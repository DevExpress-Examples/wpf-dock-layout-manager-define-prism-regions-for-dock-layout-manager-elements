Imports System
Imports System.ComponentModel.Composition
Imports System.Linq
Imports DevExpress.Mvvm
Imports Microsoft.Practices.ServiceLocation
Imports Prism.Mef.Modularity
Imports Prism.Modularity
Imports Prism.Regions
Imports PrismOnDXDocking.ExampleModule.Views
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule
    <ModuleExport(GetType(ExampleModule))> _
    Public Class ExampleModule
        Implements IModule

        Private ReadOnly regionManager As IRegionManager
        Private ReadOnly menuService As IMenuService
        <ImportingConstructor> _
        Public Sub New(ByVal regionManager As IRegionManager, ByVal menuService As IMenuService)
            Me.regionManager = regionManager
            Me.menuService = menuService
        End Sub
        Public Sub Initialize()
            regionManager.RegisterViewWithRegion(RegionNames.TabRegion, GetType(DefaultView))

            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())

            menuService.Add(New MenuItem() With { _
                .Command = New DelegateCommand(AddressOf ShowOutput), _
                .Parent = "View", _
                .Title = "Output" _
            })
            menuService.Add(New MenuItem() With { _
                .Command = New DelegateCommand(AddressOf ShowProperties), _
                .Parent = "View", _
                .Title = "Properties Window" _
            })
            menuService.Add(New MenuItem() With { _
                .Command = New DelegateCommand(AddressOf ShowToolbox), _
                .Parent = "View", _
                .Title = "Toolbox" _
            })
            menuService.Add(New MenuItem() With { _
                .Command = New DelegateCommand(AddressOf AddNewDocument), _
                .Parent = "File", _
                .Title = "New" _
            })
        End Sub

        Private Sub ShowOutput()
            Show(Of OutputView)(RegionNames.TabRegion)
        End Sub
        Private Sub ShowToolbox()
            Show(Of ToolBoxView)(RegionNames.LeftRegion)
        End Sub
        Private Sub ShowProperties()
            Show(Of PropertiesView)(RegionNames.RightRegion)
        End Sub
        Private Sub AddNewDocument()
            Show(Of DocumentView)(RegionNames.MainRegion, True)
        End Sub
        Private Sub Show(Of T)(ByVal regionName As String, Optional ByVal addNew As Boolean = False)
            Dim region = regionManager.Regions(regionName)
            Dim view As T = Nothing
            If addNew OrElse Not GetView(Of T)(region, view) Then
                view = ServiceLocator.Current.GetInstance(Of T)()
                regionManager.AddToRegion(regionName, view)
            End If
            region.Activate(view)
        End Sub
        Private Function GetView(Of T)(ByVal region As IRegion, ByRef view As T) As Boolean
            view = region.Views.OfType(Of T)().FirstOrDefault()
            Return view IsNot Nothing
        End Function
    End Class
End Namespace