Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms



Public Class FlowArrowMatrix2
    Inherits Control


    Private DotPattern As ULong


    Private BlinkTimer As Timer

    Private m_arrowColor As Color

    Private m_valueFlow As Boolean

    Private _blinkInterval As Integer

    Public m_Angle As FlowArrowMatrix2.Angle

    Private flagTimer As Boolean

    <Browsable(True), DefaultValue(500), Description("LED blinking interval in milliseconds."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowBlinkInterval() As Integer
        Get
            Return Me._blinkInterval
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 500
            End If
            If value < 0 Then
                value = 500
            End If
            If Me._blinkInterval <> value Then
                Me._blinkInterval = value
                Me.BlinkTimer.Interval = Me._blinkInterval
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(315), Description("The direction of the arrow."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowDirection() As FlowArrowMatrix2.Angle
        Get
            Return Me.m_Angle
        End Get
        Set(ByVal value As FlowArrowMatrix2.Angle)
            Me.m_Angle = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), DefaultValue(GetType(Color), "DodgerBlue"), Description("The arrow LEDs color."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowLEDColor() As Color
        Get
            Return Me.m_arrowColor
        End Get
        Set(ByVal value As Color)
            If Me.m_arrowColor <> value Then
                Me.m_arrowColor = value
                Me.Invalidate()
            End If
        End Set
    End Property



    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            If String.Compare(MyBase.Text, value) <> 0 Then
                MyBase.Text = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(False), Description("Indicates whether there is a flow."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As Boolean
        Get
            Return Me.m_valueFlow
        End Get
        Set(ByVal value As Boolean)
            If Me.m_valueFlow <> value Then
                Me.m_valueFlow = value
                If Not Me.m_valueFlow Then
                    Me.BlinkTimer.Enabled = False
                    Me.flagTimer = False
                Else
                    Me.BlinkTimer.Enabled = True
                End If
            End If
            Me.Invalidate()
        End Set
    End Property


    Public Sub New()
        Dim flowArrowMatrix2 As FlowArrowMatrix2 = Me
        AddHandler MyBase.Click, AddressOf flowArrowMatrix2.FlowArrowMatrix2_Click
        Dim flowArrowMatrix21 As FlowArrowMatrix2 = Me
        AddHandler MyBase.Resize, AddressOf flowArrowMatrix21.FlowArrowMatrix2_Resize

        Me.m_arrowColor = Color.DodgerBlue
        Me._blinkInterval = 500
        Me.m_Angle = FlowArrowMatrix2.Angle.SE
        Me.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.Transparent
        Me.Size = New Size(121, 121)
        Me.DotPattern = Convert.ToUInt64("0001000001100001111111111111011111100110000001000", 2)
        Me.BlinkTimer = New Timer() With {
            .Interval = Me._blinkInterval,
            .Enabled = False
        }
        Me.flagTimer = False
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub FlowArrowMatrix2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Focus()
    End Sub

    Private Sub FlowArrowMatrix2_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If Me.Height < 26 Then
            Me.Height = 26
        End If
        If Me.Width < 26 Then
            Me.Width = 26
        End If
        Me.Width = Me.Height
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim colorArray() As Color
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim graphics As Graphics = e.Graphics
        'INSTANT VB NOTE: The variable clientRectangle was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim clientRectangle_Renamed As Rectangle = Me.ClientRectangle
        'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim width_Renamed As Single = CSng(CDbl(clientRectangle_Renamed.Width) / 2)
        Dim rectangle As Rectangle = Me.ClientRectangle
        graphics.TranslateTransform(width_Renamed, CSng(CDbl(rectangle.Height) / 2))
        e.Graphics.RotateTransform(-CSng(Me.m_Angle))
        Dim graphic As Graphics = e.Graphics
        rectangle = Me.ClientRectangle
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: float single = (float)((double)(checked(0 - rectangle.Width)) / 2);
        Dim [single] As Single = CSng(CDbl(0 - rectangle.Width) / 2)
        clientRectangle_Renamed = Me.ClientRectangle
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: graphic.TranslateTransform(single, (float)((double)(checked(0 - clientRectangle.Height)) / 2));
        graphic.TranslateTransform([single], CSng(CDbl(0 - clientRectangle_Renamed.Height) / 2))
        Dim num As Integer = 0
        Do
            Dim num1 As Short = 0
            Do
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: long num2 = checked((long)Math.Round(Math.Pow(2, (double)(checked(checked(num * 7) + num1)))));
                Dim num2 As Long = CLng(Math.Truncate(Math.Round(Math.Pow(2, CDbl((num * 7) + num1)))))
                Dim rectangle1 As New Rectangle(Convert.ToInt32(CDbl(num1) * (CDbl(Me.Width) / 7)), Convert.ToInt32(CDbl(num) * (CDbl(Me.Width) / 7)), Convert.ToInt32(CDbl(Me.Width) / 7 - 1), Convert.ToInt32(CDbl(Me.Width) / 7 - 1))
                Dim graphicsPath As New GraphicsPath()
                graphicsPath.AddEllipse(rectangle1)
                Dim pathGradientBrush As New PathGradientBrush(graphicsPath)
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: if (((void*)(checked((long)this.DotPattern)) & num2) > (long)0)
                If (CLng(Me.DotPattern) And num2) > CLng(0) Then
                    rectangle1.Inflate(-1, -1)
                    e.Graphics.FillEllipse(New SolidBrush(Color.Black), rectangle1)
                    If Not Me.flagTimer Then
                        e.Graphics.DrawEllipse(New Pen(Color.FromArgb(185, Me.m_arrowColor), 2.0F), rectangle1)
                        pathGradientBrush.CenterColor = ControlPaint.Light(Me.m_arrowColor)
                        colorArray = New Color() {Color.FromArgb(25, ControlPaint.Light(Me.m_arrowColor))}
                        pathGradientBrush.SurroundColors = colorArray
                    Else
                        e.Graphics.DrawEllipse(New Pen(Color.FromArgb(45, Me.m_arrowColor), 2.0F), rectangle1)
                        pathGradientBrush.CenterColor = ControlPaint.DarkDark(Me.m_arrowColor)
                        colorArray = New Color() {ControlPaint.Dark(Me.m_arrowColor)}
                        pathGradientBrush.SurroundColors = colorArray
                    End If
                    e.Graphics.FillEllipse(pathGradientBrush, rectangle1)
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: num1 = checked((short)(num1 + 1));
                num1 = CShort(num1 + 1)
            Loop While num1 <= 6
            num += 1
        Loop While num <= 6
        e.Graphics.ResetTransform()
        If Not String.IsNullOrEmpty(Me.Text) Then
            Dim stringFormat As New StringFormat() With {
             .Alignment = StringAlignment.Center,
             .LineAlignment = StringAlignment.Center
            }
            Dim graphics1 As Graphics = e.Graphics
            Dim text_Renamed As String = Me.Text
            Dim font_Renamed As Font = Me.Font
            Dim solidBrush As New SolidBrush(Me.ForeColor)
            Dim point As New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), CInt(Math.Round(CDbl(Me.Height) / 2)))
            graphics1.DrawString(text_Renamed, font_Renamed, solidBrush, point, stringFormat)
        End If
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me.flagTimer = Not Me.flagTimer
        Me.Invalidate()
    End Sub

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

