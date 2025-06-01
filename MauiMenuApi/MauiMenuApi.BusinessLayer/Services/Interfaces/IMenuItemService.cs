using MauiMenuApi.Domain.Common;
using MauiMenuApi.Domain.DTOs;

namespace MauiMenuApi.BusinessLayer.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<Result<MainMenuDto>> GetMainMenu();
        Task<Result<SubMenuDto>> GetSubMenusByParentId(int parentId);
    }
}
