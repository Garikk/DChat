Public Class frmCHLInfo
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
    Friend WithEvents lblCHLTopic As System.Windows.Forms.Label
    Friend WithEvents grpCHLModes As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkModN As System.Windows.Forms.CheckBox
    Friend WithEvents chkModI As System.Windows.Forms.CheckBox
    Friend WithEvents chkModM As System.Windows.Forms.CheckBox
    Friend WithEvents chkModK As System.Windows.Forms.CheckBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents chkModP As System.Windows.Forms.CheckBox
    Friend WithEvents chkModS As System.Windows.Forms.CheckBox
    Friend WithEvents tbsBEI As System.Windows.Forms.TabControl
    Friend WithEvents cmdAddBan As System.Windows.Forms.Button
    Friend WithEvents cmdDelBan As System.Windows.Forms.Button
    Friend WithEvents cmdDelException As System.Windows.Forms.Button
    Friend WithEvents cmdAddException As System.Windows.Forms.Button
    Friend WithEvents cmdDelInvite As System.Windows.Forms.Button
    Friend WithEvents cmdAddInvite As System.Windows.Forms.Button
    Friend WithEvents TbpBans As System.Windows.Forms.TabPage
    Friend WithEvents tbpExceptions As System.Windows.Forms.TabPage
    Friend WithEvents tbpInvites As System.Windows.Forms.TabPage
    Friend WithEvents chkModT As System.Windows.Forms.CheckBox
    Friend WithEvents chkModL As System.Windows.Forms.CheckBox
    Friend WithEvents txtL As System.Windows.Forms.NumericUpDown
    Friend WithEvents lstBans As System.Windows.Forms.TreeView
    Friend WithEvents lblBanWarn As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCHLTopic As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdChangetopic As System.Windows.Forms.Button
    Friend WithEvents lstInvites As System.Windows.Forms.TreeView
    Friend WithEvents lstExceptions As System.Windows.Forms.TreeView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblCHLTopic = New System.Windows.Forms.Label
        Me.grpCHLModes = New System.Windows.Forms.GroupBox
        Me.chkModS = New System.Windows.Forms.CheckBox
        Me.chkModP = New System.Windows.Forms.CheckBox
        Me.txtL = New System.Windows.Forms.NumericUpDown
        Me.chkModL = New System.Windows.Forms.CheckBox
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.chkModK = New System.Windows.Forms.CheckBox
        Me.chkModM = New System.Windows.Forms.CheckBox
        Me.chkModI = New System.Windows.Forms.CheckBox
        Me.chkModN = New System.Windows.Forms.CheckBox
        Me.chkModT = New System.Windows.Forms.CheckBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.tbsBEI = New System.Windows.Forms.TabControl
        Me.TbpBans = New System.Windows.Forms.TabPage
        Me.lblBanWarn = New System.Windows.Forms.Label
        Me.lstBans = New System.Windows.Forms.TreeView
        Me.cmdDelBan = New System.Windows.Forms.Button
        Me.cmdAddBan = New System.Windows.Forms.Button
        Me.tbpInvites = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdDelInvite = New System.Windows.Forms.Button
        Me.cmdAddInvite = New System.Windows.Forms.Button
        Me.tbpExceptions = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdDelException = New System.Windows.Forms.Button
        Me.cmdAddException = New System.Windows.Forms.Button
        Me.cmdChangetopic = New System.Windows.Forms.Button
        Me.txtCHLTopic = New System.Windows.Forms.RichTextBox
        Me.lstInvites = New System.Windows.Forms.TreeView
        Me.lstExceptions = New System.Windows.Forms.TreeView
        Me.grpCHLModes.SuspendLayout()
        CType(Me.txtL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbsBEI.SuspendLayout()
        Me.TbpBans.SuspendLayout()
        Me.tbpInvites.SuspendLayout()
        Me.tbpExceptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCHLTopic
        '
        Me.lblCHLTopic.AutoSize = True
        Me.lblCHLTopic.Location = New System.Drawing.Point(8, 8)
        Me.lblCHLTopic.Name = "lblCHLTopic"
        Me.lblCHLTopic.Size = New System.Drawing.Size(418, 16)
        Me.lblCHLTopic.TabIndex = 0
        Me.lblCHLTopic.Text = "Тема канала: (Внимание, тема будет изменена сразу после редактирования!)"
        '
        'grpCHLModes
        '
        Me.grpCHLModes.Controls.Add(Me.chkModS)
        Me.grpCHLModes.Controls.Add(Me.chkModP)
        Me.grpCHLModes.Controls.Add(Me.txtL)
        Me.grpCHLModes.Controls.Add(Me.chkModL)
        Me.grpCHLModes.Controls.Add(Me.txtPass)
        Me.grpCHLModes.Controls.Add(Me.chkModK)
        Me.grpCHLModes.Controls.Add(Me.chkModM)
        Me.grpCHLModes.Controls.Add(Me.chkModI)
        Me.grpCHLModes.Controls.Add(Me.chkModN)
        Me.grpCHLModes.Controls.Add(Me.chkModT)
        Me.grpCHLModes.Location = New System.Drawing.Point(288, 56)
        Me.grpCHLModes.Name = "grpCHLModes"
        Me.grpCHLModes.Size = New System.Drawing.Size(304, 216)
        Me.grpCHLModes.TabIndex = 2
        Me.grpCHLModes.TabStop = False
        Me.grpCHLModes.Text = "Флаги канала"
        '
        'chkModS
        '
        Me.chkModS.Location = New System.Drawing.Point(8, 184)
        Me.chkModS.Name = "chkModS"
        Me.chkModS.Size = New System.Drawing.Size(240, 24)
        Me.chkModS.TabIndex = 9
        Me.chkModS.Text = "Секретный канал (+s)"
        '
        'chkModP
        '
        Me.chkModP.Location = New System.Drawing.Point(8, 160)
        Me.chkModP.Name = "chkModP"
        Me.chkModP.Size = New System.Drawing.Size(240, 24)
        Me.chkModP.TabIndex = 8
        Me.chkModP.Text = "Приватный канал (+p)"
        '
        'txtL
        '
        Me.txtL.Location = New System.Drawing.Point(240, 136)
        Me.txtL.Name = "txtL"
        Me.txtL.Size = New System.Drawing.Size(56, 20)
        Me.txtL.TabIndex = 7
        Me.txtL.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'chkModL
        '
        Me.chkModL.Location = New System.Drawing.Point(8, 136)
        Me.chkModL.Name = "chkModL"
        Me.chkModL.Size = New System.Drawing.Size(232, 24)
        Me.chkModL.TabIndex = 6
        Me.chkModL.Text = "Ограничение числа пользователей (+l)"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(240, 112)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(56, 20)
        Me.txtPass.TabIndex = 5
        Me.txtPass.Text = ""
        '
        'chkModK
        '
        Me.chkModK.Location = New System.Drawing.Point(8, 112)
        Me.chkModK.Name = "chkModK"
        Me.chkModK.Size = New System.Drawing.Size(144, 24)
        Me.chkModK.TabIndex = 4
        Me.chkModK.Text = "Пароль: (+k)"
        '
        'chkModM
        '
        Me.chkModM.Location = New System.Drawing.Point(8, 88)
        Me.chkModM.Name = "chkModM"
        Me.chkModM.Size = New System.Drawing.Size(216, 24)
        Me.chkModM.TabIndex = 3
        Me.chkModM.Text = "Канал с модерированием (+m)"
        '
        'chkModI
        '
        Me.chkModI.Location = New System.Drawing.Point(8, 64)
        Me.chkModI.Name = "chkModI"
        Me.chkModI.Size = New System.Drawing.Size(216, 24)
        Me.chkModI.TabIndex = 2
        Me.chkModI.Text = "Вход только по приглашению (+i)"
        '
        'chkModN
        '
        Me.chkModN.Location = New System.Drawing.Point(8, 40)
        Me.chkModN.Name = "chkModN"
        Me.chkModN.Size = New System.Drawing.Size(216, 24)
        Me.chkModN.TabIndex = 1
        Me.chkModN.Text = "Запретить внешние сообщения (+n)"
        '
        'chkModT
        '
        Me.chkModT.Location = New System.Drawing.Point(8, 16)
        Me.chkModT.Name = "chkModT"
        Me.chkModT.Size = New System.Drawing.Size(248, 24)
        Me.chkModT.TabIndex = 0
        Me.chkModT.Text = "Заблокировать тему (+t)"
        '
        'cmdOk
        '
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdOk.Location = New System.Drawing.Point(408, 280)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(88, 24)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Location = New System.Drawing.Point(504, 280)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(88, 24)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Отмена"
        '
        'tbsBEI
        '
        Me.tbsBEI.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tbsBEI.Controls.Add(Me.TbpBans)
        Me.tbsBEI.Controls.Add(Me.tbpInvites)
        Me.tbsBEI.Controls.Add(Me.tbpExceptions)
        Me.tbsBEI.HotTrack = True
        Me.tbsBEI.Location = New System.Drawing.Point(8, 56)
        Me.tbsBEI.Name = "tbsBEI"
        Me.tbsBEI.SelectedIndex = 0
        Me.tbsBEI.ShowToolTips = True
        Me.tbsBEI.Size = New System.Drawing.Size(280, 216)
        Me.tbsBEI.TabIndex = 5
        '
        'TbpBans
        '
        Me.TbpBans.Controls.Add(Me.lblBanWarn)
        Me.TbpBans.Controls.Add(Me.lstBans)
        Me.TbpBans.Controls.Add(Me.cmdDelBan)
        Me.TbpBans.Controls.Add(Me.cmdAddBan)
        Me.TbpBans.Location = New System.Drawing.Point(4, 25)
        Me.TbpBans.Name = "TbpBans"
        Me.TbpBans.Size = New System.Drawing.Size(272, 187)
        Me.TbpBans.TabIndex = 0
        Me.TbpBans.Text = "Баны (+b)"
        Me.TbpBans.ToolTipText = "Список банов канала"
        '
        'lblBanWarn
        '
        Me.lblBanWarn.Location = New System.Drawing.Point(184, 72)
        Me.lblBanWarn.Name = "lblBanWarn"
        Me.lblBanWarn.Size = New System.Drawing.Size(80, 104)
        Me.lblBanWarn.TabIndex = 4
        Me.lblBanWarn.Text = "Внимание! Бан добавляется или удаляется сразу после изменения списка"
        Me.lblBanWarn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstBans
        '
        Me.lstBans.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstBans.ImageIndex = -1
        Me.lstBans.Location = New System.Drawing.Point(0, 0)
        Me.lstBans.Name = "lstBans"
        Me.lstBans.SelectedImageIndex = -1
        Me.lstBans.ShowLines = False
        Me.lstBans.ShowPlusMinus = False
        Me.lstBans.ShowRootLines = False
        Me.lstBans.Size = New System.Drawing.Size(184, 187)
        Me.lstBans.TabIndex = 3
        '
        'cmdDelBan
        '
        Me.cmdDelBan.Location = New System.Drawing.Point(192, 40)
        Me.cmdDelBan.Name = "cmdDelBan"
        Me.cmdDelBan.Size = New System.Drawing.Size(64, 24)
        Me.cmdDelBan.TabIndex = 2
        Me.cmdDelBan.Text = "Удалить"
        '
        'cmdAddBan
        '
        Me.cmdAddBan.Location = New System.Drawing.Point(192, 8)
        Me.cmdAddBan.Name = "cmdAddBan"
        Me.cmdAddBan.Size = New System.Drawing.Size(64, 24)
        Me.cmdAddBan.TabIndex = 1
        Me.cmdAddBan.Text = "Добавить"
        '
        'tbpInvites
        '
        Me.tbpInvites.Controls.Add(Me.lstInvites)
        Me.tbpInvites.Controls.Add(Me.Label1)
        Me.tbpInvites.Controls.Add(Me.cmdDelInvite)
        Me.tbpInvites.Controls.Add(Me.cmdAddInvite)
        Me.tbpInvites.Location = New System.Drawing.Point(4, 25)
        Me.tbpInvites.Name = "tbpInvites"
        Me.tbpInvites.Size = New System.Drawing.Size(272, 187)
        Me.tbpInvites.TabIndex = 2
        Me.tbpInvites.Text = "Приглашения (+I)"
        Me.tbpInvites.ToolTipText = "Список Приглашений канала"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(184, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 104)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Внимание! приглашение добавляется или удаляется сразу после изменения списка"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdDelInvite
        '
        Me.cmdDelInvite.Location = New System.Drawing.Point(192, 40)
        Me.cmdDelInvite.Name = "cmdDelInvite"
        Me.cmdDelInvite.Size = New System.Drawing.Size(64, 24)
        Me.cmdDelInvite.TabIndex = 5
        Me.cmdDelInvite.Text = "Удалить"
        '
        'cmdAddInvite
        '
        Me.cmdAddInvite.Location = New System.Drawing.Point(192, 8)
        Me.cmdAddInvite.Name = "cmdAddInvite"
        Me.cmdAddInvite.Size = New System.Drawing.Size(64, 24)
        Me.cmdAddInvite.TabIndex = 4
        Me.cmdAddInvite.Text = "Добавить"
        '
        'tbpExceptions
        '
        Me.tbpExceptions.Controls.Add(Me.lstExceptions)
        Me.tbpExceptions.Controls.Add(Me.Label2)
        Me.tbpExceptions.Controls.Add(Me.cmdDelException)
        Me.tbpExceptions.Controls.Add(Me.cmdAddException)
        Me.tbpExceptions.Location = New System.Drawing.Point(4, 25)
        Me.tbpExceptions.Name = "tbpExceptions"
        Me.tbpExceptions.Size = New System.Drawing.Size(272, 187)
        Me.tbpExceptions.TabIndex = 1
        Me.tbpExceptions.Text = "Исключения (+e)"
        Me.tbpExceptions.ToolTipText = "Список Исключений канала"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(184, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 104)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Внимание! исключение добавляется или удаляется сразу после изменения списка"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdDelException
        '
        Me.cmdDelException.Location = New System.Drawing.Point(192, 40)
        Me.cmdDelException.Name = "cmdDelException"
        Me.cmdDelException.Size = New System.Drawing.Size(64, 24)
        Me.cmdDelException.TabIndex = 5
        Me.cmdDelException.Text = "Удалить"
        '
        'cmdAddException
        '
        Me.cmdAddException.Location = New System.Drawing.Point(192, 8)
        Me.cmdAddException.Name = "cmdAddException"
        Me.cmdAddException.Size = New System.Drawing.Size(64, 24)
        Me.cmdAddException.TabIndex = 4
        Me.cmdAddException.Text = "Добавить"
        '
        'cmdChangetopic
        '
        Me.cmdChangetopic.Location = New System.Drawing.Point(528, 24)
        Me.cmdChangetopic.Name = "cmdChangetopic"
        Me.cmdChangetopic.Size = New System.Drawing.Size(64, 20)
        Me.cmdChangetopic.TabIndex = 6
        Me.cmdChangetopic.Text = "Изменить"
        '
        'txtCHLTopic
        '
        Me.txtCHLTopic.Location = New System.Drawing.Point(8, 24)
        Me.txtCHLTopic.Multiline = False
        Me.txtCHLTopic.Name = "txtCHLTopic"
        Me.txtCHLTopic.ReadOnly = True
        Me.txtCHLTopic.Size = New System.Drawing.Size(512, 20)
        Me.txtCHLTopic.TabIndex = 7
        Me.txtCHLTopic.Text = ""
        '
        'lstInvites
        '
        Me.lstInvites.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstInvites.ImageIndex = -1
        Me.lstInvites.Location = New System.Drawing.Point(0, 0)
        Me.lstInvites.Name = "lstInvites"
        Me.lstInvites.SelectedImageIndex = -1
        Me.lstInvites.ShowLines = False
        Me.lstInvites.ShowPlusMinus = False
        Me.lstInvites.ShowRootLines = False
        Me.lstInvites.Size = New System.Drawing.Size(184, 187)
        Me.lstInvites.TabIndex = 7
        '
        'lstExceptions
        '
        Me.lstExceptions.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstExceptions.ImageIndex = -1
        Me.lstExceptions.Location = New System.Drawing.Point(0, 0)
        Me.lstExceptions.Name = "lstExceptions"
        Me.lstExceptions.SelectedImageIndex = -1
        Me.lstExceptions.ShowLines = False
        Me.lstExceptions.ShowPlusMinus = False
        Me.lstExceptions.ShowRootLines = False
        Me.lstExceptions.Size = New System.Drawing.Size(184, 187)
        Me.lstExceptions.TabIndex = 7
        '
        'frmCHLInfo
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(594, 311)
        Me.Controls.Add(Me.txtCHLTopic)
        Me.Controls.Add(Me.cmdChangetopic)
        Me.Controls.Add(Me.tbsBEI)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.grpCHLModes)
        Me.Controls.Add(Me.lblCHLTopic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCHLInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Информация о канале"
        Me.grpCHLModes.ResumeLayout(False)
        CType(Me.txtL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbsBEI.ResumeLayout(False)
        Me.TbpBans.ResumeLayout(False)
        Me.tbpInvites.ResumeLayout(False)
        Me.tbpExceptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmCHLInfo
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmCHLInfo
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmCHLInfo
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmCHLInfo)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Public CURCHL As String
    Public SChanged As Boolean = False
    Public USRIsOP As Boolean

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim ExecCMD As String
        Dim NCheck As String
        If SChanged = True Then
            NCheck = "-"
            ExecCMD = "+"
            ' Длинно так написано, что покрасивее выглядело ;)
            If chkModI.Checked = True And CStr(chkModI.Tag) = "C" Then ExecCMD += "i"
            If chkModT.Checked = True And CStr(chkModT.Tag) = "C" Then ExecCMD += "t"
            If chkModM.Checked = True And CStr(chkModM.Tag) = "C" Then ExecCMD += "m"
            If chkModP.Checked = True And CStr(chkModP.Tag) = "C" Then ExecCMD += "p"
            If chkModS.Checked = True And CStr(chkModS.Tag) = "C" Then ExecCMD += "s"
            If chkModN.Checked = True And CStr(chkModN.Tag) = "C" Then ExecCMD += "n"
            If chkModI.Checked = False And CStr(chkModI.Tag) = "C" Then NCheck += "i"
            If chkModT.Checked = False And CStr(chkModT.Tag) = "C" Then NCheck += "t"
            If chkModM.Checked = False And CStr(chkModM.Tag) = "C" Then NCheck += "m"
            If chkModP.Checked = False And CStr(chkModP.Tag) = "C" Then NCheck += "p"
            If chkModS.Checked = False And CStr(chkModS.Tag) = "C" Then NCheck += "s"
            If chkModN.Checked = False And CStr(chkModN.Tag) = "C" Then NCheck += "n"

            If NCheck = "-" Then
                NCheck = ""
            Else
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " " & NCheck)
                NCheck = ""
            End If
            If ExecCMD = "+" Then
                ExecCMD = ""
            Else
                DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " " & ExecCMD)
                ExecCMD = ""
            End If
            If chkModL.Checked = True And CStr(chkModL.Tag) = "C" Then ExecCMD = "+l " & txtL.Text
            If chkModL.Checked = False And CStr(chkModL.Tag) = "C" Then ExecCMD = "-l"
            If ExecCMD <> "" Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " " & ExecCMD)
            If chkModK.Checked = True And CStr(chkModK.Tag) = "C" Then ExecCMD = "+k " & txtPass.Text
            If chkModK.Checked = False And CStr(chkModK.Tag) = "C" Then ExecCMD = "-k " & txtPass.Text
            If ExecCMD <> "" Then DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " " & ExecCMD)
        End If
        Me.Dispose()
    End Sub

    Private Sub chkModT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkModT.Click, chkModI.Click, chkModK.Click, chkModL.Click, chkModM.Click, chkModN.Click, chkModP.Click, chkModS.Click
        SChanged = True
        'CType(sender, Windows.Forms.CheckBox).Tag = True
    End Sub

    Private Sub cmdAddBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddBan.Click
        Dim NewBAN As String = InputBox("Введите имя или маску", "DChat")
        If NewBAN = "" Then Exit Sub
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " +b " & NewBAN)
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " b")
    End Sub

    Private Sub cmdDelBan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelBan.Click
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " -b " & CStr(lstBans.SelectedNode.Tag))
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " b")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangetopic.Click
        If USRIsOP = False And chkModT.Checked = True Then MsgBox("Тему на этом канале может изменить только Оператор (установлен флаг +t)", MsgBoxStyle.Critical) : Exit Sub
        frmIRCColorEditor.DefInstance.txtRTFTxt.Rtf = txtCHLTopic.Rtf
        If frmIRCColorEditor.DefInstance.ShowDialog = Windows.Forms.DialogResult.OK Then
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "/topic " & CURCHL & " :" & frmIRCColorEditor.DefInstance.RText)
            Try
                txtCHLTopic.Rtf = DCB_Interface.DCB_Universal.DC2Converter.DC2ToRTF(CHLCtl.DCB_DChannel(IRC_INF.INF_CMDEXEC & CURCHL).CHLTOPIC, IRC_Settings.IRCFont, IRC_Settings.IRCFontSize)
            Catch
                txtCHLTopic.Text = "Непредвиденная ошибка при смене темы! Возможно канал более недоступен"
            End Try
        End If
    End Sub

    Private Sub frmCHLInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If USRIsOP = False Then
            grpCHLModes.Enabled = False
            cmdAddBan.Enabled = False
            cmdDelBan.Enabled = False
            cmdAddException.Enabled = False
            cmdDelException.Enabled = False
            cmdAddInvite.Enabled = False
            cmdDelInvite.Enabled = False
        Else
            grpCHLModes.Enabled = True
            cmdAddBan.Enabled = True
            cmdDelBan.Enabled = True
            cmdAddException.Enabled = True
            cmdDelException.Enabled = True
            cmdAddInvite.Enabled = True
            cmdDelInvite.Enabled = True
        End If
        chkModI.Tag = ""
        chkModK.Tag = ""
        chkModP.Tag = ""
        chkModS.Tag = ""
        chkModM.Tag = ""
        chkModN.Tag = ""

    End Sub

    Private Sub chkModT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkModT.CheckedChanged, chkModI.CheckedChanged, chkModK.CheckedChanged, chkModL.CheckedChanged, chkModM.CheckedChanged, chkModN.CheckedChanged, chkModP.CheckedChanged, chkModS.CheckedChanged
        CType(sender, Windows.Forms.CheckBox).Tag = "C"
    End Sub

    Private Sub txtL_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtL.ValueChanged
        chkModT_CheckedChanged(chkModL, New EventArgs)
    End Sub

    Private Sub txtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.TextChanged
        chkModT_CheckedChanged(chkModK, New EventArgs)
    End Sub

    Private Sub cmdAddException_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddException.Click
        Dim NewEx As String = InputBox("Введите имя или маску", "DChat")
        If NewEx = "" Then Exit Sub
        Try
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " +e " & NewEx)
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " e")
        Catch
        End Try
    End Sub

    Private Sub cmdDelException_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelException.Click
        Try
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " -e " & CStr(lstExceptions.SelectedNode.Tag))
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " e")
        Catch
        End Try
    End Sub

    Private Sub cmdAddInvite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddInvite.Click
        Dim NewI As String = InputBox("Введите имя или маску", "DChat")
        If NewI = "" Then Exit Sub
        Try
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " +I " & NewI)
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " I")
        Catch
        End Try

    End Sub

    Private Sub cmdDelInvite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelInvite.Click
        Try
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " -I " & CStr(lstInvites.SelectedNode.Tag))
            DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% /mode " & CURCHL & " I")
        Catch
        End Try

    End Sub
End Class
