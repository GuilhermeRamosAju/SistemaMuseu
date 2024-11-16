using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class VisitanteDTO
{
    [Required(ErrorMessage = "O nome do visitante é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do visitante não pode ultrapassar 100 caracteres.")]
    public string Nome { get; set; }

    [Range(0, 130, ErrorMessage = "A idade deve ser um valor positivo.")]
    public int? Idade { get; set; }

    [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
    [StringLength(100, ErrorMessage = "O e-mail não pode ultrapassar 100 caracteres.")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "O número de telefone fornecido não é válido.")]
    [StringLength(20, ErrorMessage = "O telefone não pode ultrapassar 20 caracteres.")]
    public string? Telefone { get; set; }

    [DataType(DataType.Date, ErrorMessage = "A data da visita deve ser uma data válida.")]
    public DateTime? DataVisita { get; set; }

    [StringLength(50, ErrorMessage = "O tipo de ingresso não pode ultrapassar 50 caracteres.")]
    public string? TipoIngresso { get; set; }

    [StringLength(50, ErrorMessage = "A nacionalidade não pode ultrapassar 50 caracteres.")]
    public string? Nacionalidade { get; set; }
}
