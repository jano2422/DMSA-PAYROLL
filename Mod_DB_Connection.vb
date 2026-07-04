Imports System.Data.OleDb
Imports System.IO

Module Mod_DB_Connection

    ''' <summary>
    ''' Initializes the connection to the MDB database by setting up the connection string and creating the connection object.
    ''' </summary>
    Public Sub MDB_Connection_Init()
        Try
            ' If connection is already set, do not reinitialize
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso GlobalVariables.GlobalCon.State <> ConnectionState.Closed Then
                Debug.WriteLine("Database connection already initialized.")
                Exit Sub ' Prevent unnecessary reinitialization
            End If

            ' Define the database file path
            Dim dbfile As String = Path.Combine(Application.StartupPath, "DMSA.mdb")
            'Dim dbfile As String = "\\DMSAC-SERVER\Files\DMSA_SYSTEM\DMSA.mdb"

            ' Ensure the database file exists before proceeding
            If Not File.Exists(dbfile) Then
                Throw New FileNotFoundException("Database file not found at: " & dbfile)
            End If

            Dim candidateConnectionStrings As String() = {
                $"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;Persist Security Info=False;",
                $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;Persist Security Info=False;",
                $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;"
            }

            Dim selectedConnectionString As String = Nothing
            Dim lastError As Exception = Nothing

            For Each candidate In candidateConnectionStrings
                Try
                    Using testConnection As New OleDbConnection(candidate)
                        testConnection.Open()
                    End Using
                    selectedConnectionString = candidate
                    Exit For
                Catch ex As Exception
                    lastError = ex
                End Try
            Next

            If String.IsNullOrWhiteSpace(selectedConnectionString) Then
                Throw New InvalidOperationException("No installed Access database provider could open DMSA.mdb.", lastError)
            End If

            ' Set the global connection string
            GlobalVariables.GlobalConStr = selectedConnectionString

            ' Initialize the global database connection object
            GlobalVariables.GlobalCon = New OleDb.OleDbConnection(GlobalVariables.GlobalConStr)

            Debug.WriteLine("Database connection initialized successfully.")

        Catch ex As Exception
            Debug.WriteLine($"Error initializing database connection: {ex.Message}")
            MsgBox($"Failed to initialize database connection: {ex.Message}", vbExclamation, "Database Connection Error")
        End Try
    End Sub


    ''' <summary>
    ''' Opens a connection to the MDB database if it is not already open.
    ''' </summary>
    Public Sub Connect_to_MDB()
        Try
            ' Ensure the connection is initialized first
            If GlobalVariables.GlobalCon Is Nothing Then
                MDB_Connection_Init()
            End If

            ' Open the connection if it's closed
            If GlobalVariables.GlobalCon.State = ConnectionState.Closed Then
                GlobalVariables.GlobalCon.Open()
                Debug.WriteLine("Successfully connected to the database.")
            Else
                Debug.WriteLine("Database connection is already open.")
            End If

        Catch ex As Exception
            Debug.WriteLine($"Error connecting to the database: {ex.Message}")
            MsgBox($"Failed to connect to the database: {ex.Message}", vbExclamation, "Database Connection Error")
        End Try
    End Sub



End Module
