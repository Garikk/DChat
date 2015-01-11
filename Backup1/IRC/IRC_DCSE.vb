' DZFS.NET 2004
' DChat Project
' IRC-DCSE
'------------------------------------------------------------------------------------
' Programmed by Garikk
' IRC_DCSE Commands Processor
'------------------------------------------------------------------------------------
Imports UNI_Plugin.UNI_DChat
Imports System.Windows.Forms
Module IRC_DCSE
    Friend IRCScripts As New Collection
    Friend IRC_BLOCKWHOISVIEW As Boolean
    'Friend WithEvents IRC_Timer As New Timer
    '  Friend FrUpdTimer As Collection
    ' Friend WithEvents FriendsUpdTimer As New Windows.Forms.Timer
    'Список ссылок на процедуры
 
    Friend Structure IRC_SCRIPT_CONSTANTS
        Const IRC_SCRIPT_STSERV As String = "irc_sendtoserver "
        Const IRC_SCRIPT_PRINTINCON As String = "irc_printincon "
        Const IRC_SCRIPT_CONNECT As String = "irc_connect"
        Const IRC_SCRIPT_PLINTINCHL As String = "irc_printinchl "
        Const IRC_SCRIPT_TALK As String = "irc_talk "
        Const IRC_SCRIPT_TALK_CHL As String = "irc_talkinchl "
        Const IRC_SCRIPT_CLOSE As String = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Plugins.DCB_UNIPluginNotify.DCB_Pluginquit
        Const IRC_SCRIPT_CHTOPIC As String = "chtopic"
        Const IRC_SCRIPT_CHNICK As String = "chnick"
        Const IRC_CONST_MYSCRIPT As String = "irc.dcscript"
        Const IRC_PMGR_CMD As String = "/irccmd"
        Dim Tag As String
    End Structure

    Friend Function IRC_CMD_FUNC(ByVal CMD As String) As Object

        If CMD.StartsWith(IRC_INF.INF_CMDEXEC) Then CMD = CMD.Substring(IRC_INF.INF_CMDEXEC.Length).Trim
        ' Выносим объекты относящиеся к запросам DCB отдельно
        If CMD.ToUpper.StartsWith("DCB_") Then Return IRC_CMDFO_DCBCMDS(CMD)
        ' свои  объекты
        Select Case CMD.ToLower
            Case "ircgui_getservpnl"
                Return InterfaceCTLS.DefInstance.pnlNetOptions
            Case "ircgui_getnetoptionspnl"
                Return InterfaceCTLS.DefInstance.pnlNetOptions2
            Case "ircgui_getcolorspnl"
                Return InterfaceCTLS.DefInstance.pnlInterf_Colors
            Case "ircgui_strings"
                Return InterfaceCTLS.DefInstance.pnlStrings
            Case "ircgui_getuserspnl"
                Return InterfaceCTLS.DefInstance.pnlUserSettings
            Case "ircgui_performwindow"
                Return InterfaceCTLS.DefInstance.pnlPerform
            Case "ircgui_soundoptions"
                Return InterfaceCTLS.DefInstance.pnlSndOptions
            Case "ircgui_modes"
                Return InterfaceCTLS.DefInstance.pnlModes
            Case "irc_selmodehalt"
                Dim RT As Boolean = IRC_Settings.IRCMode.HaltStatus
                If RT = True Then IRC_Settings.IRCMode.HaltStatus = False
                Return RT
            Case "irc_modeautoset"
                Dim RT As Boolean = IRC_Settings.IRCMode.Autoset
                IRC_Settings.IRCMode.Autoset = False
                Return RT
            Case "irc_altnickisset"
                Return IRC_AltNickIsSet
            Case "irc_getcurrentusermode"
                Return IRC_Settings.IRCMode.ModeID
            Case "uni_pmgr_init"
                Return IRC_DESC
            Case Else
                Return Nothing
        End Select
    End Function
    Friend Function IRC_CMDFO_DCBCMDS(ByVal Cmd As String) As Object
        Select Case Cmd.ToUpper
            Case "DCB_GUICTL_GETLISTSPANEL"
                Return InterfaceCTLS.DefInstance.pnlLists
            Case "DCB_GUICTL_GETLPANEL"
                Return InterfaceCTLS.DefInstance.pnIRCPanel
            Case "DCB_GUI_GETUSERINFO"
                Return IRC_Settings.UserInfo
            Case "DCB_GUICTL_GETTOOLBAR"
                Return InterfaceCTLS.DefInstance.tlbIRCToolBar
        End Select
    End Function
    Friend Function IRC_CMD_PROCESS(ByVal Cmd As String, Optional ByVal Separator As Char = " "c) As Object
        ' Обработчик запросов базы (в т.ч. скриптов)
        Dim Tmp() As String
        Dim Stp As String
        Try
            If Cmd.StartsWith(IRC_INF.INF_CMDEXEC) Then Cmd = Cmd.Substring(IRC_INF.INF_CMDEXEC.Length).Trim

            Cmd = IRC_ReplaceScriptConstants(Cmd) '.ToLower
            Stp = Cmd.ToLower

            If Stp.Trim.StartsWith("/#") Then Exit Function

            Dim TObj As Object = IRC_CMD_FUNC(Cmd)
            If Not TObj Is Nothing Then Return TObj

            ' Обработка UNI_Plugin.UNI_DChat.DCB_V1
            If Stp.StartsWith("dcb_") Or Stp.StartsWith("$") Or Stp.StartsWith("neterr") Then IRC_DCSE_DCBCMDS(Cmd, Stp) : Exit Function


            ' Обработка собственных комманд
            Select Case Stp.Split(Separator)(0)
                Case "irc_sendtoserver" ' irc_sendtoserver
                    ' ------DEBUG------
                    If IRC_Settings.Debug.IRC_DBG_SHOWSENDRAW = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/base printincon <irc_sendtoserver>" & Cmd)
                    ' ------DEBUG------
                    IRC_SendMsg(Cmd.Substring(IRC_SCRIPT_CONSTANTS.IRC_SCRIPT_STSERV.Length).Trim.TrimEnd)
                Case "irc_printincon"  ' irc_printincon
                    IRC_ShowInChat("0", ChlMainIRC, Cmd.Substring(IRC_SCRIPT_CONSTANTS.IRC_SCRIPT_PRINTINCON.Length))
                Case "irc_addserver"
                    IRC_Addserver(Stp.Substring("irc_addserver".Length).Trim)
                Case "irc_loadservers"
                    IRC_ClearServersList_nf()
                    DCSE.ExecScript(IRC_INF.INF_CMDEXEC, "irc_servers.dcscript")
                    '-CONNECTION
                Case "irc_connect"
                    Try
                        IRC_NET_Connect(Stp.Split(Space(1).ToCharArray)(1), CInt(Stp.Split(Space(1).ToCharArray)(2)))
                    Catch
                        Try : IRC_NET_Connect(Stp.Split(Space(1).ToCharArray)(1), 6667) : Catch : End Try
                    End Try
                Case "irc_netstop"  ' irc_connect
                    IRC_IRCBASE_RESET_ALL()
                    If Not IRC_Socket Is Nothing Then IRC_NET_Stop()
                Case "irc_connectto"
                    Try
                        IRC_NETOPER_ConnectToServer(Stp.Split(Space(1).ToCharArray)(1), Stp.Split(Space(1).ToCharArray)(2))
                    Catch
                        Try : IRC_NETOPER_ConnectToServer(Stp.Split(Space(1).ToCharArray)(1), "6667") : Catch : End Try
                    End Try
                Case "irc_connecttodefserv"
                    IRC_NETOPER_ConnectToServer(IRC_Settings.Network.Server, IRC_Settings.Network.Port)
                Case "irc_connecttlb"
                    If IRC_Socket Is Nothing And InterfaceCTLS.DefInstance.GetConnectButtonStatus = False Then
                        IRC_NETOPER_ConnectToServer(IRC_Settings.Network.Server, IRC_Settings.Network.Port)
                    ElseIf IRC_Socket Is Nothing And InterfaceCTLS.DefInstance.GetConnectButtonStatus = True Then
                        InterfaceCTLS.DefInstance.ChangeConnectButtonIcon(False)
                        CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Сетевое подключение остановлено", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)

                    Else
                        IRC_IRCBASE_RESET_ALL()
                        IRC_NET_Stop()
                    End If
                Case "irc_getconnectstatus"
                    Return InterfaceCTLS.DefInstance.GetConnectButtonStatus
                    '-----------------------------------------------------
                Case "irc_talk_to_chl"    ' irc_talk
                    IRC_MsgManager(Stp.Substring(Stp.Split(Space(1).ToCharArray)(0).Length + 1 + Stp.Split(Space(1).ToCharArray)(1).Length).Trim, Stp.Split(Space(1).ToCharArray)(1))
                Case "irc_talk"  ' irc_talk
                    IRC_MsgManager(Cmd.Substring(IRC_SCRIPT_CONSTANTS.IRC_SCRIPT_TALK.Length).Trim)
                    'До лучших времён :) ElseIf Stp.StartsWith("irc_register_sm_event") Then
                    '    IRC_DCSE_RegisterEvent(Cmd.Substring("irc_register_sm_event".Length))
                Case "irc_copychattoclipboard"
                    IRC_CopyChatToClipboard(Cmd.Split(Space(1).ToCharArray)(1))
                Case "irc_saveservers"
                    IRC_SaveServers()
                    '--------Favorites Control ------
                Case "irc_savefavoriteslist"
                    IRC_SaveFavorites()
                Case "irc_loadfavoriteslist"
                    IRC_CHLFavoritesCollection = New Collection
                    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/exec irc_favorites.dcscript")
                    IRC_UpdateCHLFavList()
                Case "irc_addfavchl"
                    IRC_AddFavCHL(Stp.Substring("irc_addfavchl".Length))
                    '--------Freinds List Control ---------
                Case "irc_loadfriendslist"
                    IRC_FriendsCollection = New Collection
                    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/exec irc_friends.dcscript")
                    IRC_UpdateFriendsList()
                Case "irc_friend_add"
                    IRC_AddFriend(Stp.Substring("irc_friend_add".Length))
                Case "irc_savefriendslist"
                    IRC_SaveFriends()
                    '--------------------------------------

                Case "irc_clearchlwindow"
                    IRC_ClearChlWindow(Cmd.Split(Space(1).ToCharArray)(1))
                Case "irc_savechattofile"
                    IRC_SaveChatToFile(Cmd.Split(Space(1).ToCharArray)(1))
                    '------------------Sounds control---------------
                Case "irc_playsound"
                    Try : IRC_PlaySound(Cmd.Split(Space(1).ToCharArray)(1)) : Catch : End Try
                Case "irc_regsounds"
                    DCSE.ExecScript(IRC_INF.INF_CMDEXEC, "irc_sounds.dcscript", "registersoundevents")
                    '----------------------
                Case ("irc_copychattoclipboard")

                    '----               irc_leavechl        ---
                Case "irc_leavechl"
                    IRC_CloseCHLWindow(Cmd.Split(Space(1).ToCharArray)(1))
                    '----           irc_registerscript     ---
                Case "irc_registerscript"
                    IRC_RegScript(Stp.Substring("irc_registerscript".Length).Trim)
                    '----           irc_addsay  ---
                Case "irc_addsay"
                    Dim txt As Windows.Forms.RichTextBox = DCCtl.DCB_GetInputTextBox
                    txt.Rtf = CStr(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "dcb_getrtf " & " -> " & Cmd.Split(Space(1).ToCharArray)(1) & ":  " & CStr(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "dcb_getdc2 " & txt.Rtf))))
                    txt.SelectionStart = txt.TextLength + 1
                Case "irc_newquickmsg"
                    Dim ToUsr As String = Cmd.Split(Space(1).ToCharArray)(1)
                    If tousr = IRC_INF.INF_CMDEXEC Then Exit Function
                    Dim QMW As New frmMessage(tousr, frmMessage.QuickMsgInitTypes.QW_NEW_ONE)
                    QMW.Show()
                    '---- Поддержка QMWindow ------
                Case "qwm_$quickmsg$"

                    IRC_USRTOOL_NOTICE_Send(Cmd.Split(Space(1).ToCharArray)(1), Cmd.Substring(Cmd.Split(Space(1).ToCharArray)(1).Length + "qwm_$quickmsg$".Length + 2).Trim)
                    '----IRC_CREATEPRIVATE
                Case "irc_createprivate"
                    If Stp.Substring("irc_createprivate".Length).Trim = IRC_INF.INF_CMDEXEC Then Exit Function
                    IRC_Createprivate(Stp.Substring("irc_createprivate".Length).Trim)
                    '--------------------- irc_SENDBEEP -----------
                Case "irc_sendbeep"
                    Dim cmdArray() As String = Cmd.Split
                    Dim ToUsr As String = cmdArray(1)
                    Dim snd As String = Cmd.Substring(cmdArray(0).Length + cmdArray(1).Length + 2)
                    IRC_USRTOOL_SendBeep(ToUsr, snd)
                Case "irc_getchlinfo"
                    IRC_GetCHLInfo(Stp.Substring("irc_getchlinfo".Length + 1))
                Case "irc_showchlinfowindow"
                    If Stp.EndsWith("op") Then
                        frmCHLInfo.DefInstance.USRIsOP = True
                    Else
                        frmCHLInfo.DefInstance.USRIsOP = False
                    End If
                    frmCHLInfo.DefInstance.Show()
                Case "irc_talkinchl"
                    Tmp = Cmd.Split
                    IRC_MsgManager(Cmd.Substring(Tmp(0).Length + Tmp(1).Length + 2), Tmp(1))
                    ' ---- COLOR SCHEMES ----
                Case "irc_addcolorscheme"
                    Dim T As String = Cmd.Substring("irc_addcolorscheme".Length).Trim
                    IRC_ColorSchemes.Add(T, T.Split(","c)(0))
                Case "irc_clearcolorschemes"
                    IRC_ColorSchemes = New Collection
                Case "irc_loadcolorschemes"
                    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/exec irc_colors.dcscript")
                Case "irc_savecolorschemes"
                    IRC_SaveColorSchemes()
                Case "irc_whoisreq"
                    If Cmd.Substring("irc_whoisreq".Length + 1) = IRC_INF.INF_CMDEXEC Then Exit Function
                    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/whois " & Cmd.Substring("irc_whoisreq".Length + 1))
                    '-----------------------------------------
                    '------------- USER MODES ----------------
                Case "irc_initumode"
                    IRC_UMODE_Activatemode(Cmd)
                Case "irc_addumode"
                    IRC_UserModes.Add(Cmd.Substring(Cmd.Split(Space(1).ToCharArray)(0).Length), Cmd.Split(Space(1).ToCharArray)(1).Split(":"c)(1))
                Case "irc_activateumodesinterface"
                    IRC_ActivateUModesGUI()
                Case "irc_setumodesettings"
                    IRC_Settings.IRCMode.GPARAMS = Cmd.Substring("irc_setumodesettings".Length).Trim
                Case "irc_askmodecomment"
                    Dim MComment As New frmChangeMode
                    MComment.DefInstance.Mode = Cmd.Split()(1)
                    If MComment.DefInstance.ShowDialog = DialogResult.Cancel Then IRC_Settings.IRCMode.HaltStatus = True : Exit Function
                    If MComment.DefInstance.comComment.Text = "" Then MComment.DefInstance.comComment.Text = "-"
                    IRC_Settings.IRCMode.Comment = MComment.DefInstance.comComment.Text
                Case "irc_setumodeprivact"
                    IRC_Settings.IRCMode.PrivACT = Cmd.TrimStart.Split()(1)
                Case "irc_initcurrentawaymode"
                    IRC_Settings.IRCMode.Autoset = True
                    IRC_UMODE_Activatemode("irc_initumode " & IRC_Settings.IRCMode.ModeID)
                Case "irc_setaltnickforactmode"


                    ' DCSE.ExecScript(IRC_INF.INF_CMDEXEC, "irc_usermodes.dcscript", IRC_Settings.IRCMode.ModeID)
                    'irccomments()
                Case "irc_resetumodesettimeout"
                    UModeSelectPause = False
                    '-----------------------------------------
                Case "irc_initmode_g"
                    IRC_Settings.IRCMode.Autoset = False
                    IRC_UMODE_ActivateGUI(Cmd)
                    ' Case "irc_showserverinfowindow"
                    '   frmServerinfo.DefInstance.Show()
                Case "irc_loadperformlist"
                    IRC_SETTINGS_LoadPerformNetworksList()
                Case Else
                    If Stp.StartsWith("/") Then
                        If Stp.Length = 1 Then Exit Function
                        If ExecRegistredScripts(Stp.Substring(1)) = False Then
                            IRC_SendMsg(Cmd.Substring(1).Trim.TrimEnd)
                        End If
                    Else
                        ExecRegistredScripts(Stp.Trim)
                    End If
            End Select
        Catch e As Exception
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<Error><DCIRC><DCSE> CMDLINE:<" & Cmd & ">", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
            CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<Error><DCIRC><DCSE> SysErr comment: " & e.ToString, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
        End Try
    End Function
    Friend Sub IRC_DCSE_DCBCMDS(ByVal Cmd As String, ByVal Stp As String, Optional ByVal Separator As Char = " "c)
        Try
            Select Case Stp.Trim.Split(Separator)(0).ToLower
                Case "dcb_initcompleted"
                    ' Информация об режимах отладки
                    If IRC_Settings.Debug.IRC_DBG_SHOWSERVRAW = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " irc_printincon <debug> irc_dbg_showservraw is enabled")
                    If IRC_Settings.Debug.IRC_DBG_SHOWSENDRAW = True Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " irc_printincon <debug> irc_dbg_showsendraw is enabled")

                    IRCScripts.Add("irc.dcscript")
                    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/exec irc_autoexec.dcscript")
                    ' Если первый запуск
                    If IRC_Settings.FirstStart = True Then frmFirstMaster.DefInstance.ShowDialog()
                    ' Инициализация сокета
                    'IRC_NetInit()
                    ' Подключение
                    If IRC_Settings.Network.AutoConnect = True Then
                        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, IRC_INF.INF_CMDEXEC & " irc_connecttodefserv")
                        'IRC_ConnectToServer(IRC_Settings.Network.Server, IRC_Settings.Network.Port)
                        'InterfaceCTLS.DefInstance.cmdTlbConnect.ImageIndex = 13
                    End If
                    IRC_InitCurUMode()
                    '---------- UNI_Plugin.UNI_DChat.DCB_V1 ---------------------------------
                Case "$showopionswindow$"
                    IRC_LoadToSettingTable_servers()
                    IRC_SETTINGS_InitSettingsWindow()
                    DCSE.ExecScript(IRC_INF.INF_CMDEXEC, "irc_settings_dcgui.dcscript", "settingswindowshow")
                    InterfaceCTLS.DefInstance.cmdIRCNetworks.Text = IRC_Settings.Network.Group
                    ' InterfaceCTLS.DefInstance.cmbServers.Text = IRC_Settings.Network.Description

                Case "$savesettings$"
                    ' Закрывается окно настроек--Ok
                    IRC_AcceptSettings()
                    IRC_UMODES_SaveUModeSettings()
                    IRC_SaveSettings()
                Case "$talk$"  ' irc_talk
                    IRC_MsgManager(Cmd.Substring("$talk$".Length).Trim)
                Case "$topicclick$"  ' irc_talk
                    frmIRCColorEditor.DefInstance.txtRTFTxt.Rtf = DCCtl.DCB_GetTopicBox.Rtf
                    If frmIRCColorEditor.DefInstance.ShowDialog = Windows.Forms.DialogResult.OK Then
                        DCCtl.DCB_UpdateTopicBox()
                        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/topic %currentchannel% :" & frmIRCColorEditor.DefInstance.RText)
                    End If
                Case "$chtopic$"
                    IRC_OPERATIONS_CHTOPIC(Cmd.Substring(10))
                Case "$chnick$"
                    IRC_OPERATIONS_CHNICK(Cmd.Substring(8))
                    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/nick " & Cmd.Substring(8))
                Case "dcb_basequit"   ' Закрытие чата
                    Dim Tmp() As String
                    ' irc_pluginquit
                    Tmp = Cmd.Split
                    IRC_PluginQuit(CBool(Tmp(1)))
                    IRC_SettingsManager.IRC_SaveSettings()
                    IRC_IRCBASE_RESET_ALL()
                    ' ElseIf Stp.StartsWith("neterr") Then

                Case "dcb_tabpagechanged"
                    If InterfaceCTLS.DefInstance.cmdUsers.Pushed = True Then
                        Dim CCHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = DCCtl.DCB_GetCurrentChannelDCC
                        InterfaceCTLS.DefInstance.cmdList.Text = "Всего: " & CCHL.lstUsers.Items.Count
                        UpdLstUsers(CCHL)
                        CCHL.lstUsers.Visible = True
                    End If
            End Select
        Catch ex As Exception
            'Stop
        End Try
    End Sub
   
    Friend Sub IRC_CopyChatToClipboard(ByVal CHLID As String)
        Dim CHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel
        CHL = CHLCtl.DCB_DChannel(CHLID)
        CHL.txtCHL.SelectAll()
        CHL.txtCHL.Copy()
        CHL.txtCHL.SelectionLength = 0
    End Sub
    Friend Sub IRC_PlaySound(ByVal Path As String)
        If IRC_Settings.SND_EventPath = "" Or IO.File.Exists(IRC_Settings.SND_EventPath & "\" & Path) = False Then
            Path = Windows.Forms.Application.StartupPath & "\sounds\" & Path
        Else
            Path = IRC_Settings.SND_EventPath.TrimEnd("\"c) & "\" & Path.TrimStart("\"c)
        End If

        DCSE.ExecScriptCommand("", "/base playsnd " & Path)
    End Sub
    Friend Sub IRC_ClearChlWindow(ByVal CHLID As String)
        Dim CHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel
        CHL = CHLCtl.DCB_DChannel(CHLID)

        CHL.txtCHL.Clear()
        CHLCtl.DCB_Talk_UUID_ChlDCC("0", CHL, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "Окно очищено", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Purple)
    End Sub
    Friend Sub IRC_SaveChatToFile(ByVal chlid As String)
        Dim CHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel
        CHL = CHLCtl.DCB_DChannel(chlid)

        Dim dlgFileSave As New Windows.Forms.SaveFileDialog
        dlgFileSave.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt|Unicode Text (*.txt)|*.txt|All Files (*.*)|*.*"
        If dlgFileSave.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        If dlgFileSave.FilterIndex = 0 Then
            CHL.txtCHL.SaveFile(dlgFileSave.FileName, Windows.Forms.RichTextBoxStreamType.RichText)
        ElseIf dlgFileSave.FilterIndex = 2 Then
            CHL.txtCHL.SaveFile(dlgFileSave.FileName, Windows.Forms.RichTextBoxStreamType.UnicodePlainText)
        Else
            CHL.txtCHL.SaveFile(dlgFileSave.FileName, Windows.Forms.RichTextBoxStreamType.PlainText)
        End If
    End Sub
    Friend Function IRC_GetSelectedUserName() As String
        Try
            Dim Nam As String
            Try : Nam = CStr(DCCtl.DCB_GetCurrentChannelDCC.lstUsers.SelectedItems(0).Text) : Catch : End Try

            If Nam = "" Then Nam = CStr(DCCtl.DCB_GetCurrentChannelDCC.lstUsers.Tag)
            Nam = Nam.TrimStart(CChar("@"))
            Nam = Nam.TrimStart(CChar("+"))
            Nam = Nam.TrimStart(CChar("%"))

            Return Nam
        Catch
            Return ""
        End Try

    End Function
    Friend Function IRC_ReplaceScriptConstants(ByVal Cmd As String) As String
        Cmd = Cmd.Replace("%usrnick_%", IRC_Settings.UserInfo.UserNick)
        Cmd = Cmd.Replace("%usrnick%", IRC_Settings.UserInfo.UserCurrentNick)
        Cmd = Cmd.Replace("%usrnick_a%", IRC_Settings.UserInfo.UserAltNick)
        Cmd = Cmd.Replace("%usrid%", IRC_Settings.UserInfo.UserID)
        Cmd = Cmd.Replace("%realname%", IRC_Settings.UserInfo.RealName)
        Cmd = Cmd.Replace("%usrircmode%", "0")
        Cmd = Cmd.Replace("%connectserver%", IRC_Settings.Network.Server)
        Cmd = Cmd.Replace("%connectport%", IRC_Settings.Network.Port.ToString)
        Cmd = Cmd.Replace("%currentchannelid%", IRC_GetIRCCurrentchannelCHLID)
        Cmd = Cmd.Replace("%currentchannel%", IRC_GetIRCcurrentchannelName)
        Cmd = Cmd.Replace("%selectedusername%", IRC_GetSelectedUserName)
        Cmd = Cmd.Replace("%selectedchlinchllist%", IRC_GetSelectedCHLNAMInRTFL)
        Cmd = Cmd.Replace("%currentmodecomment%", IRC_Settings.IRCMode.Comment)

        ' mIRC совместимость
        If Cmd.EndsWith(" #") Then Cmd = Cmd.Substring(0, Cmd.Length - 1) & IRC_GetIRCcurrentchannelName()
        Return Cmd
    End Function
    Friend Sub IRC_CloseCHLWindow(ByVal CHLID As String)
        'Dim CHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(CHLID)
        'Usr.DelNodeFromTreeview(CHLID)
        CHLCtl.DCB_DelCHL(CHLID)
    End Sub
    Friend Function IRC_GetSelectedCHLNAMInRTFL() As String
        Try
            Return CType(CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & "CHLLIST").rtflList.SelectedItems.Item(0), UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem).CHLName
        Catch
            Return ""
        End Try
    End Function
    Friend Function ExecRegistredScripts(ByVal CMD As String) As Boolean
        Dim Path As Object

        For Each Path In IRCScripts
            If CBool(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/exec " & CStr(Path) & " " & CMD)) = True Then Return True
        Next
        Return False
    End Function
    Private Sub IRC_RegScript(ByVal SName As String)
        IRCScripts.Add(SName)
    End Sub
    Private Sub IRC_GetCHLInfo(ByVal CHL As String)
        Dim DCCCHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & CHL)
        Dim Usr As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User = USRCtl.DCB_GetUser_UID(IRC_INF.INF_CMDEXEC & IRC_Settings.UserInfo.UserCurrentNick)
        Dim TreeNode As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem_TN = Usr.GetNode(DCCCHL.CHLID)
        If TreeNode Is Nothing Then Exit Sub
        ' Запрос информации
        'Баны (не огранич)
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CHL)
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CHL & " b")
        frmCHLInfo.DefInstance.txtCHLTopic.Rtf = DC2Conv.DC2ToRTF(DCCCHL.CHLTOPIC, IRC_Settings.IRCFont, IRC_Settings.IRCFontSize.ToString)
        If TreeNode.Info.IndexOf("o") >= 0 Or TreeNode.Info.IndexOf("h") >= 0 Then
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CHL & " e")
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CHL & " I")
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_showchlinfowindow op")
        Else
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "irc_showchlinfowindow std")
        End If
    End Sub

