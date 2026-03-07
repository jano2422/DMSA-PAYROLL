Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Configuration

Module Mod_FRM_HR_REPORTS
    Public Sub Show_Client_Contract_Expiry(filter As ExpiryFilter)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim SQL As String

        SQL = "
SELECT 
    B.SUB_CLIENT_NAME,
    B.ADDRESS,
    A.START_CONTRACT_DATE,
    A.END_CONTRACT_DATE,
    A.CONTRACT_STATUS
FROM 
    TBL_CLIENT_CONTRACT A
    INNER JOIN TBL_CLIENT_SUB B ON A.SUB_CLIENT_ID = B.SUB_CLIENT_ID
WHERE 
    1=1
"

        ' 📌 APPLY FILTERS BASED ON ENUM
        Select Case filter

            Case ExpiryFilter.Exp1Month
                SQL &= "AND A.END_CONTRACT_DATE BETWEEN Date() AND DateAdd('d', 30, Date()) "

            Case ExpiryFilter.Exp2Month
                SQL &= "AND A.END_CONTRACT_DATE BETWEEN Date() AND DateAdd('d', 60, Date()) "

            Case ExpiryFilter.Exp3Month
                SQL &= "AND A.END_CONTRACT_DATE BETWEEN Date() AND DateAdd('d', 90, Date()) "

            Case ExpiryFilter.Expired
                SQL &= "AND A.END_CONTRACT_DATE < Date() "

            Case ExpiryFilter.NoRecord
                SQL &= "AND A.END_CONTRACT_DATE IS NULL "
        End Select

        SQL &= " ORDER BY A.END_CONTRACT_DATE ASC"

        Try
            da = New OleDb.OleDbDataAdapter(SQL, GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                With FRM_HR_REPORTS.LV_Client_Contract_Exp
                    .Items.Clear()

                    For Each row As DataRow In dt.Rows

                        Dim startDate As String = ""
                        Dim endDate As String = ""
                        Dim daysExpired As Integer = 0

                        If Not IsDBNull(row("START_CONTRACT_DATE")) Then
                            startDate = CDate(row("START_CONTRACT_DATE")).ToString("dd-MMM-yyyy")
                        End If

                        If Not IsDBNull(row("END_CONTRACT_DATE")) Then
                            Dim expDate As Date = CDate(row("END_CONTRACT_DATE"))
                            endDate = expDate.ToString("dd-MMM-yyyy")
                            daysExpired = (Date.Now - expDate).Days
                        End If

                        With .Items
                            .Add(row("SUB_CLIENT_NAME").ToString())
                            .Item(.Count - 1).SubItems.Add(row("ADDRESS").ToString())
                            .Item(.Count - 1).SubItems.Add(startDate)
                            .Item(.Count - 1).SubItems.Add(endDate)
                            .Item(.Count - 1).SubItems.Add(row("CONTRACT_STATUS").ToString())
                            .Item(.Count - 1).SubItems.Add(daysExpired.ToString())
                        End With

                    Next

                End With

            Else
                'MsgBox("No records found from your filter", vbExclamation)
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
            SQL = SQL & " WHERE A.main_client_id = B.main_client_id AND SUB_CLIENT_STATUS = 'Active' GROUP BY A.main_client_name ORDER BY COUNT(B.SUB_CLIENT_ID) DESC"

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
            SQL = "SELECT COUNT(*) AS CLIENT_COUNT FROM (SELECT DISTINCT MAIN_CLIENT_ID FROM TBL_CLIENT_MAIN WHERE GLOBAL_STATUS = 'Active')"

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
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("DATE_FROM")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("DATE_TO")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))


                    Next
                End With
            Else
                'MsgBox("No records found from your filter", vbExclamation, "No records")
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

            ' For improvement: Instead of specific string , filter by data type - number
            SQL = "Select * from VIEW_PENDING_GOV_INFO WHERE UCASE(" & sField & ") in('NA','N/A', 'TO FOLLOW','FOR UPDATE') order by 1 asc" ' Called Views (Query)


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Pending_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("D.EMPLOYEE_ID")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(Format(CDate(myRow.Item("DATE_HIRED")), "dd-MMM-yyyy"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add("No Available Information")
                    Next
                End With
            Else
                'MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_HR_REPORTS.LV_Pending_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub
    Public Sub Show_in_Chart_Gender_statistics(sStatus As String)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select [GENDER], Count(*) As TotalCount"
            SQL = SQL & " From HR_APPLICATION_DTL A, HR_EMPLOYEE_RECORD_HDR B"
            SQL = SQL & " Where A.APPLICATION_ID = B.APPLICATION_ID And B.EMPLOYMENT_STATUS = 'Active'"
            SQL = SQL & " GROUP BY [GENDER] ORDER BY [GENDER]"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Report_Statistics1

                    Dim myRow As DataRow
                    .Items.Clear()
                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("GENDER")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("TotalCount"))


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

    Public Sub Show_in_Chart_Age_Statistics(sStatus As String)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            SQL = "SELECT "
            SQL = SQL & "DateDiff(""yyyy"", dtl.BIRTH_DATE, Date()) "
            SQL = SQL & "- IIf(Format(Date(), ""mmdd"") < Format(dtl.BIRTH_DATE, ""mmdd""), 1, 0) AS Age, "
            SQL = SQL & "Count(*) AS TotalCount "
            SQL = SQL & "FROM HR_EMPLOYEE_RECORD_HDR AS hdr "
            SQL = SQL & "INNER JOIN HR_APPLICATION_DTL AS dtl "
            SQL = SQL & "ON hdr.APPLICATION_ID = dtl.APPLICATION_ID "
            SQL = SQL & "WHERE hdr.EMPLOYMENT_STATUS = 'Active' "
            SQL = SQL & "AND dtl.BIRTH_DATE Is Not Null "
            SQL = SQL & "GROUP BY "
            SQL = SQL & "DateDiff(""yyyy"", dtl.BIRTH_DATE, Date()) "
            SQL = SQL & "- IIf(Format(Date(), ""mmdd"") < Format(dtl.BIRTH_DATE, ""mmdd""), 1, 0) "
            SQL = SQL & "ORDER BY "
            SQL = SQL & "DateDiff(""yyyy"", dtl.BIRTH_DATE, Date()) "
            SQL = SQL & "- IIf(Format(Date(), ""mmdd"") < Format(dtl.BIRTH_DATE, ""mmdd""), 1, 0)"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Report_Statistics1

                    Dim myRow As DataRow
                    .Items.Clear()
                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("Age")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("TotalCount"))


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

    Public Sub Show_in_Chart_Hired_Per_Year(sStatus As String)


        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            'SQL = "Select FORMAT(DATE_HIRED,'yyyy') AS YEAR_VALUE, count(*) as status_count From HR_EMPLOYEE_RECORD_HDR WHERE EMPLOYMENT_STATUS = '" & sStatus & "' Group By FORMAT(DATE_HIRED,'yyyy') order by 2 desc"

            ' I Removed the Status, since status can change over time
            SQL = "Select FORMAT(DATE_HIRED,'yyyy') AS YEAR_VALUE, count(*) as status_count From HR_EMPLOYEE_RECORD_HDR Group By FORMAT(DATE_HIRED,'yyyy') order by 2 desc"

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

    Public Sub Show_in_Chart_Hired_Per_Month(sStatus As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            'SQL = "Select FORMAT(DATE_HIRED,'yyyy') AS YEAR_VALUE, count(*) as status_count From HR_EMPLOYEE_RECORD_HDR WHERE EMPLOYMENT_STATUS = '" & sStatus & "' Group By FORMAT(DATE_HIRED,'yyyy') order by 2 desc"

            SQL = "SELECT Format([DATE_HIRED], ""yyyy-mm"") AS HireMonth, Count(*) AS TotalHired"
            SQL = SQL & " From HR_EMPLOYEE_RECORD_HDR"
            SQL = SQL & "  Where DATE_HIRED Is Not NULL AND Year([DATE_HIRED]) IN (Year(Date()), Year(Date()) - 1)"
            SQL = SQL & "  AND UCase(EMPLOYMENT_STATUS) like '%" & sStatus & "%'"
            SQL = SQL & " GROUP BY Format([DATE_HIRED], ""yyyy-mm"")"
            SQL = SQL & "  ORDER BY Format([DATE_HIRED], ""yyyy-mm"")"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_Report_Statistics1

                    Dim myRow As DataRow
                    .Items.Clear()
                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("HireMonth")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("TotalHired"))


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
            SQL = "Select STATUS, COUNT(*) As status_count From HR_APPLICAtion_hdr WHERE STATUS IN ('Active','Floating','Interview','Requirement','For Completion') Group By STATUS order by 2 DESC"
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

    Public Enum ExpiryFilter
            Exp1Month = 0
            Exp2Month = 1
            Exp3Month = 2
            Expired = 3
            NoRecord = 4
        End Enum

        Public Enum ExpiryType
            Medical = 0
            License = 1
            Insurance = 2
        End Enum




    Public Sub Show_Expiry(filter As ExpiryFilter, expType As ExpiryType)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim SQL As String

        Dim tableName As String = ""
        Dim dateField As String = ""

        Select Case expType
            Case ExpiryType.Insurance
                tableName = "HR_INSURANCE_DTL"
                dateField = "END_DATE"

            Case ExpiryType.Medical
                tableName = "HR_MEDICAL_RECORDS_DTL"
                dateField = "MED_EXP_DATE"

            Case ExpiryType.License
                tableName = "HR_SECURITY_LICENSE_RECORD_DTL"
                dateField = "SEC_EXP_DATE"
        End Select



        SQL = $"
