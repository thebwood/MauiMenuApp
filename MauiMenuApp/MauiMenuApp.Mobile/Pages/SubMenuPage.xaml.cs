using MauiMenuApp.Mobile.ViewModels;

namespace MauiMenuApp.Mobile.Pages;

public partial class SubMenuPage : ContentPage
{
	private SubMenuPageViewModel _viewModel;


	public SubMenuPage(SubMenuPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
    }

	public int MenuItemId
	{
		get => _menuItemId;
        set
		{
			_menuItemId = value;
            LoadData(value);
		}
	}
	private int _menuItemId;
	private async void LoadData(int menuItemId)
	{
        _menuItemId = menuItemId;
        if (_viewModel != null)
		{
			await _viewModel.LoadDataAsync(menuItemId);
		}
    }
}