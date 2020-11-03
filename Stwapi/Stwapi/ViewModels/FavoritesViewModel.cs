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
    class FavoritesViewModel : ViewModelBase
    {
        private ObservableCollection<Characters> _favorites;
        public ObservableCollection<Characters> Favorites
        {
            get => _favorites;

            set
            {
                if (_favorites != value)
                {
                    _favorites = value;
                    OnPropertyChanged();
                }
            }
        }
        public FavoritesViewModel()
        {
            Favorites = new ObservableCollection<Characters>();
            RemoveFavoritesCommand = new Command<Characters>((o) => RemoveFavorite(o));
        }

        public void GetFavorites()
        {
            try
            {
                Favorites.Clear();

            foreach(var f in FavoriteList)
                {
                    Favorites.Add(f);
                }
            }
            catch { }
            OnPropertyChanged();
        }

        public ICommand RemoveFavoritesCommand { get; set; }
        public void RemoveFavorite(Characters character)
        {
            
            try {
                    var characterinlist = FavoriteList.FirstOrDefault(f => f.Name == character.Name);
                   
                if (characterinlist != null) 
                    { 
                        FavoriteList.Remove(characterinlist);
                        Favorites.Remove(characterinlist);
                    }
                }
            catch { }
            
        }
    }
}
