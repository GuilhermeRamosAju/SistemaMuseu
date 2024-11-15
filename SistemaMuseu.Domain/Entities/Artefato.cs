namespace SistemaMuseu.Domain.Entities;

public class Artefato
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Origem { get; set; } = string.Empty;
    public string PeriodoHistorico { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataAquisicao { get; set; }
    public string Estado { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string LocalizacaoAtual { get; set; } = string.Empty;

    // Propriedades de navegação para relacionamentos
    public ICollection<ExposicaoArtefato> ExposicoesArtefatos { get; set; }
    public ICollection<Doacao> Doacoes { get; set; }
    public ICollection<Restauracao> Restauracoes { get; set; }
}
