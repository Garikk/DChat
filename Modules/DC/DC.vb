' DZFS.NET 2003
' DChat Project
' DChat-Addon
'------------------------------------------------------------------------------------
' Programmed by Garikk
' DChat System Control Module
'------------------------------------------------------------------------------------

Module DChat
    Public Const DC_VER = "1.0"
    Dim ThemeOk As Boolean = False
    Dim WithEvents tmrInitTimer As New Timer()
    Dim DC_UsersListMenu As ContextMenu

    Public Function UNI_UListMenu() As ContextMenu
        Return DC_UsersListMenu
    End Function

    Public Sub InitDC()
        ' Инициализация чата-DC
        'InitDB_DC()                      ' Инициализация базы пользователей DC
        DC_UsersListMenu = New ContextMenu()
        UNI_ExecScript(Application.StartupPath & "\scripts\dcmenu.dcscript")

        tmrInitTimer.Interval = DC_NetworkSettings.NetPSend
        tmrInitTimer.Enabled = True
        UNI_UserSettings.UState_DC = Declares.NET_ONLINE_CSTAT_CONS.CSTAT_NO
        DC_NetworkSettings.Zone = 0      ' Зоны пока не поддерживаются
        DC_NetworkSettings.hZone = "00"  ' Зоны не поддерживаются
        'InitPrivatModule()  
        DCNet.DC_StartNetwork()

        ' Запрос на существующие каналы
        DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), NET_INFO, NET_INFO_DO_CONS.DO_INF_GET_CHL_LIST)

        ' Запрос темы (на основной канал)
        DC_SendMessage(1, "00", NET_GETTHEME, NET_TOPIC_DO_CONS.TOPIC_DO_REQ)
        UNI_BASE_CHL.UNI_Talk1(0, ChlMain, MSG_TYPES.MSG_CUSTOM, "Клиент DC запущен", Color.Red.ToArgb)
        UNI_BASE_CHL.UNI_Talk1(0, ChlMain, MSG_TYPES.MSG_CUSTOM, "<DChat> Инициализация менеджера DC....", Color.Red.ToArgb)
    End Sub
    Public Sub AddMsgToArcList(ByVal ImgInd As Declares.MSG_ARC_ICO, ByVal Msg As String)
        Dim NewItem As New TreeNode()
        Dim ToUserUID As Integer
        If ImgInd = Declares.MSG_ARC_ICO.ICO_IN Then
            NewItem.Text = UNI_InterfaceSettings.TimeLS & TimeOfDay & UNI_InterfaceSettings.TimeRS & " " & UNI_InterfaceSettings.NickLS & UNI_BASE_ULISTCTL.Users(Gx52ToDEC(Mid(Msg, 1, 2)), ChlMain).UserName & UNI_InterfaceSettings.NickRS & "<MSG>" & Mid(Msg, 3)
            ToUserUID = Gx52ToDEC(Left(Msg, 2))
            NewItem.Tag = DECtoGx52(UNI_BASE_ULISTCTL.Users(ToUserUID, ChlMain).UserName.Length) & UNI_BASE_ULISTCTL.Users(ToUserUID, ChlMain).UserName & Mid(Msg, 3)

        ElseIf ImgInd = Declares.MSG_ARC_ICO.ICO_OUT Then
            If Left(Msg, 2) = "00" Then
                NewItem.Text = UNI_InterfaceSettings.TimeLS & TimeOfDay & UNI_InterfaceSettings.TimeRS & " --> " & UNI_InterfaceSettings.NickLS & "Общее" & UNI_InterfaceSettings.NickRS & "<MSG>" & Mid(Msg, 3)
                NewItem.Tag = "00" & Mid(Msg, 3)
            Else
                NewItem.Text = UNI_InterfaceSettings.TimeLS & TimeOfDay & UNI_InterfaceSettings.TimeRS & " --> " & UNI_InterfaceSettings.NickLS & UNI_BASE_ULISTCTL.Users(Gx52ToDEC(Mid(Msg, 1, 2)), ChlMain).UserName & UNI_InterfaceSettings.NickRS & "<MSG>" & Mid(Msg, 3)
                ToUserUID = Gx52ToDEC(Left(Msg, 2))
                NewItem.Tag = DECtoGx52(UNI_BASE_ULISTCTL.Users(ToUserUID, ChlMain).UserName.Length) & UNI_BASE_ULISTCTL.Users(ToUserUID, ChlMain).UserName & Mid(Msg, 3)
            End If
        End If
        NewItem.ImageIndex = ImgInd
        NewItem.SelectedImageIndex = ImgInd
        frmChat.DefInstance.lstMsg.Nodes.Insert(-1, NewItem)
    End Sub

    Public Sub GetTheme(ByVal CHL As String, ByVal Msg As String)
        Dim CHLID As Integer = Gx52ToDEC(Mid(CHL, 2))
        Dim WrkCHL As UNI_DCChannelsI = UNI_BASE_CHL.UNI_DChannel(CHLID)
        If WrkCHL.CHLID = 9000 Then Exit Sub


        Select Case Mid(Msg, 1, 1)
            Case NET_TOPIC_DO_CONS.TOPIC_DO_REQ
                If WrkCHL.DC_TopicOk = False Then Exit Sub
                DC_SendMessage(1, Mid(WrkCHL.CHLIDf, 2, 2), Declares.NET_GETTHEME, NET_TOPIC_DO_CONS.TOPIC_DO_ANS & WrkCHL.CHLTOPIC)

            Case NET_TOPIC_DO_CONS.TOPIC_DO_ANS
                If WrkCHL.DC_TopicOk = False Then
                    WrkCHL.CHLTOPIC = Mid(Msg, 2)
                    ' UNI_ShowMessage(0, MSG_TYPES.MSG_TOPIC, Mid(Msg, 2), WrkCHL, "Текущая тема: ", , False)
                    UNI_BASE_CHL.UNI_Talk1(0, WrkCHL, MSG_TYPES.MSG_TOPIC, "Текущая тема", , False)
                    WrkCHL.DC_TopicOk = True
                    If Gx52ToDEC(Mid(frmChat.DefInstance.tbsChat.SelectedTab.Tag, 2, 2)) = CHLID Then
                        frmChat.DefInstance.txtTopic.Rtf = Mid(Msg, 2)
                    End If
                End If
        End Select
    End Sub

    Public Function GetComputerInfoString(ByVal Lite As Boolean) As String
        Dim InfoString As String
        Dim VerInfo As OSVERSIONINFO
        Dim Tmp As Long
        Select Case Lite
            Case True  ' Формирование сокращённого пакета информации
                If UNI_UserSettings.Comment = "" Then UNI_UserSettings.Comment = " "
                If UNI_UserSettings.UModeComment = "" Then UNI_UserSettings.UModeComment = " "
                InfoString = DECtoGx52(UNI_UserSettings.Comment.Length) & UNI_UserSettings.Comment & DECtoGx52(UNI_UserSettings.UModeComment.Length) & UNI_UserSettings.UModeComment
            Case False ' Формирование полного пакета информации
                ' Формат CompNameLen(2) CompNamLen UserNamLen(2) UserNamLen IPLen(2) IP SysName(2) SysName SysVer CommentModLen(2) CommentMode UserCommentLen(2) UserComment
                VerInfo.dwOSVersionInfoSize = Len(VerInfo)
                Tmp = GetVersionEx(VerInfo)
                InfoString = DECtoGx52(System.Net.Dns.GetHostName.Length) & System.Net.Dns.GetHostName
                InfoString = InfoString & DECtoGx52(System.Windows.Forms.SystemInformation.UserName.Length) & System.Windows.Forms.SystemInformation.UserName
                InfoString = InfoString & DECtoGx52(System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString.Length) & System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString
                InfoString = InfoString & DECtoGx52(VerInfo.dwMajorVersion) & DECtoGx52(VerInfo.dwMinorVersion) & DECtoGx52(VerInfo.dwPlatformId)
                InfoString = InfoString & DECtoGx52(UNI_UserSettings.UModeComment.Length) & UNI_UserSettings.UModeComment
                InfoString = InfoString & DECtoGx52(UNI_UserSettings.Comment.Length) & UNI_UserSettings.Comment
                GetComputerInfoString = InfoString

        End Select
        GetComputerInfoString = InfoString
    End Function
    Public Sub UserInfoControl(ByVal UID As Integer, ByVal Msg As String)
        Dim toUser As Integer
        Dim InfType As Short
        Dim UsrInfo As String
        Dim Tmp1 As Integer
        Dim Tmp2 As Integer
        InfType = Mid(Msg, 1, 1)
        toUser = Gx52ToDEC(Mid(Msg, 2, 2))
        Select Case InfType
            Case NET_INFO_DO_CONS.DO_INF_ANS
                If toUser = DC_NetworkSettings.UID Then
                    Msg = Mid(Msg, 4)
                    frmInfo.DefInstance.ShowInfo(UID, Msg)
                End If
            Case NET_INFO_DO_CONS.DO_INF_ANSl
                If toUser = DC_NetworkSettings.UID Then
                    Tmp1 = Gx52ToDEC(Mid(Msg, 4, 2))
                    Tmp2 = Gx52ToDEC(Mid(Msg, 6 + Tmp1, 2))
                    frmChat.DefInstance.lblInfo.Text = Mid(Msg, 6, Tmp1) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Mid(Msg, 8 + Tmp1, Tmp2)
                End If
            Case NET_INFO_DO_CONS.DO_INF_GET
                If toUser = DC_NetworkSettings.UID Then
                    DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), NET_INFO, NET_INFO_DO_CONS.DO_INF_ANS & DECtoGx52(UID) & DChat.GetComputerInfoString(False))
                End If
            Case NET_INFO_DO_CONS.DO_INF_GETl
                If toUser = DC_NetworkSettings.UID Then
                    DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), NET_INFO, NET_INFO_DO_CONS.DO_INF_ANSl & DECtoGx52(UID) & DChat.GetComputerInfoString(True))
                End If
            Case NET_INFO_DO_CONS.DO_INF_GET_CHL_LIST
                'if servers=true then
                'Chl.DC_SendChlList(UID)
            Case NET_INFO_DO_CONS.DO_INF_ANS_CHL_LIST
                ' Chl.DC_UpdateChlList(UID, Msg, frmChat.DefInstance.lstChl)
        End Select
    End Sub
    Public Sub LoginLogoff(ByVal UID As Integer, ByVal CHL As String, ByVal Msg As String)
        Select Case Mid(Msg, 1, 1)
            Case NET_LOGIN_DO_CONS.DO_LOG_IN
                'UNI_ShowMessage(UID, MSG_TYPES.MSG_LOGON, Users(UID, ChlMain).UserName & " вошёл в сеть", ChlMain)
                UNI_BASE_CHL.UNI_Talk1(UID, ChlMain, MSG_TYPES.MSG_LOGON, UNI_BASE_ULISTCTL.Users(UID, ChlMain).UserName & " вошёл в сеть")
            Case NET_LOGIN_DO_CONS.DO_EXITCHAT
                'UNI_ShowMessage(UID, MSG_TYPES.MSG_LOGOFF, Users(UID, ChlMain).UserName & " вышел из разговора", ChlMain)
                UNI_BASE_CHL.UNI_Talk1(UID, ChlMain, MSG_TYPES.MSG_LOGOFF, UNI_BASE_ULISTCTL.Users(UID, ChlMain).UserName & " вышел из разговора")
                ' UNI_UserLogoff(UID) ' Удаление пользователя из базы данных
            Case NET_LOGIN_DO_CONS.DO_EXITWIN
                UNI_BASE_CHL.UNI_Talk1(UID, ChlMain, MSG_TYPES.MSG_LOGOFF, UNI_BASE_ULISTCTL.Users(UID, ChlMain).UserName & " вышел из сети")

                'UNI_UserLogoff(UID) ' Удаление пользователя из базы данных
            Case NET_LOGIN_DO_CONS.DO_LOG_IN_CHL
                If UNI_BASE_CHL.UNI_DChannel(Gx52ToDEC(Mid(CHL, 2))).Connected = False Then Exit Sub
                Try
                    UNI_BASE_CHL.UNI_Talk1(UID, UNI_BASE_CHL.UNI_DChannel(Gx52ToDEC(Mid(CHL, 2))), MSG_TYPES.MSG_LOGONCHL, UNI_BASE_ULISTCTL.Users(UID, ChlMain).UserName & " вошёл в канал")
                Catch
                End Try
            Case NET_LOGIN_DO_CONS.DO_EXITCHL
                If UNI_BASE_CHL.UNI_DChannel(Gx52ToDEC(Mid(CHL, 2))).Connected = False Then Exit Sub
                Try
                    UNI_BASE_CHL.UNI_Talk1(UID, UNI_BASE_CHL.UNI_DChannel(Gx52ToDEC(Mid(CHL, 2))), MSG_TYPES.MSG_LOGONCHL, UNI_BASE_ULISTCTL.Users(UID, ChlMain).UserName & " вышел из канала")
                Catch
                End Try
        End Select
    End Sub
    Private Sub DC_GetUserInfo(ByVal UID As Integer, ByVal LiteInfo As Boolean)
        If LiteInfo = False Then
            DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), Declares.NET_INFO, Declares.NET_INFO_DO_CONS.DO_INF_GET & DECtoGx52(UID))
        Else
            DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), Declares.NET_INFO, Declares.NET_INFO_DO_CONS.DO_INF_GETl & DECtoGx52(UID))
        End If
    End Sub
    Public Sub GetMyUID(ByVal Channel As UNI_DCChannelsI)
        'Определение индивидуального номера
        ' 0 Системный номер, используется при инициализации
        '' 1-5 Резерв
        'Dim NewUID As Integer
        'Do
        '    NewUID = Int(Rnd() * 3843 + 1)
        '    If NewUID > 5 And Users(NewUID, Channel).UserName = Channel.FCell.UserName Then Exit Do
        'Loop
        'DC_NetworkSettings.UID = NewUID
        'DC_NetworkSettings.hUID = DECtoGx52(NewUID)
    End Sub
    Public Sub ExitDC(ByVal WinClose As Boolean)
        If WinClose = False Then
            DCNet.DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), Declares.NET_LOGIN, NET_LOGIN_DO_CONS.DO_EXITCHAT)
        Else
            DCNet.DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), Declares.NET_LOGIN, NET_LOGIN_DO_CONS.DO_EXITWIN)
        End If
        DCNet.DC_StopNetwork()
    End Sub

    Public Sub DC_SendOnLine()
        Dim CurCHL As UNI_DCChannelsI = GetCurrentChannelDCC()
        Dim CurCHLID As String = Mid(GetCurrentChannelDCC.CHLIDf, 2, 2)
        If STARTPAUSE > 0 Then Exit Sub
        If CurCHL.CHLTYPE <> UNI_DCChannelsI.CHL_TYPES.CHL_TYPE_BASE_MAIN Or CurCHL.CHLTYPE <> UNI_DCChannelsI.CHL_TYPES.CHL_TYPE_DC_VIRTUAL Then CurCHLID = Mid(ChlMain.CHLIDf, 2, 2)
        DC_SendMessage(1, CurCHLID, NET_ONLINE, UNI_UserSettings.UState_DC & UNI_UserSettings.UMode & DC_NetworkSettings.Role & UNI_UserSettings.Nick)
    End Sub

    Public Sub JoinToDCCHL(ByVal CHLIDNODE As String, ByVal CHLName As String)
        ' Подключение к каналу DC
        Dim CHLID As Integer
        ' CHLID = Chl.DC_JoinToChannel(Gx52ToDEC(Mid(CHLIDNODE, 1, 2)), CHLName, frmChat.DefInstance.tbsChat, UNI_DCChannelsI.CHL_TYPES.CHL_TYPE_DC_VIRTUAL).CHLID
        DC_SendMessage(1, DECtoGx52(CHLID), Declares.NET_LOGIN, NET_LOGIN_DO_CONS.DO_LOG_IN_CHL)
        DC_SendMessage(1, DECtoGx52(CHLID), Declares.NET_GETTHEME, Declares.NET_TOPIC_DO_CONS.TOPIC_DO_REQ)
    End Sub

    Public Sub ChangeOpts(ByVal UsrUID As Integer, ByVal CHL As String, ByVal Msg As String)
        Dim prmDO As Byte
        Dim lenPRM1 As Integer ' Длинна первого параметра
        Dim PARAM1 As String ' Первый параметр
        Dim PARAM2 As String ' Второй параметр
        Dim PARAM3 As String ' Общий
        Dim CHLID As Integer
        Dim RTFTopic As String
        Dim TmpRTFBox As New RichTextBox()
        Dim ActiveChl As UNI_DCChannelsI
        CHLID = Gx52ToDEC(CHL)
        prmDO = Mid(Msg, 1, 1)
        lenPRM1 = Gx52ToDEC(Mid(Msg, 2, 2))
        PARAM1 = Mid(Msg, 4, lenPRM1)
        PARAM2 = Mid(Msg, 4 + lenPRM1)
        PARAM3 = Mid(Msg, 2)
        ActiveChl = UNI_BASE_CHL.UNI_DChannel(CHLID)
        If ActiveChl.CHLID = 9000 Then Exit Sub
        Select Case prmDO
            Case NET_OPTS_DO_CONS.OPTS_DO_NAME
                UNI_BASE_CHL.UNI_Talk1(UsrUID, ActiveChl, MSG_TYPES.MSG_RENAME, PARAM1 & " переименовался в " & PARAM2)

            Case NET_OPTS_DO_CONS.OPTS_DO_TOPIC
                RTFTopic = DC2ToRTF(PARAM3 & " " & " (" & UNI_BASE_ULISTCTL.Users(UsrUID, ActiveChl).UserName & ") ")
                If GetCurrentChannel() = CHL Then
                    frmChat.DefInstance.txtTopic.Clear()
                    frmChat.DefInstance.txtTopic.Rtf = RTFTopic
                End If

                ActiveChl.CHLTOPIC = PARAM3 & " " & " (" & UNI_BASE_ULISTCTL.Users(UsrUID, ActiveChl).UserName & ") "
                ActiveChl.CHLTOPIC_RTF = RTFTopic
                ActiveChl.DC_TopicOk = True
                If ActiveChl.Connected = True Then UNI_BASE_CHL.UNI_Talk1(UsrUID, ActiveChl, MSG_TYPES.MSG_TOPIC, PARAM3 & " " & " (" & UNI_BASE_ULISTCTL.Users(UsrUID, ActiveChl).UserName & ") ") 'UNI_ShowMessage(UsrUID, MSG_TYPES.MSG_TOPIC, PARAM3 & " " & " (" & Users(UsrUID, ActiveChl).UserName & ") ", ActiveChl, "Тема изменена: ")

            Case NET_OPTS_DO_CONS.OPTS_DO_MODE
                If Val(PARAM3) = NET_ONLINE_MOD_CONS.MOD_ACTIVE Then
                    UNI_BASE_CHL.UNI_Talk1(UsrUID, ActiveChl, MSG_TYPES.MSG_CHMOD, UNI_BASE_ULISTCTL.Users(UsrUID, ActiveChl).UserName & " вошёл " & Chat.GetModeName(PARAM3))
                ElseIf PARAM2 = "" Then
                    UNI_BASE_CHL.UNI_Talk1(UsrUID, ActiveChl, MSG_TYPES.MSG_CHMOD, UNI_BASE_ULISTCTL.Users(UsrUID, ActiveChl).UserName & " вошёл " & Chat.GetModeName(PARAM1))
                Else
                    UNI_BASE_CHL.UNI_Talk1(UsrUID, ActiveChl, MSG_TYPES.MSG_CHMOD, UNI_BASE_ULISTCTL.Users(UsrUID, ActiveChl).UserName & " вошёл " & Chat.GetModeName(PARAM1) & " (" & PARAM2 & ")")
                End If
            Case NET_OPTS_DO_CONS.OPTS_DO_NEWCHL
                UNI_ShowMessage(UsrUID, MSG_TYPES.MSG_CUSTOM, "Создан канал: " & Mid(Msg, 2), ChlMain, , Color.Red.ToArgb)
                UNI_BASE_CHL.UNI_Talk1(UsrUID, ChlMain, MSG_TYPES.MSG_CUSTOM, "Создан канал: " & Mid(Msg, 2), Color.Red.ToArgb)
        End Select

    End Sub
    Public Sub DC_ChangeName(ByVal OldName As String, ByVal NewName As String)
        If UNI_BaseSettings.RunDC = False Then Exit Sub
        DChat.DC_SendOnLine()
        DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), Declares.NET_CHOPTS, NET_OPTS_DO_CONS.OPTS_DO_NAME & DECtoGx52(OldName.Length) & OldName & NewName)
    End Sub
    Public Sub LogonDC()
        UNI_BASE_CHL.UNI_Talk1(0, ChlMain, MSG_TYPES.MSG_CUSTOM, "<DChat> Инициализация завершена", Color.Red.ToArgb)
        ' Полуаем свой UID  
        DChat.GetMyUID(ChlMain)
        ' Вырубаем счётчик задержки
        STARTPAUSE = 0
        ' Появляемся в канале
        DC_SendOnLine()

        ' Входим в основной канал
        DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), Declares.NET_LOGIN, NET_LOGIN_DO_CONS.DO_LOG_IN)
        ThemeOk = True
    End Sub
    Public Sub DC_SendText(ByVal Channel As UNI_DCChannelsI, ByVal Msg As String)
        DChat.DC_SendOnLine()
        If Channel.CHLTYPE = UNI_DCChannelsI.CHL_TYPES.CHL_TYPE_BASE_MAIN Or Channel.CHLTYPE = UNI_DCChannelsI.CHL_TYPES.CHL_TYPE_DC_VIRTUAL Then
            DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), NET_CHAT, Msg)
        End If
    End Sub

    Public Sub DC_SetMode(ByVal Comment As String)
        If UNI_BaseSettings.RunDC = False Then Exit Sub
        DC_SendOnLine()
        If UNI_UserSettings.UMode = NET_ONLINE_MOD_CONS.MOD_ACTIVE Then
            DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), NET_CHOPTS, NET_OPTS_DO_CONS.OPTS_DO_MODE & NET_ONLINE_MOD_CONS.MOD_ACTIVE)
        Else
            DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), NET_CHOPTS, NET_OPTS_DO_CONS.OPTS_DO_MODE & "01" & UNI_UserSettings.UMode & Comment)
        End If
    End Sub

    Public Sub DC_CreateVirtualChl(ByVal CHLName As String, ByVal AutoCreate As Boolean)
        Dim NewChlID As Integer
        Dim Tmp As Integer
        ' проверка на наличие канала и подключение если существует


        'flgRebuildChlList = True
        DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), NET_CHOPTS, Declares.NET_OPTS_DO_CONS.OPTS_DO_NEWCHL & CHLName)
        DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), Declares.NET_INFO, Declares.NET_INFO_DO_CONS.DO_INF_GET_CHL_LIST)
        NewChlID = UNI_BASE_CHL.UNI_AddNewChannel(CHLName, UNI_DCChannelsI.CHL_TYPES.CHL_TYPE_DC_VIRTUAL, CHL_KEY, frmChat.DefInstance.tbsChat, frmChat.DefInstance.pnlLists, frmChat.DefInstance.ilsUserIcons).CHLID

        DC_SendMessage(1, DECtoGx52(NewChlID), NET_INFO, Declares.NET_INFO_DO_CONS.DO_INF_ANS_CHL_LIST & UNI_DCChannelsI.CHL_TYPES.CHL_TYPE_DC_VIRTUAL & DECtoGx52(NewChlID) & DECtoGx52(UNI_BASE_CHL.UNI_DChannel(NewChlID).CHLName.Length) & UNI_BASE_CHL.UNI_DChannel(NewChlID).CHLName & DECtoGx52(UNI_BASE_CHL.UNI_DChannel(NewChlID).CHLTOPIC.Length) & UNI_BASE_CHL.UNI_DChannel(NewChlID).CHLTOPIC)

        UNI_BASE_CHL.UNI_Talk1(DC_NetworkSettings.UID, UNI_BASE_CHL.UNI_DChannel(NewChlID), MSG_TYPES.MSG_CUSTOM, "Виртуальный канал: " & CHLName, UNI_ColorSettings.Welcome.ToArgb)
        UNI_BASE_CHL.UNI_Talk1(DC_NetworkSettings.UID, UNI_BASE_CHL.UNI_DChannel(NewChlID), MSG_TYPES.MSG_CUSTOM, "Виртуальный канал будет существовать до тех пор пока в нём находится хотябы один человек.", Color.Red.ToArgb)
        DC_SendMessage(1, DECtoGx52(NewChlID), Declares.NET_LOGIN, Declares.NET_LOGIN_DO_CONS.DO_LOG_IN_CHL)
    End Sub
    Public Sub DC_CheckUser(ByRef UsrUID As Short, ByVal CHL As String, ByVal PckOnLine As String)
        Dim UName As String
        Dim UMode As Byte
        Dim UState As Byte
        Dim URole As Byte
        Dim User As UNI_UList
        Dim Channel As UNI_DCChannelsI = UNI_BASE_CHL.UNI_DChannel(Gx52ToDEC(Mid(CHL, 2)))
        UState = Val(Mid(PckOnLine, 1, 1))
        UMode = Val(Mid(PckOnLine, 2, 1))
        'ShowMessage(0, MSG_TYPES.MSG_TXT, UState, ChlMain)
        URole = Val(Mid(PckOnLine, 3, 1))
        UName = Mid(PckOnLine, 4)
        User = UNI_BASE_ULISTCTL.Users(UsrUID, Channel)
        If CHL <> Mid(Chat.GetCurrentChannelDCC.CHLIDf, 2, 2) Then UState = 1

        'If UNI_BASE_ULISTCTL.Users(UsrUID, Channel).UserUID = 5000 Then
        '    User = UNI_BASE_ULISTCTL.AddNewUser(UsrUID, UName, UMode, UState, DC_NetworkSettings.UsrTimeBlock, URole, ChlMain)
        '    UNI_ChangeUserIcon(User, Channel, UState + UMode - 1)
        '    User.UserState = UState
        '    User.UserMode = UMode
        '    Exit Sub
        'End If

        'If User.UserName <> UName Then UNI_ChangeUserName(UsrUID, UName, Channel)
        ''If User.UserMode <> UMode Or User.UserState <> UState Then
        ''If UState = 0 Then Stop
        'UNI_ChangeUserIcon(User, Channel, UMode + UState - 1)
        'End If
        If User.UserRole <> URole Then User.UserRole = URole
        User.UserUpdNum = DC_NetworkSettings.UsrTimeBlock
    End Sub
    Public Sub DC_LeaveCHLMSG(ByRef CHL As UNI_DCChannelsI)
        'Уведомление о выходе из канала
        DC_SendMessage(1, Mid(CHL.CHLIDf, 2, 2), Declares.NET_LOGIN, Declares.NET_LOGIN_DO_CONS.DO_EXITCHL)
    End Sub

    Public Sub DC_SendUpdChlInfo(ByVal CHLIDf As String)
        If CHLIDf.StartsWith("M") = True Then Exit Sub
        Dim NewChlid As Integer = Gx52ToDEC(Mid(CHLIDf, 2))

        DC_SendMessage(1, Mid(CHLIDf, 2, 2), NET_INFO, Declares.NET_INFO_DO_CONS.DO_INF_ANS_CHL_LIST & UNI_DCChannelsI.CHL_TYPES.CHL_TYPE_DC_VIRTUAL & DECtoGx52(NewChlid) & DECtoGx52(UNI_BASE_CHL.UNI_DChannel(NewChlid).CHLName.Length) & UNI_BASE_CHL.UNI_DChannel(NewChlid).CHLName & DECtoGx52(UNI_BASE_CHL.UNI_DChannel(NewChlid).CHLTOPIC.Length) & UNI_BASE_CHL.UNI_DChannel(NewChlid).CHLTOPIC)
    End Sub
    Public Sub DC_Int_ChangeTopic(ByRef NewTopic As String, ByRef CHL As UNI_DCChannelsI)
        DChat.DC_SendOnLine()
        CHL.DC_TopicOk = True
        DC_SendMessage(1, Mid(CHL.CHLIDf, 2, 2), Declares.NET_CHOPTS, NET_OPTS_DO_CONS.OPTS_DO_TOPIC & NewTopic)
        DChat.DC_SendUpdChlInfo(CHL.CHLID)
    End Sub
    Public Sub DC_ChangeFormState(ByRef ustate As Byte)
        UNI_UserSettings.UState_DC = ustate
        DC_SendOnLine()
    End Sub

    Private Sub tmrInitTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrInitTimer.Tick
        ' Таймер инициализации, общего пользования

        If STARTPAUSE > 1 Then
            STARTPAUSE = STARTPAUSE - 1
        ElseIf STARTPAUSE = 1 Then
            frmChat.DefInstance.Enabled = True
            ' Запуск DC
            '---------------------------------------------------
            If UNI_BaseSettings.RunDC = True Then LogonDC()
            '----------------------------------------------------
            ' Запуск IRC
            ' TODO инициализация IRC
            '----------------------------------------------------
        End If

        ' Остановка таймера
        ' If STARTPAUSE = 0 And AutoCreateTimer = -1 Then tmrInitTimer.Enabled = False
    End Sub
    Public Sub DC_BeepControl(ByVal UID As Integer, ByVal Msg As String, ByVal Channel As UNI_DCChannelsI)
        Dim PckDO As Short
        Dim toUID As String
        PckDO = Mid(Msg, 1, 1)
        toUID = Mid(Msg, 2)
        If toUID <> DC_NetworkSettings.hUID Then Exit Sub
        Select Case PckDO
            Case Declares.NET_BEEP_DO_CONS.DO_BEEP_INC
                'UNI_ShowMessage(UID, MSG_TYPES.MSG_BEEP, Users(UID, Channel).UserName & " послал сигнал", ChlMain)
                'UNI_Talk(UID, Channel, MSG_TYPES.MSG_BEEP, Users(UID, Channel).UserName & " послал сигнал")
                DC_SendOnLine()
                DC_SendMessage(1, GetCurrentChannel, NET_BEEP, NET_BEEP_DO_CONS.DO_BEEP_OK & DECtoGx52(UID))
            Case Declares.NET_BEEP_DO_CONS.DO_BEEP_OK
                'UNI_ShowMessage(UID, MSG_TYPES.MSG_BEEP, Users(UID, Channel).UserName & " получил сигнал", ChlMain, , , False)
                'UNI_Talk(UID, Channel, MSG_TYPES.MSG_BEEP, Users(UID, Channel).UserName & " получил сигнал", , False)
        End Select
    End Sub
    Public Sub DC_ShowText(ByRef Usr As UNI_UList, ByVal Msg As String, ByRef Chl As UNI_DCChannelsI)
        'UNI_Talk(Usr.UserUID, Chl, MSG_TYPES.MSG_DC2, Msg)
    End Sub
    Public Sub DC_Cmd(ByVal CMD As String)
        Dim CmdArgs() As String = CMD.Split
        Select Case CmdArgs(0)
            Case "msgcc"
                DC_Int_SendMsg()
            Case "beepcc"
                DC_Int_Beep()
            Case "getfinfocc"
                DC_Int_GetUserInfo()
            Case "msgall"
                DC_Int_SendMsgAll()
            Case "saycc"
                DC_Int_Say(Chat.UNI_GetInputTextBox)
            Case "chgtopiccc"
                DChat.DC_Int_ChangeTopic(CmdArgs(1), GetCurrentChannelDCC)
        End Select
    End Sub
