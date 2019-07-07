Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<DefaultEvent("")>
Public Class TempController
    Inherits Control
    Private bitmap_0 As Bitmap

    Private bitmap_1 As Bitmap()

    Private bitmap_2 As Bitmap()

    Private bitmap_3 As Bitmap

    Private bitmap_4 As Bitmap

    Private bitmap_5 As Bitmap

    Private bitmap_6 As Bitmap

    Private bitmap_7 As Bitmap

    Private bitmap_8 As Bitmap

    Private bitmap_9 As Bitmap

    Private bitmap_10 As Bitmap

    Private bitmap_11 As Bitmap

    Private bitmap_12 As Bitmap

    Private bitmap_13 As Bitmap

    Private bitmap_14 As Bitmap

    Private bitmap_15 As Bitmap

    Private float_0 As Single

    Private rectangle_0 As Rectangle

    Private stringFormat_0 As StringFormat

    Private solidBrush_0 As SolidBrush

    Private float_1 As Single

    Private decimal_0 As Decimal

    Private float_2 As Single

    Private decimal_1 As Decimal

    Private string_0 As String

    Private string_1 As String

    Private string_2 As String

    Private int_0 As Integer

    Private int_1 As Integer

    Private int_2 As Integer

    Private bitmap_16 As Bitmap

    Private int_3 As Integer

    Private int_4 As Integer

    Private float_3 As Single

    Public Property Button1Text As String
        Get
            Return Me.string_1
        End Get
        Set(ByVal value As String)
            If (Operators.CompareString(Me.string_1, value, False) <> 0) Then
                Me.string_1 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property Button2Text As String
        Get
            Return Me.string_2
        End Get
        Set(ByVal value As String)
            If (Operators.CompareString(Me.string_2, value, False) <> 0) Then
                Me.string_2 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams
        Get
            Dim exStyle As System.Windows.Forms.CreateParams = MyBase.CreateParams
            exStyle.ExStyle = exStyle.ExStyle Or 32
            Return exStyle
        End Get
    End Property

    Public Property DecimalPosition As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            Me.int_1 = Math.Max(Math.Min(Me.int_0 - 1, value), 0)
            Me.method_0()
            MyBase.Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Font As System.Drawing.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As System.Drawing.Font)
            MyBase.Font = value
            MyBase.Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If (Me.solidBrush_0 IsNot Nothing) Then
                Me.solidBrush_0.Color = value
            Else
                Me.solidBrush_0 = New SolidBrush(value)
            End If
            MyBase.ForeColor = value
            MyBase.Invalidate()
        End Set
    End Property

    Public Property Value_ValueScaleFactor As Decimal
        Get
            Return Me.decimal_0
        End Get
        Set(ByVal value As Decimal)
            Me.decimal_0 = value
            MyBase.Invalidate(New Rectangle(CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.08)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.19)), CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.65)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.4))))
        End Set
    End Property

    Public Property Value_ValueScaleFactorSP As Decimal
        Get
            Return Me.decimal_1
        End Get
        Set(ByVal value As Decimal)
            Me.decimal_1 = value
            MyBase.Invalidate(New Rectangle(CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.08)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.19)), CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.65)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.4))))
        End Set
    End Property

    Public Property Value2Text As String
        Get
            Return Me.string_0
        End Get
        Set(ByVal value As String)
            If (Operators.CompareString(Me.string_0, value, False) <> 0) Then
                Me.string_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property ValuePV As Single
        Get
            Return Me.float_1
        End Get
        Set(ByVal value As Single)
            If (value <> Me.float_1) Then
                Me.float_1 = value
                MyBase.Invalidate(New Rectangle(CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.08)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.1)), CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.85)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.7))))
            End If
        End Set
    End Property

    Public Property ValueSP As Single
        Get
            Return Me.float_2
        End Get
        Set(ByVal value As Single)
            If (value <> Me.float_2) Then
                Me.float_2 = value
                MyBase.Invalidate(New Rectangle(CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.08)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.1)), CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.85)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.8))))
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        AddHandler MyBase.MouseDown, New MouseEventHandler(AddressOf Me.TempController_MouseDown)
        AddHandler MyBase.MouseUp, New MouseEventHandler(AddressOf Me.TempController_MouseUp)
        AddHandler MyBase.Resize, New EventHandler(AddressOf Me.TempController_Resize)
        ReDim Me.bitmap_1(11)
        ReDim Me.bitmap_2(11)
        Me.rectangle_0 = New Rectangle()
        Me.stringFormat_0 = New StringFormat()
        Me.decimal_0 = Decimal.One
        Me.decimal_1 = Decimal.One
        Me.string_0 = "SP"
        Me.int_0 = 5
        Me.int_1 = 0
        Me.int_2 = 98
        Me.float_3 = CSng((CDbl(My.Resources.TempController.Height) / CDbl(My.Resources.TempController.Width)))
        If ((MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0))) Then
            Me.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub method_0()
        Dim width As Single = CSng((CDbl(MyBase.Width) / CDbl(My.Resources.TempController.Width)))
        Dim height As Single = CSng((CDbl(MyBase.Height) / CDbl(My.Resources.TempController.Height)))
        If (width >= height) Then
            Me.float_0 = height
        Else
            Me.float_0 = width
        End If
        If (Me.float_0 > 0!) Then
            If (Me.bitmap_0 IsNot Nothing) Then
                Me.bitmap_0.Dispose()
            End If
            Me.bitmap_0 = New Bitmap(Convert.ToInt32(CSng(My.Resources.TempController.Width) * Me.float_0), Convert.ToInt32(CSng(My.Resources.TempController.Height) * Me.float_0))
            Dim graphic As Graphics = Graphics.FromImage(Me.bitmap_0)
            graphic.DrawImage(My.Resources.TempController, 0, 0, Me.bitmap_0.Width, Me.bitmap_0.Height)
            Me.bitmap_5 = New Bitmap(Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton1.Width) * Me.float_0)))), Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton1.Height) * Me.float_0)))))
            Me.bitmap_8 = New Bitmap(Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton2.Width) * Me.float_0)))), Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton1.Height) * Me.float_0)))))
            Me.bitmap_11 = New Bitmap(Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton3.Width) * Me.float_0)))), Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton1.Height) * Me.float_0)))))
            Me.bitmap_14 = New Bitmap(Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton4.Width) * Me.float_0)))), Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton1.Height) * Me.float_0)))))
            Me.bitmap_6 = New Bitmap(Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton1Pressed.Width) * Me.float_0)))), Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton1Pressed.Height) * Me.float_0)))))
            Me.bitmap_9 = New Bitmap(Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton2Pressed.Width) * Me.float_0)))), Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton2Pressed.Height) * Me.float_0)))))
            Me.bitmap_12 = New Bitmap(Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton3Pressed.Width) * Me.float_0)))), Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton3Pressed.Height) * Me.float_0)))))
            Me.bitmap_15 = New Bitmap(Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton4Pressed.Width) * Me.float_0)))), Convert.ToInt32(Math.Ceiling(CDbl((CSng(My.Resources.TempControllerButton4Pressed.Height) * Me.float_0)))))
            graphic = Graphics.FromImage(Me.bitmap_5)
            graphic.DrawImage(My.Resources.TempControllerButton1, 0!, 0!, CSng(My.Resources.TempControllerButton1.Width) * Me.float_0, CSng(My.Resources.TempControllerButton1.Height) * Me.float_0)
            graphic = Graphics.FromImage(Me.bitmap_8)
            graphic.DrawImage(My.Resources.TempControllerButton2, 0!, 0!, CSng(My.Resources.TempControllerButton2.Width) * Me.float_0, CSng(My.Resources.TempControllerButton2.Height) * Me.float_0)
            graphic = Graphics.FromImage(Me.bitmap_11)
            graphic.DrawImage(My.Resources.TempControllerButton3, 0!, 0!, CSng(My.Resources.TempControllerButton3.Width) * Me.float_0, CSng(My.Resources.TempControllerButton3.Height) * Me.float_0)
            graphic = Graphics.FromImage(Me.bitmap_14)
            graphic.DrawImage(My.Resources.TempControllerButton4, 0!, 0!, CSng(My.Resources.TempControllerButton4.Width) * Me.float_0, CSng(My.Resources.TempControllerButton4.Height) * Me.float_0)
            graphic = Graphics.FromImage(Me.bitmap_6)
            graphic.DrawImage(My.Resources.TempControllerButton1Pressed, 0!, 0!, CSng(My.Resources.TempControllerButton1Pressed.Width) * Me.float_0, CSng(My.Resources.TempControllerButton1Pressed.Height) * Me.float_0)
            graphic = Graphics.FromImage(Me.bitmap_9)
            graphic.DrawImage(My.Resources.TempControllerButton2Pressed, 0!, 0!, CSng(My.Resources.TempControllerButton2Pressed.Width) * Me.float_0, CSng(My.Resources.TempControllerButton2Pressed.Height) * Me.float_0)
            graphic = Graphics.FromImage(Me.bitmap_12)
            graphic.DrawImage(My.Resources.TempControllerButton3Pressed, 0!, 0!, CSng(My.Resources.TempControllerButton3Pressed.Width) * Me.float_0, CSng(My.Resources.TempControllerButton3Pressed.Height) * Me.float_0)
            graphic = Graphics.FromImage(Me.bitmap_15)
            graphic.DrawImage(My.Resources.TempControllerButton4Pressed, 0!, 0!, CSng(My.Resources.TempControllerButton4Pressed.Width) * Me.float_0, CSng(My.Resources.TempControllerButton4Pressed.Height) * Me.float_0)
            Me.bitmap_4 = Me.bitmap_5
            Me.bitmap_7 = Me.bitmap_8
            Me.bitmap_10 = Me.bitmap_11
            Me.bitmap_13 = Me.bitmap_14
            Me.rectangle_0.X = 0
            Me.rectangle_0.Y = CInt(Math.Round(CDbl((30! * Me.float_0))))
            Me.rectangle_0.Width = Me.bitmap_0.Width - 1
            Me.rectangle_0.Height = CInt(Math.Round(CDbl((60! * Me.float_0))))
            Me.stringFormat_0.Alignment = StringAlignment.Center
            Me.stringFormat_0.LineAlignment = StringAlignment.Center
            If (Me.solidBrush_0 Is Nothing) Then
                Me.solidBrush_0 = New SolidBrush(MyBase.ForeColor)
            End If
            Dim num As Integer = Convert.ToInt32(CSng(My.Resources.LED7Segment8Red.Width) * Me.float_0)
            Dim num1 As Integer = Convert.ToInt32(CSng(My.Resources.LED7Segment8Red.Height) * Me.float_0)
            Dim num2 As Integer = 0
            Do
                If (Me.bitmap_1(num2) IsNot Nothing) Then
                    Me.bitmap_1(num2).Dispose()
                End If
                Me.bitmap_1(num2) = New Bitmap(num, num1)
                graphic = Graphics.FromImage(Me.bitmap_1(num2))
                graphic.ScaleTransform(CSng((CDbl(Me.float_0) * 0.95)), CSng((CDbl(Me.float_0) * 0.95)))
                If (Me.bitmap_2(num2) IsNot Nothing) Then
                    Me.bitmap_2(num2).Dispose()
                End If
                Me.bitmap_2(num2) = New Bitmap(num, num1)
                Dim graphic1 As Graphics = Graphics.FromImage(Me.bitmap_2(num2))
                graphic1.ScaleTransform(CSng((CDbl(Me.float_0) * 2.5)), CSng((CDbl(Me.float_0) * 2.5)))
                SevenSegmentGDI.DrawDigit(graphic1, num2, Color.Green, True, 0.04, 0.048)
                Select Case num2
                    Case 0
                        graphic.DrawImage(My.Resources.LED7Segment0Red, 0, 0)
                        Exit Select
                    Case 1
                        graphic.DrawImage(My.Resources.LED7Segment1Red, 0, 0)
                        Exit Select
                    Case 2
                        graphic.DrawImage(My.Resources.LED7Segment2Red, 0, 0)
                        Exit Select
                    Case 3
                        graphic.DrawImage(My.Resources.LED7Segment3Red, 0, 0)
                        Exit Select
                    Case 4
                        graphic.DrawImage(My.Resources.LED7Segment4Red, 0, 0)
                        Exit Select
                    Case 5
                        graphic.DrawImage(My.Resources.LED7Segment5Red, 0, 0)
                        Exit Select
                    Case 6
                        graphic.DrawImage(My.Resources.LED7Segment6Red, 0, 0)
                        Exit Select
                    Case 7
                        graphic.DrawImage(My.Resources.LED7Segment7Red, 0, 0)
                        Exit Select
                    Case 8
                        graphic.DrawImage(My.Resources.LED7Segment8Red, 0, 0)
                        Exit Select
                    Case 9
                        graphic.DrawImage(My.Resources.LED7Segment9Red, 0, 0)
                        Exit Select
                    Case 10
                        graphic.DrawImage(My.Resources.LED7SegmentOffRed, 0, 0)
                        Exit Select
                    Case 11
                        graphic.DrawImage(My.Resources.LED7Segment_Red, 0, 0)
                        Exit Select
                End Select
                graphic.Dispose()
                graphic1.Dispose()
                num2 = num2 + 1
            Loop While num2 <= 11
            Me.bitmap_3 = New Bitmap(Convert.ToInt32(CSng(My.Resources.LED7SegmentDecimalRed.Width) * Me.float_0), Convert.ToInt32(CSng(My.Resources.LED7SegmentDecimalRed.Height) * Me.float_0))
            graphic = Graphics.FromImage(Me.bitmap_3)
            graphic.DrawImage(My.Resources.LED7SegmentDecimalRed, 0, 0)
            If (Me.bitmap_16 IsNot Nothing) Then
                Me.bitmap_16.Dispose()
            End If
            Me.bitmap_16 = New Bitmap(MyBase.Width, MyBase.Height)
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim num As Integer
        Dim flag As Boolean = False
        If (Not (Me.bitmap_0 Is Nothing Or Me.bitmap_16 Is Nothing) And Me.solidBrush_0 IsNot Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me.bitmap_16)
            graphic.DrawImage(Me.bitmap_0, 0, 0)
            graphic.DrawImage(Me.bitmap_4, Convert.ToInt32(CDbl(Me.bitmap_0.Width) * 0.09), Convert.ToInt32(CDbl(Me.bitmap_0.Height) * 0.7))
            graphic.DrawImage(Me.bitmap_7, Convert.ToInt32(CDbl(Me.bitmap_0.Width) * 0.31), Convert.ToInt32(CDbl(Me.bitmap_0.Height) * 0.7))
            graphic.DrawImage(Me.bitmap_10, Convert.ToInt32(CDbl(Me.bitmap_0.Width) * 0.53), Convert.ToInt32(CDbl(Me.bitmap_0.Height) * 0.7))
            graphic.DrawImage(Me.bitmap_13, Convert.ToInt32(CDbl(Me.bitmap_0.Width) * 0.75), Convert.ToInt32(CDbl(Me.bitmap_0.Height) * 0.7))
            Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(Me.bitmap_0.Width) * 0.09), Convert.ToInt32(CDbl(Me.bitmap_0.Height) * 0.7), Me.bitmap_4.Width, Me.bitmap_4.Height)
            Me.stringFormat_0.Alignment = StringAlignment.Center
            Me.stringFormat_0.LineAlignment = StringAlignment.Center
            graphic.DrawString(Me.string_1, Me.Font, Brushes.Brown, rectangle, Me.stringFormat_0)
            rectangle = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(Me.bitmap_0.Width) * 0.31), Convert.ToInt32(CDbl(Me.bitmap_0.Height) * 0.7), Me.bitmap_7.Width, Me.bitmap_7.Height)
            graphic.DrawString(Me.string_2, Me.Font, Brushes.Brown, rectangle, Me.stringFormat_0)
            If (Not String.IsNullOrEmpty(Me.string_0)) Then
                rectangle = New System.Drawing.Rectangle(0, Convert.ToInt32(CDbl(Me.bitmap_0.Height) * 0.45), Convert.ToInt32(CDbl(Me.bitmap_0.Width) * 0.31), Convert.ToInt32(CDbl(Me.bitmap_0.Height) * 0.5))
                Me.stringFormat_0.LineAlignment = StringAlignment.Near
                Me.stringFormat_0.Alignment = StringAlignment.Far
                graphic.DrawString(Me.string_0, Me.Font, Brushes.Brown, rectangle, Me.stringFormat_0)
            End If
            If (Not String.IsNullOrEmpty(MyBase.Text)) Then
                If (Me.solidBrush_0.Color <> MyBase.ForeColor) Then
                    Me.solidBrush_0.Color = MyBase.ForeColor
                End If
                Me.stringFormat_0.Alignment = StringAlignment.Center
                Me.stringFormat_0.LineAlignment = StringAlignment.Center
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.solidBrush_0, Me.rectangle_0, Me.stringFormat_0)
            End If
            Dim num1 As Integer = Convert.ToInt32(Me.float_1 * Convert.ToSingle(Me.decimal_0))
            If (Not (CDbl(num1) <= Math.Pow(10, CDbl(Me.int_0)) - 1 And CDbl(num1) >= (Math.Pow(10, CDbl((Me.int_0 - 1))) - 1) * -1)) Then
                Dim int0 As Integer = Me.int_0
                For i As Integer = 1 To int0 Step 1
                    graphic.DrawImage(Me.bitmap_1(11), CSng((90 + Me.int_2 * (i - 1))) * Me.float_0, 105! * Me.float_0)
                Next

            Else
                Dim int01 As Integer = Me.int_0
                For j As Integer = 1 To int01 Step 1
                    If (num1 >= 0) Then
                        num = Convert.ToInt32(Math.Floor(CDbl(num1) / Math.Pow(10, CDbl((Me.int_0 - j)))))
                        If (num > 0 Or j = Me.int_0 Or j > Me.int_0 - Me.int_1) Then
                            flag = True
                        End If
                        If (Not flag) Then
                            graphic.DrawImage(Me.bitmap_1(10), CSng((90 + Me.int_2 * (j - 1))) * Me.float_0, 105! * Me.float_0)
                        Else
                            graphic.DrawImage(Me.bitmap_1(num), CSng((90 + Me.int_2 * (j - 1))) * Me.float_0, 105! * Me.float_0)
                        End If
                        num1 = CInt(Math.Round(CDbl(num1) - CDbl(num) * Math.Pow(10, CDbl((Me.int_0 - j)))))
                    Else
                        graphic.DrawImage(Me.bitmap_1(11), CSng((90 + Me.int_2 * (j - 1))) * Me.float_0, 105! * Me.float_0)
                        num1 = Math.Abs(num1)
                    End If
                Next

            End If
            If (Me.int_1 > 0) Then
                graphic.DrawImage(Me.bitmap_3, CSng(((Me.int_0 - Me.int_1) * Me.int_2 + 50)) * Me.float_0, 150! * Me.float_0)
            End If
            Dim num2 As Integer = 80
            Dim num3 As Integer = 250
            Dim num4 As Integer = 275
            Dim num5 As Integer = 4
            num = 0
            num1 = CInt(Math.Round(CDbl((Me.float_2 * Convert.ToSingle(Me.decimal_1)))))
            flag = False
            If (Not (CDbl(num1) <= Math.Pow(10, 4!) - 1 And CDbl(num1) >= (Math.Pow(10, 3!) - 1) * -1)) Then
                Dim num6 As Integer = num5
                For k As Integer = 1 To num6 Step 1
                    graphic.DrawImage(Me.bitmap_2(11), CSng((num3 + num2 * (k - 1))) * Me.float_0, CSng(num4) * Me.float_0)
                Next

            Else
                Dim num7 As Integer = num5
                For l As Integer = 1 To num7 Step 1
                    If (num1 >= 0) Then
                        num = Convert.ToInt32(Math.Floor(CDbl(num1) / Math.Pow(10, CDbl((num5 - l)))))
                        If (num > 0 Or l = num5 Or l > num5 - Me.int_1) Then
                            flag = True
                        End If
                        If (Not flag) Then
                            graphic.DrawImage(Me.bitmap_2(10), CSng((num3 + num2 * (l - 1))) * Me.float_0, CSng(num4) * Me.float_0)
                        Else
                            graphic.DrawImage(Me.bitmap_2(num), CSng((num3 + num2 * (l - 1))) * Me.float_0, CSng(num4) * Me.float_0)
                        End If
                        num1 = CInt(Math.Round(CDbl(num1) - CDbl(num) * Math.Pow(10, CDbl((num5 - l)))))
                    Else
                        graphic.DrawImage(Me.bitmap_2(11), CSng((num3 + num2 * (l - 1))) * Me.float_0, CSng(num4) * Me.float_0)
                        num1 = Math.Abs(num1)
                    End If
                Next

            End If
            painte.Graphics.DrawImage(Me.bitmap_16, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        MyBase.Invalidate()
    End Sub

    Private Sub TempController_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If (CDbl(e.Location.Y) > CDbl(Me.bitmap_0.Height) * 0.7) Then
            If (CDbl(e.Location.X) > CDbl(Me.bitmap_0.Width) * 0.1 And CDbl(e.Location.X) < CDbl(Me.bitmap_0.Width) * 0.24) Then
                Me.bitmap_4 = Me.bitmap_6
                MyBase.Invalidate()
                RaiseEvent Button1MouseDown(Me, e)
            End If
            If (CDbl(e.Location.X) > CDbl(Me.bitmap_0.Width) * 0.31 And CDbl(e.Location.X) < CDbl(Me.bitmap_0.Width) * 0.46) Then
                Me.bitmap_7 = Me.bitmap_9
                MyBase.Invalidate()
                RaiseEvent Button1MouseDown(Me, e)
            End If
            If (CDbl(e.Location.X) > CDbl(Me.bitmap_0.Width) * 0.54 And CDbl(e.Location.X) < CDbl(Me.bitmap_0.Width) * 0.69) Then
                Me.bitmap_10 = Me.bitmap_12
                MyBase.Invalidate()
                RaiseEvent Button1MouseDown(Me, e)
            End If
            If (CDbl(e.Location.X) > CDbl(Me.bitmap_0.Width) * 0.76 And CDbl(e.Location.X) < CDbl(Me.bitmap_0.Width) * 0.91) Then
                Me.bitmap_13 = Me.bitmap_15
                MyBase.Invalidate()
                RaiseEvent Button1MouseDown(Me, e)
            End If
        End If
    End Sub

    Private Sub TempController_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        'If (Me.bitmap_4 = Me.bitmap_6) Then
        '    RaiseEvent Button1MouseDown(Me, e)
        'End If
        'If (Me.bitmap_7 = Me.bitmap_9) Then
        '    RaiseEvent Button1MouseDown(Me, e)
        'End If
        'If (Me.bitmap_10 = Me.bitmap_12) Then
        '    RaiseEvent Button1MouseDown(Me, e)
        'End If
        'If (Me.bitmap_13 = Me.bitmap_15) Then
        '    RaiseEvent Button1MouseDown(Me, e)
        'End If
        Me.bitmap_4 = Me.bitmap_5
        Me.bitmap_7 = Me.bitmap_8
        Me.bitmap_10 = Me.bitmap_11
        Me.bitmap_13 = Me.bitmap_14
        MyBase.Invalidate()
    End Sub

    Private Sub TempController_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Me.float_3 = CSng((CDbl(My.Resources.TempController.Height) / CDbl(My.Resources.TempController.Width)))
        If (Me.int_4 < MyBase.Height Or Me.int_3 < MyBase.Width) Then
            If (CDbl(MyBase.Height) / CDbl(MyBase.Width) <= CDbl(Me.float_3)) Then
                MyBase.Height = CInt(Math.Round(CDbl((CSng(MyBase.Width) * Me.float_3))))
            Else
                MyBase.Width = CInt(Math.Round(CDbl((CSng(MyBase.Height) / Me.float_3))))
            End If
        ElseIf (CDbl(MyBase.Height) / CDbl(MyBase.Width) <= CDbl(Me.float_3)) Then
            MyBase.Width = CInt(Math.Round(CDbl((CSng(MyBase.Height) / Me.float_3))))
        Else
            MyBase.Height = CInt(Math.Round(CDbl((CSng(MyBase.Width) * Me.float_3))))
        End If
        Me.int_3 = MyBase.Width
        Me.int_4 = MyBase.Height
        Me.method_0()
    End Sub

    Public Event Button1MouseDown As EventHandler


    Public Event Button1MouseUp As EventHandler


    Public Event Button2MouseDown As EventHandler


    Public Event Button2MouseUp As EventHandler


    Public Event Button3MouseDown As EventHandler

    Public Event Button3MouseUp As EventHandler


    Public Event Button4MouseDown As EventHandler


    Public Event Button4MouseUp As EventHandler

End Class
