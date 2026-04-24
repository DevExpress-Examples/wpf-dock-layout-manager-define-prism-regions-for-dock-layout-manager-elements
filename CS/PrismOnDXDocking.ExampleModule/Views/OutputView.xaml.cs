using System.Windows.Controls;

namespace PrismOnDXDocking.ExampleModule.Views {
    public partial class OutputView : UserControl {
        public OutputView() {
            InitializeComponent();
        }
        public string PanelCaption { get { return "Output"; } }
    }
}