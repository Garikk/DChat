' DZFS.NET 2004
' DChat Project
' IRC Interface Manager
'------------------------------------------------------------------------------------
' Programmed by Garikk
' Interface manager
'------------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports System.Drawing
Imports UNI_Plugin.UNI_DChat
Imports UNI_Plugin.UNI_DChat.DCB_V1

Public Class IRCInterface
    Public ilsIRCIcons As New Windows.Forms.ImageList
    Public mnuMainIRCMenu As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("IRC", "/#")
    Public mnuUserOptsMenu As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ContextMenu ' New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("IRC", "/#")
    Public mnuCHLMenu As New ContextMenu
    Public mnuPrivCHLMenu As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ContextMenu
    Public mnuCHLList As New ContextMenu
    Public mnuUModesMenu As ContextMenu
    Public mnuFastConnList As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ContextMenu
    Sub New()
        ilsIRCIcons = InterfaceCTLS.DefInstance.ilsUserIcons
          End Sub
    Public Function GetLPanel() As Panel
        Return InterfaceCTLS.DefInstance.pnIRCPanel
    End Function
End Class
Friend Module UInterfaceControl
    Friend Sub CreateMainIRCMenu()
        Dim tmp As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem
        Dim tmp2 As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem
        Dim mnu As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem = IRC_Interface.mnuMainIRCMenu
        '---Общая главная менюшка
        mnu.Text = "IRC"
        'mnu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Информация о сервере", "%PID% irc_showserverinfowindow"))
        'mnu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        mnu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Список каналов", "%PID% irc_sendtoserver LIST"))

        '---------Менюшка окна канала
        Dim mnuCHL As ContextMenu = IRC_Interface.mnuCHLMenu
        mnuCHL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Параметры канала", "%PID% irc_getchlinfo %currentchannel%"))
        mnuCHL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        mnuCHL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Скопировать всё", "%PID% irc_copychattoclipboard %currentchannelid%"))
        mnuCHL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        mnuCHL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Сохранить как...", "%PID% irc_savechattofile %currentchannelid%"))
        mnuCHL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Очистить", "%PID% irc_clearchlwindow %currentchannelid%")
        tmp.Shortcut = Shortcut.CtrlF12
        mnuCHL.MenuItems.Add(tmp)
        
        mnuCHL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Покинуть", "%PID% /part %currentchannel%")
        tmp.Shortcut = Shortcut.CtrlF4
        mnuCHL.MenuItems.Add(tmp)
        '----------------- Hotkey
        SetHotKey(mnu, mnuCHL)
        '-----------------

        '----------- Менюшка окна привата
        ' mnuCHL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Покинуть (Почему?)", "/part %currentchannel% %askwhy%"))
        Dim mnuPRIV As ContextMenu = IRC_Interface.mnuPrivCHLMenu
        mnuPRIV.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Скопировать всё", "%PID% irc_copychattoclipboard %currentchannelid%"))
        mnuPRIV.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        mnuPRIV.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Сохранить как...", "%PID% irc_savechattofile %currentchannelid%"))
        mnuPRIV.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Очистить", "%PID% irc_clearchlwindow %currentchannelid%")
        tmp.Shortcut = Shortcut.CtrlF12
        mnuPRIV.MenuItems.Add(tmp)
        '----------------- Hotkey
        SetHotKey(mnu, mnuPRIV)
        '-----------------
              mnuPRIV.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Покинуть", "%PID% irc_leavechl %currentchannelid%")
        tmp.Shortcut = Shortcut.CtrlF4
        mnuPRIV.MenuItems.Add(tmp)
        '----------------- Hotkey
        SetHotKey(mnu, mnuPRIV)
        '-----------------
        '----------- Менюшка списка каналов
        Dim mnuCHLL As ContextMenu = IRC_Interface.mnuCHLList
        mnuCHLL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Войти на канал", "%PID% /join %selectedchlinchllist%"))
        mnuCHLL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        mnuCHLL.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Закрыть", "%PID% irc_leavechl %currentchannelid%"))

        '----------------- Hotkey
        SetHotKey(mnu, mnuCHLL)
        '-----------------

        ' ---------- Менюшка списка пользователей
        Dim mnuULIST As ContextMenu = IRC_Interface.mnuUserOptsMenu
        tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Сообщение", "%PID% irc_newquickmsg %selectedusername%")
        tmp.Shortcut = Shortcut.Ins
        mnuULIST.MenuItems.Add(tmp)
        tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Разговор", "%PID% irc_createprivate %selectedusername%")
        tmp.Shortcut = Shortcut.CtrlT
        mnuULIST.MenuItems.Add(tmp)
        'tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Сигнал", "%PID% irc_sendbeep %selectedusername% beep.wav")
        'tmp.Shortcut = Shortcut.CtrlB
        'mnuULIST.MenuItems.Add(tmp)
        tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Сказать", "%PID% irc_addsay %selectedusername%")
        tmp.Shortcut = Shortcut.CtrlN
        mnuULIST.MenuItems.Add(tmp)
       
        mnuULIST.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        mnuULIST.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Информация", "%PID% /whois %selectedusername%"))
        tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Управление", "/#")
        'tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Игнорировать", "/#"))
        'tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Неигнорировать", "/#"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Сделать ОПом (+o)", "%PID% /mode %currentchannel% +o %selectedusername%"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Убрать ОПа (-o)", "%PID% /mode %currentchannel% -o %selectedusername%"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Сделать ХОПом (+h)", "%PID% /mode %currentchannel% +h %selectedusername%"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Убрать ХОПа (-h)", "%PID% /mode %currentchannel% -h %selectedusername%"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Дать Войс (+v)", "%PID% /mode %currentchannel% +v %selectedusername%"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Убрать Войс (-v)", "%PID% /mode %currentchannel% -v %selectedusername%"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Кикнуть", "%PID% /kick %currentchannel% %selectedusername%"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Кикнуть (Почему?)", "/exec irc.dcscript KickA"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Забанить", "%PID% /mode %currentchannel% +b %selectedusername%"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Забанить и кикнуть", "/exec irc.dcscript BanAndKick"))
        tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Забанить и кикнуть (Почему?)", "/exec irc.dcscript BanAndKickA"))
        InterfaceCTLS.DefInstance.cmdUOP.DropDownMenu = IRC_Interface.mnuUserOptsMenu

        For Each tmp2 In tmp.MenuItems
            AddHandler tmp2.Click, AddressOf IRC_MenuEvent
        Next
        mnuULIST.MenuItems.Add(tmp)
        '----------------- Hotkey
        SetHotKey(mnu, mnuULIST)
        '-----------------
        'mnuULIST.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        'tmp = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("DCC", "/#")
        'tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Послать файл", "/#"))
        'tmp.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Чат", "/#"))
        'mnuULIST.MenuItems.Add(tmp)


        'Регистрация обработчиков меню

        For Each tmp In mnu.MenuItems
            AddHandler tmp.Click, AddressOf IRC_MenuEvent
        Next

        For Each tmp In mnuCHL.MenuItems
            AddHandler tmp.Click, AddressOf IRC_MenuEvent
        Next
        For Each tmp In mnuULIST.MenuItems
            AddHandler tmp.Click, AddressOf IRC_MenuEvent
        Next
        For Each tmp In mnuPRIV.MenuItems
            AddHandler tmp.Click, AddressOf IRC_MenuEvent
        Next
        For Each tmp In mnuCHLL.MenuItems
            AddHandler tmp.Click, AddressOf IRC_MenuEvent
        Next

    End Sub
    Friend Sub IRC_INTERF_CreateFCMenu()
        CreateFastConnectMenu()
        InterfaceCTLS.DefInstance.cmdTlbConnect.DropDownMenu = IRC_Interface.mnuFastConnList
    End Sub
    Friend Sub CreateFastConnectMenu()
        Dim tmp As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem
        Dim tmp2 As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem
        IRC_Interface.mnuFastConnList = Nothing
        Dim mnu As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ContextMenu = IRC_Interface.mnuFastConnList
        '---------Менюшка быстрого подключения
        IRC_Interface.mnuFastConnList = New DCB_Controls.DCB_ContextMenu
        Dim mnuFC As ContextMenu = IRC_Interface.mnuFastConnList
        Dim servs As String() = LoadLastServersList()
        Dim tmps As String
        If servs Is Nothing Then Exit Sub
        For Each tmps In servs
            If tmps <> "" Then mnuFC.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem(tmps, IRC_INF.INF_CMDEXEC & " irc_connectto " & tmps & " 6667"))
        Next
        mnuFC.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        mnuFC.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Изменить список", "/#"))
        For Each tmp In mnuFC.MenuItems
            AddHandler tmp.Click, AddressOf IRC_MenuEvent
        Next
    End Sub
    Friend Sub SetHotKey(ByRef MMenuParent As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem, ByRef HKMenu As ContextMenu)
        Dim r As DCB_Controls.DCB_MenuItem
        Dim Z As DCB_Controls.DCB_MenuItem
        For Each r In HKMenu.MenuItems
            If r.Shortcut <> Shortcut.None Then
                Z = New DCB_Controls.DCB_MenuItem("Z", "/#")
                Z.CMD = r.CMD
                Z.Text = "HKLink"
                Z.Shortcut = r.Shortcut
                Z.Visible = False
                MMenuParent.MenuItems.Add(Z)
                AddHandler Z.Click, AddressOf IRC_MenuEvent
            End If
        Next
    End Sub

    Friend Sub IRC_MenuEvent(ByVal sender As Object, ByVal e As EventArgs)
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, CType(sender, DCB_Controls.DCB_MenuItem).CMD)
    End Sub
    Friend Sub UsersList_MouseDownEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim MPoint As Point
        MPoint.X = e.X
        MPoint.Y = e.Y
        If e.Button = MouseButtons.Right Then
            Try
                CType(sender, TreeView).SelectedNode = CType(sender, TreeView).GetNodeAt(MPoint)
            Catch

            End Try
        End If
    End Sub
    Private Function CloneMenu(ByVal InMNU As DCB_Controls.DCB_ContextMenu) As DCB_Controls.DCB_ContextMenu
        Dim A As New DCB_Controls.DCB_ContextMenu
        A = InMNU
        Return A
    End Function
    Friend Sub UsersList_MouseUpEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim MousePos As Point
        MousePos.X = e.X
        MousePos.Y = e.Y

        Try
            Dim LW As ListViewItem = CType(sender, ListView).SelectedItems(0)
            LW = CType(sender, ListView).GetItemAt(e.X, e.Y)
            ' lblInfo.Text = RtfToTxt(DCB_BASE_CHL_CTL.DChannel(Gx52ToDEC(Mid(lstChl.SelectedNode.Tag, 1, 2))).CHLTOPIC)
            If e.Button = MouseButtons.Right Then
                IRC_Interface.mnuUserOptsMenu.Show(CType(sender, ListView), MousePos)
            End If
        Catch
        End Try
    End Sub

End Module
Friend Class LViewCHLSorter
    Implements IComparer
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare
        Dim TN1 As ListViewItem = CType(y, ListViewItem)
        Dim TN2 As ListViewItem = CType(x, ListViewItem)

        If TN1.Text.StartsWith("@") And TN2.Text.StartsWith("@") Then Return 0
        If TN1.Text.StartsWith("@") Then Return 1
        If TN1.Text.StartsWith("%") And TN2.Text.StartsWith("%") Then Return 0
        If TN1.Text.StartsWith("%") And TN2.Text.StartsWith("@") Then Return -1
        If TN1.Text.StartsWith("%") Then Return 1
        If TN1.Text.StartsWith("+") And TN2.Text.StartsWith("+") Then Return 0
        If TN1.Text.StartsWith("+") And TN2.Text.StartsWith("@") Then Return -1
        If TN1.Text.StartsWith("+") And TN2.Text.StartsWith("%") Then Return -1
        If TN1.Text.StartsWith("+") Then Return 1
        Return [String].Compare(TN2.Text, TN1.Text)
    End Function
End Class