Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration

Module Mod_FRM_HR_APPLICATION

    Public Function Get_Job_Type(sApplication_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = "SELECT * FROM HR_APPLICATION_DTL A, HR_APPLICATION_HDR B WHERE A.APPLICATION_ID = " & sApplication_ID & " AND A.APPLICATION_ID = B.APPLICATION_ID"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                Dim myRow As DataRow

                For Each myRow In dt.Rows

                    With FRM_HRIS_APPLICATION


                        Return myRow.Item("JOB_TYPE")


                    End With
                Next

            Else


            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function

    Public Sub Enable_Disable_GroupBoxes(Bool_EnableDisable As Boolean)


        With FRM_HRIS_APPLICATION

            .Grp_Application_BasicInfo.Enabled = Bool_EnableDisable ' As set in the parameter
            .Grp_Application_Educ.Enabled = Bool_EnableDisable
            .Grp_Interview.Enabled = Bool_EnableDisable
            .Grp_Complete_GovNum.Enabled = Bool_EnableDisable
            .Grp_Complete_JobInfo.Enabled = Bool_EnableDisable
            .Grp_Application_Position.Enabled = Bool_EnableDisable
            .Grp_Contact_Info.Enabled = Bool_EnableDisable

        End With



    End Sub

    Public Sub Search_Employee_Application_Record(sCategory As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            'Dim sAborted_Status, sHired_Status As String
            'If FRM_HRIS_APPLICATION.Chk_Aborted.Checked = True Then ' If checked will be excluded
            '    sAborted_Status = "Aborted"
            'Else
            '    sAborted_Status = "NA"
            'End If

            'If FRM_HRIS_APPLICATION.Chk_Hired.Checked = True Then
            '    sHired_Status = "Hired"
            'Else
            '    sHired_Status = "NA"
            'End If

            'If FRM_HRIS_APPLICATION.Chk_Resigned.Checked = True Then
            '    sHired_Status = "Resigned"
            'Else
            '    sHired_Status = "NA"
            'End If

            SQL = "SELECT A.APPLICATION_ID, B.FIRST_NAME, B.MIDDLE_NAME, B.LAST_NAME, B.DATE_REGISTERED,A.STATUS FROM HR_APPLICATION_HDR A, HR_APPLICATION_DTL B"
            SQL = SQL & " WHERE " & sCategory & " like '%" & FRM_HRIS_APPLICATION.TxtSearch.Text & "%'  "
            SQL = SQL & " AND A.APPLICATION_ID = B.APPLICATION_ID  ORDER BY B.DATE_REGISTERED"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HRIS_APPLICATION.LV_Applicant_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("APPLICATION_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".")
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("DATE_REGISTERED"), "MMMM dd, yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("STATUS"))


                    Next
                End With
            Else
                FRM_HRIS_APPLICATION.LV_Applicant_List.Items.Clear()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Show Application List Error")
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Update_Application_Status_to_Complete(iApplication_ID As Integer)


        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_HRIS_APPLICATION


                SQL = "UPDATE HR_APPLICATION_HDR SET STATUS = 'Active' WHERE APPLICATION_ID = " & iApplication_ID & ""


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                MsgBox("Application was successfully completed! ", vbInformation, "Updated")

            End With

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Completion Error")
        End Try


    End Sub



    Public Sub Update_For_Completion_record(iApplication_ID As Integer)
        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_HRIS_APPLICATION

                SQL = "UPDATE HR_EMPLOYEE_RECORD_HDR SET SSS_NO = '" & .Txt_SSS.Text & "', PAGIBIG_NO = '" & .Txt_Pagibig.Text & "', PHIL_HEALTH_NO = '" & .Txt_PhilHealth.Text & "'"
                SQL = SQL & ", TIN_NO = '" & .Txt_TIN.Text & "', NATIONAL_ID = '" & .Txt_National_ID.Text & "',  DATE_HIRED = '" & .TxtDate_Hired.Text & "', SUB_CLIENT_ID = '" & .Txt_ClientID.Text & "'"
                SQL = SQL & " WHERE APPLICATION_ID = " & iApplication_ID & ""


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                'Dim SQL2 As String

                If .Lbl_Current_CLient_ID.Text <> .Txt_ClientID.Text Then ' 24-Feb2024 Will no longer allow changing of client via application form

                    MsgBox("Client was not changed! Please change the status from the Employee Movement Form.", vbInformation, "Client change not allowed here")

                    'SQL2 = "INSERT INTO HR_EMPLOYEE_CLIENT_TRANSFER_DTL (EMPLOYEE_ID, SUB_CLIENT_ID, DATE_STARTED, DATE_ENDED) VALUES ( '" & .Txt_Employee_ID.Text & "', " & .Txt_ClientID.Text & ",'" & .Txt_Client_Start_Date.Text & "', '" & .Txt_Client_Start_Date.Text & "')"

                    'Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL2, GlobalVariables.GlobalCon)
                    'SQLcmd2.ExecuteNonQuery()
                    'SQLcmd2.Dispose()


                End If


                MsgBox("Record was successfully updated.", vbInformation, "Saved")

            End With

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Update For Completion Error")
        End Try


    End Sub

    Public Sub Show_For_Completion_Record(iApplication As Integer)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = "SELECT * FROM HR_EMPLOYEE_RECORD_HDR WHERE APPLICATION_ID = " & iApplication & "  "

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                ' Prevent from generating a new Employee ID
                FRM_HRIS_APPLICATION.Btn_GenerateID.Enabled = False

                Dim myRow As DataRow
                For Each myRow In dt.Rows
                    With FRM_HRIS_APPLICATION

                        .Lbl_Complete_App_ID.Text = iApplication

                        .Txt_SSS.Text = myRow.Item("SSS_NO")
                        .Txt_Pagibig.Text = myRow.Item("PAGIBIG_NO")
                        .Txt_PhilHealth.Text = myRow.Item("PHIL_HEALTH_NO")
                        .Txt_TIN.Text = myRow.Item("TIN_NO")
                        .Txt_National_ID.Text = myRow.Item("NATIONAL_ID")
                        .Txt_ClientID.Text = myRow.Item("SUB_CLIENT_ID")
                        .Lbl_Current_CLient_ID.Text = myRow.Item("SUB_CLIENT_ID") ' redundant client id for comparaing purposes to identify change in client ID
                        .Txt_Employee_ID.Text = myRow.Item("EMPLOYEE_ID")
                        .TxtDate_Hired.Text = myRow.Item("DATE_HIRED")


                    End With
                Next
            Else
                FRM_HRIS_APPLICATION.Btn_GenerateID.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "For Completion Status")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Sub Insert_Record_To_HR_EMPLOYEE_RECORD_HDR(iApplication_ID As Integer)

        With FRM_HRIS_APPLICATION

            Dim SQL, SQL2 As String

            Connect_to_MDB()

            Try

                SQL = ""
                SQL = "INSERT INTO HR_EMPLOYEE_RECORD_HDR (APPLICATION_ID, EMPLOYEE_ID, SUB_CLIENT_ID, SSS_NO, PAGIBIG_NO, PHIL_HEALTH_NO, TIN_NO, NATIONAL_ID, DATE_HIRED, EMPLOYMENT_STATUS)"
                SQL = SQL & " VALUES (" & iApplication_ID & ", '" & .Txt_Employee_ID.Text & "', " & .Txt_ClientID.Text & ", '" & .Txt_SSS.Text & "','" & .Txt_Pagibig.Text & "','" & .Txt_PhilHealth.Text & "'"
                SQL = SQL & ", '" & .Txt_TIN.Text & "', '" & .Txt_National_ID.Text & "', '" & .TxtDate_Hired.Text & "', 'Active')"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                SQL2 = ""
                SQL2 = "INSERT INTO HR_EMPLOYEE_CLIENT_TRANSFER_DTL (EMPLOYEE_ID, SUB_CLIENT_ID, DATE_STARTED, DATE_ENDED) VALUES ( '" & .Txt_Employee_ID.Text & "', " & .Txt_ClientID.Text & ",'" & .TxtDate_Hired.Text & "','" & .TxtDate_Hired.Text & "')"

                Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL2, GlobalVariables.GlobalCon)
                SQLcmd2.ExecuteNonQuery()
                SQLcmd2.Dispose()


                MsgBox("Record was successfully saved.", vbInformation, "For Completion Status saved")

            Catch ex As Exception
                MsgBox(ex.ToString, vbCritical, "Invalid Input or check if already existing in employee records.")

            End Try

            GlobalVariables.GlobalCon.Close()

        End With



    End Sub




    Public Sub Show_Checked_Items_from_Application_Requirements(iApplication_ID As Integer, iReq_ID As String, iRowIndex As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()

        Dim SQL As String

        Connect_to_MDB()

        Try

            SQL = "SELECT * FROM HR_REQUIREMENT_DTL WHERE APPLICATION_ID = " & iApplication_ID & " AND HR_REQUIREMENT_ID = '" & iReq_ID & "' "
            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' if found in DB then set the LV row to checked state
                FRM_HRIS_APPLICATION.LV_Requirement_List.Items(iRowIndex).Checked = True

            End If


        Catch ex As Exception


        End Try

        GlobalVariables.GlobalCon.Close()






    End Sub


    Public Sub Delete_application_Requirement(iApplication_ID As Integer, iReq_ID As String)


        With FRM_HRIS_APPLICATION
            ' This function is controlling the insertion and deletion of items according to what was checked or unchecked by the use from the List View

            Dim da As New OleDb.OleDbDataAdapter
            Dim dt As New DataTable

            dt.Clear()
            dt.Reset()

            Dim SQL As String

            Connect_to_MDB()

            Try

                SQL = "SELECT * FROM HR_REQUIREMENT_DTL WHERE APPLICATION_ID = " & iApplication_ID & " AND HR_REQUIREMENT_ID = '" & iReq_ID & "' "
                da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
                da.Fill(dt)


                ' REquirement ID has no check
                If dt.Rows.Count > 0 Then
                    ' but exitsing so need to be deleted
                    With FRM_HRIS_APPLICATION


                        SQL = "DELETE FROM HR_REQUIREMENT_DTL WHERE APPLICATION_ID = " & iApplication_ID & " AND HR_REQUIREMENT_ID = '" & iReq_ID & "' "

                        Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                        SQLcmd.ExecuteNonQuery()
                        SQLcmd.Dispose()

                        MsgBox(iReq_ID & " was deleted from database because you unchecked it.", vbInformation, "Deleted")

                    End With
                Else



                End If


            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try

            GlobalVariables.GlobalCon.Close()

        End With




    End Sub


    Public Sub Insert_Application_Requirements(iApplication_ID As Integer, iReq_ID As String)


        With FRM_HRIS_APPLICATION
            ' This function is controlling the insertion and deletion of items according to what was checked or unchecked by the use from the List View

            Dim da As New OleDb.OleDbDataAdapter
            Dim dt As New DataTable

            dt.Clear()
            dt.Reset()

            Dim SQL As String

            Connect_to_MDB()

            Try

                SQL = "SELECT * FROM HR_REQUIREMENT_DTL WHERE APPLICATION_ID = " & iApplication_ID & " AND HR_REQUIREMENT_ID = '" & iReq_ID & "' "
                da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    ' Found Record then should not proceed to insert  
                    'MsgBox(iReq_ID & " is already saved under application id: " & iApplication_ID, vbInformation, "Will not save anymore")
                Else
                    ' No record yet so proceed to insert
                    ' With FRM_HRIS_APPLICATION

                    SQL = "INSERT INTO HR_REQUIREMENT_DTL (APPLICATION_ID, HR_REQUIREMENT_ID) VALUES (" & iApplication_ID & ", '" & iReq_ID & "')"

                    Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                    SQLcmd.ExecuteNonQuery()
                    SQLcmd.Dispose()

                    'Set the current status to Lbl_Req
                    .Lbl_Req_App_ID.Text = iApplication_ID

                    ' End With

                End If

            Catch ex As Exception
                MsgBox(ex.ToString, vbCritical, "Error in Requirements")

            End Try

            GlobalVariables.GlobalCon.Close()

        End With

    End Sub


    Public Sub Attach_Scanned_License_ID()

        With FRM_EMP_UPDATE_REC
            Try
                .OpenFileDialog1.Title = "Upload scanned Security Guard License ID"
                'OpenFileDialog1.InitialDirectory = ""
                '.OpenFileDialog1.FileName = ".pdf"
                '.OpenFileDialog1.Filter = "PDF Files |*.pdf"

                ' Set the file filter to allow only PDF and JPEG files
                .OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|All Files (*.*)|*.*"

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Check Map Drive")
            End Try

            Dim result As DialogResult = .OpenFileDialog1.ShowDialog()
            'Dim Full_Path_Filename, sFilename As String

            If result = 1 Then

                GlobalVariables.sFileName = .OpenFileDialog1.SafeFileName
                GlobalVariables.sSource_Path = .OpenFileDialog1.FileName

                'Rename
                Dim currentDate As DateTime = DateTime.Now
                ' Format the date and time as "ddMMyyHHmmss"
                Dim formattedDateTime As String = currentDate.ToString("ddMMyyHHmmss")

                Dim newFilePath As String = Path.Combine(Application.StartupPath & "\Attachments\SG_License\", .Lbl_Employee_ID.Text & "_" & formattedDateTime & Right(GlobalVariables.sFileName, 4))

                GlobalVariables.sDestination_Path = newFilePath
                .Txt_License_Attachment.Text = newFilePath
                '.Lbl_License_View_Attachment.Text = GlobalVariables.sFileName

            Else

                MsgBox("Please Select a valid .pdf or .jpg file.", vbCritical, "Nothing was selected")
                Exit Sub
            End If

            ' Destination + JPG filename ( Complete Destination path )


            'Dim sDriveX As String = ConfigurationSettings.AppSettings("FileServer")



        End With

    End Sub


    Public Sub Show_Application_Requirement_list(sJob_Type As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            If sJob_Type = "Security_Personnel" Then
                SQL = "SELECT * FROM HR_REQUIREMENT_REF WHERE SECURITY_POSITION_REQ in ('YES', 'BOTH') ORDER BY HR_REQ_ID ASC"
            Else
                SQL = "SELECT * FROM HR_REQUIREMENT_REF WHERE SECURITY_POSITION_REQ = 'Both' ORDER BY HR_REQ_ID ASC"
            End If


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Dim myRow As DataRow
                With FRM_HRIS_APPLICATION.LV_Requirement_List
                    .Items.Clear()
                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("HR_REQ_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("REQ_DESC"))

                    Next
                End With
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Requirement REF")
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub
    Public Sub Move_Interview_to_Requirements(iApplication_ID As Integer)
        Dim SQL2 As String
        Connect_to_MDB()

        Try
            With FRM_HRIS_APPLICATION
                SQL2 = ""
                SQL2 = "UPDATE HR_APPLICATION_HDR SET STATUS = 'Requirement' WHERE APPLICATION_ID = " & iApplication_ID & ""

                Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL2, GlobalVariables.GlobalCon) ' HR_APPLICATION_HDR
                SQLcmd2.ExecuteNonQuery()
                SQLcmd2.Dispose()
            End With

            MsgBox("Successfully moved to For Requirement Status", vbInformation, "Moved")


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error moving to Requirement Status")

        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub Move_Requirement_to_For_Completion(iApplication_ID As Integer)
        Dim SQL2 As String
        Connect_to_MDB()

        Try
            With FRM_HRIS_APPLICATION
                SQL2 = ""
                SQL2 = "UPDATE HR_APPLICATION_HDR SET STATUS = 'For Completion' WHERE APPLICATION_ID = " & iApplication_ID & ""

                Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL2, GlobalVariables.GlobalCon) ' HR_APPLICATION_HDR
                SQLcmd2.ExecuteNonQuery()
                SQLcmd2.Dispose()
            End With

            MsgBox("Successfully moved to For Completion Status", vbInformation, "Moved")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error moving to For Completion Status")

        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub Cancel_Application(iApplication_ID As Integer, sReason As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_HRIS_APPLICATION


                SQL = ""
                SQL = "UPDATE HR_APPLICATION_HDR SET STATUS = 'Aborted', REMARKS = '" & sReason & "' WHERE APPLICATION_ID = " & iApplication_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon) ' HR_APPLICATION_DTL
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("This application was succesfully CANCELLED", vbInformation, "Cancelled")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating RECORD to TBL_Application_HDR")

        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub

    Public Function Generate_Application_ID()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String
        Dim NewID As Integer

        SQL = "SELECT MAX(APPLICATION_ID) AS NEW_ID FROM HR_APPLICATION_HDR"

        Try

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow

                For Each myRow In dt.Rows
                    If IsDBNull(myRow.Item("NEW_ID")) = True Then
                        NewID = 1001
                        Return NewID
                    End If

                    NewID = myRow.Item("NEW_ID") + 1
                    Return NewID

                Next

            Else

                NewID = 1001
                Return NewID

                GlobalVariables.GlobalCon.Close()
            End If

        Catch ex As Exception

            MsgBox(ex.ToString, vbCritical, "Error in Generating Application ID Number")
            Return -1

        End Try

        Return -1

    End Function

    Public Sub Update_Application_Record(sNext_Status As String)


        Dim SQL, SQL2 As String
        Connect_to_MDB()

        Try
            With FRM_HRIS_APPLICATION

                If sNext_Status = "Application" Then

                    SQL = ""
                    SQL = "UPDATE HR_APPLICATION_DTL SET FIRST_NAME = '" & Trim(.Txt_FirstName.Text) & "', MIDDLE_NAME = '" & Trim(.Txt_MiddleName.Text) & "', LAST_NAME='" & Trim(.Txt_LastName.Text) & "', MAIDEN_NAME = '" & .Txt_Maiden.Text & "' "
                    SQL = SQL & ", CIVIL_STATUS = '" & .Cmb_Civil_Status.Text & "', BIRTH_DATE = '" & .Txt_Birthday.Text & "', GENDER = '" & .Cmb_Gender.Text & "', BLOOD_TYPE = '" & .Cmb_BloodType.Text & "', HEIGHT = '" & .Cmb_Height.Text & "', WEIGHT = '" & .Txt_Weight.Text & "'"
                    SQL = SQL & ", RELIGION = '" & .Cmb_Religion.Text & "', CONTACT_NO = '" & .Txt_ContactNo.Text & "', EMAIL = '" & .Txt_Email.Text & "', APPL_ADD = '" & .Txt_ResiAdd.Text & "'"
                    SQL = SQL & ", EDUC_ATTAINMENT = '" & .Cmb_Educ_Attainment.Text & "', COURSE = '" & .Txt_Course.Text & "', YEAR_GRAD = '" & .Cmb_Grad_Year.Text & "', PREV_COMPANY = '" & .Txt_PrevComp.Text & "'"
                    SQL = SQL & ", POS_HELD = '" & .Txt_Pos_Held.Text & "', PREV_COMP_ADD = '" & .Txt_PrevComp_Add.Text & "', REF_BY = '" & .Cmb_Refer.Text & "', REF_REM = '" & .Txt_Refer_Rem.Text & "'"
                    SQL = SQL & ", CONTACT_PERSON = '" & .Txt_Contact_Name.Text & "', CONTACT_CP_NUMBER ='" & .Txt_Contact_Number.Text & "', CONTACT_RELATIONSHIP = '" & .Cmb_Relationship.Text & "', CONTACT_ADDRESS = '" & .Txt_Contact_Address.Text & "' "
                    SQL = SQL & " WHERE APPLICATION_ID = " & CInt(.Lbl_App_ID.Text) & ""

                    Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon) ' HR_APPLICATION_DTL
                    SQLcmd.ExecuteNonQuery()
                    SQLcmd.Dispose()

                    If GlobalVariables.Active_Status_Update = 1 Then
                        'GlobalVariables.sApplication_Global_Status = "Active"
                    Else
                        GlobalVariables.sApplication_Global_Status = "Application"
                    End If


                    MsgBox("Applicant Record was successfully updated!", vbInformation, "Saved")
                    Call Record_activity_log(Mod_GlobalVariables.GlobalVariables.sEmployee_ID_Logged_in, "Updated the Employee Information for Application ID " & .Lbl_App_ID.Text & "")

                ElseIf sNext_Status = "Interview" Then ' This will save the changes and move it to the next status

                    SQL2 = ""
                    SQL2 = "UPDATE HR_APPLICATION_HDR SET STATUS = 'Interview' WHERE APPLICATION_ID = " & CInt(.Lbl_App_ID.Text) & ""

                    Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL2, GlobalVariables.GlobalCon) ' HR_APPLICATION_HDR
                    SQLcmd2.ExecuteNonQuery()
                    SQLcmd2.Dispose()

                    If GlobalVariables.Active_Status_Update = 1 Then
                        'GlobalVariables.sApplication_Global_Status = "Active"
                    Else
                        GlobalVariables.sApplication_Global_Status = "Interview"
                    End If

                    MsgBox("Applicant Record was successfully saved and moved to the next Process.", vbInformation, "Saved and Moved")
                    ' Create a log
                    Call Record_activity_log(Mod_GlobalVariables.GlobalVariables.sEmployee_ID_Logged_in, "Updated the Employee Status to Interview for Application ID " & .Lbl_App_ID.Text & "")

                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating RECORD to TBL_Application_HDR or DTL")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub



    Public Sub Clear_Application_Boxes()

        With FRM_HRIS_APPLICATION

            ' Applicants
            .TxtSearch.Text = ""

            ' Application Boxes
            .Txt_FirstName.Text = ""
            .Txt_MiddleName.Text = ""
            .Txt_LastName.Text = ""
            .Txt_Maiden.Text = ""
            .Cmb_Civil_Status.SelectedIndex = -1
            .Txt_Birthday.Text = ""
            .Cmb_Gender.Text = ""
            .Cmb_Gender.SelectedIndex = -1
            .Cmb_BloodType.SelectedIndex = -1
            .Cmb_Religion.Text = ""
            .Cmb_Religion.SelectedIndex = -1
            .Cmb_Height.Text = ""
            .Cmb_Height.SelectedIndex = -1
            .Txt_Weight.Text = ""
            .Txt_ResiAdd.Text = ""
            .Txt_ContactNo.Text = ""
            .Txt_Email.Text = ""

            .Cmb_Educ_Attainment.SelectedIndex = -1
            .Txt_Course.Text = ""
            .Cmb_Grad_Year.Text = ""
            .Txt_PrevComp.Text = ""
            .Txt_Pos_Held.Text = ""
            .Txt_PrevComp_Add.Text = ""
            .Cmb_Refer.Text = ""
            .Cmb_Refer.SelectedIndex = -1
            .Txt_Refer_Rem.Text = ""

            .Txt_Contact_Name.Text = ""
            .Txt_Contact_Number.Text = ""
            .Txt_Contact_Address.Text = ""
            .Cmb_Relationship.SelectedIndex = -1


            '.Lbl_App_ID.Text = ""

            ' Interview boxes
            .Lbl_App_Interview_ID.Text = ""

            .Cmb_InterviewHR.Text = ""
            .TxtInterviewHR_Date.Text = ""
            .Cmb_Int_HR_Result.Text = ""
            .TxtInterview_HR_Remarks.Text = ""

            .Cmb_InterviewOP.Text = ""
            .Txt_Interview_OP_Date.Text = ""
            .Cmb_Int_OPR_Result.Text = ""
            .TxtInterview_Op_Remarks.Text = ""

            .Cmb_InterviewDIR.Text = ""
            .Txt_Interview_Dir_Date.Text = ""
            .Cmb_Int_DIR_Result.Text = ""
            .TxtInterview_Dir_Remarks.Text = ""


            ' Requirement
            .Lbl_Req_App_ID.Text = ""
            For i = 0 To .LV_Requirement_List.Items.Count - 1
                .LV_Requirement_List.Items(i).Checked = False
            Next

            ' For Completion
            .Lbl_Complete_App_ID.Text = ""
            .Txt_SSS.Text = ""
            .Txt_Pagibig.Text = ""
            .Txt_PhilHealth.Text = ""
            .Txt_TIN.Text = ""
            .Txt_ClientID.Text = ""
            .Txt_Employee_ID.Text = ""
            .TxtDate_Hired.Text = ""
            .Chk_GovIDs_NotAvailable.Checked = False
            .Lbl_ClientName.Text = ""

        End With



    End Sub


    Public Sub Show_record_According_to_Status(sApplication_Status As String, iApplication_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String



        Select Case sApplication_Status

            Case "Application"
                Try
                    SQL = "SELECT * FROM HR_APPLICATION_DTL A, HR_APPLICATION_HDR B WHERE A.APPLICATION_ID = " & iApplication_ID & " AND A.APPLICATION_ID = B.APPLICATION_ID"

                    da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
                    da.Fill(dt)

                    If dt.Rows.Count > 0 Then

                        Dim myRow As DataRow

                        For Each myRow In dt.Rows

                            With FRM_HRIS_APPLICATION

                                .Lbl_App_ID.Text = myRow.Item("A.APPLICATION_ID")

                                If myRow.Item("JOB_TYPE") = "Security_Personnel" Then
                                    .Opt_SecurityPersonnel.Checked = True
                                ElseIf myRow.Item("JOB_TYPE") = "Non_Security_Personnel" Then
                                    .Opt_Non_SecurityPersonnel.Checked = True
                                End If

                                .Txt_FirstName.Text = myRow.Item("FIRST_NAME")
                                .Txt_MiddleName.Text = myRow.Item("MIDDLE_NAME")
                                .Txt_LastName.Text = myRow.Item("LAST_NAME")
                                .Txt_Maiden.Text = myRow.Item("MAIDEN_NAME")
                                .Cmb_Civil_Status.Text = myRow.Item("CIVIL_STATUS")
                                .Txt_Birthday.Text = myRow.Item("BIRTH_DATE")
                                .Cmb_Gender.Text = myRow.Item("GENDER")
                                .Cmb_BloodType.Text = myRow.Item("BLOOD_TYPE")
                                .Cmb_Height.Text = myRow.Item("HEIGHT")
                                .Txt_Weight.Text = myRow.Item("WEIGHT")
                                .Cmb_Religion.Text = myRow.Item("RELIGION")
                                .Txt_ContactNo.Text = myRow.Item("CONTACT_NO")
                                .Txt_Email.Text = myRow.Item("EMAIL")
                                .Txt_ResiAdd.Text = myRow.Item("APPL_ADD")
                                .Cmb_Educ_Attainment.Text = myRow.Item("EDUC_ATTAINMENT")
                                .Txt_Course.Text = myRow.Item("COURSE")

                                .Cmb_Grad_Year.Text = myRow.Item("YEAR_GRAD")

                                .Txt_PrevComp.Text = myRow.Item("PREV_COMPANY")
                                .Txt_Pos_Held.Text = myRow.Item("POS_HELD")
                                .Txt_PrevComp_Add.Text = myRow.Item("PREV_COMP_ADD")
                                .Cmb_Refer.Text = myRow.Item("REF_BY")
                                .Txt_Refer_Rem.Text = myRow.Item("REF_REM")

                                .Txt_Contact_Name.Text = myRow.Item("CONTACT_PERSON")
                                .Txt_Contact_Number.Text = myRow.Item("CONTACT_CP_NUMBER")
                                .Cmb_Relationship.Text = myRow.Item("CONTACT_RELATIONSHIP")
                                .Txt_Contact_Address.Text = myRow.Item("CONTACT_ADDRESS")


                            End With
                        Next

                    Else


                    End If

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                GlobalVariables.GlobalCon.Close()

            Case "Interview"
                Try
                    SQL = "SELECT * FROM HR_INTERVIEW_DTL WHERE APPLICATION_ID = " & iApplication_ID & ""

                    da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
                    da.Fill(dt)

                    If dt.Rows.Count > 0 Then

                        Dim myRow As DataRow

                        For Each myRow In dt.Rows

                            With FRM_HRIS_APPLICATION

                                .Lbl_App_Interview_ID.Text = myRow.Item("APPLICATION_ID")

                                .Cmb_InterviewHR.Text = myRow.Item("INT_1_BY")
                                .TxtInterviewHR_Date.Text = myRow.Item("INT_1_DATE")
                                .Cmb_Int_HR_Result.Text = myRow.Item("INT_1_RESULT")
                                .TxtInterview_HR_Remarks.Text = myRow.Item("INT_1_REMARKS")

                                .Cmb_InterviewOP.Text = myRow.Item("INT_2_BY")
                                .Txt_Interview_OP_Date.Text = myRow.Item("INT_2_DATE")
                                .Cmb_Int_OPR_Result.Text = myRow.Item("INT_2_RESULT")
                                .TxtInterview_Op_Remarks.Text = myRow.Item("INT_2_REMARKS")

                                .Cmb_InterviewDIR.Text = myRow.Item("INT_3_BY")
                                .Txt_Interview_Dir_Date.Text = myRow.Item("INT_3_DATE")
                                .Cmb_Int_DIR_Result.Text = myRow.Item("INT_3_RESULT")
                                .TxtInterview_Dir_Remarks.Text = myRow.Item("INT_3_REMARKS")

                            End With
                        Next

                    Else

                    End If

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                GlobalVariables.GlobalCon.Close()

            Case "Requirement"
                Try
                    With FRM_HRIS_APPLICATION
                        .Lbl_Req_App_ID.Text = iApplication_ID

                        Dim sJob_Type As String
                        sJob_Type = Get_Job_Type(iApplication_ID)
                        Call Show_Application_Requirement_list(sJob_Type)


                        ' Loop and identify items checked
                        Dim iRow As Integer
                        .Prog_REQ.Value = 0


                        For Each item As ListViewItem In .LV_Requirement_List.Items

                            If item.Checked Then

                            Else ' No check
                                Call Show_Checked_Items_from_Application_Requirements(iApplication_ID, .LV_Requirement_List.Items(iRow).SubItems(0).Text, iRow)
                            End If
                            iRow = iRow + 1
                        Next

                        Dim iChecked As Double
                        iChecked = 0
                        For Each item As ListViewItem In .LV_Requirement_List.Items
                            If item.Checked Then
                                iChecked = iChecked + 1
                            End If

                        Next

                        .Prog_REQ.Value = (iChecked / CDbl(.LV_Requirement_List.Items.Count)) * 100

                    End With
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


                GlobalVariables.GlobalCon.Close()
            Case "For Completion"

                Call Show_For_Completion_Record(iApplication_ID)


        End Select






    End Sub

    Public Function Get_Application_Status()
        Dim sApplication_status As String

        With FRM_HRIS_APPLICATION.LV_Applicant_List

            sApplication_status = .SelectedItems(0).SubItems(3).Text

        End With

        Return sApplication_status

    End Function

    Public Sub Show_List_of_Applicants()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT A.APPLICATION_ID, B.FIRST_NAME, B.MIDDLE_NAME, B.LAST_NAME, B.DATE_REGISTERED,A.STATUS FROM HR_APPLICATION_HDR A, HR_APPLICATION_DTL B"
            SQL = SQL & " WHERE A.APPLICATION_ID = B.APPLICATION_ID AND A.STATUS in ('Application','Interview','Requirement', 'For Completion') ORDER BY B.DATE_REGISTERED"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HRIS_APPLICATION.LV_Applicant_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("APPLICATION_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".")
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("DATE_REGISTERED"), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("STATUS"))


                    Next
                End With
            Else
                FRM_HRIS_APPLICATION.LV_Applicant_List.Items.Clear()
                'MsgBox("No ongoing applications", vbInformation, "No Applicants")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Show Application List Error")
        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub


    Public Sub Insert_new_Application(sJob_Type As String, sDepartment As String, sPosition As String)

        With FRM_HRIS_APPLICATION


            Dim SQL, SQL2 As String


            Connect_to_MDB()

            GlobalVariables.Error_Encountered = 0

            Try
                With FRM_HRIS_APPLICATION
                    ' Generation of unique Application ID
                    GlobalVariables.New_Application_ID = Generate_Application_ID() ' Function to generate Application ID that will be used on the entire application process


                    ' HR_APPLICATION_DTL
                    SQL = "INSERT INTO HR_APPLICATION_DTL (APPLICATION_ID, FIRST_NAME, MIDDLE_NAME, LAST_NAME, MAIDEN_NAME,CIVIL_STATUS, BIRTH_DATE, GENDER, BLOOD_TYPE ,HEIGHT, WEIGHT,RELIGION, CONTACT_NO, EMAIL, APPL_ADD"
                    SQL = SQL & ", EDUC_ATTAINMENT, COURSE, YEAR_GRAD, PREV_COMPANY, POS_HELD, PREV_COMP_ADD, REF_BY, REF_REM, CONTACT_PERSON, CONTACT_CP_NUMBER, CONTACT_RELATIONSHIP,CONTACT_ADDRESS, DATE_REGISTERED)"
                    SQL = SQL & " VALUES (" & GlobalVariables.New_Application_ID & ",'" & Trim(.Txt_FirstName.Text) & "', '" & Trim(.Txt_MiddleName.Text) & "','" & Trim(.Txt_LastName.Text) & "', '" & .Txt_Maiden.Text & "','" & .Cmb_Civil_Status.Text & "','" & .Txt_Birthday.Text & "'"
                    SQL = SQL & " , '" & .Cmb_Gender.Text & "','" & .Cmb_BloodType.Text & "','" & .Cmb_Height.Text & "', '" & .Txt_Weight.Text & "','" & .Cmb_Religion.Text & "','" & Trim(.Txt_ContactNo.Text) & "', '" & .Txt_Email.Text & "', '" & .Txt_ResiAdd.Text & "'"
                    SQL = SQL & " , '" & .Cmb_Educ_Attainment.Text & "', '" & .Txt_Course.Text & "', '" & .Cmb_Grad_Year.Text & "', '" & .Txt_PrevComp.Text & "', '" & .Txt_Pos_Held.Text & "' "
                    SQL = SQL & " , '" & .Txt_PrevComp_Add.Text & "', '" & .Cmb_Refer.Text & "', '" & .Txt_Refer_Rem.Text & "'"
                    SQL = SQL & " ,'" & .Txt_Contact_Name.Text & "', '" & .Txt_Contact_Number.Text & "', '" & .Cmb_Relationship.Text & "', '" & .Txt_Contact_Address.Text & "'"
                    SQL = SQL & " ,'" & Now.ToString() & "')"


                    Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                    SQLcmd.ExecuteNonQuery()
                    SQLcmd.Dispose()

                    ' INSERT TO HR_APPLICATION_HDR THE ID AND STATUS

                    SQL2 = "INSERT INTO HR_APPLICATION_HDR (APPLICATION_ID, JOB_TYPE, EMP_DEPARTMENT, EMP_POSITION, STATUS, REMARKS) VALUES (" & GlobalVariables.New_Application_ID & ", '" & sJob_Type & "', '" & sDepartment & "', '" & sPosition & "', 'Application', 'NA')"

                    Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL2, GlobalVariables.GlobalCon)
                    SQLcmd2.ExecuteNonQuery()
                    SQLcmd2.Dispose()


                    ' MsgBox("New Applicant was successfully saved.", vbInformation, "Saved")
                    ' Create a log
                    Call Record_activity_log(Mod_GlobalVariables.GlobalVariables.sEmployee_ID_Logged_in, "Started Application Process for application id:" & GlobalVariables.New_Application_ID & "")

                End With
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "ERROR INSERTING NEW APPLICANT")
                GlobalVariables.GlobalCon.Close()
                GlobalVariables.Error_Encountered = 1
                Exit Sub
            End Try

            GlobalVariables.GlobalCon.Close()

            'Call Clear_Application_Boxes()


        End With

    End Sub

    Public Sub Insert_New_Interview_Data(iApplication_ID As Integer)

        With FRM_HRIS_APPLICATION


            Dim SQL As String

            Connect_to_MDB()

            Try
                With FRM_HRIS_APPLICATION

                    SQL = ""
                    SQL = "INSERT INTO HR_INTERVIEW_DTL (APPLICATION_ID, INT_1_BY, INT_1_DATE, INT_1_RESULT,INT_1_REMARKS,INT_2_BY, INT_2_DATE, INT_2_RESULT, INT_2_REMARKS,INT_3_BY, INT_3_DATE, INT_3_RESULT,INT_3_REMARKS)"
                    SQL = SQL & " VALUES (" & iApplication_ID & ", '" & .Cmb_InterviewHR.Text & "', '" & .TxtInterviewHR_Date.Text & "', '" & .Cmb_Int_HR_Result.Text & "', '" & .TxtInterview_HR_Remarks.Text & "'"
                    SQL = SQL & " , '" & .Cmb_InterviewOP.Text & "', '" & .Txt_Interview_OP_Date.Text & "', '" & .Cmb_Int_OPR_Result.Text & "', '" & .TxtInterview_Op_Remarks.Text & "'"
                    SQL = SQL & ", '" & .Cmb_InterviewDIR.Text & "', '" & .Txt_Interview_Dir_Date.Text & "', '" & .Cmb_Int_DIR_Result.Text & "', '" & .TxtInterview_Dir_Remarks.Text & "')"

                    Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                    SQLcmd.ExecuteNonQuery()
                    SQLcmd.Dispose()


                    MsgBox("Interview Information was successfully saved.", vbInformation, "Saved")

                End With
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "ERROR INSERTING NEW Interview Info with Application ID: " & iApplication_ID & "")

            End Try

            GlobalVariables.GlobalCon.Close()



        End With

    End Sub

    Public Sub Update_Interview_Data(iApplication_ID As Integer)


        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_HRIS_APPLICATION


                SQL = ""
                SQL = "UPDATE HR_INTERVIEW_DTL SET INT_1_BY = '" & .Cmb_InterviewHR.Text & "', INT_1_DATE = '" & .TxtInterviewHR_Date.Text & "', INT_1_RESULT = '" & .Cmb_Int_HR_Result.Text & "'"
                SQL = SQL & ", INT_2_BY = '" & .Cmb_InterviewOP.Text & "', INT_2_DATE = '" & .Txt_Interview_OP_Date.Text & "', INT_2_RESULT = '" & .Cmb_Int_OPR_Result.Text & "', INT_2_REMARKS = '" & .TxtInterview_HR_Remarks.Text & "'"
                SQL = SQL & ", INT_3_BY = '" & .Cmb_InterviewDIR.Text & "', INT_3_DATE = '" & .Txt_Interview_Dir_Date.Text & "', INT_3_RESULT = '" & .Cmb_Int_DIR_Result.Text & "', INT_3_REMARKS= '" & .TxtInterview_Dir_Remarks.Text & "'"
                SQL = SQL & " WHERE APPLICATION_ID = " & iApplication_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Interview record was successfully saved!", vbInformation, "Saved")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating RECORD to HR_INTERVIEW_DTL")

        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

End Module
