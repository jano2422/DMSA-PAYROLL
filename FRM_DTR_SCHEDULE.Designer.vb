<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_DTR_SCHEDULE

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

    Private components As System.ComponentModel.IContainer

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
        Me.rootPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.toolbarPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.toolbarFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblToolbarTitle = New System.Windows.Forms.Label()
        Me.Btn_EmpList = New FontAwesome.Sharp.IconButton()
        Me.BtnGenerate = New FontAwesome.Sharp.IconButton()
        Me.Btn_Save = New FontAwesome.Sharp.IconButton()
        Me.Btn_Close = New System.Windows.Forms.Button()
        Me.contentPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.schedulePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.cutoffHeaderPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.firstCutoffPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFirstCutoffTitle = New System.Windows.Forms.Label()
        Me.firstCutoffFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cmb_1st_TimeIN = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmb_1st_TimeOUT = New System.Windows.Forms.ComboBox()
        Me.Btn_UpdateCells_First = New FontAwesome.Sharp.IconButton()
        Me.secondCutoffPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSecondCutoffTitle = New System.Windows.Forms.Label()
        Me.secondCutoffFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_2nd_TimeIN = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_2nd_TimeOUT = New System.Windows.Forms.ComboBox()
        Me.Btn_UpdateCells_Second = New FontAwesome.Sharp.IconButton()
        Me.gridPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.firstGridPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFirstGridTitle = New System.Windows.Forms.Label()
        Me.GView_Schedule1_15 = New System.Windows.Forms.DataGridView()
        Me.Col_Day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Time_IN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Day_Out = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_TimeOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_TotalHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.secondGridPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSecondGridTitle = New System.Windows.Forms.Label()
        Me.GView_Schedule16_30 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sidePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.employeePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblEmployeeTitle = New System.Windows.Forms.Label()
        Me.pnlEmployeeId = New System.Windows.Forms.Panel()
        Me.Lbl_IDNumber_Sched = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlEmployeeName = New System.Windows.Forms.Panel()
        Me.Lbl_Name_Sched = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlClientId = New System.Windows.Forms.Panel()
        Me.Lbl_SubClient_ID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlSubClient = New System.Windows.Forms.Panel()
        Me.Lbl_SubClient_Name = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.actionPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblActionTitle = New System.Windows.Forms.Label()
        Me.updateSubEmpRec = New FontAwesome.Sharp.IconButton()
        Me.ProgressBar_Save = New System.Windows.Forms.ProgressBar()
        Me.rootPanel.SuspendLayout()
        Me.toolbarPanel.SuspendLayout()
        Me.toolbarFlow.SuspendLayout()
        Me.contentPanel.SuspendLayout()
        Me.schedulePanel.SuspendLayout()
        Me.cutoffHeaderPanel.SuspendLayout()
        Me.firstCutoffPanel.SuspendLayout()
        Me.firstCutoffFlow.SuspendLayout()
        Me.secondCutoffPanel.SuspendLayout()
        Me.secondCutoffFlow.SuspendLayout()
        Me.gridPanel.SuspendLayout()
        Me.firstGridPanel.SuspendLayout()
        CType(Me.GView_Schedule1_15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.secondGridPanel.SuspendLayout()
        CType(Me.GView_Schedule16_30, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sidePanel.SuspendLayout()
        Me.employeePanel.SuspendLayout()
        Me.pnlEmployeeId.SuspendLayout()
        Me.pnlEmployeeName.SuspendLayout()
        Me.pnlClientId.SuspendLayout()
        Me.pnlSubClient.SuspendLayout()
        Me.actionPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'rootPanel
        '
        Me.rootPanel.ColumnCount = 1
        Me.rootPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.Controls.Add(Me.toolbarPanel, 0, 0)
        Me.rootPanel.Controls.Add(Me.contentPanel, 0, 1)
        Me.rootPanel.Controls.Add(Me.ProgressBar_Save, 0, 2)
        Me.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootPanel.Location = New System.Drawing.Point(0, 0)
        Me.rootPanel.Name = "rootPanel"
        Me.rootPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.rootPanel.RowCount = 3
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.rootPanel.Size = New System.Drawing.Size(1220, 720)
        Me.rootPanel.TabIndex = 0
        '
        'toolbarPanel
        '
        Me.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.toolbarPanel.ColumnCount = 1
        Me.toolbarPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.toolbarPanel.Controls.Add(Me.toolbarFlow, 0, 0)
        Me.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolbarPanel.Location = New System.Drawing.Point(13, 13)
        Me.toolbarPanel.Name = "toolbarPanel"
        Me.toolbarPanel.RowCount = 1
        Me.toolbarPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.toolbarPanel.Size = New System.Drawing.Size(1194, 48)
        Me.toolbarPanel.TabIndex = 0
        '
        'toolbarFlow
        '
        Me.toolbarFlow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.toolbarFlow.Controls.Add(Me.lblToolbarTitle)
        Me.toolbarFlow.Controls.Add(Me.Btn_EmpList)
        Me.toolbarFlow.Controls.Add(Me.BtnGenerate)
        Me.toolbarFlow.Controls.Add(Me.Btn_Save)
        Me.toolbarFlow.Controls.Add(Me.Btn_Close)
        Me.toolbarFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolbarFlow.Location = New System.Drawing.Point(3, 3)
        Me.toolbarFlow.Name = "toolbarFlow"
        Me.toolbarFlow.Padding = New System.Windows.Forms.Padding(4, 8, 4, 0)
        Me.toolbarFlow.Size = New System.Drawing.Size(1188, 42)
        Me.toolbarFlow.TabIndex = 0
        Me.toolbarFlow.WrapContents = False
        '
        'lblToolbarTitle
        '
        Me.lblToolbarTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblToolbarTitle.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblToolbarTitle.ForeColor = System.Drawing.Color.Teal
        Me.lblToolbarTitle.Location = New System.Drawing.Point(4, 10)
        Me.lblToolbarTitle.Margin = New System.Windows.Forms.Padding(0, 2, 12, 0)
        Me.lblToolbarTitle.Name = "lblToolbarTitle"
        Me.lblToolbarTitle.Size = New System.Drawing.Size(150, 32)
        Me.lblToolbarTitle.TabIndex = 0
        Me.lblToolbarTitle.Text = "Employee Schedule"
        Me.lblToolbarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btn_EmpList
        '
        Me.Btn_EmpList.BackColor = System.Drawing.Color.Teal
        Me.Btn_EmpList.FlatAppearance.BorderSize = 0
        Me.Btn_EmpList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_EmpList.ForeColor = System.Drawing.Color.White
        Me.Btn_EmpList.IconChar = FontAwesome.Sharp.IconChar.PeopleLine
        Me.Btn_EmpList.IconColor = System.Drawing.Color.White
        Me.Btn_EmpList.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_EmpList.IconSize = 22
        Me.Btn_EmpList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_EmpList.Location = New System.Drawing.Point(166, 10)
        Me.Btn_EmpList.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.Btn_EmpList.Name = "Btn_EmpList"
        Me.Btn_EmpList.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Btn_EmpList.Size = New System.Drawing.Size(142, 32)
        Me.Btn_EmpList.TabIndex = 1
        Me.Btn_EmpList.Text = "Employee"
        Me.Btn_EmpList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_EmpList.UseVisualStyleBackColor = False
        '
        'BtnGenerate
        '
        Me.BtnGenerate.BackColor = System.Drawing.Color.Teal
        Me.BtnGenerate.FlatAppearance.BorderSize = 0
        Me.BtnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGenerate.ForeColor = System.Drawing.Color.White
        Me.BtnGenerate.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek
        Me.BtnGenerate.IconColor = System.Drawing.Color.White
        Me.BtnGenerate.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.BtnGenerate.IconSize = 22
        Me.BtnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGenerate.Location = New System.Drawing.Point(316, 10)
        Me.BtnGenerate.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.BtnGenerate.Size = New System.Drawing.Size(174, 32)
        Me.BtnGenerate.TabIndex = 2
        Me.BtnGenerate.Text = "Default Schedule"
        Me.BtnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnGenerate.UseVisualStyleBackColor = False
        '
        'Btn_Save
        '
        Me.Btn_Save.BackColor = System.Drawing.Color.Teal
        Me.Btn_Save.FlatAppearance.BorderSize = 0
        Me.Btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Save.ForeColor = System.Drawing.Color.White
        Me.Btn_Save.IconChar = FontAwesome.Sharp.IconChar.FileEdit
        Me.Btn_Save.IconColor = System.Drawing.Color.White
        Me.Btn_Save.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Save.IconSize = 22
        Me.Btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Save.Location = New System.Drawing.Point(498, 10)
        Me.Btn_Save.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Btn_Save.Size = New System.Drawing.Size(100, 32)
        Me.Btn_Save.TabIndex = 3
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Save.UseVisualStyleBackColor = False
        '
        'Btn_Close
        '
        Me.Btn_Close.BackColor = System.Drawing.Color.White
        Me.Btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Teal
        Me.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Close.ForeColor = System.Drawing.Color.Black
        Me.Btn_Close.Location = New System.Drawing.Point(606, 10)
        Me.Btn_Close.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(92, 32)
        Me.Btn_Close.TabIndex = 4
        Me.Btn_Close.Text = "Close"
        Me.Btn_Close.UseVisualStyleBackColor = False
        '
        'contentPanel
        '
        Me.contentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.contentPanel.ColumnCount = 2
        Me.contentPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.0!))
        Me.contentPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.contentPanel.Controls.Add(Me.schedulePanel, 0, 0)
        Me.contentPanel.Controls.Add(Me.sidePanel, 1, 0)
        Me.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contentPanel.Location = New System.Drawing.Point(13, 67)
        Me.contentPanel.Name = "contentPanel"
        Me.contentPanel.RowCount = 1
        Me.contentPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.contentPanel.Size = New System.Drawing.Size(1194, 610)
        Me.contentPanel.TabIndex = 1
        '
        'schedulePanel
        '
        Me.schedulePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.schedulePanel.ColumnCount = 1
        Me.schedulePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.schedulePanel.Controls.Add(Me.cutoffHeaderPanel, 0, 0)
        Me.schedulePanel.Controls.Add(Me.gridPanel, 0, 1)
        Me.schedulePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.schedulePanel.Location = New System.Drawing.Point(3, 3)
        Me.schedulePanel.Name = "schedulePanel"
        Me.schedulePanel.RowCount = 2
        Me.schedulePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.schedulePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.schedulePanel.Size = New System.Drawing.Size(877, 604)
        Me.schedulePanel.TabIndex = 0
        '
        'cutoffHeaderPanel
        '
        Me.cutoffHeaderPanel.ColumnCount = 2
        Me.cutoffHeaderPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.cutoffHeaderPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.cutoffHeaderPanel.Controls.Add(Me.firstCutoffPanel, 0, 0)
        Me.cutoffHeaderPanel.Controls.Add(Me.secondCutoffPanel, 1, 0)
        Me.cutoffHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cutoffHeaderPanel.Location = New System.Drawing.Point(0, 0)
        Me.cutoffHeaderPanel.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.cutoffHeaderPanel.Name = "cutoffHeaderPanel"
        Me.cutoffHeaderPanel.RowCount = 1
        Me.cutoffHeaderPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.cutoffHeaderPanel.Size = New System.Drawing.Size(877, 104)
        Me.cutoffHeaderPanel.TabIndex = 0
        '
        'firstCutoffPanel
        '
        Me.firstCutoffPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.firstCutoffPanel.ColumnCount = 1
        Me.firstCutoffPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.firstCutoffPanel.Controls.Add(Me.lblFirstCutoffTitle, 0, 0)
        Me.firstCutoffPanel.Controls.Add(Me.firstCutoffFlow, 0, 1)
        Me.firstCutoffPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.firstCutoffPanel.Location = New System.Drawing.Point(0, 0)
        Me.firstCutoffPanel.Margin = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.firstCutoffPanel.Name = "firstCutoffPanel"
        Me.firstCutoffPanel.RowCount = 2
        Me.firstCutoffPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.firstCutoffPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.firstCutoffPanel.Size = New System.Drawing.Size(432, 104)
        Me.firstCutoffPanel.TabIndex = 0
        '
        'lblFirstCutoffTitle
        '
        Me.lblFirstCutoffTitle.BackColor = System.Drawing.Color.Teal
        Me.lblFirstCutoffTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFirstCutoffTitle.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFirstCutoffTitle.ForeColor = System.Drawing.Color.White
        Me.lblFirstCutoffTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblFirstCutoffTitle.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.lblFirstCutoffTitle.Name = "lblFirstCutoffTitle"
        Me.lblFirstCutoffTitle.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblFirstCutoffTitle.Size = New System.Drawing.Size(432, 28)
        Me.lblFirstCutoffTitle.TabIndex = 0
        Me.lblFirstCutoffTitle.Text = "1st Cut-Off"
        Me.lblFirstCutoffTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'firstCutoffFlow
        '
        Me.firstCutoffFlow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.firstCutoffFlow.Controls.Add(Me.Label4)
        Me.firstCutoffFlow.Controls.Add(Me.Cmb_1st_TimeIN)
        Me.firstCutoffFlow.Controls.Add(Me.Label5)
        Me.firstCutoffFlow.Controls.Add(Me.Cmb_1st_TimeOUT)
        Me.firstCutoffFlow.Controls.Add(Me.Btn_UpdateCells_First)
        Me.firstCutoffFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.firstCutoffFlow.Location = New System.Drawing.Point(0, 34)
        Me.firstCutoffFlow.Margin = New System.Windows.Forms.Padding(0)
        Me.firstCutoffFlow.Name = "firstCutoffFlow"
        Me.firstCutoffFlow.Padding = New System.Windows.Forms.Padding(10, 14, 10, 0)
        Me.firstCutoffFlow.Size = New System.Drawing.Size(432, 70)
        Me.firstCutoffFlow.TabIndex = 1
        Me.firstCutoffFlow.WrapContents = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(10, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 28)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "In"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_1st_TimeIN
        '
        Me.Cmb_1st_TimeIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_1st_TimeIN.FormattingEnabled = True
        Me.Cmb_1st_TimeIN.Location = New System.Drawing.Point(70, 16)
        Me.Cmb_1st_TimeIN.Margin = New System.Windows.Forms.Padding(0, 2, 10, 0)
        Me.Cmb_1st_TimeIN.Name = "Cmb_1st_TimeIN"
        Me.Cmb_1st_TimeIN.Size = New System.Drawing.Size(90, 24)
        Me.Cmb_1st_TimeIN.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(170, 16)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 28)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Out"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_1st_TimeOUT
        '
        Me.Cmb_1st_TimeOUT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_1st_TimeOUT.FormattingEnabled = True
        Me.Cmb_1st_TimeOUT.Location = New System.Drawing.Point(230, 16)
        Me.Cmb_1st_TimeOUT.Margin = New System.Windows.Forms.Padding(0, 2, 10, 0)
        Me.Cmb_1st_TimeOUT.Name = "Cmb_1st_TimeOUT"
        Me.Cmb_1st_TimeOUT.Size = New System.Drawing.Size(90, 24)
        Me.Cmb_1st_TimeOUT.TabIndex = 3
        '
        'Btn_UpdateCells_First
        '
        Me.Btn_UpdateCells_First.BackColor = System.Drawing.Color.Teal
        Me.Btn_UpdateCells_First.FlatAppearance.BorderSize = 0
        Me.Btn_UpdateCells_First.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_UpdateCells_First.ForeColor = System.Drawing.Color.White
        Me.Btn_UpdateCells_First.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek
        Me.Btn_UpdateCells_First.IconColor = System.Drawing.Color.White
        Me.Btn_UpdateCells_First.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_UpdateCells_First.IconSize = 18
        Me.Btn_UpdateCells_First.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_UpdateCells_First.Location = New System.Drawing.Point(330, 16)
        Me.Btn_UpdateCells_First.Margin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Btn_UpdateCells_First.Name = "Btn_UpdateCells_First"
        Me.Btn_UpdateCells_First.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Btn_UpdateCells_First.Size = New System.Drawing.Size(92, 32)
        Me.Btn_UpdateCells_First.TabIndex = 4
        Me.Btn_UpdateCells_First.Text = "Apply"
        Me.Btn_UpdateCells_First.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_UpdateCells_First.UseVisualStyleBackColor = False
        '
        'secondCutoffPanel
        '
        Me.secondCutoffPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.secondCutoffPanel.ColumnCount = 1
        Me.secondCutoffPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.secondCutoffPanel.Controls.Add(Me.lblSecondCutoffTitle, 0, 0)
        Me.secondCutoffPanel.Controls.Add(Me.secondCutoffFlow, 0, 1)
        Me.secondCutoffPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.secondCutoffPanel.Location = New System.Drawing.Point(444, 0)
        Me.secondCutoffPanel.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.secondCutoffPanel.Name = "secondCutoffPanel"
        Me.secondCutoffPanel.RowCount = 2
        Me.secondCutoffPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.secondCutoffPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.secondCutoffPanel.Size = New System.Drawing.Size(433, 104)
        Me.secondCutoffPanel.TabIndex = 1
        '
        'lblSecondCutoffTitle
        '
        Me.lblSecondCutoffTitle.BackColor = System.Drawing.Color.Teal
        Me.lblSecondCutoffTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSecondCutoffTitle.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblSecondCutoffTitle.ForeColor = System.Drawing.Color.White
        Me.lblSecondCutoffTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblSecondCutoffTitle.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.lblSecondCutoffTitle.Name = "lblSecondCutoffTitle"
        Me.lblSecondCutoffTitle.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblSecondCutoffTitle.Size = New System.Drawing.Size(433, 28)
        Me.lblSecondCutoffTitle.TabIndex = 0
        Me.lblSecondCutoffTitle.Text = "2nd Cut-Off"
        Me.lblSecondCutoffTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'secondCutoffFlow
        '
        Me.secondCutoffFlow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.secondCutoffFlow.Controls.Add(Me.Label7)
        Me.secondCutoffFlow.Controls.Add(Me.Cmb_2nd_TimeIN)
        Me.secondCutoffFlow.Controls.Add(Me.Label6)
        Me.secondCutoffFlow.Controls.Add(Me.Cmb_2nd_TimeOUT)
        Me.secondCutoffFlow.Controls.Add(Me.Btn_UpdateCells_Second)
        Me.secondCutoffFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.secondCutoffFlow.Location = New System.Drawing.Point(0, 34)
        Me.secondCutoffFlow.Margin = New System.Windows.Forms.Padding(0)
        Me.secondCutoffFlow.Name = "secondCutoffFlow"
        Me.secondCutoffFlow.Padding = New System.Windows.Forms.Padding(10, 14, 10, 0)
        Me.secondCutoffFlow.Size = New System.Drawing.Size(433, 70)
        Me.secondCutoffFlow.TabIndex = 1
        Me.secondCutoffFlow.WrapContents = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(10, 16)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 28)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "In"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_2nd_TimeIN
        '
        Me.Cmb_2nd_TimeIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_2nd_TimeIN.FormattingEnabled = True
        Me.Cmb_2nd_TimeIN.Location = New System.Drawing.Point(70, 16)
        Me.Cmb_2nd_TimeIN.Margin = New System.Windows.Forms.Padding(0, 2, 10, 0)
        Me.Cmb_2nd_TimeIN.Name = "Cmb_2nd_TimeIN"
        Me.Cmb_2nd_TimeIN.Size = New System.Drawing.Size(90, 24)
        Me.Cmb_2nd_TimeIN.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(170, 16)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 28)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Out"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_2nd_TimeOUT
        '
        Me.Cmb_2nd_TimeOUT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_2nd_TimeOUT.FormattingEnabled = True
        Me.Cmb_2nd_TimeOUT.Location = New System.Drawing.Point(230, 16)
        Me.Cmb_2nd_TimeOUT.Margin = New System.Windows.Forms.Padding(0, 2, 10, 0)
        Me.Cmb_2nd_TimeOUT.Name = "Cmb_2nd_TimeOUT"
        Me.Cmb_2nd_TimeOUT.Size = New System.Drawing.Size(90, 24)
        Me.Cmb_2nd_TimeOUT.TabIndex = 3
        '
        'Btn_UpdateCells_Second
        '
        Me.Btn_UpdateCells_Second.BackColor = System.Drawing.Color.Teal
        Me.Btn_UpdateCells_Second.FlatAppearance.BorderSize = 0
        Me.Btn_UpdateCells_Second.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_UpdateCells_Second.ForeColor = System.Drawing.Color.White
        Me.Btn_UpdateCells_Second.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek
        Me.Btn_UpdateCells_Second.IconColor = System.Drawing.Color.White
        Me.Btn_UpdateCells_Second.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_UpdateCells_Second.IconSize = 18
        Me.Btn_UpdateCells_Second.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_UpdateCells_Second.Location = New System.Drawing.Point(330, 16)
        Me.Btn_UpdateCells_Second.Margin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Btn_UpdateCells_Second.Name = "Btn_UpdateCells_Second"
        Me.Btn_UpdateCells_Second.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Btn_UpdateCells_Second.Size = New System.Drawing.Size(92, 32)
        Me.Btn_UpdateCells_Second.TabIndex = 4
        Me.Btn_UpdateCells_Second.Text = "Apply"
        Me.Btn_UpdateCells_Second.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_UpdateCells_Second.UseVisualStyleBackColor = False
        '
        'gridPanel
        '
        Me.gridPanel.ColumnCount = 2
        Me.gridPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.gridPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.gridPanel.Controls.Add(Me.firstGridPanel, 0, 0)
        Me.gridPanel.Controls.Add(Me.secondGridPanel, 1, 0)
        Me.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPanel.Location = New System.Drawing.Point(0, 112)
        Me.gridPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.gridPanel.Name = "gridPanel"
        Me.gridPanel.RowCount = 1
        Me.gridPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.gridPanel.Size = New System.Drawing.Size(877, 492)
        Me.gridPanel.TabIndex = 1
        '
        'firstGridPanel
        '
        Me.firstGridPanel.ColumnCount = 1
        Me.firstGridPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.firstGridPanel.Controls.Add(Me.lblFirstGridTitle, 0, 0)
        Me.firstGridPanel.Controls.Add(Me.GView_Schedule1_15, 0, 1)
        Me.firstGridPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.firstGridPanel.Location = New System.Drawing.Point(0, 0)
        Me.firstGridPanel.Margin = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.firstGridPanel.Name = "firstGridPanel"
        Me.firstGridPanel.RowCount = 2
        Me.firstGridPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.firstGridPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.firstGridPanel.Size = New System.Drawing.Size(432, 492)
        Me.firstGridPanel.TabIndex = 0
        '
        'lblFirstGridTitle
        '
        Me.lblFirstGridTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblFirstGridTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFirstGridTitle.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblFirstGridTitle.ForeColor = System.Drawing.Color.Teal
        Me.lblFirstGridTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblFirstGridTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFirstGridTitle.Name = "lblFirstGridTitle"
        Me.lblFirstGridTitle.Size = New System.Drawing.Size(432, 34)
        Me.lblFirstGridTitle.TabIndex = 0
        Me.lblFirstGridTitle.Text = "Days 1-15"
        Me.lblFirstGridTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GView_Schedule1_15
        '
        Me.GView_Schedule1_15.AllowUserToAddRows = False
        Me.GView_Schedule1_15.AllowUserToDeleteRows = False
        Me.GView_Schedule1_15.AllowUserToResizeRows = False
        Me.GView_Schedule1_15.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.GView_Schedule1_15.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GView_Schedule1_15.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GView_Schedule1_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GView_Schedule1_15.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.GView_Schedule1_15.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Teal
        Me.GView_Schedule1_15.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GView_Schedule1_15.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.GView_Schedule1_15.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GView_Schedule1_15.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col_Day, Me.Col_Time_IN, Me.Col_Day_Out, Me.Col_TimeOut, Me.Col_TotalHours})
        Me.GView_Schedule1_15.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GView_Schedule1_15.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GView_Schedule1_15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GView_Schedule1_15.EnableHeadersVisualStyles = False
        Me.GView_Schedule1_15.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GView_Schedule1_15.Location = New System.Drawing.Point(0, 34)
        Me.GView_Schedule1_15.Margin = New System.Windows.Forms.Padding(0)
        Me.GView_Schedule1_15.MultiSelect = False
        Me.GView_Schedule1_15.Name = "GView_Schedule1_15"
        Me.GView_Schedule1_15.RowHeadersVisible = False
        Me.GView_Schedule1_15.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GView_Schedule1_15.Size = New System.Drawing.Size(432, 458)
        Me.GView_Schedule1_15.TabIndex = 1
        '
        'Col_Day
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Col_Day.DefaultCellStyle = DataGridViewCellStyle1
        Me.Col_Day.HeaderText = "Day In"
        Me.Col_Day.Name = "Col_Day"
        Me.Col_Day.ReadOnly = True
        '
        'Col_Time_IN
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.Col_Time_IN.DefaultCellStyle = DataGridViewCellStyle2
        Me.Col_Time_IN.HeaderText = "Time In"
        Me.Col_Time_IN.Name = "Col_Time_IN"
        '
        'Col_Day_Out
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Col_Day_Out.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col_Day_Out.HeaderText = "Day Out"
        Me.Col_Day_Out.Name = "Col_Day_Out"
        '
        'Col_TimeOut
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.Col_TimeOut.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col_TimeOut.HeaderText = "Time Out"
        Me.Col_TimeOut.Name = "Col_TimeOut"
        '
        'Col_TotalHours
        '
        Me.Col_TotalHours.HeaderText = "Total"
        Me.Col_TotalHours.Name = "Col_TotalHours"
        Me.Col_TotalHours.ReadOnly = True
        '
        'secondGridPanel
        '
        Me.secondGridPanel.ColumnCount = 1
        Me.secondGridPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.secondGridPanel.Controls.Add(Me.lblSecondGridTitle, 0, 0)
        Me.secondGridPanel.Controls.Add(Me.GView_Schedule16_30, 0, 1)
        Me.secondGridPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.secondGridPanel.Location = New System.Drawing.Point(444, 0)
        Me.secondGridPanel.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.secondGridPanel.Name = "secondGridPanel"
        Me.secondGridPanel.RowCount = 2
        Me.secondGridPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.secondGridPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.secondGridPanel.Size = New System.Drawing.Size(433, 492)
        Me.secondGridPanel.TabIndex = 1
        '
        'lblSecondGridTitle
        '
        Me.lblSecondGridTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSecondGridTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSecondGridTitle.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblSecondGridTitle.ForeColor = System.Drawing.Color.Teal
        Me.lblSecondGridTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblSecondGridTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSecondGridTitle.Name = "lblSecondGridTitle"
        Me.lblSecondGridTitle.Size = New System.Drawing.Size(433, 34)
        Me.lblSecondGridTitle.TabIndex = 0
        Me.lblSecondGridTitle.Text = "Days 16-31"
        Me.lblSecondGridTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GView_Schedule16_30
        '
        Me.GView_Schedule16_30.AllowUserToAddRows = False
        Me.GView_Schedule16_30.AllowUserToDeleteRows = False
        Me.GView_Schedule16_30.AllowUserToResizeRows = False
        Me.GView_Schedule16_30.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.GView_Schedule16_30.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GView_Schedule16_30.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GView_Schedule16_30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GView_Schedule16_30.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.GView_Schedule16_30.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Teal
        Me.GView_Schedule16_30.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GView_Schedule16_30.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.GView_Schedule16_30.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GView_Schedule16_30.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.GView_Schedule16_30.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GView_Schedule16_30.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.GView_Schedule16_30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GView_Schedule16_30.EnableHeadersVisualStyles = False
        Me.GView_Schedule16_30.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GView_Schedule16_30.Location = New System.Drawing.Point(0, 34)
        Me.GView_Schedule16_30.Margin = New System.Windows.Forms.Padding(0)
        Me.GView_Schedule16_30.MultiSelect = False
        Me.GView_Schedule16_30.Name = "GView_Schedule16_30"
        Me.GView_Schedule16_30.RowHeadersVisible = False
        Me.GView_Schedule16_30.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GView_Schedule16_30.Size = New System.Drawing.Size(433, 458)
        Me.GView_Schedule16_30.TabIndex = 1
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn5.HeaderText = "Day In"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn6.HeaderText = "Time In"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn.HeaderText = "Day Out"
        Me.DataGridViewTextBoxColumn.Name = "DataGridViewTextBoxColumn"
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn7.HeaderText = "Time Out"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'sidePanel
        '
        Me.sidePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.sidePanel.ColumnCount = 1
        Me.sidePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.sidePanel.Controls.Add(Me.employeePanel, 0, 0)
        Me.sidePanel.Controls.Add(Me.actionPanel, 0, 1)
        Me.sidePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sidePanel.Location = New System.Drawing.Point(883, 3)
        Me.sidePanel.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.sidePanel.Name = "sidePanel"
        Me.sidePanel.RowCount = 3
        Me.sidePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 314.0!))
        Me.sidePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.sidePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.sidePanel.Size = New System.Drawing.Size(308, 604)
        Me.sidePanel.TabIndex = 1
        '
        'employeePanel
        '
        Me.employeePanel.ColumnCount = 1
        Me.employeePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.employeePanel.Controls.Add(Me.lblEmployeeTitle, 0, 0)
        Me.employeePanel.Controls.Add(Me.pnlEmployeeId, 0, 1)
        Me.employeePanel.Controls.Add(Me.pnlEmployeeName, 0, 2)
        Me.employeePanel.Controls.Add(Me.pnlClientId, 0, 3)
        Me.employeePanel.Controls.Add(Me.pnlSubClient, 0, 4)
        Me.employeePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.employeePanel.Location = New System.Drawing.Point(0, 0)
        Me.employeePanel.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.employeePanel.Name = "employeePanel"
        Me.employeePanel.RowCount = 6
        Me.employeePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.employeePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.employeePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.employeePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.employeePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.employeePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.employeePanel.Size = New System.Drawing.Size(308, 306)
        Me.employeePanel.TabIndex = 0
        '
        'lblEmployeeTitle
        '
        Me.lblEmployeeTitle.BackColor = System.Drawing.Color.Teal
        Me.lblEmployeeTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEmployeeTitle.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeTitle.ForeColor = System.Drawing.Color.White
        Me.lblEmployeeTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblEmployeeTitle.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.lblEmployeeTitle.Name = "lblEmployeeTitle"
        Me.lblEmployeeTitle.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblEmployeeTitle.Size = New System.Drawing.Size(308, 36)
        Me.lblEmployeeTitle.TabIndex = 0
        Me.lblEmployeeTitle.Text = "Selected employee"
        Me.lblEmployeeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlEmployeeId
        '
        Me.pnlEmployeeId.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlEmployeeId.Controls.Add(Me.Lbl_IDNumber_Sched)
        Me.pnlEmployeeId.Controls.Add(Me.Label2)
        Me.pnlEmployeeId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEmployeeId.Location = New System.Drawing.Point(0, 42)
        Me.pnlEmployeeId.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlEmployeeId.Name = "pnlEmployeeId"
        Me.pnlEmployeeId.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlEmployeeId.Size = New System.Drawing.Size(308, 58)
        Me.pnlEmployeeId.TabIndex = 1
        '
        'Lbl_IDNumber_Sched
        '
        Me.Lbl_IDNumber_Sched.AutoEllipsis = True
        Me.Lbl_IDNumber_Sched.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lbl_IDNumber_Sched.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_IDNumber_Sched.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_IDNumber_Sched.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_IDNumber_Sched.Location = New System.Drawing.Point(10, 24)
        Me.Lbl_IDNumber_Sched.Name = "Lbl_IDNumber_Sched"
        Me.Lbl_IDNumber_Sched.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Lbl_IDNumber_Sched.Size = New System.Drawing.Size(288, 28)
        Me.Lbl_IDNumber_Sched.TabIndex = 1
        Me.Lbl_IDNumber_Sched.Text = "-"
        Me.Lbl_IDNumber_Sched.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(10, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "EMPLOYEE ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlEmployeeName
        '
        Me.pnlEmployeeName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlEmployeeName.Controls.Add(Me.Lbl_Name_Sched)
        Me.pnlEmployeeName.Controls.Add(Me.Label1)
        Me.pnlEmployeeName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEmployeeName.Location = New System.Drawing.Point(0, 106)
        Me.pnlEmployeeName.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlEmployeeName.Name = "pnlEmployeeName"
        Me.pnlEmployeeName.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlEmployeeName.Size = New System.Drawing.Size(308, 72)
        Me.pnlEmployeeName.TabIndex = 2
        '
        'Lbl_Name_Sched
        '
        Me.Lbl_Name_Sched.AutoEllipsis = True
        Me.Lbl_Name_Sched.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lbl_Name_Sched.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Name_Sched.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Name_Sched.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Name_Sched.Location = New System.Drawing.Point(10, 24)
        Me.Lbl_Name_Sched.Name = "Lbl_Name_Sched"
        Me.Lbl_Name_Sched.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Lbl_Name_Sched.Size = New System.Drawing.Size(288, 42)
        Me.Lbl_Name_Sched.TabIndex = 1
        Me.Lbl_Name_Sched.Text = "-"
        Me.Lbl_Name_Sched.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(10, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EMPLOYEE NAME"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlClientId
        '
        Me.pnlClientId.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlClientId.Controls.Add(Me.Lbl_SubClient_ID)
        Me.pnlClientId.Controls.Add(Me.Label3)
        Me.pnlClientId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlClientId.Location = New System.Drawing.Point(0, 184)
        Me.pnlClientId.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlClientId.Name = "pnlClientId"
        Me.pnlClientId.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlClientId.Size = New System.Drawing.Size(308, 58)
        Me.pnlClientId.TabIndex = 3
        '
        'Lbl_SubClient_ID
        '
        Me.Lbl_SubClient_ID.AutoEllipsis = True
        Me.Lbl_SubClient_ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lbl_SubClient_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_SubClient_ID.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_SubClient_ID.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_SubClient_ID.Location = New System.Drawing.Point(10, 24)
        Me.Lbl_SubClient_ID.Name = "Lbl_SubClient_ID"
        Me.Lbl_SubClient_ID.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Lbl_SubClient_ID.Size = New System.Drawing.Size(288, 28)
        Me.Lbl_SubClient_ID.TabIndex = 1
        Me.Lbl_SubClient_ID.Text = "-"
        Me.Lbl_SubClient_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Teal
        Me.Label3.Location = New System.Drawing.Point(10, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(288, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CLIENT ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlSubClient
        '
        Me.pnlSubClient.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlSubClient.Controls.Add(Me.Lbl_SubClient_Name)
        Me.pnlSubClient.Controls.Add(Me.Label8)
        Me.pnlSubClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSubClient.Location = New System.Drawing.Point(0, 248)
        Me.pnlSubClient.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlSubClient.Name = "pnlSubClient"
        Me.pnlSubClient.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlSubClient.Size = New System.Drawing.Size(308, 58)
        Me.pnlSubClient.TabIndex = 4
        '
        'Lbl_SubClient_Name
        '
        Me.Lbl_SubClient_Name.AutoEllipsis = True
        Me.Lbl_SubClient_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Lbl_SubClient_Name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_SubClient_Name.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_SubClient_Name.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_SubClient_Name.Location = New System.Drawing.Point(10, 24)
        Me.Lbl_SubClient_Name.Name = "Lbl_SubClient_Name"
        Me.Lbl_SubClient_Name.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Lbl_SubClient_Name.Size = New System.Drawing.Size(288, 28)
        Me.Lbl_SubClient_Name.TabIndex = 1
        Me.Lbl_SubClient_Name.Text = "-"
        Me.Lbl_SubClient_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Teal
        Me.Label8.Location = New System.Drawing.Point(10, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(288, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "SUB CLIENT"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'actionPanel
        '
        Me.actionPanel.ColumnCount = 1
        Me.actionPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.actionPanel.Controls.Add(Me.lblActionTitle, 0, 0)
        Me.actionPanel.Controls.Add(Me.updateSubEmpRec, 0, 1)
        Me.actionPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.actionPanel.Location = New System.Drawing.Point(0, 314)
        Me.actionPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.actionPanel.Name = "actionPanel"
        Me.actionPanel.RowCount = 3
        Me.actionPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.actionPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.actionPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.actionPanel.Size = New System.Drawing.Size(308, 106)
        Me.actionPanel.TabIndex = 1
        '
        'lblActionTitle
        '
        Me.lblActionTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblActionTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblActionTitle.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblActionTitle.ForeColor = System.Drawing.Color.Teal
        Me.lblActionTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblActionTitle.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.lblActionTitle.Name = "lblActionTitle"
        Me.lblActionTitle.Size = New System.Drawing.Size(308, 30)
        Me.lblActionTitle.TabIndex = 0
        Me.lblActionTitle.Text = "Maintenance"
        Me.lblActionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'updateSubEmpRec
        '
        Me.updateSubEmpRec.BackColor = System.Drawing.Color.Teal
        Me.updateSubEmpRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.updateSubEmpRec.FlatAppearance.BorderSize = 0
        Me.updateSubEmpRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.updateSubEmpRec.ForeColor = System.Drawing.Color.White
        Me.updateSubEmpRec.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek
        Me.updateSubEmpRec.IconColor = System.Drawing.Color.White
        Me.updateSubEmpRec.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.updateSubEmpRec.IconSize = 22
        Me.updateSubEmpRec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.updateSubEmpRec.Location = New System.Drawing.Point(0, 34)
        Me.updateSubEmpRec.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.updateSubEmpRec.Name = "updateSubEmpRec"
        Me.updateSubEmpRec.Padding = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.updateSubEmpRec.Size = New System.Drawing.Size(308, 48)
        Me.updateSubEmpRec.TabIndex = 1
        Me.updateSubEmpRec.Text = "Update Sub Client From Emp Rec"
        Me.updateSubEmpRec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.updateSubEmpRec.UseVisualStyleBackColor = False
        Me.updateSubEmpRec.Visible = False
        '
        'ProgressBar_Save
        '
        Me.ProgressBar_Save.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar_Save.Location = New System.Drawing.Point(13, 683)
        Me.ProgressBar_Save.Name = "ProgressBar_Save"
        Me.ProgressBar_Save.Size = New System.Drawing.Size(1194, 24)
        Me.ProgressBar_Save.TabIndex = 2
        Me.ProgressBar_Save.Visible = False
        '
        'FRM_DTR_SCHEDULE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1220, 720)
        Me.Controls.Add(Me.rootPanel)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)
        Me.MinimumSize = New System.Drawing.Size(1100, 650)
        Me.Name = "FRM_DTR_SCHEDULE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Security Guard Schedule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.rootPanel.ResumeLayout(False)
        Me.toolbarPanel.ResumeLayout(False)
        Me.toolbarFlow.ResumeLayout(False)
        Me.contentPanel.ResumeLayout(False)
        Me.schedulePanel.ResumeLayout(False)
        Me.cutoffHeaderPanel.ResumeLayout(False)
        Me.firstCutoffPanel.ResumeLayout(False)
        Me.firstCutoffFlow.ResumeLayout(False)
        Me.secondCutoffPanel.ResumeLayout(False)
        Me.secondCutoffFlow.ResumeLayout(False)
        Me.gridPanel.ResumeLayout(False)
        Me.firstGridPanel.ResumeLayout(False)
        CType(Me.GView_Schedule1_15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.secondGridPanel.ResumeLayout(False)
        CType(Me.GView_Schedule16_30, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sidePanel.ResumeLayout(False)
        Me.employeePanel.ResumeLayout(False)
        Me.pnlEmployeeId.ResumeLayout(False)
        Me.pnlEmployeeName.ResumeLayout(False)
        Me.pnlClientId.ResumeLayout(False)
        Me.pnlSubClient.ResumeLayout(False)
        Me.actionPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rootPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents toolbarPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents toolbarFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblToolbarTitle As System.Windows.Forms.Label
    Friend WithEvents Btn_EmpList As FontAwesome.Sharp.IconButton
    Friend WithEvents BtnGenerate As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Save As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Close As System.Windows.Forms.Button
    Friend WithEvents contentPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents schedulePanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cutoffHeaderPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents firstCutoffPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFirstCutoffTitle As System.Windows.Forms.Label
    Friend WithEvents firstCutoffFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmb_1st_TimeIN As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmb_1st_TimeOUT As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_UpdateCells_First As FontAwesome.Sharp.IconButton
    Friend WithEvents secondCutoffPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSecondCutoffTitle As System.Windows.Forms.Label
    Friend WithEvents secondCutoffFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmb_2nd_TimeIN As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmb_2nd_TimeOUT As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_UpdateCells_Second As FontAwesome.Sharp.IconButton
    Friend WithEvents gridPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents firstGridPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFirstGridTitle As System.Windows.Forms.Label
    Friend WithEvents GView_Schedule1_15 As System.Windows.Forms.DataGridView
    Friend WithEvents secondGridPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSecondGridTitle As System.Windows.Forms.Label
    Friend WithEvents GView_Schedule16_30 As System.Windows.Forms.DataGridView
    Friend WithEvents sidePanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents employeePanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblEmployeeTitle As System.Windows.Forms.Label
    Friend WithEvents pnlEmployeeId As System.Windows.Forms.Panel
    Friend WithEvents Lbl_IDNumber_Sched As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlEmployeeName As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Name_Sched As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlClientId As System.Windows.Forms.Panel
    Friend WithEvents Lbl_SubClient_ID As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlSubClient As System.Windows.Forms.Panel
    Friend WithEvents Lbl_SubClient_Name As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents actionPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblActionTitle As System.Windows.Forms.Label
    Friend WithEvents updateSubEmpRec As FontAwesome.Sharp.IconButton
    Friend WithEvents ProgressBar_Save As System.Windows.Forms.ProgressBar
    Friend WithEvents Col_Day As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Time_IN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_Day_Out As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_TimeOut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col_TotalHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
