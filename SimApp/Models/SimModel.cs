using System.ComponentModel.DataAnnotations;

namespace SimApp.Models
{
    public class SimModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Edad { get; set; }
        [Display(Name="Estado")]
        public bool IsMuerto { get; set; }
        [Display(Name ="Sexo")]
        public bool IsMujer { get; set; }
    }
}
