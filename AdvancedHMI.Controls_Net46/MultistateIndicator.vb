Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class MultistateIndicator
    Inherits Control
    Private rectangle_0 As Rectangle

    Private solidBrush_0 As SolidBrush

    Private int_0 As Integer

    Private collection_0 As Collection(Of MessageByValue)

    Private linearGradientBrush_0 As LinearGradientBrush

    Private color_0 As Color

    Private font_0 As System.Drawing.Font

    Private solidBrush_1 As SolidBrush

    Private pen_0 As Pen

    Private string_0 As String

    Private decimal_0 As Decimal

    Private stringFormat_0 As StringFormat

    Private solidBrush_2 As SolidBrush

    Public Property BorderColor As Color
        Get
            Return Me.pen_0.Color
        End Get
        Set(ByVal value As Color)
            If (Me.pen_0.Color <> value) Then
                If (Me.pen_0 Is Nothing) Then
                    Me.pen_0 = New Pen(value, 1!)
                Else
                    Me.pen_0.Color = value
                End If
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property BorderWidth As Integer
        Get
            Return Convert.ToInt32(Me.pen_0.Width)
        End Get
        Set(ByVal value As Integer)
            If (Me.pen_0.Width <> CSng(value)) Then
                If (Me.pen_0 Is Nothing) Then
                    If (Me.pen_0 IsNot Nothing) Then
                        Me.pen_0.Dispose()
                    End If
                    Me.pen_0 = New Pen(Brushes.White, CSng(value))
                Else
                    Me.pen_0.Width = CSng(value)
                End If
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property NumericFormat As String
        Get
            Return Me.string_0
        End Get
        Set(ByVal value As String)
            Me.string_0 = value
        End Set
    End Property

    Public Property SelectedStateBackColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If (Me.color_0 <> value) Then
                Me.color_0 = value
                If (MyBase.Height > 0) Then
                    Me.method_0()
                End If
            End If
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public ReadOnly Property States As Collection(Of MessageByValue)
        Get
            Return Me.collection_0
        End Get
    End Property

    Public Property StatesFont As System.Drawing.Font
        Get
            Return Me.font_0
        End Get
        Set(ByVal value As System.Drawing.Font)
            Me.font_0 = value
            MyBase.Invalidate()
        End Set
    End Property

    Public Property StatesForecolor As Color
        Get
            Return Me.solidBrush_1.Color
        End Get
        Set(ByVal value As Color)
            Me.solidBrush_1.Color = value
            MyBase.Invalidate()
        End Set
    End Property

    Public Property Value As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.int_0) Then
                Me.int_0 = value
                MyBase.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ValueScaleFactor As Decimal
        Get
            Return Me.decimal_0
        End Get
        Set(ByVal value As Decimal)
            Me.decimal_0 = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.rectangle_0 = New Rectangle()
        Me.collection_0 = New Collection(Of MessageByValue)()
        Me.color_0 = Color.Maroon
        Me.font_0 = New System.Drawing.Font("Arial", 16!, FontStyle.Regular, GraphicsUnit.Point)
        Me.solidBrush_1 = New SolidBrush(Color.Black)
        Me.decimal_0 = Decimal.One
        Me.stringFormat_0 = New StringFormat()
        Me.solidBrush_2 = New SolidBrush(MyBase.ForeColor)
        Me.solidBrush_0 = New SolidBrush(MyBase.BackColor)
        Me.pen_0 = New Pen(Brushes.White, 1!)
        MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        Me.stringFormat_0.Dispose()
        Me.font_0.Dispose()
        Me.solidBrush_2.Dispose()
        Me.solidBrush_1.Dispose()
        If (Me.solidBrush_0 IsNot Nothing) Then
            Me.solidBrush_0.Dispose()
        End If
        If (Me.pen_0 IsNot Nothing) Then
            Me.pen_0.Dispose()
        End If
        If (Me.linearGradientBrush_0 IsNot Nothing) Then
            Me.linearGradientBrush_0.Dispose()
        End If
    End Sub

    Private Sub method_0()
        Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(CInt(Me.color_0.A), Convert.ToInt32(Math.Min(CDbl(Me.color_0.R) * 1.4, 255)), Convert.ToInt32(Math.Min(CDbl(Me.color_0.G) * 1.4, 255)), Convert.ToInt32(Math.Min(CDbl(Me.color_0.B) * 1.4, 255)))
        If (Me.linearGradientBrush_0 IsNot Nothing) Then
            Me.linearGradientBrush_0.Dispose()
        End If
        Dim color1 As System.Drawing.Color = System.Drawing.Color.FromArgb(CInt(Me.color_0.A), Convert.ToInt32(CDbl(Me.color_0.R) * 0.6), Convert.ToInt32(CDbl(Me.color_0.G) * 0.6), Convert.ToInt32(CDbl(Me.color_0.B) * 0.6))
        Dim point As System.Drawing.Point = New System.Drawing.Point(0, 0)
        Dim point1 As System.Drawing.Point = New System.Drawing.Point(0, MyBase.Height)
        Me.linearGradientBrush_0 = New LinearGradientBrush(point, point1, color, color1)
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Me.solidBrush_0.Color = Me.BackColor
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Me.stringFormat_0.Alignment = StringAlignment.Center
        Me.stringFormat_0.LineAlignment = StringAlignment.Center
        If (Me.solidBrush_2 Is Nothing) Then
            Me.solidBrush_2 = New SolidBrush(MyBase.ForeColor)
        End If
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        If (Me.solidBrush_2 IsNot Nothing) Then
            Me.solidBrush_2.Color = MyBase.ForeColor
        Else
            Me.solidBrush_2 = New SolidBrush(Color.Black)
        End If
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        If (If(painte Is Nothing, False, painte.Graphics IsNot Nothing) AndAlso Me.solidBrush_2 IsNot Nothing AndAlso MyBase.Height > 0 And MyBase.Width > 0) Then
            Dim graphics As System.Drawing.Graphics = painte.Graphics
            Dim height As Integer = Me.Font.Height + 4
            If (String.IsNullOrEmpty(Me.Text)) Then
                height = 0
            End If
            graphics.FillRectangle(Brushes.LightGray, 0, 0, MyBase.Width, MyBase.Height)
            graphics.FillRectangle(Me.solidBrush_0, 0, 0, MyBase.Width, height)
            Dim width As Integer = MyBase.Width
            If (Me.States.Count > 1) Then
                width = Convert.ToInt32(CDbl(MyBase.Width) / CDbl(Me.States.Count))
            End If
            If (height > 0) Then
                graphics.DrawLine(Pens.White, 0, height, MyBase.Width, height)
            End If
            Dim count As Integer = Me.States.Count - 1
            Dim num As Integer = 0
            Do
                Dim [single] As Single = Convert.ToSingle(CDbl((width * num)) + CDbl(width) / 2)
                Dim single1 As Single = Convert.ToSingle(CDbl(height) + CDbl((MyBase.Height - Me.Font.Height - 4)) / 2)
                If (Me.collection_0(num).Value = Me.int_0) Then
                    If (Me.linearGradientBrush_0 Is Nothing) Then
                        Me.method_0()
                    End If
                    If (Me.linearGradientBrush_0 IsNot Nothing) Then
                        graphics.FillRectangle(Me.linearGradientBrush_0, width * num, height + 1, width, MyBase.Height - height)
                    Else
                        graphics.FillRectangle(Brushes.Maroon, width * num, height + 1, width, MyBase.Height - height)
                    End If
                End If
                graphics.DrawLine(Me.pen_0, width * num, height, width * num, MyBase.Height)
                If (height > 0) Then
                    graphics.DrawString(Me.collection_0(num).Message, Me.StatesFont, Me.solidBrush_1, [single], single1, Me.stringFormat_0)
                End If
                num = num + 1
            Loop While num <= count
            If (Not String.IsNullOrEmpty(MyBase.Text)) Then
                graphics.DrawString(MyBase.Text, MyBase.Font, Me.solidBrush_2, CSng(Convert.ToInt32(CDbl(MyBase.Width) / 2)), CSng(Convert.ToInt32(CDbl(MyBase.Font.Height) / 2 + 2)), Me.stringFormat_0)
            End If
            graphics.DrawRectangle(Me.pen_0, 0, 0, MyBase.Width - 1, MyBase.Height - 1)
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        MyBase.Invalidate()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Public Event ValueChanged As EventHandler

End Class
