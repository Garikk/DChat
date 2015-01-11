' DZFS.NET 2003
' DChat Project
' IRC Control Module
'------------------------------------------------------------------------------------
' Programmed by Garikk
' IRC Plugin for DChat (IRChat) (IRC RFC2812)
' V1 Plugin Type
'------------------------------------------------------------------------------------
Imports System.Windows.Forms
Imports System.Drawing
Imports UNI_Plugin.UNI_DChat
Imports UNI_Plugin.UNI_DChat.DCB_V1

#Region " Plugin Initialisation "
Public Class DCB_PLUGININFO
    Implements DCB_Universal.DCB_UNI_iPluginGetInfo

    Public ReadOnly Property DCB_GetInfo() As UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_PluginInfo Implements UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_iPluginGetInfo.DCB_GetInfo
        Get
            IRC_Int_InitInfo()
            Return IRC_INF
        End Get
    End Property
End Class

Public Class DCB_Plugin
    ' Связь с базой DChat (UNI V1)
    Implements DCB_Universal.DCB_iPlugin
    Public Sub DCB_PLUGIN_SETPID(ByVal intPID As Integer)
        IRC_Int_InitInfo()
        IRC_INF.INF_PMGR_PID = intPID
        IRC_INF.INF_CMDEXEC &= intPID
    End Sub
    Public Sub DCB_PLUGIN_Init(ByRef dcb_CHLCTL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl, ByRef dcb_USRCTL As DCB_Channels2.DCB_iUsersControl, ByRef DCGUI As DCB_Base.DCB_GUI_Control, ByRef NETWORK As DCB_Base.DCB_NetSocket, ByRef dcb_DCSE As DCB_Base.DCB_DCSE) Implements DCB_Universal.DCB_iPlugin.DCB_DCSE_V1_c_Plugininit
        IRC_Settings.Debug.IRC_DBG_SHOWSERVRAW = False
        IRC_Settings.Debug.IRC_DBG_SHOWSENDRAW = False
        IRC_Settings.Debug.IRC_DBG_MODULES = False
        If IRC_INF.INF_CMDEXEC = "" Then IRC_Int_InitInfo()

        IRC_CONS_CHLID = IRC_INF.INF_CMDEXEC & "IRC console"
        IRC_CONS_TalkInChl = IRC_INF.INF_CMDEXEC & "irc"

        IRC_LoadSettings()
        DCSE = dcb_DCSE
        ' Проверка требуемых плагинов
        IRC_CheckReqPlugins()
        ' Управление сокетами
        'IRC_Socket = CType(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/etcps etcps_getetcpsocket"), UNI_Plugin.UNI_Extended.UNI_iETCPS)
        DC2Conv = New IRCTextManager("/dc2conv")

        IRC_Settings.IRCMode.Autoset = False

        IRC_InitColors(IRC_Settings.IRCColors.ColorScheme)
        'Stop
        CreateMainIRCMenu()
        IRC_INTERF_CreateFCMenu()
        ' Создание объектов управления
        ' Управление базой каналов и пользователей
        CHLCtl = dcb_CHLCTL
        USRCtl = dcb_USRCTL
        ' Управление интерфейсом
        DCCtl = DCGUI
         ' Запрашиваем шрифт
        Dim FNT As Font = CType(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/baseobj dcb_getfontinfo"), Font)
        InterfaceCTLS.DefInstance.lstFavoriteCHLs.BackColor = CType(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/baseobj dcb_getbackwndcolor"), Color)
        IRC_Settings.IRCFont = FNT.Name
        IRC_Settings.IRCFontSize = CInt(FNT.Size)
        ' Создание консоли плагина
        ChlMainIRC = CHLCtl.DCB_AddNewChannel(New DCB_Channels2.DCB_NewChannelDataPack(IRC_INF, IRC_CONS_CHLID, "IRC Console", DCB_Channels2.DCB_Channel_Types.CHL_PluginConsole, DCCtl.DCB_GetTabControl, InterfaceCTLS.DefInstance.pnlLists, Nothing, 3))
        ChlMainIRC.CHLMainMenu = IRC_Interface.mnuMainIRCMenu

        ChlMainIRC.CHLTOPIC = IRC_INF.INF_NAME & " Version " & IRC_INF.INF_VER.ToString
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, IRC_INF.INF_NAME & " Ver." & IRC_INF.INF_VER.ToString, DCB_Base.DCB_IRCColors.Purple)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Welcome to DChat-IRC Client :)", DCB_Base.DCB_IRCColors.Blue)

        ' Информация об режимах отладки
        If IRC_Settings.Debug.IRC_DBG_SHOWSERVRAW = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " irc_printincon <debug> irc_dbg_showservraw is enabled")
        If IRC_Settings.Debug.IRC_DBG_SHOWSENDRAW = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " irc_printincon <debug> irc_dbg_showsendraw is enabled")
        If IRC_Settings.Debug.IRC_DBG_MODULES = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " irc_printincon <debug> irc_dbg_modules is enabled")
    End Sub

    Friend Function FileToString(ByVal FilePath As String) As String
        Dim Tmp As String
        Dim A As System.IO.StreamReader
        A = New System.IO.StreamReader(FilePath, System.Text.Encoding.Default)
        Tmp = A.ReadToEnd()
        A.Close()
        Return Tmp
    End Function
    Public Function DCB_PLUGIN_Cmd(ByVal PID As String, ByVal Cmd As String) As Object Implements DCB_Universal.DCB_iPlugin.DCB_DCSE_Exec
        ' Выполнение комманд пришедших с базы
        If Cmd.StartsWith("DCB_SETALTPID") Then DCB_PLUGIN_SETPID(CInt(Cmd.Split()(1))) : Exit Function
        Return IRC_CMD_PROCESS(Cmd)
    End Function
    'Public Function DCB_PLUGIN_CMDFO(ByVal CMD As String) As Object Implements DCB_Plugins.DCB_iPlugin.DCB_CMDFO
    '    Return IRC_CMD_FUNC(CMD)
    'End Function
    Public ReadOnly Property DCB_GetInfo() As DCB_Universal.DCB_UNI_PluginInfo Implements DCB_Universal.DCB_iPlugin.uni_GetInfo
        Get
            Return IRC_INF
        End Get
    End Property

    Private Sub IRC_CheckReqPlugins()
        Dim pl As Hashtable = CType(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "dcb_pmgr_getpluginshashtable"), Hashtable)
        Dim R As String
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base printincon <IRC Init>Checking plugins")
        If pl.ContainsKey("/etcps") Then R = "Ok" Else R = "Not found!!"
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base printincon <IRC Init>ETCPS...........Using DCB_Base " & R)
        If pl.ContainsKey("/dc2conv") Then R = "Ok" Else R = "Not found!!"
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base printincon <IRC Init>IRC2RTF........." & R)
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base printincon <IRC Init>Rus2Lat.........Using DCB_Base module")

    End Sub
