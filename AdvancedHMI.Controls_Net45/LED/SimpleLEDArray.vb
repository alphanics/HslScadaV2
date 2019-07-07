Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class SimpleLEDArray
    Inherits Control

    Private _BlinkTimer As Timer

    Private _border As Boolean

    Private _borderColor As Color

    Private _LEDColor As SimpleLEDArray.LED_Col

    Private _LEDBrightness As SimpleLEDArray.LED_Bri

    Private currentLEDNum As Integer

    Private _LEDNumber As Integer

    Private _orientation As SimpleLEDArray.LED_Dir

    Private m_Value As Integer

    Private _blinkInterval As Integer

    Private _LEDwidth As Integer

    Private flagTimer As Boolean

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
    '        SimpleLEDArray simpleLEDArray = this;
    '        EventHandler eventHandler = new EventHandler(simpleLEDArray.BlinkTimer_Tick);
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

    <Browsable(True), DefaultValue(0), Description("Set LEDs array orientation (Horizontal or Vertical)."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_ArrayOrientation() As SimpleLEDArray.LED_Dir
        Get
            Return Me._orientation
        End Get
        Set(ByVal value As SimpleLEDArray.LED_Dir)
            If Me._orientation <> value Then
                Me._orientation = value
                Me.AddRemoveAll()
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(500), Description("LEDs blinking interval in milliseconds."), RefreshProperties(RefreshProperties.All)>
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
                Me._BlinkTimer.Interval = Me._blinkInterval
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(False), Description("Enable border on each LED."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_Border() As Boolean
        Get
            Return Me._border
        End Get
        Set(ByVal value As Boolean)
            Dim enumerator As IEnumerator = Nothing
            If Me._border <> value Then
                Me._border = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLED).LED_Border = Me._border
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
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
            Dim enumerator As IEnumerator = Nothing
            If Me._borderColor <> value Then
                Me._borderColor = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLED).LED_BorderColor = Me._borderColor
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(0), Description("LEDs brightness.")>
    Public Property LED_Brightness() As SimpleLEDArray.LED_Bri
        Get
            Return Me._LEDBrightness
        End Get
        Set(ByVal value As SimpleLEDArray.LED_Bri)
            Dim enumerator As IEnumerator = Nothing
            If Me._LEDBrightness <> value Then
                Me._LEDBrightness = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLED).LED_Brightness = CType(Me._LEDBrightness, SimpleLED.LED_Bri)
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
            End If
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), DefaultValue(0), Description("Color of all LEDs."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_Color() As SimpleLEDArray.LED_Col
        Get
            Return Me._LEDColor
        End Get
        Set(ByVal value As SimpleLEDArray.LED_Col)
            Dim enumerator As IEnumerator = Nothing
            If Me._LEDColor <> value Then
                Me._LEDColor = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLED).LED_Color = CType(Me._LEDColor, SimpleLED.LED_Col)
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(2), Description("Number of LEDs in array (valid values 2 to 30)."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_NumberOfLEDs() As Integer
        Get
            Return Me._LEDNumber
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 2
            End If
            If value < 2 Then
                value = 2
            End If
            If value > 30 Then
                value = 30
            End If
            If Me._LEDNumber <> value Then
                Me.currentLEDNum = Me._LEDNumber
                Me._LEDNumber = value
                If Me._LEDNumber <= Me.currentLEDNum Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: int num = checked(this.currentLEDNum - this._LEDNumber);
                    Dim num As Integer = Me.currentLEDNum - Me._LEDNumber
                    For i As Integer = 1 To num
                        Me.Remove()
                        Me.SimpleLEDArray_Resize(Me, Nothing)
                    Next i
                Else
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: int num1 = checked(this._LEDNumber - this.currentLEDNum);
                    Dim num1 As Integer = Me._LEDNumber - Me.currentLEDNum
                    For j As Integer = 1 To num1
                        Me.AddNewSimpleLED()
                        Me.SimpleLEDArray_Resize(Me, Nothing)
                    Next j
                End If
            End If
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), Description("Single LED height (the same as LED width)."), RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property LED_SingleLEDHeight() As Integer
        Get
            Return Me._LEDwidth
        End Get
    End Property

    <Browsable(True), DefaultValue(30), Description("Single LED width (valid values 30 to 360)."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_SingleLEDWidth() As Integer
        Get
            Return Me._LEDwidth
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 30
            End If
            If value < 30 Then
                value = 30
            End If
            If value > 360 Then
                value = 360
            End If
            If Me._LEDwidth <> value Then
                Me._LEDwidth = value
                Me.AddRemoveAll()
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

    <Browsable(True), DefaultValue(0), Description("Set LEDs to OFF/ON/BLINK state (valid values 0, 1 and 2 respectively)."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As Integer
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Integer)
            Dim enumerator As IEnumerator = Nothing
            If Not Versioned.IsNumeric(value) Then
                value = 0
            End If
            If value < 0 Then
                value = 0
            End If
            If value > 2 Then
                value = 2
            End If
            If Me.m_Value <> value Then
                Me.m_Value = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        Dim current As SimpleLED = DirectCast(enumerator.Current, SimpleLED)
                        current.LED_BlinkInterval = Me._blinkInterval
                        If (If(Me.m_Value = 0 OrElse Me.m_Value = 1, False, True)) Then
                            Me.flagTimer = False
                            Me._BlinkTimer.Enabled = True
                        Else
                            current.LED_Blink = False
                            current.Value = Me.m_Value <> 0
                            Me._BlinkTimer.Enabled = False
                        End If
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
            End If
            Me.Invalidate()
        End Set
    End Property



    Public Sub New()
        Dim simpleLEDArray As SimpleLEDArray = Me
        AddHandler MyBase.Resize, AddressOf simpleLEDArray.SimpleLEDArray_Resize

        Me._borderColor = Color.MediumSeaGreen
        Me._LEDColor = SimpleLEDArray.LED_Col.Red
        Me._LEDBrightness = SimpleLEDArray.LED_Bri.Normal
        Me._LEDNumber = 2
        Me._orientation = SimpleLEDArray.LED_Dir.Horizontal
        Me._blinkInterval = 500
        Me._LEDwidth = 30
        Me.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        Me.Size = New Size(60, 30)
        Me.BackColor = Color.Transparent
        Me._BlinkTimer = New Timer() With {
         .Interval = Me._blinkInterval,
         .Enabled = False
        }
        Dim num As Integer = Me._LEDNumber
        For i As Integer = 1 To num
            Me.AddNewSimpleLED()
        Next i
    End Sub


    Private Function AddNewSimpleLED() As SimpleLED
        Dim simpleLED As New SimpleLED()
        Me.Controls.Add(simpleLED)
        simpleLED.Size = New Size(Me._LEDwidth, Me._LEDwidth)
        If Me._orientation <> SimpleLEDArray.LED_Dir.Horizontal Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: simpleLED.Top = checked((checked(this.Controls.Count - 1)) * this._LEDwidth);
            simpleLED.Top = (Me.Controls.Count - 1) * Me._LEDwidth
            simpleLED.Left = 0
        Else
            simpleLED.Top = 0
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: simpleLED.Left = checked((checked(this.Controls.Count - 1)) * this._LEDwidth);
            simpleLED.Left = (Me.Controls.Count - 1) * Me._LEDwidth
        End If
        If Me.m_Value <> 2 Then
            simpleLED.Value = Me.m_Value <> 0
        End If
        simpleLED.LED_Blink = False
        simpleLED.Text = String.Empty
        simpleLED.LED_Color = CType(Me._LEDColor, SimpleLED.LED_Col)
        simpleLED.LED_Brightness = CType(Me._LEDBrightness, SimpleLED.LED_Bri)
        simpleLED.LED_Border = Me._border
        simpleLED.LED_BorderColor = Me._borderColor
        Return simpleLED
    End Function

    Private Sub AddRemoveAll()
        Dim num As Integer = Me._LEDNumber
        For i As Integer = 1 To num
            Me.Remove()
        Next i
        Dim num1 As Integer = Me._LEDNumber
        For j As Integer = 1 To num1
            Me.AddNewSimpleLED()
            Me.SimpleLEDArray_Resize(Me, Nothing)
        Next j
    End Sub

    Private Sub BlinkTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim enumerator As IEnumerator = Nothing
        Try
            enumerator = Me.Controls.GetEnumerator()
            Do While enumerator.MoveNext()
                Dim current As SimpleLED = DirectCast(enumerator.Current, SimpleLED)
                current.LED_Blink = False
                If Me.flagTimer Then
                    current.Value = False
                Else
                    current.Value = True
                End If
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Me.flagTimer = Not Me.flagTimer
    End Sub

    Private Sub Remove()
        If Me.Controls.Count > 0 Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Controls.Remove((SimpleLED)this.Controls[checked(this.Controls.Count - 1)]);
            Me.Controls.Remove(DirectCast(Me.Controls(Me.Controls.Count - 1), SimpleLED))
        End If
    End Sub

    Private Sub SimpleLEDArray_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If Me._orientation <> SimpleLEDArray.LED_Dir.Horizontal Then
            Me.Width = Me._LEDwidth
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Height = checked(this._LEDNumber * this._LEDwidth);
            Me.Height = Me._LEDNumber * Me._LEDwidth
        Else
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Width = checked(this._LEDNumber * this._LEDwidth);
            Me.Width = Me._LEDNumber * Me._LEDwidth
            Me.Height = Me._LEDwidth
        End If
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

    Public Enum LED_Dir
        Horizontal
        Vertical
    End Enum
End Class

