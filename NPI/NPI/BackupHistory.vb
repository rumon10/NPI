Imports System.Drawing.Drawing2D

Public Class BackupHistory
    Private _messagebox As MessageBoxUser = New MessageBoxUser()
    Private Sub BackupHistory_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Return
            End If

            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 1)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BackupHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim backBAL As BackupBAL = New BackupBAL()
            Dim data As DataTable = backBAL.AllBackupInfo()
            dgvSucessJob.DataSource = data
            dgvSucessJob.Columns("Backup No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("Backup Date Time").DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt"
            dgvSucessJob.Columns("Backup Date Time").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            _messagebox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
End Class