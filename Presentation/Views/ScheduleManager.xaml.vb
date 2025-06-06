Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace DMSA_System
    Public Class ScheduleManager
        Inherits Window
        Public Sub New()
            InitializeComponent()
            DataContext = New ViewModels.ScheduleManagerViewModel()
        End Sub
        Private Sub EmployeeSearchTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles EmployeeSearchTextBox.KeyDown
            If e.Key = Key.Down Then
                EmployeeListBox.Focus()
                EmployeeListBox.SelectedIndex = 0
            ElseIf e.Key = Key.Enter AndAlso EmployeeListBox.SelectedItem IsNot Nothing Then
            End If
        End Sub
        Private Sub EmployeeListBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            EmployeeSearchPopup.IsOpen = False
        End Sub

    End Class
End Namespace
