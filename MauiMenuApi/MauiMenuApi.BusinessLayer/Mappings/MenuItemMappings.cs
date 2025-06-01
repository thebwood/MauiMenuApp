using MauiMenuApi.Domain.DTOs;
using MauiMenuApi.Domain.Models;

namespace MauiMenuApi.BusinessLayer.Mappings
{
    public static class MenuItemMappings
    {

        public static MenuItemDto ToDto(this MenuItemModel model)
        {
            if (model == null) return null!;
            return new MenuItemDto
            {
                MenuItemId = model.MenuItemId,
                ParentMenuItemId = model.ParentMenuItemId,
                DisplayName = model.DisplayName,
                Url = model.Url
            };
        }
    }
}