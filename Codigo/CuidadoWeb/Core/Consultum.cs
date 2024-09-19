using System;
using System.Collections.Generic;

namespace Core;

public partial class Consultum
{
    public int Idconsulta { get; set; }

    public string? Descricao { get; set; }

    public DateTime DataConsulta { get; set; }

    public DateTime? DataRetorno { get; set; }

    public string MedicoResponsavel { get; set; } = null!;

    public bool ExamesSolicitados { get; set; }

    public int IdEspecialidadeMedicina { get; set; }

    public int ResidenteId { get; set; }

    public int FuncionarioId { get; set; }

    public virtual ICollection<Exame> Exames { get; set; } = new List<Exame>();

    public virtual Funcionario Funcionario { get; set; } = null!;

    public virtual Especialidademedicina IdEspecialidadeMedicinaNavigation { get; set; } = null!;

    public virtual Residente Residente { get; set; } = null!;
}
