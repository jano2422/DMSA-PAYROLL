Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports iText.Kernel.Pdf
Imports iText.Kernel.Pdf.Canvas.Parser
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Media

Public Class FRM_DTR_BIOMETRIC_WPF_UC
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub BtnUploadDTR_Click(sender As Object, e As RoutedEventArgs)
        Dim extractedRecords As New DataTable()
        Dim filePath As String = "C:/MASTER_DTR/4011.pdf"
        If Not File.Exists(filePath) Then
            AppNotification.ShowWpf("File not found: " & filePath, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
            Return
        End If
        extractedRecords = ExtractDTRDataFromPDF(filePath)
    End Sub

    Private Function ExtractDTRDataFromPDF(filePath As String) As DataTable
        Dim extractedRecords As New DataTable()
        extractedRecords.Columns.Add("DateTime", GetType(DateTime)) ' Ensure column is created

        Using pdfReader As New PdfReader(filePath)
            Using pdfDocument As New PdfDocument(pdfReader)
                For i As Integer = 1 To pdfDocument.GetNumberOfPages()
                    Dim page As PdfPage = pdfDocument.GetPage(i)
                    Dim text As String = PdfTextExtractor.GetTextFromPage(page)

                    ' Extract records from current page
                    Dim pageRecords As DataTable = ParseTextToDTRRecords(text)

                    ' Append records to main DataTable
                    For Each row As DataRow In pageRecords.Rows
                        extractedRecords.ImportRow(row)
                    Next
                Next
            End Using
        End Using

        Return extractedRecords
    End Function

    Private Function ParseTextToDTRRecords(text As String) As DataTable
        Dim dataTable As New DataTable()
        dataTable.Columns.Add("DateTime", GetType(DateTime)) ' Ensure single column exists

        Dim lines As String() = text.Split(New String() {vbLf}, StringSplitOptions.RemoveEmptyEntries)

        ' Keep the date pattern the same
        Dim datePattern As String = "(\d{2}/\d{2}/\d{4})\s+\w+\s+"

        ' Modify the time pattern to be case-insensitive
        Dim timePattern As String = "(?i)(\d{1,2}:\d{2} (?:AM|PM))"

        Dim currentDate As DateTime = Nothing

        For Each line As String In lines
            Dim dateMatch As Match = Regex.Match(line, datePattern)
            If dateMatch.Success Then
                currentDate = DateTime.ParseExact(dateMatch.Groups(1).Value, "MM/dd/yyyy", Nothing)
            End If

            Dim timeMatches As MatchCollection = Regex.Matches(line, timePattern)
            If timeMatches.Count > 0 AndAlso currentDate <> Nothing Then
                For Each timeMatch As Match In timeMatches
                    Dim parsedTime As DateTime = DateTime.ParseExact(timeMatch.Value, "h:mm tt", Nothing)
                    Dim fullDateTime As New DateTime(currentDate.Year, currentDate.Month, currentDate.Day, parsedTime.Hour, parsedTime.Minute, 0)

                    ' Add raw DateTime to DataTable
                    dataTable.Rows.Add(fullDateTime)
                Next
            End If
        Next

        Return dataTable
    End Function

End Class
