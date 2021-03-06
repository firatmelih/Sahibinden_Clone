using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Car.Models;
using Microsoft.Extensions.Localization;

namespace Car.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> sharedResource;
      

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<SharedResource> _sharedResource)
        {
            _logger = logger;
            sharedResource = _sharedResource;
        }

        
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
