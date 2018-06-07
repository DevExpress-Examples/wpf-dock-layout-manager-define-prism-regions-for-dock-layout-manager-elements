using System.ComponentModel.Composition;
using System.Windows.Controls;
using PrismOnDXDocking.Infrastructure;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class OutputView : UserControl, IPanelInfo {
		public OutputView() {
			InitializeComponent();
		}
        string IPanelInfo.GetPanelCaption() {
            return "Output";
        }
	}
}
