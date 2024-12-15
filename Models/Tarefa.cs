namespace Models;

public class Tarefa(string nome)
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = nome;
    public string? Descricao { get; set; }
    public PrioridadeEnum PrioridadeEnum { get; set; }
    public DateOnly DataLimite { get; set; }
    public StatusEnum Status { get; set; }
}
