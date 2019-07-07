Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class BeveledButtonDisplay

    Inherits ButtonBase

    Private m_Text2 As String

    Private m_BorderColor As Color

    Private m_BackColorOn As Color

    Private m_BorderWidth As Integer

    Private m_BeepOnClick As Boolean

    Private m_OutputType As OutputType

    Public Property BackcolorOn As Color
        Get
            Return Me.m_BackColorOn
        End Get
        Set(ByVal value As Color)
            Me.m_BackColorOn = value
            Me.CreateStaticImage()
        End Set
    End Property

    Public Property BeepOnClick As Boolean
        Get
            Return Me.m_BeepOnClick
        End Get
        Set(ByVal value As Boolean)
            Me.m_BeepOnClick = value
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return Me.m_BorderColor
        End Get
        Set(ByVal value As Color)
            Me.m_BorderColor = value
            Me.CreateStaticImage()
            Me.OnBorderColorChanged(EventArgs.Empty)
        End Set
    End Property

    Public Property BorderWidth As Integer
        Get
            Return Me.m_BorderWidth
        End Get
        Set(ByVal value As Integer)
            If (Me.m_BorderWidth <> value) Then
                Me.m_BorderWidth = Math.Min(Math.Max(2, value), 10)
                Me.CreateStaticImage()
                Me.OnBorderWidthChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property OutputType As OutputType
        Get
            Return Me.m_OutputType
        End Get
        Set(ByVal value As OutputType)
            Me.m_OutputType = value
        End Set
    End Property

    Public Property Text2 As String
        Get
            Return Me.m_Text2
        End Get
        Set(ByVal value As String)
            If (Operators.CompareString(Me.m_Text2, value, False) <> 0) Then
                Me.m_Text2 = value
                Me.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property



    Public Sub New()
        MyBase.New()

        Me.m_BackColorOn = Color.Black
        Me.m_BeepOnClick = True
        Me.m_OutputType = OutputType.MomentarySet
        Me.m_BorderColor = Color.DimGray
        MyBase.BackColor = Color.LightGray
        Me.m_BorderWidth = 7
        Me.CreateStaticImage()
    End Sub



    Public Shared Sub Draw3DBorder(ByVal c As Control, ByVal g As Graphics, ByVal color As System.Drawing.Color, ByVal width As Integer)
        Dim point() As System.Drawing.Point = {New System.Drawing.Point(0, 0), New System.Drawing.Point(0, c.Height), New System.Drawing.Point(width, c.Height - width), New System.Drawing.Point(width, width), New System.Drawing.Point(c.Width - width, width), New System.Drawing.Point(c.Width, 0)}
        g.FillPolygon(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(color, 1.8)), point)
        g.DrawLine(New Pen(System.Drawing.Color.FromArgb(128, 32, 32, 32), 1.0!), point(0), point(3))
        point(0).X = c.Width
        point(0).Y = c.Height
        point(3).X = c.Width - width
        point(3).Y = c.Height - width
        g.FillPolygon(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(color, 0.5)), point)
        g.DrawLine(New Pen(System.Drawing.Color.FromArgb(128, 120, 120, 120), 1.0!), point(0), point(3))
        Dim point1 As System.Drawing.Point = New System.Drawing.Point(0, 0)
        Dim point2 As System.Drawing.Point = New System.Drawing.Point(c.Width, c.Height)
        Dim linearGradientBrush As System.Drawing.Drawing2D.LinearGradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(point1, point2, BeveledButtonDisplay.GetRelativeColor(color, 1.2), BeveledButtonDisplay.GetRelativeColor(color, 2.1))
        g.FillRectangle(linearGradientBrush, width, width, c.Width - width * 2, c.Height - width * 2)
    End Sub

    Public Shared Function GetRelativeColor(ByVal color As System.Drawing.Color, ByVal intensity As Double) As System.Drawing.Color
        intensity = Math.Max(intensity, 0)
        Dim color1 As System.Drawing.Color = System.Drawing.Color.FromArgb(CInt(Math.Round(Math.Min(CDbl((color.R + 1)) * intensity, 255))), CInt(Math.Round(Math.Min(CDbl((color.G + 1)) * intensity, 255))), CInt(Math.Round(Math.Min(CDbl((color.B + 1)) * intensity, 255))))
        Return color1
    End Function

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overridable Sub OnBorderColorChanged(ByVal e As EventArgs)
        RaiseEvent BorderColorChanged(Me, e)
    End Sub

    Protected Overridable Sub OnBorderWidthChanged(ByVal e As EventArgs)
        RaiseEvent BorderWidthChanged(Me, e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Console.Beep()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If (Me.OnImage IsNot Nothing) Then
            Me.sf.LineAlignment = StringAlignment.Center
            Me.sf.Alignment = StringAlignment.Center
            If (Not Me.m_Value) Then
                e.Graphics.DrawImage(Me.OffImage, 0, 0)
                e.Graphics.DrawString(Me.Text, Me.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            Else
                e.Graphics.DrawImage(Me.OnImage, 0, 0)
                e.Graphics.DrawString(Me.m_Text2, Me.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        If (Operators.CompareString(Me.m_Text2, String.Empty, False) = 0) Then
            Me.m_Text2 = Me.Text
        End If
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub CreateStaticImage()
        If (Not (Me.Width <= 0 Or Me.Height <= 0)) Then
            Me.OnImage = New Bitmap(Me.Width, Me.Height)
            Me.OffImage = New Bitmap(Me.Width, Me.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.OnImage)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.OffImage)
            BeveledButtonDisplay.Draw3DBorder(Me, graphic, Me.m_BorderColor, Me.m_BorderWidth)
            BeveledButtonDisplay.Draw3DBorder(Me, graphic1, Me.m_BorderColor, Me.m_BorderWidth)
            Dim width As Integer = Me.Width - Me.m_BorderWidth * 4
            If (width <= 0) Then
                width = 1
            End If
            Dim height As Integer = Me.Height - Me.m_BorderWidth * 4
            If (height <= 0) Then
                height = 1
            End If
            Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(Me.m_BorderWidth * 2, Me.m_BorderWidth * 2, width, height)
            Dim graphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
            graphicsPath.AddRectangle(rectangle)
            Dim pathGradientBrush As System.Drawing.Drawing2D.PathGradientBrush = New System.Drawing.Drawing2D.PathGradientBrush(graphicsPath)
            If (Me.m_BackColorOn <> Color.Black) Then
                pathGradientBrush.CenterColor = BeveledButtonDisplay.GetRelativeColor(Me.m_BackColorOn, 20)
            Else
                pathGradientBrush.CenterColor = BeveledButtonDisplay.GetRelativeColor(Me.BackColor, 20)
            End If
            Dim mBackColorOn(0) As Color
            If (Me.m_BackColorOn <> Color.Black) Then
                mBackColorOn(0) = Me.m_BackColorOn
            Else
                mBackColorOn(0) = BeveledButtonDisplay.GetRelativeColor(Me.BackColor, 0.9)
            End If
            pathGradientBrush.SurroundColors = mBackColorOn
            graphic.FillRectangle(pathGradientBrush, rectangle)
            If (Me.m_BackColorOn <> Color.Black) Then
                graphic.DrawRectangle(New Pen(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.m_BackColorOn, 0.75)), 2.0!), rectangle)
            Else
                graphic.DrawRectangle(New Pen(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.m_BorderColor, 0.5)), 2.0!), rectangle)
            End If
            graphic1.FillRectangle(New SolidBrush(Me.BackColor), rectangle)
            graphic1.DrawRectangle(New Pen(New SolidBrush(BeveledButtonDisplay.GetRelativeColor(Me.m_BorderColor, 0.5)), 2.0!), rectangle)
            Me.TextRectangle = New System.Drawing.Rectangle(Me.m_BorderWidth * 2 + 1, Me.m_BorderWidth * 2 + 1, Me.Width - (Me.m_BorderWidth * 4 + 2), Me.Height - (Me.m_BorderWidth * 4 + 2))
            Dim r As Byte = Me.ForeColor.R
            Dim g As Byte = Me.ForeColor.G
            Dim foreColor As Color = Me.ForeColor
            Me.TextBrush = New SolidBrush(Color.FromArgb(216, CInt(r), CInt(g), CInt(foreColor.B)))
            Me.Invalidate()
        End If
    End Sub

    Public Event BorderColorChanged As EventHandler

    Public Event BorderWidthChanged As EventHandler
End Class

