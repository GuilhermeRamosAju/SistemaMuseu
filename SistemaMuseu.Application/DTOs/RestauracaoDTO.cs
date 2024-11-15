using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class RestauracaoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A data de início é obrigatória.")]
    public DateTime DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    [StringLength(1000, ErrorMessage = "A descrição não pode ultrapassar 1000 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "O custo deve ser um valor positivo.")]
    public decimal? Custo { get; set; }

    [StringLength(1000, ErrorMessage = "As técnicas utilizadas não podem ultrapassar 1000 caracteres.")]
    public string TecnicasUtilizadas { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Os materiais usados não podem ultrapassar 1000 caracteres.")]
    public string MateriaisUsados { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "O status não pode ultrapassar 50 caracteres.")]
    public string Status { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Artefato associado é obrigatório.")]
    public int ArtefatoId { get; set; }
}