End Class

#End Region

'DateTime.op_Addition(New Date(1970, 1, 1, 0, 0, 0), TimeSpan.FromSeconds(1081066424)).ToString

Module IRC_BASE
    Public Const IRC_DESC As String = "IRC Client for DChat, ver. 0.9.47.3, DZFS.net 2005, Created by Garikk"
    Public Const IRC_VER As String = "0.9.47.3"
#Region " Сеть "
    Dim IRC_NET_Buffer As String
    Dim LastConnect As String
    'Сетевая часть IRC

    Private Sub IRC_NET_CreateSocket()
        ' CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "IRC_NET_CreateSocket", DCB_Base.DCB_IRCColors.Blue)

        IRC_Socket = Nothing
        IRC_Socket = CType(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base base_getnetsocket"), DCB_Base.DCB_NetSocket)
        AddHandler IRC_Socket.DCB_NET_ReciveData, AddressOf IRC_NET_DataDecoder_Level1
        AddHandler IRC_Socket.DCB_NET_Error, AddressOf IRC_NetError
        IRC_Socket.DCB_NET_NetInit(IRC_INF)

    End Sub
    Private Sub IRC_NET_DisposeSocket()
        RemoveHandler IRC_Socket.DCB_NET_ReciveData, AddressOf IRC_NET_DataDecoder_Level1
        IRC_Socket.DCB_NET_Disconnect()
        IRC_Socket = Nothing
    End Sub
    Friend Sub IRC_NET_Connect(ByVal URL As String, ByVal Port As Integer)
        If Not IRC_Socket Is Nothing Then
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_netstop")
            ' CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<ETCPS><NETERROR> Подключение уже создано!!", DCB_Base.DCB_IRCColors.Blue)
            ' Exit Sub
        End If
        LastConnect = URL
        '----------------
        ' CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "IRC_NET_Connect", DCB_Base.DCB_IRCColors.Blue)
        InterfaceCTLS.DefInstance.ChangeConnectButtonIcon(True)
        Try
            IRC_NET_CreateSocket()
            IRC_Socket.DCB_NET_Connect(URL, Port)
        Catch ex As Exception
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<ETCPS><NETERROR>" & ex.ToString, DCB_Base.DCB_IRCColors.Blue)
        End Try
    End Sub
    Friend Sub IRC_NET_Stop()
        InterfaceCTLS.DefInstance.ChangeConnectButtonIcon(False)
        If IRC_Settings.IRCStrings.IRC_QuitMsgPrgClose Is Nothing Then IRC_Settings.IRCStrings.IRC_QuitMsgPrgClose = ""
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " /QUIT :" & IRC_Settings.IRCStrings.IRC_QuitMsgPrgClose.Trim)
        IRC_Socket.DCB_NET_Disconnect()
        IRC_NET_DisposeSocket()
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Сетевое подключение остановлено", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)

    End Sub
    Friend Sub IRC_NET_ERRORSTOP()

        IRC_Socket.DCB_NET_Disconnect()
        IRC_NET_DisposeSocket()
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Сетевое подключение остановлено", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)

        '
        If IRC_Settings.Network.Reconnect = True Then
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Переподключение через: " & IRC_Settings.Network.ReconWait & " Секунд.", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
            If LastConnect <> "" Then
                Dim T As New IRC_UniTimer("%PID% irc_connectto " & LastConnect, IRC_Settings.Network.ReconWait, IRC_INF.INF_CMDEXEC & " irc_getconnectstatus")
            Else
                Dim T As New IRC_UniTimer("%PID% irc_connecttodefserv", IRC_Settings.Network.ReconWait, IRC_INF.INF_CMDEXEC & " irc_getconnectstatus")
            End If

        End If
    End Sub
    Friend Sub IRC_SendMessage(ByVal Dat As String)
        If Not IRC_Socket Is Nothing Then
            IRC_Socket.DCB_NET_SendMessage(Dat)
        End If
    End Sub
    Friend Sub IRC_NetError(ByVal Err As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<NETERROR>" & Err, DCB_Base.DCB_IRCColors.Blue)
        IRC_NET_ERRORSTOP()
    End Sub

    Private Sub IRC_NET_DataDecoder_Level1(ByVal indata As String)
        ' "низкоуровневая" разбока пакетов. сборка фрагментации
        Dim SPLITMSG As String
        Dim MSGS() As String
        Dim Fragmentation As Boolean = False

        MSGS = indata.Split(vbLf.ToCharArray)
        For Each SPLITMSG In MSGS
            If Fragmentation = False Then
                If IRC_NET_Buffer <> "" And SPLITMSG.EndsWith(Chr(13)) Then
                    SPLITMSG = IRC_NET_Buffer & SPLITMSG
                End If
                Fragmentation = True
                IRC_NET_Buffer = ""
            End If
            If SPLITMSG <> "" Then
                If SPLITMSG.EndsWith(Chr(13)) Then
                    'IRChat.IRC_ShowInChat(0, ChlMainIRC, SPLITMSG)
                    IRC_Packets_Parser(SPLITMSG)
                Else
                    Fragmentation = True
                    IRC_NET_Buffer = SPLITMSG
                End If
            End If
        Next
    End Sub


#End Region

    Friend Sub IRC_ShowInChat(ByVal UID As String, ByVal Chl As DCB_Channels2.DCB_Channel, ByVal Msg As String)
        Try
            CHLCtl.DCB_Talk_UUID_ChlDCC(UID, Chl, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, Msg, CType(IRC_Settings.IRCColors.NormalColor, DCB_Base.DCB_IRCColors))
        Catch
            ' MsgBox("<Error><DCIRC><ShowInChat> CHL disposed!!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Friend Function IRC_GetIRCCurrentChannelDCC() As DCB_Channels2.DCB_Channel
        Dim LastMyCHL As DCB_Channels2.DCB_Channel = ChlMainIRC
        Dim CurChl As DCB_Channels2.DCB_Channel = DCCtl.DCB_GetCurrentChannelDCC
        If Not CurChl.CHLID.StartsWith(IRC_INF.INF_CMDEXEC) Then
            Return LastMyCHL
        Else
            Return CurChl
        End If
    End Function


    Friend Function IRC_GetIRCCurrentchannelCHLID() As String
        Dim LastMyCHL As DCB_Channels2.DCB_Channel = ChlMainIRC
        Dim CurChl As DCB_Channels2.DCB_Channel = DCCtl.DCB_GetCurrentChannelDCC
        If Not CurChl.CHLID.StartsWith(IRC_INF.INF_CMDEXEC) Then
            Return LastMyCHL.CHLID
        Else
            Return CurChl.CHLID
        End If
    End Function

    Friend Function IRC_GetIRCcurrentchannelName() As String
        Dim LastMyCHL As DCB_Channels2.DCB_Channel = ChlMainIRC
        Dim CurChl As DCB_Channels2.DCB_Channel = DCCtl.DCB_GetCurrentChannelDCC
        If Not CurChl.CHLID.StartsWith(IRC_INF.INF_CMDEXEC) Then
            Return LastMyCHL.CHLID.Substring(IRC_INF.INF_CMDEXEC.Length)
        Else
            Return CurChl.CHLID.Substring(IRC_INF.INF_CMDEXEC.Length)
        End If
    End Function

    Friend Sub IRC_AddUsrToChannelOnConnect(ByVal Msg As String)
        'Разборка пакета с пользователями
        Dim Usr As DCB_Channels2.DCB_User
        Dim ToChl As DCB_Channels2.DCB_Channel
        Dim MsgArray() As String = Msg.Split
        Dim tmp As Integer
        Dim User As String
        Dim UserNameToDisplay As String
        Dim USRole As String
        Dim UMode As String

        ToChl = CHLCtl.DCB_DChannelSTR(MsgArray(4), IRC_INF.INF_CMDEXEC)
        If ToChl Is Nothing Then Exit Sub
        For tmp = 5 To MsgArray.Length - 1
            UMode = ""
            UserNameToDisplay = MsgArray(tmp)
            User = UserNameToDisplay
            IRC_UpdFriend(User, IRC_Friend.FriendStates.Active)
            If UserNameToDisplay.StartsWith(":") Then UserNameToDisplay = UserNameToDisplay.Substring(1)
            If User = " " Or User = Chr(13) Or User = "" Then Exit For
            If User.StartsWith(":") Then User = User.Substring(1)
            If User.StartsWith("@") Then User = User.Substring(1) : UMode = UMode + "o"
            If User.StartsWith("%") Then User = User.Substring(1) : UMode = UMode + "h"
            If User.StartsWith("+") Then User = User.Substring(1) : UMode = UMode + "v"
            Usr = USRCtl.DCB_GetUser_Name(User, IRC_INF.INF_CMDEXEC)
            If Usr Is Nothing Then

                Usr = USRCtl.DCB_AddNewUser(IRC_INF.INF_CMDEXEC & User, User, User, IRC_INF.INF_CMDEXEC)
                If Usr.UserNick <> IRC_Settings.UserInfo.UserCurrentNick Then Usr.UserType = DCB_Universal.DCB_LocalUserInfo.UserTypes.USR_StdRemote
                Usr._miniplugincolorscheme.OurTextColor = Color.FromArgb(DC2Conv.GetARGBfromIRCCode(IRC_Settings.IRCColors.NormalColor))
                Usr._miniplugincolorscheme.MyTextColor = Color.FromArgb(DC2Conv.GetARGBfromIRCCode(IRC_Settings.IRCColors.OwnColor))

            End If
            If CHLCtl.IsUserExist(Usr.UserID, ToChl.CHLID) = False Then
                CHLCtl.DCB_JoinUserToChl(Usr.UserID, ToChl.CHLID)
            End If
            Dim UNode As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem_TN = Usr.GetNode(ToChl.CHLID)
            UNode.Text = UserNameToDisplay
            UNode.Info = UMode
            Dim UIco As Integer = 0
            If UserNameToDisplay.StartsWith("@") Then UIco = 10
            If UserNameToDisplay.StartsWith("%") Then UIco = 11
            If UserNameToDisplay.StartsWith("+") Then UIco = 12
            UNode.ImageIndex = UIco
        Next
        UpdLstUsers(ToChl)
    End Sub
    Friend Sub IRC_ChangeUserNick(ByVal USR As String, ByVal NewNick As String)
        USRCtl.DCB_ChangeUserName(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & USR, NewNick)
    End Sub

    Friend Sub IRC_AddJoinedUserToChannel(ByVal Msg As String)
        Dim UserName() As String = Msg.Split(CChar("!"))
        Dim MsgArray() As String = Msg.Split
        Dim ToChl As DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & MsgArray(2).Trim(CChar(":")))
        Dim Usr As DCB_Channels2.DCB_User
        If ToChl Is Nothing Then Exit Sub

        Usr = USRCtl.DCB_GetUser_Name(UserName(0), IRC_INF.INF_CMDEXEC)
        If Usr Is Nothing Then
            Usr = USRCtl.DCB_AddNewUser(IRC_INF.INF_CMDEXEC & UserName(0), UserName(0), UserName(0), IRC_INF.INF_CMDEXEC)
            If Usr.UserNick <> IRC_Settings.UserInfo.UserCurrentNick Then Usr.UserType = DCB_Universal.DCB_LocalUserInfo.UserTypes.USR_StdRemote
        End If
        If USRCtl.IsCHLExsist(Usr.UserID, ToChl.CHLID) = False Then
            CHLCtl.DCB_JoinUserToChl(Usr.UserID, ToChl.CHLID)
        End If

    End Sub


    Friend Sub IRC_Int_InitInfo()
        '----------------------------------
        'UNI
        '----------------------------------
        IRC_INF.INF_CMDEXEC = "/irccmd"
        'IRC_INF.INF_ENTRY = "IRC.IRC_DC_CLIENT"
        IRC_INF.INF_NAME = "DCIRC"
        IRC_INF.INF_VER = New Version(IRC_VER)
        IRC_INF.INF_DESCRIPTION = IRC_DESC ' .INF_CHTOPIC = IRC_SCRIPT_CONSTANTS.IRC_SCRIPT_CHTOPIC
        IRC_INF.INF_PLUGINTYPESTR = "DCB_V1"
        IRC_INF.INF_PLUGINTYPE = DCB_Universal.DCB_UNI_PluginTypes.DCB_V1
        IRC_INF.INF_OPTIONS.DCB_UseGUICTL = True

    End Sub


    Friend Sub IRC_SendMsg(ByVal MSG As String)
        'Подготовка пакета к отправке
        '   If IRC_NET_STOP = True Then Exit Sub
        If IRC_Socket Is Nothing Then
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "Нет подключения!", DCB_Base.DCB_IRCColors.Blue)
            Exit Sub
        End If
        MSG = MSG.TrimStart(CChar("/"))
        MSG &= vbCrLf
        '  If MSG.IndexOf("whois") > 0 Then Stop

        IRC_SendMessage(MSG)
    End Sub

    Friend Sub IRC_CheckUserMode_Step1(ByVal CHLName As String, ByVal Mode As String, ByVal User As String)
        ' Обработка отображения режимов пользователей
        If User = "" Then Exit Sub ' Обрабатываем только пользователей :)
        ' Разбираем флаги и юзеров
        Dim Users() As String = User.Split
        Dim Plus As Char
        Dim tmp As Integer
        Dim tmp1 As Integer
        For tmp = 0 To Mode.Length - 1
            If Mode.Substring(tmp, 1) = "+" Then
                Plus = "+"c
            ElseIf Mode.Substring(tmp, 1) = "-" Then
                Plus = "-"c
            Else
                For tmp1 = 0 To UBound(Users) '- 1
                    Try
                        irc_CheckUserMode_Step2(CHLName, Plus & Mode.Substring(tmp, 1), Users(tmp1))
                    Catch : End Try
                Next
            End If
        Next
    End Sub
    Friend Sub irc_CheckUserMode_Step2(ByVal CHLName As String, ByVal Mode As String, ByVal User As String)
        If User = "" Then Exit Sub
        Dim chl As DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & CHLName)
        Dim USR As DCB_Channels2.DCB_User = USRCtl.DCB_GetUser_UID(IRC_INF.INF_CMDEXEC & User)
        Dim node As DCB_Controls.DCB_ListViewItem_TN = USR.GetNode(IRC_INF.INF_CMDEXEC & CHLName)
        '  Dim tmp As Integer

        If Mode.StartsWith("+") Then
            Try
                If node.Info.IndexOf(Mode.Substring(1)) < 0 Then node.Info &= Mode.Substring(1)
            Catch
                node.Info &= Mode.Substring(1)
            End Try
        Else
            Try
                node.Info = node.Info.Replace(Mode.Substring(1), "")
            Catch : End Try
        End If
        ' обработка видимых режимов
        If node.Info.IndexOf("o") >= 0 Then
            node.Text = "@" & USR.UserNick
            node.ImageIndex = 10
        ElseIf node.Info.IndexOf("h") >= 0 Then
            node.Text = "%" & USR.UserNick
            node.ImageIndex = 11
        ElseIf node.Info.IndexOf("v") >= 0 Then
            node.Text = "+" & USR.UserNick
            node.ImageIndex = 12
        Else
            node.Text = USR.UserNick
            node.ImageIndex = 0
        End If
        UpdLstUsers(chl)
    End Sub
    Friend Sub UpdLstUsers(ByVal CHL As DCB_Channels2.DCB_Channel)
        CHL.lstUsers.ListViewItemSorter = New LViewCHLSorter
        CHL.lstUsers.Sort()
    End Sub
    Friend Sub IRC_PluginQuit(ByVal WinExit As Boolean)
        If Not IRC_Socket Is Nothing Then
            If WinExit = True Then
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/QUIT :" & IRC_Settings.IRCStrings.IRC_QuitMsgSysExit.Trim)
            Else
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/QUIT :" & IRC_Settings.IRCStrings.IRC_QuitMsgPrgClose.Trim)
            End If
        End If
    End Sub

    Friend Sub IRC_NETOPER_ConnectToServer(ByVal URL As String, Optional ByVal Port As String = "6667")
        If URL = "" Then Exit Sub
        IRC_NETOPER_CheckServList(URL)

        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " irc_printincon Connecting to " & URL & ":" & Port & "......")
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " irc_connect " & URL & " " & Port)
        ' Application.DoEvents()
        If IRC_Socket Is Nothing Then Exit Sub
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " /USER %usrid% 0 * :%realname%")
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " /NICK %usrnick_%")

    End Sub
    Friend Function GetUserUID() As String
        Dim UID As String
        UID = IRC_INF.INF_CMDEXEC & Int(Rnd() * 10000)
        If Not USRCtl.DCB_GetUser_UID(UID) Is Nothing Then UID = GetUserUID()
        Return UID
    End Function
    Friend Function GetDateFromIRCStd(ByVal DatString As String) As String
        Return DateTime.op_Addition(New Date(1970, 1, 1, 0, 0, 0), TimeSpan.FromSeconds(Val(DatString))).ToString()
    End Function

    Friend Sub IRC_NETOPER_CheckServList(ByVal URL As String)
        Dim SL As String() = LoadLastServersList()
        Dim TMP As String
        Dim NSL(10) As String
        Dim intTMP As Integer
        If Not SL Is Nothing Then
            For Each TMP In SL
                If TMP = URL Then Exit Sub
            Next

            For intTMP = 10 To 1 Step -1
                NSL(intTMP) = SL(intTMP - 1)
            Next
        End If
        NSL(0) = URL

        SaveLastServersList(NSL)
        IRC_INTERF_CreateFCMenu()
    End Sub
