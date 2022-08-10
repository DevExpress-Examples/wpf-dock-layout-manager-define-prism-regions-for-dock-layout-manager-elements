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
Imports Microsoft.Practices.ServiceLocation
Imports PrismOnDXDocking.ExampleModule.Views
Imports PrismOnDXDocking.Infrastructure
Imports Prism.Modularity
Imports Prism.Regions
Imports Prism.Commands
Imports Prism.Mef.Modularity

Namespace PrismOnDXDocking.ExampleModule

    <ModuleExport(GetType(ExampleModule))>
    Public Class ExampleModule
        Inherits IModule

        Private ReadOnly regionManager As IRegionManager

        Private ReadOnly menuService As PrismOnDXDocking.Infrastructure.IMenuService

        Private ReadOnly showOutputField As DelegateCommand

        Private ReadOnly showPropertiesField As DelegateCommand

        Private ReadOnly showToolboxField As DelegateCommand

        Private ReadOnly newDocument As DelegateCommand

        <ImportingConstructor>
        Public Sub New(ByVal regionManager As IRegionManager, ByVal menuService As PrismOnDXDocking.Infrastructure.IMenuService)
            Me.regionManager = regionManager
            Me.menuService = menuService
            showOutputField = New DelegateCommand(AddressOf ShowOutput)
            showPropertiesField = New DelegateCommand(AddressOf ShowProperties)
            showToolboxField = New DelegateCommand(AddressOf ShowToolbox)
            newDocument = New DelegateCommand(AddressOf AddNewDocument)
        End Sub

        Public Sub Initialize()
            regionManager.RegisterViewWithRegion(PrismOnDXDocking.Infrastructure.RegionNames.DefaultViewRegion, GetType(DefaultView))
            regionManager.AddToRegion(PrismOnDXDocking.Infrastructure.RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
            regionManager.AddToRegion(PrismOnDXDocking.Infrastructure.RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
            regionManager.AddToRegion(PrismOnDXDocking.Infrastructure.RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())
            menuService.Add(New PrismOnDXDocking.Infrastructure.MenuItem() With {.Command = showOutputField, .Parent = "View", .Title = "Output"})
            menuService.Add(New PrismOnDXDocking.Infrastructure.MenuItem() With {.Command = showPropertiesField, .Parent = "View", .Title = "Properties Window"})
            menuService.Add(New PrismOnDXDocking.Infrastructure.MenuItem() With {.Command = showToolboxField, .Parent = "View", .Title = "Toolbox"})
            menuService.Add(New PrismOnDXDocking.Infrastructure.MenuItem() With {.Command = newDocument, .Parent = "File", .Title = "New"})
        End Sub

        Private Sub ShowOutput()
            regionManager.AddToRegion(PrismOnDXDocking.Infrastructure.RegionNames.TabRegion, ServiceLocator.Current.GetInstance(Of OutputView)())
        End Sub

        Private Sub ShowToolbox()
            regionManager.AddToRegion(PrismOnDXDocking.Infrastructure.RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
        End Sub

        Private Sub ShowProperties()
            regionManager.AddToRegion(PrismOnDXDocking.Infrastructure.RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
        End Sub

        Private Sub AddNewDocument()
            regionManager.AddToRegion(PrismOnDXDocking.Infrastructure.RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())
        End Sub

        Private Sub Initialize()
            Me.Initialize()
        End Sub
    End Class
End Namespace
