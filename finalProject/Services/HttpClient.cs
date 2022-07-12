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
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        public DataModel Entries { get; set; }

        public async Task<String> GetAsync()
        {
            
                // Call asynchronous network methods in a try/catch block to handle exceptions.
                try
                {
                    string responseBody = await client.GetStringAsync("https://api.publicapis.org/entries");

                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
        }
    }
}
