Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles


Public Class VerticalSlider
    Inherits Control



    Private SliderHeight As Integer

    Private SliderWidth As Double

    Private BackBuffer As Bitmap

    Private BackImage As Bitmap

    Private m_Minimum As Double

    Private m_Maximum As Double

    Protected m_Value As Double

    Private m_ShowTickMarks As Boolean

    Private m_MajorTickMarks As Integer

    Public Property MajorTickMarks() As Integer
        Get
            Return Me.m_MajorTickMarks
        End Get
        Set(ByVal value As Integer)
            If Me.m_MajorTickMarks <> value Then
                Me.m_MajorTickMarks = Math.Min(Math.Max(value, 2), 25)
                Me.RefreshImage()
            End If
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

    Public Property ShowTickMarks() As Boolean
        Get
            Return Me.m_ShowTickMarks
        End Get
        Set(ByVal value As Boolean)
            If Me.m_ShowTickMarks <> value Then
                Me.m_ShowTickMarks = value
                Me.RefreshImage()
            End If
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

        Me.m_Maximum = 100
        Me.m_MajorTickMarks = 4
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub



    Private Sub CalcNewPosition(ByVal y As Integer)
        Dim height_Renamed As Double = (CDbl(Me.Height - y) - CDbl(Me.SliderHeight) / 2) / CDbl(Me.Height - Me.SliderHeight) * (Me.m_Maximum - Me.m_Minimum) + Me.m_Minimum
        height_Renamed = Math.Min(Me.m_Maximum, height_Renamed)
        height_Renamed = Math.Max(Me.m_Minimum, height_Renamed)
        If height_Renamed <> Me.m_Value Then
            Me.m_Value = height_Renamed
            Me.OnValueChangedWithSlider(EventArgs.Empty)
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        Me.BackBuffer.Dispose()
    End Sub

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.CalcNewPosition(e.Y)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        'INSTANT VB NOTE: The variable location was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim location_Renamed As Point = e.Location
        Dim point As Point = e.Location
        If e.Button = MouseButtons.Left And location_Renamed.Y > -10 And point.X > -10 Then
            Me.CalcNewPosition(e.Y)
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim mValue As Double = 0
        MyBase.OnPaint(e)
        If Me.BackBuffer IsNot Nothing Then
            Dim graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.DrawImage(Me.BackImage, 0, 0)
            If Me.SliderHeight > 0 Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: if (this.m_Maximum - this.m_Minimum > 0 & checked(this.Height - this.SliderHeight) > 0)
                If Me.m_Maximum - Me.m_Minimum > 0 And Me.Height - Me.SliderHeight > 0 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: mValue = (this.m_Value - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(checked(this.Height - this.SliderHeight));
                    mValue = (Me.m_Value - Me.m_Minimum) / (Me.m_Maximum - Me.m_Minimum) * CDbl(Me.Height - Me.SliderHeight)
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: Rectangle rectangle = new Rectangle(0, checked((int)Math.Round((double)(checked(this.Height - this.SliderHeight)) - mValue)), checked((int)Math.Round(this.SliderWidth)), this.SliderHeight);
                Dim rectangle As New Rectangle(0, CInt(Math.Truncate(Math.Round(CDbl(Me.Height - Me.SliderHeight) - mValue))), CInt(Math.Truncate(Math.Round(Me.SliderWidth))), Me.SliderHeight)
                ButtonRenderer.DrawButton(graphic, rectangle, PushButtonState.Normal)
            End If
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.RefreshImage()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueChangedEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Protected Overridable Sub OnValueChangedWithSlider(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueChangedWithSliderEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Private Sub RefreshImage()
        If Me.Height > 0 And Me.Width > 0 Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.SliderHeight = checked((int)Math.Round((double)this.Height / 20));
            Me.SliderHeight = CInt(Math.Round(CDbl(Me.Height) / 20))
            Me.SliderWidth = CDbl(Me.Width)
            If Me.m_ShowTickMarks Then
                Me.SliderWidth = CDbl(Me.Width) * 0.6667
            End If
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
            Me.BackImage = New Bitmap(Me.Width, Me.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.BackImage)
            If (Me.BackColor <> Color.Transparent) Or Me.Parent Is Nothing Then
                graphic.Clear(Me.BackColor)
            ElseIf Me.Parent IsNot Nothing Then
                graphic.Clear(Me.Parent.BackColor)
            End If
            Dim point As New Point(0, 0)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point1 = new Point(checked((int)Math.Round((double)this.Width / 5)), 0);
            Dim point1 As New Point(CInt(Math.Round(CDbl(Me.Width) / 5)), 0)
            Dim linearGradientBrush As New LinearGradientBrush(point, point1, Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 220, 220, 220))
            Dim colorBlend As New ColorBlend()
            Dim colorArray() As Color = {Color.FromArgb(255, 220, 220, 220), Color.FromArgb(255, 32, 32, 32), Color.FromArgb(255, 220, 220, 220)}
            colorBlend.Colors = colorArray
            colorBlend.Positions = New Single() {0.0F, 0.5F, 1.0F}
            linearGradientBrush.InterpolationColors = colorBlend
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: int num = checked((int)Math.Round((double)this.Width / 2));
            Dim num As Integer = CInt(Math.Round(CDbl(Me.Width) / 2))
            If Me.m_ShowTickMarks Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: num = checked((int)Math.Round((double)this.Width / 3));
                num = CInt(Math.Round(CDbl(Me.Width) / 3))
            End If
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: graphic.FillRectangle(linearGradientBrush, checked((int)Math.Round((double)num - this.SliderWidth / 10)), checked((int)Math.Round((double)this.SliderHeight / 2)), checked((int)Math.Round(this.SliderWidth / 5)), checked(this.Height - this.SliderHeight));
            graphic.FillRectangle(linearGradientBrush, CInt(Math.Truncate(Math.Round(CDbl(num) - Me.SliderWidth / 10))), CInt(Math.Truncate(Math.Round(CDbl(Me.SliderHeight) / 2))), CInt(Math.Truncate(Math.Round(Me.SliderWidth / 5))), Me.Height - Me.SliderHeight)
            If Me.m_ShowTickMarks Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: double height = (double)(checked(this.Height - this.SliderHeight)) / (double)(checked(this.m_MajorTickMarks - 1));
                'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
                Dim height_Renamed As Double = CDbl(Me.Height - Me.SliderHeight) / CDbl(Me.m_MajorTickMarks - 1)
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: int mMajorTickMarks = checked(this.m_MajorTickMarks - 1);
                Dim mMajorTickMarks As Integer = Me.m_MajorTickMarks - 1
                For i As Integer = 0 To mMajorTickMarks
                    graphic.DrawLine(New Pen(Me.ForeColor), CSng(CDbl(Me.Width) * 0.7), CSng(CDbl(i) * height_Renamed + CDbl(Me.SliderHeight) / 2), CSng(Me.Width), CSng(CDbl(i) * height_Renamed + CDbl(Me.SliderHeight) / 2))
                Next i
            End If
            Me.Invalidate()
        End If
    End Sub

    Public Event ValueChanged As EventHandler

    Public Event ValueChangedWithSlider As EventHandler
End Class

