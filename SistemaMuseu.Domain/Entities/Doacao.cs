namespace SistemaMuseu.Domain.Entities;

public class Doacao
{
    public int Id { get; set; }
    public string Doador { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public int ArtefatoId { get; set; }
    public Artefato Artefato { get; set; } = new Artefato();
    public string Descricao { get; set; } = string.Empty;
    public string TipoDoacao { get; set; } = string.Empty;
    public string Certificado { get; set; } = string.Empty;
}
