<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_HRIS_APPLICATION
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
        Me.Tab_Recruitment = New System.Windows.Forms.TabControl()
        Me.Tab_AppList = New System.Windows.Forms.TabPage()
        Me.Btn_Refresh = New FontAwesome.Sharp.IconButton()
        Me.Btn_SearchApplicant = New FontAwesome.Sharp.IconButton()
        Me.Btn_Abort_Application = New FontAwesome.Sharp.IconButton()
        Me.Btn_CancelApplication = New FontAwesome.Sharp.IconButton()
        Me.Btn_EditApplication = New FontAwesome.Sharp.IconButton()
        Me.Btn_NewApplication = New FontAwesome.Sharp.IconButton()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Cmb_Category = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.LV_Applicant_List = New System.Windows.Forms.ListView()
        Me.Col_AppID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_AppName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_DateApp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_AppStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tab_Application = New System.Windows.Forms.TabPage()
        Me.Grp_Application_Position = New System.Windows.Forms.GroupBox()
        Me.Cmb_Position = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Cmb_Department = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Opt_Non_SecurityPersonnel = New System.Windows.Forms.RadioButton()
        Me.Opt_SecurityPersonnel = New System.Windows.Forms.RadioButton()
        Me.Btn_Move_to_Interview = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Grp_Contact_Info = New System.Windows.Forms.GroupBox()
        Me.Txt_Contact_Address = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Txt_Contact_Number = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Cmb_Relationship = New System.Windows.Forms.ComboBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Txt_Contact_Name = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Grp_Application_Educ = New System.Windows.Forms.GroupBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Cmb_Grad_Year = New System.Windows.Forms.ComboBox()
        Me.Txt_Pos_Held = New System.Windows.Forms.TextBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Txt_Refer_Rem = New System.Windows.Forms.TextBox()
        Me.Cmb_Refer = New System.Windows.Forms.ComboBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Txt_PrevComp_Add = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Txt_Course = New System.Windows.Forms.TextBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Txt_PrevComp = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Cmb_Educ_Attainment = New System.Windows.Forms.ComboBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Grp_Application_BasicInfo = New System.Windows.Forms.GroupBox()
        Me.Cmb_BloodType = New System.Windows.Forms.ComboBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Txt_Maiden = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Cmb_Civil_Status = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Cmb_Religion = New System.Windows.Forms.ComboBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Txt_Weight = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Cmb_Height = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Txt_Email = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Txt_ContactNo = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Txt_ResiAdd = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Txt_Birthday = New System.Windows.Forms.TextBox()
        Me.DP_Bday = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Cmb_Gender = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt_LastName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_MiddleName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_FirstName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Lbl_App_ID = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Tab_Interview = New System.Windows.Forms.TabPage()
        Me.Btn_Interview_Cancel = New System.Windows.Forms.Button()
        Me.Grp_Interview = New System.Windows.Forms.GroupBox()
        Me.TxtInterview_Dir_Remarks = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TxtInterview_Op_Remarks = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Cmb_Int_DIR_Result = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Txt_Interview_Dir_Date = New System.Windows.Forms.TextBox()
        Me.DT_Interview3_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Cmb_InterviewDIR = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TxtInterview_HR_Remarks = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Cmb_Int_OPR_Result = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Cmb_Int_HR_Result = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txt_Interview_OP_Date = New System.Windows.Forms.TextBox()
        Me.DT_Interview2_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Cmb_InterviewOP = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtInterviewHR_Date = New System.Windows.Forms.TextBox()
        Me.DT_Interview1_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Cmb_InterviewHR = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Lbl_App_Interview_ID = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Btn_Move_to_REQ = New System.Windows.Forms.Button()
        Me.Btn_Interview_SAVE = New System.Windows.Forms.Button()
        Me.Tab_Processing = New System.Windows.Forms.TabPage()
        Me.Btn_Requirement_Cancel = New System.Windows.Forms.Button()
        Me.Prog_REQ = New System.Windows.Forms.ProgressBar()
        Me.Lbl_Req_App_ID = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Btn_Req_MoveNext = New System.Windows.Forms.Button()
        Me.Btn_Req_Save = New System.Windows.Forms.Button()
        Me.LV_Requirement_List = New System.Windows.Forms.ListView()
        Me.Col_Req_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_REQ_DESC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Tab_Completion = New System.Windows.Forms.TabPage()
        Me.Grp_Complete_GovNum = New System.Windows.Forms.GroupBox()
        Me.Txt_National_ID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Chk_GovIDs_NotAvailable = New System.Windows.Forms.CheckBox()
        Me.Txt_TIN = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_PhilHealth = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Txt_Pagibig = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Txt_SSS = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Grp_Complete_JobInfo = New System.Windows.Forms.GroupBox()
        Me.Btn_Manual_ID = New System.Windows.Forms.Button()
        Me.Txt_Client_Start_Date = New System.Windows.Forms.TextBox()
        Me.DP_Client_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Lbl_Client_Start_Date = New System.Windows.Forms.Label()
        Me.Lbl_Current_CLient_ID = New System.Windows.Forms.Label()
        Me.Lbl_ClientName = New System.Windows.Forms.Label()
        Me.Txt_ClientID = New System.Windows.Forms.TextBox()
        Me.Btn_GenerateID = New System.Windows.Forms.Button()
        Me.Btn_ShowClientList = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Employee_ID = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtDate_Hired = New System.Windows.Forms.TextBox()
        Me.DP_Date_Hired = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Lbl_Complete_App_ID = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Btn_Complete = New System.Windows.Forms.Button()
        Me.Btn_SemiComplete_Save = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Bar_AppProgress = New System.Windows.Forms.ProgressBar()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Tab_Recruitment.SuspendLayout()
        Me.Tab_AppList.SuspendLayout()
        Me.Tab_Application.SuspendLayout()
        Me.Grp_Application_Position.SuspendLayout()
        Me.Grp_Contact_Info.SuspendLayout()
        Me.Grp_Application_Educ.SuspendLayout()
        Me.Grp_Application_BasicInfo.SuspendLayout()
        Me.Tab_Interview.SuspendLayout()
        Me.Grp_Interview.SuspendLayout()
        Me.Tab_Processing.SuspendLayout()
        Me.Tab_Completion.SuspendLayout()
        Me.Grp_Complete_GovNum.SuspendLayout()
        Me.Grp_Complete_JobInfo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tab_Recruitment
        '
        Me.Tab_Recruitment.Controls.Add(Me.Tab_AppList)
        Me.Tab_Recruitment.Controls.Add(Me.Tab_Application)
        Me.Tab_Recruitment.Controls.Add(Me.Tab_Interview)
        Me.Tab_Recruitment.Controls.Add(Me.Tab_Processing)
        Me.Tab_Recruitment.Controls.Add(Me.Tab_Completion)
        Me.Tab_Recruitment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab_Recruitment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_Recruitment.HotTrack = True
        Me.Tab_Recruitment.Location = New System.Drawing.Point(34, 132)
        Me.Tab_Recruitment.Name = "Tab_Recruitment"
        Me.Tab_Recruitment.SelectedIndex = 0
        Me.Tab_Recruitment.Size = New System.Drawing.Size(1258, 714)
        Me.Tab_Recruitment.TabIndex = 2
        '
        'Tab_AppList
        '
        Me.Tab_AppList.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tab_AppList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab_AppList.Controls.Add(Me.Btn_Refresh)
        Me.Tab_AppList.Controls.Add(Me.Btn_SearchApplicant)
        Me.Tab_AppList.Controls.Add(Me.Btn_Abort_Application)
        Me.Tab_AppList.Controls.Add(Me.Btn_CancelApplication)
        Me.Tab_AppList.Controls.Add(Me.Btn_EditApplication)
        Me.Tab_AppList.Controls.Add(Me.Btn_NewApplication)
        Me.Tab_AppList.Controls.Add(Me.TxtSearch)
        Me.Tab_AppList.Controls.Add(Me.Cmb_Category)
        Me.Tab_AppList.Controls.Add(Me.Label63)
        Me.Tab_AppList.Controls.Add(Me.LV_Applicant_List)
        Me.Tab_AppList.Location = New System.Drawing.Point(4, 29)
        Me.Tab_AppList.Name = "Tab_AppList"
        Me.Tab_AppList.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_AppList.Size = New System.Drawing.Size(1250, 681)
        Me.Tab_AppList.TabIndex = 7
        Me.Tab_AppList.Text = "   Application List   "
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.IconChar = FontAwesome.Sharp.IconChar.Repeat
        Me.Btn_Refresh.IconColor = System.Drawing.Color.Green
        Me.Btn_Refresh.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Refresh.IconSize = 40
        Me.Btn_Refresh.Location = New System.Drawing.Point(13, 455)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(119, 94)
        Me.Btn_Refresh.TabIndex = 148
        Me.Btn_Refresh.Text = "Refresh"
        Me.Btn_Refresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refresh.UseVisualStyleBackColor = True
        '
        'Btn_SearchApplicant
        '
        Me.Btn_SearchApplicant.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass
        Me.Btn_SearchApplicant.IconColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_SearchApplicant.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_SearchApplicant.IconSize = 25
        Me.Btn_SearchApplicant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_SearchApplicant.Location = New System.Drawing.Point(530, 29)
        Me.Btn_SearchApplicant.Name = "Btn_SearchApplicant"
        Me.Btn_SearchApplicant.Size = New System.Drawing.Size(127, 31)
        Me.Btn_SearchApplicant.TabIndex = 147
        Me.Btn_SearchApplicant.Text = "Search"
        Me.Btn_SearchApplicant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_SearchApplicant.UseVisualStyleBackColor = True
        '
        'Btn_Abort_Application
        '
        Me.Btn_Abort_Application.Enabled = False
        Me.Btn_Abort_Application.IconChar = FontAwesome.Sharp.IconChar.Xmark
        Me.Btn_Abort_Application.IconColor = System.Drawing.Color.Red
        Me.Btn_Abort_Application.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Abort_Application.IconSize = 40
        Me.Btn_Abort_Application.Location = New System.Drawing.Point(13, 362)
        Me.Btn_Abort_Application.Name = "Btn_Abort_Application"
        Me.Btn_Abort_Application.Size = New System.Drawing.Size(119, 94)
        Me.Btn_Abort_Application.TabIndex = 146
        Me.Btn_Abort_Application.Text = "Abort"
        Me.Btn_Abort_Application.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Abort_Application.UseVisualStyleBackColor = True
        '
        'Btn_CancelApplication
        '
        Me.Btn_CancelApplication.Enabled = False
        Me.Btn_CancelApplication.IconChar = FontAwesome.Sharp.IconChar.Cancel
        Me.Btn_CancelApplication.IconColor = System.Drawing.Color.Red
        Me.Btn_CancelApplication.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_CancelApplication.IconSize = 40
        Me.Btn_CancelApplication.Location = New System.Drawing.Point(13, 269)
        Me.Btn_CancelApplication.Name = "Btn_CancelApplication"
        Me.Btn_CancelApplication.Size = New System.Drawing.Size(119, 94)
        Me.Btn_CancelApplication.TabIndex = 145
        Me.Btn_CancelApplication.Text = "Cancel"
        Me.Btn_CancelApplication.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_CancelApplication.UseVisualStyleBackColor = True
        '
        'Btn_EditApplication
        '
        Me.Btn_EditApplication.Enabled = False
        Me.Btn_EditApplication.IconChar = FontAwesome.Sharp.IconChar.Pen
        Me.Btn_EditApplication.IconColor = System.Drawing.Color.Blue
        Me.Btn_EditApplication.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_EditApplication.IconSize = 40
        Me.Btn_EditApplication.Location = New System.Drawing.Point(13, 176)
        Me.Btn_EditApplication.Name = "Btn_EditApplication"
        Me.Btn_EditApplication.Size = New System.Drawing.Size(119, 94)
        Me.Btn_EditApplication.TabIndex = 144
        Me.Btn_EditApplication.Text = "Edit"
        Me.Btn_EditApplication.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_EditApplication.UseVisualStyleBackColor = True
        '
        'Btn_NewApplication
        '
        Me.Btn_NewApplication.IconChar = FontAwesome.Sharp.IconChar.PlusCircle
        Me.Btn_NewApplication.IconColor = System.Drawing.Color.Green
        Me.Btn_NewApplication.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_NewApplication.Location = New System.Drawing.Point(13, 83)
        Me.Btn_NewApplication.Name = "Btn_NewApplication"
        Me.Btn_NewApplication.Size = New System.Drawing.Size(119, 94)
        Me.Btn_NewApplication.TabIndex = 143
        Me.Btn_NewApplication.Text = "New"
        Me.Btn_NewApplication.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_NewApplication.UseVisualStyleBackColor = True
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(290, 30)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(234, 27)
        Me.TxtSearch.TabIndex = 63
        '
        'Cmb_Category
        '
        Me.Cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Category.FormattingEnabled = True
        Me.Cmb_Category.Items.AddRange(New Object() {"LAST NAME", "STATUS", "ALL"})
        Me.Cmb_Category.Location = New System.Drawing.Point(114, 29)
        Me.Cmb_Category.Name = "Cmb_Category"
        Me.Cmb_Category.Size = New System.Drawing.Size(170, 28)
        Me.Cmb_Category.TabIndex = 61
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label63.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(20, 33)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(88, 18)
        Me.Label63.TabIndex = 62
        Me.Label63.Text = "Category:"
        '
        'LV_Applicant_List
        '
        Me.LV_Applicant_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Applicant_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_AppID, Me.Col_AppName, Me.Col_DateApp, Me.Col_AppStatus})
        Me.LV_Applicant_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Applicant_List.FullRowSelect = True
        Me.LV_Applicant_List.GridLines = True
        Me.LV_Applicant_List.HideSelection = False
        Me.LV_Applicant_List.Location = New System.Drawing.Point(138, 83)
        Me.LV_Applicant_List.Name = "LV_Applicant_List"
        Me.LV_Applicant_List.Size = New System.Drawing.Size(807, 549)
        Me.LV_Applicant_List.TabIndex = 60
        Me.LV_Applicant_List.UseCompatibleStateImageBehavior = False
        Me.LV_Applicant_List.View = System.Windows.Forms.View.Details
        '
        'Col_AppID
        '
        Me.Col_AppID.Text = "App ID"
        Me.Col_AppID.Width = 0
        '
        'Col_AppName
        '
        Me.Col_AppName.Text = "Applicant Name"
        Me.Col_AppName.Width = 300
        '
        'Col_DateApp
        '
        Me.Col_DateApp.Text = "Application Date"
        Me.Col_DateApp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_DateApp.Width = 250
        '
        'Col_AppStatus
        '
        Me.Col_AppStatus.Text = "Application Status"
        Me.Col_AppStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_AppStatus.Width = 250
        '
        'Tab_Application
        '
        Me.Tab_Application.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tab_Application.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Tab_Application.Controls.Add(Me.Grp_Application_Position)
        Me.Tab_Application.Controls.Add(Me.Btn_Move_to_Interview)
        Me.Tab_Application.Controls.Add(Me.Button1)
        Me.Tab_Application.Controls.Add(Me.Grp_Contact_Info)
        Me.Tab_Application.Controls.Add(Me.Grp_Application_Educ)
        Me.Tab_Application.Controls.Add(Me.Grp_Application_BasicInfo)
        Me.Tab_Application.Controls.Add(Me.BtnSave)
        Me.Tab_Application.Controls.Add(Me.Lbl_App_ID)
        Me.Tab_Application.Controls.Add(Me.Label49)
        Me.Tab_Application.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_Application.ForeColor = System.Drawing.Color.Black
        Me.Tab_Application.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Application.Name = "Tab_Application"
        Me.Tab_Application.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Application.Size = New System.Drawing.Size(1250, 681)
        Me.Tab_Application.TabIndex = 0
        Me.Tab_Application.Text = "   Application   "
        '
        'Grp_Application_Position
        '
        Me.Grp_Application_Position.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grp_Application_Position.Controls.Add(Me.Cmb_Position)
        Me.Grp_Application_Position.Controls.Add(Me.Label16)
        Me.Grp_Application_Position.Controls.Add(Me.Cmb_Department)
        Me.Grp_Application_Position.Controls.Add(Me.Label6)
        Me.Grp_Application_Position.Controls.Add(Me.Opt_Non_SecurityPersonnel)
        Me.Grp_Application_Position.Controls.Add(Me.Opt_SecurityPersonnel)
        Me.Grp_Application_Position.Enabled = False
        Me.Grp_Application_Position.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Grp_Application_Position.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Application_Position.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Application_Position.Location = New System.Drawing.Point(19, 19)
        Me.Grp_Application_Position.Name = "Grp_Application_Position"
        Me.Grp_Application_Position.Size = New System.Drawing.Size(909, 123)
        Me.Grp_Application_Position.TabIndex = 146
        Me.Grp_Application_Position.TabStop = False
        Me.Grp_Application_Position.Text = "Application Position"
        '
        'Cmb_Position
        '
        Me.Cmb_Position.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Position.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Position.FormattingEnabled = True
        Me.Cmb_Position.Items.AddRange(New Object() {"HR Chief", "HR Assisstent", "HR Staff", "Payroll Staff", "Accounting Staff", "Operations Staff", "Operation Officer", "Director"})
        Me.Cmb_Position.Location = New System.Drawing.Point(648, 70)
        Me.Cmb_Position.Name = "Cmb_Position"
        Me.Cmb_Position.Size = New System.Drawing.Size(203, 28)
        Me.Cmb_Position.TabIndex = 142
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(544, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 20)
        Me.Label16.TabIndex = 143
        Me.Label16.Text = "Position:"
        '
        'Cmb_Department
        '
        Me.Cmb_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Department.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Department.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Department.FormattingEnabled = True
        Me.Cmb_Department.Location = New System.Drawing.Point(648, 36)
        Me.Cmb_Department.Name = "Cmb_Department"
        Me.Cmb_Department.Size = New System.Drawing.Size(203, 28)
        Me.Cmb_Department.TabIndex = 140
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(544, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 20)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "Department:"
        '
        'Opt_Non_SecurityPersonnel
        '
        Me.Opt_Non_SecurityPersonnel.AutoSize = True
        Me.Opt_Non_SecurityPersonnel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Non_SecurityPersonnel.ForeColor = System.Drawing.Color.Green
        Me.Opt_Non_SecurityPersonnel.Location = New System.Drawing.Point(270, 57)
        Me.Opt_Non_SecurityPersonnel.Name = "Opt_Non_SecurityPersonnel"
        Me.Opt_Non_SecurityPersonnel.Size = New System.Drawing.Size(223, 23)
        Me.Opt_Non_SecurityPersonnel.TabIndex = 1
        Me.Opt_Non_SecurityPersonnel.Text = " Non-Security Personnel"
        Me.Opt_Non_SecurityPersonnel.UseVisualStyleBackColor = True
        '
        'Opt_SecurityPersonnel
        '
        Me.Opt_SecurityPersonnel.AutoSize = True
        Me.Opt_SecurityPersonnel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_SecurityPersonnel.ForeColor = System.Drawing.Color.Green
        Me.Opt_SecurityPersonnel.Location = New System.Drawing.Point(47, 57)
        Me.Opt_SecurityPersonnel.Name = "Opt_SecurityPersonnel"
        Me.Opt_SecurityPersonnel.Size = New System.Drawing.Size(184, 23)
        Me.Opt_SecurityPersonnel.TabIndex = 0
        Me.Opt_SecurityPersonnel.Text = " Security Personnel"
        Me.Opt_SecurityPersonnel.UseVisualStyleBackColor = True
        '
        'Btn_Move_to_Interview
        '
        Me.Btn_Move_to_Interview.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Move_to_Interview.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Move_to_Interview.ForeColor = System.Drawing.Color.Red
        Me.Btn_Move_to_Interview.Location = New System.Drawing.Point(974, 544)
        Me.Btn_Move_to_Interview.Name = "Btn_Move_to_Interview"
        Me.Btn_Move_to_Interview.Size = New System.Drawing.Size(234, 40)
        Me.Btn_Move_to_Interview.TabIndex = 143
        Me.Btn_Move_to_Interview.Text = "Move to Interview"
        Me.Btn_Move_to_Interview.UseVisualStyleBackColor = False
        Me.Btn_Move_to_Interview.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Yellow
        Me.Button1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1070, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 40)
        Me.Button1.TabIndex = 141
        Me.Button1.Text = "Simulation"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Grp_Contact_Info
        '
        Me.Grp_Contact_Info.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grp_Contact_Info.Controls.Add(Me.Txt_Contact_Address)
        Me.Grp_Contact_Info.Controls.Add(Me.Label56)
        Me.Grp_Contact_Info.Controls.Add(Me.Label53)
        Me.Grp_Contact_Info.Controls.Add(Me.Txt_Contact_Number)
        Me.Grp_Contact_Info.Controls.Add(Me.Label55)
        Me.Grp_Contact_Info.Controls.Add(Me.Cmb_Relationship)
        Me.Grp_Contact_Info.Controls.Add(Me.Label52)
        Me.Grp_Contact_Info.Controls.Add(Me.Txt_Contact_Name)
        Me.Grp_Contact_Info.Controls.Add(Me.Label47)
        Me.Grp_Contact_Info.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Contact_Info.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Contact_Info.Location = New System.Drawing.Point(19, 553)
        Me.Grp_Contact_Info.Name = "Grp_Contact_Info"
        Me.Grp_Contact_Info.Size = New System.Drawing.Size(927, 117)
        Me.Grp_Contact_Info.TabIndex = 142
        Me.Grp_Contact_Info.TabStop = False
        Me.Grp_Contact_Info.Text = "Contact Information"
        '
        'Txt_Contact_Address
        '
        Me.Txt_Contact_Address.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_Address.Location = New System.Drawing.Point(569, 72)
        Me.Txt_Contact_Address.Name = "Txt_Contact_Address"
        Me.Txt_Contact_Address.Size = New System.Drawing.Size(304, 26)
        Me.Txt_Contact_Address.TabIndex = 137
        Me.Txt_Contact_Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.Black
        Me.Label56.Location = New System.Drawing.Point(489, 78)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(72, 20)
        Me.Label56.TabIndex = 136
        Me.Label56.Text = "Address:"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(168, 75)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(36, 20)
        Me.Label53.TabIndex = 138
        Me.Label53.Text = "+63"
        '
        'Txt_Contact_Number
        '
        Me.Txt_Contact_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_Number.Location = New System.Drawing.Point(210, 72)
        Me.Txt_Contact_Number.Name = "Txt_Contact_Number"
        Me.Txt_Contact_Number.Size = New System.Drawing.Size(162, 26)
        Me.Txt_Contact_Number.TabIndex = 136
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(23, 75)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(97, 20)
        Me.Label55.TabIndex = 137
        Me.Label55.Text = "Contact No.:"
        '
        'Cmb_Relationship
        '
        Me.Cmb_Relationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Relationship.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Relationship.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Relationship.FormattingEnabled = True
        Me.Cmb_Relationship.Items.AddRange(New Object() {"Spouse", "Mother", "Father", "Son", "Daughter", "Relative", "Guardian", "Live-in Partner"})
        Me.Cmb_Relationship.Location = New System.Drawing.Point(704, 40)
        Me.Cmb_Relationship.Name = "Cmb_Relationship"
        Me.Cmb_Relationship.Size = New System.Drawing.Size(169, 28)
        Me.Cmb_Relationship.TabIndex = 130
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(597, 43)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(101, 20)
        Me.Label52.TabIndex = 131
        Me.Label52.Text = "Relationship:"
        '
        'Txt_Contact_Name
        '
        Me.Txt_Contact_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_Name.Location = New System.Drawing.Point(210, 40)
        Me.Txt_Contact_Name.Name = "Txt_Contact_Name"
        Me.Txt_Contact_Name.Size = New System.Drawing.Size(342, 26)
        Me.Txt_Contact_Name.TabIndex = 123
        Me.Txt_Contact_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(21, 43)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(144, 20)
        Me.Label47.TabIndex = 122
        Me.Label47.Text = "Contact Full Name:"
        '
        'Grp_Application_Educ
        '
        Me.Grp_Application_Educ.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grp_Application_Educ.Controls.Add(Me.Label34)
        Me.Grp_Application_Educ.Controls.Add(Me.Cmb_Grad_Year)
        Me.Grp_Application_Educ.Controls.Add(Me.Txt_Pos_Held)
        Me.Grp_Application_Educ.Controls.Add(Me.Label94)
        Me.Grp_Application_Educ.Controls.Add(Me.Txt_Refer_Rem)
        Me.Grp_Application_Educ.Controls.Add(Me.Cmb_Refer)
        Me.Grp_Application_Educ.Controls.Add(Me.Label90)
        Me.Grp_Application_Educ.Controls.Add(Me.Txt_PrevComp_Add)
        Me.Grp_Application_Educ.Controls.Add(Me.Label89)
        Me.Grp_Application_Educ.Controls.Add(Me.Label88)
        Me.Grp_Application_Educ.Controls.Add(Me.Txt_Course)
        Me.Grp_Application_Educ.Controls.Add(Me.Label87)
        Me.Grp_Application_Educ.Controls.Add(Me.Txt_PrevComp)
        Me.Grp_Application_Educ.Controls.Add(Me.Label86)
        Me.Grp_Application_Educ.Controls.Add(Me.Cmb_Educ_Attainment)
        Me.Grp_Application_Educ.Controls.Add(Me.Label84)
        Me.Grp_Application_Educ.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Application_Educ.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Application_Educ.Location = New System.Drawing.Point(19, 394)
        Me.Grp_Application_Educ.Name = "Grp_Application_Educ"
        Me.Grp_Application_Educ.Size = New System.Drawing.Size(1189, 153)
        Me.Grp_Application_Educ.TabIndex = 122
        Me.Grp_Application_Educ.TabStop = False
        Me.Grp_Application_Educ.Text = "Education and Work Experience"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(382, 114)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(96, 20)
        Me.Label34.TabIndex = 135
        Me.Label34.Text = "Referred by:"
        '
        'Cmb_Grad_Year
        '
        Me.Cmb_Grad_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Grad_Year.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Grad_Year.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Grad_Year.FormattingEnabled = True
        Me.Cmb_Grad_Year.Location = New System.Drawing.Point(866, 42)
        Me.Cmb_Grad_Year.Name = "Cmb_Grad_Year"
        Me.Cmb_Grad_Year.Size = New System.Drawing.Size(98, 28)
        Me.Cmb_Grad_Year.TabIndex = 134
        '
        'Txt_Pos_Held
        '
        Me.Txt_Pos_Held.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Pos_Held.Location = New System.Drawing.Point(564, 78)
        Me.Txt_Pos_Held.Name = "Txt_Pos_Held"
        Me.Txt_Pos_Held.Size = New System.Drawing.Size(195, 26)
        Me.Txt_Pos_Held.TabIndex = 132
        Me.Txt_Pos_Held.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.ForeColor = System.Drawing.Color.Black
        Me.Label94.Location = New System.Drawing.Point(455, 82)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(106, 20)
        Me.Label94.TabIndex = 131
        Me.Label94.Text = "Position Held:"
        '
        'Txt_Refer_Rem
        '
        Me.Txt_Refer_Rem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Refer_Rem.Location = New System.Drawing.Point(479, 111)
        Me.Txt_Refer_Rem.Name = "Txt_Refer_Rem"
        Me.Txt_Refer_Rem.Size = New System.Drawing.Size(280, 26)
        Me.Txt_Refer_Rem.TabIndex = 130
        Me.Txt_Refer_Rem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Cmb_Refer
        '
        Me.Cmb_Refer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Refer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Refer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Refer.FormattingEnabled = True
        Me.Cmb_Refer.Items.AddRange(New Object() {"Walk-In", "Referred by"})
        Me.Cmb_Refer.Location = New System.Drawing.Point(210, 108)
        Me.Cmb_Refer.Name = "Cmb_Refer"
        Me.Cmb_Refer.Size = New System.Drawing.Size(154, 28)
        Me.Cmb_Refer.TabIndex = 128
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Black
        Me.Label90.Location = New System.Drawing.Point(21, 114)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(70, 20)
        Me.Label90.TabIndex = 129
        Me.Label90.Text = "Referral:"
        '
        'Txt_PrevComp_Add
        '
        Me.Txt_PrevComp_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PrevComp_Add.Location = New System.Drawing.Point(866, 78)
        Me.Txt_PrevComp_Add.Name = "Txt_PrevComp_Add"
        Me.Txt_PrevComp_Add.Size = New System.Drawing.Size(304, 26)
        Me.Txt_PrevComp_Add.TabIndex = 127
        Me.Txt_PrevComp_Add.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.Black
        Me.Label89.Location = New System.Drawing.Point(455, 48)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(64, 20)
        Me.Label89.TabIndex = 126
        Me.Label89.Text = "Course:"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.Black
        Me.Label88.Location = New System.Drawing.Point(788, 48)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(47, 20)
        Me.Label88.TabIndex = 125
        Me.Label88.Text = "Year:"
        '
        'Txt_Course
        '
        Me.Txt_Course.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Course.Location = New System.Drawing.Point(564, 42)
        Me.Txt_Course.Name = "Txt_Course"
        Me.Txt_Course.Size = New System.Drawing.Size(195, 26)
        Me.Txt_Course.TabIndex = 123
        Me.Txt_Course.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.Black
        Me.Label87.Location = New System.Drawing.Point(786, 84)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(72, 20)
        Me.Label87.TabIndex = 122
        Me.Label87.Text = "Address:"
        '
        'Txt_PrevComp
        '
        Me.Txt_PrevComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PrevComp.Location = New System.Drawing.Point(210, 76)
        Me.Txt_PrevComp.Name = "Txt_PrevComp"
        Me.Txt_PrevComp.Size = New System.Drawing.Size(232, 26)
        Me.Txt_PrevComp.TabIndex = 121
        Me.Txt_PrevComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.Black
        Me.Label86.Location = New System.Drawing.Point(22, 82)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(172, 20)
        Me.Label86.TabIndex = 120
        Me.Label86.Text = "Last Company/Agency:"
        '
        'Cmb_Educ_Attainment
        '
        Me.Cmb_Educ_Attainment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Educ_Attainment.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Educ_Attainment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Educ_Attainment.FormattingEnabled = True
        Me.Cmb_Educ_Attainment.Items.AddRange(New Object() {"High School Graduate", "College Graduate", "Vocational Graduate", "College Under Graduate", "High School Under Graduate"})
        Me.Cmb_Educ_Attainment.Location = New System.Drawing.Point(210, 42)
        Me.Cmb_Educ_Attainment.Name = "Cmb_Educ_Attainment"
        Me.Cmb_Educ_Attainment.Size = New System.Drawing.Size(232, 28)
        Me.Cmb_Educ_Attainment.TabIndex = 118
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.Black
        Me.Label84.Location = New System.Drawing.Point(21, 48)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(179, 20)
        Me.Label84.TabIndex = 119
        Me.Label84.Text = "Educational Attainment:"
        '
        'Grp_Application_BasicInfo
        '
        Me.Grp_Application_BasicInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Cmb_BloodType)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label46)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label45)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_Maiden)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label44)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Cmb_Civil_Status)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label35)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label93)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Cmb_Religion)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label91)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_Weight)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label83)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label50)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Cmb_Height)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label51)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_Email)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label48)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_ContactNo)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label32)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_ResiAdd)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label15)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_Birthday)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.DP_Bday)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label13)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Cmb_Gender)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label14)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_LastName)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label10)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_MiddleName)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label11)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Txt_FirstName)
        Me.Grp_Application_BasicInfo.Controls.Add(Me.Label12)
        Me.Grp_Application_BasicInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Grp_Application_BasicInfo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Application_BasicInfo.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Application_BasicInfo.Location = New System.Drawing.Point(19, 148)
        Me.Grp_Application_BasicInfo.Name = "Grp_Application_BasicInfo"
        Me.Grp_Application_BasicInfo.Size = New System.Drawing.Size(1189, 240)
        Me.Grp_Application_BasicInfo.TabIndex = 120
        Me.Grp_Application_BasicInfo.TabStop = False
        Me.Grp_Application_BasicInfo.Text = "Basic Information"
        '
        'Cmb_BloodType
        '
        Me.Cmb_BloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_BloodType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_BloodType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_BloodType.FormattingEnabled = True
        Me.Cmb_BloodType.Items.AddRange(New Object() {"A positive (A+)", "A negative (A-)", "B positive (B+)", "B negative (B-)", "AB positive (AB+)", "AB negative (AB-)", "O positive (O+)", "O negative (O-)", "To Follow"})
        Me.Cmb_BloodType.Location = New System.Drawing.Point(426, 110)
        Me.Cmb_BloodType.Name = "Cmb_BloodType"
        Me.Cmb_BloodType.Size = New System.Drawing.Size(144, 28)
        Me.Cmb_BloodType.TabIndex = 147
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(335, 112)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(92, 20)
        Me.Label46.TabIndex = 148
        Me.Label46.Text = "Blood Type:"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(779, 49)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(14, 20)
        Me.Label45.TabIndex = 146
        Me.Label45.Text = "-"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Txt_Maiden
        '
        Me.Txt_Maiden.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Maiden.Location = New System.Drawing.Point(806, 46)
        Me.Txt_Maiden.Name = "Txt_Maiden"
        Me.Txt_Maiden.Size = New System.Drawing.Size(322, 26)
        Me.Txt_Maiden.TabIndex = 144
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(802, 25)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(176, 20)
        Me.Label44.TabIndex = 145
        Me.Label44.Text = "Mother's Maiden Name:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cmb_Civil_Status
        '
        Me.Cmb_Civil_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Civil_Status.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Civil_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Civil_Status.FormattingEnabled = True
        Me.Cmb_Civil_Status.Items.AddRange(New Object() {"Single", "Married", "Widow"})
        Me.Cmb_Civil_Status.Location = New System.Drawing.Point(134, 79)
        Me.Cmb_Civil_Status.Name = "Cmb_Civil_Status"
        Me.Cmb_Civil_Status.Size = New System.Drawing.Size(154, 28)
        Me.Cmb_Civil_Status.TabIndex = 142
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(21, 82)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(91, 20)
        Me.Label35.TabIndex = 143
        Me.Label35.Text = "Civil Status:"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.Color.Black
        Me.Label93.Location = New System.Drawing.Point(23, 51)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(55, 20)
        Me.Label93.TabIndex = 140
        Me.Label93.Text = "Name:"
        '
        'Cmb_Religion
        '
        Me.Cmb_Religion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Religion.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Religion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Religion.FormattingEnabled = True
        Me.Cmb_Religion.Items.AddRange(New Object() {"Catholic", "Born Again", "Muslim", "INC", "Others"})
        Me.Cmb_Religion.Location = New System.Drawing.Point(684, 108)
        Me.Cmb_Religion.Name = "Cmb_Religion"
        Me.Cmb_Religion.Size = New System.Drawing.Size(154, 28)
        Me.Cmb_Religion.TabIndex = 138
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.Black
        Me.Label91.Location = New System.Drawing.Point(608, 110)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(70, 20)
        Me.Label91.TabIndex = 139
        Me.Label91.Text = "Religion:"
        '
        'Txt_Weight
        '
        Me.Txt_Weight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Weight.Location = New System.Drawing.Point(426, 143)
        Me.Txt_Weight.Name = "Txt_Weight"
        Me.Txt_Weight.Size = New System.Drawing.Size(107, 26)
        Me.Txt_Weight.TabIndex = 137
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.Black
        Me.Label83.Location = New System.Drawing.Point(331, 146)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(96, 20)
        Me.Label83.TabIndex = 136
        Me.Label83.Text = "Weight (Kg):"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(723, 174)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(36, 20)
        Me.Label50.TabIndex = 135
        Me.Label50.Text = "+63"
        '
        'Cmb_Height
        '
        Me.Cmb_Height.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Height.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Height.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Height.FormattingEnabled = True
        Me.Cmb_Height.Items.AddRange(New Object() {"4ft 5in", "4ft 6in", "4ft 7in", "4ft 8in", "4ft 9in", "4ft 10in", "4ft 11in", "5ft", "5ft 1in", "5ft 2in", "5ft 3in", "5ft 4in", "5ft 5in", "5ft 6in", "5ft 7in", "5ft 8in", "5ft 9in", "5ft 10in", "5ft 11in", "6ft"})
        Me.Cmb_Height.Location = New System.Drawing.Point(133, 146)
        Me.Cmb_Height.Name = "Cmb_Height"
        Me.Cmb_Height.Size = New System.Drawing.Size(116, 28)
        Me.Cmb_Height.TabIndex = 133
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(22, 149)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(60, 20)
        Me.Label51.TabIndex = 134
        Me.Label51.Text = "Height:"
        '
        'Txt_Email
        '
        Me.Txt_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Email.Location = New System.Drawing.Point(727, 203)
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.Size = New System.Drawing.Size(293, 26)
        Me.Txt_Email.TabIndex = 131
        Me.Txt_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(610, 206)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(90, 20)
        Me.Label48.TabIndex = 132
        Me.Label48.Text = "E-mail Add:"
        '
        'Txt_ContactNo
        '
        Me.Txt_ContactNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ContactNo.Location = New System.Drawing.Point(765, 171)
        Me.Txt_ContactNo.Name = "Txt_ContactNo"
        Me.Txt_ContactNo.Size = New System.Drawing.Size(162, 26)
        Me.Txt_ContactNo.TabIndex = 129
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(611, 177)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(97, 20)
        Me.Label32.TabIndex = 130
        Me.Label32.Text = "Contact No.:"
        '
        'Txt_ResiAdd
        '
        Me.Txt_ResiAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ResiAdd.Location = New System.Drawing.Point(133, 180)
        Me.Txt_ResiAdd.Multiline = True
        Me.Txt_ResiAdd.Name = "Txt_ResiAdd"
        Me.Txt_ResiAdd.Size = New System.Drawing.Size(414, 47)
        Me.Txt_ResiAdd.TabIndex = 127
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(22, 197)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 20)
        Me.Label15.TabIndex = 128
        Me.Label15.Text = "Address:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Txt_Birthday
        '
        Me.Txt_Birthday.Enabled = False
        Me.Txt_Birthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Birthday.Location = New System.Drawing.Point(426, 79)
        Me.Txt_Birthday.Name = "Txt_Birthday"
        Me.Txt_Birthday.Size = New System.Drawing.Size(227, 26)
        Me.Txt_Birthday.TabIndex = 126
        Me.Txt_Birthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Bday
        '
        Me.DP_Bday.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Bday.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Bday.Location = New System.Drawing.Point(654, 79)
        Me.DP_Bday.Name = "DP_Bday"
        Me.DP_Bday.Size = New System.Drawing.Size(17, 26)
        Me.DP_Bday.TabIndex = 122
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(335, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 20)
        Me.Label13.TabIndex = 125
        Me.Label13.Text = "Birthday:"
        '
        'Cmb_Gender
        '
        Me.Cmb_Gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Gender.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Gender.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Gender.FormattingEnabled = True
        Me.Cmb_Gender.Items.AddRange(New Object() {"Male", "Female"})
        Me.Cmb_Gender.Location = New System.Drawing.Point(134, 112)
        Me.Cmb_Gender.Name = "Cmb_Gender"
        Me.Cmb_Gender.Size = New System.Drawing.Size(154, 28)
        Me.Cmb_Gender.TabIndex = 123
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(21, 115)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 20)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "Gender:"
        '
        'Txt_LastName
        '
        Me.Txt_LastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LastName.Location = New System.Drawing.Point(538, 45)
        Me.Txt_LastName.Name = "Txt_LastName"
        Me.Txt_LastName.Size = New System.Drawing.Size(221, 26)
        Me.Txt_LastName.TabIndex = 119
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(534, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 20)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Last Name:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Txt_MiddleName
        '
        Me.Txt_MiddleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MiddleName.Location = New System.Drawing.Point(339, 47)
        Me.Txt_MiddleName.Name = "Txt_MiddleName"
        Me.Txt_MiddleName.Size = New System.Drawing.Size(186, 26)
        Me.Txt_MiddleName.TabIndex = 117
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(342, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 20)
        Me.Label11.TabIndex = 120
        Me.Label11.Text = "Middle Name:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Txt_FirstName
        '
        Me.Txt_FirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_FirstName.Location = New System.Drawing.Point(134, 48)
        Me.Txt_FirstName.Name = "Txt_FirstName"
        Me.Txt_FirstName.Size = New System.Drawing.Size(190, 26)
        Me.Txt_FirstName.TabIndex = 116
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(130, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 20)
        Me.Label12.TabIndex = 118
        Me.Label12.Text = "First Name:"
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnSave.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(1047, 611)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(161, 40)
        Me.BtnSave.TabIndex = 91
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Lbl_App_ID
        '
        Me.Lbl_App_ID.AutoSize = True
        Me.Lbl_App_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_App_ID.ForeColor = System.Drawing.Color.Red
        Me.Lbl_App_ID.Location = New System.Drawing.Point(1153, 8)
        Me.Lbl_App_ID.Name = "Lbl_App_ID"
        Me.Lbl_App_ID.Size = New System.Drawing.Size(55, 24)
        Me.Lbl_App_ID.TabIndex = 52
        Me.Lbl_App_ID.Text = "XXX"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Red
        Me.Label49.Location = New System.Drawing.Point(1002, 8)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(145, 24)
        Me.Label49.TabIndex = 51
        Me.Label49.Text = "Application ID:"
        '
        'Tab_Interview
        '
        Me.Tab_Interview.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tab_Interview.Controls.Add(Me.Btn_Interview_Cancel)
        Me.Tab_Interview.Controls.Add(Me.Grp_Interview)
        Me.Tab_Interview.Controls.Add(Me.Lbl_App_Interview_ID)
        Me.Tab_Interview.Controls.Add(Me.Label71)
        Me.Tab_Interview.Controls.Add(Me.Btn_Move_to_REQ)
        Me.Tab_Interview.Controls.Add(Me.Btn_Interview_SAVE)
        Me.Tab_Interview.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Interview.Name = "Tab_Interview"
        Me.Tab_Interview.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Interview.Size = New System.Drawing.Size(1250, 681)
        Me.Tab_Interview.TabIndex = 1
        Me.Tab_Interview.Text = "   Interview   "
        '
        'Btn_Interview_Cancel
        '
        Me.Btn_Interview_Cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Interview_Cancel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Interview_Cancel.ForeColor = System.Drawing.Color.Red
        Me.Btn_Interview_Cancel.Location = New System.Drawing.Point(28, 588)
        Me.Btn_Interview_Cancel.Name = "Btn_Interview_Cancel"
        Me.Btn_Interview_Cancel.Size = New System.Drawing.Size(220, 40)
        Me.Btn_Interview_Cancel.TabIndex = 122
        Me.Btn_Interview_Cancel.Text = "Abort/Cancel Application"
        Me.Btn_Interview_Cancel.UseVisualStyleBackColor = False
        '
        'Grp_Interview
        '
        Me.Grp_Interview.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grp_Interview.Controls.Add(Me.TxtInterview_Dir_Remarks)
        Me.Grp_Interview.Controls.Add(Me.Label41)
        Me.Grp_Interview.Controls.Add(Me.TxtInterview_Op_Remarks)
        Me.Grp_Interview.Controls.Add(Me.Label40)
        Me.Grp_Interview.Controls.Add(Me.Cmb_Int_DIR_Result)
        Me.Grp_Interview.Controls.Add(Me.Label36)
        Me.Grp_Interview.Controls.Add(Me.Txt_Interview_Dir_Date)
        Me.Grp_Interview.Controls.Add(Me.DT_Interview3_Date)
        Me.Grp_Interview.Controls.Add(Me.Label37)
        Me.Grp_Interview.Controls.Add(Me.Label38)
        Me.Grp_Interview.Controls.Add(Me.Cmb_InterviewDIR)
        Me.Grp_Interview.Controls.Add(Me.Label39)
        Me.Grp_Interview.Controls.Add(Me.TxtInterview_HR_Remarks)
        Me.Grp_Interview.Controls.Add(Me.Label54)
        Me.Grp_Interview.Controls.Add(Me.Cmb_Int_OPR_Result)
        Me.Grp_Interview.Controls.Add(Me.Label23)
        Me.Grp_Interview.Controls.Add(Me.Cmb_Int_HR_Result)
        Me.Grp_Interview.Controls.Add(Me.Label17)
        Me.Grp_Interview.Controls.Add(Me.Txt_Interview_OP_Date)
        Me.Grp_Interview.Controls.Add(Me.DT_Interview2_Date)
        Me.Grp_Interview.Controls.Add(Me.Label21)
        Me.Grp_Interview.Controls.Add(Me.Label22)
        Me.Grp_Interview.Controls.Add(Me.Cmb_InterviewOP)
        Me.Grp_Interview.Controls.Add(Me.Label24)
        Me.Grp_Interview.Controls.Add(Me.TxtInterviewHR_Date)
        Me.Grp_Interview.Controls.Add(Me.DT_Interview1_Date)
        Me.Grp_Interview.Controls.Add(Me.Label20)
        Me.Grp_Interview.Controls.Add(Me.Label19)
        Me.Grp_Interview.Controls.Add(Me.Cmb_InterviewHR)
        Me.Grp_Interview.Controls.Add(Me.Label18)
        Me.Grp_Interview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Grp_Interview.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Interview.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Interview.Location = New System.Drawing.Point(23, 42)
        Me.Grp_Interview.Name = "Grp_Interview"
        Me.Grp_Interview.Size = New System.Drawing.Size(1189, 487)
        Me.Grp_Interview.TabIndex = 121
        Me.Grp_Interview.TabStop = False
        Me.Grp_Interview.Text = "Interview"
        '
        'TxtInterview_Dir_Remarks
        '
        Me.TxtInterview_Dir_Remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInterview_Dir_Remarks.Location = New System.Drawing.Point(512, 357)
        Me.TxtInterview_Dir_Remarks.Multiline = True
        Me.TxtInterview_Dir_Remarks.Name = "TxtInterview_Dir_Remarks"
        Me.TxtInterview_Dir_Remarks.Size = New System.Drawing.Size(612, 76)
        Me.TxtInterview_Dir_Remarks.TabIndex = 114
        Me.TxtInterview_Dir_Remarks.Text = "-"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(508, 333)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(77, 20)
        Me.Label41.TabIndex = 115
        Me.Label41.Text = "Remarks:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtInterview_Op_Remarks
        '
        Me.TxtInterview_Op_Remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInterview_Op_Remarks.Location = New System.Drawing.Point(512, 207)
        Me.TxtInterview_Op_Remarks.Multiline = True
        Me.TxtInterview_Op_Remarks.Name = "TxtInterview_Op_Remarks"
        Me.TxtInterview_Op_Remarks.Size = New System.Drawing.Size(612, 76)
        Me.TxtInterview_Op_Remarks.TabIndex = 112
        Me.TxtInterview_Op_Remarks.Text = "-"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(508, 183)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(77, 20)
        Me.Label40.TabIndex = 113
        Me.Label40.Text = "Remarks:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cmb_Int_DIR_Result
        '
        Me.Cmb_Int_DIR_Result.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Int_DIR_Result.FormattingEnabled = True
        Me.Cmb_Int_DIR_Result.Items.AddRange(New Object() {"Pass", "Fail", "NA"})
        Me.Cmb_Int_DIR_Result.Location = New System.Drawing.Point(195, 426)
        Me.Cmb_Int_DIR_Result.Name = "Cmb_Int_DIR_Result"
        Me.Cmb_Int_DIR_Result.Size = New System.Drawing.Size(99, 28)
        Me.Cmb_Int_DIR_Result.TabIndex = 110
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(130, 429)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(59, 20)
        Me.Label36.TabIndex = 111
        Me.Label36.Text = "Result:"
        '
        'Txt_Interview_Dir_Date
        '
        Me.Txt_Interview_Dir_Date.Enabled = False
        Me.Txt_Interview_Dir_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Interview_Dir_Date.Location = New System.Drawing.Point(195, 394)
        Me.Txt_Interview_Dir_Date.Name = "Txt_Interview_Dir_Date"
        Me.Txt_Interview_Dir_Date.Size = New System.Drawing.Size(227, 26)
        Me.Txt_Interview_Dir_Date.TabIndex = 109
        Me.Txt_Interview_Dir_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DT_Interview3_Date
        '
        Me.DT_Interview3_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Interview3_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Interview3_Date.Location = New System.Drawing.Point(423, 394)
        Me.DT_Interview3_Date.Name = "DT_Interview3_Date"
        Me.DT_Interview3_Date.Size = New System.Drawing.Size(17, 26)
        Me.DT_Interview3_Date.TabIndex = 107
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(141, 397)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(48, 20)
        Me.Label37.TabIndex = 108
        Me.Label37.Text = "Date:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Blue
        Me.Label38.Location = New System.Drawing.Point(36, 333)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(234, 24)
        Me.Label38.TabIndex = 106
        Me.Label38.Text = "3rd Interview ( Director )"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cmb_InterviewDIR
        '
        Me.Cmb_InterviewDIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_InterviewDIR.FormattingEnabled = True
        Me.Cmb_InterviewDIR.Items.AddRange(New Object() {"Liza Castillo", "NA"})
        Me.Cmb_InterviewDIR.Location = New System.Drawing.Point(195, 360)
        Me.Cmb_InterviewDIR.Name = "Cmb_InterviewDIR"
        Me.Cmb_InterviewDIR.Size = New System.Drawing.Size(245, 28)
        Me.Cmb_InterviewDIR.TabIndex = 104
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(75, 364)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(114, 20)
        Me.Label39.TabIndex = 105
        Me.Label39.Text = "Interviewed by:"
        '
        'TxtInterview_HR_Remarks
        '
        Me.TxtInterview_HR_Remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInterview_HR_Remarks.Location = New System.Drawing.Point(512, 61)
        Me.TxtInterview_HR_Remarks.Multiline = True
        Me.TxtInterview_HR_Remarks.Name = "TxtInterview_HR_Remarks"
        Me.TxtInterview_HR_Remarks.Size = New System.Drawing.Size(612, 73)
        Me.TxtInterview_HR_Remarks.TabIndex = 102
        Me.TxtInterview_HR_Remarks.Text = "-"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Black
        Me.Label54.Location = New System.Drawing.Point(508, 37)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(77, 20)
        Me.Label54.TabIndex = 103
        Me.Label54.Text = "Remarks:"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cmb_Int_OPR_Result
        '
        Me.Cmb_Int_OPR_Result.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Int_OPR_Result.FormattingEnabled = True
        Me.Cmb_Int_OPR_Result.Items.AddRange(New Object() {"Pass", "Fail"})
        Me.Cmb_Int_OPR_Result.Location = New System.Drawing.Point(195, 276)
        Me.Cmb_Int_OPR_Result.Name = "Cmb_Int_OPR_Result"
        Me.Cmb_Int_OPR_Result.Size = New System.Drawing.Size(99, 28)
        Me.Cmb_Int_OPR_Result.TabIndex = 100
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(130, 279)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(59, 20)
        Me.Label23.TabIndex = 101
        Me.Label23.Text = "Result:"
        '
        'Cmb_Int_HR_Result
        '
        Me.Cmb_Int_HR_Result.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Int_HR_Result.FormattingEnabled = True
        Me.Cmb_Int_HR_Result.Items.AddRange(New Object() {"Pass", "Fail"})
        Me.Cmb_Int_HR_Result.Location = New System.Drawing.Point(195, 130)
        Me.Cmb_Int_HR_Result.Name = "Cmb_Int_HR_Result"
        Me.Cmb_Int_HR_Result.Size = New System.Drawing.Size(99, 28)
        Me.Cmb_Int_HR_Result.TabIndex = 98
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(130, 133)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 20)
        Me.Label17.TabIndex = 99
        Me.Label17.Text = "Result:"
        '
        'Txt_Interview_OP_Date
        '
        Me.Txt_Interview_OP_Date.Enabled = False
        Me.Txt_Interview_OP_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Interview_OP_Date.Location = New System.Drawing.Point(195, 244)
        Me.Txt_Interview_OP_Date.Name = "Txt_Interview_OP_Date"
        Me.Txt_Interview_OP_Date.Size = New System.Drawing.Size(227, 26)
        Me.Txt_Interview_OP_Date.TabIndex = 97
        Me.Txt_Interview_OP_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DT_Interview2_Date
        '
        Me.DT_Interview2_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Interview2_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Interview2_Date.Location = New System.Drawing.Point(423, 244)
        Me.DT_Interview2_Date.Name = "DT_Interview2_Date"
        Me.DT_Interview2_Date.Size = New System.Drawing.Size(17, 26)
        Me.DT_Interview2_Date.TabIndex = 95
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(141, 247)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 20)
        Me.Label21.TabIndex = 96
        Me.Label21.Text = "Date:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(36, 183)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(268, 24)
        Me.Label22.TabIndex = 94
        Me.Label22.Text = "2nd Interview ( Operations )"
        '
        'Cmb_InterviewOP
        '
        Me.Cmb_InterviewOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_InterviewOP.FormattingEnabled = True
        Me.Cmb_InterviewOP.Items.AddRange(New Object() {"Raymund Alturas", "Leonald Anoyo", "Victoriano Peria", "NA"})
        Me.Cmb_InterviewOP.Location = New System.Drawing.Point(195, 210)
        Me.Cmb_InterviewOP.Name = "Cmb_InterviewOP"
        Me.Cmb_InterviewOP.Size = New System.Drawing.Size(245, 28)
        Me.Cmb_InterviewOP.TabIndex = 92
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(75, 214)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(114, 20)
        Me.Label24.TabIndex = 93
        Me.Label24.Text = "Interviewed by:"
        '
        'TxtInterviewHR_Date
        '
        Me.TxtInterviewHR_Date.Enabled = False
        Me.TxtInterviewHR_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInterviewHR_Date.Location = New System.Drawing.Point(195, 98)
        Me.TxtInterviewHR_Date.Name = "TxtInterviewHR_Date"
        Me.TxtInterviewHR_Date.Size = New System.Drawing.Size(227, 26)
        Me.TxtInterviewHR_Date.TabIndex = 91
        Me.TxtInterviewHR_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DT_Interview1_Date
        '
        Me.DT_Interview1_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Interview1_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Interview1_Date.Location = New System.Drawing.Point(423, 98)
        Me.DT_Interview1_Date.Name = "DT_Interview1_Date"
        Me.DT_Interview1_Date.Size = New System.Drawing.Size(17, 26)
        Me.DT_Interview1_Date.TabIndex = 89
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(141, 100)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 20)
        Me.Label20.TabIndex = 90
        Me.Label20.Text = "Date:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(36, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(174, 24)
        Me.Label19.TabIndex = 88
        Me.Label19.Text = "1st Interview (HR)"
        '
        'Cmb_InterviewHR
        '
        Me.Cmb_InterviewHR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_InterviewHR.FormattingEnabled = True
        Me.Cmb_InterviewHR.Items.AddRange(New Object() {"Kim Hernandez"})
        Me.Cmb_InterviewHR.Location = New System.Drawing.Point(195, 64)
        Me.Cmb_InterviewHR.Name = "Cmb_InterviewHR"
        Me.Cmb_InterviewHR.Size = New System.Drawing.Size(245, 28)
        Me.Cmb_InterviewHR.TabIndex = 86
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(75, 68)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 20)
        Me.Label18.TabIndex = 87
        Me.Label18.Text = "Interviewed by:"
        '
        'Lbl_App_Interview_ID
        '
        Me.Lbl_App_Interview_ID.AutoSize = True
        Me.Lbl_App_Interview_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_App_Interview_ID.ForeColor = System.Drawing.Color.Red
        Me.Lbl_App_Interview_ID.Location = New System.Drawing.Point(1178, 15)
        Me.Lbl_App_Interview_ID.Name = "Lbl_App_Interview_ID"
        Me.Lbl_App_Interview_ID.Size = New System.Drawing.Size(55, 24)
        Me.Lbl_App_Interview_ID.TabIndex = 92
        Me.Lbl_App_Interview_ID.Text = "XXX"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.Red
        Me.Label71.Location = New System.Drawing.Point(1027, 15)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(145, 24)
        Me.Label71.TabIndex = 91
        Me.Label71.Text = "Application ID:"
        '
        'Btn_Move_to_REQ
        '
        Me.Btn_Move_to_REQ.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Move_to_REQ.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Move_to_REQ.Location = New System.Drawing.Point(983, 588)
        Me.Btn_Move_to_REQ.Name = "Btn_Move_to_REQ"
        Me.Btn_Move_to_REQ.Size = New System.Drawing.Size(245, 40)
        Me.Btn_Move_to_REQ.TabIndex = 90
        Me.Btn_Move_to_REQ.Text = "Move to Next Process"
        Me.Btn_Move_to_REQ.UseVisualStyleBackColor = False
        '
        'Btn_Interview_SAVE
        '
        Me.Btn_Interview_SAVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Interview_SAVE.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_Interview_SAVE.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Interview_SAVE.Location = New System.Drawing.Point(814, 588)
        Me.Btn_Interview_SAVE.Name = "Btn_Interview_SAVE"
        Me.Btn_Interview_SAVE.Size = New System.Drawing.Size(163, 40)
        Me.Btn_Interview_SAVE.TabIndex = 89
        Me.Btn_Interview_SAVE.Text = "&Save"
        Me.Btn_Interview_SAVE.UseVisualStyleBackColor = False
        '
        'Tab_Processing
        '
        Me.Tab_Processing.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tab_Processing.Controls.Add(Me.Btn_Requirement_Cancel)
        Me.Tab_Processing.Controls.Add(Me.Prog_REQ)
        Me.Tab_Processing.Controls.Add(Me.Lbl_Req_App_ID)
        Me.Tab_Processing.Controls.Add(Me.Label75)
        Me.Tab_Processing.Controls.Add(Me.Btn_Req_MoveNext)
        Me.Tab_Processing.Controls.Add(Me.Btn_Req_Save)
        Me.Tab_Processing.Controls.Add(Me.LV_Requirement_List)
        Me.Tab_Processing.Controls.Add(Me.Label28)
        Me.Tab_Processing.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Processing.Name = "Tab_Processing"
        Me.Tab_Processing.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Processing.Size = New System.Drawing.Size(1250, 681)
        Me.Tab_Processing.TabIndex = 3
        Me.Tab_Processing.Text = "   Requirements   "
        '
        'Btn_Requirement_Cancel
        '
        Me.Btn_Requirement_Cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Requirement_Cancel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Requirement_Cancel.ForeColor = System.Drawing.Color.Red
        Me.Btn_Requirement_Cancel.Location = New System.Drawing.Point(17, 592)
        Me.Btn_Requirement_Cancel.Name = "Btn_Requirement_Cancel"
        Me.Btn_Requirement_Cancel.Size = New System.Drawing.Size(220, 40)
        Me.Btn_Requirement_Cancel.TabIndex = 123
        Me.Btn_Requirement_Cancel.Text = "Abort/Cancel Application"
        Me.Btn_Requirement_Cancel.UseVisualStyleBackColor = False
        '
        'Prog_REQ
        '
        Me.Prog_REQ.Location = New System.Drawing.Point(17, 54)
        Me.Prog_REQ.Name = "Prog_REQ"
        Me.Prog_REQ.Size = New System.Drawing.Size(655, 23)
        Me.Prog_REQ.TabIndex = 108
        '
        'Lbl_Req_App_ID
        '
        Me.Lbl_Req_App_ID.AutoSize = True
        Me.Lbl_Req_App_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Req_App_ID.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Req_App_ID.Location = New System.Drawing.Point(1169, 19)
        Me.Lbl_Req_App_ID.Name = "Lbl_Req_App_ID"
        Me.Lbl_Req_App_ID.Size = New System.Drawing.Size(55, 24)
        Me.Lbl_Req_App_ID.TabIndex = 107
        Me.Lbl_Req_App_ID.Text = "XXX"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Red
        Me.Label75.Location = New System.Drawing.Point(1018, 19)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(145, 24)
        Me.Label75.TabIndex = 106
        Me.Label75.Text = "Application ID:"
        '
        'Btn_Req_MoveNext
        '
        Me.Btn_Req_MoveNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Req_MoveNext.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_Req_MoveNext.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Req_MoveNext.Location = New System.Drawing.Point(994, 592)
        Me.Btn_Req_MoveNext.Name = "Btn_Req_MoveNext"
        Me.Btn_Req_MoveNext.Size = New System.Drawing.Size(220, 40)
        Me.Btn_Req_MoveNext.TabIndex = 92
        Me.Btn_Req_MoveNext.Text = "Move to Next Process"
        Me.Btn_Req_MoveNext.UseVisualStyleBackColor = False
        '
        'Btn_Req_Save
        '
        Me.Btn_Req_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Req_Save.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_Req_Save.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Req_Save.Location = New System.Drawing.Point(832, 592)
        Me.Btn_Req_Save.Name = "Btn_Req_Save"
        Me.Btn_Req_Save.Size = New System.Drawing.Size(156, 40)
        Me.Btn_Req_Save.TabIndex = 91
        Me.Btn_Req_Save.Text = "&Save"
        Me.Btn_Req_Save.UseVisualStyleBackColor = False
        '
        'LV_Requirement_List
        '
        Me.LV_Requirement_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Requirement_List.CheckBoxes = True
        Me.LV_Requirement_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_Req_ID, Me.Col_REQ_DESC})
        Me.LV_Requirement_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Requirement_List.FullRowSelect = True
        Me.LV_Requirement_List.GridLines = True
        Me.LV_Requirement_List.HideSelection = False
        Me.LV_Requirement_List.Location = New System.Drawing.Point(17, 88)
        Me.LV_Requirement_List.Name = "LV_Requirement_List"
        Me.LV_Requirement_List.Size = New System.Drawing.Size(655, 473)
        Me.LV_Requirement_List.TabIndex = 48
        Me.LV_Requirement_List.UseCompatibleStateImageBehavior = False
        Me.LV_Requirement_List.View = System.Windows.Forms.View.Details
        '
        'Col_Req_ID
        '
        Me.Col_Req_ID.Text = "REQ ID"
        Me.Col_Req_ID.Width = 100
        '
        'Col_REQ_DESC
        '
        Me.Col_REQ_DESC.Text = "REQUIREMENT DESCRIPTION"
        Me.Col_REQ_DESC.Width = 550
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(13, 14)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(277, 24)
        Me.Label28.TabIndex = 47
        Me.Label28.Text = "Submission of Requirements"
        '
        'Tab_Completion
        '
        Me.Tab_Completion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tab_Completion.Controls.Add(Me.Grp_Complete_GovNum)
        Me.Tab_Completion.Controls.Add(Me.Label26)
        Me.Tab_Completion.Controls.Add(Me.Grp_Complete_JobInfo)
        Me.Tab_Completion.Controls.Add(Me.Lbl_Complete_App_ID)
        Me.Tab_Completion.Controls.Add(Me.Label81)
        Me.Tab_Completion.Controls.Add(Me.Btn_Complete)
        Me.Tab_Completion.Controls.Add(Me.Btn_SemiComplete_Save)
        Me.Tab_Completion.Location = New System.Drawing.Point(4, 29)
        Me.Tab_Completion.Name = "Tab_Completion"
        Me.Tab_Completion.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Completion.Size = New System.Drawing.Size(1250, 681)
        Me.Tab_Completion.TabIndex = 6
        Me.Tab_Completion.Text = "   Completed   "
        '
        'Grp_Complete_GovNum
        '
        Me.Grp_Complete_GovNum.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grp_Complete_GovNum.Controls.Add(Me.Txt_National_ID)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Label9)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Chk_GovIDs_NotAvailable)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Txt_TIN)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Label7)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Txt_PhilHealth)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Label31)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Txt_Pagibig)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Label29)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Txt_SSS)
        Me.Grp_Complete_GovNum.Controls.Add(Me.Label27)
        Me.Grp_Complete_GovNum.Enabled = False
        Me.Grp_Complete_GovNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Grp_Complete_GovNum.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Complete_GovNum.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Complete_GovNum.Location = New System.Drawing.Point(35, 57)
        Me.Grp_Complete_GovNum.Name = "Grp_Complete_GovNum"
        Me.Grp_Complete_GovNum.Size = New System.Drawing.Size(1189, 142)
        Me.Grp_Complete_GovNum.TabIndex = 145
        Me.Grp_Complete_GovNum.TabStop = False
        Me.Grp_Complete_GovNum.Text = "Government Identification Numbers"
        '
        'Txt_National_ID
        '
        Me.Txt_National_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_National_ID.Location = New System.Drawing.Point(808, 39)
        Me.Txt_National_ID.Name = "Txt_National_ID"
        Me.Txt_National_ID.Size = New System.Drawing.Size(192, 26)
        Me.Txt_National_ID.TabIndex = 146
        Me.Txt_National_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(710, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 20)
        Me.Label9.TabIndex = 151
        Me.Label9.Text = "National ID:"
        '
        'Chk_GovIDs_NotAvailable
        '
        Me.Chk_GovIDs_NotAvailable.AutoSize = True
        Me.Chk_GovIDs_NotAvailable.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_GovIDs_NotAvailable.Location = New System.Drawing.Point(544, 0)
        Me.Chk_GovIDs_NotAvailable.Name = "Chk_GovIDs_NotAvailable"
        Me.Chk_GovIDs_NotAvailable.Size = New System.Drawing.Size(145, 23)
        Me.Chk_GovIDs_NotAvailable.TabIndex = 146
        Me.Chk_GovIDs_NotAvailable.Text = "Not yet available"
        Me.Chk_GovIDs_NotAvailable.UseVisualStyleBackColor = True
        '
        'Txt_TIN
        '
        Me.Txt_TIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TIN.Location = New System.Drawing.Point(470, 73)
        Me.Txt_TIN.Name = "Txt_TIN"
        Me.Txt_TIN.Size = New System.Drawing.Size(192, 26)
        Me.Txt_TIN.TabIndex = 148
        Me.Txt_TIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(383, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "TIN No.:"
        '
        'Txt_PhilHealth
        '
        Me.Txt_PhilHealth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PhilHealth.Location = New System.Drawing.Point(470, 39)
        Me.Txt_PhilHealth.Name = "Txt_PhilHealth"
        Me.Txt_PhilHealth.Size = New System.Drawing.Size(192, 26)
        Me.Txt_PhilHealth.TabIndex = 145
        Me.Txt_PhilHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(383, 42)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(78, 20)
        Me.Label31.TabIndex = 147
        Me.Label31.Text = "PhilH No.:"
        '
        'Txt_Pagibig
        '
        Me.Txt_Pagibig.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Pagibig.Location = New System.Drawing.Point(155, 73)
        Me.Txt_Pagibig.Name = "Txt_Pagibig"
        Me.Txt_Pagibig.Size = New System.Drawing.Size(192, 26)
        Me.Txt_Pagibig.TabIndex = 147
        Me.Txt_Pagibig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(20, 79)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(100, 20)
        Me.Label29.TabIndex = 145
        Me.Label29.Text = "Pag-Ibig No.:"
        '
        'Txt_SSS
        '
        Me.Txt_SSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SSS.Location = New System.Drawing.Point(155, 37)
        Me.Txt_SSS.Name = "Txt_SSS"
        Me.Txt_SSS.Size = New System.Drawing.Size(192, 26)
        Me.Txt_SSS.TabIndex = 144
        Me.Txt_SSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(20, 40)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(106, 20)
        Me.Label27.TabIndex = 143
        Me.Label27.Text = "SSS Number:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(12, 599)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(824, 20)
        Me.Label26.TabIndex = 131
        Me.Label26.Text = "Note: Records of the applicant will be automaticaly added to the Employee Master " &
    "List after application completeion "
        '
        'Grp_Complete_JobInfo
        '
        Me.Grp_Complete_JobInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Btn_Manual_ID)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Txt_Client_Start_Date)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.DP_Client_Start_Date)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Lbl_Client_Start_Date)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Lbl_Current_CLient_ID)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Lbl_ClientName)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Txt_ClientID)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Btn_GenerateID)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Btn_ShowClientList)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Label5)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Txt_Employee_ID)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Label25)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.TxtDate_Hired)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.DP_Date_Hired)
        Me.Grp_Complete_JobInfo.Controls.Add(Me.Label30)
        Me.Grp_Complete_JobInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Grp_Complete_JobInfo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Complete_JobInfo.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Complete_JobInfo.Location = New System.Drawing.Point(35, 218)
        Me.Grp_Complete_JobInfo.Name = "Grp_Complete_JobInfo"
        Me.Grp_Complete_JobInfo.Size = New System.Drawing.Size(1189, 182)
        Me.Grp_Complete_JobInfo.TabIndex = 122
        Me.Grp_Complete_JobInfo.TabStop = False
        Me.Grp_Complete_JobInfo.Text = "Job Information"
        '
        'Btn_Manual_ID
        '
        Me.Btn_Manual_ID.BackColor = System.Drawing.Color.Yellow
        Me.Btn_Manual_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Manual_ID.Location = New System.Drawing.Point(154, 155)
        Me.Btn_Manual_ID.Name = "Btn_Manual_ID"
        Me.Btn_Manual_ID.Size = New System.Drawing.Size(163, 27)
        Me.Btn_Manual_ID.TabIndex = 135
        Me.Btn_Manual_ID.Text = "Enable Manual ID"
        Me.Btn_Manual_ID.UseVisualStyleBackColor = False
        '
        'Txt_Client_Start_Date
        '
        Me.Txt_Client_Start_Date.Enabled = False
        Me.Txt_Client_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Client_Start_Date.Location = New System.Drawing.Point(709, 125)
        Me.Txt_Client_Start_Date.Name = "Txt_Client_Start_Date"
        Me.Txt_Client_Start_Date.Size = New System.Drawing.Size(152, 26)
        Me.Txt_Client_Start_Date.TabIndex = 134
        Me.Txt_Client_Start_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Client_Start_Date.Visible = False
        '
        'DP_Client_Start_Date
        '
        Me.DP_Client_Start_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Client_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Client_Start_Date.Location = New System.Drawing.Point(864, 125)
        Me.DP_Client_Start_Date.Name = "DP_Client_Start_Date"
        Me.DP_Client_Start_Date.Size = New System.Drawing.Size(17, 26)
        Me.DP_Client_Start_Date.TabIndex = 152
        Me.DP_Client_Start_Date.Visible = False
        '
        'Lbl_Client_Start_Date
        '
        Me.Lbl_Client_Start_Date.AutoSize = True
        Me.Lbl_Client_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Client_Start_Date.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Client_Start_Date.Location = New System.Drawing.Point(602, 128)
        Me.Lbl_Client_Start_Date.Name = "Lbl_Client_Start_Date"
        Me.Lbl_Client_Start_Date.Size = New System.Drawing.Size(87, 20)
        Me.Lbl_Client_Start_Date.TabIndex = 133
        Me.Lbl_Client_Start_Date.Text = "Start Date:"
        Me.Lbl_Client_Start_Date.Visible = False
        '
        'Lbl_Current_CLient_ID
        '
        Me.Lbl_Current_CLient_ID.AutoSize = True
        Me.Lbl_Current_CLient_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Current_CLient_ID.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Current_CLient_ID.Location = New System.Drawing.Point(705, 29)
        Me.Lbl_Current_CLient_ID.Name = "Lbl_Current_CLient_ID"
        Me.Lbl_Current_CLient_ID.Size = New System.Drawing.Size(127, 20)
        Me.Lbl_Current_CLient_ID.TabIndex = 131
        Me.Lbl_Current_CLient_ID.Text = "Current Client ID"
        Me.Lbl_Current_CLient_ID.Visible = False
        '
        'Lbl_ClientName
        '
        Me.Lbl_ClientName.AutoSize = True
        Me.Lbl_ClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ClientName.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_ClientName.Location = New System.Drawing.Point(714, 92)
        Me.Lbl_ClientName.Name = "Lbl_ClientName"
        Me.Lbl_ClientName.Size = New System.Drawing.Size(95, 20)
        Me.Lbl_ClientName.TabIndex = 130
        Me.Lbl_ClientName.Text = "Client Name"
        '
        'Txt_ClientID
        '
        Me.Txt_ClientID.Enabled = False
        Me.Txt_ClientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClientID.Location = New System.Drawing.Point(709, 63)
        Me.Txt_ClientID.Name = "Txt_ClientID"
        Me.Txt_ClientID.Size = New System.Drawing.Size(82, 26)
        Me.Txt_ClientID.TabIndex = 125
        Me.Txt_ClientID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_GenerateID
        '
        Me.Btn_GenerateID.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_GenerateID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_GenerateID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_GenerateID.Location = New System.Drawing.Point(323, 122)
        Me.Btn_GenerateID.Name = "Btn_GenerateID"
        Me.Btn_GenerateID.Size = New System.Drawing.Size(163, 27)
        Me.Btn_GenerateID.TabIndex = 150
        Me.Btn_GenerateID.Text = "Auto Generate ID"
        Me.Btn_GenerateID.UseVisualStyleBackColor = False
        '
        'Btn_ShowClientList
        '
        Me.Btn_ShowClientList.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_ShowClientList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_ShowClientList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ShowClientList.Location = New System.Drawing.Point(797, 62)
        Me.Btn_ShowClientList.Name = "Btn_ShowClientList"
        Me.Btn_ShowClientList.Size = New System.Drawing.Size(145, 27)
        Me.Btn_ShowClientList.TabIndex = 151
        Me.Btn_ShowClientList.Text = "Select Client"
        Me.Btn_ShowClientList.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(602, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 20)
        Me.Label5.TabIndex = 129
        Me.Label5.Text = "Client ID:"
        '
        'Txt_Employee_ID
        '
        Me.Txt_Employee_ID.Enabled = False
        Me.Txt_Employee_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Employee_ID.Location = New System.Drawing.Point(155, 122)
        Me.Txt_Employee_ID.Name = "Txt_Employee_ID"
        Me.Txt_Employee_ID.Size = New System.Drawing.Size(162, 26)
        Me.Txt_Employee_ID.TabIndex = 121
        Me.Txt_Employee_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(21, 122)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 20)
        Me.Label25.TabIndex = 120
        Me.Label25.Text = "Employee ID:"
        '
        'TxtDate_Hired
        '
        Me.TxtDate_Hired.Enabled = False
        Me.TxtDate_Hired.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDate_Hired.Location = New System.Drawing.Point(156, 67)
        Me.TxtDate_Hired.Name = "TxtDate_Hired"
        Me.TxtDate_Hired.Size = New System.Drawing.Size(191, 26)
        Me.TxtDate_Hired.TabIndex = 119
        Me.TxtDate_Hired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Date_Hired
        '
        Me.DP_Date_Hired.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Date_Hired.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Date_Hired.Location = New System.Drawing.Point(350, 67)
        Me.DP_Date_Hired.Name = "DP_Date_Hired"
        Me.DP_Date_Hired.Size = New System.Drawing.Size(17, 26)
        Me.DP_Date_Hired.TabIndex = 149
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(21, 70)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(90, 20)
        Me.Label30.TabIndex = 118
        Me.Label30.Text = "Date Hired:"
        '
        'Lbl_Complete_App_ID
        '
        Me.Lbl_Complete_App_ID.AutoSize = True
        Me.Lbl_Complete_App_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Complete_App_ID.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Complete_App_ID.Location = New System.Drawing.Point(1169, 13)
        Me.Lbl_Complete_App_ID.Name = "Lbl_Complete_App_ID"
        Me.Lbl_Complete_App_ID.Size = New System.Drawing.Size(55, 24)
        Me.Lbl_Complete_App_ID.TabIndex = 105
        Me.Lbl_Complete_App_ID.Text = "XXX"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Red
        Me.Label81.Location = New System.Drawing.Point(1018, 13)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(145, 24)
        Me.Label81.TabIndex = 104
        Me.Label81.Text = "Application ID:"
        '
        'Btn_Complete
        '
        Me.Btn_Complete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_Complete.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Complete.ForeColor = System.Drawing.Color.White
        Me.Btn_Complete.Location = New System.Drawing.Point(1004, 589)
        Me.Btn_Complete.Name = "Btn_Complete"
        Me.Btn_Complete.Size = New System.Drawing.Size(220, 40)
        Me.Btn_Complete.TabIndex = 103
        Me.Btn_Complete.Text = "Complete"
        Me.Btn_Complete.UseVisualStyleBackColor = False
        '
        'Btn_SemiComplete_Save
        '
        Me.Btn_SemiComplete_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_SemiComplete_Save.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_SemiComplete_Save.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_SemiComplete_Save.Location = New System.Drawing.Point(842, 589)
        Me.Btn_SemiComplete_Save.Name = "Btn_SemiComplete_Save"
        Me.Btn_SemiComplete_Save.Size = New System.Drawing.Size(156, 40)
        Me.Btn_SemiComplete_Save.TabIndex = 102
        Me.Btn_SemiComplete_Save.Text = "Save"
        Me.Btn_SemiComplete_Save.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(173, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Application"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(26, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Progress:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(401, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "For Interview"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(660, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "For Requirements"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(947, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 19)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "For Completion"
        '
        'Bar_AppProgress
        '
        Me.Bar_AppProgress.Location = New System.Drawing.Point(34, 86)
        Me.Bar_AppProgress.Name = "Bar_AppProgress"
        Me.Bar_AppProgress.Size = New System.Drawing.Size(1258, 23)
        Me.Bar_AppProgress.TabIndex = 11
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(1237, 55)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 19)
        Me.Label33.TabIndex = 13
        Me.Label33.Text = "Hired"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Location = New System.Drawing.Point(-8, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1353, 33)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox2.Location = New System.Drawing.Point(34, 852)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1262, 70)
        Me.PictureBox2.TabIndex = 121
        Me.PictureBox2.TabStop = False
        '
        'FRM_HRIS_APPLICATION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1352, 942)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Bar_AppProgress)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tab_Recruitment)
        Me.Name = "FRM_HRIS_APPLICATION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HR Application Process "
        Me.Tab_Recruitment.ResumeLayout(False)
        Me.Tab_AppList.ResumeLayout(False)
        Me.Tab_AppList.PerformLayout()
        Me.Tab_Application.ResumeLayout(False)
        Me.Tab_Application.PerformLayout()
        Me.Grp_Application_Position.ResumeLayout(False)
        Me.Grp_Application_Position.PerformLayout()
        Me.Grp_Contact_Info.ResumeLayout(False)
        Me.Grp_Contact_Info.PerformLayout()
        Me.Grp_Application_Educ.ResumeLayout(False)
        Me.Grp_Application_Educ.PerformLayout()
        Me.Grp_Application_BasicInfo.ResumeLayout(False)
        Me.Grp_Application_BasicInfo.PerformLayout()
        Me.Tab_Interview.ResumeLayout(False)
        Me.Tab_Interview.PerformLayout()
        Me.Grp_Interview.ResumeLayout(False)
        Me.Grp_Interview.PerformLayout()
        Me.Tab_Processing.ResumeLayout(False)
        Me.Tab_Processing.PerformLayout()
        Me.Tab_Completion.ResumeLayout(False)
        Me.Tab_Completion.PerformLayout()
        Me.Grp_Complete_GovNum.ResumeLayout(False)
        Me.Grp_Complete_GovNum.PerformLayout()
        Me.Grp_Complete_JobInfo.ResumeLayout(False)
        Me.Grp_Complete_JobInfo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tab_Recruitment As TabControl
    Friend WithEvents Tab_Application As TabPage
    Friend WithEvents Tab_Interview As TabPage
    Friend WithEvents Tab_Processing As TabPage
    Friend WithEvents Tab_Completion As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents LV_Requirement_List As ListView
    Friend WithEvents Lbl_App_ID As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Tab_AppList As TabPage
    Friend WithEvents LV_Applicant_List As ListView
    Friend WithEvents Col_AppID As ColumnHeader
    Friend WithEvents Col_AppName As ColumnHeader
    Friend WithEvents Col_AppStatus As ColumnHeader
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Cmb_Category As ComboBox
    Friend WithEvents Label63 As Label
    Friend WithEvents Col_DateApp As ColumnHeader
    Friend WithEvents BtnSave As Button
    Friend WithEvents Btn_Move_to_REQ As Button
    Friend WithEvents Btn_Interview_SAVE As Button
    Friend WithEvents Btn_Req_MoveNext As Button
    Friend WithEvents Btn_Req_Save As Button
    Friend WithEvents Btn_Complete As Button
    Friend WithEvents Btn_SemiComplete_Save As Button
    Friend WithEvents Lbl_App_Interview_ID As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents Lbl_Req_App_ID As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents Lbl_Complete_App_ID As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents Bar_AppProgress As ProgressBar
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Grp_Application_Educ As GroupBox
    Friend WithEvents Txt_Pos_Held As TextBox
    Friend WithEvents Label94 As Label
    Friend WithEvents Txt_Refer_Rem As TextBox
    Friend WithEvents Cmb_Refer As ComboBox
    Friend WithEvents Label90 As Label
    Friend WithEvents Txt_PrevComp_Add As TextBox
    Friend WithEvents Label89 As Label
    Friend WithEvents Label88 As Label
    Friend WithEvents Txt_Course As TextBox
    Friend WithEvents Label87 As Label
    Friend WithEvents Txt_PrevComp As TextBox
    Friend WithEvents Label86 As Label
    Friend WithEvents Cmb_Educ_Attainment As ComboBox
    Friend WithEvents Label84 As Label
    Friend WithEvents Grp_Application_BasicInfo As GroupBox
    Friend WithEvents Label93 As Label
    Friend WithEvents Cmb_Religion As ComboBox
    Friend WithEvents Label91 As Label
    Friend WithEvents Txt_Weight As TextBox
    Friend WithEvents Label83 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Cmb_Height As ComboBox
    Friend WithEvents Label51 As Label
    Friend WithEvents Txt_Email As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Txt_ContactNo As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Txt_ResiAdd As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Txt_Birthday As TextBox
    Friend WithEvents DP_Bday As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents Cmb_Gender As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Txt_LastName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt_MiddleName As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Txt_FirstName As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Prog_REQ As ProgressBar
    Friend WithEvents Grp_Interview As GroupBox
    Friend WithEvents TxtInterview_HR_Remarks As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents Cmb_Int_OPR_Result As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Cmb_Int_HR_Result As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Txt_Interview_OP_Date As TextBox
    Friend WithEvents DT_Interview2_Date As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Cmb_InterviewOP As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TxtInterviewHR_Date As TextBox
    Friend WithEvents DT_Interview1_Date As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Cmb_InterviewHR As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Grp_Complete_JobInfo As GroupBox
    Friend WithEvents Lbl_ClientName As Label
    Friend WithEvents Txt_ClientID As TextBox
    Friend WithEvents Btn_GenerateID As Button
    Friend WithEvents Btn_ShowClientList As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_Employee_ID As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TxtDate_Hired As TextBox
    Friend WithEvents DP_Date_Hired As DateTimePicker
    Friend WithEvents Label30 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Cmb_Grad_Year As ComboBox
    Friend WithEvents Btn_Interview_Cancel As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Col_Req_ID As ColumnHeader
    Friend WithEvents Col_REQ_DESC As ColumnHeader
    Friend WithEvents Grp_Complete_GovNum As GroupBox
    Friend WithEvents Txt_PhilHealth As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Txt_Pagibig As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Txt_SSS As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Txt_TIN As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Btn_Requirement_Cancel As Button
    Friend WithEvents Label34 As Label
    Friend WithEvents Cmb_Civil_Status As ComboBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Lbl_Current_CLient_ID As Label
    Friend WithEvents Txt_Client_Start_Date As TextBox
    Friend WithEvents DP_Client_Start_Date As DateTimePicker
    Friend WithEvents Lbl_Client_Start_Date As Label
    Friend WithEvents TxtInterview_Dir_Remarks As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TxtInterview_Op_Remarks As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Cmb_Int_DIR_Result As ComboBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Txt_Interview_Dir_Date As TextBox
    Friend WithEvents DT_Interview3_Date As DateTimePicker
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Cmb_InterviewDIR As ComboBox
    Friend WithEvents Label39 As Label
    Friend WithEvents Chk_GovIDs_NotAvailable As CheckBox
    Friend WithEvents Grp_Contact_Info As GroupBox
    Friend WithEvents Txt_Contact_Address As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Txt_Contact_Number As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents Cmb_Relationship As ComboBox
    Friend WithEvents Label52 As Label
    Friend WithEvents Txt_Contact_Name As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Cmb_BloodType As ComboBox
    Friend WithEvents Label46 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Txt_Maiden As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Txt_National_ID As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Btn_Manual_ID As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Btn_NewApplication As IconButton
    Friend WithEvents Btn_Abort_Application As IconButton
    Friend WithEvents Btn_CancelApplication As IconButton
    Friend WithEvents Btn_EditApplication As IconButton
    Friend WithEvents Btn_SearchApplicant As IconButton
    Friend WithEvents Btn_Refresh As IconButton
    Friend WithEvents Btn_Move_to_Interview As Button
    Friend WithEvents Grp_Application_Position As GroupBox
    Friend WithEvents Opt_Non_SecurityPersonnel As RadioButton
    Friend WithEvents Opt_SecurityPersonnel As RadioButton
    Friend WithEvents Cmb_Position As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Cmb_Department As ComboBox
    Friend WithEvents Label6 As Label
End Class
