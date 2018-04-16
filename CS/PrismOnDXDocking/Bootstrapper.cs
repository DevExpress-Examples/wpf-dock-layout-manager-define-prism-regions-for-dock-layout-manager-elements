using System.Windows;
using DevExpress.Xpf.Docking;
using PrismOnDXDocking.Infrastructure;
using DevExpress.Xpf.Prism;
using Prism.Mef;
using Prism.Regions;

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
            var factory = Container.GetExportedValue<IRegionBehaviorFactory>();
            mappings.RegisterMapping(typeof(LayoutPanel), AdapterFactory.Make<RegionAdapterBase<LayoutPanel>>(factory));
            mappings.RegisterMapping(typeof(LayoutGroup), AdapterFactory.Make<RegionAdapterBase<LayoutGroup>>(factory));
            mappings.RegisterMapping(typeof(TabbedGroup), AdapterFactory.Make<RegionAdapterBase<TabbedGroup>>(factory));
            mappings.RegisterMapping(typeof(DocumentGroup), AdapterFactory.Make<RegionAdapterBase<DocumentGroup>>(factory));
            return mappings;
		}
	}
}