Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Conversion
Imports System.Windows
Imports DMSA_System.Models

Public Class FRM_DTR_BIOMETRIC

    ' Variable to store the selected directory
    Private selectedDirectory As String = String.Empty
    'Dim DefaultDTRDir As String = "\\DMSAC-SERVER\Files\MASTER_DTR"
    Dim DefaultDTRDir As String = "C:\MASTER_DTR"
    Public Property AutoStartForSelectedEmployee As Boolean
    Private isRefreshingDtrViews As Boolean
    Private isRecalculatingDtr As Boolean
    Private isUpdatingClassificationGrid As Boolean
    Private ReadOnly dtrCalculationTable As New DtrCalculationTable()
    Private Const DtrDateColumnIndex As Integer = 0
    Private Const DtrDayColumnIndex As Integer = 1
    Private Const RawPunchStartColumnIndex As Integer = 2
    Private Const RawPunchEndColumnIndex As Integer = 9
    Private Shared ReadOnly RawDtrVisibleColumns As Integer() = Enumerable.Range(DtrDateColumnIndex, RawPunchEndColumnIndex + 1).ToArray()

    Public ReadOnly Property DtrCalculations As DtrCalculationTable
        Get
            Return dtrCalculationTable
        End Get
    End Property

    Public Sub StartForSelectedEmployee()
        StartDtrSelection(False)
    End Sub

    Private Sub StartDtrSelection(promptForEmployee As Boolean)
        ' Clear the schedule grid and reset UI
        GView_Schedule.Rows.Clear()
        ClearClassificationGrid()
        DtrCalculations.Clear()
        ClearTimeCalculationView()

        ' Default DTR Directory


        ' Ensure a directory is selected
        If Not PromptForDirectorySelection(DefaultDTRDir, False, selectedDirectory) Then
            Exit Sub ' Exit if no directory is selected
        End If

        If promptForEmployee Then
            Dim previousProcess = GlobalVariables.sDTR_or_Schedule_Process
            GlobalVariables.sDTR_or_Schedule_Process = "BIOMETRIC_DTR"
            FRM_DTR_EMPLOYEE_LIST_ALL.ShowDialog()
            GlobalVariables.sDTR_or_Schedule_Process = previousProcess
        End If

        ' Retrieve and show the employee schedule
        Call Show_Employee_Schedule(GlobalVariables.DTR_Selected_Employee_ID, "No", 0)

        ' Ensure an employee is selected
        If String.IsNullOrEmpty(GlobalVariables.DTR_Selected_Employee_Name) Then
            MsgBox("No selected employee found", vbExclamation, "No Employee Found")
            Exit Sub
        End If

        ' Extract selected employee's name
        Dim szSelectedEmpName As String = GlobalVariables.DTR_Selected_Employee_Name
        Lbl_IDNumber.Text = GlobalVariables.DTR_Selected_Employee_ID
        Lbl_Name.Text = GlobalVariables.DTR_Selected_Employee_Name
        DTR_Lbl_Period.Text = GlobalVariables.sPayroll_Cutoff

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

            ' Reset the calculation view before loading the next DTR.
            ClearClassificationGrid()
            DtrCalculations.Clear()
            ClearTimeCalculationView()

            ' Load the converted Excel file into the application
            Connect_to_Excel_DTR()
            ClearTimeCalculationView()

            ' Perform DTR calculations
            Calculate_DTR()
            BuildClassificationGrid()
            ProcessHoursBreakdown()
            RefreshDtrViews()

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

    Private Sub RefreshDtrViews()
        Try
            isRefreshingDtrViews = True
            ConfigureRawDtrGridColumns()
            PopulateTimeCalculationView()
        Finally
            isRefreshingDtrViews = False
        End Try

    End Sub

    Private Sub ConfigureRawDtrGridColumns()
        If GView_DTR Is Nothing Then Return

        GView_DTR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        GView_DTR.AllowUserToAddRows = False
        GView_DTR.AllowUserToDeleteRows = False

        For columnIndex As Integer = 0 To GView_DTR.Columns.Count - 1
            Dim column = GView_DTR.Columns(columnIndex)
            Dim isRawVisible = Array.IndexOf(RawDtrVisibleColumns, columnIndex) >= 0
            Dim isEditablePunch = columnIndex >= RawPunchStartColumnIndex AndAlso columnIndex <= RawPunchEndColumnIndex

            column.Visible = isRawVisible
            column.ReadOnly = Not isEditablePunch
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            column.Frozen = columnIndex <= DtrDayColumnIndex
        Next
    End Sub

    Private Sub PopulateTimeCalculationView()
        GView_TimeCalculation.Rows.Clear()
        GView_TimeCalculation.Columns.Clear()
        GView_TimeCalculation.AllowUserToAddRows = False
        GView_TimeCalculation.AllowUserToDeleteRows = False
        GView_TimeCalculation.ReadOnly = True
        GView_TimeCalculation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GView_TimeCalculation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GView_TimeCalculation.DataSource = Nothing

        GView_TimeCalculation.DataSource = DtrCalculations.ToBreakdownTable(PeriodCoverageDates())

        If GView_TimeCalculation.Columns.Contains("BreakdownLabel") Then
            With GView_TimeCalculation.Columns("BreakdownLabel")
                .HeaderText = "Breakdown of Hours"
                .Frozen = True
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 150
            End With
        End If

        For Each coveredDate In PeriodCoverageDates()
            Dim columnName = DtrCalculationTable.DateColumnName(coveredDate)
            If Not GView_TimeCalculation.Columns.Contains(columnName) Then Continue For

            With GView_TimeCalculation.Columns(columnName)
                .HeaderText = coveredDate.ToString("MMM d", Globalization.CultureInfo.InvariantCulture) & vbCrLf & coveredDate.ToString("ddd", Globalization.CultureInfo.InvariantCulture)
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 74
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.##"
            End With
        Next

        If GView_TimeCalculation.Columns.Contains("Total") Then
            With GView_TimeCalculation.Columns("Total")
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 76
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.##"
                .DefaultCellStyle.BackColor = Color.FromArgb(235, 245, 245)
            End With
        End If

        For Each row As DataGridViewRow In GView_TimeCalculation.Rows
            For columnIndex As Integer = 1 To GView_TimeCalculation.Columns.Count - 1
                If GView_TimeCalculation.Columns(columnIndex).Name = "Total" Then Continue For
                If row.Cells(columnIndex).Value Is Nothing OrElse row.Cells(columnIndex).Value Is DBNull.Value Then
                    row.Cells(columnIndex).Style.BackColor = Color.LightGray
                    row.Cells(columnIndex).Style.SelectionBackColor = Color.LightGray
                End If
            Next
        Next
    End Sub

    Private Sub BIOMETRICForm_FormClosing(sender As Object, e As EventArgs) Handles MyBase.Closing
        ClearTimeCalculationView()
    End Sub

    Private Sub ClearTimeCalculationView()
        If GView_TimeCalculation Is Nothing Then Return
        GView_TimeCalculation.DataSource = Nothing
        GView_TimeCalculation.Rows.Clear()
        GView_TimeCalculation.Columns.Clear()
    End Sub

    Private Sub ClearClassificationGrid()
        If GView_Classification Is Nothing Then Return
        GView_Classification.Rows.Clear()
        GView_Classification.Columns.Clear()
    End Sub

    Private Sub BuildClassificationGrid()
        If GView_Classification Is Nothing Then Return

        Try
            isUpdatingClassificationGrid = True

            GView_Classification.Columns.Clear()
            GView_Classification.Rows.Clear()
            GView_Classification.AllowUserToAddRows = False
            GView_Classification.AllowUserToDeleteRows = False
            GView_Classification.ReadOnly = True
            GView_Classification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            GView_Classification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

            GView_Classification.Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "Label",
                .HeaderText = "Classification",
                .Frozen = True,
                .ReadOnly = True,
                .SortMode = DataGridViewColumnSortMode.NotSortable,
                .Width = 180
            })

            For Each coveredDate In PeriodCoverageDates()
                GView_Classification.Columns.Add(New DataGridViewCheckBoxColumn With {
                    .Name = DateColumnName(coveredDate),
                    .HeaderText = coveredDate.ToString("MMM d", Globalization.CultureInfo.InvariantCulture) & vbCrLf & coveredDate.ToString("ddd", Globalization.CultureInfo.InvariantCulture),
                    .ReadOnly = True,
                    .SortMode = DataGridViewColumnSortMode.NotSortable,
                    .Tag = coveredDate.Date,
                    .Width = 74
                })
            Next

            Dim sundayRowIndex = GView_Classification.Rows.Add()
            GView_Classification.Rows(sundayRowIndex).Cells("Label").Value = "Sunday"

            Dim shRowIndex = GView_Classification.Rows.Add()
            GView_Classification.Rows(shRowIndex).Cells("Label").Value = "Special Holiday (SH)"

            Dim lhRowIndex = GView_Classification.Rows.Add()
            GView_Classification.Rows(lhRowIndex).Cells("Label").Value = "Legal Holiday (LH)"

            For columnIndex As Integer = 1 To GView_Classification.Columns.Count - 1
                Dim coveredDate = ClassificationDateForColumn(columnIndex)
                Dim sundayCell = GView_Classification.Rows(sundayRowIndex).Cells(columnIndex)
                sundayCell.Value = coveredDate.HasValue AndAlso coveredDate.Value.DayOfWeek = DayOfWeek.Sunday

                If Not coveredDate.HasValue OrElse coveredDate.Value.DayOfWeek <> DayOfWeek.Sunday Then
                    sundayCell.ReadOnly = True
                    sundayCell.Style.BackColor = Color.LightGray
                    sundayCell.Style.SelectionBackColor = Color.LightGray
                    sundayCell.Style.ForeColor = Color.DimGray
                    sundayCell.ToolTipText = "Sunday can only be selected on an actual Sunday date."
                End If

                GView_Classification.Rows(shRowIndex).Cells(columnIndex).Value = False
                GView_Classification.Rows(lhRowIndex).Cells(columnIndex).Value = False
                ApplyClassificationExclusionState(columnIndex)
            Next
        Finally
            isUpdatingClassificationGrid = False
        End Try
    End Sub

    Private Function DateColumnName(d As Date) As String
        Return "D" & d.ToString("yyyyMMdd", Globalization.CultureInfo.InvariantCulture)
    End Function

    Private Function ClassificationDateForColumn(columnIndex As Integer) As Date?
        If GView_Classification Is Nothing OrElse columnIndex < 1 OrElse columnIndex >= GView_Classification.Columns.Count Then Return Nothing

        Dim tagValue = GView_Classification.Columns(columnIndex).Tag
        If TypeOf tagValue Is Date Then Return DirectCast(tagValue, Date).Date

        Return Nothing
    End Function

    Private Function ClassificationColumnIndexForDate(d As Date) As Integer
        If GView_Classification Is Nothing Then Return -1

        Dim columnName = DateColumnName(d)
        If GView_Classification.Columns.Contains(columnName) Then Return GView_Classification.Columns(columnName).Index

        Return -1
    End Function

    Private Function IsClassificationColumnSunday(columnIndex As Integer) As Boolean
        Dim coveredDate = ClassificationDateForColumn(columnIndex)
        Return coveredDate.HasValue AndAlso coveredDate.Value.DayOfWeek = DayOfWeek.Sunday
    End Function

    Private Function IsCellChecked(cell As DataGridViewCell) As Boolean
        If cell Is Nothing OrElse cell.Value Is Nothing OrElse cell.Value Is DBNull.Value Then Return False

        Dim checkedValue As Boolean
        Boolean.TryParse(cell.Value.ToString(), checkedValue)
        Return checkedValue
    End Function

    Private Function IsSundayCheckedForClassificationColumn(columnIndex As Integer) As Boolean
        If GView_Classification Is Nothing OrElse GView_Classification.Rows.Count = 0 OrElse columnIndex < 1 Then Return False
        Return IsCellChecked(GView_Classification.Rows(0).Cells(columnIndex))
    End Function

    Private Sub ApplyClassificationExclusionState(columnIndex As Integer)
        If GView_Classification Is Nothing OrElse GView_Classification.Rows.Count < 3 OrElse columnIndex < 1 Then Return

        Dim sundaySelected = IsSundayCheckedForClassificationColumn(columnIndex)

        For rowIndex As Integer = 1 To 2
            Dim cell = GView_Classification.Rows(rowIndex).Cells(columnIndex)
            cell.ReadOnly = sundaySelected
            cell.ToolTipText = If(sundaySelected, "SH and LH cannot be selected when Sunday is selected.", "")

            If sundaySelected Then
                cell.Value = False
                cell.Style.BackColor = Color.LightGray
                cell.Style.SelectionBackColor = Color.LightGray
                cell.Style.ForeColor = Color.DimGray
            Else
                cell.Style.BackColor = Color.FromArgb(255, 224, 192)
                cell.Style.SelectionBackColor = GView_Classification.DefaultCellStyle.SelectionBackColor
                cell.Style.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub GView_Classification_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GView_Classification.CellClick
        If isUpdatingClassificationGrid OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 1 Then Return

        Dim cell = GView_Classification.Rows(e.RowIndex).Cells(e.ColumnIndex)
        Dim currentValue = IsCellChecked(cell)

        If e.RowIndex = 0 Then
            If Not IsClassificationColumnSunday(e.ColumnIndex) Then Return
            cell.Value = Not currentValue
            If CBool(cell.Value) Then
                GView_Classification.Rows(1).Cells(e.ColumnIndex).Value = False
                GView_Classification.Rows(2).Cells(e.ColumnIndex).Value = False
            End If
            ApplyClassificationExclusionState(e.ColumnIndex)
        ElseIf e.RowIndex = 1 Then
            If IsSundayCheckedForClassificationColumn(e.ColumnIndex) Then Return
            cell.Value = Not currentValue
            If CBool(cell.Value) Then GView_Classification.Rows(2).Cells(e.ColumnIndex).Value = False
        ElseIf e.RowIndex = 2 Then
            If IsSundayCheckedForClassificationColumn(e.ColumnIndex) Then Return
            cell.Value = Not currentValue
            If CBool(cell.Value) Then GView_Classification.Rows(1).Cells(e.ColumnIndex).Value = False
        End If

        RecalculateDtrFromClassifications()
    End Sub

    Private Function ClassificationForDate(d As Date) As String
        If GView_Classification Is Nothing OrElse GView_Classification.Rows.Count < 3 Then
            Return If(d.DayOfWeek = DayOfWeek.Sunday, "SUN", "")
        End If

        Dim columnIndex = ClassificationColumnIndexForDate(d)
        If columnIndex < 1 Then Return If(d.DayOfWeek = DayOfWeek.Sunday, "SUN", "")

        If IsCellChecked(GView_Classification.Rows(0).Cells(columnIndex)) Then Return "SUN"
        If IsCellChecked(GView_Classification.Rows(1).Cells(columnIndex)) Then Return "SH"
        If IsCellChecked(GView_Classification.Rows(2).Cells(columnIndex)) Then Return "LH"

        Return ""
    End Function

    Private Function ClassificationForDtrRow(row As DataGridViewRow) As String
        Dim rowDate = DtrRowDate(row)
        If Not rowDate.HasValue Then Return ""

        Return ClassificationForDate(rowDate.Value)
    End Function

    Private Sub ApplyDtrClassificationStyles()
        For rowIndex As Integer = 0 To GView_DTR.Rows.Count - 1
            If Not IsDtrDataRow(GView_DTR, rowIndex) Then Continue For

            Dim row = GView_DTR.Rows(rowIndex)
            Select Case ClassificationForDtrRow(row)
                Case "SUN"
                    row.DefaultCellStyle.BackColor = Color.LightBlue
                Case "SH"
                    row.DefaultCellStyle.BackColor = Color.Yellow
                Case "LH"
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                Case Else
                    row.DefaultCellStyle.BackColor = Color.Empty
            End Select
        Next
    End Sub

    Private Function SourceColumnIndexForCell(grid As DataGridView, columnIndex As Integer) As Integer
        If grid Is Nothing Then Return -1

        If columnIndex < 0 OrElse columnIndex >= grid.Columns.Count Then Return -1
        Return columnIndex
    End Function

    Private Function TryGetCellBySourceColumn(row As DataGridViewRow, sourceColumnIndex As Integer, ByRef cell As DataGridViewCell) As Boolean
        cell = Nothing
        If row Is Nothing OrElse row.DataGridView Is Nothing Then Return False

        For Each column As DataGridViewColumn In row.DataGridView.Columns
            If SourceColumnIndexForCell(row.DataGridView, column.Index) = sourceColumnIndex Then
                If column.Index < row.Cells.Count Then
                    cell = row.Cells(column.Index)
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Function SourceRowIndexForDate(grid As DataGridView, coveredDate As Date) As Integer
        If grid Is Nothing Then Return -1

        For rowIndex As Integer = 0 To grid.Rows.Count - 1
            If Not IsDtrDataRow(grid, rowIndex) Then Continue For

            Dim rowDate = DtrRowDate(grid.Rows(rowIndex))
            If rowDate.HasValue AndAlso rowDate.Value.Date = coveredDate.Date Then Return rowIndex
        Next

        Return -1
    End Function

    Private Function DtrRowDate(row As DataGridViewRow) As Date?
        If row Is Nothing Then Return Nothing

        Dim dateText = SourceCellText(row, 0)
        If String.IsNullOrWhiteSpace(dateText) Then Return Nothing

        Dim parsedDate As DateTime
        If DateTime.TryParse(GetFirstDate(dateText), parsedDate) Then Return parsedDate.Date

        Return Nothing
    End Function

    Public Function GetOrCreateCalculationForDtrRow(row As DataGridViewRow) As DtrDayCalculation
        Dim rowDate = DtrRowDate(row)
        If Not rowDate.HasValue Then Return Nothing

        Return DtrCalculations.Upsert(rowDate.Value, SourceCellText(row, DtrDayColumnIndex))
    End Function

    Public Function TryGetCalculationForDtrRow(row As DataGridViewRow, ByRef calculation As DtrDayCalculation) As Boolean
        calculation = Nothing

        Dim rowDate = DtrRowDate(row)
        If Not rowDate.HasValue Then Return False

        Return DtrCalculations.TryGet(rowDate.Value, calculation)
    End Function

    Private Function PeriodCoverageDates() As List(Of Date)
        Dim rowDates = DtrDataDates()
        Dim cutoff = GlobalVariables.sPayroll_Cutoff
        Dim cutoffDates = CutoffCoverageDates(cutoff, rowDates)

        If cutoffDates.Count > 0 Then Return cutoffDates
        Return rowDates
    End Function

    Private Function DtrDataDates() As List(Of Date)
        Dim dates As New List(Of Date)

        For rowIndex As Integer = 0 To GView_DTR.Rows.Count - 1
            If Not IsDtrDataRow(GView_DTR, rowIndex) Then Continue For

            Dim rowDate = DtrRowDate(GView_DTR.Rows(rowIndex))
            If rowDate.HasValue AndAlso Not dates.Contains(rowDate.Value.Date) Then dates.Add(rowDate.Value.Date)
        Next

        dates.Sort()
        Return dates
    End Function

    Private Function CutoffCoverageDates(cutoff As String, fallbackDates As List(Of Date)) As List(Of Date)
        Dim dates As New List(Of Date)
        If String.IsNullOrWhiteSpace(cutoff) Then Return dates

        Dim parts = cutoff.Split("_"c)
        If parts.Length < 3 Then Return dates

        Dim monthValue As Integer
        Dim yearValue As Integer
        If Not Integer.TryParse(parts(0), monthValue) Then Return dates
        If Not Integer.TryParse(parts(2), yearValue) Then Return dates
        If monthValue < 1 OrElse monthValue > 12 Then Return dates

        Dim startDay As Integer
        Dim endDay As Integer
        If cutoff.IndexOf("_1st_", StringComparison.OrdinalIgnoreCase) >= 0 Then
            startDay = 1
            endDay = 15
        ElseIf cutoff.IndexOf("_2nd_", StringComparison.OrdinalIgnoreCase) >= 0 Then
            startDay = 16
            endDay = Date.DaysInMonth(yearValue, monthValue)
        Else
            Return dates
        End If

        If fallbackDates IsNot Nothing AndAlso fallbackDates.Count > 0 Then
            Dim minDate = fallbackDates.Min()
            Dim maxDate = fallbackDates.Max()
            If minDate.Month <> monthValue OrElse minDate.Year <> yearValue Then Return fallbackDates
            If maxDate.Month <> monthValue OrElse maxDate.Year <> yearValue Then Return fallbackDates
        End If

        For dayValue As Integer = startDay To endDay
            dates.Add(New Date(yearValue, monthValue, dayValue))
        Next

        Return dates
    End Function

    Private Sub AddBreakdownTotalColumn()
        Dim totalColumn As New DataGridViewTextBoxColumn With {
            .Name = "Total",
            .HeaderText = "Total",
            .ReadOnly = True,
            .SortMode = DataGridViewColumnSortMode.NotSortable,
            .Width = 76
        }
        totalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        GView_TimeCalculation.Columns.Add(totalColumn)

        RefreshBreakdownTotals()
    End Sub

    Private Sub RefreshBreakdownTotals()
        If GView_TimeCalculation.Columns.Count = 0 OrElse Not GView_TimeCalculation.Columns.Contains("Total") Then Return

        Dim totalColumnIndex = GView_TimeCalculation.Columns.Count - 1
        For Each row As DataGridViewRow In GView_TimeCalculation.Rows
            Dim total As Decimal = 0D

            For columnIndex As Integer = 1 To totalColumnIndex - 1
                Dim value As Decimal
                If row.Cells(columnIndex).Value IsNot Nothing AndAlso Decimal.TryParse(row.Cells(columnIndex).Value.ToString(), value) Then
                    total += value
                End If
            Next

            row.Cells(totalColumnIndex).Value = total.ToString("0.##")
            row.Cells(totalColumnIndex).Style.BackColor = Color.FromArgb(235, 245, 245)
        Next
    End Sub

    Private Function SourceCellText(row As DataGridViewRow, sourceColumnIndex As Integer) As String
        Dim cell As DataGridViewCell = Nothing
        If Not TryGetCellBySourceColumn(row, sourceColumnIndex, cell) Then Return String.Empty
        Return Convert.ToString(cell.Value).Trim()
    End Function

    Private Function IsDtrDataRow(grid As DataGridView, rowIndex As Integer) As Boolean
        If grid Is Nothing OrElse rowIndex < 0 OrElse rowIndex >= grid.Rows.Count Then Return False

        Dim row = grid.Rows(rowIndex)
        If row Is Nothing Then Return False
        If row.IsNewRow Then Return False
        If String.Equals(SourceCellText(row, 13), "Total:", StringComparison.OrdinalIgnoreCase) Then Return False

        Dim dateText = SourceCellText(row, 0)
        If String.IsNullOrWhiteSpace(dateText) Then Return False
        If String.Equals(dateText, "Total:", StringComparison.OrdinalIgnoreCase) Then Return False

        Dim parsedDate As DateTime
        Return DateTime.TryParse(GetFirstDate(dateText), parsedDate)
    End Function

    Private Function GetTotalRowIndex(grid As DataGridView) As Integer
        If grid Is Nothing OrElse grid.Rows.Count = 0 Then Return -1

        For rowIndex As Integer = 0 To grid.Rows.Count - 1
            If String.Equals(SourceCellText(grid.Rows(rowIndex), 13), "Total:", StringComparison.OrdinalIgnoreCase) Then
                Return rowIndex
            End If
        Next

        If grid.Rows.Count > 1 Then Return grid.Rows.Count - 2
        Return grid.Rows.Count - 1
    End Function

    Private Sub UpdateTotalRow(grid As DataGridView, columnIndices As Integer())
        Dim totalRowIndex = GetTotalRowIndex(grid)
        If totalRowIndex < 0 Then Return

        Dim totals(columnIndices.Length - 1) As Double

        For rowIndex As Integer = 0 To grid.Rows.Count - 1
            If rowIndex = totalRowIndex OrElse Not IsDtrDataRow(grid, rowIndex) Then Continue For

            For columnOffset As Integer = 0 To columnIndices.Length - 1
                Dim sourceCell As DataGridViewCell = Nothing
                If Not TryGetCellBySourceColumn(grid.Rows(rowIndex), columnIndices(columnOffset), sourceCell) Then Continue For

                Dim cellValue = sourceCell.Value
                If cellValue IsNot Nothing AndAlso IsNumeric(cellValue) Then
                    totals(columnOffset) += CDbl(cellValue)
                End If
            Next
        Next

        Dim totalLabelCell As DataGridViewCell = Nothing
        If TryGetCellBySourceColumn(grid.Rows(totalRowIndex), 13, totalLabelCell) Then
            totalLabelCell.Value = "Total:"
        End If

        For columnOffset As Integer = 0 To columnIndices.Length - 1
            Dim totalCell As DataGridViewCell = Nothing
            If TryGetCellBySourceColumn(grid.Rows(totalRowIndex), columnIndices(columnOffset), totalCell) Then
                totalCell.Value = Math.Round(totals(columnOffset), 2)
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
            ConfigureRawDtrGridColumns()

            ' Terminate any running instances of Excel that are using "PdfToExcel.xlsx"
            TerminateExcelProcesses("PdfToExcel.xlsx")
        Catch ex As Exception
            ' Log or display the error
            MsgBox($"An error occurred during form load: {ex.Message}", vbExclamation, "Error")
        End Try
    End Sub

    Private Sub FRM_BIOMETRIC_DTR_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If AutoStartForSelectedEmployee Then
            AutoStartForSelectedEmployee = False
            StartForSelectedEmployee()
        End If
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

    Private Sub ProcessHoursBreakdown()
        ApplyDtrClassificationStyles()
        DtrCalculations.ResetHourBreakdown()

        ' Loop through rows in GView_DTR
        For iRow = 0 To GView_DTR.Rows.Count - 1
            If Not IsDtrDataRow(GView_DTR, iRow) Then Continue For

            Dim rowIndex = iRow
            Dim allEmpty As Boolean = Enumerable.Range(RawPunchStartColumnIndex, RawPunchEndColumnIndex - RawPunchStartColumnIndex + 1).All(Function(col) String.IsNullOrEmpty(CStr(GView_DTR.Rows(rowIndex).Cells(col).Value)))
            If allEmpty Then
                Continue For
            End If

            Dim calculation As DtrDayCalculation = Nothing
            If Not TryGetCalculationForDtrRow(GView_DTR.Rows(iRow), calculation) Then Continue For

            Dim totalHours As Double = CDbl(calculation.TotalHours)

            Dim firstDate As String = GetFirstDate(GView_DTR.Rows(iRow).Cells(DtrDateColumnIndex)?.Value?.ToString())
            Dim parsedDate = ParseDate(firstDate)
            If parsedDate Is Nothing Then Throw New Exception("Invalid Date")

            Dim dayOfMonth As Integer = parsedDate.Value.Day
            Dim schedTotalWorkHours As Integer = ParseScheduleTotalHours(dayOfMonth)
            Dim regHours As Double = If(schedTotalWorkHours >= 16, 16, 8)
            Dim otHours As Double = 0

            ' Process regular hours and OT logic
            ProcessRegularAndOTHours(GView_DTR.Rows(iRow), calculation, totalHours, regHours, otHours)
            calculation.RegularOvertimeHours = CDec(otHours)
        Next

    End Sub

    ' Helper function to handle regular hours and OT calculation
    Private Sub ProcessRegularAndOTHours(row As DataGridViewRow, calculation As DtrDayCalculation, totalHours As Double, regHours As Double, ByRef otHours As Double)
        If calculation Is Nothing Then Return

        Select Case ClassificationForDtrRow(row)
            Case "SUN"
                calculation.Classification = "SUN"
                AssignHours(calculation, totalHours, regHours, DtrCalculationMetric.SundayHours, otHours)
            Case "SH"
                calculation.Classification = "SH"
                AssignHours(calculation, totalHours, regHours, DtrCalculationMetric.SpecialHolidayHours, otHours)
            Case "LH"
                calculation.Classification = "LH"
                AssignHours(calculation, totalHours, regHours, DtrCalculationMetric.LegalHolidayHours, otHours)
            Case Else
                calculation.Classification = String.Empty
                AssignHours(calculation, totalHours, regHours, DtrCalculationMetric.RegularHours, otHours)
        End Select
    End Sub

    ' Helper function to assign hours
    Private Sub AssignHours(calculation As DtrDayCalculation, totalHours As Double, regHours As Double, metric As DtrCalculationMetric, ByRef otHours As Double)
        Dim regularValue As Decimal

        If totalHours >= regHours Then
            regularValue = CDec(Math.Round(regHours, 2))
            otHours = Math.Round(totalHours - regHours, 2)
        Else
            regularValue = CDec(Math.Round(totalHours, 2))
            otHours = 0
        End If

        Select Case metric
            Case DtrCalculationMetric.RegularHours
                calculation.RegularHours = regularValue
            Case DtrCalculationMetric.SundayHours
                calculation.SundayHours = regularValue
            Case DtrCalculationMetric.SpecialHolidayHours
                calculation.SpecialHolidayHours = regularValue
            Case DtrCalculationMetric.LegalHolidayHours
                calculation.LegalHolidayHours = regularValue
        End Select
    End Sub
    Private Function GetDecimalFromTextBox(txt As TextBox) As Decimal
        If txt Is Nothing Then Return 0D

        Dim value As Decimal
        If Decimal.TryParse(txt.Text.Trim(), value) Then
            Return value
        End If

        Return 0D
    End Function
    Private Function IsFirstCutoff(cutoff As String) As Boolean
        If String.IsNullOrWhiteSpace(cutoff) Then Return False
        Return cutoff.IndexOf("_1st_", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Private Function IsSecondCutoff(cutoff As String) As Boolean
        If String.IsNullOrWhiteSpace(cutoff) Then Return False
        Return cutoff.IndexOf("_2nd_", StringComparison.OrdinalIgnoreCase) >= 0
    End Function



    Private Sub Btn_Save_DTR_Click(sender As Object, e As EventArgs) Handles Btn_Save_DTR.Click

        Dim cutoff As String = GlobalVariables.sPayroll_Cutoff


        ' === Save ===
        Save_DTR_Total_Hours(GlobalVariables.DTR_Selected_SubClient_ID,
                         GlobalVariables.DTR_Selected_Employee_ID,
                         cutoff,
                         CInt(Me.Lbl_Num_of_Reporting_Days.Text),
                         CInt(Me.Lbl_ND_Days.Text))

        Save_DTR_Hours_Per_Day(GlobalVariables.DTR_Selected_SubClient_ID,
                           GlobalVariables.DTR_Selected_Employee_ID)

    End Sub
    Private Sub GView_DTR_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GView_DTR.CellEndEdit
        If isRecalculatingDtr OrElse isRefreshingDtrViews Then Return
        If e.RowIndex < 0 OrElse e.ColumnIndex < RawPunchStartColumnIndex OrElse e.ColumnIndex > RawPunchEndColumnIndex Then Return

        RecalculateDtrFromTimeDetails()
    End Sub

    Private Sub RecalculateDtrFromTimeDetails()
        If isRecalculatingDtr Then Return

        Try
            isRecalculatingDtr = True
            ClearTimeCalculationView()
            Calculate_DTR()
            ProcessHoursBreakdown()
            RefreshDtrViews()
        Finally
            isRecalculatingDtr = False
        End Try
    End Sub

    Private Sub RecalculateDtrFromClassifications()
        If isRecalculatingDtr Then Return

        Try
            isRecalculatingDtr = True
            ProcessHoursBreakdown()
            RefreshDtrViews()
        Finally
            isRecalculatingDtr = False
        End Try
    End Sub

    Private Function IsTextBoxNullOrEmpty(txt As TextBox) As Boolean
        Return txt Is Nothing OrElse String.IsNullOrWhiteSpace(txt.Text)
    End Function

End Class
