using System.Windows.Controls;
using PrismOnDXDocking.Infrastructure;
using System.ComponentModel.Composition;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class DocumentView : UserControl, IPanelInfo {
		public DocumentView() {
			InitializeComponent();
		}
        string IPanelInfo.GetPanelCaption() {
            return "new document";
        }
	}
}
