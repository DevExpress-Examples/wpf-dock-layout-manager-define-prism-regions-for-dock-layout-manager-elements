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
Imports Microsoft.Practices.Prism.Commands
Imports Microsoft.Practices.Prism.MefExtensions.Modularity
Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.ServiceLocation
Imports PrismOnDXDocking.ExampleModule.Views
Imports PrismOnDXDocking.Infrastructure
Imports System.Collections.Generic
Imports System.Linq

Namespace PrismOnDXDocking.ExampleModule
    <ModuleExport(GetType(ExampleModule))> _
    Public Class ExampleModule
        Implements IModule

        Private ReadOnly regionManager As IRegionManager
        Private ReadOnly menuService As IMenuService

        Private ReadOnly showOutput_Renamed As DelegateCommand

        Private ReadOnly showProperties_Renamed As DelegateCommand

        Private ReadOnly showToolbox_Renamed As DelegateCommand
        Private ReadOnly newDocument As DelegateCommand
        <ImportingConstructor> _
        Public Sub New(ByVal regionManager As IRegionManager, ByVal menuService As IMenuService)
            Me.regionManager = regionManager
            Me.menuService = menuService
            Me.showOutput_Renamed = New DelegateCommand(AddressOf ShowOutput)
            Me.showProperties_Renamed = New DelegateCommand(AddressOf ShowProperties)
            Me.showToolbox_Renamed = New DelegateCommand(AddressOf ShowToolbox)
            Me.newDocument = New DelegateCommand(AddressOf AddNewDocument)
        End Sub
        Public Sub Initialize() Implements IModule.Initialize
            regionManager.RegisterViewWithRegion(RegionNames.DefaultViewRegion, GetType(DefaultView))

            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())

            menuService.Add(New MenuItem() With {.Command = showOutput_Renamed, .Parent = "View", .Title = "Output"})
            menuService.Add(New MenuItem() With {.Command = showProperties_Renamed, .Parent = "View", .Title = "Properties Window"})
            menuService.Add(New MenuItem() With {.Command = showToolbox_Renamed, .Parent = "View", .Title = "Toolbox"})
            menuService.Add(New MenuItem() With {.Command = newDocument, .Parent = "File", .Title = "New"})
        End Sub

        Private Sub ShowOutput()
            regionManager.AddToRegion(RegionNames.TabRegion, ServiceLocator.Current.GetInstance(Of OutputView)())
        End Sub
        Private Sub ShowToolbox()
            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
        End Sub
        Private Sub ShowProperties()
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
        End Sub
        Private Sub AddNewDocument()
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())
        End Sub
    End Class
End Namespace