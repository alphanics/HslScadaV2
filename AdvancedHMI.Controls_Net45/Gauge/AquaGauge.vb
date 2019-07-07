Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

'''' <summary>
'''' Aqua Gauge Control - A Windows User Control.
'''' Author  : Ambalavanar Thirugnanam
'''' Date    : 24th August 2007
'''' email   : ambalavanar.thiru@gmail.com
'''' This control is for free. You can use for any commercial or non-commercial purposes.
'''' [Please do not remove this header when using this control in your application.]
'''' </summary>

' * Original Project: http://www.codeproject.com/Articles/20341/Aqua-Gauge
' *
' * 27-AUG-2015 Converted from C# to VB Net and modified by Godra
' * - Re-sizing was adjusted to refresh all components at the same time.
' * - 5 digits will be always showing with rounding to 0, 1, 2, 3 or 4 decimal places depending on the value, which
' *   is inversely proportional (the higher the value the lower the number of decimal places - to fit 5 digits).
' * - Added option to change color for most components.
' * - Added showing of "Aqua Gauge" words on the top part of the control (with the color corresponding to needle's LightLight color).
' * - Disabled public property EnableTransparentBackground and related entries.

Partial Public Class AquaGauge
    Inherits Control

#Region "Private Attributes"

    Private m_minValue As Single
    Private m_maxValue As Single = 100
    Private threshold As Single = 10
    Private currentValue As Single
    Private m_recommendedValue As Single = 60
    Private m_noOfDivisions As Integer = 10
    Private m_noOfSubDivisions As Integer = 4
    Private m_dialText As String = "Speed"
    Private m_dialColor As Color = Color.Black
    Private m_digitColor As Color = Color.DodgerBlue
    Private m_digitBckgColor As Color = Color.Black
    Private m_needleColor As Color = Color.Cyan
    Private m_rimColor As Color = Color.White
    Private m_rulerDivColor As Color = Color.Red
    Private m_rulerSubDivColor As Color = Color.DarkOrange
    Private m_thresholdColor As Color = Color.LawnGreen
    Private m_digitBckgOpacity As Integer = 0
    Private glossinessAlpha As Single = 121
    Private x As Integer, y As Integer, wdth As Integer, hght As Integer
    Private fromAngle As Single = 135.0F
    Private toAngle As Single = 405.0F
    'Private m_enableTransparentBackground As Boolean
    Private requiresRedraw As Boolean
    Private backgroundImg As Image
    Private rectImg As Rectangle

