Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class AnalogDial
    Inherits Control
    Private bool_0 As Boolean

    Private float_0 As Single

    Private rectangle_0 As Rectangle

    Private stringFormat_0 As StringFormat

    Private stringFormat_1 As StringFormat

    Private stringFormat_2 As StringFormat

    Private stringFormat_3 As StringFormat

    Private rectangle_1 As Rectangle

    Private double_0 As Double

    Private bitmap_0 As Bitmap

    Private solidBrush_0 As SolidBrush

    Private bitmap_1 As Bitmap

    Private bitmap_2 As Bitmap

    Private bool_1 As Boolean

    Private double_1 As Double

    Private double_2 As Double

    Private double_3 As Double

    Private double_4 As Double

    Private bool_2 As Boolean

    Private double_5 As Double

    Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams
        Get
            Dim exStyle As System.Windows.Forms.CreateParams = MyBase.CreateParams
            exStyle.ExStyle = exStyle.ExStyle Or 32
            Return exStyle
        End Get
    End Property

    Public Shadows Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If (value <> MyBase.ForeColor) Then
                MyBase.ForeColor = value
                Me.solidBrush_0 = New SolidBrush(MyBase.ForeColor)
                Me.method_1()
            End If
        End Set
    End Property

    Public Property Maximum As Double
        Get
            Return Me.double_2
        End Get
        Set(ByVal value As Double)
            If (Me.double_2 <> value) Then
                Me.double_2 = value
                Me.method_1()
            End If
        End Set
    End Property

    Public Property Minimum As Double
        Get
            Return Me.double_1
        End Get
        Set(ByVal value As Double)
            If (Me.double_1 <> value) Then
                Me.double_1 = value
                Me.method_1()
            End If
        End Set
    End Property

    Public Property RedColorBandStartValue As Double
        Get
            Return Me.double_5
        End Get
        Set(ByVal value As Double)
            If (Me.double_5 <> value) Then
                Me.double_5 = value
                Me.method_1()
            End If
        End Set
    End Property

    Public Property Resolution As Double
        Get
            Return Me.double_4
        End Get
        Set(ByVal value As Double)
            Me.double_4 = value
        End Set
    End Property

    Public Property ShowColorBand As Boolean
        Get
            Return Me.bool_2
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_2 <> value) Then
                Me.bool_2 = value
                Me.method_1()
            End If
        End Set
    End Property

    Public Property Value As Double
        Get
            Return Me.double_3
        End Get
        Set(ByVal value As Double)
            If (Me.double_3 <> value And Not Me.bool_0) Then
                Me.method_2(value, False)
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.rectangle_0 = New Rectangle()
        Me.stringFormat_0 = New StringFormat()
        Me.stringFormat_1 = New StringFormat()
        Me.stringFormat_2 = New StringFormat()
        Me.stringFormat_3 = New StringFormat()
        Me.bool_1 = True
        Me.double_2 = 100
        Me.double_4 = 0.1
        Me.bool_2 = True
        Me.double_5 = 75
        MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Private Sub method_0(ByVal int_0 As Integer, ByVal int_1 As Integer)
        Dim num As Integer = CInt(Math.Round(CDbl(int_0) - CDbl(MyBase.Width) / 2))
        Dim num1 As Integer = CInt(Math.Round(CDbl(MyBase.Height) / 2 - CDbl(int_1)))
        Dim num2 As Double = Math.Atan(CDbl(num1) / CDbl(num)) * 180 / 3.14159265358979
        If (num < 0) Then
            num2 += 180
        End If
        Dim num3 As Double = 180 - num2
        Dim double3 As Double = Me.double_3
        Me.method_2((num3 + 45) / 270 * (Me.double_2 - Me.double_1) + Me.double_1, True)
        If (Me.double_3 <> double3) Then
            Me.OnValueChangedWithDial(EventArgs.Empty)
        End If
    End Sub

    Private Sub method_1()
        Using graphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
            graphicsPath.AddEllipse(-1, -1, MyBase.Width + 1, MyBase.Height + 1)
            MyBase.Region = New System.Drawing.Region(graphicsPath)
        End Using
        Dim width As Double = CDbl(MyBase.Width) / CDbl(My.Resources.ChromeKnob.Width) / 3
        Dim height As Double = CDbl(MyBase.Height) / CDbl(My.Resources.ChromeKnob.Height) / 3
        If (width >= height) Then
            Me.double_0 = height
        Else
            Me.double_0 = width
        End If
        If (Me.double_0 > 0) Then
            Me.stringFormat_1.Alignment = StringAlignment.Center
            Me.stringFormat_1.LineAlignment = StringAlignment.Center
            If (Me.solidBrush_0 Is Nothing) Then
                Me.solidBrush_0 = New SolidBrush(MyBase.ForeColor)
            End If
            If (Me.bitmap_1 IsNot Nothing) Then
                Me.bitmap_1.Dispose()
            End If
            Me.bitmap_1 = New Bitmap(MyBase.Width, MyBase.Height)
            Using graphic As Graphics = Graphics.FromImage(Me.bitmap_1)
                graphic.SmoothingMode = SmoothingMode.HighQuality
                graphic.DrawImage(My.Resources.Plate, 0, 0, MyBase.Width, MyBase.Height)
                Dim num As Integer = Convert.ToInt32((Me.double_2 - Me.double_1) / 10)
                Using font As System.Drawing.Font = New System.Drawing.Font("Arial", CSng((65 * Me.double_0)), FontStyle.Regular, GraphicsUnit.Point)
                    Dim size As System.Drawing.Size = TextRenderer.MeasureText(Conversions.ToString(Me.double_2), font)
                    Dim width1 As Integer = size.Width
                    size = TextRenderer.MeasureText(Conversions.ToString(Me.double_2), font)
                    Dim height1 As Integer = size.Height
                    Me.stringFormat_3.Alignment = StringAlignment.Near
                    Me.stringFormat_0.Alignment = StringAlignment.Center
                    Me.stringFormat_2.Alignment = StringAlignment.Far
                    Dim num1 As Double = CDbl(MyBase.Width) / 2 - CDbl(width1) / 2
                    Dim num2 As Integer = Convert.ToInt32(Math.Cos(3.92699081698724) * num1 - CDbl(width1) / 2)
                    Dim num3 As Integer = Convert.ToInt32(Math.Sin(3.92699081698724) * num1 + CDbl(height1) / 2)
                    Dim width2 As Double = CDbl(MyBase.Width) / 2
                    Dim height2 As Double = CDbl(MyBase.Height) / 2
                    Dim num4 As Integer = 0
                    Do
                        Dim num5 As Double = CDbl((225 - 27 * num4)) * 3.14159265358979 / 180
                        num1 = Math.Sqrt(width2 * width2 * Math.Cos(num5) * Math.Cos(num5) + height2 * height2 * Math.Sin(num5) * Math.Sin(num5)) - CDbl(width1) / 2
                        num2 = Convert.ToInt32(Math.Cos(num5) * num1 - CDbl(width1) / 2)
                        num3 = Convert.ToInt32(Math.Sin(num5) * num1 + CDbl(height1) / 2)
                        Me.rectangle_1 = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(num2) + CDbl(MyBase.Width) / 2), Convert.ToInt32(CDbl(MyBase.Height) / 2 - CDbl(num3)), width1, height1)
                        graphic.DrawString(Convert.ToString(Me.double_1 + CDbl((num * num4))), font, Me.solidBrush_0, Me.rectangle_1, Me.stringFormat_0)
                        num4 = num4 + 1
                    Loop While num4 <= 10
                End Using
                If (Me.bool_2) Then
                    Using pen As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Green, CSng((CDbl(MyBase.Width) / 18)))
                        Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(CInt(Math.Round(CDbl(MyBase.Width) * 0.23)), CInt(Math.Round(CDbl(MyBase.Height) * 0.23)), CInt(Math.Round(CDbl(MyBase.Width) * 0.54)), CInt(Math.Round(CDbl(MyBase.Height) * 0.54)))
                        graphic.DrawArc(pen, rectangle, 135!, 270!)
                        If (Me.double_5 > Me.double_1 And Me.double_5 < Me.double_2 AndAlso Me.double_2 <> Me.double_1) Then
                            Dim double5 As Single = CSng(((Me.double_5 - Me.double_1) / (Me.double_2 - Me.double_1) * 270))
                            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Brushes.Red, CSng((CDbl(MyBase.Width) / 18)))
                                graphic.DrawArc(pen1, rectangle, 135! + double5, 270! - double5)
                            End Using
                        End If
                    End Using
                End If
            End Using
            Me.rectangle_0 = New System.Drawing.Rectangle(CInt(Math.Round(CDbl(MyBase.Width) * 0.1)), CInt(Math.Round(CDbl(MyBase.Height) * 0.9)), CInt(Math.Round(CDbl(MyBase.Width) * 0.8)), CInt(Math.Round(CDbl(Me.Font.Height) * 1.1)))
            Me.bitmap_2 = New Bitmap(MyBase.Width, MyBase.Height)
            Using graphic1 As Graphics = Graphics.FromImage(Me.bitmap_2)
                graphic1.SmoothingMode = SmoothingMode.AntiAlias
                graphic1.DrawImage(My.Resources.ChromeKnob, New System.Drawing.Rectangle(CInt(Math.Round(CDbl(MyBase.Width) / 4)), CInt(Math.Round(CDbl(MyBase.Height) / 4)), CInt(Math.Round(CDbl(MyBase.Width) / 2)), CInt(Math.Round(CDbl(MyBase.Height) / 2))))
            End Using
            Me.bool_1 = True
            MyBase.Invalidate()
        End If
    End Sub

    Private Sub method_2(ByVal double_6 As Double, ByVal bool_3 As Boolean)
        Dim num As Double = Math.Min(double_6, Me.double_2)
        num = Math.Max(num, Me.double_1)
        If (Me.double_4 > 0) Then
            num = CDbl(Convert.ToInt32(num / Me.double_4)) * Me.double_4
        End If
        If (Me.double_2 = Me.double_1) Then
            Me.float_0 = -90!
        Else
            Me.float_0 = CSng(((num - Me.Minimum) / (Me.double_2 - Me.double_1) * 270 - 135))
        End If
        If (Not bool_3) Then
            Me.double_3 = double_6
        Else
            Me.double_3 = num
        End If
        MyBase.Invalidate()
        Me.OnValueChanged(EventArgs.Empty)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.bool_0 = True
        Dim location As Point = e.Location
        If (e.Button = System.Windows.Forms.MouseButtons.Left And location.Y > -10 And e.Location.X > -10) Then
            Dim x As Integer = e.Location.X
            location = e.Location
            Me.method_0(x, location.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim location As Point = e.Location
        If (e.Button = System.Windows.Forms.MouseButtons.Left And location.Y > -10 And e.Location.X > -10 And e.Location.Y < MyBase.Width + 10 And e.Location.X < MyBase.Height + 10) Then
            Dim x As Integer = e.Location.X
            location = e.Location
            Me.method_0(x, location.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal mevent As MouseEventArgs)
        MyBase.OnMouseUp(mevent)
        Me.bool_0 = False
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        MyBase.OnPaint(painte)
        Dim graphics As System.Drawing.Graphics = painte.Graphics
        graphics.Clear(Me.BackColor)
        If (Me.bitmap_1 IsNot Nothing) Then
            graphics.DrawImage(Me.bitmap_1, 0, 0)
        End If
        If (Me.solidBrush_0 IsNot Nothing) Then
            graphics.DrawString(Me.Text, Me.Font, Me.solidBrush_0, Me.rectangle_0, Me.stringFormat_1)
        End If
        Using matrix As System.Drawing.Drawing2D.Matrix = New System.Drawing.Drawing2D.Matrix()
            Dim width As Double = CDbl(My.Resources.ChromeKnob.Width) / 2
            Dim height As Double = CDbl(My.Resources.ChromeKnob.Height) / 2
            Dim [single] As Single = CSng(MyBase.Width) / (CSng(My.Resources.ChromeKnob.Width) / 0.5!)
            Dim height1 As Single = CSng(MyBase.Height) / (CSng(My.Resources.ChromeKnob.Height) / 0.5!)
            matrix.RotateAt(Me.float_0, New Point(Convert.ToInt32(width), Convert.ToInt32(height)), MatrixOrder.Prepend)
            matrix.Scale([single], height1, MatrixOrder.Append)
            matrix.Translate((CSng(MyBase.Width) - CSng(My.Resources.ChromeKnob.Width) * [single]) / 2.0!, (CSng(MyBase.Height) - CSng(My.Resources.ChromeKnob.Height) * height1) / 2.0!, MatrixOrder.Append)
            graphics.Transform = matrix
            graphics.DrawImage(My.Resources.ChromeKnob, 0, 0)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
        If (Me.bool_1) Then
            MyBase.OnPaintBackground(pevent)
            Me.bool_1 = False
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.method_1()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        MyBase.Invalidate()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)

        RaiseEvent ValueChanged(Me, e)
    End Sub

    Protected Overridable Sub OnValueChangedWithDial(ByVal e As EventArgs)

        RaiseEvent ValueChangedWithDial(Me, e)
    End Sub

    Public Event ValueChanged As EventHandler



    Public Event ValueChangedWithDial As EventHandler

End Class
