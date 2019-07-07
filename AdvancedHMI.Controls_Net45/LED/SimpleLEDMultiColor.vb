Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class SimpleLEDMultiColor
    Inherits Control



    Private BlinkTimer As Timer

    Private _brushONColor() As Color

    Private color1 As Color

    Private color2 As Color

    Private _ONOFF As Boolean

    Private _border As Boolean

    Private _borderColor As Color

    Private _LEDBrightness As SimpleLEDMultiColor.LED_Bri

    Private _LEDColor As SimpleLEDMultiColor.LED_Col

    Private _defaultColor As SimpleLEDMultiColor.LED_Col

    Private m_Value As Integer

    Private _showValue As Boolean

    Private _blink As Boolean

    Private _blinkInterval As Integer

    Private _interaction As Boolean

    'private virtual Timer BlinkTimer
    '{
    '    [DebuggerNonUserCode]
    '    get
    '    {
    '        return this._BlinkTimer;
    '    }
    '    [DebuggerNonUserCode]
    '    set
    '    {
    '        SimpleLEDMultiColor simpleLEDMultiColor = this;
    '        EventHandler eventHandler = new EventHandler(simpleLEDMultiColor.tmr_Tick);
    '        if (this._BlinkTimer != null)
    '        {
    '            this._BlinkTimer.Tick -= eventHandler;
    '        }
    '        this._BlinkTimer = value;
    '        if (this._BlinkTimer != null)
    '        {
    '            this._BlinkTimer.Tick += eventHandler;
    '        }
    '    }
    '}

    <Browsable(False)>
    Public Property BorderStyle() As BorderStyle

    <Browsable(False), DefaultValue(False), Description("Enable LED blink."), RefreshProperties(RefreshProperties.All)>
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
    Public Property LED_Brightness() As SimpleLEDMultiColor.LED_Bri
        Get
            Return Me._LEDBrightness
        End Get
        Set(ByVal value As SimpleLEDMultiColor.LED_Bri)
            If Me._LEDBrightness <> value Then
                Me._LEDBrightness = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), Description("LED color."), RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property LED_Color() As SimpleLEDMultiColor.LED_Col
        Get
            Return Me._LEDColor
        End Get
    End Property

    <Browsable(True), Description("Set LED default OFF color."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_ColorDefaultOFF() As SimpleLEDMultiColor.LED_Col
        Get
            Return Me._defaultColor
        End Get
        Set(ByVal value As SimpleLEDMultiColor.LED_Col)
            If Me._defaultColor <> value Then
                Me._defaultColor = value
                If Me.m_Value = 0 Then
                    Me._LEDColor = Me._defaultColor
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(False), Description("Show the current integer value on the LED itself (also controlled by the mouse DoubleClick event)."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_ShowValue() As Boolean
        Get
            Return Me._showValue
        End Get
        Set(ByVal value As Boolean)
            If Me._showValue <> value Then
                Me._showValue = value
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(False), Description("Enable user interaction at Runtime (when focused use MouseWheel to increase/decrease integer value thus change the LED color and state)."), RefreshProperties(RefreshProperties.All)>
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

    <Browsable(True), DefaultValue(0), Description("LED single input integer value (valid range 0 to 18)."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As Integer
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 0
            End If
            If value < 0 Then
                value = 0
            End If
            If value > 18 Then
                value = 0
            End If
            If Me.m_Value <> value Then
                Me.m_Value = value
                If Me.m_Value = 0 Then
                    Me._LEDColor = Me._defaultColor
                End If
                If Me.m_Value = 1 Or Me.m_Value = 2 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.Red
                End If
                If Me.m_Value = 3 Or Me.m_Value = 4 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.Green
                End If
                If Me.m_Value = 5 Or Me.m_Value = 6 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.Lime
                End If
                If Me.m_Value = 7 Or Me.m_Value = 8 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.Blue
                End If
                If Me.m_Value = 9 Or Me.m_Value = 10 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.Cyan
                End If
                If Me.m_Value = 11 Or Me.m_Value = 12 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.Orange
                End If
                If Me.m_Value = 13 Or Me.m_Value = 14 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.Yellow
                End If
                If Me.m_Value = 15 Or Me.m_Value = 16 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.Violet
                End If
                If Me.m_Value = 17 Or Me.m_Value = 18 Then
                    Me._LEDColor = SimpleLEDMultiColor.LED_Col.White
                End If
                Me.LED(Me.m_Value)
                Me.Invalidate()
            End If
        End Set
    End Property


    Public Sub New()
        Dim simpleLEDMultiColor As SimpleLEDMultiColor = Me
        AddHandler MyBase.Click, AddressOf simpleLEDMultiColor.SimpleLEDMultiColor_Click
        Dim simpleLEDMultiColor1 As SimpleLEDMultiColor = Me
        AddHandler MyBase.DoubleClick, AddressOf simpleLEDMultiColor1.SimpleLEDMultiColor_DoubleClick
        Dim simpleLEDMultiColor2 As SimpleLEDMultiColor = Me
        AddHandler MyBase.MouseWheel, AddressOf simpleLEDMultiColor2.SimpleLEDMultiColor_MouseWheel
        Dim simpleLEDMultiColor3 As SimpleLEDMultiColor = Me
        AddHandler MyBase.Resize, AddressOf simpleLEDMultiColor3.SimpleLEDMultiColor_Resize

        Dim red() As Color = {Color.Red, Color.Green, Color.Lime, Color.Blue, Color.Cyan, Color.Orange, Color.Yellow, Color.Violet, Color.White}
        Me._brushONColor = red
        Me._ONOFF = False
        Me.BorderStyle = BorderStyle.None
        Me._borderColor = Color.MediumSeaGreen
        Me._LEDBrightness = SimpleLEDMultiColor.LED_Bri.Normal
        Me._defaultColor = SimpleLEDMultiColor.LED_Col.Red
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
        Me._LEDColor = SimpleLEDMultiColor.LED_Col.Red
        Me._ONOFF = False
        Me.LED_Blink = False
    End Sub


    Private Sub LED(ByVal e As Integer)
        If e = 0 Then
            Me._ONOFF = False
            Me.LED_Blink = False
        End If
        If e = 1 Or e = 3 Or e = 5 Or e = 7 Or e = 9 Or e = 11 Or e = 13 Or e = 15 Or e = 17 Then
            Me.LED_Blink = False
            Me._ONOFF = True
        End If
        If e = 2 Or e = 4 Or e = 6 Or e = 8 Or e = 10 Or e = 12 Or e = 14 Or e = 16 Or e = 18 Then
            Me._ONOFF = False
            Me.LED_Blink = True
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim point As Point
        Dim colorArray() As Color
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
        Dim graphicsPath As New GraphicsPath()
        graphicsPath.AddEllipse(rectangle3)
        Dim pathGradientBrush As New PathGradientBrush(graphicsPath)
        If Not Me._ONOFF Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Black), rectangle1)
            Me.color1 = Color.FromArgb(255, ControlPaint.Dark(Me._brushONColor(CInt(Me._LEDColor))))
            Me.color2 = Color.FromArgb(100, Me.color1)
            e.Graphics.DrawEllipse(New Pen(Color.FromArgb(45, Me._brushONColor(CInt(Me._LEDColor))), 2.5F), rectangle2)
        Else
            e.Graphics.FillEllipse(New SolidBrush(ControlPaint.Dark(Me._brushONColor(CInt(Me._LEDColor)))), rectangle1)
            Me.color1 = Color.FromArgb(255, Me._brushONColor(CInt(Me._LEDColor)))
            Me.color2 = Color.FromArgb(0, Me.color1)
            e.Graphics.DrawEllipse(New Pen(Color.FromArgb(125, Me._brushONColor(CInt(Me._LEDColor))), 2.5F), rectangle2)
            If Me._LEDBrightness = SimpleLEDMultiColor.LED_Bri.Brighter Then
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
        If Not String.IsNullOrEmpty(Me.Text) Or Me._showValue Then
            Dim stringFormat As New StringFormat() With {
             .Alignment = StringAlignment.Center,
             .LineAlignment = StringAlignment.Center
            }
            If Not Me._showValue Then
                Dim graphics As Graphics = e.Graphics
                'INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
                Dim text_Renamed As String = Me.Text
                'INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
                Dim font_Renamed As Font = Me.Font
                Dim solidBrush As New SolidBrush(Me.ForeColor)
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: point = new Point(checked((int)Math.Round((double)this.Width / 2)), checked((int)Math.Round((double)this.Height / 2)));
                point = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), CInt(Math.Round(CDbl(Me.Height) / 2)))
                graphics.DrawString(text_Renamed, font_Renamed, solidBrush, point, stringFormat)
            Else
                Dim graphic As Graphics = e.Graphics
                Dim str As String = Me.m_Value.ToString()
                Dim font1 As Font = Me.Font
                Dim solidBrush1 As New SolidBrush(Me.ForeColor)
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: point = new Point(checked((int)Math.Round((double)this.Width / 2)), checked((int)Math.Round((double)this.Height / 2)));
                point = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), CInt(Math.Round(CDbl(Me.Height) / 2)))
                graphic.DrawString(str, font1, solidBrush1, point, stringFormat)
            End If
        End If
    End Sub

    Private Sub SimpleLEDMultiColor_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Focus()
    End Sub

    Private Sub SimpleLEDMultiColor_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Me.LED_ShowValue = Not Me.LED_ShowValue
        Me.Invalidate()
    End Sub

    Private Sub SimpleLEDMultiColor_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
        If (If(Not Me.Focused OrElse Not Me._interaction, False, True)) Then
            If Math.Sign(e.Delta) <= 0 Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.Value = checked(this.Value - 1);
                Me.Value = Me.Value - 1
                If Me.Value < 0 Then
                    Me.Value = 0
                End If
            Else
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.Value = checked(this.Value + 1);
                Me.Value = Me.Value + 1
                If Me.Value > 18 Then
                    Me.Value = 18
                End If
            End If
        End If
    End Sub

    Private Sub SimpleLEDMultiColor_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Me.Width = Me.Height
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me._ONOFF = Not Me._ONOFF
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

