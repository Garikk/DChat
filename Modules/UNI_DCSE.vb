''------------------------------------------------------------------------------------
'' DZFS.NET 2004
'' DChat project
'' DCSE
''------------------------------------------------------------------------------------
'' Programmed by Garikk
'' DChat Scripting Engine (DCSE)
''------------------------------------------------------------------------------------
'Imports DCB_Interface

'Public Class DCB_DCSE_FORPLUGINS
'    ' Ссылка для плагинов для доступа к DCSE
'    Implements DCB_V1.DCB_Base.DCB_DCSE


'    Public Function ExecScriptCommand(ByVal PID As String, ByVal CMD As String) As Object Implements DCB_V1.DCB_Base.DCB_DCSE.ExecScriptCommand
'        Try
'            Return DCB_ScriptCommandExecuter(PID, CMD)
'        Catch
'        End Try
'    End Function
'    Public Sub ExecScript(ByVal pid As String, ByVal Path As String, Optional ByVal CallProc As String = "", Optional ByVal Parametrs As String = "") Implements DCB_V1.DCB_Base.DCB_DCSE.ExecScript
'        DCB_ExecScript(pid, Path, CallProc, Parametrs)
'    End Sub
'    Public Function GetProcSource(ByVal PID As String, ByVal Path As String, ByVal Proc As String) As String Implements DCB_Interface.DCB_V1.DCB_Base.DCB_DCSE.GetProcSource
'        Return GetProcSRC(Path, Proc)
'    End Function
'    'Public Sub ExecScriptBlock(ByVal PID As String, ByVal Block As String) Implements DCB_V1.DCB_Base.DCB_DCSE.ExecScriptBlock
'    '    ' Пока неработает
'    '    'DCB_ExecScriptBlock(Block)
'    'End Sub
'    'Public Function ExecScriptCommandOF(ByVal CMD As String) As Object Implements DCB_V1.DCB_Base.DCB_DCSE.ExecScriptCommandF
'    '    Return DCB_ExScriptFunc(CMD)
'    'End Function
'End Class

'Module DCSE
'    Dim wrk As String
'    Dim zScrPath
'    Dim zCallProc
'    Dim zParam1
'    Dim zParam2
'    Dim zParam3
'    Dim zParam4
'    Dim zParam5

'    'Public Function DCB_ExScriptFunc(ByVal CMD As String) As Object
'    '    Dim cmds() As String = CMD.Split

'    '    Select Case cmds(0)

'    '    End Select
'    '   End Function
'    Friend Function GetProcSRC(ByVal Path As String, ByVal Proc As String) As String
'        Dim Script As System.IO.File
'        Dim Reader As System.IO.StreamReader
'        Dim Tmp As String
'        Dim Buff As String
'        Path = Application.StartupPath & "\scripts\" & Path
'        Reader = New System.IO.StreamReader(Script.OpenText(Path).BaseStream, System.Text.Encoding.Default)
'        Tmp = ""
'        Try
'            Do Until Tmp.ToLower = ("proc " & Proc).ToLower
'                Tmp = Reader.ReadLine
'            Loop
'        Catch
'            Reader.Close()
'            Return ""
'        End Try
'        Buff = ""
'        Try
'            Tmp = Reader.ReadLine
'            Do
'                Buff += Tmp & vbCrLf
'                Tmp = Reader.ReadLine
'            Loop While Tmp.ToLower.Trim <> "end proc"
'        Catch
'            Reader.Close()
'            Return Buff
'        End Try
'        Reader.Close()
'        Return Buff
'    End Function


