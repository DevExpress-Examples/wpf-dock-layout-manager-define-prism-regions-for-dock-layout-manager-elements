using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using PrismOnDXDocking.Infrastructure;

namespace PrismOnDXDocking.ExampleModule.Views {
    [PartCreationPolicy(CreationPolicy.NonShared), Export]
    public partial class PropertiesView : UserControl, IPanelInfo {
        public PropertiesView() {
            InitializeComponent();
        }
        public string PanelCaption { get { return "Properties"; } }
    }
}