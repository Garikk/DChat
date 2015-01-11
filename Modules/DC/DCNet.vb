' DZFS.NET 2003
' DChat Project
' DChat-DC Net control
'------------------------------------------------------------------------------------
' Programmed by Garikk
' DChat-DC Network Control Module (DCNet)
' Ver 2 (using DC_UNI Base)
'------------------------------------------------------------------------------------


Imports System.Net.Sockets

Module DCNet

    Dim SCK As UNI_NET_Socket

#Region "Обработка данных"
    Public Sub DataDecoder(ByVal MySock As Boolean, ByVal InData As String)
        Dim PckID As String ' Индентификатор пакета
        Dim PckZN As String ' Подсеть
        Dim PckIP As String ' IP/UID Отправителя в Gx
        Dim PckVR As String ' Версия чата
        Dim intUID As Short ' UID входящего пакета
        Dim intVER As Short ' Версия входящего пакета
        Dim Msg As String ' Пакет без заголовка
        Dim REZ As String ' Резерв
        Dim CHL As String ' Канал (в приватах и основной = 0)
        Dim Channel As UNI_DCChannelsI

        ' Разборка заголовка пакета
        PckID = Mid(InData, 1, 4)
        PckVR = Mid(InData, 5, 2)
        PckZN = Mid(InData, 7, 2)
        PckIP = Mid(InData, 9, 2)

        CHL = Mid(InData, 11, 2)
        REZ = Mid(InData, 13, 2)
        Msg = Mid(InData, 15)
        intUID = Gx52ToDEC(PckIP)
        intVER = Gx52ToDEC(PckVR)
        'for debug -> UNI_ShowMessage(DC_NetworkSettings.UID, MSG_TYPES.MSG_TXT, InData, chlmain.txtchl)
        ' Отброс отражения (если будет)
        If MySock = False And DC_NetworkSettings.UID = intUID Then
            Exit Sub
        End If
        'UNI_UserSettings.UState_DC & UNI_UserSettings.UMode & DC_NetworkSettings.Role & UNI_UserSettings.Nick
        ' Обработка пакетов
        Select Case PckID
            Case NET_ONLINE
                DChat.DC_CheckUser(intUID, CHL, Msg)
            Case NET_CHAT
                Channel = UNI_BASE_CHL.UNI_DChannel(Gx52ToDEC(Mid(CHL, 2)))
                DC_ShowText(UNI_BASE_ULISTCTL.Users(intUID, ChlMain), Msg, Channel)
            Case NET_CHOPTS
                DChat.ChangeOpts(intUID, CHL, Msg)
            Case NET_BEEP
                Channel = UNI_BASE_CHL.UNI_DChannel(Gx52ToDEC(Mid(CHL, 2)))
                DChat.DC_BeepControl(intUID, Msg, Channel)
            Case NET_MSG
                Chat.ShowReceiveMessage(intUID, Msg)
            Case NET_LOGIN
                DChat.LoginLogoff(intUID, CHL, Msg)
            Case NET_INFO
                DChat.UserInfoControl(intUID, Msg)
            Case NET_GETTHEME
                DChat.GetTheme(CHL, Msg)
            Case NET_PRIVAT
                '  Privat.ReceivePrivatPackets(intUID, Msg)
        End Select
    End Sub
#End Region

    Public Sub DC_SendMessage(ByVal InterfVER As Short, ByVal CHL As String, ByVal MsgType As String, ByVal Msg As String, Optional ByVal REZ As String = "")
        Dim Packet As String
        If STARTPAUSE > 0 And MsgType <> NET_GETTHEME Then Exit Sub

        If Len(DC_NetworkSettings.hUID) = 1 Then DC_NetworkSettings.hUID = "0" & DC_NetworkSettings.hUID
        If DC_NetworkSettings.hUID = "" Then DC_NetworkSettings.hUID = "00"
        If REZ = "" Then REZ = "00" ' Резерв
        If CHL.Length = 3 Then CHL = Mid(CHL, 1, 2)
        Packet = MsgType & DECtoGx52(InterfVER) & DC_NetworkSettings.hZone & DC_NetworkSettings.hUID & CHL & REZ & Msg

        DataDecoder(True, Packet)
        If UNI_BaseSettings.RunDC = False Then Exit Sub
        Dim ECode As Integer
        SCK.UNI_NET_SendMessage(Packet)
    End Sub


    Public Sub DC_StartNetwork()

        'Select Case DC_NetworkSettings.MultiCast
        '    Case True
        '        SCK = New UNI_NET_Socket()
        '        s()
        '    Case False
        '        SCK = New UNI_NET_Socket(ProtocolType.Udp, DC_NetworkSettings.Host, DC_NetworkSettings.Port)
        'End Select
        'AddHandler SCK.UNI_DCNET_ReciveData, AddressOf DC_UNICOMPDDEC
        'InitOnLineSender()
    End Sub
    Private Sub DC_UNICOMPDDEC(ByVal Dat As String)
        DataDecoder(False, Dat)
    End Sub
    Public Sub DC_StopNetwork()
        SCK.UNI_NET_Disconnect()
    End Sub
#Region " Отправка OnLine "
    Dim SendOnLine As Threading.Thread
    Private Sub InitOnLineSender()
        SendOnLine = New Threading.Thread(AddressOf Sender)
        SendOnLine.Start()
    End Sub

    Private Sub Sender()
        ' Отправка пакетов OnLine
        Do
            SendOnLine.Sleep(DC_NetworkSettings.NetPSend)
            DChat.DC_SendOnLine()
        Loop
    End Sub
#End Region
End Module