#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.ForeColor = Color.Orange
        x = 5
        y = 5
        wdth = Me.Width - 10
        hght = Me.Height - 10
        Me.m_noOfDivisions = 10
        Me.m_noOfSubDivisions = 4
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.BackColor = Color.Transparent
        Me.Size = New Size(283, 283)
        Me.MinimumSize = New Size(136, 136)
        Me.requiresRedraw = True
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    ''' Mininum value on the scale
    ''' </summary>
    <DefaultValue(0), RefreshProperties(RefreshProperties.All), Description("Mininum value on the scale")>
    Public Property MinValue() As Single
        Get
            Return m_minValue
        End Get
        Set(ByVal value As Single)
            If value < 0 OrElse value > m_maxValue Then
                MessageBox.Show("Invalid value!")
                Me.m_minValue = 0
                requiresRedraw = True
                Exit Property
            End If
            If value < m_maxValue Then
                m_minValue = value
                If currentValue < m_minValue Then
                    currentValue = m_minValue
                End If
                If m_recommendedValue < m_minValue Then
                    m_recommendedValue = m_minValue
                End If
                requiresRedraw = True
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Maximum value on the scale
    ''' </summary>
    <DefaultValue(100), RefreshProperties(RefreshProperties.All), Description("Maximum value on the scale (up to 100000)")>
    Public Property MaxValue() As Single
        Get
            Return m_maxValue
        End Get
        Set(ByVal value As Single)
            If value < 0 OrElse value < m_minValue OrElse value > 100000 Then
                MessageBox.Show("Invalid value!")
                Me.m_maxValue = 100
                requiresRedraw = True
                Exit Property
            End If
            If value > m_minValue Then
                m_maxValue = value
                If currentValue > m_maxValue Then
                    currentValue = m_maxValue
                End If
                If m_recommendedValue > m_maxValue Then
                    m_recommendedValue = m_maxValue
                End If
                requiresRedraw = True
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or Sets the Threshold area from the Recommended Value. (1-50% of the full scale)
    ''' </summary>
    <DefaultValue(10), RefreshProperties(RefreshProperties.All), Description("Gets or Sets the Threshold area from the Recommended Value. (1-50% of the full scale)")>
    Public Property ThresholdPercent() As Single
        Get
            Return threshold
        End Get
        Set(ByVal value As Single)
            If value >= 1 AndAlso value <= 50 Then
                threshold = value
                requiresRedraw = True
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Threshold value from which threshold area will be marked.
    ''' </summary>
    <DefaultValue(60), RefreshProperties(RefreshProperties.All), Description("Threshold value from which threshold area will be marked.")>
    Public Property RecommendedValue() As Single
        Get
            Return m_recommendedValue
        End Get
        Set(ByVal value As Single)
            If value >= m_minValue AndAlso value <= m_maxValue Then
                m_recommendedValue = value
                requiresRedraw = True
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Value where the pointer will point to.
    ''' </summary>
    <DefaultValue(0), RefreshProperties(RefreshProperties.All), Description("Value where the pointer will point to.")>
    Public Property Value() As Single
        Get
            Return currentValue
        End Get
        Set(ByVal value As Single)
            If value >= m_minValue AndAlso value <= m_maxValue Then
                If m_maxValue = 100000 AndAlso value = 100000 Then
                    currentValue = 99999
                ElseIf value >= 10000 AndAlso value <= m_maxValue Then
                    currentValue = CInt(value)
                ElseIf value >= 1000 AndAlso value <= m_maxValue Then
                    currentValue = Math.Round(value, 1, MidpointRounding.AwayFromZero)
                ElseIf value >= 100 AndAlso value <= m_maxValue Then
                    currentValue = Math.Round(value, 2, MidpointRounding.AwayFromZero)
                ElseIf value >= 10 AndAlso value <= m_maxValue Then
                    currentValue = Math.Round(value, 3, MidpointRounding.AwayFromZero)
                Else
                    currentValue = Math.Round(value, 4, MidpointRounding.AwayFromZero)
                End If
            Else
                Exit Property
            End If
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Display digits background color opacity.
    ''' </summary>
    <DefaultValue(0), RefreshProperties(RefreshProperties.All), Description("Display digits background opacity (value 0-100).")>
    Public Property DigitsBackgroundOpacity() As Integer
        Get
            Return Me.m_digitBckgOpacity
        End Get
        Set(ByVal value As Integer)
            If value >= 0 AndAlso value <= 100 Then
                Me.m_digitBckgOpacity = value
                requiresRedraw = True
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Ruler divisions color
    ''' </summary>
    <DefaultValue(GetType(Color), "Red"), RefreshProperties(RefreshProperties.All), Description("Ruler Divisions color")>
    Public Property RulerDivisionsColor() As Color
        Get
            Return Me.m_rulerDivColor
        End Get
        Set(ByVal value As Color)
            Me.m_rulerDivColor = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Ruler subdivisions color
    ''' </summary>
    <DefaultValue(GetType(Color), "DarkOrange"), RefreshProperties(RefreshProperties.All), Description("Ruler SubDivisions color")>
    Public Property RulerSubDivisionsColor() As Color
        Get
            Return Me.m_rulerSubDivColor
        End Get
        Set(ByVal value As Color)
            Me.m_rulerSubDivColor = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Display digits background color
    ''' </summary>
    <DefaultValue(GetType(Color), "Black"), RefreshProperties(RefreshProperties.All), Description("Display digits background color")>
    Public Property DigitsBackgroundColor() As Color
        Get
            Return Me.m_digitBckgColor
        End Get
        Set(ByVal value As Color)
            Me.m_digitBckgColor = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Display digits color
    ''' </summary>
    <DefaultValue(GetType(Color), "DodgerBlue"), RefreshProperties(RefreshProperties.All), Description("Display digits color")>
    Public Property DigitsColor() As Color
        Get
            Return m_digitColor
        End Get
        Set(ByVal value As Color)
            m_digitColor = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Needle color
    ''' </summary>
    <DefaultValue(GetType(Color), "Cyan"), RefreshProperties(RefreshProperties.All), Description("Needle color")>
    Public Property NeedleColor() As Color
        Get
            Return m_needleColor
        End Get
        Set(ByVal value As Color)
            m_needleColor = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Rim color
    ''' </summary>
    <DefaultValue(GetType(Color), "White"), RefreshProperties(RefreshProperties.All), Description("Rim color")>
    Public Property RimColor() As Color
        Get
            Return m_rimColor
        End Get
        Set(ByVal value As Color)
            m_rimColor = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Threshold area color
    ''' </summary>
    <DefaultValue(GetType(Color), "LawnGreen"), RefreshProperties(RefreshProperties.All), Description("Threshold area color")>
    Public Property ThresholdColor() As Color
        Get
            Return m_thresholdColor
        End Get
        Set(ByVal value As Color)
            m_thresholdColor = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Background color of the dial
    ''' </summary>
    <DefaultValue(GetType(Color), "Black"), RefreshProperties(RefreshProperties.All), Description("Background color of the dial")>
    Public Property DialColor() As Color
        Get
            Return m_dialColor
        End Get
        Set(ByVal value As Color)
            m_dialColor = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Glossiness strength. Range: 0-100
    ''' </summary>
    <DefaultValue(55), RefreshProperties(RefreshProperties.All), Description("Glossiness strength. Range: 0-100")>
    Public Property Glossiness() As Single
        Get
            Return (glossinessAlpha * 100) / 220
        End Get
        Set(ByVal value As Single)
            Dim val As Single = value
            If val > 100 Then
                value = 100
            End If
            If val < 0 Then
                value = 0
            End If
            glossinessAlpha = (value * 220) / 100
            Me.Refresh()
        End Set
    End Property

    ''' <summary>
    ''' Get or Sets the number of Divisions in the dial scale (up to 25).
    ''' </summary>
    <DefaultValue(10), RefreshProperties(RefreshProperties.All), Description("Get or Sets the number of Divisions in the dial scale (up to 25).")>
    Public Property NoOfDivisions() As Integer
        Get
            Return Me.m_noOfDivisions
        End Get
        Set(ByVal value As Integer)
            If value > 1 AndAlso value < 25 Then
                Me.m_noOfDivisions = value
                requiresRedraw = True
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or Sets the number of Sub Divisions in the scale per Division (up to 10).
    ''' </summary>
    <DefaultValue(4), RefreshProperties(RefreshProperties.All), Description("Gets or Sets the number of Sub Divisions in the scale per Division (up to 10).")>
    Public Property NoOfSubDivisions() As Integer
        Get
            Return Me.m_noOfSubDivisions
        End Get
        Set(ByVal value As Integer)
            If value > 0 AndAlso value <= 10 Then
                Me.m_noOfSubDivisions = value
                requiresRedraw = True
                Me.Invalidate()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or Sets the Text to be displayed in the dial
    ''' </summary>
    <RefreshProperties(RefreshProperties.All), Description("Gets or Sets the Text to be displayed in the dial")>
    Public Property DialText() As String
        Get
            Return Me.m_dialText
        End Get
        Set(ByVal value As String)
            Me.m_dialText = value
            requiresRedraw = True
            Me.Invalidate()
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            If String.Compare(MyBase.Text, value) <> 0 Then
                MyBase.Text = value
                Me.Invalidate()
            End If
        End Set
    End Property

    '''' <summary>
    '''' Enables or Disables Transparent Background color.
    '''' Note: Enabling this will reduce the performance and may make the control flicker.
    '''' </summary>
    '<DefaultValue(False)>
    '<Description("Enables or Disables Transparent Background color. Note: Enabling this will reduce the performance and may make the control flicker.")>
    'Public Property EnableTransparentBackground() As Boolean
    '    Get
    '        Return Me.m_enableTransparentBackground
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Me.m_enableTransparentBackground = value
    '        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, Not m_enableTransparentBackground)
    '        requiresRedraw = True
    '        Me.Refresh()
    '    End Set
    'End Property

#End Region

#Region "Overriden Control methods"

    ''' <summary>
    ''' Draws the pointer.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        wdth = Me.Width - x * 2
        hght = Me.Height - y * 2
        DrawPointer(e.Graphics, ((wdth) \ 2) + x, ((hght) \ 2) + y)
    End Sub

    ''' <summary>
    ''' Draws the dial background.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        'If Not m_enableTransparentBackground Then
        MyBase.OnPaintBackground(e)
        'End If

        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), New Rectangle(0, 0, Width, Height))
        If backgroundImg Is Nothing OrElse requiresRedraw Then
            backgroundImg = New Bitmap(Me.Width, Me.Height)
            Dim g As Graphics = Graphics.FromImage(backgroundImg)
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            wdth = Me.Width - x * 2
            hght = Me.Height - y * 2
            rectImg = New Rectangle(x, y, wdth, hght)

            'Draw background color
            Using backGroundBrush As Brush = New SolidBrush(Color.FromArgb(220, m_dialColor))
                g.FillEllipse(New SolidBrush(Color.Black), x, y, wdth, hght)
                g.FillEllipse(backGroundBrush, x, y, wdth, hght)
            End Using

            'Draw Rim
            Using outlineBrush As New SolidBrush(Color.FromArgb(100, Color.SlateGray))
                Dim outline As New Pen(outlineBrush, CSng(wdth * 0.03))
                g.DrawEllipse(outline, rectImg)
                g.DrawEllipse(New Pen(Color.SlateGray), x, y, wdth, hght)
            End Using

            'Draw Callibration
            DrawCalibration(g, rectImg, ((wdth) \ 2) + x, ((hght) \ 2) + y)

            'Draw Colored Rim
            Dim colorPen As New Pen(Color.FromArgb(190, m_rimColor), Me.Width \ 40)
            Dim gap As Integer = CInt(Math.Truncate(Me.Width * 0.03F))
            Dim rectg As New Rectangle(rectImg.X + gap, rectImg.Y + gap, rectImg.Width - gap * 2, rectImg.Height - gap * 2)
            g.DrawArc(colorPen, rectg, 135, 270)

            'Draw Threshold
            colorPen = New Pen(Color.FromArgb(200, m_thresholdColor), Me.Width \ 50)
            rectg = New Rectangle(rectImg.X + gap, rectImg.Y + gap, rectImg.Width - gap * 2, rectImg.Height - gap * 2)
            Dim val As Single = MaxValue - MinValue
            val = (MaxValue * (Me.m_recommendedValue - MinValue)) / val
            val = ((toAngle - fromAngle) * val) / MaxValue
            val += fromAngle
            Dim stAngle As Single = val - ((270 * threshold) / 200)
            If stAngle <= 135 Then
                stAngle = 135
            End If
            Dim sweepAngle As Single = ((270 * threshold) / 100)
            If stAngle + sweepAngle > 405 Then
                sweepAngle = 405 - stAngle
            End If
            g.DrawArc(colorPen, rectg, stAngle, sweepAngle)

            'Draw Digital Value
            Dim digiRect As New RectangleF(CSng(Me.Width) / 2.0F - CSng(Me.wdth) / 5.0F, CSng(Me.hght) / 1.19F, CSng(Me.wdth) / 2.5F, CSng(Me.Height) / 9.0F)
            Dim digiFRect As New RectangleF(Me.Width / 2 - Me.wdth / 7, Math.Truncate(Me.hght / 1.16), Me.wdth / 4, Me.Height / 12)
            g.FillRectangle(New SolidBrush(Color.FromArgb(m_digitBckgOpacity, Me.DigitsBackgroundColor)), digiRect)
            DisplayNumber(g, Me.currentValue, digiFRect)

            'Draw Aqua Gauge text
            Dim textSize1 As SizeF = g.MeasureString("Aqua Gauge", New Font("Mistral", Me.Font.Size, FontStyle.Regular))
            Dim digiFRectText1 As New RectangleF(Me.Width / 2 - textSize1.Width / 2, Math.Truncate(Me.hght / 3.7), textSize1.Width, textSize1.Height)
            g.DrawString("Aqua Gauge", New Font("Mistral", Me.Font.Size, FontStyle.Regular), New SolidBrush(ControlPaint.LightLight(Me.NeedleColor)), digiFRectText1)

            'Draw Dial Text
            Dim textSize2 As SizeF = g.MeasureString(Me.m_dialText, Me.Font)
            Dim digiFRectText2 As New RectangleF(Me.Width / 2 - textSize2.Width / 2, CInt(Math.Truncate(Me.hght / 1.425)), textSize2.Width, textSize2.Height)
            g.DrawString(m_dialText, Me.Font, New SolidBrush(Me.ForeColor), digiFRectText2)
        End If
        e.Graphics.DrawImage(backgroundImg, rectImg)

        If Not String.IsNullOrEmpty(Me.Text) Then
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Color.White), New Point(Me.Width / 2, Me.Height / 2.75), sf)
        End If

        requiresRedraw = True
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20
            Return cp
        End Get
    End Property

#End Region

#Region "Private methods"

    ''' <summary>
    ''' Draws the Pointer.
    ''' </summary>
    ''' <param name="gr"></param>
    ''' <param name="cx"></param>
    ''' <param name="cy"></param>
    Private Sub DrawPointer(ByVal gr As Graphics, ByVal cx As Integer, ByVal cy As Integer)
        Dim radius As Single = Me.Width \ 2 - (Me.Width * 0.12F)
        Dim val As Single = MaxValue - MinValue

        Dim img As Image = New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(img)
        g.SmoothingMode = SmoothingMode.AntiAlias

        val = (100 * (Me.currentValue - MinValue)) / val
        val = ((toAngle - fromAngle) * val) / 100
        val += fromAngle

        Dim angle As Single = GetRadian(val)
        Dim gradientAngle As Single = angle

        Dim pts As PointF() = New PointF(4) {}

        pts(0).X = CSng(cx + radius * Math.Cos(angle))
        pts(0).Y = CSng(cy + radius * Math.Sin(angle))

        pts(4).X = CSng(cx + radius * Math.Cos(angle - 0.02))
        pts(4).Y = CSng(cy + radius * Math.Sin(angle - 0.02))

        angle = GetRadian((val + 20))
        pts(1).X = CSng(cx + (Me.Width * 0.09F) * Math.Cos(angle))
        pts(1).Y = CSng(cy + (Me.Width * 0.09F) * Math.Sin(angle))

        pts(2).X = cx
        pts(2).Y = cy

        angle = GetRadian((val - 20))
        pts(3).X = CSng(cx + (Me.Width * 0.09F) * Math.Cos(angle))
        pts(3).Y = CSng(cy + (Me.Width * 0.09F) * Math.Sin(angle))

        Dim pointer As Brush = New SolidBrush(ControlPaint.Dark(Me.m_needleColor))
        g.FillPolygon(pointer, pts)

        Dim shinePts As PointF() = New PointF(2) {}
        angle = GetRadian(val)
        shinePts(0).X = CSng(cx + radius * Math.Cos(angle))
        shinePts(0).Y = CSng(cy + radius * Math.Sin(angle))

        angle = GetRadian(val + 20)
        shinePts(1).X = CSng(cx + (Me.Width * 0.09F) * Math.Cos(angle))
        shinePts(1).Y = CSng(cy + (Me.Width * 0.09F) * Math.Sin(angle))

        shinePts(2).X = cx
        shinePts(2).Y = cy

        Dim gpointer As New LinearGradientBrush(shinePts(0), shinePts(2), ControlPaint.Light(Me.m_needleColor), ControlPaint.Dark(Me.m_needleColor))
        g.FillPolygon(gpointer, shinePts)

        Dim rect As New Rectangle(x, y, wdth, hght)
        DrawCenterPoint(g, rect, ((wdth) \ 2) + x, ((hght) \ 2) + y)

        DrawGloss(g)

        gr.DrawImage(img, 0, 0)
    End Sub

    ''' <summary>
    ''' Draws the glossiness.
    ''' </summary>
    ''' <param name="g"></param>
    Private Sub DrawGloss(ByVal g As Graphics)
        Dim glossRect As New RectangleF(x + CSng(wdth * 0.1), y + CSng(hght * 0.07), CSng(wdth * 0.8), CSng(hght * 0.7))
        Dim gradientBrush As New LinearGradientBrush(glossRect, Color.FromArgb(CInt(Math.Truncate(glossinessAlpha)), Color.White), Color.Transparent, LinearGradientMode.Vertical)
        g.FillEllipse(gradientBrush, glossRect)

        'TODO: Gradient from bottom
        glossRect = New RectangleF(x + CSng(wdth * 0.25), y + CSng(hght * 0.77), CSng(wdth * 0.5), CSng(hght * 0.2))
        Dim gloss As Integer = CInt(Math.Truncate(glossinessAlpha / 3))
        gradientBrush = New LinearGradientBrush(glossRect, Color.Transparent, Color.FromArgb(gloss, Me.BackColor), LinearGradientMode.Vertical)
        g.FillEllipse(gradientBrush, glossRect)
    End Sub

    ''' <summary>
    ''' Draws the center point.
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="rect"></param>
    ''' <param name="cX"></param>
    ''' <param name="cY"></param>
    Private Sub DrawCenterPoint(ByVal g As Graphics, ByVal rect As Rectangle, ByVal cX As Integer, ByVal cY As Integer)
        Dim shift As Single = Width \ 5
        Dim rectangle As New RectangleF(cX - (shift / 2), cY - (shift / 2), shift, shift)
        Dim brush As New LinearGradientBrush(rect, Color.Black, Color.FromArgb(100, Me.m_dialColor), LinearGradientMode.Vertical)
        g.FillEllipse(brush, rectangle)

        shift = Width \ 7
        rectangle = New RectangleF(cX - (shift / 2), cY - (shift / 2), shift, shift)
        brush = New LinearGradientBrush(rect, Color.SlateGray, Color.Black, LinearGradientMode.ForwardDiagonal)
        g.FillEllipse(brush, rectangle)
    End Sub

    ''' <summary>
    ''' Draws the Ruler
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="rect"></param>
    ''' <param name="cX"></param>
    ''' <param name="cY"></param>
    Private Sub DrawCalibration(ByVal g As Graphics, ByVal rect As Rectangle, ByVal cX As Integer, ByVal cY As Integer)
        Dim noOfParts As Integer = Me.m_noOfDivisions + 1
        Dim noOfIntermediates As Integer = Me.m_noOfSubDivisions
        Dim currentAngle As Single = GetRadian(fromAngle)
        Dim gap As Integer = CInt(Math.Truncate(Me.Width * 0.01F))
        Dim shift As Single = Me.Width \ 25
        Dim rectangle As New Rectangle(rect.Left + gap, rect.Top + gap, rect.Width - gap, rect.Height - gap)

        Dim x As Single, y As Single, x1 As Single, y1 As Single, tx As Single, ty As Single, radius As Single
        radius = rectangle.Width \ 2 - gap * 5
        Dim totalAngle As Single = toAngle - fromAngle
        Dim incr As Single = GetRadian(((totalAngle) / ((noOfParts - 1) * (noOfIntermediates + 1))))

        Dim thickPen As New Pen(Me.m_rulerDivColor, Width \ 50)
        Dim thinPen As New Pen(Me.m_rulerSubDivColor, Width \ 100)
        Dim rulerValue As Single = MinValue
        For i As Integer = 0 To noOfParts
            'Draw Thick Line
            x = CSng(cX + radius * Math.Cos(currentAngle))
            y = CSng(cY + radius * Math.Sin(currentAngle))
            x1 = CSng(cX + (radius - Width \ 20) * Math.Cos(currentAngle))
            y1 = CSng(cY + (radius - Width \ 20) * Math.Sin(currentAngle))
            g.DrawLine(thickPen, x, y, x1, y1)

            'Draw Strings
            Dim format As New StringFormat()
            tx = CSng(cX + (radius - Width \ 10) * Math.Cos(currentAngle))
            ty = CSng(cY - shift + (radius - Width \ 10) * Math.Sin(currentAngle))
            Dim stringPen As Brush = New SolidBrush(Me.ForeColor)
            Dim strFormat As New StringFormat(StringFormatFlags.NoClip)
            strFormat.Alignment = StringAlignment.Center
            Dim f As New Font(Me.Font.FontFamily, CSng(Me.Width \ 23), Me.Font.Style)
            g.DrawString(rulerValue.ToString() & String.Empty, f, stringPen, New PointF(tx, ty), strFormat)
            rulerValue += CSng((MaxValue - MinValue) / (noOfParts - 1))
            rulerValue = CSng(Math.Round(rulerValue, 2))

            'currentAngle += incr;
            If i = noOfParts - 1 Then
                Exit For
            End If
            For j As Integer = 0 To noOfIntermediates
                'Draw thin lines 
                currentAngle += incr
                x = CSng(cX + radius * Math.Cos(currentAngle))
                y = CSng(cY + radius * Math.Sin(currentAngle))
                x1 = CSng(cX + (radius - Width \ 50) * Math.Cos(currentAngle))
                y1 = CSng(cY + (radius - Width \ 50) * Math.Sin(currentAngle))
                g.DrawLine(thinPen, x, y, x1, y1)
            Next
        Next
    End Sub

    ''' <summary>
    ''' Converts the given degree to radian.
    ''' </summary>
    ''' <param name="theta"></param>
    ''' <returns></returns>
    Public Function GetRadian(ByVal theta As Single) As Single
        Return theta * CSng(Math.PI) / 180.0F
    End Function

    ''' <summary>
    ''' Displays the given number in the 7-Segement format.
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="number"></param>
    ''' <param name="drect"></param>
    Private Sub DisplayNumber(ByVal g As Graphics, ByVal number As Single, ByVal drect As RectangleF)
        Try
            Dim num As String
            If currentValue >= 10000 AndAlso currentValue <= m_maxValue Then
                num = number.ToString("00000")
            ElseIf currentValue >= 1000 AndAlso currentValue <= m_maxValue Then
                num = number.ToString("0000.0")
            ElseIf currentValue >= 100 AndAlso currentValue <= m_maxValue Then
                num = number.ToString("000.00")
            ElseIf currentValue >= 10 AndAlso currentValue <= m_maxValue Then
                num = number.ToString("00.000")
            Else
                num = number.ToString("0.0000")
            End If
            Dim shift As Single = 0
            If number < 0 Then
                shift -= wdth \ 17
            End If
            Dim drawDPS As Boolean = False
            Dim chars As Char() = num.ToCharArray()
            For i As Integer = 0 To chars.Length - 1
                Dim c As Char = chars(i)
                If i < chars.Length - 1 AndAlso chars(i + 1) = "."c Then
                    drawDPS = True
                Else
                    drawDPS = False
                End If
                If c <> "."c Then
                    If c = "-"c Then
                        DrawDigit(g, -1, New PointF(drect.X + shift, drect.Y), drawDPS, drect.Height)
                    Else
                        DrawDigit(g, Int16.Parse(c.ToString()), New PointF(drect.X + shift, drect.Y), drawDPS, drect.Height)
                    End If
                    shift += 15 * Me.wdth \ 250
                Else
                    shift += 2 * Me.wdth \ 250
                End If
            Next
        Catch generatedExceptionName As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Draws a digit in 7-Segement format.
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="number"></param>
    ''' <param name="position"></param>
    ''' <param name="dp"></param>
    ''' <param name="height"></param>
    Private Sub DrawDigit(ByVal g As Graphics, ByVal number As Integer, ByVal position As PointF, ByVal dp As Boolean, ByVal height As Single)
        Dim width As Single
        width = 10.0F * height / 13

        Dim outline As New Pen(Color.FromArgb(50, Me.m_dialColor))
        Dim fillPen As New Pen(Me.DigitsColor)

        '#Region "Form Polygon Points"
        'Segment A
        Dim segmentA As PointF() = New PointF(4) {}
        segmentA(0) = InlineAssignHelper(segmentA(4), New PointF(position.X + GetX(2.8F, width), position.Y + GetY(1.0F, height)))
        segmentA(1) = New PointF(position.X + GetX(10, width), position.Y + GetY(1.0F, height))
        segmentA(2) = New PointF(position.X + GetX(8.8F, width), position.Y + GetY(2.0F, height))
        segmentA(3) = New PointF(position.X + GetX(3.8F, width), position.Y + GetY(2.0F, height))

        'Segment B
        Dim segmentB As PointF() = New PointF(4) {}
        segmentB(0) = InlineAssignHelper(segmentB(4), New PointF(position.X + GetX(10, width), position.Y + GetY(1.4F, height)))
        segmentB(1) = New PointF(position.X + GetX(9.3F, width), position.Y + GetY(6.8F, height))
        segmentB(2) = New PointF(position.X + GetX(8.4F, width), position.Y + GetY(6.4F, height))
        segmentB(3) = New PointF(position.X + GetX(9.0F, width), position.Y + GetY(2.2F, height))

        'Segment C
        Dim segmentC As PointF() = New PointF(4) {}
        segmentC(0) = InlineAssignHelper(segmentC(4), New PointF(position.X + GetX(9.2F, width), position.Y + GetY(7.2F, height)))
        segmentC(1) = New PointF(position.X + GetX(8.7F, width), position.Y + GetY(12.7F, height))
        segmentC(2) = New PointF(position.X + GetX(7.6F, width), position.Y + GetY(11.9F, height))
        segmentC(3) = New PointF(position.X + GetX(8.2F, width), position.Y + GetY(7.7F, height))

        'Segment D
        Dim segmentD As PointF() = New PointF(4) {}
        segmentD(0) = InlineAssignHelper(segmentD(4), New PointF(position.X + GetX(7.4F, width), position.Y + GetY(12.1F, height)))
        segmentD(1) = New PointF(position.X + GetX(8.4F, width), position.Y + GetY(13.0F, height))
        segmentD(2) = New PointF(position.X + GetX(1.3F, width), position.Y + GetY(13.0F, height))
        segmentD(3) = New PointF(position.X + GetX(2.2F, width), position.Y + GetY(12.1F, height))

        'Segment E
        Dim segmentE As PointF() = New PointF(4) {}
        segmentE(0) = InlineAssignHelper(segmentE(4), New PointF(position.X + GetX(2.2F, width), position.Y + GetY(11.8F, height)))
        segmentE(1) = New PointF(position.X + GetX(1.0F, width), position.Y + GetY(12.7F, height))
        segmentE(2) = New PointF(position.X + GetX(1.7F, width), position.Y + GetY(7.2F, height))
        segmentE(3) = New PointF(position.X + GetX(2.8F, width), position.Y + GetY(7.7F, height))

        'Segment F
        Dim segmentF As PointF() = New PointF(4) {}
        segmentF(0) = InlineAssignHelper(segmentF(4), New PointF(position.X + GetX(3.0F, width), position.Y + GetY(6.4F, height)))
        segmentF(1) = New PointF(position.X + GetX(1.8F, width), position.Y + GetY(6.8F, height))
        segmentF(2) = New PointF(position.X + GetX(2.6F, width), position.Y + GetY(1.3F, height))
        segmentF(3) = New PointF(position.X + GetX(3.6F, width), position.Y + GetY(2.2F, height))

        'Segment G
        Dim segmentG As PointF() = New PointF(6) {}
        segmentG(0) = InlineAssignHelper(segmentG(6), New PointF(position.X + GetX(2.0F, width), position.Y + GetY(7.0F, height)))
        segmentG(1) = New PointF(position.X + GetX(3.1F, width), position.Y + GetY(6.5F, height))
        segmentG(2) = New PointF(position.X + GetX(8.3F, width), position.Y + GetY(6.5F, height))
        segmentG(3) = New PointF(position.X + GetX(9.0F, width), position.Y + GetY(7.0F, height))
        segmentG(4) = New PointF(position.X + GetX(8.2F, width), position.Y + GetY(7.5F, height))
        segmentG(5) = New PointF(position.X + GetX(2.9F, width), position.Y + GetY(7.5F, height))

        'Segment DP
        '#End Region

        '#Region "Draw Segments Outline"
        g.FillPolygon(outline.Brush, segmentA)
        g.FillPolygon(outline.Brush, segmentB)
        g.FillPolygon(outline.Brush, segmentC)
        g.FillPolygon(outline.Brush, segmentD)
        g.FillPolygon(outline.Brush, segmentE)
        g.FillPolygon(outline.Brush, segmentF)
        g.FillPolygon(outline.Brush, segmentG)
        '#End Region

        '#Region "Fill Segments"
        'Fill SegmentA
        If IsNumberAvailable(number, 0, 2, 3, 5, 6,
         7, 8, 9) Then
            g.FillPolygon(fillPen.Brush, segmentA)
        End If

        'Fill SegmentB
        If IsNumberAvailable(number, 0, 1, 2, 3, 4,
         7, 8, 9) Then
            g.FillPolygon(fillPen.Brush, segmentB)
        End If

        'Fill SegmentC
        If IsNumberAvailable(number, 0, 1, 3, 4, 5,
         6, 7, 8, 9) Then
            g.FillPolygon(fillPen.Brush, segmentC)
        End If

        'Fill SegmentD
        If IsNumberAvailable(number, 0, 2, 3, 5, 6,
         8, 9) Then
            g.FillPolygon(fillPen.Brush, segmentD)
        End If

        'Fill SegmentE
        If IsNumberAvailable(number, 0, 2, 6, 8) Then
            g.FillPolygon(fillPen.Brush, segmentE)
        End If

        'Fill SegmentF
        If IsNumberAvailable(number, 0, 4, 5, 6, 7,
         8, 9) Then
            g.FillPolygon(fillPen.Brush, segmentF)
        End If

        'Fill SegmentG
        If IsNumberAvailable(number, 2, 3, 4, 5, 6,
         8, 9, -1) Then
            g.FillPolygon(fillPen.Brush, segmentG)
        End If
        '#End Region

        'Draw decimal point
        If dp Then
            g.FillEllipse(fillPen.Brush, New RectangleF(position.X + GetX(10.0F, width), position.Y + GetY(12.0F, height), width / 7, width / 7))
        End If
    End Sub

    ''' <summary>
    ''' Gets Relative X for the given width to draw digit
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="width"></param>
    ''' <returns></returns>
    Private Function GetX(ByVal x As Single, ByVal width As Single) As Single
        Return x * width / 12
    End Function

    ''' <summary>
    ''' Gets relative Y for the given height to draw digit
    ''' </summary>
    ''' <param name="y"></param>
    ''' <param name="height"></param>
    ''' <returns></returns>
    Private Function GetY(ByVal y As Single, ByVal height As Single) As Single
        Return y * height / 15
    End Function

    ''' <summary>
    ''' Returns true if a given number is available in the given list.
    ''' </summary>
    ''' <param name="number"></param>
    ''' <param name="listOfNumbers"></param>
    ''' <returns></returns>
    Private Function IsNumberAvailable(ByVal number As Integer, ByVal ParamArray listOfNumbers As Integer()) As Boolean
        If listOfNumbers.Length > 0 Then
            For Each i As Integer In listOfNumbers
                If i = number Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    ''' <summary>
    ''' Restricts the size to make sure the height and width are always same.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AquaGauge_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Me.Width = Me.Height
        Me.requiresRedraw = True
        Me.Invalidate()
    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

#End Region

End Class

