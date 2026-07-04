<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppNotificationDialog
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
        Me.rootPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.headerPanel = New System.Windows.Forms.Panel()
        Me.Btn_Close = New System.Windows.Forms.Button()
        Me.Lbl_Title = New System.Windows.Forms.Label()
        Me.bodyPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.accentPanel = New System.Windows.Forms.Panel()
        Me.Lbl_Icon = New System.Windows.Forms.Label()
        Me.Lbl_Message = New System.Windows.Forms.Label()
        Me.footerPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.rootPanel.SuspendLayout()
        Me.headerPanel.SuspendLayout()
        Me.bodyPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'rootPanel
        '
        Me.rootPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rootPanel.ColumnCount = 1
        Me.rootPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.Controls.Add(Me.headerPanel, 0, 0)
        Me.rootPanel.Controls.Add(Me.bodyPanel, 0, 1)
        Me.rootPanel.Controls.Add(Me.footerPanel, 0, 2)
        Me.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootPanel.Location = New System.Drawing.Point(0, 0)
        Me.rootPanel.Name = "rootPanel"
        Me.rootPanel.RowCount = 3
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.rootPanel.Size = New System.Drawing.Size(426, 216)
        Me.rootPanel.TabIndex = 0
        '
        'headerPanel
        '
        Me.headerPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.headerPanel.Controls.Add(Me.Btn_Close)
        Me.headerPanel.Controls.Add(Me.Lbl_Title)
        Me.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.headerPanel.Location = New System.Drawing.Point(0, 0)
        Me.headerPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.headerPanel.Name = "headerPanel"
        Me.headerPanel.Size = New System.Drawing.Size(426, 52)
        Me.headerPanel.TabIndex = 0
        '
        'Btn_Close
        '
        Me.Btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Close.FlatAppearance.BorderSize = 0
        Me.Btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Close.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Btn_Close.ForeColor = System.Drawing.Color.White
        Me.Btn_Close.Location = New System.Drawing.Point(384, 9)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(34, 34)
        Me.Btn_Close.TabIndex = 1
        Me.Btn_Close.Text = "X"
        Me.Btn_Close.UseVisualStyleBackColor = False
        '
        'Lbl_Title
        '
        Me.Lbl_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Title.AutoEllipsis = True
        Me.Lbl_Title.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Title.ForeColor = System.Drawing.Color.White
        Me.Lbl_Title.Location = New System.Drawing.Point(20, 0)
        Me.Lbl_Title.Name = "Lbl_Title"
        Me.Lbl_Title.Size = New System.Drawing.Size(358, 52)
        Me.Lbl_Title.TabIndex = 0
        Me.Lbl_Title.Text = "DMSA System"
        Me.Lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bodyPanel
        '
        Me.bodyPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bodyPanel.ColumnCount = 3
        Me.bodyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.bodyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.bodyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.bodyPanel.Controls.Add(Me.accentPanel, 0, 0)
        Me.bodyPanel.Controls.Add(Me.Lbl_Icon, 1, 0)
        Me.bodyPanel.Controls.Add(Me.Lbl_Message, 2, 0)
        Me.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bodyPanel.Location = New System.Drawing.Point(0, 52)
        Me.bodyPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.bodyPanel.Name = "bodyPanel"
        Me.bodyPanel.RowCount = 1
        Me.bodyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.bodyPanel.Size = New System.Drawing.Size(426, 100)
        Me.bodyPanel.TabIndex = 1
        '
        'accentPanel
        '
        Me.accentPanel.BackColor = System.Drawing.Color.Teal
        Me.accentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.accentPanel.Location = New System.Drawing.Point(0, 0)
        Me.accentPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.accentPanel.Name = "accentPanel"
        Me.accentPanel.Size = New System.Drawing.Size(8, 100)
        Me.accentPanel.TabIndex = 0
        '
        'Lbl_Icon
        '
        Me.Lbl_Icon.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Icon.BackColor = System.Drawing.Color.Teal
        Me.Lbl_Icon.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Icon.ForeColor = System.Drawing.Color.White
        Me.Lbl_Icon.Location = New System.Drawing.Point(26, 29)
        Me.Lbl_Icon.Name = "Lbl_Icon"
        Me.Lbl_Icon.Size = New System.Drawing.Size(42, 42)
        Me.Lbl_Icon.TabIndex = 1
        Me.Lbl_Icon.Text = "i"
        Me.Lbl_Icon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_Message
        '
        Me.Lbl_Message.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Message.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)
        Me.Lbl_Message.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Lbl_Message.Location = New System.Drawing.Point(89, 0)
        Me.Lbl_Message.Name = "Lbl_Message"
        Me.Lbl_Message.Padding = New System.Windows.Forms.Padding(0, 14, 20, 14)
        Me.Lbl_Message.Size = New System.Drawing.Size(334, 100)
        Me.Lbl_Message.TabIndex = 2
        Me.Lbl_Message.Text = "Notification message"
        Me.Lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'footerPanel
        '
        Me.footerPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.footerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.footerPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.footerPanel.Location = New System.Drawing.Point(0, 152)
        Me.footerPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.footerPanel.Name = "footerPanel"
        Me.footerPanel.Padding = New System.Windows.Forms.Padding(14, 14, 16, 0)
        Me.footerPanel.Size = New System.Drawing.Size(426, 64)
        Me.footerPanel.TabIndex = 2
        '
        'AppNotificationDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(430, 220)
        Me.Controls.Add(Me.rootPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(380, 210)
        Me.Name = "AppNotificationDialog"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DMSA System"
        Me.rootPanel.ResumeLayout(False)
        Me.headerPanel.ResumeLayout(False)
        Me.bodyPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rootPanel As TableLayoutPanel
    Friend WithEvents headerPanel As Panel
    Friend WithEvents Lbl_Title As Label
    Friend WithEvents Btn_Close As Button
    Friend WithEvents bodyPanel As TableLayoutPanel
    Friend WithEvents accentPanel As Panel
    Friend WithEvents Lbl_Icon As Label
    Friend WithEvents Lbl_Message As Label
    Friend WithEvents footerPanel As FlowLayoutPanel
End Class
