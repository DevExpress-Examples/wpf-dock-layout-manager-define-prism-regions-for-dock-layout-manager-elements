using System.ComponentModel.Composition;
using System.Windows;
using DevExpress.Xpf.Docking;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace PrismOnDXDocking.Infrastructure.Behaviors {
    [Export(typeof(TabbedGroupRegionBehavior)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class TabbedGroupRegionBehavior : RegionBehavior, IHostAwareRegionBehavior {
		[Import]
		public IRegionManager RegionManager { get; set; }
		public DependencyObject HostControl { get; set; }
		protected override void OnAttach() {
			RegisterRegion();
		}
	    void RegisterRegion() {
			DependencyObject targetElement = HostControl;
			if(targetElement.CheckAccess()) {
				TabbedGroup tg = targetElement as TabbedGroup;
				if(tg != null && RegionManager != null)
				    RegionManager.Regions.Add(Region);
			}
		}
	}
}