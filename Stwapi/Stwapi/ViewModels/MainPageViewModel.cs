using Stwapi.Models;
using Stwapi.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Stwapi.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        ObservableCollection<Result> _movies;

        public ObservableCollection<Result> Movies
        {
            get => _movies;

            set
            {
                if (_movies != value)
                {
                    _movies = value;
                    OnPropertyChanged();
                }
            }
        }

        public INavigation Navigation { get; set; }
        public MainPageViewModel(INavigation navigation)
        {
            _movies = new ObservableCollection<Result>();
            Navigation = navigation;
            EpisodeCommand = new Command(async (o) => await GotoEpisodePage(o.ToString()));
            FavoriteCommand = new Command(async () => await GotoFavoritePage());
        }

        public async Task GetMovies()
        {
            try
            {
                _movies.Clear();
                var myMovies = await apiService.GetMovies();

                foreach (var movie in myMovies.Results)
                {
                    _movies.Add(movie);
                }
            }
            catch
            {

            }
        }

        public ICommand EpisodeCommand { get; set; }

        public async Task GotoEpisodePage(string url)
        {
            await Navigation.PushAsync(new EpisodeViewPage(url));
        }

        public ICommand FavoriteCommand { get; set; }

        public async Task GotoFavoritePage()
        {
            await Navigation.PushAsync(new FavoritePage());
        }
    }
}
