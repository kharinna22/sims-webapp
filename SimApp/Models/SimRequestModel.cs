using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SimApp.Models
{
    public class SimRequestModel
    {
        [Required(ErrorMessage = "*Nombre es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "*Apellido es requerido")]
        public string? Apellido { get; set; }
        public string? Edad { get; set; }
        [Display(Name = "Estado")]
        public bool IsMuerto { get; set; }
        [Display(Name = "Sexo")]
        public bool IsMujer { get; set; }
    }
}
