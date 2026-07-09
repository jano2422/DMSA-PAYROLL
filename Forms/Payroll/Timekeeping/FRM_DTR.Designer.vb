<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_DTR
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
        Me.LV_EmployeeList = New System.Windows.Forms.ListView()
        Me.Col_CompanyID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.COl_Detachment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Period = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletionStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnShow = New System.Windows.Forms.Button()
        Me.Btn_Encode_DTR = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_Year = New System.Windows.Forms.ComboBox()
        Me.Cmb_Month = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_Pending_DTR = New System.Windows.Forms.CheckBox()
        Me.Cmb_CutOff = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblPeriod = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Btn_LoadDTR = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LV_EmployeeList
        '
        Me.LV_EmployeeList.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_EmployeeList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_CompanyID, Me.Col_Name, Me.COl_Detachment, Me.Col_Period})
        Me.LV_EmployeeList.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_EmployeeList.FullRowSelect = True
        Me.LV_EmployeeList.GridLines = True
        Me.LV_EmployeeList.HideSelection = False
        Me.LV_EmployeeList.Location = New System.Drawing.Point(318, 95)
        Me.LV_EmployeeList.Name = "LV_EmployeeList"
        Me.LV_EmployeeList.Size = New System.Drawing.Size(1105, 612)
        Me.LV_EmployeeList.TabIndex = 2
        Me.LV_EmployeeList.UseCompatibleStateImageBehavior = False
        Me.LV_EmployeeList.View = System.Windows.Forms.View.Details
        '
        'Col_CompanyID
        '
        Me.Col_CompanyID.Text = "Company ID"
        Me.Col_CompanyID.Width = 140
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Name"
        Me.Col_Name.Width = 330
        '
        'COl_Detachment
        '
        Me.COl_Detachment.Text = "Detachment"
        Me.COl_Detachment.Width = 400
        '
        'Col_Period
        '
        Me.Col_Period.Text = "Latest Cut-Off Encoded"
        Me.Col_Period.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Period.Width = 230
        '
        'CmbCategory
        '
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Items.AddRange(New Object() {"", "A.COMPANY_ID", "B.LAST_NAME", "C.CLIENT_NAME"})
        Me.CmbCategory.Location = New System.Drawing.Point(43, 231)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(184, 32)
        Me.CmbCategory.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(39, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 23)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Category"
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(43, 269)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(234, 31)
        Me.TxtSearch.TabIndex = 21
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1449, 24)
        Me.MenuStrip1.TabIndex = 30
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompletionStatusToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'CompletionStatusToolStripMenuItem
        '
        Me.CompletionStatusToolStripMenuItem.Name = "CompletionStatusToolStripMenuItem"
        Me.CompletionStatusToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CompletionStatusToolStripMenuItem.Text = "Completion Status"
        '
        'BtnShow
        '
        Me.BtnShow.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShow.Location = New System.Drawing.Point(561, 47)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(113, 32)
        Me.BtnShow.TabIndex = 31
        Me.BtnShow.Text = "Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'Btn_Encode_DTR
        '
        Me.Btn_Encode_DTR.Enabled = False
        Me.Btn_Encode_DTR.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Encode_DTR.Location = New System.Drawing.Point(1202, 47)
        Me.Btn_Encode_DTR.Name = "Btn_Encode_DTR"
        Me.Btn_Encode_DTR.Size = New System.Drawing.Size(212, 32)
        Me.Btn_Encode_DTR.TabIndex = 32
        Me.Btn_Encode_DTR.Text = "Encode New DTR"
        Me.Btn_Encode_DTR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Aqua
        Me.Label1.Location = New System.Drawing.Point(39, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 23)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Year:"
        '
        'Cmb_Year
        '
        Me.Cmb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Year.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Year.FormattingEnabled = True
        Me.Cmb_Year.Location = New System.Drawing.Point(105, 47)
        Me.Cmb_Year.Name = "Cmb_Year"
        Me.Cmb_Year.Size = New System.Drawing.Size(100, 32)
        Me.Cmb_Year.TabIndex = 34
        '
        'Cmb_Month
        '
        Me.Cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Month.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Month.FormattingEnabled = True
        Me.Cmb_Month.Location = New System.Drawing.Point(293, 47)
        Me.Cmb_Month.Name = "Cmb_Month"
        Me.Cmb_Month.Size = New System.Drawing.Size(100, 32)
        Me.Cmb_Month.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Aqua
        Me.Label2.Location = New System.Drawing.Point(220, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 23)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Month:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(39, 321)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 23)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "DTR Status"
        '
        'Chk_Pending_DTR
        '
        Me.Chk_Pending_DTR.AutoSize = True
        Me.Chk_Pending_DTR.BackColor = System.Drawing.Color.Teal
        Me.Chk_Pending_DTR.Checked = True
        Me.Chk_Pending_DTR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Pending_DTR.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Pending_DTR.ForeColor = System.Drawing.Color.Aqua
        Me.Chk_Pending_DTR.Location = New System.Drawing.Point(54, 361)
        Me.Chk_Pending_DTR.Name = "Chk_Pending_DTR"
        Me.Chk_Pending_DTR.Size = New System.Drawing.Size(223, 22)
        Me.Chk_Pending_DTR.TabIndex = 39
        Me.Chk_Pending_DTR.Text = "DTR pending for encode"
        Me.Chk_Pending_DTR.UseVisualStyleBackColor = False
        '
        'Cmb_CutOff
        '
        Me.Cmb_CutOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_CutOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_CutOff.FormattingEnabled = True
        Me.Cmb_CutOff.Items.AddRange(New Object() {"1st Cut-Off", "2nd Cut-Off"})
        Me.Cmb_CutOff.Location = New System.Drawing.Point(399, 47)
        Me.Cmb_CutOff.Name = "Cmb_CutOff"
        Me.Cmb_CutOff.Size = New System.Drawing.Size(154, 32)
        Me.Cmb_CutOff.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(39, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 23)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Payroll Cut-Off"
        '
        'LblPeriod
        '
        Me.LblPeriod.AutoSize = True
        Me.LblPeriod.BackColor = System.Drawing.Color.Teal
        Me.LblPeriod.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeriod.ForeColor = System.Drawing.Color.White
        Me.LblPeriod.Location = New System.Drawing.Point(51, 159)
        Me.LblPeriod.Name = "LblPeriod"
        Me.LblPeriod.Size = New System.Drawing.Size(19, 23)
        Me.LblPeriod.TabIndex = 45
        Me.LblPeriod.Text = "-"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Teal
        Me.PictureBox3.Location = New System.Drawing.Point(26, 713)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1397, 10)
        Me.PictureBox3.TabIndex = 42
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Teal
        Me.PictureBox1.Location = New System.Drawing.Point(26, 95)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(286, 612)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Btn_LoadDTR
        '
        Me.Btn_LoadDTR.Enabled = False
        Me.Btn_LoadDTR.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LoadDTR.Location = New System.Drawing.Point(984, 47)
        Me.Btn_LoadDTR.Name = "Btn_LoadDTR"
        Me.Btn_LoadDTR.Size = New System.Drawing.Size(212, 32)
        Me.Btn_LoadDTR.TabIndex = 46
        Me.Btn_LoadDTR.Text = "Load DTR"
        Me.Btn_LoadDTR.UseVisualStyleBackColor = True
        '
        'FRM_DTR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1449, 735)
        Me.Controls.Add(Me.Btn_LoadDTR)
        Me.Controls.Add(Me.LblPeriod)
        Me.Controls.Add(Me.Cmb_CutOff)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Chk_Pending_DTR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cmb_Month)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cmb_Year)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Encode_DTR)
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.CmbCategory)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LV_EmployeeList)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_DTR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Date and Time Record of Employee Overview"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LV_EmployeeList As ListView
    Friend WithEvents Col_CompanyID As ColumnHeader
    Friend WithEvents Col_Name As ColumnHeader
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CmbCategory As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BtnShow As Button
    Friend WithEvents Btn_Encode_DTR As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Cmb_Year As ComboBox
    Friend WithEvents Cmb_Month As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Chk_Pending_DTR As CheckBox
    Friend WithEvents COl_Detachment As ColumnHeader
    Friend WithEvents Col_Period As ColumnHeader
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Cmb_CutOff As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LblPeriod As Label
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompletionStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Btn_LoadDTR As Button
End Class
