param(
    [string]$AssemblyPath = (Join-Path $PSScriptRoot '..\bin\Release\DMSA_System.exe'),
    [string]$PreviewPath
)

# Run with Windows PowerShell 5.1 -STA after building Release. Design-time
# fixtures exercise the real form without connecting to a payroll database.
$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Windows.Forms, System.Drawing, System.Design
$assembly = [Reflection.Assembly]::LoadFrom((Resolve-Path $AssemblyPath))
$flags = [Reflection.BindingFlags]'Instance,NonPublic,Public'
$formType = $assembly.GetType('DMSA_System.FRM_DTR_SHIFT_MANUAL', $true)
$globals = $assembly.GetType('DMSA_System.Mod_GlobalVariables+GlobalVariables', $true)
function Get-Field($Name) {
    $field = $formType.GetField($Name, $flags)
    if ($field) { return $field.GetValue($form) }
    return $formType.GetProperty($Name, $flags).GetValue($form, $null)
}
function Set-Field($Name, $Value) { $formType.GetField($Name, $flags).SetValue($form, $Value) }
function Invoke-Private($Name, [object[]]$Arguments = @()) {
    $result = $formType.GetMethod($Name, $flags).Invoke($form, $Arguments)
    Write-Output -NoEnumerate $result
}
$script:assertions = 0
function Assert-Equal($Expected, $Actual, $Description) {
    if ($Expected -ne $Actual) { throw "$Description - expected '$Expected', got '$Actual'." }
    $script:assertions++
}
function Set-Period($Year, $Month, $Cutoff) {
    Set-Field 'isChangingPeriod' $true
    (Get-Field 'cmbYear').SelectedItem = [string]$Year
    (Get-Field 'cmbMonth').SelectedIndex = $Month - 1
    (Get-Field 'cmbCutoff').SelectedIndex = $Cutoff
    Set-Field 'isChangingPeriod' $false
    $null = Invoke-Private 'BuildPeriodDates'
}
function New-Record($Status) {
    $record = $assembly.CreateInstance('DMSA_System.ManualPayrollRecord')
    $record.RecordStatus = $Status
    return $record
}

