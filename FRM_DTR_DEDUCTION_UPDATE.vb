Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Public Class FRM_DTR_DEDUCTION_UPDATE
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

    Private ReadOnly _isFirstCutoff As Boolean

    Private txtSss As TextBox
    Private txtPhilhealth As TextBox
    Private txtPagibig As TextBox
    Private txtCashBond As TextBox
    Private txtSssLoan As TextBox
    Private txtSssCalLoan As TextBox
    Private txtPiLoan As TextBox
    Private txtPiCalLoan As TextBox
    Private txtOfficerAllowance As TextBox

    Private lblRegValue As Label
    Private lblSunValue As Label
    Private lblShValue As Label
    Private lblLhValue As Label
    Private lblUnallocatedValue As Label

    Private _unallocatedHours As Decimal
    Private ReadOnly _initialRegHours As Decimal
    Private ReadOnly _initialSunHours As Decimal
    Private ReadOnly _initialShHours As Decimal
    Private ReadOnly _initialLhHours As Decimal

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
        officerAllowance As Decimal
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
        _unallocatedHours = 0D

        _isFirstCutoff = IsFirstCutoff(cutoff)

        InitializeComponents()
    End Sub

    Private Sub InitializeComponents()
        Text = $"Update Deductions - {_employeeName}"
        StartPosition = FormStartPosition.CenterParent
        FormBorderStyle = FormBorderStyle.FixedDialog
        MinimizeBox = False
        MaximizeBox = False
        Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink

        Dim mainPanel As New TableLayoutPanel With {
    .Dock = DockStyle.Fill,
    .ColumnCount = 2,
    .AutoSize = True,
    .Padding = New Padding(16)}

        mainPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 45))
        mainPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 55))

        Dim header As New Label With {
            .Text = $"Employee: {_employeeName}" & Environment.NewLine & $"Cutoff: {FormatCutoff(_cutoff)}",
            .AutoSize = True,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 30, 30),
            .Padding = New Padding(0, 0, 0, 8)
        }

        mainPanel.Controls.Add(header, 0, 0)
        mainPanel.SetColumnSpan(header, 2)

        Dim rowIndex As Integer = 1

        mainPanel.Controls.Add(BuildAllocationSection(), 0, rowIndex)
        mainPanel.SetColumnSpan(mainPanel.GetControlFromPosition(0, rowIndex), 2)
        rowIndex += 1

        If _isFirstCutoff Then
            txtSss = AddField(mainPanel, rowIndex, "SSS Deduction", _defaultSssDeduct)
            rowIndex += 1
            txtPhilhealth = AddField(mainPanel, rowIndex, "PhilHealth Deduction", _defaultPhilhealthDeduct)
            rowIndex += 1
            txtPagibig = AddField(mainPanel, rowIndex, "Pag-IBIG Deduction", _defaultPagibigDeduct)
            rowIndex += 1
            txtOfficerAllowance = AddField(mainPanel, rowIndex, "Officer's Allowance", _defaultOfficerAllowance)
            rowIndex += 1
        Else
            txtCashBond = AddField(mainPanel, rowIndex, "Cash Bond Deduction", _defaultCbDeduct)
            rowIndex += 1
            txtSssLoan = AddField(mainPanel, rowIndex, "SSS Loan Deduction", _defaultSssLoanDeduct)
            rowIndex += 1
            txtSssCalLoan = AddField(mainPanel, rowIndex, "SSS Cal Loan Deduction", _defaultSssCalLoanDeduct)
            rowIndex += 1
            txtPiLoan = AddField(mainPanel, rowIndex, "Pag-IBIG Loan Deduction", _defaultPiLoanDeduct)
            rowIndex += 1
            txtPiCalLoan = AddField(mainPanel, rowIndex, "Pag-IBIG Cal Loan Deduction", _defaultPiCalLoanDeduct)
            rowIndex += 1
            txtOfficerAllowance = AddField(mainPanel, rowIndex, "Officer's Allowance", _defaultOfficerAllowance)
            rowIndex += 1
        End If

        Dim buttonPanel As New FlowLayoutPanel With {
            .FlowDirection = FlowDirection.RightToLeft,
            .Dock = DockStyle.Fill,
            .AutoSize = True
        }

        Dim btnSave As New Button With {
            .Text = "Save",
            .AutoSize = True,
            .BackColor = Color.FromArgb(0, 120, 212),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        btnSave.FlatAppearance.BorderSize = 0
        AddHandler btnSave.Click, AddressOf HandleSave

        Dim btnCancel As New Button With {
            .Text = "Cancel",
            .AutoSize = True
        }
        AddHandler btnCancel.Click, Sub() DialogResult = DialogResult.Cancel

        buttonPanel.Controls.Add(btnSave)
        buttonPanel.Controls.Add(btnCancel)

        mainPanel.Controls.Add(buttonPanel, 0, rowIndex)
        mainPanel.SetColumnSpan(buttonPanel, 2)

        Controls.Add(mainPanel)
        AcceptButton = btnSave
        CancelButton = btnCancel
    End Sub

    Private Function BuildAllocationSection() As Control
        Dim sectionPanel As New TableLayoutPanel With {
            .ColumnCount = 1,
            .AutoSize = True,
            .Dock = DockStyle.Fill,
            .Margin = New Padding(0, 0, 0, 12)
        }

        Dim sectionTitle As New Label With {
            .Text = "Hour Allocation Adjustment (REG/SUN/SH/LH)",
            .AutoSize = True,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .Margin = New Padding(0, 4, 0, 6)
        }
        sectionPanel.Controls.Add(sectionTitle)

        Dim grid As New TableLayoutPanel With {
            .ColumnCount = 6,
            .RowCount = 6,
            .AutoSize = True,
            .Dock = DockStyle.Fill
        }

        grid.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100))
        grid.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 90))
        grid.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 55))
        grid.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 55))
        grid.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 120))
        grid.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 170))

        grid.Controls.Add(New Label With {.Text = "Type", .AutoSize = True, .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}, 0, 0)
        grid.Controls.Add(New Label With {.Text = "Hours", .AutoSize = True, .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}, 1, 0)

        lblRegValue = AddAllocationRow(grid, 1, "REG", _regHours,
            Sub() AdjustAllocation("REG", -1D),
            Sub() AdjustAllocation("REG", 1D))

        lblSunValue = AddAllocationRow(grid, 2, "SUN", _sunHours,
            Sub() AdjustAllocation("SUN", -1D),
            Sub() AdjustAllocation("SUN", 1D))

        lblShValue = AddAllocationRow(grid, 3, "SH", _shHours,
            Sub() AdjustAllocation("SH", -1D),
            Sub() AdjustAllocation("SH", 1D))

        lblLhValue = AddAllocationRow(grid, 4, "LH", _lhHours,
            Sub() AdjustAllocation("LH", -1D),
            Sub() AdjustAllocation("LH", 1D))

        Dim lblUnallocated As New Label With {
            .Text = "Unallocated",
            .AutoSize = True,
            .Margin = New Padding(0, 8, 8, 4),
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        }
        lblUnallocatedValue = New Label With {
            .Text = _unallocatedHours.ToString("0.##"),
            .AutoSize = True,
            .Margin = New Padding(0, 8, 8, 4),
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(194, 77, 0)
        }

        grid.Controls.Add(lblUnallocated, 0, 5)
        grid.Controls.Add(lblUnallocatedValue, 1, 5)
        sectionPanel.Controls.Add(grid)

        Dim actionPanel As New FlowLayoutPanel With {
            .AutoSize = True,
            .FlowDirection = FlowDirection.LeftToRight,
            .Margin = New Padding(0, 8, 0, 0)
        }

        Dim btnResetAll As New Button With {
            .Text = "Reset to Original",
            .AutoSize = True
        }
        AddHandler btnResetAll.Click, AddressOf HandleResetToOriginal

        Dim btnRestoreAll As New Button With {
            .Text = "Restore Distribution from Unallocated",
            .AutoSize = True
        }
        AddHandler btnRestoreAll.Click, AddressOf HandleRestoreAll

        actionPanel.Controls.Add(btnResetAll)
        actionPanel.Controls.Add(btnRestoreAll)
        sectionPanel.Controls.Add(actionPanel)

        Return sectionPanel
    End Function

    Private Function AddAllocationRow(grid As TableLayoutPanel, row As Integer, allocationName As String, value As Decimal, onMinus As Action, onPlus As Action) As Label
        Dim lblName As New Label With {
            .Text = allocationName,
            .AutoSize = True,
            .Margin = New Padding(0, 6, 8, 6)
        }

        Dim lblValue As New Label With {
            .Text = value.ToString("0.##"),
            .AutoSize = True,
            .Margin = New Padding(0, 6, 8, 6)
        }

        Dim btnMinus As New Button With {
            .Text = "-",
            .Width = 45,
            .Height = 28,
            .Margin = New Padding(0, 2, 6, 2)
        }
        AddHandler btnMinus.Click, Sub() onMinus()

        Dim btnPlus As New Button With {
            .Text = "+",
            .Width = 45,
            .Height = 28,
            .Margin = New Padding(0, 2, 0, 2)
        }
        AddHandler btnPlus.Click, Sub() onPlus()

        Dim btnUnallocateAll As New Button With {
            .Text = "Unallocate All",
            .AutoSize = True,
            .Margin = New Padding(0, 2, 6, 2)
        }
        AddHandler btnUnallocateAll.Click, Sub() HandleUnallocateAllForType(allocationName)

        Dim btnAllocateAll As New Button With {
            .Text = "Allocate All Unallocated",
            .AutoSize = True,
            .Margin = New Padding(0, 2, 0, 2)
        }
        AddHandler btnAllocateAll.Click, Sub() HandleAllocateAllUnallocatedForType(allocationName)

        grid.Controls.Add(lblName, 0, row)
        grid.Controls.Add(lblValue, 1, row)
        grid.Controls.Add(btnMinus, 2, row)
        grid.Controls.Add(btnPlus, 3, row)
        grid.Controls.Add(btnUnallocateAll, 4, row)
        grid.Controls.Add(btnAllocateAll, 5, row)

        Return lblValue
    End Function

    Private Sub AdjustAllocation(allocationName As String, delta As Decimal)
        If delta = 0D Then Return

        If delta < 0D Then
            If GetAllocationValue(allocationName) < Math.Abs(delta) Then
                MessageBox.Show($"No more hours to remove from {allocationName}.", "Adjustment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            SetAllocationValue(allocationName, GetAllocationValue(allocationName) + delta)
            _unallocatedHours += Math.Abs(delta)
            RefreshAllocationLabels()
            Return
        End If

        If _unallocatedHours < delta Then
            MessageBox.Show("No unallocated hours available to add.", "Adjustment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        SetAllocationValue(allocationName, GetAllocationValue(allocationName) + delta)
        _unallocatedHours -= delta
        RefreshAllocationLabels()
    End Sub

    Private Sub HandleUnallocateAllForType(allocationName As String)
        Dim currentValue As Decimal = GetAllocationValue(allocationName)
        If currentValue <= 0D Then
            Return
        End If

        SetAllocationValue(allocationName, 0D)
        _unallocatedHours += currentValue
        RefreshAllocationLabels()
    End Sub

    Private Sub HandleAllocateAllUnallocatedForType(allocationName As String)
        If _unallocatedHours <= 0D Then
            Return
        End If

        SetAllocationValue(allocationName, GetAllocationValue(allocationName) + _unallocatedHours)
        _unallocatedHours = 0D
        RefreshAllocationLabels()
    End Sub

    Private Sub HandleRestoreAll(sender As Object, e As EventArgs)
        Dim totalAdjustableHours As Decimal = _regHours + _sunHours + _shHours + _lhHours + _unallocatedHours
        Dim initialTotal As Decimal = _initialRegHours + _initialSunHours + _initialShHours + _initialLhHours

        If totalAdjustableHours <= 0D Then
            RefreshAllocationLabels()
            Return
        End If

        _regHours = Math.Min(_initialRegHours, totalAdjustableHours)
        totalAdjustableHours -= _regHours

        _sunHours = Math.Min(_initialSunHours, totalAdjustableHours)
        totalAdjustableHours -= _sunHours

        _shHours = Math.Min(_initialShHours, totalAdjustableHours)
        totalAdjustableHours -= _shHours

        _lhHours = Math.Min(_initialLhHours, totalAdjustableHours)
        totalAdjustableHours -= _lhHours

        If totalAdjustableHours > 0D Then
            _regHours += totalAdjustableHours
            totalAdjustableHours = 0D
        End If

        _unallocatedHours = Math.Max(0D, initialTotal - (_regHours + _sunHours + _shHours + _lhHours))
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
        If lblRegValue IsNot Nothing Then lblRegValue.Text = _regHours.ToString("0.##")
        If lblSunValue IsNot Nothing Then lblSunValue.Text = _sunHours.ToString("0.##")
        If lblShValue IsNot Nothing Then lblShValue.Text = _shHours.ToString("0.##")
        If lblLhValue IsNot Nothing Then lblLhValue.Text = _lhHours.ToString("0.##")
        If lblUnallocatedValue IsNot Nothing Then lblUnallocatedValue.Text = _unallocatedHours.ToString("0.##")
    End Sub

    Private Function AddField(panel As TableLayoutPanel, rowIndex As Integer, labelText As String, initialValue As Decimal) As TextBox
        panel.RowStyles.Add(New RowStyle(SizeType.AutoSize))

        Dim lbl As New Label With {
            .Text = labelText,
            .AutoSize = True,
            .Margin = New Padding(0, 6, 8, 6)
        }

        Dim txt As New TextBox With {
            .Text = initialValue.ToString("0.##"),
            .Margin = New Padding(0, 3, 0, 3),
            .Width = 220
        }

        panel.Controls.Add(lbl, 0, rowIndex)
        panel.Controls.Add(txt, 1, rowIndex)

        Return txt
    End Function

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

        If _isFirstCutoff Then
            If Not TryReadDecimal(txtSss, sssDeduct, "SSS Deduction") Then Return
            If Not TryReadDecimal(txtPhilhealth, philhealthDeduct, "PhilHealth Deduction") Then Return
            If Not TryReadDecimal(txtPagibig, pagibigDeduct, "Pag-IBIG Deduction") Then Return
            If Not TryReadDecimal(txtOfficerAllowance, officerAllowance, "Officer's Allowance") Then Return
        Else
            If Not TryReadDecimal(txtCashBond, cbDeduct, "Cash Bond Deduction") Then Return
            If Not TryReadDecimal(txtSssLoan, sssLoanDeduct, "SSS Loan Deduction") Then Return
            If Not TryReadDecimal(txtSssCalLoan, sssCalLoanDeduct, "SSS Cal Loan Deduction") Then Return
            If Not TryReadDecimal(txtPiLoan, piLoanDeduct, "Pag-IBIG Loan Deduction") Then Return
            If Not TryReadDecimal(txtPiCalLoan, piCalLoanDeduct, "Pag-IBIG Cal Loan Deduction") Then Return
            If Not TryReadDecimal(txtOfficerAllowance, officerAllowance, "Officer's Allowance") Then Return
        End If

        If _unallocatedHours > 0D Then
            MessageBox.Show("Unable to save while there are unallocated hours. Please allocate all hours or reset to original first.", "Unallocated Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            officerAllowance
        )

        MessageBox.Show("Deductions updated successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        DialogResult = DialogResult.OK
    End Sub

    Private Function TryReadDecimal(textBox As TextBox, ByRef value As Decimal, fieldName As String) As Boolean
        If textBox Is Nothing Then Return True

        Dim cleaned As String = textBox.Text.Trim().Replace(",", "")
        If Decimal.TryParse(cleaned, value) Then
            Return True
        End If

        MessageBox.Show($"Invalid value for {fieldName}.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        Return $"{monthName} {yearNumber} ({cutoffLabel} Cutoff)"
    End Function

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'FRM_DTR_DEDUCTION_UPDATE
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Name = "FRM_DTR_DEDUCTION_UPDATE"
        Me.ResumeLayout(False)

    End Sub

    Private Sub FRM_DTR_DEDUCTION_UPDATE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
