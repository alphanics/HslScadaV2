Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Runtime.CompilerServices

Public Class DataLogDB
    Implements IDisposable
    ' Methods
    Public Sub AddDataPoint(ByVal dataPoint_0 As DataPoint)
        Dim chArray3 As Char()
        Dim time As DateTime
        Dim numRef As Integer
        Me.method_4(dataPoint_0.Timestamp)
        If (Me.list_0.Count > 0) Then
            Dim chArray1 As Char() = New Char() {","c}
            Dim str As String = Me.list_0((Me.list_0.Count - 1)).Split(chArray1)(0)
            Dim str2 As String = str.Substring(&H11, 2)
            time = New DateTime(Conversions.ToInteger(str.Substring(0, 4)), Conversions.ToInteger(str.Substring(5, 2)), Conversions.ToInteger(str.Substring(8, 2)), Conversions.ToInteger(str.Substring(11, 2)), Conversions.ToInteger(str.Substring(14, 2)), Conversions.ToInteger(str.Substring(&H11, 2)))
        End If
        If ((Me.list_0.Count <= 0) OrElse (DateTime.Compare(time, dataPoint_0.Timestamp) <= 0)) Then
            Me.list_0.Add(dataPoint_0.ToString)
            goto Label_01C6
        End If
        Dim num As Integer = CInt(Math.Round(CDbl((CDbl(Me.list_0.Count) / 2))))
        Dim num2 As Integer = 1
        Dim separator As Char() = New Char() {","c}
        If (DateTime.Compare(Me.method_7(Me.list_0(num).Split(separator)(0)), dataPoint_0.Timestamp) > 0) Then
            num2 = -1
        End If
Label_015D:
        chArray3 = New Char() {","c}
        If (((num >= 0) And (num < Me.list_0.Count)) And (DateTime.Compare(Me.method_7(Me.list_0(num).Split(chArray3)(0)), dataPoint_0.Timestamp) > 0)) Then
            num = (num + num2)
            goto Label_015D
        End If
        Me.list_0.Insert((num + 1), dataPoint_0.ToString)