'    Public Function DCB_ExecScript(ByVal PID As String, ByVal ScrPath As String, ByVal CallProc As String, Optional ByVal Parametrs As String = "") As Boolean
'        Dim Script As System.IO.File
'        Dim Reader As System.IO.StreamReader
'        Dim ScriptCmd As String
'        Dim ScriptCmds() As String
'        Dim ScriptRoot As String
'        '   Dim Variables(10, 1) As String
'        If DCB_BaseSettings.Debugmode = True Then
'            DCB_BASE_CHL_CTL.DCB_Talk("0", CHLMain, DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "<Debug><DCB_ScriptCall> " & ScrPath & " " & CallProc & " " & Parametrs, DCB_V1.DCB_Base.DCB_IRCColors.Purple)
'        End If
'        Try
'            If ScrPath.Trim.StartsWith("/#") Then Exit Function
'            ScrPath = Application.StartupPath & "\scripts\" & ScrPath
'            Reader = New System.IO.StreamReader(Script.OpenText(ScrPath).BaseStream, System.Text.Encoding.Default)

'            If CallProc <> "" Then
'                'Ищем начало CallProc
'                ScriptCmd = Reader.ReadLine
'                Do Until ScriptCmd.ToLower = ("proc " & CallProc).ToLower
'                    ScriptCmd = Reader.ReadLine
'                Loop
'            End If

'            Do
'                Dim EB As System.Text.ASCIIEncoding
'                'Reader.ReadLine()
'                ScriptCmd = Reader.ReadLine.Trim
'                If CallProc <> "" Then ScriptCmd = ScriptCmd.Replace("%procname%", CallProc)
'                If ScriptCmd = "dcse_blocknodirectcall" And CallProc = "" Then Reader.Close() : Return True
'                ' If ScriptCmd.Trim.EndsWith("\\$trim") Then ScriptCmd = ScriptCmd.Substring(ScriptCmd.Length - 7).Trim
'                If SpecialModes(ScriptCmd, Reader) = False Then
'                    If ScriptCmd.ToLower = "end proc" Then Exit Do
'                    '------------------------------------------------------------------------------
'                    ScriptCmd = DCSE_ScriptReplaces(PID, ScriptCmd, Parametrs)
'                    '------------------------------------------------------------------------------
'                    '------------------------------------------------------------------------------
'IF_EXECCYCLE:       ' выполнение комманды IF
'                    '-------------------------------------------
'                    If ScriptCmd.StartsWith("PID=") = True Then
'                        ScriptRoot = ScriptCmd.Substring(4)
'                    ElseIf ScriptCmd.ToLower.Trim = "dcse_haltscript" Then
'                        GoTo dcse_haltscript
'                    ElseIf ScriptCmd.StartsWith("if") Then
'                        ' IF одноуровневый, однокоммандный
'                        Dim ARet As String = DCSE.DCB_ScriptCommandExecuter(ScriptRoot, ScriptRoot & " " & ScriptCmd.Split()(1), True)
'                        If ARet.ToString.ToLower = ScriptCmd.Split()(2).ToLower Then
'                            ScriptCmd = ScriptCmd.Split(":"c)(1)
'                            GoTo IF_EXECCYCLE
'                        End If
'                    Else
'                        '----EXEC----
'                        If ScriptCmd <> "" Then DCB_ScriptCommandExecuter(ScriptRoot, ScriptRoot & " " & ScriptCmd)
'                    End If
'                End If
'            Loop
'dcse_haltscript:  ' Отмена выполнения скрипта
'            DCB_ExecScript = True
'            Reader.Close()
'        Catch
'            Try : Reader.Close() : Catch : End Try
'            DCB_ExecScript = False
'        End Try
'    End Function
'    Friend Function DCB_VarSetMgr(ByVal Varname As String, ByVal CMDStr As String) As String


'    End Function

'    Private Function DCSE_ScriptReplaces(ByVal pid As String, ByVal CMD As String, ByVal parametrs As String) As String

'        ' сложные замены
'        Dim tmp As Integer
'        Dim FStep1 As Integer
'        Dim FStep2 As Integer
'        Dim ASK As String
'        Dim PRM(5) As String

'        Try : parametrs = parametrs.Substring(parametrs.Split(Space(1).ToCharArray)(0).Length + 1) : Catch : End Try
'        Dim PSplit() As String = parametrs.Split


