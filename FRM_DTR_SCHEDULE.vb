Public Class FRM_DTR_SCHEDULE
    Dim Opt_1st_CutOff_FLag_Shift As String
    Dim Opt_2nd_CutOff_FLag_Shift As String
    Private Sub FRM_DTR_SCHEDULE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_IDNumber_Sched.Text = GlobalVariables.DTR_Selected_Employee_ID
        Lbl_Name_Sched.Text = GlobalVariables.DTR_Selected_Employee_Name
        Lbl_SubClient_ID.Text = GlobalVariables.DTR_Selected_SubClient_ID
        Lbl_SubClient_Name.Text = GlobalVariables.DTR_Selected_SubClient_Name

        GView_Schedule1_15.Rows.Clear()
        GView_Schedule16_30.Rows.Clear()

        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 1) 'Temporary - Should be from the selected Employee
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "Yes", 2) 'Temporary - Should be from the selected Employee
    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        'Controls
        If GView_Schedule1_15.RowCount <= 1 Or GView_Schedule16_30.RowCount <= 1 Then
            MsgBox("Nothing to save.", vbCritical, "Invalid")
            Exit Sub
        End If

        ProgressBar_Save.Value = 0 ' reset

        'Check content/ time input validity
        Dim iError_Detected As Integer
        iError_Detected = Verify_Schedule_Validity()

        If iError_Detected = -1 Then
            MsgBox("Invalid time IN or time OUT was detected. Please check.", vbCritical, "Invalid")
            Exit Sub
        End If

        ' Row and Column starts at 0,0 for the gridview
        ProgressBar_Save.Visible = True
        ProgressBar_Save.Maximum = GView_Schedule1_15.RowCount + GView_Schedule16_30.RowCount

        Try
            ' loop save
            ' 1-15
            For iRow = 0 To GView_Schedule1_15.RowCount - 1
                For iCol = 1 To 3

                    If GView_Schedule1_15.Rows(iRow).Cells(0).Value = "" Then ' control ( end of grid is null )
                        Exit For
                    End If

                    Call Update_SecGuard_Schedule(GlobalVariables.DTR_Selected_Employee_ID, Opt_1st_CutOff_FLag_Shift, GView_Schedule1_15.Rows(iRow).Cells(0).Value, GView_Schedule1_15.Rows(iRow).Cells(1).Value, GView_Schedule1_15.Rows(iRow).Cells(2).Value, GView_Schedule1_15.Rows(iRow).Cells(3).Value.ToString)

                Next
                ProgressBar_Save.Value = ProgressBar_Save.Value + 1
            Next
        Catch ex As Exception

        End Try

        Try
            '16-31
            For iRow = 0 To GView_Schedule16_30.RowCount - 1
                For iCol = 1 To 3

                    If GView_Schedule16_30.Rows(iRow).Cells(0).Value = "" Then ' control ( end of grid is null )
                        Exit For
                    End If

                    Call Update_SecGuard_Schedule(GlobalVariables.DTR_Selected_Employee_ID, Opt_2nd_CutOff_FLag_Shift, GView_Schedule16_30.Rows(iRow).Cells(0).Value, GView_Schedule16_30.Rows(iRow).Cells(1).Value, GView_Schedule16_30.Rows(iRow).Cells(2).Value, GView_Schedule16_30.Rows(iRow).Cells(3).Value.ToString)

                Next
                ProgressBar_Save.Value = ProgressBar_Save.Value + 1

            Next


            MsgBox("Schedule was successfully updated!", vbInformation, "Saved!")
            ProgressBar_Save.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Progress: '" & ProgressBar_Save.Value & "'")
        End Try



    End Sub

    Private Sub Opt_1st_AM_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_1st_AM.CheckedChanged

        Cmb_1st_TimeIN.SelectedIndex = -1
        Cmb_1st_TimeOUT.SelectedIndex = -1

        If Opt_1st_AM.Checked = True Then
            Opt_1st_CutOff_FLag_Shift = "MS"
            Cmb_1st_TimeIN.Items.Clear()
            Cmb_1st_TimeIN.Items.Add("5:00")
            Cmb_1st_TimeIN.Items.Add("5:30")
            Cmb_1st_TimeIN.Items.Add("6:00")
            Cmb_1st_TimeIN.Items.Add("6:30")
            Cmb_1st_TimeIN.Items.Add("7:00")
            Cmb_1st_TimeIN.Items.Add("7:30")
            Cmb_1st_TimeIN.Items.Add("8:00")
            Cmb_1st_TimeOUT.Items.Clear()
            Cmb_1st_TimeOUT.Items.Add("17:00")
            Cmb_1st_TimeOUT.Items.Add("17:30")
            Cmb_1st_TimeOUT.Items.Add("18:00")
            Cmb_1st_TimeOUT.Items.Add("18:30")
            Cmb_1st_TimeOUT.Items.Add("19:00")
            Cmb_1st_TimeOUT.Items.Add("19:30")
            Cmb_1st_TimeOUT.Items.Add("20:00")
        Else ' Night shift
            Opt_1st_CutOff_FLag_Shift = "NS"
            Cmb_1st_TimeIN.Items.Clear()
            Cmb_1st_TimeIN.Items.Add("17:00")
            Cmb_1st_TimeIN.Items.Add("17:30")
            Cmb_1st_TimeIN.Items.Add("18:00")
            Cmb_1st_TimeIN.Items.Add("18:30")
            Cmb_1st_TimeIN.Items.Add("19:00")
            Cmb_1st_TimeOUT.Items.Clear()
            Cmb_1st_TimeOUT.Items.Add("5:00")
            Cmb_1st_TimeOUT.Items.Add("5:30")
            Cmb_1st_TimeOUT.Items.Add("6:00")
            Cmb_1st_TimeOUT.Items.Add("6:30")
            Cmb_1st_TimeOUT.Items.Add("7:00")
        End If
    End Sub

    Private Sub Opt_1st_PM_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_1st_PM.CheckedChanged

        Cmb_1st_TimeIN.SelectedIndex = -1
        Cmb_1st_TimeOUT.SelectedIndex = -1

        If Opt_1st_AM.Checked = True Then
            Opt_1st_CutOff_FLag_Shift = "MS"
            Cmb_1st_TimeIN.Items.Clear()
            Cmb_1st_TimeIN.Items.Add("5:00")
            Cmb_1st_TimeIN.Items.Add("5:30")
            Cmb_1st_TimeIN.Items.Add("6:00")
            Cmb_1st_TimeIN.Items.Add("6:30")
            Cmb_1st_TimeIN.Items.Add("7:00")
            Cmb_1st_TimeIN.Items.Add("7:30")
            Cmb_1st_TimeIN.Items.Add("8:00")
            Cmb_1st_TimeOUT.Items.Clear()
            Cmb_1st_TimeOUT.Items.Add("17:00")
            Cmb_1st_TimeOUT.Items.Add("17:30")
            Cmb_1st_TimeOUT.Items.Add("18:00")
            Cmb_1st_TimeOUT.Items.Add("18:30")
            Cmb_1st_TimeOUT.Items.Add("19:00")
            Cmb_1st_TimeOUT.Items.Add("19:30")
            Cmb_1st_TimeOUT.Items.Add("20:00")
        Else ' Night shift
            Opt_1st_CutOff_FLag_Shift = "NS"
            Cmb_1st_TimeIN.Items.Clear()
            Cmb_1st_TimeIN.Items.Add("17:00")
            Cmb_1st_TimeIN.Items.Add("17:30")
            Cmb_1st_TimeIN.Items.Add("18:00")
            Cmb_1st_TimeIN.Items.Add("18:30")
            Cmb_1st_TimeIN.Items.Add("19:00")
            Cmb_1st_TimeOUT.Items.Clear()
            Cmb_1st_TimeOUT.Items.Add("5:00")
            Cmb_1st_TimeOUT.Items.Add("5:30")
            Cmb_1st_TimeOUT.Items.Add("6:00")
            Cmb_1st_TimeOUT.Items.Add("6:30")
            Cmb_1st_TimeOUT.Items.Add("7:00")
        End If
    End Sub

    Private Sub Opt_2nd_PM_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_2nd_PM.CheckedChanged
        If Opt_2nd_AM.Checked = True Then
            Opt_2nd_CutOff_FLag_Shift = "MS"
            Cmb_2nd_TimeIN.Items.Clear()
            Cmb_2nd_TimeIN.Items.Add("5:00")
            Cmb_2nd_TimeIN.Items.Add("5:30")
            Cmb_2nd_TimeIN.Items.Add("6:00")
            Cmb_2nd_TimeIN.Items.Add("6:30")
            Cmb_2nd_TimeIN.Items.Add("7:00")
            Cmb_2nd_TimeOUT.Items.Clear()
            Cmb_2nd_TimeOUT.Items.Add("17:00")
            Cmb_2nd_TimeOUT.Items.Add("17:30")
            Cmb_2nd_TimeOUT.Items.Add("18:00")
            Cmb_2nd_TimeOUT.Items.Add("18:30")
            Cmb_2nd_TimeOUT.Items.Add("19:00")
        Else ' Night shift
            Opt_2nd_CutOff_FLag_Shift = "NS"
            Cmb_2nd_TimeIN.Items.Clear()
            Cmb_2nd_TimeIN.Items.Add("17:00")
            Cmb_2nd_TimeIN.Items.Add("17:30")
            Cmb_2nd_TimeIN.Items.Add("18:00")
            Cmb_2nd_TimeIN.Items.Add("18:30")
            Cmb_2nd_TimeIN.Items.Add("19:00")
            Cmb_2nd_TimeOUT.Items.Clear()
            Cmb_2nd_TimeOUT.Items.Add("5:00")
            Cmb_2nd_TimeOUT.Items.Add("5:30")
            Cmb_2nd_TimeOUT.Items.Add("6:00")
            Cmb_2nd_TimeOUT.Items.Add("6:30")
            Cmb_2nd_TimeOUT.Items.Add("7:00")
        End If
    End Sub

    Private Sub Opt_2nd_AM_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_2nd_AM.CheckedChanged
        If Opt_2nd_AM.Checked = True Then
            Opt_2nd_CutOff_FLag_Shift = "MS"
            Cmb_2nd_TimeIN.Items.Clear()
            Cmb_2nd_TimeIN.Items.Add("5:00")
            Cmb_2nd_TimeIN.Items.Add("5:30")
            Cmb_2nd_TimeIN.Items.Add("6:00")
            Cmb_2nd_TimeIN.Items.Add("6:30")
            Cmb_2nd_TimeIN.Items.Add("7:00")
            Cmb_2nd_TimeOUT.Items.Clear()
            Cmb_2nd_TimeOUT.Items.Add("17:00")
            Cmb_2nd_TimeOUT.Items.Add("17:30")
            Cmb_2nd_TimeOUT.Items.Add("18:00")
            Cmb_2nd_TimeOUT.Items.Add("18:30")
            Cmb_2nd_TimeOUT.Items.Add("19:00")
        Else ' Night shift
            Opt_2nd_CutOff_FLag_Shift = "NS"
            Cmb_2nd_TimeIN.Items.Clear()
            Cmb_2nd_TimeIN.Items.Add("17:00")
            Cmb_2nd_TimeIN.Items.Add("17:30")
            Cmb_2nd_TimeIN.Items.Add("18:00")
            Cmb_2nd_TimeIN.Items.Add("18:30")
            Cmb_2nd_TimeIN.Items.Add("19:00")
            Cmb_2nd_TimeOUT.Items.Clear()
            Cmb_2nd_TimeOUT.Items.Add("5:00")
            Cmb_2nd_TimeOUT.Items.Add("5:30")
            Cmb_2nd_TimeOUT.Items.Add("6:00")
            Cmb_2nd_TimeOUT.Items.Add("6:30")
            Cmb_2nd_TimeOUT.Items.Add("7:00")
        End If
    End Sub

    Private Sub Btn_UpdateCells_First_Click(sender As Object, e As EventArgs) Handles Btn_UpdateCells_First.Click

        If Cmb_1st_TimeIN.SelectedIndex = -1 Or Cmb_1st_TimeOUT.SelectedIndex = -1 Then
            MsgBox("Please input both Time IN and Time Out.", vbExclamation, "Invalid")
            Exit Sub
        End If

        Call Update_1stCutoff_Cells(Cmb_1st_TimeIN.Text, Cmb_1st_TimeOUT.Text, Opt_1st_CutOff_FLag_Shift)
        Auto_Compute_total_Hours_Shedule()
    End Sub

    Private Sub Btn_UpdateCells_Second_Click(sender As Object, e As EventArgs) Handles Btn_UpdateCells_Second.Click


        If Cmb_2nd_TimeIN.SelectedIndex = -1 Or Cmb_2nd_TimeOUT.SelectedIndex = -1 Then
            MsgBox("Please input both Time IN and Time Out.", vbExclamation, "Invalid")
            Exit Sub
        End If

        Call Update_2ndCutoff_Cells(Cmb_2nd_TimeIN.Text, Cmb_2nd_TimeOUT.Text, Opt_2nd_CutOff_FLag_Shift)
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
End Class