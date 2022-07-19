using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using finalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace finalProject.Services.Interfaces
{
    public interface IHttpClient
    {
        Task<Entries> GetAsync();
    }
}
