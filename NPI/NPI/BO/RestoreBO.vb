Public Class RestoreBO
    Private _restoreUser As String = "Empty"
    Property RestoreUser As String
        Get
            Return _restoreUser
        End Get
        Set(ByVal value As String)
            _restoreUser = value
        End Set
    End Property
    Private _restoreId As String = String.Empty
    Property RestoreId As String
        Get
            Return _restoreId
        End Get
        Set(ByVal value As String)
            _restoreId = value
        End Set
    End Property
End Class
