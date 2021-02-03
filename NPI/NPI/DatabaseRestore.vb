Imports System.Drawing.Drawing2D
Imports System.IO
Public Class DatabaseRestore
    Private _messageBox As MessageBoxUser = New MessageBoxUser()
    Private Sub DatabaseRestore_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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
        If OpenFileDialog1.ShowDialog() <> DialogResult.Cancel Then
            txtBackupPath.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtBackupPath.Text.Trim() = String.Empty Or OpenFileDialog1.FileName.Trim() = String.Empty Then
            _messageBox.ShowMessageBox("To start restore of Nunavut Person Information system need to select past backup database. Please first select the database path.", "Database path Required", 1, 3)
            Return
        End If

        If Me.GetDatabase() = String.Empty Then
            _messageBox.ShowMessageBox("System is now unable to restore the database. Please try again.", "Restore Failed", 1, 4)
            Application.Exit()
        End If

        Dim destinationPath As String = Me.GetDatabase() + "NIP_NEW.mdb"
        Dim databasePath As String = Me.GetDatabase() + "NIP.mdb"
        Dim RestoreId As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim count As Integer = 1
        Dim aricheDir As String = Me.GetRestorePath()
        Dim arichePath As String = aricheDir + RestoreId + ".mdb"
        Dim RestoreFileId As String = DateTime.Now.ToString("yyyy-MM-dd")
        Try
            If File.Exists(destinationPath) Then
                File.Delete(destinationPath)
            End If
            File.Copy(txtBackupPath.Text, destinationPath)

            While File.Exists(arichePath)
                arichePath = aricheDir + RestoreId + "_" & count & ".mdb"
                RestoreFileId = RestoreId + "_" & count
                count = count + 1
            End While

            File.Move(databasePath, arichePath)
            My.Computer.FileSystem.RenameFile(destinationPath, "NIP.mdb")

            Dim restore As RestoreBO = New RestoreBO()
            restore.RestoreUser = Environment.UserName
            restore.RestoreId = RestoreFileId
            Dim RestoreBAL As RestoreBAL = New RestoreBAL()
            RestoreBAL.insertBackupRecord(restore)
            _messageBox.ShowMessageBox("Nunavut Person Information System Database has Sucessfully Restored.", "Restore Sucess", 1, 1)
            txtBackupPath.Text = String.Empty
        Catch ex As Exception
            _messageBox.ShowMessageBox("System is now unable to restore the database. Please try again.", "Restore Failed", 1, 4)
            Return
        End Try
    End Sub
    Private Function GetRestorePath() As String
        Return Directory.GetCurrentDirectory() + "\\archive\\"
    End Function
    Private Function GetDatabase() As String
        Return Directory.GetCurrentDirectory() + "\\"
    End Function
End Class