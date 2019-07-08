Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Globalization

Public Class AutoToDoubleTypeConverter(Of T As IConvertible)
    Inherits TypeConverter
    ' Methods
    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        Return (sourceType.GetInterface("IConvertible", False) > Nothing)
    End Function

    Public Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
        Return (destinationType.GetInterface("IConvertible", False) > Nothing)
    End Function

    Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        Try
            Dim convertible As IConvertible = DirectCast(value, IConvertible)
            If (convertible > Nothing) Then
                Return convertible.ToType(GetType(T), culture)
            End If
        Catch exception1 As FormatException
            ProjectData.SetProjectError(exception1)
            Dim exception As FormatException = exception1
            If Not ((Not value Is Nothing) AndAlso value.ToString.Equals("AUTO", StringComparison.CurrentCultureIgnoreCase)) Then
                Throw
            End If
            ProjectData.ClearProjectError
            Return NaN
        End Try
        Return Nothing
    End Function

    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
        If ((Not value Is Nothing) AndAlso Double.IsNaN(Conversions.ToDouble(value))) Then
            Return "Auto"
        End If
        Return DirectCast(value, IConvertible).ToType(destinationType, culture)
    End Function

End Class

