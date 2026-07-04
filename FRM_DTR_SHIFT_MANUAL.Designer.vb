<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_DTR_SHIFT_MANUAL

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.rootPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.toolbarPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.periodPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblPeriodTitle = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.lblCutoff = New System.Windows.Forms.Label()
        Me.cmbCutoff = New System.Windows.Forms.ComboBox()
        Me.workPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.shiftSection = New System.Windows.Forms.TableLayoutPanel()
        Me.shiftGrid = New System.Windows.Forms.DataGridView()
        Me.fillPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.holidayGrid = New System.Windows.Forms.DataGridView()
        Me.dailyHoursGrid = New System.Windows.Forms.DataGridView()
        Me.headerPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.pnlEmployee = New System.Windows.Forms.Panel()
        Me.lblEmployee = New System.Windows.Forms.Label()
        Me.lblEmployeeCaption = New System.Windows.Forms.Label()
        Me.pnlClient = New System.Windows.Forms.Panel()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.lblClientCaption = New System.Windows.Forms.Label()
        Me.pnlAddress = New System.Windows.Forms.Panel()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblAddressCaption = New System.Windows.Forms.Label()
        Me.pnlSchedType = New System.Windows.Forms.Panel()
        Me.lblSchedType = New System.Windows.Forms.Label()
        Me.lblSchedTypeCaption = New System.Windows.Forms.Label()
        Me.pnlCoverage = New System.Windows.Forms.Panel()
        Me.lblCoverage = New System.Windows.Forms.Label()
        Me.lblCoverageCaption = New System.Windows.Forms.Label()
        Me.footerPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNumDays = New System.Windows.Forms.Label()
        Me.lblTotalHours = New System.Windows.Forms.Label()
        Me.lblReg = New System.Windows.Forms.Label()
        Me.lblSun = New System.Windows.Forms.Label()
        Me.lblSh = New System.Windows.Forms.Label()
        Me.lblLh = New System.Windows.Forms.Label()
        Me.lblOt = New System.Windows.Forms.Label()
        Me.lblNdDays = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.rootPanel.SuspendLayout()
        Me.toolbarPanel.SuspendLayout()
        Me.periodPanel.SuspendLayout()
        Me.workPanel.SuspendLayout()
        Me.shiftSection.SuspendLayout()
        CType(Me.shiftGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.holidayGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dailyHoursGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.headerPanel.SuspendLayout()
        Me.pnlEmployee.SuspendLayout()
        Me.pnlClient.SuspendLayout()
        Me.pnlAddress.SuspendLayout()
        Me.pnlSchedType.SuspendLayout()
        Me.pnlCoverage.SuspendLayout()
        Me.footerPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'rootPanel
        '
        Me.rootPanel.ColumnCount = 2
        Me.rootPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.0!))
        Me.rootPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.rootPanel.Controls.Add(Me.toolbarPanel, 0, 0)
        Me.rootPanel.Controls.Add(Me.workPanel, 0, 1)
        Me.rootPanel.Controls.Add(Me.headerPanel, 1, 1)
        Me.rootPanel.Controls.Add(Me.footerPanel, 0, 2)
        Me.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootPanel.Location = New System.Drawing.Point(0, 0)
        Me.rootPanel.Name = "rootPanel"
        Me.rootPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.rootPanel.RowCount = 3
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.rootPanel.Size = New System.Drawing.Size(1220, 720)
        Me.rootPanel.TabIndex = 0
        Me.rootPanel.SetColumnSpan(Me.toolbarPanel, 2)
        Me.rootPanel.SetColumnSpan(Me.footerPanel, 2)
        '
        'toolbarPanel
        '
        Me.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.toolbarPanel.ColumnCount = 1
        Me.toolbarPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.toolbarPanel.Controls.Add(Me.periodPanel, 0, 0)
        Me.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolbarPanel.Location = New System.Drawing.Point(13, 13)
        Me.toolbarPanel.Name = "toolbarPanel"
        Me.toolbarPanel.RowCount = 1
        Me.toolbarPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.toolbarPanel.Size = New System.Drawing.Size(1194, 48)
        Me.toolbarPanel.TabIndex = 0
        '
        'periodPanel
        '
        Me.periodPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.periodPanel.Controls.Add(Me.lblPeriodTitle)
        Me.periodPanel.Controls.Add(Me.lblYear)
        Me.periodPanel.Controls.Add(Me.cmbYear)
        Me.periodPanel.Controls.Add(Me.lblMonth)
        Me.periodPanel.Controls.Add(Me.cmbMonth)
        Me.periodPanel.Controls.Add(Me.lblCutoff)
        Me.periodPanel.Controls.Add(Me.cmbCutoff)
        Me.periodPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.periodPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
        Me.periodPanel.Location = New System.Drawing.Point(3, 3)
        Me.periodPanel.Name = "periodPanel"
        Me.periodPanel.Padding = New System.Windows.Forms.Padding(4, 8, 4, 0)
        Me.periodPanel.Size = New System.Drawing.Size(1188, 42)
        Me.periodPanel.TabIndex = 0
        Me.periodPanel.WrapContents = True
        '
        'lblPeriodTitle
        '
        Me.lblPeriodTitle.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.lblPeriodTitle.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblPeriodTitle.ForeColor = System.Drawing.Color.Teal
        Me.lblPeriodTitle.Location = New System.Drawing.Point(4, 10)
        Me.lblPeriodTitle.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.lblPeriodTitle.Name = "lblPeriodTitle"
        Me.lblPeriodTitle.Size = New System.Drawing.Size(58, 32)
        Me.lblPeriodTitle.TabIndex = 0
        Me.lblPeriodTitle.Text = "Period"
        Me.lblPeriodTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblYear
        '
        Me.lblYear.AutoEllipsis = True
        Me.lblYear.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.lblYear.Location = New System.Drawing.Point(70, 10)
        Me.lblYear.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(72, 28)
        Me.lblYear.TabIndex = 1
        Me.lblYear.Text = "Year"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbYear
        '
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.Location = New System.Drawing.Point(148, 10)
        Me.cmbYear.Margin = New System.Windows.Forms.Padding(0, 2, 12, 0)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(86, 24)
        Me.cmbYear.TabIndex = 2
        '
        'lblMonth
        '
        Me.lblMonth.AutoEllipsis = True
        Me.lblMonth.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.lblMonth.Location = New System.Drawing.Point(246, 10)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(72, 28)
        Me.lblMonth.TabIndex = 3
        Me.lblMonth.Text = "Month"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbMonth
        '
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.Location = New System.Drawing.Point(324, 10)
        Me.cmbMonth.Margin = New System.Windows.Forms.Padding(0, 2, 12, 0)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(100, 24)
        Me.cmbMonth.TabIndex = 4
        '
        'lblCutoff
        '
        Me.lblCutoff.AutoEllipsis = True
        Me.lblCutoff.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.lblCutoff.Location = New System.Drawing.Point(436, 10)
        Me.lblCutoff.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.lblCutoff.Name = "lblCutoff"
        Me.lblCutoff.Size = New System.Drawing.Size(72, 28)
        Me.lblCutoff.TabIndex = 5
        Me.lblCutoff.Text = "Cutoff"
        Me.lblCutoff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCutoff
        '
        Me.cmbCutoff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCutoff.Location = New System.Drawing.Point(514, 10)
        Me.cmbCutoff.Margin = New System.Windows.Forms.Padding(0, 2, 12, 0)
        Me.cmbCutoff.Name = "cmbCutoff"
        Me.cmbCutoff.Size = New System.Drawing.Size(124, 24)
        Me.cmbCutoff.TabIndex = 6
        '
        'workPanel
        '
        Me.workPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.workPanel.ColumnCount = 1
        Me.workPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.workPanel.Controls.Add(Me.shiftSection, 0, 0)
        Me.workPanel.Controls.Add(Me.holidayGrid, 0, 1)
        Me.workPanel.Controls.Add(Me.dailyHoursGrid, 0, 2)
        Me.workPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.workPanel.Location = New System.Drawing.Point(13, 67)
        Me.workPanel.Name = "workPanel"
        Me.workPanel.RowCount = 3
        Me.workPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.0!))
        Me.workPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.workPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.workPanel.Size = New System.Drawing.Size(882, 576)
        Me.workPanel.TabIndex = 1
        '
        'shiftSection
        '
        Me.shiftSection.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.shiftSection.ColumnCount = 1
        Me.shiftSection.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.shiftSection.Controls.Add(Me.shiftGrid, 0, 0)
        Me.shiftSection.Controls.Add(Me.fillPanel, 0, 1)
        Me.shiftSection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.shiftSection.Location = New System.Drawing.Point(3, 3)
        Me.shiftSection.Name = "shiftSection"
        Me.shiftSection.RowCount = 2
        Me.shiftSection.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.shiftSection.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.shiftSection.Size = New System.Drawing.Size(876, 258)
        Me.shiftSection.TabIndex = 0
        '
        'shiftGrid
        '
        Me.shiftGrid.AllowUserToAddRows = False
        Me.shiftGrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 238, 214)
        Me.shiftGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.shiftGrid.BackgroundColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.shiftGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shiftGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Teal
        Me.shiftGrid.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.shiftGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.shiftGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.shiftGrid.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.shiftGrid.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.shiftGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.shiftGrid.EnableHeadersVisualStyles = False
        Me.shiftGrid.Location = New System.Drawing.Point(3, 3)
        Me.shiftGrid.MultiSelect = False
        Me.shiftGrid.Name = "shiftGrid"
        Me.shiftGrid.RowHeadersVisible = False
        Me.shiftGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.shiftGrid.Size = New System.Drawing.Size(870, 204)
        Me.shiftGrid.TabIndex = 0
        '
        'fillPanel
        '
        Me.fillPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fillPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
        Me.fillPanel.Location = New System.Drawing.Point(3, 213)
        Me.fillPanel.Name = "fillPanel"
        Me.fillPanel.Padding = New System.Windows.Forms.Padding(4, 7, 4, 0)
        Me.fillPanel.Size = New System.Drawing.Size(870, 42)
        Me.fillPanel.TabIndex = 1
        Me.fillPanel.WrapContents = True
        '
        'holidayGrid
        '
        Me.holidayGrid.AllowUserToAddRows = False
        Me.holidayGrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 238, 214)
        Me.holidayGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.holidayGrid.BackgroundColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.holidayGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.holidayGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Teal
        Me.holidayGrid.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.holidayGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.holidayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.holidayGrid.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.holidayGrid.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.holidayGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.holidayGrid.EnableHeadersVisualStyles = False
        Me.holidayGrid.Location = New System.Drawing.Point(3, 267)
        Me.holidayGrid.MultiSelect = False
        Me.holidayGrid.Name = "holidayGrid"
        Me.holidayGrid.ReadOnly = True
        Me.holidayGrid.RowHeadersVisible = False
        Me.holidayGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.holidayGrid.Size = New System.Drawing.Size(876, 138)
        Me.holidayGrid.TabIndex = 1
        '
        'dailyHoursGrid
        '
        Me.dailyHoursGrid.AllowUserToAddRows = False
        Me.dailyHoursGrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 238, 214)
        Me.dailyHoursGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dailyHoursGrid.BackgroundColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.dailyHoursGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dailyHoursGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Teal
        Me.dailyHoursGrid.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dailyHoursGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dailyHoursGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dailyHoursGrid.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.dailyHoursGrid.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dailyHoursGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dailyHoursGrid.EnableHeadersVisualStyles = False
        Me.dailyHoursGrid.Location = New System.Drawing.Point(3, 411)
        Me.dailyHoursGrid.MultiSelect = False
        Me.dailyHoursGrid.Name = "dailyHoursGrid"
        Me.dailyHoursGrid.ReadOnly = True
        Me.dailyHoursGrid.RowHeadersVisible = False
        Me.dailyHoursGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dailyHoursGrid.Size = New System.Drawing.Size(876, 162)
        Me.dailyHoursGrid.TabIndex = 2
        '
        'headerPanel
        '
        Me.headerPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.headerPanel.ColumnCount = 1
        Me.headerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.headerPanel.Controls.Add(Me.lblHeaderTitle, 0, 0)
        Me.headerPanel.Controls.Add(Me.pnlEmployee, 0, 1)
        Me.headerPanel.Controls.Add(Me.pnlClient, 0, 2)
        Me.headerPanel.Controls.Add(Me.pnlAddress, 0, 3)
        Me.headerPanel.Controls.Add(Me.pnlSchedType, 0, 4)
        Me.headerPanel.Controls.Add(Me.pnlCoverage, 0, 5)
        Me.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.headerPanel.Location = New System.Drawing.Point(901, 67)
        Me.headerPanel.Name = "headerPanel"
        Me.headerPanel.RowCount = 7
        Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.headerPanel.Size = New System.Drawing.Size(306, 576)
        Me.headerPanel.TabIndex = 2
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.BackColor = System.Drawing.Color.Teal
        Me.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblHeaderTitle.Size = New System.Drawing.Size(300, 42)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "DTR employee"
        Me.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlEmployee
        '
        Me.pnlEmployee.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlEmployee.Controls.Add(Me.lblEmployee)
        Me.pnlEmployee.Controls.Add(Me.lblEmployeeCaption)
        Me.pnlEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEmployee.Location = New System.Drawing.Point(0, 42)
        Me.pnlEmployee.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlEmployee.Name = "pnlEmployee"
        Me.pnlEmployee.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlEmployee.Size = New System.Drawing.Size(306, 58)
        Me.pnlEmployee.TabIndex = 1
        '
        'lblEmployee
        '
        Me.lblEmployee.AutoEllipsis = True
        Me.lblEmployee.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEmployee.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lblEmployee.ForeColor = System.Drawing.Color.Blue
        Me.lblEmployee.Location = New System.Drawing.Point(10, 24)
        Me.lblEmployee.Name = "lblEmployee"
        Me.lblEmployee.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblEmployee.Size = New System.Drawing.Size(286, 28)
        Me.lblEmployee.TabIndex = 1
        Me.lblEmployee.Text = "Employee: -"
        Me.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployeeCaption
        '
        Me.lblEmployeeCaption.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblEmployeeCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEmployeeCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblEmployeeCaption.Location = New System.Drawing.Point(10, 6)
        Me.lblEmployeeCaption.Name = "lblEmployeeCaption"
        Me.lblEmployeeCaption.Size = New System.Drawing.Size(286, 18)
        Me.lblEmployeeCaption.TabIndex = 0
        Me.lblEmployeeCaption.Text = "EMPLOYEE"
        Me.lblEmployeeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlClient
        '
        Me.pnlClient.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlClient.Controls.Add(Me.lblClient)
        Me.pnlClient.Controls.Add(Me.lblClientCaption)
        Me.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlClient.Location = New System.Drawing.Point(0, 106)
        Me.pnlClient.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlClient.Name = "pnlClient"
        Me.pnlClient.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlClient.Size = New System.Drawing.Size(306, 58)
        Me.pnlClient.TabIndex = 2
        '
        'lblClient
        '
        Me.lblClient.AutoEllipsis = True
        Me.lblClient.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClient.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lblClient.ForeColor = System.Drawing.Color.Blue
        Me.lblClient.Location = New System.Drawing.Point(10, 24)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblClient.Size = New System.Drawing.Size(286, 28)
        Me.lblClient.TabIndex = 1
        Me.lblClient.Text = "Detachment: -"
        Me.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClientCaption
        '
        Me.lblClientCaption.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblClientCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblClientCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblClientCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblClientCaption.Location = New System.Drawing.Point(10, 6)
        Me.lblClientCaption.Name = "lblClientCaption"
        Me.lblClientCaption.Size = New System.Drawing.Size(286, 18)
        Me.lblClientCaption.TabIndex = 0
        Me.lblClientCaption.Text = "DETACHMENT"
        Me.lblClientCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAddress
        '
        Me.pnlAddress.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlAddress.Controls.Add(Me.lblAddress)
        Me.pnlAddress.Controls.Add(Me.lblAddressCaption)
        Me.pnlAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddress.Location = New System.Drawing.Point(0, 170)
        Me.pnlAddress.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlAddress.Name = "pnlAddress"
        Me.pnlAddress.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlAddress.Size = New System.Drawing.Size(306, 58)
        Me.pnlAddress.TabIndex = 3
        '
        'lblAddress
        '
        Me.lblAddress.AutoEllipsis = True
        Me.lblAddress.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAddress.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lblAddress.ForeColor = System.Drawing.Color.Blue
        Me.lblAddress.Location = New System.Drawing.Point(10, 24)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblAddress.Size = New System.Drawing.Size(286, 28)
        Me.lblAddress.TabIndex = 1
        Me.lblAddress.Text = "Address: -"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddressCaption
        '
        Me.lblAddressCaption.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblAddressCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAddressCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblAddressCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblAddressCaption.Location = New System.Drawing.Point(10, 6)
        Me.lblAddressCaption.Name = "lblAddressCaption"
        Me.lblAddressCaption.Size = New System.Drawing.Size(286, 18)
        Me.lblAddressCaption.TabIndex = 0
        Me.lblAddressCaption.Text = "ADDRESS"
        Me.lblAddressCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlSchedType
        '
        Me.pnlSchedType.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlSchedType.Controls.Add(Me.lblSchedType)
        Me.pnlSchedType.Controls.Add(Me.lblSchedTypeCaption)
        Me.pnlSchedType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSchedType.Location = New System.Drawing.Point(0, 234)
        Me.pnlSchedType.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlSchedType.Name = "pnlSchedType"
        Me.pnlSchedType.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlSchedType.Size = New System.Drawing.Size(306, 58)
        Me.pnlSchedType.TabIndex = 4
        '
        'lblSchedType
        '
        Me.lblSchedType.AutoEllipsis = True
        Me.lblSchedType.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblSchedType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSchedType.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lblSchedType.ForeColor = System.Drawing.Color.Blue
        Me.lblSchedType.Location = New System.Drawing.Point(10, 24)
        Me.lblSchedType.Name = "lblSchedType"
        Me.lblSchedType.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblSchedType.Size = New System.Drawing.Size(286, 28)
        Me.lblSchedType.TabIndex = 1
        Me.lblSchedType.Text = "Schedule Type: -"
        Me.lblSchedType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSchedTypeCaption
        '
        Me.lblSchedTypeCaption.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblSchedTypeCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSchedTypeCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblSchedTypeCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblSchedTypeCaption.Location = New System.Drawing.Point(10, 6)
        Me.lblSchedTypeCaption.Name = "lblSchedTypeCaption"
        Me.lblSchedTypeCaption.Size = New System.Drawing.Size(286, 18)
        Me.lblSchedTypeCaption.TabIndex = 0
        Me.lblSchedTypeCaption.Text = "SCHEDULE TYPE"
        Me.lblSchedTypeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCoverage
        '
        Me.pnlCoverage.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlCoverage.Controls.Add(Me.lblCoverage)
        Me.pnlCoverage.Controls.Add(Me.lblCoverageCaption)
        Me.pnlCoverage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCoverage.Location = New System.Drawing.Point(0, 298)
        Me.pnlCoverage.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlCoverage.Name = "pnlCoverage"
        Me.pnlCoverage.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlCoverage.Size = New System.Drawing.Size(306, 58)
        Me.pnlCoverage.TabIndex = 5
        '
        'lblCoverage
        '
        Me.lblCoverage.AutoEllipsis = True
        Me.lblCoverage.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblCoverage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCoverage.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lblCoverage.ForeColor = System.Drawing.Color.Blue
        Me.lblCoverage.Location = New System.Drawing.Point(10, 24)
        Me.lblCoverage.Name = "lblCoverage"
        Me.lblCoverage.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblCoverage.Size = New System.Drawing.Size(286, 28)
        Me.lblCoverage.TabIndex = 1
        Me.lblCoverage.Text = "Coverage: -"
        Me.lblCoverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCoverageCaption
        '
        Me.lblCoverageCaption.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblCoverageCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCoverageCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblCoverageCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblCoverageCaption.Location = New System.Drawing.Point(10, 6)
        Me.lblCoverageCaption.Name = "lblCoverageCaption"
        Me.lblCoverageCaption.Size = New System.Drawing.Size(286, 18)
        Me.lblCoverageCaption.TabIndex = 0
        Me.lblCoverageCaption.Text = "COVERAGE"
        Me.lblCoverageCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'footerPanel
        '
        Me.footerPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.footerPanel.ColumnCount = 10
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.5!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.footerPanel.Controls.Add(Me.lblNumDays, 0, 0)
        Me.footerPanel.Controls.Add(Me.lblTotalHours, 1, 0)
        Me.footerPanel.Controls.Add(Me.lblReg, 2, 0)
        Me.footerPanel.Controls.Add(Me.lblSun, 3, 0)
        Me.footerPanel.Controls.Add(Me.lblSh, 4, 0)
        Me.footerPanel.Controls.Add(Me.lblLh, 5, 0)
        Me.footerPanel.Controls.Add(Me.lblOt, 6, 0)
        Me.footerPanel.Controls.Add(Me.lblNdDays, 7, 0)
        Me.footerPanel.Controls.Add(Me.btnSave, 8, 0)
        Me.footerPanel.Controls.Add(Me.btnClose, 9, 0)
        Me.footerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.footerPanel.Location = New System.Drawing.Point(13, 649)
        Me.footerPanel.Name = "footerPanel"
        Me.footerPanel.RowCount = 1
        Me.footerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.footerPanel.Size = New System.Drawing.Size(1194, 58)
        Me.footerPanel.TabIndex = 3
        '
        'lblNumDays
        '
        Me.lblNumDays.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblNumDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumDays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNumDays.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNumDays.Location = New System.Drawing.Point(3, 0)
        Me.lblNumDays.Name = "lblNumDays"
        Me.lblNumDays.Size = New System.Drawing.Size(119, 58)
        Me.lblNumDays.TabIndex = 0
        Me.lblNumDays.Text = "Days: 0"
        Me.lblNumDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalHours
        '
        Me.lblTotalHours.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblTotalHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalHours.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalHours.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotalHours.Location = New System.Drawing.Point(128, 0)
        Me.lblTotalHours.Name = "lblTotalHours"
        Me.lblTotalHours.Size = New System.Drawing.Size(119, 58)
        Me.lblTotalHours.TabIndex = 1
        Me.lblTotalHours.Text = "Total: 0"
        Me.lblTotalHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReg
        '
        Me.lblReg.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblReg.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblReg.Location = New System.Drawing.Point(253, 0)
        Me.lblReg.Name = "lblReg"
        Me.lblReg.Size = New System.Drawing.Size(119, 58)
        Me.lblReg.TabIndex = 2
        Me.lblReg.Text = "REG: 0"
        Me.lblReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSun
        '
        Me.lblSun.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblSun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSun.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSun.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblSun.Location = New System.Drawing.Point(378, 0)
        Me.lblSun.Name = "lblSun"
        Me.lblSun.Size = New System.Drawing.Size(119, 58)
        Me.lblSun.TabIndex = 3
        Me.lblSun.Text = "SUN: 0"
        Me.lblSun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSh
        '
        Me.lblSh.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblSh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSh.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblSh.Location = New System.Drawing.Point(503, 0)
        Me.lblSh.Name = "lblSh"
        Me.lblSh.Size = New System.Drawing.Size(119, 58)
        Me.lblSh.TabIndex = 4
        Me.lblSh.Text = "SH: 0"
        Me.lblSh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLh
        '
        Me.lblLh.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblLh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLh.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblLh.Location = New System.Drawing.Point(628, 0)
        Me.lblLh.Name = "lblLh"
        Me.lblLh.Size = New System.Drawing.Size(119, 58)
        Me.lblLh.TabIndex = 5
        Me.lblLh.Text = "LH: 0"
        Me.lblLh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOt
        '
        Me.lblOt.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblOt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblOt.Location = New System.Drawing.Point(753, 0)
        Me.lblOt.Name = "lblOt"
        Me.lblOt.Size = New System.Drawing.Size(119, 58)
        Me.lblOt.TabIndex = 6
        Me.lblOt.Text = "OT: 0"
        Me.lblOt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNdDays
        '
        Me.lblNdDays.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.lblNdDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNdDays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNdDays.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNdDays.Location = New System.Drawing.Point(878, 0)
        Me.lblNdDays.Name = "lblNdDays"
        Me.lblNdDays.Size = New System.Drawing.Size(119, 58)
        Me.lblNdDays.TabIndex = 7
        Me.lblNdDays.Text = "ND Days: 0"
        Me.lblNdDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Teal
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(1003, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 52)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Teal
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(1098, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(93, 52)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'FRM_DTR_SHIFT_MANUAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.ClientSize = New System.Drawing.Size(1220, 720)
        Me.Controls.Add(Me.rootPanel)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)
        Me.MinimumSize = New System.Drawing.Size(1100, 650)
        Me.Name = "FRM_DTR_SHIFT_MANUAL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DTR Manual Shift Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.rootPanel.ResumeLayout(False)
        Me.toolbarPanel.ResumeLayout(False)
        Me.periodPanel.ResumeLayout(False)
        Me.workPanel.ResumeLayout(False)
        Me.shiftSection.ResumeLayout(False)
        CType(Me.shiftGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.holidayGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dailyHoursGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.headerPanel.ResumeLayout(False)
        Me.pnlEmployee.ResumeLayout(False)
        Me.pnlClient.ResumeLayout(False)
        Me.pnlAddress.ResumeLayout(False)
        Me.pnlSchedType.ResumeLayout(False)
        Me.pnlCoverage.ResumeLayout(False)
        Me.footerPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rootPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents toolbarPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents periodPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblPeriodTitle As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblCutoff As System.Windows.Forms.Label
    Friend WithEvents cmbCutoff As System.Windows.Forms.ComboBox
    Friend WithEvents workPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents shiftSection As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents shiftGrid As System.Windows.Forms.DataGridView
    Friend WithEvents fillPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents holidayGrid As System.Windows.Forms.DataGridView
    Friend WithEvents dailyHoursGrid As System.Windows.Forms.DataGridView
    Friend WithEvents headerPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents pnlEmployee As System.Windows.Forms.Panel
    Friend WithEvents lblEmployee As System.Windows.Forms.Label
    Friend WithEvents lblEmployeeCaption As System.Windows.Forms.Label
    Friend WithEvents pnlClient As System.Windows.Forms.Panel
    Friend WithEvents lblClient As System.Windows.Forms.Label
    Friend WithEvents lblClientCaption As System.Windows.Forms.Label
    Friend WithEvents pnlAddress As System.Windows.Forms.Panel
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblAddressCaption As System.Windows.Forms.Label
    Friend WithEvents pnlSchedType As System.Windows.Forms.Panel
    Friend WithEvents lblSchedType As System.Windows.Forms.Label
    Friend WithEvents lblSchedTypeCaption As System.Windows.Forms.Label
    Friend WithEvents pnlCoverage As System.Windows.Forms.Panel
    Friend WithEvents lblCoverage As System.Windows.Forms.Label
    Friend WithEvents lblCoverageCaption As System.Windows.Forms.Label
    Friend WithEvents footerPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNumDays As System.Windows.Forms.Label
    Friend WithEvents lblTotalHours As System.Windows.Forms.Label
    Friend WithEvents lblReg As System.Windows.Forms.Label
    Friend WithEvents lblSun As System.Windows.Forms.Label
    Friend WithEvents lblSh As System.Windows.Forms.Label
    Friend WithEvents lblLh As System.Windows.Forms.Label
    Friend WithEvents lblOt As System.Windows.Forms.Label
    Friend WithEvents lblNdDays As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
