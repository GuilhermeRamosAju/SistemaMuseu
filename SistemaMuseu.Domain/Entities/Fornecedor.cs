namespace SistemaMuseu.Domain.Entities;

public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Contato { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string TipoMaterial { get; set; } = string.Empty;
    public string CNPJ { get; set; } = string.Empty;
    public decimal Avaliacao { get; set; }
    public bool ContratoAtivo { get; set; }
}