$oldContext = [ComponentModel.LicenseManager]::CurrentContext
$form = $null
try {
    [ComponentModel.LicenseManager]::CurrentContext = New-Object ComponentModel.Design.DesigntimeLicenseContext
    foreach ($entry in @{
        DTR_Selected_Employee_ID = 'TEST-EMPLOYEE'
        DTR_Selected_Employee_Name = 'Test Employee'
        DTR_Selected_SubClient_ID = '1'
        DTR_Selected_SubClient_Name = 'Test Client'
        GlobalConStr = 'INVALID: tests must never connect to a database'
    }.GetEnumerator()) { $globals.GetField($entry.Key).SetValue($null, $entry.Value) }
    $form = [Activator]::CreateInstance($formType)

    foreach ($case in @(
        @(2026, 1, 0, '12_1st_2025'),
        @(2026, 1, 1, '12_2nd_2025'),
        @(2024, 3, 0, '2_1st_2024'),
        @(2026, 11, 1, '10_2nd_2026')
    )) {
        Set-Period $case[0] $case[1] $case[2]
        Assert-Equal $case[3] (Invoke-Private 'BuildBenefitSourceCutoff') 'Previous month keeps cutoff'
    }

    Set-Period 2026 11 0
    Assert-Equal $true (Get-Field 'btnPreviousMonthBenefits').Enabled 'Open first cutoff enables copy'

    $benefits = $assembly.CreateInstance('DMSA_System.ManualPayrollClientAdjustment')
    $benefits.SubClientId = 1
    $benefits.SssDeduction = 500.25
    $benefits.SssProvidentDeduction = 100.50
    $benefits.PhilHealthDeduction = 300.75
    $benefits.PagIbigDeduction = 200
    # Non-contribution source amounts must never be copied.
    $benefits.OfficerAllowance = 9999
    $benefits.SssLoanDeduction = 9999
    $unrelated = @('txtOfficerAllowance', 'txtUniformAllowance', 'txtOtherEarnings',
        'txtCashBondDeduction', 'txtSssLoanDeduction', 'txtSssCalLoanDeduction',
        'txtPagIbigLoanDeduction', 'txtPagIbigCalLoanDeduction', 'txtOtherDeductions')
    Set-Field 'isLoadingPayrollInputs' $true
    foreach ($name in $unrelated) { (Get-Field $name).Text = '123.45' }
    Set-Field 'isLoadingPayrollInputs' $false
    $otherClient = [Activator]::CreateInstance($formType.GetNestedType('PayrollAdjustments', [Reflection.BindingFlags]::NonPublic))
    $otherClient.SssDeduction = 987.65
    (Get-Field 'workspaceAdjustments')[2] = $otherClient
    $workDate = [datetime]'2026-11-02'
    $null = Invoke-Private 'SetAssignmentClientId' @(0, $workDate, 1)
    $null = Invoke-Private 'ApplyCopiedBenefits' @($benefits)
    Assert-Equal '500.25' (Get-Field 'txtSssDeduction').Text 'SSS copied'
    Assert-Equal '100.5' (Get-Field 'txtSssProvidentDeduction').Text 'Provident copied'
    Assert-Equal '300.75' (Get-Field 'txtPhilHealthDeduction').Text 'PhilHealth copied'
    Assert-Equal '200' (Get-Field 'txtPagIbigDeduction').Text 'Pag-IBIG copied'
    foreach ($name in $unrelated) { Assert-Equal '123.45' (Get-Field $name).Text "$name preserved" }
    Assert-Equal 987.65 (Get-Field 'workspaceAdjustments')[2].SssDeduction 'Other client preserved'
    Assert-Equal 1 (Invoke-Private 'AssignmentClientId' @(0, $workDate)) 'Rendered shift assignment preserved'
    Assert-Equal $true (Get-Field 'hasUnsavedChanges') 'Copy is an unsaved edit'
    $null = Invoke-Private 'ApplyCopiedBenefits' @($benefits)
    Assert-Equal '500.25' (Get-Field 'txtSssDeduction').Text 'Repeated copy replaces instead of adding'

    $savedAdjustments = Invoke-Private 'BuildClientAdjustmentRecords'
    $savedHome = @($savedAdjustments | Where-Object SubClientId -eq 1)[0]
    Assert-Equal 500.25 $savedHome.SssDeduction 'Draft serialization includes copied contribution'
    Assert-Equal 123.45 $savedHome.OfficerAllowance 'Draft serialization preserves allowance'
    $roundTrip = New-Record 'DRAFT'
    $roundTrip.ClientAdjustments.Add($savedHome)
    $null = Invoke-Private 'LoadPayrollInputs' @($roundTrip)
    Assert-Equal '300.75' (Get-Field 'txtPhilHealthDeduction').Text 'Reload retains copied contribution'

    foreach ($status in @('FINAL', 'LEGACY_FINAL')) {
        Set-Field 'currentRecord' (New-Record $status)
        $null = Invoke-Private 'SetRecordEditability' @($false)
        Assert-Equal $false (Get-Field 'btnPreviousMonthBenefits').Enabled "$status disables month button"
        $benefits.SssDeduction = 999
        $null = Invoke-Private 'ApplyCopiedBenefits' @($benefits)
        Assert-Equal '500.25' (Get-Field 'txtSssDeduction').Text "$status blocks contribution changes"
    }
    foreach ($status in @('DRAFT', 'AMENDMENT_DRAFT')) {
        Set-Field 'currentRecord' (New-Record $status)
        $null = Invoke-Private 'SetRecordEditability' @($true)
        Assert-Equal $true (Get-Field 'btnPreviousMonthBenefits').Enabled "$status permits copy"
    }
    $benefits.SubClientId = 2
    $null = Invoke-Private 'ApplyCopiedBenefits' @($benefits)
    Assert-Equal '500.25' (Get-Field 'txtSssDeduction').Text 'Wrong client source rejected'
    $null = Invoke-Private 'ApplyCopiedBenefits' @($null)
    Assert-Equal '500.25' (Get-Field 'txtSssDeduction').Text 'Missing benefits leave values intact'

    Set-Period 2026 11 1
    Assert-Equal $false (Get-Field 'btnPreviousMonthBenefits').Enabled 'Second cutoff disables month button'
    $benefits.SubClientId = 1
    $null = Invoke-Private 'ApplyCopiedBenefits' @($benefits)
    Assert-Equal '0' (Get-Field 'txtSssDeduction').Text 'Second cutoff cannot acquire hidden contributions'

    Set-Period 2026 11 0
    (Get-Field 'txtSssDeduction').Text = '321'
    $benefits.SssDeduction = 0
    $null = Invoke-Private 'ApplyCopiedBenefits' @($benefits)
    Assert-Equal '0' (Get-Field 'txtSssDeduction').Text 'Zero source amounts replace current contribution'
    $null = Invoke-Private 'SetRecordEditability' @($false)
    Assert-Equal $false (Get-Field 'btnPreviousMonthBenefits').Enabled 'Load error/read-only disables copy'

    if ($PreviewPath) {
        $null = Invoke-Private 'SetRecordEditability' @($true)
        (Get-Field 'lblEmployee').Text = 'TEST-EMPLOYEE - Test Employee'
        $form.WindowState = 'Normal'
        $form.ShowInTaskbar = $false
        $form.StartPosition = 'Manual'
        $form.Location = New-Object Drawing.Point(-30000, -30000)
        $form.Size = New-Object Drawing.Size(1400, 900)
        $form.Show()
        $form.PerformLayout()
        $bitmap = New-Object Drawing.Bitmap($form.Width, $form.Height)
        try {
            $form.DrawToBitmap($bitmap, (New-Object Drawing.Rectangle(0, 0, $form.Width, $form.Height)))
            $bitmap.Save($PreviewPath, [Drawing.Imaging.ImageFormat]::Png)
        } finally { $bitmap.Dispose() }
    }
    Write-Output "PASS: $script:assertions assertions; no database connection or payroll writes."
} finally {
    if ($form) { $form.Dispose() }
    [ComponentModel.LicenseManager]::CurrentContext = $oldContext
}
