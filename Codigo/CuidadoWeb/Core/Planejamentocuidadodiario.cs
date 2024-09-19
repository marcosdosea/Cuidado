using System;
using System.Collections.Generic;

namespace Core;

public partial class Planejamentocuidadodiario
{
    public int Id { get; set; }

    public DateTime DiaSemana { get; set; }

    public TimeSpan Hora { get; set; }

    public int IdPlanejamentoCuidado { get; set; }

    public virtual Planejamentocuidado IdPlanejamentoCuidadoNavigation { get; set; } = null!;
}
