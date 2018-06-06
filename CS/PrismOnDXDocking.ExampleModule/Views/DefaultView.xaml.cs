using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class DefaultView : UserControl {
		public DefaultView() {
            InitializeComponent();
		}
        public string PanelCaption { get { return "New Page"; } }
    }
}
