
Public Class AlphaKeyBoard
    Inherits System.Windows.Forms.Form

    Public Event ButtonClick(ByVal sender As Object, ByVal e As KeypadEventArgs)

    Private components As System.ComponentModel.IContainer

    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents B1 As System.Windows.Forms.Button
    Friend WithEvents B2 As System.Windows.Forms.Button
    Friend WithEvents B3 As System.Windows.Forms.Button
    Friend WithEvents B4 As System.Windows.Forms.Button
    Friend WithEvents B5 As System.Windows.Forms.Button
    Friend WithEvents B6 As System.Windows.Forms.Button
    Friend WithEvents B7 As System.Windows.Forms.Button
    Friend WithEvents BQ As System.Windows.Forms.Button
    Friend WithEvents BW As System.Windows.Forms.Button
    Friend WithEvents BE As System.Windows.Forms.Button
    Friend WithEvents BA As System.Windows.Forms.Button
    Friend WithEvents BS As System.Windows.Forms.Button
    Friend WithEvents BD As System.Windows.Forms.Button
    Friend WithEvents EnterKey As System.Windows.Forms.Button
    Friend WithEvents B8 As System.Windows.Forms.Button
    Friend WithEvents B9 As System.Windows.Forms.Button
    Friend WithEvents BR As System.Windows.Forms.Button
    Friend WithEvents BT As System.Windows.Forms.Button
    Friend WithEvents BY As System.Windows.Forms.Button
    Friend WithEvents BU As System.Windows.Forms.Button
    Friend WithEvents BI As System.Windows.Forms.Button
    Friend WithEvents BO As System.Windows.Forms.Button
    Friend WithEvents BP As System.Windows.Forms.Button
    Friend WithEvents BF As System.Windows.Forms.Button
    Friend WithEvents BG As System.Windows.Forms.Button
    Friend WithEvents BH As System.Windows.Forms.Button
    Friend WithEvents BJ As System.Windows.Forms.Button
    Friend WithEvents BK As System.Windows.Forms.Button
    Friend WithEvents BL As System.Windows.Forms.Button
    Friend WithEvents BZ As System.Windows.Forms.Button
    Friend WithEvents BX As System.Windows.Forms.Button
    Friend WithEvents BC As System.Windows.Forms.Button
    Friend WithEvents BV As System.Windows.Forms.Button
    Friend WithEvents BB As System.Windows.Forms.Button
    Friend WithEvents BN As System.Windows.Forms.Button
    Friend WithEvents BM As System.Windows.Forms.Button
    Friend WithEvents BDash As System.Windows.Forms.Button
    Friend WithEvents B0 As System.Windows.Forms.Button
    Friend WithEvents BDot As System.Windows.Forms.Button
    Friend WithEvents BackSpaceButton As System.Windows.Forms.Button
    Friend WithEvents SpaceBar As System.Windows.Forms.Button

