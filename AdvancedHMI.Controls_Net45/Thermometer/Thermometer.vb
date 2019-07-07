Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class Thermometer
    Inherits Control



    Private StaticImage As Bitmap

    Private BackBuffer As Bitmap

    Private ValueRectangle As Rectangle

    Private BulbCircle As Rectangle

    Private BulbBrush As PathGradientBrush

    Private FillBrush As LinearGradientBrush

    Private m_Minimum As Double

    Private m_Maximum As Double

    Private m_Value As Double

    Private m_FillColor As Color

    Public Property FillColor() As Color
        Get
            Return Me.m_FillColor
        End Get
        Set(ByVal value As Color)
            If Me.m_FillColor <> value Then
                Me.m_FillColor = value
                Me.RefreshImage()
            End If
        End Set
    End Property

    Public Property Maximum() As Double
        Get
            Return Me.m_Maximum
        End Get
        Set(ByVal value As Double)
            If Me.m_Maximum <> value Then
                Me.m_Maximum = value
                Me.RefreshImage()
            End If
        End Set
    End Property

    Public Property Minimum() As Double
        Get
            Return Me.m_Minimum
        End Get
        Set(ByVal value As Double)
            If Me.m_Minimum <> value Then
                Me.m_Minimum = value
                Me.RefreshImage()
            End If
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
        End Set
    End Property

    Public Property Value() As Double
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Double)
            If value <> Me.m_Value Then
                Me.m_Value = value
                Me.UpdateValueRectangle()
            End If
        End Set
    End Property


    Public Sub New()

        Me.m_Minimum = 0
        Me.m_Maximum = 100
        Me.m_FillColor = Color.Red
        Me.ValueRectangle = New Rectangle(0, 0, 10, 10)
    End Sub



    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            If Me.BackBuffer IsNot Nothing Then
                Me.BackBuffer.Dispose()
            End If
            If Me.FillBrush IsNot Nothing Then
                Me.FillBrush.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Public Shared Function GetRelativeColor(ByVal color As Color, ByVal intensity As Double) As Color
        intensity = Math.Max(intensity, 0)
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: Color color1 = Color.FromArgb(checked((int)Math.Round(Math.Min((double)(checked(color.R + 1)) * intensity, 255))), checked((int)Math.Round(Math.Min((double)(checked(color.G + 1)) * intensity, 255))), checked((int)Math.Round(Math.Min((double)(checked(color.B + 1)) * intensity, 255))));
        Dim color1 As Color = System.Drawing.Color.FromArgb(CInt(Math.Truncate(Math.Round(Math.Min(CDbl(color.R + 1) * intensity, 255)))), CInt(Math.Truncate(Math.Round(Math.Min(CDbl(color.G + 1) * intensity, 255)))), CInt(Math.Truncate(Math.Round(Math.Min(CDbl(color.B + 1) * intensity, 255)))))
        Return color1
    End Function

    Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        If Me.BackBuffer IsNot Nothing Or Me.StaticImage IsNot Nothing Or Me.FillBrush IsNot Nothing Then
            Using graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
                graphic.SmoothingMode = SmoothingMode.AntiAlias
                graphic.DrawImage(Me.StaticImage, 0, 0)
                graphic.FillRectangle(Me.FillBrush, Me.ValueRectangle)
                graphic.FillEllipse(Me.BulbBrush, Me.BulbCircle)
            End Using
            e.Graphics.DrawImageUnscaled(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueChangedEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Private Sub RefreshImage()
        If Me.Width > 0 And Me.Height > 0 Then
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
            Me.StaticImage = New Bitmap(Me.Width, Me.Height)
            Using graphic As Graphics = Graphics.FromImage(Me.StaticImage)
                graphic.DrawImage(My.Resources.ThermometerStatic, 0, 0, Me.StaticImage.Width, Me.StaticImage.Height)
                Dim stringFormat As New StringFormat() With {
                 .LineAlignment = StringAlignment.Center,
                 .Alignment = StringAlignment.Far
                }
                Dim mMaximum As Double = (Me.m_Maximum - Me.m_Minimum) / 10
                Dim rectangle(10) As Rectangle
                Dim num As Integer = 0
                Do
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: rectangle[num] = new Rectangle(0, checked((int)Math.Round((double)this.StaticImage.Height * (0.75 - (double)num * 0.065))), checked((int)Math.Round((double)this.StaticImage.Width * 0.48)), checked((int)Math.Round((double)this.StaticImage.Height * 0.05)));
                    rectangle(num) = New Rectangle(0, CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * (0.75 - CDbl(num) * 0.065)))), CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Width) * 0.48))), CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * 0.05))))
                    graphic.DrawString(Convert.ToString(Me.m_Minimum + mMaximum * CDbl(num)), New Font(Me.Font.FontFamily, CSng(CDbl(Me.Height) * 0.025), FontStyle.Regular, GraphicsUnit.Point), New SolidBrush(Me.ForeColor), rectangle(num), stringFormat)
                    num += 1
                Loop While num <= 10
                stringFormat.LineAlignment = StringAlignment.Near
                stringFormat.Alignment = StringAlignment.Center
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(0, checked((int)Math.Round((double)this.StaticImage.Height * 0.01)), this.StaticImage.Width, this.StaticImage.Height);
                Dim rectangle1 As New Rectangle(0, CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * 0.01))), Me.StaticImage.Width, Me.StaticImage.Height)
                graphic.DrawString(MyBase.Text, Me.Font, New SolidBrush(Me.ForeColor), rectangle1, stringFormat)
            End Using
            Me.UpdateValueRectangle()
            Me.FillBrush = New LinearGradientBrush(Me.ValueRectangle, Color.FromArgb(0, 0, 180), Color.FromArgb(0, 0, 180), 0.0F)
            Dim colorBlend As New ColorBlend()
            Dim relativeColor() As Color = {Thermometer.GetRelativeColor(Me.m_FillColor, 0.5), Me.m_FillColor, Thermometer.GetRelativeColor(Me.m_FillColor, 0.5)}
            colorBlend.Colors = relativeColor
            colorBlend.Positions = New Single() {0.0F, 0.5F, 1.0F}
            Me.FillBrush.InterpolationColors = colorBlend
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.BulbCircle = new Rectangle(checked((int)Math.Round((double)this.Width * 0.63)), checked((int)Math.Round((double)this.Height * 0.865)), checked((int)Math.Round((double)this.Width * 0.2)), checked((int)Math.Round((double)this.Height * 0.05)));
            Me.BulbCircle = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.63))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.865))), CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.2))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.05))))
            Dim graphicsPath As New GraphicsPath()
            graphicsPath.AddEllipse(Me.BulbCircle)
            Me.BulbBrush = New PathGradientBrush(graphicsPath)
            'INSTANT VB NOTE: The variable bulbBrush was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim bulbBrush_Renamed As PathGradientBrush = Me.BulbBrush
            Dim colorArray() As Color = {Thermometer.GetRelativeColor(Me.m_FillColor, 0.5)}
            bulbBrush_Renamed.SurroundColors = colorArray
            Me.BulbBrush.CenterColor = Me.m_FillColor
            Me.Invalidate()
        End If
    End Sub

    Private Sub UpdateValueRectangle()
        Dim num As Double = Math.Min(Me.m_Value, Me.m_Maximum)
        Dim mMinimum As Double = (num - Me.m_Minimum) / (Me.m_Maximum - Me.m_Minimum)
        'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim height_Renamed As Double = CDbl(Me.Height) * 0.88
        Dim height1 As Double = CDbl(Me.Height) * 0.65 * mMinimum + CDbl(Me.Height) * 0.105
        If height1 < 1 Then
            height1 = 1
        End If
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.ValueRectangle.Height = checked((int)Math.Round(height1));
        Me.ValueRectangle.Height = CInt(Math.Truncate(Math.Round(height1)))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.ValueRectangle.Width = checked((int)Math.Round((double)this.Width * 0.125));
        Me.ValueRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.125)))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.ValueRectangle.X = checked((int)Math.Round((double)this.Width * 0.67));
        Me.ValueRectangle.X = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.67)))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.ValueRectangle.Y = checked((int)Math.Round(height - height1));
        Me.ValueRectangle.Y = CInt(Math.Truncate(Math.Round(height_Renamed - height1)))
        Me.Invalidate()
    End Sub

    Public Event ValueChanged As EventHandler
End Class

