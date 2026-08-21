Imports System.Data.OleDb
Imports System.IO

Module Mod_FRM_DTR_EXPORTS

    Private Function TryGetNumericValue(value As String) As Double
        Dim parsedValue As Double
        If Double.TryParse(value, parsedValue) Then
            Return parsedValue
        End If

        Return 0
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
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .Width = If(width > 0, width, 76)
        }
        column.MinimumWidth = Math.Min(column.Width, 48)
        dgv.Columns.Add(column)
    End Sub

    Private Sub ConfigurePerClientGrid(cutoff As String)
        Dim dgv = FRM_DTR_EXPORTS.DGV_DTR_Per_Client
        dgv.Rows.Clear()
        dgv.Columns.Clear()
        dgv.AutoGenerateColumns = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False

        AddPerClientHiddenColumn(dgv, "colEmployeeId")
        AddPerClientColumn(dgv, "colItem", "Item", 52)
        AddPerClientColumn(dgv, "colName", "Employee Name", 220)
        dgv.Columns("colItem").Frozen = True
        dgv.Columns("colName").Frozen = True
        AddPerClientColumn(dgv, "colNumDays", "No. Days", 84)
        AddPerClientColumn(dgv, "colTotalHours", "Total Hours", 90)
        AddPerClientColumn(dgv, "colReg", "REG", 66)
        AddPerClientColumn(dgv, "colSun", "SUN", 66)
        AddPerClientColumn(dgv, "colLh", "LH", 66)
        AddPerClientColumn(dgv, "colSh", "SH", 66)
        AddPerClientColumn(dgv, "colSunLh", "SUN + LH", 88)
        AddPerClientColumn(dgv, "colSunSh", "SUN + SH", 88)
        AddPerClientColumn(dgv, "colNdReg", "ND REG", 78)
        AddPerClientColumn(dgv, "colNdSun", "ND SUN", 78)
        AddPerClientColumn(dgv, "colNdLh", "ND LH", 78)
        AddPerClientColumn(dgv, "colNdSh", "ND SH", 78)
        AddPerClientColumn(dgv, "colNdSunLh", "ND SUN + LH", 104)
        AddPerClientColumn(dgv, "colNdSunSh", "ND SUN + SH", 104)
        AddPerClientColumn(dgv, "colOtReg", "OT REG", 78)
        AddPerClientColumn(dgv, "colOtSun", "OT SUN", 78)
        AddPerClientColumn(dgv, "colOtLh", "OT LH", 78)
        AddPerClientColumn(dgv, "colOtSh", "OT SH", 78)
        AddPerClientColumn(dgv, "colOtSunLh", "OT SUN + LH", 104)
        AddPerClientColumn(dgv, "colOtSunSh", "OT SUN + SH", 104)
        AddPerClientHiddenColumn(dgv, "colNumNdDays")

        If IsFirstCutoff(cutoff) Then
            AddPerClientColumn(dgv, "colSss", "SSS", 70)
            AddPerClientColumn(dgv, "colSssProvident", "SSS Provident", 110)
            AddPerClientColumn(dgv, "colPhilHealth", "PhilHealth", 90)
            AddPerClientColumn(dgv, "colPagIbig", "Pag-IBIG", 90)
            AddPerClientColumn(dgv, "colOfficerAllo", "Officer Allo", 100)
            AddPerClientColumn(dgv, "colSgUniformAllowance", "SG Uniform Allowance", 120)
        ElseIf IsSecondCutoff(cutoff) Then
            AddPerClientColumn(dgv, "colCb", "Cash Bond", 90)
            AddPerClientColumn(dgv, "colSssLoan", "SSS Loan", 90)
            AddPerClientColumn(dgv, "colSssCalLoan", "SSS Cal Loan", 110)
            AddPerClientColumn(dgv, "colPiLoan", "PI Loan", 90)
            AddPerClientColumn(dgv, "colPiCalLoan", "PI Cal Loan", 110)
            AddPerClientColumn(dgv, "colOfficerAllo", "Officer Allo", 100)
            AddPerClientColumn(dgv, "colSgUniformAllowance", "SG Uniform Allowance", 120)
        End If
        AddPerClientColumn(dgv, "colOtherEarnings", "Other Earnings", 105)
        AddPerClientColumn(dgv, "colOtherDeductions", "Other Deductions", 115)
        For Each columnName In {
            "colSnapshotComplete", "colDailyWageSnapshot", "colRegEarnings", "colSunEarnings", "colLhEarnings", "colShEarnings",
            "colNdRegEarnings", "colNdSunEarnings", "colNdLhEarnings", "colNdShEarnings",
            "colOtRegEarnings", "colOtSunEarnings", "colOtLhEarnings", "colOtShEarnings",
            "colIncentiveEarnings", "colTotalEarnings", "colTotalDeductions", "colNetPay", "colCalculationVersion"}
            AddPerClientHiddenColumn(dgv, columnName)
        Next
    End Sub

    Public Sub Export_DTR_Per_Client_to_Excell(iSubClientId As Integer, sMainClient As String, sDetachment As String, sAddress As String, sDailyWage As String, sCutOff As String)
        Try
            If Not IsFirstCutoff(sCutOff) AndAlso Not IsSecondCutoff(sCutOff) Then
                Throw New Exception("Invalid cutoff format: " & sCutOff)
            End If

            Dim safeClient As String = MakeSafeFileName(sDetachment)
            Dim safeCutoff As String = MakeSafeFileName(sCutOff)

            Dim exportFolder As String = BuildExportFolder("Payroll EXPORTS", sDetachment, sCutOff)
            Dim outPath As String = Path.Combine(exportFolder,
            $"Payroll_{safeClient}_{safeCutoff}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx")

            PayrollReportService.CreatePayrollReport(
                outPath,
                sMainClient,
                sDetachment,
                sAddress,
                CDec(TryGetNumericValue(sDailyWage)),
                iSubClientId,
                sCutOff,
                FRM_DTR_EXPORTS.DGV_DTR_Per_Client,
                FRM_DTR_EXPORTS.DGV_DTR_MATRIX)

            Process.Start(outPath)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Payroll Report Export")
        End Try
    End Sub

    Public Sub Export_DTR_Hours_Per_Client_to_Excell(
    sMainClient As String,
    sDetachment As String,
    sAddress As String,
    sCutOff As String)
        Try
            If Not IsFirstCutoff(sCutOff) AndAlso Not IsSecondCutoff(sCutOff) Then
                Throw New Exception("Invalid cutoff format: " & sCutOff)
            End If

            Dim safeClient = MakeSafeFileName(sDetachment)
            Dim safeCutoff = MakeSafeFileName(sCutOff)

            Dim exportFolder = BuildExportFolder("DTR EXPORTS", sDetachment, sCutOff)
            Dim outPath = Path.Combine(exportFolder,
            $"DTR_Hours_{safeClient}_{safeCutoff}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx")

            PayrollReportService.CreateDtrHoursReport(
                outPath,
                sMainClient,
                sDetachment,
                sAddress,
                sCutOff,
                FRM_DTR_EXPORTS.DGV_DTR_MATRIX)

            Process.Start(outPath)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Export Error")
        End Try
    End Sub

    Private Function MakeSafeFileName(text As String) As String
        If String.IsNullOrWhiteSpace(text) Then Return "NA"
        Dim invalid = Path.GetInvalidFileNameChars()
        Dim cleaned = New String(text.Select(Function(ch) If(invalid.Contains(ch), "_"c, ch)).ToArray())
        cleaned = cleaned.Trim()
        If cleaned.Length = 0 Then cleaned = "NA"
        Return cleaned
    End Function

    Private Function BuildExportFolder(baseFolderName As String, clientName As String, cutoff As String) As String
        If String.IsNullOrWhiteSpace(baseFolderName) Then
            Throw New ArgumentException("Base folder name is required.", NameOf(baseFolderName))
        End If

        If String.IsNullOrWhiteSpace(cutoff) Then
            Throw New ArgumentException("Cutoff is required.", NameOf(cutoff))
        End If

        Dim parts = cutoff.Split("_"c)
        If parts.Length <> 3 Then
            Throw New FormatException("Invalid cutoff format. Expected: M_1st|2nd_YYYY")
        End If

        Dim monthNum As Integer = Integer.Parse(parts(0))
        Dim cutOffPart As String = parts(1).ToLowerInvariant()
        Dim yearNum As Integer = Integer.Parse(parts(2))

        If cutOffPart <> "1st" AndAlso cutOffPart <> "2nd" Then
            Throw New FormatException("Cutoff must be '1st' or '2nd'")
        End If

        Dim safeClient As String = MakeSafeFileName(clientName)
        Dim yearFolder As String = yearNum.ToString()
        Dim monthFolder As String = New DateTime(yearNum, monthNum, 1).ToString("MMMM").ToUpperInvariant()
        Dim cutoffFolder As String = cutOffPart

        Dim exportFolder As String = Path.Combine(Application.StartupPath, baseFolderName, safeClient, yearFolder, monthFolder, cutoffFolder)
        Directory.CreateDirectory(exportFolder)
        Return exportFolder
    End Function

    Public Sub Get_DTR_Per_Client(iClient_ID As Integer, sCut_Off As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            'SQL = "select LAST_NAME, FIRST_NAME, MIDDLE_NAME, NUM_OF_DAYS, TOTAL_HOURS, REG, SUN,SH,LH, RD_SUN_SH, RD_SUN_LH, ND_REG, ND_SUN, ND_SH, ND_LH, ND_RD_SUN_SH, ND_RD_SUN_LH, OT_REG from VIEW_DTR_PER_SUB_CLIENT"
            'SQL = SQL & " where A.SUB_CLIENT_ID = " & iClient_ID & " and CUTOFF_PERIOD = '" & sCut_Off & "'"

            ManualPayrollRecordService.EnsureSchema()
            SQL = "SELECT A.A.EMPLOYEE_ID AS EMPLOYEE_ID, LAST_NAME, FIRST_NAME, MIDDLE_NAME, NUM_OF_DAYS, ND_DAYS, TOTAL_HOURS, " &
                "REG, SUN, SH, LH, RD_SUN_SH, RD_SUN_LH, ND_REG, ND_SUN, ND_SH, ND_LH, ND_RD_SUN_SH, ND_RD_SUN_LH, " &
                "OT_REG, OT_SUN, OT_SH, OT_LH, OT_RD_SUN_SH, OT_RD_SUN_LH, " &
                "CB_DEDUCT, SSS_LOAN_DEDUCT, SSS_CAL_LOAN_DEDUCT, PI_LOAN_DEDUCT, PI_CAL_LOAN_DEDUCT, " &
                "SSS_DEDUCT, SSS_PROVIDENT_DEDUCT, PH_DEDUCT, PI_DEDUCT, OFFICERS_ALLOWANCE, SGUNIFORMALLOWANCE, " &
                "OTHER_EARNINGS, OTHER_DEDUCTIONS, SNAPSHOT_COMPLETE, DAILY_WAGE_SNAPSHOT, " &
                "REG_EARNINGS, SUN_EARNINGS, LH_EARNINGS, SH_EARNINGS, ND_REG_EARNINGS, ND_SUN_EARNINGS, ND_LH_EARNINGS, ND_SH_EARNINGS, " &
                "OT_REG_EARNINGS, OT_SUN_EARNINGS, OT_LH_EARNINGS, OT_SH_EARNINGS, INCENTIVE_EARNINGS, TOTAL_EARNINGS, TOTAL_DEDUCTIONS, NET_PAY, CALCULATION_VERSION "
            SQL = SQL & "FROM VIEW_DTR_PER_SUB_CLIENT A "
            SQL = SQL & "WHERE A.A.SUB_CLIENT_ID = " & iClient_ID & " AND A.CUTOFF_PERIOD = '" & sCut_Off & "' "
            SQL = SQL & "AND A.D.ID = (SELECT MAX(D.ID) FROM PRL_DTR_TOTAL_HOURS D " &
                "WHERE D.EMPLOYEE_ID = A.A.EMPLOYEE_ID AND D.SUB_CLIENT_ID = A.A.SUB_CLIENT_ID " &
                "AND D.CUTOFF_PERIOD = A.CUTOFF_PERIOD " &
                "AND (D.RECORD_STATUS = 'FINAL' OR D.RECORD_STATUS IS NULL OR D.RECORD_STATUS = '')) "
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
                                StandaloneHours(myRow, "LH", "RD_SUN_LH"),
                                StandaloneHours(myRow, "SH", "RD_SUN_SH"),
                                NzZero(myRow, "RD_SUN_LH"),
                                NzZero(myRow, "RD_SUN_SH"),
                                NzZero(myRow, "ND_REG"),
                                NzZero(myRow, "ND_SUN"),
                                StandaloneHours(myRow, "ND_LH", "ND_RD_SUN_LH"),
                                StandaloneHours(myRow, "ND_SH", "ND_RD_SUN_SH"),
                                NzZero(myRow, "ND_RD_SUN_LH"),
                                NzZero(myRow, "ND_RD_SUN_SH"),
                                NzZero(myRow, "OT_REG"),
                                NzZero(myRow, "OT_SUN"),
                                StandaloneHours(myRow, "OT_LH", "OT_RD_SUN_LH"),
                                StandaloneHours(myRow, "OT_SH", "OT_RD_SUN_SH"),
                                NzZero(myRow, "OT_RD_SUN_LH"),
                                NzZero(myRow, "OT_RD_SUN_SH"),
                                NzZero(myRow, "ND_DAYS"),
                                NzZero(myRow, "SSS_DEDUCT"),
                                NzZero(myRow, "SSS_PROVIDENT_DEDUCT"),
                                NzZero(myRow, "PH_DEDUCT"),
                                NzZero(myRow, "PI_DEDUCT"),
                                NzZero(myRow, "OFFICERS_ALLOWANCE"),
                                NzZero(myRow, "SGUNIFORMALLOWANCE"),
                                NzZero(myRow, "OTHER_EARNINGS"),
                                NzZero(myRow, "OTHER_DEDUCTIONS"),
                                NzBoolean(myRow, "SNAPSHOT_COMPLETE"),
                                NzZero(myRow, "DAILY_WAGE_SNAPSHOT"),
                                NzZero(myRow, "REG_EARNINGS"),
                                NzZero(myRow, "SUN_EARNINGS"),
                                NzZero(myRow, "LH_EARNINGS"),
                                NzZero(myRow, "SH_EARNINGS"),
                                NzZero(myRow, "ND_REG_EARNINGS"),
                                NzZero(myRow, "ND_SUN_EARNINGS"),
                                NzZero(myRow, "ND_LH_EARNINGS"),
                                NzZero(myRow, "ND_SH_EARNINGS"),
                                NzZero(myRow, "OT_REG_EARNINGS"),
                                NzZero(myRow, "OT_SUN_EARNINGS"),
                                NzZero(myRow, "OT_LH_EARNINGS"),
                                NzZero(myRow, "OT_SH_EARNINGS"),
                                NzZero(myRow, "INCENTIVE_EARNINGS"),
                                NzZero(myRow, "TOTAL_EARNINGS"),
                                NzZero(myRow, "TOTAL_DEDUCTIONS"),
                                NzZero(myRow, "NET_PAY"),
                                NzText(myRow, "CALCULATION_VERSION")
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
                                StandaloneHours(myRow, "LH", "RD_SUN_LH"),
                                StandaloneHours(myRow, "SH", "RD_SUN_SH"),
                                NzZero(myRow, "RD_SUN_LH"),
                                NzZero(myRow, "RD_SUN_SH"),
                                NzZero(myRow, "ND_REG"),
                                NzZero(myRow, "ND_SUN"),
                                StandaloneHours(myRow, "ND_LH", "ND_RD_SUN_LH"),
                                StandaloneHours(myRow, "ND_SH", "ND_RD_SUN_SH"),
                                NzZero(myRow, "ND_RD_SUN_LH"),
                                NzZero(myRow, "ND_RD_SUN_SH"),
                                NzZero(myRow, "OT_REG"),
                                NzZero(myRow, "OT_SUN"),
                                StandaloneHours(myRow, "OT_LH", "OT_RD_SUN_LH"),
                                StandaloneHours(myRow, "OT_SH", "OT_RD_SUN_SH"),
                                NzZero(myRow, "OT_RD_SUN_LH"),
                                NzZero(myRow, "OT_RD_SUN_SH"),
                                NzZero(myRow, "ND_DAYS"),
                                NzZero(myRow, "CB_DEDUCT"),
                                NzZero(myRow, "SSS_LOAN_DEDUCT"),
                                NzZero(myRow, "SSS_CAL_LOAN_DEDUCT"),
                                NzZero(myRow, "PI_LOAN_DEDUCT"),
                                NzZero(myRow, "PI_CAL_LOAN_DEDUCT"),
                                NzZero(myRow, "OFFICERS_ALLOWANCE"),
                                NzZero(myRow, "SGUNIFORMALLOWANCE"),
                                NzZero(myRow, "OTHER_EARNINGS"),
                                NzZero(myRow, "OTHER_DEDUCTIONS"),
                                NzBoolean(myRow, "SNAPSHOT_COMPLETE"),
                                NzZero(myRow, "DAILY_WAGE_SNAPSHOT"),
                                NzZero(myRow, "REG_EARNINGS"),
                                NzZero(myRow, "SUN_EARNINGS"),
                                NzZero(myRow, "LH_EARNINGS"),
                                NzZero(myRow, "SH_EARNINGS"),
                                NzZero(myRow, "ND_REG_EARNINGS"),
                                NzZero(myRow, "ND_SUN_EARNINGS"),
                                NzZero(myRow, "ND_LH_EARNINGS"),
                                NzZero(myRow, "ND_SH_EARNINGS"),
                                NzZero(myRow, "OT_REG_EARNINGS"),
                                NzZero(myRow, "OT_SUN_EARNINGS"),
                                NzZero(myRow, "OT_LH_EARNINGS"),
                                NzZero(myRow, "OT_SH_EARNINGS"),
                                NzZero(myRow, "INCENTIVE_EARNINGS"),
                                NzZero(myRow, "TOTAL_EARNINGS"),
                                NzZero(myRow, "TOTAL_DEDUCTIONS"),
                                NzZero(myRow, "NET_PAY"),
                                NzText(myRow, "CALCULATION_VERSION")
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

    Private Function NzBoolean(row As DataRow, col As String) As String
        If Not row.Table.Columns.Contains(col) OrElse row.IsNull(col) Then Return "0"
        Try
            Return If(Convert.ToBoolean(row(col)), "1", "0")
        Catch
            Return "0"
        End Try
    End Function

    Private Function StandaloneHours(row As DataRow, inclusiveColumn As String, combinedColumn As String) As String
        Dim inclusiveValue As Decimal
        Dim combinedValue As Decimal
        Decimal.TryParse(NzZero(row, inclusiveColumn), inclusiveValue)
        Decimal.TryParse(NzZero(row, combinedColumn), combinedValue)
        Return Math.Max(0D, inclusiveValue - combinedValue).ToString("0.##")
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
        pagibigDeduct As Decimal,
        officerAllowance As Decimal,
        sguniformallowance As Decimal
    )
        SubClientPayrollPolicyService.EnsureSchema()
        Dim latest = GetLatestDtrTotals(employeeId, cutoff)
        Dim ndDays = LatestDecimal(latest, "ND_DAYS")
        Dim ndReg = LatestDecimal(latest, "ND_REG")
        Dim ndSun = LatestDecimal(latest, "ND_SUN")
        Dim ndSh = LatestDecimal(latest, "ND_SH")
        Dim ndLh = LatestDecimal(latest, "ND_LH")
        Dim otSun = LatestDecimal(latest, "OT_SUN")
        Dim otSh = LatestDecimal(latest, "OT_SH")
        Dim otLh = LatestDecimal(latest, "OT_LH")

        Dim sql As String = "INSERT INTO PRL_DTR_TOTAL_HOURS " &
            "(EMPLOYEE_ID, SUB_CLIENT_ID, CUTOFF_PERIOD, NUM_OF_DAYS, " &
            "TOTAL_HOURS, REG, SUN, SH, LH, ND_DAYS, ND_REG, ND_SUN, ND_SH, ND_LH, " &
            "OT_REG, OT_SUN, OT_SH, OT_LH, " &
            "CB_DEDUCT, SSS_LOAN_DEDUCT, PI_LOAN_DEDUCT, PH_DEDUCT, SSS_DEDUCT, PI_DEDUCT, SSS_CAL_LOAN_DEDUCT, PI_CAL_LOAN_DEDUCT, OFFICERS_ALLOWANCE, SGUNIFORMALLOWANCE) " &
            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

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
                cmd.Parameters.AddWithValue("?", ndDays)
                cmd.Parameters.AddWithValue("?", ndReg)
                cmd.Parameters.AddWithValue("?", ndSun)
                cmd.Parameters.AddWithValue("?", ndSh)
                cmd.Parameters.AddWithValue("?", ndLh)
                cmd.Parameters.AddWithValue("?", otRegHours)
                cmd.Parameters.AddWithValue("?", otSun)
                cmd.Parameters.AddWithValue("?", otSh)
                cmd.Parameters.AddWithValue("?", otLh)
                cmd.Parameters.AddWithValue("?", cbDeduct)
                cmd.Parameters.AddWithValue("?", sssLoanDeduct)
                cmd.Parameters.AddWithValue("?", piLoanDeduct)
                cmd.Parameters.AddWithValue("?", philhealthDeduct)
                cmd.Parameters.AddWithValue("?", sssDeduct)
                cmd.Parameters.AddWithValue("?", pagibigDeduct)
                cmd.Parameters.AddWithValue("?", sssCalLoanDeduct)
                cmd.Parameters.AddWithValue("?", piCalLoanDeduct)
                cmd.Parameters.AddWithValue("?", officerAllowance)
                cmd.Parameters.AddWithValue("?", sguniformallowance)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Saving Deductions")
        End Try
    End Sub

    Public Function Export_Overall_Payroll_to_Excel(sCutOff As String) As OverallPayrollExportResult
        If Not IsFirstCutoff(sCutOff) AndAlso Not IsSecondCutoff(sCutOff) Then
            Throw New ArgumentException("Invalid cutoff format: " & sCutOff, NameOf(sCutOff))
        End If

        Dim exportFolder = BuildExportFolder("Payroll EXPORTS", "ALL ACTIVE CLIENTS", sCutOff)
        Dim safeCutoff = MakeSafeFileName(sCutOff)
        Dim outputPath = Path.Combine(exportFolder,
            $"Overall_Payroll_All_Active_Clients_{safeCutoff}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx")
        Return OverallPayrollExportService.CreateOverallPayrollReport(outputPath, sCutOff)
    End Function

    Private Function LatestDecimal(row As DataRow, columnName As String) As Decimal
        If row Is Nothing OrElse Not row.Table.Columns.Contains(columnName) OrElse row.IsNull(columnName) Then Return 0D
        Dim result As Decimal
        Decimal.TryParse(Convert.ToString(row(columnName)), result)
        Return result
    End Function

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
