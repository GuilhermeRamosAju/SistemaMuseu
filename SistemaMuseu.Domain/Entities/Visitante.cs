using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMuseu.Domain.Entities
{
    internal class Visitante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataVisita { get; set; }
        public string TipoIngresso { get; set; }
        public string Nacionalidade { get; set; }
    }
}
