Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Globalization
Imports System.Text

Module Mod_Biometric_DTR


    Public Sub Calculate_DTR()
        With FRM_DTR_BIOMETRIC

#Region "DTR Attendance and Schedule Processing"
            '============================ DTR Attendance and Schedule Processing ================================
            Try
                ' Check if all rows in the DataGridView are null or empty
                Dim allRowsEmpty = True
                For Each row As DataGridViewRow In .GView_DTR.Rows
                    If row.Cells.Cast(Of DataGridViewCell).Any(Function(cell) Not String.IsNullOrEmpty(CStr(cell?.Value))) Then
                        allRowsEmpty = False
                        Exit For
                    End If
                Next

                ' If all rows are empty, show a message and exit
                If allRowsEmpty Then
                    MsgBox("All rows in the DTR are empty. Please ensure the data is properly loaded before proceeding.", vbExclamation, "No Data")
                    Exit Sub
                End If

                ' Initialize a StringBuilder to track invalid schedule rows
                Dim invalidRows As New StringBuilder()

                ' Iterate through each row in the DTR (Daily Time Record) grid
                For Each row As DataGridViewRow In .GView_DTR.Rows
                    ' Skip rows that are entirely empty
                    Dim isRowEmpty As Boolean = row.Cells.Cast(Of DataGridViewCell)().All(Function(cell) String.IsNullOrWhiteSpace(CStr(cell?.Value))) OrElse
                        String.IsNullOrWhiteSpace(CStr(row.Cells(0)?.Value))

                    If isRowEmpty Then Continue For

                    ' Extract the first date value (in string format) and parse it
                    Dim firstDate As String = GetFirstDate(row.Cells(0)?.Value?.ToString())
                    Dim parsedDate = ParseDate(firstDate)
                    If parsedDate Is Nothing Then Continue For

                    Dim dayOfMonth As Integer = parsedDate.Value.Day

                    ' Skip rows without matching schedule
                    If Not ScheduleExists(dayOfMonth, invalidRows) Then Continue For

                    ' Validate schedule for the given day
                    Dim scheduledTimeIn As String = GetScheduleTime(dayOfMonth, 1)
                    Dim scheduledTimeOut As String = GetScheduleTime(dayOfMonth, 3)
                    ValidateScheduleTimes(dayOfMonth, scheduledTimeIn, scheduledTimeOut, invalidRows)
                Next


                ' If there are any invalid rows, show an error message and exit
                If invalidRows.Length > 0 Then
                    MsgBox($"The following issues were found in the Schedule{vbCrLf}{invalidRows}", vbCritical, "Schedule Error")
                    Exit Sub
                End If

                ' Process Attendance (Present/Absent)
                ProcessAttendance()

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
#End Region

#Region "Break Calculation"
            ' Calculate break durations and excess break time
            CalculateBreaks()
#End Region

#Region "Overtime and Total Hours Calculation"
            ' Calculate overtime, under-time, and total hours worked (including breaks)
            CalculateOvertimeAndTotalHours()
#End Region

        End With
    End Sub


