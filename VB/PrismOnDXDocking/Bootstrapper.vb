Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports DevExpress.Xpf.Prism
Imports Prism.Mef
Imports Prism.Regions
Imports PrismOnDXDocking.Infrastructure

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
            Dim factory = Container.GetExportedValue(Of IRegionBehaviorFactory)()
            mappings.RegisterMapping(GetType(LayoutPanel), AdapterFactory.Make(Of RegionAdapterBase(Of LayoutPanel))(factory))
            mappings.RegisterMapping(GetType(LayoutGroup), AdapterFactory.Make(Of RegionAdapterBase(Of LayoutGroup))(factory))
            mappings.RegisterMapping(GetType(TabbedGroup), AdapterFactory.Make(Of RegionAdapterBase(Of TabbedGroup))(factory))
            mappings.RegisterMapping(GetType(DocumentGroup), AdapterFactory.Make(Of RegionAdapterBase(Of DocumentGroup))(factory))
            Return mappings
        End Function
    End Class
End Namespace