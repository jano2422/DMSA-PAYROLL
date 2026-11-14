Imports System.Globalization
Imports System.IO
Imports ClosedXML.Excel

Public Class PayrollExportRow
    Public Property EmployeeName As String
    Public Property NumberOfDays As Decimal
    Public Property TotalHours As Decimal
    Public Property RegularHours As Decimal
    Public Property SundayHours As Decimal
    Public Property SpecialHolidayHours As Decimal
    Public Property LegalHolidayHours As Decimal
    Public Property NightDifferentialDays As Decimal
    Public Property NightDifferentialRegularHours As Decimal
    Public Property NightDifferentialSundayHours As Decimal
    Public Property NightDifferentialLegalHolidayHours As Decimal
    Public Property NightDifferentialSpecialHolidayHours As Decimal
    Public Property OvertimeRegularHours As Decimal
    Public Property OvertimeSundayHours As Decimal
    Public Property OvertimeLegalHolidayHours As Decimal
    Public Property OvertimeSpecialHolidayHours As Decimal
    Public Property SundaySpecialHolidayHours As Decimal
    Public Property SundayLegalHolidayHours As Decimal
    Public Property NightDifferentialSundaySpecialHolidayHours As Decimal
    Public Property NightDifferentialSundayLegalHolidayHours As Decimal
    Public Property OvertimeSundaySpecialHolidayHours As Decimal
    Public Property OvertimeSundayLegalHolidayHours As Decimal
    Public Property SgUniformAllowance As Decimal
    Public Property OfficerAllowance As Decimal
    Public Property OtherEarnings As Decimal
    Public Property SssDeduction As Decimal
    Public Property SssProvidentDeduction As Decimal
    Public Property PhilHealthDeduction As Decimal
    Public Property PagIbigDeduction As Decimal
    Public Property CashBondDeduction As Decimal
    Public Property SssLoanDeduction As Decimal
    Public Property SssCalLoanDeduction As Decimal
    Public Property PagIbigLoanDeduction As Decimal
    Public Property PagIbigCalLoanDeduction As Decimal
    Public Property OtherDeductions As Decimal
    Public Property HasMonetarySnapshot As Boolean
    Public Property DailyWageSnapshot As Decimal
    Public Property RegularEarnings As Decimal
    Public Property SundayEarnings As Decimal
    Public Property SpecialHolidayEarnings As Decimal
    Public Property LegalHolidayEarnings As Decimal
    Public Property NightDifferentialRegularEarnings As Decimal
    Public Property NightDifferentialSundayEarnings As Decimal
    Public Property NightDifferentialSpecialHolidayEarnings As Decimal
    Public Property NightDifferentialLegalHolidayEarnings As Decimal
    Public Property OvertimeRegularEarnings As Decimal
    Public Property OvertimeSundayEarnings As Decimal
    Public Property OvertimeSpecialHolidayEarnings As Decimal
    Public Property OvertimeLegalHolidayEarnings As Decimal
    Public Property IncentivePay As Decimal
    Public Property TotalEarnings As Decimal
    Public Property TotalDeductions As Decimal
    Public Property NetPay As Decimal
    Public Property CalculationVersion As String
End Class

