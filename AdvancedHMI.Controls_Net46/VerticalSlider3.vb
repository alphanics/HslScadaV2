Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class VerticalSlider3
    Inherits Control
    Private int_0 As Integer

    Private double_0 As Double

    Private bitmap_0 As Bitmap

    Private bitmap_1 As Bitmap

    Private double_1 As Double

    Private double_2 As Double

    Protected m_Value As Double

    Private double_3 As Double

    Private bool_0 As Boolean

    Private int_1 As Integer

    Private int_2 As Integer

    Private color_0 As Color

    Public Property BorderColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (value <> Me.color_0) Then
                Me.color_0 = value
                Me.method_1()
            End If
        End Set
    End Property

    Public Property Increment As Double
        Get
            Return Me.double_3
        End Get
        Set(ByVal value As Double)
            Me.double_3 = value
        End Set
    End Property

    Public Property MajorTickMarks As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            If (Me.int_1 <> value) Then
                Me.int_1 = Math.Min(Math.Max(value, 2), 25)
                Me.method_1()
            End If
        End Set
    End Property

    Public Property Maximum As Double
        Get
            Return Me.double_2
        End Get
        Set(ByVal value As Double)
            Me.double_2 = value
        End Set
    End Property

    Public Property Minimum As Double
        Get
            Return Me.double_1
        End Get
        Set(ByVal value As Double)
            Me.double_1 = value
        End Set
    End Property

    Public Property MinorTickMarks As Integer
        Get
            Return Me.int_2
        End Get
        Set(ByVal value As Integer)
            If (Me.int_2 <> value) Then
                Me.int_2 = Math.Min(Math.Max(value, 0), 10)
                Me.method_1()
            End If
        End Set
    End Property

    Public Property ShowTickMarks As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_0 <> value) Then
                Me.bool_0 = value
                Me.method_1()
            End If
        End Set
    End Property

    Public Property Value As Double
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Double)
            If (Me.m_Value <> value) Then
                Me.m_Value = value
                MyBase.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.double_2 = 100
        Me.double_3 = 0.1
        Me.int_1 = 5
        Me.int_2 = 4
        Me.color_0 = Color.Transparent
        MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        Me.bitmap_0.Dispose()
        If (Me.bitmap_1 IsNot Nothing) Then
            Me.bitmap_1.Dispose()
        End If
    End Sub

    Private Sub method_0(ByVal int_3 As Integer)
        Dim height As Double = (CDbl((MyBase.Height - int_3)) - CDbl(Me.int_0) / 2) / CDbl((MyBase.Height - Me.int_0)) * (Me.double_2 - Me.double_1) + Me.double_1
        height = Math.Min(Me.double_2, height)
        height = Math.Max(Me.double_1, height)
        If (Me.double_3 > 0) Then
            height = CDbl(Convert.ToInt32(height / Me.double_3)) * Me.double_3
        End If
        If (height <> Me.m_Value) Then
            Me.m_Value = height
            Me.OnValueChangedByMouse(EventArgs.Empty)
            MyBase.Invalidate()
        End If
    End Sub

    Private Sub method_1()
        If (MyBase.Height > 0 And MyBase.Width > 0) Then
            Me.double_0 = CDbl(MyBase.Width)
            If (Me.bool_0) Then
                Me.double_0 = CDbl(MyBase.Width) * 0.6667
            End If
            Me.bitmap_0 = New Bitmap(MyBase.Width, MyBase.Height)
            Me.bitmap_1 = New Bitmap(MyBase.Width, MyBase.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.bitmap_1)
            If ((Me.BackColor <> Color.Transparent) Or MyBase.Parent Is Nothing) Then
                graphic.Clear(Me.BackColor)
            ElseIf (MyBase.Parent IsNot Nothing) Then
                graphic.Clear(MyBase.Parent.BackColor)
            End If
            Dim height As Double = CDbl(MyBase.Height) / CDbl(My.Resources.AnalogSliderSlot.Height)
            Dim width As Double = CDbl(My.Resources.AnalogSliderSlot.Width) * height
            graphic.DrawImage(My.Resources.AnalogSliderSlot, CInt(Math.Round(CDbl(MyBase.Width) / 2 - width / 2)), 0, CInt(Math.Round(width)), MyBase.Height)
            Me.double_0 = CDbl(CInt(Math.Round(CDbl(My.Resources.VerticalSlider.Width) * height)))
            Me.int_0 = CInt(Math.Round(CDbl(My.Resources.VerticalSlider.Height) * height))
            If (Me.bool_0) Then
                Dim num As Integer = CInt(Math.Round((CDbl(MyBase.Width) - width * 3) / 2))
                If (num <= 0) Then
                    num = 1
                End If
                Dim num1 As Integer = CInt(Math.Round(Math.Max(CDbl(num) / 2, 1)))
                Dim height1 As Double = CDbl((MyBase.Height - Me.int_0)) / CDbl((Me.int_1 - 1))
                Dim int1 As Integer = Me.int_1 - 1
                For i As Integer = 0 To int1 Step 1
                    Using pen As System.Drawing.Pen = New System.Drawing.Pen(Me.ForeColor)
                        graphic.DrawLine(pen, 0!, CSng((CDbl(i) * height1 + CDbl(Me.int_0) / 2)), CSng(num), CSng((CDbl(i) * height1 + CDbl(Me.int_0) / 2)))
                        graphic.DrawLine(pen, CSng((MyBase.Width - num)), CSng((CDbl(i) * height1 + CDbl(Me.int_0) / 2)), CSng(MyBase.Width), CSng((CDbl(i) * height1 + CDbl(Me.int_0) / 2)))
                    End Using
                    If (Me.int_2 > 0 And i < Me.int_1 - 1) Then
                        Dim int2 As Double = height1 / CDbl((Me.int_2 + 1))
                        Dim int21 As Integer = Me.int_2
                        For j As Integer = 0 To int21 Step 1
                            Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(Me.ForeColor)
                                graphic.DrawLine(pen1, 0!, CSng((CDbl(i) * height1 + CDbl(Me.int_0) / 2 + CDbl(j) * int2)), CSng(num1), CSng((CDbl(i) * height1 + CDbl(Me.int_0) / 2 + CDbl(j) * int2)))
                                graphic.DrawLine(pen1, CSng((MyBase.Width - num1)), CSng((CDbl(i) * height1 + CDbl(Me.int_0) / 2 + CDbl(j) * int2)), CSng(MyBase.Width), CSng((CDbl(i) * height1 + CDbl(Me.int_0) / 2 + CDbl(j) * int2)))
                            End Using
                        Next

                    End If
                Next

            End If
            If (Me.color_0 <> Color.Transparent) Then
                Using pen2 As System.Drawing.Pen = New System.Drawing.Pen(Me.color_0)
                    graphic.DrawRectangle(pen2, 0, 0, MyBase.Width - 1, MyBase.Height - 1)
                End Using
            End If
            MyBase.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Me.method_1()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        Me.method_1()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.method_0(e.Y)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim location As Point = e.Location
        If (e.Button = System.Windows.Forms.MouseButtons.Left And location.Y > -10 And e.Location.X > -10) Then
            Me.method_0(e.Y)
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim double1 As Double = 0
        MyBase.OnPaint(painte)
        If (Me.bitmap_0 IsNot Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me.bitmap_0)
            graphic.DrawImage(Me.bitmap_1, 0, 0)
            If (Me.int_0 > 0) Then
                Dim num As Double = Math.Max(Math.Min(Me.m_Value, Me.double_2), Me.double_1)
                If (Me.double_2 - Me.double_1 > 0 And MyBase.Height - Me.int_0 > 0) Then
                    double1 = (num - Me.double_1) / (Me.double_2 - Me.double_1) * CDbl((MyBase.Height - Me.int_0))
                End If
                graphic.DrawImage(My.Resources.VerticalSlider, New Rectangle(CInt(Math.Round((CDbl(MyBase.Width) - Me.double_0) / 2)), CInt(Math.Round(CDbl((MyBase.Height - Me.int_0)) - double1)), CInt(Math.Round(Me.double_0)), Me.int_0))
            End If
            painte.Graphics.DrawImage(Me.bitmap_0, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.method_1()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)

        RaiseEvent ValueChanged(Me, e)
    End Sub

    Protected Overridable Sub OnValueChangedByMouse(ByVal e As EventArgs)

        RaiseEvent ValueChangedByMouse(Me, e)
    End Sub

    Public Event ValueChanged As EventHandler


    Public Event ValueChangedByMouse As EventHandler

End Class
