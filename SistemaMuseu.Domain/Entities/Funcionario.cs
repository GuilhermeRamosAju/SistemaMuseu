namespace SistemaMuseu.Domain.Entities;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public string Departamento { get; set; } = string.Empty;
    public int NivelAcesso { get; set; }
    public string Especialidade { get; set; } = string.Empty;
}
