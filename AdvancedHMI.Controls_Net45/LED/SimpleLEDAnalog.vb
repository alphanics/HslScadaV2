Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class SimpleLEDAnalog
    Inherits Control



    Private _brushONColor() As Color

    Private color1 As Color

    Private color2 As Color

    Private color3 As Color

    Private color4 As Color

    Private diff As Single

    Private range As Single

    Private newValue1 As Single

    Private newValue2 As Single

    Private newValue3 As Single

    Private newValue4 As Single

    Private newValue5 As Single

    Private _border As Boolean

    Private _borderColor As Color

    Private _LEDColor As SimpleLEDAnalog.LED_Col

    Private m_Value As Single

    Private _showValue As Boolean

    Private m_Maximum As Single

    Private m_Minimum As Single

    Private _interaction As Boolean

    <Browsable(False)>
    Public Property BorderStyle() As BorderStyle

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

    <Browsable(True), DefaultValue(0), Description("LED color."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_Color() As SimpleLEDAnalog.LED_Col
        Get
            Return Me._LEDColor
        End Get
        Set(ByVal value As SimpleLEDAnalog.LED_Col)
            If Me._LEDColor <> value Then
                Me._LEDColor = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(False), Description("Show the current analog value on the LED itself (also controlled by the mouse DoubleClick event)."), RefreshProperties(RefreshProperties.All)>
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

    <Browsable(True), DefaultValue(False), Description("Enable user interaction at Runtime (when focused use MouseWheel to increase/decrease the LED brightness)."), RefreshProperties(RefreshProperties.All)>
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

    <Browsable(True), DefaultValue(255.0F), Description("Maximum LED analog value (needs to be at least 5 higher than the Minimum)."), RefreshProperties(RefreshProperties.All)>
    Public Property Maximum() As Single
        Get
            Return Me.m_Maximum
        End Get
        Set(ByVal value As Single)
            If Not Versioned.IsNumeric(value) Then
                value = 0.0F
            End If
            If Me.m_Maximum <> value Then
                Me.m_Maximum = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(0.0F), Description("Minimum LED analog value (needs to be at least 5 lower than the Maximum)."), RefreshProperties(RefreshProperties.All)>
    Public Property Minimum() As Single
        Get
            Return Me.m_Minimum
        End Get
        Set(ByVal value As Single)
            If Not Versioned.IsNumeric(value) Then
                value = 0.0F
            End If
            If Me.m_Minimum <> value Then
                Me.m_Minimum = value
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

    <Browsable(True), DefaultValue(0.0F), Description("LED analog value."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As Single
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Single)
            If Not Versioned.IsNumeric(value) Then
                value = Me.m_Minimum
            End If
            If Me.m_Value <> value Then
                Me.m_Value = value
                Me.Invalidate()
            End If
        End Set
    End Property


    Public Sub New()
        Dim simpleLEDAnalog As SimpleLEDAnalog = Me
        AddHandler MyBase.Click, AddressOf simpleLEDAnalog.SimpleLEDAnalog_Click
        Dim simpleLEDAnalog1 As SimpleLEDAnalog = Me
        AddHandler MyBase.DoubleClick, AddressOf simpleLEDAnalog1.SimpleLEDAnalog_DoubleClick
        Dim simpleLEDAnalog2 As SimpleLEDAnalog = Me
        AddHandler MyBase.MouseWheel, AddressOf simpleLEDAnalog2.SimpleLEDAnalog_MouseWheel
        Dim simpleLEDAnalog3 As SimpleLEDAnalog = Me
        AddHandler MyBase.Resize, AddressOf simpleLEDAnalog3.LED_Resize

        Dim red() As Color = {Color.Red, Color.Green, Color.Lime, Color.Blue, Color.Cyan, Color.Orange, Color.Yellow, Color.Violet, Color.White}
        Me._brushONColor = red
        Me.BorderStyle = BorderStyle.None
        Me._borderColor = Color.MediumSeaGreen
        Me.m_Maximum = 255.0F
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
    End Sub



    Private Sub LED_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Me.Width = Me.Height
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim point As Point
        Dim colorArray() As Color
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        If Math.Min(Me.m_Minimum, Me.m_Maximum) = Me.m_Maximum Then
            Me.m_Minimum = Me.m_Maximum - 5.0F
            MessageBox.Show("The minimum value should be less than the currently set maximum value!")
        ElseIf Math.Max(Me.m_Maximum, Me.m_Minimum) = Me.m_Minimum Then
            Me.m_Maximum = Me.m_Minimum + 5.0F
            MessageBox.Show("The maximum value should be greater than the currently set minimum value!")
        ElseIf Me.m_Maximum - Me.m_Minimum >= 5.0F Then
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
            Dim graphicsPath As New GraphicsPath()
            graphicsPath.AddEllipse(rectangle3)
            Dim pathGradientBrush As New PathGradientBrush(graphicsPath)
            If Me._border Then
                e.Graphics.DrawEllipse(New Pen(Me._borderColor, 1.5F), rectangle)
            End If
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: int num = checked((int)Math.Round((double)this.m_Minimum));
            Dim num As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.m_Minimum))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: int num1 = checked((int)Math.Round((double)Math.Max(this.m_Minimum, Math.Min(this.m_Maximum, this.m_Value))));
            Dim num1 As Integer = CInt(Math.Truncate(Math.Round(CDbl(Math.Max(Me.m_Minimum, Math.Min(Me.m_Maximum, Me.m_Value))))))
            For i As Integer = num To num1
                Me.diff = CSng(i) - Me.m_Minimum
                Me.range = Me.m_Maximum - Me.m_Minimum
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.newValue1 = (float)(checked((int)Math.Round((double)((float)(this.diff * 255f / this.range)))));
                Me.newValue1 = CSng(CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.diff * 255.0F / Me.range))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.newValue2 = (float)(checked((int)Math.Round((double)((float)(this.diff * 150f / this.range)))));
                Me.newValue2 = CSng(CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.diff * 150.0F / Me.range))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.newValue3 = (float)(checked((int)Math.Round((double)((float)(this.diff * 510f / this.range)))));
                Me.newValue3 = CSng(CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.diff * 510.0F / Me.range))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.newValue4 = (float)(checked((int)Math.Round((double)((float)(this.diff * 310f / this.range)))));
                Me.newValue4 = CSng(CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.diff * 310.0F / Me.range))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.newValue5 = (float)(checked((int)Math.Round((double)((float)(this.diff * 120f / this.range)))));
                Me.newValue5 = CSng(CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.diff * 120.0F / Me.range))))))
                If Me.newValue1 >= 128.0F Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: this.color3 = Color.FromArgb(checked((int)Math.Round((double)((float)(this.newValue3 - 255f)))), this._brushONColor[(int)this._LEDColor]);
                    Me.color3 = Color.FromArgb(CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.newValue3 - 255.0F))))), Me._brushONColor(CInt(Me._LEDColor)))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: this.color4 = Color.FromArgb(checked((int)Math.Round((double)((float)(this.newValue5 + 75f)))), this.color1);
                    Me.color4 = Color.FromArgb(CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.newValue5 + 75.0F))))), Me.color1)
                    pathGradientBrush.CenterColor = Me.color3
                    colorArray = New Color() {Me.color4}
                    pathGradientBrush.SurroundColors = colorArray
                    e.Graphics.FillEllipse(New SolidBrush(Me.color2), rectangle3)
                Else
                    Me.color1 = Color.FromArgb(255, ControlPaint.Dark(Me._brushONColor(CInt(Me._LEDColor))))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: this.color2 = Color.FromArgb(checked((int)Math.Round((double)((float)(100f + this.newValue4)))), this.color1);
                    Me.color2 = Color.FromArgb(CInt(Math.Truncate(Math.Round(CDbl(CSng(100.0F + Me.newValue4))))), Me.color1)
                    pathGradientBrush.CenterColor = Me.color1
                    colorArray = New Color() {Me.color2}
                    pathGradientBrush.SurroundColors = colorArray
                    e.Graphics.FillEllipse(New SolidBrush(Color.Black), rectangle1)
                End If
            Next i
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: e.Graphics.DrawEllipse(new Pen(Color.FromArgb(checked((int)Math.Round((double)((float)(this.newValue2 + 45f)))), this._brushONColor[(int)this._LEDColor]), 2.5f), rectangle2);
            e.Graphics.DrawEllipse(New Pen(Color.FromArgb(CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.newValue2 + 45.0F))))), Me._brushONColor(CInt(Me._LEDColor))), 2.5F), rectangle2)
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
        Else
            Me.m_Maximum = Me.m_Minimum + 5.0F
            MessageBox.Show("The operating range is narrow. The difference between Maximum and Minimum values will be increased!")
        End If
    End Sub

    Private Sub SimpleLEDAnalog_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Focus()
    End Sub

    Private Sub SimpleLEDAnalog_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Me.LED_ShowValue = Not Me.LED_ShowValue
        Me.Invalidate()
    End Sub

    Private Sub SimpleLEDAnalog_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
        If (If(Not Me.Focused OrElse Not Me._interaction, False, True)) Then
            If Math.Sign(e.Delta) <= 0 Then
                Me.Value = Me.Value - 2.5F
            Else
                Me.Value = Me.Value + 2.5F
            End If
        End If
    End Sub

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

