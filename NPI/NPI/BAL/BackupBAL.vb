Public Class BackupBAL
    Public Sub insertBackupRecord(ByVal backup As BackupBO)
        Dim query As String = "INSERT INTO BackupTable (BackupId,BackupDate,BackupPath,BackupUser,BackupInfo) VALUES (" & backup.NumberId & ",'" + Date.Now.ToString("yyyy/MM/dd hh:mm tt") + "','" + backup.BackupPath + "','" + backup.BackupUser + "','Continue')"
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
    End Sub
    Public Sub updatetBackupRecord(ByVal code As Integer)
        Dim query As String = "UPDATE BackupTable SET BackupInfo = 'Sucess' WHERE BackupId = " & code
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
    End Sub
    Public Function BackupInfo() As DataTable
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT COUNT(*) AS [Total Record],(SELECT BackupDate FROM BackupTable WHERE BackupTable.RecId= (SELECT MAX(RecId) FROM BackupTable)) AS [Last Backup] FROM BackupTable"
        Dim dbconnection As DbConnection = New DbConnection()
        Try
            dbconnection.ConnectDatabase()
            datatable = dbconnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbconnection.CloseDatabase()
        End Try
        Return datatable
    End Function
    Public Function AllBackupInfo() As DataTable
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT BackupId AS [Backup No],BackupDate AS [Backup Date Time],BackupPath AS [Backup Path],BackupUser AS [Backup Computer],BackupInfo AS [Backup Log] FROM BackupTable"
        Dim dbconnection As DbConnection = New DbConnection()
        Try
            dbconnection.ConnectDatabase()
            datatable = dbconnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbconnection.CloseDatabase()
        End Try
        Return datatable
    End Function
End Class
