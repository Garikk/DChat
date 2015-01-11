' DZFS.NET 2003 - 2005
' DChat Project
' IRC Control Module
'------------------------------------------------------------------------------------
' Programmed by Garikk
' IRC Net Messages Processor (IRChat) (IRC RFC2812)
'------------------------------------------------------------------------------------
Imports UNI_Plugin.UNI_DChat.DCB_V1
Imports System.Windows.Forms
Imports System.Drawing

Module IRC_Process
    Public IRC_AltNickIsSet As Boolean = False
    Dim CHLListBuffer As New Collection
    Public Function TxtToRTF(ByVal Txt As String) As String
        Dim A As New Windows.Forms.RichTextBox
        A.Text = Txt
        A.SelectAll()
        Return A.SelectedRtf
    End Function

    Friend Sub IRC_Packets_Parser(ByVal Msg As String)
        ' Обработчик сетевых пакетов IRC сервера
        Dim Prefix As String
        Dim command As Integer
        Dim Params As String
        Static ToChl As DCB_Channels2.DCB_Channel
        Static Usr As DCB_Channels2.DCB_User

        Dim ReadStep As String
        Dim MsgArray() As String
        Dim ParamsString As String
        Dim NoStandardPrefix As Boolean = False

        Dim ColonSplit() As String
        Dim SpaceSplit() As String


        MsgArray = Msg.Split
        ColonSplit = Msg.Split(CChar(":"))
        SpaceSplit = Msg.Split

        If Msg.StartsWith(":") Then Msg = Msg.Remove(0, 1)
        Prefix = MsgArray(0)
        command = CInt(Val(MsgArray(1)))

        ' ------DEBUG------
        If IRC_Settings.Debug.IRC_DBG_SHOWSERVRAW = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base printincon <i_irc_packets_parser>" & Msg)
        ' ------DEBUG------
        Try
            ParamsString = " " & Msg.Substring(MsgArray(0).Length + MsgArray(1).Length + MsgArray(2).Length + 2).TrimStart(CChar(":"))
        Catch
            Stop
        End Try
        '-----sm events----- ppcmd=true
        ' Отключено до лучших времён :)
        'IRC_PROC_EVENTS(Msg, CStr(command), MsgArray, True)
        '-------------------
        Select Case command
            ' -------------------- RPL ------------------
        Case IRCConst.RPL_WELCOME, IRCConst.RPL_YOURHOST, IRCConst.RPL_MYINFO, IRCConst.RPL_CREATED
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Purple)
                If command = 4 Then
                    IRC_FirstNickInit = False ' Установщик Alt ника...отключаем
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXT_NOTUNAME, " ", DCB_Base.DCB_IRCColors.Purple)
                    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/exec irc_perform.dcscript")
                    Try
                        IRC_JoinFavorites()
                    Catch
                        ' ------DEBUG------
                        If IRC_Settings.Debug.IRC_DBG_MODULES = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base printincon <CHLFavirites Error>" & Msg)
                        ' ------DEBUG------
                    End Try
                End If
            Case IRCConst.RPL_NAMREPLY, IRCConst.RPL_ENDOFNAMES
                IRC_PROCESS_NAMEREPLY(Msg, MsgArray, ColonSplit, command)
            Case IRCConst.RPL_TOPIC, IRCConst.RPL_TOPIC_CHANGER_NOTRFC, IRCConst.RPL_NOTOPIC
                IRC_PROCESS_TOPIC(Msg, command, MsgArray, ParamsString)
            Case IRCConst.RPL_ISUPPORT
                IRC_PROCESS_ISUPPORT(Msg, ParamsString)
            Case IRCConst.RPL_LUSERCLIENT, RPL_LUSEROP, RPL_LUSERUNKNOWN, RPL_LUSERCHANNELS, RPL_LUSERME
                IRC_PROCESS_LUSER(command, Msg, ParamsString)
            Case IRCConst.RPL_VERSION
                IRC_PROCESS_VERSION(Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_ADMINME, IRCConst.RPL_ADMINLOC1, IRCConst.RPL_ADMINLOC2, IRCConst.RPL_ADMINEMAIL
                IRC_PROCESS_ADMIN(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_TRYAGAIN
                IRC_PROCESS_TRYAGAIN(Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_TIME
                IRC_PROCESS_TIME(Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_STATSCOMMANDS, IRCConst.RPL_STATSLINKINFO, IRCConst.RPL_STATSOLINE, IRCConst.RPL_STATSUPTIME, IRCConst.RPL_ENDOFSTATS
                IRC_PROCESS_STATS(command, Msg, MsgArray, ParamsString)
            Case 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 261, 262 ' TRACE
                IRC_PROCESS_TRACE(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_USERSSTART, IRCConst.RPL_USERS, IRCConst.RPL_ENDOFUSERS
                IRC_PROCESS_USERS(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_INFO, IRCConst.RPL_ENDOFINFO
                IRC_PROCESS_INFO(command, MsgArray, ParamsString)
            Case IRCConst.RPL_AWAY, IRCConst.RPL_UNAWAY, IRCConst.RPL_NOWAWAY
                IRC_PROCESS_AWAY(command, MsgArray, ParamsString)
            Case IRCConst.RPL_LISTSTART, IRCConst.RPL_LIST, IRCConst.RPL_LISTEND
                IRC_PROCESS_LIST(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_YOUREOPER
                IRC_PROCESS_YOUREOPER(Msg, MsgArray)
            Case IRCConst.RPL_REHASHING
                IRC_PROCESS_REHASHING(Msg, MsgArray, ParamsString)

            Case IRCConst.RPL_YOURESERVICE
                IRC_PROCESS_YOURESERVICE(Msg, MsgArray, ParamsString)

            Case IRCConst.RPL_UMODEIS
                IRC_PROCESS_UMODEIS(Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_CHLCREATIONDATE_NOTRFC
                IRC_PROCESS_CHLCREATIONTIME_NOTRFC(Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_SERVLIST, IRCConst.RPL_SERVLISTEND
                IRC_PROCESS_SERVLIST(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_LINKS, IRCConst.RPL_ENDOFLINKS
                IRC_PROCESS_LINKS(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_BANLIST, IRCConst.RPL_ENDOFBANLIST
                IRC_PROCESS_BANLIST(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_USERHOST
                IRC_PROCESS_USERHOST(Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_CHANNELMODEIS
                IRC_PROCESS_CHANNELMODEIS(Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_INVITELIST, IRCConst.RPL_ENDOFINVITELIST
                IRC_PROCESS_INVITELIST(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_UNIQOPIS
                IRC_PROCESS_UNIQOPIS(Msg, ParamsString)
            Case IRCConst.RPL_EXCEPTLIST, IRCConst.RPL_ENDOFEXCEPTLIST
                IRC_PROCESS_EXCEPTLIST(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_WHOISCHANNELS, IRCConst.RPL_WHOISIDLE, RPL_WHOISOPERATOR, RPL_WHOISSERVER, RPL_WHOISUSER, RPL_ENDOFWHOIS, RPL_ACTUALLY_NOTRFC
                IRC_PROCESS_WHOIS(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_ENDOFWHO, IRCConst.RPL_WHOREPLY
                IRC_PROCESS_WHO(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_WHOWASUSER, IRCConst.RPL_ENDOFWHOWAS
                IRC_PROCESS_WHOWAS(command, Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_ISON
                IRC_PROCESS_ISON(Msg, MsgArray, ParamsString)
            Case 265, 266, 250, 15, 17 'Reserved
                IRC_PROCESS_RESERVE(command, ParamsString)
                ' -------------- ERR --------------------
            Case IRCConst.ERR_NICKNAMEINUSE
                IRC_PROCESS_ERR_NICKNAMEINUSE(Msg)
            Case IRCConst.ERR_ERRONEUSNICKNAME
                IRC_PROCESS_ERR_ERRONEUSNICKNAME(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NICKCOLLISION
                IRC_PROCESS_ERR_NICKCOLLISION(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_BANNEDFROMCHAN
                IRC_PROCESS_ERR_BAN(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_CHANNELISFULL
                IRC_PROCESS_ERR_CHANNELISFULL(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_INVITEONLYCHAN
                IRC_PROCESS_ERR_INVITEONLYCHAN(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_BADCHANNELKEY
                IRC_PROCESS_ERR_BADCHANNELKEY(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_CHANOPRIVSNEEDED
                IRC_PROCESS_ERR_CHANOPRIVSNEEDED(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NEEDMOREPARAMS
                IRC_PROCESS_ERR_NEEDMOREPARAMS(Msg, MsgArray, ParamsString)
            Case IRCConst.RPL_MOTDSTART, IRCConst.RPL_MOTD, IRCConst.RPL_ENDOFMOTD
                IRC_PROCESS_MOTD(command, Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOSUCHNICK
                IRC_PROCESS_ERR_NOSUCHNICK(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOSUCHSERVER
                IRC_PROCESS_ERR_NOSUCHSERVER(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOSUCHCHANNEL
                IRC_PROCESS_ERR_NOSUCHCHANNEL(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_CANNOTSENDTOCHAN
                IRC_PROCESS_ERR_CANNOTSENDTOCHAN(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_TOOMANYCHANNELS
                IRC_PROCESS_ERR_TOOMANYCHANNELS(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_WASNOSUCHNICK
                IRC_PROCESS_ERR_WASNOSUCHNICK(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_TOOMANYTARGETS
                IRC_PROCESS_ERR_TOOMANYTARGETS(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOSUCHSERVICE
                IRC_PROCESS_ERR_NOSUCHSERVICE(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOORIGIN
                IRC_PROCESS_ERR_NOORIGIN(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NORECIPIENT
                IRC_PROCESS_ERR_NORECIPIENT(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOTEXTTOSEND
                IRC_PROCESS_ERR_NOTEXTTOSEND(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOTOPLEVEL
                IRC_PROCESS_ERR_NOTOPLEVEL(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_WILDTOPLEVEL
                IRC_PROCESS_ERR_WILDTOPLEVEL(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_BADMASK
                IRC_PROCESS_ERR_BADMASK(Msg, MsgArray, ParamsString)

            Case IRCConst.ERR_UNKNOWNCOMMAND
                IRC_PROCESS_ERR_UNKNOWNCOMMAND(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOMOTD
                IRC_PROCESS_ERR_NOMOTD(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOADMININFO
                IRC_PROCESS_ERR_NOADMININFO(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_FILEERROR
                IRC_PROCESS_ERR_FILEERROR(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NONICKNAMEGIVEN
                IRC_PROCESS_ERR_NONICKNAMEGIVEN(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_UNAVAILRESOURCE
                IRC_PROCESS_ERR_UNAVAILRESOURCE(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOOPERHOST
                IRC_PROCESS_ERR_NOOPERHOST(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_USERNOTINCHANNEL
                IRC_PROCESS_ERR_USERNOTINCHANNEL(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOPRIVILEGES
                IRC_PROCESS_ERR_NOPRIVILEGES(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOTONCHANNEL
                IRC_PROCESS_ERR_NOTONCHANNEL(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_YOUREBANNEDCREEP
                IRC_PROCESS_ERR_YOUREBANNEDCREEP(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_YOUWILLBEBANNED
                IRC_PROCESS_ERR_YOUWILLBEBANNED(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_KEYSET
                IRC_PROCESS_ERR_KEYSET(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_USERSDONTMATCH
                IRC_PROCESS_ERR_USERSDONTMATCH(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_UMODEUNKNOWNFLAG
                IRC_PROCESS_ERR_UMODEUNKNOWNFLAG(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_CANTKILLSERVER
                IRC_PROCESS_ERR_CANTKILLSERVER(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_RESTRICTED
                IRC_PROCESS_ERR_RESTRICTED(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_UNIQOPPRIVSNEEDED
                IRC_PROCESS_ERR_UNIQOPPRIVSNEEDED(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_BADCHANMASK
                IRC_PROCESS_ERR_BADCHANMASK(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOCHANMODES
                IRC_PROCESS_ERR_NOCHANMODES(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_BANLISTFULL
                IRC_PROCESS_ERR_BANLISTFULL(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_USERONCHANNEL
                IRC_PROCESS_ERR_USERONCHANNEL(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOLOGIN
                IRC_PROCESS_ERR_NOLOGIN(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_SUMMONDISABLED
                IRC_PROCESS_ERR_SUMMONDISABLED(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_USERSDISABLED
                IRC_PROCESS_ERR_USERSDISABLED(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOTREGISTERED
                IRC_PROCESS_ERR_NOTREGISTERED(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_ALREADYREGISTRED
                IRC_PROCESS_ERR_ALREADYREGISTRED(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_NOPERMFORHOST
                IRC_PROCESS_ERR_NOPERMFORHOST(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_PASSWDMISMATCH
                IRC_PROCESS_ERR_PASSWDMISMATCH(Msg, MsgArray, ParamsString)
            Case IRCConst.ERR_ALREADYONCHL_NOTRFC
                IRC_PROCESS_ERR_ALREADYONCHL(Msg, MsgArray, ParamsString)
            Case Else
                ' ----------- Без определённого заголовка ------------------
                'Разборка ненумерованных пакетов
                If MsgArray(1) = "PRIVMSG" Then
                    IRC_PROCESS_PRIVMSG(Msg, MsgArray, ColonSplit, ParamsString)
                ElseIf MsgArray(1) = "NOTICE" Then
                    IRC_PROCESS_NOTICE(Msg, MsgArray, ColonSplit, ParamsString)
                ElseIf MsgArray(1) = "JOIN" Then
                    IRC_PROCESS_JOIN(Msg, MsgArray, ColonSplit)
                ElseIf MsgArray(1) = "MODE" Then
                    IRC_PROCESS_MODE(Msg, MsgArray, ParamsString)
                ElseIf MsgArray(1) = "TOPIC" Then
                    IRC_PROCESS_TOPIC(Msg, 9000, MsgArray, ParamsString)
                ElseIf MsgArray(0) = "PING" Then
                    IRC_PROCESS_PING(Msg, MsgArray, ColonSplit)
                ElseIf MsgArray(1) = "PART" Then
                    IRC_PROCESS_PART(Msg, MsgArray, ColonSplit)
                ElseIf MsgArray(1) = "QUIT" Then
                    IRC_PROCESS_QUIT(Msg, MsgArray, ColonSplit)
                ElseIf MsgArray(1) = "KICK" Then
                    IRC_PROCESS_KICK(Msg, MsgArray, ParamsString)
                ElseIf MsgArray(1) = "INVITE" Then
                    IRC_PROCESS_INVITE(Msg, MsgArray, ParamsString)
                ElseIf MsgArray(1) = "WALLOPS" Then
                    IRC_PROCESS_WALLOPS(Msg, MsgArray, ParamsString)
                ElseIf MsgArray(1) = "NICK" Then
                    IRC_PROCESS_NICK(Msg, MsgArray)
                    ':Angel!wings@irc.org INVITE Wiz #Dust
                ElseIf ColonSplit(0).TrimEnd = "ERROR" Then
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_ERROR, ColonSplit(1), DCB_Base.DCB_IRCColors.Red)

                Else
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXT_NOTUNAME, MsgArray(1) & ParamsString, DCB_Base.DCB_IRCColors.Red)

                End If
        End Select
        '-----sm events-----
        ' Отключено до лучших времён :)
        ' IRC_PROC_EVENTS(Msg, CStr(command), MsgArray)
        '-------------------
    End Sub

    Friend Function IRC_GetUserNameFromPrefix(ByVal Prefix As String) As String
        'Вытаскиваем Username из Префикса
        Dim Pref() As String = Prefix.Split(CChar("!"))
        Return Pref(0)
    End Function
    'Friend Function IRC_PROC_EVENTS(ByVal cmd As String, ByVal Command As String, ByVal MsgArray() As String, Optional ByVal ppcmd As Boolean = False) As Boolean
    ' Отключено до лучших времён
    '    Dim Tmp As IRC_Event
    '    Dim TmpO As Object
    '    Try
    '        TmpO = IRC_RegEvents(Command)
    '    Catch
    '        Try
    '            TmpO = IRC_RegEvents(MsgArray(1))
    '        Catch
    '            Return False
    '        End Try
    '    End Try
    '    Tmp = CType(TmpO, IRC_Event)
    '    If (Tmp.Evppcmd = "0" And ppcmd = True) Or (Tmp.Evppcmd = "1" And ppcmd = False) Then Return False

    '    If Tmp.EvCHLSndCtl = "1" Then Tmp.EvCMD = Tmp.EvCMD.Replace("%sfcmd%", cmd)
    '    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, Tmp.EvCMD)

    '    ' ------DEBUG------
    '    If IRC_Settings.Debug.IRC_DBG_MODULES = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base printincon <IRCHAT><PACKETPARSER><EVENT>" & cmd)
    '    ' ------DEBUG------

    '    Return False
    'End Function
#Region " RPL "
    Friend Sub IRC_PROCESS_NICK(ByVal Msg As String, ByVal MsgArray() As String)
        Dim UserName As String = IRC_GetUserNameFromPrefix(MsgArray(0)).TrimStart(CChar(":"))
        Dim NewUsername As String = MsgArray(2).TrimStart(CChar(":"))

        If UserName = IRC_Settings.UserInfo.UserCurrentNick Then
            IRC_Settings.UserInfo.UserCurrentNick = NewUsername
            If DCCtl.DCB_GetCurrentPluginID = IRC_INF.INF_CMDEXEC Then DCCtl.DCB_GetNickTextBox.Text = NewUsername
        End If
        CHLCtl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs(IRC_INF.INF_CMDEXEC & UserName, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, UserName & " переименовался в " & NewUsername, CType(IRC_Settings.IRCColors.NickColor, DCB_Base.DCB_IRCColors), 5)
        Try : IRC_ChangeUserNick(UserName, NewUsername) : Catch : End Try
        UpdLstUsers(DCCtl.DCB_GetCurrentChannelDCC)
        IRC_SNDMGR_MANAGER(IRC_Declares.IRC_SNDMGR_Events.IRC_SND_NICK, IRC_INF.INF_CMDEXEC & NewUsername)

        'If DCCtl.DCB_GetCurrentChannelDCC.CHLParams.USESound = True Then IRC_CtlSounds(UInterfaceControl.IRC_SNDS.S_RENAME)
    End Sub
    Friend Sub IRC_PROCESS_YOUREOPER(ByVal Msg As String, ByVal MsgArray() As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Вам предоставлены права Администратора сервера " & MsgArray(0).TrimStart(CChar(":")), DCB_Base.DCB_IRCColors.Purple)
    End Sub
    Friend Sub IRC_PROCESS_SERVLIST(ByVal command As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Select Case command
            Case IRCConst.RPL_SERVLIST
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_SERVLISTEND
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "---------------------------", DCB_Base.DCB_IRCColors.Blue)
        End Select
    End Sub
    Friend Sub IRC_PROCESS_INVITE(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim UsrName As String = IRC_GetUserNameFromPrefix(MsgArray(0).TrimStart(CChar(":")))
        'If Windows.Forms.MessageBox.Show(UsrName & " приглашает вас на канал " & MsgArray(3) & ". Войти по приглашению?", "DC-IRChat", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    IRC_CMD_PROCESS("irc_sendtoserver JOIN " & MsgArray(3).TrimStart(CChar(":")))
        'End If
        CHLCtl.DCB_Talk_UID_ALL_PLUGIN_CHLs(IRC_INF.INF_CMDEXEC & UsrName, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Вас приглашают на канал:" & MsgArray(3), CType(IRC_Settings.IRCColors.InviteColor, DCB_Base.DCB_IRCColors))

    End Sub
    Friend Sub IRC_PROCESS_WALLOPS(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim UsrName As String = IRC_GetUserNameFromPrefix(MsgArray(0).TrimStart(CChar(":")))
       
        CHLCtl.DCB_Talk_UID_ALL_PLUGIN_CHLs(IRC_INF.INF_CMDEXEC & UsrName, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "WALLOPS message:" & MsgArray(3) & " " & ParamsString, CType(IRC_Settings.IRCColors.WallopsColor, DCB_Base.DCB_IRCColors))

    End Sub
    Friend Sub IRC_PROCESS_AWAY(ByVal command As Integer, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim UsrName As String = MsgArray(3)
        Dim Usruid As String = IRC_INF.INF_CMDEXEC & UsrName
        Dim Comment As String = ParamsString.Substring(MsgArray(4).Length).TrimStart(CChar(":"))
        ' CHLCtl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs(IRC_INF.INF_CMDEXEC & IRC_Settings.UserInfo.UserCurrentNick, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "MMSG!", DCB_Base.DCB_IRCColors.Green)
        Select Case command
            Case IRCConst.RPL_AWAY
                CHLCtl.DCB_Talk_UUID_ChlDCC(Usruid, ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXT_NOTUNAME, "Пользователь " & UsrName & " находится в режиме ""Не беспокоить"" : " & Comment, DCB_Base.DCB_IRCColors.Maroon)
                IRC_UpdFriend(UsrName, IRC_Friend.FriendStates.Away)
                If frmUserInfo.DefInstance.Visible = False Then frmUserInfo.DefInstance.txtAwayInfo.Text = ParamsString.Split(":"c)(1).Trim
            Case IRCConst.RPL_NOWAWAY
                CHLCtl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs(IRC_INF.INF_CMDEXEC & IRC_Settings.UserInfo.UserCurrentNick, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Установлен режим: Не беспокоить (" & IRC_Settings.IRCMode.ModeName & ": " & IRC_Settings.IRCMode.Comment & ")", DCB_Base.DCB_IRCColors.Green)
            Case IRCConst.RPL_UNAWAY
                CHLCtl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs(IRC_INF.INF_CMDEXEC & IRC_Settings.UserInfo.UserCurrentNick, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Режим ""Не беспокоить"" снят", DCB_Base.DCB_IRCColors.Green)
        End Select

    End Sub
    Friend Sub IRC_PROCESS_LIST(ByVal command As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        ' Static CHLBuffer As New Collection
        Static CHLList As DCB_Channels2.DCB_Channel

        Select Case command
            Case IRCConst.RPL_LISTSTART
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Получение списка каналов....", DCB_Base.DCB_IRCColors.Blue)
                ''Проверка на наличее Channels list
                CHLList = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & "CHLLIST")
                If CHLList Is Nothing Then
                    CHLList = CHLCtl.DCB_AddNewChannel(New DCB_Channels2.DCB_NewChannelDataPack(IRC_INF, IRC_INF.INF_CMDEXEC & "CHLLIST", "Список каналов", DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFListChannel, DCCtl.DCB_GetTabControl, InterfaceCTLS.DefInstance.pnlLists, Nothing, 0))
                    CHLList.CHLMainMenu = IRC_Interface.mnuMainIRCMenu
                End If
                CHLList.rtflList.Items.Clear()
                CHLList.rtflList.Items.Add("Получение списка каналов, в завимости от размера сети это может занять от 1 до 20 и более минут")
                CHLList.rtflList.ContextMenu = IRC_Interface.mnuCHLList
                Dim TRW As ListView = CHLList.rtflList
                trw.items.Clear()
                CHLListBuffer = New Collection

            Case IRCConst.RPL_LIST
                CHLListBuffer.Add(ParamsString)
                CHLList.tbsCHL.Text = "Список каналов: " & CHLListBuffer.Count
                
            Case IRCConst.RPL_LISTEND
                Dim CHL As DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & "CHLLIST")
                Dim TRW As ListView = CHL.rtflList
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Список каналов получен", DCB_Base.DCB_IRCColors.Blue)
                TRW.BeginUpdate()
                trw.Items.Clear()
                Dim T As String
                Dim L As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem
                For Each T In CHLListBuffer
                    L = New DCB_Controls.DCB_ListViewItem
                    T = T.Trim
                    L.Text = T.Split(Space(1).ToCharArray)(0)
                    L.CMD = "/join " & T.Split(Space(1).ToCharArray)(0)
                    L.CHLName = T.Split(Space(1).ToCharArray)(0)
                    L.DC2Text = T.Substring(T.Split(":"c)(0).Length + 1) ' T.Substring(T.Split(Space(1).ToCharArray)(0).Length + T.Split(Space(1).ToCharArray)(1).Length + 2).TrimStart(":"c)
                    L.SubItems.AddRange(New String() {T.Split(Space(1).ToCharArray)(1), DC2Conv.RemoveIRCCodes(T.Substring(T.Split(":"c)(0).Length + 1))})
                    trw.Items.Add(L)
                Next
                trw.EndUpdate()
        End Select
    End Sub

    Friend Sub IRC_PROCESS_PRIVMSG(ByVal Msg As String, ByVal MsgArray() As String, ByVal ColonSplit() As String, ByVal ParamString As String)
        Dim ToCHL As DCB_Channels2.DCB_Channel
        Dim Usr As DCB_Channels2.DCB_User
        Dim UName As String = IRC_GetUserNameFromPrefix(MsgArray(0).Substring(1))
        If Not Msg.IndexOf(CChar(Chr(1))) = -1 Then
            'Обработка CTCP
            IRC_PROCESS_CTCP(Msg, MsgArray, ParamString, False)
            Exit Sub
        End If


        If MsgArray(2).StartsWith("#") Then
            ToCHL = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & MsgArray(2).ToLower)
            If ToCHL Is Nothing Then
                ToCHL = CHLCtl.DCB_AddNewChannel(New DCB_Channels2.DCB_NewChannelDataPack(IRC_INF, IRC_INF.INF_CMDEXEC & MsgArray(2).Trim(CChar(":")), MsgArray(2).Trim(CChar(":")), DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFChannel, DCCtl.DCB_GetTabControl, InterfaceCTLS.DefInstance.pnlLists, IRC_Interface.ilsIRCIcons, 3))
                ToCHL.txtCHL.ContextMenu = IRC_Interface.mnuPrivCHLMenu
            End If
        Else
            ToCHL = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & UName)
            If ToCHL Is Nothing Then
                ToCHL = CHLCtl.DCB_AddNewChannel(New DCB_Channels2.DCB_NewChannelDataPack(IRC_INF, IRC_INF.INF_CMDEXEC & UName, UName, DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFChannel, DCCtl.DCB_GetTabControl, InterfaceCTLS.DefInstance.pnlLists, IRC_Interface.ilsIRCIcons, 6))
                ToCHL.lstUsers.Enabled = False
                ToCHL.CHLMainMenu = IRC_Interface.mnuMainIRCMenu
                ToCHL.txtCHL.ContextMenu = IRC_Interface.mnuPrivCHLMenu
                ' ---------- USERMODE ---------
                DCSE.ExecScript(IRC_INF.INF_CMDEXEC, "irc_usermodes.dcscript", IRC_Settings.IRCMode.PrivACT, ToCHL.CHLName)
                ' -----------------------------
            End If
        End If
        Usr = USRCtl.DCB_GetUser_UID(IRC_INF.INF_CMDEXEC & UName)
        If Usr Is Nothing Then
            Usr = USRCtl.DCB_AddNewUser(IRC_INF.INF_CMDEXEC & UName, UName, UName, IRC_INF.INF_CMDEXEC)
            If Usr.UserNick <> IRC_Settings.UserInfo.UserCurrentNick Then Usr.UserType = UNI_Plugin.UNI_DChat.DCB_Universal.DCB_LocalUserInfo.UserTypes.USR_StdRemote
            CHLCtl.DCB_JoinUserToChl(Usr.UserID, ToCHL.CHLID)
        End If

        If Not ToCHL.CHLName.StartsWith("#") Then
            CHLCtl.DCB_Talk_UITEM_CHLDCC(Usr, ToCHL, DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, Msg.Substring(MsgArray(0).Length + MsgArray(1).Length + MsgArray(2).Length + 3), CType(IRC_Settings.IRCColors.NormalColor, DCB_Base.DCB_IRCColors), 7)
        Else
            CHLCtl.DCB_Talk_UITEM_CHLDCC(Usr, ToCHL, DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, Msg.Substring(MsgArray(0).Length + MsgArray(1).Length + MsgArray(2).Length + 3), CType(IRC_Settings.IRCColors.NormalColor, DCB_Base.DCB_IRCColors), 4)
        End If
    End Sub
    Friend Sub IRC_PROCESS_NAMEREPLY(ByVal Msg As String, ByVal MsgArray() As String, ByVal ColonSplit() As String, ByVal command As Integer)
        If command = IRCConst.RPL_NAMREPLY Then
            IRC_AddUsrToChannelOnConnect(Msg)
        Else
            If InterfaceCTLS.DefInstance.cmdUsers.Pushed = True Then InterfaceCTLS.DefInstance.cmdList.Text = "Всего: " & DCCtl.DCB_GetCurrentChannelDCC.lstUsers.Items.Count
            DCCtl.DCB_UpdateInterf()
        End If
    End Sub
    Friend Sub IRC_PROCESS_JOIN(ByVal Msg As String, ByVal MsgArray() As String, ByVal ColonSplit() As String)
        Dim ToCHL As DCB_Channels2.DCB_Channel
        Dim Usr As DCB_Channels2.DCB_User

        If CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & MsgArray(2).Trim(CChar(":"))) Is Nothing Then
            ToCHL = CHLCtl.DCB_AddNewChannel(New DCB_Channels2.DCB_NewChannelDataPack(IRC_INF, IRC_INF.INF_CMDEXEC & MsgArray(2).Trim(CChar(":")), MsgArray(2).Trim(CChar(":")), DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFChannel, DCCtl.DCB_GetTabControl, InterfaceCTLS.DefInstance.pnlLists, IRC_Interface.ilsIRCIcons, 4))
            ToCHL.CHLMainMenu = IRC_Interface.mnuMainIRCMenu
            ToCHL.txtCHL.ContextMenu = IRC_Interface.mnuCHLMenu.GetContextMenu
            ' Регистрация обработчика UsersList Menu
            AddHandler ToCHL.lstUsers.MouseDown, AddressOf UsersList_MouseDownEvent
            AddHandler ToCHL.lstUsers.MouseUp, AddressOf UsersList_MouseUpEvent
            Try
                Dim FCHL As IRC_CHLFavorite = CType(IRC_CHLFavoritesCollection.Item(MsgArray(2).Trim(CChar(":"))), IRC_CHLFavorite)
                ToCHL.CHLParams.USESound = FCHL.UseSND
                ToCHL.CHLParams.USEAlarm = FCHL.UseAlarm
            Catch
            End Try
        End If
        IRC_AddJoinedUserToChannel(Msg)
        ToCHL = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & MsgArray(2).Trim(CChar(":"))) : If ToCHL Is Nothing Then Exit Sub
        Usr = USRCtl.DCB_GetUser_UID(IRC_INF.INF_CMDEXEC & IRC_GetUserNameFromPrefix(MsgArray(0).Substring(1))) : If Usr Is Nothing Then Exit Sub
        CHLCtl.DCB_Talk_UUID_ChlDCC(Usr.UserID, ToCHL, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, Usr.UserNick & " вошёл на канал", CType(IRC_Settings.IRCColors.JoinColor, DCB_Base.DCB_IRCColors), 5)
        If InterfaceCTLS.DefInstance.cmdUsers.Pushed = True Then InterfaceCTLS.DefInstance.cmdList.Text = "Всего: " & DCCtl.DCB_GetCurrentChannelDCC.lstUsers.Items.Count
        IRC_SNDMGR_MANAGER(IRC_Declares.IRC_SNDMGR_Events.IRC_SND_JOIN, Usr.UserID)
        DCCtl.DCB_UpdateInterf()
        '
    End Sub
    Friend Sub IRC_PROCESS_PART(ByVal Msg As String, ByVal MsgArray() As String, ByVal ColonSplit() As String)
        Dim ToCHL As DCB_Channels2.DCB_Channel
        Dim Usr As DCB_Channels2.DCB_User
        Dim PartString As String
        Dim PartTxt As String
        Dim PartUsrNick As String

        PartUsrNick = IRC_GetUserNameFromPrefix(MsgArray(0).Substring(1))
        ToCHL = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & MsgArray(2)) : If ToCHL Is Nothing Then Exit Sub
        Usr = USRCtl.DCB_GetUser_UID(IRC_INF.INF_CMDEXEC & PartUsrNick)

        If PartUsrNick = IRC_Settings.UserInfo.UserCurrentNick Then
            Try
                Usr.DelNodeFromTreeview(ToCHL.CHLID)
                CHLCtl.DCB_DelCHL(ToCHL.CHLID)
                Exit Sub
            Catch
            End Try
        End If

        Try
            PartString = Msg.Substring(ColonSplit(1).Length + 1).TrimEnd(Chr(13))
        Catch
            PartString = ""
        End Try
        If PartString = "" Then
            PartTxt = PartUsrNick & " покинул канал"
        Else
            PartTxt = Usr.UserNick & " покинул канал (" & PartString & ")"
        End If
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ToCHL, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, PartTxt, CType(IRC_Settings.IRCColors.PartColor, DCB_Base.DCB_IRCColors), 5)
        IRC_SNDMGR_MANAGER(IRC_Declares.IRC_SNDMGR_Events.IRC_SND_PART, Usr.UserID)
        Try : CHLCtl.DCB_LeaveUserFromCHL(Usr.UserID, ToCHL.CHLID) : Catch : End Try
        'If ToCHL.CHLParams.USESound = True Then IRC_CtlSounds(UInterfaceControl.IRC_SNDS.S_PART)
    End Sub
    Friend Sub IRC_PROCESS_QUIT(ByVal Msg As String, ByVal MsgArray() As String, ByVal ColonSplit() As String)
        Dim ToCHL As DCB_Channels2.DCB_Channel
        Dim Usr As DCB_Channels2.DCB_User
        Dim QuitMsg As String
        Dim usrnam As String
        Dim PlaySND As Boolean = True

        usrnam = IRC_GetUserNameFromPrefix(MsgArray(0).Substring(1))
        Usr = USRCtl.DCB_GetUser_Name(usrnam, IRC_INF.INF_CMDEXEC)
        IRC_SNDMGR_MANAGER(IRC_Declares.IRC_SNDMGR_Events.IRC_SND_QUIT, Usr.UserID)
        Try
            QuitMsg = Msg.Substring(ColonSplit(1).Length + 1).TrimEnd(Chr(13))
            If QuitMsg <> "" Then
                CHLCtl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs(IRC_INF.INF_CMDEXEC & usrnam, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, usrnam & " вышел из IRC (" & QuitMsg & ")", CType(IRC_Settings.IRCColors.Quitcolor, DCB_Base.DCB_IRCColors), 5)
            Else
                CHLCtl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs(IRC_INF.INF_CMDEXEC & usrnam, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "" & IRC_Settings.IRCColors.Quitcolor & usrnam & " вышел из IRC", CType(IRC_Settings.IRCColors.Quitcolor, DCB_Base.DCB_IRCColors), 5)
            End If
        Catch
            CHLCtl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs(IRC_INF.INF_CMDEXEC & usrnam, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "" & IRC_Settings.IRCColors.Quitcolor & usrnam & " вышел из IRC", CType(IRC_Settings.IRCColors.Quitcolor, DCB_Base.DCB_IRCColors), 5)
        End Try
        Try
            USRCtl.DCB_RemoveUser(IRC_INF.INF_CMDEXEC & usrnam)
        Catch
        End Try

        IRC_UpdFriend(usrnam, IRC_Friend.FriendStates.Offline)
    End Sub
    'Friend Sub IRC_CLOSECONNECTION()
    '    Dim ToCHL As DCB_Channels2.DCB_Channel
    '    CHLCtl.DCB_Talk_UID_ALLCHL("0", IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "--== DISCONNECTED ==--")
    'End Sub
    Friend Sub IRC_PROCESS_PING(ByVal Msg As String, ByVal MsgArray() As String, ByVal ColonSplit() As String)
        Dim ToCHL As DCB_Channels2.DCB_Channel
        Dim Usr As DCB_Channels2.DCB_User

        IRC_CMD_PROCESS("irc_sendtoserver PONG " & MsgArray(1).Substring(1))
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "Ping..Pong...", CType(IRC_Settings.IRCColors.NormalColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_TOPIC(ByVal msg As String, ByVal CMD As Integer, ByVal msgarray() As String, ByVal ParamsString As String)
        Select Case CMD
            Case IRCConst.RPL_TOPIC
                Dim CSplit() As String = ParamsString.Split(CChar(":"))
                Dim CHL As DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & CSplit(0).Trim)
                ' CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "Тема на канале: " & CSplit(0) & " : " & CSplit(1))
                If CHL Is Nothing Then Exit Sub

                CHL.CHLTOPIC = ParamsString.Substring(CSplit(0).Length + 1)
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", CHL, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "" & IRC_Settings.IRCColors.TopicColor & "Текущая тема: " & CHL.CHLTOPIC, CType(IRC_Settings.IRCColors.TopicColor, DCB_Base.DCB_IRCColors), 5)
                DCCtl.DCB_UpdateTopicBox()
            Case IRCConst.RPL_TOPIC_CHANGER_NOTRFC
                Dim SPLIT() As String = ParamsString.Split
                Dim CHL As DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & SPLIT(1).Trim)
                'Dim UName As String = IRC_GetUserNameFromPrefix(SPLIT(1))
                Dim Dat As String = GetDateFromIRCStd(SPLIT(3))
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", CHL, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "Тему установил " & SPLIT(2).TrimStart(CChar(":")) & ", " & Dat, CType(IRC_Settings.IRCColors.TopicColor, DCB_Base.DCB_IRCColors), 5)
            Case IRCConst.RPL_NOTOPIC
                Try
                    CHLCtl.DCB_Talk_UUID_CHLID("0", IRC_INF.INF_CMDEXEC & msgarray(3), DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Тема не установлена", CType(IRC_Settings.IRCColors.TopicColor, DCB_Base.DCB_IRCColors), 5)
                Catch
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "На канале " & msgarray(3) & " тема не установлена", CType(IRC_Settings.IRCColors.TopicColor, DCB_Base.DCB_IRCColors), 5)
                End Try
            Case 9000 ' Изменение темы
                Dim Changer As String = IRC_GetUserNameFromPrefix(msgarray(0).TrimStart(":"c))
                Dim CHL As String = msgarray(2)
                Dim CHLdcc As DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & chl)

                Dim Topic As String = msg.Substring(msg.Split(CChar(":"))(0).Length + 1)
                CHLCtl.DCB_Talk_UUID_CHLID("0", IRC_INF.INF_CMDEXEC & chl, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, Changer & " изменил тему: " & Topic, CType(IRC_Settings.IRCColors.TopicColor, DCB_Base.DCB_IRCColors), 5)
                CHLdcc.CHLTOPIC = Topic
                DCCtl.DCB_UpdateTopicBox()
                If frmCHLInfo.DefInstance.CURCHL = chl Then frmCHLInfo.DefInstance.txtCHLTopic.Rtf = DC2Conv.dc2toRTF(Topic, IRC_Settings.IRCFont, IRC_Settings.IRCFontSize.ToString)
                IRC_SNDMGR_MANAGER(IRC_Declares.IRC_SNDMGR_Events.IRC_SND_TOPIC, chl)

        End Select
    End Sub
    Friend Sub IRC_PROCESS_ISUPPORT(ByVal Msg As String, ByVal Paramsstring As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, Paramsstring, DCB_Base.DCB_IRCColors.Blue)
        ' Составление расширенной информации о сервере
        Dim PARAMS As String() = Paramsstring.Split()
        Dim Tmp As String
        For Each Tmp In PARAMS
            If Tmp.StartsWith(":are") Then Exit Sub
            If Tmp <> "" Then
                If Tmp.IndexOf("=") > 0 Then
                    IRC_CurServerISUPPORT.Add(Tmp.Split("="c)(0), Tmp.Split("="c)(1))
                Else
                    IRC_CurServerISUPPORT.Add(Tmp, "N/A")
                End If
            End If
        Next
    End Sub
    Friend Sub IRC_PROCESS_CHANNELMODEIS(ByVal Msg As String, ByVal msgarray() As String, ByVal Paramsstring As String)
        Dim Keys As String = Paramsstring.Trim.Split(Space(1).ToCharArray)(1)
        With frmCHLInfo.DefInstance
            .CURCHL = Paramsstring.Trim.Split(Space(1).ToCharArray)(0)
            If Keys.IndexOf("t") > 0 Then .chkModT.Checked = True Else .chkModT.Checked = False
            If Keys.IndexOf("n") > 0 Then .chkModN.Checked = True Else .chkModN.Checked = False
            If Keys.IndexOf("i") > 0 Then .chkModI.Checked = True Else .chkModI.Checked = False
            If Keys.IndexOf("m") > 0 Then .chkModM.Checked = True Else .chkModM.Checked = False
            If Keys.IndexOf("p") > 0 Then .chkModP.Checked = True Else .chkModP.Checked = False
            If Keys.IndexOf("s") > 0 Then .chkModS.Checked = True Else .chkModS.Checked = False
            If Keys.IndexOf("k") > 0 Then
                .chkModK.Checked = True
                If Keys.IndexOf("l") > 0 Then
                    .txtPass.Text = Paramsstring.Trim.Split(Space(1).ToCharArray)(3)
                Else
                    .txtPass.Text = Paramsstring.Trim.Split(Space(1).ToCharArray)(2)
                End If
            Else
                .chkModK.Checked = False
                .txtPass.Text = ""
            End If
            If Keys.IndexOf("l") > 0 Then
                .chkModL.Checked = True
                .txtL.Text = Paramsstring.Trim.Split(Space(1).ToCharArray)(2)
            Else
                .chkModL.Checked = False
                .txtL.Text = ""
            End If
            .chkModT.Tag = ""
            .chkModN.Tag = ""
            .chkModI.Tag = ""
            .chkModM.Tag = ""
            .chkModP.Tag = ""
            .chkModS.Tag = ""
            .chkModK.Tag = ""
            .chkModL.Tag = ""
        End With
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, Paramsstring.Trim, DCB_Base.DCB_IRCColors.Blue)
    End Sub
    Friend Sub IRC_PROCESS_INVITELIST(ByVal cmd As Integer, ByVal Msg As String, ByVal Msgarray() As String, ByVal Paramsstring As String)
        Static FView As Boolean = True
        If FView = True Then frmCHLInfo.DefInstance.lstInvites.Nodes.Clear() : FView = False

        Select Case cmd
            Case IRCConst.RPL_INVITELIST
                Dim a As String = ""
                Try : a = GetDateFromIRCStd(Msgarray(6)) : Catch : End Try
                Dim z As New TreeNode
                z.Text = Msgarray(4) & "  Установил: " & Msgarray(5) & " " & a
                z.Tag = Msgarray(4)
                frmCHLInfo.DefInstance.lstInvites.Nodes.Add(z)
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, Paramsstring, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_ENDOFINVITELIST
                FView = True
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXT_NOTUNAME, "------------------------", DCB_Base.DCB_IRCColors.Blue)
        End Select

    End Sub
    Friend Sub IRC_PROCESS_EXCEPTLIST(ByVal cmd As Integer, ByVal Msg As String, ByVal Msgarray() As String, ByVal Paramsstring As String)
        Static FView As Boolean = True
        If FView = True Then frmCHLInfo.DefInstance.lstExceptions.Nodes.Clear() : FView = False

        Select Case cmd
            Case IRCConst.RPL_EXCEPTLIST
                Dim a As String = ""
                Try : a = GetDateFromIRCStd(Msgarray(6)) : Catch : End Try
                Dim z As New TreeNode
                z.Text = Msgarray(4) & "  Установил: " & Msgarray(5) & " " & a
                z.Tag = Msgarray(4)
                frmCHLInfo.DefInstance.lstExceptions.Nodes.Add(z)
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, Paramsstring, DCB_Base.DCB_IRCColors.Blue)

            Case IRCConst.RPL_ENDOFEXCEPTLIST
                FView = True
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXT_NOTUNAME, "------------------------", DCB_Base.DCB_IRCColors.Blue)
        End Select

    End Sub
    Friend Sub IRC_PROCESS_UNIQOPIS(ByVal Msg As String, ByVal Paramsstring As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, Paramsstring, DCB_Base.DCB_IRCColors.Blue)
    End Sub

    Friend Sub IRC_PROCESS_LUSER(ByVal Command As Integer, ByVal Msg As String, ByVal ParamString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, ParamString, DCB_Base.DCB_IRCColors.Blue)
        If Command = IRCConst.RPL_LUSERME Then
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, " ", DCB_Base.DCB_IRCColors.Blue)
        End If
    End Sub
    Friend Sub IRC_PROCESS_RESERVE(ByVal Command As Integer, ByVal Msg As String)

        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, Msg, DCB_Base.DCB_IRCColors.Maroon)
    End Sub
    Friend Sub IRC_PROCESS_NOTICE(ByVal Msg As String, ByVal MsgArray() As String, ByVal ColonSplit() As String, ByVal paramsstring As String)
        Dim ToChl As DCB_Channels2.DCB_Channel
        Dim usr As DCB_Channels2.DCB_User
        Dim Usrname As String
        If MsgArray(0) <> "" Then IRC_GetUserNameFromPrefix(MsgArray(0).Substring(1))
        IRC_PROCESS_CTCP(Msg, MsgArray, paramsstring, True)
        '---
        '------------------------
        ' Поддержка QMWindow
        If paramsstring.Trim.StartsWith("[QMSG]") And paramsstring.TrimStart.Length > 6 Then
            Dim QWM As New frmMessage(Usrname, frmMessage.QuickMsgInitTypes.QW_NEW_READ, paramsstring.Trim.Substring("[QMSG]".Length + 1))

            If IRC_Settings.IRCMode.GPARAMS.Split()(1) = "1" Then
                QWM.Show()
                QWM.Activate()
            Else
                QWM.Visible = True
            End If
            Exit Sub
        End If
        '------------------------
        '---

        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "- " & Usrname & " - " & Msg.Substring(ColonSplit(0).Length + ColonSplit(1).Length + 1), DCB_Base.DCB_IRCColors.Purple)

    End Sub
    Friend Sub IRC_PROCESS_MOTD(ByVal command As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal Paramsstring As String)
        Select Case command
            Case IRCConst.RPL_MOTDSTART
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "----------------------------------------------------", DCB_Base.DCB_IRCColors.Red)
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, Paramsstring, DCB_Base.DCB_IRCColors.Red)
            Case IRCConst.RPL_MOTD
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, Paramsstring, DCB_Base.DCB_IRCColors.Red)
            Case IRCConst.RPL_ENDOFMOTD
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, Paramsstring, DCB_Base.DCB_IRCColors.Red)
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "----------------------------------------------------", DCB_Base.DCB_IRCColors.Red)
        End Select
    End Sub
    Friend Sub IRC_PROCESS_MODE(ByVal Msg As String, ByVal msgarray() As String, ByVal ParamsString As String)
        Dim USRName As String = msgarray(0)
        Dim USRNameUID As String = IRC_GetUserNameFromPrefix(USRName).Trim.TrimStart(CChar(":"))
        Dim FullString As String = Msg.Substring(msgarray(0).Length + msgarray(1).Length)
        If msgarray(2).StartsWith("#") Then
            Dim USRs As String = ParamsString.Substring(msgarray(3).Length + 2).Trim
            CHLCtl.DCB_Talk_UUID_CHLID("0", IRC_INF.INF_CMDEXEC & msgarray(2), DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, USRNameUID & " Устанавливает флаг " & FullString.Substring(msgarray(2).Length + 1), CType(IRC_Settings.IRCColors.ModeColor, DCB_Base.DCB_IRCColors), 5)
            IRC_CheckUserMode_Step1(msgarray(2), msgarray(3), USRs)
        Else
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, USRNameUID & " Устанавливает флаг " & ParamsString, CType(IRC_Settings.IRCColors.ModeColor, DCB_Base.DCB_IRCColors), 5)
        End If
    End Sub
    Friend Sub IRC_PROCESS_CTCP(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String, ByVal IsReply As Boolean)
        If (MsgArray(3).Substring(1).ToUpper.StartsWith(Chr(1) & "VERSION")) Then
            Try
                If IsReply = True Then
                    frmUserInfo.DefInstance.txtCTCPReply.Text = ParamsString.Split(Chr(1))(1).Substring(8).TrimEnd(Chr(1))
                Else
                    IRC_USRTOOL_NOTICE_Send(IRC_GetUserNameFromPrefix(MsgArray(0).Trim(CChar(":"))), Chr(1) & "VERSION " & System.Windows.Forms.Application.ProductVersion & Chr(1)) ' '& IRC_INF.INF_NAME & " " & IRC_INF.INF_VER.ToString & Chr(1))
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, IRC_GetUserNameFromPrefix(MsgArray(0).Trim(CChar(":"))) & "[CTCP VERSION]", CType(IRC_Settings.IRCColors.CTCPColor, DCB_Base.DCB_IRCColors))

                End If
            Catch
            End Try
        ElseIf (MsgArray(3).Substring(1).ToUpper.StartsWith(Chr(1) & "TIME")) Then
            Try
                If IsReply = True Then
                    frmUserInfo.DefInstance.txtCTCPReply.Text = ParamsString.Split(Chr(1))(1).Substring(4).TrimEnd(Chr(1))
                Else
                    IRC_USRTOOL_NOTICE_Send(IRC_GetUserNameFromPrefix(MsgArray(0).Trim(CChar(":"))), Chr(1) & "TIME " & Today.DayOfWeek.ToString & " " & TimeOfDay & " " & Today & " " & Chr(1))
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, IRC_GetUserNameFromPrefix(MsgArray(0).Trim(CChar(":"))) & "[CTCP TIME]", CType(IRC_Settings.IRCColors.CTCPColor, DCB_Base.DCB_IRCColors))

                End If
            Catch
            End Try
        ElseIf (MsgArray(3).Substring(1).ToUpper.StartsWith(Chr(1) & "PING")) Then
            IRC_USRTOOL_NOTICE_Send(IRC_GetUserNameFromPrefix(MsgArray(0).Trim(CChar(":"))), Chr(1) & "PING " & MsgArray(4).Trim)
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, IRC_GetUserNameFromPrefix(MsgArray(0).Trim(CChar(":"))) & "[CTCP PING]", CType(IRC_Settings.IRCColors.CTCPColor, DCB_Base.DCB_IRCColors))

        ElseIf (MsgArray(3).Substring(1).ToUpper.StartsWith(Chr(1) & "FINGER" & Chr(1))) Then
            IRC_USRTOOL_NOTICE_Send(IRC_GetUserNameFromPrefix(MsgArray(0).Trim(CChar(":"))), Chr(1) & "FINGER Finger reply... ну ты потыкай, потыкай" & Chr(1))
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, IRC_GetUserNameFromPrefix(MsgArray(0).Trim(CChar(":"))) & "[CTCP FINGER]", CType(IRC_Settings.IRCColors.CTCPColor, DCB_Base.DCB_IRCColors))

        ElseIf (MsgArray(3).Substring(1).ToUpper.StartsWith(Chr(1) & "FINGER")) Then
            frmUserInfo.DefInstance.txtCTCPReply.Text = ParamsString.Split(Chr(1))(1).Substring(6).TrimEnd(Chr(1))

        ElseIf (MsgArray(3).Substring(1).ToUpper.StartsWith(Chr(1) & "SOUND")) Then
            Dim sndTO As String = MsgArray(2)
            Dim toCHL As DCB_Channels2.DCB_Channel
            Dim snd As String = ParamsString.Substring("sound".Length + 2).TrimEnd.TrimEnd(Chr(1)).Trim
            Dim usr As String = IRC_GetUserNameFromPrefix(MsgArray(0)).Substring(1)
            If sndTO = IRC_Settings.UserInfo.UserCurrentNick Then
                Try
                    CHLCtl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs(IRC_INF.INF_CMDEXEC & usr, IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Сигнал от: " & usr & " " & snd, CType(IRC_Settings.IRCColors.ActionColor, DCB_Base.DCB_IRCColors))
                Catch
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Сигнал от: " & usr & " " & snd, CType(IRC_Settings.IRCColors.ActionColor, DCB_Base.DCB_IRCColors))
                End Try
            Else
                toCHL = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & sndTO)
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", toCHL, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "[" & sndTO & "] Сигнал от: " & usr & " " & snd, CType(IRC_Settings.IRCColors.ActionColor, DCB_Base.DCB_IRCColors))
            End If
            If IRC_Settings.SND_UseCTCP = False Then Exit Sub
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & snd)
        ElseIf (MsgArray(3).Substring(1).ToUpper.StartsWith(Chr(1) & "ACTION")) Then
            Dim UID As String = IRC_INF.INF_CMDEXEC & IRC_GetUserNameFromPrefix(MsgArray(0))
            Dim CHLID As String = IRC_INF.INF_CMDEXEC & MsgArray(2)
            Dim Actmsg As String = UID.Substring(IRC_INF.INF_CMDEXEC.Length + 1) & ParamsString.Substring(8).TrimEnd.TrimEnd(Chr(1))
            CHLCtl.DCB_Talk_UUID_CHLID(UID, CHLID, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, Actmsg, CType(IRC_Settings.IRCColors.ActionColor, DCB_Base.DCB_IRCColors), 4)

        End If
    End Sub
    Friend Sub IRC_PROCESS_KICK(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim UsrName As String = IRC_GetUserNameFromPrefix(MsgArray(0)).TrimStart(CChar(":"))
        Dim Chlname As String = MsgArray(2)
        Dim whokicked As String = MsgArray(3)
        Dim Param As String
        Param = Msg.Split(CChar(":"))(1).TrimEnd
        If whokicked = IRC_Settings.UserInfo.UserCurrentNick Then
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, UsrName & " кикнул вас с канала: " & Chlname & ". По причине: " & Param, DCB_Base.DCB_IRCColors.Red)
            CHLCtl.DCB_DelCHL(IRC_INF.INF_CMDEXEC & Chlname)
        Else
            If Param <> "" Then Param = " (" & Param & ")"
            CHLCtl.DCB_Talk_UUID_CHLID("0", IRC_INF.INF_CMDEXEC & Chlname, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, UsrName & " кикнул " & whokicked & Param, CType(IRC_Settings.IRCColors.KickColor, DCB_Base.DCB_IRCColors))
            Try
                CHLCtl.DCB_LeaveUserFromCHL(IRC_INF.INF_CMDEXEC & whokicked, IRC_INF.INF_CMDEXEC & Chlname)
            Catch
            End Try
        End If
        IRC_SNDMGR_MANAGER(IRC_Declares.IRC_SNDMGR_Events.IRC_SND_KICK, IRC_INF.INF_CMDEXEC & UsrName)
    End Sub
    Friend Sub IRC_PROCESS_VERSION(ByVal msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim FullParams As String = msg.Substring(MsgArray(0).Length + MsgArray(1).Length + MsgArray(2).Length)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-------------Server Version--------------", DCB_Base.DCB_IRCColors.Green)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, FullParams, DCB_Base.DCB_IRCColors.Green)
    End Sub
    Friend Sub IRC_PROCESS_TRYAGAIN(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UID_ALL_PLUGIN_CHLs("0", IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_WARNING, Msg, DCB_Base.DCB_IRCColors.Red)
    End Sub
    Friend Sub IRC_PROCESS_ADMIN(ByVal cmd As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Select Case cmd
            Case IRCConst.RPL_ADMINME
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Red)
            Case IRCConst.RPL_ADMINME, IRCConst.RPL_ADMINLOC1, IRCConst.RPL_ADMINLOC2
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Green)
            Case IRCConst.RPL_ADMINEMAIL
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "mailto:" & ParamsString.Trim, DCB_Base.DCB_IRCColors.Green)
        End Select
    End Sub
    Friend Sub IRC_PROCESS_UMODEIS(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)

        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Флаги пользователя: " & MsgArray(2) & " " & ParamsString, DCB_Base.DCB_IRCColors.Green)
    End Sub
    Friend Sub IRC_PROCESS_TIME(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)

        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Текущее время на сервере: " & ParamsString, DCB_Base.DCB_IRCColors.Green)
    End Sub
    Friend Sub IRC_PROCESS_REHASHING(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
    End Sub
    Friend Sub IRC_PROCESS_YOURESERVICE(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
    End Sub
    Friend Sub IRC_PROCESS_USERHOST(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
    End Sub
    Friend Sub IRC_PROCESS_ISON(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
    End Sub

    Friend Sub IRC_PROCESS_WHOWAS(ByVal cmd As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Static FirstView As Boolean = True
        If FirstView = True Then
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Информация (Whowas): " & MsgArray(3), DCB_Base.DCB_IRCColors.Blue)
            FirstView = False
        End If
        Select Case cmd
            Case IRCConst.RPL_WHOWASUSER
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_ENDOFWHOWAS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-------------------------------", DCB_Base.DCB_IRCColors.Blue)
                FirstView = True
        End Select
    End Sub
    Friend Sub IRC_PROCESS_WHO(ByVal cmd As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Static FirstView As Boolean = True
        If FirstView = True Then
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Информация (Who): " & MsgArray(3), DCB_Base.DCB_IRCColors.Blue)
            FirstView = False

        End If
        Select Case cmd
            Case IRCConst.RPL_WHOREPLY
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_ENDOFWHO
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-------------------------------", DCB_Base.DCB_IRCColors.Blue)
                FirstView = True
        End Select
    End Sub
    Friend Sub IRC_PROCESS_LINKS(ByVal cmd As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Static FirstView As Boolean = True
        If FirstView = True Then
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "--Список серверов сети--", DCB_Base.DCB_IRCColors.Blue)
            FirstView = False
        End If
        Select Case cmd
            Case IRCConst.RPL_LINKS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_ENDOFLINKS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-------------------------------", DCB_Base.DCB_IRCColors.Blue)
                FirstView = True
        End Select
    End Sub
    Friend Sub IRC_PROCESS_USERS(ByVal cmd As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Select Case cmd
            Case IRCConst.RPL_USERSSTART
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "--Список пользователей--", DCB_Base.DCB_IRCColors.Blue)
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_USERS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_ENDOFUSERS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-------------------------------", DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_NOUSERS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
        End Select
    End Sub
    Friend Sub IRC_PROCESS_TRACE(ByVal cmd As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Select Case cmd
            Case IRCConst.RPL_TRACECLASS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACECONNECTING
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACEEND
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACEHANDSHAKE
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACELINK
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACELOG
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACENEWTYPE
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACEOPERATOR
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACERECONNECT
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACESERVER
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACESERVICE
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACEUNKNOWN
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_TRACEUSER
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
        End Select
    End Sub
    Friend Sub IRC_PROCESS_BANLIST(ByVal cmd As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Static FirstView As Boolean = True
        If FirstView = True Then
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "--Список банов канала: " & MsgArray(3) & " --", DCB_Base.DCB_IRCColors.Blue)
            FirstView = False
            frmCHLInfo.DefInstance.lstBans.Nodes.Clear()
        End If
        Select Case cmd
            Case IRCConst.RPL_BANLIST
                Dim a As String = ""
                Try : a = GetDateFromIRCStd(MsgArray(6)) : Catch : End Try
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Бан на: " & MsgArray(4) & "  Установил: " & MsgArray(5) & " " & a, DCB_Base.DCB_IRCColors.Blue)
                Dim z As New TreeNode
                z.Text = MsgArray(4) & "  Установил: " & MsgArray(5) & " " & a
                z.Tag = MsgArray(4)
                frmCHLInfo.DefInstance.lstBans.Nodes.Add(z)
            Case IRCConst.RPL_ENDOFBANLIST
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-------------------------------", DCB_Base.DCB_IRCColors.Blue)
                FirstView = True
        End Select
    End Sub
    Friend Sub IRC_PROCESS_STATS(ByVal cmd As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Select Case cmd
            Case IRCConst.RPL_STATSUPTIME
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_STATSCOMMANDS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_STATSLINKINFO
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_STATSOLINE
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
            Case IRCConst.RPL_ENDOFSTATS
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
        End Select
    End Sub
    Friend Sub IRC_PROCESS_WHOIS(ByVal CMD As Integer, ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Static FirstView As Boolean = True

        If FirstView = True And CMD <> IRCConst.RPL_WHOISSERVER Then
            If IRC_BLOCKWHOISVIEW = False Then
                frmUserInfo.DefInstance.txtUserNick.Text = MsgArray(3)
                frmUserInfo.DefInstance.txtStatus.Text = "Normal User"
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Информация (Whois): " & MsgArray(3), CType(IRC_Settings.IRCColors.WhoisColor, DCB_Base.DCB_IRCColors))
                ' IRC_UpdFriend(MsgArray(3), IRC_Friend.FriendStates.Active)
            End If
            FirstView = False

        End If

        Select Case CMD
            Case IRCConst.RPL_WHOISCHANNELS
                ParamsString = ParamsString.Substring(MsgArray(3).Length + 1).Trim.TrimStart(CChar(":"))
                If IRC_BLOCKWHOISVIEW = False Then
                    frmUserInfo.DefInstance.txtChannels.Text = ParamsString.Trim
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, CType(IRC_Settings.IRCColors.WhoisColor, DCB_Base.DCB_IRCColors))
                End If

            Case IRCConst.RPL_WHOISIDLE
                ParamsString = ParamsString.Substring(MsgArray(3).Length + 1)
                Dim Dat As String = GetDateFromIRCStd(MsgArray(5))
                Dim tim As String = TimeSpan.FromSeconds(Val(MsgArray(4))).ToString
                If IRC_BLOCKWHOISVIEW = False Then
                    frmUserInfo.DefInstance.txtIdle.Text = tim.Trim
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Has been idle:" & tim & ", signed on: " & Dat, CType(IRC_Settings.IRCColors.WhoisColor, DCB_Base.DCB_IRCColors))

                End If
                IRC_UpdFriend(MsgArray(3), IRC_Friend.FriendStates.Active)
            Case IRCConst.RPL_WHOISOPERATOR
                If IRC_BLOCKWHOISVIEW = False Then
                    frmUserInfo.DefInstance.txtStatus.Text = ParamsString.Trim
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, CType(IRC_Settings.IRCColors.WhoisColor, DCB_Base.DCB_IRCColors))
                End If
            Case IRCConst.RPL_WHOISSERVER
                ParamsString = ParamsString.Substring(MsgArray(3).Length + 1).Trim
                If IRC_BLOCKWHOISVIEW = False Then
                    frmUserInfo.DefInstance.txtServer.Text = ParamsString.Trim
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, CType(IRC_Settings.IRCColors.WhoisColor, DCB_Base.DCB_IRCColors))
                End If
            Case IRCConst.RPL_ACTUALLY_NOTRFC
                ParamsString = ParamsString.Substring(MsgArray(3).Length + 1).Trim
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, CType(IRC_Settings.IRCColors.WhoisColor, DCB_Base.DCB_IRCColors))
            Case IRCConst.RPL_WHOISUSER
                Dim SPL() As String = ParamsString.Split
                Dim RealName As String = ParamsString.Split(CChar(":"))(1)
                If IRC_BLOCKWHOISVIEW = False Then
                    frmUserInfo.DefInstance.txtAddress.Text = SPL(2) & "@" & SPL(3)
                    frmUserInfo.DefInstance.txtRealName.Text = RealName.Trim
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, CType(IRC_Settings.IRCColors.WhoisColor, DCB_Base.DCB_IRCColors))
                End If
            Case IRCConst.RPL_ENDOFWHOIS
                FirstView = True
                If IRC_BLOCKWHOISVIEW = False Then
                    frmUserInfo.DefInstance.Show()
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-------------------------------", CType(IRC_Settings.IRCColors.WhoisColor, DCB_Base.DCB_IRCColors))
                Else
                    IRC_BLOCKWHOISVIEW = False
                End If


        End Select
    End Sub


    Friend Sub IRC_PROCESS_CHLCREATIONTIME_NOTRFC(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim CHLnam As String = MsgArray(3)
        Dim CRDat As String = GetDateFromIRCStd(MsgArray(4))
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Канал: " & CHLnam & " Создан:" & CRDat, DCB_Base.DCB_IRCColors.Green)
    End Sub
    Friend Sub IRC_PROCESS_INFO(ByVal command As Integer, ByVal MsgArray() As String, ByVal ParamsString As String)
        Static IsFirst As Boolean = True
        Select Case command
            Case IRCConst.RPL_INFO
                If IsFirst Then
                    IsFirst = False
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-----------Server Info-------------------", DCB_Base.DCB_IRCColors.Blue)
                Else
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, ParamsString, DCB_Base.DCB_IRCColors.Blue)
                End If

            Case IRCConst.RPL_ENDOFINFO
                IsFirst = True
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "-----------------------------------------", DCB_Base.DCB_IRCColors.Blue)
        End Select

    End Sub
#End Region
#Region " ERR "
    ' ---------------------------- ERR -----------------------
    Friend Sub IRC_PROCESS_ERR_NICKNAMEINUSE(ByVal Msg As String)
        If IRC_FirstNickInit = True Then
            If IRC_AltNickIsSet = False Then
                IRC_USRTOOL_ChangeNick(IRC_Settings.UserInfo.UserAltNick)
                IRC_AltNickIsSet = True
                CHLCtl.DCB_Talk_UID_ALL_PLUGIN_CHLs("0", IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_ERROR, "Указанное имя уже используется, установка Альтернативного ника (" & IRC_Settings.UserInfo.UserAltNick & ")", DCB_Base.DCB_IRCColors.Red)
            Else
                Dim newnick As String = "DC" & CStr(Int(Rnd() * 10000))
                CHLCtl.DCB_Talk_UID_ALL_PLUGIN_CHLs("0", IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_ERROR, "Указанное имя уже используется...устанавливаю случайный ник (" & newnick & ")", DCB_Base.DCB_IRCColors.Red)
                IRC_USRTOOL_ChangeNick(newnick)
            End If
        Else
            If DCCtl.DCB_GetCurrentPluginID = IRC_INF.INF_CMDEXEC Then DCCtl.DCB_GetNickTextBox.Text = IRC_Settings.UserInfo.UserCurrentNick
            CHLCtl.DCB_Talk_UID_ALL_PLUGIN_CHLs("0", IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_ERROR, "Указанный ник уже занят.", DCB_Base.DCB_IRCColors.Red)
        End If
        DCCtl.DCB_UpdateInterf()
    End Sub
    Friend Sub IRC_PROCESS_ERR_BAN(ByVal MSg As String, ByVal Msgarray() As String, ByVal Paramsstring As String)
        Dim ChlName As String = Msgarray(3)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Вы не можете подключится к " & ChlName & ", вас забанили (+b)", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_CHANNELISFULL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim ChlName As String = MsgArray(3)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Вы не можете подключится к " & ChlName & " , количество пользователей на канале достигло максимума (+l)", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub

    Friend Sub IRC_PROCESS_ERR_INVITEONLYCHAN(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim ChlName As String = MsgArray(3)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Вы не можете подключится к " & ChlName & " , доступ к каналу возможен только по приглашению (+i)", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_BADCHANNELKEY(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim ChlName As String = MsgArray(3)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Вы не можете подключится к " & ChlName & " , Неверно указан пароль к каналу (+k)", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_CHANOPRIVSNEEDED(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        Dim ChlName As String = MsgArray(3)
        Try
            CHLCtl.DCB_Talk_UUID_CHLID("0", IRC_INF.INF_CMDEXEC & ChlName, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Для выполнения этого действия вам необходимы привелегии оператора канала", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
        Catch
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Для выполнения этого действия вам необходимы привелегии оператора канала", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
        End Try

    End Sub

    Friend Sub IRC_PROCESS_ERR_NEEDMOREPARAMS(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOSUCHNICK(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOSUCHSERVER(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Указанный сервер не существует", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOSUCHCHANNEL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Неверно указано имя канала", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_CANNOTSENDTOCHAN(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_TOOMANYCHANNELS(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_WASNOSUCHNICK(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_TOOMANYTARGETS(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        ' ВНИМАНИЕ ПОМЕНЯТЬ ФОРМАТ!!!!"<target> :<error code> recipients. <abort message>"
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOSUCHSERVICE(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOORIGIN(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        'ПРОВЕРИТЬ ФОРМАТ!
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NORECIPIENT(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        'ПРОВЕРИТЬ ФОРМАТ
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOTEXTTOSEND(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        ' ПРОВЕРИТЬ ФОРМАТ
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOTOPLEVEL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_WILDTOPLEVEL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_BADMASK(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_UNKNOWNCOMMAND(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOMOTD(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOADMININFO(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_FILEERROR(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        ' ФОРМАТ!
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NONICKNAMEGIVEN(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        ' ФОРМАТ!
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_ERRONEUSNICKNAME(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        If DCCtl.DCB_GetCurrentPluginID = IRC_INF.INF_CMDEXEC Then DCCtl.DCB_GetNickTextBox.Text = IRC_Settings.UserInfo.UserCurrentNick
        CHLCtl.DCB_Talk_UID_ALL_PLUGIN_CHLs("0", IRC_INF.INF_CMDEXEC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Указан недопустимый ник!", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))

        If IRC_FirstNickInit = True Then
            If IRC_AltNickIsSet = False Then
                IRC_USRTOOL_ChangeNick(IRC_Settings.UserInfo.UserAltNick)
                IRC_AltNickIsSet = True
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_ERROR, "Указанное имя уже используется, установка Альтернативного ника (" & IRC_Settings.UserInfo.UserAltNick & ")", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
            Else
                Dim newnick As String = "DC" & CStr(Int(Rnd() * 10000))
                CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_ERROR, "Указанное имя уже используется...устанавливаю случайный ник (" & newnick & ")", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
                IRC_USRTOOL_ChangeNick(newnick)
            End If
        End If
    End Sub
    Friend Sub IRC_PROCESS_ERR_NICKCOLLISION(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        If DCCtl.DCB_GetCurrentPluginID = IRC_INF.INF_CMDEXEC Then DCCtl.DCB_GetNickTextBox.Text = IRC_Settings.UserInfo.UserCurrentNick
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_UNAVAILRESOURCE(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        ' ФОРМАТ!
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_USERNOTINCHANNEL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        ' ФОРМАТ!
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOOPERHOST(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOTONCHANNEL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Неверно указано имя канала", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOPRIVILEGES(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "У вас недостаточно прав для выполнения этого действия", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub

    Friend Sub IRC_PROCESS_ERR_YOUREBANNEDCREEP(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub

    Friend Sub IRC_PROCESS_ERR_YOUWILLBEBANNED(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub

    Friend Sub IRC_PROCESS_ERR_KEYSET(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Пароль на канал " & ParamsString.Split(CChar(":"))(0) & " уже установлен", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub

    Friend Sub IRC_PROCESS_ERR_USERSDONTMATCH(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Вы не можете изменять флаги других пользователей", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_UMODEUNKNOWNFLAG(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Указан неизвестный флаг", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub

    Friend Sub IRC_PROCESS_ERR_CANTKILLSERVER(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_RESTRICTED(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_UNIQOPPRIVSNEEDED(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_BADCHANMASK(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOCHANMODES(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_BANLISTFULL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_USERONCHANNEL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOLOGIN(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_SUMMONDISABLED(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_USERSDISABLED(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOTREGISTERED(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_ALREADYREGISTRED(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_NOPERMFORHOST(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_PASSWDMISMATCH(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_WARNING, "Неверно указан пароль", CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
    End Sub
    Friend Sub IRC_PROCESS_ERR_ALREADYONCHL(ByVal Msg As String, ByVal MsgArray() As String, ByVal ParamsString As String)
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_TXT_NOTUNAME, ParamsString, CType(IRC_Settings.IRCColors.HighlightColor, DCB_Base.DCB_IRCColors))
        Dim CHL As DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & ParamsString.Trim.Split(Space(1).ToCharArray)(0))
        If CHL Is Nothing Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc.dcscript Rejoin " & ParamsString.Trim.Split(Space(1).ToCharArray)(0)) : Exit Sub
        DCCtl.DCB_GetTabControl.SelectedTab = CHL.tbsCHL
    End Sub
#End Region
End Module