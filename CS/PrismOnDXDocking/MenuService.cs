using Microsoft.VisualBasic;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using DevExpress.Xpf.Bars;

namespace PrismOnDXDocking.Infrastructure {
    [Export(typeof(IMenuService))]
    public class MenuService : IMenuService {
        private readonly BarManager manager;
        private readonly Bar bar;
        [ImportingConstructor]
        public MenuService(Shell shell) {
            manager = shell.BarManager;
            bar = shell.MainMenu;
        }
        public void Add(MenuItem item) {
            BarSubItem parent = GetParent(item.Parent);
            BarButtonItem button = new BarButtonItem { Content = item.Title, Command = item.Command, Name = "bbi" + Regex.Replace(item.Title, "[^a-zA-Z0-9]", "") };
            manager.Items.Add(button);
            parent.ItemLinks.Add(new BarButtonItemLink { BarItemName = button.Name });
        }

        void IMenuService.Add(MenuItem item) {
            Add(item);
        }

        BarSubItem GetParent(string parentName) {
            foreach(BarItem item in manager.Items) {
                BarSubItem button = item as BarSubItem;
                if(button != null && button.Content.ToString() == parentName)
                    return button;
            }
            BarSubItem newParent = new BarSubItem { Content = parentName, Name = "bsi" + Regex.Replace(parentName, "[^a-zA-Z0-9]", "") };
            manager.Items.Add(newParent);
            bar.ItemLinks.Add(new BarSubItemLink { BarItemName = newParent.Name });
            return newParent;
        }
    }
}