Public Module PayrollReportService
    Private ReadOnly Maroon As XLColor = XLColor.FromHtml("#800000")
    Private ReadOnly Teal As XLColor = XLColor.FromHtml("#008080")
    Private ReadOnly LightOrange As XLColor = XLColor.FromHtml("#FFE0C0")
    Private ReadOnly LightTeal As XLColor = XLColor.FromHtml("#D9EDEA")
    Private Const MoneyFormat As String = "#,##0.00;[Red]-#,##0.00;-"
    Private Const QuantityFormat As String = "0.00;-0.00;-"

    Public Sub CreatePayrollReport(
        outputPath As String,
        mainClientName As String,
        detachmentName As String,
        clientAddress As String,
        dailyWage As Decimal,
        subClientId As Integer,
        cutoff As String,
        payrollGrid As DataGridView,
        dtrGrid As DataGridView
    )
        Dim settings = PayrollReportSettingsService.LoadSettings()
        Dim policy = SubClientPayrollPolicyService.LoadPolicy(subClientId)
        Dim rows = ReadPayrollRows(payrollGrid, IsFirstCutoff(cutoff))
        If rows.Count = 0 Then Throw New InvalidOperationException("There are no payroll rows to export.")

        Using workbook As New XLWorkbook()
            BuildUniversalSettingsSheet(workbook, dailyWage, cutoff, policy, settings)
            BuildUniversalPayrollSheet(workbook, mainClientName, detachmentName, clientAddress, dailyWage, cutoff, rows, policy, settings)
            BuildClassificationDetailSheet(workbook, mainClientName, detachmentName, clientAddress, cutoff, rows, settings)
            BuildPayslipSheet(workbook, detachmentName, clientAddress, cutoff, rows.Count, IsFirstCutoff(cutoff), settings)
            BuildDtrHoursSheet(workbook, mainClientName, detachmentName, clientAddress, cutoff, dtrGrid, settings)
            workbook.CalculateMode = XLCalculateMode.Auto
            Try
                workbook.RecalculateAllFormulas()
            Catch
                ' Excel recalculates all formula cells when the generated workbook is opened.
            End Try
            HideUnusedUniversalPayrollColumns(workbook.Worksheet("PAYROLL SHEET"), rows, dailyWage, cutoff, policy)
            ApplyReadableReportLayout(workbook)
            AddCompanyLogos(workbook, settings)
            workbook.SaveAs(outputPath)
        End Using
    End Sub

    Public Sub ApplyReadableReportLayout(workbook As XLWorkbook)
        For Each sheet In workbook.Worksheets
            If sheet.Visibility <> XLWorksheetVisibility.Visible OrElse sheet.Name = "PAYSLIP" Then Continue For
            Select Case sheet.Name
                Case "PAYROLL SHEET"
                    sheet.Column(1).Width = 22
                    sheet.Columns(5, 16).Width = 6.5
                    sheet.Columns(17, 43).Width = 11
                    sheet.Columns(44, 45).Width = 13
                    sheet.Column(46).Width = 14
                    sheet.Rows(6, 8).Height = 18
                    sheet.Rows(10, 11).Height = 18
                Case "CLASSIFICATION DETAIL"
                    sheet.Column(1).Width = 22
                    sheet.Column(2).Width = 8
                    sheet.Columns(3, 20).Width = 7.5
                    sheet.Row(10).Height = 18
                Case "DTR_Hours"
                    sheet.Column(1).Width = 22
                    Dim lastColumn = sheet.LastColumnUsed().ColumnNumber()
                    If lastColumn > 2 Then sheet.Columns(2, lastColumn - 1).Width = 6
                    sheet.Column(lastColumn).Width = 11
                Case "CLIENT COVERAGE"
                    sheet.Columns(1, 13).Width = 13
                    sheet.Column(2).Width = 22
                    sheet.Column(4).Width = 22
                    sheet.Column(5).Width = 26
                    sheet.Column(13).Width = 20
                Case "EMPLOYEE PAYROLL"
                    sheet.Columns(1, 61).Width = 11
                    sheet.Columns(1, 2).Width = 22
                    sheet.Column(4).Width = 22
                    sheet.Column(8).Width = 18
                    sheet.Columns(54, 55).Width = 18
                Case "SUMMARY"
                    sheet.Column(1).Width = 28
                    sheet.Column(2).Width = 12
                    sheet.Column(4).Width = 22
            End Select

            Using bitmap As New Bitmap(1, 1)
                bitmap.SetResolution(96, 96)
                Using drawingGraphics = Graphics.FromImage(bitmap)
                    Dim digitWidth = ReportDigitWidth(sheet, drawingGraphics)
                    Dim cells = sheet.CellsUsed().ToList()
                    For Each cell In cells
                        cell.Style.Font.FontSize = If(cell.Style.Font.FontSize >= 14, Math.Max(18, cell.Style.Font.FontSize), 12)
                        If sheet.Name = "PAYROLL SHEET" AndAlso cell.Address.RowNumber = 10 Then cell.Style.Font.FontSize = 10
                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                        cell.Style.Alignment.ShrinkToFit = False
                        cell.Style.Alignment.WrapText = Not cell.HasFormula AndAlso cell.DataType = XLDataType.Text
                        If sheet.Column(cell.Address.ColumnNumber).IsHidden Then Continue For
                        If cell.Style.Alignment.WrapText OrElse cell.IsMerged() Then Continue For
                        ' Keep numbers and dates intact; widen only when their
                        ' formatted value actually needs more space.
                        Dim text As String
                        Try
                            text = cell.GetFormattedString()
                        Catch
                            Continue For ' Excel evaluates unsupported formulas on open.
                        End Try
                        Using font = ReportCellFont(cell)
                            Dim needed = drawingGraphics.MeasureString(text, font, PointF.Empty, StringFormat.GenericTypographic).Width + 6
                            Dim column = sheet.Column(cell.Address.ColumnNumber)
                            If needed > VisibleColumnPixels(sheet, column.ColumnNumber(), digitWidth) Then
                                column.Width = Math.Max(column.Width, Math.Ceiling((needed - 5) / digitWidth * 10) / 10)
                            End If
                        End Using
                    Next
                    For Each row In sheet.RowsUsed()
                        row.Height = Math.Max(row.Height, 18)
                    Next
                    For Each cell In cells
                        If cell.HasFormula OrElse cell.DataType <> XLDataType.Text Then Continue For
                        FitWrappedReportCell(sheet, cell, cell.GetString(), drawingGraphics, digitWidth)
                    Next
                End Using
            End Using
        Next
    End Sub

    Private Function ReportDigitWidth(sheet As IXLWorksheet, drawingGraphics As Graphics) As Integer
        Dim style = sheet.Workbook.Style.Font
        Using font As New Font(style.FontName, CSng(style.FontSize))
            Return Math.Max(1, CInt(Math.Round(drawingGraphics.MeasureString("0", font, PointF.Empty, StringFormat.GenericTypographic).Width)))
        End Using
    End Function

    Private Function ReportCellFont(cell As IXLCell) As Font
        Dim style = cell.Style.Font
        Dim selectedStyle = If(style.Bold, FontStyle.Bold, FontStyle.Regular) Or If(style.Italic, FontStyle.Italic, FontStyle.Regular)
        Return New Font(style.FontName, CSng(style.FontSize), selectedStyle)
    End Function

    Private Sub FitWrappedReportCell(sheet As IXLWorksheet, cell As IXLCell, text As String, drawingGraphics As Graphics, digitWidth As Integer)
        If String.IsNullOrWhiteSpace(text) Then Return
        Dim area = If(cell.IsMerged(), cell.MergedRange(), cell.AsRange())
        Dim firstColumn = area.RangeAddress.FirstAddress.ColumnNumber
        Dim lastColumn = area.RangeAddress.LastAddress.ColumnNumber
        Dim width = Enumerable.Range(firstColumn, lastColumn - firstColumn + 1).
            Sum(Function(column) VisibleColumnPixels(sheet, column, digitWidth)) - 4
        If width <= 0 Then Return
        Using font = ReportCellFont(cell)
            Dim size = drawingGraphics.MeasureString(text, font, New SizeF(CSng(Math.Max(1, width)), 10000), StringFormat.GenericTypographic)
            Dim height = Math.Ceiling((size.Height * 72.0 / 96.0 + 2) / area.RowCount())
            For rowNumber = area.RangeAddress.FirstAddress.RowNumber To area.RangeAddress.LastAddress.RowNumber
                Dim row = sheet.Row(rowNumber)
                row.Height = Math.Max(row.Height, Math.Min(409.5, height))
            Next
        End Using
    End Sub

    Private Sub HideUnusedUniversalPayrollColumns(
        sheet As IXLWorksheet,
        rows As IEnumerable(Of PayrollExportRow),
        dailyWage As Decimal,
        cutoff As String,
        policy As SubClientPayrollPolicy
    )
        Dim columnsWithValues As New HashSet(Of Integer)()
        For Each item In rows
            Dim hours = UniversalHourValues(item, policy)
            For index As Integer = 0 To hours.Length - 1
                MarkColumnIfNonZero(columnsWithValues, 5 + index, hours(index))
            Next

            Dim earnings(SubClientPayrollPolicyService.PayCodeOrder.Length - 1) As Decimal
            Dim incentivePay As Decimal
            If item.HasMonetarySnapshot Then
                earnings = {
                    item.RegularEarnings, item.SundayEarnings, item.LegalHolidayEarnings, item.SpecialHolidayEarnings,
                    item.NightDifferentialRegularEarnings, item.NightDifferentialSundayEarnings,
                    item.NightDifferentialLegalHolidayEarnings, item.NightDifferentialSpecialHolidayEarnings,
                    item.OvertimeRegularEarnings, item.OvertimeSundayEarnings,
                    item.OvertimeLegalHolidayEarnings, item.OvertimeSpecialHolidayEarnings
                }
                incentivePay = item.IncentivePay
            Else
                Dim breakdown = SubClientPayrollPolicyService.CalculateEarningsBreakdown(
                    policy, dailyWage, cutoff, item.NumberOfDays, item.NightDifferentialDays,
                    hours(0), hours(1), hours(2), hours(3),
                    hours(4), hours(5), hours(6), hours(7),
                    hours(8), hours(9), hours(10), hours(11),
                    item.OfficerAllowance, item.SgUniformAllowance, item.OtherEarnings)
                For index As Integer = 0 To earnings.Length - 1
                    earnings(index) = breakdown.AmountFor(SubClientPayrollPolicyService.PayCodeOrder(index))
                Next
                incentivePay = breakdown.IncentivePay
            End If
            For index As Integer = 0 To earnings.Length - 1
                MarkColumnIfNonZero(columnsWithValues, 17 + index, earnings(index))
            Next

            MarkColumnIfNonZero(columnsWithValues, 29, incentivePay)
            MarkColumnIfNonZero(columnsWithValues, 30, item.OfficerAllowance)
            MarkColumnIfNonZero(columnsWithValues, 31, item.SgUniformAllowance)
            MarkColumnIfNonZero(columnsWithValues, 32, item.OtherEarnings)
            MarkColumnIfNonZero(columnsWithValues, 34, item.SssDeduction)
            MarkColumnIfNonZero(columnsWithValues, 35, item.SssProvidentDeduction)
            MarkColumnIfNonZero(columnsWithValues, 36, item.PhilHealthDeduction)
            MarkColumnIfNonZero(columnsWithValues, 37, item.PagIbigDeduction)
            MarkColumnIfNonZero(columnsWithValues, 38, item.CashBondDeduction)
            MarkColumnIfNonZero(columnsWithValues, 39, item.SssLoanDeduction)
            MarkColumnIfNonZero(columnsWithValues, 40, item.SssCalLoanDeduction)
            MarkColumnIfNonZero(columnsWithValues, 41, item.PagIbigLoanDeduction)
            MarkColumnIfNonZero(columnsWithValues, 42, item.PagIbigCalLoanDeduction)
            MarkColumnIfNonZero(columnsWithValues, 43, item.OtherDeductions)
        Next

        Dim optionalColumns = Enumerable.Range(5, 28).
            Concat(Enumerable.Range(34, 10)).
            ToArray()
        For Each columnNumber In optionalColumns
            If Not columnsWithValues.Contains(columnNumber) Then sheet.Column(columnNumber).Hide()
        Next
    End Sub

    Private Sub MarkColumnIfNonZero(columnsWithValues As ISet(Of Integer), columnNumber As Integer, value As Decimal)
        If Math.Abs(value) > 0.0000001D Then columnsWithValues.Add(columnNumber)
    End Sub

    Private Function UniversalHourValues(item As PayrollExportRow, policy As SubClientPayrollPolicy) As Decimal()
        Dim values = New Decimal() {
            item.RegularHours, item.SundayHours, item.LegalHolidayHours, item.SpecialHolidayHours,
            item.NightDifferentialRegularHours, item.NightDifferentialSundayHours,
            item.NightDifferentialLegalHolidayHours, item.NightDifferentialSpecialHolidayHours,
            item.OvertimeRegularHours, item.OvertimeSundayHours,
            item.OvertimeLegalHolidayHours, item.OvertimeSpecialHolidayHours
        }
        If item.HasMonetarySnapshot Then Return values

        Dim normalizedHours = SubClientPayrollPolicyService.NormalizePayHours(
            policy,
            item.RegularHours, item.SundayHours, item.LegalHolidayHours, item.SpecialHolidayHours,
            item.NightDifferentialRegularHours, item.NightDifferentialSundayHours,
            item.NightDifferentialLegalHolidayHours, item.NightDifferentialSpecialHolidayHours,
            item.OvertimeRegularHours, item.OvertimeSundayHours,
            item.OvertimeLegalHolidayHours, item.OvertimeSpecialHolidayHours)
        For index As Integer = 0 To values.Length - 1
            values(index) = normalizedHours(SubClientPayrollPolicyService.PayCodeOrder(index))
        Next
        Return values
    End Function

    Public Sub CreateDtrHoursReport(
        outputPath As String,
        mainClientName As String,
        detachmentName As String,
        clientAddress As String,
        cutoff As String,
        dtrGrid As DataGridView
    )
        Dim settings = PayrollReportSettingsService.LoadSettings()
        Using workbook As New XLWorkbook()
            BuildDtrHoursSheet(workbook, mainClientName, detachmentName, clientAddress, cutoff, dtrGrid, settings)
            workbook.CalculateMode = XLCalculateMode.Auto
            Try
                workbook.RecalculateAllFormulas()
            Catch
            End Try
            workbook.SaveAs(outputPath)
        End Using
    End Sub

    Private Function ReadPayrollRows(grid As DataGridView, firstCutoff As Boolean) As List(Of PayrollExportRow)
        Dim result As New List(Of PayrollExportRow)()
        If grid Is Nothing Then Return result

        For Each row As DataGridViewRow In grid.Rows
            If row.IsNewRow Then Continue For
            Dim item As New PayrollExportRow With {
                .EmployeeName = ReadText(row, "colName"),
                .NumberOfDays = ReadDecimal(row, "colNumDays"),
                .TotalHours = ReadDecimal(row, "colTotalHours"),
                .RegularHours = ReadDecimal(row, "colReg"),
                .SundayHours = ReadDecimal(row, "colSun"),
                .SpecialHolidayHours = ReadDecimal(row, "colSh") + ReadDecimal(row, "colSunSh"),
                .LegalHolidayHours = ReadDecimal(row, "colLh") + ReadDecimal(row, "colSunLh"),
                .NightDifferentialDays = ReadDecimal(row, "colNumNdDays"),
                .NightDifferentialRegularHours = ReadDecimal(row, "colNdReg"),
                .NightDifferentialSundayHours = ReadDecimal(row, "colNdSun"),
                .NightDifferentialLegalHolidayHours = ReadDecimal(row, "colNdLh") + ReadDecimal(row, "colNdSunLh"),
                .NightDifferentialSpecialHolidayHours = ReadDecimal(row, "colNdSh") + ReadDecimal(row, "colNdSunSh"),
                .OvertimeRegularHours = ReadDecimal(row, "colOtReg"),
                .OvertimeSundayHours = ReadDecimal(row, "colOtSun"),
                .OvertimeLegalHolidayHours = ReadDecimal(row, "colOtLh") + ReadDecimal(row, "colOtSunLh"),
                .OvertimeSpecialHolidayHours = ReadDecimal(row, "colOtSh") + ReadDecimal(row, "colOtSunSh"),
                .SundaySpecialHolidayHours = ReadDecimal(row, "colSunSh"),
                .SundayLegalHolidayHours = ReadDecimal(row, "colSunLh"),
                .NightDifferentialSundaySpecialHolidayHours = ReadDecimal(row, "colNdSunSh"),
                .NightDifferentialSundayLegalHolidayHours = ReadDecimal(row, "colNdSunLh"),
                .OvertimeSundaySpecialHolidayHours = ReadDecimal(row, "colOtSunSh"),
                .OvertimeSundayLegalHolidayHours = ReadDecimal(row, "colOtSunLh"),
                .SgUniformAllowance = ReadDecimal(row, "colSgUniformAllowance"),
                .OfficerAllowance = ReadDecimal(row, "colOfficerAllo"),
                .OtherEarnings = ReadDecimal(row, "colOtherEarnings"),
                .OtherDeductions = ReadDecimal(row, "colOtherDeductions"),
                .HasMonetarySnapshot = ReadDecimal(row, "colSnapshotComplete") <> 0D,
                .DailyWageSnapshot = ReadDecimal(row, "colDailyWageSnapshot"),
                .RegularEarnings = ReadDecimal(row, "colRegEarnings"),
                .SundayEarnings = ReadDecimal(row, "colSunEarnings"),
                .LegalHolidayEarnings = ReadDecimal(row, "colLhEarnings"),
                .SpecialHolidayEarnings = ReadDecimal(row, "colShEarnings"),
                .NightDifferentialRegularEarnings = ReadDecimal(row, "colNdRegEarnings"),
                .NightDifferentialSundayEarnings = ReadDecimal(row, "colNdSunEarnings"),
                .NightDifferentialLegalHolidayEarnings = ReadDecimal(row, "colNdLhEarnings"),
                .NightDifferentialSpecialHolidayEarnings = ReadDecimal(row, "colNdShEarnings"),
                .OvertimeRegularEarnings = ReadDecimal(row, "colOtRegEarnings"),
                .OvertimeSundayEarnings = ReadDecimal(row, "colOtSunEarnings"),
                .OvertimeLegalHolidayEarnings = ReadDecimal(row, "colOtLhEarnings"),
                .OvertimeSpecialHolidayEarnings = ReadDecimal(row, "colOtShEarnings"),
                .IncentivePay = ReadDecimal(row, "colIncentiveEarnings"),
                .TotalEarnings = ReadDecimal(row, "colTotalEarnings"),
                .TotalDeductions = ReadDecimal(row, "colTotalDeductions"),
                .NetPay = ReadDecimal(row, "colNetPay"),
                .CalculationVersion = ReadText(row, "colCalculationVersion")
            }

            If firstCutoff Then
                item.SssDeduction = ReadDecimal(row, "colSss")
                item.SssProvidentDeduction = ReadDecimal(row, "colSssProvident")
                item.PhilHealthDeduction = ReadDecimal(row, "colPhilHealth")
                item.PagIbigDeduction = ReadDecimal(row, "colPagIbig")
            Else
                item.CashBondDeduction = ReadDecimal(row, "colCb")
                item.SssLoanDeduction = ReadDecimal(row, "colSssLoan")
                item.SssCalLoanDeduction = ReadDecimal(row, "colSssCalLoan")
                item.PagIbigLoanDeduction = ReadDecimal(row, "colPiLoan")
                item.PagIbigCalLoanDeduction = ReadDecimal(row, "colPiCalLoan")
            End If

            result.Add(item)
        Next
        Return result
    End Function

    Private Sub BuildUniversalSettingsSheet(
        workbook As XLWorkbook,
        dailyWage As Decimal,
        cutoff As String,
        policy As SubClientPayrollPolicy,
        settings As PayrollReportSettings
    )
        Dim sheet = workbook.Worksheets.Add("SETTINGS")
        sheet.Cell("A1").Value = "Setting"
        sheet.Cell("B1").Value = "Value"
        sheet.Cell("A2").Value = "Daily wage"
        sheet.Cell("B2").Value = dailyWage
        sheet.Cell("A3").Value = "Hours per day"
        sheet.Cell("B3").Value = policy.HoursPerDay
        sheet.Cell("A4").Value = "Cutoff calendar days"
        sheet.Cell("B4").Value = SubClientPayrollPolicyService.CutoffDayCount(cutoff)
        sheet.Cell("A5").Value = "Night differential mode"
        sheet.Cell("B5").Value = If(
            policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialFixedCutoffPool,
            1,
            If(policy.NightDifferentialMode = SubClientPayrollPolicy.NightDifferentialDisabled, 2, 0))
        sheet.Cell("A6").Value = "Monthly ND amount (paid by ND days)"
        sheet.Cell("B6").Value = policy.NightDifferentialFixedCutoffAmount
        sheet.Cell("A7").Value = "Incentive enabled"
        sheet.Cell("B7").Value = If(policy.IncentiveEnabled, 1, 0)
        sheet.Cell("A8").Value = "Incentive days"
        sheet.Cell("B8").Value = policy.IncentiveDays
        sheet.Cell("A9").Value = "Incentive month divisor"
        sheet.Cell("B9").Value = policy.IncentiveMonthDivisor
        sheet.Cell("A10").Value = "Incentive cutoff divisor"
        sheet.Cell("B10").Value = policy.IncentiveCutoffDivisor
        sheet.Cell("A11").Value = "Payroll cutoffs per month"
        sheet.Cell("B11").Value = 2
        sheet.Cell("A12").Value = "Policy notes"
        sheet.Cell("B12").Value = policy.Notes
        sheet.Cell("A13").Value = "Manual DTR duty mode"
        sheet.Cell("B13").Value = policy.DutyEntryMode
        sheet.Cell("A14").Value = "Configured single-shift hours"
        sheet.Cell("B14").Value = policy.SingleShiftHours
        sheet.Cell("A15").Value = "Configured shift is night"
        sheet.Cell("B15").Value = If(policy.SingleShiftIsNight, 1, 0)

        sheet.Cell("D1").Value = "Pay code"
        sheet.Cell("E1").Value = "Enabled"
        sheet.Cell("F1").Value = "Additional premium"
        sheet.Cell("G1").Value = "Effective earnings factor"
        For index As Integer = 0 To SubClientPayrollPolicyService.PayCodeOrder.Length - 1
            Dim rule = policy.GetRule(SubClientPayrollPolicyService.PayCodeOrder(index))
            Dim rowNumber = index + 2
            sheet.Cell(rowNumber, 4).Value = rule.Code
            sheet.Cell(rowNumber, 5).Value = If(rule.Enabled, 1, 0)
            sheet.Cell(rowNumber, 6).Value = rule.Multiplier
            sheet.Cell(rowNumber, 7).Value = SubClientPayrollPolicyService.EarningsFactorForCode(policy, rule.Code)
        Next

        sheet.Cell("H1").Value = "Report setting"
        sheet.Cell("I1").Value = "Value"
        Dim reportSettings = New KeyValuePair(Of String, String)() {
            New KeyValuePair(Of String, String)("Company name", settings.CompanyName),
            New KeyValuePair(Of String, String)("Company address", settings.CompanyAddress),
            New KeyValuePair(Of String, String)("Company phone", settings.CompanyPhone),
            New KeyValuePair(Of String, String)("Company email", settings.CompanyEmail),
            New KeyValuePair(Of String, String)("Payroll prepared by", settings.PayrollPreparedName),
            New KeyValuePair(Of String, String)("Payroll approved by", settings.PayrollApprovedName)
        }
        For index As Integer = 0 To reportSettings.Length - 1
            sheet.Cell(index + 2, 8).Value = reportSettings(index).Key
            sheet.Cell(index + 2, 9).Value = reportSettings(index).Value
        Next

        For Each headerRange In {sheet.Range("A1:B1"), sheet.Range("D1:G1"), sheet.Range("H1:I1")}
            headerRange.Style.Font.Bold = True
            headerRange.Style.Fill.BackgroundColor = Teal
            headerRange.Style.Font.FontColor = XLColor.White
        Next
        sheet.Column(1).Width = 31
        sheet.Column(2).Width = 54
        sheet.Column(4).Width = 20
        sheet.Columns(5, 6).Width = 18
        sheet.Column(7).Width = 24
        sheet.Column(8).Width = 28
        sheet.Column(9).Width = 54
        sheet.Range("B2:B11").Style.NumberFormat.Format = "0.######"
        sheet.Range("B14:B15").Style.NumberFormat.Format = "0.######"
        sheet.Range("F2:G13").Style.NumberFormat.Format = "0.######"
        sheet.Visibility = XLWorksheetVisibility.VeryHidden
    End Sub

    Private Sub BuildUniversalPayrollSheet(
        workbook As XLWorkbook,
        mainClientName As String,
        detachmentName As String,
        clientAddress As String,
        dailyWage As Decimal,
        cutoff As String,
        rows As List(Of PayrollExportRow),
        policy As SubClientPayrollPolicy,
        settings As PayrollReportSettings
    )
        Const lastColumn As Integer = 46
        Const dataStartRow As Integer = 12
        Dim sheet = workbook.Worksheets.Add("PAYROLL SHEET")
        Dim dataEndRow = dataStartRow + rows.Count - 1
        Dim totalRow = dataEndRow + 1

        WriteCompanyHeader(sheet, lastColumn, settings)
        WriteUniversalContext(sheet, mainClientName, detachmentName, clientAddress, cutoff, lastColumn)
        WriteUniversalSummary(sheet, dataStartRow, dataEndRow, totalRow, lastColumn)
        WriteUniversalHeaders(sheet)

        For index As Integer = 0 To rows.Count - 1
            WriteUniversalPayrollDataRow(sheet, dataStartRow + index, rows(index), dailyWage, policy)
        Next

        sheet.Cell(totalRow, 1).Value = "TOTAL AMOUNT"
        For column As Integer = 3 To 45
            sheet.Cell(totalRow, column).FormulaA1 = $"SUM({ColumnLetter(column)}{dataStartRow}:{ColumnLetter(column)}{dataEndRow})"
        Next
        StyleTotalRow(sheet.Range(totalRow, 1, totalRow, lastColumn))
        sheet.Range(totalRow, 2, totalRow, 2).Clear(XLClearOptions.Contents)
        sheet.Range(totalRow, 46, totalRow, 46).Clear(XLClearOptions.Contents)

        Dim certificationRow = totalRow + 2
        sheet.Range(certificationRow, 1, certificationRow, lastColumn).Merge()
        sheet.Cell(certificationRow, 1).Value = "I hereby certify that the employees listed above received their corresponding payroll for the stated period."
        sheet.Cell(certificationRow, 1).Style.Font.Italic = True
        WriteSignatoryBlock(sheet, certificationRow + 2, certificationRow + 4, certificationRow + 5, 1, 15,
            "Prepared by:", settings.PayrollPreparedName, settings.PayrollPreparedTitle)
        WriteSignatoryBlock(sheet, certificationRow + 2, certificationRow + 4, certificationRow + 5, 16, 31,
            "Checked by:", settings.DtrCheckedName, settings.DtrCheckedTitle)
        WriteSignatoryBlock(sheet, certificationRow + 2, certificationRow + 4, certificationRow + 5, 32, lastColumn,
            "Approved for payment:", settings.PayrollApprovedName, settings.PayrollApprovedTitle)

        FormatUniversalPayrollSheet(sheet, dataStartRow, totalRow, certificationRow + 5, lastColumn)
    End Sub

    Private Sub WriteUniversalContext(
        sheet As IXLWorksheet,
        mainClientName As String,
        detachmentName As String,
        clientAddress As String,
        cutoff As String,
        lastColumn As Integer
    )
        sheet.Range(6, 1, 6, 5).Merge()
        sheet.Cell(6, 1).Value = "MAIN CLIENT: " & mainClientName
        sheet.Range(6, 6, 6, 16).Merge()
        sheet.Cell(6, 6).Value = "DETACHMENT: " & detachmentName
        sheet.Range(6, 17, 6, 34).Merge()
        sheet.Cell(6, 17).Value = "ADDRESS: " & clientAddress
        sheet.Range(6, 35, 6, lastColumn).Merge()
        sheet.Cell(6, 35).Value = "PERIOD: " & ConvertCutoffToReadable(cutoff)
        With sheet.Range(6, 1, 6, lastColumn).Style
            .Font.Bold = True
            .Font.FontSize = 8
            .Fill.BackgroundColor = XLColor.FromHtml("#F4F6F7")
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Alignment.WrapText = True
            .Border.BottomBorder = XLBorderStyleValues.Thin
        End With
    End Sub

    Private Sub WriteUniversalSummary(
        sheet As IXLWorksheet,
        dataStartRow As Integer,
        dataEndRow As Integer,
        totalRow As Integer,
        lastColumn As Integer
    )
        Dim blocks = New Tuple(Of Integer, Integer, String, String)() {
            Tuple.Create(1, 11, "TOTAL EARNINGS", "AG"),
            Tuple.Create(12, 22, "TOTAL DEDUCTIONS", "AR"),
            Tuple.Create(23, 33, "NET PAYROLL", "AS"),
            Tuple.Create(34, lastColumn, "EMPLOYEES ENTERED", String.Empty)
        }
        For Each block In blocks
            sheet.Range(7, block.Item1, 7, block.Item2).Merge()
            sheet.Cell(7, block.Item1).Value = block.Item3
            sheet.Range(8, block.Item1, 8, block.Item2).Merge()
            If block.Item4 = String.Empty Then
                sheet.Cell(8, block.Item1).FormulaA1 = $"COUNTA(A{dataStartRow}:A{dataEndRow})"
                sheet.Cell(8, block.Item1).Style.NumberFormat.Format = "0"
            Else
                sheet.Cell(8, block.Item1).FormulaA1 = $"{block.Item4}{totalRow}"
                sheet.Cell(8, block.Item1).Style.NumberFormat.Format = MoneyFormat
            End If
        Next

        With sheet.Range(7, 1, 7, lastColumn).Style
            .Fill.BackgroundColor = XLColor.FromHtml("#006B66")
            .Font.FontColor = XLColor.White
            .Font.Bold = True
            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        End With
        With sheet.Range(8, 1, 8, lastColumn).Style
            .Fill.BackgroundColor = XLColor.FromHtml("#D9F0ED")
            .Font.Bold = True
            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            .Border.BottomBorder = XLBorderStyleValues.Thin
        End With
        sheet.Range(9, 1, 9, lastColumn).Merge()
        sheet.Cell(9, 1).Value = "COLOR GUIDE: Yellow cells are DTR/pay-basis inputs. Green cells are policy-driven formulas. Blue cells are allowances and deductions."
        sheet.Cell(9, 1).Style.Font.Italic = True
        sheet.Cell(9, 1).Style.Font.FontSize = 7
        sheet.Cell(9, 1).Style.Font.FontColor = XLColor.FromHtml("#006B66")
    End Sub

    Private Sub WriteUniversalHeaders(sheet As IXLWorksheet)
        SetUniversalGroupHeader(sheet, 1, 1, "EMPLOYEE")
        SetUniversalGroupHeader(sheet, 2, 4, "PAY BASIS")
        SetUniversalGroupHeader(sheet, 5, 16, "TIME INPUTS (HOURS)")
        SetUniversalGroupHeader(sheet, 17, 28, "CALCULATED EARNINGS")
        SetUniversalGroupHeader(sheet, 29, 32, "MANUAL EARNINGS")
        SetUniversalGroupHeader(sheet, 33, 33, "TOTAL")
        SetUniversalGroupHeader(sheet, 34, 44, "DEDUCTIONS")
        SetUniversalGroupHeader(sheet, 45, 45, "RESULTS")
        SetUniversalGroupHeader(sheet, 46, 46, "SIGNATURE")

        Dim headers = {
            "EMPLOYEE NAME", "DAILY WAGE", "NO. DAYS", "TOTAL HRS",
            "REG", "SUN", "LH", "SH", "ND REG", "ND SUN", "ND LH", "ND SH", "OT REG", "OT SUN", "OT LH", "OT SH",
            "BASIC PAY", "SUNDAY PAY", "LEGAL HOLIDAY", "SPECIAL HOLIDAY", "ND REG PAY", "ND SUN PAY", "ND LH PAY", "ND SH PAY",
            "OT REG PAY", "OT SUN PAY", "OT LH PAY", "OT SH PAY",
            "INCENTIVE PAY", "OFFICER ALLOW.", "UNIFORM ALLOW.", "OTHER EARNINGS", "TOTAL EARNINGS",
            "SSS", "SSS PROVIDENT", "PHILHEALTH", "PAG-IBIG", "CASH BOND", "SSS LOAN", "SSS CAL LOAN",
            "PAG-IBIG LOAN", "PAG-IBIG CAL LOAN", "OTHER DEDUCTIONS", "TOTAL DEDUCTIONS", "NET AMOUNT PAID", "SIGNATURE"
        }
        For index As Integer = 0 To headers.Length - 1
            sheet.Cell(11, index + 1).Value = headers(index)
        Next

        With sheet.Range(11, 1, 11, 46).Style
            .Fill.BackgroundColor = XLColor.FromHtml("#E8EEF2")
            .Font.Bold = True
            .Font.FontSize = 7
            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Alignment.WrapText = True
            .Border.TopBorder = XLBorderStyleValues.Thin
            .Border.BottomBorder = XLBorderStyleValues.Thin
            .Border.LeftBorder = XLBorderStyleValues.Thin
            .Border.RightBorder = XLBorderStyleValues.Thin
        End With
    End Sub

    Private Sub SetUniversalGroupHeader(sheet As IXLWorksheet, firstColumn As Integer, lastColumn As Integer, text As String)
        If lastColumn > firstColumn Then sheet.Range(10, firstColumn, 10, lastColumn).Merge()
        sheet.Cell(10, firstColumn).Value = text
        With sheet.Range(10, firstColumn, 10, lastColumn).Style
            .Fill.BackgroundColor = XLColor.FromHtml("#008985")
            .Font.FontColor = XLColor.White
            .Font.Bold = True
            .Font.FontSize = 7
            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Border.TopBorder = XLBorderStyleValues.Thin
            .Border.BottomBorder = XLBorderStyleValues.Thin
            .Border.LeftBorder = XLBorderStyleValues.Thin
            .Border.RightBorder = XLBorderStyleValues.Thin
        End With
    End Sub

    Private Sub WriteUniversalPayrollDataRow(
        sheet As IXLWorksheet,
        rowNumber As Integer,
        item As PayrollExportRow,
        dailyWage As Decimal,
        policy As SubClientPayrollPolicy
    )
        Dim values = UniversalHourValues(item, policy)
        sheet.Cell(rowNumber, 1).Value = item.EmployeeName
        sheet.Cell(rowNumber, 2).Value = If(item.HasMonetarySnapshot AndAlso item.DailyWageSnapshot > 0D, item.DailyWageSnapshot, dailyWage)
        sheet.Cell(rowNumber, 3).Value = item.NumberOfDays
        sheet.Cell(rowNumber, 4).Value = item.TotalHours
        For index As Integer = 0 To values.Length - 1
            sheet.Cell(rowNumber, 5 + index).Value = values(index)
        Next

        If item.HasMonetarySnapshot Then
            Dim savedEarnings = {
                item.RegularEarnings, item.SundayEarnings, item.LegalHolidayEarnings, item.SpecialHolidayEarnings,
                item.NightDifferentialRegularEarnings, item.NightDifferentialSundayEarnings,
                item.NightDifferentialLegalHolidayEarnings, item.NightDifferentialSpecialHolidayEarnings,
                item.OvertimeRegularEarnings, item.OvertimeSundayEarnings,
                item.OvertimeLegalHolidayEarnings, item.OvertimeSpecialHolidayEarnings
            }
            For index As Integer = 0 To savedEarnings.Length - 1
                sheet.Cell(rowNumber, 17 + index).Value = savedEarnings(index)
            Next
            sheet.Cell(rowNumber, 29).Value = item.IncentivePay
        Else
            For index As Integer = 0 To SubClientPayrollPolicyService.PayCodeOrder.Length - 1
                Dim code = SubClientPayrollPolicyService.PayCodeOrder(index)
                Dim settingsRow = index + 2
                Dim inputColumn = ColumnLetter(5 + index)
                Dim payColumn = 17 + index
                Dim formula As String
                If code.Equals("ND_REG", StringComparison.OrdinalIgnoreCase) Then
                    Dim ndDays = item.NightDifferentialDays.ToString(CultureInfo.InvariantCulture)
                    formula = $"IF('SETTINGS'!$E${settingsRow}=0,0,IF('SETTINGS'!$B$5=1,'SETTINGS'!$B$6/'SETTINGS'!$B$11/'SETTINGS'!$B$4*{ndDays},$B{rowNumber}/'SETTINGS'!$B$3*'SETTINGS'!$G${settingsRow}*{inputColumn}{rowNumber}))"
                Else
                    formula = $"IF('SETTINGS'!$E${settingsRow}=0,0,$B{rowNumber}/'SETTINGS'!$B$3*'SETTINGS'!$G${settingsRow}*{inputColumn}{rowNumber})"
                End If
                sheet.Cell(rowNumber, payColumn).FormulaA1 = formula
            Next
            sheet.Cell(rowNumber, 29).FormulaA1 =
                $"IF('SETTINGS'!$B$7=0,0,$B{rowNumber}*'SETTINGS'!$B$8/'SETTINGS'!$B$9/'SETTINGS'!$B$10/'SETTINGS'!$B$4*$C{rowNumber})"
        End If
        sheet.Cell(rowNumber, 30).Value = item.OfficerAllowance
        sheet.Cell(rowNumber, 31).Value = item.SgUniformAllowance
        sheet.Cell(rowNumber, 32).Value = item.OtherEarnings
        If item.HasMonetarySnapshot Then
            sheet.Cell(rowNumber, 33).Value = item.TotalEarnings
        Else
            sheet.Cell(rowNumber, 33).FormulaA1 = $"SUM(Q{rowNumber}:AF{rowNumber})"
        End If
        sheet.Cell(rowNumber, 34).Value = item.SssDeduction
        sheet.Cell(rowNumber, 35).Value = item.SssProvidentDeduction
        sheet.Cell(rowNumber, 36).Value = item.PhilHealthDeduction
        sheet.Cell(rowNumber, 37).Value = item.PagIbigDeduction
        sheet.Cell(rowNumber, 38).Value = item.CashBondDeduction
        sheet.Cell(rowNumber, 39).Value = item.SssLoanDeduction
        sheet.Cell(rowNumber, 40).Value = item.SssCalLoanDeduction
        sheet.Cell(rowNumber, 41).Value = item.PagIbigLoanDeduction
        sheet.Cell(rowNumber, 42).Value = item.PagIbigCalLoanDeduction
        sheet.Cell(rowNumber, 43).Value = item.OtherDeductions
        If item.HasMonetarySnapshot Then
            sheet.Cell(rowNumber, 44).Value = item.TotalDeductions
            sheet.Cell(rowNumber, 45).Value = item.NetPay
        Else
            sheet.Cell(rowNumber, 44).FormulaA1 = $"SUM(AH{rowNumber}:AQ{rowNumber})"
            sheet.Cell(rowNumber, 45).FormulaA1 = $"AG{rowNumber}-AR{rowNumber}"
        End If
    End Sub

    Private Sub FormatUniversalPayrollSheet(
        sheet As IXLWorksheet,
        dataStartRow As Integer,
        totalRow As Integer,
        lastPrintRow As Integer,
        lastColumn As Integer
    )
        Dim dataRange = sheet.Range(dataStartRow, 1, totalRow, lastColumn)
        With dataRange.Style
            .Border.TopBorder = XLBorderStyleValues.Thin
            .Border.BottomBorder = XLBorderStyleValues.Thin
            .Border.LeftBorder = XLBorderStyleValues.Thin
            .Border.RightBorder = XLBorderStyleValues.Thin
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Font.FontSize = 7.5
        End With
        sheet.Range(dataStartRow, 2, totalRow, 16).Style.Fill.BackgroundColor = XLColor.FromHtml("#FFF7DC")
        sheet.Range(dataStartRow, 17, totalRow, 28).Style.Fill.BackgroundColor = XLColor.FromHtml("#E6F4E8")
        sheet.Range(dataStartRow, 29, totalRow, 32).Style.Fill.BackgroundColor = XLColor.FromHtml("#EAF2F8")
        sheet.Range(dataStartRow, 33, totalRow, 33).Style.Fill.BackgroundColor = XLColor.FromHtml("#E6F4E8")
        sheet.Range(dataStartRow, 34, totalRow, 43).Style.Fill.BackgroundColor = XLColor.FromHtml("#EAF2F8")
        sheet.Range(dataStartRow, 44, totalRow, 45).Style.Fill.BackgroundColor = XLColor.FromHtml("#E6F4E8")

        sheet.Range(dataStartRow, 2, totalRow, 2).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(dataStartRow, 3, totalRow, 16).Style.NumberFormat.Format = QuantityFormat
        sheet.Range(dataStartRow, 17, totalRow, 45).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(dataStartRow, 2, totalRow, 45).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right

        sheet.Column(1).Width = 27
        sheet.Columns(2, 4).Width = 10
        sheet.Columns(5, 16).Width = 8.5
        sheet.Columns(17, 28).Width = 12
        sheet.Columns(29, 32).Width = 13
        sheet.Column(33).Width = 14
        sheet.Columns(34, 43).Width = 12
        sheet.Columns(44, 45).Width = 15
        sheet.Column(46).Width = 17
        sheet.Row(6).Height = 30
        sheet.Row(7).Height = 24
        sheet.Row(8).Height = 24
        sheet.Row(10).Height = 24
        sheet.Row(11).Height = 44
        sheet.Rows(dataStartRow, totalRow).Height = 20

        sheet.SheetView.FreezeRows(11)
        sheet.SheetView.FreezeColumns(1)
        sheet.SheetView.View = XLSheetViewOptions.PageBreakPreview
        sheet.ShowGridLines = False
        sheet.PageSetup.PageOrientation = XLPageOrientation.Landscape
        sheet.PageSetup.PaperSize = XLPaperSize.LegalPaper
        sheet.PageSetup.FitToPages(1, 0)
        sheet.PageSetup.SetRowsToRepeatAtTop(1, 11)
        ' Include every payroll column through Signature inside the page
        ' boundary, with additional employee rows continuing down the page.
        sheet.PageSetup.ColumnBreaks.Clear()
        sheet.PageSetup.PrintAreas.Clear()
        sheet.PageSetup.PrintAreas.Add(1, 1, lastPrintRow, lastColumn)
        sheet.PageSetup.Margins.Left = 0.15
        sheet.PageSetup.Margins.Right = 0.15
        sheet.PageSetup.Margins.Top = 0.25
        sheet.PageSetup.Margins.Bottom = 0.25
        sheet.PageSetup.CenterHorizontally = True
    End Sub

    Private Sub BuildPayrollSheet(
        workbook As XLWorkbook,
        clientName As String,
        clientAddress As String,
        cutoff As String,
        rows As List(Of PayrollExportRow),
        firstCutoff As Boolean,
        settings As PayrollReportSettings
    )
        Dim sheet = workbook.Worksheets.Add("PAYROLL")
        Dim lastColumn As Integer = If(firstCutoff, 27, 28)
        Dim dataStartRow As Integer = 15
        Dim dataEndRow As Integer = dataStartRow + rows.Count - 1
        Dim totalRow As Integer = dataEndRow + 1

        WriteCompanyHeader(sheet, lastColumn, settings)
        sheet.Cell(7, 1).Value = "Detachment"
        sheet.Cell(7, 2).Value = clientName
        sheet.Cell(8, 1).Value = "Address"
        sheet.Cell(8, 2).Value = clientAddress
        sheet.Cell(9, 1).Value = "Period"
        sheet.Cell(9, 2).Value = ConvertCutoffToReadable(cutoff)
        sheet.Range(11, 1, 11, lastColumn).Merge()
        sheet.Cell(11, 1).Value = "We hereby acknowledge receipt of the amounts shown opposite our names as full payment for services rendered."
        sheet.Cell(11, 1).Style.Font.Italic = True

        WritePayrollHeaders(sheet, firstCutoff)
        For index As Integer = 0 To rows.Count - 1
            WritePayrollDataRow(sheet, dataStartRow + index, rows(index), firstCutoff)
        Next

        sheet.Cell(totalRow, 1).Value = "TOTAL AMOUNT"
        sheet.Cell(totalRow, 1).Style.Font.Bold = True
        For column As Integer = 2 To lastColumn - 1
            sheet.Cell(totalRow, column).FormulaA1 = $"SUM({ColumnLetter(column)}{dataStartRow}:{ColumnLetter(column)}{dataEndRow})"
        Next
        StyleTotalRow(sheet.Range(totalRow, 1, totalRow, lastColumn))

        Dim certificationRow = totalRow + 1
        sheet.Range(certificationRow, 1, certificationRow, lastColumn).Merge()
        sheet.Cell(certificationRow, 1).Value = "I certify that I personally paid all employees listed above their corresponding payroll for the stated period."
        sheet.Cell(certificationRow + 3, 1).Value = "Prepared by:"
        sheet.Cell(certificationRow + 3, 12).Value = "Approved for payment:"
        sheet.Cell(certificationRow + 5, 1).Value = settings.PayrollPreparedName
        sheet.Cell(certificationRow + 5, 1).Style.Font.Bold = True
        sheet.Cell(certificationRow + 5, 12).Value = settings.PayrollApprovedName
        sheet.Cell(certificationRow + 5, 12).Style.Font.Bold = True
        sheet.Cell(certificationRow + 6, 1).Value = settings.PayrollPreparedTitle
        sheet.Cell(certificationRow + 6, 12).Value = settings.PayrollApprovedTitle

        FormatPayrollSheet(sheet, lastColumn, dataStartRow, totalRow, certificationRow + 6)
    End Sub

    Private Sub WritePayrollHeaders(sheet As IXLWorksheet, firstCutoff As Boolean)
        Dim fixedHeaders = New String() {
            "NAME", "NO. DAYS", "TOTAL HRS", "REG", "SUN", "LH/LH", "", "LH", "SH", "ND", "OT/HRS",
            "BASIC", "SUN", "LH PAY", "SH PAY", "OT PAY", "INC", "SG UNIFORM", "OFFICER'S ALLO", "TOTAL EARNINGS"
        }
        For column As Integer = 1 To fixedHeaders.Length
            sheet.Range(12, column, 13, column).Merge()
            sheet.Cell(12, column).Value = fixedHeaders(column - 1)
        Next

        If firstCutoff Then
            sheet.Range(12, 21, 12, 24).Merge()
            sheet.Cell(12, 21).Value = "DEDUCTIONS"
            sheet.Cell(13, 21).Value = "SSS"
            sheet.Cell(13, 22).Value = "SSS PROVIDENT"
            sheet.Cell(13, 23).Value = "PH"
            sheet.Cell(13, 24).Value = "PI"
            WriteMergedHeader(sheet, 25, "TOTAL DEDUCTIONS")
            WriteMergedHeader(sheet, 26, "NET AMOUNT PAID")
            WriteMergedHeader(sheet, 27, "SIGNATURE")
        Else
            sheet.Range(12, 21, 12, 25).Merge()
            sheet.Cell(12, 21).Value = "DEDUCTIONS"
            sheet.Cell(13, 21).Value = "CASH BOND"
            sheet.Cell(13, 22).Value = "SSS LOAN"
            sheet.Cell(13, 23).Value = "SSS CAL LOAN"
            sheet.Cell(13, 24).Value = "PI LOAN"
            sheet.Cell(13, 25).Value = "PI CAL LOAN"
            WriteMergedHeader(sheet, 26, "TOTAL DEDUCTIONS")
            WriteMergedHeader(sheet, 27, "NET AMOUNT PAID")
            WriteMergedHeader(sheet, 28, "SIGNATURE")
        End If

        Dim lastColumn = If(firstCutoff, 27, 28)
        With sheet.Range(12, 1, 13, lastColumn).Style
            .Font.Bold = True
            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Alignment.WrapText = True
            .Fill.BackgroundColor = LightTeal
            .Border.TopBorder = XLBorderStyleValues.Thin
            .Border.BottomBorder = XLBorderStyleValues.Thin
            .Border.LeftBorder = XLBorderStyleValues.Thin
            .Border.RightBorder = XLBorderStyleValues.Thin
        End With
    End Sub

    Private Sub WriteMergedHeader(sheet As IXLWorksheet, column As Integer, text As String)
        sheet.Range(12, column, 13, column).Merge()
        sheet.Cell(12, column).Value = text
    End Sub

    Private Sub WritePayrollDataRow(sheet As IXLWorksheet, rowNumber As Integer, item As PayrollExportRow, firstCutoff As Boolean)
        sheet.Cell(rowNumber, 1).Value = item.EmployeeName
        sheet.Cell(rowNumber, 2).Value = item.NumberOfDays
        sheet.Cell(rowNumber, 3).Value = item.TotalHours
        sheet.Cell(rowNumber, 4).Value = item.RegularHours
        sheet.Cell(rowNumber, 5).Value = item.SundayHours
        sheet.Cell(rowNumber, 8).Value = item.LegalHolidayHours
        sheet.Cell(rowNumber, 9).Value = item.SpecialHolidayHours
        sheet.Cell(rowNumber, 10).Value = item.NightDifferentialDays
        sheet.Cell(rowNumber, 11).Value = item.OvertimeRegularHours
        sheet.Cell(rowNumber, 18).Value = item.SgUniformAllowance
        sheet.Cell(rowNumber, 19).Value = item.OfficerAllowance

        sheet.Cell(rowNumber, 12).FormulaA1 = $"'SETTINGS'!$B$2/'SETTINGS'!$B$3*D{rowNumber}"
        sheet.Cell(rowNumber, 13).FormulaA1 = $"'SETTINGS'!$B$2/'SETTINGS'!$B$3*(1+'SETTINGS'!$B$4)*E{rowNumber}"
        sheet.Cell(rowNumber, 14).FormulaA1 = $"'SETTINGS'!$B$2/'SETTINGS'!$B$3*(1+'SETTINGS'!$B$6)*H{rowNumber}"
        sheet.Cell(rowNumber, 15).FormulaA1 = $"'SETTINGS'!$B$2/'SETTINGS'!$B$3*(1+'SETTINGS'!$B$5)*I{rowNumber}"
        sheet.Cell(rowNumber, 16).FormulaA1 = $"'SETTINGS'!$B$7*K{rowNumber}"
        sheet.Cell(rowNumber, 17).FormulaA1 = $"'SETTINGS'!$B$2*'SETTINGS'!$B$8/'SETTINGS'!$B$9/'SETTINGS'!$B$10*C{rowNumber}"
        sheet.Cell(rowNumber, 20).FormulaA1 = $"SUM(L{rowNumber}:S{rowNumber})"

        If firstCutoff Then
            sheet.Cell(rowNumber, 21).Value = item.SssDeduction
            sheet.Cell(rowNumber, 22).Value = item.SssProvidentDeduction
            sheet.Cell(rowNumber, 23).Value = item.PhilHealthDeduction
            sheet.Cell(rowNumber, 24).Value = item.PagIbigDeduction
            sheet.Cell(rowNumber, 25).FormulaA1 = $"SUM(U{rowNumber}:X{rowNumber})"
            sheet.Cell(rowNumber, 26).FormulaA1 = $"T{rowNumber}-Y{rowNumber}"
        Else
            sheet.Cell(rowNumber, 21).Value = item.CashBondDeduction
            sheet.Cell(rowNumber, 22).Value = item.SssLoanDeduction
            sheet.Cell(rowNumber, 23).Value = item.SssCalLoanDeduction
            sheet.Cell(rowNumber, 24).Value = item.PagIbigLoanDeduction
            sheet.Cell(rowNumber, 25).Value = item.PagIbigCalLoanDeduction
            sheet.Cell(rowNumber, 26).FormulaA1 = $"SUM(U{rowNumber}:Y{rowNumber})"
            sheet.Cell(rowNumber, 27).FormulaA1 = $"T{rowNumber}-Z{rowNumber}"
        End If
    End Sub

    Private Sub FormatPayrollSheet(
        sheet As IXLWorksheet,
        lastColumn As Integer,
        dataStartRow As Integer,
        totalRow As Integer,
        lastRow As Integer
    )
        sheet.SheetView.FreezeRows(13)
        sheet.Row(2).Height = 25
        sheet.Rows(12, 13).Height = 31
        sheet.Column(1).Width = 24
        sheet.Column(2).Width = 9
        sheet.Column(3).Width = 10
        For column As Integer = 4 To 11
            sheet.Column(column).Width = 8
        Next
        For column As Integer = 12 To lastColumn - 1
            sheet.Column(column).Width = 13
        Next
        sheet.Column(lastColumn).Width = 16

        Dim dataRange = sheet.Range(dataStartRow, 1, totalRow, lastColumn)
        dataRange.Style.Border.TopBorder = XLBorderStyleValues.Thin
        dataRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin
        dataRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin
        dataRange.Style.Border.RightBorder = XLBorderStyleValues.Thin
        dataRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        sheet.Range(dataStartRow, 2, totalRow, 11).Style.NumberFormat.Format = QuantityFormat
        sheet.Range(dataStartRow, 12, totalRow, lastColumn - 1).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(dataStartRow, 2, totalRow, lastColumn - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
        sheet.Range(dataStartRow, 1, totalRow, lastColumn).Style.Font.FontSize = 9

        sheet.PageSetup.PageOrientation = XLPageOrientation.Landscape
        sheet.PageSetup.PaperSize = XLPaperSize.A4Paper
        sheet.PageSetup.FitToPages(1, 0)
        sheet.PageSetup.SetRowsToRepeatAtTop(1, 13)
        sheet.PageSetup.PrintAreas.Add(1, 1, lastRow, lastColumn)
        sheet.PageSetup.Margins.Left = 0.2
        sheet.PageSetup.Margins.Right = 0.2
        sheet.PageSetup.Margins.Top = 0.35
        sheet.PageSetup.Margins.Bottom = 0.35
        sheet.PageSetup.CenterHorizontally = True
    End Sub

    Private Sub BuildPayslipSheet(
        workbook As XLWorkbook,
        clientName As String,
        clientAddress As String,
        cutoff As String,
        employeeCount As Integer,
        firstCutoff As Boolean,
        settings As PayrollReportSettings
    )
        Dim sheet = workbook.Worksheets.Add("PAYSLIP")
        Const blockHeight As Integer = 25
        Const slipsPerRow As Integer = 2
        Const pairRowsPerPage As Integer = 2

        For index As Integer = 0 To employeeCount - 1
            Dim pairRowIndex = index \ slipsPerRow
            Dim startRow = 1 + pairRowIndex * blockHeight
            Dim startColumn = If(index Mod slipsPerRow = 0, 1, 9)
            Dim payrollRow = 12 + index
            WritePayslipBlock(sheet, startRow, startColumn, payrollRow, clientName, clientAddress, cutoff, firstCutoff, settings)
        Next

        ' Reclaim the empty value/spacer columns; labels span them instead.
        Dim compactWidths = New Double() {10.5, 1.5, 4.5, 8, 10, 1.5, 8}
        For offset As Integer = 0 To compactWidths.Length - 1
            sheet.Column(1 + offset).Width = compactWidths(offset)
            sheet.Column(9 + offset).Width = compactWidths(offset)
        Next
        sheet.Column(8).Width = 1.2
        FitPayslipWrappedRows(sheet, employeeCount)
        sheet.ShowGridLines = False
        sheet.PageSetup.PageOrientation = XLPageOrientation.Portrait
        sheet.PageSetup.PaperSize = XLPaperSize.A4Paper
        Dim pairCount = CInt(Math.Ceiling(employeeCount / CDbl(slipsPerRow)))
        sheet.PageSetup.PrintAreas.Add(1, 1, pairCount * blockHeight, 15)
        sheet.PageSetup.Margins.Left = 0.2
        sheet.PageSetup.Margins.Right = 0.2
        sheet.PageSetup.Margins.Top = 0.2
        sheet.PageSetup.Margins.Bottom = 0.2
        sheet.PageSetup.CenterHorizontally = True

        ' Print two pairs (four employees) per page. Use explicit scaling
        ' so Excel honors these manual breaks instead of fitting the whole
        ' worksheet to an automatically chosen number of pages.
        Dim largestPageHeight As Double = 0
        For pairRowIndex As Integer = 0 To pairCount - 1 Step pairRowsPerPage
            Dim startRow = 1 + pairRowIndex * blockHeight
            Dim lastRow = Math.Min(pairCount, pairRowIndex + pairRowsPerPage) * blockHeight
            largestPageHeight = Math.Max(largestPageHeight,
                Enumerable.Range(startRow, lastRow - startRow + 1).Sum(Function(row) sheet.Row(row).Height))
            If pairRowIndex > 0 Then sheet.PageSetup.AddHorizontalPageBreak(startRow - 1)
        Next
        Using bitmap As New Bitmap(1, 1)
            bitmap.SetResolution(96, 96)
            Using drawingGraphics = Graphics.FromImage(bitmap)
                Dim digitWidth = ReportDigitWidth(sheet, drawingGraphics)
                Dim contentWidth = Enumerable.Range(1, 15).Sum(Function(column) VisibleColumnPixels(sheet, column, digitWidth)) * 72.0 / 96.0
                ' A4 dimensions in points, with a small printer-tolerance inset.
                Dim printableWidth = 595.28 - (sheet.PageSetup.Margins.Left + sheet.PageSetup.Margins.Right) * 72 - 12
                Dim printableHeight = 841.89 - (sheet.PageSetup.Margins.Top + sheet.PageSetup.Margins.Bottom) * 72 - 12
                Dim printScale = Math.Floor(100 * Math.Min(1, Math.Min(printableWidth / contentWidth, printableHeight / Math.Max(1, largestPageHeight))))
                sheet.PageSetup.Scale = CInt(Math.Max(10, printScale))
            End Using
        End Using
    End Sub

    Private Sub WritePayslipBlock(
        sheet As IXLWorksheet,
        startRow As Integer,
        startColumn As Integer,
        payrollRow As Integer,
        clientName As String,
        clientAddress As String,
        cutoff As String,
        firstCutoff As Boolean,
        settings As PayrollReportSettings
    )
        Dim endRow = startRow + 23
        Dim typeColumn = startColumn
        Dim valueStartColumn = startColumn + 1
        Dim hoursColumn = startColumn + 2
        Dim amountColumn = startColumn + 3
        Dim deductionTypeColumn = startColumn + 4
        Dim deductionValueStartColumn = startColumn + 5
        Dim deductionAmountColumn = startColumn + 6

        sheet.Range(startRow, startColumn, startRow + 1, startColumn).Merge()
        sheet.Range(startRow, valueStartColumn, startRow, deductionAmountColumn).Merge()
        sheet.Cell(startRow, valueStartColumn).Value = settings.CompanyName
        sheet.Cell(startRow, valueStartColumn).Style.Font.Bold = True
        sheet.Cell(startRow, valueStartColumn).Style.Font.FontColor = Maroon
        sheet.Cell(startRow, valueStartColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        sheet.Range(startRow + 1, valueStartColumn, startRow + 1, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 1, valueStartColumn).Value = settings.CompanyAddress
        sheet.Cell(startRow + 1, valueStartColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        sheet.Range(startRow, valueStartColumn, startRow + 1, deductionAmountColumn).Style.Alignment.WrapText = True

        sheet.Cell(startRow + 2, typeColumn).Value = "Detachment:"
        sheet.Range(startRow + 2, valueStartColumn, startRow + 2, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 2, valueStartColumn).Value = clientName
        sheet.Cell(startRow + 3, typeColumn).Value = "Address:"
        sheet.Range(startRow + 3, valueStartColumn, startRow + 3, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 3, valueStartColumn).Value = clientAddress
        sheet.Cell(startRow + 4, typeColumn).Value = "Name:"
        sheet.Range(startRow + 4, valueStartColumn, startRow + 4, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 4, valueStartColumn).FormulaA1 = $"'PAYROLL SHEET'!A{payrollRow}"
        sheet.Cell(startRow + 5, typeColumn).Value = "Period Covered:"
        sheet.Range(startRow + 5, valueStartColumn, startRow + 5, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 5, valueStartColumn).Value = ConvertCutoffToReadable(cutoff)
        sheet.Cell(startRow + 6, typeColumn).Value = "Total Number of Days"
        sheet.Range(startRow + 6, typeColumn, startRow + 6, valueStartColumn).Merge()
        sheet.Cell(startRow + 6, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!C{payrollRow}"
        sheet.Cell(startRow + 6, deductionTypeColumn).Value = "Total Number of Hrs."
        sheet.Range(startRow + 6, deductionTypeColumn, startRow + 6, deductionValueStartColumn).Merge()
        sheet.Cell(startRow + 6, deductionAmountColumn).FormulaA1 = $"'PAYROLL SHEET'!D{payrollRow}"

        sheet.Range(startRow + 7, startColumn, startRow + 7, amountColumn).Merge()
        sheet.Cell(startRow + 7, startColumn).Value = "SALARY"
        sheet.Range(startRow + 7, deductionTypeColumn, startRow + 7, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 7, deductionTypeColumn).Value = "DEDUCTIONS"
        sheet.Range(startRow + 7, startColumn, startRow + 8, deductionAmountColumn).Style.Fill.BackgroundColor = LightTeal
        sheet.Range(startRow + 7, startColumn, startRow + 8, deductionAmountColumn).Style.Font.Bold = True
        sheet.Range(startRow + 7, startColumn, startRow + 8, deductionAmountColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        sheet.Cell(startRow + 8, typeColumn).Value = "TYPE"
        sheet.Cell(startRow + 8, hoursColumn).Value = "HOURS"
        sheet.Cell(startRow + 8, amountColumn).Value = "AMOUNT (PHP)"
        sheet.Cell(startRow + 8, deductionTypeColumn).Value = "TYPE"
        sheet.Cell(startRow + 8, deductionAmountColumn).Value = "AMOUNT (PHP)"
        For rowNumber = startRow + 8 To startRow + 20
            sheet.Range(rowNumber, typeColumn, rowNumber, valueStartColumn).Merge()
            sheet.Range(rowNumber, deductionTypeColumn, rowNumber, deductionValueStartColumn).Merge()
        Next

        Dim earningLabels = New String() {
            "Daily Wage", "Basic Pay", "Sunday Pay", "Legal Holiday", "Special Holiday",
            "Night Differential", "OT Regular", "OT Sunday", "OT Legal Holiday",
            "OT Special Holiday", "Incentive Pay", "Allowances / Other"
        }
        For offset As Integer = 0 To earningLabels.Length - 1
            sheet.Cell(startRow + 9 + offset, typeColumn).Value = earningLabels(offset)
        Next
        sheet.Cell(startRow + 9, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!B{payrollRow}"
        sheet.Cell(startRow + 10, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!E{payrollRow}"
        sheet.Cell(startRow + 10, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!Q{payrollRow}"
        sheet.Cell(startRow + 11, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!F{payrollRow}"
        sheet.Cell(startRow + 11, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!R{payrollRow}"
        sheet.Cell(startRow + 12, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!G{payrollRow}"
        sheet.Cell(startRow + 12, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!S{payrollRow}"
        sheet.Cell(startRow + 13, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!H{payrollRow}"
        sheet.Cell(startRow + 13, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!T{payrollRow}"
        sheet.Cell(startRow + 14, hoursColumn).FormulaA1 = $"SUM('PAYROLL SHEET'!I{payrollRow}:L{payrollRow})"
        sheet.Cell(startRow + 14, amountColumn).FormulaA1 = $"SUM('PAYROLL SHEET'!U{payrollRow}:X{payrollRow})"
        sheet.Cell(startRow + 15, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!M{payrollRow}"
        sheet.Cell(startRow + 15, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!Y{payrollRow}"
        sheet.Cell(startRow + 16, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!N{payrollRow}"
        sheet.Cell(startRow + 16, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!Z{payrollRow}"
        sheet.Cell(startRow + 17, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!O{payrollRow}"
        sheet.Cell(startRow + 17, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!AA{payrollRow}"
        sheet.Cell(startRow + 18, hoursColumn).FormulaA1 = $"'PAYROLL SHEET'!P{payrollRow}"
        sheet.Cell(startRow + 18, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!AB{payrollRow}"
        sheet.Cell(startRow + 19, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!AC{payrollRow}"
        sheet.Cell(startRow + 20, amountColumn).FormulaA1 = $"SUM('PAYROLL SHEET'!AD{payrollRow}:AF{payrollRow})"

        If firstCutoff Then
            WritePayslipDeduction(sheet, startRow + 9, startColumn, "SSS", $"'PAYROLL SHEET'!AH{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 10, startColumn, "SSS Provident", $"'PAYROLL SHEET'!AI{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 11, startColumn, "PhilHealth", $"'PAYROLL SHEET'!AJ{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 12, startColumn, "Pag-IBIG", $"'PAYROLL SHEET'!AK{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 13, startColumn, "Other", $"'PAYROLL SHEET'!AQ{payrollRow}")
        Else
            WritePayslipDeduction(sheet, startRow + 9, startColumn, "Cash Bond", $"'PAYROLL SHEET'!AL{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 10, startColumn, "SSS Loan", $"'PAYROLL SHEET'!AM{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 11, startColumn, "SSS Cal Loan", $"'PAYROLL SHEET'!AN{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 12, startColumn, "Pag-IBIG Loan", $"'PAYROLL SHEET'!AO{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 13, startColumn, "Pag-IBIG Cal Loan", $"'PAYROLL SHEET'!AP{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 14, startColumn, "Other", $"'PAYROLL SHEET'!AQ{payrollRow}")
        End If

        sheet.Cell(startRow + 21, typeColumn).Value = "TOTAL EARNINGS"
        sheet.Range(startRow + 21, typeColumn, startRow + 21, hoursColumn).Merge()
        sheet.Cell(startRow + 21, amountColumn).FormulaA1 = $"'PAYROLL SHEET'!AG{payrollRow}"
        sheet.Cell(startRow + 21, deductionTypeColumn).Value = "TOTAL DEDUCTIONS"
        sheet.Range(startRow + 21, deductionTypeColumn, startRow + 21, deductionValueStartColumn).Merge()
        sheet.Cell(startRow + 21, deductionAmountColumn).FormulaA1 = $"'PAYROLL SHEET'!AR{payrollRow}"
        sheet.Range(startRow + 22, typeColumn, startRow + 22, deductionValueStartColumn).Merge()
        sheet.Cell(startRow + 22, typeColumn).Value = "**** NET PAY ****"
        sheet.Cell(startRow + 22, typeColumn).Style.Font.Bold = True
        sheet.Cell(startRow + 22, typeColumn).Style.Font.Italic = True
        sheet.Cell(startRow + 22, typeColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        sheet.Cell(startRow + 22, deductionAmountColumn).FormulaA1 = $"'PAYROLL SHEET'!AS{payrollRow}"

        Dim blockRange = sheet.Range(startRow, startColumn, endRow - 1, deductionAmountColumn)
        blockRange.Style.Border.TopBorder = XLBorderStyleValues.Thin
        blockRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin
        blockRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin
        blockRange.Style.Border.RightBorder = XLBorderStyleValues.Thin
        blockRange.Style.Font.FontSize = 9
        sheet.Cell(startRow, valueStartColumn).Style.Font.FontSize = 10
        sheet.Cell(startRow + 1, valueStartColumn).Style.Font.FontSize = 8
        blockRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        sheet.Range(startRow + 2, startColumn, startRow + 22, deductionAmountColumn).Style.Alignment.WrapText = True
        sheet.Range(startRow + 9, hoursColumn, startRow + 20, hoursColumn).Style.NumberFormat.Format = QuantityFormat
        sheet.Range(startRow + 9, amountColumn, startRow + 22, amountColumn).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(startRow + 9, deductionAmountColumn, startRow + 22, deductionAmountColumn).Style.NumberFormat.Format = MoneyFormat
        StyleTotalRow(sheet.Range(startRow + 21, startColumn, startRow + 22, deductionAmountColumn))
        sheet.Row(startRow).Height = 22
        sheet.Row(startRow + 1).Height = 18
        ' Give each payslip more vertical space; wrapped rows may grow further.
        For rowNumber As Integer = startRow + 2 To startRow + 20
            sheet.Row(rowNumber).Height = 20
        Next
        sheet.Row(startRow + 21).Height = 22
        sheet.Row(startRow + 22).Height = 24
        sheet.Row(startRow + 23).Height = 8
        sheet.Row(startRow + 24).Height = 8
    End Sub

    Private Sub FitPayslipWrappedRows(sheet As IXLWorksheet, employeeCount As Integer)
        Using bitmap As New Bitmap(1, 1)
            bitmap.SetResolution(96, 96)
            Using drawingGraphics = Graphics.FromImage(bitmap)
                Dim normalFont = sheet.Workbook.Style.Font
                Dim digitWidth As Integer
                Using font As New Font(normalFont.FontName, CSng(normalFont.FontSize))
                    digitWidth = CInt(Math.Round(drawingGraphics.MeasureString("0", font, PointF.Empty, StringFormat.GenericTypographic).Width))
                End Using
                For index = 0 To employeeCount - 1
                    Dim startRow = 1 + (index \ 2) * 25
                    Dim startColumn = If(index Mod 2 = 0, 1, 9)
                    For Each cell In sheet.Range(startRow, startColumn, startRow + 22, startColumn + 6).CellsUsed()
                        Dim text As String
                        If cell.HasFormula Then
                            ' Only the employee-name formula contains text;
                            ' numeric payroll formulas retain their formatting.
                            If cell.Address.RowNumber <> startRow + 4 OrElse cell.Address.ColumnNumber <> startColumn + 1 Then Continue For
                            text = sheet.Workbook.Worksheet("PAYROLL SHEET").Cell(12 + index, 1).GetString()
                        Else
                            text = cell.GetString()
                        End If
                        FitWrappedReportCell(sheet, cell, text, drawingGraphics, digitWidth)
                    Next
                Next
            End Using
        End Using
    End Sub

    Private Sub WritePayslipDeduction(sheet As IXLWorksheet, row As Integer, startColumn As Integer, label As String, formula As String)
        sheet.Cell(row, startColumn + 4).Value = label
        sheet.Cell(row, startColumn + 6).FormulaA1 = formula
    End Sub

    Private Sub BuildClassificationDetailSheet(
        workbook As XLWorkbook,
        mainClientName As String,
        detachmentName As String,
        clientAddress As String,
        cutoff As String,
        rows As List(Of PayrollExportRow),
        settings As PayrollReportSettings
    )
        Const lastColumn As Integer = 20
        Const headerRow As Integer = 13
        Const dataStartRow As Integer = 14
        Dim sheet = workbook.Worksheets.Add("CLASSIFICATION DETAIL")
        WriteCompanyHeader(sheet, lastColumn, settings)

        sheet.Range(7, 1, 7, 4).Merge()
        sheet.Cell(7, 1).Value = "MAIN CLIENT"
        sheet.Range(7, 5, 7, 10).Merge()
        sheet.Cell(7, 5).Value = mainClientName
        sheet.Range(7, 11, 7, 13).Merge()
        sheet.Cell(7, 11).Value = "DETACHMENT"
        sheet.Range(7, 14, 7, lastColumn).Merge()
        sheet.Cell(7, 14).Value = detachmentName
        sheet.Range(8, 1, 8, 4).Merge()
        sheet.Cell(8, 1).Value = "ADDRESS"
        sheet.Range(8, 5, 8, 14).Merge()
        sheet.Cell(8, 5).Value = clientAddress
        sheet.Range(8, 15, 8, 17).Merge()
        sheet.Cell(8, 15).Value = "PERIOD"
        sheet.Range(8, 18, 8, lastColumn).Merge()
        sheet.Cell(8, 18).Value = ConvertCutoffToReadable(cutoff)
        With sheet.Range(7, 1, 8, lastColumn).Style
            .Font.Bold = True
            .Fill.BackgroundColor = XLColor.FromHtml("#F4F6F7")
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Alignment.WrapText = True
            .Border.BottomBorder = XLBorderStyleValues.Thin
        End With

        sheet.Range(10, 1, 10, lastColumn).Merge()
        sheet.Cell(10, 1).Value =
            "Sunday + SH/LH hours are separated from standalone holiday hours. " &
            "ND and OT are premium-hour subsets and must not be added again when reconciling TOTAL HRS."
        With sheet.Range(10, 1, 10, lastColumn).Style
            .Font.Italic = True
            .Font.FontColor = XLColor.FromHtml("#005B58")
            .Fill.BackgroundColor = LightTeal
            .Alignment.WrapText = True
        End With

        SetClassificationGroupHeader(sheet, 1, 2, "EMPLOYEE AND TOTAL")
        SetClassificationGroupHeader(sheet, 3, 8, "DAY CLASSIFICATION HOURS")
        SetClassificationGroupHeader(sheet, 9, 14, "NIGHT DIFFERENTIAL HOURS")
        SetClassificationGroupHeader(sheet, 15, 20, "OVERTIME HOURS")

        Dim headers = {
            "EMPLOYEE NAME", "TOTAL HRS",
            "REG", "SUN", "SH", "SUN + SH", "LH", "SUN + LH",
            "ND REG", "ND SUN", "ND SH", "ND SUN + SH", "ND LH", "ND SUN + LH",
            "OT REG", "OT SUN", "OT SH", "OT SUN + SH", "OT LH", "OT SUN + LH"
        }
        For index As Integer = 0 To headers.Length - 1
            sheet.Cell(headerRow, index + 1).Value = headers(index)
        Next
        With sheet.Range(headerRow, 1, headerRow, lastColumn).Style
            .Fill.BackgroundColor = XLColor.FromHtml("#E8EEF2")
            .Font.Bold = True
            .Font.FontSize = 8
            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Alignment.WrapText = True
            .Border.TopBorder = XLBorderStyleValues.Thin
            .Border.BottomBorder = XLBorderStyleValues.Thin
        End With

        For index As Integer = 0 To rows.Count - 1
            Dim rowNumber = dataStartRow + index
            Dim item = rows(index)
            Dim values As Object() = {
                item.EmployeeName, item.TotalHours,
                item.RegularHours, item.SundayHours,
                StandaloneClassificationHours(item.SpecialHolidayHours, item.SundaySpecialHolidayHours), item.SundaySpecialHolidayHours,
                StandaloneClassificationHours(item.LegalHolidayHours, item.SundayLegalHolidayHours), item.SundayLegalHolidayHours,
                item.NightDifferentialRegularHours, item.NightDifferentialSundayHours,
                StandaloneClassificationHours(item.NightDifferentialSpecialHolidayHours, item.NightDifferentialSundaySpecialHolidayHours), item.NightDifferentialSundaySpecialHolidayHours,
                StandaloneClassificationHours(item.NightDifferentialLegalHolidayHours, item.NightDifferentialSundayLegalHolidayHours), item.NightDifferentialSundayLegalHolidayHours,
                item.OvertimeRegularHours, item.OvertimeSundayHours,
                StandaloneClassificationHours(item.OvertimeSpecialHolidayHours, item.OvertimeSundaySpecialHolidayHours), item.OvertimeSundaySpecialHolidayHours,
                StandaloneClassificationHours(item.OvertimeLegalHolidayHours, item.OvertimeSundayLegalHolidayHours), item.OvertimeSundayLegalHolidayHours
            }
            For columnIndex As Integer = 0 To values.Length - 1
                If TypeOf values(columnIndex) Is Decimal Then
                    sheet.Cell(rowNumber, columnIndex + 1).Value = CDec(values(columnIndex))
                Else
                    sheet.Cell(rowNumber, columnIndex + 1).Value = Convert.ToString(values(columnIndex))
                End If
            Next
        Next

        Dim dataEndRow = Math.Max(dataStartRow, dataStartRow + rows.Count - 1)
        Dim totalRow = dataStartRow + rows.Count
        sheet.Cell(totalRow, 1).Value = "TOTAL"
        For column As Integer = 2 To lastColumn
            sheet.Cell(totalRow, column).FormulaA1 =
                $"SUM({ColumnLetter(column)}{dataStartRow}:{ColumnLetter(column)}{dataEndRow})"
        Next
        StyleTotalRow(sheet.Range(totalRow, 1, totalRow, lastColumn))

        sheet.Range(dataStartRow, 2, totalRow, lastColumn).Style.NumberFormat.Format = QuantityFormat
        If rows.Count > 0 Then
            sheet.Range(dataStartRow, 1, dataEndRow, lastColumn).Style.Border.BottomBorder = XLBorderStyleValues.Hair
        End If
        For Each combinedColumn In {6, 8, 12, 14, 18, 20}
            sheet.Range(headerRow, combinedColumn, dataEndRow, combinedColumn).Style.Fill.BackgroundColor = LightTeal
        Next
        sheet.Range(headerRow, 1, totalRow, lastColumn).SetAutoFilter()
        sheet.SheetView.FreezeRows(headerRow)
        sheet.SheetView.FreezeColumns(1)
        sheet.Column(1).Width = 30
        sheet.Column(2).Width = 12
        sheet.Columns(3, lastColumn).Width = 11
        For Each combinedColumn In {6, 8, 12, 14, 18, 20}
            sheet.Column(combinedColumn).Width = 14
        Next
        sheet.Row(10).Height = 34
        sheet.Row(headerRow).Height = 34
        sheet.ShowGridLines = False
        sheet.PageSetup.PageOrientation = XLPageOrientation.Landscape
        sheet.PageSetup.PaperSize = XLPaperSize.A4Paper
        sheet.PageSetup.FitToPages(1, 0)
        sheet.PageSetup.SetRowsToRepeatAtTop(1, headerRow)
        sheet.PageSetup.PrintAreas.Add(1, 1, totalRow, lastColumn)
        sheet.PageSetup.Margins.Left = 0.25
        sheet.PageSetup.Margins.Right = 0.25
    End Sub

    Private Sub SetClassificationGroupHeader(sheet As IXLWorksheet, firstColumn As Integer, lastColumn As Integer, text As String)
        sheet.Range(12, firstColumn, 12, lastColumn).Merge()
        sheet.Cell(12, firstColumn).Value = text
        With sheet.Range(12, firstColumn, 12, lastColumn).Style
            .Fill.BackgroundColor = LightTeal
            .Font.FontColor = XLColor.FromHtml("#005B58")
            .Font.Bold = True
            .Font.FontSize = 8
            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Border.TopBorder = XLBorderStyleValues.Thin
            .Border.BottomBorder = XLBorderStyleValues.Thin
        End With
    End Sub

    Private Function StandaloneClassificationHours(inclusiveHours As Decimal, combinedHours As Decimal) As Decimal
        Return Math.Max(0D, inclusiveHours - combinedHours)
    End Function

    Private Sub BuildDtrHoursSheet(
        workbook As XLWorkbook,
        mainClientName As String,
        detachmentName As String,
        clientAddress As String,
        cutoff As String,
        grid As DataGridView,
        settings As PayrollReportSettings
    )
        Dim sheet = workbook.Worksheets.Add("DTR_Hours")
        Dim dayColumns As New List(Of DataGridViewColumn)()
        If grid IsNot Nothing Then
            For index As Integer = 1 To Math.Max(0, grid.Columns.Count - 2)
                dayColumns.Add(grid.Columns(index))
            Next
        End If

        Dim lastColumn = Math.Max(2, dayColumns.Count + 2)
        WriteCompanyHeader(sheet, lastColumn, settings)
        sheet.Cell(6, 1).Value = "Client Name:"
        sheet.Cell(6, 2).Value = mainClientName
        sheet.Cell(7, 1).Value = "Detachment:"
        sheet.Cell(7, 2).Value = detachmentName
        sheet.Cell(8, 1).Value = "Address:"
        sheet.Cell(8, 2).Value = clientAddress
        sheet.Cell(10, 1).Value = "Covered Period:"
        sheet.Cell(10, 2).Value = ConvertCutoffToReadable(cutoff)
        If lastColumn > 2 Then
            For Each contextRow In {6, 7, 8, 10}
                sheet.Range(contextRow, 2, contextRow, lastColumn).Merge()
            Next
        End If
        sheet.Range(12, 1, 13, 1).Merge()
        sheet.Cell(12, 1).Value = "Internal Security Name"
        sheet.Range(12, lastColumn, 13, lastColumn).Merge()
        sheet.Cell(12, lastColumn).Value = "TOTAL NO. OF HOURS"

        Dim hasDayNameRow = grid IsNot Nothing AndAlso grid.Rows.Count > 0 AndAlso Not grid.Rows(0).IsNewRow
        For index As Integer = 0 To dayColumns.Count - 1
            Dim columnNumber = index + 2
            Dim dayName As String = ""
            If hasDayNameRow Then dayName = Convert.ToString(grid.Rows(0).Cells(dayColumns(index).Index).Value)
            sheet.Cell(12, columnNumber).Value = dayName
            sheet.Cell(13, columnNumber).Value = dayColumns(index).HeaderText
            If dayName.Trim().Equals("Sun", StringComparison.OrdinalIgnoreCase) Then
                sheet.Cell(12, columnNumber).Style.Fill.BackgroundColor = XLColor.LightGreen
            End If
        Next

        Dim dataStartRow = 15
        Dim outputRow = dataStartRow
        If grid IsNot Nothing Then
            For Each dataGridRow As DataGridViewRow In grid.Rows
                If dataGridRow.IsNewRow Then Continue For
                If hasDayNameRow AndAlso dataGridRow.Index = 0 Then Continue For
                sheet.Cell(outputRow, 1).Value = Convert.ToString(dataGridRow.Cells(0).Value)
                For index As Integer = 0 To dayColumns.Count - 1
                    sheet.Cell(outputRow, index + 2).Value = ParseDecimal(dataGridRow.Cells(dayColumns(index).Index).Value)
                Next
                If dayColumns.Count > 0 Then
                    sheet.Cell(outputRow, lastColumn).FormulaA1 = $"SUM(B{outputRow}:{ColumnLetter(lastColumn - 1)}{outputRow})"
                Else
                    sheet.Cell(outputRow, lastColumn).Value = 0D
                End If
                outputRow += 1
            Next
        End If

        Dim dataEndRow = Math.Max(dataStartRow, outputRow - 1)
        Dim totalRow = outputRow
        sheet.Cell(totalRow, 1).Value = "TOTAL NUMBER OF HOURS"
        For column As Integer = 2 To lastColumn
            sheet.Cell(totalRow, column).FormulaA1 = $"SUM({ColumnLetter(column)}{dataStartRow}:{ColumnLetter(column)}{dataEndRow})"
        Next
        StyleTotalRow(sheet.Range(totalRow, 1, totalRow, lastColumn))
        Dim signatoryEndRow = WriteDtrSignatories(sheet, totalRow + 3, lastColumn, settings)
        StyleDtrSheet(sheet, lastColumn, dataStartRow, totalRow, signatoryEndRow)
    End Sub

    Private Function WriteDtrSignatories(
        sheet As IXLWorksheet,
        labelRow As Integer,
        lastColumn As Integer,
        settings As PayrollReportSettings
    ) As Integer
        Dim checkedColumn = Math.Max(2, CInt(Math.Ceiling(lastColumn / 3.0R)))
        Dim notedColumn = Math.Max(checkedColumn + 1, CInt(Math.Ceiling(lastColumn * 2.0R / 3.0R)))
        Dim nameRow = labelRow + 2
        Dim titleRow = labelRow + 3

        WriteSignatoryBlock(sheet, labelRow, nameRow, titleRow, 1, checkedColumn - 1, "Prepared by:", settings.DtrPreparedName, settings.DtrPreparedTitle)
        WriteSignatoryBlock(sheet, labelRow, nameRow, titleRow, checkedColumn, notedColumn - 1, "Checked by:", settings.DtrCheckedName, settings.DtrCheckedTitle)
        WriteSignatoryBlock(sheet, labelRow, nameRow, titleRow, notedColumn, lastColumn, "Noted by:", settings.DtrNotedName, settings.DtrNotedTitle)
        Return titleRow
    End Function

    Private Sub WriteSignatoryBlock(
        sheet As IXLWorksheet,
        labelRow As Integer,
        nameRow As Integer,
        titleRow As Integer,
        firstColumn As Integer,
        lastColumn As Integer,
        label As String,
        name As String,
        title As String
    )
        sheet.Range(labelRow, firstColumn, labelRow, lastColumn).Merge()
        sheet.Cell(labelRow, firstColumn).Value = label
        sheet.Range(nameRow, firstColumn, nameRow, lastColumn).Merge()
        sheet.Cell(nameRow, firstColumn).Value = name
        sheet.Cell(nameRow, firstColumn).Style.Font.Bold = True
        sheet.Range(titleRow, firstColumn, titleRow, lastColumn).Merge()
        sheet.Cell(titleRow, firstColumn).Value = title
    End Sub

    Private Sub StyleDtrSheet(
        sheet As IXLWorksheet,
        lastColumn As Integer,
        dataStartRow As Integer,
        totalRow As Integer,
        lastPrintRow As Integer
    )
        With sheet.Range(12, 1, 13, lastColumn).Style
            .Font.Bold = True
            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            .Alignment.Vertical = XLAlignmentVerticalValues.Center
            .Alignment.WrapText = True
            .Fill.BackgroundColor = LightTeal
            .Border.TopBorder = XLBorderStyleValues.Thin
            .Border.BottomBorder = XLBorderStyleValues.Thin
            .Border.LeftBorder = XLBorderStyleValues.Thin
            .Border.RightBorder = XLBorderStyleValues.Thin
        End With
        For column As Integer = 2 To lastColumn - 1
            If Convert.ToString(sheet.Cell(12, column).Value).Trim().Equals("Sun", StringComparison.OrdinalIgnoreCase) Then
                sheet.Cell(12, column).Style.Fill.BackgroundColor = XLColor.LightGreen
            End If
        Next
        Dim dataRange = sheet.Range(dataStartRow, 1, totalRow, lastColumn)
        dataRange.Style.Border.TopBorder = XLBorderStyleValues.Thin
        dataRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin
        dataRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin
        dataRange.Style.Border.RightBorder = XLBorderStyleValues.Thin
        sheet.Range(dataStartRow, 2, totalRow, lastColumn).Style.NumberFormat.Format = QuantityFormat
        sheet.Column(1).Width = 30
        For column As Integer = 2 To lastColumn - 1
            sheet.Column(column).Width = 8
        Next
        sheet.Column(lastColumn).Width = 16
        sheet.SheetView.FreezeRows(13)
        sheet.PageSetup.PageOrientation = XLPageOrientation.Landscape
        sheet.PageSetup.PaperSize = XLPaperSize.A4Paper
        sheet.PageSetup.FitToPages(1, 0)
        sheet.PageSetup.SetRowsToRepeatAtTop(1, 13)
        sheet.PageSetup.PrintAreas.Add(1, 1, lastPrintRow, lastColumn)
        sheet.PageSetup.Margins.Left = 0.25
        sheet.PageSetup.Margins.Right = 0.25
    End Sub

    Private Sub WriteCompanyHeader(sheet As IXLWorksheet, lastColumn As Integer, settings As PayrollReportSettings)
        sheet.Range(2, 1, 2, lastColumn).Merge()
        sheet.Cell(2, 1).Value = settings.CompanyName
        sheet.Cell(2, 1).Style.Font.Bold = True
        sheet.Cell(2, 1).Style.Font.FontSize = 18
        sheet.Cell(2, 1).Style.Font.FontColor = Maroon
        sheet.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        sheet.Range(3, 1, 3, lastColumn).Merge()
        sheet.Cell(3, 1).Value = settings.CompanyAddress
        sheet.Range(4, 1, 4, lastColumn).Merge()
        sheet.Cell(4, 1).Value = If(String.IsNullOrWhiteSpace(settings.CompanyPhone), "", "Tel. " & settings.CompanyPhone)
        sheet.Range(5, 1, 5, lastColumn).Merge()
        sheet.Cell(5, 1).Value = If(String.IsNullOrWhiteSpace(settings.CompanyEmail), "", "Email: " & settings.CompanyEmail)
        sheet.Range(3, 1, 5, lastColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        sheet.Range(3, 1, 5, lastColumn).Style.Font.Italic = True
    End Sub

    Private Sub AddCompanyLogos(workbook As XLWorkbook, settings As PayrollReportSettings)
        ' Add images only after widths and optional hidden columns are final.
        ' Each merged company-name heading identifies its own logo/text block,
        ' including the right-hand payslip and every subsequent printed page.
        For Each sheet In workbook.Worksheets
            Dim isPayslip = sheet.Name = "PAYSLIP"
            For Each header In sheet.MergedRanges.Where(
                Function(range) String.Equals(range.FirstCell().GetString(), settings.CompanyName, StringComparison.Ordinal)).ToList()
                Dim address = header.RangeAddress.FirstAddress
                If isPayslip Then
                    If (address.ColumnNumber <> 2 AndAlso address.ColumnNumber <> 10) OrElse (address.RowNumber - 1) Mod 25 <> 0 Then Continue For
                ElseIf address.RowNumber <> 2 OrElse address.ColumnNumber <> 1 Then
                    Continue For
                End If
                Dim isPayrollReportHeader = sheet.Name = "PAYROLL SHEET" OrElse sheet.Name = "CLASSIFICATION DETAIL" OrElse sheet.Name = "DTR_Hours"
                TryAddCompanyLogo(sheet, header, If(isPayslip, 2, 4), If(isPayslip, 48, If(isPayrollReportHeader, 96, 56)))
            Next
        Next
    End Sub

    Private Sub TryAddCompanyLogo(
        sheet As IXLWorksheet,
        companyHeading As IXLRange,
        headerRowCount As Integer,
        maximumSize As Integer
    )
        If sheet Is Nothing Then Return
        Dim logoPath = Path.Combine(Application.StartupPath, "Resources", "DeltaMaroon_NoBg.png")
        If String.IsNullOrWhiteSpace(logoPath) OrElse Not File.Exists(logoPath) Then Return

        Dim picture As ClosedXML.Excel.Drawings.IXLPicture = Nothing
        Try
            Using bitmap As New Bitmap(1, 1)
                ' Excel drawing offsets use 96-DPI pixels, regardless of the
                ' workstation's display scaling or the printer selected.
                bitmap.SetResolution(96, 96)
                Using drawingGraphics = Graphics.FromImage(bitmap)
                    Dim normalFont = sheet.Workbook.Style.Font
                    Dim digitWidth As Integer
                    Using font As New Font(normalFont.FontName, CSng(normalFont.FontSize))
                        digitWidth = CInt(Math.Round(drawingGraphics.MeasureString("0", font, PointF.Empty, StringFormat.GenericTypographic).Width))
                    End Using
                    Dim firstRow = companyHeading.RangeAddress.FirstAddress.RowNumber
                    Dim firstColumn = companyHeading.RangeAddress.FirstAddress.ColumnNumber
                    Dim lastColumn = companyHeading.RangeAddress.LastAddress.ColumnNumber
                    Dim headerWidth = Enumerable.Range(firstColumn, lastColumn - firstColumn + 1).
                        Sum(Function(column) VisibleColumnPixels(sheet, column, digitWidth))
                    Dim textWidth As Double = 0
                    Dim headerHeight As Double = 0
                    For rowNumber = firstRow To firstRow + headerRowCount - 1
                        Dim cell = sheet.Cell(rowNumber, firstColumn)
                        Dim style = cell.Style.Font
                        Dim selectedFontStyle = If(style.Bold, FontStyle.Bold, FontStyle.Regular) Or If(style.Italic, FontStyle.Italic, FontStyle.Regular)
                        Using font As New Font(style.FontName, CSng(style.FontSize), selectedFontStyle)
                            Dim lineWidth = drawingGraphics.MeasureString(cell.GetString(), font, PointF.Empty, StringFormat.GenericTypographic).Width
                            If cell.Style.Alignment.WrapText Then lineWidth = Math.Min(lineWidth, Math.Max(1, headerWidth - 4))
                            textWidth = Math.Max(textWidth, lineWidth)
                        End Using
                        headerHeight += sheet.Row(rowNumber).Height * 96.0 / 72.0
                    Next

                    picture = sheet.AddPicture(logoPath)
                    Dim scale = Math.Min(maximumSize / CDbl(picture.OriginalWidth), maximumSize / CDbl(picture.OriginalHeight))
                    picture.WithPlacement(ClosedXML.Excel.Drawings.XLPicturePlacement.Move)
                    picture.Scale(scale)
                    Dim gap = If(headerRowCount = 2, 4, 8)
                    Dim anchorColumn = If(headerRowCount = 2, firstColumn - 1, firstColumn)
                    Dim reservedWidth = If(headerRowCount = 2, VisibleColumnPixels(sheet, anchorColumn, digitWidth), 0)
                    Dim leftAdjustment = If(headerRowCount = 2, 8, If(sheet.Name = "PAYROLL SHEET" OrElse sheet.Name = "CLASSIFICATION DETAIL" OrElse sheet.Name = "DTR_Hours", 24, 0))
                    Dim offsetX = Math.Max(4, reservedWidth + CInt(Math.Floor((headerWidth - textWidth) / 2)) - picture.Width - gap - leftAdjustment)
                    Dim offsetY = Math.Max(0, CInt(Math.Round((headerHeight - picture.Height) / 2)))
                    Dim pictureRow = firstRow
                    If headerRowCount = 4 AndAlso picture.Height > headerHeight Then
                        pictureRow = firstRow - 1
                        Dim availableHeight = sheet.Row(pictureRow).Height * 96.0 / 72.0 + headerHeight
                        offsetY = CInt(Math.Max(0, Math.Round(availableHeight - picture.Height)))
                    End If
                    While anchorColumn < lastColumn
                        Dim columnWidth = VisibleColumnPixels(sheet, anchorColumn, digitWidth)
                        If columnWidth > offsetX Then Exit While
                        offsetX -= columnWidth
                        anchorColumn += 1
                    End While
                    picture.MoveTo(sheet.Cell(pictureRow, anchorColumn), offsetX, offsetY)
                End Using
            End Using
        Catch
            If picture IsNot Nothing Then picture.Delete()
            ' A missing or invalid optional logo must not prevent payroll export.
        End Try
    End Sub

    Private Function VisibleColumnPixels(sheet As IXLWorksheet, columnNumber As Integer, digitWidth As Integer) As Integer
        Dim column = sheet.Column(columnNumber)
        If column.IsHidden Then Return 0
        Return CInt(Math.Floor(column.Width * digitWidth + 0.5)) + 5
    End Function

    Private Sub StyleTotalRow(range As IXLRange)
        range.Style.Font.Bold = True
        range.Style.Fill.BackgroundColor = LightOrange
        range.Style.Border.TopBorder = XLBorderStyleValues.Medium
        range.Style.Border.BottomBorder = XLBorderStyleValues.Medium
    End Sub

    Private Function ConvertCutoffToReadable(input As String) As String
        If String.IsNullOrWhiteSpace(input) Then Return ""
        Dim parts = input.Split("_"c)
        If parts.Length <> 3 Then Return input

        Dim monthNumber As Integer
        Dim yearNumber As Integer
        If Not Integer.TryParse(parts(0), monthNumber) OrElse Not Integer.TryParse(parts(2), yearNumber) Then Return input
        If monthNumber < 1 OrElse monthNumber > 12 Then Return input

        Dim startDay = If(parts(1).Equals("1st", StringComparison.OrdinalIgnoreCase), 1, 16)
        Dim endDay = If(startDay = 1, 15, Date.DaysInMonth(yearNumber, monthNumber))
        Return $"{startDay}-{endDay} {New Date(yearNumber, monthNumber, 1):MMMM yyyy}".ToUpperInvariant()
    End Function

    Private Function ReadText(row As DataGridViewRow, columnName As String) As String
        Try
            Return Convert.ToString(row.Cells(columnName).Value).Trim()
        Catch
            Return ""
        End Try
    End Function

    Private Function ReadDecimal(row As DataGridViewRow, columnName As String) As Decimal
        Try
            Return ParseDecimal(row.Cells(columnName).Value)
        Catch
            Return 0D
        End Try
    End Function

    Private Function ParseDecimal(value As Object) As Decimal
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0D
        Dim text = Convert.ToString(value).Trim().Replace(",", "")
        Dim result As Decimal
        If Decimal.TryParse(text, NumberStyles.Number Or NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, result) Then Return result
        If Decimal.TryParse(text, NumberStyles.Number Or NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, result) Then Return result
        Return 0D
    End Function

    Private Function ColumnLetter(columnNumber As Integer) As String
        Dim dividend = columnNumber
        Dim name As String = ""
        While dividend > 0
            Dim moduloValue = (dividend - 1) Mod 26
            name = Chr(65 + moduloValue) & name
            dividend = (dividend - moduloValue) \ 26
        End While
        Return name
    End Function
End Module
