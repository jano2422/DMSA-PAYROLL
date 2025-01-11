Imports System.Data.OleDb
Module Mod_DB_Connection


    Public Sub MDB_Connection_Init()

        'Dim dbfile As String = Application.StartupPath & "\DMSA.mdb"
        Dim dbfile As String = "Z:\DMSA_SYSTEM\DMSA.mdb"

        GlobalVariables.GlobalConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbfile & " ;User ID=admin;Password=;"

        GlobalVariables.GlobalCon = New OleDb.OleDbConnection(GlobalVariables.GlobalConStr)



    End Sub

    Public Sub Connect_to_MDB()
        If GlobalVariables.GlobalCon.State = ConnectionState.Closed Then
            GlobalVariables.GlobalCon.Open()
        End If
    End Sub

End Module
