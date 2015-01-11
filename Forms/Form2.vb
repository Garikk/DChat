Public Class frmOptions
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
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ImgLstOptions As System.Windows.Forms.ImageList
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lblUsers As System.Windows.Forms.Label
    Friend WithEvents picUsers As System.Windows.Forms.PictureBox
    Friend WithEvents pnlUsers As System.Windows.Forms.Panel
    Friend WithEvents picNet As System.Windows.Forms.PictureBox
    Friend WithEvents picSounds As System.Windows.Forms.PictureBox
    Friend WithEvents picInterface As System.Windows.Forms.PictureBox
    Friend WithEvents lblInterface As System.Windows.Forms.Label
    Friend WithEvents lblSounds As System.Windows.Forms.Label
    Friend WithEvents lblNet As System.Windows.Forms.Label
    Friend WithEvents pnlNet As System.Windows.Forms.Panel
    Friend WithEvents pnlInterface As System.Windows.Forms.Panel
    Friend WithEvents pnlSounds As System.Windows.Forms.Panel
    Friend WithEvents tbcNet As System.Windows.Forms.TabControl
    Friend WithEvents tbcSounds As System.Windows.Forms.TabControl
    Friend WithEvents tbcUsers As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lanCmdDefault As System.Windows.Forms.Button
    Friend WithEvents sndCmdDefault As System.Windows.Forms.Button
    Friend WithEvents colCmdDefault As System.Windows.Forms.Button
    Friend WithEvents cmdAllDefault As System.Windows.Forms.Button
    Friend WithEvents fntDChat As System.Windows.Forms.FontDialog
    Friend WithEvents clrDChat As System.Windows.Forms.ColorDialog
    Friend WithEvents cmdDefShowSymb As System.Windows.Forms.Button
    Friend WithEvents cmdDefPop As System.Windows.Forms.Button
    Friend WithEvents cmdDefInterf As System.Windows.Forms.Button
    Friend WithEvents tbcInterface As System.Windows.Forms.TabControl
    Friend WithEvents intcoltabColors As System.Windows.Forms.TabPage
    Friend WithEvents colfraColors As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents colCmd4 As System.Windows.Forms.Button
    Friend WithEvents colCmd11 As System.Windows.Forms.Button
    Friend WithEvents colCmd6 As System.Windows.Forms.Button
    Friend WithEvents colCmd9 As System.Windows.Forms.Button
    Friend WithEvents colCmd7 As System.Windows.Forms.Button
    Friend WithEvents colCmd1 As System.Windows.Forms.Button
    Friend WithEvents colCmd10 As System.Windows.Forms.Button
    Friend WithEvents colCmd8 As System.Windows.Forms.Button
    Friend WithEvents colCmd5 As System.Windows.Forms.Button
    Friend WithEvents colCmd15 As System.Windows.Forms.Button
    Friend WithEvents colCmd12 As System.Windows.Forms.Button
    Friend WithEvents colCmd16 As System.Windows.Forms.Button
    Friend WithEvents colCmd2 As System.Windows.Forms.Button
    Friend WithEvents colCmd13 As System.Windows.Forms.Button
    Friend WithEvents colCmd14 As System.Windows.Forms.Button
    Friend WithEvents colCmd3 As System.Windows.Forms.Button
    Friend WithEvents CheckBox15 As System.Windows.Forms.CheckBox
    Friend WithEvents pupOptAwayOff As System.Windows.Forms.RadioButton
    Friend WithEvents pupOptAwayOn As System.Windows.Forms.RadioButton
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents pupOptGameOff As System.Windows.Forms.RadioButton
    Friend WithEvents pupOptGameOn As System.Windows.Forms.RadioButton
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents pupOptBusyOff As System.Windows.Forms.RadioButton
    Friend WithEvents pupOptBusyOn As System.Windows.Forms.RadioButton
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents pupChkEnterToPrivate As System.Windows.Forms.CheckBox
    Friend WithEvents pupChkNewLine As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents smbTxtRightUsers As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents smbTxtRightTime As System.Windows.Forms.TextBox
    Friend WithEvents smbTxtLeftUsers As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents smbTxtLeftTime As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents smbChkSystemMessage As System.Windows.Forms.CheckBox
    Friend WithEvents fraInterfTabs As System.Windows.Forms.GroupBox
    Friend WithEvents intOptFlatButtons As System.Windows.Forms.RadioButton
    Friend WithEvents intOptButtons As System.Windows.Forms.RadioButton
    Friend WithEvents intOptTab As System.Windows.Forms.RadioButton
    Friend WithEvents fraInterfShow As System.Windows.Forms.GroupBox
    Friend WithEvents intChkTopic As System.Windows.Forms.CheckBox
    Friend WithEvents intChkName As System.Windows.Forms.CheckBox
    Friend WithEvents fraInterfFont As System.Windows.Forms.GroupBox
    Friend WithEvents intCmdFont As System.Windows.Forms.Button
    Friend WithEvents fraPopMsg As System.Windows.Forms.GroupBox
    Friend WithEvents fraPopMain As System.Windows.Forms.GroupBox
    Friend WithEvents fraSymbOther As System.Windows.Forms.GroupBox
    Friend WithEvents fraSymbShowSymb As System.Windows.Forms.GroupBox
    Friend WithEvents fraSymbSymb As System.Windows.Forms.GroupBox
    Friend WithEvents fraInterfOther As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents lanTxtBroadcastAddress As System.Windows.Forms.TextBox
    Friend WithEvents lanOptBroadcast As System.Windows.Forms.RadioButton
    Friend WithEvents lanTxtMulticastAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lanOptMulticast As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lanUDTTL As System.Windows.Forms.DomainUpDown
    Friend WithEvents lblLANTTL As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSeparatorLAN As System.Windows.Forms.Label
    Friend WithEvents lanTxtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lanUDOnLine As System.Windows.Forms.NumericUpDown
    Friend WithEvents lanUDRefreshList As System.Windows.Forms.NumericUpDown
    Friend WithEvents lanTxtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents sndChkAway As System.Windows.Forms.CheckBox
    Friend WithEvents sndChkBusy As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents sndTxtLeaveChannel As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents sndTxtJoinChannel As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents sndTxtAddLink As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents sndTxtReceiveScreenShot As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtRemoteExec As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtSignal As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtStrMe As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtChangeTopic As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtMultipleMessage As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtChangeName As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents sndTxtSendMessage As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtReceiveMessage As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtLineToChat As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtEndToTalk As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtExitToLan As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtEnterToLan As System.Windows.Forms.TextBox
    Friend WithEvents sndTxtBeginToTalk As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents sndChkOnSound As System.Windows.Forms.CheckBox
    Friend WithEvents tabSounds As System.Windows.Forms.TabPage
    Friend WithEvents lblBorder1 As System.Windows.Forms.Label
    Friend WithEvents fraUserSettings As System.Windows.Forms.GroupBox
    Friend WithEvents optSexNone As System.Windows.Forms.RadioButton
    Friend WithEvents optSexFemale As System.Windows.Forms.RadioButton
    Friend WithEvents optSexMale As System.Windows.Forms.RadioButton
    Friend WithEvents lblSex As System.Windows.Forms.Label
    Friend WithEvents lblUsrComments As System.Windows.Forms.Label
    Friend WithEvents usrTxtComment As System.Windows.Forms.TextBox
    Friend WithEvents lblBorder2 As System.Windows.Forms.Label
    Friend WithEvents lblBorder3 As System.Windows.Forms.Label
    Friend WithEvents lblBorder4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlPopAway As System.Windows.Forms.Panel
    Friend WithEvents pnlpopPlay As System.Windows.Forms.Panel
    Friend WithEvents pnlPopWork As System.Windows.Forms.Panel
    Friend WithEvents lblBorder5 As System.Windows.Forms.Label
    Friend WithEvents cmdSnd17 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd16 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd15 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd14 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd13 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd11 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd10 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd12 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd8 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd7 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd9 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd5 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd4 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd6 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd2 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd1 As System.Windows.Forms.Button
    Friend WithEvents cmdSnd3 As System.Windows.Forms.Button
    Friend WithEvents opfDChat As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents fraLogs As System.Windows.Forms.GroupBox
    Friend WithEvents chkUseLogMsg As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseLogMain As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseLogPriv As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseLogCHL As System.Windows.Forms.CheckBox
    Friend WithEvents tabLanguage As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLang As System.Windows.Forms.ListBox
    Friend WithEvents chkUseRTF As System.Windows.Forms.CheckBox
    Friend WithEvents tabInterface As System.Windows.Forms.TabPage
    Friend WithEvents tabViewSymbols As System.Windows.Forms.TabPage
    Friend WithEvents tabPopupOptions As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOptions))
        Me.ImgLstOptions = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdAllDefault = New System.Windows.Forms.Button
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.pnlInterface = New System.Windows.Forms.Panel
        Me.picInterface = New System.Windows.Forms.PictureBox
        Me.lblInterface = New System.Windows.Forms.Label
        Me.pnlSounds = New System.Windows.Forms.Panel
        Me.picSounds = New System.Windows.Forms.PictureBox
        Me.lblSounds = New System.Windows.Forms.Label
        Me.pnlNet = New System.Windows.Forms.Panel
        Me.picNet = New System.Windows.Forms.PictureBox
        Me.lblNet = New System.Windows.Forms.Label
        Me.pnlUsers = New System.Windows.Forms.Panel
        Me.lblUsers = New System.Windows.Forms.Label
        Me.picUsers = New System.Windows.Forms.PictureBox
        Me.tbcNet = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.lblBorder5 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.lanTxtBroadcastAddress = New System.Windows.Forms.TextBox
        Me.lanOptBroadcast = New System.Windows.Forms.RadioButton
        Me.lanTxtMulticastAddress = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lanOptMulticast = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.lanUDTTL = New System.Windows.Forms.DomainUpDown
        Me.lblLANTTL = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblSeparatorLAN = New System.Windows.Forms.Label
        Me.lanTxtIP = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.lanUDOnLine = New System.Windows.Forms.NumericUpDown
        Me.lanUDRefreshList = New System.Windows.Forms.NumericUpDown
        Me.lanTxtPort = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lanCmdDefault = New System.Windows.Forms.Button
        Me.tbcSounds = New System.Windows.Forms.TabControl
        Me.tabSounds = New System.Windows.Forms.TabPage
        Me.lblBorder1 = New System.Windows.Forms.Label
        Me.sndChkOnSound = New System.Windows.Forms.CheckBox
        Me.sndChkAway = New System.Windows.Forms.CheckBox
        Me.sndChkBusy = New System.Windows.Forms.CheckBox
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdSnd17 = New System.Windows.Forms.Button
        Me.sndTxtLeaveChannel = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.cmdSnd16 = New System.Windows.Forms.Button
        Me.sndTxtJoinChannel = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.cmdSnd15 = New System.Windows.Forms.Button
        Me.sndTxtAddLink = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.cmdSnd14 = New System.Windows.Forms.Button
        Me.cmdSnd13 = New System.Windows.Forms.Button
        Me.cmdSnd11 = New System.Windows.Forms.Button
        Me.cmdSnd10 = New System.Windows.Forms.Button
        Me.cmdSnd12 = New System.Windows.Forms.Button
        Me.cmdSnd8 = New System.Windows.Forms.Button
        Me.cmdSnd7 = New System.Windows.Forms.Button
        Me.cmdSnd9 = New System.Windows.Forms.Button
        Me.cmdSnd5 = New System.Windows.Forms.Button
        Me.cmdSnd4 = New System.Windows.Forms.Button
        Me.cmdSnd6 = New System.Windows.Forms.Button
        Me.cmdSnd2 = New System.Windows.Forms.Button
        Me.cmdSnd1 = New System.Windows.Forms.Button
        Me.sndTxtReceiveScreenShot = New System.Windows.Forms.TextBox
        Me.sndTxtRemoteExec = New System.Windows.Forms.TextBox
        Me.sndTxtSignal = New System.Windows.Forms.TextBox
        Me.sndTxtStrMe = New System.Windows.Forms.TextBox
        Me.sndTxtChangeTopic = New System.Windows.Forms.TextBox
        Me.sndTxtMultipleMessage = New System.Windows.Forms.TextBox
        Me.sndTxtChangeName = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.sndTxtSendMessage = New System.Windows.Forms.TextBox
        Me.sndTxtReceiveMessage = New System.Windows.Forms.TextBox
        Me.sndTxtLineToChat = New System.Windows.Forms.TextBox
        Me.sndTxtEndToTalk = New System.Windows.Forms.TextBox
        Me.sndTxtExitToLan = New System.Windows.Forms.TextBox
        Me.sndTxtEnterToLan = New System.Windows.Forms.TextBox
        Me.cmdSnd3 = New System.Windows.Forms.Button
        Me.sndTxtBeginToTalk = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.sndCmdDefault = New System.Windows.Forms.Button
        Me.tbcInterface = New System.Windows.Forms.TabControl
        Me.intcoltabColors = New System.Windows.Forms.TabPage
        Me.lblBorder2 = New System.Windows.Forms.Label
        Me.colfraColors = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.colCmd4 = New System.Windows.Forms.Button
        Me.colCmd11 = New System.Windows.Forms.Button
        Me.colCmd6 = New System.Windows.Forms.Button
        Me.colCmd9 = New System.Windows.Forms.Button
        Me.colCmd7 = New System.Windows.Forms.Button
        Me.colCmd1 = New System.Windows.Forms.Button
        Me.colCmd10 = New System.Windows.Forms.Button
        Me.colCmd8 = New System.Windows.Forms.Button
        Me.colCmd5 = New System.Windows.Forms.Button
        Me.colCmd15 = New System.Windows.Forms.Button
        Me.colCmd12 = New System.Windows.Forms.Button
        Me.colCmd16 = New System.Windows.Forms.Button
        Me.colCmd2 = New System.Windows.Forms.Button
        Me.colCmd13 = New System.Windows.Forms.Button
        Me.colCmd14 = New System.Windows.Forms.Button
        Me.colCmd3 = New System.Windows.Forms.Button
        Me.colCmdDefault = New System.Windows.Forms.Button
        Me.tabInterface = New System.Windows.Forms.TabPage
        Me.lblBorder3 = New System.Windows.Forms.Label
        Me.fraInterfOther = New System.Windows.Forms.GroupBox
        Me.fraInterfTabs = New System.Windows.Forms.GroupBox
        Me.intOptFlatButtons = New System.Windows.Forms.RadioButton
        Me.intOptButtons = New System.Windows.Forms.RadioButton
        Me.intOptTab = New System.Windows.Forms.RadioButton
        Me.fraInterfShow = New System.Windows.Forms.GroupBox
        Me.intChkTopic = New System.Windows.Forms.CheckBox
        Me.intChkName = New System.Windows.Forms.CheckBox
        Me.fraInterfFont = New System.Windows.Forms.GroupBox
        Me.intCmdFont = New System.Windows.Forms.Button
        Me.cmdDefInterf = New System.Windows.Forms.Button
        Me.tabViewSymbols = New System.Windows.Forms.TabPage
        Me.lblBorder4 = New System.Windows.Forms.Label
        Me.fraSymbOther = New System.Windows.Forms.GroupBox
        Me.chkUseRTF = New System.Windows.Forms.CheckBox
        Me.fraSymbShowSymb = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.smbTxtRightUsers = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.smbTxtRightTime = New System.Windows.Forms.TextBox
        Me.smbTxtLeftUsers = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.smbTxtLeftTime = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.fraSymbSymb = New System.Windows.Forms.GroupBox
        Me.smbChkSystemMessage = New System.Windows.Forms.CheckBox
        Me.cmdDefShowSymb = New System.Windows.Forms.Button
        Me.tabPopupOptions = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.CheckBox15 = New System.Windows.Forms.CheckBox
        Me.fraPopMsg = New System.Windows.Forms.GroupBox
        Me.pnlPopAway = New System.Windows.Forms.Panel
        Me.pupOptAwayOff = New System.Windows.Forms.RadioButton
        Me.pupOptAwayOn = New System.Windows.Forms.RadioButton
        Me.Label31 = New System.Windows.Forms.Label
        Me.pnlpopPlay = New System.Windows.Forms.Panel
        Me.pupOptGameOff = New System.Windows.Forms.RadioButton
        Me.pupOptGameOn = New System.Windows.Forms.RadioButton
        Me.Label26 = New System.Windows.Forms.Label
        Me.pnlPopWork = New System.Windows.Forms.Panel
        Me.pupOptBusyOff = New System.Windows.Forms.RadioButton
        Me.pupOptBusyOn = New System.Windows.Forms.RadioButton
        Me.Label29 = New System.Windows.Forms.Label
        Me.fraPopMain = New System.Windows.Forms.GroupBox
        Me.pupChkEnterToPrivate = New System.Windows.Forms.CheckBox
        Me.pupChkNewLine = New System.Windows.Forms.CheckBox
        Me.cmdDefPop = New System.Windows.Forms.Button
        Me.tabLanguage = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstLang = New System.Windows.Forms.ListBox
        Me.tbcUsers = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.fraUserSettings = New System.Windows.Forms.GroupBox
        Me.optSexNone = New System.Windows.Forms.RadioButton
        Me.optSexFemale = New System.Windows.Forms.RadioButton
        Me.optSexMale = New System.Windows.Forms.RadioButton
        Me.lblSex = New System.Windows.Forms.Label
        Me.lblUsrComments = New System.Windows.Forms.Label
        Me.usrTxtComment = New System.Windows.Forms.TextBox
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.fraLogs = New System.Windows.Forms.GroupBox
        Me.chkUseLogCHL = New System.Windows.Forms.CheckBox
        Me.chkUseLogPriv = New System.Windows.Forms.CheckBox
        Me.chkUseLogMain = New System.Windows.Forms.CheckBox
        Me.chkUseLogMsg = New System.Windows.Forms.CheckBox
        Me.fntDChat = New System.Windows.Forms.FontDialog
        Me.clrDChat = New System.Windows.Forms.ColorDialog
        Me.opfDChat = New System.Windows.Forms.OpenFileDialog
        Me.Panel6.SuspendLayout()
        Me.pnlInterface.SuspendLayout()
        Me.pnlSounds.SuspendLayout()
        Me.pnlNet.SuspendLayout()
        Me.pnlUsers.SuspendLayout()
        Me.tbcNet.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.lanUDOnLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lanUDRefreshList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcSounds.SuspendLayout()
        Me.tabSounds.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tbcInterface.SuspendLayout()
        Me.intcoltabColors.SuspendLayout()
        Me.colfraColors.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tabInterface.SuspendLayout()
        Me.fraInterfTabs.SuspendLayout()
        Me.fraInterfShow.SuspendLayout()
        Me.fraInterfFont.SuspendLayout()
        Me.tabViewSymbols.SuspendLayout()
        Me.fraSymbOther.SuspendLayout()
        Me.fraSymbShowSymb.SuspendLayout()
        Me.fraSymbSymb.SuspendLayout()
        Me.tabPopupOptions.SuspendLayout()
        Me.fraPopMsg.SuspendLayout()
        Me.pnlPopAway.SuspendLayout()
        Me.pnlpopPlay.SuspendLayout()
        Me.pnlPopWork.SuspendLayout()
        Me.fraPopMain.SuspendLayout()
        Me.tabLanguage.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbcUsers.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.fraUserSettings.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.fraLogs.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImgLstOptions
        '
        Me.ImgLstOptions.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImgLstOptions.ImageStream = CType(resources.GetObject("ImgLstOptions.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstOptions.TransparentColor = System.Drawing.Color.Transparent
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Location = New System.Drawing.Point(376, 312)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(80, 24)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Сохранить"
        '
        'cmdCancel
        '
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Location = New System.Drawing.Point(464, 312)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(88, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Отмена"
        '
        'cmdAllDefault
        '
        Me.cmdAllDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAllDefault.Location = New System.Drawing.Point(104, 312)
        Me.cmdAllDefault.Name = "cmdAllDefault"
        Me.cmdAllDefault.Size = New System.Drawing.Size(184, 24)
        Me.cmdAllDefault.TabIndex = 3
        Me.cmdAllDefault.Text = "Все настройки по умолчанию"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.pnlInterface)
        Me.Panel6.Controls.Add(Me.pnlSounds)
        Me.Panel6.Controls.Add(Me.pnlNet)
        Me.Panel6.Controls.Add(Me.pnlUsers)
        Me.Panel6.Location = New System.Drawing.Point(8, 8)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(88, 328)
        Me.Panel6.TabIndex = 4
        '
        'pnlInterface
        '
        Me.pnlInterface.Controls.Add(Me.picInterface)
        Me.pnlInterface.Controls.Add(Me.lblInterface)
        Me.pnlInterface.Location = New System.Drawing.Point(8, 232)
        Me.pnlInterface.Name = "pnlInterface"
        Me.pnlInterface.Size = New System.Drawing.Size(72, 64)
        Me.pnlInterface.TabIndex = 18
        '
        'picInterface
        '
        Me.picInterface.BackColor = System.Drawing.SystemColors.ControlDark
        Me.picInterface.Enabled = False
        Me.picInterface.Image = CType(resources.GetObject("picInterface.Image"), System.Drawing.Image)
        Me.picInterface.Location = New System.Drawing.Point(26, 6)
        Me.picInterface.Name = "picInterface"
        Me.picInterface.Size = New System.Drawing.Size(24, 24)
        Me.picInterface.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picInterface.TabIndex = 13
        Me.picInterface.TabStop = False
        '
        'lblInterface
        '
        Me.lblInterface.AutoSize = True
        Me.lblInterface.BackColor = System.Drawing.Color.Transparent
        Me.lblInterface.Enabled = False
        Me.lblInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblInterface.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblInterface.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblInterface.Location = New System.Drawing.Point(3, 40)
        Me.lblInterface.Name = "lblInterface"
        Me.lblInterface.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblInterface.Size = New System.Drawing.Size(64, 16)
        Me.lblInterface.TabIndex = 10
        Me.lblInterface.Text = "Интерфейс"
        Me.lblInterface.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSounds
        '
        Me.pnlSounds.Controls.Add(Me.picSounds)
        Me.pnlSounds.Controls.Add(Me.lblSounds)
        Me.pnlSounds.Location = New System.Drawing.Point(8, 160)
        Me.pnlSounds.Name = "pnlSounds"
        Me.pnlSounds.Size = New System.Drawing.Size(72, 64)
        Me.pnlSounds.TabIndex = 17
        '
        'picSounds
        '
        Me.picSounds.BackColor = System.Drawing.SystemColors.ControlDark
        Me.picSounds.Enabled = False
        Me.picSounds.Image = CType(resources.GetObject("picSounds.Image"), System.Drawing.Image)
        Me.picSounds.Location = New System.Drawing.Point(26, 6)
        Me.picSounds.Name = "picSounds"
        Me.picSounds.Size = New System.Drawing.Size(24, 24)
        Me.picSounds.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSounds.TabIndex = 11
        Me.picSounds.TabStop = False
        '
        'lblSounds
        '
        Me.lblSounds.AutoSize = True
        Me.lblSounds.BackColor = System.Drawing.Color.Transparent
        Me.lblSounds.Enabled = False
        Me.lblSounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSounds.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblSounds.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSounds.Location = New System.Drawing.Point(19, 40)
        Me.lblSounds.Name = "lblSounds"
        Me.lblSounds.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSounds.Size = New System.Drawing.Size(35, 16)
        Me.lblSounds.TabIndex = 10
        Me.lblSounds.Text = "Звуки"
        Me.lblSounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlNet
        '
        Me.pnlNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNet.Controls.Add(Me.picNet)
        Me.pnlNet.Controls.Add(Me.lblNet)
        Me.pnlNet.Location = New System.Drawing.Point(8, 16)
        Me.pnlNet.Name = "pnlNet"
        Me.pnlNet.Size = New System.Drawing.Size(72, 64)
        Me.pnlNet.TabIndex = 16
        '
        'picNet
        '
        Me.picNet.Enabled = False
        Me.picNet.Image = CType(resources.GetObject("picNet.Image"), System.Drawing.Image)
        Me.picNet.Location = New System.Drawing.Point(26, 6)
        Me.picNet.Name = "picNet"
        Me.picNet.Size = New System.Drawing.Size(24, 24)
        Me.picNet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picNet.TabIndex = 11
        Me.picNet.TabStop = False
        '
        'lblNet
        '
        Me.lblNet.AutoSize = True
        Me.lblNet.BackColor = System.Drawing.Color.Transparent
        Me.lblNet.Enabled = False
        Me.lblNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblNet.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblNet.Location = New System.Drawing.Point(22, 40)
        Me.lblNet.Name = "lblNet"
        Me.lblNet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNet.Size = New System.Drawing.Size(31, 16)
        Me.lblNet.TabIndex = 10
        Me.lblNet.Text = "Сеть"
        Me.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlUsers
        '
        Me.pnlUsers.Controls.Add(Me.lblUsers)
        Me.pnlUsers.Controls.Add(Me.picUsers)
        Me.pnlUsers.Location = New System.Drawing.Point(8, 88)
        Me.pnlUsers.Name = "pnlUsers"
        Me.pnlUsers.Size = New System.Drawing.Size(72, 64)
        Me.pnlUsers.TabIndex = 14
        '
        'lblUsers
        '
        Me.lblUsers.AutoSize = True
        Me.lblUsers.BackColor = System.Drawing.Color.Transparent
        Me.lblUsers.Enabled = False
        Me.lblUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblUsers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblUsers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblUsers.Location = New System.Drawing.Point(12, 42)
        Me.lblUsers.Name = "lblUsers"
        Me.lblUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblUsers.Size = New System.Drawing.Size(42, 16)
        Me.lblUsers.TabIndex = 10
        Me.lblUsers.Text = "Юзеры"
        Me.lblUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picUsers
        '
        Me.picUsers.BackColor = System.Drawing.SystemColors.ControlDark
        Me.picUsers.Enabled = False
        Me.picUsers.Image = CType(resources.GetObject("picUsers.Image"), System.Drawing.Image)
        Me.picUsers.Location = New System.Drawing.Point(26, 6)
        Me.picUsers.Name = "picUsers"
        Me.picUsers.Size = New System.Drawing.Size(24, 24)
        Me.picUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picUsers.TabIndex = 9
        Me.picUsers.TabStop = False
        '
        'tbcNet
        '
        Me.tbcNet.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcNet.Controls.Add(Me.TabPage3)
        Me.tbcNet.ImageList = Me.ImgLstOptions
        Me.tbcNet.ItemSize = New System.Drawing.Size(0, 18)
        Me.tbcNet.Location = New System.Drawing.Point(104, 16)
        Me.tbcNet.Name = "tbcNet"
        Me.tbcNet.SelectedIndex = 0
        Me.tbcNet.Size = New System.Drawing.Size(453, 288)
        Me.tbcNet.TabIndex = 5
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lblBorder5)
        Me.TabPage3.Controls.Add(Me.GroupBox7)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.lanCmdDefault)
        Me.TabPage3.ImageIndex = 3
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(445, 262)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Сеть"
        '
        'lblBorder5
        '
        Me.lblBorder5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBorder5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBorder5.Location = New System.Drawing.Point(0, 260)
        Me.lblBorder5.Name = "lblBorder5"
        Me.lblBorder5.Size = New System.Drawing.Size(445, 2)
        Me.lblBorder5.TabIndex = 91
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lanTxtBroadcastAddress)
        Me.GroupBox7.Controls.Add(Me.lanOptBroadcast)
        Me.GroupBox7.Controls.Add(Me.lanTxtMulticastAddress)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.lanOptMulticast)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.lanUDTTL)
        Me.GroupBox7.Controls.Add(Me.lblLANTTL)
        Me.GroupBox7.Location = New System.Drawing.Point(2, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(224, 216)
        Me.GroupBox7.TabIndex = 90
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Тип подключения"
        '
        'lanTxtBroadcastAddress
        '
        Me.lanTxtBroadcastAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lanTxtBroadcastAddress.Location = New System.Drawing.Point(64, 48)
        Me.lanTxtBroadcastAddress.Name = "lanTxtBroadcastAddress"
        Me.lanTxtBroadcastAddress.Size = New System.Drawing.Size(152, 20)
        Me.lanTxtBroadcastAddress.TabIndex = 46
        Me.lanTxtBroadcastAddress.Text = ""
        Me.lanTxtBroadcastAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lanOptBroadcast
        '
        Me.lanOptBroadcast.Checked = True
        Me.lanOptBroadcast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lanOptBroadcast.Location = New System.Drawing.Point(8, 24)
        Me.lanOptBroadcast.Name = "lanOptBroadcast"
        Me.lanOptBroadcast.Size = New System.Drawing.Size(112, 16)
        Me.lanOptBroadcast.TabIndex = 47
        Me.lanOptBroadcast.TabStop = True
        Me.lanOptBroadcast.Text = "Широковещание"
        '
        'lanTxtMulticastAddress
        '
        Me.lanTxtMulticastAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lanTxtMulticastAddress.Location = New System.Drawing.Point(64, 104)
        Me.lanTxtMulticastAddress.Name = "lanTxtMulticastAddress"
        Me.lanTxtMulticastAddress.Size = New System.Drawing.Size(152, 20)
        Me.lanTxtMulticastAddress.TabIndex = 41
        Me.lanTxtMulticastAddress.Text = ""
        Me.lanTxtMulticastAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 20)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Адрес"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lanOptMulticast
        '
        Me.lanOptMulticast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lanOptMulticast.Location = New System.Drawing.Point(8, 80)
        Me.lanOptMulticast.Name = "lanOptMulticast"
        Me.lanOptMulticast.Size = New System.Drawing.Size(88, 16)
        Me.lanOptMulticast.TabIndex = 44
        Me.lanOptMulticast.Text = "Мультикаст"
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 20)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Адрес"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lanUDTTL
        '
        Me.lanUDTTL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lanUDTTL.Location = New System.Drawing.Point(176, 144)
        Me.lanUDTTL.Name = "lanUDTTL"
        Me.lanUDTTL.Size = New System.Drawing.Size(40, 20)
        Me.lanUDTTL.TabIndex = 53
        Me.lanUDTTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLANTTL
        '
        Me.lblLANTTL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLANTTL.Location = New System.Drawing.Point(8, 136)
        Me.lblLANTTL.Name = "lblLANTTL"
        Me.lblLANTTL.Size = New System.Drawing.Size(168, 32)
        Me.lblLANTTL.TabIndex = 47
        Me.lblLANTTL.Text = "Кол-во проходимых сегментов (TTL):"
        Me.lblLANTTL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblSeparatorLAN)
        Me.GroupBox3.Controls.Add(Me.lanTxtIP)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.lanUDOnLine)
        Me.GroupBox3.Controls.Add(Me.lanUDRefreshList)
        Me.GroupBox3.Controls.Add(Me.lanTxtPort)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(226, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(216, 216)
        Me.GroupBox3.TabIndex = 89
        Me.GroupBox3.TabStop = False
        '
        'lblSeparatorLAN
        '
        Me.lblSeparatorLAN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSeparatorLAN.Location = New System.Drawing.Point(8, 160)
        Me.lblSeparatorLAN.Name = "lblSeparatorLAN"
        Me.lblSeparatorLAN.Size = New System.Drawing.Size(200, 2)
        Me.lblSeparatorLAN.TabIndex = 57
        '
        'lanTxtIP
        '
        Me.lanTxtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lanTxtIP.Enabled = False
        Me.lanTxtIP.Location = New System.Drawing.Point(120, 176)
        Me.lanTxtIP.Name = "lanTxtIP"
        Me.lanTxtIP.Size = New System.Drawing.Size(88, 20)
        Me.lanTxtIP.TabIndex = 56
        Me.lanTxtIP.Text = ""
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(8, 176)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(64, 16)
        Me.Label38.TabIndex = 55
        Me.Label38.Text = "Адрес IP"
        '
        'lanUDOnLine
        '
        Me.lanUDOnLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lanUDOnLine.Location = New System.Drawing.Point(168, 16)
        Me.lanUDOnLine.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.lanUDOnLine.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.lanUDOnLine.Name = "lanUDOnLine"
        Me.lanUDOnLine.Size = New System.Drawing.Size(40, 20)
        Me.lanUDOnLine.TabIndex = 52
        Me.lanUDOnLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lanUDOnLine.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lanUDRefreshList
        '
        Me.lanUDRefreshList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lanUDRefreshList.Location = New System.Drawing.Point(168, 56)
        Me.lanUDRefreshList.Name = "lanUDRefreshList"
        Me.lanUDRefreshList.Size = New System.Drawing.Size(40, 20)
        Me.lanUDRefreshList.TabIndex = 54
        Me.lanUDRefreshList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lanUDRefreshList.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'lanTxtPort
        '
        Me.lanTxtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lanTxtPort.Location = New System.Drawing.Point(168, 96)
        Me.lanTxtPort.Name = "lanTxtPort"
        Me.lanTxtPort.Size = New System.Drawing.Size(40, 20)
        Me.lanTxtPort.TabIndex = 50
        Me.lanTxtPort.Text = ""
        Me.lanTxtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(8, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 20)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Сигнал OnLine"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(8, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(144, 20)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Обновление списка (сек.)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(8, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 20)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Порт:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lanCmdDefault
        '
        Me.lanCmdDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lanCmdDefault.Location = New System.Drawing.Point(8, 224)
        Me.lanCmdDefault.Name = "lanCmdDefault"
        Me.lanCmdDefault.Size = New System.Drawing.Size(432, 24)
        Me.lanCmdDefault.TabIndex = 88
        Me.lanCmdDefault.Text = "По умолчанию"
        '
        'tbcSounds
        '
        Me.tbcSounds.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcSounds.Controls.Add(Me.tabSounds)
        Me.tbcSounds.ImageList = Me.ImgLstOptions
        Me.tbcSounds.Location = New System.Drawing.Point(104, 16)
        Me.tbcSounds.Name = "tbcSounds"
        Me.tbcSounds.SelectedIndex = 0
        Me.tbcSounds.Size = New System.Drawing.Size(453, 288)
        Me.tbcSounds.TabIndex = 6
        '
        'tabSounds
        '
        Me.tabSounds.Controls.Add(Me.lblBorder1)
        Me.tabSounds.Controls.Add(Me.sndChkOnSound)
        Me.tabSounds.Controls.Add(Me.sndChkAway)
        Me.tabSounds.Controls.Add(Me.sndChkBusy)
        Me.tabSounds.Controls.Add(Me.GroupBox10)
        Me.tabSounds.Controls.Add(Me.sndCmdDefault)
        Me.tabSounds.ImageIndex = 7
        Me.tabSounds.Location = New System.Drawing.Point(4, 26)
        Me.tabSounds.Name = "tabSounds"
        Me.tabSounds.Size = New System.Drawing.Size(445, 258)
        Me.tabSounds.TabIndex = 0
        Me.tabSounds.Text = "Звуки"
        '
        'lblBorder1
        '
        Me.lblBorder1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBorder1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBorder1.Location = New System.Drawing.Point(0, 256)
        Me.lblBorder1.Name = "lblBorder1"
        Me.lblBorder1.Size = New System.Drawing.Size(445, 2)
        Me.lblBorder1.TabIndex = 94
        '
        'sndChkOnSound
        '
        Me.sndChkOnSound.Checked = True
        Me.sndChkOnSound.CheckState = System.Windows.Forms.CheckState.Checked
        Me.sndChkOnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sndChkOnSound.Location = New System.Drawing.Point(16, 200)
        Me.sndChkOnSound.Name = "sndChkOnSound"
        Me.sndChkOnSound.Size = New System.Drawing.Size(112, 16)
        Me.sndChkOnSound.TabIndex = 93
        Me.sndChkOnSound.Text = "Включить звуки"
        '
        'sndChkAway
        '
        Me.sndChkAway.Checked = True
        Me.sndChkAway.CheckState = System.Windows.Forms.CheckState.Checked
        Me.sndChkAway.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sndChkAway.Location = New System.Drawing.Point(304, 200)
        Me.sndChkAway.Name = "sndChkAway"
        Me.sndChkAway.Size = New System.Drawing.Size(120, 16)
        Me.sndChkAway.TabIndex = 92
        Me.sndChkAway.Text = "В режиме ""Ушел"""
        '
        'sndChkBusy
        '
        Me.sndChkBusy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sndChkBusy.Location = New System.Drawing.Point(144, 200)
        Me.sndChkBusy.Name = "sndChkBusy"
        Me.sndChkBusy.Size = New System.Drawing.Size(120, 16)
        Me.sndChkBusy.TabIndex = 91
        Me.sndChkBusy.Text = "В режиме ""Занят"""
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Panel1)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox10.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(445, 184)
        Me.GroupBox10.TabIndex = 88
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Звуковые события"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.cmdSnd17)
        Me.Panel1.Controls.Add(Me.sndTxtLeaveChannel)
        Me.Panel1.Controls.Add(Me.Label39)
        Me.Panel1.Controls.Add(Me.cmdSnd16)
        Me.Panel1.Controls.Add(Me.sndTxtJoinChannel)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Controls.Add(Me.cmdSnd15)
        Me.Panel1.Controls.Add(Me.sndTxtAddLink)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.cmdSnd14)
        Me.Panel1.Controls.Add(Me.cmdSnd13)
        Me.Panel1.Controls.Add(Me.cmdSnd11)
        Me.Panel1.Controls.Add(Me.cmdSnd10)
        Me.Panel1.Controls.Add(Me.cmdSnd12)
        Me.Panel1.Controls.Add(Me.cmdSnd8)
        Me.Panel1.Controls.Add(Me.cmdSnd7)
        Me.Panel1.Controls.Add(Me.cmdSnd9)
        Me.Panel1.Controls.Add(Me.cmdSnd5)
        Me.Panel1.Controls.Add(Me.cmdSnd4)
        Me.Panel1.Controls.Add(Me.cmdSnd6)
        Me.Panel1.Controls.Add(Me.cmdSnd2)
        Me.Panel1.Controls.Add(Me.cmdSnd1)
        Me.Panel1.Controls.Add(Me.sndTxtReceiveScreenShot)
        Me.Panel1.Controls.Add(Me.sndTxtRemoteExec)
        Me.Panel1.Controls.Add(Me.sndTxtSignal)
        Me.Panel1.Controls.Add(Me.sndTxtStrMe)
        Me.Panel1.Controls.Add(Me.sndTxtChangeTopic)
        Me.Panel1.Controls.Add(Me.sndTxtMultipleMessage)
        Me.Panel1.Controls.Add(Me.sndTxtChangeName)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.Label36)
        Me.Panel1.Controls.Add(Me.Label37)
        Me.Panel1.Controls.Add(Me.sndTxtSendMessage)
        Me.Panel1.Controls.Add(Me.sndTxtReceiveMessage)
        Me.Panel1.Controls.Add(Me.sndTxtLineToChat)
        Me.Panel1.Controls.Add(Me.sndTxtEndToTalk)
        Me.Panel1.Controls.Add(Me.sndTxtExitToLan)
        Me.Panel1.Controls.Add(Me.sndTxtEnterToLan)
        Me.Panel1.Controls.Add(Me.cmdSnd3)
        Me.Panel1.Controls.Add(Me.sndTxtBeginToTalk)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Location = New System.Drawing.Point(8, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 160)
        Me.Panel1.TabIndex = 4
        '
        'cmdSnd17
        '
        Me.cmdSnd17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd17.ImageIndex = 7
        Me.cmdSnd17.ImageList = Me.ImgLstOptions
        Me.cmdSnd17.Location = New System.Drawing.Point(376, 392)
        Me.cmdSnd17.Name = "cmdSnd17"
        Me.cmdSnd17.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd17.TabIndex = 51
        '
        'sndTxtLeaveChannel
        '
        Me.sndTxtLeaveChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtLeaveChannel.Location = New System.Drawing.Point(200, 392)
        Me.sndTxtLeaveChannel.Name = "sndTxtLeaveChannel"
        Me.sndTxtLeaveChannel.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtLeaveChannel.TabIndex = 50
        Me.sndTxtLeaveChannel.Text = ""
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(6, 392)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(184, 20)
        Me.Label39.TabIndex = 49
        Me.Label39.Text = "выход из канала"
        '
        'cmdSnd16
        '
        Me.cmdSnd16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd16.ImageIndex = 7
        Me.cmdSnd16.ImageList = Me.ImgLstOptions
        Me.cmdSnd16.Location = New System.Drawing.Point(376, 368)
        Me.cmdSnd16.Name = "cmdSnd16"
        Me.cmdSnd16.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd16.TabIndex = 48
        '
        'sndTxtJoinChannel
        '
        Me.sndTxtJoinChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtJoinChannel.Location = New System.Drawing.Point(200, 368)
        Me.sndTxtJoinChannel.Name = "sndTxtJoinChannel"
        Me.sndTxtJoinChannel.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtJoinChannel.TabIndex = 47
        Me.sndTxtJoinChannel.Text = ""
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(6, 368)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(184, 20)
        Me.Label40.TabIndex = 46
        Me.Label40.Text = "Вход в канал"
        '
        'cmdSnd15
        '
        Me.cmdSnd15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd15.ImageIndex = 7
        Me.cmdSnd15.ImageList = Me.ImgLstOptions
        Me.cmdSnd15.Location = New System.Drawing.Point(376, 344)
        Me.cmdSnd15.Name = "cmdSnd15"
        Me.cmdSnd15.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd15.TabIndex = 45
        '
        'sndTxtAddLink
        '
        Me.sndTxtAddLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtAddLink.Location = New System.Drawing.Point(200, 344)
        Me.sndTxtAddLink.Name = "sndTxtAddLink"
        Me.sndTxtAddLink.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtAddLink.TabIndex = 44
        Me.sndTxtAddLink.Text = ""
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(8, 344)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(184, 20)
        Me.Label33.TabIndex = 43
        Me.Label33.Text = "Добавление ссылки"
        '
        'cmdSnd14
        '
        Me.cmdSnd14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd14.ImageIndex = 7
        Me.cmdSnd14.ImageList = Me.ImgLstOptions
        Me.cmdSnd14.Location = New System.Drawing.Point(376, 320)
        Me.cmdSnd14.Name = "cmdSnd14"
        Me.cmdSnd14.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd14.TabIndex = 42
        '
        'cmdSnd13
        '
        Me.cmdSnd13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd13.ImageIndex = 7
        Me.cmdSnd13.ImageList = Me.ImgLstOptions
        Me.cmdSnd13.Location = New System.Drawing.Point(376, 296)
        Me.cmdSnd13.Name = "cmdSnd13"
        Me.cmdSnd13.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd13.TabIndex = 41
        '
        'cmdSnd11
        '
        Me.cmdSnd11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd11.ImageIndex = 7
        Me.cmdSnd11.ImageList = Me.ImgLstOptions
        Me.cmdSnd11.Location = New System.Drawing.Point(376, 248)
        Me.cmdSnd11.Name = "cmdSnd11"
        Me.cmdSnd11.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd11.TabIndex = 40
        '
        'cmdSnd10
        '
        Me.cmdSnd10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd10.ImageIndex = 7
        Me.cmdSnd10.ImageList = Me.ImgLstOptions
        Me.cmdSnd10.Location = New System.Drawing.Point(376, 224)
        Me.cmdSnd10.Name = "cmdSnd10"
        Me.cmdSnd10.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd10.TabIndex = 39
        '
        'cmdSnd12
        '
        Me.cmdSnd12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd12.ImageIndex = 7
        Me.cmdSnd12.ImageList = Me.ImgLstOptions
        Me.cmdSnd12.Location = New System.Drawing.Point(376, 272)
        Me.cmdSnd12.Name = "cmdSnd12"
        Me.cmdSnd12.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd12.TabIndex = 38
        '
        'cmdSnd8
        '
        Me.cmdSnd8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd8.ImageIndex = 7
        Me.cmdSnd8.ImageList = Me.ImgLstOptions
        Me.cmdSnd8.Location = New System.Drawing.Point(376, 176)
        Me.cmdSnd8.Name = "cmdSnd8"
        Me.cmdSnd8.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd8.TabIndex = 37
        '
        'cmdSnd7
        '
        Me.cmdSnd7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd7.ImageIndex = 7
        Me.cmdSnd7.ImageList = Me.ImgLstOptions
        Me.cmdSnd7.Location = New System.Drawing.Point(376, 152)
        Me.cmdSnd7.Name = "cmdSnd7"
        Me.cmdSnd7.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd7.TabIndex = 36
        '
        'cmdSnd9
        '
        Me.cmdSnd9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd9.ImageIndex = 7
        Me.cmdSnd9.ImageList = Me.ImgLstOptions
        Me.cmdSnd9.Location = New System.Drawing.Point(376, 200)
        Me.cmdSnd9.Name = "cmdSnd9"
        Me.cmdSnd9.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd9.TabIndex = 35
        '
        'cmdSnd5
        '
        Me.cmdSnd5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd5.ImageIndex = 7
        Me.cmdSnd5.ImageList = Me.ImgLstOptions
        Me.cmdSnd5.Location = New System.Drawing.Point(376, 104)
        Me.cmdSnd5.Name = "cmdSnd5"
        Me.cmdSnd5.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd5.TabIndex = 34
        '
        'cmdSnd4
        '
        Me.cmdSnd4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd4.ImageIndex = 7
        Me.cmdSnd4.ImageList = Me.ImgLstOptions
        Me.cmdSnd4.Location = New System.Drawing.Point(376, 80)
        Me.cmdSnd4.Name = "cmdSnd4"
        Me.cmdSnd4.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd4.TabIndex = 33
        '
        'cmdSnd6
        '
        Me.cmdSnd6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd6.ImageIndex = 7
        Me.cmdSnd6.ImageList = Me.ImgLstOptions
        Me.cmdSnd6.Location = New System.Drawing.Point(376, 128)
        Me.cmdSnd6.Name = "cmdSnd6"
        Me.cmdSnd6.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd6.TabIndex = 32
        '
        'cmdSnd2
        '
        Me.cmdSnd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd2.ImageIndex = 7
        Me.cmdSnd2.ImageList = Me.ImgLstOptions
        Me.cmdSnd2.Location = New System.Drawing.Point(376, 32)
        Me.cmdSnd2.Name = "cmdSnd2"
        Me.cmdSnd2.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd2.TabIndex = 31
        '
        'cmdSnd1
        '
        Me.cmdSnd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd1.ImageIndex = 7
        Me.cmdSnd1.ImageList = Me.ImgLstOptions
        Me.cmdSnd1.Location = New System.Drawing.Point(376, 8)
        Me.cmdSnd1.Name = "cmdSnd1"
        Me.cmdSnd1.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd1.TabIndex = 30
        '
        'sndTxtReceiveScreenShot
        '
        Me.sndTxtReceiveScreenShot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtReceiveScreenShot.Location = New System.Drawing.Point(200, 320)
        Me.sndTxtReceiveScreenShot.Name = "sndTxtReceiveScreenShot"
        Me.sndTxtReceiveScreenShot.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtReceiveScreenShot.TabIndex = 29
        Me.sndTxtReceiveScreenShot.Text = ""
        '
        'sndTxtRemoteExec
        '
        Me.sndTxtRemoteExec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtRemoteExec.Location = New System.Drawing.Point(200, 296)
        Me.sndTxtRemoteExec.Name = "sndTxtRemoteExec"
        Me.sndTxtRemoteExec.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtRemoteExec.TabIndex = 28
        Me.sndTxtRemoteExec.Text = ""
        '
        'sndTxtSignal
        '
        Me.sndTxtSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtSignal.Location = New System.Drawing.Point(200, 272)
        Me.sndTxtSignal.Name = "sndTxtSignal"
        Me.sndTxtSignal.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtSignal.TabIndex = 27
        Me.sndTxtSignal.Text = ""
        '
        'sndTxtStrMe
        '
        Me.sndTxtStrMe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtStrMe.Location = New System.Drawing.Point(200, 248)
        Me.sndTxtStrMe.Name = "sndTxtStrMe"
        Me.sndTxtStrMe.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtStrMe.TabIndex = 26
        Me.sndTxtStrMe.Text = ""
        '
        'sndTxtChangeTopic
        '
        Me.sndTxtChangeTopic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtChangeTopic.Location = New System.Drawing.Point(200, 200)
        Me.sndTxtChangeTopic.Name = "sndTxtChangeTopic"
        Me.sndTxtChangeTopic.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtChangeTopic.TabIndex = 25
        Me.sndTxtChangeTopic.Text = ""
        '
        'sndTxtMultipleMessage
        '
        Me.sndTxtMultipleMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtMultipleMessage.Location = New System.Drawing.Point(200, 176)
        Me.sndTxtMultipleMessage.Name = "sndTxtMultipleMessage"
        Me.sndTxtMultipleMessage.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtMultipleMessage.TabIndex = 24
        Me.sndTxtMultipleMessage.Text = ""
        '
        'sndTxtChangeName
        '
        Me.sndTxtChangeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtChangeName.Location = New System.Drawing.Point(200, 224)
        Me.sndTxtChangeName.Name = "sndTxtChangeName"
        Me.sndTxtChangeName.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtChangeName.TabIndex = 23
        Me.sndTxtChangeName.Text = ""
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(8, 320)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(184, 20)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "Получение скриншота"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(8, 296)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(184, 20)
        Me.Label28.TabIndex = 21
        Me.Label28.Text = "Удаленное исполнение"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(8, 272)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(184, 20)
        Me.Label32.TabIndex = 20
        Me.Label32.Text = "Сигнал"
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(8, 248)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(184, 20)
        Me.Label34.TabIndex = 19
        Me.Label34.Text = "Строка /me"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(8, 224)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(184, 20)
        Me.Label35.TabIndex = 18
        Me.Label35.Text = "Изменение имени"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(8, 200)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(184, 20)
        Me.Label36.TabIndex = 17
        Me.Label36.Text = "Изменение темы"
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(8, 176)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(184, 20)
        Me.Label37.TabIndex = 16
        Me.Label37.Text = "Многоадресное сообщение"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sndTxtSendMessage
        '
        Me.sndTxtSendMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtSendMessage.Location = New System.Drawing.Point(200, 152)
        Me.sndTxtSendMessage.Name = "sndTxtSendMessage"
        Me.sndTxtSendMessage.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtSendMessage.TabIndex = 15
        Me.sndTxtSendMessage.Text = ""
        '
        'sndTxtReceiveMessage
        '
        Me.sndTxtReceiveMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtReceiveMessage.Location = New System.Drawing.Point(200, 128)
        Me.sndTxtReceiveMessage.Name = "sndTxtReceiveMessage"
        Me.sndTxtReceiveMessage.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtReceiveMessage.TabIndex = 14
        Me.sndTxtReceiveMessage.Text = ""
        '
        'sndTxtLineToChat
        '
        Me.sndTxtLineToChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtLineToChat.Location = New System.Drawing.Point(200, 104)
        Me.sndTxtLineToChat.Name = "sndTxtLineToChat"
        Me.sndTxtLineToChat.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtLineToChat.TabIndex = 13
        Me.sndTxtLineToChat.Text = ""
        '
        'sndTxtEndToTalk
        '
        Me.sndTxtEndToTalk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtEndToTalk.Location = New System.Drawing.Point(200, 80)
        Me.sndTxtEndToTalk.Name = "sndTxtEndToTalk"
        Me.sndTxtEndToTalk.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtEndToTalk.TabIndex = 12
        Me.sndTxtEndToTalk.Text = ""
        '
        'sndTxtExitToLan
        '
        Me.sndTxtExitToLan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtExitToLan.Location = New System.Drawing.Point(200, 32)
        Me.sndTxtExitToLan.Name = "sndTxtExitToLan"
        Me.sndTxtExitToLan.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtExitToLan.TabIndex = 11
        Me.sndTxtExitToLan.Text = ""
        '
        'sndTxtEnterToLan
        '
        Me.sndTxtEnterToLan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtEnterToLan.Location = New System.Drawing.Point(200, 8)
        Me.sndTxtEnterToLan.Name = "sndTxtEnterToLan"
        Me.sndTxtEnterToLan.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtEnterToLan.TabIndex = 10
        Me.sndTxtEnterToLan.Text = ""
        '
        'cmdSnd3
        '
        Me.cmdSnd3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSnd3.ImageIndex = 7
        Me.cmdSnd3.ImageList = Me.ImgLstOptions
        Me.cmdSnd3.Location = New System.Drawing.Point(376, 56)
        Me.cmdSnd3.Name = "cmdSnd3"
        Me.cmdSnd3.Size = New System.Drawing.Size(20, 20)
        Me.cmdSnd3.TabIndex = 9
        '
        'sndTxtBeginToTalk
        '
        Me.sndTxtBeginToTalk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sndTxtBeginToTalk.Location = New System.Drawing.Point(200, 56)
        Me.sndTxtBeginToTalk.Name = "sndTxtBeginToTalk"
        Me.sndTxtBeginToTalk.Size = New System.Drawing.Size(168, 20)
        Me.sndTxtBeginToTalk.TabIndex = 8
        Me.sndTxtBeginToTalk.Text = ""
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(8, 152)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(184, 20)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "Отправка сообщения"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(8, 128)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(184, 20)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Получение сообщения"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 104)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(184, 20)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "Строка в чате"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 80)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(184, 20)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Завершение разговора"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(8, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(184, 20)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Начало разговора"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(184, 20)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Выход из сети"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(184, 20)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Вход в сеть"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sndCmdDefault
        '
        Me.sndCmdDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sndCmdDefault.Location = New System.Drawing.Point(8, 224)
        Me.sndCmdDefault.Name = "sndCmdDefault"
        Me.sndCmdDefault.Size = New System.Drawing.Size(432, 24)
        Me.sndCmdDefault.TabIndex = 87
        Me.sndCmdDefault.Text = "По умолчанию"
        '
        'tbcInterface
        '
        Me.tbcInterface.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcInterface.Controls.Add(Me.intcoltabColors)
        Me.tbcInterface.Controls.Add(Me.tabPopupOptions)
        Me.tbcInterface.Controls.Add(Me.tabInterface)
        Me.tbcInterface.Controls.Add(Me.tabViewSymbols)
        Me.tbcInterface.Controls.Add(Me.tabLanguage)
        Me.tbcInterface.ImageList = Me.ImgLstOptions
        Me.tbcInterface.Location = New System.Drawing.Point(104, 16)
        Me.tbcInterface.Name = "tbcInterface"
        Me.tbcInterface.SelectedIndex = 0
        Me.tbcInterface.Size = New System.Drawing.Size(453, 288)
        Me.tbcInterface.TabIndex = 7
        '
        'intcoltabColors
        '
        Me.intcoltabColors.Controls.Add(Me.lblBorder2)
        Me.intcoltabColors.Controls.Add(Me.colfraColors)
        Me.intcoltabColors.Controls.Add(Me.colCmdDefault)
        Me.intcoltabColors.ImageIndex = 0
        Me.intcoltabColors.Location = New System.Drawing.Point(4, 26)
        Me.intcoltabColors.Name = "intcoltabColors"
        Me.intcoltabColors.Size = New System.Drawing.Size(445, 258)
        Me.intcoltabColors.TabIndex = 0
        Me.intcoltabColors.Text = "Цвета"
        '
        'lblBorder2
        '
        Me.lblBorder2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBorder2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBorder2.Location = New System.Drawing.Point(0, 256)
        Me.lblBorder2.Name = "lblBorder2"
        Me.lblBorder2.Size = New System.Drawing.Size(445, 2)
        Me.lblBorder2.TabIndex = 88
        '
        'colfraColors
        '
        Me.colfraColors.Controls.Add(Me.Panel2)
        Me.colfraColors.Dock = System.Windows.Forms.DockStyle.Top
        Me.colfraColors.Location = New System.Drawing.Point(0, 0)
        Me.colfraColors.Name = "colfraColors"
        Me.colfraColors.Size = New System.Drawing.Size(445, 216)
        Me.colfraColors.TabIndex = 87
        Me.colfraColors.TabStop = False
        Me.colfraColors.Text = "Цвета"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.colCmd4)
        Me.Panel2.Controls.Add(Me.colCmd11)
        Me.Panel2.Controls.Add(Me.colCmd6)
        Me.Panel2.Controls.Add(Me.colCmd9)
        Me.Panel2.Controls.Add(Me.colCmd7)
        Me.Panel2.Controls.Add(Me.colCmd1)
        Me.Panel2.Controls.Add(Me.colCmd10)
        Me.Panel2.Controls.Add(Me.colCmd8)
        Me.Panel2.Controls.Add(Me.colCmd5)
        Me.Panel2.Controls.Add(Me.colCmd15)
        Me.Panel2.Controls.Add(Me.colCmd12)
        Me.Panel2.Controls.Add(Me.colCmd16)
        Me.Panel2.Controls.Add(Me.colCmd2)
        Me.Panel2.Controls.Add(Me.colCmd13)
        Me.Panel2.Controls.Add(Me.colCmd14)
        Me.Panel2.Controls.Add(Me.colCmd3)
        Me.Panel2.Location = New System.Drawing.Point(24, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(416, 192)
        Me.Panel2.TabIndex = 0
        '
        'colCmd4
        '
        Me.colCmd4.BackColor = System.Drawing.Color.Green
        Me.colCmd4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd4.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd4.Location = New System.Drawing.Point(8, 72)
        Me.colCmd4.Name = "colCmd4"
        Me.colCmd4.Size = New System.Drawing.Size(192, 20)
        Me.colCmd4.TabIndex = 73
        Me.colCmd4.Text = "Выход из сети"
        '
        'colCmd11
        '
        Me.colCmd11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.colCmd11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd11.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd11.Location = New System.Drawing.Point(200, 48)
        Me.colCmd11.Name = "colCmd11"
        Me.colCmd11.Size = New System.Drawing.Size(192, 20)
        Me.colCmd11.TabIndex = 79
        Me.colCmd11.Text = "Фон чата"
        '
        'colCmd6
        '
        Me.colCmd6.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.colCmd6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd6.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd6.Location = New System.Drawing.Point(8, 120)
        Me.colCmd6.Name = "colCmd6"
        Me.colCmd6.Size = New System.Drawing.Size(192, 20)
        Me.colCmd6.TabIndex = 78
        Me.colCmd6.Text = "Смена темы"
        '
        'colCmd9
        '
        Me.colCmd9.BackColor = System.Drawing.Color.Navy
        Me.colCmd9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd9.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd9.Location = New System.Drawing.Point(200, 0)
        Me.colCmd9.Name = "colCmd9"
        Me.colCmd9.Size = New System.Drawing.Size(192, 20)
        Me.colCmd9.TabIndex = 85
        Me.colCmd9.Text = "Отправка сообщения"
        '
        'colCmd7
        '
        Me.colCmd7.BackColor = System.Drawing.Color.Fuchsia
        Me.colCmd7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd7.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd7.Location = New System.Drawing.Point(8, 144)
        Me.colCmd7.Name = "colCmd7"
        Me.colCmd7.Size = New System.Drawing.Size(192, 20)
        Me.colCmd7.TabIndex = 79
        Me.colCmd7.Text = "Приветствие"
        '
        'colCmd1
        '
        Me.colCmd1.BackColor = System.Drawing.Color.Black
        Me.colCmd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd1.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd1.Location = New System.Drawing.Point(8, 0)
        Me.colCmd1.Name = "colCmd1"
        Me.colCmd1.Size = New System.Drawing.Size(192, 20)
        Me.colCmd1.TabIndex = 76
        Me.colCmd1.Text = "Собственный текст"
        '
        'colCmd10
        '
        Me.colCmd10.BackColor = System.Drawing.Color.Navy
        Me.colCmd10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd10.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd10.Location = New System.Drawing.Point(200, 24)
        Me.colCmd10.Name = "colCmd10"
        Me.colCmd10.Size = New System.Drawing.Size(192, 20)
        Me.colCmd10.TabIndex = 86
        Me.colCmd10.Text = "Получение сообщения"
        '
        'colCmd8
        '
        Me.colCmd8.BackColor = System.Drawing.Color.Teal
        Me.colCmd8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd8.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd8.Location = New System.Drawing.Point(8, 168)
        Me.colCmd8.Name = "colCmd8"
        Me.colCmd8.Size = New System.Drawing.Size(192, 20)
        Me.colCmd8.TabIndex = 74
        Me.colCmd8.Text = "Исполнение"
        '
        'colCmd5
        '
        Me.colCmd5.BackColor = System.Drawing.Color.Maroon
        Me.colCmd5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd5.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd5.Location = New System.Drawing.Point(8, 96)
        Me.colCmd5.Name = "colCmd5"
        Me.colCmd5.Size = New System.Drawing.Size(192, 20)
        Me.colCmd5.TabIndex = 75
        Me.colCmd5.Text = "Смена имени"
        '
        'colCmd15
        '
        Me.colCmd15.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.colCmd15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd15.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd15.Location = New System.Drawing.Point(200, 144)
        Me.colCmd15.Name = "colCmd15"
        Me.colCmd15.Size = New System.Drawing.Size(192, 20)
        Me.colCmd15.TabIndex = 80
        Me.colCmd15.Text = "Получение скриншота"
        '
        'colCmd12
        '
        Me.colCmd12.BackColor = System.Drawing.Color.Purple
        Me.colCmd12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd12.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd12.Location = New System.Drawing.Point(200, 72)
        Me.colCmd12.Name = "colCmd12"
        Me.colCmd12.Size = New System.Drawing.Size(192, 20)
        Me.colCmd12.TabIndex = 77
        Me.colCmd12.Text = "Строка /me"
        '
        'colCmd16
        '
        Me.colCmd16.BackColor = System.Drawing.Color.Gray
        Me.colCmd16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd16.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd16.Location = New System.Drawing.Point(200, 168)
        Me.colCmd16.Name = "colCmd16"
        Me.colCmd16.Size = New System.Drawing.Size(192, 20)
        Me.colCmd16.TabIndex = 81
        Me.colCmd16.Text = "Изменение режима"
        '
        'colCmd2
        '
        Me.colCmd2.BackColor = System.Drawing.Color.Blue
        Me.colCmd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd2.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd2.Location = New System.Drawing.Point(8, 24)
        Me.colCmd2.Name = "colCmd2"
        Me.colCmd2.Size = New System.Drawing.Size(192, 20)
        Me.colCmd2.TabIndex = 77
        Me.colCmd2.Text = "Внешний текст"
        '
        'colCmd13
        '
        Me.colCmd13.BackColor = System.Drawing.Color.FromArgb(CType(103, Byte), CType(60, Byte), CType(239, Byte))
        Me.colCmd13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd13.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd13.Location = New System.Drawing.Point(200, 96)
        Me.colCmd13.Name = "colCmd13"
        Me.colCmd13.Size = New System.Drawing.Size(192, 20)
        Me.colCmd13.TabIndex = 78
        Me.colCmd13.Text = "Многоадресное сообщение"
        '
        'colCmd14
        '
        Me.colCmd14.BackColor = System.Drawing.Color.Black
        Me.colCmd14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd14.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd14.Location = New System.Drawing.Point(200, 120)
        Me.colCmd14.Name = "colCmd14"
        Me.colCmd14.Size = New System.Drawing.Size(192, 20)
        Me.colCmd14.TabIndex = 81
        Me.colCmd14.Text = "Цвет текста в окнах"
        '
        'colCmd3
        '
        Me.colCmd3.BackColor = System.Drawing.Color.Green
        Me.colCmd3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmd3.ForeColor = System.Drawing.Color.Gainsboro
        Me.colCmd3.Location = New System.Drawing.Point(8, 48)
        Me.colCmd3.Name = "colCmd3"
        Me.colCmd3.Size = New System.Drawing.Size(192, 20)
        Me.colCmd3.TabIndex = 72
        Me.colCmd3.Text = "Вход из сеть"
        '
        'colCmdDefault
        '
        Me.colCmdDefault.Enabled = False
        Me.colCmdDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCmdDefault.Location = New System.Drawing.Point(8, 224)
        Me.colCmdDefault.Name = "colCmdDefault"
        Me.colCmdDefault.Size = New System.Drawing.Size(432, 24)
        Me.colCmdDefault.TabIndex = 86
        Me.colCmdDefault.Text = "По умолчанию"
        '
        'tabInterface
        '
        Me.tabInterface.Controls.Add(Me.lblBorder3)
        Me.tabInterface.Controls.Add(Me.fraInterfOther)
        Me.tabInterface.Controls.Add(Me.fraInterfTabs)
        Me.tabInterface.Controls.Add(Me.fraInterfShow)
        Me.tabInterface.Controls.Add(Me.fraInterfFont)
        Me.tabInterface.Controls.Add(Me.cmdDefInterf)
        Me.tabInterface.ImageIndex = 2
        Me.tabInterface.Location = New System.Drawing.Point(4, 26)
        Me.tabInterface.Name = "tabInterface"
        Me.tabInterface.Size = New System.Drawing.Size(445, 258)
        Me.tabInterface.TabIndex = 2
        Me.tabInterface.Text = "Внешний вид"
        '
        'lblBorder3
        '
        Me.lblBorder3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBorder3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBorder3.Location = New System.Drawing.Point(0, 256)
        Me.lblBorder3.Name = "lblBorder3"
        Me.lblBorder3.Size = New System.Drawing.Size(445, 2)
        Me.lblBorder3.TabIndex = 89
        '
        'fraInterfOther
        '
        Me.fraInterfOther.Location = New System.Drawing.Point(240, 80)
        Me.fraInterfOther.Name = "fraInterfOther"
        Me.fraInterfOther.Size = New System.Drawing.Size(200, 136)
        Me.fraInterfOther.TabIndex = 57
        Me.fraInterfOther.TabStop = False
        '
        'fraInterfTabs
        '
        Me.fraInterfTabs.Controls.Add(Me.intOptFlatButtons)
        Me.fraInterfTabs.Controls.Add(Me.intOptButtons)
        Me.fraInterfTabs.Controls.Add(Me.intOptTab)
        Me.fraInterfTabs.Location = New System.Drawing.Point(0, 0)
        Me.fraInterfTabs.Name = "fraInterfTabs"
        Me.fraInterfTabs.Size = New System.Drawing.Size(232, 80)
        Me.fraInterfTabs.TabIndex = 54
        Me.fraInterfTabs.TabStop = False
        Me.fraInterfTabs.Text = "Тип закладок"
        '
        'intOptFlatButtons
        '
        Me.intOptFlatButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.intOptFlatButtons.Location = New System.Drawing.Point(16, 32)
        Me.intOptFlatButtons.Name = "intOptFlatButtons"
        Me.intOptFlatButtons.Size = New System.Drawing.Size(200, 16)
        Me.intOptFlatButtons.TabIndex = 2
        Me.intOptFlatButtons.Text = "Плоские кнопки"
        '
        'intOptButtons
        '
        Me.intOptButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.intOptButtons.Location = New System.Drawing.Point(16, 48)
        Me.intOptButtons.Name = "intOptButtons"
        Me.intOptButtons.Size = New System.Drawing.Size(200, 16)
        Me.intOptButtons.TabIndex = 1
        Me.intOptButtons.Text = "Кнопки"
        '
        'intOptTab
        '
        Me.intOptTab.Checked = True
        Me.intOptTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.intOptTab.Location = New System.Drawing.Point(16, 16)
        Me.intOptTab.Name = "intOptTab"
        Me.intOptTab.Size = New System.Drawing.Size(192, 16)
        Me.intOptTab.TabIndex = 0
        Me.intOptTab.TabStop = True
        Me.intOptTab.Text = "Закладки"
        '
        'fraInterfShow
        '
        Me.fraInterfShow.Controls.Add(Me.intChkTopic)
        Me.fraInterfShow.Controls.Add(Me.intChkName)
        Me.fraInterfShow.Location = New System.Drawing.Point(0, 80)
        Me.fraInterfShow.Name = "fraInterfShow"
        Me.fraInterfShow.Size = New System.Drawing.Size(232, 136)
        Me.fraInterfShow.TabIndex = 55
        Me.fraInterfShow.TabStop = False
        Me.fraInterfShow.Text = "Отображать"
        '
        'intChkTopic
        '
        Me.intChkTopic.Checked = True
        Me.intChkTopic.CheckState = System.Windows.Forms.CheckState.Checked
        Me.intChkTopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.intChkTopic.Location = New System.Drawing.Point(16, 48)
        Me.intChkTopic.Name = "intChkTopic"
        Me.intChkTopic.Size = New System.Drawing.Size(56, 16)
        Me.intChkTopic.TabIndex = 2
        Me.intChkTopic.Text = "Тема"
        '
        'intChkName
        '
        Me.intChkName.Checked = True
        Me.intChkName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.intChkName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.intChkName.Location = New System.Drawing.Point(16, 24)
        Me.intChkName.Name = "intChkName"
        Me.intChkName.Size = New System.Drawing.Size(120, 16)
        Me.intChkName.TabIndex = 1
        Me.intChkName.Text = "Имя пользователя"
        '
        'fraInterfFont
        '
        Me.fraInterfFont.Controls.Add(Me.intCmdFont)
        Me.fraInterfFont.Location = New System.Drawing.Point(240, 0)
        Me.fraInterfFont.Name = "fraInterfFont"
        Me.fraInterfFont.Size = New System.Drawing.Size(200, 80)
        Me.fraInterfFont.TabIndex = 56
        Me.fraInterfFont.TabStop = False
        Me.fraInterfFont.Text = "Шрифт"
        '
        'intCmdFont
        '
        Me.intCmdFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.intCmdFont.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.intCmdFont.Location = New System.Drawing.Point(32, 48)
        Me.intCmdFont.Name = "intCmdFont"
        Me.intCmdFont.Size = New System.Drawing.Size(144, 24)
        Me.intCmdFont.TabIndex = 1
        Me.intCmdFont.Text = "Шрифт"
        '
        'cmdDefInterf
        '
        Me.cmdDefInterf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDefInterf.Location = New System.Drawing.Point(8, 224)
        Me.cmdDefInterf.Name = "cmdDefInterf"
        Me.cmdDefInterf.Size = New System.Drawing.Size(432, 24)
        Me.cmdDefInterf.TabIndex = 53
        Me.cmdDefInterf.Text = "По умолчанию"
        '
        'tabViewSymbols
        '
        Me.tabViewSymbols.Controls.Add(Me.lblBorder4)
        Me.tabViewSymbols.Controls.Add(Me.fraSymbOther)
        Me.tabViewSymbols.Controls.Add(Me.fraSymbShowSymb)
        Me.tabViewSymbols.Controls.Add(Me.fraSymbSymb)
        Me.tabViewSymbols.Controls.Add(Me.cmdDefShowSymb)
        Me.tabViewSymbols.ImageIndex = 1
        Me.tabViewSymbols.Location = New System.Drawing.Point(4, 26)
        Me.tabViewSymbols.Name = "tabViewSymbols"
        Me.tabViewSymbols.Size = New System.Drawing.Size(445, 258)
        Me.tabViewSymbols.TabIndex = 1
        Me.tabViewSymbols.Text = "Отображаемые символы"
        '
        'lblBorder4
        '
        Me.lblBorder4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBorder4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBorder4.Location = New System.Drawing.Point(0, 256)
        Me.lblBorder4.Name = "lblBorder4"
        Me.lblBorder4.Size = New System.Drawing.Size(445, 2)
        Me.lblBorder4.TabIndex = 89
        '
        'fraSymbOther
        '
        Me.fraSymbOther.Controls.Add(Me.chkUseRTF)
        Me.fraSymbOther.Location = New System.Drawing.Point(232, 88)
        Me.fraSymbOther.Name = "fraSymbOther"
        Me.fraSymbOther.Size = New System.Drawing.Size(208, 128)
        Me.fraSymbOther.TabIndex = 56
        Me.fraSymbOther.TabStop = False
        '
        'chkUseRTF
        '
        Me.chkUseRTF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUseRTF.Location = New System.Drawing.Point(8, 16)
        Me.chkUseRTF.Name = "chkUseRTF"
        Me.chkUseRTF.Size = New System.Drawing.Size(192, 32)
        Me.chkUseRTF.TabIndex = 0
        Me.chkUseRTF.Text = "Использовать форматирование текста (DC1/RTF)"
        '
        'fraSymbShowSymb
        '
        Me.fraSymbShowSymb.Controls.Add(Me.Label4)
        Me.fraSymbShowSymb.Controls.Add(Me.Label3)
        Me.fraSymbShowSymb.Controls.Add(Me.smbTxtRightUsers)
        Me.fraSymbShowSymb.Controls.Add(Me.Label2)
        Me.fraSymbShowSymb.Controls.Add(Me.Label1)
        Me.fraSymbShowSymb.Controls.Add(Me.smbTxtRightTime)
        Me.fraSymbShowSymb.Controls.Add(Me.smbTxtLeftUsers)
        Me.fraSymbShowSymb.Controls.Add(Me.Label16)
        Me.fraSymbShowSymb.Controls.Add(Me.smbTxtLeftTime)
        Me.fraSymbShowSymb.Controls.Add(Me.Label30)
        Me.fraSymbShowSymb.Location = New System.Drawing.Point(0, 0)
        Me.fraSymbShowSymb.Name = "fraSymbShowSymb"
        Me.fraSymbShowSymb.Size = New System.Drawing.Size(224, 216)
        Me.fraSymbShowSymb.TabIndex = 54
        Me.fraSymbShowSymb.TabStop = False
        Me.fraSymbShowSymb.Text = "Отображаемые символы"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(96, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "<User>"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(32, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "00:00:00"
        '
        'smbTxtRightUsers
        '
        Me.smbTxtRightUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.smbTxtRightUsers.Location = New System.Drawing.Point(114, 56)
        Me.smbTxtRightUsers.Name = "smbTxtRightUsers"
        Me.smbTxtRightUsers.Size = New System.Drawing.Size(16, 20)
        Me.smbTxtRightUsers.TabIndex = 36
        Me.smbTxtRightUsers.Text = ">"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(88, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "User"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "[00:00:00]"
        '
        'smbTxtRightTime
        '
        Me.smbTxtRightTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.smbTxtRightTime.Location = New System.Drawing.Point(80, 128)
        Me.smbTxtRightTime.Name = "smbTxtRightTime"
        Me.smbTxtRightTime.Size = New System.Drawing.Size(16, 20)
        Me.smbTxtRightTime.TabIndex = 32
        Me.smbTxtRightTime.Text = "]"
        '
        'smbTxtLeftUsers
        '
        Me.smbTxtLeftUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.smbTxtLeftUsers.Location = New System.Drawing.Point(72, 56)
        Me.smbTxtLeftUsers.Name = "smbTxtLeftUsers"
        Me.smbTxtLeftUsers.Size = New System.Drawing.Size(16, 20)
        Me.smbTxtLeftUsers.TabIndex = 30
        Me.smbTxtLeftUsers.Text = "<"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(208, 20)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Левый и правый символы в имени:"
        '
        'smbTxtLeftTime
        '
        Me.smbTxtLeftTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.smbTxtLeftTime.Location = New System.Drawing.Point(16, 128)
        Me.smbTxtLeftTime.Name = "smbTxtLeftTime"
        Me.smbTxtLeftTime.Size = New System.Drawing.Size(16, 20)
        Me.smbTxtLeftTime.TabIndex = 33
        Me.smbTxtLeftTime.Text = "["
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(8, 104)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(208, 20)
        Me.Label30.TabIndex = 31
        Me.Label30.Text = "Левый и правый символы во времени:"
        '
        'fraSymbSymb
        '
        Me.fraSymbSymb.Controls.Add(Me.smbChkSystemMessage)
        Me.fraSymbSymb.Location = New System.Drawing.Point(232, 0)
        Me.fraSymbSymb.Name = "fraSymbSymb"
        Me.fraSymbSymb.Size = New System.Drawing.Size(208, 88)
        Me.fraSymbSymb.TabIndex = 55
        Me.fraSymbSymb.TabStop = False
        Me.fraSymbSymb.Text = "Временные штампы"
        '
        'smbChkSystemMessage
        '
        Me.smbChkSystemMessage.Checked = True
        Me.smbChkSystemMessage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.smbChkSystemMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.smbChkSystemMessage.Location = New System.Drawing.Point(8, 24)
        Me.smbChkSystemMessage.Name = "smbChkSystemMessage"
        Me.smbChkSystemMessage.Size = New System.Drawing.Size(184, 16)
        Me.smbChkSystemMessage.TabIndex = 29
        Me.smbChkSystemMessage.Text = "Отображать временной штамп"
        '
        'cmdDefShowSymb
        '
        Me.cmdDefShowSymb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDefShowSymb.Location = New System.Drawing.Point(8, 224)
        Me.cmdDefShowSymb.Name = "cmdDefShowSymb"
        Me.cmdDefShowSymb.Size = New System.Drawing.Size(432, 24)
        Me.cmdDefShowSymb.TabIndex = 47
        Me.cmdDefShowSymb.Text = "По умолчанию"
        '
        'tabPopupOptions
        '
        Me.tabPopupOptions.Controls.Add(Me.Label5)
        Me.tabPopupOptions.Controls.Add(Me.CheckBox15)
        Me.tabPopupOptions.Controls.Add(Me.fraPopMsg)
        Me.tabPopupOptions.Controls.Add(Me.fraPopMain)
        Me.tabPopupOptions.Controls.Add(Me.cmdDefPop)
        Me.tabPopupOptions.ImageIndex = 8
        Me.tabPopupOptions.Location = New System.Drawing.Point(4, 26)
        Me.tabPopupOptions.Name = "tabPopupOptions"
        Me.tabPopupOptions.Size = New System.Drawing.Size(445, 258)
        Me.tabPopupOptions.TabIndex = 3
        Me.tabPopupOptions.Text = "Всплытие"
        Me.tabPopupOptions.ToolTipText = "Выбор параметров всплытия окна"
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Location = New System.Drawing.Point(0, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(445, 2)
        Me.Label5.TabIndex = 89
        '
        'CheckBox15
        '
        Me.CheckBox15.Checked = True
        Me.CheckBox15.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox15.Location = New System.Drawing.Point(6, 192)
        Me.CheckBox15.Name = "CheckBox15"
        Me.CheckBox15.Size = New System.Drawing.Size(144, 16)
        Me.CheckBox15.TabIndex = 58
        Me.CheckBox15.Text = "Запускать свернутым"
        '
        'fraPopMsg
        '
        Me.fraPopMsg.Controls.Add(Me.pnlPopAway)
        Me.fraPopMsg.Controls.Add(Me.pnlpopPlay)
        Me.fraPopMsg.Controls.Add(Me.pnlPopWork)
        Me.fraPopMsg.Location = New System.Drawing.Point(224, 0)
        Me.fraPopMsg.Name = "fraPopMsg"
        Me.fraPopMsg.Size = New System.Drawing.Size(216, 184)
        Me.fraPopMsg.TabIndex = 56
        Me.fraPopMsg.TabStop = False
        Me.fraPopMsg.Text = "Сообщения"
        '
        'pnlPopAway
        '
        Me.pnlPopAway.Controls.Add(Me.pupOptAwayOff)
        Me.pnlPopAway.Controls.Add(Me.pupOptAwayOn)
        Me.pnlPopAway.Controls.Add(Me.Label31)
        Me.pnlPopAway.Location = New System.Drawing.Point(8, 112)
        Me.pnlPopAway.Name = "pnlPopAway"
        Me.pnlPopAway.Size = New System.Drawing.Size(184, 48)
        Me.pnlPopAway.TabIndex = 12
        '
        'pupOptAwayOff
        '
        Me.pupOptAwayOff.Checked = True
        Me.pupOptAwayOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupOptAwayOff.Location = New System.Drawing.Point(88, 24)
        Me.pupOptAwayOff.Name = "pupOptAwayOff"
        Me.pupOptAwayOff.Size = New System.Drawing.Size(96, 16)
        Me.pupOptAwayOff.TabIndex = 12
        Me.pupOptAwayOff.TabStop = True
        Me.pupOptAwayOff.Text = "Не всплывать"
        '
        'pupOptAwayOn
        '
        Me.pupOptAwayOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupOptAwayOn.Location = New System.Drawing.Point(0, 24)
        Me.pupOptAwayOn.Name = "pupOptAwayOn"
        Me.pupOptAwayOn.Size = New System.Drawing.Size(80, 16)
        Me.pupOptAwayOn.TabIndex = 11
        Me.pupOptAwayOn.Text = "Всплывать"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(0, 8)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(96, 16)
        Me.Label31.TabIndex = 10
        Me.Label31.Text = "Режим ""Ушел"""
        '
        'pnlpopPlay
        '
        Me.pnlpopPlay.Controls.Add(Me.pupOptGameOff)
        Me.pnlpopPlay.Controls.Add(Me.pupOptGameOn)
        Me.pnlpopPlay.Controls.Add(Me.Label26)
        Me.pnlpopPlay.Location = New System.Drawing.Point(8, 64)
        Me.pnlpopPlay.Name = "pnlpopPlay"
        Me.pnlpopPlay.Size = New System.Drawing.Size(184, 48)
        Me.pnlpopPlay.TabIndex = 11
        '
        'pupOptGameOff
        '
        Me.pupOptGameOff.Checked = True
        Me.pupOptGameOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupOptGameOff.Location = New System.Drawing.Point(88, 24)
        Me.pupOptGameOff.Name = "pupOptGameOff"
        Me.pupOptGameOff.Size = New System.Drawing.Size(96, 16)
        Me.pupOptGameOff.TabIndex = 9
        Me.pupOptGameOff.TabStop = True
        Me.pupOptGameOff.Text = "Не всплывать"
        '
        'pupOptGameOn
        '
        Me.pupOptGameOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupOptGameOn.Location = New System.Drawing.Point(0, 24)
        Me.pupOptGameOn.Name = "pupOptGameOn"
        Me.pupOptGameOn.Size = New System.Drawing.Size(80, 16)
        Me.pupOptGameOn.TabIndex = 8
        Me.pupOptGameOn.Text = "Всплывать"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(0, 8)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(96, 16)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "Режим ""Игровой"""
        '
        'pnlPopWork
        '
        Me.pnlPopWork.Controls.Add(Me.pupOptBusyOff)
        Me.pnlPopWork.Controls.Add(Me.pupOptBusyOn)
        Me.pnlPopWork.Controls.Add(Me.Label29)
        Me.pnlPopWork.Location = New System.Drawing.Point(8, 16)
        Me.pnlPopWork.Name = "pnlPopWork"
        Me.pnlPopWork.Size = New System.Drawing.Size(184, 40)
        Me.pnlPopWork.TabIndex = 10
        '
        'pupOptBusyOff
        '
        Me.pupOptBusyOff.Checked = True
        Me.pupOptBusyOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupOptBusyOff.Location = New System.Drawing.Point(88, 24)
        Me.pupOptBusyOff.Name = "pupOptBusyOff"
        Me.pupOptBusyOff.Size = New System.Drawing.Size(96, 16)
        Me.pupOptBusyOff.TabIndex = 6
        Me.pupOptBusyOff.TabStop = True
        Me.pupOptBusyOff.Text = "Не всплывать"
        '
        'pupOptBusyOn
        '
        Me.pupOptBusyOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupOptBusyOn.Location = New System.Drawing.Point(0, 24)
        Me.pupOptBusyOn.Name = "pupOptBusyOn"
        Me.pupOptBusyOn.Size = New System.Drawing.Size(80, 16)
        Me.pupOptBusyOn.TabIndex = 5
        Me.pupOptBusyOn.Text = "Всплывать"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(0, 8)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(96, 16)
        Me.Label29.TabIndex = 4
        Me.Label29.Text = "Режим ""Занят"""
        '
        'fraPopMain
        '
        Me.fraPopMain.Controls.Add(Me.pupChkEnterToPrivate)
        Me.fraPopMain.Controls.Add(Me.pupChkNewLine)
        Me.fraPopMain.Location = New System.Drawing.Point(0, 0)
        Me.fraPopMain.Name = "fraPopMain"
        Me.fraPopMain.Size = New System.Drawing.Size(224, 88)
        Me.fraPopMain.TabIndex = 55
        Me.fraPopMain.TabStop = False
        Me.fraPopMain.Text = "Главное окно"
        '
        'pupChkEnterToPrivate
        '
        Me.pupChkEnterToPrivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupChkEnterToPrivate.Location = New System.Drawing.Point(8, 56)
        Me.pupChkEnterToPrivate.Name = "pupChkEnterToPrivate"
        Me.pupChkEnterToPrivate.Size = New System.Drawing.Size(200, 16)
        Me.pupChkEnterToPrivate.TabIndex = 1
        Me.pupChkEnterToPrivate.Text = "Всплывать при входе в разговор"
        '
        'pupChkNewLine
        '
        Me.pupChkNewLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupChkNewLine.Location = New System.Drawing.Point(8, 16)
        Me.pupChkNewLine.Name = "pupChkNewLine"
        Me.pupChkNewLine.Size = New System.Drawing.Size(168, 32)
        Me.pupChkNewLine.TabIndex = 0
        Me.pupChkNewLine.Text = "Всплывать при появлении строки в чате"
        '
        'cmdDefPop
        '
        Me.cmdDefPop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDefPop.Location = New System.Drawing.Point(8, 224)
        Me.cmdDefPop.Name = "cmdDefPop"
        Me.cmdDefPop.Size = New System.Drawing.Size(432, 24)
        Me.cmdDefPop.TabIndex = 54
        Me.cmdDefPop.Text = "По умолчанию"
        '
        'tabLanguage
        '
        Me.tabLanguage.Controls.Add(Me.GroupBox2)
        Me.tabLanguage.Controls.Add(Me.GroupBox1)
        Me.tabLanguage.ImageIndex = 9
        Me.tabLanguage.Location = New System.Drawing.Point(4, 26)
        Me.tabLanguage.Name = "tabLanguage"
        Me.tabLanguage.Size = New System.Drawing.Size(445, 258)
        Me.tabLanguage.TabIndex = 4
        Me.tabLanguage.Text = "Язык"
        Me.tabLanguage.ToolTipText = "Выбор языка интерфейса"
        '
        'GroupBox2
        '
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Location = New System.Drawing.Point(269, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(176, 258)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Информация"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstLang)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 258)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Доступные языки"
        '
        'lstLang
        '
        Me.lstLang.Items.AddRange(New Object() {"Русский"})
        Me.lstLang.Location = New System.Drawing.Point(8, 16)
        Me.lstLang.Name = "lstLang"
        Me.lstLang.Size = New System.Drawing.Size(168, 238)
        Me.lstLang.TabIndex = 0
        '
        'tbcUsers
        '
        Me.tbcUsers.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcUsers.Controls.Add(Me.TabPage4)
        Me.tbcUsers.Controls.Add(Me.TabPage1)
        Me.tbcUsers.ImageList = Me.ImgLstOptions
        Me.tbcUsers.Location = New System.Drawing.Point(104, 16)
        Me.tbcUsers.Name = "tbcUsers"
        Me.tbcUsers.SelectedIndex = 0
        Me.tbcUsers.Size = New System.Drawing.Size(453, 288)
        Me.tbcUsers.TabIndex = 8
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.fraUserSettings)
        Me.TabPage4.ImageIndex = 5
        Me.TabPage4.Location = New System.Drawing.Point(4, 26)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(445, 258)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Настройка пользователя"
        '
        'fraUserSettings
        '
        Me.fraUserSettings.Controls.Add(Me.optSexNone)
        Me.fraUserSettings.Controls.Add(Me.optSexFemale)
        Me.fraUserSettings.Controls.Add(Me.optSexMale)
        Me.fraUserSettings.Controls.Add(Me.lblSex)
        Me.fraUserSettings.Controls.Add(Me.lblUsrComments)
        Me.fraUserSettings.Controls.Add(Me.usrTxtComment)
        Me.fraUserSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraUserSettings.Location = New System.Drawing.Point(0, 0)
        Me.fraUserSettings.Name = "fraUserSettings"
        Me.fraUserSettings.Size = New System.Drawing.Size(445, 258)
        Me.fraUserSettings.TabIndex = 3
        Me.fraUserSettings.TabStop = False
        Me.fraUserSettings.Text = "Параметры пользователей"
        '
        'optSexNone
        '
        Me.optSexNone.Enabled = False
        Me.optSexNone.Location = New System.Drawing.Point(48, 64)
        Me.optSexNone.Name = "optSexNone"
        Me.optSexNone.Size = New System.Drawing.Size(144, 16)
        Me.optSexNone.TabIndex = 13
        Me.optSexNone.Text = "Средний"
        '
        'optSexFemale
        '
        Me.optSexFemale.Enabled = False
        Me.optSexFemale.Location = New System.Drawing.Point(48, 40)
        Me.optSexFemale.Name = "optSexFemale"
        Me.optSexFemale.Size = New System.Drawing.Size(144, 24)
        Me.optSexFemale.TabIndex = 12
        Me.optSexFemale.Text = "Женский"
        '
        'optSexMale
        '
        Me.optSexMale.Checked = True
        Me.optSexMale.Location = New System.Drawing.Point(48, 24)
        Me.optSexMale.Name = "optSexMale"
        Me.optSexMale.Size = New System.Drawing.Size(144, 16)
        Me.optSexMale.TabIndex = 11
        Me.optSexMale.TabStop = True
        Me.optSexMale.Text = "Мужской"
        '
        'lblSex
        '
        Me.lblSex.AutoSize = True
        Me.lblSex.Location = New System.Drawing.Point(8, 24)
        Me.lblSex.Name = "lblSex"
        Me.lblSex.Size = New System.Drawing.Size(28, 16)
        Me.lblSex.TabIndex = 6
        Me.lblSex.Text = "Пол:"
        '
        'lblUsrComments
        '
        Me.lblUsrComments.AutoSize = True
        Me.lblUsrComments.Location = New System.Drawing.Point(16, 152)
        Me.lblUsrComments.Name = "lblUsrComments"
        Me.lblUsrComments.Size = New System.Drawing.Size(80, 16)
        Me.lblUsrComments.TabIndex = 3
        Me.lblUsrComments.Text = "Комментарий:"
        '
        'usrTxtComment
        '
        Me.usrTxtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.usrTxtComment.Location = New System.Drawing.Point(16, 168)
        Me.usrTxtComment.Multiline = True
        Me.usrTxtComment.Name = "usrTxtComment"
        Me.usrTxtComment.Size = New System.Drawing.Size(184, 80)
        Me.usrTxtComment.TabIndex = 5
        Me.usrTxtComment.Text = ""
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.fraLogs)
        Me.TabPage1.ImageIndex = 2
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(445, 258)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Протоколы"
        '
        'fraLogs
        '
        Me.fraLogs.Controls.Add(Me.chkUseLogCHL)
        Me.fraLogs.Controls.Add(Me.chkUseLogPriv)
        Me.fraLogs.Controls.Add(Me.chkUseLogMain)
        Me.fraLogs.Controls.Add(Me.chkUseLogMsg)
        Me.fraLogs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fraLogs.Location = New System.Drawing.Point(0, 0)
        Me.fraLogs.Name = "fraLogs"
        Me.fraLogs.Size = New System.Drawing.Size(445, 258)
        Me.fraLogs.TabIndex = 0
        Me.fraLogs.TabStop = False
        Me.fraLogs.Text = "Протоколы"
        '
        'chkUseLogCHL
        '
        Me.chkUseLogCHL.Enabled = False
        Me.chkUseLogCHL.Location = New System.Drawing.Point(8, 72)
        Me.chkUseLogCHL.Name = "chkUseLogCHL"
        Me.chkUseLogCHL.Size = New System.Drawing.Size(312, 16)
        Me.chkUseLogCHL.TabIndex = 3
        Me.chkUseLogCHL.Text = "Протоколирование каналов"
        '
        'chkUseLogPriv
        '
        Me.chkUseLogPriv.Enabled = False
        Me.chkUseLogPriv.Location = New System.Drawing.Point(8, 56)
        Me.chkUseLogPriv.Name = "chkUseLogPriv"
        Me.chkUseLogPriv.Size = New System.Drawing.Size(312, 16)
        Me.chkUseLogPriv.TabIndex = 2
        Me.chkUseLogPriv.Text = "Протоколрование приватных разговоров"
        '
        'chkUseLogMain
        '
        Me.chkUseLogMain.Enabled = False
        Me.chkUseLogMain.Location = New System.Drawing.Point(8, 40)
        Me.chkUseLogMain.Name = "chkUseLogMain"
        Me.chkUseLogMain.Size = New System.Drawing.Size(312, 16)
        Me.chkUseLogMain.TabIndex = 1
        Me.chkUseLogMain.Text = "Протоколирование основного канала"
        '
        'chkUseLogMsg
        '
        Me.chkUseLogMsg.Location = New System.Drawing.Point(8, 24)
        Me.chkUseLogMsg.Name = "chkUseLogMsg"
        Me.chkUseLogMsg.Size = New System.Drawing.Size(312, 16)
        Me.chkUseLogMsg.TabIndex = 0
        Me.chkUseLogMsg.Text = "Протоколирование сообщений"
        '
        'frmOptions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(562, 343)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.cmdAllDefault)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.tbcInterface)
        Me.Controls.Add(Me.tbcNet)
        Me.Controls.Add(Me.tbcSounds)
        Me.Controls.Add(Me.tbcUsers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmOptions"
        Me.Text = "Настройки"
        Me.Panel6.ResumeLayout(False)
        Me.pnlInterface.ResumeLayout(False)
        Me.pnlSounds.ResumeLayout(False)
        Me.pnlNet.ResumeLayout(False)
        Me.pnlUsers.ResumeLayout(False)
        Me.tbcNet.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.lanUDOnLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lanUDRefreshList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcSounds.ResumeLayout(False)
        Me.tabSounds.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.tbcInterface.ResumeLayout(False)
        Me.intcoltabColors.ResumeLayout(False)
        Me.colfraColors.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.tabInterface.ResumeLayout(False)
        Me.fraInterfTabs.ResumeLayout(False)
        Me.fraInterfShow.ResumeLayout(False)
        Me.fraInterfFont.ResumeLayout(False)
        Me.tabViewSymbols.ResumeLayout(False)
        Me.fraSymbOther.ResumeLayout(False)
        Me.fraSymbShowSymb.ResumeLayout(False)
        Me.fraSymbSymb.ResumeLayout(False)
        Me.tabPopupOptions.ResumeLayout(False)
        Me.fraPopMsg.ResumeLayout(False)
        Me.pnlPopAway.ResumeLayout(False)
        Me.pnlpopPlay.ResumeLayout(False)
        Me.pnlPopWork.ResumeLayout(False)
        Me.fraPopMain.ResumeLayout(False)
        Me.tabLanguage.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.tbcUsers.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.fraUserSettings.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.fraLogs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmOptions
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmOptions
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmOptions()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmOptions)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    '    Dim FontNam As String
    '    Dim FontSiz As String
    '    Dim HKAlt As Boolean
    '    Dim HKShift As Boolean
    '    Dim HKControl As Boolean
    '    Dim HKey As Integer

    '    Private Sub pnlUsers_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlUsers.MouseMove
    '        If pnlUsers.BorderStyle = BorderStyle.None Then
    '            lblUsers.Font = New Font(lblUsers.Font.Name, lblUsers.Font.Size, FontStyle.Bold)
    '        End If
    '    End Sub

    '    Private Sub pnlUsers_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlUsers.MouseLeave
    '        If pnlUsers.BorderStyle = BorderStyle.None Then
    '            lblUsers.Font = New Font(lblUsers.Font.Name, lblUsers.Font.Size, FontStyle.Regular)
    '        End If
    '    End Sub

    '    Private Sub pnlUsers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlUsers.Click
    '        lblUsers.Font = New Font(lblUsers.Font.Name, lblUsers.Font.Size, FontStyle.Bold)
    '        pnlUsers.BorderStyle = BorderStyle.FixedSingle

    '        lblNet.Font = New Font(lblNet.Font.Name, lblNet.Font.Size, FontStyle.Regular)
    '        pnlNet.BorderStyle = BorderStyle.None

    '        lblInterface.Font = New Font(lblInterface.Font.Name, lblInterface.Font.Size, FontStyle.Regular)
    '        pnlInterface.BorderStyle = BorderStyle.None

    '        lblSounds.Font = New Font(lblSounds.Font.Name, lblSounds.Font.Size, FontStyle.Regular)
    '        pnlSounds.BorderStyle = BorderStyle.None
    '        tbcUsers.BringToFront()
    '    End Sub


    '    Private Sub pnlNet_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlNet.MouseLeave
    '        If pnlNet.BorderStyle = BorderStyle.None Then
    '            lblNet.Font = New Font(lblNet.Font.Name, lblNet.Font.Size, FontStyle.Regular)
    '        End If
    '    End Sub

    '    Private Sub pnlNet_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlNet.MouseMove
    '        If pnlNet.BorderStyle = BorderStyle.None Then
    '            lblNet.Font = New Font(lblNet.Font.Name, lblNet.Font.Size, FontStyle.Bold)
    '        End If
    '    End Sub

    '    Private Sub pnlNet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlNet.Click
    '        lblUsers.Font = New Font(lblUsers.Font.Name, lblUsers.Font.Size, FontStyle.Regular)
    '        pnlUsers.BorderStyle = BorderStyle.None

    '        lblNet.Font = New Font(lblNet.Font.Name, lblNet.Font.Size, FontStyle.Bold)
    '        pnlNet.BorderStyle = BorderStyle.FixedSingle
    '        lblInterface.Font = New Font(lblInterface.Font.Name, lblInterface.Font.Size, FontStyle.Regular)
    '        pnlInterface.BorderStyle = BorderStyle.None
    '        lblSounds.Font = New Font(lblSounds.Font.Name, lblSounds.Font.Size, FontStyle.Regular)
    '        pnlSounds.BorderStyle = BorderStyle.None
    '        tbcNet.BringToFront()
    '    End Sub

    '    Private Sub pnlSounds_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlSounds.Paint

    '    End Sub

    '    Private Sub pnlSounds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSounds.Click
    '        lblUsers.Font = New Font(lblUsers.Font.Name, lblUsers.Font.Size, FontStyle.Regular)
    '        pnlUsers.BorderStyle = BorderStyle.None

    '        lblNet.Font = New Font(lblNet.Font.Name, lblNet.Font.Size, FontStyle.Regular)
    '        pnlNet.BorderStyle = BorderStyle.None
    '        lblInterface.Font = New Font(lblInterface.Font.Name, lblInterface.Font.Size, FontStyle.Regular)
    '        pnlInterface.BorderStyle = BorderStyle.None
    '        lblSounds.Font = New Font(lblSounds.Font.Name, lblSounds.Font.Size, FontStyle.Bold)
    '        pnlSounds.BorderStyle = BorderStyle.FixedSingle
    '        tbcSounds.BringToFront()
    '    End Sub

    '    Private Sub pnlSounds_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSounds.MouseMove
    '        If pnlSounds.BorderStyle = BorderStyle.None Then
    '            lblSounds.Font = New Font(lblSounds.Font.Name, lblSounds.Font.Size, FontStyle.Bold)
    '        End If
    '    End Sub

    '    Private Sub pnlSounds_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSounds.MouseLeave
    '        If pnlSounds.BorderStyle = BorderStyle.None Then
    '            lblSounds.Font = New Font(lblSounds.Font.Name, lblSounds.Font.Size, FontStyle.Regular)
    '        End If
    '    End Sub

    '    Private Sub pnlInterface_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInterface.Click
    '        lblUsers.Font = New Font(lblUsers.Font.Name, lblUsers.Font.Size, FontStyle.Regular)
    '        pnlUsers.BorderStyle = BorderStyle.None

    '        lblNet.Font = New Font(lblNet.Font.Name, lblNet.Font.Size, FontStyle.Regular)
    '        pnlNet.BorderStyle = BorderStyle.None
    '        lblInterface.Font = New Font(lblInterface.Font.Name, lblInterface.Font.Size, FontStyle.Bold)
    '        pnlInterface.BorderStyle = BorderStyle.FixedSingle
    '        lblSounds.Font = New Font(lblSounds.Font.Name, lblSounds.Font.Size, FontStyle.Regular)
    '        pnlSounds.BorderStyle = BorderStyle.None
    '        tbcInterface.BringToFront()
    '    End Sub

    '    Private Sub pnlInterface_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlInterface.MouseMove
    '        If pnlInterface.BorderStyle = BorderStyle.None Then
    '            lblInterface.Font = New Font(lblInterface.Font.Name, lblInterface.Font.Size, FontStyle.Bold)
    '        End If
    '    End Sub

    '    Private Sub pnlInterface_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInterface.MouseLeave
    '        If pnlInterface.BorderStyle = BorderStyle.None Then
    '            lblInterface.Font = New Font(lblInterface.Font.Name, lblInterface.Font.Size, FontStyle.Regular)
    '        End If

    '    End Sub

    '    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        Dim Tmp As Integer
    '        Dim TmpStr As String = ""
    '        lanTxtBroadcastAddress.Text = DC_NetworkSettings.Host
    '        lanTxtMulticastAddress.Text = DC_NetworkSettings.HostMCast
    '        lanUDOnLine.Text = DC_NetworkSettings.NetPSend / 1000
    '        lanUDRefreshList.Text = DC_NetworkSettings.NetLSUpd / 1000
    '        lanTxtPort.Text = DC_NetworkSettings.Port
    '        lanTxtIP.Text = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString
    '        Me.lanUDTTL.Text = DC_NetworkSettings.TTL

    '        If DC_NetworkSettings.MultiCast = True Then
    '            lanOptMulticast.Checked = True
    '            lanOptBroadcast.Checked = False
    '        Else
    '            lanOptMulticast.Checked = False
    '            lanOptBroadcast.Checked = True
    '        End If
    '        ' Звуки
    '        sndTxtEnterToLan.Text = UNI_SoundSettings.Logon
    '        sndTxtExitToLan.Text = UNI_SoundSettings.LogOff
    '        sndTxtBeginToTalk.Text = UNI_SoundSettings.StartPriv
    '        sndTxtEndToTalk.Text = UNI_SoundSettings.ClosePriv
    '        sndTxtLineToChat.Text = UNI_SoundSettings.ChatLine
    '        sndTxtReceiveMessage.Text = UNI_SoundSettings.ReceiveMessage
    '        sndTxtSendMessage.Text = UNI_SoundSettings.ReceiveMessage
    '        sndTxtMultipleMessage.Text = UNI_SoundSettings.MassMsg
    '        sndTxtChangeTopic.Text = UNI_SoundSettings.ChTopic
    '        sndTxtChangeName.Text = UNI_SoundSettings.ChNick
    '        sndTxtStrMe.Text = UNI_SoundSettings.MeLine
    '        sndTxtSignal.Text = UNI_SoundSettings.UsrBeep
    '        sndTxtRemoteExec.Text = UNI_SoundSettings.RemoteExec
    '        sndTxtReceiveScreenShot.Text = UNI_SoundSettings.ClosePriv
    '        sndTxtAddLink.Text = UNI_SoundSettings.StartPriv
    '        sndTxtJoinChannel.Text = UNI_SoundSettings.LogOnChl
    '        sndTxtLeaveChannel.Text = UNI_SoundSettings.LogOffChl
    '        ' Пользователь
    '        usrTxtComment.Text = UNI_UserSettings.Comment

    '        ' Протоколы
    '        chkUseLogMsg.Checked = Declares.DC_ChatMsgArchive.UseMsgArc
    '        chkUseLogMain.Checked = Declares.DC_ChatMsgArchive.UseChtArc
    '        chkUseLogCHL.Checked = Declares.DC_ChatMsgArchive.UseChlArc
    '        chkUseLogPriv.Checked = Declares.DC_ChatMsgArchive.UsePriArc
    '        ' Для интерфейса, цвета
    '        colCmd1.BackColor = UNI_ColorSettings.MyTextColor
    '        colCmd2.BackColor = UNI_ColorSettings.OurTextColor
    '        colCmd3.BackColor = UNI_ColorSettings.LogOnColor
    '        colCmd4.BackColor = UNI_ColorSettings.LogOffColor
    '        colCmd5.BackColor = UNI_ColorSettings.ChangeName
    '        colCmd6.BackColor = UNI_ColorSettings.ChangeTopic
    '        colCmd7.BackColor = UNI_ColorSettings.Welcome
    '        colCmd8.BackColor = UNI_ColorSettings.RemoteExec
    '        colCmd9.BackColor = UNI_ColorSettings.MsgSendColor
    '        colCmd10.BackColor = UNI_ColorSettings.MsgReceiveColor
    '        colCmd11.BackColor = UNI_ColorSettings.BackChatColor
    '        colCmd12.BackColor = UNI_ColorSettings.MeStr
    '        colCmd13.BackColor = UNI_ColorSettings.MultiMsg
    '        colCmd14.BackColor = UNI_ColorSettings.WndText
    '        colCmd15.BackColor = UNI_ColorSettings.GetScreenShot
    '        colCmd16.BackColor = UNI_ColorSettings.ModeChg

    '        ' Внешний вид
    '        If UNI_InterfaceSettings.Tabs = 1 Then
    '            intOptTab.Checked = True
    '        ElseIf UNI_InterfaceSettings.Tabs = 2 Then
    '            intOptButtons.Checked = True
    '        Else
    '            intOptFlatButtons.Checked = True
    '        End If
    '        FontNam = UNI_InterfaceSettings.ChatFont
    '        FontSiz = UNI_InterfaceSettings.ChatFontSize

    '        chkUseRTF.Checked = UNI_InterfaceSettings.UseFormat

    '        intChkTopic.Checked = UNI_InterfaceSettings.ShowTopicBar
    '        'intChkUsers.Checked =  UNI_InterfaceSettings.ShowUsrLst
    '        intChkName.Checked = UNI_InterfaceSettings.ShowUsrNameBar
    '        smbTxtLeftUsers.Text = UNI_InterfaceSettings.NickLS
    '        smbTxtRightUsers.Text = UNI_InterfaceSettings.NickRS
    '        smbTxtLeftTime.Text = UNI_InterfaceSettings.TimeLS
    '        smbTxtRightTime.Text = UNI_InterfaceSettings.TimeRS
    '        Me.smbChkSystemMessage.Checked = UNI_InterfaceSettings.ShowTimeMsg

    '        pupOptBusyOn.Checked = UNI_InterfaceSettings.PupUpMsgBusy
    '        pupOptAwayOn.Checked = UNI_InterfaceSettings.PupUpMsgAway
    '        pupOptGameOn.Checked = UNI_InterfaceSettings.PupUpMsgGame
    '        pupChkEnterToPrivate.Checked = UNI_InterfaceSettings.PopUpLogOn
    '        pupChkNewLine.Checked = UNI_InterfaceSettings.PopUpLineChat
    '        CheckBox15.Checked = UNI_InterfaceSettings.RunMin
    '        pupChkHotKey.Checked = UNI_InterfaceSettings.HKeyUse
    '        HKAlt = UNI_InterfaceSettings.HKAlt
    '        HKShift = UNI_InterfaceSettings.HKShift
    '        HKControl = UNI_InterfaceSettings.HKCtrl
    '        HKey = UNI_InterfaceSettings.HKKey
    '        pupTxtHotKey.Text = UNI_InterfaceSettings.HKeyString



    '    End Sub

    '    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    '        Me.Close()
    '    End Sub

    '    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
    '        Dim Tmp As Integer

    '        DC_NetworkSettings.MultiCast = Not lanOptBroadcast.Checked
    '        DC_NetworkSettings.Host = lanTxtBroadcastAddress.Text
    '        DC_NetworkSettings.HostMCast = lanTxtMulticastAddress.Text
    '        DC_NetworkSettings.NetPSend = lanUDOnLine.Text * 1000
    '        DC_NetworkSettings.NetLSUpd = lanUDRefreshList.Text * 1000
    '        DC_NetworkSettings.Port = lanTxtPort.Text

    '        UNI_SoundSettings.Logon = sndTxtEnterToLan.Text
    '        UNI_SoundSettings.LogOff = sndTxtExitToLan.Text
    '        UNI_SoundSettings.StartPriv = sndTxtBeginToTalk.Text
    '        UNI_SoundSettings.ClosePriv = sndTxtEndToTalk.Text
    '        UNI_SoundSettings.ChatLine = sndTxtLineToChat.Text
    '        UNI_SoundSettings.ReceiveMessage = sndTxtReceiveMessage.Text
    '        UNI_SoundSettings.ReceiveMessage = sndTxtSendMessage.Text
    '        UNI_SoundSettings.MassMsg = sndTxtMultipleMessage.Text
    '        UNI_SoundSettings.ChTopic = sndTxtChangeTopic.Text
    '        UNI_SoundSettings.ChNick = sndTxtChangeName.Text
    '        UNI_SoundSettings.MeLine = sndTxtStrMe.Text
    '        UNI_SoundSettings.UsrBeep = sndTxtSignal.Text
    '        UNI_SoundSettings.RemoteExec = sndTxtRemoteExec.Text
    '        UNI_SoundSettings.ClosePriv = sndTxtReceiveScreenShot.Text
    '        UNI_SoundSettings.StartPriv = sndTxtAddLink.Text
    '        UNI_SoundSettings.LogOnChl = sndTxtJoinChannel.Text
    '        UNI_SoundSettings.LogOffChl = sndTxtLeaveChannel.Text

    '        ' Узеры


    '        UNI_UserSettings.Comment = usrTxtComment.Text
    '        ' Протоколы
    '        Declares.DC_ChatMsgArchive.UseMsgArc = chkUseLogMsg.Checked
    '        Declares.DC_ChatMsgArchive.UseChtArc = chkUseLogMain.Checked
    '        Declares.DC_ChatMsgArchive.UseChlArc = chkUseLogCHL.Checked
    '        Declares.DC_ChatMsgArchive.UsePriArc = chkUseLogPriv.Checked

    '        usrTxtComment.Text = UNI_UserSettings.Comment
    '        ' Интерфейс
    '        ' Для интерфейса, цвета
    '        UNI_ColorSettings.MyTextColor = colCmd1.BackColor
    '        UNI_ColorSettings.OurTextColor = colCmd2.BackColor
    '        UNI_ColorSettings.LogOnColor = colCmd3.BackColor
    '        UNI_ColorSettings.LogOffColor = colCmd4.BackColor
    '        UNI_ColorSettings.ChangeName = colCmd5.BackColor
    '        UNI_ColorSettings.ChangeTopic = colCmd6.BackColor
    '        UNI_ColorSettings.Welcome = colCmd7.BackColor
    '        UNI_ColorSettings.RemoteExec = colCmd8.BackColor
    '        UNI_ColorSettings.MsgSendColor = colCmd9.BackColor
    '        UNI_ColorSettings.MsgReceiveColor = colCmd10.BackColor
    '        UNI_ColorSettings.BackChatColor = colCmd11.BackColor
    '        UNI_ColorSettings.MeStr = colCmd12.BackColor
    '        UNI_ColorSettings.MultiMsg = colCmd13.BackColor
    '        UNI_ColorSettings.WndText = colCmd14.BackColor
    '        UNI_ColorSettings.GetScreenShot = colCmd15.BackColor
    '        UNI_ColorSettings.ModeChg = colCmd16.BackColor

    '        ' Внешний вид
    '        If intOptTab.Checked = True Then UNI_InterfaceSettings.Tabs = 1
    '        If intOptButtons.Checked = True Then UNI_InterfaceSettings.Tabs = 2
    '        If intOptFlatButtons.Checked = True Then UNI_InterfaceSettings.Tabs = 3

    '        UNI_InterfaceSettings.ChatFont = FontNam
    '        UNI_InterfaceSettings.ChatFontSize = FontSiz

    '        UNI_InterfaceSettings.UseFormat = chkUseRTF.Checked

    '        UNI_InterfaceSettings.ShowTopicBar = intChkTopic.Checked
    '        'InterfaceSettings.ShowUsrLst = intChkUsers.Checked
    '        UNI_InterfaceSettings.ShowUsrNameBar = intChkName.Checked
    '        UNI_InterfaceSettings.NickLS = smbTxtLeftUsers.Text
    '        UNI_InterfaceSettings.NickRS = smbTxtRightUsers.Text
    '        UNI_InterfaceSettings.TimeLS = smbTxtLeftTime.Text
    '        UNI_InterfaceSettings.TimeRS = smbTxtRightTime.Text
    '        UNI_InterfaceSettings.ShowTimeMsg = Me.smbChkSystemMessage.Checked

    '        UNI_InterfaceSettings.PupUpMsgBusy = pupOptBusyOn.Checked
    '        UNI_InterfaceSettings.PupUpMsgAway = pupOptAwayOn.Checked
    '        UNI_InterfaceSettings.PupUpMsgGame = pupOptGameOn.Checked

    '        UNI_InterfaceSettings.PopUpLineChat = pupChkNewLine.Checked
    '        UNI_InterfaceSettings.PopUpLogOn = Me.pupChkEnterToPrivate.Checked
    '        UNI_InterfaceSettings.RunMin = CheckBox15.Checked
    '        UNI_InterfaceSettings.HKeyUse = pupChkHotKey.Checked
    '        UNI_InterfaceSettings.HKAlt = HKAlt
    '        UNI_InterfaceSettings.HKCtrl = HKControl
    '        UNI_InterfaceSettings.HKShift = HKShift
    '        UNI_InterfaceSettings.HKKey = HKey
    '        UNI_InterfaceSettings.HKeyString = pupTxtHotKey.Text

    '        Settings2.SaveSettings(UNI_UserSettings.Profile)
    '        Me.Close()
    '    End Sub




    '    Private Sub lanOptBroadcast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lanOptBroadcast.CheckedChanged
    '        Select Case lanOptBroadcast.Checked
    '            Case True
    '                lanTxtMulticastAddress.Enabled = False
    '                lanTxtBroadcastAddress.Enabled = True
    '                lanUDTTL.Enabled = False
    '            Case False
    '                lanTxtMulticastAddress.Enabled = True
    '                lanTxtBroadcastAddress.Enabled = False
    '                lanUDTTL.Enabled = True
    '        End Select

    '    End Sub

    '    Private Sub intCmdFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles intCmdFont.Click
    '        fntDChat.Font = New Font(UNI_InterfaceSettings.ChatFont, UNI_InterfaceSettings.ChatFontSize)
    '        fntDChat.ShowDialog()
    '        FontNam = fntDChat.Font.Name
    '        FontSiz = fntDChat.Font.Size
    '    End Sub

    '    Private Sub colCmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colCmd1.Click, colCmd10.Click, colCmd11.Click, colCmd12.Click, colCmd13.Click, colCmd14.Click, colCmd15.Click, colCmd16.Click, colCmd2.Click, colCmd3.Click, colCmd4.Click, colCmd5.Click, colCmd6.Click, colCmd7.Click, colCmd8.Click, colCmd9.Click
    '        clrDChat.Color = sender.backcolor
    '        clrDChat.ShowDialog()
    '        sender.backcolor = clrDChat.Color
    '    End Sub


    '    Private Sub pupTxtHotKey_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles pupTxtHotKey.KeyDown
    '        pupTxtHotKey.Text = ""
    '        If e.Alt = False And e.Control = False And e.Shift = False Then GoTo Ex
    '        If e.Alt = True Then pupTxtHotKey.Text = "Alt + "
    '        If e.Control = True Then pupTxtHotKey.Text = pupTxtHotKey.Text & "Ctrl + "
    '        If e.Shift = True Then pupTxtHotKey.Text = pupTxtHotKey.Text & "Shift + "
    '        pupTxtHotKey.Text = pupTxtHotKey.Text & Chr(e.KeyValue)
    '        HKAlt = e.Alt
    '        HKShift = e.Shift
    '        HKControl = e.Control
    '        HKey = e.KeyCode
    'Ex:
    '        e.Handled = True
    '        e = New System.Windows.Forms.KeyEventArgs(Keys.None)
    '    End Sub


    '    Private Sub cmdDefShowSymb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefShowSymb.Click
    '        smbTxtLeftUsers.Text = "<"
    '        smbTxtRightUsers.Text = ">"
    '        smbTxtLeftTime.Text = "["
    '        smbTxtRightTime.Text = "]"

    '    End Sub

    '    Private Sub cmdDefPop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefPop.Click
    '        pupChkNewLine.Checked = False
    '        pupChkEnterToPrivate.Checked = False
    '        Me.pupOptBusyOff.Checked = True
    '        Me.pupOptAwayOn.Checked = True
    '        Me.pupOptGameOff.Checked = True
    '        CheckBox15.Checked = True

    '    End Sub

    '    Private Sub cmdDefInterf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefInterf.Click
    '        Dim A As New TextBox()
    '        Me.intChkName.Checked = True
    '        Me.intChkTopic.Checked = True
    '        'Me.intChkUsers.Checked = True
    '        Me.intOptTab.Checked = True
    '        FontNam = A.Font.Name
    '        FontSiz = A.Font.Size
    '        A.Dispose()
    '    End Sub

    '    Private Sub sndCmdDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sndCmdDefault.Click
    '        Me.sndChkAway.Checked = True
    '        Me.sndChkBusy.Checked = False
    '        Me.sndChkOnSound.Checked = True
    '    End Sub

    '    Private Sub tbcUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcUsers.SelectedIndexChanged

    '    End Sub

    '    Private Sub lanCmdDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lanCmdDefault.Click
    '        Me.lanOptMulticast.Checked = True
    '        Me.lanTxtMulticastAddress.Text = "224.0.0.1"
    '        Me.lanTxtBroadcastAddress.Text = "255.255.255.255"
    '        Me.lanTxtPort.Text = "3755"
    '        Me.lanUDOnLine.Text = "5"
    '        Me.lanUDRefreshList.Text = "6"
    '        Me.lanUDTTL.Text = "5"
    '    End Sub

    '    Private Sub cmdAllDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllDefault.Click
    '        Me.cmdDefInterf_Click(Me, New System.EventArgs())
    '        Me.cmdDefPop_Click(Me, New System.EventArgs())
    '        Me.cmdDefShowSymb_Click(Me, New System.EventArgs())
    '        Me.lanCmdDefault_Click(Me, New System.EventArgs())
    '    End Sub


    '    Private Sub cmdSnd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSnd1.Click, cmdSnd10.Click, cmdSnd11.Click, cmdSnd12.Click, cmdSnd13.Click, cmdSnd14.Click, cmdSnd15.Click, cmdSnd16.Click, cmdSnd17.Click, cmdSnd2.Click, cmdSnd3.Click, cmdSnd4.Click, cmdSnd5.Click, cmdSnd6.Click, cmdSnd7.Click, cmdSnd8.Click, cmdSnd9.Click
    '        opfDChat.Filter = "Wave *.wav|*.wav|All Files|*.*"
    '        Select Case LCase(sender.name)
    '            Case "cmdsnd1"
    '                opfDChat.FileName = Me.sndTxtEnterToLan.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtEnterToLan.Text = opfDChat.FileName
    '            Case "cmdsnd2"
    '                opfDChat.FileName = Me.sndTxtExitToLan.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtExitToLan.Text = opfDChat.FileName
    '            Case "cmdsnd3"
    '                opfDChat.FileName = Me.sndTxtBeginToTalk.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtBeginToTalk.Text = opfDChat.FileName
    '            Case "cmdsnd4"
    '                opfDChat.FileName = Me.sndTxtEndToTalk.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtEndToTalk.Text = opfDChat.FileName
    '            Case "cmdsnd5"
    '                opfDChat.FileName = Me.sndTxtLineToChat.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtLineToChat.Text = opfDChat.FileName
    '            Case "cmdsnd6"
    '                opfDChat.FileName = Me.sndTxtReceiveMessage.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtReceiveMessage.Text = opfDChat.FileName
    '            Case "cmdsnd7"
    '                opfDChat.FileName = Me.sndTxtSendMessage.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtSendMessage.Text = opfDChat.FileName
    '            Case "cmdsnd8"
    '                opfDChat.FileName = Me.sndTxtMultipleMessage.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtMultipleMessage.Text = opfDChat.FileName
    '            Case "cmdsnd9"
    '                opfDChat.FileName = Me.sndTxtChangeTopic.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtChangeTopic.Text = opfDChat.FileName
    '            Case "cmdsnd10"
    '                opfDChat.FileName = Me.sndTxtChangeName.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtChangeName.Text = opfDChat.FileName
    '            Case "cmdsnd11"
    '                opfDChat.FileName = Me.sndTxtStrMe.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtStrMe.Text = opfDChat.FileName
    '            Case "cmdsnd12"
    '                opfDChat.FileName = Me.sndTxtSignal.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtSignal.Text = opfDChat.FileName
    '            Case "cmdsnd13"
    '                opfDChat.FileName = Me.sndTxtRemoteExec.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtRemoteExec.Text = opfDChat.FileName
    '            Case "cmdsnd14"
    '                opfDChat.FileName = Me.sndTxtReceiveScreenShot.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtReceiveScreenShot.Text = opfDChat.FileName
    '            Case "cmdsnd15"
    '                opfDChat.FileName = Me.sndTxtAddLink.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtAddLink.Text = opfDChat.FileName
    '            Case "cmdsnd16"
    '                opfDChat.FileName = Me.sndTxtJoinChannel.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtJoinChannel.Text = opfDChat.FileName
    '            Case "cmdsnd17"
    '                opfDChat.FileName = Me.sndTxtLeaveChannel.Text
    '                opfDChat.ShowDialog()
    '                If opfDChat.FileName = "" Then Exit Sub
    '                Me.sndTxtLeaveChannel.Text = opfDChat.FileName
    '        End Select
    '    End Sub

    '    Private Sub pupTxtHotKey_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pupTxtHotKey.TextChanged

    '    End Sub

    '    Private Sub tbcInterface_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcInterface.SelectedIndexChanged

    'End Sub
End Class
