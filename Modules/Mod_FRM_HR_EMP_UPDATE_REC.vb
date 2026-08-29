Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Module Mod_FRM_HR_EMP_UPDATE_REC

    Private Class ClientMovementPeriod
        Public Property ID As Integer
        Public Property DateStarted As Date
        Public Property DateEnded As Date
    End Class






    Public Sub Update_Employee_Record_New_Client_Assignment(sEmployee_ID As String, iNewClient_ID As Integer)
        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = "UPDATE HR_EMPLOYEE_RECORD_HDR SET SUB_CLIENT_ID = " & iNewClient_ID & " WHERE EMPLOYEE_ID = '" & sEmployee_ID & "'"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                ' MsgBox("Insurance record was successfully updated!", vbInformation, "Saved!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error updating EMPLOYEE HDR record")

        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub

    Public Sub Show_Status_Change_History(sEmployee_ID As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM HR_STATUS_CHANGE_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' "

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC.LV_Status_History

                    Dim myRow As DataRow
                    Dim iROw As Integer
                    .Items.Clear()
                    iROw = 1

                    For Each myRow In dt.Rows

                        .Items.Add(iROw)
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("EMPLOYMENT_STATUS"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("EFFECTIVITY_DATE"), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("REMARKS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ID"))

                        iROw = iROw + 1

                    Next
                End With
            Else
                'MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_EMP_UPDATE_REC.LV_Status_History.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbExclamation, "Status History Error")
        End Try

    End Sub

    Public Sub Delete_Employee_Insurance_record(iRef_ID As Integer)
        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "DELETE FROM HR_INSURANCE_DTL WHERE  ID = " & iRef_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Employee Insurance record was successfully deleted!", vbInformation, "Deleted!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Deleting Employee Insurance record")

        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Sub Clear_Insurance_Textboxes()

        With FRM_EMP_UPDATE_REC

            .Txt_Insurance_DateStart.Text = ""
            .Txt_Insurance_DateEnd.Text = ""
            .Txt_Insurance_Policy.Text = ""
            .Cmb_Insurance_CompName.Text = ""
            GlobalVariables.sInsurance_Reference_ID = ""


        End With


    End Sub

    Public Sub Update_Employee_Insurance_Record(sEmployee_ID As String, iRef_ID As Integer)
        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "UPDATE HR_INSURANCE_DTL SET START_DATE = '" & .Txt_Insurance_DateStart.Text & "', END_DATE = '" & .Txt_Insurance_DateEnd.Text & "', POLICY_NUMBER = '" & .Txt_Insurance_Policy.Text & "', INSURANCE_COMPANY = '" & .Cmb_Insurance_CompName.Text & "'"
                SQL = SQL & " WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' and ID = " & iRef_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Insurance record was successfully updated!", vbInformation, "Saved!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error updating Insurance record")

        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub
    Public Sub Insert_New_Insurance_Record(sEmployee_ID As String)


        With FRM_EMP_UPDATE_REC


            Dim SQL As String

            Connect_to_MDB()

            Try

                SQL = "INSERT INTO HR_INSURANCE_DTL (EMPLOYEE_ID, START_DATE, END_DATE, POLICY_NUMBER, INSURANCE_COMPANY)"
                SQL = SQL & " VALUES ('" & sEmployee_ID & "', '" & .Txt_Insurance_DateStart.Text & "', '" & .Txt_Insurance_DateEnd.Text & "', '" & .Txt_Insurance_Policy.Text & "', '" & .Cmb_Insurance_CompName.Text & "')"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                MsgBox("New Insurance Record record was successfully saved.", vbInformation, "Saved")


            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error Inserting Insurance Record")

            End Try

            GlobalVariables.GlobalCon.Close()


        End With


    End Sub


    Public Sub Show_Insurance_recod_To_Texboxes(sEmployee_ID As String, iRef_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * from HR_INSURANCE_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' and ID = " & iRef_ID & ""

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC

                    Dim myRow As DataRow

                    For Each myRow In dt.Rows

                        .Txt_Insurance_DateStart.Text = Format(CDate(myRow.Item("START_DATE")), "dd-MMM-yyyy")
                        .Txt_Insurance_DateEnd.Text = Format(CDate(myRow.Item("END_DATE")), "dd-MMM-yyyy")
                        .Txt_Insurance_Policy.Text = myRow.Item("POLICY_NUMBER")
                        .Cmb_Insurance_CompName.Text = myRow.Item("INSURANCE_COMPANY")


                    Next
                End With
            Else


            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Show Medical Record Error")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub
    Public Sub Show_Insurance_Record_To_Listview(sEmployee_ID As String)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select * From HR_INSURANCE_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' ORDER BY ID DESC"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC.LV_Insurance_List

                    Dim myRow As DataRow
                    Dim iROw As Integer
                    .Items.Clear()
                    iROw = 1

                    For Each myRow In dt.Rows

                        .Items.Add(iROw)
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("START_DATE")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("END_DATE")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("INSURANCE_COMPANY"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("POLICY_NUMBER"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ID"))

                        iROw = iROw + 1

                    Next
                End With
            Else
                'MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_EMP_UPDATE_REC.LV_Insurance_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub



    Public Sub Show_Medical_recod_To_Texboxes(sEmployee_ID As String, iRef_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * from HR_MEDICAL_RECORDS_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' and ID = " & iRef_ID & ""

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC

                    Dim myRow As DataRow

                    For Each myRow In dt.Rows

                        .Cmb_Hospital.Text = myRow.Item("HOSPITAL_NAME")
                        .Cmb_Medical_Type.Text = myRow.Item("MED_TYPE")
                        .Txt_Medical_Date.Text = Format(CDate(myRow.Item("MED_DATE")), "dd-MMM-yyyy")
                        .Cmb_Drug_Test.Text = myRow.Item("DRUG_TEST")

                        .Txt_Medical_Exp_Date.Text = Format(CDate(myRow.Item("MED_EXP_DATE")), "dd-MMM-yyyy")

                        If myRow.Item("WITH_FINDINGS") = "Yes" Then
                            .Chk_Medical_Findings.Checked = True
                        Else
                            .Chk_Medical_Findings.Checked = False
                        End If
                        .Txt_Medical_Remarks.Text = myRow.Item("REMARKS")

                    Next
                End With
            Else


            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Show Medical Record Error")
        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub
    Public Sub Show_Medical_Record_to_Listview(sEmployee_ID As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select * From HR_MEDICAL_RECORDS_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' ORDER BY ID DESC"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC.LV_Medical_List

                    Dim myRow As DataRow
                    Dim iROw As Integer
                    .Items.Clear()
                    iROw = 1

                    For Each myRow In dt.Rows

                        .Items.Add(iROw)
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("MED_DATE")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("MED_TYPE"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("REMARKS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ID"))

                        iROw = iROw + 1

                    Next
                End With
            Else
                'MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_EMP_UPDATE_REC.LV_Medical_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub Clear_Medical_Record_Textboxes()

        With FRM_EMP_UPDATE_REC

            .Cmb_Hospital.Text = ""
            .Cmb_Medical_Type.SelectedIndex = -1
            .Cmb_Drug_Test.SelectedIndex = -1
            .Txt_Medical_Remarks.Text = ""
            .Lbl_Medical_Ref_ID.Text = "Ref_ID"
            .Chk_Medical_Findings.Checked = False
            .Txt_Medical_Exp_Date.Text = ""
            .Txt_Medical_Date.Text = ""

        End With



    End Sub

    Public Sub Delete_Medical_Record(iRef_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "DELETE FROM HR_MEDICAL_RECORDS_DTL WHERE  ID = " & iRef_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Employee Medical record was successfully deleted!", vbInformation, "Deleted!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Deleting Employee Medical record")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub Update_Medical_Record(sId As String)
        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC

                Dim sWithFindings As String = If(.Chk_Medical_Findings.Checked, "Yes", "None")

                SQL = "UPDATE HR_MEDICAL_RECORDS_DTL SET " &
                  "MED_TYPE = ?, " &
                  "WITH_FINDINGS = ?, " &
                  "REMARKS = ?, " &
                  "MED_DATE = ?, " &
                  "DRUG_TEST = ?, " &
                  "HOSPITAL_NAME = ?, " &
                  "MED_EXP_DATE = ? " &
                  "WHERE ID = ?"

                Using SQLcmd As New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                    SQLcmd.Parameters.AddWithValue("?", .Cmb_Medical_Type.Text)
                    SQLcmd.Parameters.AddWithValue("?", sWithFindings)
                    SQLcmd.Parameters.AddWithValue("?", .Txt_Medical_Remarks.Text)
                    SQLcmd.Parameters.AddWithValue("?", .Txt_Medical_Date.Text)
                    SQLcmd.Parameters.AddWithValue("?", .Cmb_Drug_Test.Text)
                    SQLcmd.Parameters.AddWithValue("?", .Cmb_Hospital.Text)
                    SQLcmd.Parameters.AddWithValue("?", .Txt_Medical_Exp_Date.Text)
                    SQLcmd.Parameters.AddWithValue("?", sId)

                    SQLcmd.ExecuteNonQuery()
                End Using

                MsgBox("Medical record was successfully updated!", vbInformation, "Saved")
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating Medical Record")
        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub


    Public Sub Insert_New_Medical_Record(sEmployee_ID As String)


        With FRM_EMP_UPDATE_REC


            Dim SQL As String

            Connect_to_MDB()

            Try

                Dim sWithFindings As String
                If .Chk_Medical_Findings.Checked = True Then
                    sWithFindings = "Yes"
                Else
                    sWithFindings = "None"
                End If


                SQL = "INSERT INTO HR_MEDICAL_RECORDS_DTL (EMPLOYEE_ID, MED_TYPE, WITH_FINDINGS,REMARKS, MED_DATE, DRUG_TEST, HOSPITAL_NAME, MED_EXP_DATE)"
                SQL = SQL & " VALUES ('" & sEmployee_ID & "', '" & .Cmb_Medical_Type.Text & "', '" & sWithFindings & "', '" & .Txt_Medical_Remarks.Text & "'"
                SQL = SQL & ", '" & .Txt_Medical_Date.Text & "', '" & .Cmb_Drug_Test.Text & "', '" & .Cmb_Hospital.Text & "', '" & .Txt_Medical_Exp_Date.Text & "')"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                MsgBox("New Medical Record record was successfully saved.", vbInformation, "Saved")

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "New medical record for employee: " & sEmployee_ID & "")

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error Inserting Medical Record")

            End Try

            GlobalVariables.GlobalCon.Close()


        End With





    End Sub

    Public Function Get_Latest_Client_Assignment(sEmployee_ID As String)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select max(ID) AS LATEST_ASSIGNMENT_ID from HR_EMPLOYEE_CLIENT_TRANSFER_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' "

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow

                For Each myRow In dt.Rows

                    Return myRow.Item("LATEST_ASSIGNMENT_ID")

                Next

            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
            MsgBox(ex.ToString, vbCritical, "Error in getting MAX client assignment")
        End Try

        GlobalVariables.GlobalCon.Close()

        Return 0

    End Function



    Public Sub Clear_Client_Textboxes()

        With FRM_EMP_UPDATE_REC

            .Txt_ClientID.Text = ""
            .Txt_Client_Start_Date.Text = ""
            .Txt_Client_End_Date.Text = ""
            .Txt_selected_Client_ID.Text = ""
            .Lbl_Client_Ref_ID.Text = ""
            .Lbl_ClientName.Text = ""
            .LblClient_Address.Text = ""

        End With

    End Sub

    Public Sub Delete_Client_History(i_RefID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "DELETE FROM HR_EMPLOYEE_CLIENT_TRANSFER_DTL WHERE  ID = " & i_RefID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Employee client record was successfully deleted!", vbInformation, "Deleted!")

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Deleted a client record history")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Deleting Employee Client History")

        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub

    Public Sub Show_Employee_Client_History_at_Client_Change(sEmployee_ID As String)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select * From HR_EMPLOYEE_CLIENT_TRANSFER_DTL A, TBL_CLIENT_SUB B"
            SQL = SQL & " Where A.SUB_CLIENT_ID = B.SUB_CLIENT_ID And A.EMPLOYEE_ID = '" & sEmployee_ID & "' ORDER BY A.DATE_STARTED DESC, A.ID DESC"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC.LV_Client_History

                    Dim myRow As DataRow
                    Dim latestMovementID As Integer = CInt(dt.Rows(0).Item("ID"))

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("A.SUB_CLIENT_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ADDRESS"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("DATE_STARTED")), "dd-MMM-yyyy"))

                        ' Equal dates can also mean a valid one-day assignment. Only the latest
                        ' movement may use the legacy equal-date value as "Up to present".
                        If CInt(myRow.Item("ID")) = latestMovementID AndAlso
                           CDate(myRow.Item("DATE_STARTED")).Date = CDate(myRow.Item("DATE_ENDED")).Date Then
                            .Items(.Items.Count - 1).SubItems.Add("Up to present")
                        Else
                            .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("DATE_ENDED")), "dd-MMM-yyyy"))
                        End If

                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ID"))



                    Next
                End With
            Else
                'MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_EMP_UPDATE_REC.LV_Client_History.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Function Add_New_Client_Historical_Record(sEmployee_ID As String, sNew_Client_ID As Integer) As Boolean
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC
                Dim startDate As Date
                Dim endDate As Date

                If Not TryParseClientMovementDate(.Txt_Client_Start_Date.Text, startDate) Then
                    MsgBox("Please enter a valid client movement start date.", vbExclamation, "Invalid Start Date")
                    Return False
                End If

                If Not TryParseClientMovementDate(.Txt_Client_End_Date.Text, endDate) Then
                    MsgBox("Please enter a valid client movement end date.", vbExclamation, "Invalid End Date")
                    Return False
                End If

                startDate = startDate.Date
                endDate = endDate.Date

                If endDate < startDate Then
                    MsgBox("The client movement end date cannot be earlier than its start date.", vbExclamation, "Invalid Date Range")
                    Return False
                End If

                Dim isCurrentMovement As Boolean = (startDate = endDate)
                Dim existingMovements As List(Of ClientMovementPeriod)

                Using transaction As OleDbTransaction = GlobalVariables.GlobalCon.BeginTransaction()
                    Try
                        existingMovements = LoadClientMovementPeriods(sEmployee_ID, transaction)

                        Dim currentMovementID As Integer = GetCurrentClientMovementID(existingMovements)

                        If isCurrentMovement AndAlso existingMovements.Count > 0 Then
                            Dim latestStartDate As Date = existingMovements.Max(Function(movement) movement.DateStarted)

                            If startDate <= latestStartDate Then
                                transaction.Rollback()
                                MsgBox(
                                    "An up-to-present movement must start after the latest existing movement (" &
                                    latestStartDate.ToString("dd-MMM-yyyy") & ").",
                                    vbExclamation,
                                    "Invalid Current Movement")
                                Return False
                            End If
                        End If

                        Dim conflictingMovement As ClientMovementPeriod = Nothing
                        If TryFindOverlappingClientMovement(
                            startDate,
                            endDate,
                            isCurrentMovement,
                            existingMovements,
                            0,
                            currentMovementID,
                            isCurrentMovement,
                            conflictingMovement) Then

                            transaction.Rollback()
                            ShowClientMovementOverlapError(conflictingMovement, currentMovementID)
                            Return False
                        End If

                        If isCurrentMovement Then
                            CloseExistingCurrentClientMovements(
                                sEmployee_ID,
                                startDate,
                                existingMovements,
                                transaction)
                        End If

                        Const insertSql As String =
                            "INSERT INTO HR_EMPLOYEE_CLIENT_TRANSFER_DTL " &
                            "(EMPLOYEE_ID, SUB_CLIENT_ID, DATE_STARTED, DATE_ENDED) " &
                            "VALUES (?, ?, ?, ?)"

                        Using insertCommand As New OleDbCommand(insertSql, GlobalVariables.GlobalCon, transaction)
                            insertCommand.Parameters.Add("?", OleDbType.VarWChar).Value = sEmployee_ID
                            insertCommand.Parameters.Add("?", OleDbType.Integer).Value = sNew_Client_ID
                            insertCommand.Parameters.Add("?", OleDbType.Date).Value = startDate
                            insertCommand.Parameters.Add("?", OleDbType.Date).Value = endDate
                            insertCommand.ExecuteNonQuery()
                        End Using

                        Const updateHeaderSql As String =
                            "UPDATE HR_EMPLOYEE_RECORD_HDR SET SUB_CLIENT_ID = ? WHERE EMPLOYEE_ID = ?"

                        Using updateHeaderCommand As New OleDbCommand(updateHeaderSql, GlobalVariables.GlobalCon, transaction)
                            updateHeaderCommand.Parameters.Add("?", OleDbType.Integer).Value = sNew_Client_ID
                            updateHeaderCommand.Parameters.Add("?", OleDbType.VarWChar).Value = sEmployee_ID
                            updateHeaderCommand.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                    Catch
                        Try
                            transaction.Rollback()
                        Catch
                            ' Preserve the original database error.
                        End Try
                        Throw
                    End Try
                End Using

                MsgBox("Successfully added a new client historical record", vbInformation, "Saved!")
            End With

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error in adding client")
            Return False
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State <> ConnectionState.Closed Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try
    End Function

    Private Function TryParseClientMovementDate(value As String, ByRef parsedDate As Date) As Boolean
        Dim acceptedFormats() As String = {"dd-MMM-yyyy", "d-MMM-yyyy", "M/d/yyyy", "MM/dd/yyyy"}

        Return Date.TryParseExact(
            value.Trim(),
            acceptedFormats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.AllowWhiteSpaces,
            parsedDate) OrElse Date.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, parsedDate)
    End Function

    Private Function LoadClientMovementPeriods(
        employeeID As String,
        transaction As OleDbTransaction) As List(Of ClientMovementPeriod)

        Const selectSql As String =
            "SELECT ID, DATE_STARTED, DATE_ENDED " &
            "FROM HR_EMPLOYEE_CLIENT_TRANSFER_DTL " &
            "WHERE EMPLOYEE_ID = ? ORDER BY DATE_STARTED, ID"

        Dim movements As New List(Of ClientMovementPeriod)

        Using selectCommand As New OleDbCommand(selectSql, GlobalVariables.GlobalCon)
            If transaction IsNot Nothing Then
                selectCommand.Transaction = transaction
            End If

            selectCommand.Parameters.Add("?", OleDbType.VarWChar).Value = employeeID

            Using reader As OleDbDataReader = selectCommand.ExecuteReader()
                While reader.Read()
                    movements.Add(New ClientMovementPeriod With {
                        .ID = CInt(reader("ID")),
                        .DateStarted = CDate(reader("DATE_STARTED")).Date,
                        .DateEnded = CDate(reader("DATE_ENDED")).Date
                    })
                End While
            End Using
        End Using

        Return movements
    End Function

    Private Function GetCurrentClientMovementID(movements As List(Of ClientMovementPeriod)) As Integer
        If movements.Count = 0 Then
            Return 0
        End If

        Dim latestMovement As ClientMovementPeriod = movements.
            OrderByDescending(Function(movement) movement.DateStarted).
            ThenByDescending(Function(movement) movement.ID).
            First()

        If latestMovement.DateStarted = latestMovement.DateEnded Then
            Return latestMovement.ID
        End If

        Return 0
    End Function

    Private Function TryFindOverlappingClientMovement(
        candidateStart As Date,
        candidateEnd As Date,
        candidateIsCurrent As Boolean,
        existingMovements As List(Of ClientMovementPeriod),
        excludedMovementID As Integer,
        currentMovementID As Integer,
        currentMovementWillBeClosed As Boolean,
        ByRef conflictingMovement As ClientMovementPeriod) As Boolean

        Dim candidateEffectiveEnd As Date = If(candidateIsCurrent, Date.MaxValue.Date, candidateEnd.Date)

        For Each movement In existingMovements
            If movement.ID = excludedMovementID Then
                Continue For
            End If

            If currentMovementWillBeClosed AndAlso movement.ID = currentMovementID Then
                Continue For
            End If

            Dim movementEffectiveEnd As Date = movement.DateEnded
            If movement.ID = currentMovementID Then
                movementEffectiveEnd = Date.MaxValue.Date
            End If

            If candidateStart.Date <= movementEffectiveEnd AndAlso
               movement.DateStarted <= candidateEffectiveEnd Then
                conflictingMovement = movement
                Return True
            End If
        Next

        conflictingMovement = Nothing
        Return False
    End Function

    Private Sub ShowClientMovementOverlapError(
        conflictingMovement As ClientMovementPeriod,
        currentMovementID As Integer)

        Dim conflictingEnd As String
        If conflictingMovement.ID = currentMovementID Then
            conflictingEnd = "Up to present"
        Else
            conflictingEnd = conflictingMovement.DateEnded.ToString("dd-MMM-yyyy")
        End If

        MsgBox(
            "The selected dates overlap movement record " & conflictingMovement.ID &
            " (" & conflictingMovement.DateStarted.ToString("dd-MMM-yyyy") &
            " to " & conflictingEnd & ")." & vbCrLf & vbCrLf &
            "Client movement dates cannot overlap.",
            vbExclamation,
            "Overlapping Client Movement")
    End Sub

    Private Sub CloseExistingCurrentClientMovements(
        employeeID As String,
        newMovementStart As Date,
        existingMovements As List(Of ClientMovementPeriod),
        transaction As OleDbTransaction)

        Const updateSql As String =
            "UPDATE HR_EMPLOYEE_CLIENT_TRANSFER_DTL " &
            "SET DATE_ENDED = ? WHERE ID = ? AND EMPLOYEE_ID = ?"

        For Each currentMovement In existingMovements.Where(
            Function(movement) movement.DateStarted = movement.DateEnded)

            Dim nextMovementStart As Date = newMovementStart

            For Each candidate In existingMovements
                If candidate.DateStarted > currentMovement.DateStarted AndAlso
                   candidate.DateStarted < nextMovementStart Then
                    nextMovementStart = candidate.DateStarted
                End If
            Next

            Dim correctedEndDate As Date = nextMovementStart.AddDays(-1)

            Using updateCommand As New OleDbCommand(updateSql, GlobalVariables.GlobalCon, transaction)
                updateCommand.Parameters.Add("?", OleDbType.Date).Value = correctedEndDate
                updateCommand.Parameters.Add("?", OleDbType.Integer).Value = currentMovement.ID
                updateCommand.Parameters.Add("?", OleDbType.VarWChar).Value = employeeID
                updateCommand.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Public Function Update_Client_Record(sEmployee_ID As String, sRef_ID As Integer) As Boolean
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC
                Dim startDate As Date
                Dim endDate As Date
                Dim isCurrentMovement As Boolean = .Chk_UptoPresent.Checked

                If Not TryParseClientMovementDate(.Txt_Client_Start_Date.Text, startDate) Then
                    MsgBox("Please enter a valid client movement start date.", vbExclamation, "Invalid Start Date")
                    Return False
                End If

                If isCurrentMovement Then
                    endDate = startDate
                ElseIf Not TryParseClientMovementDate(.Txt_Client_End_Date.Text, endDate) Then
                    MsgBox("Please enter a valid client movement end date.", vbExclamation, "Invalid End Date")
                    Return False
                End If

                startDate = startDate.Date
                endDate = endDate.Date

                If Not isCurrentMovement AndAlso endDate < startDate Then
                    MsgBox("The client movement end date cannot be earlier than its start date.", vbExclamation, "Invalid Date Range")
                    Return False
                End If

                Dim existingMovements As List(Of ClientMovementPeriod) = LoadClientMovementPeriods(sEmployee_ID, Nothing)
                Dim currentMovementID As Integer = GetCurrentClientMovementID(existingMovements)
                Dim conflictingMovement As ClientMovementPeriod = Nothing

                If TryFindOverlappingClientMovement(
                    startDate,
                    endDate,
                    isCurrentMovement,
                    existingMovements,
                    sRef_ID,
                    currentMovementID,
                    False,
                    conflictingMovement) Then

                    ShowClientMovementOverlapError(conflictingMovement, currentMovementID)
                    Return False
                End If

                Const updateSql As String =
                    "UPDATE HR_EMPLOYEE_CLIENT_TRANSFER_DTL " &
                    "SET DATE_STARTED = ?, DATE_ENDED = ? " &
                    "WHERE ID = ? AND EMPLOYEE_ID = ?"

                Using updateCommand As New OleDbCommand(updateSql, GlobalVariables.GlobalCon)
                    updateCommand.Parameters.Add("?", OleDbType.Date).Value = startDate
                    updateCommand.Parameters.Add("?", OleDbType.Date).Value = endDate
                    updateCommand.Parameters.Add("?", OleDbType.Integer).Value = sRef_ID
                    updateCommand.Parameters.Add("?", OleDbType.VarWChar).Value = sEmployee_ID
                    updateCommand.ExecuteNonQuery()
                End Using

                Call Record_activity_log(Mod_GlobalVariables.GlobalVariables.sEmployee_ID_Logged_in, "Updated Client assigment Date of " & sEmployee_ID & "")
                MsgBox("Client record was successfully updated!", vbInformation, "Saved")

            End With

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating Client Record")
            Return False
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State <> ConnectionState.Closed Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try
    End Function
    Public Sub Change_Employee_Client_Assignment(sEmployee_ID As String, sNew_Client_ID As Integer, iLatest_Client_ID As Integer)

        ' Update Employee_Record
        ' Insert new record to HR_EMPLOYEE_CLIENT_TRANSFER_DTL

        Dim SQL, SQL2 As String

        Dim Error_part As String
        Error_part = ""

        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "UPDATE HR_EMPLOYEE_RECORD_HDR SET CLIENT_ID = " & sNew_Client_ID & " WHERE EMPLOYEE_ID = '" & sEmployee_ID & "'"

                Error_part = "Updating"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                If .Txt_Client_End_Date.Text = "" Then ' Meaning the Up to Present check box was checked. --> Up to present in this Client
                    ' As work around, I will use the same Date as Start Date to avoid NULL value in END Date
                    .Txt_Client_End_Date.Text = .Txt_Client_Start_Date.Text
                End If


                SQL2 = ""
                SQL2 = "INSERT INTO HR_EMPLOYEE_CLIENT_TRANSFER_DTL (EMPLOYEE_ID, SUB_CLIENT_ID, DATE_STARTED, DATE_ENDED) VALUES ('" & sEmployee_ID & "', " & sNew_Client_ID & ", '" & .Txt_Client_Start_Date.Text & "','" & .Txt_Client_End_Date.Text & "')"


                Error_part = "Inserting"

                Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL2, GlobalVariables.GlobalCon)
                SQLcmd2.ExecuteNonQuery()
                SQLcmd2.Dispose()


                '' The previous record also has the same START and END , therefor the END Date must be updated and use the START DATE of the new one so that only one record displays "Up to Present" status.
                'SQL3 = "UPDATE HR_EMPLOYEE_CLIENT_TRANSFER_DTL SET DATE_ENDED = '" & .Txt_Client_Start_Date.Text & "' WHERE ID = " & iLatest_Client_ID & ""
                'Dim SQLcmd3 As OleDbCommand = New OleDbCommand(SQL3, GlobalVariables.GlobalCon)
                'SQLcmd3.ExecuteNonQuery()
                'SQLcmd3.Dispose()


                Call Record_activity_log(Mod_GlobalVariables.GlobalVariables.sEmployee_ID_Logged_in, "Changed client assignment for " & sEmployee_ID & "")

                MsgBox("Successfully assigned to a new Client", vbInformation, "Updated!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error " & Error_part & " Client")

        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub


    Public Sub Delete_License_record(sEmployee_ID As String, sRef_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "DELETE FROM HR_SECURITY_LICENSE_RECORD_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' and ID = " & sRef_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("License record was successfully deleted!", vbInformation, "Deleted!")

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Deleted a license record: " & sEmployee_ID & "")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Deleting License Filing")

        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub Show_License_recod_To_Texboxes(sEmployee_ID As String, sRef_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * from HR_SECURITY_LICENSE_RECORD_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' and ID = " & sRef_ID & ""

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC

                    Dim myRow As DataRow

                    For Each myRow In dt.Rows
                        .Txt_License_Number.Text = myRow.Item("SEC_LICENSE_NO")
                        .Txt_License_Expiry.Text = Format(CDate(myRow.Item("SEC_EXP_DATE")), "dd-MMM-yyyy")
                        .Cmb_LicenseType.Text = myRow.Item("SEC_LICENSE_TYPE")
                        .Txt_License_Attachment.Text = myRow.Item("SEC_LICENSE_PATH")


                    Next
                End With
            Else


            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Show License Record Error")
        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub Show_License_Record_to_ListView(sEmployee_ID As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * from HR_SECURITY_LICENSE_RECORD_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' ORDER BY ID DESC"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then
                With FRM_EMP_UPDATE_REC.LV_License_Record

                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1
                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(iRow)
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SEC_LICENSE_NO"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SEC_LICENSE_TYPE"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("SEC_EXP_DATE")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ID"))

                        iRow = iRow + 1
                    Next
                End With
            Else
                FRM_EMP_UPDATE_REC.LV_License_Record.Items.Clear()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Show License Record Error")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub


    Public Sub Update_License_Record(sEmployee_ID As String, iSEC_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "UPDATE HR_SECURITY_LICENSE_RECORD_DTL SET SEC_LICENSE_NO = '" & Trim(.Txt_License_Number.Text) & "', SEC_EXP_DATE = '" & .Txt_License_Expiry.Text & "' "
                SQL = SQL & ", SEC_LICENSE_TYPE = '" & .Cmb_LicenseType.Text & "', SEC_LICENSE_PATH = '" & .Txt_License_Attachment.Text & "' WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' and ID = " & iSEC_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("License record was successfully updated!", vbInformation, "Saved")

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Updated a license record")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating Leave Filing")
            FRM_EMP_UPDATE_REC.Btn_License_Edit.Text = "Edit"
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Insert_new_License_Record(sEmployee_ID As String)


        With FRM_EMP_UPDATE_REC


            Dim SQL As String

            Connect_to_MDB()

            Try


                SQL = "INSERT INTO HR_SECURITY_LICENSE_RECORD_DTL (EMPLOYEE_ID, SEC_LICENSE_NO, SEC_EXP_DATE,SEC_LICENSE_TYPE, SEC_LICENSE_PATH)"
                SQL = SQL & " VALUES ('" & sEmployee_ID & "', '" & Trim(.Txt_License_Number.Text) & "', '" & .Txt_License_Expiry.Text & "', '" & .Cmb_LicenseType.Text & "'"
                SQL = SQL & ", '" & .Txt_License_Attachment.Text & "')"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                'Copy the PDF file to Destination Path
                My.Computer.FileSystem.CopyFile(GlobalVariables.sSource_Path, GlobalVariables.sDestination_Path)

                MsgBox("New Security License record was successfully saved.", vbInformation, "Saved")

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Added new license record")

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error Inserting License Record")

            End Try

            GlobalVariables.GlobalCon.Close()


        End With





    End Sub


    Public Sub Clear_License_Textboxes()

        With FRM_EMP_UPDATE_REC

            .Txt_License_Number.Text = ""
            .Txt_License_Expiry.Text = ""
            .Cmb_LicenseType.SelectedIndex = -1
            .Txt_License_Attachment.Text = ""


        End With

    End Sub


    Public Sub Delete_Leave_Record(sEmployee_id As String, sRef_ID As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "DELETE FROM HR_LEAVE_FILING WHERE EMPLOYEE_ID = '" & sEmployee_id & "' and ID = " & sRef_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                MsgBox("Leave record was successfully deleted!", vbInformation, "Deleted!")

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Deleted a leave record from employee " & .Lbl_Employee_ID.Text & "")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Deleting Leave Filing")

        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub Update_Leave_Record(sEmployee_ID As String, sRef_ID As String)


        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC


                SQL = ""
                SQL = "UPDATE HR_LEAVE_FILING SET LEAVE_TYPE = '" & .Cmb_LeaveType.Text & "', NOTIFY = '" & .Cmb_Notification.Text & "'"
                SQL = SQL & ", DATE_FROM = '" & .Txt_Leave_DateFrom.Text & "', DATE_TO = '" & .Txt_Leave_DateTo.Text & "', REASON = '" & .Txt_Leave_Reason.Text & "', STATUS = '" & .Cmb_Leave_Status.Text & "'"
                SQL = SQL & " WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' and ID = " & sRef_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Leave record was successfully updated!", vbInformation, "Saved")

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Updated a leave record")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating Leave Filing")

        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub
    Public Sub Show_Leave_Records_To_Textboxes(sEmployee_ID As String, sRef_ID As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * from HR_LEAVE_FILING WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' and ID = " & sRef_ID & ""

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC

                    Dim myRow As DataRow

                    For Each myRow In dt.Rows

                        .Cmb_LeaveType.Text = myRow.Item("LEAVE_TYPE")
                        .Txt_Leave_DateFrom.Text = Format(CDate(myRow.Item("DATE_FROM")), "dd-MMM-yyyy")
                        .Txt_Leave_DateTo.Text = Format(CDate(myRow.Item("DATE_TO")), "dd-MMM-yyyy")
                        .Cmb_Notification.Text = myRow.Item("NOTIFY")
                        .Txt_Leave_Reason.Text = myRow.Item("REASON")
                        .Cmb_Leave_Status.Text = myRow.Item("STATUS")

                    Next
                End With
            Else


            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Show Leave Record Error")
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Show_Leave_File_Records(sEmployee_D As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * from HR_LEAVE_FILING WHERE EMPLOYEE_ID = '" & sEmployee_D & "'"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_UPDATE_REC.LV_Leave

                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1
                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(iRow)
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LEAVE_TYPE"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("DATE_FROM")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("DATE_TO")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("STATUS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ID"))


                        iRow = iRow + 1
                    Next
                End With

            Else
                FRM_EMP_UPDATE_REC.LV_Leave.Items.Clear()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Show Leave Record Error")
        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub

    Public Sub Clear_Leave_Filing_Boxes()


        With FRM_EMP_UPDATE_REC

            .Cmb_LeaveType.SelectedIndex = -1
            .Cmb_Leave_Status.SelectedIndex = -1
            .Cmb_Notification.SelectedIndex = -1
            .Txt_Leave_DateFrom.Text = ""
            .Txt_Leave_DateTo.Text = ""
            .Txt_Leave_Reason.Text = ""

        End With


    End Sub

    Public Sub Insert_Leave_filing(sEmployee_ID As String)

        With FRM_EMP_UPDATE_REC


            Dim SQL As String

            Connect_to_MDB()

            Try

                SQL = "INSERT INTO HR_LEAVE_FILING (EMPLOYEE_ID, LEAVE_TYPE, NOTIFY, DATE_FROM, DATE_TO, REASON, STATUS) VALUES ('" & sEmployee_ID & "', '" & .Cmb_LeaveType.Text & "','" & .Cmb_Notification.Text & "'"
                SQL = SQL & ", '" & .Txt_Leave_DateFrom.Text & "', '" & .Txt_Leave_DateTo.Text & "', '" & .Txt_Leave_Reason.Text & "', '" & .Cmb_Leave_Status.Text & "')"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("Leave File was successfully saved.", vbInformation, "Saved")

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "New Leave Filing")

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error Inserting Leave Record")

            End Try

            GlobalVariables.GlobalCon.Close()


        End With





    End Sub
End Module
