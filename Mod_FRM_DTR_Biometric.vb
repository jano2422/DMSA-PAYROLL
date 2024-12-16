Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Globalization
Imports System.Text

Module Mod_Biometric_DTR

    Public Sub Calculate_DTR() ' 0 morning ; 1 night shift ( because I used checkbox )

        With FRM_DTR_BIOMETRIC


            ' Computation of Late, Over Break and Over Time after loading the schedule and DTR
            ' Temporary. This should be on a separate function

            Dim DTR_Time_OUT_OT As DateTime
            Dim Parsed_DTR_Sched_Time_OUT, DTR_Sched_DateTime_IN, Parsed_DTR_Sched_Time_IN As DateTime

            Dim No_Time_OUT As Boolean
            No_Time_OUT = False

            Dim parsedFirst_Time_IN, parsedLast_Time_OUT As DateTime
            Dim Total_TimeSpan As TimeSpan
            Dim Total_Hours_Spent As Double

            Dim OUT_Over_Under_Time, IN_early_late_Time As TimeSpan

            Dim dDTR_Date As String
            Dim iDTR_Day_Num, iDTR_Month_Num, iDTR_Year_Num As Integer
            Dim sSchedule_Time_IN As String

            ' Break Calculation
            Dim minutesDifference_Break1, minutesDifference_Break2 As Integer
            ' Absent Counter
            Dim Present_Ctr, Absent_Count As Integer
            Present_Ctr = 0
            Absent_Count = 0

