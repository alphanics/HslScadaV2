Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms



Public Class StackLight
    Inherits Control


    Private StaticImage As Bitmap

    Private StaticImage2 As Bitmap

    Private LightImages() As Bitmap

    Private Light1Image As Bitmap

    Private Light2Image As Bitmap

    Private Light3Image As Bitmap

    Private ImageRatio As Single

    Private TextRectangle As Rectangle

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private m_ValueGreen As Boolean

    Private m_EnableGreen As Boolean

    Private m_ValueAmber As Boolean

    Private m_EnableAmber As Boolean

    Private m_ValueRed As Boolean

    Private m_EnableRed As Boolean

    Private LightCount As Integer

    Private BackgroundNeedsRefreshed As Boolean

    Private _backBuffer As Bitmap

    Private LegendPlateRatio As Double

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
    Public Overrides Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            Me.Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If Me.TextBrush IsNot Nothing Then
                Me.TextBrush.Color = value
            Else
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            MyBase.ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property LightAmberEnable() As Boolean
        Get
            Return Me.m_EnableAmber
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_EnableAmber Then
                Me.m_EnableAmber = value
                Me.SetLightCount()
                Me.BackgroundNeedsRefreshed = True
            End If
        End Set
    End Property

    Public Property LightAmberValue() As Boolean
        Get
            Return Me.m_ValueAmber
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_ValueAmber Then
                Me.m_ValueAmber = value
                If Not Me.m_ValueAmber Then
                    Me.Light2Image = Me.LightImages(2)
                Else
                    Me.Light2Image = Me.LightImages(3)
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property LightGreenEnable() As Boolean
        Get
            Return Me.m_EnableGreen
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_EnableGreen Then
                Me.m_EnableGreen = value
                Me.SetLightCount()
                Me.BackgroundNeedsRefreshed = True
            End If
        End Set
    End Property

    Public Property LightGreenValue() As Boolean
        Get
            Return Me.m_ValueGreen
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_ValueGreen Then
                Me.m_ValueGreen = value
                If Not Me.m_ValueGreen Then
                    Me.Light1Image = Me.LightImages(0)
                Else
                    Me.Light1Image = Me.LightImages(1)
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property LightRedEnable() As Boolean
        Get
            Return Me.m_EnableRed
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_EnableRed Then
                Me.m_EnableRed = value
                Me.SetLightCount()
                Me.BackgroundNeedsRefreshed = True
            End If
        End Set
    End Property

    Public Property LightRedValue() As Boolean
        Get
            Return Me.m_ValueRed
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_ValueRed Then
                Me.m_ValueRed = value
                If Not Me.m_ValueRed Then
                    Me.Light3Image = Me.LightImages(4)
                Else
                    Me.Light3Image = Me.LightImages(5)
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


    Public Sub New()
        Dim stackLight As StackLight = Me
        AddHandler MyBase.Resize, AddressOf stackLight.MomentaryButton_Resize

        Me.LightImages = New Bitmap(5) {}
        Me.TextRectangle = New Rectangle()
        Me.sf = New StringFormat()
        Me.m_EnableGreen = True
        Me.m_EnableAmber = True
        Me.m_EnableRed = True
        Me.LightCount = 3
        Me.LegendPlateRatio = CDbl(My.Resources.StackLightCap.Height) + CDbl(My.Resources.StackLightGreenOn.Height * Me.LightCount) / CDbl(My.Resources.StackLightCap.Width)
        Me.RefreshImage()
    End Sub




    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                Me.TextBrush.Dispose()
                Me.sf.Dispose()
                Me._backBuffer.Dispose()
                Me.StaticImage2.Dispose()
                Me.StaticImage.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub MomentaryButton_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Me.RefreshImage()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Me.DesignMode Then
            If (Me.Parent.BackColor = Color.Black) And (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Then
                Me.ForeColor = Color.White
            End If
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim height_Renamed As Integer = 0
        If Not (Me.StaticImage Is Nothing Or Me.StaticImage2 Is Nothing Or Me._backBuffer Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            Try
                If Me.m_EnableRed Then
                    graphic.DrawImage(Me.Light3Image, 0, Convert.ToInt32(Me.StaticImage2.Height))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: height = checked(height + this.Light3Image.Height);
                    height_Renamed = height_Renamed + Me.Light3Image.Height
                End If
                If Me.m_EnableAmber Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.DrawImage(this.Light2Image, 0, Convert.ToInt32(checked(this.StaticImage2.Height + height)));
                    graphic.DrawImage(Me.Light2Image, 0, Convert.ToInt32(Me.StaticImage2.Height + height_Renamed))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: height = checked(height + this.Light2Image.Height);
                    height_Renamed = height_Renamed + Me.Light2Image.Height
                End If
                If Me.m_EnableGreen Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.DrawImage(this.Light1Image, 0, Convert.ToInt32(checked(this.StaticImage2.Height + height)));
                    graphic.DrawImage(Me.Light1Image, 0, Convert.ToInt32(Me.StaticImage2.Height + height_Renamed))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: height = checked(height + this.Light1Image.Height);
                    height_Renamed = height_Renamed + Me.Light1Image.Height
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawImage(this.StaticImage, 0, Convert.ToInt32(checked(this.StaticImage2.Height + height)));
                graphic.DrawImage(Me.StaticImage, 0, Convert.ToInt32(Me.StaticImage2.Height + height_Renamed))
                graphic.DrawImage(Me.StaticImage2, 0, 0)
                If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                    If Me.TextBrush.Color <> MyBase.ForeColor Then
                        Me.TextBrush.Color = MyBase.ForeColor
                    End If
                    graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
                End If
            Catch exception As Exception
                ProjectData.SetProjectError(exception)
                ProjectData.ClearProjectError()
            End Try
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
            graphic.Dispose()
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        If Me.BackgroundNeedsRefreshed Then
            MyBase.OnPaintBackground(e)
            Me.BackgroundNeedsRefreshed = False
        End If
    End Sub

    Private Sub RefreshImage()
        Dim graphic As Graphics
        'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim height_Renamed As Single = 0.0F
        Try
            'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim width_Renamed As Single = CSng(Me.Width) / CSng(My.Resources.StackLightBase.Width)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: height = (float)(checked(My.Resources.StackLightBase.Height + My.Resources.StackLightCap.Height));
            height_Renamed = CSng(My.Resources.StackLightBase.Height + My.Resources.StackLightCap.Height)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: height = height + (float)(checked(My.Resources.StackLightGreenOff.Height * this.LightCount));
            height_Renamed = height_Renamed + CSng(My.Resources.StackLightGreenOff.Height * Me.LightCount)
            Dim [single] As Single = CSng(Me.Height) / CSng(height_Renamed)
            If width_Renamed >= [single] Then
                Me.ImageRatio = [single]
            Else
                Me.ImageRatio = width_Renamed
            End If
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            ProjectData.ClearProjectError()
        End Try
        If Me.ImageRatio > 0.0F Then
            If Me.StaticImage IsNot Nothing Then
                Me.StaticImage.Dispose()
            End If
            Me.StaticImage = New Bitmap(Convert.ToInt32(CSng(My.Resources.StackLightBase.Width) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.StackLightBase.Height) * Me.ImageRatio))
            Dim graphic1 As Graphics = Graphics.FromImage(Me.StaticImage)
            graphic1.DrawImage(My.Resources.StackLightBase, 0, 0, Me.StaticImage.Width, Convert.ToInt32(CDbl(Me.StaticImage.Width) / CDbl(My.Resources.StackLightBase.Width) * CDbl(My.Resources.StackLightBase.Height)))
            Me.TextRectangle.X = 1
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Width = checked(this.StaticImage.Width - 2);
            Me.TextRectangle.Width = Me.StaticImage.Width - 2
            Me.TextRectangle.Y = Convert.ToInt32(CDbl(height_Renamed) * 0.82 * CDbl(Me.ImageRatio))
            Me.TextRectangle.Height = Convert.ToInt32(CDbl(height_Renamed) * 0.16 * CDbl(Me.ImageRatio))
            Me.sf.Alignment = StringAlignment.Center
            Me.sf.LineAlignment = StringAlignment.Center
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            graphic1.Dispose()
            If Me.StaticImage2 IsNot Nothing Then
                Me.StaticImage2.Dispose()
            End If
            Me.StaticImage2 = New Bitmap(Convert.ToInt32(CSng(My.Resources.StackLightCap.Width) * Me.ImageRatio), Convert.ToInt32(CSng(My.Resources.StackLightCap.Height) * Me.ImageRatio))
            graphic1 = Graphics.FromImage(Me.StaticImage2)
            graphic1.DrawImage(My.Resources.StackLightCap, 0, 0, Me.StaticImage.Width, Convert.ToInt32(CDbl(Me.StaticImage.Width) / CDbl(My.Resources.StackLightBase.Width) * CDbl(My.Resources.StackLightCap.Height)))
            graphic1.Dispose()
            Try
                Me.LightImages(0) = New Bitmap(Me.StaticImage.Width, Convert.ToInt32(CSng(My.Resources.StackLightGreenOff.Height) * Me.ImageRatio))
                Me.LightImages(1) = New Bitmap(Me.StaticImage.Width, Convert.ToInt32(CSng(My.Resources.StackLightGreenOn.Height) * Me.ImageRatio))
                graphic1 = Graphics.FromImage(Me.LightImages(0))
                graphic = Graphics.FromImage(Me.LightImages(1))
                graphic1.DrawImage(My.Resources.StackLightGreenOff, 0, 0, Me.LightImages(0).Width, Me.LightImages(0).Height)
                graphic.DrawImage(My.Resources.StackLightGreenOn, 0, 0, Me.LightImages(1).Width, Me.LightImages(1).Height)
                graphic1.Dispose()
                graphic.Dispose()
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError()
            End Try
            Try
                Me.LightImages(2) = New Bitmap(Me.StaticImage.Width, Convert.ToInt32(CSng(My.Resources.StackLightAmberOff.Height) * Me.ImageRatio))
                Me.LightImages(3) = New Bitmap(Me.StaticImage.Width, Convert.ToInt32(CSng(My.Resources.StackLightAmberOn.Height) * Me.ImageRatio))
                graphic1 = Graphics.FromImage(Me.LightImages(2))
                graphic = Graphics.FromImage(Me.LightImages(3))
                graphic1.DrawImage(My.Resources.StackLightAmberOff, 0, 0, Me.LightImages(2).Width, Me.LightImages(2).Height)
                graphic.DrawImage(My.Resources.StackLightAmberOn, 0, 0, Me.LightImages(3).Width, Me.LightImages(3).Height)
                graphic1.Dispose()
                graphic.Dispose()
            Catch exception2 As Exception
                ProjectData.SetProjectError(exception2)
                ProjectData.ClearProjectError()
            End Try
            Try
                Me.LightImages(4) = New Bitmap(Me.StaticImage.Width, Convert.ToInt32(CSng(My.Resources.StackLightRedOff.Height) * Me.ImageRatio))
                Me.LightImages(5) = New Bitmap(Me.StaticImage.Width, Convert.ToInt32(CSng(My.Resources.StackLightRedON.Height) * Me.ImageRatio))
                graphic1 = Graphics.FromImage(Me.LightImages(4))
                graphic = Graphics.FromImage(Me.LightImages(5))
                graphic1.DrawImage(My.Resources.StackLightRedOff, 0, 0, Me.LightImages(4).Width, Me.LightImages(4).Height)
                graphic.DrawImage(My.Resources.StackLightRedON, 0, 0, Me.LightImages(5).Width, Me.LightImages(5).Height)
                graphic1.Dispose()
                graphic.Dispose()
            Catch exception3 As Exception
                ProjectData.SetProjectError(exception3)
                ProjectData.ClearProjectError()
            End Try
            Me.Light1Image = Me.LightImages(0)
            Me.Light2Image = Me.LightImages(2)
            Me.Light3Image = Me.LightImages(4)
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
        End If
    End Sub

    Private Sub SetLightCount()
        Me.LightCount = 0
        If Me.m_EnableAmber Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.LightCount = checked(this.LightCount + 1);
            Me.LightCount = Me.LightCount + 1
        End If
        If Me.m_EnableRed Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.LightCount = checked(this.LightCount + 1);
            Me.LightCount = Me.LightCount + 1
        End If
        If Me.m_EnableGreen Then
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.LightCount = checked(this.LightCount + 1);
            Me.LightCount = Me.LightCount + 1
        End If
        'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
        'ORIGINAL LINE: this.LegendPlateRatio = (double)(checked(My.Resources.StackLightCap.Height + checked(My.Resources.StackLightGreenOn.Height * this.LightCount))) / (double)My.Resources.StackLightCap.Width;
        Me.LegendPlateRatio = CDbl(My.Resources.StackLightCap.Height + My.Resources.StackLightGreenOn.Height * Me.LightCount) / CDbl(My.Resources.StackLightCap.Width)
        Me.RefreshImage()
        Me.Invalidate()
    End Sub
End Class

