Imports System.Data
Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Globalization

Public Partial Class FRM_DTR_SHIFT_MANUAL
    Inherits Form

    Private Class ShiftDefinition
        Public Property Name As String
        Public Property Coverage As String
        Public Property TotalHours As Decimal
        Public Property RegularHours As Decimal
        Public Property BaseOtHours As Decimal
        Public Property IsNightShift As Boolean
    End Class

    Private ReadOnly shifts As New List(Of ShiftDefinition)
    Private ReadOnly coveredDates As New List(Of Date)
    Private isUpdatingGrid As Boolean
    Private payrollPolicy As SubClientPayrollPolicy
    Private payrollPolicyStatusLabel As Label

    Public Sub New()
        InitializeComponent()
        SetupGridPresentation()
        SetupPeriodControls()
        SetupRuntimeHandlers()
        LoadPayrollPolicy()
        LoadSelectedEmployee()
        SetupPayrollPolicyPanel()
        BuildPeriodDates()
    End Sub

    Private Sub SetupGridPresentation()
        ConfigureWorkAreaRows()
        ConfigureGridForFullSurface(shiftGrid)
        ConfigureGridForFullSurface(holidayGrid)
        ConfigureGridForFullSurface(dailyHoursGrid)

        AddHandler shiftGrid.Resize, Sub(sender, e) FillGridRows(shiftGrid)
        AddHandler holidayGrid.Resize, Sub(sender, e) FillGridRows(holidayGrid)
        AddHandler dailyHoursGrid.Resize, Sub(sender, e) FillGridRows(dailyHoursGrid)
        AddHandler shiftGrid.CellPainting, AddressOf GridCheckBoxCellPainting
        AddHandler holidayGrid.CellPainting, AddressOf GridCheckBoxCellPainting
    End Sub

    Private Sub ConfigureWorkAreaRows()
        If workPanel.RowStyles.Count < 3 Then Return

        workPanel.RowStyles(0).SizeType = SizeType.Percent
        workPanel.RowStyles(0).Height = 30.0!
        workPanel.RowStyles(1).SizeType = SizeType.Percent
        workPanel.RowStyles(1).Height = 20.0!
        workPanel.RowStyles(2).SizeType = SizeType.Percent
        workPanel.RowStyles(2).Height = 50.0!
    End Sub

    Private Sub ConfigureGridForFullSurface(grid As DataGridView)
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        grid.ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 10.0!, FontStyle.Bold)
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grid.ColumnHeadersHeight = 46
        grid.DefaultCellStyle.Font = New Font("Verdana", 11.0!, FontStyle.Regular)
        grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 244, 184)
        grid.DefaultCellStyle.SelectionForeColor = Color.Black
        grid.RowTemplate.Height = 36
        grid.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub SetupRuntimeHandlers()
        AddHandler shiftGrid.CurrentCellDirtyStateChanged, AddressOf GridCurrentCellDirtyStateChanged
        AddHandler shiftGrid.CellClick, AddressOf ShiftGridCellClick
        AddHandler shiftGrid.CellValueChanged, AddressOf ShiftGridCellValueChanged
        AddHandler holidayGrid.CellClick, AddressOf HolidayGridCellClick
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        AddHandler btnClose.Click, AddressOf BtnClose_Click
    End Sub

    Private Sub SetupPeriodControls()
        RemoveHandler cmbYear.SelectedIndexChanged, AddressOf PeriodChanged
        RemoveHandler cmbMonth.SelectedIndexChanged, AddressOf PeriodChanged
        RemoveHandler cmbCutoff.SelectedIndexChanged, AddressOf PeriodChanged

        cmbYear.Items.Clear()
        cmbMonth.Items.Clear()
        cmbCutoff.Items.Clear()

        cmbCutoff.Items.AddRange(New Object() {"1st Cut-Off", "2nd Cut-Off"})

        For y As Integer = Date.Today.Year To 2023 Step -1
            cmbYear.Items.Add(y.ToString())
        Next

        For m As Integer = 1 To 12
            cmbMonth.Items.Add(New DateTime(1, m, 1).ToString("MMM", CultureInfo.InvariantCulture))
        Next

        cmbYear.SelectedItem = Date.Today.Year.ToString()
        cmbMonth.SelectedItem = Date.Today.ToString("MMM", CultureInfo.InvariantCulture)
        cmbCutoff.SelectedIndex = If(Date.Today.Day <= 15, 0, 1)

        AddHandler cmbYear.SelectedIndexChanged, AddressOf PeriodChanged
        AddHandler cmbMonth.SelectedIndexChanged, AddressOf PeriodChanged
        AddHandler cmbCutoff.SelectedIndexChanged, AddressOf PeriodChanged
    End Sub

    Private Sub LoadSelectedEmployee()
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then
            lblEmployee.Text = "230096 - CATAPAT, MARIBEL A."
            lblClient.Text = "Sample Detachment"
            lblAddress.Text = "Sample Address"
            lblSchedType.Text = "2SHIFTS"

            shifts.Clear()
            shifts.Add(New ShiftDefinition With {.Name = "Shift A", .Coverage = "7AM-7PM", .TotalHours = 12D, .RegularHours = 8D, .BaseOtHours = 4D, .IsNightShift = False})
            shifts.Add(New ShiftDefinition With {.Name = "Shift B", .Coverage = "7PM-7AM", .TotalHours = 12D, .RegularHours = 8D, .BaseOtHours = 4D, .IsNightShift = True})
            Return
        End If

        lblEmployee.Text = GlobalVariables.DTR_Selected_Employee_ID & " - " & GlobalVariables.DTR_Selected_Employee_Name
        lblClient.Text = GlobalVariables.DTR_Selected_SubClient_Name
        lblAddress.Text = GlobalVariables.DTR_Selected_SubClient_Address
        lblSchedType.Text = GlobalVariables.DTR_Selected_Sched_Type

        shifts.Clear()
        If UsesConfiguredSingleShift() Then
            Dim totalHours = payrollPolicy.SingleShiftHours
            Dim regularHours = Math.Min(payrollPolicy.HoursPerDay, totalHours)
            lblSchedType.Text = "SINGLE SHIFT (" & totalHours.ToString("0.##", CultureInfo.CurrentCulture) & " HRS)"
            shifts.Add(New ShiftDefinition With {
                .Name = "Single Shift",
                .Coverage = totalHours.ToString("0.##", CultureInfo.CurrentCulture) & " configured hours",
                .TotalHours = totalHours,
                .RegularHours = regularHours,
                .BaseOtHours = Math.Max(0D, totalHours - regularHours),
                .IsNightShift = payrollPolicy.SingleShiftIsNight
            })
            Return
        End If

        Select Case GlobalVariables.DTR_Selected_Sched_Type
            Case "2SHIFTS"
                shifts.Add(New ShiftDefinition With {.Name = "Shift A", .Coverage = "7AM-7PM", .TotalHours = 12D, .RegularHours = 8D, .BaseOtHours = 4D, .IsNightShift = False})
                shifts.Add(New ShiftDefinition With {.Name = "Shift B", .Coverage = "7PM-7AM", .TotalHours = 12D, .RegularHours = 8D, .BaseOtHours = 4D, .IsNightShift = True})
            Case "TRI_SHIFT"
                shifts.Add(New ShiftDefinition With {.Name = "Shift A", .Coverage = "6AM-2PM", .TotalHours = 8D, .RegularHours = 8D, .BaseOtHours = 0D, .IsNightShift = False})
                shifts.Add(New ShiftDefinition With {.Name = "Shift B", .Coverage = "2PM-10PM", .TotalHours = 8D, .RegularHours = 8D, .BaseOtHours = 0D, .IsNightShift = False})
                shifts.Add(New ShiftDefinition With {.Name = "Shift C", .Coverage = "10PM-6AM", .TotalHours = 8D, .RegularHours = 8D, .BaseOtHours = 0D, .IsNightShift = True})
        End Select
    End Sub

    Private Sub LoadPayrollPolicy()
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then
            payrollPolicy = SubClientPayrollPolicy.CreateDefault(1)
            Return
        End If

        Dim subClientId As Integer
        If Not Integer.TryParse(GlobalVariables.DTR_Selected_SubClient_ID, subClientId) OrElse subClientId <= 0 Then
            payrollPolicy = SubClientPayrollPolicy.CreateDefault(1)
            Return
        End If

        Try
            payrollPolicy = SubClientPayrollPolicyService.LoadPolicy(subClientId)
        Catch
            payrollPolicy = SubClientPayrollPolicy.CreateDefault(subClientId)
        End Try
    End Sub

    Private Sub SetupPayrollPolicyPanel()
        If headerPanel Is Nothing OrElse payrollPolicyStatusLabel IsNot Nothing Then Return

        Dim policyPanel As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(222, 245, 235),
            .Padding = New Padding(10, 7, 10, 7),
            .Margin = New Padding(0, 0, 0, 6)
        }
        Dim caption As New Label With {
            .Dock = DockStyle.Top,
            .Height = 18,
            .Text = "PAYROLL RULES",
            .Font = New Font("Verdana", 7.5!, FontStyle.Bold),
            .ForeColor = Color.Teal,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        payrollPolicyStatusLabel = New Label With {
            .Dock = DockStyle.Fill,
            .Text = SubClientPayrollPolicyService.DescribePolicy(payrollPolicy),
            .Font = New Font("Verdana", 8.5!, FontStyle.Bold),
            .ForeColor = Color.FromArgb(0, 92, 92),
            .TextAlign = ContentAlignment.MiddleLeft,
            .AutoEllipsis = True
        }
        policyPanel.Controls.Add(payrollPolicyStatusLabel)
        policyPanel.Controls.Add(caption)

        Dim userLevel = If(GlobalVariables.sUser_Level, String.Empty).Trim()
        If String.Equals(userLevel, "Administrator", StringComparison.OrdinalIgnoreCase) Then
            Dim configureLink As New LinkLabel With {
                .Dock = DockStyle.Bottom,
                .Height = 20,
                .Text = "Configure sub-client rules",
                .LinkColor = Color.Maroon,
                .TextAlign = ContentAlignment.MiddleLeft
            }
            AddHandler configureLink.LinkClicked, AddressOf ConfigurePayrollPolicy
            policyPanel.Controls.Add(configureLink)
        End If

        headerPanel.Controls.Add(policyPanel, 0, 9)
    End Sub

    Private Sub ConfigurePayrollPolicy(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim subClientId As Integer
        If Not Integer.TryParse(GlobalVariables.DTR_Selected_SubClient_ID, subClientId) Then Return

        Try
            Using form As New FRM_SUB_CLIENT_PAYROLL_SETTINGS(subClientId)
                form.ShowDialog(Me)
            End Using
            LoadPayrollPolicy()
            payrollPolicyStatusLabel.Text = SubClientPayrollPolicyService.DescribePolicy(payrollPolicy)
        Catch ex As Exception
            AppNotification.Show(ex.Message, "Payroll Rules", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub PeriodChanged(sender As Object, e As EventArgs)
        If cmbYear Is Nothing OrElse cmbMonth Is Nothing OrElse cmbCutoff Is Nothing Then Return
        If cmbYear.SelectedIndex < 0 OrElse cmbMonth.SelectedIndex < 0 OrElse cmbCutoff.SelectedIndex < 0 Then Return
        BuildPeriodDates()
    End Sub

    Private Sub BuildPeriodDates()
        If cmbYear.SelectedIndex < 0 OrElse cmbMonth.SelectedIndex < 0 OrElse cmbCutoff.SelectedIndex < 0 Then Return

        coveredDates.Clear()
        Dim yearValue As Integer = CInt(cmbYear.Text)
        Dim monthValue As Integer = DateTime.ParseExact(cmbMonth.Text.Trim().ToUpperInvariant(), "MMM", CultureInfo.InvariantCulture).Month
        Dim startDay As Integer = If(cmbCutoff.SelectedIndex = 0, 1, 16)
        Dim endDay As Integer = If(cmbCutoff.SelectedIndex = 0, 15, Date.DaysInMonth(yearValue, monthValue))

        For dayValue As Integer = startDay To endDay
            coveredDates.Add(New Date(yearValue, monthValue, dayValue))
        Next

        lblCoverage.Text = "Period: " & coveredDates.First().ToString("M/d/yyyy", CultureInfo.InvariantCulture) & " - " & coveredDates.Last().ToString("M/d/yyyy", CultureInfo.InvariantCulture)
        GlobalVariables.sPayroll_Cutoff = BuildCutoff()
        BuildShiftGrid()
        BuildDailyHoursGrid()
        BuildHolidayGrid()
        BuildFillButtons()
        RecalculateTotals()
    End Sub

    Private Function BuildCutoff() As String
        Dim monthValue As Integer = DateTime.ParseExact(cmbMonth.Text.Trim().ToUpperInvariant(), "MMM", CultureInfo.InvariantCulture).Month
        Dim cutoffText As String = If(cmbCutoff.SelectedIndex = 0, "1st", "2nd")
        Return monthValue & "_" & cutoffText & "_" & cmbYear.Text
    End Function

    Private Sub BuildShiftGrid()
        isUpdatingGrid = True
        shiftGrid.Columns.Clear()
        shiftGrid.Rows.Clear()

        shiftGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ShiftName", .HeaderText = "Shift", .ReadOnly = True, .Frozen = True, .Width = 110})
        shiftGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Coverage", .HeaderText = "Coverage", .ReadOnly = True, .Frozen = True, .Width = 110})

        For Each d As Date In coveredDates
            shiftGrid.Columns.Add(New DataGridViewCheckBoxColumn With {
                .Name = DateColumnName(d),
                .HeaderText = d.ToString("MMM d", CultureInfo.InvariantCulture) & vbCrLf & d.ToString("ddd", CultureInfo.InvariantCulture),
                .ReadOnly = True,
                .Width = 74
            })
        Next

        For Each shiftDef In shifts
            Dim rowIndex = shiftGrid.Rows.Add()
            shiftGrid.Rows(rowIndex).Cells("ShiftName").Value = shiftDef.Name
            shiftGrid.Rows(rowIndex).Cells("Coverage").Value = shiftDef.Coverage

            For Each d As Date In coveredDates
                shiftGrid.Rows(rowIndex).Cells(DateColumnName(d)).Value = True
            Next
        Next

        ApplyFullGridLayout(shiftGrid, 118, 128)
        isUpdatingGrid = False
    End Sub

    Private Sub BuildHolidayGrid()
        isUpdatingGrid = True
        holidayGrid.Columns.Clear()
        holidayGrid.Rows.Clear()
        holidayGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Label", .HeaderText = "Classification", .ReadOnly = True, .Frozen = True, .Width = 180})

        For Each d As Date In coveredDates
            holidayGrid.Columns.Add(New DataGridViewCheckBoxColumn With {
                .Name = DateColumnName(d),
                .HeaderText = d.ToString("MMM d", CultureInfo.InvariantCulture),
                .ReadOnly = True,
                .Width = 74
            })
        Next

        Dim sundayRowIndex = holidayGrid.Rows.Add()
        holidayGrid.Rows(sundayRowIndex).Cells("Label").Value = "Sunday"

        Dim shRowIndex = holidayGrid.Rows.Add()
        holidayGrid.Rows(shRowIndex).Cells("Label").Value = "Special Holiday (SH)"

        Dim lhRowIndex = holidayGrid.Rows.Add()
        holidayGrid.Rows(lhRowIndex).Cells("Label").Value = "Legal Holiday (LH)"

        For Each d As Date In coveredDates
            Dim columnName = DateColumnName(d)
            Dim sundayCell = holidayGrid.Rows(sundayRowIndex).Cells(columnName)
            sundayCell.Value = False

            If d.DayOfWeek <> DayOfWeek.Sunday Then
                sundayCell.ReadOnly = True
                sundayCell.Style.BackColor = Color.LightGray
                sundayCell.Style.SelectionBackColor = Color.LightGray
                sundayCell.ToolTipText = "Sunday can only be selected on an actual Sunday date."
            Else
                sundayCell.ToolTipText = "Select Sunday to allocate this date's shift hours to SUN instead of REG."
            End If

            holidayGrid.Rows(shRowIndex).Cells(columnName).Value = False
            holidayGrid.Rows(lhRowIndex).Cells(columnName).Value = False
            ApplyHolidayExclusionState(holidayGrid.Columns(columnName).Index)
        Next

        ApplyFullGridLayout(holidayGrid, 190)
        isUpdatingGrid = False
    End Sub

    Private Sub BuildDailyHoursGrid()
        dailyHoursGrid.Columns.Clear()
        dailyHoursGrid.Rows.Clear()
        dailyHoursGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Label", .HeaderText = "Hours Breakdown", .ReadOnly = True, .Frozen = True, .Width = 180})
        dailyHoursGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Total", .HeaderText = "Total", .ReadOnly = True, .Frozen = True, .Width = 80})

        For Each d As Date In coveredDates
            dailyHoursGrid.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = DateColumnName(d),
                .HeaderText = d.ToString("MMM d", CultureInfo.InvariantCulture),
                .ReadOnly = True,
                .Width = 74
            })
        Next

        For Each rowLabel As String In {
            "Daily Hours",
            "Regular (REG)",
            "Sunday (SUN)",
            "Legal Holiday (LH)",
            "Special Holiday (SH)",
            "Night Diff. Regular (ND REG)",
            "Night Diff. Sunday (ND SUN)",
            "Night Diff. Legal Holiday (ND LH)",
            "Night Diff. Special Holiday (ND SH)",
            "Overtime Regular (OT REG)",
            "Overtime Sunday (OT SUN)",
            "Overtime Legal Holiday (OT LH)",
            "Overtime Special Holiday (OT SH)"
        }
            Dim rowIndex = dailyHoursGrid.Rows.Add()
            dailyHoursGrid.Rows(rowIndex).Cells("Label").Value = rowLabel
        Next

        ApplyFullGridLayout(dailyHoursGrid, 190, 80)
    End Sub

    Private Sub ApplyFullGridLayout(grid As DataGridView, ParamArray fixedColumnWidths As Integer())
        If grid.Columns.Count = 0 Then Return

        For columnIndex As Integer = 0 To grid.Columns.Count - 1
            Dim column = grid.Columns(columnIndex)
            column.SortMode = DataGridViewColumnSortMode.NotSortable

            If columnIndex < fixedColumnWidths.Length Then
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                column.Width = fixedColumnWidths(columnIndex)
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Else
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                column.FillWeight = 1.0!
                column.MinimumWidth = 38
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next

        FillGridRows(grid)
    End Sub

    Private Sub FillGridRows(grid As DataGridView)
        If grid.Rows.Count = 0 OrElse grid.ClientSize.Height <= 0 Then Return

        Dim availableHeight = grid.ClientSize.Height - grid.ColumnHeadersHeight - 2
        If availableHeight <= 0 Then Return

        Dim baseHeight = Math.Max(grid.RowTemplate.Height, availableHeight \ grid.Rows.Count)
        Dim usedHeight = baseHeight * grid.Rows.Count
        Dim remainder = Math.Max(0, availableHeight - usedHeight)

        For rowIndex As Integer = 0 To grid.Rows.Count - 1
            grid.Rows(rowIndex).Height = baseHeight + If(rowIndex = grid.Rows.Count - 1, remainder, 0)
        Next
    End Sub

    Private Sub GridCheckBoxCellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim grid = TryCast(sender, DataGridView)
        If grid Is Nothing OrElse Not TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then Return

        e.Paint(e.ClipBounds, e.PaintParts And Not DataGridViewPaintParts.ContentForeground)

        Dim checked = IsCellChecked(grid.Rows(e.RowIndex).Cells(e.ColumnIndex))
        Dim boxSize = Math.Min(24, Math.Max(18, Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 14))
        Dim boxLeft = e.CellBounds.Left + ((e.CellBounds.Width - boxSize) \ 2)
        Dim boxTop = e.CellBounds.Top + ((e.CellBounds.Height - boxSize) \ 2)
        Dim boxBounds As New Rectangle(boxLeft, boxTop, boxSize, boxSize)

        Dim borderColor = If(checked, Color.FromArgb(0, 112, 112), Color.FromArgb(110, 110, 110))
        Dim fillColor = If(checked, Color.Teal, Color.White)

        Using fillBrush As New SolidBrush(fillColor)
            e.Graphics.FillRectangle(fillBrush, boxBounds)
        End Using

        Using borderPen As New Pen(borderColor, 2.0!)
            e.Graphics.DrawRectangle(borderPen, boxBounds)
        End Using

        If checked Then
            Dim oldSmoothingMode = e.Graphics.SmoothingMode
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Using checkPen As New Pen(Color.White, 3.0!)
                checkPen.StartCap = Drawing2D.LineCap.Round
                checkPen.EndCap = Drawing2D.LineCap.Round

                Dim firstPoint As New Point(boxBounds.Left + CInt(boxSize * 0.24), boxBounds.Top + CInt(boxSize * 0.54))
                Dim middlePoint As New Point(boxBounds.Left + CInt(boxSize * 0.43), boxBounds.Top + CInt(boxSize * 0.72))
                Dim lastPoint As New Point(boxBounds.Left + CInt(boxSize * 0.78), boxBounds.Top + CInt(boxSize * 0.3))

                e.Graphics.DrawLines(checkPen, New Point() {firstPoint, middlePoint, lastPoint})
            End Using

            e.Graphics.SmoothingMode = oldSmoothingMode
        End If

        e.Handled = True
    End Sub

    Private Sub BuildFillButtons()
        fillPanel.Controls.Clear()
        fillPanel.Controls.Add(ToolbarGroupLabel("Shift tools", 86))

        For i As Integer = 0 To shifts.Count - 1
            Dim shiftIndex As Integer = i
            Dim btn As New Button With {
                .Text = "Fill " & shifts(i).Name,
                .Width = 116,
                .Height = 32,
                .Margin = New Padding(0, 2, 8, 0),
                .BackColor = Color.Teal,
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat
            }
            btn.FlatAppearance.BorderSize = 0
            AddHandler btn.Click, Sub(sender, e) FillAllShift(shiftIndex)
            fillPanel.Controls.Add(btn)
        Next

        Dim clearButton As New Button With {
            .Text = "Clear All",
            .Width = 92,
            .Height = 32,
            .Margin = New Padding(0, 2, 8, 0),
            .BackColor = Color.FromArgb(245, 245, 245),
            .ForeColor = Color.Black,
            .FlatStyle = FlatStyle.Flat
        }
        clearButton.FlatAppearance.BorderSize = 0
        AddHandler clearButton.Click, Sub(sender, e) ClearAllEntries()
        fillPanel.Controls.Add(clearButton)
    End Sub

    Private Function ToolbarGroupLabel(text As String, width As Integer) As Label
        Return New Label With {
            .Text = text,
            .AutoSize = False,
            .Width = width,
            .Height = 32,
            .Margin = New Padding(0, 2, 8, 0),
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Verdana", 8.5!, FontStyle.Bold),
            .ForeColor = Color.Teal,
            .BackColor = Color.FromArgb(255, 192, 128)
        }
    End Function

    Private Sub FillAllShift(shiftIndex As Integer)
        isUpdatingGrid = True
        For Each d As Date In coveredDates
            Dim columnName = DateColumnName(d)
            If AllowsMultipleShiftsPerDate() Then
                shiftGrid.Rows(shiftIndex).Cells(columnName).Value = True
            Else
                For rowIndex As Integer = 0 To shiftGrid.Rows.Count - 1
                    shiftGrid.Rows(rowIndex).Cells(columnName).Value = (rowIndex = shiftIndex)
                Next
            End If
        Next
        isUpdatingGrid = False
        RecalculateTotals()
    End Sub

    Private Sub ClearAllEntries()
        isUpdatingGrid = True
        For Each row As DataGridViewRow In shiftGrid.Rows
            For Each d As Date In coveredDates
                row.Cells(DateColumnName(d)).Value = False
            Next
        Next
        For Each d As Date In coveredDates
            Dim columnName = DateColumnName(d)
            holidayGrid.Rows(0).Cells(columnName).Value = False
            holidayGrid.Rows(1).Cells(columnName).Value = False
            holidayGrid.Rows(2).Cells(columnName).Value = False
            ApplyHolidayExclusionState(holidayGrid.Columns(columnName).Index)
        Next
        isUpdatingGrid = False
        RecalculateTotals()
    End Sub

    Private Sub GridCurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        Dim grid = TryCast(sender, DataGridView)
        If grid IsNot Nothing AndAlso grid.IsCurrentCellDirty Then
            grid.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub ShiftGridCellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If isUpdatingGrid OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 2 Then Return

        If Not AllowsMultipleShiftsPerDate() AndAlso IsCellChecked(shiftGrid.Rows(e.RowIndex).Cells(e.ColumnIndex)) Then
            isUpdatingGrid = True
            For rowIndex As Integer = 0 To shiftGrid.Rows.Count - 1
                If rowIndex <> e.RowIndex Then
                    shiftGrid.Rows(rowIndex).Cells(e.ColumnIndex).Value = False
                End If
            Next
            isUpdatingGrid = False
        End If

        RecalculateTotals()
    End Sub

    Private Sub ShiftGridCellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 2 Then Return

        isUpdatingGrid = True
        Try
            Dim cell = shiftGrid.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim isSelected = Not IsCellChecked(cell)
            cell.Value = isSelected

            If isSelected AndAlso Not AllowsMultipleShiftsPerDate() Then
                For rowIndex As Integer = 0 To shiftGrid.Rows.Count - 1
                    If rowIndex <> e.RowIndex Then
                        shiftGrid.Rows(rowIndex).Cells(e.ColumnIndex).Value = False
                    End If
                Next
            End If
        Finally
            isUpdatingGrid = False
        End Try

        RecalculateTotals()
    End Sub

    Private Sub AnyGridCellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If isUpdatingGrid OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 1 Then Return
        RecalculateTotals()
    End Sub

    Private Sub HolidayGridCellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 1 Then Return

        Dim cell = holidayGrid.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If cell.ReadOnly AndAlso e.RowIndex = 0 AndAlso Not IsClassificationColumnSunday(e.ColumnIndex) Then Return

        Dim currentValue As Boolean = IsCellChecked(cell)

        If e.RowIndex = 0 Then
            If Not IsClassificationColumnSunday(e.ColumnIndex) Then Return
            cell.Value = Not currentValue
            If CBool(cell.Value) Then
                holidayGrid.Rows(1).Cells(e.ColumnIndex).Value = False
                holidayGrid.Rows(2).Cells(e.ColumnIndex).Value = False
            End If
            ApplyHolidayExclusionState(e.ColumnIndex)
        ElseIf e.RowIndex = 1 Then
            If IsSundayCheckedForColumn(e.ColumnIndex) Then Return
            cell.Value = Not currentValue
            If CBool(cell.Value) Then holidayGrid.Rows(2).Cells(e.ColumnIndex).Value = False
        ElseIf e.RowIndex = 2 Then
            If IsSundayCheckedForColumn(e.ColumnIndex) Then Return
            cell.Value = Not currentValue
            If CBool(cell.Value) Then holidayGrid.Rows(1).Cells(e.ColumnIndex).Value = False
        End If

        RecalculateTotals()
    End Sub

    Private Sub ApplyHolidayExclusionState(columnIndex As Integer)
        If holidayGrid.Rows.Count < 3 OrElse columnIndex < 1 Then Return

        Dim sundaySelected = IsSundayCheckedForColumn(columnIndex)

        For rowIndex As Integer = 1 To 2
            Dim cell = holidayGrid.Rows(rowIndex).Cells(columnIndex)
            cell.ReadOnly = sundaySelected
            cell.ToolTipText = If(sundaySelected, "SH and LH cannot be selected when Sunday is selected.", "")

            If sundaySelected Then
                cell.Value = False
                cell.Style.BackColor = Color.LightGray
                cell.Style.SelectionBackColor = Color.LightGray
                cell.Style.ForeColor = Color.DimGray
            Else
                cell.Style.BackColor = Color.FromArgb(255, 224, 192)
                cell.Style.SelectionBackColor = holidayGrid.DefaultCellStyle.SelectionBackColor
                cell.Style.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Function IsSundayCheckedForColumn(columnIndex As Integer) As Boolean
        If holidayGrid.Rows.Count = 0 OrElse columnIndex < 1 Then Return False
        Return IsCellChecked(holidayGrid.Rows(0).Cells(columnIndex))
    End Function

    Private Function IsClassificationColumnSunday(columnIndex As Integer) As Boolean
        If columnIndex < 1 OrElse columnIndex > coveredDates.Count Then Return False
        Return coveredDates(columnIndex - 1).DayOfWeek = DayOfWeek.Sunday
    End Function

    Private Function DateColumnName(d As Date) As String
        Return "D" & d.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
    End Function

    Private Function IsCellChecked(cell As DataGridViewCell) As Boolean
        If cell.Value Is Nothing OrElse cell.Value Is DBNull.Value Then Return False
        Dim checkedValue As Boolean
        Boolean.TryParse(cell.Value.ToString(), checkedValue)
        Return checkedValue
    End Function

    Private Function AllowsMultipleShiftsPerDate() As Boolean
        If UsesConfiguredSingleShift() Then Return False
        Return IsTriShiftSchedule() OrElse
            String.Equals(lblSchedType.Text.Trim(), "2SHIFTS", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function IsTriShiftSchedule() As Boolean
        If UsesConfiguredSingleShift() Then Return False
        Return String.Equals(lblSchedType.Text.Trim(), "TRI_SHIFT", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function UsesConfiguredSingleShift() As Boolean
        Return payrollPolicy IsNot Nothing AndAlso
            payrollPolicy.DutyEntryMode = SubClientPayrollPolicy.DutyEntrySingleShift
    End Function

    Private Function RegularHoursForSelections(selectedShifts As IEnumerable(Of ShiftDefinition)) As Decimal
        If IsTriShiftSchedule() Then
            Return selectedShifts.Sum(Function(shift) shift.TotalHours)
        End If

        Return selectedShifts.Sum(Function(shift) shift.RegularHours)
    End Function

    Private Function OvertimeHoursForSelections(selectedShifts As IEnumerable(Of ShiftDefinition)) As Decimal
        If IsTriShiftSchedule() Then Return 0D
        Return selectedShifts.Sum(Function(shift) shift.BaseOtHours)
    End Function

    Private Function SelectedShiftsForDate(d As Date) As List(Of ShiftDefinition)
        Dim selectedShifts As New List(Of ShiftDefinition)
        Dim columnName = DateColumnName(d)
        For rowIndex As Integer = 0 To shifts.Count - 1
            If IsCellChecked(shiftGrid.Rows(rowIndex).Cells(columnName)) Then
                selectedShifts.Add(shifts(rowIndex))
            End If
        Next
        Return selectedShifts
    End Function

    Private Function HolidayForDate(d As Date) As String
        If holidayGrid.Rows.Count < 3 Then Return ""
        Dim columnName = DateColumnName(d)
        If IsCellChecked(holidayGrid.Rows(1).Cells(columnName)) Then Return "SH"
        If IsCellChecked(holidayGrid.Rows(2).Cells(columnName)) Then Return "LH"
        Return ""
    End Function

    Private Function IsSundaySelected(d As Date) As Boolean
        If holidayGrid.Rows.Count = 0 Then Return False
        If d.DayOfWeek <> DayOfWeek.Sunday Then Return False
        Return IsCellChecked(holidayGrid.Rows(0).Cells(DateColumnName(d)))
    End Function

    Private Function CalculateTotals() As Dictionary(Of String, Decimal)
        Dim totals As New Dictionary(Of String, Decimal) From {
            {"NUM_DAYS", 0D},
            {"TOTAL_HOURS", 0D},
            {"REG", 0D},
            {"SUN", 0D},
            {"LH", 0D},
            {"SH", 0D},
            {"ND_REG", 0D},
            {"ND_SUN", 0D},
            {"ND_LH", 0D},
            {"ND_SH", 0D},
            {"OT_REG", 0D},
            {"OT_SUN", 0D},
            {"OT_LH", 0D},
            {"OT_SH", 0D},
            {"ND_DAYS", 0D}
        }

        For Each d As Date In coveredDates
            Dim selectedShifts = SelectedShiftsForDate(d)
            If selectedShifts.Count = 0 Then Continue For

            Dim totalHours = selectedShifts.Sum(Function(shift) shift.TotalHours)
            Dim regularHours = RegularHoursForSelections(selectedShifts)
            Dim nightHours = selectedShifts.Where(Function(shift) shift.IsNightShift).
                Sum(Function(shift) If(IsTriShiftSchedule(), shift.TotalHours, shift.RegularHours))
            Dim overtimeHours = OvertimeHoursForSelections(selectedShifts)
            Dim baseHours = If(payrollPolicy Is Nothing OrElse payrollPolicy.HoursPerDay <= 0D, 8D, payrollPolicy.HoursPerDay)
            ' Each selected shift is one reporting day. Multiple shifts selected
            ' on the same calendar date remain separate reporting days.
            totals("NUM_DAYS") += selectedShifts.Count
            totals("TOTAL_HOURS") += totalHours
            totals("ND_DAYS") += nightHours / baseHours

            Dim dayCode As String
            If IsSundaySelected(d) Then
                dayCode = "SUN"
            Else
                Select Case HolidayForDate(d)
                    Case "SH"
                        dayCode = "SH"
                    Case "LH"
                        dayCode = "LH"
                    Case Else
                        dayCode = "REG"
                End Select
            End If

            totals(dayCode) += regularHours
            totals("ND_" & dayCode) += nightHours
            totals("OT_" & dayCode) += overtimeHours
        Next

        Return totals
    End Function

    Private Function DailyTotals() As Dictionary(Of Date, Decimal)
        Dim daily As New Dictionary(Of Date, Decimal)
        For Each d As Date In coveredDates
            Dim selectedShifts = SelectedShiftsForDate(d)
            If selectedShifts.Count = 0 Then Continue For
            daily(d) = selectedShifts.Sum(Function(shift) shift.TotalHours)
        Next
        Return daily
    End Function

    Private Sub RecalculateTotals()
        Dim totals = CalculateTotals()
        UpdateDailyHoursDisplay(totals)
        lblActualReportingDays.Text = totals("NUM_DAYS").ToString("0.##")
        lblNightDifferentialDays.Text = totals("ND_DAYS").ToString("0.##")
    End Sub

    Private Sub UpdateDailyHoursDisplay(totals As Dictionary(Of String, Decimal))
        If dailyHoursGrid.Rows.Count = 0 Then Return

        Dim breakdownKeys = {
            "TOTAL_HOURS", "REG", "SUN", "LH", "SH",
            "ND_REG", "ND_SUN", "ND_LH", "ND_SH",
            "OT_REG", "OT_SUN", "OT_LH", "OT_SH"
        }
        For rowIndex As Integer = 0 To breakdownKeys.Length - 1
            dailyHoursGrid.Rows(rowIndex).Cells("Total").Value = FormatBreakdownValue(totals(breakdownKeys(rowIndex)))
        Next

        For Each d As Date In coveredDates
            Dim selectedShifts = SelectedShiftsForDate(d)
            Dim dailyValues As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)
            For Each key In breakdownKeys
                dailyValues(key) = 0D
            Next

            If selectedShifts.Count > 0 Then
                dailyValues("TOTAL_HOURS") = selectedShifts.Sum(Function(shift) shift.TotalHours)
                Dim regularHours = RegularHoursForSelections(selectedShifts)
                Dim nightHours = selectedShifts.Where(Function(shift) shift.IsNightShift).
                    Sum(Function(shift) If(IsTriShiftSchedule(), shift.TotalHours, shift.RegularHours))
                Dim overtimeHours = OvertimeHoursForSelections(selectedShifts)

                Dim dayCode As String
                If IsSundaySelected(d) Then
                    dayCode = "SUN"
                Else
                    Select Case HolidayForDate(d)
                        Case "SH"
                            dayCode = "SH"
                        Case "LH"
                            dayCode = "LH"
                        Case Else
                            dayCode = "REG"
                    End Select
                End If
                dailyValues(dayCode) = regularHours
                dailyValues("ND_" & dayCode) = nightHours
                dailyValues("OT_" & dayCode) = overtimeHours
            End If

            Dim columnName = DateColumnName(d)
            For rowIndex As Integer = 0 To breakdownKeys.Length - 1
                dailyHoursGrid.Rows(rowIndex).Cells(columnName).Value = FormatBreakdownValue(dailyValues(breakdownKeys(rowIndex)))
            Next
        Next
    End Sub

    Private Function FormatBreakdownValue(value As Decimal) As String
        If value = 0D Then Return ""
        Return value.ToString("0.##")
    End Function

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        Dim totals = CalculateTotals()
        Dim daily = DailyTotals()

        If daily.Count = 0 Then
            MsgBox("Please select at least one rendered shift before saving.", vbExclamation, "DTR")
            Return
        End If

        If MsgBox("Save DTR totals for " & GlobalVariables.DTR_Selected_Employee_Name & " / " & BuildCutoff() & "?", vbQuestion Or vbYesNo, "Save DTR") <> vbYes Then
            Return
        End If

        Try
            SubClientPayrollPolicyService.EnsureSchema()
            Connect_to_MDB()
            Using tx = GlobalVariables.GlobalCon.BeginTransaction()
                Dim totalSql As String = "INSERT INTO PRL_DTR_TOTAL_HOURS " &
                    "(EMPLOYEE_ID, SUB_CLIENT_ID, CUTOFF_PERIOD, NUM_OF_DAYS, TOTAL_HOURS, " &
                    "REG, SUN, SH, LH, ND_DAYS, ND_REG, ND_SUN, ND_SH, ND_LH, " &
                    "OT_REG, OT_SUN, OT_SH, OT_LH) " &
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

                Using cmd As New OleDbCommand(totalSql, GlobalVariables.GlobalCon, tx)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.DTR_Selected_Employee_ID)
                    cmd.Parameters.AddWithValue("?", CInt(GlobalVariables.DTR_Selected_SubClient_ID))
                    cmd.Parameters.AddWithValue("?", BuildCutoff())
                    cmd.Parameters.AddWithValue("?", CInt(totals("NUM_DAYS")))
                    cmd.Parameters.AddWithValue("?", totals("TOTAL_HOURS"))
                    cmd.Parameters.AddWithValue("?", totals("REG"))
                    cmd.Parameters.AddWithValue("?", totals("SUN"))
                    cmd.Parameters.AddWithValue("?", totals("SH"))
                    cmd.Parameters.AddWithValue("?", totals("LH"))
                    cmd.Parameters.AddWithValue("?", CInt(totals("ND_DAYS")))
                    cmd.Parameters.AddWithValue("?", totals("ND_REG"))
                    cmd.Parameters.AddWithValue("?", totals("ND_SUN"))
                    cmd.Parameters.AddWithValue("?", totals("ND_SH"))
                    cmd.Parameters.AddWithValue("?", totals("ND_LH"))
                    cmd.Parameters.AddWithValue("?", totals("OT_REG"))
                    cmd.Parameters.AddWithValue("?", totals("OT_SUN"))
                    cmd.Parameters.AddWithValue("?", totals("OT_SH"))
                    cmd.Parameters.AddWithValue("?", totals("OT_LH"))
                    cmd.ExecuteNonQuery()
                End Using

                Dim dailySql As String = "INSERT INTO PRL_DTR_HOURS_PER_DAY " &
                    "(EMPLOYEE_ID, SUB_CLIENT_ID, REPORT_DATE, REPORT_DAY, DAILY_TOTAL_HOURS) " &
                    "VALUES (?, ?, ?, ?, ?)"

                For Each item In daily.OrderBy(Function(x) x.Key)
                    Using cmd As New OleDbCommand(dailySql, GlobalVariables.GlobalCon, tx)
                        cmd.Parameters.AddWithValue("?", GlobalVariables.DTR_Selected_Employee_ID)
                        cmd.Parameters.AddWithValue("?", CInt(GlobalVariables.DTR_Selected_SubClient_ID))
                        cmd.Parameters.AddWithValue("?", item.Key)
                        cmd.Parameters.AddWithValue("?", item.Key.DayOfWeek.ToString())
                        cmd.Parameters.AddWithValue("?", item.Value)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                tx.Commit()
            End Using

            MsgBox("Manual DTR was successfully saved.", vbInformation, "DTR")
        Catch ex As Exception
            MsgBox("Error saving manual DTR: " & ex.Message, vbCritical, "DTR")
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Close()
    End Sub
End Class
