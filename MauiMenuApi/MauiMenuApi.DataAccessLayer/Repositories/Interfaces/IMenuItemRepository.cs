using MauiMenuApi.Domain.Models;

namespace MauiMenuApi.DataAccessLayer.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItemModel>> GetMainMenu();
        Task<MenuItemModel> GetMenuItemById(int menuItemId);
        Task<List<MenuItemModel>> GetSubMenusByParentId(int parentId);

    }
}
