using System.Windows.Controls;

namespace PrismOnDXDocking.ExampleModule.Views {
    public partial class DocumentView : UserControl {
        public DocumentView() {
            InitializeComponent();
        }
        public string PanelCaption { get { return "new document"; } }
    }
}