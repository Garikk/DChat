' DZFS.NET 2003
' DChat project
' Channel Control Module
' DChat Channels DataBase  (CHLDB)
'------------------------------------------------------------------------------------
' Programmed by Garikk
' Channel control procedures and CHLDB Manager
'------------------------------------------------------------------------------------

Imports System.Windows.Forms
Imports UNI_Plugin.UNI_DChat
Imports UNI_Plugin.UNI_DChat.DCB_V1

Friend Class DCB_CHL_Control
    Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl
    Dim CurMouseButton As MouseButtons

    Public Function DCB_CHLCTL_OPER_AddNewChannel(ByVal NewChlDat As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_NewChannelDataPack) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_AddNewChannel
        ' Создание записи в базе и интерфейсик...
        NewChlDat.CHLName = NewChlDat.CHLName.TrimEnd(Chr(13))
        NewChlDat.CHLID = NewChlDat.CHLID.TrimEnd(Chr(13)).ToLower  '& NewChlDat.CHLName
        Dim NewCHL As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel(NewChlDat.CHLName, NewChlDat.CHLID, NewChlDat.CHLType, NewChlDat.ParentPluginInfo.INF_CMDEXEC)

        Select Case NewChlDat.CHLType
            Case DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFListChannel
                NewCHL = DCB_CHLCTL_iOPER_RTFL(NewCHL, NewChlDat.iIconBase, NewChlDat.CHLIcoIndex, "")
                AddHandler NewCHL.rtflList.Click, AddressOf _rtfl_selectnode
                AddHandler NewCHL.rtflList.ItemActivate, AddressOf DCB_Int_CtlsTagExec
                AddHandler NewCHL.rtflList.ColumnClick, AddressOf _rtfl_sortctl
                AddHandler NewCHL.lstUsers.Resize, AddressOf _lstviewresize

            Case Else
                NewCHL = DCB_CHLCTL_iOPER_CHLInit_RTFTEXT(NewCHL, NewChlDat.iIconBase, NewChlDat.CHLIcoIndex, "")
                ' AddHandler NewCHL.lstUsers.AfterSelect, AddressOf _lstafterselect
                AddHandler NewCHL.lstUsers.SelectedIndexChanged, AddressOf _lstafterselect
                AddHandler NewCHL.lstUsers.Resize, AddressOf _lstviewresize
                '   AddHandler NewCHL.lstUsers.MouseMove, AddressOf _lstviewmmove
        End Select

        'отображение на форме
        NewChlDat.UlistBase.Controls.Add(NewCHL.lstUsers)
        '  NewCHL.lstUsers.BringToFront()
        ' Добавляем на TabPage учитывая сортировку #& ---
        If NewCHL.tbsCHL.Text.StartsWith("#") Or NewCHL.tbsCHL.Text.StartsWith("&") Or NewCHL.CHLTYPE = DCB_Channels2.DCB_Channel_Types.CHL_MainConsole Or NewCHL.CHLTYPE = DCB_Channels2.DCB_Channel_Types.CHL_PluginConsole Then
            NewChlDat.tbsTab.TabPages.Add(NewCHL.tbsCHL)
            Dim TP As Integer
            Dim buf As TabPage
            For TP = NewChlDat.tbsTab.TabPages.Count - 1 To 0 Step -1
                If TP < NewChlDat.tbsTab.TabPages.Count - 1 And NewChlDat.tbsTab.TabPages.Count > 1 Then
                    If NewChlDat.tbsTab.TabPages(TP).Text.StartsWith("#") Or DCB_CHLCTL_OPER_DChannel(NewChlDat.tbsTab.TabPages(TP).Tag).CHLTYPE = DCB_Channels2.DCB_Channel_Types.CHL_MainConsole Or DCB_CHLCTL_OPER_DChannel(NewChlDat.tbsTab.TabPages(TP).Tag).CHLTYPE = DCB_Channels2.DCB_Channel_Types.CHL_PluginConsole Then Exit For
                    buf = NewChlDat.tbsTab.TabPages(TP)
                    NewChlDat.tbsTab.TabPages(TP) = NewChlDat.tbsTab.TabPages(TP + 1)
                    NewChlDat.tbsTab.TabPages(TP + 1) = buf
                End If
            Next
        Else
            NewChlDat.tbsTab.TabPages.Add(NewCHL.tbsCHL)
        End If

        ' обавляем 
        DCB_BASE_CHLDB.AddCHL(NewCHL)
        NewChlDat.tbsTab.SelectedTab = NewCHL.tbsCHL
        DCB_DCTL.DCB_UpdateInterface()
        Return NewCHL
    End Function

    Private Function DCB_CHLCTL_iOPER_CHLInit_RTFTEXT(ByRef newcell As DCB_Channels2.DCB_Channel, ByVal IconBase As ImageList, ByVal IconIndex As Integer, ByVal ChlTopic As String) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel
        Dim NewTabPage As New TabPage
        Dim NewTextBox As New RichTextBox
        'Dim NewTreeView As New TreeView
        Dim NewTreeView As New ListView

        'Подготовка интерфейса

        NewTabPage.Tag = newcell.CHLID  'NewCHL.CHLIDf
        NewTextBox.Text = ""
        NewTextBox.Dock = DockStyle.Fill
        NewTextBox.ReadOnly = True
        NewTextBox.DetectUrls = True
        NewTextBox.Font = New Font(DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)
        NewTextBox.HideSelection = False
        NewTextBox.ShowSelectionMargin = True
        NewTextBox.BackColor = DCB_ColorSettings.BackChatColor
        NewTextBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical
        AddHandler NewTextBox.LinkClicked, AddressOf _LinkClick


        '        DCB_DCTL.DCB_GetTabControl.ImageList.Images.Add(IconBase.Images(IconIndex))
        NewTabPage.Text = newcell.CHLName
        NewTabPage.ImageIndex = IconIndex
        NewTabPage.Controls.Add(NewTextBox)

        'Список узеров
        newcell.lstUsers = NewTreeView
        newcell.lstUsers.BackColor = DCB_ColorSettings.BackChatColor
        newcell.lstUsers.Visible = False


        newcell.lstUsers.Dock = DockStyle.Fill
        newcell.lstUsers.SmallImageList = IconBase '= DCB_DCTL.DCB_GetIListUser

        newcell.lstUsers.HideSelection = False
        newcell.lstUsers.View = View.Details
        newcell.lstUsers.HeaderStyle = ColumnHeaderStyle.None
        newcell.lstUsers.Columns.Add("def", 56, HorizontalAlignment.Left)
        newcell.lstUsers.Tag = newcell.PID
        newcell.lstUsers.Font = New Font(DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)

        'Общие параметры

        newcell.CHLTOPIC = ChlTopic
        newcell.tbsCHL = NewTabPage
        newcell.txtCHL = NewTextBox

        newcell.CHLParams.USEAlarm = False
        newcell.CHLParams.USESound = False

        Return newcell
    End Function
    Private Function DCB_CHLCTL_iOPER_RTFL(ByRef newcell As DCB_Channels2.DCB_Channel, ByVal IconBase As ImageList, ByVal IconIndex As Integer, ByVal ChlTopic As String) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel


        Dim NewTabPage As New TabPage
        ' Dim NewRTFL As New DCB_Controls.RTFList(newcell.CHLID)
        Dim NewRTFL As New ListView
        Dim NewTreeView As New ListView

        'Подготовка интерфейса


        NewTabPage.Tag = newcell.CHLID  'NewCHL.CHLIDf
        NewRTFL.Text = ""
        NewRTFL.Dock = DockStyle.Fill
        NewRTFL.View = View.Details
        NewRTFL.BackColor = DCB_ColorSettings.BackChatColor


        NewRTFL.GridLines = True
        NewRTFL.FullRowSelect = True

        Dim CH As New ColumnHeader
        CH.Text = "Название канала"
        CH.Width = 150
        NewRTFL.Columns.Add(CH)
        CH = New ColumnHeader
        CH.Text = "Кол-во пользователей"
        CH.Width = 50
        NewRTFL.Columns.Add(CH)
        CH = New ColumnHeader
        CH.Text = "Тема канала"
        NewRTFL.Columns.Add(CH)
        CH.Width = 350


        NewRTFL.BackColor = DCB_ColorSettings.BackChatColor
        '  NewRTFL.Sorted = True
        'NewRTFL. = View.List
        NewRTFL.Font = New Font(DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)

        'AddHandler NewRTFL.UPDList, AddressOf RTFLUPD
        NewTabPage.Text = newcell.CHLName
        NewTabPage.ImageIndex = IconIndex
        NewTabPage.Controls.Add(NewRTFL)

        'Список узеров
        newcell.lstUsers = NewTreeView
        newcell.lstUsers.Visible = False
        'newcell.lstUsers.HotTrackin = True
        ' newcell.lstUsers.ShowPlusMinus = False
        ' newcell.lstUsers.ShowLines = False
        ' newcell.lstUsers.ShowRootLines = False
        newcell.lstUsers.Dock = DockStyle.Fill
        newcell.lstUsers.SmallImageList = IconBase
        newcell.lstUsers.HideSelection = False
        newcell.lstUsers.View = View.Details
        newcell.lstUsers.HeaderStyle = ColumnHeaderStyle.None
        newcell.lstUsers.Columns.Add("def", 56, HorizontalAlignment.Left)
        ' newcell.lstUsers.BringToFront()
        '  newcell.lstUsers.Sorted = True

        'Общие параметры

        newcell.CHLTOPIC = ChlTopic
        newcell.tbsCHL = NewTabPage
        newcell.rtflList = NewRTFL

        newcell.CHLParams.USEAlarm = False
        newcell.CHLParams.USESound = False

        newcell.CHLTOPIC = "Список каналов"
        Return newcell
    End Function

    Public Sub DCB_CHLCTL_OPER_DelCHL(ByVal ChlID As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_DelCHL
        'ChlID = ChlID.ToLower
        Dim LeaveCHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel = DCB_CHLCTL_OPER_DChannel(ChlID)
        Dim Usr As DCB_Channels2.DCB_User
        ' Удаляем у всех пользователей записи о канале
        For Each Usr In DCB_BASE_USRDB.UDB_Main_Collection(LeaveCHL.PID)
            Usr.DelNodeFromTreeview(ChlID)
        Next
        LeaveCHL.tbsCHL.Dispose()
        If LeaveCHL.CHLTYPE = DCB_Channels2.DCB_Channel_Types.CHL_PluginRTFListChannel Then
            LeaveCHL.rtflList.Dispose()
        Else
            LeaveCHL.txtCHL.Dispose()
        End If

        LeaveCHL.lstUsers.Dispose()
        DCB_BASE_CHLDB.RemoveCHL_CHLID(ChlID)
    End Sub

    Public Function DCB_CHLCTL_OPER_DChannel(ByVal ChlID As String) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_DChannel
        Return DCB_BASE_CHLDB.GetCHL_CHLID(ChlID.ToLower)
    End Function

    Public Function DCB_CHLCTL_OPER_DChannelSTR(ByVal ChlNAM As String, ByVal PID As String) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_DChannelSTR
        Return DCB_BASE_CHLDB.GetCHL_NAME(ChlNAM, PID)
    End Function

    Public Overloads Sub DCB_CHLCTL_OPER_Talk(ByVal UID As String, ByVal Channel As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel, ByVal MsgType As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes, ByVal Msg As String, ByVal CustomColor As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors, Optional ByVal IcoUPD As Byte = 1) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_Talk_UUID_ChlDCC
        If Msg = "" Then Exit Sub
        If Msg.EndsWith(Chr(13)) = False Then Msg += Chr(13)
        DCB_ShowMessage(UID, MsgType, Msg, Channel, , CustomColor, IcoUPD)
    End Sub
    Public Overloads Sub DCB_CHLCTL_OPER_Talk(ByVal PID As String, ByVal User As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User, ByVal Channel As String, ByVal MsgType As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes, ByVal Msg As String, ByVal CustomColor As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors, Optional ByVal IcoUPD As Byte = 1) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_Talk_UITEM_CHLNAM
        DCB_CHLCTL_OPER_Talk(User.UserID, DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_DChannelSTR(Channel, PID), MsgType, Msg, CustomColor, IcoUPD)
    End Sub
    Public Overloads Sub DCB_CHLCTL_OPER_Talk(ByVal UID As String, ByVal ChlID As String, ByVal MsgType As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes, ByVal Msg As String, ByVal CustomColor As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors, Optional ByVal IcoUPD As Byte = 1) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_Talk_UUID_CHLID
        DCB_CHLCTL_OPER_Talk(UID, DCB_BASE_CHL_CTL.DCB_CHLCTL_OPER_DChannel(ChlID), MsgType, Msg, CustomColor, IcoUPD)
    End Sub
    Public Overloads Sub DCB_CHLCTL_OPER_Talk(ByVal User As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User, ByVal ChlDCC As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel, ByVal MsgType As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes, ByVal Msg As String, ByVal CustomColor As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors, Optional ByVal IcoUPD As Byte = 1) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_Talk_UITEM_CHLDCC
        If Msg = "" Then Exit Sub
        If Msg.EndsWith(Chr(13)) = False Then Msg += Chr(13)
        DCB_ShowMessage(User, MsgType, Msg, ChlDCC, CustomColor, IcoUPD)
    End Sub
    Public Sub DCB_CHLCTL_OPER_TalkInALL(ByVal UID As String, ByVal Pluginid As String, ByVal MsgType As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes, ByVal Msg As String, ByVal CustomColor As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors, Optional ByVal IcoUPD As Byte = 1) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_Talk_UID_ALL_PLUGIN_USER_CHLs
        Dim CHL As DCB_Channels2.DCB_Channel
        Dim USR As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User = DCB_BASE_UDB_CTL.DCB_GetUser_UID(UID)
        For Each CHL In DCB_BASE_CHLDB.GetArrayFromPID(Pluginid)
            If DCB_CHLCTL_OPER_ExistCHL(UID, CHL.CHLID) = True Then
                DCB_CHLCTL_OPER_Talk(USR, CHL, MsgType, Msg, CustomColor, IcoUPD)
            End If
        Next
    End Sub
    Public Sub DCB_CHLCTL_OPER_TalkInALL2(ByVal UID As String, ByVal Pluginid As String, ByVal MsgType As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_MessageTypes, ByVal Msg As String, ByVal CustomColor As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_IRCColors, Optional ByVal IcoUPD As Byte = 1) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_Talk_UID_ALL_PLUGIN_CHLs
        Dim CHL As DCB_Channels2.DCB_Channel
        For Each CHL In DCB_BASE_CHLDB.GetArrayFromPID(Pluginid)
            DCB_CHLCTL_OPER_Talk(UID, CHL, MsgType, Msg, CustomColor, IcoUPD)
        Next
    End Sub

    Public Function DCB_CHLCTL_OPER_ExistCHL(ByVal UID As String, ByVal CHLID As String) As Boolean Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.IsUserExist
        Dim Usr As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User = DCB_BASE_USRDB.Item_UID(UID)
        Dim Node As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem_TN
        If Usr Is Nothing Then Return False
        Try
            For Each Node In Usr.UserTreeViewNodes
                If Node.Tag = CHLID Then Return True
            Next
        Catch
            Return False
        End Try
    End Function
    Public Sub DCB_CHLCTL_OPER_JoinUserToChl(ByVal UID As String, ByVal CHLID As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_JoinUserToChl
        Dim CHL As DCB_Channels2.DCB_Channel = DCB_BASE_CHLDB.GetCHL_CHLID(CHLID)
        Dim USR As DCB_Channels2.DCB_User = DCB_BASE_USRDB.Item_UID(UID)
        USR.AddNodeToTreeview(CHL, CHL.lstUsers)
    End Sub
    Public Sub DCB_CHLCTL_OPER_LeaveUserFromCHL(ByVal UID As String, ByVal CHLID As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_LeaveUserFromCHL
        Dim USR As DCB_Channels2.DCB_User = DCB_BASE_USRDB.Item_UID(UID)
        USR.DelNodeFromTreeview(CHLID)
    End Sub
    Public Function DCB_CHLCTL_OPER_GetPluginCHLIDs(ByVal PID As String) As String Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_GetPluginCHLIDs
        Dim T As DCB_Channels2.DCB_Channel
        Dim ret As String
        For Each T In DCB_BASE_CHLDB.GetArrayFromPID(PID)
            ret += T.CHLID & ":"
        Next
        Return ret.Substring(0, ret.Length - 1)
    End Function
    Public Function DCB_CHLCTL_OPER_GetPluginCHLS(ByVal PID As String) As Collection Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iChannelsControl.DCB_GetPluginCHLS

        Return (DCB_BASE_CHLDB.GetArrayFromPID(PID))

    End Function
End Class