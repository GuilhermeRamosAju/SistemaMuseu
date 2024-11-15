using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMuseu.Domain.Entities
{
    internal class EventoVisitante
    {
        public int EventoId { get; set; }
        public Evento Evento { get; set; } = new Evento();
        public int VisitanteId { get; set; }
        public Visitante Visitante { get; set; } = new Visitante();
    }
}
