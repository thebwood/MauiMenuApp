using MauiMenuApp.Mobile.ViewModels;

namespace MauiMenuApp.Mobile.Pages
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;


        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
        }
    }
}