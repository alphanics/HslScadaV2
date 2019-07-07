Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class AnimatingPictureBox
    Inherits PictureBox



    Private m_ImageRotationScale As RotationScale

    Private m_ImageRotationValue As Single

    Private m_ImageTranslateXScale As TranslationScale

    Private m_ImageTranslateXValue As Integer

    Private m_ImageTranslateYScale As TranslationScale

    Private m_ImageTranslateYValue As Integer

    Private m_ImageSizeXScale As TranslationScale

    Private m_ImageSizeXValue As Double

    Private m_ImageSizeYScale As TranslationScale

    Private m_ImageSizeYValue As Double

    Private rotatedBmp As Bitmap

    Private m As Matrix

    Private r As Rectangle

    Public Property ImageRotationScale() As RotationScale
        Get
            Return m_ImageRotationScale
        End Get
        Set(ByVal value As RotationScale)
            m_ImageRotationScale = value
        End Set
    End Property

    Public Property ImageRotationValue() As Single
        Get
            Return m_ImageRotationValue
        End Get
        Set(ByVal value As Single)
            If m_ImageRotationValue <> value Then
                m_ImageRotationValue = value
                UpdateImage()
            End If
        End Set
    End Property

    Public Property ImageSizeXScale() As TranslationScale
        Get
            Return m_ImageSizeXScale
        End Get
        Set(ByVal value As TranslationScale)
            m_ImageSizeXScale = value
        End Set
    End Property

    Public Property ImageSizeXValue() As Double
        Get
            Return m_ImageSizeXValue
        End Get
        Set(ByVal value As Double)
            If m_ImageSizeXValue <> value Then
                m_ImageSizeXValue = value
                UpdateImage()
            End If
        End Set
    End Property

    Public Property ImageSizeYScale() As TranslationScale
        Get
            Return m_ImageSizeYScale
        End Get
        Set(ByVal value As TranslationScale)
            m_ImageSizeYScale = value
        End Set
    End Property

    Public Property ImageSizeYValue() As Double
        Get
            Return m_ImageSizeYValue
        End Get
        Set(ByVal value As Double)
            If m_ImageSizeYValue <> value Then
                m_ImageSizeYValue = value
                UpdateImage()
            End If
        End Set
    End Property

    Public Property ImageTranslateXScale() As TranslationScale
        Get
            Return m_ImageTranslateXScale
        End Get
        Set(ByVal value As TranslationScale)
            m_ImageTranslateXScale = value
        End Set
    End Property

    Public Property ImageTranslateXValue() As Integer
        Get
            Return m_ImageTranslateXValue
        End Get
        Set(ByVal value As Integer)
            If m_ImageTranslateXValue <> value Then
                m_ImageTranslateXValue = value
                UpdateImage()
            End If
        End Set
    End Property

    Public Property ImageTranslateYScale() As TranslationScale
        Get
            Return m_ImageTranslateYScale
        End Get
        Set(ByVal value As TranslationScale)
            m_ImageTranslateYScale = value
        End Set
    End Property

    Public Property ImageTranslateYValue() As Integer
        Get
            Return m_ImageTranslateYValue
        End Get
        Set(ByVal value As Integer)
            If m_ImageTranslateYValue <> value Then
                m_ImageTranslateYValue = value
                UpdateImage()
            End If
        End Set
    End Property



    Public Sub New()

        m_ImageRotationScale = New RotationScale()
        m_ImageTranslateXScale = New TranslationScale()
        m_ImageTranslateYScale = New TranslationScale()
        m_ImageSizeXValue = 1
        m_ImageSizeYValue = 1
        m = New Matrix()
        BackColor = Color.Transparent
        BackgroundImageLayout = ImageLayout.Stretch
        m_ImageSizeXScale = New TranslationScale() With {
            .InputMaxValue = 1,
            .OutputMaxValue = 1,
            .ErrorValue = 1
        }
        m_ImageSizeYScale = New TranslationScale() With {
            .InputMaxValue = 1,
            .OutputMaxValue = 1,
            .ErrorValue = 1
        }
    End Sub



    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        Dim rectangle As New Rectangle()
        Try
            If (If(Image Is Nothing OrElse rotatedBmp IsNot Nothing AndAlso Not (r = rectangle), False, True)) Then
                UpdateImage()
            End If
            If (If(rotatedBmp Is Nothing OrElse Not (r <> rectangle), False, True)) Then
                pe.Graphics.DrawImage(rotatedBmp, r)
            End If
        Catch

        End Try
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        UpdateImage()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub UpdateImage()
        Dim num As Integer = 0
        Dim num1 As Integer = 0
        Dim flag As Boolean
        If Image IsNot Nothing Then
            If rotatedBmp IsNot Nothing AndAlso rotatedBmp.Width = Image.Width Then
                If rotatedBmp.Height <> Image.Height Then
                    GoTo Label1
                End If
                flag = False
                GoTo Label0
            End If
Label1:
            flag = True
Label0:
            If flag Then
                rotatedBmp = New Bitmap(Width, Height)
                rotatedBmp.SetResolution(Image.HorizontalResolution, Image.VerticalResolution)
            End If
            If m_ImageTranslateXScale IsNot Nothing Then
                num = CInt(Math.Truncate(Math.Round(m_ImageTranslateXScale.GetValue(CDbl(m_ImageTranslateXValue)))))
            End If
            If m_ImageTranslateYScale IsNot Nothing Then
                num1 = CInt(Math.Truncate(Math.Round(m_ImageTranslateXScale.GetValue(CDbl(m_ImageTranslateYValue)))))
            End If
            r = New Rectangle(0, 0, Width, Height)
            Using g As Graphics = Graphics.FromImage(rotatedBmp)
                m.Reset()
                g.Clear(Color.Transparent)
                Dim value As Double = m_ImageSizeXScale.GetValue(m_ImageSizeXValue)
                Dim value1 As Double = m_ImageSizeYScale.GetValue(m_ImageSizeYValue)
                If value = 0 Then
                    value = 1
                End If
                If value1 = 0 Then
                    value1 = 1
                End If
                Dim matrix As Matrix = m
                Dim angle As Single = ImageRotationScale.GetAngle(m_ImageRotationValue)
                Dim point As New Point(CInt(Math.Truncate(Math.Round(CDbl(Width) / 2 + CDbl(ImageRotationScale.XPosition) * value + CDbl(num) * value))), CInt(Math.Truncate(Math.Round(CDbl(Height) / 2 + CDbl(ImageRotationScale.YPosition) * value1 + CDbl(num1) * value1))))
                matrix.RotateAt(angle, point)
                m.Translate(CSng((CDbl(Width) - CDbl(Image.Width) * value) / 2), CSng((CDbl(Height) - CDbl(Image.Height) * value1) / 2))
                m.Scale(CSng(value), CSng(value1))
                g.Transform = m
                Dim image_Renamed As Image = Image
                point = New Point(num, num1)
                g.DrawImage(image_Renamed, point)
            End Using
        End If
        Invalidate()
    End Sub
End Class

