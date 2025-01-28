using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models;

public class Visita
{
    [Key]
    [DisplayName("Código")]
    public int Id { get; set; }

    public DateOnly DataVisita { get; set; }

    public TimeOnly HorarioVisita { get; set; }

    public int IdResidente { get; set; }

    public int IdVisitante { get; set; }
}

