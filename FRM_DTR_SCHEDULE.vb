Public Class FRM_DTR_SCHEDULE

    Private Sub FRM_DTR_SCHEDULE_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
            ' Log or display the error
            MsgBox($"An error occurred during form close: {ex.Message}", vbExclamation, "Error")
        End Try
    End Sub
    Private Sub FRM_DTR_SCHEDULE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_IDNumber_Sched.Text = GlobalVariables.DTR_Selected_Employee_ID
        Lbl_Name_Sched.Text = GlobalVariables.DTR_Selected_Employee_Name
        Lbl_SubClient_ID.Text = GlobalVariables.DTR_Selected_SubClient_ID
        Lbl_SubClient_Name.Text = GlobalVariables.DTR_Selected_SubClient_Name

        GView_Schedule1_15.Rows.Clear()
        GView_Schedule16_30.Rows.Clear()

        Call SetupToggleColumns()
        Call SetTimeCmbBox()
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 1) 'Temporary - Should be from the selected Employee
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 2) 'Temporary - Should be from the selected Employee

        AddHandler GView_Schedule1_15.CellClick, AddressOf GView_Schedule_CellClick
        AddHandler GView_Schedule16_30.CellClick, AddressOf GView_Schedule_CellClick
    End Sub
    Private Sub SetupToggleColumns()
        With Me.GView_Schedule1_15
            If .Columns.Count < 6 Then
                ' Add buttons in column 4 and 5 (after day column)
                Dim btnSub As New DataGridViewButtonColumn()
                btnSub.Name = "BtnSub"
                btnSub.HeaderText = "◀ Day Out"
                btnSub.Text = "◀"
                btnSub.UseColumnTextForButtonValue = True
                .Columns.Insert(5, btnSub)

                Dim btnAdd As New DataGridViewButtonColumn()
                btnAdd.Name = "BtnAdd"
                btnAdd.HeaderText = "+ Day Out"
                btnAdd.Text = "+"
                btnAdd.UseColumnTextForButtonValue = True
                .Columns.Insert(6, btnAdd)
            End If
        End With

        With Me.GView_Schedule16_30
            If .Columns.Count < 6 Then
                ' Add buttons in column 4 and 5 (after day column)
                Dim btnSub As New DataGridViewButtonColumn()
                btnSub.Name = "BtnSub"
                btnSub.HeaderText = "◀ Day Out"
                btnSub.Text = "-"
                btnSub.UseColumnTextForButtonValue = True
                .Columns.Insert(5, btnSub)

                Dim btnAdd As New DataGridViewButtonColumn()
                btnAdd.Name = "BtnAdd"
                btnAdd.HeaderText = "+ Day Out"
                btnAdd.Text = "+"
                btnAdd.UseColumnTextForButtonValue = True
                .Columns.Insert(6, btnAdd)
            End If
        End With
    End Sub

    Private Sub GView_Schedule_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim grid = CType(sender, DataGridView)
        If e.RowIndex < 0 Then Exit Sub
        Dim row = grid.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Exit Sub
        Dim days = CType(row.Tag, Integer())
        Dim currentVal = CInt(row.Cells(2).Value)

        Select Case grid.Columns(e.ColumnIndex).Name
            Case "BtnAdd"
                If currentVal <> days(1) Then row.Cells(2).Value = days(1)
            Case "BtnSub"
                If currentVal <> days(0) Then row.Cells(2).Value = days(0)
        End Select
        Call Auto_Compute_total_Hours_Shedule()
    End Sub
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Generate_Default_Schedule(GlobalVariables.DTR_Selected_Employee_ID)

        GView_Schedule1_15.Rows.Clear()
        GView_Schedule16_30.Rows.Clear()

        ' Load employee schedule
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 1)
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 2)
    End Sub
    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        If GView_Schedule1_15.RowCount <= 1 Or GView_Schedule16_30.RowCount <= 1 Then
            MsgBox("Nothing to save.", vbCritical, "Invalid")
            Exit Sub
        End If

        ProgressBar_Save.Value = 0

        Dim iError_Detected As Integer = Verify_Schedule_Validity()
        If iError_Detected = -1 Then
            MsgBox("Invalid time IN or time OUT was detected. Please check.", vbCritical, "Invalid")
            Exit Sub
        End If

        Auto_Compute_total_Hours_Shedule()

        ProgressBar_Save.Visible = True
        ProgressBar_Save.Maximum = GView_Schedule1_15.RowCount + GView_Schedule16_30.RowCount

        Try
            For iRow = 0 To GView_Schedule1_15.RowCount - 1
                If GView_Schedule1_15.Rows(iRow).Cells(0).Value = "" Then Exit For

                Dim selectedValue As String = ""
                If GView_Schedule1_15.Rows(iRow).Cells(2).Value IsNot Nothing Then
                    selectedValue = GView_Schedule1_15.Rows(iRow).Cells(2).Value.ToString().Trim()
                End If

                If selectedValue = "" Then Continue For

                Call Update_SecGuard_Schedule(GlobalVariables.DTR_Selected_Employee_ID,
                                          GView_Schedule1_15.Rows(iRow).Cells(0).Value,
                                          GView_Schedule1_15.Rows(iRow).Cells(1).Value,
                                          selectedValue,
                                          GView_Schedule1_15.Rows(iRow).Cells(3).Value,
                                          GView_Schedule1_15.Rows(iRow).Cells(4).Value.ToString())

                ProgressBar_Save.Value += 1
            Next
        Catch ex As Exception
            MsgBox("Error saving schedule: " & ex.Message, vbCritical, "Error")
        End Try

        Try
            For iRow = 0 To GView_Schedule16_30.RowCount - 1
                If GView_Schedule16_30.Rows(iRow).Cells(0).Value = "" Then Exit For

                Dim selectedValue As String = ""
                If GView_Schedule16_30.Rows(iRow).Cells(2).Value IsNot Nothing Then
                    selectedValue = GView_Schedule16_30.Rows(iRow).Cells(2).Value.ToString().Trim()
                End If

                If selectedValue = "" Then Continue For

                Call Update_SecGuard_Schedule(GlobalVariables.DTR_Selected_Employee_ID,
                                          GView_Schedule16_30.Rows(iRow).Cells(0).Value,
                                          GView_Schedule16_30.Rows(iRow).Cells(1).Value,
                                          selectedValue,
                                          GView_Schedule16_30.Rows(iRow).Cells(3).Value,
                                          GView_Schedule16_30.Rows(iRow).Cells(4).Value.ToString())

                ProgressBar_Save.Value += 1
            Next

            MsgBox("Schedule was successfully updated!", vbInformation, "Saved!")
            ProgressBar_Save.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Progress: '" & ProgressBar_Save.Value & "'")
        End Try
    End Sub

    Private Sub SetTimeCmbBox()
        Cmb_1st_TimeIN.Items.Clear()
        Cmb_1st_TimeOUT.Items.Clear()

        Cmb_2nd_TimeIN.Items.Clear()
        Cmb_2nd_TimeIN.Items.Clear()

        Cmb_1st_TimeIN.Items.Add("5:00")
        Cmb_1st_TimeIN.Items.Add("5:30")
        Cmb_1st_TimeIN.Items.Add("6:00")
        Cmb_1st_TimeIN.Items.Add("6:30")
        Cmb_1st_TimeIN.Items.Add("7:00")
        Cmb_1st_TimeIN.Items.Add("7:30")
        Cmb_1st_TimeIN.Items.Add("8:00")
        Cmb_1st_TimeIN.Items.Add("17:00")
        Cmb_1st_TimeIN.Items.Add("17:30")
        Cmb_1st_TimeIN.Items.Add("18:00")
        Cmb_1st_TimeIN.Items.Add("18:30")
        Cmb_1st_TimeIN.Items.Add("19:00")

        Cmb_1st_TimeOUT.Items.Add("5:00")
        Cmb_1st_TimeOUT.Items.Add("5:30")
        Cmb_1st_TimeOUT.Items.Add("6:00")
        Cmb_1st_TimeOUT.Items.Add("6:30")
        Cmb_1st_TimeOUT.Items.Add("7:00")
        Cmb_1st_TimeOUT.Items.Add("7:30")
        Cmb_1st_TimeOUT.Items.Add("8:00")
        Cmb_1st_TimeOUT.Items.Add("17:00")
        Cmb_1st_TimeOUT.Items.Add("17:30")
        Cmb_1st_TimeOUT.Items.Add("18:00")
        Cmb_1st_TimeOUT.Items.Add("18:30")
        Cmb_1st_TimeOUT.Items.Add("19:00")
        Cmb_1st_TimeOUT.Items.Add("19:30")
        Cmb_1st_TimeOUT.Items.Add("20:00")


        Cmb_2nd_TimeIN.Items.Add("5:00")
        Cmb_2nd_TimeIN.Items.Add("5:30")
        Cmb_2nd_TimeIN.Items.Add("6:00")
        Cmb_2nd_TimeIN.Items.Add("6:30")
        Cmb_2nd_TimeIN.Items.Add("7:00")
        Cmb_2nd_TimeIN.Items.Add("7:30")
        Cmb_2nd_TimeIN.Items.Add("8:00")
        Cmb_2nd_TimeIN.Items.Add("17:00")
        Cmb_2nd_TimeIN.Items.Add("17:30")
        Cmb_2nd_TimeIN.Items.Add("18:00")
        Cmb_2nd_TimeIN.Items.Add("18:30")
        Cmb_2nd_TimeIN.Items.Add("19:00")

        Cmb_2nd_TimeOUT.Items.Add("5:00")
        Cmb_2nd_TimeOUT.Items.Add("5:30")
        Cmb_2nd_TimeOUT.Items.Add("6:00")
        Cmb_2nd_TimeOUT.Items.Add("6:30")
        Cmb_2nd_TimeOUT.Items.Add("7:00")
        Cmb_2nd_TimeOUT.Items.Add("7:30")
        Cmb_2nd_TimeOUT.Items.Add("8:00")
        Cmb_2nd_TimeOUT.Items.Add("17:00")
        Cmb_2nd_TimeOUT.Items.Add("17:30")
        Cmb_2nd_TimeOUT.Items.Add("18:00")
        Cmb_2nd_TimeOUT.Items.Add("18:30")
        Cmb_2nd_TimeOUT.Items.Add("19:00")
        Cmb_2nd_TimeOUT.Items.Add("19:30")
        Cmb_2nd_TimeOUT.Items.Add("20:00")
    End Sub

    Private Sub Btn_UpdateCells_First_Click(sender As Object, e As EventArgs) Handles Btn_UpdateCells_First.Click

        If String.IsNullOrEmpty(Cmb_1st_TimeIN.Text) Or String.IsNullOrEmpty(Cmb_1st_TimeOUT.Text) Then
            MsgBox("Please input both Time IN and Time Out.", vbExclamation, "Invalid")
            Exit Sub
        End If

        Call Update_1stCutoff_Cells(Cmb_1st_TimeIN.Text, Cmb_1st_TimeOUT.Text)
        Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub Btn_UpdateCells_Second_Click(sender As Object, e As EventArgs) Handles Btn_UpdateCells_Second.Click

        If String.IsNullOrEmpty(Cmb_2nd_TimeIN.Text) Or String.IsNullOrEmpty(Cmb_2nd_TimeOUT.Text) Then
            MsgBox("Please input both Time IN and Time Out.", vbExclamation, "Invalid")
            Exit Sub
        End If

        Call Update_2ndCutoff_Cells(Cmb_2nd_TimeIN.Text, Cmb_2nd_TimeOUT.Text)
        Auto_Compute_total_Hours_Shedule()
    End Sub


    Private Sub GView_Schedule1_15_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GView_Schedule1_15.CellEndEdit
        Call Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub GView_Schedule16_30_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GView_Schedule16_30.CellEndEdit
        Call Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub GView_Schedule1_15_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GView_Schedule1_15.CellContentClick

    End Sub

    Private Sub Btn_EmpList_Click(sender As Object, e As EventArgs) Handles Btn_EmpList.Click
        GlobalVariables.sDTR_or_Schedule_Process = "EMPLOYEE_LIST"
        FRM_DTR_EMPLOYEE_LIST.ShowDialog()
    End Sub

    Private Sub updateSubEmpRec_Click(sender As Object, e As EventArgs) Handles updateSubEmpRec.Click
        UpdateSubClientFromLatestTransfer()
    End Sub
End Class