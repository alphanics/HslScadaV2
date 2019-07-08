Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Drawing
Imports System.Windows.Forms

Public Class BasicChart
    Inherits Control
    ' Methods
    Public Sub New()
        AddHandler Me.observableCollection_0.CollectionChanged, New NotifyCollectionChangedEventHandler(AddressOf Me.observableCollection_0_CollectionChanged)
        MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        MyBase.BackColor = Color.Black
        Me.solidBrush_0 = New SolidBrush(Color.Black)
    End Sub

    Private Sub observableCollection_0_CollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If (Me.observableCollection_0.Count > Me.int_1) Then
            Me.observableCollection_0.RemoveAt(0)
        End If
        Me.int_0 = 1
        Dim num As Integer
        For Each num In Me.observableCollection_0
            Me.int_0 = Math.Max(Me.int_0, num)
        Next
        Me.int_0 = Me.int_3
        Me.list_0.Clear
        If (Me.observableCollection_0.Count > 1) Then
            Dim num2 As Single = CSng((CDbl(MyBase.Width) / CDbl((Me.observableCollection_0.Count - 1))))
            Dim i As Integer
            For i = 0 To Me.observableCollection_0.Count - 1
                Me.list_0.Add(New PointF((num2 * i), CSng((MyBase.Height - ((CDbl((Me.observableCollection_0(i) - Me.int_2)) / CDbl((Me.int_0 - Me.int_2))) * MyBase.Height)))))
            Next i
        End If
        MyBase.Invalidate
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Me.bitmap_0 = New Bitmap(MyBase.Width, MyBase.Height)
        Dim graphics As Graphics = Graphics.FromImage(Me.bitmap_0)
        graphics.FillRectangle(Me.solidBrush_0, 0, 0, MyBase.Width, MyBase.Height)
        If (Me.observableCollection_0.Count > 1) Then
            Dim i As Integer
            For i = 0 To (Me.observableCollection_0.Count - 1) - 1
                Try
                    graphics.DrawLine(Pens.Blue, Me.list_0(i), Me.list_0((i + 1)))
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    ProjectData.ClearProjectError
                End Try
            Next i
        End If
        graphics.DrawLine(Pens.White, 0, 0, 0, MyBase.Height)
        graphics.DrawLine(Pens.White, 0, (MyBase.Height - 1), MyBase.Width, (MyBase.Height - 1))
        Using font As Font = New Font("Arial", 10!)
            graphics.DrawString(Me.int_0.ToString, font, Brushes.White, CSng(0!), CSng(0!))
            graphics.DrawString(Me.int_2.ToString, font, Brushes.White, 0!, CSng((MyBase.Height - &H10)))
        End Using
        e.Graphics.DrawImageUnscaled(Me.bitmap_0, 0, 0)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub


    ' Properties
    Public Property Value As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            Try
                If Not String.IsNullOrEmpty(value) Then
                    Me.observableCollection_0.Add(CInt(Math.Round(CDbl(Conversions.ToSingle(value)))))
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError
            End Try
        End Set
    End Property

    Public ReadOnly Property Points As ObservableCollection(Of Integer)
        Get
            Return Me.observableCollection_0
        End Get
    End Property

    Public Property MaxPoints As Integer
        Get
            Return Me.int_1
        End Get
        Set(ByVal value As Integer)
            Me.int_1 = value
        End Set
    End Property

    Public Property YMinimum As Integer
        Get
            Return Me.int_2
        End Get
        Set(ByVal value As Integer)
            If (Me.int_2 <> value) Then
                Me.int_2 = value
                MyBase.Invalidate
            End If
        End Set
    End Property

    Public Property YMaximum As Integer
        Get
            Return Me.int_3
        End Get
        Set(ByVal value As Integer)
            If (Me.int_3 <> value) Then
                Me.int_3 = value
                Me.int_0 = value
                MyBase.Invalidate
            End If
        End Set
    End Property

    Public Overrides Property BackColor As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            If (MyBase.BackColor <> value) Then
                MyBase.BackColor = value
                Me.solidBrush_0 = New SolidBrush(value)
            End If
        End Set
    End Property


    ' Fields
    Private int_0 As Integer
    Private list_0 As List(Of PointF) = New List(Of PointF)
    Private bitmap_0 As Bitmap
    Private observableCollection_0 As ObservableCollection(Of Integer) = New ObservableCollection(Of Integer)
    Private int_1 As Integer = 100
    Private int_2 As Integer
    Private int_3 As Integer = &H7FFF
    Private solidBrush_0 As SolidBrush
End Class

