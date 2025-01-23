using System;
using System.Collections.Generic;

namespace Core;

public partial class Consulta
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public DateTime DataConsulta { get; set; }

    public DateTime? DataRetorno { get; set; }

    public string MedicoResponsavel { get; set; } = null!;

    public bool ExamesSolicitados { get; set; }

    public int IdEspecialidadeMedicina { get; set; }

    public int IdResidente { get; set; }

    public int IdFuncionario { get; set; }

    public virtual ICollection<Exame> Exame { get; set; } = new List<Exame>();

    public virtual EspecialidadeMedicina IdEspecialidadeMedicinaNavigation { get; set; } = null!;

    public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;

    public virtual Residente IdResidenteNavigation { get; set; } = null!;
}