'        Try
'            For tmp = 1 To 5

'                ' Сочетания $$1 - $$2 ....
'                FStep1 = CMD.IndexOf("$$" & tmp)
'                If FStep1 > 0 Then
'                    If CMD.Substring(0, FStep1 - 1) = "#" Or CMD.Substring(0, FStep1 - 1) = "#" Then
'                        If PRM(tmp) = "" Then Return "/#"
'                        CMD.Replace("$$" & tmp, PRM(tmp))
'                    End If
'                End If
'            Next

'            ' простые замены $1 - $5

'            Try
'                CMD = CMD.Replace("$1-", PSplit(0).Trim)
'                CMD = CMD.Replace("$2-", parametrs.Substring(PSplit(0).Length + 1))
'                CMD = CMD.Replace("$3-", parametrs.Substring(PSplit(0).Length + 1 + PSplit(1).Length + 1))
'                CMD = CMD.Replace("$4-", parametrs.Substring(PSplit(0).Length + 1 + PSplit(1).Length + 1 + PSplit(2).Length))
'                CMD = CMD.Replace("$5-", parametrs.Substring(PSplit(0).Length + 1 + PSplit(1).Length + 1 + PSplit(2).Length + 1 + PSplit(3).Length + 1))
'            Catch
'            End Try
'            '----------------------

'            For tmp = 1 To PSplit.Length
'                CMD = CMD.Replace("$" & tmp, PSplit(tmp - 1))
'            Next
'            ' Сброс неиспользуемых маркеров

'            For tmp = 1 To 10
'                CMD = CMD.Replace("$" & tmp, "")
'            Next


'            CMD = CMD.Replace("%PID%", pid)

'            'Inputbox
'            If CMD.IndexOf("$?=") > 0 Then
'                'Вытаскиваем вопрос
'                Dim IBoxtext As String
'                IBoxtext = CMD.Substring(CMD.IndexOf("$?=") + 3, CMD.IndexOf("=?$") - CMD.IndexOf("$?=") - 3)
'                IBoxtext = InputBox(IBoxtext)
'                CMD = CMD.Replace(CMD.Substring(CMD.IndexOf("$?="), CMD.IndexOf("=?$") - CMD.IndexOf("$?=") + 3), IBoxtext)
'            End If


'        Catch e As Exception
'            ' Stop

'        End Try
'        Return (CMD)
'    End Function
'    Private Function SpecialModes(ByVal scriptcmd As String, ByRef Reader As System.IO.StreamReader) As Boolean

'        If scriptcmd.StartsWith("/loadblock") Then
'            Dim Sendblockto As String
'            Sendblockto = scriptcmd.Substring("/loadblock".Length)
'            '  Offset += 1
'            DCSE.DCB_ScriptCommandExecuter("", Sendblockto & vbCr & BlockLoader(Reader))
'            Return True

'        End If
'    End Function

'    Private Overloads Function BlockLoader(ByRef Reader As System.IO.StreamReader) As String
'        Dim Block As String
'        Dim RLine As String = " "
'        Do While RLine.Trim.StartsWith("/endblock") = False
'            Block &= RLine
'            RLine = Reader.ReadLine & vbCr
'        Loop
'        Return Block.Trim
'    End Function
'    Private Overloads Function BlockLoader(ByRef SBlock() As String, ByRef Offset As Integer) As String
'        Dim Block As String
'        Dim RLine As String = " "
'        Dim Tmp As Integer
'        'Dim tmp2 As Integer = Offset

'        For Tmp = Offset To UBound(SBlock)
'            If SBlock(Tmp).TrimStart.StartsWith("/endblock") Then Exit For
'            RLine = SBlock(Tmp) & vbCr
'            Block &= RLine
'        Next
'        Offset = Offset + Tmp
'        Return Block.Trim
'    End Function
'    Private Function CheckHeader(ByRef Scr As System.IO.TextReader)
'        Dim SHeader As String
'        Dim SVersion As String
'        SHeader = Scr.ReadLine
'        SVersion = Scr.ReadLine
'    End Function

