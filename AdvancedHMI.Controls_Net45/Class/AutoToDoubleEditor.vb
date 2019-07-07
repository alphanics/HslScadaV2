Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design


Public Class AutoToDoubleEditor
    Inherits UITypeEditor

    Private editorService As IWindowsFormsEditorService


    Private Sub AutoClicked(ByVal sender As Object, ByVal e As EventArgs)
        If Me.editorService IsNot Nothing Then
            Me.editorService.CloseDropDown()
        End If
    End Sub

    Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
        Dim obj As Object
        If context IsNot Nothing And context.Instance IsNot Nothing And provider IsNot Nothing Then
            Me.editorService = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
            If Me.editorService IsNot Nothing Then
                Dim listBox As New ListBox()
                Dim autoToDoubleEditor As AutoToDoubleEditor = Me
                AddHandler listBox.Click, AddressOf autoToDoubleEditor.AutoClicked
                listBox.Items.Add("Auto")
                listBox.SetSelected(1, True)
                listBox.Height = 20
                Me.editorService.DropDownControl(listBox)
                If Operators.ConditionalCompareObjectNotEqual(listBox.SelectedItem, String.Empty, False) Then
                    obj = Double.NaN
                    Return obj
                End If
            End If
        End If
        obj = value
        Return obj
    End Function

    Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return (If(If(context Is Nothing OrElse context.Instance Is Nothing, True, False), MyBase.GetEditStyle(context), UITypeEditorEditStyle.DropDown))
    End Function
End Class

