using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalProject.Models;
using finalProject.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;


namespace finalProject.Services
{
    public class HttpClient : IHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IEnumerable<DataModel> Entries { get; set; }

        public async Task<IEnumerable<DataModel>> GetAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.publicapis.org/");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if(httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                Entries = await JsonSerializer.DeserializeAsync<IEnumerable<DataModel>>(contentStream);
                return Entries;
            }

            //If you reach this, it didn't work
            return null;
            
        }
    }
}
