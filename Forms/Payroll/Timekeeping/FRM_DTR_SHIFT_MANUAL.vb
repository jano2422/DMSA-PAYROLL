Imports System.Data
Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Globalization

Public Partial Class FRM_DTR_SHIFT_MANUAL
    Inherits Form

    Private Shared ReadOnly CanvasColor As Color = Color.FromArgb(243, 246, 248)
    Private Shared ReadOnly SurfaceColor As Color = Color.White
    Private Shared ReadOnly BorderColor As Color = Color.FromArgb(210, 218, 224)
    Private Shared ReadOnly PrimaryColor As Color = Color.FromArgb(0, 112, 118)
    Private Shared ReadOnly PrimaryDarkColor As Color = Color.FromArgb(0, 82, 87)
    Private Shared ReadOnly WarningColor As Color = Color.FromArgb(194, 124, 32)
    Private Shared ReadOnly TextColor As Color = Color.FromArgb(35, 45, 52)
    Private Shared ReadOnly MutedTextColor As Color = Color.FromArgb(91, 103, 112)
    Private Const TimelineStubWidth As Integer = 270
    Private Const ShiftNameColumnWidth As Integer = 118
    Private Const ShiftCoverageColumnWidth As Integer = TimelineStubWidth - ShiftNameColumnWidth
    Private Const BreakdownTotalColumnWidth As Integer = 80
    Private Const BreakdownLabelColumnWidth As Integer = TimelineStubWidth - BreakdownTotalColumnWidth
    Private Const MinimumTimelineDateWidth As Integer = 38
    Private Shared ReadOnly DailyBreakdownKeys As String() = {
        "TOTAL_HOURS",
        "REG", "SUN", "LH", "SH", "RD_LH", "RD_SH",
        "ND_REG", "ND_SUN", "ND_LH", "ND_SH", "ND_RD_LH", "ND_RD_SH",
        "OT_REG", "OT_SUN", "OT_LH", "OT_SH", "OT_RD_LH", "OT_RD_SH"
    }
    Private Shared ReadOnly DailyBreakdownLabels As String() = {
        "Daily Hours",
        "Regular (REG)",
        "Sunday (SUN)",
        "Legal Holiday (LH)",
        "Special Holiday (SH)",
        "Sunday + LH (SUN+LH)",
        "Sunday + SH (SUN+SH)",
        "Night Diff. Regular (ND REG)",
        "Night Diff. Sunday (ND SUN)",
        "Night Diff. Legal Holiday (ND LH)",
        "Night Diff. Special Holiday (ND SH)",
        "Night Diff. Sunday + LH",
        "Night Diff. Sunday + SH",
        "Overtime Regular (OT REG)",
        "Overtime Sunday (OT SUN)",
        "Overtime Legal Holiday (OT LH)",
        "Overtime Special Holiday (OT SH)",
        "Overtime Sunday + LH",
        "Overtime Sunday + SH"
    }

    Private Class ShiftDefinition
        Public Property Name As String
        Public Property Coverage As String
        Public Property TotalHours As Decimal
        Public Property RegularHours As Decimal
        Public Property BaseOtHours As Decimal
        Public Property IsNightShift As Boolean
    End Class

    Private Class DayHourAllocation
        Public Property ScheduledHours As Decimal
        Public Property AdjustmentHours As Decimal
        Public Property TotalHours As Decimal
        Public Property RegularHours As Decimal
        Public Property OvertimeHours As Decimal
        Public Property NightHours As Decimal
    End Class

    Private ReadOnly shifts As New List(Of ShiftDefinition)
    Private ReadOnly coveredDates As New List(Of Date)
    Private isUpdatingGrid As Boolean
    Private payrollPolicy As SubClientPayrollPolicy
    Private payrollPolicyStatusLabel As Label
    Private dailyWage As Decimal
    Private isLoadingPayrollInputs As Boolean
    Private isApplyingRecord As Boolean
    Private isRecordReadOnly As Boolean
    Private hasUnsavedChanges As Boolean
    Private isChangingPeriod As Boolean
    Private isSynchronizingTimelineScroll As Boolean
    Private lastLoadedYear As String = String.Empty
    Private lastLoadedMonth As String = String.Empty
    Private lastLoadedCutoffIndex As Integer = -1
    Private currentRecord As ManualPayrollRecord
    Private hourAdjustmentGrid As DataGridView

    Private txtOfficerAllowance As TextBox
    Private txtUniformAllowance As TextBox
    Private txtOtherEarnings As TextBox
    Private txtSssDeduction As TextBox
    Private txtSssProvidentDeduction As TextBox
    Private txtPhilHealthDeduction As TextBox
    Private txtPagIbigDeduction As TextBox
    Private txtCashBondDeduction As TextBox
    Private txtSssLoanDeduction As TextBox
    Private txtSssCalLoanDeduction As TextBox
    Private txtPagIbigLoanDeduction As TextBox
    Private txtPagIbigCalLoanDeduction As TextBox
    Private txtOtherDeductions As TextBox
    Private ReadOnly payrollInputRows As New Dictionary(Of TextBox, Control)

    Private lblDailyWageValue As Label
    Private lblWorkEarningsValue As Label
    Private lblAllowanceTotalValue As Label
    Private lblGrossPayValue As Label
    Private lblDeductionTotalValue As Label
    Private lblNetPayValue As Label
    Private lblPreviewStatus As Label
    Private lblRecordStatus As Label
    Private lblRecordMetadata As Label
    Private amendmentPanel As TableLayoutPanel
    Private txtChangeRemarks As TextBox
    Private btnSubmitFinal As Button
    Private btnFirstCutoffFile As Button
    Private btnSecondCutoffFile As Button
    Private cutoffStatusToolTip As ToolTip

    Public ReadOnly Property SelectedPayrollYear As String
        Get
            Return If(cmbYear Is Nothing, String.Empty, cmbYear.Text)
        End Get
    End Property

    Public ReadOnly Property SelectedPayrollMonth As String
        Get
            Return If(cmbMonth Is Nothing, String.Empty, cmbMonth.Text)
        End Get
    End Property

    Public ReadOnly Property SelectedPayrollCutoffIndex As Integer
        Get
            Return If(cmbCutoff Is Nothing, -1, cmbCutoff.SelectedIndex)
        End Get
    End Property

    Private Class PayrollAdjustments
        Public Property OfficerAllowance As Decimal
        Public Property UniformAllowance As Decimal
        Public Property OtherEarnings As Decimal
        Public Property SssDeduction As Decimal
        Public Property SssProvidentDeduction As Decimal
        Public Property PhilHealthDeduction As Decimal
        Public Property PagIbigDeduction As Decimal
        Public Property CashBondDeduction As Decimal
        Public Property SssLoanDeduction As Decimal
        Public Property SssCalLoanDeduction As Decimal
        Public Property PagIbigLoanDeduction As Decimal
        Public Property PagIbigCalLoanDeduction As Decimal
        Public Property OtherDeductions As Decimal

        Public Function TotalDeductions(isFirstCutoff As Boolean) As Decimal
            If isFirstCutoff Then
                Return SssDeduction + SssProvidentDeduction + PhilHealthDeduction + PagIbigDeduction + OtherDeductions
            End If

            Return CashBondDeduction + SssLoanDeduction + SssCalLoanDeduction +
                PagIbigLoanDeduction + PagIbigCalLoanDeduction + OtherDeductions
        End Function
    End Class

    Public Sub New()
        InitializeComponent()
        SetupHourAdjustmentWorkspace()
        SetupGridPresentation()
        SetupPeriodControls()
        SetupRuntimeHandlers()
        LoadPayrollPolicy()
        LoadSelectedEmployee()
        SetupPayrollWorkspace()
        BuildPeriodDates()
    End Sub

    Public Sub SetInitialPayrollPeriod(yearValue As String, monthValue As String, cutoffIndex As Integer)
        If cmbYear Is Nothing OrElse cmbMonth Is Nothing OrElse cmbCutoff Is Nothing Then Return
        If String.IsNullOrWhiteSpace(yearValue) OrElse String.IsNullOrWhiteSpace(monthValue) Then Return
        If cutoffIndex < 0 OrElse cutoffIndex >= cmbCutoff.Items.Count Then Return
        If Not cmbYear.Items.Contains(yearValue) OrElse Not cmbMonth.Items.Contains(monthValue) Then Return

        isChangingPeriod = True
        Try
            cmbYear.SelectedItem = yearValue
            cmbMonth.SelectedItem = monthValue
            cmbCutoff.SelectedIndex = cutoffIndex
        Finally
            isChangingPeriod = False
        End Try
        BuildPeriodDates()
    End Sub

    Private Sub SetupHourAdjustmentWorkspace()
        hourAdjustmentGrid = New DataGridView With {
            .Name = "hourAdjustmentGrid",
            .Dock = DockStyle.Fill,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .AllowUserToResizeRows = False,
            .RowHeadersVisible = False,
            .MultiSelect = False,
            .EditMode = DataGridViewEditMode.EditOnEnter,
            .TabIndex = holidayGrid.TabIndex + 1,
            .AccessibleName = "Daily extended or subtracted hours"
        }
        workPanel.RowCount = 4
        workPanel.RowStyles.Clear()
        workPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 23.0!))
        workPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 20.0!))
        workPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 16.0!))
        workPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 41.0!))
        workPanel.SetRow(dailyHoursGrid, 3)
        workPanel.Controls.Add(hourAdjustmentGrid, 0, 2)
    End Sub

    Private Sub SetupGridPresentation()
        ConfigureWorkAreaRows()
        ConfigureGridForFullSurface(shiftGrid)
        ConfigureGridForFullSurface(holidayGrid)
        ConfigureGridForFullSurface(hourAdjustmentGrid)
        ConfigureGridForFullSurface(dailyHoursGrid)

        AddHandler shiftGrid.Resize, Sub(sender, e) FillGridRows(shiftGrid)
        AddHandler holidayGrid.Resize, Sub(sender, e) FillGridRows(holidayGrid)
        AddHandler hourAdjustmentGrid.Resize, Sub(sender, e) FillGridRows(hourAdjustmentGrid)
        AddHandler dailyHoursGrid.Resize, Sub(sender, e) FillGridRows(dailyHoursGrid)
        AddHandler shiftGrid.CellPainting, AddressOf GridCheckBoxCellPainting
        AddHandler holidayGrid.CellPainting, AddressOf GridCheckBoxCellPainting
    End Sub

    Private Sub ConfigureWorkAreaRows()
        If workPanel.RowStyles.Count < 4 Then Return

        workPanel.RowStyles(0).SizeType = SizeType.Percent
        workPanel.RowStyles(0).Height = 23.0!
        workPanel.RowStyles(1).SizeType = SizeType.Percent
        workPanel.RowStyles(1).Height = 20.0!
        workPanel.RowStyles(2).SizeType = SizeType.Percent
        workPanel.RowStyles(2).Height = 16.0!
        workPanel.RowStyles(3).SizeType = SizeType.Percent
        workPanel.RowStyles(3).Height = 41.0!
    End Sub

    Private Sub ConfigureGridForFullSurface(grid As DataGridView)
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        grid.BackgroundColor = SurfaceColor
        grid.BorderStyle = BorderStyle.FixedSingle
        grid.GridColor = BorderColor
        grid.EnableHeadersVisualStyles = False
        grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        grid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
        grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDarkColor
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grid.ColumnHeadersHeight = 46
        grid.DefaultCellStyle.Font = New Font("Segoe UI", 10.0!, FontStyle.Regular)
        grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grid.DefaultCellStyle.BackColor = Color.White
        grid.DefaultCellStyle.ForeColor = TextColor
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(213, 238, 239)
        grid.DefaultCellStyle.SelectionForeColor = TextColor
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 251)
        grid.RowTemplate.Height = 36
        grid.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub ApplyModernVisualDesign()
        Me.BackColor = CanvasColor
        Me.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
        rootPanel.BackColor = CanvasColor
        rootPanel.Padding = New Padding(12)
        If rootPanel.RowStyles.Count > 0 Then rootPanel.RowStyles(0).Height = 62.0!
        toolbarPanel.BackColor = BorderColor
        toolbarPanel.Padding = New Padding(0, 0, 0, 1)
        periodPanel.BackColor = SurfaceColor
        periodPanel.Padding = New Padding(10, 9, 8, 0)
        periodPanel.WrapContents = False
        workPanel.BackColor = CanvasColor
        shiftSection.BackColor = CanvasColor
        shiftSection.Margin = Padding.Empty
        shiftGrid.Margin = Padding.Empty
        holidayGrid.Margin = Padding.Empty
        hourAdjustmentGrid.Margin = Padding.Empty
        dailyHoursGrid.Margin = Padding.Empty
        fillPanel.BackColor = CanvasColor
        headerPanel.BackColor = CanvasColor
        footerPanel.BackColor = CanvasColor

        lblPeriodTitle.BackColor = SurfaceColor
        lblPeriodTitle.ForeColor = PrimaryDarkColor
        lblPeriodTitle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
        For Each periodLabel In {lblYear, lblMonth, lblCutoff}
            periodLabel.BackColor = SurfaceColor
            periodLabel.ForeColor = MutedTextColor
            periodLabel.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular)
        Next
        For Each selector In {cmbYear, cmbMonth, cmbCutoff}
            selector.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            selector.FlatStyle = FlatStyle.Flat
            selector.BackColor = Color.White
        Next

        btnClose.BackColor = SurfaceColor
        btnClose.ForeColor = TextColor
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderColor = BorderColor
        btnClose.FlatAppearance.BorderSize = 1
        btnSave.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
        If btnSubmitFinal IsNot Nothing Then btnSubmitFinal.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)

        For Each grid In {shiftGrid, holidayGrid, hourAdjustmentGrid, dailyHoursGrid}
            ConfigureGridForFullSurface(grid)
        Next
        hourAdjustmentGrid.ColumnHeadersHeight = 46
        hourAdjustmentGrid.RowTemplate.Height = 28
        FillGridRows(hourAdjustmentGrid)
    End Sub

    Private Sub SetupRuntimeHandlers()
        AddHandler shiftGrid.CurrentCellDirtyStateChanged, AddressOf GridCurrentCellDirtyStateChanged
        AddHandler shiftGrid.CellClick, AddressOf ShiftGridCellClick
        AddHandler shiftGrid.CellValueChanged, AddressOf ShiftGridCellValueChanged
        AddHandler holidayGrid.CellClick, AddressOf HolidayGridCellClick
        AddHandler hourAdjustmentGrid.CellValidating, AddressOf HourAdjustmentCellValidating
        AddHandler hourAdjustmentGrid.CellValueChanged, AddressOf HourAdjustmentCellValueChanged
        AddHandler hourAdjustmentGrid.EditingControlShowing, AddressOf HourAdjustmentEditingControlShowing
        AddHandler workPanel.Resize, AddressOf TimelineWorkspaceResize
        AddHandler shiftGrid.Scroll, AddressOf TimelineGridScrolled
        AddHandler holidayGrid.Scroll, AddressOf TimelineGridScrolled
        AddHandler hourAdjustmentGrid.Scroll, AddressOf TimelineGridScrolled
        AddHandler dailyHoursGrid.Scroll, AddressOf TimelineGridScrolled
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        AddHandler btnClose.Click, AddressOf BtnClose_Click
        AddHandler Me.FormClosing, AddressOf ManualPayrollFormClosing
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

    Private Sub SetupPayrollWorkspace()
        If headerPanel Is Nothing OrElse payrollPolicyStatusLabel IsNot Nothing Then Return

        headerPanel.SuspendLayout()
        headerPanel.Controls.Clear()
        headerPanel.Padding = New Padding(8)
        headerPanel.ColumnCount = 1
        headerPanel.ColumnStyles.Clear()
        headerPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        headerPanel.RowCount = 6
        headerPanel.RowStyles.Clear()
        headerPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 68.0!))
        headerPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 102.0!))
        headerPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
        headerPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 0.0!))
        headerPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 176.0!))
        headerPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 96.0!))

        headerPanel.Controls.Add(BuildRecordHeaderPanel(), 0, 0)
        headerPanel.Controls.Add(BuildEmployeeSummaryPanel(), 0, 1)
        headerPanel.Controls.Add(BuildPayrollInputsPanel(), 0, 2)
        headerPanel.Controls.Add(BuildAmendmentPanel(), 0, 3)
        headerPanel.Controls.Add(BuildPayrollPreviewPanel(), 0, 4)

        footerPanel.SuspendLayout()
        footerPanel.Controls.Clear()
        footerPanel.ColumnCount = 2
        footerPanel.RowCount = 2
        footerPanel.ColumnStyles.Clear()
        footerPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 74.0!))
        footerPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 26.0!))
        footerPanel.RowStyles.Clear()
        footerPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        footerPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        footerPanel.Margin = New Padding(0, 6, 0, 0)
        btnSave.Text = "Save Draft"
        btnSave.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
        btnSave.BackColor = WarningColor
        btnSave.TabIndex = 0
        btnSubmitFinal = New Button With {
            .Dock = DockStyle.Fill,
            .Text = "Submit Final",
            .Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold),
            .BackColor = PrimaryColor,
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Margin = New Padding(3),
            .TabIndex = 1
        }
        btnSubmitFinal.FlatAppearance.BorderSize = 0
        AddHandler btnSubmitFinal.Click, AddressOf BtnSubmitFinal_Click
        footerPanel.Controls.Add(btnSave, 0, 0)
        btnClose.TabIndex = 2
        footerPanel.Controls.Add(btnClose, 1, 0)
        footerPanel.SetRowSpan(btnClose, 2)
        footerPanel.Controls.Add(btnSubmitFinal, 0, 1)
        footerPanel.ResumeLayout()
        headerPanel.Controls.Add(footerPanel, 0, 5)
        SetupCutoffFileTabs()
        headerPanel.ResumeLayout()
    End Sub

    Private Function BuildRecordHeaderPanel() As Control
        Dim paper As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 2,
            .BackColor = SurfaceColor,
            .Padding = New Padding(10, 6, 10, 5),
            .Margin = New Padding(0, 0, 0, 6),
            .CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        }
        paper.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 58.0!))
        paper.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 42.0!))
        paper.RowStyles.Add(New RowStyle(SizeType.Absolute, 31.0!))
        paper.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))

        lblHeaderTitle.Text = "Payroll cutoff file"
        lblHeaderTitle.Dock = DockStyle.Fill
        lblHeaderTitle.Margin = New Padding(0)
        lblHeaderTitle.BackColor = Color.Transparent
        lblHeaderTitle.ForeColor = TextColor
        lblHeaderTitle.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblHeaderTitle.TextAlign = ContentAlignment.MiddleLeft

        lblRecordStatus = New Label With {
            .Dock = DockStyle.Fill,
            .Text = "NOT STARTED",
            .Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold),
            .BackColor = Color.FromArgb(235, 239, 242),
            .ForeColor = MutedTextColor,
            .BorderStyle = BorderStyle.FixedSingle,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Margin = New Padding(6, 0, 0, 0)
        }
        lblRecordMetadata = New Label With {
            .Dock = DockStyle.Fill,
            .Text = "No saved record exists for this cutoff.",
            .Font = New Font("Segoe UI", 7.75!, FontStyle.Regular),
            .ForeColor = MutedTextColor,
            .TextAlign = ContentAlignment.MiddleLeft,
            .AutoEllipsis = True,
            .Margin = New Padding(0)
        }
        paper.Controls.Add(lblHeaderTitle, 0, 0)
        paper.Controls.Add(lblRecordStatus, 1, 0)
        paper.Controls.Add(lblRecordMetadata, 0, 1)
        paper.SetColumnSpan(lblRecordMetadata, 2)
        Return paper
    End Function

    Private Sub SetupCutoffFileTabs()
        If btnFirstCutoffFile IsNot Nothing Then Return
        cutoffStatusToolTip = New ToolTip()

        Dim caption As New Label With {
            .Text = "Cutoff status",
            .AutoSize = False,
            .Width = 106,
            .Height = 32,
            .Margin = New Padding(18, 2, 6, 0),
            .Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold),
            .ForeColor = MutedTextColor,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        btnFirstCutoffFile = CreateCutoffFileButton("1ST  NOT STARTED", 0)
        btnSecondCutoffFile = CreateCutoffFileButton("2ND  NOT STARTED", 1)
        periodPanel.Controls.Add(caption)
        periodPanel.Controls.Add(btnFirstCutoffFile)
        periodPanel.Controls.Add(btnSecondCutoffFile)
    End Sub

    Private Function CreateCutoffFileButton(text As String, cutoffIndex As Integer) As Button
        Dim button As New Button With {
            .Text = text,
            .Width = 154,
            .Height = 32,
            .Margin = New Padding(0, 2, 6, 0),
            .Font = New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(239, 242, 244),
            .ForeColor = MutedTextColor,
            .TextAlign = ContentAlignment.MiddleCenter,
            .AccessibleName = If(cutoffIndex = 0, "First cutoff employee file", "Second cutoff employee file")
        }
        button.FlatAppearance.BorderColor = BorderColor
        button.FlatAppearance.BorderSize = 1
        AddHandler button.Click,
            Sub(sender, e)
                If cmbCutoff.SelectedIndex <> cutoffIndex Then cmbCutoff.SelectedIndex = cutoffIndex
            End Sub
        Return button
    End Function

    Private Function BuildEmployeeSummaryPanel() As Control
        Dim panel As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 5,
            .BackColor = Color.White,
            .Padding = New Padding(8, 6, 8, 6),
            .Margin = New Padding(0, 0, 0, 6)
        }
        panel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 104.0!))
        panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        For rowIndex As Integer = 0 To 4
            panel.RowStyles.Add(New RowStyle(SizeType.Percent, 20.0!))
        Next

        AddSummaryRow(panel, 0, "EMPLOYEE", lblEmployee)
        AddSummaryRow(panel, 1, "DETACHMENT", lblClient)
        AddSummaryRow(panel, 2, "SCHEDULE", lblSchedType)
        AddSummaryRow(panel, 3, "COVERAGE", lblCoverage)
        lblDailyWageValue = New Label With {.Text = "PHP 0.00"}
        AddSummaryRow(panel, 4, "DAILY WAGE", lblDailyWageValue)
        Return panel
    End Function

    Private Sub AddSummaryRow(panel As TableLayoutPanel, rowIndex As Integer, caption As String, valueLabel As Label)
        Dim captionLabel As New Label With {
            .Dock = DockStyle.Fill,
            .Text = caption,
            .Font = New Font("Segoe UI Semibold", 7.75!, FontStyle.Bold),
            .ForeColor = PrimaryDarkColor,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        valueLabel.Dock = DockStyle.Fill
        valueLabel.Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold)
        valueLabel.ForeColor = TextColor
        valueLabel.BackColor = SurfaceColor
        valueLabel.TextAlign = ContentAlignment.MiddleLeft
        valueLabel.AutoEllipsis = True
        valueLabel.Padding = New Padding(4, 0, 0, 0)
        panel.Controls.Add(captionLabel, 0, rowIndex)
        panel.Controls.Add(valueLabel, 1, rowIndex)
    End Sub

    Private Function BuildPayrollInputsPanel() As Control
        Dim outer As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 3,
            .BackColor = SurfaceColor,
            .Padding = New Padding(8, 6, 8, 6),
            .Margin = New Padding(0, 0, 0, 6)
        }
        outer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        outer.RowStyles.Add(New RowStyle(SizeType.Absolute, 24.0!))
        outer.RowStyles.Add(New RowStyle(SizeType.Absolute, 38.0!))
        outer.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))

        Dim title As New Label With {
            .Dock = DockStyle.Fill,
            .Text = "ALLOWANCES AND DEDUCTIONS",
            .Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold),
            .ForeColor = PrimaryDarkColor,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        payrollPolicyStatusLabel = New Label With {
            .Dock = DockStyle.Fill,
            .Text = SubClientPayrollPolicyService.DescribePolicy(payrollPolicy),
            .Font = New Font("Segoe UI", 8.0!, FontStyle.Regular),
            .ForeColor = MutedTextColor,
            .TextAlign = ContentAlignment.MiddleLeft,
            .AutoEllipsis = True
        }

        Dim inputHost As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .AutoScroll = True,
            .BackColor = Color.White,
            .Padding = New Padding(2)
        }

        txtOfficerAllowance = AddMoneyInputRow(inputHost, "Officer's allowance")
        txtUniformAllowance = AddMoneyInputRow(inputHost, "SG uniform allowance")
        txtOtherEarnings = AddMoneyInputRow(inputHost, "Other earnings")
        txtSssDeduction = AddMoneyInputRow(inputHost, "SSS contribution")
        txtSssProvidentDeduction = AddMoneyInputRow(inputHost, "SSS Provident")
        txtPhilHealthDeduction = AddMoneyInputRow(inputHost, "PhilHealth")
        txtPagIbigDeduction = AddMoneyInputRow(inputHost, "Pag-IBIG contribution")
        txtCashBondDeduction = AddMoneyInputRow(inputHost, "Cash bond")
        txtSssLoanDeduction = AddMoneyInputRow(inputHost, "SSS salary loan")
        txtSssCalLoanDeduction = AddMoneyInputRow(inputHost, "SSS calamity loan")
        txtPagIbigLoanDeduction = AddMoneyInputRow(inputHost, "Pag-IBIG salary loan")
        txtPagIbigCalLoanDeduction = AddMoneyInputRow(inputHost, "Pag-IBIG calamity loan")
        txtOtherDeductions = AddMoneyInputRow(inputHost, "Other deductions")

        AddHandler inputHost.Resize,
            Sub(sender, e)
                Dim availableWidth = Math.Max(260, inputHost.ClientSize.Width - 8)
                For Each row As Control In inputHost.Controls
                    row.Width = availableWidth
                Next
            End Sub

        outer.Controls.Add(title, 0, 0)
        outer.Controls.Add(payrollPolicyStatusLabel, 0, 1)
        outer.Controls.Add(inputHost, 0, 2)

        Dim userLevel = If(GlobalVariables.sUser_Level, String.Empty).Trim()
        If String.Equals(userLevel, "Administrator", StringComparison.OrdinalIgnoreCase) Then
            Dim configureLink As New LinkLabel With {
                .Dock = DockStyle.Right,
                .Width = 92,
                .Text = "Edit rules",
                .LinkColor = PrimaryDarkColor,
                .TextAlign = ContentAlignment.MiddleRight,
                .Font = New Font("Verdana", 7.25!, FontStyle.Bold)
            }
            AddHandler configureLink.LinkClicked, AddressOf ConfigurePayrollPolicy
            title.Controls.Add(configureLink)
        End If

        Return outer
    End Function

    Private Function AddMoneyInputRow(host As FlowLayoutPanel, caption As String) As TextBox
        Dim row As New Panel With {
            .Height = 36,
            .Width = 340,
            .Margin = New Padding(0, 0, 0, 2),
            .BackColor = Color.White
        }
        Dim input As New TextBox With {
            .Dock = DockStyle.Right,
            .Width = 118,
            .Text = "0",
            .TextAlign = HorizontalAlignment.Right,
            .Font = New Font("Segoe UI", 9.0!, FontStyle.Regular),
            .Margin = New Padding(4)
        }
        Dim peso As New Label With {
            .Dock = DockStyle.Right,
            .Width = 34,
            .Text = "PHP",
            .Font = New Font("Segoe UI Semibold", 7.5!, FontStyle.Bold),
            .ForeColor = Color.DimGray,
            .TextAlign = ContentAlignment.MiddleRight,
            .Padding = New Padding(0, 0, 4, 0)
        }
        Dim label As New Label With {
            .Dock = DockStyle.Fill,
            .Text = caption,
            .Font = New Font("Segoe UI", 8.75!, FontStyle.Regular),
            .ForeColor = TextColor,
            .TextAlign = ContentAlignment.MiddleLeft,
            .AutoEllipsis = True
        }
        row.Controls.Add(label)
        row.Controls.Add(peso)
        row.Controls.Add(input)
        host.Controls.Add(row)
        payrollInputRows(input) = row
        AddHandler input.TextChanged, AddressOf PayrollInputChanged
        Return input
    End Function

    Private Function BuildAmendmentPanel() As Control
        amendmentPanel = New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 1,
            .RowCount = 3,
            .BackColor = Color.FromArgb(255, 248, 232),
            .Padding = New Padding(10, 6, 10, 6),
            .Margin = New Padding(0, 0, 0, 6),
            .Visible = False
        }
        amendmentPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        amendmentPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 24.0!))
        amendmentPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
        amendmentPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22.0!))

        Dim title As New Label With {
            .Dock = DockStyle.Fill,
            .Text = "AMENDMENT REMARKS · REQUIRED",
            .Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold),
            .ForeColor = Color.FromArgb(133, 75, 13),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        txtChangeRemarks = New TextBox With {
            .Dock = DockStyle.Fill,
            .Multiline = True,
            .ScrollBars = ScrollBars.Vertical,
            .MaxLength = 1000,
            .Font = New Font("Segoe UI", 9.0!, FontStyle.Regular),
            .BackColor = Color.White,
            .AccessibleName = "Required payroll amendment remarks"
        }
        AddHandler txtChangeRemarks.TextChanged, AddressOf AmendmentRemarksChanged
        Dim helper As New Label With {
            .Dock = DockStyle.Fill,
            .Text = "Explain what changed and why. This is saved in the payroll audit history.",
            .Font = New Font("Segoe UI", 7.5!, FontStyle.Italic),
            .ForeColor = MutedTextColor,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        amendmentPanel.Controls.Add(title, 0, 0)
        amendmentPanel.Controls.Add(txtChangeRemarks, 0, 1)
        amendmentPanel.Controls.Add(helper, 0, 2)
        Return amendmentPanel
    End Function

    Private Sub SetAmendmentPanelVisible(visible As Boolean)
        If amendmentPanel Is Nothing OrElse headerPanel.RowStyles.Count < 6 Then Return
        amendmentPanel.Visible = visible
        headerPanel.RowStyles(3).SizeType = SizeType.Absolute
        headerPanel.RowStyles(3).Height = If(visible, 116.0!, 0.0!)
    End Sub

    Private Sub AmendmentRemarksChanged(sender As Object, e As EventArgs)
        If isApplyingRecord OrElse isLoadingPayrollInputs Then Return
        If currentRecord Is Nothing OrElse currentRecord.RecordStatus <> ManualPayrollRecordService.StatusAmendmentDraft Then Return
        MarkRecordDirty()
    End Sub

    Private Function BuildPayrollPreviewPanel() As Control
        Dim panel As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 7,
            .BackColor = Color.FromArgb(232, 246, 242),
            .Padding = New Padding(10, 5, 10, 5),
            .Margin = New Padding(0, 0, 0, 0)
        }
        panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 58.0!))
        panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 42.0!))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 26.0!))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22.0!))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22.0!))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 24.0!))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 22.0!))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 34.0!))
        panel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))

        Dim title As New Label With {
            .Dock = DockStyle.Fill,
            .Text = "PAYROLL CALCULATION PREVIEW",
            .Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold),
            .ForeColor = PrimaryDarkColor,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        panel.Controls.Add(title, 0, 0)
        panel.SetColumnSpan(title, 2)

        lblWorkEarningsValue = AddPreviewRow(panel, 1, "Work earnings")
        lblAllowanceTotalValue = AddPreviewRow(panel, 2, "Allowances")
        lblGrossPayValue = AddPreviewRow(panel, 3, "Gross pay", True)
        lblDeductionTotalValue = AddPreviewRow(panel, 4, "Deductions")
        lblNetPayValue = AddPreviewRow(panel, 5, "ESTIMATED NET PAY", True)
        lblNetPayValue.Font = New Font("Segoe UI Semibold", 12.0!, FontStyle.Bold)
        lblNetPayValue.ForeColor = PrimaryDarkColor

        lblPreviewStatus = New Label With {
            .Dock = DockStyle.Fill,
            .Text = "Preview updates as shifts and payroll inputs change.",
            .Font = New Font("Verdana", 7.0!, FontStyle.Italic),
            .ForeColor = Color.DimGray,
            .TextAlign = ContentAlignment.MiddleLeft,
            .AutoEllipsis = True
        }
        panel.Controls.Add(lblPreviewStatus, 0, 6)
        panel.SetColumnSpan(lblPreviewStatus, 2)
        Return panel
    End Function

    Private Function AddPreviewRow(panel As TableLayoutPanel, rowIndex As Integer, caption As String, Optional emphasize As Boolean = False) As Label
        Dim selectedFontStyle As FontStyle = If(emphasize, FontStyle.Bold, FontStyle.Regular)
        Dim captionLabel As New Label With {
            .Dock = DockStyle.Fill,
            .Text = caption,
            .Font = New Font("Verdana", 8.0!, selectedFontStyle),
            .ForeColor = Color.FromArgb(55, 55, 55),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        Dim valueLabel As New Label With {
            .Dock = DockStyle.Fill,
            .Text = "PHP 0.00",
            .Font = New Font("Verdana", 8.5!, selectedFontStyle),
            .ForeColor = Color.FromArgb(55, 55, 55),
            .TextAlign = ContentAlignment.MiddleRight
        }
        panel.Controls.Add(captionLabel, 0, rowIndex)
        panel.Controls.Add(valueLabel, 1, rowIndex)
        Return valueLabel
    End Function

    Private Sub ConfigurePayrollPolicy(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim subClientId As Integer
        If Not Integer.TryParse(GlobalVariables.DTR_Selected_SubClient_ID, subClientId) Then Return

        Try
            Using form As New FRM_SUB_CLIENT_PAYROLL_SETTINGS(subClientId)
                form.ShowDialog(Me)
            End Using
            LoadPayrollPolicy()
            payrollPolicyStatusLabel.Text = SubClientPayrollPolicyService.DescribePolicy(payrollPolicy)
            LoadSelectedEmployee()
            BuildPeriodDates()
        Catch ex As Exception
            AppNotification.Show(ex.Message, "Payroll Rules", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub PayrollInputChanged(sender As Object, e As EventArgs)
        If isLoadingPayrollInputs Then Return
        RefreshPayrollPreview()
        MarkRecordDirty()
    End Sub

    Private Function IsFirstCutoffSelected() As Boolean
        Return cmbCutoff IsNot Nothing AndAlso cmbCutoff.SelectedIndex = 0
    End Function

    Private Sub LoadPayrollInputs(record As ManualPayrollRecord)
        If txtOfficerAllowance Is Nothing Then Return

        isLoadingPayrollInputs = True
        Try
            dailyWage = 0D

            If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then
                dailyWage = 610D
            Else
                Dim subClientId As Integer
                If Integer.TryParse(GlobalVariables.DTR_Selected_SubClient_ID, subClientId) AndAlso subClientId > 0 Then
                    dailyWage = LoadDailyWage(subClientId)
                End If
            End If

            SetMoneyInput(txtOfficerAllowance, If(record Is Nothing, 0D, record.OfficerAllowance))
            SetMoneyInput(txtUniformAllowance, If(record Is Nothing, 0D, record.UniformAllowance))
            SetMoneyInput(txtOtherEarnings, If(record Is Nothing, 0D, record.OtherEarnings))
            SetMoneyInput(txtSssDeduction, If(record Is Nothing, 0D, record.SssDeduction))
            SetMoneyInput(txtSssProvidentDeduction, If(record Is Nothing, 0D, record.SssProvidentDeduction))
            SetMoneyInput(txtPhilHealthDeduction, If(record Is Nothing, 0D, record.PhilHealthDeduction))
            SetMoneyInput(txtPagIbigDeduction, If(record Is Nothing, 0D, record.PagIbigDeduction))
            SetMoneyInput(txtCashBondDeduction, If(record Is Nothing, 0D, record.CashBondDeduction))
            SetMoneyInput(txtSssLoanDeduction, If(record Is Nothing, 0D, record.SssLoanDeduction))
            SetMoneyInput(txtSssCalLoanDeduction, If(record Is Nothing, 0D, record.SssCalLoanDeduction))
            SetMoneyInput(txtPagIbigLoanDeduction, If(record Is Nothing, 0D, record.PagIbigLoanDeduction))
            SetMoneyInput(txtPagIbigCalLoanDeduction, If(record Is Nothing, 0D, record.PagIbigCalLoanDeduction))
            SetMoneyInput(txtOtherDeductions, If(record Is Nothing, 0D, record.OtherDeductions))

            If lblDailyWageValue IsNot Nothing Then lblDailyWageValue.Text = FormatPeso(dailyWage)
            UpdateCutoffInputVisibility()
        Finally
            isLoadingPayrollInputs = False
        End Try

        RefreshPayrollPreview()
    End Sub

    Private Function LoadDailyWage(subClientId As Integer) As Decimal
        Dim result As Decimal = 0D
        Try
            Connect_to_MDB()
            Using wageCommand As New OleDbCommand("SELECT DAILY_WAGE FROM TBL_CLIENT_SUB WHERE SUB_CLIENT_ID = ?", GlobalVariables.GlobalCon)
                wageCommand.Parameters.AddWithValue("?", subClientId)
                Dim wageResult = wageCommand.ExecuteScalar()
                If wageResult IsNot Nothing AndAlso wageResult IsNot DBNull.Value Then
                    Decimal.TryParse(Convert.ToString(wageResult), result)
                End If
            End Using
        Catch ex As Exception
            If lblPreviewStatus IsNot Nothing Then
                lblPreviewStatus.Text = "Daily wage could not be loaded: " & ex.Message
                lblPreviewStatus.ForeColor = Color.Maroon
            End If
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try

        Return result
    End Function

    Private Sub SetMoneyInput(input As TextBox, value As Decimal)
        If input Is Nothing Then Return
        input.Text = value.ToString("0.##", CultureInfo.CurrentCulture)
        input.BackColor = Color.White
    End Sub

    Private Sub UpdateCutoffInputVisibility()
        Dim firstCutoff = IsFirstCutoffSelected()
        SetPayrollInputVisible(txtSssDeduction, firstCutoff)
        SetPayrollInputVisible(txtSssProvidentDeduction, firstCutoff)
        SetPayrollInputVisible(txtPhilHealthDeduction, firstCutoff)
        SetPayrollInputVisible(txtPagIbigDeduction, firstCutoff)
        SetPayrollInputVisible(txtCashBondDeduction, Not firstCutoff)
        SetPayrollInputVisible(txtSssLoanDeduction, Not firstCutoff)
        SetPayrollInputVisible(txtSssCalLoanDeduction, Not firstCutoff)
        SetPayrollInputVisible(txtPagIbigLoanDeduction, Not firstCutoff)
        SetPayrollInputVisible(txtPagIbigCalLoanDeduction, Not firstCutoff)
        SetPayrollInputVisible(txtOtherEarnings, True)
        SetPayrollInputVisible(txtOtherDeductions, True)

        If payrollPolicyStatusLabel IsNot Nothing Then
            Dim cutoffDescription = If(firstCutoff,
                "1st cutoff: statutory contributions",
                "2nd cutoff: loans and cash bond")
            payrollPolicyStatusLabel.Text = cutoffDescription & " | " &
                SubClientPayrollPolicyService.DescribePolicy(payrollPolicy)
        End If
    End Sub

    Private Sub SetPayrollInputVisible(input As TextBox, visible As Boolean)
        If input Is Nothing OrElse Not payrollInputRows.ContainsKey(input) Then Return
        payrollInputRows(input).Visible = visible
    End Sub

    Private Function TryReadPayrollAdjustments(ByRef adjustments As PayrollAdjustments, showValidation As Boolean) As Boolean
        adjustments = New PayrollAdjustments()
        If Not TryReadAdjustmentField(txtOfficerAllowance, "Officer's allowance", adjustments.OfficerAllowance, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtUniformAllowance, "SG uniform allowance", adjustments.UniformAllowance, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtOtherEarnings, "Other earnings", adjustments.OtherEarnings, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtSssDeduction, "SSS contribution", adjustments.SssDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtSssProvidentDeduction, "SSS Provident", adjustments.SssProvidentDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtPhilHealthDeduction, "PhilHealth", adjustments.PhilHealthDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtPagIbigDeduction, "Pag-IBIG contribution", adjustments.PagIbigDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtCashBondDeduction, "Cash bond", adjustments.CashBondDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtSssLoanDeduction, "SSS salary loan", adjustments.SssLoanDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtSssCalLoanDeduction, "SSS calamity loan", adjustments.SssCalLoanDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtPagIbigLoanDeduction, "Pag-IBIG salary loan", adjustments.PagIbigLoanDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtPagIbigCalLoanDeduction, "Pag-IBIG calamity loan", adjustments.PagIbigCalLoanDeduction, showValidation) Then Return False
        If Not TryReadAdjustmentField(txtOtherDeductions, "Other deductions", adjustments.OtherDeductions, showValidation) Then Return False
        Return True
    End Function

    Private Function TryReadAdjustmentField(input As TextBox, fieldName As String, ByRef value As Decimal, showValidation As Boolean) As Boolean
        If TryReadMoneyInput(input, value) Then
            input.BackColor = Color.White
            Return True
        End If

        input.BackColor = Color.MistyRose
        If showValidation Then
            AppNotification.Show("Enter a valid non-negative amount for " & fieldName & ".", "Payroll Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            input.Focus()
        End If
        Return False
    End Function

    Private Function TryReadMoneyInput(input As TextBox, ByRef value As Decimal) As Boolean
        value = 0D
        If input Is Nothing OrElse String.IsNullOrWhiteSpace(input.Text) Then Return True
        Dim cleaned = input.Text.Trim().Replace("PHP", "").Replace(",", "").Trim()
        If Not Decimal.TryParse(cleaned, NumberStyles.Number Or NumberStyles.AllowLeadingSign,
            CultureInfo.CurrentCulture, value) AndAlso
           Not Decimal.TryParse(cleaned, NumberStyles.Number Or NumberStyles.AllowLeadingSign,
            CultureInfo.InvariantCulture, value) Then
            Return False
        End If
        Return value >= 0D
    End Function

    Private Sub RefreshPayrollPreview(Optional totalsOverride As Dictionary(Of String, Decimal) = Nothing)
        If lblNetPayValue Is Nothing OrElse dailyHoursGrid.Rows.Count = 0 Then Return

        Dim adjustments As PayrollAdjustments = Nothing
        If Not TryReadPayrollAdjustments(adjustments, False) Then
            lblWorkEarningsValue.Text = "-"
            lblAllowanceTotalValue.Text = "-"
            lblGrossPayValue.Text = "-"
            lblDeductionTotalValue.Text = "-"
            lblNetPayValue.Text = "-"
            lblNetPayValue.ForeColor = Color.Maroon
            lblPreviewStatus.Text = "Correct the highlighted amount to restore the preview."
            lblPreviewStatus.ForeColor = Color.Maroon
            Return
        End If

        Dim totals = If(totalsOverride, CalculateTotals())
        Dim workEarnings As Decimal
        If totalsOverride Is Nothing Then
            workEarnings = SubClientPayrollPolicyService.CalculateEarningsBreakdownForDays(
                payrollPolicy,
                dailyWage,
                BuildCutoff(),
                totals("NUM_DAYS"),
                BuildPayrollDayEarningInputs(),
                0D,
                0D,
                0D).WorkEarnings
        Else
            ' Historical summaries do not retain enough date-level context to
            ' distinguish an ordinary holiday from a holiday that falls on Sunday.
            workEarnings = SubClientPayrollPolicyService.CalculateTotalEarnings(
                payrollPolicy,
                dailyWage,
                BuildCutoff(),
                totals("NUM_DAYS"),
                totals("REG"), totals("SUN"), totals("LH"), totals("SH"),
                totals("ND_REG"), totals("ND_SUN"), totals("ND_LH"), totals("ND_SH"),
                totals("OT_REG"), totals("OT_SUN"), totals("OT_LH"), totals("OT_SH"),
                0D, 0D, 0D)
        End If
        Dim allowanceTotal = adjustments.OfficerAllowance + adjustments.UniformAllowance + adjustments.OtherEarnings
        Dim grossPay = workEarnings + allowanceTotal
        Dim deductionTotal = adjustments.TotalDeductions(IsFirstCutoffSelected())
        Dim netPay = grossPay - deductionTotal

        lblWorkEarningsValue.Text = FormatPeso(workEarnings)
        lblAllowanceTotalValue.Text = FormatPeso(allowanceTotal)
        lblGrossPayValue.Text = FormatPeso(grossPay)
        lblDeductionTotalValue.Text = FormatPeso(deductionTotal)
        lblNetPayValue.Text = FormatPeso(netPay)
        lblNetPayValue.ForeColor = If(netPay < 0D, Color.Maroon, Color.Teal)

        If dailyWage <= 0D Then
            lblPreviewStatus.Text = "Daily wage is missing; payroll earnings cannot be calculated."
            lblPreviewStatus.ForeColor = Color.Maroon
        ElseIf netPay < 0D Then
            lblPreviewStatus.Text = "Review the deductions because estimated net pay is negative."
            lblPreviewStatus.ForeColor = Color.Maroon
        Else
            Dim fallbackNote = DescribePayCodeFallbacks()
            If fallbackNote <> String.Empty Then
                lblPreviewStatus.Text = fallbackNote
                lblPreviewStatus.ForeColor = WarningColor
            Else
                lblPreviewStatus.Text = "Live estimate; the generated payroll uses these saved values."
                lblPreviewStatus.ForeColor = Color.DimGray
            End If
        End If
    End Sub

    Private Function DescribePayCodeFallbacks() As String
        If payrollPolicy Is Nothing OrElse coveredDates.Count = 0 Then Return String.Empty
        Dim changes As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

        For Each d In coveredDates
            If SelectedShiftsForDate(d).Count = 0 Then Continue For
            Dim candidates = RequestedDayCodes(d)
            For Each prefix In {String.Empty, "ND_", "OT_"}
                Dim requestedCode = prefix & candidates(0)
                Dim resolvedCode = ResolvedPayCode(d, prefix)
                If Not String.Equals(requestedCode, resolvedCode, StringComparison.OrdinalIgnoreCase) Then
                    changes(requestedCode) = resolvedCode
                ElseIf Not payrollPolicy.GetRule(requestedCode).Enabled Then
                    changes(requestedCode) = String.Empty
                End If
            Next
        Next

        If changes.Count = 0 Then Return String.Empty
        Dim notes = changes.Take(3).Select(
            Function(change)
                Dim sourceName = payrollPolicy.GetRule(change.Key).DisplayName
                If change.Value = String.Empty Then Return sourceName & " is disabled and has no enabled fallback."
                Return sourceName & " is disabled; hours use " & payrollPolicy.GetRule(change.Value).DisplayName & "."
            End Function)
        Dim message = String.Join(" ", notes)
        If changes.Count > 3 Then message &= " Additional disabled categories also use their configured fallback."
        Return message
    End Function

    Private Function FormatPeso(value As Decimal) As String
        Return "PHP " & value.ToString("N2", CultureInfo.CurrentCulture)
    End Function

    Private Sub PeriodChanged(sender As Object, e As EventArgs)
        If isChangingPeriod Then Return
        If cmbYear Is Nothing OrElse cmbMonth Is Nothing OrElse cmbCutoff Is Nothing Then Return
        If cmbYear.SelectedIndex < 0 OrElse cmbMonth.SelectedIndex < 0 OrElse cmbCutoff.SelectedIndex < 0 Then Return

        If hasUnsavedChanges AndAlso lastLoadedCutoffIndex >= 0 Then
            Dim discard = AppNotification.Show(
                "This cutoff has unsaved changes. Discard them and open another cutoff?",
                "Unsaved Payroll Draft",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)
            If discard <> DialogResult.Yes Then
                isChangingPeriod = True
                Try
                    cmbYear.SelectedItem = lastLoadedYear
                    cmbMonth.SelectedItem = lastLoadedMonth
                    cmbCutoff.SelectedIndex = lastLoadedCutoffIndex
                Finally
                    isChangingPeriod = False
                End Try
                Return
            End If
        End If
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
        BuildHourAdjustmentGrid()
        BuildFillButtons()
        LoadSelectedCutoffRecord()
        ApplyModernVisualDesign()
        SynchronizeTimelineColumns()
    End Sub

    Private Sub LoadSelectedCutoffRecord()
        isApplyingRecord = True
        hasUnsavedChanges = False
        currentRecord = Nothing
        Try
            Dim subClientId As Integer
            If LicenseManager.UsageMode <> LicenseUsageMode.Designtime AndAlso
               Integer.TryParse(GlobalVariables.DTR_Selected_SubClient_ID, subClientId) AndAlso subClientId > 0 Then
                currentRecord = ManualPayrollRecordService.LoadLatest(
                    GlobalVariables.DTR_Selected_Employee_ID,
                    subClientId,
                    BuildCutoff())
            End If

            LoadPayrollInputs(currentRecord)
            If txtChangeRemarks IsNot Nothing Then
                txtChangeRemarks.Text = If(currentRecord Is Nothing, String.Empty, currentRecord.ChangeRemarks)
            End If

            If currentRecord Is Nothing Then
                SetAmendmentPanelVisible(False)
                UpdateRecordStateVisuals(ManualPayrollRecordService.StatusNotStarted, Nothing)
                SetRecordEditability(True)
                RecalculateTotals()
            ElseIf currentRecord.RecordStatus = ManualPayrollRecordService.StatusLegacyFinal Then
                SetAmendmentPanelVisible(False)
                ClearRecordGridSelections()
                UpdateDailyHoursDisplayFromRecord(currentRecord)
                RefreshPayrollPreview(TotalsFromRecord(currentRecord))
                UpdateRecordStateVisuals(ManualPayrollRecordService.StatusLegacyFinal, currentRecord)
                SetRecordEditability(False)
            Else
                SetAmendmentPanelVisible(currentRecord.RecordStatus = ManualPayrollRecordService.StatusAmendmentDraft)
                ApplyRecordToGrids(currentRecord)
                RecalculateTotals()
                UpdateRecordStateVisuals(currentRecord.RecordStatus, currentRecord)
                SetRecordEditability(currentRecord.RecordStatus = ManualPayrollRecordService.StatusDraft OrElse
                    currentRecord.RecordStatus = ManualPayrollRecordService.StatusAmendmentDraft)
            End If

            RefreshCutoffFileTabs()
            lastLoadedYear = cmbYear.Text
            lastLoadedMonth = cmbMonth.Text
            lastLoadedCutoffIndex = cmbCutoff.SelectedIndex
        Catch ex As Exception
            SetRecordLoadError(ex.Message)
        Finally
            isApplyingRecord = False
            hasUnsavedChanges = False
        End Try
    End Sub

    Private Sub ApplyRecordToGrids(record As ManualPayrollRecord)
        If record Is Nothing Then Return
        isUpdatingGrid = True
        Try
            ClearRecordGridSelections()
            For Each day In record.Days
                Dim columnName = DateColumnName(day.ReportDate.Date)
                If Not shiftGrid.Columns.Contains(columnName) Then Continue For

                For rowIndex As Integer = 0 To shifts.Count - 1
                    Dim shiftName = shifts(rowIndex).Name
                    shiftGrid.Rows(rowIndex).Cells(columnName).Value =
                        day.SelectedShiftNames.Any(Function(name) String.Equals(name, shiftName, StringComparison.OrdinalIgnoreCase))
                Next

                Dim columnIndex = holidayGrid.Columns(columnName).Index
                Dim classifications = If(day.Classification, String.Empty).
                    Split("+"c).
                    Select(Function(value) value.Trim().ToUpperInvariant()).
                    ToList()
                If classifications.Contains("SUN") AndAlso IsClassificationColumnSunday(columnIndex) Then
                    holidayGrid.Rows(0).Cells(columnName).Value = True
                End If
                If classifications.Contains("SH") Then holidayGrid.Rows(1).Cells(columnName).Value = True
                If classifications.Contains("LH") Then holidayGrid.Rows(2).Cells(columnName).Value = True
                If hourAdjustmentGrid.Rows.Count > 1 Then
                    hourAdjustmentGrid.Rows(1).Cells(columnName).Value = day.HourAdjustment.ToString("0.##", CultureInfo.CurrentCulture)
                End If
                ApplyHolidayExclusionState(columnIndex)
            Next
            RefreshHourAdjustmentDisplay()
        Finally
            isUpdatingGrid = False
        End Try
    End Sub

    Private Sub ClearRecordGridSelections()
        Dim previousUpdating = isUpdatingGrid
        isUpdatingGrid = True
        Try
            For Each row As DataGridViewRow In shiftGrid.Rows
                For Each d In coveredDates
                    row.Cells(DateColumnName(d)).Value = False
                Next
            Next
            If holidayGrid.Rows.Count >= 3 Then
                For Each d In coveredDates
                    Dim columnName = DateColumnName(d)
                    For rowIndex As Integer = 0 To 2
                        holidayGrid.Rows(rowIndex).Cells(columnName).Value = False
                    Next
                    ApplyHolidayExclusionState(holidayGrid.Columns(columnName).Index)
                Next
            End If
            If hourAdjustmentGrid IsNot Nothing AndAlso hourAdjustmentGrid.Rows.Count > 1 Then
                For Each d In coveredDates
                    hourAdjustmentGrid.Rows(1).Cells(DateColumnName(d)).Value = "0"
                Next
                RefreshHourAdjustmentDisplay()
            End If
        Finally
            isUpdatingGrid = previousUpdating
        End Try
    End Sub

    Private Sub UpdateDailyHoursDisplayFromRecord(record As ManualPayrollRecord)
        If dailyHoursGrid.Rows.Count = 0 Then Return
        Dim totals = TotalsFromRecord(record)
        Dim keys = {
            "TOTAL_HOURS", "REG", "SUN", "LH", "SH",
            "ND_REG", "ND_SUN", "ND_LH", "ND_SH",
            "OT_REG", "OT_SUN", "OT_LH", "OT_SH"
        }
        For rowIndex As Integer = 0 To keys.Length - 1
            dailyHoursGrid.Rows(rowIndex).Cells("Total").Value = FormatBreakdownValue(totals(keys(rowIndex)))
            For Each d In coveredDates
                dailyHoursGrid.Rows(rowIndex).Cells(DateColumnName(d)).Value = Nothing
            Next
        Next
        lblActualReportingDays.Text = record.NumberOfDays.ToString("0.##")
        lblNightDifferentialDays.Text = record.NightDifferentialDays.ToString("0.##")
    End Sub

    Private Function TotalsFromRecord(record As ManualPayrollRecord) As Dictionary(Of String, Decimal)
        Return New Dictionary(Of String, Decimal) From {
            {"NUM_DAYS", record.NumberOfDays},
            {"TOTAL_HOURS", record.TotalHours},
            {"REG", record.RegularHours},
            {"SUN", record.SundayHours},
            {"SH", record.SpecialHolidayHours},
            {"LH", record.LegalHolidayHours},
            {"ND_DAYS", record.NightDifferentialDays},
            {"ND_REG", record.NightDifferentialRegularHours},
            {"ND_SUN", record.NightDifferentialSundayHours},
            {"ND_SH", record.NightDifferentialSpecialHolidayHours},
            {"ND_LH", record.NightDifferentialLegalHolidayHours},
            {"OT_REG", record.OvertimeRegularHours},
            {"OT_SUN", record.OvertimeSundayHours},
            {"OT_SH", record.OvertimeSpecialHolidayHours},
            {"OT_LH", record.OvertimeLegalHolidayHours}
        }
    End Function

    Private Sub RefreshCutoffFileTabs()
        If btnFirstCutoffFile Is Nothing OrElse btnSecondCutoffFile Is Nothing Then Return
        Dim subClientId As Integer
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime OrElse
           Not Integer.TryParse(GlobalVariables.DTR_Selected_SubClient_ID, subClientId) OrElse subClientId <= 0 Then
            ApplyCutoffFileStatus(btnFirstCutoffFile, 0, New ManualPayrollRecordStatus With {.RecordStatus = ManualPayrollRecordService.StatusNotStarted})
            ApplyCutoffFileStatus(btnSecondCutoffFile, 1, New ManualPayrollRecordStatus With {.RecordStatus = ManualPayrollRecordService.StatusNotStarted})
            Return
        End If

        Dim firstStatus = ManualPayrollRecordService.LoadStatus(GlobalVariables.DTR_Selected_Employee_ID, subClientId, BuildCutoffForIndex(0))
        Dim secondStatus = ManualPayrollRecordService.LoadStatus(GlobalVariables.DTR_Selected_Employee_ID, subClientId, BuildCutoffForIndex(1))
        ApplyCutoffFileStatus(btnFirstCutoffFile, 0, firstStatus)
        ApplyCutoffFileStatus(btnSecondCutoffFile, 1, secondStatus)
    End Sub

    Private Function BuildCutoffForIndex(cutoffIndex As Integer) As String
        Dim monthValue = DateTime.ParseExact(cmbMonth.Text.Trim().ToUpperInvariant(), "MMM", CultureInfo.InvariantCulture).Month
        Return monthValue & "_" & If(cutoffIndex = 0, "1st", "2nd") & "_" & cmbYear.Text
    End Function

    Private Sub ApplyCutoffFileStatus(button As Button, cutoffIndex As Integer, status As ManualPayrollRecordStatus)
        Dim statusCode = If(status Is Nothing, ManualPayrollRecordService.StatusNotStarted, status.RecordStatus)
        Dim statusText As String
        Dim backColor As Color
        Dim foreColor As Color
        Select Case statusCode
            Case ManualPayrollRecordService.StatusDraft
                statusText = "DRAFT"
                backColor = Color.FromArgb(255, 215, 144)
                foreColor = Color.Maroon
            Case ManualPayrollRecordService.StatusAmendmentDraft
                statusText = "AMENDMENT"
                backColor = Color.FromArgb(255, 232, 184)
                foreColor = Color.FromArgb(133, 75, 13)
            Case ManualPayrollRecordService.StatusFinal
                statusText = "FINAL"
                backColor = Color.FromArgb(213, 238, 229)
                foreColor = PrimaryDarkColor
            Case ManualPayrollRecordService.StatusLegacyFinal
                statusText = "LEGACY FINAL"
                backColor = Color.FromArgb(224, 224, 224)
                foreColor = Color.FromArgb(75, 75, 75)
            Case Else
                statusText = "NOT STARTED"
                backColor = Color.FromArgb(239, 242, 244)
                foreColor = MutedTextColor
        End Select

        button.Text = If(cutoffIndex = 0, "1ST  ", "2ND  ") & statusText
        button.BackColor = backColor
        button.ForeColor = foreColor
        button.FlatAppearance.BorderColor = If(cmbCutoff.SelectedIndex = cutoffIndex, PrimaryColor, BorderColor)
        button.FlatAppearance.BorderSize = If(cmbCutoff.SelectedIndex = cutoffIndex, 3, 1)
        cutoffStatusToolTip.SetToolTip(button,
            If(statusText = "NOT STARTED",
               "No record exists for this employee and cutoff.",
               statusText & If(status IsNot Nothing AndAlso status.SavedAt.HasValue,
                   " | Last saved " & status.SavedAt.Value.ToString("g", CultureInfo.CurrentCulture), String.Empty)))
    End Sub

    Private Sub UpdateRecordStateVisuals(status As String, record As ManualPayrollRecord)
        Select Case status
            Case ManualPayrollRecordService.StatusDraft
                lblRecordStatus.Text = "DRAFT - INCOMPLETE"
                lblRecordStatus.BackColor = Color.FromArgb(255, 215, 144)
                lblRecordStatus.ForeColor = Color.Maroon
                lblRecordMetadata.Text = "Saved " & FormatAudit(record.SavedAt, record.SavedBy) & ". Continue editing or submit final."
            Case ManualPayrollRecordService.StatusAmendmentDraft
                lblRecordStatus.Text = "AMENDMENT DRAFT · REV " & record.RevisionNo.ToString(CultureInfo.CurrentCulture)
                lblRecordStatus.BackColor = Color.FromArgb(255, 232, 184)
                lblRecordStatus.ForeColor = Color.FromArgb(133, 75, 13)
                lblRecordMetadata.Text = "Original final remains active. Saved " & FormatAudit(record.SavedAt, record.SavedBy) & "."
            Case ManualPayrollRecordService.StatusFinal
                lblRecordStatus.Text = "SUBMITTED FINAL · REV " & record.RevisionNo.ToString(CultureInfo.CurrentCulture)
                lblRecordStatus.BackColor = Color.FromArgb(213, 238, 229)
                lblRecordStatus.ForeColor = PrimaryDarkColor
                lblRecordMetadata.Text = "Completed " & FormatAudit(record.SubmittedAt, record.SubmittedBy) & ". Use Amend Final for controlled changes."
            Case ManualPayrollRecordService.StatusLegacyFinal
                lblRecordStatus.Text = "LEGACY FINAL"
                lblRecordStatus.BackColor = Color.FromArgb(224, 224, 224)
                lblRecordStatus.ForeColor = Color.FromArgb(75, 75, 75)
                lblRecordMetadata.Text = "Existing summary-only payroll record. Exact shift selections are unavailable, so it is locked."
            Case Else
                lblRecordStatus.Text = "NOT STARTED"
                lblRecordStatus.BackColor = Color.FromArgb(231, 223, 204)
                lblRecordStatus.ForeColor = Color.FromArgb(94, 82, 65)
                lblRecordMetadata.Text = "No saved record exists. Save a draft to keep work for this cutoff."
        End Select
    End Sub

    Private Function FormatAudit(timestamp As Nullable(Of Date), actor As String) As String
        Dim timeText = If(timestamp.HasValue, timestamp.Value.ToString("g", CultureInfo.CurrentCulture), "at an unknown time")
        Dim actorText = If(String.IsNullOrWhiteSpace(actor), "unknown user", actor.Trim())
        Return timeText & " by " & actorText
    End Function

    Private Sub SetRecordEditability(editable As Boolean)
        isRecordReadOnly = Not editable
        fillPanel.Enabled = editable
        If hourAdjustmentGrid IsNot Nothing AndAlso hourAdjustmentGrid.Rows.Count > 1 Then
            For Each d As Date In coveredDates
                Dim cell = hourAdjustmentGrid.Rows(1).Cells(DateColumnName(d))
                cell.ReadOnly = Not editable
                cell.Style.BackColor = If(editable, Color.FromArgb(255, 252, 240), Color.FromArgb(239, 242, 244))
            Next
        End If
        For Each inputControl In payrollInputRows.Keys
            inputControl.ReadOnly = Not editable
            inputControl.BackColor = If(editable, Color.White, Color.FromArgb(239, 242, 244))
            inputControl.TabStop = editable
        Next
        If txtChangeRemarks IsNot Nothing Then
            txtChangeRemarks.ReadOnly = Not editable
            txtChangeRemarks.BackColor = If(editable, Color.White, Color.FromArgb(239, 242, 244))
            txtChangeRemarks.TabStop = editable
        End If
        UpdateActionButtons(editable)
    End Sub

    Private Sub UpdateActionButtons(editable As Boolean)
        Dim status = If(currentRecord Is Nothing, ManualPayrollRecordService.StatusNotStarted, currentRecord.RecordStatus)
        Select Case status
            Case ManualPayrollRecordService.StatusFinal
                btnSave.Text = "Amend Final"
                btnSave.Enabled = True
                btnSave.BackColor = WarningColor
                btnSave.ForeColor = Color.White
                btnSubmitFinal.Text = "Final Submitted"
                btnSubmitFinal.Enabled = False
            Case ManualPayrollRecordService.StatusAmendmentDraft
                btnSave.Text = "Save Amendment"
                btnSave.Enabled = editable
                btnSave.BackColor = WarningColor
                btnSave.ForeColor = Color.White
                btnSubmitFinal.Text = "Submit Amended Final"
                btnSubmitFinal.Enabled = editable
            Case ManualPayrollRecordService.StatusLegacyFinal
                btnSave.Text = "Legacy Record"
                btnSave.Enabled = False
                btnSubmitFinal.Text = "Final Submitted"
                btnSubmitFinal.Enabled = False
            Case Else
                btnSave.Text = "Save Draft"
                btnSave.Enabled = editable
                btnSave.BackColor = WarningColor
                btnSave.ForeColor = Color.White
                btnSubmitFinal.Text = "Submit Final"
                btnSubmitFinal.Enabled = editable
        End Select
    End Sub

    Private Sub SetRecordLoadError(message As String)
        isRecordReadOnly = True
        lblRecordStatus.Text = "LOAD ERROR"
        lblRecordStatus.BackColor = Color.MistyRose
        lblRecordStatus.ForeColor = Color.Maroon
        lblRecordMetadata.Text = "The cutoff record could not be loaded. Editing is disabled to protect existing data."
        SetRecordEditability(False)
        btnSave.Enabled = False
        If btnSubmitFinal IsNot Nothing Then btnSubmitFinal.Enabled = False
        AppNotification.Show(message, "Unable to Load Payroll Cutoff", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub MarkRecordDirty()
        If isApplyingRecord OrElse isLoadingPayrollInputs OrElse isUpdatingGrid OrElse isRecordReadOnly Then Return
        hasUnsavedChanges = True
        Dim isAmendment = currentRecord IsNot Nothing AndAlso
            currentRecord.RecordStatus = ManualPayrollRecordService.StatusAmendmentDraft
        lblRecordStatus.Text = If(isAmendment, "UNSAVED AMENDMENT", "UNSAVED CHANGES")
        lblRecordStatus.BackColor = Color.FromArgb(255, 235, 174)
        lblRecordStatus.ForeColor = Color.Maroon
        lblRecordMetadata.Text = If(isAmendment,
            "Changes exist only on this screen. Remarks are required before saving or submitting.",
            "Changes exist only on this screen. Choose Save Draft or Submit Final.")
    End Sub

    Private Sub ManualPayrollFormClosing(sender As Object, e As FormClosingEventArgs)
        If Not hasUnsavedChanges Then Return
        Dim discard = AppNotification.Show(
            "This cutoff has unsaved changes. Close without saving them?",
            "Unsaved Payroll Draft",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If discard <> DialogResult.Yes Then e.Cancel = True
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

        shiftGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ShiftName", .HeaderText = "Shift", .ReadOnly = True, .Frozen = True, .Width = ShiftNameColumnWidth})
        shiftGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Coverage", .HeaderText = "Coverage", .ReadOnly = True, .Frozen = True, .Width = ShiftCoverageColumnWidth})

        For Each d As Date In coveredDates
            shiftGrid.Columns.Add(New DataGridViewCheckBoxColumn With {
                .Name = DateColumnName(d),
                .HeaderText = TimelineHeaderText(d),
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

        ApplyFullGridLayout(shiftGrid, ShiftNameColumnWidth, ShiftCoverageColumnWidth)
        isUpdatingGrid = False
    End Sub

    Private Sub BuildHolidayGrid()
        isUpdatingGrid = True
        holidayGrid.Columns.Clear()
        holidayGrid.Rows.Clear()
        holidayGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Label", .HeaderText = "Classification", .ReadOnly = True, .Frozen = True, .Width = TimelineStubWidth})

        For Each d As Date In coveredDates
            holidayGrid.Columns.Add(New DataGridViewCheckBoxColumn With {
                .Name = DateColumnName(d),
                .HeaderText = TimelineHeaderText(d),
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
                sundayCell.ToolTipText = "Sunday may be combined with SH or LH. The configured Sunday + holiday premium is applied without duplicating worked hours."
            End If

            holidayGrid.Rows(shRowIndex).Cells(columnName).Value = False
            holidayGrid.Rows(lhRowIndex).Cells(columnName).Value = False
            holidayGrid.Rows(shRowIndex).Cells(columnName).ToolTipText = "Special Holiday may be combined with Sunday and uses the Sunday + SH premium. SH and LH cannot both be selected."
            holidayGrid.Rows(lhRowIndex).Cells(columnName).ToolTipText = "Legal Holiday may be combined with Sunday and uses the Sunday + LH premium. LH and SH cannot both be selected."
            ApplyHolidayExclusionState(holidayGrid.Columns(columnName).Index)
        Next

        ApplyFullGridLayout(holidayGrid, TimelineStubWidth)
        isUpdatingGrid = False
    End Sub

    Private Sub BuildHourAdjustmentGrid()
        isUpdatingGrid = True
        Try
            hourAdjustmentGrid.Columns.Clear()
            hourAdjustmentGrid.Rows.Clear()
            hourAdjustmentGrid.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "Label",
                .HeaderText = "Daily hours adjustment",
                .ReadOnly = True,
                .Frozen = True,
                .Width = TimelineStubWidth
            })
            For Each d As Date In coveredDates
                hourAdjustmentGrid.Columns.Add(New DataGridViewTextBoxColumn With {
                    .Name = DateColumnName(d),
                    .HeaderText = TimelineHeaderText(d),
                    .Width = 74
                })
            Next

            Dim statusRow = hourAdjustmentGrid.Rows.Add()
            Dim adjustmentRow = hourAdjustmentGrid.Rows.Add()
            Dim resultRow = hourAdjustmentGrid.Rows.Add()
            hourAdjustmentGrid.Rows(statusRow).Cells("Label").Value = "Treatment"
            hourAdjustmentGrid.Rows(adjustmentRow).Cells("Label").Value = "Adjustment (+/- hrs)"
            hourAdjustmentGrid.Rows(resultRow).Cells("Label").Value = "Resulting hours"
            hourAdjustmentGrid.Rows(statusRow).DefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.0!, FontStyle.Bold)
            hourAdjustmentGrid.Rows(resultRow).DefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)

            For Each d As Date In coveredDates
                Dim columnName = DateColumnName(d)
                hourAdjustmentGrid.Rows(statusRow).Cells(columnName).ReadOnly = True
                hourAdjustmentGrid.Rows(statusRow).Cells(columnName).Value = "NO EXT"
                hourAdjustmentGrid.Rows(statusRow).Cells(columnName).ToolTipText = "Not extended; scheduled hours are unchanged."
                hourAdjustmentGrid.Rows(adjustmentRow).Cells(columnName).Value = "0"
                hourAdjustmentGrid.Rows(adjustmentRow).Cells(columnName).Style.BackColor = Color.FromArgb(255, 252, 240)
                hourAdjustmentGrid.Rows(adjustmentRow).Cells(columnName).ToolTipText =
                    "Enter positive hours to extend or negative hours to subtract. Example: 2 or -1.5."
                hourAdjustmentGrid.Rows(resultRow).Cells(columnName).ReadOnly = True
            Next
            hourAdjustmentGrid.ColumnHeadersHeight = 46
            hourAdjustmentGrid.RowTemplate.Height = 28
            ApplyFullGridLayout(hourAdjustmentGrid, TimelineStubWidth)
            RefreshHourAdjustmentDisplay()
        Finally
            isUpdatingGrid = False
        End Try
    End Sub

    Private Sub BuildDailyHoursGrid()
        dailyHoursGrid.Columns.Clear()
        dailyHoursGrid.Rows.Clear()
        dailyHoursGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Label", .HeaderText = "Hours Breakdown", .ReadOnly = True, .Frozen = True, .Width = BreakdownLabelColumnWidth})
        dailyHoursGrid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Total", .HeaderText = "Total", .ReadOnly = True, .Frozen = True, .Width = BreakdownTotalColumnWidth})

        For Each d As Date In coveredDates
            dailyHoursGrid.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = DateColumnName(d),
                .HeaderText = TimelineHeaderText(d),
                .ReadOnly = True,
                .Width = 74
            })
        Next

        For rowIndex As Integer = 0 To DailyBreakdownLabels.Length - 1
            Dim gridRowIndex = dailyHoursGrid.Rows.Add()
            Dim row = dailyHoursGrid.Rows(gridRowIndex)
            row.Cells("Label").Value = DailyBreakdownLabels(rowIndex)
            If IsCombinedBreakdownCode(DailyBreakdownKeys(rowIndex)) Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(235, 248, 248)
                row.DefaultCellStyle.ForeColor = PrimaryDarkColor
                row.DefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
                For Each cell As DataGridViewCell In row.Cells
                    cell.ToolTipText = "Combined Sunday and holiday hours are shown once here. Payroll export remains mapped to the corresponding SH or LH bucket."
                Next
            End If
        Next

        ApplyFullGridLayout(dailyHoursGrid, BreakdownLabelColumnWidth, BreakdownTotalColumnWidth)
    End Sub

    Private Function TimelineHeaderText(d As Date) As String
        Return d.ToString("MMM d", CultureInfo.InvariantCulture) & vbCrLf &
            d.ToString("ddd", CultureInfo.InvariantCulture)
    End Function

    Private Function TimelineGrids() As DataGridView()
        Return {shiftGrid, holidayGrid, hourAdjustmentGrid, dailyHoursGrid}
    End Function

    Private Sub TimelineWorkspaceResize(sender As Object, e As EventArgs)
        SynchronizeTimelineColumns()
    End Sub

    Private Sub SynchronizeTimelineColumns()
        If coveredDates.Count = 0 Then Return

        Dim grids = TimelineGrids().Where(Function(grid) grid IsNot Nothing AndAlso grid.ClientSize.Width > 0).ToArray()
        If grids.Length = 0 OrElse grids.Any(Function(grid) grid.Columns.Count = 0) Then Return

        ' Reserve the scrollbar gutter for every grid. The breakdown grid normally
        ' owns the vertical scrollbar, so using its gutter across the workspace
        ' keeps every date boundary on the same x-coordinate.
        Dim commonClientWidth = grids.Min(Function(grid) grid.ClientSize.Width)
        Dim availableTimelineWidth = Math.Max(
            coveredDates.Count * MinimumTimelineDateWidth,
            commonClientWidth - TimelineStubWidth - SystemInformation.VerticalScrollBarWidth - 6)
        Dim baseDateWidth = Math.Max(MinimumTimelineDateWidth, availableTimelineWidth \ coveredDates.Count)
        Dim remainder = Math.Max(0, availableTimelineWidth - (baseDateWidth * coveredDates.Count))

        For Each grid In grids
            If grid Is shiftGrid Then
                grid.Columns("ShiftName").Width = ShiftNameColumnWidth
                grid.Columns("Coverage").Width = ShiftCoverageColumnWidth
            ElseIf grid Is dailyHoursGrid Then
                grid.Columns("Label").Width = BreakdownLabelColumnWidth
                grid.Columns("Total").Width = BreakdownTotalColumnWidth
            Else
                grid.Columns("Label").Width = TimelineStubWidth
            End If

            For dateIndex As Integer = 0 To coveredDates.Count - 1
                Dim column = grid.Columns(DateColumnName(coveredDates(dateIndex)))
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                column.MinimumWidth = MinimumTimelineDateWidth
                column.Width = baseDateWidth + If(dateIndex < remainder, 1, 0)
            Next
        Next
    End Sub

    Private Sub TimelineGridScrolled(sender As Object, e As ScrollEventArgs)
        If e.ScrollOrientation <> ScrollOrientation.HorizontalScroll OrElse isSynchronizingTimelineScroll Then Return

        Dim source = TryCast(sender, DataGridView)
        If source Is Nothing Then Return

        isSynchronizingTimelineScroll = True
        Try
            For Each grid In TimelineGrids()
                If grid Is Nothing OrElse grid Is source OrElse grid.Columns.Count = 0 Then Continue For
                grid.HorizontalScrollingOffset = source.HorizontalScrollingOffset
            Next
        Finally
            isSynchronizingTimelineScroll = False
        End Try
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

        Dim borderColor = If(checked, PrimaryColor, Color.FromArgb(110, 120, 126))
        Dim fillColor = If(checked, PrimaryColor, Color.White)

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
                .BackColor = PrimaryColor,
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
        clearButton.FlatAppearance.BorderColor = BorderColor
        clearButton.FlatAppearance.BorderSize = 1
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
            .Font = New Font("Segoe UI Semibold", 8.5!, FontStyle.Bold),
            .ForeColor = PrimaryDarkColor,
            .BackColor = CanvasColor
        }
    End Function

    Private Sub FillAllShift(shiftIndex As Integer)
        If isRecordReadOnly Then Return
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
        MarkRecordDirty()
    End Sub

    Private Sub ClearAllEntries()
        If isRecordReadOnly Then Return
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
            If hourAdjustmentGrid.Rows.Count > 1 Then hourAdjustmentGrid.Rows(1).Cells(columnName).Value = "0"
            ApplyHolidayExclusionState(holidayGrid.Columns(columnName).Index)
        Next
        isUpdatingGrid = False
        RecalculateTotals()
        MarkRecordDirty()
    End Sub

    Private Sub GridCurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        Dim grid = TryCast(sender, DataGridView)
        If grid IsNot Nothing AndAlso grid.IsCurrentCellDirty Then
            grid.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub ShiftGridCellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If isUpdatingGrid OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 2 Then Return
        If isRecordReadOnly Then Return

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
        MarkRecordDirty()
    End Sub

    Private Sub ShiftGridCellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 2 Then Return
        If isRecordReadOnly Then Return

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
        MarkRecordDirty()
    End Sub

    Private Sub AnyGridCellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If isUpdatingGrid OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 1 Then Return
        RecalculateTotals()
    End Sub

    Private Sub HourAdjustmentEditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        Dim input = TryCast(e.Control, TextBox)
        If input Is Nothing Then Return
        RemoveHandler input.KeyPress, AddressOf HourAdjustmentKeyPress
        AddHandler input.KeyPress, AddressOf HourAdjustmentKeyPress
    End Sub

    Private Sub HourAdjustmentKeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "-"c OrElse
           e.KeyChar = "."c OrElse e.KeyChar = ","c Then Return
        e.Handled = True
    End Sub

    Private Sub HourAdjustmentCellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
        If isUpdatingGrid OrElse e.RowIndex <> 1 OrElse e.ColumnIndex < 1 Then Return
        Dim value As Decimal
        If Not TryParseHourAdjustment(Convert.ToString(e.FormattedValue), value) OrElse Math.Abs(value) > 24D Then
            e.Cancel = True
            hourAdjustmentGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "Enter a number from -24 to 24."
            Return
        End If
        hourAdjustmentGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = String.Empty
    End Sub

    Private Sub HourAdjustmentCellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        If isUpdatingGrid OrElse isRecordReadOnly OrElse e.RowIndex <> 1 OrElse e.ColumnIndex < 1 Then Return
        RefreshHourAdjustmentDisplay()
        RecalculateTotals()
        MarkRecordDirty()
    End Sub

    Private Function TryParseHourAdjustment(text As String, ByRef value As Decimal) As Boolean
        text = If(text, String.Empty).Trim()
        If text = String.Empty Then
            value = 0D
            Return True
        End If
        If Decimal.TryParse(text, NumberStyles.Number Or NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, value) Then Return True
        Return Decimal.TryParse(text, NumberStyles.Number Or NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, value)
    End Function

    Private Function HourAdjustmentForDate(d As Date) As Decimal
        If hourAdjustmentGrid Is Nothing OrElse hourAdjustmentGrid.Rows.Count < 2 Then Return 0D
        Dim value As Decimal
        TryParseHourAdjustment(Convert.ToString(hourAdjustmentGrid.Rows(1).Cells(DateColumnName(d)).Value), value)
        Return value
    End Function

    Private Sub RefreshHourAdjustmentDisplay()
        If hourAdjustmentGrid Is Nothing OrElse hourAdjustmentGrid.Rows.Count < 3 Then Return
        Dim previousUpdating = isUpdatingGrid
        isUpdatingGrid = True
        Try
            For Each d As Date In coveredDates
                Dim columnName = DateColumnName(d)
                Dim scheduled = SelectedShiftsForDate(d).Sum(Function(shift) shift.TotalHours)
                Dim adjustment = HourAdjustmentForDate(d)
                Dim resulting = scheduled + adjustment
                Dim statusCell = hourAdjustmentGrid.Rows(0).Cells(columnName)
                Dim resultCell = hourAdjustmentGrid.Rows(2).Cells(columnName)

                If adjustment > 0D Then
                    statusCell.Value = "EXTENDED"
                    statusCell.ToolTipText = "Extended hours are added to overtime."
                    statusCell.Style.BackColor = Color.FromArgb(255, 232, 184)
                    statusCell.Style.ForeColor = Color.FromArgb(133, 75, 13)
                ElseIf adjustment < 0D Then
                    statusCell.Value = "SUBTRACT"
                    statusCell.ToolTipText = "Subtracted hours reduce overtime first, then regular hours."
                    statusCell.Style.BackColor = Color.FromArgb(252, 226, 226)
                    statusCell.Style.ForeColor = Color.Maroon
                Else
                    statusCell.Value = "NO EXT"
                    statusCell.ToolTipText = "Not extended; scheduled hours are unchanged."
                    statusCell.Style.BackColor = Color.FromArgb(239, 242, 244)
                    statusCell.Style.ForeColor = MutedTextColor
                End If

                If adjustment <> 0D AndAlso scheduled <= 0D Then
                    statusCell.Value = "Needs shift"
                    statusCell.Style.BackColor = Color.MistyRose
                    statusCell.Style.ForeColor = Color.Maroon
                End If
                resultCell.Value = If(scheduled <= 0D AndAlso adjustment = 0D, String.Empty,
                    Math.Max(0D, resulting).ToString("0.##", CultureInfo.CurrentCulture))
                resultCell.Style.BackColor = Color.FromArgb(232, 246, 242)
                resultCell.Style.ForeColor = PrimaryDarkColor
            Next
        Finally
            isUpdatingGrid = previousUpdating
        End Try
    End Sub

    Private Function ValidateHourAdjustments(showMessage As Boolean) As Boolean
        If hourAdjustmentGrid IsNot Nothing Then hourAdjustmentGrid.EndEdit()
        For Each d As Date In coveredDates
            Dim cell = hourAdjustmentGrid.Rows(1).Cells(DateColumnName(d))
            Dim adjustment As Decimal
            If Not TryParseHourAdjustment(Convert.ToString(cell.Value), adjustment) OrElse Math.Abs(adjustment) > 24D Then
                If showMessage Then AppNotification.Show("Enter a valid adjustment from -24 to 24 for " & d.ToString("MMM d, yyyy") & ".", "Invalid Daily Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cell.Selected = True
                Return False
            End If

            Dim scheduled = SelectedShiftsForDate(d).Sum(Function(shift) shift.TotalHours)
            If adjustment <> 0D AndAlso scheduled <= 0D Then
                If showMessage Then AppNotification.Show("Select a shift before adjusting hours for " & d.ToString("MMM d, yyyy") & ".", "Shift Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cell.Selected = True
                Return False
            End If
            Dim resulting = scheduled + adjustment
            If scheduled > 0D AndAlso resulting <= 0D Then
                If showMessage Then AppNotification.Show("The resulting hours for " & d.ToString("MMM d, yyyy") & " must be greater than zero. Clear the shift instead when no work was rendered.", "Invalid Daily Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cell.Selected = True
                Return False
            End If
            If resulting > 24D Then
                If showMessage Then AppNotification.Show("The resulting hours for " & d.ToString("MMM d, yyyy") & " cannot exceed 24 hours.", "Invalid Daily Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cell.Selected = True
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub HolidayGridCellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 1 Then Return
        If isRecordReadOnly Then Return

        Dim cell = holidayGrid.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If cell.ReadOnly AndAlso e.RowIndex = 0 AndAlso Not IsClassificationColumnSunday(e.ColumnIndex) Then Return

        Dim currentValue As Boolean = IsCellChecked(cell)

        If e.RowIndex = 0 Then
            If Not IsClassificationColumnSunday(e.ColumnIndex) Then Return
            cell.Value = Not currentValue
            ApplyHolidayExclusionState(e.ColumnIndex)
        ElseIf e.RowIndex = 1 Then
            cell.Value = Not currentValue
            If CBool(cell.Value) Then holidayGrid.Rows(2).Cells(e.ColumnIndex).Value = False
        ElseIf e.RowIndex = 2 Then
            cell.Value = Not currentValue
            If CBool(cell.Value) Then holidayGrid.Rows(1).Cells(e.ColumnIndex).Value = False
        End If

        RecalculateTotals()
        MarkRecordDirty()
    End Sub

    Private Sub ApplyHolidayExclusionState(columnIndex As Integer)
        If holidayGrid.Rows.Count < 3 OrElse columnIndex < 1 Then Return

        For rowIndex As Integer = 1 To 2
            Dim cell = holidayGrid.Rows(rowIndex).Cells(columnIndex)
            cell.ReadOnly = False
            cell.Style.BackColor = Color.White
            cell.Style.SelectionBackColor = holidayGrid.DefaultCellStyle.SelectionBackColor
            cell.Style.ForeColor = Color.Black
            cell.ToolTipText = If(rowIndex = 1,
                "Special Holiday may be combined with Sunday and uses the Sunday + SH premium. SH and LH cannot both be selected.",
                "Legal Holiday may be combined with Sunday and uses the Sunday + LH premium. LH and SH cannot both be selected.")
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

    Private Function AllocateHoursForDate(d As Date, selectedShifts As List(Of ShiftDefinition)) As DayHourAllocation
        Dim allocation As New DayHourAllocation()
        If selectedShifts Is Nothing OrElse selectedShifts.Count = 0 Then Return allocation

        allocation.ScheduledHours = selectedShifts.Sum(Function(shift) shift.TotalHours)
        allocation.AdjustmentHours = HourAdjustmentForDate(d)
        allocation.RegularHours = RegularHoursForSelections(selectedShifts)
        allocation.OvertimeHours = OvertimeHoursForSelections(selectedShifts)
        allocation.NightHours = selectedShifts.Where(Function(shift) shift.IsNightShift).
            Sum(Function(shift) If(IsTriShiftSchedule(), shift.TotalHours, shift.RegularHours))

        If allocation.AdjustmentHours > 0D Then
            allocation.OvertimeHours += allocation.AdjustmentHours
        ElseIf allocation.AdjustmentHours < 0D Then
            Dim reduction = -allocation.AdjustmentHours
            Dim overtimeReduction = Math.Min(allocation.OvertimeHours, reduction)
            allocation.OvertimeHours -= overtimeReduction
            reduction -= overtimeReduction

            If reduction > 0D Then
                Dim originalRegular = allocation.RegularHours
                allocation.RegularHours = Math.Max(0D, allocation.RegularHours - reduction)
                If originalRegular > 0D Then
                    allocation.NightHours *= allocation.RegularHours / originalRegular
                Else
                    allocation.NightHours = 0D
                End If
            End If
        End If

        allocation.TotalHours = allocation.RegularHours + allocation.OvertimeHours
        Return allocation
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

    Private Function RequestedDayCodes(d As Date) As String()
        Dim result As New List(Of String)()
        Dim holidayCode = HolidayForDate(d)
        If holidayCode <> String.Empty Then result.Add(holidayCode)
        If IsSundaySelected(d) Then result.Add("SUN")
        result.Add("REG")
        Return result.Distinct(StringComparer.OrdinalIgnoreCase).ToArray()
    End Function

    Private Function BuildPayrollDayEarningInputs() As List(Of PayrollDayEarningInput)
        Dim result As New List(Of PayrollDayEarningInput)()
        For Each d In coveredDates
            Dim selectedShifts = SelectedShiftsForDate(d)
            If selectedShifts.Count = 0 Then Continue For
            Dim allocation = AllocateHoursForDate(d, selectedShifts)
            result.Add(New PayrollDayEarningInput With {
                .DayCodes = RequestedDayCodes(d),
                .RegularHours = allocation.RegularHours,
                .NightHours = allocation.NightHours,
                .OvertimeHours = allocation.OvertimeHours
            })
        Next
        Return result
    End Function

    Private Function ResolvedPayCode(d As Date, prefix As String) As String
        If String.IsNullOrEmpty(prefix) Then
            Return SubClientPayrollPolicyService.ResolveEnabledDayPayCode(payrollPolicy, RequestedDayCodes(d))
        End If
        Return SubClientPayrollPolicyService.ResolveEnabledPayCode(payrollPolicy, prefix, RequestedDayCodes(d))
    End Function

    Private Function DisplayBreakdownPayCode(d As Date, prefix As String) As String
        Dim holidayCode = HolidayForDate(d)
        Dim resolvedCode = ResolvedPayCode(d, prefix)
        If payrollPolicy IsNot Nothing AndAlso IsSundaySelected(d) Then
            Dim combinedCode As String = Nothing
            If String.Equals(holidayCode, "SH", StringComparison.OrdinalIgnoreCase) Then
                combinedCode = "RD_SH"
            ElseIf String.Equals(holidayCode, "LH", StringComparison.OrdinalIgnoreCase) Then
                combinedCode = "RD_LH"
            End If

            If combinedCode IsNot Nothing AndAlso payrollPolicy.GetRule(combinedCode).Enabled Then
                If String.IsNullOrEmpty(prefix) Then Return combinedCode
                If String.Equals(resolvedCode, prefix & holidayCode, StringComparison.OrdinalIgnoreCase) Then
                    Return prefix & combinedCode
                End If
            End If
        End If
        Return resolvedCode
    End Function

    Private Shared Function IsCombinedBreakdownCode(code As String) As Boolean
        Return If(code, String.Empty).IndexOf("RD_", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Private Function CalculateCombinedClassificationTotals() As Dictionary(Of String, Decimal)
        Dim result As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase) From {
            {"RD_SH", 0D}, {"RD_LH", 0D},
            {"ND_RD_SH", 0D}, {"ND_RD_LH", 0D},
            {"OT_RD_SH", 0D}, {"OT_RD_LH", 0D}
        }
        For Each reportDate In coveredDates
            Dim selectedShifts = SelectedShiftsForDate(reportDate)
            If selectedShifts.Count = 0 Then Continue For
            Dim allocation = AllocateHoursForDate(reportDate, selectedShifts)
            Dim baseCode = DisplayBreakdownPayCode(reportDate, String.Empty)
            Dim ndCode = DisplayBreakdownPayCode(reportDate, "ND_")
            Dim otCode = DisplayBreakdownPayCode(reportDate, "OT_")
            If result.ContainsKey(baseCode) Then result(baseCode) += allocation.RegularHours
            If result.ContainsKey(ndCode) Then result(ndCode) += allocation.NightHours
            If result.ContainsKey(otCode) Then result(otCode) += allocation.OvertimeHours
        Next
        Return result
    End Function

    Private Function ClassificationForDate(d As Date) As String
        Dim result As New List(Of String)()
        If IsSundaySelected(d) Then result.Add("SUN")
        Dim holidayCode = HolidayForDate(d)
        If holidayCode <> String.Empty Then result.Add(holidayCode)
        Return String.Join("+", result)
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

            Dim allocation = AllocateHoursForDate(d, selectedShifts)
            Dim baseHours = If(payrollPolicy Is Nothing OrElse payrollPolicy.HoursPerDay <= 0D, 8D, payrollPolicy.HoursPerDay)
            ' Each selected shift is one reporting day. Multiple shifts selected
            ' on the same calendar date remain separate reporting days.
            totals("NUM_DAYS") += selectedShifts.Count
            totals("TOTAL_HOURS") += allocation.TotalHours
            totals("ND_DAYS") += allocation.NightHours / baseHours

            totals(ResolvedPayCode(d, String.Empty)) += allocation.RegularHours
            totals(ResolvedPayCode(d, "ND_")) += allocation.NightHours
            totals(ResolvedPayCode(d, "OT_")) += allocation.OvertimeHours
        Next

        Return totals
    End Function

    Private Function DailyTotals() As Dictionary(Of Date, Decimal)
        Dim daily As New Dictionary(Of Date, Decimal)
        For Each d As Date In coveredDates
            Dim selectedShifts = SelectedShiftsForDate(d)
            If selectedShifts.Count = 0 Then Continue For
            daily(d) = AllocateHoursForDate(d, selectedShifts).TotalHours
        Next
        Return daily
    End Function

    Private Sub RecalculateTotals()
        RefreshHourAdjustmentDisplay()
        Dim totals = CalculateTotals()
        UpdateDailyHoursDisplay(totals)
        lblActualReportingDays.Text = totals("NUM_DAYS").ToString("0.##")
        lblNightDifferentialDays.Text = totals("ND_DAYS").ToString("0.##")
        RefreshPayrollPreview()
    End Sub

    Private Sub UpdateDailyHoursDisplay(totals As Dictionary(Of String, Decimal))
        If dailyHoursGrid.Rows.Count = 0 Then Return

        Dim displayTotals As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)
        For Each key In DailyBreakdownKeys
            displayTotals(key) = 0D
        Next
        displayTotals("TOTAL_HOURS") = totals("TOTAL_HOURS")

        For Each d As Date In coveredDates
            Dim selectedShifts = SelectedShiftsForDate(d)
            Dim dailyValues As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)
            For Each key In DailyBreakdownKeys
                dailyValues(key) = 0D
            Next

            If selectedShifts.Count > 0 Then
                Dim allocation = AllocateHoursForDate(d, selectedShifts)
                dailyValues("TOTAL_HOURS") = allocation.TotalHours
                dailyValues(DisplayBreakdownPayCode(d, String.Empty)) = allocation.RegularHours
                dailyValues(DisplayBreakdownPayCode(d, "ND_")) = allocation.NightHours
                dailyValues(DisplayBreakdownPayCode(d, "OT_")) = allocation.OvertimeHours

                For Each key In DailyBreakdownKeys.Skip(1)
                    displayTotals(key) += dailyValues(key)
                Next
            End If

            Dim columnName = DateColumnName(d)
            For rowIndex As Integer = 0 To DailyBreakdownKeys.Length - 1
                dailyHoursGrid.Rows(rowIndex).Cells(columnName).Value = FormatBreakdownValue(dailyValues(DailyBreakdownKeys(rowIndex)))
            Next
        Next

        For rowIndex As Integer = 0 To DailyBreakdownKeys.Length - 1
            dailyHoursGrid.Rows(rowIndex).Cells("Total").Value = FormatBreakdownValue(displayTotals(DailyBreakdownKeys(rowIndex)))
        Next
    End Sub

    Private Function FormatBreakdownValue(value As Decimal) As String
        If value = 0D Then Return ""
        Return value.ToString("0.##")
    End Function

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        If currentRecord IsNot Nothing AndAlso currentRecord.RecordStatus = ManualPayrollRecordService.StatusFinal Then
            BeginFinalAmendment()
            Return
        End If
        SavePayrollRecord(False)
    End Sub

    Private Sub BtnSubmitFinal_Click(sender As Object, e As EventArgs)
        SavePayrollRecord(True)
    End Sub

    Private Sub BeginFinalAmendment()
        If currentRecord Is Nothing OrElse currentRecord.RecordStatus <> ManualPayrollRecordService.StatusFinal Then Return
        Dim remarks As String = Nothing
        If Not TryRequestAmendmentRemarks(remarks) Then Return

        Try
            currentRecord = ManualPayrollRecordService.BeginAmendment(currentRecord, remarks, CurrentActor())
            isApplyingRecord = True
            Try
                txtChangeRemarks.Text = currentRecord.ChangeRemarks
                SetAmendmentPanelVisible(True)
                UpdateRecordStateVisuals(currentRecord.RecordStatus, currentRecord)
                SetRecordEditability(True)
                RefreshCutoffFileTabs()
                hasUnsavedChanges = False
            Finally
                isApplyingRecord = False
            End Try
            txtChangeRemarks.Focus()
            txtChangeRemarks.SelectionStart = txtChangeRemarks.TextLength
            AppNotification.Show(
                "Amendment revision " & currentRecord.RevisionNo.ToString(CultureInfo.CurrentCulture) &
                " is ready. The previous final remains active until this amendment is submitted.",
                "Amendment Started",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
        Catch ex As Exception
            AppNotification.Show("Unable to start the payroll amendment: " & ex.Message, "Amend Final Payroll", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function TryRequestAmendmentRemarks(ByRef remarks As String) As Boolean
        Using dialog As New Form With {
            .Text = "Amend Final Payroll",
            .StartPosition = FormStartPosition.CenterParent,
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .MinimizeBox = False,
            .MaximizeBox = False,
            .ShowInTaskbar = False,
            .ClientSize = New Size(540, 255),
            .BackColor = CanvasColor,
            .Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
        }
            Dim layout As New TableLayoutPanel With {
                .Dock = DockStyle.Fill,
                .ColumnCount = 1,
                .RowCount = 4,
                .Padding = New Padding(18),
                .BackColor = CanvasColor
            }
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 44.0!))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 46.0!))

            Dim heading As New Label With {
                .Dock = DockStyle.Fill,
                .Text = "Why does this finalized payroll need to change?",
                .Font = New Font("Segoe UI Semibold", 11.0!, FontStyle.Bold),
                .ForeColor = TextColor,
                .TextAlign = ContentAlignment.MiddleLeft
            }
            Dim input As New TextBox With {
                .Dock = DockStyle.Fill,
                .Multiline = True,
                .ScrollBars = ScrollBars.Vertical,
                .MaxLength = 1000,
                .Font = New Font("Segoe UI", 9.5!, FontStyle.Regular),
                .AccessibleName = "Reason for amending final payroll"
            }
            Dim helper As New Label With {
                .Dock = DockStyle.Fill,
                .Text = "Required. The reason and user account will be written to the audit history.",
                .ForeColor = MutedTextColor,
                .Font = New Font("Segoe UI", 8.0!, FontStyle.Italic),
                .TextAlign = ContentAlignment.MiddleLeft
            }
            Dim actions As New FlowLayoutPanel With {
                .Dock = DockStyle.Fill,
                .FlowDirection = FlowDirection.RightToLeft,
                .WrapContents = False,
                .Padding = New Padding(0, 5, 0, 0)
            }
            Dim startButton As New Button With {
                .Text = "Start Amendment",
                .DialogResult = DialogResult.OK,
                .Width = 142,
                .Height = 34,
                .BackColor = WarningColor,
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
            }
            startButton.FlatAppearance.BorderSize = 0
            Dim cancelButton As New Button With {
                .Text = "Cancel",
                .DialogResult = DialogResult.Cancel,
                .Width = 92,
                .Height = 34,
                .BackColor = Color.White,
                .ForeColor = TextColor,
                .FlatStyle = FlatStyle.Flat
            }
            cancelButton.FlatAppearance.BorderColor = BorderColor
            AddHandler startButton.Click,
                Sub(sender, e)
                    If String.IsNullOrWhiteSpace(input.Text) Then
                        dialog.DialogResult = DialogResult.None
                        AppNotification.Show("Enter the reason for this amendment.", "Remarks Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        input.Focus()
                    End If
                End Sub
            actions.Controls.Add(startButton)
            actions.Controls.Add(cancelButton)
            layout.Controls.Add(heading, 0, 0)
            layout.Controls.Add(input, 0, 1)
            layout.Controls.Add(helper, 0, 2)
            layout.Controls.Add(actions, 0, 3)
            dialog.Controls.Add(layout)
            dialog.AcceptButton = startButton
            dialog.CancelButton = cancelButton
            If dialog.ShowDialog(Me) <> DialogResult.OK Then Return False
            remarks = input.Text.Trim()
            Return remarks <> String.Empty
        End Using
    End Function

    Private Function SavePayrollRecord(submitFinal As Boolean, Optional showSuccessNotification As Boolean = True) As Boolean
        If isRecordReadOnly Then Return False
        If Not ValidateHourAdjustments(True) Then Return False
        Dim totals = CalculateTotals()
        Dim daily = DailyTotals()
        Dim adjustments As PayrollAdjustments = Nothing

        If submitFinal AndAlso daily.Count = 0 Then
            AppNotification.Show("Select at least one rendered shift before submitting final payroll.", "Incomplete Payroll", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If submitFinal AndAlso dailyWage <= 0D Then
            AppNotification.Show("The selected detachment has no valid daily wage. Set the daily wage before saving payroll input.", "Missing Daily Wage", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not TryReadPayrollAdjustments(adjustments, True) Then Return False

        Dim isAmendment = currentRecord IsNot Nothing AndAlso
            currentRecord.RecordStatus = ManualPayrollRecordService.StatusAmendmentDraft
        If isAmendment AndAlso (txtChangeRemarks Is Nothing OrElse String.IsNullOrWhiteSpace(txtChangeRemarks.Text)) Then
            AppNotification.Show("Enter amendment remarks before saving these changes.", "Remarks Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If txtChangeRemarks IsNot Nothing Then txtChangeRemarks.Focus()
            Return False
        End If

        RefreshPayrollPreview()

        Dim subClientId As Integer
        If Not Integer.TryParse(GlobalVariables.DTR_Selected_SubClient_ID, subClientId) OrElse subClientId <= 0 Then
            AppNotification.Show("Unable to identify the selected detachment.", "Payroll Record", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If submitFinal Then
            Dim emptyDates = coveredDates.Count - daily.Count
            Dim submitLabel = If(isAmendment, "AMENDED FINAL", "FINAL")
            Dim prompt = "Submit this payroll as " & submitLabel & " for " & GlobalVariables.DTR_Selected_Employee_Name &
                " / " & BuildCutoff() & "?" & vbCrLf & vbCrLf &
                "Estimated net pay: " & lblNetPayValue.Text & vbCrLf &
                "Dates without a selected shift: " & emptyDates.ToString(CultureInfo.CurrentCulture) & vbCrLf & vbCrLf &
                If(isAmendment,
                   "Revision " & currentRecord.RevisionNo.ToString(CultureInfo.CurrentCulture) & " will become the active final payroll.",
                   "Final submission completes this cutoff. Future changes require a documented amendment.")
            If AppNotification.Show(prompt, If(isAmendment, "Submit Amended Payroll", "Submit Final Payroll"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return False
        End If

        Try
            Dim record = BuildPayrollRecord(totals, adjustments, subClientId)
            currentRecord = ManualPayrollRecordService.Save(record, submitFinal, CurrentActor())
            hasUnsavedChanges = False
            SetAmendmentPanelVisible(currentRecord.RecordStatus = ManualPayrollRecordService.StatusAmendmentDraft)
            UpdateRecordStateVisuals(currentRecord.RecordStatus, currentRecord)
            SetRecordEditability(Not submitFinal)
            RefreshCutoffFileTabs()

            Dim actionText = If(submitFinal,
                If(isAmendment, "Submitted amended final payroll", "Submitted final payroll"),
                If(isAmendment, "Saved payroll amendment", "Saved payroll draft"))
            Try
                Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in,
                    actionText & " for employee " & GlobalVariables.DTR_Selected_Employee_ID & " / " & BuildCutoff())
            Catch
            End Try

            If showSuccessNotification Then
                AppNotification.Show(
                    If(submitFinal,
                       If(isAmendment, "Amended payroll submitted as the active final.", "Final payroll submitted.") &
                           vbCrLf & "Estimated net pay: " & lblNetPayValue.Text,
                       If(isAmendment, "Amendment draft saved with its audit remarks.", "Draft saved. You can return to this employee and cutoff to continue editing.")),
                    If(submitFinal, "Payroll Completed", If(isAmendment, "Amendment Saved", "Draft Saved")),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End If
            Return True
        Catch ex As Exception
            AppNotification.Show("Unable to save the payroll cutoff: " & ex.Message, "Payroll Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function BuildPayrollRecord(totals As Dictionary(Of String, Decimal), adjustments As PayrollAdjustments, subClientId As Integer) As ManualPayrollRecord
        Dim breakdown = SubClientPayrollPolicyService.CalculateEarningsBreakdownForDays(
            payrollPolicy,
            dailyWage,
            BuildCutoff(),
            totals("NUM_DAYS"),
            BuildPayrollDayEarningInputs(),
            adjustments.OfficerAllowance,
            adjustments.UniformAllowance,
            adjustments.OtherEarnings)
        Dim combinedTotals = CalculateCombinedClassificationTotals()
        Dim totalDeductions = adjustments.TotalDeductions(IsFirstCutoffSelected())

        Dim record As New ManualPayrollRecord With {
            .ParentRecordId = If(currentRecord Is Nothing, 0, currentRecord.ParentRecordId),
            .RevisionNo = If(currentRecord Is Nothing, 0, currentRecord.RevisionNo),
            .RecordStatus = If(currentRecord Is Nothing, ManualPayrollRecordService.StatusDraft, currentRecord.RecordStatus),
            .ChangeRemarks = If(txtChangeRemarks Is Nothing, String.Empty, txtChangeRemarks.Text.Trim()),
            .EmployeeId = GlobalVariables.DTR_Selected_Employee_ID,
            .EmployeeNameSnapshot = GlobalVariables.DTR_Selected_Employee_Name,
            .SubClientId = subClientId,
            .SubClientNameSnapshot = GlobalVariables.DTR_Selected_SubClient_Name,
            .ClientAddressSnapshot = GlobalVariables.DTR_Selected_SubClient_Address,
            .CutoffPeriod = BuildCutoff(),
            .NumberOfDays = totals("NUM_DAYS"),
            .TotalHours = totals("TOTAL_HOURS"),
            .RegularHours = totals("REG"),
            .SundayHours = totals("SUN"),
            .SpecialHolidayHours = totals("SH"),
            .LegalHolidayHours = totals("LH"),
            .NightDifferentialDays = totals("ND_DAYS"),
            .NightDifferentialRegularHours = totals("ND_REG"),
            .NightDifferentialSundayHours = totals("ND_SUN"),
            .NightDifferentialSpecialHolidayHours = totals("ND_SH"),
            .NightDifferentialLegalHolidayHours = totals("ND_LH"),
            .OvertimeRegularHours = totals("OT_REG"),
            .OvertimeSundayHours = totals("OT_SUN"),
            .OvertimeSpecialHolidayHours = totals("OT_SH"),
            .OvertimeLegalHolidayHours = totals("OT_LH"),
            .SundaySpecialHolidayHours = combinedTotals("RD_SH"),
            .SundayLegalHolidayHours = combinedTotals("RD_LH"),
            .NightDifferentialSundaySpecialHolidayHours = combinedTotals("ND_RD_SH"),
            .NightDifferentialSundayLegalHolidayHours = combinedTotals("ND_RD_LH"),
            .OvertimeSundaySpecialHolidayHours = combinedTotals("OT_RD_SH"),
            .OvertimeSundayLegalHolidayHours = combinedTotals("OT_RD_LH"),
            .CashBondDeduction = adjustments.CashBondDeduction,
            .SssLoanDeduction = adjustments.SssLoanDeduction,
            .SssCalLoanDeduction = adjustments.SssCalLoanDeduction,
            .PagIbigLoanDeduction = adjustments.PagIbigLoanDeduction,
            .PagIbigCalLoanDeduction = adjustments.PagIbigCalLoanDeduction,
            .PhilHealthDeduction = adjustments.PhilHealthDeduction,
            .SssDeduction = adjustments.SssDeduction,
            .SssProvidentDeduction = adjustments.SssProvidentDeduction,
            .PagIbigDeduction = adjustments.PagIbigDeduction,
            .OfficerAllowance = adjustments.OfficerAllowance,
            .UniformAllowance = adjustments.UniformAllowance,
            .OtherEarnings = adjustments.OtherEarnings,
            .OtherDeductions = adjustments.OtherDeductions,
            .DailyWageSnapshot = dailyWage,
            .HoursPerDaySnapshot = payrollPolicy.HoursPerDay,
            .RegularEarnings = breakdown.AmountFor("REG"),
            .SundayEarnings = breakdown.AmountFor("SUN"),
            .SpecialHolidayEarnings = breakdown.AmountFor("SH"),
            .LegalHolidayEarnings = breakdown.AmountFor("LH"),
            .NightDifferentialRegularEarnings = breakdown.AmountFor("ND_REG"),
            .NightDifferentialSundayEarnings = breakdown.AmountFor("ND_SUN"),
            .NightDifferentialSpecialHolidayEarnings = breakdown.AmountFor("ND_SH"),
            .NightDifferentialLegalHolidayEarnings = breakdown.AmountFor("ND_LH"),
            .OvertimeRegularEarnings = breakdown.AmountFor("OT_REG"),
            .OvertimeSundayEarnings = breakdown.AmountFor("OT_SUN"),
            .OvertimeSpecialHolidayEarnings = breakdown.AmountFor("OT_SH"),
            .OvertimeLegalHolidayEarnings = breakdown.AmountFor("OT_LH"),
            .IncentivePay = breakdown.IncentivePay,
            .TotalEarnings = breakdown.TotalEarnings,
            .TotalDeductions = totalDeductions,
            .NetPay = breakdown.TotalEarnings - totalDeductions,
            .CalculationVersion = ManualPayrollRecordService.CurrentCalculationVersion,
            .PayPolicySnapshot = payrollPolicy.ToAuditText(),
            .SnapshotComplete = True
        }

        For Each reportDate In coveredDates
            Dim selectedShifts = SelectedShiftsForDate(reportDate)
            Dim allocation = AllocateHoursForDate(reportDate, selectedShifts)
            record.Days.Add(New ManualPayrollDayRecord With {
                .ReportDate = reportDate.Date,
                .SelectedShiftNames = selectedShifts.Select(Function(shift) shift.Name).ToList(),
                .Classification = ClassificationForDate(reportDate),
                .HourAdjustment = HourAdjustmentForDate(reportDate),
                .TotalHours = allocation.TotalHours
            })
        Next
        Return record
    End Function

    Private Function CurrentActor() As String
        Dim employeeId = If(GlobalVariables.sEmployee_ID_Logged_in, String.Empty).Trim()
        If employeeId <> String.Empty Then Return employeeId
        Dim displayName = If(GlobalVariables.sLogged_in_Name, String.Empty).Trim()
        If displayName <> String.Empty Then Return displayName
        Return If(GlobalVariables.sUser_Level, "Payroll user").Trim()
    End Function

    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Close()
    End Sub
End Class
