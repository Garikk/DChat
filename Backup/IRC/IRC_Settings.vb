' DZFS.NET 2003
' DChat Project
' IRC Control Module
'------------------------------------------------------------------------------------
' Programmed by Garikk
' IRC Settings Manager (Microsoft.Win32.Registry using)
'------------------------------------------------------------------------------------
Imports Microsoft.Win32.Registry
Module IRC_SettingsManager
    Public IRC_Settings As IRC_SSettings

    Public Sub IRC_LoadSettings()
        Dim SettingStringNET As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\Net"
        Dim SettingStringMSGS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\IRCStrings"
        Dim SettingStringUSRS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\User"
        Dim SettingStringCOLORS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\Colors"
        Dim SettingStringSOUNDS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\Sounds"


        Dim Errors As Integer = 0
        Dim HKSaveString As String
        IRC_Settings.UserInfo = New UNI_Plugin.UNI_DChat.DCB_Universal.DCB_LocalUserInfo
        IRC_DefSettings()
Retr:
        Try
            IRC_Settings.FirstStart = CBool(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("FirstStart", "True"))

            ' настройки сети
            IRC_Settings.Network.ReconWait = CInt(CurrentUser.OpenSubKey(SettingStringNET).GetValue("WaitReconnect", "10"))
            IRC_Settings.Network.Reconnect = CBool(CurrentUser.OpenSubKey(SettingStringNET).GetValue("Reconnect", False))
            IRC_Settings.Network.AutoConnect = CBool(CurrentUser.OpenSubKey(SettingStringNET).GetValue("Autoconnect", True))
            IRC_Settings.Network.Description = CStr(CurrentUser.OpenSubKey(SettingStringNET).GetValue("Description", "flexhome.flex.ru"))
            IRC_Settings.Network.Group = CStr(CurrentUser.OpenSubKey(SettingStringNET).GetValue("Group", ""))
            IRC_Settings.Network.Password = CStr(CurrentUser.OpenSubKey(SettingStringNET).GetValue("Password", ""))
            IRC_Settings.Network.Port = CStr(CurrentUser.OpenSubKey(SettingStringNET).GetValue("Port", 6667))
            IRC_Settings.Network.Server = CStr(CurrentUser.OpenSubKey(SettingStringNET).GetValue("Server", "80.252.130.250"))
            ' Разное--Strings
            IRC_Settings.IRCStrings.IRC_QuitMsgPrgClose = CStr(CurrentUser.OpenSubKey(SettingStringMSGS).GetValue("QuitMsgPrgClose", "closing client"))
            IRC_Settings.IRCStrings.IRC_QuitMsgSysExit = CStr(CurrentUser.OpenSubKey(SettingStringMSGS).GetValue("QuitMsgSysExit", "Quit, Bye :)"))
            IRC_Settings.IRCStrings.fingerReply = CStr(CurrentUser.OpenSubKey(SettingStringMSGS).GetValue("FingerReply", "DO NOT TOUCH ME!!"))
            ' Разное-звуки
            IRC_Settings.SND_UseSNDS = CBool(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("UseSnds", True))
            IRC_Settings.SND_UseCTCP = CBool(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("UseCtcpSnds", False))
            IRC_Settings.SND_CTCPPath = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndsCtcpPath", System.Windows.Forms.Application.StartupPath & "\sounds\"))
            IRC_Settings.SND_EventPath = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndsEvPath", System.Windows.Forms.Application.StartupPath & "\sounds\"))
            IRC_Settings.SND_Paths.IRC_SND_TOPIC = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndTopic", "topic.wav"))
            IRC_Settings.SND_Paths.IRC_SND_QUIT = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndQuit", "logoff.wav"))
            IRC_Settings.SND_Paths.IRC_SND_QMSG = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndQMsg", "message.wav"))
            IRC_Settings.SND_Paths.IRC_SND_PART = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndPart", "logoff.wav"))
            IRC_Settings.SND_Paths.IRC_SND_NICK = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndNick", "name.wav"))
            IRC_Settings.SND_Paths.IRC_SND_MODE_BAN = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndModeB", ""))
            IRC_Settings.SND_Paths.IRC_SND_MODE = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndMode", ""))
            IRC_Settings.SND_Paths.IRC_SND_KICK = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndKick", ""))
            IRC_Settings.SND_Paths.IRC_SND_JOIN = CStr(CurrentUser.OpenSubKey(SettingStringSOUNDS).GetValue("SndJoin", "logon.wav"))

            If IRC_Settings.SND_EventPath = "" Then IRC_Settings.SND_EventPath = System.Windows.Forms.Application.StartupPath & "\sounds\"
            ' Пользователь
            IRC_Settings.UserInfo.EMail = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("Email", "123@123.123"))
            IRC_Settings.UserInfo.UserAltNick = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("AltNick", Windows.Forms.SystemInformation.UserName & "2"))
            IRC_Settings.UserInfo.RealName = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("RealName", Windows.Forms.SystemInformation.UserName))
            IRC_Settings.UserInfo.UserNick = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("Nick", Windows.Forms.SystemInformation.UserName))
            IRC_Settings.UserInfo.UserID = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("UserID", Windows.Forms.SystemInformation.UserName))
            IRC_Settings.UserInfo.UserCurrentNick = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("CurNick", IRC_Settings.UserInfo.UserNick))
            If IRC_Settings.UserInfo.UserCurrentNick = "" Then
                IRC_Settings.UserInfo.UserCurrentNick = IRC_Settings.UserInfo.UserNick
            End If
            ' Mode
            IRC_Settings.IRCMode.ModeName = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("Mode", "Активен"))
            IRC_Settings.IRCMode.ModeID = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("ModeID", "irc_mod_act"))
            IRC_Settings.IRCMode.Comment = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("ModeComment", " "))
            IRC_Settings.IRCMode.PrivACT = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("PCMD", " "))
            IRC_Settings.IRCMode.GPARAMS = CStr(CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("MSettings", "1 1 0"))
            'IRC_Settings.IRCMode.NickPrefix_work = CStr( CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("NickPrefix_off", " "))
            'IRC_Settings.IRCMode.NickPrefix_off = CStr( CurrentUser.OpenSubKey(SettingStringUSRS).GetValue("NickPrefix_work", " "))


            ' Цвета и шрифт

            IRC_Settings.IRCColors.ColorScheme = CStr(CurrentUser.OpenSubKey(SettingStringCOLORS).GetValue("ColorScheme", "Default,6,4,5,2,3,3,3,3,3,3,1,5,7,6,1,3,2,3,5,1"))
            'IRC_Settings.IRCFont = CStr( CurrentUser.OpenSubKey(SettingStringCOLORS).GetValue("Font", Windows.Forms.RichTextBox.DefaultFont.Name))
            'IRC_Settings.IRCFontSize = CInt( CurrentUser.OpenSubKey(SettingStringCOLORS).GetValue("Size", Windows.Forms.RichTextBox.DefaultFont.Size))
            IRC_ColorSchemes.Add(IRC_Settings.IRCColors.ColorScheme)
        Catch e As Exception  ' создание записей при первом запуске
            If Errors = 8 Then
                Exit Sub
            End If
            Errors += 1
            CurrentUser.CreateSubKey(SettingStringNET)
            CurrentUser.CreateSubKey(SettingStringMSGS)
            CurrentUser.CreateSubKey(SettingStringUSRS)
            CurrentUser.CreateSubKey(SettingStringCOLORS)
            CurrentUser.CreateSubKey(SettingStringSOUNDS)
            GoTo retr
        End Try
    End Sub

    Public Sub IRC_SaveSettings()
        Dim SettingStringNET As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\Net"
        Dim SettingStringMSGS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\IRCStrings"
        Dim SettingStringUSRS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\User"
        Dim SettingStringCOLORS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\Colors"
        Dim SettingStringSOUNDS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\Sounds"

        Dim Errors As Integer = 0
        Dim HKSaveString As String

