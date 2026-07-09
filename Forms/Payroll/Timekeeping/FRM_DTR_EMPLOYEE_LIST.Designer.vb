<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_DTR_EMPLOYEE_LIST
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LV_Employee_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Emp_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ClientCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_SubClient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ClientBranch = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Cmb_Category = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(35, 450)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(258, 18)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Puregold Security Guards only."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1020, 30)
        Me.Panel1.TabIndex = 62
        '
        'LV_Employee_List
        '
        Me.LV_Employee_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Employee_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Col_Emp_ID, Me.Col_Name, Me.Col_ClientCode, Me.Col_SubClient, Me.Col_ClientBranch})
        Me.LV_Employee_List.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Employee_List.FullRowSelect = True
        Me.LV_Employee_List.GridLines = True
        Me.LV_Employee_List.HideSelection = False
        Me.LV_Employee_List.Location = New System.Drawing.Point(28, 99)
        Me.LV_Employee_List.Name = "LV_Employee_List"
        Me.LV_Employee_List.Size = New System.Drawing.Size(956, 329)
        Me.LV_Employee_List.TabIndex = 57
        Me.LV_Employee_List.UseCompatibleStateImageBehavior = False
        Me.LV_Employee_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Item"
        '
        'Col_Emp_ID
        '
        Me.Col_Emp_ID.Text = "Emp ID"
        Me.Col_Emp_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Emp_ID.Width = 90
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Name"
        Me.Col_Name.Width = 200
        '
        'Col_ClientCode
        '
        Me.Col_ClientCode.Text = "Sub Client ID"
        Me.Col_ClientCode.Width = 100
        '
        'Col_SubClient
        '
        Me.Col_SubClient.Text = "Sub Client"
        Me.Col_SubClient.Width = 300
        '
        'Col_ClientBranch
        '
        Me.Col_ClientBranch.Text = "Address / Branch"
        Me.Col_ClientBranch.Width = 200
        '
        'Btn_Search
        '
        Me.Btn_Search.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(613, 57)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(109, 30)
        Me.Btn_Search.TabIndex = 61
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(373, 58)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(234, 27)
        Me.TxtSearch.TabIndex = 60
        '
        'Cmb_Category
        '
        Me.Cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Category.FormattingEnabled = True
        Me.Cmb_Category.Items.AddRange(New Object() {"EMPLOYEE_ID", "LAST_NAME", "FIRST_NAME", "ADDRESS"})
        Me.Cmb_Category.Location = New System.Drawing.Point(138, 57)
        Me.Cmb_Category.Name = "Cmb_Category"
        Me.Cmb_Category.Size = New System.Drawing.Size(229, 28)
        Me.Cmb_Category.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Aqua
        Me.Label2.Location = New System.Drawing.Point(35, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 18)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Category:"
        '
        'FRM_DTR_EMPLOYEE_LIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 498)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LV_Employee_List)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.Cmb_Category)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FRM_DTR_EMPLOYEE_LIST"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pure Gold Employees"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LV_Employee_List As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Col_Emp_ID As ColumnHeader
    Friend WithEvents Col_Name As ColumnHeader
    Friend WithEvents Col_ClientCode As ColumnHeader
    Friend WithEvents Col_SubClient As ColumnHeader
    Friend WithEvents Col_ClientBranch As ColumnHeader
    Friend WithEvents Btn_Search As Button
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Cmb_Category As ComboBox
    Friend WithEvents Label2 As Label
End Class
