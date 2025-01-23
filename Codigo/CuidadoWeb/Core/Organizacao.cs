using System;
using System.Collections.Generic;

namespace Core;

public partial class Organizacao
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public virtual ICollection<AtividadeExterna> AtividadeExterna { get; set; } = new List<AtividadeExterna>();

    public virtual ICollection<FornecedorOrganizacao> FornecedorOrganizacao { get; set; } = new List<FornecedorOrganizacao>();

    public virtual ICollection<Funcionario> Funcionario { get; set; } = new List<Funcionario>();

    public virtual ICollection<Produto> Produto { get; set; } = new List<Produto>();

    public virtual ICollection<Residente> Residente { get; set; } = new List<Residente>();
}
