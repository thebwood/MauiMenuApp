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
		set
		{
            LoadData(value);
		}
	}

	private async void LoadData(int menuItemId)
	{
		if (_viewModel != null)
		{
			await _viewModel.LoadDataAsync(menuItemId);
		}
    }
}