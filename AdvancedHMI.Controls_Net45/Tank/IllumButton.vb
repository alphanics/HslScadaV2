Option Explicit On
Option Strict On
Imports System.Drawing
Imports System.Windows.Forms

Public Class IllumButton
    Inherits Control

#Region "Notes:"
    '// Title:    IllumButton
    '// Author:   Morgan Haueisen
    '// Created:  5/24/2016

    ' This software is provided "as-is," without any express or implied warranty.
    ' In no event shall the author be held liable for any damages arising from the use of this software.
    ' If you do not agree with these terms, do not use "IllumButton". Use of the program implicitly means
    ' you have agreed to these terms.

    ' Permission is granted to anyone to use this software for any purpose,
    ' including commercial use, and to alter and redistribute it.
#End Region

#Region "Constructor/Destructor"
    Public Sub New()
        MyBase.New()
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Padding = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(32, 32)
        Me.Name = "IllumButton"
        Me.Size = New System.Drawing.Size(75, 75)
        Me.ResumeLayout(False)
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub




#End Region

#Region "Properties and variables"
    Private mErrMsg As String = String.Empty
    Private mButtonDn As Boolean = False
    Private mValue As Boolean = False

    Private mButtonUp As Image
    Public Property Button1Up As Image
        Get
            Return mButtonUp
        End Get
        Set(ByVal value As Image)
            mButtonUp = value
            Me.Invalidate()
        End Set
    End Property
    Private mButtonPressed As Image
    Public Property Button2Pressed As Image
        Get
            Return mButtonPressed
        End Get
        Set(ByVal value As Image)
            mButtonPressed = value
            Me.Invalidate()
        End Set
    End Property
    Private mButtonOn As Image
    Public Property Button3On As Image
        Get
            Return mButtonOn
        End Get
        Set(ByVal value As Image)
            mButtonOn = value
            Me.Invalidate()
        End Set
    End Property
    Private mOutputType As OutputType = OutputType.MomentarySet
    <System.ComponentModel.Category("PLC Properties")>
    Public Property OutputType As OutputType
        Get
            Return mOutputType
        End Get
        Set(ByVal value As OutputType)
            mOutputType = value
        End Set
    End Property
    Private m_ValueToWrite As Integer = 0
    <System.ComponentModel.Category("PLC Properties")>
    Public Property ValueToWrite As Integer
        Get
            Return m_ValueToWrite
        End Get
        Set(ByVal value As Integer)
            m_ValueToWrite = value
        End Set
    End Property
#End Region

#Region "Draw Button"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim iImage As Image

        '// Get image to draw
        If mValue Then
            iImage = mButtonOn
        ElseIf mButtonDn Then
            iImage = mButtonPressed
        Else
            iImage = mButtonUp
        End If

        '// Draw Image
        If Not iImage Is Nothing Then
            e.Graphics.DrawImage(iImage, 0, 0, Me.ClientRectangle.Width, Me.ClientRectangle.Width)
        End If

        If Not String.IsNullOrWhiteSpace(mErrMsg) Then
            '// Draw Text
            Dim strFormat As StringFormat = New StringFormat()
            strFormat.LineAlignment = StringAlignment.Center
            strFormat.Alignment = StringAlignment.Near
            e.Graphics.DrawString(mErrMsg, New Font("Arial", 8), New SolidBrush(Color.White), New Point(10, 10), strFormat)
        End If

    End Sub

    Private Sub IllumButton_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SizeChanged
        '// Keep the control square so that the button is always round
        Dim iSize As Integer = 0
        If Me.Width > Me.Height Then
            iSize = Me.Height
            Me.Width = iSize
        Else
            iSize = Me.Width
            Me.Height = iSize
        End If
    End Sub
#End Region



#Region "Button Pressed minimum hold time"
    Private mMouseIsDown As Boolean
    Private mHoldTimeMet As Boolean

    '*****************************************
    '* Property - Hold time before bit reset
    '*****************************************
    Private WithEvents MinHoldTimer As New System.Windows.Forms.Timer
    Private m_MinimumHoldTime As Integer = 500
    <System.ComponentModel.Category("PLC Properties")>
    Public Property MinimumHoldTime() As Integer
        Get
            Return m_MinimumHoldTime
        End Get
        Set(ByVal value As Integer)
            m_MinimumHoldTime = value
            If value > 0 Then MinHoldTimer.Interval = value
        End Set
    End Property

    Private Sub HoldTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinHoldTimer.Tick
        MinHoldTimer.Enabled = False
        mHoldTimeMet = True
        If Not mMouseIsDown Then

        End If
    End Sub


#End Region







End Class