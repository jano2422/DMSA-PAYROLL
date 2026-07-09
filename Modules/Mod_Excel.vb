Imports System.Globalization
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Excel

Module Mod_Excel
    Public Sub Connect_to_Excel_DTR()


        ' Create an instance of Excel application
        Dim excelApp As New Application()

        ' Open the Excel file
        'Dim workbook As Workbook = excelApp.Workbooks.Open("D:\01 - Software Development\Delta Maroon Security Agency\DMSA_System\bin\Debug\PdfToExcel.xlsx")

        'Dim workbook As Workbook = excelApp.Workbooks.Open("C:\Users\johnc\Downloads\Software Projects\Project 1\DMSA_System\bin\Debug\PdfToExcel.xlsx") - original
        Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory
        Dim pdfToExcelPath As String = System.IO.Path.Combine(exeDirectory, "PdfToExcel.xlsx")

        Dim workbook As Workbook = excelApp.Workbooks.Open(pdfToExcelPath)

        'Dim workbook As Workbook = excelApp.Workbooks.Open("Z:\DMSA_SYSTEM\Reports\PdfToExcel.xlsx")

        ' Assuming data is in the first worksheet, you can change this according to your need
        Dim worksheet As Worksheet = workbook.Sheets(1)

        Try


            With FRM_DTR_BIOMETRIC
                .GView_DTR.Rows.Clear()
                For i = 1 To 18
                    .GView_DTR.Rows.Add()
                Next

                .DTR_Lbl_Period.Text = Convert.ToString(worksheet.Cells(6, 3).Value)


                ' Find the location of "Date" in cells
                Dim iCol_Date As Integer

                For iCol = 12 To 40
                    If worksheet.Cells(9, iCol).Value = "Date" Then ' This is the start reference
                        iCol_Date = iCol ' Column where "Date" is located 
                        Exit For
                    End If
                Next

                Rearrange_Excel_NS_DTR(excelApp, workbook, worksheet, iCol_Date)


            End With

            ' Close Excel
            If workbook IsNot Nothing Then
                workbook.Close(SaveChanges:=False)
                workbook = Nothing
            End If
            If excelApp IsNot Nothing Then
                excelApp.Quit()
                excelApp = Nothing
            End If
            GC.Collect()
            GC.WaitForPendingFinalizers()
        Catch ex As Exception

            ' Close Excel
            If workbook IsNot Nothing Then
                workbook.Close(SaveChanges:=False)
                workbook = Nothing
            End If
            If excelApp IsNot Nothing Then
                excelApp.Quit()
                excelApp = Nothing
            End If
            GC.Collect()
            GC.WaitForPendingFinalizers()

        End Try


    End Sub
    Private Function GetPreviousNearest12Hour(dt As DateTime) As DateTime
        Dim snapped = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
        If dt.Hour >= 12 Then
            snapped = snapped.AddHours(12) ' Go to 12:00 PM
        End If
        Return snapped
    End Function

    Private Function GetNextNearest12Hour(dt As DateTime) As DateTime
        Dim snapped = New DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0)
        If dt.Hour < 12 Then
            snapped = snapped.AddHours(12) ' Next is 12:00 PM
        Else
            snapped = snapped.AddDays(1) ' Next is tomorrow 12:00 AM
        End If
        Return snapped
    End Function

    Private Sub Rearrange_Excel_NS_DTR(excelApp As Application, workbook As Workbook, worksheet As Worksheet, refDateTimeCol As Integer)
        With FRM_DTR_BIOMETRIC
            ' Read data from Excel
            Dim rawData As New List(Of Tuple(Of DateTime, String, String))()
            Dim rowIndex As Integer = 10 ' Reference row for DATE/TIME

            While worksheet.Cells(rowIndex, refDateTimeCol).Value IsNot Nothing
                Dim rawDateValue As String = worksheet.Cells(rowIndex, refDateTimeCol).Value
                Dim dateValue As DateTime
                Dim isDateParsed As Boolean = DateTime.TryParseExact(rawDateValue, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue)

                If Not isDateParsed Then
                    Console.WriteLine($"Skipping invalid date at Row {rowIndex}: {rawDateValue}")
                    rowIndex += 1
                    Continue While
                End If

                Dim day As String = worksheet.Cells(rowIndex, refDateTimeCol + 1).Value

                For TimeCol = refDateTimeCol + 2 To 30
                    Dim time As String = worksheet.Cells(rowIndex, TimeCol).Value
                    If Not String.IsNullOrEmpty(time) Then
                        Dim parsedTime As TimeSpan
                        If DateTime.TryParseExact(time, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, Nothing) Then
                            parsedTime = DateTime.ParseExact(time, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay
                            rawData.Add(Tuple.Create(dateValue.Add(parsedTime), day, time))
                        Else
                            Console.WriteLine($"Invalid time format at Row {rowIndex}, Column {TimeCol}: {time}")
                        End If
                    End If
                Next
                rowIndex += 1
            End While
            ' Process data into time windows based on DataGridView schedule
            Dim processedData As New List(Of Object)()
            Dim previousWindowEnd As DateTime? = Nothing

            ' Loop through all rows in the schedule DataGridView
            For i As Integer = 0 To .GView_Schedule.Rows.Count - 1
                Dim row = .GView_Schedule.Rows(i)

                ' Only process rows with valid schedule and hours > 0
                If row.Cells(0).Value IsNot Nothing AndAlso
       row.Cells(1).Value IsNot Nothing AndAlso
       row.Cells(2).Value IsNot Nothing AndAlso
       row.Cells(3).Value IsNot Nothing AndAlso
       row.Cells(4).Value IsNot Nothing AndAlso
       IsNumeric(row.Cells(4).Value) AndAlso
       Convert.ToDouble(row.Cells(4).Value) > 0 Then

                    ' Extract schedule day numbers and time strings
                    Dim dayNumIn As Integer = Convert.ToInt32(row.Cells(0).Value)
                    Dim schedInTime As String = row.Cells(1).Value.ToString()
                    Dim dayNumOut As Integer = Convert.ToInt32(row.Cells(2).Value)
                    Dim schedOutTime As String = row.Cells(3).Value.ToString()

                    ' Only proceed if there is time-in/out raw data
                    If rawData.Count > 0 Then
                        ' Get date information from the first raw entry
                        Dim dayNumber As Integer = rawData(0).Item1.Day
                        Dim iDTR_Year_Num As Integer = rawData(0).Item1.Year
                        Dim iDTR_Month_Num As Integer = rawData(0).Item1.Month
                        Dim daysInMonth As Integer = DateTime.DaysInMonth(iDTR_Year_Num, iDTR_Month_Num)

                        ' Set payroll cutoff based on day of month
                        If dayNumber <= 15 Then
                            GlobalVariables.sPayroll_Cutoff = iDTR_Month_Num & "_" & "1st_" & iDTR_Year_Num
                        ElseIf dayNumber >= 16 Then
                            GlobalVariables.sPayroll_Cutoff = iDTR_Month_Num & "_" & "2nd_" & iDTR_Year_Num
                        End If

                        ' Skip if sched-in date is invalid
                        If dayNumIn > daysInMonth Then Continue For

                        ' Build DateTime object for schedule in
                        Dim schedInDate As New DateTime(iDTR_Year_Num, iDTR_Month_Num, dayNumIn,
                                            Convert.ToDateTime(schedInTime).Hour,
                                            Convert.ToDateTime(schedInTime).Minute, 0)

                        Dim schedOutDate As DateTime

                        ' If sched-out day is still within the month
                        If dayNumOut <= daysInMonth Then
                            schedOutDate = New DateTime(iDTR_Year_Num, iDTR_Month_Num, dayNumOut,
                                            Convert.ToDateTime(schedOutTime).Hour,
                                            Convert.ToDateTime(schedOutTime).Minute, 0)
                        Else
                            ' Handle sched-out dates that fall into next month/year
                            Dim nextMonth As Integer = iDTR_Month_Num + 1
                            Dim nextYear As Integer = iDTR_Year_Num

                            If nextMonth > 12 Then
                                nextMonth = 1
                                nextYear += 1
                            End If

                            ' Adjust overflow day
                            Dim adjustedDay As Integer = dayNumOut - daysInMonth
                            Dim daysInNextMonth As Integer = DateTime.DaysInMonth(nextYear, nextMonth)

                            ' Skip if adjusted day is invalid
                            If adjustedDay > daysInNextMonth Then Continue For

                            schedOutDate = New DateTime(nextYear, nextMonth, adjustedDay,
                                            Convert.ToDateTime(schedOutTime).Hour,
                                            Convert.ToDateTime(schedOutTime).Minute, 0)
                        End If

                        ' Determine window start: previous end if exists, else nearest 12-hour before sched-in
                        Dim windowStart As DateTime = If(previousWindowEnd.HasValue, previousWindowEnd.Value, GetPreviousNearest12Hour(schedInDate))
                        Dim windowEnd As DateTime = schedOutDate ' initial window end

                        ' Try to find the next valid schedule row to calculate mid-window
                        Dim nextValidRow As DataGridViewRow = Nothing
                        For j As Integer = i + 1 To .GView_Schedule.Rows.Count - 1
                            Dim possibleRow = .GView_Schedule.Rows(j)
                            If possibleRow.Cells(0).Value IsNot Nothing AndAlso
                   possibleRow.Cells(1).Value IsNot Nothing AndAlso
                   possibleRow.Cells(4).Value IsNot Nothing AndAlso
                   IsNumeric(possibleRow.Cells(4).Value) AndAlso
                   Convert.ToDouble(possibleRow.Cells(4).Value) > 0 Then

                                Dim nextDayNumIn As Integer = Convert.ToInt32(possibleRow.Cells(0).Value)
                                If nextDayNumIn <= daysInMonth Then
                                    nextValidRow = possibleRow
                                    Exit For
                                End If
                            End If
                        Next

                        ' If next valid schedule found, compute the midpoint between current out and next in
                        If nextValidRow IsNot Nothing Then
                            Dim nextDayNumIn As Integer = Convert.ToInt32(nextValidRow.Cells(0).Value)
                            Dim nextSchedInTime As String = nextValidRow.Cells(1).Value.ToString()
                            Dim nextSchedInDate As New DateTime(iDTR_Year_Num, iDTR_Month_Num, nextDayNumIn,
                                                    Convert.ToDateTime(nextSchedInTime).Hour,
                                                    Convert.ToDateTime(nextSchedInTime).Minute, 0)

                            windowEnd = schedOutDate.AddSeconds((nextSchedInDate - schedOutDate).TotalSeconds / 2)
                        Else
                            ' Else set next nearest 12-hour mark after sched-out
                            windowEnd = GetNextNearest12Hour(schedOutDate)
                        End If

                        ' Store this window’s end to be used in the next iteration
                        previousWindowEnd = windowEnd

                        ' Find raw punches between the calculated window start and end
                        Dim timeInOutData As New List(Of String)()
                        For Each entry In rawData
                            If entry.Item1 >= windowStart AndAlso entry.Item1 <= windowEnd Then
                                timeInOutData.Add(entry.Item1.ToString())
                            End If
                        Next

                        ' If any punches found in the window, add processed data to the result
                        If timeInOutData.Count > 0 Then
                            processedData.Add(New With {
                    .DateRange = If(schedInDate.Date = schedOutDate.Date,
                                    String.Format("{0:MM/dd/yyyy}", schedInDate),
                                    String.Format("{0:MM/dd/yyyy} - {1:MM/dd/yyyy}", schedInDate, schedOutDate)),
                    .Days = If(schedInDate.Date = schedOutDate.Date,
                               schedInDate.DayOfWeek.ToString(),
                               schedInDate.DayOfWeek.ToString() & " - " & schedOutDate.DayOfWeek.ToString()),
                    .Start = windowStart,
                    .End = windowEnd,
                    .TimeInOut = timeInOutData
                })
                        End If
                    End If
                End If
            Next




            Dim existingRowIndex As Integer = 0
            For Each entry In processedData
                ' Find the row index that matches the entry, assuming you have a unique key like DateRange
                ' For example, if DateRange is the first column, you can search for it
                ' Update the row with the new data
                .GView_DTR.Rows(existingRowIndex).Cells(0).Value = entry.DateRange
                .GView_DTR.Rows(existingRowIndex).Cells(1).Value = entry.Days

                ' Update Time In/Out columns (assuming 2nd column is the Days column and 3rd to 8th are the Time In/Out columns)
                For i = 0 To 7 ' Adjust the range depending on the number of Time In/Out columns you have
                    If i < entry.TimeInOut.Count Then
                        .GView_DTR.Rows(existingRowIndex).Cells(i + 2).Value = entry.TimeInOut(i) ' +2 to start from the 3rd column (index 2)
                    Else
                        .GView_DTR.Rows(existingRowIndex).Cells(i + 2).Value = "" ' Clear the cell if no time data
                    End If
                Next
                existingRowIndex += 1
            Next
        End With
    End Sub

End Module
