Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class PilotLight3Color
    Inherits Control


    Private StaticImage As Bitmap

    Private LightColor1Image As Bitmap

    Private LightColor2Image As Bitmap

    Private LightColor3Image As Bitmap

    Private ActiveLightImage As Bitmap

    Private ButtonDownImage As Bitmap

    Private TextRectangle As Rectangle

    Private ImageRatio As Decimal

    Private ButtonIsDown As Boolean

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private m_SelectColor2 As Boolean

    Private m_SelectColor3 As Boolean

    Private m_LightColor1 As PilotLight3Color.LightColors

    Private m_LightColor2 As PilotLight3Color.LightColors

    Private m_LightColor3 As PilotLight3Color.LightColors

    Private m_LegendPlate As PilotLight3Color.LegendPlates

    Private m_OutputType As OutputType

    Private _backBuffer As Bitmap


    Private tmrError As Timer

    Private LegendPlateRatio As Double

    Private LastWidth As Integer

    Private LastHeight As Integer

    Public Property LegendPlate() As PilotLight3Color.LegendPlates
        Get
            Return Me.m_LegendPlate
        End Get
        Set(ByVal value As PilotLight3Color.LegendPlates)
            Me.m_LegendPlate = value
            Me.OnResize(EventArgs.Empty)
            Me.RefreshImage()
        End Set
    End Property

    Public Property LightColor1() As PilotLight3Color.LightColors
        Get
            Return Me.m_LightColor1
        End Get
        Set(ByVal value As PilotLight3Color.LightColors)
            Me.m_LightColor1 = value
            Me.RefreshImage()
        End Set
    End Property

    Public Property LightColor3() As PilotLight3Color.LightColors
        Get
            Return Me.m_LightColor3
        End Get
        Set(ByVal value As PilotLight3Color.LightColors)
            Me.m_LightColor3 = value
            Me.RefreshImage()
        End Set
    End Property

    Public Property LightColorOff() As PilotLight3Color.LightColors
        Get
            Return Me.m_LightColor2
        End Get
        Set(ByVal value As PilotLight3Color.LightColors)
            Me.m_LightColor2 = value
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

    <Category("Appearance")>
    Public Property SelectColor2() As Boolean
        Get
            Return Me.m_SelectColor2
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_SelectColor2 Then
                Me.m_SelectColor2 = value
                Me.Invalidate()
                Me.OnValueSelectColor1Changed(EventArgs.Empty)
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property SelectColor3() As Boolean
        Get
            Return Me.m_SelectColor3
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_SelectColor3 Then
                Me.m_SelectColor3 = value
                Me.Invalidate()
            End If
        End Set
    End Property




    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.sf = New StringFormat()
        Me.m_LightColor1 = PilotLight3Color.LightColors.White
        Me.m_LightColor2 = PilotLight3Color.LightColors.Green
        Me.m_LightColor3 = PilotLight3Color.LightColors.Red
        Me.m_LegendPlate = PilotLight3Color.LegendPlates.Large
        Me.m_OutputType = OutputType.MomentarySet
        Me.tmrError = New Timer()
        Me.LegendPlateRatio = CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width)
        Me.sf = New StringFormat() With {
         .Alignment = StringAlignment.Center,
         .LineAlignment = StringAlignment.Center
        }
        Me.TextBrush = New SolidBrush(Color.Black)
    End Sub


    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.ButtonIsDown = True
        If Me.Enabled Then
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        Me.ButtonIsDown = False
        If Me.Enabled Then
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImage Is Nothing Or Me._backBuffer Is Nothing Or Me.ActiveLightImage Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.StaticImage, 0, 0)
            Me.ActiveLightImage = Me.LightColor1Image
            If Me.m_SelectColor3 Then
                Me.ActiveLightImage = Me.LightColor3Image
            ElseIf Me.m_SelectColor2 Then
                Me.ActiveLightImage = Me.LightColor2Image
            End If
            If Me.m_LegendPlate <> PilotLight3Color.LegendPlates.Large Then
                graphic.DrawImage(Me.ActiveLightImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.ActiveLightImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.59 - CDbl(Me.ActiveLightImage.Height) / 2))
            Else
                graphic.DrawImage(Me.ActiveLightImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.ActiveLightImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.68 - CDbl(Me.ActiveLightImage.Height) / 2))
            End If
            If (If(Me.Text Is Nothing OrElse String.Compare(Me.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
            If Me.ButtonIsDown Then
                If Me.m_LegendPlate <> PilotLight3Color.LegendPlates.Large Then
                    graphic.DrawImage(Me.ButtonDownImage, Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(102)), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(170)), Me.ImageRatio)))
                Else
                    graphic.DrawImage(Me.ButtonDownImage, Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(102)), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(360)), Me.ImageRatio)))
                End If
            End If
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        If Me.m_LegendPlate <> PilotLight3Color.LegendPlates.Large Then
            Me.LegendPlateRatio = CDbl(My.Resources.LegendPlateShort.Height) / CDbl(My.Resources.LegendPlateShort.Width)
        Else
            Me.LegendPlateRatio = CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width)
        End If
        MyBase.OnResize(e)
        If Me.LastHeight < Me.Height Or Me.LastWidth < Me.Width Then
            If CDbl(Me.Height) / CDbl(Me.Width) <= Me.LegendPlateRatio Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.Height = checked((int)Math.Round((double)this.Width * this.LegendPlateRatio));
                Me.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Width) * Me.LegendPlateRatio)))
            Else
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.Width = checked((int)Math.Round((double)this.Height / this.LegendPlateRatio));
                Me.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) / Me.LegendPlateRatio)))
            End If
        ElseIf CDbl(Me.Height) / CDbl(Me.Width) <= Me.LegendPlateRatio Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Width = checked((int)Math.Round((double)this.Height / this.LegendPlateRatio));
            Me.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) / Me.LegendPlateRatio)))
        Else
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Height = checked((int)Math.Round((double)this.Width * this.LegendPlateRatio));
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

    Protected Overridable Sub OnValueSelectColor1Changed(ByVal e As EventArgs)
        Dim eventHandler As EventHandler = Me.ValueSelectColor1ChangedEvent
        If eventHandler IsNot Nothing Then
            eventHandler(Me, e)
        End If
    End Sub

    Private Sub RefreshImage()
        Dim graphic As Graphics
        Dim num As Decimal
        Dim num1 As Decimal
        If Me.m_LegendPlate <> PilotLight3Color.LegendPlates.Large Then
            num1 = New Decimal(CSng(Me.Width) / CSng(My.Resources.LegendPlateShort.Width))
            num = New Decimal(CSng(Me.Height) / CSng(My.Resources.LegendPlateShort.Height))
        Else
            num1 = New Decimal(CSng(Me.Width) / CSng(My.Resources.LegendPlate.Width))
            num = New Decimal(CSng(Me.Height) / CSng(My.Resources.LegendPlate.Height))
        End If
        If Decimal.Compare(num1, num) >= 0 Then
            Me.ImageRatio = num
        Else
            Me.ImageRatio = num1
        End If
        If Decimal.Compare(Me.ImageRatio, Decimal.Zero) > 0 Then
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            If Me.m_LegendPlate <> PilotLight3Color.LegendPlates.Large Then
                Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Height), Me.ImageRatio)))
                Me.LegendPlateRatio = CDbl(My.Resources.LegendPlateShort.Height) / CDbl(My.Resources.LegendPlateShort.Width)
                graphic = Graphics.FromImage(Me.StaticImage)
                graphic.DrawImage(My.Resources.LegendPlateShort, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Height), Me.ImageRatio)))
            Else
                Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Height), Me.ImageRatio)))
                Me.LegendPlateRatio = CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width)
                graphic = Graphics.FromImage(Me.StaticImage)
                graphic.DrawImage(My.Resources.LegendPlate, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Height), Me.ImageRatio)))
            End If
            Me.LightColor1Image = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.WhitePilotOn.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenPilotOff.Height), Me.ImageRatio)))
            Me.LightColor2Image = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenPilotOn.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenPilotOff.Height), Me.ImageRatio)))
            Me.LightColor3Image = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.RedPilotOn.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenPilotOff.Height), Me.ImageRatio)))
            graphic = Graphics.FromImage(Me.LightColor1Image)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.LightColor2Image)
            Dim graphic2 As Graphics = Graphics.FromImage(Me.LightColor3Image)
            If Me.m_LightColor1 = PilotLight3Color.LightColors.Green Then
                graphic.DrawImage(My.Resources.GreenPilotOn, 0, 0, Me.LightColor1Image.Width, Me.LightColor1Image.Height)
            ElseIf Me.m_LightColor1 = PilotLight3Color.LightColors.Red Then
                graphic.DrawImage(My.Resources.RedPilotOn, 0, 0, Me.LightColor1Image.Width, Me.LightColor1Image.Height)
            ElseIf Me.m_LightColor1 = PilotLight3Color.LightColors.Blue Then
                graphic.DrawImage(My.Resources.BluePilotOn, 0, 0, Me.LightColor1Image.Width, Me.LightColor1Image.Height)
            ElseIf Me.m_LightColor1 <> PilotLight3Color.LightColors.White Then
                graphic.DrawImage(My.Resources.YellowPilotOn, 0, 0, Me.LightColor1Image.Width, Me.LightColor1Image.Height)
            Else
                graphic.DrawImage(My.Resources.WhitePilotOn, 0, 0, Me.LightColor1Image.Width, Me.LightColor1Image.Height)
            End If
            If Me.m_LightColor2 = PilotLight3Color.LightColors.Green Then
                graphic1.DrawImage(My.Resources.GreenPilotOn, 0, 0, Me.LightColor2Image.Width, Me.LightColor2Image.Height)
            ElseIf Me.m_LightColor2 = PilotLight3Color.LightColors.Red Then
                graphic1.DrawImage(My.Resources.RedPilotOn, 0, 0, Me.LightColor2Image.Width, Me.LightColor2Image.Height)
            ElseIf Me.m_LightColor2 = PilotLight3Color.LightColors.Blue Then
                graphic1.DrawImage(My.Resources.BluePilotOn, 0, 0, Me.LightColor2Image.Width, Me.LightColor2Image.Height)
            ElseIf Me.m_LightColor2 <> PilotLight3Color.LightColors.White Then
                graphic1.DrawImage(My.Resources.YellowPilotOn, 0, 0, Me.LightColor2Image.Width, Me.LightColor2Image.Height)
            Else
                graphic1.DrawImage(My.Resources.WhitePilotOn, 0, 0, Me.LightColor2Image.Width, Me.LightColor2Image.Height)
            End If
            If Me.m_LightColor3 = PilotLight3Color.LightColors.Green Then
                graphic2.DrawImage(My.Resources.GreenPilotOn, 0, 0, Me.LightColor3Image.Width, Me.LightColor3Image.Height)
            ElseIf Me.m_LightColor3 = PilotLight3Color.LightColors.Red Then
                graphic2.DrawImage(My.Resources.RedPilotOn, 0, 0, Me.LightColor3Image.Width, Me.LightColor3Image.Height)
            ElseIf Me.m_LightColor3 = PilotLight3Color.LightColors.Blue Then
                graphic2.DrawImage(My.Resources.BluePilotOn, 0, 0, Me.LightColor3Image.Width, Me.LightColor3Image.Height)
            ElseIf Me.m_LightColor3 <> PilotLight3Color.LightColors.White Then
                graphic2.DrawImage(My.Resources.YellowPilotOn, 0, 0, Me.LightColor3Image.Width, Me.LightColor3Image.Height)
            Else
                graphic2.DrawImage(My.Resources.WhitePilotOn, 0, 0, Me.LightColor3Image.Width, Me.LightColor3Image.Height)
            End If
            Me.ButtonDownImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PilotLightDown.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.PilotLightDown.Height), Me.ImageRatio)))
            graphic = Graphics.FromImage(Me.ButtonDownImage)
            graphic.DrawImage(My.Resources.PilotLightDown, 0, 0, Me.ButtonDownImage.Width, Me.ButtonDownImage.Height)
            graphic.Dispose()
            graphic1.Dispose()
            Me.TextRectangle.X = 0
            Me.TextRectangle.Width = Me.Width
            Me.TextRectangle.Y = 0
            If Me.m_LegendPlate <> PilotLight3Color.LegendPlates.Large Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.18));
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.18)))
            Else
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.4));
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.4)))
            End If
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.ActiveLightImage = Me.LightColor1Image
            If Me.m_SelectColor2 Then
                Me.ActiveLightImage = Me.LightColor2Image
            ElseIf Me.m_SelectColor3 Then
                Me.ActiveLightImage = Me.LightColor3Image
            End If
            Me.Invalidate()
        End If
    End Sub

    Public Event ValueChanged As EventHandler

    Public Event ValueSelectColor1Changed As EventHandler

    Public Enum LegendPlates
        Large
        Small
    End Enum

    Public Enum LightColors
        Red
        Green
        Blue
        Yellow
        White
    End Enum
End Class

