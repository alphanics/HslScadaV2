Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Thermometer2
    Inherits Control



    Private StaticImage As Bitmap

    Private BackBuffer As Bitmap

    Private BulbImage As Bitmap

    Private ValueRectangle As Rectangle

    Private BulbCircle As Rectangle

    Private m_Minimum As Double

    Private m_Value As Double

    Private m_ValueUnits As Thermometer2.UnitsSelect

    Private m_FillColor As Color

    Private m_ColumnColor As Thermometer2.ColumnColors

    Public Property ColumnColor() As Thermometer2.ColumnColors
        Get
            Return Me.m_ColumnColor
        End Get
        Set(ByVal value As Thermometer2.ColumnColors)
            If Me.m_ColumnColor <> value Then
                Me.m_ColumnColor = value
                Me.RefreshImage()
            End If
        End Set
    End Property

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

    Public Property ValueUnits() As Thermometer2.UnitsSelect
        Get
            Return Me.m_ValueUnits
        End Get
        Set(ByVal value As Thermometer2.UnitsSelect)
            If Me.m_ValueUnits <> value Then
                Me.m_ValueUnits = value
                Me.UpdateValueRectangle()
            End If
        End Set
    End Property


    Public Sub New()

        Me.m_Minimum = -40
        Me.m_FillColor = Color.Red
        Me.m_ColumnColor = Thermometer2.ColumnColors.Red
        Me.ValueRectangle = New Rectangle(0, 0, 10, 10)
        Me.ForeColor = Color.Black
        Me.Height = 240
        Me.Width = 75
    End Sub



    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            If Me.BackBuffer IsNot Nothing Then
                Me.BackBuffer.Dispose()
            End If
            If Me.BulbImage IsNot Nothing Then
                Me.BulbImage.Dispose()
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
        If Me.BackBuffer IsNot Nothing Or Me.StaticImage IsNot Nothing Or Me.BulbImage IsNot Nothing Then
            Using graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
                graphic.DrawImage(Me.StaticImage, 0, 0)
                Select Case Me.m_ColumnColor
                    Case Thermometer2.ColumnColors.Red
                        graphic.DrawImage(My.Resources.Thermometer2Column, Me.ValueRectangle)
                        Exit Select
                    Case Thermometer2.ColumnColors.Green
                        graphic.DrawImage(My.Resources.Thermometer2ColumnGrn, Me.ValueRectangle)
                        Exit Select
                    Case Thermometer2.ColumnColors.Blue
                        graphic.DrawImage(My.Resources.Thermometer2ColumnBlue, Me.ValueRectangle)
                        Exit Select
                End Select
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawImage(this.BulbImage, checked((int)Math.Round((double)this.Width * 0.335)), checked((int)Math.Round((double)this.Height * 0.822)));
                graphic.DrawImage(Me.BulbImage, CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.335))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.822))))
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
                graphic.DrawImage(My.Resources.Thermometer2Static, 0, 0, Me.StaticImage.Width, Me.StaticImage.Height)
                Dim stringFormat As New StringFormat() With {
                 .LineAlignment = StringAlignment.Center,
                 .Alignment = StringAlignment.Far
                }
                Dim num As Double = 20
                Dim rectangle(8) As Rectangle
                Dim num1 As Integer = 0
                Do
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: rectangle[num1] = new Rectangle(0, checked((int)Math.Round((double)this.StaticImage.Height * (0.775 - (double)num1 * 0.08))), checked((int)Math.Round((double)this.StaticImage.Width * 0.24)), checked((int)Math.Round((double)this.StaticImage.Height * 0.05)));
                    rectangle(num1) = New Rectangle(0, CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * (0.775 - CDbl(num1) * 0.08)))), CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Width) * 0.24))), CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * 0.05))))
                    graphic.DrawString(Convert.ToString(Me.m_Minimum + num * CDbl(num1)), New Font(Me.Font.FontFamily, CSng(CDbl(Me.Height) * 0.025), FontStyle.Regular, GraphicsUnit.Point), New SolidBrush(Me.ForeColor), rectangle(num1), stringFormat)
                    num1 += 1
                Loop While num1 <= 8
                num = 10
                stringFormat.Alignment = StringAlignment.Near
                Dim mMinimum As Double = (Me.m_Minimum - 32) * 5 / 9
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: int num2 = checked((int)Math.Round((double)this.Width * 0.77));
                Dim num2 As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.77)))
                Dim num3 As Integer = 0
                Do
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: rectangle[0] = new Rectangle(num2, checked((int)Math.Round((double)this.StaticImage.Height * (0.762 - (double)num3 * 0.071))), checked(this.Width - num2), checked((int)Math.Round((double)this.StaticImage.Height * 0.05)));
                    rectangle(0) = New Rectangle(num2, CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * (0.762 - CDbl(num3) * 0.071)))), Me.Width - num2, CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * 0.05))))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.DrawString(Convert.ToString(checked((int)Math.Round(mMinimum + num * (double)num3))), new Font(this.Font.FontFamily, (float)((double)this.Height * 0.025), FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(this.ForeColor), rectangle[0], stringFormat);
                    graphic.DrawString(Convert.ToString(CInt(Math.Truncate(Math.Round(mMinimum + num * CDbl(num3))))), New Font(Me.Font.FontFamily, CSng(CDbl(Me.Height) * 0.025), FontStyle.Regular, GraphicsUnit.Point), New SolidBrush(Me.ForeColor), rectangle(0), stringFormat)
                    num3 += 1
                Loop While num3 <= 9
                stringFormat.LineAlignment = StringAlignment.Near
                stringFormat.Alignment = StringAlignment.Center
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(0, checked((int)Math.Round((double)this.StaticImage.Height * 0.01)), this.StaticImage.Width, this.StaticImage.Height);
                Dim rectangle1 As New Rectangle(0, CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImage.Height) * 0.01))), Me.StaticImage.Width, Me.StaticImage.Height)
                graphic.DrawString(MyBase.Text, Me.Font, New SolidBrush(Me.ForeColor), rectangle1, stringFormat)
            End Using
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.BulbImage = new Bitmap(checked((int)Math.Round((double)this.Width * 0.366)), checked((int)Math.Round((double)this.Height * 0.125)));
            Me.BulbImage = New Bitmap(CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.366))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.125))))
            Using graphic1 As Graphics = Graphics.FromImage(Me.BulbImage)
                Select Case Me.m_ColumnColor
                    Case Thermometer2.ColumnColors.Red
                        graphic1.DrawImage(My.Resources.Thermometer2Bulb, 0, 0, Me.BulbImage.Width, Me.BulbImage.Height)
                        Exit Select
                    Case Thermometer2.ColumnColors.Green
                        graphic1.DrawImage(My.Resources.Thermometer2BulbGrn, 0, 0, Me.BulbImage.Width, Me.BulbImage.Height)
                        Exit Select
                    Case Thermometer2.ColumnColors.Blue
                        graphic1.DrawImage(My.Resources.Thermometer2BulbBlue, 0, 0, Me.BulbImage.Width, Me.BulbImage.Height)
                        Exit Select
                End Select
            End Using
            Me.UpdateValueRectangle()
            Me.Invalidate()
        End If
    End Sub

    Private Sub UpdateValueRectangle()
        Dim mMinimum As Double
        Dim num As Double = Math.Max(Me.m_Value, Me.m_Minimum - 5)
        If Me.m_ValueUnits <> Thermometer2.UnitsSelect.F Then
            num = Math.Min(num, Me.m_Minimum + 92)
            mMinimum = (num * 1.8 + 32 - Me.m_Minimum) / 160
        Else
            num = Math.Min(num, Me.m_Minimum + 165)
            mMinimum = (num - Me.m_Minimum) / 160
        End If
        'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim height_Renamed As Double = CDbl(Me.Height) * 0.85
        Dim height1 As Double = CDbl(Me.Height) * 0.645 * mMinimum + CDbl(Me.Height) * 0.05
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.ValueRectangle.Height = checked((int)Math.Round(height1));
        Me.ValueRectangle.Height = CInt(Math.Truncate(Math.Round(height1)))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.ValueRectangle.Width = checked((int)Math.Round((double)this.Width * 0.08));
        Me.ValueRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.08)))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.ValueRectangle.X = checked((int)Math.Round((double)this.Width * 0.47));
        Me.ValueRectangle.X = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.47)))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.ValueRectangle.Y = checked((int)Math.Round(height - height1));
        Me.ValueRectangle.Y = CInt(Math.Truncate(Math.Round(height_Renamed - height1)))
        Me.Invalidate()
    End Sub

    Public Event ValueChanged As EventHandler

    Public Enum ColumnColors
        Red
        Green
        Blue
    End Enum

    Public Enum UnitsSelect
        F
        C
    End Enum
End Class

