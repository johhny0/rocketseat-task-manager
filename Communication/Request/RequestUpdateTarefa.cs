using Models;

namespace Communication.Request;

public class RequestUpdateTarefa(string nome)
{
    public string Nome { get; set; } = nome;
    public string? Descricao { get; set; }
    public PrioridadeEnum PrioridadeEnum { get; set; }
    public DateOnly DataLimite { get; set; }
    public StatusEnum Status { get; set; }
}
