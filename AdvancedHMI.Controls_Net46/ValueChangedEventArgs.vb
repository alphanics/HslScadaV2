Imports System

Public Class ValueChangedEventArgs
    Inherits EventArgs
    Private long_0 As Long

    Private long_1 As Long

    Private int_0 As Integer

    Public Property BitNumber As Integer
        Get
            Return Me.int_0
        End Get
        Set(ByVal value As Integer)
            Me.int_0 = value
        End Set
    End Property

    Public Property NewValue As Long
        Get
            Return Me.long_0
        End Get
        Set(ByVal value As Long)
            Me.long_0 = value
        End Set
    End Property

    Public Property OldValue As Long
        Get
            Return Me.long_1
        End Get
        Set(ByVal value As Long)
            Me.long_1 = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal newValue As Long)
        MyBase.New()
        Me.long_0 = newValue
    End Sub

    Public Sub New(ByVal newValue As Long, ByVal oldValue As Long)
        MyClass.New(newValue)
        Me.long_1 = oldValue
    End Sub

    Public Sub New(ByVal newValue As Long, ByVal oldValue As Long, ByVal bitNumber As Integer)
        MyClass.New(newValue, oldValue)
        Me.int_0 = bitNumber
    End Sub
End Class
