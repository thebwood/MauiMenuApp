using CommunityToolkit.Mvvm.Input;
using MauiMenuApp.Domain.Models;

namespace MauiMenuApp.Mobile.ViewModels
{
    public partial class MenuItemControlViewModel : BaseViewModel
    {
        [RelayCommand]
        public async Task NavigateAsync(MenuItemModel menuItem)
        {
            await Shell.Current.GoToAsync($"{nameof(SubMenuPage)}?menuItemId={menuItem.MenuItemId}");
        }
    }
}
