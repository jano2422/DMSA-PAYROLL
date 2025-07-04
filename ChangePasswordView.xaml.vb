Imports System.Data.OleDb
Imports System.Windows
Imports System.Windows.Controls
Public Class ChangePasswordView
    Inherits UserControl
    Private Sub BtnChangePassword_Click(sender As Object, e As RoutedEventArgs)
        Dim username As String = TxtUsername.Text.Trim()
        Dim currentPassword As String = TxtCurrentPassword.Password.Trim()
        Dim newPassword As String = TxtNewPassword.Password.Trim()
        Dim confirmPassword As String = TxtConfirmPassword.Password.Trim()

        ' === Validation ===
        If String.IsNullOrWhiteSpace(username) OrElse
           String.IsNullOrWhiteSpace(currentPassword) OrElse
           String.IsNullOrWhiteSpace(newPassword) OrElse
           String.IsNullOrWhiteSpace(confirmPassword) Then

            MessageBox.Show("All fields are required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning)
            Return
        End If

        If newPassword <> confirmPassword Then
            MessageBox.Show("New password and confirmation do not match.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning)
            Return
        End If

        ' === Perform Update in MS Access ===
        Try
            Using con As New OleDbConnection(Mod_GlobalVariables.GlobalVariables.GlobalConStr)
                con.Open()

                ' Check if current credentials are correct (case-insensitive for COMPANY_ID and PASSWORD)
                Dim checkCmd As New OleDbCommand("
                    SELECT COUNT(*) FROM TBL_USERS 
                    WHERE UCASE(COMPANY_ID) = UCASE(?) 
                    AND PASSWORD = ?", con)

                checkCmd.Parameters.AddWithValue("?", username)
                checkCmd.Parameters.AddWithValue("?", currentPassword)

                Dim isValid As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If isValid = 0 Then
                    MessageBox.Show("Invalid username or current password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
                    Return
                End If

                ' Update new password
                Dim updateCmd As New OleDbCommand("
                    UPDATE TBL_USERS 
                    SET [PASSWORD] = ? 
                    WHERE UCASE(COMPANY_ID) = UCASE(?)", con)

                updateCmd.Parameters.AddWithValue("?", newPassword)
                updateCmd.Parameters.AddWithValue("?", username)

                updateCmd.ExecuteNonQuery()

                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information)

                ' Clear inputs
                TxtUsername.Clear()
                TxtCurrentPassword.Clear()
                TxtNewPassword.Clear()
                TxtConfirmPassword.Clear()
            End Using

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

End Class
