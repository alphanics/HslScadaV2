Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class SimpleLEDMatrixArray
    Inherits Panel



    Private _LEDColor As Color

    Private savedValue As String

    Private currentLEDMatrixNum As Integer

    Private _LEDMatrixNumber As Integer

    Private i As Integer

    Private m_Value As String

    Private _LEDMatrixWidth As Integer

    Private m_cellSpacing As Integer

    Private m_alpha As Integer

    <Browsable(False)>
    Public Overrides Property AutoSize() As Boolean
        Get
            Return MyBase.AutoSize
        End Get
        Set(ByVal value As Boolean)
            If MyBase.AutoSize <> value Then
                MyBase.AutoSize = value
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Overrides Property AutoSizeMode() As AutoSizeMode
        Get
            Return MyBase.AutoSizeMode
        End Get
        Set(ByVal value As AutoSizeMode)
            If MyBase.AutoSizeMode <> value Then
                MyBase.AutoSizeMode = value
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(GetType(Color), "Red"), Description("Color of matrix LEDs."), RefreshProperties(RefreshProperties.All)>
    Public Property DM_LEDColor() As Color
        Get
            Return Me._LEDColor
        End Get
        Set(ByVal value As Color)
            Dim enumerator As IEnumerator = Nothing
            If Me._LEDColor <> value Then
                Me._LEDColor = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDMatrix).ForeColor = Me._LEDColor
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

    <Browsable(True), DefaultValue(0), Description("Opacity value for inactive dots on the matrix display (valid values 0 to 255)."), RefreshProperties(RefreshProperties.All)>
    Public Property DM_MatrixAlpha() As Integer
        Get
            Return Me.m_alpha
        End Get
        Set(ByVal value As Integer)
            Dim enumerator As IEnumerator = Nothing
            If Not Versioned.IsNumeric(value) Then
                value = 0
            End If
            If value < 0 Then
                value = 0
            End If
            If value > 255 Then
                value = 255
            End If
            If Me.m_alpha <> value Then
                Me.m_alpha = value
                Try
                    enumerator = Me.Controls.GetEnumerator()
                    Do While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDMatrix).DM_Alpha = Me.m_alpha
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

    <Browsable(True), Description("Single matrix cell height (SizeScaleCoefficient * single matrix width)."), RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property DM_MatrixCellHeight() As Integer
        Get
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: int num = checked((int)Math.Round((double)((float)((float)this._LEDMatrixWidth * 1.76296294f))));
            Dim num As Integer = CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me._LEDMatrixWidth) * 1.76296294F)))))
            Return num
        End Get
    End Property

    <Browsable(True), DefaultValue(2), Description("Number of matrix cells in array (valid values 2 to 30)."), RefreshProperties(RefreshProperties.All)>
    Public Property DM_MatrixCells() As Integer
        Get
            Return Me._LEDMatrixNumber
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
            If Me._LEDMatrixNumber <> value Then
                Me.savedValue = Me.m_Value
                Me.Value = String.Empty
                Me.currentLEDMatrixNum = Me._LEDMatrixNumber
                Me._LEDMatrixNumber = value
                If Me._LEDMatrixNumber <= Me.currentLEDMatrixNum Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: int num = checked(this.currentLEDMatrixNum - this._LEDMatrixNumber);
                    Dim num As Integer = Me.currentLEDMatrixNum - Me._LEDMatrixNumber
                    For i As Integer = 1 To num
                        Me.Remove()
                    Next i
                Else
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: int num1 = checked(this._LEDMatrixNumber - this.currentLEDMatrixNum);
                    Dim num1 As Integer = Me._LEDMatrixNumber - Me.currentLEDMatrixNum
                    For j As Integer = 1 To num1
                        Me.AddNewSimpleLEDMatrix()
                    Next j
                End If
            End If
            Me.Invalidate()
            Dim propertyChangedEventHandler As SimpleLEDMatrixArray.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If propertyChangedEventHandler IsNot Nothing Then
                propertyChangedEventHandler()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(6), Description("Spacing between individual matrix cells (valid values 2 to 20)."), RefreshProperties(RefreshProperties.All)>
    Public Property DM_MatrixCellSpacing() As Integer
        Get
            Return Me.m_cellSpacing
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 6
            End If
            If value < 2 Then
                value = 2
            End If
            If value > 20 Then
                value = 20
            End If
            If Me.m_cellSpacing <> value Then
                Me.savedValue = Me.m_Value
                Me.Value = String.Empty
                Me.m_cellSpacing = value
                Me.AddRemoveAll()
            End If
            Me.Invalidate()
            Dim propertyChangedEventHandler As SimpleLEDMatrixArray.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If propertyChangedEventHandler IsNot Nothing Then
                propertyChangedEventHandler()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(28), Description("Single matrix cell width (valid values 28 to 300)."), RefreshProperties(RefreshProperties.All)>
    Public Property DM_MatrixCellWidth() As Integer
        Get
            Return Me._LEDMatrixWidth
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 28
            End If
            If value < 28 Then
                value = 28
            End If
            If value > 300 Then
                value = 300
            End If
            If Me._LEDMatrixWidth <> value Then
                Me.savedValue = Me.m_Value
                Me.Value = String.Empty
                Me._LEDMatrixWidth = value
                Me.AddRemoveAll()
            End If
            Me.Invalidate()
            Dim propertyChangedEventHandler As SimpleLEDMatrixArray.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If propertyChangedEventHandler IsNot Nothing Then
                propertyChangedEventHandler()
            End If
        End Set
    End Property

    <Browsable(True), Description("Constant value used to maintain the ratio between width and height of each matrix cell."), RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property DM_SizeScaleCoefficient() As Single
        Get
            Return 1.76296294F
        End Get
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

    <Browsable(True), DefaultValue(""), Description("Any string composed of standard keyboard characters."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As String
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As String)
            Dim enumerator As IEnumerator = Nothing
            Me.m_Value = value
            Try
                enumerator = Me.Controls.GetEnumerator()
                Do While enumerator.MoveNext()
                    Dim current As SimpleLEDMatrix = DirectCast(enumerator.Current, SimpleLEDMatrix)
                    If (If(Me.m_Value.Length = 0 OrElse Me.i = Me.m_Value.Length AndAlso Me.i < Me._LEDMatrixNumber, False, True)) Then
                        current.Value = Me.m_Value.Chars(Me.i)
                        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        'ORIGINAL LINE: this.i = checked(this.i + 1);
                        Me.i = Me.i + 1
                    Else
                        current.Value = ControlChars.NullChar
                    End If
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Me.i = 0
            Me.Invalidate()
        End Set
    End Property


    Public Sub New()
        Dim simpleLEDMatrixArray As SimpleLEDMatrixArray = Me
        AddHandler Me.PropertyChanged, AddressOf simpleLEDMatrixArray.Matrix_PropertyChanged

        Me._LEDColor = Color.Red
        Me._LEDMatrixNumber = 2
        Me.m_Value = String.Empty
        Me._LEDMatrixWidth = 28
        Me.m_cellSpacing = 6
        Me.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Dim num As Integer = Me._LEDMatrixNumber
        For i As Integer = 1 To num
            Me.AddNewSimpleLEDMatrix()
        Next i
    End Sub



    Private Function AddNewSimpleLEDMatrix() As SimpleLEDMatrix
        Dim simpleLEDMatrix As New SimpleLEDMatrix()
        Me.Controls.Add(simpleLEDMatrix)
        simpleLEDMatrix.Width = Me._LEDMatrixWidth
        simpleLEDMatrix.Top = 4
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: simpleLEDMatrix.Left = checked(checked((checked(this.Controls.Count - 1)) * (checked(this._LEDMatrixWidth + this.m_cellSpacing))) + 4);
        simpleLEDMatrix.Left = ((Me.Controls.Count - 1) * (Me._LEDMatrixWidth + Me.m_cellSpacing)) + 4
        simpleLEDMatrix.Text = String.Empty
        simpleLEDMatrix.ForeColor = Me._LEDColor
        simpleLEDMatrix.DM_Alpha = Me.m_alpha
        Return simpleLEDMatrix
    End Function

    Private Sub AddRemoveAll()
        Dim num As Integer = Me._LEDMatrixNumber
        For i As Integer = 1 To num
            Me.Remove()
        Next i
        Dim num1 As Integer = Me._LEDMatrixNumber
        For j As Integer = 1 To num1
            Me.AddNewSimpleLEDMatrix()
        Next j
    End Sub

    Private Sub Matrix_PropertyChanged()
        If Operators.CompareString(Me.savedValue, Nothing, False) <> 0 Then
            Me.Value = Me.savedValue
        End If
        Me.Invalidate()
    End Sub

    Private Sub Remove()
        If Me.Controls.Count > 0 Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Controls.Remove((SimpleLEDMatrix)this.Controls[checked(this.Controls.Count - 1)]);
            Me.Controls.Remove(DirectCast(Me.Controls(Me.Controls.Count - 1), SimpleLEDMatrix))
        End If
    End Sub

    Public Event PropertyChanged As SimpleLEDMatrixArray.PropertyChangedEventHandler

    Public Delegate Sub PropertyChangedEventHandler()
End Class

