Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class FlowArrowSolid
    Inherits Control

    Private BlinkTimer As Timer

    Private incr As Single

    Private m_arrowColor As Color

    Private m_valueFlow As Boolean

    Private _blinkInterval As Integer

    Private _coeffInterval As Single

    Private m_Angle As FlowArrowSolid.Angle

    Private m_mode As FlowArrowSolid.AMode

    Private flagTimer As Boolean
#Region "Property"
    <Browsable(True), DefaultValue(GetType(Color), "BlueViolet"), Description("The arrow color."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowColor() As Color
        Get
            Return Me.m_arrowColor
        End Get
        Set(ByVal value As Color)
            If Me.m_arrowColor <> value Then
                Me.m_arrowColor = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(45), Description("The direction of the arrow."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowDirection() As FlowArrowSolid.Angle
        Get
            Return Me.m_Angle
        End Get
        Set(ByVal value As FlowArrowSolid.Angle)
            Me.m_Angle = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), DefaultValue(1), Description("The active arrow mode (Blink or Fill)."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowMode() As FlowArrowSolid.AMode
        Get
            Return Me.m_mode
        End Get
        Set(ByVal value As FlowArrowSolid.AMode)
            If Me.m_mode <> value Then
                Me.m_mode = value
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(5), Description("Coefficient to adjust the arrow fill rate (valid values 1 to 10)."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowTimerCoefficient() As Integer
        Get
            Return CInt(Math.Truncate(Math.Round(CDbl(Me._coeffInterval))))
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 5
            End If
            If value > 10 Then
                value = 10
            End If
            If value < 1 Then
                value = 1
            End If
            If Me._coeffInterval <> CSng(value) Then
                Me._coeffInterval = CSng(value)
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(100), Description("Interval in milliseconds to define arrow Blink/Fill rate."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowTimerInterval() As Integer
        Get
            Return Me._blinkInterval
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 100
            End If
            If value < 0 Then
                value = 100
            End If
            If Me._blinkInterval <> value Then
                Me._blinkInterval = value
                Me.BlinkTimer.Interval = Me._blinkInterval
                Me.Invalidate()
            End If
        End Set
    End Property



    Public Overrides Property Text() As String
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

    <Browsable(True), DefaultValue(False), Description("Indicates whether there is a flow."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As Boolean
        Get
            Return Me.m_valueFlow
        End Get
        Set(ByVal value As Boolean)
            If Me.m_valueFlow <> value Then
                Me.m_valueFlow = value
                If Not Me.m_valueFlow Then
                    Me.BlinkTimer.Enabled = False
                    Me.flagTimer = False
                Else
                    Me.BlinkTimer.Enabled = True
                End If
            End If
            Me.Invalidate()
        End Set
    End Property
#End Region

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.Width = Me.Height
    End Sub
    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        MyBase.OnClick(e)
        Me.Focus()
    End Sub

    Public Sub New()


        Me.incr = 1.0F
        Me.m_arrowColor = Color.BlueViolet
        Me._blinkInterval = 100
        Me._coeffInterval = 5.0F
        Me.m_Angle = FlowArrowSolid.Angle.NE
        Me.m_mode = FlowArrowSolid.AMode.Fill
        Me.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.Transparent
        Dim size_Renamed As New Size(121, 121)
        Me.Size = size_Renamed
        size_Renamed = New Size(28, 28)
        Me.MinimumSize = size_Renamed
        Me.BlinkTimer = New Timer() With {
            .Interval = Me._blinkInterval,
            .Enabled = False
        }
        Me.flagTimer = False
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim point As Point
        Dim point1 As Point
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim graphics As Graphics = e.Graphics
        Dim clientRectangle_Renamed As Rectangle = Me.ClientRectangle
        Dim width_Renamed As Single = CSng(clientRectangle_Renamed.Width) / 2.0F
        Dim rectangle As Rectangle = Me.ClientRectangle
        graphics.TranslateTransform(width_Renamed, CSng(rectangle.Height) / 2.0F)
        e.Graphics.RotateTransform(-CSng(Me.m_Angle))
        Dim graphic As Graphics = e.Graphics
        rectangle = Me.ClientRectangle
        Dim [single] As Single = -CSng(rectangle.Width) / 2.0F
        clientRectangle_Renamed = Me.ClientRectangle
        graphic.TranslateTransform([single], -CSng(clientRectangle_Renamed.Height) / 2.0F)
        Dim pointFArray(6) As PointF
        Dim pointF As New PointF(0.0F, CSng(Me.Height) * 2.1F / 7.0F)
        pointFArray(0) = pointF
        Dim pointF1 As New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height) * 2.1F / 7.0F)
        pointFArray(1) = pointF1
        Dim pointF2 As New PointF(CSng(Me.Width) * 3.5F / 7.0F, 0.0F)
        pointFArray(2) = pointF2
        Dim pointF3 As New PointF(CSng(Me.Width), CSng(Me.Height) * 3.5F / 7.0F)
        pointFArray(3) = pointF3
        Dim pointF4 As New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height))
        pointFArray(4) = pointF4
        Dim pointF5 As New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height) * 4.9F / 7.0F)
        pointFArray(5) = pointF5
        Dim pointF6 As New PointF(0.0F, CSng(Me.Height) * 4.9F / 7.0F)
        pointFArray(6) = pointF6
        Dim pointFArray1() As PointF = pointFArray
        pointF6 = New PointF(0.0F, 0.0F)
        Dim sizeF As New SizeF(Me.incr, CSng(Me.Height))
        Dim rectangleF As New RectangleF(pointF6, sizeF)
        Dim graphicsPath As New GraphicsPath()
        graphicsPath.AddPolygon(pointFArray1)
        Dim blend As New Blend(11)
        Dim singleArray() As Single = {0.0F, 0.1F, 0.2F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F, 1.0F}
        blend.Positions = singleArray
        singleArray = New Single() {0.0F, 0.0F, 0.1F, 0.2F, 0.3F, 0.5F, 0.3F, 0.2F, 0.1F, 0.0F, 0.0F}
        blend.Factors = singleArray
        If Me.m_mode = FlowArrowSolid.AMode.Fill Then
            point = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), 0)
            point1 = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), Me.Height)
            Using linearGradientBrush As New LinearGradientBrush(point, point1, Me.m_arrowColor, ControlPaint.LightLight(Me.m_arrowColor))
                linearGradientBrush.Blend = blend
                e.Graphics.DrawPolygon(New Pen(New SolidBrush(ControlPaint.Dark(Me.m_arrowColor)), 1.0F), pointFArray1)
                If Not Me.BlinkTimer.Enabled Then
                    e.Graphics.FillPolygon(linearGradientBrush, pointFArray1)
                ElseIf Me.incr <= CSng(Me.Width) + 10.0F Then
                    Dim region_Renamed As New Region(graphicsPath)
                    region_Renamed.Intersect(rectangleF)
                    e.Graphics.FillRegion(linearGradientBrush, region_Renamed)
                    Me.incr = Me.incr + Me._coeffInterval
                Else
                    Me.incr = 1.0F
                    Return
                End If
            End Using
        ElseIf Not Me.flagTimer Then
            point1 = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), 0)
            point = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), Me.Height)
            Using linearGradientBrush1 As New LinearGradientBrush(point1, point, Me.m_arrowColor, ControlPaint.LightLight(Me.m_arrowColor))
                linearGradientBrush1.Blend = blend
                e.Graphics.DrawPolygon(New Pen(New SolidBrush(ControlPaint.Dark(Me.m_arrowColor)), 1.0F), pointFArray1)
                e.Graphics.FillPolygon(linearGradientBrush1, pointFArray1)
            End Using
        Else
            point1 = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), 0)
            point = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), Me.Height)
            Using linearGradientBrush2 As New LinearGradientBrush(point1, point, ControlPaint.DarkDark(Me.m_arrowColor), ControlPaint.Dark(Me.m_arrowColor))
                linearGradientBrush2.Blend = blend
                e.Graphics.DrawPolygon(New Pen(New SolidBrush(ControlPaint.Dark(Me.m_arrowColor)), 1.0F), pointFArray1)
                e.Graphics.FillPolygon(linearGradientBrush2, pointFArray1)
            End Using
        End If
        e.Graphics.ResetTransform()
        If Not String.IsNullOrEmpty(Me.Text) Then
            Dim stringFormat As New StringFormat() With {
             .Alignment = StringAlignment.Center,
             .LineAlignment = StringAlignment.Center
            }
            Dim graphics1 As Graphics = e.Graphics
            Dim text_Renamed As String = Me.Text
            Dim font_Renamed As Font = Me.Font
            Dim solidBrush As New SolidBrush(Me.ForeColor)
            point1 = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), CInt(Math.Round(CDbl(Me.Height) / 2)))
            graphics1.DrawString(text_Renamed, font_Renamed, solidBrush, point1, stringFormat)
        End If
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me.flagTimer = Not Me.flagTimer
        Me.Invalidate()
    End Sub

    Public Enum AMode
        Blink
        Fill
    End Enum

    Public Enum Angle
        E = 0
        NE = 45
        N = 90
        NW = 135
        W = 180
        SW = 225
        S = 270
        SE = 315
    End Enum
End Class

