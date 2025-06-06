Imports System.Windows.Forms.Integration
Imports DMSA_System.FRM_DTR_BIOMETRIC_WPF_UC  ' Namespace of your WPF UserControl

Public Class FRM_DTR_BIOMETRIC_WINDOW
    Private Sub FRM_DTR_BIOMETRIC_WINDOW_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create an instance of ElementHost
        Dim host As New ElementHost()
        host.Dock = DockStyle.Fill  ' Make it fill the form

        ' Create an instance of your WPF UserControl
        Dim wpfControl As New FRM_DTR_BIOMETRIC_WPF_UC()

        ' Set the hosted control
        host.Child = wpfControl

        ' Add the ElementHost to the form
        Me.Controls.Add(host)
    End Sub
End Class
