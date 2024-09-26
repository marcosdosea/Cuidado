using System;
using System.Collections.Generic;

namespace Core;

public partial class Residente
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string NomeMae { get; set; } = null!;

    public string NomePai { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public string EstadoCivil { get; set; } = null!;

    public string CidadeNatal { get; set; } = null!;

    public string EstadoNatal { get; set; } = null!;

    public string GrauEscolaridade { get; set; } = null!;

    public int QuantidadeFilhos { get; set; }

    public string GrauDepedencia { get; set; } = null!;

    public string Interditado { get; set; } = null!;

    public string FonteRenda { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public string CertidaoNascimento { get; set; } = null!;

    public string NumeroSus { get; set; } = null!;

    public string NumeroNis { get; set; } = null!;

    public int IdOrganizacao { get; set; }

    public int IdFuncionario { get; set; }

    public virtual ICollection<Atividadeexterna> Atividadeexternas { get; set; } = new List<Atividadeexterna>();

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();

    public virtual ICollection<Cuidado> Cuidados { get; set; } = new List<Cuidado>();

    public virtual ICollection<Fonterendum> Fonterenda { get; set; } = new List<Fonterendum>();

    public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;

    public virtual Organizacao IdOrganizacaoNavigation { get; set; } = null!;

    public virtual ICollection<Planoassistencium> Planoassistencia { get; set; } = new List<Planoassistencium>();

    public virtual ICollection<Planosaude> Planosaudes { get; set; } = new List<Planosaude>();

    public virtual ICollection<Responsavel> Responsavels { get; set; } = new List<Responsavel>();

    public virtual ICollection<Tipoexame> Tipoexames { get; set; } = new List<Tipoexame>();

    public virtual ICollection<Visitum> Visita { get; set; } = new List<Visitum>();
}
