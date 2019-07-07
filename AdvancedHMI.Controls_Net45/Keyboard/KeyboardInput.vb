Imports System
Imports System.Windows.Forms


Public Class KeyboardInput
    Inherits TextBox
    Public Event EnterKeyPressed As EventHandler
    Private m_GetFocusValue As Integer

    Private m_GetFocusMatchValue As Integer

    Private m_ClearAfterEnterKey As Boolean

    Public Property ClearAfterEnterKey As Boolean
        Get
            Return Me.m_ClearAfterEnterKey
        End Get
        Set(ByVal value As Boolean)
            Me.m_ClearAfterEnterKey = value
        End Set
    End Property

    Public Property GetFocusMatchValue As Integer
        Get
            Return Me.m_GetFocusMatchValue
        End Get
        Set(ByVal value As Integer)
            Me.m_GetFocusMatchValue = value
        End Set
    End Property

    Public Property GetFocusValue As Integer
        Get
            Return Me.m_GetFocusValue
        End Get
        Set(ByVal value As Integer)
            If (Me.m_GetFocusValue <> value) Then
                Me.m_GetFocusValue = value
                If (Me.m_GetFocusValue = Me.m_GetFocusMatchValue) Then
                    MyBase.Focus()
                End If
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.m_GetFocusMatchValue = 1
    End Sub

    Protected Overridable Sub OnEnterKeyPressed(ByVal e As EventArgs)
        RaiseEvent EnterKeyPressed(Me, e)
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        If (e.KeyChar <> Convert.ToChar(13)) Then
            MyBase.OnKeyPress(e)
        Else
            Me.OnEnterKeyPressed(EventArgs.Empty)
            If (Me.m_ClearAfterEnterKey) Then
                Me.Text = String.Empty
            End If
            e.Handled = True
        End If
    End Sub



End Class

