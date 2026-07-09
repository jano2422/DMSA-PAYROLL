Imports Microsoft.Office.Interop
Imports System.Data.OleDb

Module Mod_FRM_DTR_REPORT

    Public Sub Show_Report_per_Client_in_LV(sYear As String, sPeriod As String, iClient_ID As Integer)
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        SQL = ""

        'SQL = "Select A.COMPANY_ID, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME, B.TOTAL_DAYS,B.TOTAL_HOURS, D.H_TOTAL_REG, D.H_TOTAL_REG_SUN, D.H_TOTAL_REG_SH, D.H_TOTAL_REG_LH, D.H_TOTAL_ND_REG, D.H_TOTAL_ND_SUN, D.H_TOTAL_ND_SH, D.H_TOTAL_ND_LH, D.H_TOTAL_OT_REG, D.H_TOTAL_OT_SUN, D.H_TOTAL_OT_SH, D.H_TOTAL_OT_LH"
        'SQL = SQL & " From TBL_EMP_HDR As A, TBL_DTR_HDR As B, TBL_CLIENT_SUB As C, TBL_DTR_EARNINGS D"
        'SQL = SQL & " Where A.COMPANY_ID = B.COMPANY_ID And B.DTR_NO = D.DTR_NO And B.PAYROLL_YEAR ='" & sYear & "' AND B.PAYROLL_PERIOD='" & sPeriod & "' AND A.CLIENT_ID =" & iClient_ID & " And A.CLIENT_ID=B.CLIENT_ID"
        'SQL = SQL & " AND B.CLIENT_ID=C.CLIENT_ID ORDER BY A.LAST_NAME ASC"

        SQL = "Select B.DTR_NO, A.COMPANY_ID, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME, B.TOTAL_DAYS,B.TOTAL_HOURS, D.H_TOTAL_REG, D.H_TOTAL_REG_SUN, D.H_TOTAL_REG_SH, D.H_TOTAL_REG_LH, D.H_TOTAL_ND_REG, D.H_TOTAL_ND_SUN, D.H_TOTAL_ND_SH, D.H_TOTAL_ND_LH, D.H_TOTAL_OT_REG, D.H_TOTAL_OT_SUN, D.H_TOTAL_OT_SH, D.H_TOTAL_OT_LH"
        SQL = SQL & " From TBL_EMP_HDR As A, TBL_DTR_HDR As B, TBL_CLIENT_SUB As C, TBL_DTR_EARNINGS D"
        SQL = SQL & " Where A.COMPANY_ID = B.COMPANY_ID And B.DTR_NO = D.DTR_NO And B.PAYROLL_YEAR ='" & sYear & "' AND B.PAYROLL_PERIOD='" & sPeriod & "' AND B.SUB_CLIENT_ID =" & iClient_ID & " "
        SQL = SQL & " AND B.SUB_CLIENT_ID=C.SUB_CLIENT_ID ORDER BY A.LAST_NAME ASC"
        Try

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then
                With FRM_DTR_REPORT.LV_EmployeeList

                    Dim myRow As DataRow

                    .Items.Clear()

                    For Each myRow In dt.Rows
                        ' Include DTR No.?
                        .Items.Add(myRow.Item("DTR_NO"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("COMPANY_ID"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LAST_NAME") & ", " & myRow.Item("FIRST_NAME") & " " & Left(myRow.Item("MIDDLE_NAME"), 1) & ".")
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("TOTAL_DAYS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("TOTAL_HOURS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_REG"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_REG_SUN"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_REG_LH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_REG_SH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_ND_REG"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_ND_SUN"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_ND_LH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_ND_SH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_OT_REG"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_OT_SUN"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_OT_LH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("H_TOTAL_OT_SH"))




                    Next
                End With
            Else
                MsgBox("No records found from your filter", vbExclamation, "No records")
                FRM_DTR_REPORT.LV_EmployeeList.Items.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Error on DT_REPORT")
        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub

    Public Sub Fill_Combo_with_Client_List()

        'Dim da As New OleDb.OleDbDataAdapter
        'Dim dt As New DataTable

        'dt.Clear()
        'dt.Reset()
        'Dim SQL As String

        'Try

        '    SQL = "SELECT CLIENT_ID, CLIENT_NAME FROM TBL_CLIENT_SUB ORDER BY CLIENT_NAME ASC "


        '    da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
        '    da.Fill(dt)


        '    If dt.Rows.Count > 0 Then ' SHOW DATAS

        '        Dim myRow As DataRow
        '        FRM_DTR_REPORT.Cmb_ClientList.Items.Clear()

        '        For Each myRow In dt.Rows

        '            FRM_DTR_REPORT.Cmb_ClientList.Items.Add(myRow.Item("CLIENT_ID") & ": " & myRow.Item("CLIENT_NAME"))

        '        Next

        '    Else

        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.ToString, vbCritical, "DTR_REPORT Combo Client List")
        'End Try

        'GlobalVariables.GlobalCon.Close()



    End Sub


    Public Sub Write_To_Excel_Report(sDetachment As String, sAddress As String, sPeriod As String)

        Try
            Dim objExcel As New Excel.Application
            Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet
            objExcel.Visible = True
            'objExcel.Workbooks.Add()
            'objWorkbook = objExcel.Workbooks.Open("C:\Users\estiokojc\source\repos\DMSA_System_DotNet\DMSA_System\bin\Debug\Template1.xlsx")
            objWorkbook = objExcel.Workbooks.Open(Application.StartupPath & "\Template1.xlsx")
            objSheet = objWorkbook.Worksheets("Per_Client")

            ' Detachment Info ( Header )
            objSheet.Cells(6, 2).value = UCase(sDetachment)
            objSheet.Cells(7, 2).value = sAddress
            objSheet.Cells(8, 2).value = sPeriod

            Dim testValue As String

            With FRM_DTR_REPORT.LV_EmployeeList
                ' Employee List : A14
                For iRow = 0 To .Items.Count - 1  ' Column of List View

                    For iCol = 1 To 15  ' Row of List View

                        testValue = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(14 + iRow, iCol).value = .Items(iRow).SubItems(iCol).Text

                    Next iCol

                Next iRow

            End With


            objExcel.AlertBeforeOverwriting = False
            objExcel.SaveWorkspace()
            objExcel.Application.Quit()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Module

