Imports System.Data.OleDb
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

    Private Sub TxtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPassword.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Connect_to_MDB()
            Login(Trim(Me.TxtUsername.Text), Trim(Me.TxtPassword.Text))

        End If

    End Sub


End Class