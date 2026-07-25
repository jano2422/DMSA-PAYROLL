<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_HR_REPORTS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartTitle1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartTitle2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tab_Logs = New System.Windows.Forms.TabPage()
        Me.Btn_Logs_Show = New System.Windows.Forms.Button()
        Me.Txt_Logs_DateTo = New System.Windows.Forms.TextBox()
        Me.DP_Logs_To = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Logs_DateFrom = New System.Windows.Forms.TextBox()
        Me.DP_Logs_From = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LV_SystemLogs = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tab_Security_License = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Cmb_Exp_Category = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Lbl_Export_SecLicense = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Expiry_Status = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LV_Expiry_List = New System.Windows.Forms.ListView()
        Me.Col_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Hired = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_Info = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Expiry_Date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_DaysExpired = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Lbl_Export_Client_Contract_Exp = New System.Windows.Forms.Label()
        Me.Cmb_Client_Expiration = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LV_Client_Contract_Exp = New System.Windows.Forms.ListView()
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tab_HR1 = New System.Windows.Forms.TabPage()
        Me.TabControl4 = New System.Windows.Forms.TabControl()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.Cmb_Emp_Status = New System.Windows.Forms.ComboBox()
        Me.Btn_Age_Count = New System.Windows.Forms.Button()
        Me.Btn_Hired_Per_Month = New System.Windows.Forms.Button()
        Me.Btn_Gender_Count = New System.Windows.Forms.Button()
        Me.Btn_Hired_Per_Year = New System.Windows.Forms.Button()
        Me.LV_Report_Statistics1 = New System.Windows.Forms.ListView()
        Me.Col_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Count = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Btn_Load_Chart_Data = New System.Windows.Forms.Button()
        Me.CH_Emp_Status = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.Tab_Recruitment = New System.Windows.Forms.TabControl()
        Me.Tab_Pending_Docs = New System.Windows.Forms.TabPage()
        Me.Cmb_Pending_Category = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Btn_ShowPendingRecords = New System.Windows.Forms.Button()
        Me.Lbl_Export_PendingDocs = New System.Windows.Forms.Label()
        Me.LV_Pending_List = New System.Windows.Forms.ListView()
        Me.Col_Pending_EmpID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColRec_Datehired = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Gov_IDs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Lbl_Export_LeaveStatus = New System.Windows.Forms.Label()
        Me.Cmb_LeaveType = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Btn_Show_Leave = New System.Windows.Forms.Button()
        Me.Txt_Leave_DateTo = New System.Windows.Forms.TextBox()
        Me.DP_Leave_DateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_Leave_DateFrom = New System.Windows.Forms.TextBox()
        Me.DP_Leave_DateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LV_Leave_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Leave_Start = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Leave_End = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tab_Client = New System.Windows.Forms.TabPage()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnExport_MainClientCount = New FontAwesome.Sharp.IconButton()
        Me.LV_Client_Count = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Active_MainClient = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt_Active_SubClient = New System.Windows.Forms.TextBox()
        Me.Btn_Client_Show = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Btn_Export_SubClient_Count = New FontAwesome.Sharp.IconButton()
        Me.Btn_Show_SubClient_EmpCount = New System.Windows.Forms.Button()
        Me.LV_SubClient_EmployeeCount = New System.Windows.Forms.ListView()
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Btn_Export_Employee_Count = New FontAwesome.Sharp.IconButton()
        Me.Btn_Show_MainClient_EmpCount = New System.Windows.Forms.Button()
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT = New System.Windows.Forms.ListView()
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ReportsWorkspaceRoot = New System.Windows.Forms.TableLayoutPanel()
        Me.ReportsHeaderPanel = New System.Windows.Forms.Panel()
        Me.ReportsBodyPanel = New System.Windows.Forms.Panel()
        Me.ReportsLogo = New System.Windows.Forms.PictureBox()
        Me.ReportsTitleLabel = New System.Windows.Forms.Label()
        Me.ReportsSubtitleLabel = New System.Windows.Forms.Label()
        Me.ReportsSectionLabel = New System.Windows.Forms.Label()
        Me.ReportsCloseButton = New System.Windows.Forms.Button()
        Me.ReportsNavInfoPanel = New System.Windows.Forms.Panel()
        Me.ReportsNavInfoTitle = New System.Windows.Forms.Label()
        Me.ReportsNavInfoBody = New System.Windows.Forms.Label()
        Me.ReportsNavPanel = New System.Windows.Forms.Panel()
        Me.ReportsContentHost = New System.Windows.Forms.Panel()
        Me.NavComplianceButton = New System.Windows.Forms.Button()
        Me.NavMissingButton = New System.Windows.Forms.Button()
        Me.NavLeaveButton = New System.Windows.Forms.Button()
        Me.NavWorkforceButton = New System.Windows.Forms.Button()
        Me.NavClientsButton = New System.Windows.Forms.Button()
        Me.NavAuditButton = New System.Windows.Forms.Button()
        Me.EmpExpiryTitleLabel = New System.Windows.Forms.Label()
        Me.EmpExpiryDescriptionLabel = New System.Windows.Forms.Label()
        Me.EmpExpiryFilterPanel = New System.Windows.Forms.Panel()
        Me.ClientExpiryTitleLabel = New System.Windows.Forms.Label()
        Me.ClientExpiryDescriptionLabel = New System.Windows.Forms.Label()
        Me.ClientExpiryFilterPanel = New System.Windows.Forms.Panel()
        Me.MissingTitleLabel = New System.Windows.Forms.Label()
        Me.MissingDescriptionLabel = New System.Windows.Forms.Label()
        Me.MissingFilterPanel = New System.Windows.Forms.Panel()
        Me.LeaveTitleLabel = New System.Windows.Forms.Label()
        Me.LeaveDescriptionLabel = New System.Windows.Forms.Label()
        Me.LeaveFilterPanel = New System.Windows.Forms.Panel()
        Me.AuditTitleLabel = New System.Windows.Forms.Label()
        Me.AuditDescriptionLabel = New System.Windows.Forms.Label()
        Me.AuditFilterPanel = New System.Windows.Forms.Panel()
        Me.Btn_Export_Audit_Log = New FontAwesome.Sharp.IconButton()
        Me.AnalyticsTitleLabel = New System.Windows.Forms.Label()
        Me.AnalyticsDescriptionLabel = New System.Windows.Forms.Label()
        Me.AnalyticsPickerPanel = New System.Windows.Forms.Panel()
        Me.AnalyticsPickerLabel = New System.Windows.Forms.Label()
        Me.AnalyticsStatusLabel = New System.Windows.Forms.Label()
        Me.Btn_Export_Workforce_Analytics = New FontAwesome.Sharp.IconButton()
        Me.PortfolioTitleLabel = New System.Windows.Forms.Label()
        Me.PortfolioDescriptionLabel = New System.Windows.Forms.Label()
        Me.PortfolioSummaryPanel = New System.Windows.Forms.Panel()
        Me.SubClientTitleLabel = New System.Windows.Forms.Label()
        Me.SubClientDescriptionLabel = New System.Windows.Forms.Label()
        Me.SubClientFilterPanel = New System.Windows.Forms.Panel()
        Me.MainClientTitleLabel = New System.Windows.Forms.Label()
        Me.MainClientDescriptionLabel = New System.Windows.Forms.Label()
        Me.MainClientFilterPanel = New System.Windows.Forms.Panel()
        Me.Tab_Logs.SuspendLayout()
        Me.Tab_Security_License.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.Tab_HR1.SuspendLayout()
        Me.TabControl4.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        CType(Me.CH_Emp_Status, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Recruitment.SuspendLayout()
        Me.Tab_Pending_Docs.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Tab_Client.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Maroon
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1309, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(1006, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(276, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Delta Maroon Security Agency Report"
        '
        'Tab_Logs
        '
        Me.Tab_Logs.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Tab_Logs.Controls.Add(Me.Btn_Logs_Show)
        Me.Tab_Logs.Controls.Add(Me.Txt_Logs_DateTo)
        Me.Tab_Logs.Controls.Add(Me.DP_Logs_To)
        Me.Tab_Logs.Controls.Add(Me.Label4)
        Me.Tab_Logs.Controls.Add(Me.Txt_Logs_DateFrom)
        Me.Tab_Logs.Controls.Add(Me.DP_Logs_From)
        Me.Tab_Logs.Controls.Add(Me.Label13)
        Me.Tab_Logs.Controls.Add(Me.LV_SystemLogs)
        Me.Tab_Logs.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Logs.Name = "Tab_Logs"
        Me.Tab_Logs.Size = New System.Drawing.Size(1250, 621)
        Me.Tab_Logs.TabIndex = 9
        Me.Tab_Logs.Text = "System Logs"
        '
        'Btn_Logs_Show
        '
        Me.Btn_Logs_Show.ForeColor = System.Drawing.Color.Black
        Me.Btn_Logs_Show.Location = New System.Drawing.Point(982, 236)
        Me.Btn_Logs_Show.Name = "Btn_Logs_Show"
        Me.Btn_Logs_Show.Size = New System.Drawing.Size(215, 34)
        Me.Btn_Logs_Show.TabIndex = 133
        Me.Btn_Logs_Show.Text = "Show"
        Me.Btn_Logs_Show.UseVisualStyleBackColor = True
        '
        'Txt_Logs_DateTo
        '
        Me.Txt_Logs_DateTo.Enabled = False
        Me.Txt_Logs_DateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Logs_DateTo.Location = New System.Drawing.Point(982, 183)
        Me.Txt_Logs_DateTo.Name = "Txt_Logs_DateTo"
        Me.Txt_Logs_DateTo.Size = New System.Drawing.Size(187, 26)
        Me.Txt_Logs_DateTo.TabIndex = 132
        Me.Txt_Logs_DateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Logs_To
        '
        Me.DP_Logs_To.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Logs_To.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Logs_To.Location = New System.Drawing.Point(1175, 183)
        Me.DP_Logs_To.Name = "DP_Logs_To"
        Me.DP_Logs_To.Size = New System.Drawing.Size(17, 26)
        Me.DP_Logs_To.TabIndex = 130
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(978, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 20)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Date To:"
        '
        'Txt_Logs_DateFrom
        '
        Me.Txt_Logs_DateFrom.Enabled = False
        Me.Txt_Logs_DateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Logs_DateFrom.Location = New System.Drawing.Point(982, 105)
        Me.Txt_Logs_DateFrom.Name = "Txt_Logs_DateFrom"
        Me.Txt_Logs_DateFrom.Size = New System.Drawing.Size(187, 26)
        Me.Txt_Logs_DateFrom.TabIndex = 129
        Me.Txt_Logs_DateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Logs_From
        '
        Me.DP_Logs_From.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Logs_From.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Logs_From.Location = New System.Drawing.Point(1175, 105)
        Me.DP_Logs_From.Name = "DP_Logs_From"
        Me.DP_Logs_From.Size = New System.Drawing.Size(17, 26)
        Me.DP_Logs_From.TabIndex = 127
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(978, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 20)
        Me.Label13.TabIndex = 128
        Me.Label13.Text = "Date From:"
        '
        'LV_SystemLogs
        '
        Me.LV_SystemLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_SystemLogs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.LV_SystemLogs.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_SystemLogs.FullRowSelect = True
        Me.LV_SystemLogs.GridLines = True
        Me.LV_SystemLogs.HideSelection = False
        Me.LV_SystemLogs.Location = New System.Drawing.Point(30, 33)
        Me.LV_SystemLogs.Name = "LV_SystemLogs"
        Me.LV_SystemLogs.Size = New System.Drawing.Size(916, 566)
        Me.LV_SystemLogs.TabIndex = 3
        Me.LV_SystemLogs.UseCompatibleStateImageBehavior = False
        Me.LV_SystemLogs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Employee ID"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Change Description"
        Me.ColumnHeader2.Width = 600
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date Updated"
        Me.ColumnHeader3.Width = 160
        '
        'Tab_Security_License
        '
        Me.Tab_Security_License.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tab_Security_License.Controls.Add(Me.TabControl1)
        Me.Tab_Security_License.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Security_License.Name = "Tab_Security_License"
        Me.Tab_Security_License.Size = New System.Drawing.Size(1250, 621)
        Me.Tab_Security_License.TabIndex = 8
        Me.Tab_Security_License.Text = "Expirations"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Location = New System.Drawing.Point(22, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1205, 586)
        Me.TabControl1.TabIndex = 52
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Cmb_Exp_Category)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Lbl_Export_SecLicense)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Cmb_Expiry_Status)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.LV_Expiry_List)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1197, 553)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Expirations Tracking"
        '
        'Cmb_Exp_Category
        '
        Me.Cmb_Exp_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Exp_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Exp_Category.FormattingEnabled = True
        Me.Cmb_Exp_Category.Items.AddRange(New Object() {"Annual Medical", "Security License", "Insurance"})
        Me.Cmb_Exp_Category.Location = New System.Drawing.Point(140, 26)
        Me.Cmb_Exp_Category.Name = "Cmb_Exp_Category"
        Me.Cmb_Exp_Category.Size = New System.Drawing.Size(172, 28)
        Me.Cmb_Exp_Category.TabIndex = 57
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(46, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 18)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Category:"
        '
        'Lbl_Export_SecLicense
        '
        Me.Lbl_Export_SecLicense.AutoSize = True
        Me.Lbl_Export_SecLicense.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Export_SecLicense.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Export_SecLicense.Location = New System.Drawing.Point(1034, 520)
        Me.Lbl_Export_SecLicense.Name = "Lbl_Export_SecLicense"
        Me.Lbl_Export_SecLicense.Size = New System.Drawing.Size(115, 20)
        Me.Lbl_Export_SecLicense.TabIndex = 56
        Me.Lbl_Export_SecLicense.Text = "Export to Excel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(952, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "For Active Employees only."
        '
        'Cmb_Expiry_Status
        '
        Me.Cmb_Expiry_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Expiry_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Expiry_Status.FormattingEnabled = True
        Me.Cmb_Expiry_Status.Items.AddRange(New Object() {"In 1 month", "In 2 months", "In 3 months", "Expired", "No Record"})
        Me.Cmb_Expiry_Status.Location = New System.Drawing.Point(436, 26)
        Me.Cmb_Expiry_Status.Name = "Cmb_Expiry_Status"
        Me.Cmb_Expiry_Status.Size = New System.Drawing.Size(172, 28)
        Me.Cmb_Expiry_Status.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(327, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 18)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Expiration :"
        '
        'LV_Expiry_List
        '
        Me.LV_Expiry_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Expiry_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_ID, Me.Col_Name, Me.Col_Hired, Me.Col_Client_Info, Me.Col_Expiry_Date, Me.Col_DaysExpired})
        Me.LV_Expiry_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Expiry_List.FullRowSelect = True
        Me.LV_Expiry_List.GridLines = True
        Me.LV_Expiry_List.HideSelection = False
        Me.LV_Expiry_List.Location = New System.Drawing.Point(47, 63)
        Me.LV_Expiry_List.Name = "LV_Expiry_List"
        Me.LV_Expiry_List.Size = New System.Drawing.Size(1102, 454)
        Me.LV_Expiry_List.TabIndex = 52
        Me.LV_Expiry_List.UseCompatibleStateImageBehavior = False
        Me.LV_Expiry_List.View = System.Windows.Forms.View.Details
        '
        'Col_ID
        '
        Me.Col_ID.Text = "Emp ID"
        Me.Col_ID.Width = 105
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Name"
        Me.Col_Name.Width = 230
        '
        'Col_Hired
        '
        Me.Col_Hired.Text = "Date Hired"
        Me.Col_Hired.Width = 140
        '
        'Col_Client_Info
        '
        Me.Col_Client_Info.Text = "Client"
        Me.Col_Client_Info.Width = 350
        '
        'Col_Expiry_Date
        '
        Me.Col_Expiry_Date.Text = "Expiry Date"
        Me.Col_Expiry_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Expiry_Date.Width = 140
        '
        'Col_DaysExpired
        '
        Me.Col_DaysExpired.Text = "Days Expired"
        Me.Col_DaysExpired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_DaysExpired.Width = 140
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage7.Controls.Add(Me.Lbl_Export_Client_Contract_Exp)
        Me.TabPage7.Controls.Add(Me.Cmb_Client_Expiration)
        Me.TabPage7.Controls.Add(Me.Label17)
        Me.TabPage7.Controls.Add(Me.LV_Client_Contract_Exp)
        Me.TabPage7.Location = New System.Drawing.Point(4, 29)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(1197, 553)
        Me.TabPage7.TabIndex = 1
        Me.TabPage7.Text = "   Client Contract   "
        '
        'Lbl_Export_Client_Contract_Exp
        '
        Me.Lbl_Export_Client_Contract_Exp.AutoSize = True
        Me.Lbl_Export_Client_Contract_Exp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Export_Client_Contract_Exp.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Export_Client_Contract_Exp.Location = New System.Drawing.Point(1034, 530)
        Me.Lbl_Export_Client_Contract_Exp.Name = "Lbl_Export_Client_Contract_Exp"
        Me.Lbl_Export_Client_Contract_Exp.Size = New System.Drawing.Size(115, 20)
        Me.Lbl_Export_Client_Contract_Exp.TabIndex = 63
        Me.Lbl_Export_Client_Contract_Exp.Text = "Export to Excel"
        '
        'Cmb_Client_Expiration
        '
        Me.Cmb_Client_Expiration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Client_Expiration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Client_Expiration.FormattingEnabled = True
        Me.Cmb_Client_Expiration.Items.AddRange(New Object() {"In 1 month", "In 2 months", "In 3 months", "Expired", "No Record"})
        Me.Cmb_Client_Expiration.Location = New System.Drawing.Point(147, 31)
        Me.Cmb_Client_Expiration.Name = "Cmb_Client_Expiration"
        Me.Cmb_Client_Expiration.Size = New System.Drawing.Size(188, 28)
        Me.Cmb_Client_Expiration.TabIndex = 61
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(44, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 18)
        Me.Label17.TabIndex = 62
        Me.Label17.Text = "Expiration:"
        '
        'LV_Client_Contract_Exp
        '
        Me.LV_Client_Contract_Exp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Client_Contract_Exp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.Col_Client_ID})
        Me.LV_Client_Contract_Exp.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Client_Contract_Exp.FullRowSelect = True
        Me.LV_Client_Contract_Exp.GridLines = True
        Me.LV_Client_Contract_Exp.HideSelection = False
        Me.LV_Client_Contract_Exp.Location = New System.Drawing.Point(47, 68)
        Me.LV_Client_Contract_Exp.Name = "LV_Client_Contract_Exp"
        Me.LV_Client_Contract_Exp.Size = New System.Drawing.Size(1102, 454)
        Me.LV_Client_Contract_Exp.TabIndex = 59
        Me.LV_Client_Contract_Exp.UseCompatibleStateImageBehavior = False
        Me.LV_Client_Contract_Exp.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Client Name"
        Me.ColumnHeader19.Width = 380
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Branch"
        Me.ColumnHeader20.Width = 180
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Start Contract"
        Me.ColumnHeader21.Width = 130
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "End Contract"
        Me.ColumnHeader22.Width = 130
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Status"
        Me.ColumnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader23.Width = 120
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Days Expired"
        Me.ColumnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader24.Width = 150
        '
        'Col_Client_ID
        '
        Me.Col_Client_ID.Text = "ID"
        Me.Col_Client_ID.Width = 0
        '
        'Tab_HR1
        '
        Me.Tab_HR1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tab_HR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab_HR1.Location = New System.Drawing.Point(4, 29)
        Me.Tab_HR1.Name = "Tab_HR1"
        Me.Tab_HR1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_HR1.Size = New System.Drawing.Size(1250, 621)
        Me.Tab_HR1.TabIndex = 7
        Me.Tab_HR1.Text = "HR Statistics"
        '
        'TabControl4
        '
        Me.TabControl4.Controls.Add(Me.TabPage9)
        Me.TabControl4.Controls.Add(Me.TabPage10)
        Me.TabControl4.Location = New System.Drawing.Point(6, 9)
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedIndex = 0
        Me.TabControl4.Size = New System.Drawing.Size(1236, 604)
        Me.TabControl4.TabIndex = 52
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.Cmb_Emp_Status)
        Me.TabPage9.Controls.Add(Me.Btn_Age_Count)
        Me.TabPage9.Controls.Add(Me.Btn_Hired_Per_Month)
        Me.TabPage9.Controls.Add(Me.Btn_Gender_Count)
        Me.TabPage9.Controls.Add(Me.Btn_Hired_Per_Year)
        Me.TabPage9.Controls.Add(Me.LV_Report_Statistics1)
        Me.TabPage9.Controls.Add(Me.Btn_Load_Chart_Data)
        Me.TabPage9.Controls.Add(Me.CH_Emp_Status)
        Me.TabPage9.Location = New System.Drawing.Point(4, 29)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(1228, 571)
        Me.TabPage9.TabIndex = 1
        Me.TabPage9.Text = "Statistics 1"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'Cmb_Emp_Status
        '
        Me.Cmb_Emp_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Emp_Status.FormattingEnabled = True
        Me.Cmb_Emp_Status.Items.AddRange(New Object() {"Hired", "Active", "Resigned", "AWOL", "Floating"})
        Me.Cmb_Emp_Status.Location = New System.Drawing.Point(146, 449)
        Me.Cmb_Emp_Status.Name = "Cmb_Emp_Status"
        Me.Cmb_Emp_Status.Size = New System.Drawing.Size(126, 28)
        Me.Cmb_Emp_Status.TabIndex = 58
        '
        'Btn_Age_Count
        '
        Me.Btn_Age_Count.Location = New System.Drawing.Point(12, 525)
        Me.Btn_Age_Count.Name = "Btn_Age_Count"
        Me.Btn_Age_Count.Size = New System.Drawing.Size(260, 34)
        Me.Btn_Age_Count.TabIndex = 57
        Me.Btn_Age_Count.Text = "Show Age Count"
        Me.Btn_Age_Count.UseVisualStyleBackColor = True
        '
        'Btn_Hired_Per_Month
        '
        Me.Btn_Hired_Per_Month.ForeColor = System.Drawing.Color.Black
        Me.Btn_Hired_Per_Month.Location = New System.Drawing.Point(12, 445)
        Me.Btn_Hired_Per_Month.Name = "Btn_Hired_Per_Month"
        Me.Btn_Hired_Per_Month.Size = New System.Drawing.Size(128, 34)
        Me.Btn_Hired_Per_Month.TabIndex = 51
        Me.Btn_Hired_Per_Month.Text = "Status Status:"
        Me.Btn_Hired_Per_Month.UseVisualStyleBackColor = True
        '
        'Btn_Gender_Count
        '
        Me.Btn_Gender_Count.Location = New System.Drawing.Point(12, 485)
        Me.Btn_Gender_Count.Name = "Btn_Gender_Count"
        Me.Btn_Gender_Count.Size = New System.Drawing.Size(260, 34)
        Me.Btn_Gender_Count.TabIndex = 56
        Me.Btn_Gender_Count.Text = "Show Gender Count"
        Me.Btn_Gender_Count.UseVisualStyleBackColor = True
        '
        'Btn_Hired_Per_Year
        '
        Me.Btn_Hired_Per_Year.ForeColor = System.Drawing.Color.Black
        Me.Btn_Hired_Per_Year.Location = New System.Drawing.Point(12, 405)
        Me.Btn_Hired_Per_Year.Name = "Btn_Hired_Per_Year"
        Me.Btn_Hired_Per_Year.Size = New System.Drawing.Size(260, 34)
        Me.Btn_Hired_Per_Year.TabIndex = 3
        Me.Btn_Hired_Per_Year.Text = "Show Hired / Year"
        Me.Btn_Hired_Per_Year.UseVisualStyleBackColor = True
        '
        'LV_Report_Statistics1
        '
        Me.LV_Report_Statistics1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Report_Statistics1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_Status, Me.Col_Count})
        Me.LV_Report_Statistics1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Report_Statistics1.FullRowSelect = True
        Me.LV_Report_Statistics1.GridLines = True
        Me.LV_Report_Statistics1.HideSelection = False
        Me.LV_Report_Statistics1.Location = New System.Drawing.Point(8, 19)
        Me.LV_Report_Statistics1.Name = "LV_Report_Statistics1"
        Me.LV_Report_Statistics1.Size = New System.Drawing.Size(264, 340)
        Me.LV_Report_Statistics1.TabIndex = 54
        Me.LV_Report_Statistics1.UseCompatibleStateImageBehavior = False
        Me.LV_Report_Statistics1.View = System.Windows.Forms.View.Details
        '
        'Col_Status
        '
        Me.Col_Status.Text = "Parameter"
        Me.Col_Status.Width = 160
        '
        'Col_Count
        '
        Me.Col_Count.Text = "Count"
        Me.Col_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Count.Width = 100
        '
        'Btn_Load_Chart_Data
        '
        Me.Btn_Load_Chart_Data.Location = New System.Drawing.Point(12, 365)
        Me.Btn_Load_Chart_Data.Name = "Btn_Load_Chart_Data"
        Me.Btn_Load_Chart_Data.Size = New System.Drawing.Size(260, 34)
        Me.Btn_Load_Chart_Data.TabIndex = 53
        Me.Btn_Load_Chart_Data.Text = "Overall Employment Status"
        Me.Btn_Load_Chart_Data.UseVisualStyleBackColor = True
        '
        'CH_Emp_Status
        '
        Me.CH_Emp_Status.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CH_Emp_Status.BackSecondaryColor = System.Drawing.Color.Yellow
        Me.CH_Emp_Status.BorderlineColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.CH_Emp_Status.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.CH_Emp_Status.BorderlineWidth = 1
        ChartArea2.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(224, 176, 128)
        ChartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48)
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular)
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(224, 176, 128)
        ChartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(224, 176, 128)
        ChartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48)
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular)
        ChartArea2.Name = "ChartArea1"
        Me.CH_Emp_Status.ChartAreas.Add(ChartArea2)
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Enabled = False
        Legend2.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Legend2.Name = "L_Hired"
        Me.CH_Emp_Status.Legends.Add(Legend2)
        Me.CH_Emp_Status.Location = New System.Drawing.Point(278, 19)
        Me.CH_Emp_Status.Name = "CH_Emp_Status"
        Series2.ChartArea = "ChartArea1"
        Series2.Color = System.Drawing.Color.FromArgb(111, 29, 48)
        Series2.IsValueShownAsLabel = True
        Series2.LabelBackColor = System.Drawing.Color.Transparent
        Series2.LabelForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Series2.Legend = "L_Hired"
        Series2.Name = "Count"
        Me.CH_Emp_Status.Series.Add(Series2)
        Me.CH_Emp_Status.Size = New System.Drawing.Size(944, 540)
        Me.CH_Emp_Status.TabIndex = 52
        Me.CH_Emp_Status.Text = "Chart1"
        ChartTitle1.Alignment = System.Drawing.ContentAlignment.TopLeft
        ChartTitle1.Font = New System.Drawing.Font("Bahnschrift SemiBold", 13.0!, System.Drawing.FontStyle.Regular)
        ChartTitle1.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        ChartTitle1.Name = "ReportTitle"
        ChartTitle1.Text = "Select a report"
        ChartTitle2.Alignment = System.Drawing.ContentAlignment.TopLeft
        ChartTitle2.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Regular)
        ChartTitle2.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48)
        ChartTitle2.Name = "ReportCaption"
        ChartTitle2.Text = "Choose a report view from the left panel"
        Me.CH_Emp_Status.Titles.Add(ChartTitle1)
        Me.CH_Emp_Status.Titles.Add(ChartTitle2)
        '
        'TabPage10
        '
        Me.TabPage10.Location = New System.Drawing.Point(4, 29)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage10.Size = New System.Drawing.Size(1228, 571)
        Me.TabPage10.TabIndex = 2
        Me.TabPage10.Text = "Statistics 2"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'Tab_Recruitment
        '
        Me.Tab_Recruitment.Controls.Add(Me.Tab_Security_License)
        Me.Tab_Recruitment.Controls.Add(Me.Tab_Pending_Docs)
        Me.Tab_Recruitment.Controls.Add(Me.TabPage4)
        Me.Tab_Recruitment.Controls.Add(Me.Tab_HR1)
        Me.Tab_Recruitment.Controls.Add(Me.Tab_Client)
        Me.Tab_Recruitment.Controls.Add(Me.Tab_Logs)
        Me.Tab_Recruitment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab_Recruitment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_Recruitment.HotTrack = True
        Me.Tab_Recruitment.Location = New System.Drawing.Point(24, 69)
        Me.Tab_Recruitment.Name = "Tab_Recruitment"
        Me.Tab_Recruitment.SelectedIndex = 0
        Me.Tab_Recruitment.Size = New System.Drawing.Size(1258, 654)
        Me.Tab_Recruitment.TabIndex = 3
        '
        'Tab_Pending_Docs
        '
        Me.Tab_Pending_Docs.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Tab_Pending_Docs.Controls.Add(Me.Cmb_Pending_Category)
        Me.Tab_Pending_Docs.Controls.Add(Me.Label5)
        Me.Tab_Pending_Docs.Controls.Add(Me.Label9)
        Me.Tab_Pending_Docs.Controls.Add(Me.Btn_ShowPendingRecords)
        Me.Tab_Pending_Docs.Controls.Add(Me.Lbl_Export_PendingDocs)
        Me.Tab_Pending_Docs.Controls.Add(Me.LV_Pending_List)
        Me.Tab_Pending_Docs.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Pending_Docs.Name = "Tab_Pending_Docs"
        Me.Tab_Pending_Docs.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Pending_Docs.Size = New System.Drawing.Size(1250, 621)
        Me.Tab_Pending_Docs.TabIndex = 10
        Me.Tab_Pending_Docs.Text = "Pending Docs"
        '
        'Cmb_Pending_Category
        '
        Me.Cmb_Pending_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Pending_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Pending_Category.FormattingEnabled = True
        Me.Cmb_Pending_Category.Items.AddRange(New Object() {"SSS_NO", "PAGIBIG_NO", "TIN_NO", "PHIL_HEALTH_NO", "BANK_NAME"})
        Me.Cmb_Pending_Category.Location = New System.Drawing.Point(122, 21)
        Me.Cmb_Pending_Category.Name = "Cmb_Pending_Category"
        Me.Cmb_Pending_Category.Size = New System.Drawing.Size(172, 28)
        Me.Cmb_Pending_Category.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 18)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Category:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(640, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(573, 20)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Pending Government Information (Pagibig No., SSS No., TIN No., Philhealth No.)"
        '
        'Btn_ShowPendingRecords
        '
        Me.Btn_ShowPendingRecords.ForeColor = System.Drawing.Color.Black
        Me.Btn_ShowPendingRecords.Location = New System.Drawing.Point(300, 21)
        Me.Btn_ShowPendingRecords.Name = "Btn_ShowPendingRecords"
        Me.Btn_ShowPendingRecords.Size = New System.Drawing.Size(165, 28)
        Me.Btn_ShowPendingRecords.TabIndex = 53
        Me.Btn_ShowPendingRecords.Text = "Show Records"
        Me.Btn_ShowPendingRecords.UseVisualStyleBackColor = True
        '
        'Lbl_Export_PendingDocs
        '
        Me.Lbl_Export_PendingDocs.AutoSize = True
        Me.Lbl_Export_PendingDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Export_PendingDocs.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Export_PendingDocs.Location = New System.Drawing.Point(1098, 570)
        Me.Lbl_Export_PendingDocs.Name = "Lbl_Export_PendingDocs"
        Me.Lbl_Export_PendingDocs.Size = New System.Drawing.Size(115, 20)
        Me.Lbl_Export_PendingDocs.TabIndex = 52
        Me.Lbl_Export_PendingDocs.Text = "Export to Excel"
        '
        'LV_Pending_List
        '
        Me.LV_Pending_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Pending_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_Pending_EmpID, Me.ColumnHeader5, Me.ColRec_Datehired, Me.ColumnHeader7, Me.Col_Gov_IDs})
        Me.LV_Pending_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Pending_List.FullRowSelect = True
        Me.LV_Pending_List.GridLines = True
        Me.LV_Pending_List.HideSelection = False
        Me.LV_Pending_List.Location = New System.Drawing.Point(31, 58)
        Me.LV_Pending_List.Name = "LV_Pending_List"
        Me.LV_Pending_List.Size = New System.Drawing.Size(1182, 498)
        Me.LV_Pending_List.TabIndex = 50
        Me.LV_Pending_List.UseCompatibleStateImageBehavior = False
        Me.LV_Pending_List.View = System.Windows.Forms.View.Details
        '
        'Col_Pending_EmpID
        '
        Me.Col_Pending_EmpID.Text = "Emp ID"
        Me.Col_Pending_EmpID.Width = 110
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Name"
        Me.ColumnHeader5.Width = 270
        '
        'ColRec_Datehired
        '
        Me.ColRec_Datehired.Text = "Date Hired"
        Me.ColRec_Datehired.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Client"
        Me.ColumnHeader7.Width = 410
        '
        'Col_Gov_IDs
        '
        Me.Col_Gov_IDs.Text = "Remarks"
        Me.Col_Gov_IDs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Gov_IDs.Width = 235
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1250, 621)
        Me.TabPage4.TabIndex = 11
        Me.TabPage4.Text = "Leave Status"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Location = New System.Drawing.Point(16, 15)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1155, 586)
        Me.TabControl2.TabIndex = 140
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage5.Controls.Add(Me.Lbl_Export_LeaveStatus)
        Me.TabPage5.Controls.Add(Me.Cmb_LeaveType)
        Me.TabPage5.Controls.Add(Me.Label16)
        Me.TabPage5.Controls.Add(Me.Btn_Show_Leave)
        Me.TabPage5.Controls.Add(Me.Txt_Leave_DateTo)
        Me.TabPage5.Controls.Add(Me.DP_Leave_DateTo)
        Me.TabPage5.Controls.Add(Me.Label11)
        Me.TabPage5.Controls.Add(Me.Txt_Leave_DateFrom)
        Me.TabPage5.Controls.Add(Me.DP_Leave_DateFrom)
        Me.TabPage5.Controls.Add(Me.Label12)
        Me.TabPage5.Controls.Add(Me.LV_Leave_List)
        Me.TabPage5.Location = New System.Drawing.Point(4, 29)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1147, 553)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.Text = "Filed Leave and Suspension"
        '
        'Lbl_Export_LeaveStatus
        '
        Me.Lbl_Export_LeaveStatus.AutoSize = True
        Me.Lbl_Export_LeaveStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Export_LeaveStatus.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Export_LeaveStatus.Location = New System.Drawing.Point(993, 515)
        Me.Lbl_Export_LeaveStatus.Name = "Lbl_Export_LeaveStatus"
        Me.Lbl_Export_LeaveStatus.Size = New System.Drawing.Size(115, 20)
        Me.Lbl_Export_LeaveStatus.TabIndex = 242
        Me.Lbl_Export_LeaveStatus.Text = "Export to Excel"
        '
        'Cmb_LeaveType
        '
        Me.Cmb_LeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_LeaveType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_LeaveType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_LeaveType.FormattingEnabled = True
        Me.Cmb_LeaveType.Items.AddRange(New Object() {"Vacation Leave", "Emergency Leave", "Sick Leave", "Maternity Leave", "Paternity Leave", "All"})
        Me.Cmb_LeaveType.Location = New System.Drawing.Point(145, 28)
        Me.Cmb_LeaveType.Name = "Cmb_LeaveType"
        Me.Cmb_LeaveType.Size = New System.Drawing.Size(185, 28)
        Me.Cmb_LeaveType.TabIndex = 240
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(50, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 20)
        Me.Label16.TabIndex = 241
        Me.Label16.Text = "Type:"
        '
        'Btn_Show_Leave
        '
        Me.Btn_Show_Leave.ForeColor = System.Drawing.Color.Black
        Me.Btn_Show_Leave.Location = New System.Drawing.Point(686, 58)
        Me.Btn_Show_Leave.Name = "Btn_Show_Leave"
        Me.Btn_Show_Leave.Size = New System.Drawing.Size(123, 34)
        Me.Btn_Show_Leave.TabIndex = 147
        Me.Btn_Show_Leave.Text = "Show"
        Me.Btn_Show_Leave.UseVisualStyleBackColor = True
        '
        'Txt_Leave_DateTo
        '
        Me.Txt_Leave_DateTo.Enabled = False
        Me.Txt_Leave_DateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Leave_DateTo.Location = New System.Drawing.Point(458, 62)
        Me.Txt_Leave_DateTo.Name = "Txt_Leave_DateTo"
        Me.Txt_Leave_DateTo.Size = New System.Drawing.Size(187, 26)
        Me.Txt_Leave_DateTo.TabIndex = 146
        Me.Txt_Leave_DateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Leave_DateTo
        '
        Me.DP_Leave_DateTo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Leave_DateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Leave_DateTo.Location = New System.Drawing.Point(648, 62)
        Me.DP_Leave_DateTo.Name = "DP_Leave_DateTo"
        Me.DP_Leave_DateTo.Size = New System.Drawing.Size(17, 26)
        Me.DP_Leave_DateTo.TabIndex = 144
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(382, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 20)
        Me.Label11.TabIndex = 145
        Me.Label11.Text = "Date To:"
        '
        'Txt_Leave_DateFrom
        '
        Me.Txt_Leave_DateFrom.Enabled = False
        Me.Txt_Leave_DateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Leave_DateFrom.Location = New System.Drawing.Point(145, 62)
        Me.Txt_Leave_DateFrom.Name = "Txt_Leave_DateFrom"
        Me.Txt_Leave_DateFrom.Size = New System.Drawing.Size(187, 26)
        Me.Txt_Leave_DateFrom.TabIndex = 143
        Me.Txt_Leave_DateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Leave_DateFrom
        '
        Me.DP_Leave_DateFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Leave_DateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Leave_DateFrom.Location = New System.Drawing.Point(335, 62)
        Me.DP_Leave_DateFrom.Name = "DP_Leave_DateFrom"
        Me.DP_Leave_DateFrom.Size = New System.Drawing.Size(17, 26)
        Me.DP_Leave_DateFrom.TabIndex = 141
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(50, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 20)
        Me.Label12.TabIndex = 142
        Me.Label12.Text = "Date From:"
        '
        'LV_Leave_List
        '
        Me.LV_Leave_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Leave_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.Col_Leave_Start, Me.Col_Leave_End, Me.ColumnHeader16})
        Me.LV_Leave_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Leave_List.FullRowSelect = True
        Me.LV_Leave_List.GridLines = True
        Me.LV_Leave_List.HideSelection = False
        Me.LV_Leave_List.Location = New System.Drawing.Point(30, 118)
        Me.LV_Leave_List.Name = "LV_Leave_List"
        Me.LV_Leave_List.Size = New System.Drawing.Size(1078, 385)
        Me.LV_Leave_List.TabIndex = 140
        Me.LV_Leave_List.UseCompatibleStateImageBehavior = False
        Me.LV_Leave_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Emp ID"
        Me.ColumnHeader9.Width = 110
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Name"
        Me.ColumnHeader10.Width = 250
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Leave Type"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader11.Width = 140
        '
        'Col_Leave_Start
        '
        Me.Col_Leave_Start.Text = "Start Date"
        Me.Col_Leave_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Leave_Start.Width = 130
        '
        'Col_Leave_End
        '
        Me.Col_Leave_End.Text = "End Date"
        Me.Col_Leave_End.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Leave_End.Width = 130
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Client Name"
        Me.ColumnHeader16.Width = 310
        '
        'Tab_Client
        '
        Me.Tab_Client.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tab_Client.Controls.Add(Me.TabControl3)
        Me.Tab_Client.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Client.Name = "Tab_Client"
        Me.Tab_Client.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Client.Size = New System.Drawing.Size(1250, 621)
        Me.Tab_Client.TabIndex = 12
        Me.Tab_Client.Text = "Client Statistics"
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage2)
        Me.TabControl3.Controls.Add(Me.TabPage3)
        Me.TabControl3.Controls.Add(Me.TabPage6)
        Me.TabControl3.Location = New System.Drawing.Point(21, 33)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(1204, 563)
        Me.TabControl3.TabIndex = 151
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.BtnExport_MainClientCount)
        Me.TabPage2.Controls.Add(Me.LV_Client_Count)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Txt_Active_MainClient)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Txt_Active_SubClient)
        Me.TabPage2.Controls.Add(Me.Btn_Client_Show)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1196, 530)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Client Count"
        '
        'BtnExport_MainClientCount
        '
        Me.BtnExport_MainClientCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExport_MainClientCount.IconChar = FontAwesome.Sharp.IconChar.ShareFromSquare
        Me.BtnExport_MainClientCount.IconColor = System.Drawing.Color.Green
        Me.BtnExport_MainClientCount.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.BtnExport_MainClientCount.IconSize = 40
        Me.BtnExport_MainClientCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExport_MainClientCount.Location = New System.Drawing.Point(1125, 453)
        Me.BtnExport_MainClientCount.Name = "BtnExport_MainClientCount"
        Me.BtnExport_MainClientCount.Size = New System.Drawing.Size(48, 43)
        Me.BtnExport_MainClientCount.TabIndex = 160
        Me.BtnExport_MainClientCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExport_MainClientCount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnExport_MainClientCount.UseVisualStyleBackColor = True
        '
        'LV_Client_Count
        '
        Me.LV_Client_Count.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Client_Count.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader4, Me.ColumnHeader6})
        Me.LV_Client_Count.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Client_Count.FullRowSelect = True
        Me.LV_Client_Count.GridLines = True
        Me.LV_Client_Count.HideSelection = False
        Me.LV_Client_Count.Location = New System.Drawing.Point(451, 42)
        Me.LV_Client_Count.Name = "LV_Client_Count"
        Me.LV_Client_Count.Size = New System.Drawing.Size(668, 454)
        Me.LV_Client_Count.TabIndex = 156
        Me.LV_Client_Count.UseCompatibleStateImageBehavior = False
        Me.LV_Client_Count.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Item"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Active Main Client"
        Me.ColumnHeader4.Width = 400
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Sub Client Count"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 200
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(49, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(222, 20)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "Number of active Main Clients:"
        '
        'Txt_Active_MainClient
        '
        Me.Txt_Active_MainClient.Enabled = False
        Me.Txt_Active_MainClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Active_MainClient.Location = New System.Drawing.Point(272, 104)
        Me.Txt_Active_MainClient.Name = "Txt_Active_MainClient"
        Me.Txt_Active_MainClient.Size = New System.Drawing.Size(107, 26)
        Me.Txt_Active_MainClient.TabIndex = 154
        Me.Txt_Active_MainClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(49, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(217, 20)
        Me.Label14.TabIndex = 153
        Me.Label14.Text = "Number of active Sub Clients:"
        '
        'Txt_Active_SubClient
        '
        Me.Txt_Active_SubClient.Enabled = False
        Me.Txt_Active_SubClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Active_SubClient.Location = New System.Drawing.Point(272, 145)
        Me.Txt_Active_SubClient.Name = "Txt_Active_SubClient"
        Me.Txt_Active_SubClient.Size = New System.Drawing.Size(107, 26)
        Me.Txt_Active_SubClient.TabIndex = 152
        Me.Txt_Active_SubClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_Client_Show
        '
        Me.Btn_Client_Show.ForeColor = System.Drawing.Color.Black
        Me.Btn_Client_Show.Location = New System.Drawing.Point(53, 42)
        Me.Btn_Client_Show.Name = "Btn_Client_Show"
        Me.Btn_Client_Show.Size = New System.Drawing.Size(159, 29)
        Me.Btn_Client_Show.TabIndex = 151
        Me.Btn_Client_Show.Text = "Show"
        Me.Btn_Client_Show.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Btn_Export_SubClient_Count)
        Me.TabPage3.Controls.Add(Me.Btn_Show_SubClient_EmpCount)
        Me.TabPage3.Controls.Add(Me.LV_SubClient_EmployeeCount)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1196, 530)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Sub Client Count"
        '
        'Btn_Export_SubClient_Count
        '
        Me.Btn_Export_SubClient_Count.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Export_SubClient_Count.IconChar = FontAwesome.Sharp.IconChar.ShareFromSquare
        Me.Btn_Export_SubClient_Count.IconColor = System.Drawing.Color.Green
        Me.Btn_Export_SubClient_Count.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Export_SubClient_Count.IconSize = 40
        Me.Btn_Export_SubClient_Count.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Export_SubClient_Count.Location = New System.Drawing.Point(1123, 449)
        Me.Btn_Export_SubClient_Count.Name = "Btn_Export_SubClient_Count"
        Me.Btn_Export_SubClient_Count.Size = New System.Drawing.Size(48, 43)
        Me.Btn_Export_SubClient_Count.TabIndex = 159
        Me.Btn_Export_SubClient_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Export_SubClient_Count.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Export_SubClient_Count.UseVisualStyleBackColor = True
        '
        'Btn_Show_SubClient_EmpCount
        '
        Me.Btn_Show_SubClient_EmpCount.ForeColor = System.Drawing.Color.Black
        Me.Btn_Show_SubClient_EmpCount.Location = New System.Drawing.Point(41, 38)
        Me.Btn_Show_SubClient_EmpCount.Name = "Btn_Show_SubClient_EmpCount"
        Me.Btn_Show_SubClient_EmpCount.Size = New System.Drawing.Size(159, 29)
        Me.Btn_Show_SubClient_EmpCount.TabIndex = 158
        Me.Btn_Show_SubClient_EmpCount.Text = "Show"
        Me.Btn_Show_SubClient_EmpCount.UseVisualStyleBackColor = True
        '
        'LV_SubClient_EmployeeCount
        '
        Me.LV_SubClient_EmployeeCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_SubClient_EmployeeCount.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.LV_SubClient_EmployeeCount.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_SubClient_EmployeeCount.FullRowSelect = True
        Me.LV_SubClient_EmployeeCount.GridLines = True
        Me.LV_SubClient_EmployeeCount.HideSelection = False
        Me.LV_SubClient_EmployeeCount.Location = New System.Drawing.Point(249, 38)
        Me.LV_SubClient_EmployeeCount.Name = "LV_SubClient_EmployeeCount"
        Me.LV_SubClient_EmployeeCount.Size = New System.Drawing.Size(868, 454)
        Me.LV_SubClient_EmployeeCount.TabIndex = 157
        Me.LV_SubClient_EmployeeCount.UseCompatibleStateImageBehavior = False
        Me.LV_SubClient_EmployeeCount.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Item"
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Sub Client Name"
        Me.ColumnHeader13.Width = 600
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Employee Count"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader14.Width = 200
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.Btn_Export_Employee_Count)
        Me.TabPage6.Controls.Add(Me.Btn_Show_MainClient_EmpCount)
        Me.TabPage6.Controls.Add(Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT)
        Me.TabPage6.Location = New System.Drawing.Point(4, 29)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1196, 530)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Employee Count"
        '
        'Btn_Export_Employee_Count
        '
        Me.Btn_Export_Employee_Count.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Export_Employee_Count.IconChar = FontAwesome.Sharp.IconChar.ShareFromSquare
        Me.Btn_Export_Employee_Count.IconColor = System.Drawing.Color.Green
        Me.Btn_Export_Employee_Count.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Export_Employee_Count.IconSize = 40
        Me.Btn_Export_Employee_Count.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Export_Employee_Count.Location = New System.Drawing.Point(922, 451)
        Me.Btn_Export_Employee_Count.Name = "Btn_Export_Employee_Count"
        Me.Btn_Export_Employee_Count.Size = New System.Drawing.Size(48, 43)
        Me.Btn_Export_Employee_Count.TabIndex = 161
        Me.Btn_Export_Employee_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Export_Employee_Count.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Export_Employee_Count.UseVisualStyleBackColor = True
        '
        'Btn_Show_MainClient_EmpCount
        '
        Me.Btn_Show_MainClient_EmpCount.ForeColor = System.Drawing.Color.Black
        Me.Btn_Show_MainClient_EmpCount.Location = New System.Drawing.Point(40, 40)
        Me.Btn_Show_MainClient_EmpCount.Name = "Btn_Show_MainClient_EmpCount"
        Me.Btn_Show_MainClient_EmpCount.Size = New System.Drawing.Size(159, 29)
        Me.Btn_Show_MainClient_EmpCount.TabIndex = 160
        Me.Btn_Show_MainClient_EmpCount.Text = "Show"
        Me.Btn_Show_MainClient_EmpCount.UseVisualStyleBackColor = True
        '
        'LV_MAIN_CLIENT_EMPLOYEE_COUNT
        '
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader15, Me.ColumnHeader17, Me.ColumnHeader18})
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.FullRowSelect = True
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.GridLines = True
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.HideSelection = False
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Location = New System.Drawing.Point(248, 40)
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Name = "LV_MAIN_CLIENT_EMPLOYEE_COUNT"
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Size = New System.Drawing.Size(668, 454)
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.TabIndex = 159
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.UseCompatibleStateImageBehavior = False
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Item"
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Main Client Name"
        Me.ColumnHeader17.Width = 400
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Active Employees"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader18.Width = 200
        '
        'ReportsWorkspaceRoot
        '
        Me.ReportsWorkspaceRoot.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.ReportsWorkspaceRoot.ColumnCount = 1
        Me.ReportsWorkspaceRoot.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ReportsWorkspaceRoot.Controls.Add(Me.ReportsHeaderPanel, 0, 0)
        Me.ReportsWorkspaceRoot.Controls.Add(Me.ReportsBodyPanel, 0, 1)
        Me.ReportsWorkspaceRoot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportsWorkspaceRoot.Location = New System.Drawing.Point(0, 0)
        Me.ReportsWorkspaceRoot.Margin = New System.Windows.Forms.Padding(0)
        Me.ReportsWorkspaceRoot.Name = "ReportsWorkspaceRoot"
        Me.ReportsWorkspaceRoot.RowCount = 2
        Me.ReportsWorkspaceRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.ReportsWorkspaceRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ReportsWorkspaceRoot.Size = New System.Drawing.Size(1440, 860)
        Me.ReportsWorkspaceRoot.TabIndex = 200
        '
        'ReportsHeaderPanel
        '
        Me.ReportsHeaderPanel.BackColor = System.Drawing.Color.FromArgb(68, 18, 31)
        Me.ReportsHeaderPanel.Controls.Add(Me.ReportsSectionLabel)
        Me.ReportsHeaderPanel.Controls.Add(Me.ReportsCloseButton)
        Me.ReportsHeaderPanel.Controls.Add(Me.ReportsSubtitleLabel)
        Me.ReportsHeaderPanel.Controls.Add(Me.ReportsTitleLabel)
        Me.ReportsHeaderPanel.Controls.Add(Me.ReportsLogo)
        Me.ReportsHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportsHeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.ReportsHeaderPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ReportsHeaderPanel.Name = "ReportsHeaderPanel"
        Me.ReportsHeaderPanel.Padding = New System.Windows.Forms.Padding(24, 14, 24, 12)
        Me.ReportsHeaderPanel.Size = New System.Drawing.Size(1440, 94)
        Me.ReportsHeaderPanel.TabIndex = 0
        '
        'ReportsLogo
        '
        Me.ReportsLogo.BackColor = System.Drawing.Color.Transparent
        Me.ReportsLogo.Dock = System.Windows.Forms.DockStyle.Left
        Me.ReportsLogo.Image = Global.DMSA_System.My.Resources.Resources.DeltaMaroon_NoBg
        Me.ReportsLogo.Location = New System.Drawing.Point(24, 14)
        Me.ReportsLogo.Name = "ReportsLogo"
        Me.ReportsLogo.Size = New System.Drawing.Size(62, 68)
        Me.ReportsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ReportsLogo.TabIndex = 0
        Me.ReportsLogo.TabStop = False
        '
        'ReportsTitleLabel
        '
        Me.ReportsTitleLabel.AutoSize = True
        Me.ReportsTitleLabel.BackColor = System.Drawing.Color.Transparent
        Me.ReportsTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 18.0!, System.Drawing.FontStyle.Regular)
        Me.ReportsTitleLabel.ForeColor = System.Drawing.Color.White
        Me.ReportsTitleLabel.Location = New System.Drawing.Point(104, 20)
        Me.ReportsTitleLabel.Name = "ReportsTitleLabel"
        Me.ReportsTitleLabel.Size = New System.Drawing.Size(377, 29)
        Me.ReportsTitleLabel.TabIndex = 1
        Me.ReportsTitleLabel.Text = "HUMAN RESOURCES  /  REPORTS"
        '
        'ReportsSubtitleLabel
        '
        Me.ReportsSubtitleLabel.AutoSize = True
        Me.ReportsSubtitleLabel.BackColor = System.Drawing.Color.Transparent
        Me.ReportsSubtitleLabel.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.ReportsSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(223, 207, 212)
        Me.ReportsSubtitleLabel.Location = New System.Drawing.Point(106, 58)
        Me.ReportsSubtitleLabel.Name = "ReportsSubtitleLabel"
        Me.ReportsSubtitleLabel.Size = New System.Drawing.Size(425, 17)
        Me.ReportsSubtitleLabel.TabIndex = 2
        Me.ReportsSubtitleLabel.Text = "Compliance, workforce and client records in one reporting workspace"
        '
        'ReportsSectionLabel
        '
        Me.ReportsSectionLabel.BackColor = System.Drawing.Color.Transparent
        Me.ReportsSectionLabel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ReportsSectionLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 11.0!, System.Drawing.FontStyle.Regular)
        Me.ReportsSectionLabel.ForeColor = System.Drawing.Color.FromArgb(245, 205, 112)
        Me.ReportsSectionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportsSectionLabel.Dock = System.Windows.Forms.DockStyle.None
        Me.ReportsSectionLabel.Location = New System.Drawing.Point(1080, 14)
        Me.ReportsSectionLabel.Name = "ReportsSectionLabel"
        Me.ReportsSectionLabel.Size = New System.Drawing.Size(220, 68)
        Me.ReportsSectionLabel.TabIndex = 3
        Me.ReportsSectionLabel.Text = "COMPLIANCE"
        Me.ReportsSectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ReportsCloseButton
        '
        Me.ReportsCloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportsCloseButton.BackColor = System.Drawing.Color.White
        Me.ReportsCloseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReportsCloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(245, 205, 112)
        Me.ReportsCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ReportsCloseButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.ReportsCloseButton.ForeColor = System.Drawing.Color.FromArgb(68, 18, 31)
        Me.ReportsCloseButton.Location = New System.Drawing.Point(1316, 29)
        Me.ReportsCloseButton.Name = "ReportsCloseButton"
        Me.ReportsCloseButton.Size = New System.Drawing.Size(100, 36)
        Me.ReportsCloseButton.TabIndex = 4
        Me.ReportsCloseButton.Text = "Close"
        Me.ReportsCloseButton.UseVisualStyleBackColor = False
        '
        'ReportsBodyPanel
        '
        Me.ReportsBodyPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.ReportsBodyPanel.Controls.Add(Me.ReportsContentHost)
        Me.ReportsBodyPanel.Controls.Add(Me.ReportsNavPanel)
        Me.ReportsBodyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportsBodyPanel.Location = New System.Drawing.Point(0, 94)
        Me.ReportsBodyPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ReportsBodyPanel.Name = "ReportsBodyPanel"
        Me.ReportsBodyPanel.Padding = New System.Windows.Forms.Padding(18, 14, 18, 18)
        Me.ReportsBodyPanel.Size = New System.Drawing.Size(1440, 766)
        Me.ReportsBodyPanel.TabIndex = 1
        '
        'ReportsNavPanel
        '
        Me.ReportsNavPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.ReportsNavPanel.Controls.Add(Me.ReportsNavInfoPanel)
        Me.ReportsNavPanel.Controls.Add(Me.NavAuditButton)
        Me.ReportsNavPanel.Controls.Add(Me.NavClientsButton)
        Me.ReportsNavPanel.Controls.Add(Me.NavWorkforceButton)
        Me.ReportsNavPanel.Controls.Add(Me.NavLeaveButton)
        Me.ReportsNavPanel.Controls.Add(Me.NavMissingButton)
        Me.ReportsNavPanel.Controls.Add(Me.NavComplianceButton)
        Me.ReportsNavPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.ReportsNavPanel.Location = New System.Drawing.Point(18, 14)
        Me.ReportsNavPanel.Name = "ReportsNavPanel"
        Me.ReportsNavPanel.Size = New System.Drawing.Size(196, 734)
        Me.ReportsNavPanel.TabIndex = 0
        '
        'ReportsContentHost
        '
        Me.ReportsContentHost.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.ReportsContentHost.Controls.Add(Me.Tab_Recruitment)
        Me.ReportsContentHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportsContentHost.Location = New System.Drawing.Point(214, 14)
        Me.ReportsContentHost.Name = "ReportsContentHost"
        Me.ReportsContentHost.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.ReportsContentHost.Size = New System.Drawing.Size(1208, 734)
        Me.ReportsContentHost.TabIndex = 1
        '
        'Report navigation buttons
        '
        Me.NavComplianceButton.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.NavComplianceButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NavComplianceButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavComplianceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(111, 29, 48)
        Me.NavComplianceButton.FlatAppearance.BorderSize = 2
        Me.NavComplianceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NavComplianceButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular)
        Me.NavComplianceButton.ForeColor = System.Drawing.Color.FromArgb(111, 29, 48)
        Me.NavComplianceButton.Location = New System.Drawing.Point(0, 0)
        Me.NavComplianceButton.Name = "NavComplianceButton"
        Me.NavComplianceButton.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.NavComplianceButton.Size = New System.Drawing.Size(196, 58)
        Me.NavComplianceButton.TabIndex = 0
        Me.NavComplianceButton.Tag = "0"
        Me.NavComplianceButton.Text = "CO    Compliance"
        Me.NavComplianceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavComplianceButton.UseVisualStyleBackColor = False
        Me.NavMissingButton.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.NavMissingButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NavMissingButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavMissingButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.NavMissingButton.FlatAppearance.BorderSize = 1
        Me.NavMissingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NavMissingButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular)
        Me.NavMissingButton.Location = New System.Drawing.Point(0, 58)
        Me.NavMissingButton.Name = "NavMissingButton"
        Me.NavMissingButton.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.NavMissingButton.Size = New System.Drawing.Size(196, 58)
        Me.NavMissingButton.TabIndex = 1
        Me.NavMissingButton.Tag = "1"
        Me.NavMissingButton.Text = "MR    Missing records"
        Me.NavMissingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavMissingButton.UseVisualStyleBackColor = False
        Me.NavLeaveButton.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.NavLeaveButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NavLeaveButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavLeaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.NavLeaveButton.FlatAppearance.BorderSize = 1
        Me.NavLeaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NavLeaveButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular)
        Me.NavLeaveButton.Location = New System.Drawing.Point(0, 116)
        Me.NavLeaveButton.Name = "NavLeaveButton"
        Me.NavLeaveButton.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.NavLeaveButton.Size = New System.Drawing.Size(196, 58)
        Me.NavLeaveButton.TabIndex = 2
        Me.NavLeaveButton.Tag = "2"
        Me.NavLeaveButton.Text = "LR    Leave records"
        Me.NavLeaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavLeaveButton.UseVisualStyleBackColor = False
        Me.NavWorkforceButton.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.NavWorkforceButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NavWorkforceButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavWorkforceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.NavWorkforceButton.FlatAppearance.BorderSize = 1
        Me.NavWorkforceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NavWorkforceButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular)
        Me.NavWorkforceButton.Location = New System.Drawing.Point(0, 174)
        Me.NavWorkforceButton.Name = "NavWorkforceButton"
        Me.NavWorkforceButton.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.NavWorkforceButton.Size = New System.Drawing.Size(196, 58)
        Me.NavWorkforceButton.TabIndex = 3
        Me.NavWorkforceButton.Tag = "3"
        Me.NavWorkforceButton.Text = "WF    Workforce"
        Me.NavWorkforceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavWorkforceButton.UseVisualStyleBackColor = False
        Me.NavClientsButton.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.NavClientsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NavClientsButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavClientsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.NavClientsButton.FlatAppearance.BorderSize = 1
        Me.NavClientsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NavClientsButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular)
        Me.NavClientsButton.Location = New System.Drawing.Point(0, 232)
        Me.NavClientsButton.Name = "NavClientsButton"
        Me.NavClientsButton.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.NavClientsButton.Size = New System.Drawing.Size(196, 58)
        Me.NavClientsButton.TabIndex = 4
        Me.NavClientsButton.Tag = "4"
        Me.NavClientsButton.Text = "CC    Client coverage"
        Me.NavClientsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavClientsButton.UseVisualStyleBackColor = False
        Me.NavAuditButton.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.NavAuditButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NavAuditButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavAuditButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.NavAuditButton.FlatAppearance.BorderSize = 1
        Me.NavAuditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NavAuditButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular)
        Me.NavAuditButton.Location = New System.Drawing.Point(0, 290)
        Me.NavAuditButton.Name = "NavAuditButton"
        Me.NavAuditButton.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.NavAuditButton.Size = New System.Drawing.Size(196, 58)
        Me.NavAuditButton.TabIndex = 5
        Me.NavAuditButton.Tag = "5"
        Me.NavAuditButton.Text = "AL    Audit log"
        Me.NavAuditButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavAuditButton.UseVisualStyleBackColor = False
        '
        'ReportsNavInfoPanel
        '
        Me.ReportsNavInfoPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportsNavInfoPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.ReportsNavInfoPanel.Controls.Add(Me.ReportsNavInfoBody)
        Me.ReportsNavInfoPanel.Controls.Add(Me.ReportsNavInfoTitle)
        Me.ReportsNavInfoPanel.Location = New System.Drawing.Point(0, 348)
        Me.ReportsNavInfoPanel.Name = "ReportsNavInfoPanel"
        Me.ReportsNavInfoPanel.Padding = New System.Windows.Forms.Padding(14)
        Me.ReportsNavInfoPanel.Size = New System.Drawing.Size(196, 386)
        Me.ReportsNavInfoPanel.TabIndex = 2
        Me.ReportsNavInfoPanel.BringToFront()
        '
        'ReportsNavInfoTitle
        '
        Me.ReportsNavInfoTitle.AutoSize = True
        Me.ReportsNavInfoTitle.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.ReportsNavInfoTitle.ForeColor = System.Drawing.Color.Teal
        Me.ReportsNavInfoTitle.Location = New System.Drawing.Point(14, 16)
        Me.ReportsNavInfoTitle.Name = "ReportsNavInfoTitle"
        Me.ReportsNavInfoTitle.Text = "REPORT GUIDE"
        '
        'ReportsNavInfoBody
        '
        Me.ReportsNavInfoBody.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Regular)
        Me.ReportsNavInfoBody.ForeColor = System.Drawing.Color.FromArgb(74, 55, 32)
        Me.ReportsNavInfoBody.Location = New System.Drawing.Point(14, 48)
        Me.ReportsNavInfoBody.Name = "ReportsNavInfoBody"
        Me.ReportsNavInfoBody.Size = New System.Drawing.Size(168, 130)
        Me.ReportsNavInfoBody.Text = "Choose a report category." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Apply filters to load records." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Export the current view to Excel."
        '
        'Tab_Recruitment - redesigned navigation
        '
        Me.Tab_Recruitment.Alignment = System.Windows.Forms.TabAlignment.Top
        Me.Tab_Recruitment.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.Tab_Recruitment.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Tab_Recruitment.Cursor = System.Windows.Forms.Cursors.Default
        Me.Tab_Recruitment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab_Recruitment.DrawMode = System.Windows.Forms.TabDrawMode.Normal
        Me.Tab_Recruitment.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular)
        Me.Tab_Recruitment.ItemSize = New System.Drawing.Size(0, 1)
        Me.Tab_Recruitment.Location = New System.Drawing.Point(14, 0)
        Me.Tab_Recruitment.Padding = New System.Drawing.Point(0, 0)
        Me.Tab_Recruitment.Size = New System.Drawing.Size(1194, 734)
        Me.Tab_Recruitment.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        '
        'Top-level report pages
        '
        Me.Tab_Security_License.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Tab_Security_License.Padding = New System.Windows.Forms.Padding(12)
        Me.Tab_Security_License.Text = "Compliance"
        Me.Tab_Pending_Docs.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Tab_Pending_Docs.Padding = New System.Windows.Forms.Padding(0)
        Me.Tab_Pending_Docs.Text = "Missing records"
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(0)
        Me.TabPage4.Text = "Leave records"
        Me.Tab_HR1.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Tab_HR1.Padding = New System.Windows.Forms.Padding(0)
        Me.Tab_HR1.Text = "Workforce"
        Me.Tab_Client.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Tab_Client.Padding = New System.Windows.Forms.Padding(12)
        Me.Tab_Client.Text = "Client coverage"
        Me.Tab_Logs.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Tab_Logs.Padding = New System.Windows.Forms.Padding(0)
        Me.Tab_Logs.Text = "Audit log"
        '
        'Compliance tab host
        '
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.25!, System.Drawing.FontStyle.Regular)
        Me.TabControl1.ItemSize = New System.Drawing.Size(185, 38)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.TabPage1.Text = "Employee credentials"
        Me.TabPage7.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.TabPage7.Text = "Client contracts"
        '
        'Employee credential page
        '
        Me.EmpExpiryTitleLabel.AutoSize = True
        Me.EmpExpiryTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.EmpExpiryTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.EmpExpiryTitleLabel.Location = New System.Drawing.Point(28, 22)
        Me.EmpExpiryTitleLabel.Name = "EmpExpiryTitleLabel"
        Me.EmpExpiryTitleLabel.Text = "Employee credential expiry"
        Me.EmpExpiryDescriptionLabel.AutoSize = True
        Me.EmpExpiryDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.EmpExpiryDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.EmpExpiryDescriptionLabel.Location = New System.Drawing.Point(29, 54)
        Me.EmpExpiryDescriptionLabel.Name = "EmpExpiryDescriptionLabel"
        Me.EmpExpiryDescriptionLabel.Text = "Track medical, licence and insurance renewals before they interrupt deployment."
        Me.EmpExpiryFilterPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EmpExpiryFilterPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.EmpExpiryFilterPanel.Controls.Add(Me.Label10)
        Me.EmpExpiryFilterPanel.Controls.Add(Me.Cmb_Exp_Category)
        Me.EmpExpiryFilterPanel.Controls.Add(Me.Label1)
        Me.EmpExpiryFilterPanel.Controls.Add(Me.Cmb_Expiry_Status)
        Me.EmpExpiryFilterPanel.Controls.Add(Me.Label3)
        Me.EmpExpiryFilterPanel.Location = New System.Drawing.Point(24, 86)
        Me.EmpExpiryFilterPanel.Name = "EmpExpiryFilterPanel"
        Me.EmpExpiryFilterPanel.Size = New System.Drawing.Size(1110, 58)
        Me.Label10.Location = New System.Drawing.Point(18, 19)
        Me.Label10.Text = "Category:"
        Me.Cmb_Exp_Category.Location = New System.Drawing.Point(96, 15)
        Me.Cmb_Exp_Category.Size = New System.Drawing.Size(180, 25)
        Me.Label1.Location = New System.Drawing.Point(306, 19)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label1.Text = "Expiration:"
        Me.Cmb_Expiry_Status.Location = New System.Drawing.Point(390, 15)
        Me.Cmb_Expiry_Status.Size = New System.Drawing.Size(180, 25)
        Me.Label3.Location = New System.Drawing.Point(598, 19)
        Me.Label3.Text = "For active employees only."
        Me.LV_Expiry_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Expiry_List.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_Expiry_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_Expiry_List.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_Expiry_List.Location = New System.Drawing.Point(24, 156)
        Me.LV_Expiry_List.Size = New System.Drawing.Size(1110, 330)
        Me.Lbl_Export_SecLicense.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Export_SecLicense.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.Lbl_Export_SecLicense.ForeColor = System.Drawing.Color.White
        Me.Lbl_Export_SecLicense.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Lbl_Export_SecLicense.Location = New System.Drawing.Point(978, 500)
        Me.Lbl_Export_SecLicense.Size = New System.Drawing.Size(156, 36)
        Me.Lbl_Export_SecLicense.Text = "Export to Excel"
        Me.Lbl_Export_SecLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TabPage1.Controls.Add(Me.EmpExpiryTitleLabel)
        Me.TabPage1.Controls.Add(Me.EmpExpiryDescriptionLabel)
        Me.TabPage1.Controls.Add(Me.EmpExpiryFilterPanel)
        Me.TabPage1.Controls.Add(Me.LV_Expiry_List)
        Me.TabPage1.Controls.Add(Me.Lbl_Export_SecLicense)
        '
        'Client contract page
        '
        Me.ClientExpiryTitleLabel.AutoSize = True
        Me.ClientExpiryTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.ClientExpiryTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.ClientExpiryTitleLabel.Location = New System.Drawing.Point(28, 22)
        Me.ClientExpiryTitleLabel.Name = "ClientExpiryTitleLabel"
        Me.ClientExpiryTitleLabel.Text = "Client contract expiry"
        Me.ClientExpiryDescriptionLabel.AutoSize = True
        Me.ClientExpiryDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.ClientExpiryDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.ClientExpiryDescriptionLabel.Location = New System.Drawing.Point(29, 54)
        Me.ClientExpiryDescriptionLabel.Name = "ClientExpiryDescriptionLabel"
        Me.ClientExpiryDescriptionLabel.Text = "Review contract dates and prioritise client renewals."
        Me.ClientExpiryFilterPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClientExpiryFilterPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.ClientExpiryFilterPanel.Controls.Add(Me.Label17)
        Me.ClientExpiryFilterPanel.Controls.Add(Me.Cmb_Client_Expiration)
        Me.ClientExpiryFilterPanel.Location = New System.Drawing.Point(24, 86)
        Me.ClientExpiryFilterPanel.Name = "ClientExpiryFilterPanel"
        Me.ClientExpiryFilterPanel.Size = New System.Drawing.Size(1110, 58)
        Me.Label17.Location = New System.Drawing.Point(18, 19)
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label17.Text = "Expiration:"
        Me.Cmb_Client_Expiration.Location = New System.Drawing.Point(104, 15)
        Me.Cmb_Client_Expiration.Size = New System.Drawing.Size(190, 25)
        Me.LV_Client_Contract_Exp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Client_Contract_Exp.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_Client_Contract_Exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_Client_Contract_Exp.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_Client_Contract_Exp.Location = New System.Drawing.Point(24, 156)
        Me.LV_Client_Contract_Exp.Size = New System.Drawing.Size(1110, 330)
        Me.Lbl_Export_Client_Contract_Exp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Export_Client_Contract_Exp.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.Lbl_Export_Client_Contract_Exp.ForeColor = System.Drawing.Color.White
        Me.Lbl_Export_Client_Contract_Exp.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Lbl_Export_Client_Contract_Exp.Location = New System.Drawing.Point(978, 500)
        Me.Lbl_Export_Client_Contract_Exp.Size = New System.Drawing.Size(156, 36)
        Me.Lbl_Export_Client_Contract_Exp.Text = "Export to Excel"
        Me.Lbl_Export_Client_Contract_Exp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TabPage7.Controls.Add(Me.ClientExpiryTitleLabel)
        Me.TabPage7.Controls.Add(Me.ClientExpiryDescriptionLabel)
        Me.TabPage7.Controls.Add(Me.ClientExpiryFilterPanel)
        Me.TabPage7.Controls.Add(Me.LV_Client_Contract_Exp)
        Me.TabPage7.Controls.Add(Me.Lbl_Export_Client_Contract_Exp)
        '
        'Missing records page
        '
        Me.MissingTitleLabel.AutoSize = True
        Me.MissingTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.MissingTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.MissingTitleLabel.Location = New System.Drawing.Point(28, 24)
        Me.MissingTitleLabel.Name = "MissingTitleLabel"
        Me.MissingTitleLabel.Text = "Missing employee records"
        Me.MissingDescriptionLabel.AutoSize = True
        Me.MissingDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.MissingDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.MissingDescriptionLabel.Location = New System.Drawing.Point(29, 56)
        Me.MissingDescriptionLabel.Name = "MissingDescriptionLabel"
        Me.MissingDescriptionLabel.Text = "Find incomplete government, bank and payroll information by requirement."
        Me.MissingFilterPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MissingFilterPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.MissingFilterPanel.Controls.Add(Me.Label5)
        Me.MissingFilterPanel.Controls.Add(Me.Cmb_Pending_Category)
        Me.MissingFilterPanel.Controls.Add(Me.Btn_ShowPendingRecords)
        Me.MissingFilterPanel.Controls.Add(Me.Label9)
        Me.MissingFilterPanel.Location = New System.Drawing.Point(24, 88)
        Me.MissingFilterPanel.Name = "MissingFilterPanel"
        Me.MissingFilterPanel.Size = New System.Drawing.Size(1140, 58)
        Me.Label5.Location = New System.Drawing.Point(18, 19)
        Me.Cmb_Pending_Category.Location = New System.Drawing.Point(96, 15)
        Me.Cmb_Pending_Category.Size = New System.Drawing.Size(180, 25)
        Me.Btn_ShowPendingRecords.BackColor = System.Drawing.Color.Teal
        Me.Btn_ShowPendingRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_ShowPendingRecords.ForeColor = System.Drawing.Color.White
        Me.Btn_ShowPendingRecords.Location = New System.Drawing.Point(296, 11)
        Me.Btn_ShowPendingRecords.Size = New System.Drawing.Size(168, 36)
        Me.Btn_ShowPendingRecords.Text = "Show records"
        Me.Label9.Location = New System.Drawing.Point(492, 19)
        Me.Label9.Text = "Government, bank and payroll requirements"
        Me.LV_Pending_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Pending_List.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_Pending_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_Pending_List.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_Pending_List.Location = New System.Drawing.Point(24, 158)
        Me.LV_Pending_List.Size = New System.Drawing.Size(1140, 393)
        Me.Lbl_Export_PendingDocs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Export_PendingDocs.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.Lbl_Export_PendingDocs.ForeColor = System.Drawing.Color.White
        Me.Lbl_Export_PendingDocs.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Lbl_Export_PendingDocs.Location = New System.Drawing.Point(1008, 555)
        Me.Lbl_Export_PendingDocs.Size = New System.Drawing.Size(156, 36)
        Me.Lbl_Export_PendingDocs.Text = "Export to Excel"
        Me.Lbl_Export_PendingDocs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Tab_Pending_Docs.Controls.Add(Me.MissingTitleLabel)
        Me.Tab_Pending_Docs.Controls.Add(Me.MissingDescriptionLabel)
        Me.Tab_Pending_Docs.Controls.Add(Me.MissingFilterPanel)
        Me.Tab_Pending_Docs.Controls.Add(Me.LV_Pending_List)
        Me.Tab_Pending_Docs.Controls.Add(Me.Lbl_Export_PendingDocs)
        '
        'Leave records page
        '
        Me.LeaveTitleLabel.AutoSize = True
        Me.LeaveTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LeaveTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LeaveTitleLabel.Location = New System.Drawing.Point(28, 24)
        Me.LeaveTitleLabel.Name = "LeaveTitleLabel"
        Me.LeaveTitleLabel.Text = "Leave and suspension register"
        Me.LeaveDescriptionLabel.AutoSize = True
        Me.LeaveDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LeaveDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.LeaveDescriptionLabel.Location = New System.Drawing.Point(29, 56)
        Me.LeaveDescriptionLabel.Name = "LeaveDescriptionLabel"
        Me.LeaveDescriptionLabel.Text = "Review filed employee absences within a selected date range."
        Me.LeaveFilterPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LeaveFilterPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LeaveFilterPanel.Controls.Add(Me.Label16)
        Me.LeaveFilterPanel.Controls.Add(Me.Cmb_LeaveType)
        Me.LeaveFilterPanel.Controls.Add(Me.Label12)
        Me.LeaveFilterPanel.Controls.Add(Me.DP_Leave_DateFrom)
        Me.LeaveFilterPanel.Controls.Add(Me.Label11)
        Me.LeaveFilterPanel.Controls.Add(Me.DP_Leave_DateTo)
        Me.LeaveFilterPanel.Controls.Add(Me.Btn_Show_Leave)
        Me.LeaveFilterPanel.Location = New System.Drawing.Point(24, 88)
        Me.LeaveFilterPanel.Name = "LeaveFilterPanel"
        Me.LeaveFilterPanel.Size = New System.Drawing.Size(1140, 58)
        Me.Label16.Location = New System.Drawing.Point(18, 19)
        Me.Cmb_LeaveType.Location = New System.Drawing.Point(66, 15)
        Me.Cmb_LeaveType.Size = New System.Drawing.Size(160, 25)
        Me.Label12.Location = New System.Drawing.Point(250, 19)
        Me.Label12.Text = "Date from:"
        Me.DP_Leave_DateFrom.CustomFormat = "dd-MMM-yyyy"
        Me.DP_Leave_DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Leave_DateFrom.Location = New System.Drawing.Point(326, 15)
        Me.DP_Leave_DateFrom.Size = New System.Drawing.Size(154, 25)
        Me.Label11.Location = New System.Drawing.Point(504, 19)
        Me.Label11.Text = "Date to:"
        Me.DP_Leave_DateTo.CustomFormat = "dd-MMM-yyyy"
        Me.DP_Leave_DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Leave_DateTo.Location = New System.Drawing.Point(562, 15)
        Me.DP_Leave_DateTo.Size = New System.Drawing.Size(154, 25)
        Me.Btn_Show_Leave.BackColor = System.Drawing.Color.Teal
        Me.Btn_Show_Leave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Show_Leave.ForeColor = System.Drawing.Color.White
        Me.Btn_Show_Leave.Location = New System.Drawing.Point(738, 11)
        Me.Btn_Show_Leave.Size = New System.Drawing.Size(132, 36)
        Me.Btn_Show_Leave.Text = "Apply filters"
        Me.LV_Leave_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Leave_List.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_Leave_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_Leave_List.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_Leave_List.Location = New System.Drawing.Point(24, 158)
        Me.LV_Leave_List.Size = New System.Drawing.Size(1140, 393)
        Me.Lbl_Export_LeaveStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Export_LeaveStatus.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.Lbl_Export_LeaveStatus.ForeColor = System.Drawing.Color.White
        Me.Lbl_Export_LeaveStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Lbl_Export_LeaveStatus.Location = New System.Drawing.Point(1008, 555)
        Me.Lbl_Export_LeaveStatus.Size = New System.Drawing.Size(156, 36)
        Me.Lbl_Export_LeaveStatus.Text = "Export to Excel"
        Me.Lbl_Export_LeaveStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.TabPage4.Controls.Add(Me.LeaveTitleLabel)
        Me.TabPage4.Controls.Add(Me.LeaveDescriptionLabel)
        Me.TabPage4.Controls.Add(Me.LeaveFilterPanel)
        Me.TabPage4.Controls.Add(Me.LV_Leave_List)
        Me.TabPage4.Controls.Add(Me.Lbl_Export_LeaveStatus)
        '
        'Audit log page
        '
        Me.AuditTitleLabel.AutoSize = True
        Me.AuditTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.AuditTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.AuditTitleLabel.Location = New System.Drawing.Point(28, 24)
        Me.AuditTitleLabel.Name = "AuditTitleLabel"
        Me.AuditTitleLabel.Text = "Employee record audit log"
        Me.AuditDescriptionLabel.AutoSize = True
        Me.AuditDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.AuditDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.AuditDescriptionLabel.Location = New System.Drawing.Point(29, 56)
        Me.AuditDescriptionLabel.Name = "AuditDescriptionLabel"
        Me.AuditDescriptionLabel.Text = "Trace changes to employee records across a selected date range."
        Me.AuditFilterPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AuditFilterPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.AuditFilterPanel.Controls.Add(Me.Label13)
        Me.AuditFilterPanel.Controls.Add(Me.DP_Logs_From)
        Me.AuditFilterPanel.Controls.Add(Me.Label4)
        Me.AuditFilterPanel.Controls.Add(Me.DP_Logs_To)
        Me.AuditFilterPanel.Controls.Add(Me.Btn_Logs_Show)
        Me.AuditFilterPanel.Location = New System.Drawing.Point(24, 88)
        Me.AuditFilterPanel.Name = "AuditFilterPanel"
        Me.AuditFilterPanel.Size = New System.Drawing.Size(1140, 58)
        Me.Label13.Location = New System.Drawing.Point(18, 19)
        Me.Label13.Text = "Date from:"
        Me.DP_Logs_From.CustomFormat = "dd-MMM-yyyy"
        Me.DP_Logs_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Logs_From.Location = New System.Drawing.Point(96, 15)
        Me.DP_Logs_From.Size = New System.Drawing.Size(154, 25)
        Me.Label4.Location = New System.Drawing.Point(276, 19)
        Me.Label4.Text = "Date to:"
        Me.DP_Logs_To.CustomFormat = "dd-MMM-yyyy"
        Me.DP_Logs_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DP_Logs_To.Location = New System.Drawing.Point(336, 15)
        Me.DP_Logs_To.Size = New System.Drawing.Size(154, 25)
        Me.Btn_Logs_Show.BackColor = System.Drawing.Color.Teal
        Me.Btn_Logs_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Logs_Show.ForeColor = System.Drawing.Color.White
        Me.Btn_Logs_Show.Location = New System.Drawing.Point(512, 11)
        Me.Btn_Logs_Show.Size = New System.Drawing.Size(200, 36)
        Me.Btn_Logs_Show.Text = "Apply date range"
        Me.LV_SystemLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_SystemLogs.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_SystemLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_SystemLogs.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_SystemLogs.Location = New System.Drawing.Point(24, 158)
        Me.LV_SystemLogs.Size = New System.Drawing.Size(1140, 377)
        Me.Btn_Export_Audit_Log.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Export_Audit_Log.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.Btn_Export_Audit_Log.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Export_Audit_Log.FlatAppearance.BorderSize = 0
        Me.Btn_Export_Audit_Log.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Export_Audit_Log.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Export_Audit_Log.ForeColor = System.Drawing.Color.White
        Me.Btn_Export_Audit_Log.IconChar = FontAwesome.Sharp.IconChar.FileExcel
        Me.Btn_Export_Audit_Log.IconColor = System.Drawing.Color.White
        Me.Btn_Export_Audit_Log.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Export_Audit_Log.IconSize = 20
        Me.Btn_Export_Audit_Log.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Export_Audit_Log.Location = New System.Drawing.Point(1008, 555)
        Me.Btn_Export_Audit_Log.Name = "Btn_Export_Audit_Log"
        Me.Btn_Export_Audit_Log.Size = New System.Drawing.Size(156, 36)
        Me.Btn_Export_Audit_Log.TabIndex = 206
        Me.Btn_Export_Audit_Log.Text = "Export to Excel"
        Me.Btn_Export_Audit_Log.UseVisualStyleBackColor = False
        Me.Tab_Logs.Controls.Add(Me.AuditTitleLabel)
        Me.Tab_Logs.Controls.Add(Me.AuditDescriptionLabel)
        Me.Tab_Logs.Controls.Add(Me.AuditFilterPanel)
        Me.Tab_Logs.Controls.Add(Me.LV_SystemLogs)
        Me.Tab_Logs.Controls.Add(Me.Btn_Export_Audit_Log)
        '
        'Workforce analytics page
        '
        Me.AnalyticsTitleLabel.AutoSize = True
        Me.AnalyticsTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.AnalyticsTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.AnalyticsTitleLabel.Location = New System.Drawing.Point(28, 24)
        Me.AnalyticsTitleLabel.Name = "AnalyticsTitleLabel"
        Me.AnalyticsTitleLabel.Text = "Workforce analytics"
        Me.AnalyticsDescriptionLabel.AutoSize = True
        Me.AnalyticsDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.AnalyticsDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.AnalyticsDescriptionLabel.Location = New System.Drawing.Point(29, 56)
        Me.AnalyticsDescriptionLabel.Name = "AnalyticsDescriptionLabel"
        Me.AnalyticsDescriptionLabel.Text = "Explore current workforce composition and hiring patterns."
        Me.AnalyticsPickerPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AnalyticsPickerPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.AnalyticsPickerPanel.Controls.Add(Me.AnalyticsPickerLabel)
        Me.AnalyticsPickerPanel.Controls.Add(Me.Btn_Load_Chart_Data)
        Me.AnalyticsPickerPanel.Controls.Add(Me.Btn_Hired_Per_Year)
        Me.AnalyticsPickerPanel.Controls.Add(Me.Btn_Gender_Count)
        Me.AnalyticsPickerPanel.Controls.Add(Me.Btn_Age_Count)
        Me.AnalyticsPickerPanel.Controls.Add(Me.AnalyticsStatusLabel)
        Me.AnalyticsPickerPanel.Controls.Add(Me.Cmb_Emp_Status)
        Me.AnalyticsPickerPanel.Controls.Add(Me.Btn_Hired_Per_Month)
        Me.AnalyticsPickerPanel.Location = New System.Drawing.Point(24, 90)
        Me.AnalyticsPickerPanel.Name = "AnalyticsPickerPanel"
        Me.AnalyticsPickerPanel.Size = New System.Drawing.Size(224, 445)
        Me.AnalyticsPickerLabel.AutoSize = True
        Me.AnalyticsPickerLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Regular)
        Me.AnalyticsPickerLabel.ForeColor = System.Drawing.Color.FromArgb(111, 29, 48)
        Me.AnalyticsPickerLabel.Location = New System.Drawing.Point(16, 18)
        Me.AnalyticsPickerLabel.Name = "AnalyticsPickerLabel"
        Me.AnalyticsPickerLabel.Text = "REPORT VIEW"
        Me.Btn_Load_Chart_Data.Location = New System.Drawing.Point(12, 50)
        Me.Btn_Load_Chart_Data.Size = New System.Drawing.Size(200, 36)
        Me.Btn_Load_Chart_Data.Text = "Employment status"
        Me.Btn_Hired_Per_Year.Location = New System.Drawing.Point(12, 92)
        Me.Btn_Hired_Per_Year.Size = New System.Drawing.Size(200, 36)
        Me.Btn_Hired_Per_Year.Text = "Hires by year"
        Me.Btn_Gender_Count.Location = New System.Drawing.Point(12, 134)
        Me.Btn_Gender_Count.Size = New System.Drawing.Size(200, 36)
        Me.Btn_Gender_Count.Text = "Gender distribution"
        Me.Btn_Age_Count.Location = New System.Drawing.Point(12, 176)
        Me.Btn_Age_Count.Size = New System.Drawing.Size(200, 36)
        Me.Btn_Age_Count.Text = "Age distribution"
        Me.AnalyticsStatusLabel.AutoSize = True
        Me.AnalyticsStatusLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Regular)
        Me.AnalyticsStatusLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.AnalyticsStatusLabel.Location = New System.Drawing.Point(16, 238)
        Me.AnalyticsStatusLabel.Name = "AnalyticsStatusLabel"
        Me.AnalyticsStatusLabel.Text = "MONTHLY STATUS"
        Me.Cmb_Emp_Status.Location = New System.Drawing.Point(12, 266)
        Me.Cmb_Emp_Status.Size = New System.Drawing.Size(200, 25)
        Me.Btn_Hired_Per_Month.Location = New System.Drawing.Point(12, 304)
        Me.Btn_Hired_Per_Month.Size = New System.Drawing.Size(200, 36)
        Me.Btn_Hired_Per_Month.Text = "Employees by month"
        Me.CH_Emp_Status.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CH_Emp_Status.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.CH_Emp_Status.Location = New System.Drawing.Point(262, 90)
        Me.CH_Emp_Status.Size = New System.Drawing.Size(646, 445)
        Me.LV_Report_Statistics1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Report_Statistics1.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_Report_Statistics1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_Report_Statistics1.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_Report_Statistics1.Location = New System.Drawing.Point(922, 90)
        Me.LV_Report_Statistics1.Size = New System.Drawing.Size(242, 445)
        Me.Btn_Export_Workforce_Analytics.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Export_Workforce_Analytics.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.Btn_Export_Workforce_Analytics.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Export_Workforce_Analytics.FlatAppearance.BorderSize = 0
        Me.Btn_Export_Workforce_Analytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Export_Workforce_Analytics.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Export_Workforce_Analytics.ForeColor = System.Drawing.Color.White
        Me.Btn_Export_Workforce_Analytics.IconChar = FontAwesome.Sharp.IconChar.FileExcel
        Me.Btn_Export_Workforce_Analytics.IconColor = System.Drawing.Color.White
        Me.Btn_Export_Workforce_Analytics.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Export_Workforce_Analytics.IconSize = 20
        Me.Btn_Export_Workforce_Analytics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Export_Workforce_Analytics.Location = New System.Drawing.Point(1008, 555)
        Me.Btn_Export_Workforce_Analytics.Name = "Btn_Export_Workforce_Analytics"
        Me.Btn_Export_Workforce_Analytics.Size = New System.Drawing.Size(156, 36)
        Me.Btn_Export_Workforce_Analytics.TabIndex = 207
        Me.Btn_Export_Workforce_Analytics.Text = "Export all analytics"
        Me.Btn_Export_Workforce_Analytics.UseVisualStyleBackColor = False
        Me.Tab_HR1.Controls.Add(Me.AnalyticsTitleLabel)
        Me.Tab_HR1.Controls.Add(Me.AnalyticsDescriptionLabel)
        Me.Tab_HR1.Controls.Add(Me.AnalyticsPickerPanel)
        Me.Tab_HR1.Controls.Add(Me.CH_Emp_Status)
        Me.Tab_HR1.Controls.Add(Me.LV_Report_Statistics1)
        Me.Tab_HR1.Controls.Add(Me.Btn_Export_Workforce_Analytics)
        '
        'Client tab host
        '
        Me.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl3.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.25!, System.Drawing.FontStyle.Regular)
        Me.TabControl3.ItemSize = New System.Drawing.Size(185, 38)
        Me.TabControl3.Location = New System.Drawing.Point(12, 12)
        Me.TabControl3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.TabPage2.Text = "Portfolio"
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.TabPage3.Text = "Employees by detachment"
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.TabPage6.Text = "Employees by client"
        '
        'Client portfolio page
        '
        Me.PortfolioTitleLabel.AutoSize = True
        Me.PortfolioTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.PortfolioTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.PortfolioTitleLabel.Location = New System.Drawing.Point(28, 22)
        Me.PortfolioTitleLabel.Name = "PortfolioTitleLabel"
        Me.PortfolioTitleLabel.Text = "Active client portfolio"
        Me.PortfolioDescriptionLabel.AutoSize = True
        Me.PortfolioDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.PortfolioDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.PortfolioDescriptionLabel.Location = New System.Drawing.Point(29, 54)
        Me.PortfolioDescriptionLabel.Name = "PortfolioDescriptionLabel"
        Me.PortfolioDescriptionLabel.Text = "See the main-client and detachment structure at a glance."
        Me.PortfolioSummaryPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PortfolioSummaryPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.PortfolioSummaryPanel.Controls.Add(Me.Btn_Client_Show)
        Me.PortfolioSummaryPanel.Controls.Add(Me.Label6)
        Me.PortfolioSummaryPanel.Controls.Add(Me.Txt_Active_MainClient)
        Me.PortfolioSummaryPanel.Controls.Add(Me.Label14)
        Me.PortfolioSummaryPanel.Controls.Add(Me.Txt_Active_SubClient)
        Me.PortfolioSummaryPanel.Location = New System.Drawing.Point(24, 90)
        Me.PortfolioSummaryPanel.Name = "PortfolioSummaryPanel"
        Me.PortfolioSummaryPanel.Size = New System.Drawing.Size(300, 364)
        Me.Btn_Client_Show.BackColor = System.Drawing.Color.Teal
        Me.Btn_Client_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Client_Show.ForeColor = System.Drawing.Color.White
        Me.Btn_Client_Show.Location = New System.Drawing.Point(18, 18)
        Me.Btn_Client_Show.Size = New System.Drawing.Size(264, 36)
        Me.Btn_Client_Show.Text = "Refresh summary"
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Regular)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.Label6.Location = New System.Drawing.Point(18, 82)
        Me.Label6.Text = "ACTIVE MAIN CLIENTS"
        Me.Txt_Active_MainClient.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Txt_Active_MainClient.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_Active_MainClient.Font = New System.Drawing.Font("Bahnschrift SemiBold", 24.0!, System.Drawing.FontStyle.Regular)
        Me.Txt_Active_MainClient.ForeColor = System.Drawing.Color.FromArgb(111, 29, 48)
        Me.Txt_Active_MainClient.Location = New System.Drawing.Point(18, 108)
        Me.Txt_Active_MainClient.Size = New System.Drawing.Size(250, 39)
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Regular)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.Label14.Location = New System.Drawing.Point(18, 176)
        Me.Label14.Text = "ACTIVE DETACHMENTS"
        Me.Txt_Active_SubClient.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Txt_Active_SubClient.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_Active_SubClient.Font = New System.Drawing.Font("Bahnschrift SemiBold", 24.0!, System.Drawing.FontStyle.Regular)
        Me.Txt_Active_SubClient.ForeColor = System.Drawing.Color.FromArgb(111, 29, 48)
        Me.Txt_Active_SubClient.Location = New System.Drawing.Point(18, 202)
        Me.Txt_Active_SubClient.Size = New System.Drawing.Size(250, 39)
        Me.LV_Client_Count.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Client_Count.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_Client_Count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_Client_Count.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_Client_Count.Location = New System.Drawing.Point(340, 90)
        Me.LV_Client_Count.Size = New System.Drawing.Size(794, 364)
        Me.BtnExport_MainClientCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExport_MainClientCount.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.BtnExport_MainClientCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExport_MainClientCount.ForeColor = System.Drawing.Color.White
        Me.BtnExport_MainClientCount.Location = New System.Drawing.Point(978, 474)
        Me.BtnExport_MainClientCount.Size = New System.Drawing.Size(156, 36)
        Me.BtnExport_MainClientCount.Text = "Export to Excel"
        Me.TabPage2.Controls.Add(Me.PortfolioTitleLabel)
        Me.TabPage2.Controls.Add(Me.PortfolioDescriptionLabel)
        Me.TabPage2.Controls.Add(Me.PortfolioSummaryPanel)
        Me.TabPage2.Controls.Add(Me.LV_Client_Count)
        Me.TabPage2.Controls.Add(Me.BtnExport_MainClientCount)
        '
        'Detachment report page
        '
        Me.SubClientTitleLabel.AutoSize = True
        Me.SubClientTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.SubClientTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.SubClientTitleLabel.Location = New System.Drawing.Point(28, 22)
        Me.SubClientTitleLabel.Name = "SubClientTitleLabel"
        Me.SubClientTitleLabel.Text = "Employees by detachment"
        Me.SubClientDescriptionLabel.AutoSize = True
        Me.SubClientDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.SubClientDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.SubClientDescriptionLabel.Location = New System.Drawing.Point(29, 54)
        Me.SubClientDescriptionLabel.Name = "SubClientDescriptionLabel"
        Me.SubClientDescriptionLabel.Text = "Compare active staffing across client detachments."
        Me.SubClientFilterPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SubClientFilterPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.SubClientFilterPanel.Controls.Add(Me.Btn_Show_SubClient_EmpCount)
        Me.SubClientFilterPanel.Location = New System.Drawing.Point(24, 86)
        Me.SubClientFilterPanel.Name = "SubClientFilterPanel"
        Me.SubClientFilterPanel.Size = New System.Drawing.Size(1110, 58)
        Me.Btn_Show_SubClient_EmpCount.BackColor = System.Drawing.Color.Teal
        Me.Btn_Show_SubClient_EmpCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Show_SubClient_EmpCount.ForeColor = System.Drawing.Color.White
        Me.Btn_Show_SubClient_EmpCount.Location = New System.Drawing.Point(16, 11)
        Me.Btn_Show_SubClient_EmpCount.Size = New System.Drawing.Size(142, 36)
        Me.Btn_Show_SubClient_EmpCount.Text = "Load report"
        Me.LV_SubClient_EmployeeCount.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_SubClient_EmployeeCount.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_SubClient_EmployeeCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_SubClient_EmployeeCount.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_SubClient_EmployeeCount.Location = New System.Drawing.Point(24, 156)
        Me.LV_SubClient_EmployeeCount.Size = New System.Drawing.Size(1110, 298)
        Me.Btn_Export_SubClient_Count.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Export_SubClient_Count.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.Btn_Export_SubClient_Count.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Export_SubClient_Count.ForeColor = System.Drawing.Color.White
        Me.Btn_Export_SubClient_Count.Location = New System.Drawing.Point(978, 474)
        Me.Btn_Export_SubClient_Count.Size = New System.Drawing.Size(156, 36)
        Me.Btn_Export_SubClient_Count.Text = "Export to Excel"
        Me.TabPage3.Controls.Add(Me.SubClientTitleLabel)
        Me.TabPage3.Controls.Add(Me.SubClientDescriptionLabel)
        Me.TabPage3.Controls.Add(Me.SubClientFilterPanel)
        Me.TabPage3.Controls.Add(Me.LV_SubClient_EmployeeCount)
        Me.TabPage3.Controls.Add(Me.Btn_Export_SubClient_Count)
        '
        'Main client employee report page
        '
        Me.MainClientTitleLabel.AutoSize = True
        Me.MainClientTitleLabel.Font = New System.Drawing.Font("Bahnschrift SemiBold", 14.0!, System.Drawing.FontStyle.Regular)
        Me.MainClientTitleLabel.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.MainClientTitleLabel.Location = New System.Drawing.Point(28, 22)
        Me.MainClientTitleLabel.Name = "MainClientTitleLabel"
        Me.MainClientTitleLabel.Text = "Employees by main client"
        Me.MainClientDescriptionLabel.AutoSize = True
        Me.MainClientDescriptionLabel.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.MainClientDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(98, 108, 118)
        Me.MainClientDescriptionLabel.Location = New System.Drawing.Point(29, 54)
        Me.MainClientDescriptionLabel.Name = "MainClientDescriptionLabel"
        Me.MainClientDescriptionLabel.Text = "Review active employee coverage for each main client."
        Me.MainClientFilterPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainClientFilterPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.MainClientFilterPanel.Controls.Add(Me.Btn_Show_MainClient_EmpCount)
        Me.MainClientFilterPanel.Location = New System.Drawing.Point(24, 86)
        Me.MainClientFilterPanel.Name = "MainClientFilterPanel"
        Me.MainClientFilterPanel.Size = New System.Drawing.Size(1110, 58)
        Me.Btn_Show_MainClient_EmpCount.BackColor = System.Drawing.Color.Teal
        Me.Btn_Show_MainClient_EmpCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Show_MainClient_EmpCount.ForeColor = System.Drawing.Color.White
        Me.Btn_Show_MainClient_EmpCount.Location = New System.Drawing.Point(16, 11)
        Me.Btn_Show_MainClient_EmpCount.Size = New System.Drawing.Size(142, 36)
        Me.Btn_Show_MainClient_EmpCount.Text = "Load report"
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular)
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Location = New System.Drawing.Point(24, 156)
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.Size = New System.Drawing.Size(1110, 298)
        Me.Btn_Export_Employee_Count.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Export_Employee_Count.BackColor = System.Drawing.Color.FromArgb(0, 128, 128)
        Me.Btn_Export_Employee_Count.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Export_Employee_Count.ForeColor = System.Drawing.Color.White
        Me.Btn_Export_Employee_Count.Location = New System.Drawing.Point(978, 474)
        Me.Btn_Export_Employee_Count.Size = New System.Drawing.Size(156, 36)
        Me.Btn_Export_Employee_Count.Text = "Export to Excel"
        Me.TabPage6.Controls.Add(Me.MainClientTitleLabel)
        Me.TabPage6.Controls.Add(Me.MainClientDescriptionLabel)
        Me.TabPage6.Controls.Add(Me.MainClientFilterPanel)
        Me.TabPage6.Controls.Add(Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT)
        Me.TabPage6.Controls.Add(Me.Btn_Export_Employee_Count)
        '
        'Designer-owned shared report styling
        '
        Me.Txt_Leave_DateFrom.Visible = False
        Me.Txt_Leave_DateTo.Visible = False
        Me.Txt_Logs_DateFrom.Visible = False
        Me.Txt_Logs_DateTo.Visible = False
        Me.Txt_Active_MainClient.ReadOnly = True
        Me.Txt_Active_SubClient.ReadOnly = True
        '
        Me.Cmb_Exp_Category.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_Exp_Category.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.Cmb_Expiry_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_Expiry_Status.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.Cmb_Client_Expiration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_Client_Expiration.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.Cmb_Pending_Category.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_Pending_Category.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.Cmb_LeaveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_LeaveType.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.Cmb_Emp_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_Emp_Status.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        '
        Me.DP_Leave_DateFrom.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.DP_Leave_DateTo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.DP_Logs_From.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.DP_Logs_To.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48)
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(92, 70, 48)
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        '
        Me.Btn_Load_Chart_Data.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Btn_Load_Chart_Data.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Load_Chart_Data.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.Btn_Load_Chart_Data.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Load_Chart_Data.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Load_Chart_Data.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Btn_Load_Chart_Data.UseVisualStyleBackColor = False
        Me.Btn_Hired_Per_Year.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Btn_Hired_Per_Year.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Hired_Per_Year.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.Btn_Hired_Per_Year.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Hired_Per_Year.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Hired_Per_Year.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Btn_Hired_Per_Year.UseVisualStyleBackColor = False
        Me.Btn_Gender_Count.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Btn_Gender_Count.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Gender_Count.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.Btn_Gender_Count.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Gender_Count.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Gender_Count.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Btn_Gender_Count.UseVisualStyleBackColor = False
        Me.Btn_Age_Count.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Btn_Age_Count.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Age_Count.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.Btn_Age_Count.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Age_Count.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Age_Count.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Btn_Age_Count.UseVisualStyleBackColor = False
        Me.Btn_Hired_Per_Month.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Btn_Hired_Per_Month.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Hired_Per_Month.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.Btn_Hired_Per_Month.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Hired_Per_Month.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Hired_Per_Month.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.Btn_Hired_Per_Month.UseVisualStyleBackColor = False
        '
        Me.Btn_ShowPendingRecords.FlatAppearance.BorderSize = 0
        Me.Btn_ShowPendingRecords.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_ShowPendingRecords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Show_Leave.FlatAppearance.BorderSize = 0
        Me.Btn_Show_Leave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Show_Leave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Logs_Show.FlatAppearance.BorderSize = 0
        Me.Btn_Logs_Show.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Logs_Show.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Client_Show.FlatAppearance.BorderSize = 0
        Me.Btn_Client_Show.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Client_Show.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Show_SubClient_EmpCount.FlatAppearance.BorderSize = 0
        Me.Btn_Show_SubClient_EmpCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Show_SubClient_EmpCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Show_MainClient_EmpCount.FlatAppearance.BorderSize = 0
        Me.Btn_Show_MainClient_EmpCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Show_MainClient_EmpCount.Cursor = System.Windows.Forms.Cursors.Hand
        '
        Me.Lbl_Export_SecLicense.AutoSize = False
        Me.Lbl_Export_SecLicense.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lbl_Export_SecLicense.Size = New System.Drawing.Size(156, 36)
        Me.Lbl_Export_Client_Contract_Exp.AutoSize = False
        Me.Lbl_Export_Client_Contract_Exp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lbl_Export_Client_Contract_Exp.Size = New System.Drawing.Size(156, 36)
        Me.Lbl_Export_PendingDocs.AutoSize = False
        Me.Lbl_Export_PendingDocs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lbl_Export_PendingDocs.Size = New System.Drawing.Size(156, 36)
        Me.Lbl_Export_LeaveStatus.AutoSize = False
        Me.Lbl_Export_LeaveStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lbl_Export_LeaveStatus.Size = New System.Drawing.Size(156, 36)
        Me.BtnExport_MainClientCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnExport_MainClientCount.FlatAppearance.BorderSize = 0
        Me.BtnExport_MainClientCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.BtnExport_MainClientCount.IconChar = FontAwesome.Sharp.IconChar.FileExcel
        Me.BtnExport_MainClientCount.IconColor = System.Drawing.Color.White
        Me.BtnExport_MainClientCount.IconSize = 20
        Me.Btn_Export_SubClient_Count.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Export_SubClient_Count.FlatAppearance.BorderSize = 0
        Me.Btn_Export_SubClient_Count.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Export_SubClient_Count.IconChar = FontAwesome.Sharp.IconChar.FileExcel
        Me.Btn_Export_SubClient_Count.IconColor = System.Drawing.Color.White
        Me.Btn_Export_SubClient_Count.IconSize = 20
        Me.Btn_Export_Employee_Count.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Export_Employee_Count.FlatAppearance.BorderSize = 0
        Me.Btn_Export_Employee_Count.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Btn_Export_Employee_Count.IconChar = FontAwesome.Sharp.IconChar.FileExcel
        Me.Btn_Export_Employee_Count.IconColor = System.Drawing.Color.White
        Me.Btn_Export_Employee_Count.IconSize = 20
        '
        Me.LV_Expiry_List.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_Expiry_List.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_Expiry_List.GridLines = False
        Me.LV_Expiry_List.OwnerDraw = True
        Me.LV_Client_Contract_Exp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_Client_Contract_Exp.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_Client_Contract_Exp.GridLines = False
        Me.LV_Client_Contract_Exp.OwnerDraw = True
        Me.LV_Pending_List.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_Pending_List.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_Pending_List.GridLines = False
        Me.LV_Pending_List.OwnerDraw = True
        Me.LV_Leave_List.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_Leave_List.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_Leave_List.GridLines = False
        Me.LV_Leave_List.OwnerDraw = True
        Me.LV_SystemLogs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_SystemLogs.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_SystemLogs.GridLines = False
        Me.LV_SystemLogs.OwnerDraw = True
        Me.LV_Report_Statistics1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_Report_Statistics1.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_Report_Statistics1.GridLines = False
        Me.LV_Report_Statistics1.OwnerDraw = True
        Me.LV_Client_Count.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_Client_Count.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_Client_Count.GridLines = False
        Me.LV_Client_Count.OwnerDraw = True
        Me.LV_SubClient_EmployeeCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_SubClient_EmployeeCount.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_SubClient_EmployeeCount.GridLines = False
        Me.LV_SubClient_EmployeeCount.OwnerDraw = True
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51)
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.GridLines = False
        Me.LV_MAIN_CLIENT_EMPLOYEE_COUNT.OwnerDraw = True
        '
        Me.CH_Emp_Status.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Me.CH_Emp_Status.PaletteCustomColors = New System.Drawing.Color() {
            System.Drawing.Color.FromArgb(111, 29, 48),
            System.Drawing.Color.FromArgb(0, 128, 128),
            System.Drawing.Color.FromArgb(213, 145, 36),
            System.Drawing.Color.FromArgb(74, 103, 133),
            System.Drawing.Color.FromArgb(158, 91, 105),
            System.Drawing.Color.FromArgb(78, 151, 137)}
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PictureBox2.Location = New System.Drawing.Point(24, 729)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1258, 70)
        Me.PictureBox2.TabIndex = 121
        Me.PictureBox2.TabStop = False
        '
        'FRM_HR_REPORTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.ClientSize = New System.Drawing.Size(1440, 860)
        Me.Controls.Add(Me.ReportsWorkspaceRoot)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular)
        Me.MinimumSize = New System.Drawing.Size(1180, 720)
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Name = "FRM_HR_REPORTS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Human Resources Reports"
        Me.Tab_Logs.ResumeLayout(False)
        Me.Tab_Logs.PerformLayout()
        Me.Tab_Security_License.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.Tab_HR1.ResumeLayout(False)
        Me.TabControl4.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        CType(Me.CH_Emp_Status, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Recruitment.ResumeLayout(False)
        Me.Tab_Pending_Docs.ResumeLayout(False)
        Me.Tab_Pending_Docs.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.Tab_Client.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Label2 As Label
    Friend WithEvents Tab_Logs As TabPage
    Friend WithEvents Tab_Security_License As TabPage
    Friend WithEvents Tab_HR1 As TabPage
    Friend WithEvents Tab_Recruitment As TabControl
    Friend WithEvents LV_SystemLogs As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Txt_Logs_DateTo As TextBox
    Friend WithEvents DP_Logs_To As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_Logs_DateFrom As TextBox
    Friend WithEvents DP_Logs_From As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents Btn_Logs_Show As Button
    Friend WithEvents Tab_Pending_Docs As TabPage
    Friend WithEvents Lbl_Export_PendingDocs As Label
    Friend WithEvents LV_Pending_List As ListView
    Friend WithEvents Col_Pending_EmpID As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColRec_Datehired As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Col_Gov_IDs As ColumnHeader
    Friend WithEvents Label9 As Label
    Friend WithEvents Btn_ShowPendingRecords As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Cmb_Exp_Category As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Lbl_Export_SecLicense As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_Expiry_Status As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LV_Expiry_List As ListView
    Friend WithEvents Col_ID As ColumnHeader
    Friend WithEvents Col_Name As ColumnHeader
    Friend WithEvents Col_Hired As ColumnHeader
    Friend WithEvents Col_Client_Info As ColumnHeader
    Friend WithEvents Col_Expiry_Date As ColumnHeader
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Btn_Show_Leave As Button
    Friend WithEvents Txt_Leave_DateTo As TextBox
    Friend WithEvents DP_Leave_DateTo As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Txt_Leave_DateFrom As TextBox
    Friend WithEvents DP_Leave_DateFrom As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents LV_Leave_List As ListView
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents Col_Leave_Start As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents Cmb_LeaveType As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Lbl_Export_LeaveStatus As Label
    Friend WithEvents Col_Leave_End As ColumnHeader
    Friend WithEvents Cmb_Pending_Category As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Tab_Client As TabPage
    Friend WithEvents Col_DaysExpired As ColumnHeader
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt_Active_MainClient As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Txt_Active_SubClient As TextBox
    Friend WithEvents Btn_Client_Show As Button
    Friend WithEvents LV_Client_Count As ListView
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents LV_SubClient_EmployeeCount As ListView
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents Btn_Show_SubClient_EmpCount As Button
    Friend WithEvents Btn_Show_MainClient_EmpCount As Button
    Friend WithEvents LV_MAIN_CLIENT_EMPLOYEE_COUNT As ListView
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents Btn_Export_SubClient_Count As IconButton
    Friend WithEvents BtnExport_MainClientCount As IconButton
    Friend WithEvents Btn_Export_Employee_Count As IconButton
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents Cmb_Client_Expiration As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents LV_Client_Contract_Exp As ListView
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents Col_Client_ID As ColumnHeader
    Friend WithEvents Lbl_Export_Client_Contract_Exp As Label
    Friend WithEvents TabControl4 As TabControl
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents Btn_Gender_Count As Button
    Friend WithEvents Btn_Hired_Per_Month As Button
    Friend WithEvents Btn_Hired_Per_Year As Button
    Friend WithEvents LV_Report_Statistics1 As ListView
    Friend WithEvents Col_Status As ColumnHeader
    Friend WithEvents Col_Count As ColumnHeader
    Friend WithEvents Btn_Load_Chart_Data As Button
    Friend WithEvents CH_Emp_Status As DataVisualization.Charting.Chart
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents Btn_Age_Count As Button
    Friend WithEvents Cmb_Emp_Status As ComboBox
    Friend WithEvents ReportsWorkspaceRoot As TableLayoutPanel
    Friend WithEvents ReportsHeaderPanel As Panel
    Friend WithEvents ReportsBodyPanel As Panel
    Friend WithEvents ReportsLogo As PictureBox
    Friend WithEvents ReportsTitleLabel As Label
    Friend WithEvents ReportsSubtitleLabel As Label
    Friend WithEvents ReportsSectionLabel As Label
    Friend WithEvents ReportsCloseButton As Button
    Friend WithEvents ReportsNavInfoPanel As Panel
    Friend WithEvents ReportsNavInfoTitle As Label
    Friend WithEvents ReportsNavInfoBody As Label
    Friend WithEvents ReportsNavPanel As Panel
    Friend WithEvents ReportsContentHost As Panel
    Friend WithEvents NavComplianceButton As Button
    Friend WithEvents NavMissingButton As Button
    Friend WithEvents NavLeaveButton As Button
    Friend WithEvents NavWorkforceButton As Button
    Friend WithEvents NavClientsButton As Button
    Friend WithEvents NavAuditButton As Button
    Friend WithEvents EmpExpiryTitleLabel As Label
    Friend WithEvents EmpExpiryDescriptionLabel As Label
    Friend WithEvents EmpExpiryFilterPanel As Panel
    Friend WithEvents ClientExpiryTitleLabel As Label
    Friend WithEvents ClientExpiryDescriptionLabel As Label
    Friend WithEvents ClientExpiryFilterPanel As Panel
    Friend WithEvents MissingTitleLabel As Label
    Friend WithEvents MissingDescriptionLabel As Label
    Friend WithEvents MissingFilterPanel As Panel
    Friend WithEvents LeaveTitleLabel As Label
    Friend WithEvents LeaveDescriptionLabel As Label
    Friend WithEvents LeaveFilterPanel As Panel
    Friend WithEvents AuditTitleLabel As Label
    Friend WithEvents AuditDescriptionLabel As Label
    Friend WithEvents AuditFilterPanel As Panel
    Friend WithEvents Btn_Export_Audit_Log As IconButton
    Friend WithEvents AnalyticsTitleLabel As Label
    Friend WithEvents AnalyticsDescriptionLabel As Label
    Friend WithEvents AnalyticsPickerPanel As Panel
    Friend WithEvents AnalyticsPickerLabel As Label
    Friend WithEvents AnalyticsStatusLabel As Label
    Friend WithEvents Btn_Export_Workforce_Analytics As IconButton
    Friend WithEvents PortfolioTitleLabel As Label
    Friend WithEvents PortfolioDescriptionLabel As Label
    Friend WithEvents PortfolioSummaryPanel As Panel
    Friend WithEvents SubClientTitleLabel As Label
    Friend WithEvents SubClientDescriptionLabel As Label
    Friend WithEvents SubClientFilterPanel As Panel
    Friend WithEvents MainClientTitleLabel As Label
    Friend WithEvents MainClientDescriptionLabel As Label
    Friend WithEvents MainClientFilterPanel As Panel
End Class
