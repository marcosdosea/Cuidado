using System;
using System.Collections.Generic;

namespace Core;

public partial class FornecedorOrganizacao
{
    public int IdFornecedor { get; set; }

    public int IdOrganizacao { get; set; }

    public string? Observacoes { get; set; }

    public virtual Fornecedor IdFornecedorNavigation { get; set; } = null!;

    public virtual Organizacao IdOrganizacaoNavigation { get; set; } = null!;
}
