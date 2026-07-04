Public Partial Class FRM_DTR_SCHEDULE
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FRM_DTR_SCHEDULE_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
            MsgBox("An error occurred during form close: " & ex.Message, vbExclamation, "Error")
        End Try
    End Sub

    Private Sub FRM_DTR_SCHEDULE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupToggleColumns()
        SetTimeCmbBox()
        LoadSelectedEmployeeSchedule()

        RemoveHandler GView_Schedule1_15.CellClick, AddressOf GView_Schedule_CellClick
        RemoveHandler GView_Schedule16_30.CellClick, AddressOf GView_Schedule_CellClick
        AddHandler GView_Schedule1_15.CellClick, AddressOf GView_Schedule_CellClick
        AddHandler GView_Schedule16_30.CellClick, AddressOf GView_Schedule_CellClick
    End Sub

    Private Sub LoadSelectedEmployeeSchedule()
        Lbl_IDNumber_Sched.Text = EmptyDisplay(GlobalVariables.DTR_Selected_Employee_ID)
        Lbl_Name_Sched.Text = If(String.IsNullOrWhiteSpace(GlobalVariables.DTR_Selected_Employee_Name), "No employee selected", GlobalVariables.DTR_Selected_Employee_Name)
        Lbl_SubClient_ID.Text = EmptyDisplay(GlobalVariables.DTR_Selected_SubClient_ID)
        Lbl_SubClient_Name.Text = EmptyDisplay(GlobalVariables.DTR_Selected_SubClient_Name)

        GView_Schedule1_15.Rows.Clear()
        GView_Schedule16_30.Rows.Clear()

        If String.IsNullOrWhiteSpace(GlobalVariables.DTR_Selected_Employee_ID) Then Return

        Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 1)
        Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 2)
    End Sub

    Private Function EmptyDisplay(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return "-"
        Return value
    End Function

    Private Sub SetupToggleColumns()
        AddToggleColumns(GView_Schedule1_15)
        AddToggleColumns(GView_Schedule16_30)
    End Sub

    Private Sub AddToggleColumns(grid As DataGridView)
        If Not grid.Columns.Contains("BtnSub") Then
            Dim btnSub As New DataGridViewButtonColumn()
            btnSub.Name = "BtnSub"
            btnSub.HeaderText = "Day Out -"
            btnSub.Text = "-"
            btnSub.UseColumnTextForButtonValue = True
            grid.Columns.Insert(5, btnSub)
        End If

        If Not grid.Columns.Contains("BtnAdd") Then
            Dim btnAdd As New DataGridViewButtonColumn()
            btnAdd.Name = "BtnAdd"
            btnAdd.HeaderText = "Day Out +"
            btnAdd.Text = "+"
            btnAdd.UseColumnTextForButtonValue = True
            grid.Columns.Insert(6, btnAdd)
        End If
    End Sub

    Private Sub GView_Schedule_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim grid = CType(sender, DataGridView)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub
        If grid.Columns(e.ColumnIndex).Name <> "BtnAdd" AndAlso grid.Columns(e.ColumnIndex).Name <> "BtnSub" Then Exit Sub

        Dim row = grid.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Exit Sub

        Dim days = CType(row.Tag, Integer())
        Dim currentVal As Integer
        If Not Integer.TryParse(Convert.ToString(row.Cells(2).Value), currentVal) Then Exit Sub

        Select Case grid.Columns(e.ColumnIndex).Name
            Case "BtnAdd"
                If currentVal <> days(1) Then row.Cells(2).Value = days(1)
            Case "BtnSub"
                If currentVal <> days(0) Then row.Cells(2).Value = days(0)
        End Select

        Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        If String.IsNullOrWhiteSpace(GlobalVariables.DTR_Selected_Employee_ID) Then
            MsgBox("Please select an employee before generating a default schedule.", vbExclamation, "Schedule")
            Exit Sub
        End If

        Generate_Default_Schedule(GlobalVariables.DTR_Selected_Employee_ID)
        LoadSelectedEmployeeSchedule()
    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        If String.IsNullOrWhiteSpace(GlobalVariables.DTR_Selected_Employee_ID) Then
            MsgBox("Please select an employee before saving.", vbExclamation, "Schedule")
            Exit Sub
        End If

        If CountScheduleRows(GView_Schedule1_15) = 0 OrElse CountScheduleRows(GView_Schedule16_30) = 0 Then
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
        ProgressBar_Save.Maximum = Math.Max(1, CountScheduleRows(GView_Schedule1_15) + CountScheduleRows(GView_Schedule16_30))

        Try
            SaveScheduleGrid(GView_Schedule1_15)
            SaveScheduleGrid(GView_Schedule16_30)

            MsgBox("Schedule was successfully updated!", vbInformation, "Saved!")
            ProgressBar_Save.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Progress: '" & ProgressBar_Save.Value & "'")
            ProgressBar_Save.Visible = False
        End Try
    End Sub

    Private Sub SaveScheduleGrid(grid As DataGridView)
        For Each row As DataGridViewRow In grid.Rows
            If row.IsNewRow OrElse Not RowHasScheduleDay(row) Then Continue For

            Dim selectedValue As String = Convert.ToString(row.Cells(2).Value).Trim()
            If selectedValue = "" Then Continue For

            Update_SecGuard_Schedule(GlobalVariables.DTR_Selected_Employee_ID,
                                     row.Cells(0).Value,
                                     row.Cells(1).Value,
                                     selectedValue,
                                     row.Cells(3).Value,
                                     Convert.ToString(row.Cells(4).Value))

            If ProgressBar_Save.Value < ProgressBar_Save.Maximum Then
                ProgressBar_Save.Value += 1
            End If
        Next
    End Sub

    Private Function CountScheduleRows(grid As DataGridView) As Integer
        Dim count As Integer = 0
        For Each row As DataGridViewRow In grid.Rows
            If Not row.IsNewRow AndAlso RowHasScheduleDay(row) Then count += 1
        Next
        Return count
    End Function

    Private Function RowHasScheduleDay(row As DataGridViewRow) As Boolean
        Return Not String.IsNullOrWhiteSpace(Convert.ToString(row.Cells(0).Value))
    End Function

    Private Sub SetTimeCmbBox()
        Cmb_1st_TimeIN.Items.Clear()
        Cmb_1st_TimeOUT.Items.Clear()
        Cmb_2nd_TimeIN.Items.Clear()
        Cmb_2nd_TimeOUT.Items.Clear()

        Dim timeInValues As Object() = {"5:00", "5:30", "6:00", "6:30", "7:00", "7:30", "8:00", "17:00", "17:30", "18:00", "18:30", "19:00"}
        Dim timeOutValues As Object() = {"5:00", "5:30", "6:00", "6:30", "7:00", "7:30", "8:00", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00"}

        Cmb_1st_TimeIN.Items.AddRange(timeInValues)
        Cmb_2nd_TimeIN.Items.AddRange(timeInValues)
        Cmb_1st_TimeOUT.Items.AddRange(timeOutValues)
        Cmb_2nd_TimeOUT.Items.AddRange(timeOutValues)

        SelectComboValue(Cmb_1st_TimeIN, "7:00")
        SelectComboValue(Cmb_1st_TimeOUT, "19:00")
        SelectComboValue(Cmb_2nd_TimeIN, "19:00")
        SelectComboValue(Cmb_2nd_TimeOUT, "7:00")
    End Sub

    Private Sub SelectComboValue(combo As ComboBox, value As String)
        If combo.Items.Contains(value) Then combo.SelectedItem = value
    End Sub

    Private Sub Btn_UpdateCells_First_Click(sender As Object, e As EventArgs) Handles Btn_UpdateCells_First.Click
        If String.IsNullOrEmpty(Cmb_1st_TimeIN.Text) Or String.IsNullOrEmpty(Cmb_1st_TimeOUT.Text) Then
            MsgBox("Please input both Time IN and Time Out.", vbExclamation, "Invalid")
            Exit Sub
        End If

        Update_1stCutoff_Cells(Cmb_1st_TimeIN.Text, Cmb_1st_TimeOUT.Text)
        Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub Btn_UpdateCells_Second_Click(sender As Object, e As EventArgs) Handles Btn_UpdateCells_Second.Click
        If String.IsNullOrEmpty(Cmb_2nd_TimeIN.Text) Or String.IsNullOrEmpty(Cmb_2nd_TimeOUT.Text) Then
            MsgBox("Please input both Time IN and Time Out.", vbExclamation, "Invalid")
            Exit Sub
        End If

        Update_2ndCutoff_Cells(Cmb_2nd_TimeIN.Text, Cmb_2nd_TimeOUT.Text)
        Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub GView_Schedule1_15_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GView_Schedule1_15.CellEndEdit
        Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub GView_Schedule16_30_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GView_Schedule16_30.CellEndEdit
        Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub Btn_EmpList_Click(sender As Object, e As EventArgs) Handles Btn_EmpList.Click
        GlobalVariables.sDTR_or_Schedule_Process = "EMPLOYEE_LIST"
        FRM_DTR_EMPLOYEE_LIST.ShowDialog()
    End Sub

    Private Sub updateSubEmpRec_Click(sender As Object, e As EventArgs) Handles updateSubEmpRec.Click
        UpdateSubClientFromLatestTransfer()
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click
        Close()
    End Sub
End Class
