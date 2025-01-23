using System;
using System.Collections.Generic;

namespace Core;

public partial class FonteRenda
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Valor { get; set; }

    public int IdResidente { get; set; }

    public virtual Residente IdResidenteNavigation { get; set; } = null!;
}
