Imports System.Data.OleDb
Imports System.IO
Imports System.Linq
Imports System.Text
Module Mod_FRM_EMP_REG


    Public Sub Update_ATM_Info(sEmployee_ID As String, sBank_Name As String, sATM_No As String)

        With FRM_EMP_REG

            Dim SQL As String

            Connect_to_MDB()

            Try


                SQL = "UPDATE TBL_ATM_DTL SET BANK_NAME = '" & sBank_Name & "', ATM_ACC = '" & sATM_No & "' WHERE EMPLOYEE_ID = '" & sEmployee_ID & "'"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                MsgBox("ATM Information was successfully updated!", vbInformation, "Saved")

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error saving ATM information")

            End Try

            GlobalVariables.GlobalCon.Close()


        End With




    End Sub

    Public Sub Reg_ATM_Info(sEmployee_ID As String)
        Try
            Connect_to_MDB()

            Dim SQL As String = "INSERT INTO TBL_ATM_DTL (EMPLOYEE_ID, BANK_NAME, ATM_ACC) VALUES (?, ?, ?)"
            Using SQLcmd As New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.Parameters.AddWithValue("@EMPLOYEE_ID", sEmployee_ID)
                SQLcmd.Parameters.AddWithValue("@BANK_NAME", "FOR UPDATE")
                SQLcmd.Parameters.AddWithValue("@ATM_ACC", "FOR UPDATE")
                SQLcmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error registering employee on ATM Info")
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try
    End Sub

    Public Sub Show_ATM_Info(sEmployee_ID As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM TBL_ATM_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "'"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                Dim myRow As DataRow
                For Each myRow In dt.Rows

                    With FRM_EMP_REG

                        .Cmb_Bank_Name.Text = myRow.Item("BANK_NAME")
                        .Txt_ATM_Number.Text = myRow.Item("ATM_ACC")

                    End With

                Next

            Else
                With FRM_EMP_REG
                    .Cmb_Bank_Name.Text = ""
                    .Txt_ATM_Number.Text = ""
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Error showing ATM Info")
        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub Export_EMployee_Records_To_Excel()


        Try

            Dim objExcel As New Excel.Application
            'Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet
            objExcel.Visible = True
            objExcel.Workbooks.Add()

            'objWorkbook = objExcel.Workbooks.Open("C:\Users\estiokojc\source\repos\DMSA_System_DotNet\DMSA_System\bin\Debug\Template1.xlsx")
            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Exports\Employee_Records.xlsx")
            objSheet = objExcel.Worksheets("Sheet1")

            ' Detachment Info ( Header )
            objSheet.Cells(1, 1).value = "EMPLOYEE ID"
            objSheet.Cells(1, 2).value = "EMPLOYEE NAME"
            objSheet.Cells(1, 3).value = "DATE HIRED"
            objSheet.Cells(1, 4).value = "DETACHMENT"
            objSheet.Cells(1, 5).value = "STATUS"


            Dim testValue As String

            With FRM_EMP_REG.LV_Employee_List
                ' Employee List : A14
                For iRow = 0 To .Items.Count - 1

                    For iCol = 1 To 5

                        testValue = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(2 + iRow, iCol).value = .Items(iRow).SubItems(iCol).Text

                    Next iCol

                Next iRow

            End With


            'objExcel.AlertBeforeOverwriting = False
            'objExcel.SaveWorkspace()
            'objExcel.Application.Quit()


        Catch ex As Exception
            'MsgBox(ex.ToString, vbCritical, "Error in Exporting to Excel")
        End Try


    End Sub


    Public Function Show_Photo_in_Employee_Rec(sEmployee_ID As String)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM HR_PHOTO_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "'"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                Dim myRow As DataRow
                For Each myRow In dt.Rows

                    Return myRow.Item("PHOTO_PATH")

                Next

            Else
                Return "0"

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Error showing the Photo")
        End Try

        GlobalVariables.GlobalCon.Close()

        Return "0"


    End Function


    Public Sub Update_Employee_Photo(sEmployee_ID As String)

        With FRM_EMP_REG

            Dim SQL As String

            Connect_to_MDB()

            Try


                SQL = "UPDATE HR_PHOTO_DTL SET PHOTO_PATH = '" & GlobalVariables.Photo_Destination_Path & "' WHERE EMPLOYEE_ID = '" & sEmployee_ID & "'"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Uploaded a photo for " & sEmployee_ID & ".")

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error saving Photo information")
                Call Record_activity_log(GlobalVariables.Selected_Employee_ID, "Error updating photo")
            End Try

            GlobalVariables.GlobalCon.Close()


        End With

    End Sub

    Public Sub Insert_Photo_Uploaded(sEmployee_ID As String, sDestination_Path As String)

        With FRM_EMP_REG

            Dim SQL As String

            Connect_to_MDB()

            Try


                SQL = "INSERT INTO HR_PHOTO_DTL (EMPLOYEE_ID, PHOTO_PATH) VALUES ('" & sEmployee_ID & "', '" & sDestination_Path & "')"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error saving Photo information")
                Call Record_activity_log(GlobalVariables.Selected_Employee_ID, "Error uploading new photo ")
            End Try

            GlobalVariables.GlobalCon.Close()


        End With


    End Sub
    Public Sub Show_Insurance_Expiration_to_Employee_Record(sEmployee_ID As String)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM HR_INSURANCE_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' ORDER BY ID DESC"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                Dim myRow As DataRow
                For Each myRow In dt.Rows

                    FRM_EMP_REG.Txt_Insurance_Num.Text = myRow.Item("POLICY_NUMBER")
                    FRM_EMP_REG.Txt_Insurance_Exp_Date.Text = Format(myRow.Item("END_DATE"), "dd-MMM-yyyy")

                Next

            Else
                FRM_EMP_REG.Txt_Insurance_Num.Text = "No Insurance Record"
                FRM_EMP_REG.Txt_Insurance_Exp_Date.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub
    Public Sub Show_Medical_Expiration_To_Employee_Record(sEmployee_ID As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM HR_MEDICAL_RECORDS_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' ORDER BY ID DESC"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                Dim myRow As DataRow
                For Each myRow In dt.Rows

                    FRM_EMP_REG.Txt_Medical_Type.Text = myRow.Item("MED_TYPE")
                    FRM_EMP_REG.Txt_Medical_Exp_Date.Text = Format(myRow.Item("MED_EXP_DATE"), "dd-MMM-yyyy")

                Next

                ' Add 365 days as the expiration date
                'Dim Med_Date_String_To_DateTime As DateTime ' Need to Parse the Date so it will become Date Type to be able to add days on it.
                'DateTime.TryParseExact(FRM_EMP_REG.Txt_Medical_Exp_Date.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, Med_Date_String_To_DateTime)

                'FRM_EMP_REG.Txt_Medical_Exp_Date.Text = Med_Date_String_To_DateTime.AddDays(365) ' expiration

            Else
                FRM_EMP_REG.Txt_Medical_Type.Text = "No Medical Record"
                FRM_EMP_REG.Txt_Medical_Exp_Date.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Show_Employee_Details(sEmployee_ID As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B, TBL_CLIENT_SUB C, HR_APPLICATION_HDR D "
            SQL = SQL & " WHERE A.APPLICATION_ID = B.APPLICATION_ID AND B.EMPLOYEE_ID = '" & sEmployee_ID & "'"
            SQL = SQL & " AND B.SUB_CLIENT_ID = C.SUB_CLIENT_ID AND A.APPLICATION_ID = D.APPLICATION_ID"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow
                With FRM_EMP_REG
                    For Each myRow In dt.Rows

                        If myRow.Item("EMPLOYMENT_STATUS") = "Active" Then
                            .Lbl_Employee_Status.Text = "Status: Active"
                            .Lbl_Employee_Status.ForeColor = Color.Lime
                        ElseIf myRow.Item("EMPLOYMENT_STATUS") = "For Update" Then
                            .Lbl_Employee_Status.Text = "Status: For Update"
                            .Lbl_Employee_Status.ForeColor = Color.Orange
                        ElseIf myRow.Item("EMPLOYMENT_STATUS") = "Inactive" Then
                            .Lbl_Employee_Status.Text = "Status: Inactive"
                            .Lbl_Employee_Status.ForeColor = Color.Red
                        Else
                            .Lbl_Employee_Status.Text = "Status: " & .LV_Employee_List.SelectedItems(0).SubItems(5).Text
                            .Lbl_Employee_Status.ForeColor = Color.Yellow
                        End If


                        .Txt_Birthday.Text = Format(myRow.Item("BIRTH_DATE"), "dd-MMM-yyyy")
                        .Txt_Gender.Text = myRow.Item("GENDER")
                        .Txt_BloodType.Text = myRow.Item("BLOOD_TYPE")
                        .Txt_Height.Text = myRow.Item("HEIGHT")
                        .Txt_Weight.Text = myRow.Item("WEIGHT")
                        .Txt_Religion.Text = myRow.Item("RELIGION")
                        .Txt_CivilStatus.Text = myRow.Item("CIVIL_STATUS")
                        .Txt_ContactNo.Text = myRow.Item("CONTACT_NO")
                        .Txt_Email.Text = myRow.Item("EMAIL")
                        .Txt_ResiAdd.Text = myRow.Item("APPL_ADD")
                        .Txt_SSS.Text = myRow.Item("SSS_NO")
                        .Txt_Pagibig.Text = myRow.Item("PAGIBIG_NO")
                        .Txt_PhilHealth.Text = myRow.Item("PHIL_HEALTH_NO")
                        .Txt_TIN.Text = myRow.Item("TIN_NO")
                        .Txt_National_ID.Text = myRow.Item("NATIONAL_ID")

                        .Txt_Contact_Person.Text = myRow.Item("A.CONTACT_PERSON")
                        .Txt_Contact_CPNumber.Text = myRow.Item("CONTACT_CP_NUMBER")
                        .Txt_Relationship.Text = myRow.Item("CONTACT_RELATIONSHIP")
                        .Txt_Contact_Address.Text = myRow.Item("CONTACT_ADDRESS")

                    Next
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Error getting employee info")
        End Try

        GlobalVariables.GlobalCon.Close()





    End Sub
    Public Sub Show_Security_License_Expiration_To_Employee_Record(sEmployee_ID As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT * FROM HR_SECURITY_LICENSE_RECORD_DTL WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' ORDER BY ID DESC"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)



            If dt.Rows.Count > 0 Then ' SHOW DATAS
                Dim myRow As DataRow
                For Each myRow In dt.Rows

                    FRM_EMP_REG.Txt_Sec_License.Text = myRow.Item("SEC_LICENSE_NO")
                    FRM_EMP_REG.Txt_Sec_License_Exp.Text = Format(myRow.Item("SEC_EXP_DATE"), "dd-MMM-yyyy")

                Next

            Else
                FRM_EMP_REG.Txt_Sec_License.Text = "No Active License registered"
                FRM_EMP_REG.Txt_Sec_License_Exp.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub


    Public Sub Show_Employee_Client_History(sEmployee_ID As String)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select * From HR_EMPLOYEE_CLIENT_TRANSFER_DTL A, TBL_CLIENT_SUB B"
            SQL = SQL & " Where A.SUB_CLIENT_ID = B.SUB_CLIENT_ID And A.EMPLOYEE_ID = '" & sEmployee_ID & "'"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_REG.LV_Client_History

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("A.SUB_CLIENT_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DATE_STARTED"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DATE_ENDED"))


                    Next
                End With
            Else
                'MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_EMP_REG.LV_Client_History.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Function Get_Application_ID(sEmployee_ID As String)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select APPLICATION_ID FROM HR_EMPLOYEE_RECORD_HDR WHERE EMPLOYEE_ID = '" & sEmployee_ID & "'"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATA

                Dim myRow As DataRow

                For Each myRow In dt.Rows

                    Return myRow.Item("APPLICATION_ID")

                Next

            End If

        Catch ex As Exception
            Return 0
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()
        Return "0"

    End Function

    Public Sub Update_Employee_Separation_Status(sApplication_ID As Integer, sEmployee_ID As String, sNew_Status As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC

                SQL = ""
                SQL = "UPDATE HR_APPLICATION_HDR SET STATUS = '" & sNew_Status & "', REMARKS = '" & .Txt_Leave_Reason.Text & "' WHERE APPLICATION_ID = " & sApplication_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon) ' HR_APPLICATION_DTL
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                SQL = ""
                SQL = "UPDATE HR_EMPLOYEE_RECORD_HDR SET EMPLOYMENT_STATUS = '" & sNew_Status & "' WHERE APPLICATION_ID = " & sApplication_ID & ""

                Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd2.ExecuteNonQuery()
                SQLcmd2.Dispose()

                SQL = ""
                SQL = "INSERT INTO HR_STATUS_CHANGE_DTL (EMPLOYEE_ID, APPLICATION_ID, EMPLOYMENT_STATUS, EFFECTIVITY_DATE, REMARKS) VALUES"
                SQL = SQL & " (" & sEmployee_ID & ", " & sApplication_ID & ", '" & sNew_Status & "', '" & .Txt_StatusChange_Date.Text & "', '" & .Txt_ChangeStatus_Remark.Text & "')"

                Dim SQLcmd3 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd3.ExecuteNonQuery()
                SQLcmd3.Dispose()


                MsgBox("New Status was successfully saved!", vbInformation, "Saved")
                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Updated the employment status of " & sEmployee_ID & " to Inactive.")

            End With
        Catch ex As Exception

            MsgBox(ex.Message, vbCritical, "Error Updating RECORD to Employee_Separation_Status")

        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Update_Employee_Status_Remarks(sRefId As Integer, sEmployee_ID As String, sNew_Status As String, updatedRemarks As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC

                ' 🧠 Prevent SQL errors if remarks contains single quotes
                updatedRemarks = updatedRemarks.Replace("'", "''")

                ' 🧠 If status is null or empty, set it to NULL-friendly text (or skip it)
                If String.IsNullOrWhiteSpace(sNew_Status) Then
                    sNew_Status = "N/A" ' or leave blank or set default value
                End If

                ' ✅ Update HR_STATUS_CHANGE_DTL with correct syntax
                SQL = "UPDATE HR_STATUS_CHANGE_DTL SET REMARKS = '" & updatedRemarks & "' WHERE ID = " & sRefId
                Dim SQLcmd3 As New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd3.ExecuteNonQuery()
                SQLcmd3.Dispose()

                MsgBox("✅ New Status was successfully saved!", vbInformation, "Saved")

                ' ✅ Logging – safely handle null/empty status
                Dim statusText As String = If(String.IsNullOrWhiteSpace(sNew_Status), "[No Status Provided]", sNew_Status)

                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Updated the status remarks of " & sEmployee_ID & " to " & updatedRemarks & " ")

            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating RECORD to Employee_Separation_Status")
        Finally
            If GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try

    End Sub



    Public Sub Edit_Employee_Separation_Status(sID As Integer, sApplication_ID As Integer, sEmployee_ID As String, sNew_Status As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_EMP_UPDATE_REC

                SQL = ""
                SQL = "UPDATE HR_APPLICATION_HDR SET STATUS = '" & sNew_Status & "', REMARKS = '" & .Txt_Leave_Reason.Text & "' WHERE APPLICATION_ID = " & sApplication_ID & ""

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon) ' HR_APPLICATION_DTL
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                SQL = ""
                SQL = "UPDATE HR_EMPLOYEE_RECORD_HDR SET EMPLOYMENT_STATUS = '" & sNew_Status & "' WHERE APPLICATION_ID = " & sApplication_ID & ""

                Dim SQLcmd2 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd2.ExecuteNonQuery()
                SQLcmd2.Dispose()

                SQL = ""
                SQL = "UPDATE HR_STATUS_CHANGE_DTL SET "
                SQL &= "EMPLOYEE_ID = " & sEmployee_ID & ", "
                SQL &= "APPLICATION_ID = " & sApplication_ID & ", "
                SQL &= "EMPLOYMENT_STATUS = '" & sNew_Status & "', "
                SQL &= "EFFECTIVITY_DATE = #" & Format(.Txt_StatusChange_Date.Text, "yyyy-mm-dd") & "#, "
                SQL &= "REMARKS = '" & Replace(.Txt_ChangeStatus_Remark.Text, "'", "''") & "' "
                SQL &= "WHERE ID = " & sID

                Dim SQLcmd3 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd3.ExecuteNonQuery()
                SQLcmd3.Dispose()


                MsgBox("New Status was successfully saved!", vbInformation, "Saved")
                Call Record_activity_log(GlobalVariables.sEmployee_ID_Logged_in, "Updated the employment status of " & sEmployee_ID & " to Inactive.")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Updating RECORD to Employee_Separation_Status")
        End Try
        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub Clear_all_Boxes_from_EMP_RECORD()

        With FRM_EMP_REG

            FRM_EMP_REG.LV_Employee_List.Items.Clear()
            .Txt_Sec_License.Text = ""
            .Txt_Sec_License_Exp.Text = ""
            .Txt_Birthday.Text = ""
            .Txt_Gender.Text = ""
            .Txt_Height.Text = ""
            .Txt_Weight.Text = ""
            .Txt_BloodType.Text = ""
            .Txt_CivilStatus.Text = ""
            .Txt_Religion.Text = ""
            .Txt_ContactNo.Text = ""
            .Txt_Email.Text = ""
            .Txt_ResiAdd.Text = ""
            .Txt_SSS.Text = ""
            .Txt_Pagibig.Text = ""
            .Txt_PhilHealth.Text = ""
            .Txt_TIN.Text = ""
            .Txt_National_ID.Text = ""

            .Txt_Contact_Person.Text = ""
            .Txt_Relationship.Text = ""
            .Txt_Contact_Address.Text = ""
            .Txt_ContactNo.Text = ""
            .Txt_Contact_CPNumber.Text = ""

            .Cmb_Category.SelectedIndex = -1
            .TxtSearch.Text = ""

            .LV_Client_History.Items.Clear()

            .Cmb_Bank_Name.Text = ""
            .Txt_ATM_Number.Text = ""

        End With



    End Sub





    Public Sub Show_Employee_List()
        Dim dt As DataTable = GetEmployeeList()

        With FRM_EMP_REG.LV_Employee_List
            .Items.Clear()

            If dt.Rows.Count = 0 Then
                MsgBox("No records found.", vbExclamation, "No records")
                Exit Sub
            End If

            Dim index As Integer = 1

            For Each row As DataRow In dt.Rows
                .Items.Add(index.ToString())
                Dim item = .Items(.Items.Count - 1)

                item.SubItems.Add(row("EMPLOYEE_ID").ToString())
                item.SubItems.Add(row("LAST_NAME") & " " &
                              row("FIRST_NAME") & " " &
                              row("MIDDLE_NAME"))

                item.SubItems.Add(Format(row("DATE_HIRED"), "dd-MMM-yyyy"))
                item.SubItems.Add(row("SUB_CLIENT_NAME").ToString())

                ' Color coding
                If row("EMPLOYMENT_STATUS").ToString() <> "Active" Then
                    item.ForeColor = Color.Red
                Else
                    item.ForeColor = Color.Black
                End If

                item.SubItems.Add(row("EMPLOYMENT_STATUS").ToString())

                index += 1
            Next
        End With
    End Sub


    Public Function GetEmployeeList() As DataTable
        Dim dt As New DataTable

        Try
            Dim SQL As String =
    "SELECT A.FIRST_NAME, A.MIDDLE_NAME, A.LAST_NAME, " &
            "B.EMPLOYEE_ID, B.DATE_HIRED, B.SUB_CLIENT_ID, B.EMPLOYMENT_STATUS, " &
            "D.SUB_CLIENT_NAME " &
    "FROM ((HR_APPLICATION_DTL AS A " &
    "INNER JOIN HR_EMPLOYEE_RECORD_HDR AS B ON A.APPLICATION_ID = B.APPLICATION_ID) " &
    "INNER JOIN HR_APPLICATION_HDR AS C ON B.APPLICATION_ID = C.APPLICATION_ID) " &
    "INNER JOIN TBL_CLIENT_SUB AS D ON B.SUB_CLIENT_ID = D.SUB_CLIENT_ID " &
    "WHERE B.EMPLOYMENT_STATUS = 'Active' " &
    "ORDER BY A.LAST_NAME ASC"


            Using da As New OleDb.OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
                da.Fill(dt)
            End Using

        Catch ex As Exception
            MsgBox("Error loading employee list:" & vbCrLf & ex.Message, vbCritical, "Database Error")
        End Try

        Return dt
    End Function
    Public Sub ExportDataTableToCsv(dt As DataTable, filePath As String)
        Try
            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                Dim headers = dt.Columns.Cast(Of DataColumn)().
                    Select(Function(column) EscapeCsvValue(column.ColumnName))
                writer.WriteLine(String.Join(",", headers))

                For Each row As DataRow In dt.Rows
                    Dim fields = dt.Columns.Cast(Of DataColumn)().
                        Select(Function(column) EscapeCsvValue(Convert.ToString(row(column))))
                    writer.WriteLine(String.Join(",", fields))
                Next
            End Using

            MsgBox("CSV file saved successfully!", vbInformation)

        Catch ex As Exception
            MsgBox("Error exporting to CSV: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Function EscapeCsvValue(value As String) As String
        If value Is Nothing Then
            Return ""
        End If

        Dim escapedValue As String = value.Replace("""", """""")
        Dim needsQuotes As Boolean = escapedValue.Contains(",") OrElse
            escapedValue.Contains("""") OrElse
            escapedValue.Contains(vbCr) OrElse
            escapedValue.Contains(vbLf)

        If needsQuotes Then
            Return """" & escapedValue & """"
        End If

        Return escapedValue
    End Function
    Public Sub Show_Search(sCategory As String, sSearchString As String)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select B.EMPLOYEE_ID, A.FIRST_NAME, A.MIDDLE_NAME, A.LAST_NAME, B.SUB_CLIENT_ID,D.SUB_CLIENT_NAME, B.DATE_HIRED, B.EMPLOYMENT_STATUS"
            SQL = SQL & " From HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B, HR_APPLICATION_HDR C, TBL_CLIENT_SUB D"
            SQL = SQL & " Where A.APPLICATION_ID = B.APPLICATION_ID AND B.APPLICATION_ID = C.APPLICATION_ID "
            SQL = SQL & " AND B.SUB_CLIENT_ID = D.SUB_CLIENT_ID "
            SQL = SQL & " And " & sCategory & " Like '%" & sSearchString & "%'"
            SQL = SQL & " ORDER BY A.LAST_NAME ASC"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_EMP_REG.LV_Employee_List

                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(iRow) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("EMPLOYEE_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & " " & myRow.Item("First_Name") & " " & myRow.Item("Middle_Name")) ' Name

                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("DATE_HIRED"), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME")) ' Client name

                        If myRow.Item("EMPLOYMENT_STATUS") <> "Active" Then
                            .Items(.Items.Count - 1).ForeColor = Color.Red
                        Else
                            .Items(.Items.Count - 1).ForeColor = Color.Black
                        End If

                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("EMPLOYMENT_STATUS"))

                        iRow = iRow + 1

                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_DTR.LV_EmployeeList.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()







    End Sub




End Module
