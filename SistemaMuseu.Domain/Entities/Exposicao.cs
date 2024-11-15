using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMuseu.Domain.Entities
{
    internal class Exposicao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int CapacidadeMaxima { get; set; }
        public string TipoDoacao { get; set; } = string.Empty;
        public decimal CustoTotal { get; set; }
        public int ResponsavelId { get; set; }
        public Funcionario Responsavel { get; set; } = new Funcionario();
    }
}
