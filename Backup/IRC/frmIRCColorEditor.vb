Imports System.drawing
Imports System.Windows.Forms
Public Class frmIRCColorEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblIRCColorPreview As System.Windows.Forms.Label
    Friend WithEvents tlbColors As System.Windows.Forms.ToolBar
    Friend WithEvents ilsIRCColorEdit As System.Windows.Forms.ImageList
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblRTF As System.Windows.Forms.Label
    Friend WithEvents txtRTFTxt As System.Windows.Forms.RichTextBox
    Friend WithEvents txtmIRCTxt As System.Windows.Forms.TextBox
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdBold As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdUnderline As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd8 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd9 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd10 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd11 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd12 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd13 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd14 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd15 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmd16 As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIRCColorEditor))
        Me.txtRTFTxt = New System.Windows.Forms.RichTextBox
        Me.txtmIRCTxt = New System.Windows.Forms.TextBox
        Me.lblIRCColorPreview = New System.Windows.Forms.Label
        Me.tlbColors = New System.Windows.Forms.ToolBar
        Me.cmdBold = New System.Windows.Forms.ToolBarButton
        Me.cmdUnderline = New System.Windows.Forms.ToolBarButton
        Me.cmd1 = New System.Windows.Forms.ToolBarButton
        Me.cmd2 = New System.Windows.Forms.ToolBarButton
        Me.cmd3 = New System.Windows.Forms.ToolBarButton
        Me.cmd4 = New System.Windows.Forms.ToolBarButton
        Me.cmd5 = New System.Windows.Forms.ToolBarButton
        Me.cmd6 = New System.Windows.Forms.ToolBarButton
        Me.cmd7 = New System.Windows.Forms.ToolBarButton
        Me.cmd8 = New System.Windows.Forms.ToolBarButton
        Me.cmd9 = New System.Windows.Forms.ToolBarButton
        Me.cmd10 = New System.Windows.Forms.ToolBarButton
        Me.cmd11 = New System.Windows.Forms.ToolBarButton
        Me.cmd12 = New System.Windows.Forms.ToolBarButton
        Me.cmd13 = New System.Windows.Forms.ToolBarButton
        Me.cmd14 = New System.Windows.Forms.ToolBarButton
        Me.cmd15 = New System.Windows.Forms.ToolBarButton
        Me.cmd16 = New System.Windows.Forms.ToolBarButton
        Me.ilsIRCColorEdit = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblRTF = New System.Windows.Forms.Label
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtRTFTxt
        '
        Me.txtRTFTxt.Location = New System.Drawing.Point(0, 48)
        Me.txtRTFTxt.Multiline = False
        Me.txtRTFTxt.Name = "txtRTFTxt"
        Me.txtRTFTxt.Size = New System.Drawing.Size(544, 24)
        Me.txtRTFTxt.TabIndex = 0
        Me.txtRTFTxt.Text = ""
        '
        'txtmIRCTxt
        '
        Me.txtmIRCTxt.Location = New System.Drawing.Point(0, 88)
        Me.txtmIRCTxt.Name = "txtmIRCTxt"
        Me.txtmIRCTxt.Size = New System.Drawing.Size(176, 20)
        Me.txtmIRCTxt.TabIndex = 1
        Me.txtmIRCTxt.Text = ""
        Me.txtmIRCTxt.Visible = False
        '
        'lblIRCColorPreview
        '
        Me.lblIRCColorPreview.AutoSize = True
        Me.lblIRCColorPreview.Location = New System.Drawing.Point(0, 72)
        Me.lblIRCColorPreview.Name = "lblIRCColorPreview"
        Me.lblIRCColorPreview.Size = New System.Drawing.Size(179, 16)
        Me.lblIRCColorPreview.TabIndex = 2
        Me.lblIRCColorPreview.Text = "Текст с кодами форматирования"
        Me.lblIRCColorPreview.Visible = False
        '
        'tlbColors
        '
        Me.tlbColors.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbColors.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdBold, Me.cmdUnderline, Me.cmd1, Me.cmd2, Me.cmd3, Me.cmd4, Me.cmd5, Me.cmd6, Me.cmd7, Me.cmd8, Me.cmd9, Me.cmd10, Me.cmd11, Me.cmd12, Me.cmd13, Me.cmd14, Me.cmd15, Me.cmd16})
        Me.tlbColors.Dock = System.Windows.Forms.DockStyle.None
        Me.tlbColors.DropDownArrows = True
        Me.tlbColors.ImageList = Me.ilsIRCColorEdit
        Me.tlbColors.Location = New System.Drawing.Point(0, 16)
        Me.tlbColors.Name = "tlbColors"
        Me.tlbColors.ShowToolTips = True
        Me.tlbColors.Size = New System.Drawing.Size(544, 28)
        Me.tlbColors.TabIndex = 3
        '
        'cmdBold
        '
        Me.cmdBold.ImageIndex = 16
        Me.cmdBold.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdBold.Tag = "50"
        '
        'cmdUnderline
        '
        Me.cmdUnderline.ImageIndex = 17
        Me.cmdUnderline.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdUnderline.Tag = "51"
        '
        'cmd1
        '
        Me.cmd1.ImageIndex = 0
        Me.cmd1.Tag = "1"
        '
        'cmd2
        '
        Me.cmd2.ImageIndex = 1
        Me.cmd2.Tag = "2"
        '
        'cmd3
        '
        Me.cmd3.ImageIndex = 2
        Me.cmd3.Tag = "3"
        '
        'cmd4
        '
        Me.cmd4.ImageIndex = 3
        Me.cmd4.Tag = "4"
        '
        'cmd5
        '
        Me.cmd5.ImageIndex = 4
        Me.cmd5.Tag = "5"
        '
        'cmd6
        '
        Me.cmd6.ImageIndex = 5
        Me.cmd6.Tag = "6"
        '
        'cmd7
        '
        Me.cmd7.ImageIndex = 6
        Me.cmd7.Tag = "7"
        '
        'cmd8
        '
        Me.cmd8.ImageIndex = 7
        Me.cmd8.Tag = "8"
        '
        'cmd9
        '
        Me.cmd9.ImageIndex = 8
        Me.cmd9.Tag = "9"
        '
        'cmd10
        '
        Me.cmd10.ImageIndex = 9
        Me.cmd10.Tag = "10"
        '
        'cmd11
        '
        Me.cmd11.ImageIndex = 10
        Me.cmd11.Tag = "11"
        '
        'cmd12
        '
        Me.cmd12.ImageIndex = 11
        Me.cmd12.Tag = "12"
        '
        'cmd13
        '
        Me.cmd13.ImageIndex = 12
        Me.cmd13.Tag = "13"
        '
        'cmd14
        '
        Me.cmd14.ImageIndex = 13
        Me.cmd14.Tag = "14"
        '
        'cmd15
        '
        Me.cmd15.ImageIndex = 14
        Me.cmd15.Tag = "15"
        '
        'cmd16
        '
        Me.cmd16.ImageIndex = 15
        Me.cmd16.Tag = "16"
        '
        'ilsIRCColorEdit
        '
        Me.ilsIRCColorEdit.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsIRCColorEdit.ImageStream = CType(resources.GetObject("ilsIRCColorEdit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsIRCColorEdit.TransparentColor = System.Drawing.Color.Transparent
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(352, 80)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(88, 24)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(448, 80)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 24)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Отмена"
        '
        'lblRTF
        '
        Me.lblRTF.AutoSize = True
        Me.lblRTF.Location = New System.Drawing.Point(0, 0)
        Me.lblRTF.Name = "lblRTF"
        Me.lblRTF.Size = New System.Drawing.Size(71, 16)
        Me.lblRTF.TabIndex = 6
        Me.lblRTF.Text = "Ввод текста:"
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(184, 88)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(80, 20)
        Me.cmdCopy.TabIndex = 7
        Me.cmdCopy.Text = "Копировать"
        Me.cmdCopy.Visible = False
        '
        'frmIRCColorEditor
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(546, 111)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.lblRTF)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblIRCColorPreview)
        Me.Controls.Add(Me.tlbColors)
        Me.Controls.Add(Me.txtmIRCTxt)
        Me.Controls.Add(Me.txtRTFTxt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIRCColorEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Редактор цветного текста"
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmIRCColorEditor
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmIRCColorEditor
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmIRCColorEditor
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmIRCColorEditor)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Public RText As String
    Private Sub tlbColors_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbColors.ButtonClick
        Dim sstart As Integer
        Dim slength As Integer
        Select Case e.Button.Tag
            Case 50, 51
                SetFontParams(txtRTFTxt, cmdBold.Pushed, False, cmdUnderline.Pushed)
            Case 1 To 16
                txtRTFTxt.SelectionColor = Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(e.Button.Tag) - 1))
                SetFontParams(txtRTFTxt, cmdBold.Pushed, False, cmdUnderline.Pushed)
        End Select
    End Sub
    Public Sub SetFontParams(ByVal rtfTextBox As RichTextBox, ByVal Bold As Boolean, ByVal Ital As Boolean, ByVal Under As Boolean, Optional ByVal FontName As String = "", Optional ByVal FontSize As Integer = 0)
        Dim currentFont As System.Drawing.Font = rtfTextBox.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        newFontStyle = FontStyle.Regular
        If Ital = True Then newFontStyle = CType(newFontStyle + System.Drawing.FontStyle.Italic, FontStyle)
        If Bold = True Then newFontStyle = CType(newFontStyle + System.Drawing.FontStyle.Bold, FontStyle)
        If Under = True Then newFontStyle = CType(newFontStyle + System.Drawing.FontStyle.Underline, FontStyle)


        If FontName <> "" Then currentFont = New Font(FontName, currentFont.Size, currentFont.Style)
        If FontSize > 0 Then currentFont = New Font(FontName, FontSize, currentFont.Style)

        rtfTextBox.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
    End Sub

    Private Sub txtRTFTxt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRTFTxt.TextChanged
        If cmdCopy.Visible = True Then
            txtmIRCTxt.Text = DC2Conv.RTFToDC2(txtRTFTxt.Rtf)
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        txtmIRCTxt.Text = DC2Conv.RTFToDC2(txtRTFTxt.Rtf)
        RText = txtmIRCTxt.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lblRTF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRTF.DoubleClick
        lblIRCColorPreview.Visible = Not lblIRCColorPreview.Visible
        txtmIRCTxt.Visible = Not txtmIRCTxt.Visible
        cmdCopy.Visible = Not cmdCopy.Visible
    End Sub

    Private Sub frmIRCColorEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  Me.txtRTFTxt.Font = New Font(IRC_Settings.IRCFont, IRC_Settings.IRCFontSize)
    End Sub
End Class
