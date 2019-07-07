Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<DefaultEvent("")>
Public Class DigitalPanelMeter
    Inherits Control
    Private bitmap_0 As Bitmap

    Private bitmap_1 As Bitmap()

    Private bitmap_2 As Bitmap

    Private float_0 As Single

    Private rectangle_0 As Rectangle

    Private stringFormat_0 As StringFormat

    Private solidBrush_0 As SolidBrush

    Private float_1 As Single

    Private float_2 As Single

    Private double_0 As Double

    Private decimal_0 As Decimal

    Private decimal_1 As Decimal

    Private decimal_2 As Decimal

    Private int_0 As Integer

    Private int_1 As Integer

    Private int_2 As Integer

    Private bitmap_3 As Bitmap

    Private int_3 As Integer

    Private int_4 As Integer

    Private float_3 As Single

    <Category("Numeric Display")>
    Public Property DecimalPosition As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            Me.int_1 = Math.Max(Math.Min(Me.int_0 - 1, value), 0)
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

    <Category("Numeric Display")>
    Public Property NumberOfDigits As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.int_0) Then
                Me.int_0 = Math.Max(Math.Min(6, value), 4)
                Me.method_1()
                Me.method_2()
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property Resolution As Decimal
        Get
            Return Me.decimal_2
        End Get
        Set(ByVal value As Decimal)
            If (Decimal.Compare(value, Decimal.Zero) <> 0) Then
                Me.decimal_2 = value
                If (Me.bitmap_0 IsNot Nothing) Then
                    MyBase.Invalidate()
                End If
            End If
        End Set
    End Property

    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            MyBase.Invalidate()
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property Value As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            If (value <> Me.double_0) Then
                Me.double_0 = value
                MyBase.Invalidate(New Rectangle(CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.08)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.1)), CInt(Math.Round(CDbl(Me.bitmap_0.Width) * 0.85)), CInt(Math.Round(CDbl(Me.bitmap_0.Height) * 0.8))))
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property ValueScaleFactor As Decimal
        Get
            Return Me.decimal_0
        End Get
        Set(ByVal value As Decimal)
            If (Decimal.Compare(Me.decimal_0, value) <> 0) Then
                Me.decimal_0 = value
                MyBase.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property ValueScaleOffset As Decimal
        Get
            Return Me.decimal_1
        End Get
        Set(ByVal value As Decimal)
            If (Decimal.Compare(Me.decimal_1, value) <> 0) Then
                Me.decimal_1 = value
                MyBase.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        ReDim Me.bitmap_1(11)
        Me.rectangle_0 = New Rectangle()
        Me.decimal_0 = Decimal.One
        Me.decimal_2 = Decimal.One
        Me.int_0 = 5
        Me.int_1 = 0
        Me.int_2 = 85
        Me.float_3 = CSng((CDbl(My.Resources.DigitalPanelMeter.Height) / CDbl(My.Resources.DigitalPanelMeter.Width)))
        Try

            MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
            Me.BackColor = Color.Transparent
            If ((MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0))) Then
                Me.ForeColor = Color.LightGray
            End If
            Me.method_1()
            Me.stringFormat_0 = New StringFormat() With
                {
                    .Alignment = StringAlignment.Center,
                    .LineAlignment = StringAlignment.Far
                }

        Catch

        End Try
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                If (Me.bitmap_0 IsNot Nothing) Then
                    Me.bitmap_0.Dispose()
                End If
                If (Me.bitmap_2 IsNot Nothing) Then
                    Me.bitmap_2.Dispose()
                End If
                Dim length As Integer = CInt(Me.bitmap_1.Length) - 1
                Dim num As Integer = 0
                Do
                    If (Me.bitmap_1(num) IsNot Nothing) Then
                        Me.bitmap_1(num).Dispose()
                    End If
                    num = num + 1
                Loop While num <= length
                Me.solidBrush_0.Dispose()
                Me.stringFormat_0.Dispose()
                Me.bitmap_3.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub method_0()
        If (MyBase.Height <> Me.int_4 Or MyBase.Width <> Me.int_3) Then
            Me.method_1()
            Me.int_3 = MyBase.Width
            Me.int_4 = MyBase.Height
            Me.method_2()
        End If
    End Sub

    Private Sub method_1()
        Me.float_3 = CSng((CDbl(My.Resources.DigitalPanelMeter.Height) / CDbl((My.Resources.DigitalPanelMeter.Width + (Me.int_0 - 4) * Me.int_2))))
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
    End Sub

    Private Sub method_2()
        Me.float_3 = CSng((CDbl(My.Resources.DigitalPanelMeter.Height) / CDbl((My.Resources.DigitalPanelMeter.Width + (Me.int_0 - 4) * Me.int_2))))
        Dim width As Single = CSng((CDbl(MyBase.Width) / CDbl((My.Resources.DigitalPanelMeter.Width + (Me.int_0 - 4 * Me.int_2)))))
        Dim height As Single = CSng((CDbl(MyBase.Height) / CDbl(My.Resources.DigitalPanelMeter.Height)))
        If (width >= height) Then
            Me.float_1 = CSng(MyBase.Width)
            Me.float_2 = CSng((CDbl(My.Resources.DigitalPanelMeter.Height) / CDbl((My.Resources.DigitalPanelMeter.Width + (Me.int_0 - 4 * Me.int_2))) * CDbl(MyBase.Width)))
            Me.float_0 = height
        Else
            Me.float_2 = CSng(MyBase.Height)
            If (Not (MyBase.Height > 0 And My.Resources.DigitalPanelMeter.Height > 0)) Then
                Me.float_1 = 1!
            Else
                Me.float_1 = CSng((CDbl((My.Resources.DigitalPanelMeter.Width + (Me.int_0 - 4 * Me.int_2))) / CDbl(My.Resources.DigitalPanelMeter.Height) * CDbl(MyBase.Height)))
            End If
            Me.float_0 = width
        End If
        If (Me.float_0 > 0!) Then
            If (Me.bitmap_0 IsNot Nothing) Then
                Me.bitmap_0.Dispose()
            End If
            Me.bitmap_0 = New Bitmap(Convert.ToInt32(CSng((My.Resources.DigitalPanelMeter.Width + (Me.int_0 - 4) * Me.int_2)) * Me.float_0), Convert.ToInt32(CSng(My.Resources.DigitalPanelMeter.Height) * Me.float_0))
            Dim graphic As Graphics = Graphics.FromImage(Me.bitmap_0)
            graphic.DrawImage(My.Resources.DigitalPanelMeter, CSng(Convert.ToInt32((Me.int_0 - 4) * Me.int_2)) * Me.float_0, 0!, CSng(My.Resources.DigitalPanelMeter.Width) * Me.float_0, CSng(My.Resources.DigitalPanelMeter.Height) * Me.float_0)
            If (Me.int_0 > 4) Then
                graphic.DrawImage(My.Resources.DigitalPanelMeterLeftHalf, 0!, 0!, CSng(My.Resources.DigitalPanelMeterLeftHalf.Width) * Me.float_0, CSng(Convert.ToInt32(CSng(My.Resources.DigitalPanelMeterLeftHalf.Height) * Me.float_0)))
            End If
            Me.rectangle_0.X = 0
            Me.rectangle_0.Y = CInt(Math.Round(CDbl(MyBase.Height) * 0.04))
            Me.rectangle_0.Width = MyBase.Width
            Me.rectangle_0.Height = CInt(Math.Round(CDbl(MyBase.Height) * 0.18))
            If (Me.solidBrush_0 Is Nothing) Then
                Me.solidBrush_0 = New SolidBrush(MyBase.ForeColor)
            End If
            Dim num As Integer = CInt(Math.Round(CDbl(Convert.ToInt32(CSng(My.Resources.LED7Segment8Red.Width) * Me.float_0)) * 0.7))
            Dim num1 As Integer = CInt(Math.Round(CDbl(Convert.ToInt32(CSng(My.Resources.LED7Segment8Red.Height) * Me.float_0)) * 0.7))
            Dim num2 As Integer = 0
            Do
                If (Me.bitmap_1(num2) IsNot Nothing) Then
                    Me.bitmap_1(num2).Dispose()
                End If
                Me.bitmap_1(num2) = New Bitmap(num, num1)
                graphic = Graphics.FromImage(Me.bitmap_1(num2))
                Select Case num2
                    Case 0
                        graphic.DrawImage(My.Resources.LED7Segment0Red, 0, 0, num, num1)
                        Exit Select
                    Case 1
                        graphic.DrawImage(My.Resources.LED7Segment1Red, 0, 0, num, num1)
                        Exit Select
                    Case 2
                        graphic.DrawImage(My.Resources.LED7Segment2Red, 0, 0, num, num1)
                        Exit Select
                    Case 3
                        graphic.DrawImage(My.Resources.LED7Segment3Red, 0, 0, num, num1)
                        Exit Select
                    Case 4
                        graphic.DrawImage(My.Resources.LED7Segment4Red, 0, 0, num, num1)
                        Exit Select
                    Case 5
                        graphic.DrawImage(My.Resources.LED7Segment5Red, 0, 0, num, num1)
                        Exit Select
                    Case 6
                        graphic.DrawImage(My.Resources.LED7Segment6Red, 0, 0, num, num1)
                        Exit Select
                    Case 7
                        graphic.DrawImage(My.Resources.LED7Segment7Red, 0, 0, num, num1)
                        Exit Select
                    Case 8
                        graphic.DrawImage(My.Resources.LED7Segment8Red, 0, 0, num, num1)
                        Exit Select
                    Case 9
                        graphic.DrawImage(My.Resources.LED7Segment9Red, 0, 0, num, num1)
                        Exit Select
                    Case 10
                        graphic.DrawImage(My.Resources.LED7SegmentOffRed, 0, 0, num, num1)
                        Exit Select
                    Case 11
                        graphic.DrawImage(My.Resources.LED7Segment_Red, 0, 0, num, num1)
                        Exit Select
                End Select
                num2 = num2 + 1
            Loop While num2 <= 11
            Me.bitmap_2 = New Bitmap(Convert.ToInt32(CSng(My.Resources.LED7SegmentDecimalRed.Width) * Me.float_0), Convert.ToInt32(CSng(My.Resources.LED7SegmentDecimalRed.Height) * Me.float_0))
            graphic = Graphics.FromImage(Me.bitmap_2)
            graphic.DrawImage(My.Resources.LED7SegmentDecimalRed, 0, 0, Convert.ToInt32(CSng(My.Resources.LED7SegmentDecimalRed.Width) * Me.float_0), Convert.ToInt32(CSng(My.Resources.LED7SegmentDecimalRed.Height) * Me.float_0))
            graphic.Dispose()
            If (Me.bitmap_3 IsNot Nothing) Then
                Me.bitmap_3.Dispose()
            End If
            Me.bitmap_3 = New Bitmap(MyBase.Width, MyBase.Height)
            MyBase.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim flag As Boolean = False
        If (Not (Me.bitmap_0 Is Nothing Or Me.bitmap_3 Is Nothing) And Me.solidBrush_0 IsNot Nothing) Then
            Using graphic As Graphics = Graphics.FromImage(Me.bitmap_3)
                graphic.Clear(MyBase.BackColor)
                graphic.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, MyBase.Width, MyBase.Height)
                graphic.DrawImage(Me.bitmap_0, 0, 0)
                If (Not String.IsNullOrEmpty(MyBase.Text)) Then
                    If (Me.solidBrush_0.Color <> MyBase.ForeColor) Then
                        Me.solidBrush_0.Color = MyBase.ForeColor
                    End If
                    graphic.DrawString(MyBase.Text, MyBase.Font, Me.solidBrush_0, Me.rectangle_0, Me.stringFormat_0)
                End If
                Try
                    Dim one As Decimal = Decimal.Divide(Decimal.One, Me.decimal_2)
                    If (Decimal.Compare(one, Decimal.Zero) = 0) Then
                        one = Decimal.One
                    End If
                    Dim num As Long = CLng(Math.Round((Me.double_0 + Convert.ToDouble(Me.decimal_1)) * Convert.ToDouble(one) * Convert.ToDouble(Me.decimal_0)))
                    Dim num1 As Long = Convert.ToInt64(Decimal.Divide(New Decimal(num), one))
                    If (Not (CDbl(num1) <= Math.Pow(10, CDbl(Me.int_0)) - 1 And CDbl(num1) >= (Math.Pow(10, CDbl((Me.int_0 - 1))) - 1) * -1)) Then
                        Dim int0 As Integer = Me.int_0
                        For i As Integer = 1 To int0 Step 1
                            graphic.DrawImage(Me.bitmap_1(11), CSng((75 + Me.int_2 * (i - 1))) * Me.float_0, 65! * Me.float_0)
                        Next

                    Else
                        Dim int01 As Integer = Me.int_0
                        For j As Integer = 1 To int01 Step 1
                            If (num1 >= 0L) Then
                                Dim num2 As Long = Convert.ToInt64(Math.Floor(CDbl(num1) / Math.Pow(10, CDbl((Me.int_0 - j)))))
                                If (num2 > 0L Or j = Me.int_0 Or j > Me.int_0 - Me.int_1) Then
                                    flag = True
                                End If
                                If (Not flag) Then
                                    graphic.DrawImage(Me.bitmap_1(10), CSng((75 + Me.int_2 * (j - 1))) * Me.float_0, 65! * Me.float_0)
                                Else
                                    graphic.DrawImage(Me.bitmap_1(CInt(num2)), CSng((75 + Me.int_2 * (j - 1))) * Me.float_0, 65! * Me.float_0)
                                End If
                                num1 = num1 - Convert.ToInt64(CDbl(num2) * Math.Pow(10, CDbl((Me.int_0 - j))))
                            Else
                                graphic.DrawImage(Me.bitmap_1(11), CSng((75 + Me.int_2 * (j - 1))) * Me.float_0, 65! * Me.float_0)
                                num1 = Math.Abs(num1)
                            End If
                        Next

                    End If
                Catch exception As System.Exception
                    ProjectData.SetProjectError(exception)
                    Dim int02 As Integer = Me.int_0
                    Dim num3 As Integer = 1
                    Do
                        graphic.DrawImage(Me.bitmap_1(11), CSng((75 + Me.int_2 * (num3 - 1))) * Me.float_0, 65! * Me.float_0)
                        num3 = num3 + 1
                    Loop While num3 <= int02
                    ProjectData.ClearProjectError()
                End Try
                If (Me.int_1 > 0) Then
                    graphic.DrawImage(Me.bitmap_2, CSng(((Me.int_0 - Me.int_1) * Me.int_2 + 55)) * Me.float_0, 160! * Me.float_0)
                End If
                painte.Graphics.DrawImage(Me.bitmap_3, 0, 0)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If (Me.bitmap_3 IsNot Nothing) Then
            Me.bitmap_3.Dispose()
            Me.bitmap_3 = Nothing
        End If
        Me.method_0()
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Public Event ValueChanged As EventHandler

End Class
