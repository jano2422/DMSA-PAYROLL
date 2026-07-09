<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_DTR_EXPORTS
    Inherits System.Windows.Forms.Form

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
        Me.rootPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.toolbarPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.periodPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cmb_Year = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Month = New System.Windows.Forms.ComboBox()
        Me.lblCutoffCaption = New System.Windows.Forms.Label()
        Me.Cmb_CutOff = New System.Windows.Forms.ComboBox()
        Me.Btn_Client = New System.Windows.Forms.Button()
        Me.Btn_Show = New System.Windows.Forms.Button()
        Me.Lbl_LoadedPeriod = New System.Windows.Forms.Label()
        Me.Btn_Close = New System.Windows.Forms.Button()
        Me.contentPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DGV_DTR_Per_Client = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DGV_DTR_MATRIX = New System.Windows.Forms.DataGridView()
        Me.sidePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.clientPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlClientName = New System.Windows.Forms.Panel()
        Me.Lbl_Client_Name = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlClientAddress = New System.Windows.Forms.Panel()
        Me.Lbl_Client_Address = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlClientId = New System.Windows.Forms.Panel()
        Me.Lbl_ClientID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlDailyWage = New System.Windows.Forms.Panel()
        Me.Lbl_Client_Daily_Wage = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.exportPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblExportTitle = New System.Windows.Forms.Label()
        Me.btnDtrHrsExport = New FontAwesome.Sharp.IconButton()
        Me.Btn_Export_to_Excell = New FontAwesome.Sharp.IconButton()
        Me.rootPanel.SuspendLayout()
        Me.toolbarPanel.SuspendLayout()
        Me.periodPanel.SuspendLayout()
        Me.contentPanel.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGV_DTR_Per_Client, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGV_DTR_MATRIX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sidePanel.SuspendLayout()
        Me.clientPanel.SuspendLayout()
        Me.pnlClientName.SuspendLayout()
        Me.pnlClientAddress.SuspendLayout()
        Me.pnlClientId.SuspendLayout()
        Me.pnlDailyWage.SuspendLayout()
        Me.exportPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'rootPanel
        '
        Me.rootPanel.ColumnCount = 2
        Me.rootPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.0!))
        Me.rootPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.rootPanel.Controls.Add(Me.toolbarPanel, 0, 0)
        Me.rootPanel.Controls.Add(Me.contentPanel, 0, 1)
        Me.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootPanel.Location = New System.Drawing.Point(0, 0)
        Me.rootPanel.Name = "rootPanel"
        Me.rootPanel.Padding = New System.Windows.Forms.Padding(10)
        Me.rootPanel.RowCount = 2
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.Size = New System.Drawing.Size(1220, 720)
        Me.rootPanel.TabIndex = 0
        Me.rootPanel.SetColumnSpan(Me.toolbarPanel, 2)
        Me.rootPanel.SetColumnSpan(Me.contentPanel, 2)
        '
        'toolbarPanel
        '
        Me.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.toolbarPanel.ColumnCount = 1
        Me.toolbarPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.toolbarPanel.Controls.Add(Me.periodPanel, 0, 0)
        Me.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolbarPanel.Location = New System.Drawing.Point(13, 13)
        Me.toolbarPanel.Name = "toolbarPanel"
        Me.toolbarPanel.RowCount = 1
        Me.toolbarPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.toolbarPanel.Size = New System.Drawing.Size(1194, 48)
        Me.toolbarPanel.TabIndex = 0
        '
        'periodPanel
        '
        Me.periodPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.periodPanel.Controls.Add(Me.Label10)
        Me.periodPanel.Controls.Add(Me.Label4)
        Me.periodPanel.Controls.Add(Me.Cmb_Year)
        Me.periodPanel.Controls.Add(Me.Label3)
        Me.periodPanel.Controls.Add(Me.Cmb_Month)
        Me.periodPanel.Controls.Add(Me.lblCutoffCaption)
        Me.periodPanel.Controls.Add(Me.Cmb_CutOff)
        Me.periodPanel.Controls.Add(Me.Btn_Client)
        Me.periodPanel.Controls.Add(Me.Btn_Show)
        Me.periodPanel.Controls.Add(Me.Lbl_LoadedPeriod)
        Me.periodPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.periodPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
        Me.periodPanel.Location = New System.Drawing.Point(3, 3)
        Me.periodPanel.Name = "periodPanel"
        Me.periodPanel.Padding = New System.Windows.Forms.Padding(4, 8, 4, 0)
        Me.periodPanel.Size = New System.Drawing.Size(1188, 42)
        Me.periodPanel.TabIndex = 0
        Me.periodPanel.WrapContents = True
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Teal
        Me.Label10.Location = New System.Drawing.Point(4, 10)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 32)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Period"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoEllipsis = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Label4.Location = New System.Drawing.Point(70, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 28)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Year"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_Year
        '
        Me.Cmb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Year.FormattingEnabled = True
        Me.Cmb_Year.Location = New System.Drawing.Point(134, 10)
        Me.Cmb_Year.Margin = New System.Windows.Forms.Padding(0, 2, 12, 0)
        Me.Cmb_Year.Name = "Cmb_Year"
        Me.Cmb_Year.Size = New System.Drawing.Size(86, 24)
        Me.Cmb_Year.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoEllipsis = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Label3.Location = New System.Drawing.Point(232, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 28)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Month"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_Month
        '
        Me.Cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Month.FormattingEnabled = True
        Me.Cmb_Month.Location = New System.Drawing.Point(302, 10)
        Me.Cmb_Month.Margin = New System.Windows.Forms.Padding(0, 2, 12, 0)
        Me.Cmb_Month.Name = "Cmb_Month"
        Me.Cmb_Month.Size = New System.Drawing.Size(100, 24)
        Me.Cmb_Month.TabIndex = 4
        '
        'lblCutoffCaption
        '
        Me.lblCutoffCaption.AutoEllipsis = True
        Me.lblCutoffCaption.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.lblCutoffCaption.Location = New System.Drawing.Point(414, 10)
        Me.lblCutoffCaption.Margin = New System.Windows.Forms.Padding(0, 2, 6, 0)
        Me.lblCutoffCaption.Name = "lblCutoffCaption"
        Me.lblCutoffCaption.Size = New System.Drawing.Size(68, 28)
        Me.lblCutoffCaption.TabIndex = 5
        Me.lblCutoffCaption.Text = "Cutoff"
        Me.lblCutoffCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_CutOff
        '
        Me.Cmb_CutOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_CutOff.FormattingEnabled = True
        Me.Cmb_CutOff.Items.AddRange(New Object() {"1st Cut-Off", "2nd Cut-Off"})
        Me.Cmb_CutOff.Location = New System.Drawing.Point(488, 10)
        Me.Cmb_CutOff.Margin = New System.Windows.Forms.Padding(0, 2, 16, 0)
        Me.Cmb_CutOff.Name = "Cmb_CutOff"
        Me.Cmb_CutOff.Size = New System.Drawing.Size(124, 24)
        Me.Cmb_CutOff.TabIndex = 6
        '
        'Btn_Client
        '
        Me.Btn_Client.BackColor = System.Drawing.Color.Teal
        Me.Btn_Client.FlatAppearance.BorderSize = 0
        Me.Btn_Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Client.ForeColor = System.Drawing.Color.White
        Me.Btn_Client.Location = New System.Drawing.Point(628, 10)
        Me.Btn_Client.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.Btn_Client.Name = "Btn_Client"
        Me.Btn_Client.Size = New System.Drawing.Size(132, 32)
        Me.Btn_Client.TabIndex = 7
        Me.Btn_Client.Text = "Select Client"
        Me.Btn_Client.UseVisualStyleBackColor = False
        '
        'Btn_Show
        '
        Me.Btn_Show.BackColor = System.Drawing.Color.Teal
        Me.Btn_Show.FlatAppearance.BorderSize = 0
        Me.Btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Show.ForeColor = System.Drawing.Color.White
        Me.Btn_Show.Location = New System.Drawing.Point(768, 10)
        Me.Btn_Show.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.Btn_Show.Name = "Btn_Show"
        Me.Btn_Show.Size = New System.Drawing.Size(132, 32)
        Me.Btn_Show.TabIndex = 8
        Me.Btn_Show.Text = "Show Records"
        Me.Btn_Show.UseVisualStyleBackColor = False
        '
        'Lbl_LoadedPeriod
        '
        Me.Lbl_LoadedPeriod.AutoEllipsis = True
        Me.Lbl_LoadedPeriod.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Lbl_LoadedPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_LoadedPeriod.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.Lbl_LoadedPeriod.ForeColor = System.Drawing.Color.FromArgb(74, 55, 32)
        Me.Lbl_LoadedPeriod.Location = New System.Drawing.Point(908, 10)
        Me.Lbl_LoadedPeriod.Margin = New System.Windows.Forms.Padding(0, 2, 8, 0)
        Me.Lbl_LoadedPeriod.Name = "Lbl_LoadedPeriod"
        Me.Lbl_LoadedPeriod.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Lbl_LoadedPeriod.Size = New System.Drawing.Size(170, 32)
        Me.Lbl_LoadedPeriod.TabIndex = 9
        Me.Lbl_LoadedPeriod.Text = "Showing: none"
        Me.Lbl_LoadedPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btn_Close
        '
        Me.Btn_Close.BackColor = System.Drawing.Color.White
        Me.Btn_Close.Dock = System.Windows.Forms.DockStyle.Top
        Me.Btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Teal
        Me.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Close.ForeColor = System.Drawing.Color.Black
        Me.Btn_Close.Location = New System.Drawing.Point(0, 526)
        Me.Btn_Close.Margin = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(305, 42)
        Me.Btn_Close.TabIndex = 10
        Me.Btn_Close.Text = "Close"
        Me.Btn_Close.UseVisualStyleBackColor = False
        '
        'contentPanel
        '
        Me.contentPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.contentPanel.ColumnCount = 2
        Me.contentPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.0!))
        Me.contentPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.contentPanel.Controls.Add(Me.TabControl1, 0, 0)
        Me.contentPanel.Controls.Add(Me.sidePanel, 1, 0)
        Me.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contentPanel.Location = New System.Drawing.Point(13, 67)
        Me.contentPanel.Name = "contentPanel"
        Me.contentPanel.RowCount = 1
        Me.contentPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.contentPanel.Size = New System.Drawing.Size(1194, 640)
        Me.contentPanel.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(877, 634)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.TabPage1.Controls.Add(Me.DGV_DTR_Per_Client)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(869, 605)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Per Client"
        '
        'DGV_DTR_Per_Client
        '
        Me.DGV_DTR_Per_Client.AllowUserToAddRows = False
        Me.DGV_DTR_Per_Client.AllowUserToDeleteRows = False
        Me.DGV_DTR_Per_Client.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 238, 214)
        Me.DGV_DTR_Per_Client.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DGV_DTR_Per_Client.BackgroundColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.DGV_DTR_Per_Client.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DGV_DTR_Per_Client.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Teal
        Me.DGV_DTR_Per_Client.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DGV_DTR_Per_Client.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.DGV_DTR_Per_Client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DTR_Per_Client.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.DGV_DTR_Per_Client.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DGV_DTR_Per_Client.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_DTR_Per_Client.EnableHeadersVisualStyles = False
        Me.DGV_DTR_Per_Client.GridColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.DGV_DTR_Per_Client.Location = New System.Drawing.Point(3, 3)
        Me.DGV_DTR_Per_Client.MultiSelect = False
        Me.DGV_DTR_Per_Client.Name = "DGV_DTR_Per_Client"
        Me.DGV_DTR_Per_Client.ReadOnly = True
        Me.DGV_DTR_Per_Client.RowHeadersVisible = False
        Me.DGV_DTR_Per_Client.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_DTR_Per_Client.Size = New System.Drawing.Size(863, 599)
        Me.DGV_DTR_Per_Client.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.TabPage2.Controls.Add(Me.DGV_DTR_MATRIX)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(869, 605)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Hours Per Day"
        '
        'DGV_DTR_MATRIX
        '
        Me.DGV_DTR_MATRIX.AllowUserToAddRows = False
        Me.DGV_DTR_MATRIX.AllowUserToDeleteRows = False
        Me.DGV_DTR_MATRIX.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 238, 214)
        Me.DGV_DTR_MATRIX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DGV_DTR_MATRIX.BackgroundColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.DGV_DTR_MATRIX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DGV_DTR_MATRIX.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Teal
        Me.DGV_DTR_MATRIX.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DGV_DTR_MATRIX.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.DGV_DTR_MATRIX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DTR_MATRIX.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.DGV_DTR_MATRIX.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DGV_DTR_MATRIX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_DTR_MATRIX.EnableHeadersVisualStyles = False
        Me.DGV_DTR_MATRIX.GridColor = System.Drawing.Color.FromArgb(224, 176, 128)
        Me.DGV_DTR_MATRIX.Location = New System.Drawing.Point(3, 3)
        Me.DGV_DTR_MATRIX.MultiSelect = False
        Me.DGV_DTR_MATRIX.Name = "DGV_DTR_MATRIX"
        Me.DGV_DTR_MATRIX.ReadOnly = True
        Me.DGV_DTR_MATRIX.RowHeadersVisible = False
        Me.DGV_DTR_MATRIX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGV_DTR_MATRIX.Size = New System.Drawing.Size(863, 599)
        Me.DGV_DTR_MATRIX.TabIndex = 0
        '
        'sidePanel
        '
        Me.sidePanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.sidePanel.ColumnCount = 1
        Me.sidePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.sidePanel.Controls.Add(Me.clientPanel, 0, 0)
        Me.sidePanel.Controls.Add(Me.exportPanel, 0, 1)
        Me.sidePanel.Controls.Add(Me.Btn_Close, 0, 2)
        Me.sidePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sidePanel.Location = New System.Drawing.Point(886, 3)
        Me.sidePanel.Name = "sidePanel"
        Me.sidePanel.RowCount = 3
        Me.sidePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 336.0!))
        Me.sidePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.sidePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.sidePanel.Size = New System.Drawing.Size(305, 634)
        Me.sidePanel.TabIndex = 1
        '
        'clientPanel
        '
        Me.clientPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.clientPanel.ColumnCount = 1
        Me.clientPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.clientPanel.Controls.Add(Me.Label5, 0, 0)
        Me.clientPanel.Controls.Add(Me.pnlClientName, 0, 1)
        Me.clientPanel.Controls.Add(Me.pnlClientAddress, 0, 2)
        Me.clientPanel.Controls.Add(Me.pnlClientId, 0, 3)
        Me.clientPanel.Controls.Add(Me.pnlDailyWage, 0, 4)
        Me.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clientPanel.Location = New System.Drawing.Point(0, 0)
        Me.clientPanel.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.clientPanel.Name = "clientPanel"
        Me.clientPanel.RowCount = 6
        Me.clientPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.clientPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.clientPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.clientPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.clientPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.clientPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.clientPanel.Size = New System.Drawing.Size(305, 328)
        Me.clientPanel.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(305, 36)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Selected client"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlClientName
        '
        Me.pnlClientName.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlClientName.Controls.Add(Me.Lbl_Client_Name)
        Me.pnlClientName.Controls.Add(Me.Label1)
        Me.pnlClientName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlClientName.Location = New System.Drawing.Point(0, 42)
        Me.pnlClientName.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlClientName.Name = "pnlClientName"
        Me.pnlClientName.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlClientName.Size = New System.Drawing.Size(305, 58)
        Me.pnlClientName.TabIndex = 1
        '
        'Lbl_Client_Name
        '
        Me.Lbl_Client_Name.AutoEllipsis = True
        Me.Lbl_Client_Name.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Lbl_Client_Name.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Client_Name.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Client_Name.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Client_Name.Location = New System.Drawing.Point(10, 24)
        Me.Lbl_Client_Name.Name = "Lbl_Client_Name"
        Me.Lbl_Client_Name.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Lbl_Client_Name.Size = New System.Drawing.Size(285, 28)
        Me.Lbl_Client_Name.TabIndex = 1
        Me.Lbl_Client_Name.Text = "-"
        Me.Lbl_Client_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(10, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CLIENT NAME"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlClientAddress
        '
        Me.pnlClientAddress.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlClientAddress.Controls.Add(Me.Lbl_Client_Address)
        Me.pnlClientAddress.Controls.Add(Me.Label2)
        Me.pnlClientAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlClientAddress.Location = New System.Drawing.Point(0, 106)
        Me.pnlClientAddress.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlClientAddress.Name = "pnlClientAddress"
        Me.pnlClientAddress.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlClientAddress.Size = New System.Drawing.Size(305, 76)
        Me.pnlClientAddress.TabIndex = 2
        '
        'Lbl_Client_Address
        '
        Me.Lbl_Client_Address.AutoEllipsis = True
        Me.Lbl_Client_Address.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Lbl_Client_Address.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Client_Address.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Client_Address.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Client_Address.Location = New System.Drawing.Point(10, 24)
        Me.Lbl_Client_Address.Name = "Lbl_Client_Address"
        Me.Lbl_Client_Address.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Lbl_Client_Address.Size = New System.Drawing.Size(285, 46)
        Me.Lbl_Client_Address.TabIndex = 1
        Me.Lbl_Client_Address.Text = "-"
        Me.Lbl_Client_Address.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(10, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(285, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "ADDRESS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlClientId
        '
        Me.pnlClientId.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlClientId.Controls.Add(Me.Lbl_ClientID)
        Me.pnlClientId.Controls.Add(Me.Label7)
        Me.pnlClientId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlClientId.Location = New System.Drawing.Point(0, 188)
        Me.pnlClientId.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlClientId.Name = "pnlClientId"
        Me.pnlClientId.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlClientId.Size = New System.Drawing.Size(305, 58)
        Me.pnlClientId.TabIndex = 3
        '
        'Lbl_ClientID
        '
        Me.Lbl_ClientID.AutoEllipsis = True
        Me.Lbl_ClientID.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Lbl_ClientID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_ClientID.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_ClientID.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_ClientID.Location = New System.Drawing.Point(10, 24)
        Me.Lbl_ClientID.Name = "Lbl_ClientID"
        Me.Lbl_ClientID.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Lbl_ClientID.Size = New System.Drawing.Size(285, 28)
        Me.Lbl_ClientID.TabIndex = 1
        Me.Lbl_ClientID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Teal
        Me.Label7.Location = New System.Drawing.Point(10, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(285, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "CLIENT ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDailyWage
        '
        Me.pnlDailyWage.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.pnlDailyWage.Controls.Add(Me.Lbl_Client_Daily_Wage)
        Me.pnlDailyWage.Controls.Add(Me.Label6)
        Me.pnlDailyWage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDailyWage.Location = New System.Drawing.Point(0, 252)
        Me.pnlDailyWage.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlDailyWage.Name = "pnlDailyWage"
        Me.pnlDailyWage.Padding = New System.Windows.Forms.Padding(10, 6, 10, 6)
        Me.pnlDailyWage.Size = New System.Drawing.Size(305, 58)
        Me.pnlDailyWage.TabIndex = 4
        '
        'Lbl_Client_Daily_Wage
        '
        Me.Lbl_Client_Daily_Wage.AutoEllipsis = True
        Me.Lbl_Client_Daily_Wage.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Lbl_Client_Daily_Wage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Client_Daily_Wage.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Client_Daily_Wage.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_Client_Daily_Wage.Location = New System.Drawing.Point(10, 24)
        Me.Lbl_Client_Daily_Wage.Name = "Lbl_Client_Daily_Wage"
        Me.Lbl_Client_Daily_Wage.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Lbl_Client_Daily_Wage.Size = New System.Drawing.Size(285, 28)
        Me.Lbl_Client_Daily_Wage.TabIndex = 1
        Me.Lbl_Client_Daily_Wage.Text = "-"
        Me.Lbl_Client_Daily_Wage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Verdana", 7.5!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Teal
        Me.Label6.Location = New System.Drawing.Point(10, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(285, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "DAILY WAGE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'exportPanel
        '
        Me.exportPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.exportPanel.ColumnCount = 1
        Me.exportPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.exportPanel.Controls.Add(Me.lblExportTitle, 0, 0)
        Me.exportPanel.Controls.Add(Me.btnDtrHrsExport, 0, 1)
        Me.exportPanel.Controls.Add(Me.Btn_Export_to_Excell, 0, 2)
        Me.exportPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.exportPanel.Location = New System.Drawing.Point(0, 336)
        Me.exportPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.exportPanel.Name = "exportPanel"
        Me.exportPanel.RowCount = 4
        Me.exportPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.exportPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.exportPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.exportPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.exportPanel.Size = New System.Drawing.Size(305, 178)
        Me.exportPanel.TabIndex = 1
        '
        'lblExportTitle
        '
        Me.lblExportTitle.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.lblExportTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblExportTitle.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblExportTitle.ForeColor = System.Drawing.Color.Teal
        Me.lblExportTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblExportTitle.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.lblExportTitle.Name = "lblExportTitle"
        Me.lblExportTitle.Size = New System.Drawing.Size(305, 30)
        Me.lblExportTitle.TabIndex = 0
        Me.lblExportTitle.Text = "Export"
        Me.lblExportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDtrHrsExport
        '
        Me.btnDtrHrsExport.BackColor = System.Drawing.Color.Teal
        Me.btnDtrHrsExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDtrHrsExport.FlatAppearance.BorderSize = 0
        Me.btnDtrHrsExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDtrHrsExport.ForeColor = System.Drawing.Color.White
        Me.btnDtrHrsExport.IconChar = FontAwesome.Sharp.IconChar.ClockFour
        Me.btnDtrHrsExport.IconColor = System.Drawing.Color.White
        Me.btnDtrHrsExport.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnDtrHrsExport.IconSize = 24
        Me.btnDtrHrsExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDtrHrsExport.Location = New System.Drawing.Point(0, 34)
        Me.btnDtrHrsExport.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.btnDtrHrsExport.Name = "btnDtrHrsExport"
        Me.btnDtrHrsExport.Padding = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.btnDtrHrsExport.Size = New System.Drawing.Size(305, 48)
        Me.btnDtrHrsExport.TabIndex = 1
        Me.btnDtrHrsExport.Text = "Export DTR Hours"
        Me.btnDtrHrsExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDtrHrsExport.UseVisualStyleBackColor = False
        '
        'Btn_Export_to_Excell
        '
        Me.Btn_Export_to_Excell.BackColor = System.Drawing.Color.Teal
        Me.Btn_Export_to_Excell.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Btn_Export_to_Excell.FlatAppearance.BorderSize = 0
        Me.Btn_Export_to_Excell.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Export_to_Excell.ForeColor = System.Drawing.Color.White
        Me.Btn_Export_to_Excell.IconChar = FontAwesome.Sharp.IconChar.FileDownload
        Me.Btn_Export_to_Excell.IconColor = System.Drawing.Color.White
        Me.Btn_Export_to_Excell.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Export_to_Excell.IconSize = 24
        Me.Btn_Export_to_Excell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Export_to_Excell.Location = New System.Drawing.Point(0, 90)
        Me.Btn_Export_to_Excell.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.Btn_Export_to_Excell.Name = "Btn_Export_to_Excell"
        Me.Btn_Export_to_Excell.Padding = New System.Windows.Forms.Padding(12, 0, 12, 0)
        Me.Btn_Export_to_Excell.Size = New System.Drawing.Size(305, 48)
        Me.Btn_Export_to_Excell.TabIndex = 2
        Me.Btn_Export_to_Excell.Text = "Export Payroll"
        Me.Btn_Export_to_Excell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Export_to_Excell.UseVisualStyleBackColor = False
        '
        'FRM_DTR_EXPORTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.ClientSize = New System.Drawing.Size(1220, 720)
        Me.Controls.Add(Me.rootPanel)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)
        Me.MinimumSize = New System.Drawing.Size(1100, 650)
        Me.Name = "FRM_DTR_EXPORTS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DTR Exports"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.rootPanel.ResumeLayout(False)
        Me.toolbarPanel.ResumeLayout(False)
        Me.periodPanel.ResumeLayout(False)
        Me.contentPanel.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DGV_DTR_Per_Client, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DGV_DTR_MATRIX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sidePanel.ResumeLayout(False)
        Me.clientPanel.ResumeLayout(False)
        Me.pnlClientName.ResumeLayout(False)
        Me.pnlClientAddress.ResumeLayout(False)
        Me.pnlClientId.ResumeLayout(False)
        Me.pnlDailyWage.ResumeLayout(False)
        Me.exportPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rootPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents toolbarPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents periodPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Year As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Month As System.Windows.Forms.ComboBox
    Friend WithEvents lblCutoffCaption As System.Windows.Forms.Label
    Friend WithEvents Cmb_CutOff As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Client As System.Windows.Forms.Button
    Friend WithEvents Btn_Show As System.Windows.Forms.Button
    Friend WithEvents Lbl_LoadedPeriod As System.Windows.Forms.Label
    Friend WithEvents Btn_Close As System.Windows.Forms.Button
    Friend WithEvents contentPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DGV_DTR_Per_Client As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DGV_DTR_MATRIX As System.Windows.Forms.DataGridView
    Friend WithEvents sidePanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents clientPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlClientName As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Client_Name As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlClientAddress As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Client_Address As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlClientId As System.Windows.Forms.Panel
    Friend WithEvents Lbl_ClientID As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlDailyWage As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Client_Daily_Wage As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents exportPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblExportTitle As System.Windows.Forms.Label
    Friend WithEvents btnDtrHrsExport As FontAwesome.Sharp.IconButton
    Friend WithEvents Btn_Export_to_Excell As FontAwesome.Sharp.IconButton
End Class
