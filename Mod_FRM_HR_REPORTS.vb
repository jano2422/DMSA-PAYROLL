Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Configuration

Module Mod_FRM_HR_REPORTS
    Public Sub Show_Client_Contract_Expiry(dExpiry_Date As DateTime)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = ""

            SQL = "SELECT * FROM TBL_CLIENT_CONTRACT A, TBL_CLIENT_SUB B WHERE A.SUB_CLIENT_ID = B.SUB_CLIENT_ID AND A.END_CONTRACT_DATE <= CDate('" & dExpiry_Date & "') order by end_contract_date desc"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Client_Contract_Exp

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("SUB_CLIENT_NAME")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ADDRESS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("START_CONTRACT_DATE"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("END_CONTRACT_DATE"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("CONTRACT_STATUS"))


                        Dim expirationDate As DateTime = CType(myRow.Item("END_CONTRACT_DATE"), DateTime)
                        Dim currentDate As DateTime = DateTime.Now
                        ' Calculate the difference in days
                        Dim daysExpired As Integer = (currentDate - expirationDate).Days

                        .Items(.Items.Count - 1).SubItems.Add(daysExpired)


                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_HR_REPORTS.LV_Client_Contract_Exp.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub
    Public Sub Show_Main_Client_Employe_Count()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = "SELECT * from VIEW_MAIN_CLIENT_EMPLOYEE_COUNT"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_MAIN_CLIENT_EMPLOYEE_COUNT

                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1
                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(iRow)
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("MAIN_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("EMPLOYEE_COUNT"))

                        iRow = iRow + 1
                    Next
                End With
            Else
                FRM_HR_REPORTS.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub


    Public Sub Show_Sub_Client_Employee_Count()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = "SELECT * from VIEW_SUB_CLIENT_EMPLOYEE_COUNT order by SUB_CLIENT_NAME "


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_SubClient_EmployeeCount

                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1
                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(iRow)
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("EMPLOYEE_COUNT"))

                        iRow = iRow + 1
                    Next
                End With
            Else
                FRM_HR_REPORTS.LV_SubClient_EmployeeCount.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Show_Client_Count_In_Listview()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = "SELECT A.main_client_name, COUNT(B.SUB_CLIENT_ID) AS SubClient_count FROM tbl_client_main A, tbl_client_Sub B"
            SQL = SQL & " WHERE A.main_client_id = B.main_client_id GROUP BY A.main_client_name ORDER BY COUNT(B.SUB_CLIENT_ID) DESC"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Client_Count

                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1
                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(iRow)
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("MAIN_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SubClient_count"))

                        iRow = iRow + 1
                    Next
                End With
            Else
                FRM_HR_REPORTS.LV_Client_Count.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Export_Pending_Docs_to_Excel()
        Try
            Dim objExcel As New Excel.Application
            ' Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet
            objExcel.Visible = True
            objExcel.Workbooks.Add()

            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Security_License_Expiry.xlsx")
            'objSheet = objWorkbook.Worksheets("Sheet1")

            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Security_License_Expiry.xlsx")
            objSheet = objExcel.Worksheets("Sheet1")

            ' Added to be able to clear sheet content
            Dim sheet As Excel.Worksheet = DirectCast(objExcel.Sheets("Sheet1"), Excel.Worksheet)
            sheet.Cells.Clear()

            objSheet.Cells(1, 1).value = "EMPLOYEE ID"
            objSheet.Cells(1, 2).value = "NAME"
            objSheet.Cells(1, 3).value = "DATE HIRED"
            objSheet.Cells(1, 4).value = "CLIENT"
            objSheet.Cells(1, 5).value = "GOVERNMENT ID"


            Dim testValue As String

            With FRM_HR_REPORTS.LV_Pending_List

                For iRow = 0 To .Items.Count - 1  ' Row of List View

                    For iCol = 0 To 4  ' Col of List View

                        testValue = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(2 + iRow, 1 + iCol).value = .Items(iRow).SubItems(iCol).Text

                    Next iCol

                Next iRow

            End With

            ' Just for autofit of cells value
            Dim range As Excel.Range = sheet.Range("A1:E1")
            range.EntireColumn.AutoFit()

            'objExcel.AlertBeforeOverwriting = False
            'objExcel.SaveWorkspace()
            'objExcel.Application.Quit()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Export_Leave_Status_to_Excel()
        Try
            Dim objExcel As New Excel.Application
            ' Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet
            objExcel.Visible = True
            objExcel.Workbooks.Add()

            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Security_License_Expiry.xlsx")
            'objSheet = objWorkbook.Worksheets("Sheet1")

            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Security_License_Expiry.xlsx")
            objSheet = objExcel.Worksheets("Sheet1")

            ' Added to be able to clear sheet content
            Dim sheet As Excel.Worksheet = DirectCast(objExcel.Sheets("Sheet1"), Excel.Worksheet)
            sheet.Cells.Clear()

            objSheet.Cells(1, 1).value = "EMPLOYEE ID"
            objSheet.Cells(1, 2).value = "NAME"
            objSheet.Cells(1, 3).value = "LEAVE TYPE"
            objSheet.Cells(1, 4).value = "START DATE"
            objSheet.Cells(1, 5).value = "END DATE"
            objSheet.Cells(1, 6).value = "CLIENT NAME"

            Dim testValue As String

            With FRM_HR_REPORTS.LV_Leave_List

                For iRow = 0 To .Items.Count - 1  ' Row of List View

                    For iCol = 0 To 5  ' Col of List View

                        testValue = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(2 + iRow, 1 + iCol).value = .Items(iRow).SubItems(iCol).Text

                    Next iCol

                Next iRow

            End With

            ' Just for autofit of cells value
            Dim range As Excel.Range = sheet.Range("A1:E1")
            range.EntireColumn.AutoFit()

            'objExcel.AlertBeforeOverwriting = False
            'objExcel.SaveWorkspace()
            'objExcel.Application.Quit()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Show_Number_of_Active_Clients()


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = ""
            SQL = "SELECT COUNT(*) AS DISTINCTCOUNT FROM (SELECT DISTINCT (SUB_CLIENT_NAME) FROM TBL_CLIENT_SUB WHERE SUB_CLIENT_STATUS = 'Active')  AS NUMBER_OF_ACTIVE_CLIENT"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow

                For Each myRow In dt.Rows

                    FRM_HR_REPORTS.Txt_Active_SubClient.Text = myRow.Item(0)

                Next

            Else

            End If

            dt.Clear()
            dt.Reset()

            SQL = ""
            SQL = "SELECT COUNT(*) AS CLIENT_COUNT FROM ( SELECT DISTINCT(MAIN_CLIENT_ID) FROM TBL_CLIENT_MAIN)"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow

                For Each myRow In dt.Rows

                    FRM_HR_REPORTS.Txt_Active_MainClient.Text = myRow.Item(0)

                Next

            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub
    Public Sub Export_Client_Contract_Expiry_to_Excel()
        Try
            Dim objExcel As New Excel.Application
            ' Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet
            objExcel.Visible = True
            objExcel.Workbooks.Add()

            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Security_License_Expiry.xlsx")
            'objSheet = objWorkbook.Worksheets("Sheet1")

            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Security_License_Expiry.xlsx")
            objSheet = objExcel.Worksheets("Sheet1")

            ' Added to be able to clear sheet content
            Dim sheet As Excel.Worksheet = DirectCast(objExcel.Sheets("Sheet1"), Excel.Worksheet)
            sheet.Cells.Clear()

            objSheet.Cells(2, 1).value = "Expiration: "
            objSheet.Cells(3, 1).value = Date.Now

            objSheet.Cells(5, 1).value = "ITEM"
            objSheet.Cells(5, 2).value = "CLIENT NAME"
            objSheet.Cells(5, 3).value = "CLIENT ADDRESS"
            objSheet.Cells(5, 4).value = "START OF CONTRACT"
            objSheet.Cells(5, 5).value = "END OF CONTRACT"
            objSheet.Cells(5, 6).value = "STATUS"
            objSheet.Cells(5, 7).value = "DAYS EXPIRED"

            'Merge Cells
            'Dim rangeToMerge1 As Excel.Range = objSheet.Range("A1:D1")
            'Dim rangeToMerge2 As Excel.Range = objSheet.Range("A2:D2")
            'Dim rangeToMerge3 As Excel.Range = objSheet.Range("A3:D3")

            'rangeToMerge1.Merge()
            'rangeToMerge2.Merge()
            'rangeToMerge3.Merge() ' Date

            'rangeToMerge3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

            Dim testValue As String

            With FRM_HR_REPORTS.LV_Client_Contract_Exp

                For iRow = 0 To .Items.Count - 1  ' Row of List View

                    For iCol = 0 To 5  ' Col of List View

                        testValue = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(6 + iRow, 2 + iCol).value = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(6 + iRow, 1).value = 1 + iRow

                    Next iCol

                Next iRow

            End With

            ' Just for autofit of cells value
            Dim range As Excel.Range = sheet.Range("A1:E1")
            range.EntireColumn.AutoFit()

            'objExcel.AlertBeforeOverwriting = False
            'objExcel.SaveWorkspace()
            'objExcel.Application.Quit()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub Export_Expiry_to_Excel()
        Try
            Dim objExcel As New Excel.Application
            ' Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet
            objExcel.Visible = True
            objExcel.Workbooks.Add()

            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Security_License_Expiry.xlsx")
            'objSheet = objWorkbook.Worksheets("Sheet1")

            'objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Security_License_Expiry.xlsx")
            objSheet = objExcel.Worksheets("Sheet1")

            ' Added to be able to clear sheet content
            Dim sheet As Excel.Worksheet = DirectCast(objExcel.Sheets("Sheet1"), Excel.Worksheet)
            sheet.Cells.Clear()


            objSheet.Cells(1, 1).value = "Category: " & FRM_HR_REPORTS.Cmb_Exp_Category.Text & ""
            objSheet.Cells(2, 1).value = "Expiration: " & FRM_HR_REPORTS.Cmb_Expiry_Status.Text & ""
            objSheet.Cells(3, 1).value = Date.Now

            objSheet.Cells(5, 1).value = "ITEM"
            objSheet.Cells(5, 2).value = "EMPLOYEE ID"
            objSheet.Cells(5, 3).value = "EMPLOYEE NAME"
            objSheet.Cells(5, 4).value = "DATE HIRED"
            objSheet.Cells(5, 5).value = "CLIENT REPORTING"
            objSheet.Cells(5, 6).value = "EXPIRY DATE"
            objSheet.Cells(5, 7).value = "DAYS EXPIRED"

            'Merge Cells
            Dim rangeToMerge1 As Excel.Range = objSheet.Range("A1:D1")
            Dim rangeToMerge2 As Excel.Range = objSheet.Range("A2:D2")
            Dim rangeToMerge3 As Excel.Range = objSheet.Range("A3:D3")

            rangeToMerge1.Merge()
            rangeToMerge2.Merge()
            rangeToMerge3.Merge() ' Date

            rangeToMerge3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

            Dim testValue As String

            With FRM_HR_REPORTS.LV_Expiry_List

                For iRow = 0 To .Items.Count - 1  ' Row of List View

                    For iCol = 0 To 5  ' Col of List View

                        testValue = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(6 + iRow, 2 + iCol).value = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(6 + iRow, 1).value = 1 + iRow

                    Next iCol

                Next iRow

            End With

            ' Just for autofit of cells value
            Dim range As Excel.Range = sheet.Range("A1:E1")
            range.EntireColumn.AutoFit()

            'objExcel.AlertBeforeOverwriting = False
            'objExcel.SaveWorkspace()
            'objExcel.Application.Quit()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub Show_Leave_Applications(sLeave_Type As String, dDate_From As Date, dDate_To As Date)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            If sLeave_Type = "All" Or sLeave_Type = "ALL" Then
                SQL = "Select * From HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B, TBL_CLIENT_SUB C, HR_LEAVE_FILING D"
                SQL = SQL & " Where A.APPLICATION_ID = B.APPLICATION_ID And B.SUB_CLIENT_ID = C.SUB_CLIENT_ID And D.EMPLOYEE_ID = B.EMPLOYEE_ID"
                SQL = SQL & " AND DATE_FROM >= CDate('" & dDate_From & "') and Date_to <= CDate('" & dDate_To & "')"

            Else

                SQL = "Select * From HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B, TBL_CLIENT_SUB C, HR_LEAVE_FILING D"
                SQL = SQL & " Where A.APPLICATION_ID = B.APPLICATION_ID And B.SUB_CLIENT_ID = C.SUB_CLIENT_ID And D.EMPLOYEE_ID = B.EMPLOYEE_ID"
                SQL = SQL & " And D.LEAVE_TYPE = '" & sLeave_Type & "' AND DATE_FROM >= CDate('" & dDate_From & "') and Date_to <= CDate('" & dDate_To & "')"

            End If


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Leave_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("B.EMPLOYEE_ID")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LEAVE_TYPE"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DATE_FROM"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DATE_TO"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))


                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_HR_REPORTS.LV_Leave_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub Show_Employees_With_Pending_Information(sField As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select * from VIEW_PENDING_GOV_INFO WHERE UCASE(" & sField & ") in('NA', 'TO FOLLOW') order by 1 asc" ' Called Views (Query)


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Pending_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("EMPLOYEE_ID")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DATE_HIRED"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add("To Follow")
                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_HR_REPORTS.LV_Pending_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Show_in_Chart_Hired_Per_Year(sStatus As String)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select FORMAT(DATE_HIRED,'yyyy') AS YEAR_VALUE, count(*) as status_count From HR_EMPLOYEE_RECORD_HDR WHERE EMPLOYMENT_STATUS = '" & sStatus & "' Group By FORMAT(DATE_HIRED,'yyyy') order by 2 desc"
            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Report_Statistics1

                    Dim myRow As DataRow
                    .Items.Clear()
                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("YEAR_VALUE")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("status_count"))


                    Next
                End With
            Else
                FRM_HR_REPORTS.LV_Report_Statistics1.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub
    Public Sub Show_Employee_Status_in_Chart()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = "Select STATUS, COUNT(*) As status_count From HR_APPLICAtion_hdr Group By STATUS order by 2 DESC"
            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Report_Statistics1

                    Dim myRow As DataRow
                    .Items.Clear()
                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("STATUS")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("status_count"))


                    Next
                End With
            Else
                FRM_HR_REPORTS.LV_Report_Statistics1.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Sub Show_Insurance_Expiry(dExpiry_Date As DateTime)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = ""


            SQL = "Select * From HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B, TBL_CLIENT_SUB C, HR_INSURANCE_DTL D"
            SQL = SQL & " Where A.APPLICATION_ID = B.APPLICATION_ID And B.SUB_CLIENT_ID = C.SUB_CLIENT_ID And D.EMPLOYEE_ID = B.EMPLOYEE_ID"
            SQL = SQL & " And D.END_DATE <= CDate('" & dExpiry_Date & "') AND B.EMPLOYMENT_STATUS = 'Active' ORDER BY END_DATE ASC"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Expiry_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("D.EMPLOYEE_ID")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("DATE_HIRED"), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("END_DATE"), "dd-MMM-yyyy"))

                        Dim expirationDate As DateTime = CType(myRow.Item("END_DATE"), DateTime)
                        Dim currentDate As DateTime = DateTime.Now
                        ' Calculate the difference in days
                        Dim daysExpired As Integer = (currentDate - expirationDate).Days

                        .Items(.Items.Count - 1).SubItems.Add(daysExpired)


                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_HR_REPORTS.LV_Expiry_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub
    Public Sub Show_Medical_Expiry(dExpiry_Date As DateTime)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = ""


            'SQL = "Select * From HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B, TBL_CLIENT_SUB C, HR_MEDICAL_RECORDS_DTL D"
            'SQL = SQL & " Where A.APPLICATION_ID = B.APPLICATION_ID And B.CLIENT_ID = C.CLIENT_ID And D.EMPLOYEE_ID = B.EMPLOYEE_ID"
            'SQL = SQL & " And D.MED_EXP_DATE <= CDate('" & dExpiry_Date & "') AND D.MED_EXP_DATE <= CDate('" & Date.Now & "')"


            SQL = "Select * From HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B, TBL_CLIENT_SUB C, HR_MEDICAL_RECORDS_DTL D"
            SQL = SQL & " Where A.APPLICATION_ID = B.APPLICATION_ID And B.SUB_CLIENT_ID = C.SUB_CLIENT_ID And D.EMPLOYEE_ID = B.EMPLOYEE_ID"
            SQL = SQL & " And D.MED_EXP_DATE <= CDate('" & dExpiry_Date & "') AND B.EMPLOYMENT_STATUS = 'Active' ORDER BY MED_EXP_DATE ASC "

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Expiry_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("D.EMPLOYEE_ID")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("DATE_HIRED"), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("MED_EXP_DATE"), "dd-MMM-yyyy"))

                        Dim expirationDate As DateTime = CType(myRow.Item("MED_EXP_DATE"), DateTime)
                        Dim currentDate As DateTime = DateTime.Now
                        ' Calculate the difference in days
                        Dim daysExpired As Integer = (currentDate - expirationDate).Days

                        .Items(.Items.Count - 1).SubItems.Add(daysExpired)


                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_HR_REPORTS.LV_Expiry_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Show_License_Expiry(dExpiry_Date As DateTime)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = "Select * FROM HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B, TBL_CLIENT_SUB C, HR_SECURITY_LICENSE_RECORD_DTL D"
            SQL = SQL & " WHERE A.APPLICATION_ID = B.APPLICATION_ID And B.SUB_CLIENT_ID = C.SUB_CLIENT_ID AND D.EMPLOYEE_ID = B.EMPLOYEE_ID And D.SEC_EXP_DATE <= CDate('" & dExpiry_Date & "') AND B.EMPLOYMENT_STATUS = 'Active' order by SEC_EXP_DATE ASC"
            'SQL = SQL & " OR D.SEC_EXP_DATE <= CDate('" & Date.Now & "')"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Expiry_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("D.EMPLOYEE_ID")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("DATE_HIRED"), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(myRow.Item("SEC_EXP_DATE"), "dd-MMM-yyyy"))

                        Dim expirationDate As DateTime = CType(myRow.Item("SEC_EXP_DATE"), DateTime)
                        Dim currentDate As DateTime = DateTime.Now
                        ' Calculate the difference in days
                        Dim daysExpired As Integer = (currentDate - expirationDate).Days

                        .Items(.Items.Count - 1).SubItems.Add(daysExpired)

                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_HR_REPORTS.LV_Expiry_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub


End Module
