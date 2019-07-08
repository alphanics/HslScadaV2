Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms

Public Class LinearMeterV
    Inherits LinearMeterBase
    Private rectangle_0 As Rectangle

    Private blend_0 As Blend

    Public Sub New()
        MyBase.New()
        Me.blend_0 = New Blend()
        MyBase.BackColor = Color.FromArgb(255, 255, 255)
        MyBase.ForeColor = Color.Black
        Me.rectangle_0 = New Rectangle()
        Me.blend_0.Factors = New Single() {0.5!, 0.85!, 0.2!}
        Me.blend_0.Positions = New Single() {Nothing, 0.3!, 1!}
    End Sub

    Protected Overrides Sub CreateStaticImage()
        Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle()
        Dim num As Integer = 0
        Dim num1 As Integer = 0
        Dim x As Integer = 0
        If (MyBase.Width > 0 Or MyBase.Height > 0) Then
            Try
                If (Me.StaticImage IsNot Nothing AndAlso Me.StaticImage.Width <> MyBase.Width Or Me.StaticImage.Height <> MyBase.Height) Then
                    Me.StaticImage.Dispose()
                    Me.StaticImage = Nothing
                End If
                If (Me.StaticImage Is Nothing) Then
                    Me.StaticImage = New Bitmap(MyBase.Width, MyBase.Height)
                End If
                If (Me.m_CenterTargetValue) Then
                    Dim mTolerancePlus As Double = Me.m_TolerancePlus * 4
                    If (Me.m_ToleranceMinus > Me.m_TolerancePlus) Then
                        mTolerancePlus = Me.m_ToleranceMinus * 4
                    End If
                    Me.m_Maximum = Me.m_TargetValue + mTolerancePlus
                    Me.m_Minimum = Me.m_TargetValue - mTolerancePlus
                    If (Me.m_Maximum = Me.m_Minimum) Then
                        Me.m_Maximum += Me.m_Minimum
                    End If
                End If
                Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
                If (Not ((Me.BackColor = Color.Transparent) And Me.BackgroundImage IsNot Nothing)) Then
                    graphic.TextRenderingHint = TextRenderingHint.AntiAlias
                Else
                    graphic.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                End If
                graphic.Clear(Me.BackColor)
                If (Me.m_BorderWidth > 0) Then
                    BeveledButtonDisplay.Draw3DBorder(Me, graphic, Me.m_BorderColor, Me.m_BorderWidth)
                End If
                Dim stringFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat()
                If (Not String.IsNullOrEmpty(Me.Text)) Then
                    rectangle = New System.Drawing.Rectangle(Me.m_BorderWidth * 2, Me.m_BorderWidth * 2 + 1, MyBase.Width - Me.m_BorderWidth * 4 - 1, MyBase.Height - Me.m_BorderWidth * 4 - 2)
                    stringFormat.Alignment = StringAlignment.Center
                    stringFormat.LineAlignment = StringAlignment.Near
                    graphic.DrawString(Me.Text, Me.Font, Me.TextBrush, rectangle, stringFormat)
                End If
                Dim sizeF As System.Drawing.SizeF = graphic.MeasureString(Me.Text, Me.Font, rectangle.Width)
                If (Me.m_BorderWidth > 0 And Not String.IsNullOrEmpty(Me.Text)) Then
                    Dim r As Byte = Me.ForeColor.R
                    Dim g As Byte = Me.ForeColor.G
                    Dim foreColor As Color = Me.ForeColor
                    graphic.DrawLine(New System.Drawing.Pen(Color.FromArgb(80, CInt(r), CInt(g), CInt(foreColor.B)), 2!), CSng((Me.m_BorderWidth * 2)), sizeF.Height + CSng((Me.m_BorderWidth * 2)) + 2!, CSng((MyBase.Width - Me.m_BorderWidth * 2)), sizeF.Height + CSng((Me.m_BorderWidth * 2)) + 2!)
                End If
                Dim num2 As Integer = Convert.ToInt32(CDbl(MyBase.Width) * 0.12)
                Dim num3 As Integer = Convert.ToInt32(CDbl(MyBase.Width) * 0.08)
                Dim pen As System.Drawing.Pen = New System.Drawing.Pen(Me.ForeColor, 2!)
                Dim pen1 As System.Drawing.Pen = New System.Drawing.Pen(Me.ForeColor, 1!)
                Dim sizeF1 As System.Drawing.SizeF = graphic.MeasureString(Conversions.ToString(Me.m_Maximum), Me.Font, rectangle.Width)
                Dim sizeF2 As System.Drawing.SizeF = graphic.MeasureString(Conversions.ToString(Me.m_Minimum), Me.Font, rectangle.Width)
                Dim num4 As Integer = CInt(Math.Ceiling(CDbl(Math.Max(sizeF1.Width, sizeF2.Width))))
                Dim mBorderWidth As Integer = Me.m_BorderWidth * 2 + 2
                Me.BarRectangle = New System.Drawing.Rectangle(mBorderWidth, CInt(Math.Round(CDbl(sizeF.Height) + Math.Ceiling(CDbl((sizeF1.Height / 2!))) + CDbl((Me.m_BorderWidth * 2)))), MyBase.Width - num2 - num4 - mBorderWidth - MyBase.BorderWidth * 2 - 4, CInt(Math.Round(CDbl((CSng((MyBase.Height - Me.m_BorderWidth * 4)) - sizeF.Height)) - Math.Ceiling(CDbl(sizeF1.Height)))))
                graphic.FillRectangle(New SolidBrush(Me.m_FillAreaBackcolor), Me.BarRectangle)
                If (Me.m_ShowValidRangeMarker) Then
                    Dim mTargetValue As Double = Me.m_TargetValue
                    If (Me.m_ScaleTargetValue) Then
                        mTargetValue = Me.m_TargetValue * Me.m_ValueScaleFactor
                    End If
                    Dim num5 As Integer = Me.method_2(Math.Max(mTargetValue - Me.m_ToleranceMinus, Me.m_Minimum)) - Me.method_2(Math.Min(mTargetValue + Me.m_TolerancePlus, Me.m_Maximum))
                    If (num5 > 0) Then
                        graphic.FillRectangle(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 0.7)), Me.BarRectangle.X + Me.BarRectangle.Width + 2, Me.method_2(Math.Min(mTargetValue + Me.m_TolerancePlus, Me.m_Maximum)), num3, num5)
                    End If
                End If
                graphic.DrawLine(pen, New Point(Me.BarRectangle.X + Me.BarRectangle.Width + 2, Me.BarRectangle.Y), New Point(Me.BarRectangle.X + Me.BarRectangle.Width + num2, Me.BarRectangle.Y))
                Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(Me.BarRectangle.X + Me.BarRectangle.Width + num2 + 2, Me.BarRectangle.Y - Me.Font.Height, MyBase.Width, Me.Font.Height * 2)
                stringFormat.LineAlignment = StringAlignment.Center
                stringFormat.Alignment = StringAlignment.Near
                graphic.DrawString(Conversions.ToString(Me.m_Maximum), Me.Font, Me.TextBrush, rectangle1, stringFormat)
                If (Me.m_MajorDivisions > 0) Then
                    While num < Me.m_MajorDivisions
                        num1 = CInt(Math.Round(CDbl(Me.BarRectangle.Y) + CDbl(Me.BarRectangle.Height) / CDbl(Me.m_MajorDivisions) * CDbl((num + 1)) - 1))
                        x = Me.BarRectangle.X + Me.BarRectangle.Width + 2
                        Dim x1 As Integer = Me.BarRectangle.X + Me.BarRectangle.Width + num2
                        graphic.DrawLine(pen, New Point(x, num1), New Point(x1, num1))
                        rectangle1 = New System.Drawing.Rectangle(x1 + 2, num1 - Me.Font.Height, MyBase.Width - x1, Me.Font.Height * 2)
                        graphic.DrawString(Conversions.ToString(Me.m_Maximum - CDbl((num + 1)) * ((Me.m_Maximum - Me.m_Minimum) / CDbl(Me.m_MajorDivisions))), Me.Font, Me.TextBrush, rectangle1, stringFormat)
                        If (Me.m_MinorDivisions > 1) Then
                            Dim num6 As Integer = 0
                            While num6 < Me.m_MinorDivisions - 1
                                Dim num7 As Integer = CInt(Math.Round(CDbl(Me.BarRectangle.Y) + CDbl(Me.BarRectangle.Height) / CDbl((Me.m_MajorDivisions * Me.m_MinorDivisions)) * CDbl((num6 + 1)) + CDbl(Me.BarRectangle.Height) / CDbl(Me.m_MajorDivisions) * CDbl(num) - 1))
                                graphic.DrawLine(pen1, New Point(Me.BarRectangle.X + Me.BarRectangle.Width + 2, num7), New Point(Me.BarRectangle.X + Me.BarRectangle.Width + num3, num7))
                                num6 = num6 + 1
                            End While
                        End If
                        num = num + 1
                    End While
                    graphic.DrawLine(pen1, x, Convert.ToInt32(Me.BarRectangle.Y), x, num1)
                End If
                MyBase.Invalidate()
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                ProjectData.ClearProjectError()
            End Try
        End If
    End Sub

    Private Function method_2(ByVal double_0 As Double) As Integer
        Dim mMaximum As Double = Me.m_Maximum - Me.m_Minimum
        Dim double0 As Double = (double_0 - Me.m_Minimum) / mMaximum
        Dim num As Integer = CInt(Math.Round(CDbl(Me.BarRectangle.Height) * double0))
        Dim y As Integer = Me.BarRectangle.Y + Me.BarRectangle.Height - num
        Return y
    End Function

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim blend0 As LinearGradientBrush
        Dim str As String
        MyBase.OnPaint(painte)
        Dim graphics As System.Drawing.Graphics = painte.Graphics
        graphics.SmoothingMode = SmoothingMode.None
        Dim num As Double = Math.Max(Math.Min(Me.Value, Me.m_Maximum / Me.m_ValueScaleFactor), Me.m_Minimum / Me.m_ValueScaleFactor)
        Me.rectangle_0.Width = Me.BarRectangle.Width - 2
        Me.rectangle_0.X = Me.BarRectangle.X + 1
        Me.rectangle_0.Height = Convert.ToInt32((num * Me.m_ValueScaleFactor - Me.m_Minimum) / (Me.m_Maximum - Me.m_Minimum) * CDbl((Me.BarRectangle.Height - 2)))
        Dim y As Integer = Me.BarRectangle.Y + 1 + Me.BarRectangle.Height - 1 - Me.rectangle_0.Height - 1
        If (Me.m_FillType = AdvancedHMI.Controls_Net46.LinearMeterBase.FillTypeOption.WideBand) Then
            Me.rectangle_0.Height = Math.Max(2, CInt(Math.Round(CDbl(MyBase.Height) * 0.03)) * 2)
            Me.rectangle_0.Y = CInt(Math.Round(CDbl(y) - CDbl(Me.rectangle_0.Height) / 2))
        ElseIf (Me.m_FillType <> FillTypeOption.NarrowBand) Then
            Me.rectangle_0.Y = y
        Else
            Me.rectangle_0.Height = 4
            Me.rectangle_0.Y = y - 2
        End If
        If (Me.rectangle_0.Height > 0 And Me.rectangle_0.Width > 0) Then
            Dim mTargetValue As Double = Me.m_TargetValue
            If (Me.m_ScaleTargetValue) Then
                mTargetValue = Me.m_TargetValue * Me.m_ValueScaleFactor
            End If
            blend0 = If(Not (Me.m_Value * Me.m_ValueScaleFactor >= mTargetValue - Me.m_ToleranceMinus And Me.m_Value * Me.m_ValueScaleFactor <= mTargetValue + Me.m_TolerancePlus), New LinearGradientBrush(Me.rectangle_0, BeveledButtonDisplay.GetRelativeColor(Me.m_FillColor, 0.5), BeveledButtonDisplay.GetRelativeColor(Me.m_FillColor, 2), 0!, False), New LinearGradientBrush(Me.rectangle_0, BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 0.5), BeveledButtonDisplay.GetRelativeColor(Me.m_FillColorInRange, 1.5), 0!, False))
            blend0.Blend = Me.blend_0
            graphics.FillRectangle(blend0, Me.rectangle_0)
        End If
        If (Me.m_FillType <> FillTypeOption.Fill) Then
            graphics.DrawLine(New Pen(Color.Black, 2!), Me.rectangle_0.X, y, Me.rectangle_0.X + Me.rectangle_0.Width - 1, y)
        End If
        If (Me.m_ShowValue) Then
            Me.stringFormat_0.Alignment = StringAlignment.Center
            If (String.IsNullOrEmpty(Me.m_NumericFormat)) Then
                str = Conversions.ToString(Me.m_Value)
            Else
                Try
                    str = Me.m_Value.ToString(Me.m_NumericFormat)
                Catch exception As System.Exception
                    ProjectData.SetProjectError(exception)
                    str = "NumericFormat Invalid"
                    ProjectData.ClearProjectError()
                End Try
            End If
            If (Me.m_FillType <> FillTypeOption.Fill) Then
                Me.TextRectangle.X = Me.BarRectangle.X + 1
                Me.TextRectangle.Y = Me.rectangle_0.Y - Me.Font.Height - 2
                Me.TextRectangle.Height = Me.Font.Height + 2
                Me.TextRectangle.Width = Me.BarRectangle.Width
                If (Me.TextRectangle.Y < Me.BarRectangle.Y And Me.TextRectangle.Y >= Me.BarRectangle.Y - 5) Then
                    Me.TextRectangle.Y = Me.BarRectangle.Y
                End If
                If (Me.TextRectangle.Y < Me.BarRectangle.Y - 5) Then
                    Me.TextRectangle.Y = Me.rectangle_0.Y + Me.rectangle_0.Height + 1
                End If
                Me.stringFormat_0.LineAlignment = StringAlignment.Center
                Me.stringFormat_0.Alignment = StringAlignment.Center
                graphics.DrawString(str, Me.Font, Me.TextBrush, Me.TextRectangle, Me.stringFormat_0)
            ElseIf (Me.rectangle_0.Height <= Me.Font.Height) Then
                Me.stringFormat_0.LineAlignment = StringAlignment.Far
                graphics.DrawString(str, Me.Font, Me.TextBrush, Me.BarRectangle, Me.stringFormat_0)
            Else
                Me.stringFormat_0.LineAlignment = StringAlignment.Near
                graphics.DrawString(str, Me.Font, Me.TextBrush, Me.rectangle_0, Me.stringFormat_0)
            End If
        End If
    End Sub
End Class
