Imports System
Imports System.ComponentModel
Imports System.Linq

<TypeConverter(GetType(TranslationScaleTypeConverter))>
Public Class TranslationScale
    Private m_InputMinValue As Double

    Private m_InputMaxValue As Double

    Private m_OutputMinValue As Double

    Private m_OutputMaxValue As Double

    Private m_ErrorValue As Double

    Public Property ErrorValue() As Double
        Get
            Return Me.m_ErrorValue
        End Get
        Set(ByVal value As Double)
            Me.m_ErrorValue = value
        End Set
    End Property

    Public Property InputMaxValue() As Double
        Get
            Return Me.m_InputMaxValue
        End Get
        Set(ByVal value As Double)
            Me.m_InputMaxValue = value
        End Set
    End Property

    Public Property InputMinValue() As Double
        Get
            Return Me.m_InputMinValue
        End Get
        Set(ByVal value As Double)
            Me.m_InputMinValue = value
        End Set
    End Property

    Public Property OutputMaxValue() As Double
        Get
            Return Me.m_OutputMaxValue
        End Get
        Set(ByVal value As Double)
            Me.m_OutputMaxValue = value
        End Set
    End Property

    Public Property OutputMinValue() As Double
        Get
            Return Me.m_OutputMinValue
        End Get
        Set(ByVal value As Double)
            Me.m_OutputMinValue = value
        End Set
    End Property

    Public Sub New()
        Me.m_InputMaxValue = 100
        Me.m_OutputMaxValue = 100
    End Sub

    Public Sub New(ByVal inputMinValue As Double, ByVal inputMaxValue As Double, ByVal outputMinValue As Double, ByVal outputMaxValue As Double)
        Me.New()
        Me.m_InputMinValue = inputMinValue
        Me.m_InputMaxValue = inputMaxValue
        Me.m_OutputMinValue = outputMinValue
        Me.m_OutputMaxValue = outputMaxValue
    End Sub

    Public Function GetValue(ByVal value As Double) As Double
        Dim num As Double
        Dim mInputMaxValue As Double = Me.m_InputMaxValue - Me.m_InputMinValue
        Dim mOutputMaxValue As Double = Me.m_OutputMaxValue - Me.m_OutputMinValue
        num = (If(mInputMaxValue = 0, Me.m_ErrorValue, (value - Me.m_InputMinValue) * (mOutputMaxValue / mInputMaxValue) + Me.m_OutputMinValue))
        Return num
    End Function
End Class

