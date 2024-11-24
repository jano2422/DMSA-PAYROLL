<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_DTR_REPORT
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Txt_ClientName = New System.Windows.Forms.TextBox()
        Me.Btn_ShowClientList = New System.Windows.Forms.Button()
        Me.Lbl_Client_Address = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_ExportToExcel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_CutOff = New System.Windows.Forms.ComboBox()
        Me.Cmb_Month = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_Year = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnShow = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LV_EmployeeList = New System.Windows.Forms.ListView()
        Me.ColDTRNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_NoOfDays = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NoOfHours = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Reg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Sun = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_LH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_SH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_NDreg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_NDSun = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_NDLH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_NDSH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_OTReg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_OTSun = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColOTLH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColOTSH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Maroon
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1354, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1328, 673)
        Me.TabControl1.TabIndex = 65
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Txt_ClientName)
        Me.TabPage1.Controls.Add(Me.Btn_ShowClientList)
        Me.TabPage1.Controls.Add(Me.Lbl_Client_Address)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Btn_ExportToExcel)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Cmb_CutOff)
        Me.TabPage1.Controls.Add(Me.Cmb_Month)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Cmb_Year)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.BtnShow)
        Me.TabPage1.Controls.Add(Me.PictureBox2)
        Me.TabPage1.Controls.Add(Me.LV_EmployeeList)
        Me.TabPage1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1320, 647)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report Per Client "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Txt_ClientName
        '
        Me.Txt_ClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClientName.Location = New System.Drawing.Point(164, 35)
        Me.Txt_ClientName.Name = "Txt_ClientName"
        Me.Txt_ClientName.Size = New System.Drawing.Size(468, 29)
        Me.Txt_ClientName.TabIndex = 79
        '
        'Btn_ShowClientList
        '
        Me.Btn_ShowClientList.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_ShowClientList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_ShowClientList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ShowClientList.Location = New System.Drawing.Point(636, 35)
        Me.Btn_ShowClientList.Name = "Btn_ShowClientList"
        Me.Btn_ShowClientList.Size = New System.Drawing.Size(53, 29)
        Me.Btn_ShowClientList.TabIndex = 78
        Me.Btn_ShowClientList.Text = "..."
        Me.Btn_ShowClientList.UseVisualStyleBackColor = False
        '
        'Lbl_Client_Address
        '
        Me.Lbl_Client_Address.AutoSize = True
        Me.Lbl_Client_Address.BackColor = System.Drawing.Color.Teal
        Me.Lbl_Client_Address.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Client_Address.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Lbl_Client_Address.Location = New System.Drawing.Point(160, 76)
        Me.Lbl_Client_Address.Name = "Lbl_Client_Address"
        Me.Lbl_Client_Address.Size = New System.Drawing.Size(157, 23)
        Me.Lbl_Client_Address.TabIndex = 77
        Me.Lbl_Client_Address.Text = "Client Address:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Aqua
        Me.Label4.Location = New System.Drawing.Point(25, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 23)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Address:"
        '
        'Btn_ExportToExcel
        '
        Me.Btn_ExportToExcel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ExportToExcel.Location = New System.Drawing.Point(1068, 129)
        Me.Btn_ExportToExcel.Name = "Btn_ExportToExcel"
        Me.Btn_ExportToExcel.Size = New System.Drawing.Size(225, 36)
        Me.Btn_ExportToExcel.TabIndex = 75
        Me.Btn_ExportToExcel.Text = "Export to Excel"
        Me.Btn_ExportToExcel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Aqua
        Me.Label3.Location = New System.Drawing.Point(25, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 23)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Detachment:"
        '
        'Cmb_CutOff
        '
        Me.Cmb_CutOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_CutOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_CutOff.FormattingEnabled = True
        Me.Cmb_CutOff.Items.AddRange(New Object() {"1-15", "16-30"})
        Me.Cmb_CutOff.Location = New System.Drawing.Point(385, 128)
        Me.Cmb_CutOff.Name = "Cmb_CutOff"
        Me.Cmb_CutOff.Size = New System.Drawing.Size(154, 32)
        Me.Cmb_CutOff.TabIndex = 72
        '
        'Cmb_Month
        '
        Me.Cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Month.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Month.FormattingEnabled = True
        Me.Cmb_Month.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.Cmb_Month.Location = New System.Drawing.Point(279, 128)
        Me.Cmb_Month.Name = "Cmb_Month"
        Me.Cmb_Month.Size = New System.Drawing.Size(100, 32)
        Me.Cmb_Month.TabIndex = 67
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Aqua
        Me.Label2.Location = New System.Drawing.Point(206, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 23)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Month:"
        '
        'Cmb_Year
        '
        Me.Cmb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Year.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Year.FormattingEnabled = True
        Me.Cmb_Year.Location = New System.Drawing.Point(91, 128)
        Me.Cmb_Year.Name = "Cmb_Year"
        Me.Cmb_Year.Size = New System.Drawing.Size(100, 32)
        Me.Cmb_Year.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Aqua
        Me.Label1.Location = New System.Drawing.Point(25, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 23)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Year:"
        '
        'BtnShow
        '
        Me.BtnShow.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShow.Location = New System.Drawing.Point(545, 128)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(87, 32)
        Me.BtnShow.TabIndex = 68
        Me.BtnShow.Text = "Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Teal
        Me.PictureBox2.Location = New System.Drawing.Point(3, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1304, 162)
        Me.PictureBox2.TabIndex = 66
        Me.PictureBox2.TabStop = False
        '
        'LV_EmployeeList
        '
        Me.LV_EmployeeList.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_EmployeeList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColDTRNo, Me.Col_ID, Me.Col_Name, Me.Col_NoOfDays, Me.NoOfHours, Me.Col_Reg, Me.Col_Sun, Me.Col_LH, Me.Col_SH, Me.Col_NDreg, Me.Col_NDSun, Me.Col_NDLH, Me.Col_NDSH, Me.Col_OTReg, Me.Col_OTSun, Me.ColOTLH, Me.ColOTSH})
        Me.LV_EmployeeList.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_EmployeeList.FullRowSelect = True
        Me.LV_EmployeeList.GridLines = True
        Me.LV_EmployeeList.HideSelection = False
        Me.LV_EmployeeList.Location = New System.Drawing.Point(3, 184)
        Me.LV_EmployeeList.Name = "LV_EmployeeList"
        Me.LV_EmployeeList.Size = New System.Drawing.Size(1304, 446)
        Me.LV_EmployeeList.TabIndex = 65
        Me.LV_EmployeeList.UseCompatibleStateImageBehavior = False
        Me.LV_EmployeeList.View = System.Windows.Forms.View.Details
        '
        'ColDTRNo
        '
        Me.ColDTRNo.Text = "DTR No"
        Me.ColDTRNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColDTRNo.Width = 80
        '
        'Col_ID
        '
        Me.Col_ID.Text = "Comp ID"
        Me.Col_ID.Width = 90
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Name"
        Me.Col_Name.Width = 250
        '
        'Col_NoOfDays
        '
        Me.Col_NoOfDays.Text = "Days"
        Me.Col_NoOfDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NoOfHours
        '
        Me.NoOfHours.Text = "Hours"
        Me.NoOfHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Col_Reg
        '
        Me.Col_Reg.Text = "REG"
        Me.Col_Reg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Reg.Width = 50
        '
        'Col_Sun
        '
        Me.Col_Sun.Text = "SUN"
        Me.Col_Sun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Sun.Width = 50
        '
        'Col_LH
        '
        Me.Col_LH.Text = "LH"
        Me.Col_LH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_LH.Width = 50
        '
        'Col_SH
        '
        Me.Col_SH.Text = "SH"
        Me.Col_SH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_SH.Width = 50
        '
        'Col_NDreg
        '
        Me.Col_NDreg.Text = "ND-Reg"
        Me.Col_NDreg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_NDreg.Width = 80
        '
        'Col_NDSun
        '
        Me.Col_NDSun.Text = "ND-Sun"
        Me.Col_NDSun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_NDSun.Width = 80
        '
        'Col_NDLH
        '
        Me.Col_NDLH.Text = "ND-LH"
        Me.Col_NDLH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_NDLH.Width = 80
        '
        'Col_NDSH
        '
        Me.Col_NDSH.Text = "ND-SH"
        Me.Col_NDSH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_NDSH.Width = 80
        '
        'Col_OTReg
        '
        Me.Col_OTReg.Text = "OT-Reg"
        Me.Col_OTReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_OTReg.Width = 80
        '
        'Col_OTSun
        '
        Me.Col_OTSun.Text = "OT-Sun"
        Me.Col_OTSun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_OTSun.Width = 80
        '
        'ColOTLH
        '
        Me.ColOTLH.Text = "OT-LH"
        Me.ColOTLH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColOTLH.Width = 80
        '
        'ColOTSH
        '
        Me.ColOTSH.Text = "OT-SH"
        Me.ColOTSH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColOTSH.Width = 80
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1320, 647)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Individual Payslip"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FRM_DTR_REPORT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1354, 727)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_DTR_REPORT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export to Excel"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Btn_ExportToExcel As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_CutOff As ComboBox
    Friend WithEvents Cmb_Month As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Cmb_Year As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnShow As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents LV_EmployeeList As ListView
    Friend WithEvents Col_ID As ColumnHeader
    Friend WithEvents Col_Name As ColumnHeader
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Lbl_Client_Address As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Btn_ShowClientList As Button
    Friend WithEvents Txt_ClientName As TextBox
    Friend WithEvents Col_NoOfDays As ColumnHeader
    Friend WithEvents NoOfHours As ColumnHeader
    Friend WithEvents Col_Reg As ColumnHeader
    Friend WithEvents Col_Sun As ColumnHeader
    Friend WithEvents Col_LH As ColumnHeader
    Friend WithEvents Col_SH As ColumnHeader
    Friend WithEvents Col_NDreg As ColumnHeader
    Friend WithEvents Col_NDSun As ColumnHeader
    Friend WithEvents Col_NDLH As ColumnHeader
    Friend WithEvents Col_NDSH As ColumnHeader
    Friend WithEvents Col_OTReg As ColumnHeader
    Friend WithEvents Col_OTSun As ColumnHeader
    Friend WithEvents ColOTLH As ColumnHeader
    Friend WithEvents ColOTSH As ColumnHeader
    Friend WithEvents ColDTRNo As ColumnHeader
End Class
