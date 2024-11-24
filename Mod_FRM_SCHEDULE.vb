Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Configuration
Module Mod_FRM_SCHEDULE

    Public Sub Auto_Compute_total_Hours_Shedule()

        Dim time As TimeSpan


        Try

            With FRM_DTR_SCHEDULE

                For iRow = 0 To 14
                    time = DateTime.Parse(.GView_Schedule1_15.Rows(iRow).Cells(2).Value) - DateTime.Parse(.GView_Schedule1_15.Rows(iRow).Cells(1).Value)


                    Dim hour As Integer = time.Hours
                    Dim minute As Integer = time.Minutes
                    Dim decimalTime As Double = hour + (minute / 60.0)

                    .GView_Schedule1_15.Rows(iRow).Cells(3).Value = decimalTime
                Next


                For iRow = 0 To 16
                    time = DateTime.Parse(.GView_Schedule16_30.Rows(iRow).Cells(2).Value) - DateTime.Parse(.GView_Schedule16_30.Rows(iRow).Cells(1).Value)

                    Dim hour As Integer = time.Hours
                    Dim minute As Integer = time.Minutes
                    Dim decimalTime As Double = hour + (minute / 60.0)

                    .GView_Schedule16_30.Rows(iRow).Cells(3).Value = decimalTime

                Next

            End With

        Catch ex As Exception

        End Try



    End Sub





    Public Sub Update_2ndCutoff_Cells(sTime_IN As String, sTime_OUT As String)

        With FRM_DTR_SCHEDULE


            For i = 0 To .GView_Schedule16_30.Rows.Count - 2

                .GView_Schedule16_30.Rows(i).Cells(1).Value = .Cmb_2nd_TimeIN.Text
                .GView_Schedule16_30.Rows(i).Cells(2).Value = .Cmb_2nd_TimeOUT.Text

            Next

            MsgBox("Time IN and Time OUT were successfully updated!", vbInformation, "Updated")

        End With





    End Sub
    Public Sub Update_1stCutoff_Cells(sTime_IN As String, sTime_OUT As String)

        With FRM_DTR_SCHEDULE


            For i = 0 To .GView_Schedule1_15.Rows.Count - 2

                .GView_Schedule1_15.Rows(i).Cells(1).Value = .Cmb_1st_TimeIN.Text
                .GView_Schedule1_15.Rows(i).Cells(2).Value = .Cmb_1st_TimeOUT.Text

            Next

            MsgBox("Time IN and Time OUT were successfully updated!", vbInformation, "Updated")

        End With





    End Sub

    Public Function Verify_Schedule_Validity()

        Dim First_Cut_Off_Time_IN As String
        Dim First_Cut_Off_Time_OUT As String



        With FRM_DTR_SCHEDULE

            For iCol = 1 To 2
                For iRow = 0 To .GView_Schedule1_15.Rows.Count - 2

                    First_Cut_Off_Time_IN = .GView_Schedule1_15.Rows(iRow).Cells(iCol).Value

                    ' Get the colon
                    If First_Cut_Off_Time_IN.Length = 5 Then

                        If IsNumeric(Mid(First_Cut_Off_Time_IN, 1, 2)) = False Then
                            Return -1
                        End If

                        If Mid(First_Cut_Off_Time_IN, 3, 1) <> ":" Then
                            Return -1
                        End If

                        If IsNumeric(Mid(First_Cut_Off_Time_IN, 4, 2)) = False Then
                            Return -1
                        End If


                    ElseIf First_Cut_Off_Time_IN.Length = 4 Then

                        If IsNumeric(Mid(First_Cut_Off_Time_IN, 1, 1)) = False Then
                            Return -1
                        End If

                        If Mid(First_Cut_Off_Time_IN, 2, 1) <> ":" Then
                            Return -1
                        End If

                        If IsNumeric(Mid(First_Cut_Off_Time_IN, 3, 2)) = False Then
                            Return -1
                        End If

                    End If



                Next
            Next

            Return 0

        End With


    End Function



    Public Sub Update_SecGuard_Schedule(sEmployee_ID As String, iDay As Integer, sSched_IN As String, sSched_OUT As String, sTotal_Hours As String)

        With FRM_DTR_SCHEDULE


            Dim SQL As String

            Connect_to_MDB()

            Try


                SQL = "UPDATE PRL_EMPLOYEE_SCHEDULE SET SCHED_IN = '" & sSched_IN & "', SCHED_OUT = '" & sSched_OUT & "', TOTAL_HOURS = '" & sTotal_Hours & "' where employee_id = '" & sEmployee_ID & "' and DAY_NUM = " & iDay & " "

                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Error saving Day: '" & iDay & "'")

            End Try

            GlobalVariables.GlobalCon.Close()


        End With



    End Sub


End Module
