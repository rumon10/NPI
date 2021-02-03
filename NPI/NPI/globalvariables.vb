Module globalvariables
    'storing variables for the customer details
    Public firstname As String
    Public lastname As String
    Public gender As String
    Public custaddress As String
    Public custphoneno As String
    'variable for the quantity value
    Public Productquanty As Integer
    'variable for the total price of the product
    Public totalprice As Decimal
    'variable for the total amount including vat
    Public totalamont As Decimal

    'constant variable for products of the store
    Public Const CRICKETBAT As Decimal = 100
    Public Const CRICKETBATLL As Decimal = 50
    Public Const GLOVES As Decimal = 20
    Public Const ARMGUARD As Decimal = 30
    Public Const CRICKETSET As Decimal = 200

    'constant variable for the vat rate
    Public Const VATRATE As Decimal = 0.2
    'variable the total vat amount of the product
    Public TOTALVAT As Decimal
    Public IsFound As Boolean = False
    Public __Npi As NPI
End Module

Enum OperationAction
    Insert
    Delete
    Edit
    Search
End Enum
Enum OperationStatus
    Ready
    NoReady
    None
End Enum
