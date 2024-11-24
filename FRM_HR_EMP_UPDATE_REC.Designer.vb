<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_EMP_UPDATE_REC
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
        Me.Tab_Employee_Transactions = New System.Windows.Forms.TabControl()
        Me.Tab_Leave_Filing = New System.Windows.Forms.TabPage()
        Me.Grp_Leave_Info = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Leave_Reason = New System.Windows.Forms.TextBox()
        Me.Cmb_Notification = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_LeaveType = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_Leave_Status = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DP_Leave_To = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Leave_DateTo = New System.Windows.Forms.TextBox()
        Me.DP_Leave_From = New System.Windows.Forms.DateTimePicker()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Txt_Leave_DateFrom = New System.Windows.Forms.TextBox()
        Me.Btn_Leave_Delete = New System.Windows.Forms.Button()
        Me.Btn_Leave_Edit = New System.Windows.Forms.Button()
        Me.Btn_Leave_New = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.LV_Leave = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Leave_Type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Reference_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Lbl_Medical_Ref_ID = New System.Windows.Forms.Label()
        Me.Btn_Medical_Delete = New System.Windows.Forms.Button()
        Me.Btn_Medical_Edit = New System.Windows.Forms.Button()
        Me.Btn_Medical_New = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.LV_Medical_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Med_Type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Medical_Ref_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Grp_Medical_Info = New System.Windows.Forms.GroupBox()
        Me.Txt_Medical_Exp_Date = New System.Windows.Forms.TextBox()
        Me.DP_Medical_Exp_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Cmb_Hospital = New System.Windows.Forms.ComboBox()
        Me.Txt_Medical_Date = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DP_Medical_Date = New System.Windows.Forms.DateTimePicker()
        Me.Cmb_Drug_Test = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_Medical_Type = New System.Windows.Forms.ComboBox()
        Me.Txt_Medical_Remarks = New System.Windows.Forms.TextBox()
        Me.Chk_Medical_Findings = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Btn_Insurance_Delete = New System.Windows.Forms.Button()
        Me.Btn_Insurance_Edit = New System.Windows.Forms.Button()
        Me.Btn_Insurance_New = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.LV_Insurance_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Insu_Company = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_PolicyNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Insurance_RefID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Grp_Insurance_Info = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Cmb_Insurance_CompName = New System.Windows.Forms.ComboBox()
        Me.Txt_Insurance_Policy = New System.Windows.Forms.TextBox()
        Me.DP_Insurance_DateEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_Insurance_DateEnd = New System.Windows.Forms.TextBox()
        Me.Txt_Insurance_DateStart = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DP_Insurance_DateStart = New System.Windows.Forms.DateTimePicker()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Lbl_License_View_Attachment = New System.Windows.Forms.Label()
        Me.Grp_License = New System.Windows.Forms.GroupBox()
        Me.Btn_License_AttachFile = New System.Windows.Forms.Button()
        Me.Txt_License_Attachment = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cmb_LicenseType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txt_License_Number = New System.Windows.Forms.TextBox()
        Me.DP_License_Expiry = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt_License_Expiry = New System.Windows.Forms.TextBox()
        Me.Btn_License_Delete = New System.Windows.Forms.Button()
        Me.Btn_License_Edit = New System.Windows.Forms.Button()
        Me.Btn_License_NEW = New System.Windows.Forms.Button()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.LV_License_Record = New System.Windows.Forms.ListView()
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_License_Number = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Exp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_SEC_Ref_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tab_Client = New System.Windows.Forms.TabPage()
        Me.Btn_Client_Add = New System.Windows.Forms.Button()
        Me.Btn_Client_Edit = New System.Windows.Forms.Button()
        Me.Grp_Client_Info = New System.Windows.Forms.GroupBox()
        Me.Chk_UptoPresent = New System.Windows.Forms.CheckBox()
        Me.Txt_Client_End_Date = New System.Windows.Forms.TextBox()
        Me.DP_Client_End_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Lbl_Client_Ref_ID = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Txt_selected_Client_ID = New System.Windows.Forms.TextBox()
        Me.Txt_Client_Start_Date = New System.Windows.Forms.TextBox()
        Me.DP_Client_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Lbl_Client_Start_Date = New System.Windows.Forms.Label()
        Me.LblClient_Address = New System.Windows.Forms.Label()
        Me.Btn_ShowClientList = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Txt_ClientID = New System.Windows.Forms.TextBox()
        Me.Lbl_ClientName = New System.Windows.Forms.Label()
        Me.Btn_Client_Delete = New System.Windows.Forms.Button()
        Me.Btn_Client_Change = New System.Windows.Forms.Button()
        Me.LV_Client_History = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_Address = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_StartDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_EndDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_Ref_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.LV_Status_History = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_DeclaredStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Btn_Separation_Update = New System.Windows.Forms.Button()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Txt_StatusChange_Date = New System.Windows.Forms.TextBox()
        Me.DP_Sepa_day = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Txt_ChangeStatus_Remark = New System.Windows.Forms.TextBox()
        Me.Cmb_Separation = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Lbl_Employee_ID = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Lbl_Employee_Name = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Btn_Selected_Button = New FontAwesome.Sharp.IconButton()
        Me.Btn_Employment_Status = New FontAwesome.Sharp.IconButton()
        Me.Btn_Personel_Movement = New FontAwesome.Sharp.IconButton()
        Me.Btn_Security_License = New FontAwesome.Sharp.IconButton()
        Me.Btn_Insurance = New FontAwesome.Sharp.IconButton()
        Me.Btn_Medical_Records = New FontAwesome.Sharp.IconButton()
        Me.Btn_Leave_Filing = New FontAwesome.Sharp.IconButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Pic_Employee_Photo = New System.Windows.Forms.PictureBox()
        Me.Tab_Employee_Transactions.SuspendLayout()
        Me.Tab_Leave_Filing.SuspendLayout()
        Me.Grp_Leave_Info.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_Medical_Info.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_Insurance_Info.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Grp_License.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Client.SuspendLayout()
        Me.Grp_Client_Info.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Pic_Employee_Photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tab_Employee_Transactions
        '
        Me.Tab_Employee_Transactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab_Employee_Transactions.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.Tab_Employee_Transactions.Controls.Add(Me.Tab_Leave_Filing)
        Me.Tab_Employee_Transactions.Controls.Add(Me.TabPage2)
        Me.Tab_Employee_Transactions.Controls.Add(Me.TabPage3)
        Me.Tab_Employee_Transactions.Controls.Add(Me.TabPage4)
        Me.Tab_Employee_Transactions.Controls.Add(Me.Tab_Client)
        Me.Tab_Employee_Transactions.Controls.Add(Me.TabPage6)
        Me.Tab_Employee_Transactions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_Employee_Transactions.Location = New System.Drawing.Point(248, 146)
        Me.Tab_Employee_Transactions.Name = "Tab_Employee_Transactions"
        Me.Tab_Employee_Transactions.SelectedIndex = 0
        Me.Tab_Employee_Transactions.Size = New System.Drawing.Size(801, 683)
        Me.Tab_Employee_Transactions.TabIndex = 69
        '
        'Tab_Leave_Filing
        '
        Me.Tab_Leave_Filing.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Tab_Leave_Filing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Tab_Leave_Filing.Controls.Add(Me.Grp_Leave_Info)
        Me.Tab_Leave_Filing.Controls.Add(Me.Btn_Leave_Delete)
        Me.Tab_Leave_Filing.Controls.Add(Me.Btn_Leave_Edit)
        Me.Tab_Leave_Filing.Controls.Add(Me.Btn_Leave_New)
        Me.Tab_Leave_Filing.Controls.Add(Me.PictureBox3)
        Me.Tab_Leave_Filing.Controls.Add(Me.LV_Leave)
        Me.Tab_Leave_Filing.ForeColor = System.Drawing.Color.Black
        Me.Tab_Leave_Filing.Location = New System.Drawing.Point(4, 32)
        Me.Tab_Leave_Filing.Name = "Tab_Leave_Filing"
        Me.Tab_Leave_Filing.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Leave_Filing.Size = New System.Drawing.Size(793, 647)
        Me.Tab_Leave_Filing.TabIndex = 0
        Me.Tab_Leave_Filing.Text = "  Leave Filing  "
        '
        'Grp_Leave_Info
        '
        Me.Grp_Leave_Info.Controls.Add(Me.Label8)
        Me.Grp_Leave_Info.Controls.Add(Me.Txt_Leave_Reason)
        Me.Grp_Leave_Info.Controls.Add(Me.Cmb_Notification)
        Me.Grp_Leave_Info.Controls.Add(Me.Label7)
        Me.Grp_Leave_Info.Controls.Add(Me.Cmb_LeaveType)
        Me.Grp_Leave_Info.Controls.Add(Me.Label6)
        Me.Grp_Leave_Info.Controls.Add(Me.Cmb_Leave_Status)
        Me.Grp_Leave_Info.Controls.Add(Me.Label5)
        Me.Grp_Leave_Info.Controls.Add(Me.Label4)
        Me.Grp_Leave_Info.Controls.Add(Me.DP_Leave_To)
        Me.Grp_Leave_Info.Controls.Add(Me.Label2)
        Me.Grp_Leave_Info.Controls.Add(Me.Txt_Leave_DateTo)
        Me.Grp_Leave_Info.Controls.Add(Me.DP_Leave_From)
        Me.Grp_Leave_Info.Controls.Add(Me.Label93)
        Me.Grp_Leave_Info.Controls.Add(Me.Txt_Leave_DateFrom)
        Me.Grp_Leave_Info.Enabled = False
        Me.Grp_Leave_Info.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Leave_Info.Location = New System.Drawing.Point(51, 292)
        Me.Grp_Leave_Info.Name = "Grp_Leave_Info"
        Me.Grp_Leave_Info.Size = New System.Drawing.Size(675, 245)
        Me.Grp_Leave_Info.TabIndex = 229
        Me.Grp_Leave_Info.TabStop = False
        Me.Grp_Leave_Info.Text = "Leave Information"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(32, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 20)
        Me.Label8.TabIndex = 243
        Me.Label8.Text = "Reason:"
        '
        'Txt_Leave_Reason
        '
        Me.Txt_Leave_Reason.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Leave_Reason.Location = New System.Drawing.Point(107, 200)
        Me.Txt_Leave_Reason.Name = "Txt_Leave_Reason"
        Me.Txt_Leave_Reason.Size = New System.Drawing.Size(536, 26)
        Me.Txt_Leave_Reason.TabIndex = 242
        '
        'Cmb_Notification
        '
        Me.Cmb_Notification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Notification.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Notification.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Notification.FormattingEnabled = True
        Me.Cmb_Notification.Items.AddRange(New Object() {"Through SMS", "Through Call", "Personal", "Email", "NA"})
        Me.Cmb_Notification.Location = New System.Drawing.Point(458, 34)
        Me.Cmb_Notification.Name = "Cmb_Notification"
        Me.Cmb_Notification.Size = New System.Drawing.Size(185, 28)
        Me.Cmb_Notification.TabIndex = 240
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(307, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 20)
        Me.Label7.TabIndex = 241
        Me.Label7.Text = "Way of Notification:"
        '
        'Cmb_LeaveType
        '
        Me.Cmb_LeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_LeaveType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_LeaveType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_LeaveType.FormattingEnabled = True
        Me.Cmb_LeaveType.Items.AddRange(New Object() {"Vacation Leave", "Emergency Leave", "Sick Leave", "Maternity Leave", "Paternity Leave"})
        Me.Cmb_LeaveType.Location = New System.Drawing.Point(90, 34)
        Me.Cmb_LeaveType.Name = "Cmb_LeaveType"
        Me.Cmb_LeaveType.Size = New System.Drawing.Size(185, 28)
        Me.Cmb_LeaveType.TabIndex = 238
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(29, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 20)
        Me.Label6.TabIndex = 239
        Me.Label6.Text = "Type:"
        '
        'Cmb_Leave_Status
        '
        Me.Cmb_Leave_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Leave_Status.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Leave_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Leave_Status.FormattingEnabled = True
        Me.Cmb_Leave_Status.Items.AddRange(New Object() {"Open", "Closed", "Cancelled"})
        Me.Cmb_Leave_Status.Location = New System.Drawing.Point(469, 113)
        Me.Cmb_Leave_Status.Name = "Cmb_Leave_Status"
        Me.Cmb_Leave_Status.Size = New System.Drawing.Size(127, 28)
        Me.Cmb_Leave_Status.TabIndex = 236
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(408, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 20)
        Me.Label5.TabIndex = 237
        Me.Label5.Text = "Status:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(30, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 18)
        Me.Label4.TabIndex = 235
        Me.Label4.Text = "Period of Coverage"
        '
        'DP_Leave_To
        '
        Me.DP_Leave_To.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Leave_To.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Leave_To.Location = New System.Drawing.Point(338, 150)
        Me.DP_Leave_To.Name = "DP_Leave_To"
        Me.DP_Leave_To.Size = New System.Drawing.Size(17, 26)
        Me.DP_Leave_To.TabIndex = 234
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(65, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 20)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Date To:"
        '
        'Txt_Leave_DateTo
        '
        Me.Txt_Leave_DateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Leave_DateTo.Location = New System.Drawing.Point(158, 150)
        Me.Txt_Leave_DateTo.Name = "Txt_Leave_DateTo"
        Me.Txt_Leave_DateTo.Size = New System.Drawing.Size(178, 26)
        Me.Txt_Leave_DateTo.TabIndex = 232
        Me.Txt_Leave_DateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Leave_From
        '
        Me.DP_Leave_From.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Leave_From.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Leave_From.Location = New System.Drawing.Point(338, 113)
        Me.DP_Leave_From.Name = "DP_Leave_From"
        Me.DP_Leave_From.Size = New System.Drawing.Size(17, 26)
        Me.DP_Leave_From.TabIndex = 231
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.Color.Black
        Me.Label93.Location = New System.Drawing.Point(65, 118)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(84, 20)
        Me.Label93.TabIndex = 230
        Me.Label93.Text = "Date from:"
        '
        'Txt_Leave_DateFrom
        '
        Me.Txt_Leave_DateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Leave_DateFrom.Location = New System.Drawing.Point(158, 113)
        Me.Txt_Leave_DateFrom.Name = "Txt_Leave_DateFrom"
        Me.Txt_Leave_DateFrom.Size = New System.Drawing.Size(178, 26)
        Me.Txt_Leave_DateFrom.TabIndex = 229
        Me.Txt_Leave_DateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_Leave_Delete
        '
        Me.Btn_Leave_Delete.Enabled = False
        Me.Btn_Leave_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Leave_Delete.ForeColor = System.Drawing.Color.Black
        Me.Btn_Leave_Delete.Location = New System.Drawing.Point(369, 566)
        Me.Btn_Leave_Delete.Name = "Btn_Leave_Delete"
        Me.Btn_Leave_Delete.Size = New System.Drawing.Size(134, 34)
        Me.Btn_Leave_Delete.TabIndex = 224
        Me.Btn_Leave_Delete.Text = "Delete"
        Me.Btn_Leave_Delete.UseVisualStyleBackColor = True
        '
        'Btn_Leave_Edit
        '
        Me.Btn_Leave_Edit.Enabled = False
        Me.Btn_Leave_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Leave_Edit.ForeColor = System.Drawing.Color.Black
        Me.Btn_Leave_Edit.Location = New System.Drawing.Point(220, 566)
        Me.Btn_Leave_Edit.Name = "Btn_Leave_Edit"
        Me.Btn_Leave_Edit.Size = New System.Drawing.Size(134, 34)
        Me.Btn_Leave_Edit.TabIndex = 223
        Me.Btn_Leave_Edit.Text = "Edit"
        Me.Btn_Leave_Edit.UseVisualStyleBackColor = True
        '
        'Btn_Leave_New
        '
        Me.Btn_Leave_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Leave_New.ForeColor = System.Drawing.Color.Black
        Me.Btn_Leave_New.Location = New System.Drawing.Point(71, 566)
        Me.Btn_Leave_New.Name = "Btn_Leave_New"
        Me.Btn_Leave_New.Size = New System.Drawing.Size(134, 34)
        Me.Btn_Leave_New.TabIndex = 221
        Me.Btn_Leave_New.Text = "New"
        Me.Btn_Leave_New.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Teal
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(20, 548)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(736, 69)
        Me.PictureBox3.TabIndex = 222
        Me.PictureBox3.TabStop = False
        '
        'LV_Leave
        '
        Me.LV_Leave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Leave.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Col_Leave_Type, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader6, Me.Col_Reference_ID})
        Me.LV_Leave.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Leave.FullRowSelect = True
        Me.LV_Leave.GridLines = True
        Me.LV_Leave.HideSelection = False
        Me.LV_Leave.Location = New System.Drawing.Point(51, 28)
        Me.LV_Leave.Name = "LV_Leave"
        Me.LV_Leave.Size = New System.Drawing.Size(675, 258)
        Me.LV_Leave.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LV_Leave.TabIndex = 209
        Me.LV_Leave.UseCompatibleStateImageBehavior = False
        Me.LV_Leave.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Item"
        '
        'Col_Leave_Type
        '
        Me.Col_Leave_Type.Text = "Type"
        Me.Col_Leave_Type.Width = 160
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date From"
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date To"
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Status"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 170
        '
        'Col_Reference_ID
        '
        Me.Col_Reference_ID.Text = "ID"
        Me.Col_Reference_ID.Width = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Lbl_Medical_Ref_ID)
        Me.TabPage2.Controls.Add(Me.Btn_Medical_Delete)
        Me.TabPage2.Controls.Add(Me.Btn_Medical_Edit)
        Me.TabPage2.Controls.Add(Me.Btn_Medical_New)
        Me.TabPage2.Controls.Add(Me.PictureBox4)
        Me.TabPage2.Controls.Add(Me.LV_Medical_List)
        Me.TabPage2.Controls.Add(Me.Grp_Medical_Info)
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(793, 647)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "  Medical Records  "
        '
        'Lbl_Medical_Ref_ID
        '
        Me.Lbl_Medical_Ref_ID.AutoSize = True
        Me.Lbl_Medical_Ref_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Medical_Ref_ID.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Medical_Ref_ID.Location = New System.Drawing.Point(335, 265)
        Me.Lbl_Medical_Ref_ID.Name = "Lbl_Medical_Ref_ID"
        Me.Lbl_Medical_Ref_ID.Size = New System.Drawing.Size(61, 20)
        Me.Lbl_Medical_Ref_ID.TabIndex = 182
        Me.Lbl_Medical_Ref_ID.Text = "Ref_ID"
        Me.Lbl_Medical_Ref_ID.Visible = False
        '
        'Btn_Medical_Delete
        '
        Me.Btn_Medical_Delete.Enabled = False
        Me.Btn_Medical_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Medical_Delete.Location = New System.Drawing.Point(428, 563)
        Me.Btn_Medical_Delete.Name = "Btn_Medical_Delete"
        Me.Btn_Medical_Delete.Size = New System.Drawing.Size(173, 34)
        Me.Btn_Medical_Delete.TabIndex = 180
        Me.Btn_Medical_Delete.Text = "Delete"
        Me.Btn_Medical_Delete.UseVisualStyleBackColor = True
        '
        'Btn_Medical_Edit
        '
        Me.Btn_Medical_Edit.Enabled = False
        Me.Btn_Medical_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Medical_Edit.Location = New System.Drawing.Point(237, 563)
        Me.Btn_Medical_Edit.Name = "Btn_Medical_Edit"
        Me.Btn_Medical_Edit.Size = New System.Drawing.Size(173, 34)
        Me.Btn_Medical_Edit.TabIndex = 179
        Me.Btn_Medical_Edit.Text = "Edit"
        Me.Btn_Medical_Edit.UseVisualStyleBackColor = True
        '
        'Btn_Medical_New
        '
        Me.Btn_Medical_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Medical_New.Location = New System.Drawing.Point(47, 563)
        Me.Btn_Medical_New.Name = "Btn_Medical_New"
        Me.Btn_Medical_New.Size = New System.Drawing.Size(173, 34)
        Me.Btn_Medical_New.TabIndex = 171
        Me.Btn_Medical_New.Text = "New"
        Me.Btn_Medical_New.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Teal
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(25, 545)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(718, 69)
        Me.PictureBox4.TabIndex = 172
        Me.PictureBox4.TabStop = False
        '
        'LV_Medical_List
        '
        Me.LV_Medical_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Medical_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.Col_Med_Type, Me.ColumnHeader10, Me.Col_Medical_Ref_ID})
        Me.LV_Medical_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Medical_List.FullRowSelect = True
        Me.LV_Medical_List.GridLines = True
        Me.LV_Medical_List.HideSelection = False
        Me.LV_Medical_List.Location = New System.Drawing.Point(28, 30)
        Me.LV_Medical_List.Name = "LV_Medical_List"
        Me.LV_Medical_List.Size = New System.Drawing.Size(715, 222)
        Me.LV_Medical_List.TabIndex = 166
        Me.LV_Medical_List.UseCompatibleStateImageBehavior = False
        Me.LV_Medical_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Item"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Medical Date"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 130
        '
        'Col_Med_Type
        '
        Me.Col_Med_Type.Text = "Type"
        Me.Col_Med_Type.Width = 140
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Results / Remarks"
        Me.ColumnHeader10.Width = 380
        '
        'Col_Medical_Ref_ID
        '
        Me.Col_Medical_Ref_ID.Text = "ID"
        Me.Col_Medical_Ref_ID.Width = 0
        '
        'Grp_Medical_Info
        '
        Me.Grp_Medical_Info.Controls.Add(Me.Txt_Medical_Exp_Date)
        Me.Grp_Medical_Info.Controls.Add(Me.DP_Medical_Exp_Date)
        Me.Grp_Medical_Info.Controls.Add(Me.Label26)
        Me.Grp_Medical_Info.Controls.Add(Me.Label25)
        Me.Grp_Medical_Info.Controls.Add(Me.Cmb_Hospital)
        Me.Grp_Medical_Info.Controls.Add(Me.Txt_Medical_Date)
        Me.Grp_Medical_Info.Controls.Add(Me.Label3)
        Me.Grp_Medical_Info.Controls.Add(Me.DP_Medical_Date)
        Me.Grp_Medical_Info.Controls.Add(Me.Cmb_Drug_Test)
        Me.Grp_Medical_Info.Controls.Add(Me.Label35)
        Me.Grp_Medical_Info.Controls.Add(Me.Label1)
        Me.Grp_Medical_Info.Controls.Add(Me.Cmb_Medical_Type)
        Me.Grp_Medical_Info.Controls.Add(Me.Txt_Medical_Remarks)
        Me.Grp_Medical_Info.Controls.Add(Me.Chk_Medical_Findings)
        Me.Grp_Medical_Info.Controls.Add(Me.Label15)
        Me.Grp_Medical_Info.Enabled = False
        Me.Grp_Medical_Info.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Medical_Info.Location = New System.Drawing.Point(25, 288)
        Me.Grp_Medical_Info.Name = "Grp_Medical_Info"
        Me.Grp_Medical_Info.Size = New System.Drawing.Size(718, 251)
        Me.Grp_Medical_Info.TabIndex = 181
        Me.Grp_Medical_Info.TabStop = False
        Me.Grp_Medical_Info.Text = "Medical Info"
        '
        'Txt_Medical_Exp_Date
        '
        Me.Txt_Medical_Exp_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Medical_Exp_Date.Location = New System.Drawing.Point(449, 115)
        Me.Txt_Medical_Exp_Date.Name = "Txt_Medical_Exp_Date"
        Me.Txt_Medical_Exp_Date.Size = New System.Drawing.Size(178, 26)
        Me.Txt_Medical_Exp_Date.TabIndex = 182
        '
        'DP_Medical_Exp_Date
        '
        Me.DP_Medical_Exp_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Medical_Exp_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Medical_Exp_Date.Location = New System.Drawing.Point(630, 115)
        Me.DP_Medical_Exp_Date.Name = "DP_Medical_Exp_Date"
        Me.DP_Medical_Exp_Date.Size = New System.Drawing.Size(17, 26)
        Me.DP_Medical_Exp_Date.TabIndex = 183
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(321, 118)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(122, 20)
        Me.Label26.TabIndex = 181
        Me.Label26.Text = "Expiration Date:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(39, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(71, 20)
        Me.Label25.TabIndex = 180
        Me.Label25.Text = "Hospital:"
        '
        'Cmb_Hospital
        '
        Me.Cmb_Hospital.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Hospital.FormattingEnabled = True
        Me.Cmb_Hospital.Items.AddRange(New Object() {"RB Lirio Medical and Diagnostic Clinic"})
        Me.Cmb_Hospital.Location = New System.Drawing.Point(152, 37)
        Me.Cmb_Hospital.Name = "Cmb_Hospital"
        Me.Cmb_Hospital.Size = New System.Drawing.Size(475, 28)
        Me.Cmb_Hospital.TabIndex = 179
        '
        'Txt_Medical_Date
        '
        Me.Txt_Medical_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Medical_Date.Location = New System.Drawing.Point(449, 72)
        Me.Txt_Medical_Date.Name = "Txt_Medical_Date"
        Me.Txt_Medical_Date.Size = New System.Drawing.Size(178, 26)
        Me.Txt_Medical_Date.TabIndex = 167
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(337, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 20)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "Medical Date:"
        '
        'DP_Medical_Date
        '
        Me.DP_Medical_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Medical_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Medical_Date.Location = New System.Drawing.Point(630, 72)
        Me.DP_Medical_Date.Name = "DP_Medical_Date"
        Me.DP_Medical_Date.Size = New System.Drawing.Size(17, 26)
        Me.DP_Medical_Date.TabIndex = 173
        '
        'Cmb_Drug_Test
        '
        Me.Cmb_Drug_Test.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Drug_Test.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Drug_Test.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Drug_Test.FormattingEnabled = True
        Me.Cmb_Drug_Test.Items.AddRange(New Object() {"Passed", "Failed"})
        Me.Cmb_Drug_Test.Location = New System.Drawing.Point(152, 113)
        Me.Cmb_Drug_Test.Name = "Cmb_Drug_Test"
        Me.Cmb_Drug_Test.Size = New System.Drawing.Size(130, 28)
        Me.Cmb_Drug_Test.TabIndex = 177
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(39, 78)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(105, 20)
        Me.Label35.TabIndex = 170
        Me.Label35.Text = "Medical Type:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(39, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Drug Test:"
        '
        'Cmb_Medical_Type
        '
        Me.Cmb_Medical_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Medical_Type.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_Medical_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Medical_Type.FormattingEnabled = True
        Me.Cmb_Medical_Type.Items.AddRange(New Object() {"Annual Medical", "Pre-Employment", "Pre-Permanency"})
        Me.Cmb_Medical_Type.Location = New System.Drawing.Point(152, 75)
        Me.Cmb_Medical_Type.Name = "Cmb_Medical_Type"
        Me.Cmb_Medical_Type.Size = New System.Drawing.Size(154, 28)
        Me.Cmb_Medical_Type.TabIndex = 169
        '
        'Txt_Medical_Remarks
        '
        Me.Txt_Medical_Remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Medical_Remarks.Location = New System.Drawing.Point(43, 189)
        Me.Txt_Medical_Remarks.Multiline = True
        Me.Txt_Medical_Remarks.Name = "Txt_Medical_Remarks"
        Me.Txt_Medical_Remarks.Size = New System.Drawing.Size(604, 47)
        Me.Txt_Medical_Remarks.TabIndex = 175
        '
        'Chk_Medical_Findings
        '
        Me.Chk_Medical_Findings.AutoSize = True
        Me.Chk_Medical_Findings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Medical_Findings.ForeColor = System.Drawing.Color.Red
        Me.Chk_Medical_Findings.Location = New System.Drawing.Point(197, 165)
        Me.Chk_Medical_Findings.Name = "Chk_Medical_Findings"
        Me.Chk_Medical_Findings.Size = New System.Drawing.Size(130, 24)
        Me.Chk_Medical_Findings.TabIndex = 174
        Me.Chk_Medical_Findings.Text = "with Finding(s)"
        Me.Chk_Medical_Findings.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(39, 166)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 20)
        Me.Label15.TabIndex = 176
        Me.Label15.Text = "Results / Remarks:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Btn_Insurance_Delete)
        Me.TabPage3.Controls.Add(Me.Btn_Insurance_Edit)
        Me.TabPage3.Controls.Add(Me.Btn_Insurance_New)
        Me.TabPage3.Controls.Add(Me.PictureBox5)
        Me.TabPage3.Controls.Add(Me.LV_Insurance_List)
        Me.TabPage3.Controls.Add(Me.Grp_Insurance_Info)
        Me.TabPage3.Location = New System.Drawing.Point(4, 32)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(793, 647)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Insurance"
        '
        'Btn_Insurance_Delete
        '
        Me.Btn_Insurance_Delete.Enabled = False
        Me.Btn_Insurance_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Insurance_Delete.Location = New System.Drawing.Point(351, 564)
        Me.Btn_Insurance_Delete.Name = "Btn_Insurance_Delete"
        Me.Btn_Insurance_Delete.Size = New System.Drawing.Size(134, 34)
        Me.Btn_Insurance_Delete.TabIndex = 197
        Me.Btn_Insurance_Delete.Text = "Delete"
        Me.Btn_Insurance_Delete.UseVisualStyleBackColor = True
        '
        'Btn_Insurance_Edit
        '
        Me.Btn_Insurance_Edit.Enabled = False
        Me.Btn_Insurance_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Insurance_Edit.Location = New System.Drawing.Point(202, 564)
        Me.Btn_Insurance_Edit.Name = "Btn_Insurance_Edit"
        Me.Btn_Insurance_Edit.Size = New System.Drawing.Size(134, 34)
        Me.Btn_Insurance_Edit.TabIndex = 196
        Me.Btn_Insurance_Edit.Text = "Edit"
        Me.Btn_Insurance_Edit.UseVisualStyleBackColor = True
        '
        'Btn_Insurance_New
        '
        Me.Btn_Insurance_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Insurance_New.Location = New System.Drawing.Point(53, 564)
        Me.Btn_Insurance_New.Name = "Btn_Insurance_New"
        Me.Btn_Insurance_New.Size = New System.Drawing.Size(134, 34)
        Me.Btn_Insurance_New.TabIndex = 193
        Me.Btn_Insurance_New.Text = "New"
        Me.Btn_Insurance_New.UseVisualStyleBackColor = True
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Teal
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Location = New System.Drawing.Point(24, 546)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(732, 69)
        Me.PictureBox5.TabIndex = 194
        Me.PictureBox5.TabStop = False
        '
        'LV_Insurance_List
        '
        Me.LV_Insurance_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Insurance_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.Col_Insu_Company, Me.Col_PolicyNum, Me.Col_Insurance_RefID})
        Me.LV_Insurance_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Insurance_List.FullRowSelect = True
        Me.LV_Insurance_List.GridLines = True
        Me.LV_Insurance_List.HideSelection = False
        Me.LV_Insurance_List.Location = New System.Drawing.Point(24, 25)
        Me.LV_Insurance_List.Name = "LV_Insurance_List"
        Me.LV_Insurance_List.Size = New System.Drawing.Size(732, 314)
        Me.LV_Insurance_List.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LV_Insurance_List.TabIndex = 190
        Me.LV_Insurance_List.UseCompatibleStateImageBehavior = False
        Me.LV_Insurance_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Item"
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Start Date"
        Me.ColumnHeader12.Width = 130
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "End Date"
        Me.ColumnHeader13.Width = 130
        '
        'Col_Insu_Company
        '
        Me.Col_Insu_Company.Text = "Insurance Company"
        Me.Col_Insu_Company.Width = 260
        '
        'Col_PolicyNum
        '
        Me.Col_PolicyNum.DisplayIndex = 5
        Me.Col_PolicyNum.Text = "Policy No."
        Me.Col_PolicyNum.Width = 150
        '
        'Col_Insurance_RefID
        '
        Me.Col_Insurance_RefID.DisplayIndex = 4
        Me.Col_Insurance_RefID.Text = "ID"
        Me.Col_Insurance_RefID.Width = 0
        '
        'Grp_Insurance_Info
        '
        Me.Grp_Insurance_Info.Controls.Add(Me.Label20)
        Me.Grp_Insurance_Info.Controls.Add(Me.Cmb_Insurance_CompName)
        Me.Grp_Insurance_Info.Controls.Add(Me.Txt_Insurance_Policy)
        Me.Grp_Insurance_Info.Controls.Add(Me.DP_Insurance_DateEnd)
        Me.Grp_Insurance_Info.Controls.Add(Me.Label9)
        Me.Grp_Insurance_Info.Controls.Add(Me.Label10)
        Me.Grp_Insurance_Info.Controls.Add(Me.Txt_Insurance_DateEnd)
        Me.Grp_Insurance_Info.Controls.Add(Me.Txt_Insurance_DateStart)
        Me.Grp_Insurance_Info.Controls.Add(Me.Label11)
        Me.Grp_Insurance_Info.Controls.Add(Me.DP_Insurance_DateStart)
        Me.Grp_Insurance_Info.Enabled = False
        Me.Grp_Insurance_Info.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Insurance_Info.Location = New System.Drawing.Point(24, 345)
        Me.Grp_Insurance_Info.Name = "Grp_Insurance_Info"
        Me.Grp_Insurance_Info.Size = New System.Drawing.Size(732, 195)
        Me.Grp_Insurance_Info.TabIndex = 202
        Me.Grp_Insurance_Info.TabStop = False
        Me.Grp_Insurance_Info.Text = "Insurance Info"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(34, 31)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(155, 20)
        Me.Label20.TabIndex = 203
        Me.Label20.Text = "Insurance Company:"
        '
        'Cmb_Insurance_CompName
        '
        Me.Cmb_Insurance_CompName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Insurance_CompName.FormattingEnabled = True
        Me.Cmb_Insurance_CompName.Items.AddRange(New Object() {"FPG Insurance", "AFPMBAI"})
        Me.Cmb_Insurance_CompName.Location = New System.Drawing.Point(195, 28)
        Me.Cmb_Insurance_CompName.Name = "Cmb_Insurance_CompName"
        Me.Cmb_Insurance_CompName.Size = New System.Drawing.Size(254, 28)
        Me.Cmb_Insurance_CompName.TabIndex = 202
        '
        'Txt_Insurance_Policy
        '
        Me.Txt_Insurance_Policy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Insurance_Policy.Location = New System.Drawing.Point(195, 68)
        Me.Txt_Insurance_Policy.Name = "Txt_Insurance_Policy"
        Me.Txt_Insurance_Policy.Size = New System.Drawing.Size(254, 26)
        Me.Txt_Insurance_Policy.TabIndex = 201
        '
        'DP_Insurance_DateEnd
        '
        Me.DP_Insurance_DateEnd.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Insurance_DateEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Insurance_DateEnd.Location = New System.Drawing.Point(376, 151)
        Me.DP_Insurance_DateEnd.Name = "DP_Insurance_DateEnd"
        Me.DP_Insurance_DateEnd.Size = New System.Drawing.Size(17, 26)
        Me.DP_Insurance_DateEnd.TabIndex = 200
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(34, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 20)
        Me.Label9.TabIndex = 182
        Me.Label9.Text = "Policy No:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(34, 154)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 20)
        Me.Label10.TabIndex = 199
        Me.Label10.Text = "End Date:"
        '
        'Txt_Insurance_DateEnd
        '
        Me.Txt_Insurance_DateEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Insurance_DateEnd.Location = New System.Drawing.Point(195, 151)
        Me.Txt_Insurance_DateEnd.Name = "Txt_Insurance_DateEnd"
        Me.Txt_Insurance_DateEnd.Size = New System.Drawing.Size(178, 26)
        Me.Txt_Insurance_DateEnd.TabIndex = 198
        '
        'Txt_Insurance_DateStart
        '
        Me.Txt_Insurance_DateStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Insurance_DateStart.Location = New System.Drawing.Point(195, 114)
        Me.Txt_Insurance_DateStart.Name = "Txt_Insurance_DateStart"
        Me.Txt_Insurance_DateStart.Size = New System.Drawing.Size(178, 26)
        Me.Txt_Insurance_DateStart.TabIndex = 191
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(34, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 20)
        Me.Label11.TabIndex = 192
        Me.Label11.Text = "Start Date:"
        '
        'DP_Insurance_DateStart
        '
        Me.DP_Insurance_DateStart.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Insurance_DateStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Insurance_DateStart.Location = New System.Drawing.Point(376, 114)
        Me.DP_Insurance_DateStart.Name = "DP_Insurance_DateStart"
        Me.DP_Insurance_DateStart.Size = New System.Drawing.Size(17, 26)
        Me.DP_Insurance_DateStart.TabIndex = 195
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.Lbl_License_View_Attachment)
        Me.TabPage4.Controls.Add(Me.Grp_License)
        Me.TabPage4.Controls.Add(Me.Btn_License_Delete)
        Me.TabPage4.Controls.Add(Me.Btn_License_Edit)
        Me.TabPage4.Controls.Add(Me.Btn_License_NEW)
        Me.TabPage4.Controls.Add(Me.PictureBox6)
        Me.TabPage4.Controls.Add(Me.LV_License_Record)
        Me.TabPage4.Location = New System.Drawing.Point(4, 32)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(793, 647)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Security License"
        '
        'Lbl_License_View_Attachment
        '
        Me.Lbl_License_View_Attachment.AutoSize = True
        Me.Lbl_License_View_Attachment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lbl_License_View_Attachment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_License_View_Attachment.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_License_View_Attachment.Location = New System.Drawing.Point(632, 4)
        Me.Lbl_License_View_Attachment.Name = "Lbl_License_View_Attachment"
        Me.Lbl_License_View_Attachment.Size = New System.Drawing.Size(130, 20)
        Me.Lbl_License_View_Attachment.TabIndex = 240
        Me.Lbl_License_View_Attachment.Text = "View Attachment"
        '
        'Grp_License
        '
        Me.Grp_License.Controls.Add(Me.Btn_License_AttachFile)
        Me.Grp_License.Controls.Add(Me.Txt_License_Attachment)
        Me.Grp_License.Controls.Add(Me.Label16)
        Me.Grp_License.Controls.Add(Me.Label12)
        Me.Grp_License.Controls.Add(Me.Cmb_LicenseType)
        Me.Grp_License.Controls.Add(Me.Label13)
        Me.Grp_License.Controls.Add(Me.Txt_License_Number)
        Me.Grp_License.Controls.Add(Me.DP_License_Expiry)
        Me.Grp_License.Controls.Add(Me.Label14)
        Me.Grp_License.Controls.Add(Me.Txt_License_Expiry)
        Me.Grp_License.Enabled = False
        Me.Grp_License.ForeColor = System.Drawing.Color.Blue
        Me.Grp_License.Location = New System.Drawing.Point(25, 295)
        Me.Grp_License.Name = "Grp_License"
        Me.Grp_License.Size = New System.Drawing.Size(737, 226)
        Me.Grp_License.TabIndex = 230
        Me.Grp_License.TabStop = False
        Me.Grp_License.Text = "License Information"
        '
        'Btn_License_AttachFile
        '
        Me.Btn_License_AttachFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_License_AttachFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_License_AttachFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_License_AttachFile.Location = New System.Drawing.Point(250, 146)
        Me.Btn_License_AttachFile.Name = "Btn_License_AttachFile"
        Me.Btn_License_AttachFile.Size = New System.Drawing.Size(53, 27)
        Me.Btn_License_AttachFile.TabIndex = 239
        Me.Btn_License_AttachFile.Text = "..."
        Me.Btn_License_AttachFile.UseVisualStyleBackColor = False
        '
        'Txt_License_Attachment
        '
        Me.Txt_License_Attachment.Enabled = False
        Me.Txt_License_Attachment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_License_Attachment.Location = New System.Drawing.Point(39, 179)
        Me.Txt_License_Attachment.Multiline = True
        Me.Txt_License_Attachment.Name = "Txt_License_Attachment"
        Me.Txt_License_Attachment.Size = New System.Drawing.Size(671, 24)
        Me.Txt_License_Attachment.TabIndex = 237
        Me.Txt_License_Attachment.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(36, 149)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(208, 20)
        Me.Label16.TabIndex = 238
        Me.Label16.Text = "Attach Scanned License ID:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(35, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 20)
        Me.Label12.TabIndex = 236
        Me.Label12.Text = "Type:"
        '
        'Cmb_LicenseType
        '
        Me.Cmb_LicenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_LicenseType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cmb_LicenseType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_LicenseType.FormattingEnabled = True
        Me.Cmb_LicenseType.Items.AddRange(New Object() {"SG", "SO", "LG", "MCG", "BAG", "CBASTRAC", "NA"})
        Me.Cmb_LicenseType.Location = New System.Drawing.Point(137, 105)
        Me.Cmb_LicenseType.Name = "Cmb_LicenseType"
        Me.Cmb_LicenseType.Size = New System.Drawing.Size(137, 28)
        Me.Cmb_LicenseType.TabIndex = 235
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(35, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 20)
        Me.Label13.TabIndex = 234
        Me.Label13.Text = "License No.:"
        '
        'Txt_License_Number
        '
        Me.Txt_License_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_License_Number.Location = New System.Drawing.Point(137, 36)
        Me.Txt_License_Number.Name = "Txt_License_Number"
        Me.Txt_License_Number.Size = New System.Drawing.Size(178, 26)
        Me.Txt_License_Number.TabIndex = 233
        Me.Txt_License_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_License_Expiry
        '
        Me.DP_License_Expiry.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_License_Expiry.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_License_Expiry.Location = New System.Drawing.Point(320, 70)
        Me.DP_License_Expiry.Name = "DP_License_Expiry"
        Me.DP_License_Expiry.Size = New System.Drawing.Size(17, 26)
        Me.DP_License_Expiry.TabIndex = 232
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(35, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 20)
        Me.Label14.TabIndex = 231
        Me.Label14.Text = "Expiry Date:"
        '
        'Txt_License_Expiry
        '
        Me.Txt_License_Expiry.Enabled = False
        Me.Txt_License_Expiry.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_License_Expiry.Location = New System.Drawing.Point(137, 70)
        Me.Txt_License_Expiry.Name = "Txt_License_Expiry"
        Me.Txt_License_Expiry.Size = New System.Drawing.Size(178, 26)
        Me.Txt_License_Expiry.TabIndex = 230
        Me.Txt_License_Expiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_License_Delete
        '
        Me.Btn_License_Delete.Enabled = False
        Me.Btn_License_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_License_Delete.Location = New System.Drawing.Point(355, 546)
        Me.Btn_License_Delete.Name = "Btn_License_Delete"
        Me.Btn_License_Delete.Size = New System.Drawing.Size(134, 34)
        Me.Btn_License_Delete.TabIndex = 221
        Me.Btn_License_Delete.Text = "Delete"
        Me.Btn_License_Delete.UseVisualStyleBackColor = True
        '
        'Btn_License_Edit
        '
        Me.Btn_License_Edit.Enabled = False
        Me.Btn_License_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_License_Edit.Location = New System.Drawing.Point(206, 546)
        Me.Btn_License_Edit.Name = "Btn_License_Edit"
        Me.Btn_License_Edit.Size = New System.Drawing.Size(134, 34)
        Me.Btn_License_Edit.TabIndex = 220
        Me.Btn_License_Edit.Text = "Edit"
        Me.Btn_License_Edit.UseVisualStyleBackColor = True
        '
        'Btn_License_NEW
        '
        Me.Btn_License_NEW.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_License_NEW.Location = New System.Drawing.Point(60, 546)
        Me.Btn_License_NEW.Name = "Btn_License_NEW"
        Me.Btn_License_NEW.Size = New System.Drawing.Size(134, 34)
        Me.Btn_License_NEW.TabIndex = 217
        Me.Btn_License_NEW.Text = "New"
        Me.Btn_License_NEW.UseVisualStyleBackColor = True
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Teal
        Me.PictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox6.Location = New System.Drawing.Point(25, 527)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(737, 69)
        Me.PictureBox6.TabIndex = 218
        Me.PictureBox6.TabStop = False
        '
        'LV_License_Record
        '
        Me.LV_License_Record.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_License_Record.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader15, Me.Col_License_Number, Me.Col_type, Me.Col_Exp, Me.Col_SEC_Ref_ID})
        Me.LV_License_Record.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_License_Record.FullRowSelect = True
        Me.LV_License_Record.GridLines = True
        Me.LV_License_Record.HideSelection = False
        Me.LV_License_Record.Location = New System.Drawing.Point(25, 27)
        Me.LV_License_Record.Name = "LV_License_Record"
        Me.LV_License_Record.Size = New System.Drawing.Size(737, 262)
        Me.LV_License_Record.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LV_License_Record.TabIndex = 214
        Me.LV_License_Record.UseCompatibleStateImageBehavior = False
        Me.LV_License_Record.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Item"
        Me.ColumnHeader15.Width = 100
        '
        'Col_License_Number
        '
        Me.Col_License_Number.Text = "License No."
        Me.Col_License_Number.Width = 260
        '
        'Col_type
        '
        Me.Col_type.Text = "Type"
        Me.Col_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_type.Width = 150
        '
        'Col_Exp
        '
        Me.Col_Exp.Text = "Expiration Date"
        Me.Col_Exp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Exp.Width = 220
        '
        'Col_SEC_Ref_ID
        '
        Me.Col_SEC_Ref_ID.Text = "ID"
        Me.Col_SEC_Ref_ID.Width = 0
        '
        'Tab_Client
        '
        Me.Tab_Client.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Tab_Client.Controls.Add(Me.Btn_Client_Add)
        Me.Tab_Client.Controls.Add(Me.Btn_Client_Edit)
        Me.Tab_Client.Controls.Add(Me.Grp_Client_Info)
        Me.Tab_Client.Controls.Add(Me.Btn_Client_Delete)
        Me.Tab_Client.Controls.Add(Me.Btn_Client_Change)
        Me.Tab_Client.Controls.Add(Me.LV_Client_History)
        Me.Tab_Client.Controls.Add(Me.PictureBox9)
        Me.Tab_Client.Location = New System.Drawing.Point(4, 32)
        Me.Tab_Client.Name = "Tab_Client"
        Me.Tab_Client.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Client.Size = New System.Drawing.Size(793, 647)
        Me.Tab_Client.TabIndex = 6
        Me.Tab_Client.Text = "Client Change"
        '
        'Btn_Client_Add
        '
        Me.Btn_Client_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Client_Add.Location = New System.Drawing.Point(354, 549)
        Me.Btn_Client_Add.Name = "Btn_Client_Add"
        Me.Btn_Client_Add.Size = New System.Drawing.Size(120, 34)
        Me.Btn_Client_Add.TabIndex = 180
        Me.Btn_Client_Add.Text = "Add"
        Me.Btn_Client_Add.UseVisualStyleBackColor = True
        '
        'Btn_Client_Edit
        '
        Me.Btn_Client_Edit.Enabled = False
        Me.Btn_Client_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Client_Edit.Location = New System.Drawing.Point(480, 549)
        Me.Btn_Client_Edit.Name = "Btn_Client_Edit"
        Me.Btn_Client_Edit.Size = New System.Drawing.Size(120, 34)
        Me.Btn_Client_Edit.TabIndex = 179
        Me.Btn_Client_Edit.Text = "Edit"
        Me.Btn_Client_Edit.UseVisualStyleBackColor = True
        '
        'Grp_Client_Info
        '
        Me.Grp_Client_Info.Controls.Add(Me.Chk_UptoPresent)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_Client_End_Date)
        Me.Grp_Client_Info.Controls.Add(Me.DP_Client_End_Date)
        Me.Grp_Client_Info.Controls.Add(Me.Label27)
        Me.Grp_Client_Info.Controls.Add(Me.Lbl_Client_Ref_ID)
        Me.Grp_Client_Info.Controls.Add(Me.Label24)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_selected_Client_ID)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_Client_Start_Date)
        Me.Grp_Client_Info.Controls.Add(Me.DP_Client_Start_Date)
        Me.Grp_Client_Info.Controls.Add(Me.Lbl_Client_Start_Date)
        Me.Grp_Client_Info.Controls.Add(Me.LblClient_Address)
        Me.Grp_Client_Info.Controls.Add(Me.Btn_ShowClientList)
        Me.Grp_Client_Info.Controls.Add(Me.Label30)
        Me.Grp_Client_Info.Controls.Add(Me.Label22)
        Me.Grp_Client_Info.Controls.Add(Me.Label29)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_ClientID)
        Me.Grp_Client_Info.Controls.Add(Me.Lbl_ClientName)
        Me.Grp_Client_Info.Enabled = False
        Me.Grp_Client_Info.ForeColor = System.Drawing.Color.Blue
        Me.Grp_Client_Info.Location = New System.Drawing.Point(23, 285)
        Me.Grp_Client_Info.Name = "Grp_Client_Info"
        Me.Grp_Client_Info.Size = New System.Drawing.Size(735, 229)
        Me.Grp_Client_Info.TabIndex = 178
        Me.Grp_Client_Info.TabStop = False
        Me.Grp_Client_Info.Text = "Client Info"
        '
        'Chk_UptoPresent
        '
        Me.Chk_UptoPresent.AutoSize = True
        Me.Chk_UptoPresent.ForeColor = System.Drawing.Color.Black
        Me.Chk_UptoPresent.Location = New System.Drawing.Point(324, 123)
        Me.Chk_UptoPresent.Name = "Chk_UptoPresent"
        Me.Chk_UptoPresent.Size = New System.Drawing.Size(125, 24)
        Me.Chk_UptoPresent.TabIndex = 186
        Me.Chk_UptoPresent.Text = "Up to present"
        Me.Chk_UptoPresent.UseVisualStyleBackColor = True
        '
        'Txt_Client_End_Date
        '
        Me.Txt_Client_End_Date.Enabled = False
        Me.Txt_Client_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Client_End_Date.Location = New System.Drawing.Point(146, 121)
        Me.Txt_Client_End_Date.Name = "Txt_Client_End_Date"
        Me.Txt_Client_End_Date.Size = New System.Drawing.Size(152, 26)
        Me.Txt_Client_End_Date.TabIndex = 185
        Me.Txt_Client_End_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Client_End_Date
        '
        Me.DP_Client_End_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Client_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Client_End_Date.Location = New System.Drawing.Point(301, 121)
        Me.DP_Client_End_Date.Name = "DP_Client_End_Date"
        Me.DP_Client_End_Date.Size = New System.Drawing.Size(17, 26)
        Me.DP_Client_End_Date.TabIndex = 183
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(39, 124)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(81, 20)
        Me.Label27.TabIndex = 184
        Me.Label27.Text = "End Date:"
        '
        'Lbl_Client_Ref_ID
        '
        Me.Lbl_Client_Ref_ID.AutoSize = True
        Me.Lbl_Client_Ref_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Client_Ref_ID.ForeColor = System.Drawing.Color.Gray
        Me.Lbl_Client_Ref_ID.Location = New System.Drawing.Point(552, 74)
        Me.Lbl_Client_Ref_ID.Name = "Lbl_Client_Ref_ID"
        Me.Lbl_Client_Ref_ID.Size = New System.Drawing.Size(60, 20)
        Me.Lbl_Client_Ref_ID.TabIndex = 182
        Me.Lbl_Client_Ref_ID.Text = "Ref ID:"
        Me.Lbl_Client_Ref_ID.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Gray
        Me.Label24.Location = New System.Drawing.Point(403, 49)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(141, 20)
        Me.Label24.TabIndex = 181
        Me.Label24.Text = "Selected Client ID:"
        Me.Label24.Visible = False
        '
        'Txt_selected_Client_ID
        '
        Me.Txt_selected_Client_ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Txt_selected_Client_ID.Enabled = False
        Me.Txt_selected_Client_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_selected_Client_ID.Location = New System.Drawing.Point(556, 45)
        Me.Txt_selected_Client_ID.Name = "Txt_selected_Client_ID"
        Me.Txt_selected_Client_ID.Size = New System.Drawing.Size(90, 26)
        Me.Txt_selected_Client_ID.TabIndex = 180
        Me.Txt_selected_Client_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_selected_Client_ID.Visible = False
        '
        'Txt_Client_Start_Date
        '
        Me.Txt_Client_Start_Date.Enabled = False
        Me.Txt_Client_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Client_Start_Date.Location = New System.Drawing.Point(146, 89)
        Me.Txt_Client_Start_Date.Name = "Txt_Client_Start_Date"
        Me.Txt_Client_Start_Date.Size = New System.Drawing.Size(152, 26)
        Me.Txt_Client_Start_Date.TabIndex = 179
        Me.Txt_Client_Start_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Client_Start_Date
        '
        Me.DP_Client_Start_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Client_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Client_Start_Date.Location = New System.Drawing.Point(301, 89)
        Me.DP_Client_Start_Date.Name = "DP_Client_Start_Date"
        Me.DP_Client_Start_Date.Size = New System.Drawing.Size(17, 26)
        Me.DP_Client_Start_Date.TabIndex = 177
        '
        'Lbl_Client_Start_Date
        '
        Me.Lbl_Client_Start_Date.AutoSize = True
        Me.Lbl_Client_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Client_Start_Date.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Client_Start_Date.Location = New System.Drawing.Point(39, 92)
        Me.Lbl_Client_Start_Date.Name = "Lbl_Client_Start_Date"
        Me.Lbl_Client_Start_Date.Size = New System.Drawing.Size(87, 20)
        Me.Lbl_Client_Start_Date.TabIndex = 178
        Me.Lbl_Client_Start_Date.Text = "Start Date:"
        '
        'LblClient_Address
        '
        Me.LblClient_Address.AutoSize = True
        Me.LblClient_Address.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClient_Address.ForeColor = System.Drawing.Color.Blue
        Me.LblClient_Address.Location = New System.Drawing.Point(144, 197)
        Me.LblClient_Address.Name = "LblClient_Address"
        Me.LblClient_Address.Size = New System.Drawing.Size(112, 20)
        Me.LblClient_Address.TabIndex = 176
        Me.LblClient_Address.Text = "Client Address"
        '
        'Btn_ShowClientList
        '
        Me.Btn_ShowClientList.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_ShowClientList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_ShowClientList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ShowClientList.Location = New System.Drawing.Point(234, 46)
        Me.Btn_ShowClientList.Name = "Btn_ShowClientList"
        Me.Btn_ShowClientList.Size = New System.Drawing.Size(145, 27)
        Me.Btn_ShowClientList.TabIndex = 132
        Me.Btn_ShowClientList.Text = "Select Client"
        Me.Btn_ShowClientList.UseVisualStyleBackColor = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(39, 197)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(72, 20)
        Me.Label30.TabIndex = 175
        Me.Label30.Text = "Address:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(39, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 20)
        Me.Label22.TabIndex = 133
        Me.Label22.Text = "Client ID:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(39, 164)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(99, 20)
        Me.Label29.TabIndex = 174
        Me.Label29.Text = "Client Name:"
        '
        'Txt_ClientID
        '
        Me.Txt_ClientID.Enabled = False
        Me.Txt_ClientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClientID.Location = New System.Drawing.Point(146, 47)
        Me.Txt_ClientID.Name = "Txt_ClientID"
        Me.Txt_ClientID.Size = New System.Drawing.Size(82, 26)
        Me.Txt_ClientID.TabIndex = 131
        Me.Txt_ClientID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_ClientName
        '
        Me.Lbl_ClientName.AutoSize = True
        Me.Lbl_ClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ClientName.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_ClientName.Location = New System.Drawing.Point(144, 164)
        Me.Lbl_ClientName.Name = "Lbl_ClientName"
        Me.Lbl_ClientName.Size = New System.Drawing.Size(95, 20)
        Me.Lbl_ClientName.TabIndex = 134
        Me.Lbl_ClientName.Text = "Client Name"
        '
        'Btn_Client_Delete
        '
        Me.Btn_Client_Delete.Enabled = False
        Me.Btn_Client_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Client_Delete.Location = New System.Drawing.Point(606, 549)
        Me.Btn_Client_Delete.Name = "Btn_Client_Delete"
        Me.Btn_Client_Delete.Size = New System.Drawing.Size(120, 34)
        Me.Btn_Client_Delete.TabIndex = 177
        Me.Btn_Client_Delete.Text = "Delete"
        Me.Btn_Client_Delete.UseVisualStyleBackColor = True
        '
        'Btn_Client_Change
        '
        Me.Btn_Client_Change.Enabled = False
        Me.Btn_Client_Change.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Client_Change.Location = New System.Drawing.Point(38, 549)
        Me.Btn_Client_Change.Name = "Btn_Client_Change"
        Me.Btn_Client_Change.Size = New System.Drawing.Size(173, 34)
        Me.Btn_Client_Change.TabIndex = 172
        Me.Btn_Client_Change.Text = "Change Assignment"
        Me.Btn_Client_Change.UseVisualStyleBackColor = True
        Me.Btn_Client_Change.Visible = False
        '
        'LV_Client_History
        '
        Me.LV_Client_History.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Client_History.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader22, Me.Col_Client_Address, Me.Col_Client_StartDate, Me.Col_Client_EndDate, Me.Col_Client_Ref_ID})
        Me.LV_Client_History.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Client_History.FullRowSelect = True
        Me.LV_Client_History.GridLines = True
        Me.LV_Client_History.HideSelection = False
        Me.LV_Client_History.Location = New System.Drawing.Point(23, 22)
        Me.LV_Client_History.Name = "LV_Client_History"
        Me.LV_Client_History.Size = New System.Drawing.Size(735, 257)
        Me.LV_Client_History.TabIndex = 156
        Me.LV_Client_History.UseCompatibleStateImageBehavior = False
        Me.LV_Client_History.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Client ID"
        Me.ColumnHeader5.Width = 90
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Client Name"
        Me.ColumnHeader22.Width = 300
        '
        'Col_Client_Address
        '
        Me.Col_Client_Address.Text = "Address"
        Me.Col_Client_Address.Width = 0
        '
        'Col_Client_StartDate
        '
        Me.Col_Client_StartDate.Text = "Date Started"
        Me.Col_Client_StartDate.Width = 170
        '
        'Col_Client_EndDate
        '
        Me.Col_Client_EndDate.Text = "Date Ended"
        Me.Col_Client_EndDate.Width = 170
        '
        'Col_Client_Ref_ID
        '
        Me.Col_Client_Ref_ID.Text = "ID"
        Me.Col_Client_Ref_ID.Width = 0
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Teal
        Me.PictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox9.Location = New System.Drawing.Point(23, 530)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(735, 69)
        Me.PictureBox9.TabIndex = 173
        Me.PictureBox9.TabStop = False
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.LV_Status_History)
        Me.TabPage6.Controls.Add(Me.Btn_Separation_Update)
        Me.TabPage6.Controls.Add(Me.PictureBox7)
        Me.TabPage6.Controls.Add(Me.Txt_StatusChange_Date)
        Me.TabPage6.Controls.Add(Me.DP_Sepa_day)
        Me.TabPage6.Controls.Add(Me.Label17)
        Me.TabPage6.Controls.Add(Me.Label18)
        Me.TabPage6.Controls.Add(Me.Txt_ChangeStatus_Remark)
        Me.TabPage6.Controls.Add(Me.Cmb_Separation)
        Me.TabPage6.Controls.Add(Me.Label19)
        Me.TabPage6.Location = New System.Drawing.Point(4, 32)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(793, 647)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Employment Status"
        '
        'LV_Status_History
        '
        Me.LV_Status_History.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Status_History.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.Col_DeclaredStatus, Me.ColumnHeader14, Me.ColumnHeader16, Me.ColumnHeader9})
        Me.LV_Status_History.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Status_History.FullRowSelect = True
        Me.LV_Status_History.GridLines = True
        Me.LV_Status_History.HideSelection = False
        Me.LV_Status_History.Location = New System.Drawing.Point(31, 30)
        Me.LV_Status_History.Name = "LV_Status_History"
        Me.LV_Status_History.Size = New System.Drawing.Size(715, 222)
        Me.LV_Status_History.TabIndex = 167
        Me.LV_Status_History.UseCompatibleStateImageBehavior = False
        Me.LV_Status_History.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Item"
        '
        'Col_DeclaredStatus
        '
        Me.Col_DeclaredStatus.Text = " Declared Status"
        Me.Col_DeclaredStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_DeclaredStatus.Width = 160
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Effectivity Date"
        Me.ColumnHeader14.Width = 160
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Remarks"
        Me.ColumnHeader16.Width = 380
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "ID"
        Me.ColumnHeader9.Width = 0
        '
        'Btn_Separation_Update
        '
        Me.Btn_Separation_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Separation_Update.Location = New System.Drawing.Point(523, 531)
        Me.Btn_Separation_Update.Name = "Btn_Separation_Update"
        Me.Btn_Separation_Update.Size = New System.Drawing.Size(173, 34)
        Me.Btn_Separation_Update.TabIndex = 165
        Me.Btn_Separation_Update.Text = "Change Status"
        Me.Btn_Separation_Update.UseVisualStyleBackColor = True
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Teal
        Me.PictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox7.Location = New System.Drawing.Point(50, 515)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(671, 69)
        Me.PictureBox7.TabIndex = 164
        Me.PictureBox7.TabStop = False
        '
        'Txt_StatusChange_Date
        '
        Me.Txt_StatusChange_Date.Enabled = False
        Me.Txt_StatusChange_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_StatusChange_Date.Location = New System.Drawing.Point(497, 276)
        Me.Txt_StatusChange_Date.Name = "Txt_StatusChange_Date"
        Me.Txt_StatusChange_Date.Size = New System.Drawing.Size(185, 26)
        Me.Txt_StatusChange_Date.TabIndex = 163
        Me.Txt_StatusChange_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Sepa_day
        '
        Me.DP_Sepa_day.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Sepa_day.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Sepa_day.Location = New System.Drawing.Point(686, 276)
        Me.DP_Sepa_day.Name = "DP_Sepa_day"
        Me.DP_Sepa_day.Size = New System.Drawing.Size(17, 26)
        Me.DP_Sepa_day.TabIndex = 162
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(349, 280)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(142, 18)
        Me.Label17.TabIndex = 161
        Me.Label17.Text = "Effectivity Date:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(47, 336)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 18)
        Me.Label18.TabIndex = 160
        Me.Label18.Text = "Remarks"
        '
        'Txt_ChangeStatus_Remark
        '
        Me.Txt_ChangeStatus_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ChangeStatus_Remark.Location = New System.Drawing.Point(50, 369)
        Me.Txt_ChangeStatus_Remark.Multiline = True
        Me.Txt_ChangeStatus_Remark.Name = "Txt_ChangeStatus_Remark"
        Me.Txt_ChangeStatus_Remark.Size = New System.Drawing.Size(657, 62)
        Me.Txt_ChangeStatus_Remark.TabIndex = 159
        '
        'Cmb_Separation
        '
        Me.Cmb_Separation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Separation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Separation.FormattingEnabled = True
        Me.Cmb_Separation.Items.AddRange(New Object() {"Active", "Resigned", "Terminated", "Finished Contract", "AWOL", "Floating", "Terminated", "Suspended"})
        Me.Cmb_Separation.Location = New System.Drawing.Point(169, 276)
        Me.Cmb_Separation.Name = "Cmb_Separation"
        Me.Cmb_Separation.Size = New System.Drawing.Size(150, 28)
        Me.Cmb_Separation.TabIndex = 156
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(47, 280)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 18)
        Me.Label19.TabIndex = 157
        Me.Label19.Text = "Set Status:"
        '
        'Lbl_Employee_ID
        '
        Me.Lbl_Employee_ID.AutoSize = True
        Me.Lbl_Employee_ID.BackColor = System.Drawing.Color.Black
        Me.Lbl_Employee_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Employee_ID.ForeColor = System.Drawing.Color.Yellow
        Me.Lbl_Employee_ID.Location = New System.Drawing.Point(288, 47)
        Me.Lbl_Employee_ID.Name = "Lbl_Employee_ID"
        Me.Lbl_Employee_ID.Size = New System.Drawing.Size(63, 20)
        Me.Lbl_Employee_ID.TabIndex = 73
        Me.Lbl_Employee_ID.Text = "239001"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(151, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(119, 18)
        Me.Label21.TabIndex = 72
        Me.Label21.Text = "Employee ID:"
        '
        'Lbl_Employee_Name
        '
        Me.Lbl_Employee_Name.AutoSize = True
        Me.Lbl_Employee_Name.BackColor = System.Drawing.Color.Black
        Me.Lbl_Employee_Name.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Employee_Name.ForeColor = System.Drawing.Color.Yellow
        Me.Lbl_Employee_Name.Location = New System.Drawing.Point(288, 76)
        Me.Lbl_Employee_Name.Name = "Lbl_Employee_Name"
        Me.Lbl_Employee_Name.Size = New System.Drawing.Size(261, 23)
        Me.Lbl_Employee_Name.TabIndex = 71
        Me.Lbl_Employee_Name.Text = "Employee Complete Name"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Black
        Me.Label23.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(150, 76)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 23)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "Name:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1075, 41)
        Me.Panel1.TabIndex = 75
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Btn_Selected_Button)
        Me.Panel2.Controls.Add(Me.Btn_Employment_Status)
        Me.Panel2.Controls.Add(Me.Btn_Personel_Movement)
        Me.Panel2.Controls.Add(Me.Btn_Security_License)
        Me.Panel2.Controls.Add(Me.Btn_Insurance)
        Me.Panel2.Controls.Add(Me.Btn_Medical_Records)
        Me.Panel2.Controls.Add(Me.Btn_Leave_Filing)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(230, 819)
        Me.Panel2.TabIndex = 76
        '
        'Btn_Selected_Button
        '
        Me.Btn_Selected_Button.BackColor = System.Drawing.Color.Gray
        Me.Btn_Selected_Button.FlatAppearance.BorderSize = 0
        Me.Btn_Selected_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Selected_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Selected_Button.ForeColor = System.Drawing.Color.Aqua
        Me.Btn_Selected_Button.IconChar = FontAwesome.Sharp.IconChar.File
        Me.Btn_Selected_Button.IconColor = System.Drawing.Color.White
        Me.Btn_Selected_Button.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Selected_Button.IconSize = 60
        Me.Btn_Selected_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Selected_Button.Location = New System.Drawing.Point(12, 38)
        Me.Btn_Selected_Button.Name = "Btn_Selected_Button"
        Me.Btn_Selected_Button.Size = New System.Drawing.Size(202, 73)
        Me.Btn_Selected_Button.TabIndex = 42
        Me.Btn_Selected_Button.Text = "Leave Filing"
        Me.Btn_Selected_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Selected_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Selected_Button.UseVisualStyleBackColor = False
        '
        'Btn_Employment_Status
        '
        Me.Btn_Employment_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Employment_Status.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpenText
        Me.Btn_Employment_Status.IconColor = System.Drawing.Color.Green
        Me.Btn_Employment_Status.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Employment_Status.IconSize = 60
        Me.Btn_Employment_Status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Employment_Status.Location = New System.Drawing.Point(3, 698)
        Me.Btn_Employment_Status.Name = "Btn_Employment_Status"
        Me.Btn_Employment_Status.Size = New System.Drawing.Size(224, 73)
        Me.Btn_Employment_Status.TabIndex = 41
        Me.Btn_Employment_Status.Text = "Employment Status"
        Me.Btn_Employment_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Employment_Status.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Employment_Status.UseVisualStyleBackColor = True
        '
        'Btn_Personel_Movement
        '
        Me.Btn_Personel_Movement.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Personel_Movement.IconChar = FontAwesome.Sharp.IconChar.Route
        Me.Btn_Personel_Movement.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btn_Personel_Movement.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Personel_Movement.IconSize = 60
        Me.Btn_Personel_Movement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Personel_Movement.Location = New System.Drawing.Point(3, 625)
        Me.Btn_Personel_Movement.Name = "Btn_Personel_Movement"
        Me.Btn_Personel_Movement.Size = New System.Drawing.Size(224, 73)
        Me.Btn_Personel_Movement.TabIndex = 40
        Me.Btn_Personel_Movement.Text = "Personnel Movement"
        Me.Btn_Personel_Movement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Personel_Movement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Personel_Movement.UseVisualStyleBackColor = True
        '
        'Btn_Security_License
        '
        Me.Btn_Security_License.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Security_License.IconChar = FontAwesome.Sharp.IconChar.Gun
        Me.Btn_Security_License.IconColor = System.Drawing.Color.Black
        Me.Btn_Security_License.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Security_License.IconSize = 60
        Me.Btn_Security_License.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Security_License.Location = New System.Drawing.Point(3, 552)
        Me.Btn_Security_License.Name = "Btn_Security_License"
        Me.Btn_Security_License.Size = New System.Drawing.Size(224, 73)
        Me.Btn_Security_License.TabIndex = 39
        Me.Btn_Security_License.Text = "Security License"
        Me.Btn_Security_License.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Security_License.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Security_License.UseVisualStyleBackColor = True
        '
        'Btn_Insurance
        '
        Me.Btn_Insurance.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Insurance.IconChar = FontAwesome.Sharp.IconChar.FileMedicalAlt
        Me.Btn_Insurance.IconColor = System.Drawing.Color.Maroon
        Me.Btn_Insurance.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Insurance.IconSize = 60
        Me.Btn_Insurance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Insurance.Location = New System.Drawing.Point(3, 479)
        Me.Btn_Insurance.Name = "Btn_Insurance"
        Me.Btn_Insurance.Size = New System.Drawing.Size(224, 73)
        Me.Btn_Insurance.TabIndex = 38
        Me.Btn_Insurance.Text = "Insurance"
        Me.Btn_Insurance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Insurance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Insurance.UseVisualStyleBackColor = True
        '
        'Btn_Medical_Records
        '
        Me.Btn_Medical_Records.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Btn_Medical_Records.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Medical_Records.IconChar = FontAwesome.Sharp.IconChar.Medkit
        Me.Btn_Medical_Records.IconColor = System.Drawing.Color.Green
        Me.Btn_Medical_Records.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Medical_Records.IconSize = 60
        Me.Btn_Medical_Records.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Medical_Records.Location = New System.Drawing.Point(3, 406)
        Me.Btn_Medical_Records.Name = "Btn_Medical_Records"
        Me.Btn_Medical_Records.Size = New System.Drawing.Size(224, 73)
        Me.Btn_Medical_Records.TabIndex = 37
        Me.Btn_Medical_Records.Text = "Medical Records"
        Me.Btn_Medical_Records.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Medical_Records.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Medical_Records.UseVisualStyleBackColor = True
        '
        'Btn_Leave_Filing
        '
        Me.Btn_Leave_Filing.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Leave_Filing.IconChar = FontAwesome.Sharp.IconChar.File
        Me.Btn_Leave_Filing.IconColor = System.Drawing.Color.Black
        Me.Btn_Leave_Filing.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Leave_Filing.IconSize = 60
        Me.Btn_Leave_Filing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Leave_Filing.Location = New System.Drawing.Point(3, 333)
        Me.Btn_Leave_Filing.Name = "Btn_Leave_Filing"
        Me.Btn_Leave_Filing.Size = New System.Drawing.Size(224, 73)
        Me.Btn_Leave_Filing.TabIndex = 36
        Me.Btn_Leave_Filing.Text = "Leave Filing"
        Me.Btn_Leave_Filing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Leave_Filing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Leave_Filing.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Controls.Add(Me.Pic_Employee_Photo)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.Lbl_Employee_Name)
        Me.Panel3.Controls.Add(Me.Lbl_Employee_ID)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(230, 41)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(845, 99)
        Me.Panel3.TabIndex = 77
        '
        'Pic_Employee_Photo
        '
        Me.Pic_Employee_Photo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic_Employee_Photo.Image = Global.DMSA_System.My.Resources.Resources.DMSA_Logo
        Me.Pic_Employee_Photo.Location = New System.Drawing.Point(18, 10)
        Me.Pic_Employee_Photo.Name = "Pic_Employee_Photo"
        Me.Pic_Employee_Photo.Size = New System.Drawing.Size(119, 113)
        Me.Pic_Employee_Photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Employee_Photo.TabIndex = 74
        Me.Pic_Employee_Photo.TabStop = False
        '
        'FRM_EMP_UPDATE_REC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1075, 860)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Tab_Employee_Transactions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FRM_EMP_UPDATE_REC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Records Management"
        Me.Tab_Employee_Transactions.ResumeLayout(False)
        Me.Tab_Leave_Filing.ResumeLayout(False)
        Me.Grp_Leave_Info.ResumeLayout(False)
        Me.Grp_Leave_Info.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_Medical_Info.ResumeLayout(False)
        Me.Grp_Medical_Info.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_Insurance_Info.ResumeLayout(False)
        Me.Grp_Insurance_Info.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.Grp_License.ResumeLayout(False)
        Me.Grp_License.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Client.ResumeLayout(False)
        Me.Grp_Client_Info.ResumeLayout(False)
        Me.Grp_Client_Info.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Pic_Employee_Photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab_Employee_Transactions As TabControl
    Friend WithEvents Tab_Leave_Filing As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Btn_Leave_Delete As Button
    Friend WithEvents Btn_Leave_Edit As Button
    Friend WithEvents Btn_Leave_New As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents LV_Leave As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Col_Leave_Type As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Btn_Medical_Delete As Button
    Friend WithEvents Btn_Medical_Edit As Button
    Friend WithEvents Cmb_Drug_Test As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Medical_Remarks As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Chk_Medical_Findings As CheckBox
    Friend WithEvents DP_Medical_Date As DateTimePicker
    Friend WithEvents Btn_Medical_New As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Cmb_Medical_Type As ComboBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_Medical_Date As TextBox
    Friend WithEvents LV_Medical_List As ListView
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents Col_Med_Type As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents DP_Insurance_DateEnd As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt_Insurance_DateEnd As TextBox
    Friend WithEvents Btn_Insurance_Delete As Button
    Friend WithEvents Btn_Insurance_Edit As Button
    Friend WithEvents DP_Insurance_DateStart As DateTimePicker
    Friend WithEvents Btn_Insurance_New As Button
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Txt_Insurance_DateStart As TextBox
    Friend WithEvents LV_Insurance_List As ListView
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents Col_Insu_Company As ColumnHeader
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Btn_License_Delete As Button
    Friend WithEvents Btn_License_Edit As Button
    Friend WithEvents Btn_License_NEW As Button
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents LV_License_Record As ListView
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents Col_License_Number As ColumnHeader
    Friend WithEvents Col_type As ColumnHeader
    Friend WithEvents Col_Exp As ColumnHeader
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Txt_StatusChange_Date As TextBox
    Friend WithEvents DP_Sepa_day As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Txt_ChangeStatus_Remark As TextBox
    Friend WithEvents Cmb_Separation As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Lbl_Employee_ID As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Lbl_Employee_Name As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Grp_Leave_Info As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_Leave_Reason As TextBox
    Friend WithEvents Cmb_Notification As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Cmb_LeaveType As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Cmb_Leave_Status As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DP_Leave_To As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Leave_DateTo As TextBox
    Friend WithEvents DP_Leave_From As DateTimePicker
    Friend WithEvents Label93 As Label
    Friend WithEvents Txt_Leave_DateFrom As TextBox
    Friend WithEvents Tab_Client As TabPage
    Friend WithEvents Lbl_ClientName As Label
    Friend WithEvents Txt_ClientID As TextBox
    Friend WithEvents Btn_ShowClientList As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents LblClient_Address As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Btn_Client_Change As Button
    Friend WithEvents LV_Client_History As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents Col_Client_StartDate As ColumnHeader
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents Btn_Separation_Update As Button
    Friend WithEvents Col_Reference_ID As ColumnHeader
    Friend WithEvents Grp_License As GroupBox
    Friend WithEvents Btn_License_AttachFile As Button
    Friend WithEvents Txt_License_Attachment As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Cmb_LicenseType As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Txt_License_Number As TextBox
    Friend WithEvents DP_License_Expiry As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents Txt_License_Expiry As TextBox
    Friend WithEvents Col_SEC_Ref_ID As ColumnHeader
    Friend WithEvents Btn_Client_Delete As Button
    Friend WithEvents Grp_Client_Info As GroupBox
    Friend WithEvents Txt_Client_Start_Date As TextBox
    Friend WithEvents DP_Client_Start_Date As DateTimePicker
    Friend WithEvents Lbl_Client_Start_Date As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Txt_selected_Client_ID As TextBox
    Friend WithEvents Col_Client_Ref_ID As ColumnHeader
    Friend WithEvents Lbl_Client_Ref_ID As Label
    Friend WithEvents Col_Medical_Ref_ID As ColumnHeader
    Friend WithEvents Grp_Medical_Info As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Cmb_Hospital As ComboBox
    Friend WithEvents Lbl_Medical_Ref_ID As Label
    Friend WithEvents Col_Insurance_RefID As ColumnHeader
    Friend WithEvents Grp_Insurance_Info As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_Insurance_Policy As TextBox
    Friend WithEvents Txt_Medical_Exp_Date As TextBox
    Friend WithEvents DP_Medical_Exp_Date As DateTimePicker
    Friend WithEvents Label26 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Cmb_Insurance_CompName As ComboBox
    Friend WithEvents Col_PolicyNum As ColumnHeader
    Friend WithEvents Txt_Client_End_Date As TextBox
    Friend WithEvents DP_Client_End_Date As DateTimePicker
    Friend WithEvents Label27 As Label
    Friend WithEvents Col_Client_EndDate As ColumnHeader
    Friend WithEvents Btn_Client_Edit As Button
    Friend WithEvents Chk_UptoPresent As CheckBox
    Friend WithEvents Col_Client_Address As ColumnHeader
    Friend WithEvents Btn_Client_Add As Button
    Friend WithEvents Lbl_License_View_Attachment As Label
    Friend WithEvents LV_Status_History As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Col_DeclaredStatus As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Btn_Employment_Status As IconButton
    Friend WithEvents Btn_Personel_Movement As IconButton
    Friend WithEvents Btn_Security_License As IconButton
    Friend WithEvents Btn_Insurance As IconButton
    Friend WithEvents Btn_Medical_Records As IconButton
    Friend WithEvents Btn_Leave_Filing As IconButton
    Friend WithEvents Btn_Selected_Button As IconButton
    Friend WithEvents Pic_Employee_Photo As PictureBox
End Class
