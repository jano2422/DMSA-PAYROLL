Public Class FRM_USER_CREATOR
    Private Sub Btn_Create_Click(sender As Object, e As EventArgs) Handles Btn_Create.Click
        If Btn_Create.Text = "Create" Then
            Btn_Cancel.Visible = True

            Select Case GlobalVariables.sUser_Level

                Case "User"
                    Cmb_UserLevel.Enabled = False
                    Cmb_UserLevel.SelectedIndex = 0
                Case "Administrator"
                    Cmb_UserLevel.Enabled = True

            End Select


        Else
            If TxtName.Text = "" Or Txt_Employee_ID.Text = "" Or Cmb_UserLevel.SelectedIndex = -1 Then
                MsgBox("Please complete all text boxes.", vbCritical, "Can not leave empty")
                Exit Sub
            End If

            Call Insert_new_User(TxtName.Text, "welcome", Cmb_UserLevel.Text)

            Btn_Cancel.Visible = False
        End If




    End Sub

    Private Sub FRM_USER_CREATOR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cmb_UserLevel.SelectedIndex = -1
    End Sub
End Class