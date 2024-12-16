using Communication.Request;
using Models;

namespace Application.UseCases.Tarefas
{
    public class TarefasRepository
    {
        private static List<Tarefa> _tarefas = [
            new Tarefa("Tarefa 1")
            {
                Id = Guid.Parse("a1e58926-7556-42e6-a568-c3686265ada6"),
                Descricao = "Descricao 1",
                PrioridadeEnum = PrioridadeEnum.Baixa,
                DataLimite = new DateOnly(2022, 12, 31)
            },
            new Tarefa("Tarefa 2")
            {
                Id = Guid.Parse("83511923-a09d-4cc6-8a63-221b6988fc65"),
                Descricao = "Descricao 1",
                PrioridadeEnum = PrioridadeEnum.Baixa,
                DataLimite = new DateOnly(2022, 12, 31)
            },

            ];

        public Tarefa Add(RequestRegisterTarefa tarefa)
        {
            var newTarefa = new Tarefa(tarefa.Nome)
            {
                Id = Guid.NewGuid(),
                Descricao = tarefa.Descricao,
                PrioridadeEnum = tarefa.PrioridadeEnum,
                DataLimite = tarefa.DataLimite
            };

            _tarefas.Add(newTarefa);

            return newTarefa;
        }

        public List<Tarefa> GetAll()
        {
            return _tarefas;
        }

        public Tarefa? GetById(Guid id)
        {
            return _tarefas.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(Guid id)
        {
            _tarefas.RemoveAll(t => t.Id == id);
        }
    }

}
