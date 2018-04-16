using Microsoft.VisualBasic;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;
using DevExpress.Xpf.Docking;
using System;

namespace PrismOnDXDocking.Infrastructure.Adapters {
	[Export(typeof(LayoutPanelAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class LayoutPanelAdapter : RegionAdapterBase<LayoutPanel> {
        [ImportingConstructor]
		public LayoutPanelAdapter(IRegionBehaviorFactory behaviorFactory) : 
            base(behaviorFactory) { 
		}
		protected override IRegion CreateRegion() {
			return new SingleActiveRegion();
		}
		protected override void Adapt(IRegion region, LayoutPanel regionTarget) {
			string regionName = RegionManager.GetRegionName(regionTarget);
			if(!String.IsNullOrEmpty(regionName)) {
				if(regionTarget != null && regionTarget.Content == null) {
					ContentControl control = new ContentControl();
					RegionManager.SetRegionName(control, regionName);
                    regionTarget.Content = control;
				}
			}
		}
	}
}
