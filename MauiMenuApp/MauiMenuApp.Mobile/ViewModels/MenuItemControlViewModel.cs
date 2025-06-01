using MauiMenuApp.Domain.Models;
using System.Collections.ObjectModel;

namespace MauiMenuApp.Mobile.ViewModels
{
    public class MenuItemControlViewModel
    {
        public ObservableCollection<MenuItemModel> MenuItems { get; set; } = new ObservableCollection<MenuItemModel>();
    }
}
