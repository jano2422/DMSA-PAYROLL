<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSelectionControl
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
        Me.LabelFolder = New System.Windows.Forms.Label()
        Me.Txt_SelectedDirectory = New System.Windows.Forms.TextBox()
        Me.Btn_ReselectFolder = New System.Windows.Forms.Button()
        Me.LabelSearch = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.Btn_Clear = New System.Windows.Forms.Button()
        Me.LV_FileList = New System.Windows.Forms.ListView()
        Me.Col_Item = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_FileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Modified = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lbl_ResultCount = New System.Windows.Forms.Label()
        Me.Lbl_Status = New System.Windows.Forms.Label()
        Me.Btn_Select = New System.Windows.Forms.Button()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
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
        Me.PanelHeader.Size = New System.Drawing.Size(780, 48)
        Me.PanelHeader.TabIndex = 0
        '
        'Lbl_Title
        '
        Me.Lbl_Title.AutoSize = True
        Me.Lbl_Title.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Title.ForeColor = System.Drawing.Color.White
        Me.Lbl_Title.Location = New System.Drawing.Point(18, 13)
        Me.Lbl_Title.Name = "Lbl_Title"
        Me.Lbl_Title.Size = New System.Drawing.Size(204, 23)
        Me.Lbl_Title.TabIndex = 0
        Me.Lbl_Title.Text = "DTR File Selection"
        '
        'LabelFolder
        '
        Me.LabelFolder.AutoSize = True
        Me.LabelFolder.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFolder.ForeColor = System.Drawing.Color.Teal
        Me.LabelFolder.Location = New System.Drawing.Point(24, 67)
        Me.LabelFolder.Name = "LabelFolder"
        Me.LabelFolder.Size = New System.Drawing.Size(53, 16)
        Me.LabelFolder.TabIndex = 1
        Me.LabelFolder.Text = "Folder"
        '
        'Txt_SelectedDirectory
        '
        Me.Txt_SelectedDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_SelectedDirectory.BackColor = System.Drawing.Color.White
        Me.Txt_SelectedDirectory.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SelectedDirectory.Location = New System.Drawing.Point(96, 63)
        Me.Txt_SelectedDirectory.Name = "Txt_SelectedDirectory"
        Me.Txt_SelectedDirectory.ReadOnly = True
        Me.Txt_SelectedDirectory.Size = New System.Drawing.Size(528, 23)
        Me.Txt_SelectedDirectory.TabIndex = 2
        '
        'Btn_ReselectFolder
        '
        Me.Btn_ReselectFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_ReselectFolder.BackColor = System.Drawing.Color.Teal
        Me.Btn_ReselectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_ReselectFolder.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ReselectFolder.ForeColor = System.Drawing.Color.White
        Me.Btn_ReselectFolder.Location = New System.Drawing.Point(636, 60)
        Me.Btn_ReselectFolder.Name = "Btn_ReselectFolder"
        Me.Btn_ReselectFolder.Size = New System.Drawing.Size(120, 30)
        Me.Btn_ReselectFolder.TabIndex = 3
        Me.Btn_ReselectFolder.Text = "Browse"
        Me.Btn_ReselectFolder.UseVisualStyleBackColor = False
        '
        'LabelSearch
        '
        Me.LabelSearch.AutoSize = True
        Me.LabelSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSearch.ForeColor = System.Drawing.Color.Teal
        Me.LabelSearch.Location = New System.Drawing.Point(24, 105)
        Me.LabelSearch.Name = "LabelSearch"
        Me.LabelSearch.Size = New System.Drawing.Size(66, 16)
        Me.LabelSearch.TabIndex = 4
        Me.LabelSearch.Text = "Find file"
        '
        'TxtSearch
        '
        Me.TxtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(96, 101)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(360, 23)
        Me.TxtSearch.TabIndex = 5
        '
        'Btn_Search
        '
        Me.Btn_Search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Search.BackColor = System.Drawing.Color.Teal
        Me.Btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Search.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Search.ForeColor = System.Drawing.Color.White
        Me.Btn_Search.Location = New System.Drawing.Point(468, 98)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(108, 30)
        Me.Btn_Search.TabIndex = 6
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = False
        '
        'Btn_Clear
        '
        Me.Btn_Clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Clear.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Clear.Location = New System.Drawing.Point(588, 98)
        Me.Btn_Clear.Name = "Btn_Clear"
        Me.Btn_Clear.Size = New System.Drawing.Size(84, 30)
        Me.Btn_Clear.TabIndex = 7
        Me.Btn_Clear.Text = "Clear"
        Me.Btn_Clear.UseVisualStyleBackColor = True
        '
        'LV_FileList
        '
        Me.LV_FileList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_FileList.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_FileList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_Item, Me.Col_FileName, Me.Col_Size, Me.Col_Modified})
        Me.LV_FileList.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_FileList.FullRowSelect = True
        Me.LV_FileList.GridLines = True
        Me.LV_FileList.HideSelection = False
        Me.LV_FileList.Location = New System.Drawing.Point(22, 140)
        Me.LV_FileList.MultiSelect = False
        Me.LV_FileList.Name = "LV_FileList"
        Me.LV_FileList.Size = New System.Drawing.Size(734, 280)
        Me.LV_FileList.TabIndex = 8
        Me.LV_FileList.UseCompatibleStateImageBehavior = False
        Me.LV_FileList.View = System.Windows.Forms.View.Details
        '
        'Col_Item
        '
        Me.Col_Item.Text = "Item"
        Me.Col_Item.Width = 55
        '
        'Col_FileName
        '
        Me.Col_FileName.Text = "File Name"
        Me.Col_FileName.Width = 385
        '
        'Col_Size
        '
        Me.Col_Size.Text = "Size"
        Me.Col_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Col_Size.Width = 90
        '
        'Col_Modified
        '
        Me.Col_Modified.Text = "Modified"
        Me.Col_Modified.Width = 170
        '
        'Lbl_ResultCount
        '
        Me.Lbl_ResultCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl_ResultCount.AutoSize = True
        Me.Lbl_ResultCount.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ResultCount.ForeColor = System.Drawing.Color.Teal
        Me.Lbl_ResultCount.Location = New System.Drawing.Point(24, 438)
        Me.Lbl_ResultCount.Name = "Lbl_ResultCount"
        Me.Lbl_ResultCount.Size = New System.Drawing.Size(102, 16)
        Me.Lbl_ResultCount.TabIndex = 9
        Me.Lbl_ResultCount.Text = "Files found: 0"
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Status.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Status.ForeColor = System.Drawing.Color.Maroon
        Me.Lbl_Status.Location = New System.Drawing.Point(154, 438)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(356, 32)
        Me.Lbl_Status.TabIndex = 10
        '
        'Btn_Select
        '
        Me.Btn_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Select.BackColor = System.Drawing.Color.Gainsboro
        Me.Btn_Select.Enabled = False
        Me.Btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Select.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Select.ForeColor = System.Drawing.Color.DimGray
        Me.Btn_Select.Location = New System.Drawing.Point(530, 430)
        Me.Btn_Select.Name = "Btn_Select"
        Me.Btn_Select.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Select.TabIndex = 11
        Me.Btn_Select.Text = "Select"
        Me.Btn_Select.UseVisualStyleBackColor = False
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Cancel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(652, 430)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(104, 32)
        Me.Btn_Cancel.TabIndex = 12
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'FileSelectionControl
        '
        Me.AcceptButton = Me.Btn_Select
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CancelButton = Me.Btn_Cancel
        Me.ClientSize = New System.Drawing.Size(780, 484)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Select)
        Me.Controls.Add(Me.Lbl_Status)
        Me.Controls.Add(Me.Lbl_ResultCount)
        Me.Controls.Add(Me.LV_FileList)
        Me.Controls.Add(Me.Btn_Clear)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.LabelSearch)
        Me.Controls.Add(Me.Btn_ReselectFolder)
        Me.Controls.Add(Me.Txt_SelectedDirectory)
        Me.Controls.Add(Me.LabelFolder)
        Me.Controls.Add(Me.PanelHeader)
        Me.MinimumSize = New System.Drawing.Size(700, 460)
        Me.Name = "FileSelectionControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DTR File Selection"
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents Lbl_Title As Label
    Friend WithEvents LabelFolder As Label
    Friend WithEvents Txt_SelectedDirectory As TextBox
    Friend WithEvents Btn_ReselectFolder As Button
    Friend WithEvents LabelSearch As Label
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Btn_Search As Button
    Friend WithEvents Btn_Clear As Button
    Friend WithEvents LV_FileList As ListView
    Friend WithEvents Col_Item As ColumnHeader
    Friend WithEvents Col_FileName As ColumnHeader
    Friend WithEvents Col_Size As ColumnHeader
    Friend WithEvents Col_Modified As ColumnHeader
    Friend WithEvents Lbl_ResultCount As Label
    Friend WithEvents Lbl_Status As Label
    Friend WithEvents Btn_Select As Button
    Friend WithEvents Btn_Cancel As Button
End Class
