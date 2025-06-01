namespace MauiMenuApi.Domain.DTOs
{
    public class MenuItemDto
    {
        public int MenuItemId { get; set; }
        public int ParentMenuItemId { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }

    }
}
