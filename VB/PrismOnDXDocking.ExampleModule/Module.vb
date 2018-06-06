Imports System.ComponentModel.Composition
Imports Microsoft.Practices.ServiceLocation
Imports PrismOnDXDocking.ExampleModule.Views
Imports PrismOnDXDocking.Infrastructure
Imports Prism.Modularity
Imports Prism.Regions
Imports Prism.Commands
Imports Prism.Mef.Modularity

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
            showOutput_Renamed = New DelegateCommand(AddressOf ShowOutput)
            showProperties_Renamed = New DelegateCommand(AddressOf ShowProperties)
            showToolbox_Renamed = New DelegateCommand(AddressOf ShowToolbox)
            newDocument = New DelegateCommand(AddressOf AddNewDocument)
        End Sub
        Public Sub Initialize()
            regionManager.RegisterViewWithRegion(RegionNames.DefaultViewRegion, GetType(DefaultView))

            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())

            menuService.Add(New MenuItem() With { _
                .Command = showOutput_Renamed, _
                .Parent = "View", _
                .Title = "Output" _
            })
            menuService.Add(New MenuItem() With { _
                .Command = showProperties_Renamed, _
                .Parent = "View", _
                .Title = "Properties Window" _
            })
            menuService.Add(New MenuItem() With { _
                .Command = showToolbox_Renamed, _
                .Parent = "View", _
                .Title = "Toolbox" _
            })
            menuService.Add(New MenuItem() With { _
                .Command = newDocument, _
                .Parent = "File", _
                .Title = "New" _
            })
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