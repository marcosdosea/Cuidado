using System;
using System.Collections.Generic;

namespace Core;

public partial class PlanejamentoCuidado
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public string FrequenciaDiaria { get; set; } = null!;

    public bool Continuo { get; set; }

    public int IdTipoCuidaddo { get; set; }

    public int IdProduto { get; set; }

    public virtual ICollection<Cuidado> Cuidado { get; set; } = new List<Cuidado>();

    public virtual Produto IdProdutoNavigation { get; set; } = null!;

    public virtual TipoCuidado IdTipoCuidaddoNavigation { get; set; } = null!;

    public virtual ICollection<PlanejamentoCuidadoDiario> PlanejamentoCuidadoDiario { get; set; } = new List<PlanejamentoCuidadoDiario>();
}
