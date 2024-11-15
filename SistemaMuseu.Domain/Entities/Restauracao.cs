namespace SistemaMuseu.Domain.Entities;

public class Restauracao
{
    public int Id { get; set; }
    public int ArtefatoId { get; set; }
    public Artefato Artefato { get; set; } = new Artefato();
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Custo { get; set; }
    public string TecnicasUtilizadas { get; set; } = string.Empty;
    public string MateriaisUsados { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
