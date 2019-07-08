Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class LinearMeterV
    Inherits LinearMeterBase



    Private ValueRectangle As Rectangle

    Private ValueBrush As SolidBrush

    Private m_blend As Blend


    Public Sub New()

        Me.ValueRectangle = New Rectangle()
        m_blend = New Blend
        Me.ValueRectangle = Nothing
        MyBase.BackColor = Color.FromArgb(255, 255, 255)
        MyBase.ForeColor = Color.Black
        Me.m_blend.Factors = New Single() {0.5F, 0.85F, 0.2F}
        Me.m_blend.Positions = New Single() {0.0F, 0.3F, 1.0F}

        Me.ValueBrush = New SolidBrush(Color.Red)
    End Sub



    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Me.CreateStaticImage()
    End Sub



    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim str As String
        Dim linearGradientBrush As LinearGradientBrush
        MyBase.OnPaint(e)
        If Me.BackBuffer IsNot Nothing Then
            Dim graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.DrawImage(Me.StaticImage, 0, 0)
            Dim num As Double = Math.Max(Math.Min(Me.Value, Me.m_Maximum / Me.m_ValueScaleFactor), Me.m_Minimum / Me.m_ValueScaleFactor)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.ValueRectangle.Width = checked(this.BarRectangle.Width - 2);
            Me.ValueRectangle.Width = Me.BarRectangle.Width - 2
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.ValueRectangle.X = checked(this.BarRectangle.X + 1);
            Me.ValueRectangle.X = Me.BarRectangle.X + 1
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.ValueRectangle.Height = Convert.ToInt32((num * this.m_ValueScaleFactor - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(checked(this.BarRectangle.Height - 2)));
            Me.ValueRectangle.Height = Convert.ToInt32((num * Me.m_ValueScaleFactor - Me.m_Minimum) / (Me.m_Maximum - Me.m_Minimum) * CDbl(Me.BarRectangle.Height - 2))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: int y = checked(checked(checked(checked(checked(this.BarRectangle.Y + 1) + this.BarRectangle.Height) - 1) - this.ValueRectangle.Height) - 1);
            Dim y As Integer = ((Me.BarRectangle.Y + 1 + Me.BarRectangle.Height) - 1 - Me.ValueRectangle.Height) - 1
            If Me.m_FillType = LinearMeterV.FillTypes.WideBand Then
                Me.ValueRectangle.Height = 12
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.ValueRectangle.Y = checked(y - 6);
                Me.ValueRectangle.Y = y - 6
            ElseIf Me.m_FillType <> LinearMeterV.FillTypes.NarrowBand Then
                Me.ValueRectangle.Y = y
            Else
                Me.ValueRectangle.Height = 4
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.ValueRectangle.Y = checked(y - 2);
                Me.ValueRectangle.Y = y - 2
            End If
            If Me.ValueRectangle.Height > 0 And Me.ValueRectangle.Width > 0 Then
                Dim mTargetValue As Double = Me.m_TargetValue
                If Me.m_ScaleTargetValue Then
                    mTargetValue = Me.m_TargetValue * Me.m_ValueScaleFactor
                End If
                If Not (Me.m_Value * Me.m_ValueScaleFactor >= mTargetValue - Me.m_ToleranceMinus And Me.m_Value * Me.m_ValueScaleFactor <= mTargetValue + Me.m_TolerancePlus) Then
                    Me.ValueBrush.Color = Color.Red
                    linearGradientBrush = New LinearGradientBrush(Me.ValueRectangle, BeveledButtonDisplay.GetRelativeColor(Me.m_FillColor, 0.5), BeveledButtonDisplay.GetRelativeColor(Me.m_FillColor, 2), 0.0F, False)
                Else
                    Me.ValueBrush.Color = Color.Green
                    linearGradientBrush = New LinearGradientBrush(Me.ValueRectangle, BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 0.5), BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 1.5), 0.0F, False)
                End If
                Dim blend As New Blend()
                Dim singleArray() As Single = {0.5F, 0.85F, 0.2F}
                blend.Factors = singleArray
                singleArray = New Single() {0.0F, 0.3F, 1.0F}
                blend.Positions = singleArray
                linearGradientBrush.Blend = blend
                graphic.FillRectangle(linearGradientBrush, Me.ValueRectangle)
            End If
            If Me.m_FillType <> LinearMeterV.FillTypes.Fill Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawLine(Pens.Black, this.ValueRectangle.X, y, checked(checked(this.ValueRectangle.X + this.ValueRectangle.Width) - 1), y);
                graphic.DrawLine(Pens.Black, Me.ValueRectangle.X, y, (Me.ValueRectangle.X + Me.ValueRectangle.Width) - 1, y)
            End If
            Me.sf.Alignment = StringAlignment.Center
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
            If Me.m_FillType <> LinearMeterV.FillTypes.Fill Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.X = checked(this.BarRectangle.X + 1);
                Me.TextRectangle.X = Me.BarRectangle.X + 1
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Y = checked(checked(this.ValueRectangle.Y - this.Font.Height) - 2);
                Me.TextRectangle.Y = (Me.ValueRectangle.Y - Me.Font.Height) - 2
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Height = checked(this.Font.Height + 2);
                Me.TextRectangle.Height = Me.Font.Height + 2
                Me.TextRectangle.Width = Me.BarRectangle.Width
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: if (this.TextRectangle.Y < this.BarRectangle.Y & this.TextRectangle.Y >= checked(this.BarRectangle.Y - 5))
                If Me.TextRectangle.Y < Me.BarRectangle.Y And Me.TextRectangle.Y >= Me.BarRectangle.Y - 5 Then
                    Me.TextRectangle.Y = Me.BarRectangle.Y
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: if (this.TextRectangle.Y < checked(this.BarRectangle.Y - 5))
                If Me.TextRectangle.Y < Me.BarRectangle.Y - 5 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: this.TextRectangle.Y = checked(checked(this.ValueRectangle.Y + this.ValueRectangle.Height) + 1);
                    Me.TextRectangle.Y = (Me.ValueRectangle.Y + Me.ValueRectangle.Height) + 1
                End If
                Me.sf.LineAlignment = StringAlignment.Center
                Me.sf.Alignment = StringAlignment.Center
                graphic.DrawString(str, Me.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            ElseIf Me.ValueRectangle.Height <= Me.Font.Height Then
                Me.sf.LineAlignment = StringAlignment.Far
                graphic.DrawString(str, Me.Font, Me.TextBrush, Me.BarRectangle, Me.sf)
            Else
                Me.sf.LineAlignment = StringAlignment.Near
                graphic.DrawString(str, Me.Font, Me.TextBrush, Me.ValueRectangle, Me.sf)
            End If
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End If
    End Sub


    Protected Overrides Sub CreateStaticImage()
        Dim rectangle As New Rectangle()
        Dim num As Integer = 0
        Dim x As Integer = 0
        Dim num1 As Integer = 0
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
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.BarRectangle = new Rectangle(checked((int)Math.Round((double)this.Width / 15 + (double)(checked(this.m_BorderWidth * 2)))), checked((int)Math.Round((double)((float)(sizeF.Height + (float)this.Font.Height + (float)(checked(this.m_BorderWidth * 2)))))), checked((int)Math.Round((double)(checked(checked(this.Width - this.MajorDivisions) - checked(this.BorderWidth * 2))) / 2.75)), checked((int)Math.Round((double)((float)(checked(this.Height - checked(this.m_BorderWidth * 4))) - sizeF.Height) - (double)this.Font.Height * 1.5)));
            Me.BarRectangle = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.Width) / 15 + CDbl(Me.m_BorderWidth * 2)))), CInt(Math.Truncate(Math.Round(CDbl(CSng(sizeF.Height + CSng(Me.Font.Height) + CSng(Me.m_BorderWidth * 2)))))), CInt(Math.Truncate(Math.Round(CDbl((Me.Width - Me.MajorDivisions) - Me.BorderWidth * 2) / 2.75))), CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.Height - Me.m_BorderWidth * 4) - sizeF.Height) - CDbl(Me.Font.Height) * 1.5))))
            graphic.FillRectangle(Brushes.LightGray, Me.BarRectangle)
            Dim num2 As Integer = Convert.ToInt32(CDbl(Me.Width) * 0.12)
            Dim num3 As Integer = Convert.ToInt32(CDbl(Me.Width) * 0.08)
            Dim pen As New Pen(Me.ForeColor, 2.0F)
            Dim pen1 As New Pen(Me.ForeColor, 1.0F)
            If Me.m_ShowValidRangeMarker Then
                Dim mTargetValue As Double = Me.m_TargetValue
                If Me.m_ScaleTargetValue Then
                    mTargetValue = Me.m_TargetValue * Me.m_ValueScaleFactor
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: int yPos = checked(this.ValueToYPos(Math.Max(mTargetValue - this.m_ToleranceMinus, this.m_Minimum)) - this.ValueToYPos(Math.Min(mTargetValue + this.m_TolerancePlus, this.m_Maximum)));
                Dim yPos As Integer = Me.ValueToYPos(Math.Max(mTargetValue - Me.m_ToleranceMinus, Me.m_Minimum)) - Me.ValueToYPos(Math.Min(mTargetValue + Me.m_TolerancePlus, Me.m_Maximum))
                If yPos > 0 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(BeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 0.7)), checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + 2), this.ValueToYPos(Math.Min(mTargetValue + this.m_TolerancePlus, this.m_Maximum)), num3, yPos);
                    graphic.FillRectangle(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 0.7)), (Me.BarRectangle.X + Me.BarRectangle.Width) + 2, Me.ValueToYPos(Math.Min(mTargetValue + Me.m_TolerancePlus, Me.m_Maximum)), num3, yPos)
                End If
            End If
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point = new Point(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + 2), this.BarRectangle.Y);
            Dim point As New Point((Me.BarRectangle.X + Me.BarRectangle.Width) + 2, Me.BarRectangle.Y)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point1 = new Point(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + num2), this.BarRectangle.Y);
            Dim point1 As New Point((Me.BarRectangle.X + Me.BarRectangle.Width) + num2, Me.BarRectangle.Y)
            graphic.DrawLine(pen, point, point1)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(checked(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + num2) + 2), checked(this.BarRectangle.Y - this.Font.Height), this.Width, checked(this.Font.Height * 2));
            Dim rectangle1 As New Rectangle((Me.BarRectangle.X + Me.BarRectangle.Width + num2) + 2, Me.BarRectangle.Y - Me.Font.Height, Me.Width, Me.Font.Height * 2)
            stringFormat.LineAlignment = StringAlignment.Center
            stringFormat.Alignment = StringAlignment.Near
            graphic.DrawString(Conversions.ToString(Me.m_Maximum), Me.Font, Me.TextBrush, rectangle1, stringFormat)
            If Me.m_MajorDivisions > 0 Then
                Do While num < Me.m_MajorDivisions
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num1 = checked((int)Math.Round((double)this.BarRectangle.Y + (double)this.BarRectangle.Height / (double)this.m_MajorDivisions * (double)(checked(num + 1)) - 1));
                    num1 = CInt(Math.Truncate(Math.Round(CDbl(Me.BarRectangle.Y) + CDbl(Me.BarRectangle.Height) / CDbl(Me.m_MajorDivisions) * CDbl(num + 1) - 1)))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: x = checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + 2);
                    x = (Me.BarRectangle.X + Me.BarRectangle.Width) + 2
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: int x1 = checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + num2);
                    Dim x1 As Integer = (Me.BarRectangle.X + Me.BarRectangle.Width) + num2
                    point1 = New Point(x, num1)
                    point = New Point(x1, num1)
                    graphic.DrawLine(pen, point1, point)
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: rectangle1 = new Rectangle(checked(x1 + 2), checked(num1 - this.Font.Height), checked(this.Width - x1), checked(this.Font.Height * 2));
                    rectangle1 = New Rectangle(x1 + 2, num1 - Me.Font.Height, Me.Width - x1, Me.Font.Height * 2)
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.DrawString(Conversions.ToString(this.m_Maximum - (double)(checked(num + 1)) * ((this.m_Maximum - this.m_Minimum) / (double)this.m_MajorDivisions)), this.Font, this.TextBrush, rectangle1, stringFormat);
                    graphic.DrawString(Conversions.ToString(Me.m_Maximum - CDbl(num + 1) * ((Me.m_Maximum - Me.m_Minimum) / CDbl(Me.m_MajorDivisions))), Me.Font, Me.TextBrush, rectangle1, stringFormat)
                    If Me.m_MinorDivisions > 1 Then
                        Dim i As Integer = 0
                        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        'ORIGINAL LINE: for (int i = 0; i < checked(this.m_MinorDivisions - 1); i += 1)
                        Do While i < Me.m_MinorDivisions - 1
                            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            'ORIGINAL LINE: int num4 = checked((int)Math.Round((double)this.BarRectangle.Y + (double)this.BarRectangle.Height / (double)(checked(this.m_MajorDivisions * this.m_MinorDivisions)) * (double)(checked(i + 1)) + (double)this.BarRectangle.Height / (double)this.m_MajorDivisions * (double)num - 1));
                            Dim num4 As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.BarRectangle.Y) + CDbl(Me.BarRectangle.Height) / CDbl(Me.m_MajorDivisions * Me.m_MinorDivisions) * CDbl(i + 1) + CDbl(Me.BarRectangle.Height) / CDbl(Me.m_MajorDivisions) * CDbl(num) - 1)))
                            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            'ORIGINAL LINE: point1 = new Point(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + 2), num4);
                            point1 = New Point((Me.BarRectangle.X + Me.BarRectangle.Width) + 2, num4)
                            point = New Point((Me.BarRectangle.X + Me.BarRectangle.Width) + num3, num4)
                            graphic.DrawLine(pen1, point1, point)
                            i += 1
                        Loop
                    End If
                    num += 1
                Loop
                graphic.DrawLine(pen1, x, Convert.ToInt32(Me.BarRectangle.Y), x, num1)
            End If
            Me.Invalidate()
        End If
    End Sub

    Private Function ValueToYPos(ByVal value As Double) As Integer
        Dim mMaximum As Double = Me.m_Maximum - Me.m_Minimum
        Dim num As Double = (value - Me.m_Minimum) / mMaximum
        Dim num1 As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.BarRectangle.Height) * num)))
        Dim y As Integer = (Me.BarRectangle.Y + Me.BarRectangle.Height) - num1
        Return y
    End Function


End Class

