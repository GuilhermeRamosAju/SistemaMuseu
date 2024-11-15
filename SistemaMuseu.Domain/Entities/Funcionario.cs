using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMuseu.Domain.Entities
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; }
        public decimal Salario { get; set; }
        public string Departamento { get; set; } = string.Empty;
        public int NivelAcesso { get; set; }
        public string Especialidade { get; set; } = string.Empty;
    }
}
