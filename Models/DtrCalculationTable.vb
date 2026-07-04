Imports System.Data

Namespace Models
    Public Enum DtrCalculationMetric
        TotalHours
        RegularHours
        SundayHours
        SpecialHolidayHours
        LegalHolidayHours
        RegularOvertimeHours
        LateHours
        BreaktimeHours
    End Enum

    Public Class DtrDayCalculation
        Public Property ReportDate As Date
        Public Property ReportDay As String
        Public Property LateMinutes As Decimal
        Public Property TotalBreakMinutes As Decimal
        Public Property OverBreakMinutes As Decimal
        Public Property OvertimeMinutes As Decimal
        Public Property TotalHours As Decimal
        Public Property RegularHours As Decimal
        Public Property SundayHours As Decimal
        Public Property SpecialHolidayHours As Decimal
        Public Property LegalHolidayHours As Decimal
        Public Property RegularOvertimeHours As Decimal
        Public Property Classification As String
    End Class

    Public Class DtrCalculationTable
        Private ReadOnly calculationsByDate As New Dictionary(Of Date, DtrDayCalculation)

        Public Sub Clear()
            calculationsByDate.Clear()
        End Sub

        Public Function Upsert(reportDate As Date, reportDay As String) As DtrDayCalculation
            Dim key = reportDate.Date
            Dim calculation As DtrDayCalculation = Nothing

            If Not calculationsByDate.TryGetValue(key, calculation) Then
                calculation = New DtrDayCalculation With {.ReportDate = key}
                calculationsByDate.Add(key, calculation)
            End If

            calculation.ReportDay = If(reportDay, String.Empty)
            Return calculation
        End Function

        Public Function TryGet(reportDate As Date, ByRef calculation As DtrDayCalculation) As Boolean
            Return calculationsByDate.TryGetValue(reportDate.Date, calculation)
        End Function

        Public ReadOnly Property Rows As IEnumerable(Of DtrDayCalculation)
            Get
                Return calculationsByDate.Values.OrderBy(Function(row) row.ReportDate).ToList()
            End Get
        End Property

        Public Sub ResetHourBreakdown()
            For Each calculation In calculationsByDate.Values
                calculation.RegularHours = 0D
                calculation.SundayHours = 0D
                calculation.SpecialHolidayHours = 0D
                calculation.LegalHolidayHours = 0D
                calculation.RegularOvertimeHours = 0D
                calculation.Classification = String.Empty
            Next
        End Sub

        Public Function TotalFor(metric As DtrCalculationMetric) As Decimal
            Return calculationsByDate.Values.Sum(Function(calculation) MetricValue(calculation, metric))
        End Function

        Public Function ToBreakdownTable(coveredDates As IEnumerable(Of Date)) As DataTable
            Dim table As New DataTable("DtrCalculationBreakdown")
            table.Columns.Add("BreakdownLabel", GetType(String))
            table.Columns.Add("Total", GetType(Decimal))

            Dim dates = If(coveredDates, Enumerable.Empty(Of Date)()).
                Select(Function(d) d.Date).
                Distinct().
                OrderBy(Function(d) d).
                ToList()

            For Each coveredDate In dates
                table.Columns.Add(DateColumnName(coveredDate), GetType(Decimal))
            Next

            For Each metric In BreakdownMetrics()
                Dim row = table.NewRow()
                row("BreakdownLabel") = MetricLabel(metric)

                Dim rowTotal As Decimal = 0D
                For Each coveredDate In dates
                    Dim calculation As DtrDayCalculation = Nothing
                    Dim value As Decimal = 0D
                    If TryGet(coveredDate, calculation) Then
                        value = MetricValue(calculation, metric)
                        row(DateColumnName(coveredDate)) = value
                        rowTotal += value
                    Else
                        row(DateColumnName(coveredDate)) = DBNull.Value
                    End If
                Next

                row("Total") = rowTotal
                table.Rows.Add(row)
            Next

            Return table
        End Function

        Public Shared Function DateColumnName(d As Date) As String
            Return "D" & d.ToString("yyyyMMdd", Globalization.CultureInfo.InvariantCulture)
        End Function

        Private Shared Function BreakdownMetrics() As DtrCalculationMetric()
            Return New DtrCalculationMetric() {
                DtrCalculationMetric.TotalHours,
                DtrCalculationMetric.RegularHours,
                DtrCalculationMetric.SundayHours,
                DtrCalculationMetric.SpecialHolidayHours,
                DtrCalculationMetric.LegalHolidayHours,
                DtrCalculationMetric.RegularOvertimeHours,
                DtrCalculationMetric.LateHours,
                DtrCalculationMetric.BreaktimeHours
            }
        End Function

        Private Shared Function MetricLabel(metric As DtrCalculationMetric) As String
            Select Case metric
                Case DtrCalculationMetric.TotalHours
                    Return "Total Hours"
                Case DtrCalculationMetric.RegularHours
                    Return "Regular"
                Case DtrCalculationMetric.SundayHours
                    Return "Sunday"
                Case DtrCalculationMetric.SpecialHolidayHours
                    Return "Special Holiday"
                Case DtrCalculationMetric.LegalHolidayHours
                    Return "Legal Holiday"
                Case DtrCalculationMetric.RegularOvertimeHours
                    Return "Overtime"
                Case DtrCalculationMetric.LateHours
                    Return "Late"
                Case DtrCalculationMetric.BreaktimeHours
                    Return "Breaktime"
                Case Else
                    Return metric.ToString()
            End Select
        End Function

        Private Shared Function MetricValue(calculation As DtrDayCalculation, metric As DtrCalculationMetric) As Decimal
            If calculation Is Nothing Then Return 0D

            Select Case metric
                Case DtrCalculationMetric.TotalHours
                    Return calculation.TotalHours
                Case DtrCalculationMetric.RegularHours
                    Return calculation.RegularHours
                Case DtrCalculationMetric.SundayHours
                    Return calculation.SundayHours
                Case DtrCalculationMetric.SpecialHolidayHours
                    Return calculation.SpecialHolidayHours
                Case DtrCalculationMetric.LegalHolidayHours
                    Return calculation.LegalHolidayHours
                Case DtrCalculationMetric.RegularOvertimeHours
                    Return calculation.RegularOvertimeHours
                Case DtrCalculationMetric.LateHours
                    Return MinutesToHours(calculation.LateMinutes)
                Case DtrCalculationMetric.BreaktimeHours
                    Return MinutesToHours(calculation.OverBreakMinutes)
                Case Else
                    Return 0D
            End Select
        End Function

        Private Shared Function MinutesToHours(minutes As Decimal) As Decimal
            Return Math.Round(minutes / 60D, 2)
        End Function
    End Class
End Namespace
