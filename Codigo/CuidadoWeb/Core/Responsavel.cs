using System;
using System.Collections.Generic;

namespace Core;

public partial class Responsavel
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public string Vinculo { get; set; } = null!;

    public int NumeroCasa { get; set; }

    public string? Identificador { get; set; }

    public int Cep { get; set; }

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string? Complemento { get; set; }

    public string? PrimeiroTelefone { get; set; }

    public string? SegundoTelefone { get; set; }

    public int IdResidente { get; set; }

    public virtual Residente IdResidenteNavigation { get; set; } = null!;
}
