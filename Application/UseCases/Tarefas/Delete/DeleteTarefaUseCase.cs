namespace Application.UseCases.Tarefas.Delete;

public class DeleteTarefaUseCase
{
    private TarefasRepository _repository = new();

    public void Execute(Guid id)
    {
        _repository.Remove(id);    
    }
}
