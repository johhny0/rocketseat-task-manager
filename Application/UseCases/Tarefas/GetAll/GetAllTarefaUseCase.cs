using Communication.Response;
using Models;

namespace Application.UseCases.Tarefas.GetAll;

public class GetAllTarefaUseCase
{
    private readonly TarefasRepository _repository = new();

    public List<Tarefa> Execute()
    {
       return _repository.GetAll();
    }
}