#Region "Constructor"
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.B1 = New System.Windows.Forms.Button()
        Me.B2 = New System.Windows.Forms.Button()
        Me.B3 = New System.Windows.Forms.Button()
        Me.B4 = New System.Windows.Forms.Button()
        Me.B5 = New System.Windows.Forms.Button()
        Me.B6 = New System.Windows.Forms.Button()
        Me.B7 = New System.Windows.Forms.Button()
        Me.BQ = New System.Windows.Forms.Button()
        Me.BW = New System.Windows.Forms.Button()
        Me.BE = New System.Windows.Forms.Button()
        Me.BA = New System.Windows.Forms.Button()
        Me.BS = New System.Windows.Forms.Button()
        Me.BD = New System.Windows.Forms.Button()
        Me.EnterKey = New System.Windows.Forms.Button()
        Me.B8 = New System.Windows.Forms.Button()
        Me.B9 = New System.Windows.Forms.Button()
        Me.BR = New System.Windows.Forms.Button()
        Me.BT = New System.Windows.Forms.Button()
        Me.BY = New System.Windows.Forms.Button()
        Me.BU = New System.Windows.Forms.Button()
        Me.BI = New System.Windows.Forms.Button()
        Me.BO = New System.Windows.Forms.Button()
        Me.BP = New System.Windows.Forms.Button()
        Me.BF = New System.Windows.Forms.Button()
        Me.BG = New System.Windows.Forms.Button()
        Me.BH = New System.Windows.Forms.Button()
        Me.BJ = New System.Windows.Forms.Button()
        Me.BK = New System.Windows.Forms.Button()
        Me.BL = New System.Windows.Forms.Button()
        Me.BZ = New System.Windows.Forms.Button()
        Me.BX = New System.Windows.Forms.Button()
        Me.BC = New System.Windows.Forms.Button()
        Me.BV = New System.Windows.Forms.Button()
        Me.BB = New System.Windows.Forms.Button()
        Me.BN = New System.Windows.Forms.Button()
        Me.BM = New System.Windows.Forms.Button()
        Me.BDash = New System.Windows.Forms.Button()
        Me.B0 = New System.Windows.Forms.Button()
        Me.BDot = New System.Windows.Forms.Button()
        Me.BackSpaceButton = New System.Windows.Forms.Button()
        Me.SpaceBar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.TextBox1.Location = New System.Drawing.Point(36, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(673, 32)
        Me.TextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(586, 318)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 47)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'B1
        '
        Me.B1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B1.ForeColor = System.Drawing.Color.Black
        Me.B1.Location = New System.Drawing.Point(43, 76)
        Me.B1.Name = "B1"
        Me.B1.Size = New System.Drawing.Size(57, 51)
        Me.B1.TabIndex = 2
        Me.B1.Text = "1"
        Me.B1.UseVisualStyleBackColor = True
        '
        'B2
        '
        Me.B2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B2.ForeColor = System.Drawing.Color.Black
        Me.B2.Location = New System.Drawing.Point(106, 76)
        Me.B2.Name = "B2"
        Me.B2.Size = New System.Drawing.Size(57, 51)
        Me.B2.TabIndex = 3
        Me.B2.Text = "2"
        Me.B2.UseVisualStyleBackColor = True
        '
        'B3
        '
        Me.B3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B3.ForeColor = System.Drawing.Color.Black
        Me.B3.Location = New System.Drawing.Point(169, 76)
        Me.B3.Name = "B3"
        Me.B3.Size = New System.Drawing.Size(57, 51)
        Me.B3.TabIndex = 4
        Me.B3.Text = "3"
        Me.B3.UseVisualStyleBackColor = True
        '
        'B4
        '
        Me.B4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B4.ForeColor = System.Drawing.Color.Black
        Me.B4.Location = New System.Drawing.Point(232, 76)
        Me.B4.Name = "B4"
        Me.B4.Size = New System.Drawing.Size(57, 51)
        Me.B4.TabIndex = 5
        Me.B4.Text = "4"
        Me.B4.UseVisualStyleBackColor = True
        '
        'B5
        '
        Me.B5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B5.ForeColor = System.Drawing.Color.Black
        Me.B5.Location = New System.Drawing.Point(295, 76)
        Me.B5.Name = "B5"
        Me.B5.Size = New System.Drawing.Size(57, 51)
        Me.B5.TabIndex = 6
        Me.B5.Text = "5"
        Me.B5.UseVisualStyleBackColor = True
        '
        'B6
        '
        Me.B6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B6.ForeColor = System.Drawing.Color.Black
        Me.B6.Location = New System.Drawing.Point(358, 76)
        Me.B6.Name = "B6"
        Me.B6.Size = New System.Drawing.Size(57, 51)
        Me.B6.TabIndex = 7
        Me.B6.Text = "6"
        Me.B6.UseVisualStyleBackColor = True
        '
        'B7
        '
        Me.B7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B7.ForeColor = System.Drawing.Color.Black
        Me.B7.Location = New System.Drawing.Point(421, 76)
        Me.B7.Name = "B7"
        Me.B7.Size = New System.Drawing.Size(57, 51)
        Me.B7.TabIndex = 8
        Me.B7.Text = "7"
        Me.B7.UseVisualStyleBackColor = True
        '
        'BQ
        '
        Me.BQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BQ.ForeColor = System.Drawing.Color.Black
        Me.BQ.Location = New System.Drawing.Point(12, 133)
        Me.BQ.Name = "BQ"
        Me.BQ.Size = New System.Drawing.Size(57, 51)
        Me.BQ.TabIndex = 9
        Me.BQ.Text = "Q"
        Me.BQ.UseVisualStyleBackColor = True
        '
        'BW
        '
        Me.BW.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BW.ForeColor = System.Drawing.Color.Black
        Me.BW.Location = New System.Drawing.Point(75, 133)
        Me.BW.Name = "BW"
        Me.BW.Size = New System.Drawing.Size(57, 51)
        Me.BW.TabIndex = 10
        Me.BW.Text = "W"
        Me.BW.UseVisualStyleBackColor = True
        '
        'BE
        '
        Me.BE.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BE.ForeColor = System.Drawing.Color.Black
        Me.BE.Location = New System.Drawing.Point(138, 133)
        Me.BE.Name = "BE"
        Me.BE.Size = New System.Drawing.Size(57, 51)
        Me.BE.TabIndex = 11
        Me.BE.Text = "E"
        Me.BE.UseVisualStyleBackColor = True
        '
        'BA
        '
        Me.BA.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BA.ForeColor = System.Drawing.Color.Black
        Me.BA.Location = New System.Drawing.Point(36, 190)
        Me.BA.Name = "BA"
        Me.BA.Size = New System.Drawing.Size(57, 51)
        Me.BA.TabIndex = 12
        Me.BA.Text = "A"
        Me.BA.UseVisualStyleBackColor = True
        '
        'BS
        '
        Me.BS.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BS.ForeColor = System.Drawing.Color.Black
        Me.BS.Location = New System.Drawing.Point(99, 190)
        Me.BS.Name = "BS"
        Me.BS.Size = New System.Drawing.Size(57, 51)
        Me.BS.TabIndex = 13
        Me.BS.Text = "S"
        Me.BS.UseVisualStyleBackColor = True
        '
        'BD
        '
        Me.BD.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BD.ForeColor = System.Drawing.Color.Black
        Me.BD.Location = New System.Drawing.Point(162, 190)
        Me.BD.Name = "BD"
        Me.BD.Size = New System.Drawing.Size(57, 51)
        Me.BD.TabIndex = 14
        Me.BD.Text = "D"
        Me.BD.UseVisualStyleBackColor = True
        '
        'EnterKey
        '
        Me.EnterKey.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.EnterKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.EnterKey.ForeColor = System.Drawing.Color.Black
        Me.EnterKey.Location = New System.Drawing.Point(602, 190)
        Me.EnterKey.Name = "EnterKey"
        Me.EnterKey.Size = New System.Drawing.Size(117, 51)
        Me.EnterKey.TabIndex = 15
        Me.EnterKey.Text = "ENTER"
        Me.EnterKey.UseVisualStyleBackColor = True
        '
        'B8
        '
        Me.B8.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B8.ForeColor = System.Drawing.Color.Black
        Me.B8.Location = New System.Drawing.Point(484, 76)
        Me.B8.Name = "B8"
        Me.B8.Size = New System.Drawing.Size(57, 51)
        Me.B8.TabIndex = 16
        Me.B8.Text = "8"
        Me.B8.UseVisualStyleBackColor = True
        '
        'B9
        '
        Me.B9.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B9.ForeColor = System.Drawing.Color.Black
        Me.B9.Location = New System.Drawing.Point(547, 76)
        Me.B9.Name = "B9"
        Me.B9.Size = New System.Drawing.Size(57, 51)
        Me.B9.TabIndex = 17
        Me.B9.Text = "9"
        Me.B9.UseVisualStyleBackColor = True
        '
        'BR
        '
        Me.BR.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BR.ForeColor = System.Drawing.Color.Black
        Me.BR.Location = New System.Drawing.Point(201, 133)
        Me.BR.Name = "BR"
        Me.BR.Size = New System.Drawing.Size(57, 51)
        Me.BR.TabIndex = 18
        Me.BR.Text = "R"
        Me.BR.UseVisualStyleBackColor = True
        '
        'BT
        '
        Me.BT.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BT.ForeColor = System.Drawing.Color.Black
        Me.BT.Location = New System.Drawing.Point(264, 133)
        Me.BT.Name = "BT"
        Me.BT.Size = New System.Drawing.Size(57, 51)
        Me.BT.TabIndex = 19
        Me.BT.Text = "T"
        Me.BT.UseVisualStyleBackColor = True
        '
        'BY
        '
        Me.BY.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BY.ForeColor = System.Drawing.Color.Black
        Me.BY.Location = New System.Drawing.Point(327, 133)
        Me.BY.Name = "BY"
        Me.BY.Size = New System.Drawing.Size(57, 51)
        Me.BY.TabIndex = 20
        Me.BY.Text = "Y"
        Me.BY.UseVisualStyleBackColor = True
        '
        'BU
        '
        Me.BU.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BU.ForeColor = System.Drawing.Color.Black
        Me.BU.Location = New System.Drawing.Point(390, 133)
        Me.BU.Name = "BU"
        Me.BU.Size = New System.Drawing.Size(57, 51)
        Me.BU.TabIndex = 21
        Me.BU.Text = "U"
        Me.BU.UseVisualStyleBackColor = True
        '
        'BI
        '
        Me.BI.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BI.ForeColor = System.Drawing.Color.Black
        Me.BI.Location = New System.Drawing.Point(453, 133)
        Me.BI.Name = "BI"
        Me.BI.Size = New System.Drawing.Size(57, 51)
        Me.BI.TabIndex = 22
        Me.BI.Text = "I"
        Me.BI.UseVisualStyleBackColor = True
        '
        'BO
        '
        Me.BO.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BO.ForeColor = System.Drawing.Color.Black
        Me.BO.Location = New System.Drawing.Point(516, 133)
        Me.BO.Name = "BO"
        Me.BO.Size = New System.Drawing.Size(57, 51)
        Me.BO.TabIndex = 23
        Me.BO.Text = "O"
        Me.BO.UseVisualStyleBackColor = True
        '
        'BP
        '
        Me.BP.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BP.ForeColor = System.Drawing.Color.Black
        Me.BP.Location = New System.Drawing.Point(578, 133)
        Me.BP.Name = "BP"
        Me.BP.Size = New System.Drawing.Size(57, 51)
        Me.BP.TabIndex = 24
        Me.BP.Text = "P"
        Me.BP.UseVisualStyleBackColor = True
        '
        'BF
        '
        Me.BF.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BF.ForeColor = System.Drawing.Color.Black
        Me.BF.Location = New System.Drawing.Point(225, 190)
        Me.BF.Name = "BF"
        Me.BF.Size = New System.Drawing.Size(57, 51)
        Me.BF.TabIndex = 25
        Me.BF.Text = "F"
        Me.BF.UseVisualStyleBackColor = True
        '
        'BG
        '
        Me.BG.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BG.ForeColor = System.Drawing.Color.Black
        Me.BG.Location = New System.Drawing.Point(288, 190)
        Me.BG.Name = "BG"
        Me.BG.Size = New System.Drawing.Size(57, 51)
        Me.BG.TabIndex = 26
        Me.BG.Text = "G"
        Me.BG.UseVisualStyleBackColor = True
        '
        'BH
        '
        Me.BH.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BH.ForeColor = System.Drawing.Color.Black
        Me.BH.Location = New System.Drawing.Point(351, 190)
        Me.BH.Name = "BH"
        Me.BH.Size = New System.Drawing.Size(57, 51)
        Me.BH.TabIndex = 27
        Me.BH.Text = "H"
        Me.BH.UseVisualStyleBackColor = True
        '
        'BJ
        '
        Me.BJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BJ.ForeColor = System.Drawing.Color.Black
        Me.BJ.Location = New System.Drawing.Point(414, 190)
        Me.BJ.Name = "BJ"
        Me.BJ.Size = New System.Drawing.Size(57, 51)
        Me.BJ.TabIndex = 28
        Me.BJ.Text = "J"
        Me.BJ.UseVisualStyleBackColor = True
        '
        'BK
        '
        Me.BK.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BK.ForeColor = System.Drawing.Color.Black
        Me.BK.Location = New System.Drawing.Point(477, 190)
        Me.BK.Name = "BK"
        Me.BK.Size = New System.Drawing.Size(57, 51)
        Me.BK.TabIndex = 29
        Me.BK.Text = "K"
        Me.BK.UseVisualStyleBackColor = True
        '
        'BL
        '
        Me.BL.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BL.ForeColor = System.Drawing.Color.Black
        Me.BL.Location = New System.Drawing.Point(540, 190)
        Me.BL.Name = "BL"
        Me.BL.Size = New System.Drawing.Size(57, 51)
        Me.BL.TabIndex = 30
        Me.BL.Text = "L"
        Me.BL.UseVisualStyleBackColor = True
        '
        'BZ
        '
        Me.BZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BZ.ForeColor = System.Drawing.Color.Black
        Me.BZ.Location = New System.Drawing.Point(43, 247)
        Me.BZ.Name = "BZ"
        Me.BZ.Size = New System.Drawing.Size(57, 51)
        Me.BZ.TabIndex = 31
        Me.BZ.Text = "Z"
        Me.BZ.UseVisualStyleBackColor = True
        '
        'BX
        '
        Me.BX.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BX.ForeColor = System.Drawing.Color.Black
        Me.BX.Location = New System.Drawing.Point(106, 247)
        Me.BX.Name = "BX"
        Me.BX.Size = New System.Drawing.Size(57, 51)
        Me.BX.TabIndex = 32
        Me.BX.Text = "X"
        Me.BX.UseVisualStyleBackColor = True
        '
        'BC
        '
        Me.BC.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BC.ForeColor = System.Drawing.Color.Black
        Me.BC.Location = New System.Drawing.Point(169, 247)
        Me.BC.Name = "BC"
        Me.BC.Size = New System.Drawing.Size(57, 51)
        Me.BC.TabIndex = 33
        Me.BC.Text = "C"
        Me.BC.UseVisualStyleBackColor = True
        '
        'BV
        '
        Me.BV.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BV.ForeColor = System.Drawing.Color.Black
        Me.BV.Location = New System.Drawing.Point(232, 247)
        Me.BV.Name = "BV"
        Me.BV.Size = New System.Drawing.Size(57, 51)
        Me.BV.TabIndex = 34
        Me.BV.Text = "V"
        Me.BV.UseVisualStyleBackColor = True
        '
        'BB
        '
        Me.BB.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BB.ForeColor = System.Drawing.Color.Black
        Me.BB.Location = New System.Drawing.Point(295, 247)
        Me.BB.Name = "BB"
        Me.BB.Size = New System.Drawing.Size(57, 51)
        Me.BB.TabIndex = 35
        Me.BB.Text = "B"
        Me.BB.UseVisualStyleBackColor = True
        '
        'BN
        '
        Me.BN.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BN.ForeColor = System.Drawing.Color.Black
        Me.BN.Location = New System.Drawing.Point(358, 247)
        Me.BN.Name = "BN"
        Me.BN.Size = New System.Drawing.Size(57, 51)
        Me.BN.TabIndex = 36
        Me.BN.Text = "N"
        Me.BN.UseVisualStyleBackColor = True
        '
        'BM
        '
        Me.BM.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BM.ForeColor = System.Drawing.Color.Black
        Me.BM.Location = New System.Drawing.Point(421, 247)
        Me.BM.Name = "BM"
        Me.BM.Size = New System.Drawing.Size(57, 51)
        Me.BM.TabIndex = 37
        Me.BM.Text = "M"
        Me.BM.UseVisualStyleBackColor = True
        '
        'BDash
        '
        Me.BDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDash.ForeColor = System.Drawing.Color.Black
        Me.BDash.Location = New System.Drawing.Point(673, 76)
        Me.BDash.Name = "BDash"
        Me.BDash.Size = New System.Drawing.Size(57, 51)
        Me.BDash.TabIndex = 38
        Me.BDash.Text = "-"
        Me.BDash.UseVisualStyleBackColor = True
        '
        'B0
        '
        Me.B0.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.B0.ForeColor = System.Drawing.Color.Black
        Me.B0.Location = New System.Drawing.Point(610, 76)
        Me.B0.Name = "B0"
        Me.B0.Size = New System.Drawing.Size(57, 51)
        Me.B0.TabIndex = 39
        Me.B0.Text = "0"
        Me.B0.UseVisualStyleBackColor = True
        '
        'BDot
        '
        Me.BDot.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDot.ForeColor = System.Drawing.Color.Black
        Me.BDot.Location = New System.Drawing.Point(540, 247)
        Me.BDot.Name = "BDot"
        Me.BDot.Size = New System.Drawing.Size(57, 51)
        Me.BDot.TabIndex = 40
        Me.BDot.Text = "."
        Me.BDot.UseVisualStyleBackColor = True
        '
        'BackSpaceButton
        '
        Me.BackSpaceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BackSpaceButton.ForeColor = System.Drawing.Color.Black
        Me.BackSpaceButton.Location = New System.Drawing.Point(641, 133)
        Me.BackSpaceButton.Name = "BackSpaceButton"
        Me.BackSpaceButton.Size = New System.Drawing.Size(89, 51)
        Me.BackSpaceButton.TabIndex = 41
        Me.BackSpaceButton.Text = "BackSpace"
        Me.BackSpaceButton.UseVisualStyleBackColor = True
        '
        'SpaceBar
        '
        Me.SpaceBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.SpaceBar.ForeColor = System.Drawing.Color.Black
        Me.SpaceBar.Location = New System.Drawing.Point(99, 304)
        Me.SpaceBar.Name = "SpaceBar"
        Me.SpaceBar.Size = New System.Drawing.Size(442, 51)
        Me.SpaceBar.TabIndex = 42
        Me.SpaceBar.Text = " "
        Me.SpaceBar.UseVisualStyleBackColor = True
        '
        'AlphaKeyboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 377)
        Me.Controls.Add(Me.SpaceBar)
        Me.Controls.Add(Me.BackSpaceButton)
        Me.Controls.Add(Me.BDot)
        Me.Controls.Add(Me.B0)
        Me.Controls.Add(Me.BDash)
        Me.Controls.Add(Me.BM)
        Me.Controls.Add(Me.BN)
        Me.Controls.Add(Me.BB)
        Me.Controls.Add(Me.BV)
        Me.Controls.Add(Me.BC)
        Me.Controls.Add(Me.BX)
        Me.Controls.Add(Me.BZ)
        Me.Controls.Add(Me.BL)
        Me.Controls.Add(Me.BK)
        Me.Controls.Add(Me.BJ)
        Me.Controls.Add(Me.BH)
        Me.Controls.Add(Me.BG)
        Me.Controls.Add(Me.BF)
        Me.Controls.Add(Me.BP)
        Me.Controls.Add(Me.BO)
        Me.Controls.Add(Me.BI)
        Me.Controls.Add(Me.BU)
        Me.Controls.Add(Me.BY)
        Me.Controls.Add(Me.BT)
        Me.Controls.Add(Me.BR)
        Me.Controls.Add(Me.B9)
        Me.Controls.Add(Me.B8)
        Me.Controls.Add(Me.EnterKey)
        Me.Controls.Add(Me.BD)
        Me.Controls.Add(Me.BS)
        Me.Controls.Add(Me.BA)
        Me.Controls.Add(Me.BE)
        Me.Controls.Add(Me.BW)
        Me.Controls.Add(Me.BQ)
        Me.Controls.Add(Me.B7)
        Me.Controls.Add(Me.B6)
        Me.Controls.Add(Me.B5)
        Me.Controls.Add(Me.B4)
        Me.Controls.Add(Me.B3)
        Me.Controls.Add(Me.B2)
        Me.Controls.Add(Me.B1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AlphaKeyboard"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
#End Region

#Region "Properties"
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            Me.Invalidate()
        End Set
    End Property

    Public Property PassWordCharacters As Boolean
        Get
            Return TextBox1.UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            TextBox1.UseSystemPasswordChar = value
        End Set
    End Property

    Public Overrides Property Font As System.Drawing.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As System.Drawing.Font)
            MyBase.Font = value
        End Set
    End Property


    Public Property Value As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property

    Public Shadows Property Location() As System.Drawing.Point
        Get
            Return MyBase.Location
        End Get
        Set(ByVal value As System.Drawing.Point)
            MyBase.Location = value
        End Set
    End Property

    Public Shadows Property Visible() As Boolean
        Get
            Return MyBase.Visible
        End Get
        Set(ByVal value As Boolean)
            MyBase.Visible = value
        End Set
    End Property

    Public Overrides Property ForeColor As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.ForeColor = value
        End Set
    End Property

    Public Shadows Property TopMost As Boolean
        Get
            Return MyBase.TopMost
        End Get
        Set(ByVal value As Boolean)
            MyBase.TopMost = value
        End Set
    End Property

    Public Shadows Property StartPosition As Object
        Get
            Return MyBase.StartPosition
        End Get
        Set(ByVal value As Object)
            MyBase.StartPosition = value
        End Set
    End Property
