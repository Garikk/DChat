Public Class frmAddFriend
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
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents fraAddFriend As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lstAltNames As System.Windows.Forms.ListBox
    Friend WithEvents cmdAddAltNick As System.Windows.Forms.Button
    Friend WithEvents cmdDelAltNick As System.Windows.Forms.Button
    Friend WithEvents chkAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.fraAddFriend = New System.Windows.Forms.GroupBox
        Me.chkAlarm = New System.Windows.Forms.CheckBox
        Me.cmdDelAltNick = New System.Windows.Forms.Button
        Me.cmdAddAltNick = New System.Windows.Forms.Button
        Me.lstAltNames = New System.Windows.Forms.ListBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.fraAddFriend.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(200, 240)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(120, 24)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "Добавить/Изменить"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(328, 240)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 24)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Отмена"
        '
        'fraAddFriend
        '
        Me.fraAddFriend.Controls.Add(Me.Label1)
        Me.fraAddFriend.Controls.Add(Me.chkAlarm)
        Me.fraAddFriend.Controls.Add(Me.cmdDelAltNick)
        Me.fraAddFriend.Controls.Add(Me.cmdAddAltNick)
        Me.fraAddFriend.Controls.Add(Me.lstAltNames)
        Me.fraAddFriend.Controls.Add(Me.lblName)
        Me.fraAddFriend.Controls.Add(Me.txtName)
        Me.fraAddFriend.Location = New System.Drawing.Point(0, 0)
        Me.fraAddFriend.Name = "fraAddFriend"
        Me.fraAddFriend.Size = New System.Drawing.Size(424, 232)
        Me.fraAddFriend.TabIndex = 2
        Me.fraAddFriend.TabStop = False
        Me.fraAddFriend.Text = "Параметры"
        '
        'chkAlarm
        '
        Me.chkAlarm.Location = New System.Drawing.Point(8, 56)
        Me.chkAlarm.Name = "chkAlarm"
        Me.chkAlarm.Size = New System.Drawing.Size(192, 32)
        Me.chkAlarm.TabIndex = 5
        Me.chkAlarm.Text = "Оповещение, если вошёл в чат"
        '
        'cmdDelAltNick
        '
        Me.cmdDelAltNick.Location = New System.Drawing.Point(336, 64)
        Me.cmdDelAltNick.Name = "cmdDelAltNick"
        Me.cmdDelAltNick.Size = New System.Drawing.Size(80, 24)
        Me.cmdDelAltNick.TabIndex = 4
        Me.cmdDelAltNick.Text = "Удалить"
        '
        'cmdAddAltNick
        '
        Me.cmdAddAltNick.Location = New System.Drawing.Point(336, 32)
        Me.cmdAddAltNick.Name = "cmdAddAltNick"
        Me.cmdAddAltNick.Size = New System.Drawing.Size(80, 24)
        Me.cmdAddAltNick.TabIndex = 3
        Me.cmdAddAltNick.Text = "Добавить"
        '
        'lstAltNames
        '
        Me.lstAltNames.Location = New System.Drawing.Point(200, 32)
        Me.lstAltNames.Name = "lstAltNames"
        Me.lstAltNames.Size = New System.Drawing.Size(128, 186)
        Me.lstAltNames.Sorted = True
        Me.lstAltNames.TabIndex = 2
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(8, 16)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(106, 16)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Имя пользователя:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(8, 32)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(184, 20)
        Me.txtName.TabIndex = 0
        Me.txtName.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(200, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Ники пользователя"
        '
        'frmAddFriend
        '
        Me.AcceptButton = Me.cmdAdd
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(426, 271)
        Me.Controls.Add(Me.fraAddFriend)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddFriend"
        Me.Text = "Изменение списка друзей"
        Me.fraAddFriend.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region " Form Access "
    Private Shared m_vb6FormDefInstance As frmAddFriend
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmAddFriend
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmAddFriend
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As frmAddFriend)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    Private Sub cmdAddAltNick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddAltNick.Click
        Dim NewNick As String
        NewNick = InputBox("Введите имя")
        If NewNick = "" Then Exit Sub
        lstAltNames.Items.Add(NewNick)
    End Sub

    Private Sub cmdDelAltNick_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelAltNick.Click
        If lstAltNames.SelectedItem Is Nothing Then Exit Sub
        If Windows.Forms.MessageBox.Show("Удалить выделенное имя?", "DChat", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            lstAltNames.Items.Remove(lstAltNames.SelectedItem)
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If lstAltNames.Items.Count = 0 Then MsgBox("Задайте список ников пользователя", MsgBoxStyle.Information) : Exit Sub
        ' Обновляем список друзей
        Dim Tmp As IRC_Friend
        Dim NewCollection As New Collection
        Dim AddOk As Boolean = False
        Dim Altnicks As String
        Dim TT As String
        For Each TT In lstAltNames.Items
            Altnicks += TT & " "
        Next
        Altnicks = Altnicks.Trim
        For Each Tmp In IRC_FriendsCollection
            If Tmp.Nick = txtName.Text Then
                NewCollection.Add(New IRC_Friend(txtName.Text, Altnicks, Me.chkAlarm.Checked))
                AddOk = True
            Else
                NewCollection.Add(Tmp)
            End If
        Next

        If AddOk = False Then
            NewCollection.Add(New IRC_Friend(txtName.Text, Altnicks, Me.chkAlarm.Checked))
        End If
        IRC_FriendsCollection = NewCollection
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_savefriendslist")
        DCSE.ExecScriptCommand(IRC_INF.INF_CMDEXEC, "%PID% irc_loadfriendslist")
        Me.Close()
    End Sub
End Class
