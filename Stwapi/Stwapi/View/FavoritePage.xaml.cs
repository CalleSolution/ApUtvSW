using Stwapi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stwapi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {

        private readonly FavoritesViewModel viewmodel;
        public FavoritePage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new FavoritesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.GetFavorites();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var o = (Button)sender;
            o.IsVisible = false;
            DisplayAlert("Remove Favorite" ,"Successfully Removed", "OK");
            
        }
    }


}