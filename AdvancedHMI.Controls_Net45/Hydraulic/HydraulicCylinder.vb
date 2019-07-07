Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class HydraulicCylinder
    Inherits Control
    Public Event ValueChanged As EventHandler
#Region "متغيرات"

    Private OffImage As Bitmap

    Private OnImage As Bitmap

    Private RodImage As Bitmap

    Private ImageRatio As Single

    Private TextRectangle As Rectangle

    Private TextBrush As SolidBrush

    Private sf As StringFormat

    Private m_Value As Boolean

    Private m_Rotation As RotateFlipType

    Private BackNeedsRefreshed As Boolean

    Private _backBuffer As Bitmap

    Private LastValue As Boolean

    Private FormBitmap As Bitmap
#End Region
#Region "خصائص"
    '* This is necessary to make the background draw correctly
    '*  http://www.bobpowell.net/transcontrols.htm
    '*part of the transparent background code
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 32
            Return cp
        End Get
    End Property

    Public Property Rotation() As RotateFlipType
        Get
            Return Me.m_Rotation
        End Get
        Set(ByVal value As RotateFlipType)
            Me.m_Rotation = value
            Me.BackNeedsRefreshed = True
            Me.RefreshImage()
        End Set
    End Property

    Public Property Value() As Boolean
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_Value Then
                Me.m_Value = value
                Me.Invalidate()
                Dim empty As EventArgs = EventArgs.Empty
                Me.OnValueChanged(empty)
            End If
        End Set
    End Property

