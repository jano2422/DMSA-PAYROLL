Public Class FRM_CLIENT_REG
    Private Sub FRM_EMP_REG_CLIENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Select Case GlobalVariables.Client_Event

            Case "Application"
                Call Show_Client_Selection("")

            Case "Employee_Record_Update"
                Call Show_Client_Selection("")

            Case "Payslip_Per_Client"
                Call Show_Client_Selection("Pure")


        End Select
    End Sub

    Private Sub LV_Main_Client_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Main_Client_List.SelectedIndexChanged


        Select Case GlobalVariables.Client_Event

            Case "Employee_Record_Update"

                FRM_EMP_UPDATE_REC.Txt_ClientID.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(0).Text
                FRM_EMP_UPDATE_REC.Lbl_ClientName.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(0).Text & "-" & Me.LV_Main_Client_List.SelectedItems(0).SubItems(1).Text
                FRM_EMP_UPDATE_REC.LblClient_Address.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(2).Text

            Case "Application"
                FRM_HRIS_APPLICATION.Txt_ClientID.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(0).Text
                FRM_HRIS_APPLICATION.Lbl_ClientName.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(1).Text

            'Case "DTR_1_to_15"
            '    FRM_DTR_REPORT.Txt_ClientName.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(1).Text
            '    GlobalVariables.Selected_Sub_Client_ID = Me.LV_Main_Client_List.SelectedItems(0).SubItems(0).Text
            'Case "DTR_16_to_30"

            Case "Payslip_Per_Client"
                FRM_DTR_EXPORTS.Lbl_ClientID.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(0).Text
                FRM_DTR_EXPORTS.Lbl_Client_Name.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(1).Text
                FRM_DTR_EXPORTS.Lbl_Client_Address.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(2).Text
                FRM_DTR_EXPORTS.Lbl_Client_Daily_Wage.Text = Me.LV_Main_Client_List.SelectedItems(0).SubItems(3).Text
        End Select


        Me.Close()


    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click

        If Me.Cmb_Category.SelectedIndex = -1 Then
            Call Search_Client("address", Me.TxtSearch.Text) ' any field just to avoid null value
        Else
            Call Search_Client(Me.Cmb_Category.Text, Me.TxtSearch.Text)
        End If

    End Sub
End Class