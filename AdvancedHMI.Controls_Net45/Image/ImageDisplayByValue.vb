Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public Class ImageDisplayByValue
    Inherits Label

    Public Sub New()

        Me.AutoSize = False
        If (MyBase.ForeColor = Color.FromKnownColor(KnownColor.ControlText)) Or (Me.ForeColor = Color.FromArgb(0, 0, 0, 0)) Then
            Me.ForeColor = Color.Black
        End If
    End Sub



    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Dim i As Integer = 0
        Dim count As Integer = Me.Parent.Site.Container.Components.Count
        Do While MyBase.ImageList Is Nothing And i < count
            If Operators.CompareString(DirectCast(Me.Parent.Site.Container.Components(i), Object).GetType().ToString(), "System.Windows.Forms.ImageList", False) = 0 Then
                Me.ImageList = DirectCast(Me.Parent.Site.Container.Components(i), ImageList)
            End If
            i += 1
        Loop
        If MyBase.ImageList Is Nothing Then
            Me.Parent.Site.Container.Add(New ImageList())
            MyBase.ImageList = DirectCast(Me.Parent.Site.Container.Components(Me.Parent.Site.Container.Components.Count - 1), ImageList)
        End If
        MyBase.ImageIndex = 0
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Try
            If (If(Me.ImageList Is Nothing OrElse Me.ImageList.Images Is Nothing OrElse Me.ImageList.Images.Count <= 0 OrElse Me.ImageList.Images(0) Is Nothing, False, True)) Then
                e.Graphics.DrawImage(Me.ImageList.Images(0), 0, 0, Me.Width, Me.Height)
            End If
        Catch

        End Try
    End Sub
End Class

