Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class PneumaticBallVave
    Inherits Control


    Private LightImage As Bitmap

    Private OffImage As Bitmap

    Private OnImage As Bitmap

    Private TextRectangle As Rectangle

    Private ImageRatio As Decimal

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private _backBuffer As Bitmap

    Private _Value As Boolean

    Private m_Rotation As RotateFlipType

    Private m_OutputType As OutputType

    Private BackNeedsRefreshed As Boolean


    Private tmrError As Timer

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
            Me.m_Rotation = value
            Me.BackNeedsRefreshed = True
            Me.RefreshImage()
        End Set
    End Property



    Public Property Value() As Boolean
        Get
            Return Me._Value
        End Get
        Set(ByVal value As Boolean)
            If Not value Then
                Me.LightImage = Me.OffImage
            Else
                Me.LightImage = Me.OnImage
            End If
            Me._Value = value
            Me.Invalidate()
        End Set
    End Property



    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.sf = New StringFormat()
        Me.m_Rotation = RotateFlipType.RotateNoneFlipNone
        Me.m_OutputType = OutputType.MomentarySet
        Me.tmrError = New Timer()
        Me.SourceImageRatio = New Decimal(CDbl(My.Resources.PneumaticBallValveOff.Height) / CDbl(My.Resources.PneumaticBallValveOff.Width))
        If (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            Me.ForeColor = Color.LightGray
        End If
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
            If Me.OutputType <> OutputType.Toggle Then
                Me.LightImage = Me.OffImage
            End If
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me._backBuffer Is Nothing Or Me.LightImage Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.LightImage, 0, 0)
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
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

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Private Sub RefreshImage()
        Dim num As New Decimal(CSng(Me.Width) / CSng(My.Resources.PneumaticBallValveOff.Width))
        Dim num1 As New Decimal(CSng(Me.Height) / CSng(My.Resources.PneumaticBallValveOff.Height))
        If Decimal.Compare(num, num1) >= 0 Then
            Me.ImageRatio = num1
        Else
            Me.ImageRatio = num
        End If
        If Decimal.Compare(Me.ImageRatio, Decimal.Zero) > 0 Then
            Me.LightImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PneumaticBallValveOff.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PneumaticBallValveOff.Height), Me.ImageRatio)))
            Dim graphic As Graphics = Graphics.FromImage(Me.LightImage)
            graphic.DrawImage(My.Resources.PneumaticBallValveOff, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.PneumaticBallValveOff.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.PneumaticBallValveOff.Height), Me.ImageRatio)))
            Me.OffImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PneumaticBallValveOff.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PneumaticBallValveOff.Height), Me.ImageRatio)))
            Me.OnImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PneumaticBallValveOn.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PneumaticBallValveOn.Height), Me.ImageRatio)))
            graphic = Graphics.FromImage(Me.OffImage)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.OnImage)
            graphic.DrawImage(My.Resources.PneumaticBallValveOff, 0, 0, Me.OffImage.Width, Me.OffImage.Height)
            graphic1.DrawImage(My.Resources.PneumaticBallValveOn, 0, 0, Me.OnImage.Width, Me.OnImage.Height)
            Me.OffImage.RotateFlip(Me.m_Rotation)
            Me.OnImage.RotateFlip(Me.m_Rotation)
            If Not Me._Value Then
                Me.LightImage = Me.OffImage
            Else
                Me.LightImage = Me.OnImage
            End If
            graphic.Dispose()
            graphic1.Dispose()
            Me.TextRectangle.X = 0
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Width = checked((int)Math.Round((double)this.Width * 0.95));
            Me.TextRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.95)))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)this.Height * 0.55));
            Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.55)))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.45));
            Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.45)))
            Me.sf.Alignment = StringAlignment.Center
            Me.sf.LineAlignment = StringAlignment.Center
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub
End Class

