using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class CompraDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo FornecedorId é obrigatório.")]
    public int FornecedorId { get; set; }

    [Required(ErrorMessage = "O campo FornecedorNome é obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome do fornecedor deve ter no máximo 200 caracteres.")]
    public string FornecedorNome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data da compra é obrigatória.")]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "O valor total é obrigatório.")]
    [Range(0, double.MaxValue, ErrorMessage = "O valor total não pode ser negativo.")]
    public decimal ValorTotal { get; set; }

    [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Status é obrigatório.")]
    [StringLength(50, ErrorMessage = "O status deve ter no máximo 50 caracteres.")]
    public string Status { get; set; } = string.Empty;

    [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
    [StringLength(50, ErrorMessage = "A forma de pagamento deve ter no máximo 50 caracteres.")]
    public string FormaPagamento { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "O número da nota fiscal não pode ter mais de 20 caracteres.")]
    public string NumeroNF { get; set; } = string.Empty;
}
