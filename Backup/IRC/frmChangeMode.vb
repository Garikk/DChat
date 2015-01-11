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
        'Me.Validate()
        'Me.Show()
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.comComment = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.System
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
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Location = New System.Drawing.Point(280, 48)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 24)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "Отмена"
        '
        'comComment
        '
        Me.comComment.Location = New System.Drawing.Point(8, 8)
        Me.comComment.Name = "comComment"
        Me.comComment.Size = New System.Drawing.Size(344, 21)
        Me.comComment.TabIndex = 4
        '
        'frmChangeMode
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(362, 79)
        Me.ControlBox = False
        Me.Controls.Add(Me.comComment)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmChangeMode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Изменение режима"
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
                m_vb6FormDefInstance = New frmChangeMode
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmChangeMode)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Dim ModeComments() As String
    Dim NewMod As Byte
    Dim ModeDesc As String
    Dim ModePref As String


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub LoadMsgArchive()
        Dim Tmp As Byte

        ModeComments = LoadModeComments(ModePref) 'Settings2.GetModeComment(GetSettingModPref() & Tmp)
        comComment.Items.Clear()
        For Tmp = 0 To 10
            Try
                comComment.Items.Add(ModeComments(Tmp))
            Catch
            End Try
        Next
        comComment.Text = ModeComments(0)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        CheckDescList()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CheckDescList()
        Dim Tmp As Integer
        For Tmp = 0 To 10
            If comComment.Text = ModeComments(Tmp) Then Exit Sub
        Next
        For Tmp = 10 To 1 Step -1
            ModeComments(Tmp) = ModeComments(Tmp - 1)
        Next
        ModeComments(0) = comComment.Text

        SaveModeComments(ModePref, ModeComments)
    End Sub

    Public Property Mode() As String
        Get
            Return ModePref
        End Get
        Set(ByVal Value As String)
            ModePref = Value.Trim
            LoadMsgArchive()
            Me.Text = "Комментарий для режима: " & IRC_UserModes(Value).ToString.Split(":"c)(0)
        End Set
    End Property

    Private Sub frmChangeMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
