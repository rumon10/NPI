Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Runtime.InteropServices

Public Class pdfGenewration
    Private _messageBox As MessageBoxUser = New MessageBoxUser()

    Public Sub btnGeneratePDFFile_Click(ByVal data As DataGridView)
        Dim pdfLocation As String = Directory.GetCurrentDirectory() + "\\pdf\\ProfileAll.pdf"
        Dim doc As Document = New Document()
        Dim tableLayout As New PdfPTable(data.Columns.Count - 1)
        Dim pr As Process = New Process()
        Try
            If File.Exists(pdfLocation) Then
                File.Delete(pdfLocation)
            End If
        Catch ex As Exception
            If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
                _messageBox.ShowMessageBox("Please close the existing opening profile.pdf file & try again.", "Try again", 1, 3)
                Return
            End If
        End Try

        Try
            PdfWriter.GetInstance(doc, New FileStream(Directory.GetCurrentDirectory() + "\\pdf\\ProfileAll.pdf", FileMode.Create))
            doc.Open()
            doc.Add(Add_Content_To_PDF(tableLayout, data))
            doc.Close()
            pr.Start(pdfLocation)
        Catch ex As Exception
            _messageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Function Add_Content_To_PDF(ByVal tableLayout As PdfPTable, ByVal data As DataGridView) As PdfPTable
        Try
            Dim headers As Single() = {17, 20, 20, 15, 15, 15, 15, 15, 15, 30, 15, 20, 15, 30}
            tableLayout.SetWidths(headers)
            tableLayout.WidthPercentage = 109
            tableLayout.AddCell(New PdfPCell(New Phrase("Nunavut Person Information", New Font(Font.HELVETICA, 14, 1, New iTextSharp.text.Color(153, 51, 0)))) With {
             .Colspan = data.Columns.Count - 1, _
             .Border = 0, _
             .PaddingBottom = 20, _
             .HorizontalAlignment = Element.ALIGN_CENTER _
            })

            Dim j As Integer = 0
            Dim i As Integer = 0

            For i = 0 To data.Columns.Count - 2
                AddCellToHeader(tableLayout, data.Columns(i).HeaderText)
            Next

            For i = 0 To data.Rows.Count - 1
                For j = 0 To data.Columns.Count - 2
                    If data.Columns(j).Name = "Person No" Or data.Columns(j).Name = "DOB" Or data.Columns(j).Name = "Height" Or data.Columns(j).Name = "Weight" Or data.Columns(j).Name = "Phone" Then
                        AddCellToBodyRight(tableLayout, data.Rows(i).Cells(j).FormattedValue.ToString())
                    Else
                        AddCellToBodyLeft(tableLayout, data.Rows(i).Cells(j).FormattedValue.ToString())
                    End If

                Next
            Next
        Catch ex As Exception
            Throw
        End Try
        Return tableLayout
    End Function
    Private Sub AddCellToHeader(ByVal tableLayout As PdfPTable, ByVal cellText As String)
        Try
            tableLayout.AddCell(New PdfPCell(New Phrase(cellText, New Font(Font.HELVETICA, 6, 0, iTextSharp.text.Color.WHITE))) With { _
         .HorizontalAlignment = Element.ALIGN_CENTER, _
         .Padding = 3, _
         .BackgroundColor = New iTextSharp.text.Color(0, 51, 102) _
        })
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub AddCellToBody(ByVal tableLayout As PdfPTable, ByVal cellText As String)
        Try
            tableLayout.AddCell(New PdfPCell(New Phrase(cellText, New Font(Font.HELVETICA, 5, 1, iTextSharp.text.Color.BLACK))) With { _
         .HorizontalAlignment = Element.ALIGN_CENTER, _
         .Padding = 3, _
         .BackgroundColor = iTextSharp.text.Color.WHITE _
        })
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub AddCellToBodyLeft(ByVal tableLayout As PdfPTable, ByVal cellText As String)
        Try
            tableLayout.AddCell(New PdfPCell(New Phrase(cellText, New Font(Font.HELVETICA, 5, 1, iTextSharp.text.Color.BLACK))) With { _
         .HorizontalAlignment = Element.ALIGN_LEFT, _
         .Padding = 3, _
         .BackgroundColor = iTextSharp.text.Color.WHITE _
        })
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub AddCellToBodyRight(ByVal tableLayout As PdfPTable, ByVal cellText As String)
        Try
            tableLayout.AddCell(New PdfPCell(New Phrase(cellText, New Font(Font.HELVETICA, 5, 1, iTextSharp.text.Color.BLACK))) With { _
         .HorizontalAlignment = Element.ALIGN_RIGHT, _
         .Padding = 3, _
         .BackgroundColor = iTextSharp.text.Color.WHITE _
        })
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Function IsFileLocked(ByVal exception As Exception) As Boolean
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function
End Class
