using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models
{
    public class VisitaViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Data de visita")]
        public string? Data { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Horário da visita")]
        public string? Horário { get; set; }

        public int IdVisitante { get; set; }
    }
}