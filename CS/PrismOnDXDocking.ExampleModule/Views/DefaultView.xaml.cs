using Microsoft.VisualBasic;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using PrismOnDXDocking.Infrastructure;

namespace PrismOnDXDocking.ExampleModule.Views {
	[PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class DefaultView : UserControl {
		public DefaultView() {
            InitializeComponent();
		}
	}
}