#Region "LATE_Calculation"
            '============================ Time IN LATE Calculation ================================


            Try
                Dim invalidRows As New StringBuilder() ' Use StringBuilder for better performance with concatenations

                ' Loop over each row in GView_DTR to map corresponding index to GView_Schedule
                For i = 0 To .GView_DTR.Rows.Count - 1
                    Dim cellValue As Object = .GView_DTR.Rows(i).Cells(0)?.Value

                    ' Skip the iteration if no value is found
                    If cellValue Is Nothing OrElse String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                        Continue For
                    End If

                    Dim szfirstDate As String
                    Dim valueStr As String = cellValue.ToString()

                    ' Process only if the value contains the "-" character
                    If valueStr.Contains("-"c) Then
                        szfirstDate = valueStr.Split("-"c)(0).Trim()
                        ' Continue processing with szfirstDate...
                    Else
                        ' Skip trimming and handle the case where "-" is not present
                        szfirstDate = valueStr
                        ' Optional: Additional handling for cases without "-"
                    End If

                    Dim DTfirstDateTime As DateTime
                    ' Convert string into Date ( Format should be same from what is being converted )
                    If Not DateTime.TryParseExact(szfirstDate, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, DTfirstDateTime) Then
                        Continue For
                    End If

                    Dim DtrDayNumber = DTfirstDateTime.Day
                    ' Skip rows where DtrDayNumber is empty or invalid
                    If String.IsNullOrWhiteSpace(DtrDayNumber) Then
                        Continue For
                    End If

                    Dim isDayNumberFound As Boolean = False ' Track if the day number is found in GView_Schedule

                    ' Search GView_Schedule to check if DtrDayNumber exists
                    For Each schedRow In .GView_Schedule.Rows
                        If schedRow.Cells(0)?.Value?.ToString() = DtrDayNumber Then
                            isDayNumberFound = True

                            Dim schedTimeIn = schedRow.Cells(1)?.Value?.ToString() ' Scheduled Time In
                            Dim schedTimeOut = schedRow.Cells(2)?.Value?.ToString() ' Scheduled Time Out

                            ' Check for invalid or empty fields in Sched Time In or Sched Time Out
                            Dim errors As List(Of String) = New List(Of String)()

                            If String.IsNullOrWhiteSpace(schedTimeIn) Then
                                errors.Add("Time In is invalid")
                            End If

                            If String.IsNullOrWhiteSpace(schedTimeOut) Then
                                errors.Add("Time Out is invalid")
                            End If

                            If errors.Count > 0 Then
                                invalidRows.AppendLine($"Day {DtrDayNumber}: {String.Join(", ", errors)}")
                            End If
                            Exit For ' Exit loop as we've found the corresponding day number
                        End If
                    Next

                    ' If the day number was not found in GView_Schedule
                    If Not isDayNumberFound Then
                        invalidRows.AppendLine($"Day {DtrDayNumber} has no corresponding schedule row")
                    End If
                Next

                ' If invalid rows exist, display them in a MessageBox
                If invalidRows.Length > 0 Then
                    MsgBox("The following issues were found in the Schedule:" & vbCrLf & invalidRows.ToString(), vbCritical, "Schedule Error")
                    Exit Sub
                End If

                For i = 0 To 16 ' DTR DataGridView ( Number of days in a shift )

                    If .GView_DTR.Rows(i).Cells(0).Value = "" Then
                        Exit For ' Skip empty cells
                    End If

                    ' Get the Day from DTR

                    dDTR_Date = .GView_DTR.Rows(i).Cells(0).Value

                    ' Convert string into Date ( Format should be same from what is being converted )
                    'Dim format As String = "MM/dd/yyyy"
                    'Dim dateObject As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(0).Value, format, System.Globalization.CultureInfo.InvariantCulture)


                    Dim firstDate As String = .GView_DTR.Rows(i).Cells(0).Value.Split("-"c)(0).Trim() ' Get the first date and remove any leading or trailing spaces
                    Dim firstDateTime As DateTime
                    ' Convert string into Date ( Format should be same from what is being converted )
                    If Not DateTime.TryParseExact(firstDate, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, firstDateTime) Then
                        Throw New Exception("Invalid Date")
                    End If

                    iDTR_Day_Num = firstDateTime.Day ' This is the Day Num from DTR
                    iDTR_Month_Num = firstDateTime.Month
                    iDTR_Year_Num = firstDateTime.Year

                    'Just to get the first day to get the Cut Off Date e.g Month_1stCutoff_2024
                    ' This is used in saving the total hours
                    If i = 0 Then
                        If iDTR_Day_Num <= 15 Then
                            GlobalVariables.sPayroll_Cutoff = iDTR_Month_Num & "_" & "1st_" & iDTR_Year_Num
                        ElseIf iDTR_Day_Num >= 16 Then
                            GlobalVariables.sPayroll_Cutoff = iDTR_Month_Num & "_" & "2nd_" & iDTR_Year_Num
                        End If

                    End If

                    Dim parsedSchedule_DateTime_IN As DateTime
                    ' Search from Schedule the Day_Num
                    For j = 0 To 30 ' Schedule DataGridView

                        'j = iDTR_Day_Num - 1       ' This will help a little bit to speed up the loop , becuse j will not always start with Zero
                        If .GView_Schedule.Rows(j).Cells(0).Value = iDTR_Day_Num Then
                            sSchedule_Time_IN = .GView_Schedule.Rows(j).Cells(1).Value
                            Parsed_SchedStrToDate(firstDateTime, sSchedule_Time_IN, parsedSchedule_DateTime_IN)
                            ' Present on this day
                            .GView_Schedule.Rows(j).Cells(6).Value = "Present" ' j can also be the iDTR_Day_Num -1

                            Present_Ctr = Present_Ctr + 1
                            Absent_Count = (j - Present_Ctr) + 1
                            Exit For
                        End If

                    Next


                    .Lbl_Num_of_Reporting_Days.Text = Present_Ctr


                    ' Parsed DTR Time IN
                    'Dim parsedTime_DTR_IN As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(2).Value, "h:mm tt", Nothing)
                    Dim parsedTime_DTR_IN As DateTime
                    Dim DtrTimeInString As String = .GView_DTR.Rows(i).Cells(2).Value
                    ' Parse the string using the exact format
                    If DateTime.TryParseExact(DtrTimeInString, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, parsedTime_DTR_IN) Then
                        ' Successfully parsed
                        Console.WriteLine($"Parsed DateTime: {parsedTime_DTR_IN}")
                    Else
                        ' Handle invalid format
                        Throw New Exception($"Invalid DateTime format: {DtrTimeInString}")
                    End If


                    'Dim DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("HH:mm")

                    Dim STR_DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("M/d/yyyy HH:mm:ss", CultureInfo.InvariantCulture)

                    Console.WriteLine($"Military Time Format: {STR_DTR_militaryTime_DTR_IN}")


                    ' Subtract the DTR Time IN against Schedule
                    'Dim DTR_Time_IN As DateTime = DateTime.Parse(STR_DTR_militaryTime_DTR_IN)

                    ' Parse the military time string into a DateTime object
                    If DateTime.TryParseExact(STR_DTR_militaryTime_DTR_IN, "M/d/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, parsedTime_DTR_IN) Then
                        Console.WriteLine($"Parsed DateTime: {parsedTime_DTR_IN}")
                    Else
                        ' Handle parsing errors
                        Throw New Exception($"Invalid DateTime format: {STR_DTR_militaryTime_DTR_IN}")
                    End If


                    DTR_Sched_DateTime_IN = parsedSchedule_DateTime_IN

                    Dim difference_Late As TimeSpan = parsedTime_DTR_IN - DTR_Sched_DateTime_IN
                    Dim minutesDifference_Late As Integer = CInt(difference_Late.TotalMinutes)

                    ' If value is NEGATIVE, then employee is early. No Deduction or Over Time
                    ' If the value is Positive, the employee is Late! the value needs to be deducted from the expected total hours.

                    If minutesDifference_Late >= 0 Then ' LATE!

                        .GView_DTR.Rows(i).Cells(8).Value = minutesDifference_Late

                    Else ' Not Late then should just be 0

                        .GView_DTR.Rows(i).Cells(8).Value = 0

                    End If

                    '.GView_DTR.Refresh()

                Next

                ' Counting the number of absences ( See line 126 to 128 )
                .Lbl_Absent_Count.Text = Absent_Count

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

#End Region
#Region "Break_Calculation"
            ' ==================================Calculate Total Break ======================================

            '============================ OVer Break Calculation: 1st Break ================================
#Region "Over Break 1"
            ' Cell 9 = cell 4 - cell 3

            ' Condition:
            '1 - If Cells are not empty, then calculate
            '2- There are normally 2 breaks in a shift but sometimes only 1 break is used.

            For i = 0 To 16 ' DTR DataGridView

                If .GView_DTR.Rows(i).Cells(4).Value = "" Then ' Cells(04) is 2nd Time-IN
                    Exit For ' Skip empty cells
                End If

                ' Reset values
                minutesDifference_Break1 = 0 ' 1st Break
                minutesDifference_Break2 = 0 ' 2nd Break

                ' Next is to calculate the Over Break ( convert to military first )
                'Dim parsedTime_Break1_IN As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(4).Value, "h:mm tt", Nothing) ' Time IN
                Dim parsedTime_Break1_IN As DateTime
                Dim DtrBreak1TimeInString As String = .GView_DTR.Rows(i).Cells(4).Value
                Parsed_StrToDate(DtrBreak1TimeInString, parsedTime_Break1_IN)

                'Dim DTR_militaryTime_Break1_IN As String = parsedTime_Break1_IN.ToString("HH:mm")
                'Dim parsedTime_Break1_OUT As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(3).Value, "h:mm tt", Nothing) ' Time OUT
                Dim parsedTime_Break1_OUT As DateTime
                Dim DtrBreak1TimeOutString As String = .GView_DTR.Rows(i).Cells(3).Value
                Parsed_StrToDate(DtrBreak1TimeOutString, parsedTime_Break1_OUT)

                'Dim DTR_militaryTime_Break1_OUT As String = parsedTime_Break1_OUT.ToString("HH:mm")

                ' Subtract the DTR against Schedule
                'Dim DTR_Break1_IN As DateTime = DateTime.Parse(DTR_militaryTime_Break1_IN) ' Time IN
                'Dim DTR_Break1_OUT As DateTime = DateTime.Parse(DTR_militaryTime_Break1_OUT) ' TimeUT

                Dim DTR_Break1_IN As DateTime = parsedTime_Break1_IN
                Dim DTR_Break1_OUT As DateTime = parsedTime_Break1_OUT

                Dim difference_Break1 As TimeSpan = DTR_Break1_IN - DTR_Break1_OUT
                minutesDifference_Break1 = CInt(difference_Break1.TotalMinutes)
#End Region
#Region "Over Break 2"
                ' minutesDifference_Break1 will be summed up with Break 2


                ' ============================= Over Break Calculation: 2nd Break ===========================

                ' Condition:
                '1 - If Cells are not empty, then calculate
                '2- There are normally 2 breaks in a shift but sometimes only 1 break is used.

                Try
                    ' Next is to calculate the Over Break
                    'Dim parsedTime_Break2_IN As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(6).Value, "h:mm tt", Nothing) ' Time IN
                    Dim parsedTime_Break2_IN As DateTime
                    Dim DtrBreak2TimeInString As String = .GView_DTR.Rows(i).Cells(6).Value

                    Parsed_StrToDate(DtrBreak2TimeInString, parsedTime_Break2_IN)
                    'Dim DTR_militaryTime_Break2_IN As String = parsedTime_Break2_IN.ToString("HH:mm")

                    'Dim parsedTime_Break2_OUT As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(5).Value, "h:mm tt", Nothing) ' Time OUT
                    Dim parsedTime_Break2_OUT As DateTime
                    Dim DtrBreak2TimeOutString As String = .GView_DTR.Rows(i).Cells(5).Value

                    Parsed_StrToDate(DtrBreak2TimeOutString, parsedTime_Break2_OUT)
                    'Dim DTR_militaryTime_Break2_OUT As String = parsedTime_Break2_OUT.ToString("HH:mm")

                    ' Subtract the DTR against Schedule
                    Dim DTR_Break_IN2 As DateTime = parsedTime_Break2_IN
                    Dim DTR_Break_OUT2 As DateTime = parsedTime_Break2_OUT


                    Dim difference_Break2 As TimeSpan = DTR_Break_IN2 - DTR_Break_OUT2
                    minutesDifference_Break2 = CInt(difference_Break2.TotalMinutes)

#End Region

                Catch ex As Exception

                End Try

                ' ===================== Combine Over Break 1 and Over Break 2 =====================

                .GView_DTR.Rows(i).Cells(9).Value = minutesDifference_Break1 + minutesDifference_Break2

                If CInt(.GView_DTR.Rows(i).Cells(9).Value) > 60 Then ' Over Break if greater then 60 minutes

                    .GView_DTR.Rows(i).Cells(10).Value = CInt(.GView_DTR.Rows(i).Cells(9).Value) - 60

                Else

                    .GView_DTR.Rows(i).Cells(10).Value = 0

                End If

            Next

#End Region
#Region "OT_UT_Total_Hours_Calc"

            ' ===================== Calculate Over Time / Under Time / Total Hours ====================================


            For i = 0 To 16

                ' Skip empty cells
                If .GView_DTR.Rows(i) IsNot Nothing AndAlso .GView_DTR.Rows(i).Cells(0) IsNot Nothing Then
                    If String.IsNullOrEmpty(.GView_DTR.Rows(i).Cells(0).Value?.ToString()) Then
                        Exit For
                    End If
                End If

                ' Get the Day from DTR
                dDTR_Date = .GView_DTR.Rows(i).Cells(0).Value
                Dim firstDate As String = dDTR_Date.Split("-"c)(0).Trim()
                Dim firstDateTime As DateTime

                ' Try parsing the date
                If Not DateTime.TryParseExact(firstDate, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, firstDateTime) Then
                    Throw New Exception("Invalid Date")
                End If

                iDTR_Day_Num = firstDateTime.Day ' This is the Day Num from DTR

                ' Parse Time IN
                Dim parsedFirstTime_DTR_IN As DateTime
                Parsed_StrToDate(.GView_DTR.Rows(i).Cells(2).Value, parsedFirstTime_DTR_IN)
                parsedFirst_Time_IN = parsedFirstTime_DTR_IN

                ' Determine the correct Time OUT (First, Second, or Night Shift)
                Dim parsedTimeOut_OT As DateTime
                Dim DtrTimeOTOutString As String



                ' Check which Time OUT is available and calculate
                If Not String.IsNullOrEmpty(.GView_DTR.Rows(i).Cells(7).Value.ToString()) Then
                    ' 3rd Time OUT (Overtime)
                    DtrTimeOTOutString = .GView_DTR.Rows(i).Cells(7).Value
                    Parsed_SchedStrToDate(firstDateTime, .GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(2).Value, Parsed_DTR_Sched_Time_OUT)
                    Parsed_SchedStrToDate(firstDateTime, .GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(1).Value, Parsed_DTR_Sched_Time_IN)
                ElseIf Not String.IsNullOrEmpty(.GView_DTR.Rows(i).Cells(5).Value.ToString()) Then
                    ' 2nd Time OUT (Overtime)
                    DtrTimeOTOutString = .GView_DTR.Rows(i).Cells(5).Value
                    Parsed_SchedStrToDate(firstDateTime, .GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(2).Value, Parsed_DTR_Sched_Time_OUT)
                    Parsed_SchedStrToDate(firstDateTime, .GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(1).Value, Parsed_DTR_Sched_Time_IN)
                ElseIf Not String.IsNullOrEmpty(.GView_DTR.Rows(i).Cells(3).Value.ToString()) Then
                    ' 1st Time OUT (Night Shift)
                    DtrTimeOTOutString = .GView_DTR.Rows(i).Cells(3).Value
                    Parsed_NsSchedStrToDate(firstDateTime, .GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(2).Value, Parsed_DTR_Sched_Time_OUT)
                    Parsed_SchedStrToDate(firstDateTime, .GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(1).Value, Parsed_DTR_Sched_Time_IN)
                Else
                    ' No Time OUT
                    No_Time_OUT = True
                    .GView_DTR.Rows(i).Cells(11).Value = 0 ' this will be overwritten
                    Continue For
                End If


                Parsed_StrToDate(DtrTimeOTOutString, parsedTimeOut_OT)

                parsedLast_Time_OUT = parsedTimeOut_OT

                ' Total Time Span and Hours Spent
                Total_TimeSpan = parsedLast_Time_OUT - Parsed_DTR_Sched_Time_IN
                Total_Hours_Spent = Total_TimeSpan.TotalHours

                ' Time Out: Overtime or Undertime
                OUT_Over_Under_Time = parsedLast_Time_OUT - Parsed_DTR_Sched_Time_OUT

                If OUT_Over_Under_Time >= TimeSpan.Zero Then
                    ' Overtime
                    OUT_Over_Under_Time = OUT_Over_Under_Time
                Else
                    ' Undertime
                    OUT_Over_Under_Time = OUT_Over_Under_Time
                End If

                ' Time IN: Late or Early
                IN_early_late_Time = parsedFirst_Time_IN - Parsed_DTR_Sched_Time_IN

                If IN_early_late_Time >= TimeSpan.Zero Then
                    IN_early_late_Time = IN_early_late_Time.Negate() ' Late
                Else
                    IN_early_late_Time = TimeSpan.Zero ' Early
                End If

                ' Calculate Late and Overtime
                Dim difference_OT As TimeSpan = parsedLast_Time_OUT - Parsed_DTR_Sched_Time_OUT
                Dim minutesDifference_OT As Integer = CInt(difference_OT.TotalMinutes)

                Dim difference_LATE As TimeSpan = parsedFirst_Time_IN - Parsed_DTR_Sched_Time_IN
                Dim minutesDifference_LATE As Integer = CInt(difference_LATE.TotalMinutes)
                'overtime_calc
                If minutesDifference_OT >= 0 Then
                    .GView_DTR.Rows(i).Cells(11).Value = minutesDifference_OT
                Else
                    .GView_DTR.Rows(i).Cells(11).Value = 0
                End If
                'late_cal
                If minutesDifference_LATE >= 0 Then
                    .GView_DTR.Rows(i).Cells(8).Value = minutesDifference_LATE
                Else
                    .GView_DTR.Rows(i).Cells(8).Value = 0
                End If

                ' Compute Total Hours
                Dim Total_hours As Double = Total_Hours_Spent + IN_early_late_Time.TotalHours - OUT_Over_Under_Time.TotalHours
                If No_Time_OUT Then Total_hours = 0 ' No Time OUT

                .GView_DTR.Rows(i).Cells(12).Value = Total_hours.ToString("F2")

                ' Update global variable
                GlobalVariables.iHours_Rendered(i) = .GView_DTR.Rows(i).Cells(12).Value

            Next

            ' Calculate Overall Hours
            Dim Overall_Hours As Double = 0
            For i = 0 To 16
                Overall_Hours += CDbl(.GView_DTR.Rows(i).Cells(12).Value)
            Next

            .GView_DTR.Rows(17).Cells(11).Value = "Total:"
            .GView_DTR.Rows(17).Cells(12).Value = Overall_Hours

#End Region

        End With

    End Sub

    Public Sub Save_DTR_Total_Hours(iSub_Client_ID As Integer, sEmployee_ID As String, sCutOff_Period As String, iNumber_of_Days As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_DTR_BIOMETRIC.GView_DTR


                SQL = "INSERT INTO PRL_DTR_TOTAL_HOURS (EMPLOYEE_ID, SUB_CLIENT_ID, CUTOFF_PERIOD, NUM_OF_DAYS ,TOTAL_HOURS, REG, SUN, SH, LH,RD_SUN_SH, RD_SUN_LH, ND_REG, ND_SUN, ND_SH, ND_LH,ND_RD_SUN_SH,ND_RD_SUN_LH, OT_REG)"
                SQL = SQL & " VALUES ('" & sEmployee_ID & "', " & iSub_Client_ID & ", '" & sCutOff_Period & "', " & iNumber_of_Days & ",'" & .Rows(17).Cells(12).Value & "', '" & .Rows(17).Cells(13).Value & "'"
                SQL = SQL & " ,'" & .Rows(17).Cells(14).Value & "','" & .Rows(17).Cells(15).Value & "','" & .Rows(17).Cells(16).Value & "','" & .Rows(17).Cells(17).Value & "'"
                SQL = SQL & " ,'" & .Rows(17).Cells(18).Value & "','" & .Rows(17).Cells(19).Value & "','" & .Rows(17).Cells(20).Value & "','" & .Rows(17).Cells(21).Value & "'"
                SQL = SQL & " ,'" & .Rows(17).Cells(22).Value & "','" & .Rows(17).Cells(23).Value & "','" & .Rows(17).Cells(24).Value & "','" & .Rows(17).Cells(25).Value & "')"

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

                MsgBox("DTR Total Hours was successfully saved!", vbInformation, "Saved")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving total hours!")

        End Try

        GlobalVariables.GlobalCon.Close()


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
                SQL = "Select DAY_NUM, SCHED_IN, SCHED_OUT,TOTAL_HOURS, FLAG_SHIFT  from PRL_EMPLOYEE_SCHEDULE where EMPLOYEE_ID = '" & iEmployee_ID & "' and DAY_NUM <= 15"
            ElseIf iCutOff = 2 Then
                SQL = "Select DAY_NUM, SCHED_IN, SCHED_OUT,TOTAL_HOURS, FLAG_SHIFT  from PRL_EMPLOYEE_SCHEDULE where EMPLOYEE_ID = '" & iEmployee_ID & "' and DAY_NUM > 15"
            ElseIf iCutOff = 0 Then
                SQL = "Select DAY_NUM, SCHED_IN, SCHED_OUT,TOTAL_HOURS, FLAG_SHIFT  from PRL_EMPLOYEE_SCHEDULE where EMPLOYEE_ID = '" & iEmployee_ID & "' "
            End If

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATA

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

                            For i As Integer = 0 To dt.Columns.Count - 1

                                FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Cells(i).Value = row(i).ToString()

                            Next

                        Next
                    ElseIf iCutOff = 2 Then
                        FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows.Clear()
                        For Each row As DataRow In dt.Rows

                            Dim newRow As Integer = FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows.Add()

                            For i As Integer = 0 To dt.Columns.Count - 1

                                FRM_DTR_SCHEDULE.GView_Schedule16_30.Rows(newRow).Cells(i).Value = row(i).ToString()

                            Next

                        Next
                    End If

                End If

            Else

            End If



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()



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

    Private Sub Parsed_SchedStrToDate(RefDate As DateTime, sScheduleDateTimeStr As String, ByRef parsedSchedule_DateTime As DateTime)
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
