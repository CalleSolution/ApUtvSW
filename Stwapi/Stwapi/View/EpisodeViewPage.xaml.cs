using Stwapi.Models;
using Stwapi.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stwapi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EpisodeViewPage : ContentPage
    {
        private readonly EpisodeViewModel viewmodel;

        private string _url;
        public EpisodeViewPage(string url)
        {
            InitializeComponent();
            _url = url;
            BindingContext = viewmodel = new EpisodeViewModel();
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewmodel.GetEpisode(_url);
              
        }
    }
}