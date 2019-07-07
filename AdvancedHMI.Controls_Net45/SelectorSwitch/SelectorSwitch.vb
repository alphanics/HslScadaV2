Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class SelectorSwitch
    Inherits ButtonBase
#Region "تعريفات"
    Private ButtonImage As Bitmap

    Private m_LegendPlate As LegendPlates

    Private m_OutputType As OutputType

    Private LegendPlateRatio As Decimal
#End Region

#Region "Property"
    Public Enum LegendPlates
        Large
        Small
    End Enum
    Public Property LegendPlate() As SelectorSwitch.LegendPlates
        Get
            Return Me.m_LegendPlate
        End Get
        Set(ByVal value As SelectorSwitch.LegendPlates)
            If Me.m_LegendPlate <> value Then
                Me.m_LegendPlate = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property OutputType() As OutputType
        Get
            Return Me.m_OutputType
        End Get
        Set(ByVal value As OutputType)
            Me.m_OutputType = value
        End Set
    End Property
#End Region
#Region "المشيدات"
    Public Sub New()
        Me.m_LegendPlate = LegendPlates.Large
        Me.m_OutputType = OutputType.MomentarySet
        Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width))
    End Sub
#End Region
#Region "اعدة تعريف الاحداث"
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If Me.Enabled Then
            If Me.OutputType <> OutputType.Toggle Then
                Me.ButtonImage = CType(Me.OffImage, Bitmap)
            End If
            Me.Invalidate()
        End If
    End Sub


    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Me.Enabled Then
            Me.ButtonImage = CType(Me.OnImage, Bitmap)
            If Me.m_OutputType = OutputType.Toggle Then
                Me.Value = Not Me.m_Value
            End If
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImage Is Nothing Or Me.BackBuffer Is Nothing Or Me.ButtonImage Is Nothing) Then
            Dim g As Graphics = Graphics.FromImage(Me.BackBuffer)
            g.DrawImage(Me.StaticImage, 0, 0)
            If Not Me.m_Value Then
                Me.ButtonImage = CType(Me.OffImage, Bitmap)
            Else
                Me.ButtonImage = CType(Me.OnImage, Bitmap)
            End If
            If Me.m_LegendPlate <> SelectorSwitch.LegendPlates.Large Then
                g.DrawImage(Me.ButtonImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.ButtonImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.59 - CDbl(Me.ButtonImage.Height) / 2))
            Else
                g.DrawImage(Me.ButtonImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.ButtonImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.68 - CDbl(Me.ButtonImage.Height) / 2))
            End If
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                g.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
            e.Graphics.DrawImage(Me.BackBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width Then
            If CDbl(Me.Height) / CDbl(Me.Width) <= Convert.ToDouble(Me.LegendPlateRatio) Then
                Me.Height = Convert.ToInt32(Decimal.Multiply(New Decimal(Me.Width), Me.LegendPlateRatio))
            Else
                Me.Width = Convert.ToInt32(Decimal.Divide(New Decimal(Me.Height), Me.LegendPlateRatio))
            End If
        ElseIf CDbl(Me.Height) / CDbl(Me.Width) <= Convert.ToDouble(Me.LegendPlateRatio) Then
            Me.Width = Convert.ToInt32(Decimal.Divide(New Decimal(Me.Height), Me.LegendPlateRatio))
        Else
            Me.Height = Convert.ToInt32(Decimal.Multiply(New Decimal(Me.Width), Me.LegendPlateRatio))
        End If
        Me.LastWidth = Me.Width
        Me.LastHeight = Me.Height
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub
#End Region
#Region "طرق"
    Protected Overrides Sub CreateStaticImage()
        Dim HeightRatio As Decimal
        Dim WidthRatio As Decimal
        If Me.m_LegendPlate <> SelectorSwitch.LegendPlates.Large Then
            WidthRatio = New Decimal(CSng(Me.Width) / CSng(My.Resources.LegendPlateShort.Width))
            HeightRatio = New Decimal(CSng(Me.Height) / CSng(My.Resources.LegendPlateShort.Height))
        Else
            WidthRatio = New Decimal(CSng(Me.Width) / CSng(My.Resources.LegendPlate.Width))
            HeightRatio = New Decimal(CSng(Me.Height) / CSng(My.Resources.LegendPlate.Height))
        End If
        If Decimal.Compare(WidthRatio, HeightRatio) >= 0 Then
            Me.ImageRatio = Convert.ToDouble(HeightRatio)
        Else
            Me.ImageRatio = Convert.ToDouble(WidthRatio)
        End If
        If Me.ImageRatio > 0 Then
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            If Me.m_LegendPlate <> SelectorSwitch.LegendPlates.Large Then
                Me.StaticImage = New Bitmap(Convert.ToInt32(CDbl(My.Resources.LegendPlateShort.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.LegendPlateShort.Height) * Me.ImageRatio))
                Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlateShort.Height) / CDbl(My.Resources.LegendPlateShort.Width))
            Else
                Me.StaticImage = New Bitmap(Convert.ToInt32(CDbl(My.Resources.LegendPlate.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.LegendPlate.Height) * Me.ImageRatio))
                Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width))
            End If
            Dim gr_dest As Graphics = Graphics.FromImage(Me.StaticImage)
            If Me.m_LegendPlate <> SelectorSwitch.LegendPlates.Large Then
                gr_dest.DrawImage(My.Resources.LegendPlateShort, 0, 0, Convert.ToInt32(CDbl(My.Resources.LegendPlateShort.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.LegendPlateShort.Height) * Me.ImageRatio))
            Else
                gr_dest.DrawImage(My.Resources.LegendPlate, 0, 0, Convert.ToInt32(CDbl(My.Resources.LegendPlate.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.LegendPlate.Height) * Me.ImageRatio))
            End If
            Me.OffImage = New Bitmap(Convert.ToInt32(CDbl(My.Resources.SelectorSwitchLeft.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.SelectorSwitchLeft.Height) * Me.ImageRatio))
            Me.OnImage = New Bitmap(Convert.ToInt32(CDbl(My.Resources.SelectorSwitchRight.Width) * Me.ImageRatio), Convert.ToInt32(CDbl(My.Resources.SelectorSwitchRight.Height) * Me.ImageRatio))
            gr_dest = Graphics.FromImage(Me.OffImage)
            Dim gr_dest1 As Graphics = Graphics.FromImage(Me.OnImage)
            gr_dest.DrawImage(My.Resources.SelectorSwitchLeft, 0, 0, Me.OffImage.Width, Me.OffImage.Height)
            gr_dest1.DrawImage(My.Resources.SelectorSwitchRight, 0, 0, Me.OnImage.Width, Me.OnImage.Height)
            Me.ButtonImage = CType(Me.OffImage, Bitmap)
            gr_dest.Dispose()
            gr_dest1.Dispose()
            Me.TextRectangle.X = 0
            Me.TextRectangle.Width = Me.Width
            Me.TextRectangle.Y = 0
            If Me.m_LegendPlate <> SelectorSwitch.LegendPlates.Large Then
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.18)))
            Else
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.4)))
            End If
            Me.sf.Alignment = StringAlignment.Center
            Me.sf.LineAlignment = StringAlignment.Center
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            If Me.BackBuffer IsNot Nothing Then
                Me.BackBuffer.Dispose()
            End If
            Me.BackBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub
#End Region
End Class

