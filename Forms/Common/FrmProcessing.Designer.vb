<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcessing
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
        Me.Lbl_Title = New System.Windows.Forms.Label()
        Me.bodyPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.fileBadgePanel = New System.Windows.Forms.Panel()
        Me.Lbl_FileBadge = New System.Windows.Forms.Label()
        Me.messagePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Lbl_Message = New System.Windows.Forms.Label()
        Me.Lbl_SubMessage = New System.Windows.Forms.Label()
        Me.footerPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.progressTrack = New System.Windows.Forms.Panel()
        Me.progressFill = New System.Windows.Forms.Panel()
        Me.Lbl_Working = New System.Windows.Forms.Label()
        Me.rootPanel.SuspendLayout()
        Me.headerPanel.SuspendLayout()
        Me.bodyPanel.SuspendLayout()
        Me.fileBadgePanel.SuspendLayout()
        Me.messagePanel.SuspendLayout()
        Me.footerPanel.SuspendLayout()
        Me.progressTrack.SuspendLayout()
        Me.SuspendLayout()
        '
        'rootPanel
        '
        Me.rootPanel.BackColor = System.Drawing.Color.Teal
        Me.rootPanel.ColumnCount = 1
        Me.rootPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.Controls.Add(Me.headerPanel, 0, 0)
        Me.rootPanel.Controls.Add(Me.bodyPanel, 0, 1)
        Me.rootPanel.Controls.Add(Me.footerPanel, 0, 2)
        Me.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rootPanel.Location = New System.Drawing.Point(0, 0)
        Me.rootPanel.Name = "rootPanel"
        Me.rootPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.rootPanel.RowCount = 3
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.rootPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.rootPanel.Size = New System.Drawing.Size(500, 200)
        Me.rootPanel.TabIndex = 0
        '
        'headerPanel
        '
        Me.headerPanel.BackColor = System.Drawing.Color.Teal
        Me.headerPanel.Controls.Add(Me.Lbl_Title)
        Me.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.headerPanel.Location = New System.Drawing.Point(1, 1)
        Me.headerPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.headerPanel.Name = "headerPanel"
        Me.headerPanel.Padding = New System.Windows.Forms.Padding(18, 0, 18, 0)
        Me.headerPanel.Size = New System.Drawing.Size(498, 44)
        Me.headerPanel.TabIndex = 0
        '
        'Lbl_Title
        '
        Me.Lbl_Title.BackColor = System.Drawing.Color.Teal
        Me.Lbl_Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Title.Font = New System.Drawing.Font("Verdana", 10.75!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Title.ForeColor = System.Drawing.Color.White
        Me.Lbl_Title.Location = New System.Drawing.Point(18, 0)
        Me.Lbl_Title.Name = "Lbl_Title"
        Me.Lbl_Title.Size = New System.Drawing.Size(462, 44)
        Me.Lbl_Title.TabIndex = 0
        Me.Lbl_Title.Text = "Export in progress"
        Me.Lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bodyPanel
        '
        Me.bodyPanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.bodyPanel.ColumnCount = 2
        Me.bodyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.bodyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.bodyPanel.Controls.Add(Me.fileBadgePanel, 0, 0)
        Me.bodyPanel.Controls.Add(Me.messagePanel, 1, 0)
        Me.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bodyPanel.Location = New System.Drawing.Point(1, 45)
        Me.bodyPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.bodyPanel.Name = "bodyPanel"
        Me.bodyPanel.Padding = New System.Windows.Forms.Padding(18, 16, 18, 10)
        Me.bodyPanel.RowCount = 1
        Me.bodyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.bodyPanel.Size = New System.Drawing.Size(498, 100)
        Me.bodyPanel.TabIndex = 1
        '
        'fileBadgePanel
        '
        Me.fileBadgePanel.BackColor = System.Drawing.Color.Teal
        Me.fileBadgePanel.Controls.Add(Me.Lbl_FileBadge)
        Me.fileBadgePanel.Location = New System.Drawing.Point(18, 16)
        Me.fileBadgePanel.Margin = New System.Windows.Forms.Padding(0)
        Me.fileBadgePanel.Name = "fileBadgePanel"
        Me.fileBadgePanel.Size = New System.Drawing.Size(64, 64)
        Me.fileBadgePanel.TabIndex = 0
        '
        'Lbl_FileBadge
        '
        Me.Lbl_FileBadge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_FileBadge.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Lbl_FileBadge.ForeColor = System.Drawing.Color.White
        Me.Lbl_FileBadge.Location = New System.Drawing.Point(0, 0)
        Me.Lbl_FileBadge.Name = "Lbl_FileBadge"
        Me.Lbl_FileBadge.Size = New System.Drawing.Size(64, 64)
        Me.Lbl_FileBadge.TabIndex = 0
        Me.Lbl_FileBadge.Text = "XLS"
        Me.Lbl_FileBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'messagePanel
        '
        Me.messagePanel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.messagePanel.ColumnCount = 1
        Me.messagePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.messagePanel.Controls.Add(Me.Lbl_Message, 0, 0)
        Me.messagePanel.Controls.Add(Me.Lbl_SubMessage, 0, 1)
        Me.messagePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.messagePanel.Location = New System.Drawing.Point(110, 16)
        Me.messagePanel.Margin = New System.Windows.Forms.Padding(0)
        Me.messagePanel.Name = "messagePanel"
        Me.messagePanel.RowCount = 2
        Me.messagePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.0!))
        Me.messagePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.0!))
        Me.messagePanel.Size = New System.Drawing.Size(370, 74)
        Me.messagePanel.TabIndex = 1
        '
        'Lbl_Message
        '
        Me.Lbl_Message.AutoEllipsis = True
        Me.Lbl_Message.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Lbl_Message.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_Message.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Message.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30)
        Me.Lbl_Message.Location = New System.Drawing.Point(0, 0)
        Me.Lbl_Message.Margin = New System.Windows.Forms.Padding(0)
        Me.Lbl_Message.Name = "Lbl_Message"
        Me.Lbl_Message.Size = New System.Drawing.Size(370, 42)
        Me.Lbl_Message.TabIndex = 0
        Me.Lbl_Message.Text = "Exporting payroll to Excel..."
        Me.Lbl_Message.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Lbl_SubMessage
        '
        Me.Lbl_SubMessage.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.Lbl_SubMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_SubMessage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Lbl_SubMessage.ForeColor = System.Drawing.Color.Teal
        Me.Lbl_SubMessage.Location = New System.Drawing.Point(0, 42)
        Me.Lbl_SubMessage.Margin = New System.Windows.Forms.Padding(0)
        Me.Lbl_SubMessage.Name = "Lbl_SubMessage"
        Me.Lbl_SubMessage.Size = New System.Drawing.Size(370, 32)
        Me.Lbl_SubMessage.TabIndex = 1
        Me.Lbl_SubMessage.Text = "Building workbook sheets"
        Me.Lbl_SubMessage.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'footerPanel
        '
        Me.footerPanel.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.footerPanel.ColumnCount = 2
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.footerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.footerPanel.Controls.Add(Me.progressTrack, 0, 0)
        Me.footerPanel.Controls.Add(Me.Lbl_Working, 1, 0)
        Me.footerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.footerPanel.Location = New System.Drawing.Point(1, 145)
        Me.footerPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.footerPanel.Name = "footerPanel"
        Me.footerPanel.Padding = New System.Windows.Forms.Padding(18, 13, 18, 0)
        Me.footerPanel.RowCount = 1
        Me.footerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.footerPanel.Size = New System.Drawing.Size(498, 54)
        Me.footerPanel.TabIndex = 2
        '
        'progressTrack
        '
        Me.progressTrack.BackColor = System.Drawing.Color.FromArgb(255, 238, 214)
        Me.progressTrack.Controls.Add(Me.progressFill)
        Me.progressTrack.Dock = System.Windows.Forms.DockStyle.Top
        Me.progressTrack.Location = New System.Drawing.Point(18, 13)
        Me.progressTrack.Margin = New System.Windows.Forms.Padding(0)
        Me.progressTrack.Name = "progressTrack"
        Me.progressTrack.Size = New System.Drawing.Size(362, 14)
        Me.progressTrack.TabIndex = 0
        '
        'progressFill
        '
        Me.progressFill.BackColor = System.Drawing.Color.Teal
        Me.progressFill.Location = New System.Drawing.Point(0, 0)
        Me.progressFill.Margin = New System.Windows.Forms.Padding(0)
        Me.progressFill.Name = "progressFill"
        Me.progressFill.Size = New System.Drawing.Size(120, 14)
        Me.progressFill.TabIndex = 0
        '
        'Lbl_Working
        '
        Me.Lbl_Working.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.Lbl_Working.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lbl_Working.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Working.ForeColor = System.Drawing.Color.FromArgb(74, 55, 32)
        Me.Lbl_Working.Location = New System.Drawing.Point(390, 13)
        Me.Lbl_Working.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Lbl_Working.Name = "Lbl_Working"
        Me.Lbl_Working.Size = New System.Drawing.Size(90, 24)
        Me.Lbl_Working.TabIndex = 1
        Me.Lbl_Working.Text = "Working..."
        Me.Lbl_Working.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmProcessing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(255, 192, 128)
        Me.ClientSize = New System.Drawing.Size(500, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.rootPanel)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmProcessing"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Processing"
        Me.TopMost = True
        Me.rootPanel.ResumeLayout(False)
        Me.headerPanel.ResumeLayout(False)
        Me.bodyPanel.ResumeLayout(False)
        Me.fileBadgePanel.ResumeLayout(False)
        Me.messagePanel.ResumeLayout(False)
        Me.footerPanel.ResumeLayout(False)
        Me.progressTrack.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rootPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents headerPanel As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Title As System.Windows.Forms.Label
    Friend WithEvents bodyPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents fileBadgePanel As System.Windows.Forms.Panel
    Friend WithEvents Lbl_FileBadge As System.Windows.Forms.Label
    Friend WithEvents messagePanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_Message As System.Windows.Forms.Label
    Friend WithEvents Lbl_SubMessage As System.Windows.Forms.Label
    Friend WithEvents footerPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents progressTrack As System.Windows.Forms.Panel
    Friend WithEvents progressFill As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Working As System.Windows.Forms.Label
End Class
