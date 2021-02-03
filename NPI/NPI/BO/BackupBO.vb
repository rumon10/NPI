Public Class BackupBO
    Private _backupUser As String = "Empty"
    Property BackupUser As String
        Get
            Return _backupUser
        End Get
        Set(ByVal value As String)
            _backupUser = value
        End Set
    End Property
    Private _backupPath As String = "Empty"
    Property BackupPath As String
        Get
            Return _backupPath
        End Get
        Set(ByVal value As String)
            _backupPath = value
        End Set
    End Property
    Private _NumberId As Integer = 0
    Property NumberId As Integer
        Get
            Return _NumberId
        End Get
        Set(ByVal value As Integer)
            _NumberId = value
        End Set
    End Property
End Class