#Region " Вызов формы отправки сообщения + Overloads "
    Private Overloads Sub DC_Int_SendMsg(ByVal UsrUID As Integer, ByVal CHL As UNI_DCChannelsI)
        'Dim frmMsg As New frmMessage()
        'frmMsg.SendMSG(UsrUID, Declares.MESSAGES.MSG_TOONE)
    End Sub
    Private Overloads Sub DC_Int_SendMsg()
        Dim Channel As UNI_DCChannelsI = GetCurrentChannelDCC()
        Dim UsrUID As String = Channel.lstUsers.SelectedNode.Tag
        DC_Int_SendMsg(UsrUID, Channel)
    End Sub
    Private Sub DC_Int_SendMsgAll()
        ' Dim frmMsg As New frmMessage()
        ' frmMsg.SendMSG(0, Declares.MESSAGES.MSG_TOALL)
    End Sub
#End Region
#Region " Сигнал "
    Private Sub DC_Int_BeepTo(ByVal UID As Integer)
        DChat.DC_SendOnLine()
        DC_SendMessage(1, Mid(GetCurrentChannelDCC.CHLIDf, 2, 2), NET_BEEP, Declares.NET_BEEP_DO_CONS.DO_BEEP_INC & DECtoGx52(UID))
    End Sub
    Private Sub DC_Int_Beep()
        Dim Channel As UNI_DCChannelsI = GetCurrentChannelDCC()
        Dim UsrUID As String = Channel.lstUsers.SelectedNode.Tag
        DC_Int_BeepTo(UsrUID)
    End Sub
#End Region
    Private Sub DC_Int_GetUserInfo(Optional ByVal Lite As Boolean = False)
        DChat.DC_GetUserInfo(GetCurrentChannelDCC.lstUsers.SelectedNode.Tag, Lite)
    End Sub
    Private Sub DC_Int_Say(ByVal RTFBox As RichTextBox)
        RTFBox.Text = "-> " & GetCurrentChannelDCC.lstUsers.SelectedNode.Text & ": " & RTFBox.Text
        RTFBox.SelectionStart = RTFBox.TextLength
        RTFBox.Focus()
    End Sub
End Module
