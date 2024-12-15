using Application.UseCases.Tarefas.Delete;
using Application.UseCases.Tarefas.GetAll;
using Application.UseCases.Tarefas.GetById;
using Application.UseCases.Tarefas.Register;
using Application.UseCases.Tarefas.Update;
using Communication.Request;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private RegisterTarefaUseCase _registerUseCase;
        private UpdateTarefaUseCase _updateUseCase;
        private GetAllTarefaUseCase _getAllUseCase;
        private GetTarefaByIdUseCase _getByIdUseCase;
        private DeleteTarefaUseCase _deleteUseCase;

        public TarefaController()
        {
            _registerUseCase = new RegisterTarefaUseCase();
            _updateUseCase = new UpdateTarefaUseCase();
            _getAllUseCase = new GetAllTarefaUseCase();
            _getByIdUseCase = new GetTarefaByIdUseCase();
            _deleteUseCase = new DeleteTarefaUseCase();
            
        }
        /*
- Deve ser possível criar uma tarefa;
- Deve ser possível visualizar todas as tarefas criadas;
- Deve ser possível visualizar uma tarefa buscando pelo seu id;
- Deve ser possível editar informações de uma tarefa;
- Deve ser possível excluir uma tarefa.
    */

        [HttpGet]
        [ProducesResponseType<ResponseAllTarefas>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResponseAllTarefas>(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Index()
        {
            var response = _getAllUseCase.Execute();
            
            if (!response.Tarefas.Any()) return NoContent();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<ResponseTarefa>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid id)
        {
            var tarefa = _getByIdUseCase.Execute(id);
            return Ok(tarefa);
        }


        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterTarefa), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] RequestRegisterTarefa tarefa)
        {
            var result = _registerUseCase.Execute(tarefa);
            return Created(string.Empty, result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTarefa), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RequestUpdateTarefa tarefa)
        {
            _updateUseCase.Execute(id, tarefa);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType<ResponseTarefa>(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _deleteUseCase.Execute(id);
            return NoContent();
        }

    }
}
