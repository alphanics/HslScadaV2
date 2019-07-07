Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class SimpleLED
    Inherits Control



    Private BlinkTimer As Timer

    Private _brushONColor() As Color

    Private color1 As Color

    Private color2 As Color

    Private LED_ON As Boolean

    Private _border As Boolean

    Private _borderColor As Color

    Private _LEDBrightness As SimpleLED.LED_Bri

    Private _LEDColor As SimpleLED.LED_Col

    Private m_Value As Boolean

    Private _blink As Boolean

    Private _blinkInterval As Integer

    Private _interaction As Boolean



    <Browsable(False)>
    Public Property BorderStyle() As BorderStyle

    <Browsable(True), DefaultValue(False), Description("Enable LED blink (also controlled by the mouse DoubleClick event when user interaction is enabled)."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_Blink() As Boolean
        Get
            Return Me._blink
        End Get
        Set(ByVal value As Boolean)
            If Me._blink <> value Then
                Me._blink = value
                If Not Me._blink Then
                    Me.BlinkTimer.Enabled = False
                Else
                    Me.BlinkTimer.Enabled = True
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(500), Description("LED blinking interval in milliseconds."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_BlinkInterval() As Integer
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

    <Browsable(True), DefaultValue(False), Description("Enable LED border."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_Border() As Boolean
        Get
            Return Me._border
        End Get
        Set(ByVal value As Boolean)
            If Me._border <> value Then
                Me._border = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(GetType(Color), "MediumSeaGreen"), Description("LED border color."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_BorderColor() As Color
        Get
            Return Me._borderColor
        End Get
        Set(ByVal value As Color)
            If Me._borderColor <> value Then
                Me._borderColor = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(0), Description("LED brightness."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_Brightness() As SimpleLED.LED_Bri
        Get
            Return Me._LEDBrightness
        End Get
        Set(ByVal value As SimpleLED.LED_Bri)
            If Me._LEDBrightness <> value Then
                Me._LEDBrightness = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(0), Description("LED color."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_Color() As SimpleLED.LED_Col
        Get
            Return Me._LEDColor
        End Get
        Set(ByVal value As SimpleLED.LED_Col)
            If Me._LEDColor <> value Then
                Me._LEDColor = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(False), Description("Enable user interaction at Runtime (events: Click for ON/OFF, DoubleClick for blink)."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_UserInteraction() As Boolean
        Get
            Return Me._interaction
        End Get
        Set(ByVal value As Boolean)
            If Me._interaction <> value Then
                Me._interaction = value
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

    <Browsable(True), DefaultValue(False), Description("Turn LED ON (also controlled by the mouse Click event when user interaction is enabled)."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As Boolean
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Boolean)
            If Me.m_Value <> value Then
                Me.m_Value = value
            End If
            Me.Invalidate()
        End Set
    End Property



    Public Sub New()
        Dim simpleLED As SimpleLED = Me
        AddHandler MyBase.Click, AddressOf simpleLED.LED_Click
        Dim simpleLED1 As SimpleLED = Me
        AddHandler MyBase.DoubleClick, AddressOf simpleLED1.LED_DoubleClick
        Dim simpleLED2 As SimpleLED = Me
        AddHandler MyBase.Resize, AddressOf simpleLED2.LED_Resize

        Dim red() As Color = {Color.Red, Color.Green, Color.Lime, Color.Blue, Color.Cyan, Color.Orange, Color.Yellow, Color.Violet, Color.White}
        Me._brushONColor = red
        Me.LED_ON = False
        Me.BorderStyle = BorderStyle.None
        Me._borderColor = Color.MediumSeaGreen
        Me._LEDBrightness = SimpleLED.LED_Bri.Normal
        Me._LEDColor = SimpleLED.LED_Col.Red
        Me._blinkInterval = 500
        Me.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent
        'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim size_Renamed As New Size(30, 30)
        Me.MinimumSize = size_Renamed
        size_Renamed = New Size(360, 360)
        Me.MaximumSize = size_Renamed
        Me.Width = Me.Height
        Me.BlinkTimer = New Timer() With {
         .Interval = Me._blinkInterval,
         .Enabled = False
        }
    End Sub


    Private Sub LED_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Focus()
        If Not Me._blink Then
            If Me._interaction Then
                Me.m_Value = Not Me.m_Value
                Me.Invalidate()
            End If
        End If
    End Sub

    Private Sub LED_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        If Not Me._blink Then
            If Me._interaction Then
                Me.BlinkTimer.Enabled = Not Me.BlinkTimer.Enabled
                Me.Invalidate()
            End If
        End If
    End Sub

    Private Sub LED_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Me.Width = Me.Height
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim colorArray() As Color
        Dim flag As Boolean
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: Rectangle rectangle = new Rectangle(0, 0, checked((int)Math.Round((double)((float)((float)this.Width - 1f)))), checked((int)Math.Round((double)((float)((float)this.Height - 1f)))));
        Dim rectangle As New Rectangle(0, 0, CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Width) - 1.0F))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) - 1.0F))))))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(2, 2, checked((int)Math.Round((double)((float)((float)this.Width - 5f)))), checked((int)Math.Round((double)((float)((float)this.Height - 5f)))));
        Dim rectangle1 As New Rectangle(2, 2, CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Width) - 5.0F))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) - 5.0F))))))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: Rectangle rectangle2 = new Rectangle(3, 3, checked((int)Math.Round((double)((float)((float)this.Width - 7f)))), checked((int)Math.Round((double)((float)((float)this.Height - 7f)))));
        Dim rectangle2 As New Rectangle(3, 3, CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Width) - 7.0F))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) - 7.0F))))))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: Rectangle rectangle3 = new Rectangle(5, 5, checked((int)Math.Round((double)((float)((float)this.Width - 11f)))), checked((int)Math.Round((double)((float)((float)this.Height - 11f)))));
        Dim rectangle3 As New Rectangle(5, 5, CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Width) - 11.0F))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) - 11.0F))))))
        If Me._border Then
            e.Graphics.DrawEllipse(New Pen(Me._borderColor, 1.5F), rectangle)
        End If
        If Not Me.BlinkTimer.Enabled Then
            If Not Me.m_Value Then
                Me.LED_ON = False
            Else
                Me.LED_ON = True
            End If
        End If
        Dim graphicsPath As New GraphicsPath()
        graphicsPath.AddEllipse(rectangle3)
        Dim pathGradientBrush As New PathGradientBrush(graphicsPath)
        If Not Me.LED_ON Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Black), rectangle1)
            Me.color1 = Color.FromArgb(255, ControlPaint.Dark(Me._brushONColor(CInt(Me._LEDColor))))
            Me.color2 = Color.FromArgb(100, Me.color1)
            e.Graphics.DrawEllipse(New Pen(Color.FromArgb(45, Me._brushONColor(CInt(Me._LEDColor))), 2.5F), rectangle2)
        Else
            If Me._LEDColor <> SimpleLED.LED_Col.Green AndAlso Me._LEDColor <> SimpleLED.LED_Col.Orange Then
                If Me._LEDColor = SimpleLED.LED_Col.Violet Then
                    GoTo Label1
                End If
                flag = False
                GoTo Label0
            End If
