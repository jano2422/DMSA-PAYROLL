Imports System.Drawing
Imports System.Windows.Forms

Public Class FRM_DTR_DEDUCTION_UPDATE
    Inherits Form

    Private ReadOnly _employeeId As String
    Private ReadOnly _employeeName As String
    Private ReadOnly _cutoff As String
    Private ReadOnly _subClientId As Integer
    Private ReadOnly _numDays As Decimal
    Private ReadOnly _totalHours As Decimal
    Private ReadOnly _regHours As Decimal
    Private ReadOnly _sunHours As Decimal
    Private ReadOnly _shHours As Decimal
    Private ReadOnly _lhHours As Decimal
    Private ReadOnly _otRegHours As Decimal
    Private ReadOnly _defaultCbDeduct As Decimal
    Private ReadOnly _defaultSssLoanDeduct As Decimal
    Private ReadOnly _defaultSssCalLoanDeduct As Decimal
    Private ReadOnly _defaultPiLoanDeduct As Decimal
    Private ReadOnly _defaultPiCalLoanDeduct As Decimal
    Private ReadOnly _defaultPhilhealthDeduct As Decimal
    Private ReadOnly _defaultSssDeduct As Decimal
    Private ReadOnly _defaultPagibigDeduct As Decimal

    Private ReadOnly _isFirstCutoff As Boolean

    Private txtSss As TextBox
    Private txtPhilhealth As TextBox
    Private txtPagibig As TextBox
    Private txtCashBond As TextBox
    Private txtSssLoan As TextBox
    Private txtSssCalLoan As TextBox
    Private txtPiLoan As TextBox
    Private txtPiCalLoan As TextBox

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
        pagibigDeduct As Decimal
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
        _otRegHours = otRegHours
        _defaultCbDeduct = cbDeduct
        _defaultSssLoanDeduct = sssLoanDeduct
        _defaultSssCalLoanDeduct = sssCalLoanDeduct
        _defaultPiLoanDeduct = piLoanDeduct
        _defaultPiCalLoanDeduct = piCalLoanDeduct
        _defaultPhilhealthDeduct = philhealthDeduct
        _defaultSssDeduct = sssDeduct
        _defaultPagibigDeduct = pagibigDeduct

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
            .Text = $"Employee: {_employeeName}" & Environment.NewLine & $"Cutoff: {_cutoff}",
            .AutoSize = True,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 30, 30),
            .Padding = New Padding(0, 0, 0, 8)
        }

        mainPanel.Controls.Add(header, 0, 0)
        mainPanel.SetColumnSpan(header, 2)

        Dim rowIndex As Integer = 1

        If _isFirstCutoff Then
            txtSss = AddField(mainPanel, rowIndex, "SSS Deduction", _defaultSssDeduct)
            rowIndex += 1
            txtPhilhealth = AddField(mainPanel, rowIndex, "PhilHealth Deduction", _defaultPhilhealthDeduct)
            rowIndex += 1
            txtPagibig = AddField(mainPanel, rowIndex, "Pag-IBIG Deduction", _defaultPagibigDeduct)
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

        If _isFirstCutoff Then
            If Not TryReadDecimal(txtSss, sssDeduct, "SSS Deduction") Then Return
            If Not TryReadDecimal(txtPhilhealth, philhealthDeduct, "PhilHealth Deduction") Then Return
            If Not TryReadDecimal(txtPagibig, pagibigDeduct, "Pag-IBIG Deduction") Then Return
        Else
            If Not TryReadDecimal(txtCashBond, cbDeduct, "Cash Bond Deduction") Then Return
            If Not TryReadDecimal(txtSssLoan, sssLoanDeduct, "SSS Loan Deduction") Then Return
            If Not TryReadDecimal(txtSssCalLoan, sssCalLoanDeduct, "SSS Cal Loan Deduction") Then Return
            If Not TryReadDecimal(txtPiLoan, piLoanDeduct, "Pag-IBIG Loan Deduction") Then Return
            If Not TryReadDecimal(txtPiCalLoan, piCalLoanDeduct, "Pag-IBIG Cal Loan Deduction") Then Return
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
            pagibigDeduct
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
End Class
