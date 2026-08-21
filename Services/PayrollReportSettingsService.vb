Imports System.Globalization
Imports System.IO
Imports System.Xml

Public Class PayrollReportSettings
    Public Property CompanyName As String
    Public Property CompanyAddress As String
    Public Property CompanyPhone As String
    Public Property CompanyEmail As String
    Public Property PayrollPreparedName As String
    Public Property PayrollPreparedTitle As String
    Public Property PayrollApprovedName As String
    Public Property PayrollApprovedTitle As String
    Public Property DtrPreparedName As String
    Public Property DtrPreparedTitle As String
    Public Property DtrCheckedName As String
    Public Property DtrCheckedTitle As String
    Public Property DtrNotedName As String
    Public Property DtrNotedTitle As String
    Public Property HoursPerDay As Decimal
    Public Property RateSemantics As String
    Public Property SundayPremium As Decimal
    Public Property SpecialHolidayPremium As Decimal
    Public Property LegalHolidayPremium As Decimal
    Public Property OvertimeHourlyRate As Decimal
    Public Property ServiceIncentiveDays As Decimal
    Public Property IncentiveMonthsDivisor As Decimal
    Public Property IncentiveDaysDivisor As Decimal

    Public Shared Function CreateDefault() As PayrollReportSettings
        Return New PayrollReportSettings With {
            .CompanyName = "DELTA MAROON SECURITY AGENCY CORP.",
            .CompanyAddress = "Blk 9 Lot 16 Jasmin St. Rodriguez Village, Lawa, Calamba City, Laguna",
            .CompanyPhone = "(049) 834-3812 / 0917-5080368",
            .CompanyEmail = "deltamaroonscty@yahoo.com",
            .PayrollPreparedName = "Melanie M. Ros",
            .PayrollPreparedTitle = "Finance Staff",
            .PayrollApprovedName = "Liza S. Castillo",
            .PayrollApprovedTitle = "Security Director",
            .DtrPreparedName = "Kristine Terrenal",
            .DtrPreparedTitle = "Accounting Staff",
            .DtrCheckedName = "Melanie M. Ros",
            .DtrCheckedTitle = "Finance Officer",
            .DtrNotedName = "Liza S. Castillo",
            .DtrNotedTitle = "Security Director",
            .HoursPerDay = 8D,
            .RateSemantics = PayrollReportSettingsService.PremiumRateSemantics,
            .SundayPremium = 0.3D,
            .SpecialHolidayPremium = 0.3D,
            .LegalHolidayPremium = 1D,
            .OvertimeHourlyRate = 2500D / 2D / 15D / 4D,
            .ServiceIncentiveDays = 5D,
            .IncentiveMonthsDivisor = 12D,
            .IncentiveDaysDivisor = 365D
        }
    End Function

    Public Sub Validate()
        If String.IsNullOrWhiteSpace(CompanyName) Then Throw New InvalidDataException("Company name is required.")
        If String.IsNullOrWhiteSpace(PayrollPreparedName) Then Throw New InvalidDataException("Payroll prepared-by name is required.")
        If String.IsNullOrWhiteSpace(PayrollApprovedName) Then Throw New InvalidDataException("Payroll approved-by name is required.")
        If String.IsNullOrWhiteSpace(DtrPreparedName) Then Throw New InvalidDataException("DTR prepared-by name is required.")
        If String.IsNullOrWhiteSpace(DtrCheckedName) Then Throw New InvalidDataException("DTR checked-by name is required.")
        If String.IsNullOrWhiteSpace(DtrNotedName) Then Throw New InvalidDataException("DTR noted-by name is required.")
        If HoursPerDay <= 0D Then Throw New InvalidDataException("Hours per day must be greater than zero.")
        If SundayPremium < 0D Then Throw New InvalidDataException("Sunday additional premium cannot be negative.")
        If SpecialHolidayPremium < 0D Then Throw New InvalidDataException("Special-holiday additional premium cannot be negative.")
        If LegalHolidayPremium < 0D Then Throw New InvalidDataException("Legal-holiday additional premium cannot be negative.")
        If OvertimeHourlyRate < 0D Then Throw New InvalidDataException("Overtime hourly rate cannot be negative.")
        If ServiceIncentiveDays < 0D Then Throw New InvalidDataException("Service incentive days cannot be negative.")
        If IncentiveMonthsDivisor <= 0D Then Throw New InvalidDataException("Incentive month divisor must be greater than zero.")
        If IncentiveDaysDivisor <= 0D Then Throw New InvalidDataException("Incentive day divisor must be greater than zero.")
    End Sub
End Class