Label1:
            flag = True
Label0:
            If Not flag Then
                e.Graphics.FillEllipse(New SolidBrush(ControlPaint.Dark(Me._brushONColor(CInt(Me._LEDColor)), 20.0F)), rectangle1)
            Else
                e.Graphics.FillEllipse(New SolidBrush(ControlPaint.Dark(Me._brushONColor(CInt(Me._LEDColor)))), rectangle1)
            End If
            Me.color1 = Color.FromArgb(255, Me._brushONColor(CInt(Me._LEDColor)))
            Me.color2 = Color.FromArgb(0, Me.color1)
            e.Graphics.DrawEllipse(New Pen(Color.FromArgb(125, Me._brushONColor(CInt(Me._LEDColor))), 2.5F), rectangle2)
            If Me._LEDBrightness = SimpleLED.LED_Bri.Brighter Then
                pathGradientBrush.CenterColor = ControlPaint.Light(Me._brushONColor(CInt(Me._LEDColor)))
                colorArray = New Color() {Color.FromArgb(25, ControlPaint.Light(Me._brushONColor(CInt(Me._LEDColor))))}
                pathGradientBrush.SurroundColors = colorArray
                e.Graphics.FillEllipse(pathGradientBrush, rectangle3)
            End If
        End If
        pathGradientBrush.CenterColor = Me.color1
        colorArray = New Color() {Me.color2}
        pathGradientBrush.SurroundColors = colorArray
        e.Graphics.FillEllipse(pathGradientBrush, rectangle3)
        If Not String.IsNullOrEmpty(Me.Text) Then
            Dim stringFormat As New StringFormat() With {
             .Alignment = StringAlignment.Center,
             .LineAlignment = StringAlignment.Center
            }
            Dim graphics As Graphics = e.Graphics
            'INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim text_Renamed As String = Me.Text
            'INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim font_Renamed As Font = Me.Font
            Dim solidBrush As New SolidBrush(Me.ForeColor)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point = new Point(checked((int)Math.Round((double)this.Width / 2)), checked((int)Math.Round((double)this.Height / 2)));
            Dim point As New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), CInt(Math.Round(CDbl(Me.Height) / 2)))
            graphics.DrawString(text_Renamed, font_Renamed, solidBrush, point, stringFormat)
        End If
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me.LED_ON = Not Me.LED_ON
        Me.Invalidate()
    End Sub

    Public Enum LED_Bri
        Normal
        Brighter
    End Enum

    Public Enum LED_Col
        Red
        Green
        Lime
        Blue
        Cyan
        Orange
        Yellow
        Violet
        White
    End Enum
End Class



