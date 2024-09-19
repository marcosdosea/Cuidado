using System;
using System.Collections.Generic;

namespace Core;

public partial class Especialidademedicina
{
    public int IdespecialidadeMedicina { get; set; }

    public string NomeEspecialidade { get; set; } = null!;

    public virtual ICollection<Consultum> Consulta { get; set; } = new List<Consultum>();
}
