Imports System
Imports System.Collections.ObjectModel
Imports System.Data.OleDb
Imports DMSA_System.Models

Public Class ScheduleService
    Public Function FetchEmployeeSchedules(employeeID As String, startDay As Integer, endDay As Integer) As ObservableCollection(Of EmployeeSchedule)
        Dim schedules As New ObservableCollection(Of EmployeeSchedule)

        ' Ensure EmployeeID is provided
        If String.IsNullOrWhiteSpace(employeeID) Then
            Throw New ArgumentException("Error: EmployeeID is missing.")
        End If

        Try
            Using con As New OleDbConnection(GlobalVariables.GlobalConStr)
                con.Open()

                ' Query to filter schedules based on EmployeeID and payroll period (DAY_NUM range)
                Dim query As String = "SELECT EMPLOYEE_ID, DAY_NUM, SCHED_IN, SCHED_OUT, FLAG_SHIFT " &
                                  "FROM PRL_EMPLOYEE_SCHEDULE " &
                                  "WHERE EMPLOYEE_ID = ? AND DAY_NUM BETWEEN ? AND ? " &
                                  "ORDER BY DAY_NUM ASC"

                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("@p1", employeeID)
                    cmd.Parameters.AddWithValue("@p2", startDay)
                    cmd.Parameters.AddWithValue("@p3", endDay)

                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ' Extract EmployeeID
                            Dim empID As String = reader("EMPLOYEE_ID").ToString()

                            ' Parse SCHED_IN and SCHED_OUT times (Format: "DD HH:mm:ss")
                            Dim schedIn As String = reader("SCHED_IN").ToString()
                            Dim schedOut As String = reader("SCHED_OUT").ToString()

                            ' Extract day and time from SCHED_IN
                            Dim dayIn As Integer = Integer.Parse(schedIn.Substring(0, 2))
                            Dim timeIn As TimeSpan = TimeSpan.Parse(schedIn.Substring(3))

                            ' Extract day and time from SCHED_OUT
                            Dim dayOut As Integer = Integer.Parse(schedOut.Substring(0, 2))
                            Dim timeOut As TimeSpan = TimeSpan.Parse(schedOut.Substring(3))

                            ' Determine the shift end day (same or next day)
                            If timeOut < timeIn Then
                                dayOut += 1 ' If end time is earlier than start time, shift ends next day
                            End If

                            ' Convert to DateTime for ViewModel
                            Dim shiftStartDateTime As DateTime = New DateTime(DateTime.Today.Year, 1, dayIn, timeIn.Hours, timeIn.Minutes, timeIn.Seconds)
                            Dim shiftEndDateTime As DateTime = New DateTime(DateTime.Today.Year, 1, dayOut, timeOut.Hours, timeOut.Minutes, timeOut.Seconds)

                            ' Create EmployeeSchedule object
                            Dim schedule As New EmployeeSchedule With {
                            .EmployeeID = empID,
                            .DayNumber = Convert.ToInt32(reader("DAY_NUM")),
                            .ShiftStartDateTime = shiftStartDateTime,
                            .ShiftEndDateTime = shiftEndDateTime,
                            .ShiftType = reader("FLAG_SHIFT").ToString()
                        }

                            ' Total Hours Calculation is handled in EmployeeSchedule class (UpdateTotalHours method)
                            schedules.Add(schedule)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New ApplicationException($"Error fetching schedules: {ex.Message}")
        End Try

        Return schedules
    End Function



    Public Sub SaveEmployeeSchedules(scheduleList As ObservableCollection(Of EmployeeSchedule))
        Try
            Using con As New OleDbConnection(GlobalVariables.GlobalConStr)
                con.Open()

                For Each schedule In scheduleList
                    ' Check if the record already exists
                    Dim queryCheck As String = "SELECT COUNT(*) FROM PRL_EMPLOYEE_SCHEDULE WHERE EMPLOYEE_ID = ? AND DAY_NUM = ?"
                    Using cmdCheck As New OleDbCommand(queryCheck, con)
                        cmdCheck.Parameters.AddWithValue("@p1", schedule.EmployeeID)
                        cmdCheck.Parameters.AddWithValue("@p2", schedule.DayNumber)

                        Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())

                        If count > 0 Then
                            ' Update existing record
                            Dim queryUpdate As String = "UPDATE PRL_EMPLOYEE_SCHEDULE " &
                                                        "SET SCHED_IN = ?, SCHED_OUT = ?, TOTAL_HOURS = ?, FLAG_SHIFT = ? " &
                                                        "WHERE EMPLOYEE_ID = ? AND DAY_NUM = ?"
                            Using cmdUpdate As New OleDbCommand(queryUpdate, con)
                                cmdUpdate.Parameters.AddWithValue("@p1", schedule.ShiftStartDateTime.ToString("dd HH:mm:ss"))
                                cmdUpdate.Parameters.AddWithValue("@p2", schedule.ShiftEndDateTime.ToString("dd HH:mm:ss"))
                                cmdUpdate.Parameters.AddWithValue("@p3", schedule.TotalHours)
                                cmdUpdate.Parameters.AddWithValue("@p4", schedule.ShiftType)
                                cmdUpdate.Parameters.AddWithValue("@p5", schedule.EmployeeID)
                                cmdUpdate.Parameters.AddWithValue("@p6", schedule.DayNumber)
                                cmdUpdate.ExecuteNonQuery()
                            End Using
                        Else
                            ' Insert new record
                            Dim queryInsert As String = "INSERT INTO PRL_EMPLOYEE_SCHEDULE (EMPLOYEE_ID, DAY_NUM, SCHED_IN, SCHED_OUT, TOTAL_HOURS, FLAG_SHIFT) " &
                                                        "VALUES (?, ?, ?, ?, ?, ?)"
                            Using cmdInsert As New OleDbCommand(queryInsert, con)
                                cmdInsert.Parameters.AddWithValue("@p1", schedule.EmployeeID)
                                cmdInsert.Parameters.AddWithValue("@p2", schedule.DayNumber)
                                cmdInsert.Parameters.AddWithValue("@p3", schedule.ShiftStartDateTime.ToString("dd HH:mm:ss"))
                                cmdInsert.Parameters.AddWithValue("@p4", schedule.ShiftEndDateTime.ToString("dd HH:mm:ss"))
                                cmdInsert.Parameters.AddWithValue("@p5", schedule.TotalHours)
                                cmdInsert.Parameters.AddWithValue("@p6", schedule.ShiftType)
                                cmdInsert.ExecuteNonQuery()
                            End Using
                        End If
                    End Using
                Next
            End Using
        Catch ex As Exception
            Throw New ApplicationException($"Error saving schedules: {ex.Message}")
        End Try
    End Sub
End Class
