Imports System.IO

Public Class FileSelectionControl
    Public Property SelectedFile As String
    Public Property SelectedDirectory As String

    Private ReadOnly allFiles As New List(Of String)()
    Private ReadOnly fileNameFilters As New List(Of String)()

    Public Sub New(files As List(Of String), directory As String, Optional filters As IEnumerable(Of String) = Nothing)
        InitializeComponent()

        SelectedDirectory = If(directory, String.Empty)

        If filters IsNot Nothing Then
            fileNameFilters.AddRange(filters.Where(Function(filter) Not String.IsNullOrWhiteSpace(filter)).
                                      Select(Function(filter) filter.Trim()))
        End If

        LoadFiles(files)
    End Sub

    Private Sub FileSelectionControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtSearch.Clear()
        UpdateFolderDisplay()
        RefreshFileList()
        TxtSearch.Focus()
    End Sub

    Private Sub LoadFiles(files As IEnumerable(Of String))
        allFiles.Clear()

        If files IsNot Nothing Then
            allFiles.AddRange(files.Where(Function(filePath) Not String.IsNullOrWhiteSpace(filePath) AndAlso File.Exists(filePath)).
                                      Distinct(StringComparer.OrdinalIgnoreCase).
                                      OrderBy(Function(filePath) Path.GetFileName(filePath)))
        End If

        If LV_FileList IsNot Nothing Then
            RefreshFileList()
        End If
    End Sub

    Private Sub RefreshFileList()
        Dim searchText = TxtSearch.Text.Trim()
        Dim visibleFiles = allFiles.AsEnumerable()

        If Not String.IsNullOrWhiteSpace(searchText) Then
            visibleFiles = visibleFiles.Where(Function(filePath)
                                                 Dim fileName = Path.GetFileName(filePath)
                                                 Return fileName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                                             End Function)
        End If

        LV_FileList.BeginUpdate()
        LV_FileList.Items.Clear()

        Dim rowNumber As Integer = 1
        For Each filePath In visibleFiles
            Dim fileInfo As New FileInfo(filePath)
            Dim item As New ListViewItem(rowNumber.ToString())
            item.SubItems.Add(fileInfo.Name)
            item.SubItems.Add(FormatFileSize(fileInfo.Length))
            item.SubItems.Add(fileInfo.LastWriteTime.ToString("MMM dd, yyyy hh:mm tt"))
            item.Tag = filePath
            LV_FileList.Items.Add(item)
            rowNumber += 1
        Next

        LV_FileList.EndUpdate()

        Lbl_ResultCount.Text = "Files found: " & LV_FileList.Items.Count

        If allFiles.Count = 0 Then
            Lbl_Status.Text = "No PDF files found in the selected folder."
        ElseIf LV_FileList.Items.Count = 0 Then
            Lbl_Status.Text = "No files match the current search."
        Else
            Lbl_Status.Text = ""
        End If

        UpdateActionState()
        ResizeFileColumns()
    End Sub

    Private Sub UpdateFolderDisplay()
        Txt_SelectedDirectory.Text = SelectedDirectory
    End Sub

    Private Sub UpdateActionState()
        Btn_Select.Enabled = LV_FileList.SelectedItems.Count > 0
        Btn_Select.BackColor = If(Btn_Select.Enabled, Color.Teal, Color.Gainsboro)
        Btn_Select.ForeColor = If(Btn_Select.Enabled, Color.White, Color.DimGray)
        Btn_Select.Cursor = If(Btn_Select.Enabled, Cursors.Hand, Cursors.Arrow)
    End Sub

    Private Function ApplyFileNameFilters(files As IEnumerable(Of String)) As List(Of String)
        Dim pdfFiles As New List(Of String)()

        If files IsNot Nothing Then
            pdfFiles.AddRange(files)
        End If

        If fileNameFilters.Count = 0 Then Return pdfFiles

        Dim matchedFiles = pdfFiles.Where(Function(filePath)
                                             Dim fileName = Path.GetFileName(filePath)
                                             Return fileNameFilters.Any(Function(filter) fileName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                                         End Function).ToList()

        If matchedFiles.Count > 0 Then Return matchedFiles

        Lbl_Status.Text = "No employee name match found; showing all PDF files."
        Return pdfFiles
    End Function

    Private Function FormatFileSize(bytes As Long) As String
        If bytes >= 1024L * 1024L Then Return (bytes / 1024D / 1024D).ToString("0.##") & " MB"
        If bytes >= 1024L Then Return (bytes / 1024D).ToString("0.##") & " KB"
        Return bytes & " B"
    End Function

    Private Sub SelectCurrentFile()
        If LV_FileList.SelectedItems.Count = 0 Then
            MsgBox("Please select a DTR file.", vbExclamation, "DTR File Selection")
            Return
        End If

        SelectedFile = Convert.ToString(LV_FileList.SelectedItems(0).Tag)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        RefreshFileList()
    End Sub

    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        TxtSearch.Clear()
        RefreshFileList()
        TxtSearch.Focus()
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            RefreshFileList()
        End If
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        RefreshFileList()
    End Sub

    Private Sub LV_FileList_DoubleClick(sender As Object, e As EventArgs) Handles LV_FileList.DoubleClick
        SelectCurrentFile()
    End Sub

    Private Sub LV_FileList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_FileList.SelectedIndexChanged
        UpdateActionState()
    End Sub

    Private Sub Btn_Select_Click(sender As Object, e As EventArgs) Handles Btn_Select.Click
        SelectCurrentFile()
    End Sub

    Private Sub Btn_ReselectFolder_Click(sender As Object, e As EventArgs) Handles Btn_ReselectFolder.Click
        Using folderDialog As New FolderBrowserDialog()
            folderDialog.Description = "Select a folder containing DTR PDF files."
            folderDialog.ShowNewFolderButton = False

            If Not String.IsNullOrWhiteSpace(SelectedDirectory) AndAlso Directory.Exists(SelectedDirectory) Then
                folderDialog.SelectedPath = SelectedDirectory
            End If

            If folderDialog.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK Then Return

            SelectedDirectory = folderDialog.SelectedPath
            UpdateFolderDisplay()
            TxtSearch.Clear()

            Dim pdfFiles = Directory.GetFiles(SelectedDirectory, "*.pdf").ToList()
            LoadFiles(ApplyFileNameFilters(pdfFiles))
        End Using
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub FileSelectionControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ResizeFileColumns()
    End Sub

    Private Sub LV_FileList_Resize(sender As Object, e As EventArgs) Handles LV_FileList.Resize
        ResizeFileColumns()
    End Sub

    Private Sub ResizeFileColumns()
        If LV_FileList Is Nothing OrElse LV_FileList.Columns.Count = 0 Then Return

        Dim fixedWidth = Col_Item.Width + Col_Size.Width + Col_Modified.Width + 28
        Col_FileName.Width = Math.Max(260, LV_FileList.ClientSize.Width - fixedWidth)
    End Sub
End Class
