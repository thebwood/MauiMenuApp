using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiMenuApp.Domain.Models
{
    public class SubMenuModel : INotifyPropertyChanged
    {
        public int ParentMenuItemId { get; set; }
        public string? ParentDisplayName { get; set; }

        private ObservableCollection<MenuItemModel> _menuItems = new();
        public ObservableCollection<MenuItemModel> MenuItems
        {
            get => _menuItems;
            set
            {
                if (_menuItems != value)
                {
                    _menuItems = value;
                    OnPropertyChanged(nameof(MenuItems));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
