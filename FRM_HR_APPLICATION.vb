Imports System.Globalization
Public Class FRM_HRIS_APPLICATION
    Private Sub FRM_HRIS_MAIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Show_List_of_Applicants()
        Call Clear_Application_Boxes()
        'Call Show_Application_Requirement_list() ' REF

        Call Enable_Disable_GroupBoxes(False)

        ' Application - Graduation Year combo box initialization as early as form load
        Me.Cmb_Grad_Year.Items.Clear()
        For i = 1980 To Date.Now.Year()
            Me.Cmb_Grad_Year.Items.Add(i)
        Next i

        Me.Cmb_Category.SelectedIndex = 2 ' Default to ALL
        Tab_Recruitment.SelectedIndex = 0
        Bar_AppProgress.Value = 0

        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(LV_Applicant_List, "Double click to shift to current application status.")
    End Sub


    Private Sub Btn_NewApplication_Click(sender As Object, e As EventArgs)

        GlobalVariables.sApplication_Global_Status = ""
        Tab_Recruitment.SelectedIndex = 1
        Call Enable_Disable_GroupBoxes(True)
        Call Clear_Application_Boxes()



    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Dim sResponse As String

        If GlobalVariables.sSelected_Job_Type = "" Then
            MsgBox("Please select Job Type first!", vbExclamation, "Job Type")
            Exit Sub
        End If

        If GlobalVariables.sApplication_Global_Status = "Active" Then ' Hired
            sResponse = MsgBox("This Employee was already hired. Are you sure you want to commit changes on its records?.", vbQuestion + vbYesNo, "Update Record?")
            If sResponse = vbYes Then

                GlobalVariables.Active_Status_Update = 1 ' Meaning you are updating an Active Status (hired) so avoid tampering the global status into "Application/Interview" status
                'Proceed to saving outside this IF
            Else
                Exit Sub
            End If

        End If

        If GlobalVariables.New_Application_ID = Nothing And Lbl_App_ID.Text = "" Then

            Call Insert_new_Application(GlobalVariables.sSelected_Job_Type, Cmb_Department.Text, Cmb_Position.Text)
            Me.Lbl_App_ID.Text = GlobalVariables.New_Application_ID ' Since app_id was already generated after inserting new applicant info

            'Error handling from the Insert_new_application function when there are incomplete inputs from the textboxes
            If GlobalVariables.Error_Encountered = 1 Then
                MsgBox("Error encountered while saving. Please check completeness of inputs.", vbCritical, "Invalid Input")
                GlobalVariables.Error_Encountered = 0
                GlobalVariables.New_Application_ID = Nothing 'reset
                Lbl_App_ID.Text = "" ' reset
                Exit Sub
            End If

            Call Update_Application_Record("Interview") ' Move to Interview
            Tab_Recruitment.SelectedIndex = 2 ' Move to Interview Tab
            Call Show_List_of_Applicants()

        ElseIf GlobalVariables.New_Application_ID = Nothing And Lbl_App_ID.Text <> "" And GlobalVariables.sApplication_Global_Status = "Application" Then

            Call Update_Application_Record("Application")
            Call Update_Application_Record("Interview") ' Move to Interview
            Tab_Recruitment.SelectedIndex = 2 ' Move to Interview Tab
            Call Show_List_of_Applicants()

        ElseIf GlobalVariables.New_Application_ID = Nothing And Lbl_App_ID.Text <> "" And GlobalVariables.sApplication_Global_Status = "Active" Then ' Active status means Hired
            Call Update_Application_Record("Application")
        End If


    End Sub
    Private Sub LV_Applicant_List_DoubleClick(sender As Object, e As EventArgs) Handles LV_Applicant_List.DoubleClick
        Dim sApplication_Status As String
        Dim iApplication_ID As Integer

        sApplication_Status = Get_Application_Status() ' From Database

        iApplication_ID = Me.LV_Applicant_List.SelectedItems(0).SubItems(0).Text ' Application ID from Database 

        GlobalVariables.sApplication_Global_Status = Me.LV_Applicant_List.SelectedItems(0).SubItems(3).Text ' or simply assign the value of iApplication_ID


        ' Assign Application ID to all Tabs
        Me.Lbl_App_ID.Text = iApplication_ID
        Me.Lbl_App_Interview_ID.Text = iApplication_ID

        Call Clear_Application_Boxes()

        Call Enable_Disable_GroupBoxes(True)

        Select Case sApplication_Status

            Case "Application"

                Call Show_record_According_to_Status(sApplication_Status, iApplication_ID)

                If Lbl_App_ID.Text <> "" Or Lbl_App_ID.Text <> "XXX" Then
                    Btn_Move_to_Interview.Enabled = True
                Else
                    Btn_Move_to_Interview.Enabled = False
                End If

                Tab_Recruitment.SelectedIndex = 1
                Bar_AppProgress.Value = 15
            Case "Interview"


                Call Show_record_According_to_Status("Application", iApplication_ID)
                Call Show_record_According_to_Status("Interview", iApplication_ID)

                Tab_Recruitment.SelectedIndex = 2
                Bar_AppProgress.Value = 33
            Case "Requirement"


                ' Get Job Type First ( This is to identify requrements depending on the job type )
                Dim sJob_Type As String
                sJob_Type = Get_Job_Type(iApplication_ID)
                Call Show_Application_Requirement_list(sJob_Type)

                Call Show_record_According_to_Status("Application", iApplication_ID)
                Call Show_record_According_to_Status("Interview", iApplication_ID)
                Call Show_record_According_to_Status("Requirement", iApplication_ID)


                Tab_Recruitment.SelectedIndex = 3
                Bar_AppProgress.Value = 55
            Case "For Completion"
                ' Clear Requirement

                Call Show_record_According_to_Status("Application", iApplication_ID)
                Call Show_record_According_to_Status("Interview", iApplication_ID)
                Call Show_record_According_to_Status("Requirement", iApplication_ID)
                Call Show_record_According_to_Status("For Completion", iApplication_ID)

                Tab_Recruitment.SelectedIndex = 4
                Bar_AppProgress.Value = 78

            Case "Active", "AWOL", "Resigned", "Terminated", "For Update", "Floating", "Finished Contract"

                Call Show_record_According_to_Status("Application", iApplication_ID)
                Call Show_record_According_to_Status("Interview", iApplication_ID)
                Call Show_record_According_to_Status("Requirement", iApplication_ID)
                Call Show_record_According_to_Status("For Completion", iApplication_ID)
                Tab_Recruitment.SelectedIndex = 4
                Bar_AppProgress.Value = 100


        End Select
    End Sub
    Private Sub LV_Applicant_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Applicant_List.SelectedIndexChanged

        ' See also Double CLick event
        Try

            GlobalVariables.sApplication_Global_Status = Me.LV_Applicant_List.SelectedItems(0).SubItems(3).Text

            Select Case GlobalVariables.sApplication_Global_Status

                Case "Application"
                    Bar_AppProgress.Value = 15
                    Btn_Abort_Application.Enabled = False
                Case "Interview"
                    Bar_AppProgress.Value = 33
                    Btn_Abort_Application.Enabled = True
                Case "Requirement"
                    Bar_AppProgress.Value = 55
                    Btn_Abort_Application.Enabled = True
                Case "For Completion"
                    Bar_AppProgress.Value = 78
                    Btn_Abort_Application.Enabled = False
                Case "Active"
                    Bar_AppProgress.Value = 100
                    Btn_Abort_Application.Enabled = False
                Case "Aborted"
                    Bar_AppProgress.Value = 0
                    Btn_Abort_Application.Enabled = False
            End Select

        Catch ex As Exception

        End Try
    End Sub



    Private Sub Cmb_Grad_Year_MouseDown(sender As Object, e As MouseEventArgs) Handles Cmb_Grad_Year.MouseDown
        '' Application - Graduation Year combo box
        'Me.Cmb_Grad_Year.Items.Clear()
        'For i = 2000 To Date.Now.Year()
        '    Me.Cmb_Grad_Year.Items.Add(i)
        'Next i
    End Sub

    Private Sub DTP_SL_Expiry_ValueChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub DP_Bday_ValueChanged_1(sender As Object, e As EventArgs) Handles DP_Bday.ValueChanged

        If DP_Bday.Value > Date.Now Then
            MsgBox("Invalid Birth date.", vbCritical, "Invalid Date")
            Exit Sub
        End If

        'If DP_Bday.Value.Year > Date.Now.Year - 18 Then
        '    MsgBox("Invalid Birth date. Age is too young to work", vbCritical, "Invalid Date")
        '    Exit Sub
        'End If

        Txt_Birthday.Text = DP_Bday.Value.ToShortDateString()
    End Sub






    Private Sub Tab_Interview_Click(sender As Object, e As EventArgs) Handles Tab_Interview.Click

        Select Case TabIndex
            Case 0

            Case 1 ' Application
                Call Show_record_According_to_Status("Application", Me.Lbl_App_ID.Text)

            Case 2 ' Interview

            Case 3 ' Requirements

            Case 4 ' Completed

        End Select

    End Sub

    Private Sub Btn_Move_to_REQ_Click(sender As Object, e As EventArgs) Handles Btn_Move_to_REQ.Click

        If Me.Lbl_App_Interview_ID.Text = "" Then
            MsgBox("Invalid Process", vbCritical, "Not applicable")
            Exit Sub
        End If


        If GlobalVariables.sApplication_Global_Status <> "Interview" Then
            MsgBox("Invalid Process", vbCritical, "Not for Interview")
            Exit Sub
        End If

        If Me.Cmb_Int_HR_Result.Text = "Fail" Or Me.Cmb_Int_OPR_Result.Text = "Fail" Or Me.Cmb_InterviewDIR.Text = "Fail" Then
            MsgBox("Can not proceed to next step if Interview result is FAIL.", vbCritical, "Failed in Interview")
            Exit Sub
        End If

        'Save 
        If Me.Lbl_App_Interview_ID.Text = "" Then
            Try
                Call Insert_New_Interview_Data(CInt(Lbl_App_ID.Text))
            Catch ex As Exception
                MsgBox("Invalid Process. Error in Inserting new interview record.", vbCritical, "Insert error")
            End Try
        Else
            Call Move_Interview_to_Requirements(CInt(Lbl_App_Interview_ID.Text))
            GlobalVariables.sApplication_Global_Status = "Requirement"
        End If

        'Lbl_Req_App_ID.Text = Lbl_App_Interview_ID.Text
        Call Show_Application_Requirement_list(GlobalVariables.sSelected_Job_Type)
        Tab_Recruitment.SelectedIndex = 3

    End Sub

    Private Sub Btn_Interview_SAVE_Click(sender As Object, e As EventArgs) Handles Btn_Interview_SAVE.Click

        If GlobalVariables.sApplication_Global_Status = "" Then
            MsgBox("Invalid Process", vbCritical, "Not applicable")
            Exit Sub
        End If

        ' Can also use now the Global_Status instead of this Lbl_App_Interview_ID, please update later
        ' Globa-Status is the current status from DB
        If Lbl_App_Interview_ID.Text = "XXX" Or Lbl_App_Interview_ID.Text = "" Then ' insert

            Call Insert_New_Interview_Data(Lbl_App_ID.Text)
            Lbl_App_Interview_ID.Text = Lbl_App_ID.Text

        Else ' update

            Call Update_Interview_Data(CInt(Lbl_App_Interview_ID.Text))
            Call Show_List_of_Applicants()
        End If



    End Sub

    Private Sub DT_Interview1_Date_ValueChanged(sender As Object, e As EventArgs) Handles DT_Interview1_Date.ValueChanged
        TxtInterviewHR_Date.Text = DT_Interview1_Date.Value.ToShortDateString
    End Sub

    Private Sub DT_Interview2_Date_ValueChanged(sender As Object, e As EventArgs) Handles DT_Interview2_Date.ValueChanged
        Txt_Interview_OP_Date.Text = DT_Interview2_Date.Value.ToShortDateString
    End Sub

    Private Sub Btn_Interview_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Interview_Cancel.Click

        If Me.Lbl_App_ID.Text = "" Then
            MsgBox("Invalid Process", vbCritical, "Select a record")
            Exit Sub
        End If


        Dim iResp As String
        iResp = MsgBox("Are you sure you want to cancel this application?", vbQuestion + vbYesNo, "Cancel Application")
        If iResp = vbYes Then
            Dim iReason_for_Cancelling As String
            iReason_for_Cancelling = InputBox("Please state the reason why you want to cancel this application.", "Cancel Application -  ID:  " & Me.Lbl_App_ID.Text)
            Call Cancel_Application(CInt(Me.Lbl_App_ID.Text), iReason_for_Cancelling)
            Me.Close()
        Else

        End If

    End Sub

    Private Sub Cmb_InterviewHR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_InterviewHR.SelectedIndexChanged
        Me.TxtInterviewHR_Date.Text = Now.ToShortDateString
        Me.Cmb_Int_HR_Result.SelectedIndex = 0
        Me.TxtInterview_HR_Remarks.Text = "Accepted"
    End Sub

    Private Sub Cmb_InterviewOP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_InterviewOP.SelectedIndexChanged
        Me.Txt_Interview_OP_Date.Text = Now.ToShortDateString
        Me.Cmb_Int_OPR_Result.SelectedIndex = 0
        Me.TxtInterview_Op_Remarks.Text = "Accepted"
    End Sub
    Private Sub Cmb_InterviewDIR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_InterviewDIR.SelectedIndexChanged
        Me.Txt_Interview_Dir_Date.Text = Date.Now.ToShortDateString
        Me.Cmb_Int_DIR_Result.SelectedIndex = 2
        Me.TxtInterview_Dir_Remarks.Text = "Accepted"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Me.Txt_FirstName.Text = "John Carlo"
        Me.Txt_MiddleName.Text = "Galera"
        Me.Txt_LastName.Text = "Estioko"
        Me.Txt_Maiden.Text = "De Asis"
        Me.Cmb_Civil_Status.SelectedIndex = 0
        Me.Txt_Birthday.Text = "9/6/1985"
        Me.Cmb_Gender.SelectedIndex = 1
        Me.Cmb_BloodType.SelectedIndex = 1
        Me.Cmb_Religion.SelectedIndex = 1

        Me.Cmb_Height.SelectedIndex = 1
        Me.Txt_Weight.Text = "70"
        Me.Txt_ResiAdd.Text = "Bay Laguna"
        Me.Txt_ContactNo.Text = "9175394469"
        Me.Txt_Email.Text = "myemail.com"

        Me.Cmb_Educ_Attainment.SelectedIndex = 1
        Me.Txt_Course.Text = "BSCOE"
        Me.Cmb_Grad_Year.Text = "2007"
        Me.Txt_PrevComp.Text = "TESLA"
        Me.Txt_Pos_Held.Text = "CEO"
        Me.Txt_PrevComp_Add.Text = "Microsoft"
        Me.Cmb_Refer.Text = "NA"
        Me.Cmb_Refer.SelectedIndex = 1

        Me.Txt_Contact_Name.Text = "Ivana Estioko"
        Me.Txt_Contact_Address.Text = "Bay Laguna"
        Me.Txt_Contact_Number.Text = "9175394469"
        Me.Cmb_Relationship.SelectedIndex = 0






    End Sub

    Private Sub Cmb_Refer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Refer.SelectedIndexChanged
        If Me.Cmb_Refer.SelectedIndex = 0 Then
            Txt_Refer_Rem.Text = "NA"
        Else
            Txt_Refer_Rem.Text = "Input complete name here"
        End If

        Me.Txt_Refer_Rem.Select()
    End Sub

    Private Sub Btn_App_AttachFile_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Lbl_App_View_Attachment_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub Btn_Req_Save_Click(sender As Object, e As EventArgs) Handles Btn_Req_Save.Click

        If GlobalVariables.sApplication_Global_Status = "" Then
            MsgBox("No selected applicant.", vbCritical, "Error")
            Exit Sub
        End If

        If GlobalVariables.sApplication_Global_Status <> "Requirement" Then
            MsgBox("Invalid Process. Not yet for requirement", vbCritical, "Error")
            Exit Sub
        End If


        If GlobalVariables.sApplication_Global_Status = "Active" Then
            MsgBox("This Employee was already hired and active. But will still accept changes on its records.", vbInformation, "Information")
        End If

        Dim iRow As Integer
        iRow = 0
        For Each item As ListViewItem In LV_Requirement_List.Items


            If item.Checked Then
                ' Save the items ( Insert if new , delete if unchecked, overwrite or ignore  if existing )
                ' During insertion, I am using the Interview app ID since there is no new record yet from REQ table
                Call Insert_Application_Requirements(Me.Lbl_App_Interview_ID.Text, Me.LV_Requirement_List.Items(iRow).SubItems(0).Text)


            Else ' No check
                ' Delete if uncheck but existing in DB 
                Try
                    Call Delete_application_Requirement(Me.Lbl_Req_App_ID.Text, Me.LV_Requirement_List.Items(iRow).SubItems(0).Text)
                Catch ex As Exception
                    ' going to Delete function but no req_id yet ( try catch fixed it )
                End Try


            End If
            iRow = iRow + 1
        Next

        MsgBox("Requirements were successfully saved.", vbInformation, "Saved")


    End Sub
    Private Sub LV_Requirement_List_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LV_Requirement_List.ItemChecked


    End Sub
    Private Sub LV_Requirement_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Requirement_List.SelectedIndexChanged



    End Sub

    Private Sub FRM_HRIS_APPLICATION_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ' Clear Requirement
        For i = 0 To Me.LV_Requirement_List.Items.Count - 1
            Me.LV_Requirement_List.Items(i).Checked = False
        Next
    End Sub

    Private Sub Btn_Req_MoveNext_Click(sender As Object, e As EventArgs) Handles Btn_Req_MoveNext.Click
        ' Do you want to control if requirements are completely submitted?
        Dim Check_ctr As Integer
        Dim sResponse As String

        If GlobalVariables.sApplication_Global_Status <> "Requirement" Then
            MsgBox("Error moving to next process. Please check current status.", vbCritical, "Error Moving")
            Exit Sub
        End If

        Check_ctr = 0
        For i = 0 To Me.LV_Requirement_List.Items.Count - 1
            If Me.LV_Requirement_List.Items(i).Checked = True Then
                Check_ctr = Check_ctr + 1
            End If

        Next

        If Check_ctr = 0 Then
            MsgBox("Can not move to For Completion status. There is not even one requiremtent being submitted.", vbCritical, "0 requirement submitted")
            Exit Sub
        ElseIf Check_ctr <= Me.LV_Requirement_List.Items.Count - 1 Then
            sResponse= MsgBox("Requirements are not complete yet. Do you really want to move this to For Completion Status?", vbQuestion + vbYesNo, "Are you sure?")
            If sResponse = vbNo Then
                Exit Sub
            End If
        End If

        Call Move_Requirement_to_For_Completion(Me.Lbl_Req_App_ID.Text)
        GlobalVariables.sApplication_Global_Status = "For Completion"

        Tab_Recruitment.SelectedIndex = 4
    End Sub

    Private Sub DP_Date_Hired_ValueChanged(sender As Object, e As EventArgs) Handles DP_Date_Hired.ValueChanged

        'If DP_Date_Hired.Value <= Date.Now Then
        '    MsgBox("Date can't be from the past. Please check the Date.", vbCritical, "Invalid Hiring Date")
        '    Exit Sub
        'End If

        Me.TxtDate_Hired.Text = Me.DP_Date_Hired.Value.ToShortDateString
    End Sub

    Private Sub Btn_ShowClientList_Click(sender As Object, e As EventArgs) Handles Btn_ShowClientList.Click
        GlobalVariables.Client_Event = "Application"
        Call FRM_CLIENT_REG.ShowDialog()
    End Sub

    Private Sub Btn_GenerateID_Click(sender As Object, e As EventArgs) Handles Btn_GenerateID.Click

        Call Generate_Employee_ID()
    End Sub

    Private Sub Btn_SemiComplete_Save_Click(sender As Object, e As EventArgs) Handles Btn_SemiComplete_Save.Click
        If GlobalVariables.sApplication_Global_Status = "Hired" Or GlobalVariables.sApplication_Global_Status = "Active" Then ' Hired status is no longer being used
            MsgBox("This Employee was already hired. But will still accept changes on its records.", vbInformation, "Information")
        End If

        Dim sClient_Response As String

        If Txt_Client_Start_Date.Visible = True And Txt_Client_Start_Date.Text = "" Then
            MsgBox("Please specify the start date for the new Client.", vbCritical, "Start Date missing")
            Exit Sub
        End If

        If Me.Lbl_Current_CLient_ID.Text <> Me.Txt_ClientID.Text And Txt_Client_Start_Date.Visible = True Then ' The client ID was changed therefor need to insert historica record at HR Client Transfer table 
            sClient_Response = MsgBox("You are about to change the client ID of this Employee. Are you sure you want to proceed?", vbQuestion + vbOKCancel, "Change Client")
            If sClient_Response = vbCancel Then
                Exit Sub
            End If
        End If


        Try
            If Me.Lbl_Complete_App_ID.Text = "" Then
                Call Insert_Record_To_HR_EMPLOYEE_RECORD_HDR(Me.Lbl_Req_App_ID.Text)
                Lbl_Complete_App_ID.Text = Me.Lbl_Req_App_ID.Text ' So no need to close the form for refresh ( to select an employee and get the updated app_id )
            Else
                Call Update_For_Completion_record(Me.Lbl_Complete_App_ID.Text)

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Updated the record of " & Txt_Employee_ID.Text & "")

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error")

        End Try

        'Me.Close()
    End Sub

    Private Sub Btn_Complete_Click(sender As Object, e As EventArgs) Handles Btn_Complete.Click

        If GlobalVariables.sApplication_Global_Status = "Active" Or GlobalVariables.sApplication_Global_Status = "Resigned" Or GlobalVariables.sApplication_Global_Status = "AWOL" Then
            MsgBox("This Employee was already hired.", vbCritical, "Active")
            Exit Sub
        End If

        If Me.Lbl_Complete_App_ID.Text = "" Then ' if this is null, then there is no record yet from DB
            MsgBox("Please save it first.", vbCritical, "Not yet saved")
            Exit Sub
        End If

        If Me.TxtDate_Hired.Text = "" Or Me.Txt_ClientID.Text = "" Or Me.Txt_Employee_ID.Text = "" Then
            MsgBox("Not complete yet. Please provide information asked and click save.", vbCritical, "Not applicabe yet")
            Exit Sub
        End If

        ' Update Application global status to 'Hired'
        Call Update_Application_Status_to_Complete(Lbl_Complete_App_ID.Text)
        Call Show_List_of_Applicants()
        Me.Close()

    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs)


    End Sub



    Private Sub Cmb_Grad_Year_MouseLeave(sender As Object, e As EventArgs) Handles Cmb_Grad_Year.MouseLeave
        If Me.Cmb_Grad_Year.Text <> "" Then
            If IsNumeric(Me.Cmb_Grad_Year.Text) = False Then
                MsgBox("Invalid Year", vbCritical, "Not a valid Year")
                Me.Cmb_Grad_Year.Select()
            End If
        End If
    End Sub

    Private Sub LV_Requirement_List_MouseLeave(sender As Object, e As EventArgs) Handles LV_Requirement_List.MouseLeave

        Dim iChecked As Integer
        iChecked = 0

        If GlobalVariables.sApplication_Global_Status = "" Then
            ' Having an error when form is initally loaded and then go directly to Requirement Tab
            ' This will handle the error - do not remove
            Exit Sub
        End If

        For Each item As ListViewItem In Me.LV_Requirement_List.Items
            Try
                If IsNothing(item) = False Then
                    If item.Checked Then
                        iChecked = iChecked + 1
                    End If
                End If
            Catch ex As Exception

            End Try
        Next

        Me.Prog_REQ.Value = (iChecked / CInt(Me.LV_Requirement_List.Items.Count)) * 100
    End Sub
    Private Sub Txt_ContactNo_LostFocus(sender As Object, e As EventArgs) Handles Txt_ContactNo.LostFocus
        If Me.Txt_ContactNo.Text.Length <> 10 Then
            MsgBox("Ivalid Contact Number Length - 10 digits starting at number 9", vbCritical, "Invalid CP Number")
            Me.Txt_ContactNo.Select()
            Exit Sub
        End If

        If IsNumeric(Me.Txt_ContactNo.Text) = False Then
            MsgBox("Invalid Integer in Contact Number.", vbCritical, "Inavalid")
            Exit Sub
        End If

        If Mid(Me.Txt_ContactNo.Text, 1, 1) <> "9" Then
            MsgBox("Invalid start of Contact Number. It should start with number 9", vbCritical, "Inavalid")
            Exit Sub
        End If

    End Sub
    Private Sub Txt_ContactNo_TextChanged(sender As Object, e As EventArgs) Handles Txt_ContactNo.TextChanged

    End Sub



    Private Sub Txt_Email_LostFocus(sender As Object, e As EventArgs) Handles Txt_Email.LostFocus

        If Me.Txt_Email.Text = "" Then

            Me.Txt_Email.Text = "NA"

        End If
    End Sub



    Private Sub Txt_Weight_LostFocus(sender As Object, e As EventArgs) Handles Txt_Weight.LostFocus
        If IsNumeric(Me.Txt_Weight.Text) = False Then
            MsgBox("Invalid weight. Only accepts integer.", vbCritical, "Invalid")
            Exit Sub
        End If

        If CInt(Me.Txt_Weight.Text) > 100 Or CInt(Me.Txt_Weight.Text) < 40 Then
            MsgBox("Overweight or Underweight.", vbCritical, "Weight not acceptable")
            Exit Sub
        End If
    End Sub

    Private Sub Btn_Requirement_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Requirement_Cancel.Click


        If Me.Lbl_App_ID.Text = "" Then
            MsgBox("Invalid Process", vbCritical, "Select a record")
            Exit Sub
        End If

        Dim iResp As String
        iResp = MsgBox("Are you sure you want to cancel this application?", vbQuestion + vbYesNo, "Cancel Application")
        If iResp = vbYes Then
            Dim iReason_for_Cancelling As String
            iReason_for_Cancelling = InputBox("Please state the reason why you want to cancel this application.", "Cancel Application -  ID:  " & Me.Lbl_App_ID.Text)
            Call Cancel_Application(CInt(Me.Lbl_App_ID.Text), iReason_for_Cancelling)
            Me.Close()
        Else

        End If
    End Sub

    Private Sub DP_CLient_Start_Date_ValueChanged(sender As Object, e As EventArgs) Handles DP_Client_Start_Date.ValueChanged
        Me.Txt_Client_Start_Date.Text = DP_Client_Start_Date.Value.ToShortDateString
    End Sub

    Private Sub Tab_Recruitment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab_Recruitment.SelectedIndexChanged

    End Sub

    Private Sub Chk_GovIDs_NotAvailable_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_GovIDs_NotAvailable.CheckedChanged
        If Chk_GovIDs_NotAvailable.Checked = True Then
            Dim sResponse As String
            sResponse = MsgBox("This will set all Goverment IDs into To follow and will overwrite current IDs. " & vbCrLf & " Are you sure you want to proceed?", vbQuestion + vbYesNo, "To Follow")
            If sResponse = vbNo Then
                Exit Sub
            End If

            Me.Txt_SSS.Text = "To follow"
            Me.Txt_Pagibig.Text = "To follow"
            Me.Txt_PhilHealth.Text = "To follow"
            Me.Txt_TIN.Text = "To follow"
            Me.Txt_National_ID.Text = "To follow"
            Grp_Complete_GovNum.Enabled = False
        Else
            Me.Txt_SSS.Text = ""
            Me.Txt_Pagibig.Text = ""
            Me.Txt_PhilHealth.Text = ""
            Me.Txt_TIN.Text = ""
            Me.Txt_National_ID.Text = ""
            Grp_Complete_GovNum.Enabled = True
        End If
    End Sub

    Private Sub Chk_No_License_yet_CheckedChanged(sender As Object, e As EventArgs)
        ' Not here since even just showing the value will trigger the event of checked/unchecked
        ' So I put it on the click event instead
    End Sub

    Private Sub DT_Interview3_Date_ValueChanged(sender As Object, e As EventArgs) Handles DT_Interview3_Date.ValueChanged
        Txt_Interview_Dir_Date.Text = DT_Interview3_Date.Value.ToShortDateString
    End Sub

    Private Sub Btn_Manual_ID_Click(sender As Object, e As EventArgs) Handles Btn_Manual_ID.Click

        'If GlobalVariables.sEmployee_ID_Logged_in = "Admin001" Then
        If Txt_Employee_ID.Enabled = False Then
            Txt_Employee_ID.Enabled = True
            Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Enabled manual ID input for Application ID " & Lbl_App_ID.Text & "")
        Else
            Txt_Employee_ID.Enabled = False
        End If

    End Sub

    Private Sub Btn_NewApplication_Click_1(sender As Object, e As EventArgs) Handles Btn_NewApplication.Click

        ' I created a status New_application_ID to know if the user is adding a new ID 
        ' The iApplication_ID is the application ID taken from the database, meaning it's not new and that the user selected an ongoing application 
        ' This ID regardless where it came from is being reflected in Lbl_app_ID as the visible ID for the user and admin

        'reset IDs
        GlobalVariables.sApplication_Global_Status = ""
        GlobalVariables.New_Application_ID = Nothing
        Lbl_App_ID.Text = ""

        Tab_Recruitment.SelectedIndex = 1
        Call Enable_Disable_GroupBoxes(True)
        Call Clear_Application_Boxes()

        If Me.Lbl_App_ID.Text = "XXX" Or Me.Lbl_App_ID.Text = "" Then ' I already removed the XXX label in Lbl_App_ID
            Btn_Move_to_Interview.Enabled = False
        Else
            Btn_Move_to_Interview.Enabled = True
        End If
    End Sub

    Private Sub Btn_SearchApplicant_Click(sender As Object, e As EventArgs) Handles Btn_SearchApplicant.Click
        Dim sCategory As String
        sCategory = ""

        If Me.Cmb_Category.SelectedIndex = 0 Then
            sCategory = "B.LAST_NAME"
        ElseIf Me.Cmb_Category.SelectedIndex = 1 Then
            sCategory = "A.STATUS"
        ElseIf Me.Cmb_Category.SelectedIndex = 2 Then
            sCategory = "B.LAST_NAME" ' if "ALL" was selected
        End If

        Call Search_Employee_Application_Record(sCategory)
    End Sub

    Private Sub Tab_AppList_Click(sender As Object, e As EventArgs) Handles Tab_AppList.Click

    End Sub

    Private Sub Btn_Refresh_Click(sender As Object, e As EventArgs) Handles Btn_Refresh.Click
        Call Show_List_of_Applicants()
    End Sub

    Private Sub Txt_Email_TextChanged(sender As Object, e As EventArgs) Handles Txt_Email.TextChanged

    End Sub

    Private Sub Cmb_Educ_Attainment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Educ_Attainment.SelectedIndexChanged
        If Cmb_Educ_Attainment.SelectedIndex = 0 Or Cmb_Educ_Attainment.SelectedIndex = 4 Then
            Txt_Course.Text = "NA"
        End If
    End Sub



    Private Sub TxtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSearch.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Dim sCategory As String
            sCategory = ""

            If Me.Cmb_Category.SelectedIndex = 0 Then
                sCategory = "B.LAST_NAME"
            ElseIf Me.Cmb_Category.SelectedIndex = 1 Then
                sCategory = "A.STATUS"
            ElseIf Me.Cmb_Category.SelectedIndex = 2 Then
                sCategory = "B.LAST_NAME" ' if "ALL" was selected
            End If

            Call Search_Employee_Application_Record(sCategory)

        End If
    End Sub

    Private Sub Opt_SecurityPersonnel_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_SecurityPersonnel.CheckedChanged
        Cmb_Department.Items.Clear()
        Cmb_Position.Items.Clear()

        If Opt_SecurityPersonnel.Checked = True Then
            GlobalVariables.sSelected_Job_Type = "Security_Personnel"
            Cmb_Department.Items.Add("Operations")
            Cmb_Position.Items.Add("Security Guard")
            Cmb_Department.SelectedIndex = 0
            Cmb_Position.SelectedIndex = 0

        ElseIf Opt_Non_SecurityPersonnel.Checked = True Then
            GlobalVariables.sSelected_Job_Type = "Non_Security_Personnel"
            Cmb_Department.Items.Add("Human Resources")
            Cmb_Department.Items.Add("Payroll")
            Cmb_Department.Items.Add("Accounting")
            Cmb_Department.Items.Add("Marketing")
        End If
    End Sub

    Private Sub Opt_Non_SecurityPersonnel_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_Non_SecurityPersonnel.CheckedChanged
        If Opt_SecurityPersonnel.Checked = True Then
            GlobalVariables.sSelected_Job_Type = "Security_Personnel"
        ElseIf Opt_Non_SecurityPersonnel.Checked = True Then
            GlobalVariables.sSelected_Job_Type = "Non_Security_Personnel"
        End If
    End Sub

    Private Sub Cmb_Position_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Position.SelectedIndexChanged

    End Sub

    Private Sub Cmb_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Department.SelectedIndexChanged

    End Sub
End Class