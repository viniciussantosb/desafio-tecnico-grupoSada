using GestaoDeTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeTarefas.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tarefa> Tarefas { get; set; }
}