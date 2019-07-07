


Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms


Public Class Keypad
    Inherits Form
    Implements IKeyboard

    Private StaticImage As Bitmap

    Private KeyImage As Bitmap

    Private KeyUpImage As Bitmap

    Private KeyDownImage As Bitmap

    Private KeyImages As Bitmap()

    Private ClearKeyImage As Bitmap

    Private QuitKeyImage As Bitmap

    Private EnterKeyImage As Bitmap

    Private WideKeyImage As Bitmap

    Private WideKeyUpImage As Bitmap

    Private WideKeyDownImage As Bitmap

    Private KeyFont As Font

    Private TextRectangle As Rectangle

    Private KeyTextRect As Rectangle

    Private KeyTextColor As SolidBrush

    Private ValueTextColor As SolidBrush

    Private sf As StringFormat

    Private sfRight As StringFormat

    Private ImageRatio As Decimal

    Private _chr As Char

    Private m_AllowDecimal As Boolean

    Private m_AllowNegative As Boolean

    Private m_Value As String

    Private m_MaxValue As Decimal

    Private m_MinValue As Decimal

    Private _backBuffer As Bitmap

    Private TextBrush As SolidBrush


    Private tmrError As Timer

    Private ImageIndex As Integer

    Public Property AllowDecimal As Boolean
        Get
            Return Me.m_AllowDecimal
        End Get
        Set(ByVal value As Boolean)
            Me.m_AllowDecimal = value
            Me.Invalidate()
        End Set
    End Property

    Public Property AllowNegative As Boolean
        Get
            Return Me.m_AllowNegative
        End Get
        Set(ByVal value As Boolean)
            Me.m_AllowNegative = value
            Me.Invalidate()
        End Set
    End Property

    Public Overrides Property Font As Font Implements IKeyboard.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
        End Set
    End Property

    Public Overrides Property ForeColor As Color Implements IKeyboard.ForeColor
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            MyBase.ForeColor = value
        End Set
    End Property

    Public Shadows Property Location As Point Implements IKeyboard.Location
        Get
            Return MyBase.Location
        End Get
        Set(ByVal value As Point)
            MyBase.Location = value
        End Set
    End Property

    Public Property MaxValue As Decimal
        Get
            Return Me.m_MaxValue
        End Get
        Set(ByVal value As Decimal)
            Me.m_MaxValue = value
        End Set
    End Property

    Public Property MinValue As Decimal
        Get
            Return Me.m_MinValue
        End Get
        Set(ByVal value As Decimal)
            Me.m_MinValue = value
        End Set
    End Property

    Public Shadows Property StartPosition As Object Implements IKeyboard.StartPosition
        Get
            Return MyBase.StartPosition
        End Get
        Set(ByVal value As Object)
            MyBase.StartPosition = DirectCast(Conversions.ToInteger(value), FormStartPosition)
        End Set
    End Property

    Public Overrides Property Text As String Implements IKeyboard.Text
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            Me.Invalidate()
        End Set
    End Property



    Public Shadows Property TopMost As Boolean Implements IKeyboard.TopMost
        Get
            Return MyBase.TopMost
        End Get
        Set(ByVal value As Boolean)
            MyBase.TopMost = value
        End Set
    End Property

    Public Property Value As String Implements IKeyboard.Value
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As String)
            Me.m_Value = value
        End Set
    End Property

    Public Shadows Property Visible As Boolean Implements IKeyboard.Visible
        Get
            Return MyBase.Visible
        End Get
        Set(ByVal value As Boolean)
            MyBase.Visible = value
        End Set
    End Property


    Public Sub New()
        MyBase.New()

        ReDim Me.KeyImages(11)
        Me.TextRectangle = New Rectangle()
        Me.KeyTextColor = New SolidBrush(Color.FromArgb(245, 226, 224, 220))
        Me.ValueTextColor = New SolidBrush(Color.FromArgb(245, 40, 45, 50))
        Me.m_AllowDecimal = True
        Me.m_AllowNegative = True
        Me.m_Value = String.Empty
        Me.m_MaxValue = New Decimal()
        Me.m_MinValue = New Decimal()
        Me.tmrError = New Timer()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.TransparencyKey = Color.Transparent
        Me.RefreshImage()
    End Sub

    Public Sub New(ByVal Width As Integer)
        MyBase.New()

        ReDim Me.KeyImages(11)
        Me.TextRectangle = New Rectangle()
        Me.KeyTextColor = New SolidBrush(Color.FromArgb(245, 226, 224, 220))
        Me.ValueTextColor = New SolidBrush(Color.FromArgb(245, 40, 45, 50))
        Me.m_AllowDecimal = True
        Me.m_AllowNegative = True
        Me.m_Value = String.Empty
        Me.m_MaxValue = New Decimal()
        Me.m_MinValue = New Decimal()
        Me.tmrError = New Timer()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.TransparencyKey = Color.Transparent
        Me.Width = Width
        Me.Height = Convert.ToInt32(My.Resources.KeypadBlack.Height * My.Resources.KeypadBlack.Width * Me.Width)
        Me.RefreshImage()
    End Sub



    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.TransparencyKey = Color.White
        Me.BackgroundImage = My.Resources.KeypadBlack
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.ClientSize = New Size(284, 262)
        Me.DoubleBuffered = True
        Me.Name = "Keypad"
        Me.ResumeLayout(False)
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        If (e.KeyChar >= "0"c And e.KeyChar <= "9"c Or e.KeyChar >= "A"c And e.KeyChar <= "Z"c Or e.KeyChar >= "a"c And e.KeyChar <= "z"c Or e.KeyChar = Strings.ChrW(32) Or Operators.CompareString(Conversions.ToString(e.KeyChar), CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, False) = 0) Then
            Me.Value = String.Concat(Me.Value, Conversions.ToString(e.KeyChar))
        End If
        If (e.KeyChar = Convert.ToChar(13) Or e.KeyChar = Convert.ToChar(10)) Then
            Me.DialogResult = DialogResult.OK
            RaiseEvent ButtonClick(Me, New KeyPadEventArgs("Enter"))
        End If
        If (e.KeyChar = Convert.ToChar(27)) Then
            RaiseEvent ButtonClick(Me, New KeyPadEventArgs("Quit"))
            Me.DialogResult = DialogResult.Cancel
        End If
        If (e.KeyChar = "-"c) Then
            If (Me.m_AllowNegative) Then
                If (If(Me.Value.Length <= 0 OrElse Operators.CompareString(Me.Value.Substring(0, 1), "-", False) <> 0, True, False)) Then
                    Me.Value = String.Concat("-", Me.Value)
                Else
                    Me.Value = Me.Value.Substring(1)
                End If
            End If
        End If
        If (e.KeyChar = Convert.ToChar(8)) Then
            Me.Value = String.Empty
            RaiseEvent ButtonClick(Me, New KeyPadEventArgs("Clear"))
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Dim location As System.Drawing.Point = e.Location
        Dim num As Integer = CInt(Math.Round(Math.Floor((CDbl(location.X) / CDbl(Me.StaticImage.Width) - 0.13) / 0.17)))
        location = e.Location
        Dim num1 As Integer = CInt(Math.Round(Math.Floor((CDbl(location.Y) / CDbl(Me.StaticImage.Height) - 0.3) / 0.15)))
        Me.ImageIndex = num1 * 3 + num
        If (e.Location.X - Convert.ToInt32(CDbl(Me.StaticImage.Width) * (CDbl(num) * 0.17 + 0.13)) < Me.KeyUpImage.Width And e.Location.Y - Convert.ToInt32(CDbl(Me.StaticImage.Height) * (0.15 * CDbl(num1) + 0.3)) < Me.KeyUpImage.Height And e.Location.X < Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.6) And Me.ImageIndex >= 0 And Me.ImageIndex < 12) Then
            Me.KeyImages(Me.ImageIndex) = Me.KeyDownImage
            If (Me.Value.Length < 17) Then
                If (Me.ImageIndex < 9) Then
                    Me.Value = String.Concat(Me.Value, Conversions.ToString(Me.ImageIndex + 1))
                    RaiseEvent ButtonClick(Me, New KeyPadEventArgs(Conversions.ToString(Me.ImageIndex + 1)))
                ElseIf (Me.ImageIndex = 9) Then
                    If (Me.Value.IndexOf(".") < 0 And Me.m_AllowDecimal) Then
                        Me.Value = String.Concat(Me.Value, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    End If
                    RaiseEvent ButtonClick(Me, New KeyPadEventArgs("."))
                ElseIf (Me.ImageIndex = 10) Then
                    Me.Value = String.Concat(Me.Value, "0")
                    RaiseEvent ButtonClick(Me, New KeyPadEventArgs("0"))
                ElseIf (Me.ImageIndex = 11) Then
                    If (Me.m_AllowNegative) Then
                        If (If(Me.Value.Length <= 0 OrElse Operators.CompareString(Me.Value.Substring(0, 1), "-", False) <> 0, True, False)) Then
                            Me.Value = String.Concat("-", Me.Value)
                        Else
                            Me.Value = Me.Value.Substring(1)
                        End If
                        RaiseEvent ButtonClick(Me, New KeyPadEventArgs("-"))
                    End If
                End If
            End If
        End If
        Dim point As System.Drawing.Point = e.Location
        Dim location1 As System.Drawing.Point = e.Location
        Dim x As Boolean = CDbl(point.X) > CDbl(Me.StaticImage.Width) * 0.68 And CDbl(location1.X) < CDbl(Me.StaticImage.Width) * 0.68 + CDbl(Me.WideKeyUpImage.Width)
        location = e.Location
        Dim point1 As System.Drawing.Point = e.Location
        If (x And CDbl(location.Y) > CDbl(Me.StaticImage.Height) * 0.3 And CDbl(point1.Y) < CDbl(Me.StaticImage.Height) * 0.4) Then
            Me.ClearKeyImage = Me.WideKeyDownImage
            Me.Value = String.Empty
            RaiseEvent ButtonClick(Me, New KeyPadEventArgs("Clear"))
        End If
        point1 = e.Location
        point = e.Location
        Dim flag As Boolean = CDbl(point1.X) > CDbl(Me.StaticImage.Width) * 0.68 And CDbl(point.X) < CDbl(Me.StaticImage.Width) * 0.68 + CDbl(Me.WideKeyUpImage.Width)
        location1 = e.Location
        location = e.Location
        If (flag And CDbl(location1.Y) > CDbl(Me.StaticImage.Height) * 0.45 And CDbl(location.Y) < CDbl(Me.StaticImage.Height) * 0.45 + CDbl(Me.WideKeyUpImage.Height)) Then
            Me.QuitKeyImage = Me.WideKeyDownImage
            RaiseEvent ButtonClick(Me, New KeyPadEventArgs("Quit"))
            Me.DialogResult = DialogResult.Cancel
        End If
        point1 = e.Location
        point = e.Location
        Dim x1 As Boolean = CDbl(point1.X) > CDbl(Me.StaticImage.Width) * 0.68 And CDbl(point.X) < CDbl(Me.StaticImage.Width) * 0.68 + CDbl(Me.WideKeyUpImage.Width)
        location1 = e.Location
        location = e.Location
        If (x1 And CDbl(location1.Y) > CDbl(Me.StaticImage.Height) * 0.75 And CDbl(location.Y) < CDbl(Me.StaticImage.Height) * 0.75 + CDbl(Me.WideKeyUpImage.Height)) Then
            Me.EnterKeyImage = Me.WideKeyDownImage
            If (Decimal.Compare(Me.m_MinValue, Me.m_MaxValue) <> 0) Then
                If (Conversions.ToDouble(Me.Value) < Convert.ToDouble(Me.m_MaxValue) Or Conversions.ToDouble(Me.Value) > Convert.ToDouble(Me.m_MaxValue)) Then
                    MessageBox.Show(String.Concat("Value must be >", Conversions.ToString(Me.m_MinValue), " and <", Conversions.ToString(Me.m_MaxValue)))
                    Return
                End If
            End If
            RaiseEvent ButtonClick(Me, New KeyPadEventArgs("Enter"))
            Me.DialogResult = DialogResult.OK
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If (Me.ImageIndex >= 0 And Me.ImageIndex <= 11) Then
            Me.KeyImages(Me.ImageIndex) = Me.KeyUpImage
        End If
        Me.ClearKeyImage = Me.WideKeyUpImage
        Me.QuitKeyImage = Me.WideKeyUpImage
        Me.EnterKeyImage = Me.WideKeyUpImage
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim rectangle As System.Drawing.Rectangle
        If (Not (Me.StaticImage Is Nothing Or Me._backBuffer Is Nothing Or Me.TextBrush Is Nothing)) Then
            Dim graphic As Graphics = Graphics.FromImage(Me._backBuffer)
            graphic.DrawImage(Me.StaticImage, 0, 0)
            Dim str As String = String.Empty
            Dim num As Integer = 0
            Do
                Dim num1 As Integer = 0
                Do
                    graphic.DrawImage(Me.KeyImages(num * 3 + num1), Convert.ToInt32(CDbl(Me.StaticImage.Width) * (CDbl(num1) * 0.17 + 0.13)), Convert.ToInt32(CDbl(Me.StaticImage.Height) * (0.15 * CDbl(num) + 0.3)))
                    If (num * 3 + num1 < 9) Then
                        str = Conversions.ToString(num * 3 + num1 + 1)
                    ElseIf (num * 3 + num1 = 10) Then
                        str = "0"
                    ElseIf (Not (Me.m_AllowDecimal And num * 3 + num1 = 9)) Then
                        str = If(Not (Me.m_AllowNegative And num * 3 + num1 = 11), String.Empty, "±")
                    Else
                        str = "."
                    End If
                    If (If(str Is Nothing OrElse String.Compare(str, String.Empty) = 0, False, True)) Then
                        Dim keyFont As System.Drawing.Font = Me.KeyFont
                        Dim keyTextColor As System.Drawing.SolidBrush = Me.KeyTextColor
                        rectangle = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(Me.StaticImage.Width) * (CDbl(num1) * 0.17 + 0.13)), Convert.ToInt32(CDbl(Me.StaticImage.Height) * (0.15 * CDbl(num) + 0.3)), Me.KeyUpImage.Width, Me.KeyUpImage.Height)
                        graphic.DrawString(str, keyFont, keyTextColor, rectangle, Me.sf)
                    End If
                    num1 = num1 + 1
                Loop While num1 <= 2
                num = num + 1
            Loop While num <= 3
            graphic.DrawImage(Me.ClearKeyImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.68), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.3))
            Dim font As System.Drawing.Font = Me.KeyFont
            Dim solidBrush As System.Drawing.SolidBrush = Me.KeyTextColor
            rectangle = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.68), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.3), Me.WideKeyUpImage.Width, Me.WideKeyUpImage.Height)
            graphic.DrawString("Clear", font, solidBrush, rectangle, Me.sf)
            graphic.DrawImage(Me.QuitKeyImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.68), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.45))
            Dim keyFont1 As System.Drawing.Font = Me.KeyFont
            Dim keyTextColor1 As System.Drawing.SolidBrush = Me.KeyTextColor
            rectangle = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.68), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.45), Me.WideKeyUpImage.Width, Me.WideKeyUpImage.Height)
            graphic.DrawString("Quit", keyFont1, keyTextColor1, rectangle, Me.sf)
            graphic.DrawImage(Me.EnterKeyImage, Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.68), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.75))
            Dim font1 As System.Drawing.Font = Me.KeyFont
            Dim solidBrush1 As System.Drawing.SolidBrush = Me.KeyTextColor
            rectangle = New System.Drawing.Rectangle(Convert.ToInt32(CDbl(Me.StaticImage.Width) * 0.68), Convert.ToInt32(CDbl(Me.StaticImage.Height) * 0.75), Me.WideKeyUpImage.Width, Me.WideKeyUpImage.Height)
            graphic.DrawString("Enter", font1, solidBrush1, rectangle, Me.sf)
            If (If(MyBase.Text Is Nothing OrElse String.Compare(MyBase.Text, String.Empty) = 0, False, True)) Then
                If (Me.TextBrush.Color <> MyBase.ForeColor) Then
                    Me.TextBrush.Color = MyBase.ForeColor
                End If
                graphic.DrawString(MyBase.Text, MyBase.Font, Me.TextBrush, Me.TextRectangle, Me.sf)
            End If
            Dim value As String = Me.Value
            Dim keyFont2 As System.Drawing.Font = Me.KeyFont
            Dim valueTextColor As System.Drawing.SolidBrush = Me.ValueTextColor
            rectangle = New System.Drawing.Rectangle(Convert.ToInt32(Decimal.Multiply(Me.ImageRatio, New Decimal(CLng(72)))), Convert.ToInt32(Decimal.Multiply(Me.ImageRatio, New Decimal(CLng(98)))), Convert.ToInt32(Decimal.Multiply(Me.ImageRatio, New Decimal(CLng(515)))), Convert.ToInt32(Decimal.Multiply(Me.ImageRatio, New Decimal(CLng(90)))))
            graphic.DrawString(value, keyFont2, valueTextColor, rectangle, Me.sfRight)
            e.Graphics.DrawImage(Me._backBuffer, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Private Sub RefreshImage()
        Dim num As Decimal = New Decimal(CSng(Me.Width) / CSng(My.Resources.KeypadBlack.Width))
        Dim num1 As Decimal = New Decimal(CSng(Me.Height) / CSng(My.Resources.KeypadBlack.Height))
        If (Decimal.Compare(num, num1) >= 0) Then
            Me.ImageRatio = num1
        Else
            Me.ImageRatio = num
        End If
        If (Decimal.Compare(Me.ImageRatio, Decimal.Zero) > 0) Then
            If (Me.StaticImage IsNot Nothing) Then
                Me.StaticImage.Dispose()
            End If
            Me.StaticImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeypadBlack.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeypadBlack.Height), Me.ImageRatio)))
            Me.Width = Me.StaticImage.Width
            Me.Height = Me.StaticImage.Height
            Dim graphic As Graphics = Graphics.FromImage(Me.StaticImage)
            graphic.DrawImage(My.Resources.KeypadBlack, 0.0!, 0.0!, Convert.ToSingle(Decimal.Add(Decimal.Multiply(New Decimal(My.Resources.KeypadBlack.Width), Me.ImageRatio), Decimal.One)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeypadBlack.Height), Me.ImageRatio)))
            Me.BackgroundImage = Me.StaticImage
            Me.TextRectangle.X = CInt(Math.Round(CDbl(Me.Width) * 0.05))
            Me.TextRectangle.Width = CInt(Math.Round(CDbl(Me.StaticImage.Width) * 0.95))
            Me.TextRectangle.Y = 0
            Me.TextRectangle.Height = CInt(Math.Round(CDbl(Me.StaticImage.Height) * 0.12))
            If (Me.sf Is Nothing) Then
                Me.sf = New StringFormat()
            End If
            Me.sf.Alignment = StringAlignment.Center
            Me.sf.LineAlignment = StringAlignment.Center
            If (Me.TextBrush Is Nothing) Then
                Me.TextBrush = New SolidBrush(Color.FromArgb(255, 190, 180, 180))
            End If
            If (Me.sfRight IsNot Nothing) Then
                Me.sfRight.Dispose()
            End If
            Me.sfRight = New StringFormat() With
            {
                .Alignment = StringAlignment.Far,
                .LineAlignment = StringAlignment.Center
            }
            Me.KeyUpImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeyPadKey.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeyPadKey.Height), Me.ImageRatio)))
            Me.KeyDownImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeyPadKey.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeyPadKey.Height), Me.ImageRatio)))
            graphic = Graphics.FromImage(Me.KeyUpImage)
            Dim graphic1 As Graphics = Graphics.FromImage(Me.KeyDownImage)
            graphic.DrawImage(My.Resources.KeyPadKey, 0.0!, 0.0!, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeyPadKey.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeyPadKey.Height), Me.ImageRatio)))
            graphic1.DrawImage(My.Resources.KeyPadKeyDown, 0.0!, 0.0!, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeyPadKey.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeyPadKey.Height), Me.ImageRatio)))
            Me.KeyImage = Me.KeyUpImage
            Dim num2 As Integer = 0
            Do
                Me.KeyImages(num2) = Me.KeyImage
                num2 = num2 + 1
            Loop While num2 <= 11
            graphic.Dispose()
            graphic1.Dispose()
            Me.WideKeyUpImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeypadKeyWide.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeypadKeyWide.Height), Me.ImageRatio)))
            Me.WideKeyDownImage = New Bitmap(Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeypadKeyWideDown.Width), Me.ImageRatio)), Convert.ToInt32(Decimal.Multiply(New Decimal(My.Resources.KeypadKeyWideDown.Height), Me.ImageRatio)))
            graphic = Graphics.FromImage(Me.WideKeyUpImage)
            graphic1 = Graphics.FromImage(Me.WideKeyDownImage)
            graphic.DrawImage(My.Resources.KeypadKeyWide, 0.0!, 0.0!, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeypadKeyWide.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeypadKeyWide.Height), Me.ImageRatio)))
            graphic1.DrawImage(My.Resources.KeypadKeyWideDown, 0.0!, 0.0!, Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeypadKeyWideDown.Width), Me.ImageRatio)), Convert.ToSingle(Decimal.Multiply(New Decimal(My.Resources.KeypadKeyWideDown.Height), Me.ImageRatio)))
            Me.ClearKeyImage = Me.WideKeyUpImage
            Me.QuitKeyImage = Me.WideKeyUpImage
            Me.EnterKeyImage = Me.WideKeyUpImage
            graphic.Dispose()
            graphic1.Dispose()
            If (Me.KeyFont IsNot Nothing) Then
                Me.KeyFont.Dispose()
            End If
            Me.KeyFont = New Font("Arial", Convert.ToSingle(Decimal.Multiply(New Decimal(CLng(38)), Me.ImageRatio)), FontStyle.Bold, GraphicsUnit.Point)
            Me.KeyTextRect = New Rectangle(0, 0, Me.KeyUpImage.Width, Me.KeyUpImage.Height)
            If (Me._backBuffer IsNot Nothing) Then
                Me._backBuffer.Dispose()
            End If
            Me._backBuffer = New Bitmap(Me.Width, Me.Height)
            Me.Invalidate()
        End If
    End Sub

    Public Event ButtonClick As IKeyboard.ButtonClickEventHandler Implements IKeyboard.ButtonClick

    Public Event QuitClick As Keypad.QuitClickEventHandler

    Public Delegate Sub QuitClickEventHandler(ByVal sender As Object, ByVal e As EventArgs)
End Class

