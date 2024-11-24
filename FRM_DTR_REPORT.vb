Public Class FRM_DTR_REPORT
    Private Sub Btn_ExportToExcel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FRM_DTR_REPORT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For i = 2023 To Date.Now.Year()
            Cmb_Year.Items.Add(i)
        Next i

        Cmb_Year.SelectedIndex = 0
        Cmb_Month.SelectedIndex = 5 ' remove later
        Cmb_CutOff.SelectedIndex = 0 ' remove later

    End Sub

    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
        Dim sPeriod As String

        If Me.Cmb_CutOff.SelectedIndex = 0 Then
            sPeriod = Me.Cmb_Month.Text & " 1-15"
        Else
            sPeriod = Me.Cmb_Month.Text & " 16-30"
        End If

        Show_Report_per_Client_in_LV(Me.Cmb_Year.Text, sPeriod, GlobalVariables.Selected_Sub_Client_ID)


    End Sub

    Private Sub Btn_ExportToExcel_Click_1(sender As Object, e As EventArgs) Handles Btn_ExportToExcel.Click
        Dim sPeriod As String

        If Me.Cmb_CutOff.SelectedIndex = 0 Then
            sPeriod = Me.Cmb_Month.Text & " 1-15"
        Else
            sPeriod = Me.Cmb_Month.Text & " 16-30"
        End If

        Call Write_To_Excel_Report(Me.Txt_ClientName.Text, Me.Lbl_Client_Address.Text, sPeriod)

    End Sub

    Private Sub Cmb_ClientList_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_ShowClientList_Click(sender As Object, e As EventArgs) Handles Btn_ShowClientList.Click
        GlobalVariables.Client_Event = "DTR_1_to_15"
        FRM_CLIENT_REG.ShowDialog()
    End Sub

    Private Sub LV_EmployeeList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_EmployeeList.SelectedIndexChanged

    End Sub
End Class