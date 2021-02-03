Imports System.Drawing.Drawing2D
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Security.AccessControl
Imports System.Security.Principal

Public Class NPIcricketshop
    Private _messageBox As MessageBoxUser = New MessageBoxUser()
    Private _printPreviewDatagridview As DataGridView

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreatePermission()
        pnlHeader.Width = Me.Width
        llbLogindatetime.Text = DateAndTime.Now.ToString("F")
        Dim NPIUc As NPI = New NPI()
        TableLayoutPanel1.Width = NPIUc.Width
        TableLayoutPanel1.Height = NPIUc.Height
        TableLayoutPanel1.Top = (Me.Height - NPIUc.Height - 30) / 2
        TableLayoutPanel1.Left = (Me.Width - NPIUc.Width) / 2
        TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TableLayoutPanel1.Controls.Add(NPIUc)
    End Sub
    Private Sub NPIcricketshop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim pen As Pen = New Pen(Color.Transparent, 0)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStrip1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ToolStrip1.Paint
        Try
            Dim pen As Pen = New Pen(Color.Transparent, 0)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.ToolStrip1.Width, Me.ToolStrip1.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(30, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub StatusStrip1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles StatusStrip1.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 1)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.StatusStrip1.Width, Me.StatusStrip1.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(30, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click
        Try
            Dim customeruc As NPI = New NPI()
            customeruc = __Npi
            customeruc.Button3.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel2.Click
        Try
            Dim customeruc As NPI = New NPI()
            customeruc = __Npi
            customeruc.Button5.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel3.Click
        Try
            Dim customeruc As NPI = New NPI()
            customeruc = __Npi
            customeruc.Button4.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel4.Click
        Try
            Dim customeruc As NPI = New NPI()
            customeruc = __Npi
            customeruc.Button6.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Dim customeruc As NPI = New NPI()
            customeruc = __Npi
            customeruc.Button2.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Dim customeruc As NPI = New NPI()
            customeruc = __Npi
            customeruc.btnDelete.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Dim version As Version = New Version()
        version.ShowDialog()
    End Sub

    Private Sub excelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles excelExport.Click
        Me.excelExporting()
    End Sub
    Private Sub excelExporting()
        Try
            Dim personal As PersonInformationBAL = New PersonInformationBAL()
            Dim data As DataTable = personal.LoadAllInformation()
            dataLog.DataSource = Nothing
            dataLog.DataSource = data

            dataLog.Columns("Person No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("Phone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("Weight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("Height").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("DOB").DefaultCellStyle.Format = "yyyy/MM/dd"
            dataLog.Columns("DOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("Create Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            dataLog.Columns("Create Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            If dataLog.Rows.Count <= 0 Then
                _messageBox.ShowMessageBox("No data exists for exporting into excel.", "Excel Export Log", 1, 1)
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

            For i = 0 To dataLog.Columns.Count - 1
                xlWorkSheet.Cells(2, i + 1) = dataLog.Columns(i).HeaderText
                rg = xlWorkSheet.Cells(2, i + 1)
                rg.EntireColumn.AutoFit()
                rg.Font.Bold = True
            Next


            For i = 0 To dataLog.RowCount - 1
                For j = 0 To dataLog.ColumnCount - 1
                    If dataLog.Columns(j).Name = "DOB" Then
                        rg = xlWorkSheet.Cells(i + 1 + 2, j + 1)
                        rg.NumberFormatLocal = "yyyy/mm/dd"
                        rg.HorizontalAlignment = -4152
                        rg.Value2 = dataLog.Rows(i).Cells(j).Value.ToString()
                        rg.EntireColumn.AutoFit()
                    ElseIf dataLog.Columns(j).Name = "Create Date" Then
                        rg = xlWorkSheet.Cells(i + 1 + 2, j + 1)
                        rg.NumberFormatLocal = "mm/dd/yyyy"
                        rg.HorizontalAlignment = -4152
                        rg.Value2 = dataLog.Rows(i).Cells(j).Value.ToString()
                        rg.EntireColumn.AutoFit()
                    ElseIf dataLog.Columns(j).Name = "Person No" Or dataLog.Columns(j).Name = "Phone" Then
                        rg = xlWorkSheet.Cells(i + 1 + 2, j + 1)
                        rg.HorizontalAlignment = -4152
                        rg.Value2 = dataLog.Rows(i).Cells(j).Value.ToString()
                        rg.EntireColumn.AutoFit()
                    ElseIf dataLog.Columns(j).Name = "Weight" Or dataLog.Columns(j).Name = "Height" Then
                        rg = xlWorkSheet.Cells(i + 1 + 2, j + 1)
                        rg.HorizontalAlignment = -4152
                        rg.Value2 = dataLog.Rows(i).Cells(j).Value.ToString()
                        rg.EntireColumn.AutoFit()
                    Else
                        xlWorkSheet.Cells(i + 1 + 2, j + 1) = dataLog.Rows(i).Cells(j).Value.ToString()
                        rg.HorizontalAlignment = -4131
                        rg = xlWorkSheet.Cells(i + 1 + 2, j + 1)
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
            Me.Cursor = Cursors.Arrow
            _messageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
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

    Private Sub DBAdministrator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBAdministrator.Click
        Dim Backup As DatabaseSystem = New DatabaseSystem()
        Backup.Show()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        GeneratePdf()
    End Sub
    Private Sub GeneratePdf()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim personal As PersonInformationBAL = New PersonInformationBAL()
            Dim data As DataTable = personal.LoadAllInformation()
            dataLog.DataSource = Nothing
            dataLog.DataSource = data

            dataLog.Columns("Person No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("Phone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("Weight").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("Height").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("DOB").DefaultCellStyle.Format = "yyyy/MM/dd"
            dataLog.Columns("DOB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dataLog.Columns("Create Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            dataLog.Columns("Create Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            If dataLog.Rows.Count <= 0 Then
                _messageBox.ShowMessageBox("No data exists for exporting into excel.", "Excel Export Log", 1, 1)
                Return
            End If

            Dim test As pdfGenewration = New pdfGenewration()
            test.btnGeneratePDFFile_Click(dataLog)
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            _messageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim data As frmPrintPreview = New frmPrintPreview()
        dataLog = data.PrintPreviewData
        'MessageBox.Show(_printPreviewDatagridview.Columns.Count.ToString())
        prnPreview.Document = prnDocument
        prnPreview.PrintPreviewControl.Zoom = 1
        prnPreview.ShowDialog()
    End Sub
    Private Sub prnDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prnDocument.PrintPage
        Dim dataGridViewImage As Bitmap = New Bitmap(Me.dataLog.Width, Me.dataLog.Height)
        dataLog.DrawToBitmap(dataGridViewImage, New Rectangle(0, 0, dataLog.Width, dataLog.Height))
        e.Graphics.DrawImage(dataGridViewImage, 0, 0)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Dim restore As DatabaseRestore = New DatabaseRestore()
        restore.Show()
    End Sub
    Private Sub CreatePermission()
        Try
            Dim appPath As String = Path.GetDirectoryName(Application.ExecutablePath)
            
            'Code for DB Permission
            Dim dbFilePath As String = appPath + "\\NIP.mdb"
            Dim aFiles As String() = Directory.GetFiles(appPath)

            Dim fileName As String = dbFilePath
            Dim fSecurity As FileSecurity = File.GetAccessControl(fileName)
            fSecurity.AddAccessRule(New FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow))

            'Code for DB Permission
            Dim pdfPath As String = appPath + "\\pdf"
            fileName = pdfPath
            fSecurity = File.GetAccessControl(fileName)
            fSecurity.AddAccessRule(New FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow))

            'Code for Image Permission
            Dim imagePath As String = appPath + "\\image"
            fileName = imagePath
            fSecurity = File.GetAccessControl(fileName)
            fSecurity.AddAccessRule(New FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow))

        Catch ex As Exception
            _messageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
End Class
