using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Regions;
using DevExpress.Xpf.Docking;
using System.Collections.Specialized;
using System.ComponentModel.Composition;

namespace PrismOnDXDocking.Infrastructure.Adapters {
    [Export(typeof(DocumentGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DocumentGroupAdapter : RegionAdapterBase<DocumentGroup> {
        [ImportingConstructor]
        public DocumentGroupAdapter(IRegionBehaviorFactory behaviorFactory) :
            base(behaviorFactory) {
        }
        protected override IRegion CreateRegion() {
            return new AllActiveRegion();
        }
        protected override void Adapt(IRegion region, DocumentGroup regionTarget) {
            region.Views.CollectionChanged += (s, e) => {
                OnViewsCollectionChanged(region, regionTarget, s, e);
            };
        }
        void OnViewsCollectionChanged(IRegion region, DocumentGroup regionTarget, object sender, NotifyCollectionChangedEventArgs e) {
            if(e.Action == NotifyCollectionChangedAction.Add) {
                foreach(object view in e.NewItems) {
                    DockLayoutManager manager = regionTarget.GetDockLayoutManager();
                    DocumentPanel panel = manager.DockController.AddDocumentPanel(regionTarget);
                    panel.Content = view;
                    if(view is IPanelInfo)
                        panel.Caption = ((IPanelInfo)view).GetPanelCaption();
                    else panel.Caption = "new Page";
                    manager.DockController.Activate(panel);
                }
            }
        }
    }
}
