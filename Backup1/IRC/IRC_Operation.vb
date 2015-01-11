' DZFS.NET 2003
' DChat Project
' IRC Control Module
'------------------------------------------------------------------------------------
' Programmed by Garikk
' Standard IRC commands control (IRChat) (IRC RFC2812)
'------------------------------------------------------------------------------------
Option Strict Off
Imports UNI_Plugin.UNI_DChat
Imports UNI_Plugin.UNI_DChat.DCB_V1
Imports System.Windows.Forms


Module IRC_Operation
    Friend UModeSelectPause As Boolean = False
    Friend Sub IRC_MsgManager(ByVal Msg As String, Optional ByVal CHLID As String = "")
        Dim CurChl As DCB_Channels2.DCB_Channel
        If CHLID = "" Then
            CurChl = IRC_GetIRCCurrentChannelDCC()
        Else
            CurChl = CHLCtl.DCB_DChannel(CHLID)
        End If
        ' Обрабатвываем сообщения
        If Not Msg.StartsWith("/") Then
            ' Сборка пакета и отправка на сервер
            'Пишем сначала у себя...
            If Not CurChl Is Nothing Then
                CHLCtl.DCB_Talk_UUID_ChlDCC(IRC_INF.INF_CMDEXEC & IRC_Settings.UserInfo.UserCurrentNick, CurChl, DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, Msg, CType(IRC_Settings.IRCColors.OwnColor, DCB_Base.DCB_IRCColors))
            Else
                CHLCtl.DCB_Talk_UUID_ChlDCC(IRC_INF.INF_CMDEXEC & IRC_Settings.UserInfo.UserCurrentNick, ChlMainIRC, DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "Say to: " & CHLID.Replace(IRC_INF.INF_CMDEXEC, "") & " -> " & Msg, CType(IRC_Settings.IRCColors.OwnColor, DCB_Base.DCB_IRCColors))
            End If
            'Собираем пакет
            If CHLID <> "" Then
                Msg = "PRIVMSG " & CHLID.Replace(IRC_INF.INF_CMDEXEC, "") & " :" & Msg
            Else
                Msg = "PRIVMSG " & CurChl.CHLName & " :" & Msg
            End If
            'Отправляем на сервер
            IRC_CMD_PROCESS("irc_sendtoserver " & Msg)
        Else
            'Комманды со слэшем отправляем сразу на сервер без обработки (слэш отрезаем)
            IRC_CMD_PROCESS("irc_sendtoserver " & Msg.Substring(1))
        End If
    End Sub
    Friend Sub irc_MsgManager_tusr(ByVal ToUsr As String, ByVal Msg As String)
        Dim sMsg As String
        sMsg = "PRIVMSG " & ToUsr & " :" & Msg
        'Отправляем на сервер
        IRC_CMD_PROCESS("irc_sendtoserver " & sMsg)
    End Sub
    Friend Sub IRC_USRTOOL_ChangeNick(ByVal NewNick As String)
        IRC_DCSE.IRC_CMD_PROCESS("irc_sendtoserver /NICK " & NewNick)
        IRC_Settings.UserInfo.UserCurrentNick = NewNick
    End Sub
    Friend Sub IRC_USRTOOL_NOTICE_Send(ByVal ToUsr As String, ByVal Text As String)
        ' TODO ВСЁ ПЕРЕВЕСТИ НА ГЛОБАЛЬНЫЙ DCSE!!!
        IRC_DCSE.IRC_CMD_PROCESS("irc_sendtoserver /NOTICE " & ToUsr & " :" & Text)
    End Sub
    Friend Sub IRC_USRTOOL_SendBeep(ByVal ToUsr As String, ByVal SNDPath As String)
        IRC_DCSE.IRC_CMD_PROCESS("irc_sendtoserver /PRIVMSG " & ToUsr & " " & Chr(1) & "SOUND " & SNDPath & Chr(1))
    End Sub
    Friend Sub IRC_IRCBASE_RESET_ALL()
        ' Сбрасываем всё при реконнекте
        Dim CHLS() As String = CHLCtl.DCB_GetPluginCHLIDs(IRC_INF.INF_CMDEXEC).Split(":"c)
        Dim Tmp As String
        For Each Tmp In CHLS
            If Not Tmp.ToLower = (IRC_INF.INF_CMDEXEC & "IRC Console").ToLower Then
                CHLCtl.DCB_DelCHL(Tmp)
                IRC_FirstNickInit = True
                IRC_AltNickIsSet = False
            End If
        Next
        ' Сбрасываем RPL_ISUPPROT
        IRC_CurServerISUPPORT = New Hashtable
    End Sub

    Friend Sub IRC_SNDMGR_MANAGER(ByVal SndEv As IRC_SNDMGR_Events, Optional ByVal UUID As String = "")
        If IRC_Settings.IRCMode.GPARAMS.Split()(0) = "0" Then Exit Sub
        If UUID <> "" And Not (UUID.StartsWith("#") Or UUID.StartsWith("&")) Then
            If IRC_SNDMGR_SndOk(UUID) = False Then Exit Sub
        End If
        Select Case SndEv
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_JOIN
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_JOIN)
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_KICK
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_KICK)
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_MODE
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_MODE)
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_MODE_BAN
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_MODE_BAN)
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_NICK
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_NICK)
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_PART
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_PART)
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_QMSG
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_QMSG)
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_QUIT
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_QUIT)
            Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_TOPIC
                Try
                    If CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & UUID).CHLParams.USESound = True Then
                        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_playsound " & IRC_Settings.SND_Paths.IRC_SND_TOPIC)
                    End If
                Catch
                End Try
        End Select
    End Sub
    Friend Function IRC_SNDMGR_SndOk(ByVal ForUID As String) As Boolean
        Dim CHLs As Collection = CHLCtl.DCB_GetPluginCHLS(IRC_INF.INF_CMDEXEC)
        Dim CHL As DCB_Channels2.DCB_Channel
        For Each CHL In CHLs
            ' interfacectls.DefInstance.
            If CHLCtl.IsUserExist(ForUID, CHL.CHLID) And CHL.CHLParams.USESound = True Then Return True
        Next
        Return False
    End Function
    Friend Sub IRC_OPERATIONS_CHTOPIC(ByVal Topic As String)
        If Not IRC_CurServerISUPPORT Is Nothing Then
            Try
                Dim NL As Integer = CInt(IRC_CurServerISUPPORT("TOPICLEN"))
                If NL < Topic.Length Then
                    MsgBox("Длина темы канала не должна превышать " & NL & " символов.", MsgBoxStyle.Critical)
                    Exit Sub
                ElseIf NL = 0 Then
                    Exit Sub
                End If
            Catch
            End Try

        End If

        DCCtl.DCB_UpdateTopicBox()
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/topic %currentchannel% :" & Topic)

    End Sub
    Friend Sub IRC_OPERATIONS_CHNICK(ByVal Nick As String)
        'Проверка на соответсвие RPL_ISUPPORT
        If Not IRC_CurServerISUPPORT Is Nothing Then
            Try
                Dim NL As Integer = CInt(IRC_CurServerISUPPORT("NICKLEN"))
                If NL < Nick.Length Then
                    MsgBox("Длина вашего ника не должна превышать " & NL & " символов.", MsgBoxStyle.Critical)
                    Exit Sub
                ElseIf NL = 0 Then
                    Exit Sub
                End If
            Catch
            End Try

        End If

        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/nick " & Nick)

    End Sub

