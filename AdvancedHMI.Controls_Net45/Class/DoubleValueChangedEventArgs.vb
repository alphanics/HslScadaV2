Imports System


Public Class DoubleValueChangedEventArgs
    Inherits EventArgs

    Private m_NewValue As Double

    Public Property NewValue() As Double
        Get
            Return Me.m_NewValue
        End Get
        Set(ByVal value As Double)
            Me.m_NewValue = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(ByVal val As Double)
        Me.m_NewValue = val
    End Sub
End Class

