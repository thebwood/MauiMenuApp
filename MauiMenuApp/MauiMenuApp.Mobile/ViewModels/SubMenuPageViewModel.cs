using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMenuApp.Domain.Models;
using MauiMenuApp.Mobile.Services.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace MauiMenuApp.Mobile.ViewModels
{
    public partial class SubMenuPageViewModel : BaseViewModel
    {
        private readonly IMenuItemClient _menuItemClient;
        [ObservableProperty]
        private SubMenuModel subMenuItems = new SubMenuModel();
        public SubMenuPageViewModel(IMenuItemClient menuItemClient)
        {
            _menuItemClient = menuItemClient;
        }
        public async Task LoadDataAsync(int menuItemId)
        {
            if (menuItemId <= 0)
            {
                throw new ArgumentException("Invalid menu item ID.", nameof(menuItemId));
            }
            var result = await _menuItemClient.GetSubMenuItems(menuItemId);
            if (result.Success && result.Value != null)
            {
                SubMenuItems = result.Value;
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
