Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Net
Imports System.Net.Mail

Public Class Emailer
    Inherits Component
    ' Methods
    Public Sub New()
        Me.mailMessage_0.Subject = "Email from AdvancedHMI Emailer"
        Me.smtpClient_0 = New SmtpClient
        Me.smtpClient_0.Port = &H19
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If (Me.smtpClient_0 > Nothing) Then
                    Me.smtpClient_0.Dispose
                End If
                If (Me.mailMessage_0 > Nothing) Then
                    Me.mailMessage_0.Dispose
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Public Sub SendMessage()
        If Not String.IsNullOrEmpty(Me.string_0) Then
            Me.smtpClient_0.UseDefaultCredentials = False
            Me.smtpClient_0.Credentials = New NetworkCredential(Me.string_0, Me.string_1)
        End If
        Me.smtpClient_0.Send(Me.mailMessage_0)
    End Sub


    ' Properties
    Public Property SmtpServer As String
        Get
            Return Me.smtpClient_0.Host
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                Me.smtpClient_0.Host = value
            End If
        End Set
    End Property

    Public Property SmtpPort As Integer
        Get
            Return Me.smtpClient_0.Port
        End Get
        Set(ByVal value As Integer)
            Me.smtpClient_0.Port = value
        End Set
    End Property

    Public Property UseSsl As Boolean
        Get
            Return Me.smtpClient_0.EnableSsl
        End Get
        Set(ByVal value As Boolean)
            Me.smtpClient_0.EnableSsl = value
        End Set
    End Property

    Public Property SmtpLoginUserName As String
        Get
            Return Me.string_0
        End Get
        Set(ByVal value As String)
            Me.string_0 = value
        End Set
    End Property

    Public Property SmtpLoginPassword As String
        Get
            Return Me.string_1
        End Get
        Set(ByVal value As String)
            Me.string_1 = value
        End Set
    End Property

    Public Property MessageTo As String
        Get
            If (Me.mailMessage_0.To.Count > 0) Then
                Return Me.mailMessage_0.To(0).ToString
            End If
            Return ""
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                Me.mailMessage_0.To.Clear
                Me.mailMessage_0.To.Add(value)
            End If
        End Set
    End Property

    Public Property MessageFrom As String
        Get
            If (Me.mailMessage_0.From > Nothing) Then
                Return Me.mailMessage_0.From.ToString
            End If
            Return ""
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                Me.mailMessage_0.From = New MailAddress(value)
            End If
        End Set
    End Property

    Public Property MessageSubject As String
        Get
            Return Me.mailMessage_0.Subject
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                Me.mailMessage_0.Subject = value
            End If
        End Set
    End Property

    <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))> _
    Public Property MessageBody As String
        Get
            Return Me.mailMessage_0.Body
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                Me.mailMessage_0.Body = value
            End If
        End Set
    End Property


    ' Fields
    Private mailMessage_0 As MailMessage = New MailMessage
    Private smtpClient_0 As SmtpClient
    Private string_0 As String = ""
    Private string_1 As String
End Class

