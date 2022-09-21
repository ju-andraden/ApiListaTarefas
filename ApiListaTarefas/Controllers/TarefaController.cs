using _4_Recursos;
using Aplicacao.Interfaces;
using Dominio.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost("CriarTarefa")]
        public async Task<IActionResult> TarefaCriada([FromBody] CriarTarefaDto criarTarefaDto)
        {
            var tarefaCriada = await _tarefaService.CriarTarefa(criarTarefaDto);

            return Created($"/{tarefaCriada.IdTarefa}", tarefaCriada);
        }

        [HttpGet("BuscarTarefaPeloId")]
        public async Task<IActionResult> LeiaTarefa(int id)
        {
            var tarefa = await _tarefaService.LerTarefa(id);

            if (tarefa is null)
            {
                return NotFound(Mensagens.TarefaNaoEncontrada);
            }
            return Ok(tarefa);
        }

        [HttpGet("BuscarTodasAsTarefas")]
        public async Task<IActionResult> LeiaTodasAsTarefas()
        {
            var leiaTodasAsTarefas = await _tarefaService.LerTodasAsTarefas();

            return Ok(leiaTodasAsTarefas);
        }

        [HttpPut("AtualizarTarefa")]
        public async Task<IActionResult> AtualizaTarefa(int id,
            [FromBody] AtualizarTarefaDto atualizarTarefaDto)
        {
            var resultado = await _tarefaService.AtualizarTarefa(id, atualizarTarefaDto);

            if (resultado is null)
            {
                return BadRequest(Mensagens.TarefaNaoEncontrada);
            }
            return Ok(resultado);
        }

        [HttpDelete("DeletarTarefa")]
        public async Task<IActionResult> DeletandoTarefa(int id)
        {
            var resultado = await _tarefaService.DeletarTarefa(id);

            if (resultado is null)
            {
                return NotFound(Mensagens.TarefaNaoEncontrada);
            }
            return Ok(resultado);
        }
    }
}