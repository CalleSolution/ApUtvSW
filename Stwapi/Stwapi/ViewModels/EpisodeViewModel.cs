using Stwapi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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

        public EpisodeViewModel()
        {
            _episode = new Result();
        }
        public async Task GetEpisode(string url)
        {
            try 
            { 
            var myEpisode = await apiService.GetEpisode(url);
                _episode = myEpisode;
            }
            catch
            {

            }
            
        }
    }
}
