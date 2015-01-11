Public Class frmChangeMode
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
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents comComment As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.comComment = New System.Windows.Forms.ComboBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'comComment
        '
        Me.comComment.Location = New System.Drawing.Point(-2, -2)
        Me.comComment.Name = "comComment"
        Me.comComment.Size = New System.Drawing.Size(344, 21)
        Me.comComment.TabIndex = 1
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOk.Location = New System.Drawing.Point(200, 48)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(72, 24)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.TabStop = False
        Me.cmdOk.Text = "Сменить"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Location = New System.Drawing.Point(280, 48)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "Отмена"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.comComment})
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(341, 18)
        Me.Panel1.TabIndex = 3
        '
        'frmChangeMode
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(362, 79)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.cmdCancel, Me.cmdOk})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmChangeMode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Изменение режима"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmChangeMode
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmChangeMode
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmChangeMode()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmChangeMode)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Dim ModeComments(10) As String
    Dim NewMod As Byte

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Public Sub ShowForm(ByVal SelMod As Byte)
        NewMod = SelMod
        LoadMsgArchive()

        Select Case SelMod
            Case NET_ONLINE_MOD_CONS.MOD_WORK
                Me.Text = "Комментарий для режима: Занят"
                SelMod = NET_ONLINE_MOD_CONS.MOD_WORK
            Case NET_ONLINE_MOD_CONS.MOD_AWAY
                Me.Text = "Комментарий для режима: Ушёл"
                SelMod = NET_ONLINE_MOD_CONS.MOD_AWAY
            Case NET_ONLINE_MOD_CONS.MOD_OFF
                Me.Text = "Комментарий для режима: Отключен"
                SelMod = NET_ONLINE_MOD_CONS.MOD_OFF
            Case NET_ONLINE_MOD_CONS.MOD_GAME
                Me.Text = "Комментарий для режима: Игровой"
                SelMod = NET_ONLINE_MOD_CONS.MOD_GAME
        End Select
        Me.Validate()
        Me.Show()

    End Sub
    Public Sub LoadMsgArchive()
        Dim Tmp As Byte
        For Tmp = 0 To 10
            ModeComments(Tmp) = Settings2.GetModeComment(GetSettingModPref() & Tmp)
            Try
                comComment.Items.Add(ModeComments(Tmp))
            Catch
            End Try
            comComment.Text = Settings2.GetModeComment(GetSettingModPref() & "LastDesc")
        Next
    End Sub

    Public Sub SaveMsgDesc()
        Dim Tmp As Byte
        For Tmp = 0 To 10
            Settings2.SaveModeComment(GetSettingModPref() & Tmp, ModeComments(Tmp))
        Next
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        'CheckDescList()
        'DCB_UserSettings.UMode = NewMod
        'DCB_UserSettings.UModeDescription = comComment.Text
        'Chat.DCB_ShowChangeMode(NewMod, comComment.Text)

        'Me.Close()
    End Sub

    Private Sub CheckDescList()
        Dim Tmp As Integer

        Settings2.SaveModeComment(GetSettingModPref() & "LastDesc", comComment.Text)
        For Tmp = 0 To 10
            If comComment.Text = ModeComments(Tmp) Then Exit Sub
        Next
        For Tmp = 10 To 1 Step -1
            ModeComments(Tmp) = ModeComments(Tmp - 1)
        Next
        ModeComments(0) = comComment.Text
        SaveMsgDesc()
    End Sub
    Private Function GetSettingModPref() As String
        Select Case NewMod
            Case NET_ONLINE_MOD_CONS.MOD_OFF
                GetSettingModPref = "OfModCom"
            Case NET_ONLINE_MOD_CONS.MOD_AWAY
                GetSettingModPref = "AwModCom"
            Case NET_ONLINE_MOD_CONS.MOD_GAME
                GetSettingModPref = "GaModCom"
            Case NET_ONLINE_MOD_CONS.MOD_WORK
                GetSettingModPref = "WrModCom"
        End Select
    End Function


    Private Sub frmChangeMode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = False And e.Alt = False And e.Shift = False And e.KeyCode = Keys.Enter Then cmdOk_Click(Me, New System.EventArgs())

    End Sub
End Class
