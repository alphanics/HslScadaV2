Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class Conveyor
    Inherits Control

    Private LightImage As Bitmap

    Private OffImage As Bitmap

    Private OnImage As Bitmap

    Private TextRectangle As Rectangle

    Private TextFormat As StringFormat

    Private TextBrush As SolidBrush

    Private m_Value As Boolean

    Private m_Rotation As RotateFlipType

    Private m_OutputType As OutputType

    Private BackNeedsRefreshed As Boolean

    Private _backBuffer As Bitmap


    Private _tmrError As Timer

    Private ControlSizeRatio As Decimal

    Private SourceImageRatio As Decimal

    Private LastWidth As Integer

    Private LastHeight As Integer

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
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
                Me.AdjustSize()
                Me.RefreshImage()
            End If
        End Set
    End Property


    Public Property Value() As Boolean
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_Value Then
                If Not value Then
                    Me.LightImage = Me.OffImage
                Else
                    Me.LightImage = Me.OnImage
                End If
                Me.m_Value = value
                Me.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property



    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.m_Rotation = RotateFlipType.RotateNoneFlipNone
        Me.m_OutputType = OutputType.MomentarySet
        Me._tmrError = New Timer()
        Me.SourceImageRatio = New Decimal(CDbl(My.Resources.ConveyorOff.Height) / CDbl(My.Resources.ConveyorOff.Width))
        Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        Me.TextFormat = New StringFormat() With {
         .Alignment = StringAlignment.Center,
         .LineAlignment = StringAlignment.Far
        }
    End Sub



    Private Sub AdjustSize()
        If Not (Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone) Then
            Me.SourceImageRatio = New Decimal(CDbl(My.Resources.ConveyorOff.Height) / CDbl(My.Resources.ConveyorOff.Width))
        Else
            Me.SourceImageRatio = New Decimal(CDbl(My.Resources.ConveyorOff.Width) / CDbl(My.Resources.ConveyorOff.Height))
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
        Me.BackNeedsRefreshed = True
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Me.Enabled Then
            Me.LightImage = Me.OnImage
            If Me.m_OutputType = OutputType.Toggle Then
                Me.Value = Not Me.Value
            End If
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If Me.Enabled Then
            If Me.m_OutputType <> OutputType.Toggle Then
                Me.LightImage = Me.OffImage
            End If
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me._backBuffer Is Nothing Or Me.LightImage Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.LightImage, 0, 0)
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
        Me.AdjustSize()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Private Sub RefreshImage()
        Dim WidthLast As Decimal
        Dim HeightLast As Decimal
        If Not (Me.Width <= 0 Or Me.Height <= 0) Then
            If Not (Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone) Then
                Me.SourceImageRatio = New Decimal(CDbl(My.Resources.ConveyorOff.Height) / CDbl(My.Resources.ConveyorOff.Width))
                HeightLast = New Decimal(CSng(Me.Width) / CSng(My.Resources.ConveyorOff.Width))
                WidthLast = New Decimal(CSng(Me.Height) / CSng(My.Resources.ConveyorOff.Height))
            Else
                Me.SourceImageRatio = New Decimal(CDbl(My.Resources.ConveyorOff.Width) / CDbl(My.Resources.ConveyorOff.Height))
                HeightLast = New Decimal(CSng(Me.Width) / CSng(My.Resources.ConveyorOff.Height))
                WidthLast = New Decimal(CSng(Me.Height) / CSng(My.Resources.ConveyorOff.Width))
            End If
            Me.ControlSizeRatio = Math.Min(HeightLast, WidthLast)
            Me.LightImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.ConveyorOff.Width), Me.ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.ConveyorOff.Height), Me.ControlSizeRatio)))
            Dim graphic As Graphics = Graphics.FromImage(Me.LightImage)
            graphic.DrawImage(My.Resources.ConveyorOff, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.ConveyorOff.Width), Me.ControlSizeRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.ConveyorOff.Height), Me.ControlSizeRatio)))
            Me.OffImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.ConveyorOff.Width), Me.ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.ConveyorOff.Height), Me.ControlSizeRatio)))
            Me.OnImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.ConveyorOn.Width), Me.ControlSizeRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.ConveyorOn.Height), Me.ControlSizeRatio)))
            graphic = Graphics.FromImage(Me.OffImage)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.OnImage)
            graphic.DrawImage(My.Resources.ConveyorOff, 0, 0, Me.OffImage.Width, Me.OffImage.Height)
            graphic1.DrawImage(My.Resources.ConveyorOn, 0, 0, Me.OnImage.Width, Me.OnImage.Height)
            Me.OnImage.RotateFlip(Me.m_Rotation)
            Me.OffImage.RotateFlip(Me.m_Rotation)
            If Not Me.m_Value Then
                Me.LightImage = Me.OffImage
            Else
                Me.LightImage = Me.OnImage
            End If
            graphic.Dispose()
            graphic1.Dispose()
            Me.TextRectangle.X = 0
            Me.TextRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.95)))
            Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.47)))
            Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.5)))
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub

    Public Event ValueChanged As EventHandler(Of EventArgs)
End Class

