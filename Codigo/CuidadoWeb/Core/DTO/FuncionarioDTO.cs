using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class FuncionarioDTO
    {
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Cargo { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal Salario { get; set; }
        public string? PrimeiroTelefone { get; set; }
        public string? SegundoTelefone { get; set; }
        public int IdOrganizacao { get; set; }
    }
}