'    Private Sub DCB_Int_ExecBaseScript(ByVal CMD As String)
'        ' Комманды для базы
'        Dim Cmds() As String
'        Dim tmp As String
'        Dim NItem As MenuItem
'        If CMD.StartsWith("addbasemenu") Then ' Добавление меню в основную строчку
'            'Cmds = CMD.Substring("addbasemenu".Length + 1).Split(vbCr)
'            'DCB_Int_MenuManager(Cmds, DCB_DCTL.DCB_GetCurrentChannelDCC.CHLMainMenu)

'        ElseIf CMD.StartsWith("exit") Or CMD.StartsWith("quit") Then
'            If CMD.EndsWith("p") Then
'                ShowExit()
'            Else
'                Chat.CloseChat(False)
'            End If
'        ElseIf CMD.StartsWith("dcb_createsettingstree") Then
'            Cmds = CMD.Substring("dcb_createsettingstree".Length + 1).Split(vbCr)
'            DCBGUI_SettingsWindow_CreateTree(Cmds)
'        ElseIf CMD.StartsWith("dcb_dcgui_addsettingspanel") Then
'            dcb_dcgui_addsettingspanel(CMD.Substring("dcb_dcgui_addsettingspanel".Length + 1))
'        ElseIf CMD.StartsWith("showabout") Then
'            frmAbout.DefInstance.Show()
'        ElseIf CMD.StartsWith("showhelp") Then
'            DCB_DCTL.DCB_GetHelpProvider.SetShowHelp(DCB_DCTL.DCB_GetMainForm, True)
'        ElseIf CMD.StartsWith("printincon") Then
'            CMD = CMD.Substring("printincon".Length + 1)
'            DCB_BASE_CHL_CTL.DCB_Talk(ConsTalk, CHLMain, DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_UNAME, CMD, DCB_V1.DCB_Base.DCB_IRCColors.Black)
'        ElseIf CMD.StartsWith("displaymainmenu") Then
'            DCB_DCTL.DCB_GetMainForm.Menu.MergeMenu(DCB_DCTL.DCB_GetCurrentChannelDCC.CHLMainMenu)
'        ElseIf CMD.StartsWith("displayteststring") Then
'            DCB_BASE_CHL_CTL.DCB_Talk(ConsTalk, CHLMain, DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "This is test string :-) How are you? :-))", DCB_V1.DCB_Base.DCB_IRCColors.Red)
'        ElseIf CMD.StartsWith("showoptions") Then
'            frmSettings.DefInstance.trwSettings.Nodes.Clear()
'            frmSettings.DefInstance.fraSettings.Controls.Clear()
'            DCSE.DCB_ExecScript("/base", "base_settings_dcgui.dcscript", "settingswindowshow")
'            DCB_PMGR_CALLPLUGINSCRIPTS("$showopionswindow$", , True)
'            frmSettings.DefInstance.ShowDialog()
'        ElseIf CMD.StartsWith("textabout") Then
'            DCB_BASE_CHL_CTL.DCB_Talk(ConsTalk, CHLMain, DCB_V1.DCB_Base.DCB_MessageTypes.MSG_TXTCOLORED_NOTUNAME, "DChat, Created by Garikk", DCB_V1.DCB_Base.DCB_IRCColors.Red)
'        ElseIf CMD.StartsWith("playsnd") Then
'            sndPlaySound(CMD.Substring(7).Trim, 1)
'        ElseIf CMD.StartsWith("showdcconsole") Then
'            'DCB_BASE_CHL_CTL.DChannel("main").tbsCH.Visible = Not DCB_BASE_CHL_CTL.DChannel("main").tbsCHL.Visible

