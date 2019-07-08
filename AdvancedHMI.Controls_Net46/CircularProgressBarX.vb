Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Public Class CircularProgressBarX
    Inherits Control
    ' Events
    Public Event ValueChanged As EventHandler

    ' Methods
    Public Sub New()
        MyBase.SetStyle((ControlStyles.OptimizedDoubleBuffer Or (ControlStyles.AllPaintingInWmPaint Or (ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint))), True)
        Me.pen_0 = New Pen(Color.Lime, 4!)
        Me.pen_1 = New Pen(Color.White, 4!)
        Me.solidBrush_0 = New SolidBrush(Color.White)
        Me.rectangle_0 = New Rectangle
        Me.stringFormat_0.Alignment = StringAlignment.Center
        Me.stringFormat_0.LineAlignment = StringAlignment.Center
        Me.BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If disposing Then
            If (Me.pen_0 > Nothing) Then
                Me.pen_0.Dispose
            End If
            If (Me.pen_1 > Nothing) Then
                Me.pen_1.Dispose
            End If
            If (Me.solidBrush_0 > Nothing) Then
                Me.solidBrush_0.Dispose
            End If
            If (Me.stringFormat_0 > Nothing) Then
                Me.stringFormat_0.Dispose
            End If
        End If
    End Sub

    Private Sub method_0()
        Me.point_0 = New Point(CInt(Math.Round(CDbl((CDbl(MyBase.Width) / 2)))), CInt(Math.Round(CDbl((CDbl(MyBase.Height) / 2)))))
        Me.rectangle_0.Height = (Math.Min(MyBase.Width, MyBase.Height) - (Me.PenSize * 2))
        Me.rectangle_0.Width = Me.rectangle_0.Height
        Me.rectangle_0.X = CInt(Math.Round(CDbl((CDbl((MyBase.Width - Me.rectangle_0.Width)) / 2))))
        Me.rectangle_0.Y = CInt(Math.Round(CDbl((CDbl((MyBase.Height - Me.rectangle_0.Height)) / 2))))
        If ((MyBase.Width > 0) And (MyBase.Height > 0)) Then
            Dim path As New GraphicsPath
            path.AddEllipse(Me.rectangle_0)
            MyBase.Region = New Region(path)
        Else
            MyBase.Region = Nothing
        End If
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        Me.solidBrush_0.Color = Me.ForeColor
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim graphics As Graphics = e.Graphics
        Dim sweepAngle As Single = CSng(((360 * (Me.double_0 - Me.int_0)) / CDbl((Me.int_1 - Me.int_0))))
        Dim num2 As Single = (360.0! - sweepAngle)
        graphics.SmoothingMode = SmoothingMode.AntiAlias
        graphics.DrawArc(Me.pen_0, Me.rectangle_0, -90.0!, sweepAngle)
        graphics.DrawArc(Me.pen_1, Me.rectangle_0, (sweepAngle - 90.0!), num2)
        If Me.ShowValue Then
            Dim str As String = Conversions.ToString(Me.double_0)
            Try
                If Not String.IsNullOrEmpty(Me.string_0) Then
                    str = Me.double_0.ToString(Me.string_0)
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                str = "Invalid NumericFormat"
                ProjectData.ClearProjectError()
            End Try
            graphics.DrawString((str & Me.string_1), Me.Font, Me.solidBrush_0, DirectCast(Me.point_0, PointF), Me.stringFormat_0)
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.method_0
    End Sub

    Protected Overridable Sub OnValueChanged()
        Dim handler As EventHandler = Me.eventHandler_0
        If (Not handler Is Nothing) Then
            handler.Invoke(Me, EventArgs.Empty)
        End If
    End Sub


    ' Properties
    Public Property Value As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            If Not (value = Me.double_0) Then
                Me.double_0 = value
                MyBase.Invalidate
                Me.OnValueChanged
            End If
        End Set
    End Property

    Public Property Minimum As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.int_0) Then
                Me.int_0 = value
                Me.method_0
            End If
        End Set
    End Property

    Public Property Maximum As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            If (value <> Me.int_1) Then
                Me.int_1 = value
                Me.method_0
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

    Public Property Suffix As String
        Get
            Return Me.string_1
        End Get
        Set(ByVal value As String)
            Me.string_1 = value
            MyBase.Invalidate
        End Set
    End Property

    Public Property PenSize As Integer
        Get
            Return Me.int_2
        End Get
        Set(ByVal value As Integer)
            If (Me.int_2 <> value) Then
                Me.int_2 = value
                Me.pen_0.Width = value
                Me.pen_1.Width = value
                MyBase.Invalidate
            End If
        End Set
    End Property

    Public Property ShowValue As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            Me.bool_0 = value
            MyBase.Invalidate
        End Set
    End Property

    Public Property PenBackColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            Me.color_0 = value
            MyBase.Invalidate
        End Set
    End Property

    Public Property PenForeColor As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            Me.color_1 = value
            MyBase.Invalidate
        End Set
    End Property


    ' Fields
    Private point_0 As Point = New Point
    Private pen_0 As Pen
    Private pen_1 As Pen
    Private solidBrush_0 As SolidBrush
    Private rectangle_0 As Rectangle
    Private stringFormat_0 As StringFormat = New StringFormat
    Private double_0 As Double = 0
    Private int_0 As Integer
    Private int_1 As Integer = 100
    Private string_0 As String
    Private string_1 As String = "%"
    Private int_2 As Integer = 4
    Private bool_0 As Boolean = True
    Private color_0 As Color = Color.White
    Private color_1 As Color = Color.Lime
End Class

