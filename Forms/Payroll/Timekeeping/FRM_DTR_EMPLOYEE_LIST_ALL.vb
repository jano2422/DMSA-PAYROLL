Imports System.Data
Imports System.Data.OleDb

Public Class FRM_DTR_EMPLOYEE_LIST_ALL
    Private Sub FRM_DTR_EMPLOYEE_LIST_ALL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetSearchControls()
    End Sub

    Private Sub FRM_DTR_EMPLOYEE_LIST_ALL_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ResetSearchControls()
        LoadPayrollEmployees(Cmb_Category.Text, TxtSearch.Text)
    End Sub

    Private Sub Btn_Search_Click(sender As Object, e As EventArgs) Handles Btn_Search.Click
        LoadPayrollEmployees(Cmb_Category.Text, TxtSearch.Text)
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadPayrollEmployees(Cmb_Category.Text, TxtSearch.Text)
        End If
    End Sub

    Private Sub LV_Employee_List_DoubleClick(sender As Object, e As EventArgs) Handles LV_Employee_List.DoubleClick
        SelectEmployee()
    End Sub

    Private Sub Btn_Select_Click(sender As Object, e As EventArgs) Handles Btn_Select.Click
        SelectEmployee()
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click
        Close()
    End Sub

    Private Sub ResetSearchControls()
        TxtSearch.Clear()
        Cmb_Category.SelectedItem = "LAST_NAME"
    End Sub

    Private Sub LoadPayrollEmployees(category As String, searchText As String)
        Dim safeCategory As String = NormalizeSearchCategory(category)
        Dim sql As String =
            "SELECT R.EMPLOYEE_ID, A.LAST_NAME, A.FIRST_NAME, A.MIDDLE_NAME, R.SUB_CLIENT_ID, S.SUB_CLIENT_NAME, S.ADDRESS " &
            "FROM (HR_EMPLOYEE_RECORD_HDR AS R " &
            "INNER JOIN HR_APPLICATION_DTL AS A ON R.APPLICATION_ID = A.APPLICATION_ID) " &
            "LEFT JOIN TBL_CLIENT_SUB AS S ON R.SUB_CLIENT_ID = S.SUB_CLIENT_ID " &
            "WHERE R.EMPLOYMENT_STATUS = 'Active' AND " & safeCategory & " LIKE ? " &
            "ORDER BY SUB_CLIENT_NAME ASC, LAST_NAME ASC, FIRST_NAME ASC"

        LV_Employee_List.Items.Clear()

        Try
            Connect_to_MDB()

            Using cmd As New OleDbCommand(sql, GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", "%" & searchText.Trim() & "%")

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    Dim rowNumber As Integer = 1
                    While reader.Read()
                        Dim middleName As String = GetReaderString(reader, "MIDDLE_NAME")
                        Dim middleInitial As String = If(String.IsNullOrWhiteSpace(middleName), "", " " & middleName.Substring(0, 1) & ".")
                        Dim employeeName As String = GetReaderString(reader, "LAST_NAME") & ", " & GetReaderString(reader, "FIRST_NAME") & middleInitial

                        Dim item As New ListViewItem(rowNumber.ToString())
                        item.SubItems.Add(GetReaderString(reader, "EMPLOYEE_ID"))
                        item.SubItems.Add(employeeName)
                        item.SubItems.Add(GetReaderString(reader, "SUB_CLIENT_ID"))
                        item.SubItems.Add(GetReaderString(reader, "SUB_CLIENT_NAME"))
                        item.SubItems.Add(GetReaderString(reader, "ADDRESS"))
                        LV_Employee_List.Items.Add(item)
                        rowNumber += 1
                    End While
                End Using
            End Using

            Lbl_ResultCount.Text = "Employees found: " & LV_Employee_List.Items.Count
        Catch ex As Exception
            MsgBox("Unable to load DTR employee list: " & ex.Message, vbCritical, "DTR Employee List")
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try
    End Sub

    Private Function NormalizeSearchCategory(category As String) As String
        Select Case category
            Case "EMPLOYEE_ID"
                Return "R.EMPLOYEE_ID"
            Case "LAST_NAME"
                Return "A.LAST_NAME"
            Case "FIRST_NAME"
                Return "A.FIRST_NAME"
            Case "ADDRESS"
                Return "S.ADDRESS"
            Case "SUB_CLIENT_NAME"
                Return "S.SUB_CLIENT_NAME"
            Case Else
                Return "A.LAST_NAME"
        End Select
    End Function

    Private Function GetReaderString(reader As OleDbDataReader, columnName As String) As String
        Dim value As Object = reader(columnName)
        If value Is Nothing OrElse value Is DBNull.Value Then Return ""
        Return value.ToString().Trim()
    End Function

    Private Sub SelectEmployee()
        If LV_Employee_List.SelectedItems.Count = 0 Then
            MsgBox("Please select an employee.", vbExclamation, "DTR Employee List")
            Return
        End If

        With LV_Employee_List.SelectedItems(0)
            GlobalVariables.DTR_Selected_Employee_ID = .SubItems(1).Text
            GlobalVariables.DTR_Selected_Employee_Name = .SubItems(2).Text
            GlobalVariables.DTR_Selected_SubClient_ID = .SubItems(3).Text
            GlobalVariables.DTR_Selected_SubClient_Name = .SubItems(4).Text
            GlobalVariables.DTR_Selected_SubClient_Address = .SubItems(5).Text
        End With

        GlobalVariables.DTR_Selected_Sched_Type = GetSelectedSubClientSchedType(GlobalVariables.DTR_Selected_SubClient_ID)

        If GlobalVariables.sDTR_or_Schedule_Process = "DTR" Then
            RouteSelectedEmployeeForDtr()
        End If

        Close()
    End Sub

    Private Function GetSelectedSubClientSchedType(subClientId As String) As String
        If String.IsNullOrWhiteSpace(subClientId) Then Return ""

        Dim schedType As String = ""
        Try
            Connect_to_MDB()
            Using cmd As New OleDbCommand("SELECT SCHED_TYPE FROM TBL_CLIENT_SUB WHERE SUB_CLIENT_ID = ?", GlobalVariables.GlobalCon)
                cmd.Parameters.AddWithValue("?", CInt(subClientId))
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    schedType = result.ToString().Trim().ToUpperInvariant()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Unable to read subclient schedule type: " & ex.Message, vbCritical, "DTR")
        Finally
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Open Then
                GlobalVariables.GlobalCon.Close()
            End If
        End Try

        Return schedType
    End Function

    Private Sub RouteSelectedEmployeeForDtr()
        Select Case GlobalVariables.DTR_Selected_Sched_Type
            Case "2SHIFTS", "TRI_SHIFT"
                Using manualDtr As New FRM_DTR_SHIFT_MANUAL()
                    manualDtr.ShowDialog()
                End Using
            Case "TIME_SPECIFIC"
                FRM_DTR_BIOMETRIC.AutoStartForSelectedEmployee = True
                FRM_DTR_BIOMETRIC.ShowDialog()
            Case Else
                MsgBox("Unsupported or missing schedule type for the selected subclient: " & GlobalVariables.DTR_Selected_Sched_Type, vbExclamation, "DTR")
        End Select
    End Sub
End Class
