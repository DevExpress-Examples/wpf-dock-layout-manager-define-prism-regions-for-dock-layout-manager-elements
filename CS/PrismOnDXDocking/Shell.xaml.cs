using Microsoft.VisualBasic;
using System.ComponentModel.Composition;
using DevExpress.Xpf.Core;

namespace PrismOnDXDocking {
	[Export]
	public partial class Shell : DXWindow {
		public Shell() {
            InitializeComponent();
		}
	}
}
