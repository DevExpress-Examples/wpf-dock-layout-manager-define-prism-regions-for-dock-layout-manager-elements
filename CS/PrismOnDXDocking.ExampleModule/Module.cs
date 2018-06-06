using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using PrismOnDXDocking.ExampleModule.Views;
using PrismOnDXDocking.Infrastructure;
using Prism.Modularity;
using Prism.Regions;
using Prism.Commands;
using Prism.Mef.Modularity;

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
            showOutput = new DelegateCommand(ShowOutput);
            showProperties = new DelegateCommand(ShowProperties);
            showToolbox = new DelegateCommand(ShowToolbox);
            newDocument = new DelegateCommand(AddNewDocument);
		}
        public void Initialize() {
            regionManager.RegisterViewWithRegion(RegionNames.DefaultViewRegion, typeof(DefaultView));

            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance<ToolBoxView>());
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance<PropertiesView>());
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance<DocumentView>());

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

        void IModule.Initialize() {
            Initialize();
        }
    }
}