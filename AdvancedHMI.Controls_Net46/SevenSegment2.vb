Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

<DefaultEvent("")>
Public Class SevenSegment2
    Inherits Control
    Private point_0 As Point()

    Private point_1 As Point()

    Private point_2 As Point()

    Private point_3 As Point()

    Private point_4 As Point()

    Private point_5 As Point()

    Private point_6 As Point()

    Private bitmap_0 As Bitmap()

    Private bitmap_1 As Bitmap()

    Private bitmap_2 As Bitmap()

    Private bitmap_3 As Bitmap

    Private bitmap_4 As Bitmap

    Private bitmap_5 As Bitmap

    Private float_0 As Single

    Private color_1 As Color

    Private color_2 As Color

    Private color_3 As Color

    Private double_0 As Double

    Private double_1 As Double

    Private double_2 As Double

    Private decimal_0 As Decimal

    Private int_0 As Integer

    Private int_1 As Integer

    Private bool_0 As Boolean

    Private int_2 As Integer

    Private int_3 As Integer

    Private point_7 As Point

    Private int_4 As Integer

    Private bitmap_6 As Bitmap

    Private int_5 As Integer

    Private int_6 As Integer

    Private bool_1 As Boolean

    Private double_3 As Double

    Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams
        Get
            Dim exStyle As System.Windows.Forms.CreateParams = MyBase.CreateParams
            exStyle.ExStyle = exStyle.ExStyle Or 32
            Return exStyle
        End Get
    End Property

    <Category("Numeric Display")>
    Public Property DecimalPosition As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.int_1) Then
                Me.int_1 = Math.Max(Math.Min(Me.int_0 - 1, value), 0)
                Me.method_2()
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Overrides Property ForeColor As Color

    Public Property ForecolorHighLimitValue As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            If (Me.double_0 <> value) Then
                Me.double_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property ForeColorInLimits As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            If (Me.color_1 <> value) Then
                Me.color_1 = value
                Me.method_2()
            End If
        End Set
    End Property

    Public Property ForecolorLowLimitValue As Double
        Get
            Return Me.double_1
        End Get
        Set(ByVal value As Double)
            If (Me.double_1 <> value) Then
                Me.double_1 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property ForeColorOverHighLimit As Color
        Get
            Return Me.color_2
        End Get
        Set(ByVal value As Color)
            If (Me.color_2 <> value) Then
                Me.color_2 = value
                Me.method_2()
            End If
        End Set
    End Property

    Public Property ForeColorUnderLowLimit As Color
        Get
            Return Me.color_3
        End Get
        Set(ByVal value As Color)
            If (Me.color_3 <> value) Then
                Me.color_3 = value
                Me.method_2()
            End If
        End Set
    End Property

    Public Property InsetPercent As Integer
        Get
            Return Me.int_3
        End Get
        Set(ByVal value As Integer)
            Me.int_3 = Math.Min(Math.Max(0, value), 45)
            Me.method_1()
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property NumberOfDigits As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.int_0) Then
                Me.int_0 = Math.Max(Math.Min(50, value), 1)
                Me.method_1()
                Me.method_2()
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property ResolutionOfLastDigit As Decimal
        Get
            Return Me.decimal_0
        End Get
        Set(ByVal value As Decimal)
            If (Decimal.Compare(value, Decimal.Zero) <> 0) Then
                Me.decimal_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property ShowOffSegments As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_0 <> value) Then
                Me.bool_0 = value
                Me.method_2()
            End If
        End Set
    End Property

    Public Property TextCenterLocation As Point
        Get
            Return Me.point_7
        End Get
        Set(ByVal value As Point)
            Me.point_7 = value
            MyBase.Invalidate()
        End Set
    End Property

    Public Property TextForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If (value <> MyBase.ForeColor) Then
                MyBase.ForeColor = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property Value As Double
        Get
            Return Me.double_2
        End Get
        Set(ByVal value As Double)
            If (value <> Me.double_2) Then
                Me.double_2 = value
                MyBase.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        ReDim Me.point_0(11)
        ReDim Me.point_1(11)
        ReDim Me.point_2(11)
        ReDim Me.point_3(11)
        ReDim Me.point_4(6)
        ReDim Me.point_5(16)
        ReDim Me.point_6(16)
        ReDim Me.bitmap_0(11)
        ReDim Me.bitmap_1(11)
        ReDim Me.bitmap_2(11)
        Me.color_1 = Color.White
        Me.color_2 = Color.Red
        Me.color_3 = Color.Yellow
        Me.double_0 = 999999
        Me.double_1 = -999999
        Me.decimal_0 = Decimal.One
        Me.int_0 = 5
        Me.int_1 = 0
        Me.bool_0 = True
        Me.int_4 = 340
        Me.double_3 = 486 / (CDbl((340 * Me.int_0)) * 1.1)

        MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.method_3()
        MyBase.BackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        Me.method_1()

    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                Dim length As Integer = CInt(Me.bitmap_0.Length) - 1
                Dim num As Integer = 0
                Do
                    If (Me.bitmap_0(num) IsNot Nothing) Then
                        Me.bitmap_0(num).Dispose()
                    End If
                    If (Me.bitmap_2(num) IsNot Nothing) Then
                        Me.bitmap_2(num).Dispose()
                    End If
                    num = num + 1
                Loop While num <= length
                If (Me.bitmap_5 IsNot Nothing) Then
                    Me.bitmap_5.Dispose()
                End If
                If (Me.bitmap_4 IsNot Nothing) Then
                    Me.bitmap_4.Dispose()
                End If
                If (Me.bitmap_3 IsNot Nothing) Then
                    Me.bitmap_3.Dispose()
                End If
                If (Me.bitmap_6 IsNot Nothing) Then
                    Me.bitmap_6.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub method_0(ByVal sender As Object, ByVal e As EventArgs)
        If (Not Me.bool_1 AndAlso MyBase.Height <> Me.int_6 Or MyBase.Width <> Me.int_5) Then
            Me.bool_1 = True
            Me.method_1()
            Me.int_5 = MyBase.Width
            Me.int_6 = MyBase.Height
            Me.bool_1 = False
            Me.method_2()
        End If
    End Sub

    Private Sub method_1()
        Me.double_3 = 486 / (CDbl((340 * Me.int_0)) * 1.1)
        Me.int_2 = Math.Max(CInt(Math.Round(CDbl((MyBase.Height * Me.int_3)) / 200)), CInt(Math.Round(CDbl((MyBase.Width * Me.int_3)) / 200)))
        If (Me.int_6 < MyBase.Height Or Me.int_5 < MyBase.Width) Then
            If (CDbl((MyBase.Height - Me.int_2 * 2)) / CDbl((MyBase.Width - Me.int_2 * 2)) <= Me.double_3) Then
                MyBase.Height = CInt(Math.Round(CDbl((MyBase.Width - Me.int_2 * 2)) * Me.double_3)) + Me.int_2 * 2
            Else
                MyBase.Width = CInt(Math.Round(CDbl((MyBase.Height - Me.int_2 * 2)) / Me.double_3)) + Me.int_2 * 2
            End If
        ElseIf (CDbl((MyBase.Height - Me.int_2 * 2)) / CDbl((MyBase.Width - Me.int_2 * 2)) <= Me.double_3) Then
            MyBase.Width = CInt(Math.Round(CDbl((MyBase.Height - Me.int_2 * 2)) / Me.double_3)) + Me.int_2 * 2
        Else
            MyBase.Height = CInt(Math.Round(CDbl((MyBase.Width - Me.int_2 * 2)) * Me.double_3)) + Me.int_2 * 2
        End If
    End Sub

    Private Sub method_2()
        Me.double_3 = 486 / (CDbl((340 * Me.int_0)) * 1.1)
        Dim width As Single = CSng((CDbl((MyBase.Width - Me.int_2 * 2)) / (CDbl((340 * Me.int_0)) * 1.1)))
        Dim height As Single = CSng((CDbl((MyBase.Height - Me.int_2 * 2)) / 486))
        If (width >= height) Then
            Me.float_0 = height
        Else
            Me.float_0 = width
        End If
        If (Me.float_0 > 0!) Then
            Dim num As Integer = Convert.ToInt32(340! * Me.float_0)
            Dim num1 As Integer = Convert.ToInt32(486! * Me.float_0)
            Dim num2 As Integer = 0
            Do
                If (Me.bitmap_0(num2) IsNot Nothing) Then
                    Me.bitmap_0(num2).Dispose()
                End If
                Me.bitmap_0(num2) = New Bitmap(num, num1)
                Using graphic As Graphics = Graphics.FromImage(Me.bitmap_0(num2))
                    graphic.ScaleTransform(CSng((CDbl(num) / 700)), CSng((CDbl(num) / 700)))
                    SevenSegment2.smethod_7(graphic, num2, Me.color_2, Me.bool_0)
                End Using
                num2 = num2 + 1
            Loop While num2 <= 11
            Dim num3 As Integer = 0
            Do
                If (Me.bitmap_1(num3) IsNot Nothing) Then
                    Me.bitmap_1(num3).Dispose()
                End If
                Me.bitmap_1(num3) = New Bitmap(num, num1)
                Using graphic1 As Graphics = Graphics.FromImage(Me.bitmap_1(num3))
                    graphic1.ScaleTransform(CSng((CDbl(num) / 700)), CSng((CDbl(num) / 700)))
                    SevenSegment2.smethod_7(graphic1, num3, Me.color_1, Me.bool_0)
                End Using
                num3 = num3 + 1
            Loop While num3 <= 11
            Dim num4 As Integer = 0
            Do
                If (Me.bitmap_2(num4) IsNot Nothing) Then
                    Me.bitmap_2(num4).Dispose()
                End If
                Me.bitmap_2(num4) = New Bitmap(num, num1)
                Using graphic2 As Graphics = Graphics.FromImage(Me.bitmap_2(num4))
                    graphic2.ScaleTransform(CSng((CDbl(num) / 700)), CSng((CDbl(num) / 700)))
                    SevenSegment2.smethod_7(graphic2, num4, Me.ForeColorUnderLowLimit, Me.bool_0)
                End Using
                num4 = num4 + 1
            Loop While num4 <= 11
            Me.bitmap_3 = New Bitmap(Convert.ToInt32(75! * Me.float_0), Convert.ToInt32(75! * Me.float_0))
            Dim point() As System.Drawing.Point = {New System.Drawing.Point(CInt(Math.Round(CDbl(Me.bitmap_3.Width) / 2)), 0), New System.Drawing.Point(Me.bitmap_3.Width, CInt(Math.Round(CDbl(Me.bitmap_3.Height) / 2))), New System.Drawing.Point(CInt(Math.Round(CDbl(Me.bitmap_3.Width) / 2)), Me.bitmap_3.Height), New System.Drawing.Point(0, CInt(Math.Round(CDbl(Me.bitmap_3.Height) / 2))), New System.Drawing.Point(CInt(Math.Round(CDbl(Me.bitmap_3.Width) / 2)), 0)}
            Using graphic3 As Graphics = Graphics.FromImage(Me.bitmap_3)
                Using solidBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.color_2)
                    graphic3.FillPolygon(solidBrush, point)
                End Using
            End Using
            Me.bitmap_5 = New Bitmap(Convert.ToInt32(75! * Me.float_0), Convert.ToInt32(75! * Me.float_0))
            Using graphic4 As Graphics = Graphics.FromImage(Me.bitmap_5)
                Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.color_3)
                    graphic4.FillPolygon(solidBrush1, point)
                End Using
            End Using
            Me.bitmap_4 = New Bitmap(Convert.ToInt32(75! * Me.float_0), Convert.ToInt32(75! * Me.float_0))
            Using graphic5 As Graphics = Graphics.FromImage(Me.bitmap_4)
                Using solidBrush2 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Me.color_1)
                    graphic5.FillPolygon(solidBrush2, point)
                End Using
            End Using
            If (Me.bitmap_6 IsNot Nothing) Then
                Me.bitmap_6.Dispose()
            End If
            Me.bitmap_6 = New Bitmap(MyBase.Width, MyBase.Height)
            MyBase.Invalidate()
        End If
    End Sub

    Private Sub method_3()
        Me.point_0(0) = New Point(75, 110)
        Me.point_0(1) = New Point(47, 415)
        Me.point_0(2) = New Point(98, 471)
        Me.point_0(3) = New Point(157, 417)
        Me.point_0(4) = New Point(182, 125)
        Me.point_0(5) = New Point(88, 21)
        Me.point_0(6) = New Point(88, 21)
        Me.point_0(7) = New Point(85, 27)
        Me.point_0(8) = New Point(82, 32)
        Me.point_0(9) = New Point(80, 38)
        Me.point_0(10) = New Point(79, 44)
        Me.point_0(11) = New Point(74, 110)
        Me.point_1(0) = New Point(580, 471)
        Me.point_1(1) = New Point(641, 415)
        Me.point_1(2) = New Point(668, 110)
        Me.point_1(3) = New Point(673, 44)
        Me.point_1(4) = New Point(673, 44)
        Me.point_1(5) = New Point(674, 38)
        Me.point_1(6) = New Point(673, 31)
        Me.point_1(7) = New Point(671, 26)
        Me.point_1(8) = New Point(669, 20)
        Me.point_1(9) = New Point(557, 123)
        Me.point_1(10) = New Point(531, 417)
        Me.point_1(11) = New Point(580, 471)
        Me.point_2(0) = New Point(96, 499)
        Me.point_2(1) = New Point(35, 555)
        Me.point_2(2) = New Point(8, 858)
        Me.point_2(3) = New Point(3, 924)
        Me.point_2(4) = New Point(3, 924)
        Me.point_2(5) = New Point(2, 930)
        Me.point_2(6) = New Point(3, 937)
        Me.point_2(7) = New Point(5, 942)
        Me.point_2(8) = New Point(7, 948)
        Me.point_2(9) = New Point(119, 845)
        Me.point_2(10) = New Point(145, 553)
        Me.point_2(11) = New Point(96, 499)
        Me.point_3(0) = New Point(602, 858)
        Me.point_3(1) = New Point(629, 555)
        Me.point_3(2) = New Point(578, 499)
        Me.point_3(3) = New Point(519, 553)
        Me.point_3(4) = New Point(493, 847)
        Me.point_3(5) = New Point(586, 949)
        Me.point_3(6) = New Point(586, 949)
        Me.point_3(7) = New Point(590, 943)
        Me.point_3(8) = New Point(593, 937)
        Me.point_3(9) = New Point(595, 931)
        Me.point_3(10) = New Point(597, 924)
        Me.point_3(11) = New Point(602, 858)
        Me.point_4(0) = New Point(515, 430)
        Me.point_4(1) = New Point(171, 430)
        Me.point_4(2) = New Point(111, 485)
        Me.point_4(3) = New Point(161, 540)
        Me.point_4(4) = New Point(505, 540)
        Me.point_4(5) = New Point(565, 485)
        Me.point_4(6) = New Point(515, 430)
        Me.point_5(0) = New Point(475, 858)
        Me.point_5(1) = New Point(133, 858)
        Me.point_5(2) = New Point(21, 962)
        Me.point_5(3) = New Point(21, 962)
        Me.point_5(4) = New Point(26, 965)
        Me.point_5(5) = New Point(31, 966)
        Me.point_5(6) = New Point(37, 968)
        Me.point_5(7) = New Point(43, 968)
        Me.point_5(8) = New Point(109, 968)
        Me.point_5(9) = New Point(483, 968)
        Me.point_5(10) = New Point(549, 968)
        Me.point_5(11) = New Point(549, 968)
        Me.point_5(12) = New Point(554, 968)
        Me.point_5(13) = New Point(560, 967)
        Me.point_5(14) = New Point(565, 965)
        Me.point_5(15) = New Point(570, 962)
        Me.point_5(16) = New Point(475, 858)
        Me.point_6(0) = New Point(192, 110)
        Me.point_6(1) = New Point(543, 110)
        Me.point_6(2) = New Point(655, 6)
        Me.point_6(3) = New Point(655, 6)
        Me.point_6(4) = New Point(650, 4)
        Me.point_6(5) = New Point(645, 2)
        Me.point_6(6) = New Point(639, 0)
        Me.point_6(7) = New Point(633, 0)
        Me.point_6(8) = New Point(567, 0)
        Me.point_6(9) = New Point(193, 0)
        Me.point_6(10) = New Point(127, 0)
        Me.point_6(11) = New Point(127, 0)
        Me.point_6(12) = New Point(121, 0)
        Me.point_6(13) = New Point(115, 2)
        Me.point_6(14) = New Point(109, 4)
        Me.point_6(15) = New Point(103, 7)
        Me.point_6(16) = New Point(197, 110)
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim flag As Boolean = False
        If (Me.bitmap_6 IsNot Nothing) Then
            Using graphic As Graphics = Graphics.FromImage(Me.bitmap_6)
                graphic.Clear(Me.BackColor)
                If (Me.BackgroundImage IsNot Nothing) Then
                    If (Me.BackgroundImageLayout <> ImageLayout.Stretch) Then
                        graphic.DrawImage(Me.BackgroundImage, 0, 0)
                    Else
                        graphic.DrawImage(Me.BackgroundImage, 0, 0, MyBase.Width, MyBase.Height)
                    End If
                End If
                Dim double2 As Double = Me.double_2 * Math.Pow(10, CDbl(Me.int_1))
                If (Decimal.Compare(Me.decimal_0, Decimal.Zero) <> 0) Then
                    double2 = Convert.ToDouble(Decimal.Multiply(New Decimal(CInt(Math.Round(double2 / Convert.ToDouble(Me.decimal_0)))), Me.decimal_0))
                End If
                Dim double21 As Boolean = Me.double_2 >= Me.double_1
                Dim flag1 As Boolean = Me.double_2 >= Me.double_0
                If (Not (double2 < Math.Pow(10, CDbl(Me.int_0)) And double2 > -Math.Pow(10, CDbl((Me.int_0 - 1))))) Then
                    Dim int0 As Integer = Me.int_0
                    For i As Integer = 1 To int0 Step 1
                        graphic.DrawImage(Me.bitmap_2(11), CInt(Math.Round(CDbl((CSng((Me.int_4 * (i - 1))) * Me.float_0)) * 1.1)) + Me.int_2, Me.int_2)
                    Next

                Else
                    Dim num As Integer = Me.int_0
                    Dim num1 As Integer = 1
                    Do
                        If (double2 >= 0) Then
                            Dim num2 As Integer = Convert.ToInt32(Math.Floor(double2 / Math.Pow(10, CDbl((Me.int_0 - num1)))))
                            If (num2 > 0 Or num1 = Me.int_0 Or num1 > Me.int_0 - Me.int_1) Then
                                flag = True
                            End If
                            If (flag) Then
                                If (flag1) Then
                                    graphic.DrawImage(Me.bitmap_0(num2), CSng(Convert.ToInt32(CDbl((Me.int_4 * (num1 - 1))) * 1.1)) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                                ElseIf (Not double21) Then
                                    graphic.DrawImage(Me.bitmap_2(num2), CSng(Convert.ToInt32(CDbl((Me.int_4 * (num1 - 1))) * 1.1)) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                                Else
                                    graphic.DrawImage(Me.bitmap_1(num2), CSng(Convert.ToInt32(CDbl((Me.int_4 * (num1 - 1))) * 1.1)) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                                End If
                            ElseIf (flag1) Then
                                graphic.DrawImage(Me.bitmap_0(10), CSng(Convert.ToInt32(CDbl((Me.int_4 * (num1 - 1))) * 1.1)) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                            ElseIf (Not double21) Then
                                graphic.DrawImage(Me.bitmap_2(10), CSng(Convert.ToInt32(CDbl((Me.int_4 * (num1 - 1))) * 1.1)) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                            Else
                                graphic.DrawImage(Me.bitmap_1(10), CSng(Convert.ToInt32(CDbl((Me.int_4 * (num1 - 1))) * 1.1)) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                            End If
                            double2 = double2 - CDbl(num2) * Math.Pow(10, CDbl((Me.int_0 - num1)))
                        Else
                            If (flag1) Then
                                graphic.DrawImage(Me.bitmap_0(11), CSng((Me.int_4 * (num1 - 1))) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                            ElseIf (Not double21) Then
                                graphic.DrawImage(Me.bitmap_2(11), CSng((Me.int_4 * (num1 - 1))) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                            Else
                                graphic.DrawImage(Me.bitmap_1(11), CSng((Me.int_4 * (num1 - 1))) * Me.float_0 + CSng(Me.int_2), CSng(Me.int_2))
                            End If
                            double2 = Math.Abs(double2)
                        End If
                        num1 = num1 + 1
                    Loop While num1 <= num
                    If (Me.int_1 > 0) Then
                        If (flag1) Then
                            graphic.DrawImage(Me.bitmap_3, CSng((Convert.ToInt32(CDbl((CSng(((Me.int_0 - Me.int_1) * Me.int_4 - 70)) * Me.float_0)) * 1.1) + Me.int_2)), 400! * Me.float_0 + CSng(Me.int_2))
                        ElseIf (Not double21) Then
                            graphic.DrawImage(Me.bitmap_5, CSng((Convert.ToInt32(CDbl((CSng(((Me.int_0 - Me.int_1) * Me.int_4 - 70)) * Me.float_0)) * 1.1) + Me.int_2)), 400! * Me.float_0 + CSng(Me.int_2))
                        Else
                            graphic.DrawImage(Me.bitmap_4, CSng((Convert.ToInt32(CDbl((CSng(((Me.int_0 - Me.int_1) * Me.int_4 - 70)) * Me.float_0)) * 1.1) + Me.int_2)), 400! * Me.float_0 + CSng(Me.int_2))
                        End If
                    End If
                End If
                If (Not String.IsNullOrEmpty(Me.Text)) Then
                    Dim sizeF As System.Drawing.SizeF = graphic.MeasureString(Me.Text, Me.Font)
                    Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(CInt(Math.Round(CDbl((CSng(Me.point_7.X) - sizeF.Width / 2!)))), CInt(Math.Round(CDbl((CSng(Me.point_7.Y) - sizeF.Height / 2!)))), CInt(Math.Ceiling(CDbl(sizeF.Width))), CInt(Math.Ceiling(CDbl((sizeF.Height + 2!)))))
                    graphic.DrawString(Me.Text, Me.Font, New SolidBrush(MyBase.ForeColor), rectangle)
                End If
                If (If(painte Is Nothing, False, painte.Graphics IsNot Nothing)) Then
                    painte.Graphics.DrawImage(Me.bitmap_6, 0, 0)
                End If
            End Using
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If (Me.bitmap_6 IsNot Nothing) Then
            Me.bitmap_6.Dispose()
            Me.bitmap_6 = Nothing
        End If
        Me.method_0(Me, Nothing)
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        MyBase.Invalidate()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Friend Shared Function smethod_0() As System.Drawing.Point()
        Dim point() As System.Drawing.Point = {New System.Drawing.Point(75, 110), New System.Drawing.Point(47, 415), New System.Drawing.Point(98, 471), New System.Drawing.Point(157, 417), New System.Drawing.Point(182, 125), New System.Drawing.Point(88, 21), New System.Drawing.Point(88, 21), New System.Drawing.Point(85, 27), New System.Drawing.Point(82, 32), New System.Drawing.Point(80, 38), New System.Drawing.Point(79, 44), New System.Drawing.Point(74, 110)}
        Return point
    End Function

    Friend Shared Function smethod_1() As System.Drawing.Point()
        Dim point() As System.Drawing.Point = {New System.Drawing.Point(580, 471), New System.Drawing.Point(641, 415), New System.Drawing.Point(668, 110), New System.Drawing.Point(673, 44), New System.Drawing.Point(673, 44), New System.Drawing.Point(674, 38), New System.Drawing.Point(673, 31), New System.Drawing.Point(671, 26), New System.Drawing.Point(669, 20), New System.Drawing.Point(557, 123), New System.Drawing.Point(531, 417), New System.Drawing.Point(580, 471)}
        Return point
    End Function

    Friend Shared Function smethod_2() As System.Drawing.Point()
        Dim point() As System.Drawing.Point = {New System.Drawing.Point(96, 499), New System.Drawing.Point(35, 555), New System.Drawing.Point(8, 858), New System.Drawing.Point(3, 924), New System.Drawing.Point(3, 924), New System.Drawing.Point(2, 930), New System.Drawing.Point(3, 937), New System.Drawing.Point(5, 942), New System.Drawing.Point(7, 948), New System.Drawing.Point(119, 845), New System.Drawing.Point(145, 553), New System.Drawing.Point(96, 499)}
        Return point
    End Function

    Friend Shared Function smethod_3() As System.Drawing.Point()
        Dim point() As System.Drawing.Point = {New System.Drawing.Point(602, 858), New System.Drawing.Point(629, 555), New System.Drawing.Point(578, 499), New System.Drawing.Point(519, 553), New System.Drawing.Point(493, 847), New System.Drawing.Point(586, 949), New System.Drawing.Point(586, 949), New System.Drawing.Point(590, 943), New System.Drawing.Point(593, 937), New System.Drawing.Point(595, 931), New System.Drawing.Point(597, 924), New System.Drawing.Point(602, 858)}
        Return point
    End Function

    Friend Shared Function smethod_4() As System.Drawing.Point()
        Dim point() As System.Drawing.Point = {New System.Drawing.Point(515, 430), New System.Drawing.Point(171, 430), New System.Drawing.Point(111, 485), New System.Drawing.Point(161, 540), New System.Drawing.Point(505, 540), New System.Drawing.Point(565, 485), New System.Drawing.Point(515, 430)}
        Return point
    End Function

    Friend Shared Function smethod_5() As System.Drawing.Point()
        Dim point() As System.Drawing.Point = {New System.Drawing.Point(475, 858), New System.Drawing.Point(133, 858), New System.Drawing.Point(21, 962), New System.Drawing.Point(21, 962), New System.Drawing.Point(26, 965), New System.Drawing.Point(31, 966), New System.Drawing.Point(37, 968), New System.Drawing.Point(43, 968), New System.Drawing.Point(109, 968), New System.Drawing.Point(483, 968), New System.Drawing.Point(549, 968), New System.Drawing.Point(549, 968), New System.Drawing.Point(554, 968), New System.Drawing.Point(560, 967), New System.Drawing.Point(565, 965), New System.Drawing.Point(570, 962), New System.Drawing.Point(475, 858)}
        Return point
    End Function

    Friend Shared Function smethod_6() As System.Drawing.Point()
        Dim point() As System.Drawing.Point = {New System.Drawing.Point(192, 110), New System.Drawing.Point(543, 110), New System.Drawing.Point(655, 6), New System.Drawing.Point(655, 6), New System.Drawing.Point(650, 4), New System.Drawing.Point(645, 2), New System.Drawing.Point(639, 0), New System.Drawing.Point(633, 0), New System.Drawing.Point(567, 0), New System.Drawing.Point(193, 0), New System.Drawing.Point(127, 0), New System.Drawing.Point(127, 0), New System.Drawing.Point(121, 0), New System.Drawing.Point(115, 2), New System.Drawing.Point(109, 4), New System.Drawing.Point(103, 7), New System.Drawing.Point(197, 110)}
        Return point
    End Function

    Friend Shared Sub smethod_7(ByVal graphics_0 As Graphics, ByVal int_7 As Integer, ByVal color_4 As Color, ByVal bool_2 As Boolean)
        Using solidBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(color_4)
            Using solidBrush1 As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.FromArgb(40, CInt(color_4.R), CInt(color_4.G), CInt(color_4.B)))
                graphics_0.CompositingQuality = CompositingQuality.HighQuality
                graphics_0.SmoothingMode = SmoothingMode.AntiAlias
                If (int_7 = 0 Or int_7 = 4 Or int_7 = 5 Or int_7 = 6 Or int_7 = 8 Or int_7 = 9) Then
                    graphics_0.FillPolygon(solidBrush, SevenSegment2.smethod_0())
                ElseIf (bool_2) Then
                    graphics_0.FillPolygon(solidBrush1, SevenSegment2.smethod_0())
                End If
                If (Not (int_7 = 5 Or int_7 = 6 Or int_7 = 10 Or int_7 = 11)) Then
                    graphics_0.FillPolygon(solidBrush, SevenSegment2.smethod_1())
                ElseIf (bool_2) Then
                    graphics_0.FillPolygon(solidBrush1, SevenSegment2.smethod_1())
                End If
                If (int_7 = 0 Or int_7 = 2 Or int_7 = 6 Or int_7 = 8) Then
                    graphics_0.FillPolygon(solidBrush, SevenSegment2.smethod_2())
                ElseIf (bool_2) Then
                    graphics_0.FillPolygon(solidBrush1, SevenSegment2.smethod_2())
                End If
                If (Not (int_7 = 2 Or int_7 = 10 Or int_7 = 11)) Then
                    graphics_0.FillPolygon(solidBrush, SevenSegment2.smethod_3())
                ElseIf (bool_2) Then
                    graphics_0.FillPolygon(solidBrush1, SevenSegment2.smethod_3())
                End If
                If (Not (int_7 = 0 Or int_7 = 1 Or int_7 = 7 Or int_7 = 10)) Then
                    graphics_0.FillPolygon(solidBrush, SevenSegment2.smethod_4())
                ElseIf (bool_2) Then
                    graphics_0.FillPolygon(solidBrush1, SevenSegment2.smethod_4())
                End If
                If (Not (int_7 = 1 Or int_7 = 4 Or int_7 = 7 Or int_7 = 9 Or int_7 = 10 Or int_7 = 11)) Then
                    graphics_0.FillPolygon(solidBrush, SevenSegment2.smethod_5())
                ElseIf (bool_2) Then
                    graphics_0.FillPolygon(solidBrush1, SevenSegment2.smethod_5())
                End If
                If (Not (int_7 = 1 Or int_7 = 4 Or int_7 = 10 Or int_7 = 11)) Then
                    graphics_0.FillPolygon(solidBrush, SevenSegment2.smethod_6())
                ElseIf (bool_2) Then
                    graphics_0.FillPolygon(solidBrush1, SevenSegment2.smethod_6())
                End If
            End Using
        End Using
    End Sub

    Public Event ValueChanged As EventHandler

End Class
