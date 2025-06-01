using MauiMenuApp.Domain.Models;
using MauiMenuApp.Mobile.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MauiMenuApp.Mobile.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IMenuItemClient _menuItemClient;
        public ObservableCollection<MenuItemModel> MainMenuItems { get; set; } = new ObservableCollection<MenuItemModel>();

        public MainPageViewModel(IMenuItemClient menuItemClient)
        {
            _menuItemClient = menuItemClient;
        }

        public async Task LoadMainMenuItemsAsync()
        {
            var mainMenu = await _menuItemClient.GetMainMenuAsync();
            if (mainMenu?.MenuItems != null)
            {
                MainMenuItems.Clear();
                foreach (var item in mainMenu.MenuItems)
                {
                    MainMenuItems.Add(item);
                }
            }
        }
}
