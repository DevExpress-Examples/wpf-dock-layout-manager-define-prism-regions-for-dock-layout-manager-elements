using Microsoft.VisualBasic;
using System;
using System.Windows;

namespace PrismOnDXDocking {
	public partial class App : Application {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			Bootstrapper bootstrapper = new Bootstrapper();
			bootstrapper.Run();
            ShutdownMode = ShutdownMode.OnMainWindowClose;
		}
	}
}