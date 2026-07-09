Imports System.Drawing
Imports System.Windows.Forms

Public Class AppNotificationDialog
    Private Const DropShadowClassStyle As Integer = &H20000
    Private Shared ReadOnly DialogBorderColor As Color = Color.FromArgb(55, 65, 81)
    Private Shared ReadOnly HeaderColor As Color = Color.FromArgb(38, 50, 56)
    Private Shared ReadOnly BrandPeachColor As Color = Color.FromArgb(255, 224, 192)
    Private Shared ReadOnly SurfaceColor As Color = BrandPeachColor
    Private Shared ReadOnly FooterColor As Color = BrandPeachColor
    Private Shared ReadOnly PrimaryButtonColor As Color = Color.FromArgb(0, 128, 128)
    Private Shared ReadOnly PrimaryButtonHoverColor As Color = Color.FromArgb(0, 105, 105)
    Private Shared ReadOnly SecondaryButtonBorderColor As Color = Color.FromArgb(180, 190, 195)
    Private _dragOffset As Point

    Public Property SelectedResult As DialogResult = DialogResult.Cancel

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim parameters = MyBase.CreateParams
            parameters.ClassStyle = parameters.ClassStyle Or DropShadowClassStyle
            Return parameters
        End Get
    End Property

    Public Sub Configure(message As String, title As String, buttons As MessageBoxButtons, icon As MessageBoxIcon)
        Lbl_Title.Text = If(String.IsNullOrWhiteSpace(title), "DMSA System", title)
        Text = Lbl_Title.Text
        Lbl_Message.Text = message

        Dim accent As Color = ResolveAccentColor(icon)
        BackColor = DialogBorderColor
        rootPanel.BackColor = SurfaceColor
        bodyPanel.BackColor = SurfaceColor
        footerPanel.BackColor = FooterColor
        headerPanel.BackColor = HeaderColor
        Btn_Close.BackColor = HeaderColor
        accentPanel.BackColor = accent
        Lbl_Icon.BackColor = accent
        Lbl_Icon.ForeColor = Color.White
        Lbl_Icon.Text = ResolveIconText(icon)

        ConfigureButtons(buttons)
        FitToMessage()
    End Sub

    Private Sub ConfigureButtons(buttons As MessageBoxButtons)
        footerPanel.Controls.Clear()
        AcceptButton = Nothing
        CancelButton = Nothing

        Select Case buttons
            Case MessageBoxButtons.OKCancel
                AddDialogButton("Cancel", DialogResult.Cancel, False)
                AddDialogButton("OK", DialogResult.OK, True)
            Case MessageBoxButtons.YesNo
                AddDialogButton("No", DialogResult.No, False)
                AddDialogButton("Yes", DialogResult.Yes, True)
            Case MessageBoxButtons.YesNoCancel
                AddDialogButton("Cancel", DialogResult.Cancel, False)
                AddDialogButton("No", DialogResult.No, False)
                AddDialogButton("Yes", DialogResult.Yes, True)
            Case MessageBoxButtons.RetryCancel
                AddDialogButton("Cancel", DialogResult.Cancel, False)
                AddDialogButton("Retry", DialogResult.Retry, True)
            Case MessageBoxButtons.AbortRetryIgnore
                AddDialogButton("Ignore", DialogResult.Ignore, False)
                AddDialogButton("Retry", DialogResult.Retry, True)
                AddDialogButton("Abort", DialogResult.Abort, False)
            Case Else
                AddDialogButton("OK", DialogResult.OK, True)
        End Select
    End Sub

    Private Sub AddDialogButton(text As String, result As DialogResult, isPrimary As Boolean)
        Dim button As New Button With {
            .Text = text,
            .Width = 98,
            .Height = 34,
            .Margin = New Padding(8, 0, 0, 0),
            .DialogResult = result,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Verdana", 9.25!, If(isPrimary, FontStyle.Bold, FontStyle.Regular)),
            .BackColor = If(isPrimary, PrimaryButtonColor, Color.White),
            .ForeColor = If(isPrimary, Color.White, Color.FromArgb(30, 30, 30)),
            .UseVisualStyleBackColor = False
        }

        button.FlatAppearance.BorderColor = If(isPrimary, PrimaryButtonColor, SecondaryButtonBorderColor)
        button.FlatAppearance.BorderSize = 1
        button.FlatAppearance.MouseOverBackColor = If(isPrimary, PrimaryButtonHoverColor, Color.FromArgb(235, 241, 243))
        button.FlatAppearance.MouseDownBackColor = If(isPrimary, Color.FromArgb(0, 90, 90), Color.FromArgb(223, 232, 235))
        AddHandler button.Click, AddressOf DialogButton_Click
        footerPanel.Controls.Add(button)

        If isPrimary AndAlso AcceptButton Is Nothing Then AcceptButton = button
        If result = DialogResult.Cancel Then CancelButton = button
    End Sub

    Private Sub DialogButton_Click(sender As Object, e As EventArgs)
        Dim button = DirectCast(sender, Button)
        SelectedResult = button.DialogResult
        DialogResult = button.DialogResult
        Close()
    End Sub

    Private Function ResolveAccentColor(icon As MessageBoxIcon) As Color
        Select Case icon
            Case MessageBoxIcon.Error, MessageBoxIcon.Hand, MessageBoxIcon.Stop
                Return Color.FromArgb(176, 50, 42)
            Case MessageBoxIcon.Warning, MessageBoxIcon.Exclamation
                Return Color.FromArgb(194, 108, 0)
            Case MessageBoxIcon.Question
                Return Color.FromArgb(44, 96, 154)
            Case Else
                Return Color.Teal
        End Select
    End Function

    Private Function ResolveIconText(icon As MessageBoxIcon) As String
        Select Case icon
            Case MessageBoxIcon.Error, MessageBoxIcon.Hand, MessageBoxIcon.Stop
                Return "X"
            Case MessageBoxIcon.Warning, MessageBoxIcon.Exclamation
                Return "!"
            Case MessageBoxIcon.Question
                Return "?"
            Case Else
                Return "i"
        End Select
    End Function

    Private Sub FitToMessage()
        Dim messageWidth As Integer = Math.Min(580, Math.Max(380, TextRenderer.MeasureText(Lbl_Message.Text, Lbl_Message.Font).Width + 150))
        Dim measured = TextRenderer.MeasureText(Lbl_Message.Text, Lbl_Message.Font, New Size(messageWidth - 122, 0), TextFormatFlags.WordBreak)
        Width = messageWidth
        Height = Math.Min(380, Math.Max(220, measured.Height + 158))
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click
        SelectedResult = DialogResult.Cancel
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub Header_MouseDown(sender As Object, e As MouseEventArgs) Handles headerPanel.MouseDown, Lbl_Title.MouseDown
        If e.Button <> MouseButtons.Left Then Return
        _dragOffset = New Point(e.X, e.Y)
    End Sub

    Private Sub Header_MouseMove(sender As Object, e As MouseEventArgs) Handles headerPanel.MouseMove, Lbl_Title.MouseMove
        If e.Button <> MouseButtons.Left Then Return
        Location = New Point(Location.X + e.X - _dragOffset.X, Location.Y + e.Y - _dragOffset.Y)
    End Sub
End Class
