using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using PrismOnDXDocking.Infrastructure;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
    public partial class DocumentView : UserControl, IPanelInfo {
        public DocumentView() {
            InitializeComponent();
        }
        public string PanelCaption { get { return "new document"; } }
    }
}