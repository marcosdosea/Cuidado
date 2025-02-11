using System;
using System.Collections.Generic;

namespace Core;

public partial class Aquisicao
{
    public int Id { get; set; }

    public string? Observacoes { get; set; }

    public DateTime DataSolicitacao { get; set; }

    public DateTime? DataEntrada { get; set; }

    public int IdFuncionario { get; set; }

    public int IdFornecedor { get; set; }

    public virtual ICollection<AquisicaoProduto> AquisicaoProduto { get; set; } = new List<AquisicaoProduto>();

    public virtual Fornecedor IdFornecedorNavigation { get; set; } = null!;

    public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;
}
