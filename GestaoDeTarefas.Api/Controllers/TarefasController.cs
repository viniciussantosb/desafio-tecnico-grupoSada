using GestaoDeTarefas.Api.DTOs;
using GestaoDeTarefas.Domain.Entities;
using GestaoDeTarefas.Domain.Enums;
using GestaoDeTarefas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeTarefas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ITarefaRepository _repository;

    public TarefasController(ITarefaRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarTarefaDto dto)
    {
        var tarefa = new Tarefa(dto.Titulo, dto.Descricao, dto.DataVencimento, dto.Status);
        await _repository.AdicionarAsync(tarefa);

        return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var tarefa = await _repository.ObterPorIdAsync(id);
        if (tarefa == null) return NotFound(new { mensagem = "Tarefa não encontrada." });

        return Ok(tarefa);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodas([FromQuery] StatusTarefa? status, [FromQuery] DateOnly? dataVencimento)
    {
        var tarefas = await _repository.ObterTodasAsync(status, dataVencimento);
        return Ok(tarefas);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarTarefaDto dto)
    {
        var tarefa = await _repository.ObterPorIdAsync(id);
        if (tarefa == null) return NotFound(new { mensagem = "Tarefa não encontrada." });

        tarefa.Atualizar(dto.Titulo, dto.Descricao, dto.DataVencimento, dto.Status);
        await _repository.AtualizarAsync(tarefa);

        return Ok(new
        {
            mensagem = $"Tarefa {id} atualizada com sucesso",
            dados = tarefa
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        var tarefa = await _repository.ObterPorIdAsync(id);
        if (tarefa == null) return NotFound(new { mensagem = "Tarefa não encontrada." });

        await _repository.RemoverAsync(id);
        return NoContent();
    }
}