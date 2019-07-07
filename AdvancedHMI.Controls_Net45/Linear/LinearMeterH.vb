Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class LinearMeterH
    Inherits LinearMeterBase



    Private ValueRectangle As Rectangle

    Private ValueBrush As SolidBrush

    Private m_blend As Blend

    Public Sub New()
        Me.ValueRectangle = New Rectangle()

        m_blend = New Blend
        Me.ValueRectangle = Nothing
        Me.m_blend.Factors = New Single() {0.5F, 0.85F, 0.2F}
        Me.m_blend.Positions = New Single() {0.0F, 0.3F, 1.0F}
        MyBase.BackColor = Color.FromArgb(255, 255, 255)
        MyBase.ForeColor = Color.Black


    End Sub


    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Me.CreateStaticImage()
    End Sub



    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim str As String
        Dim linearGradientBrush As LinearGradientBrush
        If Me.BackBuffer IsNot Nothing Then
            Dim graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.FillRectangle(Brushes.LightGray, Me.BarRectangle)
            graphic.DrawImage(Me.StaticImage, 0, 0)
            Dim num As Double = Math.Max(Math.Min(Me.Value, Me.m_Maximum / Me.m_ValueScaleFactor), Me.m_Minimum / Me.m_ValueScaleFactor)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.ValueRectangle.Height = checked(this.BarRectangle.Height - 2);
            Me.ValueRectangle.Height = Me.BarRectangle.Height - 2
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.ValueRectangle.Y = checked(this.BarRectangle.Y + 1);
            Me.ValueRectangle.Y = Me.BarRectangle.Y + 1
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.ValueRectangle.Width = Convert.ToInt32((num * this.m_ValueScaleFactor - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(checked(this.BarRectangle.Width - 2)));
            Me.ValueRectangle.Width = Convert.ToInt32((num * Me.m_ValueScaleFactor - Me.m_Minimum) / (Me.m_Maximum - Me.m_Minimum) * CDbl(Me.BarRectangle.Width - 2))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: int x = checked(checked(this.BarRectangle.X + this.ValueRectangle.Width) + 1);
            Dim x As Integer = (Me.BarRectangle.X + Me.ValueRectangle.Width) + 1
            If Me.m_FillType = LinearMeterH.FillTypes.WideBand Then
                Me.ValueRectangle.Width = 12
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.ValueRectangle.X = checked(x - 6);
                Me.ValueRectangle.X = x - 6
            ElseIf Me.m_FillType <> LinearMeterH.FillTypes.NarrowBand Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.ValueRectangle.X = checked(this.BarRectangle.X + 1);
                Me.ValueRectangle.X = Me.BarRectangle.X + 1
            Else
                Me.ValueRectangle.Width = 4
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.ValueRectangle.X = checked(x - 2);
                Me.ValueRectangle.X = x - 2
            End If
            If Me.ValueRectangle.Width > 0 And Me.ValueRectangle.Height > 0 Then
                If Not (Me.m_Value * Me.m_ValueScaleFactor >= Me.m_TargetValue - Me.m_ToleranceMinus And Me.m_Value * Me.m_ValueScaleFactor <= Me.m_TargetValue + Me.m_TolerancePlus) Then
                    Me.ValueBrush.Color = Color.Red
                    linearGradientBrush = New LinearGradientBrush(Me.ValueRectangle, BeveledButtonDisplay.GetRelativeColor(Me.m_FillColor, 0.5), BeveledButtonDisplay.GetRelativeColor(Me.m_FillColor, 2), 90.0F, False)
                Else
                    Me.ValueBrush.Color = Color.Green
                    linearGradientBrush = New LinearGradientBrush(Me.ValueRectangle, BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 0.5), BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 1.5), 90.0F, False)
                End If
                Dim blend As New Blend()
                Dim singleArray() As Single = {0.5F, 0.85F, 0.2F}
                blend.Factors = singleArray
                singleArray = New Single() {0.0F, 0.3F, 1.0F}
                blend.Positions = singleArray
                linearGradientBrush.Blend = blend
                graphic.FillRectangle(linearGradientBrush, Me.ValueRectangle)
            End If
            If Me.m_FillType <> LinearMeterH.FillTypes.Fill Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawLine(Pens.Black, x, this.ValueRectangle.Y, x, checked(checked(this.ValueRectangle.Y + this.ValueRectangle.Height) - 1));
                graphic.DrawLine(Pens.Black, x, Me.ValueRectangle.Y, x, (Me.ValueRectangle.Y + Me.ValueRectangle.Height) - 1)
            End If
            Me.sf.LineAlignment = StringAlignment.Center
            If (If(Me.m_NumericFormat Is Nothing OrElse String.Compare(Me.m_NumericFormat, String.Empty) = 0, True, False)) Then
                str = Conversions.ToString(Me.m_Value)
            Else
                Try
                    str = Me.m_Value.ToString(Me.m_NumericFormat)
                Catch exception As Exception
                    ProjectData.SetProjectError(exception)
                    str = "NumericFormat Invalid"
                    ProjectData.ClearProjectError()
                End Try
            End If
            If Me.m_FillType <> LinearMeterH.FillTypes.Fill Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.X = checked(checked(this.ValueRectangle.X + this.ValueRectangle.Width) + 1);
                Me.TextRectangle.X = (Me.ValueRectangle.X + Me.ValueRectangle.Width) + 1
                Me.TextRectangle.Y = Me.BarRectangle.Y
                Me.TextRectangle.Height = Me.BarRectangle.Height
                Dim sizeF As SizeF = graphic.MeasureString(str, Me.Font)
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Width = checked((int)Math.Round((double)((float)(sizeF.Width + 2f))));
                Me.TextRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(CSng(sizeF.Width + 2.0F)))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: if (checked(this.TextRectangle.X + this.TextRectangle.Width) > checked(this.BarRectangle.X + this.BarRectangle.Width) & (double)(checked(this.TextRectangle.X + this.TextRectangle.Width)) <= (double)(checked(this.BarRectangle.X + this.BarRectangle.Width)) + (double)this.ValueRectangle.Width / 2 + 1)
                If Me.TextRectangle.X + Me.TextRectangle.Width > Me.BarRectangle.X + Me.BarRectangle.Width And CDbl(Me.TextRectangle.X + Me.TextRectangle.Width) <= CDbl(Me.BarRectangle.X + Me.BarRectangle.Width) + CDbl(Me.ValueRectangle.Width) / 2 + 1 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: this.TextRectangle.X = checked(checked(this.BarRectangle.X + this.BarRectangle.Width) - this.TextRectangle.Width);
                    Me.TextRectangle.X = (Me.BarRectangle.X + Me.BarRectangle.Width) - Me.TextRectangle.Width
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: if ((double)(checked(this.TextRectangle.X + this.TextRectangle.Width)) > (double)(checked(this.BarRectangle.X + this.BarRectangle.Width)) + (double)this.ValueRectangle.Width / 2 + 1)
                If CDbl(Me.TextRectangle.X + Me.TextRectangle.Width) > CDbl(Me.BarRectangle.X + Me.BarRectangle.Width) + CDbl(Me.ValueRectangle.Width) / 2 + 1 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: this.TextRectangle.X = checked(checked(this.ValueRectangle.X - this.TextRectangle.Width) - 1);
                    Me.TextRectangle.X = (Me.ValueRectangle.X - Me.TextRectangle.Width) - 1
                End If
                Me.sf.LineAlignment = StringAlignment.Center
                Me.sf.Alignment = StringAlignment.Center
                graphic.DrawString(str, Me.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            ElseIf CSng(Me.ValueRectangle.Width) <= graphic.MeasureString(str, Me.Font).Width Then
                Me.sf.Alignment = StringAlignment.Near
                graphic.DrawString(str, Me.Font, Me.TextBrush, Me.BarRectangle, Me.sf)
            Else
                Me.sf.Alignment = StringAlignment.Far
                graphic.DrawString(str, Me.Font, Me.TextBrush, Me.ValueRectangle, Me.sf)
            End If
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        Me.Invalidate(Me.BarRectangle)
    End Sub

    Protected Overrides Sub CreateStaticImage()
        Dim rectangle As New Rectangle()
        Dim num As Integer = 0
        Dim num1 As Integer = 0
        Dim y As Integer = 0
        If Not (Me.Width <= 0 And Me.Height <= 0) Then
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
            Me.StaticImage = New Bitmap(Me.Width, Me.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(BeveledButtonDisplay.GetRelativeColor(this.m_BorderColor, 1)), checked(this.m_BorderWidth * 2), checked(this.m_BorderWidth * 2), checked(this.Width - checked(this.m_BorderWidth * 4)), checked(this.Height - checked(this.m_BorderWidth * 4)));
            graphic.FillRectangle(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.m_BorderColor, 1)), Me.m_BorderWidth * 2, Me.m_BorderWidth * 2, Me.Width - Me.m_BorderWidth * 4, Me.Height - Me.m_BorderWidth * 4)
            BeveledButtonDisplay.Draw3DBorder(Me, graphic, Me.m_BorderColor, Me.m_BorderWidth)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(this.BackColor), checked(this.m_BorderWidth * 2), checked(this.m_BorderWidth * 2), checked(this.Width - checked(this.m_BorderWidth * 4)), checked(this.Height - checked(this.m_BorderWidth * 4)));
            graphic.FillRectangle(New SolidBrush(Me.BackColor), Me.m_BorderWidth * 2, Me.m_BorderWidth * 2, Me.Width - Me.m_BorderWidth * 4, Me.Height - Me.m_BorderWidth * 4)
            Dim stringFormat As New StringFormat()
            If (If(Me.Text Is Nothing OrElse String.Compare(Me.Text, String.Empty) = 0, False, True)) Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: rectangle = new Rectangle(checked(this.m_BorderWidth * 2), checked(checked(this.m_BorderWidth * 2) + 1), checked(checked(this.Width - checked(this.m_BorderWidth * 4)) - 1), checked(checked(this.Height - checked(this.m_BorderWidth * 4)) - 2));
                rectangle = New Rectangle(Me.m_BorderWidth * 2, (Me.m_BorderWidth * 2) + 1, (Me.Width - Me.m_BorderWidth * 4) - 1, (Me.Height - Me.m_BorderWidth * 4) - 2)
                stringFormat.Alignment = StringAlignment.Center
                stringFormat.LineAlignment = StringAlignment.Near
                graphic.DrawString(Me.Text, Me.Font, Me.TextBrush, rectangle, stringFormat)
            End If
            Dim sizeF As SizeF = graphic.MeasureString(Me.Text, Me.Font, rectangle.Width)
            Dim r As Byte = Me.ForeColor.R
            Dim g As Byte = Me.ForeColor.G
            'INSTANT VB NOTE: The variable foreColor was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim foreColor_Renamed As Color = Me.ForeColor
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: graphic.DrawLine(new Pen(Color.FromArgb(80, (int)r, (int)g, (int)foreColor.B), 2f), (float)(checked(this.m_BorderWidth * 2)), sizeF.Height + (float)(checked(this.m_BorderWidth * 2)) + 2f, (float)(checked(this.Width - checked(this.m_BorderWidth * 2))), sizeF.Height + (float)(checked(this.m_BorderWidth * 2)) + 2f);
            graphic.DrawLine(New Pen(Color.FromArgb(80, CInt(r), CInt(g), CInt(foreColor_Renamed.B)), 2.0F), CSng(Me.m_BorderWidth * 2), sizeF.Height + CSng(Me.m_BorderWidth * 2) + 2.0F, CSng(Me.Width - Me.m_BorderWidth * 2), sizeF.Height + CSng(Me.m_BorderWidth * 2) + 2.0F)
            Dim num2 As Integer = Convert.ToInt32(CDbl(Me.Height) * 0.12)
            Dim num3 As Integer = Convert.ToInt32(CDbl(Me.Height) * 0.08)
            Dim pen As New Pen(Me.ForeColor, 2.0F)
            Dim pen1 As New Pen(Me.ForeColor, 1.0F)
            Dim sizeF1 As SizeF = graphic.MeasureString(Conversions.ToString(Me.m_Maximum), Me.Font)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: int num4 = checked((int)Math.Round((double)sizeF1.Width));
            Dim num4 As Integer = CInt(Math.Round(CDbl(sizeF1.Width)))
            sizeF1 = graphic.MeasureString(Conversions.ToString(Me.m_Minimum), Me.Font)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: int num5 = checked((int)Math.Round((double)sizeF1.Width));
            Dim num5 As Integer = CInt(Math.Round(CDbl(sizeF1.Width)))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.BarRectangle = new Rectangle() { X = checked((int)Math.Round((double)num5 / 2 + (double)(checked(this.m_BorderWidth * 2)))), Y = checked((int)Math.Round((double)(sizeF.Height + (float)this.Font.Height + (float)(checked(this.m_BorderWidth * 2)) + (float)num2) + (double)this.Height * 0.1)), Width = checked((int)Math.Round((double)this.Width - (double)num4 / 2 - (double)num5 / 2 - (double)(checked(this.BorderWidth * 4)))), Height = checked((int)Math.Round((double)((float)(checked(this.Height - checked(this.m_BorderWidth * 4))) - sizeF.Height - (float)num2 - (float)this.Font.Height) - (double)this.Height * 0.15)) };
            Me.BarRectangle = New Rectangle() With {
             .X = CInt(Math.Truncate(Math.Round(CDbl(num5) / 2 + CDbl(Me.m_BorderWidth * 2)))),
             .Y = CInt(Math.Truncate(Math.Round(CDbl(sizeF.Height + CSng(Me.Font.Height) + CSng(Me.m_BorderWidth * 2) + CSng(num2)) + CDbl(Me.Height) * 0.1))),
             .Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) - CDbl(num4) / 2 - CDbl(num5) / 2 - CDbl(Me.BorderWidth * 4)))),
             .Height = CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.Height - Me.m_BorderWidth * 4) - sizeF.Height - CSng(num2) - CSng(Me.Font.Height)) - CDbl(Me.Height) * 0.15)))
            }
            graphic.FillRectangle(Brushes.LightGray, Me.BarRectangle)
            If Me.m_ShowValidRangeMarker Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: int xPos = checked(this.ValueToXPos(Math.Max(this.m_TargetValue - this.m_ToleranceMinus, this.m_Minimum)) - this.ValueToXPos(Math.Min(this.m_TargetValue + this.m_TolerancePlus, this.m_Maximum)));
                Dim xPos As Integer = Me.ValueToXPos(Math.Max(Me.m_TargetValue - Me.m_ToleranceMinus, Me.m_Minimum)) - Me.ValueToXPos(Math.Min(Me.m_TargetValue + Me.m_TolerancePlus, Me.m_Maximum))
                If xPos > 0 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(BeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 0.7)), this.ValueToXPos(Math.Min(this.m_TargetValue + this.m_TolerancePlus, this.m_Maximum)), checked(checked(this.BarRectangle.Y - 2) - num3), xPos, num3);
                    graphic.FillRectangle(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 0.7)), Me.ValueToXPos(Math.Min(Me.m_TargetValue + Me.m_TolerancePlus, Me.m_Maximum)), (Me.BarRectangle.Y - 2) - num3, xPos, num3)
                End If
            End If
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point = new Point(checked(this.BarRectangle.X + 1), checked(this.BarRectangle.Y - 2));
            Dim point As New Point(Me.BarRectangle.X + 1, Me.BarRectangle.Y - 2)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point1 = new Point(checked(this.BarRectangle.X + 1), checked(checked(this.BarRectangle.Y - 2) - num2));
            Dim point1 As New Point(Me.BarRectangle.X + 1, (Me.BarRectangle.Y - 2) - num2)
            graphic.DrawLine(pen, point, point1)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(checked((int)Math.Round((double)this.BarRectangle.X - (double)num5 / 2)), checked(checked(checked(this.BarRectangle.Y - this.Font.Height) - num2) - 4), checked(num5 + 2), checked(this.Font.Height + 4));
            Dim rectangle1 As New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.BarRectangle.X) - CDbl(num5) / 2))), (Me.BarRectangle.Y - Me.Font.Height - num2) - 4, num5 + 2, Me.Font.Height + 4)
            stringFormat.LineAlignment = StringAlignment.Center
            stringFormat.Alignment = StringAlignment.Center
            graphic.DrawString(Conversions.ToString(Me.m_Minimum), Me.Font, Me.TextBrush, rectangle1, stringFormat)
            If Me.m_MajorDivisions > 0 Then
                Do While num < Me.m_MajorDivisions
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num1 = checked((int)Math.Round((double)this.BarRectangle.X + (double)this.BarRectangle.Width / (double)this.m_MajorDivisions * (double)(checked(num + 1)) - 1));
                    num1 = CInt(Math.Truncate(Math.Round(CDbl(Me.BarRectangle.X) + CDbl(Me.BarRectangle.Width) / CDbl(Me.m_MajorDivisions) * CDbl(num + 1) - 1)))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: y = checked(this.BarRectangle.Y - 2);
                    y = Me.BarRectangle.Y - 2
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: int num6 = checked(y - num2);
                    Dim num6 As Integer = y - num2
                    point1 = New Point(num1, y)
                    point = New Point(num1, num6)
                    graphic.DrawLine(pen, point1, point)
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: rectangle1 = new Rectangle(checked(num1 - 20), checked(checked(num6 - this.Font.Height) - 2), 40, checked(this.Font.Height + 2));
                    rectangle1 = New Rectangle(num1 - 20, (num6 - Me.Font.Height) - 2, 40, Me.Font.Height + 2)
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.DrawString(Conversions.ToString(this.m_Minimum + (double)(checked(num + 1)) * ((this.m_Maximum - this.m_Minimum) / (double)this.m_MajorDivisions)), this.Font, this.TextBrush, rectangle1, stringFormat);
                    graphic.DrawString(Conversions.ToString(Me.m_Minimum + CDbl(num + 1) * ((Me.m_Maximum - Me.m_Minimum) / CDbl(Me.m_MajorDivisions))), Me.Font, Me.TextBrush, rectangle1, stringFormat)
                    If Me.m_MinorDivisions > 1 Then
                        Dim i As Integer = 0
                        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        'ORIGINAL LINE: for (int i = 0; i < checked(this.m_MinorDivisions - 1); i += 1)
                        Do While i < Me.m_MinorDivisions - 1
                            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            'ORIGINAL LINE: int num7 = checked((int)Math.Round((double)this.BarRectangle.X + (double)this.BarRectangle.Width / (double)(checked(this.m_MajorDivisions * this.m_MinorDivisions)) * (double)(checked(i + 1)) + (double)this.BarRectangle.Width / (double)this.m_MajorDivisions * (double)num - 1));
                            Dim num7 As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.BarRectangle.X) + CDbl(Me.BarRectangle.Width) / CDbl(Me.m_MajorDivisions * Me.m_MinorDivisions) * CDbl(i + 1) + CDbl(Me.BarRectangle.Width) / CDbl(Me.m_MajorDivisions) * CDbl(num) - 1)))
                            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            'ORIGINAL LINE: point1 = new Point(num7, checked(this.BarRectangle.Y - 2));
                            point1 = New Point(num7, Me.BarRectangle.Y - 2)
                            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            'ORIGINAL LINE: point = new Point(num7, checked(checked(this.BarRectangle.Y - 2) - num3));
                            point = New Point(num7, (Me.BarRectangle.Y - 2) - num3)
                            graphic.DrawLine(pen1, point1, point)
                            i += 1
                        Loop
                    End If
                    num += 1
                Loop
                graphic.DrawLine(pen1, Convert.ToInt32(Me.BarRectangle.X), y, num1, y)
            End If
            Me.Invalidate()
        End If
    End Sub

    Private Function ValueToXPos(ByVal value As Double) As Integer
        Dim mMaximum As Double = Me.m_Maximum - Me.m_Minimum
        Dim num As Double = (value - Me.m_Minimum) / mMaximum
        Dim num1 As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.BarRectangle.Width) * num)))
        Dim x As Integer = (Me.BarRectangle.X + Me.BarRectangle.Width) - num1
        Return x
    End Function


End Class

