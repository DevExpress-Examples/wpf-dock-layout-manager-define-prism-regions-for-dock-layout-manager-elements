Imports Microsoft.VisualBasic
Imports System.Windows.Input

Namespace PrismOnDXDocking.Infrastructure
    Public Class MenuItem
        Public Property Parent() As String
        Public Property Title() As String
        Public Property Command() As ICommand
    End Class
End Namespace