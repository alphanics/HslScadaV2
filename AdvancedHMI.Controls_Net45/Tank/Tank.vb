Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class Tank
    Inherits Control

    Private BarValue As Single

    Private TankImage As Bitmap

    Private TextRectangle As Rectangle

    Private TextBrush As SolidBrush

    Private sfCenter As StringFormat

    Private sfCenterTop As StringFormat

    Private m_Value As Single

    Private m_ValueScaleFactor As Decimal

    Private m_MaxValue As Integer

    Private m_MinValue As Integer

    Private m_TankContentColor As HatchBrush

    Private m_LockAspectRatio As Boolean

    Private BarHeight As Integer

    Private FullBarHeight As Integer

    Private _backBuffer As Bitmap

    Private ImageRatio As Single

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            Return createParams_Renamed
        End Get
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If value <> MyBase.ForeColor Then
                MyBase.ForeColor = value
                If Me.TextBrush IsNot Nothing Then
                    Me.TextBrush.Color = value
                Else
                    Me.TextBrush = New SolidBrush(MyBase.ForeColor)
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property MaxValue() As Integer
        Get
            Return Me.m_MaxValue
        End Get
        Set(ByVal value As Integer)
            Me.m_MaxValue = CInt(Math.Truncate(Math.Round(Math.Ceiling(CDbl(value - Me.m_MinValue) / 10) * 10 + CDbl(Me.m_MinValue))))
            Me.CalculateScaledValue()
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    Public Property MinValue() As Integer
        Get
            Return Me.m_MinValue
        End Get
        Set(ByVal value As Integer)
            Me.m_MinValue = value
            Me.MaxValue = Me.m_MaxValue
            Me.CalculateScaledValue()
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    Public Property TankContentColor() As Color
        Get
            Return Me.m_TankContentColor.BackgroundColor
        End Get
        Set(ByVal value As Color)
            If Me.m_TankContentColor IsNot Nothing Then
                Me.m_TankContentColor.Dispose()
            End If
            Me.m_TankContentColor = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value)
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    Public Property Value() As Single
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Single)
            If value <> Me.m_Value Then
                Me.m_Value = Math.Max(Math.Min(value, CSng(Me.m_MaxValue)), CSng(Me.m_MinValue))
                Me.CalculateScaledValue()
                Dim rectangle As New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.TankImage.Width) * 0.49))), CInt(Math.Truncate(Math.Round(CDbl(Me.TankImage.Height) * 0.1))), CInt(Math.Truncate(Math.Round(CDbl(Me.TankImage.Width) * 0.2))), CInt(Math.Truncate(Math.Round(CDbl(Me.TankImage.Height) * 0.6))))
                Me.Invalidate(rectangle)
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property ValueScaleFactor() As Decimal
        Get
            Return Me.m_ValueScaleFactor
        End Get
        Set(ByVal value As Decimal)
            Me.m_ValueScaleFactor = value
        End Set
    End Property



    Public Sub New()
        Dim tank As Tank = Me
        AddHandler MyBase.Resize, AddressOf tank.Tank_Resize

        Me.BarValue = 20.0F
        Me.TextRectangle = New Rectangle()
        Me.sfCenter = New StringFormat()
        Me.sfCenterTop = New StringFormat()
        Me.m_ValueScaleFactor = Decimal.One
        Me.m_MaxValue = 100
        Me.m_TankContentColor = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Aqua)
        Me.RefreshImage()
    End Sub



    Private Sub CalculateScaledValue()
        Me.BarHeight = CInt(Math.Truncate(Math.Round(CDbl((Me.m_Value * Convert.ToSingle(Me.m_ValueScaleFactor) + CSng(Me.m_MinValue)) / CSng(Me.m_MaxValue - Me.m_MinValue)) * (CDbl(Me.Height) / CDbl(My.Resources.TankWithWindow.Height)) * 550)))
        Me.FullBarHeight = CInt(Math.Truncate(Math.Round(CDbl(Me.m_MaxValue + Me.m_MinValue) / CDbl(Me.m_MaxValue - Me.m_MinValue) * (CDbl(Me.Height) / CDbl(My.Resources.TankWithWindow.Height)) * 550)))
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                Me.TankImage.Dispose()
                Me._backBuffer.Dispose()
                Me.m_TankContentColor.Dispose()
                Me.sfCenterTop.Dispose()
                Me.sfCenter.Dispose()
                Me.TextBrush.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.TankImage Is Nothing Or Me._backBuffer Is Nothing Or Me.TextBrush Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.TankImage, 0, 0)
            If Me.m_TankContentColor IsNot Nothing Then
                graphic.FillRectangle(Me.m_TankContentColor, Convert.ToInt32(361 * (CDbl(Me.Width) / CDbl(My.Resources.TankWithWindow.Width))), Convert.ToInt32(158 * (CDbl(Me.Height) / CDbl(My.Resources.TankWithWindow.Height)) + CDbl(Me.FullBarHeight) - CDbl(Me.BarHeight)), Convert.ToInt32(68 * (CDbl(Me.Width) / CDbl(My.Resources.TankWithWindow.Width))), Me.BarHeight)
            End If
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterTop)
            End If
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Me._backBuffer IsNot Nothing Then
            Me._backBuffer.Dispose()
            Me._backBuffer = Nothing
        End If
        MyBase.OnSizeChanged(e)
        If Me.Parent IsNot Nothing Then
            Me.Parent.Invalidate()
        End If
    End Sub

    Private Sub RefreshImage()
        'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim width_Renamed As Integer
        'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim height_Renamed As Integer
        Dim [single] As Single = CSng(CDbl(Me.Width) / CDbl(My.Resources.TankWithWindow.Width))
        Dim height1 As Single = CSng(CDbl(Me.Height) / CDbl(My.Resources.TankWithWindow.Height))
        Me.ImageRatio = CSng(CDbl(Me.Width) / CDbl(Me.Height))
        Me.ImageRatio = 1.0F
        If [single] >= height1 Then
            width_Renamed = Me.Width
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: height = checked((int)Math.Round((double)My.Resources.TankWithWindow.Height / (double)My.Resources.TankWithWindow.Width * (double)this.Width));
            height_Renamed = CInt(Math.Round(CDbl(My.Resources.TankWithWindow.Height) / CDbl(My.Resources.TankWithWindow.Width) * CDbl(Me.Width)))
            Me.ImageRatio = height1
        Else
            height_Renamed = Me.Height
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: width = (!(this.Height > 0 & My.Resources.TankWithWindow.Height > 0) ? 1 : checked((int)Math.Round((double)My.Resources.TankWithWindow.Width / (double)My.Resources.TankWithWindow.Height * (double)this.Height)));
            width_Renamed = (If(Not (Me.Height > 0 And My.Resources.TankWithWindow.Height > 0), 1, CInt(Math.Round(CDbl(My.Resources.TankWithWindow.Width) / CDbl(My.Resources.TankWithWindow.Height) * CDbl(Me.Height)))))
            Me.ImageRatio = [single]
        End If
        If Me.ImageRatio > 0.0F Then
            If Me.TankImage IsNot Nothing Then
                Me.TankImage.Dispose()
            End If
            Me.TankImage = New Bitmap(Convert.ToInt32(Me.Width), Convert.ToInt32(Me.Height))
            Dim graphic As Graphics = Graphics.FromImage(Me.TankImage)
            graphic.DrawImage(My.Resources.TankWithWindow, 0, 0, Me.TankImage.Width, Me.TankImage.Height)
            Me.TextRectangle.X = 1
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)(70f * this.ImageRatio - 1f))));
            Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(CSng(70.0F * Me.ImageRatio - 1.0F)))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Width = checked(this.TankImage.Width - 2);
            Me.TextRectangle.Width = Me.TankImage.Width - 2
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.TankImage.Height * 0.1));
            Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.TankImage.Height) * 0.1)))
            Me.sfCenterTop.Alignment = StringAlignment.Center
            Me.sfCenterTop.LineAlignment = StringAlignment.Near
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            graphic.Dispose()
            Me.Invalidate()
        End If
    End Sub

    Private Sub Tank_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Me.CalculateScaledValue()
        Me.RefreshImage()
    End Sub
End Class

