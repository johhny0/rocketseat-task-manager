using Communication.Response;

namespace Application.UseCases.Tarefas.GetAll;

public class GetAllTarefaUseCase
{
    public ResponseAllTarefas Execute()
    {
        return new ResponseAllTarefas()
        {
            Tarefas = [
                new  ResponseShortTarefa(){ Id = Guid.NewGuid(), Nome = "Ola" },
                new  ResponseShortTarefa(){ Id = Guid.NewGuid(), Nome = "Ola" },
                new  ResponseShortTarefa(){ Id = Guid.NewGuid(), Nome = "Ola" },
                new  ResponseShortTarefa(){ Id = Guid.NewGuid(), Nome = "Ola" },
                ]
        };
    }
}
