

Public Class FRM_DTR_INPUT


    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        Dim Confirm_Save As String

        If CInt(Txt_Total_Earnings.Text) = 0 Then
            MsgBox("No Earnings to be saved!", vbExclamation, "Invalid DTR earnings")
            Exit Sub
        End If

        If TxtTotal_Hours.Text = "" Then
            MsgBox("All Hours must have atleast Zero value. Currently there are empty Hours-textboxes.", vbExclamation, "Invalid DTR Hours")
            Exit Sub
        End If


        Confirm_Save = MsgBox("Are you sure you want to save this DTR record?", vbYesNo + vbQuestion, "Save")

        If Confirm_Save = vbYes Then

            ' SAVE TO TBL_DTR_HDR ( later include the traceability e.g generated_by and date)
            Call SAVE_DTR_HDR(Lbl_Company_ID.Text, CInt(Lbl_DTR_No.Text), Lbl_Period.Text, Lbl_Year.Text, CInt(Mid(Me.Lbl_ClientName.Text, 1, 3)), CDbl(Txt_Total_Earnings.Text), CDbl(Lbl_Total_Deduction.Text), CInt(Lbl_Total_Days.Text), CInt(TxtTotal_Hours.Text))

            ' SAVE TO TBL_DTR_DTL for the attendance
            Dim sHoliday_Type As String
            For i = 1 To 15 ' Loop the DTR Values for the complete period

                Select Case Me.Controls("Btn_" & i).BackColor ' Holiday
                    Case Color.Red
                        sHoliday_Type = "LH"
                    Case Color.Yellow
                        sHoliday_Type = "SH"
                    Case Color.LightGray
                        sHoliday_Type = "NA"
                End Select

                Call SAVE_TBL_DTR_DTL(CInt(Lbl_DTR_No.Text), Lbl_Year.Text, Lbl_Period.Text, i, GlobalVariables.AM_PM_Shift(i), GlobalVariables.No_Of_Days(i), Me.Controls("Lbl_Day" & i).Text, sHoliday_Type, GlobalVariables.Selected_Client_ID, CDbl(Me.Controls("TxtWage" & i).Text))

            Next

            ' SAVE TO TBL_DTR_EARNNGS for the payslip
            Call SAVE_DTR_EARNINGS(CInt(Lbl_DTR_No.Text))

            ' SAVE TO TBL_DTR_DEDUCTIONS for the payslip
            Call SAVE_TBL_DTR_DEDUCTIONS(CInt(Lbl_DTR_No.Text))

            ' UPDATE TBL_EMP_HDR for the latest payroll_period
            Call UPDATE_TBL_EMP_HDR_LAST_PAYROLL_PERIOD(Lbl_Company_ID.Text, Lbl_Year.Text, Lbl_Period.Text)

            ' Update Loan Deduction Table ========================================================
            ' Open


            MsgBox("DTR Record was successfully saved!", vbInformation, "Saved")
            GlobalVariables.DTR_INPUT_SAVED = "Saved"
            Me.Close() ' Interim to avoid double saving
        Else
            Exit Sub

        End If

        ' Reset Variables
        GlobalVariables.sReliever = False

    End Sub

    Private Sub FRM_FRM_DTR_INPUT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalVariables.DTR_INPUT_SAVED = ""


        'GlobalVariables.DTR_Selected_Employee_ID = LV_Employee_List.SelectedItems(0).SubItems(1).Text
        'GlobalVariables.DTR_Selected_Employee_Name = LV_Employee_List.SelectedItems(0).SubItems(2).Text
        'GlobalVariables.DTR_Selected_SubClient_ID = LV_Employee_List.SelectedItems(0).SubItems(3).Text
        'GlobalVariables.DTR_Selected_SubClient_Name = LV_Employee_List.SelectedItems(0).SubItems(4).Text

        Lbl_Company_ID.Text = GlobalVariables.DTR_Selected_Employee_ID
        Lbl_Name.Text = GlobalVariables.DTR_Selected_Employee_Name
        Lbl_ClientName.Text = GlobalVariables.DTR_Selected_SubClient_Name

        'Lbl_DTR_No.Text = Generate_DTR_Number() ' Should be written down on the Hard copy DTR
        'Lbl_Period.Text = GlobalVariables.sPayroll_Cutoff
        'Lbl_Year.Text = FRM_DTR.Cmb_Year.Text

        ' Reset GLobal Variables
        For i = 1 To 15
            GlobalVariables.No_Of_Days(i) = 0
        Next

        'Call Show_Employee_HDR_Info(GlobalVariables.Selected_Employee_ID, GlobalVariables.sReliever) ' including Allowance

        Call Set_Date_Picker() ' Day 1 - 15

        'Call Uncheck_All_Checkboxes()

        ' Set default value of Wage per hour for all Days
        For i = 1 To 15 ' Make this a function later
            'Me.Controls("TxtWage" & i).Text = Me.Lbl_PerHour.Text
            Me.Controls("TxtWage" & i).Text = 498 / 8
        Next i

    End Sub



    Private Sub BtnCheckAllAM_Click(sender As Object, e As EventArgs) Handles BtnCheckAllAM.Click
        Call Check_All_AM_Dates()

    End Sub

    Private Sub BtnCheckAllPM_Click(sender As Object, e As EventArgs) Handles BtnCheckAllPM.Click
        Call Check_All_PM_Dates()
    End Sub

    Private Sub Chk1AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk1AM.CheckedChanged
        If Chk1AM.Checked = True Then
            'TxtHours1.Text = "12"
            TxtHours1.Text = GlobalVariables.iHours_Rendered(0)
            GlobalVariables.AM_PM_Shift(1) = "AM"
            GlobalVariables.No_Of_Days(1) = 1
            If Chk1PM.Checked = True Then
                TxtHours1.Text = "24"
                GlobalVariables.AM_PM_Shift(1) = "AP"
                GlobalVariables.No_Of_Days(1) = 2
            End If
        Else
            TxtHours1.Text = "0"
            GlobalVariables.AM_PM_Shift(1) = "NA"
            GlobalVariables.No_Of_Days(1) = 0
            If Chk1PM.Checked = True Then
                'TxtHours1.Text = "12"


                GlobalVariables.AM_PM_Shift(1) = "PM"
                GlobalVariables.No_Of_Days(1) = 1
            End If
        End If


        Call Compute_Total_Days()

    End Sub

    Private Sub Chk1PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk1PM.CheckedChanged
        If Chk1AM.Checked = True Then
            TxtHours1.Text = "12"
            GlobalVariables.AM_PM_Shift(1) = "AM"
            GlobalVariables.No_Of_Days(1) = 1
            If Chk1PM.Checked = True Then
                TxtHours1.Text = "24"
                GlobalVariables.AM_PM_Shift(1) = "AP"
                GlobalVariables.No_Of_Days(1) = 2
            End If
        Else
            TxtHours1.Text = "0"
            GlobalVariables.AM_PM_Shift(1) = "NA"
            GlobalVariables.No_Of_Days(1) = 0
            If Chk1PM.Checked = True Then
                TxtHours1.Text = "12"
                GlobalVariables.AM_PM_Shift(1) = "PM"
                GlobalVariables.No_Of_Days(1) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk2AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk2AM.CheckedChanged
        Try

            If Chk2AM.Checked = True Then
                'TxtHours2.Text = "12"
                TxtHours2.Text = GlobalVariables.iHours_Rendered(1)
                GlobalVariables.AM_PM_Shift(2) = "AM"
                GlobalVariables.No_Of_Days(2) = 1
                If Chk2PM.Checked = True Then
                    TxtHours2.Text = "24"
                    GlobalVariables.AM_PM_Shift(2) = "AP"
                    GlobalVariables.No_Of_Days(2) = 2
                End If
            Else
                TxtHours2.Text = "0"
                GlobalVariables.AM_PM_Shift(2) = "NA"
                GlobalVariables.No_Of_Days(2) = 0
                If Chk2PM.Checked = True Then
                    'TxtHours2.Text = "12"

                    GlobalVariables.AM_PM_Shift(2) = "PM"
                    GlobalVariables.No_Of_Days(2) = 1
                End If
            End If
            Call Compute_Total_Days()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Chk2PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk2PM.CheckedChanged
        If Chk2AM.Checked = True Then
            TxtHours2.Text = "12"
            GlobalVariables.AM_PM_Shift(2) = "AM"
            GlobalVariables.No_Of_Days(2) = 1
            If Chk2PM.Checked = True Then
                TxtHours2.Text = "24"
                GlobalVariables.AM_PM_Shift(2) = "AP"
                GlobalVariables.No_Of_Days(2) = 2
            End If
        Else
            TxtHours2.Text = "0"
            GlobalVariables.AM_PM_Shift(2) = "NA"
            GlobalVariables.No_Of_Days(2) = 0
            If Chk2PM.Checked = True Then
                TxtHours2.Text = "12"
                GlobalVariables.AM_PM_Shift(2) = "PM"
                GlobalVariables.No_Of_Days(2) = 1
            End If
            Call Compute_Total_Days()
        End If
    End Sub

    Private Sub Chk3AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk3AM.CheckedChanged
        If Chk3AM.Checked = True Then
            'TxtHours3.Text = "12"
            TxtHours3.Text = GlobalVariables.iHours_Rendered(2)
            GlobalVariables.AM_PM_Shift(3) = "AM"
            GlobalVariables.No_Of_Days(3) = 1
            If Chk3PM.Checked = True Then
                TxtHours3.Text = "24"
                GlobalVariables.AM_PM_Shift(3) = "AP"
                GlobalVariables.No_Of_Days(3) = 2
            End If
        Else
            TxtHours3.Text = "0"
            GlobalVariables.AM_PM_Shift(3) = "NA"
            GlobalVariables.No_Of_Days(3) = 0
            If Chk3PM.Checked = True Then
                'TxtHours3.Text = "12"

                GlobalVariables.AM_PM_Shift(3) = "PM"
                GlobalVariables.No_Of_Days(3) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk3PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk3PM.CheckedChanged
        If Chk3AM.Checked = True Then
            TxtHours3.Text = "12"
            GlobalVariables.AM_PM_Shift(3) = "AM"
            GlobalVariables.No_Of_Days(3) = 1
            If Chk3PM.Checked = True Then
                TxtHours3.Text = "24"
                GlobalVariables.AM_PM_Shift(3) = "AP"
                GlobalVariables.No_Of_Days(3) = 2
            End If
        Else
            TxtHours3.Text = "0"
            GlobalVariables.AM_PM_Shift(3) = "NA"
            GlobalVariables.No_Of_Days(3) = 0
            If Chk3PM.Checked = True Then
                TxtHours3.Text = "12"
                GlobalVariables.AM_PM_Shift(3) = "PM"
                GlobalVariables.No_Of_Days(3) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk4AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk4AM.CheckedChanged
        If Chk4AM.Checked = True Then
            TxtHours4.Text = "12"
            'TxtHours2.Text = GlobalVariables.iHours_Rendered(3)
            GlobalVariables.AM_PM_Shift(4) = "AM"
            GlobalVariables.No_Of_Days(4) = 1
            If Chk4PM.Checked = True Then
                TxtHours4.Text = "24"
                GlobalVariables.AM_PM_Shift(4) = "AP"
                GlobalVariables.No_Of_Days(4) = 2
            End If
        Else
            TxtHours4.Text = "0"
            GlobalVariables.AM_PM_Shift(4) = "NA"
            GlobalVariables.No_Of_Days(4) = 0
            If Chk4PM.Checked = True Then
                'TxtHours4.Text = "12"

                GlobalVariables.AM_PM_Shift(4) = "PM"
                GlobalVariables.No_Of_Days(4) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk4PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk4PM.CheckedChanged
        If Chk4AM.Checked = True Then
            TxtHours4.Text = "12"
            GlobalVariables.AM_PM_Shift(4) = "AM"
            GlobalVariables.No_Of_Days(4) = 1
            If Chk4PM.Checked = True Then
                TxtHours4.Text = "24"
                GlobalVariables.AM_PM_Shift(4) = "AP"
                GlobalVariables.No_Of_Days(4) = 2
            End If
        Else
            TxtHours4.Text = "0"
            GlobalVariables.AM_PM_Shift(4) = "NA"
            GlobalVariables.No_Of_Days(4) = 0
            If Chk4PM.Checked = True Then
                TxtHours4.Text = "12"
                GlobalVariables.AM_PM_Shift(4) = "PM"
                GlobalVariables.No_Of_Days(4) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk5AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk5AM.CheckedChanged
        If Chk5AM.Checked = True Then
            'TxtHours5.Text = "12"
            TxtHours5.Text = GlobalVariables.iHours_Rendered(4)
            GlobalVariables.AM_PM_Shift(5) = "AM"
            GlobalVariables.No_Of_Days(5) = 1
            If Chk5PM.Checked = True Then
                TxtHours5.Text = "25"
                GlobalVariables.AM_PM_Shift(5) = "AP"
                GlobalVariables.No_Of_Days(5) = 2
            End If
        Else
            TxtHours5.Text = "0"
            GlobalVariables.AM_PM_Shift(5) = "NA"
            GlobalVariables.No_Of_Days(5) = 0
            If Chk5PM.Checked = True Then
                'TxtHours5.Text = "12"

                GlobalVariables.AM_PM_Shift(5) = "PM"
                GlobalVariables.No_Of_Days(5) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk5PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk5PM.CheckedChanged
        If Chk5AM.Checked = True Then
            TxtHours5.Text = "12"
            GlobalVariables.AM_PM_Shift(5) = "AM"
            GlobalVariables.No_Of_Days(5) = 1
            If Chk5PM.Checked = True Then
                TxtHours5.Text = "25"
                GlobalVariables.AM_PM_Shift(5) = "AP"
                GlobalVariables.No_Of_Days(5) = 2
            End If
        Else
            TxtHours5.Text = "0"
            GlobalVariables.AM_PM_Shift(5) = "NA"
            GlobalVariables.No_Of_Days(5) = 0
            If Chk5PM.Checked = True Then
                TxtHours5.Text = "12"
                GlobalVariables.AM_PM_Shift(5) = "PM"
                GlobalVariables.No_Of_Days(5) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk6AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk6AM.CheckedChanged
        If Chk6AM.Checked = True Then
            'TxtHours6.Text = "12"
            TxtHours6.Text = GlobalVariables.iHours_Rendered(5)
            GlobalVariables.AM_PM_Shift(6) = "AM"
            GlobalVariables.No_Of_Days(6) = 1
            If Chk6PM.Checked = True Then
                TxtHours6.Text = "26"
                GlobalVariables.AM_PM_Shift(6) = "AP"
                GlobalVariables.No_Of_Days(6) = 2
            End If
        Else
            TxtHours6.Text = "0"
            GlobalVariables.AM_PM_Shift(6) = "NA"
            GlobalVariables.No_Of_Days(6) = 0
            If Chk6PM.Checked = True Then
                'TxtHours6.Text = "12"

                GlobalVariables.AM_PM_Shift(6) = "PM"
                GlobalVariables.No_Of_Days(6) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk6PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk6PM.CheckedChanged
        If Chk6AM.Checked = True Then
            TxtHours6.Text = "12"
            GlobalVariables.AM_PM_Shift(6) = "AM"
            GlobalVariables.No_Of_Days(6) = 1
            If Chk6PM.Checked = True Then
                TxtHours6.Text = "24"
                GlobalVariables.AM_PM_Shift(6) = "AP"
                GlobalVariables.No_Of_Days(6) = 2
            End If
        Else
            TxtHours6.Text = "0"
            GlobalVariables.AM_PM_Shift(6) = "NA"
            GlobalVariables.No_Of_Days(6) = 0
            If Chk6PM.Checked = True Then
                TxtHours6.Text = "12"
                GlobalVariables.AM_PM_Shift(6) = "PM"
                GlobalVariables.No_Of_Days(6) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub



    Private Sub Chk7AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk7AM.CheckedChanged
        If Chk7AM.Checked = True Then
            'TxtHours7.Text = "12"
            TxtHours7.Text = GlobalVariables.iHours_Rendered(6)
            GlobalVariables.AM_PM_Shift(7) = "AM"
            GlobalVariables.No_Of_Days(7) = 1
            If Chk7PM.Checked = True Then
                TxtHours7.Text = "24"
                GlobalVariables.AM_PM_Shift(7) = "AP"
                GlobalVariables.No_Of_Days(7) = 2
            End If
        Else
            TxtHours7.Text = "0"
            GlobalVariables.AM_PM_Shift(7) = "NA"
            GlobalVariables.No_Of_Days(7) = 0
            If Chk7PM.Checked = True Then
                'TxtHours7.Text = "12"

                GlobalVariables.AM_PM_Shift(7) = "PM"
                GlobalVariables.No_Of_Days(7) = 1
            End If
        End If

        Call Compute_Total_Days()
    End Sub

    Private Sub Chk7PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk7PM.CheckedChanged
        If Chk7AM.Checked = True Then
            TxtHours7.Text = "12"
            GlobalVariables.AM_PM_Shift(7) = "AM"
            GlobalVariables.No_Of_Days(7) = 1
            If Chk7PM.Checked = True Then
                TxtHours7.Text = "24"
                GlobalVariables.AM_PM_Shift(7) = "AP"
                GlobalVariables.No_Of_Days(7) = 2
            End If
        Else
            TxtHours7.Text = "0"
            GlobalVariables.AM_PM_Shift(7) = "NA"
            GlobalVariables.No_Of_Days(7) = 0
            If Chk7PM.Checked = True Then
                TxtHours7.Text = "12"
                GlobalVariables.AM_PM_Shift(7) = "PM"
                GlobalVariables.No_Of_Days(7) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk8AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk8AM.CheckedChanged
        If Chk8AM.Checked = True Then
            'TxtHours8.Text = "12"
            TxtHours8.Text = GlobalVariables.iHours_Rendered(7)
            GlobalVariables.AM_PM_Shift(8) = "AM"
            GlobalVariables.No_Of_Days(8) = 1
            If Chk8PM.Checked = True Then
                TxtHours8.Text = "24"
                GlobalVariables.AM_PM_Shift(8) = "AP"
                GlobalVariables.No_Of_Days(8) = 2
            End If
        Else
            TxtHours8.Text = "0"
            GlobalVariables.AM_PM_Shift(8) = "NA"
            GlobalVariables.No_Of_Days(8) = 0
            If Chk8PM.Checked = True Then
                'TxtHours8.Text = "12"

                GlobalVariables.AM_PM_Shift(8) = "PM"
                GlobalVariables.No_Of_Days(8) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk8PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk8PM.CheckedChanged
        If Chk8AM.Checked = True Then
            TxtHours8.Text = "12"
            GlobalVariables.AM_PM_Shift(8) = "AM"
            GlobalVariables.No_Of_Days(8) = 1
            If Chk8PM.Checked = True Then
                TxtHours8.Text = "24"
                GlobalVariables.AM_PM_Shift(8) = "AP"
                GlobalVariables.No_Of_Days(8) = 2
            End If
        Else
            TxtHours8.Text = "0"
            GlobalVariables.AM_PM_Shift(8) = "NA"
            GlobalVariables.No_Of_Days(8) = 0
            If Chk8PM.Checked = True Then
                TxtHours8.Text = "12"
                GlobalVariables.AM_PM_Shift(8) = "PM"
                GlobalVariables.No_Of_Days(8) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk9AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk9AM.CheckedChanged
        If Chk9AM.Checked = True Then
            'TxtHours9.Text = "12"
            TxtHours9.Text = GlobalVariables.iHours_Rendered(8)
            GlobalVariables.AM_PM_Shift(9) = "AM"
            GlobalVariables.No_Of_Days(9) = 1
            If Chk9PM.Checked = True Then
                TxtHours9.Text = "24"
                GlobalVariables.AM_PM_Shift(9) = "AP"
                GlobalVariables.No_Of_Days(9) = 2
            End If
        Else
            TxtHours9.Text = "0"
            GlobalVariables.AM_PM_Shift(9) = "NA"
            GlobalVariables.No_Of_Days(9) = 0
            If Chk9PM.Checked = True Then
                'TxtHours9.Text = "12"

                GlobalVariables.AM_PM_Shift(9) = "PM"
                GlobalVariables.No_Of_Days(9) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk9PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk9PM.CheckedChanged
        If Chk9AM.Checked = True Then
            TxtHours9.Text = "12"
            GlobalVariables.AM_PM_Shift(9) = "AM"
            GlobalVariables.No_Of_Days(9) = 1
            If Chk9PM.Checked = True Then
                TxtHours9.Text = "24"
                GlobalVariables.AM_PM_Shift(9) = "AP"
                GlobalVariables.No_Of_Days(9) = 2
            End If
        Else
            TxtHours9.Text = "0"
            GlobalVariables.AM_PM_Shift(9) = "NA"
            GlobalVariables.No_Of_Days(9) = 0
            If Chk9PM.Checked = True Then
                TxtHours9.Text = "12"
                GlobalVariables.AM_PM_Shift(9) = "PM"
                GlobalVariables.No_Of_Days(9) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk10AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk10AM.CheckedChanged
        If Chk10AM.Checked = True Then
            'TxtHours10.Text = "12"
            TxtHours10.Text = GlobalVariables.iHours_Rendered(9)
            GlobalVariables.AM_PM_Shift(10) = "AM"
            GlobalVariables.No_Of_Days(10) = 1
            If Chk10PM.Checked = True Then
                TxtHours10.Text = "24"
                GlobalVariables.AM_PM_Shift(10) = "AP"
                GlobalVariables.No_Of_Days(10) = 2
            End If
        Else
            TxtHours10.Text = "0"
            GlobalVariables.AM_PM_Shift(10) = "NA"
            GlobalVariables.No_Of_Days(10) = 0
            If Chk10PM.Checked = True Then
                'TxtHours10.Text = "12"

                GlobalVariables.AM_PM_Shift(10) = "PM"
                GlobalVariables.No_Of_Days(10) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk10PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk10PM.CheckedChanged
        If Chk10AM.Checked = True Then
            TxtHours10.Text = "12"
            GlobalVariables.AM_PM_Shift(10) = "AM"
            GlobalVariables.No_Of_Days(10) = 1
            If Chk10PM.Checked = True Then
                TxtHours10.Text = "24"
                GlobalVariables.AM_PM_Shift(10) = "AP"
                GlobalVariables.No_Of_Days(10) = 2
            End If
        Else
            TxtHours10.Text = "0"
            GlobalVariables.AM_PM_Shift(10) = "NA"
            GlobalVariables.No_Of_Days(10) = 0
            If Chk10PM.Checked = True Then
                TxtHours10.Text = "12"
                GlobalVariables.AM_PM_Shift(10) = "PM"
                GlobalVariables.No_Of_Days(10) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk11AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk11AM.CheckedChanged
        If Chk11AM.Checked = True Then
            'TxtHours11.Text = "12"
            TxtHours11.Text = GlobalVariables.iHours_Rendered(10)
            GlobalVariables.AM_PM_Shift(11) = "AM"
            GlobalVariables.No_Of_Days(11) = 1
            If CHK11PM.Checked = True Then
                TxtHours11.Text = "24"
                GlobalVariables.AM_PM_Shift(11) = "AP"
                GlobalVariables.No_Of_Days(11) = 2
            End If
        Else
            TxtHours11.Text = "0"
            GlobalVariables.AM_PM_Shift(11) = "NA"
            GlobalVariables.No_Of_Days(11) = 0
            If CHK11PM.Checked = True Then
                'TxtHours11.Text = "12"

                GlobalVariables.AM_PM_Shift(11) = "PM"
                GlobalVariables.No_Of_Days(11) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub CHK11PM_CheckedChanged(sender As Object, e As EventArgs) Handles CHK11PM.CheckedChanged
        If Chk11AM.Checked = True Then
            TxtHours11.Text = "12"
            GlobalVariables.AM_PM_Shift(11) = "AM"
            GlobalVariables.No_Of_Days(11) = 1
            If CHK11PM.Checked = True Then
                TxtHours11.Text = "24"
                GlobalVariables.AM_PM_Shift(11) = "AP"
                GlobalVariables.No_Of_Days(11) = 2
            End If
        Else
            TxtHours11.Text = "0"
            GlobalVariables.AM_PM_Shift(11) = "NA"
            GlobalVariables.No_Of_Days(11) = 0
            If CHK11PM.Checked = True Then
                TxtHours11.Text = "12"
                GlobalVariables.AM_PM_Shift(11) = "PM"
                GlobalVariables.No_Of_Days(11) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk12AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk12AM.CheckedChanged
        If Chk12AM.Checked = True Then
            'TxtHours12.Text = "12"
            TxtHours12.Text = GlobalVariables.iHours_Rendered(11)
            GlobalVariables.AM_PM_Shift(12) = "AM"
            GlobalVariables.No_Of_Days(12) = 1
            If Chk12PM.Checked = True Then
                TxtHours12.Text = "24"
                GlobalVariables.AM_PM_Shift(12) = "AP"
                GlobalVariables.No_Of_Days(12) = 2
            End If
        Else
            TxtHours12.Text = "0"
            GlobalVariables.AM_PM_Shift(12) = "NA"
            GlobalVariables.No_Of_Days(12) = 0
            If Chk12PM.Checked = True Then
                'TxtHours12.Text = "12"

                GlobalVariables.AM_PM_Shift(12) = "PM"
                GlobalVariables.No_Of_Days(12) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub
    Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles Chk12PM.CheckedChanged
        If Chk12AM.Checked = True Then
            TxtHours12.Text = "12"
            GlobalVariables.AM_PM_Shift(12) = "AM"
            GlobalVariables.No_Of_Days(12) = 1
            If Chk12PM.Checked = True Then
                TxtHours12.Text = "24"
                GlobalVariables.AM_PM_Shift(12) = "AP"
                GlobalVariables.No_Of_Days(12) = 2
            End If
        Else
            TxtHours12.Text = "0"
            GlobalVariables.AM_PM_Shift(12) = "NA"
            GlobalVariables.No_Of_Days(12) = 0
            If Chk12PM.Checked = True Then
                TxtHours12.Text = "12"
                GlobalVariables.AM_PM_Shift(12) = "PM"
                GlobalVariables.No_Of_Days(12) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub
    Private Sub Chk13AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk13AM.CheckedChanged
        If Chk13AM.Checked = True Then
            'TxtHours13.Text = "12"
            TxtHours13.Text = GlobalVariables.iHours_Rendered(12)
            GlobalVariables.AM_PM_Shift(13) = "AM"
            GlobalVariables.No_Of_Days(13) = 1
            If Chk13PM.Checked = True Then
                TxtHours13.Text = "24"
                GlobalVariables.AM_PM_Shift(13) = "AP"
                GlobalVariables.No_Of_Days(13) = 2
            End If
        Else
            TxtHours13.Text = "0"
            GlobalVariables.AM_PM_Shift(13) = "NA"
            GlobalVariables.No_Of_Days(13) = 0
            If Chk13PM.Checked = True Then
                'TxtHours13.Text = "12"

                GlobalVariables.AM_PM_Shift(13) = "PM"
                GlobalVariables.No_Of_Days(13) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk13PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk13PM.CheckedChanged
        If Chk13AM.Checked = True Then
            TxtHours13.Text = "12"
            GlobalVariables.AM_PM_Shift(13) = "AM"
            GlobalVariables.No_Of_Days(13) = 1
            If Chk13PM.Checked = True Then
                TxtHours13.Text = "24"
                GlobalVariables.AM_PM_Shift(13) = "AP"
                GlobalVariables.No_Of_Days(13) = 2
            End If
        Else
            TxtHours13.Text = "0"
            GlobalVariables.AM_PM_Shift(13) = "NA"
            GlobalVariables.No_Of_Days(13) = 0
            If Chk13PM.Checked = True Then
                TxtHours13.Text = "12"
                GlobalVariables.AM_PM_Shift(13) = "PM"
                GlobalVariables.No_Of_Days(13) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk14AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk14AM.CheckedChanged
        If Chk14AM.Checked = True Then
            'TxtHours14.Text = "12"
            TxtHours14.Text = GlobalVariables.iHours_Rendered(13)
            GlobalVariables.AM_PM_Shift(14) = "AM"
            GlobalVariables.No_Of_Days(14) = 1
            If Chk14PM.Checked = True Then
                TxtHours14.Text = "24"
                GlobalVariables.AM_PM_Shift(14) = "AP"
                GlobalVariables.No_Of_Days(14) = 2
            End If
        Else
            TxtHours14.Text = "0"
            GlobalVariables.AM_PM_Shift(14) = "NA"
            GlobalVariables.No_Of_Days(14) = 0
            If Chk14PM.Checked = True Then
                'TxtHours14.Text = "12"

                GlobalVariables.AM_PM_Shift(14) = "PM"
                GlobalVariables.No_Of_Days(14) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk14PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk14PM.CheckedChanged
        If Chk14AM.Checked = True Then
            TxtHours14.Text = "12"
            GlobalVariables.AM_PM_Shift(14) = "AM"
            GlobalVariables.No_Of_Days(14) = 1
            If Chk14PM.Checked = True Then
                TxtHours14.Text = "24"
                GlobalVariables.AM_PM_Shift(14) = "AP"
                GlobalVariables.No_Of_Days(14) = 2
            End If
        Else
            TxtHours14.Text = "0"
            GlobalVariables.AM_PM_Shift(14) = "NA"
            GlobalVariables.No_Of_Days(14) = 0
            If Chk14PM.Checked = True Then
                TxtHours14.Text = "12"
                GlobalVariables.AM_PM_Shift(14) = "PM"
                GlobalVariables.No_Of_Days(14) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub Chk15AM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk15AM.CheckedChanged
        If Chk15AM.Checked = True Then
            'TxtHours15.Text = "12"
            TxtHours15.Text = GlobalVariables.iHours_Rendered(14)
            GlobalVariables.AM_PM_Shift(15) = "AM"
            GlobalVariables.No_Of_Days(15) = 1
            If Chk15PM.Checked = True Then
                TxtHours15.Text = "24"
                GlobalVariables.AM_PM_Shift(15) = "AP"
                GlobalVariables.No_Of_Days(15) = 2
            End If
        Else
            TxtHours15.Text = "0"
            GlobalVariables.AM_PM_Shift(15) = "NA"
            GlobalVariables.No_Of_Days(15) = 0
            If Chk15PM.Checked = True Then
                'TxtHours15.Text = "12"

                GlobalVariables.AM_PM_Shift(15) = "PM"
                GlobalVariables.No_Of_Days(15) = 1
            End If
        End If


        Call Compute_Total_Days()
    End Sub

    Private Sub Chk15PM_CheckedChanged(sender As Object, e As EventArgs) Handles Chk15PM.CheckedChanged
        If Chk15AM.Checked = True Then
            TxtHours15.Text = "12"
            GlobalVariables.AM_PM_Shift(15) = "AM"
            GlobalVariables.No_Of_Days(15) = 1
            If Chk15PM.Checked = True Then
                TxtHours15.Text = "24"
                GlobalVariables.AM_PM_Shift(15) = "AP"
                GlobalVariables.No_Of_Days(15) = 2
            End If
        Else
            TxtHours15.Text = "0"
            GlobalVariables.AM_PM_Shift(15) = "NA"
            GlobalVariables.No_Of_Days(15) = 0
            If Chk15PM.Checked = True Then
                TxtHours15.Text = "12"
                GlobalVariables.AM_PM_Shift(15) = "PM"
                GlobalVariables.No_Of_Days(15) = 1
            End If
        End If
        Call Compute_Total_Days()
    End Sub

    Private Sub TxtHours1_TextChanged(sender As Object, e As EventArgs) Handles TxtHours1.TextChanged, TxtHours1.TextChanged


        '' Considering Sunday & Holiday 

        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("1") ' for TxtHours

        'If Chk1AM.Checked = False And Chk1PM.Checked = False Then ' Zero Hours (Absent or  RD) 
        '    Clear_Textbox_Hours(1)
        '    'Exit Sub ' Nothing to compute so just exit
        'End If

        If UCase(GlobalVariables.sDay(1)) = "SUN" Then 'Sunday

            If Btn_1.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk1AM.Checked = True And Chk1PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 8 ' assuming no undertime
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = 0

                ElseIf Chk1AM.Checked = False And Chk1PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 8 ' assuming no undertime
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 8 ' assuming no undertime
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = 0

                ElseIf Chk1AM.Checked = True And Chk1PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 16 ' assuming no undertime
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 8
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 8
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = 0
                End If

            ElseIf Btn_1.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk1AM.Checked = True And Chk1PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0 ' assuming no undertime
                    Txt_REG_SH_1.Text = 8
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_LH_1.Text = 0

                ElseIf Chk1AM.Checked = False And Chk1PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0 ' assuming no undertime
                    Txt_REG_SH_1.Text = 8
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 8
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_LH_1.Text = 0

                ElseIf Chk1AM.Checked = True And Chk1PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 8
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 8
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_LH_1.Text = 0

                End If

            ElseIf Btn_1.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk1AM.Checked = True And Chk1PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 8

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = CDbl(TxtHours1.Text) - 8

                ElseIf Chk1AM.Checked = False And Chk1PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 8

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 8

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = CDbl(TxtHours1.Text) - 8

                ElseIf Chk1AM.Checked = True And Chk1PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 16

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 8

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = CDbl(TxtHours1.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_1.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk1AM.Checked = True And Chk1PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_1.Text = 8
                    Txt_REG_SUN_1.Text = 0 ' assuming no undertime
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = 0

                ElseIf Chk1AM.Checked = False And Chk1PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_1.Text = 8
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 8
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = 0

                ElseIf Chk1AM.Checked = True And Chk1PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_1.Text = 16
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 8
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 8
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = 0
                End If

            ElseIf Btn_1.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk1AM.Checked = True And Chk1PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0 ' assuming no undertime
                    Txt_REG_SH_1.Text = 8
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_LH_1.Text = 0

                ElseIf Chk1AM.Checked = False And Chk1PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0 ' assuming no undertime
                    Txt_REG_SH_1.Text = 8
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 8
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = CDbl(TxtHours1.Text) - 8
                    Txt_OT_LH_1.Text = 0

                ElseIf Chk1AM.Checked = True And Chk1PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 16
                    Txt_REG_LH_1.Text = 0

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 8
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 8
                    Txt_OT_LH_1.Text = 0

                End If

            ElseIf Btn_1.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk1AM.Checked = True And Chk1PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 8

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 0

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = CDbl(TxtHours1.Text) - 8

                ElseIf Chk1AM.Checked = False And Chk1PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 8

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 8

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = CDbl(TxtHours1.Text) - 8

                ElseIf Chk1AM.Checked = True And Chk1PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_1.Text = 0
                    Txt_REG_SUN_1.Text = 0
                    Txt_REG_SH_1.Text = 0
                    Txt_REG_LH_1.Text = 16

                    Txt_ND_REG_1.Text = 0
                    Txt_ND_SUN_1.Text = 0
                    Txt_ND_SH_1.Text = 0
                    Txt_ND_LH_1.Text = 8

                    Txt_OT_REG_1.Text = 0
                    Txt_OT_SUN_1.Text = 0
                    Txt_OT_SH_1.Text = 0
                    Txt_OT_LH_1.Text = 8

                End If
            End If

        End If

        ' ========== Generate DTR Values ( for every Date in Payroll Period ) ==================

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub

    Private Sub TxtHours2_TextChanged(sender As Object, e As EventArgs) Handles TxtHours2.TextChanged

        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("2") ' for TxtHours

        ' Conditions for filling out the hours rendered accordingly

        If Chk2AM.Checked = False And Chk2PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(2)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(2)) = "SUN" Then 'Sunday

            If Btn_2.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk2AM.Checked = True And Chk2PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 8 ' assuming no undertime
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = 0

                ElseIf Chk2AM.Checked = False And Chk2PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 8 ' assuming no undertime
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 8 ' assuming no undertime
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = 0

                ElseIf Chk2AM.Checked = True And Chk2PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 16 ' assuming no undertime
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 8
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 8
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = 0
                End If

            ElseIf Btn_2.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk2AM.Checked = True And Chk2PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0 ' assuming no undertime
                    Txt_REG_SH_2.Text = 8
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_LH_2.Text = 0

                ElseIf Chk2AM.Checked = False And Chk2PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0 ' assuming no undertime
                    Txt_REG_SH_2.Text = 8
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 8
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_LH_2.Text = 0

                ElseIf Chk2AM.Checked = True And Chk2PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 8
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 8
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_LH_2.Text = 0

                End If

            ElseIf Btn_2.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk2AM.Checked = True And Chk2PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 8

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = CDbl(TxtHours2.Text) - 8

                ElseIf Chk2AM.Checked = False And Chk2PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 8

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 8

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = CDbl(TxtHours2.Text) - 8

                ElseIf Chk2AM.Checked = True And Chk2PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 16

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 8

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = CDbl(TxtHours2.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_2.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk2AM.Checked = True And Chk2PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_2.Text = 8
                    Txt_REG_SUN_2.Text = 0 ' assuming no undertime
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = 0

                ElseIf Chk2AM.Checked = False And Chk2PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_2.Text = 8
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 8
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = 0

                ElseIf Chk2AM.Checked = True And Chk2PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_2.Text = 16
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 8
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 8
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = 0
                End If

            ElseIf Btn_2.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk2AM.Checked = True And Chk2PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0 ' assuming no undertime
                    Txt_REG_SH_2.Text = 8
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_LH_2.Text = 0

                ElseIf Chk2AM.Checked = False And Chk2PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0 ' assuming no undertime
                    Txt_REG_SH_2.Text = 8
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 8
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = CDbl(TxtHours2.Text) - 8
                    Txt_OT_LH_2.Text = 0

                ElseIf Chk2AM.Checked = True And Chk2PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 16
                    Txt_REG_LH_2.Text = 0

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 8
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 8
                    Txt_OT_LH_2.Text = 0

                End If

            ElseIf Btn_2.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk2AM.Checked = True And Chk2PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 8

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 0

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = CDbl(TxtHours2.Text) - 8

                ElseIf Chk2AM.Checked = False And Chk2PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 8

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 8

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = CDbl(TxtHours2.Text) - 8

                ElseIf Chk2AM.Checked = True And Chk2PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_2.Text = 0
                    Txt_REG_SUN_2.Text = 0
                    Txt_REG_SH_2.Text = 0
                    Txt_REG_LH_2.Text = 16

                    Txt_ND_REG_2.Text = 0
                    Txt_ND_SUN_2.Text = 0
                    Txt_ND_SH_2.Text = 0
                    Txt_ND_LH_2.Text = 8

                    Txt_OT_REG_2.Text = 0
                    Txt_OT_SUN_2.Text = 0
                    Txt_OT_SH_2.Text = 0
                    Txt_OT_LH_2.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()

    End Sub

    Private Sub TxtHours3_TextChanged(sender As Object, e As EventArgs) Handles TxtHours3.TextChanged
        ' Considering Sunday & Holiday 


        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("3") ' for TxtHours

        ' Conditions for filling out the hours rendered accordingly

        If Chk3AM.Checked = False And Chk3PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(3)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(3)) = "SUN" Then 'Sunday

            If Btn_3.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk3AM.Checked = True And Chk3PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 8 ' assuming no undertime
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = 0

                ElseIf Chk3AM.Checked = False And Chk3PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 8 ' assuming no undertime
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 8 ' assuming no undertime
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = 0

                ElseIf Chk3AM.Checked = True And Chk3PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 16 ' assuming no undertime
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 8
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 8
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = 0
                End If

            ElseIf Btn_3.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk3AM.Checked = True And Chk3PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0 ' assuming no undertime
                    Txt_REG_SH_3.Text = 8
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_LH_3.Text = 0

                ElseIf Chk3AM.Checked = False And Chk3PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0 ' assuming no undertime
                    Txt_REG_SH_3.Text = 8
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 8
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_LH_3.Text = 0

                ElseIf Chk3AM.Checked = True And Chk3PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 8
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 8
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_LH_3.Text = 0

                End If

            ElseIf Btn_3.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk3AM.Checked = True And Chk3PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 8

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = CDbl(TxtHours3.Text) - 8

                ElseIf Chk3AM.Checked = False And Chk3PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 8

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 8

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = CDbl(TxtHours3.Text) - 8

                ElseIf Chk3AM.Checked = True And Chk3PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 16

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 8

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = CDbl(TxtHours3.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_3.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk3AM.Checked = True And Chk3PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_3.Text = 8
                    Txt_REG_SUN_3.Text = 0 ' assuming no undertime
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = 0

                ElseIf Chk3AM.Checked = False And Chk3PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_3.Text = 8
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 8
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = 0

                ElseIf Chk3AM.Checked = True And Chk3PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_3.Text = 16
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 8
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 8
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = 0
                End If

            ElseIf Btn_3.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk3AM.Checked = True And Chk3PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0 ' assuming no undertime
                    Txt_REG_SH_3.Text = 8
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_LH_3.Text = 0

                ElseIf Chk3AM.Checked = False And Chk3PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0 ' assuming no undertime
                    Txt_REG_SH_3.Text = 8
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 8
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = CDbl(TxtHours3.Text) - 8
                    Txt_OT_LH_3.Text = 0

                ElseIf Chk3AM.Checked = True And Chk3PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 16
                    Txt_REG_LH_3.Text = 0

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 8
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 8
                    Txt_OT_LH_3.Text = 0

                End If

            ElseIf Btn_3.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk3AM.Checked = True And Chk3PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 8

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 0

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = CDbl(TxtHours3.Text) - 8

                ElseIf Chk3AM.Checked = False And Chk3PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 8

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 8

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = CDbl(TxtHours3.Text) - 8

                ElseIf Chk3AM.Checked = True And Chk3PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_3.Text = 0
                    Txt_REG_SUN_3.Text = 0
                    Txt_REG_SH_3.Text = 0
                    Txt_REG_LH_3.Text = 16

                    Txt_ND_REG_3.Text = 0
                    Txt_ND_SUN_3.Text = 0
                    Txt_ND_SH_3.Text = 0
                    Txt_ND_LH_3.Text = 8

                    Txt_OT_REG_3.Text = 0
                    Txt_OT_SUN_3.Text = 0
                    Txt_OT_SH_3.Text = 0
                    Txt_OT_LH_3.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub

    Private Sub TxtHours4_TextChanged(sender As Object, e As EventArgs) Handles TxtHours4.TextChanged
        ' Considering Sunday & Holiday 


        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("4") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk4AM.Checked = False And Chk4PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(4)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(4)) = "SUN" Then 'Sunday

            If Btn_4.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk4AM.Checked = True And Chk4PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 8 ' assuming no undertime
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = 0

                ElseIf Chk4AM.Checked = False And Chk4PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 8 ' assuming no undertime
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 8 ' assuming no undertime
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = 0

                ElseIf Chk4AM.Checked = True And Chk4PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 16 ' assuming no undertime
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 8
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 8
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = 0
                End If

            ElseIf Btn_4.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk4AM.Checked = True And Chk4PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0 ' assuming no undertime
                    Txt_REG_SH_4.Text = 8
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_LH_4.Text = 0

                ElseIf Chk4AM.Checked = False And Chk4PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0 ' assuming no undertime
                    Txt_REG_SH_4.Text = 8
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 8
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_LH_4.Text = 0

                ElseIf Chk4AM.Checked = True And Chk4PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 8
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 8
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_LH_4.Text = 0

                End If

            ElseIf Btn_4.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk4AM.Checked = True And Chk4PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 8

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = CDbl(TxtHours4.Text) - 8

                ElseIf Chk4AM.Checked = False And Chk4PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 8

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 8

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = CDbl(TxtHours4.Text) - 8

                ElseIf Chk4AM.Checked = True And Chk4PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 16

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 8

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = CDbl(TxtHours4.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_4.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk4AM.Checked = True And Chk4PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_4.Text = 8
                    Txt_REG_SUN_4.Text = 0 ' assuming no undertime
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = 0

                ElseIf Chk4AM.Checked = False And Chk4PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_4.Text = 8
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 8
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = 0

                ElseIf Chk4AM.Checked = True And Chk4PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_4.Text = 16
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 8
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 8
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = 0
                End If

            ElseIf Btn_4.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk4AM.Checked = True And Chk4PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0 ' assuming no undertime
                    Txt_REG_SH_4.Text = 8
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_LH_4.Text = 0

                ElseIf Chk4AM.Checked = False And Chk4PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0 ' assuming no undertime
                    Txt_REG_SH_4.Text = 8
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 8
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = CDbl(TxtHours4.Text) - 8
                    Txt_OT_LH_4.Text = 0

                ElseIf Chk4AM.Checked = True And Chk4PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 16
                    Txt_REG_LH_4.Text = 0

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 8
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 8
                    Txt_OT_LH_4.Text = 0

                End If

            ElseIf Btn_4.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk4AM.Checked = True And Chk4PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 8

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 0

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = CDbl(TxtHours4.Text) - 8

                ElseIf Chk4AM.Checked = False And Chk4PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 8

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 8

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = CDbl(TxtHours4.Text) - 8

                ElseIf Chk4AM.Checked = True And Chk4PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_4.Text = 0
                    Txt_REG_SUN_4.Text = 0
                    Txt_REG_SH_4.Text = 0
                    Txt_REG_LH_4.Text = 16

                    Txt_ND_REG_4.Text = 0
                    Txt_ND_SUN_4.Text = 0
                    Txt_ND_SH_4.Text = 0
                    Txt_ND_LH_4.Text = 8

                    Txt_OT_REG_4.Text = 0
                    Txt_OT_SUN_4.Text = 0
                    Txt_OT_SH_4.Text = 0
                    Txt_OT_LH_4.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub



    Private Sub TxtHours5_TextChanged(sender As Object, e As EventArgs) Handles TxtHours5.TextChanged
        ' Considering Sunday & Holiday 


        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("5") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk5AM.Checked = False And Chk5PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(5)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(5)) = "SUN" Then 'Sunday

            If Btn_5.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk5AM.Checked = True And Chk5PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 8 ' assuming no undertime
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = 0

                ElseIf Chk5AM.Checked = False And Chk5PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 8 ' assuming no undertime
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 8 ' assuming no undertime
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = 0

                ElseIf Chk5AM.Checked = True And Chk5PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 16 ' assuming no undertime
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 8
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 8
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = 0
                End If

            ElseIf Btn_5.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk5AM.Checked = True And Chk5PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0 ' assuming no undertime
                    Txt_REG_SH_5.Text = 8
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_LH_5.Text = 0

                ElseIf Chk5AM.Checked = False And Chk5PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0 ' assuming no undertime
                    Txt_REG_SH_5.Text = 8
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 8
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_LH_5.Text = 0

                ElseIf Chk5AM.Checked = True And Chk5PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 8
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 8
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_LH_5.Text = 0

                End If

            ElseIf Btn_5.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk5AM.Checked = True And Chk5PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 8

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = CDbl(TxtHours5.Text) - 8

                ElseIf Chk5AM.Checked = False And Chk5PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 8

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 8

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = CDbl(TxtHours5.Text) - 8

                ElseIf Chk5AM.Checked = True And Chk5PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 16

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 8

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = CDbl(TxtHours5.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_5.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk5AM.Checked = True And Chk5PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_5.Text = 8
                    Txt_REG_SUN_5.Text = 0 ' assuming no undertime
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = 0

                ElseIf Chk5AM.Checked = False And Chk5PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_5.Text = 8
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 8
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = 0

                ElseIf Chk5AM.Checked = True And Chk5PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_5.Text = 16
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 8
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 8
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = 0
                End If

            ElseIf Btn_5.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk5AM.Checked = True And Chk5PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0 ' assuming no undertime
                    Txt_REG_SH_5.Text = 8
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_LH_5.Text = 0

                ElseIf Chk5AM.Checked = False And Chk5PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0 ' assuming no undertime
                    Txt_REG_SH_5.Text = 8
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 8
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = CDbl(TxtHours5.Text) - 8
                    Txt_OT_LH_5.Text = 0

                ElseIf Chk5AM.Checked = True And Chk5PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 16
                    Txt_REG_LH_5.Text = 0

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 8
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 8
                    Txt_OT_LH_5.Text = 0

                End If

            ElseIf Btn_5.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk5AM.Checked = True And Chk5PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 8

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 0

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = CDbl(TxtHours5.Text) - 8

                ElseIf Chk5AM.Checked = False And Chk5PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 8

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 8

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = CDbl(TxtHours5.Text) - 8

                ElseIf Chk5AM.Checked = True And Chk5PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_5.Text = 0
                    Txt_REG_SUN_5.Text = 0
                    Txt_REG_SH_5.Text = 0
                    Txt_REG_LH_5.Text = 16

                    Txt_ND_REG_5.Text = 0
                    Txt_ND_SUN_5.Text = 0
                    Txt_ND_SH_5.Text = 0
                    Txt_ND_LH_5.Text = 8

                    Txt_OT_REG_5.Text = 0
                    Txt_OT_SUN_5.Text = 0
                    Txt_OT_SH_5.Text = 0
                    Txt_OT_LH_5.Text = 8

                End If
            End If

        End If
        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()

    End Sub

    Private Sub TxtHours6_TextChanged(sender As Object, e As EventArgs) Handles TxtHours6.TextChanged
        ' Considering Sunday & Holiday 


        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("6") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk6AM.Checked = False And Chk6PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(6)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(6)) = "SUN" Then 'Sunday

            If Btn_6.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk6AM.Checked = True And Chk6PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 8 ' assuming no undertime
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = 0

                ElseIf Chk6AM.Checked = False And Chk6PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 8 ' assuming no undertime
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 8 ' assuming no undertime
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = 0

                ElseIf Chk6AM.Checked = True And Chk6PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 16 ' assuming no undertime
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 8
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 8
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = 0
                End If

            ElseIf Btn_6.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk6AM.Checked = True And Chk6PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0 ' assuming no undertime
                    Txt_REG_SH_6.Text = 8
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_LH_6.Text = 0

                ElseIf Chk6AM.Checked = False And Chk6PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0 ' assuming no undertime
                    Txt_REG_SH_6.Text = 8
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 8
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_LH_6.Text = 0

                ElseIf Chk6AM.Checked = True And Chk6PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 8
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 8
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_LH_6.Text = 0

                End If

            ElseIf Btn_6.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk6AM.Checked = True And Chk6PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 8

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = CDbl(TxtHours6.Text) - 8

                ElseIf Chk6AM.Checked = False And Chk6PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 8

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 8

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = CDbl(TxtHours6.Text) - 8

                ElseIf Chk6AM.Checked = True And Chk6PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 16

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 8

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = CDbl(TxtHours6.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_6.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk6AM.Checked = True And Chk6PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_6.Text = 8
                    Txt_REG_SUN_6.Text = 0 ' assuming no undertime
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = 0

                ElseIf Chk6AM.Checked = False And Chk6PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_6.Text = 8
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 8
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = 0

                ElseIf Chk6AM.Checked = True And Chk6PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_6.Text = 16
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 8
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 8
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = 0
                End If

            ElseIf Btn_6.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk6AM.Checked = True And Chk6PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0 ' assuming no undertime
                    Txt_REG_SH_6.Text = 8
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_LH_6.Text = 0

                ElseIf Chk6AM.Checked = False And Chk6PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0 ' assuming no undertime
                    Txt_REG_SH_6.Text = 8
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 8
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = CDbl(TxtHours6.Text) - 8
                    Txt_OT_LH_6.Text = 0

                ElseIf Chk6AM.Checked = True And Chk6PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 16
                    Txt_REG_LH_6.Text = 0

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 8
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 8
                    Txt_OT_LH_6.Text = 0

                End If

            ElseIf Btn_6.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk6AM.Checked = True And Chk6PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 8

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 0

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = CDbl(TxtHours6.Text) - 8

                ElseIf Chk6AM.Checked = False And Chk6PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 8

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 8

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = CDbl(TxtHours6.Text) - 8

                ElseIf Chk6AM.Checked = True And Chk6PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_6.Text = 0
                    Txt_REG_SUN_6.Text = 0
                    Txt_REG_SH_6.Text = 0
                    Txt_REG_LH_6.Text = 16

                    Txt_ND_REG_6.Text = 0
                    Txt_ND_SUN_6.Text = 0
                    Txt_ND_SH_6.Text = 0
                    Txt_ND_LH_6.Text = 8

                    Txt_OT_REG_6.Text = 0
                    Txt_OT_SUN_6.Text = 0
                    Txt_OT_SH_6.Text = 0
                    Txt_OT_LH_6.Text = 8

                End If
            End If

        End If
        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()

    End Sub

    Private Sub TxtHours7_TextChanged(sender As Object, e As EventArgs) Handles TxtHours7.TextChanged
        ' Considering Sunday & Holiday 

        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("7") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk7AM.Checked = False And Chk7PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(7)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(7)) = "SUN" Then 'Sunday

            If Btn_7.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk7AM.Checked = True And Chk7PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 8 ' assuming no undertime
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = 0

                ElseIf Chk7AM.Checked = False And Chk7PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 8 ' assuming no undertime
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 8 ' assuming no undertime
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = 0

                ElseIf Chk7AM.Checked = True And Chk7PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 16 ' assuming no undertime
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 8
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 8
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = 0
                End If

            ElseIf Btn_7.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk7AM.Checked = True And Chk7PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0 ' assuming no undertime
                    Txt_REG_SH_7.Text = 8
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_LH_7.Text = 0

                ElseIf Chk7AM.Checked = False And Chk7PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0 ' assuming no undertime
                    Txt_REG_SH_7.Text = 8
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 8
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_LH_7.Text = 0

                ElseIf Chk7AM.Checked = True And Chk7PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 8
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 8
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_LH_7.Text = 0

                End If

            ElseIf Btn_7.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk7AM.Checked = True And Chk7PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 8

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = CDbl(TxtHours7.Text) - 8

                ElseIf Chk7AM.Checked = False And Chk7PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 8

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 8

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = CDbl(TxtHours7.Text) - 8

                ElseIf Chk7AM.Checked = True And Chk7PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 16

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 8

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = CDbl(TxtHours7.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_7.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk7AM.Checked = True And Chk7PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_7.Text = 8
                    Txt_REG_SUN_7.Text = 0 ' assuming no undertime
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = 0

                ElseIf Chk7AM.Checked = False And Chk7PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_7.Text = 8
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 8
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = 0

                ElseIf Chk7AM.Checked = True And Chk7PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_7.Text = 16
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 8
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 8
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = 0
                End If

            ElseIf Btn_7.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk7AM.Checked = True And Chk7PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0 ' assuming no undertime
                    Txt_REG_SH_7.Text = 8
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_LH_7.Text = 0

                ElseIf Chk7AM.Checked = False And Chk7PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0 ' assuming no undertime
                    Txt_REG_SH_7.Text = 8
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 8
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = CDbl(TxtHours7.Text) - 8
                    Txt_OT_LH_7.Text = 0

                ElseIf Chk7AM.Checked = True And Chk7PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 16
                    Txt_REG_LH_7.Text = 0

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 8
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 8
                    Txt_OT_LH_7.Text = 0

                End If

            ElseIf Btn_7.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk7AM.Checked = True And Chk7PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 8

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 0

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = CDbl(TxtHours7.Text) - 8

                ElseIf Chk7AM.Checked = False And Chk7PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 8

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 8

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = CDbl(TxtHours7.Text) - 8

                ElseIf Chk7AM.Checked = True And Chk7PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_7.Text = 0
                    Txt_REG_SUN_7.Text = 0
                    Txt_REG_SH_7.Text = 0
                    Txt_REG_LH_7.Text = 16

                    Txt_ND_REG_7.Text = 0
                    Txt_ND_SUN_7.Text = 0
                    Txt_ND_SH_7.Text = 0
                    Txt_ND_LH_7.Text = 8

                    Txt_OT_REG_7.Text = 0
                    Txt_OT_SUN_7.Text = 0
                    Txt_OT_SH_7.Text = 0
                    Txt_OT_LH_7.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub

    Private Sub TxtHours8_TextChanged(sender As Object, e As EventArgs) Handles TxtHours8.TextChanged
        ' Considering Sunday & Holiday 

        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("8") ' for TxtHours

        ' Conditions for filling out the hours rendered accordingly

        If Chk8AM.Checked = False And Chk8PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(8)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(8)) = "SUN" Then 'Sunday

            If Btn_8.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk8AM.Checked = True And Chk8PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 8 ' assuming no undertime
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = 0

                ElseIf Chk8AM.Checked = False And Chk8PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 8 ' assuming no undertime
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 8 ' assuming no undertime
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = 0

                ElseIf Chk8AM.Checked = True And Chk8PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 16 ' assuming no undertime
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 8
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 8
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = 0
                End If

            ElseIf Btn_8.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk8AM.Checked = True And Chk8PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0 ' assuming no undertime
                    Txt_REG_SH_8.Text = 8
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_LH_8.Text = 0

                ElseIf Chk8AM.Checked = False And Chk8PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0 ' assuming no undertime
                    Txt_REG_SH_8.Text = 8
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 8
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_LH_8.Text = 0

                ElseIf Chk8AM.Checked = True And Chk8PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 8
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 8
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_LH_8.Text = 0

                End If

            ElseIf Btn_8.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk8AM.Checked = True And Chk8PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 8

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = CDbl(TxtHours8.Text) - 8

                ElseIf Chk8AM.Checked = False And Chk8PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 8

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 8

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = CDbl(TxtHours8.Text) - 8

                ElseIf Chk8AM.Checked = True And Chk8PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 16

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 8

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = CDbl(TxtHours8.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_8.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk8AM.Checked = True And Chk8PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_8.Text = 8
                    Txt_REG_SUN_8.Text = 0 ' assuming no undertime
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = 0

                ElseIf Chk8AM.Checked = False And Chk8PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_8.Text = 8
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 8
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = 0

                ElseIf Chk8AM.Checked = True And Chk8PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_8.Text = 16
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 8
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 8
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = 0
                End If

            ElseIf Btn_8.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk8AM.Checked = True And Chk8PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0 ' assuming no undertime
                    Txt_REG_SH_8.Text = 8
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_LH_8.Text = 0

                ElseIf Chk8AM.Checked = False And Chk8PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0 ' assuming no undertime
                    Txt_REG_SH_8.Text = 8
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 8
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = CDbl(TxtHours8.Text) - 8
                    Txt_OT_LH_8.Text = 0

                ElseIf Chk8AM.Checked = True And Chk8PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 16
                    Txt_REG_LH_8.Text = 0

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 8
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 8
                    Txt_OT_LH_8.Text = 0

                End If

            ElseIf Btn_8.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk8AM.Checked = True And Chk8PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 8

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 0

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = CDbl(TxtHours8.Text) - 8

                ElseIf Chk8AM.Checked = False And Chk8PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 8

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 8

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = CDbl(TxtHours8.Text) - 8

                ElseIf Chk8AM.Checked = True And Chk8PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_8.Text = 0
                    Txt_REG_SUN_8.Text = 0
                    Txt_REG_SH_8.Text = 0
                    Txt_REG_LH_8.Text = 16

                    Txt_ND_REG_8.Text = 0
                    Txt_ND_SUN_8.Text = 0
                    Txt_ND_SH_8.Text = 0
                    Txt_ND_LH_8.Text = 8

                    Txt_OT_REG_8.Text = 0
                    Txt_OT_SUN_8.Text = 0
                    Txt_OT_SH_8.Text = 0
                    Txt_OT_LH_8.Text = 8

                End If
            End If

        End If
        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()

    End Sub

    Private Sub TxtHours9_TextChanged(sender As Object, e As EventArgs) Handles TxtHours9.TextChanged
        ' Considering Sunday & Holiday 

        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("9") ' for TxtHours

        ' Conditions for filling out the hours rendered accordingly

        If Chk9AM.Checked = False And Chk9PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(9)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(9)) = "SUN" Then 'Sunday

            If Btn_9.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk9AM.Checked = True And Chk9PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 8 ' assuming no undertime
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = 0

                ElseIf Chk9AM.Checked = False And Chk9PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 8 ' assuming no undertime
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 8 ' assuming no undertime
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = 0

                ElseIf Chk9AM.Checked = True And Chk9PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 16 ' assuming no undertime
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 8
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 8
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = 0
                End If

            ElseIf Btn_9.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk9AM.Checked = True And Chk9PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0 ' assuming no undertime
                    Txt_REG_SH_9.Text = 8
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_LH_9.Text = 0

                ElseIf Chk9AM.Checked = False And Chk9PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0 ' assuming no undertime
                    Txt_REG_SH_9.Text = 8
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 8
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_LH_9.Text = 0

                ElseIf Chk9AM.Checked = True And Chk9PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 8
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 8
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_LH_9.Text = 0

                End If

            ElseIf Btn_9.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk9AM.Checked = True And Chk9PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 8

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = CDbl(TxtHours9.Text) - 8

                ElseIf Chk9AM.Checked = False And Chk9PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 8

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 8

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = CDbl(TxtHours9.Text) - 8

                ElseIf Chk9AM.Checked = True And Chk9PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 16

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 8

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = CDbl(TxtHours9.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_9.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk9AM.Checked = True And Chk9PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_9.Text = 8
                    Txt_REG_SUN_9.Text = 0 ' assuming no undertime
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = 0

                ElseIf Chk9AM.Checked = False And Chk9PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_9.Text = 8
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 8
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = 0

                ElseIf Chk9AM.Checked = True And Chk9PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_9.Text = 16
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 8
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 8
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = 0
                End If

            ElseIf Btn_9.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk9AM.Checked = True And Chk9PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0 ' assuming no undertime
                    Txt_REG_SH_9.Text = 8
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_LH_9.Text = 0

                ElseIf Chk9AM.Checked = False And Chk9PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0 ' assuming no undertime
                    Txt_REG_SH_9.Text = 8
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 8
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = CDbl(TxtHours9.Text) - 8
                    Txt_OT_LH_9.Text = 0

                ElseIf Chk9AM.Checked = True And Chk9PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 16
                    Txt_REG_LH_9.Text = 0

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 8
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 8
                    Txt_OT_LH_9.Text = 0

                End If

            ElseIf Btn_9.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk9AM.Checked = True And Chk9PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 8

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 0

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = CDbl(TxtHours9.Text) - 8

                ElseIf Chk9AM.Checked = False And Chk9PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 8

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 8

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = CDbl(TxtHours9.Text) - 8

                ElseIf Chk9AM.Checked = True And Chk9PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_9.Text = 0
                    Txt_REG_SUN_9.Text = 0
                    Txt_REG_SH_9.Text = 0
                    Txt_REG_LH_9.Text = 16

                    Txt_ND_REG_9.Text = 0
                    Txt_ND_SUN_9.Text = 0
                    Txt_ND_SH_9.Text = 0
                    Txt_ND_LH_9.Text = 8

                    Txt_OT_REG_9.Text = 0
                    Txt_OT_SUN_9.Text = 0
                    Txt_OT_SH_9.Text = 0
                    Txt_OT_LH_9.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub

    Private Sub TxtHours10_TextChanged(sender As Object, e As EventArgs) Handles TxtHours10.TextChanged
        ' Considering Sunday & Holiday 


        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("10") ' for TxtHours

        ' Conditions for filling out the hours rendered accordingly

        If Chk10AM.Checked = False And Chk10PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(10)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(10)) = "SUN" Then 'Sunday

            If Btn_10.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk10AM.Checked = True And Chk10PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 8 ' assuming no undertime
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = 0

                ElseIf Chk10AM.Checked = False And Chk10PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 8 ' assuming no undertime
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 8 ' assuming no undertime
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = 0

                ElseIf Chk10AM.Checked = True And Chk10PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 16 ' assuming no undertime
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 8
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 8
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = 0
                End If

            ElseIf Btn_10.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk10AM.Checked = True And Chk10PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0 ' assuming no undertime
                    Txt_REG_SH_10.Text = 8
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_LH_10.Text = 0

                ElseIf Chk10AM.Checked = False And Chk10PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0 ' assuming no undertime
                    Txt_REG_SH_10.Text = 8
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 8
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_LH_10.Text = 0

                ElseIf Chk10AM.Checked = True And Chk10PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 8
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 8
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_LH_10.Text = 0

                End If

            ElseIf Btn_10.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk10AM.Checked = True And Chk10PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 8

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = CDbl(TxtHours10.Text) - 8

                ElseIf Chk10AM.Checked = False And Chk10PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 8

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 8

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = CDbl(TxtHours10.Text) - 8

                ElseIf Chk10AM.Checked = True And Chk10PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 16

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 8

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = CDbl(TxtHours10.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_10.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk10AM.Checked = True And Chk10PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_10.Text = 8
                    Txt_REG_SUN_10.Text = 0 ' assuming no undertime
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = 0

                ElseIf Chk10AM.Checked = False And Chk10PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_10.Text = 8
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 8
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = 0

                ElseIf Chk10AM.Checked = True And Chk10PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_10.Text = 16
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 8
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 8
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = 0
                End If

            ElseIf Btn_10.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk10AM.Checked = True And Chk10PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0 ' assuming no undertime
                    Txt_REG_SH_10.Text = 8
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_LH_10.Text = 0

                ElseIf Chk10AM.Checked = False And Chk10PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0 ' assuming no undertime
                    Txt_REG_SH_10.Text = 8
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 8
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = CDbl(TxtHours10.Text) - 8
                    Txt_OT_LH_10.Text = 0

                ElseIf Chk10AM.Checked = True And Chk10PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 16
                    Txt_REG_LH_10.Text = 0

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 8
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 8
                    Txt_OT_LH_10.Text = 0

                End If

            ElseIf Btn_10.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk10AM.Checked = True And Chk10PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 8

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 0

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = CDbl(TxtHours10.Text) - 8

                ElseIf Chk10AM.Checked = False And Chk10PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 8

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 8

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = CDbl(TxtHours10.Text) - 8

                ElseIf Chk10AM.Checked = True And Chk10PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_10.Text = 0
                    Txt_REG_SUN_10.Text = 0
                    Txt_REG_SH_10.Text = 0
                    Txt_REG_LH_10.Text = 16

                    Txt_ND_REG_10.Text = 0
                    Txt_ND_SUN_10.Text = 0
                    Txt_ND_SH_10.Text = 0
                    Txt_ND_LH_10.Text = 8

                    Txt_OT_REG_10.Text = 0
                    Txt_OT_SUN_10.Text = 0
                    Txt_OT_SH_10.Text = 0
                    Txt_OT_LH_10.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub

    Private Sub TxtHours11_TextChanged(sender As Object, e As EventArgs) Handles TxtHours11.TextChanged
        ' Considering Sunday & Holiday 

        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("11") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk11AM.Checked = False And CHK11PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(11)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(11)) = "SUN" Then 'Sunday

            If Btn_11.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk11AM.Checked = True And CHK11PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 8 ' assuming no undertime
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = 0

                ElseIf Chk11AM.Checked = False And CHK11PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 8 ' assuming no undertime
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 8 ' assuming no undertime
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = 0

                ElseIf Chk11AM.Checked = True And CHK11PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 16 ' assuming no undertime
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 8
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 8
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = 0
                End If

            ElseIf Btn_11.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk11AM.Checked = True And CHK11PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0 ' assuming no undertime
                    Txt_REG_SH_11.Text = 8
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_LH_11.Text = 0

                ElseIf Chk11AM.Checked = False And CHK11PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0 ' assuming no undertime
                    Txt_REG_SH_11.Text = 8
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 8
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_LH_11.Text = 0

                ElseIf Chk11AM.Checked = True And CHK11PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 8
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 8
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_LH_11.Text = 0

                End If

            ElseIf Btn_11.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk11AM.Checked = True And CHK11PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 8

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = CDbl(TxtHours11.Text) - 8

                ElseIf Chk11AM.Checked = False And CHK11PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 8

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 8

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = CDbl(TxtHours11.Text) - 8

                ElseIf Chk11AM.Checked = True And CHK11PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 16

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 8

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = CDbl(TxtHours11.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_11.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk11AM.Checked = True And CHK11PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_11.Text = 8
                    Txt_REG_SUN_11.Text = 0 ' assuming no undertime
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = 0

                ElseIf Chk11AM.Checked = False And CHK11PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_11.Text = 8
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 8
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = 0

                ElseIf Chk11AM.Checked = True And CHK11PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_11.Text = 16
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 8
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 8
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = 0
                End If

            ElseIf Btn_11.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk11AM.Checked = True And CHK11PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0 ' assuming no undertime
                    Txt_REG_SH_11.Text = 8
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_LH_11.Text = 0

                ElseIf Chk11AM.Checked = False And CHK11PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0 ' assuming no undertime
                    Txt_REG_SH_11.Text = 8
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 8
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = CDbl(TxtHours11.Text) - 8
                    Txt_OT_LH_11.Text = 0

                ElseIf Chk11AM.Checked = True And CHK11PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 16
                    Txt_REG_LH_11.Text = 0

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 8
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 8
                    Txt_OT_LH_11.Text = 0

                End If

            ElseIf Btn_11.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk11AM.Checked = True And CHK11PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 8

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 0

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = CDbl(TxtHours11.Text) - 8

                ElseIf Chk11AM.Checked = False And CHK11PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 8

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 8

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = CDbl(TxtHours11.Text) - 8

                ElseIf Chk11AM.Checked = True And CHK11PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_11.Text = 0
                    Txt_REG_SUN_11.Text = 0
                    Txt_REG_SH_11.Text = 0
                    Txt_REG_LH_11.Text = 16

                    Txt_ND_REG_11.Text = 0
                    Txt_ND_SUN_11.Text = 0
                    Txt_ND_SH_11.Text = 0
                    Txt_ND_LH_11.Text = 8

                    Txt_OT_REG_11.Text = 0
                    Txt_OT_SUN_11.Text = 0
                    Txt_OT_SH_11.Text = 0
                    Txt_OT_LH_11.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()


    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_1_Click(sender As Object, e As EventArgs) Handles Btn_1.Click
        If Btn_1.BackColor = Color.LightGray Then
            Btn_1.BackColor = Color.Red
        ElseIf Btn_1.BackColor = Color.Red Then
            Btn_1.BackColor = Color.Yellow
        ElseIf Btn_1.BackColor = Color.Yellow Then
            Btn_1.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_OT_REG_Php.TextChanged
        Try
            Dim Total_Earnings As Double
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
                + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
                + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception
            ' Due to initial value of textboxes is null
        End Try
    End Sub

    Private Sub Btn_2_Click(sender As Object, e As EventArgs) Handles Btn_2.Click
        If Btn_2.BackColor = Color.LightGray Then
            Btn_2.BackColor = Color.Red
        ElseIf Btn_2.BackColor = Color.Red Then
            Btn_2.BackColor = Color.Yellow
        ElseIf Btn_2.BackColor = Color.Yellow Then
            Btn_2.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_3_Click(sender As Object, e As EventArgs) Handles Btn_3.Click
        If Btn_3.BackColor = Color.LightGray Then
            Btn_3.BackColor = Color.Red
        ElseIf Btn_3.BackColor = Color.Red Then
            Btn_3.BackColor = Color.Yellow
        ElseIf Btn_3.BackColor = Color.Yellow Then
            Btn_3.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_4_Click(sender As Object, e As EventArgs) Handles Btn_4.Click
        If Btn_4.BackColor = Color.LightGray Then
            Btn_4.BackColor = Color.Red
        ElseIf Btn_4.BackColor = Color.Red Then
            Btn_4.BackColor = Color.Yellow
        ElseIf Btn_4.BackColor = Color.Yellow Then
            Btn_4.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_5_Click(sender As Object, e As EventArgs) Handles Btn_5.Click
        If Btn_5.BackColor = Color.LightGray Then
            Btn_5.BackColor = Color.Red
        ElseIf Btn_5.BackColor = Color.Red Then
            Btn_5.BackColor = Color.Yellow
        ElseIf Btn_5.BackColor = Color.Yellow Then
            Btn_5.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_6_Click(sender As Object, e As EventArgs) Handles Btn_6.Click
        If Btn_6.BackColor = Color.LightGray Then
            Btn_6.BackColor = Color.Red
        ElseIf Btn_6.BackColor = Color.Red Then
            Btn_6.BackColor = Color.Yellow
        ElseIf Btn_6.BackColor = Color.Yellow Then
            Btn_6.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_7_Click(sender As Object, e As EventArgs) Handles Btn_7.Click
        If Btn_7.BackColor = Color.LightGray Then
            Btn_7.BackColor = Color.Red
        ElseIf Btn_7.BackColor = Color.Red Then
            Btn_7.BackColor = Color.Yellow
        ElseIf Btn_7.BackColor = Color.Yellow Then
            Btn_7.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_8_Click(sender As Object, e As EventArgs) Handles Btn_8.Click
        If Btn_8.BackColor = Color.LightGray Then
            Btn_8.BackColor = Color.Red
        ElseIf Btn_8.BackColor = Color.Red Then
            Btn_8.BackColor = Color.Yellow
        ElseIf Btn_8.BackColor = Color.Yellow Then
            Btn_8.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_9_Click(sender As Object, e As EventArgs) Handles Btn_9.Click
        If Btn_9.BackColor = Color.LightGray Then
            Btn_9.BackColor = Color.Red
        ElseIf Btn_9.BackColor = Color.Red Then
            Btn_9.BackColor = Color.Yellow
        ElseIf Btn_9.BackColor = Color.Yellow Then
            Btn_9.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_10_Click(sender As Object, e As EventArgs) Handles Btn_10.Click
        If Btn_10.BackColor = Color.LightGray Then
            Btn_10.BackColor = Color.Red
        ElseIf Btn_10.BackColor = Color.Red Then
            Btn_10.BackColor = Color.Yellow
        ElseIf Btn_10.BackColor = Color.Yellow Then
            Btn_10.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_11_Click(sender As Object, e As EventArgs) Handles Btn_11.Click
        If Btn_11.BackColor = Color.LightGray Then
            Btn_11.BackColor = Color.Red
        ElseIf Btn_11.BackColor = Color.Red Then
            Btn_11.BackColor = Color.Yellow
        ElseIf Btn_11.BackColor = Color.Yellow Then
            Btn_11.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_12_Click(sender As Object, e As EventArgs) Handles Btn_12.Click
        If Btn_12.BackColor = Color.LightGray Then
            Btn_12.BackColor = Color.Red
        ElseIf Btn_12.BackColor = Color.Red Then
            Btn_12.BackColor = Color.Yellow
        ElseIf Btn_12.BackColor = Color.Yellow Then
            Btn_12.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_13_Click(sender As Object, e As EventArgs) Handles Btn_13.Click
        If Btn_13.BackColor = Color.LightGray Then
            Btn_13.BackColor = Color.Red
        ElseIf Btn_13.BackColor = Color.Red Then
            Btn_13.BackColor = Color.Yellow
        ElseIf Btn_13.BackColor = Color.Yellow Then
            Btn_13.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_14_Click(sender As Object, e As EventArgs) Handles Btn_14.Click
        If Btn_14.BackColor = Color.LightGray Then
            Btn_14.BackColor = Color.Red
        ElseIf Btn_14.BackColor = Color.Red Then
            Btn_14.BackColor = Color.Yellow
        ElseIf Btn_14.BackColor = Color.Yellow Then
            Btn_14.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_15_Click(sender As Object, e As EventArgs) Handles Btn_15.Click
        If Btn_15.BackColor = Color.LightGray Then
            Btn_15.BackColor = Color.Red
        ElseIf Btn_15.BackColor = Color.Red Then
            Btn_15.BackColor = Color.Yellow
        ElseIf Btn_15.BackColor = Color.Yellow Then
            Btn_15.BackColor = Color.LightGray
        End If

        Call Refresh_Calculation()
    End Sub

    Private Sub TxtHours12_TextChanged(sender As Object, e As EventArgs) Handles TxtHours12.TextChanged
        ' Considering Sunday & Holiday 

        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("12") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk12AM.Checked = False And Chk12PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(12)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(12)) = "SUN" Then 'Sunday

            If Btn_12.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk12AM.Checked = True And Chk12PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 8 ' assuming no undertime
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = 0

                ElseIf Chk12AM.Checked = False And Chk12PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 8 ' assuming no undertime
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 8 ' assuming no undertime
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = 0

                ElseIf Chk12AM.Checked = True And Chk12PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 16 ' assuming no undertime
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 8
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 8
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = 0
                End If

            ElseIf Btn_12.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk12AM.Checked = True And Chk12PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0 ' assuming no undertime
                    Txt_REG_SH_12.Text = 8
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_LH_12.Text = 0

                ElseIf Chk12AM.Checked = False And Chk12PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0 ' assuming no undertime
                    Txt_REG_SH_12.Text = 8
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 8
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_LH_12.Text = 0

                ElseIf Chk12AM.Checked = True And Chk12PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 8
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 8
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_LH_12.Text = 0

                End If

            ElseIf Btn_12.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk12AM.Checked = True And Chk12PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 8

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = CDbl(TxtHours12.Text) - 8

                ElseIf Chk12AM.Checked = False And Chk12PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 8

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 8

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = CDbl(TxtHours12.Text) - 8

                ElseIf Chk12AM.Checked = True And Chk12PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 16

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 8

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = CDbl(TxtHours12.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_12.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk12AM.Checked = True And Chk12PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_12.Text = 8
                    Txt_REG_SUN_12.Text = 0 ' assuming no undertime
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = 0

                ElseIf Chk12AM.Checked = False And Chk12PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_12.Text = 8
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 8
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = 0

                ElseIf Chk12AM.Checked = True And Chk12PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_12.Text = 16
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 8
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 8
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = 0
                End If

            ElseIf Btn_12.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk12AM.Checked = True And Chk12PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0 ' assuming no undertime
                    Txt_REG_SH_12.Text = 8
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_LH_12.Text = 0

                ElseIf Chk12AM.Checked = False And Chk12PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0 ' assuming no undertime
                    Txt_REG_SH_12.Text = 8
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 8
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = CDbl(TxtHours12.Text) - 8
                    Txt_OT_LH_12.Text = 0

                ElseIf Chk12AM.Checked = True And Chk12PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 16
                    Txt_REG_LH_12.Text = 0

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 8
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 8
                    Txt_OT_LH_12.Text = 0

                End If

            ElseIf Btn_12.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk12AM.Checked = True And Chk12PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 8

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 0

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = CDbl(TxtHours12.Text) - 8

                ElseIf Chk12AM.Checked = False And Chk12PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 8

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 8

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = CDbl(TxtHours12.Text) - 8

                ElseIf Chk12AM.Checked = True And Chk12PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_12.Text = 0
                    Txt_REG_SUN_12.Text = 0
                    Txt_REG_SH_12.Text = 0
                    Txt_REG_LH_12.Text = 16

                    Txt_ND_REG_12.Text = 0
                    Txt_ND_SUN_12.Text = 0
                    Txt_ND_SH_12.Text = 0
                    Txt_ND_LH_12.Text = 8

                    Txt_OT_REG_12.Text = 0
                    Txt_OT_SUN_12.Text = 0
                    Txt_OT_SH_12.Text = 0
                    Txt_OT_LH_12.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub

    Private Sub TxtHours13_TextChanged(sender As Object, e As EventArgs) Handles TxtHours13.TextChanged
        ' Considering Sunday & Holiday 


        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("13") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk13AM.Checked = False And Chk13PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(13)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(13)) = "SUN" Then 'Sunday

            If Btn_13.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk13AM.Checked = True And Chk13PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 8 ' assuming no undertime
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = 0

                ElseIf Chk13AM.Checked = False And Chk13PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 8 ' assuming no undertime
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 8 ' assuming no undertime
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = 0

                ElseIf Chk13AM.Checked = True And Chk13PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 16 ' assuming no undertime
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 8
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 8
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = 0
                End If

            ElseIf Btn_13.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk13AM.Checked = True And Chk13PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0 ' assuming no undertime
                    Txt_REG_SH_13.Text = 8
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_LH_13.Text = 0

                ElseIf Chk13AM.Checked = False And Chk13PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0 ' assuming no undertime
                    Txt_REG_SH_13.Text = 8
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 8
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_LH_13.Text = 0

                ElseIf Chk13AM.Checked = True And Chk13PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 8
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 8
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_LH_13.Text = 0

                End If

            ElseIf Btn_13.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk13AM.Checked = True And Chk13PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 8

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = CDbl(TxtHours13.Text) - 8

                ElseIf Chk13AM.Checked = False And Chk13PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 8

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 8

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = CDbl(TxtHours13.Text) - 8

                ElseIf Chk13AM.Checked = True And Chk13PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 16

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 8

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = CDbl(TxtHours13.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_13.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk13AM.Checked = True And Chk13PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_13.Text = 8
                    Txt_REG_SUN_13.Text = 0 ' assuming no undertime
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = 0

                ElseIf Chk13AM.Checked = False And Chk13PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_13.Text = 8
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 8
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = 0

                ElseIf Chk13AM.Checked = True And Chk13PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_13.Text = 16
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 8
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 8
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = 0
                End If

            ElseIf Btn_13.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk13AM.Checked = True And Chk13PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0 ' assuming no undertime
                    Txt_REG_SH_13.Text = 8
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_LH_13.Text = 0

                ElseIf Chk13AM.Checked = False And Chk13PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0 ' assuming no undertime
                    Txt_REG_SH_13.Text = 8
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 8
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = CDbl(TxtHours13.Text) - 8
                    Txt_OT_LH_13.Text = 0

                ElseIf Chk13AM.Checked = True And Chk13PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 16
                    Txt_REG_LH_13.Text = 0

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 8
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 8
                    Txt_OT_LH_13.Text = 0

                End If

            ElseIf Btn_13.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk13AM.Checked = True And Chk13PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 8

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 0

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = CDbl(TxtHours13.Text) - 8

                ElseIf Chk13AM.Checked = False And Chk13PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 8

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 8

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = CDbl(TxtHours13.Text) - 8

                ElseIf Chk13AM.Checked = True And Chk13PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_13.Text = 0
                    Txt_REG_SUN_13.Text = 0
                    Txt_REG_SH_13.Text = 0
                    Txt_REG_LH_13.Text = 16

                    Txt_ND_REG_13.Text = 0
                    Txt_ND_SUN_13.Text = 0
                    Txt_ND_SH_13.Text = 0
                    Txt_ND_LH_13.Text = 8

                    Txt_OT_REG_13.Text = 0
                    Txt_OT_SUN_13.Text = 0
                    Txt_OT_SH_13.Text = 0
                    Txt_OT_LH_13.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub

    Private Sub TxtHours14_TextChanged(sender As Object, e As EventArgs) Handles TxtHours14.TextChanged
        ' Considering Sunday & Holiday 


        Call Compute_Total_Hours_Rendered()
        Call Set_ForeColor("14") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk14AM.Checked = False And Chk14PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(14)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(14)) = "SUN" Then 'Sunday

            If Btn_14.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk14AM.Checked = True And Chk14PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 8 ' assuming no undertime
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = 0

                ElseIf Chk14AM.Checked = False And Chk14PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 8 ' assuming no undertime
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 8 ' assuming no undertime
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = 0

                ElseIf Chk14AM.Checked = True And Chk14PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 16 ' assuming no undertime
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 8
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 8
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = 0
                End If

            ElseIf Btn_14.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk14AM.Checked = True And Chk14PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0 ' assuming no undertime
                    Txt_REG_SH_14.Text = 8
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_LH_14.Text = 0

                ElseIf Chk14AM.Checked = False And Chk14PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0 ' assuming no undertime
                    Txt_REG_SH_14.Text = 8
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 8
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_LH_14.Text = 0

                ElseIf Chk14AM.Checked = True And Chk14PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 8
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 8
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_LH_14.Text = 0

                End If

            ElseIf Btn_14.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk14AM.Checked = True And Chk14PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 8

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = CDbl(TxtHours14.Text) - 8

                ElseIf Chk14AM.Checked = False And Chk14PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 8

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 8

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = CDbl(TxtHours14.Text) - 8

                ElseIf Chk14AM.Checked = True And Chk14PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 16

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 8

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = CDbl(TxtHours14.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_14.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk14AM.Checked = True And Chk14PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_14.Text = 8
                    Txt_REG_SUN_14.Text = 0 ' assuming no undertime
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = 0

                ElseIf Chk14AM.Checked = False And Chk14PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_14.Text = 8
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 8
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = 0

                ElseIf Chk14AM.Checked = True And Chk14PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_14.Text = 16
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 8
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 8
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = 0
                End If

            ElseIf Btn_14.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk14AM.Checked = True And Chk14PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0 ' assuming no undertime
                    Txt_REG_SH_14.Text = 8
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_LH_14.Text = 0

                ElseIf Chk14AM.Checked = False And Chk14PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0 ' assuming no undertime
                    Txt_REG_SH_14.Text = 8
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 8
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = CDbl(TxtHours14.Text) - 8
                    Txt_OT_LH_14.Text = 0

                ElseIf Chk14AM.Checked = True And Chk14PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 16
                    Txt_REG_LH_14.Text = 0

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 8
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 8
                    Txt_OT_LH_14.Text = 0

                End If

            ElseIf Btn_14.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk14AM.Checked = True And Chk14PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 8

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 0

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = CDbl(TxtHours14.Text) - 8

                ElseIf Chk14AM.Checked = False And Chk14PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 8

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 8

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = CDbl(TxtHours14.Text) - 8

                ElseIf Chk14AM.Checked = True And Chk14PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_14.Text = 0
                    Txt_REG_SUN_14.Text = 0
                    Txt_REG_SH_14.Text = 0
                    Txt_REG_LH_14.Text = 16

                    Txt_ND_REG_14.Text = 0
                    Txt_ND_SUN_14.Text = 0
                    Txt_ND_SH_14.Text = 0
                    Txt_ND_LH_14.Text = 8

                    Txt_OT_REG_14.Text = 0
                    Txt_OT_SUN_14.Text = 0
                    Txt_OT_SH_14.Text = 0
                    Txt_OT_LH_14.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()

    End Sub

    Private Sub TxtHours15_TextChanged(sender As Object, e As EventArgs) Handles TxtHours15.TextChanged
        ' Considering Sunday & Holiday 

        Call Compute_Total_Hours_Rendered()

        Call Set_ForeColor("15") ' for TxtHours


        ' Conditions for filling out the hours rendered accordingly

        If Chk15AM.Checked = False And Chk15PM.Checked = False Then ' Zero Hours (Absent or  RD) 
            Clear_Textbox_Hours(15)
            'Exit Sub ' Nothing to compute so just exit
        End If

        If UCase(GlobalVariables.sDay(15)) = "SUN" Then 'Sunday

            If Btn_15.BackColor = Color.LightGray Then ' Sunday +  Non-Holiday

                If Chk15AM.Checked = True And Chk15PM.Checked = False Then ' Sunday Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 8 ' assuming no undertime
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = 0

                ElseIf Chk15AM.Checked = False And Chk15PM.Checked = True Then ' Sunday + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 8 ' assuming no undertime
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 8 ' assuming no undertime
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = 0

                ElseIf Chk15AM.Checked = True And Chk15PM.Checked = True Then ' Sunday Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 16 ' assuming no undertime
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 8
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 8
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = 0
                End If

            ElseIf Btn_15.BackColor = Color.Yellow Then ' Sunday + Special Holiday

                If Chk15AM.Checked = True And Chk15PM.Checked = False Then ' Sunday + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0 ' assuming no undertime
                    Txt_REG_SH_15.Text = 8
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_LH_15.Text = 0

                ElseIf Chk15AM.Checked = False And Chk15PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0 ' assuming no undertime
                    Txt_REG_SH_15.Text = 8
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 8
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_LH_15.Text = 0

                ElseIf Chk15AM.Checked = True And Chk15PM.Checked = True Then ' Sunday + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 8
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 8
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_LH_15.Text = 0

                End If

            ElseIf Btn_15.BackColor = Color.Red Then ' Sunday + Legal Holiday

                If Chk15AM.Checked = True And Chk15PM.Checked = False Then ' Sunday + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 8

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = CDbl(TxtHours15.Text) - 8

                ElseIf Chk15AM.Checked = False And Chk15PM.Checked = True Then ' Sunday + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 8

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 8

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = CDbl(TxtHours15.Text) - 8

                ElseIf Chk15AM.Checked = True And Chk15PM.Checked = True Then ' Sunday + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 16

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 8

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = CDbl(TxtHours15.Text) - 16

                End If
            End If

        Else ' Regular Day ' ======================================= Regular Day =======================================================

            If Btn_15.BackColor = Color.LightGray Then ' Regular Day +  Non-Holiday

                If Chk15AM.Checked = True And Chk15PM.Checked = False Then ' Regular Day Non_holiday Morning Shift

                    'allocate hours
                    Txt_REG_15.Text = 8
                    Txt_REG_SUN_15.Text = 0 ' assuming no undertime
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = 0

                ElseIf Chk15AM.Checked = False And Chk15PM.Checked = True Then ' Regular Day + Non_holiday + Night Shift

                    'allocate hours
                    Txt_REG_15.Text = 8
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 8
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = 0

                ElseIf Chk15AM.Checked = True And Chk15PM.Checked = True Then ' Regular Day Non_holiday 24 Hours

                    'allocate hours
                    Txt_REG_15.Text = 16
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 8
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 8
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = 0
                End If

            ElseIf Btn_15.BackColor = Color.Yellow Then ' Regular Day + Special Holiday

                If Chk15AM.Checked = True And Chk15PM.Checked = False Then ' Regular Day + Special Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0 ' assuming no undertime
                    Txt_REG_SH_15.Text = 8
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_LH_15.Text = 0

                ElseIf Chk15AM.Checked = False And Chk15PM.Checked = True Then ' Sunday + Special Holiday at Night Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0 ' assuming no undertime
                    Txt_REG_SH_15.Text = 8
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 8
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = CDbl(TxtHours15.Text) - 8
                    Txt_OT_LH_15.Text = 0

                ElseIf Chk15AM.Checked = True And Chk15PM.Checked = True Then ' Regular Day + Special Holiday 24 Hours

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 16
                    Txt_REG_LH_15.Text = 0

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 8
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 8
                    Txt_OT_LH_15.Text = 0

                End If

            ElseIf Btn_15.BackColor = Color.Red Then ' Regular Day + Legal Holiday

                If Chk15AM.Checked = True And Chk15PM.Checked = False Then ' Regular Day + Legal Holiday at Morning Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 8

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 0

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = CDbl(TxtHours15.Text) - 8

                ElseIf Chk15AM.Checked = False And Chk15PM.Checked = True Then ' Regular Day + Legal Holiday at Night Shift

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 8

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 8

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = CDbl(TxtHours15.Text) - 8

                ElseIf Chk15AM.Checked = True And Chk15PM.Checked = True Then ' Regular Day + Legal Holiday 24 Hours

                    'allocate hours
                    Txt_REG_15.Text = 0
                    Txt_REG_SUN_15.Text = 0
                    Txt_REG_SH_15.Text = 0
                    Txt_REG_LH_15.Text = 16

                    Txt_ND_REG_15.Text = 0
                    Txt_ND_SUN_15.Text = 0
                    Txt_ND_SH_15.Text = 0
                    Txt_ND_LH_15.Text = 8

                    Txt_OT_REG_15.Text = 0
                    Txt_OT_SUN_15.Text = 0
                    Txt_OT_SH_15.Text = 0
                    Txt_OT_LH_15.Text = 8

                End If
            End If

        End If

        Dim sHoliday As String

        If Btn_1.BackColor = Color.LightGray Then
            sHoliday = "NA"
        ElseIf Btn_1.BackColor = Color.Red Then
            sHoliday = "LH"
        ElseIf Btn_1.BackColor = Color.Yellow Then
            sHoliday = "SH"
        End If

        Call Calculate_Total_PHP()
        'Call Get_Hours_Breakdown()
    End Sub



    Private Sub Txt_Total_REG_REG_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_REG_REG_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_REG_SUN_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_REG_SUN_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_REG_SH_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_REG_SH_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_ND_REG_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_ND_REG_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_ND_SUN_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_ND_SUN_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_ND_SH_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_ND_SH_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_ND_LH_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_ND_LH_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_OT_SUN_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_OT_SUN_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_OT_SH_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_OT_SH_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt_Total_OT_LH_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_OT_LH_Php.TextChanged
        Dim Total_Earnings As Double
        Try
            Total_Earnings = CDbl(Txt_Total_REG_REG_Php.Text) + CDbl(Txt_Total_REG_SUN_Php.Text) + CDbl(Txt_Total_REG_SH_Php.Text) + CDbl(Txt_Total_REG_LH_Php.Text) _
            + CDbl(Txt_Total_ND_REG_Php.Text) + CDbl(Txt_Total_ND_SUN_Php.Text) + CDbl(Txt_Total_ND_SH_Php.Text) + CDbl(Txt_Total_ND_LH_Php.Text) _
            + CDbl(Txt_Total_OT_REG_Php.Text) + CDbl(Txt_Total_OT_SUN_Php.Text) + CDbl(Txt_Total_OT_SH_Php.Text) + CDbl(Txt_Total_OT_LH_Php.Text)
            Txt_Total_Earnings.Text = Total_Earnings.ToString("0,00.00")
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Txt_Total_Earnings_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_Earnings.TextChanged
        Call Compute_Net_Pay()
    End Sub

    Private Sub Btn_Reliever_Click(sender As Object, e As EventArgs) Handles Btn_Reliever.Click
        GlobalVariables.sReliever = True
        FRM_CLIENT_REG.ShowDialog()
        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click


        If GlobalVariables.DTR_INPUT_SAVED = "" Then
            Dim MsgResp As String
            MsgResp = MsgBox("Are you sure you want to close this form without saving?", vbQuestion + vbYesNo, "Close?")
            If MsgResp = vbYes Then
                GlobalVariables.DTR_INPUT_SAVED = ""
                Me.Close()
            End If

        End If
    End Sub



    Private Sub Txt_SSS_Contri_TextChanged(sender As Object, e As EventArgs) Handles Txt_SSS_Contri.TextChanged
        Call Calculate_Total_Deduction()
        Call Compute_Net_Pay()
    End Sub

    Private Sub Txt_SSS_Sal_Loan_TextChanged(sender As Object, e As EventArgs) Handles Txt_SSS_Sal_Loan.TextChanged
        Call Calculate_Total_Deduction()
        Call Compute_Net_Pay()
    End Sub

    Private Sub Txt_SSS_Cal_Loan_TextChanged(sender As Object, e As EventArgs) Handles Txt_SSS_Cal_Loan.TextChanged
        Call Calculate_Total_Deduction()
        Call Compute_Net_Pay()
    End Sub

    Private Sub Txt_PI_Contri_TextChanged(sender As Object, e As EventArgs) Handles Txt_PI_Contri.TextChanged
        Call Calculate_Total_Deduction()
        Call Compute_Net_Pay()
    End Sub

    Private Sub Txt_PI_Sal_Loan_TextChanged(sender As Object, e As EventArgs) Handles Txt_PI_Sal_Loan.TextChanged
        Call Calculate_Total_Deduction()
        Call Compute_Net_Pay()
    End Sub

    Private Sub Txt_PI_Cal_Loan_TextChanged(sender As Object, e As EventArgs) Handles Txt_PI_Cal_Loan.TextChanged
        Call Calculate_Total_Deduction()
        Call Compute_Net_Pay()
    End Sub

    Private Sub Txt_PH_Contri_TextChanged(sender As Object, e As EventArgs) Handles Txt_PH_Contri.TextChanged
        Call Calculate_Total_Deduction()
        Call Compute_Net_Pay()
    End Sub

    Private Sub Txt_Cashbond_TextChanged(sender As Object, e As EventArgs) Handles Txt_Cashbond.TextChanged
        Call Calculate_Total_Deduction()
        Call Compute_Net_Pay()
    End Sub

    Private Sub Btn_Manual_Deduction_Click(sender As Object, e As EventArgs) Handles Btn_Manual_Deduction.Click

        'If Mid(GlobalVariables.sPayroll_Cutoff, 5, 2) = "16" Then ' Contributions are being deducted only every month end payroll
        Call Get_Employee_Contributions_as_Deductions(GlobalVariables.Selected_Client_ID)
        ' End If
    End Sub

    Private Sub Btn_Calculate_Click(sender As Object, e As EventArgs) Handles Btn_Calculate.Click

        'For i = 1 To 15 ' Make this a function later
        '    Me.Controls("TxtHours" & i).Text = "0"
        '    Me.Controls("TxtHours" & i).Refresh()

        'Next i


        Txt_PI_Contri.Text = 200

        ' Take the values from Global Variable ( loop this later )
        For i = 1 To 15 ' Make this a function later
            Dim controlName As String = "Chk" & i & "AM"
            Dim ctrl As Control = Me.Controls(controlName)
            If TypeOf ctrl Is CheckBox Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                chk.Checked = True
            End If
        Next i


        Call Get_Hours_Breakdown()



    End Sub



    Private Sub TxtAllowance_TextChanged(sender As Object, e As EventArgs) Handles TxtAllowance.TextChanged
        Call Compute_Net_Pay()
    End Sub

    Private Sub Txt_Total_OT_SUN_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_OT_SUN.TextChanged

    End Sub

    Private Sub TxtTotal_Hours_TextChanged(sender As Object, e As EventArgs) Handles TxtTotal_Hours.TextChanged

    End Sub

    Private Sub Txt_Total_REG_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_REG.TextChanged

    End Sub

    Private Sub Txt_REG_SUN_1_TextChanged(sender As Object, e As EventArgs) Handles Txt_REG_SUN_1.TextChanged

    End Sub

    Private Sub Txt_REG_1_TextChanged(sender As Object, e As EventArgs) Handles Txt_REG_1.TextChanged

    End Sub

    Private Sub Txt_Total_REG_LH_Php_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_REG_LH_Php.TextChanged

    End Sub

    Private Sub Txt_Total_REG_LH_TextChanged(sender As Object, e As EventArgs) Handles Txt_Total_REG_LH.TextChanged

    End Sub

    Private Sub Txt_REG_LH_15_TextChanged(sender As Object, e As EventArgs) Handles Txt_REG_LH_15.TextChanged

    End Sub
End Class