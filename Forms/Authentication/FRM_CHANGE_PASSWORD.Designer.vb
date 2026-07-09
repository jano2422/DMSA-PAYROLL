<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_CHANGE_PASSWORD
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
        Me.PanelDetails = New System.Windows.Forms.Panel()
        Me.Chk_ShowPassword = New System.Windows.Forms.CheckBox()
        Me.Lbl_Hint = New System.Windows.Forms.Label()
        Me.TxtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.LabelConfirmPassword = New System.Windows.Forms.Label()
        Me.TxtNewPassword = New System.Windows.Forms.TextBox()
        Me.LabelNewPassword = New System.Windows.Forms.Label()
        Me.TxtCurrentPassword = New System.Windows.Forms.TextBox()
        Me.LabelCurrentPassword = New System.Windows.Forms.Label()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.LabelUsername = New System.Windows.Forms.Label()
        Me.Lbl_DetailsTitle = New System.Windows.Forms.Label()
        Me.BtnChangePassword = New System.Windows.Forms.Button()
        Me.Btn_Clear = New System.Windows.Forms.Button()
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
        Me.PanelHeader.Size = New System.Drawing.Size(620, 48)
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
        Me.Lbl_Title.Text = "Change Password"
        '
        'PanelDetails
        '
        Me.PanelDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDetails.Controls.Add(Me.Chk_ShowPassword)
        Me.PanelDetails.Controls.Add(Me.Lbl_Hint)
        Me.PanelDetails.Controls.Add(Me.TxtConfirmPassword)
        Me.PanelDetails.Controls.Add(Me.LabelConfirmPassword)
        Me.PanelDetails.Controls.Add(Me.TxtNewPassword)
        Me.PanelDetails.Controls.Add(Me.LabelNewPassword)
        Me.PanelDetails.Controls.Add(Me.TxtCurrentPassword)
        Me.PanelDetails.Controls.Add(Me.LabelCurrentPassword)
        Me.PanelDetails.Controls.Add(Me.TxtUsername)
        Me.PanelDetails.Controls.Add(Me.LabelUsername)
        Me.PanelDetails.Controls.Add(Me.Lbl_DetailsTitle)
        Me.PanelDetails.Location = New System.Drawing.Point(22, 72)
        Me.PanelDetails.Name = "PanelDetails"
        Me.PanelDetails.Size = New System.Drawing.Size(576, 241)
        Me.PanelDetails.TabIndex = 1
        '
        'Chk_ShowPassword
        '
        Me.Chk_ShowPassword.AutoSize = True
        Me.Chk_ShowPassword.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_ShowPassword.ForeColor = System.Drawing.Color.Teal
        Me.Chk_ShowPassword.Location = New System.Drawing.Point(190, 173)
        Me.Chk_ShowPassword.Name = "Chk_ShowPassword"
        Me.Chk_ShowPassword.Size = New System.Drawing.Size(123, 18)
        Me.Chk_ShowPassword.TabIndex = 8
        Me.Chk_ShowPassword.Text = "Show password"
        Me.Chk_ShowPassword.UseVisualStyleBackColor = True
        '
        'Lbl_Hint
        '
        Me.Lbl_Hint.AutoSize = True
        Me.Lbl_Hint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Hint.ForeColor = System.Drawing.Color.DimGray
        Me.Lbl_Hint.Location = New System.Drawing.Point(187, 204)
        Me.Lbl_Hint.Name = "Lbl_Hint"
        Me.Lbl_Hint.Size = New System.Drawing.Size(325, 13)
        Me.Lbl_Hint.TabIndex = 10
        Me.Lbl_Hint.Text = "Use your company ID as username. Passwords are case-sensitive."
        '
        'TxtConfirmPassword
        '
        Me.TxtConfirmPassword.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConfirmPassword.Location = New System.Drawing.Point(190, 136)
        Me.TxtConfirmPassword.Name = "TxtConfirmPassword"
        Me.TxtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmPassword.Size = New System.Drawing.Size(330, 23)
        Me.TxtConfirmPassword.TabIndex = 7
        '
        'LabelConfirmPassword
        '
        Me.LabelConfirmPassword.AutoSize = True
        Me.LabelConfirmPassword.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConfirmPassword.ForeColor = System.Drawing.Color.Teal
        Me.LabelConfirmPassword.Location = New System.Drawing.Point(28, 139)
        Me.LabelConfirmPassword.Name = "LabelConfirmPassword"
        Me.LabelConfirmPassword.Size = New System.Drawing.Size(144, 16)
        Me.LabelConfirmPassword.TabIndex = 6
        Me.LabelConfirmPassword.Text = "Confirm Password"
        '
        'TxtNewPassword
        '
        Me.TxtNewPassword.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNewPassword.Location = New System.Drawing.Point(190, 101)
        Me.TxtNewPassword.Name = "TxtNewPassword"
        Me.TxtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtNewPassword.Size = New System.Drawing.Size(330, 23)
        Me.TxtNewPassword.TabIndex = 5
        '
        'LabelNewPassword
        '
        Me.LabelNewPassword.AutoSize = True
        Me.LabelNewPassword.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNewPassword.ForeColor = System.Drawing.Color.Teal
        Me.LabelNewPassword.Location = New System.Drawing.Point(28, 104)
        Me.LabelNewPassword.Name = "LabelNewPassword"
        Me.LabelNewPassword.Size = New System.Drawing.Size(114, 16)
        Me.LabelNewPassword.TabIndex = 4
        Me.LabelNewPassword.Text = "New Password"
        '
        'TxtCurrentPassword
        '
        Me.TxtCurrentPassword.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrentPassword.Location = New System.Drawing.Point(190, 66)
        Me.TxtCurrentPassword.Name = "TxtCurrentPassword"
        Me.TxtCurrentPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtCurrentPassword.Size = New System.Drawing.Size(330, 23)
        Me.TxtCurrentPassword.TabIndex = 3
        '
        'LabelCurrentPassword
        '
        Me.LabelCurrentPassword.AutoSize = True
        Me.LabelCurrentPassword.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCurrentPassword.ForeColor = System.Drawing.Color.Teal
        Me.LabelCurrentPassword.Location = New System.Drawing.Point(28, 69)
        Me.LabelCurrentPassword.Name = "LabelCurrentPassword"
        Me.LabelCurrentPassword.Size = New System.Drawing.Size(136, 16)
        Me.LabelCurrentPassword.TabIndex = 2
        Me.LabelCurrentPassword.Text = "Current Password"
        '
        'TxtUsername
        '
        Me.TxtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUsername.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsername.Location = New System.Drawing.Point(190, 31)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(190, 23)
        Me.TxtUsername.TabIndex = 1
        '
        'LabelUsername
        '
        Me.LabelUsername.AutoSize = True
        Me.LabelUsername.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUsername.ForeColor = System.Drawing.Color.Teal
        Me.LabelUsername.Location = New System.Drawing.Point(28, 34)
        Me.LabelUsername.Name = "LabelUsername"
        Me.LabelUsername.Size = New System.Drawing.Size(78, 16)
        Me.LabelUsername.TabIndex = 0
        Me.LabelUsername.Text = "Username"
        '
        'Lbl_DetailsTitle
        '
        Me.Lbl_DetailsTitle.AutoSize = True
        Me.Lbl_DetailsTitle.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_DetailsTitle.ForeColor = System.Drawing.Color.Maroon
        Me.Lbl_DetailsTitle.Location = New System.Drawing.Point(17, 11)
        Me.Lbl_DetailsTitle.Name = "Lbl_DetailsTitle"
        Me.Lbl_DetailsTitle.Size = New System.Drawing.Size(0, 16)
        Me.Lbl_DetailsTitle.TabIndex = 9
        '
        'BtnChangePassword
        '
        Me.BtnChangePassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnChangePassword.BackColor = System.Drawing.Color.Teal
        Me.BtnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnChangePassword.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChangePassword.ForeColor = System.Drawing.Color.White
        Me.BtnChangePassword.Location = New System.Drawing.Point(275, 332)
        Me.BtnChangePassword.Name = "BtnChangePassword"
        Me.BtnChangePassword.Size = New System.Drawing.Size(148, 32)
        Me.BtnChangePassword.TabIndex = 2
        Me.BtnChangePassword.Text = "Change Password"
        Me.BtnChangePassword.UseVisualStyleBackColor = False
        '
        'Btn_Clear
        '
        Me.Btn_Clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Clear.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Clear.Location = New System.Drawing.Point(435, 332)
        Me.Btn_Clear.Name = "Btn_Clear"
        Me.Btn_Clear.Size = New System.Drawing.Size(78, 32)
        Me.Btn_Clear.TabIndex = 3
        Me.Btn_Clear.Text = "Clear"
        Me.Btn_Clear.UseVisualStyleBackColor = True
        '
        'Btn_Close
        '
        Me.Btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Close.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Close.Location = New System.Drawing.Point(520, 332)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(78, 32)
        Me.Btn_Close.TabIndex = 4
        Me.Btn_Close.Text = "Close"
        Me.Btn_Close.UseVisualStyleBackColor = True
        '
        'FRM_CHANGE_PASSWORD
        '
        Me.AcceptButton = Me.BtnChangePassword
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(620, 382)
        Me.Controls.Add(Me.Btn_Close)
        Me.Controls.Add(Me.Btn_Clear)
        Me.Controls.Add(Me.BtnChangePassword)
        Me.Controls.Add(Me.PanelDetails)
        Me.Controls.Add(Me.PanelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_CHANGE_PASSWORD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Password"
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.PanelDetails.ResumeLayout(False)
        Me.PanelDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents Lbl_Title As Label
    Friend WithEvents PanelDetails As Panel
    Friend WithEvents TxtConfirmPassword As TextBox
    Friend WithEvents LabelConfirmPassword As Label
    Friend WithEvents TxtNewPassword As TextBox
    Friend WithEvents LabelNewPassword As Label
    Friend WithEvents TxtCurrentPassword As TextBox
    Friend WithEvents LabelCurrentPassword As Label
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents LabelUsername As Label
    Friend WithEvents Lbl_DetailsTitle As Label
    Friend WithEvents Chk_ShowPassword As CheckBox
    Friend WithEvents Lbl_Hint As Label
    Friend WithEvents BtnChangePassword As Button
    Friend WithEvents Btn_Clear As Button
    Friend WithEvents Btn_Close As Button
End Class
