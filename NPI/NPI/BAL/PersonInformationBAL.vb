Public Class PersonInformationBAL
    Public Function GetId() As String
        Me.UpateID()
        Dim orderId As String = "0"
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT NumberID FROM Numbers WHERE Type='ID'"
        Dim dbconnection As DbConnection = New DbConnection()
        Try
            dbconnection.ConnectDatabase()
            datatable = dbconnection.ExecuteQuery(query)
            If datatable.Rows.Count > 0 Then
                orderId = datatable.Rows(0)(0).ToString()
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dbconnection.CloseDatabase()
        End Try
        Return orderId
    End Function
    Private Function UpateID()
        Dim query As String = "UPDATE Numbers SET NumberID=NumberID+1 WHERE Type='ID'"
        Dim dbconnection As DbConnection = New DbConnection()
        Try
            dbconnection.ConnectDatabase()
            dbconnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbconnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function addInformation(ByVal customerInfo As PersonalInformationBO, ByVal IsDOBNull As Boolean)
        Dim query As String = String.Empty
        If IsDOBNull = False Then
            query = "INSERT INTO PersonInformation (PersonID,FName,LName,DOB,[Height],[Weight],Eyes,Hair,[Sex],[Address],[POB],[Phone],[FPS],Comments,CreateDate) VALUES (" & customerInfo.PersonNo & ",'" + customerInfo.FirstName + "','" + customerInfo.LastName + "','" + customerInfo.DOB.ToString("MM/dd/yyyy") + "','" + customerInfo.Height + "','" + customerInfo.Weight + "','" + customerInfo.Eyes + "','" + customerInfo.Hair + "','" + customerInfo.Sex + "','" + customerInfo.Address + "','" + customerInfo.POB + "','" + customerInfo.Phone + "','" + customerInfo.FPS + "','" + customerInfo.Comments + "','" + Date.Now.ToString("yyyy-MM-dd") + "')"
        Else
            query = "INSERT INTO PersonInformation (PersonID,FName,LName,[Height],[Weight],Eyes,Hair,[Sex],[Address],[POB],[Phone],[FPS],Comments,CreateDate) VALUES (" & customerInfo.PersonNo & ",'" + customerInfo.FirstName + "','" + customerInfo.LastName + "','" + customerInfo.Height + "','" + customerInfo.Weight + "','" + customerInfo.Eyes + "','" + customerInfo.Hair + "','" + customerInfo.Sex + "','" + customerInfo.Address + "','" + customerInfo.POB + "','" + customerInfo.Phone + "','" + customerInfo.FPS + "','" + customerInfo.Comments + "','" + Date.Now.ToString("yyyy-MM-dd") + "')"
        End If

        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)

        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function UpdateInformation(ByVal customerInfo As PersonalInformationBO, ByVal IsDOBNull As Boolean)
        Dim query As String = String.Empty
        If IsDOBNull = False Then
            query = "UPDATE PersonInformation SET FName='" + customerInfo.FirstName + "',LName='" + customerInfo.LastName + "',DOB='" + customerInfo.DOB.ToString("MM/dd/yyyy") + "',[Height]='" + customerInfo.Height + "',[Weight]='" + customerInfo.Weight + "',Eyes='" + customerInfo.Eyes + "',Hair='" + customerInfo.Hair + "',[Sex]='" + customerInfo.Sex + "',[Address]='" + customerInfo.Address + "',[POB]='" + customerInfo.POB + "',[Phone]='" + customerInfo.Phone + "',[FPS]='" + customerInfo.FPS + "',Comments='" + customerInfo.Comments + "' WHERE PersonID=" & customerInfo.PersonNo
        Else
            Me.CallingParameter(customerInfo.PersonNo)
            query = "UPDATE PersonInformation SET FName='" + customerInfo.FirstName + "',LName='" + customerInfo.LastName + "',[Height]='" + customerInfo.Height + "',[Weight]='" + customerInfo.Weight + "',Eyes='" + customerInfo.Eyes + "',Hair='" + customerInfo.Hair + "',[Sex]='" + customerInfo.Sex + "',[Address]='" + customerInfo.Address + "',[POB]='" + customerInfo.POB + "',[Phone]='" + customerInfo.Phone + "',[FPS]='" + customerInfo.FPS + "',Comments='" + customerInfo.Comments + "' WHERE PersonID=" & customerInfo.PersonNo
        End If

        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)

        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function LoadAllInformation() As DataTable
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT PersonID AS [Person No],FName AS [First Name],LName AS [Last Name],[Sex],FORMAT(DOB,'yyyy/mm/dd') AS [DOB],[Height],[Weight],Eyes,Hair,[Address],[POB],[Phone],[FPS],Comments,FORMAT(CreateDate,'mm/dd/yyyy') AS [Create Date] FROM PersonInformation ORDER BY PersonID ASC"
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

    Public Function LoadAllInformation(ByVal condition As String) As DataTable
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT PersonID AS [Person No],FName AS [First Name],LName AS [Last Name],FORMAT(DOB,'yyyy/mm/dd') AS [DOB],[Height],[Weight],Eyes,Hair,[Sex],[Address],[POB],[Phone],[FPS],Comments,FORMAT(CreateDate,'mm/dd/yyyy') AS [Create Date] FROM PersonInformation " + condition + " ORDER BY PersonID ASC"
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
    Public Function CountRecord() As Integer
        Dim orderId As Integer = 0
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT COUNT(*) FROM PersonInformation"
        Dim dbconnection As DbConnection = New DbConnection()
        Try
            dbconnection.ConnectDatabase()
            datatable = dbconnection.ExecuteQuery(query)
            If datatable.Rows.Count > 0 Then
                orderId = datatable.Rows(0)(0).ToString()
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dbconnection.CloseDatabase()
        End Try
        Return orderId
    End Function
    Public Function DeletePersonInformation(ByVal personNo As Integer)
        Dim query As String = "DELETE FROM PersonInformation WHERE PersonID=" & personNo
        Dim dbconnection As DbConnection = New DbConnection()
        Try
            dbconnection.ConnectDatabase()
            dbconnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbconnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Private Function CallingParameter(ByVal PersonId As Integer)
        Dim query As String = "UPDATE PersonInformation SET DOB=@DOBB WHERE PersonID=" & PersonId
        Dim DbConnection As DbConnection = New DbConnection()
        DbConnection.ConnectDatabase()
        DbConnection.SetNullDate(query)
        DbConnection.CloseDatabase()
        Return Nothing
    End Function
    Public Function LoadPersonInformation(ByVal personId As Integer) As DataTable
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT PersonID AS [Person No],FName AS [First Name],LName AS [Last Name],FORMAT(DOB,'yyyy/mm/dd') AS [DOB],[Height],[Weight],Eyes,Hair,[Sex],[Address],[POB],[Phone],[FPS],Comments,FORMAT(CreateDate,'mm/dd/yyyy') AS [Create Date] FROM PersonInformation WHERE PersonID=" & personId
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
