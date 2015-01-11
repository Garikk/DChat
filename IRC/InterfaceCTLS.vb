Imports UNI_Plugin.UNI_DChat
Public Class InterfaceCTLS

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
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents cmdInfo As System.Windows.Forms.Button
    Friend WithEvents pnlLists As System.Windows.Forms.Panel
    Friend WithEvents lstFavoriteCHLs As System.Windows.Forms.TreeView
    Friend WithEvents lstFriends As System.Windows.Forms.TreeView
    Friend WithEvents tlbFavoriteCHLs As System.Windows.Forms.ToolBar
    Friend WithEvents tlbUserHot As System.Windows.Forms.ToolBar
    Friend WithEvents tlbFriends As System.Windows.Forms.ToolBar
    Friend WithEvents cmdFCHLAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdFCHLEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdFCHLDel As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbFCHLSep As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdFCHLJoin As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdUOP As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdUPrivate As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdBeep As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdUInfo As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdAddFriend As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdModifyFriend As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdDelFriend As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdFreindsSep As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdRefreshFriends As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbUsers As System.Windows.Forms.ToolBar
    Friend WithEvents cmdUsers As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdFriends As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdChannels As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdList As System.Windows.Forms.Label
    Friend WithEvents pnIRCPanel As System.Windows.Forms.Panel
    Friend WithEvents ilsLists As System.Windows.Forms.ImageList
    Friend WithEvents ilsUserIcons As System.Windows.Forms.ImageList
    Friend WithEvents ilsUsersList As System.Windows.Forms.ImageList
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents cmdsep5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdFriendPrivate As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlInterf_Colors As System.Windows.Forms.Panel
    Friend WithEvents lblColorTbl As System.Windows.Forms.Label
    Friend WithEvents cmbSchemes As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pnlNetOptions As System.Windows.Forms.Panel
    Friend WithEvents lblServAddr As System.Windows.Forms.Label
    Friend WithEvents fraAddServer As System.Windows.Forms.GroupBox
    Friend WithEvents lblServAddrShow As System.Windows.Forms.TextBox
    Friend WithEvents txtPorts As System.Windows.Forms.TextBox
    Friend WithEvents lblPorts As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents txtGroup As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents cmdAddserv As System.Windows.Forms.Button
    Friend WithEvents grpConnection As System.Windows.Forms.GroupBox
    Friend WithEvents cmbServers As System.Windows.Forms.ComboBox
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents cmdIRCNetworks As System.Windows.Forms.ComboBox
    Friend WithEvents lblNetName As System.Windows.Forms.Label
    Friend WithEvents cmdmIRCImport As System.Windows.Forms.Button
    Friend WithEvents cmdDelServ As System.Windows.Forms.Button
    Friend WithEvents cmdEditServ As System.Windows.Forms.Button
    Friend WithEvents chkAutoConnect As System.Windows.Forms.CheckBox
    Friend WithEvents chkReconnect As System.Windows.Forms.CheckBox
    Friend WithEvents pnlNetOptions2 As System.Windows.Forms.Panel
    Friend WithEvents nudRWait As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblReconWait As System.Windows.Forms.Label
    Friend WithEvents pnlStrings As System.Windows.Forms.Panel
    Friend WithEvents lblquitMsg As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQuitMsgSD As System.Windows.Forms.RichTextBox
    Friend WithEvents txtQuitMsg As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdQuitColor As System.Windows.Forms.Button
    Friend WithEvents cmdQuitSDColor As System.Windows.Forms.Button
    Friend WithEvents lblFingerReply As System.Windows.Forms.Label
    Friend WithEvents txtfingerReply As System.Windows.Forms.TextBox
    Friend WithEvents cmOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents pnlUserSettings As System.Windows.Forms.Panel
    Friend WithEvents lblFullname As System.Windows.Forms.Label
    Friend WithEvents lblNickname As System.Windows.Forms.Label
    Friend WithEvents lblAltNick As System.Windows.Forms.Label
    Friend WithEvents txtFullname As System.Windows.Forms.TextBox
    Friend WithEvents txtAltNick As System.Windows.Forms.TextBox
    Friend WithEvents txtNick As System.Windows.Forms.TextBox
    Friend WithEvents lblWarn As System.Windows.Forms.Label
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents lblC1 As System.Windows.Forms.Label
    Friend WithEvents lblC2 As System.Windows.Forms.Label
    Friend WithEvents lblC3 As System.Windows.Forms.Label
    Friend WithEvents lblC4 As System.Windows.Forms.Label
    Friend WithEvents lblC5 As System.Windows.Forms.Label
    Friend WithEvents lblC6 As System.Windows.Forms.Label
    Friend WithEvents lblC7 As System.Windows.Forms.Label
    Friend WithEvents lblC8 As System.Windows.Forms.Label
    Friend WithEvents lblC9 As System.Windows.Forms.Label
    Friend WithEvents lblC10 As System.Windows.Forms.Label
    Friend WithEvents lblC11 As System.Windows.Forms.Label
    Friend WithEvents lblC12 As System.Windows.Forms.Label
    Friend WithEvents lblC13 As System.Windows.Forms.Label
    Friend WithEvents lblC14 As System.Windows.Forms.Label
    Friend WithEvents lblC15 As System.Windows.Forms.Label
    Friend WithEvents lblC16 As System.Windows.Forms.Label
    Friend WithEvents pnlColorBar As System.Windows.Forms.Panel
    Friend WithEvents pnlColorButtons As System.Windows.Forms.Panel
    Friend WithEvents cmd10 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd11 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd3 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd20 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd19 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd17 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd18 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd4 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd12 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd6 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd8 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd7 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd9 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd5 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd13 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd16 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd2 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd14 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd15 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdSaveColorSchame As System.Windows.Forms.Button
    Friend WithEvents pnlPerform As System.Windows.Forms.Panel
    Friend WithEvents lblPerform As System.Windows.Forms.Label
    Friend WithEvents txtPerform As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlModes As System.Windows.Forms.Panel
    Friend WithEvents lblModeSettings As System.Windows.Forms.Label
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents chkSndsOff As System.Windows.Forms.CheckBox
    Friend WithEvents lblSetModes As System.Windows.Forms.Label
    Friend WithEvents chkMsgPopup As System.Windows.Forms.CheckBox
    Friend WithEvents txtModePrivAns As System.Windows.Forms.TextBox
    Friend WithEvents pnlSndOptions As System.Windows.Forms.Panel
    Friend WithEvents chkEnableSnds As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseCTCPSOUND As System.Windows.Forms.CheckBox
    Friend WithEvents lblSndfilename As System.Windows.Forms.Label
    Friend WithEvents pnlSndsCtl As System.Windows.Forms.Panel
    Friend WithEvents lblSndEvName As System.Windows.Forms.Label
    Friend WithEvents cmbSounds As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtSndsPath As System.Windows.Forms.TextBox
    Friend WithEvents lblsndsPath As System.Windows.Forms.Label
    Friend WithEvents pnlctcpsndsctl As System.Windows.Forms.Panel
    Friend WithEvents cmdCTCPBrowse As System.Windows.Forms.Button
    Friend WithEvents txtCTCPSNDPATH As System.Windows.Forms.TextBox
    Friend WithEvents lblCTCPSoundPath As System.Windows.Forms.Label
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents cmbSndEvents As System.Windows.Forms.ComboBox
    Friend WithEvents tlbIRCToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents cmdTlbConnect As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdtlbSep As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbSep As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdylbSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdtlbShowCHLsList As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdtlbModeSelector As System.Windows.Forms.ToolBarButton
    Friend WithEvents chkSetAway As System.Windows.Forms.CheckBox
    Friend WithEvents lblExecCmd As System.Windows.Forms.Label
    Friend WithEvents txtOnSetModeExec As System.Windows.Forms.TextBox
    Friend WithEvents cmbModes As System.Windows.Forms.ComboBox
    Friend WithEvents lblOSPrivExec As System.Windows.Forms.Label
    Friend WithEvents cmdColorTextHelp As System.Windows.Forms.Button
    Friend WithEvents cmbPerformIRCNetworks As System.Windows.Forms.ComboBox
    Friend WithEvents lblIRCNetName As System.Windows.Forms.Label
    Friend WithEvents cmdPerformAddIrcNet As System.Windows.Forms.Button
    Friend WithEvents cmdPerformDelIrcNet As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InterfaceCTLS))
        Me.pnIRCPanel = New System.Windows.Forms.Panel
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.pnlLists = New System.Windows.Forms.Panel
        Me.lstFriends = New System.Windows.Forms.TreeView
        Me.ilsUserIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.lstFavoriteCHLs = New System.Windows.Forms.TreeView
        Me.ilsUsersList = New System.Windows.Forms.ImageList(Me.components)
        Me.tlbUserHot = New System.Windows.Forms.ToolBar
        Me.cmdUOP = New System.Windows.Forms.ToolBarButton
        Me.cmdUPrivate = New System.Windows.Forms.ToolBarButton
        Me.cmdBeep = New System.Windows.Forms.ToolBarButton
        Me.cmdUInfo = New System.Windows.Forms.ToolBarButton
        Me.ilsLists = New System.Windows.Forms.ImageList(Me.components)
        Me.tlbFriends = New System.Windows.Forms.ToolBar
        Me.cmdAddFriend = New System.Windows.Forms.ToolBarButton
        Me.cmdModifyFriend = New System.Windows.Forms.ToolBarButton
        Me.cmdDelFriend = New System.Windows.Forms.ToolBarButton
        Me.cmdFreindsSep = New System.Windows.Forms.ToolBarButton
        Me.cmdRefreshFriends = New System.Windows.Forms.ToolBarButton
        Me.cmdsep5 = New System.Windows.Forms.ToolBarButton
        Me.cmdFriendPrivate = New System.Windows.Forms.ToolBarButton
        Me.tlbFavoriteCHLs = New System.Windows.Forms.ToolBar
        Me.cmdFCHLAdd = New System.Windows.Forms.ToolBarButton
        Me.cmdFCHLEdit = New System.Windows.Forms.ToolBarButton
        Me.cmdFCHLDel = New System.Windows.Forms.ToolBarButton
        Me.tlbFCHLSep = New System.Windows.Forms.ToolBarButton
        Me.cmdFCHLJoin = New System.Windows.Forms.ToolBarButton
        Me.pnlInfo = New System.Windows.Forms.Panel
        Me.lblInfo = New System.Windows.Forms.Label
        Me.cmdInfo = New System.Windows.Forms.Button
        Me.tlbUsers = New System.Windows.Forms.ToolBar
        Me.cmdUsers = New System.Windows.Forms.ToolBarButton
        Me.cmdFriends = New System.Windows.Forms.ToolBarButton
        Me.cmdChannels = New System.Windows.Forms.ToolBarButton
        Me.cmdList = New System.Windows.Forms.Label
        Me.pnlInterf_Colors = New System.Windows.Forms.Panel
        Me.pnlColorButtons = New System.Windows.Forms.Panel
        Me.cmd10 = New System.Windows.Forms.RadioButton
        Me.cmd11 = New System.Windows.Forms.RadioButton
        Me.cmd3 = New System.Windows.Forms.RadioButton
        Me.cmd20 = New System.Windows.Forms.RadioButton
        Me.cmd19 = New System.Windows.Forms.RadioButton
        Me.cmd17 = New System.Windows.Forms.RadioButton
        Me.cmd18 = New System.Windows.Forms.RadioButton
        Me.cmd4 = New System.Windows.Forms.RadioButton
        Me.cmd12 = New System.Windows.Forms.RadioButton
        Me.cmd6 = New System.Windows.Forms.RadioButton
        Me.cmd8 = New System.Windows.Forms.RadioButton
        Me.cmd7 = New System.Windows.Forms.RadioButton
        Me.cmd1 = New System.Windows.Forms.RadioButton
        Me.cmd9 = New System.Windows.Forms.RadioButton
        Me.cmd5 = New System.Windows.Forms.RadioButton
        Me.cmd13 = New System.Windows.Forms.RadioButton
        Me.cmd16 = New System.Windows.Forms.RadioButton
        Me.cmd2 = New System.Windows.Forms.RadioButton
        Me.cmd14 = New System.Windows.Forms.RadioButton
        Me.cmd15 = New System.Windows.Forms.RadioButton
        Me.pnlColorBar = New System.Windows.Forms.Panel
        Me.lblC16 = New System.Windows.Forms.Label
        Me.lblC15 = New System.Windows.Forms.Label
        Me.lblC14 = New System.Windows.Forms.Label
        Me.lblC13 = New System.Windows.Forms.Label
        Me.lblC12 = New System.Windows.Forms.Label
        Me.lblC11 = New System.Windows.Forms.Label
        Me.lblC10 = New System.Windows.Forms.Label
        Me.lblC9 = New System.Windows.Forms.Label
        Me.lblC8 = New System.Windows.Forms.Label
        Me.lblC7 = New System.Windows.Forms.Label
        Me.lblC6 = New System.Windows.Forms.Label
        Me.lblC5 = New System.Windows.Forms.Label
        Me.lblC4 = New System.Windows.Forms.Label
        Me.lblC3 = New System.Windows.Forms.Label
        Me.lblC2 = New System.Windows.Forms.Label
        Me.lblC1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.cmdSaveColorSchame = New System.Windows.Forms.Button
        Me.cmbSchemes = New System.Windows.Forms.ComboBox
        Me.lblColorTbl = New System.Windows.Forms.Label
        Me.pnlNetOptions = New System.Windows.Forms.Panel
        Me.grpConnection = New System.Windows.Forms.GroupBox
        Me.cmdmIRCImport = New System.Windows.Forms.Button
        Me.cmbServers = New System.Windows.Forms.ComboBox
        Me.lblServer = New System.Windows.Forms.Label
        Me.cmdIRCNetworks = New System.Windows.Forms.ComboBox
        Me.lblNetName = New System.Windows.Forms.Label
        Me.cmdAddserv = New System.Windows.Forms.Button
        Me.cmdEditServ = New System.Windows.Forms.Button
        Me.cmdDelServ = New System.Windows.Forms.Button
        Me.fraAddServer = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmOk = New System.Windows.Forms.Button
        Me.lblDesc = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.txtGroup = New System.Windows.Forms.TextBox
        Me.lblGroup = New System.Windows.Forms.Label
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.lblPorts = New System.Windows.Forms.Label
        Me.txtPorts = New System.Windows.Forms.TextBox
        Me.lblServAddrShow = New System.Windows.Forms.TextBox
        Me.lblServAddr = New System.Windows.Forms.Label
        Me.pnlNetOptions2 = New System.Windows.Forms.Panel
        Me.lblReconWait = New System.Windows.Forms.Label
        Me.nudRWait = New System.Windows.Forms.NumericUpDown
        Me.chkReconnect = New System.Windows.Forms.CheckBox
        Me.chkAutoConnect = New System.Windows.Forms.CheckBox
        Me.pnlStrings = New System.Windows.Forms.Panel
        Me.cmdColorTextHelp = New System.Windows.Forms.Button
        Me.txtfingerReply = New System.Windows.Forms.TextBox
        Me.lblFingerReply = New System.Windows.Forms.Label
        Me.cmdQuitSDColor = New System.Windows.Forms.Button
        Me.cmdQuitColor = New System.Windows.Forms.Button
        Me.txtQuitMsg = New System.Windows.Forms.RichTextBox
        Me.txtQuitMsgSD = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblquitMsg = New System.Windows.Forms.Label
        Me.pnlUserSettings = New System.Windows.Forms.Panel
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.lblUserID = New System.Windows.Forms.Label
        Me.lblWarn = New System.Windows.Forms.Label
        Me.txtNick = New System.Windows.Forms.TextBox
        Me.txtAltNick = New System.Windows.Forms.TextBox
        Me.txtFullname = New System.Windows.Forms.TextBox
        Me.lblAltNick = New System.Windows.Forms.Label
        Me.lblNickname = New System.Windows.Forms.Label
        Me.lblFullname = New System.Windows.Forms.Label
        Me.pnlPerform = New System.Windows.Forms.Panel
        Me.txtPerform = New System.Windows.Forms.RichTextBox
        Me.lblPerform = New System.Windows.Forms.Label
        Me.pnlModes = New System.Windows.Forms.Panel
        Me.lblOSPrivExec = New System.Windows.Forms.Label
        Me.txtOnSetModeExec = New System.Windows.Forms.TextBox
        Me.lblExecCmd = New System.Windows.Forms.Label
        Me.chkSetAway = New System.Windows.Forms.CheckBox
        Me.txtModePrivAns = New System.Windows.Forms.TextBox
        Me.chkMsgPopup = New System.Windows.Forms.CheckBox
        Me.cmbModes = New System.Windows.Forms.ComboBox
        Me.lblSetModes = New System.Windows.Forms.Label
        Me.chkSndsOff = New System.Windows.Forms.CheckBox
        Me.lblPrefix = New System.Windows.Forms.Label
        Me.txtPrefix = New System.Windows.Forms.TextBox
        Me.lblModeSettings = New System.Windows.Forms.Label
        Me.pnlSndOptions = New System.Windows.Forms.Panel
        Me.pnlctcpsndsctl = New System.Windows.Forms.Panel
        Me.cmdCTCPBrowse = New System.Windows.Forms.Button
        Me.txtCTCPSNDPATH = New System.Windows.Forms.TextBox
        Me.lblCTCPSoundPath = New System.Windows.Forms.Label
        Me.pnlSndsCtl = New System.Windows.Forms.Panel
        Me.cmdPlay = New System.Windows.Forms.Button
        Me.lblSndEvName = New System.Windows.Forms.Label
        Me.cmbSounds = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtSndsPath = New System.Windows.Forms.TextBox
        Me.lblsndsPath = New System.Windows.Forms.Label
        Me.cmbSndEvents = New System.Windows.Forms.ComboBox
        Me.lblSndfilename = New System.Windows.Forms.Label
        Me.chkUseCTCPSOUND = New System.Windows.Forms.CheckBox
        Me.chkEnableSnds = New System.Windows.Forms.CheckBox
        Me.tlbIRCToolBar = New System.Windows.Forms.ToolBar
        Me.tlbSep = New System.Windows.Forms.ToolBarButton
        Me.cmdTlbConnect = New System.Windows.Forms.ToolBarButton
        Me.cmdtlbSep = New System.Windows.Forms.ToolBarButton
        Me.cmdtlbModeSelector = New System.Windows.Forms.ToolBarButton
        Me.cmdylbSep2 = New System.Windows.Forms.ToolBarButton
        Me.cmdtlbShowCHLsList = New System.Windows.Forms.ToolBarButton
        Me.cmbPerformIRCNetworks = New System.Windows.Forms.ComboBox
        Me.lblIRCNetName = New System.Windows.Forms.Label
        Me.cmdPerformAddIrcNet = New System.Windows.Forms.Button
        Me.cmdPerformDelIrcNet = New System.Windows.Forms.Button
        Me.pnIRCPanel.SuspendLayout()
        Me.pnlLists.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.pnlInterf_Colors.SuspendLayout()
        Me.pnlColorButtons.SuspendLayout()
        Me.pnlColorBar.SuspendLayout()
        Me.pnlNetOptions.SuspendLayout()
        Me.grpConnection.SuspendLayout()
        Me.fraAddServer.SuspendLayout()
        Me.pnlNetOptions2.SuspendLayout()
        CType(Me.nudRWait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStrings.SuspendLayout()
        Me.pnlUserSettings.SuspendLayout()
        Me.pnlPerform.SuspendLayout()
        Me.pnlModes.SuspendLayout()
        Me.pnlSndOptions.SuspendLayout()
        Me.pnlctcpsndsctl.SuspendLayout()
        Me.pnlSndsCtl.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnIRCPanel
        '
        Me.pnIRCPanel.BackColor = System.Drawing.SystemColors.Control
        Me.pnIRCPanel.Controls.Add(Me.Splitter1)
        Me.pnIRCPanel.Controls.Add(Me.pnlLists)
        Me.pnIRCPanel.Controls.Add(Me.pnlInfo)
        Me.pnIRCPanel.Controls.Add(Me.tlbUsers)
        Me.pnIRCPanel.Controls.Add(Me.cmdList)
        Me.pnIRCPanel.Location = New System.Drawing.Point(112, 16)
        Me.pnIRCPanel.Name = "pnIRCPanel"
        Me.pnIRCPanel.Size = New System.Drawing.Size(144, 400)
        Me.pnIRCPanel.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 333)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(144, 3)
        Me.Splitter1.TabIndex = 50
        Me.Splitter1.TabStop = False
        '
        'pnlLists
        '
        Me.pnlLists.Controls.Add(Me.lstFriends)
        Me.pnlLists.Controls.Add(Me.lstFavoriteCHLs)
        Me.pnlLists.Controls.Add(Me.tlbUserHot)
        Me.pnlLists.Controls.Add(Me.tlbFriends)
        Me.pnlLists.Controls.Add(Me.tlbFavoriteCHLs)
        Me.pnlLists.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLists.Location = New System.Drawing.Point(0, 46)
        Me.pnlLists.Name = "pnlLists"
        Me.pnlLists.Size = New System.Drawing.Size(144, 290)
        Me.pnlLists.TabIndex = 47
        '
        'lstFriends
        '
        Me.lstFriends.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFriends.HideSelection = False
        Me.lstFriends.HotTracking = True
        Me.lstFriends.ImageIndex = 7
        Me.lstFriends.ImageList = Me.ilsUserIcons
        Me.lstFriends.Location = New System.Drawing.Point(0, 0)
        Me.lstFriends.Name = "lstFriends"
        Me.lstFriends.ShowLines = False
        Me.lstFriends.ShowPlusMinus = False
        Me.lstFriends.ShowRootLines = False
        Me.lstFriends.Size = New System.Drawing.Size(144, 206)
        Me.lstFriends.Sorted = True
        Me.lstFriends.TabIndex = 49
        Me.lstFriends.TabStop = False
        Me.lstFriends.Visible = False
        '
        'ilsUserIcons
        '
        Me.ilsUserIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsUserIcons.ImageStream = CType(resources.GetObject("ilsUserIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsUserIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'lstFavoriteCHLs
        '
        Me.lstFavoriteCHLs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFavoriteCHLs.HideSelection = False
        Me.lstFavoriteCHLs.HotTracking = True
        Me.lstFavoriteCHLs.ImageIndex = 6
        Me.lstFavoriteCHLs.ImageList = Me.ilsUsersList
        Me.lstFavoriteCHLs.Location = New System.Drawing.Point(0, 0)
        Me.lstFavoriteCHLs.Name = "lstFavoriteCHLs"
        Me.lstFavoriteCHLs.SelectedImageIndex = 6
        Me.lstFavoriteCHLs.ShowLines = False
        Me.lstFavoriteCHLs.ShowPlusMinus = False
        Me.lstFavoriteCHLs.ShowRootLines = False
        Me.lstFavoriteCHLs.Size = New System.Drawing.Size(144, 206)
        Me.lstFavoriteCHLs.Sorted = True
        Me.lstFavoriteCHLs.TabIndex = 54
        Me.lstFavoriteCHLs.Visible = False
        '
        'ilsUsersList
        '
        Me.ilsUsersList.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsUsersList.ImageStream = CType(resources.GetObject("ilsUsersList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsUsersList.TransparentColor = System.Drawing.Color.Transparent
        '
        'tlbUserHot
        '
        Me.tlbUserHot.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbUserHot.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdUOP, Me.cmdUPrivate, Me.cmdBeep, Me.cmdUInfo})
        Me.tlbUserHot.ButtonSize = New System.Drawing.Size(23, 22)
        Me.tlbUserHot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlbUserHot.DropDownArrows = True
        Me.tlbUserHot.ImageList = Me.ilsLists
        Me.tlbUserHot.Location = New System.Drawing.Point(0, 206)
        Me.tlbUserHot.Name = "tlbUserHot"
        Me.tlbUserHot.ShowToolTips = True
        Me.tlbUserHot.Size = New System.Drawing.Size(144, 28)
        Me.tlbUserHot.TabIndex = 52
        '
        'cmdUOP
        '
        Me.cmdUOP.ImageIndex = 6
        Me.cmdUOP.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.cmdUOP.Tag = "1"
        '
        'cmdUPrivate
        '
        Me.cmdUPrivate.ImageIndex = 7
        Me.cmdUPrivate.Tag = "2"
        '
        'cmdBeep
        '
        Me.cmdBeep.ImageIndex = 9
        Me.cmdBeep.Tag = "3"
        '
        'cmdUInfo
        '
        Me.cmdUInfo.ImageIndex = 8
        Me.cmdUInfo.Tag = "4"
        '
        'ilsLists
        '
        Me.ilsLists.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilsLists.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsLists.ImageStream = CType(resources.GetObject("ilsLists.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsLists.TransparentColor = System.Drawing.Color.Transparent
        '
        'tlbFriends
        '
        Me.tlbFriends.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbFriends.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdAddFriend, Me.cmdModifyFriend, Me.cmdDelFriend, Me.cmdFreindsSep, Me.cmdRefreshFriends, Me.cmdsep5, Me.cmdFriendPrivate})
        Me.tlbFriends.ButtonSize = New System.Drawing.Size(23, 22)
        Me.tlbFriends.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlbFriends.DropDownArrows = True
        Me.tlbFriends.ImageList = Me.ilsLists
        Me.tlbFriends.Location = New System.Drawing.Point(0, 234)
        Me.tlbFriends.Name = "tlbFriends"
        Me.tlbFriends.ShowToolTips = True
        Me.tlbFriends.Size = New System.Drawing.Size(144, 28)
        Me.tlbFriends.TabIndex = 51
        Me.tlbFriends.Visible = False
        '
        'cmdAddFriend
        '
        Me.cmdAddFriend.ImageIndex = 0
        Me.cmdAddFriend.Tag = "1"
        '
        'cmdModifyFriend
        '
        Me.cmdModifyFriend.ImageIndex = 1
        Me.cmdModifyFriend.Tag = "2"
        '
        'cmdDelFriend
        '
        Me.cmdDelFriend.ImageIndex = 2
        Me.cmdDelFriend.Tag = "3"
        '
        'cmdFreindsSep
        '
        Me.cmdFreindsSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'cmdRefreshFriends
        '
        Me.cmdRefreshFriends.ImageIndex = 3
        Me.cmdRefreshFriends.Tag = "4"
        '
        'cmdsep5
        '
        Me.cmdsep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'cmdFriendPrivate
        '
        Me.cmdFriendPrivate.ImageIndex = 7
        Me.cmdFriendPrivate.Tag = "5"
        '
        'tlbFavoriteCHLs
        '
        Me.tlbFavoriteCHLs.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbFavoriteCHLs.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdFCHLAdd, Me.cmdFCHLEdit, Me.cmdFCHLDel, Me.tlbFCHLSep, Me.cmdFCHLJoin})
        Me.tlbFavoriteCHLs.ButtonSize = New System.Drawing.Size(23, 22)
        Me.tlbFavoriteCHLs.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlbFavoriteCHLs.DropDownArrows = True
        Me.tlbFavoriteCHLs.ImageList = Me.ilsLists
        Me.tlbFavoriteCHLs.Location = New System.Drawing.Point(0, 262)
        Me.tlbFavoriteCHLs.Name = "tlbFavoriteCHLs"
        Me.tlbFavoriteCHLs.ShowToolTips = True
        Me.tlbFavoriteCHLs.Size = New System.Drawing.Size(144, 28)
        Me.tlbFavoriteCHLs.TabIndex = 53
        Me.tlbFavoriteCHLs.Visible = False
        '
        'cmdFCHLAdd
        '
        Me.cmdFCHLAdd.ImageIndex = 4
        Me.cmdFCHLAdd.Tag = "1"
        Me.cmdFCHLAdd.ToolTipText = "Добавить канал в список Избранных"
        '
        'cmdFCHLEdit
        '
        Me.cmdFCHLEdit.ImageIndex = 1
        Me.cmdFCHLEdit.Tag = "2"
        Me.cmdFCHLEdit.ToolTipText = "Редактировать"
        '
        'cmdFCHLDel
        '
        Me.cmdFCHLDel.ImageIndex = 5
        Me.cmdFCHLDel.Tag = "3"
        Me.cmdFCHLDel.ToolTipText = "Удалить канал из списка Избранных"
        '
        'tlbFCHLSep
        '
        Me.tlbFCHLSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'cmdFCHLJoin
        '
        Me.cmdFCHLJoin.ImageIndex = 11
        Me.cmdFCHLJoin.Tag = "4"
        Me.cmdFCHLJoin.ToolTipText = "Войти на канал"
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.lblInfo)
        Me.pnlInfo.Controls.Add(Me.cmdInfo)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInfo.Location = New System.Drawing.Point(0, 336)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(144, 64)
        Me.pnlInfo.TabIndex = 15
        '
        'lblInfo
        '
        Me.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo.Location = New System.Drawing.Point(0, 24)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(144, 40)
        Me.lblInfo.TabIndex = 1
        '
        'cmdInfo
        '
        Me.cmdInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdInfo.Location = New System.Drawing.Point(0, 0)
        Me.cmdInfo.Name = "cmdInfo"
        Me.cmdInfo.Size = New System.Drawing.Size(144, 24)
        Me.cmdInfo.TabIndex = 0
        Me.cmdInfo.TabStop = False
        Me.cmdInfo.Text = "Информация:"
        '
        'tlbUsers
        '
        Me.tlbUsers.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbUsers.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdUsers, Me.cmdFriends, Me.cmdChannels})
        Me.tlbUsers.ButtonSize = New System.Drawing.Size(23, 22)
        Me.tlbUsers.CausesValidation = False
        Me.tlbUsers.DropDownArrows = True
        Me.tlbUsers.ImageList = Me.ilsUsersList
        Me.tlbUsers.Location = New System.Drawing.Point(0, 18)
        Me.tlbUsers.Name = "tlbUsers"
        Me.tlbUsers.ShowToolTips = True
        Me.tlbUsers.Size = New System.Drawing.Size(144, 28)
        Me.tlbUsers.TabIndex = 49
        '
        'cmdUsers
        '
        Me.cmdUsers.ImageIndex = 0
        Me.cmdUsers.Pushed = True
        Me.cmdUsers.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdUsers.Tag = "1"
        Me.cmdUsers.ToolTipText = "Список пользователей активного канала"
        '
        'cmdFriends
        '
        Me.cmdFriends.ImageIndex = 1
        Me.cmdFriends.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdFriends.Tag = "2"
        Me.cmdFriends.ToolTipText = "Список и состояние друзей"
        Me.cmdFriends.Visible = False
        '
        'cmdChannels
        '
        Me.cmdChannels.ImageIndex = 6
        Me.cmdChannels.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.cmdChannels.Tag = "3"
        Me.cmdChannels.ToolTipText = "Избранные каналы"
        '
        'cmdList
        '
        Me.cmdList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmdList.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdList.Location = New System.Drawing.Point(0, 0)
        Me.cmdList.Name = "cmdList"
        Me.cmdList.Size = New System.Drawing.Size(144, 18)
        Me.cmdList.TabIndex = 48
        Me.cmdList.Text = "Всего: 0"
        Me.cmdList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlInterf_Colors
        '
        Me.pnlInterf_Colors.Controls.Add(Me.pnlColorButtons)
        Me.pnlInterf_Colors.Controls.Add(Me.pnlColorBar)
        Me.pnlInterf_Colors.Controls.Add(Me.Button2)
        Me.pnlInterf_Colors.Controls.Add(Me.cmdSaveColorSchame)
        Me.pnlInterf_Colors.Controls.Add(Me.cmbSchemes)
        Me.pnlInterf_Colors.Controls.Add(Me.lblColorTbl)
        Me.pnlInterf_Colors.Location = New System.Drawing.Point(816, 48)
        Me.pnlInterf_Colors.Name = "pnlInterf_Colors"
        Me.pnlInterf_Colors.Size = New System.Drawing.Size(464, 392)
        Me.pnlInterf_Colors.TabIndex = 2
        Me.pnlInterf_Colors.Tag = "ircgui_getcolorspnl"
        '
        'pnlColorButtons
        '
        Me.pnlColorButtons.Controls.Add(Me.cmd10)
        Me.pnlColorButtons.Controls.Add(Me.cmd11)
        Me.pnlColorButtons.Controls.Add(Me.cmd3)
        Me.pnlColorButtons.Controls.Add(Me.cmd20)
        Me.pnlColorButtons.Controls.Add(Me.cmd19)
        Me.pnlColorButtons.Controls.Add(Me.cmd17)
        Me.pnlColorButtons.Controls.Add(Me.cmd18)
        Me.pnlColorButtons.Controls.Add(Me.cmd4)
        Me.pnlColorButtons.Controls.Add(Me.cmd12)
        Me.pnlColorButtons.Controls.Add(Me.cmd6)
        Me.pnlColorButtons.Controls.Add(Me.cmd8)
        Me.pnlColorButtons.Controls.Add(Me.cmd7)
        Me.pnlColorButtons.Controls.Add(Me.cmd1)
        Me.pnlColorButtons.Controls.Add(Me.cmd9)
        Me.pnlColorButtons.Controls.Add(Me.cmd5)
        Me.pnlColorButtons.Controls.Add(Me.cmd13)
        Me.pnlColorButtons.Controls.Add(Me.cmd16)
        Me.pnlColorButtons.Controls.Add(Me.cmd2)
        Me.pnlColorButtons.Controls.Add(Me.cmd14)
        Me.pnlColorButtons.Controls.Add(Me.cmd15)
        Me.pnlColorButtons.Location = New System.Drawing.Point(24, 80)
        Me.pnlColorButtons.Name = "pnlColorButtons"
        Me.pnlColorButtons.Size = New System.Drawing.Size(408, 240)
        Me.pnlColorButtons.TabIndex = 115
        '
        'cmd10
        '
        Me.cmd10.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd10.BackColor = System.Drawing.Color.LimeGreen
        Me.cmd10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd10.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd10.Location = New System.Drawing.Point(8, 218)
        Me.cmd10.Name = "cmd10"
        Me.cmd10.Size = New System.Drawing.Size(192, 20)
        Me.cmd10.TabIndex = 132
        Me.cmd10.Text = "Nick"
        Me.cmd10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd11
        '
        Me.cmd11.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd11.BackColor = System.Drawing.Color.Black
        Me.cmd11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd11.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd11.Location = New System.Drawing.Point(208, 2)
        Me.cmd11.Name = "cmd11"
        Me.cmd11.Size = New System.Drawing.Size(192, 20)
        Me.cmd11.TabIndex = 133
        Me.cmd11.Text = "Normal"
        Me.cmd11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd3
        '
        Me.cmd3.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd3.BackColor = System.Drawing.Color.Gray
        Me.cmd3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd3.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd3.Location = New System.Drawing.Point(8, 50)
        Me.cmd3.Name = "cmd3"
        Me.cmd3.Size = New System.Drawing.Size(192, 20)
        Me.cmd3.TabIndex = 131
        Me.cmd3.Text = "Highlight Text"
        Me.cmd3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd20
        '
        Me.cmd20.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd20.BackColor = System.Drawing.Color.Gray
        Me.cmd20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd20.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd20.Location = New System.Drawing.Point(208, 218)
        Me.cmd20.Name = "cmd20"
        Me.cmd20.Size = New System.Drawing.Size(192, 20)
        Me.cmd20.TabIndex = 130
        Me.cmd20.Text = "Whois"
        Me.cmd20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd19
        '
        Me.cmd19.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd19.BackColor = System.Drawing.Color.Gray
        Me.cmd19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd19.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd19.Location = New System.Drawing.Point(208, 194)
        Me.cmd19.Name = "cmd19"
        Me.cmd19.Size = New System.Drawing.Size(192, 20)
        Me.cmd19.TabIndex = 129
        Me.cmd19.Text = "Wallops"
        Me.cmd19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd17
        '
        Me.cmd17.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd17.BackColor = System.Drawing.Color.FromArgb(CType(103, Byte), CType(60, Byte), CType(239, Byte))
        Me.cmd17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd17.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd17.Location = New System.Drawing.Point(208, 146)
        Me.cmd17.Name = "cmd17"
        Me.cmd17.Size = New System.Drawing.Size(192, 20)
        Me.cmd17.TabIndex = 127
        Me.cmd17.Text = "Quit"
        Me.cmd17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd18
        '
        Me.cmd18.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd18.BackColor = System.Drawing.Color.Black
        Me.cmd18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd18.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd18.Location = New System.Drawing.Point(208, 170)
        Me.cmd18.Name = "cmd18"
        Me.cmd18.Size = New System.Drawing.Size(192, 20)
        Me.cmd18.TabIndex = 128
        Me.cmd18.Text = "Topic"
        Me.cmd18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd4
        '
        Me.cmd4.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd4.BackColor = System.Drawing.Color.LimeGreen
        Me.cmd4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd4.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd4.Location = New System.Drawing.Point(8, 74)
        Me.cmd4.Name = "cmd4"
        Me.cmd4.Size = New System.Drawing.Size(192, 20)
        Me.cmd4.TabIndex = 114
        Me.cmd4.Text = "Info"
        Me.cmd4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd12
        '
        Me.cmd12.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd12.BackColor = System.Drawing.Color.Brown
        Me.cmd12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd12.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd12.Location = New System.Drawing.Point(208, 26)
        Me.cmd12.Name = "cmd12"
        Me.cmd12.Size = New System.Drawing.Size(192, 20)
        Me.cmd12.TabIndex = 121
        Me.cmd12.Text = "Notice"
        Me.cmd12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd6
        '
        Me.cmd6.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd6.BackColor = System.Drawing.Color.LimeGreen
        Me.cmd6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd6.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd6.Location = New System.Drawing.Point(8, 122)
        Me.cmd6.Name = "cmd6"
        Me.cmd6.Size = New System.Drawing.Size(192, 20)
        Me.cmd6.TabIndex = 119
        Me.cmd6.Text = "Invite"
        Me.cmd6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd8
        '
        Me.cmd8.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd8.BackColor = System.Drawing.Color.LimeGreen
        Me.cmd8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd8.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd8.Location = New System.Drawing.Point(8, 170)
        Me.cmd8.Name = "cmd8"
        Me.cmd8.Size = New System.Drawing.Size(192, 20)
        Me.cmd8.TabIndex = 125
        Me.cmd8.Text = "Kick"
        Me.cmd8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd7
        '
        Me.cmd7.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd7.BackColor = System.Drawing.Color.LimeGreen
        Me.cmd7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd7.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd7.Location = New System.Drawing.Point(8, 146)
        Me.cmd7.Name = "cmd7"
        Me.cmd7.Size = New System.Drawing.Size(192, 20)
        Me.cmd7.TabIndex = 122
        Me.cmd7.Text = "Join"
        Me.cmd7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd1
        '
        Me.cmd1.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd1.BackColor = System.Drawing.Color.DarkMagenta
        Me.cmd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd1.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd1.Location = New System.Drawing.Point(8, 2)
        Me.cmd1.Name = "cmd1"
        Me.cmd1.Size = New System.Drawing.Size(192, 20)
        Me.cmd1.TabIndex = 116
        Me.cmd1.Text = "Action"
        Me.cmd1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd9
        '
        Me.cmd9.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd9.BackColor = System.Drawing.Color.Black
        Me.cmd9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd9.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd9.Location = New System.Drawing.Point(8, 194)
        Me.cmd9.Name = "cmd9"
        Me.cmd9.Size = New System.Drawing.Size(192, 20)
        Me.cmd9.TabIndex = 126
        Me.cmd9.Text = "Mode"
        Me.cmd9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd5
        '
        Me.cmd5.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd5.BackColor = System.Drawing.Color.LimeGreen
        Me.cmd5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd5.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd5.Location = New System.Drawing.Point(8, 98)
        Me.cmd5.Name = "cmd5"
        Me.cmd5.Size = New System.Drawing.Size(192, 20)
        Me.cmd5.TabIndex = 115
        Me.cmd5.Text = "Info2"
        Me.cmd5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd13
        '
        Me.cmd13.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd13.BackColor = System.Drawing.Color.Purple
        Me.cmd13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd13.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd13.Location = New System.Drawing.Point(208, 50)
        Me.cmd13.Name = "cmd13"
        Me.cmd13.Size = New System.Drawing.Size(192, 20)
        Me.cmd13.TabIndex = 117
        Me.cmd13.Text = "Notify"
        Me.cmd13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd16
        '
        Me.cmd16.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd16.BackColor = System.Drawing.Color.Gray
        Me.cmd16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd16.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd16.Location = New System.Drawing.Point(208, 122)
        Me.cmd16.Name = "cmd16"
        Me.cmd16.Size = New System.Drawing.Size(192, 20)
        Me.cmd16.TabIndex = 124
        Me.cmd16.Text = "Part"
        Me.cmd16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd2
        '
        Me.cmd2.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd2.BackColor = System.Drawing.Color.Red
        Me.cmd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd2.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd2.Location = New System.Drawing.Point(8, 26)
        Me.cmd2.Name = "cmd2"
        Me.cmd2.Size = New System.Drawing.Size(192, 20)
        Me.cmd2.TabIndex = 118
        Me.cmd2.Text = "CTCP"
        Me.cmd2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd14
        '
        Me.cmd14.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd14.BackColor = System.Drawing.Color.FromArgb(CType(103, Byte), CType(60, Byte), CType(239, Byte))
        Me.cmd14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd14.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd14.Location = New System.Drawing.Point(208, 74)
        Me.cmd14.Name = "cmd14"
        Me.cmd14.Size = New System.Drawing.Size(192, 20)
        Me.cmd14.TabIndex = 120
        Me.cmd14.Text = "Other"
        Me.cmd14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd15
        '
        Me.cmd15.Appearance = System.Windows.Forms.Appearance.Button
        Me.cmd15.BackColor = System.Drawing.Color.Black
        Me.cmd15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd15.ForeColor = System.Drawing.Color.Gainsboro
        Me.cmd15.Location = New System.Drawing.Point(208, 98)
        Me.cmd15.Name = "cmd15"
        Me.cmd15.Size = New System.Drawing.Size(192, 20)
        Me.cmd15.TabIndex = 123
        Me.cmd15.Text = "Own"
        Me.cmd15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlColorBar
        '
        Me.pnlColorBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorBar.Controls.Add(Me.lblC16)
        Me.pnlColorBar.Controls.Add(Me.lblC15)
        Me.pnlColorBar.Controls.Add(Me.lblC14)
        Me.pnlColorBar.Controls.Add(Me.lblC13)
        Me.pnlColorBar.Controls.Add(Me.lblC12)
        Me.pnlColorBar.Controls.Add(Me.lblC11)
        Me.pnlColorBar.Controls.Add(Me.lblC10)
        Me.pnlColorBar.Controls.Add(Me.lblC9)
        Me.pnlColorBar.Controls.Add(Me.lblC8)
        Me.pnlColorBar.Controls.Add(Me.lblC7)
        Me.pnlColorBar.Controls.Add(Me.lblC6)
        Me.pnlColorBar.Controls.Add(Me.lblC5)
        Me.pnlColorBar.Controls.Add(Me.lblC4)
        Me.pnlColorBar.Controls.Add(Me.lblC3)
        Me.pnlColorBar.Controls.Add(Me.lblC2)
        Me.pnlColorBar.Controls.Add(Me.lblC1)
        Me.pnlColorBar.Location = New System.Drawing.Point(32, 328)
        Me.pnlColorBar.Name = "pnlColorBar"
        Me.pnlColorBar.Size = New System.Drawing.Size(384, 40)
        Me.pnlColorBar.TabIndex = 114
        '
        'lblC16
        '
        Me.lblC16.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblC16.Location = New System.Drawing.Point(360, 0)
        Me.lblC16.Name = "lblC16"
        Me.lblC16.Size = New System.Drawing.Size(24, 38)
        Me.lblC16.TabIndex = 15
        Me.lblC16.Tag = "15"
        Me.lblC16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC15
        '
        Me.lblC15.BackColor = System.Drawing.Color.Gray
        Me.lblC15.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC15.Location = New System.Drawing.Point(336, 0)
        Me.lblC15.Name = "lblC15"
        Me.lblC15.Size = New System.Drawing.Size(24, 38)
        Me.lblC15.TabIndex = 14
        Me.lblC15.Tag = "14"
        Me.lblC15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC14
        '
        Me.lblC14.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
        Me.lblC14.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC14.Location = New System.Drawing.Point(312, 0)
        Me.lblC14.Name = "lblC14"
        Me.lblC14.Size = New System.Drawing.Size(24, 38)
        Me.lblC14.TabIndex = 13
        Me.lblC14.Tag = "13"
        Me.lblC14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC13
        '
        Me.lblC13.BackColor = System.Drawing.Color.Blue
        Me.lblC13.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC13.Location = New System.Drawing.Point(288, 0)
        Me.lblC13.Name = "lblC13"
        Me.lblC13.Size = New System.Drawing.Size(24, 38)
        Me.lblC13.TabIndex = 12
        Me.lblC13.Tag = "12"
        Me.lblC13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC12
        '
        Me.lblC12.BackColor = System.Drawing.Color.Aqua
        Me.lblC12.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC12.Location = New System.Drawing.Point(264, 0)
        Me.lblC12.Name = "lblC12"
        Me.lblC12.Size = New System.Drawing.Size(24, 38)
        Me.lblC12.TabIndex = 11
        Me.lblC12.Tag = "11"
        Me.lblC12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC11
        '
        Me.lblC11.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(192, Byte))
        Me.lblC11.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC11.Location = New System.Drawing.Point(240, 0)
        Me.lblC11.Name = "lblC11"
        Me.lblC11.Size = New System.Drawing.Size(24, 38)
        Me.lblC11.TabIndex = 10
        Me.lblC11.Tag = "10"
        Me.lblC11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC10
        '
        Me.lblC10.BackColor = System.Drawing.Color.Lime
        Me.lblC10.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC10.Location = New System.Drawing.Point(216, 0)
        Me.lblC10.Name = "lblC10"
        Me.lblC10.Size = New System.Drawing.Size(24, 38)
        Me.lblC10.TabIndex = 9
        Me.lblC10.Tag = "9"
        Me.lblC10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC9
        '
        Me.lblC9.BackColor = System.Drawing.Color.Yellow
        Me.lblC9.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC9.Location = New System.Drawing.Point(192, 0)
        Me.lblC9.Name = "lblC9"
        Me.lblC9.Size = New System.Drawing.Size(24, 38)
        Me.lblC9.TabIndex = 8
        Me.lblC9.Tag = "8"
        Me.lblC9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC8
        '
        Me.lblC8.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.lblC8.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC8.Location = New System.Drawing.Point(168, 0)
        Me.lblC8.Name = "lblC8"
        Me.lblC8.Size = New System.Drawing.Size(24, 38)
        Me.lblC8.TabIndex = 7
        Me.lblC8.Tag = "7"
        Me.lblC8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC7
        '
        Me.lblC7.BackColor = System.Drawing.Color.Purple
        Me.lblC7.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC7.Location = New System.Drawing.Point(144, 0)
        Me.lblC7.Name = "lblC7"
        Me.lblC7.Size = New System.Drawing.Size(24, 38)
        Me.lblC7.TabIndex = 6
        Me.lblC7.Tag = "6"
        Me.lblC7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC6
        '
        Me.lblC6.BackColor = System.Drawing.Color.Maroon
        Me.lblC6.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC6.Location = New System.Drawing.Point(120, 0)
        Me.lblC6.Name = "lblC6"
        Me.lblC6.Size = New System.Drawing.Size(24, 38)
        Me.lblC6.TabIndex = 5
        Me.lblC6.Tag = "5"
        Me.lblC6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC5
        '
        Me.lblC5.BackColor = System.Drawing.Color.Red
        Me.lblC5.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC5.Location = New System.Drawing.Point(96, 0)
        Me.lblC5.Name = "lblC5"
        Me.lblC5.Size = New System.Drawing.Size(24, 38)
        Me.lblC5.TabIndex = 4
        Me.lblC5.Tag = "4"
        Me.lblC5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC4
        '
        Me.lblC4.BackColor = System.Drawing.Color.Green
        Me.lblC4.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC4.Location = New System.Drawing.Point(72, 0)
        Me.lblC4.Name = "lblC4"
        Me.lblC4.Size = New System.Drawing.Size(24, 38)
        Me.lblC4.TabIndex = 3
        Me.lblC4.Tag = "3"
        Me.lblC4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC3
        '
        Me.lblC3.BackColor = System.Drawing.Color.Navy
        Me.lblC3.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC3.ForeColor = System.Drawing.Color.White
        Me.lblC3.Location = New System.Drawing.Point(48, 0)
        Me.lblC3.Name = "lblC3"
        Me.lblC3.Size = New System.Drawing.Size(24, 38)
        Me.lblC3.TabIndex = 2
        Me.lblC3.Tag = "2"
        Me.lblC3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC2
        '
        Me.lblC2.BackColor = System.Drawing.Color.Black
        Me.lblC2.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC2.ForeColor = System.Drawing.Color.White
        Me.lblC2.Location = New System.Drawing.Point(24, 0)
        Me.lblC2.Name = "lblC2"
        Me.lblC2.Size = New System.Drawing.Size(24, 38)
        Me.lblC2.TabIndex = 1
        Me.lblC2.Tag = "1"
        Me.lblC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC1
        '
        Me.lblC1.BackColor = System.Drawing.Color.White
        Me.lblC1.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblC1.Location = New System.Drawing.Point(0, 0)
        Me.lblC1.Name = "lblC1"
        Me.lblC1.Size = New System.Drawing.Size(24, 38)
        Me.lblC1.TabIndex = 0
        Me.lblC1.Tag = "0"
        Me.lblC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(344, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 24)
        Me.Button2.TabIndex = 110
        Me.Button2.Text = "Удалить"
        '
        'cmdSaveColorSchame
        '
        Me.cmdSaveColorSchame.Location = New System.Drawing.Point(240, 24)
        Me.cmdSaveColorSchame.Name = "cmdSaveColorSchame"
        Me.cmdSaveColorSchame.Size = New System.Drawing.Size(96, 24)
        Me.cmdSaveColorSchame.TabIndex = 109
        Me.cmdSaveColorSchame.Text = "Сохранить"
        '
        'cmbSchemes
        '
        Me.cmbSchemes.Location = New System.Drawing.Point(8, 24)
        Me.cmbSchemes.Name = "cmbSchemes"
        Me.cmbSchemes.Size = New System.Drawing.Size(216, 21)
        Me.cmbSchemes.TabIndex = 104
        '
        'lblColorTbl
        '
        Me.lblColorTbl.AutoSize = True
        Me.lblColorTbl.Location = New System.Drawing.Point(8, 8)
        Me.lblColorTbl.Name = "lblColorTbl"
        Me.lblColorTbl.TabIndex = 103
        Me.lblColorTbl.Text = "Цвеетовые схемы"
        '
        'pnlNetOptions
        '
        Me.pnlNetOptions.Controls.Add(Me.grpConnection)
        Me.pnlNetOptions.Controls.Add(Me.fraAddServer)
        Me.pnlNetOptions.Location = New System.Drawing.Point(280, 432)
        Me.pnlNetOptions.Name = "pnlNetOptions"
        Me.pnlNetOptions.Size = New System.Drawing.Size(480, 424)
        Me.pnlNetOptions.TabIndex = 3
        Me.pnlNetOptions.Tag = "ircgui_getservpnl"
        '
        'grpConnection
        '
        Me.grpConnection.Controls.Add(Me.cmdmIRCImport)
        Me.grpConnection.Controls.Add(Me.cmbServers)
        Me.grpConnection.Controls.Add(Me.lblServer)
        Me.grpConnection.Controls.Add(Me.cmdIRCNetworks)
        Me.grpConnection.Controls.Add(Me.lblNetName)
        Me.grpConnection.Controls.Add(Me.cmdAddserv)
        Me.grpConnection.Controls.Add(Me.cmdEditServ)
        Me.grpConnection.Controls.Add(Me.cmdDelServ)
        Me.grpConnection.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpConnection.Location = New System.Drawing.Point(8, 8)
        Me.grpConnection.Name = "grpConnection"
        Me.grpConnection.Size = New System.Drawing.Size(432, 144)
        Me.grpConnection.TabIndex = 9
        Me.grpConnection.TabStop = False
        Me.grpConnection.Text = "Подключение"
        '
        'cmdmIRCImport
        '
        Me.cmdmIRCImport.Enabled = False
        Me.cmdmIRCImport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdmIRCImport.Location = New System.Drawing.Point(304, 112)
        Me.cmdmIRCImport.Name = "cmdmIRCImport"
        Me.cmdmIRCImport.Size = New System.Drawing.Size(120, 24)
        Me.cmdmIRCImport.TabIndex = 9
        Me.cmdmIRCImport.Text = "Импорт списка"
        '
        'cmbServers
        '
        Me.cmbServers.ItemHeight = 13
        Me.cmbServers.Location = New System.Drawing.Point(8, 72)
        Me.cmbServers.Name = "cmbServers"
        Me.cmbServers.Size = New System.Drawing.Size(280, 21)
        Me.cmbServers.TabIndex = 2
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblServer.Location = New System.Drawing.Point(8, 56)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(102, 16)
        Me.lblServer.TabIndex = 6
        Me.lblServer.Text = "Название сервера"
        '
        'cmdIRCNetworks
        '
        Me.cmdIRCNetworks.Location = New System.Drawing.Point(8, 32)
        Me.cmdIRCNetworks.Name = "cmdIRCNetworks"
        Me.cmdIRCNetworks.Size = New System.Drawing.Size(280, 21)
        Me.cmdIRCNetworks.TabIndex = 1
        Me.cmdIRCNetworks.Text = "<None>"
        '
        'lblNetName
        '
        Me.lblNetName.AutoSize = True
        Me.lblNetName.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNetName.Location = New System.Drawing.Point(8, 16)
        Me.lblNetName.Name = "lblNetName"
        Me.lblNetName.Size = New System.Drawing.Size(108, 16)
        Me.lblNetName.TabIndex = 4
        Me.lblNetName.Text = "Название IRC-Сети"
        '
        'cmdAddserv
        '
        Me.cmdAddserv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddserv.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAddserv.Location = New System.Drawing.Point(304, 16)
        Me.cmdAddserv.Name = "cmdAddserv"
        Me.cmdAddserv.Size = New System.Drawing.Size(120, 24)
        Me.cmdAddserv.TabIndex = 8
        Me.cmdAddserv.Text = "Добавить"
        '
        'cmdEditServ
        '
        Me.cmdEditServ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditServ.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEditServ.Location = New System.Drawing.Point(304, 48)
        Me.cmdEditServ.Name = "cmdEditServ"
        Me.cmdEditServ.Size = New System.Drawing.Size(120, 24)
        Me.cmdEditServ.TabIndex = 9
        Me.cmdEditServ.Text = "Изменить"
        '
        'cmdDelServ
        '
        Me.cmdDelServ.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDelServ.Location = New System.Drawing.Point(304, 80)
        Me.cmdDelServ.Name = "cmdDelServ"
        Me.cmdDelServ.Size = New System.Drawing.Size(120, 24)
        Me.cmdDelServ.TabIndex = 10
        Me.cmdDelServ.Text = "Удалить"
        '
        'fraAddServer
        '
        Me.fraAddServer.Controls.Add(Me.cmdCancel)
        Me.fraAddServer.Controls.Add(Me.cmOk)
        Me.fraAddServer.Controls.Add(Me.lblDesc)
        Me.fraAddServer.Controls.Add(Me.txtDesc)
        Me.fraAddServer.Controls.Add(Me.txtGroup)
        Me.fraAddServer.Controls.Add(Me.lblGroup)
        Me.fraAddServer.Controls.Add(Me.txtPass)
        Me.fraAddServer.Controls.Add(Me.lblPass)
        Me.fraAddServer.Controls.Add(Me.lblPorts)
        Me.fraAddServer.Controls.Add(Me.txtPorts)
        Me.fraAddServer.Controls.Add(Me.lblServAddrShow)
        Me.fraAddServer.Controls.Add(Me.lblServAddr)
        Me.fraAddServer.Enabled = False
        Me.fraAddServer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.fraAddServer.Location = New System.Drawing.Point(8, 160)
        Me.fraAddServer.Name = "fraAddServer"
        Me.fraAddServer.Size = New System.Drawing.Size(432, 264)
        Me.fraAddServer.TabIndex = 4
        Me.fraAddServer.TabStop = False
        Me.fraAddServer.Text = "Параметры сервера"
        '
        'cmdCancel
        '
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Location = New System.Drawing.Point(336, 224)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(88, 24)
        Me.cmdCancel.TabIndex = 19
        Me.cmdCancel.Text = "Отмена"
        '
        'cmOk
        '
        Me.cmOk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmOk.Location = New System.Drawing.Point(240, 224)
        Me.cmOk.Name = "cmOk"
        Me.cmOk.Size = New System.Drawing.Size(88, 24)
        Me.cmOk.TabIndex = 18
        Me.cmOk.Text = "Ok"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblDesc.Location = New System.Drawing.Point(8, 136)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(57, 16)
        Me.lblDesc.TabIndex = 17
        Me.lblDesc.Text = "Описание"
        '
        'txtDesc
        '
        Me.txtDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc.Location = New System.Drawing.Point(8, 152)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(416, 20)
        Me.txtDesc.TabIndex = 6
        Me.txtDesc.Text = ""
        '
        'txtGroup
        '
        Me.txtGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGroup.Location = New System.Drawing.Point(8, 32)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Size = New System.Drawing.Size(416, 20)
        Me.txtGroup.TabIndex = 3
        Me.txtGroup.Text = ""
        '
        'lblGroup
        '
        Me.lblGroup.AutoSize = True
        Me.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblGroup.Location = New System.Drawing.Point(8, 16)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(53, 16)
        Me.lblGroup.TabIndex = 12
        Me.lblGroup.Text = "IRC-Сеть"
        '
        'txtPass
        '
        Me.txtPass.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPass.Location = New System.Drawing.Point(8, 192)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(416, 20)
        Me.txtPass.TabIndex = 7
        Me.txtPass.Text = ""
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblPass.Location = New System.Drawing.Point(8, 176)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(44, 16)
        Me.lblPass.TabIndex = 10
        Me.lblPass.Text = "Пароль"
        '
        'lblPorts
        '
        Me.lblPorts.AutoSize = True
        Me.lblPorts.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblPorts.Location = New System.Drawing.Point(8, 96)
        Me.lblPorts.Name = "lblPorts"
        Me.lblPorts.Size = New System.Drawing.Size(30, 16)
        Me.lblPorts.TabIndex = 9
        Me.lblPorts.Text = "Порт"
        '
        'txtPorts
        '
        Me.txtPorts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPorts.Location = New System.Drawing.Point(8, 112)
        Me.txtPorts.Name = "txtPorts"
        Me.txtPorts.Size = New System.Drawing.Size(416, 20)
        Me.txtPorts.TabIndex = 5
        Me.txtPorts.Text = ""
        '
        'lblServAddrShow
        '
        Me.lblServAddrShow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblServAddrShow.Location = New System.Drawing.Point(8, 72)
        Me.lblServAddrShow.Name = "lblServAddrShow"
        Me.lblServAddrShow.Size = New System.Drawing.Size(416, 20)
        Me.lblServAddrShow.TabIndex = 4
        Me.lblServAddrShow.Text = ""
        '
        'lblServAddr
        '
        Me.lblServAddr.AutoSize = True
        Me.lblServAddr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblServAddr.Location = New System.Drawing.Point(8, 56)
        Me.lblServAddr.Name = "lblServAddr"
        Me.lblServAddr.Size = New System.Drawing.Size(86, 16)
        Me.lblServAddr.TabIndex = 0
        Me.lblServAddr.Text = "Адрес сервера:"
        '
        'pnlNetOptions2
        '
        Me.pnlNetOptions2.Controls.Add(Me.lblReconWait)
        Me.pnlNetOptions2.Controls.Add(Me.nudRWait)
        Me.pnlNetOptions2.Controls.Add(Me.chkReconnect)
        Me.pnlNetOptions2.Controls.Add(Me.chkAutoConnect)
        Me.pnlNetOptions2.Location = New System.Drawing.Point(712, 112)
        Me.pnlNetOptions2.Name = "pnlNetOptions2"
        Me.pnlNetOptions2.Size = New System.Drawing.Size(496, 376)
        Me.pnlNetOptions2.TabIndex = 4
        Me.pnlNetOptions2.Tag = "ircgui_getnetoptionspnl"
        '
        'lblReconWait
        '
        Me.lblReconWait.AutoSize = True
        Me.lblReconWait.Location = New System.Drawing.Point(32, 72)
        Me.lblReconWait.Name = "lblReconWait"
        Me.lblReconWait.Size = New System.Drawing.Size(187, 16)
        Me.lblReconWait.TabIndex = 3
        Me.lblReconWait.Text = "Задержка между попытками: (сек)"
        Me.lblReconWait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudRWait
        '
        Me.nudRWait.Location = New System.Drawing.Point(224, 72)
        Me.nudRWait.Name = "nudRWait"
        Me.nudRWait.Size = New System.Drawing.Size(88, 20)
        Me.nudRWait.TabIndex = 2
        Me.nudRWait.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'chkReconnect
        '
        Me.chkReconnect.Location = New System.Drawing.Point(16, 40)
        Me.chkReconnect.Name = "chkReconnect"
        Me.chkReconnect.Size = New System.Drawing.Size(472, 24)
        Me.chkReconnect.TabIndex = 1
        Me.chkReconnect.Text = "Переподключатся при разрыве соединения"
        '
        'chkAutoConnect
        '
        Me.chkAutoConnect.Location = New System.Drawing.Point(16, 16)
        Me.chkAutoConnect.Name = "chkAutoConnect"
        Me.chkAutoConnect.Size = New System.Drawing.Size(472, 24)
        Me.chkAutoConnect.TabIndex = 0
        Me.chkAutoConnect.Text = "Автоматически подключатся при запуске программы"
        '
        'pnlStrings
        '
        Me.pnlStrings.Controls.Add(Me.cmdColorTextHelp)
        Me.pnlStrings.Controls.Add(Me.txtfingerReply)
        Me.pnlStrings.Controls.Add(Me.lblFingerReply)
        Me.pnlStrings.Controls.Add(Me.cmdQuitSDColor)
        Me.pnlStrings.Controls.Add(Me.cmdQuitColor)
        Me.pnlStrings.Controls.Add(Me.txtQuitMsg)
        Me.pnlStrings.Controls.Add(Me.txtQuitMsgSD)
        Me.pnlStrings.Controls.Add(Me.Label1)
        Me.pnlStrings.Controls.Add(Me.lblquitMsg)
        Me.pnlStrings.Location = New System.Drawing.Point(864, 32)
        Me.pnlStrings.Name = "pnlStrings"
        Me.pnlStrings.Size = New System.Drawing.Size(456, 368)
        Me.pnlStrings.TabIndex = 5
        Me.pnlStrings.Tag = "ircgui_strings"
        '
        'cmdColorTextHelp
        '
        Me.cmdColorTextHelp.Enabled = False
        Me.cmdColorTextHelp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdColorTextHelp.Location = New System.Drawing.Point(8, 296)
        Me.cmdColorTextHelp.Name = "cmdColorTextHelp"
        Me.cmdColorTextHelp.Size = New System.Drawing.Size(440, 24)
        Me.cmdColorTextHelp.TabIndex = 8
        Me.cmdColorTextHelp.Text = "Правила ввода цветного текста"
        '
        'txtfingerReply
        '
        Me.txtfingerReply.Location = New System.Drawing.Point(8, 136)
        Me.txtfingerReply.Name = "txtfingerReply"
        Me.txtfingerReply.Size = New System.Drawing.Size(312, 20)
        Me.txtfingerReply.TabIndex = 7
        Me.txtfingerReply.Text = ""
        '
        'lblFingerReply
        '
        Me.lblFingerReply.AutoSize = True
        Me.lblFingerReply.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblFingerReply.Location = New System.Drawing.Point(8, 120)
        Me.lblFingerReply.Name = "lblFingerReply"
        Me.lblFingerReply.Size = New System.Drawing.Size(169, 16)
        Me.lblFingerReply.TabIndex = 6
        Me.lblFingerReply.Text = "Текст на запрос CTCP FINGER"
        '
        'cmdQuitSDColor
        '
        Me.cmdQuitSDColor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdQuitSDColor.Location = New System.Drawing.Point(328, 64)
        Me.cmdQuitSDColor.Name = "cmdQuitSDColor"
        Me.cmdQuitSDColor.Size = New System.Drawing.Size(96, 20)
        Me.cmdQuitSDColor.TabIndex = 5
        Me.cmdQuitSDColor.Text = "Цветной"
        '
        'cmdQuitColor
        '
        Me.cmdQuitColor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdQuitColor.Location = New System.Drawing.Point(328, 24)
        Me.cmdQuitColor.Name = "cmdQuitColor"
        Me.cmdQuitColor.Size = New System.Drawing.Size(96, 20)
        Me.cmdQuitColor.TabIndex = 4
        Me.cmdQuitColor.Text = "Цветной"
        '
        'txtQuitMsg
        '
        Me.txtQuitMsg.Location = New System.Drawing.Point(8, 24)
        Me.txtQuitMsg.Multiline = False
        Me.txtQuitMsg.Name = "txtQuitMsg"
        Me.txtQuitMsg.Size = New System.Drawing.Size(312, 20)
        Me.txtQuitMsg.TabIndex = 3
        Me.txtQuitMsg.Text = ""
        '
        'txtQuitMsgSD
        '
        Me.txtQuitMsgSD.Location = New System.Drawing.Point(8, 64)
        Me.txtQuitMsgSD.Multiline = False
        Me.txtQuitMsgSD.Name = "txtQuitMsgSD"
        Me.txtQuitMsgSD.Size = New System.Drawing.Size(312, 20)
        Me.txtQuitMsgSD.TabIndex = 2
        Me.txtQuitMsgSD.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Текст при завершении работы системы/перезагрузке"
        '
        'lblquitMsg
        '
        Me.lblquitMsg.AutoSize = True
        Me.lblquitMsg.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblquitMsg.Location = New System.Drawing.Point(8, 8)
        Me.lblquitMsg.Name = "lblquitMsg"
        Me.lblquitMsg.Size = New System.Drawing.Size(303, 16)
        Me.lblquitMsg.TabIndex = 0
        Me.lblquitMsg.Text = "Текст при выходе из программы/отключении от сервера"
        '
        'pnlUserSettings
        '
        Me.pnlUserSettings.Controls.Add(Me.txtUserID)
        Me.pnlUserSettings.Controls.Add(Me.lblUserID)
        Me.pnlUserSettings.Controls.Add(Me.lblWarn)
        Me.pnlUserSettings.Controls.Add(Me.txtNick)
        Me.pnlUserSettings.Controls.Add(Me.txtAltNick)
        Me.pnlUserSettings.Controls.Add(Me.txtFullname)
        Me.pnlUserSettings.Controls.Add(Me.lblAltNick)
        Me.pnlUserSettings.Controls.Add(Me.lblNickname)
        Me.pnlUserSettings.Controls.Add(Me.lblFullname)
        Me.pnlUserSettings.Location = New System.Drawing.Point(864, 208)
        Me.pnlUserSettings.Name = "pnlUserSettings"
        Me.pnlUserSettings.Size = New System.Drawing.Size(504, 376)
        Me.pnlUserSettings.TabIndex = 6
        Me.pnlUserSettings.Tag = "ircgui_getuserspnl"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(8, 192)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(240, 20)
        Me.txtUserID.TabIndex = 8
        Me.txtUserID.Text = ""
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblUserID.Location = New System.Drawing.Point(8, 176)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(85, 16)
        Me.lblUserID.TabIndex = 7
        Me.lblUserID.Text = "Идентифкатор:"
        '
        'lblWarn
        '
        Me.lblWarn.Location = New System.Drawing.Point(16, 256)
        Me.lblWarn.Name = "lblWarn"
        Me.lblWarn.Size = New System.Drawing.Size(384, 56)
        Me.lblWarn.TabIndex = 6
        Me.lblWarn.Text = "ВНИМАНИЕ: Ник не может начинаться с пробела, содержать пробелы, и не должен содер" & _
        "жать следующих символов: ""! ? * . , : <> ()"" Длина ника и некоторе дополнительны" & _
        "е ограничения задаются администратором сервера"
        '
        'txtNick
        '
        Me.txtNick.Location = New System.Drawing.Point(8, 64)
        Me.txtNick.Name = "txtNick"
        Me.txtNick.Size = New System.Drawing.Size(240, 20)
        Me.txtNick.TabIndex = 5
        Me.txtNick.Text = ""
        '
        'txtAltNick
        '
        Me.txtAltNick.Location = New System.Drawing.Point(8, 104)
        Me.txtAltNick.Name = "txtAltNick"
        Me.txtAltNick.Size = New System.Drawing.Size(240, 20)
        Me.txtAltNick.TabIndex = 4
        Me.txtAltNick.Text = ""
        '
        'txtFullname
        '
        Me.txtFullname.Location = New System.Drawing.Point(8, 24)
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.Size = New System.Drawing.Size(240, 20)
        Me.txtFullname.TabIndex = 3
        Me.txtFullname.Text = ""
        '
        'lblAltNick
        '
        Me.lblAltNick.AutoSize = True
        Me.lblAltNick.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblAltNick.Location = New System.Drawing.Point(8, 88)
        Me.lblAltNick.Name = "lblAltNick"
        Me.lblAltNick.Size = New System.Drawing.Size(117, 16)
        Me.lblAltNick.TabIndex = 2
        Me.lblAltNick.Text = "Альтернативный ник:"
        '
        'lblNickname
        '
        Me.lblNickname.AutoSize = True
        Me.lblNickname.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblNickname.Location = New System.Drawing.Point(8, 48)
        Me.lblNickname.Name = "lblNickname"
        Me.lblNickname.Size = New System.Drawing.Size(63, 16)
        Me.lblNickname.TabIndex = 1
        Me.lblNickname.Text = "Ник в чате:"
        '
        'lblFullname
        '
        Me.lblFullname.AutoSize = True
        Me.lblFullname.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblFullname.Location = New System.Drawing.Point(8, 8)
        Me.lblFullname.Name = "lblFullname"
        Me.lblFullname.Size = New System.Drawing.Size(71, 16)
        Me.lblFullname.TabIndex = 0
        Me.lblFullname.Text = "Полное имя:"
        '
        'pnlPerform
        '
        Me.pnlPerform.Controls.Add(Me.cmdPerformDelIrcNet)
        Me.pnlPerform.Controls.Add(Me.cmdPerformAddIrcNet)
        Me.pnlPerform.Controls.Add(Me.lblIRCNetName)
        Me.pnlPerform.Controls.Add(Me.cmbPerformIRCNetworks)
        Me.pnlPerform.Controls.Add(Me.txtPerform)
        Me.pnlPerform.Controls.Add(Me.lblPerform)
        Me.pnlPerform.Location = New System.Drawing.Point(264, 72)
        Me.pnlPerform.Name = "pnlPerform"
        Me.pnlPerform.Size = New System.Drawing.Size(440, 320)
        Me.pnlPerform.TabIndex = 7
        Me.pnlPerform.Tag = "ircgui_performwindow"
        '
        'txtPerform
        '
        Me.txtPerform.Location = New System.Drawing.Point(8, 80)
        Me.txtPerform.Name = "txtPerform"
        Me.txtPerform.Size = New System.Drawing.Size(384, 232)
        Me.txtPerform.TabIndex = 2
        Me.txtPerform.Text = ""
        '
        'lblPerform
        '
        Me.lblPerform.AutoSize = True
        Me.lblPerform.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblPerform.Location = New System.Drawing.Point(8, 56)
        Me.lblPerform.Name = "lblPerform"
        Me.lblPerform.Size = New System.Drawing.Size(289, 16)
        Me.lblPerform.TabIndex = 1
        Me.lblPerform.Text = "Комманды выполняемые при подключении к серверу"
        '
        'pnlModes
        '
        Me.pnlModes.Controls.Add(Me.lblOSPrivExec)
        Me.pnlModes.Controls.Add(Me.txtOnSetModeExec)
        Me.pnlModes.Controls.Add(Me.lblExecCmd)
        Me.pnlModes.Controls.Add(Me.chkSetAway)
        Me.pnlModes.Controls.Add(Me.txtModePrivAns)
        Me.pnlModes.Controls.Add(Me.chkMsgPopup)
        Me.pnlModes.Controls.Add(Me.cmbModes)
        Me.pnlModes.Controls.Add(Me.lblSetModes)
        Me.pnlModes.Controls.Add(Me.chkSndsOff)
        Me.pnlModes.Controls.Add(Me.lblPrefix)
        Me.pnlModes.Controls.Add(Me.txtPrefix)
        Me.pnlModes.Controls.Add(Me.lblModeSettings)
        Me.pnlModes.Location = New System.Drawing.Point(-376, 112)
        Me.pnlModes.Name = "pnlModes"
        Me.pnlModes.Size = New System.Drawing.Size(480, 400)
        Me.pnlModes.TabIndex = 8
        Me.pnlModes.Tag = "ircgui_modes"
        '
        'lblOSPrivExec
        '
        Me.lblOSPrivExec.AutoSize = True
        Me.lblOSPrivExec.Location = New System.Drawing.Point(32, 208)
        Me.lblOSPrivExec.Name = "lblOSPrivExec"
        Me.lblOSPrivExec.Size = New System.Drawing.Size(268, 16)
        Me.lblOSPrivExec.TabIndex = 13
        Me.lblOSPrivExec.Text = "При открытии привата в этом режиме выполнить:"
        '
        'txtOnSetModeExec
        '
        Me.txtOnSetModeExec.Location = New System.Drawing.Point(32, 320)
        Me.txtOnSetModeExec.Name = "txtOnSetModeExec"
        Me.txtOnSetModeExec.Size = New System.Drawing.Size(368, 20)
        Me.txtOnSetModeExec.TabIndex = 12
        Me.txtOnSetModeExec.Text = ""
        '
        'lblExecCmd
        '
        Me.lblExecCmd.AutoSize = True
        Me.lblExecCmd.Location = New System.Drawing.Point(32, 304)
        Me.lblExecCmd.Name = "lblExecCmd"
        Me.lblExecCmd.Size = New System.Drawing.Size(189, 16)
        Me.lblExecCmd.TabIndex = 11
        Me.lblExecCmd.Text = "При установке режима выполнить:"
        '
        'chkSetAway
        '
        Me.chkSetAway.Location = New System.Drawing.Point(32, 80)
        Me.chkSetAway.Name = "chkSetAway"
        Me.chkSetAway.Size = New System.Drawing.Size(432, 24)
        Me.chkSetAway.TabIndex = 10
        Me.chkSetAway.Text = "Установить состояние AWAY (затемнёный флажок- не изменять состояние)"
        Me.chkSetAway.ThreeState = True
        '
        'txtModePrivAns
        '
        Me.txtModePrivAns.Location = New System.Drawing.Point(32, 224)
        Me.txtModePrivAns.Multiline = True
        Me.txtModePrivAns.Name = "txtModePrivAns"
        Me.txtModePrivAns.Size = New System.Drawing.Size(360, 64)
        Me.txtModePrivAns.TabIndex = 9
        Me.txtModePrivAns.Text = ""
        '
        'chkMsgPopup
        '
        Me.chkMsgPopup.Location = New System.Drawing.Point(32, 176)
        Me.chkMsgPopup.Name = "chkMsgPopup"
        Me.chkMsgPopup.Size = New System.Drawing.Size(360, 16)
        Me.chkMsgPopup.TabIndex = 7
        Me.chkMsgPopup.Text = "Не разворачивать всплывающие сообщения"
        '
        'cmbModes
        '
        Me.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModes.Location = New System.Drawing.Point(24, 48)
        Me.cmbModes.Name = "cmbModes"
        Me.cmbModes.Size = New System.Drawing.Size(128, 21)
        Me.cmbModes.TabIndex = 6
        '
        'lblSetModes
        '
        Me.lblSetModes.AutoSize = True
        Me.lblSetModes.Location = New System.Drawing.Point(24, 32)
        Me.lblSetModes.Name = "lblSetModes"
        Me.lblSetModes.Size = New System.Drawing.Size(52, 16)
        Me.lblSetModes.TabIndex = 5
        Me.lblSetModes.Text = "Режимы:"
        '
        'chkSndsOff
        '
        Me.chkSndsOff.Location = New System.Drawing.Point(32, 152)
        Me.chkSndsOff.Name = "chkSndsOff"
        Me.chkSndsOff.Size = New System.Drawing.Size(360, 16)
        Me.chkSndsOff.TabIndex = 4
        Me.chkSndsOff.Text = "Отключить все звуки"
        '
        'lblPrefix
        '
        Me.lblPrefix.AutoSize = True
        Me.lblPrefix.Location = New System.Drawing.Point(24, 112)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(245, 16)
        Me.lblPrefix.TabIndex = 3
        Me.lblPrefix.Text = "При переключении режима изменить имя на:"
        '
        'txtPrefix
        '
        Me.txtPrefix.Location = New System.Drawing.Point(32, 128)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(320, 20)
        Me.txtPrefix.TabIndex = 2
        Me.txtPrefix.Text = ""
        '
        'lblModeSettings
        '
        Me.lblModeSettings.AutoSize = True
        Me.lblModeSettings.Location = New System.Drawing.Point(16, 8)
        Me.lblModeSettings.Name = "lblModeSettings"
        Me.lblModeSettings.Size = New System.Drawing.Size(111, 16)
        Me.lblModeSettings.TabIndex = 0
        Me.lblModeSettings.Text = "Настройки режимов"
        '
        'pnlSndOptions
        '
        Me.pnlSndOptions.Controls.Add(Me.pnlctcpsndsctl)
        Me.pnlSndOptions.Controls.Add(Me.pnlSndsCtl)
        Me.pnlSndOptions.Controls.Add(Me.lblSndfilename)
        Me.pnlSndOptions.Controls.Add(Me.chkUseCTCPSOUND)
        Me.pnlSndOptions.Controls.Add(Me.chkEnableSnds)
        Me.pnlSndOptions.Location = New System.Drawing.Point(-80, 424)
        Me.pnlSndOptions.Name = "pnlSndOptions"
        Me.pnlSndOptions.Size = New System.Drawing.Size(416, 392)
        Me.pnlSndOptions.TabIndex = 9
        Me.pnlSndOptions.Tag = "ircgui_soundoptions"
        '
        'pnlctcpsndsctl
        '
        Me.pnlctcpsndsctl.Controls.Add(Me.cmdCTCPBrowse)
        Me.pnlctcpsndsctl.Controls.Add(Me.txtCTCPSNDPATH)
        Me.pnlctcpsndsctl.Controls.Add(Me.lblCTCPSoundPath)
        Me.pnlctcpsndsctl.Enabled = False
        Me.pnlctcpsndsctl.Location = New System.Drawing.Point(16, 320)
        Me.pnlctcpsndsctl.Name = "pnlctcpsndsctl"
        Me.pnlctcpsndsctl.Size = New System.Drawing.Size(400, 64)
        Me.pnlctcpsndsctl.TabIndex = 8
        '
        'cmdCTCPBrowse
        '
        Me.cmdCTCPBrowse.Location = New System.Drawing.Point(280, 24)
        Me.cmdCTCPBrowse.Name = "cmdCTCPBrowse"
        Me.cmdCTCPBrowse.Size = New System.Drawing.Size(88, 20)
        Me.cmdCTCPBrowse.TabIndex = 7
        Me.cmdCTCPBrowse.Text = "Обзор"
        '
        'txtCTCPSNDPATH
        '
        Me.txtCTCPSNDPATH.Location = New System.Drawing.Point(8, 24)
        Me.txtCTCPSNDPATH.Name = "txtCTCPSNDPATH"
        Me.txtCTCPSNDPATH.Size = New System.Drawing.Size(264, 20)
        Me.txtCTCPSNDPATH.TabIndex = 6
        Me.txtCTCPSNDPATH.Text = ""
        '
        'lblCTCPSoundPath
        '
        Me.lblCTCPSoundPath.AutoSize = True
        Me.lblCTCPSoundPath.Location = New System.Drawing.Point(8, 8)
        Me.lblCTCPSoundPath.Name = "lblCTCPSoundPath"
        Me.lblCTCPSoundPath.Size = New System.Drawing.Size(271, 16)
        Me.lblCTCPSoundPath.TabIndex = 5
        Me.lblCTCPSoundPath.Text = "Путь к папке с файлами звуков для CTCP SOUND"
        '
        'pnlSndsCtl
        '
        Me.pnlSndsCtl.Controls.Add(Me.cmdPlay)
        Me.pnlSndsCtl.Controls.Add(Me.lblSndEvName)
        Me.pnlSndsCtl.Controls.Add(Me.cmbSounds)
        Me.pnlSndsCtl.Controls.Add(Me.Button3)
        Me.pnlSndsCtl.Controls.Add(Me.txtSndsPath)
        Me.pnlSndsCtl.Controls.Add(Me.lblsndsPath)
        Me.pnlSndsCtl.Controls.Add(Me.cmbSndEvents)
        Me.pnlSndsCtl.Location = New System.Drawing.Point(16, 32)
        Me.pnlSndsCtl.Name = "pnlSndsCtl"
        Me.pnlSndsCtl.Size = New System.Drawing.Size(400, 256)
        Me.pnlSndsCtl.TabIndex = 7
        '
        'cmdPlay
        '
        Me.cmdPlay.Location = New System.Drawing.Point(232, 104)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(88, 21)
        Me.cmdPlay.TabIndex = 21
        Me.cmdPlay.Text = "Тест"
        '
        'lblSndEvName
        '
        Me.lblSndEvName.AutoSize = True
        Me.lblSndEvName.Location = New System.Drawing.Point(8, 56)
        Me.lblSndEvName.Name = "lblSndEvName"
        Me.lblSndEvName.Size = New System.Drawing.Size(51, 16)
        Me.lblSndEvName.TabIndex = 20
        Me.lblSndEvName.Text = "Событие"
        '
        'cmbSounds
        '
        Me.cmbSounds.ItemHeight = 13
        Me.cmbSounds.Items.AddRange(New Object() {"<нет>"})
        Me.cmbSounds.Location = New System.Drawing.Point(8, 104)
        Me.cmbSounds.Name = "cmbSounds"
        Me.cmbSounds.Size = New System.Drawing.Size(216, 21)
        Me.cmbSounds.TabIndex = 19
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(280, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 20)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Обзор"
        '
        'txtSndsPath
        '
        Me.txtSndsPath.Location = New System.Drawing.Point(8, 24)
        Me.txtSndsPath.Name = "txtSndsPath"
        Me.txtSndsPath.Size = New System.Drawing.Size(264, 20)
        Me.txtSndsPath.TabIndex = 17
        Me.txtSndsPath.Text = ""
        '
        'lblsndsPath
        '
        Me.lblsndsPath.AutoSize = True
        Me.lblsndsPath.Location = New System.Drawing.Point(8, 8)
        Me.lblsndsPath.Name = "lblsndsPath"
        Me.lblsndsPath.Size = New System.Drawing.Size(271, 16)
        Me.lblsndsPath.TabIndex = 16
        Me.lblsndsPath.Text = "Путь к папке с файлами звуков для CTCP SOUND"
        '
        'cmbSndEvents
        '
        Me.cmbSndEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSndEvents.ItemHeight = 13
        Me.cmbSndEvents.Items.AddRange(New Object() {"[1] Вход на канал", "[2] Выход из IRC", "[3] Изменение флага", "[4] Изменение темы", "[5] Изменение ника", "[6] Установка бана (общ)", "[7] Выход с канала", "[8] Кик (общ)", "[9] Сообщение"})
        Me.cmbSndEvents.Location = New System.Drawing.Point(8, 72)
        Me.cmbSndEvents.Name = "cmbSndEvents"
        Me.cmbSndEvents.Size = New System.Drawing.Size(216, 21)
        Me.cmbSndEvents.TabIndex = 15
        '
        'lblSndfilename
        '
        Me.lblSndfilename.AutoSize = True
        Me.lblSndfilename.Location = New System.Drawing.Point(24, 88)
        Me.lblSndfilename.Name = "lblSndfilename"
        Me.lblSndfilename.Size = New System.Drawing.Size(0, 16)
        Me.lblSndfilename.TabIndex = 6
        '
        'chkUseCTCPSOUND
        '
        Me.chkUseCTCPSOUND.Location = New System.Drawing.Point(8, 296)
        Me.chkUseCTCPSOUND.Name = "chkUseCTCPSOUND"
        Me.chkUseCTCPSOUND.Size = New System.Drawing.Size(344, 24)
        Me.chkUseCTCPSOUND.TabIndex = 1
        Me.chkUseCTCPSOUND.Text = "Выполнять запросы CTCP SOUND"
        '
        'chkEnableSnds
        '
        Me.chkEnableSnds.Location = New System.Drawing.Point(8, 8)
        Me.chkEnableSnds.Name = "chkEnableSnds"
        Me.chkEnableSnds.Size = New System.Drawing.Size(344, 24)
        Me.chkEnableSnds.TabIndex = 0
        Me.chkEnableSnds.Text = "Использовать звуковые события"
        '
        'tlbIRCToolBar
        '
        Me.tlbIRCToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbIRCToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tlbSep, Me.cmdTlbConnect, Me.cmdtlbSep, Me.cmdtlbModeSelector, Me.cmdylbSep2, Me.cmdtlbShowCHLsList})
        Me.tlbIRCToolBar.Dock = System.Windows.Forms.DockStyle.None
        Me.tlbIRCToolBar.DropDownArrows = True
        Me.tlbIRCToolBar.ImageList = Me.ilsLists
        Me.tlbIRCToolBar.Location = New System.Drawing.Point(576, -8)
        Me.tlbIRCToolBar.Name = "tlbIRCToolBar"
        Me.tlbIRCToolBar.ShowToolTips = True
        Me.tlbIRCToolBar.Size = New System.Drawing.Size(328, 28)
        Me.tlbIRCToolBar.TabIndex = 10
        Me.tlbIRCToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'tlbSep
        '
        Me.tlbSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'cmdTlbConnect
        '
        Me.cmdTlbConnect.ImageIndex = 12
        Me.cmdTlbConnect.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.cmdTlbConnect.Tag = "irc_connecttlb"
        Me.cmdTlbConnect.ToolTipText = "Подключение"
        '
        'cmdtlbSep
        '
        Me.cmdtlbSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'cmdtlbModeSelector
        '
        Me.cmdtlbModeSelector.ImageIndex = 14
        Me.cmdtlbModeSelector.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.cmdtlbModeSelector.Text = "Активен"
        '
        'cmdylbSep2
        '
        Me.cmdylbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'cmdtlbShowCHLsList
        '
        Me.cmdtlbShowCHLsList.ImageIndex = 19
        Me.cmdtlbShowCHLsList.Tag = "irc_sendtoserver LIST"
        Me.cmdtlbShowCHLsList.ToolTipText = "Открыть список каналов"
        '
        'cmbPerformIRCNetworks
        '
        Me.cmbPerformIRCNetworks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPerformIRCNetworks.Items.AddRange(New Object() {"All Networks"})
        Me.cmbPerformIRCNetworks.Location = New System.Drawing.Point(8, 32)
        Me.cmbPerformIRCNetworks.Name = "cmbPerformIRCNetworks"
        Me.cmbPerformIRCNetworks.Size = New System.Drawing.Size(288, 21)
        Me.cmbPerformIRCNetworks.TabIndex = 3
        '
        'lblIRCNetName
        '
        Me.lblIRCNetName.AutoSize = True
        Me.lblIRCNetName.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblIRCNetName.Location = New System.Drawing.Point(8, 8)
        Me.lblIRCNetName.Name = "lblIRCNetName"
        Me.lblIRCNetName.Size = New System.Drawing.Size(110, 16)
        Me.lblIRCNetName.TabIndex = 4
        Me.lblIRCNetName.Text = "Название IRC Сети:"
        '
        'cmdPerformAddIrcNet
        '
        Me.cmdPerformAddIrcNet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPerformAddIrcNet.Location = New System.Drawing.Point(304, 24)
        Me.cmdPerformAddIrcNet.Name = "cmdPerformAddIrcNet"
        Me.cmdPerformAddIrcNet.Size = New System.Drawing.Size(96, 16)
        Me.cmdPerformAddIrcNet.TabIndex = 5
        Me.cmdPerformAddIrcNet.Text = "Добавить"
        '
        'cmdPerformDelIrcNet
        '
        Me.cmdPerformDelIrcNet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPerformDelIrcNet.Location = New System.Drawing.Point(304, 48)
        Me.cmdPerformDelIrcNet.Name = "cmdPerformDelIrcNet"
        Me.cmdPerformDelIrcNet.Size = New System.Drawing.Size(96, 16)
        Me.cmdPerformDelIrcNet.TabIndex = 6
        Me.cmdPerformDelIrcNet.Text = "Удалить"
        '
        'InterfaceCTLS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(968, 597)
        Me.Controls.Add(Me.pnlNetOptions)
        Me.Controls.Add(Me.pnlUserSettings)
        Me.Controls.Add(Me.tlbIRCToolBar)
        Me.Controls.Add(Me.pnlSndOptions)
        Me.Controls.Add(Me.pnIRCPanel)
        Me.Controls.Add(Me.pnlStrings)
        Me.Controls.Add(Me.pnlModes)
        Me.Controls.Add(Me.pnlPerform)
        Me.Controls.Add(Me.pnlNetOptions2)
        Me.Controls.Add(Me.pnlInterf_Colors)
        Me.Name = "InterfaceCTLS"
        Me.Text = "DZFS.net Garikk Soft! Project!! :-)"
        Me.pnIRCPanel.ResumeLayout(False)
        Me.pnlLists.ResumeLayout(False)
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInterf_Colors.ResumeLayout(False)
        Me.pnlColorButtons.ResumeLayout(False)
        Me.pnlColorBar.ResumeLayout(False)
        Me.pnlNetOptions.ResumeLayout(False)
        Me.grpConnection.ResumeLayout(False)
        Me.fraAddServer.ResumeLayout(False)
        Me.pnlNetOptions2.ResumeLayout(False)
        CType(Me.nudRWait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStrings.ResumeLayout(False)
        Me.pnlUserSettings.ResumeLayout(False)
        Me.pnlPerform.ResumeLayout(False)
        Me.pnlModes.ResumeLayout(False)
        Me.pnlSndOptions.ResumeLayout(False)
        Me.pnlctcpsndsctl.ResumeLayout(False)
        Me.pnlSndsCtl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As InterfaceCTLS
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As InterfaceCTLS
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New InterfaceCTLS
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As InterfaceCTLS)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Dim LastNet As String
    Dim LastServ As String
    Dim ServWrk As Byte
    'Public ChSnds As Collection
    Friend ChSnds As IRC_SNDMGR_SOUNDS
    Dim CurrSndEv As String
    Friend IRC_LMODES As Collection

    Friend Structure _UMode
        Dim _UModePrefix As String ' Имя,HK,ID
        Dim Privcmd As String  ' Название proc привата
        Dim PrivcmdPROC As String ' ВЕСЬ proc привата
        Dim MSett As String ' Параметры режима
        Dim ChNick As String ' Изменить ник на: , если пуcто не меняем
        Dim OnChExec As String ' Выполнить при переключении
        Dim AskModeComm As Boolean
        Dim SetAway As Byte

    End Structure

    Private Sub tlbUsers_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbUsers.ButtonClick
        tlbFriends.Visible = False
        tlbUserHot.Visible = False
        tlbFavoriteCHLs.Visible = False
        Dim CURCHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = CType(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "dcb_getcurchldcc"), UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel)
        CURCHL.lstUsers.Visible = False
        lstFriends.Visible = False
        lstFavoriteCHLs.Visible = False
        Select Case e.Button.Tag
            Case 1
                CURCHL.lstUsers.Visible = True
                tlbUsers.Buttons(0).Pushed = True
                tlbUsers.Buttons(1).Pushed = False
                tlbUsers.Buttons(2).Pushed = False
                cmdList.Text = "Всего: " & CURCHL.lstUsers.Items.Count
                tlbUserHot.Visible = True
                tlbUserHot.SendToBack()
            Case 2
                tlbUsers.Buttons(0).Pushed = False
                tlbUsers.Buttons(1).Pushed = True
                tlbUsers.Buttons(2).Pushed = False
                cmdList.Text = "Друзья"
                lstFriends.Visible = True
                tlbFriends.Visible = True
                tlbFriends.SendToBack()
            Case 3
                lstFavoriteCHLs.Visible = True
                tlbFavoriteCHLs.Visible = True
                tlbUsers.Buttons(0).Pushed = False
                tlbUsers.Buttons(1).Pushed = False
                tlbUsers.Buttons(2).Pushed = True
                cmdList.Text = "Избранное"
                tlbFavoriteCHLs.SendToBack()
        End Select

    End Sub

    Private Sub tlbFavoriteCHLs_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbFavoriteCHLs.ButtonClick
        Select Case e.Button.Tag
            Case 1
                frmAddCHL.DefInstance.Show()
            Case 2
                Dim FCHL As IRC_CHLFavorite = _iGetFavCHL(lstFavoriteCHLs.SelectedNode.Text)
                frmAddCHL.DefInstance.txtCHLName.Text = FCHL.CHLName
                frmAddCHL.DefInstance.chkAutoJoin.Checked = FCHL.AutoJoin
                frmAddCHL.DefInstance.chkUseAlarm.Checked = FCHL.UseAlarm
                frmAddCHL.DefInstance.chkUseSnd.Checked = FCHL.UseSND
                frmAddCHL.DefInstance.txtPassword.Text = FCHL.Password
                frmAddCHL.DefInstance.Show()
            Case 3
                If Windows.Forms.MessageBox.Show("Удалить канал из списка избранных?", "DChat", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Try
                        IRC_CHLFavoritesCollection.Remove(lstFavoriteCHLs.SelectedNode.Text)
                        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_savefavoriteslist")
                        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_loadfavoriteslist")
                    Catch : End Try
                End If
            Case 4
                Try : DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /join " & lstFavoriteCHLs.SelectedNode.Text) : Catch : End Try
        End Select
    End Sub
    Private Function _iGetFavCHL(ByVal CHLNAME As String) As IRC_CHLFavorite
        Return CType(IRC_CHLFavoritesCollection(CHLNAME), IRC_CHLFavorite)
    End Function
    'Private Sub InterfaceCTLS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'End Sub

    Private Sub tlbFriends_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbFriends.ButtonClick
        Select Case e.Button.Tag
            Case 1
                frmAddFriend.DefInstance.Show()
                ' IRC_AddFriend("Garikk !n-RAINBow !n-strawberry !n-lucas !n-stranger !n-a !s-notifyon !s-ecmd-%PID% irc_printincon test")
            Case 2
            Case 3
            Case 4
            Case 5

        End Select
    End Sub

    Private Sub tlbUserHot_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbUserHot.ButtonClick
        Select Case e.Button.Tag
            Case 1
                'менюшка
            Case 2
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_createprivate %selectedusername%")
            Case 3
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_newquickmsg %selectedusername%")
            Case 4
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_whoisreq %selectedusername%")
        End Select
    End Sub

    Public Sub cmbSchemes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSchemes.SelectedIndexChanged
        Dim sn As String = CStr(cmbSchemes.Text)
        Dim Tmp As String
        Dim Tmp2 As Windows.Forms.Control
        For Each Tmp2 In pnlColorButtons.Controls
            CType(Tmp2, Windows.Forms.RadioButton).Checked = False
        Next
        Dim S As Boolean = False
        For Each Tmp In IRC_ColorSchemes
            If Tmp.Split(","c)(0) = sn Then
                DisplayScheme(Tmp)
                S = True
                Exit For
            End If
        Next
        If S = False Then
            DisplayScheme(IRC_Settings.IRCColors.ColorScheme)
        End If
    End Sub
    Private Sub DisplayScheme(ByVal SCheme As String)
        Dim SplitScheme() As String = SCheme.Split(","c)
        cmd1.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(1))))
        cmd1.Tag = CInt(SplitScheme(1))
        cmd2.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(2))))
        cmd2.Tag = CInt(SplitScheme(2))
        cmd3.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(3))))
        cmd3.Tag = CInt(SplitScheme(3))
        cmd4.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(4))))
        cmd4.Tag = CInt(SplitScheme(4))
        cmd5.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(5))))
        cmd5.Tag = CInt(SplitScheme(5))
        cmd6.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(6))))
        cmd6.Tag = CInt(SplitScheme(6))
        cmd7.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(7))))
        cmd7.Tag = CInt(SplitScheme(7))
        cmd8.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(8))))
        cmd8.Tag = CInt(SplitScheme(8))
        cmd9.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(9))))
        cmd9.Tag = CInt(SplitScheme(9))
        cmd10.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(10))))
        cmd10.Tag = CInt(SplitScheme(10))
        cmd11.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(11))))
        cmd11.Tag = CInt(SplitScheme(11))
        cmd12.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(12))))
        cmd12.Tag = CInt(SplitScheme(12))
        cmd13.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(13))))
        cmd13.Tag = CInt(SplitScheme(13))
        cmd14.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(14))))
        cmd14.Tag = CInt(SplitScheme(14))
        cmd15.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(15))))
        cmd15.Tag = CInt(SplitScheme(15))
        cmd16.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(16))))
        cmd16.Tag = CInt(SplitScheme(16))
        cmd17.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(17))))
        cmd17.Tag = CInt(SplitScheme(17))
        cmd18.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(18))))
        cmd18.Tag = CInt(SplitScheme(18))
        cmd19.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(19))))
        cmd19.Tag = CInt(SplitScheme(19))
        cmd20.BackColor = System.Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(SplitScheme(20))))
        cmd20.Tag = CInt(SplitScheme(20))
    End Sub

    Private Sub pnlInterf_Colors_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlInterf_Colors.Paint

    End Sub

    Private Sub InterfaceCTLS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdmIRCImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim [OF] As New Windows.Forms.OpenFileDialog
            [OF].Filter = "servers.ini|servers.ini|All files (*.*)|*.*"
            [OF].ShowDialog()
            If [OF].FileName = "" Then Exit Sub
        Catch
        End Try
    End Sub

    Private Sub cmdIRCNetworks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIRCNetworks.SelectedIndexChanged
        Dim Tmp As IRC_NetSettings
        cmbServers.Items.Clear()
        For Each Tmp In IRC_Servers
            If Tmp.Group = cmdIRCNetworks.Text Then
                cmbServers.Items.Add(Tmp.Description)
                cmbServers.Text = Tmp.Description
                cmbServers_SelectedIndexChanged(Me, New System.EventArgs)
            End If
        Next
    End Sub

    Private Sub cmbServers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServers.SelectedIndexChanged
        Dim Tmp As IRC_NetSettings
        For Each Tmp In IRC_Servers
            If Tmp.Description = cmbServers.Text Then
                Me.lblServAddrShow.Text = Tmp.Server & " " & Tmp.Port
                txtGroup.Text = Tmp.Group
                lblServAddrShow.Text = Tmp.Server
                txtPorts.Text = CStr(Tmp.Port)
                txtDesc.Text = Tmp.Description
                txtPass.Text = Tmp.Password
                Exit Sub
            End If
        Next

    End Sub

    Private Sub pnlNetOptions_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlNetOptions.Paint

    End Sub

    Private Sub cmdCancel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fraAddServer.Visible = False
    End Sub

    Private Sub cmdAddserv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddserv.Click
        fraAddServer.Visible = True
        cmdIRCNetworks.Enabled = False
        cmbServers.Enabled = False
        cmdAddserv.Enabled = False
        cmdDelServ.Enabled = False
        cmdEditServ.Enabled = False
        ServWrk = 1
    End Sub

    Private Sub txtGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroup.TextChanged

    End Sub

    Private Sub txtGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGroup.KeyPress, txtDesc.KeyPress, txtPass.KeyPress, txtPorts.KeyPress, lblServAddrShow.KeyPress
        If e.KeyChar = "|" Then
            e.Handled = True
            MsgBox("Символ ""|"" зарезервирован и неможет использоватся в названиях или адресе", MsgBoxStyle.Critical)
            e = Nothing
        End If
    End Sub

    Private Sub cmdDelServ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelServ.Click
        If MsgBox("Вы действительно хотите удалить сервер из списка?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Dim Tmp As Integer
            For Tmp = 1 To IRC_Servers.Count '- 1
                If CType(IRC_Servers.Item(Tmp), IRC_NetSettings).Description = txtDesc.Text And CType(IRC_Servers.Item(Tmp), IRC_NetSettings).Group = txtGroup.Text Then
                    IRC_Servers.Remove(Tmp)
                    Exit For
                End If
            Next
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_saveservers")
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_loadservers")
            ' TODO СДЕЛАТЬ ЧЕРЕЗ DCSE
            IRC_LoadToSettingTable_servers()

        End If
    End Sub

    Private Sub cmdEditServ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditServ.Click
        ServWrk = 2
        fraAddServer.Enabled = True
        cmdIRCNetworks.Enabled = False
        cmbServers.Enabled = False
        cmdAddserv.Enabled = False
        cmdDelServ.Enabled = False
        cmdEditServ.Enabled = False
    End Sub

    Private Sub cmdQuitColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuitColor.Click
        Dim COLED As New frmIRCColorEditor
        frmIRCColorEditor.DefInstance.txtRTFTxt.Rtf = txtQuitMsg.Rtf
        If frmIRCColorEditor.DefInstance.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtQuitMsg.Rtf = frmIRCColorEditor.DefInstance.txtRTFTxt.Rtf
        End If
    End Sub

    Private Sub cmdQuitSDColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuitSDColor.Click
        Dim COLED As New frmIRCColorEditor
        frmIRCColorEditor.DefInstance.txtRTFTxt.Rtf = txtQuitMsgSD.Rtf
        If frmIRCColorEditor.DefInstance.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtQuitMsgSD.Rtf = frmIRCColorEditor.DefInstance.txtRTFTxt.Rtf
        End If
    End Sub

    Private Sub cmOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmOk.Click
        If ServWrk = 1 Then
            Dim NS As IRC_NetSettings
            For Each NS In IRC_Servers
                If NS.Group = txtGroup.Text And NS.Description = txtDesc.Text Then MsgBox("Сервер с таким названием в этой группе уже присутствует", MsgBoxStyle.Critical) : Exit Sub
            Next
            LastNet = txtGroup.Text
            LastServ = txtDesc.Text
            Dim NServ As New IRC_NetSettings
            NServ.Description = txtDesc.Text
            NServ.Group = txtGroup.Text
            NServ.Server = Me.lblServAddrShow.Text
            NServ.Password = txtPass.Text
            NServ.Port = CStr(txtPorts.Text)
            IRC_Servers.Add(NServ)
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_saveservers")
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_loadservers")
            ' TODO СДЕЛАТЬ ЧЕРЕЗ DCSE
            IRC_LoadToSettingTable_servers()
            Me.cmdIRCNetworks.Text = LastNet
            Me.cmbServers.Text = LastServ
            cmbServers_SelectedIndexChanged(Me, New EventArgs)
            MsgBox("Новый сервер добавлен в список", MsgBoxStyle.Information)
        ElseIf ServWrk = 2 Then
            LastNet = txtGroup.Text
            LastServ = txtDesc.Text
            Dim Tmp As Integer
            For Tmp = 1 To IRC_Servers.Count '- 1
                If CType(IRC_Servers.Item(Tmp), IRC_NetSettings).Description = txtDesc.Text And CType(IRC_Servers.Item(Tmp), IRC_NetSettings).Group = txtGroup.Text Then
                    IRC_Servers.Remove(Tmp)
                    Exit For
                End If
            Next

            Dim NServ As New IRC_NetSettings
            NServ.Description = txtDesc.Text
            NServ.Group = txtGroup.Text
            NServ.Server = Me.lblServAddrShow.Text
            NServ.Password = txtPass.Text
            NServ.Port = CStr(txtPorts.Text)
            IRC_Servers.Add(NServ)
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_saveservers")
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_loadservers")
            ' TODO СДЕЛАТЬ ЧЕРЕЗ DCSE
            IRC_LoadToSettingTable_servers()
            Me.cmdIRCNetworks.Text = LastNet
            Me.cmbServers.Text = LastServ
            cmbServers_SelectedIndexChanged(Me, New EventArgs)
        End If
        fraAddServer.Enabled = False
        cmdIRCNetworks.Enabled = True
        cmbServers.Enabled = True
        cmdAddserv.Enabled = True
        cmdDelServ.Enabled = True
        cmdEditServ.Enabled = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        fraAddServer.Enabled = False
        cmdIRCNetworks.Enabled = True
        cmbServers.Enabled = True
        cmdAddserv.Enabled = True
        cmdDelServ.Enabled = True
        cmdEditServ.Enabled = True
        cmdIRCNetworks_SelectedIndexChanged(Me, New EventArgs)
        cmbServers_SelectedIndexChanged(Me, New EventArgs)
    End Sub

    Private Sub pnlUserSettings_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlUserSettings.Paint

    End Sub

    Private Sub cmd1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.CheckedChanged, cmd2.CheckedChanged, cmd3.CheckedChanged, cmd4.CheckedChanged, cmd5.CheckedChanged, cmd6.CheckedChanged, cmd7.CheckedChanged, cmd8.CheckedChanged, cmd9.CheckedChanged, cmd10.CheckedChanged, _
       cmd11.CheckedChanged, cmd12.CheckedChanged, cmd13.CheckedChanged, cmd14.CheckedChanged, cmd15.CheckedChanged, cmd16.CheckedChanged, cmd17.CheckedChanged, cmd18.CheckedChanged, cmd19.CheckedChanged, cmd20.CheckedChanged

        Dim S As Windows.Forms.RadioButton = CType(sender, Windows.Forms.RadioButton)
        If S.Checked = True Then
            Dim Tmp As Drawing.Color = S.BackColor
            S.BackColor = S.ForeColor
            S.ForeColor = Tmp
            SetColorMarks(CShort(S.Tag))
        Else
            Dim Tmp As Drawing.Color = S.ForeColor
            S.ForeColor = S.BackColor
            S.BackColor = Tmp
        End If
    End Sub
    Private Sub SetColorMarks(ByVal SetClr As Short)
        Dim LBL As Windows.Forms.Label
        For Each LBL In pnlColorBar.Controls
            LBL.Text = ""
            If CShort(LBL.Tag) = SetClr Then
                LBL.Text = "X"
            End If
        Next

    End Sub
    Private Sub lblC1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblC1.Click, lblC2.Click, lblC3.Click, lblC4.Click, lblC5.Click, lblC6.Click, lblC7.Click, lblC8.Click, lblC9.Click, lblC10.Click, lblC11.Click, lblC12.Click, lblC13.Click, lblC15.Click, lblC16.Click
        Dim tmp As Windows.Forms.Control
        For Each tmp In pnlColorButtons.Controls
            If CType(tmp, Windows.Forms.RadioButton).Checked = True Then
                CType(tmp, Windows.Forms.RadioButton).ForeColor = Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(CInt(CType(sender, Windows.Forms.Label).Tag)))
                CType(tmp, Windows.Forms.RadioButton).Tag = CType(sender, Windows.Forms.Label).Tag
                cmbSchemes.Text = "Изменено"
                Dim LBL As Windows.Forms.Label
                For Each LBL In pnlColorBar.Controls
                    LBL.Text = ""
                Next
                CType(sender, Windows.Forms.Label).Text = "X"
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveColorSchame.Click
        Dim ColorScheme As String
        ColorScheme = CStr(InterfaceCTLS.DefInstance.cmbSchemes.Text & "," & CStr(InterfaceCTLS.DefInstance.cmd1.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd2.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd3.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd4.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd5.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd6.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd7.Tag) _
                   & "," & CStr(InterfaceCTLS.DefInstance.cmd8.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd9.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd10.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd11.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd12.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd13.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd14.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd15.Tag) _
        & "," & CStr(InterfaceCTLS.DefInstance.cmd16.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd17.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd18.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd19.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd20.Tag)) ' & "," & CStr(InterfaceCTLS.DefInstance.cmd21.Tag))
        IRC_ColorSchemes.Add(ColorScheme)
        cmbSchemes.Items.Clear()
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_savecolorschemes")
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_clearcolorschemes")
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_loadcolorschemes")
        Dim Tmp As String
        For Each Tmp In IRC_ColorSchemes
            cmbSchemes.Items.Add(Tmp.Split(","c)(0))
        Next
        cmbSchemes_SelectedIndexChanged(Me, New EventArgs)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        IRC_ColorSchemes.Remove(cmbSchemes.Text)
        cmbSchemes.Items.Clear()
        cmbSchemes.Text = "Default"
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_savecolorschemes")
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_clearcolorschemes")
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_loadcolorschemes")
        Dim Tmp As String
        For Each Tmp In IRC_ColorSchemes
            cmbSchemes.Items.Add(Tmp.Split(","c)(0))
        Next
        cmbSchemes_SelectedIndexChanged(Me, New EventArgs)
    End Sub
    Private Sub chkEnableSnds_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableSnds.CheckedChanged
        pnlSndsCtl.Enabled = chkEnableSnds.Checked
    End Sub

    Private Sub chkUseCTCPSOUND_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseCTCPSOUND.CheckedChanged
        pnlctcpsndsctl.Enabled = chkUseCTCPSOUND.Checked
    End Sub

    Private Sub cmbSndEvents_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSndEvents.SelectedIndexChanged
        'Dim Tmp As IRC_Event
        'For Each Tmp In ChSnds
        'If Tmp.EvName = CStr(cmbSndEvents.SelectedItem) Then cmbSounds.Text = Tmp.EvCMD.Split(Space(1).tochararray)(UBound(Tmp.EvCMD.Split) - 1) : CurrSndEv = Tmp.EvPrefix : Exit Sub
        'Next
        Dim Sel As String = cmbSndEvents.Text.Split(Space(1).ToCharArray)(0)
        Select Case Sel
            Case "[1]" ' Join
                cmbSounds.Text = ChSnds.IRC_SND_JOIN
            Case "[2]" ' Quit
                cmbSounds.Text = ChSnds.IRC_SND_QUIT
            Case "[3]" ' mode
                cmbSounds.Text = ChSnds.IRC_SND_MODE
            Case "[4]" ' topic
                cmbSounds.Text = ChSnds.IRC_SND_TOPIC
            Case "[5]" ' nick 
                cmbSounds.Text = ChSnds.IRC_SND_NICK
            Case "[6]" ' modeb
                cmbSounds.Text = ChSnds.IRC_SND_MODE_BAN
            Case "[7]" ' part
                cmbSounds.Text = ChSnds.IRC_SND_PART
            Case "[8]" ' kick
                cmbSounds.Text = ChSnds.IRC_SND_KICK
            Case "[9]" ' qmsg
                cmbSounds.Text = ChSnds.IRC_SND_QMSG
        End Select
    End Sub
    '    IRC_SND_JOIN = 1
    'IRC_SND_PART = 2
    'IRC_SND_QUIT = 3
    'IRC_SND_MODE = 4
    'IRC_SND_TOPIC = 5
    'IRC_SND_NICK = 6
    'IRC_SND_MODE_BAN = 7
    'IRC_SND_KICK = 8
    'IRC_SND_QMSG = 9


    Private Sub txtSndsPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSndsPath.TextChanged
        cmbSounds.Items.Clear()
        Dim Tmp As String
        If txtSndsPath.Text = "" Then Exit Sub
        Dim Tmp2() As String = System.IO.Directory.GetFiles(Me.txtSndsPath.Text, "*.wav")
        For Each Tmp In Tmp2
            cmbSounds.Items.Add(Tmp.Split("\"c)(UBound(Tmp.Split("\"c))))
        Next
    End Sub

    Private Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlay.Click
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_playsound " & cmbSounds.Text)
    End Sub

    Private Sub cmbSounds_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSounds.SelectedIndexChanged
        Dim Sel As String = cmbSndEvents.Text.Split(Space(1).ToCharArray)(0)
        Select Case Sel
            Case "[1]" ' Join
                ChSnds.IRC_SND_JOIN = cmbSounds.Text
            Case "[2]" ' Quit
                ChSnds.IRC_SND_QUIT = cmbSounds.Text
            Case "[3]" ' mode
                ChSnds.IRC_SND_MODE = cmbSounds.Text
            Case "[4]" ' topic
                ChSnds.IRC_SND_TOPIC = cmbSounds.Text
            Case "[5]" ' nick 
                ChSnds.IRC_SND_NICK = cmbSounds.Text
            Case "[6]" ' modeb
                ChSnds.IRC_SND_MODE_BAN = cmbSounds.Text
            Case "[7]" ' part
                ChSnds.IRC_SND_PART = cmbSounds.Text
            Case "[8]" ' kick
                ChSnds.IRC_SND_KICK = cmbSounds.Text
            Case "[9]" ' qmsg
                ChSnds.IRC_SND_QMSG = cmbSounds.Text
        End Select
    End Sub

    Private Sub pnlLists_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles pnlLists.ControlAdded
        Dim TB As Windows.Forms.ToolBarButton
        For Each TB In Me.tlbUsers.Buttons
            If TB.Pushed = True Then
                tlbUsers_ButtonClick(Me, New Windows.Forms.ToolBarButtonClickEventArgs(TB))
                Exit For
            End If
        Next
    End Sub

    Friend Sub ChangeConnectButtonIcon(ByVal Connected As Boolean)
        If Connected = True Then
            cmdTlbConnect.ImageIndex = 13
        Else
            cmdTlbConnect.ImageIndex = 12
        End If
    End Sub

    Friend Function GetConnectButtonStatus() As Boolean
        If cmdTlbConnect.ImageIndex = 13 Then Return True
        Return False
    End Function
    Private Sub tlbIRCToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbIRCToolBar.ButtonClick
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% " & CStr(e.Button.Tag))
    End Sub

    Private Sub cmbModes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModes.SelectedIndexChanged
        Static LastMode As String
        If LastMode <> "" Then SavePreviousModeSettings(LastMode)
        LastMode = cmbModes.Text
        Dim IM As String = GetUmodeByNam(cmbModes.Text)
        If IM = "" Then MsgBox("Ошибка обработки режимов!! (NFSM)", MsgBoxStyle.Critical) : Exit Sub
        Dim aIM As _UMode = CType(Me.IRC_LMODES(IM.Trim.Split(":"c)(1)), _UMode)
        If aIM.Privcmd <> "" Then
            Me.txtModePrivAns.Tag = aIM.Privcmd
            Me.txtModePrivAns.Text = aIM.PrivcmdPROC
        End If
        txtOnSetModeExec.Text = aIM.OnChExec
        chkSetAway.CheckState = CType(aIM.SetAway, Windows.Forms.CheckState)
        txtPrefix.Text = aIM.ChNick
        Me.txtOnSetModeExec.Text = aIM.OnChExec
        Me.chkSndsOff.Checked = Not (aIM.MSett.Split()(0) = "1")
        Me.chkMsgPopup.Checked = Not (aIM.MSett.Split()(1) = "1")
    End Sub
    Private Sub SavePreviousModeSettings(ByVal lastmode As String)
        Dim aIM As _UMode = CType(IRC_LMODES(GetUmodeByNam(lastmode).Trim.Split(":"c)(1)), _UMode)
        aIM.Privcmd = Me.txtModePrivAns.Tag.ToString
        aIM.PrivcmdPROC = Me.txtModePrivAns.Text
        aIM.OnChExec = txtOnSetModeExec.Text
        aIM.SetAway = CByte(chkSetAway.CheckState)
        aIM.ChNick = txtPrefix.Text
        If Me.chkSndsOff.Checked = False Then aIM.MSett = "1" Else aIM.MSett = "0"
        If Me.chkMsgPopup.Checked = False Then aIM.MSett = aIM.MSett & " 1" Else aIM.MSett = aIM.MSett & " 0"
        IRC_LMODES.Remove(GetUmodeByNam(lastmode).Trim.Split(":"c)(1))
        IRC_LMODES.Add(aIM, GetUmodeByNam(lastmode).Trim.Split(":"c)(1))
    End Sub
    Private Function GetUmodeByNam(ByVal N As String) As String
        Dim tmp As String
        For Each tmp In IRC_UserModes
            tmp = tmp.Trim
            If tmp.Split(":"c)(0) = N Then Return tmp
        Next
        Return Nothing
    End Function

#Region " PERFORM operations "
    Private Sub cmdPerformAddIrcNet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPerformAddIrcNet.Click
        Dim NNet As String
        NNet = InputBox("Введите название сети")
        If NNet = "" Then Exit Sub
        If cmbPerformIRCNetworks.Items.Contains(NNet) Then MsgBox("Такой пункт уже присутствует", MsgBoxStyle.Critical) : Exit Sub
        cmbPerformIRCNetworks.Items.Add(NNet)

    End Sub

    Private Sub cmdPerformDelIrcNet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPerformDelIrcNet.Click
        If cmbPerformIRCNetworks.Text = "All networks" Then
            MsgBox("Этот пункт удалить нельзя", MsgBoxStyle.Critical)
            Exit Sub
        End If
        cmbPerformIRCNetworks.Items.Remove(cmbPerformIRCNetworks.Text)
    End Sub

    Private Sub cmbPerformIRCNetworks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPerformIRCNetworks.SelectedIndexChanged
        'Загрузка комманд из файла
        Dim RootPath As String = CStr(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "dcb_getrootpath"))
        Dim PFile As String = RootPath & "\scripts\irc_perform_" & cmbPerformIRCNetworks.Text.Replace(" ", "_") & ".dcscript"
        If IO.File.Exists(PFile) = False Then
            Me.txtPerform.Text = "/# Insert your commands here..."
        Else
            Try
                Me.txtPerform.LoadFile(PFile, Windows.Forms.RichTextBoxStreamType.PlainText)
            Catch 
            End Try
        End If
    End Sub
#End Region
End Class
