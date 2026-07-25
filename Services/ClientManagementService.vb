Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Net.Mail
Imports System.Text
Imports System.Text.RegularExpressions

Public Class CompanyRecord
    Public Property Id As Integer
    Public Property Name As String
    Public Property ClientType As String
    Public Property Status As String
    Public Property WorkSiteCount As Integer
End Class

Public Class WorkSiteRecord
    Public Property Id As Integer
    Public Property CompanyId As Integer
    Public Property CompanyName As String
    Public Property Name As String
    Public Property Address As String
    Public Property DailyWage As Integer
    Public Property ScheduleType As String
    Public Property ContactPerson As String
    Public Property ContactNumber As String
    Public Property ContactEmail As String
    Public Property Status As String
End Class

Public Class ContractRecord
    Public Property Id As Integer
    Public Property WorkSiteId As Integer
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property Status As String
    Public Property Remarks As String
    Public Property FilePath As String
End Class

Public Class ContractMonitoringRecord
    Public Property ContractId As Integer
    Public Property WorkSiteId As Integer
    Public Property CompanyId As Integer
    Public Property CompanyName As String
    Public Property WorkSiteName As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property Status As String
    Public Property FilePath As String
End Class

Public Class ClientStatusHistoryRecord
    Public Property EffectiveDate As Date
    Public Property Status As String
    Public Property Reason As String
End Class

Public Class WorkSiteDraft
    Public Property Id As Integer
    Public Property CompanyId As Integer
    Public Property CompanyName As String
    Public Property Name As String
    Public Property Address As String
    Public Property DailyWage As Integer
    Public Property ScheduleType As String
    Public Property ContactPerson As String
    Public Property ContactNumber As String
    Public Property ContactEmail As String
    Public Property Status As String
End Class

Public Class ContractDraft
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property Remarks As String
    Public Property SourceFilePath As String
End Class

Public Class ClientOperationResult
    Public Property Success As Boolean
    Public Property Message As String
    Public Property RecordId As Integer
End Class

Public Class ClientNameAssessment
    Public Property IsValid As Boolean
    Public Property ErrorMessage As String
    Public Property WarningMessage As String
    Public Property SuggestedCompanyId As Integer
    Public Property SuggestedCompanyName As String
End Class

