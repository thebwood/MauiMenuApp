using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMenuApp.Domain.Common;
using MauiMenuApp.Domain.Models;
using MauiMenuApp.Mobile.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MauiMenuApp.Mobile.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly IMenuItemClient _menuItemClient;
        public ObservableCollection<MenuItemModel> MainMenuItems { get; set; } = new();
        public MainPageViewModel(IMenuItemClient menuItemClient)
        {
            _menuItemClient = menuItemClient;
        }

        public async Task LoadMainMenuItemsAsync()
        {
            Result<List<MenuItemModel>>? result = await _menuItemClient.GetMainMenuItems();

            if (result.Success && result.Value != null)
            {
                MainMenuItems.Clear();
                foreach (var item in result.Value)
                {
                    MainMenuItems.Add(item);
                }
            }
            else
            {
                // Handle errors, e.g., show a message to the user
                // You can also log the errors or take other actions as needed
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Error: {error.Message}");
                }
            }
        }

        [RelayCommand]
        public async Task NavigateAsync(MenuItemModel menuItem)
        {
            if (menuItem == null || menuItem.MenuItemId <= 0)
            {
                await ShowErrorMessage("Invalid menu item selected.");
                return;
            }
            // Navigate to the SubMenuPage with the selected menu item ID
            await Shell.Current.GoToAsync($"SubMenuPage?menuItemId={menuItem.MenuItemId}");
        }
    }
}
