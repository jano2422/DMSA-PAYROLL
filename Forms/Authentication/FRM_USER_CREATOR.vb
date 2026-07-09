Imports System.Data
Imports System.Data.OleDb

Public Class FRM_USER_CREATOR
    Private Const DefaultPassword As String = "welcome"
    Private _selectedCompanyId As String = ""
    Private _selectedUserLevel As String = ""
    Private _isLoadingSelection As Boolean = False

    Private Sub FRM_USER_CREATOR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserLevelOnStart()

        If Not IsAdministrator() Then
            MsgBox("Access denied. Only administrators are allowed to manage user accounts.", vbExclamation, "Unauthorized Access")
            BeginInvoke(New MethodInvoker(AddressOf Close))
            Return
        End If

        ResetSearchControls()
        ClearFields()
        LoadUsers(Cmb_Category.Text, TxtSearch.Text)
    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        LoadUsers(Cmb_Category.Text, TxtSearch.Text)
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadUsers(Cmb_Category.Text, TxtSearch.Text)
        End If
    End Sub

    Private Sub LV_AccountList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_AccountList.SelectedIndexChanged
        If LV_AccountList.SelectedItems.Count = 0 Then Return

        _isLoadingSelection = True
        With LV_AccountList.SelectedItems(0)
            _selectedCompanyId = .SubItems(1).Text
            _selectedUserLevel = NormalizeUserLevel(.SubItems(3).Text)
            Txt_UserID.Text = .SubItems(1).Text
            Cmb_UserLevel.SelectedItem = _selectedUserLevel
        End With
        _isLoadingSelection = False

        Txt_UserID.Enabled = False
        Btn_Create.Text = "Create"
        SetDeleteButtonState(True)
        RefreshUpdateButtonState()
        Btn_Cancel.Visible = True
    End Sub

    Private Sub LV_AccountList_DoubleClick(sender As Object, e As EventArgs) Handles LV_AccountList.DoubleClick
        If Btn_Update.Enabled Then Btn_Update.PerformClick()
    End Sub

    Private Sub Cmb_UserLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_UserLevel.SelectedIndexChanged
        If _isLoadingSelection Then Return
        RefreshUpdateButtonState()
    End Sub

    Private Sub Btn_Create_Click(sender As Object, e As EventArgs) Handles Btn_Create.Click
        If Btn_Create.Text = "Create" Then
            EnterCreateMode()
            Return
        End If

        SaveNewUser()
    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        UpdateSelectedUser()
    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        DeleteSelectedUser()
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        ClearFields()
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click
        Close()
    End Sub

    Private Sub ResetSearchControls()
        TxtSearch.Clear()
        Cmb_Category.SelectedItem = "COMPANY_ID"
    End Sub

    Private Sub EnterCreateMode()
        ClearFields()
        Btn_Create.Text = "Save"
        Btn_Cancel.Visible = True
        Cmb_UserLevel.SelectedItem = "User"
        Txt_UserID.Focus()
    End Sub

    Private Sub ClearFields()
        _isLoadingSelection = True
        _selectedCompanyId = ""
        _selectedUserLevel = ""
        Txt_UserID.Clear()
        Txt_UserID.Enabled = True
        Cmb_UserLevel.SelectedIndex = -1
        LV_AccountList.SelectedIndices.Clear()
        _isLoadingSelection = False
        Btn_Create.Text = "Create"
        SetUpdateButtonState(False)
        SetDeleteButtonState(False)
        Btn_Cancel.Visible = False
    End Sub

    Private Sub LoadUsers(category As String, searchText As String)
        Dim safeCategory As String = NormalizeSearchCategory(category)
        Dim whereClause As String = ""

        If Not String.IsNullOrWhiteSpace(searchText) Then
            Select Case safeCategory
                Case "EMPLOYEE_NAME"
                    whereClause = " WHERE A.LAST_NAME LIKE ? OR A.FIRST_NAME LIKE ? OR A.MIDDLE_NAME LIKE ?"
                Case Else
                    whereClause = " WHERE " & safeCategory & " LIKE ?"
            End Select
        End If

        Dim sql As String =
            "SELECT U.COMPANY_ID, U.USER_LEVEL, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME " &
            "FROM (TBL_USERS AS U " &
            "LEFT JOIN HR_EMPLOYEE_RECORD_HDR AS R ON U.COMPANY_ID = R.EMPLOYEE_ID) " &
            "LEFT JOIN HR_APPLICATION_DTL AS A ON R.APPLICATION_ID = A.APPLICATION_ID" &
            whereClause & " " &
            "ORDER BY U.COMPANY_ID ASC"

        LV_AccountList.Items.Clear()

        Try
            Connect_to_MDB()

            Using cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    Dim searchPattern As String = "%" & searchText.Trim() & "%"
                    If safeCategory = "EMPLOYEE_NAME" Then
                        cmd.Parameters.AddWithValue("?", searchPattern)
                        cmd.Parameters.AddWithValue("?", searchPattern)
                        cmd.Parameters.AddWithValue("?", searchPattern)
                    Else
                        cmd.Parameters.AddWithValue("?", searchPattern)
                    End If
                End If

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    Dim rowNumber As Integer = 1
                    While reader.Read()
                        Dim item As New ListViewItem(rowNumber.ToString())
                        item.SubItems.Add(GetReaderString(reader, "COMPANY_ID"))
                        item.SubItems.Add(BuildEmployeeName(reader))
                        item.SubItems.Add(NormalizeUserLevel(GetReaderString(reader, "USER_LEVEL")))
                        LV_AccountList.Items.Add(item)
                        rowNumber += 1
                    End While
                End Using
            End Using

            Lbl_ResultCount.Text = "Users found: " & LV_AccountList.Items.Count
        Catch ex As Exception
            MsgBox("Unable to load user accounts: " & ex.Message, vbCritical, "User Account Management")
        Finally
            CloseGlobalConnection()
        End Try
    End Sub

    Private Sub SaveNewUser()
        Dim companyId As String = Txt_UserID.Text.Trim()
        Dim userLevel As String = GetSelectedUserLevel()

        If Not ValidateUserInput(companyId, userLevel) Then Return

        If UserExists(companyId) Then
            MsgBox("A user account already exists for this Company ID.", vbExclamation, "Duplicate Account")
            Txt_UserID.Focus()
            Return
        End If

        Try
            Connect_to_MDB()

            Using cmd As New OleDbCommand("INSERT INTO TBL_USERS (COMPANY_ID, [PASSWORD], USER_LEVEL) VALUES (?, ?, ?)", GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", companyId)
                cmd.Parameters.AddWithValue("?", DefaultPassword)
                cmd.Parameters.AddWithValue("?", userLevel)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("New user account was successfully saved.", vbInformation, "Saved")
            LoadUsers(Cmb_Category.Text, TxtSearch.Text)
            ClearFields()
        Catch ex As Exception
            MsgBox("Error creating new account: " & ex.Message, vbCritical, "User Account Management")
        Finally
            CloseGlobalConnection()
        End Try
    End Sub

    Private Sub UpdateSelectedUser()
        Dim companyId As String = Txt_UserID.Text.Trim()
        Dim userLevel As String = GetSelectedUserLevel()

        If Not ValidateUserInput(companyId, userLevel) Then Return

        If IsCurrentUser(companyId) AndAlso Not String.Equals(userLevel, "Administrator", StringComparison.OrdinalIgnoreCase) Then
            MsgBox("You cannot remove administrator access from the account currently logged in.", vbExclamation, "Update Not Allowed")
            Return
        End If

        Try
            Connect_to_MDB()

            Using cmd As New OleDbCommand("UPDATE TBL_USERS SET USER_LEVEL = ? WHERE COMPANY_ID = ?", GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", userLevel)
                cmd.Parameters.AddWithValue("?", companyId)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("User account was successfully updated.", vbInformation, "Updated")
            LoadUsers(Cmb_Category.Text, TxtSearch.Text)
            ClearFields()
        Catch ex As Exception
            MsgBox("Update failed: " & ex.Message, vbCritical, "User Account Management")
        Finally
            CloseGlobalConnection()
        End Try
    End Sub

    Private Sub DeleteSelectedUser()
        Dim companyId As String = Txt_UserID.Text.Trim()

        If Txt_UserID.Enabled OrElse LV_AccountList.SelectedItems.Count = 0 OrElse String.IsNullOrWhiteSpace(companyId) Then
            MsgBox("Please select a user account to delete.", vbExclamation, "Missing Selection")
            Return
        End If

        If IsCurrentUser(companyId) Then
            MsgBox("You cannot delete the account currently logged in.", vbExclamation, "Delete Not Allowed")
            Return
        End If

        If MsgBox("Are you sure you want to delete this user account?", vbYesNo + vbQuestion, "Confirm Delete") <> vbYes Then Return

        Try
            Connect_to_MDB()

            Using cmd As New OleDbCommand("DELETE FROM TBL_USERS WHERE COMPANY_ID = ?", GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", companyId)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("User account was successfully deleted.", vbInformation, "Deleted")
            LoadUsers(Cmb_Category.Text, TxtSearch.Text)
            ClearFields()
        Catch ex As Exception
            MsgBox("Delete failed: " & ex.Message, vbCritical, "User Account Management")
        Finally
            CloseGlobalConnection()
        End Try
    End Sub

    Private Function ValidateUserInput(companyId As String, userLevel As String) As Boolean
        If String.IsNullOrWhiteSpace(companyId) OrElse String.IsNullOrWhiteSpace(userLevel) Then
            MsgBox("Please complete the Company ID and User Level fields.", vbExclamation, "Validation")
            Return False
        End If

        Return True
    End Function

    Private Sub RefreshUpdateButtonState()
        Dim hasSelectedUser As Boolean =
            Not String.IsNullOrWhiteSpace(_selectedCompanyId) AndAlso
            String.Equals(Txt_UserID.Text.Trim(), _selectedCompanyId, StringComparison.OrdinalIgnoreCase)

        Dim hasChanges As Boolean =
            hasSelectedUser AndAlso
            Not String.Equals(GetSelectedUserLevel(), _selectedUserLevel, StringComparison.OrdinalIgnoreCase)

        SetUpdateButtonState(hasChanges)
    End Sub

    Private Sub SetUpdateButtonState(isEnabled As Boolean)
        Btn_Update.Enabled = isEnabled

        If isEnabled Then
            Btn_Update.BackColor = Color.Teal
            Btn_Update.ForeColor = Color.White
        Else
            Btn_Update.BackColor = Color.Gainsboro
            Btn_Update.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub SetDeleteButtonState(isEnabled As Boolean)
        Btn_Delete.Enabled = isEnabled

        If isEnabled Then
            Btn_Delete.BackColor = Color.Maroon
            Btn_Delete.ForeColor = Color.White
        Else
            Btn_Delete.BackColor = Color.Gainsboro
            Btn_Delete.ForeColor = Color.DimGray
        End If
    End Sub

    Private Function UserExists(companyId As String) As Boolean
        Dim exists As Boolean = False

        Try
            Connect_to_MDB()

            Using cmd As New OleDbCommand("SELECT COUNT(*) FROM TBL_USERS WHERE COMPANY_ID = ?", GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", companyId)
                exists = CInt(cmd.ExecuteScalar()) > 0
            End Using
        Catch ex As Exception
            MsgBox("Error checking user account: " & ex.Message, vbCritical, "User Account Management")
        Finally
            CloseGlobalConnection()
        End Try

        Return exists
    End Function

    Private Sub LoadUserLevelOnStart()
        Dim companyId As String = GlobalVariables.sEmployee_ID_Logged_in
        If String.IsNullOrWhiteSpace(companyId) Then Return

        Try
            Connect_to_MDB()

            Using cmd As New OleDbCommand("SELECT USER_LEVEL FROM TBL_USERS WHERE COMPANY_ID = ?", GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", companyId.Trim())
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    GlobalVariables.sUser_Level = result.ToString().Trim()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Unable to confirm current user access: " & ex.Message, vbCritical, "User Account Management")
        Finally
            CloseGlobalConnection()
        End Try
    End Sub

    Private Function IsAdministrator() As Boolean
        Return String.Equals(GlobalVariables.sUser_Level, "Administrator", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function IsCurrentUser(companyId As String) As Boolean
        Return String.Equals(companyId, GlobalVariables.sEmployee_ID_Logged_in, StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function GetSelectedUserLevel() As String
        If Cmb_UserLevel.SelectedItem Is Nothing Then Return ""
        Return NormalizeUserLevel(Cmb_UserLevel.SelectedItem.ToString())
    End Function

    Private Function NormalizeSearchCategory(category As String) As String
        Select Case category
            Case "COMPANY_ID"
                Return "U.COMPANY_ID"
            Case "USER_LEVEL"
                Return "U.USER_LEVEL"
            Case "EMPLOYEE_NAME"
                Return "EMPLOYEE_NAME"
            Case Else
                Return "U.COMPANY_ID"
        End Select
    End Function

    Private Function NormalizeUserLevel(userLevel As String) As String
        If String.IsNullOrWhiteSpace(userLevel) Then Return ""
        If String.Equals(userLevel, "administrator", StringComparison.OrdinalIgnoreCase) Then Return "Administrator"
        If String.Equals(userLevel, "user", StringComparison.OrdinalIgnoreCase) Then Return "User"
        Return userLevel.Trim()
    End Function

    Private Function BuildEmployeeName(reader As OleDbDataReader) As String
        Dim lastName As String = GetReaderString(reader, "LAST_NAME")
        Dim firstName As String = GetReaderString(reader, "FIRST_NAME")
        Dim middleName As String = GetReaderString(reader, "MIDDLE_NAME")
        Dim middleInitial As String = If(String.IsNullOrWhiteSpace(middleName), "", " " & middleName.Substring(0, 1) & ".")

        If String.IsNullOrWhiteSpace(lastName) AndAlso String.IsNullOrWhiteSpace(firstName) Then Return ""
        Return lastName & ", " & firstName & middleInitial
    End Function

    Private Function GetReaderString(reader As OleDbDataReader, columnName As String) As String
        Dim value As Object = reader(columnName)
        If value Is Nothing OrElse value Is DBNull.Value Then Return ""
        Return value.ToString().Trim()
    End Function

    Private Sub CloseGlobalConnection()
        If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
            GlobalVariables.GlobalCon.Close()
        End If
    End Sub
End Class
