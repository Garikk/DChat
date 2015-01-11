Public Class frmSettings
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
    Friend WithEvents fraSettings As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents trwSettings As System.Windows.Forms.TreeView
    Friend WithEvents pnlInterface_Other As System.Windows.Forms.Panel
    Friend WithEvents fraPopHotKey As System.Windows.Forms.GroupBox
    Friend WithEvents pupTxtHotKey As System.Windows.Forms.TextBox
    Friend WithEvents pupChkHotKey As System.Windows.Forms.CheckBox
    Friend WithEvents pnlPlugins As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstPlugins As System.Windows.Forms.ListView
    Friend WithEvents lblOptions As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents lblPluginDeveloper As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblInterfaceType As System.Windows.Forms.Label
    Friend WithEvents lblPluginPath As System.Windows.Forms.Label
    Friend WithEvents lblPluginVersion As System.Windows.Forms.Label
    Friend WithEvents lblPluginName As System.Windows.Forms.Label
    Friend WithEvents lblline1 As System.Windows.Forms.Label
    Friend WithEvents lblInterfType As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblPlgVersion As System.Windows.Forms.Label
    Friend WithEvents lblPlgName As System.Windows.Forms.Label
    Friend WithEvents clmStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmPluginName As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFontName As System.Windows.Forms.Label
    Friend WithEvents cmdCHFont As System.Windows.Forms.Button
    Friend WithEvents cmdRestorefont As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdWndColor As System.Windows.Forms.Button
    Friend WithEvents fraOther As System.Windows.Forms.GroupBox
    Friend WithEvents lblTasbStyles As System.Windows.Forms.Label
    Friend WithEvents cmdTabStyles As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeparator As System.Windows.Forms.Label
    Friend WithEvents lblUListPosition As System.Windows.Forms.Label
    Friend WithEvents optLeftUL As System.Windows.Forms.RadioButton
    Friend WithEvents optRightOL As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.fraSettings = New System.Windows.Forms.GroupBox
        Me.pnlInterface_Other = New System.Windows.Forms.Panel
        Me.fraOther = New System.Windows.Forms.GroupBox
        Me.optRightOL = New System.Windows.Forms.RadioButton
        Me.optLeftUL = New System.Windows.Forms.RadioButton
        Me.lblUListPosition = New System.Windows.Forms.Label
        Me.lblSeparator = New System.Windows.Forms.Label
        Me.cmdTabStyles = New System.Windows.Forms.ComboBox
        Me.lblTasbStyles = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdWndColor = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdRestorefont = New System.Windows.Forms.Button
        Me.cmdCHFont = New System.Windows.Forms.Button
        Me.lblFontName = New System.Windows.Forms.Label
        Me.fraPopHotKey = New System.Windows.Forms.GroupBox
        Me.pupTxtHotKey = New System.Windows.Forms.TextBox
        Me.pupChkHotKey = New System.Windows.Forms.CheckBox
        Me.trwSettings = New System.Windows.Forms.TreeView
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.pnlPlugins = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstPlugins = New System.Windows.Forms.ListView
        Me.lblOptions = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.lblPluginDeveloper = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblInterfaceType = New System.Windows.Forms.Label
        Me.lblPluginPath = New System.Windows.Forms.Label
        Me.lblPluginVersion = New System.Windows.Forms.Label
        Me.lblPluginName = New System.Windows.Forms.Label
        Me.lblline1 = New System.Windows.Forms.Label
        Me.lblInterfType = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblPlgVersion = New System.Windows.Forms.Label
        Me.lblPlgName = New System.Windows.Forms.Label
        Me.clmStatus = New System.Windows.Forms.ColumnHeader
        Me.clmPath = New System.Windows.Forms.ColumnHeader
        Me.clmPluginName = New System.Windows.Forms.ColumnHeader
        Me.fraSettings.SuspendLayout()
        Me.pnlInterface_Other.SuspendLayout()
        Me.fraOther.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.fraPopHotKey.SuspendLayout()
        Me.pnlPlugins.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraSettings
        '
        Me.fraSettings.Controls.Add(Me.pnlInterface_Other)
        Me.fraSettings.Location = New System.Drawing.Point(136, 0)
        Me.fraSettings.Name = "fraSettings"
        Me.fraSettings.Size = New System.Drawing.Size(456, 440)
        Me.fraSettings.TabIndex = 0
        Me.fraSettings.TabStop = False
        '
        'pnlInterface_Other
        '
        Me.pnlInterface_Other.Controls.Add(Me.fraOther)
        Me.pnlInterface_Other.Controls.Add(Me.GroupBox3)
        Me.pnlInterface_Other.Controls.Add(Me.GroupBox2)
        Me.pnlInterface_Other.Controls.Add(Me.fraPopHotKey)
        Me.pnlInterface_Other.Location = New System.Drawing.Point(24, 32)
        Me.pnlInterface_Other.Name = "pnlInterface_Other"
        Me.pnlInterface_Other.Size = New System.Drawing.Size(432, 384)
        Me.pnlInterface_Other.TabIndex = 4
        Me.pnlInterface_Other.Tag = "dcb_hotkeypnl"
        Me.pnlInterface_Other.Visible = False
        '
        'fraOther
        '
        Me.fraOther.Controls.Add(Me.optRightOL)
        Me.fraOther.Controls.Add(Me.optLeftUL)
        Me.fraOther.Controls.Add(Me.lblUListPosition)
        Me.fraOther.Controls.Add(Me.lblSeparator)
        Me.fraOther.Controls.Add(Me.cmdTabStyles)
        Me.fraOther.Controls.Add(Me.lblTasbStyles)
        Me.fraOther.Location = New System.Drawing.Point(8, 216)
        Me.fraOther.Name = "fraOther"
        Me.fraOther.Size = New System.Drawing.Size(392, 80)
        Me.fraOther.TabIndex = 61
        Me.fraOther.TabStop = False
        Me.fraOther.Text = "Разное"
        '
        'optRightOL
        '
        Me.optRightOL.Location = New System.Drawing.Point(176, 48)
        Me.optRightOL.Name = "optRightOL"
        Me.optRightOL.Size = New System.Drawing.Size(64, 16)
        Me.optRightOL.TabIndex = 5
        Me.optRightOL.Text = "Справа"
        '
        'optLeftUL
        '
        Me.optLeftUL.Checked = True
        Me.optLeftUL.Location = New System.Drawing.Point(176, 32)
        Me.optLeftUL.Name = "optLeftUL"
        Me.optLeftUL.Size = New System.Drawing.Size(64, 16)
        Me.optLeftUL.TabIndex = 4
        Me.optLeftUL.TabStop = True
        Me.optLeftUL.Text = "Слева"
        '
        'lblUListPosition
        '
        Me.lblUListPosition.AutoSize = True
        Me.lblUListPosition.Location = New System.Drawing.Point(176, 16)
        Me.lblUListPosition.Name = "lblUListPosition"
        Me.lblUListPosition.Size = New System.Drawing.Size(207, 16)
        Me.lblUListPosition.TabIndex = 3
        Me.lblUListPosition.Text = "Раслоложение списка пользователей:"
        '
        'lblSeparator
        '
        Me.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSeparator.Location = New System.Drawing.Point(168, 11)
        Me.lblSeparator.Name = "lblSeparator"
        Me.lblSeparator.Size = New System.Drawing.Size(2, 64)
        Me.lblSeparator.TabIndex = 2
        '
        'cmdTabStyles
        '
        Me.cmdTabStyles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmdTabStyles.Items.AddRange(New Object() {"(1) Обычные", "(2) Кнопки объёмные", "(3) Кнопки плоские"})
        Me.cmdTabStyles.Location = New System.Drawing.Point(16, 40)
        Me.cmdTabStyles.Name = "cmdTabStyles"
        Me.cmdTabStyles.Size = New System.Drawing.Size(136, 21)
        Me.cmdTabStyles.TabIndex = 1
        '
        'lblTasbStyles
        '
        Me.lblTasbStyles.AutoSize = True
        Me.lblTasbStyles.Location = New System.Drawing.Point(16, 16)
        Me.lblTasbStyles.Name = "lblTasbStyles"
        Me.lblTasbStyles.Size = New System.Drawing.Size(136, 16)
        Me.lblTasbStyles.TabIndex = 0
        Me.lblTasbStyles.Text = "Стиль Закладок каналов"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdWndColor)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(392, 88)
        Me.GroupBox3.TabIndex = 60
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Общие цвета"
        '
        'cmdWndColor
        '
        Me.cmdWndColor.Location = New System.Drawing.Point(8, 16)
        Me.cmdWndColor.Name = "cmdWndColor"
        Me.cmdWndColor.Size = New System.Drawing.Size(160, 24)
        Me.cmdWndColor.TabIndex = 0
        Me.cmdWndColor.Text = "Цвет фона окон"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cmdRestorefont)
        Me.GroupBox2.Controls.Add(Me.cmdCHFont)
        Me.GroupBox2.Controls.Add(Me.lblFontName)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 104)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Шрифт"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(240, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Стили написания пока не поддерживаются"
        '
        'cmdRestorefont
        '
        Me.cmdRestorefont.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRestorefont.Location = New System.Drawing.Point(128, 72)
        Me.cmdRestorefont.Name = "cmdRestorefont"
        Me.cmdRestorefont.Size = New System.Drawing.Size(112, 24)
        Me.cmdRestorefont.TabIndex = 2
        Me.cmdRestorefont.Text = "Восстановить"
        '
        'cmdCHFont
        '
        Me.cmdCHFont.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCHFont.Location = New System.Drawing.Point(8, 72)
        Me.cmdCHFont.Name = "cmdCHFont"
        Me.cmdCHFont.Size = New System.Drawing.Size(112, 24)
        Me.cmdCHFont.TabIndex = 1
        Me.cmdCHFont.Text = "Изменить"
        '
        'lblFontName
        '
        Me.lblFontName.AutoSize = True
        Me.lblFontName.Location = New System.Drawing.Point(8, 16)
        Me.lblFontName.Name = "lblFontName"
        Me.lblFontName.Size = New System.Drawing.Size(93, 16)
        Me.lblFontName.TabIndex = 0
        Me.lblFontName.Text = "Пример надписи"
        '
        'fraPopHotKey
        '
        Me.fraPopHotKey.Controls.Add(Me.pupTxtHotKey)
        Me.fraPopHotKey.Controls.Add(Me.pupChkHotKey)
        Me.fraPopHotKey.Location = New System.Drawing.Point(8, 304)
        Me.fraPopHotKey.Name = "fraPopHotKey"
        Me.fraPopHotKey.Size = New System.Drawing.Size(392, 72)
        Me.fraPopHotKey.TabIndex = 58
        Me.fraPopHotKey.TabStop = False
        Me.fraPopHotKey.Tag = "dcb_hotkeypnl"
        Me.fraPopHotKey.Text = """Горячая"" кнопка"
        '
        'pupTxtHotKey
        '
        Me.pupTxtHotKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pupTxtHotKey.BackColor = System.Drawing.Color.White
        Me.pupTxtHotKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pupTxtHotKey.Location = New System.Drawing.Point(8, 40)
        Me.pupTxtHotKey.Name = "pupTxtHotKey"
        Me.pupTxtHotKey.ReadOnly = True
        Me.pupTxtHotKey.Size = New System.Drawing.Size(376, 20)
        Me.pupTxtHotKey.TabIndex = 1
        Me.pupTxtHotKey.Text = ""
        '
        'pupChkHotKey
        '
        Me.pupChkHotKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pupChkHotKey.Location = New System.Drawing.Point(8, 16)
        Me.pupChkHotKey.Name = "pupChkHotKey"
        Me.pupChkHotKey.Size = New System.Drawing.Size(200, 16)
        Me.pupChkHotKey.TabIndex = 0
        Me.pupChkHotKey.Text = "Использовать ""Горячую кнопку"""
        '
        'trwSettings
        '
        Me.trwSettings.HotTracking = True
        Me.trwSettings.ImageIndex = -1
        Me.trwSettings.Location = New System.Drawing.Point(8, 8)
        Me.trwSettings.Name = "trwSettings"
        Me.trwSettings.SelectedImageIndex = -1
        Me.trwSettings.Size = New System.Drawing.Size(120, 432)
        Me.trwSettings.TabIndex = 1
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdOk.Location = New System.Drawing.Point(392, 448)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(96, 24)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Location = New System.Drawing.Point(496, 448)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 24)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Отмена"
        '
        'pnlPlugins
        '
        Me.pnlPlugins.Controls.Add(Me.GroupBox1)
        Me.pnlPlugins.Controls.Add(Me.lstPlugins)
        Me.pnlPlugins.Location = New System.Drawing.Point(176, 120)
        Me.pnlPlugins.Name = "pnlPlugins"
        Me.pnlPlugins.Size = New System.Drawing.Size(256, 216)
        Me.pnlPlugins.TabIndex = 5
        Me.pnlPlugins.Tag = "dcb_pluginspnl"
        Me.pnlPlugins.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 88)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'lstPlugins
        '
        Me.lstPlugins.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPlugins.FullRowSelect = True
        Me.lstPlugins.GridLines = True
        Me.lstPlugins.Location = New System.Drawing.Point(0, 0)
        Me.lstPlugins.Name = "lstPlugins"
        Me.lstPlugins.Size = New System.Drawing.Size(256, 216)
        Me.lstPlugins.TabIndex = 0
        Me.lstPlugins.View = System.Windows.Forms.View.Details
        '
        'lblOptions
        '
        Me.lblOptions.AutoSize = True
        Me.lblOptions.Location = New System.Drawing.Point(96, 96)
        Me.lblOptions.Name = "lblOptions"
        Me.lblOptions.Size = New System.Drawing.Size(0, 16)
        Me.lblOptions.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 16)
        Me.Label3.TabIndex = 12
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(8, 136)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(152, 16)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Загружать при запуске"
        '
        'lblPluginDeveloper
        '
        Me.lblPluginDeveloper.AutoSize = True
        Me.lblPluginDeveloper.Location = New System.Drawing.Point(96, 80)
        Me.lblPluginDeveloper.Name = "lblPluginDeveloper"
        Me.lblPluginDeveloper.Size = New System.Drawing.Size(0, 16)
        Me.lblPluginDeveloper.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 16)
        Me.Label2.TabIndex = 9
        '
        'lblInterfaceType
        '
        Me.lblInterfaceType.AutoSize = True
        Me.lblInterfaceType.Location = New System.Drawing.Point(96, 64)
        Me.lblInterfaceType.Name = "lblInterfaceType"
        Me.lblInterfaceType.Size = New System.Drawing.Size(0, 16)
        Me.lblInterfaceType.TabIndex = 8
        '
        'lblPluginPath
        '
        Me.lblPluginPath.AutoSize = True
        Me.lblPluginPath.Location = New System.Drawing.Point(96, 48)
        Me.lblPluginPath.Name = "lblPluginPath"
        Me.lblPluginPath.Size = New System.Drawing.Size(0, 16)
        Me.lblPluginPath.TabIndex = 7
        '
        'lblPluginVersion
        '
        Me.lblPluginVersion.AutoSize = True
        Me.lblPluginVersion.Location = New System.Drawing.Point(96, 32)
        Me.lblPluginVersion.Name = "lblPluginVersion"
        Me.lblPluginVersion.Size = New System.Drawing.Size(0, 16)
        Me.lblPluginVersion.TabIndex = 6
        '
        'lblPluginName
        '
        Me.lblPluginName.AutoSize = True
        Me.lblPluginName.Location = New System.Drawing.Point(96, 16)
        Me.lblPluginName.Name = "lblPluginName"
        Me.lblPluginName.Size = New System.Drawing.Size(0, 16)
        Me.lblPluginName.TabIndex = 5
        '
        'lblline1
        '
        Me.lblline1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblline1.Location = New System.Drawing.Point(0, 128)
        Me.lblline1.Name = "lblline1"
        Me.lblline1.Size = New System.Drawing.Size(448, 3)
        Me.lblline1.TabIndex = 4
        '
        'lblInterfType
        '
        Me.lblInterfType.AutoSize = True
        Me.lblInterfType.Location = New System.Drawing.Point(67, 64)
        Me.lblInterfType.Name = "lblInterfType"
        Me.lblInterfType.Size = New System.Drawing.Size(0, 16)
        Me.lblInterfType.TabIndex = 3
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(9, 48)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(0, 16)
        Me.lblPath.TabIndex = 2
        '
        'lblPlgVersion
        '
        Me.lblPlgVersion.AutoSize = True
        Me.lblPlgVersion.Location = New System.Drawing.Point(48, 32)
        Me.lblPlgVersion.Name = "lblPlgVersion"
        Me.lblPlgVersion.Size = New System.Drawing.Size(0, 16)
        Me.lblPlgVersion.TabIndex = 1
        '
        'lblPlgName
        '
        Me.lblPlgName.AutoSize = True
        Me.lblPlgName.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlgName.Location = New System.Drawing.Point(64, 16)
        Me.lblPlgName.Name = "lblPlgName"
        Me.lblPlgName.Size = New System.Drawing.Size(0, 16)
        Me.lblPlgName.TabIndex = 0
        '
        'clmStatus
        '
        Me.clmStatus.Text = "Статус"
        Me.clmStatus.Width = 107
        '
        'clmPath
        '
        Me.clmPath.Text = "Расположение"
        Me.clmPath.Width = 204
        '
        'clmPluginName
        '
        Me.clmPluginName.Text = "Плагин"
        Me.clmPluginName.Width = 129
        '
        'frmSettings
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(594, 479)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.trwSettings)
        Me.Controls.Add(Me.fraSettings)
        Me.Controls.Add(Me.pnlPlugins)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Настройки"
        Me.fraSettings.ResumeLayout(False)
        Me.pnlInterface_Other.ResumeLayout(False)
        Me.fraOther.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.fraPopHotKey.ResumeLayout(False)
        Me.pnlPlugins.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmSettings
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmSettings
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmSettings
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmSettings)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Dim HKAlt As Boolean
    Dim HKControl As Boolean
    Dim HKShift As Boolean
    Dim HKey As Byte
    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pupChkHotKey.Checked = DCB_InterfaceSettings.HKeyUse
        HKey = DCB_InterfaceSettings.HKKey
        HKShift = DCB_InterfaceSettings.HKShift
        HKAlt = DCB_InterfaceSettings.HKAlt
        HKControl = DCB_InterfaceSettings.HKCtrl
        pupTxtHotKey.Text = DCB_InterfaceSettings.HKeyString

        cmdWndColor.BackColor = DCB_ColorSettings.BackChatColor
        ' cmdWndColor.ForeColor = Color.FromArgb(-DCB_ColorSettings.BackChatColor.ToArgb)
        lblFontName.Font = New Font(DCB_InterfaceSettings.ChatFont, DCB_InterfaceSettings.ChatFontSize)

        If DCB_InterfaceSettings.UListPosition = 2 Then
            Me.optRightOL.Checked = True
        Else
            Me.optLeftUL.Checked = True
        End If

        Dim tmp As String
        For Each tmp In cmdTabStyles.Items
            If tmp.StartsWith("(" & DCB_InterfaceSettings.Tabs) Then cmdTabStyles.SelectedItem = tmp : Exit For
        Next
    End Sub


    Private Sub lstPlugins_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            lblPluginName.Text = CType(lstPlugins.SelectedItems(0).Tag, UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_iPluginGetInfo).DCB_GetInfo.INF_NAME
            lblPluginVersion.Text = CType(lstPlugins.SelectedItems(0).Tag, UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_iPluginGetInfo).DCB_GetInfo.INF_VER.ToString
            lblInterfaceType.Text = CType(lstPlugins.SelectedItems(0).Tag, UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_iPluginGetInfo).DCB_GetInfo.INF_PLUGINTYPESTR
            lblPluginDeveloper.Text = CType(lstPlugins.SelectedItems(0).Tag, UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_iPluginGetInfo).DCB_GetInfo.INF_DESCRIPTION
            lblOptions.Text = "DCB_MsgFilter=" & CType(lstPlugins.SelectedItems(0).Tag, UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_iPluginGetInfo).DCB_GetInfo.INF_OPTIONS.DCB_MsgFilter
        Catch
        End Try
    End Sub
    Private Sub CreateTreeNode()
        ' Dim A As TreeNode
        ' Dim A_child As TreeNode
        'A = New TreeNode
        'A_child = New TreeNode
        'A.Text = "Модули"
        'A_child = New TreeNode
        'A_child.Text = "Список доступных модулей"
        'A_child.Tag = "SETT_P_PLG"
        'A.Nodes.Add(A_child)
        '(trwSettings.Nodes.Clear())
        ' trwSettings.Nodes.Add(A)
        'A = New TreeNode
        'A_child = New TreeNode
        'A.Text = "Общее"
        'A_child = New TreeNode
        'A_child.Text = "Hot Key"
        'A_child.Tag = "SETT_HKEY"
        'A.Nodes.Add(A_child)
        ''trwSettings.Nodes.Clear()
        'trwSettings.Nodes.Add(A)

    End Sub

    Private Sub trwSettings_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trwSettings.AfterSelect
        Dim CTL As Control
        For Each CTL In fraSettings.Controls
            If CTL.Tag = e.Node.Tag Then
                If CTL.Dock <> DockStyle.Fill Then CTL.Dock = DockStyle.Fill
                CTL.Visible = True
                CTL.BringToFront()
            End If
        Next
        ' CType(DCSE.DCB_ScriptCommandExecuter("", CType(e.Node, UNI_Plugin.UNI_DChat.DCB_V1.DCB_Controls.DCB_TreeNode).CMD), Panel).Parent = Me.pnlDisplay
    End Sub

    Private Sub pupTxtHotKey_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles pupTxtHotKey.KeyDown
        pupTxtHotKey.Text = ""
        If e.Alt = False And e.Control = False And e.Shift = False Then GoTo Ex
        If e.Alt = True Then pupTxtHotKey.Text = "Alt + "
        If e.Control = True Then pupTxtHotKey.Text = pupTxtHotKey.Text & "Ctrl + "
        If e.Shift = True Then pupTxtHotKey.Text = pupTxtHotKey.Text & "Shift + "
        pupTxtHotKey.Text = pupTxtHotKey.Text & Chr(e.KeyValue)
        HKAlt = e.Alt
        HKShift = e.Shift
        HKControl = e.Control
        HKey = e.KeyCode
