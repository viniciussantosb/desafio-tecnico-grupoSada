using GestaoDeTarefas.Domain.Enums;

namespace GestaoDeTarefas.Domain.Entities;

public class Tarefa
{
    public int Id { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public string? Descricao { get; private set; }
    public DateOnly? DataVencimento { get; private set; }
    public StatusTarefa Status { get; private set; }

    //Construtor para criar as novas tarefas
    public Tarefa(string titulo, string? descricao, DateOnly? dataVencimento, StatusTarefa status)
    {
        Atualizar(titulo, descricao, dataVencimento, status);
    }

    public void Atualizar(string titulo, string? descricao, DateOnly? dataVencimento, StatusTarefa status)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("O título da tarefa é obrigatório.");

        Titulo = titulo;
        Descricao = descricao;
        DataVencimento = dataVencimento;
        Status = status;
    }
}