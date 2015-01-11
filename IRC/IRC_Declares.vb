' DZFS.net 2004-2005
' DChat - IRC plugin
' Using DCIRC
'----------------------
Imports UNI_Plugin.UNI_DChat
Imports UNI_Plugin.UNI_DChat.DCB_Universal
Imports UNI_Plugin.UNI_DChat.DCB_V1

Module IRC_Declares


    Friend IRC_CONS_CHLID As String
    Friend IRC_CONS_TalkInChl As String
    'Friend Const IRC_CONS_NAME As String = "DCIRC"
    'Friend Const IRC_CONS_VER As String = "1.0.0"

    Friend ChlMainIRC As DCB_Channels2.DCB_Channel
    Friend WithEvents IRC_Socket As DCB_Base.DCB_NetSocket
    ' Friend IRC_Socket As UNI_Plugin.UNI_Extended.UNI_iETCPS

    Friend IRC_FirstNickInit As Boolean = True

    'Friend IRC_NET_Buffer As String
    ' Friend IRC_NET_STOP As Boolean = False

    Friend IRC_INF As DCB_Universal.DCB_UNI_PluginInfo

    ' Связь с базой
    Friend CHLCtl As DCB_Channels2.DCB_iChannelsControl
    Friend USRCtl As DCB_Channels2.DCB_iUsersControl
    Friend DCCtl As DCB_Base.DCB_GUI_Control
    Friend DCSE As DCB_Base.DCB_DCSE

    Friend IRC_Interface As New IRCInterface

    Friend IRC_CHLFavoritesCollection As Collection
    Friend IRC_FriendsCollection As New Collection
    Friend IRC_Servers As New Collection
    Friend IRC_ColorSchemes As New Collection
    Friend IRC_UserModes As New Collection

    Friend IRC_PerformFiles As New Collection

    Friend IRC_CurServerISUPPORT As New Hashtable

    Friend DC2Conv As IRCTextManager

    '  Friend IRC_RegEvents As New Collection

    Friend Structure IRC_SSettings
        Public UserInfo As DCB_Universal.DCB_LocalUserInfo
        Dim Network As IRC_NetSettings
        Dim IRCStrings As IRC_Str
        Dim IRCColors As IRC_Colors_type
        Dim IRCFont As String
        Dim IRCFontSize As Integer
        Dim IRCMode As IRC_UserMode
        Dim Debug As IRC_Debug
        Dim FirstStart As Boolean
        Dim CurrentMode As IRC_UserMode
        Dim SND_CTCPPath As String
        Dim SND_EventPath As String
        Dim SND_UseCTCP As Boolean
        Dim SND_UseSNDS As Boolean
        Dim SND_Paths As IRC_SNDMGR_SOUNDS
    End Structure

    Friend Structure IRC_Colors_type
        Dim ColorScheme As String
        Dim ActionColor As Short
        Dim CTCPColor As Short
        Dim HighlightColor As Short
        Dim InfoColor As Short
        Dim Info2Color As Short
        Dim InviteColor As Short
        Dim JoinColor As Short
        Dim KickColor As Short
        Dim ModeColor As Short
        Dim NickColor As Short
        Dim NormalColor As Short
        Dim NoticeColor As Short
        Dim NotifyColor As Short
        Dim OtherColor As Short
        Dim OwnColor As Short
        Dim PartColor As Short
        Dim Quitcolor As Short
        Dim TopicColor As Short
        Dim WallopsColor As Short
        Dim WhoisColor As Short
    End Structure
    Friend Structure LocalUser
        Dim CurrentNick As String
        Dim Nick As String
        Dim AltNick As String
        Dim RealName As String
        Dim EMail As String
    End Structure
    Friend Structure IRC_Str
        Dim IRC_QuitMsgSysExit As String
        Dim IRC_QuitMsgPrgClose As String
        Dim fingerReply As String
    End Structure
    Friend Structure IRC_Debug
        Dim IRC_DBG_SHOWSERVRAW As Boolean
        Dim IRC_DBG_SHOWSENDRAW As Boolean
        Dim IRC_DBG_MODULES As Boolean

    End Structure
    Friend Structure IRC_NetSettings
        ' Настройки сети для IRC
        Dim Server As String  ' адрес сервера
        Dim Description As String ' Описание сервера
        Dim Port As String   ' Порт на сервере
        Dim Group As String   ' Группа
        Dim Password As String ' Пароль для подключения
        Dim AutoConnect As Boolean ' Автоподключение
        Dim Reconnect As Boolean
        Dim ReconWait As Integer
    End Structure
    Friend Class IRC_CHLFavorite
        Public CHLName As String
        Public Network As String
        Public UseSND As Boolean
        Public UseAlarm As Boolean
        Public AutoJoin As Boolean
        Public Password As String
        Sub New(ByVal ichlname As String, Optional ByVal iNetwork As String = "[ALL]", Optional ByVal iAutoJoin As Boolean = False, Optional ByVal iUseSnd As Boolean = False, Optional ByVal iUseAlarm As Boolean = False, Optional ByVal iPassword As String = "")
            CHLName = ichlname
            Network = iNetwork
            UseSND = iUseSnd
            UseAlarm = iUseAlarm
            AutoJoin = iAutoJoin
            Password = iPassword
        End Sub
    End Class
    Friend Class IRC_Friend
        Public Nick As String
        Public AltNicks As String
        Public Notify As Boolean
        Public ExecCMD As String
        Public UpdStat As Byte
        Public Status As FriendStates
        Public LongInfo As String

        Sub New(ByVal iNick As String, Optional ByVal iAltNicks As String = "", Optional ByVal iNotify As Boolean = False, Optional ByVal iExecCMD As String = "")
            Nick = iNick
            AltNicks = iAltNicks
            Notify = iNotify
            ExecCMD = iExecCMD
        End Sub
        Public Enum FriendStates
            Offline = 2
            Active = 0
            Away = 1
        End Enum

    End Class
    Public Structure IRC_UserMode
        Public Autoset As Boolean ' Если true то режим устанавливается при запуске программы
        Public GPARAMS As String ' [snd] [qpop] [apop]
        Public ModeName As String ' Название режима
        Public ModeID As String ' Идентификатор режима
        Public PrivACT As String ' Действие при открытии привата
        Public Comment As String ' Комментарий режима
        Public HaltStatus As Boolean ' Нужен для управление Autoset
        Public AltNick As String ' Ник устанавливающийся в случае занятости основного ника (нужен для Active mode)
    End Structure
   
    Public Structure IRC_Event
        Public EvName As String
        Public EvPrefix As String
        Public EvCHLSndCtl As String
        Public EvCMD As String
        Public Evppcmd As String
    End Structure
    Friend Enum IRC_SNDMGR_Events
        IRC_SND_JOIN = 1
        IRC_SND_PART = 2
        IRC_SND_QUIT = 3
        IRC_SND_MODE = 4
        IRC_SND_TOPIC = 5
        IRC_SND_NICK = 6
        IRC_SND_MODE_BAN = 7
        IRC_SND_KICK = 8
        IRC_SND_QMSG = 9
    End Enum
    Friend Structure IRC_SNDMGR_SOUNDS
        Dim IRC_SND_JOIN As String
        Dim IRC_SND_KICK As String
        Dim IRC_SND_MODE As String
        Dim IRC_SND_MODE_BAN As String
        Dim IRC_SND_NICK As String
        Dim IRC_SND_PART As String
        Dim IRC_SND_QMSG As String
        Dim IRC_SND_QUIT As String
        Dim IRC_SND_TOPIC As String
    End Structure
End Module
