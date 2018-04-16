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