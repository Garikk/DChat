' DZFS.NET 2003
' DChat Project
' Declares Module
'------------------------------------------------------------------------------------
' Programmed by Garikk
' Win32 API Declares
' Variables, Types and constant declares
'------------------------------------------------------------------------------------
Imports UNI_Plugin.UNI_DChat
Imports UNI_Plugin.UNI_DChat.DCB_V1

Module Declares
#Region " Объявления WinAPI "
    Public Declare Function GetUserName Lib "advapi32.dll" Alias "GetUserNameA" (ByVal lpBuffer As String, ByRef nSize As Integer) As Integer
    Public Declare Function sndPlaySound Lib "winmm.dll" Alias "sndPlaySoundA" (ByVal lpszSoundName As String, ByVal uFlags As Integer) As Integer
    Public Declare Function RegisterHotKey Lib "user32" Alias "RegisterHotKey" (ByVal hwnd As Integer, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Public Declare Function UnregisterHotKey Lib "user32" Alias "UnregisterHotKey" (ByVal hwnd As Integer, ByVal id As Integer) As Integer

    Public Const WM_SYSCOMMAND = &H112
    Public Const MF_STRING = &H0
    Public Const SC_NEWMENU = 1
    Public Const GWL_WNDPROC = -4
    Public Const WM_QUIT = &H12
    Public Const MOD_ALT = &H1
    Public Const MOD_CONTROL = &H2
    Public Const MOD_SHIFT = &H4
    Public Const VK_RETURN = &HD
    Public Const WM_HOTKEY = &H312
#End Region

#Region "Константы"

    ' Общие константы

    Public Enum SOUNDS
        SND_LOGON = 1
        SND_LOGOFF = 2
        SND_LOGONCHL = 3
        SND_LOGOFFCHL = 4
        SND_STARTPRIV = 5
        SND_CLOSEPRIV = 6
        SND_CHNICK = 7
        SND_CHTOPIC = 8
        SND_MSG = 9
        SND_MSGALL = 10
        SND_MELINE = 11
        SND_EXEC = 12
        SND_BEEP = 13
        SND_CHATLINE = 14
    End Enum

    Public Enum MSG_ARC_ICO
        ICO_IN = 0
        ICO_OUT = 1
    End Enum
    Public Enum ArcTypes
        ARC_MSGIN = 1
        ARC_MSGOUT = 2
        ARC_CHT = 3
        ARC_CHL = 4
        ARC_PRI = 5
    End Enum
    Public Enum MenuRoles
        MNU_MSG = 1
        MNU_PRIVAT = 2
        MNU_RUN = 3
        MNU_BEEP = 4
        MNU_SAY = 5
        MNU_INFO = 6
        MNU_IGNOR = 7
        MNU_MSGALL = 8

    End Enum
    '#Region " Константы сети для DC "

    '    Public Const NET_ONLINE As String = "$$IC" ' OnLine пакет
    '    Public Const NET_CHAT As String = "$$CH" ' Чат строчка
    '    Public Const NET_LOGIN As String = "$$IO" ' Вход/Выход из сети, удостоверяющий пакет
    '    Public Const NET_PRIVAT As String = "$$PR" ' Приват
    '    Public Const NET_MSG As String = "$$MS" ' Сообщение
    '    Public Const NET_CHOPTS As String = "$$OP" ' Смена параметров
    '    Public Const NET_GETTHEME As String = "$$GT" ' Запрос темы
    '    Public Const NET_BEEP As String = "$$BP" ' Сигнал
    '    Public Const NET_INFO As String = "$$IN" ' Запрос информации
    '    Public Const NET_TIMESYNC As String = "$$TS" ' Синхронизация часов
    '    Public Const NET_NEWS As String = "$$NS" ' Новости
    '    Public Const NET_GETDEBUG As String = "$$GD" ' Отладочный сервис
    '    Public Const NET_SRVNETBALANCE As String = "$$SB" ' Контроль загрузки сети

    '    ' Константы сетевых операций
    '    ' Константы для NET_ONLINE
    '    ' -----Роль компьютера

    '    Public Enum NET_ONLINE_ROL_CONS
    '        CHT_ROL_USR = 1
    '        CHT_ROL_SRV = 2
    '        CHT_ROL_ADM = 3
    '        CHT_ROL_PRS = 9
    '    End Enum
    '    ' -----Режимы (H - Не смотрит в чат)
    'Public Enum NET_ONLINE_MOD_CONS
    '    MOD_ACTIVE = 1
    '    MOD_ACTIVEH = 2
    '    MOD_WORK = 3
    '    MOD_WORKH = 4
    '    MOD_AWAY = 5
    '    MOD_AWAYH = 6    ' Ушёл (не смотрит)
    '    MOD_OFF = 7      ' Отключен
    '    MOD_OFFH = 8     ' Отключен (не смотрит)
    '    MOD_GAME = 9     ' Игровой  
    '    MOD_GAMEH = 10   ' Игровой (не смотрит)
    'End Enum
    ' Константы (Смотрит / не смотрит)
    'Public Enum NET_ONLINE_CSTAT_CONS
    '    CSTAT_YES = 0    ' Смотрит
    '    CSTAT_NO = 1     ' Не смотрит
    'End Enum
    '    ' Константы для NET_PRIVAT
    '    Public Enum NET_PRIVAT_CONS
    '        PRI_DO_START = 1 ' Запрос на начало
    '        PRI_DO_START_OK = 2 ' Подтверждение на начало
    '        PRI_DO_EXIT = 3 'Выход из привата
    '        PRI_DO_CHAT = 4 ' Разговор в привате
    '        PRI_DO_NOCON = 5 ' Нет подключения
    '    End Enum
    '    ' Константы для NET_MSG
    '    Public Enum MESSAGES
    '        MSG_TOONE = 0
    '        MSG_TOALL = 1
    '        MSG_TOALLC = 2
    '        MSG_IN = 3
    '        MSG_INALL = 4
    '        MSG_INALLC = 5
    '        MSG_OFFMODANS = 8
    '        MSG_ANSW = 9
    '        MSG_ADMMSG = 10
    '    End Enum
    '    'Константы для NET_CHOPTS
    '    Public Enum NET_OPTS_DO_CONS
    '        OPTS_DO_NAME = 0  ' Смена имени
    '        OPTS_DO_MODE = 1  ' Смена режима
    '        OPTS_DO_TOPIC = 2  ' Смена темы
    '        OPTS_DO_NEWCHL = 3 ' Создание нового канала
    '        OPTS_DO_NEWSUPD = 4 ' Добавление нового объявления
    '    End Enum
    '    ' Константы для NET_THEME
    '    Public Enum NET_TOPIC_DO_CONS
    '        TOPIC_DO_REQ = 0  ' Запрос
    '        TOPIC_DO_ANS = 1 ' Ответ
    '    End Enum
    '    ' Константы для NET_BEEP
    '    Public Enum NET_BEEP_DO_CONS
    '        DO_BEEP_INC = 1  ' Получение 
    '        DO_BEEP_OK = 2   ' Подтверждение
    '    End Enum
    '    ' Константы для NET_INFO
    '    Public Enum NET_INFO_DO_CONS
    '        DO_INF_GET = 0  ' Запрос
    '        DO_INF_GETl = 1  ' Запрос сокращённой информации
    '        DO_INF_ANS = 2  ' Ответ
    '        DO_INF_ANSl = 3  ' Ответ сокращённой информ.
    '        DO_INF_GET_CHL_LIST = 4 ' Запрос списка каналов
    '        DO_INF_ANS_CHL_LIST = 5 ' Ответ списка каналов
    '        DO_INF_GET_NEWS_LIST = 6 ' Запрос на объявления
    '        DO_INF_ANS_NEWS_LIST = 7 ' Ответ объявлений
    '    End Enum
    '    ' Константы для NET_LOGIN
    '    Public Enum NET_LOGIN_DO_CONS
    '        DO_LOG_IN = 0
    '        DO_EXITCHAT = 1
    '        DO_EXITWIN = 2
    '        DO_LOG_IN_CHL = 3
    '        DO_EXITCHL = 4
    '    End Enum
    '    ' Константы для NET_CHAT
    '    Public Enum NET_CHAT_CONS
    '        CHAT_DC2 = 0
    '        CHAT_TXT = 1
    '        CHAT_ME = 2
    '        CHAT_OTHER = 3
    '    End Enum
    '    Public Enum DCB_PLUGINS_OPER
    '        OPER_CHNICK = 0
    '        OPER_CHTOPIC = 1
    '        OPER_TALK = 2
    '        OPER_SCRIPT = 3
    '        OPER_CLOSE = 4
    '    End Enum
    '#End Region

#End Region
#Region " Users and Channels DB's "
    Public Class DCB_UsersDB
        Dim MainCollection As New Collection
        'Const MAXUSR As Integer = 5000


        Public Sub Add(ByVal UDBEntry As DCB_Channels2.DCB_User)

            Try
                MainCollection.Add(UDBEntry, UDBEntry._internUID)
            Catch
            End Try
        End Sub

        Public Overloads Sub Remove(ByVal _internUID As String)


            MainCollection.Remove(_internUID)

        End Sub
        Public Function Item_UID(ByVal UID As String) As DCB_Channels2.DCB_User
            Try
                Dim tmp As DCB_Channels2.DCB_User
                For Each tmp In MainCollection
                    If tmp.UserID.ToLower = UID.ToLower Then Return tmp
                Next
                Return Nothing
            Catch
                Return Nothing
            End Try

        End Function
        Public Function Item_Name(ByVal NAME As String, ByVal PID As String) As DCB_Channels2.DCB_User
            Try
                Dim tmp As Object
                For Each tmp In MainCollection
                    If CType(tmp, DCB_Channels2.DCB_User).UserNick.ToLower = NAME.ToLower And tmp.creater = PID Then Return tmp
                Next
            Catch
                Return Nothing
            End Try

        End Function
        Public Function UDB_Main_Collection(ByVal PID As String) As Collection
            Return MainCollection
        End Function
    End Class

    Public Class DCB_ChannelsDB
        Const MAXCHL = 100
        Dim MainBase(MAXCHL) As Object
        Dim IndexBase(MAXCHL) As String
        Dim IndexBase_PID(MAXCHL) As String
        Dim MainCollection As New Collection
        Public Sub AddCHL(ByRef CHLEntry As DCB_Channels2.DCB_Channel)

            MainCollection.Add(CHLEntry, CHLEntry.CHLID.ToLower)
        End Sub

        Public Function GetCHL_CHLID(ByRef CHLID As String) As DCB_Channels2.DCB_Channel
            Try
                Return CType(MainCollection.Item(CHLID.ToLower), DCB_Channels2.DCB_Channel)
            Catch
                Return Nothing
            End Try
            'Dim Tmp As Byte
            'For Tmp = 1 To MAXCHL
            '    If IndexBase(Tmp) = Nothing Then Return Nothing
            '    If IndexBase(Tmp) = CHLID Then Return MainBase(Tmp)
            'Next
            'Return Nothing
        End Function
        Public Function GetCHL_NAME(ByRef CHLNAME As String, ByVal PID As String) As DCB_Channels2.DCB_Channel
            Return GetCHL_CHLID((PID & CHLNAME).ToLower)
        End Function
        Public Sub RemoveCHL_CHLID(ByRef CHLID As String)
            MainCollection.Remove(CHLID.ToLower)
        End Sub
        'Public Sub RemoveCHL_NAME(ByRef CHLNAME As String)
        '    Dim Tmp As Integer
        '    For Tmp = 1 To MAXCHL
        '        If IndexBase(Tmp) = Nothing Then Exit For
        '        If CType(MainBase(Tmp), DCB_Channels2.DCB_Channel).CHLName = CHLNAME Then IndexBase(Tmp) = "" : MainBase(Tmp) = "" : Exit For
        '    Next
        ' End Sub

        Public Function GetArrayFromPID(ByVal PID As String) As Collection
            Dim Coll As New Collection
            Dim tmp As UNI_Plugin.UNI_DChat.DCB_V1.DCB_Channels2.DCB_Channel

            For Each tmp In MainCollection
                If tmp.PID = PID Then Coll.Add(tmp)
                'If IndexBase(tmp) = Nothing Then Exit For
                'If IndexBase_PID(tmp) = PID Then Coll.Add(MainBase(tmp))
            Next
            Return Coll
        End Function
    End Class
#End Region

    Structure InterfUNI
        ' Общие настройки интерфейса
        Dim TimeRS As String
        Dim TimeLS As String
        Dim NickRS As String
        Dim NickLS As String
        Dim HKShift As Boolean
        Dim HKAlt As Boolean
        Dim HKCtrl As Boolean
        Dim HKKey As Byte
        Dim HKeyUse As Boolean
        Dim HKeyString As String
        Dim ShowTimeMsg As Boolean
        Dim Tabs As Byte
        Dim ShowTopicBar As Boolean
        Dim ShowUsrNameBar As Boolean
        Dim ChatFont As String
        Dim ChatFontSize As Integer
        Dim ChatFontBold As Boolean
        Dim ChatFontUnderl As Boolean
        Dim PopUpLineChat As Boolean
        Dim PopUpLogOn As Boolean
        Dim PupUpMsgBusy As Boolean
        Dim PupUpMsgGame As Boolean
        Dim PupUpMsgAway As Boolean
        Dim RunMin As Boolean
        Dim UseFormat As Boolean
        Dim ShowMenuBar As Boolean
        Dim UListPosition As Byte ' (1 право 2 лево)
    End Structure

    Structure ColorsUNI

        Dim BackChatColor As Color
    End Structure

    Structure ChatSndsUNI
        ' Общие настроки звуков
        Dim Logon As String
        Dim LogOff As String
        Dim StartPriv As String
        Dim ClosePriv As String
        Dim ChatLine As String
        Dim SendMessage As String
        Dim ReceiveMessage As String
        Dim MassMsg As String
        Dim ChTopic As String
        Dim ChNick As String
        Dim MeLine As String
        Dim UsrBeep As String
        Dim RemoteExec As String
        Dim GetScreenShot As String
        Dim AddLink As String
        Dim LogOnChl As String
        Dim LogOffChl As String
        Dim SoundOn As Boolean
        Dim SoundAway As Boolean
        Dim SoundBusy As Boolean
    End Structure

    Structure ChatParamUNI
        ' Параметры программы
        Dim MyVer As String
        Dim MyVerFChat As String
        Dim MyVerFTitle As String
        Dim MyKEY As String
    End Structure

    Structure GlobalParamsUNI
        Dim ScriptsPath As String
        Dim UseAutoExec As Boolean
        Dim Debugmode As Boolean
    End Structure

    Public DCB_SoundSettings As ChatSndsUNI
    Public DCB_InterfaceSettings As InterfUNI
    Public DCB_ColorSettings As ColorsUNI
    Public DCB_ChatParams As ChatParamUNI
    Public DCB_mnuBtn As MouseButtons
    Public DCB_BaseSettings As GlobalParamsUNI

    ' Обязательные плагины
    Public DC2Conv As New RTF2IRC.DC2Converter
End Module
