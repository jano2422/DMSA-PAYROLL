<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_DTR_EMPLOYEE_LIST_ALL
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.Lbl_Title = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_Category = New System.Windows.Forms.ComboBox()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.LV_Employee_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Emp_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ClientCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_SubClient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ClientBranch = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lbl_ResultCount = New System.Windows.Forms.Label()
        Me.Btn_Select = New System.Windows.Forms.Button()
        Me.Btn_Close = New System.Windows.Forms.Button()
        Me.PanelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.Teal
        Me.PanelHeader.Controls.Add(Me.Lbl_Title)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(1060, 48)
        Me.PanelHeader.TabIndex = 0
        '
        'Lbl_Title
        '
        Me.Lbl_Title.AutoSize = True
        Me.Lbl_Title.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Title.ForeColor = System.Drawing.Color.White
        Me.Lbl_Title.Location = New System.Drawing.Point(18, 13)
        Me.Lbl_Title.Name = "Lbl_Title"
        Me.Lbl_Title.Size = New System.Drawing.Size(269, 23)
        Me.Lbl_Title.TabIndex = 0
        Me.Lbl_Title.Text = "DTR Employee Selection"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(24, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Search by"
        '
        'Cmb_Category
        '
        Me.Cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Category.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Category.FormattingEnabled = True
        Me.Cmb_Category.Items.AddRange(New Object() {"EMPLOYEE_ID", "LAST_NAME", "FIRST_NAME", "SUB_CLIENT_NAME", "ADDRESS"})
        Me.Cmb_Category.Location = New System.Drawing.Point(105, 68)
        Me.Cmb_Category.Name = "Cmb_Category"
        Me.Cmb_Category.Size = New System.Drawing.Size(190, 24)
        Me.Cmb_Category.TabIndex = 2
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(307, 68)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(280, 23)
        Me.TxtSearch.TabIndex = 3
        '
        'Btn_Search
        '
        Me.Btn_Search.BackColor = System.Drawing.Color.Teal
        Me.Btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Search.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Search.ForeColor = System.Drawing.Color.White
        Me.Btn_Search.Location = New System.Drawing.Point(596, 65)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(108, 30)
        Me.Btn_Search.TabIndex = 4
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = False
        '
        'LV_Employee_List
        '
        Me.LV_Employee_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Employee_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Employee_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Col_Emp_ID, Me.Col_Name, Me.Col_ClientCode, Me.Col_SubClient, Me.Col_ClientBranch})
        Me.LV_Employee_List.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Employee_List.FullRowSelect = True
        Me.LV_Employee_List.GridLines = True
        Me.LV_Employee_List.HideSelection = False
        Me.LV_Employee_List.Location = New System.Drawing.Point(22, 108)
        Me.LV_Employee_List.MultiSelect = False
        Me.LV_Employee_List.Name = "LV_Employee_List"
        Me.LV_Employee_List.Size = New System.Drawing.Size(1016, 365)
        Me.LV_Employee_List.TabIndex = 5
        Me.LV_Employee_List.UseCompatibleStateImageBehavior = False
        Me.LV_Employee_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Item"
        Me.ColumnHeader1.Width = 55
        '
        'Col_Emp_ID
        '
        Me.Col_Emp_ID.Text = "Emp ID"
        Me.Col_Emp_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Emp_ID.Width = 100
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Name"
        Me.Col_Name.Width = 230
        '
        'Col_ClientCode
        '
        Me.Col_ClientCode.Text = "Sub Client ID"
        Me.Col_ClientCode.Width = 110
        '
        'Col_SubClient
        '
        Me.Col_SubClient.Text = "Sub Client / Detachment"
        Me.Col_SubClient.Width = 310
        '
        'Col_ClientBranch
        '
        Me.Col_ClientBranch.Text = "Address / Branch"
        Me.Col_ClientBranch.Width = 200
        '
        'Lbl_ResultCount
        '
        Me.Lbl_ResultCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_ResultCount.AutoSize = True
        Me.Lbl_ResultCount.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ResultCount.ForeColor = System.Drawing.Color.Teal
        Me.Lbl_ResultCount.Location = New System.Drawing.Point(24, 491)
        Me.Lbl_ResultCount.Name = "Lbl_ResultCount"
        Me.Lbl_ResultCount.Size = New System.Drawing.Size(137, 16)
        Me.Lbl_ResultCount.TabIndex = 6
        Me.Lbl_ResultCount.Text = "Employees found: 0"
        '
        'Btn_Select
        '
        Me.Btn_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Select.BackColor = System.Drawing.Color.Teal
        Me.Btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Select.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Select.ForeColor = System.Drawing.Color.White
        Me.Btn_Select.Location = New System.Drawing.Point(818, 483)
        Me.Btn_Select.Name = "Btn_Select"
        Me.Btn_Select.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Select.TabIndex = 7
        Me.Btn_Select.Text = "Select"
        Me.Btn_Select.UseVisualStyleBackColor = False
        '
        'Btn_Close
        '
        Me.Btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Close.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Close.Location = New System.Drawing.Point(934, 483)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Close.TabIndex = 8
        Me.Btn_Close.Text = "Close"
        Me.Btn_Close.UseVisualStyleBackColor = True
        '
        'FRM_DTR_EMPLOYEE_LIST_ALL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1060, 532)
        Me.Controls.Add(Me.Btn_Close)
        Me.Controls.Add(Me.Btn_Select)
        Me.Controls.Add(Me.Lbl_ResultCount)
        Me.Controls.Add(Me.LV_Employee_List)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.Cmb_Category)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PanelHeader)
        Me.MinimumSize = New System.Drawing.Size(900, 500)
        Me.Name = "FRM_DTR_EMPLOYEE_LIST_ALL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DTR Employee Selection"
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents Lbl_Title As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Cmb_Category As ComboBox
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Btn_Search As Button
    Friend WithEvents LV_Employee_List As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Col_Emp_ID As ColumnHeader
    Friend WithEvents Col_Name As ColumnHeader
    Friend WithEvents Col_ClientCode As ColumnHeader
    Friend WithEvents Col_SubClient As ColumnHeader
    Friend WithEvents Col_ClientBranch As ColumnHeader
    Friend WithEvents Lbl_ResultCount As Label
    Friend WithEvents Btn_Select As Button
    Friend WithEvents Btn_Close As Button
End Class
