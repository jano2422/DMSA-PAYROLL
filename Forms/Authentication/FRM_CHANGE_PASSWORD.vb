Imports System.Data
Imports System.Data.OleDb

Public Class FRM_CHANGE_PASSWORD
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(username As String)
        Me.New()
        TxtUsername.Text = username.Trim()
        If Not String.IsNullOrWhiteSpace(TxtUsername.Text) Then
            TxtCurrentPassword.Focus()
        End If
    End Sub

    Private Sub BtnChangePassword_Click(sender As Object, e As EventArgs) Handles BtnChangePassword.Click
        ChangePassword()
    End Sub

    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        ClearPasswordFields()
        TxtUsername.Focus()
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click
        Close()
    End Sub

    Private Sub Chk_ShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_ShowPassword.CheckedChanged
        Dim passwordChar As Char = If(Chk_ShowPassword.Checked, ControlChars.NullChar, "*"c)
        TxtCurrentPassword.PasswordChar = passwordChar
        TxtNewPassword.PasswordChar = passwordChar
        TxtConfirmPassword.PasswordChar = passwordChar
    End Sub

    Private Sub ChangePassword()
        Dim username As String = TxtUsername.Text.Trim()
        Dim currentPassword As String = TxtCurrentPassword.Text.Trim()
        Dim newPassword As String = TxtNewPassword.Text.Trim()
        Dim confirmPassword As String = TxtConfirmPassword.Text.Trim()

        If Not ValidatePasswordInput(username, currentPassword, newPassword, confirmPassword) Then Return

        Try
            Connect_to_MDB()

            If Not CurrentCredentialsAreValid(username, currentPassword) Then
                MsgBox("Invalid username or current password.", vbExclamation, "Change Password")
                TxtCurrentPassword.Focus()
                Return
            End If

            Using updateCmd As New OleDbCommand(
                "UPDATE TBL_USERS SET [PASSWORD] = ? WHERE UCASE(COMPANY_ID) = UCASE(?)",
                GlobalVariables.GlobalCon)

                updateCmd.Parameters.AddWithValue("?", newPassword)
                updateCmd.Parameters.AddWithValue("?", username)
                updateCmd.ExecuteNonQuery()
            End Using

            MsgBox("Password changed successfully.", vbInformation, "Change Password")
            ClearPasswordFields()
            TxtUsername.Focus()
        Catch ex As Exception
            MsgBox("Database error: " & ex.Message, vbCritical, "Change Password")
        Finally
            CloseGlobalConnection()
        End Try
    End Sub

    Private Function ValidatePasswordInput(username As String, currentPassword As String, newPassword As String, confirmPassword As String) As Boolean
        If String.IsNullOrWhiteSpace(username) OrElse
           String.IsNullOrWhiteSpace(currentPassword) OrElse
           String.IsNullOrWhiteSpace(newPassword) OrElse
           String.IsNullOrWhiteSpace(confirmPassword) Then

            MsgBox("Please complete all password fields.", vbExclamation, "Validation")
            Return False
        End If

        If newPassword <> confirmPassword Then
            MsgBox("New password and confirmation do not match.", vbExclamation, "Validation")
            TxtConfirmPassword.Focus()
            Return False
        End If

        If newPassword = currentPassword Then
            MsgBox("New password must be different from the current password.", vbExclamation, "Validation")
            TxtNewPassword.Focus()
            Return False
        End If

        If newPassword.Length < 4 Then
            MsgBox("New password must be at least 4 characters.", vbExclamation, "Validation")
            TxtNewPassword.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function CurrentCredentialsAreValid(username As String, currentPassword As String) As Boolean
        Using checkCmd As New OleDbCommand(
            "SELECT COUNT(*) FROM TBL_USERS WHERE UCASE(COMPANY_ID) = UCASE(?) AND [PASSWORD] = ?",
            GlobalVariables.GlobalCon)

            checkCmd.Parameters.AddWithValue("?", username)
            checkCmd.Parameters.AddWithValue("?", currentPassword)
            Return CInt(checkCmd.ExecuteScalar()) > 0
        End Using
    End Function

    Private Sub ClearPasswordFields()
        TxtCurrentPassword.Clear()
        TxtNewPassword.Clear()
        TxtConfirmPassword.Clear()
        Chk_ShowPassword.Checked = False
    End Sub

    Private Sub CloseGlobalConnection()
        If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
            GlobalVariables.GlobalCon.Close()
        End If
    End Sub
End Class
