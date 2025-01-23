using System;
using System.Collections.Generic;

namespace Core;

public partial class TipoExame
{
    public int Id { get; set; }

    public string NomeExame { get; set; } = null!;

    public string Preparacao { get; set; } = null!;

    public string? Descricao { get; set; }

    public int IdResidente { get; set; }

    public virtual ICollection<Exame> Exame { get; set; } = new List<Exame>();

    public virtual Residente IdResidenteNavigation { get; set; } = null!;
}
