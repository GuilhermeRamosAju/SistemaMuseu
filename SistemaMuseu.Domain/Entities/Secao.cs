namespace SistemaMuseu.Domain.Entities;

public class Secao
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tema { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int ResponsavelId { get; set; }
    public Funcionario Responsavel { get; set; } = new Funcionario();
    public int Capacidade { get; set; }
    public decimal Temperatura { get; set; }
    public decimal Umidade { get; set; }
    public int NivelSeguranca { get; set; }
}
