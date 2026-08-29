<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_HR_CLIENTS
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.RootLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.HeaderPanel = New System.Windows.Forms.Panel()
        Me.ClientsLogo = New System.Windows.Forms.PictureBox()
        Me.LblHeaderTitle = New System.Windows.Forms.Label()
        Me.LblHeaderSubtitle = New System.Windows.Forms.Label()
        Me.LblHeaderSection = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BodyPanel = New System.Windows.Forms.Panel()
        Me.WorkspacePanel = New System.Windows.Forms.Panel()
        Me.EditorPanel = New System.Windows.Forms.Panel()
        Me.EditorTabs = New System.Windows.Forms.TabControl()
        Me.TabCompanyEditor = New System.Windows.Forms.TabPage()
        Me.LblCompanyEditorIntro = New System.Windows.Forms.Label()
        Me.LblCompanyName = New System.Windows.Forms.Label()
        Me.TxtCompanyName = New System.Windows.Forms.TextBox()
        Me.LblCompanyType = New System.Windows.Forms.Label()
        Me.CmbCompanyType = New System.Windows.Forms.ComboBox()
        Me.PnlCompanyWarning = New System.Windows.Forms.Panel()
        Me.LblCompanyWarning = New System.Windows.Forms.Label()
        Me.ChkCompanyWarning = New System.Windows.Forms.CheckBox()
        Me.ChkCompanyConfirmation = New System.Windows.Forms.CheckBox()
        Me.BtnRouteToWorkSite = New System.Windows.Forms.Button()
        Me.TabWorkSiteEditor = New System.Windows.Forms.TabPage()
        Me.WorkSiteWizardTabs = New System.Windows.Forms.TabControl()
        Me.TabWizardIdentity = New System.Windows.Forms.TabPage()
        Me.LblLockedParentCaption = New System.Windows.Forms.Label()
        Me.LblLockedParent = New System.Windows.Forms.Label()
        Me.LblSiteName = New System.Windows.Forms.Label()
        Me.TxtSiteName = New System.Windows.Forms.TextBox()
        Me.LblSiteAddress = New System.Windows.Forms.Label()
        Me.TxtSiteAddress = New System.Windows.Forms.TextBox()
        Me.TabWizardPayroll = New System.Windows.Forms.TabPage()
        Me.LblSchedule = New System.Windows.Forms.Label()
        Me.CmbSchedule = New System.Windows.Forms.ComboBox()
        Me.LblDailyWage = New System.Windows.Forms.Label()
        Me.TxtDailyWage = New System.Windows.Forms.TextBox()
        Me.LblContactPerson = New System.Windows.Forms.Label()
        Me.TxtContactPerson = New System.Windows.Forms.TextBox()
        Me.LblContactNumber = New System.Windows.Forms.Label()
        Me.TxtContactNumber = New System.Windows.Forms.TextBox()
        Me.LblContactEmail = New System.Windows.Forms.Label()
        Me.TxtContactEmail = New System.Windows.Forms.TextBox()
        Me.TabWizardContract = New System.Windows.Forms.TabPage()
        Me.PnlInitialContract = New System.Windows.Forms.Panel()
        Me.LblInitialContractTitle = New System.Windows.Forms.Label()
        Me.LblInitialContractHelp = New System.Windows.Forms.Label()
        Me.DtpInitialContractStart = New System.Windows.Forms.DateTimePicker()
        Me.DtpInitialContractEnd = New System.Windows.Forms.DateTimePicker()
        Me.BtnChooseInitialContract = New System.Windows.Forms.Button()
        Me.LblInitialContractFile = New System.Windows.Forms.Label()
        Me.TxtInitialContractRemarks = New System.Windows.Forms.TextBox()
        Me.WizardProgressPanel = New System.Windows.Forms.Panel()
        Me.LblWizardStepOne = New System.Windows.Forms.Label()
        Me.LblWizardStepTwo = New System.Windows.Forms.Label()
        Me.LblWizardStepThree = New System.Windows.Forms.Label()
        Me.TabContractEditor = New System.Windows.Forms.TabPage()
        Me.LblContractContext = New System.Windows.Forms.Label()
        Me.LblContractStart = New System.Windows.Forms.Label()
        Me.DtpContractStart = New System.Windows.Forms.DateTimePicker()
        Me.LblContractEnd = New System.Windows.Forms.Label()
        Me.DtpContractEnd = New System.Windows.Forms.DateTimePicker()
        Me.BtnChooseContract = New System.Windows.Forms.Button()
        Me.LblContractFile = New System.Windows.Forms.Label()
        Me.LblContractRemarks = New System.Windows.Forms.Label()
        Me.TxtContractRemarks = New System.Windows.Forms.TextBox()
        Me.TabStatusEditor = New System.Windows.Forms.TabPage()
        Me.LblStatusContext = New System.Windows.Forms.Label()
        Me.LblStatusEffective = New System.Windows.Forms.Label()
        Me.DtpStatusEffective = New System.Windows.Forms.DateTimePicker()
        Me.LblStatusReason = New System.Windows.Forms.Label()
        Me.CmbStatusReason = New System.Windows.Forms.ComboBox()
        Me.LblStatusNote = New System.Windows.Forms.Label()
        Me.EditorFooterPanel = New System.Windows.Forms.Panel()
        Me.LblEditorMessage = New System.Windows.Forms.Label()
        Me.EditorActionFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.BtnEditorBack = New System.Windows.Forms.Button()
        Me.BtnCancelEditor = New System.Windows.Forms.Button()
        Me.BtnEditorNext = New System.Windows.Forms.Button()
        Me.BtnSaveEditor = New System.Windows.Forms.Button()
        Me.EditorHeaderPanel = New System.Windows.Forms.Panel()
        Me.LblEditorEyebrow = New System.Windows.Forms.Label()
        Me.LblEditorTitle = New System.Windows.Forms.Label()
        Me.LblEditorSubtitle = New System.Windows.Forms.Label()
        Me.MainCanvas = New System.Windows.Forms.Panel()
        Me.WorkspaceViews = New System.Windows.Forms.TabControl()
        Me.TabDirectoryView = New System.Windows.Forms.TabPage()
        Me.ContentSplit = New System.Windows.Forms.SplitContainer()
        Me.CompanyDirectoryPanel = New System.Windows.Forms.Panel()
        Me.BtnAddCompany = New System.Windows.Forms.Button()
        Me.LblCompaniesTitle = New System.Windows.Forms.Label()
        Me.LblCompaniesCount = New System.Windows.Forms.Label()
        Me.TxtCompanySearch = New System.Windows.Forms.TextBox()
        Me.CmbCompanyStatus = New System.Windows.Forms.ComboBox()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.LvCompanies = New System.Windows.Forms.ListView()
        Me.ColCompanyCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCompany = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCompanyType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColSiteCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCompanyStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LblCompanySearch = New System.Windows.Forms.Label()
        Me.LblCompanyStatusFilter = New System.Windows.Forms.Label()
        Me.LblCompaniesEmpty = New System.Windows.Forms.Label()
        Me.CompanyWorkspaceLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.HierarchyPanel = New System.Windows.Forms.Panel()
        Me.LblHierarchyCompanyCaption = New System.Windows.Forms.Label()
        Me.LblHierarchyCompany = New System.Windows.Forms.Label()
        Me.BtnEditCompany = New System.Windows.Forms.Button()
        Me.BtnCompanyStatus = New System.Windows.Forms.Button()
        Me.LblWorkspaceMessage = New System.Windows.Forms.Label()
        Me.WorkSitesPanel = New System.Windows.Forms.Panel()
        Me.LblWorkSitesTitle = New System.Windows.Forms.Label()
        Me.LblWorkSitesCount = New System.Windows.Forms.Label()
        Me.LvWorkSites = New System.Windows.Forms.ListView()
        Me.ColSiteCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColSiteName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColSiteAddress = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColSiteStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAddWorkSite = New System.Windows.Forms.Button()
        Me.BtnOpenWorkSite = New System.Windows.Forms.Button()
        Me.LblWorkSitesHelp = New System.Windows.Forms.Label()
        Me.LblWorkSitesEmpty = New System.Windows.Forms.Label()
        Me.TabWorkSiteProfile = New System.Windows.Forms.TabPage()
        Me.DetailsTabs = New System.Windows.Forms.TabControl()
        Me.TabOverview = New System.Windows.Forms.TabPage()
        Me.LblOverviewName = New System.Windows.Forms.Label()
        Me.LblOverviewStatus = New System.Windows.Forms.Label()
        Me.LblOverviewAddressCaption = New System.Windows.Forms.Label()
        Me.LblOverviewAddress = New System.Windows.Forms.Label()
        Me.LblOverviewParentCaption = New System.Windows.Forms.Label()
        Me.LblOverviewParent = New System.Windows.Forms.Label()
        Me.LblOverviewNextStep = New System.Windows.Forms.Label()
        Me.TabPayrollContacts = New System.Windows.Forms.TabPage()
        Me.LblOverviewScheduleCaption = New System.Windows.Forms.Label()
        Me.LblOverviewSchedule = New System.Windows.Forms.Label()
        Me.LblOverviewWageCaption = New System.Windows.Forms.Label()
        Me.LblOverviewWage = New System.Windows.Forms.Label()
        Me.LblOverviewContactCaption = New System.Windows.Forms.Label()
        Me.LblOverviewContact = New System.Windows.Forms.Label()
        Me.TabContracts = New System.Windows.Forms.TabPage()
        Me.LvContracts = New System.Windows.Forms.ListView()
        Me.ColContractPeriod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColContractStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColContractFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAddContract = New System.Windows.Forms.Button()
        Me.BtnEditContract = New System.Windows.Forms.Button()
        Me.BtnOpenContract = New System.Windows.Forms.Button()
        Me.BtnRemoveContract = New System.Windows.Forms.Button()
        Me.LblContractSummary = New System.Windows.Forms.Label()
        Me.LblContractsEmpty = New System.Windows.Forms.Label()
        Me.TabStatusHistory = New System.Windows.Forms.TabPage()
        Me.LvStatusHistory = New System.Windows.Forms.ListView()
        Me.ColHistoryDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColHistoryStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColHistoryReason = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LblStatusHistoryEmpty = New System.Windows.Forms.Label()
        Me.WorkSiteProfileHeader = New System.Windows.Forms.Panel()
        Me.BtnBackToDirectory = New System.Windows.Forms.Button()
        Me.LblProfileBreadcrumb = New System.Windows.Forms.Label()
        Me.LblProfileName = New System.Windows.Forms.Label()
        Me.LblProfileStatus = New System.Windows.Forms.Label()
        Me.BtnEditWorkSite = New System.Windows.Forms.Button()
        Me.BtnWorkSiteStatus = New System.Windows.Forms.Button()
        Me.TabContractMonitoring = New System.Windows.Forms.TabPage()
        Me.LblMonitoringTitle = New System.Windows.Forms.Label()
        Me.LblMonitoringSubtitle = New System.Windows.Forms.Label()
        Me.MonitoringFilterPanel = New System.Windows.Forms.Panel()
        Me.LblMonitoringFilter = New System.Windows.Forms.Label()
        Me.CmbContractMonitoringFilter = New System.Windows.Forms.ComboBox()
        Me.BtnRefreshContractMonitoring = New System.Windows.Forms.Button()
        Me.LvContractMonitoring = New System.Windows.Forms.ListView()
        Me.ColMonitoringCompany = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColMonitoringSite = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColMonitoringEnd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColMonitoringStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColMonitoringFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LblMonitoringEmpty = New System.Windows.Forms.Label()
        Me.NavigationPanel = New System.Windows.Forms.Panel()
        Me.NavigationGuidePanel = New System.Windows.Forms.Panel()
        Me.LblNavigationGuideTitle = New System.Windows.Forms.Label()
        Me.LblNavigationGuide = New System.Windows.Forms.Label()
        Me.BtnNavContracts = New System.Windows.Forms.Button()
        Me.BtnNavSites = New System.Windows.Forms.Button()
        Me.BtnNavCompanies = New System.Windows.Forms.Button()
        Me.WorkspaceHeaderPanel = New System.Windows.Forms.Panel()
        Me.LblWorkspaceEyebrow = New System.Windows.Forms.Label()
        Me.LblWorkspaceTitle = New System.Windows.Forms.Label()
        Me.LblWorkspaceSubtitle = New System.Windows.Forms.Label()
        Me.LblHierarchyArrowOne = New System.Windows.Forms.Label()
        Me.LblHierarchySiteCaption = New System.Windows.Forms.Label()
        Me.LblHierarchySite = New System.Windows.Forms.Label()
        Me.LblHierarchyArrowTwo = New System.Windows.Forms.Label()
        Me.LblHierarchyContractCaption = New System.Windows.Forms.Label()
        Me.LblHierarchyContract = New System.Windows.Forms.Label()
        Me.SiteDetailsSplit = New System.Windows.Forms.SplitContainer()
        Me.ClientErrors = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ClientToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContractFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SearchTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RootLayout.SuspendLayout()
        Me.HeaderPanel.SuspendLayout()
        CType(Me.ClientsLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BodyPanel.SuspendLayout()
        Me.WorkspacePanel.SuspendLayout()
        Me.EditorPanel.SuspendLayout()
        Me.EditorTabs.SuspendLayout()
        Me.TabCompanyEditor.SuspendLayout()
        Me.PnlCompanyWarning.SuspendLayout()
        Me.TabWorkSiteEditor.SuspendLayout()
        Me.WorkSiteWizardTabs.SuspendLayout()
        Me.TabWizardIdentity.SuspendLayout()
        Me.TabWizardPayroll.SuspendLayout()
        Me.TabWizardContract.SuspendLayout()
        Me.PnlInitialContract.SuspendLayout()
        Me.WizardProgressPanel.SuspendLayout()
        Me.TabContractEditor.SuspendLayout()
        Me.TabStatusEditor.SuspendLayout()
        Me.EditorFooterPanel.SuspendLayout()
        Me.EditorActionFlow.SuspendLayout()
        Me.EditorHeaderPanel.SuspendLayout()
        Me.MainCanvas.SuspendLayout()
        Me.WorkspaceViews.SuspendLayout()
        Me.TabDirectoryView.SuspendLayout()
        CType(Me.ContentSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContentSplit.Panel1.SuspendLayout()
        Me.ContentSplit.Panel2.SuspendLayout()
        Me.ContentSplit.SuspendLayout()
        Me.CompanyDirectoryPanel.SuspendLayout()
        Me.CompanyWorkspaceLayout.SuspendLayout()
        Me.HierarchyPanel.SuspendLayout()
        Me.WorkSitesPanel.SuspendLayout()
        Me.TabWorkSiteProfile.SuspendLayout()
        Me.DetailsTabs.SuspendLayout()
        Me.TabOverview.SuspendLayout()
        Me.TabPayrollContacts.SuspendLayout()
        Me.TabContracts.SuspendLayout()
        Me.TabStatusHistory.SuspendLayout()
        Me.WorkSiteProfileHeader.SuspendLayout()
        Me.TabContractMonitoring.SuspendLayout()
        Me.MonitoringFilterPanel.SuspendLayout()
        Me.NavigationPanel.SuspendLayout()
        Me.NavigationGuidePanel.SuspendLayout()
        Me.WorkspaceHeaderPanel.SuspendLayout()
        CType(Me.SiteDetailsSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SiteDetailsSplit.SuspendLayout()
        CType(Me.ClientErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RootLayout
        '
        Me.RootLayout.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.RootLayout.ColumnCount = 1
        Me.RootLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RootLayout.Controls.Add(Me.HeaderPanel, 0, 0)
        Me.RootLayout.Controls.Add(Me.BodyPanel, 0, 1)
        Me.RootLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RootLayout.Location = New System.Drawing.Point(0, 0)
        Me.RootLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.RootLayout.Name = "RootLayout"
        Me.RootLayout.RowCount = 2
        Me.RootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.RootLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RootLayout.Size = New System.Drawing.Size(1440, 860)
        Me.RootLayout.TabIndex = 0
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.HeaderPanel.Controls.Add(Me.ClientsLogo)
        Me.HeaderPanel.Controls.Add(Me.LblHeaderTitle)
        Me.HeaderPanel.Controls.Add(Me.LblHeaderSubtitle)
        Me.HeaderPanel.Controls.Add(Me.LblHeaderSection)
        Me.HeaderPanel.Controls.Add(Me.BtnClose)
        Me.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.HeaderPanel.Name = "HeaderPanel"
        Me.HeaderPanel.Size = New System.Drawing.Size(1440, 94)
        Me.HeaderPanel.TabIndex = 0
        '
        'ClientsLogo
        '
        Me.ClientsLogo.Image = Global.DMSA_System.My.Resources.Resources.DeltaMaroon_NoBg
        Me.ClientsLogo.Location = New System.Drawing.Point(24, 14)
        Me.ClientsLogo.Name = "ClientsLogo"
        Me.ClientsLogo.Size = New System.Drawing.Size(62, 68)
        Me.ClientsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ClientsLogo.TabIndex = 0
        Me.ClientsLogo.TabStop = False
        '
        'LblHeaderTitle
        '
        Me.LblHeaderTitle.AutoSize = True
        Me.LblHeaderTitle.Font = New System.Drawing.Font("Bahnschrift SemiBold", 18.0!)
        Me.LblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.LblHeaderTitle.Location = New System.Drawing.Point(104, 20)
        Me.LblHeaderTitle.Name = "LblHeaderTitle"
        Me.LblHeaderTitle.Size = New System.Drawing.Size(367, 29)
        Me.LblHeaderTitle.TabIndex = 1
        Me.LblHeaderTitle.Text = "HUMAN RESOURCES  /  CLIENTS"
        '
        'LblHeaderSubtitle
        '
        Me.LblHeaderSubtitle.AutoSize = True
        Me.LblHeaderSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.LblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.LblHeaderSubtitle.Location = New System.Drawing.Point(106, 58)
        Me.LblHeaderSubtitle.Name = "LblHeaderSubtitle"
        Me.LblHeaderSubtitle.Size = New System.Drawing.Size(357, 17)
        Me.LblHeaderSubtitle.TabIndex = 2
        Me.LblHeaderSubtitle.Text = "Clients, subclients, their information and service agreements"
        '
        'LblHeaderSection
        '
        Me.LblHeaderSection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblHeaderSection.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.LblHeaderSection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.LblHeaderSection.Location = New System.Drawing.Point(1050, 14)
        Me.LblHeaderSection.Name = "LblHeaderSection"
        Me.LblHeaderSection.Size = New System.Drawing.Size(240, 68)
        Me.LblHeaderSection.TabIndex = 3
        Me.LblHeaderSection.Text = "CLIENT DIRECTORY"
        Me.LblHeaderSection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.BtnClose.Location = New System.Drawing.Point(1316, 29)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(100, 36)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BodyPanel
        '
        Me.BodyPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BodyPanel.Controls.Add(Me.WorkspacePanel)
        Me.BodyPanel.Controls.Add(Me.NavigationPanel)
        Me.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BodyPanel.Location = New System.Drawing.Point(0, 94)
        Me.BodyPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.BodyPanel.Name = "BodyPanel"
        Me.BodyPanel.Padding = New System.Windows.Forms.Padding(18, 14, 18, 18)
        Me.BodyPanel.Size = New System.Drawing.Size(1440, 766)
        Me.BodyPanel.TabIndex = 1
        '
        'WorkspacePanel
        '
        Me.WorkspacePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.WorkspacePanel.Controls.Add(Me.EditorPanel)
        Me.WorkspacePanel.Controls.Add(Me.MainCanvas)
        Me.WorkspacePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkspacePanel.Location = New System.Drawing.Point(214, 14)
        Me.WorkspacePanel.Name = "WorkspacePanel"
        Me.WorkspacePanel.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.WorkspacePanel.Size = New System.Drawing.Size(1208, 734)
        Me.WorkspacePanel.TabIndex = 0
        '
        'EditorPanel
        '
        Me.EditorPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.EditorPanel.Controls.Add(Me.EditorTabs)
        Me.EditorPanel.Controls.Add(Me.EditorFooterPanel)
        Me.EditorPanel.Controls.Add(Me.EditorHeaderPanel)
        Me.EditorPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.EditorPanel.Location = New System.Drawing.Point(708, 0)
        Me.EditorPanel.Name = "EditorPanel"
        Me.EditorPanel.Size = New System.Drawing.Size(500, 734)
        Me.EditorPanel.TabIndex = 0
        Me.EditorPanel.Visible = False
        '
        'EditorTabs
        '
        Me.EditorTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.EditorTabs.Controls.Add(Me.TabCompanyEditor)
        Me.EditorTabs.Controls.Add(Me.TabWorkSiteEditor)
        Me.EditorTabs.Controls.Add(Me.TabContractEditor)
        Me.EditorTabs.Controls.Add(Me.TabStatusEditor)
        Me.EditorTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditorTabs.ItemSize = New System.Drawing.Size(0, 1)
        Me.EditorTabs.Location = New System.Drawing.Point(0, 104)
        Me.EditorTabs.Name = "EditorTabs"
        Me.EditorTabs.Padding = New System.Drawing.Point(0, 0)
        Me.EditorTabs.SelectedIndex = 0
        Me.EditorTabs.Size = New System.Drawing.Size(500, 542)
        Me.EditorTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.EditorTabs.TabIndex = 0
        '
        'TabCompanyEditor
        '
        Me.TabCompanyEditor.AutoScroll = True
        Me.TabCompanyEditor.AutoScrollMinSize = New System.Drawing.Size(0, 360)
        Me.TabCompanyEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabCompanyEditor.Controls.Add(Me.LblCompanyEditorIntro)
        Me.TabCompanyEditor.Controls.Add(Me.LblCompanyName)
        Me.TabCompanyEditor.Controls.Add(Me.TxtCompanyName)
        Me.TabCompanyEditor.Controls.Add(Me.LblCompanyType)
        Me.TabCompanyEditor.Controls.Add(Me.CmbCompanyType)
        Me.TabCompanyEditor.Controls.Add(Me.PnlCompanyWarning)
        Me.TabCompanyEditor.Controls.Add(Me.ChkCompanyConfirmation)
        Me.TabCompanyEditor.Controls.Add(Me.BtnRouteToWorkSite)
        Me.TabCompanyEditor.Location = New System.Drawing.Point(4, 5)
        Me.TabCompanyEditor.Name = "TabCompanyEditor"
        Me.TabCompanyEditor.Size = New System.Drawing.Size(492, 533)
        Me.TabCompanyEditor.TabIndex = 0
        '
        'LblCompanyEditorIntro
        '
        Me.LblCompanyEditorIntro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblCompanyEditorIntro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblCompanyEditorIntro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.LblCompanyEditorIntro.Location = New System.Drawing.Point(28, 12)
        Me.LblCompanyEditorIntro.Name = "LblCompanyEditorIntro"
        Me.LblCompanyEditorIntro.Padding = New System.Windows.Forms.Padding(12)
        Me.LblCompanyEditorIntro.Size = New System.Drawing.Size(438, 44)
        Me.LblCompanyEditorIntro.TabIndex = 0
        Me.LblCompanyEditorIntro.Text = "Use the registered legal organization here. Branches, detachments and deployment " &
    "locations belong under Subclients."
        '
        'LblCompanyName
        '
        Me.LblCompanyName.AutoSize = True
        Me.LblCompanyName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblCompanyName.Location = New System.Drawing.Point(28, 68)
        Me.LblCompanyName.Name = "LblCompanyName"
        Me.LblCompanyName.Size = New System.Drawing.Size(161, 15)
        Me.LblCompanyName.TabIndex = 1
        Me.LblCompanyName.Text = "Legal client name  • Required"
        '
        'TxtCompanyName
        '
        Me.TxtCompanyName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TxtCompanyName.Location = New System.Drawing.Point(28, 90)
        Me.TxtCompanyName.MaxLength = 255
        Me.TxtCompanyName.Name = "TxtCompanyName"
        Me.TxtCompanyName.Size = New System.Drawing.Size(438, 25)
        Me.TxtCompanyName.TabIndex = 2
        '
        'LblCompanyType
        '
        Me.LblCompanyType.AutoSize = True
        Me.LblCompanyType.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblCompanyType.Location = New System.Drawing.Point(28, 126)
        Me.LblCompanyType.Name = "LblCompanyType"
        Me.LblCompanyType.Size = New System.Drawing.Size(163, 15)
        Me.LblCompanyType.TabIndex = 3
        Me.LblCompanyType.Text = "Organization type  • Required"
        '
        'CmbCompanyType
        '
        Me.CmbCompanyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCompanyType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CmbCompanyType.Items.AddRange(New Object() {"Private", "Government"})
        Me.CmbCompanyType.Location = New System.Drawing.Point(28, 148)
        Me.CmbCompanyType.Name = "CmbCompanyType"
        Me.CmbCompanyType.Size = New System.Drawing.Size(438, 25)
        Me.CmbCompanyType.TabIndex = 4
        '
        'PnlCompanyWarning
        '
        Me.PnlCompanyWarning.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.PnlCompanyWarning.Controls.Add(Me.LblCompanyWarning)
        Me.PnlCompanyWarning.Controls.Add(Me.ChkCompanyWarning)
        Me.PnlCompanyWarning.Location = New System.Drawing.Point(28, 188)
        Me.PnlCompanyWarning.Name = "PnlCompanyWarning"
        Me.PnlCompanyWarning.Size = New System.Drawing.Size(438, 84)
        Me.PnlCompanyWarning.TabIndex = 5
        Me.PnlCompanyWarning.Visible = False
        '
        'LblCompanyWarning
        '
        Me.LblCompanyWarning.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.LblCompanyWarning.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.LblCompanyWarning.Location = New System.Drawing.Point(12, 10)
        Me.LblCompanyWarning.Name = "LblCompanyWarning"
        Me.LblCompanyWarning.Size = New System.Drawing.Size(414, 46)
        Me.LblCompanyWarning.TabIndex = 0
        '
        'ChkCompanyWarning
        '
        Me.ChkCompanyWarning.AutoSize = True
        Me.ChkCompanyWarning.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.ChkCompanyWarning.Location = New System.Drawing.Point(14, 60)
        Me.ChkCompanyWarning.Name = "ChkCompanyWarning"
        Me.ChkCompanyWarning.Size = New System.Drawing.Size(222, 19)
        Me.ChkCompanyWarning.TabIndex = 1
        Me.ChkCompanyWarning.Text = "I verified this is a different legal client"
        '
        'ChkCompanyConfirmation
        '
        Me.ChkCompanyConfirmation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkCompanyConfirmation.Location = New System.Drawing.Point(28, 282)
        Me.ChkCompanyConfirmation.Name = "ChkCompanyConfirmation"
        Me.ChkCompanyConfirmation.Size = New System.Drawing.Size(438, 36)
        Me.ChkCompanyConfirmation.TabIndex = 6
        Me.ChkCompanyConfirmation.Text = "I confirm this is a top-level legal organization, not a branch, detachment or wor" &
    "k location."
        '
        'BtnRouteToWorkSite
        '
        Me.BtnRouteToWorkSite.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnRouteToWorkSite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.BtnRouteToWorkSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRouteToWorkSite.Font = New System.Drawing.Font("Segoe UI Semibold", 8.75!)
        Me.BtnRouteToWorkSite.ForeColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnRouteToWorkSite.Location = New System.Drawing.Point(28, 326)
        Me.BtnRouteToWorkSite.Name = "BtnRouteToWorkSite"
        Me.BtnRouteToWorkSite.Size = New System.Drawing.Size(438, 34)
        Me.BtnRouteToWorkSite.TabIndex = 7
        Me.BtnRouteToWorkSite.Text = "Add as subclient"
        Me.BtnRouteToWorkSite.UseVisualStyleBackColor = False
        Me.BtnRouteToWorkSite.Visible = False
        '
        'TabWorkSiteEditor
        '
        Me.TabWorkSiteEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabWorkSiteEditor.Controls.Add(Me.WorkSiteWizardTabs)
        Me.TabWorkSiteEditor.Controls.Add(Me.WizardProgressPanel)
        Me.TabWorkSiteEditor.Location = New System.Drawing.Point(4, 5)
        Me.TabWorkSiteEditor.Name = "TabWorkSiteEditor"
        Me.TabWorkSiteEditor.Size = New System.Drawing.Size(492, 533)
        Me.TabWorkSiteEditor.TabIndex = 1
        '
        'WorkSiteWizardTabs
        '
        Me.WorkSiteWizardTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.WorkSiteWizardTabs.Controls.Add(Me.TabWizardIdentity)
        Me.WorkSiteWizardTabs.Controls.Add(Me.TabWizardPayroll)
        Me.WorkSiteWizardTabs.Controls.Add(Me.TabWizardContract)
        Me.WorkSiteWizardTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkSiteWizardTabs.ItemSize = New System.Drawing.Size(0, 1)
        Me.WorkSiteWizardTabs.Location = New System.Drawing.Point(0, 58)
        Me.WorkSiteWizardTabs.Name = "WorkSiteWizardTabs"
        Me.WorkSiteWizardTabs.Padding = New System.Drawing.Point(0, 0)
        Me.WorkSiteWizardTabs.SelectedIndex = 0
        Me.WorkSiteWizardTabs.Size = New System.Drawing.Size(492, 475)
        Me.WorkSiteWizardTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.WorkSiteWizardTabs.TabIndex = 0
        '
        'TabWizardIdentity
        '
        Me.TabWizardIdentity.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabWizardIdentity.Controls.Add(Me.LblLockedParentCaption)
        Me.TabWizardIdentity.Controls.Add(Me.LblLockedParent)
        Me.TabWizardIdentity.Controls.Add(Me.LblSiteName)
        Me.TabWizardIdentity.Controls.Add(Me.TxtSiteName)
        Me.TabWizardIdentity.Controls.Add(Me.LblSiteAddress)
        Me.TabWizardIdentity.Controls.Add(Me.TxtSiteAddress)
        Me.TabWizardIdentity.Location = New System.Drawing.Point(4, 5)
        Me.TabWizardIdentity.Name = "TabWizardIdentity"
        Me.TabWizardIdentity.Size = New System.Drawing.Size(484, 466)
        Me.TabWizardIdentity.TabIndex = 0
        Me.TabWizardIdentity.Text = "Identity"
        '
        'LblLockedParentCaption
        '
        Me.LblLockedParentCaption.AutoSize = True
        Me.LblLockedParentCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblLockedParentCaption.ForeColor = System.Drawing.Color.Teal
        Me.LblLockedParentCaption.Location = New System.Drawing.Point(28, 24)
        Me.LblLockedParentCaption.Name = "LblLockedParentCaption"
        Me.LblLockedParentCaption.Size = New System.Drawing.Size(143, 12)
        Me.LblLockedParentCaption.TabIndex = 0
        Me.LblLockedParentCaption.Text = "LOCKED PARENT CLIENT"
        '
        'LblLockedParent
        '
        Me.LblLockedParent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblLockedParent.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.LblLockedParent.Location = New System.Drawing.Point(28, 48)
        Me.LblLockedParent.Name = "LblLockedParent"
        Me.LblLockedParent.Padding = New System.Windows.Forms.Padding(10)
        Me.LblLockedParent.Size = New System.Drawing.Size(438, 44)
        Me.LblLockedParent.TabIndex = 1
        '
        'LblSiteName
        '
        Me.LblSiteName.AutoSize = True
        Me.LblSiteName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblSiteName.Location = New System.Drawing.Point(28, 116)
        Me.LblSiteName.Name = "LblSiteName"
        Me.LblSiteName.Size = New System.Drawing.Size(232, 15)
        Me.LblSiteName.TabIndex = 2
        Me.LblSiteName.Text = "Subclient or detachment name  • Required"
        '
        'TxtSiteName
        '
        Me.TxtSiteName.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtSiteName.Location = New System.Drawing.Point(28, 142)
        Me.TxtSiteName.MaxLength = 255
        Me.TxtSiteName.Name = "TxtSiteName"
        Me.TxtSiteName.Size = New System.Drawing.Size(438, 24)
        Me.TxtSiteName.TabIndex = 3
        '
        'LblSiteAddress
        '
        Me.LblSiteAddress.AutoSize = True
        Me.LblSiteAddress.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblSiteAddress.Location = New System.Drawing.Point(28, 194)
        Me.LblSiteAddress.Name = "LblSiteAddress"
        Me.LblSiteAddress.Size = New System.Drawing.Size(149, 15)
        Me.LblSiteAddress.TabIndex = 4
        Me.LblSiteAddress.Text = "Service address  • Required"
        '
        'TxtSiteAddress
        '
        Me.TxtSiteAddress.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtSiteAddress.Location = New System.Drawing.Point(28, 220)
        Me.TxtSiteAddress.MaxLength = 255
        Me.TxtSiteAddress.Name = "TxtSiteAddress"
        Me.TxtSiteAddress.Size = New System.Drawing.Size(438, 24)
        Me.TxtSiteAddress.TabIndex = 5
        '
        'TabWizardPayroll
        '
        Me.TabWizardPayroll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabWizardPayroll.Controls.Add(Me.LblSchedule)
        Me.TabWizardPayroll.Controls.Add(Me.CmbSchedule)
        Me.TabWizardPayroll.Controls.Add(Me.LblDailyWage)
        Me.TabWizardPayroll.Controls.Add(Me.TxtDailyWage)
        Me.TabWizardPayroll.Controls.Add(Me.LblContactPerson)
        Me.TabWizardPayroll.Controls.Add(Me.TxtContactPerson)
        Me.TabWizardPayroll.Controls.Add(Me.LblContactNumber)
        Me.TabWizardPayroll.Controls.Add(Me.TxtContactNumber)
        Me.TabWizardPayroll.Controls.Add(Me.LblContactEmail)
        Me.TabWizardPayroll.Controls.Add(Me.TxtContactEmail)
        Me.TabWizardPayroll.Location = New System.Drawing.Point(4, 5)
        Me.TabWizardPayroll.Name = "TabWizardPayroll"
        Me.TabWizardPayroll.Size = New System.Drawing.Size(484, 466)
        Me.TabWizardPayroll.TabIndex = 1
        Me.TabWizardPayroll.Text = "Payroll and contacts"
        '
        'LblSchedule
        '
        Me.LblSchedule.AutoSize = True
        Me.LblSchedule.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblSchedule.Location = New System.Drawing.Point(28, 32)
        Me.LblSchedule.Name = "LblSchedule"
        Me.LblSchedule.Size = New System.Drawing.Size(154, 15)
        Me.LblSchedule.TabIndex = 0
        Me.LblSchedule.Text = "Payroll schedule  • Required"
        '
        'CmbSchedule
        '
        Me.CmbSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSchedule.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.CmbSchedule.Items.AddRange(New Object() {"2SHIFTS", "TRI_SHIFT", "TIME_SPECIFIC"})
        Me.CmbSchedule.Location = New System.Drawing.Point(28, 58)
        Me.CmbSchedule.Name = "CmbSchedule"
        Me.CmbSchedule.Size = New System.Drawing.Size(210, 25)
        Me.CmbSchedule.TabIndex = 1
        '
        'LblDailyWage
        '
        Me.LblDailyWage.AutoSize = True
        Me.LblDailyWage.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblDailyWage.Location = New System.Drawing.Point(258, 32)
        Me.LblDailyWage.Name = "LblDailyWage"
        Me.LblDailyWage.Size = New System.Drawing.Size(126, 15)
        Me.LblDailyWage.TabIndex = 2
        Me.LblDailyWage.Text = "Daily wage  • Required"
        '
        'TxtDailyWage
        '
        Me.TxtDailyWage.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtDailyWage.Location = New System.Drawing.Point(258, 58)
        Me.TxtDailyWage.MaxLength = 7
        Me.TxtDailyWage.Name = "TxtDailyWage"
        Me.TxtDailyWage.Size = New System.Drawing.Size(208, 24)
        Me.TxtDailyWage.TabIndex = 3
        '
        'LblContactPerson
        '
        Me.LblContactPerson.AutoSize = True
        Me.LblContactPerson.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblContactPerson.Location = New System.Drawing.Point(28, 116)
        Me.LblContactPerson.Name = "LblContactPerson"
        Me.LblContactPerson.Size = New System.Drawing.Size(87, 15)
        Me.LblContactPerson.TabIndex = 4
        Me.LblContactPerson.Text = "Contact person"
        '
        'TxtContactPerson
        '
        Me.TxtContactPerson.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtContactPerson.Location = New System.Drawing.Point(28, 142)
        Me.TxtContactPerson.MaxLength = 255
        Me.TxtContactPerson.Name = "TxtContactPerson"
        Me.TxtContactPerson.Size = New System.Drawing.Size(438, 24)
        Me.TxtContactPerson.TabIndex = 5
        '
        'LblContactNumber
        '
        Me.LblContactNumber.AutoSize = True
        Me.LblContactNumber.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblContactNumber.Location = New System.Drawing.Point(28, 198)
        Me.LblContactNumber.Name = "LblContactNumber"
        Me.LblContactNumber.Size = New System.Drawing.Size(93, 15)
        Me.LblContactNumber.TabIndex = 6
        Me.LblContactNumber.Text = "Contact number"
        '
        'TxtContactNumber
        '
        Me.TxtContactNumber.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtContactNumber.Location = New System.Drawing.Point(28, 224)
        Me.TxtContactNumber.MaxLength = 30
        Me.TxtContactNumber.Name = "TxtContactNumber"
        Me.TxtContactNumber.Size = New System.Drawing.Size(210, 24)
        Me.TxtContactNumber.TabIndex = 7
        '
        'LblContactEmail
        '
        Me.LblContactEmail.AutoSize = True
        Me.LblContactEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblContactEmail.Location = New System.Drawing.Point(258, 198)
        Me.LblContactEmail.Name = "LblContactEmail"
        Me.LblContactEmail.Size = New System.Drawing.Size(80, 15)
        Me.LblContactEmail.TabIndex = 8
        Me.LblContactEmail.Text = "Contact email"
        '
        'TxtContactEmail
        '
        Me.TxtContactEmail.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtContactEmail.Location = New System.Drawing.Point(258, 224)
        Me.TxtContactEmail.MaxLength = 255
        Me.TxtContactEmail.Name = "TxtContactEmail"
        Me.TxtContactEmail.Size = New System.Drawing.Size(208, 24)
        Me.TxtContactEmail.TabIndex = 9
        '
        'TabWizardContract
        '
        Me.TabWizardContract.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabWizardContract.Controls.Add(Me.PnlInitialContract)
        Me.TabWizardContract.Location = New System.Drawing.Point(4, 5)
        Me.TabWizardContract.Name = "TabWizardContract"
        Me.TabWizardContract.Size = New System.Drawing.Size(484, 466)
        Me.TabWizardContract.TabIndex = 2
        Me.TabWizardContract.Text = "Initial contract"
        '
        'PnlInitialContract
        '
        Me.PnlInitialContract.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.PnlInitialContract.Controls.Add(Me.LblInitialContractTitle)
        Me.PnlInitialContract.Controls.Add(Me.LblInitialContractHelp)
        Me.PnlInitialContract.Controls.Add(Me.DtpInitialContractStart)
        Me.PnlInitialContract.Controls.Add(Me.DtpInitialContractEnd)
        Me.PnlInitialContract.Controls.Add(Me.BtnChooseInitialContract)
        Me.PnlInitialContract.Controls.Add(Me.LblInitialContractFile)
        Me.PnlInitialContract.Controls.Add(Me.TxtInitialContractRemarks)
        Me.PnlInitialContract.Location = New System.Drawing.Point(28, 24)
        Me.PnlInitialContract.Name = "PnlInitialContract"
        Me.PnlInitialContract.Size = New System.Drawing.Size(438, 250)
        Me.PnlInitialContract.TabIndex = 0
        '
        'LblInitialContractTitle
        '
        Me.LblInitialContractTitle.AutoSize = True
        Me.LblInitialContractTitle.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.LblInitialContractTitle.Location = New System.Drawing.Point(12, 12)
        Me.LblInitialContractTitle.Name = "LblInitialContractTitle"
        Me.LblInitialContractTitle.Size = New System.Drawing.Size(103, 18)
        Me.LblInitialContractTitle.TabIndex = 0
        Me.LblInitialContractTitle.Text = "Initial contract"
        '
        'LblInitialContractHelp
        '
        Me.LblInitialContractHelp.AutoSize = True
        Me.LblInitialContractHelp.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LblInitialContractHelp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblInitialContractHelp.Location = New System.Drawing.Point(14, 38)
        Me.LblInitialContractHelp.Name = "LblInitialContractHelp"
        Me.LblInitialContractHelp.Size = New System.Drawing.Size(190, 13)
        Me.LblInitialContractHelp.TabIndex = 1
        Me.LblInitialContractHelp.Text = "Required when creating a subclient"
        '
        'DtpInitialContractStart
        '
        Me.DtpInitialContractStart.CustomFormat = "dd MMM yyyy"
        Me.DtpInitialContractStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpInitialContractStart.Location = New System.Drawing.Point(14, 68)
        Me.DtpInitialContractStart.Name = "DtpInitialContractStart"
        Me.DtpInitialContractStart.Size = New System.Drawing.Size(190, 23)
        Me.DtpInitialContractStart.TabIndex = 2
        '
        'DtpInitialContractEnd
        '
        Me.DtpInitialContractEnd.CustomFormat = "dd MMM yyyy"
        Me.DtpInitialContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpInitialContractEnd.Location = New System.Drawing.Point(220, 68)
        Me.DtpInitialContractEnd.Name = "DtpInitialContractEnd"
        Me.DtpInitialContractEnd.Size = New System.Drawing.Size(202, 23)
        Me.DtpInitialContractEnd.TabIndex = 3
        '
        'BtnChooseInitialContract
        '
        Me.BtnChooseInitialContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnChooseInitialContract.Location = New System.Drawing.Point(14, 108)
        Me.BtnChooseInitialContract.Name = "BtnChooseInitialContract"
        Me.BtnChooseInitialContract.Size = New System.Drawing.Size(138, 32)
        Me.BtnChooseInitialContract.TabIndex = 4
        Me.BtnChooseInitialContract.Text = "Choose contract file"
        '
        'LblInitialContractFile
        '
        Me.LblInitialContractFile.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LblInitialContractFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblInitialContractFile.Location = New System.Drawing.Point(164, 112)
        Me.LblInitialContractFile.Name = "LblInitialContractFile"
        Me.LblInitialContractFile.Size = New System.Drawing.Size(258, 32)
        Me.LblInitialContractFile.TabIndex = 5
        Me.LblInitialContractFile.Text = "PDF or JPG, up to 10 MB"
        '
        'TxtInitialContractRemarks
        '
        Me.TxtInitialContractRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtInitialContractRemarks.Location = New System.Drawing.Point(14, 158)
        Me.TxtInitialContractRemarks.MaxLength = 255
        Me.TxtInitialContractRemarks.Multiline = True
        Me.TxtInitialContractRemarks.Name = "TxtInitialContractRemarks"
        Me.TxtInitialContractRemarks.Size = New System.Drawing.Size(408, 72)
        Me.TxtInitialContractRemarks.TabIndex = 6
        '
        'WizardProgressPanel
        '
        Me.WizardProgressPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WizardProgressPanel.Controls.Add(Me.LblWizardStepOne)
        Me.WizardProgressPanel.Controls.Add(Me.LblWizardStepTwo)
        Me.WizardProgressPanel.Controls.Add(Me.LblWizardStepThree)
        Me.WizardProgressPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.WizardProgressPanel.Location = New System.Drawing.Point(0, 0)
        Me.WizardProgressPanel.Name = "WizardProgressPanel"
        Me.WizardProgressPanel.Size = New System.Drawing.Size(492, 58)
        Me.WizardProgressPanel.TabIndex = 1
        '
        'LblWizardStepOne
        '
        Me.LblWizardStepOne.Font = New System.Drawing.Font("Segoe UI Semibold", 8.75!)
        Me.LblWizardStepOne.ForeColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.LblWizardStepOne.Location = New System.Drawing.Point(22, 14)
        Me.LblWizardStepOne.Name = "LblWizardStepOne"
        Me.LblWizardStepOne.Size = New System.Drawing.Size(140, 30)
        Me.LblWizardStepOne.TabIndex = 0
        Me.LblWizardStepOne.Text = "1  Identity"
        Me.LblWizardStepOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblWizardStepTwo
        '
        Me.LblWizardStepTwo.Font = New System.Drawing.Font("Segoe UI Semibold", 8.75!)
        Me.LblWizardStepTwo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblWizardStepTwo.Location = New System.Drawing.Point(174, 14)
        Me.LblWizardStepTwo.Name = "LblWizardStepTwo"
        Me.LblWizardStepTwo.Size = New System.Drawing.Size(170, 30)
        Me.LblWizardStepTwo.TabIndex = 1
        Me.LblWizardStepTwo.Text = "2  Payroll & contacts"
        Me.LblWizardStepTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblWizardStepThree
        '
        Me.LblWizardStepThree.Font = New System.Drawing.Font("Segoe UI Semibold", 8.75!)
        Me.LblWizardStepThree.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblWizardStepThree.Location = New System.Drawing.Point(356, 14)
        Me.LblWizardStepThree.Name = "LblWizardStepThree"
        Me.LblWizardStepThree.Size = New System.Drawing.Size(150, 30)
        Me.LblWizardStepThree.TabIndex = 2
        Me.LblWizardStepThree.Text = "3  Initial contract"
        Me.LblWizardStepThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabContractEditor
        '
        Me.TabContractEditor.AutoScroll = True
        Me.TabContractEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabContractEditor.Controls.Add(Me.LblContractContext)
        Me.TabContractEditor.Controls.Add(Me.LblContractStart)
        Me.TabContractEditor.Controls.Add(Me.DtpContractStart)
        Me.TabContractEditor.Controls.Add(Me.LblContractEnd)
        Me.TabContractEditor.Controls.Add(Me.DtpContractEnd)
        Me.TabContractEditor.Controls.Add(Me.BtnChooseContract)
        Me.TabContractEditor.Controls.Add(Me.LblContractFile)
        Me.TabContractEditor.Controls.Add(Me.LblContractRemarks)
        Me.TabContractEditor.Controls.Add(Me.TxtContractRemarks)
        Me.TabContractEditor.Location = New System.Drawing.Point(4, 5)
        Me.TabContractEditor.Name = "TabContractEditor"
        Me.TabContractEditor.Size = New System.Drawing.Size(492, 533)
        Me.TabContractEditor.TabIndex = 2
        '
        'LblContractContext
        '
        Me.LblContractContext.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblContractContext.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.LblContractContext.Location = New System.Drawing.Point(22, 20)
        Me.LblContractContext.Name = "LblContractContext"
        Me.LblContractContext.Padding = New System.Windows.Forms.Padding(10)
        Me.LblContractContext.Size = New System.Drawing.Size(438, 44)
        Me.LblContractContext.TabIndex = 0
        '
        'LblContractStart
        '
        Me.LblContractStart.AutoSize = True
        Me.LblContractStart.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblContractStart.Location = New System.Drawing.Point(22, 92)
        Me.LblContractStart.Name = "LblContractStart"
        Me.LblContractStart.Size = New System.Drawing.Size(144, 15)
        Me.LblContractStart.TabIndex = 1
        Me.LblContractStart.Text = "Contract starts  • Required"
        '
        'DtpContractStart
        '
        Me.DtpContractStart.CustomFormat = "dd MMM yyyy"
        Me.DtpContractStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpContractStart.Location = New System.Drawing.Point(22, 116)
        Me.DtpContractStart.Name = "DtpContractStart"
        Me.DtpContractStart.Size = New System.Drawing.Size(438, 23)
        Me.DtpContractStart.TabIndex = 2
        '
        'LblContractEnd
        '
        Me.LblContractEnd.AutoSize = True
        Me.LblContractEnd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblContractEnd.Location = New System.Drawing.Point(22, 162)
        Me.LblContractEnd.Name = "LblContractEnd"
        Me.LblContractEnd.Size = New System.Drawing.Size(141, 15)
        Me.LblContractEnd.TabIndex = 3
        Me.LblContractEnd.Text = "Contract ends  • Required"
        '
        'DtpContractEnd
        '
        Me.DtpContractEnd.CustomFormat = "dd MMM yyyy"
        Me.DtpContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpContractEnd.Location = New System.Drawing.Point(22, 186)
        Me.DtpContractEnd.Name = "DtpContractEnd"
        Me.DtpContractEnd.Size = New System.Drawing.Size(438, 23)
        Me.DtpContractEnd.TabIndex = 4
        '
        'BtnChooseContract
        '
        Me.BtnChooseContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnChooseContract.Location = New System.Drawing.Point(22, 238)
        Me.BtnChooseContract.Name = "BtnChooseContract"
        Me.BtnChooseContract.Size = New System.Drawing.Size(154, 34)
        Me.BtnChooseContract.TabIndex = 5
        Me.BtnChooseContract.Text = "Choose attachment"
        '
        'LblContractFile
        '
        Me.LblContractFile.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblContractFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblContractFile.Location = New System.Drawing.Point(190, 242)
        Me.LblContractFile.Name = "LblContractFile"
        Me.LblContractFile.Size = New System.Drawing.Size(270, 32)
        Me.LblContractFile.TabIndex = 6
        Me.LblContractFile.Text = "PDF or JPG, up to 10 MB"
        '
        'LblContractRemarks
        '
        Me.LblContractRemarks.AutoSize = True
        Me.LblContractRemarks.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblContractRemarks.Location = New System.Drawing.Point(22, 300)
        Me.LblContractRemarks.Name = "LblContractRemarks"
        Me.LblContractRemarks.Size = New System.Drawing.Size(84, 15)
        Me.LblContractRemarks.TabIndex = 7
        Me.LblContractRemarks.Text = "Contract notes"
        '
        'TxtContractRemarks
        '
        Me.TxtContractRemarks.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtContractRemarks.Location = New System.Drawing.Point(22, 324)
        Me.TxtContractRemarks.MaxLength = 255
        Me.TxtContractRemarks.Multiline = True
        Me.TxtContractRemarks.Name = "TxtContractRemarks"
        Me.TxtContractRemarks.Size = New System.Drawing.Size(438, 100)
        Me.TxtContractRemarks.TabIndex = 8
        '
        'TabStatusEditor
        '
        Me.TabStatusEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabStatusEditor.Controls.Add(Me.LblStatusContext)
        Me.TabStatusEditor.Controls.Add(Me.LblStatusEffective)
        Me.TabStatusEditor.Controls.Add(Me.DtpStatusEffective)
        Me.TabStatusEditor.Controls.Add(Me.LblStatusReason)
        Me.TabStatusEditor.Controls.Add(Me.CmbStatusReason)
        Me.TabStatusEditor.Controls.Add(Me.LblStatusNote)
        Me.TabStatusEditor.Location = New System.Drawing.Point(4, 5)
        Me.TabStatusEditor.Name = "TabStatusEditor"
        Me.TabStatusEditor.Size = New System.Drawing.Size(492, 533)
        Me.TabStatusEditor.TabIndex = 3
        '
        'LblStatusContext
        '
        Me.LblStatusContext.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblStatusContext.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.LblStatusContext.Location = New System.Drawing.Point(22, 20)
        Me.LblStatusContext.Name = "LblStatusContext"
        Me.LblStatusContext.Padding = New System.Windows.Forms.Padding(10)
        Me.LblStatusContext.Size = New System.Drawing.Size(438, 58)
        Me.LblStatusContext.TabIndex = 0
        '
        'LblStatusEffective
        '
        Me.LblStatusEffective.AutoSize = True
        Me.LblStatusEffective.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblStatusEffective.Location = New System.Drawing.Point(22, 112)
        Me.LblStatusEffective.Name = "LblStatusEffective"
        Me.LblStatusEffective.Size = New System.Drawing.Size(139, 15)
        Me.LblStatusEffective.TabIndex = 1
        Me.LblStatusEffective.Text = "Effective date  • Required"
        '
        'DtpStatusEffective
        '
        Me.DtpStatusEffective.CustomFormat = "dd MMM yyyy"
        Me.DtpStatusEffective.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpStatusEffective.Location = New System.Drawing.Point(22, 136)
        Me.DtpStatusEffective.Name = "DtpStatusEffective"
        Me.DtpStatusEffective.Size = New System.Drawing.Size(438, 23)
        Me.DtpStatusEffective.TabIndex = 2
        '
        'LblStatusReason
        '
        Me.LblStatusReason.AutoSize = True
        Me.LblStatusReason.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblStatusReason.Location = New System.Drawing.Point(22, 188)
        Me.LblStatusReason.Name = "LblStatusReason"
        Me.LblStatusReason.Size = New System.Drawing.Size(106, 15)
        Me.LblStatusReason.TabIndex = 3
        Me.LblStatusReason.Text = "Reason  • Required"
        '
        'CmbStatusReason
        '
        Me.CmbStatusReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStatusReason.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.CmbStatusReason.Location = New System.Drawing.Point(22, 212)
        Me.CmbStatusReason.Name = "CmbStatusReason"
        Me.CmbStatusReason.Size = New System.Drawing.Size(438, 25)
        Me.CmbStatusReason.TabIndex = 4
        '
        'LblStatusNote
        '
        Me.LblStatusNote.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.LblStatusNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblStatusNote.Location = New System.Drawing.Point(22, 266)
        Me.LblStatusNote.Name = "LblStatusNote"
        Me.LblStatusNote.Size = New System.Drawing.Size(438, 62)
        Me.LblStatusNote.TabIndex = 5
        Me.LblStatusNote.Text = "The record changes only after an effective date and audit reason are provided."
        '
        'EditorFooterPanel
        '
        Me.EditorFooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EditorFooterPanel.Controls.Add(Me.LblEditorMessage)
        Me.EditorFooterPanel.Controls.Add(Me.EditorActionFlow)
        Me.EditorFooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EditorFooterPanel.Location = New System.Drawing.Point(0, 646)
        Me.EditorFooterPanel.Name = "EditorFooterPanel"
        Me.EditorFooterPanel.Size = New System.Drawing.Size(500, 88)
        Me.EditorFooterPanel.TabIndex = 1
        '
        'LblEditorMessage
        '
        Me.LblEditorMessage.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!)
        Me.LblEditorMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.LblEditorMessage.Location = New System.Drawing.Point(22, 8)
        Me.LblEditorMessage.Name = "LblEditorMessage"
        Me.LblEditorMessage.Size = New System.Drawing.Size(480, 56)
        Me.LblEditorMessage.TabIndex = 0
        '
        'EditorActionFlow
        '
        Me.EditorActionFlow.AutoSize = True
        Me.EditorActionFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.EditorActionFlow.Controls.Add(Me.BtnEditorBack)
        Me.EditorActionFlow.Controls.Add(Me.BtnCancelEditor)
        Me.EditorActionFlow.Controls.Add(Me.BtnEditorNext)
        Me.EditorActionFlow.Controls.Add(Me.BtnSaveEditor)
        Me.EditorActionFlow.Dock = System.Windows.Forms.DockStyle.Right
        Me.EditorActionFlow.Location = New System.Drawing.Point(-28, 0)
        Me.EditorActionFlow.MinimumSize = New System.Drawing.Size(0, 90)
        Me.EditorActionFlow.Name = "EditorActionFlow"
        Me.EditorActionFlow.Padding = New System.Windows.Forms.Padding(0, 42, 8, 0)
        Me.EditorActionFlow.Size = New System.Drawing.Size(528, 90)
        Me.EditorActionFlow.TabIndex = 1
        Me.EditorActionFlow.WrapContents = False
        '
        'BtnEditorBack
        '
        Me.BtnEditorBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditorBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BtnEditorBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnEditorBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEditorBack.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnEditorBack.Location = New System.Drawing.Point(6, 42)
        Me.BtnEditorBack.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BtnEditorBack.Name = "BtnEditorBack"
        Me.BtnEditorBack.Size = New System.Drawing.Size(112, 36)
        Me.BtnEditorBack.TabIndex = 0
        Me.BtnEditorBack.Text = "Back"
        Me.BtnEditorBack.UseVisualStyleBackColor = False
        Me.BtnEditorBack.Visible = False
        '
        'BtnCancelEditor
        '
        Me.BtnCancelEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BtnCancelEditor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnCancelEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelEditor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnCancelEditor.Location = New System.Drawing.Point(124, 42)
        Me.BtnCancelEditor.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BtnCancelEditor.Name = "BtnCancelEditor"
        Me.BtnCancelEditor.Size = New System.Drawing.Size(112, 36)
        Me.BtnCancelEditor.TabIndex = 1
        Me.BtnCancelEditor.Text = "Cancel"
        Me.BtnCancelEditor.UseVisualStyleBackColor = False
        '
        'BtnEditorNext
        '
        Me.BtnEditorNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditorNext.BackColor = System.Drawing.Color.Teal
        Me.BtnEditorNext.FlatAppearance.BorderSize = 0
        Me.BtnEditorNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEditorNext.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnEditorNext.ForeColor = System.Drawing.Color.White
        Me.BtnEditorNext.Location = New System.Drawing.Point(242, 42)
        Me.BtnEditorNext.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BtnEditorNext.Name = "BtnEditorNext"
        Me.BtnEditorNext.Size = New System.Drawing.Size(112, 36)
        Me.BtnEditorNext.TabIndex = 2
        Me.BtnEditorNext.Text = "Continue"
        Me.BtnEditorNext.UseVisualStyleBackColor = False
        Me.BtnEditorNext.Visible = False
        '
        'BtnSaveEditor
        '
        Me.BtnSaveEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveEditor.BackColor = System.Drawing.Color.Teal
        Me.BtnSaveEditor.FlatAppearance.BorderSize = 0
        Me.BtnSaveEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSaveEditor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnSaveEditor.ForeColor = System.Drawing.Color.White
        Me.BtnSaveEditor.Location = New System.Drawing.Point(360, 42)
        Me.BtnSaveEditor.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BtnSaveEditor.Name = "BtnSaveEditor"
        Me.BtnSaveEditor.Size = New System.Drawing.Size(160, 36)
        Me.BtnSaveEditor.TabIndex = 3
        Me.BtnSaveEditor.Text = "Save changes"
        Me.BtnSaveEditor.UseVisualStyleBackColor = False
        '
        'EditorHeaderPanel
        '
        Me.EditorHeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.EditorHeaderPanel.Controls.Add(Me.LblEditorEyebrow)
        Me.EditorHeaderPanel.Controls.Add(Me.LblEditorTitle)
        Me.EditorHeaderPanel.Controls.Add(Me.LblEditorSubtitle)
        Me.EditorHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.EditorHeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.EditorHeaderPanel.Name = "EditorHeaderPanel"
        Me.EditorHeaderPanel.Size = New System.Drawing.Size(500, 104)
        Me.EditorHeaderPanel.TabIndex = 2
        '
        'LblEditorEyebrow
        '
        Me.LblEditorEyebrow.AutoSize = True
        Me.LblEditorEyebrow.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.LblEditorEyebrow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.LblEditorEyebrow.Location = New System.Drawing.Point(24, 16)
        Me.LblEditorEyebrow.Name = "LblEditorEyebrow"
        Me.LblEditorEyebrow.Size = New System.Drawing.Size(92, 13)
        Me.LblEditorEyebrow.TabIndex = 0
        Me.LblEditorEyebrow.Text = "EDIT RECORD"
        '
        'LblEditorTitle
        '
        Me.LblEditorTitle.AutoSize = True
        Me.LblEditorTitle.Font = New System.Drawing.Font("Bahnschrift SemiBold", 17.0!)
        Me.LblEditorTitle.ForeColor = System.Drawing.Color.White
        Me.LblEditorTitle.Location = New System.Drawing.Point(22, 38)
        Me.LblEditorTitle.Name = "LblEditorTitle"
        Me.LblEditorTitle.Size = New System.Drawing.Size(75, 28)
        Me.LblEditorTitle.TabIndex = 1
        Me.LblEditorTitle.Text = "Editor"
        '
        'LblEditorSubtitle
        '
        Me.LblEditorSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.8!)
        Me.LblEditorSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.LblEditorSubtitle.Location = New System.Drawing.Point(24, 70)
        Me.LblEditorSubtitle.Name = "LblEditorSubtitle"
        Me.LblEditorSubtitle.Size = New System.Drawing.Size(450, 26)
        Me.LblEditorSubtitle.TabIndex = 2
        '
        'MainCanvas
        '
        Me.MainCanvas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.MainCanvas.Controls.Add(Me.WorkspaceViews)
        Me.MainCanvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainCanvas.Location = New System.Drawing.Point(14, 0)
        Me.MainCanvas.Name = "MainCanvas"
        Me.MainCanvas.Size = New System.Drawing.Size(1194, 734)
        Me.MainCanvas.TabIndex = 1
        '
        'WorkspaceViews
        '
        Me.WorkspaceViews.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.WorkspaceViews.Controls.Add(Me.TabDirectoryView)
        Me.WorkspaceViews.Controls.Add(Me.TabWorkSiteProfile)
        Me.WorkspaceViews.Controls.Add(Me.TabContractMonitoring)
        Me.WorkspaceViews.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkspaceViews.ItemSize = New System.Drawing.Size(0, 1)
        Me.WorkspaceViews.Location = New System.Drawing.Point(0, 0)
        Me.WorkspaceViews.Name = "WorkspaceViews"
        Me.WorkspaceViews.Padding = New System.Drawing.Point(0, 0)
        Me.WorkspaceViews.SelectedIndex = 0
        Me.WorkspaceViews.Size = New System.Drawing.Size(1194, 734)
        Me.WorkspaceViews.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.WorkspaceViews.TabIndex = 0
        '
        'TabDirectoryView
        '
        Me.TabDirectoryView.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabDirectoryView.Controls.Add(Me.ContentSplit)
        Me.TabDirectoryView.Location = New System.Drawing.Point(4, 5)
        Me.TabDirectoryView.Name = "TabDirectoryView"
        Me.TabDirectoryView.Size = New System.Drawing.Size(1186, 725)
        Me.TabDirectoryView.TabIndex = 0
        Me.TabDirectoryView.Text = "Client directory"
        '
        'ContentSplit
        '
        Me.ContentSplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ContentSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.ContentSplit.Location = New System.Drawing.Point(0, 0)
        Me.ContentSplit.Name = "ContentSplit"
        '
        'ContentSplit.Panel1
        '
        Me.ContentSplit.Panel1.Controls.Add(Me.CompanyDirectoryPanel)
        Me.ContentSplit.Panel1MinSize = 300
        '
        'ContentSplit.Panel2
        '
        Me.ContentSplit.Panel2.Controls.Add(Me.CompanyWorkspaceLayout)
        Me.ContentSplit.Panel2MinSize = 500
        Me.ContentSplit.Size = New System.Drawing.Size(1186, 725)
        Me.ContentSplit.SplitterDistance = 520
        Me.ContentSplit.SplitterWidth = 1
        Me.ContentSplit.TabIndex = 0
        '
        'CompanyDirectoryPanel
        '
        Me.CompanyDirectoryPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CompanyDirectoryPanel.Controls.Add(Me.BtnAddCompany)
        Me.CompanyDirectoryPanel.Controls.Add(Me.LblCompaniesTitle)
        Me.CompanyDirectoryPanel.Controls.Add(Me.LblCompaniesCount)
        Me.CompanyDirectoryPanel.Controls.Add(Me.TxtCompanySearch)
        Me.CompanyDirectoryPanel.Controls.Add(Me.CmbCompanyStatus)
        Me.CompanyDirectoryPanel.Controls.Add(Me.BtnRefresh)
        Me.CompanyDirectoryPanel.Controls.Add(Me.LvCompanies)
        Me.CompanyDirectoryPanel.Controls.Add(Me.LblCompanySearch)
        Me.CompanyDirectoryPanel.Controls.Add(Me.LblCompanyStatusFilter)
        Me.CompanyDirectoryPanel.Controls.Add(Me.LblCompaniesEmpty)
        Me.CompanyDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompanyDirectoryPanel.Location = New System.Drawing.Point(0, 0)
        Me.CompanyDirectoryPanel.Name = "CompanyDirectoryPanel"
        Me.CompanyDirectoryPanel.Padding = New System.Windows.Forms.Padding(18)
        Me.CompanyDirectoryPanel.Size = New System.Drawing.Size(520, 725)
        Me.CompanyDirectoryPanel.TabIndex = 0
        '
        'BtnAddCompany
        '
        Me.BtnAddCompany.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddCompany.BackColor = System.Drawing.Color.Teal
        Me.BtnAddCompany.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAddCompany.FlatAppearance.BorderSize = 0
        Me.BtnAddCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddCompany.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnAddCompany.ForeColor = System.Drawing.Color.White
        Me.BtnAddCompany.Location = New System.Drawing.Point(390, 12)
        Me.BtnAddCompany.Name = "BtnAddCompany"
        Me.BtnAddCompany.Size = New System.Drawing.Size(112, 36)
        Me.BtnAddCompany.TabIndex = 3
        Me.BtnAddCompany.Text = "Add client"
        Me.BtnAddCompany.UseVisualStyleBackColor = False
        '
        'LblCompaniesTitle
        '
        Me.LblCompaniesTitle.AutoSize = True
        Me.LblCompaniesTitle.Font = New System.Drawing.Font("Bahnschrift SemiBold", 13.0!)
        Me.LblCompaniesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblCompaniesTitle.Location = New System.Drawing.Point(18, 16)
        Me.LblCompaniesTitle.Name = "LblCompaniesTitle"
        Me.LblCompaniesTitle.Size = New System.Drawing.Size(66, 22)
        Me.LblCompaniesTitle.TabIndex = 0
        Me.LblCompaniesTitle.Text = "Clients"
        '
        'LblCompaniesCount
        '
        Me.LblCompaniesCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCompaniesCount.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblCompaniesCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblCompaniesCount.Location = New System.Drawing.Point(262, 19)
        Me.LblCompaniesCount.Name = "LblCompaniesCount"
        Me.LblCompaniesCount.Size = New System.Drawing.Size(112, 19)
        Me.LblCompaniesCount.TabIndex = 1
        Me.LblCompaniesCount.Text = "0 records"
        Me.LblCompaniesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtCompanySearch
        '
        Me.TxtCompanySearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompanySearch.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtCompanySearch.Location = New System.Drawing.Point(18, 68)
        Me.TxtCompanySearch.Name = "TxtCompanySearch"
        Me.TxtCompanySearch.Size = New System.Drawing.Size(370, 24)
        Me.TxtCompanySearch.TabIndex = 2
        '
        'CmbCompanyStatus
        '
        Me.CmbCompanyStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbCompanyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCompanyStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CmbCompanyStatus.Items.AddRange(New Object() {"Active", "Inactive", "All"})
        Me.CmbCompanyStatus.Location = New System.Drawing.Point(396, 68)
        Me.CmbCompanyStatus.Name = "CmbCompanyStatus"
        Me.CmbCompanyStatus.Size = New System.Drawing.Size(106, 23)
        Me.CmbCompanyStatus.TabIndex = 3
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BtnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefresh.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.BtnRefresh.Location = New System.Drawing.Point(18, 100)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(484, 32)
        Me.BtnRefresh.TabIndex = 4
        Me.BtnRefresh.Text = "Reload client directory"
        Me.BtnRefresh.UseVisualStyleBackColor = False
        '
        'LvCompanies
        '
        Me.LvCompanies.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvCompanies.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LvCompanies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LvCompanies.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColCompanyCode, Me.ColCompany, Me.ColCompanyType, Me.ColSiteCount, Me.ColCompanyStatus})
        Me.LvCompanies.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LvCompanies.FullRowSelect = True
        Me.LvCompanies.GridLines = True
        Me.LvCompanies.HideSelection = False
        Me.LvCompanies.Location = New System.Drawing.Point(18, 142)
        Me.LvCompanies.MultiSelect = False
        Me.LvCompanies.Name = "LvCompanies"
        Me.LvCompanies.Size = New System.Drawing.Size(484, 565)
        Me.LvCompanies.TabIndex = 5
        Me.LvCompanies.UseCompatibleStateImageBehavior = False
        Me.LvCompanies.View = System.Windows.Forms.View.Details
        '
        'ColCompanyCode
        '
        Me.ColCompanyCode.Name = "ColCompanyCode"
        Me.ColCompanyCode.Text = "Ref."
        Me.ColCompanyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColCompanyCode.Width = 52
        '
        'ColCompany
        '
        Me.ColCompany.Name = "ColCompany"
        Me.ColCompany.Text = "Client"
        Me.ColCompany.Width = 150
        '
        'ColCompanyType
        '
        Me.ColCompanyType.Name = "ColCompanyType"
        Me.ColCompanyType.Text = "Type"
        Me.ColCompanyType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColCompanyType.Width = 88
        '
        'ColSiteCount
        '
        Me.ColSiteCount.Name = "ColSiteCount"
        Me.ColSiteCount.Text = "Subclients"
        Me.ColSiteCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColSiteCount.Width = 80
        '
        'ColCompanyStatus
        '
        Me.ColCompanyStatus.Name = "ColCompanyStatus"
        Me.ColCompanyStatus.Text = "Status"
        Me.ColCompanyStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColCompanyStatus.Width = 66
        '
        'LblCompanySearch
        '
        Me.LblCompanySearch.AutoSize = True
        Me.LblCompanySearch.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!)
        Me.LblCompanySearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.LblCompanySearch.Location = New System.Drawing.Point(18, 48)
        Me.LblCompanySearch.Name = "LblCompanySearch"
        Me.LblCompanySearch.Size = New System.Drawing.Size(68, 13)
        Me.LblCompanySearch.TabIndex = 6
        Me.LblCompanySearch.Text = "Find a client"
        '
        'LblCompanyStatusFilter
        '
        Me.LblCompanyStatusFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCompanyStatusFilter.AutoSize = True
        Me.LblCompanyStatusFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!)
        Me.LblCompanyStatusFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.LblCompanyStatusFilter.Location = New System.Drawing.Point(396, 48)
        Me.LblCompanyStatusFilter.Name = "LblCompanyStatusFilter"
        Me.LblCompanyStatusFilter.Size = New System.Drawing.Size(38, 13)
        Me.LblCompanyStatusFilter.TabIndex = 7
        Me.LblCompanyStatusFilter.Text = "Status"
        '
        'LblCompaniesEmpty
        '
        Me.LblCompaniesEmpty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCompaniesEmpty.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblCompaniesEmpty.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.LblCompaniesEmpty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblCompaniesEmpty.Location = New System.Drawing.Point(38, 214)
        Me.LblCompaniesEmpty.Name = "LblCompaniesEmpty"
        Me.LblCompaniesEmpty.Size = New System.Drawing.Size(444, 72)
        Me.LblCompaniesEmpty.TabIndex = 8
        Me.LblCompaniesEmpty.Text = "No clients match this search." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Clear the filters or add a client."
        Me.LblCompaniesEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblCompaniesEmpty.Visible = False
        '
        'CompanyWorkspaceLayout
        '
        Me.CompanyWorkspaceLayout.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CompanyWorkspaceLayout.ColumnCount = 1
        Me.CompanyWorkspaceLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.CompanyWorkspaceLayout.Controls.Add(Me.HierarchyPanel, 0, 0)
        Me.CompanyWorkspaceLayout.Controls.Add(Me.WorkSitesPanel, 0, 1)
        Me.CompanyWorkspaceLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CompanyWorkspaceLayout.Location = New System.Drawing.Point(0, 0)
        Me.CompanyWorkspaceLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.CompanyWorkspaceLayout.Name = "CompanyWorkspaceLayout"
        Me.CompanyWorkspaceLayout.RowCount = 2
        Me.CompanyWorkspaceLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.CompanyWorkspaceLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.CompanyWorkspaceLayout.Size = New System.Drawing.Size(835, 725)
        Me.CompanyWorkspaceLayout.TabIndex = 0
        '
        'HierarchyPanel
        '
        Me.HierarchyPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.HierarchyPanel.Controls.Add(Me.LblHierarchyCompanyCaption)
        Me.HierarchyPanel.Controls.Add(Me.LblHierarchyCompany)
        Me.HierarchyPanel.Controls.Add(Me.BtnEditCompany)
        Me.HierarchyPanel.Controls.Add(Me.BtnCompanyStatus)
        Me.HierarchyPanel.Controls.Add(Me.LblWorkspaceMessage)
        Me.HierarchyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HierarchyPanel.Location = New System.Drawing.Point(3, 3)
        Me.HierarchyPanel.Name = "HierarchyPanel"
        Me.HierarchyPanel.Size = New System.Drawing.Size(829, 98)
        Me.HierarchyPanel.TabIndex = 0
        '
        'LblHierarchyCompanyCaption
        '
        Me.LblHierarchyCompanyCaption.AutoSize = True
        Me.LblHierarchyCompanyCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblHierarchyCompanyCaption.ForeColor = System.Drawing.Color.Teal
        Me.LblHierarchyCompanyCaption.Location = New System.Drawing.Point(20, 15)
        Me.LblHierarchyCompanyCaption.Name = "LblHierarchyCompanyCaption"
        Me.LblHierarchyCompanyCaption.Size = New System.Drawing.Size(104, 12)
        Me.LblHierarchyCompanyCaption.TabIndex = 0
        Me.LblHierarchyCompanyCaption.Text = "SELECTED CLIENT"
        '
        'LblHierarchyCompany
        '
        Me.LblHierarchyCompany.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.LblHierarchyCompany.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblHierarchyCompany.Location = New System.Drawing.Point(18, 37)
        Me.LblHierarchyCompany.Name = "LblHierarchyCompany"
        Me.LblHierarchyCompany.Size = New System.Drawing.Size(650, 26)
        Me.LblHierarchyCompany.TabIndex = 1
        Me.LblHierarchyCompany.Text = "No client selected"
        '
        'BtnEditCompany
        '
        Me.BtnEditCompany.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditCompany.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BtnEditCompany.Enabled = False
        Me.BtnEditCompany.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnEditCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEditCompany.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.BtnEditCompany.Location = New System.Drawing.Point(711, 19)
        Me.BtnEditCompany.Name = "BtnEditCompany"
        Me.BtnEditCompany.Size = New System.Drawing.Size(110, 32)
        Me.BtnEditCompany.TabIndex = 2
        Me.BtnEditCompany.Text = "Edit client"
        Me.BtnEditCompany.UseVisualStyleBackColor = False
        '
        'BtnCompanyStatus
        '
        Me.BtnCompanyStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCompanyStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BtnCompanyStatus.Enabled = False
        Me.BtnCompanyStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnCompanyStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCompanyStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.BtnCompanyStatus.Location = New System.Drawing.Point(711, 57)
        Me.BtnCompanyStatus.Name = "BtnCompanyStatus"
        Me.BtnCompanyStatus.Size = New System.Drawing.Size(110, 32)
        Me.BtnCompanyStatus.TabIndex = 3
        Me.BtnCompanyStatus.Text = "Change status"
        Me.BtnCompanyStatus.UseVisualStyleBackColor = False
        '
        'LblWorkspaceMessage
        '
        Me.LblWorkspaceMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblWorkspaceMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.LblWorkspaceMessage.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.LblWorkspaceMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.LblWorkspaceMessage.Location = New System.Drawing.Point(18, 68)
        Me.LblWorkspaceMessage.Name = "LblWorkspaceMessage"
        Me.LblWorkspaceMessage.Size = New System.Drawing.Size(675, 24)
        Me.LblWorkspaceMessage.TabIndex = 4
        Me.LblWorkspaceMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblWorkspaceMessage.Visible = False
        '
        'WorkSitesPanel
        '
        Me.WorkSitesPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WorkSitesPanel.Controls.Add(Me.LblWorkSitesTitle)
        Me.WorkSitesPanel.Controls.Add(Me.LblWorkSitesCount)
        Me.WorkSitesPanel.Controls.Add(Me.LvWorkSites)
        Me.WorkSitesPanel.Controls.Add(Me.BtnAddWorkSite)
        Me.WorkSitesPanel.Controls.Add(Me.BtnOpenWorkSite)
        Me.WorkSitesPanel.Controls.Add(Me.LblWorkSitesHelp)
        Me.WorkSitesPanel.Controls.Add(Me.LblWorkSitesEmpty)
        Me.WorkSitesPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkSitesPanel.Location = New System.Drawing.Point(3, 107)
        Me.WorkSitesPanel.Name = "WorkSitesPanel"
        Me.WorkSitesPanel.Size = New System.Drawing.Size(829, 615)
        Me.WorkSitesPanel.TabIndex = 1
        '
        'LblWorkSitesTitle
        '
        Me.LblWorkSitesTitle.AutoSize = True
        Me.LblWorkSitesTitle.Font = New System.Drawing.Font("Bahnschrift SemiBold", 12.0!)
        Me.LblWorkSitesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblWorkSitesTitle.Location = New System.Drawing.Point(18, 16)
        Me.LblWorkSitesTitle.Name = "LblWorkSitesTitle"
        Me.LblWorkSitesTitle.Size = New System.Drawing.Size(85, 19)
        Me.LblWorkSitesTitle.TabIndex = 0
        Me.LblWorkSitesTitle.Text = "Subclients"
        '
        'LblWorkSitesCount
        '
        Me.LblWorkSitesCount.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblWorkSitesCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblWorkSitesCount.Location = New System.Drawing.Point(132, 18)
        Me.LblWorkSitesCount.Name = "LblWorkSitesCount"
        Me.LblWorkSitesCount.Size = New System.Drawing.Size(124, 19)
        Me.LblWorkSitesCount.TabIndex = 1
        Me.LblWorkSitesCount.Text = "0 under client"
        Me.LblWorkSitesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LvWorkSites
        '
        Me.LvWorkSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvWorkSites.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LvWorkSites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LvWorkSites.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColSiteCode, Me.ColSiteName, Me.ColSiteAddress, Me.ColSiteStatus})
        Me.LvWorkSites.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LvWorkSites.FullRowSelect = True
        Me.LvWorkSites.GridLines = True
        Me.LvWorkSites.HideSelection = False
        Me.LvWorkSites.Location = New System.Drawing.Point(18, 68)
        Me.LvWorkSites.MultiSelect = False
        Me.LvWorkSites.Name = "LvWorkSites"
        Me.LvWorkSites.Size = New System.Drawing.Size(795, 547)
        Me.LvWorkSites.TabIndex = 2
        Me.LvWorkSites.UseCompatibleStateImageBehavior = False
        Me.LvWorkSites.View = System.Windows.Forms.View.Details
        '
        'ColSiteCode
        '
        Me.ColSiteCode.Name = "ColSiteCode"
        Me.ColSiteCode.Text = "Ref."
        Me.ColSiteCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColSiteCode.Width = 72
        '
        'ColSiteName
        '
        Me.ColSiteName.Name = "ColSiteName"
        Me.ColSiteName.Text = "Subclient"
        Me.ColSiteName.Width = 230
        '
        'ColSiteAddress
        '
        Me.ColSiteAddress.Name = "ColSiteAddress"
        Me.ColSiteAddress.Text = "Address"
        Me.ColSiteAddress.Width = 330
        '
        'ColSiteStatus
        '
        Me.ColSiteStatus.Name = "ColSiteStatus"
        Me.ColSiteStatus.Text = "Status"
        Me.ColSiteStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColSiteStatus.Width = 100
        '
        'BtnAddWorkSite
        '
        Me.BtnAddWorkSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddWorkSite.BackColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnAddWorkSite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAddWorkSite.Enabled = False
        Me.BtnAddWorkSite.FlatAppearance.BorderSize = 0
        Me.BtnAddWorkSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddWorkSite.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.BtnAddWorkSite.ForeColor = System.Drawing.Color.White
        Me.BtnAddWorkSite.Location = New System.Drawing.Point(559, 12)
        Me.BtnAddWorkSite.Name = "BtnAddWorkSite"
        Me.BtnAddWorkSite.Size = New System.Drawing.Size(132, 36)
        Me.BtnAddWorkSite.TabIndex = 3
        Me.BtnAddWorkSite.Text = "Add subclient"
        Me.BtnAddWorkSite.UseVisualStyleBackColor = False
        '
        'BtnOpenWorkSite
        '
        Me.BtnOpenWorkSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOpenWorkSite.BackColor = System.Drawing.Color.Teal
        Me.BtnOpenWorkSite.Enabled = False
        Me.BtnOpenWorkSite.FlatAppearance.BorderSize = 0
        Me.BtnOpenWorkSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpenWorkSite.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.BtnOpenWorkSite.ForeColor = System.Drawing.Color.White
        Me.BtnOpenWorkSite.Location = New System.Drawing.Point(701, 12)
        Me.BtnOpenWorkSite.Name = "BtnOpenWorkSite"
        Me.BtnOpenWorkSite.Size = New System.Drawing.Size(112, 36)
        Me.BtnOpenWorkSite.TabIndex = 4
        Me.BtnOpenWorkSite.Text = "Open profile"
        Me.BtnOpenWorkSite.UseVisualStyleBackColor = False
        '
        'LblWorkSitesHelp
        '
        Me.LblWorkSitesHelp.AutoSize = True
        Me.LblWorkSitesHelp.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblWorkSitesHelp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblWorkSitesHelp.Location = New System.Drawing.Point(18, 42)
        Me.LblWorkSitesHelp.Name = "LblWorkSitesHelp"
        Me.LblWorkSitesHelp.Size = New System.Drawing.Size(380, 15)
        Me.LblWorkSitesHelp.TabIndex = 5
        Me.LblWorkSitesHelp.Text = "Open a subclient to review its information, payroll setup and contracts."
        '
        'LblWorkSitesEmpty
        '
        Me.LblWorkSitesEmpty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblWorkSitesEmpty.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblWorkSitesEmpty.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.LblWorkSitesEmpty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblWorkSitesEmpty.Location = New System.Drawing.Point(100, 180)
        Me.LblWorkSitesEmpty.Name = "LblWorkSitesEmpty"
        Me.LblWorkSitesEmpty.Size = New System.Drawing.Size(589, 72)
        Me.LblWorkSitesEmpty.TabIndex = 6
        Me.LblWorkSitesEmpty.Text = "This client has no subclients yet." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Choose Add subclient to register its first pa" &
    "yroll or service location."
        Me.LblWorkSitesEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblWorkSitesEmpty.Visible = False
        '
        'TabWorkSiteProfile
        '
        Me.TabWorkSiteProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabWorkSiteProfile.Controls.Add(Me.DetailsTabs)
        Me.TabWorkSiteProfile.Controls.Add(Me.WorkSiteProfileHeader)
        Me.TabWorkSiteProfile.Location = New System.Drawing.Point(4, 5)
        Me.TabWorkSiteProfile.Name = "TabWorkSiteProfile"
        Me.TabWorkSiteProfile.Size = New System.Drawing.Size(1186, 725)
        Me.TabWorkSiteProfile.TabIndex = 1
        Me.TabWorkSiteProfile.Text = "Subclient profile"
        '
        'DetailsTabs
        '
        Me.DetailsTabs.Controls.Add(Me.TabOverview)
        Me.DetailsTabs.Controls.Add(Me.TabPayrollContacts)
        Me.DetailsTabs.Controls.Add(Me.TabContracts)
        Me.DetailsTabs.Controls.Add(Me.TabStatusHistory)
        Me.DetailsTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailsTabs.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.DetailsTabs.ItemSize = New System.Drawing.Size(165, 38)
        Me.DetailsTabs.Location = New System.Drawing.Point(0, 118)
        Me.DetailsTabs.Name = "DetailsTabs"
        Me.DetailsTabs.SelectedIndex = 0
        Me.DetailsTabs.Size = New System.Drawing.Size(1186, 607)
        Me.DetailsTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.DetailsTabs.TabIndex = 0
        '
        'TabOverview
        '
        Me.TabOverview.AutoScroll = True
        Me.TabOverview.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabOverview.Controls.Add(Me.LblOverviewName)
        Me.TabOverview.Controls.Add(Me.LblOverviewStatus)
        Me.TabOverview.Controls.Add(Me.LblOverviewAddressCaption)
        Me.TabOverview.Controls.Add(Me.LblOverviewAddress)
        Me.TabOverview.Controls.Add(Me.LblOverviewParentCaption)
        Me.TabOverview.Controls.Add(Me.LblOverviewParent)
        Me.TabOverview.Controls.Add(Me.LblOverviewNextStep)
        Me.TabOverview.Location = New System.Drawing.Point(4, 42)
        Me.TabOverview.Name = "TabOverview"
        Me.TabOverview.Size = New System.Drawing.Size(1178, 561)
        Me.TabOverview.TabIndex = 0
        Me.TabOverview.Text = "Overview"
        '
        'LblOverviewName
        '
        Me.LblOverviewName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblOverviewName.Font = New System.Drawing.Font("Bahnschrift SemiBold", 15.0!)
        Me.LblOverviewName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblOverviewName.Location = New System.Drawing.Point(22, 22)
        Me.LblOverviewName.Name = "LblOverviewName"
        Me.LblOverviewName.Size = New System.Drawing.Size(1308, 30)
        Me.LblOverviewName.TabIndex = 0
        Me.LblOverviewName.Text = "Select a subclient"
        Me.LblOverviewName.Visible = False
        '
        'LblOverviewStatus
        '
        Me.LblOverviewStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LblOverviewStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.LblOverviewStatus.ForeColor = System.Drawing.Color.Teal
        Me.LblOverviewStatus.Location = New System.Drawing.Point(24, 58)
        Me.LblOverviewStatus.Name = "LblOverviewStatus"
        Me.LblOverviewStatus.Size = New System.Drawing.Size(90, 26)
        Me.LblOverviewStatus.TabIndex = 1
        Me.LblOverviewStatus.Text = "No selection"
        Me.LblOverviewStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblOverviewStatus.Visible = False
        '
        'LblOverviewAddressCaption
        '
        Me.LblOverviewAddressCaption.AutoSize = True
        Me.LblOverviewAddressCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblOverviewAddressCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblOverviewAddressCaption.Location = New System.Drawing.Point(32, 32)
        Me.LblOverviewAddressCaption.Name = "LblOverviewAddressCaption"
        Me.LblOverviewAddressCaption.Size = New System.Drawing.Size(114, 12)
        Me.LblOverviewAddressCaption.TabIndex = 2
        Me.LblOverviewAddressCaption.Text = "SERVICE ADDRESS"
        '
        'LblOverviewAddress
        '
        Me.LblOverviewAddress.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.LblOverviewAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblOverviewAddress.Location = New System.Drawing.Point(32, 58)
        Me.LblOverviewAddress.Name = "LblOverviewAddress"
        Me.LblOverviewAddress.Size = New System.Drawing.Size(760, 54)
        Me.LblOverviewAddress.TabIndex = 3
        Me.LblOverviewAddress.Text = "—"
        '
        'LblOverviewParentCaption
        '
        Me.LblOverviewParentCaption.AutoSize = True
        Me.LblOverviewParentCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblOverviewParentCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.LblOverviewParentCaption.Location = New System.Drawing.Point(32, 126)
        Me.LblOverviewParentCaption.Name = "LblOverviewParentCaption"
        Me.LblOverviewParentCaption.Size = New System.Drawing.Size(94, 12)
        Me.LblOverviewParentCaption.TabIndex = 4
        Me.LblOverviewParentCaption.Text = "PARENT CLIENT"
        '
        'LblOverviewParent
        '
        Me.LblOverviewParent.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.LblOverviewParent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblOverviewParent.Location = New System.Drawing.Point(32, 150)
        Me.LblOverviewParent.Name = "LblOverviewParent"
        Me.LblOverviewParent.Size = New System.Drawing.Size(760, 28)
        Me.LblOverviewParent.TabIndex = 5
        Me.LblOverviewParent.Text = "No parent client selected"
        '
        'LblOverviewNextStep
        '
        Me.LblOverviewNextStep.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.LblOverviewNextStep.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblOverviewNextStep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.LblOverviewNextStep.Location = New System.Drawing.Point(32, 208)
        Me.LblOverviewNextStep.Name = "LblOverviewNextStep"
        Me.LblOverviewNextStep.Padding = New System.Windows.Forms.Padding(16, 0, 16, 0)
        Me.LblOverviewNextStep.Size = New System.Drawing.Size(760, 64)
        Me.LblOverviewNextStep.TabIndex = 6
        Me.LblOverviewNextStep.Text = "Next: review payroll setup, site contacts and the current contract before process" &
    "ing payroll."
        Me.LblOverviewNextStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPayrollContacts
        '
        Me.TabPayrollContacts.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPayrollContacts.Controls.Add(Me.LblOverviewScheduleCaption)
        Me.TabPayrollContacts.Controls.Add(Me.LblOverviewSchedule)
        Me.TabPayrollContacts.Controls.Add(Me.LblOverviewWageCaption)
        Me.TabPayrollContacts.Controls.Add(Me.LblOverviewWage)
        Me.TabPayrollContacts.Controls.Add(Me.LblOverviewContactCaption)
        Me.TabPayrollContacts.Controls.Add(Me.LblOverviewContact)
        Me.TabPayrollContacts.Location = New System.Drawing.Point(4, 42)
        Me.TabPayrollContacts.Name = "TabPayrollContacts"
        Me.TabPayrollContacts.Size = New System.Drawing.Size(1178, 561)
        Me.TabPayrollContacts.TabIndex = 1
        Me.TabPayrollContacts.Text = "Payroll & contacts"
        '
        'LblOverviewScheduleCaption
        '
        Me.LblOverviewScheduleCaption.AutoSize = True
        Me.LblOverviewScheduleCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblOverviewScheduleCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblOverviewScheduleCaption.Location = New System.Drawing.Point(32, 34)
        Me.LblOverviewScheduleCaption.Name = "LblOverviewScheduleCaption"
        Me.LblOverviewScheduleCaption.Size = New System.Drawing.Size(121, 12)
        Me.LblOverviewScheduleCaption.TabIndex = 0
        Me.LblOverviewScheduleCaption.Text = "PAYROLL SCHEDULE"
        '
        'LblOverviewSchedule
        '
        Me.LblOverviewSchedule.AutoSize = True
        Me.LblOverviewSchedule.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.LblOverviewSchedule.Location = New System.Drawing.Point(32, 58)
        Me.LblOverviewSchedule.Name = "LblOverviewSchedule"
        Me.LblOverviewSchedule.Size = New System.Drawing.Size(21, 17)
        Me.LblOverviewSchedule.TabIndex = 1
        Me.LblOverviewSchedule.Text = "—"
        '
        'LblOverviewWageCaption
        '
        Me.LblOverviewWageCaption.AutoSize = True
        Me.LblOverviewWageCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblOverviewWageCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblOverviewWageCaption.Location = New System.Drawing.Point(280, 34)
        Me.LblOverviewWageCaption.Name = "LblOverviewWageCaption"
        Me.LblOverviewWageCaption.Size = New System.Drawing.Size(82, 12)
        Me.LblOverviewWageCaption.TabIndex = 2
        Me.LblOverviewWageCaption.Text = "DAILY WAGE"
        '
        'LblOverviewWage
        '
        Me.LblOverviewWage.AutoSize = True
        Me.LblOverviewWage.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.LblOverviewWage.Location = New System.Drawing.Point(280, 58)
        Me.LblOverviewWage.Name = "LblOverviewWage"
        Me.LblOverviewWage.Size = New System.Drawing.Size(21, 17)
        Me.LblOverviewWage.TabIndex = 3
        Me.LblOverviewWage.Text = "—"
        '
        'LblOverviewContactCaption
        '
        Me.LblOverviewContactCaption.AutoSize = True
        Me.LblOverviewContactCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblOverviewContactCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblOverviewContactCaption.Location = New System.Drawing.Point(32, 112)
        Me.LblOverviewContactCaption.Name = "LblOverviewContactCaption"
        Me.LblOverviewContactCaption.Size = New System.Drawing.Size(86, 12)
        Me.LblOverviewContactCaption.TabIndex = 4
        Me.LblOverviewContactCaption.Text = "SITE CONTACT"
        '
        'LblOverviewContact
        '
        Me.LblOverviewContact.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.LblOverviewContact.Location = New System.Drawing.Point(32, 136)
        Me.LblOverviewContact.Name = "LblOverviewContact"
        Me.LblOverviewContact.Size = New System.Drawing.Size(600, 100)
        Me.LblOverviewContact.TabIndex = 5
        Me.LblOverviewContact.Text = "—"
        '
        'TabContracts
        '
        Me.TabContracts.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabContracts.Controls.Add(Me.LvContracts)
        Me.TabContracts.Controls.Add(Me.BtnAddContract)
        Me.TabContracts.Controls.Add(Me.BtnEditContract)
        Me.TabContracts.Controls.Add(Me.BtnOpenContract)
        Me.TabContracts.Controls.Add(Me.BtnRemoveContract)
        Me.TabContracts.Controls.Add(Me.LblContractSummary)
        Me.TabContracts.Controls.Add(Me.LblContractsEmpty)
        Me.TabContracts.Location = New System.Drawing.Point(4, 42)
        Me.TabContracts.Name = "TabContracts"
        Me.TabContracts.Size = New System.Drawing.Size(1178, 561)
        Me.TabContracts.TabIndex = 2
        Me.TabContracts.Text = "Contracts"
        '
        'LvContracts
        '
        Me.LvContracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvContracts.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LvContracts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LvContracts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColContractPeriod, Me.ColContractStatus, Me.ColContractFile})
        Me.LvContracts.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.LvContracts.FullRowSelect = True
        Me.LvContracts.GridLines = True
        Me.LvContracts.HideSelection = False
        Me.LvContracts.Location = New System.Drawing.Point(18, 66)
        Me.LvContracts.MultiSelect = False
        Me.LvContracts.Name = "LvContracts"
        Me.LvContracts.Size = New System.Drawing.Size(260, 131)
        Me.LvContracts.TabIndex = 0
        Me.LvContracts.UseCompatibleStateImageBehavior = False
        Me.LvContracts.View = System.Windows.Forms.View.Details
        '
        'ColContractPeriod
        '
        Me.ColContractPeriod.Name = "ColContractPeriod"
        Me.ColContractPeriod.Text = "Contract period"
        Me.ColContractPeriod.Width = 152
        '
        'ColContractStatus
        '
        Me.ColContractStatus.Name = "ColContractStatus"
        Me.ColContractStatus.Text = "Status"
        Me.ColContractStatus.Width = 72
        '
        'ColContractFile
        '
        Me.ColContractFile.Name = "ColContractFile"
        Me.ColContractFile.Text = "Attachment"
        Me.ColContractFile.Width = 160
        '
        'BtnAddContract
        '
        Me.BtnAddContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddContract.BackColor = System.Drawing.Color.Teal
        Me.BtnAddContract.Enabled = False
        Me.BtnAddContract.FlatAppearance.BorderSize = 0
        Me.BtnAddContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddContract.ForeColor = System.Drawing.Color.White
        Me.BtnAddContract.Location = New System.Drawing.Point(-124, 18)
        Me.BtnAddContract.Name = "BtnAddContract"
        Me.BtnAddContract.Size = New System.Drawing.Size(96, 34)
        Me.BtnAddContract.TabIndex = 1
        Me.BtnAddContract.Text = "Add"
        Me.BtnAddContract.UseVisualStyleBackColor = False
        '
        'BtnEditContract
        '
        Me.BtnEditContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditContract.Enabled = False
        Me.BtnEditContract.Location = New System.Drawing.Point(-22, 18)
        Me.BtnEditContract.Name = "BtnEditContract"
        Me.BtnEditContract.Size = New System.Drawing.Size(96, 34)
        Me.BtnEditContract.TabIndex = 2
        Me.BtnEditContract.Text = "Edit"
        '
        'BtnOpenContract
        '
        Me.BtnOpenContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOpenContract.Enabled = False
        Me.BtnOpenContract.Location = New System.Drawing.Point(80, 18)
        Me.BtnOpenContract.Name = "BtnOpenContract"
        Me.BtnOpenContract.Size = New System.Drawing.Size(96, 34)
        Me.BtnOpenContract.TabIndex = 3
        Me.BtnOpenContract.Text = "Open"
        '
        'BtnRemoveContract
        '
        Me.BtnRemoveContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemoveContract.Enabled = False
        Me.BtnRemoveContract.Location = New System.Drawing.Point(182, 18)
        Me.BtnRemoveContract.Name = "BtnRemoveContract"
        Me.BtnRemoveContract.Size = New System.Drawing.Size(96, 34)
        Me.BtnRemoveContract.TabIndex = 4
        Me.BtnRemoveContract.Text = "Remove"
        '
        'LblContractSummary
        '
        Me.LblContractSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblContractSummary.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.LblContractSummary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblContractSummary.Location = New System.Drawing.Point(18, 109)
        Me.LblContractSummary.Name = "LblContractSummary"
        Me.LblContractSummary.Size = New System.Drawing.Size(260, 48)
        Me.LblContractSummary.TabIndex = 5
        Me.LblContractSummary.Text = "Select a contract to see its notes."
        '
        'LblContractsEmpty
        '
        Me.LblContractsEmpty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblContractsEmpty.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblContractsEmpty.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.LblContractsEmpty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblContractsEmpty.Location = New System.Drawing.Point(240, 150)
        Me.LblContractsEmpty.Name = "LblContractsEmpty"
        Me.LblContractsEmpty.Size = New System.Drawing.Size(90, 70)
        Me.LblContractsEmpty.TabIndex = 6
        Me.LblContractsEmpty.Text = "No contract is recorded for this subclient." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Add the current agreement before usi" &
    "ng this location for payroll."
        Me.LblContractsEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblContractsEmpty.Visible = False
        '
        'TabStatusHistory
        '
        Me.TabStatusHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabStatusHistory.Controls.Add(Me.LvStatusHistory)
        Me.TabStatusHistory.Controls.Add(Me.LblStatusHistoryEmpty)
        Me.TabStatusHistory.Location = New System.Drawing.Point(4, 42)
        Me.TabStatusHistory.Name = "TabStatusHistory"
        Me.TabStatusHistory.Size = New System.Drawing.Size(1178, 561)
        Me.TabStatusHistory.TabIndex = 3
        Me.TabStatusHistory.Text = "Status history"
        '
        'LvStatusHistory
        '
        Me.LvStatusHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvStatusHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LvStatusHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LvStatusHistory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColHistoryDate, Me.ColHistoryStatus, Me.ColHistoryReason})
        Me.LvStatusHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LvStatusHistory.FullRowSelect = True
        Me.LvStatusHistory.GridLines = True
        Me.LvStatusHistory.HideSelection = False
        Me.LvStatusHistory.Location = New System.Drawing.Point(24, 24)
        Me.LvStatusHistory.Name = "LvStatusHistory"
        Me.LvStatusHistory.Size = New System.Drawing.Size(1120, 475)
        Me.LvStatusHistory.TabIndex = 0
        Me.LvStatusHistory.UseCompatibleStateImageBehavior = False
        Me.LvStatusHistory.View = System.Windows.Forms.View.Details
        '
        'ColHistoryDate
        '
        Me.ColHistoryDate.Name = "ColHistoryDate"
        Me.ColHistoryDate.Text = "Effective date"
        Me.ColHistoryDate.Width = 170
        '
        'ColHistoryStatus
        '
        Me.ColHistoryStatus.Name = "ColHistoryStatus"
        Me.ColHistoryStatus.Text = "Status"
        Me.ColHistoryStatus.Width = 150
        '
        'ColHistoryReason
        '
        Me.ColHistoryReason.Name = "ColHistoryReason"
        Me.ColHistoryReason.Text = "Reason"
        Me.ColHistoryReason.Width = 660
        '
        'LblStatusHistoryEmpty
        '
        Me.LblStatusHistoryEmpty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblStatusHistoryEmpty.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblStatusHistoryEmpty.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.LblStatusHistoryEmpty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblStatusHistoryEmpty.Location = New System.Drawing.Point(240, 150)
        Me.LblStatusHistoryEmpty.Name = "LblStatusHistoryEmpty"
        Me.LblStatusHistoryEmpty.Size = New System.Drawing.Size(692, 64)
        Me.LblStatusHistoryEmpty.TabIndex = 1
        Me.LblStatusHistoryEmpty.Text = "No status changes have been recorded for this subclient."
        Me.LblStatusHistoryEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblStatusHistoryEmpty.Visible = False
        '
        'WorkSiteProfileHeader
        '
        Me.WorkSiteProfileHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WorkSiteProfileHeader.Controls.Add(Me.BtnBackToDirectory)
        Me.WorkSiteProfileHeader.Controls.Add(Me.LblProfileBreadcrumb)
        Me.WorkSiteProfileHeader.Controls.Add(Me.LblProfileName)
        Me.WorkSiteProfileHeader.Controls.Add(Me.LblProfileStatus)
        Me.WorkSiteProfileHeader.Controls.Add(Me.BtnEditWorkSite)
        Me.WorkSiteProfileHeader.Controls.Add(Me.BtnWorkSiteStatus)
        Me.WorkSiteProfileHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.WorkSiteProfileHeader.Location = New System.Drawing.Point(0, 0)
        Me.WorkSiteProfileHeader.Name = "WorkSiteProfileHeader"
        Me.WorkSiteProfileHeader.Size = New System.Drawing.Size(1186, 118)
        Me.WorkSiteProfileHeader.TabIndex = 1
        '
        'BtnBackToDirectory
        '
        Me.BtnBackToDirectory.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnBackToDirectory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnBackToDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBackToDirectory.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.BtnBackToDirectory.Location = New System.Drawing.Point(22, 16)
        Me.BtnBackToDirectory.Name = "BtnBackToDirectory"
        Me.BtnBackToDirectory.Size = New System.Drawing.Size(138, 32)
        Me.BtnBackToDirectory.TabIndex = 0
        Me.BtnBackToDirectory.Text = "Back to directory"
        Me.BtnBackToDirectory.UseVisualStyleBackColor = False
        '
        'LblProfileBreadcrumb
        '
        Me.LblProfileBreadcrumb.AutoSize = True
        Me.LblProfileBreadcrumb.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblProfileBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblProfileBreadcrumb.Location = New System.Drawing.Point(164, 24)
        Me.LblProfileBreadcrumb.Name = "LblProfileBreadcrumb"
        Me.LblProfileBreadcrumb.Size = New System.Drawing.Size(155, 15)
        Me.LblProfileBreadcrumb.TabIndex = 1
        Me.LblProfileBreadcrumb.Text = "Clients  ›  Client  ›  Subclient"
        '
        'LblProfileName
        '
        Me.LblProfileName.AutoEllipsis = True
        Me.LblProfileName.Font = New System.Drawing.Font("Bahnschrift SemiBold", 18.0!)
        Me.LblProfileName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblProfileName.Location = New System.Drawing.Point(22, 62)
        Me.LblProfileName.Name = "LblProfileName"
        Me.LblProfileName.Size = New System.Drawing.Size(610, 36)
        Me.LblProfileName.TabIndex = 2
        Me.LblProfileName.Text = "Subclient profile"
        '
        'LblProfileStatus
        '
        Me.LblProfileStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LblProfileStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.LblProfileStatus.ForeColor = System.Drawing.Color.Teal
        Me.LblProfileStatus.Location = New System.Drawing.Point(644, 66)
        Me.LblProfileStatus.Name = "LblProfileStatus"
        Me.LblProfileStatus.Size = New System.Drawing.Size(90, 28)
        Me.LblProfileStatus.TabIndex = 3
        Me.LblProfileStatus.Text = "Active"
        Me.LblProfileStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnEditWorkSite
        '
        Me.BtnEditWorkSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditWorkSite.BackColor = System.Drawing.Color.Teal
        Me.BtnEditWorkSite.Enabled = False
        Me.BtnEditWorkSite.FlatAppearance.BorderSize = 0
        Me.BtnEditWorkSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEditWorkSite.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.BtnEditWorkSite.ForeColor = System.Drawing.Color.White
        Me.BtnEditWorkSite.Location = New System.Drawing.Point(910, 56)
        Me.BtnEditWorkSite.Name = "BtnEditWorkSite"
        Me.BtnEditWorkSite.Size = New System.Drawing.Size(122, 38)
        Me.BtnEditWorkSite.TabIndex = 4
        Me.BtnEditWorkSite.Text = "Edit subclient"
        Me.BtnEditWorkSite.UseVisualStyleBackColor = False
        '
        'BtnWorkSiteStatus
        '
        Me.BtnWorkSiteStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWorkSiteStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BtnWorkSiteStatus.Enabled = False
        Me.BtnWorkSiteStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnWorkSiteStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnWorkSiteStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.BtnWorkSiteStatus.Location = New System.Drawing.Point(1042, 56)
        Me.BtnWorkSiteStatus.Name = "BtnWorkSiteStatus"
        Me.BtnWorkSiteStatus.Size = New System.Drawing.Size(122, 38)
        Me.BtnWorkSiteStatus.TabIndex = 5
        Me.BtnWorkSiteStatus.Text = "Change status"
        Me.BtnWorkSiteStatus.UseVisualStyleBackColor = False
        '
        'TabContractMonitoring
        '
        Me.TabContractMonitoring.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabContractMonitoring.Controls.Add(Me.LblMonitoringTitle)
        Me.TabContractMonitoring.Controls.Add(Me.LblMonitoringSubtitle)
        Me.TabContractMonitoring.Controls.Add(Me.MonitoringFilterPanel)
        Me.TabContractMonitoring.Controls.Add(Me.LvContractMonitoring)
        Me.TabContractMonitoring.Controls.Add(Me.LblMonitoringEmpty)
        Me.TabContractMonitoring.Location = New System.Drawing.Point(4, 5)
        Me.TabContractMonitoring.Name = "TabContractMonitoring"
        Me.TabContractMonitoring.Size = New System.Drawing.Size(1186, 725)
        Me.TabContractMonitoring.TabIndex = 2
        Me.TabContractMonitoring.Text = "Contract monitoring"
        '
        'LblMonitoringTitle
        '
        Me.LblMonitoringTitle.AutoSize = True
        Me.LblMonitoringTitle.Font = New System.Drawing.Font("Bahnschrift SemiBold", 16.0!)
        Me.LblMonitoringTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblMonitoringTitle.Location = New System.Drawing.Point(26, 24)
        Me.LblMonitoringTitle.Name = "LblMonitoringTitle"
        Me.LblMonitoringTitle.Size = New System.Drawing.Size(107, 27)
        Me.LblMonitoringTitle.TabIndex = 0
        Me.LblMonitoringTitle.Text = "Contracts"
        '
        'LblMonitoringSubtitle
        '
        Me.LblMonitoringSubtitle.AutoSize = True
        Me.LblMonitoringSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblMonitoringSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblMonitoringSubtitle.Location = New System.Drawing.Point(28, 56)
        Me.LblMonitoringSubtitle.Name = "LblMonitoringSubtitle"
        Me.LblMonitoringSubtitle.Size = New System.Drawing.Size(368, 15)
        Me.LblMonitoringSubtitle.TabIndex = 1
        Me.LblMonitoringSubtitle.Text = "Find agreements that are expiring, expired or missing an attachment."
        '
        'MonitoringFilterPanel
        '
        Me.MonitoringFilterPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MonitoringFilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MonitoringFilterPanel.Controls.Add(Me.LblMonitoringFilter)
        Me.MonitoringFilterPanel.Controls.Add(Me.CmbContractMonitoringFilter)
        Me.MonitoringFilterPanel.Controls.Add(Me.BtnRefreshContractMonitoring)
        Me.MonitoringFilterPanel.Location = New System.Drawing.Point(24, 88)
        Me.MonitoringFilterPanel.Name = "MonitoringFilterPanel"
        Me.MonitoringFilterPanel.Size = New System.Drawing.Size(1056, 60)
        Me.MonitoringFilterPanel.TabIndex = 2
        '
        'LblMonitoringFilter
        '
        Me.LblMonitoringFilter.AutoSize = True
        Me.LblMonitoringFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LblMonitoringFilter.Location = New System.Drawing.Point(18, 20)
        Me.LblMonitoringFilter.Name = "LblMonitoringFilter"
        Me.LblMonitoringFilter.Size = New System.Drawing.Size(79, 15)
        Me.LblMonitoringFilter.TabIndex = 0
        Me.LblMonitoringFilter.Text = "Contract view"
        '
        'CmbContractMonitoringFilter
        '
        Me.CmbContractMonitoringFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbContractMonitoringFilter.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.CmbContractMonitoringFilter.Items.AddRange(New Object() {"Expiring in 30 days", "Expired", "Missing attachment", "All contracts"})
        Me.CmbContractMonitoringFilter.Location = New System.Drawing.Point(118, 16)
        Me.CmbContractMonitoringFilter.Name = "CmbContractMonitoringFilter"
        Me.CmbContractMonitoringFilter.Size = New System.Drawing.Size(220, 25)
        Me.CmbContractMonitoringFilter.TabIndex = 1
        '
        'BtnRefreshContractMonitoring
        '
        Me.BtnRefreshContractMonitoring.BackColor = System.Drawing.Color.Teal
        Me.BtnRefreshContractMonitoring.FlatAppearance.BorderSize = 0
        Me.BtnRefreshContractMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefreshContractMonitoring.Font = New System.Drawing.Font("Segoe UI Semibold", 8.75!)
        Me.BtnRefreshContractMonitoring.ForeColor = System.Drawing.Color.White
        Me.BtnRefreshContractMonitoring.Location = New System.Drawing.Point(356, 12)
        Me.BtnRefreshContractMonitoring.Name = "BtnRefreshContractMonitoring"
        Me.BtnRefreshContractMonitoring.Size = New System.Drawing.Size(142, 36)
        Me.BtnRefreshContractMonitoring.TabIndex = 2
        Me.BtnRefreshContractMonitoring.Text = "Reload contracts"
        Me.BtnRefreshContractMonitoring.UseVisualStyleBackColor = False
        '
        'LvContractMonitoring
        '
        Me.LvContractMonitoring.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvContractMonitoring.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LvContractMonitoring.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LvContractMonitoring.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColMonitoringCompany, Me.ColMonitoringSite, Me.ColMonitoringEnd, Me.ColMonitoringStatus, Me.ColMonitoringFile})
        Me.LvContractMonitoring.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LvContractMonitoring.FullRowSelect = True
        Me.LvContractMonitoring.GridLines = True
        Me.LvContractMonitoring.HideSelection = False
        Me.LvContractMonitoring.Location = New System.Drawing.Point(24, 164)
        Me.LvContractMonitoring.MultiSelect = False
        Me.LvContractMonitoring.Name = "LvContractMonitoring"
        Me.LvContractMonitoring.Size = New System.Drawing.Size(1056, 410)
        Me.LvContractMonitoring.TabIndex = 3
        Me.LvContractMonitoring.UseCompatibleStateImageBehavior = False
        Me.LvContractMonitoring.View = System.Windows.Forms.View.Details
        '
        'ColMonitoringCompany
        '
        Me.ColMonitoringCompany.Name = "ColMonitoringCompany"
        Me.ColMonitoringCompany.Text = "Client"
        Me.ColMonitoringCompany.Width = 260
        '
        'ColMonitoringSite
        '
        Me.ColMonitoringSite.Name = "ColMonitoringSite"
        Me.ColMonitoringSite.Text = "Subclient"
        Me.ColMonitoringSite.Width = 250
        '
        'ColMonitoringEnd
        '
        Me.ColMonitoringEnd.Name = "ColMonitoringEnd"
        Me.ColMonitoringEnd.Text = "Contract ends"
        Me.ColMonitoringEnd.Width = 130
        '
        'ColMonitoringStatus
        '
        Me.ColMonitoringStatus.Name = "ColMonitoringStatus"
        Me.ColMonitoringStatus.Text = "Status"
        Me.ColMonitoringStatus.Width = 120
        '
        'ColMonitoringFile
        '
        Me.ColMonitoringFile.Name = "ColMonitoringFile"
        Me.ColMonitoringFile.Text = "Attachment"
        Me.ColMonitoringFile.Width = 260
        '
        'LblMonitoringEmpty
        '
        Me.LblMonitoringEmpty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMonitoringEmpty.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblMonitoringEmpty.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.LblMonitoringEmpty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblMonitoringEmpty.Location = New System.Drawing.Point(250, 284)
        Me.LblMonitoringEmpty.Name = "LblMonitoringEmpty"
        Me.LblMonitoringEmpty.Size = New System.Drawing.Size(600, 72)
        Me.LblMonitoringEmpty.TabIndex = 4
        Me.LblMonitoringEmpty.Text = "No contracts match this view." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Choose another contract view or refresh the record" &
    "s."
        Me.LblMonitoringEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblMonitoringEmpty.Visible = False
        '
        'NavigationPanel
        '
        Me.NavigationPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.NavigationPanel.Controls.Add(Me.NavigationGuidePanel)
        Me.NavigationPanel.Controls.Add(Me.BtnNavContracts)
        Me.NavigationPanel.Controls.Add(Me.BtnNavSites)
        Me.NavigationPanel.Controls.Add(Me.BtnNavCompanies)
        Me.NavigationPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavigationPanel.Location = New System.Drawing.Point(18, 14)
        Me.NavigationPanel.Name = "NavigationPanel"
        Me.NavigationPanel.Size = New System.Drawing.Size(196, 734)
        Me.NavigationPanel.TabIndex = 1
        '
        'NavigationGuidePanel
        '
        Me.NavigationGuidePanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NavigationGuidePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NavigationGuidePanel.Controls.Add(Me.LblNavigationGuideTitle)
        Me.NavigationGuidePanel.Controls.Add(Me.LblNavigationGuide)
        Me.NavigationGuidePanel.Location = New System.Drawing.Point(0, 174)
        Me.NavigationGuidePanel.Name = "NavigationGuidePanel"
        Me.NavigationGuidePanel.Size = New System.Drawing.Size(196, 560)
        Me.NavigationGuidePanel.TabIndex = 0
        '
        'LblNavigationGuideTitle
        '
        Me.LblNavigationGuideTitle.AutoSize = True
        Me.LblNavigationGuideTitle.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.LblNavigationGuideTitle.ForeColor = System.Drawing.Color.Teal
        Me.LblNavigationGuideTitle.Location = New System.Drawing.Point(14, 16)
        Me.LblNavigationGuideTitle.Name = "LblNavigationGuideTitle"
        Me.LblNavigationGuideTitle.Size = New System.Drawing.Size(154, 14)
        Me.LblNavigationGuideTitle.TabIndex = 0
        Me.LblNavigationGuideTitle.Text = "CLIENT MANAGEMENT"
        '
        'LblNavigationGuide
        '
        Me.LblNavigationGuide.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.LblNavigationGuide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.LblNavigationGuide.Location = New System.Drawing.Point(14, 48)
        Me.LblNavigationGuide.Name = "LblNavigationGuide"
        Me.LblNavigationGuide.Size = New System.Drawing.Size(166, 250)
        Me.LblNavigationGuide.TabIndex = 1
        Me.LblNavigationGuide.Text = "CLIENTS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manage the legal organization and its information." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SUBCLIENTS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manage" &
    " payroll or service locations under a client." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CONTRACTS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Review agreements, d" &
    "ates, and attachments."
        '
        'BtnNavContracts
        '
        Me.BtnNavContracts.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnNavContracts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNavContracts.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnNavContracts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnNavContracts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNavContracts.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!)
        Me.BtnNavContracts.Location = New System.Drawing.Point(0, 116)
        Me.BtnNavContracts.Name = "BtnNavContracts"
        Me.BtnNavContracts.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.BtnNavContracts.Size = New System.Drawing.Size(196, 58)
        Me.BtnNavContracts.TabIndex = 1
        Me.BtnNavContracts.Text = "03    Contracts"
        Me.BtnNavContracts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNavContracts.UseVisualStyleBackColor = False
        '
        'BtnNavSites
        '
        Me.BtnNavSites.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnNavSites.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNavSites.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnNavSites.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnNavSites.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNavSites.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!)
        Me.BtnNavSites.Location = New System.Drawing.Point(0, 58)
        Me.BtnNavSites.Name = "BtnNavSites"
        Me.BtnNavSites.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.BtnNavSites.Size = New System.Drawing.Size(196, 58)
        Me.BtnNavSites.TabIndex = 2
        Me.BtnNavSites.Text = "02    Subclients"
        Me.BtnNavSites.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNavSites.UseVisualStyleBackColor = False
        '
        'BtnNavCompanies
        '
        Me.BtnNavCompanies.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnNavCompanies.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNavCompanies.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnNavCompanies.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnNavCompanies.FlatAppearance.BorderSize = 2
        Me.BtnNavCompanies.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNavCompanies.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!)
        Me.BtnNavCompanies.ForeColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BtnNavCompanies.Location = New System.Drawing.Point(0, 0)
        Me.BtnNavCompanies.Name = "BtnNavCompanies"
        Me.BtnNavCompanies.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.BtnNavCompanies.Size = New System.Drawing.Size(196, 58)
        Me.BtnNavCompanies.TabIndex = 3
        Me.BtnNavCompanies.Text = "01    Clients"
        Me.BtnNavCompanies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNavCompanies.UseVisualStyleBackColor = False
        '
        'WorkspaceHeaderPanel
        '
        Me.WorkspaceHeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WorkspaceHeaderPanel.Controls.Add(Me.LblWorkspaceEyebrow)
        Me.WorkspaceHeaderPanel.Controls.Add(Me.LblWorkspaceTitle)
        Me.WorkspaceHeaderPanel.Controls.Add(Me.LblWorkspaceSubtitle)
        Me.WorkspaceHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.WorkspaceHeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.WorkspaceHeaderPanel.Name = "WorkspaceHeaderPanel"
        Me.WorkspaceHeaderPanel.Size = New System.Drawing.Size(1186, 92)
        Me.WorkspaceHeaderPanel.TabIndex = 1
        '
        'LblWorkspaceEyebrow
        '
        Me.LblWorkspaceEyebrow.AutoSize = True
        Me.LblWorkspaceEyebrow.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.LblWorkspaceEyebrow.ForeColor = System.Drawing.Color.Teal
        Me.LblWorkspaceEyebrow.Location = New System.Drawing.Point(24, 14)
        Me.LblWorkspaceEyebrow.Name = "LblWorkspaceEyebrow"
        Me.LblWorkspaceEyebrow.Size = New System.Drawing.Size(129, 13)
        Me.LblWorkspaceEyebrow.TabIndex = 0
        Me.LblWorkspaceEyebrow.Text = "CLIENT DIRECTORY"
        '
        'LblWorkspaceTitle
        '
        Me.LblWorkspaceTitle.AutoSize = True
        Me.LblWorkspaceTitle.Font = New System.Drawing.Font("Bahnschrift SemiBold", 16.0!)
        Me.LblWorkspaceTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblWorkspaceTitle.Location = New System.Drawing.Point(22, 34)
        Me.LblWorkspaceTitle.Name = "LblWorkspaceTitle"
        Me.LblWorkspaceTitle.Size = New System.Drawing.Size(228, 27)
        Me.LblWorkspaceTitle.TabIndex = 1
        Me.LblWorkspaceTitle.Text = "Clients and subclients"
        '
        'LblWorkspaceSubtitle
        '
        Me.LblWorkspaceSubtitle.AutoSize = True
        Me.LblWorkspaceSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblWorkspaceSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.LblWorkspaceSubtitle.Location = New System.Drawing.Point(24, 65)
        Me.LblWorkspaceSubtitle.Name = "LblWorkspaceSubtitle"
        Me.LblWorkspaceSubtitle.Size = New System.Drawing.Size(381, 15)
        Me.LblWorkspaceSubtitle.TabIndex = 2
        Me.LblWorkspaceSubtitle.Text = "Choose the legal client, then manage the subclients registered under it."
        '
        'LblHierarchyArrowOne
        '
        Me.LblHierarchyArrowOne.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.LblHierarchyArrowOne.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.LblHierarchyArrowOne.Location = New System.Drawing.Point(226, 38)
        Me.LblHierarchyArrowOne.Name = "LblHierarchyArrowOne"
        Me.LblHierarchyArrowOne.Size = New System.Drawing.Size(30, 30)
        Me.LblHierarchyArrowOne.TabIndex = 0
        Me.LblHierarchyArrowOne.Text = "›"
        '
        'LblHierarchySiteCaption
        '
        Me.LblHierarchySiteCaption.AutoSize = True
        Me.LblHierarchySiteCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblHierarchySiteCaption.ForeColor = System.Drawing.Color.Teal
        Me.LblHierarchySiteCaption.Location = New System.Drawing.Point(260, 15)
        Me.LblHierarchySiteCaption.Name = "LblHierarchySiteCaption"
        Me.LblHierarchySiteCaption.Size = New System.Drawing.Size(100, 23)
        Me.LblHierarchySiteCaption.TabIndex = 0
        Me.LblHierarchySiteCaption.Text = "SUBCLIENT"
        '
        'LblHierarchySite
        '
        Me.LblHierarchySite.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.LblHierarchySite.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblHierarchySite.Location = New System.Drawing.Point(258, 37)
        Me.LblHierarchySite.Name = "LblHierarchySite"
        Me.LblHierarchySite.Size = New System.Drawing.Size(205, 42)
        Me.LblHierarchySite.TabIndex = 0
        Me.LblHierarchySite.Text = "No subclient selected"
        '
        'LblHierarchyArrowTwo
        '
        Me.LblHierarchyArrowTwo.Font = New System.Drawing.Font("Segoe UI", 15.0!)
        Me.LblHierarchyArrowTwo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.LblHierarchyArrowTwo.Location = New System.Drawing.Point(466, 38)
        Me.LblHierarchyArrowTwo.Name = "LblHierarchyArrowTwo"
        Me.LblHierarchyArrowTwo.Size = New System.Drawing.Size(30, 30)
        Me.LblHierarchyArrowTwo.TabIndex = 0
        Me.LblHierarchyArrowTwo.Text = "›"
        '
        'LblHierarchyContractCaption
        '
        Me.LblHierarchyContractCaption.AutoSize = True
        Me.LblHierarchyContractCaption.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.LblHierarchyContractCaption.ForeColor = System.Drawing.Color.Teal
        Me.LblHierarchyContractCaption.Location = New System.Drawing.Point(500, 15)
        Me.LblHierarchyContractCaption.Name = "LblHierarchyContractCaption"
        Me.LblHierarchyContractCaption.Size = New System.Drawing.Size(100, 23)
        Me.LblHierarchyContractCaption.TabIndex = 0
        Me.LblHierarchyContractCaption.Text = "CONTRACT"
        '
        'LblHierarchyContract
        '
        Me.LblHierarchyContract.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!)
        Me.LblHierarchyContract.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LblHierarchyContract.Location = New System.Drawing.Point(498, 37)
        Me.LblHierarchyContract.Name = "LblHierarchyContract"
        Me.LblHierarchyContract.Size = New System.Drawing.Size(180, 42)
        Me.LblHierarchyContract.TabIndex = 0
        Me.LblHierarchyContract.Text = "No contract selected"
        '
        'SiteDetailsSplit
        '
        Me.SiteDetailsSplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SiteDetailsSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SiteDetailsSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SiteDetailsSplit.Location = New System.Drawing.Point(0, 0)
        Me.SiteDetailsSplit.Name = "SiteDetailsSplit"
        Me.SiteDetailsSplit.Panel1MinSize = 280
        Me.SiteDetailsSplit.Panel2MinSize = 340
        Me.SiteDetailsSplit.Size = New System.Drawing.Size(800, 534)
        Me.SiteDetailsSplit.SplitterDistance = 340
        Me.SiteDetailsSplit.SplitterWidth = 1
        Me.SiteDetailsSplit.TabIndex = 0
        '
        'ClientErrors
        '
        Me.ClientErrors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ClientErrors.ContainerControl = Me
        '
        'ContractFileDialog
        '
        Me.ContractFileDialog.Filter = "Contract files (*.pdf;*.jpg;*.jpeg)|*.pdf;*.jpg;*.jpeg"
        Me.ContractFileDialog.Title = "Choose the signed client contract"
        '
        'SearchTimer
        '
        Me.SearchTimer.Interval = 260
        '
        'FRM_HR_CLIENTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1440, 860)
        Me.Controls.Add(Me.RootLayout)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1200, 740)
        Me.Name = "FRM_HR_CLIENTS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Human Resources - Clients"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.RootLayout.ResumeLayout(False)
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        CType(Me.ClientsLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BodyPanel.ResumeLayout(False)
        Me.WorkspacePanel.ResumeLayout(False)
        Me.EditorPanel.ResumeLayout(False)
        Me.EditorTabs.ResumeLayout(False)
        Me.TabCompanyEditor.ResumeLayout(False)
        Me.TabCompanyEditor.PerformLayout()
        Me.PnlCompanyWarning.ResumeLayout(False)
        Me.PnlCompanyWarning.PerformLayout()
        Me.TabWorkSiteEditor.ResumeLayout(False)
        Me.WorkSiteWizardTabs.ResumeLayout(False)
        Me.TabWizardIdentity.ResumeLayout(False)
        Me.TabWizardIdentity.PerformLayout()
        Me.TabWizardPayroll.ResumeLayout(False)
        Me.TabWizardPayroll.PerformLayout()
        Me.TabWizardContract.ResumeLayout(False)
        Me.PnlInitialContract.ResumeLayout(False)
        Me.PnlInitialContract.PerformLayout()
        Me.WizardProgressPanel.ResumeLayout(False)
        Me.TabContractEditor.ResumeLayout(False)
        Me.TabContractEditor.PerformLayout()
        Me.TabStatusEditor.ResumeLayout(False)
        Me.TabStatusEditor.PerformLayout()
        Me.EditorFooterPanel.ResumeLayout(False)
        Me.EditorFooterPanel.PerformLayout()
        Me.EditorActionFlow.ResumeLayout(False)
        Me.EditorHeaderPanel.ResumeLayout(False)
        Me.EditorHeaderPanel.PerformLayout()
        Me.MainCanvas.ResumeLayout(False)
        Me.WorkspaceViews.ResumeLayout(False)
        Me.TabDirectoryView.ResumeLayout(False)
        Me.ContentSplit.Panel1.ResumeLayout(False)
        Me.ContentSplit.Panel2.ResumeLayout(False)
        CType(Me.ContentSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContentSplit.ResumeLayout(False)
        Me.CompanyDirectoryPanel.ResumeLayout(False)
        Me.CompanyDirectoryPanel.PerformLayout()
        Me.CompanyWorkspaceLayout.ResumeLayout(False)
        Me.HierarchyPanel.ResumeLayout(False)
        Me.HierarchyPanel.PerformLayout()
        Me.WorkSitesPanel.ResumeLayout(False)
        Me.WorkSitesPanel.PerformLayout()
        Me.TabWorkSiteProfile.ResumeLayout(False)
        Me.DetailsTabs.ResumeLayout(False)
        Me.TabOverview.ResumeLayout(False)
        Me.TabOverview.PerformLayout()
        Me.TabPayrollContacts.ResumeLayout(False)
        Me.TabPayrollContacts.PerformLayout()
        Me.TabContracts.ResumeLayout(False)
        Me.TabStatusHistory.ResumeLayout(False)
        Me.WorkSiteProfileHeader.ResumeLayout(False)
        Me.WorkSiteProfileHeader.PerformLayout()
        Me.TabContractMonitoring.ResumeLayout(False)
        Me.TabContractMonitoring.PerformLayout()
        Me.MonitoringFilterPanel.ResumeLayout(False)
        Me.MonitoringFilterPanel.PerformLayout()
        Me.NavigationPanel.ResumeLayout(False)
        Me.NavigationGuidePanel.ResumeLayout(False)
        Me.NavigationGuidePanel.PerformLayout()
        Me.WorkspaceHeaderPanel.ResumeLayout(False)
        Me.WorkspaceHeaderPanel.PerformLayout()
        CType(Me.SiteDetailsSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SiteDetailsSplit.ResumeLayout(False)
        CType(Me.ClientErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RootLayout As TableLayoutPanel
    Friend WithEvents HeaderPanel As Panel
    Friend WithEvents ClientsLogo As PictureBox
    Friend WithEvents LblHeaderTitle As Label
    Friend WithEvents LblHeaderSubtitle As Label
    Friend WithEvents LblHeaderSection As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents BodyPanel As Panel
    Friend WithEvents NavigationPanel As Panel
    Friend WithEvents BtnNavCompanies As Button
    Friend WithEvents BtnNavSites As Button
    Friend WithEvents BtnNavContracts As Button
    Friend WithEvents NavigationGuidePanel As Panel
    Friend WithEvents LblNavigationGuideTitle As Label
    Friend WithEvents LblNavigationGuide As Label
    Friend WithEvents WorkspacePanel As Panel
    Friend WithEvents MainCanvas As Panel
    Friend WithEvents WorkspaceViews As TabControl
    Friend WithEvents TabDirectoryView As TabPage
    Friend WithEvents TabWorkSiteProfile As TabPage
    Friend WithEvents TabContractMonitoring As TabPage
    Friend WithEvents WorkspaceHeaderPanel As Panel
    Friend WithEvents LblWorkspaceEyebrow As Label
    Friend WithEvents LblWorkspaceTitle As Label
    Friend WithEvents LblWorkspaceSubtitle As Label
    Friend WithEvents BtnAddCompany As Button
    Friend WithEvents BtnAddWorkSite As Button
    Friend WithEvents LblWorkspaceMessage As Label
    Friend WithEvents ContentSplit As SplitContainer
    Friend WithEvents CompanyDirectoryPanel As Panel
    Friend WithEvents LblCompaniesTitle As Label
    Friend WithEvents LblCompaniesCount As Label
    Friend WithEvents LblCompanySearch As Label
    Friend WithEvents LblCompanyStatusFilter As Label
    Friend WithEvents LblCompaniesEmpty As Label
    Friend WithEvents TxtCompanySearch As TextBox
    Friend WithEvents CmbCompanyStatus As ComboBox
    Friend WithEvents BtnRefresh As Button
    Friend WithEvents LvCompanies As ListView
    Friend WithEvents ColCompanyCode As ColumnHeader
    Friend WithEvents ColCompany As ColumnHeader
    Friend WithEvents ColCompanyType As ColumnHeader
    Friend WithEvents ColSiteCount As ColumnHeader
    Friend WithEvents ColCompanyStatus As ColumnHeader
    Friend WithEvents CompanyWorkspaceLayout As TableLayoutPanel
    Friend WithEvents HierarchyPanel As Panel
    Friend WithEvents LblHierarchyCompanyCaption As Label
    Friend WithEvents LblHierarchyCompany As Label
    Friend WithEvents LblHierarchyArrowOne As Label
    Friend WithEvents LblHierarchySiteCaption As Label
    Friend WithEvents LblHierarchySite As Label
    Friend WithEvents LblHierarchyArrowTwo As Label
    Friend WithEvents LblHierarchyContractCaption As Label
    Friend WithEvents LblHierarchyContract As Label
    Friend WithEvents BtnEditCompany As Button
    Friend WithEvents BtnCompanyStatus As Button
    Friend WithEvents SiteDetailsSplit As SplitContainer
    Friend WithEvents WorkSitesPanel As Panel
    Friend WithEvents LblWorkSitesTitle As Label
    Friend WithEvents LblWorkSitesCount As Label
    Friend WithEvents LblWorkSitesHelp As Label
    Friend WithEvents LblWorkSitesEmpty As Label
    Friend WithEvents LvWorkSites As ListView
    Friend WithEvents ColSiteCode As ColumnHeader
    Friend WithEvents ColSiteName As ColumnHeader
    Friend WithEvents ColSiteAddress As ColumnHeader
    Friend WithEvents ColSiteStatus As ColumnHeader
    Friend WithEvents BtnOpenWorkSite As Button
    Friend WithEvents WorkSiteProfileHeader As Panel
    Friend WithEvents BtnBackToDirectory As Button
    Friend WithEvents LblProfileBreadcrumb As Label
    Friend WithEvents LblProfileName As Label
    Friend WithEvents LblProfileStatus As Label
    Friend WithEvents DetailsTabs As TabControl
    Friend WithEvents TabOverview As TabPage
    Friend WithEvents LblOverviewName As Label
    Friend WithEvents LblOverviewStatus As Label
    Friend WithEvents LblOverviewAddressCaption As Label
    Friend WithEvents LblOverviewAddress As Label
    Friend WithEvents LblOverviewParentCaption As Label
    Friend WithEvents LblOverviewParent As Label
    Friend WithEvents LblOverviewNextStep As Label
    Friend WithEvents LblOverviewScheduleCaption As Label
    Friend WithEvents LblOverviewSchedule As Label
    Friend WithEvents LblOverviewWageCaption As Label
    Friend WithEvents LblOverviewWage As Label
    Friend WithEvents LblOverviewContactCaption As Label
    Friend WithEvents LblOverviewContact As Label
    Friend WithEvents BtnEditWorkSite As Button
    Friend WithEvents BtnWorkSiteStatus As Button
    Friend WithEvents TabPayrollContacts As TabPage
    Friend WithEvents TabContracts As TabPage
    Friend WithEvents LvContracts As ListView
    Friend WithEvents ColContractPeriod As ColumnHeader
    Friend WithEvents ColContractStatus As ColumnHeader
    Friend WithEvents ColContractFile As ColumnHeader
    Friend WithEvents BtnAddContract As Button
    Friend WithEvents BtnEditContract As Button
    Friend WithEvents BtnOpenContract As Button
    Friend WithEvents BtnRemoveContract As Button
    Friend WithEvents LblContractSummary As Label
    Friend WithEvents LblContractsEmpty As Label
    Friend WithEvents TabStatusHistory As TabPage
    Friend WithEvents LvStatusHistory As ListView
    Friend WithEvents ColHistoryDate As ColumnHeader
    Friend WithEvents ColHistoryStatus As ColumnHeader
    Friend WithEvents ColHistoryReason As ColumnHeader
    Friend WithEvents LblStatusHistoryEmpty As Label
    Friend WithEvents LblMonitoringTitle As Label
    Friend WithEvents LblMonitoringSubtitle As Label
    Friend WithEvents MonitoringFilterPanel As Panel
    Friend WithEvents LblMonitoringFilter As Label
    Friend WithEvents CmbContractMonitoringFilter As ComboBox
    Friend WithEvents BtnRefreshContractMonitoring As Button
    Friend WithEvents LvContractMonitoring As ListView
    Friend WithEvents ColMonitoringCompany As ColumnHeader
    Friend WithEvents ColMonitoringSite As ColumnHeader
    Friend WithEvents ColMonitoringEnd As ColumnHeader
    Friend WithEvents ColMonitoringStatus As ColumnHeader
    Friend WithEvents ColMonitoringFile As ColumnHeader
    Friend WithEvents LblMonitoringEmpty As Label
    Friend WithEvents EditorPanel As Panel
    Friend WithEvents EditorHeaderPanel As Panel
    Friend WithEvents LblEditorEyebrow As Label
    Friend WithEvents LblEditorTitle As Label
    Friend WithEvents LblEditorSubtitle As Label
    Friend WithEvents EditorFooterPanel As Panel
    Friend WithEvents EditorActionFlow As FlowLayoutPanel
    Friend WithEvents LblEditorMessage As Label
    Friend WithEvents BtnCancelEditor As Button
    Friend WithEvents BtnEditorBack As Button
    Friend WithEvents BtnEditorNext As Button
    Friend WithEvents BtnSaveEditor As Button
    Friend WithEvents EditorTabs As TabControl
    Friend WithEvents TabCompanyEditor As TabPage
    Friend WithEvents LblCompanyEditorIntro As Label
    Friend WithEvents LblCompanyName As Label
    Friend WithEvents TxtCompanyName As TextBox
    Friend WithEvents LblCompanyType As Label
    Friend WithEvents CmbCompanyType As ComboBox
    Friend WithEvents PnlCompanyWarning As Panel
    Friend WithEvents LblCompanyWarning As Label
    Friend WithEvents ChkCompanyWarning As CheckBox
    Friend WithEvents ChkCompanyConfirmation As CheckBox
    Friend WithEvents BtnRouteToWorkSite As Button
    Friend WithEvents TabWorkSiteEditor As TabPage
    Friend WithEvents WizardProgressPanel As Panel
    Friend WithEvents LblWizardStepOne As Label
    Friend WithEvents LblWizardStepTwo As Label
    Friend WithEvents LblWizardStepThree As Label
    Friend WithEvents WorkSiteWizardTabs As TabControl
    Friend WithEvents TabWizardIdentity As TabPage
    Friend WithEvents TabWizardPayroll As TabPage
    Friend WithEvents TabWizardContract As TabPage
    Friend WithEvents LblLockedParentCaption As Label
    Friend WithEvents LblLockedParent As Label
    Friend WithEvents LblSiteName As Label
    Friend WithEvents TxtSiteName As TextBox
    Friend WithEvents LblSiteAddress As Label
    Friend WithEvents TxtSiteAddress As TextBox
    Friend WithEvents LblSchedule As Label
    Friend WithEvents CmbSchedule As ComboBox
    Friend WithEvents LblDailyWage As Label
    Friend WithEvents TxtDailyWage As TextBox
    Friend WithEvents LblContactPerson As Label
    Friend WithEvents TxtContactPerson As TextBox
    Friend WithEvents LblContactNumber As Label
    Friend WithEvents TxtContactNumber As TextBox
    Friend WithEvents LblContactEmail As Label
    Friend WithEvents TxtContactEmail As TextBox
    Friend WithEvents PnlInitialContract As Panel
    Friend WithEvents LblInitialContractTitle As Label
    Friend WithEvents LblInitialContractHelp As Label
    Friend WithEvents DtpInitialContractStart As DateTimePicker
    Friend WithEvents DtpInitialContractEnd As DateTimePicker
    Friend WithEvents BtnChooseInitialContract As Button
    Friend WithEvents LblInitialContractFile As Label
    Friend WithEvents TxtInitialContractRemarks As TextBox
    Friend WithEvents TabContractEditor As TabPage
    Friend WithEvents LblContractContext As Label
    Friend WithEvents LblContractStart As Label
    Friend WithEvents DtpContractStart As DateTimePicker
    Friend WithEvents LblContractEnd As Label
    Friend WithEvents DtpContractEnd As DateTimePicker
    Friend WithEvents BtnChooseContract As Button
    Friend WithEvents LblContractFile As Label
    Friend WithEvents LblContractRemarks As Label
    Friend WithEvents TxtContractRemarks As TextBox
    Friend WithEvents TabStatusEditor As TabPage
    Friend WithEvents LblStatusContext As Label
    Friend WithEvents LblStatusEffective As Label
    Friend WithEvents DtpStatusEffective As DateTimePicker
    Friend WithEvents LblStatusReason As Label
    Friend WithEvents CmbStatusReason As ComboBox
    Friend WithEvents LblStatusNote As Label
    Friend WithEvents ClientErrors As ErrorProvider
    Friend WithEvents ClientToolTip As ToolTip
    Friend WithEvents ContractFileDialog As OpenFileDialog
    Friend WithEvents SearchTimer As Timer
End Class
