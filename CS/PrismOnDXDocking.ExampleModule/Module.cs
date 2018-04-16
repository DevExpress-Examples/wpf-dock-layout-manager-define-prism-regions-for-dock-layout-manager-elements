using Microsoft.VisualBasic;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using PrismOnDXDocking.ExampleModule.Views;
using PrismOnDXDocking.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace PrismOnDXDocking.ExampleModule {
	[ModuleExport(typeof(ExampleModule))]
	public class ExampleModule : IModule {
		private readonly IRegionManager regionManager;
		private readonly IMenuService menuService;
		private readonly DelegateCommand showOutput;
		private readonly DelegateCommand showProperties;
		private readonly DelegateCommand showToolbox;
		private readonly DelegateCommand newDocument;
		[ImportingConstructor]
        public ExampleModule(IRegionManager regionManager, IMenuService menuService) {
			this.regionManager = regionManager;
            this.menuService = menuService;
            this.showOutput = new DelegateCommand(ShowOutput);
            this.showProperties = new DelegateCommand(ShowProperties);
            this.showToolbox = new DelegateCommand(ShowToolbox);
            this.newDocument = new DelegateCommand(AddNewDocument);
		}
        public void Initialize() {
            regionManager.RegisterViewWithRegion(RegionNames.DefaultViewRegion, typeof(DefaultView));
            menuService.Add(new MenuItem() { Command = showOutput, Parent = "View", Title = "Output"});
            menuService.Add(new MenuItem() { Command = showProperties, Parent = "View", Title = "Properties Window"});
            menuService.Add(new MenuItem() { Command = showToolbox, Parent = "View", Title = "Toolbox"});
            menuService.Add(new MenuItem() { Command = newDocument, Parent = "File", Title = "New"});
        }

		void ShowOutput() {
			regionManager.AddToRegion(RegionNames.TabRegion, ServiceLocator.Current.GetInstance<OutputView>());
		}
		void ShowToolbox() {
			regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance<ToolBoxView>());
		}
		void ShowProperties() {
			regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance<PropertiesView>());
		}
		void AddNewDocument() {
			regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance<DocumentView>());
		}
	}
}