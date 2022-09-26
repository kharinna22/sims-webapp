using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SimApp.Models
{
    public class SimRequestModel
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Edad { get; set; }
        [Display(Name = "Estado")]
        public bool IsMuerto { get; set; }
        [Display(Name = "Sexo")]
        public bool IsMujer { get; set; }
    }
}
