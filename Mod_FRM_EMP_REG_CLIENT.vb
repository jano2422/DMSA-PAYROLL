Imports System.Data.OleDb

Module Mod_FRM_EMP_REG_CLIENT

    Public Sub Search_Client(sCategory As String, sSearch_String As String)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT SUB_CLIENT_ID, SUB_CLIENT_NAME, ADDRESS FROM TBL_CLIENT_SUB WHERE " & sCategory & " like '%" & sSearch_String & "%' AND SUB_CLIENT_STATUS = 'Active' ORDER BY SUB_CLIENT_NAME ASC "


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_CLIENT_REG.LV_Main_Client_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("sub_client_id"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("sub_client_name"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("address"))

                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_DTR.LV_EmployeeList.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Client List Selection Error")
        End Try

        GlobalVariables.GlobalCon.Close()






    End Sub

    Public Sub Show_Client_Selection(sSub_Client_Name As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT SUB_CLIENT_ID, SUB_CLIENT_NAME, ADDRESS, DAILY_WAGE FROM TBL_CLIENT_SUB WHERE SUB_CLIENT_NAME like '%" & sSub_Client_Name & "%' AND SUB_CLIENT_STATUS = 'Active' ORDER BY SUB_CLIENT_NAME ASC " ' Need to check Main Client Status as well, consider connecting to Main Client Table

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_CLIENT_REG.LV_Main_Client_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("sub_client_id"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("sub_client_name"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("address"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("DAILY_WAGE"))

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
