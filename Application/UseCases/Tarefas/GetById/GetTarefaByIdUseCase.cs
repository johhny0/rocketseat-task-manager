using Communication.Response;

namespace Application.UseCases.Tarefas.GetById;

public class GetTarefaByIdUseCase
{
    public ResponseTarefa Execute(Guid id)
    {
        return new ResponseTarefa("") { Id = id };
    }
}
