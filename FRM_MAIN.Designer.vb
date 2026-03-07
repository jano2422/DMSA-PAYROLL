<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_MAIN
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Grp_HR_Menu = New System.Windows.Forms.GroupBox()
        Me.Btn_HR_Reports = New FontAwesome.Sharp.IconButton()
        Me.Btn_ClientManagement = New FontAwesome.Sharp.IconButton()
        Me.Btn_Recruitment = New FontAwesome.Sharp.IconButton()
        Me.Btn_EmployeeRecords = New FontAwesome.Sharp.IconButton()
        Me.GRP_Payroll = New System.Windows.Forms.GroupBox()
        Me.Btn_Payslip = New FontAwesome.Sharp.IconButton()
        Me.Btn_DTR = New FontAwesome.Sharp.IconButton()
        Me.Btn_Schedule = New FontAwesome.Sharp.IconButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AdminBtn = New FontAwesome.Sharp.IconButton()
        Me.IconButton9 = New FontAwesome.Sharp.IconButton()
        Me.IconButton8 = New FontAwesome.Sharp.IconButton()
        Me.Btn_Operations = New FontAwesome.Sharp.IconButton()
        Me.Btn_Payroll = New FontAwesome.Sharp.IconButton()
        Me.Btn_HR = New FontAwesome.Sharp.IconButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GRP_Operations = New System.Windows.Forms.GroupBox()
        Me.Grp_HR_Menu.SuspendLayout()
        Me.GRP_Payroll.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRP_Operations.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Maroon
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1659, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Grp_HR_Menu
        '
        Me.Grp_HR_Menu.Controls.Add(Me.Btn_HR_Reports)
        Me.Grp_HR_Menu.Controls.Add(Me.Btn_ClientManagement)
        Me.Grp_HR_Menu.Controls.Add(Me.Btn_Recruitment)
        Me.Grp_HR_Menu.Controls.Add(Me.Btn_EmployeeRecords)
        Me.Grp_HR_Menu.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_HR_Menu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Grp_HR_Menu.Location = New System.Drawing.Point(300, 86)
        Me.Grp_HR_Menu.Name = "Grp_HR_Menu"
        Me.Grp_HR_Menu.Size = New System.Drawing.Size(1330, 248)
        Me.Grp_HR_Menu.TabIndex = 19
        Me.Grp_HR_Menu.TabStop = False
        Me.Grp_HR_Menu.Text = "Human Resources Menu"
        Me.Grp_HR_Menu.Visible = False
        '
        'Btn_HR_Reports
        '
        Me.Btn_HR_Reports.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btn_HR_Reports.FlatAppearance.BorderSize = 0
        Me.Btn_HR_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_HR_Reports.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_HR_Reports.ForeColor = System.Drawing.Color.Transparent
        Me.Btn_HR_Reports.IconChar = FontAwesome.Sharp.IconChar.ChartColumn
        Me.Btn_HR_Reports.IconColor = System.Drawing.Color.Black
        Me.Btn_HR_Reports.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_HR_Reports.IconSize = 85
        Me.Btn_HR_Reports.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_HR_Reports.Location = New System.Drawing.Point(871, 33)
        Me.Btn_HR_Reports.Name = "Btn_HR_Reports"
        Me.Btn_HR_Reports.Size = New System.Drawing.Size(277, 160)
        Me.Btn_HR_Reports.TabIndex = 35
        Me.Btn_HR_Reports.Text = "                 Reports"
        Me.Btn_HR_Reports.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Btn_HR_Reports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_HR_Reports.UseVisualStyleBackColor = False
        '
        'Btn_ClientManagement
        '
        Me.Btn_ClientManagement.BackColor = System.Drawing.Color.OliveDrab
        Me.Btn_ClientManagement.FlatAppearance.BorderSize = 0
        Me.Btn_ClientManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_ClientManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ClientManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_ClientManagement.IconChar = FontAwesome.Sharp.IconChar.PeopleRoof
        Me.Btn_ClientManagement.IconColor = System.Drawing.Color.Black
        Me.Btn_ClientManagement.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_ClientManagement.IconSize = 90
        Me.Btn_ClientManagement.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_ClientManagement.Location = New System.Drawing.Point(588, 33)
        Me.Btn_ClientManagement.Name = "Btn_ClientManagement"
        Me.Btn_ClientManagement.Size = New System.Drawing.Size(277, 160)
        Me.Btn_ClientManagement.TabIndex = 34
        Me.Btn_ClientManagement.Text = "Client Management"
        Me.Btn_ClientManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_ClientManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_ClientManagement.UseVisualStyleBackColor = False
        '
        'Btn_Recruitment
        '
        Me.Btn_Recruitment.BackColor = System.Drawing.Color.Yellow
        Me.Btn_Recruitment.FlatAppearance.BorderSize = 0
        Me.Btn_Recruitment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Recruitment.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Recruitment.ForeColor = System.Drawing.Color.Black
        Me.Btn_Recruitment.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus
        Me.Btn_Recruitment.IconColor = System.Drawing.Color.Black
        Me.Btn_Recruitment.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Recruitment.IconSize = 85
        Me.Btn_Recruitment.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Recruitment.Location = New System.Drawing.Point(305, 33)
        Me.Btn_Recruitment.Name = "Btn_Recruitment"
        Me.Btn_Recruitment.Size = New System.Drawing.Size(277, 160)
        Me.Btn_Recruitment.TabIndex = 33
        Me.Btn_Recruitment.Text = "      Recruitment"
        Me.Btn_Recruitment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Recruitment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Recruitment.UseVisualStyleBackColor = False
        '
        'Btn_EmployeeRecords
        '
        Me.Btn_EmployeeRecords.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Btn_EmployeeRecords.FlatAppearance.BorderSize = 0
        Me.Btn_EmployeeRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_EmployeeRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_EmployeeRecords.ForeColor = System.Drawing.Color.Black
        Me.Btn_EmployeeRecords.IconChar = FontAwesome.Sharp.IconChar.Book
        Me.Btn_EmployeeRecords.IconColor = System.Drawing.Color.Black
        Me.Btn_EmployeeRecords.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_EmployeeRecords.IconSize = 85
        Me.Btn_EmployeeRecords.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_EmployeeRecords.Location = New System.Drawing.Point(22, 33)
        Me.Btn_EmployeeRecords.Name = "Btn_EmployeeRecords"
        Me.Btn_EmployeeRecords.Size = New System.Drawing.Size(277, 160)
        Me.Btn_EmployeeRecords.TabIndex = 32
        Me.Btn_EmployeeRecords.Text = "Employee Records"
        Me.Btn_EmployeeRecords.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_EmployeeRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_EmployeeRecords.UseVisualStyleBackColor = False
        '
        'GRP_Payroll
        '
        Me.GRP_Payroll.Controls.Add(Me.Btn_Payslip)
        Me.GRP_Payroll.Controls.Add(Me.Btn_DTR)
        Me.GRP_Payroll.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRP_Payroll.ForeColor = System.Drawing.Color.Maroon
        Me.GRP_Payroll.Location = New System.Drawing.Point(300, 350)
        Me.GRP_Payroll.Name = "GRP_Payroll"
        Me.GRP_Payroll.Size = New System.Drawing.Size(1045, 276)
        Me.GRP_Payroll.TabIndex = 20
        Me.GRP_Payroll.TabStop = False
        Me.GRP_Payroll.Text = "Payroll System Menu"
        Me.GRP_Payroll.Visible = False
        '
        'Btn_Payslip
        '
        Me.Btn_Payslip.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btn_Payslip.FlatAppearance.BorderSize = 0
        Me.Btn_Payslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Payslip.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Payslip.ForeColor = System.Drawing.Color.Black
        Me.Btn_Payslip.IconChar = FontAwesome.Sharp.IconChar.Receipt
        Me.Btn_Payslip.IconColor = System.Drawing.Color.Black
        Me.Btn_Payslip.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Payslip.IconSize = 85
        Me.Btn_Payslip.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Payslip.Location = New System.Drawing.Point(314, 57)
        Me.Btn_Payslip.Name = "Btn_Payslip"
        Me.Btn_Payslip.Size = New System.Drawing.Size(277, 160)
        Me.Btn_Payslip.TabIndex = 35
        Me.Btn_Payslip.Text = "          Payslip"
        Me.Btn_Payslip.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Payslip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Payslip.UseVisualStyleBackColor = False
        '
        'Btn_DTR
        '
        Me.Btn_DTR.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Btn_DTR.FlatAppearance.BorderSize = 0
        Me.Btn_DTR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_DTR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_DTR.ForeColor = System.Drawing.Color.Black
        Me.Btn_DTR.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck
        Me.Btn_DTR.IconColor = System.Drawing.Color.Black
        Me.Btn_DTR.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_DTR.IconSize = 85
        Me.Btn_DTR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_DTR.Location = New System.Drawing.Point(22, 57)
        Me.Btn_DTR.Name = "Btn_DTR"
        Me.Btn_DTR.Size = New System.Drawing.Size(277, 160)
        Me.Btn_DTR.TabIndex = 34
        Me.Btn_DTR.Text = "                DTR"
        Me.Btn_DTR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_DTR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_DTR.UseVisualStyleBackColor = False
        '
        'Btn_Schedule
        '
        Me.Btn_Schedule.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btn_Schedule.FlatAppearance.BorderSize = 0
        Me.Btn_Schedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Schedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Schedule.ForeColor = System.Drawing.Color.Black
        Me.Btn_Schedule.IconChar = FontAwesome.Sharp.IconChar.CalendarDays
        Me.Btn_Schedule.IconColor = System.Drawing.Color.Black
        Me.Btn_Schedule.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Schedule.IconSize = 85
        Me.Btn_Schedule.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Schedule.Location = New System.Drawing.Point(22, 39)
        Me.Btn_Schedule.Name = "Btn_Schedule"
        Me.Btn_Schedule.Size = New System.Drawing.Size(277, 160)
        Me.Btn_Schedule.TabIndex = 36
        Me.Btn_Schedule.Text = "         Schedule"
        Me.Btn_Schedule.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Schedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Schedule.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(1365, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(265, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Delta Maroon Security Agency Corp."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.AdminBtn)
        Me.Panel1.Controls.Add(Me.IconButton9)
        Me.Panel1.Controls.Add(Me.IconButton8)
        Me.Panel1.Controls.Add(Me.Btn_Operations)
        Me.Panel1.Controls.Add(Me.Btn_Payroll)
        Me.Panel1.Controls.Add(Me.Btn_HR)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(283, 877)
        Me.Panel1.TabIndex = 27
        '
        'AdminBtn
        '
        Me.AdminBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdminBtn.IconChar = FontAwesome.Sharp.IconChar.User
        Me.AdminBtn.IconColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AdminBtn.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.AdminBtn.IconSize = 60
        Me.AdminBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AdminBtn.Location = New System.Drawing.Point(3, 602)
        Me.AdminBtn.Name = "AdminBtn"
        Me.AdminBtn.Size = New System.Drawing.Size(277, 67)
        Me.AdminBtn.TabIndex = 36
        Me.AdminBtn.Text = "Admin"
        Me.AdminBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AdminBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AdminBtn.UseVisualStyleBackColor = True
        '
        'IconButton9
        '
        Me.IconButton9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton9.IconChar = FontAwesome.Sharp.IconChar.Warehouse
        Me.IconButton9.IconColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.IconButton9.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton9.IconSize = 60
        Me.IconButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton9.Location = New System.Drawing.Point(3, 529)
        Me.IconButton9.Name = "IconButton9"
        Me.IconButton9.Size = New System.Drawing.Size(277, 73)
        Me.IconButton9.TabIndex = 35
        Me.IconButton9.Text = "Inventory"
        Me.IconButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton9.UseVisualStyleBackColor = True
        '
        'IconButton8
        '
        Me.IconButton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton8.IconChar = FontAwesome.Sharp.IconChar.SackDollar
        Me.IconButton8.IconColor = System.Drawing.Color.Purple
        Me.IconButton8.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton8.IconSize = 60
        Me.IconButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton8.Location = New System.Drawing.Point(3, 456)
        Me.IconButton8.Name = "IconButton8"
        Me.IconButton8.Size = New System.Drawing.Size(277, 73)
        Me.IconButton8.TabIndex = 34
        Me.IconButton8.Text = "Accounting"
        Me.IconButton8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton8.UseVisualStyleBackColor = True
        '
        'Btn_Operations
        '
        Me.Btn_Operations.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Operations.IconChar = FontAwesome.Sharp.IconChar.Gun
        Me.Btn_Operations.IconColor = System.Drawing.Color.Black
        Me.Btn_Operations.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Operations.IconSize = 60
        Me.Btn_Operations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Operations.Location = New System.Drawing.Point(3, 383)
        Me.Btn_Operations.Name = "Btn_Operations"
        Me.Btn_Operations.Size = New System.Drawing.Size(277, 73)
        Me.Btn_Operations.TabIndex = 33
        Me.Btn_Operations.Text = "Operations"
        Me.Btn_Operations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Operations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Operations.UseVisualStyleBackColor = True
        '
        'Btn_Payroll
        '
        Me.Btn_Payroll.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Payroll.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1Wave
        Me.Btn_Payroll.IconColor = System.Drawing.Color.Green
        Me.Btn_Payroll.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Payroll.IconSize = 60
        Me.Btn_Payroll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Payroll.Location = New System.Drawing.Point(3, 310)
        Me.Btn_Payroll.Name = "Btn_Payroll"
        Me.Btn_Payroll.Size = New System.Drawing.Size(277, 73)
        Me.Btn_Payroll.TabIndex = 32
        Me.Btn_Payroll.Text = "Payroll System"
        Me.Btn_Payroll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Payroll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Payroll.UseVisualStyleBackColor = True
        '
        'Btn_HR
        '
        Me.Btn_HR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_HR.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup
        Me.Btn_HR.IconColor = System.Drawing.Color.Blue
        Me.Btn_HR.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_HR.IconSize = 60
        Me.Btn_HR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_HR.Location = New System.Drawing.Point(3, 237)
        Me.Btn_HR.Name = "Btn_HR"
        Me.Btn_HR.Size = New System.Drawing.Size(277, 73)
        Me.Btn_HR.TabIndex = 31
        Me.Btn_HR.Text = "Human Resources"
        Me.Btn_HR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_HR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_HR.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(283, 231)
        Me.Panel2.TabIndex = 28
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.DMSA_System.My.Resources.Resources.DMSA_Logo
        Me.PictureBox2.Location = New System.Drawing.Point(41, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(200, 200)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 26
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1379, 872)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "email: kodogen.sds@gmail.com"
        '
        'GRP_Operations
        '
        Me.GRP_Operations.Controls.Add(Me.Btn_Schedule)
        Me.GRP_Operations.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRP_Operations.ForeColor = System.Drawing.Color.Maroon
        Me.GRP_Operations.Location = New System.Drawing.Point(300, 646)
        Me.GRP_Operations.Name = "GRP_Operations"
        Me.GRP_Operations.Size = New System.Drawing.Size(1045, 219)
        Me.GRP_Operations.TabIndex = 37
        Me.GRP_Operations.TabStop = False
        Me.GRP_Operations.Text = "Operations"
        Me.GRP_Operations.Visible = False
        '
        'FRM_MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1659, 901)
        Me.Controls.Add(Me.GRP_Operations)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GRP_Payroll)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Grp_HR_Menu)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_MAIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delta Maroon Security Agency Corp"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Grp_HR_Menu.ResumeLayout(False)
        Me.GRP_Payroll.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRP_Operations.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Grp_HR_Menu As GroupBox
    Friend WithEvents GRP_Payroll As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Btn_HR As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Payroll As FontAwesome.Sharp.IconButton
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Btn_EmployeeRecords As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_HR_Reports As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_ClientManagement As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Recruitment As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton9 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton8 As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Operations As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Btn_Payslip As IconButton
    Friend WithEvents Btn_DTR As IconButton
    Friend WithEvents Btn_Schedule As IconButton
    Friend WithEvents GRP_Operations As GroupBox
    Friend WithEvents AdminBtn As IconButton
End Class
