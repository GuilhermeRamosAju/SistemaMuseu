using System.ComponentModel.DataAnnotations;

namespace SistemaMuseu.Application.DTOs;

public class ArtefatoDTO
{
    [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo 'Nome' deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Origem' é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo 'Origem' deve ter no máximo 100 caracteres.")]
    public string Origem { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Período Histórico' é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo 'Período Histórico' deve ter no máximo 100 caracteres.")]
    public string PeriodoHistorico { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Tipo' é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo 'Tipo' deve ter no máximo 100 caracteres.")]
    public string Tipo { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "O campo 'Descrição' deve ter no máximo 100 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Data de Aquisição' é obrigatório.")]
    public DateTime DataAquisicao { get; set; }

    [Required(ErrorMessage = "O campo 'Estado' é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo 'Estado' deve ter no máximo 50 caracteres.")]
    public string Estado { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "O campo 'Valor' deve ser um valor positivo.")]
    public decimal Valor { get; set; }

    [StringLength(100, ErrorMessage = "O campo 'Localização Atual' deve ter no máximo 100 caracteres.")]
    public string LocalizacaoAtual { get; set; } = string.Empty;
}
