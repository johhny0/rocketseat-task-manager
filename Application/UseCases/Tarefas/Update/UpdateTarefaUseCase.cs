using Communication.Request;
using Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Tarefas.Update;

public class UpdateTarefaUseCase
{
    public ResponseTarefa Execute(Guid id, RequestUpdateTarefa request)
    {
        return new ResponseTarefa(request.Nome)
        {
            Id = id,
            Descricao = request.Descricao,
            DataLimite = request.DataLimite,
            PrioridadeEnum = request.PrioridadeEnum,
            Status = request.Status,
        };
    }
}
