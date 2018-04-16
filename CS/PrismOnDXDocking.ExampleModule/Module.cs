using Microsoft.VisualBasic;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using PrismOnDXDocking.ExampleModule.Views;
using PrismOnDXDocking.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using DevExpress.Mvvm;
using System.Windows;
using System;

namespace PrismOnDXDocking.ExampleModule {
    [ModuleExport(typeof(ExampleModule))]
    public class ExampleModule : IModule {
        private readonly IRegionManager regionManager;
        private readonly IMenuService menuService;
        [ImportingConstructor]
        public ExampleModule(IRegionManager regionManager, IMenuService menuService) {
            this.regionManager = regionManager;
            this.menuService = menuService;
        }
        public void Initialize() {
            regionManager.RegisterViewWithRegion(RegionNames.TabRegion, typeof(DefaultView));

            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance<ToolBoxView>());
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance<PropertiesView>());
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance<DocumentView>());

            menuService.Add(new MenuItem() { Command = new DelegateCommand(ShowOutput), Parent = "View", Title = "Output" });
            menuService.Add(new MenuItem() { Command = new DelegateCommand(ShowProperties), Parent = "View", Title = "Properties Window" });
            menuService.Add(new MenuItem() { Command = new DelegateCommand(ShowToolbox), Parent = "View", Title = "Toolbox" });
            menuService.Add(new MenuItem() { Command = new DelegateCommand(AddNewDocument), Parent = "File", Title = "New" });
        }

        void ShowOutput() {
            Show<OutputView>(RegionNames.TabRegion);
        }
        void ShowToolbox() {
            Show<ToolBoxView>(RegionNames.LeftRegion);
        }
        void ShowProperties() {
            Show<PropertiesView>(RegionNames.RightRegion);
        }
        void AddNewDocument() {
            Show<DocumentView>(RegionNames.MainRegion, true);
        }
        void Show<T>(string regionName, bool addNew = false) {
            var region = regionManager.Regions[regionName];
            T view;
            if (addNew || !GetView<T>(region, out view)) {
                view = ServiceLocator.Current.GetInstance<T>();
                regionManager.AddToRegion(regionName, view);
            }
            region.Activate(view);
        }
        bool GetView<T>(IRegion region, out T view) {
            view = region.Views.OfType<T>().FirstOrDefault();
            return view != null;
        }
    }
}