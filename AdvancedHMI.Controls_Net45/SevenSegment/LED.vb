Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class LED
    Inherits Control
    Public Event ValueChanged As EventHandler
    Public Sub New()

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
                ControlStyles.Selectable Or
                ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.StandardClick Or
                ControlStyles.UserPaint, True)

        Me.BackgroundImageLayout = ImageLayout.Stretch
        If _lEDColors = LEDColor.GreenLED Then
            SetNumberGreen(m_Value)
        Else
            SetNumberRed(m_Value)
        End If

        Me.Size = New Size(50, 50)
        Me.DoubleBuffered = True

    End Sub
    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, e)
    End Sub
    Private m_Value As Integer = 0
    <Category("Numeric Display")>
    Public Property Value() As Integer
        Get
            Return Me.m_Value
        End Get
        Set(ByVal value As Integer)

            If value <> Me.m_Value Then
                If _lEDColors = LEDColor.GreenLED Then
                    SetNumberGreen(value)
                Else
                    SetNumberRed(value)
                End If


                Me.Invalidate()
                Me.OnValueChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property LEDColors As LEDColor
        Get
            Return _lEDColors
        End Get
        Set(ByVal value As LEDColor)
            _lEDColors = value
            If value = LEDColor.GreenLED Then
                Me.SetNumberGreen(m_Value)
            Else
                Me.SetNumberRed(m_Value)
            End If
        End Set
    End Property

    Public Enum LEDColor
        RedLED
        GreenLED
    End Enum
    Private _lEDColors As LEDColor = LEDColor.GreenLED

    Public Function SetNumberGreen(ByVal num As Integer) As Integer

        Select Case num
            Case 0
                BackgroundImage = My.Resources.Green0
            Case 1
                BackgroundImage = My.Resources.Green1
            Case 2
                BackgroundImage = My.Resources.Green2
            Case 3
                BackgroundImage = My.Resources.Green3
            Case 4
                BackgroundImage = My.Resources.Green4
            Case 5
                BackgroundImage = My.Resources.Green5
            Case 6
                BackgroundImage = My.Resources.Green6
            Case 7
                BackgroundImage = My.Resources.Green7
            Case 8
                BackgroundImage = My.Resources.Green8
            Case 9
                BackgroundImage = My.Resources.Green9
            Case Else
                BackgroundImage = My.Resources.Green0
        End Select
        Return num
    End Function
    Public Function SetNumberRed(ByVal num As Integer) As Integer

        Select Case num
            Case 0
                BackgroundImage = My.Resources.RedZero
            Case 1
                BackgroundImage = My.Resources.RedOne
            Case 2
                BackgroundImage = My.Resources.RedTwo
            Case 3
                BackgroundImage = My.Resources.RedThree
            Case 4
                BackgroundImage = My.Resources.RedFour
            Case 5
                BackgroundImage = My.Resources.RedFive
            Case 6
                BackgroundImage = My.Resources.RedSix
            Case 7
                BackgroundImage = My.Resources.RedSeven
            Case 8
                BackgroundImage = My.Resources.RedEight
            Case 9
                BackgroundImage = My.Resources.RedNine
            Case Else
                BackgroundImage = My.Resources.RedZero
        End Select
        Return num
    End Function
End Class

