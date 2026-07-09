Public Class FRM_DTR
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Btn_Encode_DTR.Click


        ' Do not allow advance DTR Generation - check Date


        GlobalVariables.sReliever = False ' Reset employee's Client ID after a Reliever transaction at DTR Generation
        Call FRM_DTR_INPUT.ShowDialog()


    End Sub

    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
        Dim sPeriod As String

        Connect_to_MDB()

        If Me.Cmb_CutOff.SelectedIndex = 0 Then
            sPeriod = Me.Cmb_Month.Text & " 1-15"
        Else
            sPeriod = Me.Cmb_Month.Text & " 16-30"
        End If

        ' Controls
        ' If selected Year and Month is greater than NOW then should not be alloed

        Dim MonthNow As String = DateTime.Now.Month.ToString
        Dim YearNow As String = DateTime.Now.Year.ToString

        If CInt(Me.Cmb_Year.Text) > YearNow Then
            MsgBox("Not a valid year.", vbCritical, "Invalid Year")
            Exit Sub
        End If

        If (Cmb_Month.SelectedIndex + 1) > MonthNow Then
            MsgBox("Not a valid Date (Month).", vbCritical, "Invalid Month")
            Exit Sub
        End If

        GlobalVariables.sPayroll_Cutoff = sPeriod
        Show_DTR_List(Me.Cmb_Year.Text, sPeriod)


    End Sub

    Private Sub FRM_DTR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 2023 To Date.Now.Year()
            Me.Cmb_Year.Items.Add(i)
        Next i


        For i = 1 To Date.Now.Month()
            Me.Cmb_Month.Items.Add(UCase(MonthName(i, True)))
        Next i

        Me.Cmb_Year.SelectedIndex = 0
        Me.Cmb_CutOff.SelectedIndex = 0

        Me.Cmb_Month.SelectedIndex = DateTime.Now.Month.ToString - 1

    End Sub

    Private Sub LV_EmployeeList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_EmployeeList.SelectedIndexChanged
        Try
            GlobalVariables.Selected_Employee_ID = Me.LV_EmployeeList.SelectedItems(0).SubItems(0).Text
            GlobalVariables.Selected_Client_ID = Get_Client_ID(GlobalVariables.Selected_Employee_ID)
        Catch ex As Exception
            ' Getting an error 
            ' MsgBox(ex.ToString)
        End Try


        If GlobalVariables.Selected_Employee_ID <> "" Then
            Btn_Encode_DTR.Enabled = True
        Else
            Btn_Encode_DTR.Enabled = False
        End If

    End Sub

    Private Sub Cmb_CutOff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_CutOff.SelectedIndexChanged
        If Me.Cmb_CutOff.SelectedIndex = 0 Then
            LblPeriod.Text = Me.Cmb_Month.Text & " 1-15"
        Else
            LblPeriod.Text = Me.Cmb_Month.Text & " 16-30"
        End If

        GlobalVariables.sPayroll_Cutoff = LblPeriod.Text ' Payroll_Period

    End Sub

    Private Sub Btn_GeneratePayslip_Click(sender As Object, e As EventArgs) 
        FRM_DTR_REPORT.ShowDialog()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Cmb_Year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Year.SelectedIndexChanged

    End Sub

    Private Sub Btn_LoadDTR_Click(sender As Object, e As EventArgs) Handles Btn_LoadDTR.Click

    End Sub
End Class