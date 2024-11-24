<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_DTR_SCHEDULE
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GView_Schedule1_15 = New System.Windows.Forms.DataGridView()
        Me.Col_Day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Time_IN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_TimeOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_TotalHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Btn_Save = New FontAwesome.Sharp.IconButton()
        Me.Btn_UpdateCells_First = New FontAwesome.Sharp.IconButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Lbl_IDNumber = New System.Windows.Forms.Label()
        Me.Lbl_SubClient_ID = New System.Windows.Forms.Label()
        Me.Lbl_Name = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Opt_1st_AM = New System.Windows.Forms.RadioButton()
        Me.Opt_1st_PM = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmb_1st_TimeOUT = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cmb_1st_TimeIN = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Btn_UpdateCells_Second = New FontAwesome.Sharp.IconButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_2nd_TimeOUT = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_2nd_TimeIN = New System.Windows.Forms.ComboBox()
        Me.Opt_2nd_AM = New System.Windows.Forms.RadioButton()
        Me.Opt_2nd_PM = New System.Windows.Forms.RadioButton()
        Me.GView_Schedule16_30 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProgressBar_Save = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Lbl_SubClient_Name = New System.Windows.Forms.Label()
        CType(Me.GView_Schedule1_15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GView_Schedule16_30, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1175, 32)
        Me.Panel1.TabIndex = 5
        '
        'GView_Schedule1_15
        '
        Me.GView_Schedule1_15.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.GView_Schedule1_15.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GView_Schedule1_15.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Day, Me.Col_Time_IN, Me.Col_TimeOut, Me.Col_TotalHours})
        Me.GView_Schedule1_15.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GView_Schedule1_15.Location = New System.Drawing.Point(218, 291)
        Me.GView_Schedule1_15.Name = "GView_Schedule1_15"
        Me.GView_Schedule1_15.Size = New System.Drawing.Size(466, 439)
        Me.GView_Schedule1_15.TabIndex = 6
        '
        'Col_Day
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.Col_Day.DefaultCellStyle = DataGridViewCellStyle1
        Me.Col_Day.HeaderText = "Day"
        Me.Col_Day.Name = "Col_Day"
        Me.Col_Day.ReadOnly = True
        '
        'Col_Time_IN
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col_Time_IN.DefaultCellStyle = DataGridViewCellStyle2
        Me.Col_Time_IN.HeaderText = "Time-IN"
        Me.Col_Time_IN.Name = "Col_Time_IN"
        '
        'Col_TimeOut
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col_TimeOut.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col_TimeOut.HeaderText = "Time-OUT"
        Me.Col_TimeOut.Name = "Col_TimeOut"
        '
        'Col_TotalHours
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col_TotalHours.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col_TotalHours.HeaderText = "Total Hours"
        Me.Col_TotalHours.Name = "Col_TotalHours"
        Me.Col_TotalHours.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Controls.Add(Me.Btn_Save)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 745)
        Me.Panel2.TabIndex = 14
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.IconChar = FontAwesome.Sharp.IconChar.FileEdit
        Me.Btn_Save.IconColor = System.Drawing.Color.Green
        Me.Btn_Save.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Save.Location = New System.Drawing.Point(12, 671)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(176, 62)
        Me.Btn_Save.TabIndex = 0
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        '
        'Btn_UpdateCells_First
        '
        Me.Btn_UpdateCells_First.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_UpdateCells_First.ForeColor = System.Drawing.Color.Black
        Me.Btn_UpdateCells_First.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Btn_UpdateCells_First.IconColor = System.Drawing.Color.Black
        Me.Btn_UpdateCells_First.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_UpdateCells_First.Location = New System.Drawing.Point(265, 100)
        Me.Btn_UpdateCells_First.Name = "Btn_UpdateCells_First"
        Me.Btn_UpdateCells_First.Size = New System.Drawing.Size(130, 26)
        Me.Btn_UpdateCells_First.TabIndex = 1
        Me.Btn_UpdateCells_First.Text = "Update all cells"
        Me.Btn_UpdateCells_First.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(218, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(938, 85)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Lbl_IDNumber
        '
        Me.Lbl_IDNumber.AutoSize = True
        Me.Lbl_IDNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lbl_IDNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_IDNumber.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_IDNumber.Location = New System.Drawing.Point(373, 67)
        Me.Lbl_IDNumber.Name = "Lbl_IDNumber"
        Me.Lbl_IDNumber.Size = New System.Drawing.Size(86, 20)
        Me.Lbl_IDNumber.TabIndex = 21
        Me.Lbl_IDNumber.Text = "ID Number"
        '
        'Lbl_SubClient_ID
        '
        Me.Lbl_SubClient_ID.AutoSize = True
        Me.Lbl_SubClient_ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lbl_SubClient_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubClient_ID.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_SubClient_ID.Location = New System.Drawing.Point(778, 67)
        Me.Lbl_SubClient_ID.Name = "Lbl_SubClient_ID"
        Me.Lbl_SubClient_ID.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_SubClient_ID.TabIndex = 20
        Me.Lbl_SubClient_ID.Text = "Detachment"
        '
        'Lbl_Name
        '
        Me.Lbl_Name.AutoSize = True
        Me.Lbl_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lbl_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Name.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Name.Location = New System.Drawing.Point(373, 99)
        Me.Lbl_Name.Name = "Lbl_Name"
        Me.Lbl_Name.Size = New System.Drawing.Size(118, 20)
        Me.Lbl_Name.TabIndex = 19
        Me.Lbl_Name.Text = "Juan Dela Cruz"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(682, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Client ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(238, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Employee ID:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(238, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Employee Name:"
        '
        'Opt_1st_AM
        '
        Me.Opt_1st_AM.AutoSize = True
        Me.Opt_1st_AM.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_1st_AM.ForeColor = System.Drawing.Color.Yellow
        Me.Opt_1st_AM.Location = New System.Drawing.Point(24, 34)
        Me.Opt_1st_AM.Name = "Opt_1st_AM"
        Me.Opt_1st_AM.Size = New System.Drawing.Size(134, 22)
        Me.Opt_1st_AM.TabIndex = 25
        Me.Opt_1st_AM.TabStop = True
        Me.Opt_1st_AM.Text = "Morning Shift"
        Me.Opt_1st_AM.UseVisualStyleBackColor = True
        '
        'Opt_1st_PM
        '
        Me.Opt_1st_PM.AutoSize = True
        Me.Opt_1st_PM.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_1st_PM.ForeColor = System.Drawing.Color.Yellow
        Me.Opt_1st_PM.Location = New System.Drawing.Point(24, 62)
        Me.Opt_1st_PM.Name = "Opt_1st_PM"
        Me.Opt_1st_PM.Size = New System.Drawing.Size(114, 22)
        Me.Opt_1st_PM.TabIndex = 26
        Me.Opt_1st_PM.TabStop = True
        Me.Opt_1st_PM.Text = "Night Shift"
        Me.Opt_1st_PM.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Btn_UpdateCells_First)
        Me.GroupBox1.Controls.Add(Me.Cmb_1st_TimeOUT)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Cmb_1st_TimeIN)
        Me.GroupBox1.Controls.Add(Me.Opt_1st_AM)
        Me.GroupBox1.Controls.Add(Me.Opt_1st_PM)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Aqua
        Me.GroupBox1.Location = New System.Drawing.Point(218, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(466, 143)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "1st Cut-Off"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(215, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Time OUT:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cmb_1st_TimeOUT
        '
        Me.Cmb_1st_TimeOUT.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_1st_TimeOUT.FormattingEnabled = True
        Me.Cmb_1st_TimeOUT.Location = New System.Drawing.Point(305, 64)
        Me.Cmb_1st_TimeOUT.Name = "Cmb_1st_TimeOUT"
        Me.Cmb_1st_TimeOUT.Size = New System.Drawing.Size(90, 22)
        Me.Cmb_1st_TimeOUT.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(215, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 20)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Time IN:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cmb_1st_TimeIN
        '
        Me.Cmb_1st_TimeIN.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_1st_TimeIN.FormattingEnabled = True
        Me.Cmb_1st_TimeIN.Location = New System.Drawing.Point(305, 36)
        Me.Cmb_1st_TimeIN.Name = "Cmb_1st_TimeIN"
        Me.Cmb_1st_TimeIN.Size = New System.Drawing.Size(90, 22)
        Me.Cmb_1st_TimeIN.TabIndex = 27
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Btn_UpdateCells_Second)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Cmb_2nd_TimeOUT)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Cmb_2nd_TimeIN)
        Me.GroupBox2.Controls.Add(Me.Opt_2nd_AM)
        Me.GroupBox2.Controls.Add(Me.Opt_2nd_PM)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Aqua
        Me.GroupBox2.Location = New System.Drawing.Point(690, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(466, 143)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "2nd Cut-Off"
        '
        'Btn_UpdateCells_Second
        '
        Me.Btn_UpdateCells_Second.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_UpdateCells_Second.ForeColor = System.Drawing.Color.Black
        Me.Btn_UpdateCells_Second.IconChar = FontAwesome.Sharp.IconChar.None
        Me.Btn_UpdateCells_Second.IconColor = System.Drawing.Color.Black
        Me.Btn_UpdateCells_Second.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_UpdateCells_Second.Location = New System.Drawing.Point(265, 98)
        Me.Btn_UpdateCells_Second.Name = "Btn_UpdateCells_Second"
        Me.Btn_UpdateCells_Second.Size = New System.Drawing.Size(134, 28)
        Me.Btn_UpdateCells_Second.TabIndex = 32
        Me.Btn_UpdateCells_Second.Text = "Update all cells"
        Me.Btn_UpdateCells_Second.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(219, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Time OUT:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cmb_2nd_TimeOUT
        '
        Me.Cmb_2nd_TimeOUT.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_2nd_TimeOUT.FormattingEnabled = True
        Me.Cmb_2nd_TimeOUT.Location = New System.Drawing.Point(309, 64)
        Me.Cmb_2nd_TimeOUT.Name = "Cmb_2nd_TimeOUT"
        Me.Cmb_2nd_TimeOUT.Size = New System.Drawing.Size(90, 22)
        Me.Cmb_2nd_TimeOUT.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(219, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 20)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Time IN:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cmb_2nd_TimeIN
        '
        Me.Cmb_2nd_TimeIN.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_2nd_TimeIN.FormattingEnabled = True
        Me.Cmb_2nd_TimeIN.Location = New System.Drawing.Point(309, 36)
        Me.Cmb_2nd_TimeIN.Name = "Cmb_2nd_TimeIN"
        Me.Cmb_2nd_TimeIN.Size = New System.Drawing.Size(90, 22)
        Me.Cmb_2nd_TimeIN.TabIndex = 35
        '
        'Opt_2nd_AM
        '
        Me.Opt_2nd_AM.AutoSize = True
        Me.Opt_2nd_AM.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_2nd_AM.ForeColor = System.Drawing.Color.Yellow
        Me.Opt_2nd_AM.Location = New System.Drawing.Point(28, 34)
        Me.Opt_2nd_AM.Name = "Opt_2nd_AM"
        Me.Opt_2nd_AM.Size = New System.Drawing.Size(134, 22)
        Me.Opt_2nd_AM.TabIndex = 33
        Me.Opt_2nd_AM.TabStop = True
        Me.Opt_2nd_AM.Text = "Morning Shift"
        Me.Opt_2nd_AM.UseVisualStyleBackColor = True
        '
        'Opt_2nd_PM
        '
        Me.Opt_2nd_PM.AutoSize = True
        Me.Opt_2nd_PM.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_2nd_PM.ForeColor = System.Drawing.Color.Yellow
        Me.Opt_2nd_PM.Location = New System.Drawing.Point(28, 62)
        Me.Opt_2nd_PM.Name = "Opt_2nd_PM"
        Me.Opt_2nd_PM.Size = New System.Drawing.Size(114, 22)
        Me.Opt_2nd_PM.TabIndex = 34
        Me.Opt_2nd_PM.TabStop = True
        Me.Opt_2nd_PM.Text = "Night Shift"
        Me.Opt_2nd_PM.UseVisualStyleBackColor = True
        '
        'GView_Schedule16_30
        '
        Me.GView_Schedule16_30.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.GView_Schedule16_30.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GView_Schedule16_30.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.GView_Schedule16_30.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GView_Schedule16_30.Location = New System.Drawing.Point(691, 291)
        Me.GView_Schedule16_30.Name = "GView_Schedule16_30"
        Me.GView_Schedule16_30.Size = New System.Drawing.Size(466, 439)
        Me.GView_Schedule16_30.TabIndex = 29
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn5.HeaderText = "Day"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn6.HeaderText = "Time-IN"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn7.HeaderText = "Time-OUT"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn8.HeaderText = "Total Hours"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'ProgressBar_Save
        '
        Me.ProgressBar_Save.Location = New System.Drawing.Point(218, 742)
        Me.ProgressBar_Save.Name = "ProgressBar_Save"
        Me.ProgressBar_Save.Size = New System.Drawing.Size(939, 23)
        Me.ProgressBar_Save.TabIndex = 1
        Me.ProgressBar_Save.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(682, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 20)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Sub Client:"
        '
        'Lbl_SubClient_Name
        '
        Me.Lbl_SubClient_Name.AutoSize = True
        Me.Lbl_SubClient_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lbl_SubClient_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubClient_Name.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_SubClient_Name.Location = New System.Drawing.Point(778, 99)
        Me.Lbl_SubClient_Name.Name = "Lbl_SubClient_Name"
        Me.Lbl_SubClient_Name.Size = New System.Drawing.Size(97, 20)
        Me.Lbl_SubClient_Name.TabIndex = 31
        Me.Lbl_SubClient_Name.Text = "Detachment"
        '
        'FRM_DTR_SCHEDULE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1175, 777)
        Me.Controls.Add(Me.Lbl_SubClient_Name)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ProgressBar_Save)
        Me.Controls.Add(Me.GView_Schedule16_30)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Lbl_IDNumber)
        Me.Controls.Add(Me.Lbl_SubClient_ID)
        Me.Controls.Add(Me.Lbl_Name)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GView_Schedule1_15)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FRM_DTR_SCHEDULE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Security Guard Schedule"
        CType(Me.GView_Schedule1_15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GView_Schedule16_30, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GView_Schedule1_15 As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Btn_UpdateCells_First As IconButton
    Friend WithEvents Btn_Save As IconButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Lbl_IDNumber As Label
    Friend WithEvents Lbl_SubClient_ID As Label
    Friend WithEvents Lbl_Name As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Opt_1st_AM As RadioButton
    Friend WithEvents Opt_1st_PM As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Cmb_1st_TimeOUT As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Cmb_1st_TimeIN As ComboBox
    Friend WithEvents Col_Day As DataGridViewTextBoxColumn
    Friend WithEvents Col_Time_IN As DataGridViewTextBoxColumn
    Friend WithEvents Col_TimeOut As DataGridViewTextBoxColumn
    Friend WithEvents Col_TotalHours As DataGridViewTextBoxColumn
    Friend WithEvents GView_Schedule16_30 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents Btn_UpdateCells_Second As IconButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Cmb_2nd_TimeOUT As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Cmb_2nd_TimeIN As ComboBox
    Friend WithEvents Opt_2nd_AM As RadioButton
    Friend WithEvents Opt_2nd_PM As RadioButton
    Friend WithEvents ProgressBar_Save As ProgressBar
    Friend WithEvents Label8 As Label
    Friend WithEvents Lbl_SubClient_Name As Label
End Class
