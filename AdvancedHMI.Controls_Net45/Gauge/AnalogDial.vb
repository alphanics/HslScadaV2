Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class AnalogDial
    Inherits Control


    Private MouseIsDown As Boolean

    Private ValueAngle As Double

    Private TextRectangle As Rectangle

    Private sfCenter As StringFormat

    Private sfCenterBottom As StringFormat

    Private sfRight As StringFormat

    Private sfLeft As StringFormat

    Private NumberLocations As Rectangle

    Private ImageRatio As Double

    Private _backBuffer As Bitmap

    Private TextBrush As SolidBrush

    Private TextFont As Font

    Private StaticImage As Bitmap

    Private DialImage As Bitmap

    Private BackgroundNeedsRefreshed As Boolean

    Private m_Minimum As Double

    Private m_Maximum As Double

    Private m_Value As Double

    Private m_Resolution As Double

    Private m_ShowColorBand As Boolean

    Private m_RedColorBandStartValue As Double

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            'INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            Return createParams_Renamed
        End Get
    End Property

    Public Shadows Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If value <> MyBase.ForeColor Then
                MyBase.ForeColor = value
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
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

    Public Property RedColorBandStartValue() As Double
        Get
            Return Me.m_RedColorBandStartValue
        End Get
        Set(ByVal value As Double)
            If Me.m_RedColorBandStartValue <> value Then
                Me.m_RedColorBandStartValue = value
                Me.RefreshImage()
            End If
        End Set
    End Property

    Public Property Resolution() As Double
        Get
            Return Me.m_Resolution
        End Get
        Set(ByVal value As Double)
            Me.m_Resolution = value
        End Set
    End Property

    Public Property ShowColorBand() As Boolean
        Get
            Return Me.m_ShowColorBand
        End Get
        Set(ByVal value As Boolean)
            If Me.m_ShowColorBand <> value Then
                Me.m_ShowColorBand = value
                Me.RefreshImage()
            End If
        End Set
    End Property

    Public Property Value() As Double
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Double)
            If Me.m_Value <> value And Not Me.MouseIsDown Then
                Me.SetValue(value, False)
            End If
        End Set
    End Property



    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.sfCenter = New StringFormat()
        Me.sfCenterBottom = New StringFormat()
        Me.sfRight = New StringFormat()
        Me.sfLeft = New StringFormat()
        Me.BackgroundNeedsRefreshed = True
        Me.m_Maximum = 100
        Me.m_Resolution = 0.1
        Me.m_ShowColorBand = True
        Me.m_RedColorBandStartValue = 75
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub


    Private Sub CalculateValue(ByVal MouseX As Integer, ByVal MouseY As Integer)
        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
        'ORIGINAL LINE: int num = ((int)Math.Round((double)MouseX - (double)this.Width / 2));
        Dim num As Integer = CInt(Math.Truncate(Math.Round(CDbl(MouseX) - CDbl(Me.Width) / 2)))
        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
        'ORIGINAL LINE: int num1 = ((int)Math.Round((double)this.Height / 2 - (double)MouseY));
        Dim num1 As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) / 2 - CDbl(MouseY))))
        Dim num2 As Double = Math.Atan(CDbl(num1) / CDbl(num)) * 180 / 3.14159265358979
        If num < 0 Then
            num2 = num2 + 180
        End If
        Dim num3 As Double = 180 - num2
        Dim mValue As Double = Me.m_Value
        Me.SetValue((num3 + 45) / 270 * (Me.m_Maximum - Me.m_Minimum) + Me.m_Minimum, True)
        If Me.m_Value <> mValue Then
            Me.OnValueChangedWithDial(EventArgs.Empty)
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.MouseIsDown = True
        'INSTANT VB NOTE: The variable location was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim location_Renamed As Point = e.Location
        Dim point As Point = e.Location
        If e.Button = MouseButtons.Left And location_Renamed.Y > -10 And point.X > -10 Then
            Me.CalculateValue(e.Location.X, e.Location.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        'INSTANT VB NOTE: The variable location was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim location_Renamed As Point = e.Location
        Dim point As Point = e.Location
        Dim location1 As Point = e.Location
        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
        'ORIGINAL LINE: if (e.Button == MouseButtons.Left & location.Y > -10 & point.X > -10 & location1.Y < (this.Width + 10) & e.Location.X < (this.Height + 10))
        If e.Button = MouseButtons.Left And location_Renamed.Y > -10 And point.X > -10 And location1.Y < Me.Width + 10 And e.Location.X < Me.Height + 10 Then
            Me.CalculateValue(e.Location.X, e.Location.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        Me.MouseIsDown = False
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Using graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.Clear(Me.BackColor)
            If Me.StaticImage IsNot Nothing Then
                graphic.DrawImage(Me.StaticImage, 0, 0)
            End If
            If Me.TextBrush IsNot Nothing Then
                graphic.DrawString(Me.Text, Me.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterBottom)
            End If
            Dim matrix As New Matrix()
            'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim width_Renamed As Double = CDbl(My.Resources.ChromeKnob.Width) / 2
            'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim height_Renamed As Double = CDbl(My.Resources.ChromeKnob.Height) / 2
            Dim num As Double = CDbl(Me.Width) / CDbl(My.Resources.ChromeKnob.Width) / 2
            Dim height1 As Double = CDbl(Me.Height) / CDbl(My.Resources.ChromeKnob.Height) / 2
            'INSTANT VB NOTE: The variable valueAngle was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim valueAngle_Renamed As Single = CSng(Me.ValueAngle)
            Dim point As New Point(Convert.ToInt32(width_Renamed), Convert.ToInt32(height_Renamed))
            matrix.RotateAt(valueAngle_Renamed, point, MatrixOrder.Prepend)
            matrix.Scale(CSng(num), CSng(height1), MatrixOrder.Append)
            matrix.Translate(CSng((CDbl(Me.Width) - CDbl(My.Resources.ChromeKnob.Width) * num) / 2), CSng((CDbl(Me.Height) - CDbl(My.Resources.ChromeKnob.Height) * height1) / 2), MatrixOrder.Append)
            graphic.Transform = matrix
            graphic.DrawImage(My.Resources.ChromeKnob, 0, 0)
        End Using
        e.Graphics.DrawImage(Me._backBuffer, 0, 0)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        If Me.BackgroundNeedsRefreshed Then
            MyBase.OnPaintBackground(e)
            Me.BackgroundNeedsRefreshed = False
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueChangedEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Protected Overridable Sub OnValueChangedWithDial(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueChangedWithDialEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Private Sub RefreshImage()
        Dim graphicsPath As New GraphicsPath()
        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
        'ORIGINAL LINE: graphicsPath.AddEllipse(-1, -1, (this.Width + 1), (this.Height + 1));
        graphicsPath.AddEllipse(-1, -1, Me.Width + 1, Me.Height + 1)
        Me.Region = New Region(graphicsPath)
        'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim width_Renamed As Integer = My.Resources.ChromeKnob.Width
        'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim height_Renamed As Integer = My.Resources.ChromeKnob.Height
        Dim num As Double = CDbl(Me.Width) / CDbl(My.Resources.ChromeKnob.Width) / 3
        Dim height1 As Double = CDbl(Me.Height) / CDbl(My.Resources.ChromeKnob.Height) / 3
        If num >= height1 Then
            Me.ImageRatio = height1
        Else
            Me.ImageRatio = num
        End If
        If Me.ImageRatio > 0 Then
            Me.sfCenterBottom.Alignment = StringAlignment.Center
            Me.sfCenterBottom.LineAlignment = StringAlignment.Center
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            Me.StaticImage = New Bitmap(Me.Width, Me.Height)
            Using graphic As Graphics = Graphics.FromImage(Me.StaticImage)
                graphic.SmoothingMode = SmoothingMode.HighQuality
                graphic.DrawImage(My.Resources.Plate, 0, 0, Me.Width, Me.Height)
                Dim num1 As Integer = Convert.ToInt32((Me.m_Maximum - Me.m_Minimum) / 10)
                'INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
                Dim font_Renamed As New Font("Arial", CSng(65 * Me.ImageRatio), FontStyle.Regular, GraphicsUnit.Point)
                'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
                Dim size_Renamed As Size = TextRenderer.MeasureText(Conversions.ToString(Me.m_Maximum), font_Renamed)
                Dim width1 As Integer = size_Renamed.Width
                size_Renamed = TextRenderer.MeasureText(Conversions.ToString(Me.m_Maximum), font_Renamed)
                Dim height2 As Integer = size_Renamed.Height
                Me.sfLeft.Alignment = StringAlignment.Near
                Me.sfCenter.Alignment = StringAlignment.Center
                Me.sfRight.Alignment = StringAlignment.Far
                Dim width2 As Double = CDbl(Me.Width) / 2 - CDbl(width1) / 2
                'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                'ORIGINAL LINE: int num2 = ((int)Math.Round(Math.Cos(3.92699081698724) * width2 - (double)width1 / 2));
                Dim num2 As Integer = CInt(Math.Truncate(Math.Round(Math.Cos(3.92699081698724) * width2 - CDbl(width1) / 2)))
                'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                'ORIGINAL LINE: int num3 = ((int)Math.Round(Math.Sin(3.92699081698724) * width2 + (double)height2 / 2));
                Dim num3 As Integer = CInt(Math.Truncate(Math.Round(Math.Sin(3.92699081698724) * width2 + CDbl(height2) / 2)))
                Dim width3 As Double = CDbl(Me.Width) / 2
                Dim height3 As Double = CDbl(Me.Height) / 2
                Dim num4 As Integer = 0
                Do
                    'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                    'ORIGINAL LINE: double num5 = (double)((225 - (27 * num4))) * 3.14159265358979 / 180;
                    Dim num5 As Double = CDbl(225 - 27 * num4) * 3.14159265358979 / 180
                    width2 = Math.Sqrt(width3 * width3 * Math.Cos(num5) * Math.Cos(num5) + height3 * height3 * Math.Sin(num5) * Math.Sin(num5)) - CDbl(width1) / 2
                    'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                    'ORIGINAL LINE: num2 = ((int)Math.Round(Math.Cos(num5) * width2 - (double)width1 / 2));
                    num2 = CInt(Math.Truncate(Math.Round(Math.Cos(num5) * width2 - CDbl(width1) / 2)))
                    'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                    'ORIGINAL LINE: num3 = ((int)Math.Round(Math.Sin(num5) * width2 + (double)height2 / 2));
                    num3 = CInt(Math.Truncate(Math.Round(Math.Sin(num5) * width2 + CDbl(height2) / 2)))
                    Me.NumberLocations = New Rectangle(Convert.ToInt32(CDbl(num2) + CDbl(Me.Width) / 2), Convert.ToInt32(CDbl(Me.Height) / 2 - CDbl(num3)), width1, height2)
                    'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                    'ORIGINAL LINE: graphic.DrawString(Convert.ToString(this.m_Minimum + (double)((num1 * num4))), font, this.TextBrush, this.NumberLocations, this.sfCenter);
                    graphic.DrawString(Convert.ToString(Me.m_Minimum + CDbl(num1 * num4)), font_Renamed, Me.TextBrush, Me.NumberLocations, Me.sfCenter)
                    num4 += 1
                Loop While num4 <= 10
                If Me.m_ShowColorBand Then
                    Dim pen As New Pen(Brushes.Green, CSng(CDbl(Me.Width) / 18))
                    'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                    'ORIGINAL LINE: Rectangle rectangle = new Rectangle(((int)Math.Round((double)this.Width * 0.23)), ((int)Math.Round((double)this.Height * 0.23)), ((int)Math.Round((double)this.Width * 0.54)), ((int)Math.Round((double)this.Height * 0.54)));
                    Dim rectangle As New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.23))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.23))), CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.54))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.54))))
                    graphic.DrawArc(pen, rectangle, 135.0F, 270.0F)
                    If Me.m_RedColorBandStartValue > Me.m_Minimum And Me.m_RedColorBandStartValue < Me.m_Maximum Then
                        Dim pen1 As New Pen(Brushes.Red, CSng(CDbl(Me.Width) / 18))
                        If Me.m_Maximum <> Me.m_Minimum Then
                            Dim mRedColorBandStartValue As Single = CSng((Me.m_RedColorBandStartValue - Me.m_Minimum) / (Me.m_Maximum - Me.m_Minimum) * 270)
                            graphic.DrawArc(pen1, rectangle, 135.0F + mRedColorBandStartValue, 270.0F - mRedColorBandStartValue)
                        End If
                    End If
                End If
                graphic.Dispose()
            End Using
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: this.TextRectangle = new Rectangle(((int)Math.Round((double)this.Width * 0.1)), ((int)Math.Round((double)this.Height * 0.9)), ((int)Math.Round((double)this.Width * 0.8)), ((int)Math.Round((double)this.Font.Height * 1.1)));
            Me.TextRectangle = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.1))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.9))), CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.8))), CInt(Math.Truncate(Math.Round(CDbl(Me.Font.Height) * 1.1))))
            Me.DialImage = New Bitmap(Me.Width, Me.Height)
            Using graphic1 As Graphics = Graphics.FromImage(Me.DialImage)
                graphic1.SmoothingMode = SmoothingMode.AntiAlias
                Dim chromeKnob As Bitmap = My.Resources.ChromeKnob
                'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                'ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(((int)Math.Round((double)this.Width / 4)), ((int)Math.Round((double)this.Height / 4)), ((int)Math.Round((double)this.Width / 2)), ((int)Math.Round((double)this.Height / 2)));
                Dim rectangle1 As New Rectangle(CInt(Math.Round(CDbl(Me.Width) / 4)), CInt(Math.Round(CDbl(Me.Height) / 4)), CInt(Math.Round(CDbl(Me.Width) / 2)), CInt(Math.Round(CDbl(Me.Height) / 2)))
                graphic1.DrawImage(chromeKnob, rectangle1)
            End Using
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.BackgroundNeedsRefreshed = True
            Me.Invalidate()
        End If
    End Sub

    Private Sub SetValue(ByVal value As Double, ByVal constrain As Boolean)
        Dim num As Double = Math.Min(value, Me.m_Maximum)
        num = Math.Max(num, Me.m_Minimum)
        If Me.m_Resolution > 0 Then
            num = CDbl(Convert.ToInt32(num / Me.m_Resolution)) * Me.m_Resolution
        End If
        If Me.m_Maximum = Me.m_Minimum Then
            Me.ValueAngle = -90
        Else
            Me.ValueAngle = (num - Me.Minimum) / (Me.m_Maximum - Me.m_Minimum) * 270 - 135
        End If
        If Not constrain Then
            Me.m_Value = value
        Else
            Me.m_Value = num
        End If
        Me.Invalidate()
        Me.OnValueChanged(EventArgs.Empty)
    End Sub

    Public Event ValueChanged As EventHandler

    Public Event ValueChangedWithDial As EventHandler
End Class


