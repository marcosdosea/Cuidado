using System;
using System.Collections.Generic;

namespace Core;

public partial class Visitante
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? PrimeiroTelefone { get; set; }

    public string? SegundoTelefone { get; set; }

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
