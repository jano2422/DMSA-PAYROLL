Imports System.ComponentModel
Imports System.Windows

Namespace Models
    Public Class EmployeeSchedule
        Implements INotifyPropertyChanged

        Private _employeeID As String
        Private _dayNumber As Integer
        Private _shiftStartDateTime As DateTime
        Private _shiftEndDateTime As DateTime
        Private _shiftType As String
        Private _totalHours As Double

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        ' New Property: EmployeeID
        Public Property EmployeeID As String
            Get
                Return _employeeID
            End Get
            Set(value As String)
                _employeeID = value
                OnPropertyChanged(NameOf(EmployeeID))
            End Set
        End Property

        Public Property DayNumber As Integer
            Get
                Return _dayNumber
            End Get
            Set(value As Integer)
                _dayNumber = value
                OnPropertyChanged(NameOf(DayNumber))
            End Set
        End Property

        Public Property ShiftStartDateTime As DateTime
            Get
                Return _shiftStartDateTime
            End Get
            Set(value As DateTime)
                _shiftStartDateTime = value
                OnPropertyChanged(NameOf(ShiftStartDateTime))
                UpdateTotalHours()
            End Set
        End Property

        Public Property ShiftEndDateTime As DateTime
            Get
                Return _shiftEndDateTime
            End Get
            Set(value As DateTime)
                _shiftEndDateTime = value
                OnPropertyChanged(NameOf(ShiftEndDateTime))
                UpdateTotalHours()
            End Set
        End Property

        Public Property ShiftType As String
            Get
                Return _shiftType
            End Get
            Set(value As String)
                _shiftType = value
                OnPropertyChanged(NameOf(ShiftType))
            End Set
        End Property

        Public Property TotalHours As Double
            Get
                Return _totalHours
            End Get
            Set(value As Double)
                _totalHours = value
                OnPropertyChanged(NameOf(TotalHours))
            End Set
        End Property

        Private Sub UpdateTotalHours()
            If ShiftEndDateTime > ShiftStartDateTime Then
                TotalHours = (ShiftEndDateTime - ShiftStartDateTime).TotalHours
            Else
                TotalHours = (ShiftEndDateTime.AddDays(1) - ShiftStartDateTime).TotalHours
            End If
        End Sub

        Protected Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace
