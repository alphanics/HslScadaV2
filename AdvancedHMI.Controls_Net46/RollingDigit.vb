Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms

Public Class RollingDigit
    Implements IDisposable
    Private bitmap_0 As Bitmap()

    Private bool_0 As Boolean

    Private double_0 As Double

    Private font_0 As System.Drawing.Font

    Private color_0 As Color

    Private color_1 As Color

    Private int_0 As Integer

    Private int_1 As Integer

    Public Property BackColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (value <> Me.color_0) Then
                Me.color_0 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property Font As System.Drawing.Font
        Get
            Return Me.font_0
        End Get
        Set(ByVal value As System.Drawing.Font)
            Me.font_0.Dispose()
            Me.font_0 = DirectCast(value.Clone(), System.Drawing.Font)
            Me.method_0()
        End Set
    End Property

    Public Property ForeColor As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            If (value <> Me.color_1) Then
                Me.color_1 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property Height As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.int_1) Then
                Me.int_1 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property Value As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            If (value <> Me.double_0) Then
                Me.double_0 = Math.Max(value, 0)
                Me.double_0 = Math.Min(Me.double_0, 9.999999999)
            End If
        End Set
    End Property

    Public Property Width As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.int_0) Then
                Me.int_0 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        ReDim Me.bitmap_0(9)
        Me.font_0 = New System.Drawing.Font("Arial", 8!)
        Me.color_0 = Color.White
        Me.color_1 = Color.Black
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If (Not Me.bool_0 AndAlso disposing) Then
            Dim length As Integer = CInt(Me.bitmap_0.Length) - 1
            Dim num As Integer = 0
            Do
                If (Me.bitmap_0(num) IsNot Nothing) Then
                    Me.bitmap_0(num).Dispose()
                End If
                num = num + 1
            Loop While num <= length
            If (Me.font_0 IsNot Nothing) Then
                Me.font_0.Dispose()
            End If
        End If
        Me.bool_0 = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Sub Draw(ByVal graphics_0 As Graphics, ByVal offsetX As Integer, ByVal offsetY As Integer)
        If (Me.Width > 0 And Me.Height > 0) Then
            Using solidBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.color_0)
                graphics_0.FillRectangle(solidBrush, offsetX, offsetY, Me.Width, Me.Height)
            End Using
            Dim num As Integer = CInt(Math.Floor(Me.double_0))
            Dim double0 As Double = Me.double_0 - CDbl(num)
            Dim num1 As Integer = Convert.ToInt32(CDbl(Me.int_1) * double0)
            If (Me.bitmap_0(num) Is Nothing) Then
                Me.method_0()
            End If
            Dim height As Double = CDbl(Me.Height)
            If (double0 > 0) Then
                height = (1 - double0 * 0.5) * CDbl(Me.Height)
            End If
            graphics_0.DrawImage(Me.bitmap_0(num), offsetX, CInt(Math.Round(CDbl((0 - num1)) + (CDbl(Me.Height) - height))), Me.Width, CInt(Math.Round(height)))
            If (num1 > 0) Then
                Dim num2 As Integer = num + 1
                If (num2 >= 10) Then
                    num2 = 0
                End If
                If (double0 > 0) Then
                    height = Math.Min(CDbl(Me.Height), double0 * 1.75 * CDbl(Me.Height))
                End If
                graphics_0.DrawImage(Me.bitmap_0(num2), offsetX, 0 + Me.int_1 - num1, Me.Width, CInt(Math.Round(height)))
            End If
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.FromArgb(255, 8, 8, 8))
                Using pen As System.Drawing.Pen = New System.Drawing.Pen(solidBrush1, 3!)
                    graphics_0.DrawLine(pen, offsetX, offsetY + 2, Me.int_0, offsetY + 2)
                End Using
            End Using
            Using linearGradientBrush As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Rectangle(0, 0, Me.int_1, Me.int_0), Color.Black, Color.Black, 0!, False)
                Dim colorBlend As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend() With
                {
                    .Positions = New Single() {0!, 0.18!, 0.45!, 0.85!, 1!},
                    .Colors = New Color() {Color.FromArgb(255, 0, 0, 0), Color.FromArgb(64, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(96, 0, 0, 0), Color.FromArgb(255, 0, 0, 0)}
                }
                linearGradientBrush.RotateTransform(90!)
                linearGradientBrush.InterpolationColors = colorBlend
                graphics_0.FillRectangle(linearGradientBrush, offsetX, offsetY, Me.Width, Me.Height)
            End Using
        End If
    End Sub

    Public Shared Function GetRelativeColor(ByVal color As System.Drawing.Color, ByVal intensity As Double, ByVal alpha As Integer) As System.Drawing.Color
        intensity = Math.Max(intensity, 0)
        Dim color1 As System.Drawing.Color = System.Drawing.Color.FromArgb(alpha, Convert.ToInt32(Math.Min(CDbl((color.R + 1)) * intensity, 255)), Convert.ToInt32(Math.Min(CDbl((color.G + 1)) * intensity, 255)), Convert.ToInt32(Math.Min(CDbl((color.B + 1)) * intensity, 255)))
        Return color1
    End Function

    Private Sub method_0()
        If (Me.int_0 > 0 And Me.int_1 > 0) Then
            Dim font As System.Drawing.Font = New System.Drawing.Font(Me.font_0.FontFamily, 1!, FontStyle.Regular, GraphicsUnit.Pixel)
            Dim sizeF As System.Drawing.SizeF = New System.Drawing.SizeF()
            If (sizeF.Width < CSng(Me.int_0) And sizeF.Height < CSng(Me.int_1)) Then
                Do
                    sizeF = TextRenderer.MeasureText("0", font)
                    font.Dispose()
                    font = New System.Drawing.Font(Me.font_0.FontFamily, font.Size + 1!, FontStyle.Regular, GraphicsUnit.Pixel)
                Loop While Not (sizeF.Width >= CSng(Me.int_0) Or sizeF.Height >= CSng(Me.int_1))
            End If
            Using stringFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat()
                Using solidBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.color_1)
                    stringFormat.Alignment = StringAlignment.Center
                    stringFormat.LineAlignment = StringAlignment.Center
                    Dim num As Integer = 0
                    Do
                        If (Me.bitmap_0(num) IsNot Nothing) Then
                            Me.bitmap_0(num).Dispose()
                        End If
                        Me.bitmap_0(num) = New Bitmap(Me.int_0, Me.int_1)
                        Using graphic As Graphics = Graphics.FromImage(Me.bitmap_0(num))
                            graphic.SmoothingMode = SmoothingMode.AntiAlias
                            graphic.TextRenderingHint = TextRenderingHint.AntiAlias
                            graphic.DrawString(Conversions.ToString(num), font, solidBrush, CSng(Convert.ToInt32(CDbl(Me.bitmap_0(num).Width) / 2)), CSng(Convert.ToInt32(CDbl(Me.bitmap_0(num).Height) * 0.575)), stringFormat)
                            graphic.DrawLine(New Pen(New System.Drawing.SolidBrush(Color.FromArgb(255, 32, 32, 32)), 3!), 0, 0, 0, Me.int_1)
                        End Using
                        num = num + 1
                    Loop While num <= 9
                End Using
            End Using
        End If
    End Sub
End Class
