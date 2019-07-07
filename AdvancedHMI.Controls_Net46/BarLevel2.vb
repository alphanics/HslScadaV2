Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms

Public Class BarLevel2
    Inherits AnalogMeterBase
    Private stringFormat_1 As StringFormat

    Private stringFormat_2 As StringFormat

    Private stringFormat_3 As StringFormat

    Private stringFormat_4 As StringFormat

    Private float_0 As Single

    Private float_1 As Single

    Private float_2 As Single

    Private float_3 As Single

    Private string_0 As String

    Private flatStyle_0 As System.Windows.Forms.FlatStyle

    Private string_1 As String

    Private barStyle_0 As BarLevel2.BarStyle

    Private pen_0 As Pen

    Private fillDirectionOption_0 As BarLevel2.FillDirectionOption

    Private brush_0 As Brush

    Private color_0 As Color

    Private brush_1 As Brush

    Private color_1 As Color

    Private brush_2 As Brush

    Private color_2 As Color

    Private double_0 As Double

    Private double_1 As Double

    Public Property BorderColor As Color
        Get
            Return Me.pen_0.Color
        End Get
        Set(ByVal value As Color)
            If (Me.pen_0 IsNot Nothing) Then
                Me.pen_0.Color = value
            Else
                Me.pen_0 = New Pen(value, 1!)
            End If
            Me.CreateStaticImage()
        End Set
    End Property

    Public Property FillDirection As BarLevel2.FillDirectionOption
        Get
            Return Me.fillDirectionOption_0
        End Get
        Set(ByVal value As BarLevel2.FillDirectionOption)
            If (value <> Me.fillDirectionOption_0) Then
                Me.fillDirectionOption_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property FillStyle As BarLevel2.BarStyle
        Get
            Return Me.barStyle_0
        End Get
        Set(ByVal value As BarLevel2.BarStyle)
            If (Me.barStyle_0 <> value) Then
                Me.barStyle_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property FlatStyle As System.Windows.Forms.FlatStyle
        Get
            Return Me.flatStyle_0
        End Get
        Set(ByVal value As System.Windows.Forms.FlatStyle)
            If (Me.flatStyle_0 <> value) Then
                Me.flatStyle_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            MyBase.ForeColor = value
        End Set
    End Property

    Public Property ForecolorHighLimitValue As Double
        Get
            Return Me.double_0
        End Get
        Set(ByVal value As Double)
            If (Me.double_0 <> value) Then
                Me.double_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property ForeColorInLimits As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            If ((Me.color_0 <> value) Or Me.brush_0 Is Nothing) Then
                Me.color_0 = value
                If (Me.brush_0 IsNot Nothing) Then
                    Me.brush_0.Dispose()
                End If
                If (Me.barStyle_0 <> BarLevel2.BarStyle.Hatch) Then
                    Me.brush_0 = New SolidBrush(value)
                Else
                    Me.brush_0 = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value)
                End If
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property ForecolorLowLimitValue As Double
        Get
            Return Me.double_1
        End Get
        Set(ByVal value As Double)
            If (Me.double_1 <> value) Then
                Me.double_1 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Property ForeColorOverHighLimit As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            If ((Me.color_1 <> value) Or Me.brush_1 Is Nothing) Then
                Me.color_1 = value
                If (Me.brush_1 IsNot Nothing) Then
                    Me.brush_1.Dispose()
                End If
                If (Me.barStyle_0 <> BarLevel2.BarStyle.Hatch) Then
                    Me.brush_1 = New SolidBrush(value)
                Else
                    Me.brush_1 = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value)
                End If
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property ForeColorUnderLowLimit As Color
        Get
            Return Me.color_2
        End Get
        Set(ByVal value As Color)
            If ((Me.color_2 <> value) Or Me.brush_2 Is Nothing) Then
                Me.color_2 = value
                If (Me.brush_2 IsNot Nothing) Then
                    Me.brush_2.Dispose()
                End If
                If (Me.barStyle_0 <> BarLevel2.BarStyle.Hatch) Then
                    Me.brush_2 = New SolidBrush(value)
                Else
                    Me.brush_2 = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value)
                End If
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property NumericFormat As String
        Get
            Return Me.string_1
        End Get
        Set(ByVal value As String)
            Me.string_1 = value
        End Set
    End Property

    Public Property TextSuffix As String
        Get
            Return Me.string_0
        End Get
        Set(ByVal value As String)
            Me.string_0 = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.stringFormat_1 = New StringFormat()
        Me.stringFormat_2 = New StringFormat()
        Me.stringFormat_3 = New StringFormat()
        Me.stringFormat_4 = New StringFormat()
        Me.barStyle_0 = BarLevel2.BarStyle.Hatch
        Me.pen_0 = New Pen(Color.Wheat, 1!)
        Me.fillDirectionOption_0 = BarLevel2.FillDirectionOption.Up
        Me.color_0 = Color.White
        Me.color_1 = Color.Red
        Me.color_2 = Color.Yellow
        Me.double_0 = 999999
        Me.double_1 = -999999

        Me.ForeColor = Color.WhiteSmoke
        Me.stringFormat_2 = New StringFormat() With
        {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Near
        }
        Me.stringFormat_1 = New StringFormat() With
        {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
        }
        Me.stringFormat_3 = New StringFormat() With
        {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Center
        }
        Me.stringFormat_4 = New StringFormat() With
        {
            .Alignment = StringAlignment.Far,
            .LineAlignment = StringAlignment.Center
        }
        Me.CreateStaticImage()

    End Sub

    Protected Overrides Sub CreateStaticImage()
        Me.TextRectangle.X = 1
        Me.TextRectangle.Y = 1
        Me.TextRectangle.Width = MyBase.Width - 2
        Me.TextRectangle.Height = MyBase.FontHeight + 4
        Me.method_2()
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                If (Me.brush_0 IsNot Nothing) Then
                    Me.brush_0.Dispose()
                End If
                If (Me.brush_2 IsNot Nothing) Then
                    Me.brush_2.Dispose()
                End If
                If (Me.brush_1 IsNot Nothing) Then
                    Me.brush_1.Dispose()
                End If
                If (Me.stringFormat_1 IsNot Nothing) Then
                    Me.stringFormat_1.Dispose()
                End If
                If (Me.stringFormat_2 IsNot Nothing) Then
                    Me.stringFormat_2.Dispose()
                End If
                If (Me.stringFormat_3 IsNot Nothing) Then
                    Me.stringFormat_3.Dispose()
                End If
                If (Me.stringFormat_4 IsNot Nothing) Then
                    Me.stringFormat_4.Dispose()
                End If
                If (Me.pen_0 IsNot Nothing) Then
                    Me.pen_0.Dispose()
                End If
                If (Me.TextBrush IsNot Nothing) Then
                    Me.TextBrush.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub method_2()
        Dim [single] As Single = Convert.ToSingle(1 / (Me.m_Maximum * MyBase.ValueScaleFactor - Me.m_Minimum * MyBase.ValueScaleFactor) * (Me.m_Value * MyBase.ValueScaleFactor - Me.m_Minimum * MyBase.ValueScaleFactor))
        Me.float_0 = CSng((MyBase.Height - 2)) * [single]
        Me.float_1 = CSng((MyBase.Width - 2)) * [single]
        [single] = Convert.ToSingle(1 / (Me.m_Maximum * MyBase.ValueScaleFactor - Me.m_Minimum * MyBase.ValueScaleFactor) * (Me.double_0 * MyBase.ValueScaleFactor - Me.m_Minimum * MyBase.ValueScaleFactor))
        Me.float_3 = CSng((MyBase.Width - 2)) * [single]
        [single] = Convert.ToSingle(1 / (Me.m_Maximum * MyBase.ValueScaleFactor - Me.m_Minimum * MyBase.ValueScaleFactor) * (Me.double_1 * MyBase.ValueScaleFactor - Me.m_Minimum * MyBase.ValueScaleFactor))
        Me.float_2 = CSng((MyBase.Width - 2)) * [single]
    End Sub

    Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        If (Me.TextBrush IsNot Nothing) Then
            Me.TextBrush.Color = MyBase.ForeColor
        Else
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        End If
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim brush2 As Brush
        Dim rectangle As System.Drawing.Rectangle
        If (Me.TextBrush IsNot Nothing And Me.pen_0 IsNot Nothing) Then
            Using graphics As System.Drawing.Graphics = painte.Graphics
                graphics.Clear(MyBase.BackColor)
                If (Me.m_Value * Me.m_ValueScaleFactor >= Me.double_1) Then
                    brush2 = If(Me.m_Value * Me.m_ValueScaleFactor <= Me.double_0, Me.brush_0, Me.brush_1)
                Else
                    brush2 = Me.brush_2
                End If
                If (brush2 IsNot Nothing) Then
                    Dim str As String = Convert.ToString(Me.m_Value * Me.m_ValueScaleFactor, CultureInfo.CurrentCulture)
                    If (Not String.IsNullOrEmpty(Me.string_1) And Not MyBase.DesignMode) Then
                        Try
                            Me.m_Value.ToString(CultureInfo.CurrentCulture)
                            Dim mValue As Double = CDbl(CSng(Me.m_Value)) * Me.m_ValueScaleFactor
                            str = mValue.ToString(Me.string_1)
                        Catch exception As System.Exception
                            ProjectData.SetProjectError(exception)
                            str = "Check NumericFormat and variable type"
                            ProjectData.ClearProjectError()
                        End Try
                    End If
                    Select Case Me.fillDirectionOption_0
                        Case BarLevel2.FillDirectionOption.Down
                            graphics.FillRectangle(brush2, 1, 1, MyBase.Width, Convert.ToInt32(Me.float_0))
                            Me.TextRectangle.Y = Math.Min(Me.TextRectangle.Y, MyBase.Height - MyBase.FontHeight - 2)
                            graphics.DrawString(String.Concat(str, Me.string_0), MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.stringFormat_2)
                            Exit Select
                        Case BarLevel2.FillDirectionOption.Left
                            rectangle = New System.Drawing.Rectangle(CInt(Math.Round(CDbl(Math.Max(2!, CSng(MyBase.Width) - Me.float_1 + 2!)))), 2, Convert.ToInt32(Me.float_1), MyBase.Height - 4)
                            graphics.FillRectangle(brush2, MyBase.Width - Convert.ToInt32(Me.float_1), 0, Convert.ToInt32(Me.float_1), MyBase.Height)
                            If (CInt(Math.Round(CDbl(graphics.MeasureString(String.Concat(Conversions.ToString(Me.m_Value), Me.string_0), MyBase.Font).Width))) >= Convert.ToInt32(Me.float_1)) Then
                                graphics.DrawString(String.Concat(str, Me.string_0), MyBase.Font, Me.TextBrush, New System.Drawing.Rectangle(1, 1, MyBase.Width - 2, MyBase.Height - 2), Me.stringFormat_4)
                                Exit Select
                            Else
                                graphics.DrawString(String.Concat(str, Me.string_0), MyBase.Font, Me.TextBrush, rectangle, Me.stringFormat_3)
                                Exit Select
                            End If
                        Case BarLevel2.FillDirectionOption.Right
                            rectangle = New System.Drawing.Rectangle(2, 2, Convert.ToInt32(Me.float_1), MyBase.Height - 4)
                            If (Not (Me.flatStyle_0 = System.Windows.Forms.FlatStyle.Flat Or Not ProgressBarRenderer.IsSupported)) Then
                                ProgressBarRenderer.DrawHorizontalChunks(graphics, rectangle)
                            Else
                                Using solidBrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(ControlPaint.Dark(Me.BackColor, 0.1!))
                                    Using pen As System.Drawing.Pen = New System.Drawing.Pen(ControlPaint.Dark(Me.BackColor, 0.5!), 2!)
                                        Using pen1 As System.Drawing.Pen = New System.Drawing.Pen(ControlPaint.Dark(Me.BackColor, 0.5!), 2!)
                                            graphics.FillRectangle(solidBrush, Convert.ToInt32(Me.float_2), 1, Convert.ToInt32(Me.float_3 - Me.float_2), MyBase.Height - 2)
                                            graphics.FillRectangle(brush2, 1, 1, Convert.ToInt32(Me.float_1), MyBase.Height - 2)
                                            graphics.DrawLine(pen, Convert.ToInt32(Me.float_3), 1, Convert.ToInt32(Me.float_3), MyBase.Height - 2)
                                            graphics.DrawLine(pen1, Convert.ToInt32(Me.float_2), 1, Convert.ToInt32(Me.float_2), MyBase.Height - 2)
                                        End Using
                                    End Using
                                End Using
                            End If
                            If (CInt(Math.Round(CDbl(graphics.MeasureString(String.Concat(Conversions.ToString(Me.m_Value), Me.string_0), MyBase.Font).Width))) >= Convert.ToInt32(Me.float_1)) Then
                                graphics.DrawString(String.Concat(str, Me.string_0), MyBase.Font, Me.TextBrush, New System.Drawing.Rectangle(1, 1, MyBase.Width - 2, MyBase.Height - 2), Me.stringFormat_3)
                                Exit Select
                            Else
                                graphics.DrawString(String.Concat(str, Me.string_0), MyBase.Font, Me.TextBrush, rectangle, Me.stringFormat_4)
                                Exit Select
                            End If
                        Case Else
                            rectangle = New System.Drawing.Rectangle(1, MyBase.Height - Convert.ToInt32(Me.float_0), MyBase.Width, Convert.ToInt32(Me.float_0))
                            If (Not (Me.flatStyle_0 = System.Windows.Forms.FlatStyle.Flat Or Not ProgressBarRenderer.IsSupported)) Then
                                ProgressBarRenderer.DrawVerticalChunks(graphics, rectangle)
                            Else
                                graphics.FillRectangle(brush2, 1, MyBase.Height - Convert.ToInt32(Me.float_0), MyBase.Width, Convert.ToInt32(Me.float_0))
                            End If
                            Me.TextRectangle.Y = CInt(Math.Round(CDbl((CSng(MyBase.Height) - Math.Max(Me.float_0, CSng(MyBase.FontHeight))))))
                            Me.TextRectangle.Y = Math.Max(Me.TextRectangle.Y, 0)
                            graphics.DrawString(String.Concat(str, Me.string_0), MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.stringFormat_2)
                            Exit Select
                    End Select
                End If
                graphics.DrawRectangle(Me.pen_0, 0, 0, MyBase.Width - 1, MyBase.Height - 1)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.method_2()
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        If (MyBase.Parent IsNot Nothing) Then
            MyBase.Parent.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        Me.method_2()
        MyBase.Invalidate()
    End Sub

    Public Enum BarStyle
        Solid
        Hatch
    End Enum

    Public Enum FillDirectionOption
        Up
        Down
        Left
        Right
    End Enum
End Class
