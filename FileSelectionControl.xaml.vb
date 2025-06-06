Imports System.IO
Imports System.Windows
Imports Microsoft.Win32

Public Class FileSelectionControl
    Public Property SelectedFile As String
    Public Property SelectedDirectory As String ' Add this to store the selected directory

    Private fileDictionary As Dictionary(Of String, String)

    ' Constructor to accept the initial directory
    Public Sub New(files As List(Of String), ByRef directory As String)
        InitializeComponent()

        ' Store reference to the directory
        SelectedDirectory = directory

        ' Store full paths mapped to filenames
        fileDictionary = files.ToDictionary(Function(f) Path.GetFileName(f), Function(f) f)

        ' Populate listbox with just filenames
        FileListBox.ItemsSource = fileDictionary.Keys.ToList()
    End Sub

    ' Handle file selection
    Private Sub FileListBox_MouseDoubleClick(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles FileListBox.MouseDoubleClick
        If FileListBox.SelectedItem IsNot Nothing Then
            Dim selectedFileName As String = FileListBox.SelectedItem.ToString()

            ' Retrieve full path from dictionary
            If fileDictionary.ContainsKey(selectedFileName) Then
                SelectedFile = fileDictionary(selectedFileName)
            End If

            CType(Me.Parent, Window).DialogResult = True
            CType(Me.Parent, Window).Close()
        End If
    End Sub

    ' Reselect Folder
    Private Sub BtnReselectFolder_Click(sender As Object, e As RoutedEventArgs) Handles BtnReselectFolder.Click
        Dim folderDialog As New System.Windows.Forms.FolderBrowserDialog()

        If folderDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ' Update the SelectedDirectory property
            SelectedDirectory = folderDialog.SelectedPath
            CType(Me.Parent, Window).DialogResult = True
            CType(Me.Parent, Window).Close()
            '' Get new list of files from the selected directory
            'Dim newFiles = Directory.GetFiles(SelectedDirectory, "*.pdf").ToList()

            '' Update dictionary and listbox
            'fileDictionary = newFiles.ToDictionary(Function(f) Path.GetFileName(f), Function(f) f)
            'FileListBox.ItemsSource = fileDictionary.Keys.ToList()
        End If
    End Sub

    ' Cancel
    Private Sub BtnCancel_Click(sender As Object, e As RoutedEventArgs) Handles BtnCancel.Click
        CType(Me.Parent, Window).DialogResult = False
        CType(Me.Parent, Window).Close()
    End Sub
End Class