#Region "Helper Functions"
    ' Validate schedule times (throw an error if invalid)
    Private Sub ValidateScheduleTimes(dayNumber As Integer, schedTimeIn As String, schedTimeOut As String, invalidRows As StringBuilder)
        If String.IsNullOrWhiteSpace(schedTimeIn) OrElse String.IsNullOrWhiteSpace(schedTimeOut) Then
            invalidRows.AppendLine($"Day {dayNumber} has missing schedule times.")
        End If
    End Sub
    ' Get schedule time from schedule for dayNumber (1 for time-in, 2 for time-out)
    Private Function GetScheduleTime(dayNumber As Integer, columnIndex As Integer) As String
        For Each schedRow As DataGridViewRow In FRM_DTR_BIOMETRIC.GView_Schedule.Rows
            If schedRow.Cells(0)?.Value?.ToString() = dayNumber.ToString() Then
                Return schedRow.Cells(columnIndex)?.Value?.ToString()
            End If
        Next
        Return String.Empty
    End Function
    ' Check if a schedule exists for the given day
    Private Function ScheduleExists(dayNumber As Integer, invalidRows As StringBuilder) As Boolean
        For Each schedRow As DataGridViewRow In FRM_DTR_BIOMETRIC.GView_Schedule.Rows
            If schedRow.Cells(0)?.Value?.ToString() = dayNumber.ToString() Then
                Return True
            End If
        Next
        invalidRows.AppendLine($"Day {dayNumber} has no corresponding schedule row")
        Return False
    End Function
    ' Parse date string into a DateTime object
    Private Function ParseDate(dateStr As String) As DateTime?
        Dim parsedDate As DateTime
        If DateTime.TryParseExact(dateStr, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
            Return parsedDate
        End If
        Return Nothing
    End Function

    ' Get the first part of the date string
    Private Function GetFirstDate(dateStr As String) As String
        Return If(dateStr.Contains("-"c), dateStr.Split("-"c)(0).Trim(), dateStr)
    End Function

    ' Processes attendance (marks as present or absent) for each row
    Private Sub ProcessAttendance()
        Dim presentCount As Integer = 0
        Dim absentCount As Integer = 0

        For Each row As DataGridViewRow In FRM_DTR_BIOMETRIC.GView_DTR.Rows
            ' Check if the entire row is empty (skip if true)
            Dim isRowEmpty As Boolean =
        row.Cells.Cast(Of DataGridViewCell)().All(Function(cell) String.IsNullOrWhiteSpace(CStr(cell?.Value))) OrElse
        String.IsNullOrWhiteSpace(CStr(row.Cells(0)?.Value))

            If isRowEmpty Then Continue For

            ' Proceed with processing since this row contains data
            Dim firstDate As String = GetFirstDate(row.Cells(0)?.Value?.ToString())
            Dim parsedDate = ParseDate(firstDate)
            If parsedDate Is Nothing Then Throw New Exception("Invalid Date")

            Dim dayOfMonth As Integer = parsedDate.Value.Day
            Dim scheduleFound As Boolean = False

            For Each scheduleRow As DataGridViewRow In FRM_DTR_BIOMETRIC.GView_Schedule.Rows
                If scheduleRow.Cells(0)?.Value?.ToString() = dayOfMonth.ToString() Then
                    scheduleFound = True
                    ValidateAndCalculateAttendance(row, scheduleRow, presentCount)
                    Exit For
                End If
            Next

            If Not scheduleFound Then
                absentCount += 1
            End If
        Next


        ' Update UI elements showing the count of present and absent days
        FRM_DTR_BIOMETRIC.Lbl_Num_of_Reporting_Days.Text = presentCount
        FRM_DTR_BIOMETRIC.Lbl_Absent_Count.Text = absentCount
    End Sub

    ' Marks attendance as present and calculates late time
    Private Sub ValidateAndCalculateAttendance(row As DataGridViewRow, scheduleRow As DataGridViewRow, ByRef presentCount As Integer)
        ' Retrieve and validate schedule time-in
        Dim scheduledTimeIn As String = scheduleRow.Cells(1)?.Value?.ToString()
        Dim parsedScheduleIn As DateTime

        ' Extract date and validate
        Dim firstDate As String = GetFirstDate(row.Cells(0)?.Value.ToString())
        Dim parsedDate = ParseDate(firstDate)
        If parsedDate Is Nothing Then Throw New Exception("Invalid Date")

        Parsed_SchedStrToDate(parsedDate, scheduledTimeIn, parsedScheduleIn)

        ' Mark as present and increase the present count
        scheduleRow.Cells(6).Value = "Present"
        presentCount += 1

        ' Calculate late minutes (if any)
        Dim actualTimeInStr As String = row.Cells(2)?.Value?.ToString()
        Dim parsedActualTimeIn As DateTime

        If DateTime.TryParseExact(actualTimeInStr, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, parsedActualTimeIn) Then
            ' Calculate the lateness duration
            Dim lateDuration As TimeSpan = CalculateLate(parsedScheduleIn, parsedActualTimeIn)
            row.Cells(10).Value = Math.Max(lateDuration.TotalMinutes, 0)
        Else
            Throw New Exception($"Invalid DateTime format: {actualTimeInStr}")
        End If
    End Sub

    ' Calculates late duration (difference between scheduled and actual time)
    Private Function CalculateLate(scheduledTime As DateTime, actualTime As DateTime) As TimeSpan
        If actualTime > scheduledTime Then
            Return actualTime - scheduledTime ' Return late duration
        Else
            Return TimeSpan.Zero ' No lateness
        End If
    End Function

    ' Calculates break durations and excess break time
    Private Sub CalculateBreaks()
        For i = 0 To 16 ' Iterate through DTR grid rows
            If String.IsNullOrEmpty(CStr(FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(0).Value)) Then
                Continue For
            End If

            ' Calculate break durations (Break 1 and Break 2)
            Dim break1Duration As Integer = CalculateBreakDuration(i, 4, 3)
            Dim break2Duration As Integer = CalculateBreakDuration(i, 6, 5)

            ' Sum break durations and calculate excess break time (if any)
            Dim totalBreakTime As Integer = If(break1Duration < 30, 30, break1Duration) + If(break2Duration < 30, 30, break2Duration)
            FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(11).Value = totalBreakTime
            FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(12).Value = If(totalBreakTime > 60, totalBreakTime - 60, 0)
        Next
    End Sub

    ' Calculates the duration of a specific break (in minutes)
    Private Function CalculateBreakDuration(i As Integer, breakInCell As Integer, breakOutCell As Integer) As Integer
        Try
            ' Get cell values and check for null or empty
            Dim breakInValue As Object = FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(breakInCell).Value
            Dim breakOutValue As Object = FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(breakOutCell).Value

            If breakInValue Is Nothing OrElse String.IsNullOrWhiteSpace(breakInValue.ToString()) OrElse
           breakOutValue Is Nothing OrElse String.IsNullOrWhiteSpace(breakOutValue.ToString()) Then
                Return 0
            End If

            ' Parse break times (in and out)
            Dim breakIn As DateTime = ParseBreakTime(breakInValue.ToString())
            Dim breakOut As DateTime = ParseBreakTime(breakOutValue.ToString())

            Return CInt((breakIn - breakOut).TotalMinutes)
        Catch ex As Exception
            MsgBox($"Error parsing break times: {ex.Message}", vbCritical, "Error")
            Return 0
        End Try
    End Function


    ' Parses a break time string into DateTime
    Private Function ParseBreakTime(breakTimeStr As String) As DateTime
        Dim parsedTime As DateTime
        Parsed_StrToDate(breakTimeStr, parsedTime)
        Return parsedTime
    End Function
    ' Helper function to reset cells
    Sub ResetCells(row As DataGridViewRow, startIndex As Integer, endIndex As Integer)
        For idx As Integer = startIndex To endIndex
            row.Cells(idx).Value = Nothing
        Next
    End Sub
    ' Calculates overtime and total hours worked (including breaks)
    Private Sub CalculateOvertimeAndTotalHours()
        Dim totalOverallWorkedMinutes As Integer = 0 ' Variable to accumulate total worked minutes

        For i = 0 To 16
            Dim overtimeMinutes As Integer = 0
            Dim totalWorkedMinutes As Integer = 0
            If String.IsNullOrEmpty(CStr(FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(0).Value)) Then
                ResetCells(FRM_DTR_BIOMETRIC.GView_DTR.Rows(i), 10, 14)
                Continue For
            End If

            ' Extract date and validate
            Dim firstDate As String = GetFirstDate(FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(0)?.Value.ToString())
            Dim parsedDate = ParseDate(firstDate)
            If parsedDate Is Nothing Then Throw New Exception("Invalid Date")

            Dim dayOfMonth As Integer = parsedDate.Value.Day

            ' Parse time-in
            Dim parsedTimeIn As DateTime = ParseTime(FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(2).Value.ToString())
            ' Parse time-out
            Dim parsedTimeOut? As DateTime = ParseTimeOut(FRM_DTR_BIOMETRIC.GView_DTR.Rows(i))
            If parsedTimeOut Is Nothing Then
                overtimeMinutes = 0
                totalWorkedMinutes = 0
            Else
                ' Calculate overtime
                overtimeMinutes = CalculateOverTime(FRM_DTR_BIOMETRIC.GView_DTR.Rows(i), parsedTimeOut, dayOfMonth)

                ' Calculate total hours worked, considering overtime and break durations
                totalWorkedMinutes = CalculateTotalWorkedMinutes(FRM_DTR_BIOMETRIC.GView_DTR.Rows(i), parsedTimeIn, parsedTimeOut, dayOfMonth)

            End If


            ' Update grid cells with overtime and total worked hours
            FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(13).Value = overtimeMinutes

            Dim totalWorkedHours As Double = Math.Round(totalWorkedMinutes / 60,2)
            ' Ensure the maximum is 12 hours

            Dim schedTotalWorkHours = ParseScheduleTotalHours(dayOfMonth)
            If totalWorkedHours > schedTotalWorkHours Then
                totalWorkedHours = schedTotalWorkHours
            End If

            FRM_DTR_BIOMETRIC.GView_DTR.Rows(i).Cells(14).Value = totalWorkedHours



            ' Accumulate total worked minutes
            'totalOverallWorkedMinutes += totalWorkedMinutes
        Next

        ' Calculate total overall worked hours (including breaks)
        Dim totalOverallWorkedHours As Double = Math.Round(totalOverallWorkedMinutes / 60, 2)

        ' Update the last row to display the total overall worked hours
        FRM_DTR_BIOMETRIC.GView_DTR.Rows(FRM_DTR_BIOMETRIC.GView_DTR.Rows.Count - 2).Cells(13).Value = "Total:"
        'FRM_DTR_BIOMETRIC.GView_DTR.Rows(FRM_DTR_BIOMETRIC.GView_DTR.Rows.Count - 2).Cells(14).Value = totalOverallWorkedHours
    End Sub


    ' Calculate total minutes worked (including overtime and excluding break time), and consider lateness as a penalty
    Private Function CalculateTotalWorkedMinutes(dtrRow As DataGridViewRow, timeIn As DateTime, timeOut As DateTime, dayOfMonth As Integer) As Integer

        ' Declare the scheduledTimeOut variable
        Dim scheduledTimeOut As DateTime

        ' Otherwise, get the scheduled time out without adding a day
        scheduledTimeOut = ParseScheduleOut(dtrRow, dayOfMonth)

        ' Parse the scheduled time-in for the specified day
        Dim scheduledTimeIn As DateTime = ParseScheduleIn(dtrRow, dayOfMonth)
        ' Parse the actual time-in for the specified day
        Dim actualTimeIn As DateTime = timeIn
        Dim newTimeOut As DateTime
        Dim overtimeMinutes As Integer = CInt((timeOut - scheduledTimeOut).TotalMinutes)

        If overtimeMinutes < 60 AndAlso overtimeMinutes >= 0 Then
            newTimeOut = scheduledTimeOut
        Else
            newTimeOut = timeOut
        End If

        ' Calculate total minutes worked (ignoring break time)
        Dim totalMinutesWorked As Integer = CInt((newTimeOut - scheduledTimeIn).TotalMinutes)

        ' Subtract break time from total minutes worked
        Dim totalBreakTime As Integer = GetTotalBreakTime(dtrRow)
        totalMinutesWorked -= totalBreakTime

        ' Calculate lateness (if actual time-in is later than scheduled time-in)
        Dim lateMinutes As Integer = 0
        If actualTimeIn > scheduledTimeIn Then
            lateMinutes = CInt((actualTimeIn - scheduledTimeIn).TotalMinutes)
        End If

        ' Optionally subtract lateness from total worked minutes if you want to penalize the worker
        totalMinutesWorked -= lateMinutes

        ' Return the final total worked minutes after accounting for lateness
        Return totalMinutesWorked
    End Function

    ' Calculates overtime based on the difference between actual time and scheduled time
    Private Function CalculateOverTime(dtrRow As DataGridViewRow, timeOut As DateTime, dayOfMonth As Integer) As Integer
        ' Get the shift flag for the specific day of the month

        ' Declare the scheduledTimeOut variable
        Dim scheduledTimeOut As DateTime


        ' Otherwise, get the scheduled time out without adding a day
        scheduledTimeOut = ParseScheduleOut(dtrRow, dayOfMonth)

        ' Calculate overtime in minutes (ensure timeOut is later than scheduledTimeOut)
        Dim overtimeMinutes As Integer = CInt((timeOut - scheduledTimeOut).TotalMinutes)

        ' Ensure overtime is within valid range
        If overtimeMinutes > 0 AndAlso overtimeMinutes < 60 Then
            overtimeMinutes = 0 ' Ignore overtime less than 60 minutes
        ElseIf overtimeMinutes > 240 Then
            overtimeMinutes = 240 ' Cap at 4 hours (240 minutes)
        End If


        Return overtimeMinutes
    End Function




    ' Parse Time-In value and return DateTime
    Private Function ParseTime(timeStr As String) As DateTime
        Dim parsedTime As DateTime
        Parsed_StrToDate(timeStr, parsedTime)
        Return parsedTime
    End Function

    Private Function ParseTimeOut(dtrRow As DataGridViewRow) As DateTime?
        Dim timeStr As String = String.Empty
        Dim parsedTime As DateTime = DateTime.MinValue
        Dim hasValue As Boolean = False

        ' Iterate over the specific columns: 3, 5, 7, 9 to check timeout
        Dim columnsToCheck As Integer() = {3, 5, 7, 9}

        ' Loop through the columns and find the last non-empty value
        For Each columnIndex In columnsToCheck
            If dtrRow.Cells(columnIndex).Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(dtrRow.Cells(columnIndex).Value.ToString()) Then
                timeStr = dtrRow.Cells(columnIndex).Value.ToString()
                hasValue = True ' Flag that at least one column has a value
            End If
        Next

        ' If no values were found, return Nothing
        If Not hasValue Then
            Return Nothing
        End If

        ' If a valid time string is found, parse it
        If Not String.IsNullOrEmpty(timeStr) Then
            ' Assuming Parsed_StrToDate is a function that parses the string into DateTime
            Parsed_StrToDate(timeStr, parsedTime)
        End If

        Return parsedTime
    End Function



    ' Get the schedule's time-in for a specific day
    Private Function ParseScheduleIn(dtrRow As DataGridViewRow, dayNumber As Integer) As DateTime
        For Each schedRow As DataGridViewRow In FRM_DTR_BIOMETRIC.GView_Schedule.Rows
            If schedRow.Cells(0)?.Value?.ToString() = dayNumber.ToString() Then
                Dim schedTimeIn As String = schedRow.Cells(1)?.Value?.ToString()

                Dim parsedScheduleIn As DateTime


                ' Extract date and validate
                Dim firstDate As String = GetFirstDate(dtrRow.Cells(0)?.Value.ToString())
                Dim parsedDate = ParseDate(firstDate)
                If parsedDate Is Nothing Then Throw New Exception("Invalid Date")

                Parsed_SchedStrToDate(parsedDate, schedTimeIn, parsedScheduleIn)
                Return parsedScheduleIn
            End If
        Next
        Throw New Exception($"No schedule found for day {dayNumber}")
    End Function

    Private Function ParseScheduleTotalHours(dayNumber As Integer) As Integer
        For Each schedRow As DataGridViewRow In FRM_DTR_BIOMETRIC.GView_Schedule.Rows
            If schedRow.Cells(0)?.Value?.ToString() = dayNumber.ToString() Then
                Dim schedTotalHoursStr As String = schedRow.Cells(4)?.Value?.ToString()

                Dim schedTotalHours As Double
                If Double.TryParse(schedTotalHoursStr, schedTotalHours) Then
                    ' Round to nearest whole number before converting to Integer
                    Return CInt(Math.Round(schedTotalHours, MidpointRounding.AwayFromZero))

                Else
                    Throw New Exception($"Invalid schedule total hours format for Day {dayNumber}.")
                End If
            End If
        Next
        Throw New Exception($"No schedule total hours found for Day {dayNumber}.")
    End Function


    Private Function ParseScheduleOut(dtrRow As DataGridViewRow, dayNumber As Integer) As DateTime
        For Each schedRow As DataGridViewRow In FRM_DTR_BIOMETRIC.GView_Schedule.Rows
            If schedRow.Cells(0)?.Value?.ToString() = dayNumber.ToString() Then
                Dim schedTimeOut As String = schedRow.Cells(3)?.Value?.ToString()

                Dim parsedScheduleOut As DateTime

                ' Extract date and validate
                Dim firstDate As String = GetFirstDate(dtrRow.Cells(0)?.Value.ToString())
                Dim parsedDate = ParseDate(firstDate)
                If parsedDate Is Nothing Then Throw New Exception("Invalid Date")

                Parsed_SchedStrToDate(parsedDate, schedTimeOut, parsedScheduleOut)
                Return parsedScheduleOut
            End If
        Next
        Throw New Exception($"No schedule found for day {dayNumber}")
    End Function

    ' Retrieves the total break time for a specific day (in minutes)
    Private Function GetTotalBreakTime(dtrRow As DataGridViewRow) As Integer
        ' Assuming breaks are stored in the break columns for each row and need to be summed
        Dim totalBreakTime As Integer = 0

        ' Retrieve break times from break columns (cells 4 and 6 represent break times in/out)
        Dim break1Duration As Integer = CalculateBreakDuration(dtrRow.Index, 4, 3) ' Break 1

        Dim break2Duration As Integer = CalculateBreakDuration(dtrRow.Index, 6, 5) ' Break 2
        ' Sum break durations and calculate excess break time (if any)
        totalBreakTime = If(break1Duration < 30, 30, break1Duration) + If(break2Duration < 30, 30, break2Duration)


        Return If(totalBreakTime > 60, totalBreakTime - 60, 0)
    End Function


#End Region

    Private Function ToDec(value As Object) As Decimal
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0D

        Dim s As String = value.ToString().Trim()
        If s = "" Then Return 0D

        Dim d As Decimal
        If Decimal.TryParse(s, d) Then Return d

        Return 0D
    End Function


    Public Sub Save_DTR_Total_Hours(
    iSub_Client_ID As Integer,
    sEmployee_ID As String,
    sCutOff_Period As String,
    iNumber_of_Days As Integer,
    cbDeduct As Decimal,
    sssLoanDeduct As Decimal,
    sssCalLoanDeduct As Decimal,
    piLoanDeduct As Decimal,
    piCalLoanDeduct As Decimal,
    philhealthDeduct As Decimal,
    sssDeduct As Decimal,
    pagibigDeduct As Decimal
)

        Dim SQL As String = ""
        Connect_to_MDB()

        Try
            With FRM_DTR_BIOMETRIC.GView_DTR

                SQL = "INSERT INTO PRL_DTR_TOTAL_HOURS " &
                  "(EMPLOYEE_ID, SUB_CLIENT_ID, CUTOFF_PERIOD, NUM_OF_DAYS, " &
                  "TOTAL_HOURS, REG, SUN, SH, LH, OT_REG, " &
                  "CB_DEDUCT, SSS_LOAN_DEDUCT, PI_LOAN_DEDUCT, PH_DEDUCT, SSS_DEDUCT, PI_DEDUCT, SSS_CAL_LOAN_DEDUCT, PI_CAL_LOAN_DEDUCT) " &
                  "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"


                Using SQLcmd As New OleDbCommand(SQL, GlobalVariables.GlobalCon)

                    SQLcmd.Parameters.AddWithValue("?", sEmployee_ID)
                    SQLcmd.Parameters.AddWithValue("?", iSub_Client_ID)
                    SQLcmd.Parameters.AddWithValue("?", sCutOff_Period)
                    SQLcmd.Parameters.AddWithValue("?", iNumber_of_Days)

                    SQLcmd.Parameters.AddWithValue("?", ToDec(.Rows(17).Cells(14).Value))
                    SQLcmd.Parameters.AddWithValue("?", ToDec(.Rows(17).Cells(15).Value))
                    SQLcmd.Parameters.AddWithValue("?", ToDec(.Rows(17).Cells(16).Value))
                    SQLcmd.Parameters.AddWithValue("?", ToDec(.Rows(17).Cells(17).Value))
                    SQLcmd.Parameters.AddWithValue("?", ToDec(.Rows(17).Cells(18).Value))
                    SQLcmd.Parameters.AddWithValue("?", ToDec(.Rows(17).Cells(19).Value))

                    SQLcmd.Parameters.AddWithValue("?", cbDeduct)
                    SQLcmd.Parameters.AddWithValue("?", sssLoanDeduct)
                    SQLcmd.Parameters.AddWithValue("?", piLoanDeduct)
                    SQLcmd.Parameters.AddWithValue("?", philhealthDeduct)
                    SQLcmd.Parameters.AddWithValue("?", sssDeduct)
                    SQLcmd.Parameters.AddWithValue("?", pagibigDeduct)
                    SQLcmd.Parameters.AddWithValue("?", sssCalLoanDeduct)
                    SQLcmd.Parameters.AddWithValue("?", piCalLoanDeduct)

                    SQLcmd.ExecuteNonQuery()
                End Using

                MsgBox("DTR Total Hours was successfully saved!", vbInformation, "Saved")

            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving total hours!")
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State <> ConnectionState.Closed Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try

    End Sub

    Public Sub Save_DTR_Hours_Per_Day(iSub_Client_ID As Integer, sEmployee_ID As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_DTR_BIOMETRIC.GView_DTR
                For i = 0 To .Rows.Count - 1

                    If IsNothing(.Rows(i).Cells(0).Value) Then
                        Continue For
                    End If

                    ' Format the date for MS Access
                    Dim rawValue As String = .Rows(i).Cells(0).Value.ToString()
                    Dim datePart As String = rawValue.Split("-"c)(0).Trim()
                    Dim reportDate As String = "#" & Format(CDate(datePart), "yyyy-MM-dd") & "#"

                    Dim reportDay As String = .Rows(i).Cells(1).Value.ToString()
                    Dim totalHours As Double = 0

                    ' Safe conversion using TryParse
                    Dim cellValue As Object = .Rows(i).Cells(14).Value
                    If Not IsNothing(cellValue) AndAlso Not String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                        Double.TryParse(cellValue.ToString(), totalHours)
                    End If

                    ' Build SQL
                    SQL = "INSERT INTO PRL_DTR_HOURS_PER_DAY (EMPLOYEE_ID, SUB_CLIENT_ID, REPORT_DATE, REPORT_DAY, DAILY_TOTAL_HOURS) " &
                      "VALUES ('" & sEmployee_ID & "', " & iSub_Client_ID & ", " & reportDate & ", '" & reportDay & "', " & totalHours & ")"

                    Using SQLcmd As New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                        SQLcmd.ExecuteNonQuery()
                    End Using

                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving Total Hours Per Day!")
        Finally
            If GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try

    End Sub

    Public Sub Show_DTR_Employee_List(sCategory As String, sValue As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select * FROM VIEW_PAYROLL_EMPLOYEE_LIST WHERE " & sCategory & " LIKE '%" & sValue & "%' ORDER BY SUB_CLIENT_ID, LAST_NAME ASC"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS



                With FRM_DTR_EMPLOYEE_LIST.LV_Employee_List
                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(iRow) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("EMPLOYEE_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUB_CLIENT_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ADDRESS"))


                        iRow = iRow + 1
                    Next

                End With
            Else
                FRM_DTR_EMPLOYEE_LIST.LV_Employee_List.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub

    Public Sub Show_Employee_Schedule(iEmployee_ID As Integer, sScheduler As String, iCutOff As Integer)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try
            If iCutOff = 1 Then
                SQL = "SELECT DAY_NUM, SCHED_IN, DAY_NUM_OUT, SCHED_OUT, TOTAL_HOURS FROM PRL_EMPLOYEE_SCHEDULE WHERE EMPLOYEE_ID = '" & iEmployee_ID & "' AND DAY_NUM <= 15"
            ElseIf iCutOff = 2 Then
                SQL = "SELECT DAY_NUM, SCHED_IN, DAY_NUM_OUT, SCHED_OUT, TOTAL_HOURS FROM PRL_EMPLOYEE_SCHEDULE WHERE EMPLOYEE_ID = '" & iEmployee_ID & "' AND DAY_NUM > 15"
            Else
                SQL = "SELECT DAY_NUM, SCHED_IN, DAY_NUM_OUT, SCHED_OUT, TOTAL_HOURS FROM PRL_EMPLOYEE_SCHEDULE WHERE EMPLOYEE_ID = '" & iEmployee_ID & "'"
            End If

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                If sScheduler = "No" Then
                    FRM_DTR_BIOMETRIC.GView_Schedule.Rows.Clear()
                    For Each row As DataRow In dt.Rows
                        Dim newRow As Integer = FRM_DTR_BIOMETRIC.GView_Schedule.Rows.Add()
                        For i As Integer = 0 To dt.Columns.Count - 1
                            FRM_DTR_BIOMETRIC.GView_Schedule.Rows(newRow).Cells(i).Value = row(i).ToString()
                        Next
                    Next

                ElseIf sScheduler = "Yes" Then
                    If iCutOff = 1 Then
                        FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows.Clear()
                        For Each row As DataRow In dt.Rows
                            Dim newRow As Integer = FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows.Add()

                            Dim currentDay As Integer = Convert.ToInt32(row("DAY_NUM"))
                            Dim dayNumOut As Integer = If(IsDBNull(row("DAY_NUM_OUT")), -1, Convert.ToInt32(row("DAY_NUM_OUT")))
                            Dim altDay As Integer = Math.Min(currentDay + 1, 16)

                            FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Cells(0).Value = currentDay.ToString()
                            FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Cells(1).Value = row("SCHED_IN").ToString()
                            FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Cells(3).Value = row("SCHED_OUT").ToString()
                            FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Cells(4).Value = row("TOTAL_HOURS").ToString()

                            If dayNumOut = currentDay OrElse dayNumOut = altDay Then
                                FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Cells(2).Value = dayNumOut.ToString()
                            Else
                                FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Cells(2).Value = currentDay.ToString()
                            End If

                            FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Tag = {currentDay, altDay}
                        Next

                    ElseIf iCutOff = 2 Then
                        FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows.Clear()
                        For Each row As DataRow In dt.Rows
                            Dim newRow As Integer = FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows.Add()

                            Dim currentDay As Integer = Convert.ToInt32(row("DAY_NUM"))
                            Dim dayNumOut As Integer = If(IsDBNull(row("DAY_NUM_OUT")), -1, Convert.ToInt32(row("DAY_NUM_OUT")))
                            Dim altDay As Integer = Math.Min(currentDay + 1, 32)

                            FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows(newRow).Cells(0).Value = currentDay.ToString()
                            FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows(newRow).Cells(1).Value = row("SCHED_IN").ToString()
                            FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows(newRow).Cells(3).Value = row("SCHED_OUT").ToString()
                            FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows(newRow).Cells(4).Value = row("TOTAL_HOURS").ToString()

                            If dayNumOut = currentDay OrElse dayNumOut = altDay Then
                                FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows(newRow).Cells(2).Value = dayNumOut.ToString()
                            Else
                                FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows(newRow).Cells(2).Value = currentDay.ToString()
                            End If

                            FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows(newRow).Tag = {currentDay, altDay}
                        Next
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Error")
        Finally
            GlobalVariables.GlobalCon.Close()
        End Try
    End Sub





    Public Sub Parsed_StrToDate(DateTimeStr As String, ByRef ParsedDateTime As DateTime)
        ' Parse the string using the exact format
        If DateTime.TryParseExact(DateTimeStr, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, ParsedDateTime) Then
            ' Successfully parsed
            Console.WriteLine($"Parsed DateTime: {ParsedDateTime}")
        Else
            ' Handle invalid format
            Throw New Exception($"Invalid DateTime format: {DateTimeStr}")
        End If
    End Sub

    Public Sub Parsed_SchedStrToDate(RefDate As DateTime, sScheduleDateTimeStr As String, ByRef parsedSchedule_DateTime As DateTime)
        If DateTime.TryParseExact(sScheduleDateTimeStr, "H:m", CultureInfo.InvariantCulture, DateTimeStyles.None, Nothing) Then
            ' If parsing succeeds, extract the TimeSpan
            Dim parsedSchedule_Time As TimeSpan = DateTime.ParseExact(sScheduleDateTimeStr, "H:m", CultureInfo.InvariantCulture).TimeOfDay
            parsedSchedule_DateTime = RefDate.Add(parsedSchedule_Time)

        Else Throw New Exception($"invalid schedule time format: {sScheduleDateTimeStr}")
        End If
    End Sub
    Private Sub Parsed_NsSchedStrToDate(RefDate As DateTime, sScheduleDateTimeStr As String, ByRef parsedSchedule_DateTime As DateTime)
        If DateTime.TryParseExact(sScheduleDateTimeStr, "H:m", CultureInfo.InvariantCulture, DateTimeStyles.None, Nothing) Then
            ' If parsing succeeds, extract the TimeSpan
            Dim parsedSchedule_Time As TimeSpan = DateTime.ParseExact(sScheduleDateTimeStr, "H:m", CultureInfo.InvariantCulture).TimeOfDay
            parsedSchedule_DateTime = RefDate.Add(parsedSchedule_Time).AddDays(1)

        Else Throw New Exception($"invalid schedule time format: {sScheduleDateTimeStr}")
        End If
    End Sub

End Module
