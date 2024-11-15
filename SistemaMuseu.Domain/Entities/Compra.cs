namespace SistemaMuseu.Domain.Entities;

public class Compra
{
    public int Id { get; set; }
    public int FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; } = new Fornecedor();
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string FormaPagamento { get; set; } = string.Empty;
    public string NumeroNF { get; set; } = string.Empty;
}
