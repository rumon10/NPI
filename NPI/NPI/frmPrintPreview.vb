Public Class frmPrintPreview
    Private _message As MessageBoxUser = New MessageBoxUser()
    Public PrintPreviewData As DataGridView
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        PrintPreviewData = Me.GetPrintPreviewData()
    End Sub
    Private Function GetPrintPreviewData() As DataGridView
        Try
            Dim personal As PersonInformationBAL = New PersonInformationBAL()
            Dim data As DataTable = personal.LoadAllInformation()
            dgvPrintPrview.DataSource = Nothing
            dgvPrintPrview.DataSource = data
            dgvPrintPrview.Columns("Person No").Width = 60
            dgvPrintPrview.Columns("Person No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrintPrview.Columns("First Name").Width = 80
            dgvPrintPrview.Columns("Last Name").Width = 80
            dgvPrintPrview.Columns("Sex").Width = 45
            dgvPrintPrview.Columns("DOB").Width = 55
            dgvPrintPrview.Columns("DOB").DefaultCellStyle.Format = "yyyy/MM/dd"
            dgvPrintPrview.Columns("DOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrintPrview.Columns("Height").Width = 45
            dgvPrintPrview.Columns("Weight").Width = 45
            dgvPrintPrview.Columns("Eyes").Width = 60
            dgvPrintPrview.Columns("Hair").Width = 60
            dgvPrintPrview.Columns("Address").Width = 100
            dgvPrintPrview.Columns("POB").Width = 40
            dgvPrintPrview.Columns("Phone").Width = 60
            dgvPrintPrview.Columns("FPS").Width = 50
            dgvPrintPrview.Columns("Comments").Width = 70
            dgvPrintPrview.Columns("Phone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrintPrview.Columns("Weight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrintPrview.Columns("Height").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrintPrview.Columns("Create Date").Visible = False
            dgvPrintPrview.Height = 26
            If dgvPrintPrview.Rows.Count > 0 Then
                dgvPrintPrview.Height = (dgvPrintPrview.RowCount * 22) + 26
            End If
        Catch ex As Exception
            _message.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return dgvPrintPrview
    End Function
End Class