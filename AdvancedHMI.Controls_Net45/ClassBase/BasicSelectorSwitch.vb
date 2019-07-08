Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports System.Windows.Forms


Public Class BasicSelectorSwitch
    Inherits ButtonBase

    Private m_OutputType As OutputType

    Public Property OutputType() As OutputType
        Get
            Return Me.m_OutputType
        End Get
        Set(ByVal value As OutputType)
            Me.m_OutputType = value
        End Set
    End Property

    Public Sub New()

        Me.m_OutputType = OutputType.MomentarySet
    End Sub

    Protected Overrides Sub AdjustSize()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Me.Enabled Then
            If Me.m_OutputType = OutputType.Toggle Then
                Me.m_Value = Not Me.m_Value
            End If
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If Me.Enabled Then
            Me.Invalidate()
        End If
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.BackBuffer Is Nothing Or Me.OnImage Is Nothing) Then
            Dim g As Graphics = Graphics.FromImage(Me.BackBuffer)
            If Not Me.m_Value Then
                g.DrawImage(Me.OffImage, 0, 0)
            Else
                g.DrawImage(Me.OnImage, 0, 0)
            End If
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub CreateStaticImage()
        If Not (Me.Width <= 0 Or Me.Height <= 0) Then
            Dim num As Integer = Math.Max(Me.Width, Me.Height)
            Dim bitmap As New Bitmap(num, num)
            Dim g As Graphics = Graphics.FromImage(bitmap)
            Dim matrix As New Matrix()
            Dim pointF As New PointF(CSng(Me.Width) / 2.0F, CSng(Me.Height) / 2.0F)
            matrix.RotateAt(-25.0F, pointF)
            g.Transform = matrix
            g.FillRectangle(Brushes.DarkGray, Convert.ToInt32(CDbl(Me.Width) / 2 - CDbl(Me.Width) * 0.1), Convert.ToInt32(CDbl(Me.Height) * 0.1), Convert.ToInt32(CDbl(Me.Width) * 0.2), Convert.ToInt32(CDbl(Me.Height) * 0.8))
            g.DrawRectangle(Pens.Red, 0, 0, num - 1, num - 1)
            Me.OffImage = New Bitmap(Me.Width, Me.Height)
            Me.OnImage = New Bitmap(Me.Width, Me.Height)
            Dim gr_dest As Graphics = Graphics.FromImage(Me.OffImage)
            Dim gr_dest2 As Graphics = Graphics.FromImage(Me.OnImage)
            gr_dest.FillEllipse(Brushes.Gray, 0, 0, Me.Width - 1, Me.Height - 1)
            gr_dest.DrawEllipse(Pens.White, 0, 0, Me.Width - 1, Me.Height - 1)
            gr_dest.DrawImage(bitmap, 0, 0, Me.Width, Me.Height)
            gr_dest.Dispose()
            gr_dest2.Dispose()
            If Me.BackBuffer IsNot Nothing Then
                Me.BackBuffer.Dispose()
            End If
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

End Class

