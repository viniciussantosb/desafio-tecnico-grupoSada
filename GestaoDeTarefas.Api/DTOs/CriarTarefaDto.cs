using System.ComponentModel.DataAnnotations;
using GestaoDeTarefas.Domain.Enums;

namespace GestaoDeTarefas.Api.DTOs;

public record CriarTarefaDto(
    [Required(ErrorMessage = "O título é obrigatório.")] string Titulo,
    string? Descricao,
    DateOnly? DataVencimento,
    StatusTarefa Status = StatusTarefa.Pendente
);