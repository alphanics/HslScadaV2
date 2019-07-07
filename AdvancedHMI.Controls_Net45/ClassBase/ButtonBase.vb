Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public MustInherit Class ButtonBase
    Inherits Control

    Protected BackImage As Image

    Protected StaticImage As Image

    Protected OnImage As Image

    Protected OffImage As Image

    Protected ImageRatio As Double

    Protected TextRectangle As Rectangle

    Protected sf As StringFormat

    Protected TextBrush As SolidBrush

    Protected BaseImage As Image

    Protected BackBuffer As Bitmap

    Protected m_Value As Boolean

    Protected x As Single

    Protected y As Single

    Protected LastWidth As Integer

    Protected LastHeight As Integer

    Public Overridable Property Value() As Boolean
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_Value Then
                Me.m_Value = value
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Sub New()
        Me.sf = New StringFormat()
    End Sub

    Private Sub _Resize()
        If Me.Height <> Me.LastHeight Or Me.Width <> Me.LastWidth Then
            Me.AdjustSize()
            Me.LastWidth = Me.Width
            Me.LastHeight = Me.Height
            If Me.Width > 0 And Me.Height > 0 Then
                Me.CreateStaticImage()
            End If
        End If
    End Sub

    Protected Overridable Sub AdjustSize()
        If Me.BaseImage IsNot Nothing Then
            Me.ImageRatio = CDbl(Me.BaseImage.Height) / CDbl(Me.BaseImage.Width)
            If Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width Then
                If CDbl(Me.Height) / CDbl(Me.Width) <= Me.ImageRatio Then
                    Me.Height = Convert.ToInt32(CDbl(Me.Width) * Me.ImageRatio)
                Else
                    Me.Width = Convert.ToInt32(CDbl(Me.Height) / Me.ImageRatio)
                End If
            ElseIf CDbl(Me.Height) / CDbl(Me.Width) <= Me.ImageRatio Then
                Me.Width = Convert.ToInt32(CDbl(Me.Height) / Me.ImageRatio)
            Else
                Me.Height = Convert.ToInt32(CDbl(Me.Width) * Me.ImageRatio)
            End If
        End If
    End Sub

    Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)
        If Me.Width > 0 And Me.Height > 0 Then
            Me.CreateStaticImage()
        End If
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        If Me.TextBrush IsNot Nothing Then
            Me.TextBrush.Color = MyBase.ForeColor
        Else
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        End If
        If Me.Width > 0 And Me.Height > 0 Then
            Me.CreateStaticImage()
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Me.BackBuffer IsNot Nothing Then
            Me.BackBuffer.Dispose()
            Me.BackBuffer = Nothing
        End If
        Me._Resize()
        MyBase.OnSizeChanged(e)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        If Me.Width > 0 And Me.Height > 0 Then
            Me.CreateStaticImage()
        End If
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
        Me.Invalidate()
    End Sub

    Protected MustOverride Sub CreateStaticImage()

    Public Event ValueChanged As EventHandler
End Class