Public Module PayrollReportSettingsService
    Private Const SettingsFileName As String = "PayrollReportSettings.xml"
    Public Const PremiumRateSemantics As String = "ADDITIONAL_PREMIUM_V1"

    Public ReadOnly Property SettingsPath As String
        Get
            Return Path.Combine(Application.StartupPath, "Configuration", SettingsFileName)
        End Get
    End Property

    Public Function LoadSettings() As PayrollReportSettings
        Dim settings = PayrollReportSettings.CreateDefault()
        If Not File.Exists(SettingsPath) Then Return settings

        Dim document As New XmlDocument()
        document.Load(SettingsPath)
        Dim root = document.SelectSingleNode("/PayrollReportSettings")
        If root Is Nothing Then
            Throw New InvalidDataException("The payroll report settings file has no PayrollReportSettings root element.")
        End If

        settings.CompanyName = ReadText(root, "CompanyName", settings.CompanyName)
        settings.CompanyAddress = ReadText(root, "CompanyAddress", settings.CompanyAddress)
        settings.CompanyPhone = ReadText(root, "CompanyPhone", settings.CompanyPhone)
        settings.CompanyEmail = ReadText(root, "CompanyEmail", settings.CompanyEmail)
        settings.PayrollPreparedName = ReadText(root, "PayrollPreparedName", settings.PayrollPreparedName)
        settings.PayrollPreparedTitle = ReadText(root, "PayrollPreparedTitle", settings.PayrollPreparedTitle)
        settings.PayrollApprovedName = ReadText(root, "PayrollApprovedName", settings.PayrollApprovedName)
        settings.PayrollApprovedTitle = ReadText(root, "PayrollApprovedTitle", settings.PayrollApprovedTitle)
        settings.DtrPreparedName = ReadText(root, "DtrPreparedName", settings.DtrPreparedName)
        settings.DtrPreparedTitle = ReadText(root, "DtrPreparedTitle", settings.DtrPreparedTitle)
        settings.DtrCheckedName = ReadText(root, "DtrCheckedName", settings.DtrCheckedName)
        settings.DtrCheckedTitle = ReadText(root, "DtrCheckedTitle", settings.DtrCheckedTitle)
        settings.DtrNotedName = ReadText(root, "DtrNotedName", settings.DtrNotedName)
        settings.DtrNotedTitle = ReadText(root, "DtrNotedTitle", settings.DtrNotedTitle)
        settings.HoursPerDay = ReadDecimal(root, "HoursPerDay", settings.HoursPerDay)
        Dim storedSemantics = ReadText(root, "RateSemantics", String.Empty)
        If String.Equals(storedSemantics, PremiumRateSemantics, StringComparison.OrdinalIgnoreCase) Then
            settings.SundayPremium = ReadDecimal(root, "SundayPremium", ReadDecimal(root, "SundayMultiplier", settings.SundayPremium))
            settings.SpecialHolidayPremium = ReadDecimal(root, "SpecialHolidayPremium", ReadDecimal(root, "SpecialHolidayMultiplier", settings.SpecialHolidayPremium))
            settings.LegalHolidayPremium = ReadDecimal(root, "LegalHolidayPremium", ReadDecimal(root, "LegalHolidayMultiplier", settings.LegalHolidayPremium))
        Else
            settings.SundayPremium = ConvertLegacyMultiplierToPremium(ReadDecimal(root, "SundayMultiplier", 1.3D))
            settings.SpecialHolidayPremium = ConvertLegacyMultiplierToPremium(ReadDecimal(root, "SpecialHolidayMultiplier", 1.3D))
            settings.LegalHolidayPremium = ConvertLegacyMultiplierToPremium(ReadDecimal(root, "LegalHolidayMultiplier", 2D))
        End If
        settings.RateSemantics = PremiumRateSemantics
        settings.OvertimeHourlyRate = ReadDecimal(root, "OvertimeHourlyRate", settings.OvertimeHourlyRate)
        settings.ServiceIncentiveDays = ReadDecimal(root, "ServiceIncentiveDays", settings.ServiceIncentiveDays)
        settings.IncentiveMonthsDivisor = ReadDecimal(root, "IncentiveMonthsDivisor", settings.IncentiveMonthsDivisor)
        settings.IncentiveDaysDivisor = ReadDecimal(root, "IncentiveDaysDivisor", settings.IncentiveDaysDivisor)
        settings.Validate()
        Return settings
    End Function

    Public Function LoadSettingsOrDefault() As PayrollReportSettings
        Try
            Return LoadSettings()
        Catch
            Return PayrollReportSettings.CreateDefault()
        End Try
    End Function

    Public Sub SaveSettings(settings As PayrollReportSettings)
        If settings Is Nothing Then Throw New ArgumentNullException(NameOf(settings))
        settings.Validate()

        Dim folder = Path.GetDirectoryName(SettingsPath)
        Directory.CreateDirectory(folder)

        Dim writerSettings As New XmlWriterSettings With {
            .Indent = True,
            .Encoding = New System.Text.UTF8Encoding(False)
        }

        Using writer = XmlWriter.Create(SettingsPath, writerSettings)
            writer.WriteStartDocument()
            writer.WriteStartElement("PayrollReportSettings")
            writer.WriteElementString("CompanyName", settings.CompanyName.Trim())
            writer.WriteElementString("CompanyAddress", If(settings.CompanyAddress, String.Empty).Trim())
            writer.WriteElementString("CompanyPhone", If(settings.CompanyPhone, String.Empty).Trim())
            writer.WriteElementString("CompanyEmail", If(settings.CompanyEmail, String.Empty).Trim())
            writer.WriteElementString("PayrollPreparedName", settings.PayrollPreparedName.Trim())
            writer.WriteElementString("PayrollPreparedTitle", If(settings.PayrollPreparedTitle, String.Empty).Trim())
            writer.WriteElementString("PayrollApprovedName", settings.PayrollApprovedName.Trim())
            writer.WriteElementString("PayrollApprovedTitle", If(settings.PayrollApprovedTitle, String.Empty).Trim())
            writer.WriteElementString("DtrPreparedName", settings.DtrPreparedName.Trim())
            writer.WriteElementString("DtrPreparedTitle", If(settings.DtrPreparedTitle, String.Empty).Trim())
            writer.WriteElementString("DtrCheckedName", settings.DtrCheckedName.Trim())
            writer.WriteElementString("DtrCheckedTitle", If(settings.DtrCheckedTitle, String.Empty).Trim())
            writer.WriteElementString("DtrNotedName", settings.DtrNotedName.Trim())
            writer.WriteElementString("DtrNotedTitle", If(settings.DtrNotedTitle, String.Empty).Trim())
            WriteDecimal(writer, "HoursPerDay", settings.HoursPerDay)
            writer.WriteElementString("RateSemantics", PremiumRateSemantics)
            WriteDecimal(writer, "SundayPremium", settings.SundayPremium)
            WriteDecimal(writer, "SpecialHolidayPremium", settings.SpecialHolidayPremium)
            WriteDecimal(writer, "LegalHolidayPremium", settings.LegalHolidayPremium)
            WriteDecimal(writer, "OvertimeHourlyRate", settings.OvertimeHourlyRate)
            WriteDecimal(writer, "ServiceIncentiveDays", settings.ServiceIncentiveDays)
            WriteDecimal(writer, "IncentiveMonthsDivisor", settings.IncentiveMonthsDivisor)
            WriteDecimal(writer, "IncentiveDaysDivisor", settings.IncentiveDaysDivisor)
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub

    Public Function CalculateTotalEarnings(
        settings As PayrollReportSettings,
        dailyWage As Decimal,
        totalHours As Decimal,
        regularHours As Decimal,
        sundayHours As Decimal,
        specialHolidayHours As Decimal,
        legalHolidayHours As Decimal,
        overtimeHours As Decimal,
        sgUniformAllowance As Decimal,
        officerAllowance As Decimal
    ) As Decimal
        If settings Is Nothing Then Throw New ArgumentNullException(NameOf(settings))
        settings.Validate()

        Dim hourlyRate = dailyWage / settings.HoursPerDay
        Dim basicPay = hourlyRate * regularHours
        Dim sundayPay = hourlyRate * (1D + settings.SundayPremium) * sundayHours
        Dim specialHolidayPay = hourlyRate * (1D + settings.SpecialHolidayPremium) * specialHolidayHours
        Dim legalHolidayPay = hourlyRate * (1D + settings.LegalHolidayPremium) * legalHolidayHours
        Dim overtimePay = settings.OvertimeHourlyRate * overtimeHours
        Dim incentivePay = dailyWage * settings.ServiceIncentiveDays /
            settings.IncentiveMonthsDivisor / settings.IncentiveDaysDivisor * totalHours

        Return basicPay + sundayPay + specialHolidayPay + legalHolidayPay + overtimePay +
            incentivePay + sgUniformAllowance + officerAllowance
    End Function

    Public Function ConvertLegacyMultiplierToPremium(multiplier As Decimal) As Decimal
        Return Math.Max(0D, multiplier - 1D)
    End Function

    Private Function ReadDecimal(root As XmlNode, elementName As String, defaultValue As Decimal) As Decimal
        Dim node = root.SelectSingleNode(elementName)
        If node Is Nothing OrElse String.IsNullOrWhiteSpace(node.InnerText) Then Return defaultValue

        Dim value As Decimal
        If Not Decimal.TryParse(node.InnerText.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, value) Then
            Throw New InvalidDataException("Invalid value for " & elementName & ".")
        End If
        Return value
    End Function

    Private Function ReadText(root As XmlNode, elementName As String, defaultValue As String) As String
        Dim node = root.SelectSingleNode(elementName)
        If node Is Nothing Then Return defaultValue
        Return node.InnerText.Trim()
    End Function

    Private Sub WriteDecimal(writer As XmlWriter, elementName As String, value As Decimal)
        writer.WriteElementString(elementName, value.ToString("0.########", CultureInfo.InvariantCulture))
    End Sub
End Module
