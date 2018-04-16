using Microsoft.VisualBasic;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;
using DevExpress.Xpf.Docking;
using System;

namespace PrismOnDXDocking.Infrastructure.Adapters {
	[Export(typeof(DockManagerAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class DockManagerAdapter : RegionAdapterBase<DockLayoutManager> {
 [ImportingConstructor]
		public DockManagerAdapter(IRegionBehaviorFactory behaviorFactory) : 
            base(behaviorFactory) {
		}
		protected override IRegion CreateRegion() {
			return new SingleActiveRegion();
		}
		protected override void Adapt(IRegion region, DockLayoutManager regionTarget) {
			BaseLayoutItem[] items = regionTarget.GetItems();
            foreach(BaseLayoutItem item in items) {
                string regionName = RegionManager.GetRegionName(item);
                if(!String.IsNullOrEmpty(regionName)) {
                    LayoutPanel panel = item as LayoutPanel;
                    if(panel != null && panel.Content == null) {
                        ContentControl control = new ContentControl();
                        RegionManager.SetRegionName(control, regionName);
                        panel.Content = control;
                    }
                }
            }
		}
	}
}