using System;
using System.Collections.Generic;

namespace Core;

public partial class Acompanhante
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int IdAtividadeExterna { get; set; }

    public virtual AtividadeExterna IdAtividadeExternaNavigation { get; set; } = null!;
}
