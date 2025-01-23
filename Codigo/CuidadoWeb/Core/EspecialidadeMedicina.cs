using System;
using System.Collections.Generic;

namespace Core;

public partial class EspecialidadeMedicina
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}
