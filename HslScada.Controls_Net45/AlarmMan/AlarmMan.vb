Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AdvancedScada.DriverBase.Common

<System.ComponentModel.Designer(GetType(ListViewDesigner))>
Public Class AlarmMan
    Inherits ListView
    Dim intCount As Integer = 0
    Dim nTime As String = "2017/12/18 16:44:02"
    Dim nTagName As String = "TagName"
    Dim nTagValue As String = "15135"
    Dim nTagStatus() As String = New String(3) {"Alarm On", "Alarm oFF", "Alarm Ack", "Alarm Variation"}
    Dim nColor() As Color = New Color(3) {Color.Red, Color.Green, Color.Blue, Color.Yellow}
    Private _NListViewColumns As List(Of String)
    Private _NListViewColumnsColor As List(Of String)
#Region "Constructor/Destructor"
    Public Sub New()
        Me.DoubleBuffered = True
        With Me
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Columns.Clear()
            .Items.Clear()
            .Columns.Add("Tag Name", 130, HorizontalAlignment.Left)
            .Columns.Add("Tag Value", 130, HorizontalAlignment.Left)
            .Columns.Add("Time", 130, HorizontalAlignment.Left)
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
        Get
            Return _NListViewColumns
        End Get
        Set
            _NListViewColumns = Value
        End Set
    End Property

    Public Property NListViewColumnsColor As List(Of String)
        Get
            Return _NListViewColumnsColor
        End Get
        Set
            _NListViewColumnsColor = Value
        End Set
    End Property

#End Region
    Public Sub AlarmMan_DataChanged(senderPlcAddress As String, e As PlcComEventArgs)
        Dim LastValue As String = ""
        If e.PlcAddress = senderPlcAddress Then
            Dim row0 As String() = {e.PlcAddress, e.Values(0), Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}

            If e.Values(0) <> LastValue Then
                LastValue = e.Values(0)
                '* Do something here for the value changed
                If LastValue = "True" Then
                    Dim flag As Boolean = False
                    For Each listViewItem As ListViewItem In Me.Items
                        If listViewItem.Text = row0(0) And listViewItem.SubItems(2).Text.Substring(14, 2) = row0(2).Substring(14, 2) Then
                            listViewItem.ForeColor = Color.Red
                            If listViewItem.SubItems(1).Text <> row0(1) Then
                                listViewItem.SubItems(1).Text = row0(1)
                            End If
                            If listViewItem.SubItems(2).Text <> row0(2) Then
                                listViewItem.SubItems(2).Text = row0(2)
                            End If

                            flag = True
                            Exit For
                        End If
                    Next listViewItem
                    If Not flag Then
                        Dim item As New ListViewItem(row0)
                        item.ForeColor = Color.Red
                        Me.Items.Insert(0, item)
                    End If
                ElseIf LastValue = "False" Then
                    Dim row1 As String() = {e.PlcAddress, e.Values(0), Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}

                    Dim flag As Boolean = False
                    For Each listViewItem As ListViewItem In Me.Items
                        If listViewItem.Text = row0(0) And listViewItem.SubItems(2).Text.Substring(14, 2) = row0(2).Substring(14, 2) Then
                            listViewItem.ForeColor = Color.Green
                            If listViewItem.SubItems(1).Text <> row1(1) Then
                                listViewItem.SubItems(1).Text = row1(1)
                            End If
                            If listViewItem.SubItems(2).Text <> row1(2) Then
                                listViewItem.SubItems(2).Text = row1(2)
                            End If
                            flag = True
                            Exit For
                        End If
                    Next listViewItem
                    If Not flag Then
                        Dim item As New ListViewItem(row1)
                        item.ForeColor = Color.Green
                        Me.Items.Insert(0, item)
                    End If
                End If
            End If
        End If
    End Sub

End Class
