Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Interface IKeyboard
    Property CurrentValue As String

    Property Font As System.Drawing.Font

    Property ForeColor As Color

    Property Location As Point

    Property PasswordChar As Boolean

    Property StartPosition As FormStartPosition

    Property Text As String

    Property TopMost As Boolean

    Property Value As String

    Property Visible As Boolean

    Event ButtonClick As EventHandler(Of KeypadEventArgs)
End Interface
