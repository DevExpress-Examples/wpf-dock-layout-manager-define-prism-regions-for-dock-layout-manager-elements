using System.Windows.Controls;

namespace PrismOnDXDocking.ExampleModule.Views {
    public partial class DefaultView : UserControl {
        public DefaultView() {
            InitializeComponent();
        }

        public string PanelCaption { get { return "Default View"; } }
    }
}