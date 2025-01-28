using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models;

public class OrganizacaoViewModel
{
    [Key]
    [DisplayName("Código")]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = null!;

    [Required]
    [DisplayName("CNPJ")]
    public string Cnpj { get; set; } = null!;
}

