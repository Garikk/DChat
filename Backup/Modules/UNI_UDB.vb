' DZFS.NET 2004
' DChat Project
' DChat Users Database
'------------------------------------------------------------------------------------
' Programmed by Garikk
' Users Database Control
'------------------------------------------------------------------------------------

Option Explicit On 
Imports UNI_Plugin.UNI_DChat
Class DCB_UDB_Control
    Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl

    Public Sub DCB_ChangeUserIcon(ByVal UID As String, ByVal IconIndex As Integer, ByVal OnCHL As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl.DCB_ChangeUserIcon
        Dim USR As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User = DCB_GetUser_UID(UID)
        USR.GetNode(OnCHL.CHLID).ImageIndex = IconIndex
        'USR.GetNode(OnCHL.CHLID).SelectedImageIndex = IconIndex
    End Sub
    Public Sub DCB_ChangeUserName(ByVal PluginID As String, ByVal UID As String, ByVal NewName As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl.DCB_ChangeUserName
        Dim USR As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User = DCB_GetUser_UID(UID)
        USR.UserID = PluginID & NewName
        USR.UserNick = NewName
    End Sub

    Public Function DCB_GetUser_Name(ByVal UserName As String, ByVal PID As String) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl.DCB_GetUser_Name
        Return DCB_BASE_USRDB.Item_Name(UserName, PID)
    End Function
    Public Function DCB_GetUser_UID(ByVal UID As String) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl.DCB_GetUser_UID
        Return DCB_BASE_USRDB.Item_UID(UID)
    End Function


    Public Function DCB_AddNewUser(ByVal UID As String, ByVal UsrName As String, ByVal Tag As Object, ByVal Creater As String) As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl.DCB_AddNewUser
        Dim NewUser As New UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User(UID, UsrName, Tag, Creater)
        DCB_BASE_USRDB.Add(NewUser)
        Return NewUser
    End Function
    Public Sub DCB_RemoveUser(ByVal UID As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl.DCB_RemoveUser

        Try
            Dim usr As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User = DCB_BASE_USRDB.Item_UID(UID)
            Dim tmp As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem_TN
            For Each tmp In usr.UserTreeViewNodes
                tmp.Remove()
            Next
            DCB_BASE_USRDB.Remove(usr._internUID)
        Catch : End Try


    End Sub
    Public Function DCB_ExistCHL(ByVal UID As String, ByVal CHLID As String) As Boolean Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl.IsCHLExsist

        Dim Usr As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User = DCB_BASE_USRDB.Item_UID(UID)
        Dim Node As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_ListViewItem_TN
        If Usr Is Nothing Then Return False
        Try
            If Not Usr.UserTreeViewNodes.Item(CHLID) Is Nothing Then Return True
            'For Each Node In Usr.UserTreeViewNodes
            '    If Node.Tag = CHLID Then Return True
            'Next
        Catch
            Return False
        End Try
        Return False
    End Function
    Public Sub DCB_DelAllPluginUsers(ByVal PID As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_iUsersControl.DCB_RemoveAllPluginUser
        Dim T As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_User
        For Each T In DCB_BASE_USRDB.UDB_Main_Collection(PID)
            DCB_BASE_USRDB.Remove(T.UserID)
        Next
    End Sub
End Class


