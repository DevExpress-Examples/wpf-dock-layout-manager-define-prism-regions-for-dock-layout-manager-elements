Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports System.Text.RegularExpressions
Imports DevExpress.Xpf.Bars

Namespace PrismOnDXDocking.Infrastructure
	<Export(GetType(IMenuService))> _
	Public Class MenuService
		Implements IMenuService
		Private ReadOnly _manager As BarManager
		Private ReadOnly _bar As Bar
		<ImportingConstructor> _
		Public Sub New(ByVal shell As Shell)
			_manager = shell.BarManager
			_bar = shell.MainMenu
		End Sub
        Public Sub Add(ByVal item As MenuItem) Implements IMenuService.Add
            Dim parent = GetParent(item.Parent)
            Dim button = New BarButtonItem With {.Content = item.Title, .Command = item.Command, .Name = "bbi" & Regex.Replace(item.Title, "[^a-zA-Z0-9]", "")}
            _manager.Items.Add(button)
            parent.ItemLinks.Add(New BarButtonItemLink With {.BarItemName = button.Name})
        End Sub

		Private Function GetParent(ByVal parentName As String) As BarSubItem
			For Each item In _manager.Items
				Dim button = TryCast(item, BarSubItem)
				If button IsNot Nothing AndAlso CStr(button.Content) = parentName Then
					Return button
				End If
			Next item
			Dim newParent = New BarSubItem With {.Content = parentName, .Name = "bsi" & Regex.Replace(parentName, "[^a-zA-Z0-9]", "")}
			_manager.Items.Add(newParent)
			_bar.ItemLinks.Add(New BarSubItemLink With {.BarItemName = newParent.Name})
			Return newParent
		End Function
	End Class
End Namespace