#End Region
#Region "المشيدات والمهدمات"
    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.sf = New StringFormat()
        Me.m_Rotation = RotateFlipType.RotateNoneFlipNone
        If (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            Me.ForeColor = Color.LightGray
        End If
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            If Me.OffImage IsNot Nothing Then
                Me.OffImage.Dispose()
            End If
            If Me.OnImage IsNot Nothing Then
                Me.OnImage.Dispose()
            End If
            If Me.sf IsNot Nothing Then
                Me.sf.Dispose()
            End If
            If Me.TextBrush IsNot Nothing Then
                Me.TextBrush.Dispose()
            End If
            If Me.FormBitmap IsNot Nothing Then
                Me.FormBitmap.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
#End Region
#Region "الطرق"
    Private Sub GetImageBehindRod()
        If Me.Parent IsNot Nothing And Me.Width > 0 And Me.Height > 0 Then
            Dim visibleHold As Boolean = Me.Visible
            Me.Visible = False
            Me.Refresh()
            Me.FormBitmap = New Bitmap(Me.Width, Me.Height)
            Dim m_width As Integer = Me.Parent.Width
            Dim m_clientSize As Size = Me.Parent.ClientSize
            Dim borderwidth As Integer = Convert.ToInt32(CDbl(m_width - m_clientSize.Width) / 2)
            Dim m_height As Integer = Me.Parent.Height
            m_clientSize = Me.Parent.ClientSize
            Dim height1 As Integer = (m_height - m_clientSize.Height) - borderwidth
            Dim bitmap As New Bitmap(Me.Parent.Width, Me.Parent.Height)
            Try
                Dim m_parent As Control = Me.Parent
                Dim rectangle As New Rectangle(0, 0, Me.Parent.Width, Me.Parent.Height)
                m_parent.DrawToBitmap(bitmap, rectangle)
            Catch

            End Try
            Dim width1 As Integer = Me.Width - 1
            For i As Integer = 0 To width1
                Dim m_Height1 As Integer = Me.Height - 1
                For j As Integer = 0 To m_Height1
                    Dim m_formBitmap As Bitmap = Me.FormBitmap
                    Dim x As Integer = (i + Me.Location.X) + borderwidth
                    Dim location_Renamed As Point = Me.Location
                    m_formBitmap.SetPixel(i, j, bitmap.GetPixel(x, (j + location_Renamed.Y) + height1))
                Next j
            Next i
            Me.Visible = visibleHold
        End If
    End Sub

    Private Sub GetImageBehindRodX()
        Dim num As Integer = 0
        Dim visible_Renamed As Boolean = Me.Visible
        If Me.Parent IsNot Nothing Then
            Me.Visible = False
            Me.Refresh()
            If Me.FormBitmap IsNot Nothing Then
                Me.FormBitmap.Dispose()
            End If
            Me.FormBitmap = New Bitmap(400, Me.RodImage.Height)
            Dim width_Renamed As Integer = Me.Parent.ClientSize.Width
            Dim clientSize_Renamed As Size = Me.Parent.ClientSize
            Dim bitmap As New Bitmap(width_Renamed, clientSize_Renamed.Height)
            Dim parent_Renamed As Control = Me.Parent
            Dim rectangle As New Rectangle(0, 0, Me.Parent.Width, Me.Parent.Height)
            parent_Renamed.DrawToBitmap(bitmap, rectangle)
            Dim width1 As Integer = Me.Parent.Width
            clientSize_Renamed = Me.Parent.ClientSize
            Dim num1 As Integer = Convert.ToInt32(CDbl(width1 - clientSize_Renamed.Width) / 2)
            Dim height_Renamed As Integer = Me.Parent.Height
            clientSize_Renamed = Me.Parent.ClientSize
            Dim height1 As Integer = (height_Renamed - clientSize_Renamed.Height) - num1
            Dim num2 As Integer = (Convert.ToInt32(CDbl(Me.OnImage.Height) / 2) - Convert.ToInt32(CDbl(Me.RodImage.Height) / 2)) - 1
            Dim num3 As Integer = 399
            Dim width2 As Integer = Me.FormBitmap.Width - 1
            Dim num4 As Integer = num3 - num1
            Dim location_Renamed As Point = Me.Location
            num3 = Math.Min(width2, (num4 - location_Renamed.X) - num)
            Dim height2 As Integer = Me.RodImage.Height - 1
            Dim height3 As Integer = Me.FormBitmap.Height - 1
            location_Renamed = Me.Location
            height2 = Math.Min(height3, (height2 + location_Renamed.Y + height1) + num2)
            Dim num5 As Integer = num3
            For i As Integer = 0 To num5
                Dim num6 As Integer = height2
                For j As Integer = 0 To num6
                    Dim formBitmap_Renamed As Bitmap = Me.FormBitmap
                    Dim num7 As Integer = i + num1
                    location_Renamed = Me.Location
                    Dim x As Integer = (num7 + location_Renamed.X) + num
                    Dim point As Point = Me.Location
                    formBitmap_Renamed.SetPixel(i, j, bitmap.GetPixel(x, (j + point.Y + height1) + num2))
                Next j
            Next i
            Me.Visible = visible_Renamed
        End If
    End Sub
    Private Sub RefreshImage()
        Dim WidthRatio As Single = CSng(Me.Width) / CSng(My.Resources.HydraulicCylinder.Width + 400)
        Dim HeightRatio As Single = CSng(Me.Height) / CSng(My.Resources.HydraulicCylinder.Height)
        If Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone Then
            WidthRatio = CSng(Me.Width) / CSng(My.Resources.HydraulicCylinder.Height)
            HeightRatio = CSng(Me.Height) / CSng(My.Resources.HydraulicCylinder.Width + 400)
        End If
        If WidthRatio >= HeightRatio Then
            Me.ImageRatio = HeightRatio
        Else
            Me.ImageRatio = WidthRatio
        End If
        If Me.ImageRatio > 0.0F Then
            If Me.OnImage IsNot Nothing Then
                Me.OnImage.Dispose()
            End If
            Me.OnImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width + 400) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio))
            Dim gr_dest As Graphics = Graphics.FromImage(Me.OnImage)
            gr_dest.DrawImage(My.Resources.HydraulicCylinderRod, 0.0F, 91.0F * Me.ImageRatio, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Height) * Me.ImageRatio)))
            gr_dest.DrawImage(My.Resources.HydraulicCylinder, 400.0F * Me.ImageRatio, 0.0F, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio)))
            Me.OnImage.RotateFlip(Me.m_Rotation)
            If Me.RodImage IsNot Nothing Then
                Me.RodImage.Dispose()
            End If
            Me.RodImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width + 400) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio))
            gr_dest = Graphics.FromImage(Me.RodImage)
            gr_dest.DrawImage(My.Resources.HydraulicCylinderRod, 0.0F, 91.0F * Me.ImageRatio, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Height) * Me.ImageRatio)))
            Me.RodImage.RotateFlip(Me.m_Rotation)
            If Me.OffImage IsNot Nothing Then
                Me.OffImage.Dispose()
            End If
            Me.OffImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width + 400) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio))
            gr_dest = Graphics.FromImage(Me.OffImage)
            gr_dest.DrawImage(My.Resources.HydraulicCylinderRod, 285.0F * Me.ImageRatio, 91.0F * Me.ImageRatio, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Height) * Me.ImageRatio)))
            gr_dest.DrawImage(My.Resources.HydraulicCylinder, 400.0F * Me.ImageRatio, 0.0F, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio)))
            Me.OffImage.RotateFlip(Me.m_Rotation)
            gr_dest.Dispose()
            If Me.m_Rotation = RotateFlipType.Rotate180FlipNone Or Me.m_Rotation = RotateFlipType.RotateNoneFlipX Then
                Me.TextRectangle.X = 0
                Me.TextRectangle.Y = 1
                Me.TextRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.OnImage.Width) * 0.55)))
                Me.TextRectangle.Height = Me.OnImage.Height - 2
            ElseIf Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Then
                Me.TextRectangle.Y = 0
                Me.TextRectangle.X = 1
                Me.TextRectangle.Width = Me.OnImage.Width - 2
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.OnImage.Height) * 0.55)))
            ElseIf Not (Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipX) Then
                Me.TextRectangle.X = CInt(Math.Truncate(Math.Round(CDbl(Me.OnImage.Width) * 0.45)))
                Me.TextRectangle.Y = 1
                Me.TextRectangle.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.OnImage.Width) * 0.55)))
                Me.TextRectangle.Height = Me.OnImage.Height - 2
            Else
                Me.TextRectangle.Y = CInt(Math.Truncate(Math.Round(CDbl(Me.OnImage.Height) * 0.45)))
                Me.TextRectangle.X = 1
                Me.TextRectangle.Width = Me.OnImage.Width - 2
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.OnImage.Height) * 0.55)))
            End If
            Me.sf.Alignment = StringAlignment.Center
            Me.sf.LineAlignment = StringAlignment.Center
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub
#End Region
#Region "اعادة تعريف الاحداث"
    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        If Me.TextBrush IsNot Nothing Then
            Me.TextBrush.Color = MyBase.ForeColor
        Else
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnLocationChanged(ByVal e As EventArgs)
        MyBase.OnLocationChanged(e)
        Me.GetImageBehindRod()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim rectangle As New Rectangle()
        If Not (Me.OffImage Is Nothing Or Me.OnImage Is Nothing Or Me._backBuffer Is Nothing Or Me.TextBrush Is Nothing Or (Me.TextRectangle = rectangle) Or Me.sf Is Nothing) Then
            If Me.FormBitmap Is Nothing Then
                Me.GetImageBehindRod()
            End If
            Using g As Graphics = Graphics.FromImage(Me._backBuffer)
                If Not Me.m_Value Then
                    g.DrawImage(Me.FormBitmap, 0, 0)
                    g.DrawImage(Me.OffImage, 0, 0)
                Else
                    g.DrawImage(Me.FormBitmap, 0, 0)
                    g.DrawImage(Me.OnImage, 0, 0)
                End If
                If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                    If Me.TextBrush.Color <> MyBase.ForeColor Then
                        Me.TextBrush.Color = MyBase.ForeColor
                    End If
                    g.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
                End If
                e.Graphics.DrawImage(Me._backBuffer, 0, 0)
                Me.LastValue = Me.m_Value
            End Using
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        If Me.BackNeedsRefreshed Then
            MyBase.OnPaintBackground(e)
            Me.BackNeedsRefreshed = False
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.GetImageBehindRod()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub
#End Region
#Region "اطلاق الحدث"
    Protected Overridable Sub OnValueChanged(ByRef e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

#End Region


End Class

