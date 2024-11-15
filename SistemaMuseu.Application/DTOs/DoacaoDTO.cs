using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class DoacaoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Doador é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo Doador deve ter no máximo 100 caracteres.")]
    public string Doador { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data da doação é obrigatória.")]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "O valor da doação é obrigatório.")]
    [Range(0, double.MaxValue, ErrorMessage = "O valor da doação não pode ser negativo.")]
    public decimal Valor { get; set; }

    [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "O tipo de doação deve ter no máximo 50 caracteres.")]
    public string TipoDoacao { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "O certificado deve ter no máximo 100 caracteres.")]
    public string Certificado { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo ArtefatoId é obrigatório.")]
    public int ArtefatoId { get; set; }
}
