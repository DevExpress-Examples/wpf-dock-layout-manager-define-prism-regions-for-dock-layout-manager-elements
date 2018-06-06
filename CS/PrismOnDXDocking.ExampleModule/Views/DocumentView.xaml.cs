using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class DocumentView : UserControl {
		public DocumentView() {
			InitializeComponent();
		}
        public string PanelCaption { get { return "New Document"; } }
	}
}
