Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Module Mod_FRM_DTR_EXPORTS

    Public Sub Export_DTR_Per_Client_to_Excell(sClient As String, sAddress As String, sCutOff As String)

        Try
            Dim objExcel As New Excel.Application
            Dim objSheet As Excel.Worksheet
            objExcel.Visible = True
            objExcel.WindowState = Excel.XlWindowState.xlMaximized
            objExcel.Workbooks.Add()

            ' === Sheet1: Summary ===
            objSheet = objExcel.Sheets("Sheet1")
            objSheet.Cells.Clear()
            objSheet.Name = "SUMMARY"

            ' Header Info
            objSheet.Cells(2, 1).value = "Client ID:"
            objSheet.Cells(3, 1).value = "Client Address:"
            objSheet.Cells(4, 1).value = "Period:"

            objSheet.Cells(2, 2).value = UCase(FRM_DTR_EXPORTS.Lbl_Client_Name.Text)
            objSheet.Cells(3, 2).value = sAddress
            objSheet.Cells(4, 2).value = sCutOff

            ' Table Header
            objSheet.Cells(7, 1).value = "Employee Name"
            objSheet.Cells(7, 2).value = "No. of days"
            objSheet.Cells(7, 3).value = "Total Hours"
            objSheet.Cells(7, 4).value = "REG"
            objSheet.Cells(7, 5).value = "SUN"
            objSheet.Cells(7, 6).value = "SH"
            objSheet.Cells(7, 7).value = "LH"
            objSheet.Cells(7, 8).value = "OT REG"

            ' Fill ListView Data
            With FRM_DTR_EXPORTS.LV_DTR_Per_Client_List
                For iRow = 0 To .Items.Count - 1
                    For iCol = 1 To 8
                        If .Items(iRow).SubItems(iCol).Text = "" Then Exit For
                        objSheet.Cells(8 + iRow, iCol).value = .Items(iRow).SubItems(iCol).Text
                    Next iCol
                Next iRow
            End With

            ' === Sheet2: DGV_DTR_MATRIX ===
            Dim objSheet2 As Excel.Worksheet = CType(objExcel.Sheets.Add(After:=objExcel.Sheets(objExcel.Sheets.Count)), Excel.Worksheet)
            objSheet2.Name = "DAILY_TOTAL_HOURS"

            ' Copy same header info to Sheet2
            objSheet2.Cells(2, 1).value = "Client ID:"
            objSheet2.Cells(3, 1).value = "Client Address:"
            objSheet2.Cells(4, 1).value = "Period:"

            objSheet2.Cells(2, 2).value = UCase(FRM_DTR_EXPORTS.Lbl_Client_Name.Text)
            objSheet2.Cells(3, 2).value = sAddress
            objSheet2.Cells(4, 2).value = sCutOff

            ' Write DGV Matrix table below the header (start at row 7)
            Dim dgv As DataGridView = FRM_DTR_EXPORTS.DGV_DTR_MATRIX
            If dgv.Rows.Count > 0 Then
                ' Column Headers
                For col As Integer = 0 To dgv.Columns.Count - 1
                    objSheet2.Cells(7, col + 1).Value = dgv.Columns(col).HeaderText
                Next

                ' Data Rows
                For row As Integer = 0 To dgv.Rows.Count - 1
                    For col As Integer = 0 To dgv.Columns.Count - 1
                        If dgv(col, row).Value IsNot Nothing Then
                            objSheet2.Cells(row + 8, col + 1).Value = dgv(col, row).Value.ToString()
                        End If
                    Next
                Next
            End If
            ' Align all cells in Sheet2 (DAILY_TOTAL_HOURS) to middle
            With objSheet2.UsedRange
                .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Public Sub Get_DTR_Per_Client(iClient_ID As Integer, sCut_Off As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            'SQL = "select LAST_NAME, FIRST_NAME, MIDDLE_NAME, NUM_OF_DAYS, TOTAL_HOURS, REG, SUN,SH,LH, RD_SUN_SH, RD_SUN_LH, ND_REG, ND_SUN, ND_SH, ND_LH, ND_RD_SUN_SH, ND_RD_SUN_LH, OT_REG from VIEW_DTR_PER_SUB_CLIENT"
            'SQL = SQL & " where A.SUB_CLIENT_ID = " & iClient_ID & " and CUTOFF_PERIOD = '" & sCut_Off & "'"

            SQL = "SELECT LAST_NAME, FIRST_NAME, MIDDLE_NAME, NUM_OF_DAYS, TOTAL_HOURS, REG, SUN, SH, LH, OT_REG, CB_DEDUCT, SSS_LOAN_DEDUCT, PI_LOAN_DEDUCT "
            SQL = SQL & "FROM VIEW_DTR_PER_SUB_CLIENT A "
            SQL = SQL & "WHERE A.A.SUB_CLIENT_ID = " & iClient_ID & " AND A.CUTOFF_PERIOD = '" & sCut_Off & "' "
            SQL = SQL & "AND A.D.ID = (SELECT MAX(D.ID) FROM PRL_DTR_TOTAL_HOURS D WHERE D.EMPLOYEE_ID = A.A.EMPLOYEE_ID AND D.CUTOFF_PERIOD = A.CUTOFF_PERIOD) "
            SQL = SQL & "ORDER BY A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            With FRM_DTR_EXPORTS.LV_DTR_Per_Client_List
                .Items.Clear()
            End With

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_DTR_EXPORTS.LV_DTR_Per_Client_List
                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1

                    .Items.Clear()
                    For Each myRow In dt.Rows
                        .Items.Add(iRow.ToString()) ' item count
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LAST_NAME") & ", " & myRow.Item("FIRST_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("NUM_OF_DAYS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("TOTAL_HOURS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("REG"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUN"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("OT_REG"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("CB_DEDUCT"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SSS_LOAN_DEDUCT"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("PI_LOAN_DEDUCT"))

                        iRow += 1 ' Increment the row counter
                    Next
                End With
            Else
                FRM_DTR_EXPORTS.LV_DTR_Per_Client_List.Items.Clear()
                ' Handle cases where no rows exist in dt
            End If


        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Check VIEW_DTR_PER_SUB_CLIENT")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub
    Public Sub Generate_DTR_Hours_Matrix(iClient_ID As Integer, sCut_Off As String)

        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter

        ' Parse cutoff string like "7_1st_2025"
        Dim parts() As String = sCut_Off.Split("_"c)
        If parts.Length <> 3 Then
            MsgBox("Invalid cutoff format. Use M_1st_YYYY or M_2nd_YYYY.")
            Exit Sub
        End If

        Dim month As Integer = CInt(parts(0))
        Dim cutoffPart As String = parts(1).ToLower()
        Dim year As Integer = CInt(parts(2))

        Dim dFrom As Date
        Dim dTo As Date

        If cutoffPart = "1st" Then
            dFrom = New Date(year, month, 1)
            dTo = New Date(year, month, 15)
        ElseIf cutoffPart = "2nd" Then
            dFrom = New Date(year, month, 16)
            dTo = New Date(year, month, Date.DaysInMonth(year, month))
        Else
            MsgBox("Invalid cutoff part. Use '1st' or '2nd'.")
            Exit Sub
        End If

        ' SQL with TOTAL_HOURS from the view
        Dim SQL As String =
    "SELECT A.REPORT_DATE, A.REPORT_DAY, A.DAILY_TOTAL_HOURS, " &
    "B.LAST_NAME, B.FIRST_NAME, B.TOTAL_HOURS " &
    "FROM PRL_DTR_HOURS_PER_DAY AS A " &
    "INNER JOIN VIEW_DTR_PER_SUB_CLIENT AS B " &
    "ON A.EMPLOYEE_ID = B.A.EMPLOYEE_ID AND A.SUB_CLIENT_ID = B.A.SUB_CLIENT_ID " &
    "WHERE A.SUB_CLIENT_ID = " & iClient_ID & " " &
    "AND A.REPORT_DATE BETWEEN #" & dFrom.ToString("MM/dd/yyyy") & "# AND #" & dTo.ToString("MM/dd/yyyy") & "# " &
    "AND B.CUTOFF_PERIOD = '" & sCut_Off & "' " &
    "AND A.ID IN (" &
        "SELECT MAX(ID) FROM PRL_DTR_HOURS_PER_DAY " &
        "WHERE SUB_CLIENT_ID = " & iClient_ID & " " &
        "AND REPORT_DATE BETWEEN #" & dFrom.ToString("MM/dd/yyyy") & "# AND #" & dTo.ToString("MM/dd/yyyy") & "# " &
        "GROUP BY EMPLOYEE_ID, REPORT_DATE" &
    ") " &
    "ORDER BY B.LAST_NAME, B.FIRST_NAME, A.REPORT_DATE"


        Try
            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            With FRM_DTR_EXPORTS.DGV_DTR_MATRIX
                .DataSource = Nothing
                .Rows.Clear()
                .Refresh()
            End With
            If dt.Rows.Count = 0 Then

                MsgBox("No daily hour records found for the selected cutoff.")
                Exit Sub
            End If

            ' Create the header
            Dim headerTable As New DataTable()
            headerTable.Columns.Add("NAME")
            For day = dFrom.Day To dTo.Day
                headerTable.Columns.Add(day.ToString())
            Next
            headerTable.Columns.Add("TOTAL HOURS") ' <-- Add total hours at the end

            ' Add day name row
            Dim rowDayNames As DataRow = headerTable.NewRow()
            rowDayNames("NAME") = ""
            For day = dFrom.Day To dTo.Day
                Dim curDate As Date = New Date(year, month, day)
                rowDayNames(day.ToString()) = curDate.ToString("ddd")
            Next
            rowDayNames("TOTAL HOURS") = "Total"
            headerTable.Rows.Add(rowDayNames)

            ' Group by employee name
            Dim empGroups = dt.AsEnumerable().GroupBy(Function(r) r("LAST_NAME").ToString() & ", " & r("FIRST_NAME").ToString())

            For Each empGroup In empGroups
                Dim empRow As DataRow = headerTable.NewRow()
                empRow("NAME") = empGroup.Key

                ' Initialize all day columns to 0.00
                For day = dFrom.Day To dTo.Day
                    empRow(day.ToString()) = "0.00"
                Next
                ' Fill in available data from database
                For Each rec In empGroup
                    Dim day = CDate(rec("REPORT_DATE")).Day.ToString()
                    empRow(day) = FormatNumber(CDec(rec("DAILY_TOTAL_HOURS")), 2)
                Next


                ' Add total hours (even if some daily hours are missing)
                Dim totalHrs = empGroup.First()("TOTAL_HOURS")
                empRow("TOTAL HOURS") = FormatNumber(CDbl(totalHrs), 2)

                headerTable.Rows.Add(empRow)
            Next


            ' Bind to DataGridView
            With FRM_DTR_EXPORTS.DGV_DTR_MATRIX
                .DataSource = headerTable
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            GlobalVariables.GlobalCon.Close()
        End Try

    End Sub




End Module
