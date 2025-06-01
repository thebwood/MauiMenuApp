using MauiMenuApi.BusinessLayer.Services.Interfaces;
using MauiMenuApi.Domain.Common;
using MauiMenuApi.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MauiMenuApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<ActionResult<Result<MainMenuDto>>> GetMainMenu()
        {
            var result =  await _menuItemService.GetMainMenu();
            if (!result.Success)
            {
                // Example: return 404 if not found, or 400 for validation errors, etc.
                return StatusCode((int)result.StatusCode, result);
            }
            return Ok(result);

        }

        [HttpGet]
        [Route("submenus/{parentId}")]
        public async Task<ActionResult<Result<SubMenuDto>>> GetSubMenusByParentId(int parentId)
        {
            var result = await _menuItemService.GetSubMenusByParentId(parentId);
            if (!result.Success)
            {
                // Example: return 404 if not found, or 400 for validation errors, etc.
                return StatusCode((int)result.StatusCode, result);
            }
            return Ok(result);
        }
    }
}
