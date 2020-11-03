using Stwapi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Stwapi.ViewModels
{
    class EpisodeViewModel : ViewModelBase
    {
        private Result _episode;
        public Result Episode
        {
            get => _episode;

            set
            {
                if (_episode != value)
                {
                    _episode = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> CharacterURL;


        public ObservableCollection<Characters> _movieCharacters;
        public ObservableCollection<Characters> MovieCharacter
        {
            get => _movieCharacters;

            set
            {
                if (_movieCharacters != value)
                {
                    _movieCharacters = value;
                    OnPropertyChanged();
    }
}
        }

        public EpisodeViewModel()
        {
            _episode = new Result();
            CharacterURL = new ObservableCollection<string>();
            MovieCharacter = new ObservableCollection<Characters>();
            SaveFavoriteCommand = new Command<Characters>((o) => SaveFavorite(o));

        }
        public async Task GetEpisode(string url)
        {
            try 
            {
                CharacterURL.Clear();
            var myEpisode = await apiService.GetEpisode(url);
                Episode = myEpisode;


                foreach(var c in myEpisode.Characters)
                {
                    CharacterURL.Add(c);
                }

                await GetCharacters();
            }
            catch
            {
            }   
        }

        private async Task GetCharacters()
        {
            MovieCharacter.Clear();
            var characterInfo = new Characters();
            foreach (var character in CharacterURL)
            {
                characterInfo = await apiService.GetCharacter(character);
                MovieCharacter.Add(characterInfo);
            }  
        }

        public ICommand SaveFavoriteCommand { get; set;}
        public void SaveFavorite(Characters favoriteCharacter)
        {
             FavoriteList.Add(favoriteCharacter);
            
            OnPropertyChanged();
        }

    }
}
