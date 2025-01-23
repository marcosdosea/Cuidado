using System;
using System.Collections.Generic;

namespace Core;

public partial class TipoCuidado
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public virtual ICollection<PlanejamentoCuidado> PlanejamentoCuidado { get; set; } = new List<PlanejamentoCuidado>();
}
