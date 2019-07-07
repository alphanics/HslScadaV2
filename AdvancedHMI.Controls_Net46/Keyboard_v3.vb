Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Public Class Keyboard_v3

    Inherits System.Windows.Forms.Form

#Region "Constructor"
    Private components As System.ComponentModel.IContainer

    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn10 As System.Windows.Forms.Button
    Friend WithEvents btn11 As System.Windows.Forms.Button
    Friend WithEvents btn12 As System.Windows.Forms.Button
    Friend WithEvents btn13 As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnTab As System.Windows.Forms.Button
    Friend WithEvents btn_Q As System.Windows.Forms.Button
    Friend WithEvents btn_W As System.Windows.Forms.Button
    Friend WithEvents btn_E As System.Windows.Forms.Button
    Friend WithEvents btn_R As System.Windows.Forms.Button
    Friend WithEvents btn_T As System.Windows.Forms.Button
    Friend WithEvents btn_Y As System.Windows.Forms.Button
    Friend WithEvents btn_U As System.Windows.Forms.Button
    Friend WithEvents btn_I As System.Windows.Forms.Button
    Friend WithEvents btn_O As System.Windows.Forms.Button
    Friend WithEvents btn_P As System.Windows.Forms.Button
    Friend WithEvents btn16 As System.Windows.Forms.Button
    Friend WithEvents btn15 As System.Windows.Forms.Button
    Friend WithEvents btn14 As System.Windows.Forms.Button
    Friend WithEvents btnCaps As System.Windows.Forms.Button
    Friend WithEvents btn_A As System.Windows.Forms.Button
    Friend WithEvents btn_S As System.Windows.Forms.Button
    Friend WithEvents btn_D As System.Windows.Forms.Button
    Friend WithEvents btn_F As System.Windows.Forms.Button
    Friend WithEvents btn_G As System.Windows.Forms.Button
    Friend WithEvents btn_H As System.Windows.Forms.Button
    Friend WithEvents btn_J As System.Windows.Forms.Button
    Friend WithEvents btn_K As System.Windows.Forms.Button
    Friend WithEvents btn_L As System.Windows.Forms.Button
    Friend WithEvents btn30 As System.Windows.Forms.Button
    Friend WithEvents btn29 As System.Windows.Forms.Button
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnShiftL As System.Windows.Forms.Button
    Friend WithEvents btn_Z As System.Windows.Forms.Button
    Friend WithEvents btn_X As System.Windows.Forms.Button
    Friend WithEvents btn_C As System.Windows.Forms.Button
    Friend WithEvents btn_V As System.Windows.Forms.Button
    Friend WithEvents btn_B As System.Windows.Forms.Button
    Friend WithEvents btn_N As System.Windows.Forms.Button
    Friend WithEvents btn_M As System.Windows.Forms.Button
    Friend WithEvents btn41 As System.Windows.Forms.Button
    Friend WithEvents btn40 As System.Windows.Forms.Button
    Friend WithEvents btn28 As System.Windows.Forms.Button
    Friend WithEvents btnShiftR As System.Windows.Forms.Button
    Friend WithEvents btnLeft As Button
    Friend WithEvents btnUp As Button
    Friend WithEvents btnRight As Button
    Friend WithEvents btnDown As Button
    Friend WithEvents btnSpace As Button
    Friend WithEvents btnSelectAll As Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn10 = New System.Windows.Forms.Button()
        Me.btn11 = New System.Windows.Forms.Button()
        Me.btn12 = New System.Windows.Forms.Button()
        Me.btn13 = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnTab = New System.Windows.Forms.Button()
        Me.btn_Q = New System.Windows.Forms.Button()
        Me.btn_W = New System.Windows.Forms.Button()
        Me.btn_E = New System.Windows.Forms.Button()
        Me.btn_R = New System.Windows.Forms.Button()
        Me.btn_T = New System.Windows.Forms.Button()
        Me.btn_Y = New System.Windows.Forms.Button()
        Me.btn_U = New System.Windows.Forms.Button()
        Me.btn_I = New System.Windows.Forms.Button()
        Me.btn_O = New System.Windows.Forms.Button()
        Me.btn_P = New System.Windows.Forms.Button()
        Me.btn16 = New System.Windows.Forms.Button()
        Me.btn15 = New System.Windows.Forms.Button()
        Me.btn14 = New System.Windows.Forms.Button()
        Me.btnCaps = New System.Windows.Forms.Button()
        Me.btn_A = New System.Windows.Forms.Button()
        Me.btn_S = New System.Windows.Forms.Button()
        Me.btn_D = New System.Windows.Forms.Button()
        Me.btn_F = New System.Windows.Forms.Button()
        Me.btn_G = New System.Windows.Forms.Button()
        Me.btn_H = New System.Windows.Forms.Button()
        Me.btn_J = New System.Windows.Forms.Button()
        Me.btn_K = New System.Windows.Forms.Button()
        Me.btn_L = New System.Windows.Forms.Button()
        Me.btn30 = New System.Windows.Forms.Button()
        Me.btn29 = New System.Windows.Forms.Button()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnShiftL = New System.Windows.Forms.Button()
        Me.btn_Z = New System.Windows.Forms.Button()
        Me.btn_X = New System.Windows.Forms.Button()
        Me.btn_C = New System.Windows.Forms.Button()
        Me.btn_V = New System.Windows.Forms.Button()
        Me.btn_B = New System.Windows.Forms.Button()
        Me.btn_N = New System.Windows.Forms.Button()
        Me.btn_M = New System.Windows.Forms.Button()
        Me.btn41 = New System.Windows.Forms.Button()
        Me.btn40 = New System.Windows.Forms.Button()
        Me.btn28 = New System.Windows.Forms.Button()
        Me.btnShiftR = New System.Windows.Forms.Button()
        Me.btnLeft = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnRight = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnSpace = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.Black
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.ForeColor = System.Drawing.Color.White
        Me.btn1.Location = New System.Drawing.Point(58, 7)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 50)
        Me.btn1.TabIndex = 0
        Me.btn1.Text = "!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.Black
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.ForeColor = System.Drawing.Color.White
        Me.btn2.Location = New System.Drawing.Point(110, 7)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(50, 50)
        Me.btn2.TabIndex = 1
        Me.btn2.Text = "@" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.Black
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.ForeColor = System.Drawing.Color.White
        Me.btn3.Location = New System.Drawing.Point(162, 7)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(50, 50)
        Me.btn3.TabIndex = 2
        Me.btn3.Text = "#" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.Black
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.ForeColor = System.Drawing.Color.White
        Me.btn4.Location = New System.Drawing.Point(214, 7)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(50, 50)
        Me.btn4.TabIndex = 3
        Me.btn4.Text = "$" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.Black
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.ForeColor = System.Drawing.Color.White
        Me.btn5.Location = New System.Drawing.Point(266, 7)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(50, 50)
        Me.btn5.TabIndex = 4
        Me.btn5.Text = "%" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.Black
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.ForeColor = System.Drawing.Color.White
        Me.btn6.Location = New System.Drawing.Point(318, 7)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(50, 50)
        Me.btn6.TabIndex = 5
        Me.btn6.Text = "^" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.Black
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.ForeColor = System.Drawing.Color.White
        Me.btn7.Location = New System.Drawing.Point(370, 7)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(50, 50)
        Me.btn7.TabIndex = 6
        Me.btn7.Text = "&" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7"
        Me.btn7.UseMnemonic = False
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.Black
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.ForeColor = System.Drawing.Color.White
        Me.btn8.Location = New System.Drawing.Point(422, 7)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(50, 50)
        Me.btn8.TabIndex = 7
        Me.btn8.Text = "*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.Black
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.ForeColor = System.Drawing.Color.White
        Me.btn9.Location = New System.Drawing.Point(474, 7)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(50, 50)
        Me.btn9.TabIndex = 8
        Me.btn9.Text = "(" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn10
        '
        Me.btn10.BackColor = System.Drawing.Color.Black
        Me.btn10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn10.ForeColor = System.Drawing.Color.White
        Me.btn10.Location = New System.Drawing.Point(526, 7)
        Me.btn10.Name = "btn10"
        Me.btn10.Size = New System.Drawing.Size(50, 50)
        Me.btn10.TabIndex = 9
        Me.btn10.Text = ")" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0"
        Me.btn10.UseVisualStyleBackColor = False
        '
        'btn11
        '
        Me.btn11.BackColor = System.Drawing.Color.Black
        Me.btn11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn11.ForeColor = System.Drawing.Color.White
        Me.btn11.Location = New System.Drawing.Point(578, 7)
        Me.btn11.Name = "btn11"
        Me.btn11.Size = New System.Drawing.Size(50, 50)
        Me.btn11.TabIndex = 10
        Me.btn11.Text = "_" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.btn11.UseVisualStyleBackColor = False
        '
        'btn12
        '
        Me.btn12.BackColor = System.Drawing.Color.Black
        Me.btn12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn12.ForeColor = System.Drawing.Color.White
        Me.btn12.Location = New System.Drawing.Point(630, 7)
        Me.btn12.Name = "btn12"
        Me.btn12.Size = New System.Drawing.Size(50, 50)
        Me.btn12.TabIndex = 11
        Me.btn12.Text = "+" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "="
        Me.btn12.UseVisualStyleBackColor = False
        '
        'btn13
        '
        Me.btn13.BackColor = System.Drawing.Color.Black
        Me.btn13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn13.ForeColor = System.Drawing.Color.White
        Me.btn13.Location = New System.Drawing.Point(6, 7)
        Me.btn13.Name = "btn13"
        Me.btn13.Size = New System.Drawing.Size(50, 50)
        Me.btn13.TabIndex = 12
        Me.btn13.Text = "~" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "`"
        Me.btn13.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Black
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.White
        Me.btnBack.Location = New System.Drawing.Point(682, 7)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(95, 50)
        Me.btnBack.TabIndex = 13
        Me.btnBack.Text = "Backspace"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnTab
        '
        Me.btnTab.BackColor = System.Drawing.Color.Black
        Me.btnTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTab.ForeColor = System.Drawing.Color.White
        Me.btnTab.Location = New System.Drawing.Point(6, 59)
        Me.btnTab.Name = "btnTab"
        Me.btnTab.Size = New System.Drawing.Size(76, 50)
        Me.btnTab.TabIndex = 14
        Me.btnTab.Text = "Tab"
        Me.btnTab.UseVisualStyleBackColor = False
        '
        'btn_Q
        '
        Me.btn_Q.BackColor = System.Drawing.Color.Black
        Me.btn_Q.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Q.ForeColor = System.Drawing.Color.White
        Me.btn_Q.Location = New System.Drawing.Point(84, 59)
        Me.btn_Q.Name = "btn_Q"
        Me.btn_Q.Size = New System.Drawing.Size(50, 50)
        Me.btn_Q.TabIndex = 15
        Me.btn_Q.Text = "q"
        Me.btn_Q.UseVisualStyleBackColor = False
        '
        'btn_W
        '
        Me.btn_W.BackColor = System.Drawing.Color.Black
        Me.btn_W.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_W.ForeColor = System.Drawing.Color.White
        Me.btn_W.Location = New System.Drawing.Point(136, 59)
        Me.btn_W.Name = "btn_W"
        Me.btn_W.Size = New System.Drawing.Size(50, 50)
        Me.btn_W.TabIndex = 16
        Me.btn_W.Text = "w"
        Me.btn_W.UseVisualStyleBackColor = False
        '
        'btn_E
        '
        Me.btn_E.BackColor = System.Drawing.Color.Black
        Me.btn_E.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_E.ForeColor = System.Drawing.Color.White
        Me.btn_E.Location = New System.Drawing.Point(188, 59)
        Me.btn_E.Name = "btn_E"
        Me.btn_E.Size = New System.Drawing.Size(50, 50)
        Me.btn_E.TabIndex = 17
        Me.btn_E.Text = "e"
        Me.btn_E.UseVisualStyleBackColor = False
        '
        'btn_R
        '
        Me.btn_R.BackColor = System.Drawing.Color.Black
        Me.btn_R.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_R.ForeColor = System.Drawing.Color.White
        Me.btn_R.Location = New System.Drawing.Point(240, 59)
        Me.btn_R.Name = "btn_R"
        Me.btn_R.Size = New System.Drawing.Size(50, 50)
        Me.btn_R.TabIndex = 18
        Me.btn_R.Text = "r"
        Me.btn_R.UseVisualStyleBackColor = False
        '
        'btn_T
        '
        Me.btn_T.BackColor = System.Drawing.Color.Black
        Me.btn_T.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_T.ForeColor = System.Drawing.Color.White
        Me.btn_T.Location = New System.Drawing.Point(292, 59)
        Me.btn_T.Name = "btn_T"
        Me.btn_T.Size = New System.Drawing.Size(50, 50)
        Me.btn_T.TabIndex = 19
        Me.btn_T.Text = "t"
        Me.btn_T.UseVisualStyleBackColor = False
        '
        'btn_Y
        '
        Me.btn_Y.BackColor = System.Drawing.Color.Black
        Me.btn_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Y.ForeColor = System.Drawing.Color.White
        Me.btn_Y.Location = New System.Drawing.Point(344, 59)
        Me.btn_Y.Name = "btn_Y"
        Me.btn_Y.Size = New System.Drawing.Size(50, 50)
        Me.btn_Y.TabIndex = 20
        Me.btn_Y.Text = "y"
        Me.btn_Y.UseVisualStyleBackColor = False
        '
        'btn_U
        '
        Me.btn_U.BackColor = System.Drawing.Color.Black
        Me.btn_U.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_U.ForeColor = System.Drawing.Color.White
        Me.btn_U.Location = New System.Drawing.Point(396, 59)
        Me.btn_U.Name = "btn_U"
        Me.btn_U.Size = New System.Drawing.Size(50, 50)
        Me.btn_U.TabIndex = 21
        Me.btn_U.Text = "u"
        Me.btn_U.UseVisualStyleBackColor = False
        '
        'btn_I
        '
        Me.btn_I.BackColor = System.Drawing.Color.Black
        Me.btn_I.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_I.ForeColor = System.Drawing.Color.White
        Me.btn_I.Location = New System.Drawing.Point(448, 59)
        Me.btn_I.Name = "btn_I"
        Me.btn_I.Size = New System.Drawing.Size(50, 50)
        Me.btn_I.TabIndex = 22
        Me.btn_I.Text = "i"
        Me.btn_I.UseVisualStyleBackColor = False
        '
        'btn_O
        '
        Me.btn_O.BackColor = System.Drawing.Color.Black
        Me.btn_O.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_O.ForeColor = System.Drawing.Color.White
        Me.btn_O.Location = New System.Drawing.Point(500, 59)
        Me.btn_O.Name = "btn_O"
        Me.btn_O.Size = New System.Drawing.Size(50, 50)
        Me.btn_O.TabIndex = 23
        Me.btn_O.Text = "o"
        Me.btn_O.UseVisualStyleBackColor = False
        '
        'btn_P
        '
        Me.btn_P.BackColor = System.Drawing.Color.Black
        Me.btn_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_P.ForeColor = System.Drawing.Color.White
        Me.btn_P.Location = New System.Drawing.Point(552, 59)
        Me.btn_P.Name = "btn_P"
        Me.btn_P.Size = New System.Drawing.Size(50, 50)
        Me.btn_P.TabIndex = 24
        Me.btn_P.Text = "p"
        Me.btn_P.UseVisualStyleBackColor = False
        '
        'btn16
        '
        Me.btn16.BackColor = System.Drawing.Color.Black
        Me.btn16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn16.ForeColor = System.Drawing.Color.White
        Me.btn16.Location = New System.Drawing.Point(604, 59)
        Me.btn16.Name = "btn16"
        Me.btn16.Size = New System.Drawing.Size(50, 50)
        Me.btn16.TabIndex = 25
        Me.btn16.Text = "{" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "["
        Me.btn16.UseVisualStyleBackColor = False
        '
        'btn15
        '
        Me.btn15.BackColor = System.Drawing.Color.Black
        Me.btn15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn15.ForeColor = System.Drawing.Color.White
        Me.btn15.Location = New System.Drawing.Point(656, 59)
        Me.btn15.Name = "btn15"
        Me.btn15.Size = New System.Drawing.Size(50, 50)
        Me.btn15.TabIndex = 26
        Me.btn15.Text = "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "]"
        Me.btn15.UseVisualStyleBackColor = False
        '
        'btn14
        '
        Me.btn14.BackColor = System.Drawing.Color.Black
        Me.btn14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn14.ForeColor = System.Drawing.Color.White
        Me.btn14.Location = New System.Drawing.Point(708, 59)
        Me.btn14.Name = "btn14"
        Me.btn14.Size = New System.Drawing.Size(69, 50)
        Me.btn14.TabIndex = 27
        Me.btn14.Text = "|" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\"
        Me.btn14.UseVisualStyleBackColor = False
        '
        'btnCaps
        '
        Me.btnCaps.BackColor = System.Drawing.Color.Black
        Me.btnCaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaps.ForeColor = System.Drawing.Color.White
        Me.btnCaps.Location = New System.Drawing.Point(6, 111)
        Me.btnCaps.Name = "btnCaps"
        Me.btnCaps.Size = New System.Drawing.Size(91, 50)
        Me.btnCaps.TabIndex = 28
        Me.btnCaps.Text = "Caps"
        Me.btnCaps.UseVisualStyleBackColor = False
        '
        'btn_A
        '
        Me.btn_A.BackColor = System.Drawing.Color.Black
        Me.btn_A.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_A.ForeColor = System.Drawing.Color.White
        Me.btn_A.Location = New System.Drawing.Point(99, 111)
        Me.btn_A.Name = "btn_A"
        Me.btn_A.Size = New System.Drawing.Size(50, 50)
        Me.btn_A.TabIndex = 29
        Me.btn_A.Text = "a"
        Me.btn_A.UseVisualStyleBackColor = False
        '
        'btn_S
        '
        Me.btn_S.BackColor = System.Drawing.Color.Black
        Me.btn_S.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_S.ForeColor = System.Drawing.Color.White
        Me.btn_S.Location = New System.Drawing.Point(151, 111)
        Me.btn_S.Name = "btn_S"
        Me.btn_S.Size = New System.Drawing.Size(50, 50)
        Me.btn_S.TabIndex = 30
        Me.btn_S.Text = "s"
        Me.btn_S.UseVisualStyleBackColor = False
        '
        'btn_D
        '
        Me.btn_D.BackColor = System.Drawing.Color.Black
        Me.btn_D.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_D.ForeColor = System.Drawing.Color.White
        Me.btn_D.Location = New System.Drawing.Point(203, 111)
        Me.btn_D.Name = "btn_D"
        Me.btn_D.Size = New System.Drawing.Size(50, 50)
        Me.btn_D.TabIndex = 31
        Me.btn_D.Text = "d"
        Me.btn_D.UseVisualStyleBackColor = False
        '
        'btn_F
        '
        Me.btn_F.BackColor = System.Drawing.Color.Black
        Me.btn_F.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_F.ForeColor = System.Drawing.Color.White
        Me.btn_F.Location = New System.Drawing.Point(255, 111)
        Me.btn_F.Name = "btn_F"
        Me.btn_F.Size = New System.Drawing.Size(50, 50)
        Me.btn_F.TabIndex = 32
        Me.btn_F.Text = "f"
        Me.btn_F.UseVisualStyleBackColor = False
        '
        'btn_G
        '
        Me.btn_G.BackColor = System.Drawing.Color.Black
        Me.btn_G.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_G.ForeColor = System.Drawing.Color.White
        Me.btn_G.Location = New System.Drawing.Point(307, 111)
        Me.btn_G.Name = "btn_G"
        Me.btn_G.Size = New System.Drawing.Size(50, 50)
        Me.btn_G.TabIndex = 33
        Me.btn_G.Text = "g"
        Me.btn_G.UseVisualStyleBackColor = False
        '
        'btn_H
        '
        Me.btn_H.BackColor = System.Drawing.Color.Black
        Me.btn_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_H.ForeColor = System.Drawing.Color.White
        Me.btn_H.Location = New System.Drawing.Point(359, 111)
        Me.btn_H.Name = "btn_H"
        Me.btn_H.Size = New System.Drawing.Size(50, 50)
        Me.btn_H.TabIndex = 34
        Me.btn_H.Text = "h"
        Me.btn_H.UseVisualStyleBackColor = False
        '
        'btn_J
        '
        Me.btn_J.BackColor = System.Drawing.Color.Black
        Me.btn_J.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_J.ForeColor = System.Drawing.Color.White
        Me.btn_J.Location = New System.Drawing.Point(411, 111)
        Me.btn_J.Name = "btn_J"
        Me.btn_J.Size = New System.Drawing.Size(50, 50)
        Me.btn_J.TabIndex = 35
        Me.btn_J.Text = "j"
        Me.btn_J.UseVisualStyleBackColor = False
        '
        'btn_K
        '
        Me.btn_K.BackColor = System.Drawing.Color.Black
        Me.btn_K.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_K.ForeColor = System.Drawing.Color.White
        Me.btn_K.Location = New System.Drawing.Point(463, 111)
        Me.btn_K.Name = "btn_K"
        Me.btn_K.Size = New System.Drawing.Size(50, 50)
        Me.btn_K.TabIndex = 36
        Me.btn_K.Text = "k"
        Me.btn_K.UseVisualStyleBackColor = False
        '
        'btn_L
        '
        Me.btn_L.BackColor = System.Drawing.Color.Black
        Me.btn_L.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_L.ForeColor = System.Drawing.Color.White
        Me.btn_L.Location = New System.Drawing.Point(515, 111)
        Me.btn_L.Name = "btn_L"
        Me.btn_L.Size = New System.Drawing.Size(50, 50)
        Me.btn_L.TabIndex = 37
        Me.btn_L.Text = "l"
        Me.btn_L.UseVisualStyleBackColor = False
        '
        'btn30
        '
        Me.btn30.BackColor = System.Drawing.Color.Black
        Me.btn30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn30.ForeColor = System.Drawing.Color.White
        Me.btn30.Location = New System.Drawing.Point(567, 111)
        Me.btn30.Name = "btn30"
        Me.btn30.Size = New System.Drawing.Size(50, 50)
        Me.btn30.TabIndex = 38
        Me.btn30.Text = ":" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ";"
        Me.btn30.UseVisualStyleBackColor = False
        '
        'btn29
        '
        Me.btn29.BackColor = System.Drawing.Color.Black
        Me.btn29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn29.ForeColor = System.Drawing.Color.White
        Me.btn29.Location = New System.Drawing.Point(619, 111)
        Me.btn29.Name = "btn29"
        Me.btn29.Size = New System.Drawing.Size(50, 50)
        Me.btn29.TabIndex = 39
        Me.btn29.Text = """" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "'"
        Me.btn29.UseVisualStyleBackColor = False
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.Black
        Me.btnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.ForeColor = System.Drawing.Color.White
        Me.btnEnter.Location = New System.Drawing.Point(671, 111)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(106, 50)
        Me.btnEnter.TabIndex = 40
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = False
        '
        'btnShiftL
        '
        Me.btnShiftL.BackColor = System.Drawing.Color.Black
        Me.btnShiftL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShiftL.ForeColor = System.Drawing.Color.White
        Me.btnShiftL.Location = New System.Drawing.Point(6, 163)
        Me.btnShiftL.Name = "btnShiftL"
        Me.btnShiftL.Size = New System.Drawing.Size(117, 50)
        Me.btnShiftL.TabIndex = 41
        Me.btnShiftL.Text = "Shift"
        Me.btnShiftL.UseVisualStyleBackColor = False
        '
        'btn_Z
        '
        Me.btn_Z.BackColor = System.Drawing.Color.Black
        Me.btn_Z.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Z.ForeColor = System.Drawing.Color.White
        Me.btn_Z.Location = New System.Drawing.Point(125, 163)
        Me.btn_Z.Name = "btn_Z"
        Me.btn_Z.Size = New System.Drawing.Size(50, 50)
        Me.btn_Z.TabIndex = 42
        Me.btn_Z.Text = "z"
        Me.btn_Z.UseVisualStyleBackColor = False
        '
        'btn_X
        '
        Me.btn_X.BackColor = System.Drawing.Color.Black
        Me.btn_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_X.ForeColor = System.Drawing.Color.White
        Me.btn_X.Location = New System.Drawing.Point(177, 163)
        Me.btn_X.Name = "btn_X"
        Me.btn_X.Size = New System.Drawing.Size(50, 50)
        Me.btn_X.TabIndex = 43
        Me.btn_X.Text = "x"
        Me.btn_X.UseVisualStyleBackColor = False
        '
        'btn_C
        '
        Me.btn_C.BackColor = System.Drawing.Color.Black
        Me.btn_C.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_C.ForeColor = System.Drawing.Color.White
        Me.btn_C.Location = New System.Drawing.Point(229, 163)
        Me.btn_C.Name = "btn_C"
        Me.btn_C.Size = New System.Drawing.Size(50, 50)
        Me.btn_C.TabIndex = 44
        Me.btn_C.Text = "c"
        Me.btn_C.UseVisualStyleBackColor = False
        '
        'btn_V
        '
        Me.btn_V.BackColor = System.Drawing.Color.Black
        Me.btn_V.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_V.ForeColor = System.Drawing.Color.White
        Me.btn_V.Location = New System.Drawing.Point(281, 163)
        Me.btn_V.Name = "btn_V"
        Me.btn_V.Size = New System.Drawing.Size(50, 50)
        Me.btn_V.TabIndex = 45
        Me.btn_V.Text = "v"
        Me.btn_V.UseVisualStyleBackColor = False
        '
        'btn_B
        '
        Me.btn_B.BackColor = System.Drawing.Color.Black
        Me.btn_B.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_B.ForeColor = System.Drawing.Color.White
        Me.btn_B.Location = New System.Drawing.Point(333, 163)
        Me.btn_B.Name = "btn_B"
        Me.btn_B.Size = New System.Drawing.Size(50, 50)
        Me.btn_B.TabIndex = 46
        Me.btn_B.Text = "b"
        Me.btn_B.UseVisualStyleBackColor = False
        '
        'btn_N
        '
        Me.btn_N.BackColor = System.Drawing.Color.Black
        Me.btn_N.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_N.ForeColor = System.Drawing.Color.White
        Me.btn_N.Location = New System.Drawing.Point(385, 163)
        Me.btn_N.Name = "btn_N"
        Me.btn_N.Size = New System.Drawing.Size(50, 50)
        Me.btn_N.TabIndex = 47
        Me.btn_N.Text = "n"
        Me.btn_N.UseVisualStyleBackColor = False
        '
        'btn_M
        '
        Me.btn_M.BackColor = System.Drawing.Color.Black
        Me.btn_M.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_M.ForeColor = System.Drawing.Color.White
        Me.btn_M.Location = New System.Drawing.Point(437, 163)
        Me.btn_M.Name = "btn_M"
        Me.btn_M.Size = New System.Drawing.Size(50, 50)
        Me.btn_M.TabIndex = 48
        Me.btn_M.Text = "m"
        Me.btn_M.UseVisualStyleBackColor = False
        '
        'btn41
        '
        Me.btn41.BackColor = System.Drawing.Color.Black
        Me.btn41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn41.ForeColor = System.Drawing.Color.White
        Me.btn41.Location = New System.Drawing.Point(489, 163)
        Me.btn41.Name = "btn41"
        Me.btn41.Size = New System.Drawing.Size(50, 50)
        Me.btn41.TabIndex = 49
        Me.btn41.Text = "<" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ","
        Me.btn41.UseVisualStyleBackColor = False
        '
        'btn40
        '
        Me.btn40.BackColor = System.Drawing.Color.Black
        Me.btn40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn40.ForeColor = System.Drawing.Color.White
        Me.btn40.Location = New System.Drawing.Point(541, 163)
        Me.btn40.Name = "btn40"
        Me.btn40.Size = New System.Drawing.Size(50, 50)
        Me.btn40.TabIndex = 50
        Me.btn40.Text = ">" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "."
        Me.btn40.UseVisualStyleBackColor = False
        '
        'btn28
        '
        Me.btn28.BackColor = System.Drawing.Color.Black
        Me.btn28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn28.ForeColor = System.Drawing.Color.White
        Me.btn28.Location = New System.Drawing.Point(593, 163)
        Me.btn28.Name = "btn28"
        Me.btn28.Size = New System.Drawing.Size(50, 50)
        Me.btn28.TabIndex = 51
        Me.btn28.Text = "?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "/"
        Me.btn28.UseVisualStyleBackColor = False
        '
        'btnShiftR
        '
        Me.btnShiftR.BackColor = System.Drawing.Color.Black
        Me.btnShiftR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShiftR.ForeColor = System.Drawing.Color.White
        Me.btnShiftR.Location = New System.Drawing.Point(645, 163)
        Me.btnShiftR.Name = "btnShiftR"
        Me.btnShiftR.Size = New System.Drawing.Size(132, 50)
        Me.btnShiftR.TabIndex = 52
        Me.btnShiftR.Text = "Shift"
        Me.btnShiftR.UseVisualStyleBackColor = False
        '
        'btnLeft
        '
        Me.btnLeft.BackColor = System.Drawing.Color.Black
        Me.btnLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeft.ForeColor = System.Drawing.Color.White
        Me.btnLeft.Location = New System.Drawing.Point(571, 215)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(50, 50)
        Me.btnLeft.TabIndex = 55
        Me.btnLeft.Text = "←"
        Me.btnLeft.UseVisualStyleBackColor = False
        '
        'btnUp
        '
        Me.btnUp.BackColor = System.Drawing.Color.Black
        Me.btnUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUp.ForeColor = System.Drawing.Color.White
        Me.btnUp.Location = New System.Drawing.Point(727, 215)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(50, 50)
        Me.btnUp.TabIndex = 56
        Me.btnUp.Text = "↑"
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'btnRight
        '
        Me.btnRight.BackColor = System.Drawing.Color.Black
        Me.btnRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRight.ForeColor = System.Drawing.Color.White
        Me.btnRight.Location = New System.Drawing.Point(675, 215)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(50, 50)
        Me.btnRight.TabIndex = 57
        Me.btnRight.Text = "→"
        Me.btnRight.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.btnDown.BackColor = System.Drawing.Color.Black
        Me.btnDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDown.ForeColor = System.Drawing.Color.White
        Me.btnDown.Location = New System.Drawing.Point(623, 215)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(50, 50)
        Me.btnDown.TabIndex = 58
        Me.btnDown.Text = "↓"
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'btnSpace
        '
        Me.btnSpace.BackColor = System.Drawing.Color.Black
        Me.btnSpace.ForeColor = System.Drawing.Color.White
        Me.btnSpace.Location = New System.Drawing.Point(99, 215)
        Me.btnSpace.Name = "btnSpace"
        Me.btnSpace.Size = New System.Drawing.Size(470, 50)
        Me.btnSpace.TabIndex = 60
        Me.btnSpace.Text = "Space"
        Me.btnSpace.UseVisualStyleBackColor = False
        '
        'btnSelectAll
        '
        Me.btnSelectAll.BackColor = System.Drawing.Color.Black
        Me.btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.ForeColor = System.Drawing.Color.White
        Me.btnSelectAll.Location = New System.Drawing.Point(6, 215)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(91, 50)
        Me.btnSelectAll.TabIndex = 62
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = False
        '
        'Keyboard_v3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(784, 277)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnSpace)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnRight)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnLeft)
        Me.Controls.Add(Me.btnShiftR)
        Me.Controls.Add(Me.btn28)
        Me.Controls.Add(Me.btn40)
        Me.Controls.Add(Me.btn41)
        Me.Controls.Add(Me.btn_M)
        Me.Controls.Add(Me.btn_N)
        Me.Controls.Add(Me.btn_B)
        Me.Controls.Add(Me.btn_V)
        Me.Controls.Add(Me.btn_C)
        Me.Controls.Add(Me.btn_X)
        Me.Controls.Add(Me.btn_Z)
        Me.Controls.Add(Me.btnShiftL)
        Me.Controls.Add(Me.btnEnter)
        Me.Controls.Add(Me.btn29)
        Me.Controls.Add(Me.btn30)
        Me.Controls.Add(Me.btn_L)
        Me.Controls.Add(Me.btn_K)
        Me.Controls.Add(Me.btn_J)
        Me.Controls.Add(Me.btn_H)
        Me.Controls.Add(Me.btn_G)
        Me.Controls.Add(Me.btn_F)
        Me.Controls.Add(Me.btn_D)
        Me.Controls.Add(Me.btn_S)
        Me.Controls.Add(Me.btn_A)
        Me.Controls.Add(Me.btnCaps)
        Me.Controls.Add(Me.btn14)
        Me.Controls.Add(Me.btn15)
        Me.Controls.Add(Me.btn16)
        Me.Controls.Add(Me.btn_P)
        Me.Controls.Add(Me.btn_O)
        Me.Controls.Add(Me.btn_I)
        Me.Controls.Add(Me.btn_U)
        Me.Controls.Add(Me.btn_Y)
        Me.Controls.Add(Me.btn_T)
        Me.Controls.Add(Me.btn_R)
        Me.Controls.Add(Me.btn_E)
        Me.Controls.Add(Me.btn_W)
        Me.Controls.Add(Me.btn_Q)
        Me.Controls.Add(Me.btnTab)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btn13)
        Me.Controls.Add(Me.btn12)
        Me.Controls.Add(Me.btn11)
        Me.Controls.Add(Me.btn10)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Keyboard_v3"
        Me.Text = "Keyboard"
        Me.ResumeLayout(False)

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

#Region "Methods"

    Private Sub Lower()

        btn1.Tag = "1"
        btn2.Tag = "2"
        btn3.Tag = "3"
        btn4.Tag = "4"
        btn5.Tag = "5"
        btn6.Tag = "6"
        btn7.Tag = "7"
        btn8.Tag = "8"
        btn9.Tag = "9"
        btn10.Tag = "0"
        btn11.Tag = "-"
        btn12.Tag = "="
        btn13.Tag = "`"
        btn14.Tag = "\"
        btn15.Tag = "]"
        btn16.Tag = "["
        btn29.Tag = "'"
        btn30.Tag = ";"
        btn28.Tag = "/"
        btn40.Tag = "."
        btn41.Tag = ","

    End Sub

    Private Sub Upper()

        btn1.Tag = "!"
        btn2.Tag = "@"
        btn3.Tag = "#"
        btn4.Tag = "$"
        btn5.Tag = "{%}"
        btn6.Tag = "{^}"
        btn7.Tag = "&"
        btn8.Tag = "*"
        btn9.Tag = "{(}"
        btn10.Tag = "{)}"
        btn11.Tag = "{_}"
        btn12.Tag = "{+}"
        btn13.Tag = "{~}"
        btn14.Tag = "|"
        btn15.Tag = "{}}"
        btn16.Tag = "{{}"
        btn29.Tag = """"
        btn30.Tag = ":"
        btn28.Tag = "?"
        btn40.Tag = ">"
        btn41.Tag = "<"

    End Sub

