using System;
using System.Collections.Generic;

namespace Core;

public partial class Organizacao
{
    public int Idorganizacao { get; set; }

    public string Cnpj { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public virtual ICollection<Atividadeexterna> Atividadeexternas { get; set; } = new List<Atividadeexterna>();

    public virtual ICollection<Fornecedororganizacao> Fornecedororganizacaos { get; set; } = new List<Fornecedororganizacao>();

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    public virtual ICollection<Residente> Residentes { get; set; } = new List<Residente>();
}
