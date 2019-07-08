Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Public Class LockerPanel
    Inherits Panel
    ' Methods
    Public Sub New()
        AddHandler MyBase.Click, New EventHandler(AddressOf Me.LockerPanel_Click)
        AddHandler MyBase.ControlAdded, New ControlEventHandler(AddressOf Me.LockerPanel_ControlAdded)
        AddHandler MyBase.DoubleClick, New EventHandler(AddressOf Me.LockerPanel_DoubleClick)
        AddHandler MyBase.Resize, New EventHandler(AddressOf Me.LockerPanel_Resize)
        Me.Timer_0 = New Timer
        Me.toolTip_0 = New ToolTip
        Me.memoryStream_0 = New MemoryStream(New Byte() {&H89, 80, &H4E, &H47, 13, 10, &H1A, 10, 0, 0, 0, 13, &H49, &H48, &H44, &H52, 0, 0, 0, &H19, 0, 0, 0, &H19, 8, 2, 0, 0, 0, &H4B, &H8B, &H12, &H34, 0, 0, 0, 1, &H73, &H52, &H47, &H42, 0, &HAE, &HCE, &H1C, &HE9, 0, 0, 0, 4, &H67, &H41, &H4D, &H41, 0, 0, &HB1, &H8F, 11, &HFC, &H61, 5, 0, 0, 0, &H20, &H63, &H48, &H52, &H4D, 0, 0, &H7A, &H26, 0, 0, &H80, &H84, 0, 0, 250, 0, 0, 0, &H80, &HE8, 0, 0, &H75, &H30, 0, 0, &HEA, &H60, 0, 0, &H3A, &H98, 0, 0, &H17, &H70, &H9C, &HBA, &H51, 60, 0, 0, 0, 50, &H49, &H44, &H41, &H54, &H48, &H4B, &H63, &HFC, &HCF, &H40, &H3D, &H40, &H2D, &HB3, &H40, 230, 140, &H9A, &H45, &H7C, &HBC, 140, &H86, &H17, &HF1, &H61, 5, &H52, &H39, &H1A, &H5E, &HA3, &HE1, &H85, 30, 2, &HA3, &H69, &H62, &H34, &H4D, &HE0, &H48, &H13, &HC0, &HA4, &H41, &H15, 4, 0, &H7F, &H57, &H47, &HBA, &H56, &HFF, &HFB, &HE2, 0, 0, 0, 0, &H49, &H45, &H4E, &H44, &HAE, &H42, &H60, 130})
        Me.string_0 = "0000"
        Me.color_0 = Color.Blue
        Me.color_1 = Color.White
        MyBase.SuspendLayout
        Me.Button1 = New Button
        Me.Button1.Size = New Size(&H16, &H16)
        Me.Button1.BackColor = Color.Blue
        Me.Button1.ForeColor = Color.White
        Me.Button1.Text = "L"
        Me.Button1.Location = New Point((MyBase.Width - &H1B), (MyBase.Height - &H1B))
        MyBase.SetStyle((ControlStyles.OptimizedDoubleBuffer Or (ControlStyles.SupportsTransparentBackColor Or (ControlStyles.ResizeRedraw Or ControlStyles.ContainerControl))), True)
        MyBase.DoubleBuffered = True
        MyBase.BackColor = Color.SteelBlue
        Me.DoubleBuffered = True
        MyBase.BorderStyle = BorderStyle.Fixed3D
        Me.MinimumSize = New Size(&H1B, &H1B)
        MyBase.Size = New Size(200, 200)
        Me.AllowDrop = True
        MyBase.Name = "LockerPanel"
        Me.picBox = New PictureBox
        Me.picBox.Size = MyBase.Size
        Me.picBox.Dock = DockStyle.Fill
        Me.picBox.BackColor = Color.Transparent
        Me.picBox.Visible = False
        MyBase.Controls.Add(Me.picBox)
        MyBase.Controls.Add(Me.Button1)
        Me.passwordForm = New Form
        Me.passwordForm.Name = "Password"
        Me.passwordForm.Text = "Admin Password"
        Me.passwordForm.Size = New Size(220, &H35)
        Me.passwordForm.StartPosition = FormStartPosition.CenterScreen
        Me.passwordForm.MinimizeBox = False
        Me.passwordForm.MaximizeBox = False
        Me.passwordTextbox = New TextBox
        Me.passwordTextbox.Dock = DockStyle.Fill
        Me.passwordTextbox.PasswordChar = "*"c
        Me.passwordForm.Controls.Add(Me.passwordTextbox)
        Me.Timer_0.Interval = 500
        Me.Timer_0.Enabled = False
        MyBase.ResumeLayout(False)
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If (Me.passwordForm > Nothing) Then
                    Me.passwordForm.Dispose
                End If
                If (Me.memoryStream_0 > Nothing) Then
                    Me.memoryStream_0.Dispose
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub LockerPanel_Click(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Focus
    End Sub

    Private Sub LockerPanel_ControlAdded(ByVal sender As Object, ByVal e As ControlEventArgs)
        Me.picBox.SendToBack
    End Sub

    Private Sub LockerPanel_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        If (((Class2.smethod_0.Keyboard.CtrlKeyDown AndAlso Class2.smethod_0.Keyboard.AltKeyDown) AndAlso Not Me.bool_3) AndAlso Not Me.Button1.Enabled) Then
            Me.passwordForm.ShowDialog
        End If
    End Sub

    Private Sub LockerPanel_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Me.Button1.Location = New Point((MyBase.Width - &H1B), (MyBase.Height - &H1B))
    End Sub

    Private Sub method_0(ByVal sender As Object, ByVal e As EventArgs)
        If Not Me.bool_1 Then
            Me.method_4
        Else
            Me.passwordForm.ShowDialog
        End If
    End Sub

    Private Sub method_1(ByVal sender As Object, ByVal e As KeyEventArgs)
        If ((e.KeyCode = Keys.Enter) AndAlso (Me.passwordTextbox.Text <> Me.string_0)) Then
            Dim numRef As Integer
            MessageBox.Show("Incorrect Password!")
            Me.passwordTextbox.Text = ""
            numRef = CInt(AddressOf Me.int_0) = (numRef + 1)
            If (Me.int_0 = 3) Then
                Me.Button1.Enabled = False
                Me.Timer_0.Enabled = True
                Me.passwordForm.Hide
                Me.int_0 = 0
            End If
        ElseIf ((e.KeyCode = Keys.Enter) AndAlso (Me.passwordTextbox.Text = Me.string_0)) Then
            Me.int_0 = 0
            Me.passwordForm.Hide
            Me.passwordTextbox.Text = ""
            Me.Button1.Enabled = True
            Me.method_5
        End If
    End Sub

    Private Sub method_2(ByVal sender As Object, ByVal e As EventArgs)
        If (((Class2.smethod_0.Keyboard.CtrlKeyDown AndAlso Class2.smethod_0.Keyboard.AltKeyDown) AndAlso Not Me.bool_3) AndAlso Not Me.Button1.Enabled) Then
            Me.passwordForm.ShowDialog
        End If
    End Sub

    Private Sub method_3(ByVal sender As Object, ByVal e As EventArgs)
        If Me.bool_2 Then
            Me.Button1.BackColor = Color.DarkGoldenrod
            Me.bool_2 = False
        Else
            Me.Button1.BackColor = Color.Red
            Me.bool_2 = True
        End If
    End Sub

    Private Sub method_4()
        If Me.bool_5 Then
            Dim enumerator As IEnumerator
            Try
                enumerator = MyBase.Controls.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As Control = DirectCast(enumerator.Current, Control)
                    If ((Not current Is Me.Button1) AndAlso (Not current Is Me.picBox)) Then
                        current.Enabled = False
                    End If
                    Me.Button1.BringToFront
                    Me.Button1.BackColor = Color.DarkGoldenrod
                    Me.Button1.Text = "U"
                    Me.bool_1 = True
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator, IDisposable).Dispose
                End If
            End Try
        Else
            Me.picBox.Visible = True
            Me.picBox.BringToFront
            Me.Button1.BringToFront
            If Not Me.bool_0 Then
                Me.image_0 = Me.BackgroundImage
                Me.imageLayout_0 = Me.BackgroundImageLayout
                Me.bool_0 = True
            End If
            Me.BackgroundImage = New Bitmap(Me.memoryStream_0)
            Me.BackgroundImageLayout = ImageLayout.Tile
            Me.Button1.BackColor = Color.DarkGoldenrod
            Me.Button1.Text = "U"
            Me.bool_1 = True
        End If
    End Sub

    Private Sub method_5()
        If Me.bool_5 Then
            Dim enumerator As IEnumerator
            Try
                enumerator = MyBase.Controls.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As Control = DirectCast(enumerator.Current, Control)
                    If ((Not current Is Me.Button1) AndAlso (Not current Is Me.picBox)) Then
                        current.Enabled = True
                    End If
                    Me.Button1.BringToFront
                    Me.Button1.BackColor = Color.Blue
                    Me.Button1.Text = "L"
                    Me.Timer_0.Enabled = False
                    Me.bool_1 = False
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator, IDisposable).Dispose
                End If
            End Try
        Else
            Me.picBox.SendToBack
            Me.picBox.Visible = False
            Me.BackgroundImage = Me.image_0
            Me.BackgroundImageLayout = Me.imageLayout_0
            Me.Button1.BackColor = Color.Blue
            Me.Button1.Text = "L"
            Me.Timer_0.Enabled = False
            Me.bool_1 = False
        End If
    End Sub

    Private Sub method_6(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.Button1.Text = "L") Then
            Me.toolTip_0.SetToolTip(Me.Button1, "Lock")
        Else
            Me.toolTip_0.SetToolTip(Me.Button1, "Unlock")
        End If
    End Sub


    ' Properties
    Private Overridable Property Timer_0 As Timer
        <CompilerGenerated> _
        Get
            Return Me.timer_0
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Timer)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.method_3)
            Dim timer As Timer = Me.timer_0
            If (Not timer Is Nothing) Then
                RemoveHandler timer.Tick, handler
            End If
            Me.timer_0 = value
            timer = Me.timer_0
            If (Not timer Is Nothing) Then
                AddHandler timer.Tick, handler
            End If
        End Set
    End Property

    Private Overridable Property Button1 As Button
        <CompilerGenerated> _
        Get
            Return Me.button_0
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Button)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.method_0)
            Dim handler2 As EventHandler = New EventHandler(AddressOf Me.method_6)
            Dim button As Button = Me.button_0
            If (Not button Is Nothing) Then
                RemoveHandler button.Click, handler
                RemoveHandler button.MouseHover, handler2
            End If
            Me.button_0 = value
            button = Me.button_0
            If (Not button Is Nothing) Then
                AddHandler button.Click, handler
                AddHandler button.MouseHover, handler2
            End If
        End Set
    End Property

    Private Overridable Property passwordForm As Form
        <CompilerGenerated> _
        Get
            Return Me._Password
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Form)
            Me._Password = value
        End Set
    End Property

    Private Overridable Property passwordTextbox As TextBox
        <CompilerGenerated> _
        Get
            Return Me.textBox_0
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As TextBox)
            Dim handler As KeyEventHandler = New KeyEventHandler(AddressOf Me.method_1)
            Dim box As TextBox = Me.textBox_0
            If (Not box Is Nothing) Then
                RemoveHandler box.KeyDown, handler
            End If
            Me.textBox_0 = value
            box = Me.textBox_0
            If (Not box Is Nothing) Then
                AddHandler box.KeyDown, handler
            End If
        End Set
    End Property

    Private Overridable Property picBox As PictureBox
        <CompilerGenerated> _
        Get
            Return Me.pictureBox_0
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As PictureBox)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.method_2)
            Dim box As PictureBox = Me.pictureBox_0
            If (Not box Is Nothing) Then
                RemoveHandler box.DoubleClick, handler
            End If
            Me.pictureBox_0 = value
            box = Me.pictureBox_0
            If (Not box Is Nothing) Then
                AddHandler box.DoubleClick, handler
            End If
        End Set
    End Property

    <Description("Enter the password that will be used to unlock the panel."), DefaultValue("0000")> _
    Public Property LP_Password As String
        Get
            Return Me.string_0
        End Get
        Set(ByVal value As String)
            If (Me.string_0 <> value) Then
                Me.string_0 = value
                MyBase.Invalidate
            End If
        End Set
    End Property

    <DefaultValue(False), Description("Enable controlled locking of the panel (by a PLC or another control)."), Browsable(True)> _
    Public Property LP_ControlledLock As Boolean
        Get
            Return Me.bool_3
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_3 <> value) Then
                Me.bool_3 = value
                If Me.bool_3 Then
                    Me.Button1.Enabled = False
                Else
                    Me.Button1.Enabled = True
                End If
                MyBase.Invalidate
            End If
        End Set
    End Property

    <Description("Panel locked by a PLC or another control."), DefaultValue(False), Browsable(False)> _
    Public Property Value As Boolean
        Get
            Return Me.bool_4
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_4 <> value) Then
                Me.bool_4 = value
                If (Me.bool_4 AndAlso Me.bool_3) Then
                    Me.method_4
                End If
                If (Not Me.bool_4 AndAlso Me.bool_3) Then
                    Me.method_5
                End If
                MyBase.Invalidate
            End If
        End Set
    End Property

    <DefaultValue(False), Browsable(True), Description("Leave panel controls visible when locked.")> _
    Public Property LP_VisibleOnLock As Boolean
        Get
            Return Me.bool_5
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_5 <> value) Then
                Me.bool_5 = value
                MyBase.Invalidate
            End If
        End Set
    End Property

    <DefaultValue(GetType(Color), "Blue"), Description("Button back color."), Browsable(True)> _
    Public Property LP_ButtonBackColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (Me.color_0 <> value) Then
                Me.color_0 = value
                Me.Button1.BackColor = Me.color_0
                MyBase.Invalidate
            End If
        End Set
    End Property

    <DefaultValue(GetType(Color), "White"), Description("Button fore color."), Browsable(True)> _
    Public Property LP_ButtonForeColor As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            If (Me.color_1 <> value) Then
                Me.color_1 = value
                Me.Button1.ForeColor = Me.color_1
                MyBase.Invalidate
            End If
        End Set
    End Property

    Public Overrides Property [Text] As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            If (String.Compare(MyBase.Text, value, StringComparison.CurrentCulture) <> 0) Then
                MyBase.Text = value
                MyBase.Invalidate
            End If
        End Set
    End Property


    ' Fields
    <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("tmr")> _
    Private timer_0 As Timer
    <DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("Button1"), CompilerGenerated> _
    Private button_0 As Button
    <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("passwordForm")> _
    Private _Password As Form
    <AccessedThroughProperty("passwordTextbox"), CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private textBox_0 As TextBox
    <CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("picBox")> _
    Private pictureBox_0 As PictureBox
    Private image_0 As Image
    Private imageLayout_0 As ImageLayout
    Private bool_0 As Boolean
    Private bool_1 As Boolean
    Private bool_2 As Boolean
    Private int_0 As Integer
    Private toolTip_0 As ToolTip
    Private memoryStream_0 As MemoryStream
    Private string_0 As String
    Private bool_3 As Boolean
    Private bool_4 As Boolean
    Private bool_5 As Boolean
    Private color_0 As Color
    Private color_1 As Color
End Class

