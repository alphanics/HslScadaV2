Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class Meter
    Inherits Control

    Private StaticImage As Bitmap

    Private BaseImage As Bitmap

    Private Needle As Bitmap

    Private Cx As Single

    Private Cy As Single

    Private Xoff As Integer

    Private YOff As Integer

    Private ZeroCentered As Boolean

    Private ImageScale As Single

    Private TextRectangle As Rectangle

    Private NumberLocations() As Rectangle

    Private sfCenter As StringFormat

    Private sfCenterBottom As StringFormat

    Private m_Value As Double

    Private m_Angle As Decimal

    Private m_ValueScaleFactor As Decimal

    Private m_MaxValue As Decimal

    Private m_MinValue As Decimal

    Private m As Matrix

    Private _backBuffer As Bitmap

    Private TextBrush As SolidBrush

    Private LastWidth As Integer

    Private LastHeight As Integer

    Public Property MaxValue() As Decimal
        Get
            Return Me.m_MaxValue
        End Get
        Set(ByVal value As Decimal)
            Me.m_MaxValue = value
            Me.Value = Me.m_Value
            Me.CalculateAngle()
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    Public Property MinValue() As Decimal
        Get
            Return Me.m_MinValue
        End Get
        Set(ByVal value As Decimal)
            Me.m_MinValue = value
            If Decimal.Compare(Me.m_MinValue, Me.m_MaxValue) >= 0 Then
                Me.m_MaxValue = Decimal.Add(Me.m_MinValue, Decimal.One)
            End If
            Me.MaxValue = Me.m_MaxValue
            Me.Value = Me.m_Value
            Me.CalculateAngle()
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
                Me.m_Value = Math.Max(Math.Min(value, Convert.ToDouble(Decimal.Divide(Me.m_MaxValue, Me.m_ValueScaleFactor))), Convert.ToDouble(Decimal.Divide(Me.m_MinValue, Me.m_ValueScaleFactor)))
                Me.CalculateAngle()
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: Rectangle rectangle = new Rectangle(0, 0, checked((int)Math.Round((double)this.StaticImage.Width * 0.85)), checked((int)Math.Round((double)this.StaticImage.Height * 0.58)));
                Dim rectangle As New Rectangle(0, 0, CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Width) * 0.85))), CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * 0.58))))
                Me.Invalidate(rectangle)
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ValueScaleFactor() As Decimal
        Get
            Return Me.m_ValueScaleFactor
        End Get
        Set(ByVal value As Decimal)
            Me.m_ValueScaleFactor = value
            value = New Decimal(Me.m_Value)
            Me.CalculateAngle()
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Rectangle rectangle = new Rectangle(checked((int)Math.Round((double)this.StaticImage.Width * 0.12)), checked((int)Math.Round((double)this.StaticImage.Height * 0.14)), checked((int)Math.Round((double)this.StaticImage.Width * 0.76)), checked((int)Math.Round((double)this.StaticImage.Height * 0.4)));
            Dim rectangle As New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Width) * 0.12))), CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * 0.14))), CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Width) * 0.76))), CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * 0.4))))
            Me.Invalidate(rectangle)
        End Set
    End Property



    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.NumberLocations = New Rectangle(6) {}
        Me.sfCenter = New StringFormat()
        Me.sfCenterBottom = New StringFormat()
        Me.m_Angle = New Decimal(6125, 0, 0, False, 4)
        Me.m_ValueScaleFactor = Decimal.One
        Me.m_MaxValue = New Decimal(CLng(100))
        Me.m_MinValue = New Decimal()
        Me.m = New Matrix()
        Me.TextBrush = New SolidBrush(Color.Black)
    End Sub


    Private Sub CalculateAngle()
        If Not Me.ZeroCentered Then
            Me.m_Angle = New Decimal((Me.m_Value * Convert.ToDouble(Me.m_ValueScaleFactor) - Convert.ToDouble(Me.m_MinValue)) * (1.25 / Convert.ToDouble(Decimal.Subtract(Me.m_MaxValue, Me.m_MinValue))) * -1 + 0.625)
        Else
            Me.m_Angle = New Decimal((Me.m_Value * Convert.ToDouble(Me.m_ValueScaleFactor) - Convert.ToDouble(Me.m_MinValue)) * (1.5 / Convert.ToDouble(Decimal.Subtract(Me.m_MaxValue, Me.m_MinValue))) * -1 + 0.75)
        End If
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
                If Me.StaticImage IsNot Nothing Then
                    Me.StaticImage.Dispose()
                End If
                If Me.Needle IsNot Nothing Then
                    Me.Needle.Dispose()
                End If
                If Me.BaseImage IsNot Nothing Then
                    Me.BaseImage.Dispose()
                End If
                Me.sfCenter.Dispose()
                Me.sfCenterBottom.Dispose()
                Me.m.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImage Is Nothing Or Me.BaseImage Is Nothing Or Me.Needle Is Nothing) Then
            If Me._backBuffer Is Nothing Then
                Me._backBuffer = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
            End If
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImageUnscaled(Me.StaticImage, 0, 0)
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterBottom)
            End If
            Dim matrix As Matrix = Me.m
            Dim num As Single = CSng(Convert.ToDouble(Decimal.Multiply(Decimal.Negate(Me.m_Angle), New Decimal(CLng(180)))) / 3.14159265358979)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point = new Point(checked((int)Math.Round((double)this.Cx)), checked((int)Math.Round((double)this.Cy)));
            Dim point As New Point(CInt(Math.Truncate(Math.Round(CDbl(Me.Cx)))), CInt(Math.Truncate(Math.Round(CDbl(Me.Cy)))))
            matrix.RotateAt(num, point)
            graphic.Transform = Me.m
            graphic.DrawImage(Me.Needle, Me.Xoff, Me.YOff)
            Me.m.Reset()
            graphic.Transform = Me.m
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: graphic.DrawImageUnscaled(this.BaseImage, 1, checked((int)Math.Round((double)((float)(135f * this.ImageScale)))));
            graphic.DrawImageUnscaled(Me.BaseImage, 1, CInt(Math.Truncate(Math.Round(CDbl(CSng(135.0F * Me.ImageScale))))))
            e.Graphics.DrawImageUnscaled(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim width_Renamed As Single = CSng(CDbl(My.Resources.MeterNoNeedle2.Width) / CDbl(My.Resources.MeterNoNeedle2.Height))
        If Me.LastHeight <> Me.Height Or Me.LastWidth <> Me.Width Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Size size = new Size(checked((int)Math.Round((double)((float)((float)this.Height * width)))), this.Height);
            'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim size_Renamed As New Size(CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) * width_Renamed))))), Me.Height)
            Me.Size = size_Renamed
            Me.RefreshImage()
            Me.LastWidth = Me.Width
            Me.LastHeight = Me.Height
        End If
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

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueChangedEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Private Sub RefreshImage()
        Me.ImageScale = CSng(CDbl(Me.Width) / CDbl(My.Resources.MeterNoNeedle2.Width))
        If Me.ImageScale > 0.0F Then
            Me.Cx = CSng(CDbl(Me.Width) / 2)
            Me.Cy = CSng(CDbl(Me.Height) * 0.886)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Xoff = checked((int)Math.Round((double)this.Width / 2 - 2));
            Me.Xoff = CInt(Math.Round(CDbl(Me.Width) / 2 - 2))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.YOff = checked((int)Math.Round((double)((float)(45f * this.ImageScale))));
            Me.YOff = CInt(Math.Truncate(Math.Round(CDbl(CSng(45.0F * Me.ImageScale)))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)(75f * this.ImageScale))));
            Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(CSng(75.0F * Me.ImageScale)))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Width = checked((int)Math.Round((double)this.Width * 0.6));
            Me.TextRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.6)))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)((float)(50f * this.ImageScale))));
            Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale)))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.X = checked((int)Math.Round((double)(checked(this.Width - this.TextRectangle.Width)) / 2));
            Me.TextRectangle.X = CInt(Math.Truncate(Math.Round(CDbl(Me.Width - Me.TextRectangle.Width) / 2)))
            Me.sfCenterBottom.Alignment = StringAlignment.Center
            Me.sfCenterBottom.LineAlignment = StringAlignment.Far
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            Dim num As Integer = 0
            Do
                Me.NumberLocations(num) = New Rectangle()
                num += 1
            Loop While num <= 6
            If Not Me.ZeroCentered Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[0] = new Rectangle(checked((int)Math.Round((double)((float)(12f * this.ImageScale)))), checked((int)Math.Round((double)((float)(73f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(0) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(12.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(73.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(42.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[1] = new Rectangle(checked((int)Math.Round((double)((float)(60f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(1) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(60.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(42.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[2] = new Rectangle(checked((int)Math.Round((double)((float)(104f * this.ImageScale)))), checked((int)Math.Round((double)((float)(38f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(2) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(104.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(38.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(42.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[3] = new Rectangle(checked((int)Math.Round((double)((float)(150f * this.ImageScale)))), checked((int)Math.Round((double)((float)(38f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(3) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(150.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(38.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[4] = new Rectangle(checked((int)Math.Round((double)((float)(200f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(4) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(200.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[5] = new Rectangle(checked((int)Math.Round((double)((float)(248f * this.ImageScale)))), checked((int)Math.Round((double)((float)(73f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(5) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(248.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(73.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            Else
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[0] = new Rectangle(0, checked((int)Math.Round((double)((float)(85f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(0) = New Rectangle(0, CInt(Math.Truncate(Math.Round(CDbl(CSng(85.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(42.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[1] = new Rectangle(checked((int)Math.Round((double)((float)(40f * this.ImageScale)))), checked((int)Math.Round((double)((float)(60f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(1) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(40.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(60.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(42.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[2] = new Rectangle(checked((int)Math.Round((double)((float)(80f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(2) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(80.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(42.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(42.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[3] = new Rectangle(checked((int)Math.Round((double)((float)(125f * this.ImageScale)))), checked((int)Math.Round((double)((float)(38f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(3) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(125.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(38.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[4] = new Rectangle(checked((int)Math.Round((double)((float)(170f * this.ImageScale)))), checked((int)Math.Round((double)((float)(42f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(4) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(170.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(42.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[5] = new Rectangle(checked((int)Math.Round((double)((float)(210f * this.ImageScale)))), checked((int)Math.Round((double)((float)(60f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(5) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(210.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(60.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.NumberLocations[6] = new Rectangle(checked((int)Math.Round((double)((float)(248f * this.ImageScale)))), checked((int)Math.Round((double)((float)(85f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
                Me.NumberLocations(6) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(248.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(85.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            End If
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            Me.StaticImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.MeterNoNeedle2.Width) * Me.ImageScale), Convert.ToInt32(CSng(My.Resources.MeterNoNeedle2.Height) * Me.ImageScale))
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
            If Decimal.Compare(Math.Abs(Me.m_MinValue), Math.Abs(Me.m_MaxValue)) <> 0 Then
                graphic.DrawImage(My.Resources.MeterNoNeedle2, 0.0F, 0.0F, CSng(My.Resources.MeterNoNeedle2.Width) * Me.ImageScale, CSng(My.Resources.MeterNoNeedle2.Height) * Me.ImageScale)
                Me.ZeroCentered = False
            Else
                graphic.DrawImage(My.Resources.MeterNoNeedleCenterScale, 0.0F, 0.0F, CSng(My.Resources.MeterNoNeedle2.Width) * Me.ImageScale, CSng(My.Resources.MeterNoNeedle2.Height) * Me.ImageScale)
                Me.ZeroCentered = True
            End If
            Dim num1 As Decimal = Decimal.Divide(Decimal.Subtract(Me.m_MaxValue, Me.m_MinValue), New Decimal(CLng(5)))
            If Me.ZeroCentered Then
                num1 = Decimal.Divide(Decimal.Subtract(Me.m_MaxValue, Me.m_MinValue), New Decimal(CLng(6)))
            End If
            'INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim font_Renamed As New Font("Arial", 11.0F * Me.ImageScale, FontStyle.Regular, GraphicsUnit.Point)
            Dim solidBrush As New SolidBrush(Color.FromArgb(245, 45, 45, 45))
            graphic.DrawString(Conversions.ToString(Me.m_MinValue), font_Renamed, solidBrush, Me.NumberLocations(0), Me.sfCenter)
            graphic.DrawString(Conversions.ToString(Decimal.Add(Me.m_MinValue, num1)), font_Renamed, solidBrush, Me.NumberLocations(1), Me.sfCenter)
            graphic.DrawString(Conversions.ToString(Decimal.Add(Me.m_MinValue, Decimal.Multiply(num1, New Decimal(CLng(2))))), font_Renamed, solidBrush, Me.NumberLocations(2), Me.sfCenter)
            If Me.ZeroCentered Then
                graphic.DrawString("0", font_Renamed, solidBrush, Me.NumberLocations(3), Me.sfCenter)
            Else
                graphic.DrawString(Conversions.ToString(Decimal.Add(Me.m_MinValue, Decimal.Multiply(num1, New Decimal(CLng(3))))), font_Renamed, solidBrush, Me.NumberLocations(3), Me.sfCenter)
            End If
            graphic.DrawString(Conversions.ToString(Decimal.Add(Me.m_MinValue, Decimal.Multiply(num1, New Decimal(CLng(4))))), font_Renamed, solidBrush, Me.NumberLocations(4), Me.sfCenter)
            graphic.DrawString(Conversions.ToString(Decimal.Add(Me.m_MinValue, Decimal.Multiply(num1, New Decimal(CLng(5))))), font_Renamed, solidBrush, Me.NumberLocations(5), Me.sfCenter)
            If Me.ZeroCentered Then
                graphic.DrawString(Conversions.ToString(Decimal.Add(Me.m_MinValue, Decimal.Multiply(num1, New Decimal(CLng(6))))), font_Renamed, solidBrush, Me.NumberLocations(6), Me.sfCenter)
            End If
            Dim num2 As Integer = Math.Max(Convert.ToInt32(CSng(My.Resources.MeterNeedle.Width) * Me.ImageScale), 1)
            Dim num3 As Integer = Math.Max(Convert.ToInt32(CSng(My.Resources.MeterNeedle.Height) * Me.ImageScale), 1)
            Me.Needle = New Bitmap(num2, num3)
            Me.Needle = New Bitmap(num2, num3)
            graphic = Graphics.FromImage(Me.Needle)
            graphic.Transform = Me.m
            graphic.DrawImage(My.Resources.MeterNeedle, 0.0F, 0.0F, CSng(My.Resources.MeterNeedle.Width) * Me.ImageScale, CSng(My.Resources.MeterNeedle.Height) * Me.ImageScale)
            If Me.BaseImage IsNot Nothing Then
                Me.BaseImage.Dispose()
            End If
            Me.BaseImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.MeterBase.Width) * Me.ImageScale), Convert.ToInt32(CSng(My.Resources.MeterBase.Height) * Me.ImageScale))
            graphic.Dispose()
            graphic = Graphics.FromImage(Me.BaseImage)
            graphic.DrawImage(My.Resources.MeterBase, 0.0F, 0.0F, CSng(My.Resources.MeterBase.Width) * Me.ImageScale, CSng(My.Resources.MeterBase.Height) * Me.ImageScale)
            graphic.Dispose()
        End If
    End Sub

    Public Event ValueChanged As EventHandler
End Class

