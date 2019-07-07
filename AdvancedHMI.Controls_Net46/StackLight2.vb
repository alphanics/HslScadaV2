Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

<DefaultEvent("")>
Public Class StackLight2
    Inherits Control
    Private bitmap_0 As Bitmap

    Private bitmap_1 As Bitmap

    Private bitmap_2 As Bitmap()

    Private bitmap_3 As Bitmap

    Private bitmap_4 As Bitmap

    Private bitmap_5 As Bitmap

    Private bitmap_6 As Bitmap

    Private float_0 As Single

    Private rectangle_0 As Rectangle

    Private stringFormat_0 As StringFormat

    Private solidBrush_0 As SolidBrush

    Private bool_0 As Boolean

    Private bool_1 As Boolean

    Private bool_2 As Boolean

    Private bool_3 As Boolean

    Private bool_4 As Boolean

    Private bool_5 As Boolean

    Private bool_6 As Boolean

    Private bool_7 As Boolean

    Private int_0 As Integer

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Font As System.Drawing.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As System.Drawing.Font)
            MyBase.Font = value
            MyBase.Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            If (Me.solidBrush_0 IsNot Nothing) Then
                Me.solidBrush_0.Color = value
            Else
                Me.solidBrush_0 = New SolidBrush(MyBase.ForeColor)
            End If
            MyBase.ForeColor = value
            MyBase.Invalidate()
        End Set
    End Property

    Public Property LightAmberEnable As Boolean
        Get
            Return Me.bool_3
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_3) Then
                Me.bool_3 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property LightAmberValue As Boolean
        Get
            Return Me.bool_2
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_2) Then
                Me.bool_2 = value
                If (Not Me.bool_2) Then
                    Me.bitmap_4 = Me.bitmap_2(2)
                Else
                    Me.bitmap_4 = Me.bitmap_2(3)
                End If
                MyBase.Invalidate()
                Me.OnLightAmberValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property LightBlueEnable As Boolean
        Get
            Return Me.bool_5
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_5) Then
                Me.bool_5 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property LightBlueValue As Boolean
        Get
            Return Me.bool_4
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_4) Then
                Me.bool_4 = value
                If (Not Me.bool_4) Then
                    Me.bitmap_5 = Me.bitmap_2(4)
                Else
                    Me.bitmap_5 = Me.bitmap_2(5)
                End If
                MyBase.Invalidate()
                Me.OnLightBlueValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property LightGreenEnable As Boolean
        Get
            Return Me.bool_1
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_1) Then
                Me.bool_1 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property LightGreenValue As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_0) Then
                Me.bool_0 = value
                If (Not Me.bool_0) Then
                    Me.bitmap_3 = Me.bitmap_2(0)
                Else
                    Me.bitmap_3 = Me.bitmap_2(1)
                End If
                MyBase.Invalidate()
                Me.OnLightGreenValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property LightRedEnable As Boolean
        Get
            Return Me.bool_7
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_7) Then
                Me.bool_7 = value
                Me.method_0()
            End If
        End Set
    End Property

    Public Property LightRedValue As Boolean
        Get
            Return Me.bool_6
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_6) Then
                Me.bool_6 = value
                If (Not Me.bool_6) Then
                    Me.bitmap_6 = Me.bitmap_2(6)
                Else
                    Me.bitmap_6 = Me.bitmap_2(7)
                End If
                MyBase.Invalidate()
                Me.OnLightRedValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            MyBase.Invalidate()
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        ReDim Me.bitmap_2(7)
        Me.bool_1 = True
        Me.bool_3 = True
        Me.bool_5 = True
        Me.bool_7 = True
        Me.int_0 = 4
        MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.ForeColor = Color.White
        Me.solidBrush_0 = New SolidBrush(MyBase.ForeColor)
        Me.stringFormat_0 = New StringFormat() With
        {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
        }
        Me.method_1()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                Me.solidBrush_0.Dispose()
                Me.stringFormat_0.Dispose()
                If (Me.bitmap_1 IsNot Nothing) Then
                    Me.bitmap_1.Dispose()
                End If
                If (Me.bitmap_0 IsNot Nothing) Then
                    Me.bitmap_0.Dispose()
                End If
                Dim length As Integer = CInt(Me.bitmap_2.Length) - 1
                For i As Integer = 0 To length Step 1
                    If (Me.bitmap_2(i) IsNot Nothing) Then
                        Me.bitmap_2(i).Dispose()
                    End If
                Next

            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub method_0()

    End Sub

    Private Sub method_1()
        Dim height As Single = 0!
        Try
            Dim width As Single = CSng(MyBase.Width) / CSng(My.Resources.StackLightBase.Width)
            height = CSng((My.Resources.StackLightBase.Height + My.Resources.StackLightCap.Height))
            height += CSng((My.Resources.StackLightElementGray.Height * Me.int_0))
            Dim [single] As Single = CSng(MyBase.Height) / CSng(height)
            If (width >= [single]) Then
                Me.float_0 = [single]
            Else
                Me.float_0 = width
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            ProjectData.ClearProjectError()
        End Try
        If (Me.float_0 > 0!) Then
            If (Me.bitmap_0 IsNot Nothing) Then
                Me.bitmap_0.Dispose()
            End If
            Me.bitmap_0 = New Bitmap(Convert.ToInt32(CSng(My.Resources.StackLightBase.Width) * Me.float_0), Convert.ToInt32(CSng(My.Resources.StackLightBase.Height) * Me.float_0))
            Using graphic As Graphics = Graphics.FromImage(Me.bitmap_0)
                graphic.DrawImage(My.Resources.StackLightBase, 0, 0, Me.bitmap_0.Width, Convert.ToInt32(CDbl(Me.bitmap_0.Width) / CDbl(My.Resources.StackLightBase.Width) * CDbl(My.Resources.StackLightBase.Height)))
                Me.rectangle_0.X = 1
                Me.rectangle_0.Width = Me.bitmap_0.Width - 2
                Me.rectangle_0.Y = Convert.ToInt32(CDbl(height) * 0.82 * CDbl(Me.float_0))
                Me.rectangle_0.Height = Convert.ToInt32(CDbl(height) * 0.16 * CDbl(Me.float_0))
            End Using
            If (Me.bitmap_1 IsNot Nothing) Then
                Me.bitmap_1.Dispose()
            End If
            Me.bitmap_1 = New Bitmap(Convert.ToInt32(CSng(My.Resources.StackLightCap.Width) * Me.float_0), Convert.ToInt32(CSng(My.Resources.StackLightCap.Height) * Me.float_0))
            Using graphic1 As Graphics = Graphics.FromImage(Me.bitmap_1)
                graphic1.DrawImage(My.Resources.StackLightCap, 0, 0, Me.bitmap_0.Width, Convert.ToInt32(CDbl(Me.bitmap_0.Width) / CDbl(My.Resources.StackLightBase.Width) * CDbl(My.Resources.StackLightCap.Height)))
            End Using
            Dim length As Integer = CInt(Me.bitmap_2.Length) - 1
            Dim num As Integer = 0
            Do
                Me.bitmap_2(num) = New Bitmap(Me.bitmap_0.Width, Convert.ToInt32(CSng(My.Resources.StackLightElementGray.Height) * Me.float_0))
                num = num + 1
            Loop While num <= length
            Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, Me.bitmap_2(0).Width, Me.bitmap_2(0).Height)
            Using imageAttribute As ImageAttributes = New ImageAttributes()
                Try
                    imageAttribute.SetColorMatrix(New ColorMatrix(New Single()() {New Single() {0.25!, Nothing, Nothing, Nothing, Nothing}, New Single() {Nothing, 0.5!, Nothing, Nothing, Nothing}, New Single() {Nothing, Nothing, 0.25!, Nothing, Nothing}, New Single() {Nothing, Nothing, Nothing, 1!, Nothing}, New Single() {Nothing, Nothing, Nothing, Nothing, 1!}}))
                    Using graphic2 As Graphics = Graphics.FromImage(Me.bitmap_2(0))
                        graphic2.DrawImage(My.Resources.StackLightElementGray, rectangle, 0, 0, My.Resources.StackLightElementGray.Width, My.Resources.StackLightElementGray.Height, GraphicsUnit.Pixel, imageAttribute)
                    End Using
                    imageAttribute.SetColorMatrix(New ColorMatrix(New Single()() {New Single() {0.25!, Nothing, Nothing, Nothing, Nothing}, New Single() {Nothing, 2.5!, Nothing, Nothing, Nothing}, New Single() {Nothing, Nothing, 0.25!, Nothing, Nothing}, New Single() {Nothing, Nothing, Nothing, 1!, Nothing}, New Single() {Nothing, Nothing, Nothing, Nothing, 1!}}))
                    Using graphic3 As Graphics = Graphics.FromImage(Me.bitmap_2(1))
                        graphic3.DrawImage(My.Resources.StackLightElementGray, rectangle, 0, 0, My.Resources.StackLightElementGray.Width, My.Resources.StackLightElementGray.Height, GraphicsUnit.Pixel, imageAttribute)
                    End Using
                Catch exception1 As System.Exception
                    ProjectData.SetProjectError(exception1)
                    ProjectData.ClearProjectError()
                End Try
                Try
                    imageAttribute.SetColorMatrix(New ColorMatrix(New Single()() {New Single() {0.5!, Nothing, Nothing, Nothing, Nothing}, New Single() {Nothing, 0.5!, Nothing, Nothing, Nothing}, New Single() {Nothing, Nothing, 0.25!, Nothing, Nothing}, New Single() {Nothing, Nothing, Nothing, 1!, Nothing}, New Single() {Nothing, Nothing, Nothing, Nothing, 1!}}))
                    Using graphic4 As Graphics = Graphics.FromImage(Me.bitmap_2(2))
                        graphic4.DrawImage(My.Resources.StackLightElementGray, rectangle, 0, 0, My.Resources.StackLightElementGray.Width, My.Resources.StackLightElementGray.Height, GraphicsUnit.Pixel, imageAttribute)
                    End Using
                    imageAttribute.SetColorMatrix(New ColorMatrix(New Single()() {New Single() {2.5!, Nothing, Nothing, Nothing, Nothing}, New Single() {Nothing, 2.5!, Nothing, Nothing, Nothing}, New Single() {Nothing, Nothing, 0.25!, Nothing, Nothing}, New Single() {Nothing, Nothing, Nothing, 1!, Nothing}, New Single() {Nothing, Nothing, Nothing, Nothing, 1!}}))
                    Using graphic5 As Graphics = Graphics.FromImage(Me.bitmap_2(3))
                        graphic5.DrawImage(My.Resources.StackLightElementGray, rectangle, 0, 0, My.Resources.StackLightElementGray.Width, My.Resources.StackLightElementGray.Height, GraphicsUnit.Pixel, imageAttribute)
                    End Using
                Catch exception2 As System.Exception
                    ProjectData.SetProjectError(exception2)
                    ProjectData.ClearProjectError()
                End Try
                Try
                    imageAttribute.SetColorMatrix(New ColorMatrix(New Single()() {New Single() {0.25!, Nothing, Nothing, Nothing, Nothing}, New Single() {Nothing, 0.25!, Nothing, Nothing, Nothing}, New Single() {Nothing, Nothing, 0.5!, Nothing, Nothing}, New Single() {Nothing, Nothing, Nothing, 1!, Nothing}, New Single() {Nothing, Nothing, Nothing, Nothing, 1!}}))
                    Using graphic6 As Graphics = Graphics.FromImage(Me.bitmap_2(4))
                        graphic6.DrawImage(My.Resources.StackLightElementGray, rectangle, 0, 0, My.Resources.StackLightElementGray.Width, My.Resources.StackLightElementGray.Height, GraphicsUnit.Pixel, imageAttribute)
                    End Using
                    imageAttribute.SetColorMatrix(New ColorMatrix(New Single()() {New Single() {0.25!, Nothing, Nothing, Nothing, Nothing}, New Single() {Nothing, 0.25!, Nothing, Nothing, Nothing}, New Single() {Nothing, Nothing, 2.5!, Nothing, Nothing}, New Single() {Nothing, Nothing, Nothing, 1!, Nothing}, New Single() {Nothing, Nothing, Nothing, Nothing, 1!}}))
                    Using graphic7 As Graphics = Graphics.FromImage(Me.bitmap_2(5))
                        graphic7.DrawImage(My.Resources.StackLightElementGray, rectangle, 0, 0, My.Resources.StackLightElementGray.Width, My.Resources.StackLightElementGray.Height, GraphicsUnit.Pixel, imageAttribute)
                    End Using
                Catch exception3 As System.Exception
                    ProjectData.SetProjectError(exception3)
                    ProjectData.ClearProjectError()
                End Try
                Try
                    imageAttribute.SetColorMatrix(New ColorMatrix(New Single()() {New Single() {0.5!, Nothing, Nothing, Nothing, Nothing}, New Single() {Nothing, 0.25!, Nothing, Nothing, Nothing}, New Single() {Nothing, Nothing, 0.25!, Nothing, Nothing}, New Single() {Nothing, Nothing, Nothing, 1!, Nothing}, New Single() {Nothing, Nothing, Nothing, Nothing, 1!}}))
                    Using graphic8 As Graphics = Graphics.FromImage(Me.bitmap_2(6))
                        graphic8.DrawImage(My.Resources.StackLightElementGray, rectangle, 0, 0, My.Resources.StackLightElementGray.Width, My.Resources.StackLightElementGray.Height, GraphicsUnit.Pixel, imageAttribute)
                    End Using
                    imageAttribute.SetColorMatrix(New ColorMatrix(New Single()() {New Single() {2.5!, Nothing, Nothing, Nothing, Nothing}, New Single() {Nothing, 0.25!, Nothing, Nothing, Nothing}, New Single() {Nothing, Nothing, 0.25!, Nothing, Nothing}, New Single() {Nothing, Nothing, Nothing, 1!, Nothing}, New Single() {Nothing, Nothing, Nothing, Nothing, 1!}}))
                    Using graphic9 As Graphics = Graphics.FromImage(Me.bitmap_2(7))
                        graphic9.DrawImage(My.Resources.StackLightElementGray, rectangle, 0, 0, My.Resources.StackLightElementGray.Width, My.Resources.StackLightElementGray.Height, GraphicsUnit.Pixel, imageAttribute)
                    End Using
                Catch exception4 As System.Exception
                    ProjectData.SetProjectError(exception4)
                    ProjectData.ClearProjectError()
                End Try
            End Using
            Me.method_2()
        End If
    End Sub

    Private Sub method_2()
        If (Not Me.bool_0) Then
            Me.bitmap_3 = Me.bitmap_2(0)
        Else
            Me.bitmap_3 = Me.bitmap_2(1)
        End If
        If (Not Me.bool_2) Then
            Me.bitmap_4 = Me.bitmap_2(2)
        Else
            Me.bitmap_4 = Me.bitmap_2(3)
        End If
        If (Not Me.bool_4) Then
            Me.bitmap_5 = Me.bitmap_2(4)
        Else
            Me.bitmap_5 = Me.bitmap_2(5)
        End If
        If (Not Me.bool_6) Then
            Me.bitmap_6 = Me.bitmap_2(6)
        Else
            Me.bitmap_6 = Me.bitmap_2(7)
        End If
    End Sub

    Protected Overridable Sub OnLightAmberValueChanged(ByVal e As EventArgs)
        RaiseEvent LightAmberValueChanged(Me, e)
    End Sub

    Protected Overridable Sub OnLightBlueValueChanged(ByVal e As EventArgs)
        RaiseEvent LightAmberValueChanged(Me, e)
    End Sub

    Protected Overridable Sub OnLightGreenValueChanged(ByVal e As EventArgs)
        RaiseEvent LightGreenValueChanged(Me, e)
    End Sub

    Protected Overridable Sub OnLightRedValueChanged(ByVal e As EventArgs)
        RaiseEvent LightRedValueChanged(Me, e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        Dim height As Integer = 0
        If (Me.bitmap_0 IsNot Nothing And Me.bitmap_1 IsNot Nothing) Then
            Dim graphics As System.Drawing.Graphics = painte.Graphics
            Try
                If (Me.bool_7) Then
                    graphics.DrawImage(Me.bitmap_6, 0, Convert.ToInt32(Me.bitmap_1.Height + height))
                    height = height + Me.bitmap_6.Height
                End If
                If (Me.bool_5) Then
                    graphics.DrawImage(Me.bitmap_5, 0, Convert.ToInt32(Me.bitmap_1.Height + height))
                    height = height + Me.bitmap_5.Height
                End If
                If (Me.bool_3) Then
                    graphics.DrawImage(Me.bitmap_4, 0, Convert.ToInt32(Me.bitmap_1.Height + height))
                    height = height + Me.bitmap_4.Height
                End If
                If (Me.bool_1) Then
                    graphics.DrawImage(Me.bitmap_3, 0, Convert.ToInt32(Me.bitmap_1.Height + height))
                    height = height + Me.bitmap_3.Height
                End If
                graphics.DrawImage(Me.bitmap_0, 0, Convert.ToInt32(Me.bitmap_1.Height + height))
                graphics.DrawImage(Me.bitmap_1, 0, 0)
                If (Not String.IsNullOrEmpty(MyBase.Text)) Then
                    If (Me.solidBrush_0.Color <> MyBase.ForeColor) Then
                        Me.solidBrush_0.Color = MyBase.ForeColor
                    End If
                    graphics.DrawString(MyBase.Text, MyBase.Font, Me.solidBrush_0, Me.rectangle_0, Me.stringFormat_0)
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                ProjectData.ClearProjectError()
            End Try
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.method_1()
    End Sub

    Public Event LightAmberValueChanged As EventHandler


    Public Event LightGreenValueChanged As EventHandler


    Public Event LightRedValueChanged As EventHandler

End Class
