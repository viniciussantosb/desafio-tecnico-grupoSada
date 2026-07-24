using System.Text.Json.Serialization;

namespace GestaoDeTarefas.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusTarefa
{
    Pendente = 1,
    EmProgresso = 2,
    Concluida = 3
}