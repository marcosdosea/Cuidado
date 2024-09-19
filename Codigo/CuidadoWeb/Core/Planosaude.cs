using System;
using System.Collections.Generic;

namespace Core;

public partial class Planosaude
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Numero { get; set; }

    public int NumeroSerie { get; set; }

    public string? PrimeiroTelefone { get; set; }

    public string? SegundoTelefone { get; set; }

    public int IdResidente { get; set; }

    public virtual Residente IdResidenteNavigation { get; set; } = null!;
}
