Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class SelectorSwitch3Pos
    Inherits Control


    Private StaticImage As Bitmap

    Private SwitchImage As Bitmap

    Private SwitchLeftImage As Bitmap

    Private SwitchCenterImage As Bitmap

    Private SwitchRightImage As Bitmap

    Private TextRectangle As Rectangle

    Private ImageRatio As Decimal

    Private m_Value As Integer

    Private m_LegendPlate As SelectorSwitch3Pos.LegendPlates

    Private m_OutputType As OutputType

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private _backBuffer As Bitmap


    Private tmrError As Timer

    Private LegendPlateRatio As Decimal

    Private LastWidth As Integer

    Private LastHeight As Integer

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            'INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            Return createParams_Renamed
        End Get
    End Property

    Public Property LegendPlate() As SelectorSwitch3Pos.LegendPlates
        Get
            Return Me.m_LegendPlate
        End Get
        Set(ByVal value As SelectorSwitch3Pos.LegendPlates)
            If Me.m_LegendPlate <> value Then
                Me.m_LegendPlate = value
                Me.RefreshImage()
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

    Private m_ValueOfCenterPosition As Integer
    Public Property ValueOfCenterPosition As Integer
        Get
            Return m_ValueOfCenterPosition
        End Get
        Set(ByVal value As Integer)
            If (m_ValueOfCenterPosition <> value) Then
                m_ValueOfCenterPosition = value
            End If
        End Set
    End Property
    Dim m_ValueOfLeftPosition As Integer
    Public Property ValueOfLeftPosition As Integer
        Get
            Return Me.m_ValueOfLeftPosition
        End Get
        Set(ByVal value As Integer)
            If (Me.m_ValueOfLeftPosition <> value) Then
                Me.m_ValueOfLeftPosition = value
            End If
        End Set
    End Property
    Private m_ValueOfRightPosition As Integer
    Public Property ValueOfRightPosition As Integer
        Get
            Return m_ValueOfRightPosition
        End Get
        Set(ByVal value As Integer)
            If (m_ValueOfRightPosition <> value) Then
                m_ValueOfRightPosition = value
            End If
        End Set
    End Property

    Public Property Value() As Integer
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case 0
                    Me.SwitchImage = Me.SwitchLeftImage
                    Exit Select
                Case 1
                    Me.SwitchImage = Me.SwitchCenterImage
                    Exit Select
                Case 2
                    Me.SwitchImage = Me.SwitchRightImage
                    Exit Select
                Case Else
                    Me.SwitchImage = Me.SwitchRightImage
                    Exit Select
            End Select
            Me.m_Value = value
            Me.m_Value = Math.Max(0, Math.Min(Me.m_Value, 2))
            Me.Invalidate()
        End Set
    End Property



    Public Sub New()
        Dim selectorSwitch3Po As SelectorSwitch3Pos = Me
        AddHandler MyBase.MouseDown, AddressOf selectorSwitch3Po.MomentaryButton_MouseDown
        Dim selectorSwitch3Po1 As SelectorSwitch3Pos = Me
        AddHandler MyBase.TextChanged, AddressOf selectorSwitch3Po1.SelectorSwitch_TextChanged
        Dim selectorSwitch3Po2 As SelectorSwitch3Pos = Me
        AddHandler MyBase.Resize, AddressOf selectorSwitch3Po2.MomentaryButton_Resize

        Me.TextRectangle = New Rectangle()
        Me.m_Value = 1
        Me.m_LegendPlate = SelectorSwitch3Pos.LegendPlates.Large
        Me.m_OutputType = OutputType.MomentarySet
        Me.sf = New StringFormat()
        Me.tmrError = New Timer()
        Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width))
    End Sub


    Private Sub MomentaryButton_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim switchCenterEventHandler As SelectorSwitch3Pos.SwitchCenterEventHandler
        If CDbl(e.X) < CDbl(Me.Width) * 0.5 Then
            If Me.m_Value > 0 Then
                If Me.m_Value <> 1 Then
                    switchCenterEventHandler = Me.SwitchCenterEvent
                    If switchCenterEventHandler IsNot Nothing Then
                        switchCenterEventHandler()
                    End If
                Else
                    Dim switchLeftEventHandler As SelectorSwitch3Pos.SwitchLeftEventHandler = Me.SwitchLeftEvent
                    If switchLeftEventHandler IsNot Nothing Then
                        switchLeftEventHandler()
                    End If
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.Value = checked(this.Value - 1);
                Me.Value = Me.Value - 1
            End If
        ElseIf CDbl(e.Y) > CDbl(Me.Height) / 2 Then
            If Me.m_Value < 2 Then
                If Me.m_Value <> 1 Then
                    switchCenterEventHandler = Me.SwitchCenterEvent
                    If switchCenterEventHandler IsNot Nothing Then
                        switchCenterEventHandler()
                    End If
                Else
                    Dim switchRightEventHandler As SelectorSwitch3Pos.SwitchRightEventHandler = Me.SwitchRightEvent
                    If switchRightEventHandler IsNot Nothing Then
                        switchRightEventHandler()
                    End If
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.Value = checked(this.Value + 1);
                Me.Value = Me.Value + 1
            End If
        End If
    End Sub

    Private Sub MomentaryButton_Resize(ByVal sender As Object, ByVal e As EventArgs)
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
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImage Is Nothing Or Me._backBuffer Is Nothing Or Me.SwitchImage Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.StaticImage, 0, 0)
            If Me.m_LegendPlate <> SelectorSwitch3Pos.LegendPlates.Large Then
                graphic.DrawImage(Me.SwitchImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.SwitchImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.59 - CDbl(Me.SwitchImage.Height) / 2))
            Else
                graphic.DrawImage(Me.SwitchImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) / 2 - CDbl(Me.SwitchImage.Width) / 2), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.68 - CDbl(Me.SwitchImage.Height) / 2))
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
        Dim num As Decimal
        Dim num1 As Decimal
        If Me.m_LegendPlate <> SelectorSwitch3Pos.LegendPlates.Large Then
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
            If Me.m_LegendPlate <> SelectorSwitch3Pos.LegendPlates.Large Then
                Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Height), Me.ImageRatio)))
                Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlateShort.Height) / CDbl(My.Resources.LegendPlateShort.Width))
            Else
                Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Height), Me.ImageRatio)))
                Me.LegendPlateRatio = New Decimal(CDbl(My.Resources.LegendPlate.Height) / CDbl(My.Resources.LegendPlate.Width))
            End If
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
            If Me.m_LegendPlate <> SelectorSwitch3Pos.LegendPlates.Large Then
                graphic.DrawImage(My.Resources.LegendPlateShort, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlateShort.Height), Me.ImageRatio)))
            Else
                graphic.DrawImage(My.Resources.LegendPlate, 0.0F, 0.0F, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.LegendPlate.Height), Me.ImageRatio)))
            End If
            Me.SwitchLeftImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.SelectorSwitchLeft.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.SelectorSwitchLeft.Height), Me.ImageRatio)))
            Me.SwitchRightImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.SelectorSwitchRight.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.SelectorSwitchRight.Height), Me.ImageRatio)))
            Me.SwitchCenterImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.SelectorSwitchRight.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.SelectorSwitchRight.Height), Me.ImageRatio)))
            graphic = Graphics.FromImage(Me.SwitchLeftImage)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.SwitchRightImage)
            Dim graphic2 As Graphics = Graphics.FromImage(Me.SwitchCenterImage)
            graphic.DrawImage(My.Resources.SelectorSwitchLeft, 0, 0, Me.SwitchLeftImage.Width, Me.SwitchLeftImage.Height)
            graphic1.DrawImage(My.Resources.SelectorSwitchRight, 0, 0, Me.SwitchRightImage.Width, Me.SwitchRightImage.Height)
            graphic2.DrawImage(My.Resources.SelectorSwitchCenter, 0, 0, Me.SwitchCenterImage.Width, Me.SwitchCenterImage.Height)
            Me.SwitchImage = Me.SwitchCenterImage
            graphic.Dispose()
            graphic1.Dispose()
            graphic2.Dispose()
            Me.TextRectangle.X = 0
            Me.TextRectangle.Width = Me.Width
            Me.TextRectangle.Y = 0
            If Me.m_LegendPlate <> SelectorSwitch3Pos.LegendPlates.Large Then
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.18));
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.18)))
            Else
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.Height * 0.4));
                Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.Height) * 0.4)))
            End If
            Me.sf.Alignment = StringAlignment.Center
            Me.sf.LineAlignment = StringAlignment.Center
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub

    Private Sub SelectorSwitch_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.Invalidate()
    End Sub

    Public Event SwitchCenter As SelectorSwitch3Pos.SwitchCenterEventHandler

    Public Event SwitchLeft As SelectorSwitch3Pos.SwitchLeftEventHandler

    Public Event SwitchRight As SelectorSwitch3Pos.SwitchRightEventHandler

    Public Enum LegendPlates
        Large
        Small
    End Enum

    Public Delegate Sub SwitchCenterEventHandler()

    Public Delegate Sub SwitchLeftEventHandler()

    Public Delegate Sub SwitchRightEventHandler()
End Class

