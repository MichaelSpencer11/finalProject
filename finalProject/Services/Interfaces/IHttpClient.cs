using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalProject.Models;

namespace finalProject.Services.Interfaces
{
    interface IHttpClient
    {
        Task<DataModel> GetAsync();
    }
}
