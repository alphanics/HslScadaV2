Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class FlowArrowStriped
    Inherits Control

    Private ShiftTimer As Timer

    Private m_arrowColor1 As Color

    Private m_arrowColor2 As Color

    Private m_valueFlow As Boolean

    Private m_shiftInterval As Integer

    Private currentWidth As Single

    Private currentHeight As Single

    Private m_Angle As Single

    Private m_dir As FlowArrowStriped.Dir

    Private flagColor As Boolean

    Private points() As PointF

    Private point1 As Point

    Private point2 As Point

    Private flagTimer As Boolean

    <Browsable(True), DefaultValue(GetType(Color), "Red"), Description("The arrow color1."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowColor1() As Color
        Get
            Return Me.m_arrowColor1
        End Get
        Set(ByVal value As Color)
            If Me.m_arrowColor1 <> value Then
                Me.m_arrowColor1 = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(GetType(Color), "GreenYellow"), Description("The arrow color2."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowColor2() As Color
        Get
            Return Me.m_arrowColor2
        End Get
        Set(ByVal value As Color)
            If Me.m_arrowColor2 <> value Then
                Me.m_arrowColor2 = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(500), Description("The arrow color shift interval in milliseconds."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowColorShiftInterval() As Integer
        Get
            Return Me.m_shiftInterval
        End Get
        Set(ByVal value As Integer)
            If Not Versioned.IsNumeric(value) Then
                value = 500
            End If
            If value < 0 Then
                value = 500
            End If
            If Me.m_shiftInterval <> value Then
                Me.m_shiftInterval = value
                Me.ShiftTimer.Interval = Me.m_shiftInterval
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(0), Description("The direction of the arrow."), RefreshProperties(RefreshProperties.All)>
    Public Property ArrowDirection() As FlowArrowStriped.Dir
        Get
            Return Me.m_dir
        End Get
        Set(ByVal value As FlowArrowStriped.Dir)
            Dim flag As Boolean
            If Me.m_dir <> value Then
                Me.currentWidth = CSng(Me.Width)
                Me.currentHeight = CSng(Me.Height)
                If Not (value = FlowArrowStriped.Dir.Right Or value = FlowArrowStriped.Dir.Down) Then
                    Me.m_Angle = 180.0F
                Else
                    Me.m_Angle = 0.0F
                End If
                If Me.m_dir <> FlowArrowStriped.Dir.Right AndAlso Me.m_dir <> FlowArrowStriped.Dir.Left OrElse value = FlowArrowStriped.Dir.Right OrElse value = FlowArrowStriped.Dir.Left Then
                    If (Me.m_dir = FlowArrowStriped.Dir.Up OrElse Me.m_dir = FlowArrowStriped.Dir.Down) AndAlso value <> FlowArrowStriped.Dir.Up AndAlso value <> FlowArrowStriped.Dir.Down Then
                        GoTo Label1
                    End If
                    flag = False
                    GoTo Label0
                End If
Label1:
                flag = True
Label0:
                If Not flag Then
                    Me.m_dir = value
                Else
                    Me.m_dir = value
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: this.Width = checked((int)Math.Round((double)this.currentHeight));
                    Me.Width = CInt(Math.Truncate(Math.Round(CDbl(Me.currentHeight))))
                    'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    'ORIGINAL LINE: this.Height = checked((int)Math.Round((double)this.currentWidth));
                    Me.Height = CInt(Math.Truncate(Math.Round(CDbl(Me.currentWidth))))
                    Me.FlowArrowStriped_Resize(Me, Nothing)
                End If
            End If
            Me.Invalidate()
        End Set
    End Property

    'private virtual Timer ShiftTimer
    '{
    '    [DebuggerNonUserCode]
    '    get
    '    {
    '        return this._ShiftTimer;
    '    }
    '    [DebuggerNonUserCode]
    '    set
    '    {
    '        FlowArrowStriped flowArrowStriped = this;
    '        EventHandler eventHandler = new EventHandler(flowArrowStriped.tmr_Tick);
    '        if (this._ShiftTimer != null)
    '        {
    '            this._ShiftTimer.Tick -= eventHandler;
    '        }
    '        this._ShiftTimer = value;
    '        if (this._ShiftTimer != null)
    '        {
    '            this._ShiftTimer.Tick += eventHandler;
    '        }
    '    }
    '}

    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            If String.Compare(MyBase.Text, value) <> 0 Then
                MyBase.Text = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Browsable(True), DefaultValue(False), Description("Indicates whether there is a flow."), RefreshProperties(RefreshProperties.All)>
    Public Property Value() As Boolean
        Get
            Return Me.m_valueFlow
        End Get
        Set(ByVal value As Boolean)
            If Me.m_valueFlow <> value Then
                Me.m_valueFlow = value
                If Not Me.m_valueFlow Then
                    Me.ShiftTimer.Enabled = False
                    Me.flagTimer = False
                Else
                    Me.ShiftTimer.Enabled = True
                End If
            End If
            Me.Invalidate()
        End Set
    End Property



    Public Sub New()
        Dim flowArrowStriped As FlowArrowStriped = Me
        AddHandler MyBase.Resize, AddressOf flowArrowStriped.FlowArrowStriped_Resize
        Dim flowArrowStriped1 As FlowArrowStriped = Me
        AddHandler MyBase.Click, AddressOf flowArrowStriped1.FlowArrowStriped_Click

        Me.m_arrowColor1 = Color.Red
        Me.m_arrowColor2 = Color.GreenYellow
        Me.m_shiftInterval = 500
        Me.m_dir = FlowArrowStriped.Dir.Right
        Me.SetStyle(ControlStyles.ContainerControl Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        MyBase.BackColor = Color.Transparent
        Me.Size = New Size(185, 90)
        Me.ShiftTimer = New Timer() With {
            .Interval = Me.m_shiftInterval,
            .Enabled = False
        }
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub FlowArrowStriped_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Focus()
    End Sub

    Private Sub FlowArrowStriped_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If (If(Me.m_dir = FlowArrowStriped.Dir.Right OrElse Me.m_dir = FlowArrowStriped.Dir.Left, False, True)) Then
            If Me.Height < 35 Then
                Me.Height = 35
            End If
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Width = checked((int)Math.Round((double)((float)(0.4864865f * (float)this.Height))));
            Me.Width = CInt(Math.Truncate(Math.Round(CDbl(CSng(0.4864865F * CSng(Me.Height))))))
            If Me.Width < 15 Then
                Me.Width = 15
            End If
        Else
            If Me.Width < 35 Then
                Me.Width = 35
            End If
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: this.Height = checked((int)Math.Round((double)((float)(0.4864865f * (float)this.Width))));
            Me.Height = CInt(Math.Truncate(Math.Round(CDbl(CSng(0.4864865F * CSng(Me.Width))))))
            If Me.Height < 15 Then
                Me.Height = 15
            End If
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim pointF As PointF
        Dim pointF1 As PointF
        Dim pointF2 As PointF
        Dim pointF3 As PointF
        Dim pointF4 As PointF
        Dim pointF5 As PointF
        Dim pointFArray() As PointF
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim graphics As Graphics = e.Graphics
        'INSTANT VB NOTE: The variable clientRectangle was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim clientRectangle_Renamed As Rectangle = Me.ClientRectangle
        'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
        Dim width_Renamed As Single = CSng(clientRectangle_Renamed.Width) / 2.0F
        Dim rectangle As Rectangle = Me.ClientRectangle
        graphics.TranslateTransform(width_Renamed, CSng(rectangle.Height) / 2.0F)
        e.Graphics.RotateTransform(-Me.m_Angle)
        Dim graphic As Graphics = e.Graphics
        rectangle = Me.ClientRectangle
        Dim [single] As Single = -CSng(rectangle.Width) / 2.0F
        clientRectangle_Renamed = Me.ClientRectangle
        graphic.TranslateTransform([single], -CSng(clientRectangle_Renamed.Height) / 2.0F)
        Dim num As Integer = 0
        Do
            If (If(Me.m_dir = FlowArrowStriped.Dir.Right OrElse Me.m_dir = FlowArrowStriped.Dir.Left, False, True)) Then
                pointFArray = New PointF(5) {}
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF5 = new PointF((float)(checked(this.Width - 1)), (float)(checked(num * this.Height)) / 6f + 1f);
                pointF5 = New PointF(CSng(Me.Width - 1), CSng(num * Me.Height) / 6.0F + 1.0F)
                pointFArray(0) = pointF5
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF4 = new PointF((float)(checked(this.Width - 1)), (float)(checked(num + 1)) * ((float)this.Height / 6f));
                pointF4 = New PointF(CSng(Me.Width - 1), CSng(num + 1) * (CSng(Me.Height) / 6.0F))
                pointFArray(1) = pointF4
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF3 = new PointF((float)this.Width / 2f, (float)(checked(num + 2)) * ((float)this.Height / 6f));
                pointF3 = New PointF(CSng(Me.Width) / 2.0F, CSng(num + 2) * (CSng(Me.Height) / 6.0F))
                pointFArray(2) = pointF3
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF2 = new PointF(0f, (float)(checked(num + 1)) * ((float)this.Height / 6f));
                pointF2 = New PointF(0.0F, CSng(num + 1) * (CSng(Me.Height) / 6.0F))
                pointFArray(3) = pointF2
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF1 = new PointF(0f, (float)(checked(num * this.Height)) / 6f + 1f);
                pointF1 = New PointF(0.0F, CSng(num * Me.Height) / 6.0F + 1.0F)
                pointFArray(4) = pointF1
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF = new PointF((float)this.Width / 2f, (float)(checked(num + 1)) * ((float)this.Height / 6f));
                pointF = New PointF(CSng(Me.Width) / 2.0F, CSng(num + 1) * (CSng(Me.Height) / 6.0F))
                pointFArray(5) = pointF
                Me.points = pointFArray
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.point1 = new Point(0, checked((int)Math.Round((double)this.Height / 2)));
                Me.point1 = New Point(0, CInt(Math.Round(CDbl(Me.Height) / 2)))
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.point2 = new Point(this.Width, checked((int)Math.Round((double)this.Height / 2)));
                Me.point2 = New Point(Me.Width, CInt(Math.Round(CDbl(Me.Height) / 2)))
            Else
                pointFArray = New PointF(5) {}
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF = new PointF((float)(checked(num * this.Width)) / 6f + 1f, 0f);
                pointF = New PointF(CSng(num * Me.Width) / 6.0F + 1.0F, 0.0F)
                pointFArray(0) = pointF
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF1 = new PointF((float)(checked(num + 1)) * ((float)this.Width / 6f), 0f);
                pointF1 = New PointF(CSng(num + 1) * (CSng(Me.Width) / 6.0F), 0.0F)
                pointFArray(1) = pointF1
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF2 = new PointF((float)(checked(num + 2)) * ((float)this.Width / 6f), (float)this.Height / 2f);
                pointF2 = New PointF(CSng(num + 2) * (CSng(Me.Width) / 6.0F), CSng(Me.Height) / 2.0F)
                pointFArray(2) = pointF2
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF3 = new PointF((float)(checked(num + 1)) * ((float)this.Width / 6f), (float)(checked(this.Height - 1)));
                pointF3 = New PointF(CSng(num + 1) * (CSng(Me.Width) / 6.0F), CSng(Me.Height - 1))
                pointFArray(3) = pointF3
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF4 = new PointF((float)(checked(num * this.Width)) / 6f + 1f, (float)(checked(this.Height - 1)));
                pointF4 = New PointF(CSng(num * Me.Width) / 6.0F + 1.0F, CSng(Me.Height - 1))
                pointFArray(4) = pointF4
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: pointF5 = new PointF((float)(checked(num + 1)) * ((float)this.Width / 6f), (float)this.Height / 2f);
                pointF5 = New PointF(CSng(num + 1) * (CSng(Me.Width) / 6.0F), CSng(Me.Height) / 2.0F)
                pointFArray(5) = pointF5
                Me.points = pointFArray
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.point1 = new Point(checked((int)Math.Round((double)this.Width / 2)), 0);
                Me.point1 = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), 0)
                'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                'ORIGINAL LINE: this.point2 = new Point(checked((int)Math.Round((double)this.Width / 2)), this.Height);
                Me.point2 = New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), Me.Height)
            End If
            Dim blend As New Blend(11)
            Dim singleArray() As Single = {0.0F, 0.1F, 0.2F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F, 1.0F}
            blend.Positions = singleArray
            singleArray = New Single() {0.0F, 0.0F, 0.1F, 0.2F, 0.3F, 0.5F, 0.3F, 0.2F, 0.1F, 0.0F, 0.0F}
            blend.Factors = singleArray
            Dim color As New Color()
            If Not Me.flagColor Then
                color = (If(Not Me.flagTimer, Me.m_arrowColor1, Me.m_arrowColor2))
                Me.flagColor = True
            Else
                color = (If(Not Me.flagTimer, Me.m_arrowColor2, Me.m_arrowColor1))
                Me.flagColor = False
            End If
            Using linearGradientBrush As New LinearGradientBrush(Me.point1, Me.point2, color, ControlPaint.LightLight(color))
                linearGradientBrush.Blend = blend
                e.Graphics.DrawPolygon(New Pen(New SolidBrush(System.Drawing.Color.Black), 1.0F), Me.points)
                e.Graphics.FillPolygon(linearGradientBrush, Me.points)
            End Using
            num += 1
        Loop While num <= 4
        Me.flagColor = False
        e.Graphics.ResetTransform()
        If Not String.IsNullOrEmpty(Me.Text) Then
            Dim stringFormat As New StringFormat() With {
             .Alignment = StringAlignment.Center,
             .LineAlignment = StringAlignment.Center
            }
            Dim graphics1 As Graphics = e.Graphics
            'INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim text_Renamed As String = Me.Text
            'INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim font_Renamed As Font = Me.Font
            Dim solidBrush As New SolidBrush(Me.ForeColor)
            'INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
            'ORIGINAL LINE: Point point = new Point(checked((int)Math.Round((double)this.Width / 2)), checked((int)Math.Round((double)this.Height / 2)));
            Dim point As New Point(CInt(Math.Round(CDbl(Me.Width) / 2)), CInt(Math.Round(CDbl(Me.Height) / 2)))
            graphics1.DrawString(text_Renamed, font_Renamed, solidBrush, point, stringFormat)
        End If
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me.flagTimer = Not Me.flagTimer
        Me.Invalidate()
    End Sub

    Public Enum Dir
        Right
        Left
        Up
        Down
    End Enum
End Class

