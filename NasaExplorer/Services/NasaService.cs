using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;

namespace NasaExplorer.Services
{
    public class NasaService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.nasa.gov/";

        public NasaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetApodAsync(string apiKey)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}planetary/apod?api_key={apiKey}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetMarsRoverPhotos(string rover, string earthDate, string apiKey)
        {
            var url = $"{BaseUrl}mars-photos/api/v1/rovers/{rover}/photos?earth_date={earthDate}&api_key={apiKey}";
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAsteroids(string apiKey)
        {
            var url = $"{BaseUrl}neo/rest/v1/feed?api_key={apiKey}";
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetIssLocationAsync()
        {
            var url = "http://api.open-notify.org/iss-now.json";
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
