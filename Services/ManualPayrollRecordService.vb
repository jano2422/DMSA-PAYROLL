Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization

Public Class ManualPayrollDayRecord
    Public Property ReportDate As Date
    Public Property SelectedShiftNames As New List(Of String)()
    Public Property ShiftAssignments As New List(Of ManualPayrollShiftAssignment)()
    Public Property Classification As String = String.Empty
    Public Property HourAdjustment As Decimal
    Public Property TotalHours As Decimal
End Class

Public Class ManualPayrollShiftAssignment
    Public Property ReportDate As Date
    Public Property ShiftName As String = String.Empty
    Public Property SubClientId As Integer
    Public Property SubClientNameSnapshot As String = String.Empty
    Public Property DailyWageSnapshot As Decimal
    Public Property HoursPerDaySnapshot As Decimal
    Public Property RegularHours As Decimal
    Public Property NightHours As Decimal
    Public Property OvertimeHours As Decimal
    Public Property TotalHours As Decimal
    Public Property BasePayCode As String = String.Empty
    Public Property NightPayCode As String = String.Empty
    Public Property OvertimePayCode As String = String.Empty
    Public Property RegularEarnings As Decimal
    Public Property NightEarnings As Decimal
    Public Property OvertimeEarnings As Decimal
    Public Property IncentiveEarnings As Decimal
    Public Property PayPolicySnapshot As String = String.Empty
End Class

Public Class ManualPayrollClientAdjustment
    Public Property SubClientId As Integer
    Public Property OfficerAllowance As Decimal
    Public Property UniformAllowance As Decimal
    Public Property OtherEarnings As Decimal
    Public Property CashBondDeduction As Decimal
    Public Property SssLoanDeduction As Decimal
    Public Property SssCalLoanDeduction As Decimal
    Public Property PagIbigLoanDeduction As Decimal
    Public Property PagIbigCalLoanDeduction As Decimal
    Public Property PhilHealthDeduction As Decimal
    Public Property SssDeduction As Decimal
    Public Property SssProvidentDeduction As Decimal
    Public Property PagIbigDeduction As Decimal
    Public Property OtherDeductions As Decimal
End Class

Public Class ManualPayrollRecord
    Public Property RecordId As Integer
    Public Property ParentRecordId As Integer
    Public Property RevisionNo As Integer
    Public Property EmployeeId As String
    Public Property SubClientId As Integer
    Public Property CutoffPeriod As String
    Public Property RecordStatus As String
    Public Property ChangeRemarks As String
    Public Property SavedAt As Nullable(Of Date)
    Public Property SavedBy As String
    Public Property SubmittedAt As Nullable(Of Date)
    Public Property SubmittedBy As String

    Public Property EmployeeNameSnapshot As String
    Public Property MainClientNameSnapshot As String
    Public Property SubClientNameSnapshot As String
    Public Property ClientAddressSnapshot As String

    Public Property NumberOfDays As Decimal
    Public Property TotalHours As Decimal
    Public Property RegularHours As Decimal
    Public Property SundayHours As Decimal
    Public Property SpecialHolidayHours As Decimal
    Public Property LegalHolidayHours As Decimal
    Public Property NightDifferentialDays As Decimal
    Public Property NightDifferentialRegularHours As Decimal
    Public Property NightDifferentialSundayHours As Decimal
    Public Property NightDifferentialSpecialHolidayHours As Decimal
    Public Property NightDifferentialLegalHolidayHours As Decimal
    Public Property OvertimeRegularHours As Decimal
    Public Property OvertimeSundayHours As Decimal
    Public Property OvertimeSpecialHolidayHours As Decimal
    Public Property OvertimeLegalHolidayHours As Decimal
    Public Property SundaySpecialHolidayHours As Decimal
    Public Property SundayLegalHolidayHours As Decimal
    Public Property NightDifferentialSundaySpecialHolidayHours As Decimal
    Public Property NightDifferentialSundayLegalHolidayHours As Decimal
    Public Property OvertimeSundaySpecialHolidayHours As Decimal
    Public Property OvertimeSundayLegalHolidayHours As Decimal

    Public Property CashBondDeduction As Decimal
    Public Property SssLoanDeduction As Decimal
    Public Property SssCalLoanDeduction As Decimal
    Public Property PagIbigLoanDeduction As Decimal
    Public Property PagIbigCalLoanDeduction As Decimal
    Public Property PhilHealthDeduction As Decimal
    Public Property SssDeduction As Decimal
    Public Property SssProvidentDeduction As Decimal
    Public Property PagIbigDeduction As Decimal
    Public Property OfficerAllowance As Decimal
    Public Property UniformAllowance As Decimal
    Public Property OtherEarnings As Decimal
    Public Property OtherDeductions As Decimal

    Public Property DailyWageSnapshot As Decimal
    Public Property HoursPerDaySnapshot As Decimal
    Public Property RegularEarnings As Decimal
    Public Property SundayEarnings As Decimal
    Public Property SpecialHolidayEarnings As Decimal
    Public Property LegalHolidayEarnings As Decimal
    Public Property NightDifferentialRegularEarnings As Decimal
    Public Property NightDifferentialSundayEarnings As Decimal
    Public Property NightDifferentialSpecialHolidayEarnings As Decimal
    Public Property NightDifferentialLegalHolidayEarnings As Decimal
    Public Property OvertimeRegularEarnings As Decimal
    Public Property OvertimeSundayEarnings As Decimal
    Public Property OvertimeSpecialHolidayEarnings As Decimal
    Public Property OvertimeLegalHolidayEarnings As Decimal
    Public Property IncentivePay As Decimal
    Public Property TotalEarnings As Decimal
    Public Property TotalDeductions As Decimal
    Public Property NetPay As Decimal
    Public Property CalculationVersion As String
    Public Property PayPolicySnapshot As String
    Public Property SnapshotComplete As Boolean

    Public Property Days As New List(Of ManualPayrollDayRecord)()
    Public Property ClientAdjustments As New List(Of ManualPayrollClientAdjustment)()
End Class

Public Class ManualPayrollRecordStatus
    Public Property Exists As Boolean
    Public Property RecordStatus As String
    Public Property RevisionNo As Integer
    Public Property ParentRecordId As Integer
    Public Property SavedAt As Nullable(Of Date)
    Public Property SavedBy As String
    Public Property SubmittedAt As Nullable(Of Date)
    Public Property SubmittedBy As String
End Class

