using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimApp.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Linq;

namespace SimApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseUrl = "https://localhost:7212/api/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<SimModel> simsList = new List<SimModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Sim");

                
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var sims = JsonConvert.DeserializeObject<SimModel[]>(json);

                    if (sims != null)
                    {
                        simsList = sims.ToList<SimModel>();
                        simsList = simsList.OrderBy(s => s.IsMuerto).ToList();
                    }
                }
            }
            ViewData["SimsList"] = simsList;

            return View(simsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}