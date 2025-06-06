Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Configuration
Module Mod_FRM_SCHEDULE

    Public Sub Auto_Compute_total_Hours_Shedule()
        Dim totalHours As Double

        Try
            With FRM_DTR_SCHEDULE
                ' Process GView_Schedule1_15 (Rows 1-15)
                For iRow = 0 To .GView_Schedule1_15.Rows.Count - 1
                    If Not IsDBNull(.GView_Schedule1_15.Rows(iRow).Cells(0).Value) AndAlso
                   Not IsDBNull(.GView_Schedule1_15.Rows(iRow).Cells(1).Value) AndAlso
                   Not IsDBNull(.GView_Schedule1_15.Rows(iRow).Cells(2).Value) AndAlso
                   Not IsDBNull(.GView_Schedule1_15.Rows(iRow).Cells(3).Value) AndAlso
                   .GView_Schedule1_15.Rows(iRow).Cells(0).Value IsNot Nothing AndAlso
                   .GView_Schedule1_15.Rows(iRow).Cells(1).Value IsNot Nothing AndAlso
                   .GView_Schedule1_15.Rows(iRow).Cells(2).Value IsNot Nothing AndAlso
                   .GView_Schedule1_15.Rows(iRow).Cells(3).Value IsNot Nothing AndAlso
                   .GView_Schedule1_15.Rows(iRow).Cells(1).Value.ToString().Trim() <> "" AndAlso
                   .GView_Schedule1_15.Rows(iRow).Cells(3).Value.ToString().Trim() <> "" Then

                        ' Construct full DateTime from DayNum and Time
                        Dim dayIn As Integer = CInt(.GView_Schedule1_15.Rows(iRow).Cells(0).Value)
                        Dim dayOut As Integer = CInt(.GView_Schedule1_15.Rows(iRow).Cells(2).Value)
                        Dim timeIn As DateTime = DateTime.Parse(.GView_Schedule1_15.Rows(iRow).Cells(1).Value)
                        Dim timeOut As DateTime = DateTime.Parse(.GView_Schedule1_15.Rows(iRow).Cells(3).Value)

                        ' Adjust timeOut to match the correct day
                        If dayOut > dayIn Then
                            timeOut = timeOut.AddDays(dayOut - dayIn)
                        End If

                        ' Compute total hours
                        totalHours = (timeOut - timeIn).TotalHours

                        ' Store the computed hours
                        .GView_Schedule1_15.Rows(iRow).Cells(4).Value = Math.Abs(Math.Round(totalHours, 2, MidpointRounding.AwayFromZero))
                    End If
                Next

                ' Process GView_Schedule16_31 (Rows 16-31)
                For iRow = 0 To .GView_Schedule16_30.Rows.Count - 1
                    If Not IsDBNull(.GView_Schedule16_30.Rows(iRow).Cells(0).Value) AndAlso
                   Not IsDBNull(.GView_Schedule16_30.Rows(iRow).Cells(1).Value) AndAlso
                   Not IsDBNull(.GView_Schedule16_30.Rows(iRow).Cells(2).Value) AndAlso
                   Not IsDBNull(.GView_Schedule16_30.Rows(iRow).Cells(3).Value) AndAlso
                   .GView_Schedule16_30.Rows(iRow).Cells(0).Value IsNot Nothing AndAlso
                   .GView_Schedule16_30.Rows(iRow).Cells(1).Value IsNot Nothing AndAlso
                   .GView_Schedule16_30.Rows(iRow).Cells(2).Value IsNot Nothing AndAlso
                   .GView_Schedule16_30.Rows(iRow).Cells(3).Value IsNot Nothing AndAlso
                   .GView_Schedule16_30.Rows(iRow).Cells(1).Value.ToString().Trim() <> "" AndAlso
                   .GView_Schedule16_30.Rows(iRow).Cells(3).Value.ToString().Trim() <> "" Then

                        ' Construct full DateTime from DayNum and Time
                        Dim dayIn As Integer = CInt(.GView_Schedule16_30.Rows(iRow).Cells(0).Value)
                        Dim dayOut As Integer = CInt(.GView_Schedule16_30.Rows(iRow).Cells(2).Value)
                        Dim timeIn As DateTime = DateTime.Parse(.GView_Schedule16_30.Rows(iRow).Cells(1).Value)
                        Dim timeOut As DateTime = DateTime.Parse(.GView_Schedule16_30.Rows(iRow).Cells(3).Value)

                        ' Adjust timeOut to match the correct day
                        If dayOut > dayIn Then
                            timeOut = timeOut.AddDays(dayOut - dayIn)
                        End If

                        ' Compute total hours
                        totalHours = (timeOut - timeIn).TotalHours

                        ' Store the computed hours
                        .GView_Schedule16_30.Rows(iRow).Cells(4).Value = Math.Abs(Math.Round(totalHours, 2, MidpointRounding.AwayFromZero))
                    End If
                Next
            End With
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub






    Public Sub Update_2ndCutoff_Cells(sTime_IN As String, sTime_OUT As String)

        With FRM_DTR_SCHEDULE

            .GView_Schedule16_30.Rows.Clear()
            For i = 0 To 15
                .GView_Schedule16_30.Rows.Add()
                .GView_Schedule16_30.Rows(i).Cells(0).Value = (i + 16).ToString()
                .GView_Schedule16_30.Rows(i).Cells(1).Value = .Cmb_2nd_TimeIN.Text
                .GView_Schedule16_30.Rows(i).Cells(3).Value = .Cmb_2nd_TimeOUT.Text

                ' Create a ComboBox in column 2
                Dim comboCell As New DataGridViewComboBoxCell()
                comboCell.Items.Add((i + 16).ToString()) ' Add current row number
                If i < 13 Then
                    comboCell.Items.Add((i + 17).ToString()) ' Add next row number
                End If

                ' Assign the ComboBox cell to column 2
                .GView_Schedule16_30.Rows(i).Cells(2) = comboCell

                ' Set the default selected value to the first item in the ComboBox
                If comboCell.Items.Count > 0 Then
                    .GView_Schedule16_30.Rows(i).Cells(2).Value = comboCell.Items(0)
                End If
            Next

            MsgBox("Time IN and Time OUT were successfully updated!", vbInformation, "Updated")

        End With





    End Sub
    Public Sub Update_1stCutoff_Cells(sTime_IN As String, sTime_OUT As String)
        With FRM_DTR_SCHEDULE
            .GView_Schedule1_15.Rows.Clear()

            For i = 0 To 14
                .GView_Schedule1_15.Rows.Add()
                .GView_Schedule1_15.Rows(i).Cells(0).Value = (i + 1).ToString()
                .GView_Schedule1_15.Rows(i).Cells(1).Value = .Cmb_1st_TimeIN.Text
                .GView_Schedule1_15.Rows(i).Cells(3).Value = .Cmb_1st_TimeOUT.Text

                ' Create a ComboBox in column 2
                Dim comboCell As New DataGridViewComboBoxCell()
                comboCell.Items.Add((i + 1).ToString()) ' Add current row number
                If i < 13 Then
                    comboCell.Items.Add((i + 2).ToString()) ' Add next row number
                End If

                ' Assign the ComboBox cell to column 2
                .GView_Schedule1_15.Rows(i).Cells(2) = comboCell

                ' Set the default selected value to the first item in the ComboBox
                If comboCell.Items.Count > 0 Then
                    .GView_Schedule1_15.Rows(i).Cells(2).Value = comboCell.Items(0)
                End If
            Next

            MsgBox("Time IN and Time OUT were successfully updated!", vbInformation, "Updated")
        End With
    End Sub



    Public Function Verify_Schedule_Validity() As Integer
        Dim First_Cut_Off_Time As String
        Dim Second_Cut_Off_Time As String

        With FRM_DTR_SCHEDULE
            ' Loop through only columns 1 and 3
            For Each iCol As Integer In {1, 3}
                For iRow = 0 To .GView_Schedule1_15.Rows.Count - 2

                    First_Cut_Off_Time = .GView_Schedule1_15.Rows(iRow).Cells(iCol).Value

                    ' Check if the value is in the correct time format HH:mm or H:mm
                    If Not IsValidTimeFormat(First_Cut_Off_Time) Then
                        Return -1
                    End If

                Next
            Next

            For Each iCol As Integer In {1, 3}
                For iRow = 0 To .GView_Schedule16_30.Rows.Count - 2

                    Second_Cut_Off_Time = .GView_Schedule16_30.Rows(iRow).Cells(iCol).Value

                    ' Check if the value is in the correct time format HH:mm or H:mm
                    If Not IsValidTimeFormat(Second_Cut_Off_Time) Then
                        Return -1
                    End If

                Next
            Next

            ' If all rows and columns are valid, return success
            Return 0
        End With
    End Function


    ' Helper function to validate time format
    Private Function IsValidTimeFormat(timeString As String) As Boolean
        Dim timeParts() As String

        ' Check if the string contains a colon
        If Not timeString.Contains(":") Then
            Return False
        End If

        ' Split the string into parts
        timeParts = timeString.Split(":"c)
        If timeParts.Length <> 2 Then
            Return False
        End If

        ' Check if both parts are numeric and within valid ranges
        Dim hours As Integer
        Dim minutes As Integer

        If Integer.TryParse(timeParts(0), hours) AndAlso Integer.TryParse(timeParts(1), minutes) Then
            If hours >= 0 AndAlso hours <= 24 AndAlso minutes >= 0 AndAlso minutes <= 60 Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Sub Generate_Default_Schedule(sEmployee_ID As String)
        Try
            With FRM_DTR_SCHEDULE
                Connect_to_MDB()

                ' Retrieve all EMPLOYEE_IDs from VIEW_PAYROLL_EMPLOYEE_LIST
                Dim empList As New List(Of String)
                Dim empSQL As String = "SELECT EMPLOYEE_ID FROM VIEW_PAYROLL_EMPLOYEE_LIST"
                Dim empCmd As New OleDbCommand(empSQL, GlobalVariables.GlobalCon)

                Using reader As OleDbDataReader = empCmd.ExecuteReader()
                    While reader.Read()
                        empList.Add(reader.GetString(0)) ' Assuming EMPLOYEE_ID is a string
                    End While
                End Using

                ' Initialize ProgressBar
                .ProgressBar_Save.Visible = True
                .ProgressBar_Save.Minimum = 0
                .ProgressBar_Save.Maximum = 31 ' Total iterations
                .ProgressBar_Save.Value = 0
                .ProgressBar_Save.Step = 1


                For iDay As Integer = 1 To 31
                    Dim sSched_IN As String = If(iDay <= 15, "07:00", "19:00")
                    Dim sSched_OUT As String = If(iDay <= 15, "19:00", "07:00")
                    Dim sTotal_Hours As String = "12"
                    Dim iDayOut As Integer = iDay

                    ' Call function to update or insert
                    Generate_SecGuard_Schedule(sEmployee_ID, iDay, sSched_IN, iDayOut, sSched_OUT, sTotal_Hours)

                    ' Update ProgressBar
                    .ProgressBar_Save.PerformStep()
                    Application.DoEvents() ' Allows UI to update while looping
                Next

                MsgBox("The schedule has been successfully set!", vbInformation, "Success")
                .ProgressBar_Save.Visible = False
            End With


        Catch ex As Exception
            MsgBox("Error updating schedules: " & ex.Message, vbCritical, "Error")
            FRM_DTR_SCHEDULE.ProgressBar_Save.Visible = False
        Finally
            ' Ensure the connection is closed
            If GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try
    End Sub
    Public Sub Generate_All_Schedules()
        Try
            With FRM_DTR_SCHEDULE
                Connect_to_MDB()

                ' Retrieve all EMPLOYEE_IDs from VIEW_PAYROLL_EMPLOYEE_LIST
                Dim empList As New List(Of String)
                Dim empSQL As String = "SELECT EMPLOYEE_ID FROM VIEW_PAYROLL_EMPLOYEE_LIST"
                Dim empCmd As New OleDbCommand(empSQL, GlobalVariables.GlobalCon)

                Using reader As OleDbDataReader = empCmd.ExecuteReader()
                    While reader.Read()
                        empList.Add(reader.GetString(0)) ' Assuming EMPLOYEE_ID is a string
                    End While
                End Using

                ' Initialize ProgressBar
                .ProgressBar_Save.Visible = True
                .ProgressBar_Save.Minimum = 0
                .ProgressBar_Save.Maximum = empList.Count * 31 ' Total iterations
                .ProgressBar_Save.Value = 0
                .ProgressBar_Save.Step = 1

                ' Loop through employees and update their schedules
                For Each empId In empList
                    For iDay As Integer = 1 To 31
                        Dim sSched_IN As String = If(iDay <= 15, "07:00", "19:00")
                        Dim sSched_OUT As String = If(iDay <= 15, "19:00", "07:00")
                        Dim sTotal_Hours As String = "12"
                        Dim iDayOut As Integer = iDay

                        ' Call function to update or insert
                        Generate_SecGuard_Schedule(empId, iDay, sSched_IN, iDayOut, sSched_OUT, sTotal_Hours)

                        ' Update ProgressBar
                        .ProgressBar_Save.PerformStep()
                        Application.DoEvents() ' Allows UI to update while looping
                    Next
                Next

                MsgBox("The schedule has been successfully set!", vbInformation, "Success")
                .ProgressBar_Save.Visible = False
            End With


        Catch ex As Exception
            MsgBox("Error updating schedule: " & ex.Message, vbCritical, "Error")
            FRM_DTR_SCHEDULE.ProgressBar_Save.Visible = False
        Finally
            ' Ensure the connection is closed
            If GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try
    End Sub

    Public Sub Generate_SecGuard_Schedule(sEmployee_ID As String, iDay As Integer, sSched_IN As String, iDayOut As Integer, sSched_OUT As String, sTotal_Hours As String)
        With FRM_DTR_SCHEDULE
            Dim SQL As String
            Connect_to_MDB() ' Ensure the database connection is open

            Try
                ' First, check if the record exists
                Dim checkSQL As String = "SELECT COUNT(*) FROM PRL_EMPLOYEE_SCHEDULE WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' AND DAY_NUM = " & iDay
                Dim checkCmd As New OleDbCommand(checkSQL, GlobalVariables.GlobalCon)
                Dim recordCount As Integer = CInt(checkCmd.ExecuteScalar())

                If recordCount > 0 Then
                    ' ✅ Corrected UPDATE query
                    SQL = "UPDATE PRL_EMPLOYEE_SCHEDULE SET SCHED_IN = '" & sSched_IN & "', " &
                      "SCHED_OUT = '" & sSched_OUT & "', TOTAL_HOURS = '" & sTotal_Hours & "', " &
                      "DAY_NUM_OUT = " & iDayOut & " WHERE EMPLOYEE_ID = '" & sEmployee_ID & "' " &
                      "AND DAY_NUM = " & iDay
                Else
                    ' ✅ Corrected INSERT query (Added DAY_OUT column and fixed value order)
                    SQL = "INSERT INTO PRL_EMPLOYEE_SCHEDULE (EMPLOYEE_ID, DAY_NUM, SCHED_IN, SCHED_OUT, TOTAL_HOURS, DAY_NUM_OUT) " &
                      "VALUES ('" & sEmployee_ID & "', " & iDay & ", '" & sSched_IN & "', '" & sSched_OUT & "', '" & sTotal_Hours & "', " & iDayOut & ")"
                End If

                ' Execute the command
                Dim SQLcmd As New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

            Catch ex As Exception
                MsgBox("Error updating schedule for Day " & iDay & ": " & ex.Message, vbCritical, "Error")

            Finally
                ' Ensure the connection is closed
                If GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                    GlobalVariables.GlobalCon.Close()
                End If
            End Try
        End With
    End Sub






    Public Sub Update_SecGuard_Schedule(sEmployee_ID As String, iDay As Integer, sSched_IN As String, iDayOut As Object, sSched_OUT As String, sTotal_Hours As String)
        With FRM_DTR_SCHEDULE
            Dim SQL As String

            Connect_to_MDB()

            Try
                ' First, check if the record exists
                Dim checkSQL As String = "SELECT COUNT(*) FROM PRL_EMPLOYEE_SCHEDULE WHERE employee_id = '" & sEmployee_ID & "' AND DAY_NUM = " & iDay
                Dim checkCmd As New OleDbCommand(checkSQL, GlobalVariables.GlobalCon)
                Dim recordCount As Integer = CInt(checkCmd.ExecuteScalar())

                ' Prepare iDayOut handling (only insert if not empty)
                Dim updateDayOut As Boolean = Not (IsNothing(iDayOut) OrElse iDayOut.ToString().Trim() = "")

                If recordCount > 0 Then
                    ' Record exists, perform an UPDATE
                    SQL = "UPDATE PRL_EMPLOYEE_SCHEDULE SET SCHED_IN = '" & sSched_IN & "', SCHED_OUT = '" & sSched_OUT & "', TOTAL_HOURS = '" & sTotal_Hours & "'"

                    ' Only update DAY_NUM_OUT if it has a valid value
                    If updateDayOut Then
                        SQL &= ", DAY_NUM_OUT = " & iDayOut
                    End If

                    SQL &= " WHERE employee_id = '" & sEmployee_ID & "' AND DAY_NUM = " & iDay
                Else
                    ' Record does NOT exist, perform an INSERT
                    If updateDayOut Then
                        SQL = "INSERT INTO PRL_EMPLOYEE_SCHEDULE (employee_id, DAY_NUM, SCHED_IN, DAY_NUM_OUT, SCHED_OUT, TOTAL_HOURS) VALUES ('" & sEmployee_ID & "', " & iDay & ", '" & sSched_IN & "', " & iDayOut & ", '" & sSched_OUT & "', '" & sTotal_Hours & "')"
                    Else
                        SQL = "INSERT INTO PRL_EMPLOYEE_SCHEDULE (employee_id, DAY_NUM, SCHED_IN, SCHED_OUT, TOTAL_HOURS) VALUES ('" & sEmployee_ID & "', " & iDay & ", '" & sSched_IN & "', '" & sSched_OUT & "', '" & sTotal_Hours & "')"
                    End If
                End If

                ' Execute the command
                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error saving Day: '" & iDay & "'")

            Finally
                ' Ensure the connection is closed
                If GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                    GlobalVariables.GlobalCon.Close()
                End If
            End Try
        End With
    End Sub




End Module