Public Module ManualPayrollRecordService
    Public Const CurrentCalculationVersion As String = "PAYROLL_V5_CLIENT_ALLOCATION"
    Public Const StatusNotStarted As String = "NOT_STARTED"
    Public Const StatusDraft As String = "DRAFT"
    Public Const StatusAmendmentDraft As String = "AMENDMENT_DRAFT"
    Public Const StatusFinal As String = "FINAL"
    Public Const StatusLegacyFinal As String = "LEGACY_FINAL"

    Private Const DetailTable As String = "PRL_DTR_SHIFT_DAY"
    Private Const AssignmentTable As String = "PRL_DTR_SHIFT_ASSIGNMENT"
    Private Const ClientAdjustmentTable As String = "PRL_DTR_CLIENT_ADJUSTMENT"
    Private Const AuditTable As String = "PRL_DTR_RECORD_AUDIT"
    Private ReadOnly SchemaLock As New Object()
    Private schemaReady As Boolean

    Public Sub EnsureSchema()
        If schemaReady Then Return

        SyncLock SchemaLock
            If schemaReady Then Return
            SubClientPayrollPolicyService.EnsureSchema()
            Using connection = CreateOpenConnection()
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "RECORD_STATUS", "TEXT(20)")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SAVED_AT", "DATETIME")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SAVED_BY", "TEXT(100)")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SUBMITTED_AT", "DATETIME")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SUBMITTED_BY", "TEXT(100)")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "PARENT_RECORD_ID", "LONG")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "REVISION_NO", "LONG")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "CHANGE_REMARKS", "MEMO")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SSS_PROVIDENT_DEDUCT", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "EMPLOYEE_NAME_SNAPSHOT", "TEXT(200)")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "MAIN_CLIENT_NAME_SNAPSHOT", "TEXT(200)")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SUB_CLIENT_NAME_SNAPSHOT", "TEXT(200)")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "CLIENT_ADDRESS_SNAPSHOT", "MEMO")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "DAILY_WAGE_SNAPSHOT", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "HOURS_PER_DAY_SNAPSHOT", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "REG_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SUN_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SH_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "LH_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "ND_REG_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "ND_SUN_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "ND_SH_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "ND_LH_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_REG_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_SUN_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_SH_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_LH_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "INCENTIVE_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OTHER_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OTHER_DEDUCTIONS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "TOTAL_EARNINGS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "TOTAL_DEDUCTIONS", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "NET_PAY", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "CALCULATION_VERSION", "TEXT(30)")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "PAY_POLICY_SNAPSHOT", "MEMO")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "SNAPSHOT_COMPLETE", "YESNO")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "RD_SUN_SH", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "RD_SUN_LH", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "ND_RD_SUN_SH", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "ND_RD_SUN_LH", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_RD_SUN_SH", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_RD_SUN_LH", "DOUBLE")

                If Not TableExists(connection, DetailTable) Then
                    ExecuteDdl(connection,
                        "CREATE TABLE [" & DetailTable & "] (" &
                        "[ID] AUTOINCREMENT CONSTRAINT [PK_PRL_DTR_SHIFT_DAY] PRIMARY KEY, " &
                        "[PAYROLL_RECORD_ID] LONG NOT NULL, " &
                        "[EMPLOYEE_ID] TEXT(50) NOT NULL, [SUB_CLIENT_ID] LONG NOT NULL, " &
                        "[CUTOFF_PERIOD] TEXT(30) NOT NULL, [REPORT_DATE] DATETIME NOT NULL, " &
                        "[SHIFT_NAMES] MEMO, [DAY_CLASSIFICATION] TEXT(10), [HOUR_ADJUSTMENT] DOUBLE, [DAILY_TOTAL_HOURS] DOUBLE)")
                End If
                EnsureColumn(connection, DetailTable, "PAYROLL_RECORD_ID", "LONG")
                EnsureColumn(connection, DetailTable, "HOUR_ADJUSTMENT", "DOUBLE")

                If Not TableExists(connection, AssignmentTable) Then
                    ExecuteDdl(connection,
                        "CREATE TABLE [" & AssignmentTable & "] (" &
                        "[ID] AUTOINCREMENT CONSTRAINT [PK_PRL_DTR_SHIFT_ASSIGNMENT] PRIMARY KEY, " &
                        "[PAYROLL_RECORD_ID] LONG NOT NULL, [REPORT_DATE] DATETIME NOT NULL, [SHIFT_NAME] TEXT(100) NOT NULL, " &
                        "[SUB_CLIENT_ID] LONG NOT NULL, [SUB_CLIENT_NAME_SNAPSHOT] TEXT(200), " &
                        "[DAILY_WAGE_SNAPSHOT] DOUBLE, [HOURS_PER_DAY_SNAPSHOT] DOUBLE, " &
                        "[REGULAR_HOURS] DOUBLE, [NIGHT_HOURS] DOUBLE, [OVERTIME_HOURS] DOUBLE, [TOTAL_HOURS] DOUBLE, " &
                        "[BASE_PAY_CODE] TEXT(20), [NIGHT_PAY_CODE] TEXT(20), [OVERTIME_PAY_CODE] TEXT(20), " &
                        "[REGULAR_EARNINGS] DOUBLE, [NIGHT_EARNINGS] DOUBLE, [OVERTIME_EARNINGS] DOUBLE, [INCENTIVE_EARNINGS] DOUBLE, " &
                        "[PAY_POLICY_SNAPSHOT] MEMO)")
                End If
                EnsureColumn(connection, AssignmentTable, "BASE_PAY_CODE", "TEXT(20)")
                EnsureColumn(connection, AssignmentTable, "NIGHT_PAY_CODE", "TEXT(20)")
                EnsureColumn(connection, AssignmentTable, "OVERTIME_PAY_CODE", "TEXT(20)")
                EnsureColumn(connection, AssignmentTable, "REGULAR_EARNINGS", "DOUBLE")
                EnsureColumn(connection, AssignmentTable, "NIGHT_EARNINGS", "DOUBLE")
                EnsureColumn(connection, AssignmentTable, "OVERTIME_EARNINGS", "DOUBLE")
                EnsureColumn(connection, AssignmentTable, "INCENTIVE_EARNINGS", "DOUBLE")

                If Not TableExists(connection, AuditTable) Then
                    ExecuteDdl(connection,
                        "CREATE TABLE [" & AuditTable & "] (" &
                        "[ID] AUTOINCREMENT CONSTRAINT [PK_PRL_DTR_RECORD_AUDIT] PRIMARY KEY, " &
                        "[PAYROLL_RECORD_ID] LONG NOT NULL, [EMPLOYEE_ID] TEXT(50) NOT NULL, " &
                        "[SUB_CLIENT_ID] LONG NOT NULL, [CUTOFF_PERIOD] TEXT(30) NOT NULL, " &
                        "[REVISION_NO] LONG NOT NULL, [ACTION_TYPE] TEXT(30) NOT NULL, " &
                        "[REMARKS] MEMO, [ACTION_AT] DATETIME NOT NULL, [ACTION_BY] TEXT(100) NOT NULL)")
                End If

                If Not TableExists(connection, ClientAdjustmentTable) Then
                    ExecuteDdl(connection,
                        "CREATE TABLE [" & ClientAdjustmentTable & "] (" &
                        "[ID] AUTOINCREMENT CONSTRAINT [PK_PRL_DTR_CLIENT_ADJUSTMENT] PRIMARY KEY, " &
                        "[PAYROLL_RECORD_ID] LONG NOT NULL, [SUB_CLIENT_ID] LONG NOT NULL, " &
                        "[OFFICERS_ALLOWANCE] DOUBLE, [SGUNIFORMALLOWANCE] DOUBLE, [OTHER_EARNINGS] DOUBLE, " &
                        "[CB_DEDUCT] DOUBLE, [SSS_LOAN_DEDUCT] DOUBLE, [SSS_CAL_LOAN_DEDUCT] DOUBLE, " &
                        "[PI_LOAN_DEDUCT] DOUBLE, [PI_CAL_LOAN_DEDUCT] DOUBLE, [PH_DEDUCT] DOUBLE, " &
                        "[SSS_DEDUCT] DOUBLE, [SSS_PROVIDENT_DEDUCT] DOUBLE, [PI_DEDUCT] DOUBLE, [OTHER_DEDUCTIONS] DOUBLE)")
                End If

                EnsureIndex(connection, "PRL_DTR_TOTAL_HOURS", "IX_DTR_TOTAL_CUTOFF", "[EMPLOYEE_ID], [SUB_CLIENT_ID], [CUTOFF_PERIOD]")
                EnsureIndex(connection, DetailTable, "IX_DTR_SHIFT_RECORD", "[PAYROLL_RECORD_ID]")
                EnsureIndex(connection, AssignmentTable, "IX_DTR_ASSIGNMENT_RECORD", "[PAYROLL_RECORD_ID]")
                EnsureIndex(connection, ClientAdjustmentTable, "IX_DTR_CLIENT_ADJUSTMENT_RECORD", "[PAYROLL_RECORD_ID], [SUB_CLIENT_ID]")
                EnsureIndex(connection, AuditTable, "IX_DTR_AUDIT_RECORD", "[PAYROLL_RECORD_ID]")
            End Using
            schemaReady = True
        End SyncLock
    End Sub

    Public Function LoadFinalClientAllocations(subClientId As Integer, cutoff As String) As DataTable
        Dim result = CreateClientAllocationTable()
        If subClientId <= 0 OrElse String.IsNullOrWhiteSpace(cutoff) Then Return result
        EnsureSchema()

        Const sql As String =
            "SELECT P.[ID] AS [PAYROLL_RECORD_ID], P.[EMPLOYEE_ID], P.[SUB_CLIENT_ID] AS [HOME_SUB_CLIENT_ID], " &
            "P.[EMPLOYEE_NAME_SNAPSHOT], P.[CB_DEDUCT], P.[SSS_LOAN_DEDUCT], P.[SSS_CAL_LOAN_DEDUCT], " &
            "P.[PI_LOAN_DEDUCT], P.[PI_CAL_LOAN_DEDUCT], P.[SSS_DEDUCT], P.[SSS_PROVIDENT_DEDUCT], " &
            "P.[PH_DEDUCT], P.[PI_DEDUCT], P.[OFFICERS_ALLOWANCE], P.[SGUNIFORMALLOWANCE], " &
            "P.[OTHER_EARNINGS], P.[OTHER_DEDUCTIONS], P.[CALCULATION_VERSION], " &
            "A.[REPORT_DATE], A.[DAILY_WAGE_SNAPSHOT], A.[HOURS_PER_DAY_SNAPSHOT], " &
            "A.[REGULAR_HOURS], A.[NIGHT_HOURS], A.[OVERTIME_HOURS], A.[TOTAL_HOURS], " &
            "A.[BASE_PAY_CODE], A.[NIGHT_PAY_CODE], A.[OVERTIME_PAY_CODE], " &
            "A.[REGULAR_EARNINGS], A.[NIGHT_EARNINGS], A.[OVERTIME_EARNINGS], A.[INCENTIVE_EARNINGS] " &
            "FROM [PRL_DTR_TOTAL_HOURS] AS P INNER JOIN [PRL_DTR_SHIFT_ASSIGNMENT] AS A " &
            "ON P.[ID] = A.[PAYROLL_RECORD_ID] " &
            "WHERE A.[SUB_CLIENT_ID] = ? AND P.[CUTOFF_PERIOD] = ? AND P.[RECORD_STATUS] = ? " &
            "AND P.[CALCULATION_VERSION] = ? " &
            "ORDER BY P.[EMPLOYEE_ID], P.[ID] DESC, A.[REPORT_DATE], A.[ID]"

        Dim source As New DataTable()
        Using connection = CreateOpenConnection()
            Using command As New OleDbCommand(sql, connection)
                AddInteger(command, subClientId)
                AddText(command, cutoff, 30)
                AddText(command, StatusFinal, 20)
                AddText(command, CurrentCalculationVersion, 30)
                Using adapter As New OleDbDataAdapter(command)
                    adapter.Fill(source)
                End Using
            End Using
        End Using

        Dim latestRows As New List(Of DataRow)()
        For Each recordGroup In source.AsEnumerable().GroupBy(
            Function(row) Convert.ToString(row("EMPLOYEE_ID")) & "|" & Convert.ToString(row("HOME_SUB_CLIENT_ID")))
            Dim latestRecordId = recordGroup.Max(Function(row) Convert.ToInt32(row("PAYROLL_RECORD_ID"), CultureInfo.InvariantCulture))
            latestRows.AddRange(recordGroup.Where(
                Function(row) Convert.ToInt32(row("PAYROLL_RECORD_ID"), CultureInfo.InvariantCulture) = latestRecordId))
        Next

        Dim adjustmentRows As New DataTable()
        Using connection = CreateOpenConnection()
            Using command As New OleDbCommand(
                "SELECT * FROM [" & ClientAdjustmentTable & "] WHERE [SUB_CLIENT_ID] = ?", connection)
                AddInteger(command, subClientId)
                Using adapter As New OleDbDataAdapter(command)
                    adapter.Fill(adjustmentRows)
                End Using
            End Using
        End Using
        Dim adjustmentLookup = adjustmentRows.AsEnumerable().GroupBy(
            Function(row) Convert.ToInt32(row("PAYROLL_RECORD_ID"), CultureInfo.InvariantCulture)).
            ToDictionary(Function(group) group.Key, Function(group) group.Last())

        For Each employeeGroup In latestRows.GroupBy(Function(row) Convert.ToString(row("EMPLOYEE_ID")))
            Dim first = employeeGroup.First()
            Dim output = result.NewRow()
            Dim employeeName = SafeRowText(first, "EMPLOYEE_NAME_SNAPSHOT")
            output("EMPLOYEE_ID") = employeeGroup.Key
            output("LAST_NAME") = employeeName
            output("FIRST_NAME") = String.Empty
            output("MIDDLE_NAME") = String.Empty
            output("SNAPSHOT_COMPLETE") = True
            output("CALCULATION_VERSION") = CurrentCalculationVersion
            output("DAILY_WAGE_SNAPSHOT") = SafeRowDecimal(first, "DAILY_WAGE_SNAPSHOT")

            For Each assignment In employeeGroup
                AddRowDecimal(output, "NUM_OF_DAYS", 1D)
                AddRowDecimal(output, "TOTAL_HOURS", SafeRowDecimal(assignment, "TOTAL_HOURS"))
                Dim hoursPerDay = SafeRowDecimal(assignment, "HOURS_PER_DAY_SNAPSHOT")
                If hoursPerDay <= 0D Then hoursPerDay = 8D
                AddRowDecimal(output, "ND_DAYS", SafeRowDecimal(assignment, "NIGHT_HOURS") / hoursPerDay)
                AddAllocationHours(output, SafeRowText(assignment, "BASE_PAY_CODE"), SafeRowDecimal(assignment, "REGULAR_HOURS"))
                AddAllocationHours(output, SafeRowText(assignment, "NIGHT_PAY_CODE"), SafeRowDecimal(assignment, "NIGHT_HOURS"))
                AddAllocationHours(output, SafeRowText(assignment, "OVERTIME_PAY_CODE"), SafeRowDecimal(assignment, "OVERTIME_HOURS"))
                AddAllocationEarnings(output, SafeRowText(assignment, "BASE_PAY_CODE"), SafeRowDecimal(assignment, "REGULAR_EARNINGS"))
                AddAllocationEarnings(output, SafeRowText(assignment, "NIGHT_PAY_CODE"), SafeRowDecimal(assignment, "NIGHT_EARNINGS"))
                AddAllocationEarnings(output, SafeRowText(assignment, "OVERTIME_PAY_CODE"), SafeRowDecimal(assignment, "OVERTIME_EARNINGS"))
                AddRowDecimal(output, "INCENTIVE_EARNINGS", SafeRowDecimal(assignment, "INCENTIVE_EARNINGS"))
            Next

            Dim recordId = Convert.ToInt32(first("PAYROLL_RECORD_ID"), CultureInfo.InvariantCulture)
            Dim clientAdjustment As DataRow = Nothing
            If adjustmentLookup.TryGetValue(recordId, clientAdjustment) Then
                For Each name In {"CB_DEDUCT", "SSS_LOAN_DEDUCT", "SSS_CAL_LOAN_DEDUCT", "PI_LOAN_DEDUCT", "PI_CAL_LOAN_DEDUCT",
                                  "SSS_DEDUCT", "SSS_PROVIDENT_DEDUCT", "PH_DEDUCT", "PI_DEDUCT", "OFFICERS_ALLOWANCE",
                                  "SGUNIFORMALLOWANCE", "OTHER_EARNINGS", "OTHER_DEDUCTIONS"}
                    output(name) = SafeRowDecimal(clientAdjustment, name)
                Next
            ElseIf CInt(SafeRowDecimal(first, "HOME_SUB_CLIENT_ID")) = subClientId Then
                ' Compatibility for records finalized before client-specific
                ' allowances and deductions were introduced.
                For Each name In {"CB_DEDUCT", "SSS_LOAN_DEDUCT", "SSS_CAL_LOAN_DEDUCT", "PI_LOAN_DEDUCT", "PI_CAL_LOAN_DEDUCT",
                                  "SSS_DEDUCT", "SSS_PROVIDENT_DEDUCT", "PH_DEDUCT", "PI_DEDUCT", "OFFICERS_ALLOWANCE",
                                  "SGUNIFORMALLOWANCE", "OTHER_EARNINGS", "OTHER_DEDUCTIONS"}
                    output(name) = SafeRowDecimal(first, name)
                Next
            End If

            Dim workEarnings = ClientAllocationEarningColumns().Sum(Function(name) Convert.ToDecimal(output(name), CultureInfo.InvariantCulture))
            Dim allowanceTotal = Convert.ToDecimal(output("OFFICERS_ALLOWANCE"), CultureInfo.InvariantCulture) +
                Convert.ToDecimal(output("SGUNIFORMALLOWANCE"), CultureInfo.InvariantCulture) +
                Convert.ToDecimal(output("OTHER_EARNINGS"), CultureInfo.InvariantCulture)
            Dim deductionTotal = ClientAllocationDeductionColumns().Sum(Function(name) Convert.ToDecimal(output(name), CultureInfo.InvariantCulture))
            output("TOTAL_EARNINGS") = workEarnings + allowanceTotal
            output("TOTAL_DEDUCTIONS") = deductionTotal
            output("NET_PAY") = workEarnings + allowanceTotal - deductionTotal
            result.Rows.Add(output)
        Next
        Return result
    End Function

    Private Function CreateClientAllocationTable() As DataTable
        Dim result As New DataTable("FINAL_CLIENT_ALLOCATIONS")
        For Each name In {"EMPLOYEE_ID", "LAST_NAME", "FIRST_NAME", "MIDDLE_NAME", "CALCULATION_VERSION"}
            result.Columns.Add(name, GetType(String))
        Next
        For Each name In {"NUM_OF_DAYS", "ND_DAYS", "TOTAL_HOURS", "REG", "SUN", "SH", "LH", "RD_SUN_SH", "RD_SUN_LH",
                          "ND_REG", "ND_SUN", "ND_SH", "ND_LH", "ND_RD_SUN_SH", "ND_RD_SUN_LH",
                          "OT_REG", "OT_SUN", "OT_SH", "OT_LH", "OT_RD_SUN_SH", "OT_RD_SUN_LH",
                          "CB_DEDUCT", "SSS_LOAN_DEDUCT", "SSS_CAL_LOAN_DEDUCT", "PI_LOAN_DEDUCT", "PI_CAL_LOAN_DEDUCT",
                          "SSS_DEDUCT", "SSS_PROVIDENT_DEDUCT", "PH_DEDUCT", "PI_DEDUCT", "OFFICERS_ALLOWANCE",
                          "SGUNIFORMALLOWANCE", "OTHER_EARNINGS", "OTHER_DEDUCTIONS", "DAILY_WAGE_SNAPSHOT",
                          "REG_EARNINGS", "SUN_EARNINGS", "LH_EARNINGS", "SH_EARNINGS", "ND_REG_EARNINGS",
                          "ND_SUN_EARNINGS", "ND_LH_EARNINGS", "ND_SH_EARNINGS", "OT_REG_EARNINGS", "OT_SUN_EARNINGS",
                          "OT_LH_EARNINGS", "OT_SH_EARNINGS", "INCENTIVE_EARNINGS", "TOTAL_EARNINGS", "TOTAL_DEDUCTIONS", "NET_PAY"}
            result.Columns.Add(name, GetType(Decimal)).DefaultValue = 0D
        Next
        result.Columns.Add("SNAPSHOT_COMPLETE", GetType(Boolean)).DefaultValue = False
        Return result
    End Function

    Private Sub AddAllocationHours(row As DataRow, payCode As String, value As Decimal)
        Dim code = If(payCode, String.Empty).Trim().ToUpperInvariant()
        If value = 0D OrElse code = String.Empty Then Return
        Select Case code
            Case "RD_SH"
                AddRowDecimal(row, "SH", value)
                AddRowDecimal(row, "RD_SUN_SH", value)
            Case "RD_LH"
                AddRowDecimal(row, "LH", value)
                AddRowDecimal(row, "RD_SUN_LH", value)
            Case "ND_RD_SH"
                AddRowDecimal(row, "ND_SH", value)
                AddRowDecimal(row, "ND_RD_SUN_SH", value)
            Case "ND_RD_LH"
                AddRowDecimal(row, "ND_LH", value)
                AddRowDecimal(row, "ND_RD_SUN_LH", value)
            Case "OT_RD_SH"
                AddRowDecimal(row, "OT_SH", value)
                AddRowDecimal(row, "OT_RD_SUN_SH", value)
            Case "OT_RD_LH"
                AddRowDecimal(row, "OT_LH", value)
                AddRowDecimal(row, "OT_RD_SUN_LH", value)
            Case Else
                If row.Table.Columns.Contains(code) Then AddRowDecimal(row, code, value)
        End Select
    End Sub

    Private Sub AddAllocationEarnings(row As DataRow, payCode As String, value As Decimal)
        Dim code = If(payCode, String.Empty).Trim().ToUpperInvariant()
        If value = 0D OrElse code = String.Empty Then Return
        Select Case code
            Case "RD_SH" : code = "SH"
            Case "RD_LH" : code = "LH"
            Case "ND_RD_SH" : code = "ND_SH"
            Case "ND_RD_LH" : code = "ND_LH"
            Case "OT_RD_SH" : code = "OT_SH"
            Case "OT_RD_LH" : code = "OT_LH"
        End Select
        Dim columnName = code & "_EARNINGS"
        If row.Table.Columns.Contains(columnName) Then AddRowDecimal(row, columnName, value)
    End Sub

    Private Sub AddRowDecimal(row As DataRow, columnName As String, value As Decimal)
        row(columnName) = Convert.ToDecimal(row(columnName), CultureInfo.InvariantCulture) + value
    End Sub

    Private Function SafeRowText(row As DataRow, columnName As String) As String
        If row Is Nothing OrElse Not row.Table.Columns.Contains(columnName) OrElse row.IsNull(columnName) Then Return String.Empty
        Return Convert.ToString(row(columnName), CultureInfo.CurrentCulture).Trim()
    End Function

    Private Function SafeRowDecimal(row As DataRow, columnName As String) As Decimal
        Dim value As Decimal
        Decimal.TryParse(SafeRowText(row, columnName), NumberStyles.Any, CultureInfo.InvariantCulture, value)
        If value = 0D Then Decimal.TryParse(SafeRowText(row, columnName), NumberStyles.Any, CultureInfo.CurrentCulture, value)
        Return value
    End Function

    Private Function ClientAllocationEarningColumns() As String()
        Return {"REG_EARNINGS", "SUN_EARNINGS", "LH_EARNINGS", "SH_EARNINGS", "ND_REG_EARNINGS", "ND_SUN_EARNINGS",
                "ND_LH_EARNINGS", "ND_SH_EARNINGS", "OT_REG_EARNINGS", "OT_SUN_EARNINGS", "OT_LH_EARNINGS",
                "OT_SH_EARNINGS", "INCENTIVE_EARNINGS"}
    End Function

    Private Function ClientAllocationDeductionColumns() As String()
        Return {"CB_DEDUCT", "SSS_LOAN_DEDUCT", "SSS_CAL_LOAN_DEDUCT", "PI_LOAN_DEDUCT", "PI_CAL_LOAN_DEDUCT",
                "SSS_DEDUCT", "SSS_PROVIDENT_DEDUCT", "PH_DEDUCT", "PI_DEDUCT", "OTHER_DEDUCTIONS"}
    End Function

    Public Function LoadLatest(employeeId As String, subClientId As Integer, cutoff As String) As ManualPayrollRecord
        If String.IsNullOrWhiteSpace(employeeId) OrElse subClientId <= 0 OrElse String.IsNullOrWhiteSpace(cutoff) Then Return Nothing
        EnsureSchema()

        Using connection = CreateOpenConnection()
            Dim record As ManualPayrollRecord = Nothing
            Const sql As String = "SELECT TOP 1 * FROM [PRL_DTR_TOTAL_HOURS] " &
                "WHERE [EMPLOYEE_ID] = ? AND [SUB_CLIENT_ID] = ? AND [CUTOFF_PERIOD] = ? ORDER BY [ID] DESC"
            Using command As New OleDbCommand(sql, connection)
                AddText(command, employeeId, 50)
                AddInteger(command, subClientId)
                AddText(command, cutoff, 30)
                Using reader = command.ExecuteReader()
                    If reader.Read() Then record = ReadRecord(reader)
                End Using
            End Using

            If record Is Nothing Then Return Nothing
            record.Days = LoadDays(connection, record.RecordId, employeeId, subClientId, cutoff)
            LoadShiftAssignments(connection, record)
            LoadClientAdjustments(connection, record)
            If (record.RecordStatus = StatusDraft OrElse record.RecordStatus = StatusAmendmentDraft) AndAlso record.Days.Count = 0 Then
                record.RecordStatus = StatusLegacyFinal
            End If
            Return record
        End Using
    End Function

    Public Function LoadStatus(employeeId As String, subClientId As Integer, cutoff As String) As ManualPayrollRecordStatus
        Dim result As New ManualPayrollRecordStatus With {
            .Exists = False,
            .RecordStatus = StatusNotStarted
        }
        If String.IsNullOrWhiteSpace(employeeId) OrElse subClientId <= 0 OrElse String.IsNullOrWhiteSpace(cutoff) Then Return result
        EnsureSchema()

        Using connection = CreateOpenConnection()
            Const sql As String = "SELECT TOP 1 [RECORD_STATUS], [REVISION_NO], [PARENT_RECORD_ID], " &
                "[SAVED_AT], [SAVED_BY], [SUBMITTED_AT], [SUBMITTED_BY] " &
                "FROM [PRL_DTR_TOTAL_HOURS] WHERE [EMPLOYEE_ID] = ? AND [SUB_CLIENT_ID] = ? AND [CUTOFF_PERIOD] = ? ORDER BY [ID] DESC"
            Using command As New OleDbCommand(sql, connection)
                AddText(command, employeeId, 50)
                AddInteger(command, subClientId)
                AddText(command, cutoff, 30)
                Using reader = command.ExecuteReader()
                    If Not reader.Read() Then Return result
                    result.Exists = True
                    result.RecordStatus = NormalizeStatus(SafeText(reader, "RECORD_STATUS"))
                    result.RevisionNo = CInt(SafeDecimal(reader, "REVISION_NO"))
                    result.ParentRecordId = CInt(SafeDecimal(reader, "PARENT_RECORD_ID"))
                    result.SavedAt = SafeNullableDate(reader, "SAVED_AT")
                    result.SavedBy = SafeText(reader, "SAVED_BY")
                    result.SubmittedAt = SafeNullableDate(reader, "SUBMITTED_AT")
                    result.SubmittedBy = SafeText(reader, "SUBMITTED_BY")
                End Using
            End Using
        End Using
        Return result
    End Function

    Public Function Save(record As ManualPayrollRecord, submitFinal As Boolean, actor As String) As ManualPayrollRecord
        If record Is Nothing Then Throw New ArgumentNullException(NameOf(record))
        If String.IsNullOrWhiteSpace(record.EmployeeId) Then Throw New ArgumentException("Employee ID is required.")
        If record.SubClientId <= 0 Then Throw New ArgumentException("Sub-client ID is required.")
        If String.IsNullOrWhiteSpace(record.CutoffPeriod) Then Throw New ArgumentException("Cutoff period is required.")
        If record.Days Is Nothing OrElse record.Days.Count = 0 Then Throw New ArgumentException("Cutoff day details are required.")
        If record.ParentRecordId > 0 AndAlso String.IsNullOrWhiteSpace(record.ChangeRemarks) Then
            Throw New ArgumentException("Remarks are required when saving changes to a finalized payroll.")
        End If

        EnsureSchema()
        actor = If(actor, String.Empty).Trim()
        If actor = String.Empty Then actor = "Unknown user"
        Dim savedAt = Date.Now
        Dim isAmendment = record.ParentRecordId > 0 OrElse record.RecordStatus = StatusAmendmentDraft
        Dim targetStatus = If(submitFinal, StatusFinal, If(isAmendment, StatusAmendmentDraft, StatusDraft))

        Using connection = CreateOpenConnection()
            Using transaction = connection.BeginTransaction()
                Try
                    PopulateContextSnapshots(connection, transaction, record)
                    Dim latestId As Integer = 0
                    Dim latestStatus As String = StatusNotStarted
                    ReadLatestIdentity(connection, transaction, record.EmployeeId, record.SubClientId, record.CutoffPeriod, latestId, latestStatus)

                    If latestStatus = StatusFinal OrElse latestStatus = StatusLegacyFinal Then
                        Throw New InvalidOperationException("This cutoff record is already final and cannot be changed.")
                    End If

                    If latestId > 0 Then
                        UpdateSummary(connection, transaction, latestId, record, targetStatus, savedAt, actor, submitFinal)
                        record.RecordId = latestId
                    Else
                        record.RecordId = InsertSummary(connection, transaction, record, targetStatus, savedAt, actor, submitFinal)
                    End If

                    ReplaceDayDetails(connection, transaction, record)
                    If submitFinal Then ReplaceDailyHours(connection, transaction, record)
                    ReplaceShiftAssignments(connection, transaction, record)
                    ReplaceClientAdjustments(connection, transaction, record)
                    Dim actionType = If(submitFinal,
                        If(isAmendment, "AMENDMENT_SUBMITTED", "FINAL_SUBMITTED"),
                        If(isAmendment, "AMENDMENT_SAVED", "DRAFT_SAVED"))
                    InsertAudit(connection, transaction, record, actionType, record.ChangeRemarks, savedAt, actor)
                    transaction.Commit()
                Catch
                    Try
                        transaction.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using

        record.RecordStatus = targetStatus
        record.SavedAt = savedAt
        record.SavedBy = actor
        If submitFinal Then
            record.SubmittedAt = savedAt
            record.SubmittedBy = actor
        End If
        Return record
    End Function

    Public Function BeginAmendment(finalRecord As ManualPayrollRecord, remarks As String, actor As String) As ManualPayrollRecord
        If finalRecord Is Nothing Then Throw New ArgumentNullException(NameOf(finalRecord))
        remarks = If(remarks, String.Empty).Trim()
        If remarks = String.Empty Then Throw New ArgumentException("Remarks are required before a finalized payroll can be amended.")
        If finalRecord.RecordId <= 0 OrElse finalRecord.RecordStatus <> StatusFinal Then
            Throw New InvalidOperationException("Only a submitted final payroll can be amended.")
        End If
        If finalRecord.Days Is Nothing OrElse finalRecord.Days.Count = 0 Then
            Throw New InvalidOperationException("This finalized payroll has no saved shift details and cannot be amended safely.")
        End If

        EnsureSchema()
        actor = If(actor, String.Empty).Trim()
        If actor = String.Empty Then actor = "Unknown user"
        Dim savedAt = Date.Now
        Dim amendment = CopyRecord(finalRecord)
        amendment.RecordId = 0
        amendment.ParentRecordId = finalRecord.RecordId
        amendment.RevisionNo = Math.Max(0, finalRecord.RevisionNo) + 1
        amendment.RecordStatus = StatusAmendmentDraft
        amendment.ChangeRemarks = remarks
        amendment.SavedAt = savedAt
        amendment.SavedBy = actor
        amendment.SubmittedAt = Nothing
        amendment.SubmittedBy = String.Empty

        Using connection = CreateOpenConnection()
            Using transaction = connection.BeginTransaction()
                Try
                    Dim latestId As Integer = 0
                    Dim latestStatus As String = StatusNotStarted
                    ReadLatestIdentity(connection, transaction, finalRecord.EmployeeId, finalRecord.SubClientId, finalRecord.CutoffPeriod, latestId, latestStatus)
                    If latestId <> finalRecord.RecordId OrElse latestStatus <> StatusFinal Then
                        Throw New InvalidOperationException("The payroll changed after it was opened. Reload the cutoff before starting an amendment.")
                    End If

                    amendment.RecordId = InsertSummary(connection, transaction, amendment, StatusAmendmentDraft, savedAt, actor, False)
                    ReplaceDayDetails(connection, transaction, amendment)
                    ReplaceShiftAssignments(connection, transaction, amendment)
                    ReplaceClientAdjustments(connection, transaction, amendment)
                    InsertAudit(connection, transaction, amendment, "AMENDMENT_STARTED", remarks, savedAt, actor)
                    transaction.Commit()
                Catch
                    Try
                        transaction.Rollback()
                    Catch
                    End Try
                    Throw
                End Try
            End Using
        End Using
        Return amendment
    End Function

    Private Function ReadRecord(reader As OleDbDataReader) As ManualPayrollRecord
        Return New ManualPayrollRecord With {
            .RecordId = CInt(SafeDecimal(reader, "ID")),
            .ParentRecordId = CInt(SafeDecimal(reader, "PARENT_RECORD_ID")),
            .RevisionNo = CInt(SafeDecimal(reader, "REVISION_NO")),
            .EmployeeId = SafeText(reader, "EMPLOYEE_ID"),
            .SubClientId = CInt(SafeDecimal(reader, "SUB_CLIENT_ID")),
            .CutoffPeriod = SafeText(reader, "CUTOFF_PERIOD"),
            .RecordStatus = NormalizeStatus(SafeText(reader, "RECORD_STATUS")),
            .ChangeRemarks = SafeText(reader, "CHANGE_REMARKS"),
            .SavedAt = SafeNullableDate(reader, "SAVED_AT"),
            .SavedBy = SafeText(reader, "SAVED_BY"),
            .SubmittedAt = SafeNullableDate(reader, "SUBMITTED_AT"),
            .SubmittedBy = SafeText(reader, "SUBMITTED_BY"),
            .EmployeeNameSnapshot = SafeText(reader, "EMPLOYEE_NAME_SNAPSHOT"),
            .MainClientNameSnapshot = SafeText(reader, "MAIN_CLIENT_NAME_SNAPSHOT"),
            .SubClientNameSnapshot = SafeText(reader, "SUB_CLIENT_NAME_SNAPSHOT"),
            .ClientAddressSnapshot = SafeText(reader, "CLIENT_ADDRESS_SNAPSHOT"),
            .NumberOfDays = SafeDecimal(reader, "NUM_OF_DAYS"),
            .TotalHours = SafeDecimal(reader, "TOTAL_HOURS"),
            .RegularHours = SafeDecimal(reader, "REG"),
            .SundayHours = SafeDecimal(reader, "SUN"),
            .SpecialHolidayHours = SafeDecimal(reader, "SH"),
            .LegalHolidayHours = SafeDecimal(reader, "LH"),
            .NightDifferentialDays = SafeDecimal(reader, "ND_DAYS"),
            .NightDifferentialRegularHours = SafeDecimal(reader, "ND_REG"),
            .NightDifferentialSundayHours = SafeDecimal(reader, "ND_SUN"),
            .NightDifferentialSpecialHolidayHours = SafeDecimal(reader, "ND_SH"),
            .NightDifferentialLegalHolidayHours = SafeDecimal(reader, "ND_LH"),
            .OvertimeRegularHours = SafeDecimal(reader, "OT_REG"),
            .OvertimeSundayHours = SafeDecimal(reader, "OT_SUN"),
            .OvertimeSpecialHolidayHours = SafeDecimal(reader, "OT_SH"),
            .OvertimeLegalHolidayHours = SafeDecimal(reader, "OT_LH"),
            .SundaySpecialHolidayHours = SafeDecimal(reader, "RD_SUN_SH"),
            .SundayLegalHolidayHours = SafeDecimal(reader, "RD_SUN_LH"),
            .NightDifferentialSundaySpecialHolidayHours = SafeDecimal(reader, "ND_RD_SUN_SH"),
            .NightDifferentialSundayLegalHolidayHours = SafeDecimal(reader, "ND_RD_SUN_LH"),
            .OvertimeSundaySpecialHolidayHours = SafeDecimal(reader, "OT_RD_SUN_SH"),
            .OvertimeSundayLegalHolidayHours = SafeDecimal(reader, "OT_RD_SUN_LH"),
            .CashBondDeduction = SafeDecimal(reader, "CB_DEDUCT"),
            .SssLoanDeduction = SafeDecimal(reader, "SSS_LOAN_DEDUCT"),
            .SssCalLoanDeduction = SafeDecimal(reader, "SSS_CAL_LOAN_DEDUCT"),
            .PagIbigLoanDeduction = SafeDecimal(reader, "PI_LOAN_DEDUCT"),
            .PagIbigCalLoanDeduction = SafeDecimal(reader, "PI_CAL_LOAN_DEDUCT"),
            .PhilHealthDeduction = SafeDecimal(reader, "PH_DEDUCT"),
            .SssDeduction = SafeDecimal(reader, "SSS_DEDUCT"),
            .SssProvidentDeduction = SafeDecimal(reader, "SSS_PROVIDENT_DEDUCT"),
            .PagIbigDeduction = SafeDecimal(reader, "PI_DEDUCT"),
            .OfficerAllowance = SafeDecimal(reader, "OFFICERS_ALLOWANCE"),
            .UniformAllowance = SafeDecimal(reader, "SGUNIFORMALLOWANCE"),
            .OtherEarnings = SafeDecimal(reader, "OTHER_EARNINGS"),
            .OtherDeductions = SafeDecimal(reader, "OTHER_DEDUCTIONS"),
            .DailyWageSnapshot = SafeDecimal(reader, "DAILY_WAGE_SNAPSHOT"),
            .HoursPerDaySnapshot = SafeDecimal(reader, "HOURS_PER_DAY_SNAPSHOT"),
            .RegularEarnings = SafeDecimal(reader, "REG_EARNINGS"),
            .SundayEarnings = SafeDecimal(reader, "SUN_EARNINGS"),
            .SpecialHolidayEarnings = SafeDecimal(reader, "SH_EARNINGS"),
            .LegalHolidayEarnings = SafeDecimal(reader, "LH_EARNINGS"),
            .NightDifferentialRegularEarnings = SafeDecimal(reader, "ND_REG_EARNINGS"),
            .NightDifferentialSundayEarnings = SafeDecimal(reader, "ND_SUN_EARNINGS"),
            .NightDifferentialSpecialHolidayEarnings = SafeDecimal(reader, "ND_SH_EARNINGS"),
            .NightDifferentialLegalHolidayEarnings = SafeDecimal(reader, "ND_LH_EARNINGS"),
            .OvertimeRegularEarnings = SafeDecimal(reader, "OT_REG_EARNINGS"),
            .OvertimeSundayEarnings = SafeDecimal(reader, "OT_SUN_EARNINGS"),
            .OvertimeSpecialHolidayEarnings = SafeDecimal(reader, "OT_SH_EARNINGS"),
            .OvertimeLegalHolidayEarnings = SafeDecimal(reader, "OT_LH_EARNINGS"),
            .IncentivePay = SafeDecimal(reader, "INCENTIVE_EARNINGS"),
            .TotalEarnings = SafeDecimal(reader, "TOTAL_EARNINGS"),
            .TotalDeductions = SafeDecimal(reader, "TOTAL_DEDUCTIONS"),
            .NetPay = SafeDecimal(reader, "NET_PAY"),
            .CalculationVersion = SafeText(reader, "CALCULATION_VERSION"),
            .PayPolicySnapshot = SafeText(reader, "PAY_POLICY_SNAPSHOT"),
            .SnapshotComplete = SafeBoolean(reader, "SNAPSHOT_COMPLETE")
        }
    End Function

    Private Function CopyRecord(source As ManualPayrollRecord) As ManualPayrollRecord
        Dim copy As New ManualPayrollRecord With {
            .ParentRecordId = source.ParentRecordId,
            .RevisionNo = source.RevisionNo,
            .EmployeeId = source.EmployeeId,
            .SubClientId = source.SubClientId,
            .CutoffPeriod = source.CutoffPeriod,
            .RecordStatus = source.RecordStatus,
            .ChangeRemarks = source.ChangeRemarks,
            .EmployeeNameSnapshot = source.EmployeeNameSnapshot,
            .MainClientNameSnapshot = source.MainClientNameSnapshot,
            .SubClientNameSnapshot = source.SubClientNameSnapshot,
            .ClientAddressSnapshot = source.ClientAddressSnapshot,
            .NumberOfDays = source.NumberOfDays,
            .TotalHours = source.TotalHours,
            .RegularHours = source.RegularHours,
            .SundayHours = source.SundayHours,
            .SpecialHolidayHours = source.SpecialHolidayHours,
            .LegalHolidayHours = source.LegalHolidayHours,
            .NightDifferentialDays = source.NightDifferentialDays,
            .NightDifferentialRegularHours = source.NightDifferentialRegularHours,
            .NightDifferentialSundayHours = source.NightDifferentialSundayHours,
            .NightDifferentialSpecialHolidayHours = source.NightDifferentialSpecialHolidayHours,
            .NightDifferentialLegalHolidayHours = source.NightDifferentialLegalHolidayHours,
            .OvertimeRegularHours = source.OvertimeRegularHours,
            .OvertimeSundayHours = source.OvertimeSundayHours,
            .OvertimeSpecialHolidayHours = source.OvertimeSpecialHolidayHours,
            .OvertimeLegalHolidayHours = source.OvertimeLegalHolidayHours,
            .SundaySpecialHolidayHours = source.SundaySpecialHolidayHours,
            .SundayLegalHolidayHours = source.SundayLegalHolidayHours,
            .NightDifferentialSundaySpecialHolidayHours = source.NightDifferentialSundaySpecialHolidayHours,
            .NightDifferentialSundayLegalHolidayHours = source.NightDifferentialSundayLegalHolidayHours,
            .OvertimeSundaySpecialHolidayHours = source.OvertimeSundaySpecialHolidayHours,
            .OvertimeSundayLegalHolidayHours = source.OvertimeSundayLegalHolidayHours,
            .CashBondDeduction = source.CashBondDeduction,
            .SssLoanDeduction = source.SssLoanDeduction,
            .SssCalLoanDeduction = source.SssCalLoanDeduction,
            .PagIbigLoanDeduction = source.PagIbigLoanDeduction,
            .PagIbigCalLoanDeduction = source.PagIbigCalLoanDeduction,
            .PhilHealthDeduction = source.PhilHealthDeduction,
            .SssDeduction = source.SssDeduction,
            .SssProvidentDeduction = source.SssProvidentDeduction,
            .PagIbigDeduction = source.PagIbigDeduction,
            .OfficerAllowance = source.OfficerAllowance,
            .UniformAllowance = source.UniformAllowance,
            .OtherEarnings = source.OtherEarnings,
            .OtherDeductions = source.OtherDeductions,
            .DailyWageSnapshot = source.DailyWageSnapshot,
            .HoursPerDaySnapshot = source.HoursPerDaySnapshot,
            .RegularEarnings = source.RegularEarnings,
            .SundayEarnings = source.SundayEarnings,
            .SpecialHolidayEarnings = source.SpecialHolidayEarnings,
            .LegalHolidayEarnings = source.LegalHolidayEarnings,
            .NightDifferentialRegularEarnings = source.NightDifferentialRegularEarnings,
            .NightDifferentialSundayEarnings = source.NightDifferentialSundayEarnings,
            .NightDifferentialSpecialHolidayEarnings = source.NightDifferentialSpecialHolidayEarnings,
            .NightDifferentialLegalHolidayEarnings = source.NightDifferentialLegalHolidayEarnings,
            .OvertimeRegularEarnings = source.OvertimeRegularEarnings,
            .OvertimeSundayEarnings = source.OvertimeSundayEarnings,
            .OvertimeSpecialHolidayEarnings = source.OvertimeSpecialHolidayEarnings,
            .OvertimeLegalHolidayEarnings = source.OvertimeLegalHolidayEarnings,
            .IncentivePay = source.IncentivePay,
            .TotalEarnings = source.TotalEarnings,
            .TotalDeductions = source.TotalDeductions,
            .NetPay = source.NetPay,
            .CalculationVersion = source.CalculationVersion,
            .PayPolicySnapshot = source.PayPolicySnapshot,
            .SnapshotComplete = source.SnapshotComplete
        }
        copy.Days = source.Days.Select(
            Function(day) New ManualPayrollDayRecord With {
                .ReportDate = day.ReportDate,
                .SelectedShiftNames = day.SelectedShiftNames.ToList(),
                .ShiftAssignments = day.ShiftAssignments.Select(AddressOf CopyShiftAssignment).ToList(),
                .Classification = day.Classification,
                .HourAdjustment = day.HourAdjustment,
                .TotalHours = day.TotalHours
            }).ToList()
        copy.ClientAdjustments = source.ClientAdjustments.Select(
            Function(item) New ManualPayrollClientAdjustment With {
                .SubClientId = item.SubClientId,
                .OfficerAllowance = item.OfficerAllowance,
                .UniformAllowance = item.UniformAllowance,
                .OtherEarnings = item.OtherEarnings,
                .CashBondDeduction = item.CashBondDeduction,
                .SssLoanDeduction = item.SssLoanDeduction,
                .SssCalLoanDeduction = item.SssCalLoanDeduction,
                .PagIbigLoanDeduction = item.PagIbigLoanDeduction,
                .PagIbigCalLoanDeduction = item.PagIbigCalLoanDeduction,
                .PhilHealthDeduction = item.PhilHealthDeduction,
                .SssDeduction = item.SssDeduction,
                .SssProvidentDeduction = item.SssProvidentDeduction,
                .PagIbigDeduction = item.PagIbigDeduction,
                .OtherDeductions = item.OtherDeductions
            }).ToList()
        Return copy
    End Function

    Private Function CopyShiftAssignment(source As ManualPayrollShiftAssignment) As ManualPayrollShiftAssignment
        Return New ManualPayrollShiftAssignment With {
            .ReportDate = source.ReportDate,
            .ShiftName = source.ShiftName,
            .SubClientId = source.SubClientId,
            .SubClientNameSnapshot = source.SubClientNameSnapshot,
            .DailyWageSnapshot = source.DailyWageSnapshot,
            .HoursPerDaySnapshot = source.HoursPerDaySnapshot,
            .RegularHours = source.RegularHours,
            .NightHours = source.NightHours,
            .OvertimeHours = source.OvertimeHours,
            .TotalHours = source.TotalHours,
            .BasePayCode = source.BasePayCode,
            .NightPayCode = source.NightPayCode,
            .OvertimePayCode = source.OvertimePayCode,
            .RegularEarnings = source.RegularEarnings,
            .NightEarnings = source.NightEarnings,
            .OvertimeEarnings = source.OvertimeEarnings,
            .IncentiveEarnings = source.IncentiveEarnings,
            .PayPolicySnapshot = source.PayPolicySnapshot
        }
    End Function

    Private Function LoadDays(connection As OleDbConnection, recordId As Integer, employeeId As String, subClientId As Integer, cutoff As String) As List(Of ManualPayrollDayRecord)
        Dim result As New List(Of ManualPayrollDayRecord)()
        Const recordSql As String = "SELECT [REPORT_DATE], [SHIFT_NAMES], [DAY_CLASSIFICATION], [HOUR_ADJUSTMENT], [DAILY_TOTAL_HOURS] " &
            "FROM [PRL_DTR_SHIFT_DAY] WHERE [PAYROLL_RECORD_ID] = ? ORDER BY [REPORT_DATE]"
        Using command As New OleDbCommand(recordSql, connection)
            AddInteger(command, recordId)
            ReadDays(command, result)
        End Using
        If result.Count > 0 Then Return result

        Const legacySql As String = "SELECT [REPORT_DATE], [SHIFT_NAMES], [DAY_CLASSIFICATION], [HOUR_ADJUSTMENT], [DAILY_TOTAL_HOURS] " &
            "FROM [PRL_DTR_SHIFT_DAY] WHERE ([PAYROLL_RECORD_ID] IS NULL OR [PAYROLL_RECORD_ID] = 0) " &
            "AND [EMPLOYEE_ID] = ? AND [SUB_CLIENT_ID] = ? AND [CUTOFF_PERIOD] = ? ORDER BY [REPORT_DATE]"
        Using command As New OleDbCommand(legacySql, connection)
            AddText(command, employeeId, 50)
            AddInteger(command, subClientId)
            AddText(command, cutoff, 30)
            ReadDays(command, result)
        End Using
        Return result
    End Function

    Private Sub ReadDays(command As OleDbCommand, result As List(Of ManualPayrollDayRecord))
        Using reader = command.ExecuteReader()
            While reader.Read()
                Dim item As New ManualPayrollDayRecord With {
                    .ReportDate = CDate(reader("REPORT_DATE")),
                    .Classification = SafeText(reader, "DAY_CLASSIFICATION"),
                    .HourAdjustment = SafeDecimal(reader, "HOUR_ADJUSTMENT"),
                    .TotalHours = SafeDecimal(reader, "DAILY_TOTAL_HOURS")
                }
                Dim shiftText = SafeText(reader, "SHIFT_NAMES")
                If shiftText <> String.Empty Then
                    item.SelectedShiftNames = shiftText.Split("|"c).
                        Select(Function(value) value.Trim()).
                        Where(Function(value) value <> String.Empty).
                        ToList()
                End If
                result.Add(item)
            End While
        End Using
    End Sub

    Private Sub LoadShiftAssignments(connection As OleDbConnection, record As ManualPayrollRecord)
        If record Is Nothing OrElse record.RecordId <= 0 OrElse record.Days Is Nothing Then Return
        Const sql As String = "SELECT [REPORT_DATE], [SHIFT_NAME], [SUB_CLIENT_ID], [SUB_CLIENT_NAME_SNAPSHOT], " &
            "[DAILY_WAGE_SNAPSHOT], [HOURS_PER_DAY_SNAPSHOT], [REGULAR_HOURS], [NIGHT_HOURS], " &
            "[OVERTIME_HOURS], [TOTAL_HOURS], [BASE_PAY_CODE], [NIGHT_PAY_CODE], [OVERTIME_PAY_CODE], " &
            "[REGULAR_EARNINGS], [NIGHT_EARNINGS], [OVERTIME_EARNINGS], [INCENTIVE_EARNINGS], " &
            "[PAY_POLICY_SNAPSHOT] FROM [PRL_DTR_SHIFT_ASSIGNMENT] " &
            "WHERE [PAYROLL_RECORD_ID] = ? ORDER BY [REPORT_DATE], [ID]"
        Using command As New OleDbCommand(sql, connection)
            AddInteger(command, record.RecordId)
            Using reader = command.ExecuteReader()
                While reader.Read()
                    Dim reportDate = CDate(reader("REPORT_DATE")).Date
                    Dim day = record.Days.FirstOrDefault(Function(item) item.ReportDate.Date = reportDate)
                    If day Is Nothing Then Continue While
                    day.ShiftAssignments.Add(New ManualPayrollShiftAssignment With {
                        .ReportDate = reportDate,
                        .ShiftName = SafeText(reader, "SHIFT_NAME"),
                        .SubClientId = CInt(SafeDecimal(reader, "SUB_CLIENT_ID")),
                        .SubClientNameSnapshot = SafeText(reader, "SUB_CLIENT_NAME_SNAPSHOT"),
                        .DailyWageSnapshot = SafeDecimal(reader, "DAILY_WAGE_SNAPSHOT"),
                        .HoursPerDaySnapshot = SafeDecimal(reader, "HOURS_PER_DAY_SNAPSHOT"),
                        .RegularHours = SafeDecimal(reader, "REGULAR_HOURS"),
                        .NightHours = SafeDecimal(reader, "NIGHT_HOURS"),
                        .OvertimeHours = SafeDecimal(reader, "OVERTIME_HOURS"),
                        .TotalHours = SafeDecimal(reader, "TOTAL_HOURS"),
                        .BasePayCode = SafeText(reader, "BASE_PAY_CODE"),
                        .NightPayCode = SafeText(reader, "NIGHT_PAY_CODE"),
                        .OvertimePayCode = SafeText(reader, "OVERTIME_PAY_CODE"),
                        .RegularEarnings = SafeDecimal(reader, "REGULAR_EARNINGS"),
                        .NightEarnings = SafeDecimal(reader, "NIGHT_EARNINGS"),
                        .OvertimeEarnings = SafeDecimal(reader, "OVERTIME_EARNINGS"),
                        .IncentiveEarnings = SafeDecimal(reader, "INCENTIVE_EARNINGS"),
                        .PayPolicySnapshot = SafeText(reader, "PAY_POLICY_SNAPSHOT")
                    })
                End While
            End Using
        End Using

        ' Records created before reliever assignments were introduced inherit the
        ' cutoff's home detachment, preserving their original behavior.
        For Each day In record.Days
            If day.ShiftAssignments.Count > 0 Then Continue For
            For Each shiftName In day.SelectedShiftNames
                day.ShiftAssignments.Add(New ManualPayrollShiftAssignment With {
                    .ReportDate = day.ReportDate.Date,
                    .ShiftName = shiftName,
                    .SubClientId = record.SubClientId,
                    .SubClientNameSnapshot = record.SubClientNameSnapshot,
                    .DailyWageSnapshot = record.DailyWageSnapshot,
                    .HoursPerDaySnapshot = record.HoursPerDaySnapshot,
                    .TotalHours = If(day.SelectedShiftNames.Count = 0, 0D, day.TotalHours / day.SelectedShiftNames.Count),
                    .PayPolicySnapshot = record.PayPolicySnapshot
                })
            Next
        Next
    End Sub

    Private Sub LoadClientAdjustments(connection As OleDbConnection, record As ManualPayrollRecord)
        record.ClientAdjustments.Clear()
        Const sql As String = "SELECT * FROM [PRL_DTR_CLIENT_ADJUSTMENT] WHERE [PAYROLL_RECORD_ID] = ? ORDER BY [SUB_CLIENT_ID]"
        Using command As New OleDbCommand(sql, connection)
            AddInteger(command, record.RecordId)
            Using reader = command.ExecuteReader()
                While reader.Read()
                    record.ClientAdjustments.Add(New ManualPayrollClientAdjustment With {
                        .SubClientId = CInt(SafeDecimal(reader, "SUB_CLIENT_ID")),
                        .OfficerAllowance = SafeDecimal(reader, "OFFICERS_ALLOWANCE"),
                        .UniformAllowance = SafeDecimal(reader, "SGUNIFORMALLOWANCE"),
                        .OtherEarnings = SafeDecimal(reader, "OTHER_EARNINGS"),
                        .CashBondDeduction = SafeDecimal(reader, "CB_DEDUCT"),
                        .SssLoanDeduction = SafeDecimal(reader, "SSS_LOAN_DEDUCT"),
                        .SssCalLoanDeduction = SafeDecimal(reader, "SSS_CAL_LOAN_DEDUCT"),
                        .PagIbigLoanDeduction = SafeDecimal(reader, "PI_LOAN_DEDUCT"),
                        .PagIbigCalLoanDeduction = SafeDecimal(reader, "PI_CAL_LOAN_DEDUCT"),
                        .PhilHealthDeduction = SafeDecimal(reader, "PH_DEDUCT"),
                        .SssDeduction = SafeDecimal(reader, "SSS_DEDUCT"),
                        .SssProvidentDeduction = SafeDecimal(reader, "SSS_PROVIDENT_DEDUCT"),
                        .PagIbigDeduction = SafeDecimal(reader, "PI_DEDUCT"),
                        .OtherDeductions = SafeDecimal(reader, "OTHER_DEDUCTIONS")
                    })
                End While
            End Using
        End Using

        If record.ClientAdjustments.Count = 0 Then
            record.ClientAdjustments.Add(New ManualPayrollClientAdjustment With {
                .SubClientId = record.SubClientId,
                .OfficerAllowance = record.OfficerAllowance,
                .UniformAllowance = record.UniformAllowance,
                .OtherEarnings = record.OtherEarnings,
                .CashBondDeduction = record.CashBondDeduction,
                .SssLoanDeduction = record.SssLoanDeduction,
                .SssCalLoanDeduction = record.SssCalLoanDeduction,
                .PagIbigLoanDeduction = record.PagIbigLoanDeduction,
                .PagIbigCalLoanDeduction = record.PagIbigCalLoanDeduction,
                .PhilHealthDeduction = record.PhilHealthDeduction,
                .SssDeduction = record.SssDeduction,
                .SssProvidentDeduction = record.SssProvidentDeduction,
                .PagIbigDeduction = record.PagIbigDeduction,
                .OtherDeductions = record.OtherDeductions
            })
        End If
    End Sub

    Private Sub ReadLatestIdentity(connection As OleDbConnection, transaction As OleDbTransaction, employeeId As String, subClientId As Integer, cutoff As String, ByRef recordId As Integer, ByRef status As String)
        Const sql As String = "SELECT TOP 1 [ID], [RECORD_STATUS] FROM [PRL_DTR_TOTAL_HOURS] " &
            "WHERE [EMPLOYEE_ID] = ? AND [SUB_CLIENT_ID] = ? AND [CUTOFF_PERIOD] = ? ORDER BY [ID] DESC"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddText(command, employeeId, 50)
            AddInteger(command, subClientId)
            AddText(command, cutoff, 30)
            Using reader = command.ExecuteReader()
                If Not reader.Read() Then Return
                recordId = CInt(reader("ID"))
                status = NormalizeStatus(If(reader.IsDBNull(1), String.Empty, Convert.ToString(reader(1))))
            End Using
        End Using
    End Sub

    Private Sub PopulateContextSnapshots(connection As OleDbConnection, transaction As OleDbTransaction, record As ManualPayrollRecord)
        If String.IsNullOrWhiteSpace(record.SubClientNameSnapshot) OrElse
           String.IsNullOrWhiteSpace(record.MainClientNameSnapshot) OrElse
           String.IsNullOrWhiteSpace(record.ClientAddressSnapshot) Then
            Const clientSql As String =
                "SELECT S.[SUB_CLIENT_NAME], S.[ADDRESS], M.[MAIN_CLIENT_NAME] " &
                "FROM [TBL_CLIENT_SUB] AS S INNER JOIN [TBL_CLIENT_MAIN] AS M " &
                "ON S.[MAIN_CLIENT_ID] = M.[MAIN_CLIENT_ID] WHERE S.[SUB_CLIENT_ID] = ?"
            Using command As New OleDbCommand(clientSql, connection, transaction)
                AddInteger(command, record.SubClientId)
                Using reader = command.ExecuteReader()
                    If reader.Read() Then
                        If String.IsNullOrWhiteSpace(record.SubClientNameSnapshot) Then record.SubClientNameSnapshot = SafeText(reader, "SUB_CLIENT_NAME")
                        If String.IsNullOrWhiteSpace(record.MainClientNameSnapshot) Then record.MainClientNameSnapshot = SafeText(reader, "MAIN_CLIENT_NAME")
                        If String.IsNullOrWhiteSpace(record.ClientAddressSnapshot) Then record.ClientAddressSnapshot = SafeText(reader, "ADDRESS")
                    End If
                End Using
            End Using
        End If

        If String.IsNullOrWhiteSpace(record.EmployeeNameSnapshot) Then
            Const employeeSql As String =
                "SELECT TOP 1 A.[LAST_NAME], A.[FIRST_NAME], A.[MIDDLE_NAME] " &
                "FROM [HR_EMPLOYEE_RECORD_HDR] AS H INNER JOIN [HR_APPLICATION_DTL] AS A " &
                "ON H.[APPLICATION_ID] = A.[APPLICATION_ID] WHERE H.[EMPLOYEE_ID] = ? ORDER BY H.[ID] DESC"
            Using command As New OleDbCommand(employeeSql, connection, transaction)
                AddText(command, record.EmployeeId, 50)
                Using reader = command.ExecuteReader()
                    If reader.Read() Then
                        Dim lastName = SafeText(reader, "LAST_NAME")
                        Dim firstName = SafeText(reader, "FIRST_NAME")
                        Dim middleName = SafeText(reader, "MIDDLE_NAME")
                        record.EmployeeNameSnapshot = (lastName & ", " & firstName & " " & middleName).Trim()
                    End If
                End Using
            End Using
        End If
    End Sub

    Private Sub UpdateSummary(connection As OleDbConnection, transaction As OleDbTransaction, recordId As Integer, record As ManualPayrollRecord, status As String, savedAt As Date, actor As String, submitFinal As Boolean)
        Const sql As String = "UPDATE [PRL_DTR_TOTAL_HOURS] SET " &
            "[NUM_OF_DAYS]=?, [TOTAL_HOURS]=?, [REG]=?, [SUN]=?, [SH]=?, [LH]=?, [ND_DAYS]=?, " &
            "[ND_REG]=?, [ND_SUN]=?, [ND_SH]=?, [ND_LH]=?, [OT_REG]=?, [OT_SUN]=?, [OT_SH]=?, [OT_LH]=?, " &
            "[RD_SUN_SH]=?, [RD_SUN_LH]=?, [ND_RD_SUN_SH]=?, [ND_RD_SUN_LH]=?, [OT_RD_SUN_SH]=?, [OT_RD_SUN_LH]=?, " &
            "[CB_DEDUCT]=?, [SSS_LOAN_DEDUCT]=?, [PI_LOAN_DEDUCT]=?, [PH_DEDUCT]=?, [SSS_DEDUCT]=?, [SSS_PROVIDENT_DEDUCT]=?, [PI_DEDUCT]=?, " &
            "[SSS_CAL_LOAN_DEDUCT]=?, [PI_CAL_LOAN_DEDUCT]=?, [OFFICERS_ALLOWANCE]=?, [SGUNIFORMALLOWANCE]=?, " &
            "[OTHER_EARNINGS]=?, [OTHER_DEDUCTIONS]=?, [DAILY_WAGE_SNAPSHOT]=?, [HOURS_PER_DAY_SNAPSHOT]=?, " &
            "[REG_EARNINGS]=?, [SUN_EARNINGS]=?, [SH_EARNINGS]=?, [LH_EARNINGS]=?, " &
            "[ND_REG_EARNINGS]=?, [ND_SUN_EARNINGS]=?, [ND_SH_EARNINGS]=?, [ND_LH_EARNINGS]=?, " &
            "[OT_REG_EARNINGS]=?, [OT_SUN_EARNINGS]=?, [OT_SH_EARNINGS]=?, [OT_LH_EARNINGS]=?, " &
            "[INCENTIVE_EARNINGS]=?, [TOTAL_EARNINGS]=?, [TOTAL_DEDUCTIONS]=?, [NET_PAY]=?, " &
            "[EMPLOYEE_NAME_SNAPSHOT]=?, [MAIN_CLIENT_NAME_SNAPSHOT]=?, [SUB_CLIENT_NAME_SNAPSHOT]=?, [CLIENT_ADDRESS_SNAPSHOT]=?, " &
            "[CALCULATION_VERSION]=?, [PAY_POLICY_SNAPSHOT]=?, [SNAPSHOT_COMPLETE]=?, " &
            "[PARENT_RECORD_ID]=?, [REVISION_NO]=?, [CHANGE_REMARKS]=?, " &
            "[RECORD_STATUS]=?, [SAVED_AT]=?, [SAVED_BY]=?, [SUBMITTED_AT]=?, [SUBMITTED_BY]=? WHERE [ID]=?"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddSummaryParameters(command, record)
            AddInteger(command, record.ParentRecordId)
            AddInteger(command, record.RevisionNo)
            AddLongText(command, record.ChangeRemarks)
            AddText(command, status, 20)
            AddDate(command, savedAt)
            AddText(command, actor, 100)
            AddNullableDate(command, If(submitFinal, CType(savedAt, Nullable(Of Date)), Nothing))
            AddNullableText(command, If(submitFinal, actor, Nothing), 100)
            AddInteger(command, recordId)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Function InsertSummary(connection As OleDbConnection, transaction As OleDbTransaction, record As ManualPayrollRecord, status As String, savedAt As Date, actor As String, submitFinal As Boolean) As Integer
        Dim sql As String = "INSERT INTO [PRL_DTR_TOTAL_HOURS] " &
            "([EMPLOYEE_ID], [SUB_CLIENT_ID], [CUTOFF_PERIOD], [NUM_OF_DAYS], [TOTAL_HOURS], [REG], [SUN], [SH], [LH], [ND_DAYS], " &
            "[ND_REG], [ND_SUN], [ND_SH], [ND_LH], [OT_REG], [OT_SUN], [OT_SH], [OT_LH], " &
            "[RD_SUN_SH], [RD_SUN_LH], [ND_RD_SUN_SH], [ND_RD_SUN_LH], [OT_RD_SUN_SH], [OT_RD_SUN_LH], " &
            "[CB_DEDUCT], [SSS_LOAN_DEDUCT], [PI_LOAN_DEDUCT], [PH_DEDUCT], [SSS_DEDUCT], [SSS_PROVIDENT_DEDUCT], [PI_DEDUCT], " &
            "[SSS_CAL_LOAN_DEDUCT], [PI_CAL_LOAN_DEDUCT], [OFFICERS_ALLOWANCE], [SGUNIFORMALLOWANCE], " &
            "[OTHER_EARNINGS], [OTHER_DEDUCTIONS], [DAILY_WAGE_SNAPSHOT], [HOURS_PER_DAY_SNAPSHOT], " &
            "[REG_EARNINGS], [SUN_EARNINGS], [SH_EARNINGS], [LH_EARNINGS], " &
            "[ND_REG_EARNINGS], [ND_SUN_EARNINGS], [ND_SH_EARNINGS], [ND_LH_EARNINGS], " &
            "[OT_REG_EARNINGS], [OT_SUN_EARNINGS], [OT_SH_EARNINGS], [OT_LH_EARNINGS], " &
            "[INCENTIVE_EARNINGS], [TOTAL_EARNINGS], [TOTAL_DEDUCTIONS], [NET_PAY], " &
            "[EMPLOYEE_NAME_SNAPSHOT], [MAIN_CLIENT_NAME_SNAPSHOT], [SUB_CLIENT_NAME_SNAPSHOT], [CLIENT_ADDRESS_SNAPSHOT], " &
            "[CALCULATION_VERSION], [PAY_POLICY_SNAPSHOT], [SNAPSHOT_COMPLETE], " &
            "[PARENT_RECORD_ID], [REVISION_NO], [CHANGE_REMARKS], " &
            "[RECORD_STATUS], [SAVED_AT], [SAVED_BY], [SUBMITTED_AT], [SUBMITTED_BY]) " &
            "VALUES (" & String.Join(", ", Enumerable.Repeat("?", 70)) & ")"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddText(command, record.EmployeeId, 50)
            AddInteger(command, record.SubClientId)
            AddText(command, record.CutoffPeriod, 30)
            AddSummaryParameters(command, record)
            AddInteger(command, record.ParentRecordId)
            AddInteger(command, record.RevisionNo)
            AddLongText(command, record.ChangeRemarks)
            AddText(command, status, 20)
            AddDate(command, savedAt)
            AddText(command, actor, 100)
            AddNullableDate(command, If(submitFinal, CType(savedAt, Nullable(Of Date)), Nothing))
            AddNullableText(command, If(submitFinal, actor, Nothing), 100)
            command.ExecuteNonQuery()
        End Using

        Using identityCommand As New OleDbCommand("SELECT @@IDENTITY", connection, transaction)
            Return Convert.ToInt32(identityCommand.ExecuteScalar(), CultureInfo.InvariantCulture)
        End Using
    End Function

    Private Sub AddSummaryParameters(command As OleDbCommand, record As ManualPayrollRecord)
        AddDouble(command, record.NumberOfDays)
        AddDouble(command, record.TotalHours)
        AddDouble(command, record.RegularHours)
        AddDouble(command, record.SundayHours)
        AddDouble(command, record.SpecialHolidayHours)
        AddDouble(command, record.LegalHolidayHours)
        AddDouble(command, record.NightDifferentialDays)
        AddDouble(command, record.NightDifferentialRegularHours)
        AddDouble(command, record.NightDifferentialSundayHours)
        AddDouble(command, record.NightDifferentialSpecialHolidayHours)
        AddDouble(command, record.NightDifferentialLegalHolidayHours)
        AddDouble(command, record.OvertimeRegularHours)
        AddDouble(command, record.OvertimeSundayHours)
        AddDouble(command, record.OvertimeSpecialHolidayHours)
        AddDouble(command, record.OvertimeLegalHolidayHours)
        AddDouble(command, record.SundaySpecialHolidayHours)
        AddDouble(command, record.SundayLegalHolidayHours)
        AddDouble(command, record.NightDifferentialSundaySpecialHolidayHours)
        AddDouble(command, record.NightDifferentialSundayLegalHolidayHours)
        AddDouble(command, record.OvertimeSundaySpecialHolidayHours)
        AddDouble(command, record.OvertimeSundayLegalHolidayHours)
        AddDouble(command, record.CashBondDeduction)
        AddDouble(command, record.SssLoanDeduction)
        AddDouble(command, record.PagIbigLoanDeduction)
        AddDouble(command, record.PhilHealthDeduction)
        AddDouble(command, record.SssDeduction)
        AddDouble(command, record.SssProvidentDeduction)
        AddDouble(command, record.PagIbigDeduction)
        AddDouble(command, record.SssCalLoanDeduction)
        AddDouble(command, record.PagIbigCalLoanDeduction)
        AddDouble(command, record.OfficerAllowance)
        AddDouble(command, record.UniformAllowance)
        AddDouble(command, record.OtherEarnings)
        AddDouble(command, record.OtherDeductions)
        AddDouble(command, record.DailyWageSnapshot)
        AddDouble(command, record.HoursPerDaySnapshot)
        AddDouble(command, record.RegularEarnings)
        AddDouble(command, record.SundayEarnings)
        AddDouble(command, record.SpecialHolidayEarnings)
        AddDouble(command, record.LegalHolidayEarnings)
        AddDouble(command, record.NightDifferentialRegularEarnings)
        AddDouble(command, record.NightDifferentialSundayEarnings)
        AddDouble(command, record.NightDifferentialSpecialHolidayEarnings)
        AddDouble(command, record.NightDifferentialLegalHolidayEarnings)
        AddDouble(command, record.OvertimeRegularEarnings)
        AddDouble(command, record.OvertimeSundayEarnings)
        AddDouble(command, record.OvertimeSpecialHolidayEarnings)
        AddDouble(command, record.OvertimeLegalHolidayEarnings)
        AddDouble(command, record.IncentivePay)
        AddDouble(command, record.TotalEarnings)
        AddDouble(command, record.TotalDeductions)
        AddDouble(command, record.NetPay)
        AddText(command, record.EmployeeNameSnapshot, 200)
        AddText(command, record.MainClientNameSnapshot, 200)
        AddText(command, record.SubClientNameSnapshot, 200)
        AddLongText(command, record.ClientAddressSnapshot)
        AddText(command, record.CalculationVersion, 30)
        AddLongText(command, record.PayPolicySnapshot)
        AddBoolean(command, record.SnapshotComplete)
    End Sub

    Private Sub ReplaceDayDetails(connection As OleDbConnection, transaction As OleDbTransaction, record As ManualPayrollRecord)
        Using deleteCommand As New OleDbCommand(
            "DELETE FROM [" & DetailTable & "] WHERE [PAYROLL_RECORD_ID] = ?",
            connection, transaction)
            AddInteger(deleteCommand, record.RecordId)
            deleteCommand.ExecuteNonQuery()
        End Using

        Const sql As String = "INSERT INTO [PRL_DTR_SHIFT_DAY] " &
            "([PAYROLL_RECORD_ID], [EMPLOYEE_ID], [SUB_CLIENT_ID], [CUTOFF_PERIOD], [REPORT_DATE], [SHIFT_NAMES], [DAY_CLASSIFICATION], [HOUR_ADJUSTMENT], [DAILY_TOTAL_HOURS]) " &
            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
        For Each day In record.Days.OrderBy(Function(item) item.ReportDate)
            Using command As New OleDbCommand(sql, connection, transaction)
                AddInteger(command, record.RecordId)
                AddText(command, record.EmployeeId, 50)
                AddInteger(command, record.SubClientId)
                AddText(command, record.CutoffPeriod, 30)
                AddDate(command, day.ReportDate.Date)
                AddLongText(command, String.Join("|", day.SelectedShiftNames))
                AddText(command, day.Classification, 10)
                AddDouble(command, day.HourAdjustment)
                AddDouble(command, day.TotalHours)
                command.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub ReplaceShiftAssignments(connection As OleDbConnection, transaction As OleDbTransaction, record As ManualPayrollRecord)
        Using deleteCommand As New OleDbCommand(
            "DELETE FROM [" & AssignmentTable & "] WHERE [PAYROLL_RECORD_ID] = ?", connection, transaction)
            AddInteger(deleteCommand, record.RecordId)
            deleteCommand.ExecuteNonQuery()
        End Using

        Const sql As String = "INSERT INTO [PRL_DTR_SHIFT_ASSIGNMENT] " &
            "([PAYROLL_RECORD_ID], [REPORT_DATE], [SHIFT_NAME], [SUB_CLIENT_ID], [SUB_CLIENT_NAME_SNAPSHOT], " &
            "[DAILY_WAGE_SNAPSHOT], [HOURS_PER_DAY_SNAPSHOT], [REGULAR_HOURS], [NIGHT_HOURS], " &
            "[OVERTIME_HOURS], [TOTAL_HOURS], [BASE_PAY_CODE], [NIGHT_PAY_CODE], [OVERTIME_PAY_CODE], " &
            "[REGULAR_EARNINGS], [NIGHT_EARNINGS], [OVERTIME_EARNINGS], [INCENTIVE_EARNINGS], [PAY_POLICY_SNAPSHOT]) " &
            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        For Each day In record.Days
            For Each assignment In day.ShiftAssignments
                Using command As New OleDbCommand(sql, connection, transaction)
                    AddInteger(command, record.RecordId)
                    AddDate(command, assignment.ReportDate.Date)
                    AddText(command, assignment.ShiftName, 100)
                    AddInteger(command, assignment.SubClientId)
                    AddText(command, assignment.SubClientNameSnapshot, 200)
                    AddDouble(command, assignment.DailyWageSnapshot)
                    AddDouble(command, assignment.HoursPerDaySnapshot)
                    AddDouble(command, assignment.RegularHours)
                    AddDouble(command, assignment.NightHours)
                    AddDouble(command, assignment.OvertimeHours)
                    AddDouble(command, assignment.TotalHours)
                    AddText(command, assignment.BasePayCode, 20)
                    AddText(command, assignment.NightPayCode, 20)
                    AddText(command, assignment.OvertimePayCode, 20)
                    AddDouble(command, assignment.RegularEarnings)
                    AddDouble(command, assignment.NightEarnings)
                    AddDouble(command, assignment.OvertimeEarnings)
                    AddDouble(command, assignment.IncentiveEarnings)
                    AddLongText(command, assignment.PayPolicySnapshot)
                    command.ExecuteNonQuery()
                End Using
            Next
        Next
    End Sub

    Private Sub ReplaceClientAdjustments(connection As OleDbConnection, transaction As OleDbTransaction, record As ManualPayrollRecord)
        Using deleteCommand As New OleDbCommand(
            "DELETE FROM [" & ClientAdjustmentTable & "] WHERE [PAYROLL_RECORD_ID] = ?", connection, transaction)
            AddInteger(deleteCommand, record.RecordId)
            deleteCommand.ExecuteNonQuery()
        End Using

        Const sql As String = "INSERT INTO [PRL_DTR_CLIENT_ADJUSTMENT] " &
            "([PAYROLL_RECORD_ID], [SUB_CLIENT_ID], [OFFICERS_ALLOWANCE], [SGUNIFORMALLOWANCE], [OTHER_EARNINGS], " &
            "[CB_DEDUCT], [SSS_LOAN_DEDUCT], [SSS_CAL_LOAN_DEDUCT], [PI_LOAN_DEDUCT], [PI_CAL_LOAN_DEDUCT], " &
            "[PH_DEDUCT], [SSS_DEDUCT], [SSS_PROVIDENT_DEDUCT], [PI_DEDUCT], [OTHER_DEDUCTIONS]) " &
            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        For Each item In record.ClientAdjustments.GroupBy(Function(value) value.SubClientId).Select(Function(group) group.Last())
            Using command As New OleDbCommand(sql, connection, transaction)
                AddInteger(command, record.RecordId)
                AddInteger(command, item.SubClientId)
                AddDouble(command, item.OfficerAllowance)
                AddDouble(command, item.UniformAllowance)
                AddDouble(command, item.OtherEarnings)
                AddDouble(command, item.CashBondDeduction)
                AddDouble(command, item.SssLoanDeduction)
                AddDouble(command, item.SssCalLoanDeduction)
                AddDouble(command, item.PagIbigLoanDeduction)
                AddDouble(command, item.PagIbigCalLoanDeduction)
                AddDouble(command, item.PhilHealthDeduction)
                AddDouble(command, item.SssDeduction)
                AddDouble(command, item.SssProvidentDeduction)
                AddDouble(command, item.PagIbigDeduction)
                AddDouble(command, item.OtherDeductions)
                command.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub InsertAudit(connection As OleDbConnection, transaction As OleDbTransaction, record As ManualPayrollRecord, actionType As String, remarks As String, actionAt As Date, actor As String)
        Const sql As String = "INSERT INTO [PRL_DTR_RECORD_AUDIT] " &
            "([PAYROLL_RECORD_ID], [EMPLOYEE_ID], [SUB_CLIENT_ID], [CUTOFF_PERIOD], [REVISION_NO], " &
            "[ACTION_TYPE], [REMARKS], [ACTION_AT], [ACTION_BY]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddInteger(command, record.RecordId)
            AddText(command, record.EmployeeId, 50)
            AddInteger(command, record.SubClientId)
            AddText(command, record.CutoffPeriod, 30)
            AddInteger(command, record.RevisionNo)
            AddText(command, actionType, 30)
            AddLongText(command, remarks)
            AddDate(command, actionAt)
            AddText(command, actor, 100)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub ReplaceDailyHours(connection As OleDbConnection, transaction As OleDbTransaction, record As ManualPayrollRecord)
        Dim firstDate = record.Days.Min(Function(item) item.ReportDate.Date)
        Dim lastDate = record.Days.Max(Function(item) item.ReportDate.Date)
        Dim clientIds As New HashSet(Of Integer)(record.Days.
            SelectMany(Function(day) day.ShiftAssignments).
            Select(Function(item) item.SubClientId).
            Where(Function(value) value > 0))
        clientIds.Add(record.SubClientId)
        Using previousCommand As New OleDbCommand(
            "SELECT DISTINCT [SUB_CLIENT_ID] FROM [" & AssignmentTable & "] WHERE [PAYROLL_RECORD_ID] = ?",
            connection, transaction)
            AddInteger(previousCommand, record.RecordId)
            Using reader = previousCommand.ExecuteReader()
                While reader.Read()
                    If Not reader.IsDBNull(0) Then clientIds.Add(Convert.ToInt32(reader(0), CultureInfo.InvariantCulture))
                End While
            End Using
        End Using
        For Each clientId In clientIds
            Using deleteCommand As New OleDbCommand(
                "DELETE FROM [PRL_DTR_HOURS_PER_DAY] WHERE [EMPLOYEE_ID] = ? AND [SUB_CLIENT_ID] = ? AND [REPORT_DATE] BETWEEN ? AND ?",
                connection, transaction)
                AddText(deleteCommand, record.EmployeeId, 50)
                AddInteger(deleteCommand, clientId)
                AddDate(deleteCommand, firstDate)
                AddDate(deleteCommand, lastDate)
                deleteCommand.ExecuteNonQuery()
            End Using
        Next

        Const sql As String = "INSERT INTO [PRL_DTR_HOURS_PER_DAY] " &
            "([EMPLOYEE_ID], [SUB_CLIENT_ID], [REPORT_DATE], [REPORT_DAY], [DAILY_TOTAL_HOURS]) VALUES (?, ?, ?, ?, ?)"
        For Each day In record.Days.OrderBy(Function(item) item.ReportDate)
            Dim assignments = day.ShiftAssignments.Where(Function(item) item.TotalHours > 0D).ToList()
            If assignments.Count = 0 AndAlso day.TotalHours > 0D Then
                assignments.Add(New ManualPayrollShiftAssignment With {
                    .ReportDate = day.ReportDate.Date,
                    .SubClientId = record.SubClientId,
                    .TotalHours = day.TotalHours
                })
            End If
            For Each clientGroup In assignments.GroupBy(Function(item) item.SubClientId)
                Using command As New OleDbCommand(sql, connection, transaction)
                    AddText(command, record.EmployeeId, 50)
                    AddInteger(command, clientGroup.Key)
                    AddDate(command, day.ReportDate.Date)
                    AddText(command, day.ReportDate.DayOfWeek.ToString(), 20)
                    AddDouble(command, clientGroup.Sum(Function(item) item.TotalHours))
                    command.ExecuteNonQuery()
                End Using
            Next
        Next
    End Sub

    Private Function NormalizeStatus(value As String) As String
        value = If(value, String.Empty).Trim().ToUpperInvariant()
        If value = StatusDraft Then Return StatusDraft
        If value = StatusAmendmentDraft Then Return StatusAmendmentDraft
        If value = StatusFinal Then Return StatusFinal
        If value = StatusLegacyFinal Then Return StatusLegacyFinal
        Return StatusLegacyFinal
    End Function

    Private Function SafeText(reader As OleDbDataReader, columnName As String) As String
        Dim ordinal As Integer
        Try
            ordinal = reader.GetOrdinal(columnName)
        Catch
            Return String.Empty
        End Try
        If reader.IsDBNull(ordinal) Then Return String.Empty
        Return Convert.ToString(reader.GetValue(ordinal)).Trim()
    End Function

    Private Function SafeDecimal(reader As OleDbDataReader, columnName As String) As Decimal
        Dim text = SafeText(reader, columnName)
        Dim value As Decimal
        Decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, value)
        If value = 0D Then Decimal.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, value)
        Return value
    End Function

    Private Function SafeBoolean(reader As OleDbDataReader, columnName As String) As Boolean
        Dim ordinal As Integer
        Try
            ordinal = reader.GetOrdinal(columnName)
        Catch
            Return False
        End Try
        If reader.IsDBNull(ordinal) Then Return False
        Try
            Return Convert.ToBoolean(reader.GetValue(ordinal), CultureInfo.InvariantCulture)
        Catch
            Return False
        End Try
    End Function

    Private Function SafeNullableDate(reader As OleDbDataReader, columnName As String) As Nullable(Of Date)
        Dim ordinal As Integer
        Try
            ordinal = reader.GetOrdinal(columnName)
        Catch
            Return Nothing
        End Try
        If reader.IsDBNull(ordinal) Then Return Nothing
        Return CDate(reader.GetValue(ordinal))
    End Function

    Private Function CreateOpenConnection() As OleDbConnection
        If String.IsNullOrWhiteSpace(GlobalVariables.GlobalConStr) Then MDB_Connection_Init()
        If String.IsNullOrWhiteSpace(GlobalVariables.GlobalConStr) Then
            Throw New InvalidOperationException("The database connection has not been initialized.")
        End If
        Dim connection As New OleDbConnection(GlobalVariables.GlobalConStr)
        connection.Open()
        Return connection
    End Function

    Private Function TableExists(connection As OleDbConnection, tableName As String) As Boolean
        Dim schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
        Return schema.AsEnumerable().Any(Function(row) String.Equals(Convert.ToString(row("TABLE_NAME")), tableName, StringComparison.OrdinalIgnoreCase))
    End Function

    Private Function ColumnExists(connection As OleDbConnection, tableName As String, columnName As String) As Boolean
        Dim schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, tableName, Nothing})
        Return schema.AsEnumerable().Any(Function(row) String.Equals(Convert.ToString(row("COLUMN_NAME")), columnName, StringComparison.OrdinalIgnoreCase))
    End Function

    Private Sub EnsureColumn(connection As OleDbConnection, tableName As String, columnName As String, dataType As String)
        If ColumnExists(connection, tableName, columnName) Then Return
        ExecuteDdl(connection, "ALTER TABLE [" & tableName & "] ADD COLUMN [" & columnName & "] " & dataType)
    End Sub

    Private Function IndexExists(connection As OleDbConnection, tableName As String, indexName As String) As Boolean
        Dim schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Indexes, Nothing)
        Return schema.AsEnumerable().Any(
            Function(row) String.Equals(Convert.ToString(row("TABLE_NAME")), tableName, StringComparison.OrdinalIgnoreCase) AndAlso
                String.Equals(Convert.ToString(row("INDEX_NAME")), indexName, StringComparison.OrdinalIgnoreCase))
    End Function

    Private Sub EnsureIndex(connection As OleDbConnection, tableName As String, indexName As String, columns As String)
        If IndexExists(connection, tableName, indexName) Then Return
        ExecuteDdl(connection, "CREATE INDEX [" & indexName & "] ON [" & tableName & "] (" & columns & ")")
    End Sub

    Private Sub ExecuteDdl(connection As OleDbConnection, sql As String)
        Using command As New OleDbCommand(sql, connection)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub AddText(command As OleDbCommand, value As String, length As Integer)
        command.Parameters.Add("?", OleDbType.VarWChar, length).Value = If(value, String.Empty)
    End Sub

    Private Sub AddLongText(command As OleDbCommand, value As String)
        command.Parameters.Add("?", OleDbType.LongVarWChar).Value = If(value, String.Empty)
    End Sub

    Private Sub AddNullableText(command As OleDbCommand, value As String, length As Integer)
        Dim parameter = command.Parameters.Add("?", OleDbType.VarWChar, length)
        parameter.Value = If(value Is Nothing, CType(DBNull.Value, Object), value)
    End Sub

    Private Sub AddInteger(command As OleDbCommand, value As Integer)
        command.Parameters.Add("?", OleDbType.Integer).Value = value
    End Sub

    Private Sub AddDouble(command As OleDbCommand, value As Decimal)
        command.Parameters.Add("?", OleDbType.Double).Value = CDbl(value)
    End Sub

    Private Sub AddBoolean(command As OleDbCommand, value As Boolean)
        command.Parameters.Add("?", OleDbType.Boolean).Value = value
    End Sub

    Private Sub AddDate(command As OleDbCommand, value As Date)
        command.Parameters.Add("?", OleDbType.Date).Value = value
    End Sub

    Private Sub AddNullableDate(command As OleDbCommand, value As Nullable(Of Date))
        Dim parameter = command.Parameters.Add("?", OleDbType.Date)
        parameter.Value = If(value.HasValue, CType(value.Value, Object), DBNull.Value)
    End Sub
End Module
