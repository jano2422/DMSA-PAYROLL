Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class PayrollPayRule
    Public Property Code As String
    Public Property DisplayName As String
    Public Property Enabled As Boolean
    Public Property Multiplier As Decimal

    Public Function Clone() As PayrollPayRule
        Return New PayrollPayRule With {
            .Code = Code,
            .DisplayName = DisplayName,
            .Enabled = Enabled,
            .Multiplier = Multiplier
        }
    End Function
End Class

Public Class PayrollEarningsBreakdown
    Private ReadOnly _amounts As Dictionary(Of String, Decimal)

    Public Sub New()
        _amounts = New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)
    End Sub

    Public Property IncentivePay As Decimal
    Public Property OfficerAllowance As Decimal
    Public Property UniformAllowance As Decimal
    Public Property OtherEarnings As Decimal

    Public Function AmountFor(code As String) As Decimal
        Dim value As Decimal
        If _amounts.TryGetValue(code, value) Then Return value
        Return 0D
    End Function

    Public Sub SetAmount(code As String, value As Decimal)
        _amounts(code) = value
    End Sub

    Public Sub AddAmount(code As String, value As Decimal)
        _amounts(code) = AmountFor(code) + value
    End Sub

    Public ReadOnly Property WorkEarnings As Decimal
        Get
            Return _amounts.Values.Sum() + IncentivePay
        End Get
    End Property

    Public ReadOnly Property TotalEarnings As Decimal
        Get
            Return WorkEarnings + OfficerAllowance + UniformAllowance + OtherEarnings
        End Get
    End Property
End Class

Public Class PayrollDayEarningInput
    Public Property DayCodes As String() = Array.Empty(Of String)()
    Public Property RegularHours As Decimal
    Public Property NightHours As Decimal
    Public Property OvertimeHours As Decimal
End Class

