Imports Microsoft.VisualBasic
Imports System.Windows.Input

Namespace PrismOnDXDocking.Infrastructure
	Public Class MenuItem
		Private privateParent As String
		Public Property Parent() As String
			Get
				Return privateParent
			End Get
			Set(ByVal value As String)
				privateParent = value
			End Set
		End Property
		Private privateTitle As String
		Public Property Title() As String
			Get
				Return privateTitle
			End Get
			Set(ByVal value As String)
				privateTitle = value
			End Set
		End Property
		Private privateCommand As ICommand
		Public Property Command() As ICommand
			Get
				Return privateCommand
			End Get
			Set(ByVal value As ICommand)
				privateCommand = value
			End Set
		End Property
	End Class
End Namespace