'        ElseIf CMD.StartsWith("rundebug") Then
'            DebugModeControl(Not DCB_BaseSettings.Debugmode)
'        ElseIf CMD.StartsWith("dcb_basictextcontrol") Then
'            DCB_BasicTextControl(CMD)
'        End If
'    End Sub
'    Public Function DCB_BasicTextControl(ByVal Cmd As String) As String

'    End Function
'    Public Function DCB_ScriptCommandExecuter(ByVal PID As String, ByVal cmd As String, Optional ByVal GetObj As Boolean = False) As Object
'        'Обработчик консольных комманд
'        Dim CMDArgs As String() = Split(cmd.Trim)
'        Dim ArgStep As String
'        Dim NormRes As String
'        'Dim CurChl As DCB_V1.DCB_Channels2.DCB_Channel = DCB_DCTL.DCB_GetCurrentChannelDCC
'        cmd = cmd.Trim
'        cmd = cmd.Replace("%PID%", PID)
'        If DCB_BaseSettings.Debugmode = True Then
'            DCB_BASE_CHL_CTL.DCB_Talk("0", CHLMain, DCB_V1.DCB_Base.DCB_MessageTypes.MSG_DC2_NOTUNAME, "<Debug><DCB_DCSE> " & cmd, DCB_V1.DCB_Base.DCB_IRCColors.Purple)
'        End If
'        If cmd.StartsWith("/exec") Then

'            Dim CallStr As String

'            Try : CallStr = CMDArgs(2) : Catch : End Try
'            Return DCB_ExecScript(PID, CMDArgs(1), CallStr, cmd.Substring(CMDArgs(0).Length + 1 + CMDArgs(1).Length).Trim)

'        ElseIf cmd.Trim.StartsWith("/#") Then
'            Exit Function
'        ElseIf cmd.StartsWith("/loadplugin") Then
'            DCB_PMGR_InitPlugin(CMDArgs(1).Trim) ', CMDArgs(2).Trim)
'        ElseIf cmd.StartsWith("/base ") And GetObj = False Then
'            DCB_Int_ExecBaseScript(cmd.Substring(6).Trim)
'        ElseIf cmd.StartsWith("/baseobj") Or (cmd.StartsWith("/base") And GetObj = True) Then
'            If cmd.StartsWith("/baseobj") Then Return DCB_GetBaseObj(cmd.Substring(9).Trim)
'            If cmd.StartsWith("/base") Then Return DCB_GetBaseObj(cmd.Substring(6).Trim)
'        ElseIf cmd.StartsWith("dcb_getrtf") Then
'            Return DC2Conv.IRC2RTF(cmd.Substring(10).Trim, DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)
'        ElseIf cmd.StartsWith("dcb_getdc2") Then
'            Return DC2Conv.RTF2IRC(cmd.Substring(10).Trim)
'        ElseIf cmd.StartsWith("dcb_getcurchldcc") Then
'            Return DCB_DCTL.DCB_GetCurrentChannelDCC
'        ElseIf cmd.StartsWith("dcb_getcurchlid") Then
'            Return DCB_DCTL.DCB_GetCurrentChannel
'        ElseIf cmd.StartsWith("dcb_delchl") Then
'            DCB_BASE_CHL_CTL.DelCHL(cmd.Substring(11))

'        Else

'            If GetObj = True Then
'                Return DCB_PMGR_CALLPLUGINSCRIPTS(cmd, True)
'            Else
'                DCB_PMGR_CALLPLUGINSCRIPTS(cmd)
'            End If
'        End If


'    End Function
'    Friend Function DCB_GetBaseObj(ByVal Cmd As String) As Object
'        Select Case Cmd.ToLower
'            Case "dcb_hotkeypnl"
'                Return frmSettings.DefInstance.pnlInterface_Other
'            Case "dcb_pluginspnl"
'                Return frmSettings.DefInstance.pnlPlugins
'            Case "dcb_getfontinfo"
'                Return New Font(DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)
'            Case "dcb_getbackwndcolor"
'                Return DCB_ColorSettings.BackChatColor
'        End Select
'    End Function


'End Module