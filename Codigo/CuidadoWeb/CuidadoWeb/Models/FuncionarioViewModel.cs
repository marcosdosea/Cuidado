using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models
{
	public class FuncionarioViewModel
	{
		[Key]
		[Display(Name = "Código")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Nome do funcionário deve ter entre 5 e 50 caracteres")]
		public string Nome { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(11, MinimumLength = 11, ErrorMessage = "O Cpf deve ter 11 caracteres")]
		public string Cpf { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		public DateTime DataNascimento { get; set; }

		[Required(ErrorMessage = "Campo requerido")]
		public DateTime DataAdmissao { get; set; }

		[Required(ErrorMessage = "Campo requerido")]
		public string Cargo { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		public string Status { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		[Display(Name = "Salário")]
		public decimal Salario { get; set; }

		[Required(ErrorMessage = "Campo requerido")]
		[Display(Name = "Número da Casa")]
		public int NumeroCasa { get; set; }

		[Display(Name = "Identificador da Casa")]
		[StringLength(10, MinimumLength = 0, ErrorMessage = "Nome do identificador deve ter no máximo caracteres")]
		public string? IdentificadorCasa { get; set; }

		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Nome da Rua deve ter entre 5 e 50 caracteres")]
		public string Rua { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Nome do Bairro deve ter entre 5 e 50 caracteres")]
		public string Bairro { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(30, MinimumLength = 5, ErrorMessage = "Nome da Cidade deve ter entre 5 e 30 caracteres")]
		public string Cidade { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(2, MinimumLength = 2, ErrorMessage = "Nome do Estado deve ter entre 2 caracteres")]
		public string Estado { get; set; } = null!;

		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter 8 dígitos")]
		public string Cep { get; set; }

		public string? Complemento { get; set; }

		[Display(Name = "Telefone 1")]
		public string? PrimeiroTelefone { get; set; }

		[Display(Name = "Telefone 2")]
		public string? SegundoTelefone { get; set; }

		public int IdOrganizacao { get; set; }
	}
}
