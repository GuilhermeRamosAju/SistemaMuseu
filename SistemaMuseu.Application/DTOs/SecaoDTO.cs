using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class SecaoDTO
{
    [StringLength(100, ErrorMessage = "O nome da seção não pode ultrapassar 100 caracteres.")]
    public string? Nome { get; set; }

    [StringLength(100, ErrorMessage = "O tema da seção não pode ultrapassar 100 caracteres.")]
    public string? Tema { get; set; }

    [StringLength(1000, ErrorMessage = "A descrição da seção não pode ultrapassar 1000 caracteres.")]
    public string? Descricao { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "A capacidade deve ser um valor positivo.")]
    public int? Capacidade { get; set; }

    [Range(-100, 100, ErrorMessage = "A temperatura deve estar entre -100 e 100 graus.")]
    public decimal? Temperatura { get; set; }

    [Range(0, 100, ErrorMessage = "A umidade deve estar entre 0 e 100%.")]
    public decimal? Umidade { get; set; }

    [Range(1, 10, ErrorMessage = "O nível de segurança deve estar entre 1 e 10.")]
    public int? NivelSeguranca { get; set; }

    [Required(ErrorMessage = "O ID do funcionário responsável é obrigatório.")]
    public int? ResponsavelId { get; set; }
}
