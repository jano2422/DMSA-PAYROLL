Imports System.Globalization
Public Class FRM_DTR_EXPORTS
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
        For i As Integer = currentYear - 10 To currentYear + 10
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
            Export_DTR_Per_Client_to_Excell(Lbl_ClientID.Text, Lbl_Client_Address.Text, sCut_Off)

        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub FRM_DTR_EXPORTS_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class