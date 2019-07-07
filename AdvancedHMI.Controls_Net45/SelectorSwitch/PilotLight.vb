Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class PilotLight
    Inherits Control


    Private StaticImage As Bitmap

    Private LightImage As Bitmap

    Private LightOffImage As Bitmap

    Private LightOnImage As Bitmap

    Private ButtonDownImage As Bitmap

    Private TextRectangle As Rectangle

    Private ImageRatio As Decimal

    Private ButtonIsDown As Boolean

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private BlinkTimer As System.Timers.Timer

    Private LightState As Boolean

    Private m_Value As Boolean

    Private m_LightColor As LightColorOption

    Private m_LightColorOff As LightColorOption

    Private m_Blink As Boolean

    Private m_LegendPlate As LegendPlates

    Private m_OutputType As OutputType

    Private _backBuffer As Bitmap


    Private tmrError As System.Windows.Forms.Timer

    Private LegendPlateRatio As Double

    Private LastWidth As Integer

    Private LastHeight As Integer

    Public Property Blink() As Boolean
        Get
            Return Me.m_Blink
        End Get
        Set(ByVal value As Boolean)
            Me.m_Blink = value
            If Not value Then
                If Me.BlinkTimer IsNot Nothing Then
                    Me.BlinkTimer.Enabled = False
                End If
                If Not Me.m_Value Then
                    Me.LightImage = Me.LightOffImage
                Else
                    Me.LightImage = Me.LightOnImage
                End If
            Else
                If Me.BlinkTimer Is Nothing Then
                    Me.BlinkTimer = New Timers.Timer(600)
                    Dim pilotLight As PilotLight = Me
                    AddHandler BlinkTimer.Elapsed, AddressOf pilotLight.BlinkElapsed
                End If
                Me.BlinkTimer.Enabled = True
            End If
        End Set
    End Property

    Public Property LegendPlate() As LegendPlates
        Get
            Return Me.m_LegendPlate
        End Get
        Set(ByVal value As LegendPlates)
            Me.m_LegendPlate = value
            Me.OnResize(EventArgs.Empty)
            Me.RefreshImage()
        End Set
    End Property

    Public Property LightColor() As LightColorOption
        Get
            Return Me.m_LightColor
        End Get
        Set(ByVal value As LightColorOption)
            Me.m_LightColor = value
            Me.RefreshImage()
        End Set
    End Property

    Public Property LightColorOff() As LightColorOption
        Get
            Return Me.m_LightColorOff
        End Get
        Set(ByVal value As LightColorOption)
            Me.m_LightColorOff = value
            Me.RefreshImage()
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



    Public Property Value() As Boolean
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_Value Then
                If Not value Then
                    Me.LightImage = Me.LightOffImage
                Else
                    Me.LightImage = Me.LightOnImage
                End If
                Me.m_Value = value
                Me.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property



    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.sf = New StringFormat()
        Me.m_LightColor = LightColorOption.Green
        Me.m_LightColorOff = LightColorOption.White
        Me.m_LegendPlate = LegendPlates.Large
        Me.m_OutputType = OutputType.MomentarySet
        Me.tmrError = New System.Windows.Forms.Timer()
        Me.LegendPlateRatio = CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width)
        Me.sf = New StringFormat() With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
        }
        Me.TextBrush = New SolidBrush(Color.Black)
    End Sub


    Private Sub BlinkElapsed(ByVal sender As Object, ByVal e As EventArgs)
        If (If(Me.LightImage Is Me.LightOnImage OrElse Not Me.m_Value, False, True)) Then
            Me.LightImage = Me.LightOnImage
        Else
            Me.LightImage = Me.LightOffImage
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.ButtonIsDown = True
        If Me.Enabled Then
            Me.LightImage = Me.LightOnImage
            If Me.m_OutputType = OutputType.Toggle Then
                Me.Value = Not Me.Value
            End If
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        Me.ButtonIsDown = False
        If Me.Enabled Then
            If Me.OutputType <> OutputType.Toggle Then
                Me.LightImage = Me.LightOffImage
            End If
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImage Is Nothing Or Me._backBuffer Is Nothing Or Me.LightImage Is Nothing) Then
            Dim g As Graphics = Graphics.FromImage(Me._backBuffer)
            g.DrawImage(Me.StaticImage, 0, 0)
            If Me.m_LegendPlate <> LegendPlates.Large Then
                g.DrawImage(Me.LightImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.LightImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.59 - CDbl(Me.LightImage.Height) / 2))
            Else
                g.DrawImage(Me.LightImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.LightImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.68 - CDbl(Me.LightImage.Height) / 2))
            End If
            If (If(Me.Text Is Nothing OrElse String.Compare(Me.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                g.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
            If Me.ButtonIsDown Then
                If Me.m_LegendPlate <> LegendPlates.Large Then
                    g.DrawImage(Me.ButtonDownImage, Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(102)), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(170)), Me.ImageRatio)))
                Else
                    g.DrawImage(Me.ButtonDownImage, Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(102)), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(360)), Me.ImageRatio)))
                End If
            End If
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        If Me.m_LegendPlate <> LegendPlates.Large Then
            Me.LegendPlateRatio = CDbl(My.Resources.LegendPlateShort.Height) / CDbl(My.Resources.LegendPlateShort.Width)
        Else
            Me.LegendPlateRatio = CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width)
        End If
        MyBase.OnResize(e)
        If Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width Then
            If CDbl(Me.Height) / CDbl(Me.Width) <= Me.LegendPlateRatio Then
                Me.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * Me.LegendPlateRatio)))
            Else
                Me.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) / Me.LegendPlateRatio)))
            End If
        ElseIf CDbl(Me.Height) / CDbl(Me.Width) <= Me.LegendPlateRatio Then
            Me.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) / Me.LegendPlateRatio)))
        Else
            Me.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * Me.LegendPlateRatio)))
        End If
        Me.LastWidth = Me.Width
        Me.LastHeight = Me.Height
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub

    Private Sub RefreshImage()
        Dim gr_dest As Graphics
        Dim WidthRatio As Decimal
        Dim HeightRatio As Decimal
        If Me.m_LegendPlate <> LegendPlates.Large Then
            HeightRatio = New Decimal(CSng(Me.Width) / CSng(My.Resources.LegendPlateShort.Width))
            WidthRatio = New Decimal(CSng(Me.Height) / CSng(My.Resources.LegendPlateShort.Height))
        Else
            HeightRatio = New Decimal(CSng(Me.Width) / CSng(My.Resources.LegendPlate.Width))
            WidthRatio = New Decimal(CSng(Me.Height) / CSng(My.Resources.LegendPlate.Height))
        End If
        If Decimal.Compare(HeightRatio, WidthRatio) >= 0 Then
            Me.ImageRatio = WidthRatio
        Else
            Me.ImageRatio = HeightRatio
        End If
        If Decimal.Compare(Me.ImageRatio, Decimal.Zero) > 0 Then
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            If Me.m_LegendPlate <> LegendPlates.Large Then
                Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Height), Me.ImageRatio)))
                Me.LegendPlateRatio = CDbl(My.Resources.LegendPlateShort.Height) / CDbl(My.Resources.LegendPlateShort.Width)
                gr_dest = Graphics.FromImage(Me.StaticImage)
                gr_dest.DrawImage(My.Resources.LegendPlateShort, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Height), Me.ImageRatio)))
            Else
                Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Height), Me.ImageRatio)))
                Me.LegendPlateRatio = CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width)
                gr_dest = Graphics.FromImage(Me.StaticImage)
                gr_dest.DrawImage(My.Resources.LegendPlate, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Height), Me.ImageRatio)))
            End If
            Me.LightOffImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenPilotOff.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenPilotOff.Height), Me.ImageRatio)))
            Me.LightOnImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenPilotOff.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenPilotOff.Height), Me.ImageRatio)))
            gr_dest = Graphics.FromImage(Me.LightOffImage)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.LightOnImage)
            If Me.m_LightColorOff = LightColorOption.Green Then
                gr_dest.DrawImage(My.Resources.GreenPilotOff, 0, 0, Me.LightOffImage.Width, Me.LightOffImage.Height)
            ElseIf Me.m_LightColorOff = LightColorOption.Red Then
                gr_dest.DrawImage(My.Resources.RedPilotOff, 0, 0, Me.LightOffImage.Width, Me.LightOffImage.Height)
            ElseIf Me.m_LightColorOff = LightColorOption.Blue Then
                gr_dest.DrawImage(My.Resources.BluePilotOff, 0, 0, Me.LightOffImage.Width, Me.LightOffImage.Height)
            ElseIf Me.m_LightColorOff <> LightColorOption.White Then
                gr_dest.DrawImage(My.Resources.YellowPilotOff, 0, 0, Me.LightOffImage.Width, Me.LightOffImage.Height)
            Else
                gr_dest.DrawImage(My.Resources.WhitePilotOff, 0, 0, Me.LightOffImage.Width, Me.LightOffImage.Height)
            End If
            If Me.m_LightColor = LightColorOption.Green Then
                graphic1.DrawImage(My.Resources.GreenPilotOn, 0, 0, Me.LightOnImage.Width, Me.LightOnImage.Height)
            ElseIf Me.m_LightColor = LightColorOption.Red Then
                graphic1.DrawImage(My.Resources.RedPilotOn, 0, 0, Me.LightOnImage.Width, Me.LightOnImage.Height)
            ElseIf Me.m_LightColor = LightColorOption.Blue Then
                graphic1.DrawImage(My.Resources.BluePilotOn, 0, 0, Me.LightOnImage.Width, Me.LightOnImage.Height)
            ElseIf Me.m_LightColor <> LightColorOption.White Then
                graphic1.DrawImage(My.Resources.YellowPilotOn, 0, 0, Me.LightOnImage.Width, Me.LightOnImage.Height)
            Else
                graphic1.DrawImage(My.Resources.WhitePilotOn, 0, 0, Me.LightOnImage.Width, Me.LightOnImage.Height)
            End If
            Me.ButtonDownImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PilotLightDown.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PilotLightDown.Height), Me.ImageRatio)))
            gr_dest = Graphics.FromImage(Me.ButtonDownImage)
            gr_dest.DrawImage(My.Resources.PilotLightDown, 0, 0, Me.ButtonDownImage.Width, Me.ButtonDownImage.Height)
            If Not Me.m_Value Then
                Me.LightImage = Me.LightOffImage
            Else
                Me.LightImage = Me.LightOnImage
            End If
            gr_dest.Dispose()
            graphic1.Dispose()
            Me.TextRectangle.X = 0
            Me.TextRectangle.Width = Me.Width
            Me.TextRectangle.Y = 0
            If Me.m_LegendPlate <> LegendPlates.Large Then
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.18)))
            Else
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.4)))
            End If
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub

    Public Event ValueChanged As EventHandler

    Public Enum LegendPlates
        Large
        Small
    End Enum

    Public Enum LightColorOption
        Red
        Green
        Blue
        Yellow
        White
    End Enum
End Class

