Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class Motor
    Inherits Control


    Private LightImage As Bitmap

    Private LightOffImage As Bitmap

    Private LightOnImage As Bitmap

    Private TextRectangle As Rectangle

    Private TextFormat As StringFormat

    Private TextBrush As SolidBrush

    Private _Value As Boolean

    Private m_LightColor As Motor.LightColorOption

    Private m_Rotation As RotateFlipType

    Private m_OutputType As OutputType

    Private BackNeedsRefreshed As Boolean

    Private _backBuffer As Bitmap


    Private tmrError As Timer

    Private ControlSizeRatio As Decimal

    Private SourceImageRatio As Decimal

    Private LastWidth As Integer

    Private LastHeight As Integer
#Region "Property"
    '* This is necessary to make the background draw correctly
    '*  http://www.bobpowell.net/transcontrols.htm
    '*part of the transparent background code
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 32
            Return cp
        End Get
    End Property
    Public Property LightColor() As Motor.LightColorOption
        Get
            Return m_LightColor
        End Get
        Set(ByVal value As Motor.LightColorOption)
            m_LightColor = value
            RefreshImage()
        End Set
    End Property

    Public Property OutputType() As OutputType
        Get
            Return m_OutputType
        End Get
        Set(ByVal value As OutputType)
            m_OutputType = value
        End Set
    End Property

    Public Property Rotation() As RotateFlipType
        Get
            Return m_Rotation
        End Get
        Set(ByVal value As RotateFlipType)
            If m_Rotation <> value Then
                m_Rotation = value
                BackNeedsRefreshed = True
                AdjustRatio()
                RefreshImage()
            End If
        End Set
    End Property



    Public Property Value() As Boolean
        Get
            Return _Value
        End Get
        Set(ByVal value As Boolean)
            If Not value Then
                LightImage = LightOffImage
            Else
                LightImage = LightOnImage
            End If
            _Value = value
            Invalidate()
        End Set
    End Property

