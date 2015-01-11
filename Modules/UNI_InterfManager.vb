' DZFS.NET 2003
' DChat project
' InterfaceManager Module
'------------------------------------------------------------------------------------
' Programmed by Garikk
' User Interface 
'------------------------------------------------------------------------------------
Imports UNI_Plugin.UNI_DChat

Module InterfaceManager
    Friend Sub _lstviewresize(ByVal sender As Object, ByVal e As EventArgs)
        CType(sender, ListView).Columns(0).Width = CType(sender, ListView).Width - 10
    End Sub
    Public Sub _rtfl_sortctl(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
        Static R As Boolean
        R = Not R
        Dim LV As ListView = CType(sender, ListView)
        LV.Sorting = SortOrder.None
        LV.ListViewItemSorter = New ListViewItemComparer(e.Column, R)
        LV.Sort()
    End Sub

    Class ListViewItemComparer
        Implements IComparer

        Private col As Integer
        Private REV As Boolean = False

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(ByVal column As Integer, ByVal re As Boolean)
            col = column
            REV = re
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            If col = 1 Then
                If REV = True Then
                    If CInt(CType(y, ListViewItem).SubItems(col).Text) > CInt(CType(x, ListViewItem).SubItems(col).Text) Then
                        Return 1
                    ElseIf CInt(CType(y, ListViewItem).SubItems(col).Text) < CInt(CType(x, ListViewItem).SubItems(col).Text) Then
                        Return 0
                    Else
                        Return -1
                    End If
                Else
                    If CInt(CType(x, ListViewItem).SubItems(col).Text) > CInt(CType(y, ListViewItem).SubItems(col).Text) Then
                        Return 1
                    ElseIf CInt(CType(x, ListViewItem).SubItems(col).Text) < CInt(CType(y, ListViewItem).SubItems(col).Text) Then
                        Return 0
                    Else
                        Return -1
                    End If
                End If
            Else
                If REV = True Then
                    Return [String].Compare(CType(y, ListViewItem).SubItems(col).Text, CType(x, ListViewItem).SubItems(col).Text)
                Else
                    Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
                End If
            End If
        End Function
    End Class

    Public Sub _rtfl_selectnode(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim RTB As RichTextBox = DCB_DCTL.DCB_GetTopicBox '.Rtf
            RTB.Rtf = DC2Conv.dc2toRTF(CType(sender.SelectedItems.Item(0), UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem).DC2Text, RTB.Font.Name, RTB.Font.Size)
        Catch
        End Try
    End Sub
    Public Sub _LinkClick(ByVal sender As Object, ByVal e As LinkClickedEventArgs)
        Dim a As New Process
        a.Start(e.LinkText)
    End Sub

    Public Sub SendTextLine_UICall(ByVal Msg As String)
        Dim Channel As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = DCB_DCTL.DCB_GetCurrentChannelDCC()
        Dim Pref As String

        Msg = DC2Conv.RTFToDC2(Msg)

        If Not Msg.StartsWith("/") Then Pref = " $TALK$ " Else Pref = " "
        If Channel.CHLTYPE = UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel_Types.CHL_MainConsole Then
            DCSE.DCB_DCSE_OPER_Executer(Channel.PID, Msg)
        Else
            DCSE.DCB_DCSE_OPER_Executer(Channel.PID, Channel.PID & Pref & Msg)
        End If

    End Sub
    Friend Sub ChangeTopic(ByVal Topic As String)
        Dim Pref As String

        Topic = DC2Conv.RTFToDC2(Topic)
        If Not Topic.StartsWith("/") Then Pref = " $CHTOPIC$ " Else Pref = " "
        DCSE.DCB_DCSE_OPER_Executer(DCB_DCTL.DCB_GetCurrentPluginID, DCB_DCTL.DCB_GetCurrentPluginID & Pref & Topic)
    End Sub
    Friend Sub ChangeNick(ByVal Nick As String)
        '   Dim Channel As String = DCB_DCTL.DCB_GetCurrentChannel
        Dim Pref As String

        If Not Nick.StartsWith("/") Then Pref = " $CHNICK$ " Else Pref = " "
        DCSE.DCB_DCSE_OPER_Executer(DCB_DCTL.DCB_GetCurrentPluginID, DCB_DCTL.DCB_GetCurrentPluginID & Pref & Nick)
    End Sub
    Public Sub _vchanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Временно для отображения числа юзеров
        If sender.tag = "/base" Then Exit Sub
        PMGR.DCB_PMGR_CALLPLUGINSCRIPTS(sender.tag & " DCB_LSTVISCHANGED")
    End Sub
#Region " Menu Manager "

    Friend Sub CreateMainMenu()
        Dim MainMenu As Windows.Forms.MainMenu = DCB_DCTL.DCB_GetMainForm.Menu()
        Dim newMenu As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem
        Dim Tmp As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem
        Dim id As Integer
        newMenu = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("DC", "/#")
        newMenu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Режим отладки", "/base rundebug"))
        newMenu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        newMenu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Настройки", "/base showoptions"))
        newMenu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        newMenu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Выход", "/base exit p"))

        MainMenu.MenuItems.Add(newMenu)

        For Each Tmp In newMenu.MenuItems
            AddHandler Tmp.Click, AddressOf DCB_Int_AllMenuEvents
        Next


        MainMenu.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Plugin menu", "/#"))

        Dim newMenu2 As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem

        newMenu2 = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Справка", "/#")
        newMenu2.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Справка", "/base showhelp"))
        newMenu2.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("-", "/#"))
        newMenu2.MenuItems.Add(New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("О программе", "/base showabout"))

        MainMenu.MenuItems.Add(newMenu2)

        For Each Tmp In newMenu2.MenuItems
            AddHandler Tmp.Click, AddressOf DCB_Int_AllMenuEvents
        Next


    End Sub
    Friend Sub ChangeCHLMenu(ByVal newmenu As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem)
        Dim MainMenu As Windows.Forms.MainMenu = DCB_DCTL.DCB_GetMainForm.Menu()
        If newmenu Is Nothing Then newmenu = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem("Plugin menu", "/#")
        MainMenu.MenuItems.RemoveAt(1) '
        Try
            MainMenu.MenuItems.Add(1, newmenu)
        Catch a As Exception
            'Stop
        End Try

    End Sub
#End Region

#Region "--------------------- EVENTS CTL----------------------"
    Public Sub DCB_Int_AllMenuEvents(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            DCB_DCSE_OPER_Executer("", sender.cmd)
        Catch ex As Exception
            DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_ERROR, "<DCB_Int_AllMenuEvents><DCSECall>: " & ex.ToString, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)

        End Try
    End Sub
    Public Sub DCB_Int_CtlsTagExec(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            DCB_DCSE_OPER_Executer("", CType(CType(sender, ListView).SelectedItems(0), UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem).CMD)
        Catch : End Try
    End Sub


#End Region
    Public Sub dcb_dcgui_addsettingspanel(ByVal CMD As String)
        Dim NewPanel As Panel
        NewPanel = DCSE.DCB_DCSE_OPER_Executer("", CMD)
        If NewPanel Is Nothing Then Exit Sub
        NewPanel.Dock = DockStyle.Fill
        NewPanel.Visible = False
        frmSettings.DefInstance.fraSettings.Controls.Add(NewPanel)
    End Sub
    Friend Sub DCBGUI_SettingsWindow_CreateTree(ByVal TreeString() As String)
        Dim Tmp As String

        Dim TreeNode As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_TreeNode

        Dim NewTree As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_TreeNode
        Dim NewTree_compl As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_TreeNode
        Dim MSplit() As String
        Dim LevParent(4) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_TreeNode
        Static ClearFlag As Boolean
        'If ClearFlag = True Then Try : DCB_Int_ClearMenu(BaseMenu) : Catch : End Try
        LevParent(0) = NewTree_compl

        For Each Tmp In TreeString
            Tmp = Tmp.Trim.TrimEnd

            If Tmp.StartsWith("....") Then
                NewTree = DCB_Int_AddTreeNode(LevParent(3), Tmp)
                LevParent(4) = NewTree
            ElseIf Tmp.StartsWith("...") Then
                NewTree = DCB_Int_AddTreeNode(LevParent(2), Tmp)
                LevParent(3) = NewTree
            ElseIf Tmp.StartsWith("..") Then
                NewTree = DCB_Int_AddTreeNode(LevParent(1), Tmp)
                LevParent(2) = NewTree
            ElseIf Tmp.StartsWith(".") Then
                NewTree = DCB_Int_AddTreeNode(LevParent(0), Tmp)
                LevParent(1) = NewTree
                'ElseIf Tmp.StartsWith("/nextmenu") Then
                '    CreateMenu.MenuItems.Add(NewTree_compl)
                '    NewTree_compl = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_MenuItem
                '    LevParent(0) = NewTree_compl
                'ElseIf Tmp.StartsWith("/loadpluginmenu") Then
                '    ClearFlag = False
                '    DCSE.DCB_ExecScriptBlock(DCB_DCTL.DCB_GetCurrentChannelDCC.CHLMainMenuScript)
                '    ClearFlag = True
            ElseIf Tmp.StartsWith("/#") Then
                ' ничё, комментарий это
            Else ' Нулевой уровень
                MSplit = Tmp.Split(":")
                NewTree_compl.Text = MSplit(0)
                NewTree_compl.Tag = MSplit(1)
            End If
        Next
        NewTree_compl.Expand()
        frmSettings.DefInstance.trwSettings.Nodes.Add(NewTree_compl)
    End Sub
    Private Function DCB_Int_AddTreeNode(ByVal AddTo As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_TreeNode, ByVal CMD As String)
        Dim NewTree As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_TreeNode
        Dim MSplit() As String

        NewTree = New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_TreeNode
        MSplit = CMD.Split(":")
        NewTree.Text = MSplit(0).Trim(".")

        NewTree.Tag = MSplit(1)
        AddTo.Nodes.Add(NewTree)
        Return NewTree
    End Function
    Friend Sub _lstafterselect(ByVal sender As Object, ByVal e As EventArgs)
        '  sender.tag = e.Node.Text
        If sender.selecteditems.count = 0 Then Exit Sub
        sender.tag = sender.selecteditems(0).text
    End Sub
End Module

Public Class DCControl
    Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control
    Public Function DCB_GetInputTextBox() As RichTextBox Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetInputTextBox
        Return frmChat.DefInstance.txtInput
    End Function
    Public Function DCB_GetToolBarPanel() As Panel Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetToolBarPanel
        Return frmChat.DefInstance.pnlToolBar
    End Function

    Public Function DCB_GetMainForm() As Form Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetMainForm
        Return frmChat.DefInstance
    End Function
    Public Function DCB_GetTabControl() As TabControl Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetTabControl
        Return frmChat.DefInstance.tbsChat
    End Function
    Public Function DCB_GetLeftPanel() As Panel Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetListsPanel
        Return frmChat.DefInstance.pnlLTOP
    End Function
    Public Function DCB_GetTray() As Windows.Forms.NotifyIcon Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetTray
        Return frmChat.DefInstance.strDChat
    End Function
    Public Function DCB_GetHelpProvider() As HelpProvider Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetHelpProvider
        Return frmChat.DefInstance.hlpDChat
    End Function

    Public Function DCB_GetCurrentChannel() As String Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetCurrentChannelCHLID
        Return frmChat.DefInstance.tbsChat.SelectedTab.Tag
    End Function
    Public Function DCB_GetNickBox() As RichTextBox Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetNickTextBox
        Return frmChat.DefInstance.txtName
    End Function
    Public Function DCB_GetTopicBox() As RichTextBox Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetTopicBox
        Return frmChat.DefInstance.txtTopic
    End Function

    Public Sub DCB_UpdateTopicBox() Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_UpdateTopicBox
        Dim RTFTop As String = DCB_DCTL.DCB_GetCurrentChannelDCC.CHLTOPIC
        If RTFTop <> "" And (Not DC2Conv Is Nothing) Then DCB_GetTopicBox.Rtf = DC2Conv.dc2toRTF(RTFTop, DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)
    End Sub
    Public Sub DCB_UpdateInterface() Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_UpdateInterf
        Static FR As Boolean = False

        If FR = True And DCB_BaseSettings.Debugmode = True Then DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_Talk(ConsTalk, CHLMain, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes.MSG_CUSTOM, "<UPDINTERFACE> ", UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors.Red)
        FR = True
        DCB_UpdateTopicBox()
        frmChat.DefInstance.DCB_GUICTL_UpdInterf()
    End Sub
    Public Function DCB_GetCurrentPluginID() As String Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetCurrentPluginID
        Return DCB_ActivePluginID
    End Function
    Public Function DCB_GetCurrentChannelDCC() As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_GUI_Control.DCB_GetCurrentChannelDCC
        Try
            Return DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_DChannel(Chat.DCB_DCTL.DCB_GetTabControl.SelectedTab.Tag)
        Catch
            Return CHLMain
        End Try
    End Function


End Class


