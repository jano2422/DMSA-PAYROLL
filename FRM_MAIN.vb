Imports DMSA_System.DMSA_System
Imports FontAwesome.Sharp
Imports System.Globalization
Imports System.Windows.Input
Imports System.Windows.Interop

Public Class FRM_MAIN
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ShowUserManagementView()
        ' Create the user control
        Dim userManagementControl As New UserManagementView()

        ' Wrap the user control in a new window
        Dim userManagementWindow As New System.Windows.Window With {
        .Title = "User Management",
        .Width = 600,
        .Height = 500,
        .Content = userManagementControl,
        .WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
        .ResizeMode = System.Windows.ResizeMode.CanResize,
        .WindowStyle = System.Windows.WindowStyle.ToolWindow
    }

        ' Show the window as a dialog (modal), but we don't care about the result
        userManagementWindow.ShowDialog()
    End Sub
    Private Sub Btn_HR_Click(sender As Object, e As EventArgs)


        If Grp_HR_Menu.Visible = False Then
            Grp_HR_Menu.Visible = True
            Grp_HR_Menu.Location = New Point(349, 89)
            GRP_Payroll.Visible = False
        Else
            Grp_HR_Menu.Visible = False
            Grp_HR_Menu.Location = New Point(695, 89)
        End If

    End Sub

    Private Sub FRM_MAIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call MDB_Connection_Init()
        Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US") ' For MM/dd/yyyy
        Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")


    End Sub

    Private Sub Btn_Inventory_Click(sender As Object, e As EventArgs)
        FRM_LOAN.ShowDialog()
    End Sub

    Private Sub Btn_Client_Click(sender As Object, e As EventArgs)
        FRM_CLIENT_HDR.ShowDialog()
    End Sub



    Private Sub Btn_Recruitment_Click(sender As Object, e As EventArgs)
        FRM_HRIS_APPLICATION.ShowDialog()
    End Sub

    Private Sub Btn_Employee_Records_Click(sender As Object, e As EventArgs)
        FRM_EMP_REG.ShowDialog()
    End Sub



    Private Sub Btn_Payroll_Click(sender As Object, e As EventArgs)
        If GRP_Payroll.Visible = False Then
            Grp_HR_Menu.Visible = False
            GRP_Payroll.Visible = True
            GRP_Payroll.Location = New Point(349, 89)
        Else
            GRP_Payroll.Visible = False
            GRP_Payroll.Location = New Point(695, 89)
        End If
    End Sub

    Private Sub Btn_HR_Reports_Click(sender As Object, e As EventArgs)
        FRM_HR_REPORTS.ShowDialog()
    End Sub



    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles Btn_HR.Click
        If Grp_HR_Menu.Visible = False Then
            Grp_HR_Menu.Visible = True
            GRP_Operations.Visible = False
            GRP_Payroll.Visible = False
        Else
            Grp_HR_Menu.Visible = False
        End If
    End Sub

    Private Sub Btn_EmployeeRecords_Click(sender As Object, e As EventArgs) Handles Btn_EmployeeRecords.Click
        FRM_EMP_REG.ShowDialog()
    End Sub

    Private Sub Btn_Recruitment_Click_1(sender As Object, e As EventArgs) Handles Btn_Recruitment.Click
        FRM_HRIS_APPLICATION.ShowDialog()
    End Sub

    Private Sub Btn_ClientManagement_Click(sender As Object, e As EventArgs) Handles Btn_ClientManagement.Click
        FRM_CLIENT_HDR.ShowDialog()
    End Sub

    Private Sub Btn_HR_Reports_Click_1(sender As Object, e As EventArgs) Handles Btn_HR_Reports.Click
        FRM_HR_REPORTS.ShowDialog()
    End Sub

    Private Sub GRP_Payroll_Enter(sender As Object, e As EventArgs) Handles GRP_Payroll.Enter

    End Sub

    Private Sub Btn_Payroll_Click_1(sender As Object, e As EventArgs) Handles Btn_Payroll.Click
        If GRP_Payroll.Visible = False Then
            GRP_Payroll.Visible = True
            GRP_Operations.Visible = False
            Grp_HR_Menu.Visible = False
        Else
            GRP_Payroll.Visible = False
        End If
    End Sub

    Private Sub Btn_DTR_Click(sender As Object, e As EventArgs) Handles Btn_DTR.Click
        GlobalVariables.sDTR_or_Schedule_Process = "DTR"
        'FRM_DTR_BIOMETRIC_WINDOW.ShowDialog()
        FRM_DTR_BIOMETRIC.ShowDialog()
    End Sub

    Private Sub Btn_Payslip_Click(sender As Object, e As EventArgs) Handles Btn_Payslip.Click
        FRM_DTR_EXPORTS.ShowDialog()
    End Sub

    Private Sub Btn_Schedule_Click(sender As Object, e As EventArgs) Handles Btn_Schedule.Click
        '' Create and show the WPF window
        'Dim wpfScheduleWindow As New ScheduleManager()
        'Dim helper As New WindowInteropHelper(wpfScheduleWindow)
        'helper.Owner = Me.Handle ' Set WinForms window as owner

        '' Show as a modal dialog to ensure input focus
        'wpfScheduleWindow.ShowDialog()

        '' Ensure the window is properly activated and textbox is focused
        'wpfScheduleWindow.Activate()
        'Keyboard.Focus(wpfScheduleWindow.EmployeeSearchTextBox)
        FRM_DTR_SCHEDULE.ShowDialog()
    End Sub


    Private Sub Btn_Operations_Click(sender As Object, e As EventArgs) Handles Btn_Operations.Click
        If GRP_Operations.Visible = False Then
            GRP_Operations.Visible = True
            GRP_Payroll.Visible = False
            Grp_HR_Menu.Visible = False
        Else
            GRP_Operations.Visible = False
        End If
    End Sub

    Private Sub Btn_DefaultSchedule_Click(sender As Object, e As EventArgs)
        FRM_DTR_EMPLOYEE_LIST.ShowDialog()
    End Sub

    Private Sub AdminBtn_Click(sender As Object, e As EventArgs) Handles AdminBtn.Click
        ShowUserManagementView()
    End Sub
End Class