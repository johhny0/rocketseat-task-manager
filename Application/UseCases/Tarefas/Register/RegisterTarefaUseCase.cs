using Communication.Request;
using Communication.Response;
using Models;

namespace Application.UseCases.Tarefas.Register;

public class RegisterTarefaUseCase
{
    public ResponseRegisterTarefa Execute(RequestRegisterTarefa request)
    {
        return new ResponseRegisterTarefa(Guid.NewGuid(), request.Nome);
    }
}
