Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class SquareIlluminatedButton
    Inherits Control


    Private LightImage As Bitmap

    Private OffImage As Bitmap

    Private OnImage As Bitmap

    Private ButtonDownImage As Bitmap

    Private TextRectangle As Rectangle

    Private ImageRatio As Decimal

    Private MouseIsDown As Boolean

    Private m_LightColor As SquareIlluminatedButton.LightColors

    Private _Value As Boolean

    Private m_OutputType As OutputType

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private _backBuffer As Bitmap


    Private tmrError As Timer

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            Return createParams_Renamed
        End Get
    End Property

    Public Property LightColor() As LightColors
        Get
            Return Me.m_LightColor
        End Get
        Set(ByVal value As LightColors)
            Me.m_LightColor = value
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
            Return Me._Value
        End Get
        Set(ByVal value As Boolean)
            If Not value Then
                Me.LightImage = Me.OffImage
            Else
                Me.LightImage = Me.OnImage
            End If
            Me._Value = value
            Me.Invalidate()
        End Set
    End Property



    Public Sub New()

        Me.m_LightColor = LightColors.Green
        Me.m_OutputType = OutputType.MomentarySet
        Me.sf = New StringFormat()
        Me.tmrError = New Timer()
        Me.sf.Alignment = StringAlignment.Center
        Me.sf.LineAlignment = StringAlignment.Center
        Me.TextBrush = New SolidBrush(Color.Black)
        Me.TextRectangle = New Rectangle()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Me.Enabled Then
            Me.MouseIsDown = True
            Me.Invalidate()
        End If
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        Me.MouseIsDown = False
        Me.Invalidate()
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.RefreshImage()
    End Sub
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me._backBuffer Is Nothing Or Me.LightImage Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.LightImage, 0, 0)
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
            If Me.MouseIsDown Then
                graphic.DrawImage(Me.ButtonDownImage, 0, 0)
            End If
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Private Sub RefreshImage()
        If Not (Me.Width <= 0 Or Me.Height <= 0) Then
            Me.OffImage = New Bitmap(Me.Width, Me.Height)
            Me.OnImage = New Bitmap(Me.Width, Me.Height)
            Dim graphic As Graphics = Graphics.FromImage(Me.OffImage)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.OnImage)
            Select Case Me.m_LightColor
                Case SquareIlluminatedButton.LightColors.Red
                    graphic.DrawImage(My.Resources.SquareButtonRedOff, 0, 0, Me.OffImage.Width, Me.OffImage.Height)
                    graphic1.DrawImage(My.Resources.SquareButtonRedOn, 0, 0, Me.OnImage.Width, Me.OnImage.Height)
                    Exit Select
                Case SquareIlluminatedButton.LightColors.Green
                    graphic.DrawImage(My.Resources.SquareButtonGreenOff, 0, 0, Me.OffImage.Width, Me.OffImage.Height)
                    graphic1.DrawImage(My.Resources.SquareButtonGreenOn, 0, 0, Me.OnImage.Width, Me.OnImage.Height)
                    Exit Select
                Case SquareIlluminatedButton.LightColors.Blue
                    graphic.DrawImage(My.Resources.SquareButtonBlueOff, 0, 0, Me.OffImage.Width, Me.OffImage.Height)
                    graphic1.DrawImage(My.Resources.SquareButtonBlueOn, 0, 0, Me.OnImage.Width, Me.OnImage.Height)
                    Exit Select
            End Select
            Dim num As New Decimal(CDbl(My.Resources.SquareButtonDown.Width) / CDbl(My.Resources.SquareButtonBlueOff.Width))
            Dim num1 As New Decimal(CDbl(My.Resources.SquareButtonDown.Height) / CDbl(My.Resources.SquareButtonBlueOff.Height))
            Me.ButtonDownImage = New Bitmap(Me.Width, Me.Height)
            graphic = Graphics.FromImage(Me.ButtonDownImage)
            graphic.DrawImage(My.Resources.SquareButtonDown, Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(10)), num)), Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(10)), num1)), Convert.ToSingle(Decimal.Multiply(New Decimal(Me.ButtonDownImage.Width), num)), Convert.ToSingle(Decimal.Multiply(New Decimal(Me.ButtonDownImage.Height), num1)))
            If Not Me._Value Then
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
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub

    Public Enum LightColors
        Red
        Green
        Blue
    End Enum
End Class

