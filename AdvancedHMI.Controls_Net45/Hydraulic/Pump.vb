Imports System.Drawing
Imports System.Windows.Forms

Public Class Pump
    Inherits Control
    Private m_Images As ArrayList = New ArrayList()

    Private m_Count As Integer = 1
    Public Tmr_Move As New Timer
    Private _Value As Boolean
    Private LightOnImage As Bitmap
#Region "MY"
    Public Sub New()

        SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        AddHandler Tmr_Move.Tick, AddressOf Tmr_Move_Tick
        Tmr_Move.Interval = 100

        LightOnImage = My.Resources.p_h
        Me.BackgroundImage = LightOnImage
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.BackColor = Color.Transparent



    End Sub
    Public Enum ShowPump
        Blou
        Blak
        None
    End Enum
    Private m_Show As ShowPump = ShowPump.Blou
    Public Property ShowPumps As ShowPump
        Get
            Return m_Show
        End Get
        Set(ByVal value As ShowPump)
            m_Show = value
            ShowPumpRotation(m_Show, m_Rotation)
        End Set
    End Property
    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        Me.BackgroundImage = LightOnImage
        Me.Invalidate()
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)

        MyBase.OnResize(e)
        Me.BackgroundImage = LightOnImage
    End Sub
    Public Enum UPORDewn
        UP
        Dewn
    End Enum
    Private m_UPORDewn As UPORDewn = UPORDewn.Dewn
    Public Property UPORDewns As UPORDewn
        Get
            Return m_UPORDewn
        End Get
        Set(ByVal value As UPORDewn)
            m_UPORDewn = value
            If value = UPORDewn.Dewn Then
                m_Count = 1
            ElseIf value = UPORDewn.UP Then
                m_Count = 4
            End If
            Me.Invalidate()
        End Set
    End Property

    Private Sub Tmr_Move_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If m_Show = ShowPump.Blou Then
                If m_UPORDewn = UPORDewn.Dewn Then
                    m_Count = (m_Count + 1) Mod 4
                    Me.BackgroundImage = CType(m_Images(m_Count), Image)
                ElseIf m_UPORDewn = UPORDewn.UP Then
                    If m_Count = 0 Then
                        m_Count = 4
                    End If
                    m_Count = (m_Count - 1) Mod 4
                    Me.BackgroundImage = CType(m_Images(m_Count), Image)
                End If
            ElseIf m_Show = ShowPump.Blak Then
                If m_UPORDewn = UPORDewn.Dewn Then
                    m_Count = (m_Count + 1) Mod 4
                    Me.BackgroundImage = CType(m_Images(m_Count), Image)
                ElseIf m_UPORDewn = UPORDewn.UP Then
                    If m_Count = 0 Then
                        m_Count = 4
                    End If
                    m_Count = (m_Count - 1) Mod 4
                    Me.BackgroundImage = CType(m_Images(m_Count), Image)
                End If

            End If
            Me.Invalidate()
        Catch ex As Exception
            Return
        End Try


    End Sub


    Public Property Value As Boolean
        Get
            Return Me._Value
        End Get
        Set(ByVal value As Boolean)
            Me._Value = value
            If value = True Then
                Tmr_Move.Enabled = True
            ElseIf value = False Then

                Tmr_Move.Enabled = False

            End If

            Me.Invalidate()
        End Set
    End Property

    Public m_OutputType As OutputType
    Public Property OutputTypes As OutputType
        Get
            Return Me.m_OutputType
        End Get
        Set(ByVal value As OutputType)
            Me.m_OutputType = value
        End Set
    End Property
    Public Enum OutputType
        ' Fields
        MomentaryReset = 1
        MomentarySet = 0
        SetFalse = 3
        SetTrue = 2
        Toggle = 4
        WriteValue = 5
    End Enum
    Public Enum RotateFlipMY
        ' Fields
        Rotate180
        Rotate90
        Rotate270
        RotateNone

    End Enum
    Private Sub ShowPumpRotation(ByVal n_Show As ShowPump, ByVal m_Rotation As RotateFlipMY)
        m_Images.Clear()

        If m_Rotation = RotateFlipMY.Rotate180 And n_Show = ShowPump.Blou Then
            m_Images.Add(My.Resources._1_v)
            m_Images.Add(My.Resources._2_v)
            m_Images.Add(My.Resources._3_v)
            m_Images.Add(My.Resources._4_v)
            LightOnImage = My.Resources._1_v
            Me.BackgroundImage = My.Resources._1_v
        ElseIf m_Rotation = RotateFlipMY.Rotate90 And n_Show = ShowPump.Blou Then
            m_Images.Add(My.Resources._1)
            m_Images.Add(My.Resources._2)
            m_Images.Add(My.Resources._3)
            m_Images.Add(My.Resources._4)
            LightOnImage = My.Resources._1
            Me.BackgroundImage = My.Resources._1
        ElseIf m_Rotation = RotateFlipMY.Rotate270 And n_Show = ShowPump.Blou Then
            m_Images.Add(My.Resources._1_vY)
            m_Images.Add(My.Resources._2_vY)
            m_Images.Add(My.Resources._3_vY)
            m_Images.Add(My.Resources._4_vY)
            LightOnImage = My.Resources._1_vY
            Me.BackgroundImage = My.Resources._1_vY
        ElseIf m_Rotation = RotateFlipMY.RotateNone And n_Show = ShowPump.Blou Then
            m_Images.Add(My.Resources._1N)
            m_Images.Add(My.Resources._2N)
            m_Images.Add(My.Resources._3N)
            m_Images.Add(My.Resources._4N)
            LightOnImage = My.Resources._1N
            Me.BackgroundImage = My.Resources._1N
        ElseIf m_Rotation = RotateFlipMY.RotateNone And n_Show = ShowPump.Blak Then

            m_Images.Add(My.Resources._1p)
            m_Images.Add(My.Resources._2p)
            m_Images.Add(My.Resources._3p)
            m_Images.Add(My.Resources._4p)
            LightOnImage = My.Resources._1p
            BackgroundImage = My.Resources._1p
        Else
            LightOnImage = My.Resources.p_h
            BackgroundImage = My.Resources.p_h
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 32
            Return cp
            Return MyBase.CreateParams
        End Get
    End Property
    Private m_Rotation As RotateFlipMY
    Private BackNeedsRefreshed As Boolean
    Public Property Rotation As RotateFlipMY
        Get
            Return Me.m_Rotation
        End Get
        Set(ByVal value As RotateFlipMY)
            If (Me.m_Rotation <> value) Then
                Me.m_Rotation = value
                Me.BackNeedsRefreshed = True
                ShowPumpRotation(m_Show, m_Rotation)
            End If
            Me.Invalidate()
        End Set
    End Property
#End Region

End Class

