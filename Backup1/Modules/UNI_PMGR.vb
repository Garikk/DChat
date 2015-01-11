'------------------------------------------------------------------------------------
' DZFS.NET 2003
' DChat project
' DChat Base
'------------------------------------------------------------------------------------
' Programmed by Garikk
' DChat Plugins Manager (PMGR)
'------------------------------------------------------------------------------------
Option Explicit On 
Imports UNI_Plugin.UNI_DChat
Module PMGR
    Public DCB_Plugins As New DCB_Universal.DCB_PluginsDB

    Public Sub DCB_PMGR_LoadPlugins()
        ''Загрузка плагинов
        Dim Files() As String
        Dim File As String
        Files = System.IO.Directory.GetFiles(Application.StartupPath & "\addons", "*.dll")
        For Each File In Files
            DCB_PMGR_InitPlugin(File)
        Next
        ' Инициализация плагинов
        Dim Plugin As UNI_Plugin.UNI_DChat.DCB_Universal.DCB_iPlugin
        For Each Plugin In DCB_Plugins.GetMainCollection.Values
            'Try
            If Plugin.UNI_GetInfo.INF_PLUGINTYPE = DCB_Universal.DCB_UNI_PluginTypes.DCB_V2_m Then
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "Init V2m : " & Plugin.UNI_GetInfo.INF_NAME, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, Plugin.DCB_DCSE_Exec("/base", "UNI_PMGR_Init"), UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
            End If
        Next
        For Each Plugin In DCB_Plugins.GetMainCollection.Values
            If Plugin.UNI_GetInfo.INF_PLUGINTYPE = DCB_Universal.DCB_UNI_PluginTypes.DCB_V1 Then
                Plugin.DCB_DCSE_V1_c_Plugininit(DCB_BASE_CHL_CTL, DCB_BASE_UDB_CTL, DCB_DCTL, New DCB_NET_Socket, New DCB_DCSE_FORPLUGINS) ', R)
                Plugin.DCB_DCSE_Exec("", "DCB_INITCOMPLETED")
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "Init V1 : " & Plugin.UNI_GetInfo.INF_NAME, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, Plugin.DCB_DCSE_Exec("/base", "UNI_PMGR_Init"), UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Interfa", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                DCB_DCTL.DCB_UpdateInterface()
                If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Load completed", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)

            End If
        Next
    End Sub

    Public Sub DCB_PMGR_InitPlugin(ByVal InitPath As String)
        ' Загрузка и инициализация плагина V1
        Dim NewPlugin As DCB_Universal.DCB_iPlugin
        Dim NewPluginV2m As DCB_Universal.DCB_iPlugin
        Try
            ' Открываем информационную часть плагина...
            'Получаем название корня сборки
            Dim RootNamespace As String
            Dim Plugin As Reflection.Assembly
            Dim PluginTypeStr As String
            Dim PluginType As DCB_Universal.DCB_UNI_PluginTypes
            Dim PInfo As DCB_Universal.DCB_UNI_iPluginGetInfo

            If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "Load from: " & InitPath, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
            Try
                Plugin = System.Reflection.Assembly.LoadFile(InitPath)
                RootNamespace = Plugin.GetName.Name
                If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Plugin rootname: " & RootNamespace, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                PInfo = CType(Activator.CreateInstanceFrom(InitPath, RootNamespace & ".DCB_PLUGININFO").Unwrap, DCB_Universal.DCB_UNI_iPluginGetInfo)
                If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Plugin Interface is:" & PInfo.DCB_GetInfo.INF_PLUGINTYPESTR, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)

            Catch ex As Exception
                If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Is Not DChat plugin or incompatible format, skipping...", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                Exit Sub
            End Try


            PluginType = PInfo.DCB_GetInfo.INF_PLUGINTYPE
            Select Case PluginType
                Case DCB_Universal.DCB_UNI_PluginTypes.DCB_V1
                    ' Загрузка в базу V1 плагинов
                    If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Add Plugin to database....", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                    If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---:" & InitPath, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                    NewPlugin = CType(Activator.CreateInstanceFrom(InitPath, RootNamespace & ".DCB_Plugin").Unwrap, DCB_Universal.DCB_iPlugin)
                    NewPlugin.DCB_DCSE_Exec("/base", "DCB_SETALTPID " & Int(Rnd() * 10000))
                    DCB_Plugins.AddPLG(NewPlugin)
                    If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Add plugin completed", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)

                Case DCB_Universal.DCB_UNI_PluginTypes.DCB_V2_m
                    ' Загрузка в базу V2m плагинов
                    If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Add Plugin to database....", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                    If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---:" & InitPath, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
                    NewPluginV2m = CType(Activator.CreateInstanceFrom(InitPath, RootNamespace & ".DCB_Plugin").Unwrap, UNI_Plugin.UNI_DChat.DCB_universal.DCB_iPlugin)

                    DCB_Plugins.AddPLG(NewPluginV2m)

                    If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, "---Add plugin completed", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Blue)
            End Select
        Catch e As Exception
            DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<Error><Base><PMGR>Plugin load error: " & InitPath, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
            If DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<Error><Base><PMGR> SysErr comment:" & e.ToString, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
        End Try
    End Sub

    Public Function DCB_PMGR_CALLPLUGINSCRIPTS(ByVal CMD As String, Optional ByVal GetObj As Boolean = False, Optional ByVal ForAll As Boolean = False, Optional ByVal CSeparator As Char = " "c) As Object
        ' отправка скриптовой комманды плагину
        Dim Ret As Boolean = False
        Dim Plugin As DCB_Universal.DCB_iPlugin

        If DCB_Plugins.GetMainCollection.ContainsKey(CMD.TrimStart.Split(CSeparator)(0)) = True And ForAll = False Then
            Plugin = DCB_Plugins.GetMainCollection(CMD.TrimStart.Split(CSeparator)(0))
            Try
                Dim FRet As Object
                FRet = Plugin.DCB_DCSE_Exec(CMD.TrimStart.Split(CSeparator)(0), CMD)
                If Not FRet Is Nothing Then Return FRet
            Catch ex As Exception
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<Error><Base><DCB_PMGR_CALLPLUGINSCRIPTS1>Plugin error: " & ex.ToString, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)

            End Try
            Exit Function
        End If
        For Each Plugin In DCB_Plugins.GetMainCollection.Values
            Try
                If CMD.StartsWith(Plugin.UNI_GetInfo.INF_CMDEXEC) Then

                    Dim FRet As Object
                    FRet = Plugin.DCB_DCSE_Exec("", CMD)
                    If Not FRet Is Nothing Then Return FRet

                ElseIf (Plugin.UNI_GetInfo.INF_OPTIONS.DCB_MsgFilter = False Or ForAll = True) And GetObj = False Then
                    Plugin.DCB_DCSE_Exec("", CMD)
                End If
            Catch ex As Exception
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<Error><Base><DCB_PMGR_CALLPLUGINSCRIPTS2>Plugin error: " & ex.ToString, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)

            End Try
        Next
    End Function

    Public Sub DCB_PMGR_StdPluginNotifyCommands(ByVal Notif As String, ByVal Dat As String)
        DCB_PMGR_CALLPLUGINSCRIPTS(Notif & " " & Dat)
    End Sub
    Public Function DCB_PMGR_GetPluginInfo(ByVal Path As String) As DCB_Universal.DCB_UNI_PluginInfo
        Dim inf As DCB_Universal.DCB_UNI_PluginInfo
        Dim Plg As UNI_Plugin.UNI_DChat.DCB_Universal.DCB_iPlugin
        Plg = CType(Activator.CreateInstanceFrom(Path, "IRC.DCB_PLUGININFO").Unwrap, DCB_Universal.DCB_UNI_iPluginGetInfo)
        inf = Plg.UNI_GetInfo
        Return inf
    End Function
End Module
