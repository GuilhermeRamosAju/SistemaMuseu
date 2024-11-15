using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class FuncionarioDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do funcionário deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "O cargo do funcionário deve ter no máximo 50 caracteres.")]
    public string Cargo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de contratação é obrigatória.")]
    public DateTime DataContratacao { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "O salário deve ser um valor positivo.")]
    public decimal Salario { get; set; }

    [StringLength(100, ErrorMessage = "O departamento deve ter no máximo 100 caracteres.")]
    public string Departamento { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "O nível de acesso deve ser um número inteiro positivo.")]
    public int NivelAcesso { get; set; }

    [StringLength(100, ErrorMessage = "A especialidade do funcionário deve ter no máximo 100 caracteres.")]
    public string Especialidade { get; set; } = string.Empty;
}