''' <summary>
''' Provides the data access and validation boundary for the client hierarchy.
''' Every operation uses its own OleDb connection; the application's tracked
''' GlobalCon connection is never opened, closed, or otherwise mutated here.
''' </summary>
Public Class ClientManagementService
    Private Const ActiveStatus As String = "Active"
    Private Const InactiveStatus As String = "Inactive"
    Private Const MaxTextLength As Integer = 255
    Private Const MaxContractBytes As Long = 10L * 1024L * 1024L
    Private Shared ReadOnly WorkSiteIdSyncRoot As New Object()

    Private Shared ReadOnly AllowedScheduleTypes As String() = {
        "2SHIFTS",
        "TRI_SHIFT",
        "TIME_SPECIFIC"
    }

    Private Shared ReadOnly LegalSuffixTokens As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "co", "company", "corp", "corporation", "inc", "incorporated",
        "limited", "ltd", "llc", "plc", "phils", "philippines"
    }

    Private Shared ReadOnly GenericSimilarityTokens As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "and", "the", "of", "for", "department", "bureau", "office",
        "national", "philippine", "philippines", "region", "regional"
    }

    Private Class ValidatedWorkSiteData
        Public CompanyId As Integer
        Public Name As String
        Public Address As String
        Public DailyWage As Integer
        Public ScheduleType As String
        Public ContactPerson As String
        Public ContactNumber As String
        Public ContactEmail As String
        Public RequestedStatus As String
    End Class

    Private Class ValidatedContractData
        Public StartDate As Date
        Public EndDate As Date
        Public Remarks As String
        Public SourceFilePath As String
    End Class

    Public Function GetCompanies(search As String, status As String) As List(Of CompanyRecord)
        Dim records As New List(Of CompanyRecord)()
        Dim sql As New StringBuilder()
        sql.Append("SELECT M.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], M.[CLIENT_TYPE], M.[GLOBAL_STATUS], ")
        sql.Append("COUNT(S.[SUB_CLIENT_ID]) AS [WORK_SITE_COUNT] ")
        sql.Append("FROM [TBL_CLIENT_MAIN] AS M LEFT JOIN [TBL_CLIENT_SUB] AS S ")
        sql.Append("ON M.[MAIN_CLIENT_ID] = S.[MAIN_CLIENT_ID]")

        Dim conditions As New List(Of String)()
        Dim cleanSearch As String = CleanDisplayName(search)
        Dim cleanStatus As String = CleanDisplayName(status)

        If Not String.IsNullOrWhiteSpace(cleanSearch) Then
            conditions.Add("InStr(1, M.[MAIN_CLIENT_NAME], ?, 1) > 0")
        End If
        If Not String.IsNullOrWhiteSpace(cleanStatus) AndAlso
           Not String.Equals(cleanStatus, "All", StringComparison.OrdinalIgnoreCase) Then
            conditions.Add("M.[GLOBAL_STATUS] = ?")
        End If

        If conditions.Count > 0 Then
            sql.Append(" WHERE ")
            sql.Append(String.Join(" AND ", conditions.ToArray()))
        End If

        sql.Append(" GROUP BY M.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], M.[CLIENT_TYPE], M.[GLOBAL_STATUS]")
        sql.Append(" ORDER BY M.[MAIN_CLIENT_NAME]")

        Using connection As OleDbConnection = CreateOpenConnection()
            Using command As New OleDbCommand(sql.ToString(), connection)
                If Not String.IsNullOrWhiteSpace(cleanSearch) Then
                    AddTextParameter(command, cleanSearch)
                End If
                If Not String.IsNullOrWhiteSpace(cleanStatus) AndAlso
                   Not String.Equals(cleanStatus, "All", StringComparison.OrdinalIgnoreCase) Then
                    AddTextParameter(command, CanonicalStatusForRead(cleanStatus))
                End If

                Using reader As OleDbDataReader = command.ExecuteReader()
                    While reader.Read()
                        records.Add(MapCompany(reader))
                    End While
                End Using
            End Using
        End Using

        Return records
    End Function

    Public Function GetCompany(id As Integer) As CompanyRecord
        If id <= 0 Then Return Nothing

        Const sql As String =
            "SELECT M.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], M.[CLIENT_TYPE], M.[GLOBAL_STATUS], " &
            "COUNT(S.[SUB_CLIENT_ID]) AS [WORK_SITE_COUNT] " &
            "FROM [TBL_CLIENT_MAIN] AS M LEFT JOIN [TBL_CLIENT_SUB] AS S " &
            "ON M.[MAIN_CLIENT_ID] = S.[MAIN_CLIENT_ID] " &
            "WHERE M.[MAIN_CLIENT_ID] = ? " &
            "GROUP BY M.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], M.[CLIENT_TYPE], M.[GLOBAL_STATUS]"

        Using connection As OleDbConnection = CreateOpenConnection()
            Using command As New OleDbCommand(sql, connection)
                AddIntegerParameter(command, id)
                Using reader As OleDbDataReader = command.ExecuteReader()
                    If reader.Read() Then Return MapCompany(reader)
                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function GetWorkSites(companyId As Integer) As List(Of WorkSiteRecord)
        Dim records As New List(Of WorkSiteRecord)()
        If companyId <= 0 Then Return records

        Const sql As String =
            "SELECT S.[SUB_CLIENT_ID], S.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], " &
            "S.[SUB_CLIENT_NAME], S.[ADDRESS], S.[DAILY_WAGE], S.[SCHED_TYPE], " &
            "S.[CONTACT_PERSON], S.[CONTACT_NUMBER], S.[CONTACT_EMAIL], S.[SUB_CLIENT_STATUS] " &
            "FROM [TBL_CLIENT_SUB] AS S INNER JOIN [TBL_CLIENT_MAIN] AS M " &
            "ON S.[MAIN_CLIENT_ID] = M.[MAIN_CLIENT_ID] " &
            "WHERE S.[MAIN_CLIENT_ID] = ? " &
            "ORDER BY S.[SUB_CLIENT_NAME], S.[ADDRESS]"

        Using connection As OleDbConnection = CreateOpenConnection()
            Using command As New OleDbCommand(sql, connection)
                AddIntegerParameter(command, companyId)
                Using reader As OleDbDataReader = command.ExecuteReader()
                    While reader.Read()
                        records.Add(MapWorkSite(reader))
                    End While
                End Using
            End Using
        End Using

        Return records
    End Function

    Public Function GetWorkSite(id As Integer) As WorkSiteRecord
        If id <= 0 Then Return Nothing

        Const sql As String =
            "SELECT S.[SUB_CLIENT_ID], S.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], " &
            "S.[SUB_CLIENT_NAME], S.[ADDRESS], S.[DAILY_WAGE], S.[SCHED_TYPE], " &
            "S.[CONTACT_PERSON], S.[CONTACT_NUMBER], S.[CONTACT_EMAIL], S.[SUB_CLIENT_STATUS] " &
            "FROM [TBL_CLIENT_SUB] AS S INNER JOIN [TBL_CLIENT_MAIN] AS M " &
            "ON S.[MAIN_CLIENT_ID] = M.[MAIN_CLIENT_ID] " &
            "WHERE S.[SUB_CLIENT_ID] = ?"

        Using connection As OleDbConnection = CreateOpenConnection()
            Using command As New OleDbCommand(sql, connection)
                AddIntegerParameter(command, id)
                Using reader As OleDbDataReader = command.ExecuteReader()
                    If reader.Read() Then Return MapWorkSite(reader)
                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function GetContracts(siteId As Integer) As List(Of ContractRecord)
        Dim records As New List(Of ContractRecord)()
        If siteId <= 0 Then Return records

        Const sql As String =
            "SELECT [ID], [SUB_CLIENT_ID], [START_CONTRACT_DATE], [END_CONTRACT_DATE], " &
            "[CONTRACT_STATUS], [REMARKS], [CONTRACT_PATH] " &
            "FROM [TBL_CLIENT_CONTRACT] WHERE [SUB_CLIENT_ID] = ? " &
            "ORDER BY [START_CONTRACT_DATE] DESC, [ID] DESC"

        Using connection As OleDbConnection = CreateOpenConnection()
            Using command As New OleDbCommand(sql, connection)
                AddIntegerParameter(command, siteId)
                Using reader As OleDbDataReader = command.ExecuteReader()
                    While reader.Read()
                        records.Add(MapContract(reader))
                    End While
                End Using
            End Using
        End Using

        Return records
    End Function

    Public Function GetContractMonitoring(filter As String) As List(Of ContractMonitoringRecord)
        Dim records As New List(Of ContractMonitoringRecord)()
        Const sql As String =
            "SELECT c.[ID], c.[SUB_CLIENT_ID], c.[START_CONTRACT_DATE], c.[END_CONTRACT_DATE], " &
            "c.[CONTRACT_STATUS], c.[CONTRACT_PATH], s.[MAIN_CLIENT_ID], s.[SUB_CLIENT_NAME], " &
            "m.[MAIN_CLIENT_NAME] FROM ([TBL_CLIENT_CONTRACT] AS c " &
            "INNER JOIN [TBL_CLIENT_SUB] AS s ON c.[SUB_CLIENT_ID] = s.[SUB_CLIENT_ID]) " &
            "INNER JOIN [TBL_CLIENT_MAIN] AS m ON s.[MAIN_CLIENT_ID] = m.[MAIN_CLIENT_ID] " &
            "ORDER BY c.[END_CONTRACT_DATE], m.[MAIN_CLIENT_NAME], s.[SUB_CLIENT_NAME]"

        Using connection As OleDbConnection = CreateOpenConnection()
            Using command As New OleDbCommand(sql, connection)
                Using reader As OleDbDataReader = command.ExecuteReader()
                    While reader.Read()
                        records.Add(New ContractMonitoringRecord With {
                            .ContractId = SafeInteger(reader("ID")),
                            .WorkSiteId = SafeInteger(reader("SUB_CLIENT_ID")),
                            .CompanyId = SafeInteger(reader("MAIN_CLIENT_ID")),
                            .CompanyName = SafeString(reader("MAIN_CLIENT_NAME")),
                            .WorkSiteName = SafeString(reader("SUB_CLIENT_NAME")),
                            .StartDate = SafeDate(reader("START_CONTRACT_DATE")),
                            .EndDate = SafeDate(reader("END_CONTRACT_DATE")),
                            .Status = SafeString(reader("CONTRACT_STATUS")),
                            .FilePath = SafeString(reader("CONTRACT_PATH"))
                        })
                    End While
                End Using
            End Using
        End Using

        Dim normalizedFilter As String = If(filter, String.Empty).Trim()
        Dim today As Date = Date.Today
        Select Case normalizedFilter
            Case "Expiring in 30 days"
                Return records.FindAll(Function(record) record.EndDate >= today AndAlso record.EndDate <= today.AddDays(30))
            Case "Expired"
                Return records.FindAll(Function(record) record.EndDate < today)
            Case "Missing attachment"
                Return records.FindAll(Function(record) String.IsNullOrWhiteSpace(record.FilePath) OrElse Not File.Exists(record.FilePath))
            Case Else
                Return records
        End Select
    End Function

    Public Function GetWorkSiteStatusHistory(siteId As Integer) As List(Of ClientStatusHistoryRecord)
        Dim records As New List(Of ClientStatusHistoryRecord)()
        If siteId <= 0 Then Return records

        Const sql As String =
            "SELECT [SUB_CLIENT_STATUS_CHANGE], [EFFECTIVITY_DATE], [REASON] " &
            "FROM [TBL_CLIENT_STATUS_HISTORY] WHERE [SUB_CLIENT_ID] = ? " &
            "ORDER BY [EFFECTIVITY_DATE] DESC"
        Using connection As OleDbConnection = CreateOpenConnection()
            Using command As New OleDbCommand(sql, connection)
                AddIntegerParameter(command, siteId)
                Using reader As OleDbDataReader = command.ExecuteReader()
                    While reader.Read()
                        records.Add(New ClientStatusHistoryRecord With {
                            .EffectiveDate = SafeDate(reader("EFFECTIVITY_DATE")),
                            .Status = SafeString(reader("SUB_CLIENT_STATUS_CHANGE")),
                            .Reason = SafeString(reader("REASON"))
                        })
                    End While
                End Using
            End Using
        End Using
        Return records
    End Function

    Public Function AssessCompanyName(name As String,
                                      Optional excludeId As Integer? = Nothing) As ClientNameAssessment
        Dim assessment As New ClientNameAssessment With {
            .IsValid = False,
            .ErrorMessage = String.Empty,
            .WarningMessage = String.Empty,
            .SuggestedCompanyId = 0,
            .SuggestedCompanyName = String.Empty
        }

        Dim rawName As String = CleanDisplayName(name)
        Dim syntaxError As String = ValidateCompanyNameSyntax(rawName)
        If Not String.IsNullOrEmpty(syntaxError) Then
            assessment.ErrorMessage = syntaxError
            Return assessment
        End If
        Dim cleanName As String = NormalizeClientNameInput(rawName)

        Dim candidateKey As String = ComparisonKey(cleanName)

        Try
            Using connection As OleDbConnection = CreateOpenConnection()
                Dim companies As List(Of CompanyRecord) = ReadAllCompaniesForAssessment(connection)

                For Each company As CompanyRecord In companies
                    If Not IsExcludedCompany(company.Id, excludeId) AndAlso
                       String.Equals(candidateKey, ComparisonKey(company.Name), StringComparison.Ordinal) Then
                        assessment.ErrorMessage =
                            "A company named '" & company.Name & "' already exists. Select the existing company instead of creating another one."
                        assessment.SuggestedCompanyId = company.Id
                        assessment.SuggestedCompanyName = company.Name
                        Return assessment
                    End If
                Next

                Dim siteSuggestion As CompanyRecord = FindMatchingWorkSiteParent(
                    connection, candidateKey, excludeId)
                If siteSuggestion IsNot Nothing Then
                    assessment.IsValid = True
                    assessment.WarningMessage =
                        "Strong warning: this name already belongs to a work site under '" &
                        siteSuggestion.Name & "'. Add or select the work site under that company unless this is a genuinely different legal client."
                    assessment.SuggestedCompanyId = siteSuggestion.Id
                    assessment.SuggestedCompanyName = siteSuggestion.Name
                    Return assessment
                End If

                Dim bestCompany As CompanyRecord = Nothing
                Dim bestScore As Integer = 0
                For Each company As CompanyRecord In companies
                    If Not IsExcludedCompany(company.Id, excludeId) Then
                        Dim score As Integer = CompanyExtensionScore(candidateKey, ComparisonKey(company.Name))
                        If score > bestScore OrElse
                           (score = bestScore AndAlso bestCompany IsNot Nothing AndAlso
                            IsActive(company.Status) AndAlso Not IsActive(bestCompany.Status)) Then
                            bestScore = score
                            bestCompany = company
                        End If
                    End If
                Next

                assessment.IsValid = True
                If bestCompany IsNot Nothing AndAlso bestScore > 0 Then
                    assessment.WarningMessage =
                        "Strong warning: this looks like a branch, site, or naming variation of '" &
                        bestCompany.Name & "'. Use that existing company as the parent unless this is a different legal client."
                    assessment.SuggestedCompanyId = bestCompany.Id
                    assessment.SuggestedCompanyName = bestCompany.Name
                End If
            End Using
        Catch ex As Exception
            assessment.ErrorMessage = "The company name could not be checked against existing records: " & ex.Message
            Return assessment
        End Try

        Return assessment
    End Function

    Public Function CreateCompany(name As String, type As String) As ClientOperationResult
        Dim rawName As String = CleanDisplayName(name)
        Dim nameError As String = ValidateCompanyNameSyntax(rawName)
        If Not String.IsNullOrEmpty(nameError) Then Return Failure(nameError)
        Dim cleanName As String = NormalizeClientNameInput(rawName)

        Dim cleanType As String = Nothing
        Dim typeError As String = Nothing
        If Not TryNormalizeCompanyType(type, cleanType, typeError) Then Return Failure(typeError)

        Dim assessment As ClientNameAssessment = AssessCompanyName(cleanName)
        If Not assessment.IsValid Then Return Failure(assessment.ErrorMessage)

        Try
            Using connection As OleDbConnection = CreateOpenConnection()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        Dim duplicateId As Integer = 0
                        Dim duplicateName As String = Nothing
                        If FindExactCompanyDuplicate(connection, transaction, cleanName, Nothing,
                                                     duplicateId, duplicateName) Then
                            transaction.Rollback()
                            Return Failure("A company named '" & duplicateName &
                                           "' already exists. Select the existing company instead.", duplicateId)
                        End If

                        Const insertSql As String =
                            "INSERT INTO [TBL_CLIENT_MAIN] " &
                            "([MAIN_CLIENT_NAME], [CLIENT_TYPE], [GLOBAL_STATUS]) VALUES (?, ?, ?)"
                        Using command As New OleDbCommand(insertSql, connection, transaction)
                            AddTextParameter(command, cleanName)
                            AddTextParameter(command, cleanType)
                            AddTextParameter(command, ActiveStatus)
                            command.ExecuteNonQuery()
                        End Using

                        Dim newId As Integer = ReadIdentity(connection, transaction)
                        transaction.Commit()

                        Dim message As String = "Company created successfully."
                        If Not String.IsNullOrWhiteSpace(assessment.WarningMessage) Then
                            message &= " " & assessment.WarningMessage
                        End If
                        Return Succeeded(message, newId)
                    Catch
                        RollbackQuietly(transaction)
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return Failure("The company could not be created: " & ex.Message)
        End Try
    End Function

    Public Function UpdateCompany(id As Integer, name As String, type As String) As ClientOperationResult
        If id <= 0 Then Return Failure("Select a valid company to update.")

        Dim rawName As String = CleanDisplayName(name)
        Dim nameError As String = ValidateCompanyNameSyntax(rawName)
        If Not String.IsNullOrEmpty(nameError) Then Return Failure(nameError, id)
        Dim cleanName As String = NormalizeClientNameInput(rawName)

        Dim cleanType As String = Nothing
        Dim typeError As String = Nothing
        If Not TryNormalizeCompanyType(type, cleanType, typeError) Then Return Failure(typeError, id)

        Dim assessment As ClientNameAssessment = AssessCompanyName(cleanName, id)
        If Not assessment.IsValid Then Return Failure(assessment.ErrorMessage, id)

        Try
            Using connection As OleDbConnection = CreateOpenConnection()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        If Not CompanyExists(connection, transaction, id) Then
                            transaction.Rollback()
                            Return Failure("The selected company no longer exists.", id)
                        End If

                        Dim duplicateId As Integer = 0
                        Dim duplicateName As String = Nothing
                        If FindExactCompanyDuplicate(connection, transaction, cleanName, id,
                                                     duplicateId, duplicateName) Then
                            transaction.Rollback()
                            Return Failure("A company named '" & duplicateName &
                                           "' already exists. Select the existing company instead.", duplicateId)
                        End If

                        Const updateSql As String =
                            "UPDATE [TBL_CLIENT_MAIN] SET [MAIN_CLIENT_NAME] = ?, [CLIENT_TYPE] = ? " &
                            "WHERE [MAIN_CLIENT_ID] = ?"
                        Using command As New OleDbCommand(updateSql, connection, transaction)
                            AddTextParameter(command, cleanName)
                            AddTextParameter(command, cleanType)
                            AddIntegerParameter(command, id)
                            If command.ExecuteNonQuery() <> 1 Then
                                Throw New InvalidOperationException("The company record was not updated.")
                            End If
                        End Using

                        transaction.Commit()
                        Dim message As String = "Company updated successfully."
                        If Not String.IsNullOrWhiteSpace(assessment.WarningMessage) Then
                            message &= " " & assessment.WarningMessage
                        End If
                        Return Succeeded(message, id)
                    Catch
                        RollbackQuietly(transaction)
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return Failure("The company could not be updated: " & ex.Message, id)
        End Try
    End Function

    Public Function CreateWorkSite(draft As WorkSiteDraft,
                                   initialContract As ContractDraft) As ClientOperationResult
        Dim siteData As ValidatedWorkSiteData = Nothing
        Dim siteError As String = Nothing
        If Not TryValidateWorkSite(draft, True, siteData, siteError) Then Return Failure(siteError)

        Dim contractData As ValidatedContractData = Nothing
        Dim contractError As String = Nothing
        If Not TryValidateContract(initialContract, True, contractData, contractError) Then
            Return Failure("An initial contract is required. " & contractError)
        End If

        Dim copiedPath As String = Nothing
        Try
            EnsureContractDirectory()

            ' SUB_CLIENT_ID is a legacy manually assigned value. Serialize generation
            ' and insertion inside this process in addition to using the DB transaction.
            SyncLock WorkSiteIdSyncRoot
                Using connection As OleDbConnection = CreateOpenConnection()
                    Using transaction As OleDbTransaction = connection.BeginTransaction()
                        Try
                        Dim parentName As String = Nothing
                        Dim parentError As String = VerifyActiveParent(
                            connection, transaction, siteData.CompanyId, parentName)
                        If Not String.IsNullOrEmpty(parentError) Then
                            transaction.Rollback()
                            Return Failure(parentError)
                        End If

                        Dim duplicateId As Integer = 0
                        Dim warning As String = Nothing
                        Dim hasExactDuplicate As Boolean = FindWorkSiteConflict(
                            connection, transaction, siteData.CompanyId,
                            ComparisonKey(siteData.Name), ComparisonKey(siteData.Address),
                            Nothing, duplicateId, warning)
                        If hasExactDuplicate Then
                            transaction.Rollback()
                            Return Failure(
                                "That work-site name and address already exist under '" & parentName & "'.",
                                duplicateId)
                        End If

                        Dim newSiteId As Integer = GenerateNextWorkSiteId(connection, transaction)

                        Const insertSiteSql As String =
                            "INSERT INTO [TBL_CLIENT_SUB] " &
                            "([SUB_CLIENT_ID], [MAIN_CLIENT_ID], [SUB_CLIENT_NAME], [ADDRESS], " &
                            "[DAILY_WAGE], [SUB_CLIENT_STATUS], [SCHED_TYPE], [CONTACT_PERSON], " &
                            "[CONTACT_NUMBER], [CONTACT_EMAIL]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
                        Using command As New OleDbCommand(insertSiteSql, connection, transaction)
                            AddIntegerParameter(command, newSiteId)
                            AddIntegerParameter(command, siteData.CompanyId)
                            AddTextParameter(command, siteData.Name)
                            AddTextParameter(command, siteData.Address)
                            AddIntegerParameter(command, siteData.DailyWage)
                            AddTextParameter(command, siteData.RequestedStatus)
                            AddTextParameter(command, siteData.ScheduleType)
                            AddTextParameter(command, siteData.ContactPerson)
                            AddTextParameter(command, siteData.ContactNumber)
                            AddTextParameter(command, siteData.ContactEmail)
                            command.ExecuteNonQuery()
                        End Using

                        copiedPath = BuildContractDestinationPath(newSiteId, contractData.SourceFilePath)
                        CopyValidatedContractFile(contractData.SourceFilePath, copiedPath)

                        InsertContract(connection, transaction, newSiteId, contractData, copiedPath)
                        transaction.Commit()

                        Dim message As String = "Work site and initial contract created successfully."
                        If Not String.IsNullOrWhiteSpace(warning) Then message &= " " & warning
                        Return Succeeded(message, newSiteId)
                        Catch
                            RollbackQuietly(transaction)
                            Throw
                        End Try
                    End Using
                End Using
            End SyncLock
        Catch ex As Exception
            DeleteFileQuietly(copiedPath)
            Return Failure("The work site could not be created: " & ex.Message)
        End Try
    End Function

    Public Function UpdateWorkSite(draft As WorkSiteDraft) As ClientOperationResult
        If draft Is Nothing OrElse draft.Id <= 0 Then
            Return Failure("Select a valid work site to update.")
        End If

        Dim siteData As ValidatedWorkSiteData = Nothing
        Dim validationError As String = Nothing
        If Not TryValidateWorkSite(draft, False, siteData, validationError) Then
            Return Failure(validationError, draft.Id)
        End If

        Try
            Using connection As OleDbConnection = CreateOpenConnection()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        Dim currentStatus As String = ReadWorkSiteStatus(
                            connection, transaction, draft.Id)
                        If currentStatus Is Nothing Then
                            transaction.Rollback()
                            Return Failure("The selected work site no longer exists.", draft.Id)
                        End If

                        Dim parentName As String = Nothing
                        Dim parentError As String = VerifyActiveParent(
                            connection, transaction, siteData.CompanyId, parentName)
                        If Not String.IsNullOrEmpty(parentError) Then
                            transaction.Rollback()
                            Return Failure(parentError, draft.Id)
                        End If

                        Dim duplicateId As Integer = 0
                        Dim warning As String = Nothing
                        Dim hasExactDuplicate As Boolean = FindWorkSiteConflict(
                            connection, transaction, siteData.CompanyId,
                            ComparisonKey(siteData.Name), ComparisonKey(siteData.Address),
                            draft.Id, duplicateId, warning)
                        If hasExactDuplicate Then
                            transaction.Rollback()
                            Return Failure(
                                "That work-site name and address already exist under '" & parentName & "'.",
                                duplicateId)
                        End If

                        Dim finalStatus As String = If(
                            String.IsNullOrEmpty(siteData.RequestedStatus), currentStatus,
                            siteData.RequestedStatus)

                        Const updateSql As String =
                            "UPDATE [TBL_CLIENT_SUB] SET [MAIN_CLIENT_ID] = ?, [SUB_CLIENT_NAME] = ?, " &
                            "[ADDRESS] = ?, [DAILY_WAGE] = ?, [SCHED_TYPE] = ?, [CONTACT_PERSON] = ?, " &
                            "[CONTACT_NUMBER] = ?, [CONTACT_EMAIL] = ?, [SUB_CLIENT_STATUS] = ? " &
                            "WHERE [SUB_CLIENT_ID] = ?"
                        Using command As New OleDbCommand(updateSql, connection, transaction)
                            AddIntegerParameter(command, siteData.CompanyId)
                            AddTextParameter(command, siteData.Name)
                            AddTextParameter(command, siteData.Address)
                            AddIntegerParameter(command, siteData.DailyWage)
                            AddTextParameter(command, siteData.ScheduleType)
                            AddTextParameter(command, siteData.ContactPerson)
                            AddTextParameter(command, siteData.ContactNumber)
                            AddTextParameter(command, siteData.ContactEmail)
                            AddTextParameter(command, finalStatus)
                            AddIntegerParameter(command, draft.Id)
                            If command.ExecuteNonQuery() <> 1 Then
                                Throw New InvalidOperationException("The work-site record was not updated.")
                            End If
                        End Using

                        transaction.Commit()
                        Dim message As String = "Work site updated successfully."
                        If Not String.IsNullOrWhiteSpace(warning) Then message &= " " & warning
                        Return Succeeded(message, draft.Id)
                    Catch
                        RollbackQuietly(transaction)
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return Failure("The work site could not be updated: " & ex.Message, draft.Id)
        End Try
    End Function

    Public Function CreateContract(siteId As Integer, draft As ContractDraft) As ClientOperationResult
        If siteId <= 0 Then Return Failure("Select a valid work site for the contract.")

        Dim contractData As ValidatedContractData = Nothing
        Dim validationError As String = Nothing
        If Not TryValidateContract(draft, True, contractData, validationError) Then
            Return Failure(validationError)
        End If

        Dim copiedPath As String = Nothing
        Try
            EnsureContractDirectory()

            Using connection As OleDbConnection = CreateOpenConnection()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        Dim siteError As String = VerifySiteAndActiveParent(
                            connection, transaction, siteId)
                        If Not String.IsNullOrEmpty(siteError) Then
                            transaction.Rollback()
                            Return Failure(siteError)
                        End If

                        copiedPath = BuildContractDestinationPath(siteId, contractData.SourceFilePath)
                        CopyValidatedContractFile(contractData.SourceFilePath, copiedPath)

                        Dim newId As Integer = InsertContract(
                            connection, transaction, siteId, contractData, copiedPath)
                        transaction.Commit()
                        Return Succeeded("Contract created successfully.", newId)
                    Catch
                        RollbackQuietly(transaction)
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            DeleteFileQuietly(copiedPath)
            Return Failure("The contract could not be created: " & ex.Message)
        End Try
    End Function

    Public Function UpdateContract(contractId As Integer,
                                   draft As ContractDraft) As ClientOperationResult
        If contractId <= 0 Then Return Failure("Select a valid contract to update.")

        Dim hasReplacement As Boolean =
            draft IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(draft.SourceFilePath)
        Dim contractData As ValidatedContractData = Nothing
        Dim validationError As String = Nothing
        If Not TryValidateContract(draft, hasReplacement, contractData, validationError) Then
            Return Failure(validationError, contractId)
        End If

        Dim copiedPath As String = Nothing
        Dim oldPath As String = Nothing

        Try
            If hasReplacement Then EnsureContractDirectory()

            Using connection As OleDbConnection = CreateOpenConnection()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        Dim siteId As Integer = 0
                        If Not ReadContractLocation(connection, transaction, contractId, siteId, oldPath) Then
                            transaction.Rollback()
                            Return Failure("The selected contract no longer exists.", contractId)
                        End If

                        If hasReplacement Then
                            copiedPath = BuildContractDestinationPath(siteId, contractData.SourceFilePath)
                            CopyValidatedContractFile(contractData.SourceFilePath, copiedPath)
                        End If

                        Dim updateSql As String
                        If hasReplacement Then
                            updateSql =
                                "UPDATE [TBL_CLIENT_CONTRACT] SET [START_CONTRACT_DATE] = ?, " &
                                "[END_CONTRACT_DATE] = ?, [REMARKS] = ?, [CONTRACT_PATH] = ? WHERE [ID] = ?"
                        Else
                            updateSql =
                                "UPDATE [TBL_CLIENT_CONTRACT] SET [START_CONTRACT_DATE] = ?, " &
                                "[END_CONTRACT_DATE] = ?, [REMARKS] = ? WHERE [ID] = ?"
                        End If

                        Using command As New OleDbCommand(updateSql, connection, transaction)
                            AddDateParameter(command, contractData.StartDate)
                            AddDateParameter(command, contractData.EndDate)
                            AddTextParameter(command, contractData.Remarks)
                            If hasReplacement Then AddTextParameter(command, copiedPath)
                            AddIntegerParameter(command, contractId)
                            If command.ExecuteNonQuery() <> 1 Then
                                Throw New InvalidOperationException("The contract record was not updated.")
                            End If
                        End Using

                        transaction.Commit()
                    Catch
                        RollbackQuietly(transaction)
                        Throw
                    End Try
                End Using
            End Using

            Dim message As String = "Contract updated successfully."
            If hasReplacement Then
                Dim cleanupWarning As String = DeleteManagedAttachmentIfUnreferenced(oldPath)
                If Not String.IsNullOrWhiteSpace(cleanupWarning) Then
                    message &= " " & cleanupWarning
                End If
            End If
            Return Succeeded(message, contractId)
        Catch ex As Exception
            DeleteFileQuietly(copiedPath)
            Return Failure("The contract could not be updated: " & ex.Message, contractId)
        End Try
    End Function

    Public Function DeleteContract(contractId As Integer) As ClientOperationResult
        If contractId <= 0 Then Return Failure("Select a valid contract to delete.")

        Dim oldPath As String = Nothing
        Try
            Using connection As OleDbConnection = CreateOpenConnection()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        Dim siteId As Integer = 0
                        If Not ReadContractLocation(connection, transaction, contractId, siteId, oldPath) Then
                            transaction.Rollback()
                            Return Failure("The selected contract no longer exists.", contractId)
                        End If

                        Const deleteSql As String =
                            "DELETE FROM [TBL_CLIENT_CONTRACT] WHERE [ID] = ?"
                        Using command As New OleDbCommand(deleteSql, connection, transaction)
                            AddIntegerParameter(command, contractId)
                            If command.ExecuteNonQuery() <> 1 Then
                                Throw New InvalidOperationException("The contract record was not deleted.")
                            End If
                        End Using
                        transaction.Commit()
                    Catch
                        RollbackQuietly(transaction)
                        Throw
                    End Try
                End Using
            End Using

            Dim message As String = "Contract deleted successfully."
            Dim cleanupWarning As String = DeleteManagedAttachmentIfUnreferenced(oldPath)
            If Not String.IsNullOrWhiteSpace(cleanupWarning) Then message &= " " & cleanupWarning
            Return Succeeded(message, contractId)
        Catch ex As Exception
            Return Failure("The contract could not be deleted: " & ex.Message, contractId)
        End Try
    End Function

    Public Function SetCompanyStatus(id As Integer, status As String) As ClientOperationResult
        If id <= 0 Then Return Failure("Select a valid company.")

        Dim canonicalStatus As String = Nothing
        If Not TryNormalizeStatus(status, canonicalStatus) Then
            Return Failure("Company status must be Active or Inactive.", id)
        End If

        Try
            Using connection As OleDbConnection = CreateOpenConnection()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        If Not CompanyExists(connection, transaction, id) Then
                            transaction.Rollback()
                            Return Failure("The selected company no longer exists.", id)
                        End If

                        If String.Equals(canonicalStatus, InactiveStatus, StringComparison.Ordinal) Then
                            Const countSql As String =
                                "SELECT COUNT(*) FROM [TBL_CLIENT_SUB] " &
                                "WHERE [MAIN_CLIENT_ID] = ? AND [SUB_CLIENT_STATUS] = ?"
                            Using countCommand As New OleDbCommand(countSql, connection, transaction)
                                AddIntegerParameter(countCommand, id)
                                AddTextParameter(countCommand, ActiveStatus)
                                Dim activeSiteCount As Integer = SafeInteger(countCommand.ExecuteScalar())
                                If activeSiteCount > 0 Then
                                    transaction.Rollback()
                                    Return Failure(
                                        "Deactivate this company's active work sites before deactivating the company.", id)
                                End If
                            End Using
                        End If

                        Const updateSql As String =
                            "UPDATE [TBL_CLIENT_MAIN] SET [GLOBAL_STATUS] = ? WHERE [MAIN_CLIENT_ID] = ?"
                        Using command As New OleDbCommand(updateSql, connection, transaction)
                            AddTextParameter(command, canonicalStatus)
                            AddIntegerParameter(command, id)
                            If command.ExecuteNonQuery() <> 1 Then
                                Throw New InvalidOperationException("The company status was not updated.")
                            End If
                        End Using
                        transaction.Commit()
                        Return Succeeded("Company status changed to " & canonicalStatus & ".", id)
                    Catch
                        RollbackQuietly(transaction)
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return Failure("The company status could not be changed: " & ex.Message, id)
        End Try
    End Function

    Public Function SetWorkSiteStatus(id As Integer, status As String) As ClientOperationResult
        If id <= 0 Then Return Failure("Select a valid work site.")

        Dim canonicalStatus As String = Nothing
        If Not TryNormalizeStatus(status, canonicalStatus) Then
            Return Failure("Work-site status must be Active or Inactive.", id)
        End If

        Try
            Using connection As OleDbConnection = CreateOpenConnection()
                Using transaction As OleDbTransaction = connection.BeginTransaction()
                    Try
                        Dim exists As Boolean = False
                        Dim parentStatus As String = ReadWorkSiteParentStatus(
                            connection, transaction, id, exists)
                        If Not exists Then
                            transaction.Rollback()
                            Return Failure("The selected work site no longer exists.", id)
                        End If

                        If String.Equals(canonicalStatus, ActiveStatus, StringComparison.Ordinal) AndAlso
                           Not IsActive(parentStatus) Then
                            transaction.Rollback()
                            Return Failure("Reactivate the parent company before activating this work site.", id)
                        End If

                        Const updateSql As String =
                            "UPDATE [TBL_CLIENT_SUB] SET [SUB_CLIENT_STATUS] = ? WHERE [SUB_CLIENT_ID] = ?"
                        Using command As New OleDbCommand(updateSql, connection, transaction)
                            AddTextParameter(command, canonicalStatus)
                            AddIntegerParameter(command, id)
                            If command.ExecuteNonQuery() <> 1 Then
                                Throw New InvalidOperationException("The work-site status was not updated.")
                            End If
                        End Using

                        Dim historyReason As String = CleanDisplayName(
                            GlobalVariables.sReason_for_Deactivation_Activation)
                        Dim historyDate As Date = GlobalVariables.dClient_Deactivation_Date
                        If Not String.IsNullOrWhiteSpace(historyReason) AndAlso
                           historyDate <> Date.MinValue Then
                            If historyReason.Length > MaxTextLength Then
                                transaction.Rollback()
                                Return Failure("The status-change reason cannot exceed " &
                                               MaxTextLength.ToString(CultureInfo.InvariantCulture) &
                                               " characters.", id)
                            End If

                            Const historySql As String =
                                "INSERT INTO [TBL_CLIENT_STATUS_HISTORY] " &
                                "([SUB_CLIENT_ID], [SUB_CLIENT_STATUS_CHANGE], [EFFECTIVITY_DATE], [REASON]) " &
                                "VALUES (?, ?, ?, ?)"
                            Using historyCommand As New OleDbCommand(historySql, connection, transaction)
                                AddIntegerParameter(historyCommand, id)
                                AddTextParameter(historyCommand, canonicalStatus)
                                AddDateParameter(historyCommand, historyDate)
                                AddTextParameter(historyCommand, historyReason)
                                historyCommand.ExecuteNonQuery()
                            End Using
                        End If

                        transaction.Commit()
                        Return Succeeded("Work-site status changed to " & canonicalStatus & ".", id)
                    Catch
                        RollbackQuietly(transaction)
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return Failure("The work-site status could not be changed: " & ex.Message, id)
        End Try
    End Function

    ''' <summary>
    ''' Cleans text for display/storage while retaining meaningful punctuation.
    ''' Unicode compatibility forms, controls, and repeated whitespace are normalized.
    ''' </summary>
    Public Shared Function CleanDisplayName(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return String.Empty

        Dim normalized As String = value.Normalize(NormalizationForm.FormKC)
        Dim builder As New StringBuilder(normalized.Length)

        For Each ch As Char In normalized
            If Char.IsControl(ch) OrElse Char.IsWhiteSpace(ch) Then
                builder.Append(" "c)
            Else
                Select Case AscW(ch)
                    Case &H2010, &H2011, &H2012, &H2013, &H2014, &H2212
                        builder.Append("-"c)
                    Case &H2018, &H2019, &H201B
                        builder.Append("'"c)
                    Case &H201C, &H201D, &H201F
                        builder.Append(ChrW(34))
                    Case Else
                        builder.Append(ch)
                End Select
            End If
        Next

        Return Regex.Replace(builder.ToString(), "\s+", " ").Trim()
    End Function

    ''' <summary>
    ''' Formats company and work-site names consistently. Letters, numbers and
    ''' common legal-name punctuation are retained; unsupported symbols are removed.
    ''' Existing acronyms typed in uppercase are preserved.
    ''' </summary>
    Public Shared Function NormalizeClientNameInput(
        value As String,
        Optional preserveTrailingSpace As Boolean = False) As String

        If String.IsNullOrEmpty(value) Then Return String.Empty

        Dim normalized As String = value.Normalize(NormalizationForm.FormKC)
        Dim builder As New StringBuilder(normalized.Length)
        Dim lastWasSpace As Boolean = False

        For Each ch As Char In normalized
            If Char.IsWhiteSpace(ch) OrElse Char.IsControl(ch) Then
                If builder.Length > 0 AndAlso Not lastWasSpace Then
                    builder.Append(" "c)
                    lastWasSpace = True
                End If
            ElseIf IsAllowedClientNameCharacter(ch) Then
                builder.Append(ch)
                lastWasSpace = False
            End If
        Next

        Dim filtered As String = builder.ToString().Trim()
        If filtered.Length = 0 Then Return String.Empty

        Dim culture As CultureInfo = CultureInfo.CurrentCulture
        Dim titled As String = Regex.Replace(
            filtered,
            "\p{L}+",
            Function(match As Match)
                Dim token As String = match.Value
                If token.Length > 1 AndAlso
                   String.Equals(token, token.ToUpper(culture), StringComparison.CurrentCulture) Then
                    Return token
                End If
                Return culture.TextInfo.ToTitleCase(token.ToLower(culture))
            End Function)

        If preserveTrailingSpace AndAlso
           Char.IsWhiteSpace(normalized(normalized.Length - 1)) Then
            titled &= " "
        End If
        Return titled
    End Function

    Public Shared Function IsAllowedClientNameCharacter(ch As Char) As Boolean
        If Char.IsLetterOrDigit(ch) OrElse Char.IsWhiteSpace(ch) Then Return True
        Select Case ch
            Case "&"c, "'"c, "-"c, "."c, ","c, "("c, ")"c
                Return True
            Case Else
                Return False
        End Select
    End Function

    ''' <summary>
    ''' Produces a culture-invariant comparison key. Accents, punctuation,
    ''' symbols, casing, and repeated separators do not create false differences.
    ''' </summary>
    Public Shared Function ComparisonKey(value As String) As String
        Dim display As String = CleanDisplayName(value)
        If display.Length = 0 Then Return String.Empty

        Dim decomposed As String = display.Normalize(NormalizationForm.FormD)
        Dim builder As New StringBuilder(decomposed.Length)
        Dim pendingSeparator As Boolean = False

        For Each ch As Char In decomposed
            Dim category As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ch)
            If category = UnicodeCategory.NonSpacingMark OrElse
               category = UnicodeCategory.SpacingCombiningMark OrElse
               category = UnicodeCategory.EnclosingMark Then
                Continue For
            End If

            If Char.IsLetterOrDigit(ch) Then
                If pendingSeparator AndAlso builder.Length > 0 Then builder.Append(" "c)
                builder.Append(Char.ToLowerInvariant(ch))
                pendingSeparator = False
            Else
                pendingSeparator = True
            End If
        Next

        Return builder.ToString().Trim()
    End Function

    Private Shared Function CreateOpenConnection() As OleDbConnection
        If String.IsNullOrWhiteSpace(GlobalVariables.GlobalConStr) Then
            MDB_Connection_Init()
        End If

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

    Private Shared Function MapCompany(reader As OleDbDataReader) As CompanyRecord
        Return New CompanyRecord With {
            .Id = SafeInteger(reader("MAIN_CLIENT_ID")),
            .Name = SafeString(reader("MAIN_CLIENT_NAME")),
            .ClientType = SafeString(reader("CLIENT_TYPE")),
            .Status = SafeString(reader("GLOBAL_STATUS")),
            .WorkSiteCount = SafeInteger(reader("WORK_SITE_COUNT"))
        }
    End Function

    Private Shared Function MapWorkSite(reader As OleDbDataReader) As WorkSiteRecord
        Return New WorkSiteRecord With {
            .Id = SafeInteger(reader("SUB_CLIENT_ID")),
            .CompanyId = SafeInteger(reader("MAIN_CLIENT_ID")),
            .CompanyName = SafeString(reader("MAIN_CLIENT_NAME")),
            .Name = SafeString(reader("SUB_CLIENT_NAME")),
            .Address = SafeString(reader("ADDRESS")),
            .DailyWage = SafeInteger(reader("DAILY_WAGE")),
            .ScheduleType = SafeString(reader("SCHED_TYPE")),
            .ContactPerson = SafeString(reader("CONTACT_PERSON")),
            .ContactNumber = SafeString(reader("CONTACT_NUMBER")),
            .ContactEmail = SafeString(reader("CONTACT_EMAIL")),
            .Status = SafeString(reader("SUB_CLIENT_STATUS"))
        }
    End Function

    Private Shared Function MapContract(reader As OleDbDataReader) As ContractRecord
        Return New ContractRecord With {
            .Id = SafeInteger(reader("ID")),
            .WorkSiteId = SafeInteger(reader("SUB_CLIENT_ID")),
            .StartDate = SafeDate(reader("START_CONTRACT_DATE")),
            .EndDate = SafeDate(reader("END_CONTRACT_DATE")),
            .Status = SafeString(reader("CONTRACT_STATUS")),
            .Remarks = SafeString(reader("REMARKS")),
            .FilePath = SafeString(reader("CONTRACT_PATH"))
        }
    End Function

    Private Shared Function SafeString(value As Object) As String
        If value Is Nothing OrElse value Is DBNull.Value Then Return String.Empty
        Return Convert.ToString(value, CultureInfo.CurrentCulture)
    End Function

    Private Shared Function SafeInteger(value As Object) As Integer
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0
        Return Convert.ToInt32(value, CultureInfo.InvariantCulture)
    End Function

    Private Shared Function SafeDate(value As Object) As Date
        If value Is Nothing OrElse value Is DBNull.Value Then Return Date.MinValue
        Return Convert.ToDateTime(value, CultureInfo.CurrentCulture)
    End Function

    Private Shared Sub AddTextParameter(command As OleDbCommand, value As String)
        Dim parameter As OleDbParameter = command.Parameters.Add("?", OleDbType.VarWChar, MaxTextLength)
        parameter.Value = If(value Is Nothing, String.Empty, value)
    End Sub

    Private Shared Sub AddIntegerParameter(command As OleDbCommand, value As Integer)
        Dim parameter As OleDbParameter = command.Parameters.Add("?", OleDbType.Integer)
        parameter.Value = value
    End Sub

    Private Shared Sub AddDateParameter(command As OleDbCommand, value As Date)
        Dim parameter As OleDbParameter = command.Parameters.Add("?", OleDbType.Date)
        parameter.Value = value
    End Sub

    Private Shared Function Failure(message As String,
                                    Optional recordId As Integer = 0) As ClientOperationResult
        Return New ClientOperationResult With {
            .Success = False,
            .Message = If(message, "The operation could not be completed."),
            .RecordId = recordId
        }
    End Function

    Private Shared Function Succeeded(message As String,
                                      recordId As Integer) As ClientOperationResult
        Return New ClientOperationResult With {
            .Success = True,
            .Message = message,
            .RecordId = recordId
        }
    End Function

    Private Shared Function ValidateCompanyNameSyntax(cleanName As String) As String
        If String.IsNullOrWhiteSpace(cleanName) Then Return "Company name is required."
        If cleanName.Length > MaxTextLength Then
            Return "Company name cannot exceed " & MaxTextLength.ToString(CultureInfo.InvariantCulture) & " characters."
        End If
        If String.IsNullOrWhiteSpace(ComparisonKey(cleanName)) Then
            Return "Company name must contain at least one letter or number."
        End If
        Dim characterError As String = ValidateClientNameCharacters(cleanName, "Company name")
        If characterError.Length > 0 Then Return characterError
        Return String.Empty
    End Function

    Private Shared Function ValidateClientNameCharacters(value As String,
                                                         fieldName As String) As String
        For Each ch As Char In value.Normalize(NormalizationForm.FormKC)
            If Char.IsControl(ch) Then Continue For
            If Not IsAllowedClientNameCharacter(ch) Then
                Return fieldName & " contains an unsupported character. Use letters, numbers, spaces, and only &, apostrophes, periods, commas, parentheses, or hyphens."
            End If
        Next
        Return String.Empty
    End Function

    Private Shared Function TryNormalizeCompanyType(value As String,
                                                    ByRef normalized As String,
                                                    ByRef errorMessage As String) As Boolean
        Select Case ComparisonKey(value)
            Case "private"
                normalized = "Private"
            Case "government"
                normalized = "Government"
            Case Else
                errorMessage = "Client type must be Private or Government."
                Return False
        End Select
        errorMessage = String.Empty
        Return True
    End Function

    Private Shared Function TryNormalizeStatus(value As String,
                                               ByRef normalized As String) As Boolean
        Select Case ComparisonKey(value)
            Case "active"
                normalized = ActiveStatus
                Return True
            Case "inactive"
                normalized = InactiveStatus
                Return True
            Case Else
                normalized = Nothing
                Return False
        End Select
    End Function

    Private Shared Function CanonicalStatusForRead(value As String) As String
        Dim normalized As String = Nothing
        If TryNormalizeStatus(value, normalized) Then Return normalized
        Return CleanDisplayName(value)
    End Function

    Private Shared Function IsActive(value As String) As Boolean
        Return String.Equals(CleanDisplayName(value), ActiveStatus,
                             StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function IsExcludedCompany(companyId As Integer,
                                              excludeId As Integer?) As Boolean
        Return excludeId.HasValue AndAlso companyId = excludeId.Value
    End Function

    Private Shared Function ReadAllCompaniesForAssessment(
        connection As OleDbConnection) As List(Of CompanyRecord)

        Dim companies As New List(Of CompanyRecord)()
        Const sql As String =
            "SELECT [MAIN_CLIENT_ID], [MAIN_CLIENT_NAME], [CLIENT_TYPE], [GLOBAL_STATUS] " &
            "FROM [TBL_CLIENT_MAIN] ORDER BY [MAIN_CLIENT_NAME]"
        Using command As New OleDbCommand(sql, connection)
            Using reader As OleDbDataReader = command.ExecuteReader()
                While reader.Read()
                    companies.Add(New CompanyRecord With {
                        .Id = SafeInteger(reader("MAIN_CLIENT_ID")),
                        .Name = SafeString(reader("MAIN_CLIENT_NAME")),
                        .ClientType = SafeString(reader("CLIENT_TYPE")),
                        .Status = SafeString(reader("GLOBAL_STATUS"))
                    })
                End While
            End Using
        End Using
        Return companies
    End Function

    Private Shared Function FindMatchingWorkSiteParent(
        connection As OleDbConnection,
        candidateKey As String,
        excludeId As Integer?) As CompanyRecord

        Const sql As String =
            "SELECT S.[SUB_CLIENT_NAME], M.[MAIN_CLIENT_ID], M.[MAIN_CLIENT_NAME], " &
            "M.[CLIENT_TYPE], M.[GLOBAL_STATUS] " &
            "FROM [TBL_CLIENT_SUB] AS S INNER JOIN [TBL_CLIENT_MAIN] AS M " &
            "ON S.[MAIN_CLIENT_ID] = M.[MAIN_CLIENT_ID]"

        Dim inactiveFallback As CompanyRecord = Nothing
        Using command As New OleDbCommand(sql, connection)
            Using reader As OleDbDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim companyId As Integer = SafeInteger(reader("MAIN_CLIENT_ID"))
                    Dim parentName As String = SafeString(reader("MAIN_CLIENT_NAME"))
                    If Not IsExcludedCompany(companyId, excludeId) AndAlso
                       Not String.Equals(candidateKey, ComparisonKey(parentName), StringComparison.Ordinal) AndAlso
                       String.Equals(candidateKey, ComparisonKey(SafeString(reader("SUB_CLIENT_NAME"))),
                                     StringComparison.Ordinal) Then
                        Dim company As New CompanyRecord With {
                            .Id = companyId,
                            .Name = parentName,
                            .ClientType = SafeString(reader("CLIENT_TYPE")),
                            .Status = SafeString(reader("GLOBAL_STATUS"))
                        }
                        If IsActive(company.Status) Then Return company
                        If inactiveFallback Is Nothing Then inactiveFallback = company
                    End If
                End While
            End Using
        End Using

        Return inactiveFallback
    End Function

    Private Shared Function CompanyExtensionScore(candidateKey As String,
                                                  existingKey As String) As Integer
        If String.IsNullOrWhiteSpace(candidateKey) OrElse
           String.IsNullOrWhiteSpace(existingKey) OrElse
           String.Equals(candidateKey, existingKey, StringComparison.Ordinal) Then
            Return 0
        End If

        If candidateKey.StartsWith(existingKey & " ", StringComparison.Ordinal) OrElse
           existingKey.StartsWith(candidateKey & " ", StringComparison.Ordinal) Then
            Return 1000 + Math.Min(candidateKey.Length, existingKey.Length)
        End If

        Dim candidateCore As String = RemoveLegalSuffixes(candidateKey)
        Dim existingCore As String = RemoveLegalSuffixes(existingKey)
        If candidateCore.Length >= 4 AndAlso existingCore.Length >= 4 Then
            If String.Equals(candidateCore, existingCore, StringComparison.Ordinal) Then
                Return 900 + candidateCore.Length
            End If
            If candidateCore.StartsWith(existingCore & " ", StringComparison.Ordinal) OrElse
               existingCore.StartsWith(candidateCore & " ", StringComparison.Ordinal) Then
                Return 800 + Math.Min(candidateCore.Length, existingCore.Length)
            End If
        End If

        Dim candidateTokens As List(Of String) = SignificantTokens(candidateCore)
        Dim existingTokens As List(Of String) = SignificantTokens(existingCore)
        If candidateTokens.Count = 0 OrElse existingTokens.Count = 0 Then Return 0

        Dim sharedTokenCount As Integer = 0
        For Each token As String In candidateTokens
            If existingTokens.Contains(token) Then sharedTokenCount += 1
        Next

        Dim smallerCount As Integer = Math.Min(candidateTokens.Count, existingTokens.Count)
        If sharedTokenCount >= 1 AndAlso smallerCount > 0 AndAlso
           String.Equals(candidateTokens(0), existingTokens(0), StringComparison.Ordinal) AndAlso
           candidateTokens(0).Length >= 5 AndAlso
           CDbl(sharedTokenCount) / CDbl(smallerCount) >= 0.5R Then
            Return 500 + (sharedTokenCount * 10)
        End If

        Return 0
    End Function

    Private Shared Function RemoveLegalSuffixes(key As String) As String
        Dim tokens As New List(Of String)(key.Split(New Char() {" "c},
                                                      StringSplitOptions.RemoveEmptyEntries))
        While tokens.Count > 0 AndAlso LegalSuffixTokens.Contains(tokens(tokens.Count - 1))
            tokens.RemoveAt(tokens.Count - 1)
        End While
        Return String.Join(" ", tokens.ToArray())
    End Function

    Private Shared Function SignificantTokens(key As String) As List(Of String)
        Dim result As New List(Of String)()
        For Each token As String In key.Split(New Char() {" "c},
                                              StringSplitOptions.RemoveEmptyEntries)
            If token.Length >= 2 AndAlso
               Not LegalSuffixTokens.Contains(token) AndAlso
               Not GenericSimilarityTokens.Contains(token) AndAlso
               Not result.Contains(token) Then
                result.Add(token)
            End If
        Next
        Return result
    End Function

    Private Shared Function FindExactCompanyDuplicate(
        connection As OleDbConnection,
        transaction As OleDbTransaction,
        name As String,
        excludeId As Integer?,
        ByRef duplicateId As Integer,
        ByRef duplicateName As String) As Boolean

        Const sql As String =
            "SELECT [MAIN_CLIENT_ID], [MAIN_CLIENT_NAME] FROM [TBL_CLIENT_MAIN]"
        Dim key As String = ComparisonKey(name)
        Using command As New OleDbCommand(sql, connection, transaction)
            Using reader As OleDbDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim id As Integer = SafeInteger(reader("MAIN_CLIENT_ID"))
                    If Not IsExcludedCompany(id, excludeId) Then
                        Dim existingName As String = SafeString(reader("MAIN_CLIENT_NAME"))
                        If String.Equals(key, ComparisonKey(existingName), StringComparison.Ordinal) Then
                            duplicateId = id
                            duplicateName = existingName
                            Return True
                        End If
                    End If
                End While
            End Using
        End Using
        Return False
    End Function

    Private Shared Function CompanyExists(connection As OleDbConnection,
                                          transaction As OleDbTransaction,
                                          id As Integer) As Boolean
        Const sql As String =
            "SELECT COUNT(*) FROM [TBL_CLIENT_MAIN] WHERE [MAIN_CLIENT_ID] = ?"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddIntegerParameter(command, id)
            Return SafeInteger(command.ExecuteScalar()) = 1
        End Using
    End Function

    Private Shared Function TryValidateWorkSite(
        draft As WorkSiteDraft,
        isCreate As Boolean,
        ByRef data As ValidatedWorkSiteData,
        ByRef errorMessage As String) As Boolean

        If draft Is Nothing Then
            errorMessage = "Work-site details are required."
            Return False
        End If
        If draft.CompanyId <= 0 Then
            errorMessage = "Select an active parent company."
            Return False
        End If

        Dim rawName As String = CleanDisplayName(draft.Name)
        Dim nameCharacterError As String = ValidateClientNameCharacters(rawName, "Work-site name")
        If nameCharacterError.Length > 0 Then
            errorMessage = nameCharacterError
            Return False
        End If
        Dim cleanName As String = NormalizeClientNameInput(rawName)
        Dim cleanAddress As String = CleanDisplayName(draft.Address)
        Dim cleanPerson As String = CleanDisplayName(draft.ContactPerson)
        Dim cleanPhone As String = CleanDisplayName(draft.ContactNumber)
        Dim cleanEmail As String = CleanDisplayName(draft.ContactEmail)

        If String.IsNullOrWhiteSpace(cleanName) Then
            errorMessage = "Work-site name is required."
            Return False
        End If
        If String.IsNullOrWhiteSpace(ComparisonKey(cleanName)) Then
            errorMessage = "Work-site name must contain at least one letter or number."
            Return False
        End If
        If String.IsNullOrWhiteSpace(cleanAddress) Then
            errorMessage = "Work-site address is required."
            Return False
        End If
        If cleanName.Length > MaxTextLength OrElse cleanAddress.Length > MaxTextLength OrElse
           cleanPerson.Length > MaxTextLength OrElse cleanPhone.Length > MaxTextLength OrElse
           cleanEmail.Length > MaxTextLength Then
            errorMessage = "Work-site and contact fields cannot exceed " &
                           MaxTextLength.ToString(CultureInfo.InvariantCulture) & " characters."
            Return False
        End If

        Dim scheduleType As String = CleanDisplayName(draft.ScheduleType).ToUpperInvariant()
        If Array.IndexOf(AllowedScheduleTypes, scheduleType) < 0 Then
            errorMessage = "Schedule type must be 2SHIFTS, TRI_SHIFT, or TIME_SPECIFIC."
            Return False
        End If
        If draft.DailyWage <= 0 Then
            errorMessage = "Daily wage must be a positive whole-peso amount."
            Return False
        End If
        If Not IsValidEmail(cleanEmail) Then
            errorMessage = "Enter a valid email address or leave the email field blank."
            Return False
        End If
        If Not IsValidPhone(cleanPhone) Then
            errorMessage = "Enter a valid phone number or leave the phone field blank."
            Return False
        End If

        Dim requestedStatus As String = Nothing
        If isCreate Then
            If String.IsNullOrWhiteSpace(draft.Status) Then
                requestedStatus = ActiveStatus
            ElseIf Not TryNormalizeStatus(draft.Status, requestedStatus) Then
                errorMessage = "Work-site status must be Active or Inactive."
                Return False
            End If
        ElseIf Not String.IsNullOrWhiteSpace(draft.Status) AndAlso
               Not TryNormalizeStatus(draft.Status, requestedStatus) Then
            errorMessage = "Work-site status must be Active or Inactive."
            Return False
        End If

        data = New ValidatedWorkSiteData With {
            .CompanyId = draft.CompanyId,
            .Name = cleanName,
            .Address = cleanAddress,
            .DailyWage = draft.DailyWage,
            .ScheduleType = scheduleType,
            .ContactPerson = cleanPerson,
            .ContactNumber = cleanPhone,
            .ContactEmail = cleanEmail,
            .RequestedStatus = requestedStatus
        }
        errorMessage = String.Empty
        Return True
    End Function

    Private Shared Function IsValidEmail(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return True
        Try
            Dim address As New MailAddress(value)
            Return String.Equals(address.Address, value, StringComparison.OrdinalIgnoreCase) AndAlso
                   value.IndexOf("..", StringComparison.Ordinal) < 0
        Catch
            Return False
        End Try
    End Function

    Private Shared Function IsValidPhone(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return True
        If Not Regex.IsMatch(value, "^[0-9+()\-./\s]+$") Then Return False
        Dim digitCount As Integer = Regex.Replace(value, "\D", String.Empty).Length
        Return digitCount >= 7 AndAlso digitCount <= 30
    End Function

    Private Shared Function VerifyActiveParent(
        connection As OleDbConnection,
        transaction As OleDbTransaction,
        companyId As Integer,
        ByRef companyName As String) As String

        Const sql As String =
            "SELECT [MAIN_CLIENT_NAME], [GLOBAL_STATUS] FROM [TBL_CLIENT_MAIN] " &
            "WHERE [MAIN_CLIENT_ID] = ?"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddIntegerParameter(command, companyId)
            Using reader As OleDbDataReader = command.ExecuteReader()
                If Not reader.Read() Then Return "The selected parent company no longer exists."
                companyName = SafeString(reader("MAIN_CLIENT_NAME"))
                If Not IsActive(SafeString(reader("GLOBAL_STATUS"))) Then
                    Return "The selected parent company is inactive. Reactivate it before saving a work site."
                End If
            End Using
        End Using
        Return String.Empty
    End Function

    Private Shared Function FindWorkSiteConflict(
        connection As OleDbConnection,
        transaction As OleDbTransaction,
        companyId As Integer,
        nameKey As String,
        addressKey As String,
        excludeId As Integer?,
        ByRef duplicateId As Integer,
        ByRef warning As String) As Boolean

        Const sql As String =
            "SELECT [SUB_CLIENT_ID], [SUB_CLIENT_NAME], [ADDRESS] " &
            "FROM [TBL_CLIENT_SUB] WHERE [MAIN_CLIENT_ID] = ?"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddIntegerParameter(command, companyId)
            Using reader As OleDbDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim existingId As Integer = SafeInteger(reader("SUB_CLIENT_ID"))
                    If Not excludeId.HasValue OrElse existingId <> excludeId.Value Then
                        Dim existingName As String = SafeString(reader("SUB_CLIENT_NAME"))
                        If String.Equals(nameKey, ComparisonKey(existingName), StringComparison.Ordinal) Then
                            Dim existingAddress As String = SafeString(reader("ADDRESS"))
                            If String.Equals(addressKey, ComparisonKey(existingAddress),
                                             StringComparison.Ordinal) Then
                                duplicateId = existingId
                                Return True
                            End If
                            If String.IsNullOrWhiteSpace(warning) Then
                                warning =
                                    "Warning: another work site under this company has the same normalized name at a different address."
                            End If
                        End If
                    End If
                End While
            End Using
        End Using
        Return False
    End Function

    Private Shared Function ReadWorkSiteStatus(connection As OleDbConnection,
                                               transaction As OleDbTransaction,
                                               id As Integer) As String
        Const sql As String =
            "SELECT [SUB_CLIENT_STATUS] FROM [TBL_CLIENT_SUB] WHERE [SUB_CLIENT_ID] = ?"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddIntegerParameter(command, id)
            Dim value As Object = command.ExecuteScalar()
            If value Is Nothing OrElse value Is DBNull.Value Then Return Nothing
            Return SafeString(value)
        End Using
    End Function

    Private Shared Function GenerateNextWorkSiteId(connection As OleDbConnection,
                                                   transaction As OleDbTransaction) As Integer
        Const sql As String = "SELECT MAX([SUB_CLIENT_ID]) FROM [TBL_CLIENT_SUB]"
        Using command As New OleDbCommand(sql, connection, transaction)
            Dim value As Object = command.ExecuteScalar()
            If value Is Nothing OrElse value Is DBNull.Value Then Return 1
            Dim currentMaximum As Integer = SafeInteger(value)
            If currentMaximum = Integer.MaxValue Then
                Throw New InvalidOperationException("No additional work-site IDs are available.")
            End If
            Return currentMaximum + 1
        End Using
    End Function

    Private Shared Function TryValidateContract(
        draft As ContractDraft,
        requireSourceFile As Boolean,
        ByRef data As ValidatedContractData,
        ByRef errorMessage As String) As Boolean

        If draft Is Nothing Then
            errorMessage = "Contract details are required."
            Return False
        End If
        If draft.StartDate = Date.MinValue OrElse draft.EndDate = Date.MinValue Then
            errorMessage = "Contract start and end dates are required."
            Return False
        End If
        If draft.StartDate.Date > draft.EndDate.Date Then
            errorMessage = "Contract start date cannot be after the end date."
            Return False
        End If

        Dim remarks As String = CleanDisplayName(draft.Remarks)
        If remarks.Length > MaxTextLength Then
            errorMessage = "Contract remarks cannot exceed " &
                           MaxTextLength.ToString(CultureInfo.InvariantCulture) & " characters."
            Return False
        End If

        Dim sourcePath As String = String.Empty
        If Not String.IsNullOrWhiteSpace(draft.SourceFilePath) Then
            Try
                sourcePath = Path.GetFullPath(draft.SourceFilePath.Trim())
            Catch ex As Exception
                errorMessage = "The selected contract file path is invalid: " & ex.Message
                Return False
            End Try
        End If

        If requireSourceFile AndAlso String.IsNullOrWhiteSpace(sourcePath) Then
            errorMessage = "Select a PDF, JPG, or JPEG contract file."
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(sourcePath) Then
            If Not File.Exists(sourcePath) Then
                errorMessage = "The selected contract file no longer exists."
                Return False
            End If

            Dim extension As String = Path.GetExtension(sourcePath).ToLowerInvariant()
            If extension <> ".pdf" AndAlso extension <> ".jpg" AndAlso extension <> ".jpeg" Then
                errorMessage = "Contract attachment must be a PDF, JPG, or JPEG file."
                Return False
            End If

            Try
                Dim length As Long = New FileInfo(sourcePath).Length
                If length > MaxContractBytes Then
                    errorMessage = "Contract attachment cannot exceed 10 MB."
                    Return False
                End If
            Catch ex As Exception
                errorMessage = "The selected contract file could not be inspected: " & ex.Message
                Return False
            End Try
        End If

        data = New ValidatedContractData With {
            .StartDate = draft.StartDate.Date,
            .EndDate = draft.EndDate.Date,
            .Remarks = remarks,
            .SourceFilePath = sourcePath
        }
        errorMessage = String.Empty
        Return True
    End Function

    Private Shared Function ContractDirectoryPath() As String
        Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                            "Attachments", "Client_Contract")
    End Function

    Private Shared Sub EnsureContractDirectory()
        Directory.CreateDirectory(ContractDirectoryPath())
    End Sub

    Private Shared Function BuildContractDestinationPath(siteId As Integer,
                                                         sourcePath As String) As String
        Dim extension As String = Path.GetExtension(sourcePath).ToLowerInvariant()
        Dim fileName As String =
            siteId.ToString(CultureInfo.InvariantCulture) & "_" &
            DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) & "_" &
            Guid.NewGuid().ToString("N").Substring(0, 8) & extension
        Dim destination As String = Path.GetFullPath(
            Path.Combine(ContractDirectoryPath(), fileName))
        If destination.Length > MaxTextLength Then
            Throw New PathTooLongException(
                "The managed contract path exceeds the database's 255-character limit.")
        End If
        Return destination
    End Function

    Private Shared Sub CopyValidatedContractFile(sourcePath As String,
                                                 destinationPath As String)
        File.Copy(sourcePath, destinationPath, False)
        Dim copiedLength As Long = New FileInfo(destinationPath).Length
        If copiedLength > MaxContractBytes Then
            Throw New InvalidDataException("Contract attachment cannot exceed 10 MB.")
        End If
    End Sub

    Private Shared Function InsertContract(
        connection As OleDbConnection,
        transaction As OleDbTransaction,
        siteId As Integer,
        data As ValidatedContractData,
        destinationPath As String) As Integer

        Const sql As String =
            "INSERT INTO [TBL_CLIENT_CONTRACT] " &
            "([SUB_CLIENT_ID], [START_CONTRACT_DATE], [END_CONTRACT_DATE], " &
            "[CONTRACT_STATUS], [REMARKS], [CONTRACT_PATH]) VALUES (?, ?, ?, ?, ?, ?)"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddIntegerParameter(command, siteId)
            AddDateParameter(command, data.StartDate)
            AddDateParameter(command, data.EndDate)
            AddTextParameter(command, ActiveStatus)
            AddTextParameter(command, data.Remarks)
            AddTextParameter(command, destinationPath)
            command.ExecuteNonQuery()
        End Using
        Return ReadIdentity(connection, transaction)
    End Function

    Private Shared Function ReadIdentity(connection As OleDbConnection,
                                         transaction As OleDbTransaction) As Integer
        Using command As New OleDbCommand("SELECT @@IDENTITY", connection, transaction)
            Return SafeInteger(command.ExecuteScalar())
        End Using
    End Function

    Private Shared Function VerifySiteAndActiveParent(
        connection As OleDbConnection,
        transaction As OleDbTransaction,
        siteId As Integer) As String

        Const sql As String =
            "SELECT M.[GLOBAL_STATUS] FROM [TBL_CLIENT_SUB] AS S " &
            "INNER JOIN [TBL_CLIENT_MAIN] AS M ON S.[MAIN_CLIENT_ID] = M.[MAIN_CLIENT_ID] " &
            "WHERE S.[SUB_CLIENT_ID] = ?"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddIntegerParameter(command, siteId)
            Dim value As Object = command.ExecuteScalar()
            If value Is Nothing OrElse value Is DBNull.Value Then
                Return "The selected work site or its parent company no longer exists."
            End If
            If Not IsActive(SafeString(value)) Then
                Return "The parent company is inactive. Reactivate it before adding a contract."
            End If
        End Using
        Return String.Empty
    End Function

    Private Shared Function ReadContractLocation(
        connection As OleDbConnection,
        transaction As OleDbTransaction,
        contractId As Integer,
        ByRef siteId As Integer,
        ByRef filePath As String) As Boolean

        Const sql As String =
            "SELECT [SUB_CLIENT_ID], [CONTRACT_PATH] FROM [TBL_CLIENT_CONTRACT] WHERE [ID] = ?"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddIntegerParameter(command, contractId)
            Using reader As OleDbDataReader = command.ExecuteReader()
                If Not reader.Read() Then Return False
                siteId = SafeInteger(reader("SUB_CLIENT_ID"))
                filePath = SafeString(reader("CONTRACT_PATH"))
                Return True
            End Using
        End Using
    End Function

    Private Shared Function ReadWorkSiteParentStatus(
        connection As OleDbConnection,
        transaction As OleDbTransaction,
        siteId As Integer,
        ByRef exists As Boolean) As String

        Const sql As String =
            "SELECT M.[GLOBAL_STATUS] FROM [TBL_CLIENT_SUB] AS S " &
            "LEFT JOIN [TBL_CLIENT_MAIN] AS M ON S.[MAIN_CLIENT_ID] = M.[MAIN_CLIENT_ID] " &
            "WHERE S.[SUB_CLIENT_ID] = ?"
        Using command As New OleDbCommand(sql, connection, transaction)
            AddIntegerParameter(command, siteId)
            Using reader As OleDbDataReader = command.ExecuteReader()
                If Not reader.Read() Then
                    exists = False
                    Return String.Empty
                End If
                exists = True
                Return SafeString(reader("GLOBAL_STATUS"))
            End Using
        End Using
    End Function

    Private Shared Function DeleteManagedAttachmentIfUnreferenced(filePath As String) As String
        If String.IsNullOrWhiteSpace(filePath) Then Return String.Empty
        If Not IsManagedContractPath(filePath) Then Return String.Empty

        Try
            Const sql As String =
                "SELECT COUNT(*) FROM [TBL_CLIENT_CONTRACT] WHERE [CONTRACT_PATH] = ?"
            Using connection As OleDbConnection = CreateOpenConnection()
                Using command As New OleDbCommand(sql, connection)
                    AddTextParameter(command, filePath)
                    If SafeInteger(command.ExecuteScalar()) > 0 Then Return String.Empty
                End Using
            End Using

            If File.Exists(filePath) Then File.Delete(filePath)
            Return String.Empty
        Catch ex As Exception
            Return "The database change was saved, but the old managed attachment could not be removed: " & ex.Message
        End Try
    End Function

    Private Shared Function IsManagedContractPath(filePath As String) As Boolean
        Try
            Dim root As String = Path.GetFullPath(ContractDirectoryPath()).TrimEnd(
                Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) & Path.DirectorySeparatorChar
            Dim candidate As String = Path.GetFullPath(filePath)
            Return candidate.StartsWith(root, StringComparison.OrdinalIgnoreCase)
        Catch
            Return False
        End Try
    End Function

    Private Shared Sub DeleteFileQuietly(filePath As String)
        If String.IsNullOrWhiteSpace(filePath) Then Return
        Try
            If File.Exists(filePath) Then File.Delete(filePath)
        Catch
            ' A failed compensating delete must not hide the original database/file error.
        End Try
    End Sub

    Private Shared Sub RollbackQuietly(transaction As OleDbTransaction)
        If transaction Is Nothing Then Return
        Try
            transaction.Rollback()
        Catch
            ' Preserve the original failure; the connection disposal is the final safeguard.
        End Try
    End Sub
End Class
