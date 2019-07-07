Imports System

Public Class KeypadEventArgs
    Inherits EventArgs
    Private string_0 As String

    Public ReadOnly Property Key As String
        Get
            Return Me.string_0
        End Get
    End Property

    Public Sub New(ByVal Key As String)
        MyBase.New()
        Me.string_0 = Key
    End Sub
End Class
