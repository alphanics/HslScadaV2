Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class VerticalSlider2
    Inherits AnalogMeterBase
    Private int_2 As Integer

    Private int_3 As Integer

    Private rectangle_0 As Rectangle

    Private rectangle_1 As Rectangle

    Private solidBrush_0 As SolidBrush

    Private color_0 As Color

    Private color_1 As Color

    Private int_4 As Integer

    Private double_0 As Double

    Private string_0 As String

    Private double_1 As Double

    Private double_2 As Double

    Private double_3 As Double

    Private int_5 As Integer

    Private int_6 As Integer

    Private bool_0 As Boolean

    Private bool_1 As Boolean

    Public Property BorderColor As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            If (Me.color_1 <> value) Then
                Me.color_1 = value
                Me.CreateStaticImage()
                Me.OnBorderColorChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property BorderWidth As Integer
        Get
            Return Me.int_4
        End Get
        Set(ByVal value As Integer)
            If (Me.int_4 <> value) Then
                Me.int_4 = Math.Max(1, value)
                Me.int_4 = Math.Min(Me.int_4, 20)
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property FillColorInRange As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (Me.color_0 <> value) Then
                Me.color_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property MajorDivisions As Integer
        Get
            Return Me.int_5
        End Get
        Set(ByVal value As Integer)
            If (Me.int_5 <> value) Then
                Me.int_5 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property MinorDivisions As Integer
        Get
            Return Me.int_6
        End Get
        Set(ByVal value As Integer)
            If (Me.int_6 <> value) Then
                Me.int_6 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property NumericFormat As String
        Get
            Return Me.string_0
        End Get
        Set(ByVal value As String)
            Me.string_0 = value
        End Set
    End Property

    Public Property Resolution As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            Me.double_0 = value
        End Set
    End Property

    Public Property ShowValidRangeMarker As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_0 <> value) Then
                Me.bool_0 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property ShowValue As Boolean
        Get
            Return Me.bool_1
        End Get
        Set(ByVal value As Boolean)
            Me.bool_1 = value
            MyBase.Invalidate()
        End Set
    End Property

    Public Property TargetValue As Double
        Get
            Return Me.double_1
        End Get
        Set(ByVal value As Double)
            If (Me.double_1 <> value) Then
                Me.double_1 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property ToleranceMinus As Double
        Get
            Return Me.double_3
        End Get
        Set(ByVal value As Double)
            If (Me.double_3 <> value) Then
                Me.double_3 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property TolerancePlus As Double
        Get
            Return Me.double_2
        End Get
        Set(ByVal value As Double)
            If (Me.double_2 <> value) Then
                Me.double_2 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.color_0 = Color.FromArgb(16, 128, 16)
        Me.color_1 = Color.DimGray
        Me.int_4 = 4
        Me.double_0 = 1
        Me.string_0 = Conversions.ToString(0)
        Me.double_1 = 50
        Me.double_2 = 10
        Me.double_3 = 10
        Me.bool_0 = True
        MyBase.BackColor = Color.FromArgb(255, 255, 255)
        MyBase.ForeColor = Color.Black
        Me.int_5 = 2
        Me.int_6 = 5
        Me.rectangle_1 = New Rectangle()
        Me.solidBrush_0 = New SolidBrush(Color.Red)
    End Sub

    Protected Overrides Sub CreateStaticImage()
        Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle()
        Dim num As Integer = 0
        Dim num1 As Integer = 0
        Dim x As Integer = 0
        If (MyBase.Width > 0 Or MyBase.Height > 0) Then
            Me.StaticImage = New Bitmap(MyBase.Width, MyBase.Height)
            Me.int_2 = CInt(Math.Round(CDbl(MyBase.Height) / 20))
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
            Using solidBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.color_1, 1))
                graphic.FillRectangle(solidBrush, Me.int_4 * 2, Me.int_4 * 2, MyBase.Width - Me.int_4 * 4, MyBase.Height - Me.int_4 * 4)
            End Using
            BeveledButtonDisplay.Draw3DBorder(Me, graphic, Me.color_1, Me.int_4)
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.BackColor)
                graphic.FillRectangle(solidBrush1, Me.int_4 * 2, Me.int_4 * 2, MyBase.Width - Me.int_4 * 4, MyBase.Height - Me.int_4 * 4)
            End Using
            Using stringFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat()
                If (Not String.IsNullOrEmpty(Me.Text)) Then
                    rectangle = New System.Drawing.Rectangle(Me.int_4 * 2, Me.int_4 * 2 + 1, MyBase.Width - Me.int_4 * 4 - 1, MyBase.Height - Me.int_4 * 4 - 2)
                    stringFormat.Alignment = StringAlignment.Center
                    stringFormat.LineAlignment = StringAlignment.Near
                    graphic.DrawString(Me.Text, Me.Font, Me.TextBrush, rectangle, stringFormat)
                End If
            End Using
            Dim sizeF As System.Drawing.SizeF = graphic.MeasureString(Me.Text, Me.Font, rectangle.Width)
            Dim r As Byte = Me.ForeColor.R
            Dim g As Byte = Me.ForeColor.G
            Dim foreColor As Color = Me.ForeColor
            Using pen As System.Drawing.Pen = New System.Drawing.Pen(Color.FromArgb(80, CInt(r), CInt(g), CInt(foreColor.B)), 2!)
                graphic.DrawLine(pen, CSng((Me.int_4 * 2)), sizeF.Height + CSng((Me.int_4 * 2)) + 2!, CSng((MyBase.Width - Me.int_4 * 2)), sizeF.Height + CSng((Me.int_4 * 2)) + 2!)
            End Using
            Me.int_3 = CInt(Math.Round(CDbl((CSng((MyBase.Height - Me.int_4 * 4)) - sizeF.Height)) - CDbl(Me.Font.Height) * 1.5))
            Me.rectangle_0 = New System.Drawing.Rectangle(CInt(Math.Round(CDbl(MyBase.Width) / 15 + CDbl((Me.int_4 * 2)))), CInt(Math.Round(CDbl((sizeF.Height + CSng(Me.Font.Height) + CSng((Me.int_4 * 2)))))), CInt(Math.Round(CDbl((MyBase.Width - Me.MajorDivisions - Me.BorderWidth * 2)) / 2.75)), Me.int_3)
            Dim linearGradientBrush As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(CInt(Math.Round(CDbl(MyBase.Width) / 5)), 0), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 220, 220, 220))
            Dim colorBlend As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend() With
            {
                .Colors = New Color() {Color.FromArgb(255, 220, 220, 220), Color.FromArgb(255, 32, 32, 32), Color.FromArgb(255, 220, 220, 220)},
                .Positions = New Single() {Nothing, 0.5!, 1!}
            }
            linearGradientBrush.InterpolationColors = colorBlend
            graphic.FillRectangle(linearGradientBrush, New System.Drawing.Rectangle(CInt(Math.Round(CDbl(Me.rectangle_0.X) + CDbl((Me.rectangle_0.Width * 3)) / 8)), Me.rectangle_0.Y, CInt(Math.Round(CDbl(Me.rectangle_0.Width) / 4)), Me.rectangle_0.Height))
            Dim num2 As Integer = Convert.ToInt32(CDbl(MyBase.Width) * 0.12)
            Dim num3 As Integer = Convert.ToInt32(CDbl(MyBase.Width) * 0.08)
            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Me.ForeColor, 2!)
                Using pen2 As System.Drawing.Pen = New System.Drawing.Pen(Me.ForeColor, 1!)
                    If (Me.bool_0) Then
                        Dim num4 As Integer = Me.method_3(Math.Max(Me.double_1 - Me.double_3, Me.m_Minimum)) - Me.method_3(Math.Min(Me.double_1 + Me.double_2, Me.m_Maximum))
                        If (num4 > 0) Then
                            Using solidBrush2 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.color_0, 0.7))
                                graphic.FillRectangle(solidBrush2, Me.rectangle_0.X + Me.rectangle_0.Width + 2, Me.method_3(Math.Min(Me.double_1 + Me.double_2, Me.m_Maximum)), num3, num4)
                            End Using
                        End If
                    End If
                    graphic.DrawLine(pen1, New Point(Me.rectangle_0.X + Me.rectangle_0.Width + 2, Me.rectangle_0.Y), New Point(Me.rectangle_0.X + Me.rectangle_0.Width + num2, Me.rectangle_0.Y))
                    Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(Me.rectangle_0.X + Me.rectangle_0.Width + num2 + 2, Me.rectangle_0.Y - Me.Font.Height, MyBase.Width, Me.Font.Height * 2)
                    Me.stringFormat_0.LineAlignment = StringAlignment.Center
                    Me.stringFormat_0.Alignment = StringAlignment.Near
                    Dim mMaximum As Double = Me.m_Maximum
                    graphic.DrawString(Conversions.ToString(mMaximum), Me.Font, Me.TextBrush, rectangle1, Me.stringFormat_0)
                    If (Me.int_5 > 0) Then
                        While num < Me.int_5
                            num1 = CInt(Math.Round(CDbl(Me.rectangle_0.Y) + CDbl(Me.rectangle_0.Height) / CDbl(Me.int_5) * CDbl((num + 1)) - 1))
                            x = Me.rectangle_0.X + Me.rectangle_0.Width + 2
                            Dim x1 As Integer = Me.rectangle_0.X + Me.rectangle_0.Width + num2
                            graphic.DrawLine(pen1, New Point(x, num1), New Point(x1, num1))
                            rectangle1 = New System.Drawing.Rectangle(x1 + 2, num1 - Me.Font.Height, MyBase.Width - x1, Me.Font.Height * 2)
                            graphic.DrawString(Conversions.ToString(Me.m_Maximum - CDbl((num + 1)) * ((Me.m_Maximum - Me.m_Minimum) / CDbl(Me.int_5))), Me.Font, Me.TextBrush, rectangle1, Me.stringFormat_0)
                            If (Me.int_6 > 1) Then
                                Dim num5 As Integer = 0
                                While num5 < Me.int_6 - 1
                                    Dim num6 As Integer = CInt(Math.Round(CDbl(Me.rectangle_0.Y) + CDbl(Me.rectangle_0.Height) / CDbl((Me.int_5 * Me.int_6)) * CDbl((num5 + 1)) + CDbl(Me.rectangle_0.Height) / CDbl(Me.int_5) * CDbl(num) - 1))
                                    graphic.DrawLine(pen2, New Point(Me.rectangle_0.X + Me.rectangle_0.Width + 2, num6), New Point(Me.rectangle_0.X + Me.rectangle_0.Width + num3, num6))
                                    num5 = num5 + 1
                                End While
                            End If
                            num = num + 1
                        End While
                        graphic.DrawLine(pen2, x, Convert.ToInt32(Me.rectangle_0.Y), x, num1)
                    End If
                End Using
            End Using
            MyBase.Invalidate()
        End If
    End Sub

    Private Sub method_2(ByVal int_7 As Integer)
        Dim height As Double
        Dim mMaximum As Double = Me.m_Maximum - Me.m_Minimum
        If (Me.m_ValueScaleFactor <> 0) Then
            mMaximum /= Me.m_ValueScaleFactor
        End If
        If (Me.m_ValueScaleFactor = 0) Then
            height = CDbl((Me.rectangle_0.Height - int_7 + Me.rectangle_0.Y)) / CDbl(Me.rectangle_0.Height) * mMaximum + Me.m_Minimum
            height = Math.Min(Me.m_Maximum, height)
            height = Math.Max(MyBase.Minimum, height)
        Else
            height = CDbl((Me.rectangle_0.Height - int_7 + Me.rectangle_0.Y)) / CDbl(Me.rectangle_0.Height) * mMaximum + Me.m_Minimum / Me.m_ValueScaleFactor
            height = Math.Min(Me.m_Maximum / Me.m_ValueScaleFactor, height)
            height = Math.Max(MyBase.Minimum / Me.m_ValueScaleFactor, height)
        End If
        If (Me.double_0 > 0) Then
            height = CDbl(Convert.ToInt32(height / Me.double_0)) * Me.double_0
        End If
        If (height <> Me.m_Value) Then
            Me.m_Value = height
            Me.OnValueChangedWithSlider(EventArgs.Empty)
            MyBase.Invalidate()
        End If
    End Sub

    Private Function method_3(ByVal double_4 As Double) As Integer
        Dim num As Double
        num = If(MyBase.ValueScaleFactor = 0, Me.m_Maximum - Me.m_Minimum, Me.m_Maximum * Me.m_ValueScaleFactor - Me.m_Minimum * Me.m_ValueScaleFactor)
        Dim double4 As Double = (double_4 - Me.m_Minimum) / num
        Dim num1 As Integer = CInt(Math.Round(CDbl(Me.rectangle_0.Height) * double4))
        Dim y As Integer = Me.rectangle_0.Y + Me.rectangle_0.Height - num1
        Return y
    End Function

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overridable Sub OnBorderColorChanged(ByVal e As EventArgs)
        RaiseEvent BorderColorChanged(Me, e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.method_2(e.Y)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim location As Point = e.Location
        If (e.Button = System.Windows.Forms.MouseButtons.Left And location.Y > -10 And e.Location.X > -10) Then
            Me.method_2(e.Y)
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)

    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        MyBase.Invalidate(Me.rectangle_0)
    End Sub

    Protected Overridable Sub OnValueChangedWithSlider(ByVal e As EventArgs)
        RaiseEvent ValueChangedWithSlider(Me, e)
    End Sub

    Public Event BorderColorChanged As EventHandler

    Public Event ValueChangedWithSlider As EventHandler


    Public Enum FillTypes
        Fill
        WideBand
        NarrowBand
    End Enum
End Class
