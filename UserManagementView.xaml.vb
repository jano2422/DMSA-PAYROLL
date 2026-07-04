Imports System.Data.OleDb
Imports System.Windows
Imports System.Windows.Controls

Public Class UserManagementView
    Inherits UserControl

    Private Sub UserManagementView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        LoadUserLevelOnStart()

        If Not String.Equals(GlobalVariables.sUser_Level, "administrator", StringComparison.OrdinalIgnoreCase) Then
            AppNotification.ShowWpf("Access denied. Only administrators are allowed to access this view.", "Unauthorized Access", MessageBoxButton.OK, MessageBoxImage.Warning)

            ' Close the parent window
            Dim win As Window = Window.GetWindow(Me)
            If win IsNot Nothing Then
                win.Close()
            End If

            Return
        End If

        InitializeUserLevel()
        LoadUsers()
    End Sub





    Private Sub InitializeUserLevel()
        ' Default state: ComboBox is disabled
        Cmb_UserLevel.IsEnabled = False

        Select Case GlobalVariables.sUser_Level.ToLower()
            Case "user"
                Cmb_UserLevel.SelectedIndex = 0

            Case "administrator"
                Cmb_UserLevel.IsEnabled = True
                Cmb_UserLevel.SelectedIndex = 1
        End Select
    End Sub



    Private Sub Btn_Create_Click(sender As Object, e As RoutedEventArgs)
        If Btn_Create.Content.ToString() = "Create" Then
            Btn_Cancel.Visibility = Visibility.Visible
            Btn_Create.Content = "Save"
        Else
            If String.IsNullOrWhiteSpace(Txt_UserID.Text) OrElse Cmb_UserLevel.SelectedIndex = -1 Then
                AppNotification.ShowWpf("Please complete all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning)
                Return
            End If

            ' ✅ Check if COMPANY_ID already exists
            If UserExists(Txt_UserID.Text) Then
                AppNotification.ShowWpf("A user with this COMPANY_ID already exists.", "Duplicate Entry", MessageBoxButton.OK, MessageBoxImage.Warning)
                Return
            End If

            ' Insert new user
            Insert_new_User(Txt_UserID.Text, "welcome", Cmb_UserLevel.Text)

            LoadUsers()
            ClearFields()
            Btn_Cancel.Visibility = Visibility.Collapsed
            Btn_Create.Content = "Create"
        End If
    End Sub


    Private Sub Btn_Update_Click(sender As Object, e As RoutedEventArgs)
        If String.IsNullOrWhiteSpace(Txt_UserID.Text) OrElse Cmb_UserLevel.SelectedIndex = -1 Then
            AppNotification.ShowWpf("Select a user and level to update.", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning)
            Return
        End If

        Try
            Connect_to_MDB()
            Dim sql As String = $"UPDATE TBL_USERS SET USER_LEVEL = '{Cmb_UserLevel.Text}' WHERE COMPANY_ID = '{Txt_UserID.Text}'"
            Dim cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            AppNotification.ShowWpf("User updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information)
        Catch ex As Exception
            AppNotification.ShowWpf("Update failed: " & ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        Finally
            GlobalVariables.GlobalCon.Close()
            LoadUsers()
            ClearFields()
        End Try
    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As RoutedEventArgs)
        If String.IsNullOrWhiteSpace(Txt_UserID.Text) Then
            AppNotification.ShowWpf("Select a user to delete.", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning)
            Return
        End If

        If AppNotification.ShowWpf("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) = MessageBoxResult.Yes Then
            Try
                Connect_to_MDB()
                Dim sql As String = $"DELETE FROM TBL_USERS WHERE COMPANY_ID = '{Txt_UserID.Text}'"
                Dim cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                AppNotification.ShowWpf("User deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information)
            Catch ex As Exception
                AppNotification.ShowWpf("Delete failed: " & ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
            Finally
                GlobalVariables.GlobalCon.Close()
                LoadUsers()
                ClearFields()
            End Try
        End If
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As RoutedEventArgs)
        ClearFields()
        Btn_Create.Content = "Create"
        Btn_Cancel.Visibility = Visibility.Collapsed
    End Sub

    Private Sub UsersDataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If UsersDataGrid.SelectedItem IsNot Nothing Then
            Dim rowView As DataRowView = CType(UsersDataGrid.SelectedItem, DataRowView)
            Txt_UserID.Text = rowView("COMPANY_ID").ToString()
            Cmb_UserLevel.Text = rowView("USER_LEVEL").ToString()

            Txt_UserID.IsEnabled = False
            Btn_Update.IsEnabled = True
            Btn_Delete.IsEnabled = True
        End If
    End Sub

    Private Sub LoadUsers()
        Dim dt As New DataTable
        Try
            Connect_to_MDB()
            Dim adapter As New OleDbDataAdapter("SELECT COMPANY_ID, USER_LEVEL FROM TBL_USERS", GlobalVariables.GlobalCon)
            adapter.Fill(dt)
            UsersDataGrid.ItemsSource = dt.DefaultView
        Catch ex As Exception
            AppNotification.ShowWpf("Error loading users: " & ex.Message, "DB Error", MessageBoxButton.OK, MessageBoxImage.Error)
        Finally
            GlobalVariables.GlobalCon.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        Txt_UserID.Clear()
        Cmb_UserLevel.SelectedIndex = -1
        Txt_UserID.IsEnabled = True
        Btn_Update.IsEnabled = False
        Btn_Delete.IsEnabled = False
        UsersDataGrid.SelectedItem = Nothing
    End Sub
    Private Sub LoadUserLevelOnStart()
        Try
            Dim companyId As String = Mod_GlobalVariables.GlobalVariables.sEmployee_ID_Logged_in?.Trim()

            If String.IsNullOrEmpty(companyId) Then
                AppNotification.ShowWpf("No Company ID found for the logged-in user.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
                Return
            End If

            Dim userLevel As String = GetUserLevelByCompanyId(companyId)

            If String.IsNullOrEmpty(userLevel) Then
                AppNotification.ShowWpf($"User level not found for Company ID: {companyId}", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            End If

            Mod_GlobalVariables.GlobalVariables.sUser_Level = userLevel

        Catch ex As Exception
            AppNotification.ShowWpf("An error occurred while loading user level: " & ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub



    Private Function GetUserLevelByCompanyId(companyId As String) As String
        Dim userLevel As String = String.Empty
        Try
            Connect_to_MDB()
            Dim sql As String = "SELECT USER_LEVEL FROM TBL_USERS WHERE COMPANY_ID = ?"
            Using cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", companyId)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                    userLevel = result.ToString()
                End If
            End Using
        Catch ex As Exception
            AppNotification.ShowWpf("Error retrieving user level: " & ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        Finally
            GlobalVariables.GlobalCon.Close()
        End Try
        Return userLevel
    End Function

    Private Function UserExists(companyId As String) As Boolean
        Dim exists As Boolean = False
        Try
            Connect_to_MDB()
            Dim sql As String = "SELECT COUNT(*) FROM TBL_USERS WHERE COMPANY_ID = ?"
            Using cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", companyId)
                Dim count As Integer = CInt(cmd.ExecuteScalar())
                exists = (count > 0)
            End Using
        Catch ex As Exception
            AppNotification.ShowWpf("Error checking user: " & ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        Finally
            GlobalVariables.GlobalCon.Close()
        End Try
        Return exists
    End Function

End Class
