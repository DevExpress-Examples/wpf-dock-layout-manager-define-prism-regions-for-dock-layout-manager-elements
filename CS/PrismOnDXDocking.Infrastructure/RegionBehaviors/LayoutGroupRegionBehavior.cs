using Microsoft.VisualBasic;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using DevExpress.Xpf.Docking;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Regions.Behaviors;

namespace PrismOnDXDocking.Infrastructure.Behaviors {
	[Export(typeof(LayoutGroupRegionBehavior)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class LayoutGroupRegionBehavior : RegionBehavior, IHostAwareRegionBehavior {
		[Import]
		public IRegionManager RegionManager { get; set; }
        public DependencyObject HostControl { get; set; }
		protected override void OnAttach() {
			RegisterRegion();
		}
		 void RegisterRegion() {
			DependencyObject targetElement = HostControl;
			if(targetElement.CheckAccess()) {
				LayoutGroup lg = targetElement as LayoutGroup;
				if(lg != null && RegionManager != null) 
                    RegionManager.Regions.Add(Region);
			}
		}
	}
}
