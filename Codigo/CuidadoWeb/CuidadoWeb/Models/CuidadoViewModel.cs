using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models;

public class Cuidado
{
    [Key]
    [DisplayName("Código")]
    public int Id { get; set; }

    public DateTime DataExecucao { get; set; }

    public int IdFuncionario { get; set; }

    public int IdPlanejamentoCuidado { get; set; }

    public int IdResidente { get; set; }
}

