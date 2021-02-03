Public Class PersonalInformationBO
    Private _firstName As String = "Empty"
    Property FirstName As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property


    Private _lastName As String = "Empty"
    Property LastName As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    Private _hair As String = "Empty"
    Property Hair As String
        Get
            Return _hair
        End Get
        Set(ByVal value As String)
            _hair = value
        End Set
    End Property
    Private _eyes As String = "Empty"
    Property Eyes As String
        Get
            Return _eyes
        End Get
        Set(ByVal value As String)
            _eyes = value
        End Set
    End Property

    Private _sex As String = "Empty"
    Property Sex As String
        Get
            Return _sex
        End Get
        Set(ByVal value As String)
            _sex = value
        End Set
    End Property
    Private _DOB As Date
    Property DOB As Date
        Get
            Return _DOB
        End Get
        Set(ByVal value As Date)
            _DOB = value
        End Set
    End Property

    Private _pob As String = "Empty"
    Property POB As String
        Get
            Return _pob
        End Get
        Set(ByVal value As String)
            _pob = value
        End Set
    End Property

    Private _height As String = "Empty"
    Property Height As String
        Get
            Return _height
        End Get
        Set(ByVal value As String)
            _height = value
        End Set
    End Property

    Private _weight As String = "Empty"
    Property Weight As String
        Get
            Return _weight
        End Get
        Set(ByVal value As String)
            _weight = value
        End Set
    End Property

    Private _address As String = "Empty"
    Property Address As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property

    Private _phone As String = 0
    Property Phone As String
        Get
            Return _phone
        End Get
        Set(ByVal value As String)
            _phone = value
        End Set
    End Property

    Private _fPS As String = "Empty"
    Property FPS As String
        Get
            Return _fPS
        End Get
        Set(ByVal value As String)
            _fPS = value
        End Set
    End Property

    Private _comments As String = "Empty"
    Property Comments As String
        Get
            Return _comments
        End Get
        Set(ByVal value As String)
            _comments = value
        End Set
    End Property

    Private _personNo As Integer = 0
    Property PersonNo As Integer
        Get
            Return _personNo
        End Get
        Set(ByVal value As Integer)
            _personNo = value
        End Set
    End Property

End Class
