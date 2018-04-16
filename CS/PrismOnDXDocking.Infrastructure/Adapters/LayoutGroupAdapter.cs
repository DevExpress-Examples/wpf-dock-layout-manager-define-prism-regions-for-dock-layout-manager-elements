using Microsoft.VisualBasic;
using System;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using DevExpress.Xpf.Docking;

namespace PrismOnDXDocking.Infrastructure.Adapters {
	[Export(typeof(LayoutGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
	public class LayoutGroupAdapter : RegionAdapterBase<LayoutGroup> {
        [ImportingConstructor]
		public LayoutGroupAdapter(IRegionBehaviorFactory behaviorFactory) : 
            base(behaviorFactory) {
		}
		protected override IRegion CreateRegion() {
			 return new AllActiveRegion();
		}
		protected override void Adapt(IRegion region, LayoutGroup regionTarget) {
            region.Views.CollectionChanged += (s, e) => {
                OnViewsCollectionChanged(region, regionTarget, s, e);
            };
		}

        void OnViewsCollectionChanged(IRegion region, LayoutGroup regionTarget, object sender, NotifyCollectionChangedEventArgs e) {
			if(e.Action == NotifyCollectionChangedAction.Add) {
				foreach(object view in e.NewItems) {
					LayoutPanel panel = new LayoutPanel();
					panel.Content = view;
					if(view is IPanelInfo) 
						panel.Caption = ((IPanelInfo)view).GetPanelCaption();
					else panel.Caption = "new Page";
					regionTarget.Items.Add(panel);
					regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1;
				}
			}
		}
	}
}
