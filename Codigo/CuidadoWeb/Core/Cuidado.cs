using System;
using System.Collections.Generic;

namespace Core;

public partial class Cuidado
{
    public int Id { get; set; }

    public DateTime DataExecucao { get; set; }

    public int IdFuncionario { get; set; }

    public int IdPlanejamentoCuidado { get; set; }

    public int IdResidente { get; set; }

    public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;

    public virtual Planejamentocuidado IdPlanejamentoCuidadoNavigation { get; set; } = null!;

    public virtual Residente IdResidenteNavigation { get; set; } = null!;
}
