Imports System
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Linq

<Editor(GetType(RotationValueEditor), GetType(UITypeEditor)), TypeConverter(GetType(RotationTypeConverter))>
Public Class RotationScale
    Private m_RotationCCWAngle As Single

    Private m_RotationCWAngle As Single

    Private m_RotationMaxValueCCW As Single

    Private m_RotationMaxValueCW As Single

    Private m_XPosition As Integer

    Private m_YPosition As Integer

    Public Property RotationCCWAngle() As Single
        Get
            Return Me.m_RotationCCWAngle
        End Get
        Set(ByVal value As Single)
            Me.m_RotationCCWAngle = value
        End Set
    End Property

    Public Property RotationCWAngle() As Single
        Get
            Return Me.m_RotationCWAngle
        End Get
        Set(ByVal value As Single)
            Me.m_RotationCWAngle = value
        End Set
    End Property

    Public Property RotationMaxValueCCW() As Single
        Get
            Return Me.m_RotationMaxValueCCW
        End Get
        Set(ByVal value As Single)
            Me.m_RotationMaxValueCCW = value
        End Set
    End Property

    Public Property RotationMaxValueCW() As Single
        Get
            Return Me.m_RotationMaxValueCW
        End Get
        Set(ByVal value As Single)
            Me.m_RotationMaxValueCW = value
        End Set
    End Property

    Public Property XPosition() As Integer
        Get
            Return Me.m_XPosition
        End Get
        Set(ByVal value As Integer)
            Me.m_XPosition = value
        End Set
    End Property

    Public Property YPosition() As Integer
        Get
            Return Me.m_YPosition
        End Get
        Set(ByVal value As Integer)
            Me.m_YPosition = value
        End Set
    End Property

    Public Sub New()
        Me.m_RotationCWAngle = 90.0F
        Me.m_RotationMaxValueCCW = 0.0F
        Me.m_RotationMaxValueCW = 90.0F
    End Sub

    Public Sub New(ByVal rotationCCWAngle As Single, ByVal rotationCWAngle As Single, ByVal rotationMaxValueCCW As Single, ByVal rotationMaxValueCW As Single, ByVal XPosition As Integer, ByVal YPosition As Integer)
        Me.New()
        Me.m_RotationCCWAngle = rotationCCWAngle
        Me.m_RotationCWAngle = rotationCWAngle
        Me.m_RotationMaxValueCW = rotationMaxValueCW
        Me.m_RotationMaxValueCCW = rotationMaxValueCCW
        Me.m_XPosition = XPosition
        Me.m_YPosition = YPosition
    End Sub

    Public Function GetAngle(ByVal value As Single) As Single
        Dim mRotationMaxValueCCW As Single = Me.m_RotationMaxValueCCW - Me.m_RotationMaxValueCW
        Dim mRotationCCWAngle As Single = Me.m_RotationCCWAngle - Me.m_RotationCWAngle
        Return mRotationCCWAngle / mRotationMaxValueCCW * value + Me.m_RotationCCWAngle
    End Function
End Class

