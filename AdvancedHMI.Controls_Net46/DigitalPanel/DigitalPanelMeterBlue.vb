Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<DefaultEvent("")>
Public Class DigitalPanelMeterBlue
    Inherits AnalogMeterBase
    Private bitmap_0 As Bitmap()

    Private bitmap_1 As Bitmap

    Private Const int_2 As Integer = 198

    Private Const int_3 As Integer = 280

    Private decimal_0 As Decimal

    Private int_4 As Integer

    Private colorSelect_0 As DigitalPanelMeterBlue.ColorSelect

    Private color_0 As Color

    Private int_5 As Integer

    Private int_6 As Integer

    Public Property BacklightColor As DigitalPanelMeterBlue.ColorSelect
        Get
            Return Me.colorSelect_0
        End Get
        Set(ByVal value As DigitalPanelMeterBlue.ColorSelect)
            If (Me.colorSelect_0 <> value) Then
                Me.colorSelect_0 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property DecimalPosition As Integer
        Get
            Return Me.int_4
        End Get
        Set(ByVal value As Integer)
            Me.int_4 = Math.Max(Math.Min(99, value), 0)
            MyBase.Invalidate()
        End Set
    End Property

    Public Property LEDColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (Me.color_0 <> value) Then
                Me.color_0 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property Resolution As Decimal
        Get
            Return Me.decimal_0
        End Get
        Set(ByVal value As Decimal)
            If (Decimal.Compare(value, Decimal.Zero) <> 0) Then
                Me.decimal_0 = value
                If (Me.StaticImage IsNot Nothing) Then
                    MyBase.Invalidate()
                End If
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        ReDim Me.bitmap_0(11)
        Me.decimal_0 = Decimal.One
        Me.int_4 = 0
        Me.colorSelect_0 = DigitalPanelMeterBlue.ColorSelect.Blue
        Me.color_0 = Color.FromArgb(255, 48, 48, 104)
        Me.ForeColor = Color.Black
        Me.BackColor = Color.FromArgb(255, 106, 140, 255)
        MyBase.Maximum = 0
        MyBase.Minimum = 0
        MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub CreateStaticImage()
        If (MyBase.Width > 0 And MyBase.Height > 0) Then
            If (Me.StaticImage IsNot Nothing) Then
                Me.StaticImage.Dispose()
            End If
            Me.StaticImage = New Bitmap(MyBase.Width, MyBase.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
            graphic.DrawImage(My.Resources.ClearBackgroundFrame, 0, 0, Me.StaticImage.Width, Me.StaticImage.Height)
            Me.TextRectangle.X = 0
            Me.TextRectangle.Y = CInt(Math.Round(CDbl(MyBase.Height) * 0.02))
            Me.TextRectangle.Width = MyBase.Width
            Me.TextRectangle.Height = CInt(Math.Round(CDbl(MyBase.Height) * 0.17))
            If (Me.TextBrush Is Nothing) Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            Me.ImageRatio = CDbl(MyBase.Height) / CDbl(My.Resources.ClearBackgroundFrame.Height)
            Dim num As Integer = Convert.ToInt32(198 * Me.ImageRatio)
            Dim num1 As Integer = Convert.ToInt32(280 * Me.ImageRatio)
            Dim num2 As Integer = 0
            Do
                If (Me.bitmap_0(num2) IsNot Nothing) Then
                    Me.bitmap_0(num2).Dispose()
                End If
                Me.bitmap_0(num2) = New Bitmap(num, num1)
                graphic = Graphics.FromImage(Me.bitmap_0(num2))
                graphic.ScaleTransform(CSng((0.27 * Me.ImageRatio)), CSng((0.27 * Me.ImageRatio)))
                SevenSegment2.smethod_7(graphic, num2, Me.color_0, True)
                num2 = num2 + 1
            Loop While num2 <= 11
            Me.bitmap_1 = New Bitmap(Convert.ToInt32(CDbl(My.Resources.BlueSevenSegmentDot.Width) * Me.ImageRatio * 1.3), Convert.ToInt32(CDbl(My.Resources.BlueSevenSegmentDot.Height) * Me.ImageRatio * 1.3))
            graphic = Graphics.FromImage(Me.bitmap_1)
            graphic.DrawImage(My.Resources.BlueSevenSegmentDot, 0, 0, Me.bitmap_1.Width, Me.bitmap_1.Height)
            graphic.Dispose()
            MyBase.Invalidate()
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                If (Me.bitmap_1 IsNot Nothing) Then
                    Me.bitmap_1.Dispose()
                End If
                Dim length As Integer = CInt(Me.bitmap_0.Length) - 1
                For i As Integer = 0 To length Step 1
                    If (Me.bitmap_0(i) IsNot Nothing) Then
                        Me.bitmap_0(i).Dispose()
                    End If
                Next

            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim flag As Boolean = False
        If (Me.StaticImage IsNot Nothing) Then
            Dim graphics As System.Drawing.Graphics = painte.Graphics
            graphics.DrawImage(Me.StaticImage, 0, 0)
            If (Not String.IsNullOrEmpty(MyBase.Text)) Then
                If (Me.TextBrush Is Nothing) Then
                    Me.TextBrush = New SolidBrush(MyBase.ForeColor)
                ElseIf (Me.TextBrush.Color <> MyBase.ForeColor) Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphics.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.stringFormat_0)
            End If
            Dim one As Decimal = Decimal.Divide(Decimal.One, Me.decimal_0)
            If (Decimal.Compare(one, Decimal.Zero) = 0) Then
                one = Decimal.One
            End If
            Dim num As Long = Convert.ToInt64(Decimal.Divide(New Decimal(CLng(Math.Round(Me.m_Value * Convert.ToDouble(one) * Me.m_ValueScaleFactor))), one))
            Dim num1 As Integer = Convert.ToInt32(0.24 * CDbl(MyBase.Height))
            Dim num2 As Integer = Convert.ToInt32(CDbl(Me.bitmap_0(0).Width) * 1.15)
            Dim width As Single = CSng((CDbl(My.Resources.ClearBackgroundFrame.Width) * 1 / CDbl(My.Resources.ClearBackgroundFrame.Height) / (CDbl(Me.StaticImage.Width) * 1 / CDbl(Me.StaticImage.Height))))
            Dim num3 As Integer = Convert.ToInt32(CDbl(MyBase.Width) * 0.8 / (CDbl(Me.bitmap_0(0).Width) * 1.15))
            If (Not (CDbl(num) <= Math.Pow(10, CDbl(num3)) - 1 And CDbl(num) >= (Math.Pow(10, CDbl((num3 - 1))) - 1) * -1)) Then
                Dim num4 As Integer = num3
                For i As Integer = 1 To num4 Step 1
                    graphics.DrawImage(Me.bitmap_0(11), Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.1) + num2 * (i - 1), num1)
                Next

            Else
                Dim num5 As Integer = num3
                For j As Integer = 1 To num5 Step 1
                    If (num >= 0L) Then
                        Dim num6 As Integer = Convert.ToInt32(Math.Floor(CDbl(num) / Math.Pow(10, CDbl((num3 - j)))))
                        If (num6 > 0 Or j = num3 Or j > num3 - Me.int_4) Then
                            flag = True
                        End If
                        If (Not flag) Then
                            graphics.DrawImage(Me.bitmap_0(10), Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.1) + num2 * (j - 1), num1)
                        Else
                            graphics.DrawImage(Me.bitmap_0(num6), Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.1) + num2 * (j - 1), num1)
                        End If
                        num = CLng(Math.Round(CDbl(num) - CDbl(num6) * Math.Pow(10, CDbl((num3 - j)))))
                    Else
                        graphics.DrawImage(Me.bitmap_0(11), Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.1) + num2 * (j - 1), num1)
                        num = Math.Abs(num)
                    End If
                Next

            End If
            If (Me.int_4 > 0) Then
                graphics.DrawImage(Me.bitmap_1, (num3 - Me.int_4) * num2 + Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.072), Convert.ToInt32(CDbl(MyBase.Height) * 0.77))
            End If
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If (MyBase.Height <> Me.int_6 Or MyBase.Width <> Me.int_5) Then
            Me.int_5 = MyBase.Width
            Me.int_6 = MyBase.Height
            Me.CreateStaticImage()
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        MyBase.Invalidate()
    End Sub

    Public Enum ColorSelect
        Blue
        Yellow
        Green
    End Enum
End Class
