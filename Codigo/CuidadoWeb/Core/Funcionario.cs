using System;
using System.Collections.Generic;

namespace Core;

public partial class Funcionario
{
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

    public virtual ICollection<Aquisicao> Aquisicao { get; set; } = new List<Aquisicao>();

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual ICollection<Cuidado> Cuidado { get; set; } = new List<Cuidado>();

    public virtual Organizacao IdOrganizacaoNavigation { get; set; } = null!;

    public virtual ICollection<Residente> Residente { get; set; } = new List<Residente>();
}
