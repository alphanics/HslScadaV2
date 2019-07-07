Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class GroupPanel
    Inherits Panel

    Private m_BackColor As Color

    Private m_BackColor2, m_BackColor3 As Color

    Private m_SelectBackColor2, m_SelectBackColor3 As Boolean

    Public Shadows Property BackColor() As Color
        Get
            Return Me.m_BackColor
        End Get
        Set(ByVal value As Color)
            Me.m_BackColor = value
            If Not Me.m_SelectBackColor2 Then
                MyBase.BackColor = Me.m_BackColor
            End If
        End Set
    End Property
    Private Sub SetBackColor()
        If (Me.m_SelectBackColor3) Then
            MyBase.BackColor = Me.BackColor3
        ElseIf (Not Me.m_SelectBackColor2) Then
            MyBase.BackColor = Me.BackColor
        Else
            MyBase.BackColor = Me.BackColor2
        End If
    End Sub
    Public Property BackColor2() As Color
        Get
            Return Me.m_BackColor2
        End Get
        Set(ByVal value As Color)
            Me.m_BackColor2 = value
            If Not Me.m_SelectBackColor2 Then
                MyBase.BackColor = Me.m_BackColor2
            End If
        End Set
    End Property
    Public Property BackColor3 As Color
        Get
            Return Me.m_BackColor3
        End Get
        Set(ByVal value As Color)
            Me.m_BackColor3 = value
            Me.SetBackColor()
        End Set
    End Property

    <Category("Appearance")>
    Public Property SelectBackColor2() As Boolean
        Get
            Return Me.m_SelectBackColor2
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_SelectBackColor2 Then
                Me.m_SelectBackColor2 = value
                If Not value Then
                    MyBase.BackColor = Me.m_BackColor
                Else
                    MyBase.BackColor = Me.m_BackColor2
                End If
                Me.Invalidate()
                Me.OnSelectBackColor2Changed(EventArgs.Empty)
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property SelectBackColor3 As Boolean
        Get
            Return Me.m_SelectBackColor3
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.m_SelectBackColor3) Then
                Me.m_SelectBackColor3 = value
                Me.SetBackColor()
                MyBase.Invalidate()
                Me.OnSelectBackColor2Changed(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.m_BackColor = Color.Transparent
        Me.m_BackColor2 = Color.Green
        Me.m_BackColor3 = Color.Red
    End Sub


    Protected Overridable Sub OnSelectBackColor2Changed(ByVal e As EventArgs)
        RaiseEvent SelectBackColor2Changed(Me, e)
    End Sub

    Public Event SelectBackColor2Changed As EventHandler
End Class

