using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models;

public class VisitanteViewModel
{
    [Key]
    [DisplayName("Código")]
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? PrimeiroTelefone { get; set; }

    public string? SegundoTelefone { get; set; }
}

