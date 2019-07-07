Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


<DefaultEvent("Click")>
Public Class PushButton
    Inherits Control

#Region "Fild"
    Private StaticImage As Bitmap

    Private ButtonImage As Bitmap

    Private ButtonUpImage As Bitmap

    Private ButtonPressedImage As Bitmap

    Private TextRectangle As Rectangle

    Private ImageRatio As Decimal

    Private m_ButtonColor As ButtonColors

    Private m_LegendPlate As LegendPlates

    Private m_OutputType As OutputTypes

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private _backBuffer As Bitmap

    Private LegendPlateRatio As Decimal

    Private LastWidth As Integer

    Private LastHeight As Integer
#End Region
#Region "Property"
    Public Property ButtonColor() As ButtonColors
        Get
            Return Me.m_ButtonColor
        End Get
        Set(ByVal value As ButtonColors)
            Me.m_ButtonColor = value
            Me.RefreshImage()
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            Return createParams_Renamed
        End Get
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            MyBase.ForeColor = value
            Me.TextBrush.Color = value
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

    Public Property LegendPlate() As PushButton.LegendPlates
        Get
            Return Me.m_LegendPlate
        End Get
        Set(ByVal value As PushButton.LegendPlates)
            Me.m_LegendPlate = value
            Me.RefreshImage()
            Me.OnResize(EventArgs.Empty)
        End Set
    End Property

    Public Property OutputType() As PushButton.OutputTypes
        Get
            Return Me.m_OutputType
        End Get
        Set(ByVal value As PushButton.OutputTypes)
            Me.m_OutputType = value
        End Set
    End Property

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            Me.RefreshImage()
            Me.Invalidate()
        End Set
    End Property

#End Region

