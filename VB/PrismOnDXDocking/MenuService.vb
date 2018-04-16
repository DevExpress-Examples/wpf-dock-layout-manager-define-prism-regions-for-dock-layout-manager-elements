' Developer Express Code Central Example:
' Prism - How to define Prism regions for various DXDocking elements
' 
' Since Prism RegionManager supports standard controls only, it is necessary to
' write custom RegionAdapters (a descendant of the
' Microsoft.Practices.Prism.Regions.RegionAdapterBase class) in order to instruct
' Prism RegionManager how to deal with DXDocking elements.
' 
' This example covers
' the following scenarios:
' 
' Using a LayoutPanel as a Prism region. The
' LayoutPanelAdapter class creates a new ContentControl containing a View and then
' places it into a target LayoutPanel.
' Using a LayoutGroup as a Prism region. The
' LayoutGroupAdapter creates a new LayoutPanel containing a View, and then adds it
' to a target LayoutGroup’s Items collection,
' Using a DocumentGroup as a Prism
' region. The DocumentGroupAdapter behaves similarly to the LayoutGroupAdapter.
' The only difference is that it manipulates DocumentPanels.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3339

Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports System.Text.RegularExpressions
Imports DevExpress.Xpf.Bars

Namespace PrismOnDXDocking.Infrastructure
    <Export(GetType(IMenuService))> _
    Public Class MenuService
        Implements IMenuService

        Private ReadOnly manager As BarManager
        Private ReadOnly bar As Bar
        <ImportingConstructor> _
        Public Sub New(ByVal shell As Shell)
            Me.manager = shell.BarManager
            Me.bar = shell.MainMenu
        End Sub
        Public Sub Add(ByVal item As MenuItem) Implements IMenuService.Add
            Dim parent As BarSubItem = GetParent(item.Parent)
            Dim button As BarButtonItem = New BarButtonItem With {.Content = item.Title, .Command = item.Command, .Name = "bbi" & Regex.Replace(item.Title, "[^a-zA-Z0-9]", "")}
            manager.Items.Add(button)
            parent.ItemLinks.Add(New BarButtonItemLink With {.BarItemName = button.Name})
        End Sub

        Private Function GetParent(ByVal parentName As String) As BarSubItem
            For Each item As BarItem In manager.Items
                Dim button As BarSubItem = TryCast(item, BarSubItem)
                If button IsNot Nothing AndAlso button.Content.ToString() = parentName Then
                    Return button
                End If
            Next item
            Dim newParent As BarSubItem = New BarSubItem With {.Content = parentName, .Name = "bsi" & Regex.Replace(parentName, "[^a-zA-Z0-9]", "")}
            manager.Items.Add(newParent)
            bar.ItemLinks.Add(New BarSubItemLink With {.BarItemName = newParent.Name})
            Return newParent
        End Function
    End Class
End Namespace