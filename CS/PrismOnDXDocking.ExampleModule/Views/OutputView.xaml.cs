using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class OutputView : UserControl {
		public OutputView() {
			InitializeComponent();
		}
        public string PanelCaption { get { return "Output"; } }
    }
}
