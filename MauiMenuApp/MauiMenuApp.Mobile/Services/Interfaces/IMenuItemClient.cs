using MauiMenuApp.Domain.Common;
using MauiMenuApp.Domain.Models;

namespace MauiMenuApp.Mobile.Services.Interfaces
{
    public interface IMenuItemClient
    {
        Task<Result<List<MenuItemModel>>> GetMainMenuItems();
        Task<Result<SubMenuModel>> GetSubMenuItems();
    }
}
