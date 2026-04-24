using System.Windows.Controls;

namespace PrismOnDXDocking.ExampleModule.Views {
    public partial class PropertiesView : UserControl {
        public PropertiesView() {
            InitializeComponent();
        }
        public string PanelCaption { get { return "Properties"; } }
    }
}