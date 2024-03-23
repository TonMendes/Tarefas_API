using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefa_API.Context;
using Tarefa_API.Entities;

namespace Tarefa_API.Controllers
{
    [ApiController]
    [Route("Tarefa_COntroller")]
    public class TarefaController : ControllerBase
    {

        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
                _context = context;
        }

        [HttpGet("BuscandoTodasTarefas")]
        public IActionResult GetTarefas()
        {
            var TarefaBanco = _context.Tarefas;
            if(TarefaBanco == null)
            {
                return NotFound();
            }
            return Ok(TarefaBanco);
        }

        [HttpGet("BuscarTarefaPorId")]
        public IActionResult BuscarId(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            if(tarefaBanco == null)
            {
                return NotFound();
            }
            return Ok(tarefaBanco);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefaBanco = _context.Tarefas.FirstOrDefault(x => x.Titulo == titulo);
            if (tarefaBanco == null)
            {
                return NotFound();
            }
            return Ok(tarefaBanco);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefaBanco = _context.Tarefas.FirstOrDefault(x => x.Data == data);
            if (tarefaBanco == null)
            {
                return NotFound();
            }
            return Ok(tarefaBanco);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(int status)
        {
            var tarefaBanco = _context.Tarefas.FirstOrDefault(x => x.Status == status);
            if (tarefaBanco == null)
            {
                return NotFound();
            }
            return Ok(tarefaBanco);
        }




        [HttpPost("InserindoTarefa")]
        public IActionResult PosTarefas(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpDelete("DeletandoTarefa")]
        public IActionResult DeleteTarefas(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            if(tarefaBanco == null)
            {
                return NotFound();
            }
            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            return Ok(tarefaBanco);

        }
    }
}
