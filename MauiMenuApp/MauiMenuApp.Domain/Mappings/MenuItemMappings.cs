using MauiMenuApp.Domain.DTOs;
using MauiMenuApp.Domain.Models;

namespace MauiMenuApp.Domain.Mappings
{
    public static class MenuItemMappings
    {
        public static List<MenuItemModel> ToModels(this IEnumerable<MenuItemDto>? dtos)
        {
            return dtos?.Select(dto => dto.ToModel()).ToList() ?? new List<MenuItemModel>();
        }

        public static MenuItemModel ToModel(this MenuItemDto dto)
        {
            return new MenuItemModel
            {
                MenuItemId = dto.MenuItemId,
                ParentMenuItemId = dto.ParentMenuItemId,
                DisplayName = dto.DisplayName,
                Url = dto.Url
            };
        }
        public static SubMenuModel ToModel(this SubMenuDto dto)
        {
            return new SubMenuModel
            {
                ParentMenuItemId = dto.ParentMenuItemId,
                ParentDisplayName = dto.ParentDisplayName,
                MenuItems = dto.MenuItems?.Select(m => m.ToModel()).ToList()
            };
        }   
    }
}
