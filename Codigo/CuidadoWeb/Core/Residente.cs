using System;
using System.Collections.Generic;

namespace Core;

public partial class Residente
{
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

    public virtual ICollection<AtividadeExterna> AtividadeExterna { get; set; } = new List<AtividadeExterna>();

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual ICollection<Cuidado> Cuidado { get; set; } = new List<Cuidado>();

    public virtual ICollection<FonteRenda> FonteRendaNavigation { get; set; } = new List<FonteRenda>();

    public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;

    public virtual Organizacao IdOrganizacaoNavigation { get; set; } = null!;

    public virtual ICollection<PlanoAssistencia> PlanoAssistencia { get; set; } = new List<PlanoAssistencia>();

    public virtual ICollection<PlanoSaude> PlanoSaude { get; set; } = new List<PlanoSaude>();

    public virtual ICollection<Responsavel> Responsavel { get; set; } = new List<Responsavel>();

    public virtual ICollection<TipoExame> TipoExame { get; set; } = new List<TipoExame>();

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
