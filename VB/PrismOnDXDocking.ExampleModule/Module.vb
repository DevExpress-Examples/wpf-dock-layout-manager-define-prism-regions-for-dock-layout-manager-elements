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
		Private ReadOnly _regionManager As IRegionManager
		Private ReadOnly _menuService As IMenuService
		Private ReadOnly _showOutput As DelegateCommand
		Private ReadOnly _showProperties As DelegateCommand
		Private ReadOnly _showToolbox As DelegateCommand
		Private ReadOnly _newDocument As DelegateCommand


		<ImportingConstructor> _
		Public Sub New(ByVal regionManager As IRegionManager, ByVal menuService As IMenuService)
			_regionManager = regionManager
			_menuService = menuService
			_showOutput = New DelegateCommand(AddressOf ShowOutput)
			_showProperties = New DelegateCommand(AddressOf ShowProperties)
			_showToolbox = New DelegateCommand(AddressOf ShowToolbox)
			_newDocument = New DelegateCommand(AddressOf AddNewDocument)
		End Sub
        Public Sub Initialize() Implements IModule.Initialize
            _regionManager.RegisterViewWithRegion(RegionNames.DefaultViewRegion, GetType(DefaultView))
            _menuService.Add(New MenuItem() With {.Command = _showOutput, .Parent = "View", .Title = "Output"})
            _menuService.Add(New MenuItem() With {.Command = _showProperties, .Parent = "View", .Title = "Properties Window"})
            _menuService.Add(New MenuItem() With {.Command = _showToolbox, .Parent = "View", .Title = "Toolbox"})
            _menuService.Add(New MenuItem() With {.Command = _newDocument, .Parent = "File", .Title = "New"})
        End Sub

		Private Sub ShowOutput()
			_regionManager.AddToRegion(RegionNames.TabRegion, ServiceLocator.Current.GetInstance(Of OutputView)())
		End Sub

		Private Sub ShowToolbox()
			_regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance(Of ToolBoxView)())
		End Sub

		Private Sub ShowProperties()
			_regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance(Of PropertiesView)())
		End Sub

		Private Sub AddNewDocument()
			_regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance(Of DocumentView)())
		End Sub
	End Class
End Namespace