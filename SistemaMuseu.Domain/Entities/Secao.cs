using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMuseu.Domain.Entities
{
    internal class Secao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tema { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Responsavel { get; set; }
        public Funcionario ResponsavelFuncionario { get; set; } = new Funcionario();
        public int Capacidade { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Umidade { get; set; }
        public int NivelSeguranca { get; set; }
    }
}