#Region " CHLFavorites "
    Friend Sub IRC_AddFavCHL(ByVal STR As String)
        Dim CHLNam As String
        Dim CHLNet As String
        Try
            STR = STR.Trim
            Dim NewCHLF As New IRC_CHLFavorite(STR.Split(CChar(Space(1)))(0))


            NewCHLF.Network = STR.Split(CChar(Space(1)))(1)
            If STR.IndexOf("-autojoin") >= 0 Then NewCHLF.AutoJoin = True
            If STR.IndexOf("-alarm") >= 0 Then NewCHLF.UseSND = True
            If STR.IndexOf("-sound") >= 0 Then NewCHLF.UseAlarm = True
            If STR.IndexOf("-pass") > 0 Then
                NewCHLF.Password = STR.Substring(STR.IndexOf("-pass") + 5)
            End If
            IRC_CHLFavoritesCollection.Add(NewCHLF, NewCHLF.CHLName)
        Catch
        End Try
    End Sub
    Friend Sub IRC_UpdateCHLFavList()
        Dim FCHL As IRC_CHLFavorite
        InterfaceCTLS.DefInstance.lstFavoriteCHLs.Nodes.Clear()
        For Each FCHL In IRC_CHLFavoritesCollection
            InterfaceCTLS.DefInstance.lstFavoriteCHLs.Nodes.Add(FCHL.CHLName)
        Next
    End Sub
    Friend Sub IRC_SaveFavorites()
        Dim FAVCHL As New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\scripts\irc_favorites.dcscript", False)
        Try
            FAVCHL.WriteLine("/#--------------")
            FAVCHL.WriteLine("/# DChat IRC")
            FAVCHL.WriteLine("/# Favorite Channels Control File")
            FAVCHL.WriteLine("/# !!! DO NOT MODIFY THIS FILE !!!!!")
            FAVCHL.WriteLine("/#--------------")
            FAVCHL.WriteLine("PID=%PID%")
            Dim FCHL As IRC_CHLFavorite
            Dim LineToSave As String
            For Each FCHL In IRC_CHLFavoritesCollection
                LineToSave = ""
                LineToSave += "irc_addfavchl "
                LineToSave += FCHL.CHLName & " "
                LineToSave += FCHL.Network & " "
                If FCHL.AutoJoin = True Then LineToSave += "-autojoin "
                If FCHL.UseSND = True Then LineToSave += "-sound "
                If FCHL.UseAlarm = True Then LineToSave += "-alarm "
                If Not FCHL.Password = "" Then LineToSave += "-pass" & FCHL.Password
                FAVCHL.WriteLine(LineToSave)
            Next
            FAVCHL.Close()
        Catch
            Try : FAVCHL.Close() : Catch : End Try
        End Try
    End Sub
    Friend Sub IRC_JoinFavorites()
        Dim FCHL As IRC_CHLFavorite
        For Each FCHL In IRC_CHLFavoritesCollection
            If FCHL.AutoJoin = True Then
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /join " & FCHL.CHLName & " " & FCHL.Password)
            End If
        Next
    End Sub
