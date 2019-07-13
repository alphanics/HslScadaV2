Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms



<System.ComponentModel.Designer(GetType(ListViewDesigner))>
Public Class DataSubscriberlistView
    Inherits ListView
    Dim intCount As Integer = 0
    Dim nTime As String = "2017/12/18 16:44:02"
    Dim nTagName As String = "TagName"
    Dim nTagValue As String = "15135"
    Dim nTagStatus() As String = New String(3) {"Alarm On", "Alarm oFF", "Alarm Ack", "Alarm Variation"}
    Dim nColor() As Color = New Color(3) {Color.Red, Color.Green, Color.Blue, Color.Yellow}
#Region "Constructor/Destructor"
    Public Sub New()
        Me.DoubleBuffered = True
        With Me
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Columns.Clear()
            .Items.Clear()
            .Columns.Add("Time", 130, HorizontalAlignment.Left)
            .Columns.Add("Tag Name", 130, HorizontalAlignment.Left)
            .Columns.Add("Tag Value", 130, HorizontalAlignment.Left)
            .Columns.Add("Tag Status", 320, HorizontalAlignment.Left)
            .HeaderStyle = ColumnHeaderStyle.Nonclickable
        End With

        For index = 0 To 19
            Dim row0 As String() = {nTime, nTagName, nTagValue, nTagStatus(intCount)}
            Dim item As New ListViewItem(row0)
            item.ForeColor = nColor(intCount)
            Me.Items.Insert(0, item)
            intCount = intCount + 1
            If intCount = 3 Then
                intCount = 0
            End If

        Next

    End Sub

    Public Property NListViewColumns As List(Of String)
    Public Property NListViewColumnsColor As List(Of String)

#End Region


End Class
