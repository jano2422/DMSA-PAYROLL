Imports System.Data
Imports System.Globalization
Public Class FRM_DTR_EXPORTS
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
        GlobalVariables.Client_Event = "Payslip_Per_Client"
        FRM_CLIENT_REG.ShowDialog()
    End Sub

    Private Sub FRM_DTR_EXPORTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    End Sub


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
    End Sub

    Private Sub Btn_Export_to_Excell_Click(sender As Object, e As EventArgs) Handles Btn_Export_to_Excell.Click
        Try
            ' Validate that combo boxes are not empty
            If String.IsNullOrWhiteSpace(Cmb_Month.Text) OrElse
           String.IsNullOrWhiteSpace(Cmb_CutOff.Text) OrElse
           String.IsNullOrWhiteSpace(Cmb_Year.Text) Then
                MessageBox.Show("Please select a valid Month, Cut-Off, and Year.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Convert month name to month number
            Dim monthNumber As Integer
            Try
                monthNumber = DateTime.ParseExact(Cmb_Month.Text.Trim.ToUpper, "MMM", CultureInfo.InvariantCulture).Month
            Catch ex As FormatException
                MessageBox.Show("Invalid month format. Please select a valid month.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' Construct the Cut-Off string
            Dim sCut_Off As String = monthNumber & "_" & Mid(Cmb_CutOff.Text, 1, 3) & "_" & Cmb_Year.Text

            ' Validate client details
            If String.IsNullOrWhiteSpace(Lbl_ClientID.Text) OrElse String.IsNullOrWhiteSpace(Lbl_Client_Address.Text) Then
                MessageBox.Show("Client information is missing.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Call export function
            RunWithProcessing("Exporting payroll to Excel...", Sub()
                                                                   Export_DTR_Per_Client_to_Excell(Lbl_Client_Name.Text, Lbl_Client_Address.Text, Lbl_Client_Daily_Wage.Text, sCut_Off)
                                                               End Sub)

        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub FRM_DTR_EXPORTS_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnDtrHrsExport_Click(sender As Object, e As EventArgs) Handles btnDtrHrsExport.Click
        Try
            ' Validate that combo boxes are not empty
            If String.IsNullOrWhiteSpace(Cmb_Month.Text) OrElse
           String.IsNullOrWhiteSpace(Cmb_CutOff.Text) OrElse
           String.IsNullOrWhiteSpace(Cmb_Year.Text) Then
                MessageBox.Show("Please select a valid Month, Cut-Off, and Year.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Convert month name to month number
            Dim monthNumber As Integer
            Try
                monthNumber = DateTime.ParseExact(Cmb_Month.Text.Trim.ToUpper, "MMM", CultureInfo.InvariantCulture).Month
            Catch ex As FormatException
                MessageBox.Show("Invalid month format. Please select a valid month.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' Construct the Cut-Off string
            Dim sCut_Off As String = monthNumber & "_" & Mid(Cmb_CutOff.Text, 1, 3) & "_" & Cmb_Year.Text

            ' Validate client details
            If String.IsNullOrWhiteSpace(Lbl_ClientID.Text) OrElse String.IsNullOrWhiteSpace(Lbl_Client_Address.Text) Then
                MessageBox.Show("Client information is missing.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Call export function
            RunWithProcessing("Exporting DTR hours to Excel...", Sub()
                                                                     Export_DTR_Hours_Per_Client_to_Excell(Lbl_Client_Name.Text, Lbl_Client_Address.Text, sCut_Off)
                                                                 End Sub)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        If Not TryBuildCutoff(cutoff) Then Return

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
