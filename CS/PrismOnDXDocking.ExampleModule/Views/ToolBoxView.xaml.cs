using System.Windows.Controls;
using System.ComponentModel.Composition;
using PrismOnDXDocking.Infrastructure;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class ToolBoxView : UserControl, IPanelInfo {
		public ToolBoxView() {
			InitializeComponent();
		}
        string IPanelInfo.GetPanelCaption() {
            return "Toolbox";
        }
	}
}
