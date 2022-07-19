using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalProject.Models;
using finalProject.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace finalProject.Services
{
    public class HttpClient : IHttpClient
    {
        //private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClient(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

        public async Task<Stream> GetAsync()
        {
            Entries entries = new Entries();
            var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.publicapis.org/entries");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Entries>(httpResponseMessage.Content.ReadAsStreamAsync().Result);
                
                
            }

            return null;
        }
    }
}
