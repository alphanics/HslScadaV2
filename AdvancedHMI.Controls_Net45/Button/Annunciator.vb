Imports System.Drawing
Imports System.Windows.Forms



Public Class Annunciator
    Inherits Control
#Region "الاحداث"
    Public Event ValueChanged As EventHandler
#End Region
#Region "متغيرات"

    Private LightImage As Bitmap

    Private OffImage As Bitmap

    Private OnImage As Bitmap

    Private TextRectangle As Rectangle

    Private TextBrush As SolidBrush

    Private sf As StringFormat

    Private m_Value As Boolean

    Private m_OutputType As OutputType

    Private _backBuffer As Bitmap
#End Region
#Region "خصائص"
    Public Property OutputType() As OutputType
        Get
            Return Me.m_OutputType
        End Get
        Set(ByVal value As OutputType)
            Me.m_OutputType = value
        End Set
    End Property

    Public Property Value() As Boolean
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Boolean)
            If Me.m_Value <> value Then
                If Not value Then
                    Me.LightImage = Me.OffImage
                Else
                    Me.LightImage = Me.OnImage
                End If
                Me.m_Value = value
                Me.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property
#End Region
#Region "مشيدات"
    Public Sub New()

        Me.m_OutputType = OutputType.MomentarySet
        Me.sf = New StringFormat() With {
         .Alignment = StringAlignment.Center,
         .LineAlignment = StringAlignment.Center
        }
        Me.TextRectangle = New Rectangle()
        Me.TextBrush = New SolidBrush(Color.Black)
    End Sub
#End Region
#Region "اعادة تعريف الاحداث"
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Me.Enabled Then
            Me.LightImage = Me.OnImage
            If Me.m_OutputType = OutputType.Toggle Then
                Me.Value = Not Me.Value
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
        If Not (Me._backBuffer Is Nothing Or Me.LightImage Is Nothing) Then
            Dim g As Graphics = Graphics.FromImage(Me._backBuffer)
            g.DrawImage(Me.LightImage, 0, 0)
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                g.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub
#End Region
#Region "طرق"
    Private Sub RefreshImage()
        If Not (Me.Width <= 0 Or Me.Height <= 0) Then
            Me.OffImage = New Bitmap(Me.Width, Me.Height)
            Me.OnImage = New Bitmap(Me.Width, Me.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.OffImage)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.OnImage)
            graphic.DrawImage(My.Resources.AnnunciatorOff, 0, 0, Me.OffImage.Width, Me.OffImage.Height)
            graphic1.DrawImage(My.Resources.AnnunciatorOn, 0, 0, Me.OnImage.Width, Me.OnImage.Height)
            If Not Me.m_Value Then
                Me.LightImage = Me.OffImage
            Else
                Me.LightImage = Me.OnImage
            End If
            graphic.Dispose()
            graphic1.Dispose()
            Me.TextRectangle.X = 0
            Me.TextRectangle.Width = Me.Width
            Me.TextRectangle.Y = 0
            Me.TextRectangle.Height = Me.Height
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub
#End Region
End Class