#Region "Sub"
    Public Sub New()

        Me.TextRectangle = New Rectangle()
        Me.m_ButtonColor = ButtonColors.Green
        Me.m_LegendPlate = LegendPlates.Large
        Me.m_OutputType = OutputTypes.MomentarySet
        Me.sf = New StringFormat()
        Me.TextBrush = New SolidBrush(Color.Black)
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        If Me.Height <> Me.LastHeight Or Me.Width <> Me.LastWidth Then
            If Me.m_LegendPlate <> PushButton.LegendPlates.Large Then
                Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlateShort.Height) / CDbl(My.Resources.LegendPlateShort.Width))
            Else
                Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width))
            End If
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
            Me.RefreshImage()
        End If
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.ButtonImage = Me.ButtonPressedImage
        Me.Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        Me.ButtonImage = Me.ButtonUpImage
        Me.Invalidate()
    End Sub


    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImage Is Nothing Or Me._backBuffer Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.StaticImage, 0, 0)
            If Me.m_LegendPlate <> PushButton.LegendPlates.Large Then
                graphic.DrawImage(Me.ButtonImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.ButtonImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.59 - CDbl(Me.ButtonImage.Height) / 2))
            Else
                graphic.DrawImage(Me.ButtonImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.ButtonImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.68 - CDbl(Me.ButtonImage.Height) / 2))
            End If
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Private Sub RefreshImage()
        Dim WidthRatio As Decimal
        Dim HeightRatio As Decimal
        If Me.m_LegendPlate <> PushButton.LegendPlates.Large Then
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
            If Me.m_LegendPlate <> PushButton.LegendPlates.Large Then
                Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Height), Me.ImageRatio)))
                Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlateShort.Height) / CDbl(My.Resources.LegendPlateShort.Width))
            Else
                Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Height), Me.ImageRatio)))
                Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width))
            End If
            Dim gr_dest As Graphics = Graphics.FromImage(Me.StaticImage)
            If Me.m_LegendPlate <> PushButton.LegendPlates.Large Then
                gr_dest.DrawImage(My.Resources.LegendPlateShort, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Height), Me.ImageRatio)))
            Else
                gr_dest.DrawImage(My.Resources.LegendPlate, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Height), Me.ImageRatio)))
            End If
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            Select Case Me.m_ButtonColor
                Case ButtonColors.Red
                    Me.ButtonUpImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.RedButton.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.RedButton.Height), Me.ImageRatio)))
                    Me.ButtonPressedImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.RedButtonPressed.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.RedButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
                Case ButtonColors.Green

                    Me.ButtonUpImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Height), Me.ImageRatio)))
                    Me.ButtonPressedImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
                Case ButtonColors.Blue
                    Me.ButtonUpImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.BlueButton.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.BlueButton.Height), Me.ImageRatio)))
                    Me.ButtonPressedImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.BlueButtonPressed.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.BlueButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
                Case ButtonColors.Black
                    Me.ButtonUpImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.BlackButton.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.BlackButton.Height), Me.ImageRatio)))
                    Me.ButtonPressedImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.BlackButtonPressed.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.BlackButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
                Case ButtonColors.RedMushroom
                    Me.ButtonUpImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.EstopButton.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.EstopButton.Height), Me.ImageRatio)))
                    Me.ButtonPressedImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.EstopButtonDown.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.EstopButtonDown.Height), Me.ImageRatio)))
                    Exit Select
                Case Else
                    Me.ButtonUpImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Height), Me.ImageRatio)))
                    Me.ButtonPressedImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
            End Select
            gr_dest = Graphics.FromImage(Me.ButtonUpImage)
            Dim gr_dest2 As Graphics = Graphics.FromImage(Me.ButtonPressedImage)
            Select Case Me.m_ButtonColor
                Case ButtonColors.Red
                    gr_dest.DrawImage(My.Resources.RedButton, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Height), Me.ImageRatio)))
                    gr_dest2.DrawImage(My.Resources.RedButtonPressed, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
                Case ButtonColors.Green

                    gr_dest.DrawImage(My.Resources.GreenButton, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Height), Me.ImageRatio)))
                    gr_dest2.DrawImage(My.Resources.GreenButtonPressed, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
                Case ButtonColors.Blue
                    gr_dest.DrawImage(My.Resources.BlueButton, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Height), Me.ImageRatio)))
                    gr_dest2.DrawImage(My.Resources.BlueButtonPressed, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
                Case ButtonColors.Black
                    gr_dest.DrawImage(My.Resources.BlackButton, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Height), Me.ImageRatio)))
                    gr_dest2.DrawImage(My.Resources.BlackButtonPressed, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
                Case ButtonColors.RedMushroom
                    gr_dest.DrawImage(My.Resources.EstopButton, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.EstopButton.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.EstopButton.Height), Me.ImageRatio)))
                    gr_dest2.DrawImage(My.Resources.EstopButtonDown, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.EstopButtonDown.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.EstopButtonDown.Height), Me.ImageRatio)))
                    Exit Select
                Case Else
                    gr_dest.DrawImage(My.Resources.GreenButton, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButton.Height), Me.ImageRatio)))
                    gr_dest2.DrawImage(My.Resources.GreenButtonPressed, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.GreenButtonPressed.Height), Me.ImageRatio)))
                    Exit Select
            End Select
            Me.ButtonImage = Me.ButtonUpImage
            Me.TextRectangle.X = 0
            Me.TextRectangle.Width = Me.Width
            Me.TextRectangle.Y = 0
            If Me.m_LegendPlate <> PushButton.LegendPlates.Large Then
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.18)))
            Else
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.4)))
            End If
            Me.sf.Alignment = StringAlignment.Center
            Me.sf.LineAlignment = StringAlignment.Center
            gr_dest.Dispose()
            gr_dest2.Dispose()
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub
#End Region
#Region "Enum"
    Public Enum ButtonColors
        Red
        Green
        Blue
        Black
        RedMushroom
    End Enum

    Public Enum LegendPlates
        Large
        Small
    End Enum

    Public Enum OutputTypes
        MomentarySet
        MomentaryReset
        SetTrue
        SetFalse
        Toggle
    End Enum
#End Region

End Class

