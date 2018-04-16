Imports Microsoft.VisualBasic
Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports Microsoft.Practices.Prism.MefExtensions
Imports Microsoft.Practices.Prism.Regions
Imports PrismOnDXDocking.Infrastructure
Imports PrismOnDXDocking.Infrastructure.Adapters
Imports PrismOnDXDocking.Infrastructure.Behaviors

Namespace PrismOnDXDocking
	Public Class Bootstrapper
		Inherits MefBootstrapper
		Protected Overrides Sub ConfigureAggregateCatalog()
			AggregateCatalog.Catalogs.Add(New System.ComponentModel.Composition.Hosting.AssemblyCatalog(GetType(Bootstrapper).Assembly))
			AggregateCatalog.Catalogs.Add(New System.ComponentModel.Composition.Hosting.AssemblyCatalog(GetType(RegionNames).Assembly))
			AggregateCatalog.Catalogs.Add(New System.ComponentModel.Composition.Hosting.AssemblyCatalog(GetType(ExampleModule.ExampleModule).Assembly))
		End Sub
		Protected Overrides Function CreateShell() As DependencyObject
			Return Container.GetExportedValue(Of Shell)()
		End Function
		Protected Overrides Sub InitializeShell()
			MyBase.InitializeShell()
			Application.Current.MainWindow = CType(Shell, Shell)
			Application.Current.MainWindow.Show()
		End Sub
		Protected Overrides Function ConfigureRegionAdapterMappings() As RegionAdapterMappings
			Dim mappings As RegionAdapterMappings = MyBase.ConfigureRegionAdapterMappings()
			mappings.RegisterMapping(GetType(LayoutPanel), Container.GetExportedValue(Of LayoutPanelAdapter)())
			mappings.RegisterMapping(GetType(LayoutGroup), Container.GetExportedValue(Of LayoutGroupAdapter)())
			mappings.RegisterMapping(GetType(DocumentGroup), Container.GetExportedValue(Of DocumentGroupAdapter)())
			'mappings.RegisterMapping(typeof(TabbedGroup), Container.GetExportedValue<TabbedGroupAdapter>());
			Return mappings
		End Function
	End Class
End Namespace