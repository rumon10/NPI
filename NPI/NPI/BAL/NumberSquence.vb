Imports System.Data
Public Class NumberSquence

    Public Shared Function GetNextCode(ByVal numberType As String) As String
        Dim query As String = ""
        Dim datatable As DataTable = New DataTable()
        Dim _dbConnection As DbConnection = New DbConnection()
        Dim NumberId As String = String.Empty

        Dim updatequery As String = "UPDATE Numbers SET NumberID=NumberID+1 WHERE Type='" + numberType + "'"
        query = "SELECT NumberID FROM Numbers WHERE Type='" + numberType + "'"

        Try
            _dbConnection.ConnectDatabase()
            datatable = _dbConnection.ExecuteQuery(query)

            If datatable.Rows.Count > 0 Then
                NumberId = datatable.Rows(0)(0).ToString()
                _dbConnection.ExecuteNonQuery(updatequery)
            Else
                Dim InsertQery As String = "INSERT INTO Numbers (NumberID,Type) VALUES (1000,'" + numberType + "')"
                _dbConnection.ExecuteNonQuery(InsertQery)
                datatable = _dbConnection.ExecuteQuery(query)
                If datatable.Rows.Count > 0 Then
                    NumberId = datatable.Rows(0)(0).ToString()
                    _dbConnection.ExecuteNonQuery(updatequery)
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            _dbConnection.CloseDatabase()
        End Try
        Return NumberId
    End Function
End Class
