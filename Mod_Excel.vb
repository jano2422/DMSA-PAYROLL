Imports System.Globalization
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Excel

Module Mod_Excel
    Public Sub Connect_to_Excel_DTR()


        ' Create an instance of Excel application
        Dim excelApp As New Application()

        ' Open the Excel file
        'Dim workbook As Workbook = excelApp.Workbooks.Open("D:\01 - Software Development\Delta Maroon Security Agency\DMSA_System\bin\Debug\PdfToExcel.xlsx")
        Dim workbook As Workbook = excelApp.Workbooks.Open("C:\Users\johnc\Downloads\Software Projects\Project 1\DMSA_System\bin\Debug\PdfToExcel.xlsx")
        'Dim workbook As Workbook = excelApp.Workbooks.Open("Z:\DMSA_SYSTEM\Reports\PdfToExcel.xlsx")

        ' Assuming data is in the first worksheet, you can change this according to your need
        Dim worksheet As Worksheet = workbook.Sheets(1)

        Try


            With FRM_DTR_BIOMETRIC

                For i = 1 To 17
                    .GView_DTR.Rows.Add()
                Next

                .Lbl_Name.Text = worksheet.Cells(10, 3).Value
                .Lbl_Period.Text = Mid(worksheet.Cells(6, 3).Value, 8, 20)

                ' Find the location of "Date" in cells
                Dim iCol_Date As Integer

                For iCol = 12 To 14
                    If worksheet.Cells(9, iCol).Value = "Date" Then ' This is the start reference
                        iCol_Date = iCol ' Column where "Date" is located 
                        Exit For
                    End If
                Next

                If .Chk_NighShift.Checked = True Then

                    Rearrange_Excel_NS_DTR(excelApp, workbook, worksheet, iCol_Date)

                Else

                    'Populate DatagridView DTR Columns (1 to 2)
                    If worksheet.Cells(9, iCol_Date).Value = "Date" Then

                        For iRow = 10 To 26 ' Number of Days in Cut-Off
                            For iCol = iCol_Date To iCol_Date + 1 ' First 2 Column from DTR Excel

                                .GView_DTR.Rows(iRow - 10).Cells(iCol - iCol_Date).Value = worksheet.Cells(iRow, iCol).Value

                            Next
                        Next

                        ' Time In and Out
                        Dim Col_Y As Integer

                        'Col_Y ref column for time in and out of excel file
                        Col_Y = iCol_Date + 1

                        'iRow = rows of date time values
                        For iRow = 10 To 26
                            For iCol = iCol_Date + 2 To 30 Step 2
                                Col_Y = Col_Y + 1 ' Represents the incrementing Col for Gridview since I can't use the iCol due to FOR with Step 2
                                .GView_DTR.Rows(iRow - 10).Cells(Col_Y - iCol_Date).Value = worksheet.Cells(iRow, iCol).Value

                            Next
                            Col_Y = iCol_Date + 1

                        Next


                    End If

                End If



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

                If windowStart Is Nothing OrElse entryDate > windowEnd Then
                    ' Save the current window
                    If windowStart IsNot Nothing Then
                        processedData.Add(New With {
                        .DateRange = $"{windowStart:MM/dd/yyyy} - {windowEnd:MM/dd/yyyy}",
                        .Days = String.Join("-", days),
                        .TimeInOut = timeInOutData
                        })
                    End If

                    ' Start a new window
                    windowStart = entryDate.Date.AddHours(12)
                    If entryDate.TimeOfDay < TimeSpan.FromHours(12) Then
                        windowStart = windowStart.Value.AddDays(-1) ' Ensure .Value is accessed properly
                    End If
                    If windowStart.HasValue Then
                        windowEnd = windowStart.Value.AddDays(1).AddSeconds(-1)
                    End If
                    days = New List(Of String) From {day}
                    timeInOutData = New List(Of String) From {time}
                Else
                    ' Add to the current window
                    If Not days.Contains(day) Then days.Add(day)
                    timeInOutData.Add(time)
                End If
            Next

            ' Add the last time window
            If windowStart IsNot Nothing Then
                processedData.Add(New With {
                .DateRange = $"{windowStart:MM/dd/yyyy} - {windowEnd:MM/dd/yyyy}",
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

End Module
