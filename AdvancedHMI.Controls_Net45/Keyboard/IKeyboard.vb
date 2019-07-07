Imports System.Drawing

Public Interface IKeyboard
    ' Events
    Event ButtonClick As ButtonClickEventHandler

    ' Properties
    Property Font As Font
    Property ForeColor As Color
    Property Location As Point
    Property StartPosition As Object
    Property [Text] As String
    Property TopMost As Boolean
    Property Value As String
    Property Visible As Boolean

    ' Nested Types
    Delegate Sub ButtonClickEventHandler(ByVal sender As Object, ByVal e As KeypadEventArgs)
End Interface




