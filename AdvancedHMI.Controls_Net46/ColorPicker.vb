Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ColorPicker
    Inherits Button

    Public Event ColorChanged As EventHandler

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        Me.Cursor = Cursors.Hand
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderColor = Color.Silver
        Me.TextAlign = ContentAlignment.MiddleCenter
        Me.BackColor = Color.White
        Me.ForeColor = Color.Black
        Me.Size = New System.Drawing.Size(200, 30)
        Me.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
        Me.AutoEllipsis = True

    End Sub

#End Region

#Region "Basic Properties"

    Private m_SelectedColor As System.Drawing.Color
    Public Property SelectedColor As System.Drawing.Color
        Get
            Return m_SelectedColor
        End Get
        Set(value As System.Drawing.Color)
            If m_SelectedColor <> value Then
                m_SelectedColor = value

                Me.ForeColor = Color.Black

                Invalidate()
                OnValueChanged(EventArgs.Empty)

            End If
        End Set
    End Property

    Private m_ShowText As Boolean = False
    Public Property ShowText As Boolean
        Get
            Return m_ShowText
        End Get
        Set(value As Boolean)
            If m_ShowText <> value Then
                m_ShowText = value

                Invalidate()

            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles Me.Click

        Dim cDialog As New ColorDialog()

        If SelectedColor.A <> 0 Then
            cDialog.Color = SelectedColor
        End If

        cDialog.AllowFullOpen = True
        cDialog.AnyColor = True
        cDialog.SolidColorOnly = False
        cDialog.ShowHelp = True

        If (cDialog.ShowDialog() = DialogResult.OK) Then
            Dim c = cDialog.Color.ToArgb
            SelectedColor = Color.FromArgb(c)
        End If

    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ColorChanged(Me, e)
    End Sub

    Private Sub ColorPicker_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        Dim c = m_SelectedColor
        If m_SelectedColor <> Color.Empty AndAlso c.A <> 0 Then 'Don't paint if no color or transparent ("a" = 0)
            Using myBrush As New SolidBrush(m_SelectedColor)
                Dim SampleWidth = Me.Size.Height - 10
                Dim SampleHeight = Me.Size.Height - 10
                Dim Location As Integer = (Me.Size.Height - SampleHeight) / 2
                e.Graphics.FillRectangle(myBrush, 5, Location, SampleWidth, SampleHeight)
                e.Graphics.DrawRectangle(Pens.Black, 5, Location, SampleWidth - 1, SampleHeight)
            End Using

            If m_SelectedColor <> Color.Empty AndAlso m_SelectedColor <> Color.Transparent AndAlso ShowText Then
                Me.Text = m_SelectedColor.ToString
            Else
                Me.Text = ""
            End If
        End If

    End Sub

#End Region

End Class