<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_LOAN
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
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Cmb_Category = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Edit = New System.Windows.Forms.Button()
        Me.Btn_New = New System.Windows.Forms.Button()
        Me.LV_Loan_List = New System.Windows.Forms.ListView()
        Me.Col_Loan_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_CompanyID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_LoanType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_LoanAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Start_deduct = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Status1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Txt_LoanAmount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_LoanType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Maroon
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1275, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Btn_Search
        '
        Me.Btn_Search.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(547, 44)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(97, 30)
        Me.Btn_Search.TabIndex = 57
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(307, 43)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(234, 31)
        Me.TxtSearch.TabIndex = 56
        '
        'Cmb_Category
        '
        Me.Cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Category.FormattingEnabled = True
        Me.Cmb_Category.Items.AddRange(New Object() {"COMPANY_ID", "CLIENT_NAME", "LAST_NAME"})
        Me.Cmb_Category.Location = New System.Drawing.Point(131, 42)
        Me.Cmb_Category.Name = "Cmb_Category"
        Me.Cmb_Category.Size = New System.Drawing.Size(170, 32)
        Me.Cmb_Category.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Aqua
        Me.Label2.Location = New System.Drawing.Point(21, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Category:"
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Enabled = False
        Me.Btn_Delete.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(322, 659)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(134, 40)
        Me.Btn_Delete.TabIndex = 53
        Me.Btn_Delete.Text = "DELETE"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Enabled = False
        Me.Btn_Edit.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit.Location = New System.Drawing.Point(170, 659)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(134, 40)
        Me.Btn_Edit.TabIndex = 52
        Me.Btn_Edit.Text = "EDIT"
        Me.Btn_Edit.UseVisualStyleBackColor = True
        '
        'Btn_New
        '
        Me.Btn_New.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_New.Location = New System.Drawing.Point(21, 659)
        Me.Btn_New.Name = "Btn_New"
        Me.Btn_New.Size = New System.Drawing.Size(134, 40)
        Me.Btn_New.TabIndex = 51
        Me.Btn_New.Text = "NEW"
        Me.Btn_New.UseVisualStyleBackColor = True
        '
        'LV_Loan_List
        '
        Me.LV_Loan_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Loan_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_Loan_ID, Me.Col_CompanyID, Me.Col_Name, Me.Col_LoanType, Me.Col_LoanAmount, Me.Col_Balance, Me.Col_Start_deduct, Me.Col_Status1})
        Me.LV_Loan_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Loan_List.FullRowSelect = True
        Me.LV_Loan_List.GridLines = True
        Me.LV_Loan_List.HideSelection = False
        Me.LV_Loan_List.Location = New System.Drawing.Point(21, 88)
        Me.LV_Loan_List.Name = "LV_Loan_List"
        Me.LV_Loan_List.Size = New System.Drawing.Size(1231, 472)
        Me.LV_Loan_List.TabIndex = 49
        Me.LV_Loan_List.UseCompatibleStateImageBehavior = False
        Me.LV_Loan_List.View = System.Windows.Forms.View.Details
        '
        'Col_Loan_ID
        '
        Me.Col_Loan_ID.Text = "Loan ID"
        Me.Col_Loan_ID.Width = 100
        '
        'Col_CompanyID
        '
        Me.Col_CompanyID.Text = "Company ID"
        Me.Col_CompanyID.Width = 120
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Name"
        Me.Col_Name.Width = 270
        '
        'Col_LoanType
        '
        Me.Col_LoanType.Text = "Loan Type"
        Me.Col_LoanType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_LoanType.Width = 180
        '
        'Col_LoanAmount
        '
        Me.Col_LoanAmount.Text = "Amount"
        Me.Col_LoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Col_LoanAmount.Width = 160
        '
        'Col_Balance
        '
        Me.Col_Balance.Text = "Balance"
        Me.Col_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Col_Balance.Width = 150
        '
        'Col_Start_deduct
        '
        Me.Col_Start_deduct.Text = "Start Deduction"
        Me.Col_Start_deduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Start_deduct.Width = 140
        '
        'Col_Status1
        '
        Me.Col_Status1.Text = "Status"
        Me.Col_Status1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Status1.Width = 120
        '
        'Txt_LoanAmount
        '
        Me.Txt_LoanAmount.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LoanAmount.Location = New System.Drawing.Point(593, 585)
        Me.Txt_LoanAmount.Name = "Txt_LoanAmount"
        Me.Txt_LoanAmount.Size = New System.Drawing.Size(125, 31)
        Me.Txt_LoanAmount.TabIndex = 66
        Me.Txt_LoanAmount.Text = "0"
        Me.Txt_LoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Aqua
        Me.Label3.Location = New System.Drawing.Point(449, 590)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 23)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Loan Amount:"
        '
        'Cmb_LoanType
        '
        Me.Cmb_LoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_LoanType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_LoanType.FormattingEnabled = True
        Me.Cmb_LoanType.Items.AddRange(New Object() {"SSS Salary Loan", "SSS Calamity Loan", "Pagibig Salary Loan", "Pagibig Calamity Loan"})
        Me.Cmb_LoanType.Location = New System.Drawing.Point(172, 585)
        Me.Cmb_LoanType.Name = "Cmb_LoanType"
        Me.Cmb_LoanType.Size = New System.Drawing.Size(234, 32)
        Me.Cmb_LoanType.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Aqua
        Me.Label1.Location = New System.Drawing.Point(50, 589)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 23)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Loan Type:"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Teal
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(21, 566)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1231, 78)
        Me.PictureBox2.TabIndex = 62
        Me.PictureBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Aqua
        Me.Label4.Location = New System.Drawing.Point(757, 588)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(198, 23)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Start Of Deduction:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.ComboBox1.Location = New System.Drawing.Point(957, 585)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(159, 32)
        Me.ComboBox1.TabIndex = 68
        '
        'FRM_LOAN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1275, 721)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_LoanAmount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cmb_LoanType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.Cmb_Category)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Edit)
        Me.Controls.Add(Me.Btn_New)
        Me.Controls.Add(Me.LV_Loan_List)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_LOAN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Loan Registration"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Btn_Search As Button
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Cmb_Category As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Edit As Button
    Friend WithEvents Btn_New As Button
    Friend WithEvents LV_Loan_List As ListView
    Friend WithEvents Col_CompanyID As ColumnHeader
    Friend WithEvents Col_Name As ColumnHeader
    Friend WithEvents Col_LoanType As ColumnHeader
    Friend WithEvents Col_LoanAmount As ColumnHeader
    Friend WithEvents Col_Start_deduct As ColumnHeader
    Friend WithEvents Col_Balance As ColumnHeader
    Friend WithEvents Txt_LoanAmount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_LoanType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Col_Loan_ID As ColumnHeader
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Col_Status1 As ColumnHeader
End Class
