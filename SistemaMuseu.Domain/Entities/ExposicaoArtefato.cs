using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMuseu.Domain.Entities
{
    internal class ExposicaoArtefato
    {
        public int ExposicaoId { get; set; }
        public Exposicao Exposicao { get; set; } = new Exposicao();
        public int ArtefatoId { get; set; }
        public Artefato Artefato { get; set; } = new Artefato();
    }
}
