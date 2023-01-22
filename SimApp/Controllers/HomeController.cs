using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimApp.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SimApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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