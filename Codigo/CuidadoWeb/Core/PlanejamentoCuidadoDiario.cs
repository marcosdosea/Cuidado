using System;
using System.Collections.Generic;

namespace Core;

public partial class PlanejamentoCuidadoDiario
{
    public int Id { get; set; }

    public DateOnly DiaSemana { get; set; }

    public TimeOnly Hora { get; set; }

    public int IdPlanejamentoCuidado { get; set; }

    public virtual PlanejamentoCuidado IdPlanejamentoCuidadoNavigation { get; set; } = null!;
}
