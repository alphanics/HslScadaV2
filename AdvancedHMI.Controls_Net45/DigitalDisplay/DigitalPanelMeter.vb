Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class DigitalPanelMeter
    Inherits Control
    Public Event ValueChanged As EventHandler
#Region "Faild"
    Private TextRect As New Rectangle

    Private StaticImage As Bitmap

    Private LED(11) As Bitmap

    Private DecimalImage As Bitmap

    Private ImageRatio As Single

    Private TextRectangle As Rectangle

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private x As Single

    Private y As Single

    Private m_Value As Single

    Private m_ValueScaleFactor As Decimal

    Private m_ValueScaleOffset As Decimal

    Private m_Resolution As Decimal

    Private m_NumberOfDigits As Integer

    Private m_DecimalPos As Integer

    Private SegWidth As Integer

    Private _backBuffer As Bitmap

    Private LastWidth As Integer

    Private LastHeight As Integer

    Private StaticImageRatio As Single
#End Region

#Region "Property"
    <Category("Numeric Display")>
    Public Property DecimalPosition() As Integer
        Get
            Return m_DecimalPos
        End Get
        Set(ByVal value As Integer)
            m_DecimalPos = Math.Max(Math.Min(m_NumberOfDigits - 1, value), 0)
            Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If TextBrush IsNot Nothing Then
                TextBrush.Color = value
            Else
                TextBrush = New SolidBrush(value)
            End If
            MyBase.ForeColor = value
            Invalidate()
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property NumberOfDigits() As Integer
        Get
            Return m_NumberOfDigits
        End Get
        Set(ByVal value As Integer)
            If value <> m_NumberOfDigits Then
                m_NumberOfDigits = Math.Max(Math.Min(6, value), 4)
                AdjustSize()
                RefreshImage()
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property Resolution() As Decimal
        Get
            Return m_Resolution
        End Get
        Set(ByVal value As Decimal)
            If Decimal.Compare(value, Decimal.Zero) <> 0 Then
                m_Resolution = value
                If StaticImage IsNot Nothing Then
                    Invalidate()
                End If
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
            Invalidate()
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property Value() As Single
        Get
            Return m_Value
        End Get
        Set(ByVal value As Single)
            If value <> m_Value Then
                m_Value = value
                Dim rectangle As New Rectangle(Math.Truncate(Math.Round(CDbl(StaticImage.Width) * 0.08)), Math.Truncate(Math.Round(CDbl(StaticImage.Height) * 0.1)), Math.Truncate(Math.Round(CDbl(StaticImage.Width) * 0.85)), Math.Truncate(Math.Round(CDbl(StaticImage.Height) * 0.8)))
                Invalidate(rectangle)
                OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property ValueScaleFactor() As Decimal
        Get
            Return m_ValueScaleFactor
        End Get
        Set(ByVal value As Decimal)
            If Decimal.Compare(m_ValueScaleFactor, value) <> 0 Then
                m_ValueScaleFactor = value
                Invalidate()
                OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property ValueScaleOffset() As Decimal
        Get
            Return m_ValueScaleOffset
        End Get
        Set(ByVal value As Decimal)
            If Decimal.Compare(m_ValueScaleOffset, value) <> 0 Then
                m_ValueScaleOffset = value
                Invalidate()
                OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property
    '*****************************************
    '* Property - Text on Legend Plate
    '*****************************************
    Private m_LegendText As String = "Text"
    Public Property LegendText() As String
        Get
            Return m_LegendText
        End Get
        Set(ByVal value As String)
            m_LegendText = value
            RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    Public Property BackgroundColors As BackgroundColor
        Get
            Return _backgroundColor1
        End Get
        Set(ByVal value As BackgroundColor)
            _backgroundColor1 = value
            RefreshImage()
            Me.Invalidate()
        End Set
    End Property
