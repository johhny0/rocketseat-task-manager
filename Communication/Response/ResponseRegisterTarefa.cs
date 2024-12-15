namespace Communication.Response;

public class ResponseRegisterTarefa(Guid id, string nome)
{
    public Guid Id { get; } = id;
    public string Nome { get; } = nome;
}
