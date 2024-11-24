Imports System.Data.OleDb

Module Mod_EMP_REG_INPUT


    Public Function Generate_Company_ID()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        SQL = "SELECT MAX(COMPANY_ID) AS NEW_ID FROM TBL_EMP_HDR"

        Try

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow
                Dim MaxID, NewID As String
                Dim YearNow As String = Date.Today.Year

                For Each myRow In dt.Rows

                    MaxID = CInt(Mid(myRow.Item("NEW_ID"), 3, Len(myRow.Item("NEW_ID") - 2))) + 1
                    NewID = Right(YearNow, 2) + MaxID.ToString().PadLeft(4, "0")
                    FRM_EMP_REG_INPUT.Txt_CompanyID.Text = NewID

                Next

            Else


            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Error in Generating ID Number")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Function






End Module
