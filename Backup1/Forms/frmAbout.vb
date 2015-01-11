Public Class frmAbout
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
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents picDC As System.Windows.Forms.PictureBox
    Friend WithEvents lblDCname As System.Windows.Forms.Label
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents txtVerHistory As System.Windows.Forms.RichTextBox
    Friend WithEvents tbsVersionHistory As System.Windows.Forms.TabPage
    Friend WithEvents tbsModules As System.Windows.Forms.TabPage
    Friend WithEvents cmhMName As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstPlugins As System.Windows.Forms.ListView
    Friend WithEvents cmdI As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAbout))
        Me.cmdClose = New System.Windows.Forms.Button
        Me.picDC = New System.Windows.Forms.PictureBox
        Me.lblDCname = New System.Windows.Forms.Label
        Me.lblCompanyName = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tbsVersionHistory = New System.Windows.Forms.TabPage
        Me.txtVerHistory = New System.Windows.Forms.RichTextBox
        Me.tbsModules = New System.Windows.Forms.TabPage
        Me.lstPlugins = New System.Windows.Forms.ListView
        Me.cmhMName = New System.Windows.Forms.ColumnHeader
        Me.cmdDescription = New System.Windows.Forms.ColumnHeader
        Me.cmdI = New System.Windows.Forms.ColumnHeader
        Me.TabControl1.SuspendLayout()
        Me.tbsVersionHistory.SuspendLayout()
        Me.tbsModules.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(456, 280)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(96, 24)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Закрыть"
        '
        'picDC
        '
        Me.picDC.Image = CType(resources.GetObject("picDC.Image"), System.Drawing.Image)
        Me.picDC.Location = New System.Drawing.Point(0, 0)
        Me.picDC.Name = "picDC"
        Me.picDC.Size = New System.Drawing.Size(32, 32)
        Me.picDC.TabIndex = 1
        Me.picDC.TabStop = False
        '
        'lblDCname
        '
        Me.lblDCname.AutoSize = True
        Me.lblDCname.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblDCname.Location = New System.Drawing.Point(40, 0)
        Me.lblDCname.Name = "lblDCname"
        Me.lblDCname.Size = New System.Drawing.Size(71, 27)
        Me.lblDCname.TabIndex = 2
        Me.lblDCname.Text = "DChat"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Location = New System.Drawing.Point(48, 24)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(117, 16)
        Me.lblCompanyName.TabIndex = 3
        Me.lblCompanyName.Text = "DZFS.NET 2000-2005"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Created by Garikk"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbsVersionHistory)
        Me.TabControl1.Controls.Add(Me.tbsModules)
        Me.TabControl1.Location = New System.Drawing.Point(8, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(544, 216)
        Me.TabControl1.TabIndex = 5
        '
        'tbsVersionHistory
        '
        Me.tbsVersionHistory.Controls.Add(Me.txtVerHistory)
        Me.tbsVersionHistory.Location = New System.Drawing.Point(4, 22)
        Me.tbsVersionHistory.Name = "tbsVersionHistory"
        Me.tbsVersionHistory.Size = New System.Drawing.Size(536, 190)
        Me.tbsVersionHistory.TabIndex = 0
        Me.tbsVersionHistory.Text = "История версий"
        '
        'txtVerHistory
        '
        Me.txtVerHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVerHistory.Location = New System.Drawing.Point(0, 0)
        Me.txtVerHistory.Name = "txtVerHistory"
        Me.txtVerHistory.ReadOnly = True
        Me.txtVerHistory.Size = New System.Drawing.Size(536, 190)
        Me.txtVerHistory.TabIndex = 0
        Me.txtVerHistory.Text = ""
        '
        'tbsModules
        '
        Me.tbsModules.Controls.Add(Me.lstPlugins)
        Me.tbsModules.Location = New System.Drawing.Point(4, 22)
        Me.tbsModules.Name = "tbsModules"
        Me.tbsModules.Size = New System.Drawing.Size(536, 190)
        Me.tbsModules.TabIndex = 1
        Me.tbsModules.Text = "Модули"
        '
        'lstPlugins
        '
        Me.lstPlugins.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cmhMName, Me.cmdDescription, Me.cmdI})
        Me.lstPlugins.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPlugins.Location = New System.Drawing.Point(0, 0)
        Me.lstPlugins.Name = "lstPlugins"
        Me.lstPlugins.Size = New System.Drawing.Size(536, 190)
        Me.lstPlugins.TabIndex = 0
        Me.lstPlugins.View = System.Windows.Forms.View.Details
        '
        'cmhMName
        '
        Me.cmhMName.Text = "Название:"
        Me.cmhMName.Width = 95
        '
        'cmdDescription
        '
        Me.cmdDescription.Text = "Описание"
        Me.cmdDescription.Width = 334
        '
        'cmdI
        '
        Me.cmdI.Text = "Интерфейс"
        Me.cmdI.Width = 88
        '
        'frmAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(554, 311)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCompanyName)
        Me.Controls.Add(Me.lblDCname)
        Me.Controls.Add(Me.picDC)
        Me.Controls.Add(Me.cmdClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "О программе"
        Me.TabControl1.ResumeLayout(False)
        Me.tbsVersionHistory.ResumeLayout(False)
        Me.tbsModules.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmAbout
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmAbout
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmAbout()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmAbout)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDCname.Text = Application.ProductVersion
        Try
            txtVerHistory.LoadFile(Application.StartupPath & "\What's New.txt", RichTextBoxStreamType.PlainText)
        Catch Ex As Exception
            txtVerHistory.Text = "What's New.txt not found :("
        End Try
        ' Загрузка списка плагинов
        Dim R As UNI_Plugin.UNI_DChat.DCB_Universal.DCB_iPlugin
        Dim Z As UNI_Plugin.UNI_DChat.DCB_Universal.DCB_UNI_PluginInfo
        For Each R In DCB_Plugins.GetMainCollection.Values
            Z = R.UNI_GetInfo
            Dim LNI As New ListViewItem
            LNI.Text = Z.INF_NAME & " (" & Z.INF_CMDEXEC & ")"
            LNI.SubItems.Add(Z.INF_DESCRIPTION)
            LNI.SubItems.Add(Z.INF_PLUGINTYPESTR)
            lstPlugins.Items.Add(LNI)
        Next
    End Sub
End Class
