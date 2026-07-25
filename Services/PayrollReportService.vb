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
    Public Property OvertimeRegularHours As Decimal
    Public Property SgUniformAllowance As Decimal
    Public Property OfficerAllowance As Decimal
    Public Property SssDeduction As Decimal
    Public Property PhilHealthDeduction As Decimal
    Public Property PagIbigDeduction As Decimal
    Public Property CashBondDeduction As Decimal
    Public Property SssLoanDeduction As Decimal
    Public Property SssCalLoanDeduction As Decimal
    Public Property PagIbigLoanDeduction As Decimal
    Public Property PagIbigCalLoanDeduction As Decimal
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
        cutoff As String,
        payrollGrid As DataGridView,
        dtrGrid As DataGridView
    )
        Dim settings = PayrollReportSettingsService.LoadSettings()
        Dim rows = ReadPayrollRows(payrollGrid, IsFirstCutoff(cutoff))
        If rows.Count = 0 Then Throw New InvalidOperationException("There are no payroll rows to export.")

        Using workbook As New XLWorkbook()
            BuildSettingsSheet(workbook, dailyWage, settings)
            BuildPayrollSheet(workbook, detachmentName, clientAddress, cutoff, rows, IsFirstCutoff(cutoff), settings)
            BuildPayslipSheet(workbook, detachmentName, clientAddress, cutoff, rows.Count, IsFirstCutoff(cutoff), settings)
            BuildDtrHoursSheet(workbook, mainClientName, detachmentName, clientAddress, cutoff, dtrGrid, settings)
            workbook.CalculateMode = XLCalculateMode.Auto
            Try
                workbook.RecalculateAllFormulas()
            Catch
                ' Excel recalculates all formula cells when the generated workbook is opened.
            End Try
            workbook.SaveAs(outputPath)
        End Using
    End Sub

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
                .SpecialHolidayHours = ReadDecimal(row, "colSh"),
                .LegalHolidayHours = ReadDecimal(row, "colLh"),
                .NightDifferentialDays = ReadDecimal(row, "colNumNdDays"),
                .OvertimeRegularHours = ReadDecimal(row, "colOtReg"),
                .SgUniformAllowance = ReadDecimal(row, "colSgUniformAllowance"),
                .OfficerAllowance = ReadDecimal(row, "colOfficerAllo")
            }

            If firstCutoff Then
                item.SssDeduction = ReadDecimal(row, "colSss")
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

    Private Sub BuildSettingsSheet(workbook As XLWorkbook, dailyWage As Decimal, settings As PayrollReportSettings)
        Dim sheet = workbook.Worksheets.Add("SETTINGS")
        sheet.Cell("A1").Value = "Setting"
        sheet.Cell("B1").Value = "Value"
        sheet.Cell("A2").Value = "Daily wage"
        sheet.Cell("B2").Value = dailyWage
        sheet.Cell("A3").Value = "Hours per day"
        sheet.Cell("B3").Value = settings.HoursPerDay
        sheet.Cell("A4").Value = "Sunday multiplier"
        sheet.Cell("B4").Value = settings.SundayMultiplier
        sheet.Cell("A5").Value = "Special holiday multiplier"
        sheet.Cell("B5").Value = settings.SpecialHolidayMultiplier
        sheet.Cell("A6").Value = "Legal holiday multiplier"
        sheet.Cell("B6").Value = settings.LegalHolidayMultiplier
        sheet.Cell("A7").Value = "Overtime hourly rate"
        sheet.Cell("B7").Value = settings.OvertimeHourlyRate
        sheet.Cell("A8").Value = "Service incentive days"
        sheet.Cell("B8").Value = settings.ServiceIncentiveDays
        sheet.Cell("A9").Value = "Incentive month divisor"
        sheet.Cell("B9").Value = settings.IncentiveMonthsDivisor
        sheet.Cell("A10").Value = "Incentive day divisor"
        sheet.Cell("B10").Value = settings.IncentiveDaysDivisor
        Dim reportSettings = New KeyValuePair(Of String, String)() {
            New KeyValuePair(Of String, String)("Company name", settings.CompanyName),
            New KeyValuePair(Of String, String)("Company address", settings.CompanyAddress),
            New KeyValuePair(Of String, String)("Company phone", settings.CompanyPhone),
            New KeyValuePair(Of String, String)("Company email", settings.CompanyEmail),
            New KeyValuePair(Of String, String)("Payroll prepared by", settings.PayrollPreparedName),
            New KeyValuePair(Of String, String)("Payroll prepared title", settings.PayrollPreparedTitle),
            New KeyValuePair(Of String, String)("Payroll approved by", settings.PayrollApprovedName),
            New KeyValuePair(Of String, String)("Payroll approved title", settings.PayrollApprovedTitle),
            New KeyValuePair(Of String, String)("DTR prepared by", settings.DtrPreparedName),
            New KeyValuePair(Of String, String)("DTR prepared title", settings.DtrPreparedTitle),
            New KeyValuePair(Of String, String)("DTR checked by", settings.DtrCheckedName),
            New KeyValuePair(Of String, String)("DTR checked title", settings.DtrCheckedTitle),
            New KeyValuePair(Of String, String)("DTR noted by", settings.DtrNotedName),
            New KeyValuePair(Of String, String)("DTR noted title", settings.DtrNotedTitle)
        }
        For index As Integer = 0 To reportSettings.Length - 1
            sheet.Cell(12 + index, 1).Value = reportSettings(index).Key
            sheet.Cell(12 + index, 2).Value = reportSettings(index).Value
        Next
        sheet.Range("A1:B1").Style.Font.Bold = True
        sheet.Range("A1:B1").Style.Fill.BackgroundColor = Teal
        sheet.Range("A1:B1").Style.Font.FontColor = XLColor.White
        sheet.Column(1).Width = 31
        sheet.Column(2).Width = 72
        sheet.Range("B2:B10").Style.NumberFormat.Format = "0.######"
        sheet.Visibility = XLWorksheetVisibility.VeryHidden
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
        Dim lastColumn As Integer = If(firstCutoff, 26, 28)
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
            sheet.Range(12, 21, 12, 23).Merge()
            sheet.Cell(12, 21).Value = "DEDUCTIONS"
            sheet.Cell(13, 21).Value = "SSS"
            sheet.Cell(13, 22).Value = "PH"
            sheet.Cell(13, 23).Value = "PI"
            WriteMergedHeader(sheet, 24, "TOTAL DEDUCTIONS")
            WriteMergedHeader(sheet, 25, "NET AMOUNT PAID")
            WriteMergedHeader(sheet, 26, "SIGNATURE")
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

        Dim lastColumn = If(firstCutoff, 26, 28)
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
        sheet.Cell(rowNumber, 13).FormulaA1 = $"'SETTINGS'!$B$2/'SETTINGS'!$B$3*'SETTINGS'!$B$4*E{rowNumber}"
        sheet.Cell(rowNumber, 14).FormulaA1 = $"'SETTINGS'!$B$2/'SETTINGS'!$B$3*'SETTINGS'!$B$6*H{rowNumber}"
        sheet.Cell(rowNumber, 15).FormulaA1 = $"'SETTINGS'!$B$2/'SETTINGS'!$B$3*'SETTINGS'!$B$5*I{rowNumber}"
        sheet.Cell(rowNumber, 16).FormulaA1 = $"'SETTINGS'!$B$7*K{rowNumber}"
        sheet.Cell(rowNumber, 17).FormulaA1 = $"'SETTINGS'!$B$2*'SETTINGS'!$B$8/'SETTINGS'!$B$9/'SETTINGS'!$B$10*C{rowNumber}"
        sheet.Cell(rowNumber, 20).FormulaA1 = $"SUM(L{rowNumber}:S{rowNumber})"

        If firstCutoff Then
            sheet.Cell(rowNumber, 21).Value = item.SssDeduction
            sheet.Cell(rowNumber, 22).Value = item.PhilHealthDeduction
            sheet.Cell(rowNumber, 23).Value = item.PagIbigDeduction
            sheet.Cell(rowNumber, 24).FormulaA1 = $"SUM(U{rowNumber}:W{rowNumber})"
            sheet.Cell(rowNumber, 25).FormulaA1 = $"T{rowNumber}-X{rowNumber}"
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
        Const blockHeight As Integer = 22
        Const slipsPerRow As Integer = 2
        Const pairRowsPerPrintedPage As Integer = 4

        For index As Integer = 0 To employeeCount - 1
            Dim pairRowIndex = index \ slipsPerRow
            Dim startRow = 1 + pairRowIndex * blockHeight
            Dim startColumn = If(index Mod slipsPerRow = 0, 1, 9)
            Dim payrollRow = 15 + index
            WritePayslipBlock(sheet, startRow, startColumn, payrollRow, clientName, clientAddress, cutoff, firstCutoff, settings)
        Next

        Dim compactWidths = New Double() {12.5, 3.5, 5, 7.5, 11, 3.5, 7.5}
        For offset As Integer = 0 To compactWidths.Length - 1
            sheet.Column(1 + offset).Width = compactWidths(offset)
            sheet.Column(9 + offset).Width = compactWidths(offset)
        Next
        sheet.Column(8).Width = 1.2
        sheet.ShowGridLines = False
        sheet.PageSetup.PageOrientation = XLPageOrientation.Portrait
        sheet.PageSetup.PaperSize = XLPaperSize.A4Paper
        sheet.PageSetup.FitToPages(1, 0)
        Dim pairCount = CInt(Math.Ceiling(employeeCount / CDbl(slipsPerRow)))
        sheet.PageSetup.PrintAreas.Add(1, 1, pairCount * blockHeight, 15)
        For pairRowIndex As Integer = pairRowsPerPrintedPage To pairCount - 1 Step pairRowsPerPrintedPage
            sheet.PageSetup.AddHorizontalPageBreak(1 + pairRowIndex * blockHeight)
        Next
        sheet.PageSetup.Margins.Left = 0.2
        sheet.PageSetup.Margins.Right = 0.2
        sheet.PageSetup.Margins.Top = 0.2
        sheet.PageSetup.Margins.Bottom = 0.2
        sheet.PageSetup.CenterHorizontally = True
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
        Dim endRow = startRow + 20
        Dim typeColumn = startColumn
        Dim valueStartColumn = startColumn + 1
        Dim hoursColumn = startColumn + 2
        Dim amountColumn = startColumn + 3
        Dim deductionTypeColumn = startColumn + 4
        Dim deductionValueStartColumn = startColumn + 5
        Dim deductionAmountColumn = startColumn + 6

        sheet.Range(startRow, startColumn, startRow, deductionAmountColumn).Merge()
        sheet.Cell(startRow, startColumn).Value = settings.CompanyName
        sheet.Cell(startRow, startColumn).Style.Font.Bold = True
        sheet.Cell(startRow, startColumn).Style.Font.FontSize = 8
        sheet.Cell(startRow, startColumn).Style.Font.FontColor = Maroon
        sheet.Cell(startRow, startColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        sheet.Range(startRow + 1, startColumn, startRow + 1, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 1, startColumn).Value = settings.CompanyAddress
        sheet.Cell(startRow + 1, startColumn).Style.Font.FontSize = 5.5
        sheet.Cell(startRow + 1, startColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        TryAddCompanyLogo(sheet, startRow, startColumn, 24, 24)

        sheet.Cell(startRow + 2, typeColumn).Value = "Detachment:"
        sheet.Range(startRow + 2, valueStartColumn, startRow + 2, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 2, valueStartColumn).Value = clientName
        sheet.Cell(startRow + 3, typeColumn).Value = "Address:"
        sheet.Range(startRow + 3, valueStartColumn, startRow + 3, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 3, valueStartColumn).Value = clientAddress
        sheet.Cell(startRow + 4, typeColumn).Value = "Name:"
        sheet.Range(startRow + 4, valueStartColumn, startRow + 4, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 4, valueStartColumn).FormulaA1 = $"'PAYROLL'!A{payrollRow}"
        sheet.Cell(startRow + 5, typeColumn).Value = "Period Covered:"
        sheet.Range(startRow + 5, valueStartColumn, startRow + 5, deductionAmountColumn).Merge()
        sheet.Cell(startRow + 5, valueStartColumn).Value = ConvertCutoffToReadable(cutoff)
        sheet.Cell(startRow + 6, typeColumn).Value = "Total Number of Days"
        sheet.Cell(startRow + 6, hoursColumn).FormulaA1 = $"'PAYROLL'!B{payrollRow}"
        sheet.Cell(startRow + 6, deductionTypeColumn).Value = "Total Number of Hrs."
        sheet.Cell(startRow + 6, deductionAmountColumn).FormulaA1 = $"'PAYROLL'!C{payrollRow}"

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

        Dim earningLabels = New String() {"Daily Wage", "Basic Pay", "Sunday", "Special Holiday", "Legal Holiday", "OT Regular Day", "Incentive Pay", "SG Uniform Allowance", "Officer's Allowance"}
        For offset As Integer = 0 To earningLabels.Length - 1
            sheet.Cell(startRow + 9 + offset, typeColumn).Value = earningLabels(offset)
        Next
        sheet.Cell(startRow + 9, amountColumn).FormulaA1 = "'SETTINGS'!$B$2"
        sheet.Cell(startRow + 10, hoursColumn).FormulaA1 = $"'PAYROLL'!D{payrollRow}"
        sheet.Cell(startRow + 10, amountColumn).FormulaA1 = $"'PAYROLL'!L{payrollRow}"
        sheet.Cell(startRow + 11, hoursColumn).FormulaA1 = $"'PAYROLL'!E{payrollRow}"
        sheet.Cell(startRow + 11, amountColumn).FormulaA1 = $"'PAYROLL'!M{payrollRow}"
        sheet.Cell(startRow + 12, hoursColumn).FormulaA1 = $"'PAYROLL'!I{payrollRow}"
        sheet.Cell(startRow + 12, amountColumn).FormulaA1 = $"'PAYROLL'!O{payrollRow}"
        sheet.Cell(startRow + 13, hoursColumn).FormulaA1 = $"'PAYROLL'!H{payrollRow}"
        sheet.Cell(startRow + 13, amountColumn).FormulaA1 = $"'PAYROLL'!N{payrollRow}"
        sheet.Cell(startRow + 14, hoursColumn).FormulaA1 = $"'PAYROLL'!K{payrollRow}"
        sheet.Cell(startRow + 14, amountColumn).FormulaA1 = $"'PAYROLL'!P{payrollRow}"
        sheet.Cell(startRow + 15, amountColumn).FormulaA1 = $"'PAYROLL'!Q{payrollRow}"
        sheet.Cell(startRow + 16, amountColumn).FormulaA1 = $"'PAYROLL'!R{payrollRow}"
        sheet.Cell(startRow + 17, amountColumn).FormulaA1 = $"'PAYROLL'!S{payrollRow}"

        If firstCutoff Then
            WritePayslipDeduction(sheet, startRow + 9, startColumn, "SSS", $"'PAYROLL'!U{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 10, startColumn, "PhilHealth", $"'PAYROLL'!V{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 11, startColumn, "Pag-IBIG", $"'PAYROLL'!W{payrollRow}")
        Else
            WritePayslipDeduction(sheet, startRow + 9, startColumn, "Cash Bond", $"'PAYROLL'!U{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 10, startColumn, "SSS Loan", $"'PAYROLL'!V{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 11, startColumn, "SSS Cal Loan", $"'PAYROLL'!W{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 12, startColumn, "Pag-IBIG Loan", $"'PAYROLL'!X{payrollRow}")
            WritePayslipDeduction(sheet, startRow + 13, startColumn, "Pag-IBIG Cal Loan", $"'PAYROLL'!Y{payrollRow}")
        End If

        Dim totalDeductionColumn = If(firstCutoff, "X", "Z")
        Dim netColumn = If(firstCutoff, "Y", "AA")
        sheet.Cell(startRow + 18, typeColumn).Value = "TOTAL EARNINGS"
        sheet.Range(startRow + 18, typeColumn, startRow + 18, hoursColumn).Merge()
        sheet.Cell(startRow + 18, amountColumn).FormulaA1 = $"'PAYROLL'!T{payrollRow}"
        sheet.Cell(startRow + 18, deductionTypeColumn).Value = "TOTAL DEDUCTIONS"
        sheet.Range(startRow + 18, deductionTypeColumn, startRow + 18, deductionValueStartColumn).Merge()
        sheet.Cell(startRow + 18, deductionAmountColumn).FormulaA1 = $"'PAYROLL'!{totalDeductionColumn}{payrollRow}"
        sheet.Range(startRow + 19, typeColumn, startRow + 19, deductionValueStartColumn).Merge()
        sheet.Cell(startRow + 19, typeColumn).Value = "**** NET PAY ****"
        sheet.Cell(startRow + 19, typeColumn).Style.Font.Bold = True
        sheet.Cell(startRow + 19, typeColumn).Style.Font.Italic = True
        sheet.Cell(startRow + 19, typeColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        sheet.Cell(startRow + 19, deductionAmountColumn).FormulaA1 = $"'PAYROLL'!{netColumn}{payrollRow}"

        Dim blockRange = sheet.Range(startRow, startColumn, endRow - 1, deductionAmountColumn)
        blockRange.Style.Border.TopBorder = XLBorderStyleValues.Thin
        blockRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin
        blockRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin
        blockRange.Style.Border.RightBorder = XLBorderStyleValues.Thin
        blockRange.Style.Font.FontSize = 6.5
        blockRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        sheet.Range(startRow + 9, hoursColumn, startRow + 17, hoursColumn).Style.NumberFormat.Format = QuantityFormat
        sheet.Range(startRow + 9, amountColumn, startRow + 19, amountColumn).Style.NumberFormat.Format = MoneyFormat
        sheet.Range(startRow + 9, deductionAmountColumn, startRow + 19, deductionAmountColumn).Style.NumberFormat.Format = MoneyFormat
        StyleTotalRow(sheet.Range(startRow + 18, startColumn, startRow + 19, deductionAmountColumn))
        sheet.Row(startRow).Height = 14
        sheet.Row(startRow + 1).Height = 9
        For rowNumber As Integer = startRow + 2 To startRow + 19
            sheet.Row(rowNumber).Height = 10
        Next
        sheet.Row(startRow + 18).Height = 12
        sheet.Row(startRow + 19).Height = 12
        sheet.Row(startRow + 20).Height = 5
        sheet.Row(startRow + 21).Height = 5
    End Sub

    Private Sub WritePayslipDeduction(sheet As IXLWorksheet, row As Integer, startColumn As Integer, label As String, formula As String)
        sheet.Cell(row, startColumn + 4).Value = label
        sheet.Cell(row, startColumn + 6).FormulaA1 = formula
    End Sub

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
        TryAddCompanyLogo(sheet, 2, 1, 56, 56)
    End Sub

    Private Sub TryAddCompanyLogo(
        sheet As IXLWorksheet,
        anchorRow As Integer,
        anchorColumn As Integer,
        maximumWidth As Integer,
        maximumHeight As Integer
    )
        If sheet Is Nothing Then Return
        Dim logoPath = Path.Combine(Application.StartupPath, "Resources", "DeltaMaroon_NoBg.png")
        If String.IsNullOrWhiteSpace(logoPath) OrElse Not File.Exists(logoPath) Then Return

        Try
            Dim picture = sheet.AddPicture(logoPath)
            Dim scale = Math.Min(maximumWidth / CDbl(picture.OriginalWidth), maximumHeight / CDbl(picture.OriginalHeight))
            picture.WithPlacement(ClosedXML.Excel.Drawings.XLPicturePlacement.FreeFloating)
            picture.Scale(scale).MoveTo(sheet.Cell(anchorRow, anchorColumn))
        Catch
            ' A missing or invalid optional logo must not prevent payroll export.
        End Try
    End Sub

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
