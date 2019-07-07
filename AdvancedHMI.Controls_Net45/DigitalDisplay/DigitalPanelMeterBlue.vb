Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class DigitalPanelMeterBlue
    Inherits AnalogMeterBase

    Private LED() As Bitmap

    Private DecimalImage As Bitmap

    Private m_Resolution As Decimal

    Private m_DecimalPos As Integer

    Private m_BackLightColor As ColorSelect

    Private LastWidth As Integer

    Private LastHeight As Integer
#Region "Property"
    Public Property BackLightColor() As ColorSelect
        Get
            Return Me.m_BackLightColor
        End Get
        Set(ByVal value As ColorSelect)
            If Me.m_BackLightColor <> value Then
                Me.m_BackLightColor = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property DecimalPosition() As Integer
        Get
            Return Me.m_DecimalPos
        End Get
        Set(ByVal value As Integer)
            Me.m_DecimalPos = Math.Max(Math.Min(99, value), 0)
            Me.Invalidate()
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property Resolution() As Decimal
        Get
            Return Me.m_Resolution
        End Get
        Set(ByVal value As Decimal)
            If Decimal.Compare(value, Decimal.Zero) <> 0 Then
                Me.m_Resolution = value
                If Me.StaticImage IsNot Nothing Then
                    Me.Invalidate()
                End If
            End If
        End Set
    End Property
