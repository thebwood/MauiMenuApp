using MauiMenuApp.Domain.Models;
using MauiMenuApp.Mobile.ViewModels;
using System.Collections.ObjectModel;

namespace MauiMenuApp.Mobile.Pages.Controls;

public partial class MenuItemControl
{
    private MenuItemControlViewModel _viewModel;
    public MenuItemControl(MenuItemControlViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
    }
}