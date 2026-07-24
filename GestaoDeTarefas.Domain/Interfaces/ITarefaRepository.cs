using GestaoDeTarefas.Domain.Entities;
using GestaoDeTarefas.Domain.Enums;

namespace GestaoDeTarefas.Domain.Interfaces;

public interface ITarefaRepository
{
    Task<Tarefa?> ObterPorIdAsync(int id);
    Task<IEnumerable<Tarefa>> ObterTodasAsync(StatusTarefa? status, DateOnly? dataVencimento);
    Task AdicionarAsync(Tarefa tarefa);
    Task AtualizarAsync(Tarefa tarefa);
    Task RemoverAsync(int id);
}