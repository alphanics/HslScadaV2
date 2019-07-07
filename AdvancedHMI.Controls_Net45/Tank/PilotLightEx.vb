Imports System.Drawing
Imports System.Windows.Forms


Public Class PilotLightEx
    Inherits PilotLight

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim TextRectangle As Rectangle
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        If Me.LegendPlate = LegendPlates.Large Then
            TextRectangle = New Rectangle(0, Me.Height * 0.4, Me.Width, Me.Height * 0.6)
        Else
            TextRectangle = New Rectangle(0, Me.Height * 0.2, Me.Width, Me.Height * 0.8)
        End If

        If Me.Value = True Then
            Dim TextBrush As New SolidBrush(LightColorOnTextColor)
            e.Graphics.DrawString(LightColorOnText, LightColorTextFont, TextBrush, TextRectangle, sf)
        Else
            Dim TextBrush As New SolidBrush(LightColorOffTextColor)
            e.Graphics.DrawString(LightColorOffText, LightColorTextFont, TextBrush, TextRectangle, sf)
        End If

    End Sub

#Region "Properties"

    Private m_LightColorOnText As String = "ON"
    Public Property LightColorOnText As String
        Get
            Return m_LightColorOnText
        End Get
        Set(value As String)
            m_LightColorOnText = value
        End Set
    End Property

    Private m_LightColorOffText As String = "OFF"
    Public Property LightColorOffText As String
        Get
            Return m_LightColorOffText
        End Get
        Set(value As String)
            m_LightColorOffText = value
        End Set
    End Property

    Private m_LightColorTextFont As System.Drawing.Font = Me.Font
    Public Property LightColorTextFont As System.Drawing.Font
        Get
            Return m_LightColorTextFont
        End Get
        Set(value As System.Drawing.Font)
            m_LightColorTextFont = value
        End Set
    End Property

    Private m_LightColorOnTextColor As Color = Color.Black
    Public Property LightColorOnTextColor As Color
        Get
            Return m_LightColorOnTextColor
        End Get
        Set(value As Color)
            m_LightColorOnTextColor = value
        End Set
    End Property

    Private m_LightColorOffTextColor As Color = Color.White
    Public Property LightColorOffTextColor As Color
        Get
            Return m_LightColorOffTextColor
        End Get
        Set(value As Color)
            m_LightColorOffTextColor = value
        End Set
    End Property
#End Region

End Class

