using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalProject.Models;

namespace finalProject.Services.Interfaces
{
    public interface IHttpClient
    {
        Task<IEnumerable<DataModel>> GetAsync();
    }
}
