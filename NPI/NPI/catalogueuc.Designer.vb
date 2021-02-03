<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class catalogueuc
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(catalogueuc))
        Me.closebtn = New System.Windows.Forms.Button()
        Me.createinvoice = New System.Windows.Forms.Button()
        Me.productqtycombo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.productgroup = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.cricketsetrad = New System.Windows.Forms.RadioButton()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.cricketarmguardrad = New System.Windows.Forms.RadioButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cricketglovesrad = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cricketballrad = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cricketbatrad = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Addresslbl = New System.Windows.Forms.Label()
        Me.firstnamelbl = New System.Windows.Forms.Label()
        Me.totalamttxt = New System.Windows.Forms.TextBox()
        Me.totalamtlbl = New System.Windows.Forms.Label()
        Me.vatamttxt = New System.Windows.Forms.TextBox()
        Me.vatamtlbl = New System.Windows.Forms.Label()
        Me.totalpricetxt = New System.Windows.Forms.TextBox()
        Me.totalpricelbl = New System.Windows.Forms.Label()
        Me.productgroup.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'closebtn
        '
        Me.closebtn.FlatAppearance.BorderSize = 2
        Me.closebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.closebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closebtn.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closebtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.closebtn.Location = New System.Drawing.Point(600, 470)
        Me.closebtn.Name = "closebtn"
        Me.closebtn.Size = New System.Drawing.Size(119, 40)
        Me.closebtn.TabIndex = 23
        Me.closebtn.Text = "Close"
        Me.closebtn.UseVisualStyleBackColor = True
        '
        'createinvoice
        '
        Me.createinvoice.FlatAppearance.BorderSize = 2
        Me.createinvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.createinvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.createinvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.createinvoice.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createinvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.createinvoice.Location = New System.Drawing.Point(448, 470)
        Me.createinvoice.Name = "createinvoice"
        Me.createinvoice.Size = New System.Drawing.Size(146, 40)
        Me.createinvoice.TabIndex = 22
        Me.createinvoice.Text = "Create Invoice"
        Me.createinvoice.UseVisualStyleBackColor = True
        '
        'productqtycombo
        '
        Me.productqtycombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.productqtycombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.productqtycombo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.productqtycombo.FormattingEnabled = True
        Me.productqtycombo.Location = New System.Drawing.Point(568, 208)
        Me.productqtycombo.Name = "productqtycombo"
        Me.productqtycombo.Size = New System.Drawing.Size(121, 31)
        Me.productqtycombo.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(473, 211)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 23)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Quantity:"
        '
        'productgroup
        '
        Me.productgroup.Controls.Add(Me.PictureBox5)
        Me.productgroup.Controls.Add(Me.cricketsetrad)
        Me.productgroup.Controls.Add(Me.PictureBox4)
        Me.productgroup.Controls.Add(Me.cricketarmguardrad)
        Me.productgroup.Controls.Add(Me.PictureBox3)
        Me.productgroup.Controls.Add(Me.cricketglovesrad)
        Me.productgroup.Controls.Add(Me.PictureBox2)
        Me.productgroup.Controls.Add(Me.cricketballrad)
        Me.productgroup.Controls.Add(Me.PictureBox1)
        Me.productgroup.Controls.Add(Me.cricketbatrad)
        Me.productgroup.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.productgroup.Location = New System.Drawing.Point(25, 33)
        Me.productgroup.Name = "productgroup"
        Me.productgroup.Size = New System.Drawing.Size(341, 473)
        Me.productgroup.TabIndex = 19
        Me.productgroup.TabStop = False
        Me.productgroup.Text = "Product"
        '
        'PictureBox5
        '
        Me.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(178, 369)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(123, 81)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 9
        Me.PictureBox5.TabStop = False
        '
        'cricketsetrad
        '
        Me.cricketsetrad.AutoSize = True
        Me.cricketsetrad.ForeColor = System.Drawing.Color.Black
        Me.cricketsetrad.Location = New System.Drawing.Point(39, 401)
        Me.cricketsetrad.Name = "cricketsetrad"
        Me.cricketsetrad.Size = New System.Drawing.Size(102, 23)
        Me.cricketsetrad.TabIndex = 8
        Me.cricketsetrad.Text = "Cricket Set"
        Me.cricketsetrad.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(178, 282)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(123, 81)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'cricketarmguardrad
        '
        Me.cricketarmguardrad.AutoSize = True
        Me.cricketarmguardrad.ForeColor = System.Drawing.Color.Black
        Me.cricketarmguardrad.Location = New System.Drawing.Point(39, 312)
        Me.cricketarmguardrad.Name = "cricketarmguardrad"
        Me.cricketarmguardrad.Size = New System.Drawing.Size(106, 23)
        Me.cricketarmguardrad.TabIndex = 6
        Me.cricketarmguardrad.Text = "Arm Guard"
        Me.cricketarmguardrad.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(179, 195)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(123, 81)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'cricketglovesrad
        '
        Me.cricketglovesrad.AutoSize = True
        Me.cricketglovesrad.ForeColor = System.Drawing.Color.Black
        Me.cricketglovesrad.Location = New System.Drawing.Point(36, 221)
        Me.cricketglovesrad.Name = "cricketglovesrad"
        Me.cricketglovesrad.Size = New System.Drawing.Size(74, 23)
        Me.cricketglovesrad.TabIndex = 4
        Me.cricketglovesrad.Text = "Gloves"
        Me.cricketglovesrad.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(178, 108)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(123, 79)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'cricketballrad
        '
        Me.cricketballrad.AutoSize = True
        Me.cricketballrad.ForeColor = System.Drawing.Color.Black
        Me.cricketballrad.Location = New System.Drawing.Point(36, 136)
        Me.cricketballrad.Name = "cricketballrad"
        Me.cricketballrad.Size = New System.Drawing.Size(105, 23)
        Me.cricketballrad.TabIndex = 2
        Me.cricketballrad.Text = "Cricket Ball"
        Me.cricketballrad.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(178, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(123, 81)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'cricketbatrad
        '
        Me.cricketbatrad.AutoSize = True
        Me.cricketbatrad.Checked = True
        Me.cricketbatrad.ForeColor = System.Drawing.Color.Black
        Me.cricketbatrad.Location = New System.Drawing.Point(39, 52)
        Me.cricketbatrad.Name = "cricketbatrad"
        Me.cricketbatrad.Size = New System.Drawing.Size(102, 23)
        Me.cricketbatrad.TabIndex = 0
        Me.cricketbatrad.TabStop = True
        Me.cricketbatrad.Text = "Cricket Bat"
        Me.cricketbatrad.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(232, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(245, 25)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "EThames Cricket Shop"
        '
        'Addresslbl
        '
        Me.Addresslbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Addresslbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Addresslbl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Addresslbl.ForeColor = System.Drawing.Color.Black
        Me.Addresslbl.Location = New System.Drawing.Point(411, 87)
        Me.Addresslbl.Name = "Addresslbl"
        Me.Addresslbl.Size = New System.Drawing.Size(288, 61)
        Me.Addresslbl.TabIndex = 30
        Me.Addresslbl.Text = "Label1"
        Me.Addresslbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Addresslbl.Visible = False
        '
        'firstnamelbl
        '
        Me.firstnamelbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.firstnamelbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.firstnamelbl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firstnamelbl.ForeColor = System.Drawing.Color.Black
        Me.firstnamelbl.Location = New System.Drawing.Point(411, 53)
        Me.firstnamelbl.Name = "firstnamelbl"
        Me.firstnamelbl.Size = New System.Drawing.Size(288, 34)
        Me.firstnamelbl.TabIndex = 29
        Me.firstnamelbl.Text = "Label1"
        Me.firstnamelbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.firstnamelbl.Visible = False
        '
        'totalamttxt
        '
        Me.totalamttxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalamttxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.totalamttxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totalamttxt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalamttxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.totalamttxt.Location = New System.Drawing.Point(568, 378)
        Me.totalamttxt.Name = "totalamttxt"
        Me.totalamttxt.ReadOnly = True
        Me.totalamttxt.Size = New System.Drawing.Size(121, 27)
        Me.totalamttxt.TabIndex = 47
        Me.totalamttxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.totalamttxt.Visible = False
        '
        'totalamtlbl
        '
        Me.totalamtlbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalamtlbl.AutoSize = True
        Me.totalamtlbl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalamtlbl.Location = New System.Drawing.Point(433, 384)
        Me.totalamtlbl.Name = "totalamtlbl"
        Me.totalamtlbl.Size = New System.Drawing.Size(127, 19)
        Me.totalamtlbl.TabIndex = 46
        Me.totalamtlbl.Text = "Total Amount:"
        Me.totalamtlbl.Visible = False
        '
        'vatamttxt
        '
        Me.vatamttxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.vatamttxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.vatamttxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vatamttxt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vatamttxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.vatamttxt.Location = New System.Drawing.Point(568, 339)
        Me.vatamttxt.Name = "vatamttxt"
        Me.vatamttxt.ReadOnly = True
        Me.vatamttxt.Size = New System.Drawing.Size(121, 27)
        Me.vatamttxt.TabIndex = 45
        Me.vatamttxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.vatamttxt.Visible = False
        '
        'vatamtlbl
        '
        Me.vatamtlbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.vatamtlbl.AutoSize = True
        Me.vatamtlbl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vatamtlbl.Location = New System.Drawing.Point(433, 345)
        Me.vatamtlbl.Name = "vatamtlbl"
        Me.vatamtlbl.Size = New System.Drawing.Size(118, 19)
        Me.vatamtlbl.TabIndex = 44
        Me.vatamtlbl.Text = "VAT Amount:"
        Me.vatamtlbl.Visible = False
        '
        'totalpricetxt
        '
        Me.totalpricetxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalpricetxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.totalpricetxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totalpricetxt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalpricetxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.totalpricetxt.Location = New System.Drawing.Point(568, 303)
        Me.totalpricetxt.Name = "totalpricetxt"
        Me.totalpricetxt.ReadOnly = True
        Me.totalpricetxt.Size = New System.Drawing.Size(121, 27)
        Me.totalpricetxt.TabIndex = 43
        Me.totalpricetxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.totalpricetxt.Visible = False
        '
        'totalpricelbl
        '
        Me.totalpricelbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalpricelbl.AutoSize = True
        Me.totalpricelbl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalpricelbl.Location = New System.Drawing.Point(433, 306)
        Me.totalpricelbl.Name = "totalpricelbl"
        Me.totalpricelbl.Size = New System.Drawing.Size(104, 19)
        Me.totalpricelbl.TabIndex = 42
        Me.totalpricelbl.Text = "Total Price:"
        Me.totalpricelbl.Visible = False
        '
        'catalogueuc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Controls.Add(Me.totalamttxt)
        Me.Controls.Add(Me.totalamtlbl)
        Me.Controls.Add(Me.vatamttxt)
        Me.Controls.Add(Me.vatamtlbl)
        Me.Controls.Add(Me.totalpricetxt)
        Me.Controls.Add(Me.totalpricelbl)
        Me.Controls.Add(Me.Addresslbl)
        Me.Controls.Add(Me.firstnamelbl)
        Me.Controls.Add(Me.closebtn)
        Me.Controls.Add(Me.createinvoice)
        Me.Controls.Add(Me.productqtycombo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.productgroup)
        Me.Controls.Add(Me.Label6)
        Me.Name = "catalogueuc"
        Me.Size = New System.Drawing.Size(744, 521)
        Me.productgroup.ResumeLayout(False)
        Me.productgroup.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents closebtn As System.Windows.Forms.Button
    Friend WithEvents createinvoice As System.Windows.Forms.Button
    Friend WithEvents productqtycombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents productgroup As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents cricketsetrad As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents cricketarmguardrad As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cricketglovesrad As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cricketballrad As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cricketbatrad As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Addresslbl As System.Windows.Forms.Label
    Friend WithEvents firstnamelbl As System.Windows.Forms.Label
    Friend WithEvents totalamttxt As System.Windows.Forms.TextBox
    Friend WithEvents totalamtlbl As System.Windows.Forms.Label
    Friend WithEvents vatamttxt As System.Windows.Forms.TextBox
    Friend WithEvents vatamtlbl As System.Windows.Forms.Label
    Friend WithEvents totalpricetxt As System.Windows.Forms.TextBox
    Friend WithEvents totalpricelbl As System.Windows.Forms.Label

End Class
