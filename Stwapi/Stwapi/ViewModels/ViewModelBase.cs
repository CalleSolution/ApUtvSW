using Stwapi.Models;
using Stwapi.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Stwapi.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Characters> FavoriteList = new ObservableCollection<Characters>();

        public IApiService apiService;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModelBase()
        {
            apiService = DependencyService.Get<IApiService>(); 
        }
    }
}
