Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class Meter2
    Inherits AnalogMeterBase

    Private Frame As Bitmap

    Private BackGround As Bitmap

    Private Needle As Bitmap

    Private LineScale As Bitmap

    Private ScaledNeedle As Bitmap

    Private Cx As Single

    Private Cy As Single

    Private Xoff As Integer

    Private YOff As Integer

    Private ZeroCentered As Boolean

    Private ImageScale As Single

    Private NumberLocations() As Rectangle

    Private sfCenterBottom As StringFormat

    Private m As Matrix

    Private m_Angle As Decimal

    Public Sub New()
        Me.NumberLocations = New Rectangle(10) {}
        Me.m = New Matrix()
        Me.m_Angle = New Decimal(87, 0, 0, False, 2)
        Me.sfCenterBottom = New StringFormat() With {
         .Alignment = StringAlignment.Center,
         .LineAlignment = StringAlignment.Far
        }
        Me.BaseImage = My.Resources.Frame
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If Me.Frame IsNot Nothing Then
                    Me.Frame.Dispose()
                End If
                If Me.Needle IsNot Nothing Then
                    Me.Needle.Dispose()
                End If
                Me.sfCenterBottom.Dispose()
                Me.LineScale.Dispose()
                Me.m.Dispose()
                Me.ScaledNeedle.Dispose()
                Me.BackGround.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.Frame Is Nothing Or Me.BackGround Is Nothing Or Me.Needle Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.DrawImageUnscaled(Me.BackGround, 0, 0)
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(Me.Text, Me.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterBottom)
            End If
            graphic.DrawImageUnscaled(Me.Needle, 0, 0)
            graphic.DrawImageUnscaled(Me.Frame, 0, 0)
            graphic.Dispose()
            e.Graphics.DrawImageUnscaled(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        Me.UpdateNeedleImage()
    End Sub

    Protected Overrides Sub CreateStaticImage()
        Me.ImageScale = CSng(CDbl(Me.Width) / CDbl(My.Resources.Frame.Width))
        If Not (Me.ImageScale <= 0.0F Or Me.ImageScale > 100.0F) Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)(150f * this.ImageScale))));
            Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(CSng(150.0F * Me.ImageScale)))))
            Me.TextRectangle.Width = Me.Width
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)((float)(50f * this.ImageScale))));
            Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale)))))
            Me.TextRectangle.X = 0
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            Dim num As Integer = 0
            Do
                Me.NumberLocations(num) = New Rectangle()
                num += 1
            Loop While num <= 6
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[0] = new Rectangle(checked((int)Math.Round((double)((float)(6f * this.ImageScale)))), checked((int)Math.Round((double)((float)(171f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(0) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(6.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(171.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[1] = new Rectangle(checked((int)Math.Round((double)((float)(58f * this.ImageScale)))), checked((int)Math.Round((double)((float)(124f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(1) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(58.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(124.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[2] = new Rectangle(checked((int)Math.Round((double)((float)(113f * this.ImageScale)))), checked((int)Math.Round((double)((float)(87f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(2) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(113.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(87.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[3] = new Rectangle(checked((int)Math.Round((double)((float)(169f * this.ImageScale)))), checked((int)Math.Round((double)((float)(62f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(3) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(169.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(62.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[4] = new Rectangle(checked((int)Math.Round((double)((float)(231f * this.ImageScale)))), checked((int)Math.Round((double)((float)(44f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(4) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(231.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(44.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[5] = new Rectangle(checked((int)Math.Round((double)((float)(297f * this.ImageScale)))), checked((int)Math.Round((double)((float)(37f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(5) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(297.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(37.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[6] = new Rectangle(checked((int)Math.Round((double)((float)(362f * this.ImageScale)))), checked((int)Math.Round((double)((float)(44f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(6) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(362.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(44.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[7] = new Rectangle(checked((int)Math.Round((double)((float)(423f * this.ImageScale)))), checked((int)Math.Round((double)((float)(62f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(7) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(423.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(62.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[8] = new Rectangle(checked((int)Math.Round((double)((float)(483f * this.ImageScale)))), checked((int)Math.Round((double)((float)(87f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(8) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(483.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(87.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[9] = new Rectangle(checked((int)Math.Round((double)((float)(535f * this.ImageScale)))), checked((int)Math.Round((double)((float)(124f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(9) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(535.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(124.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.NumberLocations[10] = new Rectangle(checked((int)Math.Round((double)((float)(584f * this.ImageScale)))), checked((int)Math.Round((double)((float)(171f * this.ImageScale)))), checked((int)Math.Round((double)((float)(50f * this.ImageScale)))), checked((int)Math.Round((double)((float)(20f * this.ImageScale)))));
            Me.NumberLocations(10) = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(CSng(584.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(171.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(50.0F * Me.ImageScale))))), CInt(Math.Truncate(Math.Round(CDbl(CSng(20.0F * Me.ImageScale))))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Xoff = checked((int)Math.Round((double)this.Width / 2 - (double)((float)My.Resources.Needle.Width * this.ImageScale / 2f)));
            Me.Xoff = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) / 2 - CDbl(CSng(My.Resources.Needle.Width) * Me.ImageScale / 2.0F))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.YOff = checked((int)Math.Round((double)((float)(56f * this.ImageScale))));
            Me.YOff = CInt(Math.Truncate(Math.Round(CDbl(CSng(56.0F * Me.ImageScale)))))
            Me.Cx = CSng(CDbl(Me.Width) / 2)
            Me.Cy = CSng(My.Resources.Needle.Height) * Me.ImageScale + CSng(Me.YOff)
            Me.BackGround = New Bitmap(Convert.ToInt32(CSng(My.Resources.MeterScaleBackGround.Width) * Me.ImageScale), Convert.ToInt32(CSng(My.Resources.MeterScaleBackGround.Height) * Me.ImageScale))
            Dim graphic As Graphics = Graphics.FromImage(Me.BackGround)
            If Math.Abs(Me.m_Minimum) <> Math.Abs(Me.m_Maximum) Then
                graphic.DrawImage(My.Resources.MeterScaleBackGround, 0.0F, 0.0F, CSng(My.Resources.MeterScaleBackGround.Width) * Me.ImageScale, CSng(My.Resources.MeterScaleBackGround.Height) * Me.ImageScale)
                Me.ZeroCentered = False
            Else
                graphic.DrawImage(My.Resources.MeterScaleBackGround, 0.0F, 0.0F, CSng(My.Resources.MeterScaleBackGround.Width) * Me.ImageScale, CSng(My.Resources.MeterScaleBackGround.Height) * Me.ImageScale)
                Me.ZeroCentered = True
            End If
            Me.LineScale = New Bitmap(Convert.ToInt32(CSng(My.Resources.MeterScale.Width) * Me.ImageScale), Convert.ToInt32(CSng(My.Resources.MeterScale.Height) * Me.ImageScale))
            Me.m.Reset()
            graphic.Transform = Me.m
            graphic.DrawImage(My.Resources.MeterScale, 40.0F * Me.ImageScale, 60.0F * Me.ImageScale, CSng(My.Resources.MeterScale.Width) * Me.ImageScale, CSng(My.Resources.MeterScale.Height) * Me.ImageScale)
            Dim num1 As New Decimal((Me.m_Maximum - Me.m_Minimum) / 10)
            'INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim font_Renamed As New Font("Arial", 14.0F * Me.ImageScale, FontStyle.Regular, GraphicsUnit.Point)
            Dim solidBrush As New SolidBrush(Color.FromArgb(245, 45, 45, 45))
            Dim num2 As Integer = 0
            Do
                graphic.DrawString(Conversions.ToString(Me.m_Minimum + Convert.ToDouble(Decimal.Multiply(New Decimal(num2), num1))), font_Renamed, solidBrush, Me.NumberLocations(num2), Me.sf)
                num2 += 1
            Loop While num2 <= 10
            If Me.ZeroCentered Then
                graphic.DrawString(Conversions.ToString(Me.m_Minimum + Convert.ToDouble(Decimal.Multiply(num1, New Decimal(CLng(6))))), font_Renamed, solidBrush, Me.NumberLocations(6), Me.sf)
            End If
            Dim num3 As Integer = Math.Max(Convert.ToInt32(CSng(My.Resources.Needle.Width) * Me.ImageScale), 1)
            Dim num4 As Integer = Math.Max(Convert.ToInt32(CSng(My.Resources.Needle.Height) * Me.ImageScale), 1)
            Me.ScaledNeedle = New Bitmap(num3, num4)
            Graphics.FromImage(Me.ScaledNeedle).DrawImage(My.Resources.Needle, 0, 0, Me.ScaledNeedle.Width, Me.ScaledNeedle.Height)
            Me.Needle = New Bitmap(Me.Width, Me.Height)
            Me.UpdateNeedleImage()
            Me.Frame = New Bitmap(Convert.ToInt32(CSng(My.Resources.Frame.Width) * Me.ImageScale), Convert.ToInt32(CSng(My.Resources.Frame.Height) * Me.ImageScale))
            graphic.Dispose()
            graphic = Graphics.FromImage(Me.Frame)
            graphic.DrawImage(My.Resources.Frame, 0.0F, 0.0F, CSng(My.Resources.Frame.Width) * Me.ImageScale, CSng(My.Resources.Frame.Height) * Me.ImageScale)
            Me.BackBuffer = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
            graphic.Dispose()
            Me.Invalidate()
        End If
    End Sub

    Private Sub UpdateNeedleImage()
        If Me.Needle IsNot Nothing Then
            If Not Me.ZeroCentered Then
                Me.m_Angle = New Decimal((Me.m_Value * Me.m_ValueScaleFactor - Me.m_Minimum) * (1 / (Me.m_Maximum - Me.m_Minimum)) * -1.735 + 0.8675)
            Else
                Me.m_Angle = New Decimal((Me.m_Value * Me.m_ValueScaleFactor - Me.m_Minimum) * (1.5 / (Me.m_Maximum - Me.m_Minimum)) * -1 + 0.75)
            End If
            Dim graphic As Graphics = Graphics.FromImage(Me.Needle)
            Me.m.Reset()
            graphic.Clear(Color.Transparent)
            Dim matrix As Matrix = Me.m
            Dim num As Single = CSng(Convert.ToDouble(Decimal.Multiply(Decimal.Negate(Me.m_Angle), New Decimal(CLng(180)))) / 3.14159265358979)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point = new Point(checked((int)Math.Round((double)this.Cx)), checked((int)Math.Round((double)this.Cy)));
            Dim point As New Point(CInt(Math.Truncate(Math.Round(CDbl(Me.Cx)))), CInt(Math.Truncate(Math.Round(CDbl(Me.Cy)))))
            matrix.RotateAt(num, point)
            graphic.Transform = Me.m
            graphic.DrawImage(Me.ScaledNeedle, CSng(Me.Xoff), CSng(Me.YOff), CSng(My.Resources.Needle.Width) * Me.ImageScale, CSng(My.Resources.Needle.Height) * Me.ImageScale)
        End If
    End Sub
End Class

