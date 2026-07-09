Imports System.Drawing
Imports System.Windows.Forms

Public Partial Class FrmProcessing
    Private ReadOnly progressTimer As Timer
    Private progressDirection As Integer = 1
    Private dragOffset As Point

    Public Sub New(Optional message As String = "Processing, please wait...")
        InitializeComponent()
        SetStatusMessage(message)

        progressTimer = New Timer With {
            .Interval = 24
        }
        AddHandler progressTimer.Tick, AddressOf ProgressTimer_Tick
    End Sub

    Public Sub SetStatusMessage(message As String)
        Lbl_Message.Text = If(String.IsNullOrWhiteSpace(message), "Working on your file...", message.Trim())
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        CenterAgainstOwner()
        progressFill.Left = 0
        progressTimer.Start()
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        progressTimer.Stop()
        RemoveHandler progressTimer.Tick, AddressOf ProgressTimer_Tick
        progressTimer.Dispose()
        MyBase.OnFormClosed(e)
    End Sub

    Private Sub CenterAgainstOwner()
        If Owner Is Nothing Then Return

        Dim x As Integer = Owner.Left + ((Owner.Width - Width) \ 2)
        Dim y As Integer = Owner.Top + ((Owner.Height - Height) \ 2)
        Location = New Point(Math.Max(Owner.Left, x), Math.Max(Owner.Top, y))
    End Sub

    Private Sub ProgressTimer_Tick(sender As Object, e As EventArgs)
        If progressTrack.Width <= 0 Then Return

        progressFill.Width = Math.Max(92, progressTrack.Width \ 3)
        Dim maxLeft As Integer = Math.Max(0, progressTrack.Width - progressFill.Width)
        Dim nextLeft As Integer = progressFill.Left + (8 * progressDirection)

        If nextLeft >= maxLeft Then
            nextLeft = maxLeft
            progressDirection = -1
        ElseIf nextLeft <= 0 Then
            nextLeft = 0
            progressDirection = 1
        End If

        progressFill.Left = nextLeft
    End Sub

    Private Sub Header_MouseDown(sender As Object, e As MouseEventArgs) Handles headerPanel.MouseDown, Lbl_Title.MouseDown
        If e.Button <> MouseButtons.Left Then Return
        dragOffset = New Point(e.X, e.Y)
    End Sub

    Private Sub Header_MouseMove(sender As Object, e As MouseEventArgs) Handles headerPanel.MouseMove, Lbl_Title.MouseMove
        If e.Button <> MouseButtons.Left Then Return
        Location = New Point(Location.X + e.X - dragOffset.X, Location.Y + e.Y - dragOffset.Y)
    End Sub
End Class
