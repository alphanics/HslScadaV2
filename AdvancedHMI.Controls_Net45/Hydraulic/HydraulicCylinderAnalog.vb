Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class HydraulicCylinderAnalog
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

    Private m_Value As Double

    Private m_MinValue As Double

    Private m_MaxValue As Double

    Protected m_ValueScaleFactor As Double

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


    Public Property MaxValue() As Double
        Get
            Return Me.m_MaxValue
        End Get
        Set(ByVal value As Double)
            Me.m_MaxValue = value
        End Set
    End Property

    Public Property MinValue() As Double
        Get
            Return Me.m_MinValue
        End Get
        Set(ByVal value As Double)
            Me.m_MinValue = value
        End Set
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

    Public Property Value() As Double
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Double)
            If value <> Me.m_Value Then
                Me.m_Value = value
                Me.Invalidate()
                Dim empty As EventArgs = EventArgs.Empty
                Me.OnValueChanged(empty)
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Property ValueScaleFactor() As Double
        Get
            Return Me.m_ValueScaleFactor
        End Get
        Set(ByVal value As Double)
            If value <> Me.m_ValueScaleFactor Then
                Me.m_ValueScaleFactor = value
            End If
        End Set
    End Property

#End Region
#Region "المشيدات والمهدمات"
    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.sf = New StringFormat()
        Me.m_MaxValue = 100
        Me.m_ValueScaleFactor = 1
        Me.m_Rotation = RotateFlipType.RotateNoneFlipNone
        If (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            Me.ForeColor = Color.LightGray
        End If
    End Sub




    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            Me._backBuffer.Dispose()
            Me.OffImage.Dispose()
            Me.OnImage.Dispose()
            Me.sf.Dispose()
            Me.TextBrush.Dispose()
            Me.FormBitmap.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
#End Region
#Region "الطرق"
    Private Sub GetImageBehindRod()
        If Me.Parent IsNot Nothing Then
            Dim visible_Renamed As Boolean = Me.Visible
            Me.Visible = False
            Me.Refresh()
            Me.FormBitmap = New Bitmap(Me.Width, Me.Height)
            Dim width_Renamed As Integer = Me.Parent.Width
            Dim clientSize_Renamed As Size = Me.Parent.ClientSize
            Dim num As Integer = CInt(Math.Truncate(Math.Round(CDbl(width_Renamed - clientSize_Renamed.Width) / 2)))
            Dim height_Renamed As Integer = Me.Parent.Height
            clientSize_Renamed = Me.Parent.ClientSize
            Dim height1 As Integer = (height_Renamed - clientSize_Renamed.Height) - num
            Dim bitmap As New Bitmap(Me.Parent.Width, Me.Parent.Height)
            Try
                Dim parent_Renamed As Control = Me.Parent
                Dim rectangle As New Rectangle(0, 0, Me.Parent.Width, Me.Parent.Height)
                parent_Renamed.DrawToBitmap(bitmap, rectangle)
            Catch

            End Try
            Dim width1 As Integer = Me.Width - 1
            For i As Integer = 0 To width1
                Dim num1 As Integer = Me.Height - 1
                For j As Integer = 0 To num1
                    Dim formBitmap_Renamed As Bitmap = Me.FormBitmap
                    Dim x As Integer = (i + Me.Location.X) + num
                    Dim location_Renamed As Point = Me.Location
                    formBitmap_Renamed.SetPixel(i, j, bitmap.GetPixel(x, (j + location_Renamed.Y) + height1))
                Next j
            Next i
            Me.Visible = visible_Renamed
        End If
    End Sub
    Private Sub RefreshImage()
        Dim width_Renamed As Single = CSng(Me.Width) / CSng(My.Resources.HydraulicCylinder.Width + 400)
        Dim height_Renamed As Single = CSng(Me.Height) / CSng(My.Resources.HydraulicCylinder.Height)
        If Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone Then
            width_Renamed = CSng(Me.Width) / CSng(My.Resources.HydraulicCylinder.Height)
            height_Renamed = CSng(Me.Height) / CSng(My.Resources.HydraulicCylinder.Width + 400)
        End If
        If width_Renamed >= height_Renamed Then
            Me.ImageRatio = height_Renamed
        Else
            Me.ImageRatio = width_Renamed
        End If
        If Me.ImageRatio > 0.0F Then
            If Me.OnImage IsNot Nothing Then
                Me.OnImage.Dispose()
            End If
            Me.OnImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width + 400) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio))
            Dim graphic As Graphics = Graphics.FromImage(Me.OnImage)
            graphic.DrawImage(My.Resources.HydraulicCylinder, 400.0F * Me.ImageRatio, 0.0F, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio)))
            Me.OnImage.RotateFlip(Me.m_Rotation)
            If Me.RodImage IsNot Nothing Then
                Me.RodImage.Dispose()
            End If
            Me.RodImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width + 400) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio))
            graphic = Graphics.FromImage(Me.RodImage)
            graphic.DrawImage(My.Resources.HydraulicCylinderRod, 0.0F, 91.0F * Me.ImageRatio, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Height) * Me.ImageRatio)))
            Me.RodImage.RotateFlip(Me.m_Rotation)
            If Me.OffImage IsNot Nothing Then
                Me.OffImage.Dispose()
            End If
            Me.OffImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width + 400) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio))
            graphic = Graphics.FromImage(Me.OffImage)
            graphic.DrawImage(My.Resources.HydraulicCylinderRod, 285.0F * Me.ImageRatio, 91.0F * Me.ImageRatio, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinderRod.Height) * Me.ImageRatio)))
            graphic.DrawImage(My.Resources.HydraulicCylinder, 400.0F * Me.ImageRatio, 0.0F, CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Width) * Me.ImageRatio)), CSng(Convert.ToInt32(CSng(My.Resources.HydraulicCylinder.Height) * Me.ImageRatio)))
            Me.OffImage.RotateFlip(Me.m_Rotation)
            graphic.Dispose()
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
        Dim num As Integer
        Dim rectangle As New Rectangle()
        If Not (Me.OffImage Is Nothing Or Me.OnImage Is Nothing Or Me._backBuffer Is Nothing Or Me.TextBrush Is Nothing Or (Me.TextRectangle = rectangle) Or Me.sf Is Nothing) Then
            If Me.FormBitmap Is Nothing Then
                Me.GetImageBehindRod()
            End If
            Using graphic As Graphics = Graphics.FromImage(Me._backBuffer)
                graphic.DrawImage(Me.FormBitmap, 0, 0)
                Dim mValue As Double = Me.m_Value
                Dim mMaxValue As Double = Me.m_MaxValue - Me.m_MinValue
                Dim num1 As Double = Math.Max(Math.Min(Me.m_Value - Me.m_MinValue, Me.m_MaxValue), Me.m_MinValue) / mMaxValue
                'INSTANT VB NOTE: The variable imageRatio was renamed since Visual Basic does not handle local variables named the same as class members well:
                Dim imageRatio_Renamed As Double = CDbl(Me.ImageRatio * 280.0F - Me.ImageRatio * 10.0F)
                If Me.m_Rotation = RotateFlipType.RotateNoneFlipNone Or Me.m_Rotation = RotateFlipType.Rotate180FlipX Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num = checked((int)Math.Round((1 - num1) * imageRatio + (double)this.ImageRatio));
                    num = CInt(Math.Truncate(Math.Round((1 - num1) * imageRatio_Renamed + CDbl(Me.ImageRatio))))
                    graphic.DrawImage(Me.RodImage, num, 0)
                ElseIf Me.m_Rotation = RotateFlipType.Rotate270FlipX Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num = checked((int)Math.Round((1 - num1) * imageRatio + (double)this.ImageRatio));
                    num = CInt(Math.Truncate(Math.Round((1 - num1) * imageRatio_Renamed + CDbl(Me.ImageRatio))))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num = checked(num * -1);
                    num = num * -1
                    graphic.DrawImage(Me.RodImage, 0, num)
                ElseIf Me.m_Rotation = RotateFlipType.Rotate270FlipNone Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num = checked((int)Math.Round((1 - num1) * imageRatio + (double)this.ImageRatio));
                    num = CInt(Math.Truncate(Math.Round((1 - num1) * imageRatio_Renamed + CDbl(Me.ImageRatio))))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num = checked(num * -1);
                    num = num * -1
                    graphic.DrawImage(Me.RodImage, 0, num)
                ElseIf Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num = checked((int)Math.Round((1 - num1) * imageRatio + (double)this.ImageRatio));
                    num = CInt(Math.Truncate(Math.Round((1 - num1) * imageRatio_Renamed + CDbl(Me.ImageRatio))))
                    graphic.DrawImage(Me.RodImage, 0, num)
                ElseIf Me.m_Rotation = RotateFlipType.Rotate180FlipNone Or Me.m_Rotation = RotateFlipType.RotateNoneFlipX Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num = checked((int)Math.Round((1 - num1) * imageRatio + (double)this.ImageRatio));
                    num = CInt(Math.Truncate(Math.Round((1 - num1) * imageRatio_Renamed + CDbl(Me.ImageRatio))))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: num = checked(num * -1);
                    num = num * -1
                    graphic.DrawImage(Me.RodImage, num, 0)
                End If
                graphic.DrawImage(Me.OnImage, 0, 0)
                If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                    If Me.TextBrush.Color <> MyBase.ForeColor Then
                        Me.TextBrush.Color = MyBase.ForeColor
                    End If
                    graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
                End If
                e.Graphics.DrawImage(Me._backBuffer, 0, 0)
                Me.LastValue = Me.m_Value <> 0
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

