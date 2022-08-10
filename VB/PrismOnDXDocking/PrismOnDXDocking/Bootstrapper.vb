' Developer Express Code Central Example:
' Prism - How to define Prism regions for various DXDocking elements
' 
' Since Prism RegionManager supports standard controls only, it is necessary to
' write custom RegionAdapters (a descendant of the
' Microsoft.Practices.Prism.Regions.RegionAdapterBase class) in order to instruct
' Prism RegionManager how to deal with DXDocking elements.
' 
' This example covers
' the following scenarios:
' 
' Using a LayoutPanel as a Prism region. The
' LayoutPanelAdapter class creates a new ContentControl containing a View and then
' places it into a target LayoutPanel.
' Using a LayoutGroup as a Prism region. The
' LayoutGroupAdapter creates a new LayoutPanel containing a View, and then adds it
' to a target LayoutGroup’s Items collection,
' Using a DocumentGroup as a Prism
' region. The DocumentGroupAdapter behaves similarly to the LayoutGroupAdapter.
' The only difference is that it manipulates DocumentPanels.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3339
Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports PrismOnDXDocking.Infrastructure.Adapters
Imports Prism.Mef
Imports Prism.Regions

Namespace PrismOnDXDocking

    Public Class Bootstrapper
        Inherits MefBootstrapper

        Protected Overrides Sub ConfigureAggregateCatalog()
            AggregateCatalog.Catalogs.Add(New System.ComponentModel.Composition.Hosting.AssemblyCatalog(GetType(Bootstrapper).Assembly))
            AggregateCatalog.Catalogs.Add(New System.ComponentModel.Composition.Hosting.AssemblyCatalog(GetType(Infrastructure.RegionNames).Assembly))
            AggregateCatalog.Catalogs.Add(New System.ComponentModel.Composition.Hosting.AssemblyCatalog(GetType(PrismOnDXDocking.ExampleModule.ExampleModule).Assembly))
        End Sub

        Protected Overrides Function CreateShell() As DependencyObject
            Return Container.GetExportedValue(Of Shell)()
        End Function

        Protected Overrides Sub InitializeShell()
            MyBase.InitializeShell()
            Application.Current.MainWindow = CType(Shell, Shell)
            Call Application.Current.MainWindow.Show()
        End Sub

        Protected Overrides Function ConfigureRegionAdapterMappings() As RegionAdapterMappings
            Dim mappings As RegionAdapterMappings = MyBase.ConfigureRegionAdapterMappings()
            mappings.RegisterMapping(GetType(LayoutPanel), Container.GetExportedValue(Of Infrastructure.Adapters.LayoutPanelAdapter)())
            mappings.RegisterMapping(GetType(LayoutGroup), Container.GetExportedValue(Of Infrastructure.Adapters.LayoutGroupAdapter)())
            mappings.RegisterMapping(GetType(DocumentGroup), Container.GetExportedValue(Of Infrastructure.Adapters.DocumentGroupAdapter)())
            Return mappings
        End Function
    End Class
End Namespace
