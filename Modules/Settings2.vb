' DZFS.NET 2003
' DChat project
' Settings2 Module
'------------------------------------------------------------------------------------
' Programmed by Garikk & Jurik
' Registry settings load and save procedures
'------------------------------------------------------------------------------------


Module Settings2
    Dim Registry As Microsoft.Win32.Registry
    Dim SaveStringUserSettings As String
    Dim SaveStringNetworkSettings As String
    Dim SaveStringInterfaceSettings As String
    Dim SaveStringSounds As String
    Dim SaveStringColors As String
    Dim SaveStringUNames As String
    Dim SaveStringUModes As String
    Dim SaveStringArchive As String
    Dim SaveStringMacro As String
    Public Sub DCB_SETTINGS_OPER_LoadSettings(Optional ByVal Profile As String = "Default")
        Dim Errors As Byte = 0
        Dim HKSaveString As String

Retr:
        Try
            SaveStringUserSettings = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\UserSettings"
            SaveStringInterfaceSettings = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\Interfacesettings"
            SaveStringSounds = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\Sounds"
            SaveStringNetworkSettings = "Software\DZFS.NET\DChat\NetworkSettings"
            SaveStringColors = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\Colors"
            SaveStringArchive = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\Archive"
            ' Звуки
            DCB_SoundSettings.AddLink = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("AddLink", "")
            DCB_SoundSettings.ChatLine = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("ChatLine", Application.StartupPath & "\sounds\Line.wav")
            DCB_SoundSettings.ChNick = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("ChNick", Application.StartupPath & "\sounds\name.wav")
            DCB_SoundSettings.ChTopic = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("ChTopic", Application.StartupPath & "\sounds\topic.wav")
            DCB_SoundSettings.ClosePriv = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("ClosePriv", Application.StartupPath & "\sounds\privatefinish.wav")
            DCB_SoundSettings.StartPriv = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("StartPriv", Application.StartupPath & "\sounds\privatestart.wav")
            DCB_SoundSettings.Logon = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("Logon", Application.StartupPath & "\sounds\logon.wav")
            DCB_SoundSettings.LogOff = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("Logoff", Application.StartupPath & "\sounds\logoff.wav")
            DCB_SoundSettings.LogOnChl = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("LogonChl", Application.StartupPath & "\sounds\ChannelJoin.wav")
            DCB_SoundSettings.LogOffChl = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("LogoffChl", Application.StartupPath & "\sounds\ChannelLeave.wav")
            DCB_SoundSettings.UsrBeep = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("Beep", Application.StartupPath & "\sounds\beep.wav")
            DCB_SoundSettings.ReceiveMessage = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("RecMsg", Application.StartupPath & "\sounds\message.wav")
            DCB_SoundSettings.MassMsg = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("MassMsg", Application.StartupPath & "\sounds\mass.wav")
            DCB_SoundSettings.SendMessage = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("SendMsg", "")
            DCB_SoundSettings.RemoteExec = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("Exec", Application.StartupPath & "\sounds\execute.wav")
            DCB_SoundSettings.MeLine = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("MeLine", Application.StartupPath & "\sounds\meline.wav")
            DCB_SoundSettings.GetScreenShot = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("ScreenShot", "")
            ' Звуки (перекл)
            DCB_SoundSettings.SoundAway = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("SoundAway", True)
            DCB_SoundSettings.SoundBusy = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("SoundBusy", False)
            DCB_SoundSettings.SoundOn = Registry.CurrentUser.OpenSubKey(SaveStringSounds).GetValue("SoundOn", True)
            ' Цвета
            DCB_ColorSettings.BackChatColor = Color.FromArgb(Registry.CurrentUser.OpenSubKey(SaveStringColors).GetValue("Backcolor", Drawing.Color.White.ToArgb.ToString))

            ' Интерфейс
            DCB_InterfaceSettings.ChatFont = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("ChatFont", DCB_DCTL.DCB_GetInputTextBox.Font.Name)
            DCB_InterfaceSettings.ChatFontSize = CInt(Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("ChatFontSize", DCB_DCTL.DCB_GetInputTextBox.Font.Size))
            DCB_InterfaceSettings.ChatFontBold = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("ChatFontB", DCB_DCTL.DCB_GetInputTextBox.Font.Bold)
            DCB_InterfaceSettings.ChatFontUnderl = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("ChatFontU", DCB_DCTL.DCB_GetInputTextBox.Font.Underline)
            DCB_InterfaceSettings.ShowMenuBar = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("MenuBar", "True")
            DCB_InterfaceSettings.UListPosition = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("UListPos", "1")


            DCB_InterfaceSettings.NickLS = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("NickLS", "<")
            DCB_InterfaceSettings.NickRS = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("NickRS", ">")
            DCB_InterfaceSettings.TimeLS = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("TimeLS", "[")
            DCB_InterfaceSettings.TimeRS = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("TimeRS", "]")
            DCB_InterfaceSettings.UseFormat = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("UseFormat", "True")

            If Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("UseHotKey", False) = True Then
                'Try
                DCB_InterfaceSettings.HKeyUse = True
                HKSaveString = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("HotKey")
                DCB_InterfaceSettings.HKAlt = BitToBol(Mid(HKSaveString, 1, 1))
                DCB_InterfaceSettings.HKCtrl = BitToBol(Mid(HKSaveString, 2, 1))
                DCB_InterfaceSettings.HKShift = BitToBol(Mid(HKSaveString, 3, 1))
                DCB_InterfaceSettings.HKKey = HexToDec(Mid(HKSaveString, 4, 2))
                DCB_InterfaceSettings.HKeyString = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("HotKeyString", "None")
                ' Catch
                '  End Try
            End If
            DCB_InterfaceSettings.PopUpLineChat = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("PopUpLineChat", False)
            DCB_InterfaceSettings.PopUpLogOn = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("PopUpLogOn", False)
            DCB_InterfaceSettings.PupUpMsgAway = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("PopUpMsgAway", True)
            DCB_InterfaceSettings.PupUpMsgBusy = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("PopUpMsgBusy", False)
            DCB_InterfaceSettings.PupUpMsgGame = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("PopUpMsgGame", False)
            DCB_InterfaceSettings.ShowTimeMsg = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("ShowTime", True)
            DCB_InterfaceSettings.ShowTopicBar = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("ShowTopicBar", True)
            DCB_InterfaceSettings.ShowUsrNameBar = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("ShowUsrNameBar", True)
            DCB_InterfaceSettings.RunMin = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("RunMin", True)
            DCB_InterfaceSettings.Tabs = Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings).GetValue("Tabs", 3)

            ' Архив
            ' Программа
            DCB_ChatParams.MyKEY = Registry.CurrentUser.OpenSubKey("software\DZFS.NET\DChat\Program").GetValue("RKey", "0")
            DCB_ChatParams.MyVerFChat = DCB_SETTINGS_OPER_GetChatVerFChat()
            DCB_ChatParams.MyVerFTitle = DCB_SETTINGS_OPER_GetChatVerFTitle()
            '  DCB_ChatParams.MyVer = GetChatINDVERString()
        Catch ' создание записей при первом запуске
            If Errors = 4 Then Exit Sub
            Errors += 1
            'CheckStringsForSave()
            Registry.CurrentUser.CreateSubKey(SaveStringUserSettings)
            Registry.CurrentUser.CreateSubKey(SaveStringInterfaceSettings)
            Registry.CurrentUser.CreateSubKey(SaveStringSounds)
            Registry.CurrentUser.CreateSubKey("software\DZFS.NET\DChat\Program")
            '   Registry.CurrentUser.CreateSubKey(SaveStringNetworkSettings)
            Registry.CurrentUser.CreateSubKey(SaveStringColors)
            'Registry.CurrentUser.CreateSubKey(SaveStringArchive)
            GoTo retr
        End Try
    End Sub

    Public Sub DCB_SETTINGS_OPER_SaveSettings(Optional ByVal Profile As String = "Default")
        Dim Errors As Byte = 0
        SaveStringUserSettings = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\UserSettings"
        SaveStringInterfaceSettings = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\Interfacesettings"
        SaveStringSounds = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\Sounds"
        SaveStringNetworkSettings = "Software\DZFS.NET\DChat\NetworkSettings"
        SaveStringColors = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\Colors"
        SaveStringArchive = "Software\DZFS.NET\DChat\Profiles\" & Profile & "\Archive"
