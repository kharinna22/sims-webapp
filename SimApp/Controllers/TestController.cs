using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimApp.Models;
using System.Text.Encodings.Web;

namespace SimApp.Controllers
{
    public class TestController : Controller
    {
        List<Edad> edades = new List<Edad>
        {
            new Edad { value = "Infante", text = "Infante" },
            new Edad { value = "Niñez", text = "Niñez" },
            new Edad { value = "Adolescente", text = "Adolescente" },
            new Edad { value = "Joven", text = "Joven" },
            new Edad { value = "Adulto", text = "Adulto" },
            new Edad { value = "Anciano", text = "Anciano" },
        };

        public IActionResult Index()
        {
            List<SimModel> sim = new List<SimModel>
            {
                new SimModel
                {
                    Id = 1,
                    Nombre = "Andrea",
                    Apellido = "Wilson",
                    Edad = "Joven",
                    IsMuerto = false,
                    IsMujer = true
                },
                new SimModel
                {
                    Id = 2,
                    Nombre = "Ibai",
                    Apellido = "Wilson",
                    Edad = "Joven",
                    IsMuerto = false,
                    IsMujer = false
                }
            };
            ViewData["edades"] = edades;    
            return View(sim);
        }

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
    }

    public class Edad
    {
        public string? value { get; set; }
        public string? text { get; set; }
    }
}
