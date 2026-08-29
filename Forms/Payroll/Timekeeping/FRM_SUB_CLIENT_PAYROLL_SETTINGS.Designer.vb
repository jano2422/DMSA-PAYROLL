<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_SUB_CLIENT_PAYROLL_SETTINGS
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.rootLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.titlePanel = New System.Windows.Forms.Panel()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.selectorLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMainClientCaption = New System.Windows.Forms.Label()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.lblSubClientCaption = New System.Windows.Forms.Label()
        Me.cmbWorkSite = New System.Windows.Forms.ComboBox()
        Me.lblClientContext = New System.Windows.Forms.Label()
        Me.lblPolicySummary = New System.Windows.Forms.Label()
        Me.settingsTabs = New System.Windows.Forms.TabControl()
        Me.tabEarningsMatrix = New System.Windows.Forms.TabPage()
        Me.rulesGrid = New System.Windows.Forms.DataGridView()
        Me.colRuleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEnabled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colMultiplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabCalculationOptions = New System.Windows.Forms.TabPage()
        Me.calculationLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHoursPerDayCaption = New System.Windows.Forms.Label()
        Me.numHoursPerDay = New System.Windows.Forms.NumericUpDown()
        Me.lblHoursPerDayHelp = New System.Windows.Forms.Label()
        Me.lblDutyEntryModeCaption = New System.Windows.Forms.Label()
        Me.cmbDutyEntryMode = New System.Windows.Forms.ComboBox()
        Me.lblDutyEntryModeHelp = New System.Windows.Forms.Label()
        Me.lblSingleShiftHoursCaption = New System.Windows.Forms.Label()
        Me.numSingleShiftHours = New System.Windows.Forms.NumericUpDown()
        Me.lblSingleShiftHoursHelp = New System.Windows.Forms.Label()
        Me.lblSingleShiftPeriodCaption = New System.Windows.Forms.Label()
        Me.chkSingleShiftIsNight = New System.Windows.Forms.CheckBox()
        Me.lblSingleShiftPeriodHelp = New System.Windows.Forms.Label()
        Me.lblNightDifferentialModeCaption = New System.Windows.Forms.Label()
        Me.cmbNightDifferentialMode = New System.Windows.Forms.ComboBox()
        Me.lblNightDifferentialModeHelp = New System.Windows.Forms.Label()
        Me.lblFixedNightDifferentialCaption = New System.Windows.Forms.Label()
        Me.numNightDifferentialFixedAmount = New System.Windows.Forms.NumericUpDown()
        Me.lblFixedNightDifferentialHelp = New System.Windows.Forms.Label()
        Me.lblIncentiveCaption = New System.Windows.Forms.Label()
        Me.chkIncentive = New System.Windows.Forms.CheckBox()
        Me.lblIncentiveHelp = New System.Windows.Forms.Label()
        Me.lblIncentiveDaysCaption = New System.Windows.Forms.Label()
        Me.numIncentiveDays = New System.Windows.Forms.NumericUpDown()
        Me.lblIncentiveDaysHelp = New System.Windows.Forms.Label()
        Me.lblIncentiveMonthDivisorCaption = New System.Windows.Forms.Label()
        Me.numIncentiveMonthDivisor = New System.Windows.Forms.NumericUpDown()
        Me.lblIncentiveMonthDivisorHelp = New System.Windows.Forms.Label()
        Me.lblIncentiveCutoffDivisorCaption = New System.Windows.Forms.Label()
        Me.numIncentiveCutoffDivisor = New System.Windows.Forms.NumericUpDown()
        Me.lblIncentiveCutoffDivisorHelp = New System.Windows.Forms.Label()
        Me.tabNotes = New System.Windows.Forms.TabPage()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.actionsPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.openPayrollRulesDialog = New System.Windows.Forms.OpenFileDialog()
        Me.rootLayout.SuspendLayout()
        Me.titlePanel.SuspendLayout()
        Me.selectorLayout.SuspendLayout()
        Me.settingsTabs.SuspendLayout()
        Me.tabEarningsMatrix.SuspendLayout()
        CType(Me.rulesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCalculationOptions.SuspendLayout()
        Me.calculationLayout.SuspendLayout()
        CType(Me.numHoursPerDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSingleShiftHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNightDifferentialFixedAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIncentiveDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIncentiveMonthDivisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIncentiveCutoffDivisor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabNotes.SuspendLayout()
        Me.actionsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'rootLayout
        '
        Me.rootLayout.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.rootLayout.ColumnCount = 1
        Me.rootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootLayout.Controls.Add(Me.titlePanel, 0, 0)
        Me.rootLayout.Controls.Add(Me.selectorLayout, 0, 1)
        Me.rootLayout.Controls.Add(Me.settingsTabs, 0, 2)
        Me.rootLayout.Controls.Add(Me.lblStatus, 0, 3)
        Me.rootLayout.Controls.Add(Me.actionsPanel, 0, 4)
        Me.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootLayout.Location = New System.Drawing.Point(0, 0)
        Me.rootLayout.Name = "rootLayout"
        Me.rootLayout.Padding = New System.Windows.Forms.Padding(14)
        Me.rootLayout.RowCount = 5
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108.0!))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.rootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.rootLayout.Size = New System.Drawing.Size(1164, 741)
        Me.rootLayout.TabIndex = 0
        '
        'titlePanel
        '
        Me.titlePanel.BackColor = System.Drawing.Color.Teal
        Me.titlePanel.Controls.Add(Me.lblSubtitle)
        Me.titlePanel.Controls.Add(Me.lblTitle)
        Me.titlePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.titlePanel.Location = New System.Drawing.Point(17, 17)
        Me.titlePanel.Name = "titlePanel"
        Me.titlePanel.Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
        Me.titlePanel.Size = New System.Drawing.Size(1130, 58)
        Me.titlePanel.TabIndex = 0
        '
        'lblSubtitle
        '
        Me.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(16, 34)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(1098, 16)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Enter additions only (.30 means +30%). Client master wage remains the base-pay source of truth."
        Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(16, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1098, 26)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Sub-client payroll rules"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'selectorLayout
        '
        Me.selectorLayout.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.selectorLayout.ColumnCount = 4
        Me.selectorLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.selectorLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.0!))
        Me.selectorLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.selectorLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.0!))
        Me.selectorLayout.Controls.Add(Me.lblMainClientCaption, 0, 0)
        Me.selectorLayout.Controls.Add(Me.cmbCompany, 1, 0)
        Me.selectorLayout.Controls.Add(Me.lblSubClientCaption, 2, 0)
        Me.selectorLayout.Controls.Add(Me.cmbWorkSite, 3, 0)
        Me.selectorLayout.Controls.Add(Me.lblClientContext, 0, 1)
        Me.selectorLayout.Controls.Add(Me.lblPolicySummary, 2, 1)
        Me.selectorLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.selectorLayout.Location = New System.Drawing.Point(17, 81)
        Me.selectorLayout.Name = "selectorLayout"
        Me.selectorLayout.Padding = New System.Windows.Forms.Padding(10, 10, 10, 8)
        Me.selectorLayout.RowCount = 2
        Me.selectorLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.selectorLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.selectorLayout.Size = New System.Drawing.Size(1130, 102)
        Me.selectorLayout.TabIndex = 1
        '
        'lblMainClientCaption
        '
        Me.lblMainClientCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMainClientCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblMainClientCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblMainClientCaption.Location = New System.Drawing.Point(13, 10)
        Me.lblMainClientCaption.Name = "lblMainClientCaption"
        Me.lblMainClientCaption.Size = New System.Drawing.Size(106, 36)
        Me.lblMainClientCaption.TabIndex = 0
        Me.lblMainClientCaption.Text = "Main client"
        Me.lblMainClientCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCompany
        '
        Me.cmbCompany.DisplayMember = "Name"
        Me.cmbCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(125, 13)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(372, 22)
        Me.cmbCompany.TabIndex = 1
        Me.cmbCompany.ValueMember = "Id"
        '
        'lblSubClientCaption
        '
        Me.lblSubClientCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSubClientCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSubClientCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblSubClientCaption.Location = New System.Drawing.Point(503, 10)
        Me.lblSubClientCaption.Name = "lblSubClientCaption"
        Me.lblSubClientCaption.Size = New System.Drawing.Size(112, 36)
        Me.lblSubClientCaption.TabIndex = 2
        Me.lblSubClientCaption.Text = "Sub-client"
        Me.lblSubClientCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbWorkSite
        '
        Me.cmbWorkSite.DisplayMember = "Name"
        Me.cmbWorkSite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbWorkSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWorkSite.FormattingEnabled = True
        Me.cmbWorkSite.Location = New System.Drawing.Point(621, 13)
        Me.cmbWorkSite.Name = "cmbWorkSite"
        Me.cmbWorkSite.Size = New System.Drawing.Size(496, 22)
        Me.cmbWorkSite.TabIndex = 3
        Me.cmbWorkSite.ValueMember = "Id"
        '
        'lblClientContext
        '
        Me.lblClientContext.AutoEllipsis = True
        Me.selectorLayout.SetColumnSpan(Me.lblClientContext, 2)
        Me.lblClientContext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClientContext.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblClientContext.Location = New System.Drawing.Point(13, 46)
        Me.lblClientContext.Name = "lblClientContext"
        Me.lblClientContext.Size = New System.Drawing.Size(484, 48)
        Me.lblClientContext.TabIndex = 4
        Me.lblClientContext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPolicySummary
        '
        Me.lblPolicySummary.AutoEllipsis = True
        Me.selectorLayout.SetColumnSpan(Me.lblPolicySummary, 2)
        Me.lblPolicySummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPolicySummary.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblPolicySummary.ForeColor = System.Drawing.Color.Teal
        Me.lblPolicySummary.Location = New System.Drawing.Point(503, 46)
        Me.lblPolicySummary.Name = "lblPolicySummary"
        Me.lblPolicySummary.Size = New System.Drawing.Size(614, 48)
        Me.lblPolicySummary.TabIndex = 5
        Me.lblPolicySummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'settingsTabs
        '
        Me.settingsTabs.Controls.Add(Me.tabEarningsMatrix)
        Me.settingsTabs.Controls.Add(Me.tabCalculationOptions)
        Me.settingsTabs.Controls.Add(Me.tabNotes)
        Me.settingsTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.settingsTabs.Location = New System.Drawing.Point(17, 189)
        Me.settingsTabs.Name = "settingsTabs"
        Me.settingsTabs.SelectedIndex = 0
        Me.settingsTabs.Size = New System.Drawing.Size(1130, 443)
        Me.settingsTabs.TabIndex = 2
        '
        'tabEarningsMatrix
        '
        Me.tabEarningsMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.tabEarningsMatrix.Controls.Add(Me.rulesGrid)
        Me.tabEarningsMatrix.Location = New System.Drawing.Point(4, 23)
        Me.tabEarningsMatrix.Name = "tabEarningsMatrix"
        Me.tabEarningsMatrix.Padding = New System.Windows.Forms.Padding(8)
        Me.tabEarningsMatrix.Size = New System.Drawing.Size(1122, 416)
        Me.tabEarningsMatrix.TabIndex = 0
        Me.tabEarningsMatrix.Text = "Premium matrix"
        '
        'rulesGrid
        '
        Me.rulesGrid.AllowUserToAddRows = False
        Me.rulesGrid.AllowUserToDeleteRows = False
        Me.rulesGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rulesGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.rulesGrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.rulesGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.rulesGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRuleName, Me.colEnabled, Me.colMultiplier, Me.colFormula})
        Me.rulesGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rulesGrid.EnableHeadersVisualStyles = False
        Me.rulesGrid.Location = New System.Drawing.Point(8, 8)
        Me.rulesGrid.MultiSelect = False
        Me.rulesGrid.Name = "rulesGrid"
        Me.rulesGrid.RowHeadersVisible = False
        Me.rulesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.rulesGrid.Size = New System.Drawing.Size(1106, 400)
        Me.rulesGrid.TabIndex = 0
        '
        'colRuleName
        '
        Me.colRuleName.HeaderText = "Universal payroll category"
        Me.colRuleName.Name = "colRuleName"
        Me.colRuleName.ReadOnly = True
        Me.colRuleName.Width = 350
        '
        'colEnabled
        '
        Me.colEnabled.HeaderText = "Pay"
        Me.colEnabled.Name = "colEnabled"
        Me.colEnabled.Width = 90
        '
        'colMultiplier
        '
        Me.colMultiplier.HeaderText = "Additional premium"
        Me.colMultiplier.Name = "colMultiplier"
        Me.colMultiplier.Width = 145
        '
        'colFormula
        '
        Me.colFormula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFormula.HeaderText = "Calculation"
        Me.colFormula.Name = "colFormula"
        Me.colFormula.ReadOnly = True
        '
        'tabCalculationOptions
        '
        Me.tabCalculationOptions.AutoScroll = True
        Me.tabCalculationOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.tabCalculationOptions.Controls.Add(Me.calculationLayout)
        Me.tabCalculationOptions.Location = New System.Drawing.Point(4, 23)
        Me.tabCalculationOptions.Name = "tabCalculationOptions"
        Me.tabCalculationOptions.Padding = New System.Windows.Forms.Padding(14)
        Me.tabCalculationOptions.Size = New System.Drawing.Size(192, 73)
        Me.tabCalculationOptions.TabIndex = 1
        Me.tabCalculationOptions.Text = "Schedule, ND && incentives"
        '
        'calculationLayout
        '
        Me.calculationLayout.AutoSize = True
        Me.calculationLayout.ColumnCount = 3
        Me.calculationLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290.0!))
        Me.calculationLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210.0!))
        Me.calculationLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.calculationLayout.Controls.Add(Me.lblHoursPerDayCaption, 0, 0)
        Me.calculationLayout.Controls.Add(Me.numHoursPerDay, 1, 0)
        Me.calculationLayout.Controls.Add(Me.lblHoursPerDayHelp, 2, 0)
        Me.calculationLayout.Controls.Add(Me.lblDutyEntryModeCaption, 0, 1)
        Me.calculationLayout.Controls.Add(Me.cmbDutyEntryMode, 1, 1)
        Me.calculationLayout.Controls.Add(Me.lblDutyEntryModeHelp, 2, 1)
        Me.calculationLayout.Controls.Add(Me.lblSingleShiftHoursCaption, 0, 2)
        Me.calculationLayout.Controls.Add(Me.numSingleShiftHours, 1, 2)
        Me.calculationLayout.Controls.Add(Me.lblSingleShiftHoursHelp, 2, 2)
        Me.calculationLayout.Controls.Add(Me.lblSingleShiftPeriodCaption, 0, 3)
        Me.calculationLayout.Controls.Add(Me.chkSingleShiftIsNight, 1, 3)
        Me.calculationLayout.Controls.Add(Me.lblSingleShiftPeriodHelp, 2, 3)
        Me.calculationLayout.Controls.Add(Me.lblNightDifferentialModeCaption, 0, 4)
        Me.calculationLayout.Controls.Add(Me.cmbNightDifferentialMode, 1, 4)
        Me.calculationLayout.Controls.Add(Me.lblNightDifferentialModeHelp, 2, 4)
        Me.calculationLayout.Controls.Add(Me.lblFixedNightDifferentialCaption, 0, 5)
        Me.calculationLayout.Controls.Add(Me.numNightDifferentialFixedAmount, 1, 5)
        Me.calculationLayout.Controls.Add(Me.lblFixedNightDifferentialHelp, 2, 5)
        Me.calculationLayout.Controls.Add(Me.lblIncentiveCaption, 0, 6)
        Me.calculationLayout.Controls.Add(Me.chkIncentive, 1, 6)
        Me.calculationLayout.Controls.Add(Me.lblIncentiveHelp, 2, 6)
        Me.calculationLayout.Controls.Add(Me.lblIncentiveDaysCaption, 0, 7)
        Me.calculationLayout.Controls.Add(Me.numIncentiveDays, 1, 7)
        Me.calculationLayout.Controls.Add(Me.lblIncentiveDaysHelp, 2, 7)
        Me.calculationLayout.Controls.Add(Me.lblIncentiveMonthDivisorCaption, 0, 8)
        Me.calculationLayout.Controls.Add(Me.numIncentiveMonthDivisor, 1, 8)
        Me.calculationLayout.Controls.Add(Me.lblIncentiveMonthDivisorHelp, 2, 8)
        Me.calculationLayout.Controls.Add(Me.lblIncentiveCutoffDivisorCaption, 0, 9)
        Me.calculationLayout.Controls.Add(Me.numIncentiveCutoffDivisor, 1, 9)
        Me.calculationLayout.Controls.Add(Me.lblIncentiveCutoffDivisorHelp, 2, 9)
        Me.calculationLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.calculationLayout.Location = New System.Drawing.Point(14, 14)
        Me.calculationLayout.Name = "calculationLayout"
        Me.calculationLayout.RowCount = 10
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationLayout.Size = New System.Drawing.Size(147, 480)
        Me.calculationLayout.TabIndex = 0
        '
        'lblHoursPerDayCaption
        '
        Me.lblHoursPerDayCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHoursPerDayCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblHoursPerDayCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblHoursPerDayCaption.Location = New System.Drawing.Point(3, 0)
        Me.lblHoursPerDayCaption.Name = "lblHoursPerDayCaption"
        Me.lblHoursPerDayCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblHoursPerDayCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblHoursPerDayCaption.TabIndex = 0
        Me.lblHoursPerDayCaption.Text = "Base hours per day"
        Me.lblHoursPerDayCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numHoursPerDay
        '
        Me.numHoursPerDay.DecimalPlaces = 2
        Me.numHoursPerDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numHoursPerDay.Location = New System.Drawing.Point(293, 3)
        Me.numHoursPerDay.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.numHoursPerDay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numHoursPerDay.Name = "numHoursPerDay"
        Me.numHoursPerDay.Size = New System.Drawing.Size(204, 22)
        Me.numHoursPerDay.TabIndex = 1
        Me.numHoursPerDay.ThousandsSeparator = True
        Me.numHoursPerDay.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'lblHoursPerDayHelp
        '
        Me.lblHoursPerDayHelp.AutoEllipsis = True
        Me.lblHoursPerDayHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHoursPerDayHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblHoursPerDayHelp.Location = New System.Drawing.Point(503, 0)
        Me.lblHoursPerDayHelp.Name = "lblHoursPerDayHelp"
        Me.lblHoursPerDayHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblHoursPerDayHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblHoursPerDayHelp.TabIndex = 2
        Me.lblHoursPerDayHelp.Text = "Universal sheet formulas use daily wage divided by this value."
        Me.lblHoursPerDayHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDutyEntryModeCaption
        '
        Me.lblDutyEntryModeCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDutyEntryModeCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblDutyEntryModeCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblDutyEntryModeCaption.Location = New System.Drawing.Point(3, 48)
        Me.lblDutyEntryModeCaption.Name = "lblDutyEntryModeCaption"
        Me.lblDutyEntryModeCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblDutyEntryModeCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblDutyEntryModeCaption.TabIndex = 3
        Me.lblDutyEntryModeCaption.Text = "Manual DTR duty mode"
        Me.lblDutyEntryModeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDutyEntryMode
        '
        Me.cmbDutyEntryMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbDutyEntryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDutyEntryMode.FormattingEnabled = True
        Me.cmbDutyEntryMode.Items.AddRange(New Object() {"Use client schedule", "One configured shift"})
        Me.cmbDutyEntryMode.Location = New System.Drawing.Point(293, 51)
        Me.cmbDutyEntryMode.Name = "cmbDutyEntryMode"
        Me.cmbDutyEntryMode.Size = New System.Drawing.Size(204, 22)
        Me.cmbDutyEntryMode.TabIndex = 4
        '
        'lblDutyEntryModeHelp
        '
        Me.lblDutyEntryModeHelp.AutoEllipsis = True
        Me.lblDutyEntryModeHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDutyEntryModeHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblDutyEntryModeHelp.Location = New System.Drawing.Point(503, 48)
        Me.lblDutyEntryModeHelp.Name = "lblDutyEntryModeHelp"
        Me.lblDutyEntryModeHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblDutyEntryModeHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblDutyEntryModeHelp.TabIndex = 5
        Me.lblDutyEntryModeHelp.Text = "One configured shift supports 9-hour and 10-hour clients from the attached matrix" &
    "."
        Me.lblDutyEntryModeHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSingleShiftHoursCaption
        '
        Me.lblSingleShiftHoursCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSingleShiftHoursCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSingleShiftHoursCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblSingleShiftHoursCaption.Location = New System.Drawing.Point(3, 96)
        Me.lblSingleShiftHoursCaption.Name = "lblSingleShiftHoursCaption"
        Me.lblSingleShiftHoursCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblSingleShiftHoursCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblSingleShiftHoursCaption.TabIndex = 6
        Me.lblSingleShiftHoursCaption.Text = "Configured shift hours"
        Me.lblSingleShiftHoursCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numSingleShiftHours
        '
        Me.numSingleShiftHours.DecimalPlaces = 2
        Me.numSingleShiftHours.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numSingleShiftHours.Location = New System.Drawing.Point(293, 99)
        Me.numSingleShiftHours.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.numSingleShiftHours.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSingleShiftHours.Name = "numSingleShiftHours"
        Me.numSingleShiftHours.Size = New System.Drawing.Size(204, 22)
        Me.numSingleShiftHours.TabIndex = 7
        Me.numSingleShiftHours.ThousandsSeparator = True
        Me.numSingleShiftHours.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'lblSingleShiftHoursHelp
        '
        Me.lblSingleShiftHoursHelp.AutoEllipsis = True
        Me.lblSingleShiftHoursHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSingleShiftHoursHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblSingleShiftHoursHelp.Location = New System.Drawing.Point(503, 96)
        Me.lblSingleShiftHoursHelp.Name = "lblSingleShiftHoursHelp"
        Me.lblSingleShiftHoursHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblSingleShiftHoursHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblSingleShiftHoursHelp.TabIndex = 8
        Me.lblSingleShiftHoursHelp.Text = "The first base hours are regular; succeeding hours are overtime."
        Me.lblSingleShiftHoursHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSingleShiftPeriodCaption
        '
        Me.lblSingleShiftPeriodCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSingleShiftPeriodCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSingleShiftPeriodCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblSingleShiftPeriodCaption.Location = New System.Drawing.Point(3, 144)
        Me.lblSingleShiftPeriodCaption.Name = "lblSingleShiftPeriodCaption"
        Me.lblSingleShiftPeriodCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblSingleShiftPeriodCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblSingleShiftPeriodCaption.TabIndex = 9
        Me.lblSingleShiftPeriodCaption.Text = "Configured shift period"
        Me.lblSingleShiftPeriodCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkSingleShiftIsNight
        '
        Me.chkSingleShiftIsNight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkSingleShiftIsNight.Location = New System.Drawing.Point(293, 147)
        Me.chkSingleShiftIsNight.Name = "chkSingleShiftIsNight"
        Me.chkSingleShiftIsNight.Size = New System.Drawing.Size(204, 42)
        Me.chkSingleShiftIsNight.TabIndex = 10
        Me.chkSingleShiftIsNight.Text = "Treat the configured shift as a night shift"
        Me.chkSingleShiftIsNight.UseVisualStyleBackColor = True
        '
        'lblSingleShiftPeriodHelp
        '
        Me.lblSingleShiftPeriodHelp.AutoEllipsis = True
        Me.lblSingleShiftPeriodHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSingleShiftPeriodHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblSingleShiftPeriodHelp.Location = New System.Drawing.Point(503, 144)
        Me.lblSingleShiftPeriodHelp.Name = "lblSingleShiftPeriodHelp"
        Me.lblSingleShiftPeriodHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblSingleShiftPeriodHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblSingleShiftPeriodHelp.TabIndex = 11
        Me.lblSingleShiftPeriodHelp.Text = "Enable this when the single duty should also produce night-differential hours."
        Me.lblSingleShiftPeriodHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNightDifferentialModeCaption
        '
        Me.lblNightDifferentialModeCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNightDifferentialModeCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblNightDifferentialModeCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblNightDifferentialModeCaption.Location = New System.Drawing.Point(3, 192)
        Me.lblNightDifferentialModeCaption.Name = "lblNightDifferentialModeCaption"
        Me.lblNightDifferentialModeCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblNightDifferentialModeCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblNightDifferentialModeCaption.TabIndex = 12
        Me.lblNightDifferentialModeCaption.Text = "How should night differential be paid?"
        Me.lblNightDifferentialModeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNightDifferentialMode
        '
        Me.cmbNightDifferentialMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbNightDifferentialMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNightDifferentialMode.FormattingEnabled = True
        Me.cmbNightDifferentialMode.Items.AddRange(New Object() {"Pay by ND hours", "Pay by ND days from a monthly amount", "Do not pay ND"})
        Me.cmbNightDifferentialMode.Location = New System.Drawing.Point(293, 195)
        Me.cmbNightDifferentialMode.Name = "cmbNightDifferentialMode"
        Me.cmbNightDifferentialMode.Size = New System.Drawing.Size(204, 22)
        Me.cmbNightDifferentialMode.TabIndex = 13
        '
        'lblNightDifferentialModeHelp
        '
        Me.lblNightDifferentialModeHelp.AutoEllipsis = True
        Me.lblNightDifferentialModeHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNightDifferentialModeHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblNightDifferentialModeHelp.Location = New System.Drawing.Point(503, 192)
        Me.lblNightDifferentialModeHelp.Name = "lblNightDifferentialModeHelp"
        Me.lblNightDifferentialModeHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblNightDifferentialModeHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblNightDifferentialModeHelp.TabIndex = 14
        Me.lblNightDifferentialModeHelp.Text = "Choose whether ND is based on recorded hours or selected reporting shifts."
        Me.lblNightDifferentialModeHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFixedNightDifferentialCaption
        '
        Me.lblFixedNightDifferentialCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFixedNightDifferentialCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblFixedNightDifferentialCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblFixedNightDifferentialCaption.Location = New System.Drawing.Point(3, 240)
        Me.lblFixedNightDifferentialCaption.Name = "lblFixedNightDifferentialCaption"
        Me.lblFixedNightDifferentialCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblFixedNightDifferentialCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblFixedNightDifferentialCaption.TabIndex = 15
        Me.lblFixedNightDifferentialCaption.Text = "Monthly ND amount (ND REG)"
        Me.lblFixedNightDifferentialCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numNightDifferentialFixedAmount
        '
        Me.numNightDifferentialFixedAmount.DecimalPlaces = 2
        Me.numNightDifferentialFixedAmount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numNightDifferentialFixedAmount.Location = New System.Drawing.Point(293, 243)
        Me.numNightDifferentialFixedAmount.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numNightDifferentialFixedAmount.Name = "numNightDifferentialFixedAmount"
        Me.numNightDifferentialFixedAmount.Size = New System.Drawing.Size(204, 22)
        Me.numNightDifferentialFixedAmount.TabIndex = 16
        Me.numNightDifferentialFixedAmount.ThousandsSeparator = True
        '
        'lblFixedNightDifferentialHelp
        '
        Me.lblFixedNightDifferentialHelp.AutoEllipsis = True
        Me.lblFixedNightDifferentialHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFixedNightDifferentialHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblFixedNightDifferentialHelp.Location = New System.Drawing.Point(503, 240)
        Me.lblFixedNightDifferentialHelp.Name = "lblFixedNightDifferentialHelp"
        Me.lblFixedNightDifferentialHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblFixedNightDifferentialHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblFixedNightDifferentialHelp.TabIndex = 17
        Me.lblFixedNightDifferentialHelp.Text = "Available when ND is paid by ND days. Enter the contracted monthly ND amount."
        Me.lblFixedNightDifferentialHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIncentiveCaption
        '
        Me.lblIncentiveCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblIncentiveCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblIncentiveCaption.Location = New System.Drawing.Point(3, 288)
        Me.lblIncentiveCaption.Name = "lblIncentiveCaption"
        Me.lblIncentiveCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblIncentiveCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblIncentiveCaption.TabIndex = 18
        Me.lblIncentiveCaption.Text = "Incentive"
        Me.lblIncentiveCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkIncentive
        '
        Me.chkIncentive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkIncentive.Location = New System.Drawing.Point(293, 291)
        Me.chkIncentive.Name = "chkIncentive"
        Me.chkIncentive.Size = New System.Drawing.Size(204, 42)
        Me.chkIncentive.TabIndex = 19
        Me.chkIncentive.Text = "Enable 5-day incentive pay"
        Me.chkIncentive.UseVisualStyleBackColor = True
        '
        'lblIncentiveHelp
        '
        Me.lblIncentiveHelp.AutoEllipsis = True
        Me.lblIncentiveHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblIncentiveHelp.Location = New System.Drawing.Point(503, 288)
        Me.lblIncentiveHelp.Name = "lblIncentiveHelp"
        Me.lblIncentiveHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblIncentiveHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblIncentiveHelp.TabIndex = 20
        Me.lblIncentiveHelp.Text = "Uses daily wage × incentive days / month divisor / cutoff divisor / cutoff days ×" &
    " reporting days."
        Me.lblIncentiveHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIncentiveDaysCaption
        '
        Me.lblIncentiveDaysCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveDaysCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblIncentiveDaysCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblIncentiveDaysCaption.Location = New System.Drawing.Point(3, 336)
        Me.lblIncentiveDaysCaption.Name = "lblIncentiveDaysCaption"
        Me.lblIncentiveDaysCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblIncentiveDaysCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblIncentiveDaysCaption.TabIndex = 21
        Me.lblIncentiveDaysCaption.Text = "Incentive days"
        Me.lblIncentiveDaysCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numIncentiveDays
        '
        Me.numIncentiveDays.DecimalPlaces = 2
        Me.numIncentiveDays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numIncentiveDays.Location = New System.Drawing.Point(293, 339)
        Me.numIncentiveDays.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.numIncentiveDays.Name = "numIncentiveDays"
        Me.numIncentiveDays.Size = New System.Drawing.Size(204, 22)
        Me.numIncentiveDays.TabIndex = 22
        Me.numIncentiveDays.ThousandsSeparator = True
        Me.numIncentiveDays.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lblIncentiveDaysHelp
        '
        Me.lblIncentiveDaysHelp.AutoEllipsis = True
        Me.lblIncentiveDaysHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveDaysHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblIncentiveDaysHelp.Location = New System.Drawing.Point(503, 336)
        Me.lblIncentiveDaysHelp.Name = "lblIncentiveDaysHelp"
        Me.lblIncentiveDaysHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblIncentiveDaysHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblIncentiveDaysHelp.TabIndex = 23
        Me.lblIncentiveDaysHelp.Text = "The attached matrix uses 5 days."
        Me.lblIncentiveDaysHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIncentiveMonthDivisorCaption
        '
        Me.lblIncentiveMonthDivisorCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveMonthDivisorCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblIncentiveMonthDivisorCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblIncentiveMonthDivisorCaption.Location = New System.Drawing.Point(3, 384)
        Me.lblIncentiveMonthDivisorCaption.Name = "lblIncentiveMonthDivisorCaption"
        Me.lblIncentiveMonthDivisorCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblIncentiveMonthDivisorCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblIncentiveMonthDivisorCaption.TabIndex = 24
        Me.lblIncentiveMonthDivisorCaption.Text = "Incentive month divisor"
        Me.lblIncentiveMonthDivisorCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numIncentiveMonthDivisor
        '
        Me.numIncentiveMonthDivisor.DecimalPlaces = 2
        Me.numIncentiveMonthDivisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numIncentiveMonthDivisor.Location = New System.Drawing.Point(293, 387)
        Me.numIncentiveMonthDivisor.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.numIncentiveMonthDivisor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numIncentiveMonthDivisor.Name = "numIncentiveMonthDivisor"
        Me.numIncentiveMonthDivisor.Size = New System.Drawing.Size(204, 22)
        Me.numIncentiveMonthDivisor.TabIndex = 25
        Me.numIncentiveMonthDivisor.ThousandsSeparator = True
        Me.numIncentiveMonthDivisor.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'lblIncentiveMonthDivisorHelp
        '
        Me.lblIncentiveMonthDivisorHelp.AutoEllipsis = True
        Me.lblIncentiveMonthDivisorHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveMonthDivisorHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblIncentiveMonthDivisorHelp.Location = New System.Drawing.Point(503, 384)
        Me.lblIncentiveMonthDivisorHelp.Name = "lblIncentiveMonthDivisorHelp"
        Me.lblIncentiveMonthDivisorHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblIncentiveMonthDivisorHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblIncentiveMonthDivisorHelp.TabIndex = 26
        Me.lblIncentiveMonthDivisorHelp.Text = "The attached matrix uses 12 months."
        Me.lblIncentiveMonthDivisorHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIncentiveCutoffDivisorCaption
        '
        Me.lblIncentiveCutoffDivisorCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveCutoffDivisorCaption.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblIncentiveCutoffDivisorCaption.ForeColor = System.Drawing.Color.Teal
        Me.lblIncentiveCutoffDivisorCaption.Location = New System.Drawing.Point(3, 432)
        Me.lblIncentiveCutoffDivisorCaption.Name = "lblIncentiveCutoffDivisorCaption"
        Me.lblIncentiveCutoffDivisorCaption.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.lblIncentiveCutoffDivisorCaption.Size = New System.Drawing.Size(284, 48)
        Me.lblIncentiveCutoffDivisorCaption.TabIndex = 27
        Me.lblIncentiveCutoffDivisorCaption.Text = "Incentive cutoff divisor"
        Me.lblIncentiveCutoffDivisorCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numIncentiveCutoffDivisor
        '
        Me.numIncentiveCutoffDivisor.DecimalPlaces = 2
        Me.numIncentiveCutoffDivisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numIncentiveCutoffDivisor.Location = New System.Drawing.Point(293, 435)
        Me.numIncentiveCutoffDivisor.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numIncentiveCutoffDivisor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numIncentiveCutoffDivisor.Name = "numIncentiveCutoffDivisor"
        Me.numIncentiveCutoffDivisor.Size = New System.Drawing.Size(204, 22)
        Me.numIncentiveCutoffDivisor.TabIndex = 28
        Me.numIncentiveCutoffDivisor.ThousandsSeparator = True
        Me.numIncentiveCutoffDivisor.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblIncentiveCutoffDivisorHelp
        '
        Me.lblIncentiveCutoffDivisorHelp.AutoEllipsis = True
        Me.lblIncentiveCutoffDivisorHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveCutoffDivisorHelp.ForeColor = System.Drawing.Color.DimGray
        Me.lblIncentiveCutoffDivisorHelp.Location = New System.Drawing.Point(503, 432)
        Me.lblIncentiveCutoffDivisorHelp.Name = "lblIncentiveCutoffDivisorHelp"
        Me.lblIncentiveCutoffDivisorHelp.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblIncentiveCutoffDivisorHelp.Size = New System.Drawing.Size(1, 48)
        Me.lblIncentiveCutoffDivisorHelp.TabIndex = 29
        Me.lblIncentiveCutoffDivisorHelp.Text = "The attached matrix uses 2 payroll cutoffs."
        Me.lblIncentiveCutoffDivisorHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabNotes
        '
        Me.tabNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.tabNotes.Controls.Add(Me.txtNotes)
        Me.tabNotes.Location = New System.Drawing.Point(4, 23)
        Me.tabNotes.Name = "tabNotes"
        Me.tabNotes.Padding = New System.Windows.Forms.Padding(12)
        Me.tabNotes.Size = New System.Drawing.Size(192, 73)
        Me.tabNotes.TabIndex = 2
        Me.tabNotes.Text = "Notes"
        '
        'txtNotes
        '
        Me.txtNotes.AcceptsReturn = True
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtNotes.Location = New System.Drawing.Point(12, 12)
        Me.txtNotes.MaxLength = 4000
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(168, 49)
        Me.txtNotes.TabIndex = 0
        '
        'lblStatus
        '
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(17, 635)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblStatus.Size = New System.Drawing.Size(1130, 38)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'actionsPanel
        '
        Me.actionsPanel.Controls.Add(Me.btnClose)
        Me.actionsPanel.Controls.Add(Me.btnSave)
        Me.actionsPanel.Controls.Add(Me.btnRestore)
        Me.actionsPanel.Controls.Add(Me.btnImport)
        Me.actionsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.actionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.actionsPanel.Location = New System.Drawing.Point(17, 676)
        Me.actionsPanel.Name = "actionsPanel"
        Me.actionsPanel.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.actionsPanel.Size = New System.Drawing.Size(1130, 48)
        Me.actionsPanel.TabIndex = 4
        Me.actionsPanel.WrapContents = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(1038, 8)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(92, 38)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Teal
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(910, 8)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 38)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save rules"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnRestore
        '
        Me.btnRestore.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnRestore.FlatAppearance.BorderSize = 0
        Me.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestore.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnRestore.Location = New System.Drawing.Point(760, 8)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(142, 38)
        Me.btnRestore.TabIndex = 2
        Me.btnRestore.Text = "Restore standard"
        Me.btnRestore.UseVisualStyleBackColor = False
        '
        'btnImport
        '
        Me.btnImport.BackColor = System.Drawing.Color.Maroon
        Me.btnImport.FlatAppearance.BorderSize = 0
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImport.ForeColor = System.Drawing.Color.White
        Me.btnImport.Location = New System.Drawing.Point(584, 8)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(168, 38)
        Me.btnImport.TabIndex = 3
        Me.btnImport.Text = "Import Excel rules..."
        Me.btnImport.UseVisualStyleBackColor = False
        '
        'openPayrollRulesDialog
        '
        Me.openPayrollRulesDialog.Filter = "Excel workbook (*.xlsx)|*.xlsx"
        Me.openPayrollRulesDialog.Title = "Select payroll-rule workbook"
        '
        'FRM_SUB_CLIENT_PAYROLL_SETTINGS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1164, 741)
        Me.Controls.Add(Me.rootLayout)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(1040, 700)
        Me.Name = "FRM_SUB_CLIENT_PAYROLL_SETTINGS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sub-client Payroll Rules"
        Me.rootLayout.ResumeLayout(False)
        Me.titlePanel.ResumeLayout(False)
        Me.selectorLayout.ResumeLayout(False)
        Me.settingsTabs.ResumeLayout(False)
        Me.tabEarningsMatrix.ResumeLayout(False)
        CType(Me.rulesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCalculationOptions.ResumeLayout(False)
        Me.tabCalculationOptions.PerformLayout()
        Me.calculationLayout.ResumeLayout(False)
        CType(Me.numHoursPerDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSingleShiftHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNightDifferentialFixedAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIncentiveDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIncentiveMonthDivisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIncentiveCutoffDivisor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabNotes.ResumeLayout(False)
        Me.tabNotes.PerformLayout()
        Me.actionsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rootLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents titlePanel As System.Windows.Forms.Panel
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents selectorLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMainClientCaption As System.Windows.Forms.Label
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents lblSubClientCaption As System.Windows.Forms.Label
    Friend WithEvents cmbWorkSite As System.Windows.Forms.ComboBox
    Friend WithEvents lblClientContext As System.Windows.Forms.Label
    Friend WithEvents lblPolicySummary As System.Windows.Forms.Label
    Friend WithEvents settingsTabs As System.Windows.Forms.TabControl
    Friend WithEvents tabEarningsMatrix As System.Windows.Forms.TabPage
    Friend WithEvents rulesGrid As System.Windows.Forms.DataGridView
    Friend WithEvents colRuleName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEnabled As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMultiplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFormula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabCalculationOptions As System.Windows.Forms.TabPage
    Friend WithEvents calculationLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblHoursPerDayCaption As System.Windows.Forms.Label
    Friend WithEvents numHoursPerDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHoursPerDayHelp As System.Windows.Forms.Label
    Friend WithEvents lblDutyEntryModeCaption As System.Windows.Forms.Label
    Friend WithEvents cmbDutyEntryMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblDutyEntryModeHelp As System.Windows.Forms.Label
    Friend WithEvents lblSingleShiftHoursCaption As System.Windows.Forms.Label
    Friend WithEvents numSingleShiftHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSingleShiftHoursHelp As System.Windows.Forms.Label
    Friend WithEvents lblSingleShiftPeriodCaption As System.Windows.Forms.Label
    Friend WithEvents chkSingleShiftIsNight As System.Windows.Forms.CheckBox
    Friend WithEvents lblSingleShiftPeriodHelp As System.Windows.Forms.Label
    Friend WithEvents lblNightDifferentialModeCaption As System.Windows.Forms.Label
    Friend WithEvents cmbNightDifferentialMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblNightDifferentialModeHelp As System.Windows.Forms.Label
    Friend WithEvents lblFixedNightDifferentialCaption As System.Windows.Forms.Label
    Friend WithEvents numNightDifferentialFixedAmount As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblFixedNightDifferentialHelp As System.Windows.Forms.Label
    Friend WithEvents lblIncentiveCaption As System.Windows.Forms.Label
    Friend WithEvents chkIncentive As System.Windows.Forms.CheckBox
    Friend WithEvents lblIncentiveHelp As System.Windows.Forms.Label
    Friend WithEvents lblIncentiveDaysCaption As System.Windows.Forms.Label
    Friend WithEvents numIncentiveDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblIncentiveDaysHelp As System.Windows.Forms.Label
    Friend WithEvents lblIncentiveMonthDivisorCaption As System.Windows.Forms.Label
    Friend WithEvents numIncentiveMonthDivisor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblIncentiveMonthDivisorHelp As System.Windows.Forms.Label
    Friend WithEvents lblIncentiveCutoffDivisorCaption As System.Windows.Forms.Label
    Friend WithEvents numIncentiveCutoffDivisor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblIncentiveCutoffDivisorHelp As System.Windows.Forms.Label
    Friend WithEvents tabNotes As System.Windows.Forms.TabPage
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents actionsPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents openPayrollRulesDialog As System.Windows.Forms.OpenFileDialog
End Class
