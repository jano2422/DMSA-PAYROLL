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

                .DTR_Lbl_Period.Text = worksheet.Cells(6, 3).Value
                .Lbl_IDNumber.Text = GlobalVariables.DTR_Selected_Employee_ID
                .Lbl_Name.Text = worksheet.Cells(10, 3).Value


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
                    ' Skip the current row if the date is invalid
                    Console.WriteLine($"Skipping invalid date at Row {rowIndex}: {rawDateValue}")
                    rowIndex += 1
                    Continue While
                End If

                ' If the date is valid, process the row
                Dim day As String = worksheet.Cells(rowIndex, refDateTimeCol + 1).Value

                For TimeCol = refDateTimeCol + 2 To 30
                    Dim time As String = worksheet.Cells(rowIndex, TimeCol).Value

                    If Not String.IsNullOrEmpty(time) Then
                        Dim parsedTime As TimeSpan

                        ' Attempt to parse the time
                        If DateTime.TryParseExact(time, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, Nothing) Then
                            ' If parsing succeeds, extract the TimeSpan
                            parsedTime = DateTime.ParseExact(time, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay
                            Console.WriteLine($"Parsed TimeSpan: {parsedTime}")

                            ' Add the parsed data to rawData
                            rawData.Add(Tuple.Create(dateValue.Add(parsedTime), day, time))
                        Else
                            ' Handle invalid time format
                            Console.WriteLine($"Invalid time format at Row {rowIndex}, Column {TimeCol}: {time}")
                        End If
                    End If
                Next


                rowIndex += 1
            End While


            Dim firstRawDataItem As Tuple(Of DateTime, String, String) = rawData.OrderBy(Function(x) x.Item1).FirstOrDefault()
            Dim sFlagShift As String
            If firstRawDataItem IsNot Nothing Then
                ' Extract the day number from the DateTime value (e.g., "10" from "12/10/2024")
                Dim dayNumber As Integer = firstRawDataItem.Item1.Day
                Dim iDTR_Month_Num As Integer = firstRawDataItem.Item1.Month
                Dim iDTR_Year_Num As Integer = firstRawDataItem.Item1.Year

                If dayNumber <= 15 Then
                    GlobalVariables.sPayroll_Cutoff = iDTR_Month_Num & "_" & "1st_" & iDTR_Year_Num
                ElseIf dayNumber >= 16 Then
                    GlobalVariables.sPayroll_Cutoff = iDTR_Month_Num & "_" & "2nd_" & iDTR_Year_Num

                End If

                sFlagShift = Check_All_FlagShift_IfSame_Values(.GView_Schedule, dayNumber)
                Console.WriteLine($"First DateTime: {firstRawDataItem.Item1}")
                Console.WriteLine($"Extracted Day Number: {dayNumber}")
            Else
                MessageBox.Show("Error: No initial date found in DTR file.",
                    "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If



            ' Process data into time windows
            Dim processedData As New List(Of Object)()
            Dim windowStart As DateTime? = Nothing
            Dim windowEnd As DateTime? = Nothing
            Dim timeInOutData As New List(Of String)()
            Dim days As New List(Of String)()

            For Each entry In rawData.OrderBy(Function(x) x.Item1)
                Dim entryDate = entry.Item1
                Dim day = entry.Item2
                Dim time = entry.Item1

                If sFlagShift = "NS" Then
                    ' Night shift logic
                    If windowStart Is Nothing OrElse entryDate > windowEnd Then
                        ' Save the current window
                        If windowStart IsNot Nothing Then
                            processedData.Add(New With {
                            .DateRange = $"{windowStart:MM/dd/yyyy} - {windowEnd:MM/dd/yyyy}",
                            .Days = String.Join("-", days),
                            .TimeInOut = timeInOutData
                            })

                        End If

                        ' Start a new window (night shift: 12 PM to 12 PM the next day)
                        windowStart = entryDate.Date.AddHours(12)
                        If entryDate.TimeOfDay < TimeSpan.FromHours(12) Then
                            windowStart = windowStart.Value.AddDays(-1) ' Adjust for night shift
                        End If
                        windowEnd = windowStart.Value.AddDays(1).AddSeconds(-1)

                        days = New List(Of String) From {day}
                        timeInOutData = New List(Of String) From {time}
                    Else
                        ' Add to the current window
                        If Not days.Contains(day) Then days.Add(day)
                        timeInOutData.Add(time)
                    End If
                ElseIf sFlagShift = "MS" Then
                    ' Day shift logic (00:00 to 24:00 of the same day)
                    If windowStart Is Nothing OrElse entryDate.Date > windowStart.Value.Date Then
                        ' Save the current window
                        If windowStart IsNot Nothing Then
                            processedData.Add(New With {
                            .DateRange = If(windowStart.Value.Date = windowEnd.Value.Date,
                                    $"{windowStart:MM/dd/yyyy}", ' Single date
                                    $"{windowStart:MM/dd/yyyy} - {windowEnd:MM/dd/yyyy}"), ' Range for night shift
                            .Days = String.Join("-", days),
                            .TimeInOut = timeInOutData
                            })

                        End If

                        ' Start a new window (day shift: 00:00 to 24:00 of the same day)
                        windowStart = entryDate.Date ' Start at 00:00 of the current day
                        windowEnd = windowStart.Value.AddDays(1).AddSeconds(-1) ' End at 23:59:59 of the same day

                        days = New List(Of String) From {day}
                        timeInOutData = New List(Of String) From {time}
                    Else
                        ' Add to the current window
                        If Not days.Contains(day) Then days.Add(day)
                        timeInOutData.Add(time)
                    End If

                Else
                    MessageBox.Show("Error: Flag Shift Schedule Found.",
                    "No MS/NS Found on Schedule Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            ' Add the last time window
            If windowStart IsNot Nothing Then
                processedData.Add(New With {
                .DateRange = If(windowStart.Value.Date = windowEnd.Value.Date,
                        $"{windowStart:MM/dd/yyyy}", ' Single date
                        $"{windowStart:MM/dd/yyyy} - {windowEnd:MM/dd/yyyy}"), ' Range for night shift
                .Days = String.Join("-", days),
                .TimeInOut = timeInOutData
                })
            End If


            Dim existingRowIndex As Integer = 0
            For Each entry In processedData
                ' Find the row index that matches the entry, assuming you have a unique key like DateRange
                ' For example, if DateRange is the first column, you can search for it
                ' Update the row with the new data
                .GView_DTR.Rows(existingRowIndex).Cells(0).Value = entry.DateRange
                .GView_DTR.Rows(existingRowIndex).Cells(1).Value = entry.Days

                ' Update Time In/Out columns (assuming 2nd column is the Days column and 3rd to 8th are the Time In/Out columns)
                For i = 0 To 6 ' Adjust the range depending on the number of Time In/Out columns you have
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
    Public Function Check_All_FlagShift_IfSame_Values(DGVIEW_DTR_BIOMETRIC_SCHED As DataGridView, FirstDayNum As Integer) As String
        Dim allMatch As Boolean = True ' Variable to check if all are the same
        Dim flagShifts As New List(Of String)() ' Store all matched cell(4) values

        ' Determine range to check in DGVIEW_DTR_BIOMETRIC_SCHED based on DayNum
        Dim validRange As IEnumerable(Of DataGridViewRow) = Nothing

        If FirstDayNum >= 1 AndAlso FirstDayNum <= 15 Then
            ' If DayNum is between 1-15, check rows with cells(0) between 0-14
            validRange = DGVIEW_DTR_BIOMETRIC_SCHED.Rows.Cast(Of DataGridViewRow)().Where(Function(r) Not r.IsNewRow AndAlso Integer.TryParse(r.Cells(0)?.Value?.ToString(), New Integer()) AndAlso Integer.Parse(r.Cells(0)?.Value?.ToString()) >= 0 AndAlso Integer.Parse(r.Cells(0)?.Value?.ToString()) <= 14)
        ElseIf FirstDayNum >= 16 AndAlso FirstDayNum <= 31 Then
            ' If DayNum is between 16-31, check rows with cells(0) between 16-31
            validRange = DGVIEW_DTR_BIOMETRIC_SCHED.Rows.Cast(Of DataGridViewRow)().Where(Function(r) Not r.IsNewRow AndAlso Integer.TryParse(r.Cells(0)?.Value?.ToString(), New Integer()) AndAlso Integer.Parse(r.Cells(0)?.Value?.ToString()) >= 16 AndAlso Integer.Parse(r.Cells(0)?.Value?.ToString()) <= 31)
        Else
            ' DayNum is out of expected range
            Return Nothing
        End If

        ' Loop through each valid range row
        For Each row In validRange
            Dim schedDayNum As String = row.Cells(0)?.Value?.ToString()
            If Not String.IsNullOrWhiteSpace(schedDayNum) Then
                Dim cell4Value = row.Cells(4)?.Value?.ToString()
                If Not String.IsNullOrWhiteSpace(cell4Value) Then
                    flagShifts.Add(cell4Value) ' Store matched value
                Else
                    allMatch = False
                    Exit For
                End If
            Else
                allMatch = False
                Exit For
            End If
        Next

        ' Verify if all values in flagShifts are the same
        If flagShifts.Count > 0 AndAlso allMatch Then
            Dim uniqueValues = flagShifts.Distinct().ToList()
            If uniqueValues.Count = 1 Then
                Return uniqueValues(0) ' Return the matched value
            Else
                Return Nothing ' If values are not the same
            End If
        Else
            Return Nothing
        End If
    End Function

End Module
