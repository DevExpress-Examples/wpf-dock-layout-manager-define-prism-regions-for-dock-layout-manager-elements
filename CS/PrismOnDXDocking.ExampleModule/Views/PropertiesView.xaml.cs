using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class PropertiesView : UserControl {
		public PropertiesView() {
			InitializeComponent();
		}
        public string PanelCaption { get { return "Properties"; } }
	}
}
