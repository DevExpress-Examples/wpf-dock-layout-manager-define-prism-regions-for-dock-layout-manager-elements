using System.Windows.Controls;
using System.ComponentModel.Composition;
using PrismOnDXDocking.Infrastructure;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class PropertiesView : UserControl, IPanelInfo {
		public PropertiesView() {
			InitializeComponent();
		}
        string IPanelInfo.GetPanelCaption() {
            return "Properties";
        }
	}
}
