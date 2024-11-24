Imports System.Data.OleDb
Module Mod_FRM_USER_CREATOR

    Public Sub Insert_new_User(sUsername As String, sPassword As String, sUserLevel As String)

        Dim SQL As String
        Connect_to_MDB()

        Try
            With FRM_CLIENT_HDR


                SQL = "INSERT INTO TBL_USERS (USER_ID, PASSWORD, USER_LEVEL) VALUES ('" & sUsername & "', '" & sPassword & "', '" & FRM_USER_CREATOR.Cmb_UserLevel.Text & "') "


                Dim SQLcmd As OleDbCommand = New OleDbCommand(SQL, GlobalVariables.GlobalCon)
                SQLcmd.ExecuteNonQuery()
                SQLcmd.Dispose()


                MsgBox("New user account was successfully saved!", vbInformation, "Saved!")

            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error creating new account!")

        End Try

        GlobalVariables.GlobalCon.Close()

    End Sub

End Module