SELECT *
FROM (
    (HR_APPLICATION_DTL A
        INNER JOIN HR_EMPLOYEE_RECORD_HDR B ON A.APPLICATION_ID = B.APPLICATION_ID)
        INNER JOIN TBL_CLIENT_SUB C ON B.SUB_CLIENT_ID = C.SUB_CLIENT_ID)
LEFT JOIN (
    SELECT X.*
    FROM {tableName} X
    WHERE X.{dateField} = (
        SELECT MAX({dateField})
        FROM {tableName}
        WHERE EMPLOYEE_ID = X.EMPLOYEE_ID
    )
) D ON D.EMPLOYEE_ID = B.EMPLOYEE_ID
WHERE B.EMPLOYMENT_STATUS = 'Active'
"


        Select Case filter
            Case ExpiryFilter.Exp1Month
                SQL &= $"AND D.{dateField} BETWEEN Date() AND DateAdd('d', 30, Date()) "
            Case ExpiryFilter.Exp2Month
                SQL &= $"AND D.{dateField} BETWEEN Date() AND DateAdd('d', 60, Date()) "
            Case ExpiryFilter.Exp3Month
                SQL &= $"AND D.{dateField} BETWEEN Date() AND DateAdd('d', 90, Date()) "
            Case ExpiryFilter.Expired
                SQL &= $"AND D.{dateField} < Date() "
            Case ExpiryFilter.NoRecord
                SQL &= $"AND D.{dateField} IS NULL "
        End Select

        SQL &= $" ORDER BY D.{dateField} ASC"



        Try
            da = New OleDb.OleDbDataAdapter(SQL, GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                FillListView_Expiry(dt, dateField)
            Else
                'MsgBox("No records found for this filter", vbExclamation)
                FRM_HR_REPORTS.LV_Expiry_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Sub FillListView_Expiry(dt As DataTable, dateField As String)

        With FRM_HR_REPORTS.LV_Expiry_List
            .Items.Clear()

            For Each row As DataRow In dt.Rows

                Dim empId As String = If(IsDBNull(row("B.EMPLOYEE_ID")), "", row("B.EMPLOYEE_ID").ToString())
                Dim lastName As String = If(IsDBNull(row("Last_Name")), "", row("Last_Name").ToString())
                Dim firstName As String = If(IsDBNull(row("First_Name")), "", row("First_Name").ToString())
                Dim middleName As String = If(IsDBNull(row("Middle_Name")), "", row("Middle_Name").ToString())
                Dim subClientName As String = If(IsDBNull(row("SUB_CLIENT_NAME")), "", row("SUB_CLIENT_NAME").ToString())

                Dim dateHiredStr As String = ""
                If Not IsDBNull(row("DATE_HIRED")) Then
                    dateHiredStr = CDate(row("DATE_HIRED")).ToString("dd-MMM-yyyy")
                End If

                Dim expDateStr As String = ""
                Dim daysExpired As String = ""

                If Not IsDBNull(row(dateField)) Then
                    Dim expDate As Date = CDate(row(dateField))
                    expDateStr = expDate.ToString("dd-MMM-yyyy")
                    daysExpired = (Date.Now - expDate).Days.ToString()
                End If

                With .Items
                    .Add(empId)
                    .Item(.Count - 1).SubItems.Add($"{lastName}, {firstName} {If(middleName <> "", Left(middleName, 1) & ".", "")}")
                    .Item(.Count - 1).SubItems.Add(dateHiredStr)
                    .Item(.Count - 1).SubItems.Add(subClientName)
                    .Item(.Count - 1).SubItems.Add(expDateStr)
                    .Item(.Count - 1).SubItems.Add(daysExpired)
                End With

            Next

        End With

    End Sub


End Module
