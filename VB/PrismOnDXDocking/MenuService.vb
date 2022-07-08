Imports System.ComponentModel.Composition
Imports System.Text.RegularExpressions
Imports DevExpress.Xpf.Bars

Namespace PrismOnDXDocking.Infrastructure

    <System.ComponentModel.Composition.ExportAttribute(GetType(PrismOnDXDocking.Infrastructure.IMenuService))>
    Public Class MenuService
        Implements PrismOnDXDocking.Infrastructure.IMenuService

        Private ReadOnly bar As DevExpress.Xpf.Bars.Bar

        Private ReadOnly manager As DevExpress.Xpf.Bars.BarManager

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

        Private Sub IMenuService_Add(ByVal item As PrismOnDXDocking.Infrastructure.MenuItem) Implements Global.PrismOnDXDocking.Infrastructure.IMenuService.Add
            Me.Add(item)
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
    End Class
End Namespace
