Imports System.Data.OleDb
Module Mod_Acitivity_Logs

    Public Sub Show_System_Logs(dDate_From As Date, dDate_To As Date)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "Select * from TBL_LOGS WHERE DATE_COMMITTED >= Cdate('" & dDate_From & "') and DATE_COMMITTED <= Cdate('" & dDate_To & "')   ORDER BY DATE_COMMITTED DESC" ' For update of Date Range

            'DATE_FROM >= CDate('" & dDate_From & "') and Date_to <= CDate('" & dDate_To & "')"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_HR_REPORTS.LV_SystemLogs

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("USER_ID")) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("CHANGE_DESC"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DATE_COMMITTED"))



                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_HR_REPORTS.LV_SystemLogs.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

    Public Sub Record_activity_log(sEmployee_Logged_ID As String, sChange_Desc As String)

        Dim SQL As String

        Connect_to_MDB()

        Try

            SQL = "INSERT INTO TBL_LOGS (USER_ID, DATE_COMMITTED, CHANGE_DESC) VALUES ('" & sEmployee_Logged_ID & "','" & Date.Now.ToShortDateString & "', '" & sChange_Desc & "')"

            Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
            SQLcmd.ExecuteNonQuery()
            SQLcmd.Dispose()

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Erro creating logs")

        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub

End Module
