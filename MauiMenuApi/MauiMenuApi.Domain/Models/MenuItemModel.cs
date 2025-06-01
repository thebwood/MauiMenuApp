namespace MauiMenuApi.Domain.Models
{
    public class MenuItemModel
    {
        public int MenuItemId { get; set; }
        public int ParentMenuItemId { get; set; }
        public string? DisplayName { get; set; }
        public string? Url { get; set; }
    }
}
