using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuidadoWeb.Models
{
	public class ProdutoViewModel
	{
		[Key]
		[Display(Name = "Código")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Nome do produto deve ter entre 5 e 45 caracteres")]
		public string Nome { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		[Display(Name = "Classificação")]
		[StringLength(30, MinimumLength = 1, ErrorMessage = "Classificação do produto deve ter entre 1 e 30 caracteres")]
		public string Classificacao { get; set; } = null!;

		[ForeignKey("Organizacao")]
		[Display(Name = "Código Organização")]
		public int IdOrganizacao { get; set; }
	}
}
