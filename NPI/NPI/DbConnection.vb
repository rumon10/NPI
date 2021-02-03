Imports System.Data.OleDb
Imports System.IO

Public Class DbConnection

    ' Initialization Object '
    Dim _oleConnection As OleDbConnection
    Dim _oleCommand As OleDbCommand
    Dim _oleTransaction As OleDbTransaction
    Dim currentdic As String = Directory.GetCurrentDirectory()

    ' Initialization connection string of access database'
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + currentdic + "\\NIP.mdb;Jet OLEDB:Database Password=opexinfo"

    'Define database connection function'
    Public Function ConnectDatabase()

        _oleConnection = New OleDbConnection(ConnectionString)

        Try

            _oleConnection.Open()
            _oleCommand = _oleConnection.CreateCommand()

        Catch ex As Exception
            If _oleConnection.State = ConnectionState.Open Then
                _oleConnection.Close()
            End If

        End Try

        Return Nothing
    End Function

    'Define database execute nonquery function'
    Public Function ExecuteNonQuery(ByVal queryString As String)
        _oleCommand.CommandText = queryString

        Try
            _oleCommand.CommandTimeout = 80
            _oleCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex

        End Try

        Return Nothing
    End Function

    'Define database execute query function'
    Public Function ExecuteQuery(ByVal queryString As String) As DataTable
        Dim dataset As DataSet = New DataSet()

        Try
            Dim myAdapter As OleDbDataAdapter = New OleDbDataAdapter(queryString, _oleConnection)
            myAdapter.Fill(dataset)
            Return dataset.Tables(0)

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    'Define database close function'
    Public Function CloseDatabase()
        If _oleConnection.State = ConnectionState.Open Then
            _oleConnection.Close()
        End If

        Return Nothing
    End Function

    Public Function SetNullDate(ByVal query As String)
        _oleCommand = New OleDbCommand(query, _oleConnection)
        With _oleCommand.Parameters
            .Add("@DOBB", DBNull.Value)
        End With
        _oleCommand.ExecuteNonQuery()
        Return Nothing
    End Function

End Class