Label_01C6:
        numRef = CInt(AddressOf Me.int_0) = (numRef + 1)
    End Sub

    Public Sub dispose() Implements IDisposable.Dispose
        Me.dispose(True)
    End Sub

    Public Sub dispose(ByVal disposing As Boolean)
        If disposing Then
            Me.method_5(True)
        End If
    End Sub

    Public Sub Flush()
        Me.method_5(True)
    End Sub

    Public Function GetData(ByVal startDate As DateTime, ByVal endDate As DateTime) As Collection(Of DataPoint)
        Dim point As DataPoint = Me.method_2(startDate)
        Dim collection2 As New Collection(Of DataPoint)
        If (point > Nothing) Then
            If (DateTime.Compare(point.Timestamp, endDate) > 0) Then
                Return collection2
            End If
            Dim timestamp As DateTime = point.Timestamp
            Do While (DateTime.Compare(timestamp, endDate) <= 0)
                Dim point2 As DataPoint
                Dim str As String = Me.method_1(timestamp)
                Dim path As String = Path.Combine(Me.method_0(timestamp), str)
                If (String.Compare(str, Me.string_0, True) = 0) Then
                    Dim num As Integer = 0
                    Do
                        Dim line As String = Me.list_0(num)
                        point2 = New DataPoint(line)
                        If ((DateTime.Compare(point2.Timestamp, startDate) >= 0) AndAlso (DateTime.Compare(point2.Timestamp, endDate) <= 0)) Then
                            collection2.Add(point2)
                        End If
                        timestamp = point2.Timestamp
                        num += 1
                    Loop While ((num < Me.list_0.Count) And (DateTime.Compare(point2.Timestamp, endDate) <= 0))
                    timestamp = timestamp.AddDays(1)
                    timestamp = Me.method_7(timestamp.ToString("yyyy-MM-dd 00:00:00"))
                ElseIf File.Exists(path) Then
                    Using reader As StreamReader = New StreamReader(path)
                        reader.ReadLine
                        If Not reader.EndOfStream Then
                            Do
                                point2 = New DataPoint(reader.ReadLine)
                                If ((DateTime.Compare(point2.Timestamp, startDate) >= 0) AndAlso (DateTime.Compare(point2.Timestamp, endDate) <= 0)) Then
                                    collection2.Add(point2)
                                End If
                                timestamp = point2.Timestamp
                            Loop While (Not reader.EndOfStream And (DateTime.Compare(point2.Timestamp, endDate) <= 0))
                            timestamp = timestamp.AddDays(1)
                            timestamp = Me.method_7(timestamp.ToString("yyyy-MM-dd 00:00:00"))
                        End If
                    End Using
                Else
                    timestamp = timestamp.AddDays(1)
                    timestamp = Me.method_7(timestamp.ToString("yyyy-MM-dd 00:00:00"))
                End If
            Loop
        End If
        Return collection2
    End Function

    Public Function GetData(ByVal startDate As DateTime, ByVal numberOfPoints As Integer) As Collection(Of DataPoint)
        Dim point As DataPoint = Me.method_2(startDate)
        Dim collection2 As New Collection(Of DataPoint)
        Dim timestamp As New DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour, startDate.Minute, startDate.Second)
        If (point > Nothing) Then
            Do While ((collection2.Count < numberOfPoints) And (DateTime.Compare(timestamp, DateTime.Now) <= 0))
                Dim str2 As String = Me.method_0(timestamp)
                Dim strA As String = Me.method_1(timestamp)
                If (String.Compare(strA, Me.string_0, True) = 0) Then
                    Dim num As Integer = 0
                    Do
                        Dim line As String = Me.list_0(num)
                        Dim item As New DataPoint(line)
                        If ((DateTime.Compare(item.Timestamp, startDate) >= 0) AndAlso (collection2.Count < numberOfPoints)) Then
                            collection2.Add(item)
                        End If
                        timestamp = item.Timestamp
                        num += 1
                    Loop While ((num < Me.list_0.Count) And (collection2.Count < numberOfPoints))
                    timestamp = timestamp.AddDays(1)
                    timestamp = Me.method_7(timestamp.ToString("yyyy-MM-dd 00:00:00"))
                ElseIf File.Exists(Path.Combine(str2, strA)) Then
                    Using reader As StreamReader = New StreamReader(Path.Combine(str2, strA))
                        reader.ReadLine
                        Do While (Not reader.EndOfStream And (collection2.Count < numberOfPoints))
                            Dim item As New DataPoint(reader.ReadLine)
                            If (DateTime.Compare(item.Timestamp, startDate) > 0) Then
                                collection2.Add(item)
                            End If
                        Loop
                    End Using
                End If
                timestamp = timestamp.AddDays(1)
            Loop
        End If
        Return collection2
    End Function

    Public Function GetData(ByVal numberOfPoints As Integer, ByVal endDate As DateTime) As Collection(Of DataPoint)
        Dim point As DataPoint = Me.method_3(endDate)
        Dim collection2 As New Collection(Of DataPoint)
        If (point > Nothing) Then
            Dim data As Collection(Of DataPoint)
            Dim time As DateTime = Me.method_6.Timestamp.AddDays(-1)
            Dim time2 As DateTime = endDate.AddDays(-1)
            Do While (((data Is Nothing) OrElse (data.Count < numberOfPoints)) And (DateTime.Compare(time2, time) > 0))
                data = Me.GetData(time2, endDate)
                time2 = time2.AddDays(-1)
            Loop
            Dim num As Integer = numberOfPoints
            If (data > Nothing) Then
                num = Math.Min(num, data.Count)
            Else
                num = 0
            End If
            Dim num2 As Integer = (num - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                collection2.Add(data(((data.Count - num) + i)))
                i += 1
            Loop
        End If
        Return collection2
    End Function

    Private Function method_0(ByVal dateTime_0 As DateTime) As String
        Return Path.Combine(Path.Combine(Me.string_1, "datalog"), DateTime.Now.ToString("yyyy"))
    End Function

    Private Function method_1(ByVal dateTime_0 As DateTime) As String
        Dim str2 As String = "DataLog"
        Return ((str2 & dateTime_0.ToString("yyyy") & dateTime_0.ToString("MM") & dateTime_0.ToString("dd")) & ".csv")
    End Function

    Private Function method_2(ByVal dateTime_0 As DateTime) As DataPoint
        Dim time As New DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, dateTime_0.Second)
        Dim now As DateTime = DateTime.Now
        Do While ((Not Directory.Exists(Me.method_0(time)) And (String.Compare(Me.method_1(time), Me.string_0, True) <> 0)) And (DateTime.Compare(time, now) <= 0))
            time = time.AddDays(1)
        Loop
        If (DateTime.Compare(time, now) <= 0) Then
            Dim str As String = Me.method_0(time)
            Do While ((Not File.Exists(Path.Combine(str, Me.method_1(time))) And (String.Compare(Me.method_1(time), Me.string_0, True) <> 0)) AndAlso (DateTime.Compare(time, now) <= 0))
                time = time.AddDays(1)
            Loop
            If (DateTime.Compare(time, now) <= 0) Then
                Dim strArray As String()
                Dim time3 As DateTime
                If (String.Compare(Me.method_1(time), Me.string_0, True) = 0) Then
                    Dim num As Integer
                    Do
                        Dim str2 As String = Me.list_0(num)
                        Dim separator As Char() = New Char() {","c}
                        strArray = str2.Split(separator)
                        time3 = Me.method_7(strArray(0))
                        num += 1
                    Loop While Not ((DateTime.Compare(time3, dateTime_0) >= 0) Or (num >= Me.list_0.Count))
                Else
                    Dim path As String = Path.Combine(str, Me.method_1(time))
                    Dim year As Integer = time.Year
                    If File.Exists(path) Then
                        Using reader As StreamReader = New StreamReader(path)
                            reader.ReadLine
                            If Not reader.EndOfStream Then
                                Do
                                    Dim separator As Char() = New Char() {","c}
                                    strArray = reader.ReadLine.Split(separator)
                                    time3 = Me.method_7(strArray(0))
                                Loop While Not ((DateTime.Compare(time3, dateTime_0) >= 0) Or reader.EndOfStream)
                            End If
                        End Using
                    End If
                End If
                If (DateTime.Compare(time3, dateTime_0) >= 0) Then
                    Return New DataPoint(strArray)
                End If
                Return Nothing
            End If
        End If
        Return Nothing
    End Function

    Private Function method_3(ByVal dateTime_0 As DateTime) As DataPoint
        Dim point2 As DataPoint = Nothing
        Dim time As New DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, dateTime_0.Second)
        Do While (time.Year > &H7B2)
            Do While (((Not Directory.Exists(Me.method_0(time)) OrElse (Directory.GetFiles(Me.method_0(time)).Length <= 0)) And (String.Compare(Me.string_0, Me.method_1(time)) <> 0)) And (time.Year > &H7B2))
                time = time.AddYears(-1)
            Loop
            If (time.Year > &H7B2) Then
                Dim files As String()
                Dim path As String = Me.method_0(time)
                If Directory.Exists(path) Then
                    files = Directory.GetFiles(path)
                End If
                If ((String.Compare(Me.string_0, Me.method_1(time), True) = 0) OrElse (files.Length > 0)) Then
                    Dim class2 As Class8
                    class2 = New Class8(class2) With { _
                        .string_0 = Path.Combine(path, Me.method_1(time)) _
                    }
                    Do While (((String.Compare(Me.string_0, Me.method_1(time), True) <> 0) AndAlso String.IsNullOrEmpty(Array.Find(Of String)(files, If((class2.predicate_0 Is Nothing), class2.predicate_0 = New Predicate(Of String)(AddressOf class2.method_0), class2.predicate_0)))) And (time.Year >= &H7B2))
                        time = time.AddDays(-1)
                        class2.string_0 = Path.Combine(path, Me.method_1(time))
                    Loop
                    If (time.Year >= &H7B2) Then
                        Dim str3 As String
                        Dim flag7 As Boolean
                        Dim str2 As String = ""
                        If (String.Compare(Me.string_0, Me.method_1(time), True) <> 0) Then
                            Using reader As StreamReader = New StreamReader(Path.Combine(Me.method_0(time), Me.method_1(time)))
                                reader.ReadLine
                                Do While (((point2 Is Nothing) And Not reader.EndOfStream) And Not flag7)
                                    str3 = reader.ReadLine
                                    If (DateTime.Compare(Me.method_7(str3), dateTime_0) > 0) Then
                                        If Not String.IsNullOrEmpty(str2) Then
                                            Return New DataPoint(str2)
                                        End If
                                        time = time.AddDays(-1)
                                        flag7 = True
                                    End If
                                    str2 = str3
                                    If reader.EndOfStream Then
                                        Return New DataPoint(str3)
                                    End If
                                Loop
                            End Using
                        Else
                            Dim num As Integer = 0
                            Do While (((point2 Is Nothing) And (num < Me.list_0.Count)) And Not flag7)
                                str3 = Me.list_0(num)
                                num += 1
                                If (DateTime.Compare(Me.method_7(str3), dateTime_0) > 0) Then
                                    If Not String.IsNullOrEmpty(str2) Then
                                        Return New DataPoint(str2)
                                    End If
                                    time = time.AddDays(-1)
                                    flag7 = True
                                End If
                                str2 = str3
                                If (num >= Me.list_0.Count) Then
                                    Return New DataPoint(str3)
                                End If
                            Loop
                        End If
                    End If
                End If
            End If
        Loop
        Return point2
    End Function

    Private Sub method_4(ByVal dateTime_0 As DateTime)
        Dim strA As String = Me.method_1(dateTime_0)
        If (String.Compare(strA, Me.string_0, True) <> 0) Then
            Me.method_5(True)
            Dim path As String = Me.method_0(dateTime_0)
            If (Directory.Exists(path) AndAlso File.Exists(Path.Combine(path, strA))) Then
                Using reader As StreamReader = New StreamReader(Path.Combine(path, strA))
                    reader.ReadLine
                    Do While Not reader.EndOfStream
                        Me.list_0.Add(reader.ReadLine)
                    Loop
                End Using
            End If
            Me.string_0 = strA
        End If
    End Sub

    Private Sub method_5(ByVal bool_0 As Boolean)
        If ((Me.list_0.Count > 0) AndAlso Not String.IsNullOrEmpty(Me.string_0)) Then
            Dim separator As Char() = New Char() {","c}
            Dim strArray As String() = Me.list_0(0).Split(separator)
            Dim path As String = Me.method_0(Me.method_7(strArray(0)))
            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If
            Using writer As StreamWriter = New StreamWriter(Path.Combine(path, Me.string_0))
                writer.WriteLine(Me.string_2)
                Dim num As Integer = (Me.list_0.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num)
                    writer.WriteLine(Me.list_0(i))
                    i += 1
                Loop
            End Using
            If bool_0 Then
                Me.list_0.Clear
                Me.string_0 = ""
            End If
            Me.int_0 = 0
        End If
    End Sub

    Private Function method_6() As DataPoint
        Dim directories As String()
        Dim point2 As DataPoint
        If Directory.Exists(Path.Combine(Me.string_1, "datalog")) Then
            directories = Directory.GetDirectories(Path.Combine(Me.string_1, "datalog"))
            Array.Sort(Of String)(directories, StringComparer.InvariantCulture)
        End If
        If ((Not directories Is Nothing) AndAlso (directories.Length > 0)) Then
            Dim path As String = directories(0)
            Dim num As Integer = (directories.Length - 1)
            Dim i As Integer = 0
            Do While (i <= num)
                Dim info As New DirectoryInfo(path)
                If (((Operators.CompareString(directories(i), path, False) < 0) And (Directory.GetDirectories(directories(i)).Length > 0)) Or (info.GetFiles("DataLog*.csv", SearchOption.TopDirectoryOnly).Length <= 0)) Then
                    path = directories(i)
                End If
                i += 1
            Loop
            Dim files As String() = Directory.GetFiles(path)
            If (files.Length > 0) Then
                Dim num3 As Integer
                Array.Sort(Of String)(files, StringComparer.InvariantCulture)
                Do
                    Using reader As StreamReader = New StreamReader(files(num3))
                        reader.ReadLine
                        Dim str2 As String = reader.ReadLine
                        If Not String.IsNullOrEmpty(str2) Then
                            point2 = New DataPoint(str2)
                        End If
                    End Using
                    num3 += 1
                Loop While ((num3 < files.Length) And (point2 Is Nothing))
            End If
        End If
        If (Me.list_0.Count > 0) Then
            Dim point3 As New DataPoint(Me.list_0(0))
            If ((point2 Is Nothing) OrElse (DateTime.Compare(point3.Timestamp, point2.Timestamp) < 0)) Then
                point2 = point3
            End If
        End If
        Return point2
    End Function

    Private Function method_7(ByVal string_3 As String) As DateTime
        If Not String.IsNullOrEmpty(string_3) Then
            Return New DateTime(Me.method_8(string_3.Substring(0, 4)), Me.method_8(string_3.Substring(5, 2)), Me.method_8(string_3.Substring(8, 2)), Me.method_8(string_3.Substring(11, 2)), Me.method_8(string_3.Substring(14, 2)), Me.method_8(string_3.Substring(&H11, 2)))
        End If
        Return DateTime.MinValue
    End Function

    Private Function method_8(ByVal string_3 As String) As Integer
        Dim num2 As Integer
        Dim num3 As Integer = (string_3.Length - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            num2 = ((num2 * 10) + (Convert.ToInt32(string_3(i)) - &H30))
            i += 1
        Loop
        Return num2
    End Function


    ' Properties
    Public Property DataDirectory As String
        Get
            Return Me.string_1
        End Get
        Set(ByVal value As String)
            Me.string_1 = value
        End Set
    End Property

    Public Property FileHeader As String
        Get
            Return Me.string_2
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                Me.string_2 = value
            End If
        End Set
    End Property


    ' Fields
    Private list_0 As List(Of String) = New List(Of String)
    Private string_0 As String
    Private int_0 As Integer
    Private string_1 As String = ".\"
    Private string_2 As String = ""

    ' Nested Types
    <CompilerGenerated> _
    Friend NotInheritable Class Class8
        ' Methods
        Public Sub New(ByVal class8_0 As Class8)
            If (Not class8_0 Is Nothing) Then
                Me.string_0 = class8_0.string_0
            End If
        End Sub

        Friend Function method_0(ByVal string_1 As String) As Boolean
            Return string_1.Equals(Me.string_0)
        End Function


        ' Fields
        Public string_0 As String
        Public predicate_0 As Predicate(Of String)
    End Class
End Class

