Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Globalization

Public Class AutoToDoubleTypeConverter(Of T As IConvertible)
    Inherits TypeConverter



    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        Return sourceType.GetInterface("IConvertible", False) IsNot Nothing
    End Function

    Public Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
        Return destinationType.GetInterface("IConvertible", False) IsNot Nothing
    End Function

    Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        Dim type As Object
        Try
            Dim convertible As IConvertible = DirectCast(value, IConvertible)
            If convertible IsNot Nothing Then
                type = convertible.ToType(GetType(T), culture)
                Return type
            End If
        Catch formatException As FormatException
            ProjectData.SetProjectError(formatException)
            If (If(value Is Nothing OrElse Not value.ToString().Equals("AUTO", StringComparison.CurrentCultureIgnoreCase), True, False)) Then
                Throw
            Else
                type = Double.NaN
                ProjectData.ClearProjectError()
                Return type
            End If
        End Try
        type = Nothing
        Return type
    End Function

    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
        Dim type As Object
        If (If(value Is Nothing OrElse Not Double.IsNaN(Conversions.ToDouble(value)), True, False)) Then
            type = DirectCast(value, IConvertible).ToType(destinationType, culture)
        Else
            type = "Auto"
        End If
        Return type
    End Function
End Class

