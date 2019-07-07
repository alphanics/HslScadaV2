Imports System
Imports System.Windows.Forms

Public Class MainMenu
    Inherits Form
    Private menuPos_0 As MenuPos

    Public Property MenuPosition As MenuPos
        Get
            Return Me.menuPos_0
        End Get
        Set(ByVal value As MenuPos)
            Me.menuPos_0 = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub
End Class
