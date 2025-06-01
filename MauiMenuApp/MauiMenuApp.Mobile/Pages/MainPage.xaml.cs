using MauiMenuApp.Mobile.Models;
using MauiMenuApp.Mobile.PageModels;

namespace MauiMenuApp.Mobile.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}