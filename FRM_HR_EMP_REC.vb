Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class FRM_EMP_REG
    Private Sub FRM_EMP_REG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Lbl_Attachment_Path.Text = ""
        Call Clear_all_Boxes_from_EMP_RECORD()
        Call Show_Employee_List()

        'Lbl_Count.Text = Count_Employee_Record()

        Pic_Employee_Photo.Image = My.Resources.DMSA_Logo

        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(LV_Employee_List, "Double click to change employment status.")
    End Sub


    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        Dim sCategory As String

        Select Case Cmb_Category.SelectedIndex
            Case 0
                sCategory = "B.EMPLOYEE_ID"
            Case 1
                sCategory = "E.SUB_CLIENT_NAME"   ' Sub client name (TBL_CLIENT_SUB alias E)
            Case 2
                sCategory = "A.LAST_NAME"
            Case 3
                sCategory = "B.EMPLOYMENT_STATUS"
            Case Else
                sCategory = "A.LAST_NAME"
        End Select

        Dim keyword As String = TxtSearch.Text.Trim().Replace("'", "''")
        Dim activeOnly As Boolean = (sCategory = "E.SUB_CLIENT_NAME") ' ✅ Active only when searching by sub client name

        Show_Search(sCategory, keyword, activeOnly)
    End Sub




    Private Sub Btn_Edit_Click(sender As Object, e As EventArgs)
        GlobalVariables.Emp_Reg_Mode = "Edit"

    End Sub



    Private Sub FRM_EMP_REG_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        GlobalVariables.Emp_Reg_Mode = ""
        GlobalVariables.Selected_Employee_ID = ""
    End Sub
    Private Sub LV_Employee_List_DoubleClick(sender As Object, e As EventArgs) Handles LV_Employee_List.DoubleClick

        FRM_EMP_UPDATE_REC.ShowDialog()
    End Sub
    'Private Sub LV_Employee_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Employee_List.SelectedIndexChanged

    '    Try
    '        GlobalVariables.Selected_Employee_ID = LV_Employee_List.SelectedItems(0).SubItems(1).Text
    '    Catch ex As Exception
    '        ' Need to check why having error when selecting records
    '        GlobalVariables.Selected_Employee_ID = ""
    '    End Try


    '    Try

    '        Call Show_Employee_Details(GlobalVariables.Selected_Employee_ID)
    '        Call Show_Employee_Client_History(GlobalVariables.Selected_Employee_ID)
    '        Call Show_ATM_Info(GlobalVariables.Selected_Employee_ID)
    '        ' Expirations
    '        Call Show_Security_License_Expiration_To_Employee_Record(GlobalVariables.Selected_Employee_ID)
    '        Call Show_Medical_Expiration_To_Employee_Record(GlobalVariables.Selected_Employee_ID)
    '        Call Show_Insurance_Expiration_to_Employee_Record(GlobalVariables.Selected_Employee_ID)
    '    Catch EX As Exception
    '        MsgBox(EX.Message, vbCritical, "Loading information Error")
    '    End Try

    '    Try
    '        GlobalVariables.Photo_Path_from_DB = Show_Photo_in_Employee_Rec(GlobalVariables.Selected_Employee_ID)
    '        If GlobalVariables.Photo_Path_from_DB = "0" Then
    '            Me.Pic_Employee_Photo.Image = My.Resources.DMSA_Logo
    '        Else ' with Path from DB
    '            Me.Pic_Employee_Photo.Image = Image.FromFile(GlobalVariables.Photo_Path_from_DB)
    '        End If


    '        If GlobalVariables.Selected_Employee_ID <> "" Then
    '            Btn_Pic_Upload.Enabled = True

    '        Else
    '            Btn_Pic_Upload.Enabled = False

    '        End If
    '    Catch ex As Exception
    '        Me.Pic_Employee_Photo.Image = My.Resources.DMSA_Logo
    '        'MsgBox(ex.Message, vbCritical, "Loading Photo Error")
    '    End Try





    'End Sub

    Private Sub ShowExpiryPhotoToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Me.LV_Employee_List.Size = New Size(864, 505)
    End Sub

    Private Sub ShowLongListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.LV_Employee_List.Size = New Size(864, 777)
    End Sub

    Private Sub Btn_Pic_Upload_Click(sender As Object, e As EventArgs) Handles Btn_Pic_Upload.Click

        If Btn_Pic_Upload.Text = "Upload" Then

            Btn_Pic_Upload.Text = "Save"
            Btn_Pic_Cancel.Visible = True

            Try
                OpenFileDialog1.Title = "Upload scanned Security Guard License ID"
                'OpenFileDialog1.InitialDirectory = ""
                OpenFileDialog1.FileName = ".JPG"
                OpenFileDialog1.Filter = "JPG Files |*.jpg"



                Dim result As DialogResult = OpenFileDialog1.ShowDialog()


                GlobalVariables.Photo_sFilename = OpenFileDialog1.SafeFileName ' Not Used
                GlobalVariables.Photo_Source_Path = OpenFileDialog1.FileName

                Dim Image As Image

                Image = Image.FromFile(GlobalVariables.Photo_Source_Path) ' assigning the Path to image variable

                Pic_Employee_Photo.Image = Image ' Showing the picture to picture box

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Check Map Drive")
                Btn_Pic_Upload.Text = "Upload"
                Btn_Pic_Cancel.Visible = False
            End Try

        Else ' Save



            Try
                'Rename the photo
                Dim currentDate As DateTime = DateTime.Now
                ' Format the date and time as "ddMMyyHHmmss"
                Dim formattedDateTime As String = currentDate.ToString("ddMMyyHHmmss")

                Dim newFilePath As String = Path.Combine(Application.StartupPath & "\Attachments\Photo\", GlobalVariables.Selected_Employee_ID & "_" & formattedDateTime & ".jpg")

                GlobalVariables.Photo_Destination_Path = newFilePath

                'Copy the PDF file to Destination Path
                My.Computer.FileSystem.CopyFile(GlobalVariables.Photo_Source_Path, GlobalVariables.Photo_Destination_Path)

                If GlobalVariables.Photo_Path_from_DB = "0" Then

                    ' Save Path to Database 
                    Call Insert_Photo_Uploaded(GlobalVariables.Selected_Employee_ID, GlobalVariables.Photo_Destination_Path)

                    MsgBox("New Photo was successfully uploaded.", vbInformation, "Saved")

                Else ' With existing image uploaded from DB ( therefore need to update the path instead of inserting a new record

                    Call Update_Employee_Photo(GlobalVariables.Selected_Employee_ID)
                    MsgBox("Photo was successfully replaced!", vbInformation, "Saved")


                End If

                Btn_Pic_Upload.Text = "Upload"
                Btn_Pic_Cancel.Visible = False

            Catch ex As Exception
                Call Record_activity_log(GlobalVariables.Selected_Employee_ID, "Error saving of photo ")
            End Try

        End If


    End Sub

    Private Sub Btn_Pic_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Pic_Cancel.Click
        Btn_Pic_Upload.Text = "Upload"
        Btn_Pic_Cancel.Visible = False
    End Sub

    Private Sub AllEmployeeRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllEmployeeRecordsToolStripMenuItem.Click
        Dim dt As DataTable = GetEmployeeList()

        If dt.Rows.Count = 0 Then
            MsgBox("No data to export.", vbExclamation)
            Exit Sub
        End If

        ' ✅ choose columns to export (must match dt column names)
        Dim columnsToExport As String() = {
        "empId",
        "FIRST_NAME",
        "MIDDLE_NAME",
        "LAST_NAME",
        "DATE_HIRED",
        "SUB_CLIENT_NAME",
        "BIRTH_DATE",
        "CONTACT_NO",
        "APPL_ADD",
        "SSS_NO",
        "PAGIBIG_NO",
        "PHIL_HEALTH_NO",
        "TIN_NO",
        "CONTACT_PERSON",
        "CONTACT_RELATIONSHIP",
        "CONTACT_CP_NUMBER",
        "EMPLOYMENT_STATUS"
    }

        Dim dtExport As DataTable = SelectColumns(dt, columnsToExport)

        Dim timestamp As String = Format(Now, "yyyyMMdd_HHmmss")

        Dim sfd As New SaveFileDialog
        sfd.Filter = "CSV Files (*.csv)|*.csv"
        sfd.FileName = "Employee_List_" & timestamp & ".csv"

        If sfd.ShowDialog() = DialogResult.OK Then
            Dim processing As New FrmProcessing("Saving CSV file, please wait...")
            processing.Show()
            processing.Refresh()

            Task.Run(Sub()
                         ExportDataTableToCsv(dtExport, sfd.FileName)

                         Me.Invoke(Sub()
                                       processing.Close()
                                       MsgBox("Export completed successfully!", vbInformation)
                                   End Sub)
                     End Sub)
        End If
    End Sub

    Private Function SelectColumns(source As DataTable, columnNames As IEnumerable(Of String)) As DataTable
        Dim result As New DataTable()

        ' Add only requested columns that exist
        For Each colName In columnNames
            If source.Columns.Contains(colName) Then
                result.Columns.Add(colName, source.Columns(colName).DataType)
            End If
        Next

        ' Copy rows
        For Each r As DataRow In source.Rows
            Dim newRow As DataRow = result.NewRow()
            For Each c As DataColumn In result.Columns
                newRow(c.ColumnName) = r(c.ColumnName)
            Next
            result.Rows.Add(newRow)
        Next

        Return result
    End Function



    Private Sub Btn_ATM_Edit_Click(sender As Object, e As EventArgs) Handles Btn_ATM_Edit.Click
        If Btn_ATM_Edit.Text = "Edit" Then

            Btn_ATM_Cancel.Visible = True
            Btn_ATM_Edit.Text = "Save"


        Else

            If Cmb_Bank_Name.Text = "" Or Txt_ATM_Number.Text = "" Then
                MsgBox("Can not save an empty boxes!", vbCritical, "Invalid values")
                Exit Sub
            End If

            Call Update_ATM_Info(GlobalVariables.Selected_Employee_ID, Me.Cmb_Bank_Name.Text, Me.Txt_ATM_Number.Text)

            Btn_ATM_Cancel.Visible = False
            Btn_ATM_Edit.Text = "Edit"

        End If
    End Sub

    Private Sub Btn_ATM_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_ATM_Cancel.Click
        Btn_ATM_Edit.Text = "Edit"
        Btn_ATM_Cancel.Visible = False
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged

    End Sub

    Private Sub Btn_ShortList_Click(sender As Object, e As EventArgs) Handles Btn_ShortList.Click
        Me.LV_Employee_List.Size = New Size(864, 505)
    End Sub

    Private Sub Btn_LongList_Click(sender As Object, e As EventArgs) Handles Btn_LongList.Click
        Me.LV_Employee_List.Size = New Size(864, 777)
    End Sub
    Private Sub TxtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSearch.KeyPress
        If e.KeyChar <> ChrW(Keys.Enter) Then Exit Sub

        e.Handled = True ' prevent beep / ding

        Dim sCategory As String

        Select Case Me.Cmb_Category.SelectedIndex
            Case 0
                sCategory = "B.EMPLOYEE_ID"
            Case 1
                ' Sub Client Name now comes from TBL_CLIENT_SUB alias E
                sCategory = "E.SUB_CLIENT_NAME"
            Case 2
                sCategory = "A.LAST_NAME"
            Case 3
                sCategory = "B.EMPLOYMENT_STATUS"
            Case Else
                sCategory = "A.LAST_NAME"
        End Select

        Dim keyword As String = TxtSearch.Text.Trim()

        ' Optional: allow Enter with blank text to show all (or just ignore)
        If keyword = "" Then
            Call Show_Search("A.LAST_NAME", "")
            Exit Sub
        End If

        ' Prevent SQL break when user types apostrophe (e.g., O'Connor)
        keyword = keyword.Replace("'", "''")
        Dim activeOnly As Boolean = (sCategory = "E.SUB_CLIENT_NAME") ' ✅ Active only when searching by sub client name

        Call Show_Search(sCategory, keyword)
    End Sub


    Private Sub LV_Employee_List_MouseClick(sender As Object, e As MouseEventArgs) Handles LV_Employee_List.MouseClick
        Try
            GlobalVariables.Selected_Employee_ID = LV_Employee_List.SelectedItems(0).SubItems(1).Text
        Catch ex As Exception
            ' Need to check why having error when selecting records
            GlobalVariables.Selected_Employee_ID = ""
        End Try


        Try

            Call Show_Employee_Details(GlobalVariables.Selected_Employee_ID)
            Call Show_Employee_Client_History(GlobalVariables.Selected_Employee_ID)
            Call Show_ATM_Info(GlobalVariables.Selected_Employee_ID)
            ' Expirations
            Call Show_Security_License_Expiration_To_Employee_Record(GlobalVariables.Selected_Employee_ID)
            Call Show_Medical_Expiration_To_Employee_Record(GlobalVariables.Selected_Employee_ID)
            Call Show_Insurance_Expiration_to_Employee_Record(GlobalVariables.Selected_Employee_ID)
        Catch EX As Exception
            MsgBox(EX.Message, vbCritical, "Loading information Error")
        End Try

        Try
            GlobalVariables.Photo_Path_from_DB = Show_Photo_in_Employee_Rec(GlobalVariables.Selected_Employee_ID)
            If GlobalVariables.Photo_Path_from_DB = "0" Then
                Me.Pic_Employee_Photo.Image = My.Resources.DMSA_Logo
            Else ' with Path from DB
                Me.Pic_Employee_Photo.Image = Image.FromFile(GlobalVariables.Photo_Path_from_DB)
            End If


            If GlobalVariables.Selected_Employee_ID <> "" Then
                Btn_Pic_Upload.Enabled = True

            Else
                Btn_Pic_Upload.Enabled = False

            End If
        Catch ex As Exception
            Me.Pic_Employee_Photo.Image = My.Resources.DMSA_Logo
            'MsgBox(ex.Message, vbCritical, "Loading Photo Error")
        End Try




    End Sub


End Class
