Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Pipe
    Inherits Control


    Private StaticImage As Bitmap

    Private TextRectangle As Rectangle

    Private TextBrush As SolidBrush

    Private sf As StringFormat

    Private ImageRatio As Single

    Private m_Fitting As Pipe.FittingType

    Private m_Rotation As RotateFlipType

    Private BackNeedsRefreshed As Boolean

    Private _backBuffer As Bitmap

    Public Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            If MyBase.BackColor <> value Then
                MyBase.BackColor = value
                Me.BackNeedsRefreshed = True
                Me.RefreshImage()
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            'INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            If Me.m_Fitting <> Pipe.FittingType.Straight Then
                createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            End If
            Return createParams_Renamed
        End Get
    End Property

    Public Property Fitting() As Pipe.FittingType
        Get
            Return Me.m_Fitting
        End Get
        Set(ByVal value As Pipe.FittingType)
            If Me.m_Fitting <> value Then
                Me.m_Fitting = value
                Me.BackNeedsRefreshed = True
                Me.RefreshImage()
            End If
        End Set
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

    Public Property Rotation() As RotateFlipType
        Get
            Return Me.m_Rotation
        End Get
        Set(ByVal value As RotateFlipType)
            If value <> Me.m_Rotation Then
                Me.m_Rotation = value
                Me.BackNeedsRefreshed = True
                Me.RefreshImage()
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

        Me.TextRectangle = New Rectangle()
        Me.sf = New StringFormat()
        Me.m_Rotation = RotateFlipType.RotateNoneFlipNone
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Me._backBuffer.Dispose()
        Me.StaticImage.Dispose()
        Me.sf.Dispose()
        Try
            Me.TextBrush.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Me.DesignMode Then
            If (If(MyBase.Text.Length <= 3 OrElse Operators.CompareString(MyBase.Text.Substring(0, 4).ToUpper(), "PIPE", False) <> 0, False, True)) Then
                MyBase.Text = String.Empty
            End If
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.StaticImage Is Nothing Or Me._backBuffer Is Nothing Or Me.TextBrush Is Nothing) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.StaticImage, 0, 0)
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
            e.Graphics.DrawImageUnscaled(Me._backBuffer, 0, 0)
            graphic.Dispose()
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        If Me.BackNeedsRefreshed Then
            MyBase.OnPaintBackground(e)
            Me.BackNeedsRefreshed = False
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.RefreshImage()
    End Sub

    Private Sub RefreshImage()
        Dim flag As Boolean = False
        Dim horizontalPipe As Image
        If Not (Me.Width <= 0 Or Me.Height <= 0) Then
            Select Case Me.m_Fitting
                Case Pipe.FittingType.Straight
                    horizontalPipe = My.Resources.HorizontalPipe
                    Exit Select
                Case Pipe.FittingType.Elbow
                    horizontalPipe = My.Resources.Elbow1
                    Exit Select
                Case Pipe.FittingType.Tee
                    horizontalPipe = My.Resources.Tee1
                    Exit Select
                Case Else
                    horizontalPipe = My.Resources.HorizontalPipe
                    Exit Select
            End Select
            If Me.m_Rotation = RotateFlipType.Rotate90FlipNone Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipX Or Me.m_Rotation = RotateFlipType.Rotate90FlipX Or Me.m_Rotation = RotateFlipType.Rotate270FlipNone Or Me.m_Rotation = RotateFlipType.Rotate90FlipNone Then
                flag = True
            End If
            If Me._backBuffer IsNot Nothing Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            If flag Then
                Me.StaticImage = New Bitmap(Convert.ToInt32(Me.Height), Convert.ToInt32(Me.Width))
            Else
                Me.StaticImage = New Bitmap(Convert.ToInt32(Me.Width), Convert.ToInt32(Me.Height))
            End If
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
            If Me.BackColor <> Color.Transparent Then
                graphic.Clear(Me.BackColor)
            End If
            If flag Then
                graphic.DrawImage(horizontalPipe, 0, 0, Me.Height, Me.Width)
            Else
                graphic.DrawImage(horizontalPipe, 0, 0, Me.Width, Me.Height)
            End If
            Me.StaticImage.RotateFlip(Me.m_Rotation)
            Me.TextRectangle.X = 1
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Width = checked(this.Width - 2);
            Me.TextRectangle.Width = Me.Width - 2
            Me.TextRectangle.Y = 1
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.TextRectangle.Height = checked(this.Height - 2);
            Me.TextRectangle.Height = Me.Height - 2
            Me.sf = New StringFormat() With {
             .Alignment = StringAlignment.Center,
             .LineAlignment = StringAlignment.Center
            }
            If Me.TextBrush Is Nothing Then
                Me.TextBrush = New SolidBrush(MyBase.ForeColor)
            End If
            Dim solidBrush As New SolidBrush(Color.FromArgb(250, 60, 70, 60))
            graphic.Dispose()
            Me.Invalidate()
        End If
    End Sub

    Public Enum FittingType
        Straight
        Elbow
        Tee
    End Enum
End Class

