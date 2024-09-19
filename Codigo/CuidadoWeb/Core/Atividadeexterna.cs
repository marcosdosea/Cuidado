using System;
using System.Collections.Generic;

namespace Core;

public partial class Atividadeexterna
{
    public int Id { get; set; }

    public DateTime DataRealizacao { get; set; }

    public TimeSpan HorarioRealizacao { get; set; }

    public DateTime DataTermino { get; set; }

    public TimeSpan HorarioTermino { get; set; }

    public string TipoAtividade { get; set; } = null!;

    public int IdOrganizacao { get; set; }

    public int IdResidente { get; set; }

    public virtual ICollection<Acompanhante> Acompanhantes { get; set; } = new List<Acompanhante>();

    public virtual Organizacao IdOrganizacaoNavigation { get; set; } = null!;

    public virtual Residente IdResidenteNavigation { get; set; } = null!;
}
