using Communication.Request;
using Models;

namespace Application.UseCases.Tarefas.Update;

public class UpdateTarefaUseCase
{
    private readonly TarefasRepository _repository = new();

    public void Execute(Guid id, RequestUpdateTarefa request)
    {
        var tarefa  = _repository.GetById(id) ?? throw new Exception("Tarefa não encontrada");
        tarefa.Nome = request.Nome;
        tarefa.Descricao = request.Descricao;
        tarefa.DataLimite = request.DataLimite;
        tarefa.PrioridadeEnum = request.PrioridadeEnum;
        tarefa.Status = request.Status;
    }
}
