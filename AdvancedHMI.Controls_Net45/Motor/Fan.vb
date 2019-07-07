Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms



Public Class Fan
    Inherits Control


    Private FanFrame As Bitmap

    Private FanCenterCap As Bitmap

    Private FanBlades As Bitmap

    Private BackBuffer As Bitmap

    Private XScale As Single

    Private YScale As Single

    Private TextFormat As StringFormat

    Private TextRectangle As Rectangle


    Private _AnimateTimer As New Timer

    Private m_Value As Boolean

    Private _Direction As Boolean

    Private m_OutputType As OutputType

    Private SourceImageRatio As Decimal

    Private LastWidth As Integer

    Private LastHeight As Integer

    Private MatrixForRotation As Matrix

    Private AnimateGraphics As Graphics

    Private BladeCenterPoint As Point



    Public Property Direction() As Boolean
        Get
            Return Me._Direction
        End Get
        Set(ByVal value As Boolean)
            Me._Direction = value
        End Set
    End Property

    Public Property OutputType() As OutputType
        Get
            Return Me.m_OutputType
        End Get
        Set(ByVal value As OutputType)
            Me.m_OutputType = value
        End Set
    End Property

    Public Property TextPosition() As StringAlignment
        Get
            Return Me.TextFormat.LineAlignment
        End Get
        Set(ByVal value As StringAlignment)
            Me.TextFormat.LineAlignment = value
            Me.Invalidate()
        End Set
    End Property

    Public Property Value() As Boolean
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_Value Then
                Me.m_Value = value
                Me._AnimateTimer.Enabled = value And Not Me.DesignMode
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property


    Public Sub New()
        AddHandler _AnimateTimer.Tick, AddressOf AnimateTimer_Elapsed
        Me.m_OutputType = OutputType.MomentarySet
        Me.SourceImageRatio = New Decimal(Convert.ToInt32(CDbl(My.Resources.FanFrame.Height) / CDbl(My.Resources.FanFrame.Width)))
        Me.MatrixForRotation = New Matrix()
        Me.TextFormat = New StringFormat() With {.Alignment = StringAlignment.Center}
        Me._AnimateTimer.Interval = 250
    End Sub


    Private Sub Adjustsize()
        If Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width Then
            If CDbl(Me.Height) / CDbl(Me.Width) <= Convert.ToDouble(Me.SourceImageRatio) Then
                Me.Height = Convert.ToInt32(Decimal.Multiply(New Decimal(Me.Width), Me.SourceImageRatio))
            Else
                Me.Width = Convert.ToInt32(Decimal.Divide(New Decimal(Me.Height), Me.SourceImageRatio))
            End If
        ElseIf CDbl(Me.Height) / CDbl(Me.Width) <= Convert.ToDouble(Me.SourceImageRatio) Then
            Me.Width = Convert.ToInt32(Decimal.Divide(New Decimal(Me.Height), Me.SourceImageRatio))
        Else
            Me.Height = Convert.ToInt32(Decimal.Multiply(New Decimal(Me.Width), Me.SourceImageRatio))
        End If
        Me.LastWidth = Me.Width
        Me.LastHeight = Me.Height
        Me.RefreshImage()
    End Sub

    Private Sub AnimateTimer_Elapsed(ByVal sender As Object, ByVal e As EventArgs)
        Me._AnimateTimer.Enabled = False
        If Me.FanBlades IsNot Nothing And Me.AnimateGraphics IsNot Nothing Then
            If Not Me._Direction Then
                Me.MatrixForRotation.RotateAt(20.0F, Me.BladeCenterPoint)
            Else
                Me.MatrixForRotation.RotateAt(-20.0F, Me.BladeCenterPoint)
            End If
            Me.AnimateGraphics.Transform = Me.MatrixForRotation
            Me.AnimateGraphics.Clear(Color.Transparent)
            Me.AnimateGraphics.DrawImage(My.Resources.FanBlades, 0, 0, Me.FanBlades.Width, Me.FanBlades.Height)
            Me.Invalidate()
        End If
        Me._AnimateTimer.Enabled = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Me.FanCenterCap IsNot Nothing And Me.FanBlades IsNot Nothing Then
            Dim graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.DrawImage(Me.FanFrame, 0, 0)
            graphic.DrawImage(Me.FanBlades, Convert.ToInt32(40.0F * Me.XScale), Convert.ToInt32(40.0F * Me.YScale))
            graphic.DrawImage(Me.FanCenterCap, Convert.ToInt32(151.0F * Me.XScale), Convert.ToInt32(151.0F * Me.YScale))
            graphic.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), Me.TextRectangle, Me.TextFormat)
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.Adjustsize()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Private Sub RefreshImage()
        If Not (Me.Width <= 0 Or Me.Height <= 0) Then
            Me.XScale = CSng(CDbl(Me.Width) / CDbl(My.Resources.FanFrame.Width))
            Me.YScale = CSng(CDbl(Me.Height) / CDbl(My.Resources.FanFrame.Height))
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
            Me.FanCenterCap = New Bitmap(Convert.ToInt32(CSng(My.Resources.FanCenterCap.Width) * Me.XScale), Convert.ToInt32(CSng(My.Resources.FanCenterCap.Height) * Me.YScale))
            Dim graphic As Graphics = Graphics.FromImage(Me.FanCenterCap)
            graphic.DrawImage(My.Resources.FanCenterCap, 0, 0, Me.FanCenterCap.Width, Me.FanCenterCap.Height)
            Me.FanBlades = New Bitmap(Convert.ToInt32(CSng(My.Resources.FanBlades.Width) * Me.XScale), Convert.ToInt32(CSng(My.Resources.FanBlades.Height) * Me.YScale))
            graphic = Graphics.FromImage(Me.FanBlades)
            graphic.DrawImage(My.Resources.FanBlades, 0, 0, Me.FanBlades.Width, Me.FanBlades.Height)
            Me.FanFrame = New Bitmap(Convert.ToInt32(CSng(My.Resources.FanFrame.Width) * Me.XScale), Convert.ToInt32(CSng(My.Resources.FanFrame.Height) * Me.YScale))
            graphic = Graphics.FromImage(Me.FanFrame)
            graphic.DrawImage(My.Resources.FanFrame, 0, 0, Me.FanFrame.Width, Me.FanFrame.Height)
            Me.BladeCenterPoint = New Point(Convert.ToInt32(CDbl(Me.FanBlades.Width) / 2), Convert.ToInt32(CDbl(Me.FanBlades.Height) / 2))
            Me.TextRectangle = New Rectangle(0, Convert.ToInt32(10.0F * Me.YScale), Me.Width, Me.Height - Convert.ToInt32(20.0F * Me.YScale))
            Me.AnimateGraphics = Graphics.FromImage(Me.FanBlades)
        End If
    End Sub

    Public Event ValueChanged As EventHandler
End Class

