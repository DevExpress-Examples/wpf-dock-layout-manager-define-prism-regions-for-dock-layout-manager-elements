Imports System.ComponentModel.Composition
Imports System.Linq
Imports DevExpress.Mvvm
Imports Microsoft.Practices.ServiceLocation
Imports Prism.Mef.Modularity
Imports Prism.Modularity
Imports Prism.Regions
Imports PrismOnDXDocking.ExampleModule.Views
Imports PrismOnDXDocking.Infrastructure
Imports System.Runtime.InteropServices

Namespace PrismOnDXDocking.ExampleModule

    <ModuleExport(GetType(ExampleModule))>
    Public Class ExampleModule
        Implements IModule

        Private ReadOnly menuService As IMenuService

        Private ReadOnly regionManager As IRegionManager

        <ImportingConstructor>
        Public Sub New(ByVal regionManager As IRegionManager, ByVal menuService As IMenuService)
            Me.regionManager = regionManager
            Me.menuService = menuService
        End Sub

        Public Sub Initialize()
            regionManager.RegisterViewWithRegion(RegionNames.TabRegion, GetType(DefaultView))
            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())
            menuService.Add(New MenuItem() With {.Command = New DelegateCommand(AddressOf ShowOutput), .Parent = "View", .Title = "Output"})
            menuService.Add(New MenuItem() With {.Command = New DelegateCommand(AddressOf ShowProperties), .Parent = "View", .Title = "Properties Window"})
            menuService.Add(New MenuItem() With {.Command = New DelegateCommand(AddressOf ShowToolbox), .Parent = "View", .Title = "Toolbox"})
            menuService.Add(New MenuItem() With {.Command = New DelegateCommand(AddressOf AddNewDocument), .Parent = "File", .Title = "New"})
        End Sub

        Private Sub AddNewDocument()
            Call Show(Of DocumentView)(RegionNames.MainRegion, True)
        End Sub

        Private Function GetView(Of T)(ByVal region As IRegion, <Out> ByRef view As T) As Boolean
            view = region.Views.OfType(Of T)().FirstOrDefault()
            Return view IsNot Nothing
        End Function

        Private Sub IModule_Initialize() Implements IModule.Initialize
            Initialize()
        End Sub

        Private Sub Show(Of T)(ByVal regionName As String, ByVal Optional addNew As Boolean = False)
            Dim region = regionManager.Regions(regionName)
            Dim view As T
            If addNew OrElse Not GetView(region, view) Then
                view = ServiceLocator.Current.GetInstance(Of T)()
                regionManager.AddToRegion(regionName, view)
            End If

            region.Activate(view)
        End Sub

        Private Sub ShowOutput()
            Show(Of OutputView)(RegionNames.TabRegion)
        End Sub

        Private Sub ShowProperties()
            Show(Of PropertiesView)(RegionNames.RightRegion)
        End Sub

        Private Sub ShowToolbox()
            Show(Of ToolBoxView)(RegionNames.LeftRegion)
        End Sub
    End Class
End Namespace
