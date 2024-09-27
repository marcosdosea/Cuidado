using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuidadoWeb.Models
{
    public class CuidadoViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Data de Execução")]
        public DateTime DataExecucao { get; set; }

        [ForeignKey("Funcionario")]
        [Display(Name = "Código do Funcionário")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdFuncionario { get; set; }

        [ForeignKey("Planejamentocuidado")]
        [Display(Name = "Código do Planejamento do Cuidado")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdPlanejamentoCuidado { get; set; }

        [ForeignKey("Residente")]
        [Display(Name = "Código do Residente")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdResidente { get; set; }
    }
}
