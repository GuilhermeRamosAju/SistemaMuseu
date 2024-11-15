namespace SistemaMuseu.Domain.Entities;

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Local { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Organizador { get; set; } = string.Empty;
    public int CapacidadeMaxima { get; set; }
    public decimal CustoIngresso { get; set; }
    public string TipoEvento { get; set; } = string.Empty;

    // Propriedade de navegação para a tabela de relacionamento Evento_Visitante
    public ICollection<EventoVisitante> EventoVisitantes { get; set; }
}
