using Microsoft.VisualBasic;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;
using DevExpress.Xpf.Docking;
using System;
using System.Collections.Specialized;

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
            region.Views.CollectionChanged += (d, e) => {
                if(e.NewItems != null) 
                    regionTarget.Content = e.NewItems[0];
            };
		}
	}
}
