Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class ThumbDial
    Inherits Control



    Private AnimationFrame As Integer

    Private BackBuffer As Bitmap

    Private AnimationImages() As Bitmap

    Private BaseImage As Bitmap

    Private DialLocation As Point

    Private BaseLocation As Point

    Private m_Minimum As Double

    Private m_Maximum As Double

    Protected m_Value As Double

    Private m_Increment As Double

    Private m_Sensitivity As Double

    Private LastX As Integer

    Public Property Increment() As Double
        Get
            Return Me.m_Increment
        End Get
        Set(ByVal value As Double)
            Me.m_Increment = value
        End Set
    End Property

    Public Property Maximum() As Double
        Get
            Return Me.m_Maximum
        End Get
        Set(ByVal value As Double)
            Me.m_Maximum = value
        End Set
    End Property

    Public Property Minimum() As Double
        Get
            Return Me.m_Minimum
        End Get
        Set(ByVal value As Double)
            Me.m_Minimum = value
        End Set
    End Property

    Public Property Sensitivity() As Double
        Get
            Return Me.m_Sensitivity
        End Get
        Set(ByVal value As Double)
            Me.m_Sensitivity = Math.Max(value, 0.1)
        End Set
    End Property

    Public Property Value() As Double
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Double)
            If Me.m_Value <> value Then
                Me.m_Value = value
                Me.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property



    Public Sub New()

        Me.AnimationImages = New Bitmap(2) {}
        Me.m_Maximum = 100
        Me.m_Increment = 1
        Me.m_Sensitivity = 1
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub



    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim num As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.LastX - e.X) / 4 * Me.m_Sensitivity)))
        If e.Button = MouseButtons.Left Then
            If num < 0 Then
                If Me.AnimationFrame >= 2 Then
                    Me.AnimationFrame = 0
                Else
                    Me.AnimationFrame = Me.AnimationFrame + 1
                End If
                Me.LastX = e.X
                Me.m_Value = Me.m_Value + Me.m_Increment
                Me.m_Value = Math.Min(Me.m_Value, Me.m_Maximum)
                Me.Invalidate()
                Me.OnValueChangedByMouse(EventArgs.Empty)
            ElseIf num > 0 Then
                If Me.AnimationFrame <= 0 Then
                    Me.AnimationFrame = 2
                Else
                    Me.AnimationFrame = Me.AnimationFrame - 1
                End If
                Me.LastX = e.X
                Me.m_Value = Me.m_Value - Me.m_Increment
                Me.m_Value = Math.Max(Me.m_Value, Me.m_Minimum)
                Me.Invalidate()
                Me.OnValueChangedByMouse(EventArgs.Empty)
            End If
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Using graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.Clear(Me.BackColor)
            graphic.DrawImage(Me.BaseImage, Me.BaseLocation)
            If (If(Me.AnimationFrame > 2 OrElse Me.AnimationImages(Me.AnimationFrame) Is Nothing, False, True)) Then
                graphic.DrawImageUnscaled(Me.AnimationImages(Me.AnimationFrame), Me.DialLocation)
            End If
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Protected Overridable Sub OnValueChangedByMouse(ByVal e As EventArgs)
        RaiseEvent ValueChangedByMouse(Me, e)
    End Sub

    Private Sub RefreshImage()
        If Me.Height > 0 And Me.Width > 0 Then
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
            Math.Min(CDbl(Me.Width) / CDbl(My.Resources.ThumbDialFrame1.Width), CDbl(Me.Height) / CDbl(My.Resources.ThumbDialFrame1.Height))
            Dim num As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.58)))
            Dim num1 As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.45)))
            Me.DialLocation = New Point(CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * 0.21))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.2))))
            Me.AnimationImages(0) = New Bitmap(num, num1)
            Dim graphic As Graphics = Graphics.FromImage(Me.AnimationImages(0))
            graphic.DrawImage(My.Resources.ThumbDialFrame1, 0, 0, num, num1)
            Me.AnimationImages(1) = New Bitmap(num, num1)
            graphic = Graphics.FromImage(Me.AnimationImages(1))
            graphic.DrawImage(My.Resources.ThumbDialFrame2, 0, 0, num, num1)
            Me.AnimationImages(2) = New Bitmap(num, num1)
            graphic = Graphics.FromImage(Me.AnimationImages(2))
            graphic.DrawImage(My.Resources.ThumbDialFrame3, 0, 0, num, num1)
            Me.BaseLocation = New Point(0, 0)
            Me.BaseImage = New Bitmap(Me.Width, Me.Height)
            graphic = Graphics.FromImage(Me.BaseImage)
            graphic.DrawImage(My.Resources.ThumbDialBase, 0, 0, Me.BaseImage.Width, Me.BaseImage.Height)
        End If
    End Sub

    Public Event ValueChanged As EventHandler

    Public Event ValueChangedByMouse As EventHandler
End Class

