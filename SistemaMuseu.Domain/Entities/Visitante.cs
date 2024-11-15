namespace SistemaMuseu.Domain.Entities;

public class Visitante
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime DataVisita { get; set; }
    public string TipoIngresso { get; set; }
    public string Nacionalidade { get; set; }

    // Propriedade de navegação para a tabela de relacionamento Evento_Visitante
    public ICollection<EventoVisitante> EventoVisitantes { get; set; }
}
