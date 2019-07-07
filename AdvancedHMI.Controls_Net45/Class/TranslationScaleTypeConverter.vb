Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.CompilerServices

Public Class TranslationScaleTypeConverter
    Inherits TypeConverter


    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        Dim flag As Boolean
        flag = (If(Not (sourceType.Equals(GetType(String)) Or sourceType.Equals(GetType(RotationScale))), MyBase.CanConvertFrom(context, sourceType), True))
        Return flag
    End Function

    Public Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
        Dim flag As Boolean
        flag = (If(Not (destinationType.Equals(GetType(String)) Or destinationType.Equals(GetType(RotationScale))), MyBase.CanConvertTo(context, destinationType), True))
        Return flag
    End Function

    Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        Dim translationScale As Object
        If Not (TypeOf value Is String) Then
            translationScale = MyBase.ConvertFrom(context, culture, RuntimeHelpers.GetObjectValue(value))
        Else
            Dim str As String = Conversions.ToString(value)
            Dim strArrays() As String = str.Split(New Char() {","c})
            Try
                translationScale = New TranslationScale(Conversions.ToDouble(strArrays(0)), Conversions.ToDouble(strArrays(1)), Conversions.ToDouble(strArrays(2)), Conversions.ToDouble(strArrays(3)))
            Catch
                Throw New InvalidCastException(Conversions.ToString(value))
            End Try
        End If
        Return translationScale
    End Function

    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
        Dim obj As Object
        If Not destinationType.Equals(GetType(String)) Then
            obj = MyBase.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType)
        Else
            Dim translationScale As TranslationScale = DirectCast(value, TranslationScale)
            Dim str() As String = {Conversions.ToString(translationScale.InputMinValue), ",", Conversions.ToString(translationScale.InputMaxValue), ",", Conversions.ToString(translationScale.OutputMinValue), ",", Conversions.ToString(translationScale.OutputMaxValue)}
            obj = String.Concat(str)
        End If
        Return obj
    End Function

    Public Overrides Function GetProperties(ByVal context As ITypeDescriptorContext, ByVal value As Object, ByVal Attribute() As System.Attribute) As PropertyDescriptorCollection
        Return TypeDescriptor.GetProperties(RuntimeHelpers.GetObjectValue(value))
    End Function

    Public Overrides Function GetPropertiesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class

