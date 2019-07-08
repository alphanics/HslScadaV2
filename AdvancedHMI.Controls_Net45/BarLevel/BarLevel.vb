Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class BarLevel
    Inherits AnalogMeterBase

    Private sfCenter As StringFormat

    Private sfCenterTop As StringFormat

    Private sfLeftCenter As StringFormat

    Private sfRightCenter As StringFormat

    Private VerticalScaledValue As Single

    Private HorizontalScaledValue As Single

    Private m_TextSuffix As String

    Private m_FlatStyle As FlatStyle

    Private m_Format As String

    Private m_BarFillBrush As Brush

    Private m_BarContentColor As Color

    Private m_FillStyle As BarLevel.BarStyle

    Private m_BorderPen As Pen

    Private m_FillDirection As BarLevel.FillDirectionEnum

    Public Property BarContentColor() As Color
        Get
            Return Me.m_BarContentColor
        End Get
        Set(ByVal value As Color)
            Me.m_BarContentColor = value
            If Me.m_FillStyle <> BarLevel.BarStyle.Hatch Then
                Me.m_BarFillBrush = New SolidBrush(Me.m_BarContentColor)
            Else
                Me.m_BarFillBrush = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value)
            End If
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderColor() As Color
        Get
            Return Me.m_BorderPen.Color
        End Get
        Set(ByVal value As Color)
            If Me.m_BorderPen IsNot Nothing Then
                Me.m_BorderPen.Color = value
            Else
                Me.m_BorderPen = New Pen(value, 1.0F)
            End If
            Me.CreateStaticImage()
        End Set
    End Property

    Public Property FillDirection() As BarLevel.FillDirectionEnum
        Get
            Return Me.m_FillDirection
        End Get
        Set(ByVal value As BarLevel.FillDirectionEnum)
            If value <> Me.m_FillDirection Then
                Me.m_FillDirection = value
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property FillStyle() As BarLevel.BarStyle
        Get
            Return Me.m_FillStyle
        End Get
        Set(ByVal value As BarLevel.BarStyle)
            If Me.m_FillStyle <> value Then
                Me.m_FillStyle = value
                If Me.m_FillStyle <> BarLevel.BarStyle.Hatch Then
                    Me.m_BarFillBrush = New SolidBrush(Me.m_BarContentColor)
                Else
                    'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
                    'ORIGINAL LINE: this.m_BarFillBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max((this.m_BarContentColor.R - 40), 0), Math.Max((this.m_BarContentColor.G - 40), 0), Math.Max((this.m_BarContentColor.B - 40), 0)), this.m_BarContentColor);
                    Me.m_BarFillBrush = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(Me.m_BarContentColor.R - 40, 0), Math.Max(Me.m_BarContentColor.G - 40, 0), Math.Max(Me.m_BarContentColor.B - 40, 0)), Me.m_BarContentColor)
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property FlatStyle() As FlatStyle
        Get
            Return Me.m_FlatStyle
        End Get
        Set(ByVal value As FlatStyle)
            If Me.m_FlatStyle <> value Then
                Me.m_FlatStyle = value
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property NumericFormat() As String
        Get
            Return Me.m_Format
        End Get
        Set(ByVal value As String)
            Me.m_Format = value
        End Set
    End Property

    Public Property TextSuffix() As String
        Get
            Return Me.m_TextSuffix
        End Get
        Set(ByVal value As String)
            Me.m_TextSuffix = value
        End Set
    End Property

    Public Sub New()
        Me.sfCenter = New StringFormat()
        Me.sfCenterTop = New StringFormat()
        Me.sfLeftCenter = New StringFormat()
        Me.sfRightCenter = New StringFormat()
        Me.m_FillStyle = BarLevel.BarStyle.Hatch
        Me.m_BorderPen = New Pen(Color.Wheat, 1.0F)
        Me.m_FillDirection = BarLevel.FillDirectionEnum.Up
        Me.ForeColor = Color.WhiteSmoke
        Me.sfCenterTop = New StringFormat() With {
         .Alignment = StringAlignment.Center,
         .LineAlignment = StringAlignment.Near
        }
        Me.sfCenter = New StringFormat() With {
         .Alignment = StringAlignment.Center,
         .LineAlignment = StringAlignment.Center
        }
        Me.sfLeftCenter = New StringFormat() With {
         .Alignment = StringAlignment.Near,
         .LineAlignment = StringAlignment.Center
        }
        Me.sfRightCenter = New StringFormat() With {
         .Alignment = StringAlignment.Far,
         .LineAlignment = StringAlignment.Center
        }
        Me.m_BarContentColor = Color.Red
        Me.m_BarFillBrush = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Black, Color.Red)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.CreateStaticImage()
    End Sub

    Private Sub CalculateScaledValue()
        Dim mMaximum As Single = CSng(1 / (Me.m_Maximum - Me.m_Minimum) * (Me.m_Value * Me.ValueScaleFactor - Me.m_Minimum))
        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
        'ORIGINAL LINE: this.VerticalScaledValue = (float)((this.Height - 2)) * mMaximum;
        Me.VerticalScaledValue = CSng(Me.Height - 2) * mMaximum
        'INSTANT VB TODO TASK: There is no VB equivalent to '' in this context:
        'ORIGINAL LINE: this.HorizontalScaledValue = (float)((this.Width - 2)) * mMaximum;
        Me.HorizontalScaledValue = CSng(Me.Width - 2) * mMaximum
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If Me.BackBuffer IsNot Nothing Then
                    Me.BackBuffer.Dispose()
                End If
                If Me.m_BarFillBrush IsNot Nothing Then
                    Me.m_BarFillBrush.Dispose()
                End If
                If Me.sfCenter IsNot Nothing Then
                    Me.sfCenter.Dispose()
                End If
                If Me.sfCenterTop IsNot Nothing Then
                    Me.sfCenterTop.Dispose()
                End If
                If Me.sfLeftCenter IsNot Nothing Then
                    Me.sfLeftCenter.Dispose()
                End If
                If Me.sfRightCenter IsNot Nothing Then
                    Me.sfRightCenter.Dispose()
                End If
                If Me.m_BorderPen IsNot Nothing Then
                    Me.m_BorderPen.Dispose()
                End If
                If Me.TextBrush IsNot Nothing Then
                    Me.TextBrush.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        If Me.TextBrush IsNot Nothing Then
            Me.TextBrush.Color = MyBase.ForeColor
        Else
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim rectangle As Rectangle
        Dim rectangle1 As Rectangle
        If Not (Me.BackBuffer Is Nothing Or Me.TextBrush Is Nothing Or Me.m_BorderPen Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.Clear(MyBase.BackColor)
            If Me.m_BarFillBrush IsNot Nothing Then
                Dim str As String = Convert.ToString(Me.m_Value * Me.m_ValueScaleFactor)
                If (If(Me.m_Format Is Nothing OrElse String.Compare(Me.m_Format, String.Empty) = 0, False, True)) And Not Me.DesignMode Then
                    Try
                        Me.m_Value.ToString()
                        Dim mValue As Double = CDbl(CSng(Me.m_Value)) * Me.m_ValueScaleFactor
                        str = mValue.ToString(Me.m_Format)
                    Catch exception As Exception
                        ProjectData.SetProjectError(exception)
                        str = "Check NumericFormat and variable type"
                        ProjectData.ClearProjectError()
                    End Try
                End If
                Select Case Me.m_FillDirection
                    Case BarLevel.FillDirectionEnum.Down
                        graphic.FillRectangle(Me.m_BarFillBrush, 1, 1, Me.Width, Convert.ToInt32(Me.VerticalScaledValue))
                        Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(Math.Max(Me.VerticalScaledValue - CSng(MyBase.FontHeight) - 2.0F, 0.0F)))))
                        Me.TextRectangle.Y = Math.Min(Me.TextRectangle.Y, (Me.Height - MyBase.FontHeight) - 2)
                        graphic.DrawString(String.Concat(str, Me.m_TextSuffix), MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterTop)
                        Exit Select
                    Case BarLevel.FillDirectionEnum.Left
                        rectangle = New Rectangle(CInt(Math.Truncate(Math.Round(CDbl(Math.Max(2.0F, CSng(Me.Width) - Me.HorizontalScaledValue + 2.0F))))), 2, Convert.ToInt32(Me.HorizontalScaledValue), Me.Height - 4)
                        graphic.FillRectangle(Me.m_BarFillBrush, Me.Width - Convert.ToInt32(Me.HorizontalScaledValue), 0, Convert.ToInt32(Me.HorizontalScaledValue), Me.Height)
                        If CInt(Math.Round(CDbl(graphic.MeasureString(String.Concat(Conversions.ToString(Me.m_Value), Me.m_TextSuffix), MyBase.Font).Width))) >= Convert.ToInt32(Me.HorizontalScaledValue) Then
                            Dim str1 As String = String.Concat(str, Me.m_TextSuffix)
                            Dim font_Renamed As Font = MyBase.Font
                            Dim textBrush_Renamed As SolidBrush = Me.TextBrush
                            rectangle1 = New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
                            graphic.DrawString(str1, font_Renamed, textBrush_Renamed, rectangle1, Me.sfRightCenter)
                        Else
                            graphic.DrawString(String.Concat(str, Me.m_TextSuffix), MyBase.Font, Me.TextBrush, rectangle, Me.sfLeftCenter)
                        End If
                        Exit Select
                    Case BarLevel.FillDirectionEnum.Right
                        rectangle = New Rectangle(2, 2, Convert.ToInt32(Me.HorizontalScaledValue), Me.Height - 4)
                        If Not (Me.m_FlatStyle = FlatStyle.Flat Or Not ProgressBarRenderer.IsSupported) Then
                            ProgressBarRenderer.DrawHorizontalChunks(graphic, rectangle)
                        Else
                            graphic.FillRectangle(Me.m_BarFillBrush, 1, 1, Convert.ToInt32(Me.HorizontalScaledValue), Me.Height - 2)
                        End If
                        If CInt(Math.Round(CDbl(graphic.MeasureString(String.Concat(Conversions.ToString(Me.m_Value), Me.m_TextSuffix), MyBase.Font).Width))) >= Convert.ToInt32(Me.HorizontalScaledValue) Then
                            Dim str2 As String = String.Concat(str, Me.m_TextSuffix)
                            Dim font1 As Font = MyBase.Font
                            Dim solidBrush As SolidBrush = Me.TextBrush
                            rectangle1 = New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
                            graphic.DrawString(str2, font1, solidBrush, rectangle1, Me.sfLeftCenter)
                        Else
                            graphic.DrawString(String.Concat(str, Me.m_TextSuffix), MyBase.Font, Me.TextBrush, rectangle, Me.sfRightCenter)
                        End If
                        Exit Select
                    Case Else
                        rectangle = New Rectangle(1, Me.Height - Convert.ToInt32(Me.VerticalScaledValue), Me.Width, Convert.ToInt32(Me.VerticalScaledValue))
                        If Not (Me.m_FlatStyle = FlatStyle.Flat Or Not ProgressBarRenderer.IsSupported) Then
                            ProgressBarRenderer.DrawVerticalChunks(graphic, rectangle)
                        Else
                            graphic.FillRectangle(Me.m_BarFillBrush, 1, Me.Height - Convert.ToInt32(Me.VerticalScaledValue), Me.Width, Convert.ToInt32(Me.VerticalScaledValue))
                        End If
                        Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) - Math.Max(Me.VerticalScaledValue, CSng(MyBase.FontHeight)))))))
                        Me.TextRectangle.Y = Math.Max(Me.TextRectangle.Y, 0)
                        graphic.DrawString(String.Concat(str, Me.m_TextSuffix), MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterTop)
                        Exit Select
                End Select
            End If
            graphic.DrawRectangle(Me.m_BorderPen, 0, 0, Me.Width - 1, Me.Height - 1)
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.CalculateScaledValue()
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Me.Parent IsNot Nothing Then
            Me.Parent.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.CreateStaticImage()
    End Sub

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        Me.CalculateScaledValue()
        Me.Invalidate()
    End Sub

    Protected Overrides Sub CreateStaticImage()
        Me.TextRectangle.X = 1
        Me.TextRectangle.Y = 1
        Me.TextRectangle.Width = Me.Width - 2
        Me.TextRectangle.Height = MyBase.FontHeight + 4
        If Me.BackBuffer IsNot Nothing Then
            Me.BackBuffer.Dispose()
        End If
        If Me.Width > 0 And Me.Height > 0 Then
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
        End If
        Me.CalculateScaledValue()
        Me.Invalidate()
    End Sub

    Public Enum BarStyle
        Solid
        Hatch
    End Enum

    Public Enum FillDirectionEnum
        Up
        Down
        Left
        Right
    End Enum
End Class

