Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms




Public Class Gauge
    Inherits Control


    Private GaugeImage As Bitmap

    Private Needle As Bitmap

    Private NeedleShadow As Bitmap

    Private LED() As Bitmap

    Private Cx As Double

    Private Cy As Double

    Private Xoff As Integer

    Private YOff As Integer

    Private ImageRatio As Double

    Private TextRectangle As Rectangle

    Private NumberLocations() As Rectangle

    Private sfCenter As StringFormat

    Private sfCenterBottom As StringFormat

    Private sfRight As StringFormat

    Private sfLeft As StringFormat

    Private m_Angle As Double

    Private m_Value As Double

    Private m_ScaledValue As Double

    Private m_ValueScaleFactor As Decimal

    Private m_MaxValue As Integer

    Private m_MinValue As Integer

    Private m_AllowDragging As Boolean

    Private x As Double

    Private y As Double

    Private m As Matrix

    Private _backBuffer As Bitmap

    Private TextBrush As SolidBrush

    Private LastWidth As Integer

    Private LastHeight As Integer

    Private MouseIsDown As Boolean

    Private LastX As Integer

    Private LastY As Integer

    Public Property AllowDragging() As Boolean
        Get
            Return Me.m_AllowDragging
        End Get
        Set(ByVal value As Boolean)
            Me.m_AllowDragging = value
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            'INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            Return createParams_Renamed
        End Get
    End Property

    Public Property MaxValue() As Integer
        Get
            Return Me.m_MaxValue
        End Get
        Set(ByVal value As Integer)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: this.m_MaxValue = Convert.ToInt32(Math.Ceiling((double)((value - this.m_MinValue)) / 10) * 10 + (double)this.m_MinValue);
            Me.m_MaxValue = Convert.ToInt32(Math.Ceiling(CDbl(value - Me.m_MinValue) / 10) * 10 + CDbl(Me.m_MinValue))
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
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    Public Property Value() As Double
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Double)
            If value <> Me.m_Value Then
                Me.m_Value = Math.Max(Math.Min(value, Convert.ToDouble(Decimal.Divide(New Decimal(Me.m_MaxValue), Me.m_ValueScaleFactor))), CDbl(Me.m_MinValue))
                'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                'ORIGINAL LINE: this.m_Angle = (this.m_Value * Convert.ToDouble(this.m_ValueScaleFactor) - (double)this.m_MinValue) * (4.71 / (double)((this.m_MaxValue - this.m_MinValue))) * -1;
                Me.m_Angle = (Me.m_Value * Convert.ToDouble(Me.m_ValueScaleFactor) - CDbl(Me.m_MinValue)) * (4.71 / CDbl(Me.m_MaxValue - Me.m_MinValue)) * -1
                Dim rectangle As New Rectangle(Convert.ToInt32(CDbl(Me.Width) * 0.14), Convert.ToInt32(CDbl(Me.Height) * 0.14), Convert.ToInt32(CDbl(Me.Width) * 0.72), Convert.ToInt32(CDbl(Me.Height) * 0.63))
                Me.Invalidate(rectangle)
                Me.OnvalueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ValueScaleFactor() As Decimal
        Get
            Return Me.m_ValueScaleFactor
        End Get
        Set(ByVal value As Decimal)
            Me.m_ValueScaleFactor = value
            Me.m_Value = Math.Max(Math.Min(Me.m_Value, Convert.ToDouble(Decimal.Divide(New Decimal(Me.m_MaxValue), Me.m_ValueScaleFactor))), CDbl(Me.m_MinValue))
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: this.m_Angle = (this.m_Value * Convert.ToDouble(this.m_ValueScaleFactor) - (double)this.m_MinValue) * (4.71 / (double)((this.m_MaxValue - this.m_MinValue))) * -1;
            Me.m_Angle = (Me.m_Value * Convert.ToDouble(Me.m_ValueScaleFactor) - CDbl(Me.m_MinValue)) * (4.71 / CDbl(Me.m_MaxValue - Me.m_MinValue)) * -1
            Dim rectangle As New Rectangle(Convert.ToInt32(CDbl(Me.Width) * 0.14), Convert.ToInt32(CDbl(Me.Height) * 0.14), Convert.ToInt32(CDbl(Me.Width) * 0.72), Convert.ToInt32(CDbl(Me.Height) * 0.63))
            Me.Invalidate(rectangle)
        End Set
    End Property



    Public Sub New()

        Me.LED = New Bitmap(11) {}
        Me.TextRectangle = New Rectangle()
        Me.NumberLocations = New Rectangle(10) {}
        Me.sfCenter = New StringFormat()
        Me.sfCenterBottom = New StringFormat()
        Me.sfRight = New StringFormat()
        Me.sfLeft = New StringFormat()
        Me.m_ValueScaleFactor = Decimal.One
        Me.m_MaxValue = 100
        Me.m_MinValue = 0
        Me.m = New Matrix()
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        Me.RefreshImage()
    End Sub



    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If Me.TextBrush IsNot Nothing Then
                    Me.TextBrush.Dispose()
                End If
                If Me._backBuffer IsNot Nothing Then
                    Me._backBuffer.Dispose()
                End If
                If Me.GaugeImage IsNot Nothing Then
                    Me.GaugeImage.Dispose()
                End If
                If Me.Needle IsNot Nothing Then
                    Me.Needle.Dispose()
                End If
                If Me.NeedleShadow IsNot Nothing Then
                    Me.NeedleShadow.Dispose()
                End If
                If Me.sfCenter IsNot Nothing Then
                    Me.sfCenter.Dispose()
                End If
                If Me.sfCenterBottom IsNot Nothing Then
                    Me.sfCenterBottom.Dispose()
                End If
                If Me.sfRight IsNot Nothing Then
                    Me.sfRight.Dispose()
                End If
                If Me.sfLeft IsNot Nothing Then
                    Me.sfLeft.Dispose()
                End If
                If Me.m IsNot Nothing Then
                    Me.m.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        If Me.TextBrush IsNot Nothing Then
            Me.TextBrush.Color = MyBase.ForeColor
        Else
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.MouseIsDown = True
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Me.m_AllowDragging Then
            If Me.MouseIsDown And Me.LastX <> 0 Then
                'INSTANT VB NOTE: The variable location was renamed since Visual Basic does not handle local variables named the same as class members well:
                Dim location_Renamed As Point = Me.Location
                'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                'ORIGINAL LINE: int x = ((location.X - this.LastX) + e.X);
                Dim x As Integer = (location_Renamed.X - Me.LastX) + e.X
                Dim point As Point = Me.Location
                'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                'ORIGINAL LINE: Point point1 = new Point(x, ((point.Y - this.LastY) + e.Y));
                Dim point1 As New Point(x, (point.Y - Me.LastY) + e.Y)
                Me.Location = point1
            End If
            Me.LastX = e.X
            Me.LastY = e.Y
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        Me.MouseIsDown = False
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.GaugeImage Is Nothing Or Me.TextBrush Is Nothing) Then
            If Me._backBuffer Is Nothing Then
                Me._backBuffer = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
            End If
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            If Me.BackColor <> Color.Transparent Then
                graphic.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, Me.Width, Me.Height)
            ElseIf Me.Parent IsNot Nothing Then
                graphic.FillRectangle(New SolidBrush(Me.Parent.BackColor), 0, 0, Me.Width, Me.Height)
            End If
            graphic.DrawImage(Me.GaugeImage, 0, 0)
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterBottom)
            End If
            Dim num As Integer = Convert.ToInt32(35 * Me.ImageRatio)
            Dim mValue As Double = Me.m_Value * Convert.ToDouble(Me.m_ValueScaleFactor)
            If mValue > 999 Then
                mValue = mValue - Math.Floor(mValue / 1000) * 1000
            End If
            If Not (mValue > 999 Or mValue < -99) Then
                Dim num1 As Integer = 1
                Do
                    If Not (num1 = 1 And mValue < 0) Then
                        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                        'ORIGINAL LINE: int num2 = Convert.ToInt32(Math.Floor(Math.Abs(mValue) / Math.Pow(10, (double)((3 - num1)))));
                        Dim num2 As Integer = Convert.ToInt32(Math.Floor(Math.Abs(mValue) / Math.Pow(10, CDbl(3 - num1))))
                        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                        'ORIGINAL LINE: graphic.DrawImage(this.LED[num2], Convert.ToInt32(322 * this.ImageRatio + (double)((num * ((num1 - 1))))), Convert.ToInt32((double)this.Height * 0.57));
                        graphic.DrawImage(Me.LED(num2), Convert.ToInt32(322 * Me.ImageRatio + CDbl(num * (num1 - 1))), Convert.ToInt32(CDbl(Me.Height) * 0.57))
                        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                        'ORIGINAL LINE: mValue = (mValue < 0 ? mValue + (double)num2 * Math.Pow(10, (double)((3 - num1))) : mValue - (double)num2 * Math.Pow(10, (double)((3 - num1))));
                        mValue = (If(mValue < 0, mValue + CDbl(num2) * Math.Pow(10, CDbl(3 - num1)), mValue - CDbl(num2) * Math.Pow(10, CDbl(3 - num1))))
                    Else
                        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                        'ORIGINAL LINE: graphic.DrawImage(this.LED[11], Convert.ToInt32(322 * this.ImageRatio + (double)((num * ((num1 - 1))))), Convert.ToInt32((double)this.Height * 0.57));
                        graphic.DrawImage(Me.LED(11), Convert.ToInt32(322 * Me.ImageRatio + CDbl(num * (num1 - 1))), Convert.ToInt32(CDbl(Me.Height) * 0.57))
                    End If
                    num1 += 1
                Loop While num1 <= 3
            Else
                Dim num3 As Integer = 1
                Do
                    'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                    'ORIGINAL LINE: graphic.DrawImage(this.LED[11], Convert.ToInt32(322 * this.ImageRatio + (double)((num * ((num3 - 1))))), Convert.ToInt32((double)this.Height * 0.57));
                    graphic.DrawImage(Me.LED(11), Convert.ToInt32(322 * Me.ImageRatio + CDbl(num * (num3 - 1))), Convert.ToInt32(CDbl(Me.Height) * 0.57))
                    num3 += 1
                Loop While num3 <= 3
            End If
            Dim mAngle As Double = Me.m_Angle + 0.78
            Me.m.Reset()
            Me.m.Translate(CSng(CDbl(Me.Xoff) + 8 * Me.ImageRatio), CSng(CDbl(Me.YOff) + 8 * Me.ImageRatio))
            Dim matrix As Matrix = Me.m
            Dim [single] As Single = CSng(-mAngle * 180 / 3.14159265358979)
            Dim point As New Point(Convert.ToInt32(Me.Cx), Convert.ToInt32(Me.Cy))
            matrix.RotateAt([single], point)
            graphic.Transform = Me.m
            graphic.DrawImage(Me.NeedleShadow, 0, 0)
            Me.m.Reset()
            Me.m.Translate(CSng(Me.Xoff), CSng(Me.YOff))
            Dim matrix1 As Matrix = Me.m
            Dim single1 As Single = CSng(-mAngle * 180 / 3.14159265358979)
            point = New Point(Convert.ToInt32(Me.Cx), Convert.ToInt32(Me.Cy))
            matrix1.RotateAt(single1, point)
            graphic.Transform = Me.m
            graphic.DrawImage(Me.Needle, 0, 0)
            e.Graphics.DrawImageUnscaled(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim size_Renamed As Size
        MyBase.OnResize(e)
        If Not (Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width) Then
            size_Renamed = (If(Me.Height < Me.Width, New Size(Me.Height, Me.Height), New Size(Me.Width, Me.Width)))
        Else
            size_Renamed = (If(Me.Height < Me.Width, New Size(Me.Width, Me.Width), New Size(Me.Height, Me.Height)))
        End If
        Me.Size = size_Renamed
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Me._backBuffer IsNot Nothing Then
            Me._backBuffer.Dispose()
            Me._backBuffer = Nothing
        End If
        Me.RefreshImage()
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overridable Sub OnvalueChanged(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueChangedEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Private Sub RefreshImage()
        'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim width_Renamed As Integer = My.Resources.GaugeSilverNoNeedle.Width
        'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim height_Renamed As Integer = My.Resources.GaugeSilverNoNeedle.Height
        Dim num As Double = CDbl(Me.Width) / CDbl(My.Resources.GaugeSilverNoNeedle.Width)
        Dim height1 As Double = CDbl(Me.Height) / CDbl(My.Resources.GaugeSilverNoNeedle.Height)
        If num >= height1 Then
            Me.x = CDbl(Me.Width)
            Me.y = CDbl(My.Resources.GaugeSilverNoNeedle.Height) / CDbl(My.Resources.GaugeSilverNoNeedle.Width) * CDbl(Me.Width)
            Me.ImageRatio = height1
        Else
            Me.y = CDbl(Me.Height)
            If Not (Me.Height > 0 And My.Resources.GaugeSilverNoNeedle.Height > 0) Then
                Me.x = 1
            Else
                Me.x = CDbl(My.Resources.GaugeSilverNoNeedle.Width) / CDbl(My.Resources.GaugeSilverNoNeedle.Height) * CDbl(Me.Height)
            End If
            Me.ImageRatio = num
        End If
        If Me.ImageRatio > 0 Then
            Convert.ToInt32(CDbl(My.Resources.GaugeNeedle.Height) * Me.ImageRatio)
            Convert.ToInt32(CDbl(My.Resources.GaugeNeedle.Width) * Me.ImageRatio)
            Me.TextRectangle.X = Convert.ToInt32(CDbl(Me.Width) * 0.3)
            Me.TextRectangle.Y = Convert.ToInt32(CDbl(Me.Height) * 0.27)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: this.TextRectangle.Width = (this.Width - (this.TextRectangle.X * 2));
            Me.TextRectangle.Width = Me.Width - Me.TextRectangle.X * 2
            Me.TextRectangle.Height = Convert.ToInt32(CDbl(Me.Height) * 0.18)
            Me.sfCenterBottom.Alignment = StringAlignment.Center
            Me.sfCenterBottom.LineAlignment = StringAlignment.Center
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            Me.sfLeft.Alignment = StringAlignment.Near
            Me.sfCenter.Alignment = StringAlignment.Center
            Me.sfRight.Alignment = StringAlignment.Far
            Dim num1 As Integer = Convert.ToInt32(140 * Me.ImageRatio)
            Dim num2 As Integer = Convert.ToInt32(80 * Me.ImageRatio)
            Me.NumberLocations(0) = New Rectangle(Convert.ToInt32(215 * Me.ImageRatio), Convert.ToInt32(478 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(1) = New Rectangle(Convert.ToInt32(160 * Me.ImageRatio), Convert.ToInt32(405 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(2) = New Rectangle(Convert.ToInt32(160 * Me.ImageRatio), Convert.ToInt32(316 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(3) = New Rectangle(Convert.ToInt32(195 * Me.ImageRatio), Convert.ToInt32(241 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(4) = New Rectangle(Convert.ToInt32(255 * Me.ImageRatio), Convert.ToInt32(189 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(5) = New Rectangle(Convert.ToInt32(300 * Me.ImageRatio), Convert.ToInt32(155 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(6) = New Rectangle(Convert.ToInt32(340 * Me.ImageRatio), Convert.ToInt32(189 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(7) = New Rectangle(Convert.ToInt32(402 * Me.ImageRatio), Convert.ToInt32(241 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(8) = New Rectangle(Convert.ToInt32(435 * Me.ImageRatio), Convert.ToInt32(316 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(9) = New Rectangle(Convert.ToInt32(422 * Me.ImageRatio), Convert.ToInt32(405 * Me.ImageRatio), num1, num2)
            Me.NumberLocations(10) = New Rectangle(Convert.ToInt32(380 * Me.ImageRatio), Convert.ToInt32(473 * Me.ImageRatio), num1, num2)
            If Me.GaugeImage IsNot Nothing Then
                Me.GaugeImage.Dispose()
            End If
            Me.GaugeImage = New Bitmap(Me.Width, Me.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.GaugeImage)
            Me.m.Reset()
            graphic.DrawImage(My.Resources.GaugeSilverNoNeedle, 0, 0, Convert.ToInt32(CDbl(My.Resources.GaugeSilverNoNeedle.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.GaugeSilverNoNeedle.Height) * Me.ImageRatio))
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: int num3 = Convert.ToInt32((double)((this.m_MaxValue - this.m_MinValue)) / 10);
            Dim num3 As Integer = Convert.ToInt32(CDbl(Me.m_MaxValue - Me.m_MinValue) / 10)
            'INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim font_Renamed As New Font("Arial", CSng(40 * Me.ImageRatio), FontStyle.Regular, GraphicsUnit.Point)
            Dim solidBrush As New SolidBrush(Color.FromArgb(250, 35, 35, 35))
            graphic.DrawString(Me.m_MinValue.ToString(), font_Renamed, solidBrush, Me.NumberLocations(0), Me.sfLeft)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + num3)), font, solidBrush, this.NumberLocations[1], this.sfLeft);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3), font_Renamed, solidBrush, Me.NumberLocations(1), Me.sfLeft)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + (num3 * 2))), font, solidBrush, this.NumberLocations[2], this.sfLeft);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3 * 2), font_Renamed, solidBrush, Me.NumberLocations(2), Me.sfLeft)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + (num3 * 3))), font, solidBrush, this.NumberLocations[3], this.sfLeft);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3 * 3), font_Renamed, solidBrush, Me.NumberLocations(3), Me.sfLeft)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + (num3 * 4))), font, solidBrush, this.NumberLocations[4], this.sfLeft);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3 * 4), font_Renamed, solidBrush, Me.NumberLocations(4), Me.sfLeft)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + (num3 * 5))), font, solidBrush, this.NumberLocations[5], this.sfCenter);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3 * 5), font_Renamed, solidBrush, Me.NumberLocations(5), Me.sfCenter)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + (num3 * 6))), font, solidBrush, this.NumberLocations[6], this.sfRight);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3 * 6), font_Renamed, solidBrush, Me.NumberLocations(6), Me.sfRight)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + (num3 * 7))), font, solidBrush, this.NumberLocations[7], this.sfRight);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3 * 7), font_Renamed, solidBrush, Me.NumberLocations(7), Me.sfRight)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + (num3 * 8))), font, solidBrush, this.NumberLocations[8], this.sfRight);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3 * 8), font_Renamed, solidBrush, Me.NumberLocations(8), Me.sfRight)
            'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
            'ORIGINAL LINE: graphic.DrawString(Convert.ToString((this.m_MinValue + (num3 * 9))), font, solidBrush, this.NumberLocations[9], this.sfRight);
            graphic.DrawString(Convert.ToString(Me.m_MinValue + num3 * 9), font_Renamed, solidBrush, Me.NumberLocations(9), Me.sfRight)
            graphic.DrawString(Convert.ToString(Me.m_MaxValue), font_Renamed, solidBrush, Me.NumberLocations(10), Me.sfRight)
            graphic.FillRectangle(Brushes.Black, Convert.ToInt32(CDbl(Me.Width) * 0.432), Convert.ToInt32(CDbl(Me.Height) * 0.57), Convert.ToInt32(103 * Me.ImageRatio), Convert.ToInt32(60 * Me.ImageRatio))
            If Me.Needle IsNot Nothing Then
                Me.Needle.Dispose()
            End If
            Me.Needle = New Bitmap(Convert.ToInt32(CDbl(My.Resources.GaugeNeedle.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.GaugeNeedle.Height) * Me.ImageRatio))
            graphic = Graphics.FromImage(Me.Needle)
            graphic.DrawImage(My.Resources.GaugeNeedle, 0, 0, Convert.ToInt32(CDbl(My.Resources.GaugeNeedle.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.GaugeNeedle.Height) * Me.ImageRatio))
            If Me.NeedleShadow IsNot Nothing Then
                Me.NeedleShadow.Dispose()
            End If
            Me.NeedleShadow = New Bitmap(Convert.ToInt32(CDbl(My.Resources.GaugeNeedleShadow.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.GaugeNeedleShadow.Height) * Me.ImageRatio))
            graphic = Graphics.FromImage(Me.NeedleShadow)
            graphic.DrawImage(My.Resources.GaugeNeedleShadow, 0, 0, Convert.ToInt32(CDbl(My.Resources.GaugeNeedleShadow.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.GaugeNeedleShadow.Height) * Me.ImageRatio))
            Dim num4 As Integer = Convert.ToInt32(CDbl(My.Resources.LED7Segement0.Width) * Me.ImageRatio)
            Dim num5 As Integer = Convert.ToInt32(CDbl(My.Resources.LED7Segement0.Height) * Me.ImageRatio)
            Dim num6 As Integer = 0
            Do
                If Me.LED(num6) IsNot Nothing Then
                    Me.LED(num6).Dispose()
                End If
                Me.LED(num6) = New Bitmap(num4, num5)
                graphic = Graphics.FromImage(Me.LED(num6))
                Select Case num6
                    Case 0
                        graphic.DrawImage(My.Resources.LED7Segement0, 0, 0, num4, num5)
                        Exit Select
                    Case 1
                        graphic.DrawImage(My.Resources.LED7Segement1, 0, 0, num4, num5)
                        Exit Select
                    Case 2
                        graphic.DrawImage(My.Resources.LED7Segement2, 0, 0, num4, num5)
                        Exit Select
                    Case 3
                        graphic.DrawImage(My.Resources.LED7Segement3, 0, 0, num4, num5)
                        Exit Select
                    Case 4
                        graphic.DrawImage(My.Resources.LED7Segement4, 0, 0, num4, num5)
                        Exit Select
                    Case 5
                        graphic.DrawImage(My.Resources.LED7Segement5, 0, 0, num4, num5)
                        Exit Select
                    Case 6
                        graphic.DrawImage(My.Resources.LED7Segement6, 0, 0, num4, num5)
                        Exit Select
                    Case 7
                        graphic.DrawImage(My.Resources.LED7Segement7, 0, 0, num4, num5)
                        Exit Select
                    Case 8
                        graphic.DrawImage(My.Resources.LED7Segement8, 0, 0, num4, num5)
                        Exit Select
                    Case 9
                        graphic.DrawImage(My.Resources.LED7Segement9, 0, 0, num4, num5)
                        Exit Select
                    Case 10
                        graphic.DrawImage(My.Resources.LED7SegementOff, 0, 0, num4, num5)
                        Exit Select
                    Case 11
                        graphic.DrawImage(My.Resources.LED7Segement_, 0, 0, num4, num5)
                        Exit Select
                End Select
                num6 += 1
            Loop While num6 <= 11
            graphic.Dispose()
            Me.Cx = CDbl(My.Resources.GaugeSilverNoNeedle.Width) / 2 * Me.ImageRatio
            Me.Cy = (CDbl(CSng(My.Resources.GaugeNeedle.Height)) * 0.5 - 2) * Me.ImageRatio
            Me.Cx = CDbl(My.Resources.GaugeSilverNoNeedle.Width) * 0.338 * Me.ImageRatio
            Me.Cy = CDbl(Me.Needle.Height) / 2
            Me.Xoff = Convert.ToInt32(CDbl(My.Resources.GaugeSilverNoNeedle.Width) * 0.16 * Me.ImageRatio)
            Me.YOff = Convert.ToInt32(CDbl(My.Resources.GaugeSilverNoNeedle.Height) * 0.485 * Me.ImageRatio)
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
        End If
    End Sub

    Public Event ValueChanged As EventHandler
End Class

