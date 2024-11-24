Public Class FRM_RELIEVER
    Private Sub FRM_RELIEVER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Show_Client_Selection_Reliever() ' Fill-in Clients


        Dim iTxtHoursXX As String

        Cmb_Day.Items.Clear()
        Try
            With FRM_DTR_INPUT

                For i = 1 To 15

                    iTxtHoursXX = .Controls("TxtHours" & i).Text

                    If iTxtHoursXX = 0 Then
                        Cmb_Day.Items.Add(i)
                    End If

                Next i
            End With

        Catch ex As Exception

        End Try

        Call Show_Reliever_List_to_LV(CInt(FRM_DTR_INPUT.Lbl_DTR_No.Text))


    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        If Cmb_Day.Text = "" Then
            MsgBox("Please select DAY of the month!", vbCritical, "Invalid Day of the month")
            Exit Sub
        End If

        If Me.LV_Main_Client_List.SelectedItems(0).SubItems(0).Text = "" Then
            MsgBox("Please select Client from the List!", vbCritical, "Invalid Client ID")
            Exit Sub
        End If

        With FRM_DTR_INPUT

            ' Insert into
            Call Save_Reliever(CInt(.Lbl_DTR_No.Text), CInt(Me.LV_Main_Client_List.SelectedItems(0).SubItems(0).Text), Date.Today.Year, .Lbl_Period.Text, CInt(Cmb_Day.Text), Me.Cmb_Shift.Text)

            Call Show_Reliever_List_to_LV(CInt(.Lbl_DTR_No.Text))

        End With



    End Sub

    Private Sub LV_Main_Client_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Main_Client_List.SelectedIndexChanged

    End Sub

    Private Sub FRM_RELIEVER_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Call Refresh_Calculation()
    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        Dim AskDel As String
        AskDel = MsgBox("Are you sure you want to delete this Reliever Record?", vbQuestion + vbYesNo, "Delete?")
        If AskDel = vbYes Then
            Call Delete_Reliever_Record(GlobalVariables.Selected_Reliever_ID)
            Call Show_Reliever_List_to_LV(CInt(FRM_DTR_INPUT.Lbl_DTR_No.Text))
        Else

        End If


    End Sub

    Private Sub LV_Reliever_Dates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV_Reliever_Dates.SelectedIndexChanged
        GlobalVariables.Selected_Reliever_ID = Me.LV_Reliever_Dates.SelectedItems(0).SubItems(0).Text
    End Sub
End Class