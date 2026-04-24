using System;
using System.ComponentModel.Composition;
using System.Linq;
using CommonServiceLocator;
using DevExpress.Mvvm;
using Prism.Ioc;
//using Microsoft.Practices.ServiceLocation;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using PrismOnDXDocking.ExampleModule.Views;
using PrismOnDXDocking.Infrastructure;

namespace PrismOnDXDocking.ExampleModule {

    public class ExampleModule : IModule {
        private IMenuService menuService;
        private IRegionManager regionManager;

        public ExampleModule(IMenuService menuService)
        {
            this.menuService = menuService;
        }


        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager = containerProvider.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion(RegionNames.TabRegion, typeof(DefaultView));

            regionManager.AddToRegion(RegionNames.LeftRegion, ServiceLocator.Current.GetInstance<ToolBoxView>());
            regionManager.AddToRegion(RegionNames.RightRegion, ServiceLocator.Current.GetInstance<PropertiesView>());
            regionManager.AddToRegion(RegionNames.MainRegion, ServiceLocator.Current.GetInstance<DocumentView>());

            menuService.Add(new MenuItem() { Command = new DelegateCommand(ShowOutput), Parent = "View", Title = "Output" });
            menuService.Add(new MenuItem() { Command = new DelegateCommand(ShowProperties), Parent = "View", Title = "Properties Window" });
            menuService.Add(new MenuItem() { Command = new DelegateCommand(ShowToolbox), Parent = "View", Title = "Toolbox" });
            menuService.Add(new MenuItem() { Command = new DelegateCommand(AddNewDocument), Parent = "File", Title = "New" });
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        void AddNewDocument() {
            Show<DocumentView>(RegionNames.MainRegion, true);
        }
        bool GetView<T>(IRegion region, out T view) {
            view = region.Views.OfType<T>().FirstOrDefault();
            return view != null;
        }
        //void Initialize() {
        //    Initialize();
        //}
        void Show<T>(string regionName, bool addNew = false) {
            var region = regionManager.Regions[regionName];
            T view;
            if(addNew || !GetView<T>(region, out view)) {
                view = ServiceLocator.Current.GetInstance<T>();
                regionManager.AddToRegion(regionName, view);
            }
            region.Activate(view);
        }
        void ShowOutput() {
            Show<OutputView>(RegionNames.TabRegion);
        }
        void ShowProperties() {
            Show<PropertiesView>(RegionNames.RightRegion);
        }
        void ShowToolbox() {
            Show<ToolBoxView>(RegionNames.LeftRegion);
        }
    }
}