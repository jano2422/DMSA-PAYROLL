Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Module Mod_FRM_DTR_EXPORTS

    Public Sub Export_DTR_Per_Client_to_Excell(sClient As String, sAddress As String, sCutOff As String)

        Try
            Dim objExcel As New Excel.Application
            ' Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet
            objExcel.Visible = True
            objExcel.Workbooks.Add()

            objSheet = objExcel.Worksheets("Sheet1")

            ' Added to be able to clear sheet content
            Dim sheet As Excel.Worksheet = DirectCast(objExcel.Sheets("Sheet1"), Excel.Worksheet)
            sheet.Cells.Clear()

            ' Detachment Info ( Header )
            objSheet.Cells(2, 1).value = "Client ID:"
            objSheet.Cells(3, 1).value = "Client Address:"
            objSheet.Cells(4, 1).value = "Period:"

            objSheet.Cells(2, 2).value = UCase(FRM_DTR_EXPORTS.Lbl_Client_Name.Text)
            objSheet.Cells(3, 2).value = sAddress
            objSheet.Cells(4, 2).value = sCutOff


            objSheet.Cells(7, 1).value = "Employee Name"
            objSheet.Cells(7, 2).value = "No. of days"
            objSheet.Cells(7, 3).value = "Total Hours"
            objSheet.Cells(7, 4).value = "REG"
            objSheet.Cells(7, 5).value = "SUN"
            objSheet.Cells(7, 6).value = "SH"
            objSheet.Cells(7, 7).value = "LH"
            objSheet.Cells(7, 8).value = "RD SUN SH"
            objSheet.Cells(7, 9).value = "RD SUN LH"
            objSheet.Cells(7, 10).value = "ND REG"
            objSheet.Cells(7, 11).value = "ND SUN"
            objSheet.Cells(7, 12).value = "ND SH"
            objSheet.Cells(7, 13).value = "ND LH"
            objSheet.Cells(7, 14).value = "RD ND SUN SH"
            objSheet.Cells(7, 15).value = "RD ND SUN LH"
            objSheet.Cells(7, 16).value = "OT REG"


            Dim testValue As String

            With FRM_DTR_EXPORTS.LV_DTR_Per_Client_List
                ' Employee List : A14
                For iRow = 0 To .Items.Count - 1  ' Column of List View

                    For iCol = 1 To 16  ' Row of List View


                        If .Items(iRow).SubItems(iCol).Text = "" Then ' Exit for 
                            Exit For
                        End If

                        testValue = .Items(iRow).SubItems(iCol).Text
                        objSheet.Cells(8 + iRow, iCol).value = .Items(iRow).SubItems(iCol).Text

                    Next iCol

                Next iRow

            End With

            'objExcel.AlertBeforeOverwriting = False
            'objExcel.SaveWorkspace()
            'objExcel.Application.Quit()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub Get_DTR_Per_Client(iClient_ID As Integer, sCut_Off As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        Try

            SQL = "select LAST_NAME, FIRST_NAME, MIDDLE_NAME, NUM_OF_DAYS, TOTAL_HOURS, REG, SUN,SH,LH, RD_SUN_SH, RD_SUN_LH, ND_REG, ND_SUN, ND_SH, ND_LH, ND_RD_SUN_SH, ND_RD_SUN_LH, OT_REG from VIEW_DTR_PER_SUB_CLIENT"
            SQL = SQL & " where A.SUB_CLIENT_ID = " & iClient_ID & " and CUTOFF_PERIOD = '" & sCut_Off & "'"

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then ' SHOW DATAS
                With FRM_DTR_EXPORTS.LV_DTR_Per_Client_List
                    Dim myRow As DataRow
                    Dim iRow As Integer
                    iRow = 1

                    .Items.Clear()
                    For Each myRow In dt.Rows

                        .Items.Add(iRow) ' item count
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LAST_NAME") & ", " & myRow.Item("FIRST_NAME"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("NUM_OF_DAYS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("TOTAL_HOURS"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("REG"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SUN"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("SH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("LH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("RD_SUN_SH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("RD_SUN_LH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ND_REG"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ND_SUN"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ND_SH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ND_LH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ND_RD_SUN_SH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("ND_RD_SUN_LH"))
                        .Items(.Items.Count - 1).SubItems.Add(myRow.Item("OT_REG"))

                    Next
                End With
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Check VIEW_DTR_PER_SUB_CLIENT")
        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub


End Module
