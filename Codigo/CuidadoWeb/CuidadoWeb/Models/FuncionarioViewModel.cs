using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models;

public class FuncionarioViewModel
{
    [Key]
    [DisplayName("Código")]
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public DateOnly DataAdmissao { get; set; }

    public string Cargo { get; set; } = null!;

    /// <summary>
    /// A -&gt; Ativo
    /// I -&gt; Inativo
    /// </summary>
    public string Status { get; set; } = null!;

    public decimal Salario { get; set; }

    public int NumeroCasa { get; set; }

    public string? IdentificadorCasa { get; set; }

    public string Rua { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int Cep { get; set; }

    public string? Complemento { get; set; }

    public string? PrimeiroTelefone { get; set; }

    public string? SegundoTelefone { get; set; }

    public int IdOrganizacao { get; set; }
}

