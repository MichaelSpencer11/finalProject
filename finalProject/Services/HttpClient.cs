using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalProject.Models;
using finalProject.Services.Interfaces;
using System.Net.Http;

namespace finalProject.Services
{
    public class HttpClient : IHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IEnumerable<DataModel> entries { get; set; }

        public async Task<DataModel> GetAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.publicapis.org/");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
