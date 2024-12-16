using Communication.Response;
using Models;

namespace Application.UseCases.Tarefas.GetById;

public class GetTarefaByIdUseCase
{
    private readonly TarefasRepository _repository = new();

    public Tarefa? Execute(Guid id)
    {
        return _repository.GetById(id);
    }
}
