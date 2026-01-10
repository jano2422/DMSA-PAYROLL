Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Conversion
Imports System.Windows

Public Class FRM_DTR_BIOMETRIC

    ' Variable to store the selected directory
    Private selectedDirectory As String = String.Empty
    Dim DefaultDTRDir As String = "\\DMSAC-SERVER\Files\MASTER_DTR"
    'Dim DefaultDTRDir As String = "C:\MASTER_DTR"
    Private Sub Btn_DTR_Click(sender As Object, e As EventArgs) Handles Btn_DTR.Click


        ' Clear the schedule grid and reset UI
        GView_Schedule.Rows.Clear()
        RemoveDataGridViewByName(DTR_TimeCalculationPanel, "Duplicate_DGV")
        ShowOriginalDataGridViewColumns(GView_DTR)

        ' Default DTR Directory


        ' Ensure a directory is selected
        If Not PromptForDirectorySelection(DefaultDTRDir, False, selectedDirectory) Then
            Exit Sub ' Exit if no directory is selected
        End If

        ' Show the employee list form
        FRM_DTR_EMPLOYEE_LIST.ShowDialog()

        ' Retrieve and show the employee schedule
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "No", 0)

        ' Ensure an employee is selected
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

        ' Filter files in the selected directory based on employee name
        Dim filteredFiles As List(Of String) = Directory.GetFiles(selectedDirectory, "*.pdf") _
        .Where(Function(file) Path.GetFileName(file).IndexOf(lastName, StringComparison.OrdinalIgnoreCase) >= 0 _
            OrElse Path.GetFileName(file).IndexOf(firstName, StringComparison.OrdinalIgnoreCase) >= 0).ToList()

        ' Notify the user if no matching files are found
        If filteredFiles.Count = 0 Then
            MsgBox("No files found containing the selected employee's name.", vbExclamation, "No Files Found")
        End If

        ' Show the modern file selection form and get the selected file
        Dim selectedFile As String = ShowModernFileSelectionForm(filteredFiles, selectedDirectory)
        If String.IsNullOrEmpty(selectedFile) Then
            MsgBox("No file selected.", vbExclamation, "Selection Canceled")
            Exit Sub
        End If

        ' Process the selected PDF file
        ProcessSelectedPDF(selectedFile)
    End Sub


    Private Function PromptForDirectorySelection(defaultDir As String, showPrompt As Boolean, ByRef selectedDirectory As String) As Boolean
        Try
            ' If a valid directory is already set, use it
            If Not String.IsNullOrEmpty(selectedDirectory) AndAlso Directory.Exists(selectedDirectory) Then
                Return True
            Else
                selectedDirectory = defaultDir
            End If

            ' Ensure the default directory exists
            If Not Directory.Exists(defaultDir) Then Directory.CreateDirectory(defaultDir)

            ' Allow user to reselect if showPrompt is enabled
            If showPrompt Then
                Using dialog As New CommonOpenFileDialog()
                    dialog.IsFolderPicker = True ' Enables folder selection
                    dialog.InitialDirectory = If(Directory.Exists(selectedDirectory), selectedDirectory, defaultDir)
                    dialog.Title = "Select a directory containing the files"

                    ' Show dialog and handle user selection
                    If dialog.ShowDialog() = CommonFileDialogResult.Ok Then
                        selectedDirectory = dialog.FileName
                        Return True
                    Else
                        MsgBox("No directory selected. Operation cancelled.", vbExclamation, "Directory Selection")
                        Return False
                    End If
                End Using
            End If

            Return True
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, vbCritical, "Error")
            Return False
        End Try
    End Function


    Private Sub ProcessSelectedPDF(selectedFile As String)
        Try
            ' Load the selected PDF file
            Dim pdf As New PdfDocument()
            Try
                pdf.LoadFromFile(selectedFile)
            Catch ex As Exception
                Debug.WriteLine($"Error loading PDF file: {ex.Message}")
                MsgBox("Failed to load the selected PDF file.", vbExclamation, "Error")
                Exit Sub
            End Try

            ' Define output Excel file path
            Dim exeDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim filePath As String = Path.Combine(exeDirectory, "PdfToExcel.xlsx")

            ' Convert and save PDF as Excel
            Try
                pdf.SaveToFile(filePath, FileFormat.XLSX)
            Catch ex As Exception
                Debug.WriteLine($"Error saving PDF to Excel: {ex.Message}")
                MsgBox("Failed to save PDF as Excel.", vbExclamation, "Error")
                Exit Sub
            End Try

            ' Remove previous DataGridView duplicates
            RemoveDataGridViewByName(DTR_TimeCalculationPanel, "Duplicate_DGV")

            ' Load the converted Excel file into the application
            Connect_to_Excel_DTR()
            RemoveDataGridViewByName(DTR_TimeCalculationPanel, "Duplicate_DGV")
            ShowOriginalDataGridViewColumns(GView_DTR)

            ' Perform DTR calculations
            Calculate_DTR()
            ProcessHoursBreakdown()
            DuplicateAndHideDtrDGView()

            ' Enable the save button
            SetButtonState(True, Btn_Save_DTR)

        Catch ex As Exception
            Debug.WriteLine($"Unexpected error processing PDF: {ex.Message}")
            MsgBox("An unexpected error occurred while processing the PDF.", vbExclamation, "Error")
        End Try
    End Sub

    Private Function ShowModernFileSelectionForm(filteredFiles As List(Of String), ByRef selectedDirectory As String) As String
        ' Pass the current directory to the FileSelectionControl
        Dim fileSelectionControl As New FileSelectionControl(filteredFiles, selectedDirectory)

        Dim fileSelectionWindow As New Window With {
        .Title = "Select a File",
        .Width = 600,
        .Height = 400,
        .WindowStartupLocation = WindowStartupLocation.CenterScreen,
        .Content = fileSelectionControl
    }

        Dim result = fileSelectionWindow.ShowDialog()

        ' If the dialog result is True, update the directory and return the selected file
        If result.HasValue AndAlso result.Value Then
            selectedDirectory = fileSelectionControl.SelectedDirectory
            Return fileSelectionControl.SelectedFile
        End If

        Return Nothing
    End Function

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
            .Location = New System.Drawing.Point(10, 10),
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

    Private Sub FRM_BIOMETRIC_DTR_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
            ' Log or display the error
            MsgBox($"An error occurred during form close: {ex.Message}", vbExclamation, "Error")
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
                    btn.ForeColor = System.Drawing.SystemColors.ControlText ' Default text color
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
        Dim columns As Integer() = {14, 15, 16, 17, 18, 19}
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

            Dim allEmpty As Boolean = Enumerable.Range(2, 9).All(Function(col) String.IsNullOrEmpty(CStr(GView_DTR.Rows(iRow).Cells(col).Value)))
            If allEmpty Then
                Continue For
            End If

            ' Parse time and extract values
            Dim parsedTime_DTR_IN As DateTime
            Parsed_StrToDate(GView_DTR.Rows(iRow).Cells(2).Value, parsedTime_DTR_IN)
            Dim reportedTime As Integer = parsedTime_DTR_IN.Hour
            Dim totalHours As Double = CDbl(GView_DTR.Rows(iRow).Cells(14).Value)

            Dim regHours As Double = 8 ' Standard regular hours
            Dim otHours As Double = 0

            ' Reset all current row columns (15 to 26) to 0
            ResetCells(GView_DTR.Rows(iRow), 15, 21)

            ' Process regular hours and OT logic
            ProcessRegularAndOTHours(GView_DTR.Rows(iRow), totalHours, regHours, otHours)

            ' Set OT value in the last column
            GView_DTR.Rows(iRow).Cells(19).Value = otHours
        Next

        ' Array to store column indices for each hour type
        Dim columns As Integer() = {14, 15, 16, 17, 18, 19}
        Dim totals(5) As Double ' Initialize totals array


        Try


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
    Private Sub ProcessRegularAndOTHours(row As DataGridViewRow, totalHours As Double, regHours As Double, ByRef otHours As Double)
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
            AssignHours(row, totalHours, regHours, 16, otHours)
        Else ' Not Sunday
            Select Case row.DefaultCellStyle.BackColor
                Case Color.LightGreen ' Legal Holiday
                    AssignHours(row, totalHours, regHours, 18, otHours)
                Case Color.Yellow ' Special Holiday
                    AssignHours(row, totalHours, regHours, 17, otHours)
                Case Else ' Regular Day
                    AssignHours(row, totalHours, regHours, 15, otHours)
            End Select
        End If
    End Sub

    ' Helper function to assign hours
    Private Sub AssignHours(row As DataGridViewRow, totalHours As Double, regHours As Double, cellIndex As Integer, ByRef otHours As Double)
        If totalHours >= regHours Then
            row.Cells(cellIndex).Value = Math.Round(regHours, 2)
            otHours = Math.Round(totalHours - regHours, 2)
        Else
            row.Cells(cellIndex).Value = Math.Round(totalHours, 2)
            otHours = 0
        End If
    End Sub




    Private Sub Chk_Sunday_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Sunday.CheckedChanged
        If Chk_Sunday.Checked = True Then
            For iRow = 0 To 16 ' Number of Days in Cut-Off

                If GView_DTR.Rows(iRow).Cells(1).Value = "Sunday" Then
                    GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.LightBlue
                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor <> Color.Empty Then
                    'GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Empty
                End If

            Next
        Else
            For iRow = 0 To 16 ' Number of Days in Cut-Off

                If GView_DTR.Rows(iRow).Cells(1).Value = "Sunday" Then
                    GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Empty
                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor <> Color.Empty Then

                End If

            Next

        End If
    End Sub
    Private Function GetDecimalFromTextBox(txt As TextBox) As Decimal
        If txt Is Nothing Then Return 0D

        Dim value As Decimal
        If Decimal.TryParse(txt.Text.Trim(), value) Then
            Return value
        End If

        Return 0D
    End Function

    Private Sub Btn_Save_DTR_Click(sender As Object, e As EventArgs) Handles Btn_Save_DTR.Click
        ' Get cut off period from Lbl_Period
        Dim cbDeduct As Decimal = GetDecimalFromTextBox(szCashBond)
        Dim sssLoanDeduct As Decimal = GetDecimalFromTextBox(szSSSLoan)
        Dim piLoanDeduct As Decimal = GetDecimalFromTextBox(szPILoan)

        Call Save_DTR_Total_Hours(GlobalVariables.DTR_Selected_SubClient_ID, GlobalVariables.DTR_Selected_Employee_ID, GlobalVariables.sPayroll_Cutoff, CInt(Me.Lbl_Num_of_Reporting_Days.Text), cbDeduct, sssLoanDeduct, piLoanDeduct)
        Call Save_DTR_Hours_Per_Day(GlobalVariables.DTR_Selected_SubClient_ID, GlobalVariables.DTR_Selected_Employee_ID)

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

    Private Sub Btn_Calc_DTR_Click_1(sender As Object, e As EventArgs) Handles Btn_Calc_DTR.Click
        RemoveDataGridViewByName(DTR_TimeCalculationPanel, "Duplicate_DGV")
        ShowOriginalDataGridViewColumns(GView_DTR)
        Calculate_DTR()
        ProcessHoursBreakdown()
        DuplicateAndHideDtrDGView()
        TabControl2.SelectedTab = dtrBreakDownPage
    End Sub
End Class
