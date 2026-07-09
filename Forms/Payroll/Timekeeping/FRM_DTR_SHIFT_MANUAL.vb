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

    Public Sub New()
        InitializeComponent()
        SetupPeriodControls()
        SetupRuntimeHandlers()
        LoadSelectedEmployee()
        BuildPeriodDates()
    End Sub

    Private Sub SetupRuntimeHandlers()
        AddHandler shiftGrid.CurrentCellDirtyStateChanged, AddressOf GridCurrentCellDirtyStateChanged
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

        lblCoverage.Text = coveredDates.First().ToString("MMM d", CultureInfo.InvariantCulture) & " - " & coveredDates.Last().ToString("MMM d, yyyy", CultureInfo.InvariantCulture)
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
                .Width = 74
            })
        Next

        For Each shiftDef In shifts
            Dim rowIndex = shiftGrid.Rows.Add()
            shiftGrid.Rows(rowIndex).Cells("ShiftName").Value = shiftDef.Name
            shiftGrid.Rows(rowIndex).Cells("Coverage").Value = shiftDef.Coverage
        Next

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
            sundayCell.Value = (d.DayOfWeek = DayOfWeek.Sunday)

            If d.DayOfWeek <> DayOfWeek.Sunday Then
                sundayCell.ReadOnly = True
                sundayCell.Style.BackColor = Color.LightGray
                sundayCell.Style.SelectionBackColor = Color.LightGray
                sundayCell.ToolTipText = "Sunday can only be selected on an actual Sunday date."
            End If

            holidayGrid.Rows(shRowIndex).Cells(columnName).Value = False
            holidayGrid.Rows(lhRowIndex).Cells(columnName).Value = False
            ApplyHolidayExclusionState(holidayGrid.Columns(columnName).Index)
        Next

        isUpdatingGrid = False
    End Sub

    Private Sub BuildDailyHoursGrid()
        dailyHoursGrid.Columns.Clear()
        dailyHoursGrid.Rows.Clear()
        dailyHoursGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Label", .HeaderText = "Hours Breakdown", .ReadOnly = True, .Frozen = True, .Width = 180})

        For Each d As Date In coveredDates
            dailyHoursGrid.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = DateColumnName(d),
                .HeaderText = d.ToString("MMM d", CultureInfo.InvariantCulture),
                .ReadOnly = True,
                .Width = 74
            })
        Next

        For Each rowLabel As String In {"Daily Hours", "Regular (REG)", "Sunday (SUN)", "Special Holiday (SH)", "Legal Holiday (LH)", "Overtime (OT)"}
            Dim rowIndex = dailyHoursGrid.Rows.Add()
            dailyHoursGrid.Rows(rowIndex).Cells("Label").Value = rowLabel
        Next
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
            For rowIndex As Integer = 0 To shiftGrid.Rows.Count - 1
                shiftGrid.Rows(rowIndex).Cells(columnName).Value = (rowIndex = shiftIndex)
            Next
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
            holidayGrid.Rows(0).Cells(columnName).Value = (d.DayOfWeek = DayOfWeek.Sunday)
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

        If IsCellChecked(shiftGrid.Rows(e.RowIndex).Cells(e.ColumnIndex)) Then
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

    Private Function SelectedShiftForDate(d As Date) As ShiftDefinition
        Dim columnName = DateColumnName(d)
        For rowIndex As Integer = 0 To shifts.Count - 1
            If IsCellChecked(shiftGrid.Rows(rowIndex).Cells(columnName)) Then
                Return shifts(rowIndex)
            End If
        Next
        Return Nothing
    End Function

    Private Function HolidayForDate(d As Date) As String
        If holidayGrid.Rows.Count < 3 Then Return ""
        Dim columnName = DateColumnName(d)
        If IsCellChecked(holidayGrid.Rows(1).Cells(columnName)) Then Return "SH"
        If IsCellChecked(holidayGrid.Rows(2).Cells(columnName)) Then Return "LH"
        Return ""
    End Function

    Private Function IsSundaySelected(d As Date) As Boolean
        If holidayGrid.Rows.Count = 0 Then Return d.DayOfWeek = DayOfWeek.Sunday
        If d.DayOfWeek <> DayOfWeek.Sunday Then Return False
        Return IsCellChecked(holidayGrid.Rows(0).Cells(DateColumnName(d)))
    End Function

    Private Function CalculateTotals() As Dictionary(Of String, Decimal)
        Dim totals As New Dictionary(Of String, Decimal) From {
            {"NUM_DAYS", 0D},
            {"TOTAL_HOURS", 0D},
            {"REG", 0D},
            {"SUN", 0D},
            {"SH", 0D},
            {"LH", 0D},
            {"OT_REG", 0D},
            {"ND_DAYS", 0D}
        }

        For Each d As Date In coveredDates
            Dim selectedShift = SelectedShiftForDate(d)
            If selectedShift Is Nothing Then Continue For

            totals("NUM_DAYS") += 1D
            totals("TOTAL_HOURS") += selectedShift.TotalHours
            totals("OT_REG") += selectedShift.BaseOtHours
            If selectedShift.IsNightShift Then totals("ND_DAYS") += 1D

            If IsSundaySelected(d) Then
                totals("SUN") += selectedShift.RegularHours
            Else
                Select Case HolidayForDate(d)
                    Case "SH"
                        totals("SH") += selectedShift.RegularHours
                    Case "LH"
                        totals("LH") += selectedShift.RegularHours
                    Case Else
                        totals("REG") += selectedShift.RegularHours
                End Select
            End If
        Next

        Return totals
    End Function

    Private Function DailyTotals() As Dictionary(Of Date, Decimal)
        Dim daily As New Dictionary(Of Date, Decimal)
        For Each d As Date In coveredDates
            Dim selectedShift = SelectedShiftForDate(d)
            If selectedShift Is Nothing Then Continue For
            daily(d) = selectedShift.TotalHours
        Next
        Return daily
    End Function

    Private Sub RecalculateTotals()
        Dim totals = CalculateTotals()
        UpdateDailyHoursDisplay()
        lblNumDays.Text = "Days: " & totals("NUM_DAYS").ToString("0.##")
        lblTotalHours.Text = "Total: " & totals("TOTAL_HOURS").ToString("0.##")
        lblReg.Text = "REG: " & totals("REG").ToString("0.##")
        lblSun.Text = "SUN: " & totals("SUN").ToString("0.##")
        lblSh.Text = "SH: " & totals("SH").ToString("0.##")
        lblLh.Text = "LH: " & totals("LH").ToString("0.##")
        lblOt.Text = "OT: " & totals("OT_REG").ToString("0.##")
        lblNdDays.Text = "ND Days: " & totals("ND_DAYS").ToString("0.##")
    End Sub

    Private Sub UpdateDailyHoursDisplay()
        If dailyHoursGrid.Rows.Count = 0 Then Return

        For Each d As Date In coveredDates
            Dim selectedShift = SelectedShiftForDate(d)
            Dim dailyHours As Decimal = 0D
            Dim regHours As Decimal = 0D
            Dim sunHours As Decimal = 0D
            Dim shHours As Decimal = 0D
            Dim lhHours As Decimal = 0D
            Dim otHours As Decimal = 0D

            If selectedShift IsNot Nothing Then
                dailyHours = selectedShift.TotalHours
                otHours = selectedShift.BaseOtHours

                If IsSundaySelected(d) Then
                    sunHours = selectedShift.RegularHours
                Else
                    Select Case HolidayForDate(d)
                        Case "SH"
                            shHours = selectedShift.RegularHours
                        Case "LH"
                            lhHours = selectedShift.RegularHours
                        Case Else
                            regHours = selectedShift.RegularHours
                    End Select
                End If
            End If

            Dim columnName = DateColumnName(d)
            dailyHoursGrid.Rows(0).Cells(columnName).Value = FormatBreakdownValue(dailyHours)
            dailyHoursGrid.Rows(1).Cells(columnName).Value = FormatBreakdownValue(regHours)
            dailyHoursGrid.Rows(2).Cells(columnName).Value = FormatBreakdownValue(sunHours)
            dailyHoursGrid.Rows(3).Cells(columnName).Value = FormatBreakdownValue(shHours)
            dailyHoursGrid.Rows(4).Cells(columnName).Value = FormatBreakdownValue(lhHours)
            dailyHoursGrid.Rows(5).Cells(columnName).Value = FormatBreakdownValue(otHours)
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
            Connect_to_MDB()
            Using tx = GlobalVariables.GlobalCon.BeginTransaction()
                Dim totalSql As String = "INSERT INTO PRL_DTR_TOTAL_HOURS " &
                    "(EMPLOYEE_ID, SUB_CLIENT_ID, CUTOFF_PERIOD, NUM_OF_DAYS, TOTAL_HOURS, REG, SUN, SH, LH, OT_REG, ND_DAYS) " &
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

                Using cmd As New OleDbCommand(totalSql, GlobalVariables.GlobalCon, tx)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.DTR_Selected_Employee_ID)
                    cmd.Parameters.AddWithValue("?", CInt(GlobalVariables.DTR_Selected_SubClient_ID))
                    cmd.Parameters.AddWithValue("?", BuildCutoff())
                    cmd.Parameters.AddWithValue("?", CInt(totals("NUM_DAYS")))
                    cmd.Parameters.AddWithValue("?", totals("TOTAL_HOURS"))
                    cmd.Parameters.AddWithValue("?", totals("REG"))
                    cmd.Parameters.AddWithValue("?", totals("SUN"))
                    cmd.Parameters.AddWithValue("?", totals("SH"))
                    cmd.Parameters.AddWithValue("?", CInt(totals("LH")))
                    cmd.Parameters.AddWithValue("?", totals("OT_REG"))
                    cmd.Parameters.AddWithValue("?", CInt(totals("ND_DAYS")))
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
