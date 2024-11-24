Imports System.Data.OleDb
Module Mod_FRM_DTR_INPUT_1_15


    


    Public Sub Compute_Total_Days()

        Dim iTotal_Days As Integer

        iTotal_Days = 0

        With FRM_DTR_INPUT
            For i = 1 To 15
                iTotal_Days = iTotal_Days + GlobalVariables.No_Of_Days(i)
            Next
            .Lbl_Total_Days.Text = iTotal_Days
        End With


    End Sub


    Public Sub Get_Hours_Breakdown()

        Dim Total_Hours_REG, Total_Hours_REG_SUN, Total_Hours_REG_SH, Total_Hours_REG_LH As Double
        Dim Total_Hours_ND, Total_Hours_ND_SUN, Total_Hours_ND_SH, Total_Hours_ND_LH As Double
        Dim Total_Hours_OT, Total_Hours_OT_SUN, Total_Hours_OT_SH, Total_Hours_OT_LH As Double

        With FRM_DTR_INPUT


            Try
                For i = 1 To 15

                    Total_Hours_REG = Total_Hours_REG + CDbl(.Controls("Txt_REG_" & i.ToString).Text)
                    .Txt_Total_REG.Text = Total_Hours_REG
                    Total_Hours_REG_SUN = Total_Hours_REG_SUN + CDbl(.Controls("Txt_REG_SUN_" & i.ToString).Text)
                    .Txt_Total_REG_SUN.Text = Total_Hours_REG_SUN
                    Total_Hours_REG_SH = Total_Hours_REG_SH + CDbl(.Controls("Txt_REG_SH_" & i.ToString).Text)
                    .Txt_Total_REG_SH.Text = Total_Hours_REG_SH
                    Total_Hours_REG_LH = Total_Hours_REG_LH + CDbl(.Controls("Txt_REG_LH_" & i.ToString).Text)
                    .Txt_Total_REG_LH.Text = Total_Hours_REG_LH

                    Total_Hours_ND = Total_Hours_ND + CDbl(.Controls("Txt_ND_REG_" & i.ToString).Text)
                    .Txt_Total_ND_REG.Text = Total_Hours_ND
                    Total_Hours_ND_SUN = Total_Hours_ND_SUN + CDbl(.Controls("Txt_ND_SUN_" & i.ToString).Text)
                    .Txt_Total_ND_SUN.Text = Total_Hours_ND_SUN
                    Total_Hours_ND_SH = Total_Hours_ND_SH + CDbl(.Controls("Txt_ND_SH_" & i.ToString).Text)
                    .Txt_Total_ND_SH.Text = Total_Hours_ND_SH
                    Total_Hours_ND_LH = Total_Hours_ND_LH + CDbl(.Controls("Txt_ND_LH_" & i.ToString).Text)
                    .Txt_Total_ND_LH.Text = Total_Hours_ND_LH

                    Total_Hours_OT = Total_Hours_OT + CDbl(.Controls("Txt_OT_REG_" & i.ToString).Text)
                    .Txt_Total_OT_REG.Text = Total_Hours_OT
                    Total_Hours_OT_SUN = Total_Hours_OT_SUN + CDbl(.Controls("Txt_OT_SUN_" & i.ToString).Text)
                    .Txt_Total_OT_SUN.Text = Total_Hours_OT_SUN
                    Total_Hours_OT_SH = Total_Hours_OT_SH + CDbl(.Controls("Txt_OT_SH_" & i.ToString).Text)
                    .Txt_Total_OT_SH.Text = Total_Hours_OT_SH
                    Total_Hours_OT_LH = Total_Hours_OT_LH + CDbl(.Controls("Txt_OT_LH_" & i.ToString).Text)
                    .Txt_Total_OT_LH.Text = Total_Hours_OT_LH
                Next

            Catch ex As Exception

            End Try

        End With

    End Sub


    Public Sub Refresh_Calculation() ' Re-Fresh Checkboxes - Check Uncheck

        With FRM_DTR_INPUT

            If .Chk1AM.Checked = True Then
                .Chk1AM.Checked = False
                .Chk1AM.Checked = True
            Else
                .Chk1AM.Checked = True
                .Chk1AM.Checked = False
            End If

            If .Chk2AM.Checked = True Then
                .Chk2AM.Checked = False
                .Chk2AM.Checked = True
            Else
                .Chk2AM.Checked = True
                .Chk2AM.Checked = False
            End If

            If .Chk3AM.Checked = True Then
                .Chk3AM.Checked = False
                .Chk3AM.Checked = True
            Else
                .Chk3AM.Checked = True
                .Chk3AM.Checked = False
            End If

            If .Chk4AM.Checked = True Then
                .Chk4AM.Checked = False
                .Chk4AM.Checked = True
            Else
                .Chk4AM.Checked = True
                .Chk4AM.Checked = False
            End If

            If .Chk5AM.Checked = True Then
                .Chk5AM.Checked = False
                .Chk5AM.Checked = True
            Else
                .Chk5AM.Checked = True
                .Chk5AM.Checked = False
            End If

            If .Chk6AM.Checked = True Then
                .Chk6AM.Checked = False
                .Chk6AM.Checked = True
            Else
                .Chk6AM.Checked = True
                .Chk6AM.Checked = False
            End If

            If .Chk7AM.Checked = True Then
                .Chk7AM.Checked = False
                .Chk7AM.Checked = True
            Else
                .Chk7AM.Checked = True
                .Chk7AM.Checked = False
            End If

            If .Chk8AM.Checked = True Then
                .Chk8AM.Checked = False
                .Chk8AM.Checked = True
            Else
                .Chk8AM.Checked = True
                .Chk8AM.Checked = False
            End If

            If .Chk9AM.Checked = True Then
                .Chk9AM.Checked = False
                .Chk9AM.Checked = True
            Else
                .Chk9AM.Checked = True
                .Chk9AM.Checked = False
            End If


            If .Chk10AM.Checked = True Then
                .Chk10AM.Checked = False
                .Chk10AM.Checked = True
            Else
                .Chk10AM.Checked = True
                .Chk10AM.Checked = False
            End If


            If .Chk11AM.Checked = True Then
                .Chk11AM.Checked = False
                .Chk11AM.Checked = True
            Else
                .Chk11AM.Checked = True
                .Chk11AM.Checked = False
            End If


            If .Chk12AM.Checked = True Then
                .Chk12AM.Checked = False
                .Chk12AM.Checked = True
            Else
                .Chk12AM.Checked = True
                .Chk12AM.Checked = False
            End If


            If .Chk13AM.Checked = True Then
                .Chk13AM.Checked = False
                .Chk13AM.Checked = True
            Else
                .Chk13AM.Checked = True
                .Chk13AM.Checked = False
            End If


            If .Chk14AM.Checked = True Then
                .Chk14AM.Checked = False
                .Chk14AM.Checked = True
            Else
                .Chk14AM.Checked = True
                .Chk14AM.Checked = False
            End If


            If .Chk15AM.Checked = True Then
                .Chk15AM.Checked = False
                .Chk15AM.Checked = True
            Else
                .Chk15AM.Checked = True
                .Chk15AM.Checked = False
            End If

        End With



    End Sub




    Public Sub Calculate_Total_PHP()


        With FRM_DTR_INPUT
            Try
                Dim Total_REG_REG_Php, Total_REG_SUN_Php, Total_REG_SH_Php, Total_REG_LH_Php As Double
                Dim Total_ND_REG_Php, Total_ND_SUN_Php, Total_ND_SH_Php, Total_ND_LH_Php As Double
                Dim Total_OT_REG_Php, Total_OT_SUN_Php, Total_OT_SH_Php, Total_OT_LH_Php As Double

                ' Calculate Earnings per Hourly rate to consider Reliever ( difference in wage per client )
                For i = 1 To 15
                    ' REG
                    Total_REG_REG_Php = Total_REG_REG_Php + .Controls("Txt_REG_" & i).Text * .Controls("TxtWage" & i).Text
                    Total_REG_SUN_Php = Total_REG_SUN_Php + .Controls("Txt_REG_SUN_" & i).Text * .Controls("TxtWage" & i).Text * 1.3
                    Total_REG_SH_Php = Total_REG_SH_Php + .Controls("Txt_REG_SH_" & i).Text * .Controls("TxtWage" & i).Text * 1.3
                    Total_REG_LH_Php = Total_REG_LH_Php + .Controls("Txt_REG_LH_" & i).Text * .Controls("TxtWage" & i).Text * 2
                    'ND
                    Total_ND_REG_Php = Total_ND_REG_Php + .Controls("Txt_ND_REG_" & i).Text * (.Controls("TxtWage" & i).Text * 0.1)
                    Total_ND_SUN_Php = Total_ND_SUN_Php + .Controls("Txt_ND_SUN_" & i).Text * (.Controls("TxtWage" & i).Text * 0.1) * 1.3
                    Total_ND_SH_Php = Total_ND_SH_Php + .Controls("Txt_ND_SH_" & i).Text * (.Controls("TxtWage" & i).Text * 0.1) * 1.3
                    Total_ND_LH_Php = Total_ND_LH_Php + .Controls("Txt_ND_LH_" & i).Text * (.Controls("TxtWage" & i).Text * 0.1) * 2
                    'OT
                    Total_OT_REG_Php = Total_OT_REG_Php + .Controls("Txt_OT_REG_" & i).Text * .Controls("TxtWage" & i).Text * 1.25
                    Total_OT_SUN_Php = Total_OT_SUN_Php + .Controls("Txt_OT_SUN_" & i).Text * .Controls("TxtWage" & i).Text * 1.3 * 1.3
                    Total_OT_SH_Php = Total_OT_SH_Php + .Controls("Txt_OT_SH_" & i).Text * .Controls("TxtWage" & i).Text * 1.3 * 1.3
                    Total_OT_LH_Php = Total_OT_LH_Php + .Controls("Txt_OT_LH_" & i).Text * .Controls("TxtWage" & i).Text * 1.3 * 2


                Next i

                ' REG
                .Txt_Total_REG_REG_Php.Text = CDbl(Total_REG_REG_Php.ToString("0,00.00"))
                .Txt_Total_REG_SUN_Php.Text = CDbl(Total_REG_SUN_Php.ToString("0,00.00"))
                .Txt_Total_REG_SH_Php.Text = CDbl(Total_REG_SH_Php.ToString("0,00.00"))
                .Txt_Total_REG_LH_Php.Text = CDbl(Total_REG_LH_Php.ToString("0,00.00"))
                ' ND
                .Txt_Total_ND_REG_Php.Text = CDbl(Total_ND_REG_Php.ToString("0,00.00"))
                .Txt_Total_ND_SUN_Php.Text = CDbl(Total_ND_SUN_Php.ToString("0,00.00"))
                .Txt_Total_ND_SH_Php.Text = CDbl(Total_ND_SH_Php.ToString("0,00.00"))
                .Txt_Total_ND_LH_Php.Text = CDbl(Total_ND_LH_Php.ToString("0,00.00"))
                ' OT
                .Txt_Total_OT_REG_Php.Text = CDbl(Total_OT_REG_Php.ToString("0,00.00"))
                .Txt_Total_OT_SUN_Php.Text = CDbl(Total_OT_SUN_Php.ToString("0,00.00"))
                .Txt_Total_OT_SH_Php.Text = CDbl(Total_OT_SH_Php.ToString("0,00.00"))
                .Txt_Total_OT_LH_Php.Text = CDbl(Total_OT_LH_Php.ToString("0,00.00"))

            Catch ex As Exception
                '    ' Due to initial value of textboxes is null
            End Try

        End With



    End Sub


    Public Sub Get_Reliever_Record()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        SQL = "SELECT A.RELIEVER_ID, A.DTR_NO,A.CLIENT_ID,A.PAYROLL_YEAR,A.PAYROLL_PERIOD,A.DAY_RELIEVED,A.HOURS_RENDERED, B.DAILY_WAGE"
        SQL = SQL & " FROM TBL_DTR_RELIEVER A, TBL_CLIENT_SUB B"
        SQL = SQL & " WHERE A.CLIENT_ID = B.CLIENT_ID"


        da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
        da.Fill(dt)

        If dt.Rows.Count > 0 Then ' SHOW DATA

            Dim myRow As DataRow
            For Each myRow In dt.Rows
                With FRM_DTR_INPUT

                    '.Lbl_Company_ID.Text = myRow.Item(0) ' Company_ID
                    '.Lbl_Detachment.Text = myRow.Item(4) ' Detachment
                    ''.Lbl_Detachment_Address.Text = myRow.Item(5) ' Address
                    '.Lbl_Daily_Wage.Text = myRow.Item(6) ' Daily Wage  
                    '.Lbl_PerHour.Text = CInt(.Lbl_Daily_Wage.Text) / 8
                    '.Lbl_Name.Text = myRow.Item(1) & ", " & myRow.Item(2) & " " & Left(myRow.Item(3), 1) ' Name

                End With
            Next
        Else

        End If

        GlobalVariables.GlobalCon.Close()



    End Sub


    Public Sub Set_ForeColor(sDayNo As String)
        Try
            With FRM_DTR_INPUT

                If .Controls("TxtHours" & sDayNo).Text = 24 Then ' Just to emphasize 24 working hours rendered
                    .Controls("TxtHours" & sDayNo).BackColor = Color.LightBlue
                ElseIf .Controls("TxtHours" & sDayNo).Text < 8 Then
                    .Controls("TxtHours" & sDayNo).BackColor = Color.Red
                Else
                    .Controls("TxtHours" & sDayNo).BackColor = Color.White
                End If

            End With

        Catch ex As Exception

        End Try

    End Sub



    Public Sub Uncheck_All_Checkboxes()

        With FRM_DTR_INPUT

            .Chk1AM.Checked = False
            .Chk2AM.Checked = False
            .Chk3AM.Checked = False
            .Chk4AM.Checked = False
            .Chk5AM.Checked = False
            .Chk6AM.Checked = False
            .Chk7AM.Checked = False
            .Chk8AM.Checked = False
            .Chk9AM.Checked = False
            .Chk10AM.Checked = False
            .Chk11AM.Checked = False
            .Chk12AM.Checked = False
            .Chk13AM.Checked = False
            .Chk14AM.Checked = False
            .Chk15AM.Checked = False

            .Chk1PM.Checked = False
            .Chk2PM.Checked = False
            .Chk3PM.Checked = False
            .Chk4PM.Checked = False
            .Chk5PM.Checked = False
            .Chk6PM.Checked = False
            .Chk7PM.Checked = False
            .Chk8PM.Checked = False
            .Chk9PM.Checked = False
            .Chk10PM.Checked = False
            .CHK11PM.Checked = False
            .Chk12PM.Checked = False
            .Chk13PM.Checked = False
            .Chk14PM.Checked = False
            .Chk15PM.Checked = False

        End With

    End Sub



    Public Sub Compute_Net_Pay()

        Dim iNetpay As Double

        Try
            With FRM_DTR_INPUT

                iNetpay = CDbl(.Txt_Total_Earnings.Text) + CDbl(.TxtAllowance.Text) - CDbl(.Lbl_Total_Deduction.Text)
                .Lbl_Netpay.Text = iNetpay.ToString("#,###.00")

            End With
        Catch ex As Exception
            ' Having an error when there is an empty boxes / null values
        End Try

    End Sub
    Public Sub Compute_Total_Hours_Rendered()


        Try
            With FRM_DTR_INPUT

                ' Total Hours
                .TxtTotal_Hours.Text = CDbl(.TxtHours1.Text) + CDbl(.TxtHours2.Text) + CDbl(.TxtHours3.Text) + CDbl(.TxtHours4.Text) + CDbl(.TxtHours5.Text) + CDbl(.TxtHours6.Text) + CDbl(.TxtHours7.Text) _
                + CDbl(.TxtHours8.Text) + CDbl(.TxtHours9.Text) + CDbl(.TxtHours10.Text) + CDbl(.TxtHours11.Text) + CDbl(.TxtHours12.Text) + CDbl(.TxtHours13.Text) + CDbl(.TxtHours14.Text) + CDbl(.TxtHours15.Text)

            End With
        Catch ex As Exception
            ' Having an error due to initial value of txthours equal to null during first change event call (@ loading of form)
        End Try

    End Sub



    Public Function Get_Payroll_Period()

        Dim MyDate As Date = Now
        Dim DaysInMonth As Integer = Date.DaysInMonth(MyDate.Year, MyDate.Month)
        'Dim LastDayInMonthDate As Date = New Date(MyDate.Year, MyDate.Month, DaysInMonth)


        If MyDate.Day <= 15 Then
            Return Format(MyDate, "MMMM") & " 1-15"
        Else
            Return Format(MyDate, "MMMM") & " 16" & "-" & DaysInMonth
        End If

    End Function

    Public Function Get_Number_of_Days()

        Dim MyDate As Date = Now
        Dim DaysInMonth As Integer = Date.DaysInMonth(MyDate.Year, MyDate.Month)
        'Dim LastDayInMonthDate As Date = New Date(MyDate.Year, MyDate.Month, DaysInMonth)


        If MyDate.Day <= 15 Then
            Return 15
        Else
            Return DaysInMonth - 15
        End If

    End Function

    Public Sub Show_Employee_HDR_Info(sCompany_ID As String, iClient_ID As Integer)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String



        If GlobalVariables.sReliever = False Then

            SQL = "SELECT A.COMPANY_ID, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME, B.CLIENT_NAME, B.ADDRESS, B.DAILY_WAGE, A.ALLOWANCE,B.CLIENT_ID "
            SQL = SQL & " FROM TBL_EMP_HDR A, TBL_CLIENT_SUB B"
            SQL = SQL & " WHERE A.COMPANY_ID = '" & sCompany_ID & "' AND A.CLIENT_ID = B.CLIENT_ID"

        Else
            SQL = "SELECT A.COMPANY_ID, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME, B.CLIENT_NAME, B.ADDRESS, B.DAILY_WAGE, A.ALLOWANCE, B.CLIENT_ID "
            SQL = SQL & " FROM TBL_EMP_HDR A, TBL_CLIENT_SUB B"
            SQL = SQL & " WHERE A.COMPANY_ID = '" & sCompany_ID & "' AND B.CLIENT_ID = " & iClient_ID & " "

        End If


        da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
        da.Fill(dt)

        If dt.Rows.Count > 0 Then ' SHOW DATA

            Dim myRow As DataRow
            For Each myRow In dt.Rows
                With FRM_DTR_INPUT

                    .Lbl_Company_ID.Text = myRow.Item("Company_id") ' Company_ID
                    .Lbl_ClientName.Text = myRow.Item("Client_id") & "-" & myRow.Item("Client_name") ' Detachment
                    '.Lbl_Detachment_Address.Text = myRow.Item(5) ' Address
                    .Lbl_Daily_Wage.Text = myRow.Item(6) ' Daily Wage  
                    .Lbl_PerHour.Text = myRow.Item(6) / 8
                    .Lbl_Name.Text = myRow.Item(1) & ", " & myRow.Item(2) & " " & Left(myRow.Item(3), 1) ' Name
                    .TxtAllowance.Text = myRow.Item("ALLOWANCE")

                End With
            Next
        Else

        End If

        GlobalVariables.GlobalCon.Close()

    End Sub


    Public Sub Check_All_AM_Dates()
        With FRM_DTR_INPUT
            .Chk1AM.Checked = True
            .Chk2AM.Checked = True
            .Chk3AM.Checked = True
            .Chk4AM.Checked = True
            .Chk5AM.Checked = True
            .Chk6AM.Checked = True
            .Chk7AM.Checked = True
            .Chk8AM.Checked = True
            .Chk9AM.Checked = True
            .Chk10AM.Checked = True
            .Chk11AM.Checked = True
            .Chk12AM.Checked = True
            .Chk13AM.Checked = True
            .Chk14AM.Checked = True
            .Chk15AM.Checked = True

            .Chk1PM.Checked = False
            .Chk2PM.Checked = False
            .Chk3PM.Checked = False
            .Chk4PM.Checked = False
            .Chk5PM.Checked = False
            .Chk6PM.Checked = False
            .Chk7PM.Checked = False
            .Chk8PM.Checked = False
            .Chk9PM.Checked = False
            .Chk10PM.Checked = False
            .CHK11PM.Checked = False
            .Chk12PM.Checked = False
            .Chk13PM.Checked = False
            .Chk14PM.Checked = False
            .Chk15PM.Checked = False
        End With

    End Sub


    Public Sub Check_All_PM_Dates()


        With FRM_DTR_INPUT

            .Chk1PM.Checked = True
            .Chk2PM.Checked = True
            .Chk3PM.Checked = True
            .Chk4PM.Checked = True
            .Chk5PM.Checked = True
            .Chk6PM.Checked = True
            .Chk7PM.Checked = True
            .Chk8PM.Checked = True
            .Chk9PM.Checked = True
            .Chk10PM.Checked = True
            .CHK11PM.Checked = True
            .Chk12PM.Checked = True
            .Chk13PM.Checked = True
            .Chk14PM.Checked = True
            .Chk15PM.Checked = True

            .Chk1AM.Checked = False
            .Chk2AM.Checked = False
            .Chk3AM.Checked = False
            .Chk4AM.Checked = False
            .Chk5AM.Checked = False
            .Chk6AM.Checked = False
            .Chk7AM.Checked = False
            .Chk8AM.Checked = False
            .Chk9AM.Checked = False
            .Chk10AM.Checked = False
            .Chk11AM.Checked = False
            .Chk12AM.Checked = False
            .Chk13AM.Checked = False
            .Chk14AM.Checked = False
            .Chk15AM.Checked = False



        End With

    End Sub
    Public Function Generate_DTR_Number()

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        SQL = "SELECT MAX(DTR_NO) AS NEW_DTR FROM TBL_DTR_HDR"

        Try

            da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
            da.Fill(dt)


            If dt.Rows.Count > 0 Then ' SHOW DATAS

                Dim myRow As DataRow

                For Each myRow In dt.Rows


                    Return myRow.Item(0) + 1 ' Max DTR_NO + 1


                Next

            Else
                Return "1000"

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, vbCritical, "Error in Generating DTR No. - No Max DTR found")

        End Try

        GlobalVariables.GlobalCon.Close()
        Return "0"

    End Function

    Public Sub Clear_Textbox_Hours(Day_Number)
        Try

            Select Case Day_Number

                Case 1
                    With FRM_DTR_INPUT
                        .Txt_REG_1.Text = 0
                        .Txt_REG_SUN_1.Text = 0
                        .Txt_REG_SH_1.Text = 0
                        .Txt_REG_LH_1.Text = 0

                        .Txt_ND_REG_1.Text = 0
                        .Txt_ND_SUN_1.Text = 0
                        .Txt_ND_SH_1.Text = 0
                        .Txt_ND_LH_1.Text = 0

                        .Txt_OT_REG_1.Text = 0
                        .Txt_OT_SUN_1.Text = 0
                        .Txt_OT_SH_1.Text = 0
                        .Txt_OT_LH_1.Text = 0
                    End With
                Case 2
                    With FRM_DTR_INPUT

                        .Txt_REG_2.Text = 0
                        .Txt_REG_SUN_2.Text = 0
                        .Txt_REG_SH_2.Text = 0
                        .Txt_REG_LH_2.Text = 0

                        .Txt_ND_REG_2.Text = 0
                        .Txt_ND_SUN_2.Text = 0
                        .Txt_ND_SH_2.Text = 0
                        .Txt_ND_LH_2.Text = 0

                        .Txt_OT_REG_2.Text = 0
                        .Txt_OT_SUN_2.Text = 0
                        .Txt_OT_SH_2.Text = 0
                        .Txt_OT_LH_2.Text = 0

                    End With
                Case 3
                    With FRM_DTR_INPUT

                        .Txt_REG_3.Text = 0
                        .Txt_REG_SUN_3.Text = 0
                        .Txt_REG_SH_3.Text = 0
                        .Txt_REG_LH_3.Text = 0

                        .Txt_ND_REG_3.Text = 0
                        .Txt_ND_SUN_3.Text = 0
                        .Txt_ND_SH_3.Text = 0
                        .Txt_ND_LH_3.Text = 0

                        .Txt_OT_REG_3.Text = 0
                        .Txt_OT_SUN_3.Text = 0
                        .Txt_OT_SH_3.Text = 0
                        .Txt_OT_LH_3.Text = 0

                    End With
                Case 4

                    With FRM_DTR_INPUT

                        .Txt_REG_4.Text = 0
                        .Txt_REG_SUN_4.Text = 0
                        .Txt_REG_SH_4.Text = 0
                        .Txt_REG_LH_4.Text = 0

                        .Txt_ND_REG_4.Text = 0
                        .Txt_ND_SUN_4.Text = 0
                        .Txt_ND_SH_4.Text = 0
                        .Txt_ND_LH_4.Text = 0

                        .Txt_OT_REG_4.Text = 0
                        .Txt_OT_SUN_4.Text = 0
                        .Txt_OT_SH_4.Text = 0
                        .Txt_OT_LH_4.Text = 0

                    End With
                Case 5
                    With FRM_DTR_INPUT

                        .Txt_REG_5.Text = 0
                        .Txt_REG_SUN_5.Text = 0
                        .Txt_REG_SH_5.Text = 0
                        .Txt_REG_LH_5.Text = 0

                        .Txt_ND_REG_5.Text = 0
                        .Txt_ND_SUN_5.Text = 0
                        .Txt_ND_SH_5.Text = 0
                        .Txt_ND_LH_5.Text = 0

                        .Txt_OT_REG_5.Text = 0
                        .Txt_OT_SUN_5.Text = 0
                        .Txt_OT_SH_5.Text = 0
                        .Txt_OT_LH_5.Text = 0

                    End With
                Case 6
                    With FRM_DTR_INPUT

                        .Txt_REG_6.Text = 0
                        .Txt_REG_SUN_6.Text = 0
                        .Txt_REG_SH_6.Text = 0
                        .Txt_REG_LH_6.Text = 0

                        .Txt_ND_REG_6.Text = 0
                        .Txt_ND_SUN_6.Text = 0
                        .Txt_ND_SH_6.Text = 0
                        .Txt_ND_LH_6.Text = 0

                        .Txt_OT_REG_6.Text = 0
                        .Txt_OT_SUN_6.Text = 0
                        .Txt_OT_SH_6.Text = 0
                        .Txt_OT_LH_6.Text = 0

                    End With

                Case 7
                    With FRM_DTR_INPUT

                        .Txt_REG_7.Text = 0
                        .Txt_REG_SUN_7.Text = 0
                        .Txt_REG_SH_7.Text = 0
                        .Txt_REG_LH_7.Text = 0

                        .Txt_ND_REG_7.Text = 0
                        .Txt_ND_SUN_7.Text = 0
                        .Txt_ND_SH_7.Text = 0
                        .Txt_ND_LH_7.Text = 0

                        .Txt_OT_REG_7.Text = 0
                        .Txt_OT_SUN_7.Text = 0
                        .Txt_OT_SH_7.Text = 0
                        .Txt_OT_LH_7.Text = 0

                    End With
                Case 8
                    With FRM_DTR_INPUT

                        .Txt_REG_8.Text = 0
                        .Txt_REG_SUN_8.Text = 0
                        .Txt_REG_SH_8.Text = 0
                        .Txt_REG_LH_8.Text = 0

                        .Txt_ND_REG_8.Text = 0
                        .Txt_ND_SUN_8.Text = 0
                        .Txt_ND_SH_8.Text = 0
                        .Txt_ND_LH_8.Text = 0

                        .Txt_OT_REG_8.Text = 0
                        .Txt_OT_SUN_8.Text = 0
                        .Txt_OT_SH_8.Text = 0
                        .Txt_OT_LH_8.Text = 0

                    End With
                Case 9
                    With FRM_DTR_INPUT

                        .Txt_REG_9.Text = 0
                        .Txt_REG_SUN_9.Text = 0
                        .Txt_REG_SH_9.Text = 0
                        .Txt_REG_LH_9.Text = 0

                        .Txt_ND_REG_9.Text = 0
                        .Txt_ND_SUN_9.Text = 0
                        .Txt_ND_SH_9.Text = 0
                        .Txt_ND_LH_9.Text = 0

                        .Txt_OT_REG_9.Text = 0
                        .Txt_OT_SUN_9.Text = 0
                        .Txt_OT_SH_9.Text = 0
                        .Txt_OT_LH_9.Text = 0

                    End With
                Case 10
                    With FRM_DTR_INPUT

                        .Txt_REG_10.Text = 0
                        .Txt_REG_SUN_10.Text = 0
                        .Txt_REG_SH_10.Text = 0
                        .Txt_REG_LH_10.Text = 0

                        .Txt_ND_REG_10.Text = 0
                        .Txt_ND_SUN_10.Text = 0
                        .Txt_ND_SH_10.Text = 0
                        .Txt_ND_LH_10.Text = 0

                        .Txt_OT_REG_10.Text = 0
                        .Txt_OT_SUN_10.Text = 0
                        .Txt_OT_SH_10.Text = 0
                        .Txt_OT_LH_10.Text = 0

                    End With
                Case 11

                    With FRM_DTR_INPUT

                        .Txt_REG_11.Text = 0
                        .Txt_REG_SUN_11.Text = 0
                        .Txt_REG_SH_11.Text = 0
                        .Txt_REG_LH_11.Text = 0

                        .Txt_ND_REG_11.Text = 0
                        .Txt_ND_SUN_11.Text = 0
                        .Txt_ND_SH_11.Text = 0
                        .Txt_ND_LH_11.Text = 0

                        .Txt_OT_REG_11.Text = 0
                        .Txt_OT_SUN_11.Text = 0
                        .Txt_OT_SH_11.Text = 0
                        .Txt_OT_LH_11.Text = 0

                    End With

                Case 12

                    With FRM_DTR_INPUT

                        .Txt_REG_12.Text = 0
                        .Txt_REG_SUN_12.Text = 0
                        .Txt_REG_SH_12.Text = 0
                        .Txt_REG_LH_12.Text = 0

                        .Txt_ND_REG_12.Text = 0
                        .Txt_ND_SUN_12.Text = 0
                        .Txt_ND_SH_12.Text = 0
                        .Txt_ND_LH_12.Text = 0

                        .Txt_OT_REG_12.Text = 0
                        .Txt_OT_SUN_12.Text = 0
                        .Txt_OT_SH_12.Text = 0
                        .Txt_OT_LH_12.Text = 0

                    End With

                Case 13

                    With FRM_DTR_INPUT

                        .Txt_REG_13.Text = 0
                        .Txt_REG_SUN_13.Text = 0
                        .Txt_REG_SH_13.Text = 0
                        .Txt_REG_LH_13.Text = 0

                        .Txt_ND_REG_13.Text = 0
                        .Txt_ND_SUN_13.Text = 0
                        .Txt_ND_SH_13.Text = 0
                        .Txt_ND_LH_13.Text = 0

                        .Txt_OT_REG_13.Text = 0
                        .Txt_OT_SUN_13.Text = 0
                        .Txt_OT_SH_13.Text = 0
                        .Txt_OT_LH_13.Text = 0

                    End With

                Case 14

                    With FRM_DTR_INPUT

                        .Txt_REG_14.Text = 0
                        .Txt_REG_SUN_14.Text = 0
                        .Txt_REG_SH_14.Text = 0
                        .Txt_REG_LH_14.Text = 0

                        .Txt_ND_REG_14.Text = 0
                        .Txt_ND_SUN_14.Text = 0
                        .Txt_ND_SH_14.Text = 0
                        .Txt_ND_LH_14.Text = 0

                        .Txt_OT_REG_14.Text = 0
                        .Txt_OT_SUN_14.Text = 0
                        .Txt_OT_SH_14.Text = 0
                        .Txt_OT_LH_14.Text = 0

                    End With

                Case 15

                    With FRM_DTR_INPUT

                        .Txt_REG_15.Text = 0
                        .Txt_REG_SUN_15.Text = 0
                        .Txt_REG_SH_15.Text = 0
                        .Txt_REG_LH_15.Text = 0

                        .Txt_ND_REG_15.Text = 0
                        .Txt_ND_SUN_15.Text = 0
                        .Txt_ND_SH_15.Text = 0
                        .Txt_ND_LH_15.Text = 0

                        .Txt_OT_REG_15.Text = 0
                        .Txt_OT_SUN_15.Text = 0
                        .Txt_OT_SH_15.Text = 0
                        .Txt_OT_LH_15.Text = 0

                    End With


            End Select

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Set_Date_Picker() ' From 1 -15 later will include 16-31 on this loop

        With FRM_DTR_INPUT

            Dim SeriesDate As String
            Dim PreviousDate As Date

            For i = 1 To 15

                ' Set the Date Picker to get the Day e.g Sunday
                'PreviousDate = Mid(GlobalVariables.sPayroll_Cutoff, 1, 3) & " " & i & "," & Date.Now.Year ' Set the Date Long format
                PreviousDate = Mid("May", 1, 3) & " " & i & "," & Date.Now.Year ' Set the Date Long format
                SeriesDate = PreviousDate.ToLongDateString()
                GlobalVariables.sDay(i) = Mid(SeriesDate, 1, 3) ' Identification of Day e.g Sunday or Weekdays
                .Controls("Lbl_Day" & i).Text = GlobalVariables.sDay(i)

                If UCase(GlobalVariables.sDay(i)) = "SUN" Then
                    .Controls("Lbl_Day" & i).ForeColor = Color.Red
                Else
                    .Controls("Lbl_Day" & i).ForeColor = Color.White
                End If

            Next i

        End With
    End Sub

    Public Sub SAVE_DTR_HDR(Company_ID As String, DTR_Number As Integer, Payroll_Cutoff As String, sYear As String, iClient_ID As Integer, iTotal_Earnings As Integer, iTotal_Deductions As Integer, iTotal_Days As Integer, iTotal_Hours As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try
            ' TBL_DTR_HDR
            SQL = "INSERT INTO TBL_DTR_HDR (COMPANY_ID, DTR_NO, PAYROLL_YEAR, PAYROLL_PERIOD, CLIENT_ID, TOTAL_EARNINGS, TOTAL_DEDUCTIONS, TOTAL_DAYS, TOTAL_HOURS) "
            SQL = SQL & "VALUES ('" & Company_ID & "'," & DTR_Number & ",'" & sYear & "','" & Payroll_Cutoff & "'," & iClient_ID & "," & iTotal_Earnings & "," & iTotal_Deductions & "," & iTotal_Days & "," & iTotal_Hours & ") "

            Dim SQLcmd1 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
            SQLcmd1.ExecuteNonQuery()
            SQLcmd1.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Saving to DTR Tables")

        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub


    Public Sub SAVE_DTR_EARNINGS(DTR_number As Integer)
        Dim SQL As String

        Connect_to_MDB()

        Try

            With FRM_DTR_INPUT

                'SQL = ""
                'SQL = "INSERT INTO TBL_DTR_EARNINGS (DTR_NO,OFFICERS_ALLOWANCE, H_TOTAL_REG,H_TOTAL_REG_SUN, H_TOTAL_REG_SH, H_TOTAL_REG_LH, H_TOTAL_ND_REG,H_TOTAL_ND_SUN,H_TOTAL_ND_SH,H_TOTAL_ND_LH"
                'SQL = SQL & " , H_TOTAL_OT_REG, H_TOTAL_OT_SUN, H_TOTAL_OT_SH, H_TOTAL_OT_LH"
                'SQL = SQL & " ,AMT_REG, AMT_REG_SUN, AMT_REG_SH, AMT_REG_LH, AMT_ND_REG, AMT_ND_SUN, AMT_ND_SH, AMT_ND_LH, AMT_OT_REG, AMT_OT_SUN, AMT_OT_SH, AMT_OT_LH, TOTAL_AMT) "
                'SQL = SQL & " VALUES (" & DTR_number & "," & Cdbl(.TxtAllowance.Text) & ", " & Cdbl(.Txt_Total_REG.Text) & ", " & Cdbl(.Txt_Total_REG_SUN.Text) & ", " & Cdbl(.Txt_Total_REG_SH.Text) & ", " & Cdbl(.Txt_Total_REG_LH.Text) & ""
                'SQL = SQL & ", " & Cdbl(.Txt_Total_ND_REG.Text) & ", " & Cdbl(.Txt_Total_ND_SUN.Text) & ", " & Cdbl(.Txt_Total_ND_SH.Text) & ", " & Cdbl(.Txt_Total_ND_LH.Text) & " "
                'SQL = SQL & ", " & Cdbl(.Txt_Total_OT_REG.Text) & ", " & Cdbl(.Txt_Total_OT_SUN.Text) & ", " & Cdbl(.Txt_Total_OT_SH.Text) & ", " & Cdbl(.Txt_Total_OT_LH.Text) & ""
                'SQL = SQL & ", " & Cdbl(.Txt_Total_REG_REG_Php.Text) & ", " & Cdbl(.Txt_Total_REG_SUN_Php.Text) & " "
                'SQL = SQL & ", " & Cdbl(.Txt_Total_REG_SH_Php.Text) & ", " & Cdbl(.Txt_Total_REG_LH_Php.Text) & ", " & Cdbl(.Txt_Total_ND_REG_Php.Text) & ", " & Cdbl(.Txt_Total_ND_SUN_Php.Text) & " "
                'SQL = SQL & ", " & Cdbl(.Txt_Total_ND_SH_Php.Text) & ", " & Cdbl(.Txt_Total_ND_LH_Php.Text) & ", " & Cdbl(.Txt_Total_OT_REG_Php.Text) & ", " & Cdbl(.Txt_Total_OT_SUN_Php.Text) & " "
                'SQL = SQL & ", " & Cdbl(.Txt_Total_OT_SH_Php.Text) & ", " & Cdbl(.Txt_Total_OT_LH_Php.Text) & ", " & Cdbl(.Txt_Total_Earnings.Text) & ") "

                'Saving only total hours
                SQL = ""
                SQL = "INSERT INTO TBL_DTR_EARNINGS (DTR_NO,OFFICERS_ALLOWANCE, H_TOTAL_REG,H_TOTAL_REG_SUN, H_TOTAL_REG_SH, H_TOTAL_REG_LH, H_TOTAL_ND_REG,H_TOTAL_ND_SUN,H_TOTAL_ND_SH,H_TOTAL_ND_LH"
                SQL = SQL & " , H_TOTAL_OT_REG, H_TOTAL_OT_SUN, H_TOTAL_OT_SH, H_TOTAL_OT_LH)"
                SQL = SQL & " VALUES (" & DTR_number & "," & CDbl(.TxtAllowance.Text) & ", " & CDbl(.Txt_Total_REG.Text) & ", " & CDbl(.Txt_Total_REG_SUN.Text) & ", " & CDbl(.Txt_Total_REG_SH.Text) & ", " & CDbl(.Txt_Total_REG_LH.Text) & ""
                SQL = SQL & ", " & CDbl(.Txt_Total_ND_REG.Text) & ", " & CDbl(.Txt_Total_ND_SUN.Text) & ", " & CDbl(.Txt_Total_ND_SH.Text) & ", " & CDbl(.Txt_Total_ND_LH.Text) & " "
                SQL = SQL & ", " & CDbl(.Txt_Total_OT_REG.Text) & ", " & CDbl(.Txt_Total_OT_SUN.Text) & ", " & CDbl(.Txt_Total_OT_SH.Text) & ", " & CDbl(.Txt_Total_OT_LH.Text) & ")"

                Dim SQLcmd3 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd3.ExecuteNonQuery()
                SQLcmd3.Dispose()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error in saving to TBL_DTR_EARNINGS")

        End Try

        GlobalVariables.GlobalCon.Close()
    End Sub

    Public Sub UPDATE_TBL_EMP_HDR_LAST_PAYROLL_PERIOD(sCompanyID As String, iYear As String, sPayroll_Period As String)
        Dim SQL As String
        Connect_to_MDB()

        Try

            With FRM_DTR_INPUT

                ' TBL_DTR_EARNINGS
                SQL = "UPDATE TBL_EMP_HDR SET LATEST_PAYROLL_YEAR = '" & iYear & "', LATEST_PAYROLL_PERIOD = '" & sPayroll_Period & "' WHERE COMPANY_ID = '" & sCompanyID & "'"

                Dim SQLcmd3 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd3.ExecuteNonQuery()
                SQLcmd3.Dispose()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Saving to DTR Tables")

        End Try

        GlobalVariables.GlobalCon.Close()




    End Sub

    Public Sub SAVE_TBL_DTR_DTL(iDTR_No As Integer, sYear As String, sPayroll_Period As String, sDay As String, sShift As String, No_of_days As Integer, sSunday As String, sHoliday As String, iDefault_ClientID As Integer, iPerHour As Double)
        Dim SQL As String
        Connect_to_MDB()

        Try

            With FRM_DTR_INPUT

                ' TBL_DTR_EARNINGS
                SQL = "INSERT INTO TBL_DTR_DTL (DTR_NO, PAYROLL_YEAR, PAYROLL_PERIOD, DTR_DAY, DTR_SHIFT,NO_OF_DAYS, DTR_SUN, DTR_HOL, DEFAULT_CLIENT_ID, PER_HOUR) "
                SQL = SQL & " VALUES (" & iDTR_No & ", '" & sYear & "','" & sPayroll_Period & "','" & sDay & "','" & sShift & "'," & No_of_days & ",'" & sSunday & "','" & sHoliday & "'," & iDefault_ClientID & "," & iPerHour & ") "

                Dim SQLcmd3 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd3.ExecuteNonQuery()
                SQLcmd3.Dispose()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving to DTR DTL")

        End Try

        GlobalVariables.GlobalCon.Close()



    End Sub

    Public Sub SAVE_TBL_DTR_DEDUCTIONS(iDTR_No As Integer)

        Dim SQL As String
        Connect_to_MDB()

        Try

            With FRM_DTR_INPUT

                SQL = "INSERT INTO TBL_DTR_DEDUCTIONS (DTR_NO,SSS_DEDUCTION, SSS_SAL_LOAN,SSS_CAL_LOAN,PH_DEDUCTION,PI_DEDUCTION,PI_SAL_LOAN,PI_CAL_LOAN,CASHBOND) "
                SQL = SQL & " VALUES ('" & iDTR_No & "', '" & CInt(.Txt_SSS_Contri.Text) & "', '" & CInt(.Txt_SSS_Sal_Loan.Text) & "', '" & CInt(.Txt_SSS_Cal_Loan.Text) & "' "
                SQL = SQL & " , '" & CInt(.Txt_PH_Contri.Text) & "', '" & CInt(.Txt_PI_Contri.Text) & "', '" & CInt(.Txt_PI_Sal_Loan.Text) & "', '" & CInt(.Txt_PI_Cal_Loan.Text) & "', '" & CInt(.Txt_Cashbond.Text) & "')"

                Dim SQLcmd3 As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd3.ExecuteNonQuery()
                SQLcmd3.Dispose()

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error saving to TBL_DTR_DEDUCTIONS")

        End Try

        GlobalVariables.GlobalCon.Close()


    End Sub


    Public Sub Get_Employee_Contributions_as_Deductions(iClient_ID As Integer) ' Check frequency of Deductions ( e.g every Cut-Off or Every Month End Only! )
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String

        ' For Contributions ONLY, deduction for Loan Payments not yet included
        SQL = "SELECT * FROM TBL_CLIENT_SUB WHERE CLIENT_ID = " & iClient_ID & " "

        da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
        da.Fill(dt)

        If dt.Rows.Count > 0 Then ' SHOW DATA

            Dim myRow As DataRow
            Dim iTotal_deduction As Double

            For Each myRow In dt.Rows
                With FRM_DTR_INPUT

                    .Txt_SSS_Contri.Text = myRow.Item("SSS_DEDUCTION") ' Company_ID
                    .Txt_PH_Contri.Text = myRow.Item("PH_DEDUCTION") ' PAGIBIG
                    .Txt_PI_Contri.Text = myRow.Item("PI_DEDUCTION") ' PAGIBIG
                    '.Txt_Cashbond.Text = myRow.Item("CASHBOND") ' PAGIBIG

                    iTotal_deduction = CDbl(.Txt_SSS_Contri.Text) + CDbl(.Txt_SSS_Cal_Loan.Text) + CDbl(.Txt_SSS_Sal_Loan.Text)
                    iTotal_deduction = iTotal_deduction + CDbl(.Txt_PI_Contri.Text) + CDbl(.Txt_PI_Cal_Loan.Text) + CDbl(.Txt_PI_Sal_Loan.Text)
                    iTotal_deduction = iTotal_deduction + CDbl(.Txt_PH_Contri.Text) + CDbl(.Txt_Cashbond.Text)

                    .Lbl_Total_Deduction.Text = iTotal_deduction.ToString("#,###.00")

                End With
            Next

        Else

        End If

        GlobalVariables.GlobalCon.Close()

    End Sub

    Public Sub Calculate_Total_Deduction()
        Dim iTotal_deduction As Double

        Try
            With FRM_DTR_INPUT

                iTotal_deduction = CDbl(.Txt_SSS_Contri.Text) + CDbl(.Txt_SSS_Cal_Loan.Text) + CDbl(.Txt_SSS_Sal_Loan.Text)
                iTotal_deduction = iTotal_deduction + CDbl(.Txt_PI_Contri.Text) + CDbl(.Txt_PI_Cal_Loan.Text) + CDbl(.Txt_PI_Sal_Loan.Text)
                iTotal_deduction = iTotal_deduction + CDbl(.Txt_PH_Contri.Text) + CDbl(.Txt_Cashbond.Text)

                .Lbl_Total_Deduction.Text = iTotal_deduction.ToString("N")

            End With

        Catch ex As Exception

        End Try
    End Sub



End Module