#End Region

#Region " Friends Control "
    Friend Sub IRC_AddFriend(ByVal STR As String)
        Dim CHLNam As String
        Dim CHLNet As String
        Try
            STR = STR.Trim
            Dim NewFriend As New IRC_Friend(STR.Split(Space(1).ToCharArray)(0))
            If STR.IndexOf("!n-") > 0 Or STR.IndexOf("!s-") > 0 Then
                Dim FRNamesSplit() As String = Split(STR, "!")
                Dim Tmp As String
                For Each Tmp In FRNamesSplit
                    If Tmp.StartsWith("n-") Then
                        NewFriend.AltNicks += Tmp.Substring(2).Trim & " "
                    End If
                    If Tmp.Trim = "s-notifyon" Then NewFriend.Notify = True
                    If Tmp.StartsWith("s-ecmd-") Then
                        NewFriend.ExecCMD = Tmp.Substring(7)
                    End If
                Next
            End If
            NewFriend.AltNicks = NewFriend.AltNicks.Trim()
            NewFriend.ExecCMD = NewFriend.ExecCMD.Trim()
            NewFriend.Status = IRC_Friend.FriendStates.Offline
            IRC_FriendsCollection.Add(NewFriend, NewFriend.Nick)
        Catch
        End Try
    End Sub
    Friend Sub IRC_UpdFriend(ByVal UName As String, ByVal FState As IRC_Friend.FriendStates)
        Dim Fri As IRC_Friend ' = CType(IRC_FriendsCollection.Item(UName), IRC_Friend)
        UName = UName.ToLower
        For Each Fri In IRC_FriendsCollection
            If Fri.Nick.ToLower = UName Or Fri.AltNicks.ToLower.IndexOf(UName) >= 0 Then
                Fri.Status = FState
                IRC_UpdateFriendsList()
                Fri.UpdStat = 2
                Exit Sub
            End If
        Next
    End Sub
    Friend Sub IRC_UpdateFriendsList()
        Dim Fri As IRC_Friend
        Dim tmp As Windows.Forms.TreeNode
        InterfaceCTLS.DefInstance.lstFriends.Nodes.Clear()
        For Each Fri In IRC_FriendsCollection

            tmp = InterfaceCTLS.DefInstance.lstFriends.Nodes.Add(Fri.Nick)
            tmp.ImageIndex = Fri.Status
            tmp.SelectedImageIndex = Fri.Status
        Next
    End Sub
    Friend Sub IRC_SaveFriends()
        Dim FRI As New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\scripts\irc_friends.dcscript", False)
        Try
            FRI.WriteLine("/#--------------")
            FRI.WriteLine("/# DChat IRC")
            FRI.WriteLine("/# Friends Control File")
            FRI.WriteLine("/# !!! DO NOT MODIFY THIS FILE !!!!!")
            FRI.WriteLine("/#--------------")
            FRI.WriteLine("PID=%PID%")
            Dim FRND As IRC_Friend
            Dim LineToSave As String
            Dim Tmp As String
            For Each FRND In IRC_FriendsCollection
                LineToSave = ""
                LineToSave += "irc_friend_add "
                LineToSave += FRND.Nick & " "
                If FRND.AltNicks <> "" Then
                    For Each Tmp In FRND.AltNicks.Trim.Split
                        LineToSave += "!n-" & Tmp.Trim & " "
                    Next
                End If
                If FRND.Notify = True Then LineToSave += "!s-notifyon "
                If FRND.ExecCMD <> "" Then LineToSave += "!s-ecmd-" & FRND.ExecCMD

                FRI.WriteLine(LineToSave)
            Next
            FRI.Close()
        Catch e As Exception
            MsgBox(e.Message)
            Try : FRI.Close() : Catch : End Try
        End Try
    End Sub
    Friend Sub IRC_SaveServers()
        Dim FRI As New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\scripts\irc_servers.dcscript", False)
        Try
            FRI.WriteLine("/#--------------")
            FRI.WriteLine("/# DChat IRC")
            FRI.WriteLine("/# IRC Servers List")
            FRI.WriteLine("/#--------------")
            FRI.WriteLine("/# USAGE: irc_addserver Network : Descr : Addr : Ports : Password")
            FRI.WriteLine("PID=%PID%")
            Dim FRND As IRC_NetSettings
            Dim LineToSave As String
            Dim Tmp As String
            For Each FRND In IRC_Servers
                LineToSave = ""
                LineToSave += "irc_addserver "
                LineToSave += FRND.Group & " | " & FRND.Description & " | " & FRND.Server & " | " & FRND.Port
                If FRND.Password <> "" Then LineToSave += " | " & FRND.Password

                FRI.WriteLine(LineToSave)
            Next
            FRI.Close()
        Catch e As Exception
            MsgBox(e.Message)
            Try : FRI.Close() : Catch : End Try
        End Try
    End Sub
    'Friend Sub FriendsTimer(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim Tmp As IRC_Friend
    '    For Each Tmp In IRC_FriendsCollection
    '        If Tmp.UpdStat = 0 Then
    '            IRC_BLOCKWHOISVIEW = True
    '            FrUpdTimer.Add(Tmp.AltNicks)
    '            '                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /whois " & Tmp.Nick)
    '        End If
    '        If Tmp.UpdStat > 0 Then Tmp.UpdStat -= CByte(1)
    '    Next
    'End Sub
    'Friend Sub TimedProc(ByVal sender As Object, ByVal e As EventArgs)
    '    If FrUpdTimer.Count = 0 Then Exit Sub



    '    Dim Seenick As String
    '    DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /whois " & Seenick)

    'End Sub
    Friend Sub IRC_SaveColorSchemes()
        Dim FRI As New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\scripts\irc_colors.dcscript", False, Text.Encoding.Default)
        Try
            FRI.WriteLine("/#--------------")
            FRI.WriteLine("/# DChat IRC")
            FRI.WriteLine("/# Color Schemes")
            FRI.WriteLine("/#--------------")
            FRI.WriteLine("/# DO NOT MODIFY THIS FILE")
            FRI.WriteLine("PID=%PID%")
            Dim FRND As String
            Dim LineToSave As String
            Dim Tmp As String
            For Each FRND In IRC_ColorSchemes
                LineToSave = "irc_addcolorscheme " & FRND
                FRI.WriteLine(LineToSave)
            Next
            FRI.Close()
        Catch e As Exception
            MsgBox(e.Message)
            Try : FRI.Close() : Catch : End Try
        End Try
    End Sub
