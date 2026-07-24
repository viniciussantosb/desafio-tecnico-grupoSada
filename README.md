#Sistema de Gestão de Tarefas

API RESTful para gerenciamento de tarefas desenvolvida em .NET 10 utilizando Entity Framework Core InMemory e Clean Architecture.

---

## Arquitetura e Decisões de Design

Para este projeto, optei por organizar o código utilizando os princípios de Clean Architecture dividida em três camadas simples: Domain, Infrastructure e Api.

1. Separação de Responsabilidades (Organização): Mantendo a regra de negócio (tarefas, status e interfaces) na camada de Domain, o código da aplicação fica totalmente isolado dos detalhes técnicos de banco de dados ou de frameworks Web.

2. Facilidade de Manutenção e Evolução: Como o sistema foi desacoplado usando interfaces, o controller não sabe como o banco de dados funciona. Se no futuro for necessário trocar o banco em memória (InMemory) por um banco SQL real (como PostgreSQL ou SQL Server), é possível criar uma nova implementação na camada de Infrastructure e registrá-la, sem precisar alterar a regras de negócio ou a API.

3. Inversão de Dependência: As camadas de nível mais alto (como as regras do sistema) não dependem das camadas de nível mais baixo (como a forma de salvar no banco). Ambas dependem de abstrações (interfaces), o que torna o sistema muito mais flexível e fácil de testar.

---

## Tecnologias Utilizadas

*   .NET 10.0 SDK
*   Entity Framework Core InMemory
*   Scalar.AspNetCore (Interface OpenAPI para testes da API)
*   C# / Visual Studio Code

---

## Como Rodar o Projeto

### Pré-requisitos
*   .NET 10.0 instalado.

### Passo a Passo
1. Abra a pasta do projeto no Visual Studio Code.
2. Abra o terminal na raiz da solução e navegue até a pasta da API:
3. Execute o comando cd GestaoDeTarefas.Api
4. Execute o projeto com o comando dotnet run

##Após rodar a aplicação no Scalar

No painel do Scalar, você verá o grupo Tarefas com todas as rotas listadas.

##1. Cadastro de Tarefa (POST /api/tarefas)
Permite criar uma nova tarefa e gera um ID numérico sequencial único (ex: 1, 2...).

Clique no endpoint POST /api/tarefas.

Clique no botão Test Request (ou no campo de código/body).

No corpo da requisição (Body), cole o seguinte JSON:

JSON
{
  "titulo": "Teste título",
  "descricao": "Descrição teste",
  "dataVencimento": "2026-08-15",
  "status": "EmProgresso"
}

#Opções válidas de Status: "Pendente", "EmProgresso" ou "Concluida", Ou 1, 2, 3, que correspondem a 1 = "Pendente", 2 = "EmProgresso" ou 3 = "Concluida",

Clique em Send (Enviar).

#Resultado esperado: Retorno com 201 Created contendo o JSON da tarefa criada com o "id": 1.

##2. Listagem e Filtros (GET /api/tarefas)
Permite visualizar todas as tarefas ou aplicar filtros por Status e/ou Data de Vencimento.

A. Listar Todas
Clique em GET /api/tarefas -> Test Request -> Send (sem preencher nenhum parâmetro).

Resultado esperado: Retorno 200 OK com uma lista contendo todas as tarefas cadastradas.

B. Filtrar por Status
Na mesma rota, vá na seção Query Parameters (Parâmetros de Consulta).

No campo status, digite: EmProgresso.

Clique em Send.

Resultado esperado: Retorna apenas as tarefas com status "EmProgresso".

C. Filtrar por Data de Vencimento
No campo dataVencimento, informe a data: 2026-08-15.

Clique em Send.

#Resultado esperado: Retorna as tarefas com vencimento nessa data.

##3. Buscar por ID (GET /api/tarefas/{id})
Clique em GET /api/tarefas/{id} -> Test Request.

No campo de parâmetro id, digite: 1.

Clique em Send.

#Resultado esperado: Retorno 200 OK com os detalhes da Tarefa 1. (Se digitar um ID inexistente como 99, deve retornar 404 Not Found).

##4. Edição de Tarefa (PUT /api/tarefas/{id})
Permite atualizar o título, descrição, data de vencimento e status de uma tarefa existente.

Clique em PUT /api/tarefas/{id} -> Test Request.

No campo id da URL, digite: 1.

No Body (JSON), envie os novos dados atualizados:

JSON
{
  "titulo": "Teste 2",
  "descricao": "Teste 3",
  "dataVencimento": "2026-08-15",
  "status": "Concluida"
}
Clique em Send.

#Resultado esperado: Aparecerá a seguinte mensagem: "A tarefa (Id da tarefa) foi atualizada com sucesso" e exibirá os novos dados enviados da tarefa.

(Dica: Faça um GET /api/tarefas/1 novamente para confirmar que a alteração foi salva).

##5. Exclusão de Tarefa (DELETE /api/tarefas/{id})
Clique em DELETE /api/tarefas/{id} -> Test Request.

No parâmetro id, digite: 1.

Clique em Send.

#Resultado esperado: A tarefa (Id da tarefa) foi excluída com sucesso.

(Se você tentar buscar ou listar essa tarefa novamente, receberá 404 Not Found ou a mensagem "Tarefa não encontrada".
