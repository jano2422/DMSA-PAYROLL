Imports System.Data.OleDb
Imports System.IO
Module Mod_FRM_CLIENT_HDR

    Public Function Count_Active_Sub_Client_of_Main_Client(sMain_Client_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT COUNT(*) FROM TBL_CLIENT_SUB WHERE MAIN_CLIENT_ID = " & sMain_Client_ID & " AND SUB_CLIENT_STATUS = 'Active'
"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow
                For Each myRow In dt.Rows

                    If myRow.Item(0) = 0 Then
                        Return 0
                    Else
                        Return 1
                    End If


                Next
                Return 0
            Else



            End If

        Catch ex As Exception
            Return -1
            MsgBox(ex.ToString, vbCritical, "Count Inactive Sub Client")
        End Try

        GlobalVariables.GlobalCon.Close()





    End Function
    Public Sub Insert_Client_Status_History(iSub_Client_ID As Integer, sNew_Status As String)
        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "INSERT INTO TBL_CLIENT_STATUS_HISTORY (SUB_CLIENT_ID, SUB_CLIENT_STATUS_CHANGE, EFFECTIVITY_DATE, REASON)"
                SQL = SQL & " VALUES (" & iSub_Client_ID & ", '" & sNew_Status & "', '" & GlobalVariables.dClient_Deactivation_Date & "', '" & GlobalVariables.sReason_for_Deactivation_Activation & "')"


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving historical client change in status")

        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub


    Public Sub Activate_Deactivate_Sub_Client(iSub_Client_ID As Integer, sClient_Desc As String, sStatus As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "Update TBL_CLIENT_SUB set SUB_CLIENT_STATUS = '" & sStatus & "' where sub_client_id = " & iSub_Client_ID & ""

                Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd2.ExecuteNonQuery()
                SQLcmd2.Dispose()

                Call Insert_Client_Status_History(iSub_Client_ID, sStatus)

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Set to " & sStatus & " for " & sClient_Desc)

                If sStatus = "Inactive" Then
                    MsgBox(sClient_Desc & " was successfully Deactivated! ", vbInformation, "Deactivated")
                Else
                    MsgBox(sClient_Desc & " was successfully Re-Activated! ", vbInformation, "Re-Activated")
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Re or dE Activating Main Client")

        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub


    Public Sub Activate_Deactivate_Main_Client(iMain_Client_ID As Integer, sClient_Desc As String, sStatus As String)

        Dim SQL, SQL2 As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "Update TBL_CLIENT_MAIN set Global_Status = '" & sStatus & "' where main_client_id = " & iMain_Client_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Set status to " & sStatus & " for " & sClient_Desc & "")

                If sStatus = "Inactive" Then
                    MsgBox(sClient_Desc & " was successfully Deactivated! ", vbInformation, "Deactivated")
                Else
                    MsgBox(sClient_Desc & " was successfully Re-Activated! ", vbInformation, "Re-Activated")
                End If


            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error deactivating Main Client")

        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub

    Public Sub Update_Contract_Details(iRef_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "Update TBL_CLIENT_CONTRACT set START_CONTRACT_DATE = '" & .TxtContract_Start_Date.Text & "', END_CONTRACT_DATE = '" & .TxtContract_End_Date.Text & "', REMARKS = '" & .Txt_Contract_Remarks.Text & "' where ID = " & iRef_ID & " "


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                'MsgBox("Contract Details were successfully updated", vbInformation, "Updated!")
                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Updated the Client Contract")


                GlobalVariables.sSource_Path = ""
                GlobalVariables.Contract_New_File_Destination_Path = ""

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error updating Sub Client contract!")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub Show_Contract_Details_In_Textboxes(iRef_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "select * from TBL_CLIENT_CONTRACT where ID = " & iRef_ID & ""

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS


                Dim myRow As DataRow
                For Each myRow In dt.Rows

                    FRM_CLIENT_HDR.TxtContract_Start_Date.Text = myRow.Item("START_CONTRACT_DATE")
                    FRM_CLIENT_HDR.TxtContract_End_Date.Text = myRow.Item("END_CONTRACT_DATE")
                    FRM_CLIENT_HDR.Txt_Contract_Remarks.Text = myRow.Item("REMARKS")
                    'FRM_CLIENT_HDR.Lbl_Attachment_Path.Text = myRow.Item("REMARKS")



                Next

            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Contract details")
        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub
    Public Sub Delete_Contract_Record(iRef_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "Delete from TBL_CLIENT_CONTRACT where ID = " & iRef_ID & " "


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                MsgBox("Attachment was successful deleted", vbInformation, "Deleted!")
                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Deleted a license record")

                GlobalVariables.sSource_Path = ""
                GlobalVariables.Contract_New_File_Destination_Path = ""

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving Sub Client contract!")

        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub
    Public Sub Show_Contract_Attachment(iSub_Client_ID As Integer)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "select * from TBL_CLIENT_CONTRACT where SUB_CLIENT_ID = " & iSub_Client_ID & ""

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_CLIENT_HDR.LV_Contract_Attachments

                    Dim myRow As DataRow
                    Dim iCount As Integer
                    iCount = 0

                    .Items.Clear()


                    For Each myRow In dt.Rows
                        iCount = iCount + 1
                        .Items.Add(iCount)




                        Dim sString_Length, iCounter As Integer
                        Dim sPath, sFile_Name As String

                        sFile_Name = ""
                        iCounter = 0

                        sString_Length = Len(myRow.Item("CONTRACT_PATH"))
                        sPath = myRow.Item("CONTRACT_PATH")

                        For i = 0 To sString_Length

                            If Mid(sPath, sString_Length, 1) <> "\" Then
                                iCounter = iCounter + 1
                            Else
                                sFile_Name = Right(sPath, iCounter)
                                Exit For
                            End If

                            sString_Length = sString_Length - 1
                        Next

                        .Items(.Items.Count - 1).SubItems.Add(sFile_Name)
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ID"))

                    Next
                End With
            Else

                FRM_CLIENT_HDR.LV_Contract_Attachments.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Contract Attachments - check null in DB")
        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub Insert_Contract_Information(iSub_Client_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "INSERT INTO TBL_CLIENT_CONTRACT (SUB_CLIENT_ID, START_CONTRACT_DATE, END_CONTRACT_DATE, CONTRACT_STATUS, REMARKS, CONTRACT_PATH)"
                SQL = SQL & " VALUES (" & iSub_Client_ID & ", '" & .TxtContract_Start_Date.Text & "', '" & .TxtContract_End_Date.Text & "','Active', '" & .Txt_Contract_Remarks.Text & "' , '" & GlobalVariables.Contract_New_File_Destination_Path & "')"


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                'Copy the PDF file to Destination Path
                My.Computer.FileSystem.CopyFile(GlobalVariables.sSource_Path, GlobalVariables.Contract_New_File_Destination_Path)

                'MsgBox("Attachment was successful!", vbInformation, "Attached!")

                GlobalVariables.sSource_Path = ""
                GlobalVariables.Contract_New_File_Destination_Path = ""

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving Sub Client contract!")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub Attach_Contract()


        With FRM_CLIENT_HDR
            Try
                .OpenFileDialog1.Title = "Upload scanned Security Guard License ID"
                'OpenFileDialog1.InitialDirectory = ""
                '.OpenFileDialog1.FileName = ".pdf"
                '.OpenFileDialog1.Filter = "PDF Files |*.pdf"a

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

                ' Naming convention = SUB_CLIENT_ID + "Contract" + Effectivity_Date
                Dim newFilePath As String = Path.Combine(Application.StartupPath & "\Attachments\Client_Contract\", GlobalVariables.Selected_Sub_Client_ID & "_" & formattedDateTime & Right(GlobalVariables.sFileName, 4))

                'GlobalVariables.sDestination_Path = newFilePath
                GlobalVariables.Contract_New_File_Destination_Path = newFilePath

                .Lbl_Attachment_Path.Text = GlobalVariables.sFileName
                '.Lbl_License_View_Attachment.Text = GlobalVariables.sFileName

            Else

                MsgBox("Please Select a valid .pdf or .jpg file.", vbCritical, "Nothing was selected")
                Exit Sub
            End If

            ' Destination + JPG filename ( Complete Destination path )


            'Dim sDriveX As String = ConfigurationSettings.AppSettings("FileServer")



        End With
    End Sub


    Public Sub Show_Main_Client_Name_and_Status(iMain_Client_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM TBL_CLIENT_MAIN WHERE MAIN_CLIENT_ID = " & iMain_Client_ID & ""

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                With FRM_CLIENT_HDR

                    Dim myRow As DataRow

                    For Each myRow In dt.Rows

                        .Cmb_MainClientName.Text = myRow.Item("MAIN_CLIENT_NAME")

                        .Cmb_ClientType.Text = myRow.Item("CLIENT_TYPE")

                        If myRow.Item("GLOBAL_STATUS") = "Active" Then
                            .Lbl_Main_Client_Status.ForeColor = Color.Lime
                        Else
                            .Lbl_Main_Client_Status.ForeColor = Color.Red
                        End If


                        .Lbl_Main_Client_Status.Text = myRow.Item("GLOBAL_STATUS")

                    Next
                End With
            Else


            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Client Record")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Sub Update_Main_Client(iMain_Client_ID As Integer)
        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "UPDATE TBL_CLIENT_MAIN SET MAIN_CLIENT_NAME = '" & .Cmb_MainClientName.Text & "', CLIENT_TYPE = '" & .Cmb_ClientType.Text & "' WHERE MAIN_CLIENT_ID = " & iMain_Client_ID & ""


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Client record was successfully updated!", vbInformation, "Updated!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error updating Main Client record")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub


    Public Sub Add_New_Main_Client(sMian_Client_Name As String, sClient_Type As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "INSERT INTO TBL_CLIENT_MAIN (MAIN_CLIENT_NAME, CLIENT_TYPE, GLOBAL_STATUS) VALUES ( '" & sMian_Client_Name & "', '" & sClient_Type & "', 'Active')"


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Client record was successfully saved!", vbInformation, "Saved!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Inserting new Main Client record")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub



    Public Sub Delete_Client_Record(iClient_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "DELETE FROM TBL_CLIENT_SUB WHERE CLIENT_ID = " & iClient_ID & ""


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Client record was successfully deleted!", vbInformation, "Deleted!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error deleting Client record")

        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub UPDATE_SUB_CLIENT_INFO(iSubClient_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "Update TBL_CLIENT_SUB set SUB_CLIENT_NAME = '" & .Txt_SubClientName.Text & "', ADDRESS = '" & .Txt_Sub_Client_Address.Text & "'"
                SQL = SQL & ", SCHED_TYPE = '" & .Cmb_SchedType.Text & "', CONTACT_PERSON = '" & .Txt_Contact_Person.Text & "', CONTACT_NUMBER = '" & .Txt_Contact_CPNumber.Text & "', CONTACT_EMAIL = '" & .Txt_Contact_Email.Text & "'"
                SQL = SQL & " WHERE SUB_CLIENT_ID = " & iSubClient_ID & " "


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Sub Client record was successfully updated!", vbInformation, " Saved!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error updating Sub Client record")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub Show_Searched_Main_Client(sMain_Client_Name, sGlobal_Status)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            If sGlobal_Status = "All" Then
                SQL = "select * from TBL_CLIENT_MAIN where MAIN_CLIENT_NAME LIKE '%" & sMain_Client_Name & "%' ORDER BY MAIN_CLIENT_NAME ASC"
            Else
                SQL = "select * from TBL_CLIENT_MAIN where MAIN_CLIENT_NAME LIKE '%" & sMain_Client_Name & "%' and GLOBAL_STATUS = '" & sGlobal_Status & "' ORDER BY MAIN_CLIENT_NAME ASC"
            End If


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_CLIENT_HDR.LV_Main_Client_List

                    Dim myRow As DataRow
                    Dim iCount As Integer
                    iCount = 0

                    .Items.Clear()


                    For Each myRow In dt.Rows
                        iCount = iCount + 1
                        .Items.Add(iCount)

                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("MAIN_CLIENT_NAME"))

                        If myRow.Item("GLOBAL_STATUS") = "Inactive" Then
                            .Items(.Items.Count - 1).ForeColor = Color.Red
                        Else
                            .Items(.Items.Count - 1).ForeColor = Color.Black
                        End If

                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("GLOBAL_STATUS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("MAIN_CLIENT_ID")) ' Reference ID

                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_CLIENT_HDR.LV_Main_Client_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Main Client List")
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub


    Public Sub Insert_New_Sub_Client_Record(iClient_ID As Integer, iMaint_Client_ID As Integer)

        Dim SQL As String

        Connect_to_MDB()

        With FRM_CLIENT_HDR

            Try

                SQL = "INSERT INTO TBL_CLIENT_SUB (SUB_CLIENT_ID, MAIN_CLIENT_ID, SUB_CLIENT_NAME, ADDRESS, SUB_CLIENT_STATUS, SCHED_TYPE, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL)"
                SQL = SQL & " VALUES (" & iClient_ID & "," & iMaint_Client_ID & ", '" & .Txt_SubClientName.Text & "', '" & .Txt_Sub_Client_Address.Text & "','Active', '" & .Cmb_SchedType.Text & "', '" & .Txt_Contact_Person.Text & "', '" & .Txt_Contact_CPNumber.Text & "', '" & .Txt_Contact_Email.Text & "')"


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                MsgBox("New Sub Client was successfully saved.", vbInformation, "Saved")


            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error Inserting New Sub Client Record")

            End Try

            GlobalVariables.GlobalCon.Close()

        End With

    End Sub

    Public Function Generate_New_Client_ID()
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        SQL = "SELECT MAX(SUB_CLIENT_ID) AS NEW_SUB_CLIENT_ID FROM TBL_CLIENT_SUB"

        Try

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow

                For Each myRow In dt.Rows


                    Return myRow.Item("NEW_SUB_CLIENT_ID") + 1


                Next

            Else

                MsgBox("No record from Client Reference Table. Please inform your system developer.", vbInformation, "Error in Generation")

            End If

        Catch ex As Exception
            Return 0
            MsgBox(ex.ToString, vbCritical, "Error in Generating Client ID")

        End Try

        GlobalVariables.GlobalCon.Close()
        Return "0"
    End Function

    Public Sub Clear_Client_Management_Textboxes(container As Control)

        With FRM_CLIENT_HDR

            For Each ctrl As Control In container.Controls
                If TypeOf ctrl Is TextBox Then
                    Dim textBox As TextBox = DirectCast(ctrl, TextBox)
                    textBox.Text = String.Empty
                ElseIf ctrl.HasChildren Then
                    Clear_Client_Management_Textboxes(ctrl)
                End If
            Next

            .Cmb_ClientType.SelectedIndex = -1
            .Cmb_SchedType.SelectedIndex = -1

            .LV_Contract_Attachments.Items.Clear()

        End With

    End Sub

    Public Sub Show_Sub_Client_Info_in_Textboxes(iClient_ID As Integer)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            'SQL = "SELECT * FROM TBL_CLIENT_SUB WHERE SUB_CLIENT_ID = " & iClient_ID & ""

            SQL = "SELECT * FROM TBL_CLIENT_MAIN A, TBL_CLIENT_SUB B WHERE B.SUB_CLIENT_ID = " & iClient_ID & " and A.MAIN_CLIENT_ID = B.MAIN_CLIENT_ID"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                With FRM_CLIENT_HDR

                    Dim myRow As DataRow

                    For Each myRow In dt.Rows

                        '.Cmb_MainClientName.Text = myRow.Item("MAIN_CLIENT_NAME")

                        .Txt_Sub_Client_ID.Text = myRow.Item("SUB_CLIENT_ID")
                        .Txt_SubClientName.Text = myRow.Item("SUB_CLIENT_NAME")
                        .Txt_Sub_Client_Address.Text = myRow.Item("ADDRESS")
                        .Cmb_SchedType.Text = myRow.Item("SCHED_TYPE")
                        '.Cmb_ClientType.Text = myRow.Item("CLIENT_TYPE")

                        .Txt_Contact_Person.Text = myRow.Item("CONTACT_PERSON")
                        .Txt_Contact_CPNumber.Text = myRow.Item("CONTACT_NUMBER")
                        .Txt_Contact_Email.Text = myRow.Item("CONTACT_EMAIL")

                    Next
                End With
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Client Record")
        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub Show_Sub_Client_List(sMain_Client_ID As Integer)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM TBL_CLIENT_SUB WHERE MAIN_CLIENT_ID = " & sMain_Client_ID & " "

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_CLIENT_HDR.LV_Sub_Client_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("SUB_CLIENT_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ADDRESS"))

                        If myRow.Item("SUB_CLIENT_STATUS") = "Active" Then
                            .Items(.Items.Count - 1).ForeColor = Color.Black
                        Else
                            .Items(.Items.Count - 1).ForeColor = Color.Red
                        End If


                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_STATUS"))

                    Next

                    .Enabled = True
                End With



            Else
                MsgBox("No Sub Clients yet for this Main Client.", vbExclamation, "No records")
                FRM_CLIENT_HDR.LV_Sub_Client_List.Items.Clear() ' Sub Clients
                FRM_CLIENT_HDR.LV_Sub_Client_List.Enabled = False

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Sub Client List")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Sub Clear_Sub_Client_Info_in_Textboxes()


        With FRM_CLIENT_HDR

            .Cmb_MainClientName.Text = ""

            .Txt_Sub_Client_ID.Text = ""
            .Txt_SubClientName.Text = ""
            .Txt_Sub_Client_Address.Text = ""
            .Cmb_SchedType.SelectedIndex = -1
            .Cmb_ClientType.SelectedIndex = -1

            .Txt_Contact_Person.Text = ""
            .Txt_Contact_CPNumber.Text = ""
            .Txt_Contact_Email.Text = ""


        End With



    End Sub


End Module
