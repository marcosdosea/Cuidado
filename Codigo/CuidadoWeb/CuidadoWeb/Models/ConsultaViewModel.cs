using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CuidadoWeb.Models;

public class ConsultaViewModel
{
    [Key]
    [DisplayName("Código")]
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public DateTime DataConsulta { get; set; }

    public DateTime? DataRetorno { get; set; }

    public string MedicoResponsavel { get; set; } = null!;

    public bool ExamesSolicitados { get; set; }

    public int IdEspecialidadeMedicina { get; set; }

    public int IdResidente { get; set; }

    public int IdFuncionario { get; set; }
}

