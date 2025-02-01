Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Conversion


Public Class FRM_DTR_BIOMETRIC

    ' Variable to store the selected directory
    Private selectedDirectory As String = String.Empty

    Private Sub Btn_DTR_Click(sender As Object, e As EventArgs) Handles Btn_DTR.Click
        ' Check if the trial period has ended
        If Now.Year = 2026 Then
            MsgBox("Trial Period Ends")
            Exit Sub ' Exit the subroutine if the trial period has ended
        End If

        ' Call the subroutine to ensure a directory is selected
        If Not PromptForDirectorySelection(selectedDirectory) Then
            Exit Sub ' Exit the main subroutine if no directory is selected
        End If

        ' Show the employee list form
        FRM_DTR_EMPLOYEE_LIST.ShowDialog()


        ' Retrieve and show the employee schedule
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "No", 0)
        If String.IsNullOrEmpty(GlobalVariables.DTR_Selected_Employee_Name) Then
            MsgBox("No selected employee found", vbExclamation, "No Employee Found")
            Exit Sub
        End If
        ' Extract selected employee's name
        Dim szSelectedEmpName As String = GlobalVariables.DTR_Selected_Employee_Name

        ' Split the full name into last name and first name
        Dim nameParts() As String = szSelectedEmpName.Split(","c)
        Dim lastName As String = nameParts(0).Trim()
        Dim firstName As String = If(nameParts.Length > 1, nameParts(1).Trim(), "")

        ' Filter files in the selected directory
        Dim filteredFiles As List(Of String) = Directory.GetFiles(selectedDirectory, "*.pdf") _
        .Where(Function(file) Path.GetFileName(file).IndexOf(lastName, StringComparison.OrdinalIgnoreCase) >= 0 _
            OrElse Path.GetFileName(file).IndexOf(firstName, StringComparison.OrdinalIgnoreCase) >= 0).ToList()

        ' Notify the user if no matching files are found
        If filteredFiles.Count = 0 Then
            MsgBox("No files found containing the selected employee's name.", vbExclamation, "No Files Found")
        End If

        ' Create and show the custom file selection dialog
        ShowModernFileSelectionForm(filteredFiles)
    End Sub

    Private Function PromptForDirectorySelection(ByRef selectedDirectory As String) As Boolean
        ' Check if a directory has already been selected
        If String.IsNullOrEmpty(selectedDirectory) Then
            Using folderBrowser As New FolderBrowserDialog()
                ' Get the application's base directory and set the default path to the "DTR" folder
                Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory
                Dim dtrPath As String = Path.Combine(exeDirectory, "DTR")
                folderBrowser.Description = "Select a directory containing the files"
                folderBrowser.SelectedPath = dtrPath

                ' Show the folder browser dialog to the user
                If folderBrowser.ShowDialog() = DialogResult.OK Then
                    ' Update the selected directory with the user's choice
                    selectedDirectory = folderBrowser.SelectedPath
                    Return True ' Directory selected successfully
                Else
                    ' Notify the user if no directory is selected
                    MsgBox("No directory selected. Operation cancelled.", vbExclamation, "Directory Selection")
                    Return False ' Indicate that no directory was selected
                End If
            End Using
        End If

        Return True ' Directory already selected
    End Function


    Private Sub ShowModernFileSelectionForm(filteredFiles As List(Of String))
        Dim fileSelectionForm As New Form()

        Try
            ' Set basic properties of the form
            With fileSelectionForm
                .Text = "Select DTR File"
                .Size = New Size(700, 500) ' Increased size for modern look
                .StartPosition = FormStartPosition.CenterScreen
                .FormBorderStyle = FormBorderStyle.FixedDialog
                .MaximizeBox = False
                .MinimizeBox = False
                .ShowInTaskbar = False
                .Font = New Font("Segoe UI", 12, FontStyle.Regular) ' Modern font and larger size
                .BackColor = Color.White ' Clean white background for the form
            End With

            ' Create a ListBox to show filtered files
            Dim fileListBox As New ListBox() With {
    .Dock = DockStyle.Top,
    .Height = 250,
    .Font = New Font("Segoe UI", 12, FontStyle.Regular), ' Larger font for list box items
    .ItemHeight = 30, ' Adjust item height for better readability
    .BackColor = Color.LightYellow, ' Light yellow background for the list box
    .ForeColor = Color.Black ' Black text color for readability
}
            fileListBox.Items.AddRange(filteredFiles.Select(Function(f) Path.GetFileName(f)).ToArray())

            ' Create a Reselect Folder button
            Dim reselectFolderButton As New Button() With {
    .Text = "Reselect DTR Folder Path",
    .Dock = DockStyle.Bottom,
    .Height = 50, ' Increased button height for a modern touch
    .Font = New Font("Segoe UI", 14, FontStyle.Bold), ' Modern font and bold style
    .FlatStyle = FlatStyle.Flat, ' Flat style for modern look
    .BackColor = Color.Maroon, ' Maroon background for the button
    .ForeColor = Color.White ' White text color for contrast
}

            ' Create a Cancel button
            Dim cancelButton As New Button() With {
    .Text = "Cancel",
    .Dock = DockStyle.Bottom,
    .Height = 50, ' Increased button height for consistency
    .Font = New Font("Segoe UI", 14, FontStyle.Bold), ' Modern font and bold style
    .FlatStyle = FlatStyle.Flat, ' Flat style for modern look
    .BackColor = Color.Black, ' Black background for the button
    .ForeColor = Color.Yellow ' Yellow text color for contrast
}

            ' Add controls to the form
            fileSelectionForm.Controls.Add(fileListBox)
            fileSelectionForm.Controls.Add(reselectFolderButton)
            fileSelectionForm.Controls.Add(cancelButton)

            ' Handle Reselect Folder button click
            AddHandler reselectFolderButton.Click, Sub()
                                                       Try
                                                           Using folderBrowser As New FolderBrowserDialog()
                                                               folderBrowser.Description = "Select a new directory"
                                                               folderBrowser.SelectedPath = selectedDirectory

                                                               If folderBrowser.ShowDialog() = DialogResult.OK Then
                                                                   selectedDirectory = folderBrowser.SelectedPath
                                                                   fileSelectionForm.Close()
                                                               End If
                                                           End Using
                                                       Catch ex As Exception
                                                           ' Log and display error if folder selection fails
                                                           Debug.WriteLine($"Error selecting folder: {ex.Message}")
                                                           MsgBox("An error occurred while selecting a folder.", vbExclamation, "Error")
                                                       End Try
                                                   End Sub

            ' Handle ListBox item double-click
            AddHandler fileListBox.MouseDoubleClick, Sub(sender As Object, e As MouseEventArgs)
                                                         Try
                                                             Dim index As Integer = fileListBox.IndexFromPoint(e.Location)
                                                             If index <> ListBox.NoMatches Then
                                                                 Dim selectedFile As String = filteredFiles(index)

                                                                 ' Process the selected file
                                                                 Dim pdf As New PdfDocument()
                                                                 Try
                                                                     pdf.LoadFromFile(selectedFile)
                                                                 Catch ex As Exception
                                                                     ' Log and display error if file cannot be loaded
                                                                     Debug.WriteLine($"Error loading PDF file: {ex.Message}")
                                                                     MsgBox("Failed to load the selected PDF file.", vbExclamation, "Error")
                                                                     Return
                                                                 End Try

                                                                 Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory
                                                                 Dim filePath As String = System.IO.Path.Combine(exeDirectory, "PdfToExcel.xlsx")

                                                                 Try
                                                                     pdf.SaveToFile(filePath, FileFormat.XLSX)
                                                                 Catch ex As Exception
                                                                     ' Log and display error if file cannot be saved
                                                                     Debug.WriteLine($"Error saving PDF to Excel: {ex.Message}")
                                                                     MsgBox("Failed to save PDF as Excel.", vbExclamation, "Error")
                                                                     Return
                                                                 End Try

                                                                 RemoveDataGridViewByName(DTR_TimeCalculationPanel, "Duplicate_DGV")
                                                                 fileSelectionForm.Close()

                                                                 Connect_to_Excel_DTR()
                                                                 RemoveDataGridViewByName(DTR_TimeCalculationPanel, "Duplicate_DGV")
                                                                 ShowOriginalDataGridViewColumns(GView_DTR)
                                                                 Calculate_DTR()
                                                                 ProcessHoursBreakdown()
                                                                 DuplicateAndHideDtrDGView()

                                                                 SetButtonState(True, Btn_Save_DTR)
                                                             End If
                                                         Catch ex As Exception
                                                             ' Log and display error if any other error occurs
                                                             Debug.WriteLine($"Error processing ListBox item: {ex.Message}")
                                                             MsgBox("An error occurred while processing the selected file.", vbExclamation, "Error")
                                                         End Try
                                                     End Sub

            ' Handle Cancel button click
            AddHandler cancelButton.Click, Sub()
                                               Try
                                                   fileSelectionForm.Close()
                                               Catch ex As Exception
                                                   ' Log and display error if closing the form fails
                                                   Debug.WriteLine($"Error closing file selection form: {ex.Message}")
                                                   MsgBox("An error occurred while closing the form.", vbExclamation, "Error")
                                               End Try
                                           End Sub

            ' Show the custom file selection dialog
            fileSelectionForm.ShowDialog()
        Catch ex As Exception
            ' Catch any other errors that may occur during form creation or initialization
            Debug.WriteLine($"Error initializing the file selection form: {ex.Message}")
            MsgBox("An error occurred while setting up the file selection form.", vbExclamation, "Error")
        End Try
    End Sub



    Private Sub Btn_Calc_DTR_Click(sender As Object, e As EventArgs) Handles Btn_Calc_DTR.Click
        RemoveDataGridViewByName(DTR_TimeCalculationPanel, "Duplicate_DGV")
        ShowOriginalDataGridViewColumns(GView_DTR)
        Calculate_DTR()
        ProcessHoursBreakdown()
        DuplicateAndHideDtrDGView()
    End Sub

    Private Sub DuplicateAndHideDtrDGView()
        Dim columnsToHide As New List(Of String) From {"DataGridViewTextBoxColumn3", "DataGridViewTextBoxColumn4", "DataGridViewTextBoxColumn5", "DataGridViewTextBoxColumn6", "DataGridViewTextBoxColumn7", "DataGridViewTextBoxColumn8", "ExtraTimeIn1", "ExtraTimeOut1"}
        Dim OriginalDGviewcolumnsToHide As New List(Of String) From {"DataGridViewTextBoxColumn9", "DataGridViewTextBoxColumn10", "DataGridViewTextBoxColumn11", "DataGridViewTextBoxColumn12", "DataGridViewTextBoxColumn13", "REG_REG", "REG_SUN", "REG_SH", "REG_LH", "RD_SUN_SH", "REG_REG", "RD_SUN_LH", "ND_REG", "ND_SUN", "ND_SH", "ND_LH", "ND_RD_SUN_SH", "ND_RD_SUN_LH", "OT_REG"}

        DuplicateAndModifyDataGridView(GView_DTR, columnsToHide, DTR_TimeCalculationPanel)
        HideOriginalDataGridViewColumns(GView_DTR, OriginalDGviewcolumnsToHide)

    End Sub
    Private Sub DuplicateAndModifyDataGridView(originalDataGridView As DataGridView, hiddenColumns As List(Of String), targetPanel As Panel)
        ' Check if a DataGridView with the desired name already exists
        Dim existingDataGridView As DataGridView = Nothing

        For Each ctrl As Control In targetPanel.Controls
            If TypeOf ctrl Is DataGridView AndAlso ctrl.Name = "Duplicate_DGV" Then
                existingDataGridView = DirectCast(ctrl, DataGridView)
                Exit For
            End If
        Next

        ' If it exists, clear it; otherwise, create a new one
        Dim newDataGridView As DataGridView
        If existingDataGridView IsNot Nothing Then
            newDataGridView = existingDataGridView
            newDataGridView.Rows.Clear()
            newDataGridView.Columns.Clear()
        Else
            newDataGridView = New DataGridView() With {
            .Name = "Duplicate_DGV",
            .Location = New Point(10, 10),
            .Size = originalDataGridView.Size,
            .AllowUserToAddRows = originalDataGridView.AllowUserToAddRows,
            .AllowUserToDeleteRows = originalDataGridView.AllowUserToDeleteRows,
            .ReadOnly = originalDataGridView.ReadOnly,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        }
            targetPanel.Controls.Add(newDataGridView)
        End If

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

    Private Sub ShowOriginalDataGridViewColumns(originalDataGridView As DataGridView)

        Dim showColumns As New List(Of String) From {"DataGridViewTextBoxColumn9", "DataGridViewTextBoxColumn10", "DataGridViewTextBoxColumn11", "DataGridViewTextBoxColumn12", "DataGridViewTextBoxColumn13", "REG_REG", "REG_SUN", "REG_SH", "REG_LH", "RD_SUN_SH", "REG_REG", "RD_SUN_LH", "ND_REG", "ND_SUN", "ND_SH", "ND_LH", "ND_RD_SUN_SH", "ND_RD_SUN_LH", "OT_REG"}

        For Each columnName As String In showColumns
            If originalDataGridView.Columns.Contains(columnName) Then
                originalDataGridView.Columns(columnName).Visible = True
            End If
        Next
    End Sub

    Private Sub BIOMETRICForm_FormClosing(sender As Object, e As EventArgs) Handles MyBase.Closing
        RemoveDataGridViewByName(DTR_TimeCalculationPanel, "Duplicate_DGV")
        ShowOriginalDataGridViewColumns(GView_DTR)
    End Sub

    Private Sub RemoveDataGridViewByName(targetPanel As Panel, dataGridViewName As String)

        ' Loop through each control in the TabPage
        For Each ctrl As Control In targetPanel.Controls
            ' Check if the control is a DataGridView and if its name matches the target name
            If TypeOf ctrl Is DataGridView AndAlso ctrl.Name = dataGridViewName Then
                ' Remove the specific DataGridView by name
                targetPanel.Controls.Remove(ctrl)
                ctrl.Dispose() ' Dispose of the DataGridView to free resources
                Exit Sub ' Exit after removing the first match
            End If
        Next
    End Sub

    Private Sub FRM_BIOMETRIC_DTR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try



            ' Disable buttons at form load
            SetButtonState(False, Btn_Save_DTR)

            ' Initialize and connect to the MDB database
            MDB_Connection_Init()
            Connect_to_MDB()

            ' Clear any existing rows in the GView_DTR grid view
            GView_DTR.Rows.Clear()

            ' Terminate any running instances of Excel that are using "PdfToExcel.xlsx"
            TerminateExcelProcesses("PdfToExcel.xlsx")
        Catch ex As Exception
            ' Log or display the error
            MsgBox($"An error occurred during form load: {ex.Message}", vbExclamation, "Error")
        End Try
    End Sub



    ''' <summary>
    ''' Terminates Excel processes that have a specific file open.
    ''' </summary>
    ''' <param name="fileName">The name of the file to check for in running Excel processes.</param>
    Private Sub TerminateExcelProcesses(fileName As String)
        Try
            ' Get all running Excel processes
            Dim processes As Process() = Process.GetProcessesByName("EXCEL")

            ' Iterate through each process
            For Each process As Process In processes
                Dim processFileName As String = GetProcessFileName(process)

                ' Terminate the process if it matches the specified file name
                If processFileName.EndsWith(fileName, StringComparison.OrdinalIgnoreCase) Then
                    process.Kill()
                End If
            Next
        Catch ex As Exception
            ' Handle any errors during process termination
            MsgBox($"An error occurred while terminating Excel processes: {ex.Message}", vbExclamation, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Enables or disables specific buttons and visually changes their appearance based on the action.
    ''' </summary>
    ''' <param name="enable">If True, enables the buttons. If False, disables the buttons.</param>
    ''' <param name="buttons">Array of buttons to enable/disable.</param>
    Private Sub SetButtonState(enable As Boolean, ParamArray buttons() As Button)
        Try
            ' Loop through each button and enable/disable it based on the 'enable' flag
            For Each btn As Button In buttons
                If enable Then
                    ' Enable button, restore appearance, and set cursor to default
                    btn.Enabled = True
                    btn.BackColor = Color.YellowGreen ' Default background color
                    btn.ForeColor = SystemColors.ControlText ' Default text color
                    btn.Cursor = Cursors.Hand ' Change cursor to Hand when enabled (for better UX)
                Else
                    ' Disable button, visually gray it out, and set cursor to Arrow
                    btn.Enabled = False
                    btn.BackColor = Color.LightGray
                    btn.ForeColor = Color.DarkGray
                    btn.Cursor = Cursors.Arrow ' Set cursor to default Arrow when disabled
                End If
            Next
        Catch ex As Exception
            ' Log or display an error if any issue occurs
            Debug.WriteLine($"Error setting button state: {ex.Message}")
            MsgBox("An error occurred while setting the button state.", vbExclamation, "Error")
        End Try
    End Sub

    Public Sub SetSelectedTabPage(tabControl As TabControl, tabPage As TabPage)
        If tabControl.TabPages.Contains(tabPage) Then
            tabControl.SelectedTab = tabPage
        Else
            MsgBox("TabPage not found.", vbExclamation, "Error")
        End If
    End Sub



    ''' <summary>
    ''' Retrieves the file name of the main module of a given process.
    ''' </summary>
    ''' <param name="process">The process to retrieve the file name from.</param>
    ''' <returns>The file name of the process's main module, or an empty string if inaccessible.</returns>
    Private Function GetProcessFileName(ByVal process As Process) As String
        Try
            Return process.MainModule.FileName
        Catch ex As Exception
            ' Log the error for debugging purposes (optional)
            Debug.WriteLine($"Error retrieving file name for process {process.Id}: {ex.Message}")

            ' Return an empty string if unable to retrieve the file name
            Return String.Empty
        End Try
    End Function

    Private Sub btn_Breakdown_Click(sender As Object, e As EventArgs) Handles btn_Breakdown.Click
        ShowOriginalDataGridViewColumns(GView_DTR)
        Dim columns As Integer() = {14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27}
        ' Copy data to original DataGridView if Duplicate_DGV exists
        Dim duplicateDataGridView As DataGridView = FindDuplicateDataGridView("Duplicate_DGV")
        If duplicateDataGridView IsNot Nothing Then
            CopyAndCalculateTotals(duplicateDataGridView, GView_DTR, columns)
        End If

        DuplicateAndHideDtrDGView()
    End Sub


    ' Helper function to find the duplicate DataGridView by name
    Private Function FindDuplicateDataGridView(name As String) As DataGridView
        For Each ctrl As Control In DTR_TimeCalculationPanel.Controls
            If TypeOf ctrl Is DataGridView AndAlso ctrl.Name = name Then
                Return DirectCast(ctrl, DataGridView)
            End If
        Next

        ' Display error message if DataGridView is not found
        MessageBox.Show($"The DataGridView '{name}' was not found on the breakdown page. Please contact the administrator.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        Return Nothing
    End Function
    Private Sub CopyAndCalculateTotals(duplicateDataGridView As DataGridView, originalDataGridView As DataGridView, columnIndices As Integer())
        Dim totals(columnIndices.Length - 1) As Double ' Initialize totals array
        Dim invalidCells As New List(Of DataGridViewCell) ' Track invalid cells
        Dim errorMessages As New List(Of String) ' Collect error messages for all invalid cells

        Try
            ' Copy values from the duplicate DataGridView to the original DataGridView
            For rowIndex As Integer = 0 To Math.Min(duplicateDataGridView.Rows.Count - 1, originalDataGridView.Rows.Count - 1)
                For Each columnIndex In columnIndices
                    Dim cellValue As Object = duplicateDataGridView.Rows(rowIndex).Cells(columnIndex).Value
                    If cellValue IsNot Nothing Then
                        originalDataGridView.Rows(rowIndex).Cells(columnIndex).Value = cellValue
                    End If
                Next
            Next

            ' Sum values for rows 0 to 16 in the original DataGridView
            For i = 0 To Math.Min(originalDataGridView.Rows.Count - 1, 16)
                For j = 0 To columnIndices.Length - 1
                    Dim cellValue As Object = originalDataGridView.Rows(i).Cells(columnIndices(j)).Value
                    If cellValue IsNot Nothing Then
                        ' Check if value is numeric
                        If IsNumeric(cellValue) Then
                            totals(j) += CDbl(cellValue)
                        Else
                            ' Highlight the invalid cell and record error
                            Dim invalidCell = originalDataGridView.Rows(i).Cells(columnIndices(j))
                            HighlightCell(invalidCell)

                            invalidCells.Add(invalidCell)

                            ' Get the column name (header text)
                            Dim columnName As String = originalDataGridView.Columns(columnIndices(j)).HeaderText

                            ' Add detailed error message with column name
                            errorMessages.Add($"Invalid value at Row {i + 1}, Column '{columnName}'.")
                        End If
                    End If
                Next
            Next

            ' Assign totals to the second-to-last row of the original DataGridView
            Dim targetRowIndex As Integer = originalDataGridView.Rows.Count - 2
            If targetRowIndex >= 0 Then
                For j = 0 To columnIndices.Length - 1
                    originalDataGridView.Rows(targetRowIndex).Cells(columnIndices(j)).Value = totals(j)
                Next
            Else
                Throw New IndexOutOfRangeException("Target row index is invalid.")
            End If

            ' Display all error messages if there are invalid cells
            If errorMessages.Count > 0 Then
                Throw New InvalidCastException(String.Join(Environment.NewLine, errorMessages))
            End If

        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Reset the highlights for invalid cells after a delay
            If invalidCells.Count > 0 Then
                Dim resetTimer As New Timer With {.Interval = 3000} ' Highlight for 3 seconds
                AddHandler resetTimer.Tick, Sub()
                                                For Each cell In invalidCells
                                                    cell.Style.BackColor = Color.White ' Reset to default
                                                Next
                                                resetTimer.Stop()
                                                resetTimer.Dispose()
                                            End Sub
                resetTimer.Start()
            End If
        End Try
    End Sub

    ' Helper Method to Highlight a Cell
    Private Sub HighlightCell(cell As DataGridViewCell)
        cell.Style.BackColor = Color.LightCoral ' Use light red (LightCoral) for highlighting
        cell.DataGridView.CurrentCell = cell ' Optionally focus on the first invalid cell
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

            ' Reset all current row columns (15 to 26) to 0
            ResetCells(GView_DTR.Rows(iRow), 15, 26)

            ' Process regular hours and OT logic
            ProcessRegularAndOTHours(GView_DTR.Rows(iRow), totalHours, regHours, otHours, isMorningShift)

            ' Set OT value in the last column
            GView_DTR.Rows(iRow).Cells(27).Value = otHours
        Next

        ' Array to store column indices for each hour type
        Dim columns As Integer() = {14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27}
        Dim totals(13) As Double ' Initialize totals array


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
            If firstDay = "Sunday" Then
                If totalHours >= regHours Then
                    row.Cells(cellIndex).Value = regHours 'Set cellIndex to reg hours
                    otHours = totalHours - regHours 'Set the otHours
                Else
                    row.Cells(cellIndex).Value = totalHours
                    otHours = 0
                End If

            ElseIf secondDay = "Sunday" Then

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

    Private Sub Btn_TimeCalcView_Click(sender As Object, e As EventArgs) Handles Btn_TimeCalcView.Click
        TabControl2.SelectedTab = dtrBreakDownPage
    End Sub

    Private Sub Btn_TimeDtlView_Click(sender As Object, e As EventArgs) Handles Btn_TimeDtlView.Click
        TabControl2.SelectedTab = actualDtrPage
    End Sub
End Class
