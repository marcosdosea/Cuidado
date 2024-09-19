using System;
using System.Collections.Generic;

namespace Core;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public DateTime DataAdmissao { get; set; }

    public string Cargo { get; set; } = null!;

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

    public virtual ICollection<Aquisicao> Aquisicaos { get; set; } = new List<Aquisicao>();

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual ICollection<Cuidado> Cuidados { get; set; } = new List<Cuidado>();

    public virtual Organizacao IdOrganizacaoNavigation { get; set; } = null!;

    public virtual ICollection<Residente> Residentes { get; set; } = new List<Residente>();
}