#End Region



    Public Sub New()

        TextRectangle = New Rectangle()
        m_LightColor = Motor.LightColorOption.Green
        m_Rotation = RotateFlipType.RotateNoneFlipNone
        m_OutputType = OutputType.MomentarySet
        tmrError = New Timer()
        SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Height) / CDbl(My.Resources.MotorGray.Width))
        TextBrush = New SolidBrush(MyBase.ForeColor)
        TextFormat = New StringFormat() With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Far
        }
    End Sub


    Private Sub AdjustRatio()
        If Not (m_Rotation = RotateFlipType.Rotate90FlipNone Or m_Rotation = RotateFlipType.Rotate270FlipNone Or m_Rotation = RotateFlipType.Rotate90FlipX Or m_Rotation = RotateFlipType.Rotate270FlipX Or m_Rotation = RotateFlipType.Rotate270FlipX Or m_Rotation = RotateFlipType.Rotate90FlipX Or m_Rotation = RotateFlipType.Rotate270FlipNone Or m_Rotation = RotateFlipType.Rotate90FlipNone) Then
            SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Height) / CDbl(My.Resources.MotorGray.Width))
        Else
            SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Width) / CDbl(My.Resources.MotorGray.Height))
        End If
        If LastHeight < Height Or LastWidth < Width Then
            If CDbl(Height) / CDbl(Width) <= Convert.ToDouble(SourceImageRatio) Then
                Height = Convert.ToInt32(Decimal.Multiply(New Decimal(Width), SourceImageRatio))
            Else
                Width = Convert.ToInt32(Decimal.Divide(New Decimal(Height), SourceImageRatio))
            End If
        ElseIf CDbl(Height) / CDbl(Width) <= Convert.ToDouble(SourceImageRatio) Then
            Width = Convert.ToInt32(Decimal.Divide(New Decimal(Height), SourceImageRatio))
        Else
            Height = Convert.ToInt32(Decimal.Multiply(New Decimal(Width), SourceImageRatio))
        End If
        LastWidth = Width
        LastHeight = Height
        RefreshImage()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Enabled Then
            LightImage = LightOnImage
            If m_OutputType = OutputType.Toggle Then
                Value = Not Value
            End If
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If Enabled Then
            If OutputType <> OutputType.Toggle Then
                LightImage = LightOffImage
            End If
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (_backBuffer Is Nothing Or LightImage Is Nothing) Then
            Dim g As Graphics = Graphics.FromImage(_backBuffer)
            g.DrawImage(LightImage, 0, 0)
            If (If(Text Is Nothing OrElse String.Compare(Text, String.Empty) = 0, False, True)) Then
                If TextBrush.Color <> ForeColor Then
                    TextBrush.Color = ForeColor
                End If
                g.DrawString(Text, Font, TextBrush, TextRectangle, TextFormat)
            End If
            e.Graphics.DrawImage(_backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        If BackNeedsRefreshed Then
            MyBase.OnPaintBackground(e)
            BackNeedsRefreshed = False
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        AdjustRatio()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        RefreshImage()
    End Sub

    Private Sub RefreshImage()
        Dim WidthRatio As Decimal
        Dim HeightRatio As Decimal
        If Not (Width <= 0 Or Height <= 0) Then
            If Not (m_Rotation = RotateFlipType.Rotate90FlipNone Or m_Rotation = RotateFlipType.Rotate270FlipNone Or m_Rotation = RotateFlipType.Rotate90FlipX Or m_Rotation = RotateFlipType.Rotate270FlipX Or m_Rotation = RotateFlipType.Rotate270FlipX Or m_Rotation = RotateFlipType.Rotate90FlipX Or m_Rotation = RotateFlipType.Rotate270FlipNone Or m_Rotation = RotateFlipType.Rotate90FlipNone) Then
                SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Height) / CDbl(My.Resources.MotorGray.Width))
                HeightRatio = New Decimal(CSng(Width) / CSng(My.Resources.MotorGray.Width))
                WidthRatio = New Decimal(CSng(Height) / CSng(My.Resources.MotorGray.Height))
            Else
                SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Width) / CDbl(My.Resources.MotorGray.Height))
                HeightRatio = New Decimal(CSng(Width) / CSng(My.Resources.MotorGray.Height))
                WidthRatio = New Decimal(CSng(Height) / CSng(My.Resources.MotorGray.Width))
            End If
            ControlSizeRatio = Math.Min(HeightRatio, WidthRatio)
            LightImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Width), ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Height), ControlSizeRatio)))
            Dim gr_dest As Graphics = Graphics.FromImage(LightImage)
            gr_dest.DrawImage(My.Resources.MotorGray, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Width), ControlSizeRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Height), ControlSizeRatio)))
            LightOffImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Width), ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Height), ControlSizeRatio)))
            LightOnImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGreen.Width), ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGreen.Height), ControlSizeRatio)))
            gr_dest = Graphics.FromImage(LightOffImage)
            Dim gr_dest2 As Graphics = Graphics.FromImage(LightOnImage)
            gr_dest.DrawImage(My.Resources.MotorGray, 0, 0, LightOffImage.Width, LightOffImage.Height)
            gr_dest2.DrawImage(My.Resources.MotorGreen, 0, 0, LightOnImage.Width, LightOnImage.Height)
            LightOnImage.RotateFlip(m_Rotation)
            LightOffImage.RotateFlip(m_Rotation)
            If Not _Value Then
                LightImage = LightOffImage
            Else
                LightImage = LightOnImage
            End If
            gr_dest.Dispose()
            gr_dest2.Dispose()
            TextRectangle.X = 0
            TextRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Width) * 0.95)))
            TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(Height) * 0.77)))
            TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Height) * 0.2)))
            If _backBuffer IsNot Nothing Then
                _backBuffer.Dispose()
            End If
            _backBuffer = New Bitmap(Width, Height)
            Invalidate()
        End If
    End Sub

    Public Enum LightColorOption
        Red
        Green
    End Enum
End Class

