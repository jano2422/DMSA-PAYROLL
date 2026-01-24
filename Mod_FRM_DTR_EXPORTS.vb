Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Module Mod_FRM_DTR_EXPORTS

    Private Sub WriteHeaderInfo(objSheet As Excel.Worksheet, sAddress As String, sCutOff As String)
        objSheet.Cells(2, 1).value = "Client ID:"
        objSheet.Cells(3, 1).value = "Client Address:"
        objSheet.Cells(4, 1).value = "Period:"

        objSheet.Cells(2, 2).value = UCase(FRM_DTR_EXPORTS.Lbl_Client_Name.Text)
        objSheet.Cells(3, 2).value = sAddress
        objSheet.Cells(4, 2).value = sCutOff
    End Sub

    Private Function TryGetNumericValue(value As String) As Double
        Dim parsedValue As Double
        If Double.TryParse(value, parsedValue) Then
            Return parsedValue
        End If

        Return 0
    End Function

    Private Sub FormatRangeAsTable(range As Excel.Range)
        With range.Borders
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
        End With
    End Sub

    Private Sub ApplySundayHeaderStyle(cell As Excel.Range)
        If cell Is Nothing Then Return
        With cell.Interior
            .ThemeColor = Excel.XlThemeColor.xlThemeColorAccent2
            .TintAndShade = 0.4
        End With
    End Sub

    Private Sub WriteDtrHoursMatrixToSheet(dtrSheet As Excel.Worksheet, dgv As DataGridView)
        If dtrSheet Is Nothing OrElse dgv Is Nothing OrElse dgv.Columns.Count = 0 Then Return

        Dim dayHeaderRow As Integer = 12
        Dim dayNumberRow As Integer = 13
        Dim dataStartRow As Integer = 15
        Dim nameCol As Integer = 1
        Dim dayStartCol As Integer = 2

        Dim dayColumns As New List(Of DataGridViewColumn)
        For i As Integer = 1 To dgv.Columns.Count - 2
            dayColumns.Add(dgv.Columns(i))
        Next

        Dim hasDayNameRow As Boolean = dgv.Rows.Count > 0 AndAlso Not dgv.Rows(0).IsNewRow
        If hasDayNameRow Then
            For i As Integer = 0 To dayColumns.Count - 1
                Dim dayNameValue = dgv.Rows(0).Cells(dayColumns(i).Index).Value
                Dim displayValue As String = If(dayNameValue, "").ToString()
                Dim headerCell As Excel.Range = dtrSheet.Cells(dayHeaderRow, dayStartCol + i)
                headerCell.Value = displayValue
                If displayValue.Trim().Equals("Sun", StringComparison.OrdinalIgnoreCase) Then
                    ApplySundayHeaderStyle(headerCell)
                End If
            Next
        End If

        For i As Integer = 0 To dayColumns.Count - 1
            dtrSheet.Cells(dayNumberRow, dayStartCol + i).Value = dayColumns(i).HeaderText
        Next

        Dim excelRow As Integer = dataStartRow
        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For
            If hasDayNameRow AndAlso row.Index = 0 Then Continue For

            dtrSheet.Cells(excelRow, nameCol).Value = row.Cells(0).Value
            For i As Integer = 0 To dayColumns.Count - 1
                Dim rawValue As String = Convert.ToString(row.Cells(dayColumns(i).Index).Value)
                dtrSheet.Cells(excelRow, dayStartCol + i).Value = TryGetNumericValue(rawValue)
            Next

            excelRow += 1
        Next
    End Sub

    Private Function ConvertCutOffStringToReadable(input As String) As String
        ' Input : "2_2nd_2025"
        ' Output: "16–28 FEBRUARY 2025"

        If String.IsNullOrWhiteSpace(input) Then Return ""

        Dim parts = input.Split("_"c)
        If parts.Length <> 3 Then
            Throw New FormatException("Invalid cutoff format. Expected: M_1st|2nd_YYYY")
        End If

        Dim monthNum As Integer = Integer.Parse(parts(0))
        Dim cutOffPart As String = parts(1).ToLower()
        Dim yearNum As Integer = Integer.Parse(parts(2))

        Dim startDate As Date
        Dim endDate As Date

        Select Case cutOffPart
            Case "1st"
                startDate = New Date(yearNum, monthNum, 1)
                endDate = New Date(yearNum, monthNum, 15)

            Case "2nd"
                startDate = New Date(yearNum, monthNum, 16)
                endDate = New Date(yearNum, monthNum,
                               Date.DaysInMonth(yearNum, monthNum))

            Case Else
                Throw New FormatException("Cutoff must be '1st' or '2nd'")
        End Select

        ' Format result
        Return $"{startDate.Day}-{endDate.Day} {startDate:MMMM yyyy}".ToUpper()
    End Function


    Public Function IsFirstCutoff(cutoff As String) As Boolean
        If String.IsNullOrWhiteSpace(cutoff) Then Return False
        Return cutoff.IndexOf("_1st_", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Public Function IsSecondCutoff(cutoff As String) As Boolean
        If String.IsNullOrWhiteSpace(cutoff) Then Return False
        Return cutoff.IndexOf("_2nd_", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Private Sub AddPerClientHiddenColumn(dgv As DataGridView, name As String)
        Dim column As New DataGridViewTextBoxColumn With {
            .Name = name,
            .Visible = False,
            .ReadOnly = True
        }
        dgv.Columns.Add(column)
    End Sub

    Private Sub AddPerClientColumn(dgv As DataGridView, name As String, header As String, Optional width As Integer = 0)
        Dim column As New DataGridViewTextBoxColumn With {
            .Name = name,
            .HeaderText = header,
            .ReadOnly = True,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        }
        If width > 0 Then
            column.MinimumWidth = width
            column.FillWeight = width
        End If
        dgv.Columns.Add(column)
    End Sub

    Private Sub ConfigurePerClientGrid(cutoff As String)
        Dim dgv = FRM_DTR_EXPORTS.DGV_DTR_Per_Client
        dgv.Rows.Clear()
        dgv.Columns.Clear()
        dgv.AutoGenerateColumns = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False

        AddPerClientHiddenColumn(dgv, "colEmployeeId")
        AddPerClientColumn(dgv, "colItem", "Item", 50)
        AddPerClientColumn(dgv, "colName", "Name", 200)
        AddPerClientColumn(dgv, "colNumDays", "No. of Days", 90)
        AddPerClientColumn(dgv, "colTotalHours", "Total Hours", 90)
        AddPerClientColumn(dgv, "colReg", "REG", 50)
        AddPerClientColumn(dgv, "colSun", "SUN", 50)
        AddPerClientColumn(dgv, "colSh", "SH", 50)
        AddPerClientColumn(dgv, "colLh", "LH", 50)
        AddPerClientColumn(dgv, "colOtReg", "OT REG", 90)

        If IsFirstCutoff(cutoff) Then
            AddPerClientColumn(dgv, "colSss", "SSS", 70)
            AddPerClientColumn(dgv, "colPhilHealth", "PhilHealth", 90)
            AddPerClientColumn(dgv, "colPagIbig", "Pag-IBIG", 90)
        ElseIf IsSecondCutoff(cutoff) Then
            AddPerClientColumn(dgv, "colCb", "Cash Bond", 90)
            AddPerClientColumn(dgv, "colSssLoan", "SSS Loan", 90)
            AddPerClientColumn(dgv, "colSssCalLoan", "SSS Cal Loan", 110)
            AddPerClientColumn(dgv, "colPiLoan", "PI Loan", 90)
            AddPerClientColumn(dgv, "colPiCalLoan", "PI Cal Loan", 110)
        End If
    End Sub

    Public Sub Export_DTR_Per_Client_to_Excell(sClient As String, sAddress As String, sCutOff As String)

        Dim xlApp As Excel.Application = Nothing
        Dim wbOut As Excel.Workbook = Nothing

        Dim payrollSheet As Excel.Worksheet = Nothing
        Dim payslipSheet As Excel.Worksheet = Nothing
        Dim dtrHoursSheet As Excel.Worksheet = Nothing

        Try
            xlApp = New Excel.Application With {
            .Visible = True,
            .WindowState = Excel.XlWindowState.xlMaximized,
            .DisplayAlerts = False
        }

            '========================================
            ' 1) Choose template workbook based on cutoff
            '========================================
            Dim templateFileName As String

            If IsFirstCutoff(sCutOff) Then
                templateFileName = "PayrollTemplate_1st.xlsx"
            ElseIf IsSecondCutoff(sCutOff) Then
                templateFileName = "PayrollTemplate_2nd.xlsx"
            Else
                Throw New Exception("Invalid cutoff format: " & sCutOff)
            End If

            Dim templatePath As String = Path.Combine(Application.StartupPath, templateFileName)
            If Not File.Exists(templatePath) Then
                Throw New FileNotFoundException("Template not found: " & templatePath)
            End If

            Dim safeClient As String = MakeSafeFileName(sClient)
            Dim safeCutoff As String = MakeSafeFileName(sCutOff)

            Dim outPath As String = Path.Combine(Application.StartupPath,
            $"Payroll_{safeClient}_{safeCutoff}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx")

            File.Copy(templatePath, outPath, True)

            '========================================
            ' 2) Open copied workbook (output)
            '========================================
            wbOut = xlApp.Workbooks.Open(outPath)

            payrollSheet = CType(wbOut.Worksheets("PAYROLL"), Excel.Worksheet)
            payslipSheet = CType(wbOut.Worksheets("PAYSLIP"), Excel.Worksheet)
            dtrHoursSheet = CType(wbOut.Worksheets("DTR_Hours"), Excel.Worksheet)

            '========================================
            ' 3) Fill header fields
            '========================================
            Dim readableCutOff As String = ConvertCutOffStringToReadable(sCutOff)

            payrollSheet.Range("B7").Value = sClient
            payrollSheet.Range("B8").Value = sAddress
            payrollSheet.Range("B9").Value = readableCutOff

            dtrHoursSheet.Range("B7").Value = sClient
            dtrHoursSheet.Range("B8").Value = sAddress
            dtrHoursSheet.Range("B10").Value = readableCutOff

            '========================================
            ' 4) Write rows from ListView
            '========================================
            Dim payrollDataStartRow As Integer = 15

            Dim firstCutoff As Boolean = IsFirstCutoff(sCutOff)


            Dim dgv = FRM_DTR_EXPORTS.DGV_DTR_Per_Client
            Dim rowIndex As Integer = 0
            For Each row As DataGridViewRow In dgv.Rows
                If row.IsNewRow Then Continue For
                Dim r As Integer = payrollDataStartRow + rowIndex

                payrollSheet.Cells(r, 1).Value = row.Cells("colName").Value 'NAME
                payrollSheet.Cells(r, 2).Value = row.Cells("colNumDays").Value 'NO DAYS
                payrollSheet.Cells(r, 3).Value = row.Cells("colTotalHours").Value 'TOTAL HOURS
                payrollSheet.Cells(r, 4).Value = row.Cells("colReg").Value 'REG
                payrollSheet.Cells(r, 5).Value = row.Cells("colSun").Value 'SUN
                payrollSheet.Cells(r, 8).Value = row.Cells("colLh").Value 'LH
                payrollSheet.Cells(r, 9).Value = row.Cells("colSh").Value 'SH
                payrollSheet.Cells(r, 11).Value = row.Cells("colOtReg").Value 'OT/HRS

                'Deductions
                If firstCutoff Then
                    '1st cutoff → Government deductions go to columns 12,13,14
                    payrollSheet.Cells(r, 20).Value = row.Cells("colSss").Value 'SSS
                    payrollSheet.Cells(r, 21).Value = row.Cells("colPhilHealth").Value 'PH
                    payrollSheet.Cells(r, 22).Value = row.Cells("colPagIbig").Value 'PI
                Else
                    '2nd cutoff → Loans/other deductions go to columns 20,21,22
                    payrollSheet.Cells(r, 20).Value = row.Cells("colCb").Value 'CB
                    payrollSheet.Cells(r, 21).Value = row.Cells("colSssLoan").Value 'SSS LOAN
                    payrollSheet.Cells(r, 22).Value = row.Cells("colSssCalLoan").Value 'SSS CAL LOAN
                    payrollSheet.Cells(r, 23).Value = row.Cells("colPiLoan").Value 'PI LOAN
                    payrollSheet.Cells(r, 24).Value = row.Cells("colPiCalLoan").Value 'PI CAL LOAN
                End If

                rowIndex += 1
            Next

            '========================================
            ' 4b) Write Hours Per Day matrix
            '========================================
            WriteDtrHoursMatrixToSheet(dtrHoursSheet, FRM_DTR_EXPORTS.DGV_DTR_MATRIX)

            '========================================
            ' 5) Calculate + save
            '========================================
            payrollSheet.Calculate()
            payslipSheet.Calculate()
            dtrHoursSheet.Calculate()
            wbOut.Save()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            ReleaseCom(dtrHoursSheet)
            ReleaseCom(payslipSheet)
            ReleaseCom(payrollSheet)
            ReleaseCom(wbOut)
            ReleaseCom(xlApp)
        End Try

    End Sub


    Public Sub Export_DTR_Hours_Per_Client_to_Excell(sClient As String, sAddress As String, sCutOff As String)

        Dim xlApp As Excel.Application = Nothing
        Dim wbOut As Excel.Workbook = Nothing


        Dim dtrHoursSheet As Excel.Worksheet = Nothing

        Try
            xlApp = New Excel.Application With {
            .Visible = True,
            .WindowState = Excel.XlWindowState.xlMaximized,
            .DisplayAlerts = False
        }

            '========================================
            ' 1) Choose template workbook based on cutoff
            '========================================
            Dim templateFileName As String

            If IsFirstCutoff(sCutOff) Then
                templateFileName = "DtrHoursTemplate_1st.xlsx"
            ElseIf IsSecondCutoff(sCutOff) Then
                templateFileName = "DtrHoursTemplate_2nd.xlsx"
            Else
                Throw New Exception("Invalid cutoff format: " & sCutOff)
            End If

            Dim templatePath As String = Path.Combine(Application.StartupPath, templateFileName)
            If Not File.Exists(templatePath) Then
                Throw New FileNotFoundException("Template not found: " & templatePath)
            End If

            Dim safeClient As String = MakeSafeFileName(sClient)
            Dim safeCutoff As String = MakeSafeFileName(sCutOff)

            Dim outPath As String = Path.Combine(Application.StartupPath,
            $"DTR_Hours_{safeClient}_{safeCutoff}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx")

            File.Copy(templatePath, outPath, True)

            '========================================
            ' 2) Open copied workbook (output)
            '========================================
            wbOut = xlApp.Workbooks.Open(outPath)


            dtrHoursSheet = CType(wbOut.Worksheets("DTR_Hours"), Excel.Worksheet)

            '========================================
            ' 3) Fill header fields
            '========================================
            Dim readableCutOff As String = ConvertCutOffStringToReadable(sCutOff)


            dtrHoursSheet.Range("B7").Value = sClient
            dtrHoursSheet.Range("B8").Value = sAddress
            dtrHoursSheet.Range("B10").Value = readableCutOff

            '========================================
            ' 4) Write rows from ListView
            '========================================

            Dim firstCutoff As Boolean = IsFirstCutoff(sCutOff)

            '========================================
            ' 4b) Write Hours Per Day matrix
            '========================================
            WriteDtrHoursMatrixToSheet(dtrHoursSheet, FRM_DTR_EXPORTS.DGV_DTR_MATRIX)

            '========================================
            ' 5) Calculate + save
            '========================================
            dtrHoursSheet.Calculate()
            wbOut.Save()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            ReleaseCom(dtrHoursSheet)

            ReleaseCom(wbOut)
            ReleaseCom(xlApp)
        End Try

    End Sub


    '--------------------------
    ' Helpers
    '--------------------------
    Private Function MakeSafeFileName(text As String) As String
        If String.IsNullOrWhiteSpace(text) Then Return "NA"
        Dim invalid = Path.GetInvalidFileNameChars()
        Dim cleaned = New String(text.Select(Function(ch) If(invalid.Contains(ch), "_"c, ch)).ToArray())
        cleaned = cleaned.Trim()
        If cleaned.Length = 0 Then cleaned = "NA"
        Return cleaned
    End Function

    Private Sub ReleaseCom(ByVal obj As Object)
        Try
            If obj IsNot Nothing AndAlso Marshal.IsComObject(obj) Then
                Marshal.FinalReleaseComObject(obj)
            End If
        Catch
        Finally
            obj = Nothing
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

            SQL = "SELECT A.A.EMPLOYEE_ID AS EMPLOYEE_ID, LAST_NAME, FIRST_NAME, MIDDLE_NAME, NUM_OF_DAYS, TOTAL_HOURS, REG, SUN, SH, LH, OT_REG, CB_DEDUCT, SSS_LOAN_DEDUCT, SSS_CAL_LOAN_DEDUCT, PI_LOAN_DEDUCT, PI_CAL_LOAN_DEDUCT,SSS_DEDUCT, PH_DEDUCT, PI_DEDUCT "
            SQL = SQL & "FROM VIEW_DTR_PER_SUB_CLIENT A "
            SQL = SQL & "WHERE A.A.SUB_CLIENT_ID = " & iClient_ID & " AND A.CUTOFF_PERIOD = '" & sCut_Off & "' "
            SQL = SQL & "AND A.D.ID = (SELECT MAX(D.ID) FROM PRL_DTR_TOTAL_HOURS D WHERE D.EMPLOYEE_ID = A.A.EMPLOYEE_ID AND D.CUTOFF_PERIOD = A.CUTOFF_PERIOD) "
            SQL = SQL & "ORDER BY A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            With FRM_DTR_EXPORTS.DGV_DTR_Per_Client
                .Rows.Clear()
                .Columns.Clear()
            End With

            ConfigurePerClientGrid(sCut_Off)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_DTR_EXPORTS.DGV_DTR_Per_Client
                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1

                    For Each myRow In dt.Rows
                        Dim fullName As String = $"{NzText(myRow, "LAST_NAME")}, {NzText(myRow, "FIRST_NAME")}"
                        Dim employeeId As String = NzText(myRow, "EMPLOYEE_ID")

                        If IsFirstCutoff(sCut_Off) Then
                            .Rows.Add(
                                employeeId,
                                iRow.ToString(),
                                fullName,
                                NzZero(myRow, "NUM_OF_DAYS"),
                                NzZero(myRow, "TOTAL_HOURS"),
                                NzZero(myRow, "REG"),
                                NzZero(myRow, "SUN"),
                                NzZero(myRow, "SH"),
                                NzZero(myRow, "LH"),
                                NzZero(myRow, "OT_REG"),
                                NzZero(myRow, "SSS_DEDUCT"),
                                NzZero(myRow, "PH_DEDUCT"),
                                NzZero(myRow, "PI_DEDUCT")
                            )
                        Else
                            .Rows.Add(
                                employeeId,
                                iRow.ToString(),
                                fullName,
                                NzZero(myRow, "NUM_OF_DAYS"),
                                NzZero(myRow, "TOTAL_HOURS"),
                                NzZero(myRow, "REG"),
                                NzZero(myRow, "SUN"),
                                NzZero(myRow, "SH"),
                                NzZero(myRow, "LH"),
                                NzZero(myRow, "OT_REG"),
                                NzZero(myRow, "CB_DEDUCT"),
                                NzZero(myRow, "SSS_LOAN_DEDUCT"),
                                NzZero(myRow, "SSS_CAL_LOAN_DEDUCT"),
                                NzZero(myRow, "PI_LOAN_DEDUCT"),
                                NzZero(myRow, "PI_CAL_LOAN_DEDUCT")
                            )
                        End If

                        iRow += 1
                    Next
                End With
            Else
                FRM_DTR_EXPORTS.DGV_DTR_Per_Client.Rows.Clear()
                ' Handle cases where no rows exist in dt
            End If


        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Check VIEW_DTR_PER_SUB_CLIENT")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Private Function NzText(row As DataRow, col As String) As String
        If row.IsNull(col) Then Return ""
        Return Convert.ToString(row(col)).Trim()
    End Function

    Private Function NzZero(row As DataRow, col As String) As String
        If row.IsNull(col) Then Return "0"

        Dim s As String = Convert.ToString(row(col)).Trim()
        If s = "" Then Return "0"

        Dim d As Decimal
        If Decimal.TryParse(s, d) Then
            ' Optional: format how you want
            Return d.ToString("0.##")
        End If

        ' If not numeric but not empty, return it (or return "0" if you prefer)
        Return s
    End Function

    Public Function GetLatestDtrTotals(employeeId As String, cutoff As String) As DataRow
        If String.IsNullOrWhiteSpace(employeeId) OrElse String.IsNullOrWhiteSpace(cutoff) Then
            Return Nothing
        End If

        Dim dt As New DataTable
        Dim sql As String = "SELECT TOP 1 * FROM PRL_DTR_TOTAL_HOURS WHERE EMPLOYEE_ID = ? AND CUTOFF_PERIOD = ? ORDER BY ID DESC"

        Try
            Connect_to_MDB()
            Using cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", employeeId)
                cmd.Parameters.AddWithValue("?", cutoff)
                Using adapter As New OleDbDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Loading DTR Totals")
        End Try

        If dt.Rows.Count = 0 Then
            Return Nothing
        End If

        Return dt.Rows(0)
    End Function

    Public Sub Save_DTR_Deductions_Update(
        employeeId As String,
        subClientId As Integer,
        cutoff As String,
        numDays As Decimal,
        totalHours As Decimal,
        regHours As Decimal,
        sunHours As Decimal,
        shHours As Decimal,
        lhHours As Decimal,
        otRegHours As Decimal,
        cbDeduct As Decimal,
        sssLoanDeduct As Decimal,
        sssCalLoanDeduct As Decimal,
        piLoanDeduct As Decimal,
        piCalLoanDeduct As Decimal,
        philhealthDeduct As Decimal,
        sssDeduct As Decimal,
        pagibigDeduct As Decimal
    )
        Dim sql As String = "INSERT INTO PRL_DTR_TOTAL_HOURS " &
            "(EMPLOYEE_ID, SUB_CLIENT_ID, CUTOFF_PERIOD, NUM_OF_DAYS, " &
            "TOTAL_HOURS, REG, SUN, SH, LH, OT_REG, " &
            "CB_DEDUCT, SSS_LOAN_DEDUCT, PI_LOAN_DEDUCT, PH_DEDUCT, SSS_DEDUCT, PI_DEDUCT, SSS_CAL_LOAN_DEDUCT, PI_CAL_LOAN_DEDUCT) " &
            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

        Try
            Connect_to_MDB()
            Using cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", employeeId)
                cmd.Parameters.AddWithValue("?", subClientId)
                cmd.Parameters.AddWithValue("?", cutoff)
                cmd.Parameters.AddWithValue("?", numDays)
                cmd.Parameters.AddWithValue("?", totalHours)
                cmd.Parameters.AddWithValue("?", regHours)
                cmd.Parameters.AddWithValue("?", sunHours)
                cmd.Parameters.AddWithValue("?", shHours)
                cmd.Parameters.AddWithValue("?", lhHours)
                cmd.Parameters.AddWithValue("?", otRegHours)
                cmd.Parameters.AddWithValue("?", cbDeduct)
                cmd.Parameters.AddWithValue("?", sssLoanDeduct)
                cmd.Parameters.AddWithValue("?", piLoanDeduct)
                cmd.Parameters.AddWithValue("?", philhealthDeduct)
                cmd.Parameters.AddWithValue("?", sssDeduct)
                cmd.Parameters.AddWithValue("?", pagibigDeduct)
                cmd.Parameters.AddWithValue("?", sssCalLoanDeduct)
                cmd.Parameters.AddWithValue("?", piCalLoanDeduct)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Saving Deductions")
        End Try
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
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .AutoResizeColumns()
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            GlobalVariables.GlobalCon.Close()
        End Try

    End Sub




End Module
