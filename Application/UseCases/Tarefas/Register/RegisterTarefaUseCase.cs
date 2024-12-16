using Communication.Request;
using Communication.Response;
using Models;

namespace Application.UseCases.Tarefas.Register;

public class RegisterTarefaUseCase
{
    private readonly TarefasRepository _repository = new();
   
    public Tarefa Execute(RequestRegisterTarefa request)
    {
        return _repository.Add(request);
    }
}
