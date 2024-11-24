Imports System.Data.OleDb
Module Mod_GlobalVariables
    Public Class GlobalVariables
        ' Connectios
        Public Shared GlobalConStr As String
        Public Shared GlobalCon As New OleDb.OleDbConnection

        Public Shared Selected_Employee_ID As String
        Public Shared Selected_Client_ID As Integer
        Public Shared Selected_Reliever_ID As Integer


        ' Employee Update record Reference IDs - When selecting record from List need unique identification 
        Public Shared sLeave_Reference_ID As String
        Public Shared sLicense_Reference_ID As String
        Public Shared sInsurance_Reference_ID As String
        Public Shared sClient_Reference_ID As String ' Not used yet
        Public Shared sMedical_Reference_ID As String ' Not used yet
        ' For others I used Label.txt as holder of reference ID ( will change later for standardization )


        ' DTR Payroll
        Public Shared sPayroll_Cutoff As String
        Public Shared AM_PM_Shift(15) As String
        Public Shared No_Of_Days(15) As Integer ' Count the days per Date ( if 24 hours rendered, considered as 2 days not OT of 12 hours )
        Public Shared sDTR_or_Schedule_Process As String
        Public Shared iHours_Rendered(16) As Double

        Public Shared DTR_Selected_Employee_ID As String
        Public Shared DTR_Selected_Employee_Name As String
        Public Shared DTR_Selected_SubClient_ID As String
        Public Shared DTR_Selected_SubClient_Name As String

        Public Shared sDay(15) As String

        ' APPLICATION
        Public Shared New_Application_ID As Integer
        Public Shared sSelected_Job_Type As String

        ' FRM_EMP_HDR
        Public Shared Emp_Reg_Mode As String ' Identification between NEW and EDIT
        Public Shared DTR_INPUT_SAVED As String
        Public Shared sReliever As Boolean ' True if changed the CLient ID during DTR process


        ' Client Management
        Public Shared Selected_Sub_Client_ID As String
        Public Shared Selected_Sub_Client_Name As String
        Public Shared Contract_New_File_Destination_Path As String
        Public Shared Selected_Contract_attachment As String
        Public Shared Selected_Contract_ID As Integer
        ' Client Deactivation
        Public Shared sReason_for_Deactivation_Activation As String
        Public Shared sDecision As String ' If Okay to Execute or Cancel
        Public Shared sActivate_or_Deactivate As String
        Public Shared dClient_Deactivation_Date As Date


        ' HR System
        Public Shared sApplication_Global_Status As String
        Public Shared sSource_Path, sDestination_Path, sFileName As String
        Public Shared Photo_Source_Path, Photo_Destination_Path, Photo_sFilename, Photo_Path_from_DB As String
        Public Shared Client_Event As String ' Being called in many forms, need to specify event or in which form

        ' User Login
        Public Shared sUser_Level As String
        Public Shared sEmployee_ID_Logged_in As String
        Public Shared sLogged_in_Name As String

        ' Error_Encountered
        Public Shared Error_Encountered As Integer

        'Control Variables
        Public Shared Active_Status_Update As Integer

    End Class

End Module
