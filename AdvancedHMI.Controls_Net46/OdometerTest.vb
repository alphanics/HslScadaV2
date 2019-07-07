Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class OdometerTest
    Inherits Control
    Private bitmap_0 As Bitmap

    Private list_0 As List(Of RollingDigit)

    Private bool_0 As Boolean

    Private double_0 As Double

    Private int_0 As Integer

    Private int_1 As Integer

    Private color_0 As Color

    Private color_1 As Color

    Public Overrides Property BackColor As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            Dim num As Integer = 0
            MyBase.BackColor = value
            While num < Me.list_0.Count - Me.int_1
                Me.list_0(num).BackColor = value
                num = num + 1
            End While
        End Set
    End Property

    Public Property BackColorAfterDecimal As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (Me.color_0 <> value) Then
                Me.color_0 = value
                Me.method_2()
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Overrides Property Font As System.Drawing.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As System.Drawing.Font)
            Dim num As Integer = 0
            MyBase.Font = value
            While num < Me.list_0.Count
                Me.list_0(num).Font = value
                num = num + 1
            End While
        End Set
    End Property

    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            Dim num As Integer = 0
            MyBase.ForeColor = value
            While num < Me.list_0.Count - Me.int_1
                Me.list_0(num).ForeColor = value
                num = num + 1
            End While
        End Set
    End Property

    Public Property ForeColorAfterDecimal As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            If (Me.color_1 <> value) Then
                Me.color_1 = value
                Me.method_2()
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property NumberOfDigits As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (Me.int_0 <> value) Then
                Me.int_0 = value
                While Me.list_0.Count > Me.int_0
                    Me.list_0(Me.list_0.Count - 1).Dispose()
                    Me.list_0.RemoveAt(Me.list_0.Count - 1)
                End While
                While Me.list_0.Count < Me.int_0
                    Me.list_0.Add(New RollingDigit())
                    Me.list_0(Me.list_0.Count - 1).Font = Me.Font
                End While
                Me.method_2()
                Me.method_1()
                Me.method_0()
            End If
        End Set
    End Property

    Public Property NumberOfDigitsAfterDecimal As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            If (Me.int_1 <> value) Then
                Me.int_1 = Math.Min(value, Me.int_0)
                Me.method_2()
                Me.method_0()
            End If
        End Set
    End Property

    Public Property Value As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            If (value <> Me.double_0) Then
                Me.double_0 = Math.Min(value, Math.Pow(10, CDbl((Me.int_0 - Me.int_1))) - 1 / Math.Pow(10, CDbl(Me.int_1)))
                Me.method_0()
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.int_1 = 1
        Me.color_0 = Color.FromArgb(255, 64, 64, 64)
        Me.color_1 = Color.White
        MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.list_0 = New List(Of RollingDigit)()
        Me.NumberOfDigits = 5
        Me.BackColor = Color.White
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If (disposing) Then
            While Me.list_0.Count > 0
                Me.list_0(0).Dispose()
                Me.list_0.RemoveAt(0)
            End While
            If (Me.bitmap_0 IsNot Nothing) Then
                Me.bitmap_0.Dispose()
            End If
        End If
    End Sub

    Private Sub method_0()
    End Sub

    Private Sub method_1()
    End Sub

    Private Sub method_2()
    End Sub
End Class
