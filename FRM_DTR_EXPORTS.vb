Imports System.Data
Imports System.Globalization
Imports System.Drawing

Public Partial Class FRM_DTR_EXPORTS
    Private _displayedCutoff As String = ""
    Private _displayedCutoffText As String = ""
    Private _displayedMonthText As String = ""
    Private _displayedYearText As String = ""
    Private _displayedClientId As String = ""
    Private _displayedHasRecords As Boolean = False

    Private Function TryBuildCutoff(ByRef cutoff As String) As Boolean
        cutoff = ""

        If Cmb_CutOff.SelectedIndex < 0 Then
            MsgBox("Please select a cutoff first!", vbExclamation, "Cut Off")
            Return False
        End If

        If Cmb_Month.SelectedIndex < 0 Then
            MsgBox("Please select a month first!", vbExclamation, "Month")
            Return False
        End If

        If Cmb_Year.SelectedIndex < 0 Then
            MsgBox("Please select a year first!", vbExclamation, "Year")
            Return False
        End If

        Dim monthNumber As Integer = DateTime.ParseExact(Cmb_Month.Text.Trim().ToUpperInvariant(), "MMM", CultureInfo.InvariantCulture).Month
        cutoff = monthNumber & "_" & Mid(Cmb_CutOff.Text, 1, 3) & "_" & Cmb_Year.Text
        Return True
    End Function

    Private Function ReadDecimal(value As Object) As Decimal
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0D
        Dim cleaned As String = value.ToString().Trim().Replace(",", "")
        Dim parsed As Decimal
        Decimal.TryParse(cleaned, parsed)
        Return parsed
    End Function

    Private Sub Btn_Client_Click(sender As Object, e As EventArgs) Handles Btn_Client.Click
        Using clientSelector As New FRM_DTR_CLIENT_LIST_ALL()
            clientSelector.ShowDialog(Me)
        End Using
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click
        Close()
    End Sub

    Private Sub FRM_DTR_EXPORTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupRuntimeUi()

        ' Populate Cmb_Month with month names (Jan, Feb, etc.)
        Cmb_Month.Items.Clear()
        For i As Integer = 1 To 12
            Cmb_Month.Items.Add(New DateTime(1, i, 1).ToString("MMM")) ' Abbreviated month name
        Next

        ' Populate Cmb_Year with a range of years (e.g., current year ± 10 years)
        Cmb_Year.Items.Clear()

        Dim currentYear As Integer = DateTime.Now.Year

        For i As Integer = currentYear To 2023 Step -1
            Cmb_Year.Items.Add(i.ToString())
        Next



        ' Set the default selected items to the current month and year
        Cmb_CutOff.SelectedIndex = 0
        Cmb_Month.SelectedItem = DateTime.Now.ToString("MMM")
        Cmb_Year.SelectedItem = currentYear.ToString()
        UpdateActionStates()
    End Sub

    Private Sub SetupRuntimeUi()
        ApplyGridStyle(DGV_DTR_Per_Client)
        ApplyGridStyle(DGV_DTR_MATRIX)

        AddHandler Lbl_ClientID.TextChanged, Sub(sender, e)
                                                 If Not String.IsNullOrWhiteSpace(_displayedCutoff) AndAlso
                                                    Not String.Equals(_displayedClientId, Lbl_ClientID.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
                                                     ClearDisplayedRecords()
                                                 End If

                                                 UpdateActionStates()
                                             End Sub
        AddHandler DGV_DTR_Per_Client.RowsAdded, Sub(sender, e) UpdateActionStates()
        AddHandler DGV_DTR_Per_Client.RowsRemoved, Sub(sender, e) UpdateActionStates()
        AddHandler DGV_DTR_Per_Client.DataBindingComplete, Sub(sender, e)
                                                               ApplyGridStyle(DGV_DTR_Per_Client)
                                                               UpdateActionStates()
                                                           End Sub
        AddHandler DGV_DTR_MATRIX.RowsAdded, Sub(sender, e) UpdateActionStates()
        AddHandler DGV_DTR_MATRIX.RowsRemoved, Sub(sender, e) UpdateActionStates()
        AddHandler DGV_DTR_MATRIX.DataBindingComplete, Sub(sender, e)
                                                           ApplyGridStyle(DGV_DTR_MATRIX)
                                                           UpdateActionStates()
                                                       End Sub
        AddHandler Cmb_Year.SelectedIndexChanged, Sub(sender, e) UpdateLoadedPeriodStatus()
        AddHandler Cmb_Month.SelectedIndexChanged, Sub(sender, e) UpdateLoadedPeriodStatus()
        AddHandler Cmb_CutOff.SelectedIndexChanged, Sub(sender, e) UpdateLoadedPeriodStatus()
    End Sub

    Private Sub ApplyGridStyle(grid As DataGridView)
        grid.EnableHeadersVisualStyles = False
        grid.BackgroundColor = Color.FromArgb(255, 224, 192)
        grid.GridColor = Color.FromArgb(224, 176, 128)
        grid.BorderStyle = BorderStyle.FixedSingle
        grid.RowHeadersVisible = False
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 238, 214)
        grid.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192)
        grid.DefaultCellStyle.ForeColor = Color.Black
        grid.DefaultCellStyle.SelectionBackColor = Color.Teal
        grid.DefaultCellStyle.SelectionForeColor = Color.White
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        grid.ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 9.0!, FontStyle.Bold)
    End Sub

    Private Sub UpdateActionStates()
        Dim hasClient As Boolean = Not String.IsNullOrWhiteSpace(Lbl_ClientID.Text)
        Dim hasPerClientRows As Boolean = DGV_DTR_Per_Client.Rows.Count > 0
        Dim hasMatrixRows As Boolean = DGV_DTR_MATRIX.Rows.Count > 0 OrElse DGV_DTR_MATRIX.DataSource IsNot Nothing
        Dim hasDisplayedPeriod As Boolean = Not String.IsNullOrWhiteSpace(_displayedCutoff) AndAlso String.Equals(_displayedClientId, Lbl_ClientID.Text.Trim(), StringComparison.OrdinalIgnoreCase)

        SetActionButtonState(Btn_Show, hasClient)
        SetActionButtonState(Btn_Export_to_Excell, hasClient AndAlso hasDisplayedPeriod AndAlso _displayedHasRecords AndAlso hasPerClientRows)
        SetActionButtonState(btnDtrHrsExport, hasClient AndAlso hasDisplayedPeriod AndAlso _displayedHasRecords AndAlso hasMatrixRows)
        Label5.Text = If(hasClient, "Selected client", "Select a client")
        UpdateLoadedPeriodStatus()
    End Sub

    Private Sub SetActionButtonState(button As Button, isEnabled As Boolean)
        button.Enabled = isEnabled
        button.BackColor = If(isEnabled, Color.Teal, Color.FromArgb(210, 174, 132))
        button.ForeColor = If(isEnabled, Color.White, Color.FromArgb(85, 68, 52))
    End Sub

    Private Sub SetDisplayedPeriod(cutoff As String, hasRecords As Boolean)
        _displayedCutoff = cutoff
        _displayedCutoffText = Cmb_CutOff.Text.Trim()
        _displayedMonthText = Cmb_Month.Text.Trim()
        _displayedYearText = Cmb_Year.Text.Trim()
        _displayedClientId = Lbl_ClientID.Text.Trim()
        _displayedHasRecords = hasRecords
        UpdateLoadedPeriodStatus()
    End Sub

    Private Sub ClearDisplayedPeriod()
        _displayedCutoff = ""
        _displayedCutoffText = ""
        _displayedMonthText = ""
        _displayedYearText = ""
        _displayedClientId = ""
        _displayedHasRecords = False
        UpdateLoadedPeriodStatus()
    End Sub

    Private Sub ClearDisplayedRecords()
        DGV_DTR_Per_Client.DataSource = Nothing
        DGV_DTR_Per_Client.Rows.Clear()
        DGV_DTR_Per_Client.Columns.Clear()

        DGV_DTR_MATRIX.DataSource = Nothing
        DGV_DTR_MATRIX.Rows.Clear()
        DGV_DTR_MATRIX.Columns.Clear()

        ClearDisplayedPeriod()
    End Sub

    Private Function HasDisplayedPeriod() As Boolean
        Return Not String.IsNullOrWhiteSpace(_displayedCutoff) AndAlso String.Equals(_displayedClientId, Lbl_ClientID.Text.Trim(), StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function IsFilterMatchingDisplayedPeriod() As Boolean
        If Not HasDisplayedPeriod() Then Return False

        Return String.Equals(_displayedCutoffText, Cmb_CutOff.Text.Trim(), StringComparison.OrdinalIgnoreCase) AndAlso
               String.Equals(_displayedMonthText, Cmb_Month.Text.Trim(), StringComparison.OrdinalIgnoreCase) AndAlso
               String.Equals(_displayedYearText, Cmb_Year.Text.Trim(), StringComparison.OrdinalIgnoreCase)
    End Function

    Private Sub UpdateLoadedPeriodStatus()
        If Lbl_LoadedPeriod Is Nothing Then Return

        If Not HasDisplayedPeriod() Then
            Lbl_LoadedPeriod.Text = "Showing: none"
            Lbl_LoadedPeriod.BackColor = Color.FromArgb(255, 224, 192)
            Lbl_LoadedPeriod.ForeColor = Color.FromArgb(74, 55, 32)
            Return
        End If

        Dim periodText As String = _displayedMonthText & " " & _displayedYearText & ", " & _displayedCutoffText
        If Not _displayedHasRecords Then
            Lbl_LoadedPeriod.Text = "No records: " & periodText
            If Not IsFilterMatchingDisplayedPeriod() Then
                Lbl_LoadedPeriod.Text &= " | filters changed"
            End If

            Lbl_LoadedPeriod.BackColor = Color.FromArgb(255, 238, 214)
            Lbl_LoadedPeriod.ForeColor = Color.FromArgb(154, 88, 0)
            Return
        End If

        If IsFilterMatchingDisplayedPeriod() Then
            Lbl_LoadedPeriod.Text = "Showing: " & periodText
            Lbl_LoadedPeriod.BackColor = Color.FromArgb(222, 245, 235)
            Lbl_LoadedPeriod.ForeColor = Color.Teal
        Else
            Lbl_LoadedPeriod.Text = "Showing: " & periodText & " | filters changed"
            Lbl_LoadedPeriod.BackColor = Color.FromArgb(255, 238, 214)
            Lbl_LoadedPeriod.ForeColor = Color.FromArgb(154, 88, 0)
        End If
    End Sub

    Private Function TryGetDisplayedCutoff(ByRef cutoff As String) As Boolean
        cutoff = ""

        If Not HasDisplayedPeriod() Then
            AppNotification.Show("Click Show Records first so the export uses the same cutoff period currently displayed in the grid.", "No Displayed Period", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        cutoff = _displayedCutoff
        Return True
    End Function


    Private Sub Btn_Show_Click(sender As Object, e As EventArgs) Handles Btn_Show.Click

        ' Format Cut-off, Month and Year ( e.g 3_1st_2024 )

        If Lbl_ClientID.Text = "" Then
            MsgBox("Please select a client first!", vbExclamation, "Client ID")
            Exit Sub
        ElseIf Cmb_CutOff.SelectedIndex < 0 Then
            MsgBox("Please select a cutoff first!", vbExclamation, "Cut Off")
            Exit Sub
        ElseIf Cmb_Month.SelectedIndex < 0 Then
            MsgBox("Please select a month first!", vbExclamation, "Month")
            Exit Sub
        ElseIf Cmb_Year.SelectedIndex < 0 Then
            MsgBox("Please select a year first!", vbExclamation, "Year")
            Exit Sub
        End If


        Dim sCut_Off As String
        Dim monthNumber As Integer = DateTime.ParseExact(Cmb_Month.Text.Trim.ToUpper, "MMM", CultureInfo.InvariantCulture).Month
        sCut_Off = monthNumber & "_" & Mid(Cmb_CutOff.Text, 1, 3) & "_" & Cmb_Year.Text

        Call Get_DTR_Per_Client(CInt(Lbl_ClientID.Text), sCut_Off)
        Call Generate_DTR_Hours_Matrix(CInt(Lbl_ClientID.Text), sCut_Off)
        SetDisplayedPeriod(sCut_Off, HasLoadedRows())
        UpdateActionStates()
    End Sub

    Private Function HasLoadedRows() As Boolean
        Return DGV_DTR_Per_Client.Rows.Count > 0 OrElse DGV_DTR_MATRIX.Rows.Count > 0
    End Function

    Private Sub Btn_Export_to_Excell_Click(sender As Object, e As EventArgs) Handles Btn_Export_to_Excell.Click
        Try
            Dim sCut_Off As String = ""
            If Not TryGetDisplayedCutoff(sCut_Off) Then Exit Sub

            ' Validate client details
            If String.IsNullOrWhiteSpace(Lbl_ClientID.Text) OrElse String.IsNullOrWhiteSpace(Lbl_Client_Address.Text) Then
                AppNotification.Show("Client information is missing.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Call export function
            RunWithProcessing("Exporting payroll to Excel...", Sub()
                                                                   Export_DTR_Per_Client_to_Excell(Lbl_Client_Name.Text, Lbl_Client_Address.Text, Lbl_Client_Daily_Wage.Text, sCut_Off)
                                                               End Sub)

        Catch ex As Exception
            AppNotification.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub FRM_DTR_EXPORTS_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnDtrHrsExport_Click(sender As Object, e As EventArgs) Handles btnDtrHrsExport.Click
        Try
            Dim sCut_Off As String = ""
            If Not TryGetDisplayedCutoff(sCut_Off) Then Exit Sub

            ' Validate client details
            If String.IsNullOrWhiteSpace(Lbl_ClientID.Text) OrElse String.IsNullOrWhiteSpace(Lbl_Client_Address.Text) Then
                AppNotification.Show("Client information is missing.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Call export function
            RunWithProcessing("Exporting DTR hours to Excel...", Sub()
                                                                     Export_DTR_Hours_Per_Client_to_Excell(Lbl_Client_Name.Text, Lbl_Client_Address.Text, sCut_Off)
                                                                 End Sub)
        Catch ex As Exception
            AppNotification.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub RunWithProcessing(message As String, exportAction As Action)
        Dim processingForm As New FrmProcessing(message)
        Try
            processingForm.Show(Me)
            processingForm.Refresh()
            Application.DoEvents()
            exportAction()
        Finally
            processingForm.Close()
            processingForm.Dispose()
        End Try
    End Sub

    Private Sub DGV_DTR_Per_Client_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DTR_Per_Client.CellDoubleClick
        If e.RowIndex < 0 Then Return

        If String.IsNullOrWhiteSpace(Lbl_ClientID.Text) Then
            MsgBox("Please select a client first!", vbExclamation, "Client ID")
            Return
        End If

        Dim cutoff As String = ""
        If Not TryGetDisplayedCutoff(cutoff) Then Return

        Dim row As DataGridViewRow = DGV_DTR_Per_Client.Rows(e.RowIndex)
        Dim employeeId As String = Convert.ToString(row.Cells("colEmployeeId").Value).Trim()
        Dim employeeName As String = Convert.ToString(row.Cells("colName").Value).Trim()

        If employeeId = "" Then
            MsgBox("Unable to identify the selected employee.", vbExclamation, "Employee")
            Return
        End If

        Dim numDays As Decimal = ReadDecimal(row.Cells("colNumDays").Value)
        Dim totalHours As Decimal = ReadDecimal(row.Cells("colTotalHours").Value)
        Dim regHours As Decimal = ReadDecimal(row.Cells("colReg").Value)
        Dim sunHours As Decimal = ReadDecimal(row.Cells("colSun").Value)
        Dim shHours As Decimal = ReadDecimal(row.Cells("colSh").Value)
        Dim lhHours As Decimal = ReadDecimal(row.Cells("colLh").Value)
        Dim otRegHours As Decimal = ReadDecimal(row.Cells("colOtReg").Value)

        Dim latestTotals As DataRow = GetLatestDtrTotals(employeeId, cutoff)
        Dim cbDeduct As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("CB_DEDUCT")))
        Dim sssLoanDeduct As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("SSS_LOAN_DEDUCT")))
        Dim sssCalLoanDeduct As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("SSS_CAL_LOAN_DEDUCT")))
        Dim piLoanDeduct As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("PI_LOAN_DEDUCT")))
        Dim piCalLoanDeduct As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("PI_CAL_LOAN_DEDUCT")))
        Dim philhealthDeduct As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("PH_DEDUCT")))
        Dim sssDeduct As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("SSS_DEDUCT")))
        Dim pagibigDeduct As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("PI_DEDUCT")))
        Dim officerAllowance As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("OFFICERS_ALLOWANCE")))
        Dim sguniformallowance As Decimal = ReadDecimal(If(latestTotals Is Nothing, 0D, latestTotals("SGUNIFORMALLOWANCE")))

        Using dialog As New FRM_DTR_DEDUCTION_UPDATE(
            employeeId,
            employeeName,
            cutoff,
            CInt(Lbl_ClientID.Text),
            numDays,
            totalHours,
            regHours,
            sunHours,
            shHours,
            lhHours,
            otRegHours,
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
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                Get_DTR_Per_Client(CInt(Lbl_ClientID.Text), cutoff)
            End If
        End Using
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub DGV_DTR_Per_Client_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_DTR_Per_Client.CellContentClick

    End Sub
End Class
