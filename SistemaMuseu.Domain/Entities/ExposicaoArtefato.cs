namespace SistemaMuseu.Domain.Entities;

public class ExposicaoArtefato
{
    public int ExposicaoId { get; set; }
    public Exposicao Exposicao { get; set; } = new Exposicao();
    public int ArtefatoId { get; set; }
    public Artefato Artefato { get; set; } = new Artefato();
}
