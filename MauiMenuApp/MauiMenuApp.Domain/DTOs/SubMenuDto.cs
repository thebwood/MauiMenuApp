namespace MauiMenuApp.Domain.DTOs
{
    public class SubMenuDto
    {
        public int ParentMenuItemId { get; set; }
        public string? ParentDisplayName { get; set; }
        public List<MenuItemDto>? MenuItems { get; set; }
    }
}
