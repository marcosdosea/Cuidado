using System;
using System.Collections.Generic;

namespace Core;

public partial class Exame
{
    public int Id { get; set; }

    public DateTime? DataRealizacao { get; set; }

    public DateTime? DataResultado { get; set; }

    public string? Resultado { get; set; }

    public int IdConsulta { get; set; }

    public int IdTipoExame { get; set; }

    public virtual Consultum IdConsultaNavigation { get; set; } = null!;

    public virtual Tipoexame IdTipoExameNavigation { get; set; } = null!;
}
