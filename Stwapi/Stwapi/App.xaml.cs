using Stwapi.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stwapi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IApiService, ApiService>();
            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
