Public Class FRM_DTR_EMPLOYEE_LIST
    Private Sub FRM_DTR_EMPLOYEE_LIST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Show_DTR_Employee_List("LAST_NAME", TxtSearch.Text)
    End Sub

    Private Sub LV_Employee_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Employee_List.SelectedIndexChanged


        GlobalVariables.DTR_Selected_Employee_ID = LV_Employee_List.SelectedItems(0).SubItems(1).Text
        GlobalVariables.DTR_Selected_Employee_Name = LV_Employee_List.SelectedItems(0).SubItems(2).Text
        GlobalVariables.DTR_Selected_SubClient_ID = LV_Employee_List.SelectedItems(0).SubItems(3).Text
        GlobalVariables.DTR_Selected_SubClient_Name = LV_Employee_List.SelectedItems(0).SubItems(4).Text


        If GlobalVariables.sDTR_or_Schedule_Process = "SCHEDULE" Then
            FRM_DTR_SCHEDULE.ShowDialog()
        ElseIf GlobalVariables.sDTR_or_Schedule_Process = "DTR" Then
            With FRM_DTR_BIOMETRIC
                .GView_Schedule.Rows.Clear() ' Clear all rows in the DataGridView
            End With
            FRM_DTR_BIOMETRIC.ShowDialog()
        End If

        Me.Close()

    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        Call Show_DTR_Employee_List(Cmb_Category.Text, TxtSearch.Text)
    End Sub
End Class