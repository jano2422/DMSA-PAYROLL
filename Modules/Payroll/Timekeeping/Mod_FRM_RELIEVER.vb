Imports System.Data.OleDb
Module Mod_FRM_RELIEVER

    Public Sub Reflect_Reliever_Rec_to_DTR_INPUT(sDayRelieved As Integer, sShift As String)
        With FRM_DTR_INPUT
            Select Case sDayRelieved
                Case 1
                    If sShift = "AM" Then
                        .Chk1AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk1PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk1AM.Checked = True
                        .Chk1PM.Checked = True
                    End If
                Case 2
                    If sShift = "AM" Then
                        .Chk2AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk2PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk2AM.Checked = True
                        .Chk2PM.Checked = True
                    End If
                Case 3
                    If sShift = "AM" Then
                        .Chk3AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk3PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk3AM.Checked = True
                        .Chk3PM.Checked = True
                    End If
                Case 4
                    If sShift = "AM" Then
                        .Chk4AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk4PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk4AM.Checked = True
                        .Chk4PM.Checked = True
                    End If
                Case 5
                    If sShift = "AM" Then
                        .Chk5AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk5PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk5AM.Checked = True
                        .Chk5PM.Checked = True
                    End If
                Case 6
                    If sShift = "AM" Then
                        .Chk6AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk6PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk6AM.Checked = True
                        .Chk6PM.Checked = True
                    End If
                Case 7
                    If sShift = "AM" Then
                        .Chk7AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk7PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk7AM.Checked = True
                        .Chk7PM.Checked = True
                    End If
                Case 8
                    If sShift = "AM" Then
                        .Chk8AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk8PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk8AM.Checked = True
                        .Chk8PM.Checked = True
                    End If
                Case 9
                    If sShift = "AM" Then
                        .Chk9AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk9PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk9AM.Checked = True
                        .Chk9PM.Checked = True
                    End If
                Case 10
                    If sShift = "AM" Then
                        .Chk10AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk10PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk10AM.Checked = True
                        .Chk10PM.Checked = True
                    End If
                Case 11
                    If sShift = "AM" Then
                        .Chk11AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .CHK11PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk11AM.Checked = True
                        .CHK11PM.Checked = True
                    End If
                Case 12
                    If sShift = "AM" Then
                        .Chk12AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk12PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk12AM.Checked = True
                        .Chk12PM.Checked = True
                    End If
                Case 13
                    If sShift = "AM" Then
                        .Chk13AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk13PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk13AM.Checked = True
                        .Chk13PM.Checked = True
                    End If
                Case 14
                    If sShift = "AM" Then
                        .Chk14AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk14PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk14AM.Checked = True
                        .Chk14PM.Checked = True
                    End If
                Case 15
                    If sShift = "AM" Then
                        .Chk15AM.Checked = True
                    ElseIf sShift = "PM" Then
                        .Chk15PM.Checked = True
                    ElseIf sShift = "Both" Then
                        .Chk15AM.Checked = True
                        .Chk15PM.Checked = True
                    End If

            End Select

        End With
    End Sub


    Public Sub Delete_Reliever_Record(iReliever_ID As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            ' TBL_RELIEVER
            SQL = "DELETE FROM TBL_DTR_RELIEVER WHERE DTR_NO = " & iReliever_ID & ""

            Dim SQLcmd1 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
            SQLcmd1.ExecuteNonQuery()
            SQLcmd1.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Deleting Reliever Record")

        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Sub Show_Reliever_List_to_LV(iDTR_No As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        FRM_RELIEVER.LV_Reliever_Dates.Items.Clear()

        Try

            SQL = "SELECT A.RELIEVER_ID, A.CLIENT_ID, A.DAY_RELIEVED, B.DAILY_WAGE , A.SHIFT"
            SQL = SQL & " FROM TBL_DTR_RELIEVER A, TBL_CLIENT_SUB B "
            SQL = SQL & " WHERE A.DTR_NO = " & iDTR_No & " "
            SQL = SQL & " AND A.CLIENT_ID = B.CLIENT_ID"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_RELIEVER.LV_Reliever_Dates

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("RELIEVER_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("CLIENT_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DAY_RELIEVED"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DAILY_WAGE"))

                        FRM_DTR_INPUT.Controls("TxtWage" & myRow.Item("DAY_RELIEVED")).text = myRow.Item("DAILY_WAGE") / 8
                        ' FRM_DTR_INPUT.Controls("TxtHours" & myRow.Item("DAY_RELIEVED")).text = "12"
                        FRM_DTR_INPUT.Controls("TxtWage" & myRow.Item("DAY_RELIEVED")).ForeColor = Color.Red

                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SHIFT"))


                    Next
                End With
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Reliever Date List")
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub


    Public Sub Save_Reliever(iDTR_No As Integer, iClient_ID As Integer, sYear As String, sPayroll_Period As String, sDayRelieved As Integer, sShift As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        FRM_RELIEVER.LV_Reliever_Dates.Items.Clear()

        Try
            ' Control to duplicate saving of Reliever Duties
            SQL = "SELECT DTR_NO, PAYROLL_YEAR, PAYROLL_PERIOD, DAY_RELIEVED FROM TBL_DTR_RELIEVER"
            SQL = SQL & " WHERE PAYROLL_YEAR = '" & sYear & "' AND PAYROLL_PERIOD = '" & sPayroll_Period & "' AND DAY_RELIEVED = " & sDayRelieved & ""

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                MsgBox("This Reliever Record is already existing.", vbCritical, "Already Existing")
                Exit Sub
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Reliever Date List")
        End Try

        Try
            Connect_to_MDB()
            With FRM_RELIEVER

                SQL = "INSERT INTO TBL_DTR_RELIEVER (DTR_NO, CLIENT_ID, PAYROLL_YEAR, PAYROLL_PERIOD,SHIFT, DAY_RELIEVED) "
                SQL = SQL & " VALUES (" & iDTR_No & "," & iClient_ID & ", '" & sYear & "','" & sPayroll_Period & "','" & sShift & "'," & sDayRelieved & ") "

                Dim SQLcmd3 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd3.ExecuteNonQuery()
                SQLcmd3.Dispose()

                MsgBox("Reliever Record was successfully saved!", vbInformation, "Saved")

                ' Reflect to DTR INPUT
                Call Reflect_Reliever_Rec_to_DTR_INPUT(sDayRelieved, sShift)


            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving to DTR Reliever")

        End Try

        GlobalVariables.GlobalCon.Close()





    End Sub



    Public Sub Show_Client_Selection_Reliever()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT CLIENT_ID, CLIENT_NAME FROM TBL_CLIENT_SUB ORDER BY CLIENT_NAME ASC "


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_RELIEVER.LV_Main_Client_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("CLIENT_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("client_name"))

                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_DTR.LV_EmployeeList.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Client List")
        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub
End Module
