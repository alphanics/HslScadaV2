Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class GroupPanel
    Inherits Panel
    Private color_0 As Color

    Private color_1 As Color

    Private color_2 As Color

    Private bool_0 As Boolean

    Private bool_1 As Boolean

    Public Shadows Property BackColor As Color
        Get
            Return Me.color_0
        End Get
        Set(ByVal value As Color)
            Me.color_0 = value
            Me.method_0()
        End Set
    End Property

    Public Property BackColor2 As Color
        Get
            Return Me.color_1
        End Get
        Set(ByVal value As Color)
            Me.color_1 = value
            Me.method_0()
        End Set
    End Property

    Public Property BackColor3 As Color
        Get
            Return Me.color_2
        End Get
        Set(ByVal value As Color)
            Me.color_2 = value
            Me.method_0()
        End Set
    End Property

    <Category("Appearance")>
    Public Property SelectBackColor2 As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_0) Then
                Me.bool_0 = value
                Me.method_0()
                MyBase.Invalidate()
                Me.OnSelectBackColor2Changed(EventArgs.Empty)
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property SelectBackColor3 As Boolean
        Get
            Return Me.bool_1
        End Get
        Set(ByVal value As Boolean)
            If (value <> Me.bool_1) Then
                Me.bool_1 = value
                Me.method_0()
                MyBase.Invalidate()
                Me.OnSelectBackColor2Changed(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.color_0 = Color.Transparent
        Me.color_1 = Color.Green
        Me.color_2 = Color.Red
    End Sub

    Private Sub method_0()
        If (Me.bool_1) Then
            MyBase.BackColor = Me.color_2
        ElseIf (Not Me.bool_0) Then
            MyBase.BackColor = Me.color_0
        Else
            MyBase.BackColor = Me.color_1
        End If
    End Sub

    Protected Overridable Sub OnSelectBackColor2Changed(ByVal e As EventArgs)
        RaiseEvent SelectBackColor2Changed(Me, e)
    End Sub

    Public Event SelectBackColor2Changed As EventHandler

End Class
