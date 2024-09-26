using System;
using System.Collections.Generic;

namespace Core;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Classificacao { get; set; } = null!;

    public int IdOrganizacao { get; set; }

    public virtual ICollection<Aquisicaoproduto> Aquisicaoprodutos { get; set; } = new List<Aquisicaoproduto>();

    public virtual Organizacao IdOrganizacaoNavigation { get; set; } = null!;

    public virtual ICollection<Planejamentocuidado> Planejamentocuidados { get; set; } = new List<Planejamentocuidado>();
}
