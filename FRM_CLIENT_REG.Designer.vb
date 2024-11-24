<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_CLIENT_REG
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
        Me.LV_Main_Client_List = New System.Windows.Forms.ListView()
        Me.Col_ClientID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ClientName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Address = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Btn_Search = New System.Windows.Forms.Button()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Cmb_Category = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LV_Main_Client_List
        '
        Me.LV_Main_Client_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Main_Client_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_ClientID, Me.Col_ClientName, Me.Col_Address})
        Me.LV_Main_Client_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Main_Client_List.FullRowSelect = True
        Me.LV_Main_Client_List.GridLines = True
        Me.LV_Main_Client_List.HideSelection = False
        Me.LV_Main_Client_List.Location = New System.Drawing.Point(12, 61)
        Me.LV_Main_Client_List.Name = "LV_Main_Client_List"
        Me.LV_Main_Client_List.Size = New System.Drawing.Size(734, 472)
        Me.LV_Main_Client_List.TabIndex = 2
        Me.LV_Main_Client_List.UseCompatibleStateImageBehavior = False
        Me.LV_Main_Client_List.View = System.Windows.Forms.View.Details
        '
        'Col_ClientID
        '
        Me.Col_ClientID.Text = "Client ID"
        Me.Col_ClientID.Width = 100
        '
        'Col_ClientName
        '
        Me.Col_ClientName.Text = "Sub Client Name"
        Me.Col_ClientName.Width = 380
        '
        'Col_Address
        '
        Me.Col_Address.Text = "Address"
        Me.Col_Address.Width = 250
        '
        'Btn_Search
        '
        Me.Btn_Search.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Search.Location = New System.Drawing.Point(577, 19)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(97, 30)
        Me.Btn_Search.TabIndex = 52
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'TxtSearch
        '
        Me.TxtSearch.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(337, 18)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(234, 31)
        Me.TxtSearch.TabIndex = 51
        '
        'Cmb_Category
        '
        Me.Cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Category.FormattingEnabled = True
        Me.Cmb_Category.Items.AddRange(New Object() {"SUB_CLIENT_NAME", "ADDRESS"})
        Me.Cmb_Category.Location = New System.Drawing.Point(123, 17)
        Me.Cmb_Category.Name = "Cmb_Category"
        Me.Cmb_Category.Size = New System.Drawing.Size(208, 32)
        Me.Cmb_Category.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Aqua
        Me.Label2.Location = New System.Drawing.Point(13, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Category:"
        '
        'FRM_CLIENT_REG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(761, 546)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.Cmb_Category)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LV_Main_Client_List)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FRM_CLIENT_REG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Detachment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LV_Main_Client_List As ListView
    Friend WithEvents Col_ClientID As ColumnHeader
    Friend WithEvents Col_ClientName As ColumnHeader
    Friend WithEvents Col_Address As ColumnHeader
    Friend WithEvents Btn_Search As Button
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents Cmb_Category As ComboBox
    Friend WithEvents Label2 As Label
End Class
