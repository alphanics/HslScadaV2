Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class FlowArrowMatrix1
    Inherits Control
    Private ulong_0 As ULong()

    Private color_0 As Color

    Private float_0 As Single

    Private float_1 As Single

    Private arrowDirectionOption_0 As FlowArrowMatrix1.ArrowDirectionOption

    Private bool_0 As Boolean

    Private int_0 As Integer

    Private bool_1 As Boolean

    <Browsable(True)>
    <DefaultValue(500)>
    <Description("The arrow LED blinking interval in milliseconds.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ArrowBlinkInterval As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
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
    <DefaultValue(3)>
    <Description("Select arrow direction (Right, Left, Up, Down).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ArrowDirection As FlowArrowMatrix1.ArrowDirectionOption
        Get
            Return Me.arrowDirectionOption_0
        End Get
        Set(ByVal value As FlowArrowMatrix1.ArrowDirectionOption)
            Dim flag As Boolean
            If (Me.arrowDirectionOption_0 <> value) Then
                Me.float_0 = CSng(MyBase.Width)
                Me.float_1 = CSng(MyBase.Height)
                If ((Me.arrowDirectionOption_0 = FlowArrowMatrix1.ArrowDirectionOption.Right OrElse Me.arrowDirectionOption_0 = FlowArrowMatrix1.ArrowDirectionOption.Left) AndAlso value <> FlowArrowMatrix1.ArrowDirectionOption.Right) Then
                    If (value = FlowArrowMatrix1.ArrowDirectionOption.Left) Then
                        GoTo Label3
                    End If
                    flag = True
                    GoTo Label0
                End If
Label3:
                If (Me.arrowDirectionOption_0 <> FlowArrowMatrix1.ArrowDirectionOption.Up) Then
                    If (Me.arrowDirectionOption_0 = FlowArrowMatrix1.ArrowDirectionOption.Down) Then
                        GoTo Label4
                    End If
                    flag = False
                    GoTo Label0
                End If
Label4:
                flag = If(value = FlowArrowMatrix1.ArrowDirectionOption.Up, False, value <> FlowArrowMatrix1.ArrowDirectionOption.Down)
Label0:
                If (Not flag) Then
                    Me.arrowDirectionOption_0 = value
                Else
                    Me.arrowDirectionOption_0 = value
                    MyBase.Width = CInt(Math.Round(CDbl(Me.float_1)))
                    MyBase.Height = CInt(Math.Round(CDbl(Me.float_0)))
                    Me.FlowArrowMatrix1_Resize(Me, Nothing)
                End If
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(GetType(Color), "Red")>
    <Description("The arrow LEDs color.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ArrowLEDColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (Me.color_0 <> value) Then
                Me.color_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Private Property BlinkTimer As System.Windows.Forms.Timer


    <Browsable(True)>
    <Description("Constant value used to maintain the ratio between width and height.")>
    <RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property SizeScaleCoefficient As Single
        Get
            Return 0.7154471!
        End Get
    End Property

    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            If (String.Compare(MyBase.Text, value, StringComparison.CurrentCulture) <> 0) Then
                MyBase.Text = value
                MyBase.Invalidate()
            End If
        End Set
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
                    Me.bool_1 = False
                Else
                    Me.BlinkTimer.Enabled = True
                End If
                MyBase.Invalidate()

                RaiseEvent ValueChanged(Me, EventArgs.Empty)

            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        AddHandler MyBase.Click, New EventHandler(AddressOf Me.FlowArrowMatrix1_Click)
        AddHandler MyBase.Resize, New EventHandler(AddressOf Me.FlowArrowMatrix1_Resize)
        ReDim Me.ulong_0(4)
        Me.color_0 = Color.Red
        Me.arrowDirectionOption_0 = FlowArrowMatrix1.ArrowDirectionOption.Down
        Me.int_0 = 500
        MyBase.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.Transparent
        MyBase.Size = New System.Drawing.Size(87, 121)
        Me.ulong_0(0) = Convert.ToUInt64("00100010100010100010001000100010001", 2)
        Me.ulong_0(1) = Convert.ToUInt64("10001000100010001000101000101000100", 2)
        Me.ulong_0(2) = Convert.ToUInt64("10001010100010000000100010101000100", 2)
        Me.ulong_0(3) = Convert.ToUInt64("00100010101000100000001000101010001", 2)
        Me.BlinkTimer = New System.Windows.Forms.Timer() With
        {
            .Interval = Me.int_0,
            .Enabled = False
        }
        Me.bool_1 = False
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub FlowArrowMatrix1_Click(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Focus()
    End Sub

    Private Sub FlowArrowMatrix1_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If (If(Me.arrowDirectionOption_0 = FlowArrowMatrix1.ArrowDirectionOption.Right, False, Me.arrowDirectionOption_0 <> FlowArrowMatrix1.ArrowDirectionOption.Left)) Then
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

    Private Sub method_0(ByVal sender As Object, ByVal e As EventArgs)
        Me.bool_1 = Not Me.bool_1
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim num As Integer
        Dim num1 As Integer
        Dim num2 As Integer
        Dim num3 As Integer
        MyBase.OnPaint(painte)
        painte.Graphics.SmoothingMode = SmoothingMode.HighQuality
        If (If(Me.arrowDirectionOption_0 = FlowArrowMatrix1.ArrowDirectionOption.Right, False, Me.arrowDirectionOption_0 <> FlowArrowMatrix1.ArrowDirectionOption.Left)) Then
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
        Dim num5 As Integer = 0
        Do
            Dim num6 As Short = CShort(num1)
            Dim num7 As Short = 0
            While num7 <= num6
                Dim num8 As Long = CLng(Math.Round(Math.Pow(2, CDbl((num5 * num2 + num7)))))
                Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(num7) * (CDbl(MyBase.Width) / CDbl(num2))), Convert.ToInt32(CDbl(num5) * (CDbl(MyBase.Width) / CDbl(num3))), Convert.ToInt32(CDbl(MyBase.Width) / CDbl(num2) - 1), Convert.ToInt32(CDbl(MyBase.Width) / CDbl(num2) - 1))
                Using graphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
                    graphicsPath.AddEllipse(rectangle)
                    Dim pathGradientBrush As System.Drawing.Drawing2D.PathGradientBrush = New System.Drawing.Drawing2D.PathGradientBrush(graphicsPath)

                End Using
                num7 = CShort((num7 + 1))
            End While
            num5 = num5 + 1
        Loop While num5 <= num4
        If (Not String.IsNullOrEmpty(Me.Text)) Then
            Dim stringFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat() With
            {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
            painte.Graphics.DrawString(Me.Text, Me.Font, New System.Drawing.SolidBrush(Me.ForeColor), New Point(CInt(Math.Round(CDbl(MyBase.Width) / 2)), CInt(Math.Round(CDbl(MyBase.Height) / 2))), stringFormat)
        End If
    End Sub

    Public Event ValueChanged As EventHandler


    Public Enum ArrowDirectionOption
        Right
        Left
        Up
        Down
    End Enum
End Class
