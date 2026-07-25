Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration

Module Mod_DB_Connection

    ''' <summary>
    ''' Initializes the connection to the MDB database by setting up the connection string and creating the connection object.
    ''' </summary>
    Public Sub MDB_Connection_Init()
        Try
            ' A closed connection can still be fully initialized and reused. Checking
            ' only its State caused provider detection to run again whenever callers
            ' explicitly initialized a connection that had already been closed.
            If GlobalVariables.GlobalCon IsNot Nothing AndAlso
               Not String.IsNullOrWhiteSpace(GlobalVariables.GlobalCon.ConnectionString) Then
                GlobalVariables.GlobalConStr = GlobalVariables.GlobalCon.ConnectionString
                Debug.WriteLine("Database connection already initialized.")
                Exit Sub
            End If

            ' Read the database location from App.config. Relative paths remain
            ' relative to the application folder for local development.
            Dim configuredDatabasePath As String = ConfigurationManager.AppSettings("DatabasePath")
            If String.IsNullOrWhiteSpace(configuredDatabasePath) Then
                Throw New ConfigurationErrorsException("The DatabasePath app setting is missing or empty.")
            End If

            configuredDatabasePath = Environment.ExpandEnvironmentVariables(configuredDatabasePath.Trim())
            Dim dbfile As String
            If Path.IsPathRooted(configuredDatabasePath) Then
                dbfile = Path.GetFullPath(configuredDatabasePath)
            Else
                dbfile = Path.GetFullPath(Path.Combine(Application.StartupPath, configuredDatabasePath))
            End If

            ' Ensure the database file exists before proceeding
            If Not File.Exists(dbfile) Then
                Throw New FileNotFoundException("Database file not found at: " & dbfile)
            End If

            ' AnyCPU WinForms executables run as 32-bit when Prefer 32-bit is enabled.
            ' Prefer Jet in that process because probing unavailable 64-bit ACE
            ' providers raises caught first-chance InvalidOperationExceptions in VS.
            Dim candidateConnectionStrings As String()
            If Environment.Is64BitProcess Then
                candidateConnectionStrings = {
                    $"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;Persist Security Info=False;",
                    $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;Persist Security Info=False;",
                    $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;"
                }
            Else
                candidateConnectionStrings = {
                    $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;",
                    $"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;Persist Security Info=False;",
                    $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbfile};Jet OLEDB:Database Password=DMSA001;Persist Security Info=False;"
                }
            End If

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
                Throw New InvalidOperationException($"No installed Access database provider could open the database at: {dbfile}", lastError)
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
            If GlobalVariables.GlobalCon Is Nothing OrElse
               String.IsNullOrWhiteSpace(GlobalVariables.GlobalCon.ConnectionString) Then
                MDB_Connection_Init()
            End If

            If GlobalVariables.GlobalCon.State = ConnectionState.Broken Then
                GlobalVariables.GlobalCon.Close()
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
