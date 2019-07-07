Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows.Forms.Design


Public Class RotationValueEditor
    Inherits UITypeEditor

    Private editorService As IWindowsFormsEditorService


    Public Sub New()
    End Sub

    Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
        If context IsNot Nothing And context.Instance IsNot Nothing And provider IsNot Nothing Then
            Me.editorService = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
            If Me.editorService IsNot Nothing Then
                Dim frm As New RotationValueEditorForm()
                Dim frmR As RotationScale = DirectCast(value, RotationScale)
                frm.ValueAtMaxCCWTextBox.Text = Conversions.ToString(frmR.RotationMaxValueCCW)
                frm.ValueAtMaxCWTextBox.Text = Conversions.ToString(frmR.RotationMaxValueCW)
                frm.CCWRotationTextBox.Text = Conversions.ToString(frmR.RotationCCWAngle)
                frm.CWRotationTextBox.Text = Conversions.ToString(frmR.RotationCWAngle)
                frm.XPositionTextBox.Text = Conversions.ToString(frmR.XPosition)
                frm.YPositionTextBox.Text = Conversions.ToString(frmR.YPosition)
                If Me.editorService.ShowDialog(frm) = DialogResult.OK Then
                    frmR.RotationMaxValueCCW = Conversions.ToSingle(frm.ValueAtMaxCCWTextBox.Text)
                    frmR.RotationMaxValueCW = Conversions.ToSingle(frm.ValueAtMaxCWTextBox.Text)
                    frmR.RotationCCWAngle = Conversions.ToSingle(frm.CCWRotationTextBox.Text)
                    frmR.RotationCWAngle = Conversions.ToSingle(frm.CWRotationTextBox.Text)
                    frmR.XPosition = Conversions.ToInteger(frm.XPositionTextBox.Text)
                    frmR.YPosition = Conversions.ToInteger(frm.YPositionTextBox.Text)
                End If
            End If
        End If
        Return value
    End Function

    Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Dim uITypeEditorEditStyle As UITypeEditorEditStyle
        uITypeEditorEditStyle = (If(Not (context IsNot Nothing And context.Instance IsNot Nothing), MyBase.GetEditStyle(context), System.Drawing.Design.UITypeEditorEditStyle.Modal))
        Return uITypeEditorEditStyle
    End Function

    Protected Overridable Sub SetEditorProps(ByVal editingInstance As RotationScale, ByVal editor As RotationValueEditorForm)
        editor.ValueAtMaxCCWTextBox.Text = Conversions.ToString(editingInstance.RotationMaxValueCCW)
    End Sub
End Class

