Imports System.Drawing

'*****************************************************************************************************
'* Archie Jacobs
'* Manufacturing Automation, LLC
'* support@advancedhmi.com
'* 12-JUN-11
'*
'* Copyright 2011 Archie Jacobs
'*
'* Distributed under the GNU General Public License (www.gnu.org)
'*
'* This program is free software; you can redistribute it and/or
'* as published by the Free Software Foundation; either version 2
'* of the License, or (at your option) any later version.
'*
'* This program is distributed in the hope that it will be useful,
'* but WITHOUT ANY WARRANTY; without even the implied warranty of
'* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'* GNU General Public License for more details.

'* You should have received a copy of the GNU General Public License
'* along with this program; if not, write to the Free Software
'* Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
'*
'******************************************************************************************************

Public Class OnScreenKeyboard
    Inherits System.Windows.Forms.Button

#Region "Constructor"

    Public Sub New()
        MyBase.New()
        MyBase.DoubleBuffered = True
        Me.DoubleBuffered = True
        Me.Size = New Size(134, 38)
        MyBase.ForeColor = Color.MidnightBlue
    End Sub

#End Region

#Region "Private Methods"

    Private Sub OSK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Click
        System.Diagnostics.Process.Start("osk.exe")
    End Sub

#End Region

End Class

