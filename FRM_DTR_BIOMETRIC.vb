Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Conversion
Public Class FRM_DTR_BIOMETRIC

    Private Sub Btn_DTR_Click(sender As Object, e As EventArgs) Handles Btn_DTR.Click
        If Now.Year = 2026 Then
            MsgBox("Trial Period Ends")
            End
        End If
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "No", 0) 'Temporary - Should be from the selected Employee 

        Dim szSelectedEmpName As String = GlobalVariables.DTR_Selected_Employee_Name

        ' Split the full name into last name and first name
        Dim nameParts() As String = szSelectedEmpName.Split(","c)
        Dim lastName As String = nameParts(0).Trim()
        Dim firstName As String = If(nameParts.Length > 1, nameParts(1).Trim(), "")

        ' Prompt user to select a directory
        Using folderBrowser As New FolderBrowserDialog()
            Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim DtrPath As String = System.IO.Path.Combine(exeDirectory, "DTR")
            folderBrowser.Description = "Select a directory containing the files"
            folderBrowser.SelectedPath = DtrPath

            If folderBrowser.ShowDialog() = DialogResult.OK Then
                Dim selectedDirectory As String = folderBrowser.SelectedPath

                ' Filter files in the selected directory
                Dim filteredFiles As List(Of String) = Directory.GetFiles(selectedDirectory, "*.pdf") _
                .Where(Function(file) Path.GetFileName(file).IndexOf(lastName, StringComparison.OrdinalIgnoreCase) >= 0 _
                    OrElse Path.GetFileName(file).IndexOf(firstName, StringComparison.OrdinalIgnoreCase) >= 0).ToList()

                ' If no matching files are found, notify the user
                If filteredFiles.Count = 0 Then
                    MsgBox("No files found containing the selected employee's name.", vbExclamation, "No Files Found")
                    Exit Sub
                End If

                ' Create and show the custom file selection dialog
                ShowModernFileSelectionForm(filteredFiles)
            End If
        End Using
    End Sub


    Private Sub ShowModernFileSelectionForm(filteredFiles As List(Of String))
        Dim fileSelectionForm As New Form()

        ' Set basic properties of the form
        With fileSelectionForm
            .Text = "Select a File"
            .Size = New Size(600, 400)
            .StartPosition = FormStartPosition.CenterScreen
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .MaximizeBox = False
            .MinimizeBox = False
            .ShowInTaskbar = False
        End With

        ' Create a ListBox to show filtered files
        Dim fileListBox As New ListBox() With {
        .Dock = DockStyle.Top,
        .Height = 250
    }

        fileListBox.Items.AddRange(filteredFiles.Select(Function(f) Path.GetFileName(f)).ToArray())

        ' Create a Select button
        Dim selectButton As New Button() With {
        .Text = "Select",
        .Dock = DockStyle.Bottom,
        .Height = 40
    }

        ' Create a Cancel button
        Dim cancelButton As New Button() With {
        .Text = "Cancel",
        .Dock = DockStyle.Bottom,
        .Height = 40
    }

        ' Add controls to the form
        fileSelectionForm.Controls.Add(fileListBox)
        fileSelectionForm.Controls.Add(selectButton)
        fileSelectionForm.Controls.Add(cancelButton)

        ' Handle Select button click
        AddHandler selectButton.Click, Sub()
                                           If fileListBox.SelectedIndex >= 0 Then
                                               Dim selectedFile As String = filteredFiles(fileListBox.SelectedIndex)

                                               ' Process the selected file
                                               Dim pdf As PdfDocument = New PdfDocument()
                                               pdf.LoadFromFile(selectedFile)

                                               'Dim filePath As String = "C:\Users\johnc\Downloads\Software Projects\Project 1\DMSA_System\bin\Debug\PdfToExcel.xlsx" - original
                                               Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory
                                               Dim filePath As String = System.IO.Path.Combine(exeDirectory, "PdfToExcel.xlsx")

                                               pdf.SaveToFile(filePath, FileFormat.XLSX)


                                               fileSelectionForm.Close()

                                               Call Connect_to_Excel_DTR()


                                           Else
                                               MsgBox("Please select a file.", vbExclamation, "No File Selected")
                                           End If
                                       End Sub

        ' Handle Cancel button click
        AddHandler cancelButton.Click, Sub()
                                           fileSelectionForm.Close()
                                       End Sub

        ' Show the custom file selection dialog
        fileSelectionForm.ShowDialog()
    End Sub
    Private Sub Btn_Calc_DTR_Click(sender As Object, e As EventArgs) Handles Btn_Calc_DTR.Click


        ' Define the name of the specific DataGridView you want to remove
        Dim targetDataGridViewName As String = "Duplicate_DGV" ' Example name for the duplicate DataGridView

        ' Loop through each TabPage in the TabControl
        For Each tabPage As TabPage In TabControl1.TabPages
            '    ' Loop through each control in the TabPage
            For Each ctrl As Control In tabPage.Controls
                ' Check if the control is a DataGridView and if its name matches the target name
                If TypeOf ctrl Is DataGridView AndAlso ctrl.Name = targetDataGridViewName Then
                    ' Remove the specific DataGridView by name
                    tabPage.Controls.Remove(ctrl)
                    ctrl.Dispose() ' Dispose of the DataGridView to free resources
                End If
            Next
        Next


        Dim OriginalDGviewcolumnsToHide As New List(Of String) From {"DataGridViewTextBoxColumn9", "DataGridViewTextBoxColumn10", "DataGridViewTextBoxColumn11", "DataGridViewTextBoxColumn12", "DataGridViewTextBoxColumn13", "REG_REG", "REG_SUN", "REG_SH", "REG_LH", "RD_SUN_SH", "REG_REG", "RD_SUN_LH", "ND_REG", "ND_SUN", "ND_SH", "ND_LH", "ND_RD_SUN_SH", "ND_RD_SUN_LH", "OT_REG"}
        Call ShowOriginalDataGridViewColumns(GView_DTR, OriginalDGviewcolumnsToHide)


        Call Calculate_DTR()
        Call ProcessHoursBreakdown()
        Call DuplicateAndHideDtrDGView()
    End Sub
    Private Sub DuplicateAndHideDtrDGView()
        Dim columnsToHide As New List(Of String) From {"DataGridViewTextBoxColumn3", "DataGridViewTextBoxColumn4", "DataGridViewTextBoxColumn5", "DataGridViewTextBoxColumn6", "DataGridViewTextBoxColumn7", "DataGridViewTextBoxColumn8", "ExtraTimeIn1", "ExtraTimeOut1"}
        Dim OriginalDGviewcolumnsToHide As New List(Of String) From {"DataGridViewTextBoxColumn9", "DataGridViewTextBoxColumn10", "DataGridViewTextBoxColumn11", "DataGridViewTextBoxColumn12", "DataGridViewTextBoxColumn13", "REG_REG", "REG_SUN", "REG_SH", "REG_LH", "RD_SUN_SH", "REG_REG", "RD_SUN_LH", "ND_REG", "ND_SUN", "ND_SH", "ND_LH", "ND_RD_SUN_SH", "ND_RD_SUN_LH", "OT_REG"}

        DuplicateAndModifyDataGridView(GView_DTR, columnsToHide)
        HideOriginalDataGridViewColumns(GView_DTR, OriginalDGviewcolumnsToHide)

    End Sub
    Private Sub DuplicateAndModifyDataGridView(originalDataGridView As DataGridView, hiddenColumns As List(Of String))
        ' Create a new DataGridView
        Dim newDataGridView As New DataGridView()
        With newDataGridView
            newDataGridView.Name = "Duplicate_DGV" ' Set this to your desired name
            ' Add the new DataGridView to the same TabPage as the original
            originalDataGridView.Parent.Controls.Add(newDataGridView)

            ' Position it relative to the original DataGridView
            .Location = New Point(originalDataGridView.Left, originalDataGridView.Bottom + 10)
            .Size = originalDataGridView.Size
            .AllowUserToAddRows = originalDataGridView.AllowUserToAddRows
            .AllowUserToDeleteRows = originalDataGridView.AllowUserToDeleteRows
            .ReadOnly = originalDataGridView.ReadOnly
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells ' Auto-size columns based on cells
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize ' Auto-size header height
        End With

        ' Copy columns from the original DataGridView
        For Each col As DataGridViewColumn In originalDataGridView.Columns
            Dim newCol As DataGridViewColumn = DirectCast(col.Clone(), DataGridViewColumn)
            newDataGridView.Columns.Add(newCol)
        Next

        ' Copy rows from the original DataGridView
        For Each row As DataGridViewRow In originalDataGridView.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataGridViewRow = DirectCast(row.Clone(), DataGridViewRow)
                For i As Integer = 0 To row.Cells.Count - 1
                    newRow.Cells(i).Value = row.Cells(i).Value
                Next
                newDataGridView.Rows.Add(newRow)
            End If
        Next

        ' Hide specified columns in the new DataGridView
        For Each columnName As String In hiddenColumns
            If newDataGridView.Columns.Contains(columnName) Then
                newDataGridView.Columns(columnName).Visible = False
            End If
        Next

        ' Auto-size column widths based on cell content
        For Each col As DataGridViewColumn In newDataGridView.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub

    Private Sub HideOriginalDataGridViewColumns(originalDataGridView As DataGridView, hiddenColumns As List(Of String))
        For Each columnName As String In hiddenColumns
            If originalDataGridView.Columns.Contains(columnName) Then
                originalDataGridView.Columns(columnName).Visible = False
            End If
        Next
    End Sub

    Private Sub ShowOriginalDataGridViewColumns(originalDataGridView As DataGridView, hiddenColumns As List(Of String))
        For Each columnName As String In hiddenColumns
            If originalDataGridView.Columns.Contains(columnName) Then
                originalDataGridView.Columns(columnName).Visible = True
            End If
        Next
    End Sub

    Private Sub BIOMETRICForm_FormClosing(sender As Object, e As EventArgs) Handles MyBase.Closing
        ' Define the name of the specific DataGridView you want to remove
        Dim targetDataGridViewName As String = "Duplicate_DGV" ' Example name for the duplicate DataGridView

        ' Loop through each TabPage in the TabControl
        For Each tabPage As TabPage In TabControl1.TabPages
            ' Loop through each control in the TabPage
            For Each ctrl As Control In tabPage.Controls
                ' Check if the control is a DataGridView and if its name matches the target name
                If TypeOf ctrl Is DataGridView AndAlso ctrl.Name = targetDataGridViewName Then
                    ' Remove the specific DataGridView by name
                    tabPage.Controls.Remove(ctrl)
                    ctrl.Dispose() ' Dispose of the DataGridView to free resources
                End If
            Next
        Next

        Dim OriginalDGviewcolumnsToHide As New List(Of String) From {"DataGridViewTextBoxColumn9", "DataGridViewTextBoxColumn10", "DataGridViewTextBoxColumn11", "DataGridViewTextBoxColumn12", "DataGridViewTextBoxColumn13", "REG_REG", "REG_SUN", "REG_SH", "REG_LH", "RD_SUN_SH", "REG_REG", "RD_SUN_LH", "ND_REG", "ND_SUN", "ND_SH", "ND_LH", "ND_RD_SUN_SH", "ND_RD_SUN_LH", "OT_REG"}
        ShowOriginalDataGridViewColumns(GView_DTR, OriginalDGviewcolumnsToHide)

    End Sub




    Private Sub FRM_BIOMETRIC_DTR_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Connect to MDB
        MDB_Connection_Init()
        Connect_to_MDB()

        GView_DTR.Rows.Clear()

        Dim processes As Process() = Process.GetProcessesByName("EXCEL")

        For Each process As Process In processes
            Dim processFileName As String = GetProcessFileName(process)

            If processFileName.EndsWith("PdfToExcel.xlsx", StringComparison.OrdinalIgnoreCase) Then
                process.Kill()
            End If
        Next

    End Sub

    Private Function GetProcessFileName(ByVal process As Process) As String
        Try
            Return process.MainModule.FileName
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Btn_Calculate_Click(sender As Object, e As EventArgs)

    End Sub







    Private Sub Btn_Payslip_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GView_DTR_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GView_DTR.CellContentClick

    End Sub

    Private Sub GView_DTR_DoubleClick(sender As Object, e As EventArgs) Handles GView_DTR.DoubleClick



        'If GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen Then
        '    GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
        'ElseIf GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Yellow Then
        '    GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Empty
        'ElseIf GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Empty Then
        '    GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        'ElseIf GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue Then
        '    GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        'End If


    End Sub

    Private Sub Btn_Hours_Breakdown_Click(sender As Object, e As EventArgs)
        ProcessHoursBreakdown()
    End Sub
    Private Sub ProcessHoursBreakdown()
        ' Loop through rows in GView_DTR
        For iRow = 0 To GView_DTR.Rows.Count - 3
            ' Exit if cell(1) is empty
            If GView_DTR.Rows(iRow).Cells(1).Value = "" Then
                Exit For
            End If

            ' Parse time and extract values
            Dim parsedTime_DTR_IN As DateTime
            Parsed_StrToDate(GView_DTR.Rows(iRow).Cells(2).Value, parsedTime_DTR_IN)
            Dim reportedTime As Integer = parsedTime_DTR_IN.Hour
            Dim totalHours As Double = CDbl(GView_DTR.Rows(iRow).Cells(14).Value)

            Dim regHours As Double = 8 ' Standard regular hours
            Dim otHours As Double = 0
            Dim isMorningShift As Boolean = 22 - reportedTime > 10 ' Morning shift logic (before 12 PM)

            ' Reset all current row columns (15 to 24) to 0
            ResetCells(GView_DTR.Rows(iRow), 15, 26)

            ' Process regular hours and OT logic
            ProcessRegularAndOTHours(GView_DTR.Rows(iRow), totalHours, regHours, otHours, isMorningShift)

            ' Set OT value in the last column
            GView_DTR.Rows(iRow).Cells(27).Value = otHours
        Next

        ' Array to store column indices for each hour type
        Dim columns As Integer() = {15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27}
        Dim totals(12) As Double ' Initialize totals array


        Try
            Dim chkcellValue As Object = GView_DTR.Rows(0).Cells(14).Value
            ' Check for null or invalid data before converting to double
            If chkcellValue Is Nothing OrElse Not IsNumeric(chkcellValue) Then
                Throw New InvalidCastException($"Invalid data")
            End If

            ' Sum values for rows 0 to 16
            For i = 0 To 16
                For j = 0 To columns.Length - 1
                    totals(j) += CDbl(GView_DTR.Rows(i).Cells(columns(j)).Value)
                Next
            Next

            ' Assign totals to row 17
            For j = 0 To columns.Length - 1
                GView_DTR.Rows(GView_DTR.Rows.Count - 2).Cells(columns(j)).Value = totals(j)
            Next

        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        ' GView_DTR.Rows(17).Cells(14).Value = "Total:"

    End Sub

    ' Helper function to handle regular hours and OT calculation
    Private Sub ProcessRegularAndOTHours(row As DataGridViewRow, totalHours As Double, regHours As Double, ByRef otHours As Double, isMorningShift As Boolean)
        ' Extract first day from the cell value (e.g., "Sunday - Monday" or "Saturday - Sunday")
        Dim firstDay As String = String.Empty
        Dim secondDay As String = String.Empty

        If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Contains("-") Then
            ' Split only if the "-" exists
            Dim parts As String() = row.Cells(1).Value.ToString().Split("-"c)
            If parts.Length >= 2 Then
                firstDay = parts(0).Trim()
                secondDay = parts(1).Trim()
            Else
                ' Handle unexpected split results if somehow there's only one part
                firstDay = parts(0).Trim()
                secondDay = String.Empty ' or handle the default logic for only one part
            End If
        Else
            ' Handle the case where there's no "-" at all
            firstDay = row.Cells(1).Value.ToString().Trim()
            secondDay = String.Empty
        End If

        ' Determine where to assign the regular and OT hours
        If firstDay = "Sunday" Or secondDay = "Sunday" Then
            Select Case row.DefaultCellStyle.BackColor
                Case Color.LightGreen ' Sunday Legal Holiday
                    AssignHours(row, totalHours, regHours, 20, otHours, isMorningShift)
                Case Color.Yellow ' Sunday Special Holiday
                    AssignHours(row, totalHours, regHours, 19, otHours, isMorningShift)
                Case Else ' Sunday (Non-Holiday)
                    AssignHours(row, totalHours, regHours, 16, otHours, isMorningShift)
            End Select
        Else ' Not Sunday
            Select Case row.DefaultCellStyle.BackColor
                Case Color.LightGreen ' Legal Holiday
                    AssignHours(row, totalHours, regHours, 18, otHours, isMorningShift)
                Case Color.Yellow ' Special Holiday
                    AssignHours(row, totalHours, regHours, 17, otHours, isMorningShift)
                Case Else ' Regular Day
                    AssignHours(row, totalHours, regHours, 15, otHours, isMorningShift)
            End Select
        End If
    End Sub

    ' Helper function to assign hours
    Private Sub AssignHours(row As DataGridViewRow, totalHours As Double, regHours As Double, cellIndex As Integer, ByRef otHours As Double, isMorningShift As Boolean)
        If isMorningShift Then
            If totalHours >= regHours Then
                row.Cells(cellIndex).Value = regHours 'Set cellIndex to reg hours
                otHours = totalHours - regHours 'Set the otHours
            Else
                row.Cells(cellIndex).Value = totalHours
                otHours = 0
            End If
        Else
            ' Draft NightShift
            ' Extract first day from the cell value (e.g., "Sunday - Monday" or "Saturday - Sunday")
            Dim firstDay As String = row.Cells(1).Value.Split("-"c)(0).Trim()
            Dim secondDay As String = row.Cells(1).Value.Split("-"c)(1).Trim()
            ' Determine where to assign the regular and OT hours
            If firstDay = "Sunday" And CInt(Me.Lbl_Num_of_Reporting_Days.Text) = 15 Then
                If totalHours >= regHours Then
                    row.Cells(cellIndex).Value = regHours 'Set cellIndex to reg hours
                    otHours = totalHours - regHours 'Set the otHours
                Else
                    row.Cells(cellIndex).Value = totalHours
                    otHours = 0
                End If

            ElseIf secondDay = "Sunday" And CInt(Me.Lbl_Num_of_Reporting_Days.Text) = 15 Then

                If totalHours >= regHours Then
                    row.Cells(cellIndex).Value = regHours 'Set cellIndex to reg hours
                    otHours = totalHours - regHours 'Set the otHours
                Else
                    row.Cells(cellIndex).Value = totalHours
                    otHours = 0
                End If

            Else
                If totalHours >= regHours Then
                    row.Cells(cellIndex).Value = regHours 'Set cellIndex to reg hours
                    otHours = totalHours - regHours 'Set the otHours
                Else
                    row.Cells(cellIndex).Value = totalHours
                    otHours = 0
                End If

            End If


        End If
    End Sub

    ' Helper function to reset cells
    Sub ResetCells(row As DataGridViewRow, startIndex As Integer, endIndex As Integer)
        For idx As Integer = startIndex To endIndex
            row.Cells(idx).Value = 0
        Next
    End Sub
    Private Sub Chk_Sunday_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Sunday.CheckedChanged
        If Chk_Sunday.Checked = True Then
            For iRow = 1 To 16 ' Number of Days in Cut-Off

                If GView_DTR.Rows(iRow).Cells(1).Value = "Sunday" Then
                    GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.LightBlue
                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor <> Color.Empty Then
                    'GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Empty
                End If

            Next
        Else
            For iRow = 1 To 16 ' Number of Days in Cut-Off

                If GView_DTR.Rows(iRow).Cells(1).Value = "Sunday" Then
                    GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Empty
                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor <> Color.Empty Then

                End If

            Next

        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Lbl_Absent_Count_Click(sender As Object, e As EventArgs) Handles Lbl_Absent_Count.Click

    End Sub

    Private Sub Btn_Save_DTR_Click(sender As Object, e As EventArgs) Handles Btn_Save_DTR.Click

        ' Get cut off period from Lbl_Period
        Call Save_DTR_Total_Hours(GlobalVariables.DTR_Selected_SubClient_ID, GlobalVariables.DTR_Selected_Employee_ID, GlobalVariables.sPayroll_Cutoff, CInt(Me.Lbl_Num_of_Reporting_Days.Text))

    End Sub

    Private Sub BtnSH_Click(sender As Object, e As EventArgs) Handles BtnSH.Click
        GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
        ProcessHoursBreakdown()

    End Sub

    Private Sub BtnLH_Click(sender As Object, e As EventArgs) Handles BtnLH.Click
        GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        ProcessHoursBreakdown()

    End Sub


    Private Sub GetTimeInOut(row As DataGridViewRow)


    End Sub


End Class
