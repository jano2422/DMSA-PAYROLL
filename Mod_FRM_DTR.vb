Imports System.Data.OleDb
Module Mod_FRM_DTR
    Public Sub Show_DTR_List(sYear, sPeriod)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String
        SQL = ""

        ' Create conditions from filter options


        If FRM_DTR.CmbCategory.Text = "" And FRM_DTR.Chk_Pending_DTR.Checked = False Then

            SQL = "Select A.EMPLOYEE_ID, B.LAST_NAME, B.FIRST_NAME, B.MIDDLE_NAME, C.CLIENT_NAME, A.LATEST_PAYROLL_PERIOD"
            SQL = SQL & " From HR_EMPLOYEE_RECORD_HDR A, HR_APPLICATION_DTL B, TBL_CLIENT_SUB C"
            SQL = SQL & " Where A.CLIENT_ID = C.CLIENT_ID And A.APPLICATION_ID = B.APPLICATION_ID"
            SQL = SQL & " and A.LATEST_PAYROLL_YEAR = '" & sYear & "' AND A.LATEST_PAYROLL_PERIOD = '" & sPeriod & "' ORDER BY B.LAST_NAME"


            'SQL = "Select A.EMPLOYEE_ID, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME, B.CLIENT_NAME, A.LATEST_PAYROLL_PERIOD"
            'SQL = SQL & " From HR_APPLICATION_DTL A, TBL_CLIENT_SUB B"
            'SQL = SQL & " Where A.LATEST_PAYROLL_YEAR = '" & sYear & "' AND A.LATEST_PAYROLL_PERIOD = '" & sPeriod & "' AND A.CLIENT_ID = B.CLIENT_ID  ORDER BY A.LAST_NAME"
        End If

        If FRM_DTR.CmbCategory.Text = "" And FRM_DTR.Chk_Pending_DTR.Checked = True Then ' Only Pending for encoding of DTR


            SQL = "Select  A.EMPLOYEE_ID, B.LAST_NAME, B.FIRST_NAME, B.MIDDLE_NAME, C.CLIENT_NAME, A.LATEST_PAYROLL_PERIOD"
            SQL = SQL & " From HR_EMPLOYEE_RECORD_HDR A, HR_APPLICATION_DTL B, TBL_CLIENT_SUB C"
            SQL = SQL & " Where A.CLIENT_ID = C.CLIENT_ID And A.APPLICATION_ID = B.APPLICATION_ID"
            SQL = SQL & " and A.LATEST_PAYROLL_YEAR = '" & sYear & "' AND A.LATEST_PAYROLL_PERIOD <> '" & sPeriod & "' ORDER BY B.LAST_NAME"


            'SQL = "Select A.COMPANY_ID, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME, B.CLIENT_NAME, A.LATEST_PAYROLL_PERIOD"
            'SQL = SQL & " From HR_APPLICATION_DTL A, TBL_CLIENT_SUB B"
            'SQL = SQL & " Where A.LATEST_PAYROLL_YEAR = '" & sYear & "' AND A.LATEST_PAYROLL_PERIOD <> '" & sPeriod & "' AND A.CLIENT_ID = B.CLIENT_ID  ORDER BY A.LAST_NAME"
        End If

        If FRM_DTR.CmbCategory.Text <> "" And FRM_DTR.Chk_Pending_DTR.Checked = True Then ' Category Selected

            SQL = "Select  A.EMPLOYEE_ID, B.LAST_NAME, B.FIRST_NAME, B.MIDDLE_NAME, C.CLIENT_NAME, A.LATEST_PAYROLL_PERIOD"
            SQL = SQL & " From HR_EMPLOYEE_RECORD_HDR A, HR_APPLICATION_DTL B, TBL_CLIENT_SUB C"
            SQL = SQL & " Where A.CLIENT_ID = C.CLIENT_ID And A.APPLICATION_ID = B.APPLICATION_ID"
            SQL = SQL & " and A.LATEST_PAYROLL_YEAR = '" & sYear & "' AND A.LATEST_PAYROLL_PERIOD <> '" & sPeriod & "' "
            SQL = SQL & " AND " & FRM_DTR.CmbCategory.Text & " LIKE '%" & FRM_DTR.TxtSearch.Text & "%' ORDER BY B.LAST_NAME"

            'SQL = "Select A.COMPANY_ID, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME, B.CLIENT_NAME, A.LATEST_PAYROLL_PERIOD"
            'SQL = SQL & " From HR_APPLICATION_DTL A, TBL_CLIENT_SUB B"
            'SQL = SQL & " Where A.LATEST_PAYROLL_YEAR = '" & sYear & "' AND A.LATEST_PAYROLL_PERIOD <> '" & sPeriod & "' AND A.CLIENT_ID = B.CLIENT_ID"
            'SQL = SQL & " AND " & FRM_DTR.CmbCategory.Text & " LIKE '%" & FRM_DTR.TxtSearch.Text & "%' "

        End If


        Try

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_DTR.LV_EmployeeList

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows

                        .Items.Add(myRow.Item(0)) ' Company ID
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item(1) & ", " & myRow.Item(2) & " " & Left(myRow.Item(3), 1) & ".") ' Name
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item(4)) ' Client name
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item(5)) ' latest Cut-off created (PAYROLL_PERIOD)


                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_DTR.LV_EmployeeList.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Function Get_Client_ID(sCompany_ID)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim iClient_ID As Integer

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        SQL = " SELECT CLIENT_ID FROM TBL_EMP_HDR WHERE COMPANY_ID = '" & sCompany_ID & "'"

        Try

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Dim myRow As DataRow
                For Each myRow In dt.Rows

                    iClient_ID = myRow.Item("client_id") ' 

                Next
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return iClient_ID

        GlobalVariables.GlobalCon.Close()

    End Function
End Module
