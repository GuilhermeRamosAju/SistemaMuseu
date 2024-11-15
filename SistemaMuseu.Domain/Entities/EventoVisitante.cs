namespace SistemaMuseu.Domain.Entities;

public class EventoVisitante
{
    public int EventoId { get; set; }
    public Evento Evento { get; set; } = new Evento();
    public int VisitanteId { get; set; }
    public Visitante Visitante { get; set; } = new Visitante();
}
