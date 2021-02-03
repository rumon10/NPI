Public Class RestoreBAL
    Public Sub insertBackupRecord(ByVal Restore As RestoreBO)
        Dim query As String = "INSERT INTO RestoreTable (RestoreId,RestoreDate,RestoreUser) VALUES ('" + Restore.RestoreId + "','" + Date.Now.ToString("yyyy/MM/dd hh:mm tt") + "','" + Restore.RestoreUser + "')"
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
End Class
