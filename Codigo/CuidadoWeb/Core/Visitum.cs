using System;
using System.Collections.Generic;

namespace Core;

public partial class Visitum
{
    public int Id { get; set; }

    public DateTime DataVisita { get; set; }

    public TimeSpan HorarioVisita { get; set; }

    public int IdResidente { get; set; }

    public int IdVisitante { get; set; }

    public virtual Residente IdResidenteNavigation { get; set; } = null!;

    public virtual Visitante IdVisitanteNavigation { get; set; } = null!;
}
