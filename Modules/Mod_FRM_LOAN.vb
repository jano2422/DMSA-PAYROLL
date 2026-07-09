Imports System.Data.OleDb
Module Mod_FRM_LOAN

    Public Sub Show_Loan_List()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "SELECT A.LOAN_ID, A.COMPANY_ID, B.LAST_NAME, B.FIRST_NAME, B.MIDDLE_NAME, A.LOAN_TYPE, A.LOAN_AMOUNT, A.BALANCE, A.PERIOD_TO_START, A.LOAN_STATUS "
            SQL = SQL & " FROM TBL_LOAN_HDR A, TBL_EMP_HDR B WHERE A.PAYROLL_YEAR = '" & Date.Today.Year & "' AND A.COMPANY_ID = B.COMPANY_ID"


            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_LOAN.LV_Loan_List

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item("LOAN_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("COMPANY_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("Last_name") & ", " & myRow.Item("First_Name") & " " & Left(myRow.Item("Middle_Name"), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LOAN_TYPE"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LOAN_AMOUNT"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("BALANCE"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("PERIOD_TO_START"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LOAN_STATUS"))

                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Loan List")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

End Module
