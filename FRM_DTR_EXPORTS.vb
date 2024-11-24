Imports System.Globalization
Public Class FRM_DTR_EXPORTS
    Private Sub Btn_Client_Click(sender As Object, e As EventArgs) Handles Btn_Client.Click
        GlobalVariables.Client_Event = "Payslip_Per_Client"
        FRM_CLIENT_REG.ShowDialog()
    End Sub

    Private Sub Btn_Show_Click(sender As Object, e As EventArgs) Handles Btn_Show.Click

        ' Format Cut-off, Month and Year ( e.g 3_1st_2024 )

        Dim sCut_Off As String
        Dim monthNumber As Integer = DateTime.ParseExact(Cmb_Month.Text.Trim.ToUpper, "MMM", CultureInfo.InvariantCulture).Month
        sCut_Off = monthNumber & "_" & Mid(Cmb_CutOff.Text, 1, 3) & "_" & Cmb_Year.Text


        If Lbl_ClientID.Text = "" Then
            MsgBox("Please select a client first!", vbExclamation, "Client ID")
            Exit Sub
        End If

        Call Get_DTR_Per_Client(CInt(Lbl_ClientID.Text), sCut_Off)

    End Sub

    Private Sub Btn_Export_to_Excell_Click(sender As Object, e As EventArgs) Handles Btn_Export_to_Excell.Click

        Dim sCut_Off As String
        Dim monthNumber As Integer = DateTime.ParseExact(Cmb_Month.Text.Trim.ToUpper, "MMM", CultureInfo.InvariantCulture).Month
        sCut_Off = monthNumber & "_" & Mid(Cmb_CutOff.Text, 1, 3) & "_" & Cmb_Year.Text

        Call Export_DTR_Per_Client_to_Excell(Lbl_ClientID.Text, Lbl_Client_Address.Text, sCut_Off)
    End Sub
End Class