#End Region

#Region "Methods"
    Private Sub Numerickey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B1.Click, B2.Click, B3.Click, B4.Click, B5.Click, B6.Click, B7.Click, B8.Click, B9.Click, B0.Click
        RaiseEvent ButtonClick(Me, New KeyPadEventArgs(sender.text))
        AddCharacter(sender.text)
    End Sub
    Private Sub Alphakey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BQ.Click, BW.Click, BE.Click, BR.Click, BT.Click, BY.Click, BU.Click, BI.Click, BO.Click, BP.Click, BA.Click, BS.Click, BD.Click, BF.Click, BH.Click, BG.Click, BJ.Click, BK.Click, BL.Click
        RaiseEvent ButtonClick(Me, New KeyPadEventArgs(sender.text))
        AddCharacter(sender.text)
    End Sub

    Private Sub LastRowkey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BZ.Click, BX.Click, BC.Click, BV.Click, BB.Click, BN.Click, BM.Click, BDash.Click, BDot.Click
        AddCharacter(sender.text)
    End Sub

    Private Sub EnterKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterKey.Click
        RaiseEvent ButtonClick(Me, New KeyPadEventArgs("Enter"))
        DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BackSpaceButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackSpaceButton.Click
        Dim CurrentCursorPos As Integer = TextBox1.SelectionStart
        TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.SelectionStart - 1) & TextBox1.Text.Substring(TextBox1.SelectionStart)
        TextBox1.SelectionStart = CurrentCursorPos - 1
        TextBox1.Focus()
    End Sub

    Private Sub SpaceBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpaceBar.Click
        AddCharacter(" ")
    End Sub

    Private Sub AddCharacter(ByVal c As String)
        Dim CurrentCursorPos As Integer = TextBox1.SelectionStart
        TextBox1.Text = TextBox1.Text.Insert(TextBox1.SelectionStart, c)
        TextBox1.SelectionStart = CurrentCursorPos + 1
        TextBox1.Focus()
    End Sub

    Private Sub CancelButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent ButtonClick(Me, New KeyPadEventArgs("Quit"))
        DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
#End Region
End Class