Public Class SubClientPayrollPolicy
    Public Const DutyEntryClientSchedule As String = "CLIENT_SCHEDULE"
    Public Const DutyEntrySingleShift As String = "SINGLE_SHIFT"
    Public Const NightDifferentialHourly As String = "HOURLY"
    Public Const NightDifferentialFixedCutoffPool As String = "FIXED_CUTOFF_POOL"
    Public Const NightDifferentialDisabled As String = "DISABLED"
    Public Const PremiumRateSemantics As String = "ADDITIONAL_PREMIUM_V1"

    Public Property SubClientId As Integer
    Public Property HoursPerDay As Decimal
    Public Property DutyEntryMode As String
    Public Property SingleShiftHours As Decimal
    Public Property SingleShiftIsNight As Boolean
    Public Property NightDifferentialMode As String
    Public Property NightDifferentialFixedCutoffAmount As Decimal
    Public Property IncentiveEnabled As Boolean
    Public Property IncentiveDays As Decimal
    Public Property IncentiveMonthDivisor As Decimal
    Public Property IncentiveCutoffDivisor As Decimal
    Public Property Notes As String
    Public Property UpdatedAt As Date?
    Public Property UpdatedBy As String
    Public Property RateSemantics As String
    Public ReadOnly Property Rules As Dictionary(Of String, PayrollPayRule)

    Public Sub New()
        Rules = New Dictionary(Of String, PayrollPayRule)(StringComparer.OrdinalIgnoreCase)
    End Sub

    Public Shared Function CreateDefault(subClientId As Integer) As SubClientPayrollPolicy
        Dim policy As New SubClientPayrollPolicy With {
            .SubClientId = subClientId,
            .HoursPerDay = 8D,
            .DutyEntryMode = DutyEntryClientSchedule,
            .SingleShiftHours = 8D,
            .SingleShiftIsNight = False,
            .NightDifferentialMode = NightDifferentialHourly,
            .NightDifferentialFixedCutoffAmount = 0D,
            .IncentiveEnabled = False,
            .IncentiveDays = 5D,
            .IncentiveMonthDivisor = 12D,
            .IncentiveCutoffDivisor = 2D,
            .Notes = String.Empty,
            .UpdatedBy = String.Empty,
            .RateSemantics = PremiumRateSemantics
        }

        policy.AddRule("REG", "Regular day", True, 0D)
        policy.AddRule("SUN", "Sunday", True, 0.3D)
        policy.AddRule("LH", "Legal holiday", True, 1D)
        policy.AddRule("SH", "Special holiday", True, 0.3D)
        policy.AddRule("RD_SH", "Sunday + special holiday", True, 0.5D)
        policy.AddRule("RD_LH", "Sunday + legal holiday", True, 1.6D)
        policy.AddRule("ND_REG", "Night differential - regular", True, 0.1D)
        policy.AddRule("ND_SUN", "Night differential - Sunday", True, 0.1D)
        policy.AddRule("ND_LH", "Night differential - legal holiday", True, 0.1D)
        policy.AddRule("ND_SH", "Night differential - special holiday", True, 0.1D)
        policy.AddRule("OT_REG", "Overtime - regular", True, 0.25D)
        policy.AddRule("OT_SUN", "Overtime - Sunday", True, 0.3D)
        policy.AddRule("OT_LH", "Overtime - legal holiday", True, 0.3D)
        policy.AddRule("OT_SH", "Overtime - special holiday", True, 0.3D)
        Return policy
    End Function

    Public Sub AddRule(code As String, displayName As String, enabled As Boolean, multiplier As Decimal)
        Rules(code) = New PayrollPayRule With {
            .Code = code,
            .DisplayName = displayName,
            .Enabled = enabled,
            .Multiplier = multiplier
        }
    End Sub

    Public Function GetRule(code As String) As PayrollPayRule
        Dim rule As PayrollPayRule = Nothing
        If Rules.TryGetValue(code, rule) Then Return rule

        Dim defaults = CreateDefault(SubClientId)
        If defaults.Rules.TryGetValue(code, rule) Then
            rule = rule.Clone()
            Rules(code) = rule
            Return rule
        End If

        Throw New ArgumentException("Unknown payroll pay code: " & code, NameOf(code))
    End Function

    Public Function Clone() As SubClientPayrollPolicy
        Dim copy As New SubClientPayrollPolicy With {
            .SubClientId = SubClientId,
            .HoursPerDay = HoursPerDay,
            .DutyEntryMode = DutyEntryMode,
            .SingleShiftHours = SingleShiftHours,
            .SingleShiftIsNight = SingleShiftIsNight,
            .NightDifferentialMode = NightDifferentialMode,
            .NightDifferentialFixedCutoffAmount = NightDifferentialFixedCutoffAmount,
            .IncentiveEnabled = IncentiveEnabled,
            .IncentiveDays = IncentiveDays,
            .IncentiveMonthDivisor = IncentiveMonthDivisor,
            .IncentiveCutoffDivisor = IncentiveCutoffDivisor,
            .Notes = Notes,
            .UpdatedAt = UpdatedAt,
            .UpdatedBy = UpdatedBy,
            .RateSemantics = RateSemantics
        }
        For Each rule In Rules.Values
            copy.Rules(rule.Code) = rule.Clone()
        Next
        Return copy
    End Function

    Public Sub Validate()
        If SubClientId <= 0 Then Throw New InvalidDataException("A sub-client must be selected.")
        If HoursPerDay <= 0D Then Throw New InvalidDataException("Hours per day must be greater than zero.")
        If Not IsSupportedDutyEntryMode(DutyEntryMode) Then
            Throw New InvalidDataException("Select a valid duty-entry mode.")
        End If
        If DutyEntryMode = DutyEntrySingleShift AndAlso
           (SingleShiftHours < HoursPerDay OrElse SingleShiftHours > 24D) Then
            Throw New InvalidDataException("Single-shift hours must be between the regular hours per day and 24 hours.")
        End If
        If Not IsSupportedNightDifferentialMode(NightDifferentialMode) Then
            Throw New InvalidDataException("Select a valid night differential calculation mode.")
        End If
        If NightDifferentialFixedCutoffAmount < 0D Then
            Throw New InvalidDataException("The fixed night differential cutoff amount cannot be negative.")
        End If
        If NightDifferentialMode = NightDifferentialFixedCutoffPool AndAlso
           NightDifferentialFixedCutoffAmount <= 0D Then
            Throw New InvalidDataException("Enter the monthly ND amount when night differential is paid by days.")
        End If
        If IncentiveDays < 0D Then Throw New InvalidDataException("Incentive days cannot be negative.")
        If IncentiveMonthDivisor <= 0D Then Throw New InvalidDataException("The incentive month divisor must be greater than zero.")
        If IncentiveCutoffDivisor <= 0D Then Throw New InvalidDataException("The incentive cutoff divisor must be greater than zero.")

        For Each code In SubClientPayrollPolicyService.PolicyRuleOrder
            Dim rule = GetRule(code)
            If rule.Multiplier < 0D Then
                Throw New InvalidDataException(rule.DisplayName & " additional premium cannot be negative.")
            End If
        Next
    End Sub

    Public Shared Function IsSupportedNightDifferentialMode(value As String) As Boolean
        Return String.Equals(value, NightDifferentialHourly, StringComparison.OrdinalIgnoreCase) OrElse
            String.Equals(value, NightDifferentialFixedCutoffPool, StringComparison.OrdinalIgnoreCase) OrElse
            String.Equals(value, NightDifferentialDisabled, StringComparison.OrdinalIgnoreCase)
    End Function

    Public Shared Function IsSupportedDutyEntryMode(value As String) As Boolean
        Return String.Equals(value, DutyEntryClientSchedule, StringComparison.OrdinalIgnoreCase) OrElse
            String.Equals(value, DutyEntrySingleShift, StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function ToAuditText() As String
        Dim builder As New StringBuilder()
        builder.Append("HoursPerDay=").Append(HoursPerDay.ToString(CultureInfo.InvariantCulture))
        builder.Append(";DutyEntryMode=").Append(DutyEntryMode)
        builder.Append(";SingleShiftHours=").Append(SingleShiftHours.ToString(CultureInfo.InvariantCulture))
        builder.Append(";SingleShiftIsNight=").Append(SingleShiftIsNight)
        builder.Append(";NDMode=").Append(NightDifferentialMode)
        builder.Append(";NDFixed=").Append(NightDifferentialFixedCutoffAmount.ToString(CultureInfo.InvariantCulture))
        builder.Append(";Incentive=").Append(IncentiveEnabled)
        builder.Append(";IncentiveDays=").Append(IncentiveDays.ToString(CultureInfo.InvariantCulture))
        builder.Append(";RateSemantics=").Append(RateSemantics)
        For Each code In SubClientPayrollPolicyService.PolicyRuleOrder
            Dim rule = GetRule(code)
            builder.Append(";").Append(code).Append("=").Append(rule.Enabled)
            builder.Append("@").Append(rule.Multiplier.ToString(CultureInfo.InvariantCulture))
        Next
        If Not String.IsNullOrWhiteSpace(Notes) Then
            builder.Append(";Notes=").Append(Notes.Replace(vbCr, " ").Replace(vbLf, " "))
        End If
        Return builder.ToString()
    End Function
End Class

Public Class PayrollPolicyImportResult
    Public Property ImportedCount As Integer
    Public Property SingleShiftConfiguredCount As Integer
    Public Property UnmatchedClients As New List(Of String)()
    Public Property WageMismatches As New List(Of String)()
    Public Property ShiftWarnings As New List(Of String)()
    Public Property Errors As New List(Of String)()

    Public Function BuildSummary() As String
        Dim builder As New StringBuilder()
        builder.AppendLine("Imported payroll rules: " & ImportedCount.ToString(CultureInfo.CurrentCulture))
        builder.AppendLine("9/10-hour single shifts configured: " & SingleShiftConfiguredCount.ToString(CultureInfo.CurrentCulture))
        builder.AppendLine("Unmatched sub-clients: " & UnmatchedClients.Count.ToString(CultureInfo.CurrentCulture))
        builder.AppendLine("Daily wage differences: " & WageMismatches.Count.ToString(CultureInfo.CurrentCulture))
        builder.AppendLine("Shift-hour warnings: " & ShiftWarnings.Count.ToString(CultureInfo.CurrentCulture))
        builder.Append("Errors: " & Errors.Count.ToString(CultureInfo.CurrentCulture))

        If UnmatchedClients.Count > 0 Then
            builder.AppendLine().AppendLine().AppendLine("Unmatched:")
            builder.Append(String.Join(vbCrLf, UnmatchedClients.Take(12)))
            If UnmatchedClients.Count > 12 Then builder.AppendLine().Append("...")
        End If
        If WageMismatches.Count > 0 Then
            builder.AppendLine().AppendLine().AppendLine("Wage differences (client master was not changed):")
            builder.Append(String.Join(vbCrLf, WageMismatches.Take(8)))
            If WageMismatches.Count > 8 Then builder.AppendLine().Append("...")
        End If
        If ShiftWarnings.Count > 0 Then
            builder.AppendLine().AppendLine().AppendLine("Shift-hour warnings:")
            builder.Append(String.Join(vbCrLf, ShiftWarnings.Take(8)))
            If ShiftWarnings.Count > 8 Then builder.AppendLine().Append("...")
        End If
        If Errors.Count > 0 Then
            builder.AppendLine().AppendLine().AppendLine("Errors:")
            builder.Append(String.Join(vbCrLf, Errors.Take(8)))
            If Errors.Count > 8 Then builder.AppendLine().Append("...")
        End If
        Return builder.ToString()
    End Function
End Class

Public Module SubClientPayrollPolicyService
    Private Const PolicyTable As String = "PRL_SUB_CLIENT_PAY_POLICY"
    Private Const RateTable As String = "PRL_SUB_CLIENT_PAY_RATE"
    Private Const HistoryTable As String = "PRL_SUB_CLIENT_PAY_POLICY_HISTORY"
    Private ReadOnly SchemaSyncRoot As New Object()
    Private schemaReady As Boolean

    Public ReadOnly PayCodeOrder As String() = {
        "REG", "SUN", "LH", "SH",
        "ND_REG", "ND_SUN", "ND_LH", "ND_SH",
        "OT_REG", "OT_SUN", "OT_LH", "OT_SH"
    }

    Public ReadOnly PolicyRuleOrder As String() = {
        "REG", "SUN", "LH", "SH", "RD_SH", "RD_LH",
        "ND_REG", "ND_SUN", "ND_LH", "ND_SH",
        "OT_REG", "OT_SUN", "OT_LH", "OT_SH"
    }

    Private Class PayrollPolicySourceRow
        Public Property ClientName As String
        Public Property ShiftText As String
        Public Property WageText As String
        Public Property RuleTexts As String()
        Public Property IncentiveText As String
        Public Property Notes As String
    End Class

    Public Sub EnsureSchema()
        If schemaReady Then Return

        SyncLock SchemaSyncRoot
            If schemaReady Then Return
            Using connection = CreateOpenConnection()
                If Not TableExists(connection, PolicyTable) Then
                    ExecuteDdl(connection,
                        "CREATE TABLE [" & PolicyTable & "] (" &
                        "[SUB_CLIENT_ID] LONG NOT NULL, [HOURS_PER_DAY] DOUBLE, [DUTY_ENTRY_MODE] TEXT(24), " &
                        "[SINGLE_SHIFT_HOURS] DOUBLE, [SINGLE_SHIFT_IS_NIGHT] YESNO, [ND_MODE] TEXT(24), " &
                        "[ND_FIXED_CUTOFF_AMOUNT] DOUBLE, [INCENTIVE_ENABLED] YESNO, [INCENTIVE_DAYS] DOUBLE, " &
                        "[INCENTIVE_MONTH_DIVISOR] DOUBLE, [INCENTIVE_CUTOFF_DIVISOR] DOUBLE, [NOTES] MEMO, " &
                        "[RATE_SEMANTICS] TEXT(32), [UPDATED_AT] DATETIME, [UPDATED_BY] TEXT(100), " &
                        "CONSTRAINT [PK_PRL_SUB_CLIENT_PAY_POLICY] PRIMARY KEY ([SUB_CLIENT_ID]))")
                End If

                EnsureColumn(connection, PolicyTable, "DUTY_ENTRY_MODE", "TEXT(24)")
                EnsureColumn(connection, PolicyTable, "SINGLE_SHIFT_HOURS", "DOUBLE")
                EnsureColumn(connection, PolicyTable, "SINGLE_SHIFT_IS_NIGHT", "YESNO")
                EnsureColumn(connection, PolicyTable, "RATE_SEMANTICS", "TEXT(32)")

                If Not TableExists(connection, RateTable) Then
                    ExecuteDdl(connection,
                        "CREATE TABLE [" & RateTable & "] (" &
                        "[SUB_CLIENT_ID] LONG NOT NULL, [PAY_CODE] TEXT(20) NOT NULL, [ENABLED] YESNO, [MULTIPLIER] DOUBLE, " &
                        "CONSTRAINT [PK_PRL_SUB_CLIENT_PAY_RATE] PRIMARY KEY ([SUB_CLIENT_ID], [PAY_CODE]))")
                End If

                If Not TableExists(connection, HistoryTable) Then
                    ExecuteDdl(connection,
                        "CREATE TABLE [" & HistoryTable & "] (" &
                        "[AUDIT_ID] AUTOINCREMENT CONSTRAINT [PK_PRL_SUB_CLIENT_PAY_POLICY_HISTORY] PRIMARY KEY, " &
                        "[SUB_CLIENT_ID] LONG NOT NULL, [CHANGED_AT] DATETIME, [CHANGED_BY] TEXT(100), [RULE_SNAPSHOT] MEMO)")
                End If

                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_SUN", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_LH", "DOUBLE")
                EnsureColumn(connection, "PRL_DTR_TOTAL_HOURS", "OT_SH", "DOUBLE")
            End Using
            schemaReady = True
        End SyncLock
    End Sub

    Public Function LoadPolicy(subClientId As Integer) As SubClientPayrollPolicy
        Dim policy = SubClientPayrollPolicy.CreateDefault(subClientId)
        If subClientId <= 0 Then Return policy

        EnsureSchema()
        Dim loadedSemantics As String = String.Empty
        Dim loadedRateCodes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Using connection = CreateOpenConnection()
            Const headerSql As String =
                "SELECT [HOURS_PER_DAY], [DUTY_ENTRY_MODE], [SINGLE_SHIFT_HOURS], [SINGLE_SHIFT_IS_NIGHT], " &
                "[ND_MODE], [ND_FIXED_CUTOFF_AMOUNT], [INCENTIVE_ENABLED], " &
                "[INCENTIVE_DAYS], [INCENTIVE_MONTH_DIVISOR], [INCENTIVE_CUTOFF_DIVISOR], [NOTES], " &
                "[RATE_SEMANTICS], [UPDATED_AT], [UPDATED_BY] FROM [PRL_SUB_CLIENT_PAY_POLICY] WHERE [SUB_CLIENT_ID] = ?"
            Using command As New OleDbCommand(headerSql, connection)
                AddIntegerParameter(command, subClientId)
                Using reader = command.ExecuteReader()
                    If reader.Read() Then
                        policy.HoursPerDay = SafeDecimal(reader("HOURS_PER_DAY"), policy.HoursPerDay)
                        policy.DutyEntryMode = SafeText(reader("DUTY_ENTRY_MODE"), policy.DutyEntryMode)
                        policy.SingleShiftHours = SafeDecimal(reader("SINGLE_SHIFT_HOURS"), policy.SingleShiftHours)
                        policy.SingleShiftIsNight = SafeBoolean(reader("SINGLE_SHIFT_IS_NIGHT"), policy.SingleShiftIsNight)
                        policy.NightDifferentialMode = SafeText(reader("ND_MODE"), policy.NightDifferentialMode)
                        policy.NightDifferentialFixedCutoffAmount = SafeDecimal(reader("ND_FIXED_CUTOFF_AMOUNT"), 0D)
                        policy.IncentiveEnabled = SafeBoolean(reader("INCENTIVE_ENABLED"), False)
                        policy.IncentiveDays = SafeDecimal(reader("INCENTIVE_DAYS"), policy.IncentiveDays)
                        policy.IncentiveMonthDivisor = SafeDecimal(reader("INCENTIVE_MONTH_DIVISOR"), policy.IncentiveMonthDivisor)
                        policy.IncentiveCutoffDivisor = SafeDecimal(reader("INCENTIVE_CUTOFF_DIVISOR"), policy.IncentiveCutoffDivisor)
                        policy.Notes = SafeText(reader("NOTES"), String.Empty)
                        loadedSemantics = SafeText(reader("RATE_SEMANTICS"), String.Empty)
                        If Not reader.IsDBNull(reader.GetOrdinal("UPDATED_AT")) Then policy.UpdatedAt = CDate(reader("UPDATED_AT"))
                        policy.UpdatedBy = SafeText(reader("UPDATED_BY"), String.Empty)
                    End If
                End Using
            End Using

            Const rateSql As String =
                "SELECT [PAY_CODE], [ENABLED], [MULTIPLIER] FROM [PRL_SUB_CLIENT_PAY_RATE] WHERE [SUB_CLIENT_ID] = ?"
            Using command As New OleDbCommand(rateSql, connection)
                AddIntegerParameter(command, subClientId)
                Using reader = command.ExecuteReader()
                    While reader.Read()
                        Dim code = SafeText(reader("PAY_CODE"), String.Empty)
                        If String.IsNullOrWhiteSpace(code) OrElse Not policy.Rules.ContainsKey(code) Then Continue While
                        loadedRateCodes.Add(code)
                        Dim rule = policy.GetRule(code)
                        rule.Enabled = SafeBoolean(reader("ENABLED"), rule.Enabled)
                        rule.Multiplier = SafeDecimal(reader("MULTIPLIER"), rule.Multiplier)
                    End While
                End Using
            End Using
        End Using

        If loadedRateCodes.Count > 0 AndAlso
           Not String.Equals(loadedSemantics, SubClientPayrollPolicy.PremiumRateSemantics, StringComparison.OrdinalIgnoreCase) Then
            ConvertLegacyMultipliersToPremiums(policy, loadedRateCodes)
        End If
        policy.RateSemantics = SubClientPayrollPolicy.PremiumRateSemantics

        policy.Validate()
        Return policy
    End Function

    Public Sub SavePolicy(policy As SubClientPayrollPolicy, changedBy As String)
        If policy Is Nothing Then Throw New ArgumentNullException(NameOf(policy))
        policy.Validate()
        EnsureSchema()

        Dim actor = If(changedBy, String.Empty).Trim()
        If actor.Length > 100 Then actor = actor.Substring(0, 100)
        Dim changedAt = Date.Now

        Using connection = CreateOpenConnection()
            Using transaction = connection.BeginTransaction()
                Try
                    Const updateSql As String =
                        "UPDATE [PRL_SUB_CLIENT_PAY_POLICY] SET [HOURS_PER_DAY] = ?, [DUTY_ENTRY_MODE] = ?, " &
                        "[SINGLE_SHIFT_HOURS] = ?, [SINGLE_SHIFT_IS_NIGHT] = ?, [ND_MODE] = ?, " &
                        "[ND_FIXED_CUTOFF_AMOUNT] = ?, [INCENTIVE_ENABLED] = ?, [INCENTIVE_DAYS] = ?, " &
                        "[INCENTIVE_MONTH_DIVISOR] = ?, [INCENTIVE_CUTOFF_DIVISOR] = ?, [NOTES] = ?, " &
                        "[RATE_SEMANTICS] = ?, [UPDATED_AT] = ?, [UPDATED_BY] = ? WHERE [SUB_CLIENT_ID] = ?"
                    Dim affected As Integer
                    Using command As New OleDbCommand(updateSql, connection, transaction)
                        AddPolicyHeaderParameters(command, policy, changedAt, actor)
                        AddIntegerParameter(command, policy.SubClientId)
                        affected = command.ExecuteNonQuery()
                    End Using

                    If affected = 0 Then
                        Const insertSql As String =
                            "INSERT INTO [PRL_SUB_CLIENT_PAY_POLICY] " &
                            "([HOURS_PER_DAY], [DUTY_ENTRY_MODE], [SINGLE_SHIFT_HOURS], [SINGLE_SHIFT_IS_NIGHT], " &
                            "[ND_MODE], [ND_FIXED_CUTOFF_AMOUNT], [INCENTIVE_ENABLED], " &
                            "[INCENTIVE_DAYS], [INCENTIVE_MONTH_DIVISOR], [INCENTIVE_CUTOFF_DIVISOR], [NOTES], " &
                            "[RATE_SEMANTICS], [UPDATED_AT], [UPDATED_BY], [SUB_CLIENT_ID]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
                        Using command As New OleDbCommand(insertSql, connection, transaction)
                            AddPolicyHeaderParameters(command, policy, changedAt, actor)
                            AddIntegerParameter(command, policy.SubClientId)
                            command.ExecuteNonQuery()
                        End Using
                    End If

                    Using command As New OleDbCommand(
                        "DELETE FROM [PRL_SUB_CLIENT_PAY_RATE] WHERE [SUB_CLIENT_ID] = ?", connection, transaction)
                        AddIntegerParameter(command, policy.SubClientId)
                        command.ExecuteNonQuery()
                    End Using

                    Const rateInsertSql As String =
                        "INSERT INTO [PRL_SUB_CLIENT_PAY_RATE] ([SUB_CLIENT_ID], [PAY_CODE], [ENABLED], [MULTIPLIER]) " &
                        "VALUES (?, ?, ?, ?)"
                    For Each code In PolicyRuleOrder
                        Dim rule = policy.GetRule(code)
                        Using command As New OleDbCommand(rateInsertSql, connection, transaction)
                            AddIntegerParameter(command, policy.SubClientId)
                            AddTextParameter(command, code, 20)
                            AddBooleanParameter(command, rule.Enabled)
                            AddDoubleParameter(command, rule.Multiplier)
                            command.ExecuteNonQuery()
                        End Using
                    Next

                    Const auditSql As String =
                        "INSERT INTO [PRL_SUB_CLIENT_PAY_POLICY_HISTORY] " &
                        "([SUB_CLIENT_ID], [CHANGED_AT], [CHANGED_BY], [RULE_SNAPSHOT]) VALUES (?, ?, ?, ?)"
                    Using command As New OleDbCommand(auditSql, connection, transaction)
                        AddIntegerParameter(command, policy.SubClientId)
                        AddDateParameter(command, changedAt)
                        AddTextParameter(command, actor, 100)
                        AddLongTextParameter(command, policy.ToAuditText())
                        command.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                Catch
                    transaction.Rollback()
                    Throw
                End Try
            End Using
        End Using

        policy.UpdatedAt = changedAt
        policy.UpdatedBy = actor
    End Sub

    Public Function ImportRulesFromWorkbook(filePath As String, changedBy As String) As PayrollPolicyImportResult
        If String.IsNullOrWhiteSpace(filePath) OrElse Not File.Exists(filePath) Then
            Throw New FileNotFoundException("Select a valid payroll-rules workbook.", filePath)
        End If

        EnsureSchema()
        Dim result As New PayrollPolicyImportResult()
        Dim workSites = LoadWorkSiteLookup()

        ' Excel commonly keeps an open workbook shared for reading. Snapshot the
        ' file first so an administrator can import the rules without closing it.
        Dim workbookBytes As Byte()
        Using source = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite Or FileShare.Delete)
            Using snapshot As New MemoryStream()
                source.CopyTo(snapshot)
                workbookBytes = snapshot.ToArray()
            End Using
        End Using

        For Each sourceRow In ReadPolicySourceRows(workbookBytes)
                Dim clientName = sourceRow.ClientName.Trim()

                Dim normalized = NormalizeClientName(clientName)
                Dim site As WorkSiteRecord = Nothing
                If Not workSites.TryGetValue(normalized, site) OrElse site Is Nothing Then
                    result.UnmatchedClients.Add(clientName)
                    Continue For
                End If

                Try
                    Dim policy = SubClientPayrollPolicy.CreateDefault(site.Id)
                    Dim shiftValues = Regex.Matches(sourceRow.ShiftText, "\d+(?:\.\d+)?").
                        Cast(Of Match)().Select(Function(item) Decimal.Parse(item.Value, CultureInfo.InvariantCulture)).Distinct().ToList()
                    If shiftValues.Count = 1 AndAlso shiftValues(0) > policy.HoursPerDay AndAlso shiftValues(0) < 12D Then
                        policy.DutyEntryMode = SubClientPayrollPolicy.DutyEntrySingleShift
                        policy.SingleShiftHours = shiftValues(0)
                        result.SingleShiftConfiguredCount += 1
                    ElseIf shiftValues.Count > 1 Then
                        result.ShiftWarnings.Add(clientName & ": " & sourceRow.ShiftText &
                            " requires manual duty-mode review; client schedule was retained.")
                    End If

                    For index As Integer = 0 To PayCodeOrder.Length - 1
                        Dim ruleText = sourceRow.RuleTexts(index).Trim()
                        Dim rule = policy.GetRule(PayCodeOrder(index))
                        rule.Enabled = Not String.IsNullOrWhiteSpace(ruleText)
                        rule.Multiplier = ImportedMultiplier(rule.Code, ruleText, rule.Multiplier)
                    Next

                    Dim ndRegularText = sourceRow.RuleTexts(4).Trim()
                    If ndRegularText.IndexOf("987.5", StringComparison.OrdinalIgnoreCase) >= 0 Then
                        policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialFixedCutoffPool
                        policy.NightDifferentialFixedCutoffAmount = 987.5D
                        policy.GetRule("ND_REG").Enabled = True
                        policy.GetRule("ND_SUN").Enabled = False
                        policy.GetRule("ND_LH").Enabled = False
                        policy.GetRule("ND_SH").Enabled = False
                    ElseIf Not policy.GetRule("ND_REG").Enabled AndAlso
                           Not policy.GetRule("ND_SUN").Enabled AndAlso
                           Not policy.GetRule("ND_LH").Enabled AndAlso
                           Not policy.GetRule("ND_SH").Enabled Then
                        policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialDisabled
                    End If

                    policy.IncentiveEnabled = Not String.IsNullOrWhiteSpace(sourceRow.IncentiveText)
                    policy.Notes = sourceRow.Notes.Trim()
                    SavePolicy(policy, changedBy)
                    result.ImportedCount += 1

                    Dim workbookWage As Decimal
                    If Decimal.TryParse(sourceRow.WageText, NumberStyles.Any, CultureInfo.InvariantCulture, workbookWage) AndAlso
                       workbookWage > 0D AndAlso workbookWage <> site.DailyWage Then
                        result.WageMismatches.Add(clientName & ": workbook " & workbookWage.ToString("0.##") &
                            ", client master " & site.DailyWage.ToString(CultureInfo.CurrentCulture))
                    End If
                Catch ex As Exception
                    result.Errors.Add(clientName & ": " & ex.Message)
                End Try
        Next

        Return result
    End Function

    Private Function ReadPolicySourceRows(workbookBytes As Byte()) As List(Of PayrollPolicySourceRow)
        Dim rows As New List(Of PayrollPolicySourceRow)()
        Using workbookStream As New MemoryStream(workbookBytes, writable:=False)
            Using document = SpreadsheetDocument.Open(workbookStream, False)
                Dim workbookPart = document.WorkbookPart
                If workbookPart Is Nothing Then Throw New InvalidDataException("The selected file is not a valid Excel workbook.")

                Dim sourceSheet = workbookPart.Workbook.Sheets.Elements(Of Sheet)().
                    FirstOrDefault(Function(item) String.Equals(item.Name.Value, "Sheet3", StringComparison.OrdinalIgnoreCase))
                If sourceSheet Is Nothing Then Throw New InvalidDataException("The workbook must contain a Sheet3 payroll-rule matrix.")

                Dim worksheetPart = TryCast(workbookPart.GetPartById(sourceSheet.Id.Value), WorksheetPart)
                If worksheetPart Is Nothing Then Throw New InvalidDataException("Sheet3 could not be read from the payroll-rule workbook.")

                Dim sharedStrings = If(workbookPart.SharedStringTablePart Is Nothing,
                    Nothing, workbookPart.SharedStringTablePart.SharedStringTable)
                Dim sheetData = worksheetPart.Worksheet.GetFirstChild(Of SheetData)()
                If sheetData Is Nothing Then Return rows

                For Each source In sheetData.Elements(Of Row)()
                    If source.RowIndex Is Nothing OrElse source.RowIndex.Value < 2UI Then Continue For
                    Dim cells = source.Elements(Of Cell)().ToDictionary(
                        Function(cell) ExcelColumnNumber(If(cell.CellReference Is Nothing, String.Empty, cell.CellReference.Value)))

                    Dim clientName = ReadExcelCell(cells, 1, sharedStrings, preferFormula:=False).Trim()
                    If String.IsNullOrWhiteSpace(clientName) Then Continue For

                    Dim ruleTexts(PayCodeOrder.Length - 1) As String
                    For index As Integer = 0 To ruleTexts.Length - 1
                        ruleTexts(index) = ReadExcelCell(cells, 18 + index, sharedStrings, preferFormula:=True)
                    Next

                    rows.Add(New PayrollPolicySourceRow With {
                        .ClientName = clientName,
                        .ShiftText = ReadExcelCell(cells, 2, sharedStrings, preferFormula:=False),
                        .WageText = ReadExcelCell(cells, 3, sharedStrings, preferFormula:=False),
                        .RuleTexts = ruleTexts,
                        .IncentiveText = ReadExcelCell(cells, 30, sharedStrings, preferFormula:=True),
                        .Notes = ReadExcelCell(cells, 31, sharedStrings, preferFormula:=False)
                    })
                Next
            End Using
        End Using
        Return rows
    End Function

    Private Function ReadExcelCell(cells As Dictionary(Of Integer, Cell), columnNumber As Integer,
                                   sharedStrings As SharedStringTable, preferFormula As Boolean) As String
        Dim cell As Cell = Nothing
        If Not cells.TryGetValue(columnNumber, cell) Then Return String.Empty
        If preferFormula AndAlso cell.CellFormula IsNot Nothing Then Return cell.CellFormula.Text
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.InlineString Then
            Return If(cell.InlineString Is Nothing, String.Empty, cell.InlineString.InnerText)
        End If
        If cell.CellValue Is Nothing Then Return String.Empty

        Dim rawValue = cell.CellValue.Text
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString AndAlso sharedStrings IsNot Nothing Then
            Dim sharedIndex As Integer
            If Integer.TryParse(rawValue, sharedIndex) AndAlso sharedIndex >= 0 Then
                Dim sharedItem = sharedStrings.Elements(Of SharedStringItem)().ElementAtOrDefault(sharedIndex)
                If sharedItem IsNot Nothing Then Return sharedItem.InnerText
            End If
        End If
        Return rawValue
    End Function

    Private Function ExcelColumnNumber(cellReference As String) As Integer
        Dim result As Integer
        For Each character In cellReference
            If Not Char.IsLetter(character) Then Exit For
            result = result * 26 + (AscW(Char.ToUpperInvariant(character)) - AscW("A"c) + 1)
        Next
        Return result
    End Function

    Public Function DescribePolicy(policy As SubClientPayrollPolicy) As String
        If policy Is Nothing Then Return "Payroll rules unavailable"
        Dim parts As New List(Of String)()
        If policy.DutyEntryMode = SubClientPayrollPolicy.DutyEntrySingleShift Then
            parts.Add(policy.SingleShiftHours.ToString("0.##", CultureInfo.CurrentCulture) & "h single shift")
        End If
        If Not policy.GetRule("SUN").Enabled Then parts.Add("Sunday pay off")

        Select Case policy.NightDifferentialMode
            Case SubClientPayrollPolicy.NightDifferentialDisabled
                parts.Add("ND off")
            Case SubClientPayrollPolicy.NightDifferentialFixedCutoffPool
                parts.Add("ND paid by reporting days")
            Case Else
                Dim enabledNightCodes = {"ND_REG", "ND_SUN", "ND_LH", "ND_SH"}.Count(Function(code) policy.GetRule(code).Enabled)
                If enabledNightCodes < 4 Then parts.Add("limited ND")
        End Select

        Dim enabledOvertimeCodes = {"OT_REG", "OT_SUN", "OT_LH", "OT_SH"}.Count(Function(code) policy.GetRule(code).Enabled)
        If enabledOvertimeCodes = 0 Then
            parts.Add("OT off")
        ElseIf enabledOvertimeCodes < 4 Then
            parts.Add("limited OT")
        ElseIf policy.GetRule("OT_REG").Multiplier = 0D Then
            parts.Add("OT at regular rate")
        End If
        If policy.IncentiveEnabled Then parts.Add("5-day incentive")
        If parts.Count = 0 Then Return "Standard universal payroll rules"
        Return String.Join(" · ", parts)
    End Function

    Public Function CutoffDayCount(cutoff As String) As Integer
        If String.IsNullOrWhiteSpace(cutoff) Then Return 15
        Dim parts = cutoff.Split("_"c)
        If parts.Length <> 3 Then Return 15

        Dim monthNumber As Integer
        Dim yearNumber As Integer
        If Not Integer.TryParse(parts(0), monthNumber) OrElse Not Integer.TryParse(parts(2), yearNumber) Then Return 15
        If monthNumber < 1 OrElse monthNumber > 12 Then Return 15
        Return If(parts(1).Equals("1st", StringComparison.OrdinalIgnoreCase), 15, Date.DaysInMonth(yearNumber, monthNumber) - 15)
    End Function

    Public Function ResolveEnabledPayCode(
        policy As SubClientPayrollPolicy,
        prefix As String,
        ParamArray dayCodes As String()
    ) As String
        If policy Is Nothing Then policy = SubClientPayrollPolicy.CreateDefault(0)
        prefix = If(prefix, String.Empty).Trim().ToUpperInvariant()
        If prefix <> String.Empty AndAlso prefix <> "ND_" AndAlso prefix <> "OT_" Then
            Throw New ArgumentException("Pay-code prefix must be blank, ND_, or OT_.", NameOf(prefix))
        End If

        Dim candidates = If(dayCodes, Array.Empty(Of String)()).
            Select(Function(code) If(code, String.Empty).Trim().ToUpperInvariant()).
            Where(Function(code) code = "REG" OrElse code = "SUN" OrElse code = "SH" OrElse code = "LH").
            Distinct(StringComparer.OrdinalIgnoreCase).
            ToList()
        If candidates.Count = 0 Then candidates.Add("REG")

        For Each dayCode In candidates
            Dim payCode = prefix & dayCode
            If policy.GetRule(payCode).Enabled Then Return payCode
        Next

        ' Preserve the requested bucket when no fallback is enabled. This keeps
        ' the hours visible while the calculation deliberately produces no pay.
        Return prefix & candidates(0)
    End Function

    Public Function ResolveEnabledDayPayCode(policy As SubClientPayrollPolicy, ParamArray dayCodes As String()) As String
        If policy Is Nothing Then policy = SubClientPayrollPolicy.CreateDefault(0)
        Return OutputDayCodeForRateCode(ResolveEffectiveDayRateCode(policy, dayCodes))
    End Function

    Public Function NormalizePayHours(
        policy As SubClientPayrollPolicy,
        regularHours As Decimal,
        sundayHours As Decimal,
        legalHolidayHours As Decimal,
        specialHolidayHours As Decimal,
        nightDifferentialRegularHours As Decimal,
        nightDifferentialSundayHours As Decimal,
        nightDifferentialLegalHolidayHours As Decimal,
        nightDifferentialSpecialHolidayHours As Decimal,
        overtimeRegularHours As Decimal,
        overtimeSundayHours As Decimal,
        overtimeLegalHolidayHours As Decimal,
        overtimeSpecialHolidayHours As Decimal
    ) As Dictionary(Of String, Decimal)
        If policy Is Nothing Then policy = SubClientPayrollPolicy.CreateDefault(0)
        policy.Validate()
        Dim hoursByCode As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase) From {
            {"REG", regularHours}, {"SUN", sundayHours}, {"LH", legalHolidayHours}, {"SH", specialHolidayHours},
            {"ND_REG", nightDifferentialRegularHours}, {"ND_SUN", nightDifferentialSundayHours},
            {"ND_LH", nightDifferentialLegalHolidayHours}, {"ND_SH", nightDifferentialSpecialHolidayHours},
            {"OT_REG", overtimeRegularHours}, {"OT_SUN", overtimeSundayHours},
            {"OT_LH", overtimeLegalHolidayHours}, {"OT_SH", overtimeSpecialHolidayHours}
        }

        ' Legacy/imported summaries no longer have the date-level Sunday plus
        ' holiday context, so their safe fallback is the equivalent regular
        ' bucket. New Manual DTR records perform a richer holiday -> Sunday ->
        ' regular resolution before reaching this shared safeguard.
        MoveDisabledHoursToFallback(hoursByCode, policy, "SUN", "REG")
        MoveDisabledHoursToFallback(hoursByCode, policy, "SH", "REG")
        MoveDisabledHoursToFallback(hoursByCode, policy, "LH", "REG")
        MoveDisabledHoursToFallback(hoursByCode, policy, "ND_SUN", "ND_REG")
        MoveDisabledHoursToFallback(hoursByCode, policy, "ND_SH", "ND_REG")
        MoveDisabledHoursToFallback(hoursByCode, policy, "ND_LH", "ND_REG")
        MoveDisabledHoursToFallback(hoursByCode, policy, "OT_SUN", "OT_REG")
        MoveDisabledHoursToFallback(hoursByCode, policy, "OT_SH", "OT_REG")
        MoveDisabledHoursToFallback(hoursByCode, policy, "OT_LH", "OT_REG")
        Return hoursByCode
    End Function

    Public Function CalculateTotalEarnings(
        policy As SubClientPayrollPolicy,
        dailyWage As Decimal,
        cutoff As String,
        numberOfDays As Decimal,
        regularHours As Decimal,
        sundayHours As Decimal,
        legalHolidayHours As Decimal,
        specialHolidayHours As Decimal,
        nightDifferentialRegularHours As Decimal,
        nightDifferentialSundayHours As Decimal,
        nightDifferentialLegalHolidayHours As Decimal,
        nightDifferentialSpecialHolidayHours As Decimal,
        overtimeRegularHours As Decimal,
        overtimeSundayHours As Decimal,
        overtimeLegalHolidayHours As Decimal,
        overtimeSpecialHolidayHours As Decimal,
        officerAllowance As Decimal,
        uniformAllowance As Decimal,
        otherEarnings As Decimal
    ) As Decimal
        Return CalculateEarningsBreakdown(
            policy,
            dailyWage,
            cutoff,
            numberOfDays,
            regularHours,
            sundayHours,
            legalHolidayHours,
            specialHolidayHours,
            nightDifferentialRegularHours,
            nightDifferentialSundayHours,
            nightDifferentialLegalHolidayHours,
            nightDifferentialSpecialHolidayHours,
            overtimeRegularHours,
            overtimeSundayHours,
            overtimeLegalHolidayHours,
            overtimeSpecialHolidayHours,
            officerAllowance,
            uniformAllowance,
            otherEarnings).TotalEarnings
    End Function

    Public Function CalculateEarningsBreakdown(
        policy As SubClientPayrollPolicy,
        dailyWage As Decimal,
        cutoff As String,
        numberOfDays As Decimal,
        regularHours As Decimal,
        sundayHours As Decimal,
        legalHolidayHours As Decimal,
        specialHolidayHours As Decimal,
        nightDifferentialRegularHours As Decimal,
        nightDifferentialSundayHours As Decimal,
        nightDifferentialLegalHolidayHours As Decimal,
        nightDifferentialSpecialHolidayHours As Decimal,
        overtimeRegularHours As Decimal,
        overtimeSundayHours As Decimal,
        overtimeLegalHolidayHours As Decimal,
        overtimeSpecialHolidayHours As Decimal,
        officerAllowance As Decimal,
        uniformAllowance As Decimal,
        otherEarnings As Decimal
    ) As PayrollEarningsBreakdown
        If policy Is Nothing Then policy = SubClientPayrollPolicy.CreateDefault(0)
        policy.Validate()
        Dim hoursPerDay = policy.HoursPerDay
        Dim hoursByCode = NormalizePayHours(
            policy,
            regularHours, sundayHours, legalHolidayHours, specialHolidayHours,
            nightDifferentialRegularHours, nightDifferentialSundayHours,
            nightDifferentialLegalHolidayHours, nightDifferentialSpecialHolidayHours,
            overtimeRegularHours, overtimeSundayHours,
            overtimeLegalHolidayHours, overtimeSpecialHolidayHours)

        Dim result As New PayrollEarningsBreakdown With {
            .OfficerAllowance = officerAllowance,
            .UniformAllowance = uniformAllowance,
            .OtherEarnings = otherEarnings
        }
        For Each code In PayCodeOrder
            Dim rule = policy.GetRule(code)
            If Not rule.Enabled Then
                result.SetAmount(code, 0D)
                Continue For
            End If
            If code.StartsWith("ND_", StringComparison.OrdinalIgnoreCase) AndAlso
               policy.NightDifferentialMode <> SubClientPayrollPolicy.NightDifferentialHourly Then
                result.SetAmount(code, 0D)
                Continue For
            End If
            result.SetAmount(code, dailyWage / hoursPerDay * EarningsFactorForCode(policy, code) * hoursByCode(code))
        Next

        If policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialFixedCutoffPool AndAlso
           policy.GetRule("ND_REG").Enabled Then
            result.SetAmount("ND_REG", policy.NightDifferentialFixedCutoffAmount / 2D / CutoffDayCount(cutoff) * numberOfDays)
        End If
        If policy.IncentiveEnabled Then
            result.IncentivePay = dailyWage * policy.IncentiveDays / policy.IncentiveMonthDivisor /
                policy.IncentiveCutoffDivisor / CutoffDayCount(cutoff) * numberOfDays
        End If

        Return result
    End Function

    Public Function CalculateEarningsBreakdownForDays(
        policy As SubClientPayrollPolicy,
        dailyWage As Decimal,
        cutoff As String,
        numberOfDays As Decimal,
        days As IEnumerable(Of PayrollDayEarningInput),
        officerAllowance As Decimal,
        uniformAllowance As Decimal,
        otherEarnings As Decimal
    ) As PayrollEarningsBreakdown
        If policy Is Nothing Then Throw New ArgumentNullException(NameOf(policy))
        policy.Validate()

        Dim result As New PayrollEarningsBreakdown With {
            .OfficerAllowance = officerAllowance,
            .UniformAllowance = uniformAllowance,
            .OtherEarnings = otherEarnings
        }
        Dim hourlyRate = dailyWage / policy.HoursPerDay

        For Each day In If(days, Enumerable.Empty(Of PayrollDayEarningInput)())
            If day Is Nothing Then Continue For
            Dim dayCodes = If(day.DayCodes, Array.Empty(Of String)())
            Dim rateCode = ResolveEffectiveDayRateCode(policy, dayCodes)
            Dim dayFactor = 1D + policy.GetRule(rateCode).Multiplier

            Dim baseCode = OutputDayCodeForRateCode(rateCode)
            If policy.GetRule(rateCode).Enabled AndAlso day.RegularHours <> 0D Then
                result.AddAmount(baseCode, hourlyRate * dayFactor * day.RegularHours)
            End If

            If policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialHourly AndAlso day.NightHours <> 0D Then
                Dim ndCode = ResolveEnabledPayCode(policy, "ND_", dayCodes)
                Dim ndRule = policy.GetRule(ndCode)
                If ndRule.Enabled Then result.AddAmount(ndCode, hourlyRate * dayFactor * ndRule.Multiplier * day.NightHours)
            End If

            If day.OvertimeHours <> 0D Then
                Dim otCode = ResolveEnabledPayCode(policy, "OT_", dayCodes)
                Dim otRule = policy.GetRule(otCode)
                If otRule.Enabled Then result.AddAmount(otCode, hourlyRate * dayFactor * (1D + otRule.Multiplier) * day.OvertimeHours)
            End If
        Next

        If policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialFixedCutoffPool AndAlso
           policy.GetRule("ND_REG").Enabled Then
            result.SetAmount("ND_REG", policy.NightDifferentialFixedCutoffAmount / 2D / CutoffDayCount(cutoff) * numberOfDays)
        End If
        If policy.IncentiveEnabled Then
            result.IncentivePay = dailyWage * policy.IncentiveDays / policy.IncentiveMonthDivisor /
                policy.IncentiveCutoffDivisor / CutoffDayCount(cutoff) * numberOfDays
        End If
        Return result
    End Function

    Public Function EarningsFactorForCode(policy As SubClientPayrollPolicy, code As String) As Decimal
        If policy Is Nothing Then Throw New ArgumentNullException(NameOf(policy))
        Dim normalizedCode = If(code, String.Empty).Trim().ToUpperInvariant()
        Dim rule = policy.GetRule(normalizedCode)
        If normalizedCode.StartsWith("ND_", StringComparison.OrdinalIgnoreCase) Then
            Return EffectiveDayFactor(policy, normalizedCode.Substring(3)) * rule.Multiplier
        End If
        If normalizedCode.StartsWith("OT_", StringComparison.OrdinalIgnoreCase) Then
            Return EffectiveDayFactor(policy, normalizedCode.Substring(3)) * (1D + rule.Multiplier)
        End If
        Return EffectiveDayFactor(policy, normalizedCode)
    End Function

    Private Function EffectiveDayFactor(policy As SubClientPayrollPolicy, dayCode As String) As Decimal
        Return 1D + policy.GetRule(dayCode).Multiplier
    End Function

    Private Function ResolveEffectiveDayRateCode(policy As SubClientPayrollPolicy, dayCodes As IEnumerable(Of String)) As String
        Dim requested = New HashSet(Of String)(
            If(dayCodes, Enumerable.Empty(Of String)()).
                Select(Function(code) If(code, String.Empty).Trim().ToUpperInvariant()),
            StringComparer.OrdinalIgnoreCase)
        Dim candidates As New List(Of String)()
        If requested.Contains("SUN") AndAlso requested.Contains("SH") Then candidates.Add("RD_SH")
        If requested.Contains("SUN") AndAlso requested.Contains("LH") Then candidates.Add("RD_LH")
        If requested.Contains("SH") Then candidates.Add("SH")
        If requested.Contains("LH") Then candidates.Add("LH")
        If requested.Contains("SUN") Then candidates.Add("SUN")
        candidates.Add("REG")

        For Each code In candidates.Distinct(StringComparer.OrdinalIgnoreCase)
            If policy.GetRule(code).Enabled Then Return code
        Next
        Return candidates(0)
    End Function

    Private Function OutputDayCodeForRateCode(rateCode As String) As String
        If String.Equals(rateCode, "RD_SH", StringComparison.OrdinalIgnoreCase) Then Return "SH"
        If String.Equals(rateCode, "RD_LH", StringComparison.OrdinalIgnoreCase) Then Return "LH"
        Return rateCode
    End Function

    Private Sub MoveDisabledHoursToFallback(
        hoursByCode As Dictionary(Of String, Decimal),
        policy As SubClientPayrollPolicy,
        sourceCode As String,
        fallbackCode As String
    )
        If policy.GetRule(sourceCode).Enabled OrElse Not policy.GetRule(fallbackCode).Enabled Then Return
        Dim sourceHours = hoursByCode(sourceCode)
        If sourceHours = 0D Then Return
        hoursByCode(fallbackCode) += sourceHours
        hoursByCode(sourceCode) = 0D
    End Sub

    Private Function LoadWorkSiteLookup() As Dictionary(Of String, WorkSiteRecord)
        Dim lookup As New Dictionary(Of String, WorkSiteRecord)(StringComparer.OrdinalIgnoreCase)
        Const sql As String =
            "SELECT S.[SUB_CLIENT_ID], S.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], S.[SUB_CLIENT_NAME], " &
            "S.[ADDRESS], S.[DAILY_WAGE], S.[SCHED_TYPE], S.[CONTACT_PERSON], S.[CONTACT_NUMBER], " &
            "S.[CONTACT_EMAIL], S.[SUB_CLIENT_STATUS] FROM [TBL_CLIENT_SUB] AS S INNER JOIN [TBL_CLIENT_MAIN] AS M " &
            "ON S.[MAIN_CLIENT_ID] = M.[MAIN_CLIENT_ID]"

        Using connection = CreateOpenConnection()
            Using command As New OleDbCommand(sql, connection)
                Using reader = command.ExecuteReader()
                    While reader.Read()
                        Dim site As New WorkSiteRecord With {
                            .Id = CInt(reader("SUB_CLIENT_ID")),
                            .CompanyId = CInt(reader("MAIN_CLIENT_ID")),
                            .CompanyName = SafeText(reader("MAIN_CLIENT_NAME"), String.Empty),
                            .Name = SafeText(reader("SUB_CLIENT_NAME"), String.Empty),
                            .Address = SafeText(reader("ADDRESS"), String.Empty),
                            .DailyWage = CInt(SafeDecimal(reader("DAILY_WAGE"), 0D)),
                            .ScheduleType = SafeText(reader("SCHED_TYPE"), String.Empty),
                            .ContactPerson = SafeText(reader("CONTACT_PERSON"), String.Empty),
                            .ContactNumber = SafeText(reader("CONTACT_NUMBER"), String.Empty),
                            .ContactEmail = SafeText(reader("CONTACT_EMAIL"), String.Empty),
                            .Status = SafeText(reader("SUB_CLIENT_STATUS"), String.Empty)
                        }
                        Dim key = NormalizeClientName(site.Name)
                        AddWorkSiteLookupEntry(lookup, key, site)

                        Dim addressWords = NormalizeClientName(site.Address).Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                        For Each word In addressWords.Where(Function(item) item.Length >= 3).Distinct().Take(6)
                            AddWorkSiteLookupEntry(lookup, key & " " & word, site)
                        Next
                        If addressWords.Length >= 2 Then
                            Dim initials = addressWords(0).Substring(0, 1) & addressWords(1).Substring(0, 1)
                            AddWorkSiteLookupEntry(lookup, key & " " & initials, site)
                        End If
                    End While
                End Using
            End Using
        End Using
        Return lookup
    End Function

    Private Sub AddWorkSiteLookupEntry(lookup As Dictionary(Of String, WorkSiteRecord), key As String, site As WorkSiteRecord)
        If String.IsNullOrWhiteSpace(key) Then Return
        Dim existing As WorkSiteRecord = Nothing
        If lookup.TryGetValue(key, existing) Then
            If existing IsNot Nothing AndAlso existing.Id <> site.Id Then lookup(key) = Nothing
            Return
        End If
        lookup.Add(key, site)
    End Sub

    Private Function ImportedMultiplier(code As String, formulaText As String, defaultValue As Decimal) As Decimal
        If String.IsNullOrWhiteSpace(formulaText) Then Return defaultValue
        If code.Equals("OT_REG", StringComparison.OrdinalIgnoreCase) AndAlso
           formulaText.IndexOf("1.25", StringComparison.OrdinalIgnoreCase) < 0 Then Return 0D
        Return defaultValue
    End Function

    Private Sub ConvertLegacyMultipliersToPremiums(
        policy As SubClientPayrollPolicy,
        loadedRateCodes As HashSet(Of String)
    )
        Dim legacyRates As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)
        For Each code In PayCodeOrder
            If loadedRateCodes.Contains(code) Then legacyRates(code) = policy.GetRule(code).Multiplier
        Next

        For Each dayCode In {"REG", "SUN", "LH", "SH"}
            If legacyRates.ContainsKey(dayCode) Then
                policy.GetRule(dayCode).Multiplier = Math.Max(0D, legacyRates(dayCode) - 1D)
            End If
        Next

        For Each dayCode In {"REG", "SUN", "LH", "SH"}
            Dim legacyDayRate = If(legacyRates.ContainsKey(dayCode), legacyRates(dayCode), 1D + policy.GetRule(dayCode).Multiplier)
            If legacyDayRate <= 0D Then legacyDayRate = 1D

            Dim ndCode = "ND_" & dayCode
            If legacyRates.ContainsKey(ndCode) Then
                policy.GetRule(ndCode).Multiplier = Math.Max(0D, legacyRates(ndCode) / legacyDayRate)
            End If

            Dim otCode = "OT_" & dayCode
            If legacyRates.ContainsKey(otCode) Then
                policy.GetRule(otCode).Multiplier = Math.Max(0D, legacyRates(otCode) / legacyDayRate - 1D)
            End If
        Next
    End Sub

    Private Function NormalizeClientName(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return String.Empty
        Dim normalized = value.Normalize(NormalizationForm.FormD)
        Dim builder As New StringBuilder()
        Dim pendingSpace As Boolean
        For Each ch In normalized
            Dim category = CharUnicodeInfo.GetUnicodeCategory(ch)
            If category = UnicodeCategory.NonSpacingMark OrElse category = UnicodeCategory.SpacingCombiningMark Then Continue For
            If Char.IsLetterOrDigit(ch) Then
                If pendingSpace AndAlso builder.Length > 0 Then builder.Append(" "c)
                builder.Append(Char.ToLowerInvariant(ch))
                pendingSpace = False
            Else
                pendingSpace = True
            End If
        Next
        Dim result = " " & builder.ToString().Trim() & " "
        result = result.Replace(" nutral ", " natural ")
        Return result.Trim()
    End Function

    Private Sub AddPolicyHeaderParameters(command As OleDbCommand, policy As SubClientPayrollPolicy, changedAt As Date, actor As String)
        AddDoubleParameter(command, policy.HoursPerDay)
        AddTextParameter(command, policy.DutyEntryMode, 24)
        AddDoubleParameter(command, policy.SingleShiftHours)
        AddBooleanParameter(command, policy.SingleShiftIsNight)
        AddTextParameter(command, policy.NightDifferentialMode, 24)
        AddDoubleParameter(command, policy.NightDifferentialFixedCutoffAmount)
        AddBooleanParameter(command, policy.IncentiveEnabled)
        AddDoubleParameter(command, policy.IncentiveDays)
        AddDoubleParameter(command, policy.IncentiveMonthDivisor)
        AddDoubleParameter(command, policy.IncentiveCutoffDivisor)
        AddLongTextParameter(command, If(policy.Notes, String.Empty))
        AddTextParameter(command, SubClientPayrollPolicy.PremiumRateSemantics, 32)
        AddDateParameter(command, changedAt)
        AddTextParameter(command, actor, 100)
    End Sub

    Private Function CreateOpenConnection() As OleDbConnection
        If String.IsNullOrWhiteSpace(GlobalVariables.GlobalConStr) Then MDB_Connection_Init()
        If String.IsNullOrWhiteSpace(GlobalVariables.GlobalConStr) Then
            Throw New InvalidOperationException("The database connection has not been initialized.")
        End If

        Dim connection As New OleDbConnection(GlobalVariables.GlobalConStr)
        Try
            connection.Open()
            Return connection
        Catch
            connection.Dispose()
            Throw
        End Try
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

    Private Sub ExecuteDdl(connection As OleDbConnection, sql As String)
        Using command As New OleDbCommand(sql, connection)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub AddIntegerParameter(command As OleDbCommand, value As Integer)
        command.Parameters.Add("?", OleDbType.Integer).Value = value
    End Sub

    Private Sub AddDoubleParameter(command As OleDbCommand, value As Decimal)
        command.Parameters.Add("?", OleDbType.Double).Value = CDbl(value)
    End Sub

    Private Sub AddBooleanParameter(command As OleDbCommand, value As Boolean)
        command.Parameters.Add("?", OleDbType.Boolean).Value = value
    End Sub

    Private Sub AddDateParameter(command As OleDbCommand, value As Date)
        command.Parameters.Add("?", OleDbType.Date).Value = value
    End Sub

    Private Sub AddTextParameter(command As OleDbCommand, value As String, length As Integer)
        Dim parameter = command.Parameters.Add("?", OleDbType.VarWChar, length)
        parameter.Value = If(value, String.Empty)
    End Sub

    Private Sub AddLongTextParameter(command As OleDbCommand, value As String)
        Dim parameter = command.Parameters.Add("?", OleDbType.LongVarWChar)
        parameter.Value = If(value, String.Empty)
    End Sub

    Private Function SafeText(value As Object, defaultValue As String) As String
        If value Is Nothing OrElse value Is DBNull.Value Then Return defaultValue
        Return Convert.ToString(value, CultureInfo.CurrentCulture).Trim()
    End Function

    Private Function SafeDecimal(value As Object, defaultValue As Decimal) As Decimal
        If value Is Nothing OrElse value Is DBNull.Value Then Return defaultValue
        Dim result As Decimal
        If Decimal.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, result) Then Return result
        If Decimal.TryParse(Convert.ToString(value, CultureInfo.CurrentCulture), result) Then Return result
        Return defaultValue
    End Function

    Private Function SafeBoolean(value As Object, defaultValue As Boolean) As Boolean
        If value Is Nothing OrElse value Is DBNull.Value Then Return defaultValue
        Return Convert.ToBoolean(value, CultureInfo.InvariantCulture)
    End Function
End Module
