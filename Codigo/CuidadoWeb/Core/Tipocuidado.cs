using System;
using System.Collections.Generic;

namespace Core;

public partial class Tipocuidado
{
    public int Id { get; set; }

    public string NomeCuidado { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public virtual ICollection<Planejamentocuidado> Planejamentocuidados { get; set; } = new List<Planejamentocuidado>();
}
