using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class EventoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do evento é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do evento deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data do evento é obrigatória.")]
    public DateTime Data { get; set; }

    [StringLength(100, ErrorMessage = "O local do evento deve ter no máximo 100 caracteres.")]
    public string Local { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "A descrição do evento não pode ter mais de 500 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "A capacidade máxima deve ser um valor positivo.")]
    public int CapacidadeMaxima { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "O custo do ingresso não pode ser negativo.")]
    public decimal CustoIngresso { get; set; }

    [StringLength(50, ErrorMessage = "O tipo de evento deve ter no máximo 50 caracteres.")]
    public string TipoEvento { get; set; } = string.Empty;
}
