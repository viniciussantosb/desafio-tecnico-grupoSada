using System.Text.Json.Serialization;
using GestaoDeTarefas.Domain.Interfaces;
using GestaoDeTarefas.Infrastructure.Context;
using GestaoDeTarefas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Title = "API de Gestão de Tarefas";
        document.Info.Version = "v1";


        document.Info.Description = """
            ## API de Gestão de Tarefas
            
            ### Como usar:
            1. Para criar uma tarefa, envie um `POST` para `/api/tarefas`.
            2. O formato de data utilizado para vencimentos é `YYYY-MM-DD`.
            """;

        return Task.CompletedTask;
    });
});

// 1. Configura Controllers e conversão de Enums para texto no JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddOpenApi();

// 3. Banco de dados InMemory
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("GestaoDeTarefasDb"));

// 4. Injeção de Dependência
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();