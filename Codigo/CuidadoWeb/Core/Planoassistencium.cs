using System;
using System.Collections.Generic;

namespace Core;

public partial class Planoassistencium
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Numero { get; set; }

    public int NumeroSerie { get; set; }

    public string? PrimeiroTelefone { get; set; }

    public string? SegundoTelefone { get; set; }

    public int ResidenteId { get; set; }

    public virtual Residente Residente { get; set; } = null!;
}
