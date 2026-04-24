using System.Windows.Controls;

namespace PrismOnDXDocking.ExampleModule.Views {
    public partial class ToolBoxView : UserControl {
        public ToolBoxView() {
            InitializeComponent();
        }
        public string PanelCaption { get { return "Toolbox"; } }
    }
}