#Region " Settings Operations "
    Friend Sub IRC_Addserver(ByVal CMD As String)
        Dim SDesc As String
        Dim SAddr As String
        Dim SPorts As String
        Dim SGroup As String
        Dim SPass As String
        Dim NewServ As New IRC_NetSettings
        Dim SSplit() As String = CMD.Trim.Split("|"c)

        SGroup = SSplit(0).Trim
        SDesc = SSplit(1).Trim
        SAddr = SSplit(2).Trim
        SPorts = SSplit(3).Trim
        Try : SPass = SSplit(4).Trim : Catch : End Try

        NewServ.Server = SAddr
        NewServ.Description = SDesc
        NewServ.Port = CStr(SPorts)
        NewServ.Group = SGroup
        NewServ.AutoConnect = False
        IRC_Servers.Add(NewServ)
    End Sub
    Friend Sub IRC_ClearServersList_nf()
        IRC_Servers = New Collection
    End Sub

    Friend Sub IRC_LoadToSettingTable_servers()
        InterfaceCTLS.DefInstance.cmbServers.Items.Clear()
        InterfaceCTLS.DefInstance.cmdIRCNetworks.Items.Clear()
        Dim Tmp As IRC_NetSettings
        Dim SGroup As Object
        Dim FindOk As Boolean = False
        For Each Tmp In IRC_Servers
            For Each SGroup In InterfaceCTLS.DefInstance.cmdIRCNetworks.Items
                If CStr(SGroup) = Tmp.Group Then FindOk = True : Exit For
            Next
            If FindOk = False Then InterfaceCTLS.DefInstance.cmdIRCNetworks.Items.Add(Tmp.Group)
            FindOk = False
        Next
        InterfaceCTLS.DefInstance.cmdIRCNetworks.Text = IRC_Settings.Network.Group
        InterfaceCTLS.DefInstance.cmbServers.Text = IRC_Settings.Network.Description

    End Sub
    Public Sub IRC_AcceptSettings()
        ' Установка изменённых настроек, при закрытии окна настроек
        Dim NServ As IRC_NetSettings
        With IRC_Settings.Network
            .Server = InterfaceCTLS.DefInstance.lblServAddrShow.Text
            .Group = InterfaceCTLS.DefInstance.txtGroup.Text
            .Password = InterfaceCTLS.DefInstance.txtPass.Text
            .Port = CStr(InterfaceCTLS.DefInstance.txtPorts.Text)
            .Description = InterfaceCTLS.DefInstance.txtDesc.Text
            .AutoConnect = InterfaceCTLS.DefInstance.chkAutoConnect.Checked
            .Reconnect = InterfaceCTLS.DefInstance.chkReconnect.Checked
            .ReconWait = CInt(InterfaceCTLS.DefInstance.nudRWait.Value)
        End With
        With IRC_Settings.IRCStrings
            .fingerReply = InterfaceCTLS.DefInstance.txtfingerReply.Text
            .IRC_QuitMsgPrgClose = DC2Conv.RTFToDC2(InterfaceCTLS.DefInstance.txtQuitMsg.Rtf)
            .IRC_QuitMsgSysExit = DC2Conv.RTFToDC2(InterfaceCTLS.DefInstance.txtQuitMsgSD.Rtf)
        End With
        With IRC_Settings.UserInfo
            .UserAltNick = InterfaceCTLS.DefInstance.txtAltNick.Text
            .UserNick = InterfaceCTLS.DefInstance.txtNick.Text
            .RealName = InterfaceCTLS.DefInstance.txtFullname.Text
            .UserID = InterfaceCTLS.DefInstance.txtUserID.Text
        End With

        With IRC_Settings.IRCColors
            Try
                .ColorScheme = CStr(InterfaceCTLS.DefInstance.cmbSchemes.Text & "," & CStr(InterfaceCTLS.DefInstance.cmd1.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd2.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd3.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd4.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd5.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd6.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd7.Tag) _
                & "," & CStr(InterfaceCTLS.DefInstance.cmd8.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd9.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd10.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd11.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd12.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd13.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd14.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd15.Tag) _
     & "," & CStr(InterfaceCTLS.DefInstance.cmd16.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd17.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd18.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd19.Tag) & "," & CStr(InterfaceCTLS.DefInstance.cmd20.Tag))
                IRC_InitColors(.ColorScheme)
            Catch
                'MsgBox("Color crash!!!")
                'Stop
            End Try
            ' Sounds
            ' TODO сделать понормальному когданибуть, применяем настройки звуков
            IRC_Settings.SND_Paths = InterfaceCTLS.DefInstance.ChSnds
            IRC_Settings.SND_EventPath = InterfaceCTLS.DefInstance.txtSndsPath.Text
            IRC_Settings.SND_CTCPPath = InterfaceCTLS.DefInstance.txtCTCPSNDPATH.Text
        End With

        ' Perform
        'InterfaceCTLS.DefInstance.txtPerform.SaveFile(Windows.Forms.Application.StartupPath & "\scripts\irc_perform.dcscript", Windows.Forms.RichTextBoxStreamType.PlainText)
        IRC_SETTINGS_CREATEPERFORM(InterfaceCTLS.DefInstance.cmbPerformIRCNetworks)


    End Sub
    Friend Sub IRC_InitColors(ByVal ColorString As String)
        Dim CString() As String = ColorString.Split(","c)
        With IRC_Settings.IRCColors
            .ActionColor = CShort(CString(1))
            .CTCPColor = CShort(CString(2))
            .HighlightColor = CShort(CString(3))
            .InfoColor = CShort(CString(4))
            .Info2Color = CShort(CString(5))
            .InviteColor = CShort(CString(6))
            .JoinColor = CShort(CString(7))
            .KickColor = CShort(CString(8))
            .ModeColor = CShort(CString(9))
            .NickColor = CShort(CString(10))
            .NormalColor = CShort(CString(11))
            .NoticeColor = CShort(CString(12))
            .NotifyColor = CShort(CString(13))
            .OtherColor = CShort(CString(14))
            .OwnColor = CShort(CString(15))
            .PartColor = CShort(CString(16))
            .Quitcolor = CShort(CString(17))
            .TopicColor = CShort(CString(18))
            .WallopsColor = CShort(CString(19))
            .WhoisColor = CShort(CString(20))
        End With
    End Sub

    Friend Sub IRC_SETTINGS_InitSettingsWindow()
        With InterfaceCTLS.DefInstance
            ' Дополнительные настройки сети
            .chkAutoConnect.Checked = IRC_Settings.Network.AutoConnect
            .chkReconnect.Checked = IRC_Settings.Network.Reconnect
            .nudRWait.Value = CDec(IRC_Settings.Network.ReconWait)
            ' Text Strings
            .txtQuitMsg.Rtf = DC2Conv.DC2ToRTF(IRC_Settings.IRCStrings.IRC_QuitMsgPrgClose, IRC_Settings.IRCFont, IRC_Settings.IRCFontSize)
            .txtQuitMsgSD.Rtf = DC2Conv.DC2ToRTF(IRC_Settings.IRCStrings.IRC_QuitMsgSysExit, IRC_Settings.IRCFont, IRC_Settings.IRCFontSize)
            .txtfingerReply.Text = IRC_Settings.IRCStrings.fingerReply
            ' User settings
            .txtFullname.Text = IRC_Settings.UserInfo.RealName
            .txtAltNick.Text = IRC_Settings.UserInfo.UserAltNick
            .txtNick.Text = IRC_Settings.UserInfo.UserNick
            .txtUserID.Text = IRC_Settings.UserInfo.UserID
            'Color Settings
            .cmbSchemes.Items.Clear()
            Dim Tmp As String
            For Each Tmp In IRC_ColorSchemes
                .cmbSchemes.Items.Add(Tmp.Split(","c)(0))
            Next
            .cmbSchemes.Text = IRC_Settings.IRCColors.ColorScheme.Split(","c)(0)
            .cmbSchemes_SelectedIndexChanged(InterfaceCTLS.DefInstance, New EventArgs)
            'Perform Window
            '.txtPerform.LoadFile(Windows.Forms.Application.StartupPath & "\scripts\irc_perform.dcscript", Windows.Forms.RichTextBoxStreamType.PlainText)
            ' Sounds manager
            .chkEnableSnds.Checked = IRC_Settings.SND_UseSNDS
            .chkUseCTCPSOUND.Checked = IRC_Settings.SND_UseCTCP
            .txtSndsPath.Text = IRC_Settings.SND_EventPath
            .txtCTCPSNDPATH.Text = IRC_Settings.SND_CTCPPath
            InterfaceCTLS.DefInstance.ChSnds = IRC_Settings.SND_Paths
            ' Modes
            'Dim Tmp As String
            Dim SL As Integer = 0
            .cmbModes.Items.Clear()
            For Each Tmp In IRC_UserModes
                .cmbModes.Items.Add(Tmp.Split(":")(0).Trim)
                SL += 1
            Next
            irc_UMODES_LoadAdvModes()
            '------
        End With
    End Sub
    Private Sub irc_UMODES_LoadAdvModes()
        ' Загрузка содержимого скрита режимов
        InterfaceCTLS.DefInstance.IRC_LMODES = New Collection
        Dim tmp As String
        Dim NM As InterfaceCTLS._UMode

        For Each tmp In IRC_UserModes
            NM = New InterfaceCTLS._UMode
            NM._UModePrefix = tmp
            irc_umodes_loadumodescr_s2(tmp.Split(":"c)(1), NM)
            InterfaceCTLS.DefInstance.IRC_LMODES.Add(NM, NM._UModePrefix.Split(":"c)(1))
        Next
    End Sub
    Private Sub irc_umodes_loadumodescr_s2(ByVal Mode As String, ByRef Oprm As InterfaceCTLS._UMode)
        Dim INITScript() As String = DCSE.GetProcSource(IRC_INF.INF_CMDEXEC, "irc_usermodes.dcscript", Mode).Split(Chr(13))
        Dim Tmp As String
        Oprm.SetAway = 2
        For Each Tmp In INITScript
            Tmp = Tmp.Trim()
            If Tmp.StartsWith("irc_setumodesettings") Then Oprm.MSett = Tmp.Substring("irc_setumodesettings".Length + 1)
            If Tmp.StartsWith("irc_setumodeprivact") Then Oprm.Privcmd = Tmp.Split()(1)
            If Tmp.IndexOf("irc_askmodecomment") <> 0 Then Oprm.AskModeComm = True Else Oprm.AskModeComm = False
            If Tmp.Split()(0).ToLower = "mset_execcmd" Then Oprm.OnChExec = Tmp.Trim.Substring(Tmp.Split()(0).Length + 1)
            If Tmp.StartsWith("/nick") Then Oprm.ChNick = Tmp.Split()(1)
            If Tmp.Trim = "/away" Then
                Oprm.SetAway = 0
            ElseIf Tmp.StartsWith("/away") Then
                Oprm.SetAway = 1
            End If
        Next
        If Oprm.Privcmd <> "" Then Oprm.PrivcmdPROC = DCSE.GetProcSource(IRC_INF.INF_CMDEXEC, "irc_usermodes.dcscript", Oprm.Privcmd)
    End Sub
    Friend Sub IRC_UMODES_SaveUModeSettings()
        Dim FRI As New IO.StreamWriter(System.Windows.Forms.Application.StartupPath & "\scripts\irc_usermodes.dcscript", False, Text.Encoding.GetEncoding(1251))
        '  FRI.Encoding = New Text.Encoding.GetEncoding(1251)
        Try
            FRI.WriteLine("/#--------------")
            FRI.WriteLine("/# DChat IRC")
            FRI.WriteLine("/# User Modes")
            FRI.WriteLine("/# Будте осторожны с редактированием этого файла")
            FRI.WriteLine("/# Не удаляйте режим АКТИВЕН, это может привести к дестабилизации программы")
            FRI.WriteLine("/#--------------")
            Dim FRND As InterfaceCTLS._UMode
            Dim LineToSave As String
            Dim Tmp As String
            For Each FRND In InterfaceCTLS.DefInstance.IRC_LMODES
                ' Создание процедуры активации режима
                FRI.WriteLine("proc " & FRND._UModePrefix.Split(":"c)(1))
                FRI.WriteLine("PID=%PID%")
                ' Блокировка от многократного включения
                If FRND._UModePrefix.Split(":"c)(1) = "irc_mod_act" Then
                    FRI.WriteLine("irc_getcurrentusermode irc_mod_act : dcse_haltscript")
                End If
                If FRND.SetAway = 1 Then
                    FRI.WriteLine("if irc_modeautoset false : irc_askmodecomment %procname%")
                    FRI.WriteLine("if irc_selmodehalt true : dcse_haltscript")
                End If
                FRI.WriteLine("irc_setumodesettings " & FRND.MSett)
                If FRND.Privcmd <> "" Then
                    FRI.WriteLine("irc_setumodeprivact " & FRND.Privcmd)
                End If
                FRI.WriteLine("irc_initmode_g %procname%")
                ' If FRND.ChNick <> "" Then
                If FRND._UModePrefix.Split(":"c)(1) = "irc_mod_act" Then
                    FRI.WriteLine("if irc_altnickisset false : /nick %usrnick_%")
                    FRI.WriteLine("if irc_altnickisset true : /nick %usrnick_a%")
                Else
                    FRI.WriteLine(" /nick " & FRND.ChNick)
                End If
                ' End If

                If FRND.OnChExec <> "" Then FRI.WriteLine(FRND.OnChExec)
                If FRND.SetAway = 0 Then
                    FRI.WriteLine("/away")
                ElseIf FRND.SetAway = 1 Then
                    FRI.WriteLine("/away %currentmodecomment%")
                End If
                FRI.WriteLine("end proc")
                FRI.WriteLine(vbCrLf)
                ' Процедура PrivAct
                If FRND.PrivcmdPROC <> "" Then
                    FRI.WriteLine("proc " & FRND.Privcmd)
                    FRI.Write(FRND.PrivcmdPROC)
                    FRI.WriteLine("end proc")
                    FRI.WriteLine(vbCrLf)
                End If


                'FRI.WriteLine(LineToSave)
            Next

            ' --------- Создание списка активации режимов
            FRI.WriteLine("proc AddModes")
            FRI.WriteLine("irc_addumode Активен:irc_mod_act:CtrlS")
            FRI.WriteLine("irc_addumode Занят:irc_mod_wrk:CtrlA")
            FRI.WriteLine("irc_addumode Ушёл:irc_mod_awy:CtrlD")
            FRI.WriteLine("irc_addumode Отключен:irc_mod_off:CtrlF")
            FRI.WriteLine("irc_addumode Игровой:irc_mod_ply:CtrlG")
            FRI.WriteLine("irc_activateumodesinterface")
            FRI.WriteLine("irc_initlastmode")
            FRI.WriteLine("end proc")
            FRI.Close()
        Catch e As Exception
            'MsgBox(e.Message)
            Try : FRI.Close() : Catch : End Try
        End Try
    End Sub
    Private Sub IRC_SETTINGS_CREATEPERFORM(ByVal cmbCollection As ComboBox)
        ' Создаём файлы irc_perform.dcscript и файлы автовыполнения для сетей

    End Sub
    Friend Sub IRC_SETTINGS_LoadPerformNetworksList()
        ' Загрузка списка perform

    End Sub
    Friend Sub IRC_SETTINGS_SavePerformNetworkList()

    End Sub