#End Region
    Public Sub New()
        Me.LED = New Bitmap(11) {}
        Me.m_Resolution = Decimal.One
        Me.m_DecimalPos = 0
        Me.m_BackLightColor = DigitalPanelMeterBlue.ColorSelect.Blue
        If (MyBase.ForeColor = Color.LightGray) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            Me.ForeColor = Color.Black
        End If
        Me.Maximum = 0
        Me.Minimum = 0
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If Me.DecimalImage IsNot Nothing Then
                    Me.DecimalImage.Dispose()
                End If
                Dim length As Integer = (CInt(Me.LED.Length)) - 1
                For i As Integer = 0 To length
                    If Me.LED(i) IsNot Nothing Then
                        Me.LED(i).Dispose()
                    End If
                Next i
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim flag As Boolean = False
        If Not (Me.StaticImage Is Nothing Or Me.BackBuffer Is Nothing) Then
            Using graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
                graphic.DrawImage(Me.StaticImage, 0, 0)
                If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                    If Me.TextBrush Is Nothing Then
                        Me.TextBrush = New SolidBrush(MyBase.ForeColor)
                    ElseIf Me.TextBrush.Color <> MyBase.ForeColor Then
                        Me.TextBrush.Color = MyBase.ForeColor
                    End If
                    graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
                End If
                Dim one As Decimal = Decimal.Divide(Decimal.One, Me.m_Resolution)
                If Decimal.Compare(one, Decimal.Zero) = 0 Then
                    one = Decimal.One
                End If
                Dim num As Long = Convert.ToInt64(Decimal.Divide(New Decimal(CLng(Math.Truncate(Math.Round(Me.m_Value * Convert.ToDouble(one) * Me.m_ValueScaleFactor)))), one))
                Dim num1 As Integer = Convert.ToInt32(0.24 * CDbl(Me.Height))
                Dim num2 As Integer = Convert.ToInt32(CDbl(Me.LED(0).Width) * 1.15)
                Dim width_Renamed As Single = CSng(CDbl(My.Resources.BlueBackgroundFrame.Width) * 1 / CDbl(My.Resources.BlueBackgroundFrame.Height) / (CDbl(Me.StaticImage.Width) * 1 / CDbl(Me.StaticImage.Height)))
                Dim num3 As Integer = Convert.ToInt32(CDbl(Me.Width) * 0.8 / (CDbl(Me.LED(0).Width) * 1.15))
                If Not (CDbl(num) <= Math.Pow(10, CDbl(num3)) - 1 And CDbl(num) >= (Math.Pow(10, CDbl(num3 - 1)) - 1) * -1) Then
                    Dim num4 As Integer = num3
                    For i As Integer = 1 To num4
                        graphic.DrawImage(Me.LED(11), Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.1) + num2 * (i - 1), num1)
                    Next i
                Else
                    Dim num5 As Integer = num3
                    For j As Integer = 1 To num5
                        If num >= CLng(0) Then
                            Dim num6 As Integer = Convert.ToInt32(Math.Floor(CDbl(num) / Math.Pow(10, CDbl(num3 - j))))
                            If num6 > 0 Or j = num3 Or j > num3 - Me.m_DecimalPos Then
                                flag = True
                            End If
                            If flag Then
                                graphic.DrawImage(Me.LED(num6), Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.1) + num2 * (j - 1), num1)
                            End If
                            num = CLng(Math.Truncate(Math.Round(CDbl(num) - CDbl(num6) * Math.Pow(10, CDbl(num3 - j)))))
                        Else
                            graphic.DrawImage(Me.LED(11), Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.1) + num2 * (j - 1), num1)
                            num = Math.Abs(num)
                        End If
                    Next j
                End If
                If Me.m_DecimalPos > 0 Then
                    graphic.DrawImage(Me.DecimalImage, ((num3 - Me.m_DecimalPos) * num2) + Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.072), Convert.ToInt32(CDbl(Me.Height) * 0.77))
                End If
                e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Me.Height <> Me.LastHeight Or Me.Width <> Me.LastWidth Then
            Me.LastWidth = Me.Width
            Me.LastHeight = Me.Height
            Me.CreateStaticImage()
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub CreateStaticImage()
        If Not (Me.Width <= 0 Or Me.Height <= 0) Then
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            Me.StaticImage = New Bitmap(Me.Width, Me.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
            If Me.m_BackLightColor = DigitalPanelMeterBlue.ColorSelect.Green Then
                graphic.DrawImage(My.Resources.GreenBackgroundFrame, 0, 0, Me.StaticImage.Width, Me.StaticImage.Height)
            ElseIf Me.m_BackLightColor <> DigitalPanelMeterBlue.ColorSelect.Yellow Then
                graphic.DrawImage(My.Resources.BlueBackgroundFrame, 0, 0, Me.StaticImage.Width, Me.StaticImage.Height)
            Else
                graphic.DrawImage(My.Resources.YellowBackgroundFrame, 0, 0, Me.StaticImage.Width, Me.StaticImage.Height)
            End If
            Me.TextRectangle.X = 0
            Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.02)))
            Me.TextRectangle.Width = Me.Width
            Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.17)))
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            Me.ImageRatio = CDbl(Me.Height) / CDbl(My.Resources.BlueBackgroundFrame.Height)
            Dim LEDWidth As Integer = Convert.ToInt32(CDbl(My.Resources.SevenSegment0.Width) * Me.ImageRatio)
            Dim LEDHeight As Integer = Convert.ToInt32(CDbl(My.Resources.SevenSegment0.Height) * Me.ImageRatio)
            Dim i As Integer = 0
            Do
                If Me.LED(i) IsNot Nothing Then
                    Me.LED(i).Dispose()
                End If
                Me.LED(i) = New Bitmap(LEDWidth, LEDHeight)
                graphic = Graphics.FromImage(Me.LED(i))
                Select Case i
                    Case 0
                        graphic.DrawImage(My.Resources.SevenSegment0, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 1
                        graphic.DrawImage(My.Resources.SevenSegment1, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 2
                        graphic.DrawImage(My.Resources.SevenSegment2, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 3
                        graphic.DrawImage(My.Resources.SevenSegment3, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 4
                        graphic.DrawImage(My.Resources.SevenSegment4, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 5
                        graphic.DrawImage(My.Resources.SevenSegment5, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 6
                        graphic.DrawImage(My.Resources.SevenSegment6, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 7
                        graphic.DrawImage(My.Resources.SevenSegment7, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 8
                        graphic.DrawImage(My.Resources.SevenSegment8, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 9
                        graphic.DrawImage(My.Resources.SevenSegment9, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 10
                        graphic.DrawImage(My.Resources.LED7SegmentOffRed, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 11
                        graphic.DrawImage(My.Resources.SevenSegment_, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                End Select
                i += 1
            Loop While i <= 11
            Me.DecimalImage = New Bitmap(Convert.ToInt32(CDbl(My.Resources.BlueSevenSegmentDot.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.BlueSevenSegmentDot.Height) * Me.ImageRatio))
            graphic = Graphics.FromImage(Me.DecimalImage)
            graphic.DrawImage(My.Resources.BlueSevenSegmentDot, 0, 0, Me.DecimalImage.Width, Me.DecimalImage.Height)
            graphic.Dispose()
            If Me.BackBuffer IsNot Nothing Then
                Me.BackBuffer.Dispose()
            End If
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub

    Public Enum ColorSelect
        Blue
        Yellow
        Green
    End Enum
End Class

