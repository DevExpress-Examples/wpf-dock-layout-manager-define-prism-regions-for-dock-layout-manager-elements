Imports System
Imports System.ComponentModel.Composition
Imports System.Linq
Imports CommonServiceLocator
Imports DevExpress.Mvvm
Imports Prism.Ioc
'using Microsoft.Practices.ServiceLocation;
Imports Prism.Mef.Modularity
Imports Prism.Modularity
Imports Prism.Regions
Imports PrismOnDXDocking.ExampleModule.Views
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule

	Public Class ExampleModule
		Implements IModule

		Private menuService As IMenuService
		Private regionManager As IRegionManager

		Public Sub New(ByVal menuService As IMenuService)
			Me.menuService = menuService
		End Sub


		Public Sub OnInitialized(ByVal containerProvider As IContainerProvider)
			regionManager = containerProvider.Resolve(Of IRegionManager)()

			regionManager.RegisterViewWithRegion(RegionNames.TabRegion, GetType(DefaultView))

			regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
			regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
			regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())

			menuService.Add(New MenuItem() With {
				.Command = New DelegateCommand(AddressOf ShowOutput),
				.Parent = "View",
				.Title = "Output"
			})
			menuService.Add(New MenuItem() With {
				.Command = New DelegateCommand(AddressOf ShowProperties),
				.Parent = "View",
				.Title = "Properties Window"
			})
			menuService.Add(New MenuItem() With {
				.Command = New DelegateCommand(AddressOf ShowToolbox),
				.Parent = "View",
				.Title = "Toolbox"
			})
			menuService.Add(New MenuItem() With {
				.Command = New DelegateCommand(AddressOf AddNewDocument),
				.Parent = "File",
				.Title = "New"
			})
		End Sub

		Public Sub RegisterTypes(ByVal containerRegistry As IContainerRegistry)

		End Sub

		Private Sub AddNewDocument()
			Show(Of DocumentView)(RegionNames.MainRegion, True)
		End Sub
		Private Function GetView(Of T)(ByVal region As IRegion, ByRef view As T) As Boolean
			view = region.Views.OfType(Of T)().FirstOrDefault()
			Return view IsNot Nothing
		End Function
		'void Initialize() {
		'    Initialize();
		'}
		Private Sub Show(Of T)(ByVal regionName As String, Optional ByVal addNew As Boolean = False)
			Dim region = regionManager.Regions(regionName)
			Dim view As T = Nothing
			If addNew OrElse Not GetView(Of T)(region, view) Then
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