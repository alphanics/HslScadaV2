Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms



Public Class Motor3Color
    Inherits Control


    Private ActiveMotorImage As Bitmap

    Private Motor1Image As Bitmap

    Private Motor2Image As Bitmap

    Private Motor3Image As Bitmap

    Private TextRectangle As Rectangle

    Private TextFormat As StringFormat

    Private TextBrush As SolidBrush

    Private m_SelectColor2 As Boolean

    Private m_SelectColor3 As Boolean

    Private m_Rotation As RotateFlipType

    Private m_OutputType As OutputType

    Private BackNeedsRefreshed As Boolean

    Private _backBuffer As Bitmap


    Private tmrError As Timer

    Private ControlSizeRatio As Decimal

    Private SourceImageRatio As Decimal

    Private LastWidth As Integer

    Private LastHeight As Integer

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            'INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            Return createParams_Renamed
        End Get
    End Property

    Public Property OutputType() As OutputType
        Get
            Return Me.m_OutputType
        End Get
        Set(ByVal value As OutputType)
            Me.m_OutputType = value
        End Set
    End Property

    Public Property Rotation() As RotateFlipType
        Get
            Return Me.m_Rotation
        End Get
        Set(ByVal value As RotateFlipType)
            If Me.m_Rotation <> value Then
                Me.m_Rotation = value
                Me.BackNeedsRefreshed = True
                Me.AdjustRatio()
                Me.RefreshImage()
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property SelectColor2() As Boolean
        Get
            Return Me.m_SelectColor2
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_SelectColor2 Then
                Me.m_SelectColor2 = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property SelectColor3() As Boolean
        Get
            Return Me.m_SelectColor3
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_SelectColor3 Then
                Me.m_SelectColor3 = value
                Me.Invalidate()
            End If
        End Set
    End Property




    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.m_Rotation = RotateFlipType.RotateNoneFlipNone
        Me.m_OutputType = OutputType.MomentarySet
        Me.tmrError = New Timer()
        Me.SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Height) / CDbl(My.Resources.MotorGray.Width))
        Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        Me.TextFormat = New StringFormat() With {
         .Alignment = StringAlignment.Center,
         .LineAlignment = StringAlignment.Center
        }
    End Sub


    Private Sub AdjustRatio()
        If Not (Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone) Then
            Me.SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Height) / CDbl(My.Resources.MotorGray.Width))
        Else
            Me.SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Width) / CDbl(My.Resources.MotorGray.Height))
        End If
        If Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width Then
            If CDbl(Me.Height) / CDbl(Me.Width) <= Convert.ToDouble(Me.SourceImageRatio) Then
                Me.Height = Convert.ToInt32(Decimal.Multiply(New Decimal(Me.Width), Me.SourceImageRatio))
            Else
                Me.Width = Convert.ToInt32(Decimal.Divide(New Decimal(Me.Height), Me.SourceImageRatio))
            End If
        ElseIf CDbl(Me.Height) / CDbl(Me.Width) <= Convert.ToDouble(Me.SourceImageRatio) Then
            Me.Width = Convert.ToInt32(Decimal.Divide(New Decimal(Me.Height), Me.SourceImageRatio))
        Else
            Me.Height = Convert.ToInt32(Decimal.Multiply(New Decimal(Me.Width), Me.SourceImageRatio))
        End If
        Me.LastWidth = Me.Width
        Me.LastHeight = Me.Height
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Me.Enabled Then
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If Me.Enabled Then
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me._backBuffer Is Nothing Or Me.Motor1Image Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            Me.ActiveMotorImage = Me.Motor1Image
            If Me.m_SelectColor3 Then
                Me.ActiveMotorImage = Me.Motor3Image
            ElseIf Me.m_SelectColor2 Then
                Me.ActiveMotorImage = Me.Motor2Image
            End If
            graphic.DrawImage(Me.ActiveMotorImage, 0, 0)
            If (If(Me.Text Is Nothing OrElse String.Compare(Me.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> Me.ForeColor Then
                    Me.TextBrush.Color = Me.ForeColor
                End If
                graphic.DrawString(Me.Text, Me.Font, Me.TextBrush, Me.TextRectangle, Me.TextFormat)
            End If
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        If Me.BackNeedsRefreshed Then
            MyBase.OnPaintBackground(e)
            Me.BackNeedsRefreshed = False
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.AdjustRatio()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Private Sub RefreshImage()
        Dim num As Decimal
        Dim num1 As Decimal
        If Not (Me.Width <= 0 Or Me.Height <= 0) Then
            If Not (Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone) Then
                Me.SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Height) / CDbl(My.Resources.MotorGray.Width))
                num1 = New Decimal(CSng(Me.Width) / CSng(My.Resources.MotorGray.Width))
                num = New Decimal(CSng(Me.Height) / CSng(My.Resources.MotorGray.Height))
            Else
                Me.SourceImageRatio = New Decimal(CDbl(My.Resources.MotorGray.Width) / CDbl(My.Resources.MotorGray.Height))
                num1 = New Decimal(CSng(Me.Width) / CSng(My.Resources.MotorGray.Height))
                num = New Decimal(CSng(Me.Height) / CSng(My.Resources.MotorGray.Width))
            End If
            Me.ControlSizeRatio = Math.Min(num1, num)
            Me.ActiveMotorImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Width), Me.ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Height), Me.ControlSizeRatio)))
            Dim graphic As Graphics = Graphics.FromImage(Me.ActiveMotorImage)
            graphic.DrawImage(My.Resources.MotorGray, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Width), Me.ControlSizeRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Height), Me.ControlSizeRatio)))
            Me.Motor1Image = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Width), Me.ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGray.Height), Me.ControlSizeRatio)))
            Me.Motor2Image = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGreen.Width), Me.ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorGreen.Height), Me.ControlSizeRatio)))
            Me.Motor3Image = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorRed.Width), Me.ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.MotorRed.Height), Me.ControlSizeRatio)))
            graphic = Graphics.FromImage(Me.Motor1Image)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.Motor2Image)
            Dim graphic2 As Graphics = Graphics.FromImage(Me.Motor3Image)
            graphic.DrawImage(My.Resources.MotorGray, 0, 0, Me.Motor1Image.Width, Me.Motor1Image.Height)
            graphic1.DrawImage(My.Resources.MotorGreen, 0, 0, Me.Motor2Image.Width, Me.Motor2Image.Height)
            graphic2.DrawImage(My.Resources.MotorRed, 0, 0, Me.Motor3Image.Width, Me.Motor3Image.Height)
            Me.Motor1Image.RotateFlip(Me.m_Rotation)
            Me.Motor2Image.RotateFlip(Me.m_Rotation)
            Me.ActiveMotorImage = Me.Motor1Image
            If Me.m_SelectColor2 Then
                Me.ActiveMotorImage = Me.Motor2Image
            ElseIf Me.m_SelectColor3 Then
                Me.ActiveMotorImage = Me.Motor3Image
            End If
            graphic.Dispose()
            graphic1.Dispose()
            graphic2.Dispose()
            Me.TextRectangle.X = 0
            Me.TextRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.95)))
            Me.TextRectangle.Y = 0
            Me.TextRectangle.Height = Me.Height
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub
End Class


