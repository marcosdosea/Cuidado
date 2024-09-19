using System;
using System.Collections.Generic;

namespace Core;

public partial class Fornecedor
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string? PrimeiroTelefone { get; set; }

    public string? SegundoTelefone { get; set; }

    public virtual ICollection<Aquisicao> Aquisicaos { get; set; } = new List<Aquisicao>();

    public virtual ICollection<Fornecedororganizacao> Fornecedororganizacaos { get; set; } = new List<Fornecedororganizacao>();
}
