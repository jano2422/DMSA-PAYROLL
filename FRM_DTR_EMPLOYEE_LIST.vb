Public Class FRM_DTR_EMPLOYEE_LIST
    Private Sub FRM_DTR_EMPLOYEE_LIST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cmb_Category.SelectedItem = "LAST_NAME"
        Call Show_DTR_Employee_List("LAST_NAME", TxtSearch.Text)
    End Sub
    Private Sub FRM_DTR_EMPLOYEE_LIST_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
            ' Log or display the error
            MsgBox($"An error occurred during form close: {ex.Message}", vbExclamation, "Error")
        End Try
    End Sub
    Private Sub LV_Employee_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Employee_List.SelectedIndexChanged
        ' Ensure an item is selected before accessing it
        If LV_Employee_List.SelectedItems.Count = 0 Then Exit Sub

        ' Assign selected values to global variables
        GlobalVariables.DTR_Selected_Employee_ID = LV_Employee_List.SelectedItems(0).SubItems(1).Text
        GlobalVariables.DTR_Selected_Employee_Name = LV_Employee_List.SelectedItems(0).SubItems(2).Text
        GlobalVariables.DTR_Selected_SubClient_ID = LV_Employee_List.SelectedItems(0).SubItems(3).Text
        GlobalVariables.DTR_Selected_SubClient_Name = LV_Employee_List.SelectedItems(0).SubItems(4).Text

        ' Check the process type
        If GlobalVariables.sDTR_or_Schedule_Process = "EMPLOYEE_LIST" Then
            With FRM_DTR_SCHEDULE
                .Lbl_IDNumber_Sched.Text = GlobalVariables.DTR_Selected_Employee_ID
                .Lbl_Name_Sched.Text = GlobalVariables.DTR_Selected_Employee_Name
                .Lbl_SubClient_ID.Text = GlobalVariables.DTR_Selected_SubClient_ID
                .Lbl_SubClient_Name.Text = GlobalVariables.DTR_Selected_SubClient_Name

                .GView_Schedule1_15.Rows.Clear()
                .GView_Schedule16_30.Rows.Clear()

                ' Load employee schedule
                Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 1)
                Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 2)
            End With
        End If

        ' Close or hide the current form
        Me.Close() ' Use Me.Hide() instead of Me.Close() to prevent app termination
    End Sub


    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        Call Show_DTR_Employee_List(Cmb_Category.Text, TxtSearch.Text)
    End Sub
End Class