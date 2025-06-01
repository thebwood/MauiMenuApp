using MauiMenuApi.BusinessLayer.Services.Interfaces;
using MauiMenuApi.DataAccessLayer.Repositories.Interfaces;
using MauiMenuApi.Domain.Common;
using MauiMenuApi.Domain.DTOs;
using MauiMenuApi.Domain.Models;
using System.Net;
using MauiMenuApi.BusinessLayer.Mappings;

namespace MauiMenuApi.BusinessLayer.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }
        public async Task<Result<MainMenuDto>> GetMainMenu()
        {
            Result<MainMenuDto> result = new();
            List<MenuItemModel>? menuItemModels = await _menuItemRepository.GetMainMenu();

            if (menuItemModels == null || !menuItemModels.Any())
            {
                result.Errors.Add(new Error("NotFound", "No main menu items found."));
                result.StatusCode = HttpStatusCode.NotFound;
                return result; 
            }

            // Use the ToDto extension method for mapping
            var menuItemDtos = menuItemModels.Select(m => m.ToDto() as MenuItemDto).ToList();

            result.Value = new MainMenuDto
            {
                MenuItems = menuItemDtos
            };
            return result;
        }

        public async Task<Result<SubMenuDto>> GetSubMenusByParentId(int parentId)
        {
            Result<SubMenuDto> result = new();

            var menuItemModel = await _menuItemRepository.GetMenuItemById(parentId); // Ensure the parent exists
            if(menuItemModel == null || menuItemModel.MenuItemId == 0)
            {
                result.Errors.Add(new Error("NotFound", "Parent menu item not found."));
                result.StatusCode = HttpStatusCode.NotFound;
                return result;
            }

            List<MenuItemModel>? menuItemModels = await _menuItemRepository.GetSubMenusByParentId(parentId);
            if (menuItemModels == null || !menuItemModels.Any())
            {
                result.Errors.Add(new Error("NotFound", "No sub menu items found for the specified parent ID."));
                result.StatusCode = HttpStatusCode.NotFound;
                return result; 
            }
            // Use the ToDto extension method for mapping
            List<MenuItemDto>? menuItemDtos = menuItemModels.Select(m => m.ToDto() as MenuItemDto).ToList();
            result.Value = new SubMenuDto
            {
                ParentMenuItemId = menuItemModel.MenuItemId,
                ParentDisplayName = menuItemModel.DisplayName,
                MenuItems = menuItemDtos
            };
            return result;
        }
    }
}
