Imports System.ComponentModel

Public Class FRM_PAYROLL_REPORT_SETTINGS
    Public Sub New()
        InitializeComponent()

        If LicenseManager.UsageMode = LicenseUsageMode.Designtime OrElse DesignMode Then
            Return
        End If

        Dim userLevel = If(GlobalVariables.sUser_Level, String.Empty).Trim()
        If Not String.Equals(userLevel, "Administrator", StringComparison.OrdinalIgnoreCase) Then
            Throw New UnauthorizedAccessException("Only administrators can change payroll report settings.")
        End If

        settingsPathLabel.Text = "Saved to: " & PayrollReportSettingsService.SettingsPath
        DisplaySettings(PayrollReportSettingsService.LoadSettingsOrDefault())
    End Sub

    Private Sub DisplaySettings(settings As PayrollReportSettings)
        txtCompanyName.Text = settings.CompanyName
        txtCompanyAddress.Text = settings.CompanyAddress
        txtCompanyPhone.Text = settings.CompanyPhone
        txtCompanyEmail.Text = settings.CompanyEmail
        txtPayrollPreparedName.Text = settings.PayrollPreparedName
        txtPayrollPreparedTitle.Text = settings.PayrollPreparedTitle
        txtPayrollApprovedName.Text = settings.PayrollApprovedName
        txtPayrollApprovedTitle.Text = settings.PayrollApprovedTitle
        txtDtrPreparedName.Text = settings.DtrPreparedName
        txtDtrPreparedTitle.Text = settings.DtrPreparedTitle
        txtDtrCheckedName.Text = settings.DtrCheckedName
        txtDtrCheckedTitle.Text = settings.DtrCheckedTitle
        txtDtrNotedName.Text = settings.DtrNotedName
        txtDtrNotedTitle.Text = settings.DtrNotedTitle
        numHoursPerDay.Value = ClampValue(numHoursPerDay, settings.HoursPerDay)
        numSundayMultiplier.Value = ClampValue(numSundayMultiplier, settings.SundayPremium)
        numSpecialHolidayMultiplier.Value = ClampValue(numSpecialHolidayMultiplier, settings.SpecialHolidayPremium)
        numLegalHolidayMultiplier.Value = ClampValue(numLegalHolidayMultiplier, settings.LegalHolidayPremium)
        numOvertimeHourlyRate.Value = ClampValue(numOvertimeHourlyRate, settings.OvertimeHourlyRate)
        numServiceIncentiveDays.Value = ClampValue(numServiceIncentiveDays, settings.ServiceIncentiveDays)
        numIncentiveMonthsDivisor.Value = ClampValue(numIncentiveMonthsDivisor, settings.IncentiveMonthsDivisor)
        numIncentiveDaysDivisor.Value = ClampValue(numIncentiveDaysDivisor, settings.IncentiveDaysDivisor)
    End Sub

    Private Shared Function ClampValue(input As NumericUpDown, value As Decimal) As Decimal
        Return Math.Min(input.Maximum, Math.Max(input.Minimum, value))
    End Function

    Private Sub btnRestoreDefaults_Click(sender As Object, e As EventArgs) Handles btnRestoreDefaults.Click
        DisplaySettings(PayrollReportSettings.CreateDefault())
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim settings As New PayrollReportSettings With {
            .CompanyName = txtCompanyName.Text.Trim(),
            .CompanyAddress = txtCompanyAddress.Text.Trim(),
            .CompanyPhone = txtCompanyPhone.Text.Trim(),
            .CompanyEmail = txtCompanyEmail.Text.Trim(),
            .PayrollPreparedName = txtPayrollPreparedName.Text.Trim(),
            .PayrollPreparedTitle = txtPayrollPreparedTitle.Text.Trim(),
            .PayrollApprovedName = txtPayrollApprovedName.Text.Trim(),
            .PayrollApprovedTitle = txtPayrollApprovedTitle.Text.Trim(),
            .DtrPreparedName = txtDtrPreparedName.Text.Trim(),
            .DtrPreparedTitle = txtDtrPreparedTitle.Text.Trim(),
            .DtrCheckedName = txtDtrCheckedName.Text.Trim(),
            .DtrCheckedTitle = txtDtrCheckedTitle.Text.Trim(),
            .DtrNotedName = txtDtrNotedName.Text.Trim(),
            .DtrNotedTitle = txtDtrNotedTitle.Text.Trim(),
            .HoursPerDay = numHoursPerDay.Value,
            .RateSemantics = PayrollReportSettingsService.PremiumRateSemantics,
            .SundayPremium = numSundayMultiplier.Value,
            .SpecialHolidayPremium = numSpecialHolidayMultiplier.Value,
            .LegalHolidayPremium = numLegalHolidayMultiplier.Value,
            .OvertimeHourlyRate = numOvertimeHourlyRate.Value,
            .ServiceIncentiveDays = numServiceIncentiveDays.Value,
            .IncentiveMonthsDivisor = numIncentiveMonthsDivisor.Value,
            .IncentiveDaysDivisor = numIncentiveDaysDivisor.Value
        }

        Try
            PayrollReportSettingsService.SaveSettings(settings)
            Try
                Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Updated payroll and report settings")
            Catch
            End Try

            AppNotification.Show(
                "Payroll and report settings saved.",
                "Settings",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
            DialogResult = DialogResult.OK
        Catch ex As Exception
            AppNotification.Show(
                ex.Message,
                "Unable to Save Settings",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
        End Try
    End Sub
End Class
