Imports System.Globalization
Imports System.Windows.Data

' Converter to create a list of valid day options (current day and next day) from the DayNumber.
Public Class ShiftEndDayConverter
    Implements IMultiValueConverter

    ' Convert method to return a list of valid day options
    Public Function Convert(values As Object(), targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        ' Check if values is not null and contains the expected DayNumber value
        If values IsNot Nothing AndAlso values.Length > 0 AndAlso values(0) IsNot Nothing Then
            Dim dayNumber As Integer
            ' Attempt to parse the DayNumber value from the first input
            If Integer.TryParse(values(0).ToString(), dayNumber) Then
                ' Return a list containing the current day and the next day
                Return New List(Of Integer) From {dayNumber, dayNumber + 1}
            End If
        End If
        ' If input is invalid or null, return an empty list
        Return New List(Of Integer)()
    End Function

    ' ConvertBack is not implemented because the converter is used for one-way conversion
    Public Function ConvertBack(value As Object, targetTypes As Type(), parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        ' Since this is a one-way conversion, we throw NotImplementedException
        Throw New NotImplementedException()
    End Function
End Class
