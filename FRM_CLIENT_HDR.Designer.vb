<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_CLIENT_HDR
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
        Me.Btn_Show = New System.Windows.Forms.Button()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LV_Main_Client_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_MainClient_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Tab_Client_Info = New System.Windows.Forms.TabControl()
        Me.Tab_MainClient = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_ClientType = New System.Windows.Forms.ComboBox()
        Me.Lbl_Main_Client_Status = New System.Windows.Forms.Label()
        Me.Btn_Deactivate_Main_Client = New FontAwesome.Sharp.IconButton()
        Me.Btn_Activate_Main_Client = New FontAwesome.Sharp.IconButton()
        Me.Btn_Edit_Main_Client = New FontAwesome.Sharp.IconButton()
        Me.Btn_New_Main_Client = New FontAwesome.Sharp.IconButton()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Cmb_MainClientName = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Tab_SubClient = New System.Windows.Forms.TabPage()
        Me.Btn_Deactivate_Sub_Client = New FontAwesome.Sharp.IconButton()
        Me.Btn_Activate_Sub_Client = New FontAwesome.Sharp.IconButton()
        Me.Btn_New_Sub_Client = New FontAwesome.Sharp.IconButton()
        Me.Btn_Edit_Sub_Client = New FontAwesome.Sharp.IconButton()
        Me.Tab_Info_Deduction = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grp_Client_Info = New System.Windows.Forms.GroupBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Txt_Contact_CPNumber = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_Contact_Email = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Contact_Person = New System.Windows.Forms.TextBox()
        Me.Txt_Sub_Client_ID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_SchedType = New System.Windows.Forms.ComboBox()
        Me.Btn_ShowClientList = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_SubClientName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Sub_Client_Address = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Grp_Contract_Info = New System.Windows.Forms.GroupBox()
        Me.Btn_View_Contract = New FontAwesome.Sharp.IconButton()
        Me.Lbl_Attachment_Path = New System.Windows.Forms.Label()
        Me.Btn_Attachment_Upload = New FontAwesome.Sharp.IconButton()
        Me.Btn_Remove_Contract = New FontAwesome.Sharp.IconButton()
        Me.Lbl_Sub_Client_Name_Contract = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.LV_Contract_Attachments = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Contract_Path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Contract_iRefID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Txt_Contract_Remarks = New System.Windows.Forms.TextBox()
        Me.DP_Contract_End_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtContract_End_Date = New System.Windows.Forms.TextBox()
        Me.DP_Contract_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtContract_Start_Date = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.IconButton8 = New FontAwesome.Sharp.IconButton()
        Me.IconButton9 = New FontAwesome.Sharp.IconButton()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.IconButton6 = New FontAwesome.Sharp.IconButton()
        Me.Lbl_Sub_Client_Name_Termination = New System.Windows.Forms.Label()
        Me.Lbl_Sub_Client_ID_Termination = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.LV_Sub_Client_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_SubClient_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_SubClient_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cmb_MainClient_Status = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Client_Info.SuspendLayout()
        Me.Tab_MainClient.SuspendLayout()
        Me.Tab_SubClient.SuspendLayout()
        Me.Tab_Info_Deduction.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Grp_Client_Info.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Grp_Contract_Info.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Show
        '
        Me.Btn_Show.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Show.Location = New System.Drawing.Point(539, 57)
        Me.Btn_Show.Name = "Btn_Show"
        Me.Btn_Show.Size = New System.Drawing.Size(122, 30)
        Me.Btn_Show.TabIndex = 76
        Me.Btn_Show.Text = "Show"
        Me.Btn_Show.UseVisualStyleBackColor = True
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(255, 56)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(278, 31)
        Me.TxtSearch.TabIndex = 75
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Aqua
        Me.Label2.Location = New System.Drawing.Point(16, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 23)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Filter:"
        '
        'LV_Main_Client_List
        '
        Me.LV_Main_Client_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Main_Client_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.Col_Client_Name, Me.Col_Client_Status, Me.Col_MainClient_ID})
        Me.LV_Main_Client_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Main_Client_List.FullRowSelect = True
        Me.LV_Main_Client_List.GridLines = True
        Me.LV_Main_Client_List.HideSelection = False
        Me.LV_Main_Client_List.Location = New System.Drawing.Point(24, 97)
        Me.LV_Main_Client_List.Name = "LV_Main_Client_List"
        Me.LV_Main_Client_List.Size = New System.Drawing.Size(890, 455)
        Me.LV_Main_Client_List.TabIndex = 69
        Me.LV_Main_Client_List.UseCompatibleStateImageBehavior = False
        Me.LV_Main_Client_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Item"
        '
        'Col_Client_Name
        '
        Me.Col_Client_Name.Text = "Main Client Name"
        Me.Col_Client_Name.Width = 680
        '
        'Col_Client_Status
        '
        Me.Col_Client_Status.Text = "Status"
        Me.Col_Client_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Client_Status.Width = 150
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.OliveDrab
        Me.PictureBox2.Location = New System.Drawing.Point(20, 801)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1504, 50)
        Me.PictureBox2.TabIndex = 120
        Me.PictureBox2.TabStop = False
        '
        'Tab_Client_Info
        '
        Me.Tab_Client_Info.Controls.Add(Me.Tab_MainClient)
        Me.Tab_Client_Info.Controls.Add(Me.Tab_SubClient)
        Me.Tab_Client_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_Client_Info.Location = New System.Drawing.Point(916, 97)
        Me.Tab_Client_Info.Name = "Tab_Client_Info"
        Me.Tab_Client_Info.SelectedIndex = 0
        Me.Tab_Client_Info.Size = New System.Drawing.Size(609, 691)
        Me.Tab_Client_Info.TabIndex = 126
        '
        'Tab_MainClient
        '
        Me.Tab_MainClient.BackColor = System.Drawing.Color.Black
        Me.Tab_MainClient.Controls.Add(Me.Label6)
        Me.Tab_MainClient.Controls.Add(Me.Cmb_ClientType)
        Me.Tab_MainClient.Controls.Add(Me.Lbl_Main_Client_Status)
        Me.Tab_MainClient.Controls.Add(Me.Btn_Deactivate_Main_Client)
        Me.Tab_MainClient.Controls.Add(Me.Btn_Activate_Main_Client)
        Me.Tab_MainClient.Controls.Add(Me.Btn_Edit_Main_Client)
        Me.Tab_MainClient.Controls.Add(Me.Btn_New_Main_Client)
        Me.Tab_MainClient.Controls.Add(Me.Label27)
        Me.Tab_MainClient.Controls.Add(Me.Cmb_MainClientName)
        Me.Tab_MainClient.Controls.Add(Me.Label20)
        Me.Tab_MainClient.Location = New System.Drawing.Point(4, 33)
        Me.Tab_MainClient.Name = "Tab_MainClient"
        Me.Tab_MainClient.Size = New System.Drawing.Size(601, 654)
        Me.Tab_MainClient.TabIndex = 3
        Me.Tab_MainClient.Text = "   Main Client   "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Aqua
        Me.Label6.Location = New System.Drawing.Point(35, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 18)
        Me.Label6.TabIndex = 244
        Me.Label6.Text = "Client Type:"
        '
        'Cmb_ClientType
        '
        Me.Cmb_ClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ClientType.Enabled = False
        Me.Cmb_ClientType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_ClientType.FormattingEnabled = True
        Me.Cmb_ClientType.Items.AddRange(New Object() {"Government", "Private"})
        Me.Cmb_ClientType.Location = New System.Drawing.Point(38, 240)
        Me.Cmb_ClientType.Name = "Cmb_ClientType"
        Me.Cmb_ClientType.Size = New System.Drawing.Size(148, 28)
        Me.Cmb_ClientType.TabIndex = 243
        '
        'Lbl_Main_Client_Status
        '
        Me.Lbl_Main_Client_Status.AutoSize = True
        Me.Lbl_Main_Client_Status.BackColor = System.Drawing.Color.Black
        Me.Lbl_Main_Client_Status.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Main_Client_Status.ForeColor = System.Drawing.Color.Lime
        Me.Lbl_Main_Client_Status.Location = New System.Drawing.Point(110, 71)
        Me.Lbl_Main_Client_Status.Name = "Lbl_Main_Client_Status"
        Me.Lbl_Main_Client_Status.Size = New System.Drawing.Size(58, 18)
        Me.Lbl_Main_Client_Status.TabIndex = 242
        Me.Lbl_Main_Client_Status.Text = "Active"
        '
        'Btn_Deactivate_Main_Client
        '
        Me.Btn_Deactivate_Main_Client.Enabled = False
        Me.Btn_Deactivate_Main_Client.IconChar = FontAwesome.Sharp.IconChar.Lock
        Me.Btn_Deactivate_Main_Client.IconColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_Deactivate_Main_Client.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Deactivate_Main_Client.IconSize = 40
        Me.Btn_Deactivate_Main_Client.Location = New System.Drawing.Point(400, 537)
        Me.Btn_Deactivate_Main_Client.Name = "Btn_Deactivate_Main_Client"
        Me.Btn_Deactivate_Main_Client.Size = New System.Drawing.Size(119, 94)
        Me.Btn_Deactivate_Main_Client.TabIndex = 145
        Me.Btn_Deactivate_Main_Client.Text = "Deactivate"
        Me.Btn_Deactivate_Main_Client.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Deactivate_Main_Client.UseVisualStyleBackColor = True
        '
        'Btn_Activate_Main_Client
        '
        Me.Btn_Activate_Main_Client.Enabled = False
        Me.Btn_Activate_Main_Client.IconChar = FontAwesome.Sharp.IconChar.LockOpen
        Me.Btn_Activate_Main_Client.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_Activate_Main_Client.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Activate_Main_Client.Location = New System.Drawing.Point(275, 537)
        Me.Btn_Activate_Main_Client.Name = "Btn_Activate_Main_Client"
        Me.Btn_Activate_Main_Client.Size = New System.Drawing.Size(119, 94)
        Me.Btn_Activate_Main_Client.TabIndex = 144
        Me.Btn_Activate_Main_Client.Text = "Activate"
        Me.Btn_Activate_Main_Client.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Activate_Main_Client.UseVisualStyleBackColor = True
        '
        'Btn_Edit_Main_Client
        '
        Me.Btn_Edit_Main_Client.Enabled = False
        Me.Btn_Edit_Main_Client.IconChar = FontAwesome.Sharp.IconChar.Pen
        Me.Btn_Edit_Main_Client.IconColor = System.Drawing.Color.Blue
        Me.Btn_Edit_Main_Client.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Edit_Main_Client.IconSize = 40
        Me.Btn_Edit_Main_Client.Location = New System.Drawing.Point(150, 537)
        Me.Btn_Edit_Main_Client.Name = "Btn_Edit_Main_Client"
        Me.Btn_Edit_Main_Client.Size = New System.Drawing.Size(119, 94)
        Me.Btn_Edit_Main_Client.TabIndex = 143
        Me.Btn_Edit_Main_Client.Text = "Edit"
        Me.Btn_Edit_Main_Client.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Edit_Main_Client.UseVisualStyleBackColor = True
        '
        'Btn_New_Main_Client
        '
        Me.Btn_New_Main_Client.IconChar = FontAwesome.Sharp.IconChar.PlusCircle
        Me.Btn_New_Main_Client.IconColor = System.Drawing.Color.Green
        Me.Btn_New_Main_Client.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_New_Main_Client.Location = New System.Drawing.Point(25, 537)
        Me.Btn_New_Main_Client.Name = "Btn_New_Main_Client"
        Me.Btn_New_Main_Client.Size = New System.Drawing.Size(119, 94)
        Me.Btn_New_Main_Client.TabIndex = 142
        Me.Btn_New_Main_Client.Text = "New"
        Me.Btn_New_Main_Client.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_New_Main_Client.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Black
        Me.Label27.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Aqua
        Me.Label27.Location = New System.Drawing.Point(36, 71)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 18)
        Me.Label27.TabIndex = 141
        Me.Label27.Text = "Status:"
        '
        'Cmb_MainClientName
        '
        Me.Cmb_MainClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_MainClientName.FormattingEnabled = True
        Me.Cmb_MainClientName.Items.AddRange(New Object() {"Main Client"})
        Me.Cmb_MainClientName.Location = New System.Drawing.Point(38, 152)
        Me.Cmb_MainClientName.Name = "Cmb_MainClientName"
        Me.Cmb_MainClientName.Size = New System.Drawing.Size(533, 28)
        Me.Cmb_MainClientName.TabIndex = 138
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Black
        Me.Label20.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Cyan
        Me.Label20.Location = New System.Drawing.Point(35, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(160, 18)
        Me.Label20.TabIndex = 139
        Me.Label20.Text = "Main Client Name:"
        '
        'Tab_SubClient
        '
        Me.Tab_SubClient.BackColor = System.Drawing.Color.Black
        Me.Tab_SubClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Tab_SubClient.Controls.Add(Me.Btn_Deactivate_Sub_Client)
        Me.Tab_SubClient.Controls.Add(Me.Btn_Activate_Sub_Client)
        Me.Tab_SubClient.Controls.Add(Me.Btn_New_Sub_Client)
        Me.Tab_SubClient.Controls.Add(Me.Btn_Edit_Sub_Client)
        Me.Tab_SubClient.Controls.Add(Me.Tab_Info_Deduction)
        Me.Tab_SubClient.Location = New System.Drawing.Point(4, 33)
        Me.Tab_SubClient.Name = "Tab_SubClient"
        Me.Tab_SubClient.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_SubClient.Size = New System.Drawing.Size(601, 654)
        Me.Tab_SubClient.TabIndex = 0
        Me.Tab_SubClient.Text = "   Sub Client   "
        '
        'Btn_Deactivate_Sub_Client
        '
        Me.Btn_Deactivate_Sub_Client.Enabled = False
        Me.Btn_Deactivate_Sub_Client.IconChar = FontAwesome.Sharp.IconChar.Lock
        Me.Btn_Deactivate_Sub_Client.IconColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_Deactivate_Sub_Client.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Deactivate_Sub_Client.IconSize = 40
        Me.Btn_Deactivate_Sub_Client.Location = New System.Drawing.Point(402, 536)
        Me.Btn_Deactivate_Sub_Client.Name = "Btn_Deactivate_Sub_Client"
        Me.Btn_Deactivate_Sub_Client.Size = New System.Drawing.Size(119, 94)
        Me.Btn_Deactivate_Sub_Client.TabIndex = 149
        Me.Btn_Deactivate_Sub_Client.Text = "Deactivate"
        Me.Btn_Deactivate_Sub_Client.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Deactivate_Sub_Client.UseVisualStyleBackColor = True
        '
        'Btn_Activate_Sub_Client
        '
        Me.Btn_Activate_Sub_Client.Enabled = False
        Me.Btn_Activate_Sub_Client.IconChar = FontAwesome.Sharp.IconChar.Cancel
        Me.Btn_Activate_Sub_Client.IconColor = System.Drawing.Color.Lime
        Me.Btn_Activate_Sub_Client.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Activate_Sub_Client.Location = New System.Drawing.Point(277, 536)
        Me.Btn_Activate_Sub_Client.Name = "Btn_Activate_Sub_Client"
        Me.Btn_Activate_Sub_Client.Size = New System.Drawing.Size(119, 94)
        Me.Btn_Activate_Sub_Client.TabIndex = 148
        Me.Btn_Activate_Sub_Client.Text = "Activate"
        Me.Btn_Activate_Sub_Client.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Activate_Sub_Client.UseVisualStyleBackColor = True
        '
        'Btn_New_Sub_Client
        '
        Me.Btn_New_Sub_Client.Enabled = False
        Me.Btn_New_Sub_Client.IconChar = FontAwesome.Sharp.IconChar.PlusCircle
        Me.Btn_New_Sub_Client.IconColor = System.Drawing.Color.Green
        Me.Btn_New_Sub_Client.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_New_Sub_Client.Location = New System.Drawing.Point(27, 536)
        Me.Btn_New_Sub_Client.Name = "Btn_New_Sub_Client"
        Me.Btn_New_Sub_Client.Size = New System.Drawing.Size(119, 94)
        Me.Btn_New_Sub_Client.TabIndex = 146
        Me.Btn_New_Sub_Client.Text = "New"
        Me.Btn_New_Sub_Client.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_New_Sub_Client.UseVisualStyleBackColor = True
        '
        'Btn_Edit_Sub_Client
        '
        Me.Btn_Edit_Sub_Client.Enabled = False
        Me.Btn_Edit_Sub_Client.IconChar = FontAwesome.Sharp.IconChar.Pen
        Me.Btn_Edit_Sub_Client.IconColor = System.Drawing.Color.Blue
        Me.Btn_Edit_Sub_Client.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Edit_Sub_Client.IconSize = 40
        Me.Btn_Edit_Sub_Client.Location = New System.Drawing.Point(152, 536)
        Me.Btn_Edit_Sub_Client.Name = "Btn_Edit_Sub_Client"
        Me.Btn_Edit_Sub_Client.Size = New System.Drawing.Size(119, 94)
        Me.Btn_Edit_Sub_Client.TabIndex = 147
        Me.Btn_Edit_Sub_Client.Text = "Edit"
        Me.Btn_Edit_Sub_Client.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Edit_Sub_Client.UseVisualStyleBackColor = True
        '
        'Tab_Info_Deduction
        '
        Me.Tab_Info_Deduction.Controls.Add(Me.TabPage1)
        Me.Tab_Info_Deduction.Controls.Add(Me.TabPage3)
        Me.Tab_Info_Deduction.Controls.Add(Me.TabPage4)
        Me.Tab_Info_Deduction.Location = New System.Drawing.Point(11, 6)
        Me.Tab_Info_Deduction.Name = "Tab_Info_Deduction"
        Me.Tab_Info_Deduction.SelectedIndex = 0
        Me.Tab_Info_Deduction.Size = New System.Drawing.Size(585, 514)
        Me.Tab_Info_Deduction.TabIndex = 244
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.Grp_Client_Info)
        Me.TabPage1.Location = New System.Drawing.Point(4, 33)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(577, 477)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "   Information   "
        '
        'Grp_Client_Info
        '
        Me.Grp_Client_Info.BackColor = System.Drawing.Color.Black
        Me.Grp_Client_Info.Controls.Add(Me.Label50)
        Me.Grp_Client_Info.Controls.Add(Me.Label19)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_Contact_CPNumber)
        Me.Grp_Client_Info.Controls.Add(Me.Label9)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_Contact_Email)
        Me.Grp_Client_Info.Controls.Add(Me.Label8)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_Contact_Person)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_Sub_Client_ID)
        Me.Grp_Client_Info.Controls.Add(Me.Label1)
        Me.Grp_Client_Info.Controls.Add(Me.Cmb_SchedType)
        Me.Grp_Client_Info.Controls.Add(Me.Btn_ShowClientList)
        Me.Grp_Client_Info.Controls.Add(Me.Label3)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_SubClientName)
        Me.Grp_Client_Info.Controls.Add(Me.Label4)
        Me.Grp_Client_Info.Controls.Add(Me.Label5)
        Me.Grp_Client_Info.Controls.Add(Me.Txt_Sub_Client_Address)
        Me.Grp_Client_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Client_Info.ForeColor = System.Drawing.Color.Yellow
        Me.Grp_Client_Info.Location = New System.Drawing.Point(6, 77)
        Me.Grp_Client_Info.Name = "Grp_Client_Info"
        Me.Grp_Client_Info.Size = New System.Drawing.Size(568, 394)
        Me.Grp_Client_Info.TabIndex = 126
        Me.Grp_Client_Info.TabStop = False
        Me.Grp_Client_Info.Text = "General Information"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Lime
        Me.Label50.Location = New System.Drawing.Point(182, 303)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(36, 20)
        Me.Label50.TabIndex = 136
        Me.Label50.Text = "+63"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Black
        Me.Label19.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Aqua
        Me.Label19.Location = New System.Drawing.Point(16, 303)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(97, 18)
        Me.Label19.TabIndex = 114
        Me.Label19.Text = "Contact #:"
        '
        'Txt_Contact_CPNumber
        '
        Me.Txt_Contact_CPNumber.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_CPNumber.Location = New System.Drawing.Point(224, 300)
        Me.Txt_Contact_CPNumber.Name = "Txt_Contact_CPNumber"
        Me.Txt_Contact_CPNumber.Size = New System.Drawing.Size(165, 27)
        Me.Txt_Contact_CPNumber.TabIndex = 115
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Black
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Aqua
        Me.Label9.Location = New System.Drawing.Point(16, 349)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(131, 18)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = "Email Address:"
        '
        'Txt_Contact_Email
        '
        Me.Txt_Contact_Email.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_Email.Location = New System.Drawing.Point(182, 346)
        Me.Txt_Contact_Email.Name = "Txt_Contact_Email"
        Me.Txt_Contact_Email.Size = New System.Drawing.Size(372, 27)
        Me.Txt_Contact_Email.TabIndex = 113
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Aqua
        Me.Label8.Location = New System.Drawing.Point(16, 261)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 18)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "Contact Person:"
        '
        'Txt_Contact_Person
        '
        Me.Txt_Contact_Person.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_Person.Location = New System.Drawing.Point(182, 258)
        Me.Txt_Contact_Person.Name = "Txt_Contact_Person"
        Me.Txt_Contact_Person.Size = New System.Drawing.Size(281, 27)
        Me.Txt_Contact_Person.TabIndex = 111
        '
        'Txt_Sub_Client_ID
        '
        Me.Txt_Sub_Client_ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Txt_Sub_Client_ID.Enabled = False
        Me.Txt_Sub_Client_ID.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sub_Client_ID.Location = New System.Drawing.Point(182, 36)
        Me.Txt_Sub_Client_ID.Name = "Txt_Sub_Client_ID"
        Me.Txt_Sub_Client_ID.Size = New System.Drawing.Size(148, 27)
        Me.Txt_Sub_Client_ID.TabIndex = 101
        Me.Txt_Sub_Client_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Aqua
        Me.Label1.Location = New System.Drawing.Point(16, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 18)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Sub Client ID:"
        '
        'Cmb_SchedType
        '
        Me.Cmb_SchedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_SchedType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_SchedType.FormattingEnabled = True
        Me.Cmb_SchedType.Items.AddRange(New Object() {"2SHIFTS", "TRI_SHIFT", "TIME_SPECIFIC"})
        Me.Cmb_SchedType.Location = New System.Drawing.Point(182, 167)
        Me.Cmb_SchedType.Name = "Cmb_SchedType"
        Me.Cmb_SchedType.Size = New System.Drawing.Size(148, 28)
        Me.Cmb_SchedType.TabIndex = 99
        '
        'Btn_ShowClientList
        '
        Me.Btn_ShowClientList.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_ShowClientList.Enabled = False
        Me.Btn_ShowClientList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_ShowClientList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ShowClientList.Location = New System.Drawing.Point(336, 35)
        Me.Btn_ShowClientList.Name = "Btn_ShowClientList"
        Me.Btn_ShowClientList.Size = New System.Drawing.Size(53, 27)
        Me.Btn_ShowClientList.TabIndex = 102
        Me.Btn_ShowClientList.Text = "..."
        Me.Btn_ShowClientList.UseVisualStyleBackColor = False
        Me.Btn_ShowClientList.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Aqua
        Me.Label3.Location = New System.Drawing.Point(16, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 18)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Sub Client Name:"
        '
        'Txt_SubClientName
        '
        Me.Txt_SubClientName.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SubClientName.Location = New System.Drawing.Point(182, 79)
        Me.Txt_SubClientName.Name = "Txt_SubClientName"
        Me.Txt_SubClientName.Size = New System.Drawing.Size(372, 27)
        Me.Txt_SubClientName.TabIndex = 104
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Aqua
        Me.Label4.Location = New System.Drawing.Point(16, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 18)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Client Address:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Aqua
        Me.Label5.Location = New System.Drawing.Point(16, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 18)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "Sched Type:"
        '
        'Txt_Sub_Client_Address
        '
        Me.Txt_Sub_Client_Address.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sub_Client_Address.Location = New System.Drawing.Point(182, 121)
        Me.Txt_Sub_Client_Address.Name = "Txt_Sub_Client_Address"
        Me.Txt_Sub_Client_Address.Size = New System.Drawing.Size(372, 27)
        Me.Txt_Sub_Client_Address.TabIndex = 106
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Black
        Me.TabPage3.Controls.Add(Me.Grp_Contract_Info)
        Me.TabPage3.Location = New System.Drawing.Point(4, 33)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(577, 477)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "   Contract   "
        '
        'Grp_Contract_Info
        '
        Me.Grp_Contract_Info.Controls.Add(Me.Btn_View_Contract)
        Me.Grp_Contract_Info.Controls.Add(Me.Lbl_Attachment_Path)
        Me.Grp_Contract_Info.Controls.Add(Me.Btn_Attachment_Upload)
        Me.Grp_Contract_Info.Controls.Add(Me.Btn_Remove_Contract)
        Me.Grp_Contract_Info.Controls.Add(Me.Lbl_Sub_Client_Name_Contract)
        Me.Grp_Contract_Info.Controls.Add(Me.Label25)
        Me.Grp_Contract_Info.Controls.Add(Me.LV_Contract_Attachments)
        Me.Grp_Contract_Info.Controls.Add(Me.Label24)
        Me.Grp_Contract_Info.Controls.Add(Me.Txt_Contract_Remarks)
        Me.Grp_Contract_Info.Controls.Add(Me.DP_Contract_End_Date)
        Me.Grp_Contract_Info.Controls.Add(Me.Label23)
        Me.Grp_Contract_Info.Controls.Add(Me.TxtContract_End_Date)
        Me.Grp_Contract_Info.Controls.Add(Me.DP_Contract_Start_Date)
        Me.Grp_Contract_Info.Controls.Add(Me.Label22)
        Me.Grp_Contract_Info.Controls.Add(Me.TxtContract_Start_Date)
        Me.Grp_Contract_Info.ForeColor = System.Drawing.Color.Yellow
        Me.Grp_Contract_Info.Location = New System.Drawing.Point(4, 8)
        Me.Grp_Contract_Info.Name = "Grp_Contract_Info"
        Me.Grp_Contract_Info.Size = New System.Drawing.Size(570, 463)
        Me.Grp_Contract_Info.TabIndex = 268
        Me.Grp_Contract_Info.TabStop = False
        Me.Grp_Contract_Info.Text = "Contract Info"
        '
        'Btn_View_Contract
        '
        Me.Btn_View_Contract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_View_Contract.ForeColor = System.Drawing.Color.Black
        Me.Btn_View_Contract.IconChar = FontAwesome.Sharp.IconChar.Eye
        Me.Btn_View_Contract.IconColor = System.Drawing.Color.Green
        Me.Btn_View_Contract.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_View_Contract.IconSize = 28
        Me.Btn_View_Contract.Location = New System.Drawing.Point(311, 414)
        Me.Btn_View_Contract.Name = "Btn_View_Contract"
        Me.Btn_View_Contract.Size = New System.Drawing.Size(115, 35)
        Me.Btn_View_Contract.TabIndex = 282
        Me.Btn_View_Contract.Text = "View"
        Me.Btn_View_Contract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_View_Contract.UseVisualStyleBackColor = True
        '
        'Lbl_Attachment_Path
        '
        Me.Lbl_Attachment_Path.AutoSize = True
        Me.Lbl_Attachment_Path.BackColor = System.Drawing.Color.Black
        Me.Lbl_Attachment_Path.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Attachment_Path.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Lbl_Attachment_Path.Location = New System.Drawing.Point(23, 230)
        Me.Lbl_Attachment_Path.Name = "Lbl_Attachment_Path"
        Me.Lbl_Attachment_Path.Size = New System.Drawing.Size(45, 18)
        Me.Lbl_Attachment_Path.TabIndex = 281
        Me.Lbl_Attachment_Path.Text = "Path"
        '
        'Btn_Attachment_Upload
        '
        Me.Btn_Attachment_Upload.Enabled = False
        Me.Btn_Attachment_Upload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Attachment_Upload.ForeColor = System.Drawing.Color.Black
        Me.Btn_Attachment_Upload.IconChar = FontAwesome.Sharp.IconChar.UpRightFromSquare
        Me.Btn_Attachment_Upload.IconColor = System.Drawing.Color.Green
        Me.Btn_Attachment_Upload.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Attachment_Upload.IconSize = 22
        Me.Btn_Attachment_Upload.Location = New System.Drawing.Point(432, 257)
        Me.Btn_Attachment_Upload.Name = "Btn_Attachment_Upload"
        Me.Btn_Attachment_Upload.Size = New System.Drawing.Size(115, 35)
        Me.Btn_Attachment_Upload.TabIndex = 280
        Me.Btn_Attachment_Upload.Text = "Upload"
        Me.Btn_Attachment_Upload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Attachment_Upload.UseVisualStyleBackColor = True
        '
        'Btn_Remove_Contract
        '
        Me.Btn_Remove_Contract.Enabled = False
        Me.Btn_Remove_Contract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Remove_Contract.ForeColor = System.Drawing.Color.Black
        Me.Btn_Remove_Contract.IconChar = FontAwesome.Sharp.IconChar.Xmark
        Me.Btn_Remove_Contract.IconColor = System.Drawing.Color.Red
        Me.Btn_Remove_Contract.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Remove_Contract.IconSize = 22
        Me.Btn_Remove_Contract.Location = New System.Drawing.Point(432, 414)
        Me.Btn_Remove_Contract.Name = "Btn_Remove_Contract"
        Me.Btn_Remove_Contract.Size = New System.Drawing.Size(115, 35)
        Me.Btn_Remove_Contract.TabIndex = 279
        Me.Btn_Remove_Contract.Text = "Remove"
        Me.Btn_Remove_Contract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Remove_Contract.UseVisualStyleBackColor = True
        '
        'Lbl_Sub_Client_Name_Contract
        '
        Me.Lbl_Sub_Client_Name_Contract.AutoSize = True
        Me.Lbl_Sub_Client_Name_Contract.BackColor = System.Drawing.Color.Black
        Me.Lbl_Sub_Client_Name_Contract.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sub_Client_Name_Contract.ForeColor = System.Drawing.Color.Lime
        Me.Lbl_Sub_Client_Name_Contract.Location = New System.Drawing.Point(23, 50)
        Me.Lbl_Sub_Client_Name_Contract.Name = "Lbl_Sub_Client_Name_Contract"
        Me.Lbl_Sub_Client_Name_Contract.Size = New System.Drawing.Size(92, 18)
        Me.Lbl_Sub_Client_Name_Contract.TabIndex = 278
        Me.Lbl_Sub_Client_Name_Contract.Text = "Sub Client"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Black
        Me.Label25.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(23, 275)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(194, 18)
        Me.Label25.TabIndex = 277
        Me.Label25.Text = "Contract Attachments:"
        '
        'LV_Contract_Attachments
        '
        Me.LV_Contract_Attachments.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Contract_Attachments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.Col_Contract_Path, Me.Col_Contract_iRefID})
        Me.LV_Contract_Attachments.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Contract_Attachments.FullRowSelect = True
        Me.LV_Contract_Attachments.GridLines = True
        Me.LV_Contract_Attachments.HideSelection = False
        Me.LV_Contract_Attachments.Location = New System.Drawing.Point(26, 298)
        Me.LV_Contract_Attachments.Name = "LV_Contract_Attachments"
        Me.LV_Contract_Attachments.Size = New System.Drawing.Size(521, 110)
        Me.LV_Contract_Attachments.TabIndex = 276
        Me.LV_Contract_Attachments.UseCompatibleStateImageBehavior = False
        Me.LV_Contract_Attachments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Item"
        Me.ColumnHeader5.Width = 50
        '
        'Col_Contract_Path
        '
        Me.Col_Contract_Path.Text = "Attachment File Name"
        Me.Col_Contract_Path.Width = 465
        '
        'Col_Contract_iRefID
        '
        Me.Col_Contract_iRefID.Width = 0
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Black
        Me.Label24.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Aqua
        Me.Label24.Location = New System.Drawing.Point(23, 155)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(85, 18)
        Me.Label24.TabIndex = 274
        Me.Label24.Text = "Remarks:"
        '
        'Txt_Contract_Remarks
        '
        Me.Txt_Contract_Remarks.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contract_Remarks.Location = New System.Drawing.Point(204, 152)
        Me.Txt_Contract_Remarks.Multiline = True
        Me.Txt_Contract_Remarks.Name = "Txt_Contract_Remarks"
        Me.Txt_Contract_Remarks.Size = New System.Drawing.Size(343, 56)
        Me.Txt_Contract_Remarks.TabIndex = 275
        '
        'DP_Contract_End_Date
        '
        Me.DP_Contract_End_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Contract_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Contract_End_Date.Location = New System.Drawing.Point(393, 119)
        Me.DP_Contract_End_Date.Name = "DP_Contract_End_Date"
        Me.DP_Contract_End_Date.Size = New System.Drawing.Size(18, 26)
        Me.DP_Contract_End_Date.TabIndex = 273
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Black
        Me.Label23.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Aqua
        Me.Label23.Location = New System.Drawing.Point(23, 122)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(165, 18)
        Me.Label23.TabIndex = 271
        Me.Label23.Text = "Contract End Date:"
        '
        'TxtContract_End_Date
        '
        Me.TxtContract_End_Date.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtContract_End_Date.Location = New System.Drawing.Point(204, 119)
        Me.TxtContract_End_Date.Name = "TxtContract_End_Date"
        Me.TxtContract_End_Date.Size = New System.Drawing.Size(188, 27)
        Me.TxtContract_End_Date.TabIndex = 272
        Me.TxtContract_End_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DP_Contract_Start_Date
        '
        Me.DP_Contract_Start_Date.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Contract_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DP_Contract_Start_Date.Location = New System.Drawing.Point(393, 87)
        Me.DP_Contract_Start_Date.Name = "DP_Contract_Start_Date"
        Me.DP_Contract_Start_Date.Size = New System.Drawing.Size(18, 26)
        Me.DP_Contract_Start_Date.TabIndex = 270
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Black
        Me.Label22.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Aqua
        Me.Label22.Location = New System.Drawing.Point(23, 89)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(175, 18)
        Me.Label22.TabIndex = 268
        Me.Label22.Text = "Contract Start Date:"
        '
        'TxtContract_Start_Date
        '
        Me.TxtContract_Start_Date.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtContract_Start_Date.Location = New System.Drawing.Point(204, 86)
        Me.TxtContract_Start_Date.Name = "TxtContract_Start_Date"
        Me.TxtContract_Start_Date.Size = New System.Drawing.Size(188, 27)
        Me.TxtContract_Start_Date.TabIndex = 269
        Me.TxtContract_Start_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Black
        Me.TabPage4.Controls.Add(Me.IconButton8)
        Me.TabPage4.Controls.Add(Me.IconButton9)
        Me.TabPage4.Controls.Add(Me.Label32)
        Me.TabPage4.Controls.Add(Me.IconButton6)
        Me.TabPage4.Controls.Add(Me.Lbl_Sub_Client_Name_Termination)
        Me.TabPage4.Controls.Add(Me.Lbl_Sub_Client_ID_Termination)
        Me.TabPage4.Controls.Add(Me.Label29)
        Me.TabPage4.Controls.Add(Me.Label28)
        Me.TabPage4.Controls.Add(Me.Label21)
        Me.TabPage4.Controls.Add(Me.TextBox1)
        Me.TabPage4.Controls.Add(Me.DateTimePicker1)
        Me.TabPage4.Controls.Add(Me.Label26)
        Me.TabPage4.Controls.Add(Me.TextBox2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 33)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(577, 477)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "   Termination   "
        '
        'IconButton8
        '
        Me.IconButton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton8.IconChar = FontAwesome.Sharp.IconChar.Eye
        Me.IconButton8.IconColor = System.Drawing.Color.Green
        Me.IconButton8.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton8.IconSize = 28
        Me.IconButton8.Location = New System.Drawing.Point(325, 416)
        Me.IconButton8.Name = "IconButton8"
        Me.IconButton8.Size = New System.Drawing.Size(115, 35)
        Me.IconButton8.TabIndex = 273
        Me.IconButton8.Text = "View"
        Me.IconButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton8.UseVisualStyleBackColor = True
        '
        'IconButton9
        '
        Me.IconButton9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton9.IconChar = FontAwesome.Sharp.IconChar.Xmark
        Me.IconButton9.IconColor = System.Drawing.Color.Red
        Me.IconButton9.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton9.IconSize = 22
        Me.IconButton9.Location = New System.Drawing.Point(446, 416)
        Me.IconButton9.Name = "IconButton9"
        Me.IconButton9.Size = New System.Drawing.Size(115, 35)
        Me.IconButton9.TabIndex = 272
        Me.IconButton9.Text = "Remove"
        Me.IconButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton9.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Black
        Me.Label32.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(26, 326)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(38, 16)
        Me.Label32.TabIndex = 271
        Me.Label32.Text = "Path"
        '
        'IconButton6
        '
        Me.IconButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton6.IconChar = FontAwesome.Sharp.IconChar.UpRightFromSquare
        Me.IconButton6.IconColor = System.Drawing.Color.Green
        Me.IconButton6.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton6.IconSize = 22
        Me.IconButton6.Location = New System.Drawing.Point(207, 272)
        Me.IconButton6.Name = "IconButton6"
        Me.IconButton6.Size = New System.Drawing.Size(202, 35)
        Me.IconButton6.TabIndex = 270
        Me.IconButton6.Text = "Attach Termination Letter"
        Me.IconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton6.UseVisualStyleBackColor = True
        '
        'Lbl_Sub_Client_Name_Termination
        '
        Me.Lbl_Sub_Client_Name_Termination.AutoSize = True
        Me.Lbl_Sub_Client_Name_Termination.BackColor = System.Drawing.Color.Black
        Me.Lbl_Sub_Client_Name_Termination.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sub_Client_Name_Termination.ForeColor = System.Drawing.Color.Lime
        Me.Lbl_Sub_Client_Name_Termination.Location = New System.Drawing.Point(184, 77)
        Me.Lbl_Sub_Client_Name_Termination.Name = "Lbl_Sub_Client_Name_Termination"
        Me.Lbl_Sub_Client_Name_Termination.Size = New System.Drawing.Size(152, 18)
        Me.Lbl_Sub_Client_Name_Termination.TabIndex = 269
        Me.Lbl_Sub_Client_Name_Termination.Text = "Sub Client Name:"
        '
        'Lbl_Sub_Client_ID_Termination
        '
        Me.Lbl_Sub_Client_ID_Termination.AutoSize = True
        Me.Lbl_Sub_Client_ID_Termination.BackColor = System.Drawing.Color.Black
        Me.Lbl_Sub_Client_ID_Termination.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sub_Client_ID_Termination.ForeColor = System.Drawing.Color.Lime
        Me.Lbl_Sub_Client_ID_Termination.Location = New System.Drawing.Point(184, 38)
        Me.Lbl_Sub_Client_ID_Termination.Name = "Lbl_Sub_Client_ID_Termination"
        Me.Lbl_Sub_Client_ID_Termination.Size = New System.Drawing.Size(124, 18)
        Me.Lbl_Sub_Client_ID_Termination.TabIndex = 268
        Me.Lbl_Sub_Client_ID_Termination.Text = "Sub Client ID:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Black
        Me.Label29.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Cyan
        Me.Label29.Location = New System.Drawing.Point(26, 77)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(152, 18)
        Me.Label29.TabIndex = 267
        Me.Label29.Text = "Sub Client Name:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Black
        Me.Label28.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Cyan
        Me.Label28.Location = New System.Drawing.Point(26, 38)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(124, 18)
        Me.Label28.TabIndex = 266
        Me.Label28.Text = "Sub Client ID:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Aqua
        Me.Label21.Location = New System.Drawing.Point(26, 174)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 18)
        Me.Label21.TabIndex = 264
        Me.Label21.Text = "Remarks:"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(207, 171)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(343, 70)
        Me.TextBox1.TabIndex = 265
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(396, 125)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(18, 26)
        Me.DateTimePicker1.TabIndex = 263
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Black
        Me.Label26.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Aqua
        Me.Label26.Location = New System.Drawing.Point(26, 128)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(142, 18)
        Me.Label26.TabIndex = 261
        Me.Label26.Text = "Effectivity Date:"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(207, 125)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(188, 27)
        Me.TextBox2.TabIndex = 262
        '
        'LV_Sub_Client_List
        '
        Me.LV_Sub_Client_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Sub_Client_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Col_SubClient_Name, Me.ColumnHeader3, Me.Col_SubClient_Status})
        Me.LV_Sub_Client_List.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Sub_Client_List.FullRowSelect = True
        Me.LV_Sub_Client_List.GridLines = True
        Me.LV_Sub_Client_List.HideSelection = False
        Me.LV_Sub_Client_List.Location = New System.Drawing.Point(24, 558)
        Me.LV_Sub_Client_List.Name = "LV_Sub_Client_List"
        Me.LV_Sub_Client_List.Size = New System.Drawing.Size(890, 230)
        Me.LV_Sub_Client_List.TabIndex = 127
        Me.LV_Sub_Client_List.UseCompatibleStateImageBehavior = False
        Me.LV_Sub_Client_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Sub Client ID"
        Me.ColumnHeader1.Width = 110
        '
        'Col_SubClient_Name
        '
        Me.Col_SubClient_Name.Text = "Sub Client Name"
        Me.Col_SubClient_Name.Width = 400
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Address"
        Me.ColumnHeader3.Width = 280
        '
        'Col_SubClient_Status
        '
        Me.Col_SubClient_Status.Text = "Status"
        Me.Col_SubClient_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_SubClient_Status.Width = 110
        '
        'Cmb_MainClient_Status
        '
        Me.Cmb_MainClient_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_MainClient_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_MainClient_Status.FormattingEnabled = True
        Me.Cmb_MainClient_Status.Items.AddRange(New Object() {"Active", "Inactive", "All"})
        Me.Cmb_MainClient_Status.Location = New System.Drawing.Point(90, 57)
        Me.Cmb_MainClient_Status.Name = "Cmb_MainClient_Status"
        Me.Cmb_MainClient_Status.Size = New System.Drawing.Size(159, 28)
        Me.Cmb_MainClient_Status.TabIndex = 130
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1542, 34)
        Me.Panel1.TabIndex = 132
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FRM_CLIENT_HDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1542, 863)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Cmb_MainClient_Status)
        Me.Controls.Add(Me.LV_Sub_Client_List)
        Me.Controls.Add(Me.Tab_Client_Info)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Btn_Show)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LV_Main_Client_List)
        Me.Name = "FRM_CLIENT_HDR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Management"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Client_Info.ResumeLayout(False)
        Me.Tab_MainClient.ResumeLayout(False)
        Me.Tab_MainClient.PerformLayout()
        Me.Tab_SubClient.ResumeLayout(False)
        Me.Tab_Info_Deduction.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Grp_Client_Info.ResumeLayout(False)
        Me.Grp_Client_Info.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Grp_Contract_Info.ResumeLayout(False)
        Me.Grp_Contract_Info.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Show As Button
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LV_Main_Client_List As ListView
    Friend WithEvents Col_Client_Name As ColumnHeader
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Tab_Client_Info As TabControl
    Friend WithEvents Tab_SubClient As TabPage
    Friend WithEvents Col_Client_Status As ColumnHeader
    Friend WithEvents LV_Sub_Client_List As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Col_SubClient_Name As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Tab_Contract_Status As TabPage
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Col_SubClient_Status As ColumnHeader
    Friend WithEvents Cmb_MainClient_Status As ComboBox
    Friend WithEvents Col_MainClient_ID As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Tab_MainClient As TabPage
    Friend WithEvents Btn_Deactivate_Main_Client As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Activate_Main_Client As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Edit_Main_Client As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_New_Main_Client As FontAwesome.Sharp.IconButton
    Friend WithEvents Label27 As Label
    Friend WithEvents Cmb_MainClientName As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Lbl_Main_Client_Status As Label
    Friend WithEvents Btn_Deactivate_Sub_Client As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Activate_Sub_Client As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Edit_Sub_Client As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_New_Sub_Client As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Cmb_ClientType As ComboBox
    Friend WithEvents Tab_Info_Deduction As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Grp_Client_Info As GroupBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Txt_Contact_CPNumber As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_Contact_Email As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_Contact_Person As TextBox
    Friend WithEvents Txt_Sub_Client_ID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Cmb_SchedType As ComboBox
    Friend WithEvents Btn_ShowClientList As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_SubClientName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_Sub_Client_Address As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents IconButton8 As IconButton
    Friend WithEvents IconButton9 As IconButton
    Friend WithEvents Label32 As Label
    Friend WithEvents IconButton6 As IconButton
    Friend WithEvents Lbl_Sub_Client_Name_Termination As Label
    Friend WithEvents Lbl_Sub_Client_ID_Termination As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label26 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Grp_Contract_Info As GroupBox
    Friend WithEvents Btn_View_Contract As IconButton
    Friend WithEvents Lbl_Attachment_Path As Label
    Friend WithEvents Btn_Attachment_Upload As IconButton
    Friend WithEvents Btn_Remove_Contract As IconButton
    Friend WithEvents Lbl_Sub_Client_Name_Contract As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents LV_Contract_Attachments As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Col_Contract_Path As ColumnHeader
    Friend WithEvents Label24 As Label
    Friend WithEvents Txt_Contract_Remarks As TextBox
    Friend WithEvents DP_Contract_End_Date As DateTimePicker
    Friend WithEvents Label23 As Label
    Friend WithEvents TxtContract_End_Date As TextBox
    Friend WithEvents DP_Contract_Start_Date As DateTimePicker
    Friend WithEvents Label22 As Label
    Friend WithEvents TxtContract_Start_Date As TextBox
    Friend WithEvents Col_Contract_iRefID As ColumnHeader
End Class
