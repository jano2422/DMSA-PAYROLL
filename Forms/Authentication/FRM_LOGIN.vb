Imports System.Data.OleDb

Public Class FRM_LOGIN
    Public Sub New()
        InitializeComponent()
        Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath)
    End Sub

    Private Sub FRM_LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'If Now.Year = 2024 Then

        MDB_Connection_Init()

        If String.IsNullOrWhiteSpace(GlobalVariables.GlobalConStr) Then
            Close()
            Return
        End If

        Try
            ' This is intentionally silent and idempotent. Missing payroll tables,
            ' columns, and indexes are created; an up-to-date MDB is unchanged.
            ManualPayrollRecordService.EnsureSchema()
            WriteStartupSchemaLog("INFO", "Database schema check completed successfully.")
        Catch ex As Exception
            WriteStartupSchemaLog("ERROR", ex.GetType().FullName & ": " & ex.Message)
            MessageBox.Show(
                "The payroll database could not be updated for this application version. " &
                "Startup was stopped to prevent payroll processing with an incomplete schema. " &
                "Please contact the system administrator.",
                "Database Update Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            Close()
            Return
        End Try

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
        Using changePasswordForm As New FRM_CHANGE_PASSWORD(TxtUsername.Text)
            changePasswordForm.ShowDialog(Me)
        End Using
    End Sub

    Private Shared Sub WriteStartupSchemaLog(level As String, message As String)
        Try
            Dim logFolder = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "DMSA Payroll",
                "Logs")
            System.IO.Directory.CreateDirectory(logFolder)

            Dim logPath = System.IO.Path.Combine(logFolder, "startup-schema.log")
            If System.IO.File.Exists(logPath) AndAlso
               New System.IO.FileInfo(logPath).Length > 1024L * 1024L Then
                System.IO.File.Copy(logPath, logPath & ".previous", True)
                System.IO.File.WriteAllText(logPath, String.Empty)
            End If

            Dim sanitizedMessage = If(message, String.Empty).
                Replace(vbCr, " ").
                Replace(vbLf, " ")
            System.IO.File.AppendAllText(
                logPath,
                DateTimeOffset.Now.ToString("O") & " [" & level & "] DatabaseSchema " &
                sanitizedMessage & Environment.NewLine)
        Catch
            ' Logging must never prevent application startup or hide the migration result.
        End Try
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
