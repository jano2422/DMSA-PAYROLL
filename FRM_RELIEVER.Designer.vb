<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_RELIEVER
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
        Me.LV_Main_Client_List = New System.Windows.Forms.ListView()
        Me.Col_ClientID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_ClientName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LV_Reliever_Dates = New System.Windows.Forms.ListView()
        Me.Col_RelieverID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Client_ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_DateRel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Wage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Cmb_Day = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_Shift = New System.Windows.Forms.ComboBox()
        Me.Col_Shift = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Maroon
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1105, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LV_Main_Client_List
        '
        Me.LV_Main_Client_List.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LV_Main_Client_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_ClientID, Me.Col_ClientName})
        Me.LV_Main_Client_List.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Main_Client_List.FullRowSelect = True
        Me.LV_Main_Client_List.GridLines = True
        Me.LV_Main_Client_List.HideSelection = False
        Me.LV_Main_Client_List.Location = New System.Drawing.Point(23, 90)
        Me.LV_Main_Client_List.Name = "LV_Main_Client_List"
        Me.LV_Main_Client_List.Size = New System.Drawing.Size(504, 472)
        Me.LV_Main_Client_List.TabIndex = 3
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
        Me.Col_ClientName.Text = "Client Name"
        Me.Col_ClientName.Width = 400
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(19, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 23)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Reliever Day:"
        '
        'LV_Reliever_Dates
        '
        Me.LV_Reliever_Dates.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Reliever_Dates.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_RelieverID, Me.Client_ID, Me.Col_DateRel, Me.Col_Wage, Me.Col_Shift})
        Me.LV_Reliever_Dates.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Reliever_Dates.FullRowSelect = True
        Me.LV_Reliever_Dates.GridLines = True
        Me.LV_Reliever_Dates.HideSelection = False
        Me.LV_Reliever_Dates.Location = New System.Drawing.Point(533, 90)
        Me.LV_Reliever_Dates.Name = "LV_Reliever_Dates"
        Me.LV_Reliever_Dates.Size = New System.Drawing.Size(545, 472)
        Me.LV_Reliever_Dates.TabIndex = 38
        Me.LV_Reliever_Dates.UseCompatibleStateImageBehavior = False
        Me.LV_Reliever_Dates.View = System.Windows.Forms.View.Details
        '
        'Col_RelieverID
        '
        Me.Col_RelieverID.Text = "Reliever ID"
        Me.Col_RelieverID.Width = 120
        '
        'Client_ID
        '
        Me.Client_ID.Text = "Client ID"
        Me.Client_ID.Width = 120
        '
        'Col_DateRel
        '
        Me.Col_DateRel.Text = "Day Relieved"
        Me.Col_DateRel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_DateRel.Width = 130
        '
        'Col_Wage
        '
        Me.Col_Wage.Text = "Daily Wage"
        Me.Col_Wage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Col_Wage.Width = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(539, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 23)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Reliever Dates"
        '
        'Btn_Delete
        '
        Me.Btn_Delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_Delete.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(944, 568)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(134, 32)
        Me.Btn_Delete.TabIndex = 63
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = False
        '
        'Btn_Save
        '
        Me.Btn_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Btn_Save.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(23, 568)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(165, 32)
        Me.Btn_Save.TabIndex = 64
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = False
        '
        'Cmb_Day
        '
        Me.Cmb_Day.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Day.FormattingEnabled = True
        Me.Cmb_Day.Location = New System.Drawing.Point(163, 41)
        Me.Cmb_Day.Name = "Cmb_Day"
        Me.Cmb_Day.Size = New System.Drawing.Size(63, 32)
        Me.Cmb_Day.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(264, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 23)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "AM / PM :"
        '
        'Cmb_Shift
        '
        Me.Cmb_Shift.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Shift.FormattingEnabled = True
        Me.Cmb_Shift.Items.AddRange(New Object() {"AM", "PM", "Both"})
        Me.Cmb_Shift.Location = New System.Drawing.Point(375, 41)
        Me.Cmb_Shift.Name = "Cmb_Shift"
        Me.Cmb_Shift.Size = New System.Drawing.Size(88, 32)
        Me.Cmb_Shift.TabIndex = 68
        '
        'Col_Shift
        '
        Me.Col_Shift.Text = "Shift"
        Me.Col_Shift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FRM_RELIEVER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1105, 640)
        Me.Controls.Add(Me.Cmb_Shift)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cmb_Day)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LV_Reliever_Dates)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LV_Main_Client_List)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FRM_RELIEVER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reliever"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LV_Main_Client_List As ListView
    Friend WithEvents Col_ClientID As ColumnHeader
    Friend WithEvents Col_ClientName As ColumnHeader
    Friend WithEvents Label11 As Label
    Friend WithEvents LV_Reliever_Dates As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Cmb_Day As ComboBox
    Friend WithEvents Col_RelieverID As ColumnHeader
    Friend WithEvents Client_ID As ColumnHeader
    Friend WithEvents Col_DateRel As ColumnHeader
    Friend WithEvents Col_Wage As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents Cmb_Shift As ComboBox
    Friend WithEvents Col_Shift As ColumnHeader
End Class
