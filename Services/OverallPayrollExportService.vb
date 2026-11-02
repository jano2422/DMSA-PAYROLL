Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Imports ClosedXML.Excel

Public Class OverallPayrollExportResult
    Public Property OutputPath As String
    Public Property ActiveMainClientCount As Integer
    Public Property ActiveSubClientCount As Integer
    Public Property PayrollSubClientCount As Integer
    Public Property EmployeePayrollCount As Integer
    Public Property SnapshotCount As Integer
    Public Property LegacyRecalculatedCount As Integer
End Class

Friend Class OverallPayrollClient
    Public Property MainClientId As Integer
    Public Property MainClientName As String
    Public Property SubClientId As Integer
    Public Property SubClientName As String
    Public Property Address As String
    Public Property DailyWage As Decimal
End Class

Friend Class OverallPayrollRow
    Public Property PayrollRecordId As Integer
    Public Property MainClientId As Integer
    Public Property MainClientName As String
    Public Property SubClientId As Integer
    Public Property SubClientName As String
    Public Property EmployeeId As String
    Public Property EmployeeName As String
    Public Property Cutoff As String
    Public Property RecordStatus As String
    Public Property RevisionNo As Integer
    Public Property SnapshotSource As String
    Public Property CalculationVersion As String
    Public Property SubmittedAt As Nullable(Of Date)
    Public Property SubmittedBy As String
    Public Property DailyWage As Decimal
    Public Property NumberOfDays As Decimal
    Public Property NightDifferentialDays As Decimal
    Public Property TotalHours As Decimal
    Public Property RegularHours As Decimal
    Public Property SundayHours As Decimal
    Public Property LegalHolidayHours As Decimal
    Public Property SpecialHolidayHours As Decimal
    Public Property NightDifferentialRegularHours As Decimal
    Public Property NightDifferentialSundayHours As Decimal
    Public Property NightDifferentialLegalHolidayHours As Decimal
    Public Property NightDifferentialSpecialHolidayHours As Decimal
    Public Property OvertimeRegularHours As Decimal
    Public Property OvertimeSundayHours As Decimal
    Public Property OvertimeLegalHolidayHours As Decimal
    Public Property OvertimeSpecialHolidayHours As Decimal
    Public Property SundaySpecialHolidayHours As Decimal
    Public Property SundayLegalHolidayHours As Decimal
    Public Property NightDifferentialSundaySpecialHolidayHours As Decimal
    Public Property NightDifferentialSundayLegalHolidayHours As Decimal
    Public Property OvertimeSundaySpecialHolidayHours As Decimal
    Public Property OvertimeSundayLegalHolidayHours As Decimal
    Public Property RegularEarnings As Decimal
    Public Property SundayEarnings As Decimal
    Public Property LegalHolidayEarnings As Decimal
    Public Property SpecialHolidayEarnings As Decimal
    Public Property NightDifferentialRegularEarnings As Decimal
    Public Property NightDifferentialSundayEarnings As Decimal
    Public Property NightDifferentialLegalHolidayEarnings As Decimal
    Public Property NightDifferentialSpecialHolidayEarnings As Decimal
    Public Property OvertimeRegularEarnings As Decimal
    Public Property OvertimeSundayEarnings As Decimal
    Public Property OvertimeLegalHolidayEarnings As Decimal
    Public Property OvertimeSpecialHolidayEarnings As Decimal
    Public Property IncentivePay As Decimal
    Public Property OfficerAllowance As Decimal
    Public Property UniformAllowance As Decimal
    Public Property OtherEarnings As Decimal
    Public Property TotalEarnings As Decimal
    Public Property SssDeduction As Decimal
    Public Property SssProvidentDeduction As Decimal
    Public Property PhilHealthDeduction As Decimal
    Public Property PagIbigDeduction As Decimal
    Public Property CashBondDeduction As Decimal
    Public Property SssLoanDeduction As Decimal
    Public Property SssCalLoanDeduction As Decimal
    Public Property PagIbigLoanDeduction As Decimal
    Public Property PagIbigCalLoanDeduction As Decimal
    Public Property OtherDeductions As Decimal
    Public Property TotalDeductions As Decimal
    Public Property NetPay As Decimal
End Class

