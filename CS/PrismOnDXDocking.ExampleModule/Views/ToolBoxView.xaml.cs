using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class ToolBoxView : UserControl {
		public ToolBoxView() {
			InitializeComponent();
		}
        public string PanelCaption { get { return "Toolbox"; } }
	}
}
