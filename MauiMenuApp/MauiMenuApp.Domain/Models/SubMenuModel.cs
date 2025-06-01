namespace MauiMenuApp.Domain.Models
{
    public class SubMenuModel
    {
        public int ParentMenuItemId { get; set; }
        public string? ParentDisplayName { get; set; }

        public List<MenuItemModel>? MenuItems { get; set; }
    }
}
