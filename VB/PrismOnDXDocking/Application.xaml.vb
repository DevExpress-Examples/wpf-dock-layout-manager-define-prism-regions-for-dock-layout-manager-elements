Imports DevExpress.Xpf.Docking
Imports DevExpress.Xpf.Prism
Imports Prism.Ioc
Imports Prism.Modularity
Imports Prism.Regions
Imports Prism.Unity
Imports PrismOnDXDocking.Infrastructure
Imports System
Imports System.Windows

Namespace PrismOnDXDocking
	Partial Public Class App
		Inherits PrismApplication

		Protected Overrides Function CreateShell() As Window
			Return Container.Resolve(Of Shell)()
		End Function
		Protected Overrides Sub RegisterTypes(ByVal containerRegistry As IContainerRegistry)
			containerRegistry.RegisterSingleton(GetType(Shell))
			containerRegistry.Register(Of IMenuService, MenuService)()
		End Sub

		Protected Overrides Sub ConfigureModuleCatalog(ByVal moduleCatalog As IModuleCatalog)
			moduleCatalog.AddModule(Of PrismOnDXDocking.ExampleModule.ExampleModule)()
		End Sub

		Protected Overrides Sub ConfigureRegionAdapterMappings(ByVal regionAdapterMappings As RegionAdapterMappings)
			MyBase.ConfigureRegionAdapterMappings(regionAdapterMappings)

			Dim factory = Container.Resolve(Of IRegionBehaviorFactory)()
			regionAdapterMappings.RegisterMapping(GetType(LayoutPanel), AdapterFactory.Make(Of RegionAdapterBase(Of LayoutPanel))(factory))
			regionAdapterMappings.RegisterMapping(GetType(LayoutGroup), AdapterFactory.Make(Of RegionAdapterBase(Of LayoutGroup))(factory))
			regionAdapterMappings.RegisterMapping(GetType(TabbedGroup), AdapterFactory.Make(Of RegionAdapterBase(Of TabbedGroup))(factory))
			regionAdapterMappings.RegisterMapping(GetType(DocumentGroup), AdapterFactory.Make(Of RegionAdapterBase(Of DocumentGroup))(factory))
		End Sub

	End Class
End Namespace