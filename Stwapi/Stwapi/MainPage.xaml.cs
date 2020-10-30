using Stwapi.View;
using Stwapi.ViewModels;
using System;
using Xamarin.Forms;

namespace Stwapi
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel mainview;
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainview = new MainPageViewModel(Navigation);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await mainview.GetMovies();
        }
    }
}
