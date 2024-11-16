using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class FornecedorDTO
{
    [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do fornecedor deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "O contato do fornecedor deve ter no máximo 100 caracteres.")]
    public string Contato { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "O endereço do fornecedor deve ter no máximo 100 caracteres.")]
    public string Endereco { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "O tipo de material fornecido deve ter no máximo 100 caracteres.")]
    public string TipoMaterial { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "O CNPJ do fornecedor deve ter no máximo 20 caracteres.")]
    public string CNPJ { get; set; } = string.Empty;

    [Range(0, 10, ErrorMessage = "A avaliação do fornecedor deve estar entre 0 e 10.")]
    public decimal Avaliacao { get; set; }

    [Required(ErrorMessage = "O campo contrato ativo é obrigatório.")]
    public bool ContratoAtivo { get; set; }
}
