Imports MfgControl.AdvancedHMI.Controls.Common
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Threading

Public Class EmailerEx
    Inherits Emailer
    ' Events
    Public Event SendingError As EventHandler(Of BaseEventArgs)
    Public Event ValueChanged As EventHandler

    ' Methods
    Private Sub method_0()
        Dim errorMessage As String = ""
        If String.IsNullOrEmpty(MyBase.SmtpServer) Then
            errorMessage = (errorMessage & "SmtpServer not set.")
        End If
        If String.IsNullOrEmpty(MyBase.MessageTo) Then
            errorMessage = (errorMessage & "MessageTo not set.")
        End If
        Me.OnSendingError(New BaseEventArgs(200, errorMessage))
    End Sub

    Protected Overridable Sub OnSendingError(ByVal basee As BaseEventArgs)
        Dim handler As EventHandler(Of BaseEventArgs) = Me.eventHandler_1
        If (Not handler Is Nothing) Then
            handler.Invoke(Me, basee)
        End If
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        Dim handler As EventHandler = Me.eventHandler_0
        If (Not handler Is Nothing) Then
            handler.Invoke(Me, e)
        End If
        If (Me.TriggerType = TriggerTypeEnum.ValueChange) Then
            MyBase.SendMessage
        ElseIf ((Me.TriggerType = TriggerTypeEnum.BooleanValueTrue) And (String.Compare(Me.Value, "True", True) = 0)) Then
            MyBase.SendMessage
        ElseIf ((Me.TriggerType = TriggerTypeEnum.BooleanValueFalse) And (String.Compare(Me.Value, "False", True) = 0)) Then
            MyBase.SendMessage
        ElseIf (((Me.TriggerType = TriggerTypeEnum.AboveTargetValue) Or (Me.TriggerType = TriggerTypeEnum.BelowTargetValue)) Or (Me.TriggerType = TriggerTypeEnum.EqualTargetValue)) Then
            Dim num As Double
            Dim num2 As Double
            If (Double.TryParse(Me.string_3, NumberStyles.Any, DirectCast(NumberFormatInfo.CurrentInfo, IFormatProvider), num) AndAlso Double.TryParse(Me.string_2, NumberStyles.Any, DirectCast(NumberFormatInfo.CurrentInfo, IFormatProvider), num2)) Then
                If (((Me.TriggerType = TriggerTypeEnum.AboveTargetValue) And (num2 > num)) And (Me.double_0 <= num)) Then
                    MyBase.SendMessage
                ElseIf (((Me.TriggerType = TriggerTypeEnum.BelowTargetValue) And (num2 < num)) And (Me.double_0 >= num)) Then
                    MyBase.SendMessage
                ElseIf (((Me.TriggerType = TriggerTypeEnum.EqualTargetValue) And (num2 = num)) And Not (Me.double_0 = num)) Then
                    MyBase.SendMessage
                End If
            End If
            Me.double_0 = Conversions.ToDouble(Me.Value)
        End If
    End Sub


    ' Properties
    Public Property TriggerType As TriggerTypeEnum
        Get
            Return Me.triggerTypeEnum_0
        End Get
        Set(ByVal value As TriggerTypeEnum)
            Me.triggerTypeEnum_0 = value
        End Set
    End Property

    Public Property Value As String
        Get
            Return Me.string_2
        End Get
        Set(ByVal value As String)
            If (value <> Me.string_2) Then
                Me.string_2 = value
                Try
                    Me.OnValueChanged(EventArgs.Empty)
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    ProjectData.ClearProjectError
                End Try
            End If
        End Set
    End Property

    Public Property TargetValue As String
        Get
            Return Me.string_3
        End Get
        Set(ByVal value As String)
            If (value <> Me.string_3) Then
                Me.string_3 = value
            End If
        End Set
    End Property

    Public Property ServerPresets As ServerPresetsEnum
        Get
            Return ServerPresetsEnum.SelectOne
        End Get
        Set(ByVal value As ServerPresetsEnum)
            If (value > ServerPresetsEnum.SelectOne) Then
                If (value = ServerPresetsEnum.GMail) Then
                    MyBase.SmtpServer = "smtp.gmail.com"
                    MyBase.SmtpPort = &H24B
                    MyBase.UseSsl = True
                    MyBase.MessageFrom = "AdvancedHMIAutoEmail@hmi.com"
                ElseIf (value = ServerPresetsEnum.Yahoo) Then
                    MyBase.SmtpServer = "smtp.mail.yahoo.com"
                    MyBase.SmtpPort = &H1D1
                    MyBase.UseSsl = True
                End If
            End If
        End Set
    End Property


    ' Fields
    Private triggerTypeEnum_0 As TriggerTypeEnum = TriggerTypeEnum.ValueChange
    Private string_2 As String
    Private string_3 As String
    Private double_0 As Double

    ' Nested Types
    Public Enum ServerPresetsEnum
        ' Fields
        SelectOne = 0
        GMail = 1
        Yahoo = 2
    End Enum

    Public Enum TriggerTypeEnum
        ' Fields
        ValueChange = 0
        BooleanValueTrue = 1
        BooleanValueFalse = 2
        AboveTargetValue = 3
        BelowTargetValue = 4
        EqualTargetValue = 5
    End Enum
End Class

