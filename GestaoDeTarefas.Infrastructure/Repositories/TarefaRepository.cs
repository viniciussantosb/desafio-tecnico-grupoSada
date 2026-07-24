using GestaoDeTarefas.Domain.Entities;
using GestaoDeTarefas.Domain.Enums;
using GestaoDeTarefas.Domain.Interfaces;
using GestaoDeTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Infrastructure.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _context;

    public TarefaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Tarefa?> ObterPorIdAsync(int id)
    {
        return await _context.Tarefas.FindAsync(id);
    }

    public async Task<IEnumerable<Tarefa>> ObterTodasAsync(StatusTarefa? status, DateOnly? dataVencimento)
    {
        var query = _context.Tarefas.AsQueryable();

        if (status.HasValue)
            query = query.Where(t => t.Status == status.Value);

        if (dataVencimento.HasValue)
            query = query.Where(t => t.DataVencimento.HasValue && t.DataVencimento.Value == dataVencimento.Value);

        return await query.ToListAsync();
    }

    public async Task AdicionarAsync(Tarefa tarefa)
    {
        await _context.Tarefas.AddAsync(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var tarefa = await ObterPorIdAsync(id);
        if (tarefa != null)
        {
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }

}