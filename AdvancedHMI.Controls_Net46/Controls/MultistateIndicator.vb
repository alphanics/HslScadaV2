Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Controls
    Public Class MultistateIndicator
        Inherits Control
        ' Events
        Public Event ValueChanged As EventHandler

        ' Methods
        Public Sub New()
            Me.solidBrush_2 = New SolidBrush(MyBase.ForeColor)
            Me.solidBrush_0 = New SolidBrush(MyBase.BackColor)
            Me.pen_0 = New Pen(Brushes.White, 1!)
            MyBase.SetStyle((ControlStyles.OptimizedDoubleBuffer Or (ControlStyles.AllPaintingInWmPaint Or (ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint))), True)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
            Me.stringFormat_0.Dispose
            Me.font_0.Dispose
            Me.solidBrush_2.Dispose
            Me.solidBrush_1.Dispose
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
            Dim red As Integer = Convert.ToInt32(Math.Min(CDbl((Me.color_0.R * 1.4)), CDbl(255)))
            Dim green As Integer = Convert.ToInt32(Math.Min(CDbl((Me.color_0.G * 1.4)), CDbl(255)))
            Dim color As Color = Color.FromArgb(Me.color_0.A, red, green, Convert.ToInt32(Math.Min(CDbl((Me.color_0.B * 1.4)), CDbl(255))))
            If (Me.linearGradientBrush_0 IsNot Nothing) Then
                Me.linearGradientBrush_0.Dispose()
            End If
            Dim introduced7 As Integer = Convert.ToInt32(CDbl((Me.color_0.R * 0.6)))
            Dim introduced8 As Integer = Convert.ToInt32(CDbl((Me.color_0.G * 0.6)))
            Dim color2 As Color = Color.FromArgb(Me.color_0.A, introduced7, introduced8, Convert.ToInt32(CDbl((Me.color_0.B * 0.6))))
            Dim point As New Point(0, 0)
            Dim point2 As New Point(0, MyBase.Height)
            Me.linearGradientBrush_0 = New LinearGradientBrush(point, point2, color, color2)
            MyBase.Invalidate
        End Sub

        Protected Overrides Sub OnBackColorChanged(ByVal eventArgs_0 As EventArgs)
            MyBase.OnBackColorChanged(eventArgs_0)
            Me.solidBrush_0.Color = Me.BackColor
        End Sub

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl
            Me.stringFormat_0.Alignment = StringAlignment.Center
            Me.stringFormat_0.LineAlignment = StringAlignment.Center
            If (Me.solidBrush_2 Is Nothing) Then
                Me.solidBrush_2 = New SolidBrush(MyBase.ForeColor)
            End If
        End Sub

        Protected Overrides Sub OnForeColorChanged(ByVal eventArgs_0 As EventArgs)
            MyBase.OnForeColorChanged(eventArgs_0)
            If (Me.solidBrush_2 Is Nothing) Then
                Me.solidBrush_2 = New SolidBrush(Color.Black)
            Else
                Me.solidBrush_2.Color = MyBase.ForeColor
            End If
            MyBase.Invalidate
        End Sub

        Protected Overrides Sub OnPaint(ByVal paintEventArgs_0 As PaintEventArgs)
            If ((((Not paintEventArgs_0 Is Nothing) AndAlso (Not paintEventArgs_0.Graphics Is Nothing)) AndAlso (Not Me.solidBrush_2 Is Nothing)) AndAlso Not ((MyBase.Height <= 0) Or (MyBase.Width <= 0))) Then
                Dim graphics As Graphics = paintEventArgs_0.Graphics
                Dim height As Integer = (Me.Font.Height + 4)
                If String.IsNullOrEmpty(Me.Text) Then
                    height = 0
                End If
                graphics.FillRectangle(Brushes.LightGray, 0, 0, MyBase.Width, MyBase.Height)
                graphics.FillRectangle(Me.solidBrush_0, 0, 0, MyBase.Width, height)
                Dim width As Integer = MyBase.Width
                If (Me.States.Count > 1) Then
                    width = Convert.ToInt32(CDbl((CDbl(MyBase.Width) / CDbl(Me.States.Count))))
                End If
                If (height > 0) Then
                    graphics.DrawLine(Pens.White, 0, height, MyBase.Width, height)
                End If
                Dim num3 As Integer = (Me.States.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num3)
                    Dim x As Single = Convert.ToSingle(CDbl(((width * i) + (CDbl(width) / 2))))
                    Dim y As Single = Convert.ToSingle(CDbl((height + (CDbl(((MyBase.Height - Me.Font.Height) - 4)) / 2))))
                    If (Me.collection_0(i).Value = Me.int_0) Then
                        If (Me.linearGradientBrush_0 Is Nothing) Then
                            Me.method_0
                        End If
                        If (Me.linearGradientBrush_0 Is Nothing) Then
                            graphics.FillRectangle(Brushes.Maroon, (width * i), (height + 1), width, (MyBase.Height - height))
                        Else
                            graphics.FillRectangle(Me.linearGradientBrush_0, (width * i), (height + 1), width, (MyBase.Height - height))
                        End If
                    End If
                    graphics.DrawLine(Me.pen_0, (width * i), height, (width * i), MyBase.Height)
                    If (height > 0) Then
                        graphics.DrawString(Me.collection_0(i).Message, Me.StatesFont, Me.solidBrush_1, x, y, Me.stringFormat_0)
                    End If
                    i += 1
                Loop
                If Not String.IsNullOrEmpty(MyBase.Text) Then
                    graphics.DrawString(MyBase.Text, MyBase.Font, Me.solidBrush_2, CSng(Convert.ToInt32(CDbl((CDbl(MyBase.Width) / 2)))), CSng(Convert.ToInt32(CDbl(((CDbl(MyBase.Font.Height) / 2) + 2)))), Me.stringFormat_0)
                End If
                graphics.DrawRectangle(Me.pen_0, 0, 0, (MyBase.Width - 1), (MyBase.Height - 1))
            End If
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal eventArgs_0 As EventArgs)
            MyBase.OnTextChanged(eventArgs_0)
            MyBase.Invalidate
        End Sub

        Protected Overridable Sub OnValueChanged(ByVal eventArgs_0 As EventArgs)
            RaiseEvent ValueChanged(Me, eventArgs_0)
        End Sub


        ' Properties
        Public Property Value As Integer
            Get
                Return Me.int_0
            End Get
            Set(ByVal value As Integer)
                If (value <> Me.int_0) Then
                    Me.int_0 = value
                    MyBase.Invalidate
                    Me.OnValueChanged(EventArgs.Empty)
                End If
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property States As Collection(Of MessageByValue)
            Get
                Return Me.collection_0
            End Get
        End Property

        Public Property SelectedStateBackColor As Color
            Get
                Return Me.color_0
            End Get
            Set(ByVal value As Color)
                If (Me.color_0 <> value) Then
                    Me.color_0 = value
                    If (MyBase.Height > 0) Then
                        Me.method_0
                    End If
                End If
            End Set
        End Property

        Public Property StatesFont As Font
            Get
                Return Me.font_0
            End Get
            Set(ByVal value As Font)
                Me.font_0 = value
                MyBase.Invalidate
            End Set
        End Property

        Public Property StatesForecolor As Color
            Get
                Return Me.solidBrush_1.Color
            End Get
            Set(ByVal value As Color)
                Me.solidBrush_1.Color = value
                MyBase.Invalidate
            End Set
        End Property

        Public Property BorderColor As Color
            Get
                Return Me.pen_0.Color
            End Get
            Set(ByVal value As Color)
                If (Me.pen_0.Color <> value) Then
                    If (Me.pen_0 IsNot Nothing) Then
                        Me.pen_0.Color = value
                    Else
                        Me.pen_0 = New Pen(value, 1!)
                    End If
                    MyBase.Invalidate
                End If
            End Set
        End Property

        Public Property BorderWidth As Integer
            Get
                Return Convert.ToInt32(Me.pen_0.Width)
            End Get
            Set(ByVal value As Integer)
                If (Me.pen_0.Width <> value) Then
                    If (Me.pen_0 IsNot Nothing) Then
                        Me.pen_0.Width = value
                    Else
                        If (Me.pen_0 IsNot Nothing) Then
                            Me.pen_0.Dispose()
                        End If
                        Me.pen_0 = New Pen(Brushes.White, CSng(value))
                    End If
                    MyBase.Invalidate
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

        Public Property ValueScaleFactor As Decimal
            Get
                Return Me.decimal_0
            End Get
            Set(ByVal value As Decimal)
                Me.decimal_0 = value
            End Set
        End Property


        ' Fields
        Private rectangle_0 As Rectangle = New Rectangle
        Private solidBrush_0 As SolidBrush
        Private int_0 As Integer
        Private collection_0 As Collection(Of MessageByValue) = New Collection(Of MessageByValue)
        Private linearGradientBrush_0 As LinearGradientBrush
        Private color_0 As Color = Color.Maroon
        Private font_0 As Font = New Font("Arial", 16!, FontStyle.Regular, GraphicsUnit.Point)
        Private solidBrush_1 As SolidBrush = New SolidBrush(Color.Black)
        Private pen_0 As Pen
        Private string_0 As String
        Private decimal_0 As Decimal = Decimal.One
        Private stringFormat_0 As StringFormat = New StringFormat
        Private solidBrush_2 As SolidBrush
    End Class
End Namespace