Retr:
        Try ' Сохранение настроек
            Registry.CurrentUser.OpenSubKey("software\DZFS.NET\DChat\Program", True).SetValue("MyPath", Application.StartupPath)
            Registry.CurrentUser.OpenSubKey("software\DZFS.NET\DChat\Program", True).SetValue("MyDesc", CHAT_PARAM_DESC)
            '   Registry.CurrentUser.OpenSubKey("software\DZFS.NET\DChat\Program", True).SetValue("Ver", GetChatINDVERString)
            Registry.CurrentUser.OpenSubKey("software\DZFS.NET\DChat\Program", True).SetValue("MyKEY", DCB_ChatParams.MyKEY)
            ' Networksettings
            ' Звуки
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("Addlink", DCB_SoundSettings.AddLink)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("ChatLine", DCB_SoundSettings.ChatLine)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("ChNick", DCB_SoundSettings.ChNick)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("ChTopic", DCB_SoundSettings.ChTopic)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("ClosePriv", DCB_SoundSettings.ClosePriv)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("StartPriv", DCB_SoundSettings.StartPriv)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("Logon", DCB_SoundSettings.Logon)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("Logoff", DCB_SoundSettings.LogOff)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("LogonChl", DCB_SoundSettings.LogOnChl)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("LogoffChl", DCB_SoundSettings.LogOffChl)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("beep", DCB_SoundSettings.UsrBeep)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("RecMsg", DCB_SoundSettings.ReceiveMessage)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("MassMsg", DCB_SoundSettings.MassMsg)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("SendMsg", DCB_SoundSettings.SendMessage)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("Exec", DCB_SoundSettings.RemoteExec)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("MeLine", DCB_SoundSettings.MeLine)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("Screenshot", DCB_SoundSettings.GetScreenShot)
            'Звуки (перекл)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("SoundAway", DCB_SoundSettings.SoundAway)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("SoundBusy", DCB_SoundSettings.SoundBusy)
            Registry.CurrentUser.OpenSubKey(SaveStringSounds, True).SetValue("SoundOn", DCB_SoundSettings.SoundOn)
            ' Цвета
            Registry.CurrentUser.OpenSubKey(SaveStringColors, True).SetValue("BackColor", DCB_ColorSettings.BackChatColor.ToArgb.ToString)
            'Интерфейс
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("ChatFont", DCB_InterfaceSettings.ChatFont)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("ChatFontB", DCB_InterfaceSettings.ChatFontBold)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("ChatFontU", DCB_InterfaceSettings.ChatFontUnderl)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("ChatFontSize", DCB_InterfaceSettings.ChatFontSize)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("NickLS", DCB_InterfaceSettings.NickLS)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("NickRS", DCB_InterfaceSettings.NickRS)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("TimeLS", DCB_InterfaceSettings.TimeLS)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("TimeRS", DCB_InterfaceSettings.TimeRS)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("tabs", DCB_InterfaceSettings.Tabs)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("RunMin", DCB_InterfaceSettings.RunMin)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("ShowTopicBar", DCB_InterfaceSettings.ShowTopicBar)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("showUsrNameBar", DCB_InterfaceSettings.ShowUsrNameBar)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("ShowTime", DCB_InterfaceSettings.ShowTimeMsg)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("PopUpLineChat", DCB_InterfaceSettings.PopUpLineChat)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("PopUpLogOn", DCB_InterfaceSettings.PopUpLogOn)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("UseFormat", DCB_InterfaceSettings.UseFormat)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("MenuBar", DCB_InterfaceSettings.ShowMenuBar)
            Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("UListPos", DCB_InterfaceSettings.UListPosition)

            If DCB_InterfaceSettings.HKeyUse = True Then
                Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("UseHotKey", True)
                Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("HotKey", BolToBit(DCB_InterfaceSettings.HKAlt) & BolToBit(DCB_InterfaceSettings.HKCtrl) & BolToBit(DCB_InterfaceSettings.HKShift) & DecToHex(DCB_InterfaceSettings.HKKey))
                Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("HotKeyString", DCB_InterfaceSettings.HKeyString)
            Else
                Registry.CurrentUser.OpenSubKey(SaveStringInterfaceSettings, True).SetValue("UseHotKey", False)
            End If


        Catch ' создание записей при первом запуске
            If Errors = 4 Then Exit Sub
            Errors += 1
            DCB_SETTINGS_iOPER_CheckStringsForSave()
            Registry.CurrentUser.CreateSubKey(SaveStringUserSettings)
            Registry.CurrentUser.CreateSubKey(SaveStringInterfaceSettings)
            Registry.CurrentUser.CreateSubKey(SaveStringSounds)
            Registry.CurrentUser.CreateSubKey("software\DZFS.NET\DChat\Program")
            '  Registry.CurrentUser.CreateSubKey(SaveStringNetworkSettings)
            Registry.CurrentUser.CreateSubKey(SaveStringColors)
            '  Registry.CurrentUser.CreateSubKey(SaveStringArchive)
            GoTo retr
        End Try
    End Sub

    Private Sub DCB_SETTINGS_iOPER_CheckStringsForSave()
        ' Проверка на "пустые" String переменные
        If DCB_SoundSettings.AddLink = "" Then DCB_SoundSettings.AddLink = " "
        If DCB_SoundSettings.ChatLine = "" Then DCB_SoundSettings.ChatLine = " "
        If DCB_SoundSettings.ChNick = "" Then DCB_SoundSettings.ChNick = " "
        If DCB_SoundSettings.ChTopic = "" Then DCB_SoundSettings.ChTopic = " "
        If DCB_SoundSettings.ClosePriv = "" Then DCB_SoundSettings.ClosePriv = " "
        If DCB_SoundSettings.GetScreenShot = "" Then DCB_SoundSettings.GetScreenShot = " "
        If DCB_SoundSettings.LogOff = "" Then DCB_SoundSettings.LogOff = " "
        If DCB_SoundSettings.LogOffChl = "" Then DCB_SoundSettings.LogOffChl = " "
        If DCB_SoundSettings.Logon = "" Then DCB_SoundSettings.Logon = " "
        If DCB_SoundSettings.LogOnChl = "" Then DCB_SoundSettings.LogOnChl = " "
        If DCB_SoundSettings.MeLine = "" Then DCB_SoundSettings.MeLine = " "
        If DCB_SoundSettings.ReceiveMessage = "" Then DCB_SoundSettings.ReceiveMessage = " "
        If DCB_SoundSettings.RemoteExec = "" Then DCB_SoundSettings.RemoteExec = " "
        If DCB_SoundSettings.SendMessage = "" Then DCB_SoundSettings.SendMessage = " "
        If DCB_SoundSettings.StartPriv = "" Then DCB_SoundSettings.StartPriv = " "
        If DCB_SoundSettings.UsrBeep = "" Then DCB_SoundSettings.UsrBeep = " "
    End Sub

    Public Function DCB_SETTINGS_OPER_GetChatVerFChat() As String
        DCB_SETTINGS_OPER_GetChatVerFChat = Application.ProductVersion '"DChat " & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & " " & CHAT_PARAM_DESC
    End Function

    Public Function DCB_SETTINGS_OPER_GetChatVerFTitle() As String

        DCB_SETTINGS_OPER_GetChatVerFTitle = Application.ProductVersion

    End Function

    Public Function DCB_SETTINGS_OPER_GetUserNameMenuItem(ByVal Prof As String, ByVal NamNum As Byte) As String
        SaveStringUNames = "Software\DZFS.NET\DChat\plugins\" & Prof & "\Names"
        Try
            DCB_SETTINGS_OPER_GetUserNameMenuItem = Registry.CurrentUser.OpenSubKey(SaveStringUNames).GetValue(NamNum)
            If DCB_SETTINGS_OPER_GetUserNameMenuItem = "" Then DCB_SETTINGS_OPER_GetUserNameMenuItem = " "
        Catch
            DCB_SETTINGS_OPER_GetUserNameMenuItem = " "
        End Try
    End Function

    Public Sub DCB_SETTINGS_OPER_SaveUserNamesList(ByVal NamNum As Byte, ByVal Prof As String, ByVal Dat As String)
        Dim Errors As Boolean = False
        SaveStringUNames = "Software\DZFS.NET\DChat\plugins\" & Prof & "\Names"
Retr:
        Try
            Registry.CurrentUser.OpenSubKey(SaveStringUNames, True).SetValue(NamNum, Dat)
        Catch
            If Errors = True Then Exit Sub
            Errors = True
            Registry.CurrentUser.CreateSubKey(SaveStringUNames)
            GoTo Retr
        End Try
    End Sub
End Module
