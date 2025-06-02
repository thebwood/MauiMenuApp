using MauiMenuApp.Domain.Models;
using MauiMenuApp.Mobile.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MauiMenuApp.Mobile.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly IMenuItemClient _menuItemClient;
        private ObservableCollection<MenuItemModel> _mainMenuItems = new();
        public ObservableCollection<MenuItemModel> MainMenuItems
        {
            get => _mainMenuItems;
            set
            {
                if (_mainMenuItems != value)
                {
                    _mainMenuItems = value;
                    OnPropertyChanged(nameof(MainMenuItems));
                }
            }
        }

        public MainPageViewModel(IMenuItemClient menuItemClient)
        {
            _menuItemClient = menuItemClient;
        }

        public async Task LoadMainMenuItemsAsync()
        {
            var result = await _menuItemClient.GetMainMenuItems();

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
                    Console.WriteLine($"Error: {error.Name}");
                }
            }
        }
    }
}
