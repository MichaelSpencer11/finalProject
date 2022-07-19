using finalProject.Models;
using finalProject.Services;
using finalProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace finalProject.Controllers
{   
    [ApiController]
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClient _service;

        public HomeController(ILogger<HomeController> logger, IHttpClient service)
        {
            _logger = logger;
            _service = service;

        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("getdata")]
        public async Task<IActionResult> GetData()
        {
            
            var data = await _service.GetAsync();
            //string jsonString = JsonSerializer.Serialize(data);

            return Ok(data);
        }
    }
}
