Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Globalization

Public Class NPI
    Private _action As OperationAction = OperationAction.Insert
    Private _userMessageBox As MessageBoxUser = New MessageBoxUser()
    Private _status As OperationStatus = OperationStatus.NoReady
    Private _Isfind As Boolean = False
    Private CtlArray As New ArrayList
    Dim intX, intY As Integer
    Dim Xratio, Yratio As Single
    Dim createDate As Date = Date.MinValue
    Dim PersonNo As Integer = 0

    Private Sub NPI_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
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

    Private Sub NPI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ddlSex.SelectedIndex = 0
        __Npi = Me
        Try
            Dim person As PersonInformationBAL = New PersonInformationBAL()
            lblTotalRecord.Text = "Total Record :" + person.CountRecord().ToString()
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        setSizeNPosition()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.ClearAll()
        __Npi = Me
    End Sub
    Private Function ClearAll()
        Me._action = OperationAction.Insert
        txtAddress.Text = String.Empty
        txtComeent.Text = String.Empty
        lblCreateDate.Text = String.Empty
        txtEyes.Text = String.Empty
        txtFirstName.Text = String.Empty
        txtFps.Text = String.Empty
        txtHair.Text = String.Empty
        txtHeight.Text = String.Empty
        txtImage.Text = String.Empty
        pcImage.Image = Nothing
        txtLastName.Text = String.Empty
        lblPersonNo.Text = String.Empty
        txtPhone.Text = String.Empty
        txtPob.Text = String.Empty
        txtWeight.Text = String.Empty
        dtpDateofBrith.CustomFormat = " "
        PersonNo = 0
        createDate = Date.MinValue
        lblCreateDate.Text = "Record Entry Date"
        lblPersonNo.Text = "New Person No"
        _Isfind = False
        Return Nothing
    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If _status = OperationStatus.Ready Then
                If IsValidatedInformation() = True Then
                    Dim IsDOBNull As Boolean = True
                    Dim personBO As PersonalInformationBO = New PersonalInformationBO()

                    personBO.Address = txtAddress.Text
                    personBO.Comments = txtComeent.Text

                    If dtpDateofBrith.Text.Trim() = String.Empty Or dtpDateofBrith.CustomFormat = " " Then
                        IsDOBNull = True
                    Else
                        IsDOBNull = False
                        personBO.DOB = dtpDateofBrith.Value
                    End If

                    personBO.Eyes = txtEyes.Text
                    personBO.FirstName = txtFirstName.Text
                    personBO.FPS = txtFps.Text
                    personBO.Hair = txtHair.Text
                    personBO.Height = txtHeight.Text
                    personBO.LastName = txtLastName.Text
                    personBO.PersonNo = PersonNo
                    personBO.Phone = txtPhone.Text
                    personBO.POB = txtPob.Text
                    personBO.Sex = ddlSex.Text
                    personBO.Weight = txtWeight.Text

                    Dim personal As PersonInformationBAL = New PersonInformationBAL()

                    If _action = OperationAction.Insert Then
                        personal.addInformation(personBO, IsDOBNull)
                        Me.saveImage()
                        lblTotalRecord.Text = "Total Record :" + personal.CountRecord().ToString()
                        _userMessageBox.ShowMessageBox("New person information successfully saved.", "Save", 1, 1)

                        Me.ClearAll()
                        Me.DisableAllFields()
                        _status = OperationStatus.NoReady

                    ElseIf _action = OperationAction.Edit And _Isfind = True Then
                        personal.UpdateInformation(personBO, IsDOBNull)
                        Me.saveImage()
                        lblTotalRecord.Text = "Total Record :" + personal.CountRecord().ToString()
                        _userMessageBox.ShowMessageBox("Sucessfully person Information is Updated.", "Save", 1, 1)

                        Me.ClearAll()
                        Me.DisableAllFields()
                        _status = OperationStatus.NoReady
                    End If

                End If
            End If
            __Npi = Me
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Function IsValidatedInformation() As Boolean
        Dim IsVadiation As Boolean = True
        If txtFirstName.Text = String.Empty Then
            _userMessageBox.ShowMessageBox("First Name can not blank. please enter the person first name.", "First Name", 1, 1)
            txtFirstName.Focus()
            IsVadiation = False
        ElseIf PersonNo = 0 Then
            _userMessageBox.ShowMessageBox("Person no# can not blank. please generate the new person no#.", "Person No.", 1, 1)
            IsVadiation = False
        Else
            IsVadiation = True
        End If
        Return IsVadiation
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.EnableAllFields()
        Me.ClearAll()
        Me.CreateNewIDNDate()
        _status = OperationStatus.Ready
        __Npi = Me
    End Sub
    Private Function CreateNewIDNDate()
        Try
            Dim personal As PersonInformationBAL = New PersonInformationBAL()
            PersonNo = Convert.ToInt32(personal.GetId())
            lblPersonNo.Text = "Person No :" + PersonNo.ToString()

            createDate = Date.Now
            lblCreateDate.Text = "Entry Date :" + createDate.ToString("MM/dd/yyyy")

        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function
    Private Function EnableAllFields()
        Button1.Enabled = True
        txtAddress.Enabled = True
        txtComeent.Enabled = True
        txtEyes.Enabled = True
        txtFirstName.Enabled = True
        txtFps.Enabled = True
        txtHair.Enabled = True
        txtHeight.Enabled = True
        txtImage.Enabled = True
        txtLastName.Enabled = True
        txtPhone.Enabled = True
        txtPob.Enabled = True
        txtWeight.Enabled = True
        dtpDateofBrith.Enabled = True
        ddlSex.Enabled = True
        txtLastName.Focus()
        Return Nothing
    End Function

    Private Function DisableAllFields()
        Button1.Enabled = False
        txtAddress.Enabled = False
        txtComeent.Enabled = False
        txtEyes.Enabled = False
        txtFirstName.Enabled = False
        txtFps.Enabled = False
        txtHair.Enabled = False
        txtHeight.Enabled = False
        txtImage.Enabled = False
        txtLastName.Enabled = False
        txtPhone.Enabled = False
        txtPob.Enabled = False
        txtWeight.Enabled = False
        ddlSex.Enabled = False
        dtpDateofBrith.Enabled = False
        Return Nothing
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If PersonNo <> 0 Then
            Me.EnableAllFields()
            _status = OperationStatus.Ready
            __Npi = Me
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ItemImgofd.ShowDialog() <> DialogResult.Cancel Then
                txtImage.Text = ItemImgofd.FileName
                DisplayImage(ItemImgofd.FileName)
            End If

        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Function DisplayImage(ByVal imagepath As String)
        Try
            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(imagepath, IO.FileMode.Open, IO.FileAccess.Read)
            pcImage.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim find As Find = New Find()
        Dim PersonId As Integer
        find.ShowDialog()
        If IsFound = True And find.dgvRow IsNot Nothing Then
            IsFound = False
            _Isfind = True
            _action = OperationAction.Edit
            Dim dgv As DataGridViewRow = find.dgvRow
            txtAddress.Text = dgv.Cells("Address").Value.ToString()
            txtComeent.Text = dgv.Cells("Comments").Value.ToString()
            lblCreateDate.Text = "Entry Date :" + dgv.Cells("Create Date").FormattedValue.ToString()
            txtEyes.Text = dgv.Cells("Eyes").Value.ToString()
            txtFirstName.Text = dgv.Cells("First Name").Value.ToString()
            txtFps.Text = dgv.Cells("FPS").Value.ToString()
            txtHair.Text = dgv.Cells("Hair").Value.ToString()
            txtHeight.Text = dgv.Cells("Height").Value.ToString()
            txtLastName.Text = dgv.Cells("Last Name").Value.ToString()

            PersonId = Convert.ToInt32(dgv.Cells("Person No").Value.ToString())
            lblPersonNo.Text = "Person No :" + dgv.Cells("Person No").Value.ToString()
            PersonNo = PersonId

            txtPhone.Text = dgv.Cells("Phone").Value.ToString()
            txtPob.Text = dgv.Cells("POB").Value.ToString()
            txtWeight.Text = dgv.Cells("Weight").Value.ToString()

            If IsDate(dgv.Cells("DOB").Value) Then
                dtpDateofBrith.Value = Convert.ToDateTime(dgv.Cells("DOB").Value.ToString())
            Else
                dtpDateofBrith.CustomFormat = " "
            End If

            ddlSex.Text = dgv.Cells("Sex").Value.ToString()

            Dim Imagepath As String = Directory.GetCurrentDirectory() + "\\Image\\" + PersonNo.ToString() + ".png"

            If PersonNo <> 0 And File.Exists(Imagepath) Then
                DisplayImage(Imagepath)
            Else
                pcImage.Image = Nothing
            End If

        End If
        __Npi = Me
    End Sub
    Private Sub setSizeNPosition()
        intX = Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        intY = Screen.PrimaryScreen.Bounds.Height
        'These are my design screen resolutions, but should work with other resolutions too
        'Xratio = intX / 1024
        'Yratio = intY / 768

        Xratio = 1
        Yratio = 1

        'Gets the controls on the form, including menus, but not the controls in other containers
        For Each Cnt As Control In Me.Parent.Controls
            If Cnt.Name <> "ToolStrip1" And Cnt.Name <> "StatusStrip1" Then
                CtlArray.Add(Cnt)
            End If
        Next
        'Get the children controls
        GetTheChildren()
        'Adjust New size and position
        ResizeThem()
    End Sub
    Private Sub GetTheChildren()
        'Gets the controls inside containes like panels or tabcontrols
        'For Each ctl As Control In GetAllControls(Me.Parent)
        For Each ctl As Control In GetAllControls(Me)
            If ctl.Parent IsNot Me Then
                If TypeOf ctl.Parent Is TabPage Then
                    If ctl.Name = "" Then
                        CtlArray.Add(ctl)
                    Else
                        CtlArray.Add(ctl)
                    End If
                Else
                    If Not TypeOf (ctl) Is TabPage Then
                        If ctl.Name = "" Then
                            CtlArray.Add(ctl)
                        Else
                            CtlArray.Add(ctl)
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    Function GetAllControls(ByVal container As Control) As Control()
        Dim al As New ArrayList
        Dim ctl As Control
        For Each ctl In container.Controls
            GetControlsWithChildren(ctl, al)
        Next
        Return al.ToArray(GetType(Control))
    End Function

    Sub GetControlsWithChildren(ByVal container As Control, ByVal al As ArrayList)
        ' add this control to the ArrayList
        al.Add(container)
        ' add all its child controls, by calling this routine recursively
        Dim ctl As Control

        For Each ctl In container.Controls
            'A TabPage is a Panel; SplitContainer is a Panel
            GetControlsWithChildren(ctl, al)
        Next

    End Sub
    Private Sub ResizeThem()
        Dim i As Integer
        For i = 0 To CtlArray.Count - 1
            If TypeOf CtlArray.Item(i) Is MenuStrip Then
            Else
                If TypeOf CtlArray.Item(i) Is Panel And CtlArray.Item(i).parent IsNot Me Then
                    'SplitPanel for instance
                Else
                    CtlArray.Item(i).autosize = False
                    CtlArray.Item(i).dock = 0
                    CtlArray.Item(i).width = CtlArray.Item(i).width * Xratio
                    CtlArray.Item(i).left = CtlArray.Item(i).left * Xratio
                    CtlArray.Item(i).height = CtlArray.Item(i).height * Yratio
                    CtlArray.Item(i).top = CtlArray.Item(i).top * Yratio
                End If
            End If
        Next
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If _Isfind = True And PersonNo <> 0 Then
                _userMessageBox.ShowMessageBox("Do you want to delete the information of person no-" + PersonNo.ToString() + "?", "Delete Information", 2, 2)
                If _userMessageBox._DialogResult = DialogResult.Yes Then
                    Dim personId As Integer = PersonNo
                    Dim person As PersonInformationBAL = New PersonInformationBAL()
                    person.DeletePersonInformation(personId)
                    lblTotalRecord.Text = "Total Record :" + person.CountRecord().ToString()
                    _userMessageBox.ShowMessageBox("Sucessfully Deleted the information of Person No " + PersonNo.ToString() + ".", "Delete Information", 1, 1)
                    Me.ClearAll()
                    Me.DisableAllFields()
                    __Npi = Me
                End If
            End If
        Catch ex As Exception
            _userMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub dtpDateofBrith_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateofBrith.ValueChanged
        dtpDateofBrith.CustomFormat = "yyyy/MM/dd"
    End Sub

    Private Sub ClearDates_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDateofBrith.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Delete) Or (e.KeyCode = Windows.Forms.Keys.Back) Then
            Dim mDateTimePicker As Windows.Forms.DateTimePicker
            mDateTimePicker = TryCast(sender, Windows.Forms.DateTimePicker)
            If Not (mDateTimePicker Is Nothing) Then
                mDateTimePicker.CustomFormat = " "
            End If
        End If
    End Sub
    Private Function saveImage()
        If txtImage.Text <> String.Empty And PersonNo <> 0 Then
            Dim imagepath = Directory.GetCurrentDirectory() + "\\image\\" + PersonNo.ToString() + ".png"
            Try
                If File.Exists(imagepath) Then
                    File.Delete(imagepath)
                End If
                Image.FromFile(ItemImgofd.FileName).Save(imagepath)
                ItemImgofd.FileName = ""
            Catch ex As Exception
                pcImage.Image.Save(imagepath)
            End Try
        End If
        Return Nothing
    End Function
End Class
