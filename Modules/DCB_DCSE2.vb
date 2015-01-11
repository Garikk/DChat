'------------------------------------------------------------------------------------
' DZFS.NET 2005
' DChat project
' DCSE
'------------------------------------------------------------------------------------
' Programmed by Garikk
' DChat Scripting Engine (DCSE)
' Version 2
'------------------------------------------------------------------------------------
Imports UNI_Plugin.UNI_DChat

Public Class DCB_DCSE_FORPLUGINS
    ' Ссылка для плагинов для доступа к DCSE
    Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_DCSE
    '----------------------------------------
    ' Интерфейс связи с плагинами
    '----------------------------------------
    ' Created by Garikk
    '----------------------------------------
    Public Function UNI_DCSE_EXEC_ExecScriptCommand(ByVal PID As String, ByVal CMD As String, Optional ByVal CSeparator As Char = " "c) As Object Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_DCSE.ExecScriptCommand
        Try
            Return DCB_DCSE_OPER_Executer(PID, CMD, CSeparator)
        Catch
        End Try
    End Function
    Public Sub UNI_DCSE_EXEC_ExecScriptFile(ByVal pid As String, ByVal Path As String, Optional ByVal CallProc As String = "", Optional ByVal Parametrs As String = "") Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_DCSE.ExecScript
        DCB_DCSE_OPER_ExecScriptFile(pid, Path, CallProc, Parametrs)
    End Sub
    Public Function UNI_DCSE_EXEC_GetProcSource(ByVal PID As String, ByVal Path As String, ByVal Proc As String) As String Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_DCSE.GetProcSource
        Return DCB_DCSE_OPER_GetProcSRC(Path, Proc)
    End Function

End Class

Module DCSE


    Friend Function DCB_DCSE_OPER_GetProcSRC(ByVal Path As String, ByVal Proc As String) As String
        '----------------------------------------
        ' Возвращает содержимое процедуры скрипта
        '----------------------------------------
        ' Created by Garikk
        '----------------------------------------
        Dim Script As System.IO.File
        Dim Reader As System.IO.StreamReader
        Dim Tmp As String
        Dim Buff As String
        Path = Application.StartupPath & "\scripts\" & Path
        Reader = New System.IO.StreamReader(Script.OpenText(Path).BaseStream, System.Text.Encoding.Default)
        Tmp = ""
        Try
            Do Until Tmp.ToLower = ("proc " & Proc).ToLower
                Tmp = Reader.ReadLine
            Loop
        Catch
            Reader.Close()
            Return ""
        End Try
        Buff = ""
        Try
            Tmp = Reader.ReadLine
            Do
                Buff += Tmp & vbCrLf
                Tmp = Reader.ReadLine
            Loop While Tmp.ToLower.Trim <> "end proc"
        Catch
            Reader.Close()
            Return Buff
        End Try
        Reader.Close()
        Return Buff
    End Function

    Public Function DCB_DCSE_OPER_ExecScriptFile(ByVal PID As String, ByVal Path As String, ByVal Proc As String, Optional ByVal Params As String = "") As Object
        '----------------------------------------
        ' Выполняет скрипт содержащийся в файле, поддержка процедур
        '----------------------------------------
        ' Created by Garikk
        '----------------------------------------
        Dim Script As System.IO.File
        Dim Reader As System.IO.StreamReader
        Dim ScriptCmd As String
        Dim ScriptCmds() As String
        Dim ScriptRoot As String

        '-------------------------
        ' Отчёт в режиме отладки
        If DCB_BaseSettings.Debugmode = True Then
            DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk("0", CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "<Debug><DCB_ScriptCall> " & Path & " " & Proc & " " & Params, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Purple)
        End If
        '-------------------------
        ' Выполнение скрипта...поехали :)
        Try
            If Path.Trim.StartsWith("/#") Then Exit Function
            Path = Application.StartupPath & "\scripts\" & Path ' Path содержит только имя файла
            Reader = New System.IO.StreamReader(Script.OpenText(Path).BaseStream, System.Text.Encoding.Default) 'Открываем файл

            '----------------------
            ' Выполнение процедуры, если указано
            If Proc <> "" Then
                'Ищем начало процедуры, и переходим на него
                ScriptCmd = Reader.ReadLine
                Do Until ScriptCmd.ToLower = ("proc " & Proc).ToLower
                    ScriptCmd = Reader.ReadLine
                Loop
            End If
            '----------------------
            ' Выполняем скрипт
            Do
                Dim EB As System.Text.ASCIIEncoding
                ScriptCmd = Reader.ReadLine.Trim ' Отрезаем лишнее :)
                If Proc <> "" Then ScriptCmd = ScriptCmd.Replace("%procname%", Proc)
                '------------------------------------
                ' Выполнение специальных комманд dcse
                If ScriptCmd = "dcse_blocknodirectcall" And Proc = "" Then Reader.Close() : Return True ' Блокировка прямого вызова файлов с процедурами
                '------------------------------------
                If DCB_DCSE_OPER_SpecialModes(ScriptCmd, Reader) = False Then ' Special modes -- выполнение расширений (например /loadblock)
                    If ScriptCmd.ToLower = "end proc" Then Exit Do
                    '------------------------------------------------------------------------------
                    ScriptCmd = DCB_DCSE_OPER_ScriptReplaces(PID, ScriptCmd, Params) ' Замена переменных
                    '------------------------------------------------------------------------------
                    '------------------------------------------------------------------------------
