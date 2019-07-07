Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class SimpleLedMatrixArray
    Inherits Panel
    Private string_0 As String

    Private int_0 As Integer

    Private int_1 As Integer

    Private int_2 As Integer

    Private string_1 As String

    Private int_3 As Integer

    Private int_4 As Integer

    Private int_5 As Integer

    Private bool_0 As Boolean

    <Browsable(False)>
    Public Overrides Property AutoSize As Boolean
        Get
            Return MyBase.AutoSize
        End Get
        Set(ByVal value As Boolean)
            If (MyBase.AutoSize <> value) Then
                MyBase.AutoSize = value
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Overrides Property AutoSizeMode As System.Windows.Forms.AutoSizeMode
        Get
            Return MyBase.AutoSizeMode
        End Get
        Set(ByVal value As System.Windows.Forms.AutoSizeMode)
            If (MyBase.AutoSizeMode <> value) Then
                MyBase.AutoSizeMode = value
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(0)>
    <Description("Opacity value for inactive dots on the matrix display (valid values 0 to 255).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property DM_MatrixAlpha As Integer
        Get
            Return Me.int_5
        End Get
        Set(ByVal value As Integer)
            Dim enumerator As IEnumerator = Nothing
            If (value < 0) Then
                value = 0
            End If
            If (value > 255) Then
                value = 255
            End If
            If (Me.int_5 <> value) Then
                Me.int_5 = value
                Try
                    enumerator = MyBase.Controls.GetEnumerator()
                    While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDMatrix).DM_Alpha = Me.int_5
                    End While
                Finally
                    If (TypeOf enumerator Is IDisposable) Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
            End If
            MyBase.Invalidate()
        End Set
    End Property

    <Browsable(True)>
    <Description("Single matrix cell height (SizeScaleCoefficient * single matrix width).")>
    <RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property DM_MatrixCellHeight As Integer
        Get
            Dim num As Integer = CInt(Math.Round(CDbl((CSng(Me.int_3) * 1.76296294!))))
            Return num
        End Get
    End Property

    <Browsable(True)>
    <DefaultValue(10)>
    <Description("Number of matrix cells in array (valid values 2 to 60).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property DM_MatrixCells As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            If (value < 2) Then
                value = 2
            End If
            If (value > 60) Then
                value = 60
            End If
            If (Me.int_1 <> value) Then
                Me.string_0 = Me.string_1
                Me.Value = String.Empty
                Me.int_0 = Me.int_1
                Me.int_1 = value
                If (Me.int_1 <= Me.int_0) Then
                    Dim int0 As Integer = Me.int_0 - Me.int_1
                    For i As Integer = 1 To int0 Step 1
                        Me.method_1()
                    Next

                Else
                    Dim int1 As Integer = Me.int_1 - Me.int_0
                    For j As Integer = 1 To int1 Step 1
                        Me.method_0()
                    Next

                End If
            End If
            MyBase.Invalidate()

        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(6)>
    <Description("Spacing between individual matrix cells (valid values 2 to 20).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property DM_MatrixCellSpacing As Integer
        Get
            Return Me.int_4
        End Get
        Set(ByVal value As Integer)
            If (value < 2) Then
                value = 2
            End If
            If (value > 20) Then
                value = 20
            End If
            If (Me.int_4 <> value) Then
                Me.string_0 = Me.string_1
                Me.Value = String.Empty
                Me.int_4 = value
                Me.method_2()
            End If
            MyBase.Invalidate()
            RaiseEvent PropertyChanged()
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(24)>
    <Description("Single matrix cell width (valid values 24 to 300).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property DM_MatrixCellWidth As Integer
        Get
            Return Me.int_3
        End Get
        Set(ByVal value As Integer)
            If (value < 22) Then
                value = 22
            End If
            If (value > 300) Then
                value = 300
            End If
            If (Me.int_3 <> value) Then
                Me.string_0 = Me.string_1
                Me.Value = String.Empty
                Me.int_3 = value
                Me.method_2()
            End If
            MyBase.Invalidate()
            RaiseEvent PropertyChanged()
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(False)>
    <Description("Show inactive matrix dots.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property DM_ShowInactiveDots As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            Dim enumerator As IEnumerator = Nothing
            If (Me.bool_0 <> value) Then
                Me.bool_0 = value
                Try
                    enumerator = MyBase.Controls.GetEnumerator()
                    While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDMatrix).DM_ShowInactiveDots = Me.bool_0
                    End While
                Finally
                    If (TypeOf enumerator Is IDisposable) Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Description("Constant value used to maintain the ratio between width and height of each matrix cell.")>
    <RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property DM_SizeScaleCoefficient As Single
        Get
            Return 1.76296294!
        End Get
    End Property

    <Browsable(True)>
    <DefaultValue(GetType(Color), "Red")>
    <Description("Color of matrix LEDs.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            Dim enumerator As IEnumerator = Nothing
            If (MyBase.ForeColor <> value) Then
                MyBase.ForeColor = value
                Try
                    enumerator = MyBase.Controls.GetEnumerator()
                    While enumerator.MoveNext()
                        DirectCast(enumerator.Current, SimpleLEDMatrix).ForeColor = MyBase.ForeColor
                    End While
                Finally
                    If (TypeOf enumerator Is IDisposable) Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue("LED Matrix")>
    <Description("Any string composed of standard keyboard characters.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Value As String
        Get
            Return Me.string_1
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Sub New()
        MyBase.New()
        AddHandler Me.PropertyChanged, New SimpleLedMatrixArray.Delegate0(AddressOf Me.method_3)
        Me.int_1 = 10
        Me.string_1 = "LED Matrix"
        Me.int_3 = 24
        Me.int_4 = 6
        MyBase.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.ForeColor = Color.Red
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Dim int1 As Integer = Me.int_1
        Dim num As Integer = 1
        Do
            Me.method_0()
            num = num + 1
        Loop While num <= int1
        Me.Value = Me.string_1
    End Sub

    Private Function method_0() As SimpleLEDMatrix
        Dim simpleLEDMatrix As SimpleLEDMatrix = New SimpleLEDMatrix()
        MyBase.Controls.Add(simpleLEDMatrix)
        simpleLEDMatrix.Width = Me.int_3
        simpleLEDMatrix.Top = 4
        simpleLEDMatrix.Left = (MyBase.Controls.Count - 1) * (Me.int_3 + Me.int_4) + 4
        simpleLEDMatrix.Text = String.Empty
        simpleLEDMatrix.Value = Strings.ChrW(0)
        simpleLEDMatrix.ForeColor = Me.ForeColor
        simpleLEDMatrix.DM_Alpha = Me.int_5
        simpleLEDMatrix.DM_ShowInactiveDots = Me.bool_0
        Return simpleLEDMatrix
    End Function

    Private Sub method_1()
        If (MyBase.Controls.Count > 0) Then
            MyBase.Controls.Remove(DirectCast(MyBase.Controls(MyBase.Controls.Count - 1), SimpleLEDMatrix))
        End If
    End Sub

    Private Sub method_2()
        Dim int1 As Integer = Me.int_1
        Dim num As Integer = 1
        Do
            Me.method_1()
            num = num + 1
        Loop While num <= int1
        Dim int11 As Integer = Me.int_1
        For i As Integer = 1 To int11 Step 1
            Me.method_0()
        Next

    End Sub

    Private Sub method_3()
        If (Operators.CompareString(Me.string_0, Nothing, False) <> 0) Then
            Me.Value = Me.string_0
        End If
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        MyBase.Invalidate()
    End Sub

    Private Event PropertyChanged As Delegate0


    Public Event ValueChanged As EventHandler


    Private Delegate Sub Delegate0()
End Class
