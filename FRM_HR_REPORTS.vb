Imports Microsoft.Office.Interop
Public Class FRM_HR_REPORTS
    Private Sub Btn_Load_Chart_Data_Click(sender As Object, e As EventArgs) Handles Btn_Load_Chart_Data.Click

        Call Show_Employee_Status_in_Chart() ' Breakdown per status

        Me.CH_Emp_Status.Series("Count").Points.Clear()

        For i = 0 To Me.LV_Report_Statistics1.Items.Count - 1
            Me.CH_Emp_Status.Series("Count").Points.AddXY(Me.LV_Report_Statistics1.Items(i).Text, Me.LV_Report_Statistics1.Items(i).SubItems(1).Text)
        Next i


    End Sub

    Private Sub Btn_Hired_Per_Year_Click(sender As Object, e As EventArgs) Handles Btn_Hired_Per_Year.Click

        Call Show_in_Chart_Hired_Per_Year(Me.Cmb_Status.Text) ' Breakdown per Year

        Me.CH_Emp_Status.Series("Count").Points.Clear()

        For i = 0 To Me.LV_Report_Statistics1.Items.Count - 1
            Me.CH_Emp_Status.Series("Count").Points.AddXY(Me.LV_Report_Statistics1.Items(i).Text, Me.LV_Report_Statistics1.Items(i).SubItems(1).Text)
        Next i

    End Sub

    Private Sub Cmb_Expiry_Status_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Cmb_Expiry_Status.SelectedIndexChanged

        Dim Target_Date_of_Expiration As Date

        Select Case Cmb_Expiry_Status.SelectedIndex

            Case 0 ' expieres in 1 month
                Target_Date_of_Expiration = Date.Now.AddDays(30) ' Expired In 1 month
            Case 1 ' expires in 2 months
                Target_Date_of_Expiration = Date.Now.AddDays(60)
            Case 2 ' already expired
                Target_Date_of_Expiration = Date.Now.AddDays(90)
            Case 3
                Target_Date_of_Expiration = Date.Now.AddDays(0) ' Expired already
        End Select


        Select Case Cmb_Exp_Category.SelectedIndex

            Case 0 ' Annual Medical
                Call Show_Medical_Expiry(Target_Date_of_Expiration.ToShortDateString)

            Case 1 ' Security License
                Call Show_License_Expiry(Target_Date_of_Expiration.ToShortDateString)

            Case 2 ' Insurance
                Call Show_Insurance_Expiry(Target_Date_of_Expiration.ToShortDateString)

        End Select




    End Sub

    Private Sub Btn_ShowPendingRecords_Click(sender As Object, e As EventArgs) Handles Btn_ShowPendingRecords.Click
        Call Show_Employees_With_Pending_Information(Cmb_Pending_Category.Text)
    End Sub

    Private Sub Cmb_Exp_Category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Exp_Category.SelectedIndexChanged
        Cmb_Expiry_Status.SelectedIndex = -1
    End Sub

    Private Sub DP_Leave_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DP_Leave_DateTo.ValueChanged
        Txt_Leave_DateTo.Text = DP_Leave_DateTo.Value.ToShortDateString
    End Sub

    Private Sub DP_Leave_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DP_Leave_DateFrom.ValueChanged
        Txt_Leave_DateFrom.Text = DP_Leave_DateFrom.Value.ToShortDateString
    End Sub

    Private Sub Btn_Show_Leave_Click(sender As Object, e As EventArgs) Handles Btn_Show_Leave.Click
        Try
            Call Show_Leave_Applications(Me.Cmb_LeaveType.Text, Me.Txt_Leave_DateFrom.Text, Me.Txt_Leave_DateTo.Text)
        Catch ex As Exception
            MsgBox("Error in getting records. Please check requirements.", vbCritical, "Catched Error")
        End Try

    End Sub

    Private Sub Lbl_Export_SecLicense_Click(sender As Object, e As EventArgs) Handles Lbl_Export_SecLicense.Click
        If Me.LV_Expiry_List.Items.Count >= 1 Then
            Call Export_Expiry_to_Excel()
        Else
            MsgBox("No records on the list for export.", vbCritical, "Nothing to export")
        End If

    End Sub

    Private Sub Btn_Logs_Show_Click(sender As Object, e As EventArgs) Handles Btn_Logs_Show.Click
        Try
            Call Show_System_Logs(Txt_Logs_DateFrom.Text, Txt_Logs_DateTo.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DP_Logs_From_ValueChanged(sender As Object, e As EventArgs) Handles DP_Logs_From.ValueChanged
        Txt_Logs_DateFrom.Text = DP_Logs_From.Value.ToShortDateString
    End Sub

    Private Sub DP_Logs_To_ValueChanged(sender As Object, e As EventArgs) Handles DP_Logs_To.ValueChanged
        Txt_Logs_DateTo.Text = DP_Logs_To.Value.ToShortDateString
    End Sub



    Private Sub Lbl_Export_LeaveStatus_Click(sender As Object, e As EventArgs) Handles Lbl_Export_LeaveStatus.Click
        If Me.LV_Leave_List.Items.Count >= 1 Then
            Call Export_Leave_Status_to_Excel()
        Else
            MsgBox("No records on the list for export.", vbCritical, "Nothing to export")
        End If
    End Sub

    Private Sub Lbl_Export_PendingDocs_Click(sender As Object, e As EventArgs) Handles Lbl_Export_PendingDocs.Click
        If Me.LV_Pending_List.Items.Count >= 1 Then
            Call Export_Pending_Docs_to_Excel()
        Else
            MsgBox("No records on the list for export.", vbCritical, "Nothing to export")
        End If
    End Sub

    Private Sub Btn_Client_Show_Click(sender As Object, e As EventArgs) Handles Btn_Client_Show.Click
        Call Show_Number_of_Active_Clients()
        Call Show_Client_Count_In_Listview()
    End Sub

    Private Sub Btn_Show_SubClient_EmpCount_Click(sender As Object, e As EventArgs) Handles Btn_Show_SubClient_EmpCount.Click
        Call Show_Sub_Client_Employee_Count()
    End Sub

    Private Sub Btn_Show_MainClient_EmpCount_Click(sender As Object, e As EventArgs) Handles Btn_Show_MainClient_EmpCount.Click
        Call Show_Main_Client_Employe_Count()
    End Sub

    Private Sub Btn_Employment_Status_Click(sender As Object, e As EventArgs) Handles Btn_Export_SubClient_Count.Click
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


            objSheet.Cells(1, 1).value = "Item"
            objSheet.Cells(1, 2).value = "Sub Client Name"
            objSheet.Cells(1, 3).value = "Employee Count"


            With LV_SubClient_EmployeeCount

                For iRow = 0 To .Items.Count - 1  ' Row of List View

                    For iCol = 0 To 2  ' Col of List View

                        objSheet.Cells(2 + iRow, 1 + iCol).value = .Items(iRow).SubItems(iCol).Text


                    Next iCol

                Next iRow

            End With


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Sub BtnExport_MainClientCount_Click(sender As Object, e As EventArgs) Handles BtnExport_MainClientCount.Click
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


            objSheet.Cells(1, 1).value = "Item"
            objSheet.Cells(1, 2).value = "Main Client Name"
            objSheet.Cells(1, 3).value = "Sub Client Count"


            Dim testValue As String

            With LV_Client_Count

                For iRow = 0 To .Items.Count - 1  ' Row of List View

                    For iCol = 0 To 2  ' Col of List View

                        'testValue = .Items(iRow).SubItems(iCol).Text
                        'objSheet.Cells(2 + iRow, 1).value = 1 + iRow
                        objSheet.Cells(2 + iRow, 1 + iCol).value = .Items(iRow).SubItems(iCol).Text


                    Next iCol

                Next iRow

            End With


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Btn_Export_Employee_Count_Click(sender As Object, e As EventArgs) Handles Btn_Export_Employee_Count.Click
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


            objSheet.Cells(1, 1).value = "Item"
            objSheet.Cells(1, 2).value = "Main Client Name"
            objSheet.Cells(1, 3).value = "Employee Count"


            With LV_MAIN_CLIENT_EMPLOYEE_COUNT

                For iRow = 0 To .Items.Count - 1  ' Row of List View

                    For iCol = 0 To 2  ' Col of List View

                        objSheet.Cells(2 + iRow, 1 + iCol).value = .Items(iRow).SubItems(iCol).Text


                    Next iCol

                Next iRow

            End With


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Cmb_Client_Expiration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Client_Expiration.SelectedIndexChanged
        Dim Target_Date_of_Expiration As Date

        Select Case Cmb_Client_Expiration.SelectedIndex

            Case 0 ' expires in 1 month
                Target_Date_of_Expiration = Date.Now.AddDays(30) ' Expired In 1 month
            Case 1 ' expires in 2 months
                Target_Date_of_Expiration = Date.Now.AddDays(60)
            Case 2 ' expires in 3 months
                Target_Date_of_Expiration = Date.Now.AddDays(90)
            Case 3 ' already expired
                Target_Date_of_Expiration = Date.Now.AddDays(0) ' Expired already
            Case 4 ' already expired
                Target_Date_of_Expiration = Date.Now.AddDays(1000) ' Expired already
        End Select


        Call Show_Client_Contract_Expiry(Target_Date_of_Expiration.ToShortDateString)

    End Sub

    Private Sub Lbl_Export_Client_Contract_Exp_Click(sender As Object, e As EventArgs) Handles Lbl_Export_Client_Contract_Exp.Click
        Call Export_Client_Contract_Expiry_to_Excel()
    End Sub
End Class