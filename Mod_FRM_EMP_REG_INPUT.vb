Imports System.Data.OleDb

Module Mod_FRM_EMP_REG_INPUT


    Public Sub Generate_Employee_ID()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        Dim MaxID, NewID As String
        Dim YearNow As String = Date.Today.Year

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        SQL = "SELECT MAX(EMPLOYEE_ID) AS NEW_ID FROM HR_EMPLOYEE_RECORD_HDR"

        Try

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow


                For Each myRow In dt.Rows

                    MaxID = CInt(Mid(myRow.Item("NEW_ID"), 3, Len(myRow.Item("NEW_ID") - 2))) + 1
                    NewID = Right(YearNow, 2) + MaxID.ToString().PadLeft(4, "0")
                    FRM_HRIS_APPLICATION.Txt_Employee_ID.Text = NewID

                Next

            Else
                MsgBox("No Record found")

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub


End Module