Retr:
        Try
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("FirstStart", IRC_Settings.FirstStart)

            CurrentUser.OpenSubKey(SettingStringNET, True).SetValue("WaitReconnect", IRC_Settings.Network.ReconWait)
            CurrentUser.OpenSubKey(SettingStringNET, True).SetValue("Reconnect", IRC_Settings.Network.Reconnect)
            CurrentUser.OpenSubKey(SettingStringNET, True).SetValue("Autoconnect", IRC_Settings.Network.AutoConnect)
            CurrentUser.OpenSubKey(SettingStringNET, True).SetValue("Description", IRC_Settings.Network.Description)
            CurrentUser.OpenSubKey(SettingStringNET, True).SetValue("Group", IRC_Settings.Network.Group)
            CurrentUser.OpenSubKey(SettingStringNET, True).SetValue("Password", IRC_Settings.Network.Password)
            CurrentUser.OpenSubKey(SettingStringNET, True).SetValue("Port", IRC_Settings.Network.Port)
            CurrentUser.OpenSubKey(SettingStringNET, True).SetValue("Server", IRC_Settings.Network.Server)
            ' Разное текст-сообщ
            CurrentUser.OpenSubKey(SettingStringMSGS, True).SetValue("QuitMsgPrgClose", IRC_Settings.IRCStrings.IRC_QuitMsgPrgClose)
            CurrentUser.OpenSubKey(SettingStringMSGS, True).SetValue("QuitMsgSysExit", IRC_Settings.IRCStrings.IRC_QuitMsgSysExit)
            CurrentUser.OpenSubKey(SettingStringMSGS, True).SetValue("FingerReply", IRC_Settings.IRCStrings.fingerReply)
            'Разное - Snds
            'If IRC_Settings.SND_EventPath = System.Windows.Forms.Application.StartupPath & "\sounds\" Then IRC_Settings.SND_EventPath = ""
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("UseSnds", IRC_Settings.SND_UseSNDS)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("UseCtcpSnds", IRC_Settings.SND_UseCTCP)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SndsCtcpPath", IRC_Settings.SND_CTCPPath)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SndsEvPath", IRC_Settings.SND_EventPath)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDJoin", IRC_Settings.SND_Paths.IRC_SND_JOIN)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDKick", IRC_Settings.SND_Paths.IRC_SND_KICK)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDMode", IRC_Settings.SND_Paths.IRC_SND_MODE)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDModeB", IRC_Settings.SND_Paths.IRC_SND_MODE_BAN)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDNick", IRC_Settings.SND_Paths.IRC_SND_NICK)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDPart", IRC_Settings.SND_Paths.IRC_SND_PART)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDQmsg", IRC_Settings.SND_Paths.IRC_SND_QMSG)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDQuit", IRC_Settings.SND_Paths.IRC_SND_QUIT)
            CurrentUser.OpenSubKey(SettingStringSOUNDS, True).SetValue("SNDTopic", IRC_Settings.SND_Paths.IRC_SND_TOPIC)
            'Case IRC_Declares.IRC_SNDMGR_Events.IRC_SND_TOPIC
            ' Пользователь
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("EMail", IRC_Settings.UserInfo.EMail)
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("AltNick", IRC_Settings.UserInfo.UserAltNick)
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("RealName", IRC_Settings.UserInfo.RealName)
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("Nick", IRC_Settings.UserInfo.UserNick)
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("CurNick", IRC_Settings.UserInfo.UserCurrentNick)
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("UserID", IRC_Settings.UserInfo.UserID)
            'Mode
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("Mode", IRC_Settings.IRCMode.ModeName)
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("ModeID", IRC_Settings.IRCMode.ModeID)

            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("ModeComment", IRC_Settings.IRCMode.Comment)
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("PCMD", IRC_Settings.IRCMode.PrivACT)
            CurrentUser.OpenSubKey(SettingStringUSRS, True).SetValue("MSettings", IRC_Settings.IRCMode.GPARAMS)
            ' Цвета и шрифт
            CurrentUser.OpenSubKey(SettingStringCOLORS, True).SetValue("ColorScheme", IRC_Settings.IRCColors.ColorScheme)
            ' CurrentUser.OpenSubKey(SettingStringCOLORS, True).SetValue("Font", IRC_Settings.IRCFont)
            ' CurrentUser.OpenSubKey(SettingStringCOLORS, True).SetValue("Size", IRC_Settings.IRCFontSize)


        Catch e As Exception ' создание записей при первом запуске
            If Errors = 8 Then
                If IRC_Settings.Debug.IRC_DBG_MODULES = True Then
                    CHLCtl.DCB_Talk_UUID_ChlDCC("0", ChlMainIRC, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<Error><DCIRC><SAVESETTINGS> SysErr comment: " & e.ToString, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
                End If
                Exit Sub
            End If
            Errors += 1
            CurrentUser.CreateSubKey(SettingStringNET)
            CurrentUser.CreateSubKey(SettingStringMSGS)
            CurrentUser.CreateSubKey(SettingStringUSRS)
            CurrentUser.CreateSubKey(SettingStringCOLORS)
            CurrentUser.CreateSubKey(SettingStringSOUNDS)
            GoTo retr
        End Try
    End Sub
    Public Sub IRC_DefSettings()
        IRC_Settings.Network.Server = "80.252.130.250"
        IRC_Settings.Network.Port = "6667"
    End Sub
    Public Function LoadModeComments(ByVal ModePref As String) As String()
        Dim SettingStringMODS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\UModes"
        Dim tmp As Integer
        Dim MD(10) As String
        Try
            CurrentUser.OpenSubKey(SettingStringMODS).GetValueNames()
        Catch
            CurrentUser.CreateSubKey(SettingStringMODS)
        End Try
        Try
            For tmp = 0 To 10
                MD(tmp) = CurrentUser.OpenSubKey(SettingStringMODS).GetValue("MOD:" & ModePref & ":" & tmp, " ").ToString
            Next
            Return MD
        Catch
        End Try
    End Function
 
    Public Sub SaveModeComments(ByVal ModePref As String, ByVal Modescomments() As String)
        Dim SettingStringMODS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\UModes"
        Dim tmp As Integer
        For tmp = 0 To 10
            If Modescomments(tmp) <> "" Then
                CurrentUser.OpenSubKey(SettingStringMODS, True).SetValue("MOD:" & ModePref & ":" & tmp, Modescomments(tmp))
            End If
        Next
    End Sub
    Public Function LoadLastServersList() As String()
        Dim SettingStringMODS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\LServers"
        Dim tmp As Integer
        Dim MD(10) As String
        Try
            CurrentUser.OpenSubKey(SettingStringMODS).GetValueNames()
        Catch
            CurrentUser.CreateSubKey(SettingStringMODS)
        End Try
        Try
            For tmp = 0 To 10
                MD(tmp) = CurrentUser.OpenSubKey(SettingStringMODS).GetValue("SERV" & tmp).ToString
            Next
            Return MD
        Catch
            If Not MD Is Nothing Then Return MD
        End Try
    End Function
    Public Sub SaveLastServersList(ByVal Servers() As String)
        Dim SettingStringMODS As String = "Software\DZFS.NET\DChat\Plugins\DCIRC\LServers"
        Dim tmp As Integer
        For tmp = 0 To 10
            If Servers(tmp) <> "" Then
                CurrentUser.OpenSubKey(SettingStringMODS, True).SetValue("SERV" & tmp, Servers(tmp))
            End If
        Next
    End Sub
End Module
