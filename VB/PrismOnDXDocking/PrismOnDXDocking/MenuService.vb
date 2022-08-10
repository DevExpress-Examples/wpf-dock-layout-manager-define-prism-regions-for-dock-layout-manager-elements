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
Imports System.ComponentModel.Composition
Imports System.Text.RegularExpressions
Imports DevExpress.Xpf.Bars

Namespace PrismOnDXDocking.Infrastructure

    <System.ComponentModel.Composition.ExportAttribute(GetType(PrismOnDXDocking.Infrastructure.IMenuService))>
    Public Class MenuService
        Implements PrismOnDXDocking.Infrastructure.IMenuService

        Private ReadOnly manager As DevExpress.Xpf.Bars.BarManager

        Private ReadOnly bar As DevExpress.Xpf.Bars.Bar

        <System.ComponentModel.Composition.ImportingConstructorAttribute>
        Public Sub New(ByVal shell As PrismOnDXDocking.Shell)
            Me.manager = shell.BarManager
            Me.bar = shell.MainMenu
        End Sub

        Public Sub Add(ByVal item As PrismOnDXDocking.Infrastructure.MenuItem)
            Dim parent As DevExpress.Xpf.Bars.BarSubItem = Me.GetParent(item.Parent)
            Dim button As DevExpress.Xpf.Bars.BarButtonItem = New DevExpress.Xpf.Bars.BarButtonItem With {.Content = item.Title, .Command = item.Command, .Name = "bbi" & System.Text.RegularExpressions.Regex.Replace(item.Title, "[^a-zA-Z0-9]", "")}
            Me.manager.Items.Add(button)
            parent.ItemLinks.Add(New DevExpress.Xpf.Bars.BarButtonItemLink With {.BarItemName = button.Name})
        End Sub

        Private Function GetParent(ByVal parentName As String) As BarSubItem
            For Each item As DevExpress.Xpf.Bars.BarItem In Me.manager.Items
                Dim button As DevExpress.Xpf.Bars.BarSubItem = TryCast(item, DevExpress.Xpf.Bars.BarSubItem)
                If button IsNot Nothing AndAlso Equals(button.Content.ToString(), parentName) Then Return button
            Next

            Dim newParent As DevExpress.Xpf.Bars.BarSubItem = New DevExpress.Xpf.Bars.BarSubItem With {.Content = parentName, .Name = "bsi" & System.Text.RegularExpressions.Regex.Replace(parentName, "[^a-zA-Z0-9]", "")}
            Me.manager.Items.Add(newParent)
            Me.bar.ItemLinks.Add(New DevExpress.Xpf.Bars.BarSubItemLink With {.BarItemName = newParent.Name})
            Return newParent
        End Function

        Private Sub IMenuService_Add(ByVal item As PrismOnDXDocking.Infrastructure.MenuItem) Implements Global.PrismOnDXDocking.Infrastructure.IMenuService.Add
            Me.Add(item)
        End Sub
    End Class
End Namespace
