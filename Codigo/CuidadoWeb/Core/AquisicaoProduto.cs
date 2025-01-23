using System;
using System.Collections.Generic;

namespace Core;

public partial class AquisicaoProduto
{
    public int IdAquisicao { get; set; }

    public int IdProduto { get; set; }

    public DateTime DataValidade { get; set; }

    public int Quantidade { get; set; }

    public string Lote { get; set; } = null!;

    public virtual Aquisicao IdAquisicaoNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
