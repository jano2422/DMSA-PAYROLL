<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_USER_CREATOR
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
        Me.LabelSearchBy = New System.Windows.Forms.Label()
        Me.Cmb_Category = New System.Windows.Forms.ComboBox()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.LV_AccountList = New System.Windows.Forms.ListView()
        Me.Col_Item = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_UserLevel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lbl_ResultCount = New System.Windows.Forms.Label()
        Me.PanelDetails = New System.Windows.Forms.Panel()
        Me.Lbl_DefaultPassword = New System.Windows.Forms.Label()
        Me.Cmb_UserLevel = New System.Windows.Forms.ComboBox()
        Me.LabelUserLevel = New System.Windows.Forms.Label()
        Me.Txt_UserID = New System.Windows.Forms.TextBox()
        Me.LabelUserId = New System.Windows.Forms.Label()
        Me.Lbl_DetailsTitle = New System.Windows.Forms.Label()
        Me.Btn_Create = New System.Windows.Forms.Button()
        Me.Btn_Update = New System.Windows.Forms.Button()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Close = New System.Windows.Forms.Button()
        Me.PanelHeader.SuspendLayout()
        Me.PanelDetails.SuspendLayout()
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
        Me.Lbl_Title.Size = New System.Drawing.Size(276, 23)
        Me.Lbl_Title.TabIndex = 0
        Me.Lbl_Title.Text = "User Account Management"
        '
        'LabelSearchBy
        '
        Me.LabelSearchBy.AutoSize = True
        Me.LabelSearchBy.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSearchBy.ForeColor = System.Drawing.Color.Teal
        Me.LabelSearchBy.Location = New System.Drawing.Point(24, 72)
        Me.LabelSearchBy.Name = "LabelSearchBy"
        Me.LabelSearchBy.Size = New System.Drawing.Size(75, 16)
        Me.LabelSearchBy.TabIndex = 1
        Me.LabelSearchBy.Text = "Search by"
        '
        'Cmb_Category
        '
        Me.Cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Category.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Category.FormattingEnabled = True
        Me.Cmb_Category.Items.AddRange(New Object() {"COMPANY_ID", "EMPLOYEE_NAME", "USER_LEVEL"})
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
        'LV_AccountList
        '
        Me.LV_AccountList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_AccountList.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_AccountList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_Item, Me.Col_ID, Me.Col_Name, Me.Col_UserLevel})
        Me.LV_AccountList.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_AccountList.FullRowSelect = True
        Me.LV_AccountList.GridLines = True
        Me.LV_AccountList.HideSelection = False
        Me.LV_AccountList.Location = New System.Drawing.Point(22, 108)
        Me.LV_AccountList.MultiSelect = False
        Me.LV_AccountList.Name = "LV_AccountList"
        Me.LV_AccountList.Size = New System.Drawing.Size(1016, 275)
        Me.LV_AccountList.TabIndex = 5
        Me.LV_AccountList.UseCompatibleStateImageBehavior = False
        Me.LV_AccountList.View = System.Windows.Forms.View.Details
        '
        'Col_Item
        '
        Me.Col_Item.Text = "Item"
        Me.Col_Item.Width = 55
        '
        'Col_ID
        '
        Me.Col_ID.Text = "Company ID"
        Me.Col_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_ID.Width = 150
        '
        'Col_Name
        '
        Me.Col_Name.Text = "Employee Name"
        Me.Col_Name.Width = 500
        '
        'Col_UserLevel
        '
        Me.Col_UserLevel.Text = "User Level"
        Me.Col_UserLevel.Width = 250
        '
        'Lbl_ResultCount
        '
        Me.Lbl_ResultCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_ResultCount.AutoSize = True
        Me.Lbl_ResultCount.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ResultCount.ForeColor = System.Drawing.Color.Teal
        Me.Lbl_ResultCount.Location = New System.Drawing.Point(24, 397)
        Me.Lbl_ResultCount.Name = "Lbl_ResultCount"
        Me.Lbl_ResultCount.Size = New System.Drawing.Size(107, 16)
        Me.Lbl_ResultCount.TabIndex = 6
        Me.Lbl_ResultCount.Text = "Users found: 0"
        '
        'PanelDetails
        '
        Me.PanelDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDetails.Controls.Add(Me.Lbl_DefaultPassword)
        Me.PanelDetails.Controls.Add(Me.Cmb_UserLevel)
        Me.PanelDetails.Controls.Add(Me.LabelUserLevel)
        Me.PanelDetails.Controls.Add(Me.Txt_UserID)
        Me.PanelDetails.Controls.Add(Me.LabelUserId)
        Me.PanelDetails.Controls.Add(Me.Lbl_DetailsTitle)
        Me.PanelDetails.Location = New System.Drawing.Point(22, 424)
        Me.PanelDetails.Name = "PanelDetails"
        Me.PanelDetails.Size = New System.Drawing.Size(650, 96)
        Me.PanelDetails.TabIndex = 7
        '
        'Lbl_DefaultPassword
        '
        Me.Lbl_DefaultPassword.AutoSize = True
        Me.Lbl_DefaultPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_DefaultPassword.ForeColor = System.Drawing.Color.DimGray
        Me.Lbl_DefaultPassword.Location = New System.Drawing.Point(128, 68)
        Me.Lbl_DefaultPassword.Name = "Lbl_DefaultPassword"
        Me.Lbl_DefaultPassword.Size = New System.Drawing.Size(307, 13)
        Me.Lbl_DefaultPassword.TabIndex = 5
        Me.Lbl_DefaultPassword.Text = "New accounts use the default password: welcome"
        '
        'Cmb_UserLevel
        '
        Me.Cmb_UserLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_UserLevel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_UserLevel.FormattingEnabled = True
        Me.Cmb_UserLevel.Items.AddRange(New Object() {"User", "Administrator"})
        Me.Cmb_UserLevel.Location = New System.Drawing.Point(421, 34)
        Me.Cmb_UserLevel.Name = "Cmb_UserLevel"
        Me.Cmb_UserLevel.Size = New System.Drawing.Size(190, 24)
        Me.Cmb_UserLevel.TabIndex = 4
        '
        'LabelUserLevel
        '
        Me.LabelUserLevel.AutoSize = True
        Me.LabelUserLevel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUserLevel.ForeColor = System.Drawing.Color.Teal
        Me.LabelUserLevel.Location = New System.Drawing.Point(322, 38)
        Me.LabelUserLevel.Name = "LabelUserLevel"
        Me.LabelUserLevel.Size = New System.Drawing.Size(84, 16)
        Me.LabelUserLevel.TabIndex = 3
        Me.LabelUserLevel.Text = "User Level"
        '
        'Txt_UserID
        '
        Me.Txt_UserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_UserID.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UserID.Location = New System.Drawing.Point(131, 35)
        Me.Txt_UserID.Name = "Txt_UserID"
        Me.Txt_UserID.Size = New System.Drawing.Size(170, 23)
        Me.Txt_UserID.TabIndex = 2
        '
        'LabelUserId
        '
        Me.LabelUserId.AutoSize = True
        Me.LabelUserId.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUserId.ForeColor = System.Drawing.Color.Teal
        Me.LabelUserId.Location = New System.Drawing.Point(19, 38)
        Me.LabelUserId.Name = "LabelUserId"
        Me.LabelUserId.Size = New System.Drawing.Size(91, 16)
        Me.LabelUserId.TabIndex = 1
        Me.LabelUserId.Text = "Company ID"
        '
        'Lbl_DetailsTitle
        '
        Me.Lbl_DetailsTitle.AutoSize = True
        Me.Lbl_DetailsTitle.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_DetailsTitle.ForeColor = System.Drawing.Color.Maroon
        Me.Lbl_DetailsTitle.Location = New System.Drawing.Point(14, 10)
        Me.Lbl_DetailsTitle.Name = "Lbl_DetailsTitle"
        Me.Lbl_DetailsTitle.Size = New System.Drawing.Size(120, 16)
        Me.Lbl_DetailsTitle.TabIndex = 0
        Me.Lbl_DetailsTitle.Text = "Account Details"
        '
        'Btn_Create
        '
        Me.Btn_Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Create.BackColor = System.Drawing.Color.Teal
        Me.Btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Create.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Create.ForeColor = System.Drawing.Color.White
        Me.Btn_Create.Location = New System.Drawing.Point(698, 424)
        Me.Btn_Create.Name = "Btn_Create"
        Me.Btn_Create.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Create.TabIndex = 8
        Me.Btn_Create.Text = "Create"
        Me.Btn_Create.UseVisualStyleBackColor = False
        '
        'Btn_Update
        '
        Me.Btn_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Update.BackColor = System.Drawing.Color.Gainsboro
        Me.Btn_Update.Enabled = False
        Me.Btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Update.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Update.ForeColor = System.Drawing.Color.DimGray
        Me.Btn_Update.Location = New System.Drawing.Point(814, 424)
        Me.Btn_Update.Name = "Btn_Update"
        Me.Btn_Update.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Update.TabIndex = 9
        Me.Btn_Update.Text = "Update"
        Me.Btn_Update.UseVisualStyleBackColor = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Delete.BackColor = System.Drawing.Color.Gainsboro
        Me.Btn_Delete.Enabled = False
        Me.Btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Delete.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.ForeColor = System.Drawing.Color.DimGray
        Me.Btn_Delete.Location = New System.Drawing.Point(934, 424)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Delete.TabIndex = 10
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = False
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Cancel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(814, 488)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Cancel.TabIndex = 11
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_Close
        '
        Me.Btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Close.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Close.Location = New System.Drawing.Point(934, 488)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Close.TabIndex = 12
        Me.Btn_Close.Text = "Close"
        Me.Btn_Close.UseVisualStyleBackColor = True
        '
        'FRM_USER_CREATOR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1060, 542)
        Me.Controls.Add(Me.Btn_Close)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Update)
        Me.Controls.Add(Me.Btn_Create)
        Me.Controls.Add(Me.PanelDetails)
        Me.Controls.Add(Me.Lbl_ResultCount)
        Me.Controls.Add(Me.LV_AccountList)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.Cmb_Category)
        Me.Controls.Add(Me.LabelSearchBy)
        Me.Controls.Add(Me.PanelHeader)
        Me.MinimumSize = New System.Drawing.Size(900, 520)
        Me.Name = "FRM_USER_CREATOR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Account Management"
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.PanelDetails.ResumeLayout(False)
        Me.PanelDetails.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents Lbl_Title As Label
    Friend WithEvents LabelSearchBy As Label
    Friend WithEvents Cmb_Category As ComboBox
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Btn_Search As Button
    Friend WithEvents LV_AccountList As ListView
    Friend WithEvents Col_Item As ColumnHeader
    Friend WithEvents Col_ID As ColumnHeader
    Friend WithEvents Col_Name As ColumnHeader
    Friend WithEvents Col_UserLevel As ColumnHeader
    Friend WithEvents Lbl_ResultCount As Label
    Friend WithEvents PanelDetails As Panel
    Friend WithEvents Lbl_DefaultPassword As Label
    Friend WithEvents Cmb_UserLevel As ComboBox
    Friend WithEvents LabelUserLevel As Label
    Friend WithEvents Txt_UserID As TextBox
    Friend WithEvents LabelUserId As Label
    Friend WithEvents Lbl_DetailsTitle As Label
    Friend WithEvents Btn_Create As Button
    Friend WithEvents Btn_Update As Button
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Close As Button
End Class
