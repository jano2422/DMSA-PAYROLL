Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports ClosedXML.Excel

Public Class FRM_HR_REPORTS

    Private Shared ReadOnly ReportMaroon As Color = Color.FromArgb(111, 29, 48)
    Private Shared ReadOnly ReportAmber As Color = Color.FromArgb(213, 145, 36)
    Private Shared ReadOnly ReportTeal As Color = Color.FromArgb(0, 128, 128)
    Private Shared ReadOnly ReportInk As Color = Color.FromArgb(31, 41, 51)
    Private Shared ReadOnly ReportCanvas As Color = Color.FromArgb(255, 192, 128)
    Private Shared ReadOnly ReportSurface As Color = Color.FromArgb(255, 224, 192)
    Private Shared ReadOnly ReportAlternate As Color = Color.FromArgb(255, 238, 214)
    Private Shared ReadOnly ReportLine As Color = Color.FromArgb(224, 176, 128)
    Private Shared ReadOnly ReportWhite As Color = Color.White

    <Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function ShowScrollBar(windowHandle As IntPtr, scrollBar As Integer, show As Boolean) As Boolean
    End Function

    Private reportsBehaviorReady As Boolean
    Private ReadOnly reportColumnWeights As New Dictionary(Of ListView, Integer())

    Private NotInheritable Class ReportWorksheetData
        Public Property SheetName As String
        Public Property ReportTitle As String
        Public Property Columns As List(Of String)
        Public Property Rows As List(Of String())
    End Class

    Private Sub Btn_Load_Chart_Data_Click_1(sender As Object, e As EventArgs) Handles Btn_Load_Chart_Data.Click
        Show_Employee_Status_in_Chart()
        ConfigureColumnChart()
        LoadChartPointsFromReportList()
        SetChartHeading("Employment status", "Active and inactive employee distribution")
    End Sub

    Private Sub Btn_Hired_Per_Year_Click_1(sender As Object, e As EventArgs) Handles Btn_Hired_Per_Year.Click
        Show_in_Chart_Hired_Per_Year("Active")
        ConfigureColumnChart()
        LoadChartPointsFromReportList()
        SetChartHeading("Hires by year", "Hiring history in chronological order")
    End Sub

    Private Sub Btn_Hired_Per_Month_Click_1(sender As Object, e As EventArgs) Handles Btn_Hired_Per_Month.Click
        Dim sEmp_Status As String

        If Cmb_Emp_Status.SelectedIndex = -1 Then
            Cmb_Emp_Status.SelectedIndex = 0
        End If

        Select Case Cmb_Emp_Status.Text
            Case "Hired" ' Set to empty so all status will be covered ( Active or already resigned, ther are all HIRED in that month ) 
                sEmp_Status = ""
            Case Else
                sEmp_Status = Cmb_Emp_Status.Text
        End Select

        Show_in_Chart_Hired_Per_Month(sEmp_Status)
        ConfigureColumnChart()
        LoadChartPointsFromReportList()
        SetChartHeading("Employees by month", "Monthly hiring activity for the selected status")
    End Sub

    Private Sub Btn_Gender_Count_Click(sender As Object, e As EventArgs) Handles Btn_Gender_Count.Click
        Show_in_Chart_Gender_statistics("Active")
        ConfigurePieChart()
        LoadChartPointsFromReportList()
        ApplyPiePointColors()
        SetChartHeading("Active workforce by gender", "Current gender distribution")
    End Sub

    Private Sub Btn_Age_Count_Click(sender As Object, e As EventArgs) Handles Btn_Age_Count.Click
        Show_in_Chart_Age_Statistics("Active")
        ConfigureBarChart()
        LoadChartPointsFromReportList()
        SetChartHeading("Active workforce by age", "Current employee age profile")
    End Sub

    Private Sub LoadChartPointsFromReportList()
        Dim series = CH_Emp_Status.Series("Count")
        series.Points.Clear()
        For Each item As ListViewItem In LV_Report_Statistics1.Items
            Dim count As Integer
            If item.SubItems.Count > 1 AndAlso Integer.TryParse(item.SubItems(1).Text, count) Then
                series.Points.AddXY(item.Text, count)
            End If
        Next
        ApplyValueAxisHeadroom()
    End Sub

    Private Sub ApplyValueAxisHeadroom()
        Dim series = CH_Emp_Status.Series("Count")
        If series.Points.Count = 0 OrElse series.ChartType = SeriesChartType.Pie Then Return

        Dim maximumValue As Double = 0
        For Each point In series.Points
            If point.YValues.Length > 0 Then maximumValue = Math.Max(maximumValue, point.YValues(0))
        Next
        If maximumValue <= 0 Then Return

        Dim magnitude = Math.Pow(10, Math.Floor(Math.Log10(maximumValue)))
        Dim roundingStep = Math.Max(1, magnitude / 2.0R)
        Dim paddedMaximum = Math.Ceiling((maximumValue * 1.15R) / roundingStep) * roundingStep

        CH_Emp_Status.ChartAreas(0).AxisY.Maximum = paddedMaximum
        If series.ChartType = SeriesChartType.Bar Then
            CH_Emp_Status.ChartAreas(0).AxisY.Interval = roundingStep
        End If
    End Sub

    Private Sub ResetChartPresentation()
        Dim area = CH_Emp_Status.ChartAreas(0)
        area.AxisX.Enabled = AxisEnabled.True
        area.AxisY.Enabled = AxisEnabled.True
        area.AxisX.Minimum = Double.NaN
        area.AxisX.Maximum = Double.NaN
        area.AxisY.Minimum = Double.NaN
        area.AxisY.Maximum = Double.NaN
        area.AxisX.Interval = 0
        area.AxisY.Interval = 0
        area.AxisX.IsLabelAutoFit = True
        area.AxisY.IsLabelAutoFit = True
        area.AxisX.IsReversed = False
        area.AxisY.IsReversed = False
        area.AxisX.LabelStyle.Angle = 0
        area.AxisY.LabelStyle.Angle = 0
        area.AxisX.LabelStyle.ForeColor = ReportInk
        area.AxisY.LabelStyle.ForeColor = ReportInk
        area.AxisX.LabelStyle.Format = String.Empty
        area.AxisY.LabelStyle.Format = String.Empty
        area.AxisX.MajorGrid.Enabled = False
        area.AxisY.MajorGrid.Enabled = True
        area.AxisY.MajorGrid.LineColor = ReportLine

        Dim series = CH_Emp_Status.Series("Count")
        series.CustomProperties = String.Empty
        series.XValueType = ChartValueType.String
        series.YValueType = ChartValueType.Int32
        series.Color = ReportTeal
        series.BorderWidth = 0
        series.IsValueShownAsLabel = True
        series.Label = String.Empty
        series.LabelFormat = "#,##0"
        series.Font = New Font("Segoe UI Semibold", 8.5F, FontStyle.Regular)
        series.LabelBackColor = Color.Transparent
        series.LabelForeColor = ReportInk
        series.SmartLabelStyle.Enabled = True
    End Sub

    Private Sub ConfigureColumnChart()
        ResetChartPresentation()
        Dim area = CH_Emp_Status.ChartAreas(0)
        area.AxisX.Interval = 1
        area.AxisX.LabelStyle.Format = String.Empty
        area.AxisY.Minimum = 0
        area.AxisY.Interval = 0
        area.AxisY.LabelStyle.Format = "#,##0"
        CH_Emp_Status.Series("Count").ChartType = SeriesChartType.Column
    End Sub

    Private Sub ConfigureBarChart()
        ResetChartPresentation()
        Dim area = CH_Emp_Status.ChartAreas(0)
        area.AxisX.Interval = 1
        area.AxisX.IsLabelAutoFit = False
        area.AxisX.LabelStyle.Format = String.Empty
        area.AxisX.MajorGrid.Enabled = False
        area.AxisY.Minimum = 0
        area.AxisY.Interval = 0
        area.AxisY.IsStartedFromZero = True
        area.AxisY.LabelStyle.Format = "#,##0"
        area.AxisY.MajorGrid.Enabled = True
        CH_Emp_Status.Series("Count").ChartType = SeriesChartType.Bar
    End Sub

    Private Sub ConfigurePieChart()
        ResetChartPresentation()
        Dim area = CH_Emp_Status.ChartAreas(0)
        area.AxisX.Enabled = AxisEnabled.False
        area.AxisY.Enabled = AxisEnabled.False

        Dim series = CH_Emp_Status.Series("Count")
        series.ChartType = SeriesChartType.Pie
        series.Label = "#VALX: #VALY (#PERCENT{P0})"
        series.LabelFormat = String.Empty
        series.LabelForeColor = ReportWhite
        series.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
        series("PieLabelStyle") = "Inside"
        series("PieDrawingStyle") = "SoftEdge"
        series("PieStartAngle") = "270"
        series("MinimumRelativePieSize") = "55"
    End Sub

    Private Sub ApplyPiePointColors()
        Dim colors As Color() = {ReportTeal, ReportMaroon, ReportAmber, Color.FromArgb(74, 103, 133)}
        Dim points = CH_Emp_Status.Series("Count").Points
        For index = 0 To points.Count - 1
            points(index).Color = colors(index Mod colors.Length)
        Next
    End Sub

    Private Sub Cmb_Expiry_Status_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Cmb_Expiry_Status.SelectedIndexChanged

        Dim filter As ExpiryFilter = CType(Cmb_Expiry_Status.SelectedIndex, ExpiryFilter)
        Dim expType As ExpiryType

        Select Case Cmb_Exp_Category.SelectedIndex
            Case 0 : expType = ExpiryType.Medical
            Case 1 : expType = ExpiryType.License
            Case 2 : expType = ExpiryType.Insurance
            Case Else : Exit Sub
        End Select

        Show_Expiry(filter, expType)

    End Sub

    Private Sub Btn_ShowPendingRecords_Click(sender As Object, e As EventArgs) Handles Btn_ShowPendingRecords.Click
        Call Show_Employees_With_Pending_Information(Cmb_Pending_Category.Text)
    End Sub

    Private Sub Cmb_Exp_Category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Exp_Category.SelectedIndexChanged
        Cmb_Expiry_Status.SelectedIndex = 3   ' Default to Expired
        Cmb_Expiry_Status_SelectedIndexChanged_1(Cmb_Expiry_Status, EventArgs.Empty)
    End Sub


    Private Sub DP_Leave_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DP_Leave_DateTo.ValueChanged
        Txt_Leave_DateTo.Text = DP_Leave_DateTo.Value.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub DP_Leave_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DP_Leave_DateFrom.ValueChanged
        Txt_Leave_DateFrom.Text = DP_Leave_DateFrom.Value.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub Btn_Show_Leave_Click(sender As Object, e As EventArgs) Handles Btn_Show_Leave.Click
        Try
            Call Show_Leave_Applications(Me.Cmb_LeaveType.Text, Me.Txt_Leave_DateFrom.Text, Me.Txt_Leave_DateTo.Text)
        Catch ex As Exception
            MsgBox("Error in getting records. Please check requirements.", vbCritical, "Catched Error")
        End Try

    End Sub

    Private Sub Lbl_Export_SecLicense_Click(sender As Object, e As EventArgs) Handles Lbl_Export_SecLicense.Click
        ExportListViewWorkbook(LV_Expiry_List, "Expiration Tracking", "Employee expiration tracking")
    End Sub

    Private Sub Btn_Logs_Show_Click(sender As Object, e As EventArgs) Handles Btn_Logs_Show.Click
        Try
            Call Show_System_Logs(Txt_Logs_DateFrom.Text, Txt_Logs_DateTo.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DP_Logs_From_ValueChanged(sender As Object, e As EventArgs) Handles DP_Logs_From.ValueChanged
        Txt_Logs_DateFrom.Text = DP_Logs_From.Value.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub DP_Logs_To_ValueChanged(sender As Object, e As EventArgs) Handles DP_Logs_To.ValueChanged
        Txt_Logs_DateTo.Text = DP_Logs_To.Value.ToString("dd-MMM-yyyy")
    End Sub



    Private Sub Lbl_Export_LeaveStatus_Click(sender As Object, e As EventArgs) Handles Lbl_Export_LeaveStatus.Click
        ExportListViewWorkbook(LV_Leave_List, "Leave Records", "Employee leave records")
    End Sub

    Private Sub Lbl_Export_PendingDocs_Click(sender As Object, e As EventArgs) Handles Lbl_Export_PendingDocs.Click
        ExportListViewWorkbook(LV_Pending_List, "Missing Records", "Employee missing records")
    End Sub

    Private Sub Btn_Client_Show_Click(sender As Object, e As EventArgs) Handles Btn_Client_Show.Click
        Call Show_Number_of_Active_Clients()
        Call Show_Client_Count_In_Listview()
    End Sub

    Private Sub Btn_Show_SubClient_EmpCount_Click(sender As Object, e As EventArgs) Handles Btn_Show_SubClient_EmpCount.Click
        Call Show_Sub_Client_Employee_Count()
    End Sub

    Private Sub Btn_Show_MainClient_EmpCount_Click(sender As Object, e As EventArgs) Handles Btn_Show_MainClient_EmpCount.Click
        Call Show_Main_Client_Employe_Count()
    End Sub

    Private Sub Btn_Employment_Status_Click(sender As Object, e As EventArgs) Handles Btn_Export_SubClient_Count.Click
        ExportListViewWorkbook(LV_SubClient_EmployeeCount,
                               "Detachment Staffing",
                               "Employee count by detachment")
    End Sub



    Private Sub BtnExport_MainClientCount_Click(sender As Object, e As EventArgs) Handles BtnExport_MainClientCount.Click
        ExportListViewWorkbook(LV_Client_Count,
                               "Client Portfolio",
                               "Detachment count by main client")
    End Sub

    Private Sub Btn_Export_Employee_Count_Click(sender As Object, e As EventArgs) Handles Btn_Export_Employee_Count.Click
        ExportListViewWorkbook(LV_MAIN_CLIENT_EMPLOYEE_COUNT,
                               "Main Client Staffing",
                               "Employee count by main client")
    End Sub

    Private Sub Cmb_Client_Expiration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Client_Expiration.SelectedIndexChanged

        Dim filter As ExpiryFilter = CType(Cmb_Client_Expiration.SelectedIndex, ExpiryFilter)

        Show_Client_Contract_Expiry(filter)

    End Sub


    Private Sub Lbl_Export_Client_Contract_Exp_Click(sender As Object, e As EventArgs) Handles Lbl_Export_Client_Contract_Exp.Click
        ExportListViewWorkbook(LV_Client_Contract_Exp,
                               "Client Contracts",
                               "Client contract expiration tracking")
    End Sub

    Private Async Sub Btn_Export_Workforce_Analytics_Click(sender As Object, e As EventArgs) Handles Btn_Export_Workforce_Analytics.Click
        Dim outputPath = SelectExcelExportPath("HR Workforce Analytics")
        If String.IsNullOrWhiteSpace(outputPath) Then Return

        Dim previousRows = CaptureListViewRows(LV_Report_Statistics1)
        Dim worksheets As New List(Of ReportWorksheetData)()
        Dim processingForm As New FrmProcessing("Preparing workforce analytics...")
        Dim exportSucceeded As Boolean

        Try
            Btn_Export_Workforce_Analytics.Enabled = False
            processingForm.Show(Me)
            UpdateProcessingMessage(processingForm, "Collecting employment status...")
            Show_Employee_Status_in_Chart()
            worksheets.Add(CaptureWorksheetData("Employment Status", "Employment status", LV_Report_Statistics1))

            UpdateProcessingMessage(processingForm, "Collecting hires by year...")
            Show_in_Chart_Hired_Per_Year("Active")
            worksheets.Add(CaptureWorksheetData("Hires by Year", "Hires by year", LV_Report_Statistics1))

            UpdateProcessingMessage(processingForm, "Collecting gender distribution...")
            Show_in_Chart_Gender_statistics("Active")
            worksheets.Add(CaptureWorksheetData("Gender", "Active workforce by gender", LV_Report_Statistics1))

            UpdateProcessingMessage(processingForm, "Collecting age distribution...")
            Show_in_Chart_Age_Statistics("Active")
            worksheets.Add(CaptureWorksheetData("Age Bands", "Active workforce by age band", LV_Report_Statistics1))

            For Each employmentStatus In New String() {"Hired", "Active", "Resigned", "AWOL", "Floating"}
                UpdateProcessingMessage(processingForm, "Collecting monthly " & employmentStatus.ToLowerInvariant() & " records...")
                Dim statusFilter = If(employmentStatus = "Hired", String.Empty, employmentStatus)
                Show_in_Chart_Hired_Per_Month(statusFilter)
                worksheets.Add(CaptureWorksheetData(
                    "Monthly " & employmentStatus,
                    "Employees by month - " & employmentStatus,
                    LV_Report_Statistics1))
            Next

            UpdateProcessingMessage(processingForm, "Building the Excel workbook...")
            Await Task.Run(Sub() WriteClosedXmlWorkbook(outputPath, worksheets))
            exportSucceeded = True
        Catch ex As Exception
            AppNotification.Show("Unable to export workforce analytics." & Environment.NewLine & ex.Message,
                                 "Export failed",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            RestoreListViewRows(LV_Report_Statistics1, previousRows)
            Btn_Export_Workforce_Analytics.Enabled = True
            CloseProcessingForm(processingForm)
        End Try

        If exportSucceeded Then ShowCompletedExport(outputPath)
    End Sub

    Private Sub Btn_Export_Audit_Log_Click(sender As Object, e As EventArgs) Handles Btn_Export_Audit_Log.Click
        If LV_SystemLogs.Items.Count = 0 Then
            MsgBox("Load audit records before exporting.", vbExclamation, "Nothing to export")
            Return
        End If

        ExportListViewWorkbook(
            LV_SystemLogs,
            "Audit Log",
            "Audit log - " & DP_Logs_From.Value.ToString("dd-MMM-yyyy") &
            " to " & DP_Logs_To.Value.ToString("dd-MMM-yyyy"))
    End Sub

    Private Async Sub ExportListViewWorkbook(view As ListView, sheetName As String, reportTitle As String)
        If view.Items.Count = 0 Then
            AppNotification.Show("Load records before exporting.",
                                 "Nothing to export",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning)
            Return
        End If

        Dim outputPath = SelectExcelExportPath(reportTitle)
        If String.IsNullOrWhiteSpace(outputPath) Then Return

        Dim worksheets As New List(Of ReportWorksheetData) From {
            CaptureWorksheetData(sheetName, reportTitle, view)
        }
        Dim processingForm As New FrmProcessing("Exporting " & reportTitle.ToLowerInvariant() & "...")
        Dim exportSucceeded As Boolean

        Try
            processingForm.Show(Me)
            UpdateProcessingMessage(processingForm, "Building the Excel workbook...")
            Await Task.Run(Sub() WriteClosedXmlWorkbook(outputPath, worksheets))
            exportSucceeded = True
        Catch ex As Exception
            AppNotification.Show("Unable to export the report." & Environment.NewLine & ex.Message,
                                 "Export failed",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            CloseProcessingForm(processingForm)
        End Try

        If exportSucceeded Then ShowCompletedExport(outputPath)
    End Sub

    Private Function CaptureWorksheetData(sheetName As String,
                                          reportTitle As String,
                                          view As ListView) As ReportWorksheetData
        Dim columns As New List(Of String)()
        For Each column As ColumnHeader In view.Columns
            columns.Add(column.Text)
        Next
        If columns.Count = 0 Then columns.Add("Value")

        Return New ReportWorksheetData With {
            .SheetName = sheetName,
            .ReportTitle = reportTitle,
            .Columns = columns,
            .Rows = CaptureListViewRows(view)
        }
    End Function

    Private Sub WriteClosedXmlWorkbook(outputPath As String, worksheets As IEnumerable(Of ReportWorksheetData))
        Using workbook As New XLWorkbook()
            For Each report In worksheets
                Dim worksheet = workbook.Worksheets.Add(SanitizeWorksheetName(report.SheetName))
                WriteClosedXmlWorksheet(worksheet, report)
            Next
            workbook.SaveAs(outputPath)
        End Using
    End Sub

    Private Sub WriteClosedXmlWorksheet(worksheet As IXLWorksheet, report As ReportWorksheetData)
        Dim columnCount = Math.Max(1, report.Columns.Count)
        Dim titleRange = worksheet.Range(1, 1, 1, columnCount)
        titleRange.Merge()
        titleRange.Value = report.ReportTitle
        titleRange.Style.Fill.BackgroundColor = XLColor.FromColor(ReportMaroon)
        titleRange.Style.Font.FontColor = XLColor.FromColor(ReportWhite)
        titleRange.Style.Font.Bold = True
        titleRange.Style.Font.FontSize = 14
        titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
        worksheet.Row(1).Height = 24

        worksheet.Cell(2, 1).Value = "Generated " & Date.Now.ToString("dd-MMM-yyyy hh:mm tt")
        worksheet.Cell(2, 1).Style.Font.Italic = True
        worksheet.Cell(2, 1).Style.Font.FontColor = XLColor.FromColor(Color.FromArgb(92, 70, 48))

        For columnIndex = 0 To report.Columns.Count - 1
            worksheet.Cell(3, columnIndex + 1).Value = report.Columns(columnIndex)
        Next

        Dim headerRange = worksheet.Range(3, 1, 3, columnCount)
        headerRange.Style.Fill.BackgroundColor = XLColor.FromColor(ReportTeal)
        headerRange.Style.Font.FontColor = XLColor.FromColor(ReportWhite)
        headerRange.Style.Font.Bold = True

        For rowIndex = 0 To report.Rows.Count - 1
            Dim values = report.Rows(rowIndex)
            For columnIndex = 0 To columnCount - 1
                Dim value = If(columnIndex < values.Length, values(columnIndex), String.Empty)
                Dim numericValue As Integer
                If IsNumericReportColumn(report.Columns(columnIndex)) AndAlso Integer.TryParse(value, numericValue) Then
                    worksheet.Cell(rowIndex + 4, columnIndex + 1).Value = numericValue
                Else
                    worksheet.Cell(rowIndex + 4, columnIndex + 1).Value = value
                End If
            Next

            If rowIndex Mod 2 = 1 Then
                worksheet.Range(rowIndex + 4, 1, rowIndex + 4, columnCount).Style.Fill.BackgroundColor =
                    XLColor.FromColor(ReportAlternate)
            End If
        Next

        Dim lastRow = Math.Max(3, report.Rows.Count + 3)
        Dim dataRange = worksheet.Range(3, 1, lastRow, columnCount)
        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin
        dataRange.Style.Border.OutsideBorderColor = XLColor.FromColor(ReportLine)
        dataRange.Style.Border.InsideBorderColor = XLColor.FromColor(ReportLine)
        worksheet.SheetView.FreezeRows(3)
        worksheet.Columns(1, columnCount).AdjustToContents()

        For columnIndex = 1 To columnCount
            If worksheet.Column(columnIndex).Width > 48 Then worksheet.Column(columnIndex).Width = 48
        Next
    End Sub

    Private Function IsNumericReportColumn(columnName As String) As Boolean
        Dim normalized = If(columnName, String.Empty).Trim().ToLowerInvariant()
        Return normalized.Contains("count") OrElse
               normalized.Contains("days") OrElse
               normalized.Contains("total") OrElse
               normalized.Contains("quantity")
    End Function

    Private Function SanitizeWorksheetName(sheetName As String) As String
        Dim result = If(sheetName, "Report").Trim()
        For Each invalidCharacter In New Char() {":"c, "\"c, "/"c, "?"c, "*"c, "["c, "]"c}
            result = result.Replace(invalidCharacter, "-"c)
        Next
        If result.Length = 0 Then result = "Report"
        Return result.Substring(0, Math.Min(31, result.Length))
    End Function

    Private Function SelectExcelExportPath(reportName As String) As String
        Using dialog As New SaveFileDialog With {
            .Title = "Export report to Excel",
            .Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            .DefaultExt = "xlsx",
            .AddExtension = True,
            .OverwritePrompt = True,
            .RestoreDirectory = True,
            .FileName = reportName.Replace(" ", "_") & "_" & Date.Now.ToString("yyyyMMdd_HHmm") & ".xlsx"
        }
            If dialog.ShowDialog(Me) = DialogResult.OK Then Return dialog.FileName
        End Using
        Return String.Empty
    End Function

    Private Sub UpdateProcessingMessage(processingForm As FrmProcessing, message As String)
        processingForm.SetStatusMessage(message)
        processingForm.Refresh()
        Application.DoEvents()
    End Sub

    Private Sub CloseProcessingForm(processingForm As FrmProcessing)
        If processingForm Is Nothing OrElse processingForm.IsDisposed Then Return
        processingForm.Close()
        processingForm.Dispose()
    End Sub

    Private Sub ShowCompletedExport(outputPath As String)
        AppNotification.Show("Excel workbook created successfully." & Environment.NewLine & outputPath,
                             "Export complete",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information)
        Try
            Process.Start(New ProcessStartInfo(outputPath) With {.UseShellExecute = True})
        Catch
            ' The workbook remains available at the selected path if no spreadsheet app can open it.
        End Try
    End Sub

    Private Function CaptureListViewRows(view As ListView) As List(Of String())
        Dim rows As New List(Of String())
        For Each item As ListViewItem In view.Items
            Dim values(item.SubItems.Count - 1) As String
            For index = 0 To item.SubItems.Count - 1
                values(index) = item.SubItems(index).Text
            Next
            rows.Add(values)
        Next
        Return rows
    End Function

    Private Sub RestoreListViewRows(view As ListView, rows As IEnumerable(Of String()))
        Using SuspendReportListUpdates(view)
            view.Items.Clear()
            For Each values In rows
                If values.Length = 0 Then Continue For
                Dim item = view.Items.Add(values(0))
                For index = 1 To values.Length - 1
                    item.SubItems.Add(values(index))
                Next
            Next
        End Using
    End Sub

    Private Sub FRM_HR_REPORTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cmb_Exp_Category.SelectedIndex = 1 'Security License
        Cmb_Expiry_Status.SelectedIndex = 3 'Expired
        Cmb_Client_Expiration.SelectedIndex = 4 'All
        Cmb_LeaveType.SelectedItem = "All"
        Cmb_Pending_Category.SelectedIndex = 0
        InitializeReportsBehavior()
    End Sub


    Private Sub InitializeReportsBehavior()
        If reportsBehaviorReady Then Return
        reportsBehaviorReady = True

        DoubleBuffered = True
        Txt_Leave_DateFrom.Text = DP_Leave_DateFrom.Value.ToString("dd-MMM-yyyy")
        Txt_Leave_DateTo.Text = DP_Leave_DateTo.Value.ToString("dd-MMM-yyyy")
        Txt_Logs_DateFrom.Text = DP_Logs_From.Value.ToString("dd-MMM-yyyy")
        Txt_Logs_DateTo.Text = DP_Logs_To.Value.ToString("dd-MMM-yyyy")

        For Each reportList In AllReportLists()
            EnableListViewDoubleBuffering(reportList)
            WireReportListBehavior(reportList)
        Next

        ReportSectionChanged(Tab_Recruitment, EventArgs.Empty)
        BeginInvoke(New MethodInvoker(AddressOf FitAllReportColumns))
    End Sub

    Private Sub EnableListViewDoubleBuffering(view As ListView)
        Dim doubleBufferedProperty = GetType(Control).GetProperty(
            "DoubleBuffered",
            Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        If doubleBufferedProperty IsNot Nothing Then
            doubleBufferedProperty.SetValue(view, True, Nothing)
        End If
    End Sub

    Private Sub DrawInnerTabItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem, TabControl3.DrawItem
        Dim tabs = DirectCast(sender, TabControl)
        Dim selected = (e.Index = tabs.SelectedIndex)
        Dim bounds = e.Bounds

        Using brush As New SolidBrush(If(selected, ReportSurface, ReportCanvas))
            e.Graphics.FillRectangle(brush, bounds)
        End Using
        If selected Then
            Using accent As New SolidBrush(ReportMaroon)
                e.Graphics.FillRectangle(accent, bounds.Left, bounds.Bottom - 3, bounds.Width, 3)
            End Using
        End If

        TextRenderer.DrawText(e.Graphics, tabs.TabPages(e.Index).Text,
                              tabs.Font, bounds,
                              If(selected, ReportMaroon, Color.FromArgb(92, 70, 48)),
                              TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis)
    End Sub

    Private Sub ReportSectionChanged(sender As Object, e As EventArgs) Handles Tab_Recruitment.SelectedIndexChanged
        If Tab_Recruitment.SelectedTab Is Nothing Then Return
        ReportsSectionLabel.Text = Tab_Recruitment.SelectedTab.Text.ToUpperInvariant()
        UpdateNavigationButtonStates()
    End Sub

    Private Sub ReportNavigationButton_Click(sender As Object, e As EventArgs) Handles NavComplianceButton.Click,
                                                                                    NavMissingButton.Click,
                                                                                    NavLeaveButton.Click,
                                                                                    NavWorkforceButton.Click,
                                                                                    NavClientsButton.Click,
                                                                                    NavAuditButton.Click
        Dim button = TryCast(sender, Button)
        If button Is Nothing OrElse button.Tag Is Nothing Then Return

        Dim targetIndex As Integer
        If Integer.TryParse(button.Tag.ToString(), targetIndex) AndAlso
           targetIndex >= 0 AndAlso targetIndex < Tab_Recruitment.TabPages.Count Then
            Tab_Recruitment.SelectedIndex = targetIndex
        End If
    End Sub

    Private Sub UpdateNavigationButtonStates()
        Dim buttons = New Button() {
            NavComplianceButton, NavMissingButton, NavLeaveButton,
            NavWorkforceButton, NavClientsButton, NavAuditButton
        }

        For index = 0 To buttons.Length - 1
            Dim selected = (index = Tab_Recruitment.SelectedIndex)
            buttons(index).BackColor = If(selected, ReportSurface, ReportCanvas)
            buttons(index).ForeColor = If(selected, ReportMaroon, ReportInk)
            buttons(index).FlatAppearance.BorderColor = If(selected, ReportMaroon, ReportLine)
            buttons(index).FlatAppearance.BorderSize = If(selected, 2, 1)
        Next
    End Sub

    Private Sub WireReportListBehavior(view As ListView)
        Dim weights(view.Columns.Count - 1) As Integer
        For index = 0 To view.Columns.Count - 1
            weights(index) = Math.Max(1, view.Columns(index).Width)
        Next
        reportColumnWeights(view) = weights

    End Sub

    Private Sub DrawReportColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles LV_Expiry_List.DrawColumnHeader,
                                                                                                           LV_Client_Contract_Exp.DrawColumnHeader,
                                                                                                           LV_Pending_List.DrawColumnHeader,
                                                                                                           LV_Leave_List.DrawColumnHeader,
                                                                                                           LV_Report_Statistics1.DrawColumnHeader,
                                                                                                           LV_Client_Count.DrawColumnHeader,
                                                                                                           LV_SubClient_EmployeeCount.DrawColumnHeader,
                                                                                                           LV_MAIN_CLIENT_EMPLOYEE_COUNT.DrawColumnHeader,
                                                                                                           LV_SystemLogs.DrawColumnHeader
        Using background As New SolidBrush(ReportTeal)
            e.Graphics.FillRectangle(background, e.Bounds)
        End Using
        Dim flags = TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis
        flags = flags Or If(e.Header.TextAlign = HorizontalAlignment.Center,
                            TextFormatFlags.HorizontalCenter,
                            TextFormatFlags.Left)
        Dim textBounds = Rectangle.Inflate(e.Bounds, -10, 0)
        TextRenderer.DrawText(e.Graphics, e.Header.Text.ToUpperInvariant(),
                              New Font("Segoe UI Semibold", 8.25F), textBounds,
                              ReportWhite, flags)
    End Sub

    Private Sub DrawReportListItem(sender As Object, e As DrawListViewItemEventArgs) Handles LV_Expiry_List.DrawItem,
                                                                                           LV_Client_Contract_Exp.DrawItem,
                                                                                           LV_Pending_List.DrawItem,
                                                                                           LV_Leave_List.DrawItem,
                                                                                           LV_Report_Statistics1.DrawItem,
                                                                                           LV_Client_Count.DrawItem,
                                                                                           LV_SubClient_EmployeeCount.DrawItem,
                                                                                           LV_MAIN_CLIENT_EMPLOYEE_COUNT.DrawItem,
                                                                                           LV_SystemLogs.DrawItem
        If DirectCast(sender, ListView).View <> View.Details Then e.DrawDefault = True
    End Sub

    Private Sub DrawReportListSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles LV_Expiry_List.DrawSubItem,
                                                                                                 LV_Client_Contract_Exp.DrawSubItem,
                                                                                                 LV_Pending_List.DrawSubItem,
                                                                                                 LV_Leave_List.DrawSubItem,
                                                                                                 LV_Report_Statistics1.DrawSubItem,
                                                                                                 LV_Client_Count.DrawSubItem,
                                                                                                 LV_SubClient_EmployeeCount.DrawSubItem,
                                                                                                 LV_MAIN_CLIENT_EMPLOYEE_COUNT.DrawSubItem,
                                                                                                 LV_SystemLogs.DrawSubItem
        Dim selected = e.Item.Selected
        Dim rowBack = If(selected,
                         ReportTeal,
                         If(e.ItemIndex Mod 2 = 0, ReportSurface, ReportAlternate))
        Using background As New SolidBrush(rowBack)
            e.Graphics.FillRectangle(background, e.Bounds)
        End Using
        Using rule As New Pen(ReportLine)
            e.Graphics.DrawLine(rule, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1)
        End Using
        Dim flags = TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPrefix
        flags = flags Or If(e.Header.TextAlign = HorizontalAlignment.Center,
                            TextFormatFlags.HorizontalCenter,
                            TextFormatFlags.Left)
        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, DirectCast(sender, ListView).Font,
                              Rectangle.Inflate(e.Bounds, -10, 0), If(selected, ReportWhite, ReportInk), flags)
    End Sub

    Private Sub ReportList_SizeChanged(sender As Object, e As EventArgs) Handles LV_Expiry_List.SizeChanged,
                                                                             LV_Client_Contract_Exp.SizeChanged,
                                                                             LV_Pending_List.SizeChanged,
                                                                             LV_Leave_List.SizeChanged,
                                                                             LV_Report_Statistics1.SizeChanged,
                                                                             LV_Client_Count.SizeChanged,
                                                                             LV_SubClient_EmployeeCount.SizeChanged,
                                                                             LV_MAIN_CLIENT_EMPLOYEE_COUNT.SizeChanged,
                                                                             LV_SystemLogs.SizeChanged
        If reportsBehaviorReady Then FitReportColumns(DirectCast(sender, ListView))
    End Sub

    Private Sub FitAllReportColumns()
        For Each view In AllReportLists()
            FitReportColumns(view)
        Next
    End Sub

    Private Function AllReportLists() As List(Of ListView)
        Return New List(Of ListView) From {
            LV_Expiry_List, LV_Client_Contract_Exp, LV_Pending_List, LV_Leave_List,
            LV_Report_Statistics1, LV_Client_Count, LV_SubClient_EmployeeCount,
            LV_MAIN_CLIENT_EMPLOYEE_COUNT, LV_SystemLogs
        }
    End Function

    Private Sub FitReportColumns(view As ListView)
        If view Is Nothing OrElse view.Columns.Count = 0 OrElse view.ClientSize.Width < 120 Then Return
        Dim available = Math.Max(100, view.ClientSize.Width - 4)
        Dim weights As Integer() = Nothing
        If Not reportColumnWeights.TryGetValue(view, weights) OrElse weights.Length <> view.Columns.Count Then Return

        Dim totalWeight As Integer = 0
        For Each weight In weights
            totalWeight += weight
        Next
        If totalWeight <= 0 Then Return

        Dim minimumWidth = Math.Min(54, Math.Max(30, available \ view.Columns.Count))
        Dim distributable = Math.Max(0, available - (minimumWidth * view.Columns.Count))
        view.BeginUpdate()
        Dim assigned As Integer = 0
        For index = 0 To view.Columns.Count - 2
            Dim width = minimumWidth + CInt(distributable * (weights(index) / CDbl(totalWeight)))
            view.Columns(index).Width = width
            assigned += width
        Next
        view.Columns(view.Columns.Count - 1).Width = Math.Max(minimumWidth, available - assigned)
        view.EndUpdate()
        view.Refresh()
        If view.IsHandleCreated Then ShowScrollBar(view.Handle, 0, False)
    End Sub

    Private Sub SetChartHeading(heading As String, caption As String)
        If CH_Emp_Status.Titles.Count < 2 Then Return
        CH_Emp_Status.Titles(0).Text = heading
        CH_Emp_Status.Titles(1).Text = caption
    End Sub

    Private Sub ReportsCloseButton_Click(sender As Object, e As EventArgs) Handles ReportsCloseButton.Click
        Close()
    End Sub

End Class
