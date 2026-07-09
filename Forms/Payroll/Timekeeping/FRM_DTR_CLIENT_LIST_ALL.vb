Imports System.Data
Imports System.Data.OleDb

Public Class FRM_DTR_CLIENT_LIST_ALL
    Private Sub FRM_DTR_CLIENT_LIST_ALL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetSearchControls()
    End Sub

    Private Sub FRM_DTR_CLIENT_LIST_ALL_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ResetSearchControls()
        LoadDtrClients(Cmb_Category.Text, TxtSearch.Text)
    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        LoadDtrClients(Cmb_Category.Text, TxtSearch.Text)
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadDtrClients(Cmb_Category.Text, TxtSearch.Text)
        End If
    End Sub

    Private Sub LV_Client_List_DoubleClick(sender As Object, e As EventArgs) Handles LV_Client_List.DoubleClick
        SelectClient()
    End Sub

    Private Sub Btn_Select_Click(sender As Object, e As EventArgs) Handles Btn_Select.Click
        SelectClient()
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click
        Close()
    End Sub

    Private Sub ResetSearchControls()
        TxtSearch.Clear()
        Cmb_Category.SelectedItem = "SUB_CLIENT_NAME"
    End Sub

    Private Sub LoadDtrClients(category As String, searchText As String)
        Dim safeCategory As String = NormalizeSearchCategory(category)
        Dim sql As String =
            "SELECT SUB_CLIENT_ID, SUB_CLIENT_NAME, ADDRESS, DAILY_WAGE " &
            "FROM TBL_CLIENT_SUB " &
            "WHERE SUB_CLIENT_STATUS = 'Active' AND " & safeCategory & " LIKE ? " &
            "ORDER BY SUB_CLIENT_NAME ASC"

        LV_Client_List.Items.Clear()

        Try
            Connect_to_MDB()

            Using cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", "%" & searchText.Trim() & "%")

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    Dim rowNumber As Integer = 1
                    While reader.Read()
                        Dim item As New ListViewItem(rowNumber.ToString())
                        item.SubItems.Add(GetReaderString(reader, "SUB_CLIENT_ID"))
                        item.SubItems.Add(GetReaderString(reader, "SUB_CLIENT_NAME"))
                        item.SubItems.Add(GetReaderString(reader, "ADDRESS"))
                        item.SubItems.Add(GetReaderString(reader, "DAILY_WAGE"))
                        LV_Client_List.Items.Add(item)
                        rowNumber += 1
                    End While
                End Using
            End Using

            Lbl_ResultCount.Text = "Clients found: " & LV_Client_List.Items.Count
        Catch ex As Exception
            MsgBox("Unable to load DTR client list: " & ex.Message, vbCritical, "DTR Client Selection")
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try
    End Sub

    Private Function NormalizeSearchCategory(category As String) As String
        Select Case category
            Case "SUB_CLIENT_ID"
                Return "CStr(SUB_CLIENT_ID)"
            Case "ADDRESS"
                Return "ADDRESS"
            Case "SUB_CLIENT_NAME"
                Return "SUB_CLIENT_NAME"
            Case Else
                Return "SUB_CLIENT_NAME"
        End Select
    End Function

    Private Function GetReaderString(reader As OleDbDataReader, columnName As String) As String
        Dim value As Object = reader(columnName)
        If value Is Nothing OrElse value Is DBNull.Value Then Return ""
        Return value.ToString().Trim()
    End Function

    Private Sub SelectClient()
        If LV_Client_List.SelectedItems.Count = 0 Then
            MsgBox("Please select a client.", vbExclamation, "DTR Client Selection")
            Return
        End If

        With LV_Client_List.SelectedItems(0)
            FRM_DTR_EXPORTS.Lbl_ClientID.Text = .SubItems(1).Text
            FRM_DTR_EXPORTS.Lbl_Client_Name.Text = .SubItems(2).Text
            FRM_DTR_EXPORTS.Lbl_Client_Address.Text = .SubItems(3).Text
            FRM_DTR_EXPORTS.Lbl_Client_Daily_Wage.Text = .SubItems(4).Text
        End With

        Close()
    End Sub
End Class
