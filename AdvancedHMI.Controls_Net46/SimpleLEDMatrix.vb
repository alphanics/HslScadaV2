Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class SimpleLEDMatrix
    Inherits Control
    Private ulong_0 As ULong()

    Private char_0 As Char

    Private int_0 As Integer

    Private bool_0 As Boolean

    <Browsable(True)>
    <DefaultValue(0)>
    <Description("Opacity value for inactive dots on the matrix display (valid values 0 to 255).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property DM_Alpha As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                value = 0
            End If
            If (value > 255) Then
                value = 255
            End If
            If (Me.int_0 <> value) Then
                Me.int_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True)>
    <DefaultValue(False)>
    <Description("Show inactive matrix dots.")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property DM_ShowInactiveDots As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            If (Me.bool_0 <> value) Then
                Me.bool_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True)>
    <Description("Constant value used to maintain the ratio between width and height.")>
    <RefreshProperties(RefreshProperties.All)>
    Public ReadOnly Property SizeScaleCoefficient As Single
        Get
            Return 1.76296294!
        End Get
    End Property

    <Browsable(True)>
    <DefaultValue("0"C)>
    <Description("ASCII character to show on the matrix display (any standard US keyboard character is valid).")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Value As Char
        Get
            Return Me.char_0
        End Get
        Set(ByVal value As Char)
            If (Me.char_0 <> value) Then
                Me.char_0 = value
                MyBase.Invalidate()

                RaiseEvent ValueChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        AddHandler MyBase.Click, New EventHandler(AddressOf Me.SimpleLEDMatrix_Click)
        AddHandler MyBase.Resize, New EventHandler(AddressOf Me.SimpleLEDMatrix_Resize)
        ReDim Me.ulong_0(127)
        Me.char_0 = "0"C
        MyBase.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.Transparent
        MyBase.Size = New System.Drawing.Size(32, 56)
        Me.MinimumSize = New System.Drawing.Size(24, 42)
        Me.MaximumSize = New System.Drawing.Size(300, 529)
        Me.ulong_0(32) = Convert.ToUInt64("0000000000000000000000000000000000000000", 2)
        Me.ulong_0(33) = Convert.ToUInt64("0000000100000000010000100001000010000100", 2)
        Me.ulong_0(34) = Convert.ToUInt64("0000000000000000000000000010011001010010", 2)
        Me.ulong_0(35) = Convert.ToUInt64("0000000000010101111101010010101111101010", 2)
        Me.ulong_0(36) = Convert.ToUInt64("0000000100011111010001110001011111000100", 2)
        Me.ulong_0(37) = Convert.ToUInt64("0000011000110010001000100010001001100011", 2)
        Me.ulong_0(38) = Convert.ToUInt64("0000010110010011010100010001010010100010", 2)
        Me.ulong_0(39) = Convert.ToUInt64("0000000000000000000000000000100010000100", 2)
        Me.ulong_0(40) = Convert.ToUInt64("0000001000001000010000100001000010001000", 2)
        Me.ulong_0(41) = Convert.ToUInt64("0000000010001000010000100001000010000010", 2)
        Me.ulong_0(42) = Convert.ToUInt64("0000000000000001000101010011101010100100", 2)
        Me.ulong_0(43) = Convert.ToUInt64("0000000000000000010001110001000000000000", 2)
        Me.ulong_0(44) = Convert.ToUInt64("0001000100001000000000000000000000000000", 2)
        Me.ulong_0(45) = Convert.ToUInt64("0000000000000000000001110000000000000000", 2)
        Me.ulong_0(46) = Convert.ToUInt64("0000000100000000000000000000000000000000", 2)
        Me.ulong_0(47) = Convert.ToUInt64("0000000000000010001000100010001000000000", 2)
        Me.ulong_0(48) = Convert.ToUInt64("0000001110100011001110101110011000101110", 2)
        Me.ulong_0(49) = Convert.ToUInt64("0000001110001000010000100001100010000100", 2)
        Me.ulong_0(50) = Convert.ToUInt64("0000011111000100010001000100001000101110", 2)
        Me.ulong_0(51) = Convert.ToUInt64("0000001110100011000001110100001000101110", 2)
        Me.ulong_0(52) = Convert.ToUInt64("0000001000010001111101001010100110001000", 2)
        Me.ulong_0(53) = Convert.ToUInt64("0000001111100001000001111000010000111111", 2)
        Me.ulong_0(54) = Convert.ToUInt64("0000001110100011000101111000010000101110", 2)
        Me.ulong_0(55) = Convert.ToUInt64("0000000001000100010001000100001000011111", 2)
        Me.ulong_0(56) = Convert.ToUInt64("0000001110100011000101110100011000101110", 2)
        Me.ulong_0(57) = Convert.ToUInt64("0000001110100001000011110100011000101110", 2)
        Me.ulong_0(58) = Convert.ToUInt64("0000000000000000010000000001000000000000", 2)
        Me.ulong_0(59) = Convert.ToUInt64("0001000100001000000000100000000000000000", 2)
        Me.ulong_0(60) = Convert.ToUInt64("0000000000010000010000010001000100000000", 2)
        Me.ulong_0(61) = Convert.ToUInt64("0000000000000000111000000011100000000000", 2)
        Me.ulong_0(62) = Convert.ToUInt64("0000000000000100010001000001000001000000", 2)
        Me.ulong_0(63) = Convert.ToUInt64("0000000100000000010001000100001000101110", 2)
        Me.ulong_0(64) = Convert.ToUInt64("0000001110000011110110101111011000101110", 2)
        Me.ulong_0(65) = Convert.ToUInt64("0000010001100011111110001100010101000100", 2)
        Me.ulong_0(66) = Convert.ToUInt64("0000001111100011000101111100011000101111", 2)
        Me.ulong_0(67) = Convert.ToUInt64("0000001110100010000100001000011000101110", 2)
        Me.ulong_0(68) = Convert.ToUInt64("0000001111100011000110001100011000101111", 2)
        Me.ulong_0(69) = Convert.ToUInt64("0000011111000010000101111000010000111111", 2)
        Me.ulong_0(70) = Convert.ToUInt64("0000000001000010000101111000010000111111", 2)
        Me.ulong_0(71) = Convert.ToUInt64("0000001110100011000111101000011000101110", 2)
        Me.ulong_0(72) = Convert.ToUInt64("0000010001100011000111111100011000110001", 2)
        Me.ulong_0(73) = Convert.ToUInt64("0000001110001000010000100001000010001110", 2)
        Me.ulong_0(74) = Convert.ToUInt64("0000001110100011000110000100001000010000", 2)
        Me.ulong_0(75) = Convert.ToUInt64("0000010001010010010100011001010100110001", 2)
        Me.ulong_0(76) = Convert.ToUInt64("0000011111000010000100001000010000100001", 2)
        Me.ulong_0(77) = Convert.ToUInt64("0000010001100011000110001101011101110001", 2)
        Me.ulong_0(78) = Convert.ToUInt64("0000010001100011100110101100111000110001", 2)
        Me.ulong_0(79) = Convert.ToUInt64("0000001110100011000110001100011000101110", 2)
        Me.ulong_0(80) = Convert.ToUInt64("0000000001000010000101111100011000101111", 2)
        Me.ulong_0(81) = Convert.ToUInt64("0000010110010011010110001100011000101110", 2)
        Me.ulong_0(82) = Convert.ToUInt64("0000010001100011000101111100011000101111", 2)
        Me.ulong_0(83) = Convert.ToUInt64("0000001110100011000001110000011000101110", 2)
        Me.ulong_0(84) = Convert.ToUInt64("0000000100001000010000100001000010011111", 2)
        Me.ulong_0(85) = Convert.ToUInt64("0000001110100011000110001100011000110001", 2)
        Me.ulong_0(86) = Convert.ToUInt64("0000000100010101000110001100011000110001", 2)
        Me.ulong_0(87) = Convert.ToUInt64("0000010001110111010110001100011000110001", 2)
        Me.ulong_0(88) = Convert.ToUInt64("0000010001100010101000100010101000110001", 2)
        Me.ulong_0(89) = Convert.ToUInt64("0000000100001000010001010100011000110001", 2)
        Me.ulong_0(90) = Convert.ToUInt64("0000011111000010001000100010001000011111", 2)
        Me.ulong_0(91) = Convert.ToUInt64("0000001110000100001000010000100001001110", 2)
        Me.ulong_0(92) = Convert.ToUInt64("0000000000100000100000100000100000100000", 2)
        Me.ulong_0(93) = Convert.ToUInt64("0000001110010000100001000010000100001110", 2)
        Me.ulong_0(94) = Convert.ToUInt64("0000000000000000000000000100010101000100", 2)
        Me.ulong_0(95) = Convert.ToUInt64("0000011111000000000000000000000000000000", 2)
        Me.ulong_0(96) = Convert.ToUInt64("0000000000000000000000000000000010000010", 2)
        Me.ulong_0(97) = Convert.ToUInt64("0000010110010010111001000001110000000000", 2)
        Me.ulong_0(98) = Convert.ToUInt64("0000001101100111000110011011010000100001", 2)
        Me.ulong_0(99) = Convert.ToUInt64("0000001110100010000110001011100000000000", 2)
        Me.ulong_0(100) = Convert.ToUInt64("0000010110110011000111001101101000010000", 2)
        Me.ulong_0(101) = Convert.ToUInt64("0000011110000011111110001011100000000000", 2)
        Me.ulong_0(102) = Convert.ToUInt64("0000001110001000010011110001000010011000", 2)
        Me.ulong_0(103) = Convert.ToUInt64("0111010000111101000111001101100000000000", 2)
        Me.ulong_0(104) = Convert.ToUInt64("0000010001100011000110011011010000100001", 2)
        Me.ulong_0(105) = Convert.ToUInt64("0000001110001000010000100001100000000100", 2)
        Me.ulong_0(106) = Convert.ToUInt64("0011001000010000100001000011000000001000", 2)
        Me.ulong_0(107) = Convert.ToUInt64("0000010001010010011101001100010000100001", 2)
        Me.ulong_0(108) = Convert.ToUInt64("0000011110001000010000100001000010000110", 2)
        Me.ulong_0(109) = Convert.ToUInt64("0000010101101011010110101010100000000000", 2)
        Me.ulong_0(110) = Convert.ToUInt64("0000010001100011000110011011010000000000", 2)
        Me.ulong_0(111) = Convert.ToUInt64("0000001110100011000110001011100000000000", 2)
        Me.ulong_0(112) = Convert.ToUInt64("0000100001011111000110011011010000000000", 2)
        Me.ulong_0(113) = Convert.ToUInt64("1000010000111101000110001101100000000000", 2)
        Me.ulong_0(114) = Convert.ToUInt64("0000000001000010000110011011010000000000", 2)
        Me.ulong_0(115) = Convert.ToUInt64("0000001111100000111000001111100000000000", 2)
        Me.ulong_0(116) = Convert.ToUInt64("0000001100000100001000010011110001000010", 2)
        Me.ulong_0(117) = Convert.ToUInt64("0000010110110011000110001100010000000000", 2)
        Me.ulong_0(118) = Convert.ToUInt64("0000000100010101000110001100010000000000", 2)
        Me.ulong_0(119) = Convert.ToUInt64("0000001010101011010110101101010000000000", 2)
        Me.ulong_0(120) = Convert.ToUInt64("0000010001010100010001010100010000000000", 2)
        Me.ulong_0(121) = Convert.ToUInt64("0001100100001000101001010100010000000000", 2)
        Me.ulong_0(122) = Convert.ToUInt64("0000011111100100010001001111110000000000", 2)
        Me.ulong_0(123) = Convert.ToUInt64("0000001000001000010000010001000010001000", 2)
        Me.ulong_0(124) = Convert.ToUInt64("0000000100001000010000000001000010000100", 2)
        Me.ulong_0(125) = Convert.ToUInt64("0000000010001000010001000001000010000010", 2)
        Me.ulong_0(126) = Convert.ToUInt64("0000000000000000100110110000000000000000", 2)
        If ((MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0))) Then
            Me.ForeColor = Color.Red
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        MyBase.OnPaint(painte)
        painte.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim num As Integer = 0

    End Sub

    Private Sub SimpleLEDMatrix_Click(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Focus()
    End Sub

    Private Sub SimpleLEDMatrix_Resize(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Height = CInt(Math.Round(CDbl((1.76296294! * CSng(MyBase.Width)))))
    End Sub

    Public Event ValueChanged As EventHandler

End Class
