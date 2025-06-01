using MauiMenuApp.Domain.Models;
using MauiMenuApp.Mobile.ViewModels;
using System.Collections.ObjectModel;

namespace MauiMenuApp.Mobile.Pages.Controls;

public partial class MenuItemControl
{
	private MenuItemControlViewModel ViewModel;

    public MenuItemControl(MenuItemControlViewModel _viewModel)
	{
		InitializeComponent();
		ViewModel = _viewModel;
		BindingContext = ViewModel;
    }
}