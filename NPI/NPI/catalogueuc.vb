Public Class catalogueuc
    Public prodname As String = ""

    Private Sub catalogueuc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 1 To 20
            productqtycombo.Items.Add(i)
        Next
        productqtycombo.SelectedIndex = 0

        firstnamelbl.Text = firstname & " " & lastname
        Addresslbl.Text = custaddress

    End Sub

    Private Sub cricketbatrad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cricketsetrad.CheckedChanged, cricketglovesrad.CheckedChanged, cricketbatrad.CheckedChanged, cricketballrad.CheckedChanged, cricketarmguardrad.CheckedChanged
        If cricketbatrad.Checked = True Then
            cricketballrad.Checked = False
            cricketglovesrad.Checked = False
            cricketarmguardrad.Checked = False
            cricketsetrad.Checked = False

        ElseIf cricketballrad.Checked = True Then
            cricketbatrad.Checked = False
            cricketglovesrad.Checked = False
            cricketarmguardrad.Checked = False
            cricketsetrad.Checked = False

        ElseIf cricketglovesrad.Checked = True Then
            cricketbatrad.Checked = False
            cricketballrad.Checked = False
            cricketarmguardrad.Checked = False
            cricketsetrad.Checked = False

        ElseIf cricketarmguardrad.Checked = True Then
            cricketbatrad.Checked = False
            cricketballrad.Checked = False
            cricketglovesrad.Checked = False
            cricketsetrad.Checked = False

        ElseIf cricketsetrad.Checked = True Then
            cricketbatrad.Checked = False
            cricketballrad.Checked = False
            cricketglovesrad.Checked = False
            cricketarmguardrad.Checked = False
        End If
    End Sub

    Private Sub createinvoicebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles createinvoice.Click

        If Integer.TryParse(productqtycombo.Text, Productquanty) = False Then

            MessageBox.Show("Product quantity error!\n product quantity must be number value", "Product quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return

        End If

        productgroup.Visible = False
        firstnamelbl.Visible = True
        Addresslbl.Visible = True
        totalpricelbl.Visible = True
        vatamtlbl.Visible = True
        totalamtlbl.Visible = True
        totalpricetxt.Visible = True
        vatamttxt.Visible = True
        totalamttxt.Visible = True
        Me.Text = "Create invoice"

        'Calcuation invoice amount'
        Productquanty = Integer.Parse(productqtycombo.Text)


        If cricketbatrad.Checked = True Then
            prodname = cricketbatrad.Text
            totalprice = Productquanty * CRICKETBAT

        ElseIf cricketballrad.Checked = True Then
            prodname = cricketballrad.Text
            totalprice = Productquanty * CRICKETBATLL

        ElseIf cricketglovesrad.Checked = True Then
            prodname = cricketglovesrad.Text
            totalprice = Productquanty * GLOVES

        ElseIf cricketarmguardrad.Checked = True Then
            prodname = cricketarmguardrad.Text
            totalprice = Productquanty * ARMGUARD

        ElseIf cricketsetrad.Checked = True Then
            prodname = cricketsetrad.Text
            totalprice = Productquanty * CRICKETSET

        End If

        TOTALVAT = totalprice * VATRATE
        totalamont = totalprice + TOTALVAT

        totalpricetxt.Text = totalamont.ToString("c")
        vatamttxt.Text = TOTALVAT.ToString("c")
        totalamttxt.Text = totalamont.ToString("c")
        Try
            addInvoice()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        createinvoice.Visible = False
    End Sub

    'Storing Invoice into database'
    Public Function addInvoice()
        Dim dbconnection As DbConnection = New DbConnection()

        Try

            Dim query As String = "INSERT INTO Invoice (FirstName,LastName,Gender,Address,Phone,ProductName,ProductQty,TotalPrice,VatAmount,TotalAmount,EntryDate) VALUES ('" + firstname + "','" + lastname + "','" + gender + "','" + custaddress + "','" + custphoneno + "','" + prodname + "'," + Productquanty.ToString() + "," + totalprice.ToString() + "," + TOTALVAT.ToString() + "," + totalamont.ToString() + ",'" + Date.Now.Date.ToString("yyyy-MM-dd") + "')"
            dbconnection.ConnectDatabase()
            dbconnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex

        Finally
            dbconnection.CloseDatabase()
        End Try

        Return Nothing
    End Function

    Private Sub closebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closebtn.Click
        Dim catalogueuc As catalogueuc = New catalogueuc()
        Dim customeruc As Customeruc = New Customeruc()
        Controls.Clear()
        Controls.Remove(catalogueuc)
        customeruc.Left = (ClientSize.Width - customeruc.Width) / 2
        customeruc.Top = (ClientSize.Height - customeruc.Height) / 2
        Controls.Add(customeruc)
    End Sub
End Class
