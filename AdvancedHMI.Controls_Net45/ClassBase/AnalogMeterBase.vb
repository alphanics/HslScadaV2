Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public MustInherit Class AnalogMeterBase
    Inherits Control

    Protected StaticImage As Bitmap

    Protected NeedleImage As Bitmap

    Protected ImageRatio As Double

    Protected TextRectangle As Rectangle

    Protected sf As StringFormat

    Protected TextBrush As SolidBrush

    Protected BackBuffer As Bitmap

    Protected m_BaseImage As Bitmap

    Protected m_Value As Double

    Protected m_Maximum As Double

    Protected m_Minimum As Double

    Protected m_ValueScaleFactor As Double

    Protected x As Single

    Protected y As Single

    Private LastWidth As Integer

    Private LastHeight As Integer

    Protected Property BaseImage() As Bitmap
        Get
            Return Me.m_BaseImage
        End Get
        Set(ByVal value As Bitmap)
            Me.m_BaseImage = value
            Me.ImageRatio = CDbl(Me.m_BaseImage.Height) / CDbl(Me.m_BaseImage.Width)
        End Set
    End Property

    Public Property Maximum() As Double
        Get
            Return Me.m_Maximum
        End Get
        Set(ByVal value As Double)
            If Me.m_Maximum <> value Then
                Me.m_Maximum = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    Public Property Minimum() As Double
        Get
            Return Me.m_Minimum
        End Get
        Set(ByVal value As Double)
            If Me.m_Minimum <> value Then
                Me.m_Minimum = value
                Me.CreateStaticImage()
            End If
        End Set
    End Property

    <Category("Numeric Display")>
    Public Overridable Property Value() As Double
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Double)
            If value <> Me.m_Value Then
                Me.m_Value = value
                Me.OnValueChanged(EventArgs.Empty)
                Me.Invalidate()
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
                If Me.StaticImage IsNot Nothing Then
                    Me.Invalidate()
                End If
            End If
        End Set
    End Property

    Public Sub New()
        Me.m_Maximum = 100
        Me.m_ValueScaleFactor = 1
        If (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            Me.ForeColor = Color.LightGray
        End If
        Me.sf = New StringFormat() With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
        }
        Me.AdjustSize()
    End Sub

    Private Sub _Resize()
        If Me.Height <> Me.LastHeight Or Me.Width <> Me.LastWidth Then
            Me.LastWidth = Me.Width
            Me.LastHeight = Me.Height
            Me.CreateStaticImage()
        End If
    End Sub

    Private Sub AdjustSize()
        If Me.BaseImage IsNot Nothing Then
            Me.ImageRatio = CDbl(Me.m_BaseImage.Height) / CDbl(Me.m_BaseImage.Width)
            If Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width Then
                If CDbl(Me.Height) / CDbl(Me.Width) <= Me.ImageRatio Then
                    Me.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * Me.ImageRatio)))
                Else
                    Me.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) / Me.ImageRatio)))
                End If
            ElseIf CDbl(Me.Height) / CDbl(Me.Width) <= Me.ImageRatio Then
                Me.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) / Me.ImageRatio)))
            Else
                Me.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * Me.ImageRatio)))
            End If
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If Me.StaticImage IsNot Nothing Then
                    Me.StaticImage.Dispose()
                End If
                If Me.NeedleImage IsNot Nothing Then
                    Me.NeedleImage.Dispose()
                End If
                If Me.TextBrush IsNot Nothing Then
                    Me.TextBrush.Dispose()
                End If
                If Me.sf IsNot Nothing Then
                    Me.sf.Dispose()
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
        Me.CreateStaticImage()
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
        Me.CreateStaticImage()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)

        RaiseEvent ValueChanged(Me, e)

    End Sub

    Protected MustOverride Sub CreateStaticImage()

    Public Event ValueChanged As EventHandler
End Class