#End Region

#Region "Events"

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.DoubleBuffered = True
        Dim x As Integer = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Location = New Point(x, y)

        Me.TopMost = True
        For Each ctl As Control In Me.Controls
            If (ctl.Name.StartsWith("btn_")) Then
                Dim bttn As Button = DirectCast(ctl, Button)
                bttn.Tag = bttn.Text.ToLower
            End If
        Next
        Lower()

    End Sub

    Private Sub btnShiftR_Click(sender As Object, e As EventArgs) Handles btnShiftR.Click, btnShiftL.Click
        If btnShiftR.FlatStyle = FlatStyle.Flat Then
            btnShiftR.FlatStyle = FlatStyle.Standard
            btnShiftL.FlatStyle = FlatStyle.Standard
            For Each ctl As Control In Me.Controls
                If (ctl.Name.StartsWith("btn_")) Then
                    Dim bttn As Button = DirectCast(ctl, Button)
                    bttn.Tag = bttn.Text.ToLower
                    bttn.Text = bttn.Text.ToLower
                    Lower()
                End If
            Next
        ElseIf btnShiftR.FlatStyle = FlatStyle.Standard Then
            btnShiftL.FlatStyle = FlatStyle.Flat
            btnShiftR.FlatStyle = FlatStyle.Flat
            For Each ctl As Control In Me.Controls
                If (ctl.Name.StartsWith("btn_")) Then
                    Dim bttn As Button = DirectCast(ctl, Button)
                    bttn.Tag = bttn.Text.ToUpper
                    bttn.Text = bttn.Text.ToUpper
                    Upper()
                End If
            Next
        End If
    End Sub

    Private Sub btnCaps_Click(sender As Object, e As EventArgs) Handles btnCaps.Click
        If btnCaps.FlatStyle = FlatStyle.Flat Then
            btnCaps.FlatStyle = FlatStyle.Standard
            btnCaps.ForeColor = Color.White
            btnCaps.BackColor = Color.Black
            For Each ctl As Control In Me.Controls
                If (ctl.Name.StartsWith("btn_")) Then
                    Dim bttn As Button = DirectCast(ctl, Button)
                    bttn.Tag = bttn.Text.ToLower
                    bttn.Text = bttn.Text.ToLower
                    Lower()
                End If
            Next
        ElseIf btnCaps.FlatStyle = FlatStyle.Standard Then
            btnCaps.FlatStyle = FlatStyle.Flat
            btnCaps.ForeColor = Color.Black
            btnCaps.BackColor = Color.LightGreen
            For Each ctl As Control In Me.Controls
                If (ctl.Name.StartsWith("btn_")) Then
                    Dim bttn As Button = DirectCast(ctl, Button)
                    bttn.Tag = bttn.Text.ToUpper
                    bttn.Text = bttn.Text.ToUpper
                    Upper()
                End If
            Next
        End If
    End Sub

    Private Sub btn28_Click(sender As Object, e As EventArgs) Handles btn1.Click,
        btn10.Click, btn11.Click, btn12.Click, btn13.Click, btn14.Click, btn28.Click,
        btn15.Click, btn16.Click, btn2.Click, btn29.Click, btn3.Click,
        btn30.Click, btn4.Click, btn40.Click, btn41.Click, btn5.Click,
        btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_A.Click, btn_B.Click,
        btn_C.Click, btn_D.Click, btn_E.Click, btn_F.Click, btn_G.Click, btn_H.Click,
        btn_I.Click, btn_J.Click, btn_K.Click, btn_L.Click, btn_M.Click, btn_N.Click,
        btn_O.Click, btn_P.Click, btn_Q.Click, btn_R.Click, btn_S.Click, btn_T.Click,
        btn_V.Click, btn_U.Click, btn_W.Click, btn_X.Click, btn_Y.Click, btn_Z.Click

        Dim t As String = sender.Tag
        If btnShiftR.FlatStyle = FlatStyle.Flat Then
            btnShiftR.PerformClick()
        End If
        SendKeys.Send(t)

    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        SendKeys.Send("{LEFT}")
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        SendKeys.Send("{UP}")
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        SendKeys.Send("{RIGHT}")
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        SendKeys.Send("{DOWN}")
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        SendKeys.Send("{BACKSPACE}")
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub btnTab_Click(sender As Object, e As EventArgs) Handles btnTab.Click
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub btnSpace_Click(sender As Object, e As EventArgs) Handles btnSpace.Click
        SendKeys.Send(" ")
    End Sub

    Private Sub btnWindows_Click(sender As Object, e As EventArgs)
        SendKeys.Send("^{Esc}")
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        SendKeys.Send("^{A}")
    End Sub

#End Region

    Private Const WS_CHILD = &H40000000
    Private Const WS_EX_NOACTIVATE = &H8000000
    Private Const WM_MOVING = &H216

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim p As CreateParams = MyBase.CreateParams
            p.Style = p.Style Or WS_CHILD
            p.ExStyle = p.ExStyle Or WS_EX_NOACTIVATE
            Return p
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_MOVING Then
            Dim r As RECT
            r = DirectCast(Marshal.PtrToStructure(m.LParam, GetType(RECT)), RECT)
            Me.Location = New Point(r.Left, r.Top)
        End If
        MyBase.WndProc(m)
    End Sub

End Class
