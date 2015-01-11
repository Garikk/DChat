Public Class frmFirstMaster
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
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlStep1 As System.Windows.Forms.Panel
    Friend WithEvents lblS1 As System.Windows.Forms.Label
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents pnlNavigation As System.Windows.Forms.Panel
    Friend WithEvents pnlStep2 As System.Windows.Forms.Panel
    Friend WithEvents pnlStep3 As System.Windows.Forms.Panel
    Friend WithEvents pnlStep4 As System.Windows.Forms.Panel
    Friend WithEvents pnlStep5 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.pnlStep1 = New System.Windows.Forms.Panel
        Me.lblS1 = New System.Windows.Forms.Label
        Me.pnlNavigation = New System.Windows.Forms.Panel
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdBack = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.pnlStep2 = New System.Windows.Forms.Panel
        Me.pnlStep3 = New System.Windows.Forms.Panel
        Me.pnlStep4 = New System.Windows.Forms.Panel
        Me.pnlStep5 = New System.Windows.Forms.Panel
        Me.pnlTitle.SuspendLayout()
        Me.pnlStep1.SuspendLayout()
        Me.pnlNavigation.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.White
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(450, 48)
        Me.pnlTitle.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(273, 16)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Вас приветствует мастер первого запуска DChat"
        '
        'pnlStep1
        '
        Me.pnlStep1.Controls.Add(Me.lblS1)
        Me.pnlStep1.Location = New System.Drawing.Point(24, 64)
        Me.pnlStep1.Name = "pnlStep1"
        Me.pnlStep1.Size = New System.Drawing.Size(490, 216)
        Me.pnlStep1.TabIndex = 1
        Me.pnlStep1.Visible = False
        '
        'lblS1
        '
        Me.lblS1.Location = New System.Drawing.Point(8, 16)
        Me.lblS1.Name = "lblS1"
        Me.lblS1.Size = New System.Drawing.Size(472, 40)
        Me.lblS1.TabIndex = 2
        Me.lblS1.Text = "Вы в первый раз запустили DChat и должны указать некоторые парамеры, такие как Се" & _
        "рвер и Имя пользвателя, для продолжения нажмите Далее"
        '
        'pnlNavigation
        '
        Me.pnlNavigation.Controls.Add(Me.cmdCancel)
        Me.pnlNavigation.Controls.Add(Me.cmdBack)
        Me.pnlNavigation.Controls.Add(Me.cmdNext)
        Me.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlNavigation.Location = New System.Drawing.Point(0, 495)
        Me.pnlNavigation.Name = "pnlNavigation"
        Me.pnlNavigation.Size = New System.Drawing.Size(450, 40)
        Me.pnlNavigation.TabIndex = 3
        '
        'cmdCancel
        '
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Location = New System.Drawing.Point(360, 8)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Отмена"
        '
        'cmdBack
        '
        Me.cmdBack.Enabled = False
        Me.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBack.Location = New System.Drawing.Point(184, 8)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(80, 24)
        Me.cmdBack.TabIndex = 1
        Me.cmdBack.Text = "Назад"
        '
        'cmdNext
        '
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNext.Location = New System.Drawing.Point(272, 8)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(80, 24)
        Me.cmdNext.TabIndex = 0
        Me.cmdNext.Text = "Далее"
        '
        'pnlStep2
        '
        Me.pnlStep2.Location = New System.Drawing.Point(224, 72)
        Me.pnlStep2.Name = "pnlStep2"
        Me.pnlStep2.Size = New System.Drawing.Size(490, 208)
        Me.pnlStep2.TabIndex = 4
        Me.pnlStep2.Visible = False
        '
        'pnlStep3
        '
        Me.pnlStep3.Location = New System.Drawing.Point(256, 96)
        Me.pnlStep3.Name = "pnlStep3"
        Me.pnlStep3.Size = New System.Drawing.Size(490, 192)
        Me.pnlStep3.TabIndex = 5
        Me.pnlStep3.Visible = False
        '
        'pnlStep4
        '
        Me.pnlStep4.Location = New System.Drawing.Point(64, 80)
        Me.pnlStep4.Name = "pnlStep4"
        Me.pnlStep4.Size = New System.Drawing.Size(490, 208)
        Me.pnlStep4.TabIndex = 5
        Me.pnlStep4.Visible = False
        '
        'pnlStep5
        '
        Me.pnlStep5.Location = New System.Drawing.Point(120, 224)
        Me.pnlStep5.Name = "pnlStep5"
        Me.pnlStep5.Size = New System.Drawing.Size(216, 112)
        Me.pnlStep5.TabIndex = 6
        '
        'frmFirstMaster
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(450, 535)
        Me.Controls.Add(Me.pnlStep5)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.pnlStep3)
        Me.Controls.Add(Me.pnlNavigation)
        Me.Controls.Add(Me.pnlStep2)
        Me.Controls.Add(Me.pnlStep1)
        Me.Controls.Add(Me.pnlStep4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmFirstMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Мастер первого запуска"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlStep1.ResumeLayout(False)
        Me.pnlNavigation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmFirstMaster
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmFirstMaster
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmFirstMaster
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmFirstMaster)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Dim NowPage As Integer

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        NowPage -= 1
        If NowPage = 1 Then cmdBack.Enabled = False
        StepNow()
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        NowPage += 1
        If NowPage >= 2 Then cmdBack.Enabled = True
        If NowPage = 3 Then cmdNext.Text = "Далее"
        If NowPage = 4 Then cmdNext.Text = "Завершить"
        If NowPage = 5 Then IRC_CMD_PROCESS("$savesettings$") : IRC_Settings.FirstStart = False : Me.Close()
        StepNow()
    End Sub
    Private Sub InitForm()
        IRC_CMD_PROCESS("$showopionswindow$")

        Dim CCTL1 As Windows.Forms.Panel = CType(IRC_CMD_FUNC("ircgui_getservpnl"), Windows.Forms.Panel)
        CCTL1.Visible = True
        CCTL1.Dock = Windows.Forms.DockStyle.Fill
        pnlStep2.Controls.Add(CCTL1)

        CCTL1 = CType(IRC_CMD_FUNC("ircgui_strings"), Windows.Forms.Panel)
        CCTL1.Visible = True
        CCTL1.Dock = Windows.Forms.DockStyle.Fill
        pnlStep3.Controls.Add(CCTL1)

        CCTL1 = CType(IRC_CMD_FUNC("ircgui_getuserspnl"), Windows.Forms.Panel)
        CCTL1.Visible = True
        CCTL1.Dock = Windows.Forms.DockStyle.Fill
        pnlStep4.Controls.Add(CCTL1)

        'Panel4.Controls.Add(CType(DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "ircgui_getuserspnl"), Windows.Forms.Panel))
        NowPage = 1
        StepNow()
    End Sub
    Private Sub StepNow()

        Select Case NowPage
            Case 1
                lblTitle.Text = "Вас приветствует мастер первого запуска DChat"
                pnlStep1.Visible = True
                pnlStep1.Dock = Windows.Forms.DockStyle.Fill
                pnlStep2.Visible = False
                pnlStep2.Dock = Windows.Forms.DockStyle.None
                pnlStep3.Visible = False
                pnlStep3.Dock = Windows.Forms.DockStyle.None
                pnlStep4.Visible = False
                pnlStep4.Dock = Windows.Forms.DockStyle.None
                pnlStep5.Visible = False
                pnlStep5.Dock = Windows.Forms.DockStyle.None
            Case 2
                lblTitle.Text = "Сбор данных о пользователе"
                pnlStep1.Visible = False
                pnlStep1.Dock = Windows.Forms.DockStyle.None
                pnlStep2.Visible = True
                pnlStep2.Dock = Windows.Forms.DockStyle.Fill
                pnlStep3.Visible = False
                pnlStep3.Dock = Windows.Forms.DockStyle.None
                pnlStep4.Visible = False
                pnlStep4.Dock = Windows.Forms.DockStyle.None
                pnlStep5.Visible = False
                pnlStep5.Dock = Windows.Forms.DockStyle.None
            Case 3
                lblTitle.Text = "Указание дополнительных параметров"
                pnlStep1.Visible = False
                pnlStep1.Dock = Windows.Forms.DockStyle.None
                pnlStep2.Visible = False
                pnlStep2.Dock = Windows.Forms.DockStyle.None
                pnlStep3.Visible = True
                pnlStep3.Dock = Windows.Forms.DockStyle.Fill
                pnlStep4.Visible = False
                pnlStep4.Dock = Windows.Forms.DockStyle.None
                pnlStep5.Visible = False
                pnlStep5.Dock = Windows.Forms.DockStyle.None
            Case 4
                lblTitle.Text = "Настройка сетевого подключения"
                pnlStep1.Visible = False
                pnlStep1.Dock = Windows.Forms.DockStyle.None
                pnlStep2.Visible = False
                pnlStep2.Dock = Windows.Forms.DockStyle.None
                pnlStep3.Visible = False
                pnlStep3.Dock = Windows.Forms.DockStyle.None
                pnlStep4.Visible = True
                pnlStep4.Dock = Windows.Forms.DockStyle.Fill
                pnlStep5.Visible = False
                pnlStep5.Dock = Windows.Forms.DockStyle.None
            Case 5
                pnlStep1.Visible = False
                pnlStep1.Dock = Windows.Forms.DockStyle.None
                pnlStep2.Visible = False
                pnlStep2.Dock = Windows.Forms.DockStyle.None
                pnlStep3.Visible = False
                pnlStep3.Dock = Windows.Forms.DockStyle.None
                pnlStep4.Visible = False
                pnlStep4.Dock = Windows.Forms.DockStyle.None
                pnlStep5.Visible = True
                pnlStep5.Dock = Windows.Forms.DockStyle.Fill
        End Select
        pnlTitle.SendToBack()
    End Sub

    Private Sub frmFirstMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitForm()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlNavigation.Paint

    End Sub
End Class
