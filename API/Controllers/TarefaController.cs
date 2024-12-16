using Application.UseCases.Tarefas.Delete;
using Application.UseCases.Tarefas.GetAll;
using Application.UseCases.Tarefas.GetById;
using Application.UseCases.Tarefas.Register;
using Application.UseCases.Tarefas.Update;
using Communication.Request;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly RegisterTarefaUseCase _registerUseCase;
        private readonly UpdateTarefaUseCase _updateUseCase;
        private readonly GetAllTarefaUseCase _getAllUseCase;
        private readonly GetTarefaByIdUseCase _getByIdUseCase;
        private readonly DeleteTarefaUseCase _deleteUseCase;

        public TarefaController()
        {
            _registerUseCase = new RegisterTarefaUseCase();
            _updateUseCase = new UpdateTarefaUseCase();
            _getAllUseCase = new GetAllTarefaUseCase();
            _getByIdUseCase = new GetTarefaByIdUseCase();
            _deleteUseCase = new DeleteTarefaUseCase();
            
        }

        [HttpGet]
        [ProducesResponseType<List<Tarefa>>(StatusCodes.Status200OK)]
        [ProducesResponseType<Tarefa>(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Index()
        {
            var tarefas = _getAllUseCase.Execute();
            
            if (tarefas.Count == 0) return NoContent();

            return Ok(tarefas);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<Tarefa>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid id)
        {
            var tarefa = _getByIdUseCase.Execute(id);
            if (tarefa is null) return NotFound();
            return Ok(tarefa);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Tarefa), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] RequestRegisterTarefa tarefa)
        {
            var result = _registerUseCase.Execute(tarefa);
            return Created(string.Empty, result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RequestUpdateTarefa tarefa)
        {
            _updateUseCase.Execute(id, tarefa);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _deleteUseCase.Execute(id);
            return NoContent();
        }

    }
}
