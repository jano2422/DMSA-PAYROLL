<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_EMP_REG
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToExcellToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllEmployeeRecordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LV_Employee_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Hired = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Client_Info = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cmb_Category = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.Grp_BasicInfo = New System.Windows.Forms.GroupBox()
        Me.Txt_Relationship = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Contact_CPNumber = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_Contact_Address = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Contact_Person = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_BloodType = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_CivilStatus = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Height = New System.Windows.Forms.TextBox()
        Me.Txt_Gender = New System.Windows.Forms.TextBox()
        Me.Txt_Religion = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Txt_Weight = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Txt_Email = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Txt_ContactNo = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Txt_ResiAdd = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Txt_Birthday = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt_Sec_License_Exp = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_Sec_License = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LV_Client_History = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lbl_Employee_Status = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt_Medical_Type = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txt_Medical_Exp_Date = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_Insurance_Num = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_Insurance_Exp_Date = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Txt_National_ID = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Txt_TIN = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_PhilHealth = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Txt_Pagibig = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Txt_SSS = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Btn_Pic_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Pic_Upload = New System.Windows.Forms.Button()
        Me.Pic_Employee_Photo = New System.Windows.Forms.PictureBox()
        Me.Tab_Client = New System.Windows.Forms.TabPage()
        Me.Tab_Bank = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Cmb_Bank_Name = New System.Windows.Forms.ComboBox()
        Me.Btn_ATM_Cancel = New System.Windows.Forms.Button()
        Me.Btn_ATM_Edit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_ATM_Number = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Btn_LongList = New FontAwesome.Sharp.IconButton()
        Me.Btn_ShortList = New FontAwesome.Sharp.IconButton()
        Me.MenuStrip1.SuspendLayout()
        Me.Grp_BasicInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Pic_Employee_Photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Client.SuspendLayout()
        Me.Tab_Bank.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.DataToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1499, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripMenuItem1.Text = " "
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcellToolStripMenuItem})
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.DataToolStripMenuItem.Text = "Data"
        '
        'ExportToExcellToolStripMenuItem
        '
        Me.ExportToExcellToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllEmployeeRecordsToolStripMenuItem})
        Me.ExportToExcellToolStripMenuItem.Name = "ExportToExcellToolStripMenuItem"
        Me.ExportToExcellToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExportToExcellToolStripMenuItem.Text = "Export to Excell"
        '
        'AllEmployeeRecordsToolStripMenuItem
        '
        Me.AllEmployeeRecordsToolStripMenuItem.Name = "AllEmployeeRecordsToolStripMenuItem"
        Me.AllEmployeeRecordsToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AllEmployeeRecordsToolStripMenuItem.Text = "All employee records"
        '
        'LV_Employee_List
        '
        Me.LV_Employee_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Employee_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Col_ID, Me.Col_Name, Me.Col_Hired, Me.Col_Client_Info, Me.Col_Status})
        Me.LV_Employee_List.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Employee_List.FullRowSelect = True
        Me.LV_Employee_List.GridLines = True
        Me.LV_Employee_List.HideSelection = False
        Me.LV_Employee_List.Location = New System.Drawing.Point(24, 81)
        Me.LV_Employee_List.Name = "LV_Employee_List"
        Me.LV_Employee_List.Size = New System.Drawing.Size(864, 777)
        Me.LV_Employee_List.TabIndex = 1
        Me.LV_Employee_List.UseCompatibleStateImageBehavior = False
        Me.LV_Employee_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Item"
        '
        'Col_ID
        '
        Me.Col_ID.Text = "Emp ID"
        Me.Col_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_ID.Width = 90
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Name"
        Me.Col_Name.Width = 200
        '
        'Col_Hired
        '
        Me.Col_Hired.Text = "Date Hired"
        Me.Col_Hired.Width = 140
        '
        'Col_Client_Info
        '
        Me.Col_Client_Info.Text = "Sub Client"
        Me.Col_Client_Info.Width = 260
        '
        'Col_Status
        '
        Me.Col_Status.Text = "Status"
        Me.Col_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Status.Width = 100
        '
        'Cmb_Category
        '
        Me.Cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Category.FormattingEnabled = True
        Me.Cmb_Category.Items.AddRange(New Object() {"EMPLOYEE ID", "SUB CLIENT NAME", "LAST NAME", "EMPLOYMENT STATUS"})
        Me.Cmb_Category.Location = New System.Drawing.Point(134, 39)
        Me.Cmb_Category.Name = "Cmb_Category"
        Me.Cmb_Category.Size = New System.Drawing.Size(229, 28)
        Me.Cmb_Category.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Aqua
        Me.Label2.Location = New System.Drawing.Point(31, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 18)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Category:"
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(369, 40)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(234, 27)
        Me.TxtSearch.TabIndex = 47
        '
        'Btn_Search
        '
        Me.Btn_Search.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(609, 39)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(109, 30)
        Me.Btn_Search.TabIndex = 48
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'Grp_BasicInfo
        '
        Me.Grp_BasicInfo.BackColor = System.Drawing.Color.Black
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Relationship)
        Me.Grp_BasicInfo.Controls.Add(Me.Label19)
        Me.Grp_BasicInfo.Controls.Add(Me.Label8)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Contact_CPNumber)
        Me.Grp_BasicInfo.Controls.Add(Me.Label10)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Contact_Address)
        Me.Grp_BasicInfo.Controls.Add(Me.Label6)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Contact_Person)
        Me.Grp_BasicInfo.Controls.Add(Me.Label5)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_BloodType)
        Me.Grp_BasicInfo.Controls.Add(Me.Label4)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_CivilStatus)
        Me.Grp_BasicInfo.Controls.Add(Me.Label3)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Height)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Gender)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Religion)
        Me.Grp_BasicInfo.Controls.Add(Me.Label91)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Weight)
        Me.Grp_BasicInfo.Controls.Add(Me.Label83)
        Me.Grp_BasicInfo.Controls.Add(Me.Label50)
        Me.Grp_BasicInfo.Controls.Add(Me.Label51)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Email)
        Me.Grp_BasicInfo.Controls.Add(Me.Label48)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_ContactNo)
        Me.Grp_BasicInfo.Controls.Add(Me.Label32)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_ResiAdd)
        Me.Grp_BasicInfo.Controls.Add(Me.Label15)
        Me.Grp_BasicInfo.Controls.Add(Me.Txt_Birthday)
        Me.Grp_BasicInfo.Controls.Add(Me.Label13)
        Me.Grp_BasicInfo.Controls.Add(Me.Label14)
        Me.Grp_BasicInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Grp_BasicInfo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_BasicInfo.ForeColor = System.Drawing.Color.Yellow
        Me.Grp_BasicInfo.Location = New System.Drawing.Point(894, 434)
        Me.Grp_BasicInfo.Name = "Grp_BasicInfo"
        Me.Grp_BasicInfo.Size = New System.Drawing.Size(584, 424)
        Me.Grp_BasicInfo.TabIndex = 121
        Me.Grp_BasicInfo.TabStop = False
        Me.Grp_BasicInfo.Text = "Basic Information"
        '
        'Txt_Relationship
        '
        Me.Txt_Relationship.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Relationship.Location = New System.Drawing.Point(147, 310)
        Me.Txt_Relationship.Name = "Txt_Relationship"
        Me.Txt_Relationship.Size = New System.Drawing.Size(138, 26)
        Me.Txt_Relationship.TabIndex = 161
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(18, 316)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 20)
        Me.Label19.TabIndex = 160
        Me.Label19.Text = "Relationship:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Aqua
        Me.Label8.Location = New System.Drawing.Point(131, 377)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 20)
        Me.Label8.TabIndex = 159
        Me.Label8.Text = "+63"
        '
        'Txt_Contact_CPNumber
        '
        Me.Txt_Contact_CPNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_CPNumber.Location = New System.Drawing.Point(167, 374)
        Me.Txt_Contact_CPNumber.Name = "Txt_Contact_CPNumber"
        Me.Txt_Contact_CPNumber.Size = New System.Drawing.Size(118, 26)
        Me.Txt_Contact_CPNumber.TabIndex = 157
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(19, 380)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 20)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "Contact No.:"
        '
        'Txt_Contact_Address
        '
        Me.Txt_Contact_Address.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_Address.Location = New System.Drawing.Point(147, 342)
        Me.Txt_Contact_Address.Name = "Txt_Contact_Address"
        Me.Txt_Contact_Address.Size = New System.Drawing.Size(400, 26)
        Me.Txt_Contact_Address.TabIndex = 155
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(17, 345)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "Contact Address:"
        '
        'Txt_Contact_Person
        '
        Me.Txt_Contact_Person.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Contact_Person.Location = New System.Drawing.Point(147, 278)
        Me.Txt_Contact_Person.Name = "Txt_Contact_Person"
        Me.Txt_Contact_Person.Size = New System.Drawing.Size(228, 26)
        Me.Txt_Contact_Person.TabIndex = 154
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(18, 284)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 20)
        Me.Label5.TabIndex = 153
        Me.Label5.Text = "Contact Person:"
        '
        'Txt_BloodType
        '
        Me.Txt_BloodType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_BloodType.Location = New System.Drawing.Point(131, 139)
        Me.Txt_BloodType.Name = "Txt_BloodType"
        Me.Txt_BloodType.Size = New System.Drawing.Size(154, 26)
        Me.Txt_BloodType.TabIndex = 152
        Me.Txt_BloodType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(19, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Blood Type:"
        '
        'Txt_CivilStatus
        '
        Me.Txt_CivilStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CivilStatus.Location = New System.Drawing.Point(393, 73)
        Me.Txt_CivilStatus.Name = "Txt_CivilStatus"
        Me.Txt_CivilStatus.Size = New System.Drawing.Size(154, 26)
        Me.Txt_CivilStatus.TabIndex = 150
        Me.Txt_CivilStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(296, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 20)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Civil Status:"
        '
        'Txt_Height
        '
        Me.Txt_Height.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Height.Location = New System.Drawing.Point(131, 106)
        Me.Txt_Height.Name = "Txt_Height"
        Me.Txt_Height.Size = New System.Drawing.Size(154, 26)
        Me.Txt_Height.TabIndex = 147
        Me.Txt_Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Gender
        '
        Me.Txt_Gender.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Gender.Location = New System.Drawing.Point(131, 72)
        Me.Txt_Gender.Name = "Txt_Gender"
        Me.Txt_Gender.Size = New System.Drawing.Size(154, 26)
        Me.Txt_Gender.TabIndex = 146
        Me.Txt_Gender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Religion
        '
        Me.Txt_Religion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Religion.Location = New System.Drawing.Point(393, 38)
        Me.Txt_Religion.Name = "Txt_Religion"
        Me.Txt_Religion.Size = New System.Drawing.Size(154, 26)
        Me.Txt_Religion.TabIndex = 145
        Me.Txt_Religion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.White
        Me.Label91.Location = New System.Drawing.Point(317, 41)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(70, 20)
        Me.Label91.TabIndex = 139
        Me.Label91.Text = "Religion:"
        '
        'Txt_Weight
        '
        Me.Txt_Weight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Weight.Location = New System.Drawing.Point(393, 108)
        Me.Txt_Weight.Name = "Txt_Weight"
        Me.Txt_Weight.Size = New System.Drawing.Size(81, 26)
        Me.Txt_Weight.TabIndex = 137
        Me.Txt_Weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.White
        Me.Label83.Location = New System.Drawing.Point(291, 110)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(96, 20)
        Me.Label83.TabIndex = 136
        Me.Label83.Text = "Weight (Kg):"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Aqua
        Me.Label50.Location = New System.Drawing.Point(131, 206)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(36, 20)
        Me.Label50.TabIndex = 135
        Me.Label50.Text = "+63"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(19, 107)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(60, 20)
        Me.Label51.TabIndex = 134
        Me.Label51.Text = "Height:"
        '
        'Txt_Email
        '
        Me.Txt_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Email.Location = New System.Drawing.Point(130, 236)
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.Size = New System.Drawing.Size(413, 26)
        Me.Txt_Email.TabIndex = 131
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(18, 239)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(90, 20)
        Me.Label48.TabIndex = 132
        Me.Label48.Text = "E-mail Add:"
        '
        'Txt_ContactNo
        '
        Me.Txt_ContactNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ContactNo.Location = New System.Drawing.Point(167, 204)
        Me.Txt_ContactNo.Name = "Txt_ContactNo"
        Me.Txt_ContactNo.Size = New System.Drawing.Size(118, 26)
        Me.Txt_ContactNo.TabIndex = 129
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(19, 209)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(97, 20)
        Me.Label32.TabIndex = 130
        Me.Label32.Text = "Contact No.:"
        '
        'Txt_ResiAdd
        '
        Me.Txt_ResiAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ResiAdd.Location = New System.Drawing.Point(130, 171)
        Me.Txt_ResiAdd.Multiline = True
        Me.Txt_ResiAdd.Name = "Txt_ResiAdd"
        Me.Txt_ResiAdd.Size = New System.Drawing.Size(414, 27)
        Me.Txt_ResiAdd.TabIndex = 127
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(20, 174)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 20)
        Me.Label15.TabIndex = 128
        Me.Label15.Text = "Address:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Txt_Birthday
        '
        Me.Txt_Birthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Birthday.Location = New System.Drawing.Point(131, 38)
        Me.Txt_Birthday.Name = "Txt_Birthday"
        Me.Txt_Birthday.Size = New System.Drawing.Size(154, 26)
        Me.Txt_Birthday.TabIndex = 126
        Me.Txt_Birthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(20, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 20)
        Me.Label13.TabIndex = 125
        Me.Label13.Text = "Birthday:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(18, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 20)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "Gender:"
        '
        'Txt_Sec_License_Exp
        '
        Me.Txt_Sec_License_Exp.Enabled = False
        Me.Txt_Sec_License_Exp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sec_License_Exp.Location = New System.Drawing.Point(289, 68)
        Me.Txt_Sec_License_Exp.Name = "Txt_Sec_License_Exp"
        Me.Txt_Sec_License_Exp.Size = New System.Drawing.Size(147, 26)
        Me.Txt_Sec_License_Exp.TabIndex = 143
        Me.Txt_Sec_License_Exp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Cyan
        Me.Label9.Location = New System.Drawing.Point(285, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 20)
        Me.Label9.TabIndex = 142
        Me.Label9.Text = "Expiry Date:"
        '
        'Txt_Sec_License
        '
        Me.Txt_Sec_License.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sec_License.Location = New System.Drawing.Point(47, 69)
        Me.Txt_Sec_License.Name = "Txt_Sec_License"
        Me.Txt_Sec_License.Size = New System.Drawing.Size(232, 26)
        Me.Txt_Sec_License.TabIndex = 141
        Me.Txt_Sec_License.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label92.Location = New System.Drawing.Point(43, 45)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(178, 20)
        Me.Label92.TabIndex = 140
        Me.Label92.Text = "Security License No.:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Black
        Me.GroupBox1.Controls.Add(Me.LV_Client_History)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBox1.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(553, 295)
        Me.GroupBox1.TabIndex = 151
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Client Information"
        '
        'LV_Client_History
        '
        Me.LV_Client_History.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Client_History.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LV_Client_History.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Client_History.FullRowSelect = True
        Me.LV_Client_History.GridLines = True
        Me.LV_Client_History.HideSelection = False
        Me.LV_Client_History.Location = New System.Drawing.Point(10, 29)
        Me.LV_Client_History.Name = "LV_Client_History"
        Me.LV_Client_History.Size = New System.Drawing.Size(533, 244)
        Me.LV_Client_History.TabIndex = 155
        Me.LV_Client_History.UseCompatibleStateImageBehavior = False
        Me.LV_Client_History.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Client ID"
        Me.ColumnHeader7.Width = 90
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Client Name"
        Me.ColumnHeader8.Width = 320
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Date Started"
        Me.ColumnHeader9.Width = 120
        '
        'Lbl_Employee_Status
        '
        Me.Lbl_Employee_Status.AutoSize = True
        Me.Lbl_Employee_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Employee_Status.ForeColor = System.Drawing.Color.White
        Me.Lbl_Employee_Status.Location = New System.Drawing.Point(1320, 47)
        Me.Lbl_Employee_Status.Name = "Lbl_Employee_Status"
        Me.Lbl_Employee_Status.Size = New System.Drawing.Size(121, 20)
        Me.Lbl_Employee_Status.TabIndex = 149
        Me.Lbl_Employee_Status.Text = "Status: Active"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Black
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Txt_Medical_Type)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Txt_Medical_Exp_Date)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Txt_Insurance_Num)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Txt_Insurance_Exp_Date)
        Me.GroupBox2.Controls.Add(Me.Label92)
        Me.GroupBox2.Controls.Add(Me.Txt_Sec_License)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Txt_Sec_License_Exp)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBox2.Location = New System.Drawing.Point(24, 592)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(864, 266)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tracking of re-newals"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(43, 192)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 20)
        Me.Label16.TabIndex = 153
        Me.Label16.Text = "Medical:"
        '
        'Txt_Medical_Type
        '
        Me.Txt_Medical_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Medical_Type.Location = New System.Drawing.Point(47, 216)
        Me.Txt_Medical_Type.Name = "Txt_Medical_Type"
        Me.Txt_Medical_Type.Size = New System.Drawing.Size(232, 26)
        Me.Txt_Medical_Type.TabIndex = 154
        Me.Txt_Medical_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Cyan
        Me.Label17.Location = New System.Drawing.Point(285, 192)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 20)
        Me.Label17.TabIndex = 155
        Me.Label17.Text = "Expiry Date:"
        '
        'Txt_Medical_Exp_Date
        '
        Me.Txt_Medical_Exp_Date.Enabled = False
        Me.Txt_Medical_Exp_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Medical_Exp_Date.Location = New System.Drawing.Point(289, 215)
        Me.Txt_Medical_Exp_Date.Name = "Txt_Medical_Exp_Date"
        Me.Txt_Medical_Exp_Date.Size = New System.Drawing.Size(147, 26)
        Me.Txt_Medical_Exp_Date.TabIndex = 156
        Me.Txt_Medical_Exp_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(43, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(212, 20)
        Me.Label11.TabIndex = 149
        Me.Label11.Text = "Insurance Policy Number:"
        '
        'Txt_Insurance_Num
        '
        Me.Txt_Insurance_Num.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Insurance_Num.Location = New System.Drawing.Point(47, 145)
        Me.Txt_Insurance_Num.Name = "Txt_Insurance_Num"
        Me.Txt_Insurance_Num.Size = New System.Drawing.Size(232, 26)
        Me.Txt_Insurance_Num.TabIndex = 150
        Me.Txt_Insurance_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Cyan
        Me.Label12.Location = New System.Drawing.Point(285, 121)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 20)
        Me.Label12.TabIndex = 151
        Me.Label12.Text = "Expiry Date:"
        '
        'Txt_Insurance_Exp_Date
        '
        Me.Txt_Insurance_Exp_Date.Enabled = False
        Me.Txt_Insurance_Exp_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Insurance_Exp_Date.Location = New System.Drawing.Point(289, 144)
        Me.Txt_Insurance_Exp_Date.Name = "Txt_Insurance_Exp_Date"
        Me.Txt_Insurance_Exp_Date.Size = New System.Drawing.Size(147, 26)
        Me.Txt_Insurance_Exp_Date.TabIndex = 152
        Me.Txt_Insurance_Exp_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.Tab_Client)
        Me.TabControl1.Controls.Add(Me.Tab_Bank)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(894, 81)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(584, 347)
        Me.TabControl1.TabIndex = 158
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.Btn_Pic_Cancel)
        Me.TabPage1.Controls.Add(Me.Btn_Pic_Upload)
        Me.TabPage1.Controls.Add(Me.Pic_Employee_Photo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(576, 318)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "  Photo and Government IDs   "
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Black
        Me.GroupBox5.Controls.Add(Me.Txt_National_ID)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Txt_TIN)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Txt_PhilHealth)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.Txt_Pagibig)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Txt_SSS)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBox5.Location = New System.Drawing.Point(270, 18)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(290, 293)
        Me.GroupBox5.TabIndex = 147
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Government IDs"
        '
        'Txt_National_ID
        '
        Me.Txt_National_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_National_ID.Location = New System.Drawing.Point(124, 206)
        Me.Txt_National_ID.Name = "Txt_National_ID"
        Me.Txt_National_ID.Size = New System.Drawing.Size(150, 26)
        Me.Txt_National_ID.TabIndex = 152
        Me.Txt_National_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(19, 206)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 20)
        Me.Label18.TabIndex = 151
        Me.Label18.Text = "National ID:"
        '
        'Txt_TIN
        '
        Me.Txt_TIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TIN.Location = New System.Drawing.Point(124, 168)
        Me.Txt_TIN.Name = "Txt_TIN"
        Me.Txt_TIN.Size = New System.Drawing.Size(150, 26)
        Me.Txt_TIN.TabIndex = 150
        Me.Txt_TIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(45, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "TIN No.:"
        '
        'Txt_PhilHealth
        '
        Me.Txt_PhilHealth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PhilHealth.Location = New System.Drawing.Point(124, 130)
        Me.Txt_PhilHealth.Name = "Txt_PhilHealth"
        Me.Txt_PhilHealth.Size = New System.Drawing.Size(150, 26)
        Me.Txt_PhilHealth.TabIndex = 148
        Me.Txt_PhilHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(36, 133)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(78, 20)
        Me.Label31.TabIndex = 147
        Me.Label31.Text = "PhilH No.:"
        '
        'Txt_Pagibig
        '
        Me.Txt_Pagibig.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Pagibig.Location = New System.Drawing.Point(124, 91)
        Me.Txt_Pagibig.Name = "Txt_Pagibig"
        Me.Txt_Pagibig.Size = New System.Drawing.Size(150, 26)
        Me.Txt_Pagibig.TabIndex = 146
        Me.Txt_Pagibig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(9, 94)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(100, 20)
        Me.Label29.TabIndex = 145
        Me.Label29.Text = "Pag-Ibig No.:"
        '
        'Txt_SSS
        '
        Me.Txt_SSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SSS.Location = New System.Drawing.Point(124, 54)
        Me.Txt_SSS.Name = "Txt_SSS"
        Me.Txt_SSS.Size = New System.Drawing.Size(150, 26)
        Me.Txt_SSS.TabIndex = 144
        Me.Txt_SSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(9, 57)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(106, 20)
        Me.Label27.TabIndex = 143
        Me.Label27.Text = "SSS Number:"
        '
        'Btn_Pic_Cancel
        '
        Me.Btn_Pic_Cancel.Location = New System.Drawing.Point(145, 280)
        Me.Btn_Pic_Cancel.Name = "Btn_Pic_Cancel"
        Me.Btn_Pic_Cancel.Size = New System.Drawing.Size(113, 31)
        Me.Btn_Pic_Cancel.TabIndex = 2
        Me.Btn_Pic_Cancel.Text = "Cancel"
        Me.Btn_Pic_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Pic_Cancel.Visible = False
        '
        'Btn_Pic_Upload
        '
        Me.Btn_Pic_Upload.Enabled = False
        Me.Btn_Pic_Upload.Location = New System.Drawing.Point(18, 280)
        Me.Btn_Pic_Upload.Name = "Btn_Pic_Upload"
        Me.Btn_Pic_Upload.Size = New System.Drawing.Size(115, 31)
        Me.Btn_Pic_Upload.TabIndex = 1
        Me.Btn_Pic_Upload.Text = "Upload"
        Me.Btn_Pic_Upload.UseVisualStyleBackColor = True
        '
        'Pic_Employee_Photo
        '
        Me.Pic_Employee_Photo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic_Employee_Photo.Image = Global.DMSA_System.My.Resources.Resources.DMSA_Logo
        Me.Pic_Employee_Photo.Location = New System.Drawing.Point(17, 28)
        Me.Pic_Employee_Photo.Name = "Pic_Employee_Photo"
        Me.Pic_Employee_Photo.Size = New System.Drawing.Size(241, 241)
        Me.Pic_Employee_Photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Employee_Photo.TabIndex = 0
        Me.Pic_Employee_Photo.TabStop = False
        '
        'Tab_Client
        '
        Me.Tab_Client.BackColor = System.Drawing.Color.Black
        Me.Tab_Client.Controls.Add(Me.GroupBox1)
        Me.Tab_Client.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_Client.Location = New System.Drawing.Point(4, 25)
        Me.Tab_Client.Name = "Tab_Client"
        Me.Tab_Client.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Client.Size = New System.Drawing.Size(576, 318)
        Me.Tab_Client.TabIndex = 1
        Me.Tab_Client.Text = "  Client History  "
        '
        'Tab_Bank
        '
        Me.Tab_Bank.BackColor = System.Drawing.Color.Black
        Me.Tab_Bank.Controls.Add(Me.GroupBox3)
        Me.Tab_Bank.Location = New System.Drawing.Point(4, 25)
        Me.Tab_Bank.Name = "Tab_Bank"
        Me.Tab_Bank.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Bank.Size = New System.Drawing.Size(576, 318)
        Me.Tab_Bank.TabIndex = 3
        Me.Tab_Bank.Text = "  Bank Information  "
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Black
        Me.GroupBox3.Controls.Add(Me.Cmb_Bank_Name)
        Me.GroupBox3.Controls.Add(Me.Btn_ATM_Cancel)
        Me.GroupBox3.Controls.Add(Me.Btn_ATM_Edit)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Txt_ATM_Number)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Yellow
        Me.GroupBox3.Location = New System.Drawing.Point(18, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(528, 272)
        Me.GroupBox3.TabIndex = 147
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Account Information"
        '
        'Cmb_Bank_Name
        '
        Me.Cmb_Bank_Name.FormattingEnabled = True
        Me.Cmb_Bank_Name.Location = New System.Drawing.Point(173, 58)
        Me.Cmb_Bank_Name.Name = "Cmb_Bank_Name"
        Me.Cmb_Bank_Name.Size = New System.Drawing.Size(305, 27)
        Me.Cmb_Bank_Name.TabIndex = 149
        '
        'Btn_ATM_Cancel
        '
        Me.Btn_ATM_Cancel.ForeColor = System.Drawing.Color.Black
        Me.Btn_ATM_Cancel.Location = New System.Drawing.Point(133, 235)
        Me.Btn_ATM_Cancel.Name = "Btn_ATM_Cancel"
        Me.Btn_ATM_Cancel.Size = New System.Drawing.Size(121, 31)
        Me.Btn_ATM_Cancel.TabIndex = 148
        Me.Btn_ATM_Cancel.Text = "Cancel"
        Me.Btn_ATM_Cancel.UseVisualStyleBackColor = True
        Me.Btn_ATM_Cancel.Visible = False
        '
        'Btn_ATM_Edit
        '
        Me.Btn_ATM_Edit.ForeColor = System.Drawing.Color.Black
        Me.Btn_ATM_Edit.Location = New System.Drawing.Point(6, 235)
        Me.Btn_ATM_Edit.Name = "Btn_ATM_Edit"
        Me.Btn_ATM_Edit.Size = New System.Drawing.Size(121, 31)
        Me.Btn_ATM_Edit.TabIndex = 147
        Me.Btn_ATM_Edit.Text = "Edit"
        Me.Btn_ATM_Edit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(50, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "Bank Name:"
        '
        'Txt_ATM_Number
        '
        Me.Txt_ATM_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ATM_Number.Location = New System.Drawing.Point(173, 92)
        Me.Txt_ATM_Number.Name = "Txt_ATM_Number"
        Me.Txt_ATM_Number.Size = New System.Drawing.Size(230, 26)
        Me.Txt_ATM_Number.TabIndex = 144
        Me.Txt_ATM_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(50, 95)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(122, 20)
        Me.Label23.TabIndex = 143
        Me.Label23.Text = "ATM Account #:"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(24, 873)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1454, 69)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Btn_LongList
        '
        Me.Btn_LongList.IconChar = FontAwesome.Sharp.IconChar.ArrowDown
        Me.Btn_LongList.IconColor = System.Drawing.Color.Black
        Me.Btn_LongList.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_LongList.IconSize = 22
        Me.Btn_LongList.Location = New System.Drawing.Point(101, 886)
        Me.Btn_LongList.Name = "Btn_LongList"
        Me.Btn_LongList.Size = New System.Drawing.Size(55, 44)
        Me.Btn_LongList.TabIndex = 160
        Me.Btn_LongList.UseVisualStyleBackColor = True
        '
        'Btn_ShortList
        '
        Me.Btn_ShortList.BackColor = System.Drawing.Color.White
        Me.Btn_ShortList.IconChar = FontAwesome.Sharp.IconChar.ArrowUp
        Me.Btn_ShortList.IconColor = System.Drawing.Color.Black
        Me.Btn_ShortList.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_ShortList.IconSize = 22
        Me.Btn_ShortList.Location = New System.Drawing.Point(42, 886)
        Me.Btn_ShortList.Name = "Btn_ShortList"
        Me.Btn_ShortList.Size = New System.Drawing.Size(55, 44)
        Me.Btn_ShortList.TabIndex = 159
        Me.Btn_ShortList.UseVisualStyleBackColor = False
        '
        'FRM_EMP_REG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1499, 965)
        Me.Controls.Add(Me.Btn_LongList)
        Me.Controls.Add(Me.Btn_ShortList)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.LV_Employee_List)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Lbl_Employee_Status)
        Me.Controls.Add(Me.Grp_BasicInfo)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.Cmb_Category)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_EMP_REG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Records"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Grp_BasicInfo.ResumeLayout(False)
        Me.Grp_BasicInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.Pic_Employee_Photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Client.ResumeLayout(False)
        Me.Tab_Bank.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LV_Employee_List As ListView
    Friend WithEvents Col_ID As ColumnHeader
    Friend WithEvents Col_Name As ColumnHeader
    Friend WithEvents Col_Hired As ColumnHeader
    Friend WithEvents Col_Client_Info As ColumnHeader
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Cmb_Category As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Btn_Search As Button
    Friend WithEvents Grp_BasicInfo As GroupBox
    Friend WithEvents Label91 As Label
    Friend WithEvents Txt_Weight As TextBox
    Friend WithEvents Label83 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Txt_ContactNo As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Txt_ResiAdd As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Txt_Birthday As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Txt_Sec_License_Exp As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_Sec_License As TextBox
    Friend WithEvents Label92 As Label
    Friend WithEvents Txt_Email As TextBox
    Friend WithEvents Txt_Religion As TextBox
    Friend WithEvents Txt_Height As TextBox
    Friend WithEvents Txt_Gender As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Lbl_Employee_Status As Label
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents LV_Client_History As ListView
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_Contact_CPNumber As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt_Contact_Address As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt_Contact_Person As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_BloodType As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_CivilStatus As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Txt_Medical_Type As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Txt_Medical_Exp_Date As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Txt_Insurance_Num As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Txt_Insurance_Exp_Date As TextBox
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Txt_Relationship As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Pic_Employee_Photo As PictureBox
    Friend WithEvents DataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToExcellToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllEmployeeRecordsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Col_Status As ColumnHeader
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Tab_Client As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Btn_Pic_Upload As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Btn_Pic_Cancel As Button
    Friend WithEvents Tab_Bank As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Cmb_Bank_Name As ComboBox
    Friend WithEvents Btn_ATM_Cancel As Button
    Friend WithEvents Btn_ATM_Edit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_ATM_Number As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Txt_National_ID As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Txt_TIN As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt_PhilHealth As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Txt_Pagibig As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Txt_SSS As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Btn_LongList As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_ShortList As FontAwesome.Sharp.IconButton
End Class
