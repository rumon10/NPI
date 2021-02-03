Imports System.Drawing.Drawing2D
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Word
Imports System
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Runtime.InteropServices

Public Class Find
    Private _userMessageBox As MessageBoxUser = New MessageBoxUser()
    Public dgvRow As DataGridViewRow

    Private Sub Find_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim pen As Pen = New Pen(System.Drawing.Color.FromArgb(19, 95, 152), 1)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, System.Drawing.Color.FromArgb(47, 128, 185), System.Drawing.Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        IsFound = False
        Me.Close()
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim personal As PersonInformationBAL = New PersonInformationBAL()
            Dim data As DataTable = personal.LoadAllInformation()
            dgvSucessJob.DataSource = data
            dgvSucessJob.Columns("DOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("Create Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            lblSearchResult.Text = "Search Result " + data.Rows.Count.ToString() + " record has been found"
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            dtpDateofBrith.Enabled = True
        Else
            dtpDateofBrith.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim query As String = " WHERE 0=0 "
            Dim Id As Integer = 0

            If txtFirstName.Text <> String.Empty Then
                query = query + " AND FName LIKE '%" + txtFirstName.Text + "%'"
            End If

            If txtLastName.Text <> String.Empty Then
                query = query + " AND LName LIKE '%" + txtLastName.Text + "%'"
            End If

            If CheckBox1.Checked And dtpDateofBrith.Enabled Then
                query = query + " AND FORMAT(DOB,'mm/dd/yyyy')='" + dtpDateofBrith.Value.ToString("MM/dd/yyyy") + "'"
            End If

            If txtPersonNo.Text <> String.Empty And Integer.TryParse(txtPersonNo.Text, Id) = False Then
                _userMessageBox.ShowMessageBox("Invalid Person No. Please enter valid person No.", "Person No", 1, 1)
                Return
            ElseIf txtPersonNo.Text <> String.Empty And Integer.TryParse(txtPersonNo.Text, Id) = True Then
                query = query + " AND PersonID=" & Integer.Parse(txtPersonNo.Text)
            End If
            Dim personal As PersonInformationBAL = New PersonInformationBAL()
            Dim data As DataTable = personal.LoadAllInformation(query)
            dgvSucessJob.DataSource = data
            dgvSucessJob.Columns("DOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("Create Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            lblSearchResult.Text = "Search Result " + data.Rows.Count.ToString() + " record has been found"
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub dgvSucessJob_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSucessJob.CellMouseDoubleClick
        Try
            If dgvSucessJob.RowCount > 0 And e.RowIndex > -1 Then
                IsFound = True
                dgvRow = dgvSucessJob.Rows(e.RowIndex)
                Me.Close()
            End If

        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If dgvSucessJob.Rows.Count <= 0 Then
                _userMessageBox.ShowMessageBox("No Data exists for exporting into excel.", "excel export", 1, 1)
                Return
            End If

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer
            Me.Cursor = Cursors.WaitCursor
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(1)
            xlWorkSheet = xlWorkBook.Worksheets(1)
            Dim rg As Microsoft.Office.Interop.Excel.Range
            xlWorkSheet.Name = "Address Book"


            xlWorkSheet.Range("A1:O1").Merge()
            xlWorkSheet.Range("A1:O1").Value = "Nunavut Person Information"
            xlWorkSheet.Range("A1:O1").Font.Bold = True
            xlWorkSheet.Range("A1:O1").Font.Size = 16
            xlWorkSheet.Range("A1:O1").Font.Name = "Arial"
            xlWorkSheet.Range("A1:O1").Style.HorizontalAlignment = -4108

            For i = 2 To dgvSucessJob.Columns.Count - 1
                xlWorkSheet.Cells(2, i - 1) = dgvSucessJob.Columns(i).HeaderText
                rg = xlWorkSheet.Cells(2, i - 1)
                rg.EntireColumn.AutoFit()
                rg.Font.Bold = True
            Next


            For i = 0 To dgvSucessJob.RowCount - 1
                For j = 2 To dgvSucessJob.ColumnCount - 1
                    If dgvSucessJob.Columns(j).Name = "DOB" Then
                        rg = xlWorkSheet.Cells(i + 1 + 2, j - 1)
                        rg.NumberFormatLocal = "yyyy/mm/dd"
                        rg.HorizontalAlignment = -4152
                        rg.Value2 = dgvSucessJob.Rows(i).Cells(j).Value.ToString()
                        rg.EntireColumn.AutoFit()
                    ElseIf dgvSucessJob.Columns(j).Name = "Create Date" Then
                        rg = xlWorkSheet.Cells(i + 1 + 2, j - 1)
                        rg.NumberFormatLocal = "mm/dd/yyyy"
                        rg.HorizontalAlignment = -4152
                        rg.Value2 = dgvSucessJob.Rows(i).Cells(j).Value.ToString()
                        rg.EntireColumn.AutoFit()
                    Else
                        xlWorkSheet.Cells(i + 1 + 2, j - 1) = dgvSucessJob.Rows(i).Cells(j).Value.ToString()
                        rg = xlWorkSheet.Cells(i + 1 + 2, j - 1)
                        rg.EntireColumn.AutoFit()
                    End If
                Next
            Next
            xlApp.Visible = True
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub GenerateReport(ByVal data As DataTable)
        Try
            Dim oWord As Word.Application
            Dim oDoc As Word.Document
            Dim oPara1 As Word.Paragraph, oPara2 As Word.Paragraph
            Dim oPara3 As Word.Paragraph, oPara4 As Word.Paragraph
            Dim oPara5 As Word.Paragraph
            Dim oPara6 As Word.Paragraph
            Dim oPara7 As Word.Paragraph
            Dim oPara8 As Word.Paragraph
            Dim oPara9 As Word.Paragraph
            Dim oPara10 As Word.Paragraph
            Dim oPara11 As Word.Paragraph
            Dim oPara12 As Word.Paragraph
            Dim oPara13 As Word.Paragraph
            Dim oPara14 As Word.Paragraph
            Dim oPara15 As Word.Paragraph
            Dim oPara16 As Word.Paragraph
            Dim ImageRange As Range
            'Start Word and open the document template.
            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            Dim oTable As Word.Table
            Dim oTableInner As Word.Table

            Dim threePara As String = String.Empty
            Dim fourPara As String = String.Empty
            Dim Para As String = String.Empty
            Dim mobilePara As String = String.Empty
            oPara1 = oDoc.Content.Paragraphs.Add
            oPara1.Range.Text = ""
            oPara1.Range.Font.Bold = True
            oPara1.Format.SpaceAfter = 1
            oPara1.Range.InsertParagraphAfter()
            oPara1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara2.Range.Text = "Profile Information"
            oPara2.Range.Font.Name = "Lucida Fax"
            oPara2.Range.Font.Size = 27
            oPara2.Range.Font.Color = WdColor.wdColorPlum
            oPara2.Range.Bold = True
            oPara2.Range.Font.Underline = True
            oPara2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oPara2.Format.SpaceAfter = 2
            oPara2.Range.InsertParagraphAfter()

            Dim PersonId As Integer = Integer.Parse(data.Rows(0)("Person No").ToString())
            Dim imageFile As String = GetPersonImageFile(PersonId)
            oPara12 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara12.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            oPara2.Range.Font.Underline = False
            If imageFile <> String.Empty Then
                Dim oPic As Word.InlineShape = Nothing
                oPic = oPara12.Range.InlineShapes.AddPicture(imageFile)
                oPic.Height = 100
                oPic.Width = 100
                oPara12.Format.SpaceAfter = 0
                oPic.Borders.Enable = True
            End If

            'Insert another paragraph.
            oPara3 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara3.Range.Text = "Person No: " + data.Rows(0)("Person No").ToString()
            oPara3.Range.Font.Size = 14
            oPara3.Range.Font.Name = "Lucida Fax"
            oPara3.Range.Font.Color = WdColor.wdColorBlack
            oPara3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara3.Range.Font.Bold = False
            oPara3.Format.SpaceAfter = 0
            oPara3.Range.InsertParagraphAfter()
            oPara3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

            'Insert another paragraph.
            oPara5 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara5.Range.Text = "Name: " + data.Rows(0)("First Name").ToString() + " " + data.Rows(0)("Last Name").ToString()
            oPara5.Range.Font.Size = 14
            oPara5.Range.Font.Name = "Lucida Fax"
            oPara5.Range.Font.Color = WdColor.wdColorBlack
            oPara5.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara5.Range.Font.Bold = False
            oPara5.Format.SpaceAfter = 0
            oPara5.Range.InsertParagraphAfter()
            oPara5.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft



            'Insert another paragraph.
            threePara = "Sex: " + data.Rows(0)("Sex").ToString()

            While threePara.Length <= 41
                threePara = threePara + " "
            End While

            If IsDate(data.Rows(0)("DOB")) Then
                threePara = threePara + "DOB: " + Convert.ToDateTime(data.Rows(0)("DOB").ToString()).ToString("yyyy/MM/dd")
            Else
                threePara = threePara + "DOB: "
            End If

            oPara4 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara4.Range.Text = threePara
            oPara4.Range.Font.Size = 14
            oPara4.Range.Font.Name = "Lucida Fax"
            oPara4.Range.Font.Color = WdColor.wdColorBlack
            oPara4.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara4.Range.Font.Bold = False
            oPara4.Format.SpaceAfter = 0
            oPara4.Range.InsertParagraphAfter()
            oPara4.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

            'Insert another paragraph.
            fourPara = "Height: " + data.Rows(0)("Height").ToString()

            While fourPara.Length <= 40
                fourPara = fourPara + " "
            End While

            fourPara = fourPara + "Weight: " + data.Rows(0)("Weight").ToString()

            oPara6 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara6.Range.Text = fourPara
            oPara6.Range.Font.Bold = False
            oPara6.Range.Font.Size = 14
            oPara6.Range.Font.Name = "Lucida Fax"
            oPara6.Range.Font.Color = WdColor.wdColorBlack
            oPara6.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara6.Format.SpaceAfter = 0
            oPara6.Range.InsertParagraphAfter()
            oPara6.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

            'Insert another paragraph.
            Para = "Hair: " + data.Rows(0)("Hair").ToString()

            While Para.Length <= 40
                Para = Para + " "
            End While

            Para = Para + "Eyes: " + data.Rows(0)("Eyes").ToString()

            oPara7 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara7.Range.Text = Para
            oPara7.Range.Font.Bold = False
            oPara7.Range.Font.Name = "Lucida Fax"
            oPara7.Range.Font.Color = WdColor.wdColorBlack
            oPara7.Range.Font.Size = 14
            oPara7.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara7.Format.SpaceAfter = 0
            oPara7.Range.InsertParagraphAfter()
            oPara7.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

            'Insert another paragraph.
            oPara8 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara8.Range.Text = "POB: " + data.Rows(0)("POB").ToString()
            oPara8.Range.Font.Bold = False
            oPara8.Range.Font.Name = "Lucida Fax"
            oPara8.Range.Font.Color = WdColor.wdColorBlack
            oPara8.Range.Font.Size = 14
            oPara8.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara8.Format.SpaceAfter = 0
            oPara8.Range.InsertParagraphAfter()
            oPara8.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

            'Insert another paragraph.
            oPara9 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara9.Range.Text = "Address: " + data.Rows(0)("Address").ToString()
            oPara9.Range.Font.Bold = False
            oPara9.Range.Font.Name = "Lucida Fax"
            oPara9.Range.Font.Color = WdColor.wdColorBlack
            oPara9.Range.Font.Size = 14
            oPara9.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara9.Format.SpaceAfter = 0
            oPara9.Range.InsertParagraphAfter()
            oPara9.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

            'Insert another paragraph.
            mobilePara = "Phone: " + data.Rows(0)("Phone").ToString()

            While mobilePara.Length <= 37
                mobilePara = mobilePara + " "
            End While

            mobilePara = mobilePara + "FPS# " + data.Rows(0)("FPS").ToString()

            oPara10 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara10.Range.Text = mobilePara
            oPara10.Range.Font.Bold = False
            oPara10.Range.Font.Name = "Lucida Fax"
            oPara10.Range.Font.Color = WdColor.wdColorBlack
            oPara10.Range.Font.Size = 14
            oPara10.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara10.Format.SpaceAfter = 0
            oPara10.Range.InsertParagraphAfter()
            oPara10.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

            'Insert another paragraph.
            oPara11 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara11.Range.Text = "Comments: " + data.Rows(0)("Comments").ToString()
            oPara11.Range.Font.Bold = False
            oPara11.Range.Font.Name = "Lucida Fax"
            oPara11.Range.Font.Color = WdColor.wdColorBlack
            oPara11.Range.Font.Size = 14
            oPara11.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            oPara11.Format.SpaceAfter = 0
            oPara11.Range.InsertParagraphAfter()
            oPara11.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Sub GenerastePdf(ByVal data As DataTable)
        Dim pdfLocation As String = String.Empty
        pdfLocation = Directory.GetCurrentDirectory() + "\\pdf\\" + data.Rows(0)("Person No").ToString() + ".pdf"
        Try

            Dim pr As Process = New Process()

            'If File.Exists(pdfLocation) Then
            '    File.Delete(pdfLocation)
            'End If

            Dim doc As iTextSharp.text.Document = New iTextSharp.text.Document(PageSize.B5, 10, 10, 5, 5)
            Dim writer As iTextSharp.text.pdf.PdfWriter = PdfWriter.GetInstance(doc, New FileStream(pdfLocation, FileMode.Create))
            Dim footPhraseImg As Phrase = New Phrase("", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL))
            Dim footer As iTextSharp.text.HeaderFooter = New iTextSharp.text.HeaderFooter(footPhraseImg, True)
            footer.Border = iTextSharp.text.Rectangle.TOP_BORDER
            footer.Alignment = Element.ALIGN_RIGHT
            doc.Footer = footer

            doc.Open()
            Dim font22B As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 22, iTextSharp.text.Font.BOLD)
            font22B.Color = iTextSharp.text.Color.DARK_GRAY
            Dim p1 As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Profile Information", font22B)
            p1.Alignment = Element.ALIGN_CENTER
            doc.Add(New iTextSharp.text.Paragraph(p1))

            Dim PersonId As Integer = Integer.Parse(data.Rows(0)("Person No").ToString())
            Dim imageFile As String = GetPersonImageFile(PersonId)

            If imageFile <> String.Empty Then
                Dim imghead As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imageFile)
                imghead.ScaleToFit(75.0F, 75.0F)
                imghead.SpacingBefore = 5.0F
                imghead.SpacingAfter = 0.0F
                imghead.Alignment = Element.ALIGN_RIGHT
                doc.Add(imghead)
            End If

            Dim threePara As String
            Dim fourPara As String
            Dim Para As String
            Dim mobilePara As String

            threePara = "Sex: " + data.Rows(0)("Sex").ToString()
            While threePara.Length <= 30
                threePara = threePara + " "
            End While
            If IsDate(data.Rows(0)("DOB")) Then
                threePara = threePara + "DOB: " + Convert.ToDateTime(data.Rows(0)("DOB").ToString()).ToString("yyyy/MM/dd")
            Else
                threePara = threePara + "DOB: "
            End If

            fourPara = "Height: " + data.Rows(0)("Height").ToString()
            While fourPara.Length <= 30
                fourPara = fourPara + " "
            End While
            fourPara = fourPara + "Weight: " + data.Rows(0)("Weight").ToString()

            Para = "Hair: " + data.Rows(0)("Hair").ToString()
            While Para.Length <= 30
                Para = Para + " "
            End While
            Para = Para + "Eyes: " + data.Rows(0)("Eyes").ToString()

            mobilePara = "Phone: " + data.Rows(0)("Phone").ToString()
            While mobilePara.Length <= 30
                mobilePara = mobilePara + " "
            End While
            mobilePara = mobilePara + "FPS# " + data.Rows(0)("FPS").ToString()

            Dim font10B As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD)
            Dim p3 As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph(Environment.NewLine + "Person No: " + data.Rows(0)("Person No").ToString() + Environment.NewLine + "Name: " + data.Rows(0)("First Name").ToString() + " " + data.Rows(0)("Last Name").ToString() + Environment.NewLine + threePara + Environment.NewLine + fourPara + Environment.NewLine + Para + Environment.NewLine + "POB: " + data.Rows(0)("POB").ToString() + Environment.NewLine + "Address: " + data.Rows(0)("Address").ToString() + Environment.NewLine + mobilePara + Environment.NewLine + "Comments: " + data.Rows(0)("Comments").ToString() + "", font10B)
            p3.Alignment = Element.ALIGN_JUSTIFIED
            doc.Add(New iTextSharp.text.Paragraph(p3))

            doc.Close()

            pr.Start(pdfLocation)

        Catch ex As Exception
            If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
                _userMessageBox.ShowMessageBox("Please close the existing opening profile.pdf file & try again.", "Try again", 1, 3)
                Return
            End If
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Shared Function IsFileLocked(ByVal exception As Exception) As Boolean
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function
    Private Sub dgvSucessJob_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSucessJob.CellMouseClick
        Try
            If dgvSucessJob.Rows.Count > 0 And e.ColumnIndex = 1 And e.RowIndex > -1 Then
                Dim PersonNo As Integer = Integer.Parse(dgvSucessJob.Rows(e.RowIndex).Cells("Person No").Value.ToString())
                Dim person As PersonInformationBAL = New PersonInformationBAL()
                Dim data As DataTable = person.LoadPersonInformation(PersonNo)
                If data.Rows.Count <= 0 Then
                    _userMessageBox.ShowMessageBox("No Information is exists. Please try again.", "Error", 1, 4)
                End If
                Me.GenerastePdf(data)
            ElseIf dgvSucessJob.Rows.Count > 0 And e.ColumnIndex = 0 And e.RowIndex > -1 Then
                Dim PersonNo As Integer = Integer.Parse(dgvSucessJob.Rows(e.RowIndex).Cells("Person No").Value.ToString())
                Dim person As PersonInformationBAL = New PersonInformationBAL()
                Dim data As DataTable = person.LoadPersonInformation(PersonNo)
                If data.Rows.Count <= 0 Then
                    _userMessageBox.ShowMessageBox("No Information is exists. Please try again.", "Error", 1, 4)
                End If
                Me.GenerateReport(data)
            End If
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Function GetPersonImageFile(ByVal personId As Integer) As String
        Try
            Dim ImagePath = Directory.GetCurrentDirectory() + "\\Image\\" + personId.ToString() + ".png"
            If File.Exists(ImagePath) Then
                Return ImagePath
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return String.Empty
    End Function

End Class