Imports System.Drawing.Drawing2D

Public Class MessageBoxUser
    Public _DialogResult As DialogResult = Windows.Forms.DialogResult.No
    Private Sub MessageBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(0, 100, 200), 3)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width - 7, Me.Height - 29)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click, Button2.Click
        _DialogResult = Windows.Forms.DialogResult.No
        Close()
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click, Button1.Click
        _DialogResult = Windows.Forms.DialogResult.Yes
        Close()
    End Sub

    Public Function ShowMessageBox(ByVal Message As String, ByVal Title As String, ByVal button As Integer, ByVal icon As Integer)
        lblMessageText.Text = Message
        Text = Title

        If button = 2 Then
            Button2.Visible = True
            Button1.Text = "Yes"
            Button1.Location = New Point(200, 123)
        Else
            Button2.Visible = False
            Button1.Text = "Ok"
            Button1.Location = New Point(215, 123)

        End If

        If icon = 1 Then
            PictureBox2.Image = My.Resources._1376780198_administrator_info
        ElseIf icon = 2 Then
            PictureBox2.Image = My.Resources.QuestionLog
        ElseIf icon = 3 Then
            PictureBox2.Image = My.Resources.WarningLog
        Else
            PictureBox2.Image = My.Resources.ErrorLog
        End If
        Me.ShowDialog()
        Return Nothing
    End Function
End Class