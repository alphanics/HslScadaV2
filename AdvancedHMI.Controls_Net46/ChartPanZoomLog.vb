Imports System
Imports System.Collections.ObjectModel

Public Class ChartPanZoomLog
    Inherits ChartPanZoom
    ' Methods
    Public Sub AddDataPoint(ByVal dataPoint_0 As DataPoint)
        Me.dataLogDB_0.AddDataPoint(dataPoint_0)
        If Me.bool_0 Then
            MyBase.AddPoints(dataPoint_0)
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        Me.dataLogDB_0.dispose
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl
        Dim data As Collection(Of DataPoint) = Me.dataLogDB_0.GetData(500, DateTime.Now)
        MyBase.m_DataPoints.Clear
        Dim point As DataPoint
        For Each point In data
            MyBase.m_DataPoints.Add(point)
        Next
        MyBase.RefreshChart
        Me.bool_0 = True
    End Sub

    Protected Overrides Sub OnPanLeftBeyondData(ByVal panCharte As PanChartEventArgs)
        Dim data As Collection(Of DataPoint) = Me.dataLogDB_0.GetData(Math.Max(500, panCharte.NumberOfPointsOnChart), panCharte.CurrentPointDate)
        If (data.Count > 0) Then
            If (data.Count < panCharte.NumberOfPointsOnChart) Then
                data = Me.dataLogDB_0.GetData(data(0).Timestamp, Math.Max(500, panCharte.NumberOfPointsOnChart))
            End If
            MyBase.m_DataPoints.Clear
            Dim point As DataPoint
            For Each point In data
                MyBase.m_DataPoints.Add(point)
            Next
            panCharte.CurrentPoint = 0
        End If
        Me.bool_0 = False
        MyBase.OnPanLeftBeyondData(panCharte)
    End Sub

    Protected Overrides Sub OnPanRightBeyondData(ByVal panCharte As PanChartEventArgs)
        Dim data As Collection(Of DataPoint) = Me.dataLogDB_0.GetData(panCharte.CurrentPointDate, Math.Max(500, panCharte.NumberOfPointsOnChart))
        If (data.Count > 0) Then
            If (data.Count < panCharte.NumberOfPointsOnChart) Then
                data = Me.dataLogDB_0.GetData(Math.Max(500, panCharte.NumberOfPointsOnChart), data((data.Count - 1)).Timestamp)
            End If
            MyBase.m_DataPoints.Clear
            Dim point As DataPoint
            For Each point In data
                MyBase.m_DataPoints.Add(point)
            Next
        End If
        panCharte.CurrentPoint = ((panCharte.CurrentPoint - panCharte.NumberOfPointsOnChart) + 1)
        MyBase.OnPanRightBeyondData(panCharte)
    End Sub

    Protected Overrides Sub OnPanToEnd(ByVal panCharte As PanChartEventArgs)
        Dim data As Collection(Of DataPoint) = Me.dataLogDB_0.GetData(Math.Max(500, panCharte.NumberOfPointsOnChart), DateTime.Now)
        MyBase.m_DataPoints.Clear
        Dim point As DataPoint
        For Each point In data
            MyBase.m_DataPoints.Add(point)
        Next
        panCharte.CurrentPoint = 0
        panCharte.NumberOfPointsOnChart = MyBase.m_DataPoints.Count
        Me.bool_0 = True
        MyBase.OnPanToEnd(panCharte)
    End Sub

    Protected Overrides Sub OnZoomOutBeyondData(ByVal panCharte As PanChartEventArgs)
        Dim data As Collection(Of DataPoint) = Me.dataLogDB_0.GetData(Math.Max(500, panCharte.NumberOfPointsOnChart), panCharte.CurrentPointDate)
        If (data.Count < panCharte.NumberOfPointsOnChart) Then
            data = Me.dataLogDB_0.GetData(data(0).Timestamp, Math.Max(500, panCharte.NumberOfPointsOnChart))
        End If
        MyBase.m_DataPoints.Clear
        Dim point As DataPoint
        For Each point In data
            MyBase.m_DataPoints.Add(point)
        Next
        panCharte.CurrentPoint = 0
        panCharte.NumberOfPointsOnChart = MyBase.m_DataPoints.Count
        panCharte.CurrentPoint = (MyBase.m_DataPoints.Count - 1)
        MyBase.OnZoomOutBeyondData(panCharte)
    End Sub


    ' Properties
    Public Property DataDirectory As String
        Get
            Return Me.dataLogDB_0.DataDirectory
        End Get
        Set(ByVal value As String)
            Me.dataLogDB_0.DataDirectory = value
        End Set
    End Property

    Public Property FileHeader As String
        Get
            Return Me.dataLogDB_0.FileHeader
        End Get
        Set(ByVal value As String)
            Me.dataLogDB_0.FileHeader = value
        End Set
    End Property


    ' Fields
    Private dataLogDB_0 As DataLogDB = New DataLogDB
    Private bool_0 As Boolean
End Class

