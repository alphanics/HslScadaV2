Imports System.ComponentModel
Imports System.Windows.Forms
Public Class Repeat_Button

    Inherits Button

    Private m_timerRepeater As Timer 'timer to measure repeat intervals wait.
    Private m_components As IContainer 'Components collection of this control (timer)
    Private m_disposed As Boolean = False 'flag used to prevent multiple disposing in Dispose method
    Private m_mouseDownArgs As MouseEventArgs = Nothing 'mouse down arguments; used by timer when repeating events.

#Region "Constructor"

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        InitialDelay = 400
        RepeatInterval = 62

    End Sub

    Private Sub InitializeComponent()
        Me.m_components = New System.ComponentModel.Container()
        Me.m_timerRepeater = New System.Windows.Forms.Timer(Me.m_components)
        Me.SuspendLayout()
        AddHandler m_timerRepeater.Tick, AddressOf Me.timerRepeater_Tick
        Me.ResumeLayout(False)
    End Sub

    '****************************************************************
    '* UserControl overrides dispose to clean up the component list.
    '****************************************************************
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        Try
            If Not m_disposed Then
                If disposing Then
                    'If SubScriptions IsNot Nothing Then
                    '    SubScriptions.dispose()
                    'End If
                    If m_components IsNot Nothing Then
                        m_components.Dispose()
                    End If
                    m_timerRepeater.Dispose()
                End If
            End If
        Finally
            m_disposed = True
            MyBase.Dispose(disposing)
        End Try

    End Sub

#End Region

#Region "Basic Properties"

    ''' <summary>
    ''' Initial delay. Time in milliseconds between button press and first repeat action.
    ''' </summary>
    <DefaultValue(400)>
    <Category("Enhanced")>
    <Description("Initial delay. Time in milliseconds between button press and first repeat action.")>
    Private m_InitialDelay As Integer
    Public Property InitialDelay() As Integer
        Get
            Return m_InitialDelay
        End Get
        Set
            If Value > 0 Then
                m_InitialDelay = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Repeat Interval. Repeat between each repeat action while button is hold pressed.
    ''' </summary>
    <DefaultValue(62)>
    <Category("Enhanced")>
    <Description("Repeat Interval. Repeat between each repeat action while button is hold pressed.")>
    Private m_RepeatInterval As Integer
    Public Property RepeatInterval() As Integer
        Get
            Return m_RepeatInterval
        End Get
        Set
            m_RepeatInterval = Value
        End Set
    End Property

#End Region

#Region "Events"

    ''' <summary>
    ''' Initiates timer, that issues <c>MouseUp</c> event every <c>RepeatIteral</c> milliseconds. For the first time 
    ''' event is fires after <c>InitialDelay</c> milliseconds.
    ''' </summary>
    ''' <param name="mevent"></param>
    Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
        'Save arguments
        m_mouseDownArgs = mevent
        m_timerRepeater.Enabled = False
        timerRepeater_Tick(Nothing, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Repeat loop happens in thin event handler handler using the following logic:
    ''' If handler is called for the first time, it fires <c>MouseDown</c> event and waits <c>InitialDelay</c>
    ''' milliseconds till next iteration. Every next iteration is called with delay of <c>RepeatDelay</c>
    ''' milliseconds.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub timerRepeater_Tick(sender As Object, e As EventArgs)

        MyBase.OnMouseDown(m_mouseDownArgs)
        If m_timerRepeater.Enabled Then
            m_timerRepeater.Interval = RepeatInterval
        Else
            m_timerRepeater.Interval = InitialDelay
        End If

        m_timerRepeater.Enabled = True

    End Sub

    ''' <summary>
    ''' Disables timer and repetitions.
    ''' </summary>
    ''' <param name="mevent"></param>
    Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)
        MyBase.OnMouseUp(mevent)
        m_timerRepeater.Enabled = False
    End Sub

#End Region

End Class