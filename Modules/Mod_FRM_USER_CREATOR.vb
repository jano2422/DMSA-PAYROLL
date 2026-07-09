Imports System.Data.OleDb

Module Mod_FRM_USER_CREATOR

    Public Sub Insert_new_User(sUsername As String, sPassword As String, sUserLevel As String)
        Dim SQL As String = "INSERT INTO TBL_USERS (COMPANY_ID, [PASSWORD], USER_LEVEL) VALUES (?, ?, ?)"
        Connect_to_MDB()

        Try
            Using SQLcmd As New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.Parameters.AddWithValue("?", sUsername)
                SQLcmd.Parameters.AddWithValue("?", sPassword)
                SQLcmd.Parameters.AddWithValue("?", sUserLevel)

                SQLcmd.ExecuteNonQuery()
            End Using

            MsgBox("New user account was successfully saved!", vbInformation, "Saved!")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error creating new account!")

        Finally
            GlobalVariables.GlobalCon.Close()
        End Try
    End Sub

End Module
