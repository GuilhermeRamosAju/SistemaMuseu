using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMuseu.Domain.Entities
{
    internal class Compra
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; } = new Fornecedor();
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string FormaPagamento { get; set; } = string.Empty;
        public string NumeroNF { get; set; } = string.Empty;
    }
}
