Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Module AppNotification
    Public Function MsgBox(Prompt As Object, Optional Buttons As MsgBoxStyle = MsgBoxStyle.OkOnly, Optional Title As Object = Nothing) As MsgBoxResult
        Dim message As String = If(Prompt Is Nothing, "", Prompt.ToString())
        Dim caption As String = If(Title Is Nothing OrElse String.IsNullOrWhiteSpace(Title.ToString()), "DMSA System", Title.ToString())
        Dim result As DialogResult = Show(message, caption, ToMessageBoxButtons(Buttons), ToMessageBoxIcon(Buttons))
        Return ToMsgBoxResult(result)
    End Function

    Public Function Show(message As String, Optional title As String = Nothing, Optional buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional icon As MessageBoxIcon = MessageBoxIcon.None) As DialogResult
        Using dialog As New AppNotificationDialog()
            dialog.Configure(message, If(String.IsNullOrWhiteSpace(title), "DMSA System", title), buttons, icon)
            Dim owner As IWin32Window = ResolveOwner()
            If owner IsNot Nothing Then
                dialog.ShowDialog(owner)
            Else
                dialog.StartPosition = FormStartPosition.CenterScreen
                dialog.ShowDialog()
            End If
            Return dialog.SelectedResult
        End Using
    End Function

    Public Function ShowWpf(message As String, Optional title As String = Nothing, Optional buttons As System.Windows.MessageBoxButton = System.Windows.MessageBoxButton.OK, Optional icon As System.Windows.MessageBoxImage = System.Windows.MessageBoxImage.None) As System.Windows.MessageBoxResult
        Dim result As DialogResult = Show(message, title, ToWinFormsButtons(buttons), ToWinFormsIcon(icon))
        Return ToWpfResult(result)
    End Function

    Private Function ResolveOwner() As IWin32Window
        If Form.ActiveForm IsNot Nothing Then Return Form.ActiveForm
        If Application.OpenForms.Count > 0 Then Return Application.OpenForms(Application.OpenForms.Count - 1)
        Return Nothing
    End Function

    Private Function ToMessageBoxButtons(buttons As MsgBoxStyle) As MessageBoxButtons
        Select Case buttons And CType(&HF, MsgBoxStyle)
            Case MsgBoxStyle.OkCancel
                Return MessageBoxButtons.OKCancel
            Case MsgBoxStyle.AbortRetryIgnore
                Return MessageBoxButtons.AbortRetryIgnore
            Case MsgBoxStyle.YesNoCancel
                Return MessageBoxButtons.YesNoCancel
            Case MsgBoxStyle.YesNo
                Return MessageBoxButtons.YesNo
            Case MsgBoxStyle.RetryCancel
                Return MessageBoxButtons.RetryCancel
            Case Else
                Return MessageBoxButtons.OK
        End Select
    End Function

    Private Function ToMessageBoxIcon(buttons As MsgBoxStyle) As MessageBoxIcon
        If (buttons And MsgBoxStyle.Critical) = MsgBoxStyle.Critical Then Return MessageBoxIcon.Error
        If (buttons And MsgBoxStyle.Exclamation) = MsgBoxStyle.Exclamation Then Return MessageBoxIcon.Warning
        If (buttons And MsgBoxStyle.Question) = MsgBoxStyle.Question Then Return MessageBoxIcon.Question
        If (buttons And MsgBoxStyle.Information) = MsgBoxStyle.Information Then Return MessageBoxIcon.Information
        Return MessageBoxIcon.None
    End Function

    Private Function ToMsgBoxResult(result As DialogResult) As MsgBoxResult
        Select Case result
            Case DialogResult.OK
                Return MsgBoxResult.Ok
            Case DialogResult.Cancel
                Return MsgBoxResult.Cancel
            Case DialogResult.Abort
                Return MsgBoxResult.Abort
            Case DialogResult.Retry
                Return MsgBoxResult.Retry
            Case DialogResult.Ignore
                Return MsgBoxResult.Ignore
            Case DialogResult.Yes
                Return MsgBoxResult.Yes
            Case DialogResult.No
                Return MsgBoxResult.No
            Case Else
                Return MsgBoxResult.Cancel
        End Select
    End Function

    Private Function ToWinFormsButtons(buttons As System.Windows.MessageBoxButton) As MessageBoxButtons
        Select Case buttons
            Case System.Windows.MessageBoxButton.OKCancel
                Return MessageBoxButtons.OKCancel
            Case System.Windows.MessageBoxButton.YesNo
                Return MessageBoxButtons.YesNo
            Case System.Windows.MessageBoxButton.YesNoCancel
                Return MessageBoxButtons.YesNoCancel
            Case Else
                Return MessageBoxButtons.OK
        End Select
    End Function

    Private Function ToWinFormsIcon(icon As System.Windows.MessageBoxImage) As MessageBoxIcon
        If icon = System.Windows.MessageBoxImage.Error OrElse icon = System.Windows.MessageBoxImage.Hand OrElse icon = System.Windows.MessageBoxImage.Stop Then Return MessageBoxIcon.Error
        If icon = System.Windows.MessageBoxImage.Warning OrElse icon = System.Windows.MessageBoxImage.Exclamation Then Return MessageBoxIcon.Warning
        If icon = System.Windows.MessageBoxImage.Question Then Return MessageBoxIcon.Question
        If icon = System.Windows.MessageBoxImage.Information OrElse icon = System.Windows.MessageBoxImage.Asterisk Then Return MessageBoxIcon.Information
        Return MessageBoxIcon.None
    End Function

    Private Function ToWpfResult(result As DialogResult) As System.Windows.MessageBoxResult
        Select Case result
            Case DialogResult.OK
                Return System.Windows.MessageBoxResult.OK
            Case DialogResult.Cancel
                Return System.Windows.MessageBoxResult.Cancel
            Case DialogResult.Yes
                Return System.Windows.MessageBoxResult.Yes
            Case DialogResult.No
                Return System.Windows.MessageBoxResult.No
            Case Else
                Return System.Windows.MessageBoxResult.None
        End Select
    End Function
End Module
