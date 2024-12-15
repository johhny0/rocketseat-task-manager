using Models;

namespace Communication.Request;

public class RequestRegisterTarefa(string nome)
{
    public string Nome { get; set; } = nome;
    public string? Descricao { get; set; }
    public PrioridadeEnum PrioridadeEnum { get; set; }
    public DateTime DataLimite { get; set; }
}
