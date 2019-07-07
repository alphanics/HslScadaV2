Imports Microsoft.VisualBasic.CompilerServices
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class FlowArrowHatched
    Inherits Control



    Private BlinkTimer As Timer

    Private m_hatchStyle As FlowArrowHatched.HStyle

    Private m_arrowColor As Color

    Private m_valueFlow As Boolean

    Private _blinkInterval As Integer

    Private m_dir As FlowArrowHatched.Dir

    Private flagTimer As Boolean

    <Browsable(True), DefaultValue(500), Description("The active arrow blinking interval in milliseconds."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowBlinkInterval() As Integer
        Get
            Return Me._blinkInterval
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 500
            End If
            If value < 0 Then
                value = 500
            End If
            If Me._blinkInterval <> value Then
                Me._blinkInterval = value
                Me.BlinkTimer.Interval = Me._blinkInterval
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(GetType(Color), "DarkGreen"), Description("The arrow color."), RefreshProperties(RefreshProperties.All)>
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

    <Browsable(True), DefaultValue(2), Description("The direction of the arrow."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowDirection() As FlowArrowHatched.Dir
        Get
            Return Me.m_dir
        End Get
        Set(ByVal value As FlowArrowHatched.Dir)
            Me.m_dir = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), DefaultValue(34), Description("The arrow hatch style.")>
    Public Property ArrowHatchStyle() As FlowArrowHatched.HStyle
        Get
            Return Me.m_hatchStyle
        End Get
        Set(ByVal value As FlowArrowHatched.HStyle)
            Me.m_hatchStyle = value
            Me.Invalidate()
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



    Public Sub New()
        Dim flowArrowHatched As FlowArrowHatched = Me
        AddHandler MyBase.Click, AddressOf flowArrowHatched.FlowArrowHatched_Click

        Me.m_hatchStyle = HStyle.SmallConfetti
        Me.m_arrowColor = Color.PaleGreen
        Me._blinkInterval = 500
        Me.m_dir = Dir.Left
        Me.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.Transparent
        Dim m_size As New Size(121, 121)
        Me.Size = m_size
        m_size = New Size(28, 28)
        Me.MinimumSize = m_size
        Me.BlinkTimer = New Timer() With {
            .Interval = Me._blinkInterval,
            .Enabled = False
        }
        Me.flagTimer = False
    End Sub
    Private Sub FlowArrowHatched_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Focus()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim pointF As PointF
        Dim pointF1 As PointF
        Dim pointF2 As PointF
        Dim pointF3 As PointF
        Dim pointF4 As PointF
        Dim pointF5 As PointF
        Dim pointF6 As PointF
        Dim pointFArray() As PointF
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim pointFArray1() As PointF = Nothing
        If Me.m_dir = FlowArrowHatched.Dir.Left Then
            pointFArray = New PointF(6) {}
            pointF = New PointF(0.0F, CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(0) = pointF
            pointF1 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, 0.0F)
            pointFArray(1) = pointF1
            pointF2 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height) * 2.1F / 7.0F)
            pointFArray(2) = pointF2
            pointF3 = New PointF(CSng(Me.Width - 1), CSng(Me.Height) * 2.1F / 7.0F)
            pointFArray(3) = pointF3
            pointF4 = New PointF(CSng(Me.Width - 1), CSng(Me.Height) * 4.9F / 7.0F)
            pointFArray(4) = pointF4
            pointF5 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height) * 4.9F / 7.0F)
            pointFArray(5) = pointF5
            pointF6 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height - 1))
            pointFArray(6) = pointF6
            pointFArray1 = pointFArray
        End If
        If Me.m_dir = FlowArrowHatched.Dir.Right Then
            pointFArray = New PointF(6) {}
            pointF6 = New PointF(0.0F, CSng(Me.Height) * 2.1F / 7.0F)
            pointFArray(0) = pointF6
            pointF5 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height) * 2.1F / 7.0F)
            pointFArray(1) = pointF5
            pointF4 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, 0.0F)
            pointFArray(2) = pointF4
            pointF3 = New PointF(CSng(Me.Width - 1), CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(3) = pointF3
            pointF2 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height - 1))
            pointFArray(4) = pointF2
            pointF1 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height) * 4.9F / 7.0F)
            pointFArray(5) = pointF1
            pointF = New PointF(0.0F, CSng(Me.Height) * 4.9F / 7.0F)
            pointFArray(6) = pointF
            pointFArray1 = pointFArray
        End If
        If Me.m_dir = FlowArrowHatched.Dir.Up Then
            pointFArray = New PointF(6) {}
            pointF6 = New PointF(0.0F, CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(0) = pointF6
            pointF5 = New PointF(CSng(Me.Width) * 3.5F / 7.0F, 0.0F)
            pointFArray(1) = pointF5
            pointF4 = New PointF(CSng(Me.Width - 1), CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(2) = pointF4
            pointF3 = New PointF(CSng(Me.Width) * 4.9F / 7.0F, CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(3) = pointF3
            pointF2 = New PointF(CSng(Me.Width) * 4.9F / 7.0F, CSng(Me.Height - 1))
            pointFArray(4) = pointF2
            pointF1 = New PointF(CSng(Me.Width) * 2.1F / 7.0F, CSng(Me.Height - 1))
            pointFArray(5) = pointF1
            pointF = New PointF(CSng(Me.Width) * 2.1F / 7.0F, CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(6) = pointF
            pointFArray1 = pointFArray
        End If
        If Me.m_dir = FlowArrowHatched.Dir.Down Then
            pointFArray = New PointF(6) {}
            pointF6 = New PointF(0.0F, CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(0) = pointF6
            pointF5 = New PointF(CSng(Me.Width) * 2.1F / 7.0F, CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(1) = pointF5
            pointF4 = New PointF(CSng(Me.Width) * 2.1F / 7.0F, 0.0F)
            pointFArray(2) = pointF4
            pointF3 = New PointF(CSng(Me.Width) * 4.9F / 7.0F, 0.0F)
            pointFArray(3) = pointF3
            pointF2 = New PointF(CSng(Me.Width) * 4.9F / 7.0F, CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(4) = pointF2
            pointF1 = New PointF(CSng(Me.Width - 1), CSng(Me.Height) * 3.5F / 7.0F)
            pointFArray(5) = pointF1
            pointF = New PointF(CSng(Me.Width) * 3.5F / 7.0F, CSng(Me.Height - 1))
            pointFArray(6) = pointF
            pointFArray1 = pointFArray
        End If
        If Not Me.flagTimer Then
            Using hatchBrush As New HatchBrush(CType(Me.m_hatchStyle, HatchStyle), ControlPaint.Light(Me.m_arrowColor))
                e.Graphics.DrawPolygon(New Pen(New SolidBrush(ControlPaint.Dark(Me.m_arrowColor)), 2.0F), pointFArray1)
                e.Graphics.FillPolygon(hatchBrush, pointFArray1)
            End Using
        Else
            Using hatchBrush1 As New HatchBrush(CType(Me.m_hatchStyle, HatchStyle), ControlPaint.Dark(Me.m_arrowColor))
                e.Graphics.DrawPolygon(New Pen(New SolidBrush(Me.m_arrowColor), 2.0F), pointFArray1)
                e.Graphics.FillPolygon(hatchBrush1, pointFArray1)
            End Using
        End If
        If Not String.IsNullOrEmpty(Me.Text) Then
            Dim stringFormat As New StringFormat() With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
            Dim graphics As Graphics = e.Graphics
            Dim text_Renamed As String = Me.Text
            Dim font_Renamed As Font = Me.Font
            Dim solidBrush As New SolidBrush(Me.ForeColor)
            Dim point As New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), CInt(Math.Round(CDbl(Me.Height) / 2)))
            graphics.DrawString(text_Renamed, font_Renamed, solidBrush, point, stringFormat)
        End If
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me.flagTimer = Not Me.flagTimer
        Me.Invalidate()
    End Sub

    Public Enum Dir
        Right
        Up
        Left
        Down
    End Enum

    Public Enum HStyle
        Horizontal
        Vertical
        ForwardDiagonal
        BackwardDiagonal
        Cross
        DiagonalCross
        Percent05
        Percent10
        Percent20
        Percent25
        Percent30
        Percent40
        Percent50
        Percent60
        Percent70
        Percent75
        Percent80
        Percent90
        LightDownwardDiagonal
        LightUpwardDiagonal
        DarkDownwardDiagonal
        DarkUpwardDiagonal
        WideDownwardDiagonal
        WideUpwardDiagonal
        LightVertical
        LightHorizontal
        NarrowVertical
        NarrowHorizontal
        DarkVertical
        DarkHorizontal
        DashedDownwardDiagonal
        DashedUpwardDiagonal
        DashedHorizontal
        DashedVertical
        SmallConfetti
        LargeConfetti
        ZigZag
        Wave
        DiagonalBrick
        HorizontalBrick
        Weave
        Plaid
        Divot
        DottedGrid
        DottedDiamond
        Shingle
        Trellis
        Sphere
        SmallGrid
        SmallCheckerBoard
        LargeCheckerBoard
        OutlinedDiamond
        SolidDiamond
    End Enum
End Class