Ex:
        e.Handled = True
        e = New System.Windows.Forms.KeyEventArgs(Keys.None)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        DCB_InterfaceSettings.HKeyUse = pupChkHotKey.Checked
        DCB_InterfaceSettings.HKKey = HKey
        DCB_InterfaceSettings.HKShift = HKShift
        DCB_InterfaceSettings.HKAlt = HKAlt
        DCB_InterfaceSettings.HKCtrl = HKControl
        DCB_InterfaceSettings.HKeyString = pupTxtHotKey.Text

        DCB_InterfaceSettings.ChatFont = lblFontName.Font.Name
        DCB_InterfaceSettings.ChatFontSize = lblFontName.Font.Size
        DCB_InterfaceSettings.ChatFontUnderl = lblFontName.Font.Underline
        DCB_InterfaceSettings.ChatFontBold = lblFontName.Font.Bold

        DCB_ColorSettings.BackChatColor = cmdWndColor.BackColor

        DCB_InterfaceSettings.Tabs = cmdTabStyles.SelectedItem.substring(1, 1)

        If optRightOL.Checked = True Then
            DCB_InterfaceSettings.UListPosition = 2
        Else
            DCB_InterfaceSettings.UListPosition = 1
        End If

        DCB_PMGR_CALLPLUGINSCRIPTS("$savesettings$", , True)
    End Sub

    Private Sub cmdCHFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCHFont.Click
        Dim FD As New FontDialog
        FD.Font = lblFontName.Font
        If FD.ShowDialog = DialogResult.Cancel Then Exit Sub
        Dim FNT As Font
        Dim FS As FontStyle
        If FD.Font.Bold = True Then FS = FontStyle.Bold
        If FD.Font.Underline = True Then FS += FontStyle.Italic
        lblFontName.Font = New Font(FD.Font.Name, FD.Font.Size, FS)
    End Sub

    Private Sub cmdRestorefont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestorefont.Click
        lblFontName.Font = New Font(TextBox.DefaultFont.Name, TextBox.DefaultFont.Size)
    End Sub

    Private Sub cmdWndColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWndColor.Click
        Dim CD As New ColorDialog
        CD.Color = cmdWndColor.BackColor
        If CD.ShowDialog = DialogResult.Cancel Then Exit Sub
        cmdWndColor.BackColor = CD.Color
        'cmdWndColor.ForeColor = Color.FromArgb(Color.ToArgb)
    End Sub
End Class


