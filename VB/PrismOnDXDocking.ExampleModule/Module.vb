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
        Implements IModule

        Private ReadOnly regionManager As IRegionManager

        Private ReadOnly menuService As IMenuService

        Private ReadOnly showOutputField As DelegateCommand

        Private ReadOnly showPropertiesField As DelegateCommand

        Private ReadOnly showToolboxField As DelegateCommand

        Private ReadOnly newDocument As DelegateCommand

        <ImportingConstructor>
        Public Sub New(ByVal regionManager As IRegionManager, ByVal menuService As IMenuService)
            Me.regionManager = regionManager
            Me.menuService = menuService
            showOutputField = New DelegateCommand(AddressOf ShowOutput)
            showPropertiesField = New DelegateCommand(AddressOf ShowProperties)
            showToolboxField = New DelegateCommand(AddressOf ShowToolbox)
            newDocument = New DelegateCommand(AddressOf AddNewDocument)
        End Sub

        Public Sub Initialize()
            regionManager.RegisterViewWithRegion(RegionNames.DefaultViewRegion, GetType(DefaultView))
            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())
            menuService.Add(New MenuItem() With {.Command = showOutputField, .Parent = "View", .Title = "Output"})
            menuService.Add(New MenuItem() With {.Command = showPropertiesField, .Parent = "View", .Title = "Properties Window"})
            menuService.Add(New MenuItem() With {.Command = showToolboxField, .Parent = "View", .Title = "Toolbox"})
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

        Private Sub IModule_Initialize() Implements IModule.Initialize
            Initialize()
        End Sub
    End Class
End Namespace
