using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Newtonsoft.Json;
using SimApp.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SimApp.Controllers
{
    public class SimsController : Controller
    {
        string baseUrl = "https://localhost:7212/api/";

        List<string> edades = new List<string>
        {
            "Infante",
            "Niñez",
            "Adolescente",
            "Joven",
            "Adulto",
            "Anciano"
        };

        public async Task<IActionResult> Index()
        {
            List<SimModel> simsList = new List<SimModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Sims");


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
            
            return View(simsList);
        }

        public IActionResult Create()
        {
            SimRequestModel newSim = new SimRequestModel();
            // Valores predeterminados (bias propio)
            newSim.IsMujer = true;
            newSim.Edad = "Joven";
            newSim.IsMuerto = false;
            ViewData["edades"] = edades;
            return View(newSim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Apellido,Edad,IsMuerto,IsMujer")] SimRequestModel newSim)
        {
            
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var createSim = new StringContent(JsonConvert.SerializeObject(newSim), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("Sims",createSim);

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    else
                        return NotFound();
                }
            }

            return View(newSim);
        }

        // GET: Sim/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Sims/"+id);
                

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var foundedSim = JsonConvert.DeserializeObject<SimModel>(json);
                    ViewData["edades"] = edades;
                    return View(foundedSim);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Edad,IsMuerto,IsMujer")] SimModel sim)
        {
            if (id != sim.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                SimRequestModel request = new SimRequestModel
                {
                    Nombre = sim.Nombre,
                    Apellido = sim.Apellido,
                    Edad = sim.Edad,
                    IsMuerto = sim.IsMuerto,
                    IsMujer = sim.IsMujer
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var updateSim = new StringContent(JsonConvert.SerializeObject(request),Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync("Sims/"+id, updateSim);

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    else
                        return NotFound();   
                }
            }

            return View(sim);
        }

    }
}
