Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class FlowArrowMatrix2
    Inherits Control
    Private ulong_0 As ULong

    Private color_0 As Color

    Private bool_0 As Boolean

    Private int_0 As Integer

    Public m_Angle As FlowArrowMatrix2.Angle

    Private bool_1 As Boolean

    <Browsable(True)>
    <DefaultValue(500)>
    <Description("LED blinking interval in milliseconds.")>
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
    <DefaultValue(315)>
    <Description("The direction of the arrow.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ArrowDirection As FlowArrowMatrix2.Angle
        Get
            Return Me.m_Angle
        End Get
        Set(ByVal value As FlowArrowMatrix2.Angle)
            Me.m_Angle = value
            MyBase.Invalidate()
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(GetType(Color), "DodgerBlue")>
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
        AddHandler MyBase.Click, New EventHandler(AddressOf Me.FlowArrowMatrix2_Click)
        AddHandler MyBase.Resize, New EventHandler(AddressOf Me.FlowArrowMatrix2_Resize)
        Me.color_0 = Color.DodgerBlue
        Me.int_0 = 500
        Me.m_Angle = FlowArrowMatrix2.Angle.SE
        MyBase.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.Transparent
        MyBase.Size = New System.Drawing.Size(121, 121)
        Me.ulong_0 = Convert.ToUInt64("0001000001100001111111111111011111100110000001000", 2)
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

    Private Sub FlowArrowMatrix2_Click(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Focus()
    End Sub

    Private Sub FlowArrowMatrix2_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If (MyBase.Height < 26) Then
            MyBase.Height = 26
        End If
        If (MyBase.Width < 26) Then
            MyBase.Width = 26
        End If
        MyBase.Width = MyBase.Height
    End Sub

    Private Sub method_0(ByVal sender As Object, ByVal e As EventArgs)
        Me.bool_1 = Not Me.bool_1
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        MyBase.OnPaint(painte)
        painte.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim graphics As System.Drawing.Graphics = painte.Graphics
        Dim clientRectangle As System.Drawing.Rectangle = MyBase.ClientRectangle
        Dim width As Single = CSng((CDbl(clientRectangle.Width) / 2))
        clientRectangle = MyBase.ClientRectangle
        graphics.TranslateTransform(width, CSng((CDbl(clientRectangle.Height) / 2)))
        painte.Graphics.RotateTransform(-CSng(Me.m_Angle))
        Dim graphic As System.Drawing.Graphics = painte.Graphics
        clientRectangle = MyBase.ClientRectangle
        Dim [single] As Single = CSng((CDbl((0 - clientRectangle.Width)) / 2))
        clientRectangle = MyBase.ClientRectangle
        graphic.TranslateTransform([single], CSng((CDbl((0 - clientRectangle.Height)) / 2)))
        Dim num As Integer = 0
        Do
            Dim num1 As Short = 0
            Do
                Dim num2 As Long = CLng(Math.Round(Math.Pow(2, CDbl((num * 7 + num1)))))
                Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(num1) * (CDbl(MyBase.Width) / 7)), Convert.ToInt32(CDbl(num) * (CDbl(MyBase.Width) / 7)), Convert.ToInt32(CDbl(MyBase.Width) / 7 - 1), Convert.ToInt32(CDbl(MyBase.Width) / 7 - 1))
                Dim graphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
                graphicsPath.AddEllipse(rectangle)
                Dim pathGradientBrush As System.Drawing.Drawing2D.PathGradientBrush = New System.Drawing.Drawing2D.PathGradientBrush(graphicsPath)

                num1 = CShort((num1 + 1))
            Loop While num1 <= 6
            num = num + 1
        Loop While num <= 6
        painte.Graphics.ResetTransform()
        If (Not String.IsNullOrEmpty(Me.Text)) Then
            Dim stringFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat() With
            {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
            painte.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), New Point(CInt(Math.Round(CDbl(MyBase.Width) / 2)), CInt(Math.Round(CDbl(MyBase.Height) / 2))), stringFormat)
        End If
    End Sub

    Public Event ValueChanged As EventHandler


    Public Enum Angle
        E = 0
        NE = 45
        N = 90
        NW = 135
        W = 180
        SW = 225
        S = 270
        SE = 315
    End Enum
End Class
