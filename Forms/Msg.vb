' DZFS.NET 2003
' DChat Project
' Message Send Form

Option Explicit On 

Friend Class frmMessage
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
		
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents lblMsgInfo As System.Windows.Forms.Label
    Friend WithEvents pnlUsers As System.Windows.Forms.Panel
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents lstUsers As System.Windows.Forms.TreeView
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents txtMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents cmdPrivat As System.Windows.Forms.Button
    Friend WithEvents cmdCit As System.Windows.Forms.Button
    Friend WithEvents cmdAnswer As System.Windows.Forms.Button
    Friend WithEvents chkToChat As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents splMsg As System.Windows.Forms.Splitter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessage))
        Me.lblMsgInfo = New System.Windows.Forms.Label
        Me.pnlUsers = New System.Windows.Forms.Panel
        Me.lstUsers = New System.Windows.Forms.TreeView
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.txtMessage = New System.Windows.Forms.RichTextBox
        Me.pnlButtons = New System.Windows.Forms.Panel
        Me.cmdOk = New System.Windows.Forms.Button
        Me.lblLine = New System.Windows.Forms.Label
        Me.cmdPrivat = New System.Windows.Forms.Button
        Me.cmdCit = New System.Windows.Forms.Button
        Me.cmdAnswer = New System.Windows.Forms.Button
        Me.chkToChat = New System.Windows.Forms.CheckBox
        Me.splMsg = New System.Windows.Forms.Splitter
        Me.pnlUsers.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMsgInfo
        '
        Me.lblMsgInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMsgInfo.Location = New System.Drawing.Point(0, 0)
        Me.lblMsgInfo.Name = "lblMsgInfo"
        Me.lblMsgInfo.Size = New System.Drawing.Size(384, 13)
        Me.lblMsgInfo.TabIndex = 6
        Me.lblMsgInfo.Text = "Сообщение: 0/3000"
        '
        'pnlUsers
        '
        Me.pnlUsers.Controls.Add(Me.lstUsers)
        Me.pnlUsers.Controls.Add(Me.cmdRefresh)
        Me.pnlUsers.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlUsers.Location = New System.Drawing.Point(0, 13)
        Me.pnlUsers.Name = "pnlUsers"
        Me.pnlUsers.Size = New System.Drawing.Size(96, 136)
        Me.pnlUsers.TabIndex = 11
        '
        'lstUsers
        '
        Me.lstUsers.CheckBoxes = True
        Me.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstUsers.ImageIndex = -1
        Me.lstUsers.Location = New System.Drawing.Point(0, 0)
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.SelectedImageIndex = -1
        Me.lstUsers.ShowLines = False
        Me.lstUsers.ShowPlusMinus = False
        Me.lstUsers.ShowRootLines = False
        Me.lstUsers.Size = New System.Drawing.Size(96, 120)
        Me.lstUsers.TabIndex = 8
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(0, 120)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(96, 16)
        Me.cmdRefresh.TabIndex = 7
        Me.cmdRefresh.Text = "Обновить"
        '
        'pnlMsg
        '
        Me.pnlMsg.Controls.Add(Me.txtMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMsg.Location = New System.Drawing.Point(100, 13)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(284, 136)
        Me.pnlMsg.TabIndex = 12
        '
        'txtMessage
        '
        Me.txtMessage.AcceptsTab = True
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.Location = New System.Drawing.Point(0, 0)
        Me.txtMessage.MaxLength = 3000
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(284, 136)
        Me.txtMessage.TabIndex = 0
        Me.txtMessage.Text = ""
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.cmdOk)
        Me.pnlButtons.Controls.Add(Me.lblLine)
        Me.pnlButtons.Controls.Add(Me.cmdPrivat)
        Me.pnlButtons.Controls.Add(Me.cmdCit)
        Me.pnlButtons.Controls.Add(Me.cmdAnswer)
        Me.pnlButtons.Controls.Add(Me.chkToChat)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 149)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(384, 40)
        Me.pnlButtons.TabIndex = 13
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOk.Location = New System.Drawing.Point(8, 12)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(48, 24)
        Me.cmdOk.TabIndex = 17
        Me.cmdOk.Text = "Ok"
        '
        'lblLine
        '
        Me.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLine.Location = New System.Drawing.Point(0, 5)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(632, 2)
        Me.lblLine.TabIndex = 14
        '
        'cmdPrivat
        '
        Me.cmdPrivat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrivat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPrivat.Location = New System.Drawing.Point(104, 12)
        Me.cmdPrivat.Name = "cmdPrivat"
        Me.cmdPrivat.Size = New System.Drawing.Size(86, 24)
        Me.cmdPrivat.TabIndex = 13
        Me.cmdPrivat.Text = "&Разговор"
        '
        'cmdCit
        '
        Me.cmdCit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCit.Location = New System.Drawing.Point(296, 12)
        Me.cmdCit.Name = "cmdCit"
        Me.cmdCit.Size = New System.Drawing.Size(86, 24)
        Me.cmdCit.TabIndex = 11
        Me.cmdCit.Text = "&Цитировать"
        '
        'cmdAnswer
        '
        Me.cmdAnswer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAnswer.Location = New System.Drawing.Point(200, 12)
        Me.cmdAnswer.Name = "cmdAnswer"
        Me.cmdAnswer.Size = New System.Drawing.Size(88, 24)
        Me.cmdAnswer.TabIndex = 12
        Me.cmdAnswer.Text = "&Ответить"
        '
        'chkToChat
        '
        Me.chkToChat.Location = New System.Drawing.Point(8, 16)
        Me.chkToChat.Name = "chkToChat"
        Me.chkToChat.Size = New System.Drawing.Size(104, 16)
        Me.chkToChat.TabIndex = 15
        Me.chkToChat.Text = "В канал"
        Me.chkToChat.Visible = False
        '
        'splMsg
        '
        Me.splMsg.Location = New System.Drawing.Point(96, 13)
        Me.splMsg.Name = "splMsg"
        Me.splMsg.Size = New System.Drawing.Size(4, 136)
        Me.splMsg.TabIndex = 14
        Me.splMsg.TabStop = False
        '
        'frmMessage
        '
        Me.AcceptButton = Me.cmdAnswer
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(384, 189)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.splMsg)
        Me.Controls.Add(Me.pnlUsers)
        Me.Controls.Add(Me.lblMsgInfo)
        Me.Controls.Add(Me.pnlButtons)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Отправка сообщения"
        Me.pnlUsers.ResumeLayout(False)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region



    Private Sub pnlButtons_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlButtons.Paint

    End Sub

    Private Sub frmMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtMessage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessage.TextChanged

    End Sub

End Class