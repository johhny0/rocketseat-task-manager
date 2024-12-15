using Models;

namespace Communication.Response;

public class ResponseAllTarefas
{
    public List<ResponseShortTarefa> Tarefas { get; set; }
}

public class ResponseShortTarefa
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}