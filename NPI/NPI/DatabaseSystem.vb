Imports System.Drawing.Drawing2D
Imports System.IO
Public Class DatabaseSystem
    Private _messageBox As MessageBoxUser = New MessageBoxUser()

    Private Sub DatabaseSystem_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If BackupfD.ShowDialog() <> DialogResult.Cancel Then
            txtBackupPath.Text = BackupfD.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtBackupPath.Text.Trim() = String.Empty Or BackupfD.SelectedPath.Trim() = String.Empty Then
            _messageBox.ShowMessageBox("To start backup of Nunavut Person Information system need to select a sucure path. Please first select the database path.", "Backup path Required", 1, 3)
            Return
        End If
        Dim count As Integer = 1

        Try
            Dim backPath As String = txtBackupPath.Text + "\\NIP.mdb"

            While File.Exists(backPath)
                backPath = txtBackupPath.Text + "\\NIP_" & count & ".mdb"
                count = count + 1
            End While

            Dim Backup As BackupBO = New BackupBO()
            Backup.BackupPath = backPath
            Backup.BackupUser = Environment.UserName
            Backup.NumberId = NumberSquence.GetNextCode("Backup")
            Dim backBAL As BackupBAL = New BackupBAL()
            backBAL.insertBackupRecord(Backup)
            File.Copy(Me.GetDbPath(), backPath)
            backBAL.updatetBackupRecord(Backup.NumberId)
            _messageBox.ShowMessageBox("Nunavut Person Information System Database has Sucessfully backuped " + backPath + ".", "Backup Sucess", 1, 1)
            txtBackupPath.Text = String.Empty
            BackupfD.SelectedPath = String.Empty
            Me.GetRecodInfo()
        Catch ex As Exception
            _messageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Function GetDbPath() As String
        Return Directory.GetCurrentDirectory() + "\\NIP.mdb"
    End Function

    Private Sub DatabaseSystem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GetRecodInfo()
    End Sub
    Private Sub GetRecodInfo()
        Try
            Dim backupBAL As BackupBAL = New BackupBAL()
            Dim data As DataTable = backupBAL.BackupInfo()
            If data.Rows.Count > 0 Then
                lblBackupCompleted.Text = "No. of Backup Completed : " + data.Rows(0)("Total Record").ToString()
                If IsDBNull(data.Rows(0)("Last Backup")) Then
                    lblLastBackup.Text = "Last Backup Completed : No"
                Else
                    lblLastBackup.Text = "Last Backup Completed : " + Convert.ToDateTime(data.Rows(0)("Last Backup")).ToString("MM/dd/yyyy hh:mm tt")
                End If
            End If
        Catch ex As Exception
            _messageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim back As BackupHistory = New BackupHistory()
        back.Show()
    End Sub
End Class