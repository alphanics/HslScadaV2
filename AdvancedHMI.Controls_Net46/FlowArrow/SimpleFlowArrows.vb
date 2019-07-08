Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class SimpleFlowArrows
    Inherits Control
    Private ulong_0 As ULong()

    Private float_0 As Single

    Private float_1 As Single

    Private arrowDir_0 As SimpleFlowArrows.ArrowDir

    Private color_0 As Color

    Private bool_0 As Boolean

    Private int_0 As Integer

    Private bool_1 As Boolean

    <Browsable(True)>
    <DefaultValue(0)>
    <Description("Select arrow direction (Right, Left, Up, Down).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ArrowDirection As SimpleFlowArrows.ArrowDir
        Get
            Return Me.arrowDir_0
        End Get
        Set(ByVal value As SimpleFlowArrows.ArrowDir)
            Dim flag As Boolean
            If (Me.arrowDir_0 <> value) Then
                Me.float_0 = CSng(MyBase.Width)
                Me.float_1 = CSng(MyBase.Height)
                If ((Me.arrowDir_0 = SimpleFlowArrows.ArrowDir.Right OrElse Me.arrowDir_0 = SimpleFlowArrows.ArrowDir.Left) AndAlso value <> SimpleFlowArrows.ArrowDir.Right) Then
                    If (value = SimpleFlowArrows.ArrowDir.Left) Then
                        GoTo Label3
                    End If
                    flag = True
                    GoTo Label0
                End If
Label3:
                If (Me.arrowDir_0 <> SimpleFlowArrows.ArrowDir.Up) Then
                    If (Me.arrowDir_0 = SimpleFlowArrows.ArrowDir.Down) Then
                        GoTo Label4
                    End If
                    flag = False
                    GoTo Label0
                End If
Label4:
                flag = If(value = SimpleFlowArrows.ArrowDir.Up, False, value <> SimpleFlowArrows.ArrowDir.Down)
Label0:
                If (Not flag) Then
                    Me.arrowDir_0 = value
                Else
                    Me.arrowDir_0 = value
                    MyBase.Width = CInt(Math.Round(CDbl(Me.float_1)))
                    MyBase.Height = CInt(Math.Round(CDbl(Me.float_0)))
                    Me.SimpleFlowArrows_Resize(Me, Nothing)
                End If
            End If
            MyBase.Invalidate()
        End Set
    End Property

    Private Property BlinkTimer As Timer


    <Browsable(True)>
    <DefaultValue(500)>
    <Description("LED blinking interval in milliseconds.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property LED_BlinkInterval As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (Not Versioned.IsNumeric(value)) Then
                value = 500
            End If
            If (value < 0) Then
                value = 500
            End If
            If (Me.int_0 <> value) Then
                Me.int_0 = value
                Me.BlinkTimer.Interval = Me.int_0
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Description("Constant value used to maintain the ratio between width and height.")>
    <RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property SizeScaleCoefficient As Single
        Get
            Return 0.7154471!
        End Get
    End Property

    <Browsable(True)>
    <DefaultValue(False)>
    <Description("Indicates whether there is a flow.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Value As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_0 <> value) Then
                Me.bool_0 = value
                If (Not Me.bool_0) Then
                    Me.BlinkTimer.Enabled = False
                    Me.ForeColor = Me.color_0
                Else
                    Me.color_0 = Me.ForeColor
                    Me.BlinkTimer.Enabled = True
                End If
            End If
            MyBase.Invalidate()
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        AddHandler MyBase.Click, New EventHandler(AddressOf Me.SimpleFlowArrows_Click)
        AddHandler MyBase.Resize, New EventHandler(AddressOf Me.SimpleFlowArrows_Resize)
        ReDim Me.ulong_0(4)
        Me.arrowDir_0 = SimpleFlowArrows.ArrowDir.Right
        Me.int_0 = 500
        MyBase.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.Transparent
        MyBase.Size = New System.Drawing.Size(123, 88)
        Me.ulong_0(0) = Convert.ToUInt64("00100010100010100010001000100010001", 2)
        Me.ulong_0(1) = Convert.ToUInt64("10001000100010001000101000101000100", 2)
        Me.ulong_0(2) = Convert.ToUInt64("10001010100010000000100010101000100", 2)
        Me.ulong_0(3) = Convert.ToUInt64("00100010101000100000001000101010001", 2)
        If ((MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0))) Then
            Me.ForeColor = Color.Red
        End If
        Me.BlinkTimer = New Timer() With
        {
            .Interval = Me.int_0,
            .Enabled = False
        }
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub method_0(ByVal sender As Object, ByVal e As EventArgs)
        If (Not Me.bool_1) Then
            Me.ForeColor = ControlPaint.Dark(Me.color_0)
            Me.bool_1 = True
        Else
            Me.ForeColor = Me.color_0
            Me.bool_1 = False
        End If
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim num As Integer
        Dim num1 As Integer
        Dim num2 As Integer
        Dim num3 As Integer
        MyBase.OnPaint(painte)
        painte.Graphics.SmoothingMode = SmoothingMode.HighQuality
        If (If(Me.arrowDir_0 = SimpleFlowArrows.ArrowDir.Right, False, Me.arrowDir_0 <> SimpleFlowArrows.ArrowDir.Left)) Then
            num = 6
            num1 = 4
            num2 = 5
            num3 = CInt(Math.Round(5.25!))
        Else
            num = 4
            num1 = 6
            num2 = 7
            num3 = CInt(Math.Round(7.25!))
        End If
        Dim num4 As Integer = num


    End Sub

    Private Sub SimpleFlowArrows_Click(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Focus()
    End Sub

    Private Sub SimpleFlowArrows_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If (If(Me.arrowDir_0 = SimpleFlowArrows.ArrowDir.Right, False, Me.arrowDir_0 <> SimpleFlowArrows.ArrowDir.Left)) Then
            If (MyBase.Height < 25) Then
                MyBase.Height = 25
            End If
            MyBase.Width = CInt(Math.Round(CDbl((0.7154471! * CSng(MyBase.Height)))))
            If (MyBase.Width < 18) Then
                MyBase.Width = 18
            End If
        Else
            If (MyBase.Width < 25) Then
                MyBase.Width = 25
            End If
            MyBase.Height = CInt(Math.Round(CDbl((0.7154471! * CSng(MyBase.Width)))))
            If (MyBase.Height < 18) Then
                MyBase.Height = 18
            End If
        End If
    End Sub

    Public Enum ArrowDir
        Right
        Left
        Up
        Down
    End Enum
End Class
