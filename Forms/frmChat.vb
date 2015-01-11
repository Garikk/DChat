' DZFS.NET 2005
' DChat project
' Chat Interface: Garikk

Option Explicit On 
Imports UNI_Plugin.UNI_DChat

Public Class frmChat
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
        AddHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf SysEvent

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
        RemoveHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf SysEvent

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents fraLeft As System.Windows.Forms.GroupBox
    Friend WithEvents fraRight As System.Windows.Forms.GroupBox
    Friend WithEvents cmdChangeName As System.Windows.Forms.Button
    Friend WithEvents ilsTab As System.Windows.Forms.ImageList
    Friend WithEvents txtTopic As System.Windows.Forms.RichTextBox
    Friend WithEvents txtInput As System.Windows.Forms.RichTextBox
    Friend WithEvents ilsEdit As System.Windows.Forms.ImageList
    Friend WithEvents tbsChat As System.Windows.Forms.TabControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tlbEdit As System.Windows.Forms.ToolBar
    Friend WithEvents mnuTray As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents tmrAnimator As System.Windows.Forms.Timer
    Friend WithEvents cdlChatColor As System.Windows.Forms.ColorDialog
    Friend WithEvents txtName As System.Windows.Forms.RichTextBox
    Friend WithEvents lblTopic As System.Windows.Forms.Button
    Friend WithEvents ilsTrayIcons As System.Windows.Forms.ImageList
    Friend WithEvents strDChat As System.Windows.Forms.NotifyIcon
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuUserNames As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuNam1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam6 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam7 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam8 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam9 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam0 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNam2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep9 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSetSysName As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClearUNamesMenu As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChlOpts As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuConnect As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSep As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents hlpDChat As System.Windows.Forms.HelpProvider
    Friend WithEvents tlbColors As System.Windows.Forms.ToolBar
    Friend WithEvents cmdColor1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor8 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor9 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor10 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor11 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor12 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor13 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor14 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColor15 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilsIRCColors As System.Windows.Forms.ImageList
    Friend WithEvents mnuDChatMenu As System.Windows.Forms.MainMenu
    Friend WithEvents cmdColSep As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdColChangeBCol As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdBold As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdUnderl As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdAlarmCHL As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdSndButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdSel As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlLTOP As System.Windows.Forms.Panel
    Friend WithEvents cmdUseFormatting As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdSep6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlMainInterface As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pnlToolBar As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChat))
        Me.fraLeft = New System.Windows.Forms.GroupBox
        Me.tbsChat = New System.Windows.Forms.TabControl
        Me.ilsTab = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.tlbEdit = New System.Windows.Forms.ToolBar
        Me.cmdSndButton = New System.Windows.Forms.ToolBarButton
        Me.cmdAlarmCHL = New System.Windows.Forms.ToolBarButton
        Me.cmdSel = New System.Windows.Forms.ToolBarButton
        Me.ilsEdit = New System.Windows.Forms.ImageList(Me.components)
        Me.txtTopic = New System.Windows.Forms.RichTextBox
        Me.lblTopic = New System.Windows.Forms.Button
        Me.tlbColors = New System.Windows.Forms.ToolBar
        Me.cmdUseFormatting = New System.Windows.Forms.ToolBarButton
        Me.cmdSep6 = New System.Windows.Forms.ToolBarButton
        Me.cmdBold = New System.Windows.Forms.ToolBarButton
        Me.cmdUnderl = New System.Windows.Forms.ToolBarButton
        Me.cmdColSep = New System.Windows.Forms.ToolBarButton
        Me.cmdColChangeBCol = New System.Windows.Forms.ToolBarButton
        Me.cmdColor1 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor2 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor3 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor4 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor5 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor6 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor7 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor8 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor9 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor10 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor11 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor12 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor13 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor14 = New System.Windows.Forms.ToolBarButton
        Me.cmdColor15 = New System.Windows.Forms.ToolBarButton
        Me.ilsIRCColors = New System.Windows.Forms.ImageList(Me.components)
        Me.txtInput = New System.Windows.Forms.RichTextBox
        Me.fraRight = New System.Windows.Forms.GroupBox
        Me.pnlLTOP = New System.Windows.Forms.Panel
        Me.txtName = New System.Windows.Forms.RichTextBox
        Me.cmdChangeName = New System.Windows.Forms.Button
        Me.strDChat = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.mnuTray = New System.Windows.Forms.ContextMenu
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.tmrAnimator = New System.Windows.Forms.Timer(Me.components)
        Me.cdlChatColor = New System.Windows.Forms.ColorDialog
        Me.ilsTrayIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog
        Me.mnuUserNames = New System.Windows.Forms.ContextMenu
        Me.mnuNam0 = New System.Windows.Forms.MenuItem
        Me.mnuNam1 = New System.Windows.Forms.MenuItem
        Me.mnuNam2 = New System.Windows.Forms.MenuItem
        Me.mnuNam3 = New System.Windows.Forms.MenuItem
        Me.mnuNam4 = New System.Windows.Forms.MenuItem
        Me.mnuNam5 = New System.Windows.Forms.MenuItem
        Me.mnuNam6 = New System.Windows.Forms.MenuItem
        Me.mnuNam7 = New System.Windows.Forms.MenuItem
        Me.mnuNam8 = New System.Windows.Forms.MenuItem
        Me.mnuNam9 = New System.Windows.Forms.MenuItem
        Me.mnuSep9 = New System.Windows.Forms.MenuItem
        Me.mnuSetSysName = New System.Windows.Forms.MenuItem
        Me.mnuClearUNamesMenu = New System.Windows.Forms.MenuItem
        Me.mnuChlOpts = New System.Windows.Forms.ContextMenu
        Me.mnuConnect = New System.Windows.Forms.MenuItem
        Me.mnuSep = New System.Windows.Forms.MenuItem
        Me.mnuRefresh = New System.Windows.Forms.MenuItem
        Me.hlpDChat = New System.Windows.Forms.HelpProvider
        Me.mnuDChatMenu = New System.Windows.Forms.MainMenu
        Me.pnlToolBar = New System.Windows.Forms.Panel
        Me.pnlMainInterface = New System.Windows.Forms.Panel
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.fraLeft.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.fraRight.SuspendLayout()
        Me.pnlMainInterface.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraLeft
        '
        Me.fraLeft.Controls.Add(Me.tbsChat)
        Me.fraLeft.Controls.Add(Me.Panel2)
        Me.fraLeft.Controls.Add(Me.txtTopic)
        Me.fraLeft.Controls.Add(Me.lblTopic)
        Me.fraLeft.Controls.Add(Me.tlbColors)
        Me.fraLeft.Controls.Add(Me.txtInput)
        Me.fraLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.fraLeft.Location = New System.Drawing.Point(128, 0)
        Me.fraLeft.Name = "fraLeft"
        Me.fraLeft.Size = New System.Drawing.Size(496, 393)
        Me.fraLeft.TabIndex = 1
        Me.fraLeft.TabStop = False
        '
        'tbsChat
        '
        Me.tbsChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbsChat.HotTrack = True
        Me.tbsChat.ImageList = Me.ilsTab
        Me.tbsChat.Location = New System.Drawing.Point(3, 55)
        Me.tbsChat.Name = "tbsChat"
        Me.tbsChat.SelectedIndex = 0
        Me.tbsChat.Size = New System.Drawing.Size(490, 266)
        Me.tbsChat.TabIndex = 4
        Me.tbsChat.TabStop = False
        '
        'ilsTab
        '
        Me.ilsTab.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsTab.ImageStream = CType(resources.GetObject("ilsTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsTab.TransparentColor = System.Drawing.Color.Transparent
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tlbEdit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 321)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(490, 24)
        Me.Panel2.TabIndex = 17
        '
        'tlbEdit
        '
        Me.tlbEdit.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbEdit.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdSndButton, Me.cmdAlarmCHL, Me.cmdSel})
        Me.tlbEdit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlbEdit.DropDownArrows = True
        Me.tlbEdit.ImageList = Me.ilsEdit
        Me.tlbEdit.Location = New System.Drawing.Point(0, -4)
        Me.tlbEdit.Name = "tlbEdit"
        Me.tlbEdit.ShowToolTips = True
        Me.tlbEdit.Size = New System.Drawing.Size(490, 28)
        Me.tlbEdit.TabIndex = 0
        '
        'cmdSndButton
        '
        Me.cmdSndButton.ImageIndex = 10
        Me.cmdSndButton.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdSndButton.Tag = "2"
        '
        'cmdAlarmCHL
        '
        Me.cmdAlarmCHL.ImageIndex = 8
        Me.cmdAlarmCHL.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdAlarmCHL.Tag = "3"
        '
        'cmdSel
        '
        Me.cmdSel.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ilsEdit
        '
        Me.ilsEdit.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilsEdit.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsEdit.ImageStream = CType(resources.GetObject("ilsEdit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsEdit.TransparentColor = System.Drawing.Color.Transparent
        '
        'txtTopic
        '
        Me.txtTopic.AutoSize = True
        Me.txtTopic.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtTopic.Location = New System.Drawing.Point(3, 35)
        Me.txtTopic.Multiline = False
        Me.txtTopic.Name = "txtTopic"
        Me.txtTopic.Size = New System.Drawing.Size(490, 20)
        Me.txtTopic.TabIndex = 3
        Me.txtTopic.TabStop = False
        Me.txtTopic.Text = "Добро пожаловать в DChat!!!"
        '
        'lblTopic
        '
        Me.lblTopic.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTopic.Location = New System.Drawing.Point(3, 16)
        Me.lblTopic.Name = "lblTopic"
        Me.lblTopic.Size = New System.Drawing.Size(490, 19)
        Me.lblTopic.TabIndex = 2
        Me.lblTopic.TabStop = False
        Me.lblTopic.Text = "Тема:"
        '
        'tlbColors
        '
        Me.tlbColors.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbColors.AutoSize = False
        Me.tlbColors.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdUseFormatting, Me.cmdSep6, Me.cmdBold, Me.cmdUnderl, Me.cmdColSep, Me.cmdColChangeBCol, Me.cmdColor1, Me.cmdColor2, Me.cmdColor3, Me.cmdColor4, Me.cmdColor5, Me.cmdColor6, Me.cmdColor7, Me.cmdColor8, Me.cmdColor9, Me.cmdColor10, Me.cmdColor11, Me.cmdColor12, Me.cmdColor13, Me.cmdColor14, Me.cmdColor15})
        Me.tlbColors.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlbColors.DropDownArrows = True
        Me.tlbColors.ImageList = Me.ilsIRCColors
        Me.tlbColors.Location = New System.Drawing.Point(3, 345)
        Me.tlbColors.Name = "tlbColors"
        Me.tlbColors.ShowToolTips = True
        Me.tlbColors.Size = New System.Drawing.Size(490, 25)
        Me.tlbColors.TabIndex = 18
        '
        'cmdUseFormatting
        '
        Me.cmdUseFormatting.ImageIndex = 21
        Me.cmdUseFormatting.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdUseFormatting.Visible = False
        '
        'cmdSep6
        '
        Me.cmdSep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.cmdSep6.Visible = False
        '
        'cmdBold
        '
        Me.cmdBold.ImageIndex = 18
        Me.cmdBold.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdBold.Tag = "1"
        '
        'cmdUnderl
        '
        Me.cmdUnderl.ImageIndex = 20
        Me.cmdUnderl.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdUnderl.Tag = "2"
        '
        'cmdColSep
        '
        Me.cmdColSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'cmdColChangeBCol
        '
        Me.cmdColChangeBCol.Enabled = False
        Me.cmdColChangeBCol.ImageIndex = 17
        Me.cmdColChangeBCol.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdColChangeBCol.Tag = "3"
        '
        'cmdColor1
        '
        Me.cmdColor1.ImageIndex = 0
        Me.cmdColor1.Tag = ""
        '
        'cmdColor2
        '
        Me.cmdColor2.ImageIndex = 1
        Me.cmdColor2.Tag = ""
        '
        'cmdColor3
        '
        Me.cmdColor3.ImageIndex = 2
        Me.cmdColor3.Tag = ""
        '
        'cmdColor4
        '
        Me.cmdColor4.ImageIndex = 4
        Me.cmdColor4.Tag = ""
        '
        'cmdColor5
        '
        Me.cmdColor5.ImageIndex = 5
        '
        'cmdColor6
        '
        Me.cmdColor6.ImageIndex = 6
        '
        'cmdColor7
        '
        Me.cmdColor7.ImageIndex = 7
        '
        'cmdColor8
        '
        Me.cmdColor8.ImageIndex = 8
        '
        'cmdColor9
        '
        Me.cmdColor9.ImageIndex = 9
        '
        'cmdColor10
        '
        Me.cmdColor10.ImageIndex = 10
        '
        'cmdColor11
        '
        Me.cmdColor11.ImageIndex = 11
        '
        'cmdColor12
        '
        Me.cmdColor12.ImageIndex = 12
        '
        'cmdColor13
        '
        Me.cmdColor13.ImageIndex = 13
        '
        'cmdColor14
        '
        Me.cmdColor14.ImageIndex = 14
        '
        'cmdColor15
        '
        Me.cmdColor15.ImageIndex = 15
        '
        'ilsIRCColors
        '
        Me.ilsIRCColors.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsIRCColors.ImageStream = CType(resources.GetObject("ilsIRCColors.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsIRCColors.TransparentColor = System.Drawing.Color.Transparent
        '
        'txtInput
        '
        Me.txtInput.AutoSize = True
        Me.txtInput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtInput.HideSelection = False
        Me.txtInput.Location = New System.Drawing.Point(3, 370)
        Me.txtInput.Multiline = False
        Me.txtInput.Name = "txtInput"
        Me.txtInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.txtInput.Size = New System.Drawing.Size(490, 20)
        Me.txtInput.TabIndex = 0
        Me.txtInput.Text = ""
        '
        'fraRight
        '
        Me.fraRight.CausesValidation = False
        Me.fraRight.Controls.Add(Me.pnlLTOP)
        Me.fraRight.Controls.Add(Me.txtName)
        Me.fraRight.Controls.Add(Me.cmdChangeName)
        Me.fraRight.Dock = System.Windows.Forms.DockStyle.Left
        Me.fraRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.fraRight.Location = New System.Drawing.Point(0, 0)
        Me.fraRight.Name = "fraRight"
        Me.fraRight.Size = New System.Drawing.Size(128, 393)
        Me.fraRight.TabIndex = 0
        Me.fraRight.TabStop = False
        '
        'pnlLTOP
        '
        Me.pnlLTOP.BackColor = System.Drawing.SystemColors.Control
        Me.pnlLTOP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLTOP.Location = New System.Drawing.Point(3, 55)
        Me.pnlLTOP.Name = "pnlLTOP"
        Me.pnlLTOP.Size = New System.Drawing.Size(122, 335)
        Me.pnlLTOP.TabIndex = 44
        '
        'txtName
        '
        Me.txtName.AutoSize = True
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtName.Location = New System.Drawing.Point(3, 35)
        Me.txtName.MaxLength = 100
        Me.txtName.Multiline = False
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(122, 20)
        Me.txtName.TabIndex = 42
        Me.txtName.TabStop = False
        Me.txtName.Text = ""
        '
        'cmdChangeName
        '
        Me.cmdChangeName.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdChangeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChangeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdChangeName.Location = New System.Drawing.Point(3, 16)
        Me.cmdChangeName.Name = "cmdChangeName"
        Me.cmdChangeName.Size = New System.Drawing.Size(122, 19)
        Me.cmdChangeName.TabIndex = 11
        Me.cmdChangeName.TabStop = False
        Me.cmdChangeName.Text = "Имя:"
        '
        'strDChat
        '
        Me.strDChat.ContextMenu = Me.mnuTray
        Me.strDChat.Icon = CType(resources.GetObject("strDChat.Icon"), System.Drawing.Icon)
        Me.strDChat.Text = "DChat - [Активен]"
        '
        'mnuTray
        '
        Me.mnuTray.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem5, Me.mnuExit})
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 0
        Me.MenuItem5.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 1
        Me.mnuExit.Text = "В&ыход"
        '
        'tmrAnimator
        '
        Me.tmrAnimator.Enabled = True
        Me.tmrAnimator.Interval = 200
        '
        'ilsTrayIcons
        '
        Me.ilsTrayIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsTrayIcons.ImageStream = CType(resources.GetObject("ilsTrayIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsTrayIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'dlgSave
        '
        Me.dlgSave.FileName = "Chat"
        '
        'mnuUserNames
        '
        Me.mnuUserNames.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNam0, Me.mnuNam1, Me.mnuNam2, Me.mnuNam3, Me.mnuNam4, Me.mnuNam5, Me.mnuNam6, Me.mnuNam7, Me.mnuNam8, Me.mnuNam9, Me.mnuSep9, Me.mnuSetSysName, Me.mnuClearUNamesMenu})
        '
        'mnuNam0
        '
        Me.mnuNam0.Index = 0
        Me.mnuNam0.Text = ""
        '
        'mnuNam1
        '
        Me.mnuNam1.Index = 1
        Me.mnuNam1.Text = ""
        '
        'mnuNam2
        '
        Me.mnuNam2.Index = 2
        Me.mnuNam2.Text = ""
        '
        'mnuNam3
        '
        Me.mnuNam3.Index = 3
        Me.mnuNam3.Text = ""
        '
        'mnuNam4
        '
        Me.mnuNam4.Index = 4
        Me.mnuNam4.Text = ""
        '
        'mnuNam5
        '
        Me.mnuNam5.Index = 5
        Me.mnuNam5.Text = ""
        '
        'mnuNam6
        '
        Me.mnuNam6.Index = 6
        Me.mnuNam6.Text = ""
        '
        'mnuNam7
        '
        Me.mnuNam7.Index = 7
        Me.mnuNam7.Text = ""
        '
        'mnuNam8
        '
        Me.mnuNam8.Index = 8
        Me.mnuNam8.Text = ""
        '
        'mnuNam9
        '
        Me.mnuNam9.Index = 9
        Me.mnuNam9.Text = ""
        '
        'mnuSep9
        '
        Me.mnuSep9.Index = 10
        Me.mnuSep9.Text = "-"
        '
        'mnuSetSysName
        '
        Me.mnuSetSysName.Index = 11
        Me.mnuSetSysName.Text = "Системное имя"
        '
        'mnuClearUNamesMenu
        '
        Me.mnuClearUNamesMenu.Index = 12
        Me.mnuClearUNamesMenu.Text = "Очистить"
        '
        'mnuChlOpts
        '
        Me.mnuChlOpts.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConnect, Me.mnuSep, Me.mnuRefresh})
        '
        'mnuConnect
        '
        Me.mnuConnect.Index = 0
        Me.mnuConnect.Text = "Подключится"
        '
        'mnuSep
        '
        Me.mnuSep.Index = 1
        Me.mnuSep.Text = "-"
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Index = 2
        Me.mnuRefresh.Text = "Обновить список"
        '
        'hlpDChat
        '
        Me.hlpDChat.HelpNamespace = "C:\Documents and Settings\Garikk\Мои документы\VB\DChat2\DCHelp.chm"
        '
        'pnlToolBar
        '
        Me.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolBar.Name = "pnlToolBar"
        Me.pnlToolBar.Size = New System.Drawing.Size(624, 32)
        Me.pnlToolBar.TabIndex = 3
        '
        'pnlMainInterface
        '
        Me.pnlMainInterface.Controls.Add(Me.Splitter1)
        Me.pnlMainInterface.Controls.Add(Me.fraLeft)
        Me.pnlMainInterface.Controls.Add(Me.fraRight)
        Me.pnlMainInterface.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainInterface.Location = New System.Drawing.Point(0, 32)
        Me.pnlMainInterface.Name = "pnlMainInterface"
        Me.pnlMainInterface.Size = New System.Drawing.Size(624, 393)
        Me.pnlMainInterface.TabIndex = 4
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(128, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(2, 393)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'frmChat
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 425)
        Me.Controls.Add(Me.pnlMainInterface)
        Me.Controls.Add(Me.pnlToolBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Menu = Me.mnuDChatMenu
        Me.Name = "frmChat"
        Me.hlpDChat.SetShowHelp(Me, True)
        Me.Text = "DChat"
        Me.fraLeft.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.fraRight.ResumeLayout(False)
        Me.pnlMainInterface.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmChat
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmChat
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmChat
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmChat)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Public ChatClosing As Boolean = False
    Dim TextBuffer(100) As String
    Dim SelFocus As Boolean = False
    Dim SelChar As Char
    Dim WinClosing As Boolean = False
    Dim CurMouseButton As MouseButtons
    Dim HKPress As System.Windows.Forms.KeyEventArgs
    Dim HKPressC As Boolean = False
    'Dim ActiveCHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel
    Dim LastWindowState As Windows.Forms.FormWindowState
    Dim F_INIT As Boolean = True
    Dim LastMenu As MenuItem
    Dim basemenu As String

    Dim tbsChat_SelInd As Boolean = False
    Dim tbsChat_LastIndex As Integer

    Public BlinkTray As Boolean = False

    Private Sub SysEvent(ByVal Sender As System.Object, ByVal e As Microsoft.Win32.SessionEndingEventArgs)
        ChatClosing = True
    End Sub
    Private Sub frmChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Первый запуск
        hlpDChat.HelpNamespace = Application.StartupPath & "\help\DChelp.chm"
        Me.Hide()
        Me.Visible = False
        LastWindowState = FormWindowState.Maximized
        txtInput.Focus()
        Chat.ChatInit()
    End Sub

    Private Sub InitSettings()
        Dim FS As New FontStyle
        If DCB_InterfaceSettings.ChatFontBold Then
            FS = FontStyle.Bold
        End If
        If DCB_InterfaceSettings.ChatFontUnderl Then
            FS = FS + FontStyle.Underline
        End If
        Dim fnt As Font = New Font(DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize, FS)
        Dim RTFNone As String = DC2Conv.TxtToRTF("", fnt.Name, fnt.Size)
        txtTopic.BackColor = DCB_ColorSettings.BackChatColor
        txtTopic.Rtf = RTFNone
        txtTopic.Font = fnt
        txtName.BackColor = DCB_ColorSettings.BackChatColor
        txtName.Rtf = RTFNone
        txtName.Font = fnt
        txtInput.Rtf = RTFNone
        txtInput.Font = fnt
        txtInput.BackColor = DCB_ColorSettings.BackChatColor

        lblTopic.Visible = DCB_InterfaceSettings.ShowTopicBar
        txtTopic.Visible = DCB_InterfaceSettings.ShowTopicBar
        cmdChangeName.Visible = DCB_InterfaceSettings.ShowUsrNameBar
        txtName.Visible = DCB_InterfaceSettings.ShowUsrNameBar

        If DCB_InterfaceSettings.Tabs = 1 Then
            tbsChat.Appearance = TabAppearance.Normal
        ElseIf DCB_InterfaceSettings.Tabs = 2 Then
            tbsChat.Appearance = TabAppearance.Buttons
        Else
            tbsChat.Appearance = TabAppearance.FlatButtons
        End If
        If DCB_InterfaceSettings.UseFormat = False Then
            Me.cmdUnderl.Enabled = False
            Me.cmdBold.Enabled = False
        End If
        If DCB_InterfaceSettings.UListPosition = 2 Then
            fraRight.Dock = DockStyle.Right
            'fraLeft.Dock = DockStyle.Left
        End If
    End Sub

    Public Sub FormInit()
        ' Инициализация формы
        strDChat.Visible = True
        txtName.Text = "-== DChat ==-"

        LoadUNamesMenuItems()
        If DCB_InterfaceSettings.HKeyUse = True Then InitHotKey()
        If DCB_InterfaceSettings.RunMin = False Then Me.Show()
        InitSettings()
        strDChat.Icon = GetCurrentIcon()
        DCB_DCTL.DCB_GetCurrentChannelDCC.lstUsers.Visible = True
        Me.Text = DCB_ChatParams.MyVerFTitle
        F_INIT = False
        pnlToolBar.Visible = DCB_InterfaceSettings.ShowMenuBar
    End Sub


    Public Sub LoadUNamesMenuItems()
        Dim Tmp As Short
        Dim PID As String = DCB_DCTL.DCB_GetCurrentPluginID
        For Tmp = 0 To 9
            mnuUserNames.MenuItems(Tmp).Text = Settings2.DCB_SETTINGS_OPER_GetUserNameMenuItem(PID, Tmp)

        Next
    End Sub
    Public Sub SaveUNamesMenuItems()
        Dim Tmp As Short
        Dim UNamesBase(9) As String
        Dim PID As String = DCB_DCTL.DCB_GetCurrentPluginID
        For Tmp = 0 To 9
            UNamesBase(Tmp) = Settings2.DCB_SETTINGS_OPER_GetUserNameMenuItem(PID, Tmp)
        Next
        For Tmp = 9 To 1 Step -1
            UNamesBase(Tmp) = UNamesBase(Tmp - 1)
        Next
        UNamesBase(0) = txtName.Text
        For Tmp = 0 To 9
            Settings2.DCB_SETTINGS_OPER_SaveUserNamesList(Tmp, PID, UNamesBase(Tmp))
        Next
    End Sub



    Private Sub cmdInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'InterfaceManager.GetUserInfo_UICall()

    End Sub

    Private Sub tlbEdit_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbEdit.ButtonClick
        If Val(e.Button.Tag) = 1 Then
            Me.tlbColors.Visible = e.Button.Pushed
        ElseIf Val(e.Button.Tag) = 2 Then
            If e.Button.Pushed = True Then e.Button.ImageIndex = 9 Else e.Button.ImageIndex = 10
            DCB_DCTL.DCB_GetCurrentChannelDCC.CHLParams.USESound = e.Button.Pushed
        ElseIf Val(e.Button.Tag) = 3 Then
            If e.Button.Pushed = True Then e.Button.ImageIndex = 7 Else e.Button.ImageIndex = 8

            DCB_DCTL.DCB_GetCurrentChannelDCC.CHLParams.USEAlarm = e.Button.Pushed
        End If
    End Sub

    Private Sub strDChat_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles strDChat.MouseDown
        CurMouseButton = e.Button
    End Sub

    Private Sub strDChat_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles strDChat.DoubleClick
        If Me.Visible = False Then
            Me.WindowState = LastWindowState
            Me.Show()
            Me.Activate()
        Else
            Me.Visible = False
            If Me.WindowState <> FormWindowState.Minimized Then LastWindowState = Me.WindowState : Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub frmChat_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If ChatClosing = False And Me.Visible = True And WinClosing = False Then
            Me.Visible = False
            e.Cancel = True
        ElseIf WinClosing = True Then
            If DCB_InterfaceSettings.HKeyUse = True Then
                'Вырубаем HotKey
                UnregisterHotKey(Me.Handle.ToInt32, &HF)
            End If
            Chat.CloseChat(True)
        End If
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        ShowExit()
    End Sub

    Public Sub ExitForm()
        Me.Hide()
        strDChat.Visible = False
    End Sub
    Private Sub frmChat_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ' ChangeFormState_UICall(0)
        txtInput.Focus()
        BlinkTray = False
    End Sub


    Private Sub txtName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim PID As String = DCB_DCTL.DCB_GetCurrentPluginID
            Dim PUsrInf As DCB_Universal.DCB_LocalUserInfo = CType(DCSE.DCB_DCSE_OPER_Executer(PID, "%PID% DCB_GUI_GETUSERINFO"), DCB_Universal.DCB_LocalUserInfo)
            If txtName.Text = "" Then txtName.Text = PUsrInf.UserCurrentNick : Exit Sub

            e.Handled = True
            e = New System.Windows.Forms.KeyEventArgs(Keys.None)
            ' Добавляем в менюшку списка имён
            Dim NoAdd As Boolean = False
            Dim Tmp As Integer
            For Tmp = 0 To 9
                If mnuUserNames.MenuItems(Tmp).Text = txtName.Text Then
                    NoAdd = True
                    Exit For
                End If
            Next
            If NoAdd = False Then
                For Tmp = 9 To 1 Step -1
                    Settings2.DCB_SETTINGS_OPER_SaveUserNamesList(Tmp, PID, mnuUserNames.MenuItems(Tmp - 1).Text)
                Next
                Settings2.DCB_SETTINGS_OPER_SaveUserNamesList(0, PID, txtName.Text)
                LoadUNamesMenuItems()
            End If
            Dim T As String = txtName.Text
            txtName.Text = PUsrInf.UserCurrentNick
            ChangeNick(T)
        ElseIf e.Control = True And e.KeyCode = Keys.Back Then
            txtName.Text = DCB_Universal.ChangeRLLayout.ChangeLayout(txtName.Text)
            txtName.SelectionStart = txtName.TextLength
            e.Handled = True
            e = New System.Windows.Forms.KeyEventArgs(Keys.None)
        End If
    End Sub


    Private Sub txtInput_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInput.KeyDown
        Try
            If e.KeyCode = Keys.Return Then
                If txtInput.Text = "" Then Exit Sub
                WriteInTextBuffer(txtInput.Rtf)
                'Отправляем строчечку
                InterfaceManager.SendTextLine_UICall(txtInput.Rtf)

                txtInput.Text = ""
                txtInput.SelectionColor = cdlChatColor.Color
                SetFontParams(txtInput, cmdBold.Pushed, False, cmdUnderl.Pushed, txtInput.Font.Name, txtInput.Font.Size)
                e.Handled = True
                e = New System.Windows.Forms.KeyEventArgs(Keys.None)
            ElseIf e.KeyCode = Keys.Down Then
                txtInput.Rtf = ReadFromTextBuffer(False)
                txtInput.SelectionStart = txtInput.Text.Length
                e.Handled = True
                e = New System.Windows.Forms.KeyEventArgs(Keys.None)
            ElseIf e.KeyCode = Keys.Escape Then
                txtInput.Text = ""
            ElseIf e.KeyCode = Keys.Up Then


                txtInput.Rtf = ReadFromTextBuffer(True)
                txtInput.SelectionStart = txtInput.Text.Length
                e.Handled = True
                e = New System.Windows.Forms.KeyEventArgs(Keys.None)
            ElseIf e.Control = True And e.KeyCode = Keys.Back Then
                txtInput.Text = DCB_Universal.ChangeRLLayout.ChangeLayout(txtInput.Text)
                txtInput.SelectionStart = txtInput.TextLength
                e.Handled = True
                e = New System.Windows.Forms.KeyEventArgs(Keys.None)
            ElseIf e Is HKPress Then
                e.Handled = True
                e = New System.Windows.Forms.KeyEventArgs(Keys.None)
            End If
        Catch
        End Try
    End Sub
    Private Sub txtTopic_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTopic.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtTopic.Text = "" Then Exit Sub
            ChangeTopic(txtTopic.Rtf)
            txtInput.Focus()
            txtInput.Text = ""
            txtInput.Clear()
            e.Handled = True
            e = New System.Windows.Forms.KeyEventArgs(Keys.None)
        ElseIf e.Control = True And e.KeyCode = Keys.Back Then
            txtTopic.Text = DCB_Universal.ChangeRLLayout.ChangeLayout(txtTopic.Text)
            txtTopic.SelectionStart = txtTopic.TextLength
            e.Handled = True
            e = New System.Windows.Forms.KeyEventArgs(Keys.None)
        End If
    End Sub

    Private Sub txtInput_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInput.TextChanged
        SetFontParams(txtInput, cmdBold.Pushed, False, cmdUnderl.Pushed)
    End Sub

    Private Sub lblTopic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTopic.Click

        txtInput.Focus()
        DCSE.DCB_DCSE_OPER_Executer(DCB_DCTL.DCB_GetCurrentPluginID, DCB_DCTL.DCB_GetCurrentPluginID & " $TOPICCLICK$")

    End Sub


    Private Sub frmChat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim HKeyChange As Boolean = False
        ' HKeyChange = InterfaceManager.HotKey_UICall(e.Alt, e.Control, e.Shift, e.KeyCode, txtInput)
        '' Имя пользователя
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D1 Then Me.mnuNam0_Click(mnuNam0, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D2 Then Me.mnuNam0_Click(mnuNam1, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D3 Then Me.mnuNam0_Click(mnuNam2, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D4 Then Me.mnuNam0_Click(mnuNam3, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D5 Then Me.mnuNam0_Click(mnuNam4, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D6 Then Me.mnuNam0_Click(mnuNam5, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D7 Then Me.mnuNam0_Click(mnuNam6, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D8 Then Me.mnuNam0_Click(mnuNam7, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D9 Then Me.mnuNam0_Click(mnuNam8, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = True And e.Shift = False And e.KeyCode = Keys.D0 Then Me.mnuNam0_Click(mnuNam9, New System.EventArgs) : HKeyChange = True
        If e.Control = False And e.Alt = False And e.Shift = False And e.KeyCode = Keys.Escape And txtInput.Text = "" And Me.Visible = True Then Me.strDChat_DoubleClick(Me, New System.EventArgs)
        Try
            If Me.ActiveControl.Name = "txtName" Or Me.ActiveControl.Name = "txtTopic" Or Me.ActiveControl.Name = "txtInput" Then Exit Sub
        Catch
        End Try
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then Exit Sub
        SelFocus = True
    End Sub

    Private Sub tmrAnimator_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAnimator.Tick
        Static IconSelector As Boolean = True
        If BlinkTray = True Then
            If IconSelector = True Then
                IconSelector = Not IconSelector
                strDChat.Icon = icoEMP
            Else
                IconSelector = Not IconSelector
                strDChat.Icon = GetCurrentIcon()
            End If
        Else
            If strDChat.Icon Is icoEMP Then
                strDChat.Icon = GetCurrentIcon()
            End If
        End If
    End Sub
    Private Function GetCurrentIcon() As Icon
        GetCurrentIcon = icoACT
    End Function

    Private Sub cmdChangeName_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdChangeName.MouseDown
        Dim A As Point
        A.X = e.X
        A.Y = e.Y
        mnuUserNames.Show(cmdChangeName, A)
    End Sub

    Private Sub mnuNam0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNam0.Click, mnuNam1.Click, mnuNam2.Click, mnuNam3.Click, mnuNam4.Click, mnuNam5.Click, mnuNam6.Click, mnuNam7.Click, mnuNam8.Click, mnuNam9.Click
        If sender.text = "" Or sender.text = " " Then Exit Sub
        txtName.Text = sender.text
        txtName_KeyDown(Me, New KeyEventArgs(Keys.Return))
    End Sub

    Private Sub mnuSetSysName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetSysName.Click
        txtName.Text = Windows.Forms.SystemInformation.UserName
        txtName_KeyDown(Me, New KeyEventArgs(Keys.Return))
    End Sub

    Private Sub mnuClearUNamesMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearUNamesMenu.Click

        Dim Tmp As Short
        For Tmp = 0 To 9
            Settings2.DCB_SETTINGS_OPER_SaveUserNamesList(Tmp, PMGR.DCB_Plugins.GetPLG(DCB_DCTL.DCB_GetCurrentPluginID).UNI_GetInfo.INF_NAME, " ")
        Next
        LoadUNamesMenuItems()
    End Sub


    Private Sub WriteInTextBuffer(ByVal Txt As String)
        Dim Tmp As Integer
        For Tmp = 100 To 2 Step -1
            TextBuffer(Tmp) = TextBuffer(Tmp - 1)
        Next
        TextBuffer(1) = Txt
        TextBuffer(0) = 0
    End Sub
    Private Function ReadFromTextBuffer(ByVal BackRead As Boolean) As String
        ' BackRead - чтение назад
        If TextBuffer(0) = "" Then TextBuffer(0) = "1"
        Select Case BackRead
            Case True
                If TextBuffer(0) = 100 Or TextBuffer(TextBuffer(0) + 1) = "" Then ReadFromTextBuffer = TextBuffer(TextBuffer(0)) : Exit Function
                TextBuffer(0) = TextBuffer(0) + 1
                ReadFromTextBuffer = TextBuffer(TextBuffer(0))
            Case False
                If TextBuffer(0) = 0 Then ReadFromTextBuffer = "" : Exit Function
                If TextBuffer(0) = 1 Then ReadFromTextBuffer = TextBuffer(TextBuffer(0)) : TextBuffer(0) = 0 : Exit Function
                TextBuffer(0) = TextBuffer(0) - 1
                ReadFromTextBuffer = TextBuffer(TextBuffer(0))
        End Select
    End Function

    Private Sub frmChat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If SelFocus = True Then
            If Me.HKPressC = True Then HKPressC = False : e.Handled = True : e = New System.Windows.Forms.KeyPressEventArgs("") : Exit Sub
            txtInput.SelectionStart = txtInput.TextLength
            txtInput.Text = txtInput.Text & e.KeyChar
            'txtInput.SelectionLength = 1
            SetFontParams(txtInput, Me.cmdBold.Pushed, False, Me.cmdUnderl.Pushed, txtInput.Font.Name, txtInput.Font.Size)
            txtInput.SelectionColor = cdlChatColor.Color
            txtInput.SelectionStart = txtInput.SelectionLength
            txtInput.Focus()
            SelFocus = Not SelFocus
            e.Handled = True
            e = New System.Windows.Forms.KeyPressEventArgs("")
            If txtInput.Text <> "" Then txtInput.SelectionStart = txtInput.TextLength + 1 ' - 1
        End If
    End Sub
    Public Sub DCB_GUICTL_UpdInterf()
        Static ActiveCHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel
        Dim PUsrInf As DCB_Universal.DCB_LocalUserInfo
        Dim PID As String
        If F_INIT = False Then
            PID = DCB_DCTL.DCB_GetCurrentPluginID
            PUsrInf = CType(DCSE.DCB_DCSE_OPER_Executer(PID, "%PID% DCB_GUI_GETUSERINFO"), DCB_Universal.DCB_LocalUserInfo)
        End If
        'Обновление менюшки
        DCB_Int_ShowCHLMenu()
        'Отображение выбранного канала
        Try
            Dim Channel As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = DCB_DCTL.DCB_GetCurrentChannelDCC()
            If Channel Is Nothing Then Exit Sub
            If Channel.CHLTYPE = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFListChannel Then
                txtInput.Enabled = False
                txtTopic.ReadOnly = True
            Else
                txtTopic.ReadOnly = False
                txtInput.Enabled = True
            End If
            'Ставим тему..
            If Channel.CHLTOPIC <> "" Then txtTopic.Rtf = DC2Conv.DC2ToRTF(Channel.CHLTOPIC, DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize) Else txtTopic.Text = ""
            If F_INIT = False And Not PUsrInf Is Nothing Then
                txtName.Text = PUsrInf.UserCurrentNick
            ElseIf F_INIT = False And PUsrInf Is Nothing Then
                txtName.Text = ""
            End If
            Try
                If Not (Channel Is ActiveCHL) Then ActiveCHL.lstUsers.Visible = False
            Catch
            End Try
            '  Channel.lstUsers.Visible = True
            ActiveCHL = Channel
            If Channel.PID = "/base" Then
                DCB_DCTL.DCB_GetLeftPanel.Controls.Clear()
                DCB_DCTL.DCB_GetToolBarPanel.Controls.Clear()

            Else
                Dim PLG As DCB_Universal.DCB_iPlugin = PMGR.DCB_Plugins.GetPLG(Channel.PID)
                If PLG.UNI_GetInfo.INF_OPTIONS.DCB_UseGUICTL = True Then
                    Dim R As Panel = PLG.DCB_DCSE_Exec("/base", "DCB_GUICTL_GETLPANEL")
                    If Not DCB_DCTL.DCB_GetLeftPanel.Controls.Contains(R) Then
                        R.Dock = DockStyle.Fill
                        DCB_DCTL.DCB_GetLeftPanel.Controls.Add(R)
                    End If
                    If DCB_InterfaceSettings.ShowMenuBar = True Then
                        Dim MB As ToolBar = PLG.DCB_DCSE_Exec("/base", "DCB_GUICTL_GETTOOLBAR")
                        If MB Is Nothing Then
                            DCB_DCTL.DCB_GetToolBarPanel.Controls.Clear()
                        Else
                            DCB_DCTL.DCB_GetToolBarPanel.Controls.Clear()
                            DCB_DCTL.DCB_GetToolBarPanel.Controls.Add(MB)
                            MB.Dock = DockStyle.Fill
                            MB.Visible = True
                            'DCB_DCTL.DCB_GetToolBarPanel.Height = MB.Height
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Stop
        End Try
        Dim chl As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = Chat.DCB_DCTL.DCB_GetCurrentChannelDCC
        cmdAlarmCHL.Pushed = chl.CHLParams.USEAlarm
        cmdSndButton.Pushed = chl.CHLParams.USESound
        tlbEdit_ButtonClick(Me, New ToolBarButtonClickEventArgs(cmdSndButton))

        ' TODO DCIRC совместимость
        If chl.CHLTYPE = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFChannel And chl.CHLName.StartsWith("#") Then chl.tbsCHL.ImageIndex = 3
        If chl.CHLTYPE = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFChannel And Not chl.CHLName.StartsWith("#") Then chl.tbsCHL.ImageIndex = 6
    End Sub
    Private Sub tbsChat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsChat.SelectedIndexChanged
        tbsChat_SelInd = True
        DCSE.DCB_DCSE_OPER_Executer("", "dcb_tabpagechanged")
        Try
            DCB_ActivePluginID = CStr(tbsChat.SelectedTab.Tag).Replace(tbsChat.SelectedTab.Text.ToLower, "")
        Catch
            DCB_ActivePluginID = "/base"
        End Try
        DCB_GUICTL_UpdInterf()
    End Sub
    Private Sub mnuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        hlpDChat.SetShowHelp(Me, True)
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAbout.DefInstance.Show()
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = &H11 Then WinClosing = True ' WM_QUERYENDSESSION
        If m.Msg = WM_HOTKEY And m.WParam.ToInt32 = &HF Then
            Me.strDChat_DoubleClick(Me, New System.EventArgs)
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub InitHotKey()
        Dim Ret As Integer
        Dim Modifers As Integer
        ' Регистрируем HotKey
        If DCB_InterfaceSettings.HKAlt = True Then Modifers = MOD_ALT
        If DCB_InterfaceSettings.HKCtrl = True Then Modifers = Modifers + MOD_CONTROL
        If DCB_InterfaceSettings.HKShift = True Then Modifers = Modifers + MOD_SHIFT
        Ret = RegisterHotKey(frmChat.DefInstance.Handle.ToInt32, &HF, Modifers, DCB_InterfaceSettings.HKKey)
    End Sub
    Private Sub tlbColors_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbColors.ButtonClick
        If e.Button.Tag = "1" Or e.Button.Tag = "2" Then
            SetFontParams(txtInput, cmdBold.Pushed, False, cmdUnderl.Pushed)
        ElseIf e.Button.Tag = "3" Then
            If e.Button.Pushed Then e.Button.ImageIndex = 16 Else e.Button.ImageIndex = 17
        Else
            txtInput.SelectionColor = Color.FromArgb(DC2Conv.GetARGBfromIRCCode(e.Button.ImageIndex))
        End If
    End Sub

    Private Sub frmChat_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then strDChat_DoubleClick(Me, New System.EventArgs)
    End Sub

    Private Sub txtInput_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtInput.LinkClicked
        _LinkClick(sender, e)
    End Sub

    Private Sub txtName_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles txtName.Invalidated

    End Sub

    Private Sub tbsChat_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles tbsChat.ControlAdded
        Try
            DCB_ActivePluginID = CStr(tbsChat.SelectedTab.Tag).Replace(tbsChat.SelectedTab.Text.ToLower, "")
        Catch
            DCB_ActivePluginID = "/base"
        End Try
    End Sub
    Private Sub tbsChat_Mouseup(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbsChat.MouseUp
        Static TLS As Integer = -1
        Static TTLS As Integer = -1
        If TLS = -1 Then TLS = tbsChat.SelectedIndex : TTLS = TLS
        If tbsChat_SelInd = False Then
            tbsChat.SelectedTab = tbsChat.TabPages(TTLS)
        Else
            If TLS <> tbsChat.SelectedIndex Then
                TTLS = TLS
                TLS = tbsChat.SelectedIndex
            End If
            tbsChat_SelInd = False
        End If
    End Sub

    Private Sub pnlToolBar_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlToolBar.Paint

    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub
End Class
