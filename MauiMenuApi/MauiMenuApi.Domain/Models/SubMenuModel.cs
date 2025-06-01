namespace MauiMenuApi.Domain.Models
{
    public class SubMenuModel
    {
        public List<MenuItemModel>? MenuItems { get; set; }
        public SubMenuModel()
        {
            MenuItems = new List<MenuItemModel>();
        }
        public SubMenuModel(List<MenuItemModel> menuItems)
        {
            MenuItems = menuItems ?? new List<MenuItemModel>();
        }
    }
}
