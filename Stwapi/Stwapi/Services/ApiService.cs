using Newtonsoft.Json;
using Stwapi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Stwapi.Services
{
    class ApiService : IApiService
    {
        public async Task<Characters> GetCharacter(string character)
        {
            var data = await GetUrl(character);
            return JsonConvert.DeserializeObject<Characters>(data);
        }

        public async Task<Result> GetEpisode(string url)
        {
            var data = await GetUrl(url);
            return JsonConvert.DeserializeObject<Result>(data);
        }

        public async Task<Episodes> GetMovies()
        {
            var data = await GetUrl("https://swapi.dev/api/films/");
                return JsonConvert.DeserializeObject<Episodes>(data);
        }

        private async Task<string> GetUrl(string url)
        {
            HttpClient client = PreparedClient();

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch 
            {
                return "error";
            }
        }
        private HttpClient PreparedClient()
        {
            HttpClientHandler handler = new HttpClientHandler();

            
            handler.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssPolicyError) =>
            {
                return true;
            };


            HttpClient client = new HttpClient(handler);

            return client;
        }

    }
}
