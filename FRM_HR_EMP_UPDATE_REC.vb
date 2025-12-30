Public Class FRM_EMP_UPDATE_REC


    Private Sub FRM_EMP_UPDATE_REC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With FRM_EMP_REG

            Try
                GlobalVariables.Photo_Path_from_DB = Show_Photo_in_Employee_Rec(GlobalVariables.Selected_Employee_ID)
                If GlobalVariables.Photo_Path_from_DB = "0" Then
                    Me.Pic_Employee_Photo.Image = My.Resources.DMSA_Logo
                Else ' with Path from DB
                    Me.Pic_Employee_Photo.Image = Image.FromFile(GlobalVariables.Photo_Path_from_DB)
                End If
            Catch ex As Exception
                Me.Pic_Employee_Photo.Image = My.Resources.DMSA_Logo
            End Try

            Panel3.Size = New Size(845, 131)

            Me.Lbl_Employee_ID.Text = .LV_Employee_List.SelectedItems(0).SubItems(1).Text
            Me.Lbl_Employee_Name.Text = .LV_Employee_List.SelectedItems(0).SubItems(2).Text
            Try
                Call Show_Leave_File_Records(Me.Lbl_Employee_ID.Text)
                Call Show_License_Record_to_ListView(Me.Lbl_Employee_ID.Text)
                Call Show_Employee_Client_History_at_Client_Change(Me.Lbl_Employee_ID.Text)
                Call Show_Medical_Record_to_Listview(Me.Lbl_Employee_ID.Text)
                Call Show_Insurance_Record_To_Listview(Me.Lbl_Employee_ID.Text)
                Call Show_Status_Change_History(Me.Lbl_Employee_ID.Text)
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error showing details")

            End Try


            ' Reset Refernce IDs
            GlobalVariables.sInsurance_Reference_ID = ""
            GlobalVariables.sLeave_Reference_ID = ""
            GlobalVariables.sLicense_Reference_ID = ""
            Me.Lbl_Client_Ref_ID.Text = "" ' Open Task: convert to global variable
            Me.Lbl_Medical_Ref_ID.Text = "" ' Open Task: convert to global variable

            Call Clear_Medical_Record_Textboxes()
            Call Clear_Insurance_Textboxes()
            Call Clear_Leave_Filing_Boxes()
            Call Clear_License_Textboxes()
            Call Clear_Client_Textboxes()

        End With
    End Sub



    Private Sub DP_License_Expiry_ValueChanged(sender As Object, e As EventArgs)
        If DP_License_Expiry.Value <= Date.Now Then
            MsgBox("License is already expired.", vbCritical, "Invalid License Expiry Date")
            Exit Sub
        End If

        Txt_License_Expiry.Text = DP_License_Expiry.Value.ToShortDateString
    End Sub



    Private Sub DP_Sepa_day_ValueChanged(sender As Object, e As EventArgs) Handles DP_Sepa_day.ValueChanged
        Txt_StatusChange_Date.Text = DP_Sepa_day.Value.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub Btn_Leave_New_Click(sender As Object, e As EventArgs) Handles Btn_Leave_New.Click
        If Btn_Leave_New.Text = "New" Then

            Btn_Leave_New.Text = "Save"
            Btn_Leave_Delete.Text = "Cancel"
            Btn_Leave_Edit.Enabled = False
            Btn_Leave_Delete.Enabled = True
            Grp_Leave_Info.Enabled = True
            Call Clear_Leave_Filing_Boxes()


        Else

            'Controls
            If Me.DP_Leave_To.Value < Me.DP_Leave_From.Value Then
                MsgBox("Invalid Dates. TO can not be later than FROM.", vbExclamation, "Error in Dates")
                Exit Sub
            End If


            Call Insert_Leave_filing(Me.Lbl_Employee_ID.Text)
            Call Clear_Leave_Filing_Boxes()
            Call Show_Leave_File_Records(Me.Lbl_Employee_ID.Text)

            Btn_Leave_New.Text = "New"
            Btn_Leave_Delete.Text = "Delete"
            Btn_Leave_Edit.Enabled = False ' Cick new record first before enabling
            Btn_Leave_Delete.Enabled = False
            Grp_Leave_Info.Enabled = False
        End If


    End Sub

    Private Sub Btn_Leave_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Leave_Edit.Click
        If Btn_Leave_Edit.Text = "Edit" Then

            Btn_Leave_Edit.Text = "Update"
            Btn_Leave_Delete.Text = "Cancel"
            Btn_Leave_New.Enabled = False
            Btn_Leave_Delete.Enabled = True
            Grp_Leave_Info.Enabled = True


        Else
            Call Update_Leave_Record(Me.Lbl_Employee_ID.Text, GlobalVariables.sLeave_Reference_ID)
            Call Show_Leave_File_Records(Me.Lbl_Employee_ID.Text)

            Btn_Leave_Edit.Text = "Edit"
            Btn_Leave_Delete.Text = "Delete"
            Btn_Leave_New.Enabled = True
            Btn_Leave_Delete.Enabled = False
            Grp_Leave_Info.Enabled = False
            Call Clear_Leave_Filing_Boxes()

        End If
    End Sub

    Private Sub Btn_Leave_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Leave_Delete.Click
        If Btn_Leave_Delete.Text = "Delete" Then

            Dim sResponse As String
            sResponse = MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo, "Delete?")

            If sResponse = vbYes Then
                Call Delete_Leave_Record(Me.Lbl_Employee_ID.Text, GlobalVariables.sLeave_Reference_ID)
                Call Show_Leave_File_Records(Me.Lbl_Employee_ID.Text)

            Else


            End If

            Call Clear_Leave_Filing_Boxes()

        Else ' Cancel



            Btn_Leave_New.Text = "New"
            Btn_Leave_Edit.Text = "Edit"
            Btn_Leave_Delete.Text = "Delete"
            Btn_Leave_New.Enabled = True
            Btn_Leave_Delete.Enabled = False
            Btn_Leave_Edit.Enabled = False
            Grp_Leave_Info.Enabled = False

        End If

    End Sub





    Private Sub DP_Leave_From_ValueChanged(sender As Object, e As EventArgs) Handles DP_Leave_From.ValueChanged
        Txt_Leave_DateFrom.Text = DP_Leave_From.Value.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub DP_Leave_To_ValueChanged_1(sender As Object, e As EventArgs) Handles DP_Leave_To.ValueChanged
        Txt_Leave_DateTo.Text = DP_Leave_To.Value.ToString("dd-MMM-yyyy")
    End Sub


    Private Sub Cmb_LeaveType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_LeaveType.SelectedIndexChanged
        Cmb_Leave_Status.SelectedIndex = 0
        If Me.Cmb_LeaveType.Text = "Suspension" Then
            Me.Cmb_Notification.SelectedIndex = 4
        End If

    End Sub

    Private Sub LV_Leave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Leave.SelectedIndexChanged

        Try
            If Me.LV_Leave.SelectedItems(0).SubItems(1).Text <> "" Then
                GlobalVariables.sLeave_Reference_ID = Me.LV_Leave.SelectedItems(0).SubItems(5).Text ' Hidden ID , I need this as unique record from Leave DB
                Call Show_Leave_Records_To_Textboxes(Me.Lbl_Employee_ID.Text, GlobalVariables.sLeave_Reference_ID)
                Btn_Leave_New.Enabled = True
                Btn_Leave_Edit.Enabled = True
                Btn_Leave_Delete.Enabled = True
            Else
                Btn_Leave_New.Enabled = True
                Btn_Leave_Edit.Enabled = False
                Btn_Leave_Delete.Enabled = False
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Btn_License_NEW_Click(sender As Object, e As EventArgs) Handles Btn_License_NEW.Click
        If Btn_License_NEW.Text = "New" Then


            Btn_License_NEW.Text = "Save"
            Btn_License_Delete.Text = "Cancel"
            Btn_License_Edit.Enabled = False
            Btn_License_Delete.Enabled = True
            Grp_License.Enabled = True

            Call Clear_License_Textboxes()
            Txt_License_Number.Focus()

        Else

            If Me.Txt_License_Number.Text = "" Then
                MsgBox("Please enter License Number.", vbCritical, "Empty")
                Exit Sub
            End If

            Call Insert_new_License_Record(Me.Lbl_Employee_ID.Text)
            Call Show_License_Record_to_ListView(Me.Lbl_Employee_ID.Text)

            Btn_License_NEW.Text = "New"
            Btn_License_Delete.Text = "Delete"
            Btn_License_Edit.Enabled = False ' Cick new record first before enabling
            Btn_License_Delete.Enabled = False
            Grp_License.Enabled = False

            Call Show_License_Record_to_ListView(Me.Lbl_Employee_ID.Text)
        End If
    End Sub

    Private Sub Btn_License_Delete_Click(sender As Object, e As EventArgs) Handles Btn_License_Delete.Click
        If Btn_License_Delete.Text = "Delete" Then

            Dim sResponse As String
            sResponse = MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo, "Delete?")

            If sResponse = vbYes Then
                Call Delete_License_record(Me.Lbl_Employee_ID.Text, GlobalVariables.sLicense_Reference_ID)
                Call Clear_License_Textboxes()
                Call Show_License_Record_to_ListView(Me.Lbl_Employee_ID.Text)
                ' Open Task: Should we also delete the attachment file?
            Else


            End If



        Else ' Cancel



            Btn_License_NEW.Text = "New"
            Btn_License_Edit.Text = "Edit"
            Btn_License_Delete.Text = "Delete"
            Btn_License_NEW.Enabled = True
            Btn_License_Delete.Enabled = False
            Btn_License_Edit.Enabled = False
            Grp_License.Enabled = False

        End If

    End Sub

    Private Sub Btn_License_Edit_Click(sender As Object, e As EventArgs) Handles Btn_License_Edit.Click
        If Btn_License_Edit.Text = "Edit" Then

            Btn_License_Edit.Text = "Update"
            Btn_License_Delete.Text = "Cancel"
            Btn_License_NEW.Enabled = False
            Btn_License_Delete.Enabled = True
            Grp_License.Enabled = True


        Else

            If GlobalVariables.Photo_Source_Path = "" Then ' This is because the user did not open the dialogue box, therefor Source Path is empty
                GlobalVariables.Photo_Source_Path = Me.Txt_License_Attachment.Text ' I used the same source as the attached file in Server
                Exit Sub
            End If

            If Me.Txt_License_Number.Text = "" Then
                MsgBox("Can not leave License Number empty.", vbCritical, "Invalid License")
                Exit Sub
            End If

            If Me.Txt_License_Expiry.Text = "" Then
                MsgBox("Invalid License Expiration Date", vbCritical, "Invalid Date")
                Exit Sub
            End If

            Call Update_License_Record(Me.Lbl_Employee_ID.Text, GlobalVariables.sLicense_Reference_ID)

            Try
                'Copy the PDF file to Destination Path
                My.Computer.FileSystem.CopyFile(GlobalVariables.sSource_Path, GlobalVariables.sDestination_Path)
            Catch ex As Exception

            End Try


            Call Show_License_Record_to_ListView(Me.Lbl_Employee_ID.Text)

            Btn_License_Edit.Text = "Edit"
            Btn_License_Delete.Text = "Delete"
            Btn_License_NEW.Enabled = True
            Btn_License_Delete.Enabled = False
            Grp_License.Enabled = False


        End If
    End Sub

    Private Sub LV_License_Record_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_License_Record.SelectedIndexChanged
        Try
            If Me.LV_License_Record.SelectedItems(0).SubItems(1).Text <> "" Then
                GlobalVariables.sLicense_Reference_ID = Me.LV_License_Record.SelectedItems(0).SubItems(4).Text ' Hidden ID , I need this as unique record from Leave DB
                Call Show_License_recod_To_Texboxes(Me.Lbl_Employee_ID.Text, GlobalVariables.sLicense_Reference_ID)
                Btn_License_NEW.Enabled = True
                Btn_License_Edit.Enabled = True
                Btn_License_Delete.Enabled = True
                Grp_License.Enabled = False
            Else
                Btn_License_NEW.Enabled = True
                Btn_License_Edit.Enabled = False
                Btn_License_Delete.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DP_License_Expiry_ValueChanged_1(sender As Object, e As EventArgs) Handles DP_License_Expiry.ValueChanged
        Me.Txt_License_Expiry.Text = DP_License_Expiry.Value.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub Btn_License_AttachFile_Click(sender As Object, e As EventArgs) Handles Btn_License_AttachFile.Click
        Call Attach_Scanned_License_ID()
    End Sub



    Private Sub Btn_ShowClientList_Click(sender As Object, e As EventArgs) Handles Btn_ShowClientList.Click
        GlobalVariables.Client_Event = "Employee_Record_Update"
        FRM_CLIENT_REG.ShowDialog()
    End Sub


    Private Sub DP_Client_Start_Date_ValueChanged(sender As Object, e As EventArgs) Handles DP_Client_Start_Date.ValueChanged
        Txt_Client_Start_Date.Text = DP_Client_Start_Date.Value.ToString("dd-MMM-yyyy")
        Txt_Client_End_Date.Text = DP_Client_Start_Date.Value.ToString("dd-MMM-yyyy") ' Default same value to activate "Up to Present"
    End Sub

    Private Sub LV_Client_History_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Client_History.SelectedIndexChanged
        Try
            Me.Txt_ClientID.Text = Me.LV_Client_History.SelectedItems(0).SubItems(0).Text
            Me.Txt_selected_Client_ID.Text = Me.LV_Client_History.SelectedItems(0).SubItems(0).Text ' redundancy to confirm change in client ID

            Me.Lbl_ClientName.Text = Me.LV_Client_History.SelectedItems(0).SubItems(0).Text & "-" & Me.LV_Client_History.SelectedItems(0).SubItems(1).Text
            Me.LblClient_Address.Text = Me.LV_Client_History.SelectedItems(0).SubItems(2).Text
            Me.Txt_Client_Start_Date.Text = Me.LV_Client_History.SelectedItems(0).SubItems(3).Text
            Me.Txt_Client_End_Date.Text = Me.LV_Client_History.SelectedItems(0).SubItems(4).Text
            Me.Lbl_Client_Ref_ID.Text = Me.LV_Client_History.SelectedItems(0).SubItems(5).Text

            ' Get the Latest Ref_ID for the update - Selected Row should not be the base update for Up to Present
            'Me.Lbl_Latest_Client_ID.Text = Get_Latest_Client_Assignment(Me.Lbl_Employee_ID.Text)


            If Me.Txt_Client_End_Date.Text = "Up to date" Then
                Me.Chk_UptoPresent.Checked = True
            Else
                Me.Chk_UptoPresent.Checked = True
            End If

            If Txt_ClientID.Text <> "" Then
                Btn_Client_Change.Enabled = True
                Btn_Client_Delete.Enabled = True
                Btn_Client_Add.Enabled = True
                Btn_Client_Edit.Enabled = True
            Else
                Btn_Client_Change.Enabled = False
                Btn_Client_Delete.Enabled = False
            End If
        Catch ex As Exception

        End Try





    End Sub



    Private Sub Btn_Medical_New_Click(sender As Object, e As EventArgs) Handles Btn_Medical_New.Click
        If Btn_Medical_New.Text = "New" Then

            Btn_Medical_New.Text = "Save"
            Btn_Medical_Delete.Text = "Cancel"
            Btn_Medical_Edit.Enabled = False
            Btn_Medical_Delete.Enabled = True
            Grp_Medical_Info.Enabled = True
            Call Clear_Medical_Record_Textboxes()


        Else ' Saving

            If Chk_Medical_Findings.Checked = True Then
                If Txt_Medical_Remarks.Text = "" Then
                    MsgBox("Please provide the findings from the medical results!", vbCritical, "Medical Findings")
                    Txt_Medical_Remarks.Focus()
                    Exit Sub

                End If
            Else

            End If

            Call Insert_New_Medical_Record(Me.Lbl_Employee_ID.Text)
            Call Clear_Medical_Record_Textboxes()
            Call Show_Medical_Record_to_Listview(Me.Lbl_Employee_ID.Text)

            Btn_Medical_New.Text = "New"
            Btn_Medical_Delete.Text = "Delete"
            Btn_Medical_Edit.Enabled = False ' Cick new record first before enabling
            Btn_Medical_Delete.Enabled = False
            Grp_Medical_Info.Enabled = False
        End If
    End Sub

    Private Sub Btn_Medical_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Medical_Edit.Click

        If Me.Lbl_Medical_Ref_ID.Text = "Ref_ID" Then ' default value instead of null
            Exit Sub
        End If

        If Btn_Medical_Edit.Text = "Edit" Then

            Btn_Medical_Edit.Text = "Update"
            Btn_Medical_Delete.Text = "Cancel"
            Btn_Medical_New.Enabled = False
            Btn_Medical_Delete.Enabled = True
            Grp_Medical_Info.Enabled = True


        Else

            Call Update_Medical_Record(Me.Lbl_Medical_Ref_ID.Text)
            Call Show_Medical_Record_to_Listview(Me.Lbl_Employee_ID.Text)

            Btn_Medical_Edit.Text = "Edit"
            Btn_Medical_Delete.Text = "Delete"
            Btn_Medical_New.Enabled = True
            Btn_Medical_Delete.Enabled = False
            Grp_Medical_Info.Enabled = False


        End If
    End Sub

    Private Sub Btn_Medical_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Medical_Delete.Click
        If Btn_Medical_Delete.Text = "Delete" Then

            Dim sResponse As String
            sResponse = MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo, "Delete?")

            If sResponse = vbYes Then
                Call Delete_Medical_Record(Me.Lbl_Medical_Ref_ID.Text)
                Call Clear_Medical_Record_Textboxes()
                Call Show_Medical_Record_to_Listview(Me.Lbl_Employee_ID.Text)
            Else


            End If

        Else ' Cancel


            Btn_Medical_New.Text = "New"
            Btn_Medical_Edit.Text = "Edit"
            Btn_Medical_Delete.Text = "Delete"
            Btn_Medical_New.Enabled = True
            Btn_Medical_Delete.Enabled = False
            Btn_Medical_Edit.Enabled = False
            Grp_Medical_Info.Enabled = False

        End If
    End Sub

    Private Sub LV_Medical_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Medical_List.SelectedIndexChanged



        Try

            If Me.LV_Medical_List.SelectedItems(0).SubItems(4).Text <> "" Then
                Btn_Medical_Delete.Enabled = True
                Btn_Medical_Edit.Enabled = True

                Lbl_Medical_Ref_ID.Text = Me.LV_Medical_List.SelectedItems(0).SubItems(4).Text
                Call Show_Medical_recod_To_Texboxes(Me.Lbl_Employee_ID.Text, Me.Lbl_Medical_Ref_ID.Text)
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub DP_Medical_Date_ValueChanged(sender As Object, e As EventArgs) Handles DP_Medical_Date.ValueChanged
        Txt_Medical_Date.Text = DP_Medical_Date.Value.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub Btn_Insurance_New_Click(sender As Object, e As EventArgs) Handles Btn_Insurance_New.Click
        If Btn_Insurance_New.Text = "New" Then

            Btn_Insurance_New.Text = "Save"
            Btn_Insurance_Delete.Text = "Cancel"
            Btn_Insurance_Edit.Enabled = False
            Btn_Insurance_Delete.Enabled = True
            Grp_Insurance_Info.Enabled = True
            Call Clear_Insurance_Textboxes()


        Else

            Call Insert_New_Insurance_Record(Me.Lbl_Employee_ID.Text)
            Call Show_Insurance_Record_To_Listview(Me.Lbl_Employee_ID.Text)
            Call Clear_Insurance_Textboxes()

            Btn_Insurance_New.Text = "New"
            Btn_Insurance_Delete.Text = "Delete"
            Btn_Insurance_Edit.Enabled = False ' Cick new record first before enabling
            Btn_Insurance_Delete.Enabled = False
            Grp_Insurance_Info.Enabled = False
        End If
    End Sub

    Private Sub Btn_Insurance_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Insurance_Edit.Click

        If GlobalVariables.sInsurance_Reference_ID = "" Then ' No record selected yet from the Listview
            Exit Sub
        End If

        If Btn_Insurance_Edit.Text = "Edit" Then

            Btn_Insurance_Edit.Text = "Update"
            Btn_Insurance_Delete.Text = "Cancel"
            Btn_Insurance_New.Enabled = False
            Btn_Insurance_Delete.Enabled = True
            Grp_Insurance_Info.Enabled = True


        Else

            Call Update_Employee_Insurance_Record(Me.Lbl_Employee_ID.Text, GlobalVariables.sInsurance_Reference_ID)
            Call Show_Insurance_Record_To_Listview(Me.Lbl_Employee_ID.Text)

            Btn_Insurance_Edit.Text = "Edit"
            Btn_Insurance_Delete.Text = "Delete"
            Btn_Insurance_New.Enabled = True
            Btn_Insurance_Delete.Enabled = False
            Btn_Insurance_Edit.Enabled = False
            Grp_Insurance_Info.Enabled = False



        End If
    End Sub

    Private Sub Btn_Insurance_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Insurance_Delete.Click
        If Btn_Insurance_Delete.Text = "Delete" Then

            Dim sResponse As String
            sResponse = MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo, "Delete?")

            If sResponse = vbYes Then
                Call Delete_Employee_Insurance_record(GlobalVariables.sInsurance_Reference_ID)
                Call Clear_Insurance_Textboxes()
                Call Show_Insurance_Record_To_Listview(Me.Lbl_Employee_ID.Text)
                GlobalVariables.sInsurance_Reference_ID = ""
            Else


            End If

        Else ' Cancel


            Btn_Insurance_New.Text = "New"
            Btn_Insurance_Edit.Text = "Edit"
            Btn_Insurance_Delete.Text = "Delete"
            Btn_Insurance_New.Enabled = True
            Btn_Insurance_Delete.Enabled = False
            Btn_Insurance_Edit.Enabled = False
            Grp_Insurance_Info.Enabled = False

        End If
    End Sub

    Private Sub LV_Insurance_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Insurance_List.SelectedIndexChanged
        Try
            If Me.LV_Insurance_List.SelectedItems(0).SubItems(1).Text <> "" Then
                Btn_Insurance_Delete.Enabled = True
                Btn_Insurance_Edit.Enabled = True
                GlobalVariables.sInsurance_Reference_ID = Me.LV_Insurance_List.SelectedItems(0).SubItems(5).Text ' ID in DB
                Call Show_Insurance_recod_To_Texboxes(Me.Lbl_Employee_ID.Text, GlobalVariables.sInsurance_Reference_ID)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DP_Insurance_DateStart_ValueChanged(sender As Object, e As EventArgs) Handles DP_Insurance_DateStart.ValueChanged
        Txt_Insurance_DateStart.Text = DP_Insurance_DateStart.Value.ToString("dd-MMM-yyyy")

    End Sub

    Private Sub DP_Insurance_DateEnd_ValueChanged(sender As Object, e As EventArgs) Handles DP_Insurance_DateEnd.ValueChanged
        Txt_Insurance_DateEnd.Text = DP_Insurance_DateEnd.Value.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub DP_Medical_Exp_Date_ValueChanged(sender As Object, e As EventArgs) Handles DP_Medical_Exp_Date.ValueChanged
        Txt_Medical_Exp_Date.Text = DP_Medical_Exp_Date.Value.ToString("dd-MMM-yyyy")

    End Sub

    Private Sub Btn_Client_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Client_Delete.Click
        If Btn_Client_Delete.Text = "Delete" Then

            MsgBox("Only Administrator can delete records.", vbExclamation, "Delete not allowed")
            Exit Sub

            Dim sResponse As String
            sResponse = MsgBox("Are you sure you want to delete this record?", vbQuestion + vbYesNo, "Delete?")
            If sResponse = vbYes Then
                Call Delete_Client_History(Me.Lbl_Client_Ref_ID.Text)
                Call Show_Employee_Client_History_at_Client_Change(Me.Lbl_Employee_ID.Text)
                Call Clear_Client_Textboxes()
            Else

            End If

            ' System bug --> What if an old record was selected and then changed the Client ID, it will treat like the Client was changed and will accept the change.
            ' Need to get the latest Client and then compare it with the selected Client ID.

        Else ' Cancel
            Btn_Client_Delete.Text = "Delete"
            Btn_Client_Delete.Enabled = False
            Btn_Client_Change.Text = "Change Assignment"
            Grp_Client_Info.Enabled = False
            Btn_ShowClientList.Enabled = True
            Btn_Client_Edit.Text = "Edit"
            Btn_Client_Edit.Enabled = False
            Btn_Client_Add.Text = "Add"
            Btn_Client_Add.Enabled = True

            Call Clear_Client_Textboxes()

        End If
    End Sub

    Private Sub Btn_Client_Change_Click(sender As Object, e As EventArgs) Handles Btn_Client_Change.Click
        'If Txt_Client_Start_Date.Text = "" Then
        '    MsgBox("Please input the date to start on the new Client", vbInformation, "Date Start")
        '    Exit Sub
        'End If



        'If Btn_Client_Change.Text = "Change Assignment" Then

        '    Dim sResponse As String
        '    sResponse = MsgBox("This is going to change the client assignment of this employee. " & vbCrLf & " " & vbCrLf & "Are you sure you want to proceed? ", vbQuestion + vbYesNo, "Change Client Assigment")
        '    If sResponse = vbNo Then
        '        Exit Sub
        '    Else
        '        MsgBox("Please select a new Client.", vbInformation, "New Client")
        '    End If

        '    Btn_ShowClientList.Enabled = True
        '    Txt_ClientID.Text = ""
        '    Txt_Client_Start_Date.Text = ""
        '    Txt_Client_End_Date.Text = ""
        '    Me.Chk_UptoPresent.Checked = True
        '    Grp_Client_Info.Enabled = True
        '    Btn_Client_Delete.Text = "Cancel"
        '    Btn_Client_Delete.Enabled = True
        '    Btn_Client_Change.Text = "Save"

        '    Btn_Client_Add.Enabled = False
        '    Btn_Client_Edit.Enabled = False


        'Else ' SAVE

        '    If Txt_selected_Client_ID.Text = Txt_ClientID.Text Then
        '        MsgBox("No change in Client", vbExclamation, "Same Client ID")
        '        Exit Sub
        '    End If

        '    Call Change_Employee_Client_Assignment(Me.Lbl_Employee_ID.Text, Me.Txt_ClientID.Text, Me.Lbl_Latest_Client_ID.Text)

        '    ' Display
        '    Call Show_Employee_Client_History_at_Client_Change(Me.Lbl_Employee_ID.Text)

        '    Grp_Client_Info.Enabled = False
        '    Btn_Client_Delete.Text = "Delete"
        '    Btn_Client_Delete.Enabled = False
        '    Btn_Client_Change.Text = "Change Assignment"
        'End If

    End Sub

    Private Sub Btn_Separation_Update_Click(sender As Object, e As EventArgs) Handles Btn_Separation_Update.Click

        If Me.Cmb_Separation.SelectedIndex = -1 Then
            MsgBox("Please select separation status", vbCritical, "Status")
            Exit Sub
        End If

        If Me.Txt_ChangeStatus_Remark.Text = "" Then
            MsgBox("Please input reason for separation", vbCritical, "Reason")
            Exit Sub
        End If


        Dim sApplication_ID As String

        sApplication_ID = Get_Application_ID(Me.Lbl_Employee_ID.Text)

        Call Update_Employee_Separation_Status(sApplication_ID, Me.Lbl_Employee_ID.Text, Me.Cmb_Separation.Text) ' Update 3 tables 
        Call Show_Status_Change_History(Me.Lbl_Employee_ID.Text)
        ' Clear
        Cmb_Separation.SelectedIndex = -1
        Txt_StatusChange_Date.Text = ""
        Txt_ChangeStatus_Remark.Text = ""
    End Sub
    Private Sub Btn_UpRemarks_Click(sender As Object, e As EventArgs) Handles Btn_UpRemarks.Click
        ' Get remarks from textbox
        Dim remarks As String = Txt_ChangeStatus_Remark.Text.Trim()

        ' ✅ Make sure a row is selected
        If LV_Status_History.SelectedItems.Count = 0 Then
            MessageBox.Show("⚠️ Please select a record from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ✅ Safely get selected ID (column index 4)
        Dim selectedID As Integer = CInt(LV_Status_History.SelectedItems(0).SubItems(4).Text)
        Dim status As String = LV_Status_History.SelectedItems(0).SubItems(3).Text
        ' ✅ Call your update method with correct arguments
        Update_Employee_Status_Remarks(
        selectedID,
        Me.Lbl_Employee_ID.Text,               ' sEmployee_ID (if it's a string ID)
        status,                ' sNew_Status
        remarks                                ' updatedRemarks
    )
        Call Show_Status_Change_History(Me.Lbl_Employee_ID.Text)
    End Sub



    Private Sub LV_Status_History_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Status_History.SelectedIndexChanged
        If LV_Status_History.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = LV_Status_History.SelectedItems(0)

            ' Assuming column 0 is ID and column 2 is Remarks (adjust as needed)
            Dim selectedRemarks As String = selectedItem.SubItems(3).Text

            ' Display in textboxes
            Txt_ChangeStatus_Remark.Text = selectedRemarks
        End If
    End Sub
    Private Sub DP_Client_End_Date_ValueChanged(sender As Object, e As EventArgs) Handles DP_Client_End_Date.ValueChanged
        Txt_Client_End_Date.Text = DP_Client_End_Date.Value.ToShortDateString
    End Sub

    Private Sub Chk_UptoPresent_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_UptoPresent.CheckedChanged

        If Me.Chk_UptoPresent.Checked = True Then
            Me.DP_Client_End_Date.Enabled = False
            Me.Txt_Client_End_Date.Text = Me.Txt_Client_Start_Date.Text

        Else
            Me.DP_Client_End_Date.Enabled = True
            Me.Txt_Client_End_Date.Text = ""

        End If
    End Sub

    Private Sub Btn_Client_Add_Click(sender As Object, e As EventArgs) Handles Btn_Client_Add.Click
        If Btn_Client_Add.Text = "Add" Then

            MsgBox("Please select a new Client.", vbInformation, "New Client")

            Btn_ShowClientList.Enabled = True
            Btn_Client_Add.Text = "Save"
            Btn_Client_Delete.Text = "Cancel"
            Btn_Client_Edit.Enabled = False
            Btn_Client_Delete.Enabled = True
            Btn_Client_Change.Enabled = False

            Chk_UptoPresent.Enabled = False
            DP_Client_Start_Date.Enabled = True
            DP_Client_End_Date.Enabled = True

            Grp_Client_Info.Enabled = True

            Call Clear_Client_Textboxes()


        Else
            'If Me.Txt_Client_Start_Date.Text = Me.Txt_Client_End_Date.Text Then
            '    MsgBox("Same date is not allowed.", vbCritical, "Invalid Date")
            '    Exit Sub
            'End If

            Call Add_New_Client_Historical_Record(Me.Lbl_Employee_ID.Text, Me.Txt_ClientID.Text)
            Call Update_Employee_Record_New_Client_Assignment(Me.Lbl_Employee_ID.Text, Me.Txt_ClientID.Text)
            Call Show_Employee_Client_History_at_Client_Change(Me.Lbl_Employee_ID.Text)

            Btn_Client_Add.Text = "Add"
            Btn_Client_Add.Enabled = True
            Btn_Client_Delete.Text = "Delete"
            Btn_Client_Edit.Enabled = False
            Btn_Client_Edit.Text = "Edit"
            Btn_Client_Delete.Enabled = False
            Btn_Client_Change.Enabled = False
            Grp_Client_Info.Enabled = False

        End If
    End Sub

    Private Sub Btn_Client_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Client_Edit.Click
        If Btn_Client_Edit.Text = "Edit" Then

            ' changing the client should not be allowed when editing a client record
            Btn_ShowClientList.Enabled = False

            Btn_Client_Add.Text = "Add"
            Btn_Client_Add.Enabled = False
            Btn_Client_Edit.Text = "Update"
            Btn_Client_Delete.Text = "Cancel"
            Btn_Client_Edit.Enabled = True
            Btn_Client_Delete.Enabled = True
            Btn_Client_Change.Enabled = False
            Chk_UptoPresent.Enabled = True
            Grp_Client_Info.Enabled = True


        Else
            If Me.Txt_Client_Start_Date.Text = Me.Txt_Client_End_Date.Text Then
                MsgBox("Same date is set to END Date. This will have an status of Up-to-Present.", vbInformation, "Up to present is set")
            End If

            ' Since DB will not accept string, I change the "Up to present" string into Date same value as Date Start
            If Txt_Client_End_Date.Text = "Up to present" Then
                Txt_Client_End_Date.Text = Txt_Client_Start_Date.Text
            End If

            Call Update_Client_Record(Me.Lbl_Employee_ID.Text, Me.Lbl_Client_Ref_ID.Text)
            Call Show_Employee_Client_History_at_Client_Change(Me.Lbl_Employee_ID.Text)

            Btn_Client_Add.Text = "Add"
            Btn_Client_Add.Enabled = False
            Btn_Client_Edit.Text = "Edit"
            Btn_Client_Delete.Text = "Delete"
            Btn_Client_Edit.Enabled = False
            Btn_Client_Delete.Enabled = False
            Btn_Client_Change.Enabled = False
            Chk_UptoPresent.Enabled = False
            Chk_UptoPresent.Enabled = False
            Grp_Client_Info.Enabled = False

        End If
    End Sub



    Private Sub LV_License_Record_DoubleClick(sender As Object, e As EventArgs) Handles LV_License_Record.DoubleClick
        If Txt_License_Attachment.Text <> "" Then
            Try
                Process.Start(Trim(Me.Txt_License_Attachment.Text))
            Catch ex As Exception
                MsgBox(ex.ToString, vbCritical, "Error openning the attachment, try after saving.")
            End Try
        End If
    End Sub

    Private Sub Lbl_License_View_Attachment_Click(sender As Object, e As EventArgs) Handles Lbl_License_View_Attachment.Click
        If Txt_License_Attachment.Text <> "" Then
            Try
                Process.Start(Trim(Me.Txt_License_Attachment.Text))
            Catch ex As Exception
                MsgBox(ex.ToString, vbCritical, "Error openning the attachment, try after saving.")
            End Try
        End If
    End Sub

    Private Sub Tab_Client_Click(sender As Object, e As EventArgs) Handles Tab_Client.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub Cmb_Drug_Test_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Drug_Test.SelectedIndexChanged
        If Cmb_Drug_Test.Text = "Failed" Then
            Chk_Medical_Findings.Checked = True
        Else
            Chk_Medical_Findings.Checked = False
        End If
    End Sub



    Private Sub Btn_Leave_Filing_Click(sender As Object, e As EventArgs) Handles Btn_Leave_Filing.Click
        Tab_Employee_Transactions.SelectedIndex = 0
        Btn_Selected_Button.IconChar = IconChar.File
        Btn_Selected_Button.Text = "Leave Filing"

    End Sub

    Private Sub Btn_Medical_Records_Click(sender As Object, e As EventArgs) Handles Btn_Medical_Records.Click
        Tab_Employee_Transactions.SelectedIndex = 1
        Btn_Selected_Button.IconChar = IconChar.Medkit
        Btn_Selected_Button.Text = "Medical Records"
    End Sub

    Private Sub Btn_Insurance_Click(sender As Object, e As EventArgs) Handles Btn_Insurance.Click
        Tab_Employee_Transactions.SelectedIndex = 2
        Btn_Selected_Button.IconChar = IconChar.FileMedicalAlt
        Btn_Selected_Button.Text = "Insurance"
    End Sub

    Private Sub Btn_Security_License_Click(sender As Object, e As EventArgs) Handles Btn_Security_License.Click
        Tab_Employee_Transactions.SelectedIndex = 3
        Btn_Selected_Button.IconChar = IconChar.Gun
        Btn_Selected_Button.Text = "Security License"
    End Sub

    Private Sub Btn_Personel_Movement_Click(sender As Object, e As EventArgs) Handles Btn_Personel_Movement.Click
        Tab_Employee_Transactions.SelectedIndex = 4
        Btn_Selected_Button.IconChar = IconChar.Route
        Btn_Selected_Button.Text = "Personel Movement"
    End Sub

    Private Sub Btn_Employment_Status_Click(sender As Object, e As EventArgs) Handles Btn_Employment_Status.Click
        Tab_Employee_Transactions.SelectedIndex = 5
        Btn_Selected_Button.IconChar = IconChar.EnvelopeOpenText
        Btn_Selected_Button.Text = "Employee Status"
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub



End Class