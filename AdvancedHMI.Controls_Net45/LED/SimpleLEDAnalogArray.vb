Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class SimpleLEDAnalogArray
    Inherits Control



    Private _border As Boolean

    Private _borderColor As Color

    Private _LEDColor As SimpleLEDAnalog.LED_Col

    Private currentLEDNum As Integer

    Private _LEDNumber As Integer

    Private _orientation As SimpleLEDAnalogArray.LED_Dir

    Private m_Value As Single

    Private m_showValue As Boolean

    Private m_Maximum As Single

    Private m_Minimum As Single

    Private _LEDwidth As Integer

    <Browsable(True), DefaultValue(0), Description("Set LEDs array orientation (Horizontal or Vertical)."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_ArrayOrientation() As SimpleLEDAnalogArray.LED_Dir
        Get
            Return Me._orientation
        End Get
        Set(ByVal value As SimpleLEDAnalogArray.LED_Dir)
            If Me._orientation <> value Then
                Me._orientation = value
                Me.AddRemoveAll()
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
                        DirectCast(enumerator.Current, SimpleLEDAnalog).LED_Border = Me._border
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
                        DirectCast(enumerator.Current, SimpleLEDAnalog).LED_BorderColor = Me._borderColor
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

    <Browsable(True), DefaultValue(0), Description("Color of all LEDs."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_Color() As SimpleLEDAnalog.LED_Col
        Get
            Return Me._LEDColor
        End Get
        Set(ByVal value As SimpleLEDAnalog.LED_Col)
            Dim enumerator As IEnumerator = Nothing
            If Me._LEDColor <> value Then
                Me._LEDColor = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDAnalog).LED_Color = Me._LEDColor
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
                        Me.AddNewSimpleLEDAnalog()
                        Me.SimpleLEDArray_Resize(Me, Nothing)
                    Next j
                End If
            End If
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), DefaultValue(False), Description("Show the current analog value on the LED itself (also controlled by the mouse DoubleClick event)."), RefreshProperties(RefreshProperties.All)>
    Public Property LED_ShowValue() As Boolean
        Get
            Return Me.m_showValue
        End Get
        Set(ByVal value As Boolean)
            Dim enumerator As IEnumerator = Nothing
            If Me.m_showValue <> value Then
                Me.m_showValue = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDAnalog).LED_ShowValue = Me.m_showValue
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
            Dim enumerator As IEnumerator = Nothing
            If Not Versioned.IsNumeric(value) Then
                value = 0.0F
            End If
            If Me.m_Maximum <> value Then
                Me.m_Maximum = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDAnalog).Maximum = Me.m_Maximum
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

    <Browsable(True), DefaultValue(0.0F), Description("Minimum LED analog value (needs to be at least 5 lower than the Maximum)."), RefreshProperties(RefreshProperties.All)>
    Public Property Minimum() As Single
        Get
            Return Me.m_Minimum
        End Get
        Set(ByVal value As Single)
            Dim enumerator As IEnumerator = Nothing
            If Not Versioned.IsNumeric(value) Then
                value = 0.0F
            End If
            If Me.m_Minimum <> value Then
                Me.m_Minimum = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDAnalog).Minimum = Me.m_Minimum
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

    <Browsable(True), DefaultValue(0.0F), Description("Set LED analog value."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As Single
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Single)
            Dim enumerator As IEnumerator = Nothing
            If Not Versioned.IsNumeric(value) Then
                value = Me.m_Minimum
            End If
            If Me.m_Value <> value Then
                Me.m_Value = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDAnalog).Value = Me.m_Value
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


    Public Sub New()
        Dim simpleLEDAnalogArray As SimpleLEDAnalogArray = Me
        AddHandler MyBase.Resize, AddressOf simpleLEDAnalogArray.SimpleLEDArray_Resize

        Me._borderColor = Color.MediumSeaGreen
        Me._LEDColor = SimpleLEDAnalog.LED_Col.Red
        Me._LEDNumber = 2
        Me._orientation = SimpleLEDAnalogArray.LED_Dir.Horizontal
        Me.m_Maximum = 255.0F
        Me._LEDwidth = 30
        Me.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        Me.Size = New Size(60, 30)
        Me.BackColor = Color.Transparent
        Dim num As Integer = Me._LEDNumber
        For i As Integer = 1 To num
            Me.AddNewSimpleLEDAnalog()
        Next i
    End Sub



    Private Function AddNewSimpleLEDAnalog() As SimpleLEDAnalog
        Dim simpleLEDAnalog As New SimpleLEDAnalog()
        Me.Controls.Add(simpleLEDAnalog)
        simpleLEDAnalog.Size = New Size(Me._LEDwidth, Me._LEDwidth)
        If Me._orientation <> SimpleLEDAnalogArray.LED_Dir.Horizontal Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: simpleLEDAnalog.Top = checked((checked(this.Controls.Count - 1)) * this._LEDwidth);
            simpleLEDAnalog.Top = (Me.Controls.Count - 1) * Me._LEDwidth
            simpleLEDAnalog.Left = 0
        Else
            simpleLEDAnalog.Top = 0
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: simpleLEDAnalog.Left = checked((checked(this.Controls.Count - 1)) * this._LEDwidth);
            simpleLEDAnalog.Left = (Me.Controls.Count - 1) * Me._LEDwidth
        End If
        simpleLEDAnalog.Value = Me.m_Value
        simpleLEDAnalog.Text = String.Empty
        simpleLEDAnalog.LED_Color = Me._LEDColor
        simpleLEDAnalog.LED_Border = Me._border
        simpleLEDAnalog.LED_BorderColor = Me._borderColor
        simpleLEDAnalog.LED_ShowValue = Me.m_showValue
        simpleLEDAnalog.Minimum = Me.m_Minimum
        simpleLEDAnalog.Maximum = Me.m_Maximum
        Return simpleLEDAnalog
    End Function

    Private Sub AddRemoveAll()
        Dim num As Integer = Me._LEDNumber
        For i As Integer = 1 To num
            Me.Remove()
        Next i
        Dim num1 As Integer = Me._LEDNumber
        For j As Integer = 1 To num1
            Me.AddNewSimpleLEDAnalog()
            Me.SimpleLEDArray_Resize(Me, Nothing)
        Next j
    End Sub

    Private Sub Remove()
        If Me.Controls.Count > 0 Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Controls.Remove((SimpleLEDAnalog)this.Controls[checked(this.Controls.Count - 1)]);
            Me.Controls.Remove(DirectCast(Me.Controls(Me.Controls.Count - 1), SimpleLEDAnalog))
        End If
    End Sub

    Private Sub SimpleLEDArray_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If Me._orientation <> SimpleLEDAnalogArray.LED_Dir.Horizontal Then
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

    Public Enum LED_Dir
        Horizontal
        Vertical
    End Enum
End Class

