Public Class FRM_CLIENT_DEACTIVATE


    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        GlobalVariables.dClient_Deactivation_Date = Txt_Date.Text
        GlobalVariables.sReason_for_Deactivation_Activation = Cmb_Reason.Text
        GlobalVariables.sDecision = "OK"

        Me.Close()
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        GlobalVariables.sDecision = "Cancelled"
        Me.Close()
    End Sub

    Private Sub FRM_CLIENT_DEACTIVATE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt_Date.Text = ""
        Cmb_Reason.SelectedIndex = -1

        Cmb_Reason.Items.Clear()

        If GlobalVariables.sActivate_or_Deactivate = "Deactivate" Then
            Cmb_Reason.Items.Add("Finished Contract")
            Cmb_Reason.Items.Add("Terminated")

        ElseIf GlobalVariables.sActivate_or_Deactivate = "Activate" Then

            Cmb_Reason.Items.Add("Renewal of Contract")
            Cmb_Reason.Items.Add("Reactivation")
        End If

    End Sub

    Private Sub DP_Date_ValueChanged(sender As Object, e As EventArgs) Handles DP_Date.ValueChanged
        Txt_Date.Text = DP_Date.Value.ToShortDateString
    End Sub
End Class