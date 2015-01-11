' DZFS.NET 2003-2005
' DChat Project
' DChat Base
'------------------------------------------------------------------------------------
' Programmed by Garikk
' DCB_Network module (TCP)
' Ver 2
'------------------------------------------------------------------------------------
Option Strict On

Imports System.Net.Sockets
Imports System.Text
Imports UNI_Plugin.UNI_DChat

Friend Class DCB_NET_Socket
    Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_NetSocket

    Dim SCK As Net.Sockets.Socket
    Dim EP As Net.IPEndPoint
    Dim WithEvents tmrNetRead As New Timer
    Dim MCastMode As Boolean = False
    Dim SocketMode As Net.Sockets.ProtocolType
    Dim CloseConnect As Boolean = False
    Dim MHost As String
    Dim MCastTTL As Integer
    Dim Intern_ParentPluginID As UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_PluginInfo

    Public Event DCB_DCNET_ReciveData(ByVal Dat As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_NetSocket.DCB_NET_ReciveData
    Public Event DCB_DCNET_Error(ByVal Err As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_NetSocket.DCB_NET_Error

    Public Sub DCNET_NetInit(ByVal PluginID As UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_PluginInfo) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_NetSocket.DCB_NET_NetInit
        Intern_ParentPluginID = PluginID
        SCK = New Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        AddHandler tmrNetRead.Tick, AddressOf DCNET_TIMER_TCP_READER
        tmrNetRead.Interval = 5
        tmrNetRead.Enabled = False
    End Sub
    Public Function DCB_NET_TCP_ChangeServer(ByVal URL As String, ByVal Port As Integer) As Boolean ' Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_NetSocket.DCB_NET_TCP_ChangeServ
        SCK.Close()
        SCK = New Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Try
            EP = New System.Net.IPEndPoint(System.Net.IPAddress.Parse(URL), Port)
            Return True
        Catch
            Try
                EP = New System.Net.IPEndPoint(System.Net.Dns.GetHostByName(URL).AddressList(0), Port)
                Return True
            Catch e As Exception
                RaiseEvent DCB_DCNET_Error("<DCB_NET_TCP_ChangeServer>" & e.Message)
            End Try
        End Try
        Return False

    End Function
    Public Sub DCB_NET_SendMessage(ByVal CMDToSend As String) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_NetSocket.DCB_NET_SendMessage
        Dim sendBytes As [Byte]() = ASCIIEncoding.GetEncoding(1251).GetBytes(CMDToSend)
        Try
            SCK.SendTo(sendBytes, EP)
        Catch E As Exception
            RaiseEvent DCB_DCNET_Error("<DCB_NET_SM>" & E.Message)
        End Try
    End Sub

    Private Sub DCNET_TIMER_TCP_READER(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bytes As Byte()
        Dim InData As String
        Try
            If SCK.Available > 0 Then
                bytes = ASCIIEncoding.Default.GetBytes(Space(SCK.Available))

                SCK.Receive(bytes)

                InData = ASCIIEncoding.Default.GetChars(bytes)
                RaiseEvent DCB_DCNET_ReciveData(InData)

            End If
        Catch Ex As Exception
            RaiseEvent DCB_DCNET_Error("<DCNET_TIMER_TCP_READER>" & Ex.Message)
        End Try
    End Sub

    Public Sub DCB_NET_Connect(ByVal URL As String, ByVal Port As Integer) Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_NetSocket.DCB_NET_Connect
        CloseConnect = False
        Try
            If DCB_NET_TCP_ChangeServer(URL, Port) = True Then
                SCK.Connect(EP)
                tmrNetRead.Enabled = True
            End If

        Catch E As Exception
            RaiseEvent DCB_DCNET_Error("<DCB_NET_Connect>" & E.Message)
        End Try
    End Sub
    Public Sub DCB_NET_Disconnect() Implements UNI_Plugin.UNI_DChat.DCB_V1.DCB_Base.DCB_NetSocket.DCB_NET_Disconnect
        CloseConnect = True
        If Not tmrNetRead Is Nothing Then
            tmrNetRead.Stop()
            RemoveHandler tmrNetRead.Tick, AddressOf DCNET_TIMER_TCP_READER
            tmrNetRead = Nothing
        End If
        If Not SCK Is Nothing Then
            SCK.Close()
            SCK = Nothing
        End If
    End Sub
End Class

