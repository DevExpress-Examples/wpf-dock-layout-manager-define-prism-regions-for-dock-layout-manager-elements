using Microsoft.VisualBasic;
using System.Windows;
using DevExpress.Xpf.Docking;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Regions;
using PrismOnDXDocking.Infrastructure;
using PrismOnDXDocking.Infrastructure.Adapters;
using PrismOnDXDocking.Infrastructure.Behaviors;

namespace PrismOnDXDocking {
	public class Bootstrapper : MefBootstrapper {
		protected override void ConfigureAggregateCatalog() {
			AggregateCatalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.AssemblyCatalog(typeof(Bootstrapper).Assembly));
			AggregateCatalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.AssemblyCatalog(typeof(RegionNames).Assembly));
			AggregateCatalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.AssemblyCatalog(typeof(ExampleModule.ExampleModule).Assembly));
		}
		protected override DependencyObject CreateShell() {
			return Container.GetExportedValue<Shell>();
		}
		protected override void InitializeShell() {
			base.InitializeShell();
			Application.Current.MainWindow = (Shell)Shell;
			Application.Current.MainWindow.Show();
		}
		protected override RegionAdapterMappings ConfigureRegionAdapterMappings() {
			RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(LayoutPanel), Container.GetExportedValue<LayoutPanelAdapter>());
            mappings.RegisterMapping(typeof(LayoutGroup), Container.GetExportedValue<LayoutGroupAdapter>());
            mappings.RegisterMapping(typeof(DocumentGroup), Container.GetExportedValue<DocumentGroupAdapter>());
            //mappings.RegisterMapping(typeof(TabbedGroup), Container.GetExportedValue<TabbedGroupAdapter>());
            return mappings;
		}
	}
}