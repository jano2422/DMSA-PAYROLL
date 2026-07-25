Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class FRM_HR_CLIENTS
    Private Enum InlineEditorMode
        None
        CreateCompany
        EditCompany
        CreateWorkSite
        EditWorkSite
        AddContract
        EditContract
        ChangeCompanyStatus
        ChangeWorkSiteStatus
        DeleteContract
    End Enum

    Private ReadOnly _service As New ClientManagementService()
    Private ReadOnly _assessmentTimer As New Timer With {.Interval = 320}
    Private _editorMode As InlineEditorMode
    Private _selectedCompany As CompanyRecord
    Private _selectedWorkSite As WorkSiteRecord
    Private _selectedContract As ContractRecord
    Private _suppressSelectionEvents As Boolean
    Private _contractSourcePath As String = String.Empty
    Private _suggestedCompanyId As Integer
    Private _pendingStatus As String = String.Empty
    Private _workSiteWizardStep As Integer
    Private _normalizingClientName As Boolean

    Public Sub New()
        InitializeComponent()
        AddHandler _assessmentTimer.Tick, AddressOf AssessmentTimer_Tick
    End Sub

    Private Sub FRM_HR_CLIENTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbCompanyStatus.SelectedItem = "Active"
        CmbContractMonitoringFilter.SelectedItem = "Expiring in 30 days"
        DtpInitialContractStart.Value = Date.Today
        DtpInitialContractEnd.Value = Date.Today.AddYears(1)
        DtpContractStart.Value = Date.Today
        DtpContractEnd.Value = Date.Today.AddYears(1)
        DtpStatusEffective.Value = Date.Today
        ConfigureToolTips()
        WorkspaceViews.SelectedTab = TabDirectoryView
        SetNavigation(BtnNavCompanies)
        ReloadCompanies()
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        WindowState = FormWindowState.Maximized
        ResizeColumns()
    End Sub

    Private Sub ConfigureToolTips()
        ClientToolTip.SetToolTip(BtnAddCompany, "Create the top-level legal organization named on the service agreement.")
        ClientToolTip.SetToolTip(BtnAddWorkSite, "Create a subclient under the selected client.")
        ClientToolTip.SetToolTip(LvCompanies, "Select the legal client first.")
        ClientToolTip.SetToolTip(LvWorkSites, "Subclients always remain inside the selected client.")
        ClientToolTip.SetToolTip(TxtCompanyName, "Names are automatically capitalized. Unsupported symbols are removed.")
        ClientToolTip.SetToolTip(TxtSiteName, "Names are automatically capitalized. Unsupported symbols are removed.")
    End Sub

    Private Sub ReloadCompanies(Optional preferredCompanyId As Integer = 0)
        If preferredCompanyId = 0 AndAlso _selectedCompany IsNot Nothing Then preferredCompanyId = _selectedCompany.Id
        Dim records As List(Of CompanyRecord)
        Try
            records = _service.GetCompanies(TxtCompanySearch.Text, CmbCompanyStatus.Text)
        Catch ex As Exception
            ShowMessage("The client directory could not be loaded. " & ex.Message)
            Return
        End Try

        _suppressSelectionEvents = True
        LvCompanies.BeginUpdate()
        LvCompanies.Items.Clear()
        Dim preferredItem As ListViewItem = Nothing
        For Each company As CompanyRecord In records
            Dim item As New ListViewItem(company.Name)
            item.SubItems.Add(company.WorkSiteCount.ToString(CultureInfo.InvariantCulture))
            item.SubItems.Add(company.Status)
            item.Tag = company
            LvCompanies.Items.Add(item)
            If company.Id = preferredCompanyId Then preferredItem = item
        Next
        LvCompanies.EndUpdate()
        _suppressSelectionEvents = False
        LblCompaniesCount.Text = records.Count.ToString(CultureInfo.InvariantCulture) & If(records.Count = 1, " client", " clients")
        LblCompaniesEmpty.Visible = records.Count = 0
        If LblCompaniesEmpty.Visible Then LblCompaniesEmpty.BringToFront()
        ResizeCompanyColumns()

        If preferredItem Is Nothing AndAlso LvCompanies.Items.Count > 0 Then preferredItem = LvCompanies.Items(0)
        If preferredItem IsNot Nothing Then
            preferredItem.Selected = True
            preferredItem.EnsureVisible()
            SelectCompany(DirectCast(preferredItem.Tag, CompanyRecord))
        Else
            ClearCompanySelection()
        End If
    End Sub

    Private Sub SelectCompany(company As CompanyRecord)
        If company Is Nothing Then
            ClearCompanySelection()
            Return
        End If
        _selectedCompany = company
        LblWorkspaceTitle.Text = company.Name
        LblWorkspaceSubtitle.Text = company.ClientType & " organization  ·  " & company.Status & "  ·  " & company.WorkSiteCount.ToString() & If(company.WorkSiteCount = 1, " subclient", " subclients")
        LblHierarchyCompany.Text = company.Name
        BtnAddWorkSite.Enabled = IsActive(company.Status)
        BtnEditCompany.Enabled = True
        BtnCompanyStatus.Enabled = True
        BtnCompanyStatus.Text = If(IsActive(company.Status), "Deactivate", "Reactivate")
        LoadWorkSites(company.Id)
    End Sub

    Private Sub LoadWorkSites(companyId As Integer, Optional preferredSiteId As Integer = 0)
        If preferredSiteId = 0 AndAlso _selectedWorkSite IsNot Nothing AndAlso _selectedWorkSite.CompanyId = companyId Then preferredSiteId = _selectedWorkSite.Id
        Dim records As List(Of WorkSiteRecord)
        Try
            records = _service.GetWorkSites(companyId)
        Catch ex As Exception
            ShowMessage("The subclient list could not be loaded. " & ex.Message)
            Return
        End Try

        _suppressSelectionEvents = True
        LvWorkSites.BeginUpdate()
        LvWorkSites.Items.Clear()
        Dim preferredItem As ListViewItem = Nothing
        For Each site As WorkSiteRecord In records
            Dim item As New ListViewItem(site.Name)
            item.SubItems.Add(site.Address)
            item.SubItems.Add(site.Status)
            item.Tag = site
            LvWorkSites.Items.Add(item)
            If site.Id = preferredSiteId Then preferredItem = item
        Next
        LvWorkSites.EndUpdate()
        _suppressSelectionEvents = False
        LblWorkSitesCount.Text = records.Count.ToString(CultureInfo.InvariantCulture) & " under client"
        LblWorkSitesEmpty.Text = "This client has no subclients yet." & Environment.NewLine &
                                 "Choose Add subclient to register its first payroll or service location."
        LblWorkSitesEmpty.Visible = records.Count = 0
        If LblWorkSitesEmpty.Visible Then LblWorkSitesEmpty.BringToFront()
        ResizeWorkSiteColumns()

        If preferredItem Is Nothing AndAlso LvWorkSites.Items.Count > 0 Then preferredItem = LvWorkSites.Items(0)
        If preferredItem IsNot Nothing Then
            preferredItem.Selected = True
            preferredItem.EnsureVisible()
            SelectWorkSite(DirectCast(preferredItem.Tag, WorkSiteRecord))
        Else
            ClearWorkSiteSelection()
        End If
    End Sub

    Private Sub SelectWorkSite(site As WorkSiteRecord)
        If site Is Nothing Then
            ClearWorkSiteSelection()
            Return
        End If
        _selectedWorkSite = site
        LblHierarchySite.Text = site.Name
        LblProfileBreadcrumb.Text = "Clients  ›  " & site.CompanyName & "  ›  " & site.Name
        LblProfileName.Text = site.Name
        LblProfileStatus.Text = site.Status
        If IsActive(site.Status) Then
            LblProfileStatus.BackColor = Color.FromArgb(226, 243, 238)
            LblProfileStatus.ForeColor = Color.Teal
        Else
            LblProfileStatus.BackColor = Color.FromArgb(253, 236, 236)
            LblProfileStatus.ForeColor = Color.FromArgb(153, 42, 42)
        End If
        LblOverviewName.Text = site.Name
        SetStatusPill(site.Status)
        LblOverviewAddress.Text = site.Address
        LblOverviewParent.Text = site.CompanyName
        LblOverviewSchedule.Text = site.ScheduleType
        LblOverviewWage.Text = "₱" & site.DailyWage.ToString("N0", CultureInfo.InvariantCulture)
        Dim contactLines As New List(Of String)()
        If Not String.IsNullOrWhiteSpace(site.ContactPerson) Then contactLines.Add(site.ContactPerson)
        If Not String.IsNullOrWhiteSpace(site.ContactNumber) Then contactLines.Add(site.ContactNumber)
        If Not String.IsNullOrWhiteSpace(site.ContactEmail) Then contactLines.Add(site.ContactEmail)
        LblOverviewContact.Text = If(contactLines.Count = 0, "No contact recorded.", String.Join(Environment.NewLine, contactLines))
        BtnEditWorkSite.Enabled = True
        BtnWorkSiteStatus.Enabled = True
        BtnOpenWorkSite.Enabled = True
        BtnWorkSiteStatus.Text = If(IsActive(site.Status), "Deactivate", "Reactivate")
        BtnAddContract.Enabled = IsActive(site.Status) AndAlso _selectedCompany IsNot Nothing AndAlso IsActive(_selectedCompany.Status)
        LoadContracts(site.Id)
        LoadStatusHistory(site.Id)
    End Sub

    Private Sub LoadContracts(siteId As Integer, Optional preferredContractId As Integer = 0)
        If preferredContractId = 0 AndAlso _selectedContract IsNot Nothing AndAlso _selectedContract.WorkSiteId = siteId Then preferredContractId = _selectedContract.Id
        Dim records As List(Of ContractRecord)
        Try
            records = _service.GetContracts(siteId)
        Catch ex As Exception
            ShowMessage("Contracts could not be loaded. " & ex.Message)
            Return
        End Try

        _suppressSelectionEvents = True
        LvContracts.BeginUpdate()
        LvContracts.Items.Clear()
        Dim preferredItem As ListViewItem = Nothing
        For Each contract As ContractRecord In records
            Dim item As New ListViewItem(contract.StartDate.ToString("dd MMM yyyy") & " – " & contract.EndDate.ToString("dd MMM yyyy"))
            item.SubItems.Add(contract.Status)
            item.SubItems.Add(Path.GetFileName(contract.FilePath))
            item.Tag = contract
            LvContracts.Items.Add(item)
            If contract.Id = preferredContractId Then preferredItem = item
        Next
        LvContracts.EndUpdate()
        _suppressSelectionEvents = False
        LblContractsEmpty.Visible = records.Count = 0
        If LblContractsEmpty.Visible Then LblContractsEmpty.BringToFront()
        UpdateProfileGuidance(records.Count)
        ResizeContractColumns()

        If preferredItem IsNot Nothing Then
            preferredItem.Selected = True
            preferredItem.EnsureVisible()
            SelectContract(DirectCast(preferredItem.Tag, ContractRecord))
        Else
            ClearContractSelection()
        End If
    End Sub

    Private Sub SelectContract(contract As ContractRecord)
        _selectedContract = contract
        If contract Is Nothing Then
            ClearContractSelection()
            Return
        End If
        LblHierarchyContract.Text = Path.GetFileName(contract.FilePath)
        LblContractSummary.Text = If(String.IsNullOrWhiteSpace(contract.Remarks), "No contract notes recorded.", contract.Remarks)
        BtnEditContract.Enabled = True
        BtnOpenContract.Enabled = True
        BtnRemoveContract.Enabled = True
    End Sub

    Private Sub LoadStatusHistory(workSiteId As Integer)
        LvStatusHistory.BeginUpdate()
        LvStatusHistory.Items.Clear()
        Try
            For Each record As ClientStatusHistoryRecord In _service.GetWorkSiteStatusHistory(workSiteId)
                Dim item As New ListViewItem(record.EffectiveDate.ToString("dd MMM yyyy"))
                item.SubItems.Add(record.Status)
                item.SubItems.Add(If(String.IsNullOrWhiteSpace(record.Reason), "No reason recorded", record.Reason))
                LvStatusHistory.Items.Add(item)
            Next
        Catch ex As Exception
            ShowMessage("Status history could not be loaded. " & ex.Message)
        Finally
            LvStatusHistory.EndUpdate()
        End Try
        LblStatusHistoryEmpty.Visible = LvStatusHistory.Items.Count = 0
        If LblStatusHistoryEmpty.Visible Then LblStatusHistoryEmpty.BringToFront()
    End Sub

    Private Sub UpdateProfileGuidance(contractCount As Integer)
        If _selectedWorkSite Is Nothing Then
            LblOverviewNextStep.Text = "Select a subclient to review its information, payroll setup, and contract readiness."
        ElseIf contractCount = 0 Then
            LblOverviewNextStep.Text = "Action needed: add the signed service agreement before this location is used for payroll."
        ElseIf String.IsNullOrWhiteSpace(_selectedWorkSite.ContactPerson) AndAlso
               String.IsNullOrWhiteSpace(_selectedWorkSite.ContactNumber) AndAlso
               String.IsNullOrWhiteSpace(_selectedWorkSite.ContactEmail) Then
            LblOverviewNextStep.Text = "Action needed: add a site contact so payroll questions have a clear owner."
        Else
            LblOverviewNextStep.Text = "Ready for review: confirm the payroll schedule, daily wage and current contract before processing."
        End If
    End Sub

    Private Sub OpenWorkSiteProfile()
        If _selectedWorkSite Is Nothing Then
            ShowGuidance("Select a subclient, then choose Open profile.")
            Return
        End If
        CloseEditor()
        WorkspaceViews.SelectedTab = TabWorkSiteProfile
        DetailsTabs.SelectedTab = TabOverview
        LblHeaderSection.Text = "SUBCLIENT PROFILE"
    End Sub

    Private Sub ShowDirectoryView()
        CloseEditor()
        WorkspaceViews.SelectedTab = TabDirectoryView
        LblHeaderSection.Text = "CLIENT DIRECTORY"
    End Sub

    Private Sub ShowSubclientDirectory()
        CloseEditor()
        WorkspaceViews.SelectedTab = TabDirectoryView
        LblHeaderSection.Text = "SUBCLIENT DIRECTORY"
        If _selectedCompany Is Nothing Then
            ShowGuidance("Choose a client to view and manage its subclients.")
            LvCompanies.Select()
        Else
            ShowGuidance("Managing subclients under " & _selectedCompany.Name & ".")
            LvWorkSites.Select()
        End If
    End Sub

    Private Sub LoadContractMonitoring()
        LvContractMonitoring.BeginUpdate()
        LvContractMonitoring.Items.Clear()
        Try
            Dim records As List(Of ContractMonitoringRecord) = _service.GetContractMonitoring(CmbContractMonitoringFilter.Text)
            For Each record As ContractMonitoringRecord In records
                Dim displayStatus As String
                If String.IsNullOrWhiteSpace(record.FilePath) OrElse Not File.Exists(record.FilePath) Then
                    displayStatus = "Missing file"
                ElseIf record.EndDate < Date.Today Then
                    displayStatus = "Expired"
                ElseIf record.EndDate <= Date.Today.AddDays(30) Then
                    displayStatus = "Renew soon"
                Else
                    displayStatus = If(String.IsNullOrWhiteSpace(record.Status), "Current", record.Status)
                End If
                Dim item As New ListViewItem(record.CompanyName)
                item.SubItems.Add(record.WorkSiteName)
                item.SubItems.Add(record.EndDate.ToString("dd MMM yyyy"))
                item.SubItems.Add(displayStatus)
                item.SubItems.Add(If(String.IsNullOrWhiteSpace(record.FilePath), "No attachment", Path.GetFileName(record.FilePath)))
                item.Tag = record
                LvContractMonitoring.Items.Add(item)
            Next
        Catch ex As Exception
            ShowMessage("Contract monitoring could not be loaded. " & ex.Message)
        Finally
            LvContractMonitoring.EndUpdate()
        End Try
        LblMonitoringEmpty.Visible = LvContractMonitoring.Items.Count = 0
        If LblMonitoringEmpty.Visible Then LblMonitoringEmpty.BringToFront()
        LblMonitoringSubtitle.Text = If(LvContractMonitoring.Items.Count = 0,
            "No agreements match this contract view.",
            LvContractMonitoring.Items.Count.ToString(CultureInfo.InvariantCulture) &
            If(LvContractMonitoring.Items.Count = 1, " agreement shown. ", " agreements shown. ") &
            "Double-click a row to open its subclient profile.")
        ResizeMonitoringColumns()
    End Sub

    Private Sub ClearCompanySelection()
        _selectedCompany = Nothing
        LblWorkspaceTitle.Text = "Choose a client"
        LblWorkspaceSubtitle.Text = "Client details and subclients will appear here."
        LblHierarchyCompany.Text = "No client selected"
        BtnAddWorkSite.Enabled = False
        BtnEditCompany.Enabled = False
        BtnCompanyStatus.Enabled = False
        LvWorkSites.Items.Clear()
        LblWorkSitesCount.Text = "0 under client"
        LblWorkSitesEmpty.Text = "Select a client to see its subclients."
        LblWorkSitesEmpty.Visible = True
        LblWorkSitesEmpty.BringToFront()
        ClearWorkSiteSelection()
    End Sub

    Private Sub ClearWorkSiteSelection()
        _selectedWorkSite = Nothing
        LblHierarchySite.Text = "No subclient selected"
        LblOverviewName.Text = "Select a subclient"
        LblOverviewParent.Text = "No parent client selected"
        UpdateProfileGuidance(0)
        SetStatusPill(String.Empty)
        LblOverviewAddress.Text = "—"
        LblOverviewSchedule.Text = "—"
        LblOverviewWage.Text = "—"
        LblOverviewContact.Text = "—"
        BtnEditWorkSite.Enabled = False
        BtnWorkSiteStatus.Enabled = False
        BtnOpenWorkSite.Enabled = False
        BtnAddContract.Enabled = False
        LvContracts.Items.Clear()
        LvStatusHistory.Items.Clear()
        LblContractsEmpty.Visible = False
        LblStatusHistoryEmpty.Visible = False
        ClearContractSelection()
    End Sub

    Private Sub ClearContractSelection()
        _selectedContract = Nothing
        LblHierarchyContract.Text = "No contract selected"
        LblContractSummary.Text = "Select a contract to see its notes."
        BtnEditContract.Enabled = False
        BtnOpenContract.Enabled = False
        BtnRemoveContract.Enabled = False
    End Sub

    Private Sub SetStatusPill(status As String)
        If String.IsNullOrWhiteSpace(status) Then
            LblOverviewStatus.Text = "No selection"
            LblOverviewStatus.BackColor = Color.FromArgb(235, 232, 226)
            LblOverviewStatus.ForeColor = Color.FromArgb(98, 108, 118)
        ElseIf IsActive(status) Then
            LblOverviewStatus.Text = "Active"
            LblOverviewStatus.BackColor = Color.FromArgb(226, 243, 238)
            LblOverviewStatus.ForeColor = Color.Teal
        Else
            LblOverviewStatus.Text = "Inactive"
            LblOverviewStatus.BackColor = Color.FromArgb(253, 236, 236)
            LblOverviewStatus.ForeColor = Color.FromArgb(153, 42, 42)
        End If
    End Sub

    Private Shared Function IsActive(status As String) As Boolean
        Return String.Equals(status, "Active", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Sub OpenCompanyEditor(createNew As Boolean)
        ResetEditor()
        _editorMode = If(createNew, InlineEditorMode.CreateCompany, InlineEditorMode.EditCompany)
        EditorTabs.SelectedTab = TabCompanyEditor
        LblEditorEyebrow.Text = "CLIENT ORGANIZATION"
        LblEditorTitle.Text = If(createNew, "Add client", "Edit client")
        LblEditorSubtitle.Text = "Only the top-level legal identity belongs here."
        BtnSaveEditor.Text = If(createNew, "Create client", "Save changes")
        ChkCompanyConfirmation.Visible = createNew
        BtnRouteToWorkSite.Visible = False
        If Not createNew AndAlso _selectedCompany IsNot Nothing Then
            TxtCompanyName.Text = _selectedCompany.Name
            CmbCompanyType.SelectedItem = _selectedCompany.ClientType
            ChkCompanyConfirmation.Checked = True
        End If
        ShowEditor()
        TxtCompanyName.Select()
    End Sub

    Private Sub OpenWorkSiteEditor(createNew As Boolean)
        If _selectedCompany Is Nothing Then
            ShowGuidance("Choose the parent client before adding a subclient.")
            Return
        End If
        If Not IsActive(_selectedCompany.Status) Then
            ShowGuidance("Reactivate the selected client before adding or editing a subclient.")
            Return
        End If
        ResetEditor()
        _editorMode = If(createNew, InlineEditorMode.CreateWorkSite, InlineEditorMode.EditWorkSite)
        EditorTabs.SelectedTab = TabWorkSiteEditor
        LblEditorEyebrow.Text = "CLIENT  →  SUBCLIENT"
        LblEditorTitle.Text = If(createNew, "Add subclient", "Edit subclient")
        LblEditorSubtitle.Text = "The parent client is locked to prevent misclassification."
        LblLockedParent.Text = _selectedCompany.Name
        BtnSaveEditor.Text = If(createNew, "Create subclient", "Save changes")
        PnlInitialContract.Visible = createNew
        _workSiteWizardStep = 0
        WorkSiteWizardTabs.SelectedTab = TabWizardIdentity
        If createNew Then
            DtpInitialContractStart.Value = Date.Today
            DtpInitialContractEnd.Value = Date.Today.AddYears(1)
        ElseIf _selectedWorkSite IsNot Nothing Then
            TxtSiteName.Text = _selectedWorkSite.Name
            TxtSiteAddress.Text = _selectedWorkSite.Address
            CmbSchedule.SelectedItem = _selectedWorkSite.ScheduleType
            TxtDailyWage.Text = _selectedWorkSite.DailyWage.ToString(CultureInfo.InvariantCulture)
            TxtContactPerson.Text = _selectedWorkSite.ContactPerson
            TxtContactNumber.Text = _selectedWorkSite.ContactNumber
            TxtContactEmail.Text = _selectedWorkSite.ContactEmail
        End If
        UpdateWizardNavigation()
        ShowEditor()
        TxtSiteName.Select()
    End Sub

    Private Sub OpenContractEditor(createNew As Boolean)
        If _selectedWorkSite Is Nothing Then
            ShowGuidance("Choose a subclient before adding a contract.")
            Return
        End If
        ResetEditor()
        _editorMode = If(createNew, InlineEditorMode.AddContract, InlineEditorMode.EditContract)
        EditorTabs.SelectedTab = TabContractEditor
        LblEditorEyebrow.Text = "SUBCLIENT  →  CONTRACT"
        LblEditorTitle.Text = If(createNew, "Add contract", "Edit contract")
        LblEditorSubtitle.Text = "Contract for " & _selectedWorkSite.Name
        LblContractContext.Text = _selectedCompany.Name & "  →  " & _selectedWorkSite.Name
        BtnSaveEditor.Text = If(createNew, "Add contract", "Save changes")
        BtnChooseContract.Visible = createNew
        If createNew Then
            DtpContractStart.Value = Date.Today
            DtpContractEnd.Value = Date.Today.AddYears(1)
        ElseIf _selectedContract IsNot Nothing Then
            DtpContractStart.Value = _selectedContract.StartDate
            DtpContractEnd.Value = _selectedContract.EndDate
            TxtContractRemarks.Text = _selectedContract.Remarks
            LblContractFile.Text = Path.GetFileName(_selectedContract.FilePath) & " (attachment retained)"
        End If
        ShowEditor()
    End Sub

    Private Sub OpenStatusEditor(forCompany As Boolean)
        ResetEditor()
        If forCompany Then
            If _selectedCompany Is Nothing Then Return
            _pendingStatus = If(IsActive(_selectedCompany.Status), "Inactive", "Active")
            If _pendingStatus = "Inactive" Then
                Dim activeSites As Integer = 0
                For Each site As WorkSiteRecord In _service.GetWorkSites(_selectedCompany.Id)
                    If IsActive(site.Status) Then activeSites += 1
                Next
                If activeSites > 0 Then
                    ShowGuidance("Deactivate the " & activeSites.ToString() & " active subclient" & If(activeSites = 1, String.Empty, "s") & " before deactivating this client.")
                    Return
                End If
            End If
            _editorMode = InlineEditorMode.ChangeCompanyStatus
            LblEditorEyebrow.Text = "CLIENT STATUS"
            LblStatusContext.Text = _selectedCompany.Name & Environment.NewLine & "New status: " & _pendingStatus
        Else
            If _selectedWorkSite Is Nothing Then Return
            _pendingStatus = If(IsActive(_selectedWorkSite.Status), "Inactive", "Active")
            If _pendingStatus = "Active" AndAlso (_selectedCompany Is Nothing OrElse Not IsActive(_selectedCompany.Status)) Then
                ShowGuidance("Reactivate the parent client before reactivating this subclient.")
                Return
            End If
            _editorMode = InlineEditorMode.ChangeWorkSiteStatus
            LblEditorEyebrow.Text = "SUBCLIENT STATUS"
            LblStatusContext.Text = _selectedWorkSite.Name & Environment.NewLine & "New status: " & _pendingStatus
        End If
        EditorTabs.SelectedTab = TabStatusEditor
        LblEditorTitle.Text = If(_pendingStatus = "Active", "Reactivate record", "Deactivate record")
        LblEditorSubtitle.Text = "Record an effective date and audit reason."
        BtnSaveEditor.Text = If(_pendingStatus = "Active", "Reactivate", "Deactivate")
        DtpStatusEffective.Visible = True
        LblStatusEffective.Visible = True
        CmbStatusReason.Visible = True
        LblStatusReason.Visible = True
        CmbStatusReason.Items.Clear()
        CmbStatusReason.Items.AddRange(If(_pendingStatus = "Active",
            New Object() {"Contract renewed", "Operations resumed", "Record corrected"},
            New Object() {"Contract completed", "Contract terminated", "Operations suspended"}))
        ShowEditor()
    End Sub

    Private Sub OpenDeleteContractEditor()
        If _selectedContract Is Nothing Then Return
        ResetEditor()
        _editorMode = InlineEditorMode.DeleteContract
        EditorTabs.SelectedTab = TabStatusEditor
        LblEditorEyebrow.Text = "REMOVE CONTRACT"
        LblEditorTitle.Text = "Remove attachment"
        LblEditorSubtitle.Text = "This action removes the contract record from the subclient."
        LblStatusContext.Text = Path.GetFileName(_selectedContract.FilePath) & Environment.NewLine & _selectedWorkSite.Name
        LblStatusEffective.Visible = False
        DtpStatusEffective.Visible = False
        LblStatusReason.Visible = False
        CmbStatusReason.Visible = False
        LblStatusNote.Text = "Review the subclient and file name above. Select Remove contract to continue."
        BtnSaveEditor.Text = "Remove contract"
        BtnSaveEditor.BackColor = Color.FromArgb(153, 42, 42)
        ShowEditor()
    End Sub

    Private Sub ShowEditor()
        MainCanvas.Visible = False
        EditorPanel.Dock = DockStyle.Fill
        EditorPanel.Visible = True
        WorkspacePanel.Controls.SetChildIndex(EditorPanel, 0)
        EditorPanel.BringToFront()
        ResizeColumns()
    End Sub

    Private Sub CloseEditor()
        _assessmentTimer.Stop()
        EditorPanel.Visible = False
        EditorPanel.Dock = DockStyle.Right
        MainCanvas.Visible = True
        _editorMode = InlineEditorMode.None
        ClientErrors.Clear()
        ResizeColumns()
    End Sub

    Private Sub ResetEditor()
        ClientErrors.Clear()
        LblEditorMessage.Text = String.Empty
        BtnSaveEditor.BackColor = Color.Teal
        BtnSaveEditor.Visible = True
        BtnEditorBack.Visible = False
        BtnEditorNext.Visible = False
        _contractSourcePath = String.Empty
        _suggestedCompanyId = 0
        _pendingStatus = String.Empty
        TxtCompanyName.Clear()
        CmbCompanyType.SelectedIndex = -1
        ChkCompanyConfirmation.Checked = False
        ChkCompanyWarning.Checked = False
        PnlCompanyWarning.Visible = False
        BtnRouteToWorkSite.Visible = False
        TxtSiteName.Clear()
        TxtSiteAddress.Clear()
        CmbSchedule.SelectedIndex = -1
        TxtDailyWage.Clear()
        TxtContactPerson.Clear()
        TxtContactNumber.Clear()
        TxtContactEmail.Clear()
        TxtInitialContractRemarks.Clear()
        LblInitialContractFile.Text = "PDF or JPG, up to 10 MB"
        TxtContractRemarks.Clear()
        LblContractFile.Text = "PDF or JPG, up to 10 MB"
        DtpStatusEffective.Value = Date.Today
        CmbStatusReason.Items.Clear()
        CmbStatusReason.SelectedIndex = -1
        LblStatusNote.Text = "The record changes only after an effective date and audit reason are provided."
        LblStatusEffective.Visible = True
        DtpStatusEffective.Visible = True
        LblStatusReason.Visible = True
        CmbStatusReason.Visible = True
        _workSiteWizardStep = 0
    End Sub

    Private Sub UpdateWizardNavigation()
        Dim lastStep As Integer = If(_editorMode = InlineEditorMode.CreateWorkSite, 2, 1)
        _workSiteWizardStep = Math.Max(0, Math.Min(_workSiteWizardStep, lastStep))
        WorkSiteWizardTabs.SelectedIndex = _workSiteWizardStep
        BtnEditorBack.Visible = _workSiteWizardStep > 0
        BtnEditorNext.Visible = _workSiteWizardStep < lastStep
        BtnSaveEditor.Visible = _workSiteWizardStep = lastStep

        Dim activeColor As Color = Color.FromArgb(111, 29, 48)
        Dim inactiveColor As Color = Color.FromArgb(98, 108, 118)
        LblWizardStepOne.ForeColor = If(_workSiteWizardStep = 0, activeColor, inactiveColor)
        LblWizardStepTwo.ForeColor = If(_workSiteWizardStep = 1, activeColor, inactiveColor)
        LblWizardStepThree.ForeColor = If(_workSiteWizardStep = 2, activeColor, inactiveColor)
        LblWizardStepThree.Visible = _editorMode = InlineEditorMode.CreateWorkSite
    End Sub

    Private Function ValidateWizardStep(stepIndex As Integer) As Boolean
        ClientErrors.Clear()
        LblEditorMessage.Text = String.Empty
        Select Case stepIndex
            Case 0
                If String.IsNullOrWhiteSpace(TxtSiteName.Text) Then
                    SetFieldError(TxtSiteName, "Enter the subclient or detachment name.")
                    Return False
                End If
                If String.IsNullOrWhiteSpace(TxtSiteAddress.Text) Then
                    SetFieldError(TxtSiteAddress, "Enter the service address.")
                    Return False
                End If
            Case 1
                Dim wage As Integer
                If CmbSchedule.SelectedIndex < 0 Then
                    SetFieldError(CmbSchedule, "Choose the payroll schedule.")
                    Return False
                End If
                If Not Integer.TryParse(TxtDailyWage.Text.Trim(), wage) OrElse wage <= 0 Then
                    SetFieldError(TxtDailyWage, "Enter a positive whole-peso daily wage.")
                    Return False
                End If
                If Not IsValidPhone(TxtContactNumber.Text) Then
                    SetFieldError(TxtContactNumber, "Use 7–15 digits; spaces, +, parentheses and hyphens are allowed.")
                    Return False
                End If
                If Not IsValidEmail(TxtContactEmail.Text) Then
                    SetFieldError(TxtContactEmail, "Enter a complete email address, for example name@company.ph.")
                    Return False
                End If
            Case 2
                If DtpInitialContractEnd.Value.Date < DtpInitialContractStart.Value.Date Then
                    SetFieldError(DtpInitialContractEnd, "The contract end date cannot be before its start date.")
                    Return False
                End If
                Dim fileProblem As String = ValidateContractFile(_contractSourcePath)
                If Not String.IsNullOrWhiteSpace(fileProblem) Then
                    SetFieldError(BtnChooseInitialContract, fileProblem)
                    Return False
                End If
        End Select
        Return True
    End Function

    Private Sub SaveEditor()
        ClientErrors.Clear()
        LblEditorMessage.Text = String.Empty
        Select Case _editorMode
            Case InlineEditorMode.CreateCompany, InlineEditorMode.EditCompany
                SaveCompany()
            Case InlineEditorMode.CreateWorkSite, InlineEditorMode.EditWorkSite
                SaveWorkSite()
            Case InlineEditorMode.AddContract, InlineEditorMode.EditContract
                SaveContract()
            Case InlineEditorMode.ChangeCompanyStatus, InlineEditorMode.ChangeWorkSiteStatus
                SaveStatusChange()
            Case InlineEditorMode.DeleteContract
                SaveContractRemoval()
        End Select
    End Sub

    Private Sub SaveCompany()
        Dim name As String = ClientManagementService.NormalizeClientNameInput(TxtCompanyName.Text)
        If String.IsNullOrWhiteSpace(name) Then
            SetFieldError(TxtCompanyName, "Enter the registered legal client name.")
            Return
        End If
        If CmbCompanyType.SelectedIndex < 0 Then
            SetFieldError(CmbCompanyType, "Choose Private or Government.")
            Return
        End If
        If _editorMode = InlineEditorMode.CreateCompany AndAlso Not ChkCompanyConfirmation.Checked Then
            SetFieldError(ChkCompanyConfirmation, "Confirm that this is a top-level legal organization.")
            Return
        End If

        Dim excludeId As Integer? = If(_editorMode = InlineEditorMode.EditCompany AndAlso _selectedCompany IsNot Nothing, CType(_selectedCompany.Id, Integer?), Nothing)
        Dim assessment As ClientNameAssessment = _service.AssessCompanyName(name, excludeId)
        PresentCompanyAssessment(assessment)
        If Not assessment.IsValid Then
            SetFieldError(TxtCompanyName, assessment.ErrorMessage)
            Return
        End If
        If Not String.IsNullOrWhiteSpace(assessment.WarningMessage) AndAlso Not ChkCompanyWarning.Checked Then
            SetFieldError(ChkCompanyWarning, "Verify the warning before saving this as a separate legal client.")
            Return
        End If

        Dim creating As Boolean = _editorMode = InlineEditorMode.CreateCompany
        Dim result As ClientOperationResult
        If _editorMode = InlineEditorMode.CreateCompany Then
            result = _service.CreateCompany(name, CmbCompanyType.Text)
        Else
            result = _service.UpdateCompany(_selectedCompany.Id, name, CmbCompanyType.Text)
        End If
        If Not CompleteOperation(result) Then Return
        Dim savedId As Integer = result.RecordId
        CloseEditor()
        ReloadCompanies(savedId)
        ShowSuccess(If(creating, "Client created.", "Client details updated."))
    End Sub

    Private Sub SaveWorkSite()
        If _selectedCompany Is Nothing Then
            ShowEditorError("Choose a parent client first.")
            Return
        End If
        Dim wage As Integer
        If String.IsNullOrWhiteSpace(TxtSiteName.Text) Then
            SetFieldError(TxtSiteName, "Enter the subclient or detachment name.")
            Return
        End If
        If String.IsNullOrWhiteSpace(TxtSiteAddress.Text) Then
            SetFieldError(TxtSiteAddress, "Enter the service address.")
            Return
        End If
        If CmbSchedule.SelectedIndex < 0 Then
            SetFieldError(CmbSchedule, "Choose the payroll schedule.")
            Return
        End If
        If Not Integer.TryParse(TxtDailyWage.Text.Trim(), wage) OrElse wage <= 0 Then
            SetFieldError(TxtDailyWage, "Enter a positive whole-peso daily wage.")
            Return
        End If
        If Not IsValidPhone(TxtContactNumber.Text) Then
            SetFieldError(TxtContactNumber, "Use 7–15 digits; spaces, +, parentheses and hyphens are allowed.")
            Return
        End If
        If Not IsValidEmail(TxtContactEmail.Text) Then
            SetFieldError(TxtContactEmail, "Enter a complete email address, for example name@company.ph.")
            Return
        End If

        Dim draft As New WorkSiteDraft With {
            .Id = If(_editorMode = InlineEditorMode.EditWorkSite AndAlso _selectedWorkSite IsNot Nothing, _selectedWorkSite.Id, 0),
            .CompanyId = _selectedCompany.Id,
            .CompanyName = _selectedCompany.Name,
            .Name = ClientManagementService.NormalizeClientNameInput(TxtSiteName.Text),
            .Address = ClientManagementService.CleanDisplayName(TxtSiteAddress.Text),
            .DailyWage = wage,
            .ScheduleType = CmbSchedule.Text,
            .ContactPerson = ClientManagementService.CleanDisplayName(TxtContactPerson.Text),
            .ContactNumber = TxtContactNumber.Text.Trim(),
            .ContactEmail = TxtContactEmail.Text.Trim()
        }

        Dim result As ClientOperationResult
        If _editorMode = InlineEditorMode.CreateWorkSite Then
            If DtpInitialContractEnd.Value.Date < DtpInitialContractStart.Value.Date Then
                SetFieldError(DtpInitialContractEnd, "The contract end date cannot be before its start date.")
                Return
            End If
            Dim fileProblem As String = ValidateContractFile(_contractSourcePath)
            If Not String.IsNullOrWhiteSpace(fileProblem) Then
                SetFieldError(BtnChooseInitialContract, fileProblem)
                Return
            End If
            Dim contract As New ContractDraft With {
                .StartDate = DtpInitialContractStart.Value.Date,
                .EndDate = DtpInitialContractEnd.Value.Date,
                .Remarks = TxtInitialContractRemarks.Text.Trim(),
                .SourceFilePath = _contractSourcePath
            }
            result = _service.CreateWorkSite(draft, contract)
        Else
            result = _service.UpdateWorkSite(draft)
        End If
        If Not CompleteOperation(result) Then Return
        Dim siteId As Integer = result.RecordId
        Dim createMode As Boolean = _editorMode = InlineEditorMode.CreateWorkSite
        CloseEditor()
        LoadWorkSites(_selectedCompany.Id, siteId)
        ShowSuccess(If(createMode, "Subclient and initial contract created under " & _selectedCompany.Name & ".", "Subclient details updated."))
    End Sub

    Private Sub SaveContract()
        If _selectedWorkSite Is Nothing Then Return
        If DtpContractEnd.Value.Date < DtpContractStart.Value.Date Then
            SetFieldError(DtpContractEnd, "The contract end date cannot be before its start date.")
            Return
        End If
        If _editorMode = InlineEditorMode.AddContract Then
            Dim problem As String = ValidateContractFile(_contractSourcePath)
            If Not String.IsNullOrWhiteSpace(problem) Then
                SetFieldError(BtnChooseContract, problem)
                Return
            End If
        End If
        Dim draft As New ContractDraft With {
            .StartDate = DtpContractStart.Value.Date,
            .EndDate = DtpContractEnd.Value.Date,
            .Remarks = TxtContractRemarks.Text.Trim(),
            .SourceFilePath = If(_editorMode = InlineEditorMode.AddContract, _contractSourcePath, String.Empty)
        }
        Dim adding As Boolean = _editorMode = InlineEditorMode.AddContract
        Dim result As ClientOperationResult = If(adding,
            _service.CreateContract(_selectedWorkSite.Id, draft),
            _service.UpdateContract(_selectedContract.Id, draft))
        If Not CompleteOperation(result) Then Return
        Dim contractId As Integer = result.RecordId
        CloseEditor()
        LoadContracts(_selectedWorkSite.Id, contractId)
        ShowSuccess(If(adding, "Contract added to " & _selectedWorkSite.Name & ".", "Contract dates and notes updated."))
    End Sub

    Private Sub SaveStatusChange()
        If CmbStatusReason.SelectedIndex < 0 Then
            SetFieldError(CmbStatusReason, "Choose the reason for this status change.")
            Return
        End If
        GlobalVariables.dClient_Deactivation_Date = DtpStatusEffective.Value.Date
        GlobalVariables.sReason_for_Deactivation_Activation = CmbStatusReason.Text
        Dim companyChange As Boolean = _editorMode = InlineEditorMode.ChangeCompanyStatus
        Dim companyId As Integer = If(_selectedCompany Is Nothing, 0, _selectedCompany.Id)
        Dim siteId As Integer = If(_selectedWorkSite Is Nothing, 0, _selectedWorkSite.Id)
        Dim recordName As String = If(companyChange, _selectedCompany.Name, _selectedWorkSite.Name)
        Dim result As ClientOperationResult = If(companyChange,
            _service.SetCompanyStatus(companyId, _pendingStatus),
            _service.SetWorkSiteStatus(siteId, _pendingStatus))
        GlobalVariables.sReason_for_Deactivation_Activation = String.Empty
        If Not CompleteOperation(result) Then Return
        Dim changedStatus As String = _pendingStatus
        CloseEditor()
        If companyChange Then
            ReloadCompanies(companyId)
        Else
            LoadWorkSites(companyId, siteId)
        End If
        ShowSuccess(recordName & " is now " & changedStatus.ToLowerInvariant() & ".")
    End Sub

    Private Sub SaveContractRemoval()
        If _selectedContract Is Nothing OrElse _selectedWorkSite Is Nothing Then Return
        Dim siteId As Integer = _selectedWorkSite.Id
        Dim result As ClientOperationResult = _service.DeleteContract(_selectedContract.Id)
        If Not CompleteOperation(result) Then Return
        CloseEditor()
        LoadContracts(siteId)
        ShowSuccess("Contract removed.")
    End Sub

    Private Function CompleteOperation(result As ClientOperationResult) As Boolean
        If result Is Nothing OrElse Not result.Success Then
            ShowEditorError(If(result Is Nothing, "Nothing was saved.", result.Message))
            Return False
        End If
        Return True
    End Function

    Private Sub PresentCompanyAssessment(assessment As ClientNameAssessment)
        If assessment Is Nothing Then Return
        _suggestedCompanyId = assessment.SuggestedCompanyId
        If Not assessment.IsValid Then
            PnlCompanyWarning.BackColor = Color.FromArgb(253, 236, 236)
            LblCompanyWarning.ForeColor = Color.FromArgb(153, 42, 42)
            LblCompanyWarning.Text = assessment.ErrorMessage
            ChkCompanyWarning.Visible = False
            PnlCompanyWarning.Visible = True
            BtnRouteToWorkSite.Visible = False
        ElseIf Not String.IsNullOrWhiteSpace(assessment.WarningMessage) Then
            PnlCompanyWarning.BackColor = Color.FromArgb(255, 247, 225)
            LblCompanyWarning.ForeColor = Color.FromArgb(123, 82, 18)
            LblCompanyWarning.Text = assessment.WarningMessage
            ChkCompanyWarning.Visible = True
            PnlCompanyWarning.Visible = True
            If assessment.SuggestedCompanyId > 0 Then
                BtnRouteToWorkSite.Text = "Add this as a subclient under " & assessment.SuggestedCompanyName
                BtnRouteToWorkSite.Visible = True
            Else
                BtnRouteToWorkSite.Visible = False
            End If
        Else
            PnlCompanyWarning.Visible = False
            BtnRouteToWorkSite.Visible = False
        End If
    End Sub

    Private Sub SetFieldError(control As Control, message As String)
        ClientErrors.SetError(control, message)
        ShowEditorError(message)
        control.Select()
    End Sub

    Private Sub ShowEditorError(message As String)
        LblEditorMessage.Text = message
    End Sub

    Private Sub ShowMessage(message As String)
        LblWorkspaceMessage.Text = message
        LblWorkspaceMessage.BackColor = Color.FromArgb(253, 236, 236)
        LblWorkspaceMessage.ForeColor = Color.FromArgb(153, 42, 42)
        LblWorkspaceMessage.Visible = True
    End Sub

    Private Sub ShowGuidance(message As String)
        LblWorkspaceMessage.Text = message
        LblWorkspaceMessage.BackColor = Color.FromArgb(255, 247, 225)
        LblWorkspaceMessage.ForeColor = Color.FromArgb(123, 82, 18)
        LblWorkspaceMessage.Visible = True
    End Sub

    Private Sub ShowSuccess(message As String)
        LblWorkspaceMessage.Text = message
        LblWorkspaceMessage.BackColor = Color.FromArgb(226, 243, 238)
        LblWorkspaceMessage.ForeColor = Color.Teal
        LblWorkspaceMessage.Visible = True
    End Sub

    Private Sub ChooseContractFile(label As Label, button As Button)
        If ContractFileDialog.ShowDialog(Me) <> DialogResult.OK Then Return
        Dim problem As String = ValidateContractFile(ContractFileDialog.FileName)
        If Not String.IsNullOrWhiteSpace(problem) Then
            SetFieldError(button, problem)
            Return
        End If
        _contractSourcePath = ContractFileDialog.FileName
        label.Text = Path.GetFileName(_contractSourcePath) & "  ·  " & FormatFileSize(New FileInfo(_contractSourcePath).Length)
        label.ForeColor = Color.Teal
        ClientErrors.SetError(button, String.Empty)
    End Sub

    Friend Shared Function ValidateContractFile(path As String) As String
        If String.IsNullOrWhiteSpace(path) Then Return "Choose the signed contract file."
        If Not File.Exists(path) Then Return "The selected contract file no longer exists."
        Dim extension As String = IO.Path.GetExtension(path).ToLowerInvariant()
        If extension <> ".pdf" AndAlso extension <> ".jpg" AndAlso extension <> ".jpeg" Then Return "Use a PDF or JPG contract file."
        Dim length As Long = New FileInfo(path).Length
        If length <= 0 Then Return "The selected contract file is empty."
        If length > 10L * 1024L * 1024L Then Return "The contract file must be 10 MB or smaller."
        Return String.Empty
    End Function

    Private Shared Function FormatFileSize(bytes As Long) As String
        If bytes >= 1024L * 1024L Then Return (bytes / (1024.0R * 1024.0R)).ToString("0.0") & " MB"
        Return Math.Max(1, bytes \ 1024L).ToString() & " KB"
    End Function

    Private Shared Function IsValidPhone(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return True
        If Not Regex.IsMatch(value, "^[0-9+()\-\s]+$") Then Return False
        Dim digits As Integer = value.Count(Function(character) Char.IsDigit(character))
        Return digits >= 7 AndAlso digits <= 15
    End Function

    Private Shared Function IsValidEmail(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return True
        Try
            Dim address As New MailAddress(value.Trim())
            Return String.Equals(address.Address, value.Trim(), StringComparison.OrdinalIgnoreCase)
        Catch
            Return False
        End Try
    End Function

    Private Sub ResizeColumns()
        ResizeCompanyColumns()
        ResizeWorkSiteColumns()
        ResizeContractColumns()
        ResizeStatusHistoryColumns()
        ResizeMonitoringColumns()
    End Sub

    Private Sub ResizeCompanyColumns()
        If LvCompanies.ClientSize.Width <= 40 Then Return
        ColSiteCount.Width = 80
        ColCompanyStatus.Width = 72
        ColCompany.Width = Math.Max(120, LvCompanies.ClientSize.Width - ColSiteCount.Width - ColCompanyStatus.Width - 6)
    End Sub

    Private Sub ResizeWorkSiteColumns()
        If LvWorkSites.ClientSize.Width <= 40 Then Return
        ColSiteStatus.Width = 64
        ColSiteAddress.Width = Math.Max(80, CInt((LvWorkSites.ClientSize.Width - ColSiteStatus.Width - 6) * 0.38))
        ColSiteName.Width = Math.Max(110, LvWorkSites.ClientSize.Width - ColSiteAddress.Width - ColSiteStatus.Width - 6)
    End Sub

    Private Sub ResizeContractColumns()
        If LvContracts.ClientSize.Width <= 40 Then Return
        ColContractStatus.Width = 72
        ColContractPeriod.Width = 154
        ColContractFile.Width = Math.Max(100, LvContracts.ClientSize.Width - ColContractPeriod.Width - ColContractStatus.Width - 6)
    End Sub

    Private Sub ResizeStatusHistoryColumns()
        If LvStatusHistory.ClientSize.Width <= 100 Then Return
        ColHistoryDate.Width = 170
        ColHistoryStatus.Width = 150
        ColHistoryReason.Width = Math.Max(220, LvStatusHistory.ClientSize.Width - ColHistoryDate.Width - ColHistoryStatus.Width - 6)
    End Sub

    Private Sub ResizeMonitoringColumns()
        If LvContractMonitoring.ClientSize.Width <= 100 Then Return
        ColMonitoringEnd.Width = 130
        ColMonitoringStatus.Width = 120
        ColMonitoringFile.Width = Math.Max(160, CInt(LvContractMonitoring.ClientSize.Width * 0.22))
        Dim remaining As Integer = LvContractMonitoring.ClientSize.Width - ColMonitoringEnd.Width - ColMonitoringStatus.Width - ColMonitoringFile.Width - 8
        ColMonitoringCompany.Width = Math.Max(180, remaining \ 2)
        ColMonitoringSite.Width = Math.Max(180, remaining - ColMonitoringCompany.Width)
    End Sub

    Private Sub SetNavigation(activeButton As Button)
        For Each button As Button In New Button() {BtnNavCompanies, BtnNavSites, BtnNavContracts}
            Dim active As Boolean = button Is activeButton
            button.BackColor = If(active, Color.FromArgb(255, 224, 192), Color.FromArgb(255, 192, 128))
            button.ForeColor = If(active, Color.FromArgb(111, 29, 48), Color.FromArgb(31, 41, 51))
            button.FlatAppearance.BorderColor = If(active, Color.FromArgb(111, 29, 48), Color.FromArgb(224, 176, 128))
            button.FlatAppearance.BorderSize = If(active, 2, 1)
        Next
    End Sub

    Private Sub AssessmentTimer_Tick(sender As Object, e As EventArgs)
        _assessmentTimer.Stop()
        If _editorMode <> InlineEditorMode.CreateCompany AndAlso _editorMode <> InlineEditorMode.EditCompany Then Return
        If String.IsNullOrWhiteSpace(TxtCompanyName.Text) Then
            PnlCompanyWarning.Visible = False
            BtnRouteToWorkSite.Visible = False
            Return
        End If
        Dim excludeId As Integer? = If(_editorMode = InlineEditorMode.EditCompany AndAlso _selectedCompany IsNot Nothing, CType(_selectedCompany.Id, Integer?), Nothing)
        PresentCompanyAssessment(_service.AssessCompanyName(TxtCompanyName.Text, excludeId))
    End Sub

    Private Sub TxtCompanyName_TextChanged(sender As Object, e As EventArgs) Handles TxtCompanyName.TextChanged
        If _normalizingClientName Then Return
        NormalizeClientNameTextBox(TxtCompanyName)
        _assessmentTimer.Stop()
        _assessmentTimer.Start()
        ChkCompanyWarning.Checked = False
        _suggestedCompanyId = 0
        BtnRouteToWorkSite.Visible = False
        ClientErrors.SetError(TxtCompanyName, String.Empty)
    End Sub

    Private Sub TxtSiteName_TextChanged(sender As Object, e As EventArgs) Handles TxtSiteName.TextChanged
        If _normalizingClientName Then Return
        NormalizeClientNameTextBox(TxtSiteName)
        ClientErrors.SetError(TxtSiteName, String.Empty)
    End Sub

    Private Sub ClientName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCompanyName.KeyPress, TxtSiteName.KeyPress
        If Char.IsControl(e.KeyChar) Then Return
        If Not ClientManagementService.IsAllowedClientNameCharacter(e.KeyChar) Then
            e.Handled = True
            Dim input As Control = TryCast(sender, Control)
            If input IsNot Nothing Then
                ClientErrors.SetError(input, "Use letters, numbers, spaces, and only &, apostrophes, periods, commas, parentheses, or hyphens.")
            End If
        End If
    End Sub

    Private Sub NormalizeClientNameTextBox(input As TextBox)
        Dim original As String = input.Text
        Dim caret As Integer = Math.Max(0, Math.Min(input.SelectionStart, original.Length))
        Dim prefix As String = original.Substring(0, caret)
        Dim normalized As String = ClientManagementService.NormalizeClientNameInput(
            original,
            original.Length > 0 AndAlso Char.IsWhiteSpace(original(original.Length - 1)))
        If String.Equals(original, normalized, StringComparison.Ordinal) Then Return

        Dim normalizedPrefix As String = ClientManagementService.NormalizeClientNameInput(
            prefix,
            prefix.Length > 0 AndAlso Char.IsWhiteSpace(prefix(prefix.Length - 1)))
        _normalizingClientName = True
        Try
            input.Text = normalized
            input.SelectionStart = Math.Min(normalizedPrefix.Length, normalized.Length)
            input.SelectionLength = 0
        Finally
            _normalizingClientName = False
        End Try
    End Sub

    Private Sub TxtCompanySearch_TextChanged(sender As Object, e As EventArgs) Handles TxtCompanySearch.TextChanged
        SearchTimer.Stop()
        SearchTimer.Start()
    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs) Handles SearchTimer.Tick
        SearchTimer.Stop()
        ReloadCompanies()
    End Sub

    Private Sub LvCompanies_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvCompanies.SelectedIndexChanged
        If _suppressSelectionEvents Then Return
        If LvCompanies.SelectedItems.Count = 0 Then Return
        CloseEditor()
        SelectCompany(TryCast(LvCompanies.SelectedItems(0).Tag, CompanyRecord))
    End Sub

    Private Sub LvWorkSites_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvWorkSites.SelectedIndexChanged
        If _suppressSelectionEvents Then Return
        If LvWorkSites.SelectedItems.Count = 0 Then Return
        CloseEditor()
        SelectWorkSite(TryCast(LvWorkSites.SelectedItems(0).Tag, WorkSiteRecord))
    End Sub

    Private Sub LvContracts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvContracts.SelectedIndexChanged
        If _suppressSelectionEvents Then Return
        If LvContracts.SelectedItems.Count = 0 Then
            ClearContractSelection()
        Else
            SelectContract(TryCast(LvContracts.SelectedItems(0).Tag, ContractRecord))
        End If
    End Sub

    Private Sub CmbCompanyStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCompanyStatus.SelectedIndexChanged
        If IsHandleCreated Then ReloadCompanies()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ReloadCompanies()
    End Sub

    Private Sub BtnAddCompany_Click(sender As Object, e As EventArgs) Handles BtnAddCompany.Click
        OpenCompanyEditor(True)
    End Sub

    Private Sub BtnEditCompany_Click(sender As Object, e As EventArgs) Handles BtnEditCompany.Click
        If _selectedCompany IsNot Nothing Then OpenCompanyEditor(False)
    End Sub

    Private Sub BtnAddWorkSite_Click(sender As Object, e As EventArgs) Handles BtnAddWorkSite.Click
        OpenWorkSiteEditor(True)
    End Sub

    Private Sub BtnEditWorkSite_Click(sender As Object, e As EventArgs) Handles BtnEditWorkSite.Click
        If _selectedWorkSite IsNot Nothing Then OpenWorkSiteEditor(False)
    End Sub

    Private Sub BtnCompanyStatus_Click(sender As Object, e As EventArgs) Handles BtnCompanyStatus.Click
        OpenStatusEditor(True)
    End Sub

    Private Sub BtnWorkSiteStatus_Click(sender As Object, e As EventArgs) Handles BtnWorkSiteStatus.Click
        OpenStatusEditor(False)
    End Sub

    Private Sub BtnAddContract_Click(sender As Object, e As EventArgs) Handles BtnAddContract.Click
        OpenContractEditor(True)
    End Sub

    Private Sub BtnEditContract_Click(sender As Object, e As EventArgs) Handles BtnEditContract.Click
        If _selectedContract IsNot Nothing Then OpenContractEditor(False)
    End Sub

    Private Sub BtnOpenContract_Click(sender As Object, e As EventArgs) Handles BtnOpenContract.Click
        If _selectedContract Is Nothing Then Return
        If Not File.Exists(_selectedContract.FilePath) Then
            ShowMessage("The contract file is missing from " & _selectedContract.FilePath)
            Return
        End If
        Try
            Process.Start(_selectedContract.FilePath)
        Catch ex As Exception
            ShowMessage("The contract file could not be opened. " & ex.Message)
        End Try
    End Sub

    Private Sub BtnRemoveContract_Click(sender As Object, e As EventArgs) Handles BtnRemoveContract.Click
        OpenDeleteContractEditor()
    End Sub

    Private Sub BtnChooseInitialContract_Click(sender As Object, e As EventArgs) Handles BtnChooseInitialContract.Click
        ChooseContractFile(LblInitialContractFile, BtnChooseInitialContract)
    End Sub

    Private Sub BtnChooseContract_Click(sender As Object, e As EventArgs) Handles BtnChooseContract.Click
        ChooseContractFile(LblContractFile, BtnChooseContract)
    End Sub

    Private Sub BtnSaveEditor_Click(sender As Object, e As EventArgs) Handles BtnSaveEditor.Click
        SaveEditor()
    End Sub

    Private Sub BtnCancelEditor_Click(sender As Object, e As EventArgs) Handles BtnCancelEditor.Click
        CloseEditor()
    End Sub

    Private Sub BtnEditorBack_Click(sender As Object, e As EventArgs) Handles BtnEditorBack.Click
        If _editorMode <> InlineEditorMode.CreateWorkSite AndAlso _editorMode <> InlineEditorMode.EditWorkSite Then Return
        If _workSiteWizardStep <= 0 Then Return
        _workSiteWizardStep -= 1
        UpdateWizardNavigation()
    End Sub

    Private Sub BtnEditorNext_Click(sender As Object, e As EventArgs) Handles BtnEditorNext.Click
        If _editorMode <> InlineEditorMode.CreateWorkSite AndAlso _editorMode <> InlineEditorMode.EditWorkSite Then Return
        If Not ValidateWizardStep(_workSiteWizardStep) Then Return
        _workSiteWizardStep += 1
        UpdateWizardNavigation()
    End Sub

    Private Sub BtnOpenWorkSite_Click(sender As Object, e As EventArgs) Handles BtnOpenWorkSite.Click
        OpenWorkSiteProfile()
    End Sub

    Private Sub LvWorkSites_DoubleClick(sender As Object, e As EventArgs) Handles LvWorkSites.DoubleClick
        OpenWorkSiteProfile()
    End Sub

    Private Sub BtnBackToDirectory_Click(sender As Object, e As EventArgs) Handles BtnBackToDirectory.Click
        SetNavigation(BtnNavCompanies)
        ShowDirectoryView()
    End Sub

    Private Sub BtnRefreshContractMonitoring_Click(sender As Object, e As EventArgs) Handles BtnRefreshContractMonitoring.Click
        LoadContractMonitoring()
    End Sub

    Private Sub CmbContractMonitoringFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbContractMonitoringFilter.SelectedIndexChanged
        If IsHandleCreated AndAlso WorkspaceViews.SelectedTab Is TabContractMonitoring Then LoadContractMonitoring()
    End Sub

    Private Sub LvContractMonitoring_DoubleClick(sender As Object, e As EventArgs) Handles LvContractMonitoring.DoubleClick
        If LvContractMonitoring.SelectedItems.Count = 0 Then Return
        Dim record As ContractMonitoringRecord = TryCast(LvContractMonitoring.SelectedItems(0).Tag, ContractMonitoringRecord)
        If record Is Nothing Then Return
        SelectCompanyById(record.CompanyId)
        If _selectedCompany Is Nothing Then Return
        LoadWorkSites(record.CompanyId, record.WorkSiteId)
        OpenWorkSiteProfile()
        DetailsTabs.SelectedTab = TabContracts
        LoadContracts(record.WorkSiteId, record.ContractId)
    End Sub

    Private Sub BtnRouteToWorkSite_Click(sender As Object, e As EventArgs) Handles BtnRouteToWorkSite.Click
        Dim requestedCompanyId As Integer = _suggestedCompanyId
        CloseEditor()
        If requestedCompanyId > 0 Then SelectCompanyById(requestedCompanyId)
        If _selectedCompany Is Nothing Then
            ShowGuidance("Choose the legal client first, then select Add subclient.")
            Return
        End If
        OpenWorkSiteEditor(True)
    End Sub

    Private Sub SelectCompanyById(companyId As Integer)
        For Each item As ListViewItem In LvCompanies.Items
            Dim company As CompanyRecord = TryCast(item.Tag, CompanyRecord)
            If company IsNot Nothing AndAlso company.Id = companyId Then
                item.Selected = True
                item.EnsureVisible()
                SelectCompany(company)
                Return
            End If
        Next
        CmbCompanyStatus.SelectedItem = "All"
        ReloadCompanies(companyId)
    End Sub

    Private Sub BtnNavCompanies_Click(sender As Object, e As EventArgs) Handles BtnNavCompanies.Click
        SetNavigation(BtnNavCompanies)
        ShowDirectoryView()
        TxtCompanySearch.Select()
    End Sub

    Private Sub BtnNavSites_Click(sender As Object, e As EventArgs) Handles BtnNavSites.Click
        SetNavigation(BtnNavSites)
        ShowSubclientDirectory()
    End Sub

    Private Sub BtnNavContracts_Click(sender As Object, e As EventArgs) Handles BtnNavContracts.Click
        SetNavigation(BtnNavContracts)
        CloseEditor()
        WorkspaceViews.SelectedTab = TabContractMonitoring
        LblHeaderSection.Text = "CONTRACTS"
        LoadContractMonitoring()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub TxtDailyWage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDailyWage.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub FRM_HR_CLIENTS_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ResizeColumns()
    End Sub

    Private Sub FRM_HR_CLIENTS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        SearchTimer.Stop()
        _assessmentTimer.Stop()
        GlobalVariables.Selected_Sub_Client_ID = String.Empty
        GlobalVariables.Selected_Sub_Client_Name = String.Empty
        GlobalVariables.Selected_Contract_ID = 0
        GlobalVariables.Selected_Contract_attachment = String.Empty
        GlobalVariables.sReason_for_Deactivation_Activation = String.Empty
    End Sub
End Class
