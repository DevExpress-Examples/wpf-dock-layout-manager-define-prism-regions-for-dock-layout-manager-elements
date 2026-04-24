Imports DevExpress.Xpf.Bars
Imports System.Text.RegularExpressions

Namespace PrismOnDXDocking.Infrastructure
    Public Class MenuService
        Implements IMenuService

        Private ReadOnly bar As Bar
        Private ReadOnly manager As BarManager

        Public Sub New(shell As Shell)
            manager = shell.BarManager
            bar = shell.MainMenu
        End Sub

        Public Sub Add(item As MenuItem)
            Dim parent As BarSubItem = GetParent(item.Parent)
            Dim button As New BarButtonItem With {
                .Content = item.Title,
                .Command = item.Command,
                .Name = "bbi" & Regex.Replace(item.Title, "[^a-zA-Z0-9]", "")
            }
            manager.Items.Add(button)
            parent.ItemLinks.Add(New BarButtonItemLink With {.BarItemName = button.Name})
        End Sub

        Private Sub IMenuService_Add(item As MenuItem) Implements IMenuService.Add
            Add(item)
        End Sub

        Private Function GetParent(parentName As String) As BarSubItem
            For Each item As BarItem In manager.Items
                Dim button = TryCast(item, BarSubItem)
                If button IsNot Nothing AndAlso button.Content.ToString() = parentName Then
                    Return button
                End If
            Next

            Dim newParent As New BarSubItem With {
                .Content = parentName,
                .Name = "bsi" & Regex.Replace(parentName, "[^a-zA-Z0-9]", "")
            }
            manager.Items.Add(newParent)
            bar.ItemLinks.Add(New BarSubItemLink With {.BarItemName = newParent.Name})
            Return newParent
        End Function
    End Class
End Namespace