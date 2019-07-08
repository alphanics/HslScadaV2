Imports System
Imports System.Windows.Forms

Public Class ImageDisplayByValue2
    Inherits Control
    Private imageCollection_0 As ImageList.ImageCollection

    Private int_0 As Integer

    Public ReadOnly Property Images As ImageList.ImageCollection
        Get
            Return Me.imageCollection_0

        End Get
    End Property

    Public Property Value As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            If (Me.int_0 <> value) Then
                Me.int_0 = value
                MyBase.Invalidate()
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal painte As PaintEventArgs)
        MyBase.OnPaint(painte)
        If (If(Me.imageCollection_0 Is Nothing, False, Me.imageCollection_0.Count > 0)) Then
            Dim num As Integer = Math.Min(Me.int_0, Me.imageCollection_0.Count)
            num = Math.Max(0, num)
            painte.Graphics.DrawImage(Me.imageCollection_0(num), 0, 0)
        End If
    End Sub
End Class
