Imports System.Linq
Imports DevExpress.Mvvm
Imports Prism.Ioc
Imports Prism.Modularity
Imports Prism.Navigation.Regions
Imports PrismOnDXDocking.ExampleModule.Views
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule
    Public Class ExampleModule
        Implements IModule

        Private ReadOnly menuService As IMenuService
        Private regionManager As IRegionManager
        Private containerProvider As IContainerProvider

        Public Sub New(menuService As IMenuService)
            Me.menuService = menuService
        End Sub

        Public Sub OnInitialized(containerProvider As IContainerProvider) Implements IModule.OnInitialized
            Me.containerProvider = containerProvider
            regionManager = containerProvider.Resolve(Of IRegionManager)()

            regionManager.RegisterViewWithRegion(RegionNames.TabRegion, GetType(DefaultView))

            regionManager.AddToRegion(RegionNames.LeftRegion, containerProvider.Resolve(Of ToolBoxView)())
            regionManager.AddToRegion(RegionNames.RightRegion, containerProvider.Resolve(Of PropertiesView)())
            regionManager.AddToRegion(RegionNames.MainRegion, containerProvider.Resolve(Of DocumentView)())

            menuService.Add(New MenuItem With {.Command = New DelegateCommand(AddressOf ShowOutput), .Parent = "View", .Title = "Output"})
            menuService.Add(New MenuItem With {.Command = New DelegateCommand(AddressOf ShowProperties), .Parent = "View", .Title = "Properties Window"})
            menuService.Add(New MenuItem With {.Command = New DelegateCommand(AddressOf ShowToolbox), .Parent = "View", .Title = "Toolbox"})
            menuService.Add(New MenuItem With {.Command = New DelegateCommand(AddressOf AddNewDocument), .Parent = "File", .Title = "New"})
        End Sub

        Public Sub RegisterTypes(containerRegistry As IContainerRegistry) Implements IModule.RegisterTypes

        End Sub

        Private Sub AddNewDocument()
            Show(Of DocumentView)(RegionNames.MainRegion, True)
        End Sub

        Private Function GetView(Of T)(region As IRegion, ByRef view As T) As Boolean
            view = region.Views.OfType(Of T)().FirstOrDefault()
            Return view IsNot Nothing
        End Function

        Private Sub Show(Of T)(regionName As String, Optional addNew As Boolean = False)
            Dim region = regionManager.Regions(regionName)
            Dim view As T

            If addNew OrElse Not GetView(region, view) Then
                view = containerProvider.Resolve(Of T)()
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