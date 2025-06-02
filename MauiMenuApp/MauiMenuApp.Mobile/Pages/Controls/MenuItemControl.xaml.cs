using CommunityToolkit.Mvvm.Input;
using MauiMenuApp.Domain.Models;
using System.Net;

namespace MauiMenuApp.Mobile.Pages.Controls;

public partial class MenuItemControl : ContentView
{

    public static readonly BindableProperty MenuItemsProperty =
        BindableProperty.Create(nameof(MenuItems), typeof(List<MenuItemModel>), typeof(MenuItemControl), default(List<MenuItemModel>));

    public List<MenuItemModel> MenuItems
    {
        get => (List<MenuItemModel>)GetValue(MenuItemsProperty);
        set => SetValue(MenuItemsProperty, value);
    }

    public MenuItemControl()
    {
        // Do not set BindingContext here
    }

    [RelayCommand]
    public async Task NavigateAsync(MenuItemModel menuItem)
    {
        await Shell.Current.GoToAsync($"{nameof(SubMenuPage)}?menuItemId={menuItem.MenuItemId}");

    }
}