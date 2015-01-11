Public Class frmAddCHL
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCHLName As System.Windows.Forms.Label
    Friend WithEvents txtCHLName As System.Windows.Forms.TextBox
    Friend WithEvents chkAutoJoin As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseSnd As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAddCHL As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.chkUseAlarm = New System.Windows.Forms.CheckBox
        Me.chkUseSnd = New System.Windows.Forms.CheckBox
        Me.chkAutoJoin = New System.Windows.Forms.CheckBox
        Me.txtCHLName = New System.Windows.Forms.TextBox
        Me.lblCHLName = New System.Windows.Forms.Label
        Me.cmdAddCHL = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPass)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.chkUseAlarm)
        Me.GroupBox1.Controls.Add(Me.chkUseSnd)
        Me.GroupBox1.Controls.Add(Me.chkAutoJoin)
        Me.GroupBox1.Controls.Add(Me.txtCHLName)
        Me.GroupBox1.Controls.Add(Me.lblCHLName)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 224)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Параметры"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Location = New System.Drawing.Point(16, 136)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(47, 16)
        Me.lblPass.TabIndex = 6
        Me.lblPass.Text = "Пароль:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(16, 152)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(320, 20)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.Text = ""
        '
        'chkUseAlarm
        '
        Me.chkUseAlarm.Location = New System.Drawing.Point(16, 104)
        Me.chkUseAlarm.Name = "chkUseAlarm"
        Me.chkUseAlarm.Size = New System.Drawing.Size(320, 24)
        Me.chkUseAlarm.TabIndex = 4
        Me.chkUseAlarm.Text = "Включить оповещение"
        '
        'chkUseSnd
        '
        Me.chkUseSnd.Location = New System.Drawing.Point(16, 88)
        Me.chkUseSnd.Name = "chkUseSnd"
        Me.chkUseSnd.Size = New System.Drawing.Size(320, 16)
        Me.chkUseSnd.TabIndex = 3
        Me.chkUseSnd.Text = "Включить звуки"
        '
        'chkAutoJoin
        '
        Me.chkAutoJoin.Location = New System.Drawing.Point(16, 64)
        Me.chkAutoJoin.Name = "chkAutoJoin"
        Me.chkAutoJoin.Size = New System.Drawing.Size(320, 24)
        Me.chkAutoJoin.TabIndex = 2
        Me.chkAutoJoin.Text = "Заходить при подключении"
        '
        'txtCHLName
        '
        Me.txtCHLName.Location = New System.Drawing.Point(16, 32)
        Me.txtCHLName.Name = "txtCHLName"
        Me.txtCHLName.Size = New System.Drawing.Size(320, 20)
        Me.txtCHLName.TabIndex = 1
        Me.txtCHLName.Text = ""
        '
        'lblCHLName
        '
        Me.lblCHLName.AutoSize = True
        Me.lblCHLName.Location = New System.Drawing.Point(8, 16)
        Me.lblCHLName.Name = "lblCHLName"
        Me.lblCHLName.Size = New System.Drawing.Size(99, 16)
        Me.lblCHLName.TabIndex = 0
        Me.lblCHLName.Text = "Название канала:"
        '
        'cmdAddCHL
        '
        Me.cmdAddCHL.Location = New System.Drawing.Point(128, 240)
        Me.cmdAddCHL.Name = "cmdAddCHL"
        Me.cmdAddCHL.Size = New System.Drawing.Size(120, 24)
        Me.cmdAddCHL.TabIndex = 1
        Me.cmdAddCHL.Text = "Добавить/изменить"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(256, 240)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Отмена"
        '
        'frmAddCHL
        '
        Me.AcceptButton = Me.cmdAddCHL
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(354, 271)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAddCHL)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddCHL"
        Me.Text = "Добавление/Изменение канала в списке избранного"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmAddCHL
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmAddCHL
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmAddCHL
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmAddCHL)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Private Sub cmdAddCHL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddCHL.Click
        If txtCHLName.Text = "" Then
            Windows.Forms.MessageBox.Show("Вы не указали имя канала", "DChat", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Обновляем список каналов, сохраняем и загружаем
        Dim Tmp As IRC_CHLFavorite
        Dim NewCollection As New Collection
        Dim AddOk As Boolean = False
        For Each Tmp In IRC_CHLFavoritesCollection
            If Tmp.CHLName = txtCHLName.Text Then
                NewCollection.Add(New IRC_CHLFavorite(txtCHLName.Text, , chkAutoJoin.Checked, chkUseSnd.Checked, chkUseAlarm.Checked, txtPassword.Text))
                AddOk = True
            Else
                NewCollection.Add(Tmp)
            End If
        Next

        If AddOk = False Then
            NewCollection.Add(New IRC_CHLFavorite(txtCHLName.Text, , chkAutoJoin.Checked, chkUseSnd.Checked, chkUseAlarm.Checked, txtPassword.Text))
        End If
        IRC_CHLFavoritesCollection = NewCollection
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_savefavoriteslist")
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_loadfavoriteslist")
        Me.Close()
    End Sub

    Private Sub frmAddCHL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
  
End Class
