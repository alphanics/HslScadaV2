Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Inverter
    Inherits Control

#Region "Bitmap"


    Private StaticImage As Bitmap

    Private LED(11) As Bitmap

    Private DecimalImage As Bitmap
#End Region
    Private ImageRatio As Single
    Private sfCenter, sfCenterBottom, sfRight, sfLeft As New StringFormat

    Private TextRectangle As Rectangle

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private x As Single

    Private y As Single

    Private m_Value As Single



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
            Return Me.m_DecimalPos
        End Get
        Set(ByVal value As Integer)
            Me.m_DecimalPos = Math.Max(Math.Min(Me.m_NumberOfDigits - 1, value), 0)
            Me.RefreshImage()
            Me.Invalidate()
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




    Private m_Text As String = "Text"
    Public Property LegendText() As String
        Get
            Return m_Text
        End Get
        Set(ByVal value As String)
            m_Text = value
            RefreshImage()
            Me.Invalidate()
        End Set
    End Property
#End Region


    Private NumberLocations() As Rectangle
    Public Sub New()
        Me.LED = New Bitmap(11) {}


        Me.NumberLocations = New Rectangle(2) {}
        Me.sf = New StringFormat()

        Me.m_NumberOfDigits = 4
        Me.m_DecimalPos = 0
        Me.SegWidth = 25
        Me.m_Value = 9999
        TextRectangle = New Rectangle()

        m_Resolution = Decimal.One
        Me.Size = New Size(260, 225)
        Me.StaticImageRatio = CSng(CDbl(My.Resources.InverterMain.Height) / CDbl(My.Resources.InverterMain.Width))
        If (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            ForeColor = Color.LightGray
        End If

        sf = New StringFormat() With {
        .Alignment = StringAlignment.Center,
        .LineAlignment = StringAlignment.Far
    }

    End Sub


    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        StaticImageRatio = My.Resources.InverterMain.Height / My.Resources.InverterMain.Width

        '* Is the size increasing or decreasing?
        If LastHeight < Me.Height Or LastWidth < Me.Width Then
            If Me.Height / Me.Width > StaticImageRatio Then
                Me.Width = Me.Height / StaticImageRatio
            Else
                Me.Height = Me.Width * StaticImageRatio
            End If
        Else
            If Me.Height / Me.Width > StaticImageRatio Then
                Me.Height = Me.Width * StaticImageRatio
            Else
                Me.Width = Me.Height / StaticImageRatio
            End If
        End If

        LastWidth = Me.Width
        LastHeight = Me.Height


        RefreshImage()
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
        If StaticImage Is Nothing Or _backBuffer Is Nothing Then Exit Sub

        Dim g As Graphics = Graphics.FromImage(_backBuffer)


        g.DrawImage(StaticImage, 0, 0)


        '****************************************
        '* Draw each of the RED digits
        '****************************************
        Dim d As Integer
        Dim WorkValue As Single = m_Value
        Dim DigitsStarted As Boolean
        If WorkValue <= 10 ^ m_NumberOfDigits - 1 And WorkValue >= (10 ^ (m_NumberOfDigits - 1) - 1) * -1 Then
            For i = 1 To m_NumberOfDigits
                If WorkValue < 0 Then
                    '* draw in the - sign, then make the work value positive
                    g.DrawImage(LED(11), (200 + SegWidth * (i - 1)) * ImageRatio, 30 * ImageRatio)
                    WorkValue = Math.Abs(WorkValue)
                Else

                    d = CInt(Math.Floor(WorkValue / 10 ^ (m_NumberOfDigits - i)))

                    '* Determine when to use Blank(all off) or zero
                    If d > 0 Or i = (m_NumberOfDigits) Or i > (m_NumberOfDigits - m_DecimalPos) Then DigitsStarted = True

                    If DigitsStarted Then
                        g.DrawImage(LED(d), (85 + SegWidth * (i - 1)) * ImageRatio, 30 * ImageRatio)
                    Else
                        g.DrawImage(LED(10), (85 + SegWidth * (i - 1)) * ImageRatio, 30 * ImageRatio)
                    End If

                    WorkValue -= d * 10 ^ (m_NumberOfDigits - i)
                End If
            Next
        Else
            '* Draw all -'s
            For i = 1 To m_NumberOfDigits
                g.DrawImage(LED(11), (85 + SegWidth * (i - 1)) * ImageRatio, 30 * ImageRatio)
            Next
        End If


        '* Draw the decimal point
        If m_DecimalPos > 0 Then
            g.DrawImage(DecimalImage, ((m_NumberOfDigits - m_DecimalPos) * SegWidth + 50) * ImageRatio, 150 * ImageRatio)
        End If
        'Copy the back buffer to the screen
        e.Graphics.DrawImage(_backBuffer, 0, 0)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If _backBuffer IsNot Nothing Then
            _backBuffer.Dispose()
            _backBuffer = Nothing
        End If

        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub


    Private Sub RefreshImage()

        StaticImageRatio = My.Resources.InverterMain.Height / My.Resources.InverterMain.Width

        '************************************************************
        '* Calculate the size ratio of the original t resized image
        '************************************************************
        Dim WidthRatio As Single = Me.Width / My.Resources.InverterMain.Width
        Dim HeightRatio As Single = Me.Height / My.Resources.InverterMain.Height

        If WidthRatio < HeightRatio Then
            y = Me.Height
            If Me.Height > 0 And My.Resources.InverterMain.Height > 0 Then
                x = My.Resources.InverterMain.Width / My.Resources.InverterMain.Height * Me.Height
            Else
                x = 1
            End If
            ImageRatio = WidthRatio
        Else
            x = Me.Width
            y = My.Resources.InverterMain.Height / My.Resources.InverterMain.Width * Me.Width
            ImageRatio = HeightRatio
        End If

        '****************************************************************
        ' Scale the gauge image so it will draw faster in Paint event
        '****************************************************************
        ' Make a bitmap for the result.
        If StaticImage IsNot Nothing Then StaticImage.Dispose()
        StaticImage = New Bitmap(CInt(My.Resources.InverterMain.Width * ImageRatio), CInt(My.Resources.InverterMain.Height * ImageRatio))

        ' Make a Graphics object for the result Bitmap.
        Dim gr_dest As Graphics = Graphics.FromImage(StaticImage)

        gr_dest.ScaleTransform(ImageRatio * 0.75, ImageRatio * 0.75)

        ' Copy the source image into the destination bitmap.
        gr_dest.DrawImage(My.Resources.InverterMain, 0, 0)


        '************************************************
        '* Create a text rectangle and align to center
        '************************************************
        TextRectangle.X = 0
        TextRectangle.Y = 85
        TextRectangle.Width = My.Resources.InverterMain.Width / 0.75 - 1
        TextRectangle.Height = 50

        sfCenterBottom.Alignment = StringAlignment.Center
        sfCenterBottom.LineAlignment = StringAlignment.Far

        Dim f As New Font("Arial", 32, FontStyle.Regular, GraphicsUnit.Point)
        Dim b As New SolidBrush(Color.FromArgb(245, 100, 100, 100))


        gr_dest.DrawString(m_Text, f, b, TextRectangle, sfCenterBottom)


        '****************************************************************
        ' Create Scaled LED images so it will draw faster in Paint event
        '****************************************************************

        Dim LEDWidth, LEDHeight As Integer
        LEDWidth = CInt(My.Resources.LED7Segment8Red.Width * ImageRatio)
        LEDHeight = CInt(My.Resources.LED7Segment8Red.Height * ImageRatio)



        For i As Integer = 0 To 11
            If LED(i) IsNot Nothing Then LED(i).Dispose()
            LED(i) = New Bitmap(LEDWidth, LEDHeight)
            gr_dest = Graphics.FromImage(LED(i))
            gr_dest.ScaleTransform(ImageRatio * 0.25, ImageRatio * 0.25)


            Select Case i
                Case 0 : gr_dest.DrawImage(My.Resources.LED7Segment0Red, 0, 0)
                Case 1 : gr_dest.DrawImage(My.Resources.LED7Segment1Red, 0, 0)
                Case 2 : gr_dest.DrawImage(My.Resources.LED7Segment2Red, 0, 0)
                Case 3 : gr_dest.DrawImage(My.Resources.LED7Segment3Red, 0, 0)
                Case 4 : gr_dest.DrawImage(My.Resources.LED7Segment4Red, 0, 0)
                Case 5 : gr_dest.DrawImage(My.Resources.LED7Segment5Red, 0, 0)
                Case 6 : gr_dest.DrawImage(My.Resources.LED7Segment6Red, 0, 0)
                Case 7 : gr_dest.DrawImage(My.Resources.LED7Segment7Red, 0, 0)
                Case 8 : gr_dest.DrawImage(My.Resources.LED7Segment8Red, 0, 0)
                Case 9 : gr_dest.DrawImage(My.Resources.LED7Segment9Red, 0, 0)
                Case 10 : gr_dest.DrawImage(My.Resources.LED7SegmentOffRed, 0, 0)
                Case 11 : gr_dest.DrawImage(My.Resources.LED7Segment_Red, 0, 0)
            End Select


            '* Perform some cleanup
            gr_dest.Dispose()

        Next

        '* Draw the decimal point to the bitmap
        DecimalImage = New Bitmap(CInt(My.Resources.LED7SegmentDecimalRed.Width * ImageRatio), CInt(My.Resources.LED7SegmentDecimalRed.Height * ImageRatio))
        gr_dest = Graphics.FromImage(DecimalImage)
        'gr_dest.Transform = m
        gr_dest.DrawImage(My.Resources.LED7SegmentDecimalRed, 0, 0)



        '* Create a new resized backbuffer for double buffering
        If _backBuffer IsNot Nothing Then _backBuffer.Dispose()
        _backBuffer = New Bitmap(Me.Width, Me.Height)

    End Sub


    Public Event ValueChanged As EventHandler
End Class

