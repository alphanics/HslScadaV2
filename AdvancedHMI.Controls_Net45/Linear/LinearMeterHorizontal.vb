Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class LinearMeterHorizontal
    Inherits AnalogMeterBase

    Public Sub New()
        Me.BaseImage = My.Resources.LinearMeterBase
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImage Is Nothing Or Me.BackBuffer Is Nothing Or Me.TextBrush Is Nothing) Then
            Using graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
                graphic.DrawImage(Me.StaticImage, 0, 0)
                If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                    If Me.TextBrush.Color <> MyBase.ForeColor Then
                        Me.TextBrush.Color = MyBase.ForeColor
                    End If
                    graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
                End If
                If Me.NeedleImage IsNot Nothing Then
                    graphic.DrawImage(Me.NeedleImage, Convert.ToInt32(CDbl(Me.Width) * ((Me.m_Value * Me.m_ValueScaleFactor - Me.m_Minimum) / (Me.m_Maximum - Me.m_Minimum)) * 0.9 + CDbl(Me.Width) * 0.046), Convert.ToInt32(CDbl(Me.Height) * 0.35))
                Else
                    Return
                End If
            End Using
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub CreateStaticImage()
        Dim rectangle As Rectangle
        If Not (Me.Height <= 0 Or Me.Width <= 0) Then
            Me.ImageRatio = CDbl(My.Resources.LinearMeterBase.Height) / CDbl(My.Resources.LinearMeterBase.Width)
            'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim width_Renamed As Single = CSng(CDbl(Me.Width) / CDbl(My.Resources.LinearMeterBase.Width))
            'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim height_Renamed As Single = CSng(CDbl(Me.Height) / CDbl(My.Resources.LinearMeterBase.Height))
            Me.ImageRatio = 1
            If Not (Me.ImageRatio <= 0 Or Me.Width <= 0 Or height_Renamed <= 0.0F) Then
                If Me.StaticImage IsNot Nothing Then
                    Me.StaticImage.Dispose()
                End If
                Me.StaticImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.LinearMeterBase.Width) * width_Renamed), Convert.ToInt32(CSng(My.Resources.LinearMeterBase.Height) * height_Renamed))
                Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
                graphic.DrawImage(My.Resources.LinearMeterBase, 0, 0, Me.StaticImage.Width, Me.StaticImage.Height)
                Me.sf.Alignment = StringAlignment.Center
                Me.sf.LineAlignment = StringAlignment.Center
                Me.TextRectangle.X = 0
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)this.Height * 0.04));
                Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.04)))
                Me.TextRectangle.Width = Me.Width
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.3));
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.3)))
                If Me.TextBrush Is Nothing Then
                    Me.TextBrush = New SolidBrush(MyBase.ForeColor)
                End If
                Dim solidBrush As New SolidBrush(Color.FromArgb(220, 24, 24, 24))
                Dim num As Integer = 0
                Do
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: rectangle = new Rectangle(checked((int)Math.Round((double)this.Width * 0.09 * (double)num - (double)this.Width * 0.012)), Convert.ToInt32((double)this.Height * 0.52), checked((int)Math.Round((double)this.Width * 0.12)), checked((int)Math.Round((double)this.Height * 0.2)));
                    rectangle = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.09 * CDbl(num) - CDbl(Me.Width) * 0.012))), Convert.ToInt32(CDbl(Me.Height) * 0.52), CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.12))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.2))))
                    graphic.DrawString(Conversions.ToString(Me.m_Minimum + (Me.m_Maximum - Me.m_Minimum) / 10 * CDbl(num)), New Font("Arial", CSng(Convert.ToInt32(CDbl(Me.Height) * 0.1)), FontStyle.Bold, GraphicsUnit.Point), solidBrush, rectangle, Me.sf)
                    num += 1
                Loop While num <= 9
                Me.sf.Alignment = StringAlignment.Far
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: rectangle = new Rectangle(checked((int)Math.Round((double)this.Width * 0.88)), Convert.ToInt32((double)this.Height * 0.52), checked((int)Math.Round((double)this.Width * 0.1)), checked((int)Math.Round((double)this.Height * 0.2)));
                rectangle = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.88))), Convert.ToInt32(CDbl(Me.Height) * 0.52), CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.1))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.2))))
                graphic.DrawString(Conversions.ToString(Me.m_Minimum + (Me.m_Maximum - Me.m_Minimum) / 10 * 10), New Font("Arial", CSng(Convert.ToInt32(CDbl(Me.Height) * 0.1)), FontStyle.Bold, GraphicsUnit.Point), solidBrush, rectangle, Me.sf)
                Me.sf.Alignment = StringAlignment.Center
                Dim num1 As Integer = Convert.ToInt32(CSng(My.Resources.LinearMeterNeedle.Width) * width_Renamed)
                If num1 <= 0 Then
                    num1 = 1
                End If
                Dim num2 As Integer = Convert.ToInt32(CSng(My.Resources.LinearMeterNeedle.Height) * height_Renamed)
                If num2 <= 0 Then
                    num2 = 1
                End If
                Me.NeedleImage = New Bitmap(num1, num2)
                graphic = Graphics.FromImage(Me.NeedleImage)
                graphic.DrawImage(My.Resources.LinearMeterNeedle, 0, 0, num1, num2)
                graphic.Dispose()
                If Me.BackBuffer IsNot Nothing Then
                    Me.BackBuffer.Dispose()
                End If
                Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
                Me.Invalidate()
            End If
        End If
    End Sub
End Class

