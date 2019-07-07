Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class LinearMeter
    Inherits AnalogMeterBase

    Private sfCenter As StringFormat

    Private sfCenterTop As StringFormat

    Private VerticalScaledValue As Single

    Private HorizontalScaledValue As Single

    Private m_FlatStyle As FlatStyle

    Private m_BarContentColor As HatchBrush

    Private m_BorderPen As Pen

    Private m_FillDirection As LinearMeter.FillDirectionEnum

    Private m_MajorTicks As Integer

    Public Property BarContentColor() As Color
        Get
            Return Me.m_BarContentColor.BackgroundColor
        End Get
        Set(ByVal value As Color)
            Me.m_BarContentColor = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(240, Math.Max(value.R - 40, 0), Math.Max(value.G - 40, 0), Math.Max(value.B - 40, 0)), value)
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
            Me.Invalidate()
        End Set
    End Property

    Public Property FillDirection() As LinearMeter.FillDirectionEnum
        Get
            Return Me.m_FillDirection
        End Get
        Set(ByVal value As LinearMeter.FillDirectionEnum)
            If value <> Me.m_FillDirection Then
                Me.m_FillDirection = value
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property FlatStyle() As FlatStyle
        Get
            Return Me.m_FlatStyle
        End Get
        Set(ByVal value As FlatStyle)
            Me.m_FlatStyle = value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            Me.CreateStaticImage()
            Me.Invalidate()
        End Set
    End Property

    Public Property MajorTicks() As Integer
        Get
            Return Me.m_MajorTicks
        End Get
        Set(ByVal value As Integer)
            If value <> Me.m_MajorTicks Then
                If value >= 0 Then
                    Me.m_MajorTicks = value
                Else
                    Me.m_MajorTicks = 0
                End If
                Me.CreateStaticImage()
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Sub New()
        Me.sfCenter = New StringFormat()
        Me.sfCenterTop = New StringFormat()
        Me.m_BarContentColor = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Red, Color.DarkOrange)
        Me.m_BorderPen = New Pen(Color.Wheat, 1.0F)
        Me.m_FillDirection = LinearMeter.FillDirectionEnum.Up
        Me.ForeColor = Color.WhiteSmoke
        Me.sfCenter = New StringFormat()
        Me.sfCenterTop = New StringFormat()
        Me.CreateStaticImage()
    End Sub

    Private Sub CalculateScaledValue()
        Dim mMaximum As Single = CSng(1 / (Me.m_Maximum - Me.m_Minimum) * (Me.m_Value - Me.m_Minimum))
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.VerticalScaledValue = (float)(checked(this.Height - 2)) * mMaximum;
        Me.VerticalScaledValue = CSng(Me.Height - 2) * mMaximum
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.HorizontalScaledValue = (float)(checked(this.Width - 2)) * mMaximum;
        Me.HorizontalScaledValue = CSng(Me.Width - 2) * mMaximum
    End Sub

    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                Me.BackBuffer.Dispose()
                Me.m_BarContentColor.Dispose()
                Me.sfCenterTop.Dispose()
                Me.sfCenter.Dispose()
                Me.TextBrush.Dispose()
                Me.m_BorderPen.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.BackBuffer Is Nothing Or Me.TextBrush Is Nothing Or Me.m_BorderPen Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me.BackBuffer)
            graphic.FillRectangle(New SolidBrush(MyBase.BackColor), 0, 0, Me.Width, Me.Height)
            'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim width_Renamed As Integer = Me.Width
            If Me.m_BarContentColor IsNot Nothing Then
                Select Case Me.m_FillDirection
                    Case LinearMeter.FillDirectionEnum.Down
                        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        'ORIGINAL LINE: graphic.FillRectangle(this.m_BarContentColor, 0, checked(Convert.ToInt32(this.VerticalScaledValue) - 1), width, 2);
                        graphic.FillRectangle(Me.m_BarContentColor, 0, Convert.ToInt32(Me.VerticalScaledValue) - 1, width_Renamed, 2)
                        If Me.VerticalScaledValue + CSng(MyBase.FontHeight) < CSng(Me.Height) Then
                            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            'ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)(this.VerticalScaledValue - (float)base.FontHeight - 2f))));
                            Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(CSng(Me.VerticalScaledValue - CSng(MyBase.FontHeight) - 2.0F)))))
                            graphic.DrawString(Conversions.ToString(Me.m_Value), MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterTop)
                        End If
                        Exit Select
                    Case LinearMeter.FillDirectionEnum.Left
                        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        'ORIGINAL LINE: graphic.FillRectangle(this.m_BarContentColor, checked(this.Width - Convert.ToInt32(this.HorizontalScaledValue)), 0, Convert.ToInt32(this.HorizontalScaledValue), this.Height);
                        graphic.FillRectangle(Me.m_BarContentColor, Me.Width - Convert.ToInt32(Me.HorizontalScaledValue), 0, Convert.ToInt32(Me.HorizontalScaledValue), Me.Height)
                        Exit Select
                    Case LinearMeter.FillDirectionEnum.Right
                        graphic.FillRectangle(Me.m_BarContentColor, 0, 0, Convert.ToInt32(Me.HorizontalScaledValue), Me.Height)
                        Exit Select
                    Case Else
                        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        'ORIGINAL LINE: graphic.FillRectangle(this.m_BarContentColor, Convert.ToInt32((double)this.Width / 3), checked(checked(this.Height - Convert.ToInt32(this.VerticalScaledValue)) - 1), width, 2);
                        graphic.FillRectangle(Me.m_BarContentColor, Convert.ToInt32(CDbl(Me.Width) / 3), (Me.Height - Convert.ToInt32(Me.VerticalScaledValue)) - 1, width_Renamed, 2)
                        If CSng(Me.Height) - Me.VerticalScaledValue + CSng(MyBase.FontHeight) < CSng(Me.Height) Then
                            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            'ORIGINAL LINE: this.TextRectangle.Y = checked((int)Math.Round((double)((float)((float)this.Height - this.VerticalScaledValue))));
                            Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(CSng(CSng(Me.Height) - Me.VerticalScaledValue)))))
                            graphic.DrawString(Conversions.ToString(Me.m_Value), MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterTop)
                        End If
                        Exit Select
                End Select
            End If
            If Me.m_MajorTicks <> 0 Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawRectangle(this.m_BorderPen, Convert.ToInt32((double)this.Width / 3), 0, checked(width - 1), checked(this.Height - 1));
                graphic.DrawRectangle(Me.m_BorderPen, Convert.ToInt32(CDbl(Me.Width) / 3), 0, width_Renamed - 1, Me.Height - 1)
                If Me.m_MajorTicks <= 1 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.FillRectangle(Brushes.Wheat, 0, Convert.ToInt32((double)this.Height / 2), checked(Convert.ToInt32((double)this.Width / 3) - 2), 2);
                    graphic.FillRectangle(Brushes.Wheat, 0, Convert.ToInt32(CDbl(Me.Height) / 2), Convert.ToInt32(CDbl(Me.Width) / 3) - 2, 2)
                Else
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: int num = checked((int)Math.Round((double)(checked(this.Height - 2)) / (double)(checked(this.m_MajorTicks - 1))));
                    Dim num As Integer = CInt(Math.Truncate(Math.Round(CDbl(Me.Height - 2) / CDbl(Me.m_MajorTicks - 1))))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: int mMajorTicks = checked(this.m_MajorTicks - 1);
                    Dim mMajorTicks As Integer = Me.m_MajorTicks - 1
                    For i As Integer = 0 To mMajorTicks
                        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        'ORIGINAL LINE: graphic.FillRectangle(Brushes.Wheat, 0, checked(i * num), checked(Convert.ToInt32((double)this.Width / 3) - 2), 2);
                        graphic.FillRectangle(Brushes.Wheat, 0, i * num, Convert.ToInt32(CDbl(Me.Width) / 3) - 2, 2)
                    Next i
                End If
            Else
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawRectangle(this.m_BorderPen, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                graphic.DrawRectangle(Me.m_BorderPen, 0, 0, Me.Width - 1, Me.Height - 1)
            End If
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

    Protected Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        Me.CalculateScaledValue()
        Me.Invalidate()
    End Sub

    Protected Overrides Sub CreateStaticImage()
        Me.TextRectangle.X = 1
        Me.TextRectangle.Y = 1
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.TextRectangle.Width = checked(this.Width - 2);
        Me.TextRectangle.Width = Me.Width - 2
        If Me.m_MajorTicks > 0 Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Width = Convert.ToInt32((double)(checked(this.Width * 2)) / 3);
            Me.TextRectangle.Width = Convert.ToInt32(CDbl(Me.Width * 2) / 3)
            Me.TextRectangle.X = Convert.ToInt32(CDbl(Me.Width) / 3)
        End If
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.TextRectangle.Height = checked(base.FontHeight + 4);
        Me.TextRectangle.Height = MyBase.FontHeight + 4
        If Me.sfCenterTop Is Nothing Then
            Me.sfCenterTop = New StringFormat()
        End If
        Me.sfCenterTop.Alignment = StringAlignment.Center
        Me.sfCenterTop.LineAlignment = StringAlignment.Near
        Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        If Me.BackBuffer IsNot Nothing Then
            Me.BackBuffer.Dispose()
        End If
        If Me.Width > 0 And Me.Height > 0 Then
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
        End If
        Me.Invalidate()
    End Sub

    Public Enum FillDirectionEnum
        Up
        Down
        Left
        Right
    End Enum
End Class

