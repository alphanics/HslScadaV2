Imports System
Imports System.Windows.Forms

Public Class KeyboardInput
    Inherits TextBox
    Private int_0 As Integer

    Private int_1 As Integer

    Private bool_0 As Boolean

    Public Property ClearAfterEnterKey As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            Me.bool_0 = value
        End Set
    End Property

    Public Property GetFocusMatchValue As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            Me.int_1 = value
        End Set
    End Property

    Public Property GetFocusValue As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (Me.int_0 <> value) Then
                Me.int_0 = value
                If (Me.int_0 = Me.int_1) Then
                    MyBase.Focus()
                End If
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.int_1 = 1
    End Sub

    Protected Overridable Sub OnEnterKeyPressed(ByVal e As EventArgs)
        RaiseEvent EnterKeyPressed(Me, e)
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal keyPresse As KeyPressEventArgs)
        If (keyPresse.KeyChar <> Convert.ToChar(13)) Then
            MyBase.OnKeyPress(keyPresse)
        Else
            Me.OnEnterKeyPressed(EventArgs.Empty)
            If (Me.bool_0) Then
                Me.Text = String.Empty
            End If
            keyPresse.Handled = True
        End If
    End Sub

    Protected Overrides Sub OnVisibleChanged(ByVal e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If (MyBase.Visible And Me.int_0 = Me.int_1) Then
            MyBase.Focus()
        End If
    End Sub

    Public Event EnterKeyPressed As EventHandler

End Class
