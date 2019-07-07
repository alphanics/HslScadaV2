Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Indicator
    Inherits Control

    Private StaticImage As Bitmap

    Private TextRect As Rectangle

    Private ImageRatio As Single

    Private m_SelectColor2 As Boolean

    Private m_SelectColor3 As Boolean

    Private m_Color1 As Color

    Private BrushColor1 As SolidBrush

    Private m_Color2 As Color

    Private BrushColor2 As SolidBrush

    Private m_Color3 As Color

    Private BrushColor3 As SolidBrush

    Private _OutlineColor As Color

    Private m_OutlineWidth As Integer

    Private m_Shape As Indicator.ShapeTypes

    Private RefreshBackground As Boolean

    Private sf As StringFormat

    Private TextBrush As SolidBrush

    Private BackgroundBrush As SolidBrush

    Private BorderPen As Pen

    <Category("Appearance")>
    Public Property Color1() As Color
        Get
            Return Me.m_Color1
        End Get
        Set(ByVal value As Color)
            If Me.m_Color1 <> value Then
                Me.m_Color1 = value
                If Me.BrushColor1 IsNot Nothing Then
                    Me.BrushColor1.Color = value
                Else
                    Me.BrushColor1 = New SolidBrush(Me.m_Color1)
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property Color2() As Color
        Get
            Return Me.m_Color2
        End Get
        Set(ByVal value As Color)
            If Me.m_Color2 <> value Then
                Me.m_Color2 = value
                If Me.BrushColor2 IsNot Nothing Then
                    Me.BrushColor2.Color = value
                Else
                    Me.BrushColor2 = New SolidBrush(Me.m_Color2)
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property Color3() As Color
        Get
            Return Me.m_Color3
        End Get
        Set(ByVal value As Color)
            If Me.m_Color3 <> value Then
                Me.m_Color3 = value
                If Me.BrushColor3 IsNot Nothing Then
                    Me.BrushColor3.Color = value
                Else
                    Me.BrushColor3 = New SolidBrush(Me.m_Color3)
                End If
                Me.Invalidate()
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            'INSTANT VB NOTE: The local variable createParams was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
            Dim createParams_Renamed As CreateParams = MyBase.CreateParams
            createParams_Renamed.ExStyle = createParams_Renamed.ExStyle Or 32
            Return createParams_Renamed
        End Get
    End Property

    <Category("Appearance")>
    Public Property OutlineColor() As Color
        Get
            Return Me._OutlineColor
        End Get
        Set(ByVal value As Color)
            Me._OutlineColor = value
            If Me.BorderPen IsNot Nothing Then
                Me.BorderPen.Color = value
            Else
                Me.BorderPen = New Pen(Me._OutlineColor, CSng(Me.m_OutlineWidth))
            End If
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property OutlineWidth() As Integer
        Get
            Return Me.m_OutlineWidth
        End Get
        Set(ByVal value As Integer)
            If value <> Me.m_OutlineWidth Then
                Me.m_OutlineWidth = Math.Max(value, 1)
                Me.BorderPen = New Pen(Me._OutlineColor, CSng(Me.m_OutlineWidth))
                Me.Invalidate()
            End If
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
                Me.RefreshBackground = True
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
                Me.OnValueSelectColor3Changed(EventArgs.Empty)
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property Shape() As Indicator.ShapeTypes
        Get
            Return Me.m_Shape
        End Get
        Set(ByVal value As Indicator.ShapeTypes)
            If value <> Me.m_Shape Then
                Me.m_Shape = value
                Me.RefreshBackground = True
                Me.Invalidate()
            End If
        End Set
    End Property



    Public Sub New()

        Me.TextRect = New Rectangle()
        Me.m_Color1 = Color.DarkGray
        Me.m_Color2 = Color.Green
        Me.m_Color3 = Color.Red
        Me._OutlineColor = Color.Transparent
        Me.m_OutlineWidth = 1
        Me.m_Shape = Indicator.ShapeTypes.Round
        Me.sf = New StringFormat()
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                Me.BrushColor1.Dispose()
                Me.BrushColor2.Dispose()
                Me.BrushColor3.Dispose()
                Me.BorderPen.Dispose()
                Me.TextBrush.Dispose()
                Me.BackgroundBrush.Dispose()
                Me.sf.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)
        If Me.BackgroundBrush IsNot Nothing Then
            Me.BackgroundBrush.Color = Me.BackColor
        Else
            Me.BackgroundBrush = New SolidBrush(Me.BackColor)
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Me.sf.Alignment = StringAlignment.Center
        Me.sf.LineAlignment = StringAlignment.Center
        If Me.DesignMode Then
            If (Me.Parent.BackColor = Color.Black) And (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Then
                Me.ForeColor = Color.WhiteSmoke
            End If
        End If
        If Me.TextBrush Is Nothing Then
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        End If
        If Me.BorderPen Is Nothing Then
            Me.BorderPen = New Pen(Me._OutlineColor)
        End If
        If Me.BrushColor1 Is Nothing Then
            Me.BrushColor1 = New SolidBrush(Me.Color1)
        End If
        If Me.BrushColor2 Is Nothing Then
            Me.BrushColor2 = New SolidBrush(Me.Color2)
        End If
        If Me.BrushColor3 Is Nothing Then
            Me.BrushColor3 = New SolidBrush(Me.Color3)
        End If
        If Me.BackgroundBrush Is Nothing Then
            Me.BackgroundBrush = New SolidBrush(Me.BackColor)
        End If
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)
        If Me.TextBrush IsNot Nothing Then
            Me.TextBrush.Color = MyBase.ForeColor
        Else
            Me.TextBrush = New SolidBrush(MyBase.ForeColor)
        End If
        If Me.BorderPen IsNot Nothing Then
            Me.BorderPen.Color = Me._OutlineColor
        Else
            Me.BorderPen = New Pen(Me._OutlineColor, CSng(Me.m_OutlineWidth))
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not (Me.TextBrush Is Nothing Or Me.BorderPen Is Nothing Or Me.BrushColor1 Is Nothing Or Me.BrushColor2 Is Nothing Or Me.BrushColor3 Is Nothing Or Me.BackgroundBrush Is Nothing) Then
            Dim bitmap As New Bitmap(Me.Width, Me.Height)
            Dim graphic As Graphics = Graphics.FromImage(bitmap)
            graphic.FillRectangle(Me.BackgroundBrush, 0, 0, Me.Width, Me.Height)
            If Me.m_Shape <> Indicator.ShapeTypes.Round Then
                If Me.m_SelectColor2 Then
                    graphic.FillRectangle(Me.BrushColor2, 0, 0, Me.Width, Me.Height)
                ElseIf Not Me.m_SelectColor3 Then
                    graphic.FillRectangle(Me.BrushColor1, 0, 0, Me.Width, Me.Height)
                Else
                    graphic.FillRectangle(Me.BrushColor3, 0, 0, Me.Width, Me.Height)
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawRectangle(this.BorderPen, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                graphic.DrawRectangle(Me.BorderPen, 0, 0, Me.Width - 1, Me.Height - 1)
            Else
                If Me.m_SelectColor2 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.FillEllipse(this.BrushColor2, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                    graphic.FillEllipse(Me.BrushColor2, 0, 0, Me.Width - 1, Me.Height - 1)
                ElseIf Not Me.m_SelectColor3 Then
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.FillEllipse(this.BrushColor1, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                    graphic.FillEllipse(Me.BrushColor1, 0, 0, Me.Width - 1, Me.Height - 1)
                Else
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: graphic.FillEllipse(this.BrushColor3, 0, 0, checked(this.Width - 1), checked(this.Height - 1));
                    graphic.FillEllipse(Me.BrushColor3, 0, 0, Me.Width - 1, Me.Height - 1)
                End If
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: graphic.DrawEllipse(this.BorderPen, checked((int)Math.Round(Math.Floor((double)this.m_OutlineWidth / 2))), checked((int)Math.Round(Math.Floor((double)this.m_OutlineWidth / 2))), checked(this.Width - this.m_OutlineWidth), checked(this.Height - this.m_OutlineWidth));
                graphic.DrawEllipse(Me.BorderPen, CInt(Math.Truncate(Math.Round(Math.Floor(CDbl(Me.m_OutlineWidth) / 2)))), CInt(Math.Truncate(Math.Round(Math.Floor(CDbl(Me.m_OutlineWidth) / 2)))), Me.Width - Me.m_OutlineWidth, Me.Height - Me.m_OutlineWidth)
            End If
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If Me.TextBrush.Color <> MyBase.ForeColor Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, CSng(CDbl(Me.Width) / 2), CSng(CDbl(Me.Height) / 2), Me.sf)
            End If
            e.Graphics.DrawImage(bitmap, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        If Me.RefreshBackground Then
            MyBase.OnPaintBackground(e)
        End If
        Me.RefreshBackground = False
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overridable Sub OnValueSelectColor1Changed(ByVal e As EventArgs)
        RaiseEvent ValueSelectColor1Changed(Me, e)
    End Sub

    Protected Overridable Sub OnValueSelectColor3Changed(ByVal e As EventArgs)
        RaiseEvent ValueSelectColor3Changed(Me, e)
    End Sub

    Public Event ValueSelectColor1Changed As EventHandler

    Public Event ValueSelectColor3Changed As EventHandler

    Public Enum ShapeTypes
        Round
        Rectangle
    End Enum
End Class