#End Region

#Region " DC-IRC Mode manager "
    Friend Sub IRC_InitCurUMode()
        Try
            If IRC_Settings.IRCMode.ModeName.Split(":"c)(1) = "" Then Exit Sub
            DCSE.ExecScript(IRC_INF.INF_CMDEXEC, "irc_usermodes.dcscript", IRC_Settings.IRCMode.ModeName.Split(":"c)(1))
        Catch
        End Try
    End Sub

    Friend Sub IRC_ActivateUModesGUI()

        'Создание UMode менюшки
        Static firstinit As Boolean = False
        If firstinit = True Then Exit Sub
        firstinit = True
        Dim Str As String
        IRC_Interface.mnuUModesMenu = New Windows.Forms.ContextMenu
        For Each Str In IRC_UserModes
            Dim NItem As New DCB_Controls.DCB_MenuItem(Str.TrimStart.Split(":"c)(0), "%PID% irc_initumode " & Str.TrimStart.Split(":"c)(1))
            IRC_Interface.mnuUModesMenu.MenuItems.Add(NItem)
            NItem.ShowShortcut = True
            NItem.Shortcut = CType([Enum].Parse(GetType(Shortcut), Str.Split(":"c)(2)), Shortcut)
            AddHandler NItem.Click, AddressOf UInterfaceControl.IRC_MenuEvent
        Next
        InterfaceCTLS.DefInstance.cmdtlbModeSelector.DropDownMenu = IRC_Interface.mnuUModesMenu
        SetHotKey(IRC_Interface.mnuMainIRCMenu, InterfaceCTLS.DefInstance.cmdtlbModeSelector.DropDownMenu)
    End Sub
    Friend Sub IRC_UMODE_Activatemode(ByVal Cmd As String)
        Try
            If Cmd.Split()(1).Trim = "addmodes" Then
                DCSE.ExecScript(IRC_INF.INF_CMDEXEC, "irc_usermodes.dcscript", Cmd.Substring(Cmd.Split()(0).Length).TrimStart)
                Exit Sub
            End If
        Catch
        End Try
        If UModeSelectPause = True Then
            MsgBox("Мwежду изменениями режимов должно пройти не менее 5 сек.(это ограничение вызвано организацией работы IRC). Подождите и попробуйте изменить режим через несколько секунд ещё раз.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            UModeSelectPause = True
            Dim NT As New IRC_UniTimer("irc_resetumodesettimeout", 5)
        End If
        DCSE.ExecScript(IRC_INF.INF_CMDEXEC, "irc_usermodes.dcscript", Cmd.Substring(Cmd.Split()(0).Length).TrimStart)

    End Sub

    Friend Sub IRC_UMODE_ActivateGUI(ByVal ModeNameF As String)
        IRC_Settings.IRCMode.ModeID = ModeNameF.Split()(1).Trim
        IRC_Settings.IRCMode.ModeName = CStr(IRC_UserModes(ModeNameF.Split()(1).TrimStart)).Split(":"c)(0).Trim
        InterfaceCTLS.DefInstance.cmdtlbModeSelector.Text = IRC_Settings.IRCMode.ModeName
    End Sub
#End Region
End Module
