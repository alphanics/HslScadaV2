Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class GifAnimator
    Inherits Control
    Private eventHandler_0 As EventHandler

    Private image_0 As System.Drawing.Image

    Private bool_0 As Boolean

    Public Property Image As System.Drawing.Image
        Get
            Return Me.image_0
        End Get
        Set(ByVal value As System.Drawing.Image)
            Me.image_0 = value
            Me.Value = Me.bool_0
        End Set
    End Property

    Public Property Value As Boolean
        Get
            Return Me.bool_0
        End Get
        Set(ByVal value As Boolean)
            Me.bool_0 = value
            If (If(Me.image_0 Is Nothing, False, ImageAnimator.CanAnimate(Me.image_0))) Then
                If (Not Me.bool_0) Then
                    ImageAnimator.StopAnimate(Me.image_0, Me.eventHandler_0)
                Else
                    ImageAnimator.Animate(Me.image_0, Me.eventHandler_0)
                End If
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.eventHandler_0 = New EventHandler(AddressOf Me.method_0)
    End Sub

    Private Sub method_0(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        MyBase.OnPaint(painte)
        If (Me.image_0 IsNot Nothing) Then
            ImageAnimator.UpdateFrames()
            painte.Graphics.DrawImage(Me.image_0, New Point(0, 0))
        End If
    End Sub
End Class
