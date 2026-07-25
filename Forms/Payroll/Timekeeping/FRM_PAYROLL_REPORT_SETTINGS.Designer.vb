<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_PAYROLL_REPORT_SETTINGS
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
        Me.rootPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.headerLabel = New System.Windows.Forms.Label()
        Me.settingsTabs = New System.Windows.Forms.TabControl()
        Me.companyTab = New System.Windows.Forms.TabPage()
        Me.companyFields = New System.Windows.Forms.TableLayoutPanel()
        Me.calculationTab = New System.Windows.Forms.TabPage()
        Me.calculationFields = New System.Windows.Forms.TableLayoutPanel()
        Me.settingsPathLabel = New System.Windows.Forms.Label()
        Me.buttonsPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnRestoreDefaults = New System.Windows.Forms.Button()
        Me.lblCompanySection = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.helpCompanyName = New System.Windows.Forms.Label()
        Me.lblCompanyAddress = New System.Windows.Forms.Label()
        Me.txtCompanyAddress = New System.Windows.Forms.TextBox()
        Me.helpCompanyAddress = New System.Windows.Forms.Label()
        Me.lblCompanyPhone = New System.Windows.Forms.Label()
        Me.txtCompanyPhone = New System.Windows.Forms.TextBox()
        Me.helpCompanyPhone = New System.Windows.Forms.Label()
        Me.lblCompanyEmail = New System.Windows.Forms.Label()
        Me.txtCompanyEmail = New System.Windows.Forms.TextBox()
        Me.helpCompanyEmail = New System.Windows.Forms.Label()
        Me.lblPayrollSection = New System.Windows.Forms.Label()
        Me.lblPayrollPreparedName = New System.Windows.Forms.Label()
        Me.txtPayrollPreparedName = New System.Windows.Forms.TextBox()
        Me.helpPayrollPreparedName = New System.Windows.Forms.Label()
        Me.lblPayrollPreparedTitle = New System.Windows.Forms.Label()
        Me.txtPayrollPreparedTitle = New System.Windows.Forms.TextBox()
        Me.helpPayrollPreparedTitle = New System.Windows.Forms.Label()
        Me.lblPayrollApprovedName = New System.Windows.Forms.Label()
        Me.txtPayrollApprovedName = New System.Windows.Forms.TextBox()
        Me.helpPayrollApprovedName = New System.Windows.Forms.Label()
        Me.lblPayrollApprovedTitle = New System.Windows.Forms.Label()
        Me.txtPayrollApprovedTitle = New System.Windows.Forms.TextBox()
        Me.helpPayrollApprovedTitle = New System.Windows.Forms.Label()
        Me.lblDtrSection = New System.Windows.Forms.Label()
        Me.lblDtrPreparedName = New System.Windows.Forms.Label()
        Me.txtDtrPreparedName = New System.Windows.Forms.TextBox()
        Me.helpDtrPreparedName = New System.Windows.Forms.Label()
        Me.lblDtrPreparedTitle = New System.Windows.Forms.Label()
        Me.txtDtrPreparedTitle = New System.Windows.Forms.TextBox()
        Me.helpDtrPreparedTitle = New System.Windows.Forms.Label()
        Me.lblDtrCheckedName = New System.Windows.Forms.Label()
        Me.txtDtrCheckedName = New System.Windows.Forms.TextBox()
        Me.helpDtrCheckedName = New System.Windows.Forms.Label()
        Me.lblDtrCheckedTitle = New System.Windows.Forms.Label()
        Me.txtDtrCheckedTitle = New System.Windows.Forms.TextBox()
        Me.helpDtrCheckedTitle = New System.Windows.Forms.Label()
        Me.lblDtrNotedName = New System.Windows.Forms.Label()
        Me.txtDtrNotedName = New System.Windows.Forms.TextBox()
        Me.helpDtrNotedName = New System.Windows.Forms.Label()
        Me.lblDtrNotedTitle = New System.Windows.Forms.Label()
        Me.txtDtrNotedTitle = New System.Windows.Forms.TextBox()
        Me.helpDtrNotedTitle = New System.Windows.Forms.Label()
        Me.lblHoursPerDay = New System.Windows.Forms.Label()
        Me.numHoursPerDay = New System.Windows.Forms.NumericUpDown()
        Me.helpHoursPerDay = New System.Windows.Forms.Label()
        Me.lblSundayMultiplier = New System.Windows.Forms.Label()
        Me.numSundayMultiplier = New System.Windows.Forms.NumericUpDown()
        Me.helpSundayMultiplier = New System.Windows.Forms.Label()
        Me.lblSpecialHolidayMultiplier = New System.Windows.Forms.Label()
        Me.numSpecialHolidayMultiplier = New System.Windows.Forms.NumericUpDown()
        Me.helpSpecialHolidayMultiplier = New System.Windows.Forms.Label()
        Me.lblLegalHolidayMultiplier = New System.Windows.Forms.Label()
        Me.numLegalHolidayMultiplier = New System.Windows.Forms.NumericUpDown()
        Me.helpLegalHolidayMultiplier = New System.Windows.Forms.Label()
        Me.lblOvertimeHourlyRate = New System.Windows.Forms.Label()
        Me.numOvertimeHourlyRate = New System.Windows.Forms.NumericUpDown()
        Me.helpOvertimeHourlyRate = New System.Windows.Forms.Label()
        Me.lblServiceIncentiveDays = New System.Windows.Forms.Label()
        Me.numServiceIncentiveDays = New System.Windows.Forms.NumericUpDown()
        Me.helpServiceIncentiveDays = New System.Windows.Forms.Label()
        Me.lblIncentiveMonthsDivisor = New System.Windows.Forms.Label()
        Me.numIncentiveMonthsDivisor = New System.Windows.Forms.NumericUpDown()
        Me.helpIncentiveMonthsDivisor = New System.Windows.Forms.Label()
        Me.lblIncentiveDaysDivisor = New System.Windows.Forms.Label()
        Me.numIncentiveDaysDivisor = New System.Windows.Forms.NumericUpDown()
        Me.helpIncentiveDaysDivisor = New System.Windows.Forms.Label()
        Me.rootPanel.SuspendLayout()
        Me.settingsTabs.SuspendLayout()
        Me.companyTab.SuspendLayout()
        Me.companyFields.SuspendLayout()
        Me.calculationTab.SuspendLayout()
        Me.calculationFields.SuspendLayout()
        Me.buttonsPanel.SuspendLayout()
        CType(Me.numHoursPerDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSundayMultiplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSpecialHolidayMultiplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLegalHolidayMultiplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOvertimeHourlyRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numServiceIncentiveDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIncentiveMonthsDivisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIncentiveDaysDivisor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rootPanel
        '
        Me.rootPanel.ColumnCount = 1
        Me.rootPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.Controls.Add(Me.headerLabel, 0, 0)
        Me.rootPanel.Controls.Add(Me.settingsTabs, 0, 1)
        Me.rootPanel.Controls.Add(Me.settingsPathLabel, 0, 2)
        Me.rootPanel.Controls.Add(Me.buttonsPanel, 0, 3)
        Me.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootPanel.Name = "rootPanel"
        Me.rootPanel.Padding = New System.Windows.Forms.Padding(18)
        Me.rootPanel.RowCount = 4
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.rootPanel.TabIndex = 0
        '
        'headerLabel
        '
        Me.headerLabel.BackColor = System.Drawing.Color.Teal
        Me.headerLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.headerLabel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.headerLabel.ForeColor = System.Drawing.Color.White
        Me.headerLabel.Name = "headerLabel"
        Me.headerLabel.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.headerLabel.TabIndex = 0
        Me.headerLabel.Text = "PAYROLL & REPORT SETTINGS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Company identity, signatories, and calculation rules used in generated workbooks."
        Me.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.headerLabel.UseMnemonic = False
        '
        'settingsTabs
        '
        Me.settingsTabs.Controls.Add(Me.companyTab)
        Me.settingsTabs.Controls.Add(Me.calculationTab)
        Me.settingsTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.settingsTabs.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.settingsTabs.Name = "settingsTabs"
        Me.settingsTabs.Padding = New System.Drawing.Point(14, 6)
        Me.settingsTabs.SelectedIndex = 0
        Me.settingsTabs.TabIndex = 1
        '
        'companyTab
        '
        Me.companyTab.AutoScroll = True
        Me.companyTab.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.companyTab.Controls.Add(Me.companyFields)
        Me.companyTab.Name = "companyTab"
        Me.companyTab.Padding = New System.Windows.Forms.Padding(8)
        Me.companyTab.Text = "Company & signatories"
        '
        'companyFields
        '
        Me.companyFields.AutoScroll = True
        Me.companyFields.ColumnCount = 3
        Me.companyFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.companyFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330.0!))
        Me.companyFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.companyFields.Controls.Add(Me.lblCompanySection, 0, 0)
        Me.companyFields.SetColumnSpan(Me.lblCompanySection, 3)
        Me.companyFields.Controls.Add(Me.lblCompanyName, 0, 1)
        Me.companyFields.Controls.Add(Me.txtCompanyName, 1, 1)
        Me.companyFields.Controls.Add(Me.helpCompanyName, 2, 1)
        Me.companyFields.Controls.Add(Me.lblCompanyAddress, 0, 2)
        Me.companyFields.Controls.Add(Me.txtCompanyAddress, 1, 2)
        Me.companyFields.Controls.Add(Me.helpCompanyAddress, 2, 2)
        Me.companyFields.Controls.Add(Me.lblCompanyPhone, 0, 3)
        Me.companyFields.Controls.Add(Me.txtCompanyPhone, 1, 3)
        Me.companyFields.Controls.Add(Me.helpCompanyPhone, 2, 3)
        Me.companyFields.Controls.Add(Me.lblCompanyEmail, 0, 4)
        Me.companyFields.Controls.Add(Me.txtCompanyEmail, 1, 4)
        Me.companyFields.Controls.Add(Me.helpCompanyEmail, 2, 4)
        Me.companyFields.Controls.Add(Me.lblPayrollSection, 0, 5)
        Me.companyFields.SetColumnSpan(Me.lblPayrollSection, 3)
        Me.companyFields.Controls.Add(Me.lblPayrollPreparedName, 0, 6)
        Me.companyFields.Controls.Add(Me.txtPayrollPreparedName, 1, 6)
        Me.companyFields.Controls.Add(Me.helpPayrollPreparedName, 2, 6)
        Me.companyFields.Controls.Add(Me.lblPayrollPreparedTitle, 0, 7)
        Me.companyFields.Controls.Add(Me.txtPayrollPreparedTitle, 1, 7)
        Me.companyFields.Controls.Add(Me.helpPayrollPreparedTitle, 2, 7)
        Me.companyFields.Controls.Add(Me.lblPayrollApprovedName, 0, 8)
        Me.companyFields.Controls.Add(Me.txtPayrollApprovedName, 1, 8)
        Me.companyFields.Controls.Add(Me.helpPayrollApprovedName, 2, 8)
        Me.companyFields.Controls.Add(Me.lblPayrollApprovedTitle, 0, 9)
        Me.companyFields.Controls.Add(Me.txtPayrollApprovedTitle, 1, 9)
        Me.companyFields.Controls.Add(Me.helpPayrollApprovedTitle, 2, 9)
        Me.companyFields.Controls.Add(Me.lblDtrSection, 0, 10)
        Me.companyFields.SetColumnSpan(Me.lblDtrSection, 3)
        Me.companyFields.Controls.Add(Me.lblDtrPreparedName, 0, 11)
        Me.companyFields.Controls.Add(Me.txtDtrPreparedName, 1, 11)
        Me.companyFields.Controls.Add(Me.helpDtrPreparedName, 2, 11)
        Me.companyFields.Controls.Add(Me.lblDtrPreparedTitle, 0, 12)
        Me.companyFields.Controls.Add(Me.txtDtrPreparedTitle, 1, 12)
        Me.companyFields.Controls.Add(Me.helpDtrPreparedTitle, 2, 12)
        Me.companyFields.Controls.Add(Me.lblDtrCheckedName, 0, 13)
        Me.companyFields.Controls.Add(Me.txtDtrCheckedName, 1, 13)
        Me.companyFields.Controls.Add(Me.helpDtrCheckedName, 2, 13)
        Me.companyFields.Controls.Add(Me.lblDtrCheckedTitle, 0, 14)
        Me.companyFields.Controls.Add(Me.txtDtrCheckedTitle, 1, 14)
        Me.companyFields.Controls.Add(Me.helpDtrCheckedTitle, 2, 14)
        Me.companyFields.Controls.Add(Me.lblDtrNotedName, 0, 15)
        Me.companyFields.Controls.Add(Me.txtDtrNotedName, 1, 15)
        Me.companyFields.Controls.Add(Me.helpDtrNotedName, 2, 15)
        Me.companyFields.Controls.Add(Me.lblDtrNotedTitle, 0, 16)
        Me.companyFields.Controls.Add(Me.txtDtrNotedTitle, 1, 16)
        Me.companyFields.Controls.Add(Me.helpDtrNotedTitle, 2, 16)
        Me.companyFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.companyFields.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.companyFields.Name = "companyFields"
        Me.companyFields.Padding = New System.Windows.Forms.Padding(4, 8, 4, 8)
        Me.companyFields.RowCount = 17
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.companyFields.TabIndex = 0
        '
        'lblCompanySection
        '
        Me.lblCompanySection.BackColor = System.Drawing.Color.FromArgb(222, 245, 235)
        Me.lblCompanySection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCompanySection.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanySection.ForeColor = System.Drawing.Color.Teal
        Me.lblCompanySection.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblCompanySection.Name = "lblCompanySection"
        Me.lblCompanySection.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblCompanySection.TabIndex = 0
        Me.lblCompanySection.Text = "COMPANY INFORMATION"
        Me.lblCompanySection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCompanyName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.TabIndex = 1
        Me.lblCompanyName.Text = "Company name"
        Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCompanyName.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.TabIndex = 2
        '
        'helpCompanyName
        '
        Me.helpCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpCompanyName.ForeColor = System.Drawing.Color.DimGray
        Me.helpCompanyName.Name = "helpCompanyName"
        Me.helpCompanyName.TabIndex = 3
        Me.helpCompanyName.Text = "Header on payroll, payslips, and DTR Hours."
        Me.helpCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompanyAddress
        '
        Me.lblCompanyAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCompanyAddress.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyAddress.Name = "lblCompanyAddress"
        Me.lblCompanyAddress.TabIndex = 4
        Me.lblCompanyAddress.Text = "Address"
        Me.lblCompanyAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompanyAddress
        '
        Me.txtCompanyAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCompanyAddress.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtCompanyAddress.Name = "txtCompanyAddress"
        Me.txtCompanyAddress.TabIndex = 5
        '
        'helpCompanyAddress
        '
        Me.helpCompanyAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpCompanyAddress.ForeColor = System.Drawing.Color.DimGray
        Me.helpCompanyAddress.Name = "helpCompanyAddress"
        Me.helpCompanyAddress.TabIndex = 6
        Me.helpCompanyAddress.Text = "Company address shown below the report title."
        Me.helpCompanyAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompanyPhone
        '
        Me.lblCompanyPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCompanyPhone.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyPhone.Name = "lblCompanyPhone"
        Me.lblCompanyPhone.TabIndex = 7
        Me.lblCompanyPhone.Text = "Telephone / mobile"
        Me.lblCompanyPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompanyPhone
        '
        Me.txtCompanyPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCompanyPhone.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtCompanyPhone.Name = "txtCompanyPhone"
        Me.txtCompanyPhone.TabIndex = 8
        '
        'helpCompanyPhone
        '
        Me.helpCompanyPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpCompanyPhone.ForeColor = System.Drawing.Color.DimGray
        Me.helpCompanyPhone.Name = "helpCompanyPhone"
        Me.helpCompanyPhone.TabIndex = 9
        Me.helpCompanyPhone.Text = "Do not include the Tel. prefix."
        Me.helpCompanyPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompanyEmail
        '
        Me.lblCompanyEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCompanyEmail.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyEmail.Name = "lblCompanyEmail"
        Me.lblCompanyEmail.TabIndex = 10
        Me.lblCompanyEmail.Text = "Email address"
        Me.lblCompanyEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompanyEmail
        '
        Me.txtCompanyEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCompanyEmail.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtCompanyEmail.Name = "txtCompanyEmail"
        Me.txtCompanyEmail.TabIndex = 11
        '
        'helpCompanyEmail
        '
        Me.helpCompanyEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpCompanyEmail.ForeColor = System.Drawing.Color.DimGray
        Me.helpCompanyEmail.Name = "helpCompanyEmail"
        Me.helpCompanyEmail.TabIndex = 12
        Me.helpCompanyEmail.Text = "Do not include the Email: prefix."
        Me.helpCompanyEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollSection
        '
        Me.lblPayrollSection.BackColor = System.Drawing.Color.FromArgb(222, 245, 235)
        Me.lblPayrollSection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPayrollSection.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPayrollSection.ForeColor = System.Drawing.Color.Teal
        Me.lblPayrollSection.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblPayrollSection.Name = "lblPayrollSection"
        Me.lblPayrollSection.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblPayrollSection.TabIndex = 13
        Me.lblPayrollSection.Text = "PAYROLL SIGNATORIES"
        Me.lblPayrollSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollPreparedName
        '
        Me.lblPayrollPreparedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPayrollPreparedName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPayrollPreparedName.Name = "lblPayrollPreparedName"
        Me.lblPayrollPreparedName.TabIndex = 14
        Me.lblPayrollPreparedName.Text = "Prepared by - name"
        Me.lblPayrollPreparedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollPreparedName
        '
        Me.txtPayrollPreparedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayrollPreparedName.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtPayrollPreparedName.Name = "txtPayrollPreparedName"
        Me.txtPayrollPreparedName.TabIndex = 15
        '
        'helpPayrollPreparedName
        '
        Me.helpPayrollPreparedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpPayrollPreparedName.ForeColor = System.Drawing.Color.DimGray
        Me.helpPayrollPreparedName.Name = "helpPayrollPreparedName"
        Me.helpPayrollPreparedName.TabIndex = 16
        Me.helpPayrollPreparedName.Text = "Printed below the payroll table."
        Me.helpPayrollPreparedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollPreparedTitle
        '
        Me.lblPayrollPreparedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPayrollPreparedTitle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPayrollPreparedTitle.Name = "lblPayrollPreparedTitle"
        Me.lblPayrollPreparedTitle.TabIndex = 17
        Me.lblPayrollPreparedTitle.Text = "Prepared by - title"
        Me.lblPayrollPreparedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollPreparedTitle
        '
        Me.txtPayrollPreparedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayrollPreparedTitle.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtPayrollPreparedTitle.Name = "txtPayrollPreparedTitle"
        Me.txtPayrollPreparedTitle.TabIndex = 18
        '
        'helpPayrollPreparedTitle
        '
        Me.helpPayrollPreparedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpPayrollPreparedTitle.ForeColor = System.Drawing.Color.DimGray
        Me.helpPayrollPreparedTitle.Name = "helpPayrollPreparedTitle"
        Me.helpPayrollPreparedTitle.TabIndex = 19
        Me.helpPayrollPreparedTitle.Text = "Example: Finance Staff."
        Me.helpPayrollPreparedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollApprovedName
        '
        Me.lblPayrollApprovedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPayrollApprovedName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPayrollApprovedName.Name = "lblPayrollApprovedName"
        Me.lblPayrollApprovedName.TabIndex = 20
        Me.lblPayrollApprovedName.Text = "Approved by - name"
        Me.lblPayrollApprovedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollApprovedName
        '
        Me.txtPayrollApprovedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayrollApprovedName.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtPayrollApprovedName.Name = "txtPayrollApprovedName"
        Me.txtPayrollApprovedName.TabIndex = 21
        '
        'helpPayrollApprovedName
        '
        Me.helpPayrollApprovedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpPayrollApprovedName.ForeColor = System.Drawing.Color.DimGray
        Me.helpPayrollApprovedName.Name = "helpPayrollApprovedName"
        Me.helpPayrollApprovedName.TabIndex = 22
        Me.helpPayrollApprovedName.Text = "Printed under Approved for payment."
        Me.helpPayrollApprovedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollApprovedTitle
        '
        Me.lblPayrollApprovedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPayrollApprovedTitle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPayrollApprovedTitle.Name = "lblPayrollApprovedTitle"
        Me.lblPayrollApprovedTitle.TabIndex = 23
        Me.lblPayrollApprovedTitle.Text = "Approved by - title"
        Me.lblPayrollApprovedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollApprovedTitle
        '
        Me.txtPayrollApprovedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayrollApprovedTitle.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtPayrollApprovedTitle.Name = "txtPayrollApprovedTitle"
        Me.txtPayrollApprovedTitle.TabIndex = 24
        '
        'helpPayrollApprovedTitle
        '
        Me.helpPayrollApprovedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpPayrollApprovedTitle.ForeColor = System.Drawing.Color.DimGray
        Me.helpPayrollApprovedTitle.Name = "helpPayrollApprovedTitle"
        Me.helpPayrollApprovedTitle.TabIndex = 25
        Me.helpPayrollApprovedTitle.Text = "Example: Security Director."
        Me.helpPayrollApprovedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDtrSection
        '
        Me.lblDtrSection.BackColor = System.Drawing.Color.FromArgb(222, 245, 235)
        Me.lblDtrSection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDtrSection.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDtrSection.ForeColor = System.Drawing.Color.Teal
        Me.lblDtrSection.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblDtrSection.Name = "lblDtrSection"
        Me.lblDtrSection.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblDtrSection.TabIndex = 26
        Me.lblDtrSection.Text = "DTR HOURS SIGNATORIES"
        Me.lblDtrSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDtrPreparedName
        '
        Me.lblDtrPreparedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDtrPreparedName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDtrPreparedName.Name = "lblDtrPreparedName"
        Me.lblDtrPreparedName.TabIndex = 27
        Me.lblDtrPreparedName.Text = "Prepared by - name"
        Me.lblDtrPreparedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDtrPreparedName
        '
        Me.txtDtrPreparedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDtrPreparedName.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtDtrPreparedName.Name = "txtDtrPreparedName"
        Me.txtDtrPreparedName.TabIndex = 28
        '
        'helpDtrPreparedName
        '
        Me.helpDtrPreparedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpDtrPreparedName.ForeColor = System.Drawing.Color.DimGray
        Me.helpDtrPreparedName.Name = "helpDtrPreparedName"
        Me.helpDtrPreparedName.TabIndex = 29
        Me.helpDtrPreparedName.Text = "First signature block on DTR Hours."
        Me.helpDtrPreparedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDtrPreparedTitle
        '
        Me.lblDtrPreparedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDtrPreparedTitle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDtrPreparedTitle.Name = "lblDtrPreparedTitle"
        Me.lblDtrPreparedTitle.TabIndex = 30
        Me.lblDtrPreparedTitle.Text = "Prepared by - title"
        Me.lblDtrPreparedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDtrPreparedTitle
        '
        Me.txtDtrPreparedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDtrPreparedTitle.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtDtrPreparedTitle.Name = "txtDtrPreparedTitle"
        Me.txtDtrPreparedTitle.TabIndex = 31
        '
        'helpDtrPreparedTitle
        '
        Me.helpDtrPreparedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpDtrPreparedTitle.ForeColor = System.Drawing.Color.DimGray
        Me.helpDtrPreparedTitle.Name = "helpDtrPreparedTitle"
        Me.helpDtrPreparedTitle.TabIndex = 32
        Me.helpDtrPreparedTitle.Text = "Example: Accounting Staff."
        Me.helpDtrPreparedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDtrCheckedName
        '
        Me.lblDtrCheckedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDtrCheckedName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDtrCheckedName.Name = "lblDtrCheckedName"
        Me.lblDtrCheckedName.TabIndex = 33
        Me.lblDtrCheckedName.Text = "Checked by - name"
        Me.lblDtrCheckedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDtrCheckedName
        '
        Me.txtDtrCheckedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDtrCheckedName.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtDtrCheckedName.Name = "txtDtrCheckedName"
        Me.txtDtrCheckedName.TabIndex = 34
        '
        'helpDtrCheckedName
        '
        Me.helpDtrCheckedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpDtrCheckedName.ForeColor = System.Drawing.Color.DimGray
        Me.helpDtrCheckedName.Name = "helpDtrCheckedName"
        Me.helpDtrCheckedName.TabIndex = 35
        Me.helpDtrCheckedName.Text = "Middle signature block on DTR Hours."
        Me.helpDtrCheckedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDtrCheckedTitle
        '
        Me.lblDtrCheckedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDtrCheckedTitle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDtrCheckedTitle.Name = "lblDtrCheckedTitle"
        Me.lblDtrCheckedTitle.TabIndex = 36
        Me.lblDtrCheckedTitle.Text = "Checked by - title"
        Me.lblDtrCheckedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDtrCheckedTitle
        '
        Me.txtDtrCheckedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDtrCheckedTitle.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtDtrCheckedTitle.Name = "txtDtrCheckedTitle"
        Me.txtDtrCheckedTitle.TabIndex = 37
        '
        'helpDtrCheckedTitle
        '
        Me.helpDtrCheckedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpDtrCheckedTitle.ForeColor = System.Drawing.Color.DimGray
        Me.helpDtrCheckedTitle.Name = "helpDtrCheckedTitle"
        Me.helpDtrCheckedTitle.TabIndex = 38
        Me.helpDtrCheckedTitle.Text = "Example: Finance Officer."
        Me.helpDtrCheckedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDtrNotedName
        '
        Me.lblDtrNotedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDtrNotedName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDtrNotedName.Name = "lblDtrNotedName"
        Me.lblDtrNotedName.TabIndex = 39
        Me.lblDtrNotedName.Text = "Noted by - name"
        Me.lblDtrNotedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDtrNotedName
        '
        Me.txtDtrNotedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDtrNotedName.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtDtrNotedName.Name = "txtDtrNotedName"
        Me.txtDtrNotedName.TabIndex = 40
        '
        'helpDtrNotedName
        '
        Me.helpDtrNotedName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpDtrNotedName.ForeColor = System.Drawing.Color.DimGray
        Me.helpDtrNotedName.Name = "helpDtrNotedName"
        Me.helpDtrNotedName.TabIndex = 41
        Me.helpDtrNotedName.Text = "Final signature block on DTR Hours."
        Me.helpDtrNotedName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDtrNotedTitle
        '
        Me.lblDtrNotedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDtrNotedTitle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDtrNotedTitle.Name = "lblDtrNotedTitle"
        Me.lblDtrNotedTitle.TabIndex = 42
        Me.lblDtrNotedTitle.Text = "Noted by - title"
        Me.lblDtrNotedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDtrNotedTitle
        '
        Me.txtDtrNotedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDtrNotedTitle.Margin = New System.Windows.Forms.Padding(4, 8, 12, 8)
        Me.txtDtrNotedTitle.Name = "txtDtrNotedTitle"
        Me.txtDtrNotedTitle.TabIndex = 43
        '
        'helpDtrNotedTitle
        '
        Me.helpDtrNotedTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpDtrNotedTitle.ForeColor = System.Drawing.Color.DimGray
        Me.helpDtrNotedTitle.Name = "helpDtrNotedTitle"
        Me.helpDtrNotedTitle.TabIndex = 44
        Me.helpDtrNotedTitle.Text = "Example: Security Director."
        Me.helpDtrNotedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'calculationTab
        '
        Me.calculationTab.AutoScroll = True
        Me.calculationTab.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.calculationTab.Controls.Add(Me.calculationFields)
        Me.calculationTab.Name = "calculationTab"
        Me.calculationTab.Padding = New System.Windows.Forms.Padding(8)
        Me.calculationTab.Text = "Calculation rules"
        '
        'calculationFields
        '
        Me.calculationFields.AutoScroll = True
        Me.calculationFields.ColumnCount = 3
        Me.calculationFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235.0!))
        Me.calculationFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.calculationFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.calculationFields.Controls.Add(Me.lblHoursPerDay, 0, 0)
        Me.calculationFields.Controls.Add(Me.numHoursPerDay, 1, 0)
        Me.calculationFields.Controls.Add(Me.helpHoursPerDay, 2, 0)
        Me.calculationFields.Controls.Add(Me.lblSundayMultiplier, 0, 1)
        Me.calculationFields.Controls.Add(Me.numSundayMultiplier, 1, 1)
        Me.calculationFields.Controls.Add(Me.helpSundayMultiplier, 2, 1)
        Me.calculationFields.Controls.Add(Me.lblSpecialHolidayMultiplier, 0, 2)
        Me.calculationFields.Controls.Add(Me.numSpecialHolidayMultiplier, 1, 2)
        Me.calculationFields.Controls.Add(Me.helpSpecialHolidayMultiplier, 2, 2)
        Me.calculationFields.Controls.Add(Me.lblLegalHolidayMultiplier, 0, 3)
        Me.calculationFields.Controls.Add(Me.numLegalHolidayMultiplier, 1, 3)
        Me.calculationFields.Controls.Add(Me.helpLegalHolidayMultiplier, 2, 3)
        Me.calculationFields.Controls.Add(Me.lblOvertimeHourlyRate, 0, 4)
        Me.calculationFields.Controls.Add(Me.numOvertimeHourlyRate, 1, 4)
        Me.calculationFields.Controls.Add(Me.helpOvertimeHourlyRate, 2, 4)
        Me.calculationFields.Controls.Add(Me.lblServiceIncentiveDays, 0, 5)
        Me.calculationFields.Controls.Add(Me.numServiceIncentiveDays, 1, 5)
        Me.calculationFields.Controls.Add(Me.helpServiceIncentiveDays, 2, 5)
        Me.calculationFields.Controls.Add(Me.lblIncentiveMonthsDivisor, 0, 6)
        Me.calculationFields.Controls.Add(Me.numIncentiveMonthsDivisor, 1, 6)
        Me.calculationFields.Controls.Add(Me.helpIncentiveMonthsDivisor, 2, 6)
        Me.calculationFields.Controls.Add(Me.lblIncentiveDaysDivisor, 0, 7)
        Me.calculationFields.Controls.Add(Me.numIncentiveDaysDivisor, 1, 7)
        Me.calculationFields.Controls.Add(Me.helpIncentiveDaysDivisor, 2, 7)
        Me.calculationFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.calculationFields.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.calculationFields.Name = "calculationFields"
        Me.calculationFields.Padding = New System.Windows.Forms.Padding(4, 12, 4, 4)
        Me.calculationFields.RowCount = 9
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.calculationFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.calculationFields.TabIndex = 0
        '
        'lblHoursPerDay
        '
        Me.lblHoursPerDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHoursPerDay.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblHoursPerDay.Name = "lblHoursPerDay"
        Me.lblHoursPerDay.TabIndex = 0
        Me.lblHoursPerDay.Text = "Hours per day"
        Me.lblHoursPerDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numHoursPerDay
        '
        Me.numHoursPerDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numHoursPerDay.DecimalPlaces = 2
        Me.numHoursPerDay.Margin = New System.Windows.Forms.Padding(4, 0, 12, 0)
        Me.numHoursPerDay.Maximum = 1000000D
        Me.numHoursPerDay.Name = "numHoursPerDay"
        Me.numHoursPerDay.TabIndex = 1
        Me.numHoursPerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numHoursPerDay.ThousandsSeparator = True
        '
        'helpHoursPerDay
        '
        Me.helpHoursPerDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpHoursPerDay.ForeColor = System.Drawing.Color.DimGray
        Me.helpHoursPerDay.Name = "helpHoursPerDay"
        Me.helpHoursPerDay.TabIndex = 2
        Me.helpHoursPerDay.Text = "Regular hourly rate = daily wage / hours per day."
        Me.helpHoursPerDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSundayMultiplier
        '
        Me.lblSundayMultiplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSundayMultiplier.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSundayMultiplier.Name = "lblSundayMultiplier"
        Me.lblSundayMultiplier.TabIndex = 3
        Me.lblSundayMultiplier.Text = "Sunday multiplier"
        Me.lblSundayMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numSundayMultiplier
        '
        Me.numSundayMultiplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numSundayMultiplier.DecimalPlaces = 4
        Me.numSundayMultiplier.Margin = New System.Windows.Forms.Padding(4, 0, 12, 0)
        Me.numSundayMultiplier.Maximum = 1000000D
        Me.numSundayMultiplier.Name = "numSundayMultiplier"
        Me.numSundayMultiplier.TabIndex = 4
        Me.numSundayMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numSundayMultiplier.ThousandsSeparator = True
        '
        'helpSundayMultiplier
        '
        Me.helpSundayMultiplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpSundayMultiplier.ForeColor = System.Drawing.Color.DimGray
        Me.helpSundayMultiplier.Name = "helpSundayMultiplier"
        Me.helpSundayMultiplier.TabIndex = 5
        Me.helpSundayMultiplier.Text = "Applied to Sunday hours (existing template: 1.30)."
        Me.helpSundayMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSpecialHolidayMultiplier
        '
        Me.lblSpecialHolidayMultiplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSpecialHolidayMultiplier.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSpecialHolidayMultiplier.Name = "lblSpecialHolidayMultiplier"
        Me.lblSpecialHolidayMultiplier.TabIndex = 6
        Me.lblSpecialHolidayMultiplier.Text = "Special holiday multiplier"
        Me.lblSpecialHolidayMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numSpecialHolidayMultiplier
        '
        Me.numSpecialHolidayMultiplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numSpecialHolidayMultiplier.DecimalPlaces = 4
        Me.numSpecialHolidayMultiplier.Margin = New System.Windows.Forms.Padding(4, 0, 12, 0)
        Me.numSpecialHolidayMultiplier.Maximum = 1000000D
        Me.numSpecialHolidayMultiplier.Name = "numSpecialHolidayMultiplier"
        Me.numSpecialHolidayMultiplier.TabIndex = 7
        Me.numSpecialHolidayMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numSpecialHolidayMultiplier.ThousandsSeparator = True
        '
        'helpSpecialHolidayMultiplier
        '
        Me.helpSpecialHolidayMultiplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpSpecialHolidayMultiplier.ForeColor = System.Drawing.Color.DimGray
        Me.helpSpecialHolidayMultiplier.Name = "helpSpecialHolidayMultiplier"
        Me.helpSpecialHolidayMultiplier.TabIndex = 8
        Me.helpSpecialHolidayMultiplier.Text = "Applied to special-holiday hours (existing template: 1.30)."
        Me.helpSpecialHolidayMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLegalHolidayMultiplier
        '
        Me.lblLegalHolidayMultiplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLegalHolidayMultiplier.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLegalHolidayMultiplier.Name = "lblLegalHolidayMultiplier"
        Me.lblLegalHolidayMultiplier.TabIndex = 9
        Me.lblLegalHolidayMultiplier.Text = "Legal holiday multiplier"
        Me.lblLegalHolidayMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numLegalHolidayMultiplier
        '
        Me.numLegalHolidayMultiplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numLegalHolidayMultiplier.DecimalPlaces = 4
        Me.numLegalHolidayMultiplier.Margin = New System.Windows.Forms.Padding(4, 0, 12, 0)
        Me.numLegalHolidayMultiplier.Maximum = 1000000D
        Me.numLegalHolidayMultiplier.Name = "numLegalHolidayMultiplier"
        Me.numLegalHolidayMultiplier.TabIndex = 10
        Me.numLegalHolidayMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numLegalHolidayMultiplier.ThousandsSeparator = True
        '
        'helpLegalHolidayMultiplier
        '
        Me.helpLegalHolidayMultiplier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpLegalHolidayMultiplier.ForeColor = System.Drawing.Color.DimGray
        Me.helpLegalHolidayMultiplier.Name = "helpLegalHolidayMultiplier"
        Me.helpLegalHolidayMultiplier.TabIndex = 11
        Me.helpLegalHolidayMultiplier.Text = "Applied to legal-holiday hours (existing template: 2.00)."
        Me.helpLegalHolidayMultiplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOvertimeHourlyRate
        '
        Me.lblOvertimeHourlyRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOvertimeHourlyRate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOvertimeHourlyRate.Name = "lblOvertimeHourlyRate"
        Me.lblOvertimeHourlyRate.TabIndex = 12
        Me.lblOvertimeHourlyRate.Text = "Overtime hourly rate"
        Me.lblOvertimeHourlyRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numOvertimeHourlyRate
        '
        Me.numOvertimeHourlyRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numOvertimeHourlyRate.DecimalPlaces = 6
        Me.numOvertimeHourlyRate.Margin = New System.Windows.Forms.Padding(4, 0, 12, 0)
        Me.numOvertimeHourlyRate.Maximum = 1000000D
        Me.numOvertimeHourlyRate.Name = "numOvertimeHourlyRate"
        Me.numOvertimeHourlyRate.TabIndex = 13
        Me.numOvertimeHourlyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numOvertimeHourlyRate.ThousandsSeparator = True
        '
        'helpOvertimeHourlyRate
        '
        Me.helpOvertimeHourlyRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpOvertimeHourlyRate.ForeColor = System.Drawing.Color.DimGray
        Me.helpOvertimeHourlyRate.Name = "helpOvertimeHourlyRate"
        Me.helpOvertimeHourlyRate.TabIndex = 14
        Me.helpOvertimeHourlyRate.Text = "Peso amount per OT hour (existing template: 20.833333)."
        Me.helpOvertimeHourlyRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblServiceIncentiveDays
        '
        Me.lblServiceIncentiveDays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblServiceIncentiveDays.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblServiceIncentiveDays.Name = "lblServiceIncentiveDays"
        Me.lblServiceIncentiveDays.TabIndex = 15
        Me.lblServiceIncentiveDays.Text = "Service incentive days"
        Me.lblServiceIncentiveDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numServiceIncentiveDays
        '
        Me.numServiceIncentiveDays.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numServiceIncentiveDays.DecimalPlaces = 4
        Me.numServiceIncentiveDays.Margin = New System.Windows.Forms.Padding(4, 0, 12, 0)
        Me.numServiceIncentiveDays.Maximum = 1000000D
        Me.numServiceIncentiveDays.Name = "numServiceIncentiveDays"
        Me.numServiceIncentiveDays.TabIndex = 16
        Me.numServiceIncentiveDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numServiceIncentiveDays.ThousandsSeparator = True
        '
        'helpServiceIncentiveDays
        '
        Me.helpServiceIncentiveDays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpServiceIncentiveDays.ForeColor = System.Drawing.Color.DimGray
        Me.helpServiceIncentiveDays.Name = "helpServiceIncentiveDays"
        Me.helpServiceIncentiveDays.TabIndex = 17
        Me.helpServiceIncentiveDays.Text = "Numerator used in the incentive-pay calculation."
        Me.helpServiceIncentiveDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIncentiveMonthsDivisor
        '
        Me.lblIncentiveMonthsDivisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveMonthsDivisor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIncentiveMonthsDivisor.Name = "lblIncentiveMonthsDivisor"
        Me.lblIncentiveMonthsDivisor.TabIndex = 18
        Me.lblIncentiveMonthsDivisor.Text = "Incentive month divisor"
        Me.lblIncentiveMonthsDivisor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numIncentiveMonthsDivisor
        '
        Me.numIncentiveMonthsDivisor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numIncentiveMonthsDivisor.DecimalPlaces = 4
        Me.numIncentiveMonthsDivisor.Margin = New System.Windows.Forms.Padding(4, 0, 12, 0)
        Me.numIncentiveMonthsDivisor.Maximum = 1000000D
        Me.numIncentiveMonthsDivisor.Name = "numIncentiveMonthsDivisor"
        Me.numIncentiveMonthsDivisor.TabIndex = 19
        Me.numIncentiveMonthsDivisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numIncentiveMonthsDivisor.ThousandsSeparator = True
        '
        'helpIncentiveMonthsDivisor
        '
        Me.helpIncentiveMonthsDivisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpIncentiveMonthsDivisor.ForeColor = System.Drawing.Color.DimGray
        Me.helpIncentiveMonthsDivisor.Name = "helpIncentiveMonthsDivisor"
        Me.helpIncentiveMonthsDivisor.TabIndex = 20
        Me.helpIncentiveMonthsDivisor.Text = "Month divisor used in the incentive-pay calculation."
        Me.helpIncentiveMonthsDivisor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIncentiveDaysDivisor
        '
        Me.lblIncentiveDaysDivisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIncentiveDaysDivisor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIncentiveDaysDivisor.Name = "lblIncentiveDaysDivisor"
        Me.lblIncentiveDaysDivisor.TabIndex = 21
        Me.lblIncentiveDaysDivisor.Text = "Incentive day divisor"
        Me.lblIncentiveDaysDivisor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numIncentiveDaysDivisor
        '
        Me.numIncentiveDaysDivisor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numIncentiveDaysDivisor.DecimalPlaces = 4
        Me.numIncentiveDaysDivisor.Margin = New System.Windows.Forms.Padding(4, 0, 12, 0)
        Me.numIncentiveDaysDivisor.Maximum = 1000000D
        Me.numIncentiveDaysDivisor.Name = "numIncentiveDaysDivisor"
        Me.numIncentiveDaysDivisor.TabIndex = 22
        Me.numIncentiveDaysDivisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numIncentiveDaysDivisor.ThousandsSeparator = True
        '
        'helpIncentiveDaysDivisor
        '
        Me.helpIncentiveDaysDivisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpIncentiveDaysDivisor.ForeColor = System.Drawing.Color.DimGray
        Me.helpIncentiveDaysDivisor.Name = "helpIncentiveDaysDivisor"
        Me.helpIncentiveDaysDivisor.TabIndex = 23
        Me.helpIncentiveDaysDivisor.Text = "Day divisor used in the incentive-pay calculation."
        Me.helpIncentiveDaysDivisor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'settingsPathLabel
        '
        Me.settingsPathLabel.AutoEllipsis = True
        Me.settingsPathLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.settingsPathLabel.ForeColor = System.Drawing.Color.Teal
        Me.settingsPathLabel.Name = "settingsPathLabel"
        Me.settingsPathLabel.TabIndex = 2
        Me.settingsPathLabel.Text = "Saved to:"
        Me.settingsPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'buttonsPanel
        '
        Me.buttonsPanel.Controls.Add(Me.btnSave)
        Me.buttonsPanel.Controls.Add(Me.btnCancel)
        Me.buttonsPanel.Controls.Add(Me.btnRestoreDefaults)
        Me.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.buttonsPanel.Name = "buttonsPanel"
        Me.buttonsPanel.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.buttonsPanel.TabIndex = 3
        Me.buttonsPanel.WrapContents = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Teal
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(135, 38)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save changes"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 38)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRestoreDefaults
        '
        Me.btnRestoreDefaults.Name = "btnRestoreDefaults"
        Me.btnRestoreDefaults.Size = New System.Drawing.Size(145, 38)
        Me.btnRestoreDefaults.TabIndex = 2
        Me.btnRestoreDefaults.Text = "Restore defaults"
        Me.btnRestoreDefaults.UseVisualStyleBackColor = True
        '
        'FRM_PAYROLL_REPORT_SETTINGS
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(960, 720)
        Me.Controls.Add(Me.rootPanel)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(900, 650)
        Me.Name = "FRM_PAYROLL_REPORT_SETTINGS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payroll and Report Settings"
        CType(Me.numHoursPerDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSundayMultiplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSpecialHolidayMultiplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLegalHolidayMultiplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOvertimeHourlyRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numServiceIncentiveDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIncentiveMonthsDivisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIncentiveDaysDivisor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.buttonsPanel.ResumeLayout(False)
        Me.calculationFields.ResumeLayout(False)
        Me.calculationTab.ResumeLayout(False)
        Me.companyFields.ResumeLayout(False)
        Me.companyFields.PerformLayout()
        Me.companyTab.ResumeLayout(False)
        Me.settingsTabs.ResumeLayout(False)
        Me.rootPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents rootPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents headerLabel As System.Windows.Forms.Label
    Friend WithEvents settingsTabs As System.Windows.Forms.TabControl
    Friend WithEvents companyTab As System.Windows.Forms.TabPage
    Friend WithEvents companyFields As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents calculationTab As System.Windows.Forms.TabPage
    Friend WithEvents calculationFields As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents settingsPathLabel As System.Windows.Forms.Label
    Friend WithEvents buttonsPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRestoreDefaults As System.Windows.Forms.Button
    Friend WithEvents lblCompanySection As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents helpCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblCompanyAddress As System.Windows.Forms.Label
    Friend WithEvents txtCompanyAddress As System.Windows.Forms.TextBox
    Friend WithEvents helpCompanyAddress As System.Windows.Forms.Label
    Friend WithEvents lblCompanyPhone As System.Windows.Forms.Label
    Friend WithEvents txtCompanyPhone As System.Windows.Forms.TextBox
    Friend WithEvents helpCompanyPhone As System.Windows.Forms.Label
    Friend WithEvents lblCompanyEmail As System.Windows.Forms.Label
    Friend WithEvents txtCompanyEmail As System.Windows.Forms.TextBox
    Friend WithEvents helpCompanyEmail As System.Windows.Forms.Label
    Friend WithEvents lblPayrollSection As System.Windows.Forms.Label
    Friend WithEvents lblPayrollPreparedName As System.Windows.Forms.Label
    Friend WithEvents txtPayrollPreparedName As System.Windows.Forms.TextBox
    Friend WithEvents helpPayrollPreparedName As System.Windows.Forms.Label
    Friend WithEvents lblPayrollPreparedTitle As System.Windows.Forms.Label
    Friend WithEvents txtPayrollPreparedTitle As System.Windows.Forms.TextBox
    Friend WithEvents helpPayrollPreparedTitle As System.Windows.Forms.Label
    Friend WithEvents lblPayrollApprovedName As System.Windows.Forms.Label
    Friend WithEvents txtPayrollApprovedName As System.Windows.Forms.TextBox
    Friend WithEvents helpPayrollApprovedName As System.Windows.Forms.Label
    Friend WithEvents lblPayrollApprovedTitle As System.Windows.Forms.Label
    Friend WithEvents txtPayrollApprovedTitle As System.Windows.Forms.TextBox
    Friend WithEvents helpPayrollApprovedTitle As System.Windows.Forms.Label
    Friend WithEvents lblDtrSection As System.Windows.Forms.Label
    Friend WithEvents lblDtrPreparedName As System.Windows.Forms.Label
    Friend WithEvents txtDtrPreparedName As System.Windows.Forms.TextBox
    Friend WithEvents helpDtrPreparedName As System.Windows.Forms.Label
    Friend WithEvents lblDtrPreparedTitle As System.Windows.Forms.Label
    Friend WithEvents txtDtrPreparedTitle As System.Windows.Forms.TextBox
    Friend WithEvents helpDtrPreparedTitle As System.Windows.Forms.Label
    Friend WithEvents lblDtrCheckedName As System.Windows.Forms.Label
    Friend WithEvents txtDtrCheckedName As System.Windows.Forms.TextBox
    Friend WithEvents helpDtrCheckedName As System.Windows.Forms.Label
    Friend WithEvents lblDtrCheckedTitle As System.Windows.Forms.Label
    Friend WithEvents txtDtrCheckedTitle As System.Windows.Forms.TextBox
    Friend WithEvents helpDtrCheckedTitle As System.Windows.Forms.Label
    Friend WithEvents lblDtrNotedName As System.Windows.Forms.Label
    Friend WithEvents txtDtrNotedName As System.Windows.Forms.TextBox
    Friend WithEvents helpDtrNotedName As System.Windows.Forms.Label
    Friend WithEvents lblDtrNotedTitle As System.Windows.Forms.Label
    Friend WithEvents txtDtrNotedTitle As System.Windows.Forms.TextBox
    Friend WithEvents helpDtrNotedTitle As System.Windows.Forms.Label
    Friend WithEvents lblHoursPerDay As System.Windows.Forms.Label
    Friend WithEvents numHoursPerDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents helpHoursPerDay As System.Windows.Forms.Label
    Friend WithEvents lblSundayMultiplier As System.Windows.Forms.Label
    Friend WithEvents numSundayMultiplier As System.Windows.Forms.NumericUpDown
    Friend WithEvents helpSundayMultiplier As System.Windows.Forms.Label
    Friend WithEvents lblSpecialHolidayMultiplier As System.Windows.Forms.Label
    Friend WithEvents numSpecialHolidayMultiplier As System.Windows.Forms.NumericUpDown
    Friend WithEvents helpSpecialHolidayMultiplier As System.Windows.Forms.Label
    Friend WithEvents lblLegalHolidayMultiplier As System.Windows.Forms.Label
    Friend WithEvents numLegalHolidayMultiplier As System.Windows.Forms.NumericUpDown
    Friend WithEvents helpLegalHolidayMultiplier As System.Windows.Forms.Label
    Friend WithEvents lblOvertimeHourlyRate As System.Windows.Forms.Label
    Friend WithEvents numOvertimeHourlyRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents helpOvertimeHourlyRate As System.Windows.Forms.Label
    Friend WithEvents lblServiceIncentiveDays As System.Windows.Forms.Label
    Friend WithEvents numServiceIncentiveDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents helpServiceIncentiveDays As System.Windows.Forms.Label
    Friend WithEvents lblIncentiveMonthsDivisor As System.Windows.Forms.Label
    Friend WithEvents numIncentiveMonthsDivisor As System.Windows.Forms.NumericUpDown
    Friend WithEvents helpIncentiveMonthsDivisor As System.Windows.Forms.Label
    Friend WithEvents lblIncentiveDaysDivisor As System.Windows.Forms.Label
    Friend WithEvents numIncentiveDaysDivisor As System.Windows.Forms.NumericUpDown
    Friend WithEvents helpIncentiveDaysDivisor As System.Windows.Forms.Label
End Class

