Imports System.Data.OleDb
Imports System.IO

Module Mod_DB_Connection

    ''' <summary>
    ''' Initializes the connection to the MDB database by setting up the connection string and creating the connection object.
    ''' </summary>
    Public Sub MDB_Connection_Init()
        Try
            ' Define the database file path
            Dim dbfile As String = Path.Combine(Application.StartupPath, "DMSA.mdb")
            'Dim dbfile As String = "Z:\DMSA_SYSTEM\DMSA.mdb"

            ' Ensure the database file exists before proceeding
            If Not File.Exists(dbfile) Then
                Throw New FileNotFoundException("Database file not found at: " & dbfile)
            End If

            ' Set the global connection string
            GlobalVariables.GlobalConStr = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbfile};User ID=admin;Password=;"

            ' Initialize the global database connection object
            GlobalVariables.GlobalCon = New OleDb.OleDbConnection(GlobalVariables.GlobalConStr)

            ' Log success (optional)
            Debug.WriteLine("Database connection initialized successfully.")
        Catch ex As Exception
            ' Log or display an error if initialization fails
            Debug.WriteLine($"Error initializing database connection: {ex.Message}")
            MsgBox($"Failed to initialize database connection: {ex.Message}", vbExclamation, "Database Connection Error")
        End Try
    End Sub


    ''' <summary>
    ''' Opens a connection to the MDB database if it is not already open.
    ''' </summary>
    Public Sub Connect_to_MDB()
        Try
            ' Check if the connection is closed before attempting to open it
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State = ConnectionState.Closed Then
                GlobalVariables.GlobalCon.Open()
                ' Log successful connection (optional)
                Debug.WriteLine("Successfully connected to the database.")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur during the connection attempt
            Debug.WriteLine($"Error connecting to the database: {ex.Message}")
            MsgBox($"Failed to connect to the database: {ex.Message}", vbExclamation, "Database Connection Error")
        End Try
    End Sub


End Module
