using System;
using System.Collections.Generic;

namespace Core;

public partial class AtividadeExterna
{
    public int Id { get; set; }

    public DateOnly DataRealizacao { get; set; }

    public TimeOnly HorarioRealizacao { get; set; }

    public DateOnly DataTermino { get; set; }

    public TimeOnly HorarioTermino { get; set; }

    public string TipoAtividade { get; set; } = null!;

    public int IdOrganizacao { get; set; }

    public int IdResidente { get; set; }

    public virtual ICollection<Acompanhante> Acompanhante { get; set; } = new List<Acompanhante>();

    public virtual Organizacao IdOrganizacaoNavigation { get; set; } = null!;

    public virtual Residente IdResidenteNavigation { get; set; } = null!;
}
