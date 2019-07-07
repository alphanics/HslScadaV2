Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class VerticalSlider3
    Inherits Control



    Private SliderHeight As Integer

    Private SliderWidth As Double

    Private BackBuffer As Bitmap

    Private BackImage As Bitmap

    Private m_Minimum As Double

    Private m_Maximum As Double

    Protected m_Value As Double

    Private m_Increment As Double

    Private m_ShowTickMarks As Boolean

    Private m_MajorTickMarks As Integer

    Private m_MinorTickMarks As Integer

    Private m_BorderColor As Color

    Public Property BorderColor() As Color
        Get
            Return Me.m_BorderColor
        End Get
        Set(ByVal value As Color)
            If value <> Me.m_BorderColor Then
                Me.m_BorderColor = value
                Me.RefreshImage()
            End If
        End Set
    End Property

    Public Property Increment() As Double
        Get
            Return Me.m_Increment
        End Get
        Set(ByVal value As Double)
            Me.m_Increment = value
        End Set
    End Property

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

    Public Property MinorTickMarks() As Integer
        Get
            Return Me.m_MinorTickMarks
        End Get
        Set(ByVal value As Integer)
            If Me.m_MinorTickMarks <> value Then
                Me.m_MinorTickMarks = Math.Min(Math.Max(value, 0), 10)
                Me.RefreshImage()
            End If
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
        Me.m_Increment = 0.1
        Me.m_MajorTickMarks = 5
        Me.m_MinorTickMarks = 4
        Me.m_BorderColor = Color.Transparent
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub



    Private Sub CalcNewPosition(ByVal y As Integer)
        Dim height_Renamed As Double = (CDbl(Me.Height - y) - CDbl(Me.SliderHeight) / 2) / CDbl(Me.Height - Me.SliderHeight) * (Me.m_Maximum - Me.m_Minimum) + Me.m_Minimum
        height_Renamed = Math.Min(Me.m_Maximum, height_Renamed)
        height_Renamed = Math.Max(Me.m_Minimum, height_Renamed)
        If Me.m_Increment > 0 Then
            height_Renamed = CDbl(Convert.ToInt32(height_Renamed / Me.m_Increment)) * Me.m_Increment
        End If
        If height_Renamed <> Me.m_Value Then
            Me.m_Value = height_Renamed
            Me.OnValueChangedByMouse(EventArgs.Empty)
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
        Dim mMinimum As Double = 0
        MyBase.OnPaint(e)
        If Me.BackBuffer IsNot Nothing Then
            Dim graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.DrawImage(Me.BackImage, 0, 0)
            If Me.SliderHeight > 0 Then
                Dim num As Double = Math.Max(Math.Min(Me.m_Value, Me.m_Maximum), Me.m_Minimum)
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: if (this.m_Maximum - this.m_Minimum > 0 & checked(this.Height - this.SliderHeight) > 0)
                If Me.m_Maximum - Me.m_Minimum > 0 And Me.Height - Me.SliderHeight > 0 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: mMinimum = (num - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(checked(this.Height - this.SliderHeight));
                    mMinimum = (num - Me.m_Minimum) / (Me.m_Maximum - Me.m_Minimum) * CDbl(Me.Height - Me.SliderHeight)
                End If
                Dim verticalSlider As Bitmap = My.Resources.VerticalSlider
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: Rectangle rectangle = new Rectangle(checked((int)Math.Round(((double)this.Width - this.SliderWidth) / 2)), checked((int)Math.Round((double)(checked(this.Height - this.SliderHeight)) - mMinimum)), checked((int)Math.Round(this.SliderWidth)), this.SliderHeight);
                Dim rectangle As New Rectangle(CInt(Math.Truncate(Math.Round((CDbl(Me.Width) - Me.SliderWidth) / 2))), CInt(Math.Truncate(Math.Round(CDbl(Me.Height - Me.SliderHeight) - mMinimum))), CInt(Math.Truncate(Math.Round(Me.SliderWidth))), Me.SliderHeight)
                graphic.DrawImage(verticalSlider, rectangle)
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

    Protected Overridable Sub OnValueChangedByMouse(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueChangedByMouseEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Private Sub RefreshImage()
        If Me.Height > 0 And Me.Width > 0 Then
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
            'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim height_Renamed As Double = CDbl(Me.Height) / CDbl(My.Resources.AnalogSliderSlot.Height)
            'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim width_Renamed As Double = CDbl(My.Resources.AnalogSliderSlot.Width) * height_Renamed
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: graphic.DrawImage(My.Resources.AnalogSliderSlot, checked((int)Math.Round((double)this.Width / 2 - width / 2)), 0, checked((int)Math.Round(width)), this.Height);
            graphic.DrawImage(My.Resources.AnalogSliderSlot, CInt(Math.Truncate(Math.Round(CDbl(Me.Width) / 2 - width_Renamed / 2))), 0, CInt(Math.Truncate(Math.Round(width_Renamed))), Me.Height)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.SliderWidth = (double)(checked((int)Math.Round((double)My.Resources.VerticalSlider.Width * height)));
            Me.SliderWidth = CDbl(CInt(Math.Truncate(Math.Round(CDbl(My.Resources.VerticalSlider.Width) * height_Renamed))))
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.SliderHeight = checked((int)Math.Round((double)My.Resources.VerticalSlider.Height * height));
            Me.SliderHeight = CInt(Math.Truncate(Math.Round(CDbl(My.Resources.VerticalSlider.Height) * height_Renamed)))
            If Me.m_ShowTickMarks Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: int num = checked((int)Math.Round(((double)this.Width - width * 3) / 2));
                Dim num As Integer = CInt(Math.Truncate(Math.Round((CDbl(Me.Width) - width_Renamed * 3) / 2)))
                If num <= 0 Then
                    num = 1
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: int num1 = checked((int)Math.Round(Math.Max((double)num / 2, 1)));
                Dim num1 As Integer = CInt(Math.Truncate(Math.Round(Math.Max(CDbl(num) / 2, 1))))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: double height1 = (double)(checked(this.Height - this.SliderHeight)) / (double)(checked(this.m_MajorTickMarks - 1));
                Dim height1 As Double = CDbl(Me.Height - Me.SliderHeight) / CDbl(Me.m_MajorTickMarks - 1)
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: int mMajorTickMarks = checked(this.m_MajorTickMarks - 1);
                Dim mMajorTickMarks As Integer = Me.m_MajorTickMarks - 1
                For i As Integer = 0 To mMajorTickMarks
                    graphic.DrawLine(New Pen(Me.ForeColor), 0.0F, CSng(CDbl(i) * height1 + CDbl(Me.SliderHeight) / 2), CSng(num), CSng(CDbl(i) * height1 + CDbl(Me.SliderHeight) / 2))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.DrawLine(new Pen(this.ForeColor), (float)(checked(this.Width - num)), (float)((double)i * height1 + (double)this.SliderHeight / 2), (float)this.Width, (float)((double)i * height1 + (double)this.SliderHeight / 2));
                    graphic.DrawLine(New Pen(Me.ForeColor), CSng(Me.Width - num), CSng(CDbl(i) * height1 + CDbl(Me.SliderHeight) / 2), CSng(Me.Width), CSng(CDbl(i) * height1 + CDbl(Me.SliderHeight) / 2))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: if (this.m_MinorTickMarks > 0 & i < checked(this.m_MajorTickMarks - 1))
                    If Me.m_MinorTickMarks > 0 And i < Me.m_MajorTickMarks - 1 Then
                        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        'ORIGINAL LINE: double mMinorTickMarks = height1 / (double)(checked(this.m_MinorTickMarks + 1));
                        Dim mMinorTickMarks As Double = height1 / CDbl(Me.m_MinorTickMarks + 1)
                        Dim mMinorTickMarks1 As Integer = Me.m_MinorTickMarks
                        For j As Integer = 0 To mMinorTickMarks1
                            graphic.DrawLine(New Pen(Me.ForeColor), 0.0F, CSng(CDbl(i) * height1 + CDbl(Me.SliderHeight) / 2 + CDbl(j) * mMinorTickMarks), CSng(num1), CSng(CDbl(i) * height1 + CDbl(Me.SliderHeight) / 2 + CDbl(j) * mMinorTickMarks))
                            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            'ORIGINAL LINE: graphic.DrawLine(new Pen(this.ForeColor), (float)(checked(this.Width - num1)), (float)((double)i * height1 + (double)this.SliderHeight / 2 + (double)j * mMinorTickMarks), (float)this.Width, (float)((double)i * height1 + (double)this.SliderHeight / 2 + (double)j * mMinorTickMarks));
                            graphic.DrawLine(New Pen(Me.ForeColor), CSng(Me.Width - num1), CSng(CDbl(i) * height1 + CDbl(Me.SliderHeight) / 2 + CDbl(j) * mMinorTickMarks), CSng(Me.Width), CSng(CDbl(i) * height1 + CDbl(Me.SliderHeight) / 2 + CDbl(j) * mMinorTickMarks))
                        Next j
                    End If
                Next i
            End If
            If Me.m_BorderColor <> Color.Transparent Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawRectangle(new Pen(this.m_BorderColor), 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                graphic.DrawRectangle(New Pen(Me.m_BorderColor), 0, 0, Me.Width - 1, Me.Height - 1)
            End If
            Me.Invalidate()
        End If
    End Sub

    Public Event ValueChanged As EventHandler

    Public Event ValueChangedByMouse As EventHandler
End Class

