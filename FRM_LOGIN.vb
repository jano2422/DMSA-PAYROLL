Imports System.Data.OleDb
Imports System.Windows

Public Class FRM_LOGIN
    Private Sub FRM_LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'If Now.Year = 2024 Then

        MDB_Connection_Init()
        Connect_to_MDB()

        'Else
        '    MsgBox("System Evaluation Expired. Please settle payment", vbCritical, "Trial Expired")
        '    Exit Sub
        'End If

    End Sub

    Private Sub Btn_Confirm_Click(sender As Object, e As EventArgs) Handles Btn_Confirm.Click

        Connect_to_MDB()
        Login(Trim(Me.TxtUsername.Text), Trim(Me.TxtPassword.Text))


    End Sub

    Private Sub ShowChangePasswordView()
        ' Create the user control
        Dim changePasswordControl As New ChangePasswordView()

        ' Wrap the user control in a new window
        Dim changePasswordWindow As New System.Windows.Window With {
        .Title = "Change Password",
        .Width = 600,
        .Height = 500,
        .Content = changePasswordControl,
        .WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
        .ResizeMode = System.Windows.ResizeMode.CanResize,
        .WindowStyle = System.Windows.WindowStyle.ToolWindow
    }

        ' Show the window as a dialog (modal), but we don't care about the result
        changePasswordWindow.ShowDialog()
    End Sub
    Private Sub TxtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPassword.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Connect_to_MDB()
            Login(Trim(Me.TxtUsername.Text), Trim(Me.TxtPassword.Text))

        End If

    End Sub

    Private Sub AdminBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnChangePw_Click(sender As Object, e As EventArgs) Handles BtnChangePw.Click
        ShowChangePasswordView()
    End Sub
End Class