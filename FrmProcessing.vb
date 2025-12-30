Public Class FrmProcessing
    Inherits Form

    Private lblMessage As Label
    Private loadingBar As ProgressBar

    Public Sub New(Optional message As String = "Processing, please wait...")
        ' === BASE FORM SETTINGS ===
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(360, 130)
        Me.BackColor = Color.White
        Me.TopMost = True
        Me.ShowInTaskbar = False
        Me.ControlBox = False

        ' === LABEL ===
        lblMessage = New Label()
        lblMessage.Text = message
        lblMessage.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblMessage.AutoSize = False
        lblMessage.TextAlign = ContentAlignment.MiddleCenter
        lblMessage.Dock = DockStyle.Top
        lblMessage.Height = 60

        ' === PROGRESS BAR ===
        loadingBar = New ProgressBar()
        loadingBar.Dock = DockStyle.Bottom
        loadingBar.Height = 25
        loadingBar.Style = ProgressBarStyle.Marquee
        loadingBar.MarqueeAnimationSpeed = 40

        ' === ADD TO FORM ===
        Me.Controls.Add(lblMessage)
        Me.Controls.Add(loadingBar)
    End Sub
End Class