IF_EXECCYCLE:       ' выполнение комманды IF
                    '-------------------------------------------
                    If ScriptCmd.StartsWith("PID=") = True Then
                        ScriptRoot = ScriptCmd.Substring(4) ' Установка отношения скрипта к плагину
                    ElseIf ScriptCmd.ToLower.Trim = "dcse_haltscript" Then
                        GoTo dcse_haltscript                ' Остановка выполнения скрипа
                    ElseIf ScriptCmd.StartsWith("if") Then
                        '-----------------------------------> IF одноуровневый, однокоммандный
                        Dim ARet As String = DCSE.DCB_DCSE_OPER_Executer(ScriptRoot, ScriptRoot & " " & ScriptCmd.Split()(1))
                        If ARet.ToString.ToLower = ScriptCmd.Split()(2).ToLower Then
                            ScriptCmd = ScriptCmd.Split(":"c)(1)
                            GoTo IF_EXECCYCLE
                        End If
                    Else
                        '!!!!!Отправка в обработчик комманд!!!
                        If ScriptCmd <> "" Then DCB_DCSE_OPER_Executer(ScriptRoot, ScriptRoot & " " & ScriptCmd)
                    End If

                End If
            Loop
dcse_haltscript:  ' Отмена выполнения скрипта
            'DCB_ExecScript = True
            Reader.Close() ' Отключение чтения файлов
        Catch
            Try : Reader.Close() : Catch : End Try ' Отключение чтения файлов
            ' DCB_ExecScript = False
        End Try
    End Function
    Private Function DCB_DCSE_OPER_ScriptReplaces(ByVal pid As String, ByVal CMD As String, ByVal parametrs As String) As String
        '----------------------------------------
        ' Замена переменных в комманде
        ' Version 0.2
        '----------------------------------------
        ' Created by Garikk
        '----------------------------------------
        ' сложные замены
        Dim tmp As Integer
        Dim FStep1 As Integer
        Dim FStep2 As Integer
        Dim ASK As String
        Dim PRM(5) As String

        Try : parametrs = parametrs.Substring(parametrs.Split(Space(1).ToCharArray)(0).Length + 1) : Catch : End Try
        Dim PSplit() As String = parametrs.Split


        Try
            For tmp = 1 To 5

                ' Сочетания $$1 - $$2 ....
                FStep1 = CMD.IndexOf("$$" & tmp)
                If FStep1 > 0 Then
                    If CMD.Substring(0, FStep1 - 1) = "#" Or CMD.Substring(0, FStep1 - 1) = "#" Then
                        If PRM(tmp) = "" Then Return "/#"
                        CMD.Replace("$$" & tmp, PRM(tmp))
                    End If
                End If
            Next

            ' простые замены $1 - $5

            Try
                CMD = CMD.Replace("$1-", PSplit(0).Trim)
                CMD = CMD.Replace("$2-", parametrs.Substring(PSplit(0).Length + 1))
                CMD = CMD.Replace("$3-", parametrs.Substring(PSplit(0).Length + 1 + PSplit(1).Length + 1))
                CMD = CMD.Replace("$4-", parametrs.Substring(PSplit(0).Length + 1 + PSplit(1).Length + 1 + PSplit(2).Length))
                CMD = CMD.Replace("$5-", parametrs.Substring(PSplit(0).Length + 1 + PSplit(1).Length + 1 + PSplit(2).Length + 1 + PSplit(3).Length + 1))
            Catch
            End Try
            '----------------------

            For tmp = 1 To PSplit.Length
                CMD = CMD.Replace("$" & tmp, PSplit(tmp - 1))
            Next
            ' Сброс неиспользуемых маркеров

            For tmp = 1 To 10
                CMD = CMD.Replace("$" & tmp, "")
            Next


            CMD = CMD.Replace("%PID%", pid)

            'Inputbox
            If CMD.IndexOf("$?=") > 0 Then
                'Вытаскиваем вопрос
                Dim IBoxtext As String
                IBoxtext = CMD.Substring(CMD.IndexOf("$?=") + 3, CMD.IndexOf("=?$") - CMD.IndexOf("$?=") - 3)
                IBoxtext = InputBox(IBoxtext)
                CMD = CMD.Replace(CMD.Substring(CMD.IndexOf("$?="), CMD.IndexOf("=?$") - CMD.IndexOf("$?=") + 3), IBoxtext)
            End If


        Catch e As Exception
            ' Stop

        End Try
        Return (CMD)
    End Function
    Private Function DCB_DCSE_OPER_SpecialModes(ByVal scriptcmd As String, ByRef Reader As System.IO.StreamReader) As Boolean
        '----------------------------------------
        ' Выполнение расширенных комманд
        '----------------------------------------
        ' Created by Garikk
        '----------------------------------------
        If scriptcmd.StartsWith("/loadblock") Then ' Выборка блока /loadblock
            Dim Sendblockto As String
            Sendblockto = scriptcmd.Substring("/loadblock".Length)
            '  Отправка блока на выполнение
            DCB_DCSE_OPER_Executer("", Sendblockto & " " & vbCr & DCB_DCSE_OPER_BlockLoader(Reader))
            Return True
        End If
    End Function
    Private Function DCB_DCSE_OPER_BlockLoader(ByRef Reader As System.IO.StreamReader) As String
        '----------------------------------------
        ' Составление блока для комманды /loadblock
        '----------------------------------------
        ' Created by Garikk
        '----------------------------------------
        Dim Block As String
        Dim RLine As String = " "
        Do While RLine.Trim.StartsWith("/endblock") = False
            Block &= RLine
            RLine = Reader.ReadLine & vbCr
        Loop
        Return Block.Trim
    End Function
    'Private Overloads Function BlockLoader(ByRef SBlock() As String, ByRef Offset As Integer) As String
    '    Dim Block As String
    '    Dim RLine As String = " "
    '    Dim Tmp As Integer
    '    'Dim tmp2 As Integer = Offset

    '    For Tmp = Offset To UBound(SBlock)
    '        If SBlock(Tmp).TrimStart.StartsWith("/endblock") Then Exit For
    '        RLine = SBlock(Tmp) & vbCr
    '        Block &= RLine
    '    Next
    '    Offset = Offset + Tmp
    '    Return Block.Trim
    'End Function


    Private Function DCB_DCSE_OPER_Int_ExecBaseScript(ByVal CMD As String, Optional ByVal CSeprator As Char = " "c) As Object
        ' Комманды для базы
        Dim Cmds() As String
        Dim tmp As String
        Dim NItem As MenuItem
        Select Case CMD.Split(CSeprator)(0)
            Case "addbasemenu" ' Добавление меню в основную строчку
                'Cmds = CMD.Substring("addbasemenu".Length + 1).Split(vbCr)
                'DCB_Int_MenuManager(Cmds, DCB_DCTL.DCB_GetCurrentChannelDCC.CHLMainMenu)

            Case "exit", "quit"
                If CMD.EndsWith("p") Then
                    ShowExit()
                Else
                    Chat.CloseChat(False)
                End If
            Case "dcb_createsettingstree"
                Cmds = CMD.Substring(CMD.Split(CSeprator)(0).Length).Trim.Split(vbCr)
                DCBGUI_SettingsWindow_CreateTree(Cmds)
            Case "dcb_dcgui_addsettingspanel"
                dcb_dcgui_addsettingspanel(CMD.Substring("dcb_dcgui_addsettingspanel".Length + 1))
            Case "showabout"
                frmAbout.DefInstance.Show()
            Case "showhelp"
                DCB_DCTL.DCB_GetHelpProvider.SetShowHelp(DCB_DCTL.DCB_GetMainForm, True)
            Case "printincon"
                CMD = CMD.Substring("printincon".Length + 1)
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, CMD, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Black)
            Case "displaymainmenu"
                DCB_DCTL.DCB_GetMainForm.Menu.MergeMenu(DCB_DCTL.DCB_GetCurrentChannelDCC.CHLMainMenu)
            Case "displayteststring"
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "This is test string :-) How are you? :-))", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
            Case "showoptions"
                frmSettings.DefInstance.trwSettings.Nodes.Clear()
                frmSettings.DefInstance.fraSettings.Controls.Clear()
                DCSE.DCB_DCSE_OPER_ExecScriptFile("/base", "base_settings_dcgui.dcscript", "settingswindowshow")
                DCB_PMGR_CALLPLUGINSCRIPTS("$showopionswindow$", , True)
                frmSettings.DefInstance.ShowDialog()
            Case "textabout"
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "DChat, Created by Garikk", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
            Case "playsnd"
                sndPlaySound(CMD.Substring(7).Trim, 1)
            Case "showdcconsole"
                'DCB_BASE_CHL_CTL.DChannel("main").tbsCH.Visible = Not DCB_BASE_CHL_CTL.DChannel("main").tbsCHL.Visible

            Case "rundebug"
                DebugModeControl(Not DCB_BaseSettings.Debugmode)
                'Case "dcb_basictextcontrol"
                '    Return DCB_BasicTextControl(CMD)
            Case "dcb_hotkeypnl"
                Return frmSettings.DefInstance.pnlInterface_Other
            Case "dcb_pluginspnl"
                Return frmSettings.DefInstance.pnlPlugins
            Case "dcb_getfontinfo"
                Return New Font(DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)
            Case "dcb_getbackwndcolor"
                Return DCB_ColorSettings.BackChatColor
            Case "base_getnetsocket"
                Return New DCB_NET_Socket
        End Select
    End Function

    'Public Function DCB_ScriptCommandExecuter(ByVal PID As String, ByVal cmd As String, Optional ByVal GetObj As Boolean = False) As Object
    '    'Обработчик консольных комманд
    '    Dim CMDArgs As String() = Split(cmd.Trim)
    '    Dim ArgStep As String
    '    Dim NormRes As String
    '    'Dim CurChl As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = DCB_DCTL.DCB_GetCurrentChannelDCC
    '    cmd = cmd.Trim
    '    cmd = cmd.Replace("%PID%", PID)
    '    If DCB_BaseSettings.Debugmode = True Then
    '        DCB_BASE_CHL_CTL.DCB_Talk("0", CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "<Debug><DCB_DCSE> " & cmd, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Purple)
    '    End If
    '    If cmd.StartsWith("/exec") Then

    '        Dim CallStr As String

    '        Try : CallStr = CMDArgs(2) : Catch : End Try
    '        Return DCB_ExecScriptFile(PID, CMDArgs(1), CallStr, cmd.Substring(CMDArgs(0).Length + 1 + CMDArgs(1).Length).Trim)

    '    ElseIf cmd.Trim.StartsWith("/#") Then
    '        Exit Function
    '    ElseIf cmd.StartsWith("/loadplugin") Then
    '        DCB_PMGR_InitPlugin(CMDArgs(1).Trim) ', CMDArgs(2).Trim)
    '    ElseIf cmd.StartsWith("/base ") And GetObj = False Then
    '        DCB_Int_ExecBaseScript(cmd.Substring(6).Trim)
    '    ElseIf cmd.StartsWith("/baseobj") Or (cmd.StartsWith("/base") And GetObj = True) Then
    '        If cmd.StartsWith("/baseobj") Then Return DCB_GetBaseObj(cmd.Substring(9).Trim)
    '        If cmd.StartsWith("/base") Then Return DCB_GetBaseObj(cmd.Substring(6).Trim)
    '    ElseIf cmd.StartsWith("dcb_getrtf") Then
    '        Return DC2Conv.dc2toRTF(cmd.Substring(10).Trim, DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)
    '    ElseIf cmd.StartsWith("dcb_getdc2") Then
    '        Return DC2Conv.RTFToDC2(cmd.Substring(10).Trim)
    '    ElseIf cmd.StartsWith("dcb_getcurchldcc") Then
    '        Return DCB_DCTL.DCB_GetCurrentChannelDCC
    '    ElseIf cmd.StartsWith("dcb_getcurchlid") Then
    '        Return DCB_DCTL.DCB_GetCurrentChannel
    '    ElseIf cmd.StartsWith("dcb_delchl") Then
    '        DCB_BASE_CHL_CTL.DelCHL(cmd.Substring(11))

    '    Else

    '        If GetObj = True Then
    '            Return DCB_PMGR_CALLPLUGINSCRIPTS(cmd, True)
    '        Else
    '            DCB_PMGR_CALLPLUGINSCRIPTS(cmd)
    '        End If
    '    End If


    'End Function
    Friend Function DCB_DCSE_OPER_Executer(ByVal PID As String, ByVal CMD As String, Optional ByVal CSeparator As Char = " "c) As Object
        '----------------------------------------
        ' Главный обработчик комманд
        '----------------------------------------
        ' Created by Garikk
        '----------------------------------------
        'Предварительная подготовка комманды
        CMD = CMD.Trim
        Dim CMDArgs As String() = Split(CMD, CSeparator)
        CMD = CMD.Replace("%PID%", PID) ' Замена переменной PID
        '------------------------
        ' Запись отладочной информации
        If DCB_BaseSettings.Debugmode = True Then
            DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk("0", CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "<Debug><DCB_DCSE> " & CMD, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Purple)
        End If
        '------------------------
        If CMD = "/#" Then Exit Function
        '------------------------
        Select Case CMD.Split(CSeparator)(0)
            Case "/exec" ' Выполнение скрипт-файла
                Dim CallStr As String
                Try : CallStr = CMDArgs(2) : Catch : End Try
                Return DCB_DCSE_OPER_ExecScriptFile(PID, CMDArgs(1), CallStr, CMD.Substring(CMDArgs(0).Length + 1 + CMDArgs(1).Length).Trim)
            Case "/loadplugin" ' Принудительная загрузка плагина
                DCB_PMGR_InitPlugin(CMDArgs(1).Trim) ', CMDArgs(2).Trim)
            Case "/base", "/baseobj"       ' Вызов комманд базы DC
                Return DCB_DCSE_OPER_Int_ExecBaseScript(CMD.Substring(CMD.Split(CSeparator)(0).Length).Trim, CSeparator)
            Case "dcb_getcurchldcc"
                Return DCB_DCTL.DCB_GetCurrentChannelDCC
            Case "dcb_getcurchldcc"
                Return DCB_DCTL.DCB_GetCurrentChannelDCC
            Case "dcb_getcurchlid"
                Return DCB_DCTL.DCB_GetCurrentChannel
            Case "dcb_delchl"
                DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_DelCHL(CMD.Substring(11))
            Case "dcb_pmgr_getpluginshashtable"
                Return PMGR.DCB_Plugins.GetMainCollection
            Case "dcb_getrootpath"
                Return Application.StartupPath
            Case Else
                Return DCB_PMGR_CALLPLUGINSCRIPTS(CMD, , , CSeparator)
        End Select
    End Function

    'Public Function DCB_BasicTextControl(ByVal Cmd As String) As String
    '    'If Not Cmd.ToLower.Trim.StartsWith("/base" & Chr(1) & "dcb_basictextcontrol") Then Return "1"
    '    Cmd = Cmd.ToLower.Trim.Substring("dcb_basictextcontrol".Length + 1)
    '    Select Case Cmd.Split(Chr(1))(0)
    '        Case "rtf2irc"
    '            Dim TL As String = Cmd.Split(Chr(1))(1)
    '            Return DCB_TEXTWRK_RTF2IRC(TL)

    '        Case "irc2rtf"
    '            Dim TL As String = Cmd.Split(Chr(1))(3)
    '            Dim FNT As String = Cmd.Split(Chr(1))(1)
    '            Dim SIZ As Integer = Cmd.Split(Chr(1))(2)
    '            Return DCB_TEXTWRK_TXT2RTF(TL, fnt, siz)
    '        Case "txt2rtf"
    '            Dim TL As String = Cmd.Split(Chr(1))(3)
    '            Dim FNT As String = Cmd.Split(Chr(1))(1)
    '            Dim SIZ As Integer = Cmd.Split(Chr(1))(2)
    '            Return DCB_TEXTWRK_TXT2RTF(TL, fnt, siz)

    '        Case "rtf2txt"
    '            Dim TL As String = Cmd.Split(Chr(1))(1)
    '            Return DCB_TEXTWRK_RTF2TXT(TL)
    '        Case "getargbfromirccode"
    '            Return Color.Black.ToArgb
    '        Case "getirccodefroemargb"
    '            Return 1
    '        Case "descriptionline"
    '            Return "DCB IRC-Text processor v.1.0, DChat, freza.net 2005. Created by Garikk"
    '        Case "removeirccodes"
    '            Return Cmd

    '    End Select
    'End Function
    'Private Function DCB_TEXTWRK_RTF2TXT(ByVal rtf As String) As String
    '    Static R As New RichTextBox
    '    R.Rtf = rtf
    '    R.SelectAll()
    '    Return R.SelectedText
    'End Function
    'Private Function DCB_TEXTWRK_RTF2IRC(ByVal rtf As String) As String
    '    Return DCB_TEXTWRK_RTF2TXT(rtf)
    'End Function
    'Private Function DCB_TEXTWRK_TXT2RTF(ByVal txt As String, ByVal Fnt As String, ByVal Size As Integer) As String
    '    Static r As New RichTextBox
    '    r.Text = txt
    '    r.SelectAll()
    '    Return r.SelectedRtf
    'End Function
End Module