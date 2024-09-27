using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models
{
    public class VisitaViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome do Visitante deve ter entre 5 e 50 caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O Cpf deve ter 11 caracteres")]
        public string Cpf { get; set; } = null!;


        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Telefone 1")]
        public string? PrimeiroTelefone { get; set; }

        [Display(Name = "Telefone 2")]
        public string? SegundoTelefone { get; set; }
    }
}
