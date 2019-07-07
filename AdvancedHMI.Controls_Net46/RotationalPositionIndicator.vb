Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms

Public Class RotationalPositionIndicator
    Inherits Control
    Private int_0 As Integer

    Private color_0 As Color

    Private int_1 As Integer

    Private color_1 As Color

    Private int_2 As Integer

    Private string_0 As String

    Private double_0 As Double

    Private double_1 As Double

    Private double_2 As Double

    Private color_2 As Color

    Private double_3 As Double

    Private double_4 As Double

    Private color_3 As Color

    Private bool_0 As Boolean

    Private bool_1 As Boolean

    Private bool_2 As Boolean

    Private bool_3 As Boolean

    Private bool_4 As Boolean

    Private color_4 As Color

    Private color_5 As Color

    Private rectangle_0 As Rectangle

    Private rectangle_1 As Rectangle

    Private rectangle_2 As Rectangle

    Private rectangle_3 As Rectangle

    Private pointF_0 As PointF()

    Private solidBrush_0 As SolidBrush

    Private stringFormat_0 As StringFormat

    Private linearGradientBrush_0 As LinearGradientBrush

    Private image_0 As Image

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(GetType(Color), "Black")>
    <Description("The arrow color.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ArrowColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (Me.color_0 <> value) Then
                Me.color_0 = value
                If (Me.linearGradientBrush_0 IsNot Nothing) Then
                    Me.method_0()
                End If
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(9)>
    <Description("The arrow width.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ArrowWidth As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            If (Me.int_1 <> value) Then
                Me.int_1 = Math.Max(5, value)
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(GetType(Color), "Black")>
    <Description("Major tick color.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property MajorTickColor As Color
        Get
            Return Me.color_4
        End Get
        Set(ByVal value As Color)
            If (value <> Me.color_4) Then
                Me.color_4 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <Description("Minor tick color.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property MinorTickColor As Color
        Get
            Return Me.color_5
        End Get
        Set(ByVal value As Color)
            If (value <> Me.color_5) Then
                Me.color_5 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(False)>
    <Description("Display compass directions (N, E, S and W).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ShowCompassDirections As Boolean
        Get
            Return Me.bool_2
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_2 <> value) Then
                Me.bool_2 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(True)>
    <Description("Display 3D outer ring")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ShowOuterRing As Boolean
        Get
            Return Me.bool_3
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_3 <> value) Then
                Me.bool_3 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(True)>
    <Description("Show target bands.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ShowTargetBands As Boolean
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

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(True)>
    <Description("Display tick mark scale")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ShowTickMarks As Boolean
        Get
            Return Me.bool_4
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_4 <> value) Then
                Me.bool_4 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(True)>
    <Description("Display a tick to represent the zero position.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ShowZeroTick As Boolean
        Get
            Return Me.bool_1
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_1 <> value) Then
                Me.bool_1 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(0!)>
    <Description("Second target range value.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Target2Value As Double
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

    <Browsable(True)>
    <Category("Appearance")>
    <Description("Second target range color.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Target2ValueColor As Color
        Get
            Return Me.color_3
        End Get
        Set(ByVal value As Color)
            If (Me.color_3 <> value) Then
                Me.color_3 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(10!)>
    <Description("Second target range tolerance.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Target2ValueTolerance As Double
        Get
            Return Me.double_4
        End Get
        Set(ByVal value As Double)
            If (Me.double_4 <> value) Then
                Me.double_4 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(0!)>
    <Description("First target range value.")>
    <RefreshProperties(RefreshProperties.All)>
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

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(GetType(Color), "Yellow")>
    <Description("First target range color.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property TargetValueColor As Color
        Get
            Return Me.color_2
        End Get
        Set(ByVal value As Color)
            If (Me.color_2 <> value) Then
                Me.color_2 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(5!)>
    <Description("First target range tolerance.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property TargetValueTolerance As Double
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

    <Browsable(True)>
    <DefaultValue(0!)>
    <Description("Indicates the actual received arrow angle value in degrees. It could be any double-precision floating point value.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Value As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            If (Me.double_0 <> value) Then
                Me.double_0 = value
                Me.OnValueChanged(EventArgs.Empty)
            End If
            Me.string_0 = String.Concat(String.Format(Conversions.ToString(Decimal.Remainder(New Decimal(Me.double_0), New Decimal(360L))), "0"), "°")
            MyBase.Invalidate()
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(GetType(Color), "White")>
    <Description("The arrow zero/home line color.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ZeroLineColor As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            If (Me.color_1 <> value) Then
                Me.color_1 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(90)>
    <Description("Indicates the arrow zero/home position (East is set as zero angle and the zero line position angle is measured counterclockwise in increments of 1°).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property ZeroLinePosition As Integer
        Get
            Return Me.int_2
        End Get
        Set(ByVal value As Integer)
            If (Me.int_2 <> value) Then
                Me.int_2 = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.color_0 = Color.Black
        Me.int_1 = 9
        Me.color_1 = Color.White
        Me.int_2 = 90
        Me.string_0 = "0°"
        Me.double_0 = 0
        Me.double_2 = 5
        Me.color_2 = Color.Gold
        Me.double_4 = 10
        Me.color_3 = Color.FromArgb(192, 0, 0)
        Me.bool_0 = True
        Me.bool_1 = True
        Me.bool_3 = True
        Me.bool_4 = True
        Me.color_4 = Color.Black
        Me.color_5 = Color.FromArgb(20, 20, 20)
        ReDim Me.pointF_0(6)
        MyBase.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.White
        MyBase.ForeColor = Color.Black
        MyBase.Size = New System.Drawing.Size(120, 120)
        Me.MinimumSize = New System.Drawing.Size(60, 60)
    End Sub

    Protected Overridable Sub CreateStaticImage()
        Me.rectangle_0 = New System.Drawing.Rectangle(New Point(0, 0), New System.Drawing.Size(MyBase.Width - 1, MyBase.Height - 1))
        Using graphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
            graphicsPath.AddEllipse(Me.rectangle_0)
            MyBase.Region = New System.Drawing.Region(graphicsPath)
        End Using
        Me.int_0 = CInt(Math.Round(CDbl(MyBase.Width) / 17))
        Me.rectangle_2 = New System.Drawing.Rectangle(New Point(Me.int_0, Me.int_0), New System.Drawing.Size(MyBase.Width - Me.int_0 * 2, MyBase.Height - Me.int_0 * 2))
        Dim int0 As Integer = Me.int_0
        Me.rectangle_1 = New System.Drawing.Rectangle(New Point(int0, int0), New System.Drawing.Size(MyBase.Width - int0 * 2, MyBase.Height - int0 * 2))
        Me.image_0 = New Bitmap(MyBase.Width, MyBase.Height)
        Using solidBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.color_3)
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.color_2)
                Using solidBrush2 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.BackColor)
                    Using graphic As Graphics = Graphics.FromImage(Me.image_0)
                        If (Me.solidBrush_0 Is Nothing) Then
                            Me.solidBrush_0 = New System.Drawing.SolidBrush(Me.ForeColor)
                        End If
                        Me.method_0()
                        Me.method_1()
                        Dim num As Integer = 15
                        Using pen As System.Drawing.Pen = New System.Drawing.Pen(Me.color_5, 1!)
                            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Me.color_4, 2!)
                                Using pen2 As System.Drawing.Pen = New System.Drawing.Pen(Me.color_1, 3!)
                                    Dim pen3 As System.Drawing.Pen = pen
                                    graphic.SmoothingMode = SmoothingMode.AntiAlias
                                    num = CInt(Math.Round(CDbl((CSng(MyBase.Width) / 15!))))
                                    Dim num1 As Integer = CInt(Math.Round(CDbl(MyBase.Width) / 30))
                                    Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(New Point(CInt(Math.Round(CDbl(Me.int_0) + CDbl(num1) / 2 - 1)), CInt(Math.Round(CDbl(Me.int_0) + CDbl(num1) / 2 - 1))), New System.Drawing.Size(CInt(Math.Round(CDbl(Me.rectangle_1.Width) - CDbl(num) / 2 + 2)), CInt(Math.Round(CDbl(Me.rectangle_1.Height) - CDbl(num) / 2 + 2))))
                                    If (Me.bool_3) Then
                                        Using pen4 As System.Drawing.Pen = New System.Drawing.Pen(Me.method_1(), CSng(Me.int_0))
                                            graphic.DrawEllipse(pen4, New RectangleF(CSng(Math.Floor(CDbl(Me.int_0) / 2)) - 1!, CSng(Math.Floor(CDbl(Me.int_0) / 2)) - 1!, CSng((CDbl((Me.rectangle_2.Width + Me.rectangle_0.Width)) / 2 + 1)), CSng((CDbl((Me.rectangle_2.Height + Me.rectangle_0.Height)) / 2 + 1))))
                                        End Using
                                    End If
                                    If (Me.double_4 > 0 And Me.bool_0) Then
                                        Using pen5 As System.Drawing.Pen = New System.Drawing.Pen(Me.color_3, CSng(num1))
                                            graphic.DrawArc(pen5, rectangle, CSng((Me.double_3 - Me.double_4 - CDbl(Me.int_2))), CSng((Me.double_4 * 2)))
                                        End Using
                                    End If
                                    If (Me.double_2 > 0 And Me.bool_0) Then
                                        Using pen6 As System.Drawing.Pen = New System.Drawing.Pen(Me.color_2, CSng(num1))
                                            graphic.DrawArc(pen6, rectangle, CSng((Me.double_1 - Me.double_2 - CDbl(Me.int_2))), CSng((Me.double_2 * 2)))
                                        End Using
                                    End If
                                    If (Me.bool_4) Then
                                        Dim num2 As Integer = 0
                                        Do
                                            If (num2 Mod 3 <> 0) Then
                                                num = CInt(Math.Round(CDbl((CSng(MyBase.Width) / 15!))))
                                                pen3 = pen
                                            Else
                                                num = CInt(Math.Round(CDbl((CSng(MyBase.Width) / 10!))))
                                                pen3 = pen1
                                            End If
                                            graphic.DrawLine(pen3, CInt(Math.Round(CDbl((Me.rectangle_1.Width - num)) / 2 * Math.Cos(CDbl((num2 * 5)) * 3.14159265358979 / 180) + CDbl(Me.rectangle_1.Width) / 2)) + CInt(Math.Round(CDbl((Me.rectangle_0.Width - Me.rectangle_1.Width)) / 2)), CInt(Math.Round(CDbl((Me.rectangle_1.Width - num)) / 2 * Math.Sin(CDbl((num2 * 5)) * 3.14159265358979 / 180) + CDbl(Me.rectangle_1.Height) / 2)) + CInt(Math.Round(CDbl((Me.rectangle_0.Height - Me.rectangle_1.Height)) / 2)), CInt(Math.Round(CDbl(Me.rectangle_1.Width) / 2 * Math.Cos(CDbl((num2 * 5)) * 3.14159265358979 / 180) + CDbl(Me.rectangle_1.Width) / 2)) + CInt(Math.Round(CDbl((Me.rectangle_0.Width - Me.rectangle_1.Width)) / 2)), CInt(Math.Round(CDbl(Me.rectangle_1.Width) / 2 * Math.Sin(CDbl((num2 * 5)) * 3.14159265358979 / 180) + CDbl(Me.rectangle_1.Height) / 2)) + CInt(Math.Round(CDbl((Me.rectangle_0.Height - Me.rectangle_1.Height)) / 2)))
                                            num2 = num2 + 1
                                        Loop While num2 <= 71
                                    End If
                                    If (Me.bool_2) Then
                                        Using font As System.Drawing.Font = New System.Drawing.Font("Bell MT", CSng((CDbl((20 * MyBase.Height)) / 300)), FontStyle.Bold)
                                            Using stringFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat()
                                                stringFormat.Alignment = StringAlignment.Center
                                                stringFormat.LineAlignment = StringAlignment.Far
                                                graphic.DrawString("N", font, Me.solidBrush_0, CSng(CInt(Math.Round(CDbl((CSng(MyBase.Width) / 2!))))), CSng((Me.rectangle_0.Height - Me.rectangle_2.Height + int0 + 10)), stringFormat)
                                                stringFormat.LineAlignment = StringAlignment.Near
                                                graphic.DrawString("S", font, Me.solidBrush_0, CSng(CInt(Math.Round(CDbl((CSng(MyBase.Width) / 2!))))), CSng((MyBase.Height - (Me.rectangle_0.Height - Me.rectangle_2.Height + int0 + 10))), stringFormat)
                                                stringFormat.Alignment = StringAlignment.Far
                                                stringFormat.LineAlignment = StringAlignment.Center
                                                graphic.DrawString("W", font, Me.solidBrush_0, CSng((Me.rectangle_0.Width - Me.rectangle_1.Width + int0 + 15)), CSng(CInt(Math.Round(CDbl((CSng(MyBase.Width) / 2!))))), stringFormat)
                                                stringFormat.Alignment = StringAlignment.Near
                                                graphic.DrawString("E", font, Me.solidBrush_0, CSng((MyBase.Width - (Me.rectangle_0.Width - Me.rectangle_1.Width + int0 + 5))), CSng(CInt(Math.Round(CDbl((CSng(MyBase.Width) / 2!))))), stringFormat)
                                            End Using
                                        End Using
                                    End If
                                    If (Me.bool_1) Then
                                        graphic.DrawLine(pen2, CInt(Math.Round(CDbl(MyBase.Width) / 2)) + CInt(Math.Round(CDbl(Me.rectangle_1.Width) / 2 * Math.Cos(CDbl(Me.int_2) * 3.14159265358979 / 180))), CInt(Math.Round(CDbl(MyBase.Height) / 2)) - CInt(Math.Round(CDbl(Me.rectangle_1.Width) / 2 * Math.Sin(CDbl(Me.int_2) * 3.14159265358979 / 180))), CInt(Math.Round(CDbl(MyBase.Width) / 2)) + CInt(Math.Round(CDbl(Me.rectangle_2.Width) / 2 * Math.Cos(CDbl(Me.int_2) * 3.14159265358979 / 180))), CInt(Math.Round(CDbl(MyBase.Height) / 2)) - CInt(Math.Round(CDbl(Me.rectangle_2.Width) / 2 * Math.Sin(CDbl(Me.int_2) * 3.14159265358979 / 180))))
                                    End If
                                    If (Not String.IsNullOrEmpty(Me.Text)) Then
                                        If (Not ((Me.BackColor = Color.Transparent) And Me.BackgroundImage Is Nothing)) Then
                                            graphic.TextRenderingHint = TextRenderingHint.AntiAlias
                                        Else
                                            graphic.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                                        End If
                                        graphic.DrawString(Me.Text, Me.Font, Me.solidBrush_0, New Point(CInt(Math.Round(CDbl((CSng(MyBase.Width) / 2!)))), CInt(Math.Round(CDbl(MyBase.Height) * 0.55))), Me.stringFormat_0)
                                    End If
                                End Using
                            End Using
                        End Using
                        Me.rectangle_3 = New System.Drawing.Rectangle(New Point(CInt(Math.Round(CDbl((CSng(MyBase.Width) / 2! - CSng(Me.int_1) / 2!)))), CInt(Math.Round(CDbl(MyBase.Height) / 2 - CDbl((CSng(Me.int_1) / 2!))))), New System.Drawing.Size(Me.int_1, Me.int_1))
                        Me.pointF_0(0) = New PointF(CSng(MyBase.Width) / 2!, CSng(MyBase.Height) / 2! - CSng(Me.int_1) / 2!)
                        Me.pointF_0(1) = New PointF(CSng(MyBase.Width) * 5.25! / 7!, CSng(MyBase.Height) / 2! - CSng(Me.int_1) / 2!)
                        Me.pointF_0(2) = New PointF(CSng(MyBase.Width) * 5.25! / 7!, CSng(MyBase.Height) / 2! - CSng(Me.int_1))
                        Me.pointF_0(3) = New PointF(CSng(MyBase.Width) - CSng((MyBase.Width - Me.rectangle_1.Width + 5)) / 2!, CSng(MyBase.Height) / 2!)
                        Me.pointF_0(4) = New PointF(CSng(MyBase.Width) * 5.25! / 7!, CSng(MyBase.Height) / 2! + CSng(Me.int_1))
                        Me.pointF_0(5) = New PointF(CSng(MyBase.Width) * 5.25! / 7!, CSng(MyBase.Height) / 2! + CSng(Me.int_1) / 2!)
                        Me.pointF_0(6) = New PointF(CSng(MyBase.Width) / 2!, CSng(MyBase.Height) / 2! + CSng(Me.int_1) / 2!)
                        If (Me.stringFormat_0 Is Nothing) Then
                            Me.stringFormat_0 = New System.Drawing.StringFormat() With
                            {
                                .Alignment = StringAlignment.Center,
                                .LineAlignment = StringAlignment.Center
                            }
                        End If
                    End Using
                End Using
            End Using
        End Using
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                If (Me.solidBrush_0 IsNot Nothing) Then
                    Me.solidBrush_0.Dispose()
                End If
                If (Me.linearGradientBrush_0 IsNot Nothing) Then
                    Me.linearGradientBrush_0.Dispose()
                End If
                If (Me.stringFormat_0 IsNot Nothing) Then
                    Me.stringFormat_0.Dispose()
                End If
                If (Me.image_0 IsNot Nothing) Then
                    Me.image_0.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub method_0()
        If (Me.linearGradientBrush_0 IsNot Nothing) Then
            Me.linearGradientBrush_0.Dispose()
        End If
        Me.linearGradientBrush_0 = New LinearGradientBrush(New Point(0, CInt(Math.Round(CDbl(MyBase.Height) / 2 - CDbl(Me.int_1)))), New Point(0, CInt(Math.Round(CDbl(MyBase.Height) / 2 + CDbl(Me.int_1)))), Me.color_0, ControlPaint.LightLight(Me.color_0))
        Dim singleArray() As Single = {0!, 0.3!, 0.5!, 0.7!, 1!}
        Dim color0() As Color = {Me.color_0, Me.color_0, ControlPaint.Light(Me.color_0, 0.5!), Me.color_0, Me.color_0}
        Dim colorBlend As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend() With
        {
            .Positions = singleArray,
            .Colors = color0
        }
        Me.linearGradientBrush_0.InterpolationColors = colorBlend
    End Sub

    Private Function method_1() As System.Drawing.Drawing2D.PathGradientBrush
        Dim pathGradientBrush As System.Drawing.Drawing2D.PathGradientBrush
        Using graphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
            graphicsPath.AddEllipse(Me.rectangle_0)
            pathGradientBrush = New System.Drawing.Drawing2D.PathGradientBrush(graphicsPath)
            Dim singleArray() As Single = {0!, 0.06!, 0.12!, 0.12!, 1!}
            Dim black() As Color = {Color.Black, Color.White, Color.Black, Color.Transparent, Color.Transparent}
            Dim colorBlend As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend() With
            {
                .Positions = singleArray,
                .Colors = black
            }
            pathGradientBrush.InterpolationColors = colorBlend
        End Using
        Return pathGradientBrush
    End Function

    Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        Me.solidBrush_0 = New SolidBrush(Me.ForeColor)
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        MyBase.OnPaint(painte)
        If (Me.solidBrush_0 IsNot Nothing) Then
            painte.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            painte.Graphics.DrawImage(Me.image_0, 0, 0)
            painte.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias
            painte.Graphics.DrawString(Me.string_0, Me.Font, Me.solidBrush_0, CSng(CInt(Math.Round(CDbl((CSng(MyBase.Width) / 2!))))), CSng(CInt(Math.Round(CDbl((CSng(MyBase.Height) * 2! / 3!))))), Me.stringFormat_0)
            Me.PaintActiveContent(painte.Graphics)
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        MyBase.Width = MyBase.Height
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Protected Overridable Sub PaintActiveContent(ByVal graphics As System.Drawing.Graphics)
        Dim clientRectangle As Rectangle = MyBase.ClientRectangle
        Dim width As Single = CSng(clientRectangle.Width) / 2!
        clientRectangle = MyBase.ClientRectangle
        graphics.TranslateTransform(width, CSng(clientRectangle.Height) / 2!)
        graphics.RotateTransform(CSng((Me.double_0 - CDbl(CSng(Me.int_2)))))
        clientRectangle = MyBase.ClientRectangle
        Dim [single] As Single = -CSng(clientRectangle.Width) / 2!
        clientRectangle = MyBase.ClientRectangle
        graphics.TranslateTransform([single], -CSng(clientRectangle.Height) / 2!)
        graphics.FillEllipse(Me.linearGradientBrush_0, Me.rectangle_3)
        graphics.FillPolygon(Me.linearGradientBrush_0, Me.pointF_0)
    End Sub

    Public Event ValueChanged As EventHandler

End Class
