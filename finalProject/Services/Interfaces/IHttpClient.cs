using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using finalProject.Models;

namespace finalProject.Services.Interfaces
{
    public interface IHttpClient
    {
        Task<String> GetAsync();
    }
}
