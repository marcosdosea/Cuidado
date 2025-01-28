using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models;

public class ResidenteViewModel
{
    [Key]
    [DisplayName("Código")]
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string NomeMae { get; set; } = null!;

    public string NomePai { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public string EstadoCivil { get; set; } = null!;

    public string CidadeNatal { get; set; } = null!;

    public string EstadoNatal { get; set; } = null!;

    public string GrauEscolaridade { get; set; } = null!;

    public int QuantidadeFilhos { get; set; }

    public sbyte GrauDepedencia { get; set; }

    public sbyte Interditado { get; set; }

    public string FonteRenda { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public string CertidaoNascimento { get; set; } = null!;

    public string NumeroSus { get; set; } = null!;

    public string NumeroNis { get; set; } = null!;

    public int IdOrganizacao { get; set; }

    public int IdFuncionario { get; set; }
}

