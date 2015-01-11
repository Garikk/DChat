Public Class frmUserInfo
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents lblChannels As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblUserNick As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblIdle As System.Windows.Forms.Label
    Friend WithEvents txtUserNick As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtChannels As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtIdle As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtRealName As System.Windows.Forms.TextBox
    Friend WithEvents lblRealName As System.Windows.Forms.Label
    Friend WithEvents lblaway As System.Windows.Forms.Label
    Friend WithEvents txtAwayInfo As System.Windows.Forms.TextBox
    Friend WithEvents grpUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grpCTCP As System.Windows.Forms.GroupBox
    Friend WithEvents txtCTCPReply As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCTCPVer As System.Windows.Forms.Button
    Friend WithEvents txtCTCPTime As System.Windows.Forms.Button
    Friend WithEvents cmdFinger As System.Windows.Forms.Button
    Friend WithEvents cmdPing As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpUserInfo = New System.Windows.Forms.GroupBox
        Me.txtAwayInfo = New System.Windows.Forms.TextBox
        Me.lblaway = New System.Windows.Forms.Label
        Me.txtRealName = New System.Windows.Forms.TextBox
        Me.lblRealName = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.txtIdle = New System.Windows.Forms.TextBox
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.txtChannels = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtUserNick = New System.Windows.Forms.TextBox
        Me.lblIdle = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblServer = New System.Windows.Forms.Label
        Me.lblChannels = New System.Windows.Forms.Label
        Me.lblAddress = New System.Windows.Forms.Label
        Me.lblUserNick = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.grpCTCP = New System.Windows.Forms.GroupBox
        Me.cmdFinger = New System.Windows.Forms.Button
        Me.cmdPing = New System.Windows.Forms.Button
        Me.txtCTCPTime = New System.Windows.Forms.Button
        Me.cmdCTCPVer = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCTCPReply = New System.Windows.Forms.TextBox
        Me.grpUserInfo.SuspendLayout()
        Me.grpCTCP.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpUserInfo
        '
        Me.grpUserInfo.Controls.Add(Me.txtAwayInfo)
        Me.grpUserInfo.Controls.Add(Me.lblaway)
        Me.grpUserInfo.Controls.Add(Me.txtRealName)
        Me.grpUserInfo.Controls.Add(Me.lblRealName)
        Me.grpUserInfo.Controls.Add(Me.txtStatus)
        Me.grpUserInfo.Controls.Add(Me.txtIdle)
        Me.grpUserInfo.Controls.Add(Me.txtServer)
        Me.grpUserInfo.Controls.Add(Me.txtChannels)
        Me.grpUserInfo.Controls.Add(Me.txtAddress)
        Me.grpUserInfo.Controls.Add(Me.txtUserNick)
        Me.grpUserInfo.Controls.Add(Me.lblIdle)
        Me.grpUserInfo.Controls.Add(Me.lblStatus)
        Me.grpUserInfo.Controls.Add(Me.lblServer)
        Me.grpUserInfo.Controls.Add(Me.lblChannels)
        Me.grpUserInfo.Controls.Add(Me.lblAddress)
        Me.grpUserInfo.Controls.Add(Me.lblUserNick)
        Me.grpUserInfo.Location = New System.Drawing.Point(8, 8)
        Me.grpUserInfo.Name = "grpUserInfo"
        Me.grpUserInfo.Size = New System.Drawing.Size(320, 160)
        Me.grpUserInfo.TabIndex = 5
        Me.grpUserInfo.TabStop = False
        Me.grpUserInfo.Text = "Информация о пользователе"
        '
        'txtAwayInfo
        '
        Me.txtAwayInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAwayInfo.Location = New System.Drawing.Point(128, 136)
        Me.txtAwayInfo.Name = "txtAwayInfo"
        Me.txtAwayInfo.ReadOnly = True
        Me.txtAwayInfo.Size = New System.Drawing.Size(176, 13)
        Me.txtAwayInfo.TabIndex = 20
        Me.txtAwayInfo.Text = ""
        '
        'lblaway
        '
        Me.lblaway.AutoSize = True
        Me.lblaway.Location = New System.Drawing.Point(7, 136)
        Me.lblaway.Name = "lblaway"
        Me.lblaway.Size = New System.Drawing.Size(112, 16)
        Me.lblaway.TabIndex = 19
        Me.lblaway.Text = "Коммент состояния:"
        '
        'txtRealName
        '
        Me.txtRealName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRealName.Location = New System.Drawing.Point(128, 40)
        Me.txtRealName.Name = "txtRealName"
        Me.txtRealName.ReadOnly = True
        Me.txtRealName.Size = New System.Drawing.Size(176, 13)
        Me.txtRealName.TabIndex = 18
        Me.txtRealName.Text = ""
        '
        'lblRealName
        '
        Me.lblRealName.AutoSize = True
        Me.lblRealName.Location = New System.Drawing.Point(89, 40)
        Me.lblRealName.Name = "lblRealName"
        Me.lblRealName.Size = New System.Drawing.Size(30, 16)
        Me.lblRealName.TabIndex = 17
        Me.lblRealName.Text = "Имя:"
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStatus.Location = New System.Drawing.Point(128, 120)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(176, 13)
        Me.txtStatus.TabIndex = 16
        Me.txtStatus.Text = ""
        '
        'txtIdle
        '
        Me.txtIdle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIdle.Location = New System.Drawing.Point(128, 104)
        Me.txtIdle.Name = "txtIdle"
        Me.txtIdle.ReadOnly = True
        Me.txtIdle.Size = New System.Drawing.Size(176, 13)
        Me.txtIdle.TabIndex = 15
        Me.txtIdle.Text = ""
        '
        'txtServer
        '
        Me.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtServer.Location = New System.Drawing.Point(128, 88)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.ReadOnly = True
        Me.txtServer.Size = New System.Drawing.Size(176, 13)
        Me.txtServer.TabIndex = 14
        Me.txtServer.Text = ""
        '
        'txtChannels
        '
        Me.txtChannels.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChannels.Location = New System.Drawing.Point(128, 72)
        Me.txtChannels.Name = "txtChannels"
        Me.txtChannels.ReadOnly = True
        Me.txtChannels.Size = New System.Drawing.Size(176, 13)
        Me.txtChannels.TabIndex = 13
        Me.txtChannels.Text = ""
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAddress.Location = New System.Drawing.Point(128, 56)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(176, 13)
        Me.txtAddress.TabIndex = 12
        Me.txtAddress.Text = ""
        '
        'txtUserNick
        '
        Me.txtUserNick.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUserNick.Location = New System.Drawing.Point(128, 24)
        Me.txtUserNick.Name = "txtUserNick"
        Me.txtUserNick.ReadOnly = True
        Me.txtUserNick.Size = New System.Drawing.Size(176, 13)
        Me.txtUserNick.TabIndex = 11
        Me.txtUserNick.Text = ""
        '
        'lblIdle
        '
        Me.lblIdle.AutoSize = True
        Me.lblIdle.Location = New System.Drawing.Point(23, 104)
        Me.lblIdle.Name = "lblIdle"
        Me.lblIdle.Size = New System.Drawing.Size(96, 16)
        Me.lblIdle.TabIndex = 10
        Me.lblIdle.Text = "Посл. активность"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(75, 120)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(44, 16)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Статус:"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(72, 88)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(47, 16)
        Me.lblServer.TabIndex = 8
        Me.lblServer.Text = "Сервер:"
        '
        'lblChannels
        '
        Me.lblChannels.AutoSize = True
        Me.lblChannels.Location = New System.Drawing.Point(71, 72)
        Me.lblChannels.Name = "lblChannels"
        Me.lblChannels.Size = New System.Drawing.Size(48, 16)
        Me.lblChannels.TabIndex = 7
        Me.lblChannels.Text = "Каналы:"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(79, 56)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(40, 16)
        Me.lblAddress.TabIndex = 6
        Me.lblAddress.Text = "Адрес:"
        '
        'lblUserNick
        '
        Me.lblUserNick.AutoSize = True
        Me.lblUserNick.Location = New System.Drawing.Point(92, 24)
        Me.lblUserNick.Name = "lblUserNick"
        Me.lblUserNick.Size = New System.Drawing.Size(27, 16)
        Me.lblUserNick.TabIndex = 5
        Me.lblUserNick.Text = "Ник:"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(248, 272)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 24)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "OK"
        '
        'grpCTCP
        '
        Me.grpCTCP.Controls.Add(Me.cmdFinger)
        Me.grpCTCP.Controls.Add(Me.cmdPing)
        Me.grpCTCP.Controls.Add(Me.txtCTCPTime)
        Me.grpCTCP.Controls.Add(Me.cmdCTCPVer)
        Me.grpCTCP.Controls.Add(Me.Label1)
        Me.grpCTCP.Controls.Add(Me.txtCTCPReply)
        Me.grpCTCP.Location = New System.Drawing.Point(8, 168)
        Me.grpCTCP.Name = "grpCTCP"
        Me.grpCTCP.Size = New System.Drawing.Size(320, 96)
        Me.grpCTCP.TabIndex = 7
        Me.grpCTCP.TabStop = False
        Me.grpCTCP.Text = "CTCP"
        '
        'cmdFinger
        '
        Me.cmdFinger.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFinger.Location = New System.Drawing.Point(254, 64)
        Me.cmdFinger.Name = "cmdFinger"
        Me.cmdFinger.Size = New System.Drawing.Size(56, 24)
        Me.cmdFinger.TabIndex = 26
        Me.cmdFinger.Text = "Фингер"
        '
        'cmdPing
        '
        Me.cmdPing.Enabled = False
        Me.cmdPing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPing.Location = New System.Drawing.Point(172, 64)
        Me.cmdPing.Name = "cmdPing"
        Me.cmdPing.Size = New System.Drawing.Size(56, 24)
        Me.cmdPing.TabIndex = 25
        Me.cmdPing.Text = "Пинг"
        '
        'txtCTCPTime
        '
        Me.txtCTCPTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtCTCPTime.Location = New System.Drawing.Point(90, 64)
        Me.txtCTCPTime.Name = "txtCTCPTime"
        Me.txtCTCPTime.Size = New System.Drawing.Size(56, 24)
        Me.txtCTCPTime.TabIndex = 24
        Me.txtCTCPTime.Text = "Время"
        '
        'cmdCTCPVer
        '
        Me.cmdCTCPVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCTCPVer.Location = New System.Drawing.Point(8, 64)
        Me.cmdCTCPVer.Name = "cmdCTCPVer"
        Me.cmdCTCPVer.Size = New System.Drawing.Size(56, 24)
        Me.cmdCTCPVer.TabIndex = 23
        Me.cmdCTCPVer.Text = "Версия"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "CTCP ответ:"
        '
        'txtCTCPReply
        '
        Me.txtCTCPReply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCTCPReply.Location = New System.Drawing.Point(8, 32)
        Me.txtCTCPReply.Name = "txtCTCPReply"
        Me.txtCTCPReply.ReadOnly = True
        Me.txtCTCPReply.Size = New System.Drawing.Size(304, 20)
        Me.txtCTCPReply.TabIndex = 21
        Me.txtCTCPReply.Text = ""
        '
        'frmUserInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(330, 303)
        Me.Controls.Add(Me.grpCTCP)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.grpUserInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Информация о пользователе"
        Me.grpUserInfo.ResumeLayout(False)
        Me.grpCTCP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmUserInfo
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmUserInfo
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmUserInfo
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmUserInfo)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpUserInfo.Enter

    End Sub

    Private Sub cmdCTCPVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCTCPVer.Click
        IRC_DCSE.IRC_CMD_PROCESS("irc_sendtoserver /privmsg " & txtUserNick.Text & " :" & Chr(1) & "VERSION" & Chr(1))

    End Sub

    Private Sub txtCTCPTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCTCPTime.Click
        IRC_DCSE.IRC_CMD_PROCESS("irc_sendtoserver /privmsg " & txtUserNick.Text & " :" & Chr(1) & "TIME" & Chr(1))

    End Sub

    Private Sub cmdFinger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinger.Click
        IRC_DCSE.IRC_CMD_PROCESS("irc_sendtoserver /privmsg " & txtUserNick.Text & " :" & Chr(1) & "FINGER" & Chr(1))
    End Sub

    Private Sub cmdPing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPing.Click
        ' DIM PingTime as String =
        '  IRC_DCSE.IRC_CMD_PROCESS("irc_sendtoserver /privmsg " & txtUserNick.Text & " :" & Chr(1) & "PING" & Chr(1))

    End Sub

    Private Sub frmUserInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InterfaceCTLS.DefInstance.Show()
    End Sub
End Class
