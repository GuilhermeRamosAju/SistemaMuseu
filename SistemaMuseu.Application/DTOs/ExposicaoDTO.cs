using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class ExposicaoDTO
{
    [Required(ErrorMessage = "O nome da exposição é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome da exposição deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de início é obrigatória.")]
    public DateTime DataInicio { get; set; }

    [Required(ErrorMessage = "A data de término é obrigatória.")]
    public DateTime DataFim { get; set; }

    [StringLength(100, ErrorMessage = "O local da exposição deve ter no máximo 100 caracteres.")]
    public string Local { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "A descrição da exposição não pode ter mais de 500 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "A capacidade máxima deve ser um valor positivo.")]
    public int CapacidadeMaxima { get; set; }

    [StringLength(50, ErrorMessage = "O tipo de doação deve ter no máximo 50 caracteres.")]
    public string TipoDoacao { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "O custo total não pode ser negativo.")]
    public decimal CustoTotal { get; set; }

    public int ResponsavelId { get; set; }
}
