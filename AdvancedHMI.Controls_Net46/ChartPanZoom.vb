Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting

Public Class ChartPanZoom
    Inherits UserControl
    ' Events
    Public Event PanLeftBeyondData As EventHandler(Of PanChartEventArgs)
    Public Event PanRightBeyondData As EventHandler
    Public Event PanToEnd As EventHandler(Of PanChartEventArgs)
    Public Event ZoomOutBeyondData As EventHandler

    ' Methods
    Public Sub New()
        Me.InitializeComponent
    End Sub

    Public Sub AddPoints(ByVal dataPoint_0 As DataPoint)
        Me.m_DataPoints.Add(dataPoint_0)
        Dim num As Integer = ((Me.int_1 - Me.int_0) + 1)
        If (Me.int_1 = (Me.m_DataPoints.Count - 2)) Then
            Dim numRef As Integer
            If (num < Me.int_3) Then
                num = Me.int_3
            End If
            numRef = CInt(AddressOf Me.int_1) = (numRef + 1)
            Me.int_0 = Math.Max(0, ((Me.int_1 - num) + 1))
            Me.RefreshChart
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing AndAlso (Me.icontainer_0 > Nothing)) Then
                Me.icontainer_0.Dispose
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub InitializeComponent()
        Dim item As New ChartArea
        Dim series As New Series
        Me.MainTableLayoutPanel = New TableLayoutPanel
        Me.Chart1 = New Chart
        Me.NavigationTable = New TableLayoutPanel
        Me.ToEndButton = New Button
        Me.ShiftRightButton = New Button
        Me.ZoomInButton = New Button
        Me.ZoomOutButton = New Button
        Me.ShiftLeftButton = New Button
        Me.SeriesSelectPanel = New FlowLayoutPanel
        Me.ValueLabelPanel = New FlowLayoutPanel
        Me.StatusLabel = New Label
        Me.MainTableLayoutPanel.SuspendLayout
        Me.Chart1.BeginInit
        Me.NavigationTable.SuspendLayout
        MyBase.SuspendLayout
        Me.MainTableLayoutPanel.ColumnCount = 3
        Me.MainTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 15!))
        Me.MainTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70!))
        Me.MainTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 15!))
        Me.MainTableLayoutPanel.Controls.Add(Me.Chart1, 1, 0)
        Me.MainTableLayoutPanel.Controls.Add(Me.NavigationTable, 0, 1)
        Me.MainTableLayoutPanel.Controls.Add(Me.SeriesSelectPanel, 2, 0)
        Me.MainTableLayoutPanel.Controls.Add(Me.ValueLabelPanel, 0, 0)
        Me.MainTableLayoutPanel.Controls.Add(Me.StatusLabel, 0, 2)
        Me.MainTableLayoutPanel.Dock = DockStyle.Fill
        Me.MainTableLayoutPanel.Location = New Point(0, 0)
        Me.MainTableLayoutPanel.Name = "MainTableLayoutPanel"
        Me.MainTableLayoutPanel.RowCount = 3
        Me.MainTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 84.21053!))
        Me.MainTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 15.78947!))
        Me.MainTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20!))
        Me.MainTableLayoutPanel.Size = New Size(&H34E, &H1AB)
        Me.MainTableLayoutPanel.TabIndex = 0
        Me.Chart1.BackColor = SystemColors.Control
        Me.Chart1.BackImageTransparentColor = SystemColors.Control
        item.Area3DStyle.LightStyle = LightStyle.Realistic
        item.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
        item.AxisX.IsLabelAutoFit = False
        item.AxisX.Title = "Date/Time"
        item.AxisX2.IntervalAutoMode = IntervalAutoMode.VariableCount
        item.AxisX2.LabelStyle.ForeColor = Color.Peru
        item.AxisX2.Title = "Date / Time"
        item.AxisX2.TitleForeColor = Color.Peru
        item.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount
        item.AxisY.LabelStyle.Format = "0.0"
        item.AxisY.TextOrientation = TextOrientation.Stacked
        item.AxisY.Title = "Value"
        item.AxisY2.IntervalAutoMode = IntervalAutoMode.VariableCount
        item.AxisY2.LabelStyle.ForeColor = Color.Peru
        item.AxisY2.LineColor = Color.Peru
        item.AxisY2.Title = "Value"
        item.AxisY2.TitleForeColor = Color.Peru
        item.CursorX.IsUserSelectionEnabled = True
        item.CursorY.IsUserSelectionEnabled = True
        item.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(item)
        Me.Chart1.Dock = DockStyle.Fill
        Me.Chart1.Location = New Point(&H81, 3)
        Me.Chart1.Name = "Chart1"
        series.BorderColor = Color.Black
        series.ChartArea = "ChartArea1"
        series.ChartType = SeriesChartType.FastLine
        series.IsVisibleInLegend = False
        series.Name = "Series0"
        series.ToolTip = "#AXISLABEL, #VALY"
        series.XValueType = ChartValueType.DateTime
        Me.Chart1.Series.Add(series)
        Me.Chart1.Size = New Size(&H24A, &H150)
        Me.Chart1.TabIndex = 1
        Me.Chart1.Text = "Chart1"
        Me.NavigationTable.ColumnCount = 5
        Me.MainTableLayoutPanel.SetColumnSpan(Me.NavigationTable, 3)
        Me.NavigationTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22!))
        Me.NavigationTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22!))
        Me.NavigationTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22!))
        Me.NavigationTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22!))
        Me.NavigationTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12!))
        Me.NavigationTable.Controls.Add(Me.ToEndButton, 5, 0)
        Me.NavigationTable.Controls.Add(Me.ShiftRightButton, 3, 0)
        Me.NavigationTable.Controls.Add(Me.ZoomInButton, 0, 0)
        Me.NavigationTable.Controls.Add(Me.ZoomOutButton, 2, 0)
        Me.NavigationTable.Controls.Add(Me.ShiftLeftButton, 0, 0)
        Me.NavigationTable.Dock = DockStyle.Fill
        Me.NavigationTable.Location = New Point(3, &H159)
        Me.NavigationTable.Name = "NavigationTable"
        Me.NavigationTable.RowCount = 1
        Me.NavigationTable.RowStyles.Add(New RowStyle(SizeType.Percent, 100!))
        Me.NavigationTable.Size = New Size(840, &H3A)
        Me.NavigationTable.TabIndex = 2
        Me.ToEndButton.Dock = DockStyle.Fill
        Me.ToEndButton.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Me.ToEndButton.Location = New Point(&H2E3, 3)
        Me.ToEndButton.Name = "ToEndButton"
        Me.ToEndButton.Size = New Size(&H62, &H34)
        Me.ToEndButton.TabIndex = &H48
        Me.ToEndButton.Text = "End->"
        Me.ToEndButton.UseVisualStyleBackColor = True
        Me.ShiftRightButton.Dock = DockStyle.Fill
        Me.ShiftRightButton.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Me.ShiftRightButton.Location = New Point(&H22B, 3)
        Me.ShiftRightButton.Name = "ShiftRightButton"
        Me.ShiftRightButton.Size = New Size(&HB2, &H34)
        Me.ShiftRightButton.TabIndex = &H47
        Me.ShiftRightButton.Text = ">>"
        Me.ShiftRightButton.UseVisualStyleBackColor = True
        Me.ZoomInButton.Dock = DockStyle.Fill
        Me.ZoomInButton.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Me.ZoomInButton.Location = New Point(&HBB, 3)
        Me.ZoomInButton.Name = "ZoomInButton"
        Me.ZoomInButton.Size = New Size(&HB2, &H34)
        Me.ZoomInButton.TabIndex = 70
        Me.ZoomInButton.Text = "Zoom In"
        Me.ZoomInButton.UseVisualStyleBackColor = True
        Me.ZoomOutButton.Dock = DockStyle.Fill
        Me.ZoomOutButton.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Me.ZoomOutButton.Location = New Point(&H173, 3)
        Me.ZoomOutButton.Name = "ZoomOutButton"
        Me.ZoomOutButton.Size = New Size(&HB2, &H34)
        Me.ZoomOutButton.TabIndex = &H45
        Me.ZoomOutButton.Text = "Zoom Out"
        Me.ZoomOutButton.UseVisualStyleBackColor = True
        Me.ShiftLeftButton.Dock = DockStyle.Fill
        Me.ShiftLeftButton.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Me.ShiftLeftButton.Location = New Point(3, 3)
        Me.ShiftLeftButton.Name = "ShiftLeftButton"
        Me.ShiftLeftButton.Size = New Size(&HB2, &H34)
        Me.ShiftLeftButton.TabIndex = &H44
        Me.ShiftLeftButton.Text = "<<"
        Me.ShiftLeftButton.UseVisualStyleBackColor = True
        Me.SeriesSelectPanel.Dock = DockStyle.Fill
        Me.SeriesSelectPanel.FlowDirection = FlowDirection.TopDown
        Me.SeriesSelectPanel.Location = New Point(&H2D1, 3)
        Me.SeriesSelectPanel.Name = "SeriesSelectPanel"
        Me.SeriesSelectPanel.Size = New Size(&H7A, &H150)
        Me.SeriesSelectPanel.TabIndex = 3
        Me.SeriesSelectPanel.WrapContents = False
        Me.ValueLabelPanel.AutoScroll = True
        Me.ValueLabelPanel.Dock = DockStyle.Fill
        Me.ValueLabelPanel.FlowDirection = FlowDirection.TopDown
        Me.ValueLabelPanel.Location = New Point(3, 3)
        Me.ValueLabelPanel.Name = "ValueLabelPanel"
        Me.ValueLabelPanel.Size = New Size(120, &H150)
        Me.ValueLabelPanel.TabIndex = 4
        Me.ValueLabelPanel.WrapContents = False
        Me.StatusLabel.AutoSize = True
        Me.MainTableLayoutPanel.SetColumnSpan(Me.StatusLabel, 3)
        Me.StatusLabel.Dock = DockStyle.Fill
        Me.StatusLabel.ForeColor = Color.DarkGray
        Me.StatusLabel.Location = New Point(3, &H196)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New Size(840, &H15)
        Me.StatusLabel.TabIndex = 5
        Me.StatusLabel.TextAlign = ContentAlignment.MiddleCenter
        MyBase.AutoScaleDimensions = New SizeF(6!, 13!)
        MyBase.AutoScaleMode = AutoScaleMode.Font
        MyBase.Controls.Add(Me.MainTableLayoutPanel)
        MyBase.Name = "ChartPanZoom"
        MyBase.Size = New Size(&H34E, &H1AB)
        Me.MainTableLayoutPanel.ResumeLayout(False)
        Me.MainTableLayoutPanel.PerformLayout
        Me.Chart1.EndInit
        Me.NavigationTable.ResumeLayout(False)
        MyBase.ResumeLayout(False)
    End Sub

    Private Sub method_0(ByVal int_7 As Integer)
        Dim num As Integer = Me.int_0
        Dim num2 As Integer = Convert.ToInt32(Math.Ceiling(CDbl((CDbl(((Me.int_1 - Me.int_0) + 1)) / 1000))))
        If (int_7 < Me.Chart1.Series.Count) Then
            Me.Chart1.Series(int_7).BorderWidth = Me.int_4
        End If
        If (Me.m_DataPoints.Count > 0) Then
            Dim num5 As Double
            Dim num6 As Double
            If ((int_7 < Me.Chart1.Series.Count) AndAlso Me.list_1(int_7).Checked) Then
                If (Me.int_0 < Me.m_DataPoints.Count) Then
                    num5 = CDbl(Me.m_DataPoints(Me.int_0).Points(0))
                End If
                num6 = num5
                Dim num8 As Integer = Me.int_0
                Dim num9 As Integer = (Me.int_1 - 1)
                Dim i As Integer = num8
                Do While (i <= num9)
                    Dim num11 As Integer = (Me.m_DataPoints(i).Points.Count - 1)
                    Dim j As Integer = 0
                    Do While (j <= num11)
                        If (((i < Me.m_DataPoints.Count) AndAlso (j < Me.m_DataPoints(i).Points.Count)) AndAlso Me.list_1(j).Checked) Then
                            num5 = Math.Max(num5, CDbl(Me.m_DataPoints(i).Points(j)))
                            num6 = Math.Min(num6, CDbl(Me.m_DataPoints(i).Points(j)))
                        End If
                        j += 1
                    Loop
                    i += 1
                Loop
            End If
            If (Me.YAxisMaximum = Double.NaN) Then
                Me.Chart1.ChartAreas(0).AxisY.Maximum = num5
            End If
            If (num5 = num6) Then
                num6 -= 1
            End If
            If (Me.YAxisMinimum = Double.NaN) Then
                Me.Chart1.ChartAreas(0).AxisY.Minimum = num6
            End If
        End If
        If ((Me.int_0 <> Me.int_5) Or (Me.int_1 <> Me.int_6)) Then
            Dim num13 As Integer = (Me.Chart1.Series.Count - 1)
            Dim i As Integer = 0
            Do While (i <= num13)
                Me.Chart1.Series(i).Points.Clear
                Me.int_5 = -1
                Me.int_6 = -1
                i += 1
            Loop
        End If
        If (int_7 < Me.Chart1.Series.Count) Then
            Me.Chart1.Series(int_7).Points.Clear
        End If
        Dim num7 As Integer = 1
        Do While (num <= Me.int_1)
            Dim timestamp As DateTime = Me.m_DataPoints(num).Timestamp
            Dim num4 As Integer = 0
            Dim num3 As Double = 0
            If (num = Me.int_0) Then
                If (Me.m_DataPoints(num).Points.Count > int_7) Then
                    Me.double_1 = CDbl(Me.m_DataPoints(num).Points(int_7))
                End If
                Me.double_0 = Me.double_1
            Else
                If (Me.m_DataPoints(num).Points.Count > int_7) Then
                    Me.double_1 = Math.Min(Me.double_1, CDbl(Me.m_DataPoints(num).Points(int_7)))
                End If
                If (Me.m_DataPoints(num).Points.Count > int_7) Then
                    Me.double_0 = Math.Max(Me.double_0, CDbl(Me.m_DataPoints(num).Points(int_7)))
                End If
            End If
            Dim num15 As Integer = (num2 - 1)
            Dim i As Integer = 0
            Do While (i <= num15)
                If ((num + i) < Me.m_DataPoints.Count) Then
                    If (Me.m_DataPoints((num + i)).Points.Count > int_7) Then
                        num3 = (num3 + CDbl(Me.m_DataPoints((num + i)).Points(int_7)))
                    End If
                    num4 += 1
                End If
                i += 1
            Loop
            If ((int_7 < Me.Chart1.Series.Count) AndAlso (Me.m_DataPoints(num).Points.Count > int_7)) Then
                Dim str As String
                Try
                    str = timestamp.ToString(Me.string_0)
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    str = "Invalid Format"
                    ProjectData.ClearProjectError
                End Try
                Dim yValue As Object() = New Object() {(num3 / CDbl(num4))}
                Me.Chart1.Series(int_7).Points.AddXY(str, yValue)
            End If
            num7 += 1
            num = (num + num2)
        Loop
        If ((Me.list_1.Count > int_7) AndAlso (Me.m_ChartSeriesNames.Count > int_7)) Then
            Me.list_1(int_7).Text = Me.m_ChartSeriesNames(int_7)
        End If
        If (Math.Floor(CDbl((CDbl((Me.int_0 - Me.int_5)) / CDbl(num2)))) >= 1) Then
            Me.int_5 = Me.int_0
        End If
        Me.int_6 = Me.int_1
        Me.int_5 = Me.int_0
    End Sub

    Private Function method_1() As Integer
        Dim num2 As Integer = (Me.m_DataPoints.Count - 1)
        Dim i As Integer = 0
        Do While (i <= num2)
            Me.int_2 = Math.Max(Me.int_2, Me.m_DataPoints(i).Points.Count)
            i += 1
        Loop
        Return Me.int_2
    End Function

    Private Sub method_2(ByVal sender As Object, ByVal e As EventArgs)
        Dim numberOfPointsOnChart As Integer = ((Me.int_1 - Me.int_0) + 1)
        If ((Me.int_0 - numberOfPointsOnChart) < 0) Then
            Dim args As New PanChartEventArgs(numberOfPointsOnChart, Me.int_0, Me.m_DataPoints(Me.int_0).Timestamp)
            Me.OnPanLeftBeyondData(args)
            Me.int_0 = args.CurrentPoint
        End If
        Me.int_0 = Math.Max(0, (Me.int_0 - numberOfPointsOnChart))
        Me.int_1 = ((Me.int_0 + Math.Min(numberOfPointsOnChart, Me.m_DataPoints.Count)) - 1)
        Me.RefreshChart
    End Sub

    Private Sub method_3(ByVal sender As Object, ByVal e As EventArgs)
        Dim numberOfPointsOnChart As Integer = ((Me.int_1 - Me.int_0) + 1)
        numberOfPointsOnChart = (numberOfPointsOnChart * 2)
        If ((Me.m_DataPoints.Count > 0) AndAlso (numberOfPointsOnChart = Me.m_DataPoints.Count)) Then
            Dim args As New PanChartEventArgs(numberOfPointsOnChart, 0, Me.m_DataPoints((Me.m_DataPoints.Count - 1)).Timestamp)
            Me.OnZoomOutBeyondData(args)
            Me.int_1 = args.CurrentPoint
        End If
        Me.int_0 = Math.Max(0, ((Me.int_1 - numberOfPointsOnChart) + 1))
        Me.int_1 = Math.Min(CInt(((Me.int_0 + numberOfPointsOnChart) - 1)), CInt((Me.m_DataPoints.Count - 1)))
        Me.RefreshChart
    End Sub

    Private Sub method_4(ByVal sender As Object, ByVal e As EventArgs)
        Dim num As Integer = ((Me.int_1 - Me.int_0) + 1)
        If ((num > 20) Or ((Me.int_1 = 0) And (Me.int_0 = 0))) Then
            Me.int_0 = CInt(Math.Round(CDbl(((Me.int_1 - (CDbl(num) / 2)) + 1))))
            Me.int_3 = CInt(Math.Round(CDbl((CDbl(num) / 2))))
            Me.RefreshChart
        End If
    End Sub

    Private Sub method_5(ByVal sender As Object, ByVal e As EventArgs)
        Dim numberOfPointsOnChart As Integer = ((Me.int_1 - Me.int_0) + 1)
        If ((Me.int_0 - numberOfPointsOnChart) < 0) Then
            Dim args As New PanChartEventArgs(numberOfPointsOnChart, Me.int_1, Me.m_DataPoints(Me.int_1).Timestamp)
            Me.OnPanRightBeyondData(args)
            Me.int_0 = args.CurrentPoint
        End If
        Me.int_1 = Math.Min(CInt((Me.m_DataPoints.Count - 1)), CInt((Me.int_1 + numberOfPointsOnChart)))
        Me.int_0 = ((Me.int_1 - numberOfPointsOnChart) + 1)
        Me.RefreshChart
    End Sub

    Private Sub method_6(ByVal sender As Object, ByVal e As EventArgs)
        Dim timestamp As DateTime
        Dim numberOfPointsOnChart As Integer = ((Me.int_1 - Me.int_0) + 1)
        If (Me.m_DataPoints.Count > 0) Then
            timestamp = Me.m_DataPoints(Me.int_1).Timestamp
        Else
            timestamp = DateTime.Now
        End If
        Dim args As New PanChartEventArgs(numberOfPointsOnChart, Me.int_1, timestamp)
        Me.OnPanToEnd(args)
        Me.int_1 = (Me.m_DataPoints.Count - 1)
        Me.int_0 = ((Me.int_1 - numberOfPointsOnChart) + 1)
        Me.RefreshChart
    End Sub

    Private Sub method_7(ByVal sender As Object, ByVal e As EventArgs)
        Dim box As CheckBox = DirectCast(sender, CheckBox)
        Dim num As Integer = Conversions.ToInteger(box.Tag)
        If Not box.Checked Then
            Me.Chart1.Series(num).Points.Clear
            Me.RefreshChart
        Else
            Me.method_0(num)
            Dim num2 As Integer = CInt(Math.Round(Me.double_1))
            num2 = CInt(Math.Round(Me.double_0))
            Me.list_0(num).Text = (num2.ToString & " -> " & num2.ToString)
        End If
    End Sub

    Protected Overridable Sub OnPanLeftBeyondData(ByVal panCharte As PanChartEventArgs)
        Dim handler As EventHandler(Of PanChartEventArgs) = Me.eventHandler_0
        If (Not handler Is Nothing) Then
            handler.Invoke(Me, panCharte)
        End If
    End Sub

    Protected Overridable Sub OnPanRightBeyondData(ByVal panCharte As PanChartEventArgs)
        Dim handler As EventHandler = Me.eventHandler_1
        If (Not handler Is Nothing) Then
            handler.Invoke(Me, panCharte)
        End If
    End Sub

    Protected Overridable Sub OnPanToEnd(ByVal panCharte As PanChartEventArgs)
        Dim handler As EventHandler(Of PanChartEventArgs) = Me.eventHandler_2
        If (Not handler Is Nothing) Then
            handler.Invoke(Me, panCharte)
        End If
    End Sub

    Protected Overridable Sub OnZoomOutBeyondData(ByVal panCharte As PanChartEventArgs)
        Dim handler As EventHandler = Me.eventHandler_3
        If (Not handler Is Nothing) Then
            handler.Invoke(Me, panCharte)
        End If
    End Sub

    Public Sub RefreshChart()
        If (Not Me.Chart1 Is Nothing) Then
            Try
                Dim num As Integer = Me.Chart1.Series.Count
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError
                Return
            End Try
            Me.int_2 = Me.method_1
            If (Me.int_2 < Me.Chart1.Series.Count) Then
                Me.Chart1.Series.Clear
                Me.int_5 = -1
                Me.int_6 = -1
            End If
            Dim count As Integer = Me.Chart1.Series.Count
            Dim num3 As Integer = (Me.int_2 - 1)
            Dim i As Integer = count
            Do While (i <= num3)
                If ((Me.m_ChartSeriesNames.Count > i) AndAlso Not String.IsNullOrEmpty(Me.m_ChartSeriesNames(i))) Then
                    Me.Chart1.Series.Add(Me.m_ChartSeriesNames(i))
                Else
                    Me.Chart1.Series.Add(("Series" & Conversions.ToString(i)))
                End If
                Me.Chart1.Series((Me.Chart1.Series.Count - 1)).XValueType = ChartValueType.DateTime
                Me.Chart1.ChartAreas(0).AxisX.LabelStyle.Format = "hh:mm:ss"
                i += 1
            Loop
            Dim num5 As Integer = (Me.Chart1.Series.Count - 1)
            Dim j As Integer = 0
            Do While (j <= num5)
                Me.Chart1.Series(j).ChartType = Me.seriesChartType_0
                j += 1
            Loop
            Me.Chart1.ApplyPaletteColors
            If (Me.Chart1.Series.Count > Me.list_0.Count) Then
                Dim num7 As Integer = (Me.list_0.Count - 1)
                Dim k As Integer = 0
                Do While (k <= num7)
                    Me.ValueLabelPanel.Controls.Remove(Me.list_0(k))
                    RemoveHandler Me.list_1(k).CheckedChanged, New EventHandler(AddressOf Me.method_7)
                    Me.SeriesSelectPanel.Controls.Remove(Me.list_1(k))
                    k += 1
                Loop
                Me.list_0.Clear
                Me.list_1.Clear
                Dim num9 As Integer = (Me.Chart1.Series.Count - 1)
                Dim m As Integer = 0
                Do While (m <= num9)
                    Dim label As New Label With { _
                        .Dock = DockStyle.Fill, _
                        .AutoSize = True, _
                        .BackColor = Me.Chart1.Series(m).Color _
                    }
                    Dim num11 As Double = ((((CDbl((&H12B * label.BackColor.R)) / 255) + (CDbl((&H24B * label.BackColor.G)) / 255)) + (CDbl((&H72 * label.BackColor.B)) / 255)) / 1000)
                    If (num11 < 0.5) Then
                        label.ForeColor = Color.White
                    Else
                        label.ForeColor = Color.Black
                    End If
                    label.TextAlign = ContentAlignment.MiddleCenter
                    Me.ValueLabelPanel.Controls.Add(label)
                    Me.list_0.Add(label)
                    label.Visible = False
                    Dim box As New CheckBox With { _
                        .Dock = DockStyle.Fill _
                    }
                    box.Size = New Size((Me.SeriesSelectPanel.Width - 2), (box.Font.Height + 2))
                    box.AutoSize = True
                    box.ForeColor = Me.Chart1.Series(m).Color
                    If (Me.m_ChartSeriesNames.Count > m) Then
                        box.Text = Me.m_ChartSeriesNames(m)
                    Else
                        box.Text = Me.Chart1.Series(m).Name
                    End If
                    box.Tag = m
                    Me.SeriesSelectPanel.Controls.Add(box)
                    Me.list_1.Add(box)
                    box.Checked = True
                    AddHandler box.CheckedChanged, New EventHandler(AddressOf Me.method_7)
                    m += 1
                Loop
            End If
            If Me.Chart1.ChartAreas(0).AxisX.ScaleView.IsZoomed Then
                Me.Chart1.ChartAreas(0).AxisX.ScaleView.ZoomReset
            End If
            If Me.Chart1.ChartAreas(0).AxisY.ScaleView.IsZoomed Then
                Me.Chart1.ChartAreas(0).AxisY.ScaleView.ZoomReset
            End If
            If ((Me.int_1 = 0) And (Me.int_0 = 0)) Then
                Me.int_1 = (Me.m_DataPoints.Count - 1)
                Me.int_0 = Math.Max(0, (Me.int_1 - &H3E8))
            End If
            If (Me.m_DataPoints.Count > 0) Then
                Dim num12 As Integer = (Me.Chart1.Series.Count - 1)
                Dim k As Integer = 0
                Do While (k <= num12)
                    If Me.list_1(k).Checked Then
                        Me.list_0(k).Visible = Me.list_1(k).Checked
                        Me.list_1(k).Visible = True
                        Me.method_0(k)
                        Dim num14 As Integer = CInt(Math.Round(Me.double_1))
                        num14 = CInt(Math.Round(Me.double_0))
                        Me.list_0(k).Text = (num14.ToString & "=> " & num14.ToString)
                    Else
                        Me.list_0(k).Text = "---------"
                    End If
                    k += 1
                Loop
            End If
        End If
    End Sub


    ' Properties
    Private Overridable Property MainTableLayoutPanel As TableLayoutPanel
        <CompilerGenerated> _
        Get
            Return Me._MainTableLayoutPanel
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As TableLayoutPanel)
            Me._MainTableLayoutPanel = value
        End Set
    End Property

    Protected Overridable Property Chart1 As Chart
        <CompilerGenerated> _
        Get
            Return Me._Chart1
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Chart)
            Me._Chart1 = value
        End Set
    End Property

    Private Overridable Property NavigationTable As TableLayoutPanel
        <CompilerGenerated> _
        Get
            Return Me._NavigationTable
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As TableLayoutPanel)
            Me._NavigationTable = value
        End Set
    End Property

    Private Overridable Property ShiftLeftButton As Button
        <CompilerGenerated> _
        Get
            Return Me._ShiftLeftButton
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Button)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.method_2)
            Dim button As Button = Me._ShiftLeftButton
            If (Not button Is Nothing) Then
                RemoveHandler button.Click, handler
            End If
            Me._ShiftLeftButton = value
            button = Me._ShiftLeftButton
            If (Not button Is Nothing) Then
                AddHandler button.Click, handler
            End If
        End Set
    End Property

    Private Overridable Property ZoomOutButton As Button
        <CompilerGenerated> _
        Get
            Return Me._ZoomOutButton
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Button)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.method_3)
            Dim button As Button = Me._ZoomOutButton
            If (Not button Is Nothing) Then
                RemoveHandler button.Click, handler
            End If
            Me._ZoomOutButton = value
            button = Me._ZoomOutButton
            If (Not button Is Nothing) Then
                AddHandler button.Click, handler
            End If
        End Set
    End Property

    Private Overridable Property ZoomInButton As Button
        <CompilerGenerated> _
        Get
            Return Me._ZoomInButton
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Button)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.method_4)
            Dim button As Button = Me._ZoomInButton
            If (Not button Is Nothing) Then
                RemoveHandler button.Click, handler
            End If
            Me._ZoomInButton = value
            button = Me._ZoomInButton
            If (Not button Is Nothing) Then
                AddHandler button.Click, handler
            End If
        End Set
    End Property

    Private Overridable Property ShiftRightButton As Button
        <CompilerGenerated> _
        Get
            Return Me._ShiftRightButton
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Button)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.method_5)
            Dim button As Button = Me._ShiftRightButton
            If (Not button Is Nothing) Then
                RemoveHandler button.Click, handler
            End If
            Me._ShiftRightButton = value
            button = Me._ShiftRightButton
            If (Not button Is Nothing) Then
                AddHandler button.Click, handler
            End If
        End Set
    End Property

    Private Overridable Property SeriesSelectPanel As FlowLayoutPanel
        <CompilerGenerated> _
        Get
            Return Me._SeriesSelectPanel
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As FlowLayoutPanel)
            Me._SeriesSelectPanel = value
        End Set
    End Property

    Private Overridable Property ValueLabelPanel As FlowLayoutPanel
        <CompilerGenerated> _
        Get
            Return Me._ValueLabelPanel
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As FlowLayoutPanel)
            Me._ValueLabelPanel = value
        End Set
    End Property

    Friend Overridable Property StatusLabel As Label
        <CompilerGenerated> _
        Get
            Return Me._StatusLabel
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Label)
            Me._StatusLabel = value
        End Set
    End Property

    Private Overridable Property ToEndButton As Button
        <CompilerGenerated> _
        Get
            Return Me._ToEndButton
        End Get
        <MethodImpl(MethodImplOptions.Synchronized), CompilerGenerated> _
        Set(ByVal value As Button)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.method_6)
            Dim button As Button = Me._ToEndButton
            If (Not button Is Nothing) Then
                RemoveHandler button.Click, handler
            End If
            Me._ToEndButton = value
            button = Me._ToEndButton
            If (Not button Is Nothing) Then
                AddHandler button.Click, handler
            End If
        End Set
    End Property

    Public ReadOnly Property DataPoints As Collection(Of DataPoint)
        Get
            Return Me.m_DataPoints
        End Get
    End Property

    Public Property ChartType As SeriesChartType
        Get
            Return Me.seriesChartType_0
        End Get
        Set(ByVal value As SeriesChartType)
            Me.seriesChartType_0 = value
        End Set
    End Property

    Public Property ChartLineWidth As Integer
        Get
            Return Me.int_4
        End Get
        Set(ByVal value As Integer)
            Me.int_4 = value
        End Set
    End Property

    Public Property [Text] As String
        Get
            Return Me.StatusLabel.Text
        End Get
        Set(ByVal value As String)
            Me.StatusLabel.Text = value
        End Set
    End Property

    Public Property YAxisNumericFormat As String
        Get
            Return Me.Chart1.ChartAreas(0).AxisY.LabelStyle.Format
        End Get
        Set(ByVal value As String)
            Me.Chart1.ChartAreas(0).AxisY.LabelStyle.Format = value
        End Set
    End Property

    Public Property XAxisLabelFormat As String
        Get
            Return Me.string_0
        End Get
        Set(ByVal value As String)
            Me.string_0 = value
        End Set
    End Property

    <TypeConverter(GetType(AutoValueConverter))> _
    Public Property YAxisMaximum As Double
        Get
            Return Me.Chart1.ChartAreas(0).AxisY.Maximum
        End Get
        Set(ByVal value As Double)
            Me.Chart1.ChartAreas(0).AxisY.Maximum = value
        End Set
    End Property

    <TypeConverter(GetType(AutoValueConverter))> _
    Public Property YAxisMinimum As Double
        Get
            Return Me.Chart1.ChartAreas(0).AxisY.Minimum
        End Get
        Set(ByVal value As Double)
            Me.Chart1.ChartAreas(0).AxisY.Minimum = value
        End Set
    End Property

    <TypeConverter(GetType(AutoValueConverter))> _
    Public Property ButtonHeight As Double
        Get
            If (Me.MainTableLayoutPanel.RowStyles(1).SizeType = SizeType.Absolute) Then
                Return Me.double_2
            End If
            Return Double.NaN
        End Get
        Set(ByVal value As Double)
            If Not Double.IsNaN(value) Then
                Me.MainTableLayoutPanel.RowStyles(1).SizeType = SizeType.Absolute
                Me.double_2 = Math.Max(35, value)
                Me.MainTableLayoutPanel.RowStyles(1).Height = CSng(Me.double_2)
            Else
                Me.MainTableLayoutPanel.RowStyles(1).SizeType = SizeType.Percent
                Me.MainTableLayoutPanel.RowStyles(1).Height = 16!
                Me.double_2 = Double.NaN
            End If
        End Set
    End Property


    ' Fields
    Private icontainer_0 As IContainer
    <CompilerGenerated, AccessedThroughProperty("MainTableLayoutPanel"), DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private _MainTableLayoutPanel As TableLayoutPanel
    <AccessedThroughProperty("Chart1"), DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
    Private _Chart1 As Chart
    <AccessedThroughProperty("NavigationTable"), CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private _NavigationTable As TableLayoutPanel
    <AccessedThroughProperty("ShiftLeftButton"), CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private _ShiftLeftButton As Button
    <AccessedThroughProperty("ZoomOutButton"), DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
    Private _ZoomOutButton As Button
    <AccessedThroughProperty("ZoomInButton"), DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
    Private _ZoomInButton As Button
    <CompilerGenerated, AccessedThroughProperty("ShiftRightButton"), DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Private _ShiftRightButton As Button
    <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated, AccessedThroughProperty("SeriesSelectPanel")> _
    Private _SeriesSelectPanel As FlowLayoutPanel
    <AccessedThroughProperty("ValueLabelPanel"), DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated> _
    Private _ValueLabelPanel As FlowLayoutPanel
    Private double_0 As Double
    Private double_1 As Double
    Private int_0 As Integer
    Private int_1 As Integer
    Private int_2 As Integer
    Private list_0 As List(Of Label) = New List(Of Label)
    <DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated, AccessedThroughProperty("StatusLabel")> _
    Private _StatusLabel As Label
    <DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("ToEndButton"), CompilerGenerated> _
    Private _ToEndButton As Button
    Private list_1 As List(Of CheckBox) = New List(Of CheckBox)
    Private int_3 As Integer = 200
    Protected m_DataPoints As Collection(Of DataPoint) = New Collection(Of DataPoint)
    Private seriesChartType_0 As SeriesChartType = SeriesChartType.FastLine
    Private int_4 As Integer = 2
    Protected m_ChartSeriesNames As List(Of String) = New List(Of String)
    Private string_0 As String = "MMMdd HH:mm:ss"
    Private double_2 As Double = Double.NaN
    Private int_5 As Integer
    Private int_6 As Integer
End Class

