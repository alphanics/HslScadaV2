Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class WaterPump
    Inherits Control


    Private StaticImageOff As Bitmap

    Private StaticImageOn As Bitmap

    Private ImageRatio As Single

    Private TextRectangle As Rectangle

    Private sfCenter As StringFormat

    Private sfCenterBottom As StringFormat

    Private sfRight As StringFormat

    Private sfLeft As StringFormat

    Private m_Value As Boolean

    Private x As Single

    Private y As Single

    Private _backBuffer As Bitmap

    Private TextBrush As SolidBrush

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

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If MyBase.ForeColor <> value Then
                MyBase.ForeColor = value
                If Me.TextBrush IsNot Nothing Then
                    Me.TextBrush.Color = value
                Else
                    Me.TextBrush = New SolidBrush(MyBase.ForeColor)
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            Me.Invalidate()
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
            End If
        End Set
    End Property



    Public Sub New()
        Dim waterPump As WaterPump = Me
        AddHandler MyBase.Resize, AddressOf waterPump._Resize

        Me.TextRectangle = New Rectangle()
        Me.sfCenter = New StringFormat()
        Me.sfCenterBottom = New StringFormat()
        Me.sfRight = New StringFormat()
        Me.sfLeft = New StringFormat()
        Me.RefreshImage()
    End Sub


    Private Sub _Resize(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                Me.TextBrush.Dispose()
                Me._backBuffer.Dispose()
                Me.StaticImageOff.Dispose()
                Me.StaticImageOn.Dispose()
                Me.sfCenter.Dispose()
                Me.sfCenterBottom.Dispose()
                Me.sfRight.Dispose()
                Me.sfLeft.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImageOff Is Nothing Or Me.TextBrush Is Nothing) Then
            If Me._backBuffer Is Nothing Then
                Me._backBuffer = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
            End If
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            If Not Me.m_Value Then
                graphic.DrawImage(Me.StaticImageOff, 0, 0)
            Else
                graphic.DrawImage(Me.StaticImageOn, 0, 0)
            End If
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sfCenterBottom)
            End If
            e.Graphics.DrawImageUnscaled(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Me._backBuffer IsNot Nothing Then
            Me._backBuffer.Dispose()
            Me._backBuffer = Nothing
        End If
        Me.RefreshImage()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub RefreshImage()
        'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim width_Renamed As Single = CSng(CDbl(Me.Width) / CDbl(My.Resources.RSCorPumpOff.Width))
        'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim height_Renamed As Single = CSng(CDbl(Me.Height) / CDbl(My.Resources.RSCorPumpOff.Height))
        If width_Renamed >= height_Renamed Then
            Me.x = CSng(Me.Width)
            Me.y = CSng(CDbl(My.Resources.RSCorPumpOff.Height) / CDbl(My.Resources.RSCorPumpOff.Width) * CDbl(Me.Width))
            Me.ImageRatio = height_Renamed
        Else
            Me.y = CSng(Me.Height)
            If Not (Me.Height > 0 And My.Resources.RSCorPumpOff.Height > 0) Then
                Me.x = 1.0F
            Else
                Me.x = CSng(CDbl(My.Resources.RSCorPumpOff.Width) / CDbl(My.Resources.RSCorPumpOff.Height) * CDbl(Me.Height))
            End If
            Me.ImageRatio = width_Renamed
        End If
        If Me.ImageRatio > 0.0F Then
            If Me.StaticImageOff IsNot Nothing Then
                Me.StaticImageOff.Dispose()
            End If
            Me.StaticImageOff = New Bitmap(Convert.ToInt32(CSng(My.Resources.RSCorPumpOff.Width) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.RSCorPumpOff.Height) * Me.ImageRatio))
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImageOff)
            graphic.DrawImage(My.Resources.RSCorPumpOff, 0, 0, Me.StaticImageOff.Width, Me.StaticImageOff.Height)
            If Me.StaticImageOn IsNot Nothing Then
                Me.StaticImageOn.Dispose()
            End If
            Me.StaticImageOn = New Bitmap(Convert.ToInt32(CSng(My.Resources.RSCorPumpOn.Width) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.RSCorPumpOn.Height) * Me.ImageRatio))
            graphic = Graphics.FromImage(Me.StaticImageOn)
            graphic.DrawImage(My.Resources.RSCorPumpOn, 0, 0, Me.StaticImageOn.Width, Me.StaticImageOn.Height)
            graphic.Dispose()
            Me.TextRectangle.X = 0
            Me.TextRectangle.Y = 0
            Me.TextRectangle.Width = Me.StaticImageOff.Width
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Height = checked((int)Math.Round((double)this.StaticImageOff.Height * 0.99));
            Me.TextRectangle.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.StaticImageOff.Height) * 0.99)))
            Me.sfCenterBottom.Alignment = StringAlignment.Center
            Me.sfCenterBottom.LineAlignment = StringAlignment.Far
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
        End If
    End Sub
End Class

