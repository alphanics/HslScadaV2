Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class WeightIndicator2
    Inherits Control

#Region "Bitmap"


    Private StaticImage As Bitmap

    Private LED(11) As Bitmap

    Private DecimalImage As Bitmap
#End Region
    Private ImageRatio As Single

    Private TextRectangle As Rectangle

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private x As Single

    Private y As Single

    Private m_Value As Single
    Private m_Button1Text As String

    Private m_Button2Text As String

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

#End Region


    Public Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 12)
        ForeColor = Color.FromArgb(150, 150, 150)
        Size = New Size(166, 40)

        TextRectangle = New Rectangle()
        m_ValueScaleFactor = Decimal.One
        m_Resolution = Decimal.One
        m_NumberOfDigits = 5
        m_DecimalPos = 0
        SegWidth = 70
        StaticImageRatio = CDbl(My.Resources.Indicator2.Height) / CDbl(My.Resources.Indicator2.Width)
        If (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            ForeColor = Color.LightGray
        End If
        AdjustSize()
        sf = New StringFormat() With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Far
        }
    End Sub
    Protected Sub AdjustSize()

        Me.StaticImageRatio = CSng(CDbl(My.Resources.Indicator2.Height) / CDbl(My.Resources.Indicator2.Width))
        If Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width Then
            If CDbl(Me.Height) / CDbl(Me.Width) <= CDbl(Me.StaticImageRatio) Then
                Me.Height = CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Width) * Me.StaticImageRatio)))))
            Else
                Me.Width = CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) / Me.StaticImageRatio)))))
            End If
        ElseIf CDbl(Me.Height) / CDbl(Me.Width) <= CDbl(Me.StaticImageRatio) Then
            Me.Width = CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) / Me.StaticImageRatio)))))
        Else
            Me.Height = CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Width) * Me.StaticImageRatio)))))
        End If
        Me.LastWidth = Me.Width
        Me.LastHeight = Me.Height
        Me.RefreshImage()
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

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim DigitsStarted As Boolean = False
        If Not (StaticImage Is Nothing Or _backBuffer Is Nothing Or TextBrush Is Nothing) Then
            Using g As Graphics = Graphics.FromImage(_backBuffer)
                g.Clear(MyBase.BackColor)
                g.FillRectangle(New SolidBrush(BackColor), 0, 0, Width, Height)
                g.DrawImage(StaticImage, 0, 0)

                Dim one As Decimal = Decimal.Divide(Decimal.One, m_Resolution)
                If Decimal.Compare(one, Decimal.Zero) = 0 Then
                    one = Decimal.One
                End If
                Dim num As Long = Math.Truncate(Math.Round((m_Value + Convert.ToDouble(m_ValueScaleOffset)) * Convert.ToDouble(one) * Convert.ToDouble(m_ValueScaleFactor)))
                Dim WorkValue As Long = Convert.ToInt64(Decimal.Divide(New Decimal(num), one))
                If Not (WorkValue <= Math.Pow(10, m_NumberOfDigits) - 1 And WorkValue >= (Math.Pow(10, m_NumberOfDigits - 1) - 1) * -1) Then
                    Dim mNumberOfDigits As Integer = m_NumberOfDigits
                    For i As Integer = 1 To mNumberOfDigits
                        g.DrawImage(LED(11), (75 + SegWidth * (i - 1)) * ImageRatio, 35.0F * ImageRatio)
                    Next i
                Else
                    Dim mNumberOfDigits1 As Integer = m_NumberOfDigits
                    For j As Integer = 1 To mNumberOfDigits1
                        If WorkValue >= 0 Then
                            Dim d As Integer = Convert.ToInt32(Math.Floor(WorkValue / Math.Pow(10, m_NumberOfDigits - j)))
                            If d > 0 Or j = m_NumberOfDigits Or j > m_NumberOfDigits - m_DecimalPos Then
                                DigitsStarted = True
                            End If
                            If Not DigitsStarted Then
                                g.DrawImage(LED(10), (75 + SegWidth * (j - 1)) * ImageRatio, 35.0F * ImageRatio)
                            Else
                                g.DrawImage(LED(d), (75 + SegWidth * (j - 1)) * ImageRatio, 35.0F * ImageRatio)
                            End If
                            WorkValue = Math.Truncate(Math.Round(CDbl(WorkValue) - CDbl(d) * Math.Pow(10, CDbl(m_NumberOfDigits - j))))
                        Else
                            g.DrawImage(LED(11), (75 + SegWidth * (j - 1)) * ImageRatio, 35.0F * ImageRatio)
                            WorkValue = Math.Abs(WorkValue)
                        End If
                    Next j
                End If
                If m_DecimalPos > 0 Then
                    g.DrawImage(DecimalImage, (((m_NumberOfDigits - m_DecimalPos) * SegWidth) + 65) * ImageRatio, 130.0F * ImageRatio)
                End If
                e.Graphics.DrawImage(_backBuffer, 0, 0)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
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

    Private Sub RefreshImage()

        Dim WidthRatio As Single = CSng(CDbl(Me.Width) / CDbl(My.Resources.Indicator2.Width))
        Dim HeightRatio As Single = CSng(CDbl(Me.Height) / CDbl(My.Resources.Indicator2.Height))
        If WidthRatio >= HeightRatio Then
            x = CSng(Width)
            y = CSng(CDbl(My.Resources.Indicator2.Height) / CDbl(My.Resources.Indicator2.Width) * CDbl(Me.Width))
            Me.ImageRatio = HeightRatio
        Else
            y = CSng(Me.Height)
            x = (If(Not (Me.Height > 0 And My.Resources.Indicator2.Height > 0), 1.0F, CSng(CDbl(My.Resources.Indicator2.Width) / CDbl(My.Resources.Indicator2.Height) * CDbl(Me.Height))))
            Me.ImageRatio = WidthRatio
        End If
        If Me.ImageRatio > 0.0F Then
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            Me.StaticImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.Indicator2.Width) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.Indicator2.Height) * Me.ImageRatio))
            Dim gr_dest As Graphics = Graphics.FromImage(Me.StaticImage)
            gr_dest.DrawImage(My.Resources.Indicator2, 0, 0, Me.StaticImage.Width, Me.StaticImage.Height)


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
            Invalidate()
        End If
    End Sub

    Public Event ValueChanged As EventHandler
End Class

