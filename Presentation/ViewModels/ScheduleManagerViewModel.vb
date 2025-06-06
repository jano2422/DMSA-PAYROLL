Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows
Imports System.Windows.Input
Imports DMSA_System.Models
Imports DMSA_System.Helpers

Namespace DMSA_System.ViewModels
    Public Class ScheduleManagerViewModel
        Implements INotifyPropertyChanged

        Private _selectedEmployee As Employee
        Private _payrollPeriodIndex As Integer
        Private _scheduleTable As ObservableCollection(Of EmployeeSchedule)

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Public Property SelectedEmployee As Employee
            Get
                Return _selectedEmployee
            End Get
            Set(value As Employee)
                _selectedEmployee = value
                OnPropertyChanged(NameOf(SelectedEmployee))
            End Set
        End Property


        Public Property PayrollPeriodIndex As Integer
            Get
                Return _payrollPeriodIndex
            End Get
            Set(value As Integer)
                _payrollPeriodIndex = value
                OnPropertyChanged(NameOf(PayrollPeriodIndex))
            End Set
        End Property

        Public Property ScheduleTable As ObservableCollection(Of EmployeeSchedule)
            Get
                Return _scheduleTable
            End Get
            Set(value As ObservableCollection(Of EmployeeSchedule))
                _scheduleTable = value
                OnPropertyChanged(NameOf(ScheduleTable))
            End Set
        End Property

        Public Property SaveScheduleCommand As ICommand

        Public Sub New()
            ScheduleTable = New ObservableCollection(Of EmployeeSchedule) From {
            New EmployeeSchedule With {.DayNumber = 1, .ShiftStartDateTime = DateTime.Today.AddHours(8), .ShiftEndDateTime = DateTime.Today.AddHours(16), .ShiftType = "Morning", .TotalHours = 8},
            New EmployeeSchedule With {.DayNumber = 2, .ShiftStartDateTime = DateTime.Today.AddHours(16), .ShiftEndDateTime = DateTime.Today.AddHours(0), .ShiftType = "Night", .TotalHours = 8}
        }

            SaveScheduleCommand = New RelayCommand(AddressOf SaveSchedule)
        End Sub

        Private Sub SaveSchedule()
            ' Logic to save schedule to database or file
        End Sub

        Protected Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

    End Class
End Namespace
