Imports System.ComponentModel
Imports System.Globalization
Imports System.IO

Public Class FRM_SUB_CLIENT_PAYROLL_SETTINGS
    Inherits Form

    Private ReadOnly _initialSubClientId As Integer
    Private ReadOnly _clientService As New ClientManagementService()
    Private _loading As Boolean
    Private _currentPolicy As SubClientPayrollPolicy

    Public Sub New()
        Me.New(0)
    End Sub

    Public Sub New(initialSubClientId As Integer)
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            Dim userLevel = If(GlobalVariables.sUser_Level, String.Empty).Trim()
            If Not String.Equals(userLevel, "Administrator", StringComparison.OrdinalIgnoreCase) Then
                Throw New UnauthorizedAccessException("Only administrators can change sub-client payroll rules.")
            End If
        End If

        _initialSubClientId = initialSubClientId
        InitializeComponent()
    End Sub

    Private Sub FormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SubClientPayrollPolicyService.EnsureSchema()
            LoadCompaniesAndSelection()
        Catch ex As Exception
            SetStatus(ex.Message, True)
            btnSave.Enabled = False
            btnImport.Enabled = False
        End Try
    End Sub

    Private Sub LoadCompaniesAndSelection()
        _loading = True
        Try
            Dim companies = _clientService.GetCompanies(String.Empty, "All")
            cmbCompany.DataSource = companies

            If _initialSubClientId > 0 Then
                Dim initialSite = _clientService.GetWorkSite(_initialSubClientId)
                If initialSite IsNot Nothing Then cmbCompany.SelectedValue = initialSite.CompanyId
            End If
        Finally
            _loading = False
        End Try

        LoadWorkSites()
        If _initialSubClientId > 0 Then cmbWorkSite.SelectedValue = _initialSubClientId
        LoadSelectedPolicy()
    End Sub

    Private Sub CompanyChanged(sender As Object, e As EventArgs) Handles cmbCompany.SelectedIndexChanged
        If _loading Then Return
        LoadWorkSites()
        LoadSelectedPolicy()
    End Sub

    Private Sub LoadWorkSites()
        Dim company = TryCast(cmbCompany.SelectedItem, CompanyRecord)
        _loading = True
        Try
            cmbWorkSite.DataSource = If(company Is Nothing, New List(Of WorkSiteRecord)(), _clientService.GetWorkSites(company.Id))
        Finally
            _loading = False
        End Try
    End Sub

    Private Sub WorkSiteChanged(sender As Object, e As EventArgs) Handles cmbWorkSite.SelectedIndexChanged
        If _loading Then Return
        LoadSelectedPolicy()
    End Sub

    Private Sub LoadSelectedPolicy()
        Dim site = TryCast(cmbWorkSite.SelectedItem, WorkSiteRecord)
        If site Is Nothing Then
            _currentPolicy = Nothing
            rulesGrid.Rows.Clear()
            lblClientContext.Text = "No sub-client selected"
            lblPolicySummary.Text = String.Empty
            btnSave.Enabled = False
            Return
        End If

        Try
            _currentPolicy = SubClientPayrollPolicyService.LoadPolicy(site.Id)
            DisplayPolicy(_currentPolicy)
            lblClientContext.Text = String.Format(
                CultureInfo.CurrentCulture,
                "Wage: {0:N2}   ·   Schedule: {1}   ·   Status: {2}",
                site.DailyWage,
                If(String.IsNullOrWhiteSpace(site.ScheduleType), "-", site.ScheduleType),
                If(String.IsNullOrWhiteSpace(site.Status), "-", site.Status))
            lblPolicySummary.Text = SubClientPayrollPolicyService.DescribePolicy(_currentPolicy)
            btnSave.Enabled = True
            SetStatus("Loaded rules for " & site.Name & ".", False)
        Catch ex As Exception
            btnSave.Enabled = False
            SetStatus(ex.Message, True)
        End Try
    End Sub

    Private Sub DisplayPolicy(policy As SubClientPayrollPolicy)
        _loading = True
        Try
            numHoursPerDay.Value = Clamp(numHoursPerDay, policy.HoursPerDay)
            cmbDutyEntryMode.SelectedIndex = If(
                policy.DutyEntryMode = SubClientPayrollPolicy.DutyEntrySingleShift, 1, 0)
            numSingleShiftHours.Value = Clamp(numSingleShiftHours, policy.SingleShiftHours)
            chkSingleShiftIsNight.Checked = policy.SingleShiftIsNight
            Select Case policy.NightDifferentialMode
                Case SubClientPayrollPolicy.NightDifferentialFixedCutoffPool
                    cmbNightDifferentialMode.SelectedIndex = 1
                Case SubClientPayrollPolicy.NightDifferentialDisabled
                    cmbNightDifferentialMode.SelectedIndex = 2
                Case Else
                    cmbNightDifferentialMode.SelectedIndex = 0
            End Select
            numNightDifferentialFixedAmount.Value = Clamp(numNightDifferentialFixedAmount, policy.NightDifferentialFixedCutoffAmount)
            chkIncentive.Checked = policy.IncentiveEnabled
            numIncentiveDays.Value = Clamp(numIncentiveDays, policy.IncentiveDays)
            numIncentiveMonthDivisor.Value = Clamp(numIncentiveMonthDivisor, policy.IncentiveMonthDivisor)
            numIncentiveCutoffDivisor.Value = Clamp(numIncentiveCutoffDivisor, policy.IncentiveCutoffDivisor)
            txtNotes.Text = policy.Notes

            rulesGrid.Rows.Clear()
            For Each code In SubClientPayrollPolicyService.PolicyRuleOrder
                Dim rule = policy.GetRule(code)
                Dim rowIndex = rulesGrid.Rows.Add(
                    rule.DisplayName,
                    rule.Enabled,
                    rule.Multiplier.ToString("0.####", CultureInfo.InvariantCulture),
                    FormulaDescription(code))
                rulesGrid.Rows(rowIndex).Tag = code
            Next
        Finally
            _loading = False
        End Try
        ApplyDutyEntryModeState()
        ApplyNightDifferentialModeState()
    End Sub

    Private Sub SaveClicked(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim site = TryCast(cmbWorkSite.SelectedItem, WorkSiteRecord)
        If site Is Nothing OrElse _currentPolicy Is Nothing Then Return

        Try
            Dim policy = ReadPolicyFromScreen(site.Id)
            SubClientPayrollPolicyService.SavePolicy(policy, CurrentActor())
            _currentPolicy = policy
            lblPolicySummary.Text = SubClientPayrollPolicyService.DescribePolicy(policy)
            SetStatus("Payroll rules saved. New manual DTR entries and exports will use this policy.", False)
            Try
                Record_activity_log(
                    GlobalVariables.sEmployee_ID_Logged_in,
                    "Updated payroll rules for sub-client " & site.Id.ToString(CultureInfo.InvariantCulture))
            Catch
            End Try
        Catch ex As Exception
            SetStatus(ex.Message, True)
            AppNotification.Show(ex.Message, "Unable to Save Payroll Rules", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Function ReadPolicyFromScreen(subClientId As Integer) As SubClientPayrollPolicy
        Dim policy = SubClientPayrollPolicy.CreateDefault(subClientId)
        policy.HoursPerDay = numHoursPerDay.Value
        policy.DutyEntryMode = SelectedDutyEntryMode()
        policy.SingleShiftHours = numSingleShiftHours.Value
        policy.SingleShiftIsNight = chkSingleShiftIsNight.Checked
        policy.NightDifferentialMode = SelectedNightDifferentialMode()
        policy.NightDifferentialFixedCutoffAmount = numNightDifferentialFixedAmount.Value
        policy.IncentiveEnabled = chkIncentive.Checked
        policy.IncentiveDays = numIncentiveDays.Value
        policy.IncentiveMonthDivisor = numIncentiveMonthDivisor.Value
        policy.IncentiveCutoffDivisor = numIncentiveCutoffDivisor.Value
        policy.Notes = txtNotes.Text.Trim()

        For Each row As DataGridViewRow In rulesGrid.Rows
            Dim code = Convert.ToString(row.Tag)
            If String.IsNullOrWhiteSpace(code) Then Continue For
            Dim premium As Decimal
            If Not Decimal.TryParse(
                    Convert.ToString(row.Cells("colMultiplier").Value),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    premium) AndAlso
               Not Decimal.TryParse(Convert.ToString(row.Cells("colMultiplier").Value), premium) Then
                Throw New InvalidDataException(
                    "Enter a valid additional premium for " & Convert.ToString(row.Cells("colRuleName").Value) & ".")
            End If
            Dim enabled = Convert.ToBoolean(If(row.Cells("colEnabled").Value, False))
            Dim rule = policy.GetRule(code)
            rule.Enabled = enabled
            rule.Multiplier = premium
        Next

        If policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialDisabled Then
            For Each code In {"ND_REG", "ND_SUN", "ND_LH", "ND_SH"}
                policy.GetRule(code).Enabled = False
            Next
        ElseIf policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialFixedCutoffPool Then
            policy.GetRule("ND_REG").Enabled = True
            For Each code In {"ND_SUN", "ND_LH", "ND_SH"}
                policy.GetRule(code).Enabled = False
            Next
        End If

        policy.Validate()
        Return policy
    End Function

    Private Sub RestoreClicked(sender As Object, e As EventArgs) Handles btnRestore.Click
        Dim site = TryCast(cmbWorkSite.SelectedItem, WorkSiteRecord)
        If site Is Nothing Then Return
        DisplayPolicy(SubClientPayrollPolicy.CreateDefault(site.Id))
        SetStatus("Standard universal rules are shown. Click Save rules to apply them.", False)
    End Sub

    Private Sub ImportClicked(sender As Object, e As EventArgs) Handles btnImport.Click
        openPayrollRulesDialog.FileName = String.Empty
        If openPayrollRulesDialog.ShowDialog(Me) <> DialogResult.OK Then Return

        If AppNotification.Show(
                "Import matching Sheet3 rules by sub-client name? Existing saved rules for matching sub-clients will be replaced. The 9-hour and 10-hour rows will be configured as one shift. Daily wages will only be reported as differences and will not be changed.",
                "Import Payroll Rules",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            Cursor = Cursors.WaitCursor
            btnImport.Enabled = False
            Dim result = SubClientPayrollPolicyService.ImportRulesFromWorkbook(openPayrollRulesDialog.FileName, CurrentActor())
            LoadSelectedPolicy()
            AppNotification.Show(
                result.BuildSummary(),
                "Payroll Rule Import",
                MessageBoxButtons.OK,
                If(result.Errors.Count = 0 AndAlso result.ShiftWarnings.Count = 0,
                   MessageBoxIcon.Information,
                   MessageBoxIcon.Warning))
            SetStatus(
                "Excel rule import completed.",
                result.Errors.Count > 0 OrElse result.ShiftWarnings.Count > 0)
        Catch ex As Exception
            SetStatus(ex.Message, True)
            AppNotification.Show(ex.Message, "Unable to Import Rules", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            Cursor = Cursors.Default
            btnImport.Enabled = True
        End Try
    End Sub

    Private Sub NightDifferentialModeChanged(sender As Object, e As EventArgs) Handles cmbNightDifferentialMode.SelectedIndexChanged
        If _loading Then Return
        ApplyNightDifferentialModeState()
    End Sub

    Private Sub NightDifferentialAmountChanged(sender As Object, e As EventArgs) Handles numNightDifferentialFixedAmount.ValueChanged
        If _loading Then Return
        UpdateNightDifferentialGuidance()
    End Sub

    Private Sub DutyEntryModeChanged(sender As Object, e As EventArgs) Handles cmbDutyEntryMode.SelectedIndexChanged
        If _loading Then Return
        ApplyDutyEntryModeState()
    End Sub

    Private Sub CloseClicked(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub ApplyDutyEntryModeState()
        Dim configuredSingleShift = SelectedDutyEntryMode() = SubClientPayrollPolicy.DutyEntrySingleShift
        numSingleShiftHours.Enabled = configuredSingleShift
        chkSingleShiftIsNight.Enabled = configuredSingleShift
    End Sub

    Private Sub ApplyNightDifferentialModeState()
        Dim mode = SelectedNightDifferentialMode()
        Dim paysByDays = mode = SubClientPayrollPolicy.NightDifferentialFixedCutoffPool
        numNightDifferentialFixedAmount.Enabled = paysByDays
        lblFixedNightDifferentialCaption.Enabled = paysByDays

        For Each row As DataGridViewRow In rulesGrid.Rows
            Dim code = Convert.ToString(row.Tag)
            If Not code.StartsWith("ND_", StringComparison.OrdinalIgnoreCase) Then Continue For
            Dim editable = mode = SubClientPayrollPolicy.NightDifferentialHourly
            row.Cells("colEnabled").ReadOnly = Not editable
            row.Cells("colMultiplier").ReadOnly = Not editable
            row.DefaultCellStyle.ForeColor = If(editable, Color.Black, Color.DimGray)
            If mode = SubClientPayrollPolicy.NightDifferentialDisabled Then
                row.Cells("colEnabled").Value = False
            ElseIf mode = SubClientPayrollPolicy.NightDifferentialFixedCutoffPool Then
                row.Cells("colEnabled").Value = code.Equals("ND_REG", StringComparison.OrdinalIgnoreCase)
            End If
            row.Cells("colFormula").Value = FormulaDescription(code)
        Next
        UpdateNightDifferentialGuidance()
    End Sub

    Private Sub UpdateNightDifferentialGuidance()
        Select Case SelectedNightDifferentialMode()
            Case SubClientPayrollPolicy.NightDifferentialFixedCutoffPool
                Dim amount = numNightDifferentialFixedAmount.Value
                Dim fifteenDayRate = amount / 2D / 15D
                Dim sixteenDayRate = amount / 2D / 16D
                lblNightDifferentialModeHelp.Text =
                    "Uses the DTR's night-differential days. Day shifts do not increase fixed ND pay."
                lblFixedNightDifferentialHelp.Text = String.Format(
                    CultureInfo.CurrentCulture,
                    "{0:N2} / 2 / cutoff days x ND days. Preview: 15 days = {1:N2}/ND day; 16 days = {2:N2}/ND day.",
                    amount,
                    fifteenDayRate,
                    sixteenDayRate)
            Case SubClientPayrollPolicy.NightDifferentialDisabled
                lblNightDifferentialModeHelp.Text = "No night-differential pay will be calculated."
                lblFixedNightDifferentialHelp.Text = "Select 'Pay by ND days from a monthly amount' to use this field."
            Case Else
                lblNightDifferentialModeHelp.Text =
                    "Uses recorded ND hours and the additional ND premiums in the Premium matrix."
                lblFixedNightDifferentialHelp.Text = "Select 'Pay by ND days from a monthly amount' to use this field."
        End Select
    End Sub

    Private Function SelectedNightDifferentialMode() As String
        Select Case cmbNightDifferentialMode.SelectedIndex
            Case 1
                Return SubClientPayrollPolicy.NightDifferentialFixedCutoffPool
            Case 2
                Return SubClientPayrollPolicy.NightDifferentialDisabled
            Case Else
                Return SubClientPayrollPolicy.NightDifferentialHourly
        End Select
    End Function

    Private Function SelectedDutyEntryMode() As String
        If cmbDutyEntryMode.SelectedIndex = 1 Then Return SubClientPayrollPolicy.DutyEntrySingleShift
        Return SubClientPayrollPolicy.DutyEntryClientSchedule
    End Function

    Private Function FormulaDescription(code As String) As String
        If code.StartsWith("ND_", StringComparison.OrdinalIgnoreCase) Then
            Select Case SelectedNightDifferentialMode()
                Case SubClientPayrollPolicy.NightDifferentialFixedCutoffPool
                    If code.Equals("ND_REG", StringComparison.OrdinalIgnoreCase) Then
                        Return "Monthly ND amount / 2 / cutoff days x ND days"
                    End If
                    Return "Not paid in fixed ND-days mode"
                Case SubClientPayrollPolicy.NightDifferentialDisabled
                    Return "Not paid"
                Case Else
                    Return "Effective day hourly rate x premium x ND hours"
            End Select
        End If
        If code.StartsWith("OT_", StringComparison.OrdinalIgnoreCase) Then
            Return "Effective day hourly rate x (1 + premium) x OT hours"
        End If
        Return "Base hourly rate x (1 + premium) x hours"
    End Function

    Private Function CurrentActor() As String
        Dim employeeId = If(GlobalVariables.sEmployee_ID_Logged_in, String.Empty).Trim()
        If employeeId <> String.Empty Then Return employeeId
        Return If(GlobalVariables.sUser_Level, "Administrator").Trim()
    End Function

    Private Sub SetStatus(message As String, isError As Boolean)
        lblStatus.Text = message
        lblStatus.ForeColor = If(isError, Color.Maroon, Color.Teal)
    End Sub

    Private Function Clamp(control As NumericUpDown, value As Decimal) As Decimal
        Return Math.Min(control.Maximum, Math.Max(control.Minimum, value))
    End Function
End Class
