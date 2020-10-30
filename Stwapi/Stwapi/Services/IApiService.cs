using Stwapi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Stwapi.Services
{
    public interface IApiService
    {
        Task <Episodes> GetMovies();

        Task <Result> GetEpisode(string url);
    }
}
