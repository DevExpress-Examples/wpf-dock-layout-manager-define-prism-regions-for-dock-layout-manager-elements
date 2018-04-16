using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using PrismOnDXDocking.Infrastructure;

namespace PrismOnDXDocking.ExampleModule.Views {
	[PartCreationPolicy(CreationPolicy.NonShared), Export]
	public partial class PropertiesView : UserControl, IPanelInfo {
		public PropertiesView() {
			InitializeComponent();
		}
        public string GetPanelCaption() {
            return "Properties";
        }
	}
}
