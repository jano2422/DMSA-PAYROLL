<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_DTR_EXPORTS
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DGV_DTR_Per_Client = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DGV_DTR_MATRIX = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Client = New System.Windows.Forms.Button()
        Me.Btn_Export_to_Excell = New FontAwesome.Sharp.IconButton()
        Me.Cmb_CutOff = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Cmb_Month = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Year = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_Show = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Lbl_Client_Name = New System.Windows.Forms.Label()
        Me.Lbl_Client_Address = New System.Windows.Forms.Label()
        Me.Lbl_ClientID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnDtrHrsExport = New FontAwesome.Sharp.IconButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGV_DTR_Per_Client, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGV_DTR_MATRIX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1460, 32)
        Me.Panel1.TabIndex = 6
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(29, 279)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1399, 529)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DGV_DTR_Per_Client)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1391, 496)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Per Client"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DGV_DTR_Per_Client
        '
        Me.DGV_DTR_Per_Client.AllowUserToAddRows = False
        Me.DGV_DTR_Per_Client.AllowUserToDeleteRows = False
        Me.DGV_DTR_Per_Client.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV_DTR_Per_Client.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DGV_DTR_Per_Client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DTR_Per_Client.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DGV_DTR_Per_Client.Location = New System.Drawing.Point(6, 20)
        Me.DGV_DTR_Per_Client.Name = "DGV_DTR_Per_Client"
        Me.DGV_DTR_Per_Client.ReadOnly = True
        Me.DGV_DTR_Per_Client.Size = New System.Drawing.Size(1376, 455)
        Me.DGV_DTR_Per_Client.TabIndex = 70
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DGV_DTR_MATRIX)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1391, 496)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Hours Per Day"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DGV_DTR_MATRIX
        '
        Me.DGV_DTR_MATRIX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV_DTR_MATRIX.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DGV_DTR_MATRIX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_DTR_MATRIX.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DGV_DTR_MATRIX.Location = New System.Drawing.Point(6, 6)
        Me.DGV_DTR_MATRIX.Name = "DGV_DTR_MATRIX"
        Me.DGV_DTR_MATRIX.Size = New System.Drawing.Size(1379, 484)
        Me.DGV_DTR_MATRIX.TabIndex = 72
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Teal
        Me.PictureBox1.Location = New System.Drawing.Point(29, 167)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1395, 106)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(56, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 23)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Client Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(56, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 23)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Client Address:"
        '
        'Btn_Client
        '
        Me.Btn_Client.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Client.ForeColor = System.Drawing.Color.Black
        Me.Btn_Client.Location = New System.Drawing.Point(297, 52)
        Me.Btn_Client.Name = "Btn_Client"
        Me.Btn_Client.Size = New System.Drawing.Size(176, 36)
        Me.Btn_Client.TabIndex = 598
        Me.Btn_Client.Text = "Select Client"
        Me.Btn_Client.UseVisualStyleBackColor = True
        '
        'Btn_Export_to_Excell
        '
        Me.Btn_Export_to_Excell.IconChar = FontAwesome.Sharp.IconChar.FileDownload
        Me.Btn_Export_to_Excell.IconColor = System.Drawing.Color.Green
        Me.Btn_Export_to_Excell.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Btn_Export_to_Excell.IconSize = 40
        Me.Btn_Export_to_Excell.Location = New System.Drawing.Point(1314, 186)
        Me.Btn_Export_to_Excell.Name = "Btn_Export_to_Excell"
        Me.Btn_Export_to_Excell.Size = New System.Drawing.Size(94, 67)
        Me.Btn_Export_to_Excell.TabIndex = 599
        Me.Btn_Export_to_Excell.Text = "Export Payroll"
        Me.Btn_Export_to_Excell.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Export_to_Excell.UseVisualStyleBackColor = True
        '
        'Cmb_CutOff
        '
        Me.Cmb_CutOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_CutOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_CutOff.FormattingEnabled = True
        Me.Cmb_CutOff.Items.AddRange(New Object() {"1st Cut-Off", "2nd Cut-Off"})
        Me.Cmb_CutOff.Location = New System.Drawing.Point(130, 52)
        Me.Cmb_CutOff.Name = "Cmb_CutOff"
        Me.Cmb_CutOff.Size = New System.Drawing.Size(134, 28)
        Me.Cmb_CutOff.TabIndex = 600
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Black
        Me.Label10.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(49, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 18)
        Me.Label10.TabIndex = 601
        Me.Label10.Text = "Cut-Off:"
        '
        'Cmb_Month
        '
        Me.Cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Month.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Month.FormattingEnabled = True
        Me.Cmb_Month.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL" & Global.Microsoft.VisualBasic.ChrW(9), "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.Cmb_Month.Location = New System.Drawing.Point(130, 86)
        Me.Cmb_Month.Name = "Cmb_Month"
        Me.Cmb_Month.Size = New System.Drawing.Size(134, 28)
        Me.Cmb_Month.TabIndex = 602
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(49, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 18)
        Me.Label3.TabIndex = 603
        Me.Label3.Text = "Month:"
        '
        'Cmb_Year
        '
        Me.Cmb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Year.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Year.FormattingEnabled = True
        Me.Cmb_Year.Items.AddRange(New Object() {"2024", "2025", "2026"})
        Me.Cmb_Year.Location = New System.Drawing.Point(130, 120)
        Me.Cmb_Year.Name = "Cmb_Year"
        Me.Cmb_Year.Size = New System.Drawing.Size(134, 28)
        Me.Cmb_Year.TabIndex = 604
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(49, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 18)
        Me.Label4.TabIndex = 605
        Me.Label4.Text = "Year:"
        '
        'Btn_Show
        '
        Me.Btn_Show.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Show.ForeColor = System.Drawing.Color.Black
        Me.Btn_Show.Location = New System.Drawing.Point(297, 111)
        Me.Btn_Show.Name = "Btn_Show"
        Me.Btn_Show.Size = New System.Drawing.Size(176, 37)
        Me.Btn_Show.TabIndex = 606
        Me.Btn_Show.Text = "Show Records"
        Me.Btn_Show.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(1337, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 18)
        Me.Label5.TabIndex = 607
        Me.Label5.Text = "Pure Gold"
        '
        'Lbl_Client_Name
        '
        Me.Lbl_Client_Name.AutoSize = True
        Me.Lbl_Client_Name.BackColor = System.Drawing.Color.Teal
        Me.Lbl_Client_Name.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Client_Name.ForeColor = System.Drawing.Color.White
        Me.Lbl_Client_Name.Location = New System.Drawing.Point(229, 194)
        Me.Lbl_Client_Name.Name = "Lbl_Client_Name"
        Me.Lbl_Client_Name.Size = New System.Drawing.Size(0, 23)
        Me.Lbl_Client_Name.TabIndex = 608
        '
        'Lbl_Client_Address
        '
        Me.Lbl_Client_Address.AutoSize = True
        Me.Lbl_Client_Address.BackColor = System.Drawing.Color.Teal
        Me.Lbl_Client_Address.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Client_Address.ForeColor = System.Drawing.Color.White
        Me.Lbl_Client_Address.Location = New System.Drawing.Point(229, 230)
        Me.Lbl_Client_Address.Name = "Lbl_Client_Address"
        Me.Lbl_Client_Address.Size = New System.Drawing.Size(0, 23)
        Me.Lbl_Client_Address.TabIndex = 609
        '
        'Lbl_ClientID
        '
        Me.Lbl_ClientID.AutoSize = True
        Me.Lbl_ClientID.BackColor = System.Drawing.Color.Teal
        Me.Lbl_ClientID.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ClientID.ForeColor = System.Drawing.Color.White
        Me.Lbl_ClientID.Location = New System.Drawing.Point(911, 230)
        Me.Lbl_ClientID.Name = "Lbl_ClientID"
        Me.Lbl_ClientID.Size = New System.Drawing.Size(0, 23)
        Me.Lbl_ClientID.TabIndex = 611
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Teal
        Me.Label7.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(801, 230)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 610
        Me.Label7.Text = "Client ID:"
        '
        'btnDtrHrsExport
        '
        Me.btnDtrHrsExport.IconChar = FontAwesome.Sharp.IconChar.ClockFour
        Me.btnDtrHrsExport.IconColor = System.Drawing.Color.Green
        Me.btnDtrHrsExport.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnDtrHrsExport.IconSize = 40
        Me.btnDtrHrsExport.Location = New System.Drawing.Point(1194, 186)
        Me.btnDtrHrsExport.Name = "btnDtrHrsExport"
        Me.btnDtrHrsExport.Size = New System.Drawing.Size(102, 67)
        Me.btnDtrHrsExport.TabIndex = 612
        Me.btnDtrHrsExport.Text = "Export DTR Hours"
        Me.btnDtrHrsExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDtrHrsExport.UseVisualStyleBackColor = True
        '
        'FRM_DTR_EXPORTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1460, 837)
        Me.Controls.Add(Me.btnDtrHrsExport)
        Me.Controls.Add(Me.Lbl_ClientID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Lbl_Client_Address)
        Me.Controls.Add(Me.Lbl_Client_Name)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Btn_Show)
        Me.Controls.Add(Me.Cmb_Year)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Cmb_Month)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cmb_CutOff)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Btn_Export_to_Excell)
        Me.Controls.Add(Me.Btn_Client)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FRM_DTR_EXPORTS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DTR Exports"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DGV_DTR_Per_Client, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DGV_DTR_MATRIX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DGV_DTR_Per_Client As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Client As Button
    Friend WithEvents Btn_Export_to_Excell As IconButton
    Friend WithEvents Cmb_CutOff As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Cmb_Month As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_Year As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Btn_Show As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Lbl_Client_Name As Label
    Friend WithEvents Lbl_Client_Address As Label
    Friend WithEvents Lbl_ClientID As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DGV_DTR_MATRIX As DataGridView
    Friend WithEvents btnDtrHrsExport As IconButton
End Class
