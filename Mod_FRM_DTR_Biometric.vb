Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Globalization

Module Mod_Biometric_DTR

    Public Sub Calculate_DTR(sShift As String) ' 0 morning ; 1 night shift ( because I used checkbox )

        With FRM_DTR_BIOMETRIC


            ' Computation of Late, Over Break and Over Time after loading the schedule and DTR
            ' Temporary. This should be on a separate function

            Call Show_Employee_Schedule("240603", "No", 0) 'Temporary - Should be from the selected Employee 


            Dim DTR_Time_OUT_OT As DateTime
            Dim DTR_Sched_Time_OUT, DTR_Sched_DateTime_IN, DTR_Sched_Time_IN As DateTime

            Dim No_Time_OUT As Boolean
            No_Time_OUT = False

            Dim First_Time_IN, Last_Time_OUT As DateTime
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
                    If Not DateTime.TryParseExact(firstDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, firstDateTime) Then
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
                            If DateTime.TryParseExact(sSchedule_Time_IN, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, Nothing) Then
                                ' If parsing succeeds, extract the TimeSpan
                                Dim parsedSchedule_Time_IN As TimeSpan = DateTime.ParseExact(sSchedule_Time_IN, "HH:mm tt", CultureInfo.InvariantCulture).TimeOfDay
                                parsedSchedule_DateTime_IN = firstDateTime.Add(parsedSchedule_Time_IN)

                            Else Throw New Exception($"invalid schedule time format: {sSchedule_Time_IN}")
                            End If

                            ' Present on this day
                            .GView_Schedule.Rows(j).Cells(5).Value = "Present" ' j can also be the iDTR_Day_Num -1

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
                    If DateTime.TryParseExact(DtrTimeInString, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, parsedTime_DTR_IN) Then
                        ' Successfully parsed
                        Console.WriteLine($"Parsed DateTime: {parsedTime_DTR_IN}")
                    Else
                        ' Handle invalid format
                        Throw New Exception($"Invalid DateTime format: {DtrTimeInString}")
                    End If

                    'Dim DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("HH:mm")

                    Dim STR_DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)

                    Console.WriteLine($"Military Time Format: {STR_DTR_militaryTime_DTR_IN}")


                    ' Subtract the DTR Time IN against Schedule
                    'Dim DTR_Time_IN As DateTime = DateTime.Parse(STR_DTR_militaryTime_DTR_IN)

                    ' Parse the military time string into a DateTime object
                    If DateTime.TryParseExact(STR_DTR_militaryTime_DTR_IN, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, parsedTime_DTR_IN) Then
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
                Dim parsedTime_Break1_IN As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(4).Value, "h:mm tt", Nothing) ' Time IN
                Dim DTR_militaryTime_Break1_IN As String = parsedTime_Break1_IN.ToString("HH:mm")
                Dim parsedTime_Break1_OUT As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(3).Value, "h:mm tt", Nothing) ' Time OUT
                Dim DTR_militaryTime_Break1_OUT As String = parsedTime_Break1_OUT.ToString("HH:mm")

                ' Subtract the DTR against Schedule
                Dim DTR_Break1_IN As DateTime = DateTime.Parse(DTR_militaryTime_Break1_IN) ' Time IN
                Dim DTR_Break1_OUT As DateTime = DateTime.Parse(DTR_militaryTime_Break1_OUT) ' TimeUT


                Dim difference_Break1 As TimeSpan = DTR_Break1_IN - DTR_Break1_OUT
                minutesDifference_Break1 = CInt(difference_Break1.TotalMinutes)

                ' minutesDifference_Break1 will be summed up with Break 2


                ' ============================= Over Break Calculation: 2nd Break ===========================

                ' Condition:
                '1 - If Cells are not empty, then calculate
                '2- There are normally 2 breaks in a shift but sometimes only 1 break is used.

                Try
                    ' Next is to calculate the Over Break
                    Dim parsedTime_Break2_IN As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(6).Value, "h:mm tt", Nothing) ' Time IN
                    Dim DTR_militaryTime_Break2_IN As String = parsedTime_Break2_IN.ToString("HH:mm")
                    Dim parsedTime_Break2_OUT As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(5).Value, "h:mm tt", Nothing) ' Time OUT
                    Dim DTR_militaryTime_Break2_OUT As String = parsedTime_Break2_OUT.ToString("HH:mm")

                    ' Subtract the DTR against Schedule
                    Dim DTR_Break_IN2 As DateTime = DateTime.Parse(DTR_militaryTime_Break2_IN) ' Time IN
                    Dim DTR_Break_OUT2 As DateTime = DateTime.Parse(DTR_militaryTime_Break2_OUT) ' TimeUT


                    Dim difference_Break2 As TimeSpan = DTR_Break_IN2 - DTR_Break_OUT2
                    minutesDifference_Break2 = CInt(difference_Break2.TotalMinutes)



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


            For i = 0 To 18

                DTR_Time_OUT_OT = DTR_Sched_Time_OUT

                ' Just to stop if there are no more records (DTR)
                If .GView_DTR.Rows(i).Cells(0).Value = "" Then
                    Exit For ' Skip empty cells
                End If

                ' ===================================== Identify the Day Num as Row for the schedule table ==============================================

                ' This is to get the actual; DTR day to be used as the Day value for the Schedule
                dDTR_Date = .GView_DTR.Rows(i).Cells(0).Value

                ' Convert string into Date ( Format should be same from what is being converted )
                Dim format As String = "MM/dd/yyyy"
                Dim dateObject As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(0).Value, format, System.Globalization.CultureInfo.InvariantCulture)

                'dDTR_Date = dDTR_Date.ToString("MM-dd-yyyy")
                iDTR_Day_Num = dateObject.Day ' This is the Day Num from DTR

                ' =========================================================================================================================================




                First_Time_IN = DateTime.Parse(.GView_DTR.Rows(i).Cells(2).Value).ToString("HH:mm")

                If .GView_DTR.Rows(i).Cells(7).Value <> "" Then ' 3rd Time OUT

                    Dim parsedTime_OT As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(7).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_OT As String = parsedTime_OT.ToString("HH:mm")

                    ' Subtract the DTR against Schedule
                    DTR_Time_OUT_OT = DateTime.Parse(DTR_militaryTime_OT)
                    DTR_Sched_Time_OUT = DateTime.Parse(.GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(2).Value) ' Schedule Table
                    DTR_Sched_Time_IN = DateTime.Parse(.GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(1).Value) ' Schedule Table

                    ' Will assign this as the Last Time OUT
                    Last_Time_OUT = DTR_militaryTime_OT
                    'Total_TimeSpan = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(First_Time_IN.ToString("HH:mm")) ' Actual Time OUT - Actual Time IN
                    Total_TimeSpan = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(DTR_Sched_Time_IN.ToString("HH:mm")) ' Actual Time OUT - Actual Time IN
                    Total_Hours_Spent = Total_TimeSpan.TotalHours


                    ' Time Out ( identify if undertime or overtime )
                    OUT_Over_Under_Time = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(DTR_Sched_Time_OUT.ToString("HH:mm"))

                    If OUT_Over_Under_Time >= TimeSpan.Zero Then ' Overtime
                        'ignore excess time
                        OUT_Over_Under_Time = OUT_Over_Under_Time

                    Else ' Undertime
                        'Actual Time OUT 
                        OUT_Over_Under_Time = OUT_Over_Under_Time
                    End If

                    ' Time IN ( identify if late or early )
                    IN_early_late_Time = CDate(First_Time_IN.ToString("HH:mm")) - CDate(DTR_Sched_Time_IN.ToString("HH:mm"))

                    If IN_early_late_Time >= TimeSpan.Zero Then ' Late

                        IN_early_late_Time = IN_early_late_Time.Negate
                    Else ' Early

                        IN_early_late_Time = TimeSpan.Zero ' Since time-IN is earlier than schedule, it will not be deducted from Total Hours Spent

                    End If



                ElseIf .GView_DTR.Rows(i).Cells(5).Value <> "" Then ' 2nd Time OUT

                    Dim parsedTime_OT As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(5).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_OT As String = parsedTime_OT.ToString("HH:mm")


                    ' Subtract the DTR against Schedule
                    DTR_Time_OUT_OT = DateTime.Parse(DTR_militaryTime_OT)
                    DTR_Sched_Time_OUT = DateTime.Parse(.GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(2).Value) ' Schedule Table
                    DTR_Sched_Time_IN = DateTime.Parse(.GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(1).Value) ' Schedule Table

                    ' Will assign this as the Last Time OUT
                    Last_Time_OUT = DTR_militaryTime_OT
                    'Total_TimeSpan = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(First_Time_IN.ToString("HH:mm")) ' Actual Time OUT - Actual Time IN
                    Total_TimeSpan = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(DTR_Sched_Time_IN.ToString("HH:mm")) ' Actual Time OUT - Actual Time IN
                    Total_Hours_Spent = Total_TimeSpan.TotalHours


                    ' Time Out ( identify if undertime or overtime )
                    OUT_Over_Under_Time = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(DTR_Sched_Time_OUT.ToString("HH:mm"))

                    If OUT_Over_Under_Time >= TimeSpan.Zero Then ' Overtime
                        'ignore excess time
                        OUT_Over_Under_Time = OUT_Over_Under_Time

                    Else ' Undertime
                        'Actual Time OUT 
                        OUT_Over_Under_Time = OUT_Over_Under_Time
                    End If

                    ' Time IN ( identify if late or early )
                    IN_early_late_Time = CDate(First_Time_IN.ToString("HH:mm")) - CDate(DTR_Sched_Time_IN.ToString("HH:mm"))

                    If IN_early_late_Time >= TimeSpan.Zero Then ' Late

                        IN_early_late_Time = IN_early_late_Time.Negate
                    Else ' Early

                        IN_early_late_Time = TimeSpan.Zero ' Since time-IN is earlier than schedule, it will not be deducted from Total Hours Spent

                    End If

                ElseIf .GView_DTR.Rows(i).Cells(3).Value <> "" Then ' This one is when Night shift ( they don't have multiple Time in and out ) ' 1st Time OUT

                    Dim parsedTime_OT As DateTime = DateTime.ParseExact(.GView_DTR.Rows(i).Cells(3).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_OT As String = parsedTime_OT.ToString("HH:mm")

                    ' Subtract the DTR against Schedule
                    DTR_Time_OUT_OT = DateTime.Parse(DTR_militaryTime_OT)
                    DTR_Sched_Time_OUT = DateTime.Parse(.GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(2).Value) ' Schedule Table
                    DTR_Sched_Time_IN = DateTime.Parse(.GView_Schedule.Rows(iDTR_Day_Num - 1).Cells(1).Value) ' Schedule Table

                    ' Will assign this as the Last Time OUT
                    Last_Time_OUT = DTR_militaryTime_OT
                    'Total_TimeSpan = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(First_Time_IN.ToString("HH:mm")) ' Actual Time OUT - Actual Time IN
                    Total_TimeSpan = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(DTR_Sched_Time_IN.ToString("HH:mm")) ' Actual Time OUT - Actual Time IN
                    Total_Hours_Spent = Total_TimeSpan.TotalHours


                    ' Time Out ( identify if undertime or overtime )
                    OUT_Over_Under_Time = CDate(Last_Time_OUT.ToString("HH:mm")) - CDate(DTR_Sched_Time_OUT.ToString("HH:mm"))

                    If OUT_Over_Under_Time >= TimeSpan.Zero Then ' Overtime
                        'ignore excess time
                        OUT_Over_Under_Time = OUT_Over_Under_Time

                    Else ' Undertime
                        'Actual Time OUT 
                        OUT_Over_Under_Time = OUT_Over_Under_Time
                    End If

                    ' Time IN ( identify if late or early )
                    IN_early_late_Time = CDate(First_Time_IN.ToString("HH:mm")) - CDate(DTR_Sched_Time_IN.ToString("HH:mm"))

                    If IN_early_late_Time >= TimeSpan.Zero Then ' Late

                        IN_early_late_Time = IN_early_late_Time.Negate
                    Else ' Early

                        IN_early_late_Time = TimeSpan.Zero ' Since time-IN is earlier than schedule, it will not be deducted from Total Hours Spent

                    End If

                ElseIf .GView_DTR.Rows(i).Cells(3).Value = "" Then
                    ' Column 11 refers to Over Time, calculated outside this If Else
                    ' No Time OUT from the 3 Time OUT Cells from grid view
                    No_Time_OUT = True
                    .GView_DTR.Rows(i).Cells(11).Value = 0 ' this will be over written by the code below
                End If

                Dim difference_OT As TimeSpan = DTR_Time_OUT_OT - DTR_Sched_Time_OUT
                Dim minutesDifference_OT As Integer = CInt(difference_OT.TotalMinutes)

                ' If value is NEGATIVE, then employee is early. No Deduction or Over Time
                ' If the value is Positive, the employee is Late! the value needs to be deducted from the expected total hours.

                If minutesDifference_OT >= 0 Then ' LATE!
                    .GView_DTR.Rows(i).Cells(11).Value = minutesDifference_OT
                Else ' Not Late then should just be 0
                    .GView_DTR.Rows(i).Cells(11).Value = 0
                End If

                ' ======================== Total Hours ===============================

                Dim iLate, iOB, iOT As Double
                Dim Total_hours As Double



                iLate = CInt(.GView_DTR.Rows(i).Cells(8).Value)
                iOB = CInt(.GView_DTR.Rows(i).Cells(10).Value)
                'iOT = CInt(.GView_DTR.Rows(i).Cells(11).Value)

                If iOT < 60 Then
                    iOT = 0 ' because only >= 1 hour OT will be paid and if has certification/approval
                Else

                End If

                ' Compute Total Hours
                Total_hours = Total_Hours_Spent + IN_early_late_Time.TotalHours - OUT_Over_Under_Time.TotalHours

                If No_Time_OUT = True Then
                    Total_hours = 0 ' No Time OUT
                Else


                End If

                ' what is this for? is this a reset value? check later
                No_Time_OUT = False

                .GView_DTR.Rows(i).Cells(12).Value = Total_hours.ToString("F2")
                '.GView_DTR.Refresh()

                ' Transfer to Global Variable for the computaion of DTR
                GlobalVariables.iHours_Rendered(i) = .GView_DTR.Rows(i).Cells(12).Value

            Next

            Dim Overall_Hours As Double

            For i = 0 To 16
                Overall_Hours = Overall_Hours + CDbl(.GView_DTR.Rows(i).Cells(12).Value)
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
                SQL = "Select DAY_NUM, SCHED_IN, SCHED_OUT,TOTAL_HOURS  from PRL_EMPLOYEE_SCHEDULE where EMPLOYEE_ID = '" & iEmployee_ID & "' and DAY_NUM <= 15"
            ElseIf iCutOff = 2 Then
                SQL = "Select DAY_NUM, SCHED_IN, SCHED_OUT,TOTAL_HOURS  from PRL_EMPLOYEE_SCHEDULE where EMPLOYEE_ID = '" & iEmployee_ID & "' and DAY_NUM > 15"
            ElseIf iCutOff = 0 Then
                SQL = "Select DAY_NUM, SCHED_IN, SCHED_OUT,TOTAL_HOURS  from PRL_EMPLOYEE_SCHEDULE where EMPLOYEE_ID = '" & iEmployee_ID & "' "
            End If

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATA

                If sScheduler = "No" Then


                    For Each row As DataRow In dt.Rows
                        Dim newRow As Integer = FRM_DTR_BIOMETRIC.GView_Schedule.Rows.Add()
                        For i As Integer = 0 To dt.Columns.Count - 1
                            FRM_DTR_BIOMETRIC.GView_Schedule.Rows(newRow).Cells(i).Value = row(i).ToString()
                        Next

                    Next

                ElseIf sScheduler = "Yes" Then

                    If iCutOff = 1 Then

                        For Each row As DataRow In dt.Rows

                            Dim newRow As Integer = FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows.Add()

                            For i As Integer = 0 To dt.Columns.Count - 1

                                FRM_DTR_SCHEDULE.GView_Schedule1_15.Rows(newRow).Cells(i).Value = row(i).ToString()

                            Next

                        Next
                    ElseIf iCutOff = 2 Then

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





End Module
