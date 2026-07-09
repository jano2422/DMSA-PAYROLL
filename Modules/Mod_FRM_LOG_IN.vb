Imports System.Data.OleDb
Module Mod_FRM_LOG_IN

    Public Sub Login(sCompany_id As String, sPassword As String)

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        dt.Clear()
        dt.Reset()
        Dim SQL As String = "Select * from TBL_USERS where company_id = '" & sCompany_id & "' and password = '" & sPassword & "'"
        da = New OleDbDataAdapter(SQL, Mod_GlobalVariables.GlobalVariables.GlobalCon)
        da.Fill(dt)


        If dt.Rows.Count > 0 Then
            Mod_GlobalVariables.GlobalVariables.sEmployee_ID_Logged_in = sCompany_id
            'Mod_GlobalVariables.GlobalVariables.sEmployee_ID_Logged_in = sCompany_id

            FRM_MAIN.Show()
            FRM_LOGIN.Close()
        Else
            MsgBox("Username and Password did not matched!", vbCritical, "Access Denied!")
        End If

        GlobalVariables.GlobalCon.Close()

    End Sub


End Module
