Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Conversion
Public Class FRM_DTR_BIOMETRIC

    Private Sub Btn_DTR_Click(sender As Object, e As EventArgs) Handles Btn_DTR.Click

        If Now.Year = 2026 Then
            MsgBox("Trial Period Ends")
            End
        End If


        Try
            OpenFileDialog1.Title = "Upload scanned Security Guard License ID"

            ' Set the file filter to allow only PDF and JPEG files
            OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Check Map Drive")
        End Try

        GView_DTR.Rows.Clear()


        Dim result As DialogResult = OpenFileDialog1.ShowDialog()


        If result = 1 Then

            'Initialize an instance of PdfDocument class
            Dim pdf As PdfDocument = New PdfDocument()
            'Load the PDF document
            pdf.LoadFromFile(OpenFileDialog1.FileName)

            'Save the PDF document to XLSX
            'pdf.SaveToFile("D:\01 - Software Development\Delta Maroon Security Agency\DMSA_System\bin\Debug\PdfToExcel.xlsx", FileFormat.XLSX)
            Dim filePath As String = "C:\Users\johnc\Downloads\Software Projects\Project 1\DMSA_System\bin\Debug\PdfToExcel.xlsx"

            pdf.SaveToFile(filePath, FileFormat.XLSX)
            'pdf.SaveToFile("Z:\DMSA_SYSTEM\Reports\PdfToExcel.xlsx", FileFormat.XLSX)

            ' Connect with created excel file PdfToExcel.xlsx
            Call Connect_to_Excel_DTR()


        Else

            MsgBox("Please Select a valid .pdf or .jpg file.", vbCritical, "Nothing was selected")
            Exit Sub
        End If

    End Sub

    Private Sub FRM_BIOMETRIC_DTR_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Connect to MDB
        MDB_Connection_Init()
        Connect_to_MDB()

        GView_DTR.Rows.Clear()

        Dim processes As Process() = Process.GetProcessesByName("EXCEL")

        For Each process As Process In processes
            Dim processFileName As String = GetProcessFileName(process)

            If processFileName.EndsWith("PdfToExcel.xlsx", StringComparison.OrdinalIgnoreCase) Then
                process.Kill()
            End If
        Next

    End Sub

    Private Function GetProcessFileName(ByVal process As Process) As String
        Try
            Return process.MainModule.FileName
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Btn_Calculate_Click(sender As Object, e As EventArgs) Handles Btn_Calculate.Click

        If Chk_NighShift.Checked = True Then
            Call Calculate_DTR("night shift")
        Else
            Call Calculate_DTR("morning shift")
        End If



    End Sub



    Private Sub Btn_Payslip_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GView_DTR_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GView_DTR.CellContentClick

    End Sub

    Private Sub GView_DTR_DoubleClick(sender As Object, e As EventArgs) Handles GView_DTR.DoubleClick



        'If GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen Then
        '    GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
        'ElseIf GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Yellow Then
        '    GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Empty
        'ElseIf GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Empty Then
        '    GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        'ElseIf GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue Then
        '    GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        'End If


    End Sub

    Private Sub Btn_Hours_Breakdown_Click(sender As Object, e As EventArgs) Handles Btn_Hours_Breakdown.Click


        For iRow = 0 To GView_DTR.Rows.Count - 3

            If GView_DTR.Rows(iRow).Cells(1).Value = "" Then
                Exit For
            End If

            ' Regular Days
            If GView_DTR.Rows(iRow).Cells(1).Value = "Sunday" Then

                If GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.LightGreen Then ' Sunday Legal Holiday 
                    ' Check if AM or PM
                    ' Common Code for all conditions, just changing the alloction to cells
                    ' ========================================================================================================================================================

                    ' Parsed DTR Time IN
                    Dim parsedTime_DTR_IN As DateTime = DateTime.ParseExact(GView_DTR.Rows(iRow).Cells(2).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("HH")

                    If 22 - CInt(DTR_militaryTime_DTR_IN) > 10 Then ' Morning Shift ( Meaning reported to work on or before 12PM ) 
                        If GView_DTR.Rows(iRow).Cells(12).Value >= 8 Then ' For regular days

                            GView_DTR.Rows(iRow).Cells(13).Value = 0 ' Reg Hours
                            GView_DTR.Rows(iRow).Cells(14).Value = 0 ' Reg Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = 0 ' Reg SH
                            GView_DTR.Rows(iRow).Cells(16).Value = 0 ' Reg LH
                            GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 8 ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND




                            ' Get OT ( As Puregold is just providing FIX allowance for the OT, hours exceeding 8 hours will just be a regular OT, even if Sunday or Holiday )
                            GView_DTR.Rows(iRow).Cells(25).Value = CDbl(GView_DTR.Rows(iRow).Cells(12).Value) - CDbl(GView_DTR.Rows(iRow).Cells(18).Value)

                        Else ' If below 8 hours rendered, just get the value of Total_Hours

                            GView_DTR.Rows(iRow).Cells(13).Value = 0
                            GView_DTR.Rows(iRow).Cells(14).Value = 0
                            GView_DTR.Rows(iRow).Cells(15).Value = 0
                            GView_DTR.Rows(iRow).Cells(16).Value = 0
                            GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = GView_DTR.Rows(iRow).Cells(12).Value  ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' NDfy


                            ' No OT since rendered time < 8 hours
                            GView_DTR.Rows(iRow).Cells(25).Value = 0

                        End If
                    Else ' Night Shift ( with Night Diff )

                        ' only 10PM onwards for ND
                        ' Below 10PM will just be regular hours

                    End If
                    ' ========================================================================================================================================================

                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Yellow Then ' Sunday Special Holiday
                    ' Check if AM or PM

                    ' Common Code for all conditions, just changing the alloction to cells
                    ' ========================================================================================================================================================

                    ' Parsed DTR Time IN
                    Dim parsedTime_DTR_IN As DateTime = DateTime.ParseExact(GView_DTR.Rows(iRow).Cells(2).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("HH")

                    If 22 - CInt(DTR_militaryTime_DTR_IN) > 10 Then ' Morning Shift ( Meaning reported to work on or before 12PM ) 
                        If GView_DTR.Rows(iRow).Cells(12).Value >= 8 Then ' For regular days

                            GView_DTR.Rows(iRow).Cells(13).Value = 0 ' Reg Hours
                            GView_DTR.Rows(iRow).Cells(14).Value = 0 ' Reg Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = 0 ' Reg SH
                            GView_DTR.Rows(iRow).Cells(16).Value = 0 ' Reg LH
                            GView_DTR.Rows(iRow).Cells(17).Value = 8 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0 ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND



                            ' Get OT ( As Puregold is just providing FIX allowance for the OT, hours exceeding 8 hours will just be a regular OT, even if Sunday or Holiday )
                            GView_DTR.Rows(iRow).Cells(25).Value = CDbl(GView_DTR.Rows(iRow).Cells(12).Value) - CDbl(GView_DTR.Rows(iRow).Cells(17).Value)

                        Else ' If below 8 hours rendered, just get the value of Total_Hours

                            GView_DTR.Rows(iRow).Cells(13).Value = 0
                            GView_DTR.Rows(iRow).Cells(14).Value = 0
                            GView_DTR.Rows(iRow).Cells(15).Value = 0
                            GView_DTR.Rows(iRow).Cells(16).Value = 0
                            GView_DTR.Rows(iRow).Cells(17).Value = GView_DTR.Rows(iRow).Cells(12).Value  ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND


                            ' No OT since rendered time < 8 hours
                            GView_DTR.Rows(iRow).Cells(25).Value = 0

                        End If
                    Else ' Night Shift ( with Night Diff )

                        ' only 10PM onwards for ND
                        ' Below 10PM will just be regular hours

                    End If
                    ' ========================================================================================================================================================

                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Empty Or GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue Then ' Sunday (Non Holday)
                    ' Check if AM or PM

                    ' Common Code for all conditions, just changing the alloction to cells
                    ' ========================================================================================================================================================

                    ' Parsed DTR Time IN
                    Dim parsedTime_DTR_IN As DateTime = DateTime.ParseExact(GView_DTR.Rows(iRow).Cells(2).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("HH")

                    If 22 - CInt(DTR_militaryTime_DTR_IN) > 10 Then ' Morning Shift ( Meaning reported to work on or before 12PM ) 
                        If GView_DTR.Rows(iRow).Cells(12).Value >= 8 Then ' For regular days

                            GView_DTR.Rows(iRow).Cells(13).Value = 0 ' Reg Hours
                            GView_DTR.Rows(iRow).Cells(14).Value = 8 ' Reg Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = 0 ' Reg SH
                            GView_DTR.Rows(iRow).Cells(16).Value = 0 ' Reg LH
                            GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0 ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND



                            ' Get OT ( As Puregold is just providing FIX allowance for the OT, hours exceeding 8 hours will just be a regular OT, even if Sunday or Holiday )
                            GView_DTR.Rows(iRow).Cells(25).Value = CDbl(GView_DTR.Rows(iRow).Cells(12).Value) - CDbl(GView_DTR.Rows(iRow).Cells(14).Value)

                        Else ' If below 8 hours rendered, just get the value of Total_Hours

                            GView_DTR.Rows(iRow).Cells(13).Value = 0
                            GView_DTR.Rows(iRow).Cells(14).Value = GView_DTR.Rows(iRow).Cells(12).Value ' Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = 0
                            GView_DTR.Rows(iRow).Cells(16).Value = 0
                            GView_DTR.Rows(iRow).Cells(17).Value = 0  ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND


                            ' No OT since rendered time < 8 hours
                            GView_DTR.Rows(iRow).Cells(25).Value = 0

                        End If
                    Else ' Night Shift ( with Night Diff )

                        ' only 10PM onwards for ND
                        ' Below 10PM will just be regular hours

                    End If
                    ' ========================================================================================================================================================



                End If

            ElseIf GView_DTR.Rows(iRow).Cells(1).Value <> "Sunday" Then ' Not Sunday

                If GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.LightGreen Then ' Legal Holiday 
                    ' Check if AM or PM

                    ' Common Code for all conditions, just changing the alloction to cells
                    ' ========================================================================================================================================================

                    ' Parsed DTR Time IN
                    Dim parsedTime_DTR_IN As DateTime = DateTime.ParseExact(GView_DTR.Rows(iRow).Cells(2).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("HH")

                    If 22 - CInt(DTR_militaryTime_DTR_IN) > 10 Then ' Morning Shift ( Meaning reported to work on or before 12PM ) 
                        If GView_DTR.Rows(iRow).Cells(12).Value >= 8 Then ' For regular days

                            GView_DTR.Rows(iRow).Cells(13).Value = 0 ' Reg Hours
                            GView_DTR.Rows(iRow).Cells(14).Value = 0 ' Reg Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = 0 ' Reg SH
                            GView_DTR.Rows(iRow).Cells(16).Value = 8 ' Reg LH
                            GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0 ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND



                            ' Get OT ( As Puregold is just providing FIX allowance for the OT, hours exceeding 8 hours will just be a regular OT, even if Sunday or Holiday )
                            GView_DTR.Rows(iRow).Cells(25).Value = CDbl(GView_DTR.Rows(iRow).Cells(12).Value) - CDbl(GView_DTR.Rows(iRow).Cells(16).Value)

                        Else ' If below 8 hours rendered, just get the value of Total_Hours

                            GView_DTR.Rows(iRow).Cells(13).Value = 0 'Reg Hours
                            GView_DTR.Rows(iRow).Cells(14).Value = 0 'Reg Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = 0 'Reg SH
                            GView_DTR.Rows(iRow).Cells(16).Value = GView_DTR.Rows(iRow).Cells(12).Value ' Reg LH
                            GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0 ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND


                            ' No OT since rendered time < 8 hours
                            GView_DTR.Rows(iRow).Cells(25).Value = 0

                        End If
                    Else ' Night Shift ( with Night Diff )

                        ' only 10PM onwards for ND
                        ' Below 10PM will just be regular hours

                    End If
                    ' ========================================================================================================================================================

                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Yellow Then ' Special Holiday

                    ' Check if AM or PM

                    ' Common Code for all conditions, just changing the alloction to cells
                    ' ========================================================================================================================================================

                    ' Parsed DTR Time IN
                    Dim parsedTime_DTR_IN As DateTime = DateTime.ParseExact(GView_DTR.Rows(iRow).Cells(2).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("HH")

                    If 22 - CInt(DTR_militaryTime_DTR_IN) > 10 Then ' Morning Shift ( Meaning reported to work on or before 12PM ) 
                        If GView_DTR.Rows(iRow).Cells(12).Value >= 8 Then ' For regular days

                            GView_DTR.Rows(iRow).Cells(13).Value = 0 ' Reg Hours
                            GView_DTR.Rows(iRow).Cells(14).Value = 0 ' Reg Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = 8 ' Reg SH
                            GView_DTR.Rows(iRow).Cells(16).Value = 0 ' Reg LH
                            GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0 ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND



                            ' Get OT ( As Puregold is just providing FIX allowance for the OT, hours exceeding 8 hours will just be a regular OT, even if Sunday or Holiday )
                            GView_DTR.Rows(iRow).Cells(25).Value = CDbl(GView_DTR.Rows(iRow).Cells(12).Value) - CDbl(GView_DTR.Rows(iRow).Cells(15).Value)

                        Else ' If below 8 hours rendered, just get the value of Total_Hours

                            GView_DTR.Rows(iRow).Cells(13).Value = 0 'Reg Hours
                            GView_DTR.Rows(iRow).Cells(14).Value = 0 'Reg Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = GView_DTR.Rows(iRow).Cells(12).Value 'Reg SH
                            GView_DTR.Rows(iRow).Cells(16).Value = 0 ' Reg LH
                            GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0 ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND


                            ' No OT since rendered time < 8 hours
                            GView_DTR.Rows(iRow).Cells(25).Value = 0

                        End If
                    Else ' Night Shift ( with Night Diff )

                        ' only 10PM onwards for ND
                        ' Below 10PM will just be regular hours

                    End If
                    ' ========================================================================================================================================================


                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Empty Then ' Regular Day
                    ' Check if AM or PM

                    ' Common Code for all conditions, just changing the alloction to cells
                    ' ========================================================================================================================================================

                    ' Parsed DTR Time IN
                    Dim parsedTime_DTR_IN As DateTime = DateTime.ParseExact(GView_DTR.Rows(iRow).Cells(2).Value, "h:mm tt", Nothing)
                    Dim DTR_militaryTime_DTR_IN As String = parsedTime_DTR_IN.ToString("HH")


                    If 22 - CInt(DTR_militaryTime_DTR_IN) > 10 Then ' Morning Shift ( Meaning reported to work on or before 12PM ) 
                        If GView_DTR.Rows(iRow).Cells(12).Value >= 8 Then ' For regular days

                            GView_DTR.Rows(iRow).Cells(13).Value = 8 ' Reg Hours
                            GView_DTR.Rows(iRow).Cells(14).Value = 0 ' Reg Sunday
                            GView_DTR.Rows(iRow).Cells(15).Value = 0 ' Reg SH
                            GView_DTR.Rows(iRow).Cells(16).Value = 0 ' Reg LH
                            GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                            GView_DTR.Rows(iRow).Cells(18).Value = 0 ' Reg RD SUN LH
                            GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                            GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND



                            ' Get OT ( As Puregold is just providing FIX allowance for the OT, hours exceeding 8 hours will just be a regular OT, even if Sunday or Holiday )
                            GView_DTR.Rows(iRow).Cells(25).Value = CDbl(GView_DTR.Rows(iRow).Cells(12).Value) - CDbl(GView_DTR.Rows(iRow).Cells(13).Value)

                        Else   ' If below 8 hours rendered, just get the value of Total_Hours

                            If 22 - CInt(DTR_militaryTime_DTR_IN) = 0 Then
                                ' No need to write the Zero values in grid view if Total hours is ZERO
                            Else
                                GView_DTR.Rows(iRow).Cells(13).Value = GView_DTR.Rows(iRow).Cells(12).Value 'Reg Hours
                                GView_DTR.Rows(iRow).Cells(14).Value = 0 'Reg Sunday
                                GView_DTR.Rows(iRow).Cells(15).Value = 0 'Reg SH
                                GView_DTR.Rows(iRow).Cells(16).Value = 0 ' Reg LH
                                GView_DTR.Rows(iRow).Cells(17).Value = 0 ' Reg RD SUN SH
                                GView_DTR.Rows(iRow).Cells(18).Value = 0 ' Reg RD SUN LH
                                GView_DTR.Rows(iRow).Cells(19).Value = 0 ' ND
                                GView_DTR.Rows(iRow).Cells(20).Value = 0 ' ND
                                GView_DTR.Rows(iRow).Cells(21).Value = 0 ' ND
                                GView_DTR.Rows(iRow).Cells(22).Value = 0 ' ND
                                GView_DTR.Rows(iRow).Cells(23).Value = 0 ' ND
                                GView_DTR.Rows(iRow).Cells(24).Value = 0 ' ND


                                ' No OT since rendered time < 8 hours
                                GView_DTR.Rows(iRow).Cells(25).Value = 0
                            End If
                        End If
                    Else ' Night Shift ( with Night Diff )

                        ' only 10PM onwards for ND
                        ' Below 10PM will just be regular hours

                    End If
                    ' ========================================================================================================================================================

                End If

            End If


        Next


        ' Calculate Total Hours

        Dim dReg_Hours, dSun_Hours, dSH_Hours, dLH_Hours, dRD_Sun_SH_Hours, dRD_Sun_LH_Hours, dND_Reg_Hours, dND_Sun_Hours, dND_SH_Hours, dND_LH_Hours, dOT_Reg As Double
        Dim dND_RD_Sun_SH_Hours, dND_RD_Sun_LH_Hours As Double



        For i = 0 To 16
            dReg_Hours = dReg_Hours + CDbl(GView_DTR.Rows(i).Cells(13).Value)
            dSun_Hours = dSun_Hours + CDbl(GView_DTR.Rows(i).Cells(14).Value)
            dSH_Hours = dSH_Hours + CDbl(GView_DTR.Rows(i).Cells(15).Value)
            dLH_Hours = dLH_Hours + CDbl(GView_DTR.Rows(i).Cells(16).Value)
            dRD_Sun_SH_Hours = dRD_Sun_SH_Hours + CDbl(GView_DTR.Rows(i).Cells(17).Value)
            dRD_Sun_LH_Hours = dRD_Sun_LH_Hours + CDbl(GView_DTR.Rows(i).Cells(18).Value)
            dND_Reg_Hours = dND_Reg_Hours + CDbl(GView_DTR.Rows(i).Cells(19).Value)
            dND_Sun_Hours = dND_Sun_Hours + CDbl(GView_DTR.Rows(i).Cells(20).Value)
            dND_SH_Hours = dND_SH_Hours + CDbl(GView_DTR.Rows(i).Cells(21).Value)
            dND_LH_Hours = dND_LH_Hours + CDbl(GView_DTR.Rows(i).Cells(22).Value)
            dND_RD_Sun_SH_Hours = dND_RD_Sun_SH_Hours + CDbl(GView_DTR.Rows(i).Cells(23).Value)
            dND_RD_Sun_LH_Hours = dND_RD_Sun_LH_Hours + CDbl(GView_DTR.Rows(i).Cells(24).Value)
            dOT_Reg = dOT_Reg + CDbl(GView_DTR.Rows(i).Cells(25).Value)
        Next

        GView_DTR.Rows(17).Cells(13).Value = dReg_Hours
        GView_DTR.Rows(17).Cells(14).Value = dSun_Hours
        GView_DTR.Rows(17).Cells(15).Value = dSH_Hours
        GView_DTR.Rows(17).Cells(16).Value = dLH_Hours
        GView_DTR.Rows(17).Cells(17).Value = dRD_Sun_SH_Hours
        GView_DTR.Rows(17).Cells(18).Value = dRD_Sun_LH_Hours
        GView_DTR.Rows(17).Cells(19).Value = dND_Reg_Hours
        GView_DTR.Rows(17).Cells(20).Value = dND_Sun_Hours
        GView_DTR.Rows(17).Cells(21).Value = dND_SH_Hours
        GView_DTR.Rows(17).Cells(22).Value = dND_LH_Hours
        GView_DTR.Rows(17).Cells(23).Value = dND_RD_Sun_SH_Hours
        GView_DTR.Rows(17).Cells(24).Value = dND_RD_Sun_LH_Hours
        GView_DTR.Rows(17).Cells(25).Value = dOT_Reg


    End Sub

    Private Sub Chk_Sunday_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Sunday.CheckedChanged
        If Chk_Sunday.Checked = True Then
            For iRow = 1 To 16 ' Number of Days in Cut-Off

                If GView_DTR.Rows(iRow).Cells(1).Value = "Sunday" Then
                    GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.LightBlue
                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor <> Color.Empty Then
                    'GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Empty
                End If

            Next
        Else
            For iRow = 1 To 16 ' Number of Days in Cut-Off

                If GView_DTR.Rows(iRow).Cells(1).Value = "Sunday" Then
                    GView_DTR.Rows(iRow).DefaultCellStyle.BackColor = Color.Empty
                ElseIf GView_DTR.Rows(iRow).DefaultCellStyle.BackColor <> Color.Empty Then

                End If

            Next

        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Lbl_Absent_Count_Click(sender As Object, e As EventArgs) Handles Lbl_Absent_Count.Click

    End Sub

    Private Sub Btn_Save_DTR_Click(sender As Object, e As EventArgs) Handles Btn_Save_DTR.Click

        ' Get cut off period from Lbl_Period
        Call Save_DTR_Total_Hours(GlobalVariables.DTR_Selected_SubClient_ID, GlobalVariables.DTR_Selected_Employee_ID, GlobalVariables.sPayroll_Cutoff, CInt(Me.Lbl_Num_of_Reporting_Days.Text))

    End Sub

    Private Sub BtnSH_Click(sender As Object, e As EventArgs) Handles BtnSH.Click
        GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
    End Sub

    Private Sub BtnLH_Click(sender As Object, e As EventArgs) Handles BtnLH.Click
        GView_DTR.Rows(GView_DTR.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
    End Sub
End Class
