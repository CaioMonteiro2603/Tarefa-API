using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Tarefa.Models;
using Tarefa.Repository.Interface;

namespace Tarefa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
            
        }

        [HttpGet]
        public async Task<ActionResult<IList<TarefaModel>>> FindAllAsync()
        {
            var tarefa = await _tarefaRepository.FindAll();

            if (tarefa != null && tarefa.Count > 0)
            {
                return Ok(tarefa);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TarefaModel>> FindIdAsync([FromRoute] int id)
        {
            var tarefa = await _tarefaRepository.FindById(id); 

            if(tarefa != null)
            {
                return Ok(tarefa);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Post([FromBody] TarefaModel tModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tarefa = await _tarefaRepository.Insert(tModel);

            var url = Request.GetEncodedUrl().EndsWith("/") ?
                        Request.GetEncodedUrl() :
                        Request.GetEncodedUrl() + "/";

            return Created(url, tarefa);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] TarefaModel tModel)
        {
            if(!ModelState.IsValid || (id != tModel.TarefaId))
            {
                return BadRequest();
            } else
            {
                _tarefaRepository.Update(tModel);
                return NoContent();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TarefaModel>> Delete([FromRoute]int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var tarefa = _tarefaRepository.FindById(id);

            if(tarefa == null)
            {
                return NotFound();
            }

            _tarefaRepository.Delete(id);
            return NoContent();
        }


    }
}