End Module
Friend Class IRCTextManager
    ' RTFIRC Module support Class
    Dim MPID As String
    Sub New(ByVal MODPID As String)
        MPID = MODPID
    End Sub

    Public Function RTFToDC2(ByVal RTF As String) As String
        Return CStr(DCSE.ExecScriptCommand(MPID, MPID & Chr(1) & "rtftodc2" & Chr(1) & RTF, Chr(1)))
    End Function

    Public Function DC2ToRTF(ByVal RTF As String, ByVal FNT As String, ByVal FSize As String) As String
        Return CStr(DCSE.ExecScriptCommand(MPID, MPID & Chr(1) & "dc2tortf" & Chr(1) & FNT & Chr(1) & FSize & Chr(1) & RTF, Chr(1)))
    End Function
    Public Function TXT2RTF(ByVal Txt As String, ByVal FNT As String, ByVal FSize As String) As String
        Return CStr(DCSE.ExecScriptCommand(MPID, MPID & Chr(1) & "txt2rtf" & Chr(1) & FNT & Chr(1) & FSize & Chr(1) & Txt, Chr(1)))

    End Function
    Public Function RTF2TXT(ByVal Txt As String) As String
        Return CStr(DCSE.ExecScriptCommand(MPID, MPID & Chr(1) & "rtftodc2" & Chr(1) & Txt, Chr(1)))
    End Function
    Public Function GetARGBfromIRCCode(ByVal IRCCode As Integer) As Integer
        Return CInt(DCSE.ExecScriptCommand(MPID, MPID & Chr(1) & "getargbfromirccode" & Chr(1) & IRCCode, Chr(1)))
    End Function
    Public Function GetIRCCodeFormARGB(ByVal ARGB As Integer) As Integer
        Return CInt(DCSE.ExecScriptCommand(MPID, MPID & Chr(1) & "getirccodefroemargb" & Chr(1) & ARGB, Chr(1)))
    End Function
    Public Function RemoveIRCCodes(ByVal TXT As String) As String
        Return CStr(DCSE.ExecScriptCommand(MPID, MPID & Chr(1) & "removeirccodes" & Chr(1) & TXT, Chr(1)))

    End Function
End Class
