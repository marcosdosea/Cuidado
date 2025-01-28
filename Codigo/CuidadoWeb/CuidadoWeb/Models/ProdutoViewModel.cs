using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models;

public class Produto
{
    [Key]
    [DisplayName("Código")]
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Classificacao { get; set; } = null!;

    public int IdOrganizacao { get; set; }
}