#End Region
#Region "Constructor"

    Public Sub New()


        TextRectangle = New Rectangle()
        m_ValueScaleFactor = Decimal.One
        m_Resolution = Decimal.One
        m_NumberOfDigits = 5
        m_DecimalPos = 0
        SegWidth = 75
        'm_LegendText = "KG"
        StaticImageRatio = CDbl(My.Resources.DigitalPanelMeter.Height) / CDbl(My.Resources.DigitalPanelMeter.Width)
        _backgroundColor1 = BackgroundColor.Black

        MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        If (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            ForeColor = Color.LightGray
        End If
        AdjustSize()
        sf = New StringFormat() With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Far
        }
    End Sub
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If StaticImage IsNot Nothing Then
                    StaticImage.Dispose()
                End If
                If DecimalImage IsNot Nothing Then
                    DecimalImage.Dispose()
                End If
                Dim length As Integer = (LED.Length) - 1
                For i As Integer = 0 To length
                    If LED(i) IsNot Nothing Then
                        LED(i).Dispose()
                    End If
                Next i
                TextBrush.Dispose()
                sf.Dispose()
                _backBuffer.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
#End Region
#Region "Overrides Sub"
    Private Sub AdjustSize()
        StaticImageRatio = CDbl(My.Resources.DigitalPanelMeter.Height) / CDbl(My.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4) * SegWidth)
        If LastHeight < Height Or LastWidth < Width Then
            If Height / Width <= StaticImageRatio Then
                Height = Math.Truncate(Math.Round(CDbl(CSng(CSng(Width) * StaticImageRatio))))
            Else
                Width = Math.Truncate(Math.Round(CDbl(CSng(CSng(Height) / StaticImageRatio))))
            End If
        ElseIf Height / Width <= StaticImageRatio Then
            Width = Math.Truncate(Math.Round(CDbl(CSng(CSng(Height) / StaticImageRatio))))
        Else
            Height = Math.Truncate(Math.Round(CDbl(CSng(CSng(Width) * StaticImageRatio))))
        End If
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim DigitsStarted As Boolean = False
        If Not (StaticImage Is Nothing Or _backBuffer Is Nothing Or TextBrush Is Nothing) Then
            Using g As Graphics = Graphics.FromImage(_backBuffer)
                g.Clear(MyBase.BackColor)
                g.FillRectangle(New SolidBrush(BackColor), 0, 0, Width, Height)

                g.DrawImage(StaticImage, 0, 0)

                If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                    If TextBrush.Color <> MyBase.ForeColor Then
                        TextBrush.Color = MyBase.ForeColor
                    End If
                    g.DrawString(MyBase.Text, MyBase.Font, TextBrush, TextRectangle, sf)
                End If

                Dim one As Decimal = Decimal.Divide(Decimal.One, m_Resolution)
                If Decimal.Compare(one, Decimal.Zero) = 0 Then
                    one = Decimal.One
                End If
                Dim b As New SolidBrush(Color.FromArgb(250, 130, 140, 160))

                Dim num As Long = Math.Truncate(Math.Round((m_Value + Convert.ToDouble(m_ValueScaleOffset)) * Convert.ToDouble(one) * Convert.ToDouble(m_ValueScaleFactor)))
                Dim WorkValue As Long = Convert.ToInt64(Decimal.Divide(New Decimal(num), one))
                If Not (WorkValue <= Math.Pow(10, m_NumberOfDigits) - 1 And WorkValue >= (Math.Pow(10, m_NumberOfDigits - 1) - 1) * -1) Then
                    Dim mNumberOfDigits As Integer = m_NumberOfDigits
                    For i As Integer = 1 To mNumberOfDigits
                        g.DrawImage(LED(11), (75 + SegWidth * (i - 1)) * ImageRatio, 65.0F * ImageRatio)
                    Next i
                Else
                    Dim mNumberOfDigits1 As Integer = m_NumberOfDigits
                    Dim j As Integer
                    For j = 1 To mNumberOfDigits1
                        If WorkValue >= 0 Then
                            Dim d As Integer = Convert.ToInt32(Math.Floor(WorkValue / Math.Pow(10, m_NumberOfDigits - j)))
                            If d > 0 Or j = m_NumberOfDigits Or j > m_NumberOfDigits - m_DecimalPos Then
                                DigitsStarted = True
                            End If
                            If Not DigitsStarted Then
                                g.DrawImage(LED(10), (75 + SegWidth * (j - 1)) * ImageRatio, 65.0F * ImageRatio)
                            Else
                                g.DrawImage(LED(d), (75 + SegWidth * (j - 1)) * ImageRatio, 65.0F * ImageRatio)

                            End If
                            WorkValue = Math.Truncate(Math.Round(CDbl(WorkValue) - CDbl(d) * Math.Pow(10, CDbl(m_NumberOfDigits - j))))
                        Else
                            g.DrawImage(LED(11), (75 + SegWidth * (j - 1)) * ImageRatio, 65.0F * ImageRatio)
                            WorkValue = Math.Abs(WorkValue)
                        End If
                    Next j
                    '' g.DrawString(m_LegendText, MyBase.Font, TextBrush, (80 + SegWidth * (j - 1)) * ImageRatio, 150.0F * ImageRatio)

                End If
                If m_DecimalPos > 0 Then
                    g.DrawImage(DecimalImage, (((m_NumberOfDigits - m_DecimalPos) * SegWidth) + 55) * ImageRatio, 160.0F * ImageRatio)
                End If

                e.Graphics.DrawImage(_backBuffer, 0, 0)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If _backBuffer IsNot Nothing Then
            _backBuffer.Dispose()
            _backBuffer = Nothing
        End If
        RatioLock()
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Private Sub RatioLock()
        If Height <> LastHeight Or Width <> LastWidth Then
            AdjustSize()
            LastWidth = Width
            LastHeight = Height
            RefreshImage()
        End If
    End Sub
    Public Enum BackgroundColor
        White
        Black
        Gray
    End Enum
    Private _backgroundColor1 As BackgroundColor = BackgroundColor.Black
    Private Sub RefreshImage()
        'Color.Gray
        StaticImageRatio = CDbl(My.Resources.DigitalPanelMeter.Height) / CDbl(My.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4) * SegWidth)
        Dim WidthRatio As Single = CDbl(Width) / CDbl(My.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4 * SegWidth))
        Dim HeightRatio As Single = CDbl(Height) / CDbl(My.Resources.DigitalPanelMeter.Height)
        If WidthRatio >= HeightRatio Then
            x = Width
            y = CDbl(My.Resources.DigitalPanelMeter.Height) / CDbl(My.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4 * SegWidth)) * CDbl(Width)
            ImageRatio = HeightRatio
        Else
            y = Height
            If Not (Height > 0 And My.Resources.DigitalPanelMeter.Height > 0) Then
                x = 1.0F
            Else
                x = CDbl(My.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4 * SegWidth)) / CDbl(My.Resources.DigitalPanelMeter.Height) * CDbl(Height)
            End If
            ImageRatio = WidthRatio
        End If
        If ImageRatio > 0.0F Then
            If StaticImage IsNot Nothing Then
                StaticImage.Dispose()
            End If
            StaticImage = New Bitmap(Convert.ToInt32((My.Resources.DigitalPanelMeter.Width + (m_NumberOfDigits - 4) * SegWidth) * ImageRatio), Convert.ToInt32(My.Resources.DigitalPanelMeter.Height * ImageRatio))
            Dim gr_dest As Graphics = Graphics.FromImage(StaticImage)
            If _backgroundColor1 = BackgroundColor.Black Then
                gr_dest.DrawImage(My.Resources.DigitalPanelMeter, Convert.ToInt32((m_NumberOfDigits - 4) * SegWidth) * ImageRatio, 0.0F, My.Resources.DigitalPanelMeter.Width * ImageRatio, My.Resources.DigitalPanelMeter.Height * ImageRatio)
            ElseIf _backgroundColor1 = BackgroundColor.White Then
                gr_dest.DrawImage(My.Resources.DigitalPanelMeter2, Convert.ToInt32((m_NumberOfDigits - 4) * SegWidth) * ImageRatio, 0.0F, My.Resources.DigitalPanelMeter.Width * ImageRatio, My.Resources.DigitalPanelMeter.Height * ImageRatio)
            Else
                gr_dest.DrawImage(My.Resources.DigitalPanelMeter3, Convert.ToInt32((m_NumberOfDigits - 4) * SegWidth) * ImageRatio, 0.0F, My.Resources.DigitalPanelMeter.Width * ImageRatio, My.Resources.DigitalPanelMeter.Height * ImageRatio)

            End If
            If m_NumberOfDigits > 4 Then
                If _backgroundColor1 = BackgroundColor.Black Then
                    gr_dest.DrawImage(My.Resources.DigitalPanelMeterLeftHalf, 0.0F, 0.0F, My.Resources.DigitalPanelMeterLeftHalf.Width * ImageRatio, Convert.ToInt32(CSng(My.Resources.DigitalPanelMeterLeftHalf.Height) * ImageRatio))

                ElseIf _backgroundColor1 = BackgroundColor.White Then
                    gr_dest.DrawImage(My.Resources.DigitalPanelMeterLeftHalf2, 0.0F, 0.0F, My.Resources.DigitalPanelMeterLeftHalf.Width * ImageRatio, Convert.ToInt32(CSng(My.Resources.DigitalPanelMeterLeftHalf.Height) * ImageRatio))
                Else
                    gr_dest.DrawImage(My.Resources.DigitalPanelMeterLeftHalf3, 0.0F, 0.0F, My.Resources.DigitalPanelMeterLeftHalf.Width * ImageRatio, Convert.ToInt32(CSng(My.Resources.DigitalPanelMeterLeftHalf.Height) * ImageRatio))

                End If
            End If

            TextRect.X = 5
            TextRect.Width = StaticImage.Width / 0.75 / ImageRatio
            TextRect.Y = 5
            TextRect.Height = StaticImage.Height / 0.75 / ImageRatio
            Dim sf2 As New StringFormat
            sf2.Alignment = StringAlignment.Center
            sf2.LineAlignment = StringAlignment.Center

            'gr_dest.DrawRectangle(Pens.Black, TextRect)
            'Dim b As New SolidBrush(Color.FromArgb(250, 130, 140, 160))
            'gr_dest.DrawString(m_LegendText, New Font("Arial", 22, FontStyle.Regular, GraphicsUnit.Point), b, TextRect, sf2)

            TextRectangle.X = 0
            TextRectangle.Y = Math.Truncate(Math.Round(CDbl(Height) * 0.04))
            TextRectangle.Width = Width
            TextRectangle.Height = Math.Truncate(Math.Round(CDbl(Height) * 0.18))
            If TextBrush Is Nothing Then
                TextBrush = New SolidBrush(MyBase.ForeColor)
            End If

            Dim LEDWidth As Integer = Math.Truncate(Math.Round(CDbl(Convert.ToInt32(CSng(My.Resources.LED7Segment8Red.Width) * ImageRatio)) * 0.7))
            Dim LEDHeight As Integer = Math.Truncate(Math.Round(CDbl(Convert.ToInt32(CSng(My.Resources.LED7Segment8Red.Height) * ImageRatio)) * 0.7))
            Dim i As Integer = 0
            Do
                If LED(i) IsNot Nothing Then
                    LED(i).Dispose()
                End If
                LED(i) = New Bitmap(LEDWidth, LEDHeight)
                gr_dest = Graphics.FromImage(LED(i))
                Select Case i
                    Case 0
                        gr_dest.DrawImage(My.Resources.LED7Segment0Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 1
                        gr_dest.DrawImage(My.Resources.LED7Segment1Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 2
                        gr_dest.DrawImage(My.Resources.LED7Segment2Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 3
                        gr_dest.DrawImage(My.Resources.LED7Segment3Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 4
                        gr_dest.DrawImage(My.Resources.LED7Segment4Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 5
                        gr_dest.DrawImage(My.Resources.LED7Segment5Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 6
                        gr_dest.DrawImage(My.Resources.LED7Segment6Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 7
                        gr_dest.DrawImage(My.Resources.LED7Segment7Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 8
                        gr_dest.DrawImage(My.Resources.LED7Segment8Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 9
                        gr_dest.DrawImage(My.Resources.LED7Segment9Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 10
                        gr_dest.DrawImage(My.Resources.LED7SegmentOffRed, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                    Case 11
                        gr_dest.DrawImage(My.Resources.LED7Segment_Red, 0, 0, LEDWidth, LEDHeight)
                        Exit Select
                End Select
                i += 1
            Loop While i <= 11
            DecimalImage = New Bitmap(Convert.ToInt32(My.Resources.LED7SegmentDecimalRed.Width * ImageRatio), Convert.ToInt32(My.Resources.LED7SegmentDecimalRed.Height * ImageRatio))
            gr_dest = Graphics.FromImage(DecimalImage)
            gr_dest.DrawImage(My.Resources.LED7SegmentDecimalRed, 0, 0, Convert.ToInt32(My.Resources.LED7SegmentDecimalRed.Width * ImageRatio), Convert.ToInt32(My.Resources.LED7SegmentDecimalRed.Height * ImageRatio))
            gr_dest.Dispose()
            If _backBuffer IsNot Nothing Then
                _backBuffer.Dispose()
            End If
            _backBuffer = New Bitmap(Width, Height)
            'Invalidate()
        End If
    End Sub

#End Region

End Class

