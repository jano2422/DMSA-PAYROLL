Imports System.IO
Public Class FRM_CLIENT_HDR
    Private Sub Btn_New_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LV_Main_Client_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Main_Client_List.SelectedIndexChanged
        Try
            Call Clear_Sub_Client_Info_in_Textboxes() ' To avoid wrong details after selecting sub client and suddenly clicked another Main client
            Call Show_Sub_Client_List(LV_Main_Client_List.SelectedItems(0).SubItems(3).Text) ' Main_Client_ID
            Call Show_Main_Client_Name_and_Status(LV_Main_Client_List.SelectedItems(0).SubItems(3).Text) ' Status

            GlobalVariables.Selected_Sub_Client_ID = "" ' Reset Sub client ID selected
            Lbl_Sub_Client_Name_Contract.Text = ""
            Lbl_Sub_Client_Name_Termination.Text = ""
            Lbl_Sub_Client_ID_Termination.Text = ""

            If LV_Sub_Client_List.Items.Count = 0 Then
                Tab_Client_Info.SelectedIndex = 1
            Else
                Tab_Client_Info.SelectedIndex = 0
            End If

            Btn_Edit_Main_Client.Enabled = True
            Btn_New_Sub_Client.Enabled = True

            Lbl_Sub_Client_Name_Contract.Text = ""

            If Lbl_Main_Client_Status.Text = "Active" Then
                Btn_Activate_Main_Client.Enabled = False
                Btn_Deactivate_Main_Client.Enabled = True
            Else
                Btn_Activate_Main_Client.Enabled = True
                Btn_Deactivate_Main_Client.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FRM_CLIENT_HDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cmb_MainClient_Status.SelectedIndex = 2
    End Sub



    Private Sub Btn_ShowClientList_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_Edit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_Show_Click(sender As Object, e As EventArgs) Handles Btn_Show.Click

        Call Show_Searched_Main_Client(TxtSearch.Text, Cmb_MainClient_Status.Text)

    End Sub

    Private Sub LV_Sub_Client_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Sub_Client_List.SelectedIndexChanged
        Try
            GlobalVariables.Selected_Sub_Client_ID = LV_Sub_Client_List.SelectedItems(0).SubItems(0).Text ' Sub Client ID
            GlobalVariables.Selected_Sub_Client_Name = LV_Sub_Client_List.SelectedItems(0).SubItems(1).Text ' Sub Client Name
            GlobalVariables.Selected_Contract_ID = 0 ' iRef_ID

            Call Show_Sub_Client_Info_in_Textboxes(GlobalVariables.Selected_Sub_Client_ID)
            Call Show_Contract_Attachment(GlobalVariables.Selected_Sub_Client_ID)

            Lbl_Sub_Client_Name_Contract.Text = GlobalVariables.Selected_Sub_Client_Name
            Lbl_Sub_Client_Name_Termination.Text = GlobalVariables.Selected_Sub_Client_Name
            Lbl_Sub_Client_ID_Termination.Text = GlobalVariables.Selected_Sub_Client_ID

            Tab_Client_Info.SelectedIndex = 1
            Btn_Edit_Sub_Client.Enabled = True

            If LV_Sub_Client_List.SelectedItems(0).SubItems(3).Text = "Inactive" Then

                Btn_Deactivate_Sub_Client.Enabled = False
                Btn_Activate_Sub_Client.Enabled = True
            Else
                Btn_Deactivate_Sub_Client.Enabled = True
                Btn_Activate_Sub_Client.Enabled = False

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Btn_NewContract_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub DP_Contract_Start_Date_ValueChanged(sender As Object, e As EventArgs)
        TxtContract_Start_Date.Text = DP_Contract_Start_Date.Value.ToShortDateString

    End Sub

    Private Sub Btn_EditSubClient_Click(sender As Object, e As EventArgs)




    End Sub



    Private Sub Btn_Edit_Main_Client_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Main_Client.Click
        If Btn_Edit_Main_Client.Text = "Edit" Then

            LV_Main_Client_List.Enabled = False
            Btn_New_Main_Client.Enabled = False
            Btn_Edit_Main_Client.Text = "Update"
            Cmb_ClientType.Enabled = True

            Btn_Activate_Main_Client.Visible = True
            Btn_Activate_Main_Client.Text = "Cancel"
            Btn_Activate_Main_Client.Enabled = True
            Btn_Activate_Main_Client.IconChar = FontAwesome.Sharp.IconChar.Cancel
            Btn_Activate_Main_Client.IconColor = Color.Red

        ElseIf Btn_Edit_Main_Client.Text = "Cancel" Then


            LV_Main_Client_List.Enabled = True
            Btn_New_Main_Client.Enabled = True
            Btn_Edit_Main_Client.Text = "Edit"
            Btn_Edit_Main_Client.Enabled = False
            Btn_New_Main_Client.Text = "New"
            Cmb_ClientType.Enabled = False

            Btn_Activate_Main_Client.Visible = False
            Btn_Activate_Main_Client.Text = "Activate"
            Btn_Activate_Main_Client.Enabled = True
            Btn_Activate_Main_Client.IconChar = FontAwesome.Sharp.IconChar.LockOpen
            Btn_Activate_Main_Client.IconColor = Color.Lime


        ElseIf Btn_Edit_Main_Client.Text = "Update" Then

            If Cmb_MainClientName.Text = "" Then
                MsgBox("Invalid Main Client Name!", vbCritical, "Invalid Input")
                Exit Sub
            End If

            Call Update_Main_Client(LV_Main_Client_List.SelectedItems(0).SubItems(3).Text) ' Main_Client_ID
            Call Show_Searched_Main_Client(Cmb_MainClientName.Text, "Active")

            LV_Main_Client_List.Enabled = True
            Btn_New_Main_Client.Enabled = True
            Btn_Edit_Main_Client.Text = "Edit"
            Btn_Edit_Main_Client.Enabled = False
            Cmb_ClientType.Enabled = False

            Btn_Activate_Main_Client.Visible = False
            Btn_Activate_Main_Client.Text = "Activate"
            Btn_Activate_Main_Client.Enabled = True
            Btn_Activate_Main_Client.IconChar = FontAwesome.Sharp.IconChar.LockOpen
            Btn_Activate_Main_Client.IconColor = Color.Lime

        End If
    End Sub

    Private Sub Btn_New_Sub_Client_Click(sender As Object, e As EventArgs) Handles Btn_New_Sub_Client.Click
        If Btn_New_Sub_Client.Text = "New" Then

            Call Clear_Client_Management_Textboxes(Me)

            Dim New_CLient_ID = Generate_New_Client_ID()

            Txt_Sub_Client_ID.Text = New_CLient_ID

            LV_Main_Client_List.Enabled = False
            Btn_ShowClientList.Enabled = True
            Btn_New_Sub_Client.Text = "Save"
            Btn_Edit_Sub_Client.Enabled = True
            Btn_Edit_Sub_Client.Text = "Cancel"

            Btn_Attachment_Upload.Enabled = True

        Else ' SAVE

            ' Controls 
            Try

                If GlobalVariables.Contract_New_File_Destination_Path = "" Then
                    MsgBox("Please attach the Contract from Client.", vbCritical, "Contract")
                    Tab_Info_Deduction.SelectedIndex = 2
                    Exit Sub
                End If


                ' Client ID is automatic upon clicking NEW Button
                Call Insert_New_Sub_Client_Record(Me.Txt_Sub_Client_ID.Text, LV_Main_Client_List.SelectedItems(0).SubItems(3).Text)
                Call Insert_Contract_Information(Me.Txt_Sub_Client_ID.Text) ' Newly generated SUb Client ID
                Call Show_Sub_Client_List(LV_Main_Client_List.SelectedItems(0).SubItems(3).Text)
                Call Show_Contract_Attachment(Me.Txt_Sub_Client_ID.Text) ' Newly generated SUb Client ID

                LV_Main_Client_List.Enabled = True
                Btn_New_Sub_Client.Text = "New"
                Btn_New_Sub_Client.Enabled = True
                Btn_Edit_Sub_Client.Enabled = False
                Btn_Edit_Sub_Client.Text = "Edit"

                Lbl_Attachment_Path.Text = "Path"
                GlobalVariables.Contract_New_File_Destination_Path = ""
                TxtContract_Start_Date.Text = ""
                TxtContract_End_Date.Text = ""

                Btn_Attachment_Upload.Enabled = False
            Catch ex As Exception
                MsgBox(ex.ToString, vbCritical, "Special characters are not allowed.")
            End Try



        End If
    End Sub

    Private Sub Btn_Edit_Sub_Client_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Sub_Client.Click
        If Btn_Edit_Sub_Client.Text = "Edit" Then

            LV_Main_Client_List.Enabled = False
            Btn_New_Main_Client.Enabled = False
            Btn_Edit_Sub_Client.Text = "Update"
            Btn_New_Sub_Client.Enabled = False

            Btn_Activate_Sub_Client.Text = "Cancel"
            Btn_Activate_Sub_Client.Enabled = True
            Btn_Activate_Sub_Client.IconChar = FontAwesome.Sharp.IconChar.Cancel
            Btn_Activate_Sub_Client.IconColor = Color.Red

            Btn_Attachment_Upload.Enabled = True
            Btn_Remove_Contract.Enabled = True

        ElseIf Btn_Edit_Sub_Client.Text = "Cancel" Then

            LV_Main_Client_List.Enabled = True
            Btn_New_Sub_Client.Text = "New"
            Btn_New_Sub_Client.Enabled = True
            Btn_Edit_Sub_Client.Enabled = False
            Btn_Edit_Sub_Client.Text = "Edit"

            Btn_Activate_Sub_Client.Text = "Activate"
            Btn_Activate_Sub_Client.Enabled = False
            Btn_Activate_Sub_Client.IconChar = FontAwesome.Sharp.IconChar.LockOpen
            Btn_Activate_Sub_Client.IconColor = Color.Lime

            Btn_Attachment_Upload.Enabled = False
            Btn_Remove_Contract.Enabled = False
            Lbl_Attachment_Path.Text = "Path"
            GlobalVariables.Contract_New_File_Destination_Path = ""

        ElseIf Btn_Edit_Sub_Client.Text = "Update" Then

            Call UPDATE_SUB_CLIENT_INFO(Me.Txt_Sub_Client_ID.Text) ' Me.LV_Main_Client_List.SelectedItems(0).SubItems(0).Text


            If GlobalVariables.Selected_Contract_ID = 0 Then ' Contract iRef_ID

            Else
                Call Update_Contract_Details(GlobalVariables.Selected_Contract_ID)
            End If





            If Lbl_Attachment_Path.Text = "Path" Then ' No change in attachment
                ' Only Update TBL_Contract details


            Else ' Save new attachment
                Call Insert_Contract_Information(Me.Txt_Sub_Client_ID.Text)
            End If

            Call Show_Contract_Attachment(Me.Txt_Sub_Client_ID.Text)

                Btn_Activate_Sub_Client.Text = "Activate"
                Btn_Activate_Sub_Client.Enabled = False

                LV_Main_Client_List.Enabled = True
                Btn_New_Sub_Client.Text = "New"
                Btn_New_Sub_Client.Enabled = True
                Btn_Edit_Sub_Client.Enabled = False
                Btn_Edit_Sub_Client.Text = "Edit"

                Btn_Activate_Sub_Client.Text = "Activate"
                Btn_Activate_Sub_Client.Enabled = False
                Btn_Activate_Sub_Client.IconChar = FontAwesome.Sharp.IconChar.LockOpen
                Btn_Activate_Sub_Client.IconColor = Color.Lime

                TxtContract_Start_Date.Text = ""
                TxtContract_End_Date.Text = ""
                Txt_Contract_Remarks.Text = ""

                Btn_Attachment_Upload.Enabled = False
                Btn_Remove_Contract.Enabled = False
                Lbl_Attachment_Path.Text = "Path"
                GlobalVariables.Contract_New_File_Destination_Path = ""

            End If
    End Sub

    Private Sub Btn_New_Main_Client_Click(sender As Object, e As EventArgs) Handles Btn_New_Main_Client.Click
        If Btn_New_Main_Client.Text = "New" Then

            LV_Main_Client_List.Enabled = False
            LV_Sub_Client_List.Enabled = False

            Btn_New_Main_Client.Text = "Save"
            Btn_Edit_Main_Client.Text = "Cancel"
            Btn_Edit_Main_Client.Enabled = True

            Cmb_MainClientName.Text = ""
            Cmb_ClientType.SelectedIndex = -1
            Cmb_ClientType.Enabled = True
            Cmb_MainClientName.Select()

        Else

            If Cmb_MainClientName.Text = "" Then
                MsgBox("Invalid Main Client Name!", vbCritical, "Invalid Input")
                Exit Sub
            End If

            If Cmb_ClientType.SelectedIndex = -1 Then
                MsgBox("Please select client type.", vbCritical, "Client Type")
                Exit Sub
            End If

            Call Add_New_Main_Client(Trim(Cmb_MainClientName.Text), Cmb_ClientType.Text)
            Call Show_Searched_Main_Client(Cmb_MainClientName.Text, "Active")

            LV_Main_Client_List.Enabled = True
            LV_Sub_Client_List.Enabled = True
            Btn_Edit_Main_Client.Enabled = False

            Btn_New_Main_Client.Text = "New"
            Btn_Edit_Main_Client.Text = "Edit"
            Cmb_ClientType.Enabled = False

        End If
    End Sub

    Private Sub Btn_Activate_Sub_Client_Click(sender As Object, e As EventArgs) Handles Btn_Activate_Sub_Client.Click
        If Btn_Activate_Sub_Client.Text = "Activate" Then
            Dim sResponse As String

            sResponse = MsgBox("Are you sure you want to Re-Activate this Sub Client?", vbQuestion + vbYesNo, "Re-Activate")
            If sResponse = vbYes Then

                GlobalVariables.sActivate_or_Deactivate = "Activate"
                FRM_CLIENT_DEACTIVATE.ShowDialog()

                If GlobalVariables.sDecision = "OK" Then
                    Call Activate_Deactivate_Sub_Client(GlobalVariables.Selected_Sub_Client_ID, GlobalVariables.Selected_Sub_Client_Name, "Active")
                    GlobalVariables.Selected_Sub_Client_ID = 0
                    GlobalVariables.Selected_Sub_Client_Name = ""

                    ' Refresh table
                    'Call Show_Searched_Main_Client(TxtSearch.Text, Cmb_MainClient_Status.Text)
                    LV_Sub_Client_List.Items.Clear()


                    GlobalVariables.sDecision = ""
                    GlobalVariables.sReason_for_Deactivation_Activation = ""
                Else
                    GlobalVariables.sDecision = ""

                End If
            Else
                ' Nothing
            End If

        ElseIf Btn_Activate_Sub_Client.Text = "Cancel" Then

            Btn_Activate_Sub_Client.Text = "Activate"
            Btn_Activate_Sub_Client.Enabled = False

            LV_Main_Client_List.Enabled = True
            Btn_New_Sub_Client.Text = "New"
            Btn_New_Sub_Client.Enabled = True
            Btn_Edit_Sub_Client.Enabled = False
            Btn_Edit_Sub_Client.Text = "Edit"

            Btn_Activate_Sub_Client.Text = "Activate"
            Btn_Activate_Sub_Client.Enabled = False
            Btn_Activate_Sub_Client.IconChar = FontAwesome.Sharp.IconChar.LockOpen
            Btn_Activate_Sub_Client.IconColor = Color.Lime

        End If
    End Sub

    Private Sub Btn_Activate_Main_Client_Click(sender As Object, e As EventArgs) Handles Btn_Activate_Main_Client.Click
        If Btn_Activate_Main_Client.Text = "Activate" Then
            Dim sResponse As String

            sResponse = MsgBox("Are you sure you want to Re-Activate this Main Client?", vbQuestion + vbYesNo, "Re-Activate")
            If sResponse = vbYes Then

                GlobalVariables.sActivate_or_Deactivate = "Activate"
                FRM_CLIENT_DEACTIVATE.ShowDialog()

                If GlobalVariables.sDecision = "OK" Then
                    Call Activate_Deactivate_Main_Client(LV_Main_Client_List.SelectedItems(0).SubItems(3).Text, LV_Main_Client_List.SelectedItems(0).SubItems(1).Text, "Active") ' To Deactivate set status to Inactive 
                    GlobalVariables.Selected_Sub_Client_ID = 0
                    GlobalVariables.Selected_Sub_Client_Name = ""

                    ' Refresh table
                    Call Show_Searched_Main_Client(TxtSearch.Text, Cmb_MainClient_Status.Text)
                    LV_Sub_Client_List.Items.Clear()


                    GlobalVariables.sDecision = ""
                    GlobalVariables.sReason_for_Deactivation_Activation = ""
                Else
                    GlobalVariables.sDecision = ""

                End If

            Else

            End If
        ElseIf Btn_Activate_Main_Client.Text = "Cancel" Then

            LV_Main_Client_List.Enabled = True
            Btn_New_Main_Client.Enabled = True
            Btn_Edit_Main_Client.Text = "Edit"
            Btn_Edit_Main_Client.Enabled = False
            Cmb_ClientType.Enabled = False

            Btn_Activate_Main_Client.Visible = False
            Btn_Activate_Main_Client.Text = "Activate"
            Btn_Activate_Main_Client.Enabled = True
            Btn_Activate_Main_Client.IconChar = FontAwesome.Sharp.IconChar.LockOpen
            Btn_Activate_Main_Client.IconColor = Color.Lime

        End If
    End Sub



    Private Sub Btn_Attachment_Upload_Click(sender As Object, e As EventArgs) Handles Btn_Attachment_Upload.Click

        If TxtContract_Start_Date.Text = "" Or TxtContract_End_Date.Text = "" Then
            MsgBox("Please provide the Start and End of contract first.", vbCritical, "Contract Date")
            Exit Sub
        End If

        Call Attach_Contract()

    End Sub

    Private Sub DP_Contract_Start_Date_ValueChanged_1(sender As Object, e As EventArgs) Handles DP_Contract_Start_Date.ValueChanged
        TxtContract_Start_Date.Text = DP_Contract_Start_Date.Value.ToShortDateString
    End Sub

    Private Sub DP_Contract_End_Date_ValueChanged(sender As Object, e As EventArgs) Handles DP_Contract_End_Date.ValueChanged
        TxtContract_End_Date.Text = DP_Contract_End_Date.Value.ToShortDateString
    End Sub

    Private Sub Lbl_Attachment_Path_Click(sender As Object, e As EventArgs) Handles Lbl_Attachment_Path.Click

    End Sub

    Private Sub Btn_View_Contract_Click(sender As Object, e As EventArgs) Handles Btn_View_Contract.Click
        If GlobalVariables.Selected_Contract_attachment <> "" Then
            Try
                Process.Start(Application.StartupPath & "\Attachments\Client_Contract\" & LV_Contract_Attachments.SelectedItems(0).SubItems(1).Text)
            Catch ex As Exception
                MsgBox(ex.ToString, vbCritical, "Error openning the attachment, try after saving.")
            End Try
        End If
    End Sub

    Private Sub LV_Contract_Attachments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Contract_Attachments.SelectedIndexChanged



        Try
            GlobalVariables.Selected_Contract_attachment = LV_Contract_Attachments.SelectedItems(0).SubItems(1).Text ' Filename.pdf
            GlobalVariables.Selected_Contract_ID = LV_Contract_Attachments.SelectedItems(0).SubItems(2).Text
            Call Show_Contract_Details_In_Textboxes(GlobalVariables.Selected_Contract_ID) ' iRef_ID

            Btn_Remove_Contract.Enabled = True

        Catch ex As Exception
            GlobalVariables.Selected_Contract_attachment = ""
            Btn_Remove_Contract.Enabled = False
        End Try

    End Sub

    Private Sub Btn_Remove_Contract_Click(sender As Object, e As EventArgs) Handles Btn_Remove_Contract.Click
        If GlobalVariables.Selected_Contract_attachment <> "" Then
            Try

                If File.Exists(Application.StartupPath & "\Attachments\Client_Contract\" & GlobalVariables.Selected_Contract_attachment) Then
                    Dim sResponse As String

                    sResponse = MsgBox("Are you sure you want to delete this attachment?", vbQuestion + vbOKCancel, "Delete")
                    If sResponse = vbOK Then
                        ' Delete the actual file
                        File.Delete(Application.StartupPath & "\Attachments\Client_Contract\" & GlobalVariables.Selected_Contract_attachment) ' Full Path
                        ' Delete Contract record from Contract table 
                        Call Delete_Contract_Record(LV_Contract_Attachments.SelectedItems(0).SubItems(2).Text) ' iRef_ID
                        ' Show updated table
                        Call Show_Contract_Attachment(Me.Txt_Sub_Client_ID.Text)
                    Else

                    End If
                Else

                End If

            Catch ex As Exception
                MsgBox(ex.ToString, vbCritical, "Error Deleting the attachment.")
            End Try
        End If
    End Sub

    Private Sub Btn_Deactivate_Sub_Client_Click(sender As Object, e As EventArgs) Handles Btn_Deactivate_Sub_Client.Click
        Dim sResponse As String

        sResponse = MsgBox("Are you sure you want to Deactivate the Sub Client?", vbQuestion + vbYesNo, "Deactivate")
        If sResponse = vbYes Then

            GlobalVariables.sActivate_or_Deactivate = "Deactivate"
            FRM_CLIENT_DEACTIVATE.ShowDialog()
            If GlobalVariables.sDecision = "OK" Then
                Call Activate_Deactivate_Sub_Client(GlobalVariables.Selected_Sub_Client_ID, GlobalVariables.Selected_Sub_Client_Name, "Inactive") ' To Deactivate set status to Inactive 

                GlobalVariables.Selected_Sub_Client_ID = 0
                GlobalVariables.Selected_Sub_Client_Name = ""

                ' Refresh table
                Call Show_Searched_Main_Client(TxtSearch.Text, Cmb_MainClient_Status.Text)
                LV_Sub_Client_List.Items.Clear()

                GlobalVariables.sDecision = ""
                GlobalVariables.sReason_for_Deactivation_Activation = ""

            Else

                GlobalVariables.sDecision = ""
                GlobalVariables.sReason_for_Deactivation_Activation = ""
            End If

        Else

        End If
    End Sub

    Private Sub Btn_Deactivate_Main_Client_Click(sender As Object, e As EventArgs) Handles Btn_Deactivate_Main_Client.Click
        Dim sResponse As String
        Dim iResponse As Integer

        iResponse = Count_Active_Sub_Client_of_Main_Client(LV_Main_Client_List.SelectedItems(0).SubItems(3).Text)
        If iResponse = 0 Then ' No Active Sub Clients

            sResponse = MsgBox("Are you sure you want to Deactivate the Main Client? ", vbQuestion + vbYesNo, "Deactivate " & LV_Main_Client_List.SelectedItems(0).SubItems(1).Text & "")
            If sResponse = vbYes Then

                GlobalVariables.sActivate_or_Deactivate = "Deactivate"
                FRM_CLIENT_DEACTIVATE.ShowDialog()
                If GlobalVariables.sDecision = "OK" Then

                    Call Activate_Deactivate_Main_Client(LV_Main_Client_List.SelectedItems(0).SubItems(3).Text, LV_Main_Client_List.SelectedItems(0).SubItems(1).Text, "Inactive")
                    Call Show_Searched_Main_Client(TxtSearch.Text, Cmb_MainClient_Status.Text)
                    LV_Sub_Client_List.Items.Clear()


                    GlobalVariables.sDecision = ""
                    GlobalVariables.sReason_for_Deactivation_Activation = ""

                    GlobalVariables.sDecision = ""
                    GlobalVariables.sReason_for_Deactivation_Activation = ""
                End If

            Else

            End If
        Else
            MsgBox ("Can not Deactivate this Main Client because there are still active sub clients on it!", vbExclamation, "Not Allowed" )
        End If


    End Sub
End Class