Public Module OverallPayrollExportService
    Private Const MoneyFormat As String = "#,##0.00;[Red]-#,##0.00;-"
    Private Const QuantityFormat As String = "0.00;-0.00;-"
    Private ReadOnly Teal As XLColor = XLColor.FromHtml("#007C78")
    Private ReadOnly DarkTeal As XLColor = XLColor.FromHtml("#005B58")
    Private ReadOnly LightTeal As XLColor = XLColor.FromHtml("#D9F0ED")
    Private ReadOnly LightOrange As XLColor = XLColor.FromHtml("#FFF0DD")

    Public Function CreateOverallPayrollReport(outputPath As String, cutoff As String) As OverallPayrollExportResult
        If String.IsNullOrWhiteSpace(outputPath) Then Throw New ArgumentException("Output path is required.", NameOf(outputPath))
        If Not IsFirstCutoff(cutoff) AndAlso Not IsSecondCutoff(cutoff) Then Throw New ArgumentException("Select a valid payroll cutoff.", NameOf(cutoff))

        ManualPayrollRecordService.EnsureSchema()
        Dim clients As List(Of OverallPayrollClient)
        Dim payrollRows As List(Of OverallPayrollRow)
        Using connection = CreateOpenConnection()
            clients = LoadActiveClients(connection)
            payrollRows = LoadPayrollRows(connection, clients, cutoff)
        End Using

        Dim parentFolder = Path.GetDirectoryName(outputPath)
        If Not String.IsNullOrWhiteSpace(parentFolder) Then Directory.CreateDirectory(parentFolder)
        BuildWorkbook(outputPath, cutoff, clients, payrollRows)

        Return New OverallPayrollExportResult With {
            .OutputPath = outputPath,
            .ActiveMainClientCount = clients.Select(Function(item) item.MainClientId).Distinct().Count(),
            .ActiveSubClientCount = clients.Count,
            .PayrollSubClientCount = payrollRows.Select(Function(item) item.SubClientId).Distinct().Count(),
            .EmployeePayrollCount = payrollRows.Count,
            .SnapshotCount = payrollRows.Where(Function(item) item.SnapshotSource = "SAVED SNAPSHOT").Count(),
            .LegacyRecalculatedCount = payrollRows.Where(Function(item) item.SnapshotSource = "LEGACY RECALCULATED").Count()
        }
    End Function

    Private Function LoadActiveClients(connection As OleDbConnection) As List(Of OverallPayrollClient)
        Const sql As String =
            "SELECT M.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], S.[SUB_CLIENT_ID], S.[SUB_CLIENT_NAME], S.[ADDRESS], S.[DAILY_WAGE] " &
            "FROM [TBL_CLIENT_MAIN] AS M INNER JOIN [TBL_CLIENT_SUB] AS S ON M.[MAIN_CLIENT_ID] = S.[MAIN_CLIENT_ID] " &
            "WHERE M.[GLOBAL_STATUS] = 'Active' AND S.[SUB_CLIENT_STATUS] = 'Active' " &
            "ORDER BY M.[MAIN_CLIENT_NAME], S.[SUB_CLIENT_NAME]"
        Dim result As New List(Of OverallPayrollClient)()
        Using command As New OleDbCommand(sql, connection)
            Using reader = command.ExecuteReader()
                While reader.Read()
                    result.Add(New OverallPayrollClient With {
                        .MainClientId = SafeInteger(reader, "MAIN_CLIENT_ID"),
                        .MainClientName = SafeText(reader, "MAIN_CLIENT_NAME"),
                        .SubClientId = SafeInteger(reader, "SUB_CLIENT_ID"),
                        .SubClientName = SafeText(reader, "SUB_CLIENT_NAME"),
                        .Address = SafeText(reader, "ADDRESS"),
                        .DailyWage = SafeDecimal(reader, "DAILY_WAGE")
                    })
                End While
            End Using
        End Using
        Return result
    End Function

    Private Function LoadPayrollRows(connection As OleDbConnection, clients As List(Of OverallPayrollClient), cutoff As String) As List(Of OverallPayrollRow)
        Dim clientsById = clients.ToDictionary(Function(item) item.SubClientId)
        Dim namesByEmployee = LoadEmployeeNames(connection)
        Dim source As New DataTable()
        Const sql As String =
            "SELECT * FROM [PRL_DTR_TOTAL_HOURS] WHERE [CUTOFF_PERIOD] = ? " &
            "AND ([RECORD_STATUS] = 'FINAL' OR [RECORD_STATUS] IS NULL OR [RECORD_STATUS] = '') ORDER BY [ID]"
        Using command As New OleDbCommand(sql, connection)
            command.Parameters.Add("?", OleDbType.VarWChar, 30).Value = cutoff
            Using adapter As New OleDbDataAdapter(command)
                adapter.Fill(source)
            End Using
        End Using

        Dim latestRows = source.AsEnumerable().
            Where(Function(row) clientsById.ContainsKey(RowInteger(row, "SUB_CLIENT_ID"))).
            GroupBy(Function(row) RowText(row, "EMPLOYEE_ID") & "|" & RowInteger(row, "SUB_CLIENT_ID").ToString(CultureInfo.InvariantCulture)).
            Select(Function(group) group.OrderByDescending(Function(row) RowInteger(row, "ID")).First()).
            ToList()

        Dim policyCache As New Dictionary(Of Integer, SubClientPayrollPolicy)()
        Dim result As New List(Of OverallPayrollRow)()
        For Each sourceRow In latestRows
            Dim subClientId = RowInteger(sourceRow, "SUB_CLIENT_ID")
            Dim client = clientsById(subClientId)
            Dim employeeId = RowText(sourceRow, "EMPLOYEE_ID")
            Dim employeeName = RowText(sourceRow, "EMPLOYEE_NAME_SNAPSHOT")
            If String.IsNullOrWhiteSpace(employeeName) AndAlso namesByEmployee.ContainsKey(employeeId) Then employeeName = namesByEmployee(employeeId)
            If String.IsNullOrWhiteSpace(employeeName) Then employeeName = employeeId

            Dim item As New OverallPayrollRow With {
                .PayrollRecordId = RowInteger(sourceRow, "ID"),
                .MainClientId = client.MainClientId,
                .MainClientName = client.MainClientName,
                .SubClientId = client.SubClientId,
                .SubClientName = client.SubClientName,
                .EmployeeId = employeeId,
                .EmployeeName = employeeName,
                .Cutoff = cutoff,
                .RecordStatus = NormalizeRecordStatus(RowText(sourceRow, "RECORD_STATUS")),
                .RevisionNo = RowInteger(sourceRow, "REVISION_NO"),
                .SubmittedAt = RowNullableDate(sourceRow, "SUBMITTED_AT"),
                .SubmittedBy = RowText(sourceRow, "SUBMITTED_BY"),
                .NumberOfDays = RowDecimal(sourceRow, "NUM_OF_DAYS"),
                .NightDifferentialDays = RowDecimal(sourceRow, "ND_DAYS"),
                .TotalHours = RowDecimal(sourceRow, "TOTAL_HOURS"),
                .RegularHours = RowDecimal(sourceRow, "REG"),
                .SundayHours = RowDecimal(sourceRow, "SUN"),
                .LegalHolidayHours = RowDecimal(sourceRow, "LH"),
                .SpecialHolidayHours = RowDecimal(sourceRow, "SH"),
                .NightDifferentialRegularHours = RowDecimal(sourceRow, "ND_REG"),
                .NightDifferentialSundayHours = RowDecimal(sourceRow, "ND_SUN"),
                .NightDifferentialLegalHolidayHours = RowDecimal(sourceRow, "ND_LH"),
                .NightDifferentialSpecialHolidayHours = RowDecimal(sourceRow, "ND_SH"),
                .OvertimeRegularHours = RowDecimal(sourceRow, "OT_REG"),
                .OvertimeSundayHours = RowDecimal(sourceRow, "OT_SUN"),
                .OvertimeLegalHolidayHours = RowDecimal(sourceRow, "OT_LH"),
                .OvertimeSpecialHolidayHours = RowDecimal(sourceRow, "OT_SH"),
                .SundaySpecialHolidayHours = RowDecimal(sourceRow, "RD_SUN_SH"),
                .SundayLegalHolidayHours = RowDecimal(sourceRow, "RD_SUN_LH"),
                .NightDifferentialSundaySpecialHolidayHours = RowDecimal(sourceRow, "ND_RD_SUN_SH"),
                .NightDifferentialSundayLegalHolidayHours = RowDecimal(sourceRow, "ND_RD_SUN_LH"),
                .OvertimeSundaySpecialHolidayHours = RowDecimal(sourceRow, "OT_RD_SUN_SH"),
                .OvertimeSundayLegalHolidayHours = RowDecimal(sourceRow, "OT_RD_SUN_LH"),
                .OfficerAllowance = RowDecimal(sourceRow, "OFFICERS_ALLOWANCE"),
                .UniformAllowance = RowDecimal(sourceRow, "SGUNIFORMALLOWANCE"),
                .OtherEarnings = RowDecimal(sourceRow, "OTHER_EARNINGS"),
                .SssDeduction = RowDecimal(sourceRow, "SSS_DEDUCT"),
                .SssProvidentDeduction = RowDecimal(sourceRow, "SSS_PROVIDENT_DEDUCT"),
                .PhilHealthDeduction = RowDecimal(sourceRow, "PH_DEDUCT"),
                .PagIbigDeduction = RowDecimal(sourceRow, "PI_DEDUCT"),
                .CashBondDeduction = RowDecimal(sourceRow, "CB_DEDUCT"),
                .SssLoanDeduction = RowDecimal(sourceRow, "SSS_LOAN_DEDUCT"),
                .SssCalLoanDeduction = RowDecimal(sourceRow, "SSS_CAL_LOAN_DEDUCT"),
                .PagIbigLoanDeduction = RowDecimal(sourceRow, "PI_LOAN_DEDUCT"),
                .PagIbigCalLoanDeduction = RowDecimal(sourceRow, "PI_CAL_LOAN_DEDUCT"),
                .OtherDeductions = RowDecimal(sourceRow, "OTHER_DEDUCTIONS")
            }

            Dim isSnapshot = RowBoolean(sourceRow, "SNAPSHOT_COMPLETE") AndAlso
                Not String.IsNullOrWhiteSpace(RowText(sourceRow, "CALCULATION_VERSION"))
            If isSnapshot Then
                PopulateSavedSnapshot(item, sourceRow, client)
            Else
                Dim policy As SubClientPayrollPolicy = Nothing
                If Not policyCache.TryGetValue(subClientId, policy) Then
                    policy = SubClientPayrollPolicyService.LoadPolicy(subClientId)
                    policyCache(subClientId) = policy
                End If
                PopulateLegacyCalculation(item, client.DailyWage, policy)
            End If
            result.Add(item)
        Next

        Return result.OrderBy(Function(item) item.MainClientName).
            ThenBy(Function(item) item.SubClientName).
            ThenBy(Function(item) item.EmployeeName).
            ToList()
    End Function

    Private Sub PopulateSavedSnapshot(item As OverallPayrollRow, row As DataRow, client As OverallPayrollClient)
        item.SnapshotSource = "SAVED SNAPSHOT"
        item.CalculationVersion = RowText(row, "CALCULATION_VERSION")
        item.DailyWage = RowDecimal(row, "DAILY_WAGE_SNAPSHOT")
        If item.DailyWage <= 0D Then item.DailyWage = client.DailyWage
        item.RegularEarnings = RowDecimal(row, "REG_EARNINGS")
        item.SundayEarnings = RowDecimal(row, "SUN_EARNINGS")
        item.SpecialHolidayEarnings = RowDecimal(row, "SH_EARNINGS")
        item.LegalHolidayEarnings = RowDecimal(row, "LH_EARNINGS")
        item.NightDifferentialRegularEarnings = RowDecimal(row, "ND_REG_EARNINGS")
        item.NightDifferentialSundayEarnings = RowDecimal(row, "ND_SUN_EARNINGS")
        item.NightDifferentialSpecialHolidayEarnings = RowDecimal(row, "ND_SH_EARNINGS")
        item.NightDifferentialLegalHolidayEarnings = RowDecimal(row, "ND_LH_EARNINGS")
        item.OvertimeRegularEarnings = RowDecimal(row, "OT_REG_EARNINGS")
        item.OvertimeSundayEarnings = RowDecimal(row, "OT_SUN_EARNINGS")
        item.OvertimeSpecialHolidayEarnings = RowDecimal(row, "OT_SH_EARNINGS")
        item.OvertimeLegalHolidayEarnings = RowDecimal(row, "OT_LH_EARNINGS")
        item.IncentivePay = RowDecimal(row, "INCENTIVE_EARNINGS")
        item.TotalEarnings = RowDecimal(row, "TOTAL_EARNINGS")
        item.TotalDeductions = RowDecimal(row, "TOTAL_DEDUCTIONS")
        item.NetPay = RowDecimal(row, "NET_PAY")
    End Sub

    Private Sub PopulateLegacyCalculation(item As OverallPayrollRow, dailyWage As Decimal, policy As SubClientPayrollPolicy)
        item.SnapshotSource = "LEGACY RECALCULATED"
        item.CalculationVersion = "CURRENT POLICY FALLBACK"
        item.DailyWage = dailyWage
        Dim normalizedHours = SubClientPayrollPolicyService.NormalizePayHours(
            policy,
            item.RegularHours, item.SundayHours, item.LegalHolidayHours, item.SpecialHolidayHours,
            item.NightDifferentialRegularHours, item.NightDifferentialSundayHours,
            item.NightDifferentialLegalHolidayHours, item.NightDifferentialSpecialHolidayHours,
            item.OvertimeRegularHours, item.OvertimeSundayHours,
            item.OvertimeLegalHolidayHours, item.OvertimeSpecialHolidayHours)
        item.RegularHours = normalizedHours("REG")
        item.SundayHours = normalizedHours("SUN")
        item.LegalHolidayHours = normalizedHours("LH")
        item.SpecialHolidayHours = normalizedHours("SH")
        item.NightDifferentialRegularHours = normalizedHours("ND_REG")
        item.NightDifferentialSundayHours = normalizedHours("ND_SUN")
        item.NightDifferentialLegalHolidayHours = normalizedHours("ND_LH")
        item.NightDifferentialSpecialHolidayHours = normalizedHours("ND_SH")
        item.OvertimeRegularHours = normalizedHours("OT_REG")
        item.OvertimeSundayHours = normalizedHours("OT_SUN")
        item.OvertimeLegalHolidayHours = normalizedHours("OT_LH")
        item.OvertimeSpecialHolidayHours = normalizedHours("OT_SH")
        Dim breakdown = SubClientPayrollPolicyService.CalculateEarningsBreakdown(
            policy, dailyWage, item.Cutoff, item.NumberOfDays, item.NightDifferentialDays,
            item.RegularHours, item.SundayHours, item.LegalHolidayHours, item.SpecialHolidayHours,
            item.NightDifferentialRegularHours, item.NightDifferentialSundayHours,
            item.NightDifferentialLegalHolidayHours, item.NightDifferentialSpecialHolidayHours,
            item.OvertimeRegularHours, item.OvertimeSundayHours,
            item.OvertimeLegalHolidayHours, item.OvertimeSpecialHolidayHours,
            item.OfficerAllowance, item.UniformAllowance, item.OtherEarnings)
        item.RegularEarnings = breakdown.AmountFor("REG")
        item.SundayEarnings = breakdown.AmountFor("SUN")
        item.LegalHolidayEarnings = breakdown.AmountFor("LH")
        item.SpecialHolidayEarnings = breakdown.AmountFor("SH")
        item.NightDifferentialRegularEarnings = breakdown.AmountFor("ND_REG")
        item.NightDifferentialSundayEarnings = breakdown.AmountFor("ND_SUN")
        item.NightDifferentialLegalHolidayEarnings = breakdown.AmountFor("ND_LH")
        item.NightDifferentialSpecialHolidayEarnings = breakdown.AmountFor("ND_SH")
        item.OvertimeRegularEarnings = breakdown.AmountFor("OT_REG")
        item.OvertimeSundayEarnings = breakdown.AmountFor("OT_SUN")
        item.OvertimeLegalHolidayEarnings = breakdown.AmountFor("OT_LH")
        item.OvertimeSpecialHolidayEarnings = breakdown.AmountFor("OT_SH")
        item.IncentivePay = breakdown.IncentivePay
        item.TotalEarnings = breakdown.TotalEarnings
        item.TotalDeductions = If(IsFirstCutoff(item.Cutoff),
            item.SssDeduction + item.SssProvidentDeduction + item.PhilHealthDeduction + item.PagIbigDeduction + item.OtherDeductions,
            item.CashBondDeduction + item.SssLoanDeduction + item.SssCalLoanDeduction +
                item.PagIbigLoanDeduction + item.PagIbigCalLoanDeduction + item.OtherDeductions)
        item.NetPay = item.TotalEarnings - item.TotalDeductions
    End Sub

    Private Function LoadEmployeeNames(connection As OleDbConnection) As Dictionary(Of String, String)
        Const sql As String =
            "SELECT H.[EMPLOYEE_ID], A.[LAST_NAME], A.[FIRST_NAME], A.[MIDDLE_NAME], H.[ID] " &
            "FROM [HR_EMPLOYEE_RECORD_HDR] AS H INNER JOIN [HR_APPLICATION_DTL] AS A " &
            "ON H.[APPLICATION_ID] = A.[APPLICATION_ID] ORDER BY H.[ID]"
        Dim result As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        Using command As New OleDbCommand(sql, connection)
            Using reader = command.ExecuteReader()
                While reader.Read()
                    Dim employeeId = SafeText(reader, "EMPLOYEE_ID")
                    Dim name = (SafeText(reader, "LAST_NAME") & ", " & SafeText(reader, "FIRST_NAME") & " " & SafeText(reader, "MIDDLE_NAME")).Trim()
                    If employeeId <> String.Empty Then result(employeeId) = name
                End While
            End Using
        End Using
        Return result
    End Function

    Private Sub BuildWorkbook(outputPath As String, cutoff As String, clients As List(Of OverallPayrollClient), rows As List(Of OverallPayrollRow))
        Dim settings = PayrollReportSettingsService.LoadSettingsOrDefault()
        Using workbook As New XLWorkbook()
            BuildSummarySheet(workbook, settings, cutoff, clients, rows)
            BuildCoverageSheet(workbook, cutoff, clients, rows)
            BuildEmployeeDetailSheet(workbook, cutoff, rows)
            workbook.CalculateMode = XLCalculateMode.Auto
            Try
                workbook.RecalculateAllFormulas()
            Catch
            End Try
            HideUnusedEmployeePayrollColumns(workbook.Worksheet("EMPLOYEE PAYROLL"), rows.Count)
            PayrollReportService.ApplyReadableReportLayout(workbook)
            workbook.SaveAs(outputPath)
        End Using
    End Sub

    Private Sub HideUnusedEmployeePayrollColumns(sheet As IXLWorksheet, payrollRowCount As Integer)
        Const dataStartRow As Integer = 6
        Dim dataEndRow = dataStartRow + payrollRowCount - 1
        Dim optionalColumns = Enumerable.Range(12, 28).
            Concat(Enumerable.Range(41, 10)).
            Concat(Enumerable.Range(56, 6)).
            ToArray()
        HideColumnsWithoutNumericData(sheet, dataStartRow, dataEndRow, optionalColumns)
    End Sub

    Private Sub HideColumnsWithoutNumericData(
        sheet As IXLWorksheet,
        dataStartRow As Integer,
        dataEndRow As Integer,
        columnNumbers As IEnumerable(Of Integer)
    )
        For Each columnNumber In columnNumbers.Distinct()
            Dim hasMeaningfulValue As Boolean = False
            For rowNumber As Integer = dataStartRow To dataEndRow
                If CellHasMeaningfulNumericValue(sheet.Cell(rowNumber, columnNumber)) Then
                    hasMeaningfulValue = True
                    Exit For
                End If
            Next
            If Not hasMeaningfulValue Then sheet.Column(columnNumber).Hide()
        Next
    End Sub

    Private Function CellHasMeaningfulNumericValue(cell As IXLCell) As Boolean
        Dim value As Object
        Try
            value = cell.Value
        Catch
            Return True
        End Try
        If value Is Nothing OrElse value Is DBNull.Value Then Return False

        Dim numericValue As Decimal
        If Decimal.TryParse(Convert.ToString(value, CultureInfo.CurrentCulture), NumberStyles.Any, CultureInfo.CurrentCulture, numericValue) OrElse
           Decimal.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, numericValue) Then
            Return Math.Abs(numericValue) > 0.0000001D
        End If

        ' Keep an unexpected formula error or nonnumeric result visible for investigation.
        Return Not String.IsNullOrWhiteSpace(Convert.ToString(value, CultureInfo.CurrentCulture))
    End Function

    Private Sub BuildSummarySheet(workbook As XLWorkbook, settings As PayrollReportSettings, cutoff As String, clients As List(Of OverallPayrollClient), rows As List(Of OverallPayrollRow))
        Dim sheet = workbook.Worksheets.Add("SUMMARY")
        sheet.Range("A1:H1").Merge()
        sheet.Cell("A1").Value = settings.CompanyName
        sheet.Range("A2:H2").Merge()
        sheet.Cell("A2").Value = "OVERALL PAYROLL - ALL ACTIVE CLIENTS"
        sheet.Range("A3:H3").Merge()
        sheet.Cell("A3").Value = "Period: " & FormatCutoff(cutoff) & " | Generated: " & Date.Now.ToString("yyyy-MM-dd HH:mm")
        sheet.Range("A1:H1").Style.Font.Bold = True
        sheet.Range("A1:H1").Style.Font.FontSize = 16
        sheet.Range("A2:H2").Style.Font.Bold = True
        sheet.Range("A2:H2").Style.Font.FontSize = 13
        sheet.Range("A1:H3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

        Dim metrics = New Object(,) {
            {"Active main clients", clients.Select(Function(item) item.MainClientId).Distinct().Count()},
            {"Active detachments", clients.Count},
            {"Detachments with payroll", rows.Select(Function(item) item.SubClientId).Distinct().Count()},
            {"Employee payroll records", rows.Count},
            {"Saved monetary snapshots", rows.Where(Function(item) item.SnapshotSource = "SAVED SNAPSHOT").Count()},
            {"Legacy recalculated records", rows.Where(Function(item) item.SnapshotSource = "LEGACY RECALCULATED").Count()}
        }
        sheet.Cell("A5").Value = "Coverage"
        sheet.Cell("B5").Value = "Count"
        For index As Integer = 0 To metrics.GetLength(0) - 1
            sheet.Cell(index + 6, 1).Value = CStr(metrics(index, 0))
            sheet.Cell(index + 6, 2).Value = CInt(metrics(index, 1))
        Next

        sheet.Cell("D5").Value = "Payroll totals"
        sheet.Cell("E5").Value = "Amount"
        sheet.Cell("D6").Value = "Total earnings"
        sheet.Cell("D7").Value = "Total deductions"
        sheet.Cell("D8").Value = "Net payroll"
        If rows.Count > 0 Then
            Dim detailStartRow = 6
            Dim detailEndRow = detailStartRow + rows.Count - 1
            sheet.Cell("E6").FormulaA1 = $"SUM('EMPLOYEE PAYROLL'!AN{detailStartRow}:AN{detailEndRow})"
            sheet.Cell("E7").FormulaA1 = $"SUM('EMPLOYEE PAYROLL'!AY{detailStartRow}:AY{detailEndRow})"
            sheet.Cell("E8").FormulaA1 = $"SUM('EMPLOYEE PAYROLL'!AZ{detailStartRow}:AZ{detailEndRow})"
        Else
            sheet.Range("E6:E8").Value = 0D
        End If

        For Each range In {sheet.Range("A5:B5"), sheet.Range("D5:E5")}
            range.Style.Fill.BackgroundColor = Teal
            range.Style.Font.FontColor = XLColor.White
            range.Style.Font.Bold = True
        Next
        sheet.Range("E6:E8").Style.NumberFormat.Format = MoneyFormat
        sheet.Range("A5:B11").Style.Border.OutsideBorder = XLBorderStyleValues.Thin
        sheet.Range("A5:B11").Style.Border.InsideBorder = XLBorderStyleValues.Thin
        sheet.Range("D5:E8").Style.Border.OutsideBorder = XLBorderStyleValues.Thin
        sheet.Range("D5:E8").Style.Border.InsideBorder = XLBorderStyleValues.Thin
        sheet.Cell("A13").Value = "Important: SAVED SNAPSHOT rows use the finalized stored amounts. LEGACY RECALCULATED rows use the current client wage and payroll policy because older records did not store monetary details."
        sheet.Range("A13:H14").Merge()
        sheet.Range("A13:H14").Style.Alignment.WrapText = True
        sheet.Range("A13:H14").Style.Fill.BackgroundColor = LightOrange
        sheet.Columns("A:H").Width = 18
        sheet.Column("A").Width = 34
        sheet.Column("D").Width = 26
        sheet.Column("E").Width = 18
        sheet.ShowGridLines = False
        sheet.SheetView.FreezeRows(3)
    End Sub

    Private Sub BuildCoverageSheet(workbook As XLWorkbook, cutoff As String, clients As List(Of OverallPayrollClient), rows As List(Of OverallPayrollRow))
        Dim sheet = workbook.Worksheets.Add("CLIENT COVERAGE")
        Dim headers = {"MAIN CLIENT ID", "MAIN CLIENT", "DETACHMENT ID", "DETACHMENT", "ADDRESS", "DAILY WAGE", "EMPLOYEE PAYROLLS", "SAVED SNAPSHOTS", "LEGACY RECALCULATED", "TOTAL EARNINGS", "TOTAL DEDUCTIONS", "NET PAYROLL", "COVERAGE STATUS"}
        WriteSheetTitle(sheet, headers.Length, "ACTIVE CLIENT PAYROLL COVERAGE", cutoff)
        For index As Integer = 0 To headers.Length - 1
            sheet.Cell(5, index + 1).Value = headers(index)
        Next
        StyleHeader(sheet.Range(5, 1, 5, headers.Length))

        For index As Integer = 0 To clients.Count - 1
            Dim client = clients(index)
            Dim clientRows = rows.Where(Function(item) item.SubClientId = client.SubClientId).ToList()
            Dim rowNumber = index + 6
            Dim values As Object() = {
                client.MainClientId, client.MainClientName, client.SubClientId, client.SubClientName, client.Address, client.DailyWage,
                clientRows.Count,
                clientRows.Where(Function(item) item.SnapshotSource = "SAVED SNAPSHOT").Count(),
                clientRows.Where(Function(item) item.SnapshotSource = "LEGACY RECALCULATED").Count(),
                clientRows.Sum(Function(item) item.TotalEarnings),
                clientRows.Sum(Function(item) item.TotalDeductions),
                clientRows.Sum(Function(item) item.NetPay),
                If(clientRows.Count = 0, "NO FINAL PAYROLL", "PAYROLL AVAILABLE")
            }
            For column As Integer = 0 To values.Length - 1
                SetObjectCellValue(sheet.Cell(rowNumber, column + 1), values(column))
            Next
            If clientRows.Count = 0 Then sheet.Range(rowNumber, 1, rowNumber, headers.Length).Style.Fill.BackgroundColor = LightOrange
        Next

        Dim lastRow = Math.Max(6, clients.Count + 5)
        sheet.Range(6, 6, lastRow, 6).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(6, 10, lastRow, 12).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(5, 1, lastRow, headers.Length).SetAutoFilter()
        sheet.SheetView.FreezeRows(5)
        sheet.Columns().AdjustToContents()
        CapColumnWidths(sheet, headers.Length, 42D)
        sheet.ShowGridLines = False
    End Sub

    Private Sub BuildEmployeeDetailSheet(workbook As XLWorkbook, cutoff As String, rows As List(Of OverallPayrollRow))
        Dim sheet = workbook.Worksheets.Add("EMPLOYEE PAYROLL")
        Const lastColumn As Integer = 61
        WriteSheetTitle(sheet, lastColumn, "EMPLOYEE PAYROLL DETAIL", cutoff)
        SetGroupHeader(sheet, 1, 8, "EMPLOYEE AND CLIENT")
        SetGroupHeader(sheet, 9, 23, "PAY BASIS AND HOURS")
        SetGroupHeader(sheet, 24, 40, "EARNINGS")
        SetGroupHeader(sheet, 41, 52, "DEDUCTIONS AND NET PAY")
        SetGroupHeader(sheet, 53, 55, "AUDIT")
        SetGroupHeader(sheet, 56, 61, "COMBINED SUNDAY + HOLIDAY HOURS")
        Dim headers = {
            "MAIN CLIENT", "DETACHMENT", "EMPLOYEE ID", "EMPLOYEE NAME", "CUTOFF", "RECORD STATUS", "REVISION", "SNAPSHOT SOURCE",
            "DAILY WAGE", "NO. DAYS", "TOTAL HOURS", "REG HRS", "SUN HRS", "LH HRS", "SH HRS", "ND REG HRS", "ND SUN HRS", "ND LH HRS", "ND SH HRS", "OT REG HRS", "OT SUN HRS", "OT LH HRS", "OT SH HRS",
            "REG EARNINGS", "SUN EARNINGS", "LH EARNINGS (INCL SUN + LH)", "SH EARNINGS (INCL SUN + SH)", "ND REG EARNINGS", "ND SUN EARNINGS", "ND LH EARNINGS (INCL COMBINED)", "ND SH EARNINGS (INCL COMBINED)", "OT REG EARNINGS", "OT SUN EARNINGS", "OT LH EARNINGS (INCL COMBINED)", "OT SH EARNINGS (INCL COMBINED)", "INCENTIVE PAY", "OFFICER ALLOWANCE", "UNIFORM ALLOWANCE", "OTHER EARNINGS", "TOTAL EARNINGS",
            "SSS", "SSS PROVIDENT", "PHILHEALTH", "PAG-IBIG", "CASH BOND", "SSS LOAN", "SSS CAL LOAN", "PAG-IBIG LOAN", "PAG-IBIG CAL LOAN", "OTHER DEDUCTIONS", "TOTAL DEDUCTIONS", "NET PAY", "SUBMITTED AT", "SUBMITTED BY", "CALCULATION VERSION",
            "SUN + SH HRS", "SUN + LH HRS", "ND SUN + SH HRS", "ND SUN + LH HRS", "OT SUN + SH HRS", "OT SUN + LH HRS"
        }
        For index As Integer = 0 To headers.Length - 1
            sheet.Cell(5, index + 1).Value = headers(index)
        Next
        StyleHeader(sheet.Range(5, 1, 5, lastColumn))

        For index As Integer = 0 To rows.Count - 1
            WriteEmployeeRow(sheet, index + 6, rows(index))
        Next
        Dim lastRow = Math.Max(6, rows.Count + 5)
        sheet.Range(6, 9, lastRow, 23).Style.NumberFormat.Format = QuantityFormat
        sheet.Range(6, 9, lastRow, 9).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(6, 24, lastRow, 52).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(6, 53, lastRow, 53).Style.DateFormat.Format = "yyyy-mm-dd hh:mm"
        sheet.Range(6, 56, lastRow, 61).Style.NumberFormat.Format = QuantityFormat
        sheet.Range(5, 1, lastRow, lastColumn).SetAutoFilter()
        sheet.SheetView.FreezeRows(5)
        sheet.SheetView.FreezeColumns(4)
        sheet.Columns(1, lastColumn).Width = 13
        sheet.Column(1).Width = 26
        sheet.Column(2).Width = 28
        sheet.Column(3).Width = 14
        sheet.Column(4).Width = 28
        sheet.Column(8).Width = 22
        sheet.Column(54).Width = 20
        sheet.Column(55).Width = 24
        sheet.Columns(56, 61).Width = 22
        sheet.Rows(5, lastRow).Height = 20
        sheet.Row(5).Height = 42
        sheet.ShowGridLines = False
    End Sub

    Private Sub WriteEmployeeRow(sheet As IXLWorksheet, rowNumber As Integer, item As OverallPayrollRow)
        Dim values As Object() = {
            item.MainClientName, item.SubClientName, item.EmployeeId, item.EmployeeName, item.Cutoff, item.RecordStatus, item.RevisionNo, item.SnapshotSource,
            item.DailyWage, item.NumberOfDays, item.TotalHours, item.RegularHours, item.SundayHours,
            StandaloneClassificationHours(item.LegalHolidayHours, item.SundayLegalHolidayHours),
            StandaloneClassificationHours(item.SpecialHolidayHours, item.SundaySpecialHolidayHours),
            item.NightDifferentialRegularHours, item.NightDifferentialSundayHours,
            StandaloneClassificationHours(item.NightDifferentialLegalHolidayHours, item.NightDifferentialSundayLegalHolidayHours),
            StandaloneClassificationHours(item.NightDifferentialSpecialHolidayHours, item.NightDifferentialSundaySpecialHolidayHours),
            item.OvertimeRegularHours, item.OvertimeSundayHours,
            StandaloneClassificationHours(item.OvertimeLegalHolidayHours, item.OvertimeSundayLegalHolidayHours),
            StandaloneClassificationHours(item.OvertimeSpecialHolidayHours, item.OvertimeSundaySpecialHolidayHours),
            item.RegularEarnings, item.SundayEarnings, item.LegalHolidayEarnings, item.SpecialHolidayEarnings,
            item.NightDifferentialRegularEarnings, item.NightDifferentialSundayEarnings, item.NightDifferentialLegalHolidayEarnings, item.NightDifferentialSpecialHolidayEarnings,
            item.OvertimeRegularEarnings, item.OvertimeSundayEarnings, item.OvertimeLegalHolidayEarnings, item.OvertimeSpecialHolidayEarnings,
            item.IncentivePay, item.OfficerAllowance, item.UniformAllowance, item.OtherEarnings, item.TotalEarnings,
            item.SssDeduction, item.SssProvidentDeduction, item.PhilHealthDeduction, item.PagIbigDeduction, item.CashBondDeduction,
            item.SssLoanDeduction, item.SssCalLoanDeduction, item.PagIbigLoanDeduction, item.PagIbigCalLoanDeduction, item.OtherDeductions,
            item.TotalDeductions, item.NetPay, If(item.SubmittedAt.HasValue, CType(item.SubmittedAt.Value, Object), Nothing), item.SubmittedBy, item.CalculationVersion,
            item.SundaySpecialHolidayHours, item.SundayLegalHolidayHours,
            item.NightDifferentialSundaySpecialHolidayHours, item.NightDifferentialSundayLegalHolidayHours,
            item.OvertimeSundaySpecialHolidayHours, item.OvertimeSundayLegalHolidayHours
        }
        For index As Integer = 0 To values.Length - 1
            If values(index) IsNot Nothing Then SetObjectCellValue(sheet.Cell(rowNumber, index + 1), values(index))
        Next
        If item.SnapshotSource = "LEGACY RECALCULATED" Then sheet.Range(rowNumber, 1, rowNumber, 61).Style.Fill.BackgroundColor = XLColor.FromHtml("#FFF9E8")
    End Sub

    Private Sub WriteSheetTitle(sheet As IXLWorksheet, lastColumn As Integer, title As String, cutoff As String)
        sheet.Range(1, 1, 1, lastColumn).Merge()
        sheet.Cell(1, 1).Value = title
        sheet.Range(2, 1, 2, lastColumn).Merge()
        sheet.Cell(2, 1).Value = "Period: " & FormatCutoff(cutoff) & " | Generated: " & Date.Now.ToString("yyyy-MM-dd HH:mm")
        sheet.Range(1, 1, 1, lastColumn).Style.Fill.BackgroundColor = DarkTeal
        sheet.Range(1, 1, 1, lastColumn).Style.Font.FontColor = XLColor.White
        sheet.Range(1, 1, 1, lastColumn).Style.Font.Bold = True
        sheet.Range(1, 1, 1, lastColumn).Style.Font.FontSize = 14
        sheet.Range(1, 1, 2, lastColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    End Sub

    Private Sub SetGroupHeader(sheet As IXLWorksheet, firstColumn As Integer, lastColumn As Integer, title As String)
        sheet.Range(4, firstColumn, 4, lastColumn).Merge()
        sheet.Cell(4, firstColumn).Value = title
        sheet.Range(4, firstColumn, 4, lastColumn).Style.Fill.BackgroundColor = Teal
        sheet.Range(4, firstColumn, 4, lastColumn).Style.Font.FontColor = XLColor.White
        sheet.Range(4, firstColumn, 4, lastColumn).Style.Font.Bold = True
        sheet.Range(4, firstColumn, 4, lastColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
    End Sub

    Private Sub StyleHeader(range As IXLRange)
        range.Style.Fill.BackgroundColor = LightTeal
        range.Style.Font.Bold = True
        range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        range.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        range.Style.Alignment.WrapText = True
        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
        range.Style.Border.InsideBorder = XLBorderStyleValues.Thin
    End Sub

    Private Sub CapColumnWidths(sheet As IXLWorksheet, lastColumn As Integer, maximumWidth As Double)
        For column As Integer = 1 To lastColumn
            If sheet.Column(column).Width > maximumWidth Then sheet.Column(column).Width = maximumWidth
        Next
    End Sub

    Private Sub SetObjectCellValue(cell As IXLCell, value As Object)
        If value Is Nothing OrElse value Is DBNull.Value Then Return
        If TypeOf value Is Date Then
            cell.Value = DirectCast(value, Date)
        ElseIf TypeOf value Is Decimal Then
            cell.Value = DirectCast(value, Decimal)
        ElseIf TypeOf value Is Double Then
            cell.Value = DirectCast(value, Double)
        ElseIf TypeOf value Is Integer Then
            cell.Value = DirectCast(value, Integer)
        ElseIf TypeOf value Is Long Then
            cell.Value = DirectCast(value, Long)
        ElseIf TypeOf value Is Boolean Then
            cell.Value = DirectCast(value, Boolean)
        Else
            cell.Value = Convert.ToString(value, CultureInfo.CurrentCulture)
        End If
    End Sub

    Private Function FormatCutoff(cutoff As String) As String
        Dim parts = cutoff.Split("_"c)
        If parts.Length <> 3 Then Return cutoff
        Dim monthNumber As Integer
        Dim yearNumber As Integer
        If Not Integer.TryParse(parts(0), monthNumber) OrElse Not Integer.TryParse(parts(2), yearNumber) Then Return cutoff
        If monthNumber < 1 OrElse monthNumber > 12 Then Return cutoff
        Return New Date(yearNumber, monthNumber, 1).ToString("MMMM yyyy", CultureInfo.InvariantCulture) & " - " & parts(1).ToUpperInvariant() & " CUTOFF"
    End Function

    Private Function NormalizeRecordStatus(status As String) As String
        If String.IsNullOrWhiteSpace(status) Then Return ManualPayrollRecordService.StatusLegacyFinal
        Return status.Trim().ToUpperInvariant()
    End Function

    Private Function CreateOpenConnection() As OleDbConnection
        If String.IsNullOrWhiteSpace(GlobalVariables.GlobalConStr) Then MDB_Connection_Init()
        If String.IsNullOrWhiteSpace(GlobalVariables.GlobalConStr) Then Throw New InvalidOperationException("The database connection has not been initialized.")
        Dim connection As New OleDbConnection(GlobalVariables.GlobalConStr)
        connection.Open()
        Return connection
    End Function

    Private Function SafeText(reader As OleDbDataReader, columnName As String) As String
        Dim ordinal = reader.GetOrdinal(columnName)
        If reader.IsDBNull(ordinal) Then Return String.Empty
        Return Convert.ToString(reader.GetValue(ordinal)).Trim()
    End Function

    Private Function SafeInteger(reader As OleDbDataReader, columnName As String) As Integer
        Dim value As Integer
        Integer.TryParse(SafeText(reader, columnName), value)
        Return value
    End Function

    Private Function SafeDecimal(reader As OleDbDataReader, columnName As String) As Decimal
        Dim value As Decimal
        Decimal.TryParse(SafeText(reader, columnName), NumberStyles.Any, CultureInfo.InvariantCulture, value)
        Return value
    End Function

    Private Function RowText(row As DataRow, columnName As String) As String
        If Not row.Table.Columns.Contains(columnName) OrElse row.IsNull(columnName) Then Return String.Empty
        Return Convert.ToString(row(columnName)).Trim()
    End Function

    Private Function RowInteger(row As DataRow, columnName As String) As Integer
        Dim value As Integer
        Integer.TryParse(RowText(row, columnName), value)
        Return value
    End Function

    Private Function RowDecimal(row As DataRow, columnName As String) As Decimal
        Dim value As Decimal
        Decimal.TryParse(RowText(row, columnName), NumberStyles.Any, CultureInfo.InvariantCulture, value)
        If value = 0D Then Decimal.TryParse(RowText(row, columnName), NumberStyles.Any, CultureInfo.CurrentCulture, value)
        Return value
    End Function

    Private Function StandaloneClassificationHours(inclusiveHours As Decimal, combinedHours As Decimal) As Decimal
        Return Math.Max(0D, inclusiveHours - combinedHours)
    End Function

    Private Function RowBoolean(row As DataRow, columnName As String) As Boolean
        If Not row.Table.Columns.Contains(columnName) OrElse row.IsNull(columnName) Then Return False
        Try
            Return Convert.ToBoolean(row(columnName), CultureInfo.InvariantCulture)
        Catch
            Return False
        End Try
    End Function

    Private Function RowNullableDate(row As DataRow, columnName As String) As Nullable(Of Date)
        If Not row.Table.Columns.Contains(columnName) OrElse row.IsNull(columnName) Then Return Nothing
        Return CDate(row(columnName))
    End Function
End Module