#End Region

    Friend Sub IRC_Createprivate(ByVal UName As String)
        Dim ToCHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /privmsg " & UName & " :--")
        ToCHL = CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & UName)
        If ToCHL Is Nothing Then
            ToCHL = CHLCtl.DCB_AddNewChannel(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_NewChannelDataPack(IRC_INF, IRC_INF.INF_CMDEXEC & UName, UName, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFChannel, DCCtl.DCB_GetTabControl, InterfaceCTLS.DefInstance.pnlLists, IRC_Interface.ilsIRCIcons, 0))
            ToCHL.txtCHL.ContextMenu = IRC_Interface.mnuPrivCHLMenu
            ToCHL.CHLMainMenu = IRC_Interface.mnuMainIRCMenu
            ToCHL.lstUsers.Enabled = False
        End If
    End Sub


End Module
#Region " UniTimer "
Friend Class IRC_UniTimer
    Inherits Windows.Forms.Timer
    Dim iSeconds As Integer
    Dim iCMD As String
    Dim iStopSwitch As String
    Sub New(ByVal CMD As String, ByVal Seconds As Integer, Optional ByVal StopSwitch As String = "")
        iStopSwitch = StopSwitch
        ExecCMD_At(CMD, Seconds)
    End Sub
    Public Sub ExecCMD_At(ByVal CMD As String, ByVal Seconds As Integer, Optional ByVal StopSwitch As String = "")
        iSeconds = Seconds
        iCMD = CMD
        MyBase.Interval = 1000
        MyBase.Start()
    End Sub

    Private Sub IRC_UniTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Tick
        iSeconds -= 1
        If iStopSwitch <> "" Then
            If CBool(DCSE.ExecScriptCommand("/base", iStopSwitch)) = False Then
                MyBase.Stop() : MyBase.Dispose()
            End If
        End If
        If iSeconds = 0 Then
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, iCMD) : MyBase.Stop() : MyBase.Dispose()
        End If
    End Sub
End Class
#End Region