Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class AnimatingPictureBox
    Inherits PictureBox
    Private rotationScale_0 As RotationScale

    Private float_0 As Single

    Private translationScale_0 As TranslationScale

    Private int_0 As Integer

    Private translationScale_1 As TranslationScale

    Private int_1 As Integer

    Private translationScale_2 As TranslationScale

    Private double_0 As Double

    Private translationScale_3 As TranslationScale

    Private double_1 As Double

    Private point_0 As Point

    Private int_2 As Integer

    Private int_3 As Integer

    Private bitmap_0 As Bitmap

    Private matrix_0 As Matrix

    Private rectangle_0 As Rectangle

    Public Property ImageRotationScale As RotationScale
        Get
            Return Me.rotationScale_0
        End Get
        Set(ByVal value As RotationScale)
            Me.rotationScale_0 = value
        End Set
    End Property

    Public Property ImageRotationValue As Single
        Get
            Return Me.float_0
        End Get
        Set(ByVal value As Single)
            If (Me.float_0 <> value) Then
                Me.float_0 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property ImageSizeXScale As TranslationScale
        Get
            Return Me.translationScale_2
        End Get
        Set(ByVal value As TranslationScale)
            Me.translationScale_2 = value
        End Set
    End Property

    Public Property ImageSizeXValue As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            If (Me.double_0 <> value) Then
                Me.double_0 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property ImageSizeYScale As TranslationScale
        Get
            Return Me.translationScale_3
        End Get
        Set(ByVal value As TranslationScale)
            Me.translationScale_3 = value
        End Set
    End Property

    Public Property ImageSizeYValue As Double
        Get
            Return Me.double_1
        End Get
        Set(ByVal value As Double)
            If (Me.double_1 <> value) Then
                Me.double_1 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property ImageTranslateXScale As TranslationScale
        Get
            Return Me.translationScale_0
        End Get
        Set(ByVal value As TranslationScale)
            Me.translationScale_0 = value
        End Set
    End Property

    Public Property ImageTranslateXValue As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (Me.int_0 <> value) Then
                Me.int_0 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property ImageTranslateYScale As TranslationScale
        Get
            Return Me.translationScale_1
        End Get
        Set(ByVal value As TranslationScale)
            Me.translationScale_1 = value
        End Set
    End Property

    Public Property ImageTranslateYValue As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            If (Me.int_1 <> value) Then
                Me.int_1 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Shadows Property Location As Point
        Get
            Return Me.point_0
        End Get
        Set(ByVal value As Point)
            Me.point_0 = value
            MyBase.SetBounds(Me.point_0.X + Me.int_2, Me.point_0.Y, MyBase.Width, MyBase.Height, BoundsSpecified.Location)
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Property LocationOffsetX As Integer
        Get
            Return Me.int_2
        End Get
        Set(ByVal value As Integer)
            If (Me.int_2 <> value) Then
                Me.int_2 = value
                MyBase.SetBounds(Me.point_0.X + Me.int_2, Me.point_0.Y, MyBase.Width, MyBase.Height, BoundsSpecified.Location)
            End If
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Property LocationOffsetY As Integer
        Get
            Return Me.int_3
        End Get
        Set(ByVal value As Integer)
            If (Me.int_3 <> value) Then
                Me.int_3 = value
                MyBase.SetBounds(Me.point_0.X + Me.int_2, Me.point_0.Y + Me.int_3, MyBase.Width, MyBase.Height, BoundsSpecified.Location)
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.rotationScale_0 = New RotationScale()
        Me.translationScale_0 = New TranslationScale()
        Me.translationScale_1 = New TranslationScale()
        Me.double_0 = 1
        Me.double_1 = 1
        Me.matrix_0 = New Matrix()
        Me.BackColor = Color.Transparent
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.translationScale_2 = New TranslationScale() With
        {
            .InputMaxValue = 1,
            .OutputMaxValue = 1,
            .ErrorValue = 1
        }
        Me.translationScale_3 = New TranslationScale() With
        {
            .InputMaxValue = 1,
            .OutputMaxValue = 1,
            .ErrorValue = 1
        }
    End Sub

    Private Sub method_0()
        Dim num As Integer = 0
        Dim num1 As Integer = 0
        If (MyBase.Image IsNot Nothing) Then
            If (If(Me.bitmap_0 Is Nothing OrElse Me.bitmap_0.Width <> MyBase.Image.Width, True, Me.bitmap_0.Height <> MyBase.Image.Height)) Then
                Me.bitmap_0 = New Bitmap(MyBase.Width, MyBase.Height)
                Me.bitmap_0.SetResolution(MyBase.Image.HorizontalResolution, MyBase.Image.VerticalResolution)
            End If
            If (Me.translationScale_0 IsNot Nothing) Then
                num = CInt(Math.Round(Me.translationScale_0.GetValue(CDbl(Me.int_0))))
            End If
            If (Me.translationScale_1 IsNot Nothing) Then
                num1 = CInt(Math.Round(Me.translationScale_0.GetValue(CDbl(Me.int_1))))
            End If
            Me.rectangle_0 = New Rectangle(0, 0, MyBase.Width, MyBase.Height)
            Using matrix0 As Graphics = Graphics.FromImage(Me.bitmap_0)
                Me.matrix_0.Reset()
                matrix0.Clear(Color.Transparent)
                Dim value As Double = Me.translationScale_2.GetValue(Me.double_0)
                Dim value1 As Double = Me.translationScale_3.GetValue(Me.double_1)
                If (value = 0) Then
                    value = 1
                End If
                If (value1 = 0) Then
                    value1 = 1
                End If
                Me.matrix_0.RotateAt(Me.ImageRotationScale.GetAngle(Me.float_0), New Point(CInt(Math.Round(CDbl(MyBase.Width) / 2 + CDbl(Me.ImageRotationScale.XPosition) * value + CDbl(num) * value)), CInt(Math.Round(CDbl(MyBase.Height) / 2 + CDbl(Me.ImageRotationScale.YPosition) * value1 + CDbl(num1) * value1))))
                Me.matrix_0.Translate(CSng(((CDbl(MyBase.Width) - CDbl(MyBase.Image.Width) * value) / 2)), CSng(((CDbl(MyBase.Height) - CDbl(MyBase.Image.Height) * value1) / 2)))
                Me.matrix_0.Scale(CSng(value), CSng(value1))
                matrix0.Transform = Me.matrix_0
                matrix0.DrawImage(MyBase.Image, New Point(num, num1))
            End Using
        End If
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim rectangle As System.Drawing.Rectangle
        Dim flag As Boolean
        Dim flag1 As Boolean
        Try
            If (MyBase.Image Is Nothing) Then
                flag = False
            ElseIf (Me.bitmap_0 Is Nothing) Then
                flag = True
            Else
                Dim rectangle0 As System.Drawing.Rectangle = Me.rectangle_0
                rectangle = New System.Drawing.Rectangle()
                flag = rectangle0 = rectangle
            End If
            If (flag) Then
                Me.method_0()
            End If
            If (Me.bitmap_0 Is Nothing) Then
                flag1 = False
            Else
                Dim rectangle01 As System.Drawing.Rectangle = Me.rectangle_0
                rectangle = New System.Drawing.Rectangle()
                flag1 = rectangle01 <> rectangle
            End If
            If (flag1) Then
                painte.Graphics.DrawImage(Me.bitmap_0, Me.rectangle_0)
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        Me.method_0()
        MyBase.OnSizeChanged(e)
    End Sub
End Class
