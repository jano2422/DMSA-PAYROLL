Imports System.Data.OleDb
Imports System.Globalization

Public Partial Class FRM_DTR_DEDUCTION_UPDATE
    Inherits Form

    Private ReadOnly _employeeId As String
    Private ReadOnly _employeeName As String
    Private ReadOnly _cutoff As String
    Private ReadOnly _subClientId As Integer
    Private ReadOnly _numDays As Decimal
    Private ReadOnly _totalHours As Decimal
    Private _regHours As Decimal
    Private _sunHours As Decimal
    Private _shHours As Decimal
    Private _lhHours As Decimal
    Private ReadOnly _otRegHours As Decimal
    Private ReadOnly _defaultCbDeduct As Decimal
    Private ReadOnly _defaultSssLoanDeduct As Decimal
    Private ReadOnly _defaultSssCalLoanDeduct As Decimal
    Private ReadOnly _defaultPiLoanDeduct As Decimal
    Private ReadOnly _defaultPiCalLoanDeduct As Decimal
    Private ReadOnly _defaultPhilhealthDeduct As Decimal
    Private ReadOnly _defaultSssDeduct As Decimal
    Private ReadOnly _defaultPagibigDeduct As Decimal
    Private ReadOnly _defaultOfficerAllowance As Decimal
    Private ReadOnly _defaultSgUniformAllowance As Decimal

    Private _isFirstCutoff As Boolean
    Private _unallocatedHours As Decimal
    Private ReadOnly _initialRegHours As Decimal
    Private ReadOnly _initialSunHours As Decimal
    Private ReadOnly _initialShHours As Decimal
    Private ReadOnly _initialLhHours As Decimal
    Private _dailyWage As Decimal
    Private _subClientName As String

    Public Sub New()
        _employeeId = "230096"
        _employeeName = "CATAPAT, MARIBEL A."
        _cutoff = "7_1st_2026"
        _subClientId = 0
        _numDays = 9D
        _totalHours = 72D
        _regHours = 56D
        _sunHours = 16D
        _shHours = 0D
        _lhHours = 0D
        _initialRegHours = _regHours
        _initialSunHours = _sunHours
        _initialShHours = _shHours
        _initialLhHours = _lhHours
        _otRegHours = 0D
        _dailyWage = 610D
        _subClientName = "Sample Detachment"
        _isFirstCutoff = True

        InitializeComponent()
        SetupRuntimeHandlers()
        LoadDialogData(useDatabaseWage:=False)
    End Sub

    Public Sub New(
        employeeId As String,
        employeeName As String,
        cutoff As String,
        subClientId As Integer,
        numDays As Decimal,
        totalHours As Decimal,
        regHours As Decimal,
        sunHours As Decimal,
        shHours As Decimal,
        lhHours As Decimal,
        otRegHours As Decimal,
        cbDeduct As Decimal,
        sssLoanDeduct As Decimal,
        sssCalLoanDeduct As Decimal,
        piLoanDeduct As Decimal,
        piCalLoanDeduct As Decimal,
        philhealthDeduct As Decimal,
        sssDeduct As Decimal,
        pagibigDeduct As Decimal,
        officerAllowance As Decimal,
        sguniformallowance As Decimal
    )
        _employeeId = employeeId
        _employeeName = employeeName
        _cutoff = cutoff
        _subClientId = subClientId
        _numDays = numDays
        _totalHours = totalHours
        _regHours = regHours
        _sunHours = sunHours
        _shHours = shHours
        _lhHours = lhHours
        _initialRegHours = regHours
        _initialSunHours = sunHours
        _initialShHours = shHours
        _initialLhHours = lhHours
        _otRegHours = otRegHours
        _defaultCbDeduct = cbDeduct
        _defaultSssLoanDeduct = sssLoanDeduct
        _defaultSssCalLoanDeduct = sssCalLoanDeduct
        _defaultPiLoanDeduct = piLoanDeduct
        _defaultPiCalLoanDeduct = piCalLoanDeduct
        _defaultPhilhealthDeduct = philhealthDeduct
        _defaultSssDeduct = sssDeduct
        _defaultPagibigDeduct = pagibigDeduct
        _defaultOfficerAllowance = officerAllowance
        _defaultSgUniformAllowance = sguniformallowance
        _unallocatedHours = 0D
        _isFirstCutoff = IsFirstCutoff(cutoff)

        InitializeComponent()
        SetupRuntimeHandlers()
        LoadDialogData(useDatabaseWage:=True)
    End Sub

    Private Sub SetupRuntimeHandlers()
        AddHandler btnRegMinus.Click, Sub() AdjustAllocation("REG", -1D)
        AddHandler btnRegPlus.Click, Sub() AdjustAllocation("REG", 1D)
        AddHandler btnRegUnallocate.Click, Sub() HandleUnallocateAllForType("REG")
        AddHandler btnRegAllocate.Click, Sub() HandleAllocateAllUnallocatedForType("REG")

        AddHandler btnSunMinus.Click, Sub() AdjustAllocation("SUN", -1D)
        AddHandler btnSunPlus.Click, Sub() AdjustAllocation("SUN", 1D)
        AddHandler btnSunUnallocate.Click, Sub() HandleUnallocateAllForType("SUN")
        AddHandler btnSunAllocate.Click, Sub() HandleAllocateAllUnallocatedForType("SUN")

        AddHandler btnShMinus.Click, Sub() AdjustAllocation("SH", -1D)
        AddHandler btnShPlus.Click, Sub() AdjustAllocation("SH", 1D)
        AddHandler btnShUnallocate.Click, Sub() HandleUnallocateAllForType("SH")
        AddHandler btnShAllocate.Click, Sub() HandleAllocateAllUnallocatedForType("SH")

        AddHandler btnLhMinus.Click, Sub() AdjustAllocation("LH", -1D)
        AddHandler btnLhPlus.Click, Sub() AdjustAllocation("LH", 1D)
        AddHandler btnLhUnallocate.Click, Sub() HandleUnallocateAllForType("LH")
        AddHandler btnLhAllocate.Click, Sub() HandleAllocateAllUnallocatedForType("LH")

        AddHandler btnResetAll.Click, AddressOf HandleResetToOriginal
        AddHandler btnSave.Click, AddressOf HandleSave
        AddHandler btnCancel.Click, AddressOf HandleCancel
    End Sub

    Private Sub LoadDialogData(useDatabaseWage As Boolean)
        Text = "Update Deductions - " & _employeeName

        If useDatabaseWage Then
            LoadSubClientDetails()
        End If

        lblEmployeeValue.Text = _employeeId & " - " & _employeeName
        lblCutoffValue.Text = FormatCutoff(_cutoff)
        lblSubClientValue.Text = If(String.IsNullOrWhiteSpace(_subClientName), "Sub Client ID: " & _subClientId.ToString(), _subClientName)
        lblDailyWageValue.Text = FormatPeso(_dailyWage)

        txtSss.Text = _defaultSssDeduct.ToString("0.##")
        txtPhilhealth.Text = _defaultPhilhealthDeduct.ToString("0.##")
        txtPagibig.Text = _defaultPagibigDeduct.ToString("0.##")
        txtOfficerAllowanceFirst.Text = _defaultOfficerAllowance.ToString("0.##")
        txtSgUniformAllowanceFirst.Text = _defaultSgUniformAllowance.ToString("0.##")

        txtCashBond.Text = _defaultCbDeduct.ToString("0.##")
        txtSssLoan.Text = _defaultSssLoanDeduct.ToString("0.##")
        txtSssCalLoan.Text = _defaultSssCalLoanDeduct.ToString("0.##")
        txtPiLoan.Text = _defaultPiLoanDeduct.ToString("0.##")
        txtPiCalLoan.Text = _defaultPiCalLoanDeduct.ToString("0.##")
        txtOfficerAllowanceSecond.Text = _defaultOfficerAllowance.ToString("0.##")
        txtSgUniformAllowanceSecond.Text = _defaultSgUniformAllowance.ToString("0.##")

        pnlFirstCutoff.Visible = _isFirstCutoff
        pnlSecondCutoff.Visible = Not _isFirstCutoff

        RefreshAllocationLabels()
        RefreshWorkValueSummary()
    End Sub

    Private Sub RefreshWorkValueSummary()
        Dim hourlyRate As Decimal = If(_dailyWage > 0D, _dailyWage / 8D, 0D)
        Dim workAmount As Decimal = _totalHours * hourlyRate

        lblTotalWorkingHoursValue.Text = _totalHours.ToString("0.##")
        lblHourlyRateValue.Text = FormatPeso(hourlyRate)
        lblTotalWorkPesoValue.Text = FormatPeso(workAmount)
        lblFooterStatus.Text = "Total working hours are valued using Daily Wage / 8."
    End Sub

    Private Sub LoadSubClientDetails()
        If _subClientId <= 0 Then Return

        Try
            Connect_to_MDB()
            Using cmd As New OleDbCommand("SELECT SUB_CLIENT_NAME, DAILY_WAGE FROM TBL_CLIENT_SUB WHERE SUB_CLIENT_ID = ?", GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", _subClientId)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        _subClientName = Convert.ToString(reader("SUB_CLIENT_NAME")).Trim()

                        Dim wageValue As Decimal
                        If Decimal.TryParse(Convert.ToString(reader("DAILY_WAGE")), wageValue) Then
                            _dailyWage = wageValue
                        End If
                    End If
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub AdjustAllocation(allocationName As String, delta As Decimal)
        If delta = 0D Then Return

        If delta < 0D Then
            If GetAllocationValue(allocationName) < Math.Abs(delta) Then
                AppNotification.Show("No more hours to remove from " & allocationName & ".", "Adjustment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            SetAllocationValue(allocationName, GetAllocationValue(allocationName) + delta)
            _unallocatedHours += Math.Abs(delta)
            RefreshAllocationLabels()
            Return
        End If

        If _unallocatedHours < delta Then
            AppNotification.Show("No unallocated hours available to add.", "Adjustment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        SetAllocationValue(allocationName, GetAllocationValue(allocationName) + delta)
        _unallocatedHours -= delta
        RefreshAllocationLabels()
    End Sub

    Private Sub HandleUnallocateAllForType(allocationName As String)
        Dim currentValue As Decimal = GetAllocationValue(allocationName)
        If currentValue <= 0D Then Return

        SetAllocationValue(allocationName, 0D)
        _unallocatedHours += currentValue
        RefreshAllocationLabels()
    End Sub

    Private Sub HandleAllocateAllUnallocatedForType(allocationName As String)
        If _unallocatedHours <= 0D Then Return

        SetAllocationValue(allocationName, GetAllocationValue(allocationName) + _unallocatedHours)
        _unallocatedHours = 0D
        RefreshAllocationLabels()
    End Sub

    Private Sub HandleResetToOriginal(sender As Object, e As EventArgs)
        _regHours = _initialRegHours
        _sunHours = _initialSunHours
        _shHours = _initialShHours
        _lhHours = _initialLhHours
        _unallocatedHours = 0D
        RefreshAllocationLabels()
    End Sub

    Private Function GetAllocationValue(allocationName As String) As Decimal
        Select Case allocationName.ToUpperInvariant()
            Case "REG"
                Return _regHours
            Case "SUN"
                Return _sunHours
            Case "SH"
                Return _shHours
            Case "LH"
                Return _lhHours
            Case Else
                Return 0D
        End Select
    End Function

    Private Sub SetAllocationValue(allocationName As String, value As Decimal)
        value = Math.Max(0D, value)

        Select Case allocationName.ToUpperInvariant()
            Case "REG"
                _regHours = value
            Case "SUN"
                _sunHours = value
            Case "SH"
                _shHours = value
            Case "LH"
                _lhHours = value
        End Select
    End Sub

    Private Sub RefreshAllocationLabels()
        lblRegValue.Text = _regHours.ToString("0.##")
        lblSunValue.Text = _sunHours.ToString("0.##")
        lblShValue.Text = _shHours.ToString("0.##")
        lblLhValue.Text = _lhHours.ToString("0.##")
        lblUnallocatedValue.Text = _unallocatedHours.ToString("0.##")
        lblUnallocatedValue.ForeColor = If(_unallocatedHours = 0D, Color.Teal, Color.FromArgb(194, 77, 0))
    End Sub

    Private Sub HandleSave(sender As Object, e As EventArgs)
        Dim cbDeduct As Decimal = _defaultCbDeduct
        Dim sssLoanDeduct As Decimal = _defaultSssLoanDeduct
        Dim sssCalLoanDeduct As Decimal = _defaultSssCalLoanDeduct
        Dim piLoanDeduct As Decimal = _defaultPiLoanDeduct
        Dim piCalLoanDeduct As Decimal = _defaultPiCalLoanDeduct
        Dim philhealthDeduct As Decimal = _defaultPhilhealthDeduct
        Dim sssDeduct As Decimal = _defaultSssDeduct
        Dim pagibigDeduct As Decimal = _defaultPagibigDeduct
        Dim officerAllowance As Decimal = _defaultOfficerAllowance
        Dim sguniformallowance As Decimal = _defaultSgUniformAllowance

        If _isFirstCutoff Then
            If Not TryReadDecimal(txtSss, sssDeduct, "SSS Deduction") Then Return
            If Not TryReadDecimal(txtPhilhealth, philhealthDeduct, "PhilHealth Deduction") Then Return
            If Not TryReadDecimal(txtPagibig, pagibigDeduct, "Pag-IBIG Deduction") Then Return
            If Not TryReadDecimal(txtOfficerAllowanceFirst, officerAllowance, "Officer's Allowance") Then Return
            If Not TryReadDecimal(txtSgUniformAllowanceFirst, sguniformallowance, "SG Uniform Allowance") Then Return
        Else
            If Not TryReadDecimal(txtCashBond, cbDeduct, "Cash Bond Deduction") Then Return
            If Not TryReadDecimal(txtSssLoan, sssLoanDeduct, "SSS Loan Deduction") Then Return
            If Not TryReadDecimal(txtSssCalLoan, sssCalLoanDeduct, "SSS Cal Loan Deduction") Then Return
            If Not TryReadDecimal(txtPiLoan, piLoanDeduct, "Pag-IBIG Loan Deduction") Then Return
            If Not TryReadDecimal(txtPiCalLoan, piCalLoanDeduct, "Pag-IBIG Cal Loan Deduction") Then Return
            If Not TryReadDecimal(txtOfficerAllowanceSecond, officerAllowance, "Officer's Allowance") Then Return
            If Not TryReadDecimal(txtSgUniformAllowanceSecond, sguniformallowance, "SG Uniform Allowance") Then Return
        End If

        If _unallocatedHours > 0D Then
            AppNotification.Show("Unable to save while there are unallocated hours. Please allocate all hours or reset to original first.", "Unallocated Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Save_DTR_Deductions_Update(
            _employeeId,
            _subClientId,
            _cutoff,
            _numDays,
            _totalHours,
            _regHours,
            _sunHours,
            _shHours,
            _lhHours,
            _otRegHours,
            cbDeduct,
            sssLoanDeduct,
            sssCalLoanDeduct,
            piLoanDeduct,
            piCalLoanDeduct,
            philhealthDeduct,
            sssDeduct,
            pagibigDeduct,
            officerAllowance,
            sguniformallowance
        )

        AppNotification.Show("Deductions updated successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        DialogResult = DialogResult.OK
    End Sub

    Private Sub HandleCancel(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
    End Sub

    Private Function TryReadDecimal(textBox As TextBox, ByRef value As Decimal, fieldName As String) As Boolean
        If textBox Is Nothing Then Return True

        Dim cleaned As String = textBox.Text.Trim().Replace(",", "")
        If Decimal.TryParse(cleaned, value) Then
            Return True
        End If

        AppNotification.Show("Invalid value for " & fieldName & ".", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        textBox.Focus()
        Return False
    End Function

    Private Function FormatCutoff(cutoff As String) As String
        If String.IsNullOrWhiteSpace(cutoff) Then Return cutoff

        Dim parts() As String = cutoff.Split("_"c)
        If parts.Length <> 3 Then Return cutoff

        Dim monthNumber As Integer
        Dim yearNumber As Integer
        If Not Integer.TryParse(parts(0), monthNumber) Then Return cutoff
        If Not Integer.TryParse(parts(2), yearNumber) Then Return cutoff
        If monthNumber < 1 OrElse monthNumber > 12 Then Return cutoff

        Dim cutoffPart As String = parts(1).Trim()
        If Not cutoffPart.Equals("1st", StringComparison.OrdinalIgnoreCase) AndAlso
            Not cutoffPart.Equals("2nd", StringComparison.OrdinalIgnoreCase) Then
            Return cutoff
        End If

        Dim monthName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber)
        Dim normalizedCutoff As String = cutoffPart.ToLowerInvariant()
        Dim cutoffLabel As String = Char.ToUpperInvariant(normalizedCutoff(0)) & normalizedCutoff.Substring(1)

        Return monthName & " " & yearNumber.ToString() & " (" & cutoffLabel & " Cutoff)"
    End Function

    Private Function FormatPeso(value As Decimal) As String
        Return "PHP " & value.ToString("N2", CultureInfo.CurrentCulture)
    End Function
End Class
