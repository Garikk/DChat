'------------------------------------------------------------------------------------
' DZFS.NET 2000-2005
' DChat project
' DChat Base
'------------------------------------------------------------------------------------
' Programmed by Garikk
' DChat Base Control Module
'------------------------------------------------------------------------------------
Imports UNI_Plugin.UNI_DChat

Module Chat
    Public icoACT As New Icon(GetType(Chat).Assembly.GetManifestResourceStream("DChat2.mainV2.ico"))
    Public icoEMP As New Icon(GetType(Chat).Assembly.GetManifestResourceStream("DChat2.Empty.ico"))
    Public icoWRK As New Icon(GetType(Chat).Assembly.GetManifestResourceStream("DChat2.Work.ico"))
    Public icoAWY As New Icon(GetType(Chat).Assembly.GetManifestResourceStream("DChat2.AwyTray.ico"))
    Public icoPLY As New Icon(GetType(Chat).Assembly.GetManifestResourceStream("DChat2.gamTray.ico"))
    Public icoOFF As New Icon(GetType(Chat).Assembly.GetManifestResourceStream("DChat2.offTray.ico"))
    Public icoMAI As New Icon(GetType(Chat).Assembly.GetManifestResourceStream("DChat2.InMail.ico"))


    Public Const CHAT_PARAM_DESC As String = "(Beta)"

    Public DCB_BASE_CHLDB As New DCB_ChannelsDB
    Public DCB_BASE_USRDB As New DCB_UsersDB
    Public DCB_BASE_CHL_CTL As New DCB_CHL_Control
    Public DCB_BASE_UDB_CTL As New DCB_UDB_Control
    Public DCB_DCTL As New DCControl

    Public DCB_ActivePluginID As String
    ' Основная консоль
    Public CHLMain As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel
    Public Const ConsTalk = "/basedchat"
    Dim BaseMenu As String
    Dim LastMenu As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem


    Public Sub ChatInit()

        'Зегружаем программу...
        Randomize()
        InitBase() ' Инициализация базы
        frmChat.DefInstance.FormInit() 'инициализация формы
        CreateMainMenu()
    End Sub
    Friend Sub DebugModeControl(ByVal SetDbg As Boolean)
        DCB_BaseSettings.Debugmode = SetDbg
        If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXT_UNAME, "Работа в редиме отладки, возможно снижение производительности", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
        If DCB_BaseSettings.Debugmode = False Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXT_UNAME, "Нормальный режим", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
    End Sub
    Private Sub InitBase()
        ' Инициализация Базы
        Settings2.DCB_SETTINGS_OPER_LoadSettings()      ' загрузка настроек из реестра
        '-----------------
        DCB_Int_CreateConsole()
        DebugModeControl(False) ' <<<---- Выключатель Debug info в главной консоли
        PMGR.DCB_PMGR_LoadPlugins()
        DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_CUSTOM, "Добро пожаловать в " & DCB_ChatParams.MyVerFChat, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Purple)

    End Sub

    Public Overloads Sub DCB_ShowMessage(ByVal User As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User, ByVal MsgType As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes, ByVal Msg As String, ByVal ToChannel As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel, ByVal MyColor As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors, Optional ByVal UPDIcon As Byte = 1)
        Dim TimeLine As String
        Dim NickLine As String
        Dim TextToShow As String
        Dim PopUpNow As Boolean = False
        Dim TxtColor As System.Drawing.Color
        Dim ChlWindow As RichTextBox = ToChannel.txtCHL
        Dim Tmp As String
        Dim Tmp2 As String

        Dim MainForm As Form = DCB_DCTL.DCB_GetMainForm
        If User Is Nothing Then User = DCB_BASE_UDB_CTL.DCB_GetUser_UID("0") 'CHLMain.CHLUsers.Item_UID("0DChat")
        ' Форматирование
        TimeLine = DCB_InterfaceSettings.TimeLS & TimeOfDay & DCB_InterfaceSettings.TimeRS
        NickLine = DCB_InterfaceSettings.NickLS & User.UserNick & DCB_InterfaceSettings.NickRS
        ' If DCB_InterfaceSettings.ShowTimeMsg = False Then TimeLine = ""

        If Msg.EndsWith(Chr(13) & Chr(13)) Then Msg = Msg.Remove(Msg.Length - 1, 1)
        Msg = Space(1) & Msg
        ' Установка цвета
        Select Case MsgType
            Case UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME
                TxtColor = Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(MyColor))
                If MsgType = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME Then TextToShow = TimeLine & NickLine
                If MsgType = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME Then TextToShow = TimeLine
                If DCB_InterfaceSettings.PopUpLineChat = True Then PopUpNow = True

            Case UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXT_NOTUNAME, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXT_UNAME
                If User.UserType = DCB_Universal.DCB_LocalUserInfo.UserTypes.USR_ME Then
                    TxtColor = User._miniplugincolorscheme.MyTextColor
                Else
                    TxtColor = User._miniplugincolorscheme.OurTextColor
                End If
                If DCB_InterfaceSettings.PopUpLineChat = True Then PopUpNow = True
                If MsgType = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXT_UNAME Then TextToShow = TimeLine & NickLine
                If MsgType = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXT_NOTUNAME Then TextToShow = TimeLine
            Case UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_CUSTOM
                TxtColor = Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(MyColor))
                TextToShow = TimeLine '& Msg
            Case UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_UNAME
                TxtColor = Drawing.Color.FromArgb(DC2Conv.GetARGBfromIRCCode(MyColor))
                If MsgType = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_UNAME Then TextToShow = TimeLine & NickLine
                If MsgType = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME Then TextToShow = TimeLine

            Case UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR
                TxtColor = Drawing.Color.FromArgb(Color.Red.ToArgb)
                TextToShow = TimeLine ' & Msg
            Case UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_WARNING
                TxtColor = Drawing.Color.FromArgb(Color.Red.ToArgb)
                TextToShow = TimeLine '& Msg
        End Select
        Dim TmpColor As Integer
        TmpColor = DC2Conv.GetIRCColorCode(TxtColor.ToArgb)
        If TmpColor = 99 Then TmpColor = 1
        Msg = Chr(3) & TmpColor & TextToShow & Msg '.TrimEnd(Chr(13))
        Msg = Msg.Trim
        Msg = DC2Conv.DC2ToRTF(Msg, DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)

        If ChlWindow.SelectionStart <> ChlWindow.TextLength Then ChlWindow.SelectionStart = ChlWindow.TextLength

        ChlWindow.SelectedRtf = Msg
        '  ChlWindow.SelectionFont = New Font(DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)

        If MainForm.Visible = False And User.UserType <> DCB_Universal.DCB_LocalUserInfo.UserTypes.USR_ME And User.UserID <> "0" Then
            If MsgType = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME Or MsgType = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXT_UNAME Then
                If PopUpNow = True Then
                    If ToChannel.CHLParams.USEAlarm = True Then MainForm.Show()
                Else
                    If ToChannel.CHLParams.USEAlarm = True Then frmChat.DefInstance.BlinkTray = True
                End If
            End If
        End If

        If User.UserType <> DCB_Universal.DCB_LocalUserInfo.UserTypes.USR_ME Then
            If Not (DCB_DCTL.DCB_GetTabControl.SelectedTab Is ToChannel.tbsCHL) Then
                If ToChannel.CHLTYPE = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFChannel Then
                    If ToChannel.CHLID.StartsWith("/irccmd") Then
                        ' TODO СОВМЕСТИМОСТЬ --- DCIRC ПОТОМ ПЕРЕДЕЛАТЬ
                        If ToChannel.tbsCHL.ImageIndex <> 4 Then
                            If ToChannel.tbsCHL.ImageIndex <> UPDIcon Then ToChannel.tbsCHL.ImageIndex = UPDIcon
                        End If
                    Else
                        If ToChannel.tbsCHL.ImageIndex <> UPDIcon Then ToChannel.tbsCHL.ImageIndex = UPDIcon
                    End If
                End If
            End If
        End If
    End Sub
    Public Overloads Sub DCB_ShowMessage(ByVal UsrUID As String, ByVal MsgType As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes, ByVal Msg As String, ByVal ToChannel As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel, Optional ByVal PreRTFText As String = "", Optional ByVal MyColor As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Black, Optional ByVal UPDIcon As Byte = 1)
        ' Отображение текста в каналах
        DCB_ShowMessage(DCB_BASE_UDB_CTL.DCB_GetUser_UID(UsrUID), MsgType, Msg, ToChannel, MyColor, UPDIcon)
    End Sub


    Private Function DCB_Int_PrepareTextToShow(ByVal InTextStd As String, ByVal StdTextColor As Integer) As String
        Static RTFConv As New RichTextBox
        RTFConv.Text = InTextStd
        RTFConv.SelectAll()
        RTFConv.SelectionColor = Color.FromArgb(StdTextColor)
        Return RTFConv.SelectedRtf
    End Function


    Public Sub SetFontParams(ByVal rtfTextBox As RichTextBox, ByVal Bold As Boolean, ByVal Ital As Boolean, ByVal Under As Boolean, Optional ByVal FontName As String = "", Optional ByVal FontSize As Integer = 0)
        Dim currentFont As System.Drawing.Font = rtfTextBox.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        newFontStyle = FontStyle.Regular
        If Ital = True Then newFontStyle = newFontStyle + FontStyle.Italic
        If Bold = True Then newFontStyle = newFontStyle + FontStyle.Bold
        If Under = True Then newFontStyle = newFontStyle + FontStyle.Underline
        'If currentFont Is Nothing Then Exit Sub

        If FontName <> "" Then currentFont = New Font(FontName, currentFont.Size, currentFont.Style)
        If FontSize > 0 Then currentFont = New Font(FontName, FontSize, currentFont.Style)

        rtfTextBox.SelectionFont = New Font(currentFont.Name, currentFont.Size, newFontStyle)
    End Sub

    Public Sub CloseChat(ByVal WinClose As Boolean)
        Try
            ' Отключаем плагины
            PMGR.DCB_PMGR_CALLPLUGINSCRIPTS(DCB_V1.DCB_Plugins.DCB_UNIPluginNotify.DCB_Pluginquit & " " & WinClose, , True)
            Application.DoEvents()
            'Закрываем форму
            frmChat.DefInstance.ExitForm()
            'Сохраняем настройки
            Settings2.DCB_SETTINGS_OPER_SaveSettings()

        Catch
        End Try
        ' Закрываемся()
        End
    End Sub

    Public Function BolToBit(ByVal Inp As Boolean) As Short
        If Inp = True Then BolToBit = 1 Else BolToBit = 0
    End Function

    Public Function BitToBol(ByVal Inp As Short) As Boolean
        If Inp = 1 Then BitToBol = True Else BitToBol = False
    End Function


    'Public Sub DCB_ChangeMode_Event(ByVal Mode As NET_ONLINE_MOD_CONS, ByVal Comment As String)
    '    ' Событие о смене режима пользователем
    '    '  DCB_SetInterfStat(Comment)
    'End Sub


    Private Sub DCB_Int_CreateConsole()
        Dim DefPluginInfo As DCB_Universal.DCB_UNI_PluginInfo

        DefPluginInfo.INF_NAME = "DChat BASE (DCB)"
        DefPluginInfo.INF_CMDEXEC = "/base"
        Dim DefUsr As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User = DCB_BASE_UDB_CTL.DCB_AddNewUser("0", "DChat", Nothing, "/base")
        DefUsr.UserType = DCB_Universal.DCB_LocalUserInfo.UserTypes.USR_StdRemote
        DefUsr._miniplugincolorscheme.MyTextColor = Drawing.Color.Blue
        DefUsr._miniplugincolorscheme.OurTextColor = Drawing.Color.Blue

        CHLMain = DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_AddNewChannel(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_NewChannelDataPack(DefPluginInfo, "/base", "Console", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel_Types.CHL_MainConsole, DCB_DCTL.DCB_GetTabControl, DCB_DCTL.DCB_GetLeftPanel, Nothing, 0))
        CHLMain.CHLTOPIC = "4Добро пожаловать в 9DChat!!!!" ' Внимание! Текст с форматированием!!

        DCB_DCTL.DCB_UpdateTopicBox()
    End Sub
    Friend Function FileToString(ByVal FilePath As String) As String
        Dim Tmp As String
        Dim F As System.IO.StreamReader
        F = New System.IO.StreamReader(FilePath, System.Text.Encoding.Default)
        Tmp = F.ReadToEnd
        F.Close()
        Return Tmp

    End Function
    Friend Sub ShowExit()
        If MsgBox("Вы действительно хотите закрыть DChat?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Chat.CloseChat(False)
        End If
    End Sub
    Public Sub DCB_Int_ShowCHLMenu()
        'перестроение главного меню
        Try : ChangeCHLMenu(DCB_DCTL.DCB_GetCurrentChannelDCC.CHLMainMenu()) : Catch : End Try
    End Sub

    Public Function HexToDec(ByVal InHex As String) As Short
        HexToDec = Val("&H" & InHex)
    End Function

    Public Function DecToHex(ByVal InDec As String) As String
        Dim Tmp As String
        Tmp = Hex(CInt(InDec))

        If Len(Tmp) = 1 Then
            DecToHex = "0" & Tmp
        Else
            DecToHex = Tmp
        End If
    End Function

End Module
Friend Class IRCTextManager
    ' RTFIRC Module support Class
    Dim MPID As String
    Sub New(ByVal MODPID As String)
        MPID = MODPID
    End Sub

    Public Function RTF2IRC(ByVal RTF As String) As String
        Return DCSE.DCB_DCSE_OPER_Executer(MPID, MPID & Chr(1) & "rtf2irc" & Chr(1) & RTF, Chr(1))
    End Function

    Public Function IRC2RTF(ByVal RTF As String, ByVal FNT As String, ByVal FSize As String) As String
        Return DCSE.DCB_DCSE_OPER_Executer(MPID, MPID & Chr(1) & "irc2rtf" & Chr(1) & FNT & Chr(1) & FSize & Chr(1) & RTF, Chr(1))
    End Function
    Public Function TXT2RTF(ByVal Txt As String, ByVal FNT As String, ByVal FSize As String) As String
        Return DCSE.DCB_DCSE_OPER_Executer(MPID, MPID & Chr(1) & "txt2rtf" & Chr(1) & FNT & Chr(1) & FSize & Chr(1) & Txt, Chr(1))

    End Function
    Public Function RTF2TXT(ByVal Txt As String) As String
        Return DCSE.DCB_DCSE_OPER_Executer(MPID, MPID & Chr(1) & "rtf2irc" & Chr(1) & Txt, Chr(1))
    End Function
    Public Function GetARGBfromIRCCode(ByVal IRCCode As Integer) As Integer
        Return DCSE.DCB_DCSE_OPER_Executer(MPID, MPID & Chr(1) & "getargbfromirccode" & Chr(1) & IRCCode, Chr(1))
    End Function
    Public Function GetIRCCodeFormARGB(ByVal ARGB As Integer) As Integer
        Return DCSE.DCB_DCSE_OPER_Executer(MPID, MPID & Chr(1) & "getirccodefroemargb" & Chr(1) & ARGB, Chr(1))
    End Function
End Class