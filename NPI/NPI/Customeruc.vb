Public Class Customeruc
    Private Sub Customeruc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gendercombo.SelectedIndex = 0
    End Sub

    Private Sub continuebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles continuebtn.Click
        If firstnametxt.Text = String.Empty Then
            MessageBox.Show("Customer first name required", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

       
        firstname = firstnametxt.Text
        lastname = lastnametxt.Text
        gender = gendercombo.Text
        custaddress = custaddresstxt.Text
        custphoneno = custphonenumbertxt.Text

        Try

            Dim catalogueuc As catalogueuc = New catalogueuc()
            Dim customeruc As Customeruc = New Customeruc()
            Controls.Clear()
            Controls.Remove(customeruc)
            catalogueuc.Left = (ClientSize.Width - catalogueuc.Width) / 2
            catalogueuc.Top = (ClientSize.Height - catalogueuc.Height) / 2
            Controls.Add(catalogueuc)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
End Class
