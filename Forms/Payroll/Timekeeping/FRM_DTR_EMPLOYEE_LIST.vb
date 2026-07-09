Imports System.Data
Imports System.Data.OleDb

Public Class FRM_DTR_EMPLOYEE_LIST
    Private Sub FRM_DTR_EMPLOYEE_LIST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cmb_Category.SelectedItem = "LAST_NAME"
        Call Show_DTR_Employee_List("LAST_NAME", TxtSearch.Text)
    End Sub

    Private Sub FRM_DTR_EMPLOYEE_LIST_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
            MsgBox($"An error occurred during form close: {ex.Message}", vbExclamation, "Error")
        End Try
    End Sub

    Private Sub LV_Employee_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Employee_List.SelectedIndexChanged
        If LV_Employee_List.SelectedItems.Count = 0 Then Exit Sub

        GlobalVariables.DTR_Selected_Employee_ID = LV_Employee_List.SelectedItems(0).SubItems(1).Text
        GlobalVariables.DTR_Selected_Employee_Name = LV_Employee_List.SelectedItems(0).SubItems(2).Text
        GlobalVariables.DTR_Selected_SubClient_ID = LV_Employee_List.SelectedItems(0).SubItems(3).Text
        GlobalVariables.DTR_Selected_SubClient_Name = LV_Employee_List.SelectedItems(0).SubItems(4).Text
        GlobalVariables.DTR_Selected_SubClient_Address = LV_Employee_List.SelectedItems(0).SubItems(5).Text
        GlobalVariables.DTR_Selected_Sched_Type = GetSelectedSubClientSchedType(GlobalVariables.DTR_Selected_SubClient_ID)

        If GlobalVariables.sDTR_or_Schedule_Process = "EMPLOYEE_LIST" Then
            With FRM_DTR_SCHEDULE
                .Lbl_IDNumber_Sched.Text = GlobalVariables.DTR_Selected_Employee_ID
                .Lbl_Name_Sched.Text = GlobalVariables.DTR_Selected_Employee_Name
                .Lbl_SubClient_ID.Text = GlobalVariables.DTR_Selected_SubClient_ID
                .Lbl_SubClient_Name.Text = GlobalVariables.DTR_Selected_SubClient_Name

                .GView_Schedule1_15.Rows.Clear()
                .GView_Schedule16_30.Rows.Clear()

                Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 1)
                Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 2)
            End With
        ElseIf GlobalVariables.sDTR_or_Schedule_Process = "DTR" Then
            RouteSelectedEmployeeForDtr()
        End If

        Me.Close()
    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        Call Show_DTR_Employee_List(Cmb_Category.Text, TxtSearch.Text)
    End Sub

    Private Function GetSelectedSubClientSchedType(subClientId As String) As String
        If String.IsNullOrWhiteSpace(subClientId) Then Return ""

        Dim schedType As String = ""
        Try
            Connect_to_MDB()
            Using cmd As New OleDbCommand("SELECT SCHED_TYPE FROM TBL_CLIENT_SUB WHERE SUB_CLIENT_ID = ?", GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", CInt(subClientId))
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    schedType = result.ToString().Trim().ToUpperInvariant()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Unable to read subclient schedule type: " & ex.Message, vbCritical, "DTR")
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try

        Return schedType
    End Function

    Private Sub RouteSelectedEmployeeForDtr()
        Select Case GlobalVariables.DTR_Selected_Sched_Type
            Case "2SHIFTS", "TRI_SHIFT"
                Using manualDtr As New FRM_DTR_SHIFT_MANUAL()
                    manualDtr.ShowDialog()
                End Using
            Case "TIME_SPECIFIC"
                FRM_DTR_BIOMETRIC.AutoStartForSelectedEmployee = True
                FRM_DTR_BIOMETRIC.ShowDialog()
            Case Else
                MsgBox("Unsupported or missing schedule type for the selected subclient: " & GlobalVariables.DTR_Selected_Sched_Type, vbExclamation, "DTR")
        End Select
    End Sub
End Class
