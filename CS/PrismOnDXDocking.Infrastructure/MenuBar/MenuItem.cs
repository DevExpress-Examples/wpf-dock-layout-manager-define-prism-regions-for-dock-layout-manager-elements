using System.Windows.Input;

namespace PrismOnDXDocking.Infrastructure {
	public class MenuItem {
		public string Parent { get; set; }
		public string Title { get; set; }
		public ICommand Command { get; set; }
	}
}